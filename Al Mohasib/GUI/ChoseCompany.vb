Public Class ChoseCompany


    Public dt_in As New DataTable
    Public dt_stk As New DataTable
    Public dt_Out As New DataTable
    Public ReadOnly Property arid As Integer
        Get
            If txt.text.Contains("|") = False Then Return 0
            If Not IsNumeric(txt.text.Trim.Split("|")(1)) Then Return 0

            Return txt.text.Trim.Split("|")(1)
        End Get
    End Property
    Public ReadOnly Property cid As Integer
        Get
            If txtClient.text.Contains("|") = False Then Return 0
            If Not IsNumeric(txtClient.text.Trim.Split("|")(1)) Then Return 0

            Return txtClient.text.Trim.Split("|")(1)
        End Get
    End Property

    Dim dt_ajustement As DataTable

    Private Sub ChoseCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dte1.Value = Now.Date.AddMonths(-2)
        ''''''''
        dt_ajustement = New DataTable

        dt_ajustement.Columns.Add("DSID", GetType(Integer))
        dt_ajustement.Columns.Add("arid", GetType(Integer))
        dt_ajustement.Columns.Add("Designation", GetType(String))
        dt_ajustement.Columns.Add("Unite", GetType(String))
        dt_ajustement.Columns.Add("Qte", GetType(Double))
        dt_ajustement.Columns.Add("Q. Réelle", GetType(String))
        dt_ajustement.Columns.Add("Prix", GetType(Double))
        dt_ajustement.Columns.Add("Total", GetType(Double))
        dt_ajustement.Columns.Add("cid", GetType(String))
        dt_ajustement.Columns.Add("dpid", GetType(Integer))

        BackgroundWorker1.RunWorkerAsync()


        Using a As SubClass = New SubClass(1)
            a.AutoCompleteArticles(txt, "Article")
            a.AutoCompleteArticles(txtR, "Client")
        End Using
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        ResetLabels()

        Trace_Search()

        filtreTheData()

        STR_TITLE = "Traçabilité : " & txt.text

        If dg_D.Rows.Count = 0 Then Exit Sub
    End Sub
    Private Sub btDepot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDepot.Click
        Dim clc As New ChoseDepot
        If clc.ShowDialog = DialogResult.OK Then
            If clc.Button1.Tag = 1 Then
                txtDepot.text = clc.DataGridView1.SelectedRows(0).Cells(1).Value & "|" & clc.DataGridView1.SelectedRows(0).Cells(0).Value
            Else
                txtDepot.text = ""
            End If
        End If
    End Sub

    Private Sub Trace_Search()


        Dim dt1 As Date = dte1.Value.AddDays(-1)
        Dim dt2 As Date = dte2.Value.AddDays(1)

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            Dim tb As String = "Bon"
            Dim tb_D As String = "DetailsBon"



            params.Add(tb & ".date >", dt1)
            params.Add(tb & ".date <", dt2)

            If __trace__isSell__used = False Then
                If cid > 0 Then params.Add(tb & ".clid = ", cid)
            End If

            If arid > 0 Then params.Add(tb_D & ".arid =", arid)

            dt_in = a.SelectDataTableSymbols("((" & tb_D & " INNER JOIN " & tb & " ON " & tb_D & ".fctid = " & tb & ".bonid) INNER JOIN Depot ON " & tb_D & ".depot = Depot.dpid)",
                        {tb & ".date," & tb & ".name AS Client, " & tb_D & ".fctid, " & tb_D & ".name, " & tb_D & ".unit AS Unite, " &
                              tb_D & ".price AS Prix, " & tb_D & ".depot, Depot.name AS Entrepot," & tb_D & ".qte AS Qte_ENTREE"}, params)

            params.Clear()

            tb = "Facture"
            tb_D = "DetailsFacture"
            params.Add(tb & ".date >", dt1)
            params.Add(tb & ".date <", dt2)


            If __trace__isSell__used Then
                If cid > 0 Then params.Add(tb & ".clid = ", cid)
            End If

            If arid > 0 Then params.Add(tb_D & ".arid =", arid)
            dt_Out = a.SelectDataTableSymbols("((" & tb_D & " INNER JOIN " & tb & " ON " & tb_D & ".fctid = " & tb & ".fctid) INNER JOIN Depot ON " & tb_D & ".depot = Depot.dpid)",
                        {tb & ".date," & tb & ".name AS Client, " & tb_D & ".fctid, " & tb_D & ".name, " & tb_D & ".unit AS Unite, " &
                              tb_D & ".price AS Prix, " & tb_D & ".depot, Depot.name AS Entrepot," & tb_D & ".qte AS Qte_SORTIE"}, params)


        End Using

    End Sub
    Private Sub filtreTheData()
        If cbComul.Checked Then

            filtreTheDataComul()
            Exit Sub
        End If


        Dim dt As New DataTable

        Dim d_i As New DataTable
        d_i = dt_in.Copy
        Dim d_o As New DataTable
        d_o = dt_Out.Copy


        If cbIn.Checked = True And cbOut.Checked = False Then
            If Not IsNothing(d_i) Then dt = d_i

        ElseIf cbIn.Checked = False And cbOut.Checked = True Then
            If Not IsNothing(d_o) Then dt = d_o
        ElseIf cbIn.Checked = True And cbOut.Checked = True Then
            d_i.Merge(d_o, False)
            dt = d_i

        Else
            dt.Rows.Clear()
            Exit Sub
        End If

        If IsNothing(dt) Then Exit Sub
        If dt.Columns.Count < 6 Then Exit Sub

        If txtDepot.text.Contains("|") Then

            Dim dp = txtDepot.text.Split("|")(1)
            If IsNumeric(dp) Then
                Dim result = From myRow As DataRow In dt.Rows
                                        Where myRow("depot") = dp Select myRow
                If result.Count Then
                    dt = result.CopyToDataTable
                Else
                    dt.Rows.Clear()
                End If

            End If
        End If


        dg_D.DataSource = dt

      

        dg_D.Sort(dg_D.Columns(0), System.ComponentModel.ListSortDirection.Ascending)


        Dim sum As Double
        Try
            sum = Convert.ToDouble(dt.Compute("SUM(Qte_ENTREE)", String.Empty))
            lbQteIn.Text = sum & " U"
        Catch ex As Exception
            lbQteIn.Text = "... "
        End Try

        Try
            sum = Convert.ToDouble(dt.Compute("SUM(Qte_SORTIE)", String.Empty))
            lbQteOut.Text = sum & " U"
        Catch ex As Exception
            lbQteOut.Text = "... "
        End Try

        lbLnbr.Text = dg_D.Rows.Count & " Lines"
        'Me.Height = (dg_D.Rows.Count * 40) + 250

        'If Me.Height < 700 Then Me.Height = 700
    End Sub
    Private Sub filtreTheDataComul()


        Dim dt As New DataTable

        Dim d_i As DataTable = GroubDT(dt_in.Copy, False)
        Dim d_o As DataTable = GroubDT(dt_Out.Copy, True)
         

        If cbIn.Checked = True And cbOut.Checked = False Then
            If Not IsNothing(d_i) Then dt = d_i

        ElseIf cbIn.Checked = False And cbOut.Checked = True Then
            If Not IsNothing(d_o) Then dt = d_o
        ElseIf cbIn.Checked = True And cbOut.Checked = True Then
            dt = d_i
            dt.Merge(d_o, False)
        Else
            dt.Rows.Clear()
            Exit Sub
        End If


        dg_D.DataSource = dt

    End Sub

    Private Function GroubDT(ByRef inDt As DataTable, ByVal isS As Boolean) As DataTable
        Dim dd_o As DataTable = inDt.Copy

        If IsNothing(inDt) Then Return dd_o
        If inDt.Columns.Count < 6 Then Return dd_o

        If txtDepot.text.Contains("|") Then

            Dim dp = txtDepot.text.Split("|")(1)
            If IsNumeric(dp) Then
                Dim result = From myRow As DataRow In inDt.Rows
                                        Where myRow("depot") = dp Select myRow
                If result.Count Then
                    inDt = result.CopyToDataTable
                Else
                    inDt.Rows.Clear()
                End If

            End If
        End If


        If isS Then
            Dim query = From row In inDt
                                        Group row By dateGroup = New With {Key .name = row.Field(Of String)("name"),
                                                                           Key .unit = row.Field(Of String)("Unite"),
                                                                           Key .Prix = row.Field(Of Decimal)("Prix")} Into Group
                                        Select New With {Key .Dates = dateGroup,
                                                        .total = Group.Sum(Function(x) x.Field(Of Decimal)("Qte_SORTIE")),
                                                        .count = Group.Count(Function(x) x.Field(Of Integer)("fctid"))}

            dd_o.Rows.Clear()
            For Each item In query
                dd_o.Rows.Add(Now, "Groupe", item.count, item.Dates.name, item.Dates.unit, item.Dates.Prix, 0, "", item.total)
            Next

        Else
            Dim query = From row In inDt
                            Group row By dateGroup = New With {Key .name = row.Field(Of String)("name"),
                                                               Key .unit = row.Field(Of String)("Unite"),
                                                               Key .Prix = row.Field(Of Decimal)("Prix")} Into Group
                            Select New With {Key .Dates = dateGroup,
                                            .total = Group.Sum(Function(x) x.Field(Of Decimal)("Qte_ENTREE")),
                                            .count = Group.Count(Function(x) x.Field(Of Integer)("fctid"))}

            dd_o.Rows.Clear()
            For Each item In query
                dd_o.Rows.Add(Now, "Groupe", item.count, item.Dates.name, item.Dates.unit, item.Dates.Prix, 0, "", item.total)
            Next

        End If


        Return dd_o
    End Function

    Dim __trace__isSell As Boolean = True
    Public __trace__isSell__used As Boolean = True

    Private Sub cbOut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOut.CheckedChanged, cbIn.CheckedChanged, cbComul.CheckedChanged
        'filtreTheData()
        If cbOut.Checked = False And cbIn.Checked = True Then
            __trace__isSell = False
        Else
            __trace__isSell = True
        End If

    End Sub

    Private Sub txtDepot_TxtChanged() Handles txtDepot.TxtChanged, txtClient.TxtChanged
        filtreTheData()
    End Sub

    Dim STR_TITLE As String = ""
    Private Sub ResetLabels()
        Label6.Text = "Entree"
        Label7.Text = "Sortie"
        t_tva = 0

        lbQteIn.Text = "-"
        lbQteOut.Text = "-"
        lbLnbr.Text = "-"
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim params2 As New Dictionary(Of String, String)
        params2.Add("Nbr", dg_D.Rows.Count)
        params2.Add(Label6.Text, lbQteIn.Text)
        params2.Add(Label7.Text, lbQteOut.Text)
        If t_tva > 0 Then params2.Add("Tva", t_tva.ToString("N2"))
         
        STR_TITLE = STR_TITLE.Replace("|", " ")
        STR_TITLE = STR_TITLE.Replace(":", " ")
        STR_TITLE = STR_TITLE.Replace("/", " ")

        SaveDataToHtml_WithTotal(dg_D, STR_TITLE, params2)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim clc As New ChoseDepot
        If clc.ShowDialog = DialogResult.OK Then
            If clc.Button1.Tag = 1 Then
                txtdp2.text = clc.DataGridView1.SelectedRows(0).Cells(1).Value & "|" & clc.DataGridView1.SelectedRows(0).Cells(0).Value
            Else
                txtdp2.text = ""
            End If
        End If
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim clc As New ChooseCat

        If clc.ShowDialog = DialogResult.OK Then
            If clc.Button1.Tag = 1 Then
                txtCat.text = clc.DataGridView1.SelectedRows(0).Cells(1).Value & "|" & clc.DataGridView1.SelectedRows(0).Cells(0).Value
            Else
                txtCat.text = ""
            End If
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ResetLabels()
        Label7.Text = "TOTAL"
        Search_Search()

        Search_filtreTheData()

        STR_TITLE = "valorisation de stock "
    End Sub

    Private Sub Search_Search()

        Dim dt1 As Date = dte1.Value.AddDays(-1)
        Dim dt2 As Date = dte2.Value.AddDays(1)
         
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            Dim tb As String = "Article"
            Dim tb_D As String = "Detailstock"


            dt_stk = a.SelectDataTableSymbols("((" & tb_D & " INNER JOIN " & tb & " ON " & tb_D & ".arid = " & tb & ".arid) INNER JOIN Depot ON Detailstock.dpid = Depot.dpid)",
                        {"Depot.name, " & tb & ".name AS Designation, " & tb & ".bprice, " & tb & ".sprice, " & tb & ".codebar, " &
                            tb_D & ".dpid, " & tb_D & ".qte, " & tb_D & ".cid, " & tb_D & ".arid, " &
            tb_D & ".unit, " & tb_D & ".DSID,    Detailstock.qte * Article.bprice AS Valeur"})

        End Using


    End Sub
    Private Sub Search_filtreTheData()

        Dim dt As New DataTable
        dg_D.DataSource = Nothing

        If IsNothing(dt_stk) Then Exit Sub
       
        Dim dpId As Integer = 0
        Dim catId As Integer = 0

        Try
            If txtdp2.text.Contains("|") Then dpId = txtdp2.text.Split("|")(1)
        Catch ex As Exception
            dpId = 0
        End Try

        Try
            If txtCat.text.Contains("|") Then catId = txtCat.text.Split("|")(1)
        Catch ex As Exception
            catId = 0
        End Try


        If dpId = 0 And catId > 0 Then

            Dim result = From myRow As DataRow In dt_stk.Rows
                                    Where myRow("cid") = catId Select myRow
            If result.Count Then
                dt = result.CopyToDataTable
            Else
                dt.Rows.Clear()
            End If

        ElseIf catId = 0 And dpId > 0 Then


            Dim result = From myRow As DataRow In dt_stk.Rows
                                    Where myRow("dpid") = dpId Select myRow
            If result.Count Then
                dt = result.CopyToDataTable
            Else
                dt.Rows.Clear()
            End If

        ElseIf catId > 0 And dpId > 0 Then

            Dim result = From myRow As DataRow In dt_stk.Rows
                                    Where myRow("cid") = catId And myRow("dpid") = dpId Select myRow
            If result.Count Then
                dt = result.CopyToDataTable
            Else
                dt.Rows.Clear()
            End If
        Else

            dt = dt_stk
        End If


        Dim sum As Double
        Try
            sum = Convert.ToDouble(dt.Compute("SUM(Valeur)", String.Empty))
            lbQteIn.Text = sum.ToString("N2") & " Dhs"
            lbQteOut.Text = sum.ToString("N2") & " Dhs"
        Catch ex As Exception
            lbQteIn.Text = "... "
        End Try


        Try
            dt.Rows.Add("TOTAL", -1, 0, 0, "", 0, 0, 0, 0)
            dt.Rows(dt.Rows.Count - 1).Item(11) = sum.ToString("N2")
        Catch ex As Exception
        End Try

        dg_D.DataSource = Nothing
        dg_D.DataSource = dt

        Try
            dg_D.Columns(3).Visible = False
            ' dg_D.Columns(4).Visible = False '2 3 4
            dg_D.Columns(5).Visible = False
            dg_D.Columns(8).Visible = False
            'dg_D.Columns(7).Visible = False ' 8
            ' dg_D.Columns(9).Visible = False
            dg_D.Columns(10).Visible = False



            dg_D.Columns(2).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
            '' dg_D.Columns(14).DefaultCellStyle.ForeColor = Form1.Color_Default_Text
            dg_D.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            dg_D.Columns(11).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
            dg_D.Columns(0).HeaderText = "Entrepote"
            dg_D.Columns(2).HeaderText = "prix d'achat"

            dg_D.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg_D.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'dg_D.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.
            dg_D.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg_D.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg_D.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg_D.Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

            dg_D.Columns(9).DisplayIndex = 3
            dg_D.Columns(7).DisplayIndex = 3
            dg_D.Columns(4).DisplayIndex = 0
            dg_D.Columns(2).DisplayIndex = 5
            dg_D.Columns(0).DisplayIndex = 4

         
            dg_D.Columns(11).DefaultCellStyle.Format = "N2"
            dg_D.Columns(2).DefaultCellStyle.Format = "N2"
            dg_D.Columns(6).DefaultCellStyle.Format = "N2"

        Catch ex As Exception
        End Try
 
        lbLnbr.Text = dg_D.Rows.Count & " Lines"
       
    End Sub
    Private Sub Search_filtreAjustementData()

        Dim dt As New DataTable
        dg_D.DataSource = Nothing
        StyleDatagrid(dg_D)

        If IsNothing(dt_ajustement) Then Exit Sub

        Dim dpId As Integer = 0
        Dim catId As Integer = 0

        Try
            If txtAjustDp.text.Contains("|") Then dpId = txtAjustDp.text.Split("|")(1)
        Catch ex As Exception
            dpId = 0
        End Try

        Try
            If txtAjustCat.text.Contains("|") Then catId = txtAjustCat.text.Split("|")(1)
        Catch ex As Exception
            catId = 0
        End Try


        If dpId = 0 And catId > 0 Then

            Dim result = From myRow As DataRow In dt_ajustement.Rows
                                    Where myRow("cid") = catId Select myRow
            If result.Count Then
                dt = result.CopyToDataTable
            Else
                dt.Rows.Clear()
            End If

        ElseIf catId = 0 And dpId > 0 Then


            Dim result = From myRow As DataRow In dt_ajustement.Rows
                                    Where myRow("dpid") = dpId Select myRow
            If result.Count Then
                dt = result.CopyToDataTable
            Else
                dt.Rows.Clear()
            End If

        ElseIf catId > 0 And dpId > 0 Then

            Dim result = From myRow As DataRow In dt_ajustement.Rows
                                    Where myRow("cid") = catId And myRow("dpid") = dpId Select myRow
            If result.Count Then
                dt = result.CopyToDataTable
            Else
                dt.Rows.Clear()
            End If
        Else

            dt = dt_ajustement.Copy
        End If


        If txtAjustArt.text.Trim <> "" Then
            Dim result = From myRow As DataRow In dt.Rows
                                    Where myRow("Designation").ToString.Contains(txtAjustArt.text) Select myRow
            If result.Count Then
                dt = result.CopyToDataTable
            Else
                dt.Rows.Clear()
            End If
        End If


        dg_D.ReadOnly = False
        dg_D.DataSource = dt

        Try
            dg_D.Columns(0).Visible = False
            dg_D.Columns(1).Visible = False '2 3 4
            dg_D.Columns(8).Visible = False

            dg_D.Columns(2).ReadOnly = True
            dg_D.Columns(3).ReadOnly = True
            dg_D.Columns(4).ReadOnly = True
            '  dg_D.Columns(5).ReadOnly = True
            ' dg_D.Columns(6).ReadOnly = True
            dg_D.Columns(7).ReadOnly = True
            ' dg_D.Columns(8).ReadOnly = True
            dg_D.Columns(9).ReadOnly = True

            dg_D.Columns(5).DefaultCellStyle.BackColor = Color.LightSalmon
            dg_D.Columns(2).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)

            dg_D.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg_D.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg_D.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg_D.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg_D.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg_D.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

            dg_D.Columns(5).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
            dg_D.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Catch ex As Exception
        End Try

        dg_D.Columns(9).DisplayIndex = 2
        Try
            Dim sum As Double = Convert.ToDouble(dt_ajustement.Compute("SUM(total)", String.Empty))
            lbQteIn.Text = String.Format("{0:n}", CDec(sum))
            
        Catch ex As Exception
            Try
                Dim SM = dt_ajustement.AsEnumerable().Aggregate(0, Function(n, r) PriceField(r) + n)
                lbQteIn.Text = String.Format("{0:n}", CDec(SM))
            Catch exe As Exception
            End Try
        End Try



        lbLnbr.Text = dg_D.Rows.Count & " Lines"

    End Sub
    Private Shared Function PriceField(ByVal r As DataRow) As Integer
        Dim v As Integer
        Return If(Integer.TryParse(If((TryCast(r("value"), String)), String.Empty), v), v, 0)
    End Function
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim id As Integer = 0
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            dt_ajustement.Rows.Clear()

            Dim st_dt As DataTable = a.SelectDataTable("Detailstock", {"*"})
            For i As Integer = 0 To st_dt.Rows.Count - 1
                Try
                    params.Clear()
                    Dim arid As Integer = IntValue(st_dt, "arid", i)
                    params.Add("arid", arid)
                    Dim dt As New DataTable

                    Try
                        dt = a.SelectDataTable("Article", {"name", "bprice"}, params)
                    Catch ex As Exception
                    End Try
                    Dim pr As Double = 0
                    Dim tt As Double = 0
                    Dim nm As String = ""
                    Try
                        nm = StrValue(dt, "name", 0)
                        pr = DblValue(dt, "bprice", 0)
                        tt = DblValue(st_dt, "qte", i) * pr
                    Catch ex As Exception

                    End Try
                    dt_ajustement.Rows.Add(IntValue(st_dt, "DSID", i), arid, nm,
                                           StrValue(st_dt, "unit", i), DblValue(st_dt, "qte", i), "", pr.ToString("N2"), tt.ToString("N2"), IntValue(st_dt, "cid", i), IntValue(st_dt, "dpid", i))




                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next

        End Using

    End Sub
    Private Sub StyleDatagrid(ByRef dg As DataGridView)
        dg.AutoGenerateColumns = True
        ' dg.BorderStyle = Windows.Forms.BorderStyle.None
        'dg.CellBorderStyle = DataGridViewCellBorderStyle.None
        dg.RowsDefaultCellStyle.BackColor = Color.White
        dg.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        dg.DefaultCellStyle.SelectionBackColor = Color.BlueViolet
        dg.DefaultCellStyle.SelectionForeColor = Color.White

        dg.BackgroundColor = Color.White

        dg.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dg.MultiSelect = False

        dg.AllowUserToResizeColumns = False
        dg.AllowUserToAddRows = False
        dg.AllowUserToDeleteRows = False
        dg.AllowUserToResizeRows = False
        ' dg.EditMode = DataGridViewEditMode.EditProgrammatically

        dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dg.RowTemplate.Height = 33
        dg.ColumnHeadersHeight = 33

        dg.Dock = DockStyle.Fill
        dg.RowHeadersVisible = False
    End Sub
    Private Sub dg_D_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_D.CellValueChanged
        Try
            'Dim old_v = dg_D.SelectedRows(0).Cells(6).Value
            dg_D.EndEdit()
            'If Not IsNumeric(dg_D.SelectedRows(0).Cells(6).Value) Then
            '    dg_D.SelectedRows(0).Cells(6).Value = old_v
            '    Exit Sub
            'End If

            Dim d_v = dg_D.SelectedRows(0).Cells(5).Value
            Dim d_i = dg_D.SelectedRows(0).Cells(0).Value
            Dim d_P = dg_D.SelectedRows(0).Cells(6).Value

            For i As Integer = 0 To dt_ajustement.Rows.Count - 1
                If dt_ajustement.Rows(i).Item(0) = d_i Then
                    dt_ajustement.Rows(i).Item(5) = d_v

                    If Not IsNumeric(d_P) Then
                        dg_D.SelectedRows(0).Cells(6).Value = dt_ajustement.Rows(i).Item(6)
                        d_P = dt_ajustement.Rows(i).Item(6)
                    End If

                    dt_ajustement.Rows(i).Item(6) = d_P


                    If Not IsNumeric(d_v) Then
                        d_v = dt_ajustement.Rows(i).Item(4)
                    End If

                    dt_ajustement.Rows(i).Item(7) = CDbl(d_v * d_P).ToString("N2")

                    dg_D.SelectedRows(0).Cells(7).Value = dt_ajustement.Rows(i).Item(7)
                    Exit For
                End If
            Next
        Catch ex As Exception
        End Try

        Try
            Dim sum As Double = Convert.ToDouble(dt_ajustement.Compute("SUM(total)", String.Empty))
            lbQteIn.Text = String.Format("{0:n}", CDec(sum))

        Catch ex As Exception
            Try
                Dim SM = dt_ajustement.AsEnumerable().Aggregate(0, Function(n, r) PriceField(r) + n)
                lbQteIn.Text = String.Format("{0:n}", CDec(SM))
            Catch exe As Exception
            End Try
        End Try

    End Sub
    Private Sub txtCat_TxtChanged() Handles txtdp2.TxtChanged, txtCat.TxtChanged
        Search_filtreTheData()
    End Sub

    
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim clc As New ChooseCat

        If clc.ShowDialog = DialogResult.OK Then
            If clc.Button1.Tag = 1 Then
                txtAjustCat.text = clc.DataGridView1.SelectedRows(0).Cells(1).Value & "|" & clc.DataGridView1.SelectedRows(0).Cells(0).Value
            Else
                txtAjustCat.text = ""
            End If
        End If

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim clc As New ChoseDepot
        If clc.ShowDialog = DialogResult.OK Then
            If clc.Button1.Tag = 1 Then
                txtAjustDp.text = clc.DataGridView1.SelectedRows(0).Cells(1).Value & "|" & clc.DataGridView1.SelectedRows(0).Cells(0).Value
            Else
                txtAjustDp.text = ""
            End If
        End If
    End Sub

    

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        ResetLabels()
        Search_filtreAjustementData()

        STR_TITLE = "Ajustement de stock "
    End Sub

    Private Sub txtAjustArt_TxtChanged() Handles txtAjustDp.TxtChanged, txtAjustCat.TxtChanged, txtAjustArt.TxtChanged
        Search_filtreAjustementData()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click


        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            For i As Integer = 0 To dt_ajustement.Rows.Count - 1
                If Not IsNumeric(dt_ajustement.Rows(i).Item(5)) Then Continue For

                params.Clear()
                where.Clear()
                Try
                    params.Add("DSID", dt_ajustement.Rows(i).Item(0))
                    where.Add("qte", dt_ajustement.Rows(i).Item(5))


                    a.UpdateRecord("Detailstock", where, params)

                    params.Clear()
                    where.Clear()

                    params.Add("arid", dt_ajustement.Rows(i).Item("arid"))
                    where.Add("bprice", dt_ajustement.Rows(i).Item(6))


                    a.UpdateRecord("Article", where, params)
                Catch ex As Exception
                End Try
            Next
            MsgBox("Enregistrement est terminé avec succès ...  ^^")
        End Using


    End Sub
    'rapport dala33333
    Dim dt_Art As New DataTable

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click

        Dim rp As New ProfitProduitRapport
        If rp.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If

        'Dim BTA As New ALMohassinDBDataSetTableAdapters.TracabilityINTableAdapter

        'dt_in = BTA.GetDataByRapportDala3_Achat("%" & txtRP.text & "%")
        'dt_Out = BTA.GetDataByRapportDal3_Vente("%" & txtRP.text & "%")



        'Dim artta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter

        'Dim str As String = "%" & txtRP.text & "%"
        'dt_Art = artta.GetDatalikecodebar(str)




        '    filtreTheData_RapportDala3()

        '    STR_TITLE = "Rapport Article :  " & txtRP.text
    End Sub
    Private Sub filtreTheData_RapportDala3()

        Dim dt As New DataTable

        dt.Columns.Add("N", GetType(Integer))
        dt.Columns.Add("Designation", GetType(String))
        dt.Columns.Add("Nbr_Oprt", GetType(String))
        dt.Columns.Add("Prix_Min", GetType(String))
        dt.Columns.Add("Prix_Max", GetType(String))
        dt.Columns.Add("Qte", GetType(String))
        dt.Columns.Add("Total_Vente", GetType(String))
        dt.Columns.Add("Total_Achat", GetType(String))
        dt.Columns.Add("Profit", GetType(String))

        Dim MAX As Decimal = 0
        Dim MIN As Decimal = 0
        Dim QTE As Decimal = 0
        Dim TT As Decimal = 0
        Dim nb As Integer = 0
        Dim TA As Decimal = 0

        Dim T_TT_IN As Decimal = 0
        Dim T_nb_IN As Integer = 0

        Dim T_TT_OUT As Decimal = 0
        Dim T_nb_OUT As Integer = 0
        Dim T_TA_OUT As Integer = 0

        dt.Rows.Add(10, "ACHATS")
        dt.Rows.Add(20, "VENTE")
        dt.Rows.Add(30, "STOCK")
        dt.Rows.Add(40, "RESULTAT")

        For i As Integer = 0 To dt_Art.Rows.Count - 1
            MAX = 0
            MIN = 0
            QTE = 0
            TT = 0
            TA = 0
            nb = 0

            Try
                'achat
                MAX = dt_in.AsEnumerable().Where(Function(x) x.Field(Of Integer)("arid") = dt_Art.Rows(i).Item(0)).Select(Function(x) x.Field(Of Decimal)("Prix")).Max()
                MIN = dt_in.AsEnumerable().Where(Function(x) x.Field(Of Integer)("arid") = dt_Art.Rows(i).Item(0)).Select(Function(x) x.Field(Of Decimal)("Prix")).Min()
                QTE = dt_in.AsEnumerable().Where(Function(x) x.Field(Of Integer)("arid") = dt_Art.Rows(i).Item(0)).Select(Function(x) x.Field(Of Decimal)("Qte")).Sum()
                TT = dt_in.AsEnumerable().Where(Function(x) x.Field(Of Integer)("arid") = dt_Art.Rows(i).Item(0)).Select(Function(x) x.Field(Of Decimal)("Total")).Sum()
                nb = dt_in.AsEnumerable().Where(Function(x) x.Field(Of Integer)("arid") = dt_Art.Rows(i).Item(0)).Select(Function(x) x.Field(Of Integer)("arid")).Count()

                T_nb_IN += nb
                T_TT_IN += TT

                dt.Rows.Add(11, dt_Art.Rows(i).Item("name"), nb, MIN.ToString("N2"), MAX.ToString("N2"), QTE, TT.ToString("N2"))
            Catch ex As Exception
            End Try

            MAX = 0
            MIN = 0
            QTE = 0
            TT = 0
            TA = 0
            nb = 0

         

            Try
                'vente
                MAX = dt_Out.AsEnumerable().Where(Function(x) x.Field(Of Integer)("arid") = dt_Art.Rows(i).Item(0)).Select(Function(x) x.Field(Of Decimal)("Prix")).Max()
                MIN = dt_Out.AsEnumerable().Where(Function(x) x.Field(Of Integer)("arid") = dt_Art.Rows(i).Item(0)).Select(Function(x) x.Field(Of Decimal)("Prix")).Min()
                QTE = dt_Out.AsEnumerable().Where(Function(x) x.Field(Of Integer)("arid") = dt_Art.Rows(i).Item(0)).Select(Function(x) x.Field(Of Decimal)("Qte")).Sum()
                TT = dt_Out.AsEnumerable().Where(Function(x) x.Field(Of Integer)("arid") = dt_Art.Rows(i).Item(0)).Select(Function(x) x.Field(Of Decimal)("Total")).Sum()
                nb = dt_Out.AsEnumerable().Where(Function(x) x.Field(Of Integer)("arid") = dt_Art.Rows(i).Item(0)).Select(Function(x) x.Field(Of Integer)("arid")).Count()
                TA = dt_Out.AsEnumerable().Where(Function(x) x.Field(Of Integer)("arid") = dt_Art.Rows(i).Item(0)).Select(Function(x) x.Field(Of Decimal)("Total_Achat")).Sum()


                T_nb_OUT += nb
                T_TT_OUT += TT
                T_TA_OUT += TA
                dt.Rows.Add(21, dt_Art.Rows(i).Item("name"), nb, MIN.ToString("N2"), MAX.ToString("N2"), QTE, TT.ToString("N2"), TA.ToString("N2"), (TT - TA).ToString("N2"))
            Catch ex As Exception
            End Try


        Next

        dt.Rows.Add(12, "Total", T_nb_IN, "", "", "", T_TT_IN)
        dt.Rows.Add(22, "Total", T_nb_OUT, "", "", "", T_TT_OUT.ToString("N2"), T_TA_OUT.ToString("N2"), (T_TT_OUT - T_TA_OUT).ToString("N2"))

        dg_D.DataSource = dt
   
        dg_D.Sort(dg_D.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
        dg_D.Columns(1).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)

        dg_D.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dg_D.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dg_D.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dg_D.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dg_D.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dg_D.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        
          
        lbLnbr.Text = dg_D.Rows.Count & " Lines"
      
    End Sub
    Dim t_tva As Double = 0
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click

        Label6.Text = "Total"
        Label7.Text = "Regl."
        t_tva = 0

        Dim dt2 = New DateTime(dtR2.Value.Year, dtR2.Value.Month, dtR2.Value.Day, 23, 59, 0, 0)
        Dim dt1 = New DateTime(dtR1.Value.Year, dtR1.Value.Month, dtR1.Value.Day, 0, 1, 0, 0)
        Dim _dt As New DataTable

        STR_TITLE = "Archive (Ventes) " & txtR.text & " - du " & dte1.Value.ToString("dd-MM-yy") & " Au " & dte2.Value.ToString("dd-MM-yy")



        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            Dim tb As String = "facture_liste"
            Dim tb_F As String = "facture"
            Dim t_av As Double = 0
            t_tva = 0
            Dim cid As Integer = 0

            Try
                If txtR.text.Contains("|") = True And
                               IsNumeric(txtR.text.Trim.Split("|")(1)) Then
                    cid = txtR.text.Trim.Split("|")(1)
                End If
            Catch ex As Exception
            End Try

            params.Add("date >", dt1)
            params.Add("date <", dt2)
            If cid > 0 Then params.Add("clid =", cid)

            'dt_stk = a.SelectDataTableSymbols("((" & tb & " INNER JOIN " & tb_F & " ON " & tb & ".flid = " &
            '                                  tb_F & ".beInFacture) INNER JOIN client ON facture_liste.clid = client.Clid)",
            '            {tb & ".clid AS CodeClient, client.name, " & tb & ".date, " & tb & ".total, SUM(" & tb_F & ".avance) AS Regl, " &
            '               " SUM(" & tb_F & ".tva) AS Tva, " & tb & ".mode"}, )
            _dt = a.SelectDataTableSymbols(tb, {"*"}, params)


            _dt.Columns.Add("Designation", GetType(String))
            _dt.Columns.Add("Regl.", GetType(Double))
            _dt.Columns.Add("Tva", GetType(String))
            _dt.Columns.Add("ICE", GetType(String))


            For i As Integer = 0 To _dt.Rows.Count - 1
                Dim fid As Integer = _dt.Rows(i).Item(0)
                params.Clear()
                params.Add("Clid", _dt.Rows(i).Item("clid"))
                Try
                    _dt.Rows(i).Item("Designation") = a.SelectByScalar("Client", "name", params)
                Catch ex As Exception
                End Try
                Dim ice As String = "-"
                Try
                    ice = a.SelectByScalar("Client", "Adress", params)
                    ice = ice.ToString.Split("*")(2)
                Catch ex As Exception
                End Try
                _dt.Rows(i).Item("ICE") = ice

                params.Clear()
                params.Add("beInFacture", fid)

                If CBool(_dt.Rows(i).Item(5)) Then
                    _dt.Rows(i).Item("Regl.") = _dt.Rows(i).Item(7)
                    t_av += _dt.Rows(i).Item(7)
                Else
                    Try
                        Dim avv As Double = a.SelectByScalar(tb_F, "SUM(avance)", params)
                        _dt.Rows(i).Item("Regl.") = avv
                        t_av += avv
                    Catch ex As Exception
                    End Try
                End If

                Try
                    Dim avv As Double = a.SelectByScalar(tb_F, "SUM(Tva)", params)
                    _dt.Rows(i).Item("Tva") = avv
                    t_tva += avv
                Catch ex As Exception
                End Try
            Next

            _dt.Columns(0).ColumnName = "N°/ID"
            _dt.Columns(2).ColumnName = "Code Client"
            _dt.Columns(6).ColumnName = "Md Pmnt"

            _dt.Columns(8).SetOrdinal(2)
            _dt.Columns(11).SetOrdinal(3)

            dg_D.DataSource = Nothing
            dg_D.DataSource = _dt
            dg_D.Columns(1).Visible = False
            dg_D.Columns(4).Visible = False
            dg_D.Columns(6).Visible = False
            dg_D.Columns(7).Visible = False
         

            '  dg_D.Columns(8).DisplayIndex = 1

            Try
                Dim sum As Double = Convert.ToDouble(_dt.Compute("SUM(total)", String.Empty))
                lbQteIn.Text = String.Format("{0:n}", CDec(sum))

            Catch ex As Exception
                Try
                    Dim SM = _dt.AsEnumerable().Aggregate(0, Function(n, r) PriceField(r) + n)
                    lbQteIn.Text = String.Format("{0:n}", CDec(SM))
                Catch exe As Exception
                End Try
            End Try


            Try
                lbQteOut.Text = String.Format("{0:n}", CDec(t_av))

            Catch ex As Exception
            End Try

            lbLnbr.Text = dg_D.Rows.Count & " Lines"

        End Using
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Try
            Dim isSell As Boolean = True
            Dim chs As New ChoseClient
            chs.isSell = isSell
            If chs.ShowDialog = Windows.Forms.DialogResult.OK Then
                txtR.text = chs.clientName & "|" & chs.cid
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Dim clc As New ChoseClient
        clc.isSell = __trace__isSell


        If clc.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtClient.text = clc.clientName & "|" & clc.cid
            __trace__isSell__used = __trace__isSell
        End If

    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Try
            PrintDoc2.PrinterSettings.PrinterName = Form1.txttimp.Text
            PrintDoc2.Print()

        Catch ex As Exception
             
        End Try
    End Sub

    Private Sub PrintDoc2_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc2.PrintPage
        Try
            Using a As DrawClass = New DrawClass
                a.RepportFactureRecept(e, dte1.Value, dte2.Value)
            End Using
            myTva.Clear()
        Catch ex As Exception
            M = 0
            myTva.Clear()
        End Try
    End Sub
    Dim M As Integer = 0
    Dim numPage As Integer = 1
    Dim myTva As New Dictionary(Of String, Double)
End Class