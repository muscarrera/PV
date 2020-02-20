Public Class Screen2
   


    Private Sub Screen2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'Call CenterToScreen()
        'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'Me.WindowState = FormWindowState.Maximized

        pl.Location = New Point((Me.Width - pl.Width) \ 2, (Me.Height - pl.Height) \ 2)
    End Sub
End Class