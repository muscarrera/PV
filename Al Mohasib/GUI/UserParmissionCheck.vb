Public Class UserParmissionCheck
    Public code1 As String = "123459988"
    Public code2 As String = "123457766"


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Panel1.Click
        If txtCode.Text = code1 Or txtCode.Text = code2 Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub txtCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCode.KeyPress
        If e.KeyChar = Chr(13) Then
            Button1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub UserParmissionCheck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()

        txtCode.Text = ""
        txtCode.Focus()

    End Sub

    Private Sub Panel4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel4.Click, Panel3.Click, Panel2.Click, MyBase.Click, Label1.Click
        txtCode.Text = ""
        txtCode.Focus()
    End Sub
End Class