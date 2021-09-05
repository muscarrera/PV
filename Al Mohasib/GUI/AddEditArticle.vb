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
        Me.DepotTableAdapter.Fill(Me.ALMohassinDBDataSet.Depot)
        Me.CategoryTableAdapter.Fill(Me.ALMohassinDBDataSet.Category)

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

        If Validation() = False Then Exit Sub

        '   If isImgChenged Then saveImage()


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
        If editMode = False Then
            ''check the name

            Try
                Dim ta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
                ta.InsertQuery(cid, txtprdname.Text, imagePath, bprice, sprice, txtunit.Text, txtcb.text, "0", tva,
                               price2, price3, price4, TxtPoids.text, CInt(CBdp.SelectedValue), CBool(cbIsMixte.Checked), txtMinStock.text)
                ta.Fill(ALMohassinDBDataSet.Article)
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


        Else


            Try

                Dim ta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
                ta.UpdateQuery(cid, txtprdname.Text, bprice, sprice, txtunit.Text, tva,
                               price2, price3, price4, TxtPoids.text, txtcb.text, CInt(CBdp.SelectedValue),
                                cbIsMixte.Checked, txtMinStock.text, imagePath, id)
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
        Dim s As String = "0123456789abcdefghijkl0123456789mnopqrstuvwxyz0123456789"

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

   
    Private Sub txtsprice_TxtChanged() Handles txtsprice.TxtChanged
        '     PBprd.BackgroundImage = Drawimg(txtprdname.Text, txtsprice.text)
    End Sub
    Private Sub txtprdname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprdname.TextChanged
        '   PBprd.BackgroundImage = Drawimg(txtprdname.Text, txtsprice.text)
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
                MsgBox("عذرا لا يمكن اتمام طلبكم.. المرجوا تعبئة الوحدة", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                txtunit.Focus()
                Return False
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

                Dim artta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
                Dim artdt As DataTable
                For i As Integer = 0 To ls.Length - 1

                    If ls(i).Length <= 5 Then Continue For
                    '''''''''''''''''''

                    artdt = artta.GetDatalikecodebar("%" & ls(i) & "%")

                    If artdt.Rows.Count > 0 Then
                        For t As Integer = 0 To artdt.Rows.Count - 1
                            If artdt.Rows(t).Item(0) = txtprdname.Tag Then Continue For
                            Dim str As String = "عذرا لا يمكن اتمام طلبكم.. المرجوا تعبئة رمز جديد"
                            str &= vbNewLine
                            str &= ls(i) & "  |  " & artdt.Rows(t).Item("name") & " [" & artdt.Rows(t).Item(0) & "]"
                            str &= vbNewLine
                            str &= ls(i) & "  |  " & txtprdname.Text

                            MsgBox(str, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                            txtcb.Focus()
                            Return False
                        Next
                    End If
                Next
                ''''''''''''''''''''''''''''''''''''
            End If

            Return True
        Catch ex As Exception
            MsgBox("عذرا لا يمكن اتمام طلبكم.. المرحوا التأكد من صحة المعطيات ", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
            Return False
        End Try

    End Function
End Class

