Public Class InvoForm

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        dt_details.Rows.Clear()
        dt_Stock.Rows.Clear()
        dg_D.DataSource = Nothing
        _fctid = 0


        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim dt = a.SelectDataTable("invo", {"*"})

            dg_D.DataSource = Nothing
            dg_D.DataSource = dt
            dg_D.Sort(dg_D.Columns(0), System.ComponentModel.ListSortDirection.Descending)

            dg_D.Columns(0).HeaderText = "N°/ID"
            dg_D.Columns(1).HeaderText = "Réf"
            dg_D.Columns(2).HeaderText = "Code"
            dg_D.Columns(3).HeaderText = "Creation"
            dg_D.Columns(4).HeaderText = "Validation"
            dg_D.Columns(5).HeaderText = "Actf *"
            dg_D.Columns(6).Visible = False
            dg_D.Columns(7).Visible = False
            dg_D.Columns(8).HeaderText = "Vald *"

            dg_D.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg_D.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg_D.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg_D.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg_D.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg_D.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            isInvo = True
        End Using

    End Sub

    Dim dt_details As New DataTable
    Dim dt_Stock As New DataTable
    Dim isInvo As Boolean = False
    Dim _fctid As Integer = 0
    Dim _isValid As Boolean = False

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If dg_D.SelectedRows.Count = 0 Then Exit Sub

        If isInvo = False Then
            Button10_Click(Nothing, Nothing)
            Exit Sub
        End If


        _fctid = dg_D.SelectedRows(0).Cells(0).Value

        lbName.Text = dg_D.SelectedRows(0).Cells(1).Value
        lbDateCreation.Text = dg_D.SelectedRows(0).Cells(3).Value
        lbDateValid.Text = dg_D.SelectedRows(0).Cells(4).Value

        btValid.Visible = Not CBool(dg_D.SelectedRows(0).Cells(5).Value)
        _isValid = CBool(dg_D.SelectedRows(0).Cells(8).Value)

        LoadFromDb_Details()
        'showDetails
        Button7_Click(Nothing, Nothing)
        Button1_Click(Nothing, Nothing)
    End Sub

    Private Sub LoadFromDb_Details()
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add("fctid", _fctid)
            dt_details = a.SelectDataTable("detailsinvo", {"id, arid, name AS Designation, bprice AS Pr_Achat, price AS Pr_Vente, qte, unit, depot, cid", " (bprice*qte) AS Valeur_Achat", " (price*qte) AS Valeur_Vente", "writer"}, params)

            If _isValid Then
                params.Clear()

                params.Add("fctid = ", _fctid)
                dt_Stock = a.SelectDataTableSymbols("stockinvo", {"*"}, params)
            Else
                params.Clear()
                params.Add("fctid = ", _fctid)
                dt_Stock = a.SelectDataTableSymbols("detailsinvo", {"name AS Designation, bprice AS Pr_Achat, price AS Pr_Vente, unit, arid, cid, depot AS dpid, SUM(qte) As Qte"}, params, , "GROUP BY arid, depot")
                dt_Stock.Columns.Add("Enc_Qte")
                dt_Stock.Columns.Add("Def_Qte")
            End If

            dt_Stock.Columns.Add("Valeur_Vente", GetType(System.Double))
            dt_Stock.Columns.Add("Valeur_Achat", GetType(System.Double))

            For i As Integer = 0 To dt_Stock.Rows.Count - 1

                dt_Stock.Rows(i).Item("Valeur_Vente") = dt_Stock.Rows(i).Item("Pr_Vente") * dt_Stock.Rows(i).Item("Qte")
                dt_Stock.Rows(i).Item("Valeur_Achat") = dt_Stock.Rows(i).Item("Pr_Achat") * dt_Stock.Rows(i).Item("Qte")

                If _isValid = False Then
                    params.Clear()
                    params.Add("arid", dt_Stock.Rows(i).Item("arid"))
                    params.Add("dpid", dt_Stock.Rows(i).Item("dpid"))
                    Dim qteIN = a.SelectByScalar("detailstock", "qte", params)
                
                    dt_Stock.Rows(i).Item("Enc_Qte") = qteIN
                    dt_Stock.Rows(i).Item("Def_Qte") = dt_Stock.Rows(i).Item("Qte") - qteIN
                End If
            Next


            'SELECT client, SUM(tarif) FROM achat GROUP BY client
            isInvo = False
        End Using
    End Sub


    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        If Not IsNothing(sender) Then btValid.Visible = False

        dg_D.DataSource = Nothing
        dg_D.DataSource = dt_details
        dg_D.Sort(dg_D.Columns("arid"), System.ComponentModel.ListSortDirection.Descending)

        dg_D.ReadOnly = True
        dg_D.DefaultCellStyle.BackColor = Nothing
        'dg_D.Columns(0).Visible = False
        'dg_D.Columns(1).Visible = False
        'dg_D.Columns(6).Visible = False
        dg_D.Columns("Valeur_Vente").DefaultCellStyle.Format = "n2"
        dg_D.Columns("Valeur_Achat").DefaultCellStyle.Format = "n2"


        dg_D.Columns("Pr_Achat").DefaultCellStyle.Format = "n2"
        dg_D.Columns("Pr_Vente").DefaultCellStyle.Format = "n2"
        dg_D.Columns("qte").DefaultCellStyle.Format = "n0"
      
        Try
            Dim sum = Convert.ToDouble(dt_details.Compute("SUM(Valeur_Vente)", String.Empty))
            lbQteOut.Text = sum & " U"
        Catch ex As Exception
            lbQteOut.Text = "... "
        End Try

        Try
            Dim sum = Convert.ToDouble(dt_details.Compute("SUM(Valeur_Achat)", String.Empty))
            lbQteIn.Text = sum & " U"
        Catch ex As Exception
            lbQteIn.Text = "... "
        End Try

        lbLnbr.Text = dg_D.Rows.Count & " Lines"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not IsNothing(sender) Then btValid.Visible = False

        dg_D.DataSource = Nothing
        dg_D.DataSource = dt_Stock
        dg_D.Sort(dg_D.Columns("arid"), System.ComponentModel.ListSortDirection.Descending)

        dg_D.Columns(1).DefaultCellStyle.BackColor = Color.MintCream
        dg_D.Columns(2).DefaultCellStyle.BackColor = Color.LavenderBlush

        If _isValid Then

            dg_D.ReadOnly = True
            dg_D.Columns(9).DefaultCellStyle.BackColor = Color.LightSalmon
            dg_D.Columns(9).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
           
        Else
            dg_D.Columns(7).DefaultCellStyle.BackColor = Color.LightSalmon
            dg_D.Columns("Def_Qte").DefaultCellStyle.BackColor = Color.Bisque
            
            dg_D.Columns(7).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
            dg_D.ReadOnly = False
            dg_D.Columns(0).ReadOnly = True
            dg_D.Columns(3).ReadOnly = True
            dg_D.Columns(4).ReadOnly = True
            dg_D.Columns(5).ReadOnly = True
            dg_D.Columns(6).ReadOnly = True
            dg_D.Columns(8).ReadOnly = True
        End If

        dg_D.Columns("Valeur_Vente").DefaultCellStyle.Format = "n2"
        dg_D.Columns("Valeur_Achat").DefaultCellStyle.Format = "n2"

        dg_D.Columns("Pr_Achat").DefaultCellStyle.Format = "n2"
        dg_D.Columns("Pr_Vente").DefaultCellStyle.Format = "n2"
        dg_D.Columns("Qte").DefaultCellStyle.Format = "n0"
        dg_D.Columns("Enc_Qte").DefaultCellStyle.Format = "n0"
        dg_D.Columns("Def_Qte").DefaultCellStyle.Format = "n0"
     
        Try
            Dim sum = Convert.ToDouble(dt_details.Compute("SUM(Valeur_Vente)", String.Empty))
            lbQteOut.Text = sum & " U"
        Catch ex As Exception
            lbQteOut.Text = "... "
        End Try

        Try
            Dim sum = Convert.ToDouble(dt_details.Compute("SUM(Valeur_Achat)", String.Empty))
            lbQteIn.Text = sum & " U"
        Catch ex As Exception
            lbQteIn.Text = "... "
        End Try

        lbLnbr.Text = dg_D.Rows.Count & " Lines"
        isInvo = False
    End Sub

    Private Sub dg_D_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_D.CellValueChanged
        Try
            'Dim old_v = dg_D.SelectedRows(0).Cells(6).Value
            dg_D.EndEdit()
            'If Not IsNumeric(dg_D.SelectedRows(0).Cells(6).Value) Then
            '    dg_D.SelectedRows(0).Cells(6).Value = old_v
            '    Exit Sub
            'End If
            If Not IsNumeric(dg_D.SelectedRows(0).Cells(7).Value) Then
                Exit Sub
            End If


            Dim d_i = dg_D.SelectedRows(0).Cells("arid").Value
            Dim d_v = dg_D.SelectedRows(0).Cells(2).Value
            Dim d_a = dg_D.SelectedRows(0).Cells(1).Value
            Dim d_q = dg_D.SelectedRows(0).Cells(7).Value


            If e.ColumnIndex = 7 Then
                Dim d_d = dg_D.SelectedRows(0).Cells(6).Value
                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    Dim params As New Dictionary(Of String, Object)
                    Dim where As New Dictionary(Of String, Object)
                    params.Add("arid", d_i)
                    params.Add("depot", d_d)
                    Dim dt As New DataTable
                    dt = a.SelectDataTable("detailsinvo", {"*"}, params)

                    Dim up_q As Double = d_q
                    For i As Integer = 0 To dt.Rows.Count - 1

                        If i < dt.Rows.Count - 1 Then
                            If dt.Rows(i).Item("qte") <= up_q Then
                                up_q -= CDbl(dt.Rows(i).Item("qte"))
                            Else
                                params.Clear()
                                params.Add("qte", up_q)
                                where.Clear()
                                where.Add("id", dt.Rows(i).Item(0))
                                a.UpdateRecord("detailsinvo", params, where)

                                For t As Integer = 0 To dt_details.Rows.Count - 1
                                    If dt_details.Rows(t).Item("id") = dt.Rows(i).Item(0) Then
                                        dt_details.Rows(t).Item("qte") = up_q
                                        Exit Sub
                                    End If
                                Next

                                up_q = 0
                            End If
                        Else
                            params.Clear()
                            params.Add("qte", up_q)
                            where.Clear()
                            where.Add("id", dt.Rows(i).Item(0))
                            a.UpdateRecord("detailsinvo", params, where)

                            For t As Integer = 0 To dt_details.Rows.Count - 1
                                If dt_details.Rows(t).Item("id") = dt.Rows(i).Item(0) Then
                                    dt_details.Rows(t).Item("qte") = up_q
                                    Exit Sub
                                End If
                            Next

                            up_q = 0
                        End If



                    Next

                    For i As Integer = 0 To dt_Stock.Rows.Count - 1
                        If dt_Stock.Rows(i).Item("arid") = d_i Then
                            dt_Stock.Rows(i).Item("Qte") = d_q
                            dt_Stock.Rows(i).Item("Valeur_Vente") = dt_Stock.Rows(i).Item("Pr_Vente") * dt_Stock.Rows(i).Item("Qte")
                            dt_Stock.Rows(i).Item("Valeur_Achat") = dt_Stock.Rows(i).Item("Pr_Achat") * dt_Stock.Rows(i).Item("Qte")

                            Exit For
                        End If
                    Next
                End Using

                Exit Sub
            End If
             
          

            For i As Integer = 0 To dt_Stock.Rows.Count - 1
                If dt_Stock.Rows(i).Item("arid") = d_i Then


                    Try

                        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                            Dim params As New Dictionary(Of String, Object)
                            params.Add("bprice", d_a)
                            params.Add("price", d_v)

                            Dim where As New Dictionary(Of String, Object)
                            where.Add("arid", d_i)

                            a.UpdateRecord("detailsinvo", params, where)
                        End Using
                    Catch ex As Exception
                    End Try





                    dt_Stock.Rows(i).Item("Pr_Vente") = d_v
                    dt_Stock.Rows(i).Item("Pr_Achat") = d_a
                    dt_Stock.Rows(i).Item("Qte") = d_q

                    dt_Stock.Rows(i).Item("Valeur_Vente") = dt_Stock.Rows(i).Item("Pr_Vente") * dt_Stock.Rows(i).Item("Qte")
                    dt_Stock.Rows(i).Item("Valeur_Achat") = dt_Stock.Rows(i).Item("Pr_Achat") * dt_Stock.Rows(i).Item("Qte")

                    For t As Integer = 0 To dt_details.Rows.Count - 1
                        If dt_details.Rows(t).Item("arid") = d_i Then
                            dt_details.Rows(t).Item("Pr_Vente") = d_v
                            dt_details.Rows(t).Item("Pr_Achat") = d_a
                        End If
                    Next

                    Exit For
                End If
            Next
        Catch ex As Exception
        End Try


        Try
            Dim sum = Convert.ToDouble(dt_Stock.Compute("SUM(Valeur_Vente)", 0))
            lbQteOut.Text = sum & " U"
        Catch ex As Exception
            lbQteOut.Text = "... "
        End Try

        Try
            Dim sum = Convert.ToDouble(dt_Stock.Compute("SUM(Valeur_Achat)", 0))
            lbQteIn.Text = sum & " U"
        Catch ex As Exception
            lbQteIn.Text = "... "
        End Try

    End Sub
    Dim _dpid As Integer = -1
    Dim _cid As Integer = 0
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        Dim clc As New ChooseCat
     
        If clc.ShowDialog = DialogResult.OK Then
            If clc.Button1.Tag = 1 Then
                _cid = clc.DataGridView1.SelectedRows(0).Cells(0).Value
                txtTrCat.text = clc.DataGridView1.SelectedRows(0).Cells(1).Value & "|" & clc.DataGridView1.SelectedRows(0).Cells(0).Value
            Else
                _cid = 0
                txtTrCat.text = ""
            End If
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim clc As New ChoseDepot
        If clc.ShowDialog = DialogResult.OK Then
            If clc.Button1.Tag = 1 Then
                _dpid = clc.DataGridView1.SelectedRows(0).Cells(0).Value
                txtDepot.text = clc.DataGridView1.SelectedRows(0).Cells(1).Value & "|" & clc.DataGridView1.SelectedRows(0).Cells(0).Value

            Else
                _dpid = -1
                txtDepot.text = ""

            End If
        End If
         
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim clc As New ChooseCat

        If clc.ShowDialog = DialogResult.OK Then
            If clc.Button1.Tag = 1 Then
                _cid = clc.DataGridView1.SelectedRows(0).Cells(0).Value
                txtCat.text = clc.DataGridView1.SelectedRows(0).Cells(1).Value & "|" & clc.DataGridView1.SelectedRows(0).Cells(0).Value
            Else
                _cid = 0
                txtCat.text = ""
            End If
        End If

    End Sub

    Private Sub InvoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Using a As SubClass = New SubClass(1)
            a.AutoCompleteArticles(txt, "Article")

        End Using

    End Sub
    Public ReadOnly Property arid As Integer
        Get
            If txt.text.Contains("|") = False Then Return 0
            If Not IsNumeric(txt.text.Trim.Split("|")(1)) Then Return 0

            Return txt.text.Trim.Split("|")(1)
        End Get
    End Property
    Public ReadOnly Property aridSt As Integer
        Get
            If txtST.text.Contains("|") = False Then Return 0
            If Not IsNumeric(txtST.text.Trim.Split("|")(1)) Then Return 0

            Return txtST.text.Trim.Split("|")(1)
        End Get
    End Property

    Private Sub txtDepot_TxtChanged() Handles txtWriter.TxtChanged, txtTrCat.TxtChanged, txtDepot.TxtChanged, txt.TxtChanged

        Dim dt As New DataTable
        dt = dt_details.Copy

        If txt.text.Length > 0 Then
            If arid > 0 Then
                Dim result = From myRow As DataRow In dt.Rows
                                   Where myRow("arid") = arid Select myRow
                If result.Count Then
                    dt = result.CopyToDataTable
                Else
                    dt.Rows.Clear()
                End If
            Else
                Dim result = From myRow As DataRow In dt.Rows
                                Where myRow("Designation").ToString.Contains(txt.text) Select myRow
                If result.Count Then
                    dt = result.CopyToDataTable
                Else
                    dt.Rows.Clear()
                End If
            End If
        End If


        If txtWriter.text.Length > 0 Then
            Dim result = From myRow As DataRow In dt.Rows
                               Where myRow("writer") = txtWriter.text Select myRow
            If result.Count Then
                dt = result.CopyToDataTable
            Else
                dt.Rows.Clear()
            End If
        End If



        If _cid > 0 And _dpid >= 0 Then
            Dim result = From myRow As DataRow In dt.Rows
                                    Where myRow("depot") = _dpid And myRow("cid") = _cid Select myRow
            If result.Count Then
                dt = result.CopyToDataTable
            Else
                dt.Rows.Clear()
            End If


        ElseIf _cid = 0 And _dpid >= 0 Then

            Dim result = From myRow As DataRow In dt.Rows
                                    Where myRow("depot") = _dpid Select myRow
            If result.Count Then
                dt = result.CopyToDataTable
            Else
                dt.Rows.Clear()
            End If


        ElseIf _cid > 0 And _dpid < 0 Then
            Dim result = From myRow As DataRow In dt.Rows
                                    Where myRow("cid") = _cid Select myRow
            If result.Count Then
                dt = result.CopyToDataTable
            Else
                dt.Rows.Clear()
            End If
        End If






        dg_D.DataSource = Nothing
        dg_D.DataSource = dt
        dg_D.Sort(dg_D.Columns("arid"), System.ComponentModel.ListSortDirection.Descending)

        dg_D.ReadOnly = True
        dg_D.DefaultCellStyle.BackColor = Nothing

        Try
            Dim sum = Convert.ToDouble(dt.Compute("SUM(Valeur_Vente)", String.Empty))
            lbQteOut.Text = sum & " U"
        Catch ex As Exception
            lbQteOut.Text = "... "
        End Try

        Try
            Dim sum = Convert.ToDouble(dt.Compute("SUM(Valeur_Achat)", String.Empty))
            lbQteIn.Text = sum & " U"
        Catch ex As Exception
            lbQteIn.Text = "... "
        End Try

        lbLnbr.Text = dg_D.Rows.Count & " Lines"

    End Sub
    Private Sub txtstock_TxtChanged() Handles txtdp2.TxtChanged, txtCat.TxtChanged, txtST.TxtChanged

        Dim dt As New DataTable
        dt = dt_Stock.Copy


        If txtST.text.Length > 0 Then
            If aridSt > 0 Then
                Dim result = From myRow As DataRow In dt.Rows
                                   Where myRow("arid") = aridSt Select myRow
                If result.Count Then
                    dt = result.CopyToDataTable
                Else
                    dt.Rows.Clear()
                End If
            Else
                Dim result = From myRow As DataRow In dt.Rows
                                Where myRow("Designation").ToString.Contains(txtST.text) Select myRow
                If result.Count Then
                    dt = result.CopyToDataTable
                Else
                    dt.Rows.Clear()
                End If
            End If
        End If

        If _cid > 0 And _dpid >= 0 Then
            Dim result = From myRow As DataRow In dt.Rows
                                    Where myRow("dpid") = _dpid And myRow("cid") = _cid Select myRow
            If result.Count Then
                dt = result.CopyToDataTable
            Else
                dt.Rows.Clear()
            End If


        ElseIf _cid = 0 And _dpid >= 0 Then

            Dim result = From myRow As DataRow In dt.Rows
                                    Where myRow("dpid") = _dpid Select myRow
            If result.Count Then
                dt = result.CopyToDataTable
            Else
                dt.Rows.Clear()
            End If


        ElseIf _cid > 0 And _dpid < 0 Then
            Dim result = From myRow As DataRow In dt.Rows
                                    Where myRow("cid") = _cid Select myRow
            If result.Count Then
                dt = result.CopyToDataTable
            Else
                dt.Rows.Clear()
            End If
        End If

        dg_D.DataSource = Nothing
        dg_D.DataSource = dt


        If _isValid Then

            dg_D.ReadOnly = True
            dg_D.Columns(9).DefaultCellStyle.BackColor = Color.LightSalmon
            dg_D.Columns(9).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)

        Else
            dg_D.Columns(7).DefaultCellStyle.BackColor = Color.LightSalmon
            dg_D.Columns("Def_Qte").DefaultCellStyle.BackColor = Color.Bisque

            dg_D.Columns(7).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
            dg_D.ReadOnly = False
            dg_D.Columns(0).ReadOnly = True
            dg_D.Columns(3).ReadOnly = True
            dg_D.Columns(4).ReadOnly = True
            dg_D.Columns(5).ReadOnly = True
            dg_D.Columns(6).ReadOnly = True
            dg_D.Columns(8).ReadOnly = True
        End If

        dg_D.Columns("Valeur_Vente").DefaultCellStyle.Format = "n2"
        dg_D.Columns("Valeur_Achat").DefaultCellStyle.Format = "n2"

        dg_D.Columns("Pr_Achat").DefaultCellStyle.Format = "n2"
        dg_D.Columns("Pr_Vente").DefaultCellStyle.Format = "n2"
        dg_D.Columns("Qte").DefaultCellStyle.Format = "n0"
        dg_D.Columns("Enc_Qte").DefaultCellStyle.Format = "n0"
        dg_D.Columns("Def_Qte").DefaultCellStyle.Format = "n0"

        Try
            Dim sum = Convert.ToDouble(dt_details.Compute("SUM(Valeur_Vente)", String.Empty))
            lbQteOut.Text = sum & " U"
        Catch ex As Exception
            lbQteOut.Text = "... "
        End Try

        Try
            Dim sum = Convert.ToDouble(dt_details.Compute("SUM(Valeur_Achat)", String.Empty))
            lbQteIn.Text = sum & " U"
        Catch ex As Exception
            lbQteIn.Text = "... "
        End Try

        lbLnbr.Text = dg_D.Rows.Count & " Lines"
        isInvo = False

    End Sub
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click


        Dim clc As New ChooseUsers
     
        If clc.ShowDialog = DialogResult.OK Then
            If clc.val = 1 Then
                txtWriter.text = clc.DataGridView1.SelectedRows(0).Cells(1).Value
            Else
                txtWriter.text = ""
            End If


        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'dg_D.Sort(dg_D.Columns("qte"), System.ComponentModel.ListSortDirection.Descending)
        'dg_D.Sort(dg_D.Columns("arid"), System.ComponentModel.ListSortDirection.Descending)

        Dim txt As String = InputBox("Code de l'inventaire =  ")
        If txt <> "111" Then Exit Sub
        Dim __c As Integer = 0


        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            Dim __a As Integer = 0
            Dim __q As Double = 0

            For i As Integer = 0 To dg_D.RowCount - 1
                If __a = dg_D.Rows(i).Cells("arid").Value Then
                    If __q = dg_D.Rows(i).Cells("qte").Value Then
                        params.Clear()
                        params.Add("id", dg_D.Rows(i).Cells(0).Value)
                        a.DeleteRecords("detailsinvo", params)
                        __c += 1
                    Else
                        __q = dg_D.Rows(i).Cells("qte").Value
                    End If

                Else
                    __a = dg_D.Rows(i).Cells("arid").Value
                    __q = dg_D.Rows(i).Cells("qte").Value
                End If
            Next
        End Using
        MsgBox(__c)


        LoadFromDb_Details()
        Button7_Click(Nothing, Nothing)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim params2 As New Dictionary(Of String, String)
        params2.Add("Nbr", dg_D.Rows.Count)
        params2.Add(Label6.Text, lbQteIn.Text)
        params2.Add(Label7.Text, lbQteOut.Text)
        params2.Add("Date crt", lbDateCreation.Text)
        params2.Add("Date Vld", lbDateValid.Text)
        params2.Add("Editeur", Form1.adminName)

        SaveDataToHtml_WithTotal(dg_D, "Inventaire" & lbName.Text, params2)

    End Sub

    Private Sub btValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btValid.Click
        Dim txt As String = InputBox("Code de Validation =  ")
        If txt <> "91285" Then Exit Sub

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)
            '  a.DeleteRecords("Detailstock")



            a.DeleteRecords("Detailstock")

            '::::::::::::::::::::::::::::::::::::::::
            For i As Integer = 0 To dt_Stock.Rows.Count - 1
                params.Clear()
                where.Clear()

                params.Add("Designation", dt_Stock.Rows(i).Item("Designation"))
                params.Add("Pr_Achat", dt_Stock.Rows(i).Item("Pr_Achat"))
                params.Add("Pr_Vente", dt_Stock.Rows(i).Item("Pr_Vente"))

                params.Add("arid", dt_Stock.Rows(i).Item("arid"))
                params.Add("dpid", dt_Stock.Rows(i).Item("dpid"))
                params.Add("qte", dt_Stock.Rows(i).Item("Qte"))
                params.Add("unit", dt_Stock.Rows(i).Item("unit"))
                params.Add("cid", dt_Stock.Rows(i).Item("cid"))
                params.Add("oldqte", dt_Stock.Rows(i).Item("Enc_Qte"))
                params.Add("fctid", _fctid)
                a.InsertRecord("stockinvo", params)

                'params.Clear()
                'params.Add("bprice", dt_Stock.Rows(i).Item("Pr_Achat"))
                'where.Add("arid", dt_Stock.Rows(i).Item("arid"))
                'a.UpdateRecord("article", params, where)

                params.Clear()
                where.Clear()

                params.Add("arid", dt_Stock.Rows(i).Item("arid"))
                params.Add("dpid", dt_Stock.Rows(i).Item("dpid"))
                params.Add("qte", dt_Stock.Rows(i).Item("Qte"))
                params.Add("unit", dt_Stock.Rows(i).Item("unit"))
                params.Add("cid", dt_Stock.Rows(i).Item("cid"))
                a.InsertRecord("Detailstock", params)


                where.Clear()
                where.Add("arid", dt_Stock.Rows(i).Item("arid"))
                where.Add("depot", dt_Stock.Rows(i).Item("dpid"))

                Dim qteOUT = a.SelectByScalar("detailsfacture", "SUM(qte)", where)
                Dim qteIN = a.SelectByScalar("detailsbon", "SUM(qte)", where)

                If IsDBNull(qteIN) Then qteIN = 0
                If IsDBNull(qteOUT) Then qteOUT = 0

                qteIN -= qteOUT
                qteIN -= dt_Stock.Rows(i).Item("Qte")
                qteIN *= -1


                params.Clear()
                params.Add("fctid", -5)
                params.Add("name", dt_Stock.Rows(i).Item("Designation"))
                params.Add("bprice", dt_Stock.Rows(i).Item("Pr_Achat"))
                params.Add("price", dt_Stock.Rows(i).Item("Pr_Achat"))
                params.Add("unit", dt_Stock.Rows(i).Item("unit"))
                params.Add("qte", qteIN)
                params.Add("tva", 0)
                params.Add("arid", dt_Stock.Rows(i).Item("arid"))
                params.Add("depot", dt_Stock.Rows(i).Item("dpid"))
                params.Add("poid", 0)
                params.Add("code", "INVO")
                params.Add("cid", dt_Stock.Rows(i).Item("cid"))
                params.Add("rprice", 0)
                params.Add("caisse", 0)

                a.InsertRecord("detailsbon", params)
            Next

            params.Clear()
            params.Add("valid", True)
            params.Add("admin", True)
            params.Add("date_end", Now)
            where.Clear()
            where.Add("id", _fctid)
            a.UpdateRecord("invo", params, where)

            MsgBox("Opération Réussie")
            Button10_Click(sender, e)
            btValid.Visible = False
        End Using
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add("fctid", _fctid)

            Dim order As New Dictionary(Of String, String)
            order.Add("qte", "Desc")
            order.Add("arid", "Desc")

            dt_details = a.SelectDataTable("detailsinvo", {"id, arid, name AS Designation, bprice AS Pr_Achat, price AS Pr_Vente, qte, unit, depot, cid", " (bprice*qte) AS Valeur_Achat", " (price*qte) AS Valeur_Vente"}, params, order)

            dg_D.DataSource = Nothing
            dg_D.DataSource = dt_details

            isInvo = False
        End Using
    End Sub
     
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim clc As New ChoseDepot
        If clc.ShowDialog = DialogResult.OK Then
            If clc.Button1.Tag = 1 Then
                _dpid = clc.DataGridView1.SelectedRows(0).Cells(0).Value
                txtdp2.text = clc.DataGridView1.SelectedRows(0).Cells(1).Value & "|" & clc.DataGridView1.SelectedRows(0).Cells(0).Value

            Else
                _dpid = -1
                txtdp2.text = ""

            End If
        End If
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim STR_TITLE = "Inventaire : " & lbName.Text
        Dim params2 As New Dictionary(Of String, String)
        params2.Add("Nbr", dg_D.Rows.Count)
        params2.Add("Date", lbDateCreation.Text)
        params2.Add("V Achat", lbQteIn.Text)
        params2.Add("V Vente", lbQteOut.Text)



        STR_TITLE = STR_TITLE.Replace("|", " ")
        STR_TITLE = STR_TITLE.Replace(":", " ")
        STR_TITLE = STR_TITLE.Replace("/", " ")

        SaveDataToHtml_WithTotal(dg_D, STR_TITLE, params2)
    End Sub
  
End Class