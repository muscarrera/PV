Public Class ChoseCompany


    Public dt_in As New DataTable
    Public dt_stk As New DataTable
    Public dt_Out As New DataTable
    Public arid As Integer




    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If txt.text.Contains("|") = False Then Exit Sub
        If Not IsNumeric(txt.text.Trim.Split("|")(1)) Then Exit Sub

        arid = txt.text.Trim.Split("|")(1)

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

        Dim BTA As New ALMohassinDBDataSetTableAdapters.TracabilityINTableAdapter
        dt_in = BTA.GetDataIN(dt1, dt2, arid)
        dt_Out = BTA.GetDataOut(dt1, dt2, arid)

    End Sub
    Private Sub filtreTheData()

        Dim dt As New DataTable

        If cbIn.Checked = True And cbOut.Checked = False Then
            If Not IsNothing(dt_in) Then dt = dt_in.Copy

        ElseIf cbIn.Checked = False And cbOut.Checked = True Then
            If Not IsNothing(dt_Out) Then dt = dt_Out.Copy
        ElseIf cbIn.Checked = True And cbOut.Checked = True Then
            dt = dt_in.Copy
            dt.Merge(dt_Out.Copy, False)
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


        dg_D.Columns(0).Visible = False
        dg_D.Columns(2).Visible = False
        dg_D.Columns(3).Visible = False
        dg_D.Columns(4).Visible = False
        dg_D.Columns(6).Visible = False
        dg_D.Columns(7).Visible = False
        dg_D.Columns(8).Visible = False


        dg_D.Columns(11).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
        '' dg_D.Columns(14).DefaultCellStyle.ForeColor = Form1.Color_Default_Text
        dg_D.Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.None

        Try


            dg_D.Columns(1).HeaderText = "ID"
            dg_D.Columns(13).HeaderText = "Qte SORTIE"
            dg_D.Columns(15).HeaderText = "Qte ENTREE"

            dg_D.Columns(10).HeaderText = "Date"
            dg_D.Columns(11).HeaderText = "Entrepote"
            dg_D.Columns(9).HeaderText = "Libelle"
            dg_D.Columns(12).HeaderText = "prix de vente"
            dg_D.Columns(14).HeaderText = "prix d'achat"

        Catch ex As Exception

        End Try

        dg_D.Sort(dg_D.Columns(11), System.ComponentModel.ListSortDirection.Ascending)

        Try
            '0 2345678 9CL 10 DT 11DP 12PO 13QO 14PI 15QI

            dg_D.Columns(1).DisplayIndex = 1
            dg_D.Columns(10).DisplayIndex = 2
            dg_D.Columns(9).DisplayIndex = 3
            dg_D.Columns(13).DisplayIndex = 4
            dg_D.Columns(12).DisplayIndex = 5
            dg_D.Columns(15).DisplayIndex = 6
            dg_D.Columns(14).DisplayIndex = 7
        Catch ex As Exception
        End Try

        Dim sum As Double
        Try
            sum = Convert.ToDouble(dt.Compute("SUM(qteIn)", String.Empty))
            lbQteIn.Text = sum & " U"
        Catch ex As Exception
            lbQteIn.Text = "... "
        End Try

        Try
            sum = Convert.ToDouble(dt.Compute("SUM(qteOut)", String.Empty))
            lbQteOut.Text = sum & " U"
        Catch ex As Exception
            lbQteOut.Text = "... "
        End Try

        lbLnbr.Text = dg_D.Rows.Count & " Lines"
        'Me.Height = (dg_D.Rows.Count * 40) + 250

        'If Me.Height < 700 Then Me.Height = 700
    End Sub

    Private Sub cbOut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOut.CheckedChanged, cbIn.CheckedChanged
        filtreTheData()
    End Sub

    Private Sub txtDepot_TxtChanged() Handles txtDepot.TxtChanged
        filtreTheData()
    End Sub

    Dim STR_TITLE = ""

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        STR_TITLE = STR_TITLE.Replace("|", " ")
        STR_TITLE = STR_TITLE.Replace(":", " ")
        STR_TITLE = STR_TITLE.Replace("/", " ")

        SaveDataToHtml(dg_D, STR_TITLE)
    End Sub

    Private Sub ChoseCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dte1.Value = Now.Date.AddMonths(-2)

        Using a As SubClass = New SubClass(1)
            a.AutoCompleteArticles(txt, "Article")
        End Using
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
        Search_Search()

        Search_filtreTheData()

        STR_TITLE = "Valeurisation de Stock "
    End Sub

    Private Sub Search_Search()


        Dim dt1 As Date = dte1.Value.AddDays(-1)
        Dim dt2 As Date = dte2.Value.AddDays(1)

        Dim BTA As New ALMohassinDBDataSetTableAdapters.TracabilityINTableAdapter
        dt_stk = BTA.GetDataByStock()


    End Sub
    Private Sub Search_filtreTheData()

        Dim dt As New DataTable
        dg_D.DataSource = Nothing

        If IsNothing(dt_stk) Then Exit Sub
       
        Dim dpId As Integer = 0
        Dim catId As Integer = 0

        Try
            If txtdp2.text.Contains("|") Then dpId = txtDepot.text.Split("|")(1)
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


        dg_D.DataSource = dt


        '0156791011121314161820 15 17 19

        dg_D.Columns(0).Visible = False
        dg_D.Columns(1).Visible = False '2 3 4
        dg_D.Columns(5).Visible = False
        dg_D.Columns(6).Visible = False
        dg_D.Columns(7).Visible = False ' 8
        dg_D.Columns(9).Visible = False
        dg_D.Columns(10).Visible = False

        dg_D.Columns(11).Visible = False
        dg_D.Columns(12).Visible = False
        dg_D.Columns(13).Visible = False
        ' dg_D.Columns(14).Visible = False ' 15 
        dg_D.Columns(15).Visible = False ' 17
        dg_D.Columns(17).Visible = False ' 19
        dg_D.Columns(19).Visible = False

        dg_D.Columns(14).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
        '' dg_D.Columns(14).DefaultCellStyle.ForeColor = Form1.Color_Default_Text
        dg_D.Columns(14).AutoSizeMode = DataGridViewAutoSizeColumnMode.None

        dg_D.Columns(18).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)

        Dim sum As Double
        Try
            sum = Convert.ToDouble(dt.Compute("SUM(Valeur)", String.Empty))
            lbQteIn.Text = sum.ToString("N2") & " Dhs"
        Catch ex As Exception
            lbQteIn.Text = "... "
        End Try


        Try


            'dg_D.Columns(1).HeaderText = "ID"
            'dg_D.Columns(13).HeaderText = "Qte SORTIE"
            'dg_D.Columns(15).HeaderText = "Qte ENTREE"

            'dg_D.Columns(10).HeaderText = "Date"
            dg_D.Columns(2).HeaderText = "Entrepote"
            dg_D.Columns(16).HeaderText = "Ref"
            'dg_D.Columns(12).HeaderText = "prix de vente"
            dg_D.Columns(3).HeaderText = "prix d'achat"

        Catch ex As Exception

        End Try

        'dg_D.Sort(dg_D.Columns(11), System.ComponentModel.ListSortDirection.Ascending)

        Try
            '0 2345678 9CL 10 DT 11DP 12PO 13QO 14PI 15QI

            dg_D.Columns(16).DisplayIndex = 1
            dg_D.Columns(14).DisplayIndex = 2
            dg_D.Columns(8).DisplayIndex = 3
            dg_D.Columns(4).DisplayIndex = 4
            'dg_D.Columns(12).DisplayIndex = 5
            'dg_D.Columns(15).DisplayIndex = 6
            'dg_D.Columns(14).DisplayIndex = 7
        Catch ex As Exception
        End Try

       

        'Try
        '    sum = Convert.ToDouble(dt.Compute("SUM(qteOut)", String.Empty))
        '    lbQteOut.Text = sum & " U"
        'Catch ex As Exception
        '    lbQteOut.Text = "... "
        'End Try

        lbLnbr.Text = dg_D.Rows.Count & " Lines"
        'Me.Height = (dg_D.Rows.Count * 40) + 250

        'If Me.Height < 700 Then Me.Height = 700
    End Sub

    Private Sub txtCat_TxtChanged() Handles txtdp2.TxtChanged, txtCat.TxtChanged
        Search_filtreTheData()
    End Sub
End Class