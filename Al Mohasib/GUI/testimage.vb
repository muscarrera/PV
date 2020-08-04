Public Class testimage

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim OPF As New OpenFileDialog
        If OPF.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OPF.FileName)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim img As Image = PictureBox1.Image
        translate(img, 100, 100, 100, 1)
        PictureBox2.Image = New Bitmap(img, New Size(300, 150))
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim img As Image = AppendBorder(PictureBox1.Image, 4)
        translate(img, 15, 20, 30, 1)

        PictureBox2.Image = New Bitmap(img, New Size(300, 150))
    End Sub

    
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click, Button5.Click
        '// Experiment with this value
        Dim exposurePercentage As Integer = 40

        Using img As Image = PictureBox1.Image
            Using g As Graphics = Graphics.FromImage(img)

                ' // First Number = Alpha, Experiment with this value.
                Using p As Pen = New Pen(Color.FromArgb(75, 255, 255, 255))
                    '   // Looks jaggy otherwise
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias

                    Dim x, y As Integer

                    '// 3 * Height looks best
                    Dim diameter As Integer = img.Height * 3
                    Dim imgPercent As Double = CDbl(img.Height / 100)
                    x = 0 - img.Width

                    '// How many percent of the image to expose
                    y = (0 - diameter) + CInt(imgPercent * exposurePercentage)

                    g.FillEllipse(p.Brush, x, y, diameter, diameter)

                    PictureBox2.Image = img
                End Using
            End Using
        End Using
    End Sub
End Class