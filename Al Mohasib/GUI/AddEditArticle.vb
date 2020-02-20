Imports System.IO
Imports System.IO.Ports
Imports MyBarcode
Imports System.Drawing.Drawing2D


Public Class AddEditArticle
    Public cid As Integer
    Public editMode As Boolean
    Private imgWithPrice, _imgPrd As Image

    Public Property ImgPrd As Image
        Get
            Return _imgPrd
        End Get
        Set(ByVal value As Image)
            Dim rnd As New Random
            If IsNothing(value) Then
                Dim BMG As New Bitmap(Form1.txtlongerbt.Text, Form1.txtlargebt.Text,
                                      Imaging.PixelFormat.Format24bppRgb)

                Dim GR As Graphics = Graphics.FromImage(BMG)
                GR.Clear(Color.White)
                GR.Clear(Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255)))
                _imgPrd = BMG
            Else
                _imgPrd = value
            End If

        End Set
    End Property

    Dim WithEvents moRS232 As New SerialPort
    Private Sub com1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles moRS232.DataReceived

        Dim returnStr As String
        returnStr = moRS232.ReadLine
        'ReadLine does not work. Any reason why??
        ' ReceiveSerialData(returnStr)
        ' moRS232.DiscardInBuffer()
        txtcb.text = returnStr & vbCrLf

    End Sub
    Sub ReceiveSerialData(ByVal msg As String)
        ' Receive strings from a serial port.
        '  CheckForIllegalCrossThreadCalls = False
        txtcb.text = msg & vbCrLf
    End Sub
    Private Sub CommPortSetup()
        With moRS232
            .PortName = "COM1"
            .BaudRate = 9600
            .DataBits = 8
            .Parity = Parity.None
            .StopBits = StopBits.One
            .Handshake = Handshake.None
        End With
        Try
            moRS232.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub AddEditArticle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ALMohassinDBDataSet.Depot' table. You can move, or remove it, as needed.
        Me.DepotTableAdapter.Fill(Me.ALMohassinDBDataSet.Depot)
        'TODO: This line of code loads data into the 'ALMohassinDBDataSet.Category' table. You can move, or remove it, as needed.
        Me.CategoryTableAdapter.Fill(Me.ALMohassinDBDataSet.Category)

        If Form1.CBTVA.Checked = False Then
            txttva.Visible = False
            txttva.text = 20
            Label6.Visible = False
        End If

        If editMode Then
            If cbctg.Tag = 0 Or cbctg.Tag = -100 Then

                cbctg.Visible = False
                Label3.Visible = False
                cid = cbctg.Tag
            Else
                If cbctg.Tag.ToString <> "" Then
                    cbctg.SelectedValue = cbctg.Tag
                Else
                    cid = cbctg.SelectedValue
                End If
            End If
            If CBdp.Tag <> "" Then CBdp.SelectedValue = CBdp.Tag

        End If


        If PBprd.Tag = "" Or PBprd.Tag = "No Image" Then
            ImgPrd = Nothing
        Else
            ImgPrd = Image.FromFile(Form1.BtImgPah.Tag & "\art" & PBprd.Tag)
        End If

        PBprd.BackgroundImage = Drawimg(txtprdname.Text, txtsprice.text)
        txtcb.Focus()
    End Sub

    Private Sub btprd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btprd.Click
        Try
            If Not IsNumeric(txtbprice.text) Then
                txtbprice.text = txtbprice.text.Replace(".", ",")
            End If

            If Not IsNumeric(txtsprice.text) Then
                txtsprice.text = txtsprice.text.Replace(".", ",")
            End If

        Catch ex As Exception

        End Try

        Try
            'validation
            ''empty field
            If txtprdname.Text.Trim = "" Then
                MsgBox("عذرا لا يمكن اتمام طلبكم.. المرجوا تعبئة الاسم", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                txtprdname.Focus()
                Exit Sub
            End If
            If txtbprice.text.Trim = "" Then
                MsgBox("عذرا لا يمكن اتمام طلبكم.. المرجوا تعبئة ثمن الشراء", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                txtbprice.Focus()
                Exit Sub
            End If
            If txtsprice.text.Trim = "" Then
                MsgBox("عذرا لا يمكن اتمام طلبكم.. المرجوا تعبئة ثمن البيع", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                txtsprice.Focus()
                Exit Sub
            End If
            If txtunit.Text.Trim = "" Then
                MsgBox("عذرا لا يمكن اتمام طلبكم.. المرجوا تعبئة الوحدة", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                txtunit.Focus()
                Exit Sub
            End If

            If txtprice2.text.Trim = "" Then txtprice2.text = txtsprice.text
            If txtprice3.text.Trim = "" Then txtprice3.text = txtprice2.text
            If TxtPoids.text = "" Or Not IsNumeric(TxtPoids.text) Then TxtPoids.text = 0

            ''check the pricess
            If Not IsNumeric(txtbprice.text) Then
                txtbprice.text = txtbprice.text.Replace(".", ",")
                If Not IsNumeric(txtbprice.text) Then
                    MsgBox("عذرا لا يمكن اتمام طلبكم.. ثمن الشراء يجب أن يكون عدد", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                    txtbprice.Focus()
                    Exit Sub
                End If

            End If
            If Not IsNumeric(txtsprice.text) Then
                txtsprice.text = txtsprice.text.Replace(".", ",")
                If Not IsNumeric(txtsprice.text) Then
                    MsgBox("عذرا لا يمكن اتمام طلبكم.. ثمن البيع يجب أن يكون عدد", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                    txtsprice.Focus()
                    Exit Sub
                End If
            End If
            If Decimal.Parse(txtbprice.text) > Decimal.Parse(txtsprice.text) Then
                MsgBox("عذرا لا يمكن اتمام طلبكم.. ثمن البيع يجب أن يكون أكبر من ثمن الشراء", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                txtbprice.Focus()
                Exit Sub
            End If


          


        Catch ex As Exception
            MsgBox("عذرا لا يمكن اتمام طلبكم.. المرحوا التأكد من صحة المعطيات ", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
            Exit Sub
        End Try

        Dim bprice As Double = txtbprice.text
        Dim sprice As Double = txtsprice.text
        Dim tva As Double = 20
        If txttva.text <> "" Then tva = txttva.text

        Dim price2 As Double = txtprice2.text
        Dim price3 As Double = txtprice3.text

        If Not IsNumeric(txtPrice4.text) Then
            txtPrice4.text = sprice
        End If
        Dim price4 As Double = txtPrice4.text

        If cid = 0 Then cid = cbctg.SelectedValue

        ' addddd
        If btprd.Tag = "0" Then
            ''check the name

            For i As Integer = 0 To Articles.DGVPRD.Rows.Count - 1
                If txtprdname.Text = Articles.DGVPRD.Rows(i).Cells(2).Value Then
                    MsgBox("عذرا لا يمكن اتمام طلبكم.. يجب عدم تكرار نفس الاسم", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                    txtprdname.Focus()

                    Exit Sub
                End If
                If txtcb.text <> "" And txtcb.text = Articles.DGVPRD.Rows(i).Cells(1).Value.ToString Then
                    MsgBox("عذرا لا يمكن اتمام طلبكم.. يجب عدم تكرار نفس الرمز لأكتر من ماذة. أو تركه فارغ", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                    txtcb.Focus()
                    Exit Sub
                End If
            Next
            Try
                saveImage()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Try
                Dim ta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
                ta.InsertQuery(cid, txtprdname.Text, PBprd.Tag, bprice, sprice, txtunit.Text, txtcb.text, "0", tva,
                               price2, price3, price4, TxtPoids.text, CInt(CBdp.SelectedValue), CBool(cbIsMixte.Checked), txtMinStock.text)
                ta.Fill(ALMohassinDBDataSet.Article)
                If CheckBox1.Checked Then
                    txtcb.text = ""
                    txtbprice.text = ""
                    TxtPoids.text = ""
                    txtsprice.text = ""
                    txtprdname.Text = ""
                    txtunit.Text = ""
                    PBprd.Tag = ""
                    PBprd.BackgroundImage = Nothing
                Else
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            'updateeee
        Else
            saveImage()

            Try
                Dim ta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
                ta.UpdateQuery(cid, txtprdname.Text, PBprd.Tag, bprice, sprice, txtunit.Text, tva,
                               price2, price3, price4, TxtPoids.text, txtcb.text, CInt(CBdp.SelectedValue),
                               cbIsMixte.Checked, txtMinStock.text, txtprdname.Tag)
                ta.Fill(ALMohassinDBDataSet.Article)
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    Private Sub btprdimg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btprdimg.Click

        Dim savepic As New OpenFileDialog
        savepic.Filter = "*.jpg|*.jpg"
        If savepic.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim pmg2 As New Bitmap(savepic.FileName)

            lbchangeimg.Text = "1"
            ImgPrd = pmg2
            PBprd.BackgroundImage = Drawimg(txtprdname.Text, txtbprice.text)

        End If

    End Sub
    Private Sub btgenir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btgenir.Click
        Dim EA As New EAN13Barcode
        EA.Value = GetRandom(10000000, 99999999)
        txtcb.text = EA.Value & EA.CheckSum.ToString()
        EA = Nothing
    End Sub
    Private Sub btprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btprint.Click
        Try

            If txtcb.text = "" Then Exit Sub
            Dim cde As String = txtcb.text
            If cde.Length > 12 Then cde = cde.Substring(0, 12)
            If cde.Length < 12 Then Exit Sub

            Dim CD As New BarCode
            CD.Code = cde
            CD.article = txtprdname.Text
            CD.qte = txtunit.Text

            If CD.ShowDialog = DialogResult.OK Then

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim tva As Double = 1.2
            If txttva.text <> "" Then tva = (100 + txttva.text) / 100

            txtbprice.text = String.Format("{0:F}", CDbl(txtbprice.text) * tva)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim tva As Double = 1.2
            If txttva.text <> "" Then tva = (100 + txttva.text) / 100

            txtsprice.text = String.Format("{0:F}", CDbl(txtsprice.text) * tva)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cbctg_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbctg.SelectedIndexChanged
        cid = cbctg.SelectedValue
    End Sub
    Private Sub txttva_TxtChanged() Handles txttva.TxtChanged, txtMinStock.TxtChanged, TxtPoids.TxtChanged
        Try
            If txttva.text < 0 Then txttva.text = ""
        Catch ex As Exception
            txttva.text = ""
        End Try

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim tva As Double = 1.2
            If txttva.text <> "" Then tva = (100 + txttva.text) / 100

            txtprice2.text = String.Format("{0:F}", CDbl(txtprice2.text) * tva)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim tva As Double = 1.2
            If txttva.text <> "" Then tva = (100 + txttva.text) / 100

            txtprice3.text = String.Format("{0:F}", CDbl(txtprice3.text) * tva)
        Catch ex As Exception
        End Try
    End Sub

    Public Function Drawimg(ByVal name As String, ByVal Bprice As String) As Bitmap
        Dim fntSmall As New Font("Arial", 7)
        Dim fnt As New Font("Arial", 11, FontStyle.Bold)
        Dim ht As Integer = CInt(Form1.txtlargebt.Text)
        Dim wd As Integer = CInt(Form1.txtlongerbt.Text)
        'create the bitmap
        Dim BMG As New Bitmap(Form1.txtlongerbt.Text, Form1.txtlargebt.Text, Imaging.PixelFormat.Format24bppRgb)
        'ceate the graphic
        Dim GR As Graphics = Graphics.FromImage(BMG)
 

        GR.Clear(Color.White)

        'draw the lines
        Try
            'Dim rnd As New Random
            If IsNothing(ImgPrd) Then ImgPrd = Nothing
            '    GR.Clear(Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255)))
            'Else
            'Dim img As Image = ImgPrd
            GR.DrawImage(ImgPrd, 0, 0, wd, ht)
            'End If

            'imgPrd = BMG

            'Dim random_Color As New Color
            'random_Color = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255))
            'Dim nBrush As New SolidBrush(random_Color)

            Bprice = String.Format("{0:F}", CDbl(Bprice))
            Dim Sl As Size = TextRenderer.MeasureText(Bprice, fntSmall)
            GR.FillRectangle(Brushes.White, wd - Integer.Parse(Sl.Width + 5), 3, Integer.Parse(Sl.Width + 5), Integer.Parse(Sl.Height + 5))
            GR.DrawString(Bprice, fntSmall, Brushes.Black, wd - Integer.Parse(Sl.Width + 5) + 2, 5)

            Dim sfC As New StringFormat()
            sfC.Alignment = StringAlignment.Center
            Dim size As SizeF = GR.MeasureString(name, fnt, wd)
            GR.FillRectangle(Brushes.White, 0, CInt(ht - size.Height - 10), wd, CInt(size.Height + 5))
            'GR.DrawString(name, fnt, Brushes.Black, New RectangleF(2, ht - size.Height, wd - 4, size.Height), sfC)
        Catch ex As Exception

        End Try

        imgWithPrice = BMG
        Return BMG
    End Function
    Private Sub saveImage()
        Dim dir1 As New DirectoryInfo(Form1.BtImgPah.Tag)
        If dir1.Exists = False Then dir1.Create()

        Try
            Dim str As String = txtprdname.Text
            str = str.Replace("/", "-")
            str = str.Replace("*", "-")

            Using img As Image = ImgPrd
                Try
                    img.Save(Form1.BtImgPah.Tag & "\art" & str & ".jpg", Imaging.ImageFormat.Jpeg)
                Catch ex As Exception
                    Dim ff As New FileInfo(Form1.BtImgPah.Tag & "\art" & str & ".jpg")
                    ff.Delete()
                    img.Save(Form1.BtImgPah.Tag & "\art" & str & ".jpg", Imaging.ImageFormat.Jpeg)
                End Try

            End Using
            Using img As Image = imgWithPrice
                Try
                    img.Save(Form1.BtImgPah.Tag & "\P-art" & str & ".jpg", Imaging.ImageFormat.Jpeg)
                Catch ex As Exception
                    Dim ff As New FileInfo(Form1.BtImgPah.Tag & "\P-art" & str & ".jpg")
                    ff.Delete()
                    img.Save(Form1.BtImgPah.Tag & "\P-art" & str & ".jpg", Imaging.ImageFormat.Jpeg)
                End Try
            End Using

            PBprd.Tag = str & ".jpg"
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtsprice_TxtChanged() Handles txtsprice.TxtChanged
        PBprd.BackgroundImage = Drawimg(txtprdname.Text, txtsprice.text)
    End Sub
    Private Sub txtprdname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprdname.TextChanged
        PBprd.BackgroundImage = Drawimg(txtprdname.Text, txtsprice.text)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            Dim tva As Double = 1.2
            If txttva.text <> "" Then tva = (100 + txttva.text) / 100

            txtPrice4.text = String.Format("{0:F}", CDbl(txtPrice4.text) * tva)
        Catch ex As Exception
        End Try
    End Sub
End Class