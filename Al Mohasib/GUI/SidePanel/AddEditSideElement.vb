Imports System.IO
Imports System.Drawing.Imaging

Public Class AddEditSideElement

    Public element As SideElement

    Dim _isart As Boolean
    Dim TbName As String = "Article"
    Dim str_id As String = "arid"
    Dim cr As Color = Color.WhiteSmoke
    Dim _imgPrd As Image


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
    Public Function Drawimg() As Bitmap

        Dim ht As Integer = CInt(Form1.txtlargebt.Text)
        Dim wd As Integer = CInt(Form1.txtlongerbt.Text)
        'create the bitmap
        Dim BMG As New Bitmap(wd, ht, Imaging.PixelFormat.Format24bppRgb)
        'ceate the graphic
        Dim GR As Graphics = Graphics.FromImage(BMG)

        GR.Clear(Color.White)

        Try
            If IsNothing(ImgPrd) Then ImgPrd = Nothing
            GR.DrawImage(ImgPrd, 0, 0, wd, ht)
        Catch ex As Exception
        End Try

        Return BMG
    End Function
    Private Sub saveImage()
        Dim dir1 As New DirectoryInfo(Form1.BtImgPah.Tag & "\PanelFx")
        If dir1.Exists = False Then dir1.Create()

        Dim str As String = element.id & element.elementName
        Try

            str = str.Replace("/", "-")
            str = str.Replace("*", "-")
            str = str.Replace(":", "-")
            str = str.Replace("|", "-")

            Using bm As Bitmap = pb.BackgroundImage.Clone()
                bm.Save(Form1.BtImgPah.Tag & "\PanelFx\" & str & ".jpg", bm.RawFormat)
            End Using

        Catch ex As Exception
            Try
                str = element.id & "ID" & Now.Ticks
                Using bm As Bitmap = pb.BackgroundImage.Clone()
                    bm.Save(Form1.BtImgPah.Tag & "\PanelFx\" & str & ".jpg", bm.RawFormat)
                End Using
            Catch exa As Exception
            End Try
        End Try
        element.img = Form1.BtImgPah.Tag & "\PanelFx\" & str & ".jpg"
    End Sub
    Public Property isArticle As Boolean
        Get
            Return _isart
        End Get
        Set(ByVal value As Boolean)
            _isart = value

            If value Then
                btArt.BackColor = Color.Green
                btCat.BackColor = Color.Black
                TbName = "Article"
                str_id = "arid"
            Else
                btArt.BackColor = Color.Black
                btCat.BackColor = Color.Green
                TbName = "Category"
                str_id = "cid"
            End If
        End Set
    End Property

    Private Sub btArt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btArt.Click
        isArticle = True
    End Sub

    Private Sub btCat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCat.Click
        isArticle = False

        Try
            Dim artta As New ALMohassinDBDataSetTableAdapters.CategoryTableAdapter
            Dim artdt As DataTable = artta.GetData()

            '''''''''''''''''''

            If artdt.Rows.Count = 0 Then
            Else

                For i As Integer = 0 To artdt.Rows.Count - 1
                    dg.Rows.Add(artdt.Rows(i).Item(0), StrValue(artdt, "name", i), "", StrValue(artdt, "img", i))
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim cl As New ColorDialog
        If cl.ShowDialog = Windows.Forms.DialogResult.OK Then
            cr = cl.Color
            ImgPrd = Nothing
            pb.BackgroundImage = Drawimg()
            isImgChanged = True
        End If
    End Sub
    Private Sub btprdimg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btprdimg.Click

        Dim savepic As New OpenFileDialog
        savepic.Filter = "*.jpg|*.jpg"
        If savepic.ShowDialog = Windows.Forms.DialogResult.OK Then

            'Dim pmg2 As New Bitmap(savepic.FileName)

            Dim W = CInt(Form1.txtlongerbt.Text) * 2
            Dim h = CInt(Form1.txtlargebt.Text) * 2
            Dim B = CInt(h / 10)


            Using bm As Bitmap = New Bitmap(savepic.FileName)
                Dim ms As New MemoryStream()
                translate(bm, 15, 20, 30, 1)
                bm.Save(ms, ImageFormat.Bmp)
                ImgPrd = Image.FromStream(ms)
            End Using

            pb.BackgroundImage = Drawimg()
            isImgChanged = True
        End If
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        getPrdImg()
        isImgChanged = True
    End Sub
    Private Sub getPrdImg()
        Try
            If dg.SelectedRows.Count = 0 Then Exit Sub

            Dim path As String = dg.SelectedRows(0).Cells(3).Value.ToString

            If path = "" Or path = "No Image" Then
                pb.BackgroundImage = Nothing
            Else


                Dim str As String = Form1.BtImgPah.Tag & "\art" & path

                Using bm As Bitmap = New Bitmap(str)
                    Dim ms As New MemoryStream()
                    bm.Save(ms, ImageFormat.Bmp)
                    ImgPrd = Image.FromStream(ms)
                End Using
            End If

            pb.BackgroundImage = Drawimg()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dg_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellClick
        If dg.SelectedRows.Count = 0 Then Exit Sub

        getPrdImg()
        element.id = dg.SelectedRows(0).Cells(0).Value
        txt.text = dg.SelectedRows(0).Cells(1).Value.ToString


        If txtNm.text.Trim = "" Then
            element.elementName = txt.text
        Else
            element.elementName = txtNm.text
        End If

    End Sub

    Private Sub txt_TxtChanged() Handles txt.TxtChanged
        If isArticle = False Then Exit Sub

        dg.Rows.Clear()
        If txt.text.Trim = "" Then Exit Sub

        Try
            Dim artta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
            Dim artdt2 As DataTable
            Dim artdt As DataTable

            '''''''''''''''''''


            artdt = artta.GetDatalikecodebar("%" & txt.text & "%")
            artdt2 = artta.GetDatalikename("%" & txt.text & "%")
            artdt.Merge(artdt2, False)

            If artdt.Rows.Count = 0 Then
            Else

                For i As Integer = 0 To artdt.Rows.Count - 1
                    dg.Rows.Add(artdt.Rows(i).Item(0), StrValue(artdt, "name", i), StrValue(artdt, "sprice", i), StrValue(artdt, "img", i))
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Dim isImgChanged As Boolean = False
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If element.id = 0 Then Exit Sub


        If txtNm.text.Trim = "" Then
            element.elementName = txt.text
        Else
            element.elementName = txtNm.text
        End If

        element.isArticle = isArticle

        If isImgChanged Then saveImage()





        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btColor.Click
        Dim cl As New ColorDialog
        If cl.ShowDialog = Windows.Forms.DialogResult.OK Then
            btColor.BackColor = cl.Color
            element.color = cl.Color.ToArgb
        End If
    End Sub

    Private Sub AddEditSideElement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If element.id > 0 Then
            isArticle = element.isArticle
            btColor.BackColor = Color.FromArgb(element.color)

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)
                params.Add(str_id, element.id)
                Dim nm As String = c.SelectByScalar(TbName, "name", params)

                If nm = element.elementName Then
                    txt.text = element.elementName
                Else
                    txt.text = nm
                    txtNm.text = element.elementName
                End If
            End Using


            Try
                pb.BackgroundImage = Image.FromFile(element.img)
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class