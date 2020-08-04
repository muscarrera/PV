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

        Pl.BackgroundImage = BMP
    End Sub



    Private Sub BarCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getRegistryinfo(txtF1, "txtF1", "arial")
        getRegistryinfo(txtZ1, "txtZ1", "10")
        getRegistryinfo(txtF2, "txtF2", "arial")
        getRegistryinfo(txtZ2, "txtZ2", "10")
        getRegistryinfo(txtX, "txtX", "10")
        getRegistryinfo(txtY, "txtY", "10")
        getRegistryinfo(TXTW, "TXTW", "200")
        getRegistryinfo(TXTH, "TXTH", "100")

    End Sub


    Private Sub getRegistryinfo(ByRef txt As TxtBox, ByVal str As String, ByVal v As String)
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

    Private Sub txtX_TxtChanged() Handles txtZ2.TxtChanged, txtZ1.TxtChanged, txtY.TxtChanged, txtX.TxtChanged, TXTW.TxtChanged, TXTH.TxtChanged, txtF2.TxtChanged, txtF1.TxtChanged
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
End Class