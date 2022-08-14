Imports System.IO
Imports System.Drawing.Printing

Public Class ChequePanel

    Dim _pid As Integer
    Dim isRelatedApp As Boolean = False
    Dim nb_trial As Integer = 0
    Dim bonId As Integer = 0
    Dim str_Path As String = ""

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
    Public ReadOnly Property montant As Double
        Get
            Try

                If IsNumeric(txtMontant.text.Trim) Then

                    Return txtMontant.text
                Else
                    Return 0
                End If

            Catch ex As Exception
                Return 0
            End Try
        End Get
    End Property
    Public Property clientName As String
        Get
            Return txtClient.text.Split("|")(0)
        End Get
        Set(ByVal value As String)
            txtClient.text = value & "|" & clid
        End Set
    End Property
    Public Property isActive As Boolean
        Get
            Return False
        End Get
        Set(ByVal value As Boolean)
            If value Then
                btTrial.Visible = False
            Else
                btTrial.Visible = True
                nb_trial += 1
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ALM_ImpCheq", "nb_trial", nb_trial)
                lbActive.Text = nb_trial
                lbActive.Visible = True
                If nb_trial > 99 Then
                    Dim trial As New bTrialVersion
                    If trial.ShowDialog = Windows.Forms.DialogResult.OK Then
                        MsgBox("merci de votre compréhension , Code d'activation ' est correct")
                        btTrial.Enabled = False
                    Else
                        End
                    End If
                End If
            End If

        End Set
    End Property
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
    Private Sub ClearForm()
        txtClient.text = ""
        txtBon.text = ""
        lbT.Text = "00"
        lbA.Text = "00"
        lbR.Text = "00"
        txtMontant.text = ""
        txtEcheance.text = Now.Date.ToString("dd/MM/yyyy")
        txtRef.text = ""
        bonId = 0

        lbMsg.Text = ""
        plMsg.Visible = False
    End Sub


    'FCC0AA
    'EA9373

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
                txtMontant.text = DblValue(dt, "montant", 0).ToString("N2")
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
    Private Sub getRegistryinfo(ByRef txt As String, ByVal str As String, ByVal v As String)
        Try
            Dim msg As String
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ALM_ImpCheq", str, Nothing)
            If msg = Nothing Then
                msg = v
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ALM_ImpCheq", str, msg)
                txt = msg
            Else
                txt = msg
            End If
        Catch ex As Exception

        End Try
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
    Private Sub getRegistryinfo(ByRef txt As Integer, ByVal str As String, ByVal v As Integer)
        Try
            Dim msg As Integer
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ALM_ImpCheq", str, Nothing)
            If msg = Nothing Then
                msg = v
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ALM_ImpCheq", str, msg)
                txt = msg
            Else
                txt = msg
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub HandleRegistryinfo()
        getRegistryinfo(isRelatedApp, "isRelatedApp", False)
        getRegistryinfo(nb_trial, "nb_trial", 1)
        getRegistryinfo(isActive, "ALM_ImpCheq_Ref", False)
        getRegistryinfo(str_Path, "str_Path", "")

     


    End Sub


    Private Sub ChequePanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        HandleRegistryinfo()
        FillBanques()
        StyleDatagrid(dg)
    End Sub

    Private Sub btcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcancel.Click
        ClearForm()
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

        If Not IsNumeric(txtMontant.text) Then Return False

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
        Dim fld As String = "bonid"
        Dim cl As String = "comid"
        Dim _pid As String = "PBid"
        Dim nPid As Integer = 0

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            params.Add("name", clientName)
            params.Add(cl, clid)
            params.Add("montant", txtMontant.text)
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
        Dim fld As String = "bonid"
        Dim cl As String = "comid"
        Dim _pid As String = "PBid"
        Dim nPid As Integer = 0

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            params.Add("name", clientName)
            params.Add(cl, clid)
            params.Add("montant", txtMontant.text)
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

    Private Sub cbBanque_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBanque.SelectedIndexChanged
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
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        txtC.text = ""
        txtB.text = ""
        txtD1.text = ""
        txtD2.text = ""
        txtR.text = ""
        txtM.text = ""
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Panel1.Width = 180

        txtC.text = ""
        txtB.text = ""
        txtD1.text = ""
        txtD2.text = ""
        txtR.text = ""
        txtM.text = ""
    End Sub
    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click, Button9.Click
        Panel1.Width = 333
    End Sub
    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click, Button10.Click
        Pid = 0
        Panel12.Width = 440
    End Sub
    ''' edit payement
    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click, Label20.Click
        If dg.SelectedRows.Count = 0 Then Exit Sub

        Pid = dg.SelectedRows(0).Cells(0).Value
        Panel12.Width = 440

    End Sub

    Private Sub dg_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellDoubleClick
        If dg.SelectedRows.Count = 0 Then Exit Sub

        Pid = dg.SelectedRows(0).Cells(0).Value
        Panel12.Width = 440
    End Sub
    '''ddddddddddddddd
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Panel12.Width = 10
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

            Dim params As New Dictionary(Of String, Object)

            If Not IsNothing(cbB.SelectedItem) Then If cbB.SelectedItem.ToString.Length > 2 Then params.Add("way = ", cbB.Text)
            If txtC.text.Contains("|") Then params.Add("comid = ", txtC.text.Split("|")(1))
            If IsNumeric(txtB.text) Then params.Add("bonid = ", txtB.text)

            If IsDate(txtD1.text) Then
                Dim d As Date = txtD1.text
                Dim dt1 = New DateTime(d.Year, d.Month, d.Day, 0, 1, 0, 0)
                params.Add("[date] > ", dt1)
            End If
            If IsDate(txtD2.text) Then
                Dim d As Date = txtD2.text
                Dim dt1 = New DateTime(d.Year, d.Month, d.Day, 23, 59, 0, 0)
                params.Add("[date] < ", dt1)
            End If

            If txtR.text <> "" Then params.Add("Num LIKE ", txtR.text)
            If txtM.text <> "" Then params.Add("montant = ", txtM.text)

            Dim dt As DataTable
            params.Add("name NOT  LIKE  ", "@%")

            dt = a.SelectDataTableSymbols("CompanyPayment", {"TOP 50 *"}, params)


            dg.DataSource = dt
            dg.Columns(0).Visible = False
            dg.Columns(2).Visible = False
            dg.Columns(9).Visible = False

            '  dg.Columns(1).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
            dg.Columns(3).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)

            dg.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

            dg.Columns(1).HeaderText = "Labels"
            dg.Columns(3).HeaderText = "Montant"
            dg.Columns(4).HeaderText = "M.P"
            dg.Columns(6).HeaderText = "Ref"
            dg.Columns(7).HeaderText = "Bon N°"
            dg.Columns(8).HeaderText = "Editeur"

            dg.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dg.Columns(3).DefaultCellStyle.Format = "n2"

            dg.Columns(4).DisplayIndex = 1
            dg.Columns(3).DisplayIndex = 2
            dg.Columns(5).DisplayIndex = 3

            dg.Sort(dg.Columns(0), System.ComponentModel.ListSortDirection.Descending)

            StyleDatagrid(dg)


            lbLnbr.Text = dg.Rows.Count & " Lines"
            Dim sum As Double
            Try
                sum = Convert.ToDouble(dt.Compute("SUM(montant)", String.Empty))
                lbQteIn.Text = sum.ToString("N2") & " Dhs"
            Catch ex As Exception
                lbQteIn.Text = "... "
            End Try

        End Using
    End Sub
    Private Sub StyleDatagrid(ByRef dg As DataGridView)
        dg.AutoGenerateColumns = True
        dg.BorderStyle = Windows.Forms.BorderStyle.None
        dg.CellBorderStyle = DataGridViewCellBorderStyle.None
        dg.RowsDefaultCellStyle.BackColor = Color.White
        dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew

        'dg.DefaultCellStyle.SelectionBackColor = Form1.Color_Selected_Row
        'dg.DefaultCellStyle.SelectionForeColor = Form1.Color_Selected_Text

        dg.BackgroundColor = Color.White

        dg.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dg.MultiSelect = False

        dg.AllowUserToResizeColumns = False
        dg.AllowUserToAddRows = False
        dg.AllowUserToDeleteRows = False
        dg.AllowUserToResizeRows = False
        dg.EditMode = DataGridViewEditMode.EditProgrammatically

        dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dg.RowTemplate.Height = 33
        dg.ColumnHeadersHeight = 33

        dg.Dock = DockStyle.Fill
        dg.RowHeadersVisible = False
    End Sub
    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        txtD1.text = Now.Date.ToString("dd/MM/yyyy")
    End Sub
    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        txtD2.text = Now.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click, Label17.Click
        End
    End Sub


    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label22.Click, Button16.Click
        Dim gch As New ChooseBanque
        gch.str_Path = str_Path
        If gch.ShowDialog = DialogResult.OK Then
            Dim gf As New bForm
            gf.str_Path = str_Path
            gf.localname = gch.localName
            gf.LoadXml()


            If gf.ShowDialog = DialogResult.OK Then
            End If
            FillBanques()
        End If
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

                    sf.Alignment = a.Alignement

                    Dim str As String = data.Rows(0).Item(a.field)
                    str = a.str_start & str & a.str_end
                    g.DrawString(str, fn, B, New RectangleF(top_x, top_y, a.width, a.height), sf)
                Catch ex As Exception
                End Try
            Next
        End Using
        
        m = 0
    End Sub
    Public MP_Localname As String
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

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Panel1.Width = 10
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        txtEcheance.text = Now.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub btTrial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTrial.Click
        Dim trial As New bTrialVersion
        If trial.ShowDialog = Windows.Forms.DialogResult.OK Then
            MsgBox("merci de votre compréhension , Code d'activation ' est correct")
            btTrial.Enabled = False
        End If
    End Sub

    Private Sub btSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSetting.Click
        Dim st As New bSetting
        st.str_Path = str_Path
        st.txtF1.text = str_Path
        If st.ShowDialog = Windows.Forms.DialogResult.OK Then
            If st.str_Path.Length > 8 Then
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ALM_ImpCheq", "str_Path", st.str_Path)
                str_Path = st.str_Path
            End If
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim chs As New SelectBon
        chs.dte1.Value = chs.dte1.Value.AddMonths(-2)
        chs.cbSearchRegler.SelectedItem = "Non Reglé"

        If txtClient.text.Contains("|") Then chs.txtArSearch.text = txtClient.text
        If IsNumeric(txtBon.text) Then chs.txtArSearch.text = txtBon.text

        If chs.ShowDialog = Windows.Forms.DialogResult.OK Then

            If chs.fctId = 0 Then
                txtB.text = ""
            Else
                txtB.text = chs.fctId
            End If
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim chs As New ChoseClient
        chs.isSell = False
        chs.editMode = True 'Form1.RPl.EditMode

        If chs.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtC.text = chs.clientName & "|" & chs.cid
        End If
    End Sub
End Class