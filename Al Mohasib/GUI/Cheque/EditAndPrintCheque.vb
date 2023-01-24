Imports System.IO
Imports System.Drawing.Printing

Public Class EditAndPrintCheque

    Dim _pid As Integer
    Dim isRelatedApp As Boolean = False
    Dim nb_trial As Integer = 0
    Dim bonId As Integer = 0
    Dim str_Path As String = ""
    Dim _montant As Double

    Public Property Pid As Integer
        Get
            Return _pid
        End Get
        Set(ByVal value As Integer)
            _pid = value

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

    Private Sub FillForm()
        Dim tableName As String = "CompanyPayment"
        Dim tName As String = "Bon"
        Dim fld As String = "bonid"
        Dim cl As String = "comid"
        Dim _pid As String = "PBid"

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)

            params.Add("PBid", Pid)
            Dim dt = c.SelectDataTable(tableName, {"*"}, params)

            If dt.Rows.Count > 0 Then
                Dim cid = IntValue(dt, cl, 0)
                Dim bid = IntValue(dt, fld, 0)

                CbWay.SelectedItem = StrValue(dt, "way", 0)
                montant = DblValue(dt, "montant", 0).ToString("N2")
                txtEcheance.text = DteValue(dt, "paydate", 0).ToString("dd/MM/yyyy")
                txtRef.text = StrValue(dt, "Num", 0)
                params.Clear()

                If cid > 0 Then
                    txtClient.text = cid

                    params.Add("compid", cid)
                    Dim nm = c.SelectByScalar("company", "name", params)
                    txtClient.text = nm & "|" & cid

                End If
                params.Clear()

                If bid > 0 Then
                    txtBon.text = bid

                    params.Add("bonid", bid)
                    Dim dtb As DataTable = c.SelectDataTable("Bon", {"*"}, params)

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
        'Try
        '    If vid > 0 Then
        '        Dim query = From d In dt_Cats.AsEnumerable()
        '                    Where d.Field(Of Integer)(0) = vid
        '                    Select d

        '        Dim r As DataTable = query.CopyToDataTable()

        '        _dt.Rows(i).Item(3) = r.Rows(0).Item("name")
        '        _dt.Rows(i).Item(7) = 0
        '    End If
        'Catch ex As Exception

        'End Try
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
    Private Function savePayement() As Boolean

        ' If Not IsNumeric(lbMontant.Text) Then Return False

        Dim _dte As Date = Date.Now
        If IsDate(txtEcheance.text) Then _dte = CDate(txtEcheance.text)


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

        Dim tableName As String = "CompanyPayment"
        Dim tName As String = "Bon"
        Dim fld As String = "fctid"
        Dim cl As String = "cid"
        Dim _pid As String = "PBid"
        Dim nPid As Integer = 0

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            params.Add("name", clientName)
            params.Add(cl, clid)
            params.Add("montant", montant)
            params.Add("way", CbWay.Text)
            params.Add("date", Now)
            params.Add("Num", txtRef.text)
            params.Add(fld, txtBon.text)
            params.Add("writer", CStr(Form1.adminName))

            nPid = c.InsertRecord(tableName, params, True)

            If isRelatedApp Then
                If bonId > 0 Then
                    Dim av As Double = CDbl(lbA.Text) + CDbl(txtMontant.text)
                    Dim isp As Boolean = av >= CDbl(lbT.Text)

                    params.Clear()
                    where.Add(fld, bonId)

                    params.Add("avance", av)
                    params.Add("payed", isp)

                    c.UpdateRecord(tName, params, where)
                    params.Clear()
                    where.Clear()
                End If
            End If

            where = Nothing
            params = Nothing
        End Using

        If nPid > 0 Then Return True
        Return False
    End Function
    Public Function EditPayement() As Boolean

        Dim tableName As String = "CompanyPayment"
        Dim tName As String = "Bon"
        Dim fld As String = "fctid"
        Dim cl As String = "cid"
        Dim _pid As String = "PBid"
        Dim nPid As Integer = 0

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            params.Add("name", clientName)
            params.Add(cl, clid)
            params.Add("montant", montant)
            params.Add("way", CbWay.Text)
            params.Add("Num", txtRef.text)
            params.Add(fld, txtBon.text)
            params.Add("writer", CStr(Form1.adminName))

            where.Add(_pid, Pid)
            nPid = c.UpdateRecord(tableName, params, where)



            If isRelatedApp Then
                If bonId > 0 Then
                    'Dim av As Double = CDbl(lbA.Text) + CDbl(txtMontant.text)
                    'Dim isp As Boolean = av >= CDbl(lbT.Text)

                    'params.Clear()
                    'where.Add(fld, bonId)

                    'params.Add("avance", av)
                    'params.Add("payed", isp)

                    'c.UpdateRecord(tName, params, where)
                    'params.Clear()
                    'where.Clear()
                End If
            End If

            where = Nothing
            params = Nothing
        End Using

        If nPid > 0 Then Return True
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
        FillBanques()
        getRegistryinfo(isRelatedApp, "isRelatedApp", False)
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
        chs.isSell = False
        chs.editMode = True 'Form1.RPl.EditMode

        If chs.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtClient.text = chs.clientName & "|" & chs.cid
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim chs As New SelectBon
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
                params.Add("bonid", chs.fctId)
                Dim dtb As DataTable = c.SelectDataTable("Bon", {"*"}, params)

                If dtb.Rows.Count > 0 Then
                    lbT.Text = DblValue(dtb, "total", 0).ToString("N2")
                    lbA.Text = DblValue(dtb, "avance", 0).ToString("N2")
                    lbR.Text = CDbl(lbT.Text) - CDbl(lbA.Text)
                End If
            End Using


        End If
    End Sub
End Class