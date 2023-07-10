Imports System.IO
Imports System.Drawing.Printing

Public Class EditAndPrintCheque

    Dim __p As Integer
    Dim isRelatedApp As Boolean = False
    Dim nb_trial As Integer = 0
    Dim bonId As Integer = 0
    Dim str_Path As String = ""
    Dim _montant As Double
    Dim tb_P As String = "CompanyPayment"
    Dim tb_F As String = "Bon"
    Dim Tb_C As String = "company"
    Dim _fld As String = "fctid"
    Dim _cl As String = "cid"
    Dim _pid As String = "PBid"
    Dim _bnk As String = ""

    Public _isSell As Boolean = False
    Dim _obs As String = ""
    Dim _pj As Integer

    Public Property Pid As Integer
        Get
            Return __p
        End Get
        Set(ByVal value As Integer)
            __p = value

            If value = 0 Then
                ClearForm()
            Else
                FillForm()
            End If
        End Set
    End Property
    Public Property clid As Integer
        Get
            Try
                If txtClient.text.Trim = "" Then Return 0
                If IsNumeric(txtClient.text.Trim) Then Return CInt(txtClient.text.Trim)

                Return txtClient.text.Split("|")(1)
            Catch ex As Exception
                Return 0
            End Try
        End Get
        Set(ByVal value As Integer)
            txtClient.text = clientName & "|" & value
        End Set
    End Property
    Public Property montant As Double
        Get
            Return _montant
        End Get
        Set(ByVal value As Double)
            _montant = value
            lbMontant.Text = value.ToString("N2") & " dhs"
        End Set
    End Property
    Public Property clientName As String
        Get
            Return txtClient.text.Split("|")(0)
        End Get
        Set(ByVal value As String)
            txtClient.text = value & "|" & clid
        End Set
    End Property
    Public Property isSell As Boolean
        Get
            Return _isSell
        End Get
        Set(ByVal value As Boolean)
            _isSell = value

            If value Then
                tb_F = "Facture"
                tb_P = "Payment"
                tb_C = "Client"
                _pid = "Pid"
            Else
                tb_F = "Bon"
                tb_P = "CompanyPayment"
                Tb_C = "company"
                _pid = "PBid"
            End If

        End Set
    End Property
    Private Property obs As String
        Get
            If Pid = 0 Then
                Return "Nv:D" & Now.ToString("ddMMyy") & "P:" & ChequePanel.adminName
            Else
                If _obs.EndsWith("D" & Now.ToString("ddMMyy") & "P:" & ChequePanel.adminName) Then Return _obs
                Dim t = _obs
                t &= "Md:D" & Now.ToString("ddMMyy") & "P:" & ChequePanel.adminName
                If t.Length >= 255 Then t = t.Substring(t.Length - 255)
                _obs = t
                Return t
            End If
        End Get
        Set(ByVal value As String)
            _obs = value
        End Set
    End Property

    Private Sub FillForm()

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)

            params.Add(_pid, Pid)
            Dim dt = c.SelectDataTable(tb_P, {"*"}, params)

            If dt.Rows.Count > 0 Then
                Dim cid = IntValue(dt, _cl, 0)
                Dim bid = IntValue(dt, _fld, 0)

                CbWay.SelectedItem = StrValue(dt, "way", 0)
                montant = DblValue(dt, "montant", 0).ToString("N2")
                txtEcheance.text = DteValue(dt, "ech", 0).ToString("dd/MM/yyyy")
                txtRef.text = StrValue(dt, "Num", 0)
                _bnk = StrValue(dt, "bank", 0)
                obs = StrValue(dt, "obs", 0)



                params.Clear()

                If cid > 0 Then
                    txtClient.text = cid
                    If isSell Then
                        params.Add("Clid", cid)
                    Else
                        params.Add("compid", cid)
                    End If

                    Dim nm = c.SelectByScalar(Tb_C, "name", params)
                    txtClient.text = nm & "|" & cid

                End If
                params.Clear()

                If bid > 0 Then
                    txtBon.text = bid

                    If isSell Then
                        params.Add(_fld, bid)
                    Else
                        params.Add("bonid", bid)
                    End If

                    Dim dtb As DataTable = c.SelectDataTable(tb_F, {"*"}, params)

                    If dtb.Rows.Count > 0 Then
                        lbT.Text = DblValue(dtb, "total", 0).ToString("N2")
                        lbA.Text = DblValue(dtb, "avance", 0).ToString("N2")
                        lbR.Text = CDbl(lbT.Text) - CDbl(lbA.Text)
                    End If
                End If

                params.Clear()

            End If

            params = Nothing
        End Using
    End Sub
   
    Private Function savePayement() As Boolean

        ' If Not IsNumeric(lbMontant.Text) Then Return False


        Dim dt As DataTable = Nothing

        ' addddd
        If Pid = 0 Then
            If AddPayement() Then Return True
            'updateeee
        Else
            If EditPayement() Then Return True
        End If

        Return False
    End Function
    Public Function AddPayement() As Boolean


        Dim _dte As Date = Date.Now
        If IsDate(txtEcheance.text) Then _dte = CDate(txtEcheance.text)

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            params.Add("name", clientName)
            params.Add(_cl, clid)
            params.Add("montant", montant)
            params.Add("way", CbWay.Text)
            params.Add("date", Now)
            params.Add("Num", txtRef.text)
            params.Add(_fld, txtBon.text)
            params.Add("writer", CStr(ChequePanel.adminName))

            params.Add("ech", _dte)
            params.Add("desig", "-")
            If cbBanque.Text.Contains("*") = False Then params.Add("bank", cbBanque.Text)
            params.Add("obs", obs)

            __p = c.InsertRecord(tb_P, params, True)

            If isRelatedApp Then
                If bonId > 0 Then
                    Dim av As Double = CDbl(lbA.Text) + CDbl(txtMontant.text)
                    Dim isp As Boolean = av >= CDbl(lbT.Text)

                    params.Clear()
                    If isSell Then
                        where.Add(_fld, bonId)
                    Else
                        where.Add("bonid", bonId)
                    End If


                    params.Add("avance", av)
                    params.Add("payed", isp)

                    c.UpdateRecord(tb_F, params, where)
                    params.Clear()
                    where.Clear()
                End If
            End If

            where = Nothing
            params = Nothing
        End Using

        If __p > 0 Then Return True
        Return False
    End Function
    Public Function EditPayement() As Boolean
        Dim _dte As Date = Date.Now
        If IsDate(txtEcheance.text) Then _dte = CDate(txtEcheance.text)
        Dim nPid As Integer = 0

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            params.Add("name", clientName)
            params.Add(_cl, clid)
            params.Add("montant", montant)
            params.Add("way", CbWay.Text)
            params.Add("Num", txtRef.text)
            params.Add(_fld, txtBon.text)
            params.Add("writer", CStr(ChequePanel.adminName))

            params.Add("ech", _dte)
            params.Add("desig", "-")
            If cbBanque.Text.Contains("*") = False Then params.Add("bank", cbBanque.Text)
            params.Add("obs", obs)




            where.Add(_pid, Pid)
            nPid = c.UpdateRecord(tb_P, params, where)
            where = Nothing
            params = Nothing
        End Using

        If nPid > 0 Then
            If isRelatedApp Then
                If bonId > 0 Then
                    Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                        Dim params As New Dictionary(Of String, Object)
                        Dim where As New Dictionary(Of String, Object)

                        params.Add(_fld, txtBon.text)
                        Dim av = c.SelectByScalar(tb_P, "SUM(montant)", params)

                        Dim isp As Boolean = av >= CDbl(lbT.Text)

                        params.Clear()
                        If isSell Then
                            where.Add(_fld, bonId)
                        Else
                            where.Add("bonid", bonId)
                        End If

                        params.Add("avance", av)
                        params.Add("payed", isp)

                        c.UpdateRecord(tb_F, params, where)
                        params.Clear()
                        where.Clear()
                    End Using
                End If
            End If

            Return True
        End If

        Return False
    End Function
    Private Sub ClearForm()
        txtClient.text = ""
        txtBon.text = ""
        lbT.Text = "00"
        lbA.Text = "00"
        lbR.Text = "00"
        montant = 0
        txtEcheance.text = Now.Date.ToString("dd/MM/yyyy")
        txtRef.text = ""
        bonId = 0

        lbMsg.Text = ""
        plMsg.Visible = False
    End Sub

    Private Sub btcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcancel.Click
        Pid = 0
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    Private Sub btcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        If savePayement() Then
            plMsg.Visible = True
            lbMsg.Text = "Opération effectuée avec succès"
            plMsg.BackColor = Color.FromArgb(222, 254, 191)
            lbMsg.ForeColor = Color.FromArgb(115, 234, 160)

        Else
            plMsg.Visible = True
            lbMsg.Text = "l'Opération a échoué"
            plMsg.BackColor = Color.FromArgb(252, 192, 170)
            lbMsg.ForeColor = Color.FromArgb(234, 147, 115)
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If savePayement() Then
            plMsg.Visible = True
            lbMsg.Text = "Opération effectuée avec succès"
            plMsg.BackColor = Color.FromArgb(222, 254, 191)
            lbMsg.ForeColor = Color.FromArgb(115, 234, 160)

        Else
            plMsg.Visible = True
            lbMsg.Text = "l'Opération a échoué"
            plMsg.BackColor = Color.FromArgb(252, 192, 170)
            lbMsg.ForeColor = Color.FromArgb(234, 147, 115)
        End If

        Try

            MP_Localname = cbBanque.Text & ".bqu"
            If cbBanque.Text.Trim.Length < 2 Then
                Dim ss As New SelectBanque
                If ss.ShowDialog = Windows.Forms.DialogResult.OK Then
                    MP_Localname = ss.SelectedBanque & ".bqu"
                End If

            End If

            Dim dl As New PrintDialog
            If dl.ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintDoc.PrinterSettings.PrinterName = dl.PrinterSettings.PrinterName

                Dim g As New bGlobClass
                g = ReadFromXmlFile(Of bGlobClass)(str_Path & "\bqu\" & MP_Localname)


                g = ReadFromXmlFile(Of bGlobClass)(str_Path & "\bqu\" & MP_Localname)
                Dim ps As New PaperSize(g.P_name, g.Wd, g.Ht)
                ps.PaperName = g.p_Kind
                PrintDoc.DefaultPageSettings.PaperSize = ps
                PrintDoc.DefaultPageSettings.Landscape = g.is_Landscape

                PrintDoc.Print()

            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Private Sub cbBanque_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cbBanque.SelectedItem = "*Cree un Nouveau*" Then
            Dim gch As New ChooseBanque
            gch.str_Path = str_Path
            If gch.ShowDialog = DialogResult.OK Then
                Dim gf As New bForm
                gf.str_Path = str_Path
                gf.localname = gch.localName
                gf.LoadXml()


                If gf.ShowDialog = DialogResult.OK Then

                End If
            End If
        End If
    End Sub
    Private Sub lbMontant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbMontant.Click
        txtMontant.TXT.Focus()
    End Sub

    Private Sub txtMontant_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMontant.Enter
        txtMontant.text = montant
        plM.BackColor = Color.GreenYellow
    End Sub

    Private Sub txtMontant_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMontant.Leave
        txtMontant.text = ""
        plM.BackColor = Color.Transparent
    End Sub

    Private Sub txtMontant_TxtChanged() Handles txtMontant.TxtChanged
        Try
            montant = txtMontant.text
        Catch ex As Exception
        End Try

        pb.BackgroundImage = DrawBl(Data_imp_Source, False, M)

    End Sub
    Private Sub PrintDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage
        Try

            Dim data As New DataTable
            ' Create four typed columns in the DataTable.
            data.Columns.Add("*", GetType(String))
            data.Columns.Add("Nom", GetType(String))
            data.Columns.Add("Date", GetType(String))
            data.Columns.Add("Montant", GetType(String))
            data.Columns.Add("En_Chiffre", GetType(String))

            Dim str_mnt_chfr As String = ""
            Try
                Dim nPart As Decimal = 0
                Dim zPart As Decimal = 0

                SplitDecimal(CDec(montant), nPart, zPart)
                Dim stt As String = ChLettre.NBLT(nPart) & " Dirhams  "
                If zPart > 0 Then
                    stt &= "et " & ChLettre.NBLT(CInt(zPart * 100)) & " (Cts)"
                End If
                'Dim strTotal As String = "Arrêté la présente facture à la somme : " & stt
                str_mnt_chfr = stt.Substring(0, 2).ToUpper() + stt.Substring(2)
            Catch ex As Exception

            End Try
            data.Rows.Add(" ", clientName, txtEcheance.text, montant.ToString("n2"), str_mnt_chfr)

            LoadXml(MP_Localname)
            DrawBl(e, data, False, M)
        Catch ex As Exception
        End Try

    End Sub
    Dim M As Integer = 0

    Public TopFieldDic As New List(Of bTopField)

    Private W_Page As Integer = 1200
    Private h_Page As Integer = 600

    Public localname As String = "Default.bqu"
    Dim p_name As String = "A4"
    Dim p_Kind As PaperKind = PaperKind.A4
    Public Sub LoadXml(ByVal localname As String)
        Dim g As New bGlobClass

        g = ReadFromXmlFile(Of bGlobClass)(str_Path & "\bqu\" & localname)
        TopFieldDic = g.TopFieldDic
        W_Page = g.W_Page
        H_Page = g.h_Page

        p_name = g.P_name
        p_Kind = g.p_Kind
    End Sub
    Public Sub DrawBl(ByRef e As System.Drawing.Printing.PrintPageEventArgs,
                           ByVal data As DataTable, ByVal HD As Boolean, ByRef m As Integer)


        Dim g = e.Graphics

        Dim isRYAL As Boolean = Form1.isBaseOnRIYAL

        Dim y As Integer = 20
        Dim h As Integer = 20
        Dim pen As New Pen(Brushes.Black, 1.0F)

        Dim sf As New StringFormat()

        Using B As New SolidBrush(Color.Black)
            For Each a As bTopField In TopFieldDic
                'Create a brush
                Dim top_x = a.x
                Dim top_y = a.y

                Dim fn As Font
                If a.isBold Then
                    fn = New Font(a.fName, a.fSize, FontStyle.Bold)
                Else
                    fn = New Font(a.fName, a.fSize)
                End If

                Try
                    If a.hasBloc Then
                        'g.DrawRectangle(pen, a.x, a.y, a.width, a.height)
                        Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                        g.FillRectangle(_br, a.x, a.y, a.width, a.height)

                        top_x += 5
                        top_y += 3
                    End If

                    If a.field.ToUpper.StartsWith("FOR") Then

                        Dim ls = a.points.Split("|")

                        Dim myPoints(ls.Length - 1) As Point
                        For n As Integer = 0 To ls.Length - 1
                            Try
                                myPoints(n) = New Point(ls(n).Split("*")(0), ls(n).Split("*")(1))
                            Catch ex As Exception
                            End Try
                        Next
                        Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                        g.FillPolygon(_br, myPoints)

                    Else
                        sf.Alignment = a.Alignement

                        Dim str As String = data.Rows(0).Item(a.field)
                        str = a.str_start & str & a.str_end
                        g.DrawString(str, fn, B, New RectangleF(top_x, top_y, a.width, a.height), sf)
                    End If

                Catch ex As Exception
                End Try
            Next
        End Using

        m = 0
    End Sub
    Public MP_Localname As String

    Private Sub EditAndPrintCheque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        str_Path = ChequePanel.str_path
        getRegistryinfo(isRelatedApp, "isRelatedApp", True)

        FillBanques()


        If isSell Then
            tb_P = "Payment"
            tb_F = "Facture"
            _fld = "fctid"
            Tb_C = "Client"
            _cl = "cid"
            _pid = "Pid"
            Me.Width = 455
        End If
    End Sub
    Private Sub FillBanques()
        Dim dir1 As New DirectoryInfo(str_Path & "\bqu")
        If dir1.Exists = False Then dir1.Create()

        Dim aryFi As IO.FileInfo() = dir1.GetFiles("*.bqu")
        Dim fi As IO.FileInfo

        cbBanque.Items.Clear()
        cbBanque.Items.Add("* Selectionner un model *")
        For Each fi In aryFi
            cbBanque.Items.Add(fi.Name.Split(".")(0))
        Next
        cbBanque.Items.Add("***")
        cbBanque.Items.Add("*Cree un Nouveau*")
    End Sub
    Private Sub getRegistryinfo(ByRef b As Boolean, ByVal str As String, ByVal v As Boolean)
        Try
            Dim msg As Boolean
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ALM_ImpCheq", str, Nothing)
            If msg = Nothing Then
                msg = v
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ALM_ImpCheq", str, msg)
                b = msg
            Else
                b = msg
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        txtEcheance.text = Now.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim chs As New ChoseClient
        chs.isSell = isSell
        chs.editMode = True 'Form1.RPl.EditMode

        If chs.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtClient.text = chs.clientName & "|" & chs.cid
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim chs As New SelectBon
        chs.isSell = isSell
        chs.dte1.Value = chs.dte1.Value.AddMonths(-2)
        chs.cbSearchRegler.SelectedItem = "Non Reglé"

        If txtClient.text.Contains("|") Then chs.txtArSearch.text = txtClient.text
        If IsNumeric(txtBon.text) Then chs.txtArSearch.text = txtBon.text

        If chs.ShowDialog = Windows.Forms.DialogResult.OK Then

            If chs.fctId = 0 Then
                lbT.Text = "0.00"
                lbA.Text = "0.00"
                lbR.Text = "0.00"
                Exit Sub
            End If

            txtBon.text = chs.fctId

            If chs.cId > 0 Then txtClient.text = chs.ClientName & "|" & chs.cId

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                If isSell Then
                    params.Add("fctid", chs.fctId)
                Else
                    params.Add("bonid", chs.fctId)
                End If

                Dim dtb As DataTable = c.SelectDataTable(tb_F, {"*"}, params)

                If dtb.Rows.Count > 0 Then
                    lbT.Text = DblValue(dtb, "total", 0).ToString("N2")
                    lbA.Text = DblValue(dtb, "avance", 0).ToString("N2")
                    lbR.Text = CDbl(lbT.Text) - CDbl(lbA.Text)
                End If
            End Using


        End If
    End Sub

    Private Sub cbBanque_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBanque.SelectedIndexChanged

        If isSell Then Exit Sub

        localname = cbBanque.Text
        LoadXml()
         pb.BackgroundImage = DrawBl(Data_imp_Source, False, m)


    End Sub
    Public Function DrawBl(ByVal data As DataTable, ByVal hightQ As Boolean, ByRef m As Integer)
        'Create a font   



        Dim y As Integer = 20
        Dim h As Integer = 20
        Dim pen As New Pen(Brushes.Black, 1.0F)

        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Near
        Dim sfc As New StringFormat()
        sfc.Alignment = StringAlignment.Center
        Dim sfl As New StringFormat()
        sfl.Alignment = StringAlignment.Far

        Dim _Bmp As Bitmap


        Dim _w = W_Page
        Dim _h = H_Page



        Dim params_tva As New Dictionary(Of Double, Double)

        'Create a new bitmap
        Using Bmp As New Bitmap(_w, _h, Imaging.PixelFormat.Format24bppRgb)
            'Set the resolution to 300 DPI
            If hightQ Then Bmp.SetResolution(300, 300)
            'Create a graphics object from the bitmap
            Using G As Graphics = Graphics.FromImage(Bmp)
                'Paint the canvas white
                G.Clear(Color.White)
                'Set various modes to higher quality
                If hightQ Then
                    G.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                    G.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    G.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
                    '  h = F.Height + 40
                End If


                Using B As New SolidBrush(Color.Black)
                    For Each a As bTopField In TopFieldDic

                        'Create a brush
                        Dim top_x = a.x
                        Dim top_y = a.y

                        Dim fn As Font
                        If a.isBold Then
                            fn = New Font(a.fName, a.fSize, FontStyle.Bold)
                        Else
                            fn = New Font(a.fName, a.fSize)
                        End If

                        If a.hasBloc Then
                            'g.DrawRectangle(pen, a.x, a.y, a.width, a.height)
                            Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                            G.FillRectangle(_br, a.x, a.y, a.width, a.height)

                            top_x += 5
                            top_y += 3
                        End If

                        If a.field.ToUpper.StartsWith("FOR") Then

                            Dim ls = a.points.Split("|")

                            Dim myPoints(ls.Length - 1) As Point
                            For n As Integer = 0 To ls.Length - 1
                                Try
                                    myPoints(n) = New Point(ls(n).Split("*")(0), ls(n).Split("*")(1))
                                Catch ex As Exception
                                End Try
                            Next
                            Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                            G.FillPolygon(_br, myPoints)

                        Else
                            sf.Alignment = a.Alignement
                            Dim str As String = data.Rows(0).Item(a.field)
                            str = a.str_start & str & a.str_end
                            G.DrawString(str, fn, B, New RectangleF(top_x, top_y, a.width, a.height), sf)

                            top_x -= 5
                            top_y -= 3

                            top_x += 5
                            top_y += 3
                        End If


                    Next
                End Using

                G.DrawRectangle(New Pen(Brushes.Red, 3), 5, 5, W_Page - 10, h_Page - 10)

                _Bmp = DirectCast(Bmp.Clone(), Image)
            End Using
        End Using
        m = 0
        Return _Bmp
    End Function
    Public Sub LoadXml()
        Dim g As New bGlobClass
        Try

            g = ReadFromXmlFile(Of bGlobClass)(str_Path & "\bqu\" & localname & ".bqu")

            TopFieldDic = g.TopFieldDic
            W_Page = g.W_Page
            H_Page = g.h_Page

            p_name = g.P_name
            p_Kind = g.p_Kind 
        Catch ex As Exception
        End Try
    End Sub

    Public ReadOnly Property Data_imp_Source As DataTable
        Get
            Dim data As New DataTable
            ' Create four typed columns in the DataTable.
            data.Columns.Add("*", GetType(String))
            data.Columns.Add("Nom", GetType(String))
            data.Columns.Add("Date", GetType(String))
            data.Columns.Add("Montant", GetType(String))
            data.Columns.Add("En_Chiffre", GetType(String))

            Dim str_mnt_chfr As String = ""
            Try
                Dim nPart As Decimal = 0
                Dim zPart As Decimal = 0

                SplitDecimal(CDec(montant), nPart, zPart)
                Dim stt As String = ChLettre.NBLT(nPart) & " Dirhams  "
                If zPart > 0 Then
                    stt &= "et " & ChLettre.NBLT(CInt(zPart * 100)) & " (Cts)"
                End If
                'Dim strTotal As String = "Arrêté la présente facture à la somme : " & stt
                str_mnt_chfr = stt.Substring(0, 2).ToUpper() + stt.Substring(2)
            Catch ex As Exception

            End Try
            data.Rows.Add(" ", txtClient.text.Split("|")(0), CDate(txtEcheance.text).ToString("dd/MM/yyyy"), montant, str_mnt_chfr)
            Return data
        End Get
    End Property
    Public Property pj As Integer
        Get
            Return _pj
        End Get
        Set(ByVal value As Integer)
            _pj = value

            If value = 0 Then
                lbpj.Text = "Joindre des fichiers"
            Else
                lbpj.Text = "* " & value & " Fichies"
            End If
        End Set
    End Property

    Private Sub txtClient_TxtChanged() Handles txtEcheance.TxtChanged, txtClient.TxtChanged
        pb.BackgroundImage = DrawBl(Data_imp_Source, False, M)
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbpj.LinkClicked


        If Pid = 0 Then If AddPayement() = False Then Exit Sub

        Dim add As New AddFiles
        add.id = Pid
        add.isSell = isSell
        If add.ShowDialog = DialogResult.Cancel Then

        End If

    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click

        If Pid = 0 Then If AddPayement() = False Then Exit Sub

        Dim add As New AddFiles
        add.id = Pid
        add.isSell = isSell
        If add.ShowDialog = DialogResult.Cancel Then

        End If
    End Sub
End Class