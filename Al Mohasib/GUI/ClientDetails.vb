Public Class ClientDetails

    'Members
    Private _str As String = "-"


    Private Sub ClientDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Using a As SubClass = New SubClass(1)
            a.AutoCompleteArticles(txtname, "Client")
        End Using
    End Sub
    'liste rouge
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ''//
        _str = "Liste Rouge"
        Dim total As Decimal = 0
        Dim avc As Decimal = 0

        RPl.ClearItems()
        dgv.Rows.Clear()

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim dt As DataTable = a.SelectDataTable("Client", {"*"})
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim tp As Integer = CInt(dt.Rows(i).Item("type").Split("|")(0))
                    Dim clid As Integer = CInt(dt.Rows(i).Item(0))
                    Dim dtt As Date = Now.Date.AddDays(-tp)

                    Dim params As New Dictionary(Of String, Object)
                    params.Add("clid = ", clid)
                    params.Add("payed = ", False)
                    params.Add("[admin] = ", True)
                    params.Add("[date] < ", dtt)

                    Dim dt2 = a.SelectDataTableSymbols("Facture", {"*"}, params)

                    If dt2.Rows.Count > 0 Then
                    
                        Dim fctid As String = ""
                        For t As Integer = 0 To dt2.Rows.Count - 1
                            total += CDbl(dt2.Rows(t).Item("Total"))
                            avc += CDbl(dt2.Rows(t).Item("avance"))
                            fctid &= "-" & dt2.Rows(t).Item(0)
                        Next
                        dgv.Rows.Add(clid, dt.Rows(i).Item("name"), tp & " jrs", dt2.Rows.Count,
                          String.Format("{0:n}", CDec(total.ToString)),
                                String.Format("{0:n}", CDec(avc.ToString)),
                              String.Format("{0:n}", CDec(total - avc)),
                                fctid)
                    End If
                    total = 0
                    avc = 0
                Next
            End If
        End Using
        dgv.Sort(dgv.Columns(6), System.ComponentModel.ListSortDirection.Descending)

        For i As Integer = 0 To dgv.Rows.Count - 1
            total += CDec(dgv.Rows(i).Cells(4).Value)
            avc += CDec(dgv.Rows(i).Cells(5).Value)
        Next


        ''''''''
        'show details in rpl
        Dim table As New DataTable

        ' Create four typed columns in the DataTable.
        table.Columns.Add("arid", GetType(Integer))
        table.Columns.Add("qte", GetType(Decimal))
        table.Columns.Add("name", GetType(String))
        table.Columns.Add("unit", GetType(String))
        table.Columns.Add("price", GetType(Decimal))
        table.Columns.Add("bprice", GetType(Decimal))
        table.Columns.Add("tva", GetType(Double))
        table.Columns.Add("poid", GetType(Integer))
        table.Columns.Add("cid", GetType(Integer))
        table.Columns.Add("depot", GetType(Integer))
        table.Columns.Add("code", GetType(String))

        Dim NM As Integer = dgv.Rows.Count

        table.Rows.Add(4, 1, NM & "Rest", "U", total - avc, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(3, 1, "Montant payée ", "U", avc, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(2, 1, "Montant Total ", "U", total, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(1, 1, "Nbrs", "U", NM, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(0, 1, _str, "U", 0, 1, 0, 1, 0, 0, 0)

        RPl.FctId = 0
        RPl.ClientName = 0
        RPl.ClId = 0
        RPl.Avance = 0
        RPl.AddItems(table, btswitsh.Tag)

        For Each it As Control In RPl.Controls
            If TypeOf it Is Items Then
                Dim itt As Items = CType(it, Items)
                itt.ShowDesc = False
            End If
        Next

        '''''''''
    End Sub
    'etat generale
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        ''//
        ''//
        _str = "Etat Clients"
        RPl.ClearItems()
        dgv.Rows.Clear()

        Dim total As Decimal = 0
        Dim avc As Decimal = 0
        Dim ctableName As String = "Client"
        Dim ftableName As String = "Facture"
        If btswitsh.Tag = 0 Then
            ctableName = "Company"
            ftableName = "Bon"
        End If

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim dt As DataTable = a.SelectDataTable(ctableName, {"*"})
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    Dim clid As Integer = CInt(dt.Rows(i).Item(0))

                    Dim params As New Dictionary(Of String, Object)
                    params.Add("clid = ", clid)
                    params.Add("payed = ", False)
                    params.Add("[admin] = ", True)

                    Dim dt2 = a.SelectDataTableSymbols(ftableName, {"*"}, params)

                    If dt2.Rows.Count > 0 Then

                        Dim fctid As String = ""
                        For t As Integer = 0 To dt2.Rows.Count - 1
                            total += CDbl(dt2.Rows(t).Item("Total"))
                            avc += CDbl(dt2.Rows(t).Item("avance"))
                            fctid &= "-" & dt2.Rows(t).Item(0)
                        Next
                        dgv.Rows.Add(clid, dt.Rows(i).Item("name"), "--", dt2.Rows.Count,
                      String.Format("{0:n}", CDec(total.ToString)),
                          String.Format("{0:n}", CDec(avc.ToString)),
                           String.Format("{0:n}", CDec(total - avc)),
                              fctid)
                    End If
                    total = 0
                    avc = 0
                Next
            End If
        End Using
        dgv.Sort(dgv.Columns(6), System.ComponentModel.ListSortDirection.Descending)

        For i As Integer = 0 To dgv.Rows.Count - 1
            total += CDec(dgv.Rows(i).Cells(4).Value)
            avc += CDec(dgv.Rows(i).Cells(5).Value)
        Next
        ''''''''
        'show details in rpl
        Dim table As New DataTable

        ' Create four typed columns in the DataTable.
        table.Columns.Add("arid", GetType(Integer))
        table.Columns.Add("qte", GetType(Double))
        table.Columns.Add("name", GetType(String))
        table.Columns.Add("unit", GetType(String))
        table.Columns.Add("price", GetType(Double))
        table.Columns.Add("bprice", GetType(Double))
        table.Columns.Add("tva", GetType(Double))
        table.Columns.Add("poid", GetType(Integer))
        table.Columns.Add("cid", GetType(Integer))
        table.Columns.Add("depot", GetType(Integer))
        table.Columns.Add("code", GetType(String))

        Dim NM As Integer = dgv.Rows.Count
      table.Rows.Add(4, 1, NM & "Rest", "U", total - avc, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(3, 1, "Montant payée ", "U", avc, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(2, 1, "Montant Total ", "U", total, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(1, 1, "Nbrs", "U", NM, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(0, 1, _str, "U", 0, 1, 0, 1, 0, 0, 0)

        RPl.FctId = 0
        RPl.ClientName = 0
        RPl.ClId = 0
        RPl.Avance = 0
        RPl.AddItems(table, btswitsh.Tag)

        For Each it As Control In RPl.Controls
            If TypeOf it Is Items Then
                Dim itt As Items = CType(it, Items)
                itt.ShowDesc = False
            End If
        Next

        '''''''''

    End Sub

    Private Sub btswitsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btswitsh.Click
        If btswitsh.Tag = 1 Then
            btswitsh.Text = " ACHAT "
            btswitsh.BackColor = Color.Thistle
            plrightA.BackColor = Color.Thistle
            btswitsh.Tag = 0
            RPl.ClearItems()
            dgv.Rows.Clear()

            Label2.Text = "Fournisseur :"
            Button1.Visible = False
            Button2.Visible = False
            Button3.Visible = False

            Using a As SubClass = New SubClass(1)
                txtname.AutoCompleteSource = Nothing
                a.AutoCompleteArticles(txtname, "Company")
            End Using

        Else
            btswitsh.Text = " VENTE "
            btswitsh.BackColor = Color.Teal
            plrightA.BackColor = Color.Teal
            btswitsh.Tag = 1
            RPl.ClearItems()
            dgv.Rows.Clear()

            Label2.Text = "Client :"
            Button1.Visible = True
            Button2.Visible = True
            Button3.Visible = True

            Using a As SubClass = New SubClass(1)
                txtname.AutoCompleteSource = Nothing
                a.AutoCompleteArticles(txtname, "Client")
            End Using
        End If
    End Sub
    'search
    Private Sub RectangleShape3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RectangleShape3.Click

        ''//
        _str = "OC - " & txtname.text & "(du " & DtpArt1.Text & " au " & DtpArt2.Text & " )"
        Dim id As Integer
        RPl.ClearItems()
        dgv.Rows.Clear()

        Dim ftableName As String = "Facture"
        If btswitsh.Tag = 0 Then
            ftableName = "Bon"
            _str = "OF : " & txtname.text & "(du " & DtpArt1.Text & " au " & DtpArt2.Text & " )"
        End If


        If txtname.text.Contains("]") Then
            ' use ID  by name
            Dim str As String = txtname.text.Trim
            str = str.Substring(0, str.Length - 1)
            str = str.Split(CChar("|"))(1)
            id = CInt(str)
        ElseIf txtname.text.Contains("|") And Not txtname.text.Contains("]") Then
            Dim str As String = txtname.text.Trim
            str = str.Split(CChar("|"))(1)
            id = CInt(str)
        Else
            Exit Sub
        End If

        txtname.Tag = txtname.text
        Dim dtt1 As Date = CDate(DtpArt1.Text).AddDays(-1)
        Dim dtt2 As Date = CDate(DtpArt2.Text).AddDays(1)
        Dim total As Decimal = 0
        Dim avc As Decimal = 0

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

            Dim params As New Dictionary(Of String, Object)
            params.Add("clid = ", id)
            params.Add("[admin] = ", True)
            params.Add("[date] < ", dtt2)
            params.Add("[date] > ", dtt1)

            Dim dt2 = a.SelectDataTableSymbols(ftableName, {"*"}, params)

            If dt2.Rows.Count > 0 Then

                For t As Integer = 0 To dt2.Rows.Count - 1
                    total += CDec(dt2.Rows(t).Item("Total"))
                    avc += CDec(dt2.Rows(t).Item("avance"))

                    Dim n As String = dt2.Rows(t).Item(0) & " [ "
                    n &= CDate(dt2.Rows(t).Item("date")).ToString("dd, MMM yy") & " ]"

                    Dim RS As Decimal = CDec(dt2.Rows(t).Item("Total") - dt2.Rows(t).Item("avance"))
                    Dim py As String = "Non"
                    If RS <= 0 Then py = "Regle"

                    dgv.Rows.Add(id, n, " --", dt2.Rows.Count,
                   String.Format("{0:n}", CDec(dt2.Rows(t).Item("Total"))),
                       String.Format("{0:n}", CDec(dt2.Rows(t).Item("avance"))),
                          String.Format("{0:n}", RS), py)


                Next
                ''''''''''''''
            End If

        End Using

        '''''''' 

        'For i As Integer = 0 To dgv.Rows.Count - 1
        '    total += CDbl(dgv.Rows(i).Cells(4).Value)
        '    avc += CDbl(dgv.Rows(i).Cells(5).Value)
        'Next

        'show details in rpl
        Dim table As New DataTable

        ' Create four typed columns in the DataTable.
        table.Columns.Add("arid", GetType(Integer))
        table.Columns.Add("qte", GetType(Double))
        table.Columns.Add("name", GetType(String))
        table.Columns.Add("unit", GetType(String))
        table.Columns.Add("price", GetType(Double))
        table.Columns.Add("bprice", GetType(Double))
        table.Columns.Add("tva", GetType(Double))
        table.Columns.Add("poid", GetType(Integer))
        table.Columns.Add("cid", GetType(Integer))
        table.Columns.Add("depot", GetType(Integer))
        table.Columns.Add("code", GetType(String))

        Dim NM As Integer = dgv.Rows.Count
        table.Rows.Add(4, 1, " Rest (" & NM & ")", "U", total - avc, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(3, 1, "Montant payée ", "U", avc, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(2, 1, "Montant Total ", "U", total, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(1, 1, "Nbrs", "U", NM, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(0, 1, _str, "U", 0, 1, 0, 1, 0, 0, 0)

        RPl.FctId = 0
        RPl.ClientName = 0
        RPl.ClId = 0
        RPl.Avance = 0
        RPl.AddItems(table, btswitsh.Tag)

        For Each it As Control In RPl.Controls
            If TypeOf it Is Items Then
                Dim itt As Items = CType(it, Items)
                itt.ShowDesc = False
            End If
        Next

        '''''''''
    End Sub
    'operation Client
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ''//
        _str = "Operations clients"
        RPl.ClearItems()
        dgv.Rows.Clear()

        Dim ctableName As String = "Client"
        Dim ftableName As String = "Facture"
        If btswitsh.Tag = 0 Then
            ctableName = "Company"
            ftableName = "Bon"
        End If
        Dim total As Double = 0
        Dim avc As Double = 0
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim dt As DataTable = a.SelectDataTable(ctableName, {"*"})
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    Dim clid As Integer = CInt(dt.Rows(i).Item(0))

                    Dim params As New Dictionary(Of String, Object)
                    params.Add("clid = ", clid)
                    params.Add("[admin] = ", True)

                    Dim dt2 = a.SelectDataTableSymbols(ftableName, {"*"}, params)

                    If dt2.Rows.Count > 0 Then

                        Dim fctid As String = ""
                        For t As Integer = 0 To dt2.Rows.Count - 1
                            total += CDec(dt2.Rows(t).Item("Total"))
                            avc += CDec(dt2.Rows(t).Item("avance"))
                            fctid &= "-" & dt2.Rows(t).Item(0)
                        Next
                       
                        dgv.Rows.Add(clid, dt.Rows(i).Item("name"), "--", dt2.Rows.Count,
                       String.Format("{0:n}", CDec(total.ToString)),
                             String.Format("{0:n}", CDec(avc.ToString)),
                            String.Format("{0:n}", CDec(total - avc)),
                              fctid)
                    End If
                    total = 0
                    avc = 0
                Next
            End If
        End Using
        ''''''''
        For i As Integer = 0 To dgv.Rows.Count - 1
            total += CDbl(dgv.Rows(i).Cells(4).Value)
            avc += CDbl(dgv.Rows(i).Cells(5).Value)
        Next

        'show details in rpl
        Dim table As New DataTable

        ' Create four typed columns in the DataTable.
        table.Columns.Add("arid", GetType(Integer))
        table.Columns.Add("qte", GetType(Double))
        table.Columns.Add("name", GetType(String))
        table.Columns.Add("unit", GetType(String))
        table.Columns.Add("price", GetType(Double))
        table.Columns.Add("bprice", GetType(Double))
        table.Columns.Add("tva", GetType(Double))
        table.Columns.Add("poid", GetType(Integer))
        table.Columns.Add("cid", GetType(Integer))
        table.Columns.Add("depot", GetType(Integer))
        table.Columns.Add("code", GetType(String))

        Dim NM As Integer = dgv.Rows.Count
        table.Rows.Add(4, 1, NM & "Rest", "U", total - avc, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(3, 1, "Montant payée ", "U", avc, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(2, 1, "Montant Total ", "U", total, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(1, 1, "Nbrs", "U", NM, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(0, 1, _str, "U", 0, 1, 0, 1, 0, 0, 0)
        RPl.ClearItems()

        RPl.FctId = 0
        RPl.ClientName = 0
        RPl.ClId = 0
        RPl.Avance = 0
        RPl.AddItems(table, btswitsh.Tag)

        For Each it As Control In RPl.Controls
            If TypeOf it Is Items Then
                Dim itt As Items = CType(it, Items)
                itt.ShowDesc = False
            End If
        Next

        '''''''''
    End Sub
    'print
    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Try
            PrintDoc3.PrinterSettings.PrinterName = Form1.txttimp.Text
            PrintDoc3.Print()

        Catch ex As Exception

            If Form1.PrintDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintDoc3.PrinterSettings.PrinterName = Form1.PrintDlg.PrinterSettings.PrinterName
                PrintDoc3.Print()
            End If
        End Try
    End Sub
    Dim m = 0
    Private Sub PrintDoc3_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc3.PrintPage
        Try
            Using a As DrawClass = New DrawClass
                Dim dte As Date = Now.Date
               
                a.RepportClientDetails(e, dgv, RPl.DataSource, _str, m)
                
            End Using

        Catch ex As Exception
            M = 0
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ''//
        _str = "Etat - " & txtname.text
        Dim id As Integer
        RPl.ClearItems()
        dgv.Rows.Clear()

        Dim ftableName As String = "Facture"
        If btswitsh.Tag = 0 Then ftableName = "Bon"

        If txtname.text.Contains("]") Then
            ' use ID  by name
            Dim str As String = txtname.text.Trim
            str = str.Substring(0, str.Length - 1)
            str = str.Split(CChar("|"))(1)
            id = CInt(str)
        ElseIf txtname.text.Contains("|") And Not txtname.text.Contains("]") Then
            Dim str As String = txtname.text.Trim
            str = str.Split(CChar("|"))(1)
            id = CInt(str)
        Else
            Exit Sub
        End If

        txtname.Tag = txtname.text
        Dim dtt1 As Date = CDate(DtpArt1.Text).AddDays(-1)
        Dim dtt2 As Date = CDate(DtpArt2.Text).AddDays(1)
        Dim total As Decimal = 0
        Dim avc As Decimal = 0

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

            Dim params As New Dictionary(Of String, Object)
            params.Add("clid = ", id)
            params.Add("[admin] = ", True)
            params.Add("[payed] = ", False)
            params.Add("[date] < ", dtt2)
            params.Add("[date] > ", dtt1)

            Dim dt2 = a.SelectDataTableSymbols(ftableName, {"*"}, params)

            If dt2.Rows.Count > 0 Then

                For t As Integer = 0 To dt2.Rows.Count - 1
                    total += CDec(dt2.Rows(t).Item("Total"))
                    avc += CDec(dt2.Rows(t).Item("avance"))

                    Dim n As String = dt2.Rows(t).Item(0) & " [ "
                    n &= CDate(dt2.Rows(t).Item("date")).ToString("dd, MMM yy") & " ]"

                    Dim RS As Decimal = CDec(dt2.Rows(t).Item("Total") - dt2.Rows(t).Item("avance"))
                    Dim py As String = "Non"
                    If RS <= 0 Then py = "Regle"

                    dgv.Rows.Add(id, n, " --", dt2.Rows.Count,
                   String.Format("{0:n}", CDec(dt2.Rows(t).Item("Total"))),
                       String.Format("{0:n}", CDec(dt2.Rows(t).Item("avance"))),
                          String.Format("{0:n}", RS), py)


                Next
                ''''''''''''''
            End If

        End Using

        '''''''' 

        'For i As Integer = 0 To dgv.Rows.Count - 1
        '    total += CDbl(dgv.Rows(i).Cells(4).Value)
        '    avc += CDbl(dgv.Rows(i).Cells(5).Value)
        'Next

        'show details in rpl
        Dim table As New DataTable

        ' Create four typed columns in the DataTable.
        table.Columns.Add("arid", GetType(Integer))
        table.Columns.Add("qte", GetType(Double))
        table.Columns.Add("name", GetType(String))
        table.Columns.Add("unit", GetType(String))
        table.Columns.Add("price", GetType(Double))
        table.Columns.Add("bprice", GetType(Double))
        table.Columns.Add("tva", GetType(Double))
        table.Columns.Add("poid", GetType(Integer))
        table.Columns.Add("cid", GetType(Integer))
        table.Columns.Add("depot", GetType(Integer))
        table.Columns.Add("code", GetType(String))

        Dim NM As Integer = dgv.Rows.Count
        table.Rows.Add(4, 1, " Rest (" & NM & ")", "U", total - avc, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(3, 1, "Montant payée ", "U", avc, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(2, 1, "Montant Total ", "U", total, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(1, 1, "Nbrs", "U", NM, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(0, 1, _str, "U", 0, 1, 0, 1, 0, 0, 0)

        RPl.FctId = 0
        RPl.ClientName = 0
        RPl.ClId = 0
        RPl.Avance = 0
        RPl.AddItems(table, btswitsh.Tag)

        For Each it As Control In RPl.Controls
            If TypeOf it Is Items Then
                Dim itt As Items = CType(it, Items)
                itt.ShowDesc = False
            End If
        Next

        '''''''''
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ''//
        _str = "PAYEMENT - " & txtname.text & "(du " & DtpArt1.Text & " au " & DtpArt2.Text & " )"

        Dim id As Integer
        RPl.ClearItems()
        dgv.Rows.Clear()

        Dim ftableName As String = "Payment"
        If btswitsh.Tag = 0 Then ftableName = "CompanyPayment"

        If txtname.text.Contains("]") Then
            ' use ID  by name
            Dim str As String = txtname.text.Trim
            str = str.Substring(0, str.Length - 1)
            str = str.Split(CChar("|"))(1)
            id = CInt(str)
        ElseIf txtname.text.Contains("|") And Not txtname.text.Contains("]") Then
            Dim str As String = txtname.text.Trim
            str = str.Split(CChar("|"))(1)
            id = CInt(str)
        Else
            Exit Sub
        End If

        txtname.Tag = txtname.text
        Dim dtt1 As Date = CDate(DtpArt1.Text).AddDays(-1)
        Dim dtt2 As Date = CDate(DtpArt2.Text).AddDays(1)
        Dim total As Decimal = 0
        Dim avc As Decimal = 0

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

            Dim params As New Dictionary(Of String, Object)
            params.Add("clid = ", id)
            params.Add("[date] < ", dtt2)
            params.Add("[date] > ", dtt1)

            Dim dt2 = a.SelectDataTableSymbols(ftableName, {"*"}, params)

            If dt2.Rows.Count > 0 Then

                For t As Integer = 0 To dt2.Rows.Count - 1
                    total += CDec(dt2.Rows(t).Item("montant"))

                    Dim n As String = dt2.Rows(t).Item("name") & " [ "
                    n &= CDate(dt2.Rows(t).Item("date")).ToString("dd, MMM yy") & " ]"


                    dgv.Rows.Add(dt2.Rows(t).Item("fctid"), n, dt2.Rows(t).Item("way"),
                                 dt2.Rows(t).Item("Num"), String.Format("{0:n}",
                                 CDec(dt2.Rows(t).Item("montant"))),
                       "", "", dt2.Rows(t).Item("writer"))

                Next
                ''''''''''''''
            End If

        End Using

        Dim table As New DataTable

        ' Create four typed columns in the DataTable.
        table.Columns.Add("arid", GetType(Integer))
        table.Columns.Add("qte", GetType(Double))
        table.Columns.Add("name", GetType(String))
        table.Columns.Add("unit", GetType(String))
        table.Columns.Add("price", GetType(Double))
        table.Columns.Add("bprice", GetType(Double))
        table.Columns.Add("tva", GetType(Double))
        table.Columns.Add("poid", GetType(Integer))
        table.Columns.Add("cid", GetType(Integer))
        table.Columns.Add("depot", GetType(Integer))
        table.Columns.Add("code", GetType(String))

        Dim NM As Integer = dgv.Rows.Count
  
        table.Rows.Add(2, 1, "Montant  ", "U", total, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(1, 1, "Nbrs", "U", NM, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(0, 1, _str, "U", 0, 1, 0, 1, 0, 0, 0)

        RPl.FctId = 0
        RPl.ClientName = 0
        RPl.ClId = 0
        RPl.Avance = 0
        RPl.AddItems(table, btswitsh.Tag)

        For Each it As Control In RPl.Controls
            If TypeOf it Is Items Then
                Dim itt As Items = CType(it, Items)
                itt.ShowDesc = False
            End If
        Next

        '''''''''
    End Sub
End Class