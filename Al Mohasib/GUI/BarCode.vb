Public Class BarCode
    Public article As String
    Public qte As String
    Public Property Code As String
        Get
            Return EaN13Barcode1.Value
        End Get
        Set(ByVal value As String)
            EaN13Barcode1.Value = value
        End Set
    End Property


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImprimer.Click
        Try
            If txtQte.text = "" Then txtQte.text = 1
            For i As Integer = 1 To CInt(txtQte.text)

                PrintDocument1.PrinterSettings.PrinterName = Form1.txtprt2.Text
                PrintDocument1.Print()
            Next
        Catch ex As Exception

            If Form1.PrintDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintDocument1.PrinterSettings.PrinterName = Form1.PrintDlg.PrinterSettings.PrinterName
                PrintDocument1.Print()
            End If
        End Try

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        If txtX.text = "" Then txtX.text = 10
        If txtY.text = "" Then txtY.text = 10
        If TXTW.text = "" Then TXTW.text = 200
        If TXTH.text = "" Then TXTH.text = 100

        Dim BMP As New Bitmap(300, 200, Imaging.PixelFormat.Format24bppRgb)

        ' create the graphics object
        Dim GR As Graphics = Graphics.FromImage(BMP)

        ' fill the image with color white
        GR.Clear(Color.White)

        Dim x As Integer = 2
        Dim y As Integer = 2

        Dim drawRect As New Rectangle(x, y, EaN13Barcode1.Width, EaN13Barcode1.Height)
        EaN13Barcode1.PrintToGraphics(GR, drawRect)
        GR.DrawString("Fixation Atlantique Couleur", New Font("Arial", 12), Brushes.Black, x, y)
        y = y + EaN13Barcode1.Height + 10
        GR.DrawString(qte & " - " & article, New Font("Arial", 11), Brushes.Black, x, y)

        e.Graphics.DrawImage(BMP, CInt(txtX.text), CInt(txtY.text), CInt(TXTW.text), CInt(TXTH.text))

    End Sub
End Class