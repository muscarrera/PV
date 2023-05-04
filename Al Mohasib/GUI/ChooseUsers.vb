Public Class ChooseUsers
    Public val As Integer = 0
    Public ReadOnly Property adminName As String
        Get
            If DataGridView1.SelectedRows.Count = 0 Then Return ""
            Return DataGridView1.SelectedRows(0).Cells(1).Value
        End Get
    End Property
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        val = 1
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        val = 0
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        val = 0
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub ChooseUsers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            DataGridView1.DataSource = a.SelectDataTableSymbols("Admin", {"*"})
        End Using
    End Sub
End Class