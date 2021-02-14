
Public Class BarCode1
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

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtX", txtX.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtY", txtY.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TXTW", TXTW.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TXTH", TXTH.text)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try








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

        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Near
        Dim sf1 As New StringFormat()
        sf1.Alignment = StringAlignment.Far
        Dim sf2 As New StringFormat()
        sf2.Alignment = StringAlignment.Center



        If txtX.text = "" Then txtX.text = 10
        If txtY.text = "" Then txtY.text = 10
        If TXTW.text = "" Then TXTW.text = 200
        If TXTH.text = "" Then TXTH.text = 100

        Dim BMP As New Bitmap(CInt(TXTW.text + 100), CInt(TXTH.text + 100), Imaging.PixelFormat.Format24bppRgb)

        ' create the graphics object
        Dim GR As Graphics = Graphics.FromImage(BMP)

        ' fill the image with color white
        GR.Clear(Color.White)

        Dim fntT As Font = New Font(txtF1.text, CInt(txtZ1.text))
        Dim fntP As Font = New Font(txtF2.text, CInt(txtZ2.text))

        Dim x As Integer = 2
        Dim y As Integer = 2

        If CheckBox1.Checked = False Then
            Dim drawRect As New Rectangle(x, y, EaN13Barcode1.Width, EaN13Barcode1.Height)
            EaN13Barcode1.PrintToGraphics(GR, drawRect)
            GR.DrawString(article, fntT, Brushes.Black, New RectangleF(x, y, EaN13Barcode1.Width, fntP.Height), sf2)
            y = y + EaN13Barcode1.Height + 10
            GR.DrawString("*** ---  " & qte & "  ---***", fntP, Brushes.Black, New RectangleF(x, y, EaN13Barcode1.Width, 15), sf2)
        Else
            Dim drawRect As New Rectangle(x, y, EaN13Barcode1.Width, EaN13Barcode1.Height)
            EaN13Barcode1.PrintToGraphics(GR, drawRect)

            Dim size As SizeF = GR.MeasureString(article, fntT, EaN13Barcode1.Width)
            Dim H = size.Height
            GR.FillRectangle(Brushes.White, x, y, EaN13Barcode1.Width, H)
            GR.DrawString(article, fntT, Brushes.Black, New RectangleF(x, y, EaN13Barcode1.Width, H), sf2)
            y = y + EaN13Barcode1.Height + 10
            GR.DrawString("*** ---  " & qte & "  ---***", fntP, Brushes.Black, New RectangleF(x, y, EaN13Barcode1.Width, 15), sf2)

        End If

        e.Graphics.DrawImage(BMP, CInt(txtX.text), CInt(txtY.text), CInt(TXTW.text), CInt(TXTH.text))

    End Sub

    Private Sub GetApercu()

        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Near
        Dim sf1 As New StringFormat()
        sf1.Alignment = StringAlignment.Far
        Dim sf2 As New StringFormat()
        sf2.Alignment = StringAlignment.Center



        If txtX.text = "" Then txtX.text = 10
        If txtY.text = "" Then txtY.text = 10
        If TXTW.text = "" Then TXTW.text = 200
        If TXTH.text = "" Then TXTH.text = 100

        Dim BMP As New Bitmap(CInt(TXTW.text), CInt(TXTH.text), Imaging.PixelFormat.Format24bppRgb)

        ' create the graphics object
        Dim GR As Graphics = Graphics.FromImage(BMP)

        ' fill the image with color white
        GR.Clear(Color.White)

        Dim fntT As Font = New Font(txtF1.text, CInt(txtZ1.text))
        Dim fntP As Font = New Font(txtF2.text, CInt(txtZ2.text))

        Dim x As Integer = 2
        Dim y As Integer = 2

        EaN13Barcode1.Width = CInt(TXTW.text)
        EaN13Barcode1.Height = CInt(TXTH.text)
        Dim drawRect As New Rectangle(x, y, EaN13Barcode1.Width, EaN13Barcode1.Height)
        EaN13Barcode1.PrintToGraphics(GR, drawRect)


        Pb.BackgroundImage = BMP


        'Pb.Image = createBarCodeNoDescription(Code, Color.Blue, 12, False)
    End Sub



    Private Sub GetApercu22()

        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Near
        Dim sf1 As New StringFormat()
        sf1.Alignment = StringAlignment.Far
        Dim sf2 As New StringFormat()
        sf2.Alignment = StringAlignment.Center



        If txtX.text = "" Then txtX.text = 10
        If txtY.text = "" Then txtY.text = 10
        If TXTW.text = "" Then TXTW.text = 200
        If TXTH.text = "" Then TXTH.text = 100

        Dim BMP As New Bitmap(CInt(TXTW.text + 100), CInt(TXTH.text + 100), Imaging.PixelFormat.Format24bppRgb)

        ' create the graphics object
        Dim GR As Graphics = Graphics.FromImage(BMP)

        ' fill the image with color white
        GR.Clear(Color.White)

        Dim fntT As Font = New Font(txtF1.text, CInt(txtZ1.text))
        Dim fntP As Font = New Font(txtF2.text, CInt(txtZ2.text))

        Dim x As Integer = 2
        Dim y As Integer = 2

        If CheckBox1.Checked = False Then
            Dim drawRect As New Rectangle(x, y, EaN13Barcode1.Width, EaN13Barcode1.Height)
            EaN13Barcode1.PrintToGraphics(GR, drawRect)
            GR.DrawString(article, fntT, Brushes.Black, New RectangleF(x, y, EaN13Barcode1.Width, fntT.Height), sf2)
            y = y + EaN13Barcode1.Height + 10
            GR.DrawString("*** ---  " & qte & "  ---***", fntP, Brushes.Black, New RectangleF(x, y, EaN13Barcode1.Width, 15), sf2)
        Else
            Dim drawRect As New Rectangle(x, y, EaN13Barcode1.Width, EaN13Barcode1.Height)
            EaN13Barcode1.PrintToGraphics(GR, drawRect)

            Dim size As SizeF = GR.MeasureString(article, fntT, EaN13Barcode1.Width)
            Dim H = size.Height
            GR.FillRectangle(Brushes.White, x, y, EaN13Barcode1.Width, H)
            GR.DrawString(article, fntT, Brushes.Black, New RectangleF(x, y, EaN13Barcode1.Width, H), sf2)
            y = y + EaN13Barcode1.Height + 10
            GR.DrawString("*** ---  " & qte & "  ---***", fntP, Brushes.Black, New RectangleF(x, y, EaN13Barcode1.Width, 15), sf2)
        End If

        Pb.Image = BMP


        'Pb.Image = createBarCodeNoDescription(Code, Color.Blue, 12, False)
    End Sub
    Function createBarCodeNoDescription(ByVal BarcodeNumber As String, ByVal BarcodeColor As Drawing.Color, ByVal BarcodeSize As Integer, ByVal AddBackGroundColor As Boolean) As Drawing.Bitmap
        Dim stchar As String = String.Empty
        Dim col1 As Drawing.Color = BarcodeColor
        Dim col2 As Drawing.Color = BarcodeColor
        Dim k As String = BarcodeNumber
        Dim addStar As String = "*"
        Dim full As String = addStar & BarcodeNumber & addStar
        BarcodeNumber = full
        Dim textsize As Drawing.SizeF

        Dim int As Integer = BarcodeSize / 2
        Dim bc As Drawing.Bitmap = New Drawing.Bitmap(BarcodeSize * 8, BarcodeSize * 2)
        Dim myf As Drawing.Font = New Drawing.Font("Arial", int, New Drawing.FontStyle) ', GraphicsUnit.Point)
        Dim ft As Drawing.Font = New Drawing.Font("Free 3 of 9 Extended", BarcodeSize, New Drawing.FontStyle, Drawing.GraphicsUnit.Point)
        Dim g As Drawing.Graphics = Drawing.Graphics.FromImage(bc)
        textsize = g.MeasureString(BarcodeNumber, myf)
        If AddBackGroundColor = True Then
            g.Clear(Drawing.Color.White)
        End If
        ' g.Clear(Panel1.BackColor)
        ' g.Clear(Color.Transparent)
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixel '
        g.DrawString(BarcodeNumber, ft, New Drawing.SolidBrush(col1), 2, 3)
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault
        For Each chr As Char In k
            stchar &= chr.ToString & " "
        Next
        g.DrawString(stchar, myf, New Drawing.SolidBrush(col2), 6, textsize.Height + 6)
        '  g.DrawString(k, myf, New SolidBrush(Color.Black), 0, 30)
        g.Flush()
        ft.Dispose()
        g.Dispose()
        Return bc
    End Function

    Private Sub BarCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getRegistryinfo(txtF1, "txtF1", "arial")
        getRegistryinfo(txtZ1, "txtZ1", "10")
        getRegistryinfo(txtF2, "txtF2", "arial")
        getRegistryinfo(txtZ2, "txtZ2", "10")
        getRegistryinfo(txtX, "txtX", "10")
        getRegistryinfo(txtY, "txtY", "10")
        getRegistryinfo(TXTW, "TXTW", "200")
        getRegistryinfo(TXTH, "TXTH", "100")

        getRegistryinfo(TxtBox1, "TxtBox1", "44")
        getRegistryinfo(TxtBox2, "TxtBox2", "55")
        getRegistryinfo(TxtBox3, "TxtBox3", "6")
        getRegistryinfo(TxtBox4, "TxtBox4", "16")
        getRegistryinfo(TxtBox5, "TxtBox5", "0")
        getRegistryinfo(TxtBox6, "TxtBox6", "0")



      

    End Sub


    Private Sub getRegistryinfo(ByRef txt As TxtBox, ByVal str As String, ByVal v As String)
        Try
            Dim msg As String
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, Nothing)
            If msg = Nothing Then
                msg = v
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, msg)
                txt.text = msg
            Else
                txt.text = msg
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub getRegistryinfo(ByRef txt As ComboBox, ByVal str As String, ByVal v As String)
        Try
            Dim msg As String
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, Nothing)
            If msg = Nothing Then
                msg = v
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, msg)
                txt.Text = msg
            Else
                txt.Text = msg
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub getRegistryinfo(ByRef cb As CheckBox, ByVal str As String, ByVal v As Boolean)
        Try
            Dim msg As Boolean
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, Nothing)
            If IsNothing(msg) Then
                msg = v
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, msg)
                cb.Checked = msg
            Else
                cb.Checked = msg
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim fntdlg As New FontDialog
            If fntdlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            txtF1.text = fntdlg.Font.Name
            txtZ1.text = CInt(fntdlg.Font.Size)

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtF1", txtF1.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtZ1", txtZ1.text)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim fntdlg As New FontDialog
            If fntdlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            txtF2.text = fntdlg.Font.Name
            txtZ2.text = CInt(fntdlg.Font.Size)

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtF2", txtF2.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtZ2", txtZ2.text)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Sub txtX_TxtChanged() Handles txtZ2.TxtChanged, txtZ1.TxtChanged, txtY.TxtChanged, txtX.TxtChanged, TXTW.TxtChanged, TXTH.TxtChanged, txtF2.TxtChanged, txtF1.TxtChanged, TxtBox4.TxtChanged, TxtBox3.TxtChanged, TxtBox2.TxtChanged, TxtBox1.TxtChanged, TxtBox5.TxtChanged, TxtBox6.TxtChanged
        Try
            GetApercu()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Try
            GetApercu()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintDocument2_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument2.PrintPage
        e.Graphics.DrawImage(Pb.BackgroundImage, 0, CInt(TxtBox5.text), CInt(TXTW.text), CInt(TXTH.text))


        Dim sf2 As New StringFormat()
        sf2.Alignment = StringAlignment.Center

        Dim bigPrice As Integer = 0
        Dim smallPrice As Double = 0
        SplitDecimal(qte, bigPrice, smallPrice)

        Dim SM As Integer = CInt(smallPrice * 100)

        Dim fntT As Font = New Font("Tahoma", CInt(TxtBox4.text), FontStyle.Bold)
        Dim fntP As Font = New Font("Arial", CInt(TxtBox3.text), FontStyle.Bold)

        Dim fntName As Font = New Font(txtF1.text, CInt(txtZ1.text))
        Dim fntcode As Font = New Font(txtF2.text, CInt(txtZ2.text))

        e.Graphics.FillRectangle(Brushes.Black, CInt(TXTW.text) - (CInt(TxtBox2.text) + 2), 3, CInt(TxtBox2.text) + 5, CInt(TxtBox5.text) + 30)

        e.Graphics.DrawString(SM, fntP, Brushes.White, CInt(TXTW.text) - CInt(TxtBox1.text), 5)
        e.Graphics.DrawString(bigPrice, fntT, Brushes.White, CInt(TXTW.text) - CInt(TxtBox2.text), 3)

        e.Graphics.DrawString(article, fntName, Brushes.Black, New RectangleF(2, 3, CInt(TXTW.text) - CInt(TxtBox2.text), CInt(TxtBox5.text) + 30), sf2)


        If CheckBox1.Checked = False Then

            e.Graphics.FillRectangle(Brushes.White, 3, CInt(TxtBox6.text), CInt(TXTW.text), fntcode.Height)
            e.Graphics.DrawString(Code, fntcode, Brushes.Black, New RectangleF(2, CInt(TxtBox6.text), CInt(TXTW.text), fntcode.Height), sf2)

        End If



    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Try

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtX", txtX.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtY", txtY.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TXTW", TXTW.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TXTH", TXTH.text)




            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TxtBox1", TxtBox1.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TxtBox2", TxtBox2.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TxtBox3", TxtBox3.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TxtBox4", TxtBox4.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TxtBox5", TxtBox5.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TxtBox6", TxtBox6.text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try



        Try
            If txtQte.text = "" Then txtQte.text = 1
            For i As Integer = 1 To CInt(txtQte.text)

                PrintDocument2.PrinterSettings.PrinterName = Form1.txtprt2.Text
                PrintDocument2.Print()
            Next
        Catch ex As Exception

            If Form1.PrintDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintDocument2.PrinterSettings.PrinterName = Form1.PrintDlg.PrinterSettings.PrinterName
                PrintDocument2.Print()
            End If
        End Try
    End Sub

End Class