Public Class AddEditSidePanel

    Public isDeleting As Boolean = False


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSup.Click
        isDeleting = True
        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not IsNumeric(N.text) Or Not IsNumeric(W.text) Or Not IsNumeric(H.text) Or Not IsNumeric(T.text) Then Exit Sub
        If txtF1.text.Trim = "" Then txtF1.text = "Arial"
        If txt.text.Trim = "" Then txt.text = "*****"


        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btColor.Click
        Dim cr As New ColorDialog
        If cr.ShowDialog = DialogResult.OK Then
            btColor.BackColor = cr.Color
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim fntdlg As New FontDialog
            If fntdlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            txtF1.text = fntdlg.Font.Name
            T.text = CInt(fntdlg.Font.Size)


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
End Class