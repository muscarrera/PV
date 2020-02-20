Public Class Depot

    Private Sub Depot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ALMohassinDBDataSet.Depot' table. You can move, or remove it, as needed.
        Me.DepotTableAdapter.Fill(Me.ALMohassinDBDataSet.Depot)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            Exit Sub
        End If

        TextBox1.Text = DataGridView1.SelectedRows(0).Cells(1).Value
        TextBox1.Tag = DataGridView1.SelectedRows(0).Cells(0).Value
        Button1.Tag = "1"

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If TextBox1.Text.Trim = "" Then
            Button1.Tag = "0"
            Exit Sub
        End If


        Dim ta As New ALMohassinDBDataSetTableAdapters.DepotTableAdapter
        If Button1.Tag = "1" Then

            ta.UpdateQuery(TextBox1.Text, TextBox1.Tag)
        Else
            ta.Insert(TextBox1.Text)

        End If
        DepotTableAdapter.Fill(ALMohassinDBDataSet.Depot)
        TextBox1.Text = ""
        Button1.Tag = "0"
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button1.Tag = "0"
        TextBox1.Text = ""
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button1.Tag = "0"
        TextBox1.Text = ""
    End Sub
End Class