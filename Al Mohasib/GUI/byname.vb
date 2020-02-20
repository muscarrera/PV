Public Class byname

    Public qte As Double

    Private Sub byname_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txt.Focus()
    End Sub

    Private Sub txt_KeyDownOk() Handles txt.KeyDownOk
        If txt.text = "" Then
            qte = 1
        Else
            qte = txt.text
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class