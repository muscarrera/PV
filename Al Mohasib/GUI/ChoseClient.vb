Public Class ChoseClient
    'Members
    Public cid As Integer = 0
    Public clientName As String = Form1.txtcltcomptoir.Text
    Public clientadresse As String = " "
    Public tp As String = 30
    Public num As String = 0
    Public isSell As Boolean
    Public isEditing As Boolean
    Public editMode As Boolean
    Public id As Integer

    Private dt As DataTable
    Private IND As Integer

    Private Sub ChoseClient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim tableName As String = "Client"

            If isSell = False Then
                tableName = "company"
            End If
        
            dt = c.SelectDataTable(tableName, {"*"})
        End Using

        FillBloc(0)
    End Sub
    Public Sub FillBloc(ByVal startIndex As Integer)
        If startIndex >= dt.Rows.Count Then Exit Sub

        Fpl.Controls.Clear()
        PlLeft.Visible = False

        If dt.Rows.Count > 0 Then
            Dim endIndex As Integer = startIndex + 23
            Dim i As Integer

            For i = startIndex To dt.Rows.Count - 1
                Dim id As Integer = CInt(dt.Rows(i).Item(0))
                Dim nm As String = dt.Rows(i).Item("name")
                Dim adr As String = dt.Rows(i).Item("adress")
                Dim tp As String = 0
                If isSell Then tp = dt.Rows(i).Item("type")
                Dim tel As String = dt.Rows(i).Item("tel")
                Dim Cl As New ClientBloc(id, nm, adr, tel, tp, Form1.admin)
                AddHandler Cl.IsActivated, AddressOf IsActivated
                AddHandler Cl.IsDisActivated, AddressOf IsdisActivated
                AddHandler Cl.IsChoosen, AddressOf Button1_Click
                Fpl.Controls.Add(Cl)
                If i = endIndex Then
                    Exit For
                End If
            Next
            IND = i
        End If
    End Sub
    Public Sub FillBloc_tEST(ByVal startIndex As Integer)
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

            If startIndex >= dt.Rows.Count - 1 Then Exit Sub

            Dim tableName As String = "Client"

            If isSell = False Then
                tableName = "company"
            End If
            Fpl.Controls.Clear()
            PlLeft.Visible = False

            dt = c.SelectDataTable(tableName, {"*"})
            If dt.Rows.Count > 0 Then
                Dim endIndex As Integer = startIndex + 23
                Dim i As Integer

                For i = startIndex To dt.Rows.Count - 1
                    Dim id As Integer = CInt(dt.Rows(i).Item(0))
                    Dim nm As String = dt.Rows(i).Item("name")
                    Dim adr As String = dt.Rows(i).Item("adress")
                    Dim tp As String = 0
                    If isSell Then tp = dt.Rows(i).Item("type")
                    Dim tel As String = dt.Rows(i).Item("tel")
                    Dim Cl As New ClientBloc(id, nm, adr, tel, tp, Form1.admin)
                    AddHandler Cl.IsActivated, AddressOf IsActivated
                    AddHandler Cl.IsDisActivated, AddressOf IsdisActivated
                    AddHandler Cl.IsChoosen, AddressOf Button1_Click
                    Fpl.Controls.Add(Cl)
                    If i = endIndex Then
                        Exit For
                    End If
                Next
                IND = i
            End If
        End Using
    End Sub
    Public Sub IsActivated(ByRef sender As Object, ByVal e As System.EventArgs)

        For Each t As ClientBloc In Fpl.Controls
            t.isActive = False
        Next

        Dim cl As ClientBloc = sender
        cid = cl.Arid
        clientName = cl.ClientName
        clientadresse = cl.Adresse
        tp = cl.Clienttype
        num = cl.num

        cl.isActive = True
        ''''''''
        'show extra
        If editMode = False Then Exit Sub
        If isSell = False Then Exit Sub
        PlLeft.Visible = False

        Lbnm.Text = "[ " & cl.Arid & " ] " & cl.ClientName

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim tableName As String = "Facture"
            If isSell = False Then tableName = "Bon"

            DataGridView1.Rows.Clear()

            Dim params As New Dictionary(Of String, Object)
            params.Add("clid", cl.Arid)
            params.Add("payed", False)
            params.Add("admin", True)

            Dim dt = c.SelectDataTable(tableName, {"*"}, params)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    DataGridView1.Rows.Add(dt.Rows(i).Item(0),
                                           CDate(dt.Rows(i).Item("date")).ToString("dd,MM yy"),
                                           dt.Rows(i).Item("total"), dt.Rows(i).Item("bl"))
                Next
            End If
        End Using
        If DataGridView1.Rows.Count > 0 Then PlLeft.Visible = True
    End Sub
    Public Sub IsdisActivated(ByVal Arid As Integer)
        cid = 0
        clientName = ""
        clientadresse = ""
        tp = 0

        PlLeft.Visible = False

    End Sub
    'search
    Public Sub searchForClient()
        'artdt = artta.GetDatalikename(, 1)
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim tableName As String = "Client"

            Fpl.Controls.Clear()

            If isSell = False Then
                tableName = "company"
            End If
            Dim params As New Dictionary(Of String, Object)


            If IsNumeric(txtsearch.Text) Then
                If isSell = True Then
                    params.Add("Clid like ", "%" & txtsearch.Text & "%")
                Else
                    params.Add("compid like ", "%" & txtsearch.Text & "%")
                End If

                dt = c.SelectDataTableSymbols(tableName, {"*"}, params)
            Else
                params.Add("name like ", "%" & txtsearch.Text & "%")

                dt = c.SelectDataTableSymbols(tableName, {"*"}, params)
            End If

            IND = 0

            If dt.Rows.Count > 0 Then
                FillBloc(0)
            End If








            'If isSell = True Then
            '    params.Add("Clid like ", "%" & txtsearch.Text & "%")
            'Else
            '    params.Add("compid like ", "%" & txtsearch.Text & "%")
            'End If

            'dt = c.SelectDataTableSymbols(tableName, {"*"}, params)
            'If dt.Rows.Count > 0 Then

            '    For i As Integer = 0 To dt.Rows.Count - 1
            '        'DataGridView1.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("name"), dt.Rows(i).Item("credit"), dt.Rows(i).Item("adress"), dt.Rows(i).Item("type"))
            '        Dim id As Integer = CInt(dt.Rows(i).Item(0))
            '        Dim nm As String = dt.Rows(i).Item("name")
            '        Dim adr As String = dt.Rows(i).Item("adress")
            '        Dim tp As String = dt.Rows(i).Item("type")
            '        Dim tel As String = dt.Rows(i).Item("tel")
            '        Dim Cl As New ClientBloc(id, nm, adr, tel, tp, Form1.admin)
            '        AddHandler Cl.IsActivated, AddressOf IsActivated
            '        AddHandler Cl.IsDisActivated, AddressOf IsdisActivated
            '        AddHandler Cl.IsChoosen, AddressOf Button1_Click
            '        Fpl.Controls.Add(Cl)
            '    Next
            'End If
            'params.Clear()
            'params.Add("name like ", "%" & txtsearch.Text & "%")

            'Dim dt2 = c.SelectDataTableSymbols(tableName, {"*"}, params)
            'If dt2.Rows.Count > 0 Then
            '    '  dt.Merge(dt2)

            '    For i As Integer = 0 To dt2.Rows.Count - 1
            '        Try
            '            If dt.Rows(i).Item(0) = dt2.Rows(i).Item(0) Then dt2.Rows.Remove(dt2.Rows(i))
            '        Catch ex As Exception
            '        End Try

            '        'dt.Rows.Add(dt2.Rows(i))
            '    Next
            '    dt.Merge(dt2)

            '    For i As Integer = 0 To dt.Rows.Count - 1
            '        'DataGridView1.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("name"), dt.Rows(i).Item("credit"), dt.Rows(i).Item("adress"), dt.Rows(i).Item("type"))
            '        Dim id As Integer = CInt(dt.Rows(i).Item(0))
            '        Dim nm As String = dt.Rows(i).Item("name")
            '        Dim adr As String = dt.Rows(i).Item("adress")
            '        Dim tp As String = dt.Rows(i).Item("type")
            '        Dim tel As String = dt.Rows(i).Item("tel")
            '        Dim Cl As New ClientBloc(id, nm, adr, tel, tp, Form1.admin)
            '        AddHandler Cl.IsActivated, AddressOf IsActivated
            '        AddHandler Cl.IsDisActivated, AddressOf IsdisActivated
            '        AddHandler Cl.IsChoosen, AddressOf Button1_Click
            '        Fpl.Controls.Add(Cl)
            '    Next
            'End If
        End Using
    End Sub

    'cancel
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    'ok
    Private Sub Button35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button35.Click
        cid = 0
        clientName = Form1.txtcltcomptoir.Text.Split("/")(0)
        clientadresse = "-"
        tp = 1
        num = 0
        Try
            If isSell = False Then clientName = Form1.txtcltcomptoir.Text.Split("/")(1)
        Catch ex As Exception
            clientName = Form1.txtcltcomptoir.Text.Split("/")(0)
        End Try

        isEditing = False
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOk.Click, Button4.Click
        If cid = 0 Then Exit Sub
        isEditing = False
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Sub DataGridView1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Button1_Click(Nothing, Nothing)
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        searchForClient()
        '''''searching

        'For i As Integer = 0 To DataGridView1.Rows.Count - 1
        '    If DataGridView1.Rows(i).Cells(1).Value.ToString.Contains(txtsearch.Text) Then
        '        DataGridView1.Rows(i).Selected = True
        '        DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.Rows(i).Index
        '        Exit For
        '    End If
        '    If DataGridView1.Rows(i).Cells(0).Value.ToString.Contains(txtsearch.Text) Then
        '        DataGridView1.Rows(i).Selected = True
        '        DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.Rows(i).Index
        '        Exit For
        '    End If
        'Next

    End Sub
    Private Sub txtsearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsearch.KeyPress
        If btOk.Enabled = True Then
            If e.KeyChar = Chr(13) Then

                'cid = DataGridView1.SelectedRows(0).Cells(0).Value
                'clientName = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                'clientadresse = DataGridView1.SelectedRows(0).Cells(3).Value.ToString
                'Me.DialogResult = Windows.Forms.DialogResult.OK


            End If
        End If
    End Sub
    Private Sub txtsearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsearch.KeyUp
        Button5_Click(Nothing, Nothing)
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtNewClt.Click
        If isSell Then
            Dim cltdlg As New Client
            cltdlg.btcon.Tag = "0"
            If cltdlg.ShowDialog = Windows.Forms.DialogResult.OK Then

            End If
        Else
            Dim cltdlg As New company
            cltdlg.btcon.Tag = "0"
            If cltdlg.ShowDialog = Windows.Forms.DialogResult.OK Then

            End If
        End If

        FillBloc(0)
    End Sub
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            id = DataGridView1.SelectedRows(0).Cells(0).Value
            Dim tableName = "Facture"
            If isSell = 0 Then tableName = "Bon"

            'Facture
            Dim params As New Dictionary(Of String, Object)
            params.Add("total", 0)
            params.Add("admin", False)
            params.Add("payed", False)


            Dim where As New Dictionary(Of String, Object)
            If isSell Then
                where.Add("fctid", id)
            Else
                where.Add("bonid", id)
            End If

            c.UpdateRecord(tableName, params, where)

            params.Clear()
            where.Clear()


            Dim table As DataTable
            If isSell Then
                Dim ta As New ALMohassinDBDataSetTableAdapters.DetailsFactureTableAdapter
                table = ta.GetData(id)
            Else
                Dim ta As New ALMohassinDBDataSetTableAdapters.DetailsBonTableAdapter
                table = ta.GetData(id)
            End If


            'Stock
            For i As Integer = 0 To table.Rows.Count - 1

                Dim arid = table.Rows(i).Item(0)
                Dim dpid = table.Rows(i).Item("depot")

                where.Add("arid", arid)
                where.Add("dpid", dpid)

                Dim dt = c.SelectDataTable("Detailstock", {"*"}, where)
                where.Clear()

                If dt.Rows.Count > 0 Then
                    Dim qte As Double = table.Rows(i).Item("qte")
                    Dim dsid As Integer = dt.Rows(0).Item(0)
                    If isSell = 0 Then qte = qte * (-1)
                    qte = qte + dt.Rows(0).Item("qte")

                    params.Add("qte", qte)
                    where.Add("DSID", dsid)

                    c.UpdateRecord("Detailstock", params, where)
                Else
                    Dim qte As Double = table.Rows(i).Item("qte")
                    If isSell = False Then qte = qte * (-1)

                    params.Add("arid", arid)
                    params.Add("dpid", dpid)
                    params.Add("qte", qte)
                    params.Add("unit", table.Rows(i).Item("unit"))
                    params.Add("cid", table.Rows(i).Item("cid"))

                    c.InsertRecord("Detailstock", params)
                End If
                params.Clear()
                where.Clear()
            Next
            params = Nothing
            where = Nothing
        End Using
        isEditing = True
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        FillBloc(IND)
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        IND -= 46
        If IND < 0 Then IND = 0
        FillBloc(IND)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If isSell = False Then Exit Sub

        cid = -1
        clientName = "Retour"
        clientadresse = "-"
        tp = 1
        num = 0

        isEditing = False
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class