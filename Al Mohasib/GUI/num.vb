Public Class num

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "1234" & Date.Now.Day.ToString Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            MsgBox("يوجد خطأ في الرمز")
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub
End Class