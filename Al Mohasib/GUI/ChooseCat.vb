Public Class ChooseCat

    Private Sub ChooseCat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            DataGridView1.DataSource = a.SelectDataTableSymbols("Category", {"*"})
        End Using

        Button1.Tag = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.Tag = 1
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub DataGridView1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseDoubleClick
        Button1.Tag = 1
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button1.Tag = 2
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class