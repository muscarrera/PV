Public Class CaisseDetailsList

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim params2 As New Dictionary(Of String, String)
        params2.Add("Nbr", dg_D.Rows.Count)
        params2.Add(Label6.Text, lbreel.Text)
        params2.Add(Label7.Text, lbtheorie.Text)

        SaveDataToHtml_WithTotal(dg_D, "Caisse details", params2)
    End Sub

    Private Sub btDepot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDepot.Click
        Dim cc As New ChooseUsers
        If cc.ShowDialog = Windows.Forms.DialogResult.OK Then
            If cc.val = 1 Then
                txtDepot.text = cc.adminName
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
            Dim tb As String = "caisse"


            params.Add("ech >", dt1)
            params.Add("ech <", dt2)

            If txtDepot.text <> "" Then params.Add("name = ", txtDepot.text)


            Dim dt = a.SelectDataTableSymbols(tb, {"*"}, params)
            filtreTheData(dt)

        End Using

    End Sub

    Private Sub filtreTheData(ByVal dt As DataTable)

        If IsNothing(dt) Then Exit Sub

        dg_D.DataSource = dt
         
        dg_D.Columns(0).Visible = False
        dg_D.Columns(7).Visible = False
        dg_D.Columns(8).Visible = False
        dg_D.Columns(9).Visible = False
        dg_D.Columns(10).Visible = False
        dg_D.Columns(11).Visible = False
        dg_D.Columns(12).Visible = False
        dg_D.Columns(13).Visible = False
        dg_D.Columns(14).Visible = False
        dg_D.Columns(15).Visible = False
        dg_D.Columns(16).Visible = False
        dg_D.Columns(17).Visible = False

        dg_D.Sort(dg_D.Columns(0), System.ComponentModel.ListSortDirection.Descending)

        dg_D.Columns(1).HeaderText = "Personne"
        dg_D.Columns(2).HeaderText = "Editeur"
        dg_D.Columns(3).HeaderText = "Date de caisse"
        dg_D.Columns(4).HeaderText = "date de saisie"


        Dim sumt As Double = 0
        Dim sumr As Double = 0
        Try
            sumr = Convert.ToDouble(dt.Compute("SUM(ValeurRl)", String.Empty))
            lbreel.Text = sumr.ToString("n2") & " dhs"
        Catch ex As Exception
            lbreel.Text = "... "
        End Try
         
        Try
            sumt = Convert.ToDouble(dt.Compute("SUM(ValeurTh)", String.Empty))
            lbtheorie.Text = sumt.ToString("n2") & " dhs"
        Catch ex As Exception
            lbtheorie.Text = "... "
        End Try
         
        lbLnbr.Text = dg_D.Rows.Count & " Lines"

        lbDiff.Text = (sumr - sumt).ToString("n2")
        'Me.Height = (dg_D.Rows.Count * 40) + 250

        'If Me.Height < 700 Then Me.Height = 700
    End Sub



    Private Sub dg_D_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_D.CellDoubleClick
        If dg_D.SelectedRows.Count = 0 Then Exit Sub

        Dim id As Integer = dg_D.SelectedRows(0).Cells(0).Value

        Dim ad As New AddEditCaisseDetail
        ad.Pid = id
       
        If ad.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If


    End Sub

    Private Sub CaisseDetailsList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dte1.Value = Now.Date.AddDays(-7)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Trace_Search()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If dg_D.SelectedRows.Count = 0 Then Exit Sub

        Dim id As Integer = dg_D.SelectedRows(0).Cells(0).Value

        Dim ad As New AddEditCaisseDetail
        ad.Pid = id

        If ad.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ad As New AddEditCaisseDetail
        ad.lbWriter.Text = Form1.adminName
        ad.lbDate.Text = Now
        ad.btWriter.Visible = True
         
        If ad.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
    End Sub
End Class