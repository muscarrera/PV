Imports System.IO
Imports System.IO.Ports
Imports MyBarcode
Imports System.Drawing.Drawing2D
Imports System.Text
Imports System.Drawing.Imaging


Public Class AddEditArticle
    Public id As Integer = 0
    Public cid As Integer = 0
    Public editMode As Boolean = False
    Public imagePath As String = ""
    Public isImgChenged As Boolean = False
    Private imgWithPrice, _imgPrd As Image
    Dim rnd As New Random
    Dim cr As Color = Color.WhiteSmoke


    Private Sub AddEditArticle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            cbctg.DataSource = a.SelectDataTableSymbols("Category", {"*"})
            CBdp.DataSource = a.SelectDataTableSymbols("Depot", {"*"})
        End Using

        If Form1.CBTVA.Checked = False Then
            txttva.Visible = False
            txttva.text = 20
            Label6.Visible = False
        End If

        If editMode Then
            FillForm()
        End If

        If Form1.CbArticleRemise.Checked Then
            lbpoids.Text = "Remise"
            lbpoids.Left = TxtPoids.Left
        End If


        Try
            If txtMarge.text = "" Then txtMarge.text = 0
            If txtMarge.text = 0 Or True Then
                Try
                    txtMarge.text = String.Format("{0:n}", CDec((txtsprice.text - txtbprice.text) * 100 / txtbprice.text))
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        End Try

        cr = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255))
        txtcb.Focus()
    End Sub
    Public Property ImgPrd As Image
        Get
            Return _imgPrd
        End Get
        Set(ByVal value As Image)

            If IsNothing(value) Then
                Dim BMG As New Bitmap(Form1.txtlongerbt.Text, Form1.txtlargebt.Text,
                                      Imaging.PixelFormat.Format24bppRgb)

                Dim GR As Graphics = Graphics.FromImage(BMG)
                GR.Clear(Color.White)
                GR.Clear(cr)
                _imgPrd = BMG
            Else
                _imgPrd = value
            End If

        End Set
    End Property
    'Private Sub AddEditArticle_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    Try
    '        '_ImgPrd = Nothing
    '        'imgWithPrice = Nothing

    '        _imgPrd.Dispose()
    '        imgWithPrice.Dispose()
    '    Catch ex As Exception

    '    End Try


    'End Sub
    'Public Function Drawimg(ByVal name As String, ByVal Bprice As String) As Bitmap
    '    Dim fntSmall As New Font("Arial", 7)
    '    Dim fnt As New Font("Arial", 11, FontStyle.Bold)
    '    Dim ht As Integer = CInt(Form1.txtlargebt.Text)
    '    Dim wd As Integer = CInt(Form1.txtlongerbt.Text)
    '    'create the bitmap
    '    Dim BMG As New Bitmap(Form1.txtlongerbt.Text, Form1.txtlargebt.Text, Imaging.PixelFormat.Format24bppRgb)
    '    'ceate the graphic
    '    Dim GR As Graphics = Graphics.FromImage(BMG)


    '    GR.Clear(Color.White)

    '    'draw the lines
    '    Try
    '        'Dim rnd As New Random
    '        If IsNothing(ImgPrd) Then ImgPrd = Nothing
    '        '    GR.Clear(Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255)))
    '        'Else
    '        'Dim img As Image = ImgPrd
    '        GR.DrawImage(ImgPrd, 0, 0, wd, ht)
    '        'End If

    '        'imgPrd = BMG

    '        'Dim random_Color As New Color
    '        'random_Color = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255))
    '        'Dim nBrush As New SolidBrush(random_Color)
    '        Try
    '            Bprice = String.Format("{0:F}", CDbl(Bprice))
    '            Dim Sl As Size = TextRenderer.MeasureText(Bprice, fntSmall)
    '            GR.FillRectangle(Brushes.White, wd - Integer.Parse(Sl.Width + 5), 3, Integer.Parse(Sl.Width + 5), Integer.Parse(Sl.Height + 5))
    '            GR.DrawString(Bprice, fntSmall, Brushes.Black, wd - Integer.Parse(Sl.Width + 5) + 2, 5)
    '        Catch ex As Exception

    '        End Try

    '        Dim sfC As New StringFormat()
    '        sfC.Alignment = StringAlignment.Center
    '        Dim size As SizeF = GR.MeasureString(name, fnt, wd)
    '        GR.FillRectangle(Brushes.White, 0, CInt(ht - size.Height - 10), wd, CInt(size.Height + 5))
    '        'GR.DrawString(name, fnt, Brushes.Black, New RectangleF(2, ht - size.Height, wd - 4, size.Height), sfC)
    '    Catch ex As Exception

    '    End Try

    '    imgWithPrice = BMG
    '    Return BMG
    'End Function
    Private Function saveImage(ByVal theImage As Image) As Boolean

        'Dim dir1 As New DirectoryInfo(Form1.BtImgPah.Tag)
        'If dir1.Exists = False Then dir1.Create()
        Dim dir2 As New DirectoryInfo(Form1.BtImgPah.Tag & "\art" & cbctg.SelectedValue)
        If dir2.Exists = False Then dir2.Create()


        Dim str As String = imagePath
        If editMode = False Or imagePath.Contains("\") = False Then str = cbctg.SelectedValue & "\" & txtprdname.Text & ".jpg"

        'If str.Contains("\") Then
        '    Dim dir2 As New DirectoryInfo(Form1.BtImgPah.Tag & "\art" & cbctg.SelectedValue)
        '    If dir2.Exists = False Then dir2.Create()
        'End If


        Try
            str = str.Replace("/", "-")
            str = str.Replace("*", "-")

            Using bm As Bitmap = New Bitmap(theImage)
                bm.Save(Form1.BtImgPah.Tag & "\art" & str, bm.RawFormat)
            End Using


        Catch ex As Exception

            Try
                str = cbctg.SelectedValue & "\" & Now.Ticks & ".jpg"
                Using bm As Bitmap = New Bitmap(theImage)
                    bm.Save(Form1.BtImgPah.Tag & "\art" & str, bm.RawFormat)
                End Using


            Catch
                Return False
            End Try
        End Try

        If imagePath = str Then
            Return True
        Else
            imagePath = str
        End If


        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            params.Add("img", imagePath)
            Dim where As New Dictionary(Of String, Object)
            where.Add("arid", id)

            If a.UpdateRecord("Article", params, where) Then Return True
        End Using

        Return False
    End Function


    Private Sub btprd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btprd.Click
        If SaveProduct() Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
   
    End Sub

    Public Function SaveProduct() As Boolean
        If Validation() = False Then Return False

        '   If isImgChenged Then saveImage()
        Dim bprice As Double = txtbprice.text
        Dim sprice As Double = txtsprice.text
        Dim tva As Double = 20
        If txttva.text <> "" Then tva = txttva.text

        Dim price2 As Double = txtprice2.text
        Dim price3 As Double = txtprice3.text

        If Not IsNumeric(txtMarge.text) Then
            txtMarge.text = 0
        End If
        Dim price4 As Double = txtPrice4.text 'txtMarge.text
        If cid = 0 Then cid = cbctg.SelectedValue

        Dim params As New Dictionary(Of String, Object)
        params.Add("cid", cid)
        params.Add("name", txtprdname.text)
        params.Add("bprice", bprice)
        params.Add("sprice", sprice)
        params.Add("unite", txtunit.text)
        params.Add("codebar", txtcb.text)
        params.Add("tva", tva)
        params.Add("sp3", price2)
        params.Add("sp4", price3)
        params.Add("sp5", price4)
        params.Add("poid", TxtPoids.text)
        params.Add("depot", CInt(CBdp.SelectedValue))
        params.Add("mixte", CBool(cbIsMixte.Checked))
        params.Add("elements", txtMinStock.text)
        params.Add("isMixte", CBool(cbIsMixte.Checked))
        ' addddd
        Dim x As Integer = 0
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim where As New Dictionary(Of String, Object)

            If editMode Then
                where.Add("arid", id)
                x = a.UpdateRecord("Article", params, where)
            Else
                params.Add("img", imagePath)
                x = a.InsertRecord("Article", params)

                If CheckBox1.Checked Then
                    txtcb.text = ""
                    txtbprice.text = ""
                    TxtPoids.text = ""
                    txtsprice.text = ""
                    txtprice2.text = ""
                    txtprice3.text = ""
                    txtPrice4.text = ""
                    TxtPoids.text = ""
                    txtMinStock.text = ""

                    txtprdname.text = ""
                    txtunit.text = ""
                    PBprd.Tag = ""
                    PBprd.BackgroundImage = Nothing
                    x = 0

                End If
            End If

            'where.Clear()
            'params.Clear()
            'params.Add("val", "true")
            'where.Add("vkey LIKE ", "article%")
            'a.UpdateRecordSymbols("Value", params, where)
        End Using

        If x > 0 Then
            Return True
        Else
            Return False
        End If

    End Function


    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    Private Sub btprdimg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btprdimg.Click

        Dim savepic As New OpenFileDialog
        savepic.Filter = "*.jpg|*.jpg"
        If savepic.ShowDialog = Windows.Forms.DialogResult.OK Then

            isImgChenged = True

            'Dim pmg2 As New Bitmap(savepic.FileName)

            Dim W = CInt(Form1.txtlongerbt.Text) * 2
            Dim h = CInt(Form1.txtlargebt.Text) * 2
            Dim B = CInt(h / 10)


            Try
                Dim str As String = savepic.FileName

                Dim mypic As New System.IO.FileStream(str, IO.FileMode.Open)
                Dim _image As Image = Image.FromStream(mypic)
                mypic.Close()


                If saveImage(_image) Then
                    PBprd.BackgroundImage = _image
                End If

            Catch ex As Exception

            End Try

        End If

    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim cl As New ColorDialog
        If cl.ShowDialog = Windows.Forms.DialogResult.OK Then
            isImgChenged = True

            cr = cl.Color
            ImgPrd = Nothing

            If saveImage(ImgPrd) Then
                PBprd.BackgroundImage = ImgPrd
            End If
        End If
    End Sub

    Private Sub btgenir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btgenir.Click

        txtcb.text = RandomString()
    End Sub
    Function RandomString()
        Dim r As New Random
        '   Dim s As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz0123456789"
        ' Dim s As String = "0123456789abcdefghijkl0123456789mnopqrstuvwxyz0123456789"
        Dim s As String = "012345678901234567890123456789"

        Dim sb As New StringBuilder

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)

            For t As Integer = 0 To 5
                params.Clear()
                Dim cnt As Integer = r.Next(5, 9)
                For i As Integer = 1 To cnt
                    Dim idx As Integer = r.Next(0, s.Length)
                    sb.Append(s.Substring(idx, 1))
                Next


                Try
                    params.Add("codebar", sb.ToString())
                    Dim fid = c.SelectByScalar("Article", "arid", params)
                    If IsNumeric(fid) Then Exit For
                    If fid = 0 Then Exit For
                Catch ex As Exception
                    Exit For
                End Try
                ''''''''''''''''''''''''''''''''''
            Next
        End Using


        Return sb.ToString()
    End Function

    Private Sub btprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btprint.Click
        Try

            If txtcb.text = "" Then Exit Sub
            Dim cde As String = txtcb.text
            If cde.Length > 12 Then cde = cde.Substring(0, 12)
            'If cde.Length < 12 Then Exit Sub

            Dim CD As New BarCode2
            CD.CODE = cde
            CD.Article = txtprdname.Text
            ' CD.qte = txtsprice.text

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
    Private Sub txttva_TxtChanged() Handles txttva.TxtChanged, txtMinStock.TxtChanged, TxtPoids.TxtChanged, txtunit.TxtChanged, txtprdname.TxtChanged, txtNbr.TxtChanged
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

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            Dim tva As Double = 1.2
            If txttva.text <> "" Then tva = (100 + txttva.text) / 100

            txtPrice4.text = String.Format("{0:F}", CDbl(txtPrice4.text) * tva)
        Catch ex As Exception
        End Try
    End Sub
  
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        'If txtcb.text.Trim = "" Then Exit Sub

        Dim ls As New ListMultiCodes
        ls.Code = txtcb.text
        If ls.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtcb.text = ls.Code
        End If

    End Sub

    Private Sub FillForm()


        Dim params As New Dictionary(Of String, Object)
        params.Add("arid", id)
        ' added some items
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim dt As DataTable = a.SelectDataTable("Article", {"*"}, params)
            If dt.Rows.Count > 0 Then

                txtcb.text = StrValue(dt, "codebar", 0)
                txtprdname.Text = StrValue(dt, "name", 0)
                txtunit.Text = StrValue(dt, "unite", 0) 'dt.Rows(0).Item("")
                cid = IntValue(dt, "cid", 0)
                cbctg.SelectedValue = cid
                CBdp.SelectedValue = IntValue(dt, "depot", 0)
                txttva.text = DblValue(dt, "tva", 0)
                txtMinStock.text = StrValue(dt, "elements", 0)
                TxtPoids.text = DblValue(dt, "poid", 0)
                cbIsMixte.Checked = BoolValue(dt, "mixte", 0)

                txtbprice.text = DblValue(dt, "bprice", 0).ToString(Form1.frmDbl)
                txtsprice.text = DblValue(dt, "sprice", 0).ToString(Form1.frmDbl)
                txtprice2.text = DblValue(dt, "sp3", 0).ToString(Form1.frmDbl)
                txtprice3.text = DblValue(dt, "sp4", 0).ToString(Form1.frmDbl)
                txtPrice4.text = DblValue(dt, "sp5", 0).ToString(Form1.frmDbl)

                txtMarge.text = DblValue(dt, "sp5", 0).ToString(Form1.frmDbl)

                Try
                    imagePath = StrValue(dt, "img", 0)
                    Dim str As String = Form1.BtImgPah.Tag & "\art" & imagePath

                    Dim mypic As New System.IO.FileStream(str, IO.FileMode.Open)
                    Dim _image As Image = Image.FromStream(mypic)
                    mypic.Close()
                    PBprd.BackgroundImage = _image
                Catch ex As Exception

                End Try
            End If
        End Using
    End Sub
    Private Function Validation() As Boolean
        Try
            'validation
            ''empty field
            If txtprdname.Text.Trim = "" Then
                MsgBox("عذرا لا يمكن اتمام طلبكم.. المرجوا تعبئة الاسم", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                txtprdname.Focus()
                Return False
            End If
            If txtbprice.text.Trim = "" Then
                MsgBox("عذرا لا يمكن اتمام طلبكم.. المرجوا تعبئة ثمن الشراء", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                txtbprice.Focus()
                Return False
            End If
            If txtsprice.text.Trim = "" Then
                MsgBox("عذرا لا يمكن اتمام طلبكم.. المرجوا تعبئة ثمن البيع", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                txtsprice.Focus()
                Return False
            End If
            If txtunit.Text.Trim = "" Then
                'MsgBox("عذرا لا يمكن اتمام طلبكم.. المرجوا تعبئة الوحدة", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                'txtunit.Focus()
                txtunit.Text = "U"
                Return False
            End If

            If txtprice2.text.Trim = "" Then txtprice2.text = txtsprice.text
            If txtprice3.text.Trim = "" Then txtprice3.text = txtprice2.text
            If txtPrice4.text.Trim = "" Then txtPrice4.text = txtprice3.text

            If TxtPoids.text = "" Or Not IsNumeric(TxtPoids.text) Then TxtPoids.text = 0

            ''check the pricess
            If Not IsNumeric(txtbprice.text) Then
                txtbprice.text = txtbprice.text.Replace(".", ",")
                If Not IsNumeric(txtbprice.text) Then
                    MsgBox("عذرا لا يمكن اتمام طلبكم.. ثمن الشراء يجب أن يكون عدد", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                    txtbprice.Focus()
                    Return False
                End If

            End If
            If Not IsNumeric(txtsprice.text) Then
                txtsprice.text = txtsprice.text.Replace(".", ",")
                If Not IsNumeric(txtsprice.text) Then
                    MsgBox("عذرا لا يمكن اتمام طلبكم.. ثمن البيع يجب أن يكون عدد", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                    txtsprice.Focus()
                    Return False
                End If
            End If
            If Decimal.Parse(txtbprice.text) > Decimal.Parse(txtsprice.text) Then
                MsgBox("عذرا لا يمكن اتمام طلبكم.. ثمن البيع يجب أن يكون أكبر من ثمن الشراء", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                txtbprice.Focus()
                Return False
            End If


            If Form1.cbCodeDouble.Checked Then
                ''''''''''''''''''''''''''''''''''''
                Dim ls = txtcb.text.Trim.Split("-")
                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)


                    Dim params As New Dictionary(Of String, Object)
                    Dim artdt As DataTable

                    '''''''''''''''''''
                     
                      For i As Integer = 0 To ls.Length - 1

                        If ls(i).Length <= 5 Then Continue For
                        '''''''''''''''''''

                        params.Clear()
                        params.Add("codebar LIKE ", "%" & ls(i) & "%")
                        artdt = a.SelectDataTableSymbols("article", {"*"}, params)

                        If artdt.Rows.Count > 0 Then
                            For t As Integer = 0 To artdt.Rows.Count - 1
                                If artdt.Rows(t).Item(0) = txtprdname.Tag Then Continue For
                                Dim str As String = "عذرا لا يمكن اتمام طلبكم.. المرجوا تعبئة رمز جديد"
                                str &= vbNewLine
                                str &= ls(i) & "  |  " & artdt.Rows(t).Item("name") & " [" & artdt.Rows(t).Item(0) & "]"
                                str &= vbNewLine
                                str &= ls(i) & "  |  " & txtprdname.text

                                MsgBox(str, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                                txtcb.Focus()
                                Return False
                            Next
                        End If
                    Next
                End Using
                ''''''''''''''''''''''''''''''''''''
            End If

            Return True
        Catch ex As Exception
            MsgBox("عذرا لا يمكن اتمام طلبكم.. المرحوا التأكد من صحة المعطيات ", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
            Return False
        End Try

    End Function

    Dim m = 0
    Dim table As New DataTable
    Private gl As New LbGlobalElement
    Public article As String
    Public qte As String
    Private K_nmPage As Integer = 0


    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click

        If SaveProduct() = False Then Exit Sub

        Try
            ' Create four typed columns in the DataTable.
            table.Columns.Add("Name", GetType(String))
            table.Columns.Add("Prix(G)", GetType(String))
            table.Columns.Add("Prix(P)", GetType(String))
            table.Columns.Add("Prix", GetType(String))
            table.Columns.Add("Ref", GetType(String))
            table.Columns.Add("Code", GetType(String))
            table.Columns.Add("Image_Article", GetType(String))

            article = txtprdname.Text
            qte = txtsprice.text
            Dim cde As String = txtcb.text

            If cde.ToString.Contains("|") Then

                Dim str = cde.ToString.Split("|")

                For r As Integer = 0 To str.Length - 1
                    If IsNumeric(str(r)) Then
                        cde = str(r)
                        Exit For
                    End If
                Next
            End If

            If cde.Length > 12 Then cde = cde.Substring(0, 12)

            Dim bigPrice As Integer = 0
            Dim smallPrice As Double = 0
            SplitDecimal(qte, bigPrice, smallPrice)
            Dim SM As Integer = CInt(smallPrice * 100)

            table.Rows.Add(article, bigPrice, "." & String.Format("{0:00}", SM), qte,
                            cde, cde, imagePath)
        Catch ex As Exception
        End Try

        K_nmPage = 0
        LoadXmlEtqs()

        Dim ps As New Printing.PaperSize(gl.P_name, gl.W_Page, gl.h_Page)
        ps.PaperName = gl.p_Kind
        PrintDocument1.DefaultPageSettings.PaperSize = ps
        PrintDocument1.DefaultPageSettings.Landscape = gl.is_Landscape

        PrintDocument1.PrinterSettings.PrinterName = gl.Printer_name
        Dim nbr As Integer = 1

        If IsNumeric(txtNbr.text) Then nbr = CInt(txtNbr.text)

        For i As Integer = 0 To nbr - 1
            m = 0
            PrintDocument1.Print()
        Next


        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Public Sub LoadXmlEtqs()
        Try

            Dim st = "\EtqDsn\Etq-Article.dat"
            If cbM.Text = 2 Then st = "\EtqDsn\Etq-Article2.dat"
            If cbM.Text = 3 Then st = "\EtqDsn\Etq-Article3.dat"

            gl = ReadFromXmlFile(Of LbGlobalElement)(Form1.ImgPah & st)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim _x As Integer = 0
        Dim _y As Integer = gl.Start_Y
        Dim _img As Image = Nothing
        '   Dim m = 0
        If gl.is_Repeated = False Then

            Dim NBPAGE = table.Rows.Count / (gl.Nbr_H * gl.Nbr_W)

            If NBPAGE > CInt(NBPAGE) Then
                NBPAGE = CInt(NBPAGE) + 1
            Else
                NBPAGE = CInt(NBPAGE)
            End If

            For k = K_nmPage To CInt(NBPAGE)
                For i As Integer = 0 To gl.Nbr_H - 1
                    _x = gl.Start_X
                    If i > 0 Then _y += gl.Sp_H
                    For t As Integer = 0 To gl.Nbr_W - 1

                        If m >= table.Rows.Count Then Exit Sub
                        PrintLabel(m, _x, _y, e)
                        _x += gl.W_El  '.Width
                        _x += gl.Sp_W
                        m += 1
                    Next
                    _y += gl.H_El
                Next
                'If k < CInt(NBPAGE) Then
                '    k += 1
                '    e.HasMorePages = True
                '    Return
                'End If
            Next
        Else
            While m < table.Rows.Count


                For i As Integer = 0 To gl.Nbr_H - 1
                    _x = gl.Start_X
                    If i > 0 Then _y += gl.Sp_H
                    For t As Integer = 0 To gl.Nbr_W - 1

                        PrintLabel(m, _x, _y, e)
                        _x += gl.W_El
                        _x += gl.Sp_W
                    Next
                    _y += gl.H_El
                Next

                'e.HasMorePages = True
                'm += 1
                'Return
            End While

        End If
        K_nmPage = 0
        m = 0
    End Sub
    Private alphabet39 As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%*"
    Private coded39Char As String() = {"000110100", "100100001", "001100001", "101100000", "000110001", "100110000", "001110000", "000100101", "100100100", "001100100", "100001001", "001001001", "101001000", "000011001", "100011000", "001011000", "000001101", "100001100", "001001100", "000011100", "100000011", "001000011", "101000010", "000010011", "100010010", "001010010", "000000111", "100000110", "001000110", "000010110", "110000001", "011000001", "111000000", "010010001", "110010000", "011010000", "010000101", "110000100", "011000100", "010101000", "010100010", "010001010", "000101010", "010010100"}

    Private Sub PrintLabel(ByRef _i As Integer, ByRef xx As Integer, ByRef yy As Integer, ByRef e As System.Drawing.Printing.PrintPageEventArgs)

        Dim pen As New Pen(Brushes.Black, 1.0F)
        Dim sf As New StringFormat()

        'gl.W_El, gl.H_El
        e.Graphics.DrawRectangle(Pens.WhiteSmoke, 0, 0, gl.W_El - 2, gl.H_El - 2)

        For Each a As LbElement In gl.elements
            'Create a brush
            Dim top_x = a.x + xx
            Dim top_y = a.y + yy

            Dim fn As Font
            If a.isBold Then
                fn = New Font(a.fName, a.fSize, FontStyle.Bold)
            Else
                fn = New Font(a.fName, a.fSize)
            End If

            If a.hasBloc Then
                e.Graphics.DrawRectangle(pen, top_x, top_y, a.width, a.height)
                Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                e.Graphics.FillRectangle(_br, top_x, top_y, a.width, a.height)

                top_x += 5
                top_y += 3
            End If

            Dim str As String = CStr(a.designation)

            If a.field.StartsWith("*") Then

            ElseIf a.field.StartsWith("FOR") Then

                If str = "R" Then

                    Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                    e.Graphics.FillRectangle(_br, top_x, top_y, a.width, a.height)
                ElseIf str = "G" Then
                    DrawRoundedRectangle(e.Graphics, top_x, top_y, a.width, a.height, a.fSize)
                ElseIf str = "C" Then
                    Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                    e.Graphics.FillEllipse(_br, top_x, top_y, a.width, a.height)
                ElseIf str = "S" Then

                    Dim ls = a.points.Split("|")

                    Dim myPoints(ls.Length - 1) As Point
                    For n As Integer = 0 To ls.Length - 1
                        Try
                            myPoints(n) = New Point(ls(n).Split("*")(0) + xx, ls(n).Split("*")(1) + yy)
                        Catch ex As Exception
                        End Try
                    Next
                    Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                    e.Graphics.FillPolygon(_br, myPoints)
                End If

                str = ""

            ElseIf a.field.StartsWith("IMAGE_PATH") Then
                Try
                    str = ""
                    Dim fullPath As String = a.designation
                    e.Graphics.DrawImage(Image.FromFile(fullPath), top_x, top_y, a.width, a.height)
                Catch ex As Exception
                End Try
            ElseIf a.field.StartsWith("Image_Article") Then
                Try
                    str = ""
                    Dim fullPath As String = Path.Combine(Form1.ImgPah, table.Rows(_i).Item(a.field))
                    e.Graphics.DrawImage(Image.FromFile(fullPath), top_x, top_y, a.width, a.height)
                Catch ex As Exception
                End Try
            ElseIf a.field.StartsWith("//") Then  '' codebar G.FillRectangle(Brushes.Gray, top_x, top_y, a.width, a.height)

                Dim code = table.Rows(_i).Item("Code").ToUpper()
                Dim _str As String = "*"c & code & "*"c
                Dim strLength As Integer = _str.Length
                Dim intercharacterGap As String = "0"

                For i As Integer = 0 To code.Length - 1

                    If alphabet39.IndexOf(code(i)) = -1 OrElse code(i) = "*"c Then
                        e.Graphics.DrawString("INVALID BAR CODE TEXT", Font, Brushes.Red, 10, 10)
                        Exit Sub
                    End If
                Next

                Dim encodedString As String = ""

                For i As Integer = 0 To strLength - 1
                    If i > 0 Then encodedString += intercharacterGap
                    encodedString += coded39Char(alphabet39.IndexOf(_str(i)))
                Next

                Dim encodedStringLength As Integer = encodedString.Length
                Dim widthOfBarCodeString As Integer = 0
                Dim wideToNarrowRatio As Double = 3

                If a.Alignement <> 1 Then

                    For i As Integer = 0 To encodedStringLength - 1

                        If encodedString(i) = "1"c Then
                            widthOfBarCodeString += CInt((wideToNarrowRatio))
                        Else
                            widthOfBarCodeString += 1
                        End If
                    Next
                End If


                Dim wid As Integer = 0
                For i As Integer = 0 To encodedStringLength - 1

                    If encodedString(i) = "1"c Then
                        wid = CInt((wideToNarrowRatio))
                    Else
                        wid = 1
                    End If

                    Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                    e.Graphics.FillRectangle(If(i Mod 2 = 0, _br, Brushes.White), top_x, top_y, wid, a.height)
                    top_x += wid
                Next

            Else

                str &= table.Rows(_i).Item(a.field)
            End If

            Dim br = New SolidBrush(Color.FromArgb(a.forColor))
            sf.Alignment = a.Alignement
            If a.isVertical Then
                sf.FormatFlags = StringFormatFlags.DirectionVertical
            Else
                sf.FormatFlags = StringFormatFlags.DisplayFormatControl
            End If

            e.Graphics.DrawString(str, fn, br, New RectangleF(top_x, top_y, a.width, a.height), sf)
        Next

    End Sub

    Private Sub txtbprice_TxtChanged() Handles txtbprice.TxtChanged
        'Try
        '    If txtMarge.text = "" Then txtMarge.text = 0
        '    If txtbprice.TXT.Focused = False Then Exit Sub

        '    If txtbprice.text <> "" Then
        '        txtsprice.text = String.Format("{0:n}", CDec(((txtbprice.text * txtMarge.text) / 100) + txtbprice.text))
        '    End If

        'Catch ex As Exception

        'End Try
        Try
            txtMarge.text = String.Format("{0:n}", CDec((txtsprice.text - txtbprice.text) * 100 / txtbprice.text))
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtMarge_TxtChanged() Handles txtMarge.TxtChanged
        'Try
        '    If txtMarge.text = "" Then Exit Sub
        '    If txtMarge.TXT.Focused = False Then Exit Sub

        '    If txtbprice.text <> "" Then
        '        txtsprice.text = String.Format("{0:n}", CDec(((txtbprice.text * txtMarge.text) / 100) + txtbprice.text))
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub txSpRICE_TxtChanged() Handles txtsprice.TxtChanged
        'Try
        '    If txtsprice.text = "" Then Exit Sub
        '    If txtsprice.TXT.Focused = False Then Exit Sub

        '    If txtbprice.text <> "" Then
        '        txtMarge.text = String.Format("{0:n}", CDec((txtsprice.text - txtbprice.text) * 100 / txtbprice.text))
        '    End If
        'Catch ex As Exception

        'End Try
        Try
            txtMarge.text = String.Format("{0:n}", CDec((txtsprice.text - txtbprice.text) * 100 / txtbprice.text))
        Catch ex As Exception

        End Try
    End Sub
End Class

