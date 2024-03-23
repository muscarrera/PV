Imports System.IO
Imports System.Xml
Imports System.Threading.Tasks
Imports System.Data.OleDb

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
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim ctgdt = a.SelectDataTable("category", {"*"})

            Form1.FL.Controls.Clear()
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
                Form1.FL.Controls.Add(P)


                Dim params As New Dictionary(Of String, Object)
                params.Add("cid", cid)
                Dim artdt = a.SelectDataTable("Article", {"*"}, params)

                If artdt.Rows.Count = 0 Then
                    Dim lb As New Label

                    lb.ForeColor = Color.DarkGray
                    lb.Text = "لا يوجد اي سجل"
                    P.Controls.Add(lb)
                Else

                    'artdt.DefaultView.Sort = "sprice DESC"
                    'artdt = artdt.DefaultView.ToTable
                    Dim i As Integer = 0
                    For i = 0 To artdt.Rows.Count - 1

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
                        'Dim NM As String = String.Format("{0:n}", CDec(artdt.Rows(i).Item("sprice").ToString))
                        'bt.Text = "[" & NM & "] - " & artdt.Rows(i).Item("name").ToString
                        bt.Text = artdt.Rows(i).Item("name").ToString

                        bt.Name = "art" & i
                        bt.Tag = artdt.Rows(i)
                        bt.BackColor = cr
                        bt.TextAlign = ContentAlignment.BottomCenter
                        bt.Font = New Font("Arial", CInt(Form1.txtfntsize.Text), FontStyle.Bold)
                        bt.Height = Form1.txtlargebt.Text

                        If Form1.cbJnImgDb.Checked Then
                            Try
                                Dim arrImage() As Byte
                                arrImage = artdt.Rows(i).Item("img")
                                Dim mstream As New System.IO.MemoryStream(arrImage)
                                bt.BackgroundImage = Image.FromStream(mstream)
                                bt.BackgroundImageLayout = ImageLayout.Stretch
                            Catch ex As Exception
                                bt.BackgroundImage = My.Resources.AddFile_22
                            End Try
                        Else
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
                        End If



                        P.Controls.Add(bt)
                        bt.Dock = DockStyle.Top
                        AddHandler bt.Click, AddressOf art_click

                        If i = 33 Then Exit For
                    Next
                    P.Height = Form1.txtlargebt.Text * (i + 1)

                End If
            Next
        End Using
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

        Form1.PanelBody.Visible = False

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

            Dim params As New Dictionary(Of String, Object)
            params.Add("pr", 0)
            Dim ctgdt = a.SelectDataTable("category", {"*"}, params)

            Form1.FL.Controls.Clear()

            If F Then Form1.FLPStock.Controls.Clear()

            If ctgdt.Rows.Count = 1 Then
                Dim bt As New Button
                bt.Tag = ctgdt.Rows(0).Item("cid")
                ctg_click(bt, Nothing)
            Else
                FillDataSource_Cats(ctgdt, True)
            End If

            'Fill stock panel
            If F Then FillGrStock(ctgdt)
        End Using

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
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

            Dim params As New Dictionary(Of String, Object)
            params.Add("pr", c)
            Dim ctgdt = a.SelectDataTable("category", {"*"}, params)

            If ctgdt.Rows.Count > 0 Then FillDataSource_Cats(ctgdt, False)
        End Using
        If Form1.chbcb.Checked Then
            Form1.txtSearchCode.Text = ""
            Form1.txtSearchCode.Focus()
        Else
            Form1.txtSearch.Text = ""
            Form1.txtSearch.Focus()
        End If
        Form1.RPl.CP.Value = 0
    End Sub
    Public Sub FillMonGroupe(ByVal c As Integer)
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

            Dim params As New Dictionary(Of String, Object)
            params.Add("facture.clid", c)
            Dim artdt = a.SelectDataTable("((detailsfacture INNER JOIN facture ON detailsfacture.fctid = Facture.fctid) INNER JOIN article ON detailsfacture.arid = article.arid)",
                                          {"article.*"}, params)


            If artdt.Rows.Count = 0 Then
                Dim lb As New Label

                lb.ForeColor = Color.DarkGray
                lb.Text = "لا يوجد اي سجل"
                Form1.FL.Controls.Add(lb)
            Else
                Dim myLast = Form1.indexLastArticle
                'Fill Articles
                FillDataSource_Articles(artdt, 0, artdt.Rows.Count - 1, myLast)
            End If

        End Using

        If Form1.chbcb.Checked Then
            Form1.txtSearchCode.Text = ""
            Form1.txtSearchCode.Focus()
        Else
            Form1.txtSearch.Text = ""
            Form1.txtSearch.Focus()
        End If
        Form1.RPl.CP.Value = 0
    End Sub
    Public Sub FillMesCadeaux()
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

            If Form1.ListCadeau.Count = 0 Then Exit Sub

            Form1.FL.Controls.Clear()

            For Each __g In Form1.ListCadeau
                For Each cd In __g.startList
                    Dim bt As New PromoArticleBloc
                    'bt.BackgroundImageLayout = ImageLayout.Stretch
                    'bt.Visible = True
                    'bt.FlatStyle = FlatStyle.Flat
                    'bt.BackColor = Color.LightSeaGreen
                    'bt.Text = cd.name & "[Points : " & cd.point & "]"
                    bt.DataSource = cd
                    'bt.TextAlign = ContentAlignment.BottomCenter


                    bt.Width = 220 'Form1.txtlongerbt.Text
                    bt.Height = 120 'Form1.txtlargebt.Text
                    AddHandler bt.Choosed, AddressOf art_Cadeaux_click
                    Form1.FL.Controls.Add(bt)

                    Try
                        If Form1.RPl.FerstPointToWin >= cd.point Then Form1.RPl.FerstPointToWin = cd.point
                    Catch ex As Exception

                    End Try

                Next
            Next
            Form1.FL.Visible = True

        End Using

        If Form1.chbcb.Checked Then
            Form1.txtSearchCode.Text = ""
            Form1.txtSearchCode.Focus()
        Else
            Form1.txtSearch.Text = ""
            Form1.txtSearch.Focus()
        End If
        Form1.RPl.CP.Value = 0
    End Sub

    Public Sub FillGrStock(ByVal _ctgdt As DataTable)
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim ctgdt = a.SelectDataTable("category", {"*"})

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
        End Using
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

        Form1.FL.Controls.Clear()
        Try


            ' added some items
            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)

                Dim artdt2 As DataTable
                Dim artdt As DataTable

                '''''''''''''''''''

                If Form1.cbsearch.Text = "الاسم" Then
                    params.Add("name LIKE ", "%" & txt.Text & "%")
                    artdt = a.SelectDataTableSymbols("article", {"*"}, params)

                ElseIf Form1.cbsearch.Text = "الرمز" Then
                    params.Add("codebar LIKE ", "%" & txt.Text & "%")
                    artdt = a.SelectDataTableSymbols("article", {"*"}, params)

                ElseIf Form1.cbsearch.Text = "CodeStart" Then
                    params.Add("codebar LIKE ", txt.Text & "%")
                    artdt = a.SelectDataTableSymbols("article", {"*"}, params)

                ElseIf Form1.cbsearch.Text = "DirectR" Then
                    params.Add("codebar = ", txt.Text)
                    artdt = a.SelectDataTableSymbols("article", {"*"}, params)

                ElseIf Form1.cbsearch.Text = "التصنيف" Then
                    params.Add("name LIKE ", "%" & txt.Text & "%")
                    artdt = a.SelectDataTableSymbols("article", {"*"}, params)
                    params.Clear()

                    params.Add("codebar LIKE ", "%" & txt.Text & "%")
                    artdt2 = a.SelectDataTableSymbols("article", {"*"}, params)

                    artdt.Merge(artdt2, False)
                Else
                    params.Add("name LIKE ", "%" & txt.Text & "%")
                    artdt = a.SelectDataTableSymbols("article", {"*"}, params)
                    params.Clear()

                    params.Add("codebar LIKE ", "%" & txt.Text & "%")
                    artdt2 = a.SelectDataTableSymbols("article", {"*"}, params)

                    artdt.Merge(artdt2, False)
                End If

                If artdt.Rows.Count = 0 Then
                    Dim lb As New Label

                    lb.ForeColor = Color.DarkGray
                    lb.Text = "لا يوجد اي سجل"
                    Form1.FL.Controls.Add(lb)

                Else
                    Dim myLast = Form1.indexLastArticle

                    'Fill Articles
                    FillDataSource_Articles(artdt, 0, artdt.Rows.Count - 1, myLast)
                End If
            End Using

            txt.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
            txt.Focus()
        End Try
    End Sub
    Public Sub SearchForcodebar()
        Try
            Dim bt As New Button

            If Form1.cbPvArticle.Checked Then
                Dim pv As New PvArticle
                pv = Form1.FL.Controls(0)
                bt.Tag = pv.DataSource

            Else
                bt = Form1.FL.Controls(0)
            End If



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


            ' added some items
            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)


                Dim artdt As DataTable

                '''''''''''''''''''

                params.Add("codebar LIKE ", "%" & txt.Text & "%")
                artdt = a.SelectDataTableSymbols("article", {"*"}, params)

                If artdt.Rows.Count = 1 Then

                    Dim bt As New Button
                    bt.Tag = artdt.Rows(0)

                    art_click(bt, Nothing)
                    Form1.FocusedControle = Nothing '''''''Arrows
                ElseIf artdt.Rows.Count > 1 Then
                    Form1.FL.Controls.Clear()
                    Dim myLast = Form1.indexLastArticle
                    FillDataSource_Articles(artdt, 0, artdt.Rows.Count - 1, myLast)
                Else
                    Form1.FL.Controls.Clear()
                    Dim lb As New Label

                    Console.Beep()
                    Console.Beep()

                    Beep()

                    lb.ForeColor = Color.DarkGray
                    lb.Text = "لا يوجد اي سجل"
                    lb.Font = New Font("Arial", 14, FontStyle.Bold)
                    lb.ForeColor = Color.Red
                    lb.AutoSize = True
                    Form1.FL.Controls.Add(lb)
                    Form1.FocusedControle = Nothing '''''''Arrows
                End If
            End Using
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
            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)
                Dim artdt As DataTable

                '''''''''''''''''''
                params.Add("codebar", ref)
                params.Add("mixte", True)
                artdt = a.SelectDataTable("article", {"*"}, params)
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
                    Form1.FL.Controls.Clear()
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
                        Form1.FL.Controls.Add(bt)
                        'AddHandler bt.Click, AddressOf art_click
                        AddHandler bt.Click, AddressOf art_click

                        If i = 9 Then Exit For
                    Next
                Else
                    Form1.FL.Controls.Clear()
                    Dim lb As New Label


                    Console.Beep()
                    Console.Beep()
                    Console.Beep()

                    lb.ForeColor = Color.DarkGray
                    lb.Text = "لا يوجد اي سجل"
                    lb.Font = New Font("Arial", 14, FontStyle.Bold)
                    lb.ForeColor = Color.Red
                    lb.AutoSize = True
                    Form1.FL.Controls.Add(lb)
                End If
            End Using
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

    Public Sub ctg_click(ByVal sender As System.Object, ByVal e As EventArgs)

        Dim bt2 As Button = sender
        Form1.FL.Controls.Clear()

        If bt2.Tag = -300 Then
            If Form1.RPl.ClId > 0 Then FillMonGroupe(Form1.RPl.ClId)
            Exit Sub
        ElseIf bt2.Tag = -500 Then
            FillMesCadeaux()
            Exit Sub
        End If


        If bt2.Tag > 0 Then FillGroupesByCat(bt2.Tag)
        '   FillGroupesByCat_reader(bt2.Tag)

        Form1.btGoBack.Tag = bt2.Tag
        Try
            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)
                Dim artdt As DataTable

                '''''''''''''''''''
                params.Add("cid = ", bt2.Tag)
                artdt = a.SelectDataTableSymbols("article", {"*"}, params)
                Form1.FL.Tag = bt2.Tag


                If artdt.Rows.Count = 0 Then
                    Dim lb As New Label

                    lb.ForeColor = Color.DarkGray
                    lb.Text = "لا يوجد اي سجل"
                    Form1.FL.Controls.Add(lb)
                Else
                    Dim myLast = Form1.indexLastArticle
                    'Fill Articles
                    FillDataSource_Articles(artdt, 0, artdt.Rows.Count - 1, myLast)
                End If
            End Using

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
    Public Sub ctg_NEXT(ByVal sender As System.Object, ByVal e As EventArgs)
        Try
            Dim fn As Font = New Font(Form1.txtfname.Text, CInt(Form1.txtfntsize.Text), FontStyle.Bold)

            Dim bt2 As Button = sender
            Form1.FL.Controls.Clear()
            Dim artdt = bt2.Tag

            '''''''''''''''''''''''''''''''''''' go back
            If Form1.indexStartArticle > 0 Then
                Dim pv As New PvCat
                pv.DataSource = bt2.Tag
                pv.CatName = Form1.indexStartArticle & " Articles"
                pv.isPrev = True

                pv.Width = Form1.txtlongerbt.Text
                pv.Height = Form1.txtlargebt.Text
                pv.fnt = fn
                Form1.FL.Controls.Add(pv)
                AddHandler pv.Choosed, AddressOf ctg_BACK
            End If

            ''''''''''''''''''''''''''''''''''''
            Dim _END As Integer = Form1.indexStartArticle + Form1.indexLastArticle

            'Fill Articles
            FillDataSource_Articles(artdt, Form1.indexStartArticle, artdt.Rows.Count - 1, _END)

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
    Public Sub ctg_BACK(ByVal sender As System.Object, ByVal e As EventArgs)
        Try
            Dim fn As Font = New Font(Form1.txtfname.Text, CInt(Form1.txtfntsize.Text), FontStyle.Bold)

            Dim bt2 As Button = sender
            Form1.FL.Controls.Clear()
            Dim artdt = bt2.Tag

            Dim s As Integer = Form1.indexStartArticle
            Dim l As Integer = Form1.indexLastArticle
            '''''''''''''''''''''''''''''''''''' go back
            If s > l Then
                Dim pv As New PvCat
                pv.DataSource = bt2.Tag
                pv.CatName = Form1.indexStartArticle & " Articles"
                pv.isPrev = True

                pv.Width = Form1.txtlongerbt.Text
                pv.Height = Form1.txtlargebt.Text
                pv.fnt = fn
                Form1.FL.Controls.Add(pv)
                AddHandler pv.Choosed, AddressOf ctg_BACK
            End If

            ''''''''''''''''''''''''''''''''''''
            s -= l * 2
            If s < 0 Then s = 0

            Dim _END As Integer = s + l

            'Fill Articles
            FillDataSource_Articles(artdt, s, artdt.Rows.Count - 1, _END)

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

    Dim _isRightMouseClick As Boolean = False
    Private Sub art_click_Mouse_Down(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            _isRightMouseClick = True
            art_click(sender, Nothing)
        Else
            _isRightMouseClick = False
        End If
    End Sub
    Public Sub art_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim bt As Button = sender
        Dim R As DataRow = bt.Tag


        If My.Computer.Keyboard.CtrlKeyDown Then
            Try
                EditArticle(R)
            Catch ex As Exception
            End Try
            Exit Sub
        End If


        If Form1.isWorkingWithCatSelect Then
            If Form1.ls_CatSelect.Contains(R("cid")) = False Then
                Exit Sub
            End If
        End If



        Try
            ''add new bon
            If Form1.RPl.FctId = 0 Then
                If Form1.RPl.isSell Then
                    'Try
                    '    If Form1.isPortOn = False Then
                    '        Form1.isPortOn = Form1.OpenPort
                    '        Form1.RPl.CP.Value = Form1.txtQte.Text
                    '    End If

                    'Catch ex As Exception
                    'End Try

                    'If Form1.NouveauBon_Creation Then
                    Dim clientname As String = Form1.txtcltcomptoir.Text.Split("/")(0)
                    Dim cid As String = 0

                    NewFacture(cid, clientname, "", 0)

                    'Else
                    '    Form1.RPl.FctId = -198722
                    'End If
                Else
                    Exit Sub
                End If
            End If


            If Form1.CbDepotOrigine.Checked = False Then R("depot") = Form1.RPl.CP.Depot
            Dim catsMerg = Form1.txtMergeCat.Text.Split("-")

            If Form1.RPl.IsExiste(R("arid"), R("depot"), R("name")) = True And Form1.cbMergeArt.Checked = True And catsMerg.Contains(R("cid")) = False Then
                Dim item As Items = Form1.RPl.SelectedItems(R("arid"), R("depot"), R("name"))
                Dim ID As Integer = item.id
                Dim qte As Double = item.Qte + CDbl(Form1.RPl.CP.Value)

                Form1.RPl.ChangedItemsQte(R("arid"), R("depot"), qte)
                Form1.RPl.Pl.ScrollControlIntoView(item)

            Else
                Dim ppp As Double = CDbl(R("sprice"))


                If Form1.RPl.isSell Then
                    If Form1.cbOptionJenani.Checked = False Then
                        Select Case Form1.RPl.Num
                            Case 2
                                R("sprice") = R("sp3")
                            Case 3
                                R("sprice") = R("sp4")
                            Case 4
                                R("sprice") = R("sp5")
                        End Select
                    End If
                Else
                    R("sprice") = R("bprice")
                End If

                If Form1.CBTVA.Checked = False Then R("tva") = 20

                Try
                    R("codebar") = R("codebar").Split("-")(0)
                Catch ex As Exception
                    R("codebar") = ""
                End Try


                If Form1.RPl.isSell And Form1.RPl.ClId > 0 Then
                    'Last Price Option
                    If Form1.cbArtLastPrice.Text.StartsWith("LastPrice") Then


                        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                            Dim params As New Dictionary(Of String, Object)
                            Dim order As New Dictionary(Of String, String)

                            order.Add("Facture.fctid", "DESC")

                            Dim tb_A As String = "Facture"
                            Dim tb_D_A As String = "DetailsFacture"

                            params.Add(tb_A & ".clid  = ", Form1.RPl.ClId)
                            params.Add(tb_D_A & ".arid  = ", R("arid"))

                            Dim pDt As DataTable = c.SelectDataTableSymbols("(" & tb_D_A & " INNER JOIN " & tb_A & " ON " & tb_D_A & ".fctid = " & tb_A & ".fctid) ",
                                {tb_D_A & ".price," & tb_D_A & ".bprice, " & tb_D_A & ".rprice"}, params, order)

                            If pDt.Rows.Count > 0 Then

                                Dim prc As Double = pDt.Rows(0).Item("price")
                                Dim bp As Double = pDt.Rows(0).Item("bprice")
                                Dim rp As Double = pDt.Rows(0).Item("rprice")

                                If Form1.cbArtLastPrice.Text.EndsWith("PAX") Then
                                    If bp = R("bprice") Then
                                        R("sprice") = prc
                                    End If
                                ElseIf Form1.cbArtLastPrice.Text.EndsWith("PVX") Then
                                    If rp = R("sprice") Then
                                        R("sprice") = prc
                                    End If
                                Else
                                    If IsNumeric(prc) Then
                                        If prc > R("bprice") Or Form1.RPl.ClientName.Contains("**") Then
                                            R("sprice") = prc
                                        End If
                                    End If
                                End If
                            End If
                        End Using

                    ElseIf Form1.cbArtLastPrice.Text.StartsWith("LastMarge") Then

                        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                            Dim params As New Dictionary(Of String, Object)
                            Dim order As New Dictionary(Of String, String)

                            order.Add("Facture.fctid", "DESC")
                            Dim tb_A As String = "Facture"
                            Dim tb_D_A As String = "DetailsFacture"

                            params.Add(tb_A & ".clid  = ", Form1.RPl.ClId)
                            params.Add(tb_D_A & ".arid  = ", R("arid"))

                            Dim pDt As DataTable = c.SelectDataTableSymbols("(" & tb_D_A & " INNER JOIN " & tb_A & " ON " & tb_D_A & ".fctid = " & tb_A & ".fctid) ",
                                {tb_D_A & ".price," & tb_D_A & ".bprice, " & tb_D_A & ".rprice"}, params, order)
                            If pDt.Rows.Count > 0 Then

                                Dim bp As Double = pDt.Rows(0).Item("bprice")
                                Dim sp As Double = pDt.Rows(0).Item("price")


                                If Form1.cbArtLastPrice.Text.EndsWith("PV") Then
                                    bp = pDt.Rows(0).Item("rprice")

                                    If bp > 0 Then
                                        Dim mrg As Double = sp - bp
                                        R("sprice") += mrg
                                    Else
                                        bp = pDt.Rows(0).Item("bprice")
                                        If bp > 0 Then
                                            Dim mrg As Double = sp - bp
                                            R("sprice") = R("bprice") + mrg
                                        End If
                                    End If
                                ElseIf Form1.cbArtLastPrice.Text.EndsWith("PA") Then
                                    If bp > 0 Then
                                        Dim mrg As Double = sp - bp
                                        R("sprice") = R("bprice") + mrg
                                    End If

                                ElseIf Form1.cbArtLastPrice.Text.EndsWith("PAX") Then
                                    If bp = R("bprice") Then
                                        R("sprice") = sp
                                    End If
                                ElseIf Form1.cbArtLastPrice.Text.EndsWith("PVX") Then
                                    sp = pDt.Rows(0).Item("rprice")
                                    If bp = R("sprice") Then
                                        R("sprice") = sp
                                    End If
                                End If
                            End If
                        End Using
                    End If
                End If

                'Qte and Price Directly
                If Form1.cbQteCat.Checked Or Form1.cbPrixCat.Checked Or _isRightMouseClick Then
                    If setPriceOrQte(R) = False Then
                        Exit Sub
                    End If
                End If

                Dim qte As Double = CDbl(Form1.RPl.CP.Value)

                'tva

                R("sp5") = ppp
                Form1.RPl.AddItems(R)
                R("sprice") = ppp

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
    Public Sub art_Cadeaux_click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            Dim bt As Button = sender
            Dim R As PromosArticle = bt.Tag
            If Form1.RPl.FctId = 0 Then Exit Sub

            Dim p = R.point
            If Form1.RPl.TotalPoint + Form1.RPl.myPoint < p + Form1.RPl.usedPoint Then
                MsgBox("point cumuler est insuffisant")
                Exit Sub
            End If


            Form1.RPl.AddItemsCadeau(R, "Cadeaux")


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

    Private Function setPriceOrQte(ByRef R As DataRow)
        Dim ii As Integer = 0
        If Form1.cbQteCat.Checked Or _isRightMouseClick Then
            Try
                Dim cats = Form1.txtQteCat.Text.Split("-")
                If cats.Contains(R("cid").ToString) Or cats.Contains("*") Then
                    ii += 1
                End If
            Catch ex As Exception
                MsgBox("Error 4 : frth - model Multi-Prix")
            End Try
        End If

        If Form1.cbPrixCat.Checked Then
            Try
                Dim cats = Form1.txtPrixCat.Text.Split("-")
                If cats.Contains(R("cid").ToString) Or cats.Contains("*") Then
                    ii += 2
                End If
            Catch ex As Exception
                MsgBox("Error 4 : frth - model Multi-Prix")
            End Try
        End If

        If ii > 0 Then
            Dim bn As New byname

            bn.lbName.Text = R("name")
            bn.BTp1.Text = Math.Round(CDbl(R("sprice")), 2)
            bn.txtPrice.text = Math.Round(CDbl(R("sprice")), 2)
            bn.BTp2.Text = Math.Round(CDbl(R("sp3")), 2)
            bn.BTp3.Text = Math.Round(CDbl(R("sp4")), 2)
            bn.BTp4.Text = Math.Round(CDbl(R("sp5")), 2)
            bn.BTACH.Text = Math.Round(CDbl(R("bprice")), 2)

            bn.ii = ii

            If bn.ShowDialog = DialogResult.OK Then

                If ii = 1 Then
                    Form1.RPl.CP.Value = bn.qte
                ElseIf ii = 2 Then
                    R("sprice") = bn.qte
                Else
                    Form1.RPl.CP.Value = bn.qte
                    R("sprice") = CDbl(bn.txtPrice.text)
                End If

            Else
                Return False
            End If

        End If
        Return True
    End Function
    Public Sub fillFactures(ByVal a As Integer)
        Dim dt As DataTable = Nothing
        Dim p As Panel = Form1.plright
        Dim b As Button = Nothing
        p.Controls.Clear()
        Form1.RPl.ClearItems()
        Form1.RPl.isUniqTva = Form1.CBTVA.Checked

        Dim tableName As String = Form1.TB_Bon


        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add("admin", False)
            'Dim order As New Dictionary(Of String, String)
            'order.Add("fctid", "DESC")

            If Form1.cbAffichageLimite.Checked Then params.Add("writer", Form1.adminName)
            dt = c.SelectDataTable(tableName, {"*"}, params)
        End Using

        If dt.Rows.Count > 0 Then
            FillDataSource_Bon(dt, p)
        Else
            If Form1.isPortOn Then
                Form1.isPortOn = Form1.ClosePort
                Form1.RPl.CP.Value = 0
            End If
        End If

        Form1.txtSearch.Text = ""
        Form1.txtSearchCode.Text = ""

        If Form1.chbcb.Checked Then
            Form1.txtSearchCode.Focus()
        Else
            Form1.txtSearch.Focus()
        End If
    End Sub
    'Fill Articles
    Private Sub FillDataSource_Articles(ByVal artdt As DataTable, ByVal iStart As Integer, ByVal iEnd As Integer, ByVal myLast As Integer)
        Dim fn As Font = New Font(Form1.txtfname.Text, CInt(Form1.txtfntsize.Text), FontStyle.Bold)
        ' Form1.FlowLayoutPanel1.Visible = False
        Form1.FL.SuspendLayout()

        For i As Integer = iStart To iEnd
            If i = artdt.Rows.Count Then
                Form1.indexStartArticle = i '- Form1.indexLastArticle
                Exit For
            End If

            If Form1.cbUseStar.Checked Then
                If Form1.adminName.Contains("*") Then
                    If StrValue(artdt, "codebar", i).Contains("*") = False Then
                        myLast += 1
                        Continue For
                    End If
                Else
                    If StrValue(artdt, "codebar", i).Contains("*") Then
                        myLast += 1
                        Continue For
                    End If
                End If
            End If


            If Form1.isWorkingWithCatSelect Then
                If Form1.ls_CatSelect.Contains(artdt.Rows(i).Item("cid")) = False Then
                    Continue For
                End If
            End If


            Form1.FocusedControle = Nothing
            ''''''''''''''''''''''''''''''''''''
            If Form1.cbPvArticle.Checked Then
                Dim pv As New PvArticle
                pv.DataSource = artdt.Rows(i)

                pv.Width = Form1.txtlongerbt.Text
                pv.Height = Form1.txtlargebt.Text
                pv.fnt = fn
                Form1.FL.Controls.Add(pv)
                AddHandler pv.Choosed, AddressOf art_click
                AddHandler pv.MousseDown, AddressOf art_click_Mouse_Down

            Else


                Dim bt As New Button
                bt.BackgroundImageLayout = ImageLayout.Stretch
                bt.Visible = True
                bt.FlatStyle = FlatStyle.Flat
                bt.BackColor = Color.LightSeaGreen
                bt.Text = artdt.Rows(i).Item("name").ToString
                bt.Name = "art" & i
                bt.Tag = artdt.Rows(i)
                bt.TextAlign = ContentAlignment.BottomCenter
                Try
                    If Form1.cbJnImgDb.Checked Then
                        Try
                            Dim arrImage() As Byte
                            arrImage = artdt.Rows(i).Item("img")
                            Dim mstream As New System.IO.MemoryStream(arrImage)

                            bt.BackgroundImage = Image.FromStream(mstream)
                            bt.BackgroundImageLayout = ImageLayout.Stretch
                        Catch ex As Exception
                            bt.BackgroundImage = My.Resources.AddFile_22
                        End Try
                    Else
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
                    End If

                Catch ex As Exception
                    bt.Text = artdt.Rows(i).Item("name").ToString
                End Try

                bt.Width = Form1.txtlongerbt.Text
                bt.Height = Form1.txtlargebt.Text
                Form1.FL.Controls.Add(bt)
                AddHandler bt.Click, AddressOf art_click
                AddHandler bt.MouseDown, AddressOf art_click_Mouse_Down

                ''''''''''''''''''''''''''''''''''''''''''''''''''' list suivant
            End If

            If i = myLast Then
                Dim pv As New PvCat
                pv.DataSource = artdt
                pv.CatName = (artdt.Rows.Count - i) & " Articles"

                pv.isNext = True
                pv.Width = Form1.txtlongerbt.Text
                pv.Height = Form1.txtlargebt.Text
                pv.fnt = fn
                Form1.FL.Controls.Add(pv)
                AddHandler pv.Choosed, AddressOf ctg_NEXT

                Form1.indexStartArticle = myLast
                Exit For
            End If
        Next
        ' Form1.FlowLayoutPanel1.Visible = True
        Form1.FL.ResumeLayout()
    End Sub
    Private Sub FillDataSource_Cats(ByVal ctgdt As DataTable, ByVal b As Boolean)
        Dim fn As Font = New Font(Form1.txtfname.Text, CInt(Form1.txtfntsize.Text), FontStyle.Bold)

        Form1.FL.Visible = False

        'article pour client
        If Form1.cbArticleClient.Checked And b Then
            If Form1.cbPvCats.Checked Then
                Dim pv As New PvCat
                pv.CID = -300
                pv.CatName = "Mon Grp"
                pv.Width = Form1.txtlongerbt.Text
                pv.Height = Form1.txtlargebt.Text
                pv.fnt = fn
                'Form1.FlowLayoutPanel1.Controls.Add(pv)
                AddHandler pv.Choosed, AddressOf ctg_click
                Form1.FL.Controls.Add(pv)

                Dim pv2 As New PvCat
                pv2.CID = -500
                pv2.CatName = "CADEAUX"
                pv2.Width = Form1.txtlongerbt.Text
                pv2.Height = Form1.txtlargebt.Text
                pv2.fnt = fn
                'Form1.FlowLayoutPanel1.Controls.Add(pv)
                AddHandler pv2.Choosed, AddressOf ctg_click
                Form1.FL.Controls.Add(pv2)
            Else
                Dim btM As New Button
                btM.BackColor = Color.LightGoldenrodYellow
                btM.Text = "Mon Grp"
                btM.Name = "ctgMongrp"
                btM.Tag = -300
                btM.Width = Form1.txtlongerbt.Text
                btM.Height = Form1.txtlargebt.Text
                AddHandler btM.Click, AddressOf ctg_click
                Form1.FL.Controls.Add(btM)

                Dim btc As New Button
                btc.BackColor = Color.LightGoldenrodYellow
                btc.Text = "CADEAUX"
                btc.Name = "ctgMongrpcAD"
                btc.Tag = -500
                btc.Width = Form1.txtlongerbt.Text
                btc.Height = Form1.txtlargebt.Text
                AddHandler btc.Click, AddressOf ctg_click
                Form1.FL.Controls.Add(btc)
            End If
        End If






        If Form1.cbPvCats.Checked Then
            ''''''''''''''''''''''''''''''''''''
            Dim pvs(ctgdt.Rows.Count - 1) As PvCat
            For i As Integer = 0 To ctgdt.Rows.Count - 1

                If Form1.isWorkingWithCatSelect Then
                    If Form1.ls_CatSelect.Contains(ctgdt.Rows(i).Item(0)) = False Then
                        Continue For
                    End If
                End If



                Dim pv As New PvCat
                pv.CID = ctgdt.Rows(i).Item(0)
                pv.CatName = ctgdt.Rows(i).Item("name")
                pv.img = StrValue(ctgdt, "img", i)

                pv.Width = Form1.txtlongerbt.Text
                pv.Height = Form1.txtlargebt.Text
                pv.fnt = fn
                'Form1.FlowLayoutPanel1.Controls.Add(pv)
                AddHandler pv.Choosed, AddressOf ctg_click
                pvs(i) = pv


            Next
            Form1.FL.Controls.AddRange(pvs)

            Dim pva As New PvCat
            pva.CID = -0
            pva.CatName = "Melange"
            pva.Width = Form1.txtlongerbt.Text
            pva.Height = Form1.txtlargebt.Text
            pva.fnt = fn
            'Form1.FlowLayoutPanel1.Controls.Add(pv)
            AddHandler pva.Choosed, AddressOf ctg_click
            Form1.FL.Controls.Add(pva)

        Else
            ''''''''''''''''''''''''''''''''''''''''''''''''''' list suivant
            Dim pvs(ctgdt.Rows.Count - 1) As Button
            For i As Integer = 0 To ctgdt.Rows.Count - 1
                If Form1.isWorkingWithCatSelect Then
                    If Form1.ls_CatSelect.Contains(ctgdt.Rows(i).Item(0)) = False Then
                        Continue For
                    End If
                End If

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

                ' Form1.FlowLayoutPanel1.Controls.Add(bt)
                pvs(i) = bt

            Next
            Form1.FL.Controls.AddRange(pvs)

            Dim btc As New Button
            btc.BackColor = Color.LightGoldenrodYellow
            btc.Text = "Melange"
            btc.Name = "ctgMongrpcADMLG"
            btc.Tag = -0
            btc.Width = Form1.txtlongerbt.Text
            btc.Height = Form1.txtlargebt.Text
            AddHandler btc.Click, AddressOf ctg_click
            Form1.FL.Controls.Add(btc)
        End If

        Form1.FL.Visible = True

    End Sub
    Public Sub FillDataSource_Bon(ByVal dt As DataTable, ByVal p As Panel)

        Dim b As New Button
        b.Tag = 0

        For i As Integer = 0 To dt.Rows.Count - 1
            If Form1.cbPvClient.Checked Then
                Dim pv As New CBlock
                pv.ID = dt.Rows(i).Item(0)
                pv.lb.Text = dt.Rows(i).Item("name")
                pv.Dock = DockStyle.Left
                AddHandler pv.Choosed, AddressOf FactureSelected
                AddHandler pv.Delete, AddressOf PvClient_DeleteBon
                p.Controls.Add(pv)
            Else
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
                bt.Font = New Font("Arial", 9, FontStyle.Bold)
                bt.Dock = DockStyle.Left
                bt.AutoSize = True
                bt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
                bt.TextAlign = ContentAlignment.MiddleLeft
                AddHandler bt.Click, AddressOf FactureSelected

                p.Controls.Add(bt)
                'clear the recept liste

            
                bt = Nothing
                rnd = Nothing
            End If

            If i = 0 Then
                b.Tag = dt.Rows(i).Item(0)
                b.Text = dt.Rows(i).Item("name")
            End If


            If Form1.lbListBon.Tag = dt.Rows(i).Item(0) Then
                b.Tag = dt.Rows(i).Item(0)
                b.Text = dt.Rows(i).Item("name")
            End If
        Next
        Form1.lbListBon.Text = "[" & dt.Rows.Count & "] Recept(s)"
        Form1.lbListBon.Tag = dt.Rows.Count

        Form1.RPl.ClearItems()


        FactureSelected(b, Nothing)
    End Sub
    Public Sub AddDataSource_BonPatis(ByVal txt As String, ByVal p As Panel)
        Dim str As String = txt.Remove(0, 3)
        Dim bt As New Button
        bt.Text = txt
        bt.Tag = str
         

        If Form1.cbPvClient.Checked Then
            Dim pv As New CBlock
            pv.ID = str
            pv.lb.Text = str
            pv.Dock = DockStyle.Left
            AddHandler pv.Choosed, AddressOf FactureSelected
            AddHandler pv.Delete, AddressOf PvClient_DeleteBon
            p.Controls.Add(pv)
        Else
            Dim rnd As New Random
            Try
                bt.Tag = str
                bt.Text = txt
            Catch ex As Exception
            End Try

            bt.BackColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255)) 'Color.DarkSlateGray
            bt.FlatStyle = FlatStyle.Flat
            bt.ForeColor = Color.White
            bt.Font = New Font("Arial", 9, FontStyle.Bold)
            bt.Dock = DockStyle.Left
            bt.AutoSize = True
            bt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
            bt.TextAlign = ContentAlignment.MiddleLeft
            AddHandler bt.Click, AddressOf FactureSelected

            p.Controls.Add(bt)
            'clear the recept liste



            rnd = Nothing
        End If
         
        'Form1.RPl.ClearItems()


        FactureSelected(bt, Nothing)
        bt = Nothing
    End Sub

    Private Sub EditArticle(ByVal R As DataRow)

        Dim art As New AddEditArticle
        art.editMode = True
        art.id = R("arid")

        art.PlPrice.Visible = Form1.chbsell.Checked
        If art.ShowDialog = Windows.Forms.DialogResult.OK Then
            Form1.txtSearch.Text = R("codebar")
            SearchForArticles(Form1.txtSearch, R("cid"))
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
    Public Sub ctg_stock_click(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim bt2 As Button = sender
        Form1.DGVS.DataSource = Nothing

        Dim dpt As Integer = Form1.RPl.CP.Depot
        If Form1.CbDepotOrigine.Checked Then dpt = Form1.cbdepot.SelectedValue


        dpt = Form1.cbdepot.SelectedValue


        Try
            ' Dim artta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter

            Dim sdt As DataTable
            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)

                Dim tb_A As String = "article"
                Dim tb_D_A As String = "detailstock"
                params.Add(tb_D_A & ".dpid =", dpt)
                params.Add(tb_D_A & ".cid =", bt2.Tag)

                '                SELECT        Article.codebar, Article.name, Article.unite, Detailstock.qte, Detailstock.arid, Detailstock.DSID
                'FROM            (Detailstock INNER JOIN
                '                         Article ON Detailstock.arid = Article.arid)
                'WHERE        (Detailstock.dpid = ?) AND (Detailstock.cid = ?)

                sdt = a.SelectDataTableSymbols("(" & tb_D_A & " INNER JOIN " & tb_A & " ON " & tb_D_A & ".arid = " & tb_A & ".arid) ",
                    {tb_A & ".codebar, " & tb_A & ".name, " & tb_A & ".unite, " & tb_D_A & ".qte, " &
                        tb_D_A & ".arid, " & tb_D_A & ".dpid, " & tb_D_A & ".DSID"}, params)


            End Using


            If sdt.Rows.Count = 0 Then
                MsgBox("لا يوجد اي سجل", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "المخزن")
            Else
            
                Form1.DGVS.DataSource = sdt

                Form1.DGVS.Columns(0).Visible = False
                Form1.DGVS.Columns(4).Visible = False
                Form1.DGVS.Columns(6).Visible = False

                Form1.DGVS.Columns(3).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
                Form1.DGVS.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Form1.DGVS.Columns(1).HeaderText = "Designation"
                Form1.DGVS.Columns(3).HeaderText = "Qte Stk"
                Form1.DGVS.Columns(5).HeaderText = "Depot N°"
                Form1.DGVS.Columns(2).HeaderText = "Unite"


                Form1.DGVS.Columns(3).DefaultCellStyle.Format = "n2"
            End If
            Form1.btTransfert.Tag = bt2.Tag
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
                        params.Add("writer", Form1.adminName)
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
    Public Sub loadStrdBon(ByVal Txt As String)
        Try
            Dim strpath As String = Form1.BtImgPah.Tag & "\StrdBon"
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
                        params.Add("writer", Form1.adminName)
                        params.Add("tp", 1)
                        params.Add("payed", False)
                        params.Add("poid", 0)
                        params.Add("num", 0)
                        params.Add("tva", 0)
                        params.Add("adresse", "")
                        params.Add("bl", "---")
                        params.Add("remise", 0)
                        params.Add("beInFacture", 0)

                        fid = c.InsertRecord("Bon", params, True)
                        If fid > 0 Then

                            If avance > 0 Then
                                params.Clear()

                                params.Add("name", "_")
                                params.Add("comid", clientId)
                                params.Add("montant", avance)
                                params.Add("way", "Cache")
                                params.Add("date", Format(Now.Date, "dd-MM-yyyy"))
                                params.Add("Num", "")
                                params.Add("bonid", fid)
                                params.Add("writer", CStr(Form1.adminName))

                                Dim Pid = c.InsertRecord("CompanyPayment", params, True)
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

                                    c.InsertRecord("DetailsBon", params)
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
                            File.Delete(loadPath)

                            FillGroupes(True)
                            If isSell Then AppendData(fid, "Creation de la Bon ", "APP", "TABLETE")
                            bt = Nothing
                            rnd = Nothing
                        End If
                    End Using
                End If
            Catch ex As Exception
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub
    ' create new fact
    Public Sub NewFacture(ByVal t As Integer)
        Dim __is As Boolean = True

        If Form1.cbBadgeClt.Checked Then
            __is = False
            Try
                Dim sc As New UserParmissionCheck
                sc.bName.Text = "List Clients/Fournisseur"
                sc.lbNum.Text = "Creation nouveau bon"
                If sc.ShowDialog = DialogResult.OK Then
                    __is = True
                End If
            Catch ex As Exception
                __is = False
            End Try
        End If

        If __is = False Then Exit Sub




        Try
            Dim chs As New ChoseClient
            chs.isSell = Form1.RPl.isSell
            chs.editMode = True 'Form1.RPl.EditMode

            Dim p As Panel = Form1.plright

            If chs.ShowDialog = Windows.Forms.DialogResult.OK Then

                If Form1._isMohssineMode Then
                    If chs.cid > 0 Then

                        If Form1.cbPvClient.Checked Then
                            For Each b As CBlock In Form1.plright.Controls
                                If CStr(b.lb.Text) = chs.clientName Then
                                    MsgBox("هذا الزبون لديه ايصال مفتوح", MsgBoxStyle.OkOnly, "Bons")
                                    Dim bt As New Button
                                    bt.Tag = b.ID
                                    bt.Text = chs.clientName
                                    FactureSelected(bt, Nothing)

                                    If Form1.chbcb.Checked Then
                                        Form1.txtSearchCode.Text = ""
                                        Form1.txtSearchCode.Focus()
                                    Else
                                        Form1.txtSearch.Text = ""
                                        Form1.txtSearch.Focus()
                                    End If

                                    Exit Sub
                                End If
                            Next
                        Else
                            For Each b As Button In Form1.plright.Controls
                                If CStr(b.Text) = chs.clientName Then
                                    MsgBox("هذا الزبون لديه ايصال مفتوح", MsgBoxStyle.OkOnly, "Bons")

                                    FactureSelected(b, Nothing)

                                    If Form1.chbcb.Checked Then
                                        Form1.txtSearchCode.Text = ""
                                        Form1.txtSearchCode.Focus()
                                    Else
                                        Form1.txtSearch.Text = ""
                                        Form1.txtSearch.Focus()
                                    End If

                                    Exit Sub
                                End If
                            Next
                        End If

                    End If
                End If


                If chs.isEditing Then
                    fillFactures(CInt(Form1.btswitsh.Tag))
                Else
                    NewFacture(chs.cid, chs.clientName, chs.clientadresse, chs.num)
                End If

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
            Try
                saveChanges()
            Catch ex As Exception
            End Try

            Try
                If Form1.isPortOn = False Then
                    Form1.isPortOn = Form1.OpenPort
                End If

            Catch ex As Exception
            End Try


            Dim p As Panel = Form1.plright
            Dim cid As String = clid
            Dim clientname As String = cn
            Dim clientadesse As String = cad
            Dim tp As String = 0
            Dim num As String = nm
            Dim fid As Integer = 0
            Dim dte As Date = Date.Now

            If cid <> 0 And tp <> 0 Then
                If tp = "" Then tp = "1"
                If CheckForUnpaidFacture(cid, tp) = False Then Exit Sub
            End If

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)
                params.Add("clid", cid)
                params.Add("name", clientname)
                params.Add("total", 0)
                params.Add("avance", 0)
                params.Add("date", dte) 'Format(dte, "dd-MM-yyyy HH:mm"))
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
                params.Add("caisse", Form1.caisseId)
                'params.Add("delivredDay", Now.Date.AddDays(2))

                fid = c.InsertRecord(Form1.TB_Bon, params, True)
            End Using


            If fid > 0 Then

                If Form1.cbPvClient.Checked Then
                    Dim pv As New CBlock
                    pv.ID = fid
                    pv.lb.Text = clientname
                    pv.Dock = DockStyle.Left
                    AddHandler pv.Choosed, AddressOf FactureSelected
                    AddHandler pv.Delete, AddressOf PvClient_DeleteBon
                    p.Controls.Add(pv)

                Else
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

                    If isSell Then AppendData(fid, "Creation de la Bon", "-", "-")
                    bt = Nothing
                    rnd = Nothing

                End If

                Dim b As New Button
                b.Tag = fid
                b.Text = clientname
                Form1.lbListBon.Text = "[" & CInt(Form1.lbListBon.Tag) + 1 & "] Recept(s)"
                Form1.lbListBon.Tag = CInt(Form1.lbListBon.Tag) + 1

                'clear the recept liste
                Form1.RPl.ClearItems()
                FactureSelected(b, Nothing)
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
    Public Sub saveChanges()
        If Form1.RPl.FctId = 0 Then Exit Sub
        If Form1.RPl.FctId = -198722 Then NewFacture__0(True)

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            Dim prId_str = "id"
            If Form1.RPl.isSell = False Then prId_str = "bid"

            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            Dim data = Form1.RPl.DataSource
            For i As Integer = 0 To data.Rows.Count - 1

                params.Clear()
                params.Add("fctid", Form1.RPl.FctId)
                params.Add("name", data.Rows(i).Item("name"))
                params.Add("bprice", data.Rows(i).Item("bprice"))
                params.Add("price", data.Rows(i).Item("price"))
                params.Add("unit", data.Rows(i).Item("unit"))
                params.Add("qte", data.Rows(i).Item("qte"))
                params.Add("tva", data.Rows(i).Item("tva"))
                params.Add("arid", data.Rows(i).Item("arid"))
                params.Add("depot", data.Rows(i).Item("depot"))
                params.Add("poid", CInt(data.Rows(i).Item("poid")))
                params.Add("code", data.Rows(i).Item("code"))
                params.Add("cid", data.Rows(i).Item("cid"))
                params.Add("rprice", data.Rows(i).Item("rprice"))
                params.Add("caisse", Form1.caisseId)
                Dim prId As Integer = data.Rows(i).Item("id")

                If prId > 0 Then
                    where.Clear()
                    where.Add(prId_str, prId)
                    c.UpdateRecord(Form1.TB_Details, params, where)
                Else
                    c.InsertRecord(Form1.TB_Details, params)
                End If
            Next
        End Using
    End Sub
    Public Function NewFacture__0(ByVal a As Boolean) As Boolean
        Try
            Dim p As Panel = Form1.plright
            Dim cid As String = 0
            Dim clientname As String = Form1.txtcltcomptoir.Text
            Dim clientadesse As String = ""
            Dim tp As String = 0
            Dim num As String = ""
            Dim fid As Integer = 0
            Dim dte As Date = Now

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)
                params.Add("clid", cid)
                params.Add("name", clientname)
                params.Add("total", 0)
                params.Add("avance", 0)
                params.Add("date", dte) 'Format(dte, "dd-MM-yyyy HH:mm"))
                params.Add("admin", False)
                params.Add("writer", CStr(Form1.adminName))
                params.Add("tp", tp)
                params.Add("payed", False)
                params.Add("poid", 0)
                params.Add("num", num)
                params.Add("tva", 0)
                params.Add("adresse", clientadesse)
                params.Add("bl", "---")
                If isSell Then
                    params.Add("bc", "---")
                    params.Add("liv", "---")
                End If
                params.Add("remise", 0)
                params.Add("beInFacture", 0)
                params.Add("caisse", Form1.caisseId)
                'params.Add("delivredDay", Now.Date.AddDays(2))

                fid = c.InsertRecord(Form1.TB_Bon, params, True)
            End Using


            If fid > 0 Then

                If a Then
                    If Form1.cbPvClient.Checked Then

                        Dim pv As New CBlock
                        pv.ID = fid
                        pv.lb.Text = clientname
                        pv.Dock = DockStyle.Left
                        AddHandler pv.Choosed, AddressOf FactureSelected
                        AddHandler pv.Delete, AddressOf PvClient_DeleteBon
                        p.Controls.Add(pv)

                    Else
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
                    End If
                End If

                Form1.RPl.FctId = fid
                Form1.RPl.ClientName = clientname
                Form1.RPl.ClientAdresse = ""
                Form1.RPl.Dte = Now

                If isSell Then AppendData(fid, "Creation de la Bon", "-", "-")

                Return True

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return False
    End Function

    Public Function saveChanges_fct() As Boolean
        If Form1.RPl.FctId = 0 Then Return False
        If Form1.RPl.FctId = -198722 Then If NewFacture__0(False) = False Then Return False

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            Dim prId_str = "id"
            If Form1.RPl.isSell = False Then prId_str = "bid"

            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            Dim data = Form1.RPl.DataSource


            For i As Integer = 0 To data.Rows.Count - 1

                params.Clear()
                params.Add("fctid", Form1.RPl.FctId)
                params.Add("name", data.Rows(i).Item("name"))
                params.Add("bprice", data.Rows(i).Item("bprice"))
                params.Add("price", data.Rows(i).Item("price"))
                params.Add("unit", data.Rows(i).Item("unit"))
                params.Add("qte", data.Rows(i).Item("qte"))
                params.Add("tva", data.Rows(i).Item("tva"))
                params.Add("arid", data.Rows(i).Item("arid"))
                params.Add("depot", data.Rows(i).Item("depot"))
                params.Add("poid", CInt(data.Rows(i).Item("poid")))
                params.Add("code", data.Rows(i).Item("code"))
                params.Add("cid", data.Rows(i).Item("cid"))
                params.Add("rprice", data.Rows(i).Item("rprice"))
                params.Add("caisse", Form1.caisseId)
                Dim prId As Integer = data.Rows(i).Item("id")

                If prId > 0 Then
                    where.Clear()
                    where.Add(prId_str, prId)
                    c.UpdateRecord(Form1.TB_Details, params, where)
                Else
                    Dim pid = c.InsertRecord(Form1.TB_Details, params, True)

                    Dim a As Items
                    For Each a In Form1.RPl.Pl.Controls()
                        If prId = a.id Then
                            a.id = pid
                            Exit For
                        End If
                    Next

                End If
            Next
            Return True
        End Using

    End Function
    Public Sub NewFactureWatcher(ByVal g As PvModel)
        Try
            Dim tableName As String = "Facture"
            Dim p As Panel = Form1.plright
            Dim cid As String = 0
            Dim clientname As String = Form1.txtcltcomptoir.Text.Split("/")(0)
            Dim clientadesse As String = ""
            Dim tp As String = 0
            Dim num As String = 0
            Dim fid As Integer = 0
            Dim dte As Date = Date.Now

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                params.Add("clid", cid)
                params.Add("name", clientname)
                params.Add("total", 0)
                params.Add("avance", 0)
                params.Add("date", Format(dte, "dd-MM-yyyy HH:mm"))
                params.Add("admin", False)
                params.Add("writer", CStr(Form1.adminName))
                params.Add("tp", tp)
                params.Add("payed", False)
                params.Add("poid", 0)
                params.Add("num", num)
                params.Add("tva", 0)
                params.Add("adresse", clientadesse)
                params.Add("bl", g.bl)
                params.Add("remise", 0)
                params.Add("beInFacture", 0)
                params.Add("caisse", Form1.caisseId)
                'params.Add("delivredDay", Now.Date.AddDays(2))

                fid = c.InsertRecord(tableName, params, True)

                tableName = "DetailsFacture"

                If fid > 0 Then
                    For Each r As Article In g.DataSource
                        Dim prr As Double = r.sprice

                        Try
                            params.Clear()
                            params.Add("arid", CInt(r.arid))
                            prr = c.SelectByScalar("Article", "sprice", params)
                        Catch ex As Exception
                        End Try


                        params.Clear()

                        params.Add("fctid", fid)
                        params.Add("name", r.name)
                        params.Add("bprice", CDbl(r.bprice))
                        params.Add("price", prr)
                        params.Add("unit", r.unite)
                        params.Add("qte", r.qte)
                        params.Add("tva", r.TVA)
                        params.Add("poid", 0)
                        params.Add("arid", CInt(r.arid))
                        params.Add("depot", r.depot)
                        params.Add("code", r.ref)
                        params.Add("cid", CStr(r.cid))

                        c.InsertRecord(tableName, params, True)
                    Next

                    If Form1.cbPvClient.Checked Then
                        Dim pv As New CBlock
                        pv.ID = fid
                        pv.lb.Text = clientname
                        pv.Dock = DockStyle.Left
                        AddHandler pv.Choosed, AddressOf FactureSelected
                        AddHandler pv.Delete, AddressOf PvClient_DeleteBon
                        p.Controls.Add(pv)

                    Else
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

                        bt = Nothing
                        rnd = Nothing
                    End If
                End If
            End Using


            Dim b As New Button
            b.Tag = fid
            Form1.lbListBon.Text = "[" & CInt(Form1.lbListBon.Tag) + 1 & "] Recept(s)"
            Form1.lbListBon.Tag = CInt(Form1.lbListBon.Tag) + 1

            'clear the recept liste
            Form1.RPl.ClearItems()
            FactureSelected(b, Nothing)

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
    Public Sub NewFactureServerDriver(ByVal g As PvModel)
        Try
            Dim tableName As String = "Bon"
            Dim cid As String = 0
            Dim clientname As String = "Alimentation Stock"
            Dim clientadesse As String = ""
            Dim tp As String = 0
            Dim num As String = 0
            Dim fid As Integer = 0
            Dim dte As Date = Date.Now

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                Dim where As New Dictionary(Of String, Object)

                params.Add("clid", cid)
                params.Add("name", clientname)
                params.Add("total", 0)
                params.Add("avance", 0)
                params.Add("date", Format(dte, "dd-MM-yyyy HH:mm"))
                params.Add("admin", True)
                params.Add("writer", CStr(Form1.adminName))
                params.Add("tp", tp)
                params.Add("payed", False)
                params.Add("poid", 0)
                params.Add("num", num)
                params.Add("tva", 0)
                params.Add("adresse", clientadesse)
                params.Add("bl", g.fctId)
                params.Add("remise", 0)
                params.Add("beInFacture", 0)
                params.Add("caisse", Form1.caisseId)
                fid = c.InsertRecord(tableName, params, True)

                tableName = "DetailsBon"

                If fid > 0 Then
                    For Each r As Article In g.DataSource

                        params.Clear()

                        params.Add("fctid", fid)
                        params.Add("name", r.name)
                        params.Add("bprice", CDbl(r.bprice))
                        params.Add("price", r.sprice)
                        params.Add("unit", r.unite)
                        params.Add("qte", r.qte)
                        params.Add("tva", r.TVA)
                        params.Add("poid", 0)
                        params.Add("arid", CInt(r.arid))
                        params.Add("depot", r.depot)
                        params.Add("code", r.ref)
                        params.Add("cid", CStr(r.cid))

                        c.InsertRecord(tableName, params, True)
                        params.Clear()
                        where.Clear()

                        If True Then
                            where.Add("arid", r.arid)
                            params.Add("bprice", r.bprice)
                            params.Add("sprice", r.sprice)
                            params.Add("name", r.name)

                            c.UpdateRecord("Article", params, where)
                            params.Clear()
                            where.Clear()
                        End If
                         

                        where.Add("arid", r.arid)
                        where.Add("dpid", r.depot)

                        Dim dt = c.SelectDataTable("Detailstock", {"*"}, where)
                        where.Clear()

                        If dt.Rows.Count > 0 Then
                            Dim qte As Double = r.qte
                            Dim dsid As Integer = dt.Rows(0).Item(0)

                            qte = qte + dt.Rows(0).Item("qte")

                            params.Add("qte", qte)
                            where.Add("DSID", dsid)

                            c.UpdateRecord("Detailstock", params, where)
                        Else
                            Dim qte As Double = r.qte
                          
                            params.Add("arid", r.arid)
                            params.Add("dpid", r.depot)
                            params.Add("qte", qte)
                            params.Add("unit", r.unite)
                            params.Add("cid", r.cid)

                            c.InsertRecord("Detailstock", params)
                        End If
                        params.Clear()
                        where.Clear()
                    Next
                End If
            End Using

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
    Public Sub NewArticleServerDriver(ByVal g As Article)
        Try
            Dim tableName As String = "Article"
          
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                Dim where As New Dictionary(Of String, Object)

                params.Add("cid", g.cid)
                params.Add("name", g.name)
                params.Add("img", g.img)
                params.Add("bprice", g.bprice)
                params.Add("sprice", g.sprice)
                params.Add("unite", g.unite)
                params.Add("qte", g.qte)
                params.Add("codebar", g.ref)
                params.Add("tva", g.TVA)
                params.Add("sp3", g.sprice)
                params.Add("sp4", g.sprice)
                params.Add("sp5", g.sprice)
                params.Add("poid", 1)
                params.Add("depot", g.depot)
                params.Add("mixte", True)
                params.Add("elements", "")
                params.Add("isMixte", True)

                If g.arid = 0 Then
                    c.InsertRecord(tableName, params)
                Else
                    where.Add("arid", g.arid)
                    c.UpdateRecord(tableName, params, where)
                End If


            End Using

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
    Public Sub NewCategoryServerDriver(ByVal g As Article)
        Try
            Dim tableName As String = "Category"
        
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                Dim where As New Dictionary(Of String, Object)

                params.Add("name", g.name)
                params.Add("img", g.img)
                params.Add("pr", g.bprice)


                If g.arid = 0 Then
                    c.InsertRecord(tableName, params)
                Else
                    where.Add("cid", g.arid)
                    c.UpdateRecord(tableName, params, where)
                End If

            End Using

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
            'params.Add("Clid", cid)
            params.Add("code", cid)

            Try
                dt = c.SelectDataTable(Form1.TB_Client, {"*"}, params)
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

   
            Dim cl = "cid"
            Dim fc = "fctid"
            If isS = False Then fc = "bonid"


            Dim dte As Date = Date.Now
            Dim params As New Dictionary(Of String, Object)

            If Form1.RPl.ClId = 0 And isS And Form1.cbCaisse.Checked = False Then
                Dim mnt As Double = total - avance
                If Form1.RPl.delivredDay = "" Or Form1.RPl.delivredDay = "-" Or Form1.RPl.delivredDay = "0" Then
                    params.Add("name", "--")
                    params.Add(cl, 0)
                    params.Add("montant", mnt)
                    params.Add("way", "Cache")
                    params.Add("fctid", id)
                    params.Add("date", dte)
                    params.Add("writer", Form1.adminName)
                    params.Add("caisse", Form1.caisseId)
                    c.InsertRecord(Form1.TB_Payement, params)
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
            params.Add("bl", Form1.RPl.bl)
            params.Add("bc", Form1.RPl.bc)
            params.Add("liv", Form1.RPl.livreur)

            Dim where As New Dictionary(Of String, Object)

            where.Add(fc, id)

            c.UpdateRecord(Form1.TB_Bon, params, where)
            params.Clear()
            where.Clear()

            'Stock
            'If Form1.RPl.delivredDay = "" Or Form1.RPl.delivredDay = "0" Then
            For i As Integer = 0 To table.Rows.Count - 1

                Dim arid As Integer = table.Rows(i).Item(0)
                Dim dpid As Integer = table.Rows(i).Item("depot")
                Dim cid As Integer = table.Rows(i).Item("cid")
                Dim freeqte As Double = table.Rows(i).Item("freeQte")

                params.Clear()



                If freeqte > 0 And isSell Then

                    params.Add("fctid", Form1.RPl.FctId)
                    params.Add("name", table.Rows(i).Item("name") & " [Gratuits]")
                    params.Add("bprice", table.Rows(i).Item("bprice"))
                    params.Add("price", 0)
                    params.Add("unit", table.Rows(i).Item("unit"))
                    params.Add("qte", freeqte)
                    params.Add("tva", table.Rows(i).Item("tva"))
                    params.Add("arid", table.Rows(i).Item("arid"))
                    params.Add("depot", table.Rows(i).Item("depot"))
                    params.Add("poid", CInt(table.Rows(i).Item("poid")))
                    params.Add("code", table.Rows(i).Item("id"))
                    params.Add("cid", -600)
                    params.Add("rprice", table.Rows(i).Item("rprice"))
                    params.Add("caisse", Form1.caisseId)

                    c.InsertRecord(Form1.TB_Details, params)
                End If

                params.Clear()
                where.Clear()

                If cid <> 0 Then

                    where.Add("arid", arid)
                    where.Add("dpid", dpid)

                    Dim dt = c.SelectDataTable("Detailstock", {"*"}, where)
                    where.Clear()
                    Dim old_Qte As Double = 0

                    If dt.Rows.Count > 0 Then
                        Dim qte As Double = table.Rows(i).Item("qte") + freeqte
                        Dim dsid As Integer = dt.Rows(0).Item(0)
                        old_Qte = dt.Rows(0).Item("qte")
                        If isS Then qte = qte * (-1)
                        qte = qte + old_Qte

                        params.Add("qte", qte)
                        where.Add("DSID", dsid)

                        c.UpdateRecord("Detailstock", params, where)
                    Else
                        Dim qte As Double = table.Rows(i).Item("qte") + freeqte
                        If isS Then qte = qte * (-1)

                        params.Add("arid", arid)
                        params.Add("dpid", dpid)
                        params.Add("qte", qte)
                        params.Add("unit", table.Rows(i).Item("unite"))
                        params.Add("cid", table.Rows(i).Item("cid"))

                        c.InsertRecord("Detailstock", params)
                    End If



                    If isS = False Then

                        params.Clear()
                        where.Clear()

                        'update bprice
                        If CDbl(table.Rows(i).Item("bprice")) <> CDbl(table.Rows(i).Item("price")) Then

                            If Form1.cbBprice.Text = "DPA" Then
 
                                params.Add("bprice", table.Rows(i).Item("price"))
                                where.Add("arid", arid)
                                c.UpdateRecord("Article", params, where)


                            ElseIf Form1.cbBprice.Text = "CUMP" Then
                                Try
                                    If old_Qte < 0 Then old_Qte = 0
                                    Dim b As Double = table.Rows(i).Item("bprice") * old_Qte
                                    b += table.Rows(i).Item("price") * table.Rows(i).Item("qte")
                                    b /= old_Qte + table.Rows(i).Item("qte")

                                    params.Add("bprice", b)
                                    where.Add("arid", arid)
                                    c.UpdateRecord("Article", params, where)
                                Catch ex As Exception
                                End Try
                            End If
                        End If
                    End If


                    params.Clear()
                    where.Clear()
                Else

                    If Form1._isMahfoud Then
                        where.Clear()
                        params.Clear()
                        where.Add("arid", arid)
                        params.Add("cid", -100)
                        c.UpdateRecord("Article", params, where)
                    End If

                    params.Clear()
                    where.Clear()
                End If
            Next
            'End If

            Form1.lbLastBon.Text = "<< " & Form1.RPl.FctId & "   ->   " & Form1.RPl.ClientName & " [ " & Form1.RPl.LbSum.Text & "dhs  ]"
            Form1.lbLastBon.Tag = Form1.RPl.FctId
            Form1.btPrint_Top.Visible = True

            Try
                If Form1.cbPromos.Checked And isS Then
                    params.Clear()
                    where.Clear()
                    where.Add("fctid", id)
                    c.DeleteRecords("promo", where)

                    params.Add("cid", Form1.RPl.ClId)
                    params.Add("fctid", id)
                    params.Add("pointIN", Form1.RPl.myPoint)
                    params.Add("pointOUT", Form1.RPl.usedPoint)
               
                    c.InsertRecord("promo", params)
                End If
            Catch ex As Exception
            End Try

            If Form1.cbCafeMode.Checked And Form1.cbCafeTable.Checked Then
                params.Clear()
                where.Clear()

                params.Add("CIN", 0)
                where.Add("Clid", Form1.RPl.ClId)
                c.UpdateRecord("Client", params, where)
            End If

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
                Dim pr As Double = table.Rows(i).Item("price")

                Dim field = "sprice"
                If fd = 2 Then field = "sp3"
                If fd = 3 Then field = "sp4"
                If fd = 4 Then field = "sp5"

                params.Clear()
                where.Clear()
                where.Add("arid", arid)
                pr = c.SelectByScalar("Article", field, where)

                params.Clear()
                where.Clear()

                If id > 0 Then
                    params.Add("price", pr)
                    where.Add("id", id)
                    c.UpdateRecord(Form1.TB_Details, params, where)
                Else

                    params.Add("fctid", Form1.RPl.FctId)
                    params.Add("name", table.Rows(i).Item("name"))
                    params.Add("bprice", table.Rows(i).Item("bprice"))
                    params.Add("price", pr)
                    params.Add("unit", table.Rows(i).Item("unit"))
                    params.Add("qte", table.Rows(i).Item("qte"))
                    params.Add("tva", table.Rows(i).Item("tva"))
                    params.Add("arid", table.Rows(i).Item("arid"))
                    params.Add("depot", table.Rows(i).Item("depot"))
                    params.Add("poid", table.Rows(i).Item("poid"))
                    params.Add("code", table.Rows(i).Item("code"))
                    params.Add("cid", table.Rows(i).Item("cid"))

                    c.InsertRecord(Form1.TB_Details, params)
                End If
            Next

            'End If
            params.Clear()
            where.Clear()
            params.Add("num", fd)
            where.Add("fctid", Form1.RPl.FctId)
            Form1.RPl.Num = fd
            c.UpdateRecord(Form1.TB_Bon, params, where)

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

            c.UpdateRecord(Form1.TB_Bon, params, where)

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
                If Form1.cbPromos.Checked And isS Then
                    params.Clear()
                    params.Add("pointIN", rpl.myPoint)
                    params.Add("pointOUT", rpl.usedPoint)
                    where.Clear()
                    where.Add("fctid", rpl.FctId)
                    c.UpdateRecord("promo", params, where)
                End If
            Catch ex As Exception
            End Try


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

            'Facture
            Dim params As New Dictionary(Of String, Object)
            params.Add("total", 0)
            params.Add("admin", False)
            params.Add("payed", False)
            params.Add("writer", Form1.adminName)

            Dim where As New Dictionary(Of String, Object)
            If Form1.RPl.isSell = True Then
                where.Add("fctid", id)
            Else
                where.Add("bonid", id)
            End If

            c.UpdateRecord(Form1.TB_Bon, params, where)

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

        Try
            saveChanges()
        Catch ex As Exception
        End Try

        Dim bt As Button = sender
        Dim pl As Panel = Form1.plright
        Dim rnd As New Random

        Dim fld As String = "fctid"
        If Form1.btswitsh.Tag = 0 Then fld = "bonid"


        Dim fctid As Integer = 0
        Dim clientName As String = ""

        If Form1.cbPvClient.Checked Then
            For Each b As CBlock In pl.Controls
                If CStr(b.ID) = CStr(bt.Tag) Then
                    fctid = b.ID
                    clientName = b.lb.Text
                    b.isActive = True
                    b.SendToBack()
                Else
                    b.isActive = False
                End If
            Next 
        Else
            Try
                For Each b As Button In pl.Controls
                    b.BackColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255)) 'Color.DarkSlateGray
                    b.ForeColor = Color.White
                Next

                bt.BackColor = Color.White
                bt.ForeColor = Color.DarkSlateGray
                fctid = bt.Tag
                clientName = bt.Text
                bt.SendToBack()
            Catch ex As Exception

            End Try

        End If
         
        Form1.lbListBon.Text = Form1.lbListBon.Text.Split("|")(0) & "  |  " & clientName
        Form1.lbListBon.Tag = fctid

        'clear the recept liste
        Form1.RPl.ClearItems()
        Form1.RPl.FctId = fctid
        Form1.RPl.ClientName = clientName
        Form1.RPl.isSell = CBool(Form1.btswitsh.Tag)
        Form1.RPl.EditMode = False

        'GET AVANCE OF THIS FACTURE
        'fill the recept items
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add(fld, CInt(bt.Tag))
            Dim dt = c.SelectDataTable(Form1.TB_Bon, {"*"}, params)

            If dt.Rows.Count > 0 Then
                Form1.RPl.Avance = dt.Rows(0).Item("avance")
                Form1.RPl.ClId = dt.Rows(0).Item("clid")
                Form1.RPl.Num = 0
                Form1.RPl.delivredDay = dt.Rows(0).Item("tp")
                If Form1.chbsell.Checked Then Form1.RPl.Num = dt.Rows(0).Item("num")
                Try

                    Form1.RPl.ClientAdresse = dt.Rows(0).Item("adresse")
                    Form1.RPl.bl = dt.Rows(0).Item("bl")
                    Form1.RPl.bc = dt.Rows(0).Item("bc")
                    Form1.RPl.livreur = dt.Rows(0).Item("liv")

                    Try
                        Form1.RPl.Dte = dt.Rows(0).Item("date")
                    Catch ex As Exception

                        Dim where As New Dictionary(Of String, Object)
                        where.Add("date", Now)
                        c.UpdateRecord(Form1.TB_Bon, where, params)
                        Form1.RPl.Dte = Now
                    End Try



                Catch ex As Exception
                    Form1.RPl.ClientAdresse = ""
                End Try

                Try
                    Form1.RPl.Remise = dt.Rows(0).Item("remise")
                Catch ex As Exception
                    Form1.RPl.Remise = "0"
                End Try

            End If
             
               
            params.Clear()

            params.Add("fctid", CInt(bt.Tag))
            Dim order As New Dictionary(Of String, String)
            If Form1.RPl.isSell Then
                order.Add("id", "ASC")
            Else
                order.Add("bid", "ASC")
            End If

            dt = c.SelectDataTable(Form1.TB_Details, {"*"}, params, order)

            If dt.Rows.Count > 0 Then
                Form1.RPl.AddItems(dt, CBool(Form1.btswitsh.Tag))
            End If


            Try
                Form1.RPl.TotalPoint = 0
                If Form1.cbPromos.Checked And Form1.RPl.isSell And Form1.RPl.ClId > 0 Then
                    params.Clear()
                    params.Add("cid = ", Form1.RPl.ClId)
                    params.Add("fctid <> ", fctid)
                    Dim dtPoint = c.SelectDataTableSymbols("promo", {"(SUM(pointIN) - SUM(pointOUT)) AS points"}, params)

                    If dtPoint.Rows.Count > 0 Then
                        Form1.RPl.TotalPoint = dtPoint.Rows(0).Item("points")
                    End If
                End If
            Catch ex As Exception
                Form1.RPl.TotalPoint = 0
            End Try


            End Using


            Form1.txtSearch.Text = ""
            Form1.txtSearchCode.Text = ""

            If Form1.chbcb.Checked Then
                Form1.txtSearchCode.Focus()
            Else
                Form1.txtSearch.Focus()
            End If

            rnd = Nothing
    End Sub

    Public Sub FillTables()
        Form1.PanelBody.Controls.Clear()
        Form1.PanelBody.Visible = True
        Form1.PanelBody.Dock = DockStyle.Fill



        Dim rnd As New Random
        Dim PL1 As New FlowLayoutPanel



        PL1.Name = "PL1"
        PL1.BackColor = Color.AliceBlue
        PL1.Height = Form1.txtlargebt.Text + 10
        Form1.PanelBody.Controls.Add(PL1)
        PL1.Dock = DockStyle.Top
        PL1.SendToBack()


        Dim ARR As String() = {"Intérieur", "Extérieur", "Emporter"}
        For I As Integer = 0 To 2
            Dim bt As New Button
            bt.Tag = I + 1
            bt.Text = ARR(I)
            bt.FlatStyle = FlatStyle.Flat
            bt.ForeColor = Color.Black
            bt.BackColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255))
            bt.Font = New Font("Arial", 16, FontStyle.Bold)
            bt.Dock = DockStyle.Left
            bt.AutoSize = True
            bt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
            bt.TextAlign = ContentAlignment.MiddleCenter
            bt.Width = Form1.txtlongerbt.Text
            bt.Height = Form1.txtlargebt.Text

            AddHandler bt.Click, AddressOf LoadTables
            PL1.Controls.Add(bt)
        Next

        Dim PL2 As New FlowLayoutPanel

        PL2.Name = "PL2"
        PL2.AutoScroll = True
        Form1.PanelBody.Controls.Add(PL2)
        PL2.Dock = DockStyle.Fill
        PL2.BringToFront()

        LoadTables(PL1.Controls(0), Nothing)

        rnd = Nothing
        PL1 = Nothing
        PL2 = Nothing
    End Sub
    Public Sub LoadTables(ByVal sender As Object, ByVal e As EventArgs)
        Dim btt As Button = sender
        Dim fpl As FlowLayoutPanel = Form1.PanelBody.Controls(0)

        fpl.Controls.Clear()

        Dim dt As DataTable = Nothing
        Dim rnd As New Random

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add("type", btt.Tag)

            dt = c.SelectDataTable("Client", {"*"}, params)
        End Using

        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1

                Dim bt As New Button
                Dim cr As Color = Color.WhiteSmoke

                If (i Mod 2) = 0 Then cr = Color.LightGray

                Try
                    If Not IsNumeric(dt.Rows(i).Item("CIN")) Then
                        dt.Rows(i).Item("CIN") = 0
                    End If
                Catch ex As Exception
                    dt.Rows(i).Item("CIN") = 0
                End Try 

                Try
                    bt.Tag = dt.Rows(i).Item(0) & "|" & dt.Rows(i).Item("CIN")
                    bt.Text = dt.Rows(i).Item("name")
                Catch ex As Exception

                End Try

                bt.FlatStyle = FlatStyle.Flat
                bt.ForeColor = Color.Black

                If dt.Rows(i).Item("CIN") <> 0 Then
                    cr = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255)) 'Color.DarkSlateGray
                    bt.Image = Form1.Button70.Image
                    bt.ImageAlign = ContentAlignment.BottomCenter
                End If 

                bt.BackColor = cr

                bt.Name = "bt" & CStr(rnd.Next)
                bt.TextAlign = ContentAlignment.BottomCenter

                bt.Font = New Font("Arial", 16, FontStyle.Bold)
                bt.Dock = DockStyle.Left
                bt.AutoSize = True
                bt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
                bt.TextAlign = ContentAlignment.MiddleCenter
                bt.Width = Form1.txtlongerbt.Text
                bt.Height = Form1.txtlargebt.Text


                AddHandler bt.Click, AddressOf TableSelected
                fpl.Controls.Add(bt)

                bt = Nothing
            Next
        End If
        rnd = Nothing

        Form1.txtSearch.Text = ""
        Form1.txtSearch.Focus()
    End Sub
    Public Sub TableSelected(ByVal sender As Object, ByVal e As EventArgs)

        Try
            saveChanges()
        Catch ex As Exception
        End Try

        Dim btt As Button = sender
        Dim pl As Panel = Form1.plright
        Dim rnd As New Random
        Dim tableName As String = "Facture"
        Dim fld As String = "fctid"
        'If Form1.btswitsh.Tag = 0 Then
        '    tableName = "Bon"
        '    fld = "bonid"
        'End If

        Dim id As Integer = btt.Tag.ToString.Split("|")(1)
        Dim clid As Integer = btt.Tag.ToString.Split("|")(0)

        If id = 0 Then
            id = TableNewFacture(clid, btt.Text)
            If id = 0 Then Exit Sub
            btt.Tag = clid & "|" & id
        End If

        Dim bt As New Button
        Form1.plright.Controls.Clear()
        bt.BackColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255)) 'Color.DarkSlateGray
        bt.FlatStyle = FlatStyle.Flat
        bt.ForeColor = Color.White


        bt.Name = "bt" & CStr(rnd.Next)
        bt.TextAlign = ContentAlignment.BottomCenter

        bt.Font = New Font("Arial", 12, FontStyle.Bold)
        bt.Dock = DockStyle.Left
        bt.AutoSize = True
        bt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        bt.TextAlign = ContentAlignment.MiddleCenter
        bt.Width = Form1.txtlongerbt.Text
        bt.Height = Form1.txtlargebt.Text
        bt.Tag = btt.Tag

        'clear the recept liste
        Form1.RPl.ClearItems()
        Form1.RPl.FctId = id
        Form1.RPl.ClId = clid
        Form1.RPl.isSell = CBool(Form1.btswitsh.Tag)
        Form1.RPl.EditMode = False

        'GET AVANCE OF THIS FACTURE
        'fill the recept items
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add(fld, id)
            Dim dt = c.SelectDataTable(tableName, {"*"}, params)

            If dt.Rows.Count > 0 Then

                If dt.Rows(0).Item("writer") <> Form1.adminName Then

                    MsgBox("une commande de serveur " & dt.Rows(0).Item("writer") & " est en cours sur " & btt.Text)
                    Exit Sub
                End If




                Form1.RPl.Avance = dt.Rows(0).Item("avance")
                Form1.RPl.ClId = dt.Rows(0).Item("clid")
                Form1.RPl.ClientName = dt.Rows(0).Item("name")

                bt.Text = dt.Rows(0).Item("name")
                AddHandler bt.Click, AddressOf TableChanged
                Form1.plright.Controls.Add(bt)

                Form1.RPl.Num = 0
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


        'fill the recept items
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add("fctid", id)
            Dim dt = c.SelectDataTable(tableName, {"*"}, params)

            If dt.Rows.Count > 0 Then
                Form1.RPl.AddItems(dt, True)
            End If
        End Using

        FillGroupes(True)
        Form1.txtSearch.Text = ""
        Form1.txtSearch.Focus()
        rnd = Nothing
    End Sub
    Private Sub TableChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim btt As Button = sender
        Dim tableName As String = "Facture"

        Dim id As Integer = btt.Tag.ToString.Split("|")(1)
        Dim clid As Integer = btt.Tag.ToString.Split("|")(0)

        Dim newClid As Integer = 0
        Dim newTable As String = ""

        If MsgBox("voulez vous changer le numéro du table", vbYesNo) = MsgBoxResult.No Then Exit Sub


        Dim isSell As Boolean = True
        Dim chs As New ChoseClient
        chs.isSell = isSell
        chs.isTables = True

        If chs.ShowDialog = Windows.Forms.DialogResult.OK Then
            newTable = chs.clientName
            newClid = chs.cid
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                params.Add("Clid", newClid)
                Dim _id = c.SelectByScalar("Client", "CIN", params)

                If _id <> 0 Then
                    MsgBox("la table est déjà prise")
                Else
                    params.Clear()
                    params.Add("CIN", 0)
                    where.Add("Clid", clid)
                    c.UpdateRecord("Client", params, where)

                    params.Clear()
                    where.Clear()

                    params.Add("CIN", id)
                    where.Add("Clid", newClid)
                    c.UpdateRecord("Client", params, where)


                    params.Clear()
                    where.Clear()

                    params.Add("clid", newClid)
                    params.Add("name", newTable)
                    where.Add("fctid", id)
                    c.UpdateRecord("Facture", params, where)

                    btt.Text = newTable
                    btt.Tag = newClid & "|" & id
                    Form1.RPl.ClId = newClid
                    Form1.RPl.ClientName = newTable

                End If
            End Using
            fillFactures(1)
        End If

    End Sub
    Public Function TableNewFacture(ByVal Clid As Integer, ByVal name As String) As Integer
        Try
             Dim tableName As String = "Facture"

            Dim cid As Integer = Clid
            Dim clientname As String = name
            Dim clientadesse As String = ""
            Dim tp As String = 1
            Dim num As String = ""
            Dim fid As Integer = 0
            Dim dte As Date = Date.Now


            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                Dim where As New Dictionary(Of String, Object)

                params.Add("clid", cid)
                params.Add("name", clientname)
                params.Add("total", 0)
                params.Add("avance", 0)
                params.Add("date", Now)
                params.Add("admin", False)
                params.Add("writer", CStr(Form1.adminName))
                params.Add("tp", 1)
                params.Add("payed", False)
                params.Add("poid", 0)
                params.Add("num", 0)
                params.Add("tva", 0)
                params.Add("adresse", clientadesse)
                params.Add("bl", "---")
                params.Add("remise", 0)
                params.Add("beInFacture", 0)
                params.Add("caisse", Form1.caisseId)

                fid = c.InsertRecord(tableName, params, True)

                params.Clear()
                params.Add("CIN", fid)
                where.Add("Clid", cid)
                c.UpdateRecord("Client", params, where)
            End Using

            Return fid

        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function
    Public Sub UpdatefactureTp(ByVal id As Integer)

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)


            where.Add("fctid", id)
            params.Add("tp", 2)

            Try
                c.UpdateRecord("Facture", params, where)

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Using
    End Sub
    Public Function readFactureTp(ByVal id As Integer) As Integer

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            where.Add("fctid", id)

            Try
                Return c.SelectByScalar("Facture", "tp", where)

            Catch ex As Exception
                Return 0
            End Try
        End Using

        Return 0
    End Function
    Public Sub AddToCancels(ByVal R As Items)

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim price As Double = CDbl(R.Price)
            If Form1.btswitsh.Tag = 0 Then price = CDbl(R.Bprice)
            Dim params As New Dictionary(Of String, Object)

            params.Add("fctid", getCancelsFctid())
            params.Add("name", R.Name)
            params.Add("bprice", CDbl(R.Bprice))
            params.Add("price", price)
            params.Add("unit", R.Unite)
            params.Add("qte", CDbl(Form1.RPl.CP.Value))
            params.Add("tva", 20)
            params.Add("poid", CInt(R.Poid * 100))
            params.Add("arid", CInt(R.arid))
            params.Add("depot", CInt(R.Depot))
            params.Add("code", "")
            params.Add("cid", CStr(R.cid))

            c.InsertRecord("DetailsBon", params, True)
            params.Clear()

            params.Add("id", CInt(R.id))
            c.DeleteRecords("DetailsFacture", params)

            Form1.RPl.DeleteItems()
        End Using
    End Sub
    Public Function getCancelsFctid() As Integer
        Dim id As Integer = 0
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            Dim dt1 As Date = Date.Parse(Now.Date).AddDays(1)
            Dim dt2 As Date = Date.Parse(Now.Date).AddDays(-1)


            Dim params As New Dictionary(Of String, Object)

            Try
                params.Add("date < ", dt1)
                params.Add("date > ", dt2)

                Dim dt = c.SelectDataTableSymbols("Bon", {"*"}, params)

                id = dt.Rows(0).Item(0)
                If id > 0 Then Return id
                params.Clear()
            Catch ex As Exception
                params.Clear()
            End Try

            params.Add("clid", 0)
            params.Add("name", "Retour Articles : " & Now.Date.ToString("dd-MMM"))
            params.Add("total", 0)
            params.Add("avance", 0)
            params.Add("date", Now)
            params.Add("admin", True)
            params.Add("writer", CStr(Form1.adminName))
            params.Add("tp", 1)
            params.Add("payed", False)
            params.Add("poid", 0)
            params.Add("num", 0)
            params.Add("tva", 0)
            params.Add("adresse", "-")
            params.Add("bl", "---")
            params.Add("remise", 0)
            params.Add("beInFacture", 0)

            id = c.InsertRecord("Bon", params, True)
        End Using
        Return id
    End Function

    Public Sub UpdateItem(ByVal i As Items, ByVal qte As Double, ByVal isS As Boolean, ByVal Field As String)
        Try
            If i.id > 0 Then
                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                    Dim params As New Dictionary(Of String, Object)
                    params.Add(Field, qte)

                

                    Dim where As New Dictionary(Of String, Object)
                    If isS Then
                        where.Add("id", CInt(i.id))
                    Else
                        where.Add("bid", CInt(i.id))
                    End If

                    If c.UpdateRecord(Form1.TB_Details, params, where) Then
                        Form1.RPl.ChangedItemsQte(i.id, qte, Field)
                    End If

                End Using
            Else
                Form1.RPl.ChangedItemsQte(i.id, qte, Field)
            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Sub UpdateItem(ByVal i As Items, ByVal isS As Boolean)
        Try

            Dim clc As New Editprdfact(i.Name, i.Bprice, i.Price, Math.Abs(i.Qte), i.Depot, i.isRetour, i.cid)
            If clc.ShowDialog = DialogResult.OK Then
               
                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                    Dim h As Integer = 1
                    If i.id > 0 Then
                        Dim params As New Dictionary(Of String, Object)
                        Dim qte As Double = clc.prdQte
                        'Dim oldqte As Double = CDbl(i.Qte)

                        params.Add("name", clc.prdName)
                        params.Add("bprice", clc.prdBPrice)
                        params.Add("price", clc.prdSPrice)
                        params.Add("qte", clc.prdQte)
                        params.Add("depot", clc.depot)


                        Dim where As New Dictionary(Of String, Object)
                        'where.Add("fctid", CInt(Form1.RPl.FctId))
                        If isS Then
                            where.Add("id", CInt(i.id))
                        Else
                            where.Add("bid", CInt(i.id))
                        End If

                        If c.UpdateRecord(Form1.TB_Details, params, where) Then
                            Form1.RPl.ChangedItems(i.id, clc.prdName, clc.prdBPrice, clc.prdSPrice, clc.prdQte, clc.depot)
                        End If

                    Else
                        Form1.RPl.ChangedItems(i.id, clc.prdName, clc.prdBPrice, clc.prdSPrice, clc.prdQte, clc.depot)
                    End If

                   Try
                        'change Article Price
                        If clc.cbChangePrice.Checked Or clc.cbChangeName.Checked Then

                            Dim params As New Dictionary(Of String, Object)
                            Dim where As New Dictionary(Of String, Object)

                            If clc.cbChangeName.Checked Then params.Add("name", clc.prdName)
                            'price
                            If clc.cbChangePrice.Checked Then
                                If isS Then
                                    params.Add("sprice", clc.prdSPrice)
                                Else
                                    params.Add("bprice", clc.prdSPrice)
                                End If
                            End If

                            where.Add("arid", i.arid)
                            c.UpdateRecord("Article", params, where)
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
               
                Dim remise As Integer = CInt(clc.CPanel1.Value)
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
                        Dim h As Integer = c.UpdateRecord(Form1.TB_Details, params, where)
                        If h > 0 Then
                            i.Remise = CDbl(remise)
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
                    Dim h As Integer = c.UpdateRecord(Form1.TB_Details, params, where)
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
    Public Sub ReturnItem(ByRef i As Items, ByVal isS As Boolean)
        Try

            If i.id > 0 Then

                
                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                    Dim params As New Dictionary(Of String, Object)
                    params.Add("qte", i.Qte * -1)
                    Dim where As New Dictionary(Of String, Object)
                    'where.Add("fctid", CInt(Form1.RPl.FctId))
                    If isS Then
                        where.Add("id", CInt(i.id))
                    Else
                        where.Add("bid", CInt(i.id))
                    End If

                    Try
                        Dim h As Integer = c.UpdateRecord(Form1.TB_Details, params, where)
                        If h > 0 Then
                            i.isRetour = Not i.isRetour
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                End Using
            Else
                  i.isRetour = Not i.isRetour
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub UpdateDateFacture(ByVal dt As Date, ByVal id As Integer, ByVal isS As Boolean)

        Try
        
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

                Dim params As New Dictionary(Of String, Object)
                params.Add("date", dt)

                Dim where As New Dictionary(Of String, Object)
                If isS = False Then
                    where.Add("bonid", id)
                Else
                    where.Add("fctid", id)
                End If

                c.UpdateRecord(Form1.TB_Bon, params, where)
            End Using

        Catch ex As Exception

        End Try
    End Sub
    Public Sub DeleteItem(ByRef i As Al_Mohasib.Items, ByVal id As System.Int32)

       
        If i.id > 0 Then


            Dim FC = "id"
            Dim isS As Boolean = CBool(Form1.RPl.isSell)
            If isS = False Then    FC = "bid"

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim where As New Dictionary(Of String, Object)
                where.Add(FC, i.id)

                Dim params As New Dictionary(Of String, Object)
                params.Add("fctid", CInt(Form1.RPl.FctId * -1))
                params.Add("price", 0)
                params.Add("bprice", 0)
                params.Add("qte", 0)
                params.Add("code", Now.ToString("dd/MM/yy HH:mm"))
                'where.Add("arid", i.id)

                If c.UpdateRecord(Form1.TB_Details, params, where) Then
                    Form1.RPl.DeleteItems()
                End If

                'If c.DeleteRecords(Form1.TB_Details, where) Then
                '    Form1.RPl.DeleteItems()
                'End If

                'Stock
                Try
                    If Form1.RPl.EditMode Then

                        params.Clear()
                        params.Add("arid", i.arid)
                        params.Add("dpid", i.Depot)

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
        Else
            'Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            '    Dim params As New Dictionary(Of String, Object)
            '    params.Clear()
            '    params.Add("fctid", CInt(Form1.RPl.FctId * -1))
            '    params.Add("price", 0)
            '    params.Add("code", Now.ToString("dd/MM/yy HH:mm"))
            '    params.Add("name", i.Name)
            '    params.Add("bprice", i.Bprice)
            '    params.Add("unit", i.Unite)
            '    params.Add("qte", i.Qte)
            '    params.Add("tva", i.Tva)
            '    params.Add("arid", i.arid)
            '    params.Add("depot", i.Depot)
            '    params.Add("poid", 0)
            '    params.Add("cid", i.cid)
            '    params.Add("rprice", 0)
            '    params.Add("caisse", Form1.caisseId)
            '    c.InsertRecord(Form1.TB_Details, params)

            'End Using
            Form1.RPl.DeleteItems()
            If Form1.RPl.isSell Then AppendData(id, "Supression ", "-", i.Name)
        End If

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
            Dim params As New Dictionary(Of String, Object)

            params.Add("total", 0)
            params.Add("avance", 0)
            params.Add("admin", True)
            params.Add("payed", True)
            params.Add("tva", 0)
            params.Add("bl", "sup par " & Form1.adminName & " le: " & Now.ToString("ddMMyy HH:mm") & "-T" & Form1.RPl.Total_TTC & "-A" & Form1.RPl.Avance)
            params.Add("date", "2010-01-01 01:01:00")
            Dim where As New Dictionary(Of String, Object)
            If b Then
                where.Add("fctid", id)
            Else
                where.Add("bonid", id)
            End If

            c.UpdateRecord(Form1.TB_Bon, params, where)

            where.Clear()
            where.Add("fctid", id)

          
            c.DeleteRecords(Form1.TB_Details, where)

            'If b = False Then
            '    where.Clear()
            '    where.Add("bonid", id)
            'End If

            c.DeleteRecords(Form1.TB_Payement, where)

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
                If Form1.cbPvClient.Checked Then

                    For Each bt As CBlock In Form1.plright.Controls
                        If bt.ID = id Then
                            Form1.plright.Controls.Remove(bt)
                            Exit For
                        End If
                    Next
                Else
                    For Each bt As Button In Form1.plright.Controls
                        If bt.Tag = id Then
                            Form1.plright.Controls.Remove(bt)
                            Exit For
                        End If
                    Next
                End If

            Form1.lbListBon.Text = "****     [" & CInt(Form1.lbListBon.Tag) - 1 & "]  Recept(s)    ****"
            Form1.lbListBon.Tag = CInt(Form1.lbListBon.Tag) - 1



            Form1.RPl.ClearItems()
            If Form1.plright.Controls.Count > 0 Then
                If Form1.cbPvClient.Checked Then
                    Dim bt As New Button
                    bt.Tag = TryCast(Form1.plright.Controls(0), CBlock).ID
                    FactureSelected(bt, Nothing)
                Else
                    FactureSelected(Form1.plright.Controls(0), Nothing)
                End If

            End If
        End If
        End If



    End Sub

    Public Sub UpdateItemDepot(ByVal i As Items)

        If Form1.cbCafeMode.Checked Then
            Try
                saveChanges()
            Catch ex As Exception
            End Try

            Dim epb As New SplitDetailsBon
            epb.ShowDialog()

            Dim bt As New Button

            bt.Tag = Form1.RPl.ClId & "|" & Form1.RPl.FctId
            TableSelected(bt, Nothing)

            Exit Sub
        End If




        Dim clc As New ChoseDepot
        Dim isS As Boolean = Form1.RPl.isSell


        If clc.ShowDialog = DialogResult.OK Then
            Dim dpt As Integer = CInt(clc.DataGridView1.SelectedRows(0).Cells(0).Value)
            If clc.Button1.Tag = 2 Then dpt = 0

            If Form1.RPl.FctId < 0 Then
                Form1.RPl.ChangedItemsDepot(i.id, dpt)
                Exit Sub
            End If


            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                Dim where As New Dictionary(Of String, Object)



                If isS = True Then
                    where.Add("id", CInt(i.id))
                Else
                    where.Add("bid", CInt(i.id))
                End If

                params.Add("depot", dpt)



                Try
                    Dim h As Integer = c.UpdateRecord(Form1.TB_Details, params, where)
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


                                If isS = True Then
                                    q += i.Qte
                                Else
                                    q -= i.Qte
                                End If

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

                                    ' q -= i.Qte

                                    If isS = True Then
                                        q -= i.Qte
                                    Else
                                        q += i.Qte
                                    End If

                                    params.Clear()
                                    params.Add("qte", q)
                                    where.Add("DSID", dsid)

                                    c.UpdateRecord("Detailstock", params, where)
                                Else

                                    Dim q = i.Qte * -1
                                    If isS = False Then q = i.Qte

                                    params.Clear()
                                    params.Add("qte", q)
                                    params.Add("arid", i.arid)
                                    params.Add("dpid", dpt)
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
                table.Rows.Add(0, -110, 1, "Caisse", "U", cs, cs, 0, 100, -110, 0, 0)
            End If

            Dim PRFT As Double = getProfit()
            If Form1.adminRole >= 100 Then table.Rows.Add(0, -111, 1, "Profit", "U", PRFT, PRFT, 0, 100, -110, 0, 0)
            table.Rows.Add(0, -112, 1, "Rest", "U", tva, tva, 0, 100, -110, 0, 0)
            table.Rows.Add(0, -113, 1, NM & "  FACTURES", "U", price, price, 0, 0, -110, 0, 0)

            Form1.RPl.ClearItems()


            Form1.RPl.FctId = 0
            Form1.RPl.ClientName = 0
            Form1.RPl.ClId = 0
            Form1.RPl.Dte = Form1.dte1.Value
            Form1.RPl.Avance = avance
            Form1.RPl.AddItems(table, isSell)

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub UpdateBl(ByVal isS As Boolean)
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)


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

            c.UpdateRecord(Form1.TB_Bon, params, where)

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
            where.Add("admin =", True)
            where.Add("clid=", 0)
            where.Add("date <", Now.Date.AddDays(-5))
            where.Add("beInFacture =", 0)
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
            params.Add("admin = ", True)
            params.Add("date < ", dtt)

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
            If Form1.isBaseOnNormalStockMethode = False Then
                Dim where As New Dictionary(Of String, Object)
                where.Clear()
                where.Add("arid", arid)
                where.Add("depot", dpid)

                Dim qteOUT = c.SelectByScalar("detailsfacture", "SUM(qte)", where)
                Dim qteIN = c.SelectByScalar("detailsbon", "SUM(qte)", where)

                If IsDBNull(qteIN) Then qteIN = 0
                If IsDBNull(qteOUT) Then qteOUT = 0

                qteIN -= qteOUT

                If Form1.RPl.EditMode = False Then
                    result = qteIN + qte
                    If Form1.RPl.isSell Then result = qteIN - qte
                Else
                    result = qteIN
                End If 
            Else

                Dim params As New Dictionary(Of String, Object)
                params.Add("arid", arid)
                params.Add("dpid", dpid)
                Dim localStock As Double
                Try
                    localStock = c.SelectByScalar("Detailstock", "qte", params)
                Catch ex As Exception
                    localStock = 0
                End Try

                If Form1.RPl.EditMode = False Then
                    result = localStock + qte
                    If Form1.RPl.isSell Then result = localStock - qte
                Else
                    result = localStock
                End If
            End If
              
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

                'Try
                '    If Form1.cbUseStar.Checked Then
                '        If Form1.adminName.Contains("*") And tableName = "Article" Then
                '            Dim result = From myRow As DataRow In dt.Rows
                '                                      Where myRow("codebar").Contains("*") Select myRow
                '            If result.Count Then dt = result.CopyToDataTable
                '        Else
                '            Dim result = From myRow As DataRow In dt.Rows
                '                              Where myRow("codebar").Contains("*") = False Select myRow
                '            If result.Count Then dt = result.CopyToDataTable
                '        End If
                '    End If
                'Catch ex As Exception
                'End Try


                For i As Integer = 0 To dt.Rows.Count - 1

                    Try
                        If Form1.cbUseStar.Checked Then
                            If Form1.adminName.Contains("*") Then
                                If StrValue(dt, "codebar", i).Contains("*") = False Then
                                    Continue For
                                End If
                            Else
                                If StrValue(dt, "codebar", i).Contains("*") Then
                                    Continue For
                                End If
                            End If
                        End If
                    Catch ex As Exception
                    End Try


                    lst.Add(dt.Rows(i).Item("name").ToString & "|" & dt.Rows(i).Item(0).ToString)
                Next
            End If
        End Using

        'Records binded to the AutocompleteStringCollection.
        MySource.AddRange(lst.ToArray)
        txt.AutoCompleteSource = MySource

    End Sub
    Public Sub AutoCompleteArticlesWithRef(ByRef txt As TxtBox, ByVal tableName As String)
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
                    Try
                        If Form1.cbUseStar.Checked Then
                            If Form1.adminName.Contains("*") Then
                                If StrValue(dt, "codebar", i).Contains("*") = False Then
                                    Continue For
                                End If
                            Else
                                If StrValue(dt, "codebar", i).Contains("*") Then
                                    Continue For
                                End If
                            End If
                        End If
                    Catch ex As Exception
                    End Try

                    lst.Add(dt.Rows(i).Item("name").ToString & "|" & dt.Rows(i).Item(0).ToString)
                    lst.Add(dt.Rows(i).Item("codebar").ToString & "|" & dt.Rows(i).Item(0).ToString & "|" & dt.Rows(i).Item("name").ToString)
                Next
            End If
        End Using

        'Records binded to the AutocompleteStringCollection.
        MySource.AddRange(lst.ToArray)
        txt.AutoCompleteSource = MySource

    End Sub
    Public Sub ArticlesRepport(ByVal id As Integer, ByVal isSelling As Boolean, ByVal dt1 As Date, ByVal dt2 As Date, ByRef dgv As DataGridView, ByRef RPl As RPanel)

        dgv.Rows.Clear()
        Dim dt As DataTable = Nothing
        ' added some items
        Dim tQte As Decimal = 0
        Dim tbPrice As Decimal = 0
        Dim tsPrice As Decimal = 0
        Dim tTva As Double = 0

       If isSelling Then
            Try

                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                    Dim params As New Dictionary(Of String, Object)
                    Dim tb_A As String = "Facture"
                    Dim tb_D_A As String = "DetailsFacture"
                    params.Add(tb_A & ".date > ", dt1.ToString("yyyy-MM-dd 23:59:30"))
                    params.Add(tb_A & ".date < ", dt2.ToString("yyyy-MM-dd 00:00:30"))
                    params.Add(tb_D_A & ".arid = ", id)

                    dt = a.SelectDataTableSymbols("(" & tb_D_A & " INNER JOIN " & tb_A & " ON " & tb_D_A & ".fctid = " & tb_A & ".fctid) ",
                        {tb_D_A & ".fctid, " & tb_D_A & ".name, " & tb_D_A & ".bprice, " & tb_D_A & ".price, " & tb_D_A & ".qte, " &
                            tb_D_A & ".unit, " & tb_D_A & ".tva, " & tb_D_A & ".code, " & tb_A & ".date, " & tb_A & ".name AS ClientName"},
                    params)

                End Using
            Catch ex As Exception

            End Try

            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim bprice As Decimal = dt.Rows(i).Item("qte") * dt.Rows(i).Item("bprice")
                    Dim sprice As Decimal = dt.Rows(i).Item("qte") * dt.Rows(i).Item("price")

                    Dim dte As Date = CDate(dt.Rows(i).Item("date"))
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

                dgv.Rows.Add("-----", "Total", "-----", String.Format("{0:n}", CDec(tQte)),
                                                   String.Format("{0:n}", tbPrice),
                                                     String.Format("{0:n}", tsPrice),
                                                      String.Format("{0:n}", tTva))


                dt = Nothing
            End If
        Else
      
            Try
                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                    Dim params As New Dictionary(Of String, Object)
                    Dim tb_A As String = "Bon"
                    Dim tb_D_A As String = "DetailsBon"
                    params.Add(tb_A & ".date > ", dt1.ToString("yyyy-MM-dd 00:00:00"))
                    params.Add(tb_A & ".date < ", dt2.ToString("yyyy-MM-dd 00:00:00"))
                    params.Add(tb_D_A & ".arid = ", id)

                    dt = a.SelectDataTableSymbols("((" & tb_D_A & " INNER JOIN " & tb_A & " ON " & tb_D_A & ".fctid = " & tb_A & ".bonid) ",
                        {tb_D_A & ".fctid, " & tb_D_A & ".name, " & tb_D_A & ".bprice, " & tb_D_A & ".price, " &
                            tb_D_A & ".unit, " & tb_D_A & ".tva, " & tb_D_A & ".code, " & tb_A & ".date, " & tb_A & ".name AS ClientName"},
                    params)

                End Using

            Catch ex As Exception
            End Try

            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    Dim bprice As Decimal = dt.Rows(i).Item("qte") * dt.Rows(i).Item("bprice")
                    Dim sprice As Decimal = 0 'dt.Rows(i).Item("qte") * dt.Rows(i).Item("price")
                    Dim dte As Date = CDate(dt.Rows(i).Item("date"))

                    'dgv.Rows.Add(dte.ToString("dd MMMM yy"), dt.Rows(i).Item("fctid"), dt.Rows(i).Item("ClientName"),
                    'dt.Rows(i).Item("qte"), bprice, sprice, dt.Rows(i).Item("tva"))

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

                dgv.Rows.Add("-----", "Total", "-----", String.Format("{0:n}", CDec(tQte)),
                                                  "0.00", String.Format("{0:n}", tsPrice),
                                                     String.Format("{0:n}", tTva))
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
    End Sub
    Public Sub UpdateClient(ByVal fid As Integer, ByVal isS As Boolean, ByVal EdtMode As Boolean)
        Dim cc As New SelectClient
        If cc.ShowDialog = Windows.Forms.DialogResult.OK Then
            updateClient_PromoStyle(fid, isS, cc.cid, cc.cName, cc.cAdress, cc.num, EdtMode)
        End If

        'Dim chs As New ChoseClient
        'chs.isSell = isS
        'If chs.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    Dim cid As String = chs.cid
        '    Dim clientname As String = chs.clientName
        '    Dim adresse As String = chs.clientadresse
        '    Dim tp As String = chs.tp
        'End If
    End Sub
    
    Public Sub updateClient_PromoStyle(ByVal fid As Integer, ByVal isS As Boolean, ByVal cid As Integer,
                                       ByVal clientname As String, ByVal adresse As String, ByVal tp As String, ByVal EdtMode As Boolean)
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
            Form1.RPl.TotalPoint = 0

            Form1.RPl.ClId = cid
            Form1.RPl.ClientName = clientname
            Form1.RPl.ClientAdresse = adresse

            If EdtMode Then
                Form1.DGVARFA.SelectedRows(0).Cells(2).Value = clientname
                Form1.DGVARFA.SelectedRows(0).Cells(1).Value = cid
                Form1.DGVARFA.SelectedRows(0).Cells(8).Value = adresse

                Try
                    If Form1.cbPromos.Checked And isS Then
                        params.Clear()
                        where.Clear()

                        params.Add("cid", cid)
                        where.Add("fctid", fid)
                        z.UpdateRecord("promo", params, where)
                    End If
                Catch ex As Exception
                End Try
            Else
                Try

                    If Form1.cbPvClient.Checked Then
                        For Each b As CBlock In Form1.plright.Controls
                            If b.ID = fid Then
                                b.lb.Text = clientname
                            End If
                        Next

                    Else
                        For Each b As Button In Form1.plright.Controls
                            If b.Tag = fid Then
                                b.Text = clientname
                            End If
                        Next
                    End If

                    Try
                        If Form1.cbPromos.Checked And isS And cid > 0 Then
                            params.Clear()

                            params.Add("cid = ", cid)
                            params.Add("fctid <> ", fid)
                            Dim dtPoint = z.SelectDataTableSymbols("promo", {"(SUM(pointIN) - SUM(pointOUT)) AS points"}, params)

                            If dtPoint.Rows.Count > 0 Then
                                Form1.RPl.TotalPoint = dtPoint.Rows(0).Item("points")
                            End If

                            Form1.RPl.UpdateValue()
                        End If
                    Catch ex As Exception
                        Form1.RPl.TotalPoint = 0
                    End Try
                Catch ex As Exception
                End Try
            End If
        End Using
    End Sub
    Public Sub UpdateValues(ByVal params As Dictionary(Of String, String))
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            For Each k As KeyValuePair(Of String, String) In params
                Try
                    Dim pr As New Dictionary(Of String, Object)
                    Dim wh As New Dictionary(Of String, Object)
                    wh.Add("vkey", k.Key)
                    pr.Add("val", k.Value)
                    a.UpdateRecord("value", pr, wh)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next

        End Using

    End Sub
    Public Function SelectValues(ByVal key As String, ByVal val As String) As String

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

            Dim pr As New Dictionary(Of String, Object)
            pr.Add("vkey", key)
            Try
                Dim result As DataTable = a.SelectDataTable("value", {"*"}, pr)


                If result.Rows.Count > 0 Then
                    Return result.Rows(0).Item(1)
                Else
                    pr.Clear()
                    pr.Add("vkey", key)
                    pr.Add("val", val)
                    a.InsertRecord("value", pr)
                    Return val
                End If
            Catch ex As Exception
            End Try

            Return val
        End Using
    End Function
    Public Function getProfit() As Decimal

        Dim profit As Decimal = 0
        If isSell Then
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)

                For i As Integer = 0 To Form1.DGVARFA.Rows.Count - 1
                    params.Clear()

                    Dim fctid As Integer = Form1.DGVARFA.Rows(i).Cells(0).Value
                    params.Add("fctid", fctid)
                    Dim dt = c.SelectDataTable("DetailsFacture", {"*"}, params)

                    If dt.Rows.Count > 0 Then
                        For t As Integer = 0 To dt.Rows.Count - 1

                            profit += (dt.Rows(t).Item("price") - dt.Rows(t).Item("bprice")) * dt.Rows(t).Item("qte")
                        Next
                    End If
                Next
            End Using
        End If
        Return profit
    End Function
    Public Function getCaisse() As Decimal

        Dim caisseTotal As Decimal = 0
        ' Dim dt As DataTable
        Dim tt As Decimal = 0

        Dim dt1 = New DateTime(Form1.dte2.Value.Year, Form1.dte2.Value.Month, Form1.dte2.Value.Day, 23, 59, 0, 0)
        Dim dt2 = New DateTime(Form1.dte1.Value.AddDays(-1).Year, Form1.dte1.Value.AddDays(-1).Month, Form1.dte1.Value.AddDays(-1).Day, 23, 59, 0, 0)

        'Dim dt1 = New DateTime(Form1.dte2.Value.Year, Form1.dte2.Value.Month, Form1.dte2.Value.Day, 23, 59, 0, 0)
        'Dim dt2 = New DateTime(Form1.dte1.Value.Year, Form1.dte1.Value.Month, Form1.dte1.Value.Day, 0, 0, 0, 0)
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add("date < ", dt1) '.ToString("yyyy-MM-dd HH:mm"))
            params.Add("date > ", dt2) '.ToString("yyyy-MM-dd HH:mm"))

            Dim tb As String = "Payment"
            If Form1.RPl.isSell = False Then tb = "CompanyPayment"

            Dim dt = a.SelectDataTableSymbols(tb, {" SUM(montant) AS total"}, params)
            If dt.rows.count > 0 Then
                tt = dt.Rows(0).Item("total")
            End If
        End Using

        'If dt.Rows.Count > 0 Then
        '    For t As Integer = 0 To dt.Rows.Count - 1
        '        caisseTotal += dt.Rows(t).Item("montant")
        '    Next
        'End If

        'Return caisseTotal
        Return tt

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
        Form1.DGVS.DataSource = Nothing

        'Form1.DGVS.Rows.Clear()

        Dim data As New DataTable
        ' Create four typed columns in the DataTable.
        data.Columns.Add("Designation", GetType(String))
        data.Columns.Add("Nbr", GetType(String))
        data.Columns.Add("-", GetType(String))
        data.Columns.Add("Valeur", GetType(String))



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

                data.Rows.Add(dtctg.Rows(i).Item("name").ToString, dt.Rows.Count & " Aricles", "",
                                     String.Format("{0:n}", ctgvalue) & "Dhs")
                ttvalue += ctgvalue

            Next
            data.Rows.Add("-------", "-------", "-------", "-------")
            data.Rows.Add("المجموع (Total)", dtctg.Rows.Count & " ctgs", "", String.Format("{0:n}", ttvalue) & "Dhs")

            Form1.DGVS.DataSource = data
        End Using
    End Sub
    'save the modification has made
    Public Sub AppendData(ByVal fctid As String, ByVal dt As DataTable)
        Try
            If Form1.chMasar.Checked = False Then Exit Sub
            Dim str As String = Form1.btDbDv.Tag
            Dim conString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & str & ";Persist Security Info=False;"

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True) '  Using c As DataAccess = New DataAccess(conString, True)
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim params As New Dictionary(Of String, Object)
                    params.Add("fctid", fctid)
                    params.Add("date", Now)
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
                params.Add("date", Now)
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
    Private Sub PvClient_DeleteBon(ByVal ds As CBlock)

        Dim str As String = " عند قيامكم على الضغط على 'موافق' سيتم حذف ايصال "
        str = str + vbNewLine
        str = str & ds.lb.Text & " ( " & ds.ID & ")"
        str = str + vbNewLine
        str = str + " و جميع المواد الدفعات المسجلة في القائمة ..    "
        str = str + vbNewLine
        str = str + "  .. إضغط  'لا'  لالغاء الحذف   "

        If MsgBox(str, MsgBoxStyle.YesNo Or MessageBoxIcon.Exclamation, "الغاء الفاتورة") = MsgBoxResult.No Then
            Exit Sub
        End If


        If Form1.RPl.FctId = 0 Then Exit Sub

        DeleteFacture(ds.ID, Form1.RPl.isSell, False, Form1.RPl.DataSource)



        If Form1.chbcb.Checked Then
            Form1.txtSearchCode.Text = ""
            Form1.txtSearchCode.Focus()
        Else
            Form1.txtSearch.Text = ""
            Form1.txtSearch.Focus()
        End If

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
