Public Class Screen2
   


    Private Sub Screen2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Form1.txtLogo.Text.Length < 5 Then
            plLogo.Visible = False
        Else
            Try
                plLogo.BackgroundImage = Image.FromFile(Form1.txtLogo.Text)
            Catch ex As Exception
                plLogo.Visible = False
            End Try
        End If


        If Form1.txtMsgOc.Text.Length > 5 Then
            lbMsg.Text = Form1.txtMsgOc.Text
        Else
            plMsg.Visible = False
        End If


        If Form1.txtBgScreen.Text.Length > 5 Then
            Try
                PlBg.BackgroundImage = Image.FromFile(Form1.txtBgScreen.Text)
            Catch ex As Exception
            End Try
        End If


        ' Call CenterToScreen()
        ''   Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'Me.WindowState = FormWindowState.Maximized

        pl.Location = New Point((Me.Width - pl.Width) \ 2, 0)

    End Sub
End Class