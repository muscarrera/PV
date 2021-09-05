Imports System.Drawing.Printing

Public Class Devis

    Dim conString As String
    Private _isSell As Boolean
    Private tableName As String
    Private tName As String

    Public Property ISSELL() As Boolean
        Get
            Return _isSell
        End Get
        Set(ByVal value As Boolean)
            _isSell = value
            If value = False Then
                btswitsh.Text = " Bon de Commande "
                btswitsh.BackColor = Color.Thistle
                plrightA.BackColor = Color.Thistle
                btswitsh.Tag = 0
                tableName = "Bon"
                tName = "DetailsBon"

                plright.Controls.Clear()
                RPl.ClearItems()
            Else
                btswitsh.Text = " Devis "
                btswitsh.BackColor = Color.Teal
                plrightA.BackColor = Color.Teal
                btswitsh.Tag = 1
                tableName = "Facture"
                tName = "DetailsFacture"

                plright.Controls.Clear()
                RPl.ClearItems()
            End If

            'fillFactures(CInt(btswitsh.Tag))

            CBPRICE.Visible = Not value
            FillGroupes(True)

        End Set
    End Property

    Private Sub Devis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim str As String = Form1.btDbDv.Tag
        'str = str.Replace(".mdb", "_Dv_Cm.mdb")
        conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & str & ";Persist Security Info=False;"

        RPl.hasManyRemise = Form1.CbArticleRemise.Checked

        Dim monitorWidth As Integer = My.Computer.Screen.WorkingArea.Size.Width
        Dim monitorHeight As Integer = My.Computer.Screen.WorkingArea.Size.Height
        ' --- adjust size of this form ** this does NOT make consideration of DPI (eg. 125%, 150%) **
        Me.Width = monitorWidth - 100
        Me.Height = monitorHeight - 100
        Me.Top = 50
        Me.Left = 50
        RPl.TypePrinter = Form1.cbPaper.Text
    End Sub
    Private Sub btswitsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btswitsh.Click
        'If btswitsh.Tag = 1 Then
        '    btswitsh.Text = " Bon de Commande "
        '    btswitsh.BackColor = Color.Thistle
        '    plrightA.BackColor = Color.Thistle
        '    btswitsh.Tag = 0

        '    plright.Controls.Clear()
        '    RPl.ClearItems()
        'Else
        '    btswitsh.Text = " Devis "
        '    btswitsh.BackColor = Color.Teal
        '    plrightA.BackColor = Color.Teal
        '    btswitsh.Tag = 1

        '    plright.Controls.Clear()
        '    RPl.ClearItems()
        'End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim chs As New ChoseClient
            chs.isSell = True
            chs.editMode = False

            Dim tableName As String = "Facture"
            Dim p As Panel = plright

            If btswitsh.Tag = 0 Then
                chs.isSell = False
                tableName = "Bon"
            End If

            If chs.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim cid As String = chs.cid
                Dim clientname As String = chs.clientName
                Dim clientadesse As String = chs.clientadresse
                Dim tp As String = chs.tp
                Dim num As String = chs.num
                Dim fid As Integer = 0
                Dim dte As Date = Now.Date

                If chs.isEditing = True Then
                    fid = chs.id
                Else
                    Using c As DataAccess = New DataAccess(conString)
                        Dim params As New Dictionary(Of String, Object)
                        params.Add("clid", cid)
                        params.Add("name", clientname)
                        params.Add("total", 0)
                        params.Add("avance", 0)
                        params.Add("date", Format(dte, "dd-MM-yyyy"))
                        params.Add("admin", False)
                        params.Add("writer", CStr(Form1.adminName))
                        params.Add("tp", 1)
                        params.Add("payed", False)
                        params.Add("poid", 0)
                        params.Add("num", num)
                        params.Add("tva", 0)
                        params.Add("adresse", clientadesse)
                        params.Add("bl", "---")
                        params.Add("remise", 0)
                        params.Add("beInFacture", 0)

                        fid = c.InsertRecord(tableName, params, True)
                    End Using
                End If

                If fid > 0 Then

                    p.Controls.Clear()

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

                    p.Controls.Add(bt)
                    'clear the recept liste
                    RPl.ClearItems()
                    FactureSelected(bt, Nothing)

                    bt = Nothing
                    rnd = Nothing
                End If
            End If
            txtSearch.Text = ""
            txtSearch.Focus()
            chs = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub FactureSelected(ByVal sender As Object, ByVal e As EventArgs)
        Dim bt As Button = sender
        Dim pl As Panel = plright
        Dim rnd As New Random
        Dim tableName As String = "Facture"
        Dim fld As String = "fctid"
        If btswitsh.Tag = 0 Then
            tableName = "Bon"
            fld = "bonid"
        End If

        For Each b As Button In pl.Controls
            If CStr(b.Name) = CStr(bt.Name) Then
                b.BackColor = Color.White
                b.ForeColor = Color.DarkSlateGray

                'clear the recept liste
                RPl.ClearItems()
                RPl.FctId = b.Tag
                RPl.ClientName = b.Text
                RPl.isSell = CBool(btswitsh.Tag)

                'GET AVANCE OF THIS FACTURE
                'fill the recept items
                Using c As DataAccess = New DataAccess(conString)
                    Dim params As New Dictionary(Of String, Object)
                    params.Add(fld, CInt(bt.Tag))
                    Dim dt = c.SelectDataTable(tableName, {"*"}, params)

                    If dt.Rows.Count > 0 Then
                        RPl.Avance = dt.Rows(0).Item("avance")
                        RPl.ClId = dt.Rows(0).Item("clid")
                        RPl.Num = 0
                        If Form1.chbsell.Checked Then RPl.Num = dt.Rows(0).Item("num")
                        Try
                            RPl.ClientAdresse = dt.Rows(0).Item("adresse")
                            RPl.Remise = dt.Rows(0).Item("remise")
                            RPl.bl = dt.Rows(0).Item("bl")
                        Catch ex As Exception
                            RPl.ClientAdresse = ""
                            RPl.Remise = dt.Rows(0).Item("remise")
                        End Try
                    End If
                End Using

                tableName = "DetailsFacture"
                If btswitsh.Tag = 0 Then tableName = "DetailsBon"

                'fill the recept items
                Using c As DataAccess = New DataAccess(conString)
                    Dim params As New Dictionary(Of String, Object)
                    params.Add("fctid", CInt(bt.Tag))
                    Dim dt = c.SelectDataTable(tableName, {"*"}, params)

                    If dt.Rows.Count > 0 Then
                        RPl.AddItems(dt, CBool(btswitsh.Tag))
                    End If
                End Using
            Else
                b.BackColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255)) 'Color.DarkSlateGray
                b.ForeColor = Color.White
            End If
        Next
        txtSearch.Text = ""
        txtSearch.Focus()

        rnd = Nothing
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If Form1.chbcb.Checked Then
            If e.KeyChar = Chr(13) Then

                SearchForArticles(txtSearch, FlowLayoutPanel1.Tag)

                If FlowLayoutPanel1.Controls.Count = 0 Or FlowLayoutPanel1.Controls.Count > 1 Then
                    txtSearch.Text = ""
                    txtSearch.Focus()
                    Exit Sub
                End If
                SearchForcodebar()

            End If

        Else

            SearchForArticles(txtSearch, FlowLayoutPanel1.Tag)

        End If
    End Sub
    Public Sub SearchForArticles(ByRef txt As TextBox, ByVal cid As Integer)

        If txt.Text.Trim = "" Then
            Exit Sub
        End If

        FlowLayoutPanel1.Controls.Clear()
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
                FlowLayoutPanel1.Controls.Add(lb)

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
                            bt.BackgroundImage = Image.FromFile(artdt.Rows(i).Item("img").ToString)
                        End If

                        bt.BackgroundImageLayout = ImageLayout.Stretch
                        bt.ImageAlign = ContentAlignment.BottomCenter
                    Catch ex As Exception

                    End Try
                    bt.Width = Form1.txtlongerbt.Text
                    bt.Height = Form1.txtlargebt.Text
                    FlowLayoutPanel1.Controls.Add(bt)
                    AddHandler bt.Click, AddressOf art_click

                    If i = 20 Then
                        Exit For
                    End If
                Next

            End If
            txt.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub SearchForcodebar()
        Dim bt As New Button
        Try
            bt = FlowLayoutPanel1.Controls(0)

            ' sell function
            art_click(bt, Nothing)

        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Private Sub ctg_click(ByVal sender As System.Object, ByVal e As EventArgs)

        Dim bt2 As Button = sender
        FlowLayoutPanel1.Controls.Clear()
        Try
            Dim artta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
            Dim artdt = artta.GetDataBycid(bt2.Tag)

            If artdt.Rows.Count = 0 Then
                Dim lb As New Label

                lb.ForeColor = Color.DarkGray
                lb.Text = "لا يوجد اي سجل"
                FlowLayoutPanel1.Controls.Add(lb)
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
                            bt.BackgroundImage = Image.FromFile(artdt.Rows(i).Item("img").ToString)

                        End If
                        bt.BackgroundImageLayout = ImageLayout.Stretch
                        bt.ImageAlign = ContentAlignment.BottomCenter
                    Catch ex As Exception

                    End Try
                    bt.Width = Form1.txtlongerbt.Text
                    bt.Height = Form1.txtlargebt.Text
                    FlowLayoutPanel1.Controls.Add(bt)
                    AddHandler bt.Click, AddressOf art_click
                Next

            End If
            txtSearch.Text = ""
            txtSearch.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub art_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim bt As Button = sender
        Dim R As ALMohassinDBDataSet.ArticleRow = bt.Tag

        If My.Computer.Keyboard.CtrlKeyDown Then
            Try
                Dim cde As String = R.codebar
                If cde.Length > 12 Then cde = cde.Substring(0, 12)
                If cde.Length < 12 Then cde = cde.Substring(0, 12)

                Dim CD As New BarCode1
                CD.Code = cde
                CD.article = R.name
                CD.qte = R.unite

                If CD.ShowDialog = DialogResult.OK Then
                End If
            Catch ex As Exception
            End Try

            Exit Sub
        End If

        'get the details

        Dim pl As Panel = plright
        Dim fid As Integer = RPl.FctId
        Dim cid As String = 0
        Dim clientname As String = Form1.txtcltcomptoir.Text

        Try
            If RPl.FctId = 0 Then
                Exit Sub
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If RPl.IsExiste(R.arid) = False Then
                Dim arid As Integer = 0

                Using c As DataAccess = New DataAccess(conString)
                    Dim price As Double = CDbl(R.sprice)
                    If btswitsh.Tag = 0 Then price = CDbl(R.bprice)
                    Dim params As New Dictionary(Of String, Object)
                    params.Add("fctid", CInt(RPl.FctId))
                    params.Add("name", R.name)
                    params.Add("bprice", CDbl(R.bprice))
                    params.Add("price", price)
                    params.Add("unit", R.unite)
                    params.Add("qte", CDbl(RPl.CP.Value))
                    params.Add("tva", CDbl(R.tva))
                    params.Add("poid", CDbl(R.poid))
                    params.Add("arid", CInt(R.arid))
                    params.Add("depot", CInt(R.depot))
                    params.Add("code", CStr(R.codebar))
                    params.Add("cid", CStr(R.cid))

                    arid = c.InsertRecord(tName, params, True)
                End Using

                If arid > 0 Then
                    RPl.AddItems(R, arid, CBool(btswitsh.Tag))
                Else
                    Exit Sub
                End If
            Else
                Using c As DataAccess = New DataAccess(conString)

                    If R.cid <> 0 Then
                        Dim params As New Dictionary(Of String, Object)
                        Dim qte As Double = CDbl(RPl.SelectedQte(R.arid)) + CDbl(RPl.CP.Value)

                        params.Add("qte", qte)

                        Dim where As New Dictionary(Of String, Object)
                        where.Add("fctid", fid)
                        where.Add("arid", R.arid)

                        If c.UpdateRecord(tName, params, where) Then
                            RPl.ChangedItemsQte(R.arid)
                        End If
                    End If

                End Using

            End If
            txtSearch.Text = ""
            txtSearch.Focus()
        Catch ex As Exception

        End Try

    End Sub
    Public Sub UpdateItem(ByVal t As String, ByVal i As Items, ByVal Field As String)
        Try
            Dim clc As New Calc
            clc.title = t
            clc.desc = i.Qte & " " & i.Unite
            If Field <> "qte" Then
                clc.desc = i.Price & " Dhs"
            End If
            Dim tableName As String = "DetailsFacture"
            If btswitsh.Tag = 0 Then
                tableName = "DetailsBon"
            End If
            If clc.ShowDialog = DialogResult.OK Then
                Using c As DataAccess = New DataAccess(conString, True)

                    Dim params As New Dictionary(Of String, Object)
                    Dim qte As Double = CDbl(clc.CPanel1.Value)
                    Dim oldqte As Double = CDbl(i.Qte)

                    params.Add(Field, qte)
                    Dim where As New Dictionary(Of String, Object)
                    If btswitsh.Tag = 1 Then
                        where.Add("id", CInt(i.id))
                    Else
                        where.Add("bid", CInt(i.id))
                    End If

                    If c.UpdateRecord(tableName, params, where) Then
                        RPl.ChangedItemsQte(i.id, qte, Field)
                    End If
                End Using
            End If
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

        Using c As DataAccess = New DataAccess(conString, True)
            Dim where As New Dictionary(Of String, Object)
            where.Add(FC, i.id)
            'where.Add("arid", i.id)

            If c.DeleteRecords(tableName, where) Then
                RPl.DeleteItems()
            End If
        End Using

    End Sub
    Public Sub SaveFacture(ByVal id As Integer, ByVal total As Double, ByVal avance As Double,
                           ByVal tva As Double, ByVal table As DataTable, ByVal Remise As String, ByVal BL As String)

        Using c As DataAccess = New DataAccess(conString, True)
            Dim isPayed As Boolean = False
            If avance >= total Then isPayed = True

            Dim tableName = "Facture"
            If ISSELL = 0 Then tableName = "Bon"
            Dim dte As Date = Now.Date
            Dim params As New Dictionary(Of String, Object)

            'Facture
            params.Clear()
            params.Add("total", total)
            params.Add("avance", avance)
            params.Add("admin", True)
            params.Add("payed", isPayed)
            params.Add("tva", tva)
            params.Add("remise", Remise)
            params.Add("date", dte)
            params.Add("bl", BL)

            Dim where As New Dictionary(Of String, Object)
            If ISSELL Then
                where.Add("fctid", id)
            Else
                where.Add("bonid", id)
            End If

            c.UpdateRecord(tableName, params, where)
            params.Clear()
            where.Clear()

            params = Nothing
            where = Nothing
        End Using
    End Sub
    Public Sub fillFactures(ByVal a As Integer)
        Dim dt As DataTable = Nothing
        Dim p As Panel = plright
        Dim b As Button = Nothing
        p.Controls.Clear()
        RPl.ClearItems()
        RPl.isUniqTva = Form1.CBTVA.Checked

        Dim tableName As String = "Facture"
        If a = 0 Then
            tableName = "Bon"
        End If

        Using c As DataAccess = New DataAccess(conString)
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
                RPl.ClearItems()

                If i = 0 Then
                    b = bt
                End If
                bt = Nothing
                rnd = Nothing
            Next

            FactureSelected(b, Nothing)
        End If
        txtSearch.Text = ""
        txtSearch.Focus()
    End Sub

    Private Sub RPl_printCaisse() Handles RPl.printCaisse

    End Sub
    Private Sub RPl_UpdateQte(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RPl.UpdateQte
        UpdateItem("الكمية السابــقة", RPl.SelectedItem, "qte")
    End Sub
    Private Sub RPl_UpdatePrice(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RPl.UpdatePrice
        Dim field As String = "price"
        UpdateItem("الثمن السابــقة", RPl.SelectedItem, field)
    End Sub
    Private Sub RPl_DeleteItem(ByRef i As Al_Mohasib.Items, ByVal id As System.Int32) Handles RPl.DeleteItem
        DeleteItem(i, id)
    End Sub
    Public Sub FillGroupes(ByVal F As Boolean)
        Dim ctgta As New ALMohassinDBDataSetTableAdapters.CategoryTableAdapter
        Dim ctgdt = ctgta.GetData()
        FlowLayoutPanel1.Controls.Clear()
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
                    bt.BackgroundImage = Image.FromFile(ctgdt.Rows(i).Item("img").ToString)
                End If
                bt.BackgroundImageLayout = ImageLayout.Stretch
            Catch ex As Exception
            End Try
            bt.Width = 125
            bt.Height = 90

            AddHandler bt.Click, AddressOf ctg_click
            FlowLayoutPanel1.Controls.Add(bt)
        Next

        '''''''' add temperory mixete element

        Dim btMlg As New Button

        btMlg.BackColor = Color.LightGoldenrodYellow
        btMlg.Text = "Melange"
        btMlg.Name = "ctg0"
        btMlg.Tag = 0

        btMlg.TextAlign = ContentAlignment.BottomCenter
        btMlg.BackColor = Color.Moccasin
        btMlg.Width = 125
        btMlg.Height = 90

        AddHandler btMlg.Click, AddressOf ctg_click
        FlowLayoutPanel1.Controls.Add(btMlg)

        txtSearch.Text = ""
        txtSearch.Focus()
        RPl.CP.Value = 0
    End Sub
    Public Sub DeleteFacture(ByVal id As Integer, ByVal b As Boolean)
        Dim AAA As Boolean = False
        Using c As DataAccess = New DataAccess(conString, True)
            Dim tableName = "Facture"
            If b = False Then tableName = "Bon"

            Dim where As New Dictionary(Of String, Object)
            If b Then
                where.Add("fctid", id)
            Else
                where.Add("bonid", id)
            End If

            c.DeleteRecords(tableName, where)

            where.Clear()
            where.Add("fctid", id)

            tableName = "DetailsFacture"
            If b = False Then tableName = "DetailsBon"

            c.DeleteRecords(tableName, where)
            where.Clear()
            AAA = True
        End Using

        ''Reflesh the datagridview and recept panel
    End Sub
    Private Sub RPl_SaveFacture(ByVal id As System.Int32, ByVal total As System.Double, ByVal avance As System.Double, ByVal tva As System.Double, ByVal table As System.Data.DataTable) Handles RPl.SaveFacture
        If RPl.FctId = 0 Then Exit Sub
        SaveFacture(id, total, avance, tva, table, RPl.Remise, RPl.bl)
        fillFactures(ISSELL)
        FillGroupes(True)
    End Sub

    Private Sub RPl_SaveAndPrint(ByVal id As System.Int32, ByVal total As System.Double, ByVal avance As System.Double, ByVal tva As System.Double, ByVal table As System.Data.DataTable, ByVal isSell As System.Boolean, ByVal isBl As System.Boolean, ByVal isSecond As System.Boolean) Handles RPl.SaveAndPrint
        If RPl.FctId = 0 Then Exit Sub

        Dim nbr As Integer = Form1.txtNbrCopie.Text
        Dim nm As String = Form1.txttimp.Text

        Dim dl As New PrintDialog
        If dl.ShowDialog = Windows.Forms.DialogResult.OK Then
            nm = dl.PrinterSettings.PrinterName
            nbr = dl.PrinterSettings.Copies
        Else
            Exit Sub
        End If

        If Form1.cbNormalImp.Checked Then

            Try
                PrintDoc.PrinterSettings.PrinterName = nm
                Form1.chbreceipt.Checked = False
                If isBl = False Then
                    PrintDoc.PrinterSettings.PrinterName = nm
                    Form1.chbreceipt.Checked = True
                End If


                For i = 0 To nbr - 1
                    PrintDoc.Print()
                Next

            Catch ex As Exception

            End Try

            If RPl.EditMode = False Then
                SaveFacture(id, total, avance, tva, table, RPl.Remise, RPl.bl)
                fillFactures(btswitsh.Tag)
                FillGroupes(True)
            End If

        Else

            Try


                Dim g As New gGlobClass

                Form1.MP_Localname = "Devis-Default.dat"
                If btswitsh.Tag <> 1 Then Form1.MP_Localname = "Command-Default.dat"

                g = ReadFromXmlFile(Of gGlobClass)(Form1.ImgPah & "\Prt_Dsn\" & Form1.MP_Localname)
                Dim ps As New PaperSize(g.P_name, g.W_Page, g.h_Page)
                ps.PaperName = g.p_Kind
                PrintDocDesign.DefaultPageSettings.PaperSize = ps
                PrintDocDesign.DefaultPageSettings.Landscape = g.is_Landscape

                PrintDocDesign.PrinterSettings.PrinterName = nm

            Catch ex As Exception

            End Try


            For i = 0 To nbr - 1
                PrintDocDesign.Print()
            Next
        End If
    End Sub
    Private Sub RPl_DeleteFacture(ByVal id As System.Int32, ByVal isSell As System.Boolean, ByVal EM As System.Boolean, ByVal table As DataTable) Handles RPl.DeleteFacture
        If RPl.FctId = 0 Then Exit Sub
        DeleteFacture(id, isSell)
    End Sub
    Dim numPages As Integer = 1
    Dim M As Integer = 0

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage
        Try
            Using a As DrawClass = New DrawClass
                Dim dte As Date = Now.Date

                Dim WP As Boolean = False

                If btswitsh.Tag <> 1 Then
                    WP = CBPRICE.Checked
                End If

                a.DrawBon(e, RPl.DataSource, RPl.FctId, RPl.ClId,
                         RPl.ClientName, RPl.ClientAdresse,
                           RPl.Total_Ht, RPl.Total_TTC, RPl.Avance, RPl.Tva, RPl.isSell,
                           dte, RPl.Remise, Form1.txtScale.Text, True, WP, M, numPages)
            End Using

        Catch ex As Exception
            M = 0
            numPages = 1
        End Try
    End Sub
    Private Sub BtGroupes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtGroupes.Click
        FillGroupes(False)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DataGridView1.Rows.Clear()
        PlArchive.Visible = True

        Dim d As New LookForDevis
        If ISSELL Then
            d.tableName = "Client"
            d.isSell = True
        Else
            d.tableName = "company"
            d.isSell = False
        End If
        If d.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                If d.dt.Rows.Count > 0 Then
                    '''''''''''''progress bar
                    For i As Integer = 0 To d.dt.Rows.Count - 1
                        DataGridView1.Rows.Add(d.dt.Rows(i).Item(0).ToString,
                             d.dt.Rows(i).Item("name").ToString, d.dt.Rows(i).Item("date").ToString)
                    Next
                Else
                    MsgBox("Aucun facture trouvé ")
                    PlArchive.Visible = False
                End If
            Catch ex As Exception
                PlArchive.Visible = False
            End Try
        Else
            PlArchive.Visible = False
        End If
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        PlArchive.Visible = False
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.SelectedRows.Count = 0 Then Exit Sub

        plright.Controls.Clear()

        Dim rnd As New Random
        Dim bt As New Button
        bt.Text = DataGridView1.SelectedRows(0).Cells(1).Value
        bt.BackColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255)) 'Color.DarkSlateGray
        bt.FlatStyle = FlatStyle.Flat
        bt.ForeColor = Color.White
        bt.Name = "bt" & CStr(rnd.Next)
        bt.Font = New Font("Arial", 9, FontStyle.Bold)
        bt.Tag = DataGridView1.SelectedRows(0).Cells(0).Value
        bt.Dock = DockStyle.Left
        bt.AutoSize = True
        bt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        bt.TextAlign = ContentAlignment.MiddleLeft


        plright.Controls.Add(bt)
        'clear the recept liste
        RPl.ClearItems()
        FactureSelected(bt, Nothing)

        bt = Nothing
        rnd = Nothing

    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        If RPl.FctId = 0 Then Exit Sub


        Dim p As Panel = Form1.plright
        Dim table As DataTable = RPl.DataSource

        Dim cid As String = RPl.ClId
        Dim clientname As String = RPl.ClientName
        Dim clientadesse As String = RPl.ClientAdresse
        'Dim tp As String = RPl.ty
        Dim num As String = RPl.Num
        Dim fid As Integer = 0
        Dim dte As Date = Now.Date

        Dim params As New Dictionary(Of String, Object)

        'If cid <> 0 And t <> 0 And tp <> 0 Then
        '    If tp = "" Then tp = "1"
        '    If CheckForUnpaidFacture(cid, tp) = False Then Exit Sub
        'End If

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

            params.Add("clid", cid)
            params.Add("name", clientname)
            params.Add("total", 0)
            params.Add("avance", 0)
            params.Add("date", Format(dte, "dd-MM-yyyy"))
            params.Add("admin", False)
            params.Add("writer", CStr(Form1.adminName))
            params.Add("tp", 1)
            params.Add("payed", False)
            params.Add("poid", 0)
            params.Add("num", num)
            params.Add("tva", 0)
            params.Add("adresse", clientadesse)
            params.Add("bl", "---")
            params.Add("remise", 0)
            params.Add("beInFacture", 0)

            fid = c.InsertRecord(tableName, params, True)

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
                If ISSELL Then AppendData(fid, "Creation de la Bon", btswitsh.Text, RPl.FctId)
                bt = Nothing
                rnd = Nothing

                params.Clear()

                'Details
                For i As Integer = 0 To table.Rows.Count - 1

                    params.Add("fctid", fid)
                    params.Add("name", table.Rows(i).Item("name"))
                    params.Add("bprice", CDbl(table.Rows(i).Item("bprice")))
                    params.Add("price", CDbl(table.Rows(i).Item("price")))
                    params.Add("unit", table.Rows(i).Item("unite"))
                    params.Add("qte", CDbl(table.Rows(i).Item("qte")))
                    params.Add("tva", CDbl(table.Rows(i).Item("tva")))
                    params.Add("poid", 1)
                    params.Add("arid", CInt(table.Rows(i).Item("arid")))
                    params.Add("depot", CInt(table.Rows(i).Item("depot")))
                    params.Add("code", CStr(table.Rows(i).Item("code")))
                    params.Add("cid", table.Rows(i).Item("cid"))

                    c.InsertRecord(tName, params)
                    params.Clear()
                Next
            End If
        End Using
    End Sub

    Public Sub AppendData(ByVal fctid As String, ByVal desg As String, ByVal qte As String, ByVal price As String)

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
    End Sub

    Private Sub PrintDocDesign_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocDesign.PrintPage
        Try
            Dim ds As RPanel = RPl
            Dim dte As String = Format(Date.Now, "dd-MM-yyyy [hh:mm]")


            Dim data As New DataTable
            ' Create four typed columns in the DataTable.
            data.Columns.Add("id", GetType(String))
            data.Columns.Add("date", GetType(String))
            data.Columns.Add("cid", GetType(String))
            data.Columns.Add("name", GetType(String))
            data.Columns.Add("total_ht", GetType(String))
            data.Columns.Add("total_tva", GetType(String))
            data.Columns.Add("total_ttc", GetType(String))
            data.Columns.Add("total_remise", GetType(String))
            data.Columns.Add("total_avance", GetType(String))
            data.Columns.Add("total_droitTimbre", GetType(String))
            data.Columns.Add("MPayement", GetType(String))
            data.Columns.Add("Editeur", GetType(String))
            data.Columns.Add("vidal", GetType(String))

            data.Rows.Add(RPl.FctId, dte, RPl.ClId, RPl.ClientName,
                          String.Format("{0:0.00}", RPl.Total_Ht), String.Format("{0:0.00}", RPl.Tva),
                          String.Format("{0:0.00}", RPl.Total_TTC), String.Format("{0:0.00}", RPl.Remise),
                          String.Format("{0:0.00}", RPl.Avance), String.Format("{0:0.00}", 0),
                          "Cache", Form1.adminName, RPl.LbVidal.Text)

            Dim dt_Client As New DataTable
            ' Create four typed columns in the DataTable.
            dt_Client.Columns.Add("Clid", GetType(Integer))
            dt_Client.Columns.Add("name", GetType(String))
            dt_Client.Columns.Add("ref", GetType(String))
            dt_Client.Columns.Add("ville", GetType(String))
            dt_Client.Columns.Add("adresse", GetType(String))
            dt_Client.Columns.Add("ice", GetType(String))
            dt_Client.Columns.Add("tel", GetType(String))
            dt_Client.Columns.Add("NvCredit", GetType(String))
            dt_Client.Columns.Add("EncCredit", GetType(String))


            Dim credit As Double = 0
            Dim EncCreadit = 0
            Dim tel As String = ""
            Dim adresse = RPl.ClientAdresse.Split("*")(0)
            Dim client_ville As String = ""
            Dim client_ice As String = ""

            Try
                client_ville = RPl.ClientAdresse.Split("*")(1)
            Catch ex As Exception
                client_ville = "-"
            End Try

            Try
                client_ville = RPl.ClientAdresse.Split("*")(2)
            Catch ex As Exception
                client_ice = "-"
            End Try

            If RPl.ClId > 0 Then
                If ds.isSell Then
                    Dim ta As New ALMohassinDBDataSetTableAdapters.FactureTableAdapter
                    Dim tac As New ALMohassinDBDataSetTableAdapters.ClientTableAdapter

                    EncCreadit = ta.ScalarQueryClientCredit(False, RPl.ClId, True)
                    credit = EncCreadit + (RPl.Total_TTC - RPl.Avance)

                    tel = tac.ScalarQueryTel(RPl.ClId)
                Else
                    Dim ta As New ALMohassinDBDataSetTableAdapters.BonTableAdapter
                    EncCreadit = ta.ScalarQueryCompanyCredit(False, RPl.ClId, True)
                    credit = EncCreadit + (RPl.Total_TTC - RPl.Avance)
                End If
            End If

            ' Add  rows with those columns filled in the DataTable.
            dt_Client.Rows.Add(RPl.ClId, RPl.ClientName, RPl.ClId, client_ville,
                                adresse, client_ice, tel, credit, EncCreadit)

            Using g As gDrawClass = New gDrawClass(Form1.MP_Localname)
                g.rtl = Form1.cbRTL.Checked

                g.DrawBl(e, data, ds.DataSource, dt_Client, Form1.Facture_Title, False, M)
            End Using

        Catch ex As Exception

        End Try
    End Sub
End Class