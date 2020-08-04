Public Class PriceType
    Public value As Integer = 0


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click, Button3.Click, Button2.Click, Button1.Click
        Dim bt As Button = sender
        value = bt.Tag

        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub
End Class