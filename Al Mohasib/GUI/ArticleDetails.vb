Public Class ArticleDetails

    Dim m As Integer = 0
    Dim isSearch As Boolean
    Dim _str As String
    Dim _strdt As String

    Private Sub ArticleDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Using a As SubClass = New SubClass(1)
            a.AutoCompleteArticles(txtarticlearchive, "Article")
        End Using

    End Sub

    Private Sub RectangleShape3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RectangleShape3.Click
        Dim id As Integer
        isSearch = True
        _str = "Ventes de " & txtarticlearchive.text
        If CBool(btswitsh.Tag) = False Then _str = "Achats de " & txtarticlearchive.text
        _strdt = "du " & DtpArt1.Text & " Au  " & DtpArt2.Text

        If txtarticlearchive.text.Contains("]") Then
            ' use ID  by name
            Dim str As String = txtarticlearchive.text.Trim
            str = str.Substring(0, str.Length - 1)
            str = str.Split(CChar("|"))(1)
            id = CInt(str)
        ElseIf txtarticlearchive.text.Contains("|") And Not txtarticlearchive.text.Contains("]") Then
            Dim str As String = txtarticlearchive.text.Trim
            str = str.Split(CChar("|"))(1)
            id = CInt(str)

        Else
            Exit Sub
        End If
        Dim bool As Boolean = btswitsh.Tag
        txtarticlearchive.Tag = txtarticlearchive.text
        Try
            Using a As SubClass = New SubClass
                Dim dt1 As Date = CDate(DtpArt1.Text).AddDays(-1)
                Dim dt2 As Date = CDate(DtpArt2.Text).AddDays(1)
                a.ArticlesRepport(id, bool, dt1, dt2, DataGridView1, RPl)
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btswitsh.Click
        If btswitsh.Tag = 1 Then
            btswitsh.Text = " ACHAT "
            btswitsh.BackColor = Color.Thistle
            plrightA.BackColor = Color.Thistle
            btswitsh.Tag = 0
            RPl.ClearItems()
            DataGridView1.Rows.Clear()
        Else
            btswitsh.Text = " VENTE "
            btswitsh.BackColor = Color.Teal
            plrightA.BackColor = Color.Teal
            btswitsh.Tag = 1
            RPl.ClearItems()
            DataGridView1.Rows.Clear()
        End If
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        If DataGridView1.Rows.Count = 0 Then Exit Sub

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
  
    Private Sub PrintDoc3_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc3.PrintPage
        Try
            If DataGridView1.Rows.Count = 0 Then Exit Sub
            Using a As DrawClass = New DrawClass
                a.RepportArticle(e, DataGridView1, RPl.DataSource, txtarticlearchive.Tag, CBool(btswitsh.Tag),
                                 _str, _strdt, isSearch, m)
            End Using

        Catch ex As Exception
            M = 0
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ''//
        _str = "Tous les produit"
        isSearch = False
        _strdt = "du " & DtpArt1.Text & " Au  " & DtpArt2.Text

        _str = "Les Ventes Général"
        If CBool(btswitsh.Tag) = False Then _str = "Les Achats Général "
        _strdt = "du " & DtpArt1.Text & " Au  " & DtpArt2.Text


        RPl.ClearItems()
        DataGridView1.Rows.Clear()

        Dim tableName As String = "Facture"
        Dim ftableName As String = "DetailsFacture"
        If btswitsh.Tag = 0 Then
            tableName = "Bon"
            ftableName = "DetailsBon"
        End If
        Dim total As Double = 0
        Dim avc As Double = 0
        Dim dtt1 As Date = CDate(DtpArt1.Text).AddDays(-1)
        Dim dtt2 As Date = CDate(DtpArt2.Text).AddDays(1)

        Dim tQte As Double = 0
        Dim tbPrice As Double = 0
        Dim tsPrice As Double = 0
        Dim tTva As Double = 0

        Dim params As New Dictionary(Of String, Object)
        params.Add("[admin] = ", True)
        params.Add("[date] < ", dtt2)
        params.Add("[date] > ", dtt1)

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim dt As DataTable = a.SelectDataTableSymbols(tableName, {"*"}, params)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    Dim fctid As Integer = CInt(dt.Rows(i).Item(0))

                    params.Clear()
                    params.Add("fctid = ", fctid)

                    Dim dt2 = a.SelectDataTableSymbols(ftableName, {"*"}, params)

                    If dt2.Rows.Count > 0 Then
                        For t As Integer = 0 To dt2.Rows.Count - 1

                            Dim q As Integer = 0
                            Dim itemLOC As Integer = -1
                            For q = 0 To DataGridView1.Rows.Count - 1
                                If dt2.Rows(t).Item("arid") = DataGridView1.Rows(q).Cells(1).Value Then
                                    'item found
                                    itemLOC = q
                                    Exit For
                                End If
                            Next

                            Dim bprice As Decimal = dt2.Rows(t).Item("qte") * dt2.Rows(t).Item("bprice")
                            'bprice += (bprice * dt2.Rows(t).Item("tva") / 100)
                            Dim sprice As Decimal = dt2.Rows(t).Item("qte") * dt2.Rows(t).Item("price")
                            'sprice += (sprice * dt2.Rows(t).Item("tva") / 100)
                            Dim dte As Date = CDate(dt.Rows(0).Item("date"))
                            Dim tv As Decimal = (sprice * dt2.Rows(t).Item("tva") / 100)

                            If itemLOC = -1 Then
                                DataGridView1.Rows.Add(1, dt2.Rows(t).Item("arid"), dt2.Rows(t).Item("name"),
                                                             String.Format("{0:n}", CDec(dt2.Rows(t).Item("qte").ToString)),
                                                             String.Format("{0:n}", bprice),
                                                             String.Format("{0:n}", sprice),
                                                             String.Format("{0:n}", tv))

                                tQte += CDec(dt2.Rows(t).Item("qte"))
                                tbPrice += bprice
                                tsPrice += sprice
                                tTva += tv
                            Else
                                tQte += CDec(dt2.Rows(t).Item("qte"))
                                tbPrice += bprice
                                tsPrice += sprice
                                tTva += tv

                                DataGridView1.Rows(itemLOC).Cells(0).Value += 1
                                DataGridView1.Rows(itemLOC).Cells(3).Value = String.Format("{0:n}", CDec(DataGridView1.Rows(itemLOC).Cells(3).Value) + CDec(dt2.Rows(t).Item("qte")))
                                DataGridView1.Rows(itemLOC).Cells(4).Value = String.Format("{0:n}", CDec(DataGridView1.Rows(itemLOC).Cells(4).Value) + bprice)
                                DataGridView1.Rows(itemLOC).Cells(5).Value = String.Format("{0:n}", CDec(DataGridView1.Rows(itemLOC).Cells(5).Value) + sprice)
                                 '''''''''''''''''''''''''''''''''''
                            End If
                        Next
                    End If
                Next
            End If
        End Using
        ''''''''
        'show details in rpl
        Dim table As New DataTable

        ' Create four typed columns in the DataTable.
        table.Columns.Add("id", GetType(Integer))
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

        Dim NM As Integer = DataGridView1.Rows.Count
        table.Rows.Add(0, 0, 1, "Total TVA", "U", tTva, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(0, 1, 1, "Total Prix de vente", "U", tsPrice, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(0, 2, 1, "Total Prix d achat", "U", tbPrice, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(0, 3, 1, "Total Qté ", "U", tQte, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(0, 4, 1, NM & "  Articles", "U", NM, 1, 0, 1, 0, 0, 0)
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
End Class