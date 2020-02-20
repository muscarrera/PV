Public Class Calc
    Public title As String = "الكمية السابقة"
    Public desc As String

    Private Sub CalcPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbtitle.Text = title
        txt.Text = desc
        CPanel1.Value = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If CPanel1.txt.Text = "" Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Else
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CPanel1.Value = CPanel1.Value / 1.2
    End Sub
End Class