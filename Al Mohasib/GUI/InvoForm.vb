Public Class InvoForm

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
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

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If dg_D.SelectedRows.Count = 0 Then Exit Sub

        If isInvo = False Then
            Button10_Click(Nothing, Nothing)
            Exit Sub
        End If



        lbName.Text = dg_D.SelectedRows(0).Cells(1).Value
        lbDateCreation.Text = dg_D.SelectedRows(0).Cells(3).Value
        lbDateValid.Text = dg_D.SelectedRows(0).Cells(4).Value

        btValid.Visible = Not CBool(dg_D.SelectedRows(0).Cells(5).Value)

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add("fctid", dg_D.SelectedRows(0).Cells(0).Value)
            dt_details = a.SelectDataTable("detailsinvo", {"*"})

            If CBool(dg_D.SelectedRows(0).Cells(8).Value) Then
                dt_Stock = a.SelectDataTable("stockinvo", {"*"})

            Else

                params.Clear()
                params.Add("fctid = ", dg_D.SelectedRows(0).Cells(0).Value)
                dt_Stock = a.SelectDataTableSymbols("detailsinvo", {"name, bprice, price, unit, arid, depot, SUM(qte)"}, params, , "GROUP BY arid")

            End If


            dg_D.DataSource = dt_details
            dg_D.Sort(dg_D.Columns("arid"), System.ComponentModel.ListSortDirection.Descending)



            'SELECT client, SUM(tarif) FROM achat GROUP BY client
            isInvo = False
        End Using

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        dg_D.DataSource = Nothing
        dg_D.DataSource = dt_details
        dg_D.Sort(dg_D.Columns("arid"), System.ComponentModel.ListSortDirection.Descending)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        dg_D.DataSource = Nothing
        dg_D.DataSource = dt_Stock
        dg_D.Sort(dg_D.Columns("arid"), System.ComponentModel.ListSortDirection.Descending)
        isInvo = False
    End Sub
End Class