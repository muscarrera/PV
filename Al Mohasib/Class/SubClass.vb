Imports System.IO
Imports System.Xml

Public Class SubClass
    Implements IDisposable

    'Members
    Dim isSell As Integer

    'Construction
    Public Sub New(ByRef fl As Integer)
        isSell = fl
    End Sub
    Public Sub New()

    End Sub
    'Subs

    'sub for articles
    Public Sub FillGroupes()
        'Exit Sub

        If Form1.txtEnsGrp.Text = "" Then Exit Sub

        Dim cl As String() = Form1.txtEnsGrp.Text.Split("-")

        Dim ctgta As New ALMohassinDBDataSetTableAdapters.CategoryTableAdapter
        Dim ctgdt = ctgta.GetData()
        Form1.FlowLayoutPanel1.Controls.Clear()
        Dim rnd As New Random

        For t As Integer = 0 To ctgdt.Rows.Count - 1

            Dim cid As Integer = 0

            For k As Integer = 0 To cl.Length - 1
                If cl(k) = ctgdt.Rows(t).Item(0) Then
                    cid = CInt(ctgdt.Rows(t).Item(0))
                    Exit For
                End If
            Next

            If cid = 0 Then Continue For

            Dim P As New Panel
            Dim random_Color1, random_Color2 As New Color
            random_Color1 = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255))
            random_Color2 = Color.FromArgb(33, random_Color1) 'Color.FromArgb(rnd.Next(0, 150), rnd.Next(0, 150), rnd.Next(0, 150), 10)

            Dim cr As Color = Color.WhiteSmoke
            If (t Mod 2) = 0 Then cr = Color.LightGray

            P.BackColor = cr

            P.Width = Form1.txtlongerbt.Text
            P.Height = Form1.txtlargebt.Text * 13
            P.Visible = True
            'P.Dock = DockStyle.Right
            'P.BringToFront()
            Form1.FlowLayoutPanel1.Controls.Add(P)

            Dim artta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
            Dim artdt = artta.GetDataBycid(cid)

            If artdt.Rows.Count = 0 Then
                Dim lb As New Label

                lb.ForeColor = Color.DarkGray
                lb.Text = "لا يوجد اي سجل"
                P.Controls.Add(lb)
            Else

                'artdt.DefaultView.Sort = "sprice DESC"
                'artdt = artdt.DefaultView.ToTable

                For i As Integer = 0 To artdt.Rows.Count - 1

                    If (t Mod 2) = 0 Then
                        cr = random_Color1
                        If (i Mod 2) = 0 Then cr = random_Color2
                    Else
                        cr = random_Color2
                        If (i Mod 2) = 0 Then cr = random_Color1
                    End If

                    Dim bt As New Button

                    bt.Visible = True
                    bt.FlatStyle = FlatStyle.Flat
                    bt.BackColor = Color.LightSeaGreen
                    Dim NM As String = String.Format("{0:n}", CDec(artdt.Rows(i).Item("sprice").ToString))
                    bt.Text = "[" & NM & "] - " & artdt.Rows(i).Item("name").ToString
                    bt.Name = "art" & i
                    bt.Tag = artdt.Rows(i)
                    bt.BackColor = cr
                    bt.TextAlign = ContentAlignment.BottomCenter
                    bt.Font = New Font("Arial", CInt(Form1.txtfntsize.Text), FontStyle.Bold)
                    bt.Height = Form1.txtlargebt.Text

                    If Form1.cbTsImg.Checked Then
                        Try
                            If artdt.Rows(i).Item("img").ToString = "No Image" Or artdt.Rows(i).Item("img").ToString = "" Then

                            Else
                                Dim str As String = Form1.BtImgPah.Tag & "\art" & artdt.Rows(i).Item("img").ToString
                                bt.BackgroundImage = Image.FromFile(str)
                                bt.BackgroundImageLayout = ImageLayout.Stretch
                            End If
                        Catch ex As Exception

                        End Try
                    End If

                    P.Controls.Add(bt)
                    bt.Dock = DockStyle.Top
                    AddHandler bt.Click, AddressOf art_click

                    If i = 33 Then Exit For
                Next
            End If
        Next

        If Form1.chbcb.Checked Then
            Form1.txtSearchCode.Text = ""
            Form1.txtSearchCode.Focus()
        Else
            Form1.txtSearch.Text = ""
            Form1.txtSearch.Focus()
        End If
        Form1.RPl.CP.Value = 0
    End Sub

    Public Sub FillGroupes(ByVal F As Boolean)
        Dim ctgta As New ALMohassinDBDataSetTableAdapters.CategoryTableAdapter
        Dim ctgdt = ctgta.GetDataBycat(0)
        Form1.FlowLayoutPanel1.Controls.Clear()
        If F Then Form1.FLPStock.Controls.Clear()

        For i As Integer = 0 To ctgdt.Rows.Count - 1
            Dim bt As New Button

            bt.BackColor = Color.LightGoldenrodYellow
            bt.Text = ctgdt.Rows(i).Item("name").ToString
            bt.Name = "ctg" & i
            bt.Tag = ctgdt.Rows(i).Item("cid")

            bt.TextAlign = ContentAlignment.BottomCenter
            Try
                If ctgdt.Rows(i).Item("img").ToString = "No Image" Or ctgdt.Rows(i).Item("img").ToString = "" Then
                    bt.BackColor = Color.Moccasin
                Else
                    Dim str As String = Form1.BtImgPah.Tag & "\cat" & ctgdt.Rows(i).Item("img").ToString
                    If Form1.cbImgPrice.Checked Then
                        str = Form1.BtImgPah.Tag & "\P-cat" & ctgdt.Rows(i).Item("img").ToString
                        bt.Text = ""
                    End If

                    bt.BackgroundImage = Image.FromFile(str)
                End If
                bt.BackgroundImageLayout = ImageLayout.Stretch
            Catch ex As Exception
                bt.Text = ctgdt.Rows(i).Item("name").ToString
            End Try
            'bt.Width = 125
            'bt.Height = 90
            bt.Width = Form1.txtlongerbt.Text
            bt.Height = Form1.txtlargebt.Text

            AddHandler bt.Click, AddressOf ctg_click

            Form1.FlowLayoutPanel1.Controls.Add(bt)

        Next

        'Fill stock panel
        If F Then FillGrStock(ctgdt)

        If Form1.chbcb.Checked Then
            Form1.txtSearchCode.Text = ""
            Form1.txtSearchCode.Focus()
        Else
            Form1.txtSearch.Text = ""
            Form1.txtSearch.Focus()
        End If
        Form1.RPl.CP.Value = 0
    End Sub
    Public Sub FillGroupesByCat(ByVal c As Integer)
        Dim ctgta As New ALMohassinDBDataSetTableAdapters.CategoryTableAdapter
        Dim ctgdt = ctgta.GetDataBycat(c)

        For i As Integer = 0 To ctgdt.Rows.Count - 1
            Dim bt As New Button

            bt.BackColor = Color.LightGoldenrodYellow
            bt.Text = ctgdt.Rows(i).Item("name").ToString
            bt.Name = "ctg" & i
            bt.Tag = ctgdt.Rows(i).Item("cid")

            bt.TextAlign = ContentAlignment.BottomCenter
            Try
                If ctgdt.Rows(i).Item("img").ToString = "No Image" Or ctgdt.Rows(i).Item("img").ToString = "" Then
                    bt.BackColor = Color.Moccasin
                Else
                    Dim str As String = Form1.BtImgPah.Tag & "\cat" & ctgdt.Rows(i).Item("img").ToString
                    If Form1.cbImgPrice.Checked Then
                        str = Form1.BtImgPah.Tag & "\P-cat" & ctgdt.Rows(i).Item("img").ToString
                        bt.Text = ""
                    End If

                    bt.BackgroundImage = Image.FromFile(str)
                End If
                bt.BackgroundImageLayout = ImageLayout.Stretch
            Catch ex As Exception
                bt.Text = ctgdt.Rows(i).Item("name").ToString
            End Try
            'bt.Width = 125
            'bt.Height = 90
            bt.Width = Form1.txtlongerbt.Text
            bt.Height = Form1.txtlargebt.Text

            AddHandler bt.Click, AddressOf ctg_click

            Form1.FlowLayoutPanel1.Controls.Add(bt)

        Next

        If Form1.chbcb.Checked Then
            Form1.txtSearchCode.Text = ""
            Form1.txtSearchCode.Focus()
        Else
            Form1.txtSearch.Text = ""
            Form1.txtSearch.Focus()
        End If
        Form1.RPl.CP.Value = 0
    End Sub

    Public Sub FillGrStock(ByVal ctgdt As DataTable)
        For i As Integer = 0 To ctgdt.Rows.Count - 1
            Dim bt As New Button

            bt.BackColor = Color.LightGoldenrodYellow
            bt.Text = ctgdt.Rows(i).Item("name").ToString
            bt.Name = "ctg" & i
            bt.Tag = ctgdt.Rows(i).Item("cid")

            bt.TextAlign = ContentAlignment.BottomCenter
            Try
                If ctgdt.Rows(i).Item("img").ToString = "No Image" Or ctgdt.Rows(i).Item("img").ToString = "" Then
                    bt.BackColor = Color.Moccasin
                Else
                    Dim str As String = Form1.BtImgPah.Tag & "\cat" & ctgdt.Rows(i).Item("img").ToString
                    If Form1.cbImgPrice.Checked Then
                        str = Form1.BtImgPah.Tag & "\P-cat" & ctgdt.Rows(i).Item("img").ToString
                        bt.Text = ""
                    End If

                    bt.BackgroundImage = Image.FromFile(str)
                End If
                bt.BackgroundImageLayout = ImageLayout.Stretch
            Catch ex As Exception
                bt.Text = ctgdt.Rows(i).Item("name").ToString
            End Try
            bt.Width = 125
            bt.Height = 90

            AddHandler bt.Click, AddressOf ctg_stock_click
            Form1.FLPStock.Controls.Add(bt)
        Next
    End Sub
    Public Sub SearchForArticles(ByRef txt As TextBox, ByVal cid As Integer)

        If txt.Text.Trim = "" Then
            Form1.txtSearch.Text = ""
            Form1.txtSearchCode.Text = ""

            If Form1.chbcb.Checked Then
                Form1.txtSearchCode.Focus()
            Else
                Form1.txtSearch.Focus()
            End If

            Exit Sub
        End If

        Form1.FlowLayoutPanel1.Controls.Clear()
        Try
            Dim artta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
            Dim artdt2 As DataTable
            Dim artdt As DataTable

            '''''''''''''''''''

            If Form1.cbsearch.Text = "الاسم" Then
                artdt = artta.GetDatalikename("%" & txt.Text & "%")

            ElseIf Form1.cbsearch.Text = "الرمز" Then
                artdt = artta.GetDatalikecodebar(txt.Text & "%")

            ElseIf Form1.cbsearch.Text = "التصنيف" Then
                artdt = artta.GetDataBycidlikeCodeBar(txt.Text & "%", cid)
                artdt2 = artta.GetDataBycidlikename("%" & txt.Text & "%", cid)
                artdt.Merge(artdt2, False)
            Else
                artdt = artta.GetDatalikecodebar("%" & txt.Text & "%")
                artdt2 = artta.GetDatalikename("%" & txt.Text & "%")
                artdt.Merge(artdt2, False)
            End If

            If artdt.Rows.Count = 0 Then
                Dim lb As New Label

                lb.ForeColor = Color.DarkGray
                lb.Text = "لا يوجد اي سجل"
                Form1.FlowLayoutPanel1.Controls.Add(lb)

            Else
                For i As Integer = 0 To artdt.Rows.Count - 1

                    Dim bt As New Button

                    bt.Visible = True
                    bt.BackColor = Color.LightSeaGreen
                    bt.Text = artdt.Rows(i).Item("name").ToString
                    bt.Name = "art" & i
                    bt.Tag = artdt.Rows(i)
                    bt.TextAlign = ContentAlignment.BottomCenter
                    Try
                        If artdt.Rows(i).Item("img").ToString = "No Image" Or artdt.Rows(i).Item("img").ToString = "" Then

                        Else
                            Dim str As String = Form1.BtImgPah.Tag & "\art" & artdt.Rows(i).Item("img").ToString
                            If Form1.cbImgPrice.Checked Then
                                str = Form1.BtImgPah.Tag & "\P-art" & artdt.Rows(i).Item("img").ToString
                                bt.TextAlign = ContentAlignment.BottomCenter
                                bt.Font = New Font("Arial", 11, FontStyle.Bold)
                            End If

                            bt.BackgroundImage = Image.FromFile(str)
                        End If
                        bt.BackgroundImageLayout = ImageLayout.Stretch
                        bt.ImageAlign = ContentAlignment.BottomCenter
                    Catch ex As Exception

                    End Try
                    bt.Width = Form1.txtlongerbt.Text
                    bt.Height = Form1.txtlargebt.Text
                    Form1.FlowLayoutPanel1.Controls.Add(bt)
                    'AddHandler bt.Click, AddressOf art_click

                    If i = Form1.indexLastArticle Then
                        AddHandler bt.Click, AddressOf ctg_NEXT
                        bt.BackColor = Color.Green
                        bt.Text = "[...]"
                        bt.BackgroundImage = Nothing
                        bt.Tag = artdt

                        Form1.indexStartArticle = Form1.indexLastArticle
                        Exit For
                    Else
                        AddHandler bt.Click, AddressOf art_click
                    End If
                Next

            End If
            txt.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
            txt.Focus()
        End Try
    End Sub
    Public Sub SearchForArticles(ByRef txt As TextBox)

        If txt.Text.Trim = "" Then
            Form1.txtSearch.Text = ""
            Form1.txtSearchCode.Text = ""

            If Form1.chbcb.Checked Then
                Form1.txtSearchCode.Focus()
            Else
                Form1.txtSearch.Focus()
            End If

            Exit Sub
        End If

        Form1.FlowLayoutPanel1.Controls.Clear()
        Try
            Dim artta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
            Dim artdt As DataTable

            '''''''''''''''''''
             
            artdt = artta.GetDatalikecodebar(txt.Text & "%")
 
            If artdt.Rows.Count = 0 Then
                Dim lb As New Label

                lb.ForeColor = Color.DarkGray
                lb.Text = "لا يوجد اي سجل"
                Form1.FlowLayoutPanel1.Controls.Add(lb)

            Else
                For i As Integer = 0 To artdt.Rows.Count - 1

                    Dim bt As New Button

                    bt.Visible = True
                    bt.BackColor = Color.LightSeaGreen
                    bt.Text = artdt.Rows(i).Item("name").ToString
                    bt.Name = "art" & i
                    bt.Tag = artdt.Rows(i)
                    bt.TextAlign = ContentAlignment.BottomCenter
                    Try
                        If artdt.Rows(i).Item("img").ToString = "No Image" Or artdt.Rows(i).Item("img").ToString = "" Then

                        Else
                            Dim str As String = Form1.BtImgPah.Tag & "\art" & artdt.Rows(i).Item("img").ToString
                            If Form1.cbImgPrice.Checked Then
                                str = Form1.BtImgPah.Tag & "\P-art" & artdt.Rows(i).Item("img").ToString
                                bt.TextAlign = ContentAlignment.BottomCenter
                                bt.Font = New Font("Arial", 11, FontStyle.Bold)
                            End If

                            bt.BackgroundImage = Image.FromFile(str)
                        End If
                        bt.BackgroundImageLayout = ImageLayout.Stretch
                        bt.ImageAlign = ContentAlignment.BottomCenter
                    Catch ex As Exception

                    End Try
                    bt.Width = Form1.txtlongerbt.Text
                    bt.Height = Form1.txtlargebt.Text
                    Form1.FlowLayoutPanel1.Controls.Add(bt)
                    'AddHandler bt.Click, AddressOf art_click

                    If i = Form1.indexLastArticle Then
                        AddHandler bt.Click, AddressOf ctg_NEXT
                        bt.BackColor = Color.Green
                        bt.Text = "[...]"
                        bt.BackgroundImage = Nothing
                        bt.Tag = artdt

                        Form1.indexStartArticle = Form1.indexLastArticle
                        Exit For
                    Else
                        AddHandler bt.Click, AddressOf art_click
                    End If
                Next
            End If

            Form1.txtSearch.Text = ""
            Form1.txtSearchCode.Text = ""

            If Form1.chbcb.Checked Then
                Form1.txtSearchCode.Focus()
            Else
                Form1.txtSearch.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub SearchForcodebar()
        Dim bt As New Button
        Try
            bt = Form1.FlowLayoutPanel1.Controls(0)
            '''''


            ' sell function
            art_click(bt, Nothing)

        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Public Sub SearchForcodebarOnly(ByRef txt As TextBox)

        If txt.Text.Trim = "" Then
            Form1.txtSearch.Text = ""
            Form1.txtSearchCode.Text = ""

            If Form1.chbcb.Checked Then
                Form1.txtSearchCode.Focus()
            Else
                Form1.txtSearch.Focus()
            End If
            Exit Sub
        End If

        Try
            Dim artta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
            Dim artdt As DataTable

            '''''''''''''''''''

            artdt = artta.GetDatalikecodebar(txt.Text & "%")

            If artdt.Rows.Count = 1 Then

                Dim bt As New Button
                bt.Tag = artdt.Rows(0)

                If Form1.cbQte.Checked Then
                    Dim bn As New byname
                    If bn.ShowDialog = DialogResult.OK Then
                        Form1.RPl.CP.Value = bn.qte
                    End If
                End If



                ' sell function
                art_click(bt, Nothing)
            ElseIf artdt.Rows.Count > 1 Then
                Form1.FlowLayoutPanel1.Controls.Clear()

                For i As Integer = 0 To artdt.Rows.Count - 1

                    Dim bt As New Button

                    bt.Visible = True
                    bt.BackColor = Color.LightSeaGreen
                    bt.Text = artdt.Rows(i).Item("name").ToString
                    bt.Name = "art" & i
                    bt.Tag = artdt.Rows(i)
                    bt.TextAlign = ContentAlignment.BottomCenter
                    Try
                        If artdt.Rows(i).Item("img").ToString = "No Image" Or artdt.Rows(i).Item("img").ToString = "" Then

                        Else
                            Dim str As String = Form1.BtImgPah.Tag & "\art" & artdt.Rows(i).Item("img").ToString
                            If Form1.cbImgPrice.Checked Then
                                str = Form1.BtImgPah.Tag & "\P-art" & artdt.Rows(i).Item("img").ToString
                                bt.TextAlign = ContentAlignment.BottomCenter
                                bt.Font = New Font("Arial", 11, FontStyle.Bold)
                            End If

                            bt.BackgroundImage = Image.FromFile(str)
                        End If
                        bt.BackgroundImageLayout = ImageLayout.Stretch
                        bt.ImageAlign = ContentAlignment.BottomCenter
                    Catch ex As Exception

                    End Try
                    bt.Width = Form1.txtlongerbt.Text
                    bt.Height = Form1.txtlargebt.Text
                    Form1.FlowLayoutPanel1.Controls.Add(bt)
                    'AddHandler bt.Click, AddressOf art_click
                    AddHandler bt.Click, AddressOf art_click

                    If i = 9 Then Exit For
                Next
            Else
                Form1.FlowLayoutPanel1.Controls.Clear()
                Dim lb As New Label

                lb.ForeColor = Color.DarkGray
                lb.Text = "لا يوجد اي سجل"
                lb.Font = New Font("Arial", 14, FontStyle.Bold)
                lb.ForeColor = Color.Red
                lb.AutoSize = True
                Form1.FlowLayoutPanel1.Controls.Add(lb)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Form1.txtSearch.Text = ""
        Form1.txtSearchCode.Text = ""

        If Form1.chbcb.Checked Then
            Form1.txtSearchCode.Focus()
        Else
            Form1.txtSearch.Focus()
        End If
    End Sub
    Public Sub getBalancebyRef(ByRef ref As String, ByVal qte As Double)

        Try
            Dim artta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
            Dim artdt As DataTable

            '''''''''''''''''''

            artdt = artta.GetDataByRef(ref, True)

            If artdt.Rows.Count = 1 Then

                Dim bt As New Button
                bt.Tag = artdt.Rows(0)

                If artdt.Rows(0).Item("unite").ToString.ToUpper = "G" Or
                       artdt.Rows(0).Item("unite").ToString.ToUpper = "GR" Or
                       artdt.Rows(0).Item("unite").ToString = "ج" Then


                    Form1.RPl.CP.Value = qte
                Else


                    Form1.RPl.CP.Value = CDbl(qte / 1000)
                End If



                ' sell function
                art_click(bt, Nothing)
            ElseIf artdt.Rows.Count > 1 Then
                Form1.FlowLayoutPanel1.Controls.Clear()
                Form1.RPl.CP.Value = qte

                For i As Integer = 0 To artdt.Rows.Count - 1

                    Dim bt As New Button

                    bt.Visible = True
                    bt.BackColor = Color.LightSeaGreen
                    bt.Text = artdt.Rows(i).Item("name").ToString
                    bt.Name = "art" & i
                    bt.Tag = artdt.Rows(i)
                    bt.TextAlign = ContentAlignment.BottomCenter
                    Try
                        If artdt.Rows(i).Item("img").ToString = "No Image" Or artdt.Rows(i).Item("img").ToString = "" Then

                        Else
                            Dim str As String = Form1.BtImgPah.Tag & "\art" & artdt.Rows(i).Item("img").ToString
                            If Form1.cbImgPrice.Checked Then
                                str = Form1.BtImgPah.Tag & "\P-art" & artdt.Rows(i).Item("img").ToString
                                bt.TextAlign = ContentAlignment.BottomCenter
                                bt.Font = New Font("Arial", 11, FontStyle.Bold)
                            End If

                            bt.BackgroundImage = Image.FromFile(str)
                        End If
                        bt.BackgroundImageLayout = ImageLayout.Stretch
                        bt.ImageAlign = ContentAlignment.BottomCenter
                    Catch ex As Exception

                    End Try
                    bt.Width = Form1.txtlongerbt.Text
                    bt.Height = Form1.txtlargebt.Text
                    Form1.FlowLayoutPanel1.Controls.Add(bt)
                    'AddHandler bt.Click, AddressOf art_click
                    AddHandler bt.Click, AddressOf art_click

                    If i = 9 Then Exit For
                Next
            Else
                Form1.FlowLayoutPanel1.Controls.Clear()
                Dim lb As New Label

                lb.ForeColor = Color.DarkGray
                lb.Text = "لا يوجد اي سجل"
                lb.Font = New Font("Arial", 14, FontStyle.Bold)
                lb.ForeColor = Color.Red
                lb.AutoSize = True
                Form1.FlowLayoutPanel1.Controls.Add(lb)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Form1.txtSearch.Text = ""
        Form1.txtSearchCode.Text = ""

        If Form1.chbcb.Checked Then
            Form1.txtSearchCode.Focus()
        Else
            Form1.txtSearch.Focus()
        End If
    End Sub


    Private Sub ctg_click(ByVal sender As System.Object, ByVal e As EventArgs)

        Dim bt2 As Button = sender
        Form1.FlowLayoutPanel1.Controls.Clear()
        FillGroupesByCat(bt2.Tag)

        Try
            Dim artta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
            Dim artdt = artta.GetDataBycid(bt2.Tag)
            Form1.FlowLayoutPanel1.Tag = bt2.Tag

            If artdt.Rows.Count = 0 Then
                Dim lb As New Label

                lb.ForeColor = Color.DarkGray
                lb.Text = "لا يوجد اي سجل"
                Form1.FlowLayoutPanel1.Controls.Add(lb)
            Else

                For i As Integer = 0 To artdt.Rows.Count - 1

                    Dim bt As New Button

                    bt.Visible = True
                    bt.FlatStyle = FlatStyle.Flat
                    bt.BackColor = Color.LightSeaGreen
                    bt.Text = artdt.Rows(i).Item("name").ToString
                    bt.Name = "art" & i
                    bt.Tag = artdt.Rows(i)
                    bt.TextAlign = ContentAlignment.BottomCenter
                    Try
                        If artdt.Rows(i).Item("img").ToString = "No Image" Or artdt.Rows(i).Item("img").ToString = "" Then

                        Else
                            Dim str As String = Form1.BtImgPah.Tag & "\art" & artdt.Rows(i).Item("img").ToString
                            If Form1.cbImgPrice.Checked Then
                                str = Form1.BtImgPah.Tag & "\P-art" & artdt.Rows(i).Item("img").ToString
                                'bt.Text= ""
                                bt.TextAlign = ContentAlignment.BottomCenter
                                bt.Font = New Font("Arial", 11, FontStyle.Bold)
                                'Else
                                '    bt.ForeColor = Color.Yellow
                            End If

                            bt.BackgroundImage = Image.FromFile(str)
                        End If
                        bt.BackgroundImageLayout = ImageLayout.Stretch
                        bt.ImageAlign = ContentAlignment.BottomCenter
                    Catch ex As Exception
                        bt.Text = artdt.Rows(i).Item("name").ToString
                    End Try
                    bt.Width = Form1.txtlongerbt.Text
                    bt.Height = Form1.txtlargebt.Text
                    Form1.FlowLayoutPanel1.Controls.Add(bt)
                    'AddHandler bt.Click, AddressOf art_click
                    ''''''''''''''''''''''''''''''''''''''''''''''' list suivant

                    If i = Form1.indexLastArticle Then

                        AddHandler bt.Click, AddressOf ctg_NEXT
                        bt.BackColor = Color.Green
                        bt.Text = "[...]"
                        bt.TextAlign = ContentAlignment.MiddleCenter
                        bt.BackgroundImage = Nothing
                        bt.Tag = artdt

                        Form1.indexStartArticle = Form1.indexLastArticle
                        Exit For
                    Else
                        AddHandler bt.Click, AddressOf art_click
                    End If
                Next

            End If
            If Form1.chbcb.Checked Then
                Form1.txtSearchCode.Text = ""
                Form1.txtSearchCode.Focus()
            Else
                Form1.txtSearch.Text = ""
                Form1.txtSearch.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ctg_NEXT(ByVal sender As System.Object, ByVal e As EventArgs)
        Try
            Dim bt2 As Button = sender
            Form1.FlowLayoutPanel1.Controls.Clear()
            Dim artdt = bt2.Tag

            '''''''''''''''''''''''''''''''''''' go back
            If Form1.indexStartArticle > 0 Then

                Dim btBACK As New Button
                btBACK.Visible = True
                btBACK.FlatStyle = FlatStyle.Flat
                btBACK.BackColor = Color.Green
                btBACK.Text = "[...]"
                btBACK.Tag = bt2.Tag
                'btBACK.TextAlign = ContentAlignment.BottomCenter
                btBACK.Width = Form1.txtlongerbt.Text
                btBACK.Height = Form1.txtlargebt.Text
                Form1.FlowLayoutPanel1.Controls.Add(btBACK)
                AddHandler btBACK.Click, AddressOf ctg_BACK
            End If

            ''''''''''''''''''''''''''''''''''''
            Dim _END As Integer = Form1.indexStartArticle + Form1.indexLastArticle
            For i As Integer = Form1.indexStartArticle To _END

                If i = artdt.Rows.Count Then
                    Form1.indexStartArticle = i '- Form1.indexLastArticle
                    Exit For
                End If

                Dim bt As New Button

                bt.Visible = True
                bt.FlatStyle = FlatStyle.Flat
                bt.BackColor = Color.LightSeaGreen
                bt.Text = artdt.Rows(i).Item("name").ToString
                bt.Name = "art" & i
                bt.Tag = artdt.Rows(i)
                bt.TextAlign = ContentAlignment.BottomCenter
                Try
                    If artdt.Rows(i).Item("img").ToString = "No Image" Or artdt.Rows(i).Item("img").ToString = "" Then

                    Else
                        Dim str As String = Form1.BtImgPah.Tag & "\art" & artdt.Rows(i).Item("img").ToString
                        If Form1.cbImgPrice.Checked Then
                            Try
                                str = Form1.BtImgPah.Tag & "\P-art" & artdt.Rows(i).Item("img").ToString
                                bt.TextAlign = ContentAlignment.BottomCenter
                                bt.Font = New Font("Arial", 11, FontStyle.Bold)
                            Catch ex As Exception

                            End Try

                        End If

                        bt.BackgroundImage = Image.FromFile(str)
                    End If
                    bt.BackgroundImageLayout = ImageLayout.Stretch
                    bt.ImageAlign = ContentAlignment.BottomCenter
                Catch ex As Exception
                    bt.Text = artdt.Rows(i).Item("name").ToString
                End Try
                bt.Width = Form1.txtlongerbt.Text
                bt.Height = Form1.txtlargebt.Text
                Form1.FlowLayoutPanel1.Controls.Add(bt)

                ''''''''''''''''''''''''''''''' GO FORWORD
                If i = Form1.indexStartArticle + Form1.indexLastArticle Then

                    AddHandler bt.Click, AddressOf ctg_NEXT
                    bt.BackColor = Color.Green
                    bt.Text = "[...]"
                    bt.TextAlign = ContentAlignment.MiddleCenter
                    bt.BackgroundImage = Nothing
                    bt.Tag = bt2.Tag
                    Form1.indexStartArticle += Form1.indexLastArticle
                    Exit For
                Else
                    AddHandler bt.Click, AddressOf art_click
                End If
            Next

            If Form1.chbcb.Checked Then
                Form1.txtSearchCode.Text = ""
                Form1.txtSearchCode.Focus()
            Else
                Form1.txtSearch.Text = ""
                Form1.txtSearch.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ctg_BACK(ByVal sender As System.Object, ByVal e As EventArgs)
        Try
            Dim bt2 As Button = sender
            Form1.FlowLayoutPanel1.Controls.Clear()
            Dim artdt = bt2.Tag

            Dim s As Integer = Form1.indexStartArticle
            Dim l As Integer = Form1.indexLastArticle
            '''''''''''''''''''''''''''''''''''' go back
            If s > l Then

                Dim btBACK As New Button
                btBACK.Visible = True
                btBACK.FlatStyle = FlatStyle.Flat
                btBACK.BackColor = Color.Green
                btBACK.Text = "[...]"
                btBACK.Tag = bt2.Tag
                'btBACK.TextAlign = ContentAlignment.BottomCenter
                btBACK.Width = Form1.txtlongerbt.Text
                btBACK.Height = Form1.txtlargebt.Text
                Form1.FlowLayoutPanel1.Controls.Add(btBACK)
                AddHandler btBACK.Click, AddressOf ctg_BACK
            End If

            ''''''''''''''''''''''''''''''''''''
            s -= l * 2
            If s < 0 Then s = 0

            Dim _END As Integer = s + l
            For i As Integer = s To _END

                If i = artdt.Rows.Count Then
                    Form1.indexStartArticle = i '- Form1.indexLastArticle
                    Exit For
                End If

                Dim bt As New Button

                bt.Visible = True
                bt.FlatStyle = FlatStyle.Flat
                bt.BackColor = Color.LightSeaGreen
                bt.Text = artdt.Rows(i).Item("name").ToString
                bt.Name = "art" & i
                bt.Tag = artdt.Rows(i)
                bt.TextAlign = ContentAlignment.BottomCenter
                Try
                    If artdt.Rows(i).Item("img").ToString = "No Image" Or artdt.Rows(i).Item("img").ToString = "" Then

                    Else
                        Dim str As String = Form1.BtImgPah.Tag & "\art" & artdt.Rows(i).Item("img").ToString
                        If Form1.cbImgPrice.Checked Then
                            str = Form1.BtImgPah.Tag & "\P-art" & artdt.Rows(i).Item("img").ToString
                            bt.TextAlign = ContentAlignment.BottomCenter
                            bt.Font = New Font("Arial", 11, FontStyle.Bold)
                        End If

                        bt.BackgroundImage = Image.FromFile(str)
                    End If
                    bt.BackgroundImageLayout = ImageLayout.Stretch
                    bt.ImageAlign = ContentAlignment.BottomCenter
                Catch ex As Exception
                    bt.Text = artdt.Rows(i).Item("name").ToString
                End Try
                bt.Width = Form1.txtlongerbt.Text
                bt.Height = Form1.txtlargebt.Text
                Form1.FlowLayoutPanel1.Controls.Add(bt)

                ''''''''''''''''''''''''''''''' GO FORWORD
                If i = _END Then

                    AddHandler bt.Click, AddressOf ctg_NEXT
                    bt.BackColor = Color.Green
                    bt.Text = "[...]"
                    bt.TextAlign = ContentAlignment.MiddleCenter
                    bt.BackgroundImage = Nothing
                    bt.Tag = bt2.Tag
                    Form1.indexStartArticle = _END

                    Exit For
                Else
                    AddHandler bt.Click, AddressOf art_click
                End If
            Next

            If Form1.chbcb.Checked Then
                Form1.txtSearchCode.Text = ""
                Form1.txtSearchCode.Focus()
            Else
                Form1.txtSearch.Text = ""
                Form1.txtSearch.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub art_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim bt As Button = sender
        Dim R As ALMohassinDBDataSet.ArticleRow = bt.Tag

        If My.Computer.Keyboard.CtrlKeyDown Then
            Try
                EditArticle(R)

            Catch ex As Exception
            End Try

            Exit Sub
        End If

        'get the details

        Dim pl As Panel = Form1.plright
        Dim fid As Integer = Form1.RPl.FctId
        Dim cid As String = 0
        Dim clientname As String = Form1.txtcltcomptoir.Text.Split("/")(0)
        Dim tableName As String = "Facture"
        If Form1.btswitsh.Tag = 0 Then
            Try
                tableName = "Bon"
                clientname = Form1.txtcltcomptoir.Text.Split("/")(1)
            Catch ex As Exception
                clientname = "Comptoire"
            End Try

        End If

        Try
            If Form1.RPl.FctId = 0 Then
                If Form1.RPl.isSell Then
                    NewFacture(cid, clientname, "", 0)
                Else
                    Exit Sub
                End If
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            tableName = "DetailsFacture"
            If Form1.btswitsh.Tag = 0 Then
                tableName = "DetailsBon"
            End If

            Dim dpt As Integer = Form1.RPl.CP.Depot
            If Form1.CbDepotOrigine.Checked Then dpt = R.depot

            If Form1.RPl.IsExiste(R.arid, dpt) = True And Form1.cbMergeArt.Checked = True Then
                Dim item As Items = Form1.RPl.SelectedItems(R.arid, dpt)
                Dim ID As Integer = item.id
                Dim qte As Double = item.Qte + CDbl(Form1.RPl.CP.Value)

                Using a As SubClass = New SubClass
                    If Form1.CbQteStk.Checked And Form1.RPl.isSell Then
                        Dim stk = a.getStock(item.arid, item.Depot, 0)
                        If qte >= stk Then qte = stk
                        If qte < 0 Then qte = CDbl(0)
                    End If
                End Using

                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

                    If R.cid <> 0 Then
                        Dim params As New Dictionary(Of String, Object)
                        Dim where As New Dictionary(Of String, Object)

                        params.Add("qte", qte)
                        'where.Add("id", ID)

                        If Form1.RPl.isSell Then
                            where.Add("id", ID)
                        Else
                            where.Add("bid", ID)
                        End If

                        If c.UpdateRecord(tableName, params, where) Then
                            Form1.RPl.ChangedItemsQte(R.arid, dpt, qte)
                        End If
                    End If

                End Using
            Else
                Dim arid As Integer = 0

                If Form1.cbQteCat.Checked Then

                    Try
                        Dim cats = Form1.txtQteCat.Text.Split("-")
                        If cats.Contains(R.cid.ToString) Then
                            Dim bn As New byname
                            If bn.ShowDialog = DialogResult.OK Then
                                Form1.RPl.CP.Value = bn.qte
                            End If
                        End If
                    Catch ex As Exception
                    End Try

                End If


                'qte
                Dim qte As Double = CDbl(Form1.RPl.CP.Value)
                Using c As SubClass = New SubClass
                    If Form1.CbQteStk.Checked And isSell Then
                        Dim stk = c.getStock(R.arid, R.depot, 0)
                        If qte >= stk Then qte = stk
                        If qte < 0 Then qte = 0
                    End If
                End Using
                'Price
                Dim price As Double = CDbl(R.sprice)
                If Form1.RPl.isSell Then
                    'If Form1.RPl.Num > 0 Then
                    '    price = R.bprice + (R.bprice * Form1.RPl.Num / 100)
                    'End If
                    If Form1.RPl.Num > 0 Then
                        Select Case Form1.RPl.Num
                            Case 2
                                price = R.sp3
                            Case 3
                                price = R.sp4
                            Case 4
                                price = R.sp5
                            Case Else
                                price = R.sprice
                        End Select
                    End If
                Else
                    price = R.bprice
                End If
                'tva
                Dim tva As Double = 20
                If Form1.CBTVA.Checked Then tva = CDbl(R.tva)

                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    Dim params As New Dictionary(Of String, Object)
                    params.Add("fctid", CInt(Form1.RPl.FctId))
                    params.Add("name", R.name)
                    params.Add("bprice", CDbl(R.bprice))
                    params.Add("price", price)
                    params.Add("unit", R.unite)
                    params.Add("qte", qte)
                    params.Add("tva", tva)
                    params.Add("poid", CInt(R.poid * 100))
                    params.Add("arid", CInt(R.arid))
                    params.Add("depot", dpt)
                    params.Add("code", R.codebar)
                    params.Add("cid", CStr(R.cid))

                    arid = c.InsertRecord(tableName, params, True)
                End Using

                If arid > 0 Then
                    Form1.RPl.AddItems(R, arid, CBool(Form1.btswitsh.Tag))
                Else
                    Exit Sub
                End If
            End If

            Form1.txtSearch.Text = ""
            Form1.txtSearchCode.Text = ""

            If Form1.chbcb.Checked Then
                Form1.txtSearchCode.Focus()
            Else
                Form1.txtSearch.Focus()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub EditArticle(ByVal R As ALMohassinDBDataSet.ArticleRow)

        'If DGVPRD.SelectedRows(0).Cells(11).Value = 0 Then
        '    Exit Sub
        'End If
        Dim bprice As Double = String.Format("{0:F}", R.bprice)
        Dim Sprice As Double = String.Format("{0:F}", R.sprice)
        Dim tva As Double = String.Format("{0:F}", R.tva)
        Dim cid As Integer = R.cid
        Dim price2 As String = ""
        Dim price3 As String = ""

        If Form1.chbsell.Checked Then
            price2 = String.Format("{0:F}", R.sp3)
            price3 = String.Format("{0:F}", R.sp4)
        End If

        Dim art As New AddEditArticle
        art.editMode = True

        art.cbctg.Tag = cid
        art.cid = cid
        art.cbctg.SelectedValue = cid
        art.CBdp.SelectedValue = CInt(R.depot)
        art.CBdp.Tag = R.depot
        art.txtcb.text = R.codebar
        art.txtprdname.Text = R.name
        art.txtbprice.text = bprice
        art.txtsprice.text = Sprice
        art.txtprice2.text = price2
        art.txtprice3.text = price3
        art.txtunit.Text = R.unite
        art.txttva.text = tva
        art.txtprdname.Tag = R.arid

        art.PlPrice.Visible = Form1.chbsell.Checked

        Try
            art.txtMinStock.text = CInt(R.elements)
        Catch ex As Exception
            art.txtMinStock.text = "0"
        End Try

        Try
            art.TxtPoids.text = R.poid
        Catch ex As Exception
            art.TxtPoids.text = "0"
        End Try


        Try
            If R.img <> "" And R.img <> "No Image" Then
                art.PBprd.Tag = R.img
                art.ImgPrd = Image.FromFile(Form1.BtImgPah.Tag & "\art" & R.img)
            End If
        Catch ex As Exception

        End Try

        art.btprd.Tag = "1"

        If art.ShowDialog = Windows.Forms.DialogResult.OK Then
            Form1.txtSearch.Text = R.codebar
            SearchForArticles(Form1.txtSearch, R.cid)
            Form1.txtSearch.Text = ""
        End If

        If Form1.chbcb.Checked Then
            Form1.txtSearchCode.Text = ""
            Form1.txtSearchCode.Focus()
        Else
            Form1.txtSearch.Text = ""
            Form1.txtSearch.Focus()
        End If
    End Sub
    Private Sub ctg_stock_click(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim bt2 As Button = sender
        Form1.DGVS.Rows.Clear()

        Dim dpt As Integer = Form1.RPl.CP.Depot
        If Form1.CbDepotOrigine.Checked Then dpt = Form1.cbdepot.SelectedValue

        Try
            Dim artta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
            Dim sta As New ALMohassinDBDataSetTableAdapters.DetailstockTableAdapter
            Dim sdt = sta.GetDataByid(dpt, bt2.Tag)
            If sdt.Rows.Count = 0 Then
                MsgBox("لا يوجد اي سجل", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "المخزن")
            Else
                For i As Integer = 0 To sdt.Rows.Count - 1
                    Dim bt As New Button
                    Dim ardt = artta.GetDataByarid(sdt.Rows(i).Item("arid"))
                    Try
                        Form1.DGVS.Rows.Add(ardt.Rows(0).Item("codebar").ToString,
                                            ardt.Rows(0).Item("name").ToString, ardt.Rows(0).Item("unite").ToString,
                                            sdt.Rows(i).Item("qte").ToString, "", "", ardt.Rows(0).Item(0).ToString,
                                             sdt.Rows(i).Item(0))
                    Catch ex As Exception

                    End Try
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub loadStrdFct(ByVal Txt As String)
        Try
            Dim strpath As String = Form1.BtImgPah.Tag & "\StrdFct"
            Dim loadPath As String = Path.Combine(strpath, Txt)
            Dim p As Panel = Form1.plright

            Dim aa As Integer = 0
            Dim ds As New DataSet
            ds.ReadXml(loadPath)

            Try
                If ds.Tables("FactureInfo").Rows.Count > 0 Then
                    Dim fid As Integer
                    Dim clientname As String = ds.Tables("FactureInfo").Rows(0).Item("client")
                    Dim avance As Double = CDbl(ds.Tables("FactureInfo").Rows(0).Item("avance"))
                    Dim clientId As Integer = CInt(ds.Tables("FactureInfo").Rows(0).Item("clientID"))

                    Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                        Dim params As New Dictionary(Of String, Object)
                        params.Add("clid", clientId)
                        params.Add("name", clientname)
                        params.Add("total", 0)
                        params.Add("avance", avance)
                        params.Add("date", Format(Now.Date, "dd-MM-yyyy"))
                        params.Add("admin", False)
                        params.Add("writer", ds.Tables("FactureInfo").Rows(0).Item("writer"))
                        params.Add("tp", 1)
                        params.Add("payed", False)
                        params.Add("poid", 0)
                        params.Add("num", 0)
                        params.Add("tva", 0)
                        params.Add("adresse", "")
                        params.Add("bl", "---")
                        params.Add("remise", 0)
                        params.Add("beInFacture", 0)

                        fid = c.InsertRecord("Facture", params, True)
                        If fid > 0 Then

                            If avance > 0 Then
                                params.Clear()

                                params.Add("name", "_")
                                params.Add("clid", clientId)
                                params.Add("montant", avance)
                                params.Add("way", "Cache")
                                params.Add("date", Format(Now.Date, "dd-MM-yyyy"))
                                params.Add("Num", "")
                                params.Add("fctid", fid)
                                params.Add("writer", CStr(Form1.adminName))

                                Dim Pid = c.InsertRecord("Payment", params, True)
                            End If

                            If ds.Tables("DetailsFacture").Rows.Count > 0 Then
                                For j As Integer = 0 To ds.Tables("DetailsFacture").Rows.Count - 1
                                    params.Clear()

                                    params.Add("fctid", fid)
                                    params.Add("name", ds.Tables("DetailsFacture").Rows(j).Item("name"))
                                    params.Add("bprice", CDbl(ds.Tables("DetailsFacture").Rows(j).Item("bprice")))
                                    params.Add("price", CDbl(ds.Tables("DetailsFacture").Rows(j).Item("price")))
                                    params.Add("unit", ds.Tables("DetailsFacture").Rows(j).Item("unite"))
                                    params.Add("qte", CDbl(ds.Tables("DetailsFacture").Rows(j).Item("qte")))
                                    params.Add("tva", CDbl(20))
                                    params.Add("poid", 0)
                                    params.Add("arid", CInt(ds.Tables("DetailsFacture").Rows(j).Item("arid")))
                                    params.Add("depot", CInt(ds.Tables("DetailsFacture").Rows(j).Item("depot")))
                                    params.Add("code", ds.Tables("DetailsFacture").Rows(j).Item("code"))
                                    params.Add("cid", CStr(ds.Tables("DetailsFacture").Rows(j).Item("cid")))

                                    c.InsertRecord("DetailsFacture", params)
                                Next
                            End If

                            Dim rnd As New Random
                            Dim bt As New Button
                            bt.Text = clientname
                            bt.BackColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255)) 'Color.DarkSlateGray
                            bt.FlatStyle = FlatStyle.Flat
                            bt.ForeColor = Color.White
                            bt.Name = "bt" & CStr(rnd.Next) & p.Controls.Count
                            bt.Font = New Font("Arial", 9, FontStyle.Bold)
                            bt.Tag = fid
                            bt.Dock = DockStyle.Left
                            bt.AutoSize = True
                            bt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
                            bt.TextAlign = ContentAlignment.MiddleLeft
                            AddHandler bt.Click, AddressOf FactureSelected

                            p.Controls.Add(bt)
                            'clear the recept liste
                            Form1.RPl.ClearItems()
                            FactureSelected(bt, Nothing)

                            'delete xml file
                            Try
                                File.Delete(loadPath)
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            End Try


                            FillGroupes(True)
                            If isSell Then AppendData(fid, "Creation de la Facture ", "APP", "TABLETE")
                            bt = Nothing
                            rnd = Nothing
                        End If
                    End Using
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    ' create new fact

    Public Sub NewFacture(ByVal t As Integer)
        Try
            Dim chs As New ChoseClient
            chs.isSell = Form1.RPl.isSell
            chs.editMode = Form1.RPl.EditMode

            Dim p As Panel = Form1.plright

            If chs.ShowDialog = Windows.Forms.DialogResult.OK Then
                NewFacture(chs.cid, chs.clientName, chs.clientadresse, chs.num)
            End If

            If Form1.chbcb.Checked Then
                Form1.txtSearchCode.Text = ""
                Form1.txtSearchCode.Focus()
            Else
                Form1.txtSearch.Text = ""
                Form1.txtSearch.Focus()
            End If

            chs = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub NewFacture(ByVal clid As String, ByVal cn As String, ByVal cad As String, ByVal nm As String)
        Try
            Dim tableName As String = "Facture"
            Dim p As Panel = Form1.plright
            Dim cid As String = clid
            Dim clientname As String = cn
            Dim clientadesse As String = cad
            Dim tp As String = 0
            Dim num As String = nm
            Dim fid As Integer = 0
            Dim dte As Date = Now.Date

            If cid <> 0 And tp <> 0 Then
                If tp = "" Then tp = "1"
                If CheckForUnpaidFacture(cid, tp) = False Then Exit Sub
            End If

            If Form1.RPl.isSell = False Then
                tableName = "Bon"
            End If

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)
                params.Add("clid", cid)
                params.Add("name", clientname)
                params.Add("total", 0)
                params.Add("avance", 0)
                params.Add("date", Format(dte, "dd-MM-yyyy"))
                params.Add("admin", False)
                params.Add("writer", CStr(Form1.adminName))
                params.Add("tp", tp)
                params.Add("payed", False)
                params.Add("poid", 0)
                params.Add("num", num)
                params.Add("tva", 0)
                params.Add("adresse", clientadesse)
                params.Add("bl", "---")
                params.Add("remise", 0)
                params.Add("beInFacture", 0)
                'params.Add("delivredDay", Now.Date.AddDays(2))

                fid = c.InsertRecord(tableName, params, True)
            End Using


            If fid > 0 Then
                Dim rnd As New Random
                Dim bt As New Button
                bt.Text = clientname
                bt.BackColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255)) 'Color.DarkSlateGray
                bt.FlatStyle = FlatStyle.Flat
                bt.ForeColor = Color.White
                bt.Name = "bt" & CStr(rnd.Next) & p.Controls.Count
                bt.Font = New Font("Arial", 9, FontStyle.Bold)
                bt.Tag = fid
                bt.Dock = DockStyle.Left
                bt.AutoSize = True
                bt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
                bt.TextAlign = ContentAlignment.MiddleLeft
                AddHandler bt.Click, AddressOf FactureSelected

                p.Controls.Add(bt)
                'clear the recept liste
                Form1.RPl.ClearItems()
                FactureSelected(bt, Nothing)
                If isSell Then AppendData(fid, "Creation de la Bon", "-", "-")
                bt = Nothing
                rnd = Nothing

            End If

            If Form1.chbcb.Checked Then
                Form1.txtSearchCode.Text = ""
                Form1.txtSearchCode.Focus()
            Else
                Form1.txtSearch.Text = ""
                Form1.txtSearch.Focus()
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function getClient(ByVal cid As Integer) As DataTable
        Dim dt As DataTable
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add("Clid", cid)

            Try
                dt = c.SelectDataTable("Client", {"*"}, params)
                If dt.Rows.Count = 0 Then
                    dt = Nothing
                End If

            Catch ex As Exception
                dt = Nothing
            End Try
        End Using
        Return dt
    End Function
    Public Sub SaveFacture(ByVal id As Integer, ByVal total As Double, ByVal avance As Double,
                           ByVal tva As Double, ByVal table As DataTable, ByVal Remise As String,
                           ByVal BL As String, ByVal isS As Boolean)

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim isPayed As Boolean = False
            If avance >= total Then isPayed = True

            Dim tableName = "Facture"
            Dim ptName = "Payment"
            Dim cl = "clid"
            Dim fc = "fctid"
            If isS = False Then
                tableName = "Bon"
                ptName = "CompanyPayment"
                cl = "comid"
                fc = "bonid"
            End If

            Dim dte As Date = Now.Date
            Dim params As New Dictionary(Of String, Object)

            If Form1.RPl.ClId = 0 And isS And Form1.cbCaisse.Checked = False Then
                Dim mnt As Double = total - avance
                If Form1.RPl.delivredDay = "" Or Form1.RPl.delivredDay = "-" Or Form1.RPl.delivredDay = "0" Then
                    params.Add("name", "@--")
                    params.Add(cl, 0)
                    params.Add("montant", mnt)
                    params.Add("way", "Comptoire")
                    params.Add(fc, id)
                    params.Add("date", dte)
                    params.Add("writer", Form1.adminName)

                    c.InsertRecord(ptName, params)
                    isPayed = True
                    avance = total
                End If
            End If

            'Facture
            params.Clear()
            params.Add("total", total)
            params.Add("avance", avance)
            params.Add("admin", True)
            params.Add("payed", isPayed)
            params.Add("tva", tva)
            params.Add("remise", Remise)
            'params.Add("date", dte)
            params.Add("bl", BL)

            Dim where As New Dictionary(Of String, Object)

            where.Add(fc, id)

            c.UpdateRecord(tableName, params, where)
            params.Clear()
            where.Clear()

            'Stock
            'If Form1.RPl.delivredDay = "" Or Form1.RPl.delivredDay = "0" Then
            For i As Integer = 0 To table.Rows.Count - 1

                Dim arid As Integer = table.Rows(i).Item(0)
                Dim dpid As Integer = table.Rows(i).Item("depot")
                Dim cid As Integer = table.Rows(i).Item("cid")

                If cid <> 0 Then

                    If isS = False Then
                        tableName = "Article"

                        params.Add("bprice", table.Rows(i).Item("bprice"))
                        where.Add("arid", arid)

                        c.UpdateRecord(tableName, params, where)
                    End If

                    params.Clear()
                    where.Clear()

                    where.Add("arid", arid)
                    where.Add("dpid", dpid)

                    Dim dt = c.SelectDataTable("Detailstock", {"*"}, where)
                    where.Clear()

                    If dt.Rows.Count > 0 Then
                        Dim qte As Double = table.Rows(i).Item("qte")
                        Dim dsid As Integer = dt.Rows(0).Item(0)
                        If isS Then qte = qte * (-1)
                        qte = qte + dt.Rows(0).Item("qte")

                        params.Add("qte", qte)
                        where.Add("DSID", dsid)

                        c.UpdateRecord("Detailstock", params, where)
                    Else
                        Dim qte As Double = table.Rows(i).Item("qte")
                        If isS Then qte = qte * (-1)

                        params.Add("arid", arid)
                        params.Add("dpid", dpid)
                        params.Add("qte", qte)
                        params.Add("unit", table.Rows(i).Item("unite"))
                        params.Add("cid", table.Rows(i).Item("cid"))

                        c.InsertRecord("Detailstock", params)
                    End If
                    params.Clear()
                    where.Clear()

                    'Else
                    '    'mellanges
                    '    params.Clear()
                    '    where.Clear()
                    '    where.Add("arid", arid)
                    '    params.Add("cid", -100)
                    '    params.Add("codebar", "date-" & Format(dte, "dd-MM-yyyy"))

                    '    c.UpdateRecord("Article", params, where)
                End If
            Next
            'End If

            If isS Then
                AppendData(id, table)
                AppendData(id, "Total", "-", total)
                AppendData(id, "Avance", "-", avance)
            End If

            params = Nothing
            where = Nothing
        End Using
    End Sub

    Public Sub ChangeAllPrices(ByVal fd As Integer)

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)
            Dim table As DataTable = Form1.RPl.DataSource

            For i As Integer = 0 To table.Rows.Count - 1

                Dim id As Integer = table.Rows(i).Item("dsid")
                Dim arid As Integer = table.Rows(i).Item("arid")

                Dim field = "sprice"
                If fd = 2 Then field = "sp3"
                If fd = 3 Then field = "sp4"
                If fd = 4 Then field = "sp5"

                params.Clear()
                where.Clear()
                where.Add("arid", arid)
                Dim pr As Double = c.SelectByScalar("Article", field, where)

                params.Clear()
                where.Clear()
                params.Add("price", pr)
                where.Add("id", id)

                c.UpdateRecord("DetailsFacture", params, where)
            Next
            'End If
            params.Clear()
            where.Clear()
            params.Add("num", fd)
            where.Add("fctid", Form1.RPl.FctId)
            Form1.RPl.Num = fd
            c.UpdateRecord("Facture", params, where)

            params = Nothing
            where = Nothing
        End Using
    End Sub





    Public Sub SaveEditingFacture(ByVal oldValue As System.Decimal, ByVal newValue As System.Decimal,
                                  ByVal Field As System.String, ByVal itm As Items,
                                  ByVal rpl As RPanel)

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim isPayed As Boolean = False
            If rpl.Avance >= rpl.Total_TTC Then isPayed = True
            Dim isS As Boolean = rpl.isSell

            Dim tableName = "Facture"
            If isS = False Then tableName = "Bon"

            'Facture
            Dim params As New Dictionary(Of String, Object)
            params.Add("total", CDbl(rpl.Total_TTC))
            params.Add("payed", isPayed)
            params.Add("tva", CDbl(rpl.Tva))
            params.Add("remise", rpl.Remise)

            Dim where As New Dictionary(Of String, Object)
            If isS Then
                where.Add("fctid", rpl.FctId)
            Else
                where.Add("bonid", rpl.FctId)
            End If

            c.UpdateRecord(tableName, params, where)

            params.Clear()
            where.Clear()

            If Field = "qte" Then
                If itm.Depot <> 0 Then
                    'Stock
                    where.Add("arid", itm.arid)
                    where.Add("dpid", itm.Depot)

                    Dim dt = c.SelectDataTable("Detailstock", {"*"}, where)
                    where.Clear()

                    Dim qte As Double = newValue - oldValue
                    If isS Then qte = oldValue - newValue

                    If dt.Rows.Count > 0 Then
                        Dim dsid As Integer = dt.Rows(0).Item(0)
                        qte = qte + dt.Rows(0).Item("qte")

                        params.Add("qte", qte)
                        where.Add("DSID", dsid)

                        c.UpdateRecord("Detailstock", params, where)
                    Else
                        params.Add("arid", itm.id)
                        params.Add("dpid", itm.Depot)
                        params.Add("qte", qte)
                        params.Add("unit", itm.Unite)
                        params.Add("cid", itm.cid)

                        c.InsertRecord("Detailstock", params)
                    End If
                    params.Clear()
                    where.Clear()
                End If
            End If
            Form1.DGVARFA.SelectedRows(0).Cells(3).Value = rpl.Total_TTC
            Form1.DGVARFA.SelectedRows(0).Cells(5).Value = rpl.Tva
            Form1.DGVARFA.SelectedRows(0).Cells(4).Value = rpl.Avance
            params = Nothing
            where = Nothing

            Try
                Dim s = "Changement QTE"
                If Field = "price" Then s = "Changement de PRIX"
                If isS Then AppendData(rpl.FctId, itm.Name, s & " - " & oldValue, newValue)
            Catch ex As Exception

            End Try
        End Using
    End Sub
    Public Sub EditFacture(ByVal id As Integer, ByVal table As DataTable)

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            Dim tableName = "Facture"
            If Form1.RPl.isSell = False Then tableName = "Bon"


            'Facture
            Dim params As New Dictionary(Of String, Object)
            params.Add("total", 0)
            params.Add("admin", False)
            params.Add("payed", False)


            Dim where As New Dictionary(Of String, Object)
            If Form1.RPl.isSell = True Then
                where.Add("fctid", id)
            Else
                where.Add("bonid", id)
            End If

            c.UpdateRecord(tableName, params, where)

            params.Clear()
            where.Clear()


            'Stock
            For i As Integer = 0 To table.Rows.Count - 1

                Dim arid = table.Rows(i).Item(0)
                Dim dpid = table.Rows(i).Item("depot")

                where.Add("arid", arid)
                where.Add("dpid", dpid)

                Dim dt = c.SelectDataTable("Detailstock", {"*"}, where)
                where.Clear()

                If dt.Rows.Count > 0 Then
                    Dim qte As Double = table.Rows(i).Item("qte")
                    Dim dsid As Integer = dt.Rows(0).Item(0)
                    If Form1.RPl.isSell = False Then qte = qte * (-1)
                    qte = qte + dt.Rows(0).Item("qte")

                    params.Add("qte", qte)
                    where.Add("DSID", dsid)

                    c.UpdateRecord("Detailstock", params, where)
                Else
                    Dim qte As Double = table.Rows(i).Item("qte")
                    If Form1.RPl.isSell = False Then qte = qte * (-1)

                    params.Add("arid", arid)
                    params.Add("dpid", dpid)
                    params.Add("qte", qte)
                    params.Add("unit", table.Rows(i).Item("unite"))
                    params.Add("cid", table.Rows(i).Item("cid"))

                    c.InsertRecord("Detailstock", params)
                End If
                params.Clear()
                where.Clear()
            Next
            If isSell Then AppendData(id, "Modifier l'etat facture", "-", "-")
            params = Nothing
            where = Nothing
        End Using
    End Sub
    Public Sub FactureSelected(ByVal sender As Object, ByVal e As EventArgs)
        Dim bt As Button = sender
        Dim pl As Panel = Form1.plright
        Dim rnd As New Random
        Dim tableName As String = "Facture"
        Dim fld As String = "fctid"
        If Form1.btswitsh.Tag = 0 Then
            tableName = "Bon"
            fld = "bonid"
        End If

        For Each b As Button In pl.Controls
            If CStr(b.Tag) = CStr(bt.Tag) Then
                b.BackColor = Color.White
                b.ForeColor = Color.DarkSlateGray

                'clear the recept liste
                Form1.RPl.ClearItems()
                Form1.RPl.FctId = b.Tag
                Form1.RPl.ClientName = b.Text
                Form1.RPl.isSell = CBool(Form1.btswitsh.Tag)
                Form1.RPl.EditMode = False

                'GET AVANCE OF THIS FACTURE
                'fill the recept items
                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    Dim params As New Dictionary(Of String, Object)
                    params.Add(fld, CInt(bt.Tag))
                    Dim dt = c.SelectDataTable(tableName, {"*"}, params)

                    If dt.Rows.Count > 0 Then
                        Form1.RPl.Avance = dt.Rows(0).Item("avance")
                        Form1.RPl.ClId = dt.Rows(0).Item("clid")
                        Form1.RPl.Num = 0
                        Form1.RPl.delivredDay = dt.Rows(0).Item("tp")
                        If Form1.chbsell.Checked Then Form1.RPl.Num = dt.Rows(0).Item("num")
                        Try
                            Form1.RPl.ClientAdresse = dt.Rows(0).Item("adresse")
                            Form1.RPl.bl = dt.Rows(0).Item("bl")
                        Catch ex As Exception
                            Form1.RPl.ClientAdresse = ""
                        End Try

                        Try
                            Form1.RPl.Remise = dt.Rows(0).Item("remise")
                        Catch ex As Exception
                            Form1.RPl.Remise = "0"
                        End Try

                    End If
                End Using

                tableName = "DetailsFacture"
                If Form1.btswitsh.Tag = 0 Then tableName = "DetailsBon"

                'fill the recept items
                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    Dim params As New Dictionary(Of String, Object)
                    params.Add("fctid", CInt(bt.Tag))
                    Dim dt = c.SelectDataTable(tableName, {"*"}, params)

                    If dt.Rows.Count > 0 Then
                        Form1.RPl.AddItems(dt, CBool(Form1.btswitsh.Tag))
                    End If
                End Using
            Else
                b.BackColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255)) 'Color.DarkSlateGray
                b.ForeColor = Color.White
            End If
        Next

        Form1.txtSearch.Text = ""
        Form1.txtSearchCode.Text = ""

        If Form1.chbcb.Checked Then
            Form1.txtSearchCode.Focus()
        Else
            Form1.txtSearch.Focus()
        End If

        rnd = Nothing
    End Sub
    Public Sub fillFactures(ByVal a As Integer)
        Dim dt As DataTable = Nothing
        Dim p As Panel = Form1.plright
        Dim b As Button = Nothing
        p.Controls.Clear()
        Form1.RPl.ClearItems()
        Form1.RPl.isUniqTva = Form1.CBTVA.Checked

        Dim tableName As String = "Facture"
        If Form1.RPl.isSell = False Then
            tableName = "Bon"
        End If

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add("admin", False)
            dt = c.SelectDataTable(tableName, {"*"}, params)
        End Using

        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim rnd As New Random
                Dim bt As New Button
                Try
                    bt.Tag = dt.Rows(i).Item(0)
                    bt.Text = dt.Rows(i).Item("name")
                Catch ex As Exception

                End Try

                bt.BackColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255)) 'Color.DarkSlateGray
                bt.FlatStyle = FlatStyle.Flat
                bt.ForeColor = Color.White
                bt.Name = "bt" & CStr(rnd.Next) & p.Controls.Count
                bt.Font = New Font("Arial", 9, FontStyle.Bold)
                bt.Dock = DockStyle.Left
                bt.AutoSize = True
                bt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
                bt.TextAlign = ContentAlignment.MiddleLeft
                AddHandler bt.Click, AddressOf FactureSelected

                p.Controls.Add(bt)
                'clear the recept liste
                Form1.RPl.ClearItems()

                If i = 0 Then
                    b = bt
                End If
                bt = Nothing
                rnd = Nothing
            Next

            FactureSelected(b, Nothing)
        End If

        Form1.txtSearch.Text = ""
        Form1.txtSearchCode.Text = ""

        If Form1.chbcb.Checked Then
            Form1.txtSearchCode.Focus()
        Else
            Form1.txtSearch.Focus()
        End If
    End Sub
    Public Sub UpdateItem(ByVal i As Items, ByVal qte As Double, ByVal isS As Boolean, ByVal Field As String)
        Try

            Dim tableName As String = "DetailsBon"
            If isS Then tableName = "DetailsFacture"

            Dim oldqte As Double = CDbl(i.Qte)

            If Field = "qte" Then
                Using a As SubClass = New SubClass
                    If Form1.CbQteStk.Checked And isS Then
                        Dim stk = a.getStock(i.arid, i.Depot, 0)
                        If qte >= stk Then qte = oldqte
                        If qte < 0 Then qte = 0
                    End If
                End Using
            End If

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                params.Add(Field, qte)

                Dim where As New Dictionary(Of String, Object)
                If isS Then
                    where.Add("id", CInt(i.id))
                Else
                    where.Add("bid", CInt(i.id))
                End If

                Try
                    Dim h As Integer = c.UpdateRecord(tableName, params, where)
                    If h > 0 Then
                        Form1.RPl.ChangedItemsQte(i.id, qte, Field)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using

        Catch ex As Exception

        End Try
    End Sub
    Public Sub UpdateItem(ByVal i As Items, ByVal isS As Boolean)
        Try
            Dim clc As New Editprdfact(i.Name, i.Bprice, i.Price, i.Qte)
            If clc.ShowDialog = DialogResult.OK Then
                Dim tableName As String = "DetailsBon"
                If isS Then tableName = "DetailsFacture"

                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                    Dim params As New Dictionary(Of String, Object)
                    Dim qte As Double = clc.prdQte
                    'Dim oldqte As Double = CDbl(i.Qte)

                    params.Add("name", clc.prdName)
                    params.Add("bprice", clc.prdBPrice)
                    params.Add("price", clc.prdSPrice)
                    params.Add("qte", clc.prdQte)


                    Dim where As New Dictionary(Of String, Object)
                    'where.Add("fctid", CInt(Form1.RPl.FctId))
                    If isS Then
                        where.Add("id", CInt(i.id))
                    Else
                        where.Add("bid", CInt(i.id))
                    End If

                    Try
                        Dim h As Integer = c.UpdateRecord(tableName, params, where)
                        If h > 0 Then
                            Form1.RPl.ChangedItems(i.id, clc.prdName, clc.prdBPrice, clc.prdSPrice, clc.prdQte)
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                End Using
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub UpdateItemREMISE(ByRef i As Items, ByVal isS As Boolean)
        Try

            Dim clc As New Calc
            clc.title = "Remise :"
            clc.desc = i.Remise & " %"

            If clc.ShowDialog = DialogResult.OK Then
                Dim tableName As String = "DetailsBon"
                If isS Then tableName = "DetailsFacture"
                Dim remise As Integer = CInt(clc.CPanel1.Value * 100)
                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                    Dim params As New Dictionary(Of String, Object)
                    params.Add("poid", remise)

                    Dim where As New Dictionary(Of String, Object)
                    'where.Add("fctid", CInt(Form1.RPl.FctId))
                    If isS Then
                        where.Add("id", CInt(i.id))
                    Else
                        where.Add("bid", CInt(i.id))
                    End If

                    Try
                        Dim h As Integer = c.UpdateRecord(tableName, params, where)
                        If h > 0 Then
                            i.Remise = CDbl(remise / 100)
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End Using
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub UpdateItemDetails(ByVal txt As String, ByRef i As Items, ByVal isS As Boolean)

        Try
            Dim tableName As String = "DetailsBon"
            If isS Then tableName = "DetailsFacture"

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                Dim params As New Dictionary(Of String, Object)
                params.Add("code", txt)

                Dim where As New Dictionary(Of String, Object)
                'where.Add("fctid", CInt(Form1.RPl.FctId))
                If isS Then
                    where.Add("id", CInt(i.id))
                Else
                    where.Add("bid", CInt(i.id))
                End If

                Try
                    Dim h As Integer = c.UpdateRecord(tableName, params, where)
                    If h > 0 Then
                        i.code = txt
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Public Sub UpdateDateFacture(ByVal dt As Date, ByVal id As Integer, ByVal isS As Boolean)

        Try
            Dim tableName As String = "Facture"
            If isS = False Then tableName = "Bon"

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

                Dim params As New Dictionary(Of String, Object)
                params.Add("date", dt)

                Dim where As New Dictionary(Of String, Object)
                If isS = False Then
                    where.Add("bonid", id)
                Else
                    where.Add("fctid", id)
                End If

                c.UpdateRecord(tableName, params, where)
            End Using

        Catch ex As Exception

        End Try
    End Sub
    Public Sub DeleteItem(ByRef i As Al_Mohasib.Items, ByVal id As System.Int32)

        Dim tableName As String = "DetailsFacture"
        Dim FC = "id"
        Dim isS As Boolean = CBool(Form1.RPl.isSell)
        If isS = False Then
            tableName = "DetailsBon"
            FC = "bid"
        End If

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim where As New Dictionary(Of String, Object)
            where.Add(FC, i.id)
            'where.Add("arid", i.id)

            If c.DeleteRecords(tableName, where) Then
                Form1.RPl.DeleteItems()
            End If

            'Stock
            Try
                If Form1.RPl.EditMode Then

                    Dim params As New Dictionary(Of String, Object)
                    params.Add("arid", i.arid)
                    params.Add("dpid", i.depot)

                    Dim dt = c.SelectDataTable("Detailstock", {"*"}, params)
                    params.Clear()
                    where.Clear()

                    Dim qte As Double = i.Qte
                    If isS Then qte *= -1

                    Dim dsid As Integer = dt.Rows(0).Item(0)
                    'If isS = False Then qte = qte * (-1)
                    qte = dt.Rows(0).Item("qte") - qte

                    params.Add("qte", qte)
                    where.Add("DSID", dsid)

                    c.UpdateRecord("Detailstock", params, where)

                    Form1.DGVARFA.SelectedRows(0).Cells(3).Value = Form1.RPl.Total_TTC
                    Form1.DGVARFA.SelectedRows(0).Cells(4).Value = Form1.RPl.Avance
                    Form1.DGVARFA.SelectedRows(0).Cells(5).Value = Form1.RPl.Tva

                    If isS Then AppendData(id, "Supression ", "-", i.Name)
                End If
            Catch ex As Exception

            End Try
        End Using
    End Sub
    Public Sub UpdatePayment(ByVal fctid As Integer, ByVal clientName As String, ByVal clid As Integer, ByVal isSell As Boolean,
                             ByVal editMode As Boolean, ByVal total As Double, ByRef avc As Double)
        Dim pay As New PayFacture
        pay.fctid = fctid
        pay.clid = clid
        pay.isSell = isSell
        pay.total = total
        pay.editMode = editMode
        pay.clientName = clientName
        pay.haManyPayement = Form1.cbMultiPayemnt.Checked


        If pay.ShowDialog = DialogResult.OK Then
        End If
        avc = pay.Avance
        If isSell Then AppendData(fctid, "Avance", "-", avc)
    End Sub
    Public Sub UpdatePaymentFromFacture(ByVal fctid As Integer, ByVal cname As String, ByVal clid As Integer, ByVal isSell As Boolean,
                                        ByVal total As Double, ByRef avc As Double, ByRef ispayed As Boolean, ByVal ID As Integer)
        Dim pay As New PayFacture
        pay.fctid = fctid
        pay.clid = clid
        pay.isSell = isSell
        pay.total = total
        pay.editMode = True
        pay.clientName = cname
        pay.haManyPayement = Form1.cbMultiPayemnt.Checked
        pay.DGV.Rows.Clear()

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

            avc = pay.Avance
            ispayed = CBool(pay.total <= pay.Avance)

            Dim params As New Dictionary(Of String, Object)
            params.Add("beInFacture", ID)
            Dim dt = c.SelectDataTable("Facture", {"*"}, params)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    pay.DGV.Rows.Add(True, dt.Rows(i).Item(0),
                                           dt.Rows(i).Item("total"),
                                           dt.Rows(i).Item("avance"),
                                           dt.Rows(i).Item("beInFacture"))
                Next
            End If

            If pay.ShowDialog = DialogResult.OK Then
            End If

            params.Clear()
            params.Add("payed", ispayed)

            Dim where As New Dictionary(Of String, Object)
            where.Add("fctid", fctid)

            c.UpdateRecord("Facture", params, where)

            If isSell Then AppendData(fctid, "Avance ", "-", pay.Avance)
        End Using

    End Sub
    Public Sub DeleteFacture(ByVal id As Integer, ByVal b As Boolean, ByVal editMode As Boolean, ByVal table As DataTable)
        Dim AAA As Boolean = False

        If Form1.RPl.EditMode And Form1.cbSuppression.Checked Then

            If Form1.admin = False Then Exit Sub

            If Form1.adminId > 1 Then
                Dim nmdg As New num
                If nmdg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                    Exit Sub
                End If
            End If
        End If

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim tableName = "Facture"
            If b = False Then tableName = "Bon"
            Dim params As New Dictionary(Of String, Object)

            params.Add("total", 0)
            params.Add("avance", 0)
            params.Add("admin", True)
            params.Add("payed", True)
            params.Add("tva", 0)
            params.Add("bl", 0)
            params.Add("date", "1/1/2000")
            Dim where As New Dictionary(Of String, Object)
            If b Then
                where.Add("fctid", id)
            Else
                where.Add("bonid", id)
            End If

            c.UpdateRecord(tableName, params, where)

            where.Clear()
            where.Add("fctid", id)

            tableName = "DetailsFacture"
            If b = False Then tableName = "DetailsBon"

            c.DeleteRecords(tableName, where)

            tableName = "Payment"
            If b = False Then
                tableName = "CompanyPayment"
                where.Clear()
                where.Add("bonid", id)
            End If

            c.DeleteRecords(tableName, where)

            params.Clear()
            where.Clear()

            'Stock
            If Form1.RPl.EditMode Then
                For i As Integer = 0 To table.Rows.Count - 1

                    Dim arid = table.Rows(i).Item("arid")
                    Dim dpid = table.Rows(i).Item("depot")
                    Dim cid = table.Rows(i).Item("cid")

                    If cid <> 0 Then

                        params.Add("arid", arid)
                        params.Add("dpid", dpid)

                        Dim dt = c.SelectDataTable("Detailstock", {"*"}, params)
                        params.Clear()

                        If dt.Rows.Count > 0 Then
                            Dim qte As Double = table.Rows(i).Item("qte")
                            Dim dsid As Integer = dt.Rows(0).Item(0)
                            If isSell = 0 Then qte = qte * (-1)
                            qte = qte + dt.Rows(0).Item("qte")

                            params.Add("qte", qte)
                            where.Add("DSID", dsid)

                            c.UpdateRecord("Detailstock", params, where)
                        Else
                            params.Add("arid", arid)
                            params.Add("dpid", dpid)
                            params.Add("qte", table.Rows(i).Item("qte"))
                            params.Add("unit", table.Rows(i).Item("unite"))
                            params.Add("cid", table.Rows(i).Item("cid"))

                            c.InsertRecord("Detailstock", params)
                        End If
                    Else
                        where.Add("arid", arid)
                        params.Add("cid", 0)

                        c.UpdateRecord("Article", params, where)
                    End If

                    params.Clear()
                    where.Clear()
                Next
            End If
            AAA = True
            If isSell Then AppendData(id, "Supression", "Toutes", "les articles")
        End Using

        ''Reflesh the datagridview and recept panel
        If AAA Then
            If editMode Then
                Form1.DGVARFA.Rows.Remove(Form1.DGVARFA.SelectedRows(0))
                Form1.RPl.ClearItems()
            Else
                For Each bt As Button In Form1.plright.Controls
                    If bt.Tag = id Then
                        Form1.plright.Controls.Remove(bt)
                        Exit For
                    End If
                Next
                Form1.RPl.ClearItems()
                If Form1.plright.Controls.Count > 0 Then
                    FactureSelected(Form1.plright.Controls(0), Nothing)
                End If
            End If
        End If



    End Sub

    Public Sub UpdateItemDepot(ByVal i As Items)
        Dim clc As New ChoseDepot
        If clc.ShowDialog = DialogResult.OK Then
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                Dim where As New Dictionary(Of String, Object)

                Dim dpt As Integer = CInt(clc.DataGridView1.SelectedRows(0).Cells(0).Value)
                If clc.Button1.Tag = 2 Then dpt = 0

                where.Add("id", CInt(i.id))
                params.Add("depot", dpt)

                Try
                    Dim h As Integer = c.UpdateRecord("DetailsFacture", params, where)
                    If h > 0 Then
                        If Form1.RPl.EditMode Then
                            params.Clear()
                            where.Clear()

                            params.Add("arid", i.arid)
                            params.Add("dpid", i.Depot)

                            Dim dt = c.SelectDataTable("Detailstock", {"*"}, params)
                            If dt.Rows.Count > 0 Then
                                Dim dsid As Integer = CInt(dt.Rows(0).Item(0))
                                Dim q As Double = CDbl(dt.Rows(0).Item("qte"))

                                q += i.Qte

                                params.Clear()
                                params.Add("qte", q)
                                where.Add("DSID", dsid)

                                c.UpdateRecord("Detailstock", params, where)
                            End If

                            If dpt > 0 Then
                                params.Clear()
                                where.Clear()

                                params.Add("arid", i.arid)
                                params.Add("dpid", dpt)

                                Dim dt2 = c.SelectDataTable("Detailstock", {"*"}, params)
                                If dt2.Rows.Count > 0 Then
                                    Dim dsid As Integer = CInt(dt2.Rows(0).Item(0))
                                    Dim q As Double = CDbl(dt2.Rows(0).Item("qte"))

                                    q -= i.Qte

                                    params.Clear()
                                    params.Add("qte", q)
                                    where.Add("DSID", dsid)

                                    c.UpdateRecord("Detailstock", params, where)
                                Else

                                    params.Clear()
                                    params.Add("qte", i.Qte * -1)
                                    params.Add("arid", i.arid)
                                    params.Add("dpid", i.Depot)
                                    params.Add("cid", i.cid)
                                    params.Add("unit", i.Unite)
                                    c.InsertRecord("Detailstock", params)
                                End If
                            End If
                        End If
                        Form1.RPl.ChangedItemsDepot(i.id, dpt)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End Using
        End If

    End Sub

    Public Sub AboutFactures(ByVal C As Boolean)
        Try
            Dim isSell As Boolean = CBool(Form1.btSwitch2.Tag)
            Dim price As Double = 0
            Dim tva As Double = 0
            Dim avance As Double = 0
            Dim NM As Integer = 0

            For i As Integer = 0 To Form1.DGVARFA.Rows.Count - 1
                tva += Form1.DGVARFA.Rows(i).Cells(5).Value
                price += Form1.DGVARFA.Rows(i).Cells(3).Value
                avance += Form1.DGVARFA.Rows(i).Cells(4).Value
                'tva = (tva * 100) / price
                NM += 1
            Next
            Dim table As New DataTable

            ' Create four typed columns in the DataTable.
            table.Columns.Add("id", GetType(Integer))
            table.Columns.Add("arid", GetType(Integer))
            table.Columns.Add("qte", GetType(Double))
            table.Columns.Add("name", GetType(String))
            table.Columns.Add("unit", GetType(String))
            table.Columns.Add("price", GetType(Double))
            table.Columns.Add("bprice", GetType(Double))
            table.Columns.Add("tva", GetType(Double))
            table.Columns.Add("poid", GetType(Integer))
            table.Columns.Add("cid", GetType(Integer))
            table.Columns.Add("depot", GetType(Integer))
            table.Columns.Add("code", GetType(String))


            If C Then
                Dim cs As Double = getCaisse()
                table.Rows.Add(0, -110, 1, "Caisse", "U", cs, cs, 0, 0, -110, 0, 0)
            End If

            Dim PRFT As Double = getProfit()
            table.Rows.Add(0, -111, 1, "Profit", "U", PRFT, PRFT, 0, 0, -110, 0, 0)
            table.Rows.Add(0, -112, 1, "Rest", "U", tva, tva, 0, 0, -110, 0, 0)
            table.Rows.Add(0, -113, 1, NM & "  FACTURES", "U", price, price, 0, 0, -110, 0, 0)

            Form1.RPl.ClearItems()


            Form1.RPl.FctId = 0
            Form1.RPl.ClientName = 0
            Form1.RPl.ClId = 0
            Form1.RPl.Avance = avance
            Form1.RPl.AddItems(table, isSell)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub UpdateBl(ByVal isS As Boolean)
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            Dim tableName = "Facture"
            If isS = False Then tableName = "Bon"

            Dim isPayed As Boolean = False
            If Form1.RPl.Avance >= Form1.RPl.Total_TTC Then isPayed = True


            'Facture
            Dim params As New Dictionary(Of String, Object)
            params.Add("remise", CInt(Form1.RPl.Remise))
            params.Add("total", CDbl(Form1.RPl.Total_TTC))
            params.Add("payed", isPayed)
            params.Add("tva", CDbl(Form1.RPl.Tva))


            Dim where As New Dictionary(Of String, Object)
            If isS Then
                where.Add("fctid", Form1.RPl.FctId)
            Else
                where.Add("bonid", Form1.RPl.FctId)
            End If

            c.UpdateRecord(tableName, params, where)

            params.Clear()
            where.Clear()

            If Form1.RPl.EditMode Then
                Form1.DGVARFA.SelectedRows(0).Cells(3).Value = Form1.RPl.Total_TTC
                Form1.DGVARFA.SelectedRows(0).Cells(5).Value = Form1.RPl.Tva
                Form1.DGVARFA.SelectedRows(0).Cells(4).Value = Form1.RPl.Avance
            End If



            params = Nothing
            where = Nothing
        End Using
    End Sub
    Public Sub BlockParticulerFct()
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            Dim tableName = "Facture"

            'Facture
            Dim params As New Dictionary(Of String, Object)
            params.Add("beInFacture", -5)

            Dim where As New Dictionary(Of String, Object)
            where.Add("[admin]=", True)
            where.Add("[clid]=", 0)
            where.Add("[date]<", Now.Date.AddDays(-5))
            where.Add("[beInFacture]=", 0)
            Dim a = c.UpdateRecordSymbols(tableName, params, where)

            params.Clear()
            where.Clear()

            params = Nothing
            where = Nothing
        End Using
    End Sub
    Public Function CheckForUnpaidFacture(ByVal clid As Integer, ByVal TP As Integer) As Boolean
        If Form1.CbDelaiFct.Checked = False Then Return True

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim dtt As Date = Now.Date.AddDays(-TP)
            Dim params As New Dictionary(Of String, Object)
            params.Add("clid = ", clid)
            params.Add("payed = ", False)
            params.Add("[admin] = ", True)
            params.Add("[date] < ", dtt)

            Dim dt = c.SelectDataTableSymbols("Facture", {"*"}, params)

            If dt.Rows.Count > 0 Then
                Dim str As String = "vous êtes pas autorisé d'ouvrir des nouveau factures ... "
                str = str + vbNewLine
                If Form1.admin Then str = str & " ce client a des factures non réglé (plus " & TP & "j)"
                str = str + vbNewLine
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim rest As Double = dt.Rows(i).Item("total") - dt.Rows(i).Item("avance")
                    str = str & dt.Rows(i).Item("date") & " | " & dt.Rows(i).Item("fctid") & " | " & rest
                    str = str + vbNewLine
                Next

                Dim strpath As String = Form1.BtImgPah.Tag & "\AllowClient"
                If Not Directory.Exists(strpath) Then
                    Directory.CreateDirectory(strpath)
                    MsgBox(str, MsgBoxStyle.OkOnly, vbExclamation)
                    Return False
                End If
                Dim savePath As String = Path.Combine(strpath, clid & "-Allowed.dat")
                Dim savePath2 As String = Path.Combine(strpath, clid & "-Auth.dat")
                If System.IO.File.Exists(savePath) Then
                    'The file exists
                    File.Delete(savePath)
                    Return True
                ElseIf System.IO.File.Exists(savePath2) Then
                    Return True
                End If

                MsgBox(str, MsgBoxStyle.OkOnly, vbExclamation)
                Return False
            End If
        End Using

        Return True
    End Function
    Public Function CheckForMinStock(ByVal arid As Integer, ByVal dpid As Integer, ByVal qte As Double) As Integer
        Dim result As Double = 0
        Dim MinStock As Double = 0
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add("arid", arid)
            Try
                MinStock = c.SelectByScalar("Article", "elements", params)
            Catch ex As Exception
                MinStock = 0
            End Try


            params.Add("dpid", dpid)
            Dim localStock As Double
            Try
                localStock = c.SelectByScalar("Detailstock", "qte", params)
            Catch ex As Exception
                localStock = 0
            End Try
 
            result = localStock + qte
            If Form1.RPl.isSell Then result = localStock - qte
        End Using

        If result > MinStock Then
            Return 0
        ElseIf result <= MinStock And result >= 0 Then
            Return 1
        Else
            Return 2
        End If
    End Function
    Public Function getStock(ByVal arid As Integer, ByVal dpid As Integer, ByVal qte As Double) As Double
        Dim result As Double = 0
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add("arid", arid)
            params.Add("dpid", dpid)
            Dim localStock As Double
            Try
                localStock = c.SelectByScalar("Detailstock", "qte", params)
            Catch ex As Exception
                localStock = 0
            End Try

            result = localStock + qte
            If Form1.RPl.isSell Then result = localStock - qte
        End Using
        Return result
    End Function
    Public Sub AutoCompleteArticles(ByRef txt As TextBox)
        ' auto complitae
        'Item is filled either manually or from database
        Dim lst As New List(Of String)

        'AutoComplete collection that will help to filter keep the records.
        Dim MySource As New AutoCompleteStringCollection()

        ' added some items
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim dt As DataTable = a.SelectDataTable("Client", {"*"})
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    lst.Add(dt.Rows(i).Item("name").ToString & "|" & dt.Rows(i).Item("Clid").ToString)
                Next
            End If
        End Using

        'Records binded to the AutocompleteStringCollection.
        MySource.AddRange(lst.ToArray)
        txt.AutoCompleteCustomSource = MySource

    End Sub
    Public Sub AutoCompleteArticles(ByRef txt As TxtBox, ByVal tableName As String)
        ' auto complitae
        'Item is filled either manually or from database
        Dim lst As New List(Of String)

        'AutoComplete collection that will help to filter keep the records.
        Dim MySource As New AutoCompleteStringCollection()

        ' added some items
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim dt As DataTable = a.SelectDataTable(tableName, {"*"})
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    lst.Add(dt.Rows(i).Item("name").ToString & "|" & dt.Rows(i).Item(0).ToString)
                Next
            End If
        End Using

        'Records binded to the AutocompleteStringCollection.
        MySource.AddRange(lst.ToArray)
        txt.AutoCompleteSource = MySource

    End Sub
    Public Sub ArticlesRepport(ByVal id As Integer, ByVal isSelling As Boolean, ByVal dt1 As Date, ByVal dt2 As Date, ByRef dgv As DataGridView, ByRef RPl As RPanel)

        Dim STA As New ALMohassinDBDataSetTableAdapters.DetailsFactureTableAdapter
        Dim BTA As New ALMohassinDBDataSetTableAdapters.DetailsBonTableAdapter

        dgv.Rows.Clear()
        Dim dt As DataTable = Nothing
        ' added some items
        Dim tQte As Decimal = 0
        Dim tbPrice As Decimal = 0
        Dim tsPrice As Decimal = 0
        Dim tTva As Double = 0

        If isSelling Then
            Try
                dt = STA.GetDataByDateETarid(id, dt1, dt2)
            Catch ex As Exception

            End Try

            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim bprice As Decimal = dt.Rows(i).Item("qte") * dt.Rows(i).Item("bprice")
                    Dim sprice As Decimal = dt.Rows(i).Item("qte") * dt.Rows(i).Item("price")

                    Dim dte As Date = CDate(dt.Rows(0).Item("date"))
                    dgv.Rows.Add(dte.ToString("dd MMMM yy"), dt.Rows(i).Item("fctid"), dt.Rows(i).Item("ClientName"),
                                                 String.Format("{0:n}", CDec(dt.Rows(i).Item("qte").ToString)),
                                                    String.Format("{0:n}", bprice),
                                                      String.Format("{0:n}", sprice),
                                                       String.Format("{0:n}", CDec(dt.Rows(i).Item("tva").ToString)))

                    tQte += CDec(dt.Rows(i).Item("qte"))
                    tbPrice += bprice
                    tsPrice += sprice
                    tTva += (sprice * dt.Rows(i).Item("tva") / 100)
                Next
                dt = Nothing
            End If
        Else
            Try
                dt = BTA.GetDataByDateEtArid(id, dt1, dt2)
            Catch ex As Exception
            End Try

            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    Dim bprice As Decimal = dt.Rows(i).Item("qte") * dt.Rows(i).Item("bprice")

                    Dim sprice As Decimal = 0 'dt.Rows(i).Item("qte") * dt.Rows(i).Item("price")

                    Dim dte As Date = CDate(dt.Rows(0).Item("date"))
                    dgv.Rows.Add(dte.ToString("dd MMMM yy"), dt.Rows(i).Item("fctid"), dt.Rows(i).Item("ClientName"),
                                                 dt.Rows(i).Item("qte"), bprice, sprice, dt.Rows(i).Item("tva"))

                    dgv.Rows.Add(dte.ToString("dd MMMM yy"), dt.Rows(i).Item("fctid"), dt.Rows(i).Item("ClientName"),
                             String.Format("{0:n}", CDec(dt.Rows(i).Item("qte").ToString)),
                                String.Format("{0:n}", bprice),
                                  String.Format("{0:n}", sprice),
                                   String.Format("{0:n}", CDec(dt.Rows(i).Item("tva").ToString)))

                    tQte += CDec(dt.Rows(i).Item("qte"))
                    tbPrice += bprice
                    tsPrice = 0 '+= sprice
                    tTva += (bprice * dt.Rows(i).Item("tva") / 100)
                Next
                dt = Nothing
            End If
        End If

        'show details in rpl
        Dim table As New DataTable

        ' Create four typed columns in the DataTable.
        table.Columns.Add("arid", GetType(Integer))
        table.Columns.Add("qte", GetType(Decimal))
        table.Columns.Add("name", GetType(String))
        table.Columns.Add("unit", GetType(String))
        table.Columns.Add("price", GetType(Decimal))
        table.Columns.Add("bprice", GetType(Decimal))
        table.Columns.Add("tva", GetType(Double))
        table.Columns.Add("poid", GetType(Integer))
        table.Columns.Add("cid", GetType(Integer))
        table.Columns.Add("depot", GetType(Integer))
        table.Columns.Add("code", GetType(String))

        Dim NM As Integer = dgv.Rows.Count
        table.Rows.Add(0, 1, "Total TVA", "U", tTva, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(1, 1, "Total Prix de vente", "U", tsPrice, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(2, 1, "Total Prix d achat", "U", tbPrice, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(3, 1, "Total Qté ", "U", tQte, 1, 0, 1, 0, 0, 0)
        table.Rows.Add(4, 1, NM & "  FACTURES", "U", NM, 1, 0, 1, 0, 0, 0)
        RPl.ClearItems()

        RPl.FctId = 0
        RPl.ClientName = 0
        RPl.ClId = 0
        RPl.Avance = 0
        RPl.AddItems(table, isSell)

        For Each it As Control In RPl.Controls
            If TypeOf it Is Items Then
                Dim itt As Items = CType(it, Items)
                itt.ShowDesc = False
            End If
        Next

        STA = Nothing
        BTA = Nothing

        STA.Dispose()
        BTA.Dispose()

    End Sub
    Public Sub UpdateClient(ByVal fid As Integer, ByVal isS As Boolean, ByVal EdtMode As Boolean)
        Dim chs As New ChoseClient
        chs.isSell = isS
        If chs.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim cid As String = chs.cid
            Dim clientname As String = chs.clientName
            Dim adresse As String = chs.clientadresse
            Dim tp As String = chs.tp

            If cid <> 0 And isS = True And tp <> 0 Then
                If tp = "" Then tp = "1"
                If CheckForUnpaidFacture(cid, tp) = False Then Exit Sub
            End If

            Using z As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim where As New Dictionary(Of String, Object)
                Dim tName As String = "Facture"
                If isS Then
                    where.Add("fctid", fid)
                Else
                    where.Add("bonid", fid)
                    tName = "Bon"
                End If


                Dim params As New Dictionary(Of String, Object)
                params.Add("clid", cid)
                params.Add("name", clientname)
                params.Add("adresse", adresse)
                z.UpdateRecord(tName, params, where)

                If EdtMode Then
                    Form1.DGVARFA.SelectedRows(0).Cells(2).Value = clientname
                    Form1.DGVARFA.SelectedRows(0).Cells(1).Value = cid
                    Form1.DGVARFA.SelectedRows(0).Cells(8).Value = adresse
                Else
                    Try
                        For Each b As Button In Form1.plright.Controls
                            If b.Tag = fid Then
                                b.Text = clientname
                                Form1.RPl.ClId = cid
                                Form1.RPl.ClientName = clientname
                                Form1.RPl.ClientAdresse = adresse
                            End If
                        Next
                    Catch ex As Exception
                    End Try
                End If
            End Using
        End If
    End Sub

    Public Sub UpdateValues(ByVal params As Dictionary(Of String, String))
        Dim VTA As New ALMohassinDBDataSetTableAdapters.valueTableAdapter
        For Each k As KeyValuePair(Of String, String) In params
            Try
                VTA.UpdateKeyVal(k.Value, k.Key)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub
    Public Function SelectValues(ByVal key As String, ByVal val As String) As String
        Dim VTA As New ALMohassinDBDataSetTableAdapters.valueTableAdapter

        Dim result As DataTable
        Try
            result = VTA.GetData(key)
            If result.Rows.Count > 0 Then
                Return result.Rows(0).Item(1)
            Else
                VTA.Insert(key, val)
                Return val
            End If
        Catch ex As Exception

        End Try
        Return val
    End Function
    Public Function getProfit() As Decimal

        Dim profit As Decimal = 0
        If isSell Then

            Dim ta As New ALMohassinDBDataSetTableAdapters.DetailsFactureTableAdapter
            For i As Integer = 0 To Form1.DGVARFA.Rows.Count - 1
                Dim fctid As Integer = Form1.DGVARFA.Rows(i).Cells(0).Value

                Dim dt = ta.GetData(fctid)

                If dt.Rows.Count > 0 Then
                    For t As Integer = 0 To dt.Rows.Count - 1

                        profit += (dt.Rows(t).Item("price") - dt.Rows(t).Item("bprice")) * dt.Rows(t).Item("qte")
                    Next
                End If
            Next
        End If
        Return profit
    End Function
    Public Function getCaisse() As Decimal

        Dim caisseTotal As Decimal = 0
        Dim dt As DataTable
        Dim tt As Decimal = 0

        If Form1.RPl.isSell Then

            Dim ta As New ALMohassinDBDataSetTableAdapters.PaymentTableAdapter
            Dim dt1 As Date = Form1.dte1.Value.AddDays(-1)
            Dim dt2 As Date = Form1.dte2.Value.AddDays(1)

            dt = ta.GetDataBydtcaisse(dt2.Date, dt1.Date)
        Else
            Dim ta As New ALMohassinDBDataSetTableAdapters.CompanyPaymentTableAdapter
            Dim dt1 As Date = CDate(Form1.dte1.Text).AddDays(-1)
            Dim dt2 As Date = CDate(Form1.dte2.Text).AddDays(1)

            dt = ta.GetDataBydtcaisse(dt2, dt1)
        End If


        'If dt.Rows.Count > 0 Then
        '    For t As Integer = 0 To dt.Rows.Count - 1
        '        caisseTotal += dt.Rows(t).Item("montant")
        '    Next
        'End If

        'Return caisseTotal
        Return dt.Rows(0).Item("total")

    End Function
    'Melange
    Public Function AutoCompleteMelange(ByVal p As String) As List(Of String)
        ' auto complitae
        'Item is filled either manually or from database
        Dim lst As New List(Of String)

        'AutoComplete collection that will help to filter keep the records.

        ' added some items
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add("mixte", True)
            params.Add("depot", p)

            Dim dt As DataTable = a.SelectDataTable("Article", {"*"}, params)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    lst.Add(dt.Rows(i).Item("name").ToString & " | " & dt.Rows(i).Item("arid").ToString)
                Next
            End If
        End Using
        Return lst
    End Function
    Public Sub Get_MedDesc(ByRef ap As AddPanel, ByVal key As String, ByVal p As String, ByRef al As AddList)
        Dim i As Boolean = False

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim arid As String = key.Split("|")(1)

            Dim params As New Dictionary(Of String, Object)
            params.Add("arid", arid)
            Dim field As String = "sprice"
            If ap.Val = "" Then ap.Val = 0
            Try
                ap.price = CStr(a.SelectByScalar("Article", field, params))
                field = "bprice"
                ap.bPrice = CStr(a.SelectByScalar("Article", field, params))

                al.price += ap.price * ap.Val
                al.bprice += ap.bPrice * ap.Val

            Catch ex As Exception
            End Try
        End Using
    End Sub
    Private Sub Mashine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim AD As New AddMelange
        Dim bt As Button = sender
        AD.p = bt.Tag
        If AD.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If

    End Sub
    
    Public Sub DeleteMelange(ByVal id As Integer)
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            Dim where As New Dictionary(Of String, Object)
            where.Add("arid", id)
            Dim elements As String = ""
            Try
                elements = c.SelectByScalar("Article", "elements", where)
                If elements = "" Or IsDBNull(elements) Then Exit Sub
            Catch ex As Exception
                Exit Sub
            End Try

            Dim DPID As String = c.SelectByScalar("Article", "depot", where)
            elements = elements.Substring(1, elements.Length - 2)
            Dim eleArr As String() = elements.Split("*")
            For i As Integer = 0 To eleArr.Length - 1
                Try
                    Dim arid As Integer = CInt(CStr(eleArr(i).Split("&")(0)).Split("|")(1))
                    Dim qte As String = CStr(eleArr(i).Split("&")(1))
                    where.Clear()
                    where.Add("arid", arid)
                    where.Add("dpid", DPID)

                    Dim CloseBoxQte As Double = c.SelectByScalar("Detailstock", "qte", where)
                    where.Clear()

                    qte += CloseBoxQte

                    Dim params As New Dictionary(Of String, Object)
                    params.Add("qte", qte)

                    where.Add("arid", arid)
                    where.Add("dpid", DPID)
                    c.UpdateRecord("Detailstock", params, where)

                    params.Clear()
                    where.Clear()
                Catch ex As Exception
                End Try
            Next
        End Using

    End Sub

    Public Function LaodUnPaidFactures() As Double
        Dim tt As Double = 0
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            Dim tableName As String = "Facture"
            If isSell = False Then tableName = "Bon"

            Dim params As New Dictionary(Of String, Object)
            params.Add("clid", Form1.RPl.ClId)
            params.Add("payed", False)
            params.Add("admin", True)

            Dim dt = c.SelectDataTable(tableName, {"*"}, params)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(i).Item(0) <> Form1.RPl.FctId Then
                        tt += dt.Rows(i).Item("total") - dt.Rows(i).Item("avance")
                    End If
                Next
            End If
        End Using

        Return tt
    End Function
    Public Sub StockValue()

        Dim ttvalue As Double = 0
        Form1.DGVS.Rows.Clear()
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim dtctg = c.SelectDataTable("Category", {"*"})

            For i As Integer = 0 To dtctg.Rows.Count - 1
                Dim ctgvalue As Decimal = 0
                Dim params As New Dictionary(Of String, Object)
                params.Add("cid", dtctg.Rows(i).Item(0))
                Dim dt = c.SelectDataTable("Detailstock", {"*"}, params)
                params.Clear()

                For r As Integer = 0 To dt.Rows.Count - 1
                    params.Add("arid", dt.Rows(r).Item("arid"))
                    Dim price As Decimal = c.SelectByScalar("Article", "bprice", params)
                    Dim qte As Decimal = dt.Rows(r).Item("qte")
                    ctgvalue += price * qte
                    params.Clear()
                Next

                Form1.DGVS.Rows.Add("", dtctg.Rows(i).Item("name").ToString,
                                    dt.Rows.Count & " Aricles",
                                     String.Format("{0:n}", ctgvalue) & "Dhs", " ")
                ttvalue += ctgvalue

            Next
            Form1.DGVS.Rows.Add("-------", "-------", "-------", "-------", " ")
            Form1.DGVS.Rows.Add("", "المجموع (Total)", dtctg.Rows.Count & " ctgs",
                                 String.Format("{0:n}", ttvalue) & "Dhs", " ")
        End Using
    End Sub
    'save the modification has made
    Public Sub AppendData(ByVal fctid As String, ByVal dt As DataTable)
        Try
            If Form1.chMasar.Checked = False Then Exit Sub
            Dim str As String = Form1.btDbDv.Tag
            Dim conString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & str & ";Persist Security Info=False;"

            Using c As DataAccess = New DataAccess(conString, True)
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim params As New Dictionary(Of String, Object)
                    params.Add("fctid", fctid)
                    params.Add("date", Now.Date)
                    params.Add("Designation", dt.Rows(i).Item("name"))
                    params.Add("Price", dt.Rows(i).Item("price"))
                    params.Add("Qte", dt.Rows(i).Item("qte"))
                    params.Add("writer", Form1.adminName)
                    params.Add("client", Form1.RPl.ClientName)

                    c.InsertRecord("historique", params)
                Next
            End Using
        Catch ex As Exception

        End Try

    End Sub
    Public Sub AppendData(ByVal fctid As String, ByVal desg As String, ByVal qte As String, ByVal price As String)
        Try
            If Form1.chMasar.Checked = False Then Exit Sub
            Dim str As String = Form1.btDbDv.Tag
            Dim conString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & str & ";Persist Security Info=False;"
            Using c As DataAccess = New DataAccess(conString, True)
                Dim params As New Dictionary(Of String, Object)
                params.Add("fctid", fctid)
                params.Add("date", Now.Date)
                params.Add("Designation", desg)
                params.Add("Price", price)
                params.Add("Qte", qte)
                params.Add("writer", Form1.adminName)
                params.Add("client", Form1.RPl.ClientName)

                c.InsertRecord("historique", params)
            End Using
        Catch ex As Exception

        End Try

    End Sub




#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
