Imports System.IO.Ports
Imports System.IO
Imports System.Drawing.Printing
Imports System.Net.NetworkInformation
Imports System.Text.RegularExpressions
Imports System.Text

Public Class Form1
    'members
    Private TrialName As String = "ALMsbtrFirstaRunSOFI34"
    Dim nbrDay_Trial As Integer = 120

    Public admin As Boolean
    Public adminId As Integer
    Public adminName As String
    Public isMaster As Boolean
    Public isBaseOnRIYAL As Boolean
    Public frmDbl As String = "N2"

    Public dualScrean As New Screen2

    Private isArabic As Boolean = True
    Public indexStartArticle As Integer = 0
    Public indexLastArticle As Integer

    Dim dt_filtreDataSource As DataTable
    Public dt_Depot As DataTable

    Public GlobalSidePanel As New SideGlobal
    Friend Shared page_Number As Integer
    Private ReadOnly Property addHours As Integer
        Get
            If Not IsNumeric(txtComName.text) Then Return 0
            Return CInt(txtComName.text.trim)
        End Get
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    '91   42   20  04  44
    Public ReadOnly Property ImgPah As String
        Get
            Return BtImgPah.Tag
        End Get
    End Property
    Public ReadOnly Property fontName_Normal As String
        Get
            Return txtfname.Text
        End Get
    End Property
    Public ReadOnly Property fontSize_Normal As Integer
        Get
            If IsNumeric(txtfntsize.Text) Then
                Return CInt(txtfntsize.Text)
            Else
                Return 10
            End If
        End Get
    End Property
    Public ReadOnly Property fontName_Normal_pt As String
        Get
            Return txtFnPtFr.Text
        End Get
    End Property
    Public ReadOnly Property fontSize_Normal_pt As Integer
        Get
            If IsNumeric(txtFsPtFr.Text) Then
                Return CInt(txtFsPtFr.Text)
            Else
                Return 10
            End If
        End Get
    End Property
    Public Property EnableDeleting() As Boolean
        Get
            Return True
        End Get
        Set(ByVal value As Boolean)
            RPl.BtDel.Visible = value
        End Set
    End Property
    Private _RplWidth As Integer
    Public Property RplWidth() As Integer
        Get
            Return _RplWidth
        End Get
        Set(ByVal value As Integer)
            If value <= 20 Then value = 22

            _RplWidth = value
            PlRcpt.Width = value
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "RplWidth", value)

        End Set
    End Property
    Private _RplHeight As Integer
    Public Property RplHeight() As Integer
        Get
            Return _RplHeight
        End Get
        Set(ByVal value As Integer)
            If value <= 20 Then value = 22
            _RplHeight = value
            RPl.CP.Height = value

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "RplHeight", value)

        End Set
    End Property

    Private is_true_to_end As Boolean = False

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If isThTrueFileExist() = 0 Then End
        SetTheTrueMacAdrssDb()
        If isTheTrueMacAdrss(True) = 0 Then End

        HandleRegistryinfo()

        isBaseOnRIYAL = cbRYL.Checked
        If isBaseOnRIYAL Then frmDbl = "N0"

        'is_true_to_end = True

        ''Dim CDA As New PricingGetter
        ''Dim CDA As New BarCode2
        'Dim CDA As New LabelPrinter
        '' '

        'If CDA.ShowDialog = Windows.Forms.DialogResult.Cancel Then
        '    End
        'End If


        'If is_true_to_end Then End


        Try
            'trial(Version)
            Dim trial As Boolean = checktrialMaster()
            If trial = False Then
                MsgBox("Vous devez Contacter l'adminisration pour plus d'infos")
                End
            End If
        Catch ex As Exception
        End Try



        '
        Me.DepotTableAdapter.Fill(Me.ALMohassinDBDataSet.Depot)

        Dim pwdwin As New PWDPicker

        If pwdwin.ShowDialog = Windows.Forms.DialogResult.OK Then

            If pwdwin.DGV1.SelectedRows(0).Cells(2).Value = "admin" Then
                admin = True
                adminId = pwdwin.DGV1.SelectedRows(0).Cells(0).Value
                adminName = pwdwin.DGV1.SelectedRows(0).Cells(1).Value
                'Button11.Visible = False
                btAvoir.Visible = False
            Else
                admin = False
                adminId = pwdwin.DGV1.SelectedRows(0).Cells(0).Value
                adminName = pwdwin.DGV1.SelectedRows(0).Cells(1).Value
                TabControl1.Controls.Remove(TabPageStk)
                'TabControl1.Controls.Remove(TabPageArch)
                TabControl1.Controls.Remove(TabPageParm)
                'TabControl1.Controls.Remove(TabPage)

                btHistorique.Visible = False

                Button13.Visible = False
                Button17.Visible = False

                'Button30.Visible = False
                'Button37.Visible = False
                'Button38.Visible = False

                RectangleShape6.Visible = False
            End If
        Else
            End
        End If

        Try
            ' TabControl1.Controls.Remove(TabPageStk)
            TabControl1.Controls.Remove(TabPageFac)
            TabControl1.Controls.Remove(TabPageChar)
        Catch ex As Exception
        End Try

        'fill the main page settings

        dtFacture.Text = Now.Date
        Using a As SubClass = New SubClass(1)
            'chbsell.Checked = CBool(a.SelectValues("sell", 1))
            txttitle.Text = CStr(a.SelectValues("title", 1))
            txttitlestart.Text = CStr(a.SelectValues("stitle", 1))
            txtlongerbt.Text = CStr(a.SelectValues("longerbt", 1))
            txtlargebt.Text = CStr(a.SelectValues("largebt", 1))
            txtcltcomptoir.Text = CStr(a.SelectValues("cltcomptoir", 1))
            txttel.Text = CStr(a.SelectValues("tel", 1))
            txtfntsize.Text = CStr(a.SelectValues("FontSize", 1))
            TxtSignature.Text = CStr(a.SelectValues("Signature", 1))
            txtfname.Text = CStr(a.SelectValues("Font", "arial"))
            txtfntsize.Text = CStr(a.SelectValues("FontSize", 9))
            cbsearch.Text = CStr(a.SelectValues("searchway", "Code"))

            a.FillGroupes(True)
            a.fillFactures(1)
            'a.FillMachines()
            a.AutoCompleteArticles(txtarticlearchive)
            a.AutoCompleteArticles(txtArSearch, "Client")
            'a.BlockParticulerFct()
            If cbEnsGrp.Checked Then a.FillGroupes()

            a.AutoCompleteArticlesWithRef(txtnameStock, "Article")

        End Using
        'charges
        Using a As ChargesClass = New ChargesClass
            dtChargeFrom.Value = DateSerial(Date.Now.Year, Date.Now.Month, 0)
            dtChargeTo.Value = DateSerial(Date.Now.Year, Date.Now.Month + 1, 1)
            a.FillbtCharge()
            a.GetCharges(dtChargeFrom.Value, dtChargeTo.Value, dgvCharge)
            a.GetUnPaiedCharges(dgvCharge, FlpCharges)
        End Using


        If cbShowFixedPanel.Checked Then
            Using a As SideClass = New SideClass
                a.LoadXml(PL)
            End Using
        End If


        RPl.hasManyRemise = CbArticleRemise.Checked

        Try
            'Fill List of depots
            Dim dtta As New ALMohassinDBDataSetTableAdapters.DepotTableAdapter
            dt_Depot = dtta.GetData()
        Catch ex As Exception
        End Try

        '''''''''''''''''''''''''

        If admin And cbProfit.Checked Then
            RPl.ShowProfit = True
        Else
            RPl.ShowProfit = False
        End If
        If isBaseOnRIYAL Then RPl.PlHeader.Height = 80

        'RPl.ShowClc = CbBlocCalc.Checked
        RPl.hideClc = CbBlocCalc.Checked
        RPl.TypePrinter = cbPaper.Text
        RPl.isSell = True
        If CbDepotOrigine.Checked Then plDepot.Visible = False

        plTarif.Visible = chbsell.Checked

        GB1.Width = 35
        GB2.Width = 35
        GB3.Width = 35
        GB4.Width = 35
        GB5.Width = 35
        GB6.Width = 35
        GB7.Width = 35

        'fulscreen 
        Call CenterToScreen()
        'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized


        'Second Screan
        Try
            If cbDual.Checked Then
                dualScrean.Location = Screen.AllScreens(UBound(Screen.AllScreens)).Bounds.Location + New Point(100, 60)
                dualScrean.Show()
                dualScrean.TopMost = True
            End If
        Catch ex As Exception

        End Try

        Me.Show()

        Try
            getRegistryinfo(RplWidth, "RplWidth", 404)
            getRegistryinfo(RplHeight, "RplHeight", 248)
        Catch ex As Exception
        End Try


        If cbListToRight.Checked Then PlRcpt.Dock = DockStyle.Right


        'Select Search txtbox
        If chbcb.Checked Then
            txtSearchCode.Text = ""
            txtSearchCode.Focus()
        Else
            txtSearch.Text = ""
            txtSearch.Focus()
        End If
    End Sub

    ' function keys
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message,
                                               ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim k As System.Windows.Forms.Keys = keyData
        Select Case keyData

            Case Keys.F1
                If RPl.FctId = 0 Or RPl.EditMode = True Or RPl.CP.isActive = False Then Return False
                Dim qte = 0.01
                If RPl.SelectedItem.Unite = "g" Or RPl.SelectedItem.Unite = "ج" Then qte = 10
                Using a As SubClass = New SubClass
                    a.UpdateItem(RPl.SelectedItem, RPl.SelectedItem.Qte + qte, RPl.isSell, "qte")
                End Using
            Case Keys.F2
                If RPl.FctId = 0 Or RPl.EditMode = True Or RPl.CP.isActive = False Then Return False
                Dim qte = 0.05
                If RPl.SelectedItem.Unite = "g" Or RPl.SelectedItem.Unite = "ج" Then qte = 50
                Using a As SubClass = New SubClass
                    a.UpdateItem(RPl.SelectedItem, RPl.SelectedItem.Qte + qte, RPl.isSell, "qte")
                End Using
            Case Keys.F3
                If RPl.FctId = 0 Or RPl.EditMode = True Or RPl.CP.isActive = False Then Return False
                Dim qte = 0.1
                If RPl.SelectedItem.Unite = "g" Or RPl.SelectedItem.Unite = "ج" Then qte = 100
                Using a As SubClass = New SubClass
                    a.UpdateItem(RPl.SelectedItem, RPl.SelectedItem.Qte + qte, RPl.isSell, "qte")
                End Using
            Case Keys.F4
                If RPl.FctId = 0 Or RPl.EditMode = True Or RPl.CP.isActive = False Then Return False
                Dim qte = 0.25
                If RPl.SelectedItem.Unite = "g" Or RPl.SelectedItem.Unite = "ج" Then qte = 250
                Using a As SubClass = New SubClass
                    a.UpdateItem(RPl.SelectedItem, RPl.SelectedItem.Qte + qte, RPl.isSell, "qte")
                End Using
            Case Keys.F5
                If RPl.FctId = 0 Or RPl.EditMode = True Or RPl.CP.isActive = False Then Return False
                Dim qte = 0.5
                If RPl.SelectedItem.Unite = "g" Or RPl.SelectedItem.Unite = "ج" Then qte = 500
                Using a As SubClass = New SubClass
                    a.UpdateItem(RPl.SelectedItem, RPl.SelectedItem.Qte + qte, RPl.isSell, "qte")
                End Using

            Case Keys.Escape 'qte of 0 the an article


                If RPl.FctId = 0 Or RPl.EditMode = True Or RPl.CP.isActive = False Then Return False
                Using a As SubClass = New SubClass
                    a.UpdateItem(RPl.SelectedItem, 0, RPl.isSell, "qte")
                End Using

                'Case Keys.Back 'delete item
                '    If RPl.FctId = 0 Or RPl.EditMode = True Or RPl.CP.isActive = False Then Return False
                '    Using a As SubClass = New SubClass(btswitsh.Tag)
                '        a.DeleteItem(RPl.SelectedItem, RPl.FctId)
                '    End Using
            Case Keys.Add ' add one
                If RPl.FctId = 0 Or RPl.EditMode = True Or RPl.CP.isActive = False Then Return False
                Using a As SubClass = New SubClass
                    a.UpdateItem(RPl.SelectedItem, RPl.SelectedItem.Qte + 1, RPl.isSell, "qte")
                End Using
            Case Keys.Subtract  ' sub one
                If RPl.FctId = 0 Or RPl.EditMode = True Or RPl.CP.isActive = False Then Return False
                Using a As SubClass = New SubClass
                    Dim qte = RPl.SelectedItem.Qte - 1
                    If qte < 0 Then qte = 0
                    a.UpdateItem(RPl.SelectedItem, qte, RPl.isSell, "qte")
                End Using
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''End qte
            Case Keys.F6
                If RPl.FctId = 0 Or RPl.EditMode = True Then Return False
                Dim bp As New byPrice
                If bp.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim tableName = "DetailsFacture"
                    If btswitsh.Tag = 0 Then tableName = "DetailsBon"
                    Dim arid As Integer = 0
                    'qte
                    Dim qte As Double = 1

                    'Price
                    Dim price As Double = CDbl(bp.txt.Text)
                    'tva
                    Dim tva As Double = 20

                    Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                        Dim params As New Dictionary(Of String, Object)
                        params.Add("fctid", CInt(RPl.FctId))
                        params.Add("name", "Article")
                        params.Add("bprice", price)
                        params.Add("price", price)
                        params.Add("unit", "u")
                        params.Add("qte", qte)
                        params.Add("tva", tva)
                        params.Add("poid", 1)
                        params.Add("arid", 0)
                        params.Add("depot", 0)
                        params.Add("code", "")
                        params.Add("cid", 0)

                        arid = c.InsertRecord(tableName, params, True)
                    End Using

                    If arid > 0 Then
                        Dim bt As New Button
                        bt.Text = RPl.ClientName
                        bt.Tag = RPl.FctId
                        Using a As SubClass = New SubClass
                            a.FactureSelected(bt, Nothing)
                        End Using
                    End If
                End If
            Case Keys.F8 ' add NOUVEAU FACTURE
                If plright.Controls.Count > 10 Then Return False
                Using a As SubClass = New SubClass
                    Try
                        Dim cid As String = 0
                        Dim clientname As String = txtcltcomptoir.Text.Split("/")(0)
                        If RPl.isSell Then a.NewFacture(cid, clientname, "", 0)
                    Catch ex As Exception
                    End Try
                End Using

            Case Keys.F9 ' add NOUVEAU FACTURE
                If plright.Controls.Count > 10 Then Return False
                Using a As SubClass = New SubClass()
                    a.NewFacture(CInt(btswitsh.Tag))
                End Using

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'cash drawer
            Case Keys.F12
                'Modify DrawerCode to your receipt printer open drawer code
                Dim DrawerCode As String = Chr(27) & Chr(112) & Chr(48) & Chr(64) & Chr(64)
                'Modify PrinterName to your receipt printer name
                Dim PrinterName As String = txtreceipt.Text

                RawPrinter.PrintRaw(PrinterName, DrawerCode)
                'change Mode de recherche

            Case Keys.F11

                If RPl.isSell Then

                    Dim pt As New PriceType

                    If pt.ShowDialog = Windows.Forms.DialogResult.OK Then

                        If pt.value = 0 Then Return MyBase.ProcessCmdKey(msg, keyData)

                        Using a As SubClass = New SubClass()

                            a.ChangeAllPrices(pt.value)
                            Dim bt As New Button
                            bt.Text = RPl.ClientName
                            bt.Tag = RPl.FctId

                            a.FactureSelected(bt, Nothing)
                        End Using
                    End If
                End If
            Case Keys.Tab
                If txtSearch.Focused = False And txtSearchCode.Focused = False Then
                    Return MyBase.ProcessCmdKey(msg, keyData)
                Else
                    chbcb.Checked = Not chbcb.Checked
                    txtArSearch.text = ""
                    txtSearch.Text = ""

                    If chbcb.Checked Then
                        txtSearchCode.Text = ""
                    Else
                        txtSearch.Focus()
                    End If
                End If

            Case Keys.Space  ' save and print

                If RPl.EditMode = True Then Return False

                Dim a As Integer = 0

                If txtSearch.Focused Then a = 1
                If txtSearchCode.Focused Then a = 1

                'cancel espace
                ' a = 0

                If a = 1 Then
                    If RPl.Total_TTC = 0 Then
                        Return MyBase.ProcessCmdKey(msg, keyData)
                    End If

                    If txtSearch.Text.Trim <> "" Or txtSearchCode.Text.Trim <> "" Then
                        Return MyBase.ProcessCmdKey(msg, keyData)
                    End If



                    If cbPaper.Text = "Receipt" Then
                        RPl_SaveAndPrint(RPl.FctId, RPl.Total_TTC, RPl.Avance, RPl.Tva, RPl.DataSource, RPl.isSell, False, False)
                    ElseIf cbPaper.Text = "Normal" Then
                        RPl_SaveAndPrint(RPl.FctId, RPl.Total_TTC, RPl.Avance, RPl.Tva, RPl.DataSource, RPl.isSell, True, False)
                    ElseIf cbPaper.Text = "Normal&A4" Then
                        RPl_SaveAndPrint(RPl.FctId, RPl.Total_TTC, RPl.Avance, RPl.Tva, RPl.DataSource, RPl.isSell, True, False)
                    Else
                        RPl_SaveAndPrint(RPl.FctId, RPl.Total_TTC, RPl.Avance, RPl.Tva, RPl.DataSource, RPl.isSell, False, False)
                    End If
                Else
                    Return MyBase.ProcessCmdKey(msg, keyData)
                End If

            Case Keys.Delete ' delete facture
                If RPl.FctId = 0 Then Return False
                Dim str As String = " عند قيامكم على الضغط على 'موافق' سيتم حذف فاتورة "
                str = str + vbNewLine
                str = str & RPl.ClientName & " ( " & RPl.FctId & ")"
                str = str + vbNewLine
                str = str + " و جميع المواد الدفعات المسجلة في القائمة ..    "
                str = str + vbNewLine
                str = str + "  .. إضغط  'لا'  لالغاء الحذف   "

                If MsgBox(str, MsgBoxStyle.YesNo Or MessageBoxIcon.Exclamation, "الغاء الفاتورة") = MsgBoxResult.No Then
                    Return False
                End If
                RPl_DeleteFacture(RPl.FctId, RPl.isSell, RPl.EditMode, RPl.DataSource)

                'Case Keys.CapsLock  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '    Try
                '        Dim sp As SerialPort = New SerialPort("COM2", 9600, Parity.None, 8, StopBits.One)

                '        sp.Open()
                '        sp.Write(Convert.ToString(ChrW(12)))
                '        sp.WriteLine("Total : 1234 DH")
                '        sp.WriteLine(ChrW(13) & "Tendered EZFZEEZFEZF RM")
                '        sp.Close()
                '        sp.Dispose()
                '        sp = Nothing
                '        MsgBox("Total : 1234 DH")
                '    Catch ex As Exception
                '        MsgBox(ex.Message)
                '    End Try

            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)
        End Select








        If RPl.EditMode = False Then
            'Select Search txtbox
            If chbcb.Checked Then
                txtSearchCode.Text = ""
                txtSearchCode.Focus()
            Else
                txtSearch.Text = ""
                txtSearch.Focus()
            End If
        End If


        Return True
    End Function

    Private Sub getRegistryinfo(ByRef txt As TextBox, ByVal str As String, ByVal v As String)
        Try
            Dim msg As String
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, Nothing)
            If msg = Nothing Then
                msg = v
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, msg)
                txt.Text = msg
            Else
                txt.Text = msg
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub getRegistryinfo(ByRef txt As ComboBox, ByVal str As String, ByVal v As String)
        Try
            Dim msg As String
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, Nothing)
            If msg = Nothing Then
                msg = v
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, msg)
                txt.Text = msg
            Else
                txt.Text = msg
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub getRegistryinfo(ByRef cb As CheckBox, ByVal str As String, ByVal v As Boolean)
        Try
            Dim msg As Boolean
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, Nothing)
            If IsNothing(msg) Then
                msg = v
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, msg)
                cb.Checked = msg
            Else
                cb.Checked = msg
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub getRegistryinfo(ByRef txt As Integer, ByVal str As String, ByVal v As Integer)
        Try
            Dim msg As Integer
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, Nothing)
            If msg = Nothing Then
                msg = v
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, msg)
                txt = msg
            Else
                txt = msg
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub HandleRegistryinfo()

        Dim msg As String
        Try
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtNbrArt", Nothing)
            If msg = Nothing Then
                msg = "20"
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtNbrArt", msg)
                txtNbrArt.Text = msg
                indexLastArticle = 20
            Else
                txtNbrArt.Text = msg
                indexLastArticle = CInt(msg)
            End If
        Catch ex As Exception
            indexLastArticle = 20
        End Try
        msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "SouvPath", Nothing)
        If msg = Nothing Then
            msg = "C:"
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "SouvPath", msg)
            btSvPath.Tag = msg
        Else
            btSvPath.Tag = msg
        End If

        msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "ImgPath", Nothing)
        If msg = Nothing Then
            msg = "C:\Al Mohassib"
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "ImgPath", msg)
            BtImgPah.Tag = msg
        Else
            BtImgPah.Tag = msg
        End If

        msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "BtBoundDbPath", Nothing)
        If msg = Nothing Then
            msg = "C:\Al Mohassib"
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "BtBoundDbPath", msg)
            BtBoundDbPath.Tag = msg
        Else
            BtBoundDbPath.Tag = msg
        End If
        msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "btDbDv", Nothing)
        If msg = Nothing Then
            msg = "C:\Al Mohassib"
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "btDbDv", msg)
            btDbDv.Tag = msg
        Else
            btDbDv.Tag = msg
        End If




        getRegistryinfo(txttimp, "mainprinter", "no")
        getRegistryinfo(txtprt2, "prt2", "no")
        getRegistryinfo(txtreceipt, "receipt", "no")
        getRegistryinfo(txtScale, "txtScale", "1")
        getRegistryinfo(TextBox4, "LogoPath", "C:")
        getRegistryinfo(cbsearch, "SearchMethod", "الكود (الرمز)")

        getRegistryinfo(cbPaper, "cbPaper", "Normal&Receipt")
        getRegistryinfo(txtNbrCopie, "txtNbrCopie", "1")
        getRegistryinfo(txtEnsGrp, "txtEnsGrp", "1")
        getRegistryinfo(txtEnteteMarge, "txtEnteteMarge", "160")
        getRegistryinfo(txtPiedMarge, "txtPiedMarge", "750")
        getRegistryinfo(txtDptSkiped, "txtDptSkiped", "")
        getRegistryinfo(txtComName, "txtHours", "COM2")

        getRegistryinfo(chbsell, "chbsell", False)
        getRegistryinfo(CbArticleRemise, "CbArticleRemise", False)
        getRegistryinfo(chbprint, "chbprint", False)
        getRegistryinfo(chbreceipt, "chbreceipt", False)
        getRegistryinfo(chbcb, "UseCodebarScanner", False)
        getRegistryinfo(CbBlocModArt, "CbBlocModArt", False)
        getRegistryinfo(CbBlocCalc, "CbBlocCalc", False)
        getRegistryinfo(cbProfit, "cbProfit", False)
        getRegistryinfo(CBTVA, "CBTVA", False)
        getRegistryinfo(chbsell, "chbsell", False)
        getRegistryinfo(cbImgPrice, "cbImgPrice", False)
        getRegistryinfo(cbQte, "cbQte", False)
        getRegistryinfo(cbBonToFact, "cbBonToFact", False)
        getRegistryinfo(CbDelaiFct, "CbDelaiFct", False)
        getRegistryinfo(chMasar, "chMasar", False)
        getRegistryinfo(cbMultiPayemnt, "cbMultiPayemnt", False)
        getRegistryinfo(cbheader, "cbheader", False)
        getRegistryinfo(cbMergeArt, "cbMergeArt", True)
        getRegistryinfo(cbUnite, "cbUnite", False)
        getRegistryinfo(CbDisArch, "CbDisArch", False)
        getRegistryinfo(CbQteStk, "CbDisNew", False)
        getRegistryinfo(cbPrintDepot, "cbPrintDepot", True)
        getRegistryinfo(CbDepotOrigine, "CbDepotOrigine", True)
        getRegistryinfo(cbDual, "cbDual", False)
        getRegistryinfo(cbTiroir, "cbTiroir", False)
        getRegistryinfo(cbCaisse, "cbCaisse", False)
        getRegistryinfo(cbTsImg, "cbTsImg", False)
        getRegistryinfo(cbRTL, "cbRTL", False)
        getRegistryinfo(cbEnsGrp, "cbEnsGrp", False)
        getRegistryinfo(cbShowRef, "cbShowRef", False)
        getRegistryinfo(cbSuppression, "cbSuppression", False)
        getRegistryinfo(cbNormalImp, "cbNormalImp", True)
        getRegistryinfo(cbShowGloblCredit, "cbShowGloblCredit", False)
        getRegistryinfo(cbOptionJenani, "cbOptionJenani", False)
        getRegistryinfo(cbListToRight, "cbListToRight", False)
        getRegistryinfo(cbJnImgDb, "cbJnImgDb", False)
        getRegistryinfo(cbArticleItemDirection, "cbArticleItemDirection", False)
        getRegistryinfo(cbJnReduireQte, "cbJnReduireQte", False)

        getRegistryinfo(txtFnPtFr, "txtFnPtFr", "Arial")
        getRegistryinfo(txtFsPtFr, "txtFsPtFr", 10)

        getRegistryinfo(cbQteCat, "cbQteCat", False)
        getRegistryinfo(txtQteCat, "txtQteCat", "")

        getRegistryinfo(cbCodeDouble, "cbCodeDouble", False)
        getRegistryinfo(cbAffichageLimite, "cbAffichageLimite", False)
        getRegistryinfo(cbBaseOnStartedRemise, "cbBaseOnStartedRemise", False)
        getRegistryinfo(cbShowDialogPrint, "cbShowDialogPrint", False)
        getRegistryinfo(cbRYL, "cbRYL", False)
        getRegistryinfo(cbUseStar, "cbUseStar", False)
        getRegistryinfo(cbShowFixedPanel, "cbShowFixedPanel", False)
        getRegistryinfo(cbPvArticle, "cbPvArticle", False)
        getRegistryinfo(cbPvCats, "cbPvCats", False)
        getRegistryinfo(cbPvClient, "cbPvClient", False)
        getRegistryinfo(isOrderByIdDesc_items, "isOrderByIdDesc_items", False)


        gbprint.Enabled = chbprint.Checked


        msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "EnableDeleting", Nothing)
        If msg = Nothing Then
            msg = True
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "EnableDeleting", msg)
            EnableDeleting = msg
        Else
            EnableDeleting = msg
        End If


    End Sub
    ' for master
    Private Function checktrialMaster() As Boolean
        isMaster = True
        'Using a As BoundClass = New BoundClass
        '    'If a.LoadNewChangement() Then
        '    '    a.DeletOldFiles()
        '   End If
        'End Using

        '  checktrialMaster_Contrat()




        Dim resultkey As Integer = HandleRegistry2()
        If resultkey = 0 Then 'something went wrong
            Dim fdt As Date
            fdt = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", TrialName, Nothing)
            Try
                Dim ta As New ALMohassinDBDataSetTableAdapters.valueTableAdapter

                Dim dt2 = ta.GetData("truefont")

                If dt2.Rows(0).Item("val") = "true" Then
                    bttrial.Enabled = False
                    Return True
                    Exit Function
                Else
                    Dim trial As New TrialVersion
                    If trial.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                        Return False
                        Exit Function
                    Else
                        Return True
                        Exit Function
                    End If
                End If
            Catch ex As Exception
                Return False
            End Try
        Else

            Try
                Dim ta As New ALMohassinDBDataSetTableAdapters.valueTableAdapter
                Dim dt = ta.GetData("truefont")
                If dt.Rows(0).Item("val") = "true" Then
                    bttrial.Enabled = False
                Else
                    Dim ms = "Votre licence d'application expirera bientôt" & vbNewLine
                    ms &= "***** ---------------------------------------------***** " & vbNewLine & vbNewLine

                    ms &= "Vous devez activer les fenêtres dans les paramètres." & vbNewLine

                    Try
                        Dim ALMohasibfirstRunDate As Date
                        ALMohasibfirstRunDate = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", TrialName, Nothing)

                        ms &= "Merci de contactez le support technique avant : " & vbNewLine
                        ms &= nbrDay_Trial - (Now - ALMohasibfirstRunDate).Days & "Jours" & vbNewLine
                        ms &= "--------------------------------- "
                    Catch ex As Exception
                    End Try

                    MsgBox(ms, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "AL Mohasib POS \*****/")
                End If
                Return True
            Catch ex As Exception
                Return True
            End Try

        End If
    End Function
    Private Function HandleRegistry2() As Integer


        Dim ALMohasibfirstRunDate As Date
        Dim LastRunDate As Date

        ALMohasibfirstRunDate = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", TrialName, Nothing)

        LastRunDate = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", "lastDate" & TrialName, Nothing)



        '''''''''''''''''''''''''''''''''''''''''''''       '''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''       '''''''''''''''''''''''''''''''''''''''''''''
        LastRunDate = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", "lastDate" & TrialName, Nothing)

        Dim sz = (Now - LastRunDate).Days

        'Reglage de date 
        If LastRunDate = Nothing Then
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", "lastDate" & TrialName, Now.Date)
        ElseIf (Now - LastRunDate).Days <= -1 Then
            MsgBox("Merci de regler la date de votre PC .." & LastRunDate, MsgBoxStyle.Information, "Error_Date")
            End
        End If

        If CDate(Now) > CDate(LastRunDate) Then My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", "lastDate" & TrialName, Now.Date)

        '''''''''''''''''''''''''''''''''''''''''''''       '''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''       '''''''''''''''''''''''''''''''''''''''''''''

        'mac adresse
        Dim mac = getMacAddress()
        mac = Regex.Replace(mac, "[^0-9]", "")

        If ALMohasibfirstRunDate = Nothing Then
            ALMohasibfirstRunDate = Now
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", TrialName, ALMohasibfirstRunDate)
            Try
                Dim ta As New ALMohassinDBDataSetTableAdapters.valueTableAdapter
                Dim dt = ta.GetData("keypsv")
                Dim val As String = ALMohasibfirstRunDate.Day & ALMohasibfirstRunDate.Hour & "-" & ALMohasibfirstRunDate.Second & "1d5-" & ALMohasibfirstRunDate.ToString("yy") & "2H7" & "-" & mac.ToString.Substring(mac.ToString.Length - 4) & "-" & mac.ToString.Substring(0, 4) & ALMohasibfirstRunDate.Month
                If dt.Rows.Count > 0 Then
                    ta.UpdateKeyVal(val, "keypsv")
                Else
                    ta.Insert("keypsv", val)
                End If
                Dim dt2 = ta.GetData("truefont")
                If dt.Rows.Count > 0 Then
                    ta.UpdateKeyVal("false", "truefont")
                Else
                    ta.Insert("truefont", "False")
                End If
                MsgBox("AL Mohasib System de gestion - Premier utilisation ..")

            Catch ex As Exception
                MsgBox("Error 1 : frst run " & vbNewLine & ex.Message)

            End Try
            Return 1
        ElseIf (Now - ALMohasibfirstRunDate).Days > nbrDay_Trial Then
            Try

                Dim ta As New ALMohassinDBDataSetTableAdapters.valueTableAdapter
                Dim dt = ta.GetData("keypsv")
                Dim val As String = ALMohasibfirstRunDate.Day & ALMohasibfirstRunDate.Hour & "-" & ALMohasibfirstRunDate.Second & "1d5-" & ALMohasibfirstRunDate.ToString("yy") & "2H7" & "-" & mac.ToString.Substring(mac.ToString.Length - 4) & "-" & mac.ToString.Substring(0, 4) & ALMohasibfirstRunDate.Month
                ''''''
                If dt.Rows.Count > 0 Then

                    If dt.Rows(0).Item("val") <> val Then

                        ta.UpdateKeyVal(val, "keypsv")
                        Dim dt2 = ta.GetData("truefont")
                        If dt.Rows.Count > 0 Then
                            ta.UpdateKeyVal("false", "truefont")
                        Else
                            ta.Insert("truefont", "False")
                            MsgBox("AL Mohasib System de gestion - Premier utilisation ..")
                        End If

                    Else

                    End If
                Else

                    ta.Insert("keypsv", val)
                    Dim dt2 = ta.GetData("truefont")
                    If dt.Rows.Count > 0 Then
                        ta.UpdateKeyVal("false", "truefont")
                    Else
                        ta.Insert("truefont", "False")
                    End If
                    MsgBox("AL Mohasib System de gestion - Premier utilisation ..")

                End If
                '''''''

            Catch ex As Exception
                MsgBox("Error 2 : scnd run " & vbNewLine & ex.Message)
            End Try
            Return 0
        Else

            Try
                Dim ta As New ALMohassinDBDataSetTableAdapters.valueTableAdapter
                Dim dt = ta.GetData("keypsv")
                Dim val As String = ALMohasibfirstRunDate.Day & ALMohasibfirstRunDate.Hour & "-" & ALMohasibfirstRunDate.Second & "1d5-" & ALMohasibfirstRunDate.ToString("yy") & "2H7" & "-" & mac.ToString.Substring(mac.ToString.Length - 4) & "-" & mac.ToString.Substring(0, 4) & ALMohasibfirstRunDate.Month
                ''''''
                If dt.Rows.Count > 0 Then

                    If dt.Rows(0).Item("val") <> val Then

                        ta.UpdateKeyVal(val, "keypsv")
                        Dim dt2 = ta.GetData("truefont")
                        If dt.Rows.Count > 0 Then
                            ta.UpdateKeyVal("false", "truefont")
                        Else

                            ta.Insert("truefont", "False")
                            MsgBox("AL Mohasib System de gestion - Premier utilisation ..")
                        End If

                    Else

                    End If
                Else

                    ta.Insert("keypsv", val)
                    Dim dt2 = ta.GetData("truefont")
                    If dt.Rows.Count > 0 Then
                        ta.UpdateKeyVal("false", "truefont")
                    Else
                        ta.Insert("truefont", "False")
                    End If
                    MsgBox("AL Mohasib System de gestion - Premier utilisation ..")

                End If
                '''''''

            Catch ex As Exception
                MsgBox("Error 3 : trd run " & vbNewLine & ex.Message)
            End Try
            Return 1
        End If

    End Function
    Private Sub checktrialMaster_Contrat()

        'Dim LastRunDate = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", "date_contrat", Nothing)

        ''Regla$* de date 
        'If LastRunDate = Nothing Then
        '    My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", "date_contrat", 0)
        '    LastRunDate = 0
        'End If

        Dim ALMohasibfirstRunDate As Date
        ALMohasibfirstRunDate = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", TrialName, Nothing)

        'mac adresse
        Dim mac = getMacAddress()
        mac = Regex.Replace(mac, "[^0-9]", "")

        If (Now - ALMohasibfirstRunDate).Days > 330 Then
            Dim ta As New ALMohassinDBDataSetTableAdapters.valueTableAdapter

            Try
                ta.UpdateKeyVal("false", "truefont")
            Catch ex As Exception
            End Try

            ALMohasibfirstRunDate = Now
            Dim val As String = ALMohasibfirstRunDate.Day & ALMohasibfirstRunDate.Hour & "-" & ALMohasibfirstRunDate.Second & "1d5-" & ALMohasibfirstRunDate.ToString("yy") & "2H7" & "-" & mac.ToString.Substring(mac.ToString.Length - 4) & "-" & mac.ToString.Substring(0, 4) & ALMohasibfirstRunDate.Month

            Try
                ta.UpdateKeyVal(val, "keypsv")
            Catch ex As Exception
            End Try

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", TrialName, ALMohasibfirstRunDate)
        End If


    End Sub
    Function getMacAddress()
        Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()
        Return nics(1).GetPhysicalAddress.ToString
    End Function

    Private Sub SetTheTrueMacAdrssDb()

        Dim ta As New ALMohassinDBDataSetTableAdapters.valueTableAdapter
        Dim dt = ta.GetData(myMacAdd.Split("/")(0))
        If dt.Rows.Count > 0 Then
        Else
            ta.Insert(myMacAdd.Split("/")(0), myMacAdd.Split("/")(1))

            Dim dt2 = ta.GetData("truefont")
            If dt2.Rows.Count > 0 Then
                ta.UpdateKeyVal("false", "truefont")
            Else
                ta.Insert("truefont", "False")
            End If
        End If
    End Sub
    Private Function isTheTrueMacAdrss(ByVal b As Boolean) As Integer
        'cheque for mac adresse
        Dim strReg = "Mac_Cmc_adr"
        Dim myMac As String = myMacAdd.Split("/")(0)
        Dim regMac As String = ""

        regMac = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", strReg, Nothing)


        If regMac = Nothing Then
            regMac = myMac

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", strReg, regMac)
            Try

                Dim ta As New ALMohassinDBDataSetTableAdapters.valueTableAdapter
                Dim dt2 = ta.GetData("truefont")
                If dt2.Rows.Count > 0 Then
                    ta.UpdateKeyVal("false", "truefont")
                Else
                    ta.Insert("truefont", "False")
                End If


                MsgBox("AL Mohasib System de gestion - Premier utilisation ..")

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
            Return 1
        ElseIf regMac <> myMac Then
            Try

                If b Then
                    Dim ta As New ALMohassinDBDataSetTableAdapters.valueTableAdapter
                    Dim dt2 = ta.GetData("truefont")
                    If dt2.Rows.Count > 0 Then
                        ta.UpdateKeyVal("false", "truefont")
                    Else
                        ta.Insert("truefont", "False")
                        MsgBox("AL Mohasib System de gestion - Premier utilisation ..")
                    End If
                End If

                Dim m = InputBox("Code =  " & Now.Day)
                If Not IsNumeric(m) Then Return 0 ' end


                Dim tr = Now.Day * 11
                tr += 123
                tr += 111

                tr = CInt(Now.Day() & "1" & tr & "0")
                If m = tr Then
                    regMac = myMac
                    My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", strReg, regMac)
                    Return 1
                Else
                    Return 0
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Return 0
            End Try
        Else
            Return 1
        End If

    End Function
    Dim myMacAdd As String = ""
    Private Function isThTrueFileExist() As Integer
        Dim strReg = "File_Cmc_True_Path"
        Dim path As String = "c:\cmc.txt"
        Dim regFile As String = ""

        regFile = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", strReg, Nothing)

        Try
            If regFile = Nothing Then

                Dim m = InputBox("Code = NV fl txt dt pl 3 mo 1000")
                If Not IsNumeric(m) Then Return 0 ' end
                Dim tr = (Now.Day + Now.Month + Now.Year) - 1000

                If m = tr Then

                    ' Create or overwrite the file.
                    Dim fs As FileStream = File.Create(path)

                    ' Add text to the file.
                    Dim mac = getMacAddress()
                    mac = Regex.Replace(mac, "[^0-9]", "")
                    mac &= "/" & Now.Date.ToString("ddMMyy")
                    Dim info As Byte() = New UTF8Encoding(True).GetBytes(mac)
                    fs.Write(info, 0, info.Length)
                    fs.Close()
                    myMacAdd = mac
                    File.SetAttributes(path, FileAttributes.Hidden)

                    My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", strReg, 112)
                    Return 1
                Else
                    Return 0
                End If

            Else


                If System.IO.File.Exists(path) Then
                    myMacAdd = My.Computer.FileSystem.ReadAllText(path, System.Text.Encoding.UTF8)

                    If myMacAdd.Contains("/") = False Then
                        My.Computer.FileSystem.DeleteFile(path)
                        Dim mac = getMacAddress()
                        mac = Regex.Replace(mac, "[^0-9]", "")
                        mac &= "/" & Now.Date.ToString("ddMMyy")
                        Dim fs As FileStream = File.Create(path)
                        Dim info As Byte() = New UTF8Encoding(True).GetBytes(mac)
                        fs.Write(info, 0, info.Length)
                        fs.Close()
                        myMacAdd = mac
                    End If
                    Return 1
                Else
                    Dim m = InputBox("Code = MS fl txt dt pl 3 mo 1000")
                    If Not IsNumeric(m) Then Return 0 ' end
                    Dim tr = (Now.Day + Now.Month + Now.Year) - 1000

                    If m = tr Then

                        ' Create or overwrite the file.
                        Dim fs As FileStream = File.Create(path)

                        ' Add text to the file.
                        Dim mac = getMacAddress()
                        mac = Regex.Replace(mac, "[^0-9]", "")
                        mac &= "/" & Now.Date.ToString("ddMMyy")
                        Dim info As Byte() = New UTF8Encoding(True).GetBytes(mac)
                        fs.Write(info, 0, info.Length)
                        fs.Close()

                        File.SetAttributes(path, FileAttributes.Hidden)
                        myMacAdd = mac
                        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", strReg, 112)
                        Return 1
                    Else
                        Return 0
                    End If
                End If
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function
    ' for slave
    Private Function checktrialSlave() As Boolean
        isMaster = False
        'Using a As BoundClass = New BoundClass
        '    a.LoadDb()
        '    'a.LoadDb(btDbDv.Tag)
        'End Using



        Dim resultkey As Integer = HandleRegistry()
        Try
            Dim ta As New ALMohassinDBDataSetTableAdapters.valueTableAdapter

            Dim dt2 = ta.GetData("truefont")

            If dt2.Rows(0).Item("val") = "true" Then
                bttrial.Enabled = False
                Return True
                Exit Function
            Else
                If resultkey = 1 Then
                    Return True
                Else
                    Return False
                End If


            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function HandleRegistry() As Integer
        Dim ALMohasibfirstRunDate As Date
        Dim LastRunDate As Date

        ALMohasibfirstRunDate = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", TrialName, Nothing)

        LastRunDate = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", "lastDate", Nothing)

        '''''''''''''''''''''''''''''''''''''''''''''       '''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''       '''''''''''''''''''''''''''''''''''''''''''''
        LastRunDate = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", "lastDate", Nothing)

        Dim sz = (Now - LastRunDate).Days

        'Reglage de date 
        If LastRunDate = Nothing Then
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", "lastDate", Now.Date)
        ElseIf (Now - LastRunDate).Days <= -1 Then
            MsgBox("Merci de regler la date de votre PC ..", MsgBoxStyle.Information, "Error_Date")
            End
        End If

        If CDate(Now) > CDate(LastRunDate) Then My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", "lastDate", Now.Date)

        '''''''''''''''''''''''''''''''''''''''''''''       '''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''       '''''''''''''''''''''''''''''''''''''''''''''


        If ALMohasibfirstRunDate = Nothing Then
            ALMohasibfirstRunDate = Now
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", TrialName, ALMohasibfirstRunDate)

            Return 1
        ElseIf (Now - ALMohasibfirstRunDate).Days > nbrDay_Trial Then
            Return 0
        Else
            Return 1
        End If

    End Function

    Private Sub DGVS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGVS.Click
        If DGVS.SelectedRows.Count > 0 Then
            Dim id As Integer = DGVS.SelectedRows(0).Cells(0).Value
            Dim qte As Integer = 0

            If My.Computer.Keyboard.CtrlKeyDown Then

                Dim bn As New byname
                bn.qte = qte

                If bn.ShowDialog = DialogResult.OK Then qte = bn.qte

                Dim nmdg As New num
                If nmdg.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

                Dim params As New Dictionary(Of String, Object)
                Dim where As New Dictionary(Of String, Object)

                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                    params.Add("qte", qte)
                    where.Add("DSID", id)

                    c.UpdateRecord("Detailstock", params, where)
                End Using
            End If
        End If
    End Sub
    Private Sub Button71_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button71.Click
        If PrintDlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Try
            txttimp.Text = PrintDlg.PrinterSettings.PrinterName
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "mainprinter", txttimp.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try

    End Sub
    Private Sub Button72_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button72.Click
        Try
            Dim fntdlg As New FontDialog
            If fntdlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            txtfname.Text = fntdlg.Font.Name
            txtfntsize.Text = CInt(fntdlg.Font.Size)

            Dim TA As New ALMohassinDBDataSetTableAdapters.valueTableAdapter
            TA.UpdateKeyVal(txtfname.Text, "Font")
            TA.UpdateKeyVal(txtfntsize.Text, "FontSize")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
    Private Sub Button73_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button73.Click, Button45.Click
        Try
            Try

                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "chbsell", chbsell.Checked)

                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "UseCodebarScanner", chbcb.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbImgPrice", cbImgPrice.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbheader", cbheader.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbMergeArt", cbMergeArt.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "CbArticleRemise", CbArticleRemise.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "CbArticleRemise", CbArticleRemise.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbProfit", cbProfit.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "CbBlocModArt", CbBlocModArt.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "CbBlocCalc", CbBlocCalc.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbUnite", cbUnite.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "CbDisArch", CbDisArch.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "CbDisNew", CbQteStk.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbPrintDepot", cbPrintDepot.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "CbDepotOrigine", CbDepotOrigine.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbDual", cbDual.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbTiroir", cbTiroir.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbCaisse", cbCaisse.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbQte", cbQte.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbTsImg", cbTsImg.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbSuppression", cbSuppression.Checked)

                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbEnsGrp", cbEnsGrp.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtEnsGrp", txtEnsGrp.Text)

                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbQteCat", cbQteCat.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtQteCat", txtQteCat.Text)

                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbCodeDouble", cbCodeDouble.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbAffichageLimite", cbAffichageLimite.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbBaseOnStartedRemise", cbBaseOnStartedRemise.Checked)

                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbOptionJenani", cbOptionJenani.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbListToRight", cbListToRight.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbJnImgDb", cbJnImgDb.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbArticleItemDirection", cbArticleItemDirection.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbJnReduireQte", cbJnReduireQte.Checked)

                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbShowDialogPrint", cbShowDialogPrint.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbRYL", cbRYL.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtDptSkiped", txtDptSkiped.Text)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbUseStar", cbUseStar.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbShowFixedPanel", cbShowFixedPanel.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbPvArticle", cbPvArticle.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbPvCats", cbPvCats.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbPvClient", cbPvClient.Checked)
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "isOrderByIdDesc_items", isOrderByIdDesc_items.Checked)

                '" If Not IsNumeric(txtComName.Text) Then txtComName.Text = 0
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtHours", txtComName.Text)


            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            End Try
            Try
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "CBTVA", CBTVA.Checked)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            End Try
            Try
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "SearchMethod", cbsearch.Text)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            End Try
            Try
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "CbDelaiFct", CbDelaiFct.Checked)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            End Try
            Try
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbBonToFact", cbBonToFact.Checked)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            End Try
            Try
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "chbsell", chbsell.Checked)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            End Try
            Try
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "chMasar", chMasar.Checked)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            End Try
            Try
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbMultiPayemnt", cbMultiPayemnt.Checked)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            End Try
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
    Private Sub bttrial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttrial.Click
        Dim trial As New TrialVersion
        If trial.ShowDialog = Windows.Forms.DialogResult.OK Then
            MsgBox("merci de votre compréhension , Code d'activation ' est correct")
            bttrial.Enabled = False
        End If
    End Sub

    Private Sub Button74_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button74.Click
        Try
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbPaper", cbPaper.Text)
            RPl.TypePrinter = cbPaper.Text
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
    Private Sub Button55_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button55.Click
        Try
            Dim strpath As String = "D:\Al mohassib -"
            Dim MyCon As OleDb.OleDbConnection = Nothing
            MyCon = New OleDb.OleDbConnection(My.Settings.ALMohassinDBConnectionString)
            MyCon.Open()

            Dim ada As New OleDb.OleDbDataAdapter("select * from Client", MyCon)
            Dim ds As New DataSet()
            ada.Fill(ds, "Client")

            ds.WriteXml(strpath & Date.Now.Day.ToString & "-" & Date.Now.Month.ToString & "-" & Date.Now.Year.ToString & "-Les Clients.xml")
            End
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cbsearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbsearch.SelectedIndexChanged
        Try
            Dim TA As New ALMohassinDBDataSetTableAdapters.valueTableAdapter
            TA.UpdateKeyVal(cbsearch.Text, "searchway")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
    Private Sub chbprint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbprint.CheckedChanged
        gbprint.Enabled = chbprint.Checked
        Try
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "chbprint", chbprint.Checked)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub chbreceipt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbreceipt.CheckedChanged
        'gbreceipt.Enabled = chbreceipt.Checked
        Try
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "chbreceipt", chbreceipt.Checked)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button77_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button77.Click
        If PrintDlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Try
            txtprt2.Text = PrintDlg.PrinterSettings.PrinterName
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "prt2", txtprt2.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
    Private Sub Button80_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button80.Click
        If PrintDlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Try
            txtreceipt.Text = PrintDlg.PrinterSettings.PrinterName
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "receipt", txtreceipt.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Dim iii As Integer = 0
    Dim aa As Integer = 0
    Dim dpt(4) As Integer
    Private Sub Button63_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button63.Click
        Dim adm As New Addadmin
        If adm.ShowDialog = Windows.Forms.DialogResult.OK Then
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Using a As SubClass = New SubClass()
            a.NewFacture(CInt(btswitsh.Tag))
        End Using
    End Sub
    Private Sub RectangleShape1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RectangleShape1.Click
        txtSearch.Focus()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btswitsh.Click
        If btswitsh.Tag = 1 Then
            btswitsh.Text = " الدخــول "
            btswitsh.BackColor = Color.Thistle
            plrightA.BackColor = Color.Thistle
            'BtLoadFct.Visible = False
            btswitsh.Tag = 0
            RPl.isSell = False
            plright.Controls.Clear()
            RPl.ClearItems()
        Else
            btswitsh.Text = " الخروج "
            btswitsh.BackColor = Color.Teal
            plrightA.BackColor = Color.Teal
            btswitsh.Tag = 1
            RPl.isSell = True
            'BtLoadFct.Visible = True
            plright.Controls.Clear()
            RPl.ClearItems()
        End If
        Using a As SubClass = New SubClass
            a.fillFactures(CInt(btswitsh.Tag))
            a.FillGroupes(True)
            'a.FillGroupes()
        End Using
    End Sub

    Private Sub RPl_printCaisse() Handles RPl.printCaisse
       

        Dim nbr As Integer = txtNbrCopie.Text
        Dim nm As String = txttimp.Text
 
        Dim dl As New PrintDialog
        If dl.ShowDialog = Windows.Forms.DialogResult.OK Then
            nm = dl.PrinterSettings.PrinterName
            nbr = dl.PrinterSettings.Copies
        Else
            Exit Sub
        End If
         

        Try


                MP_Localname = "Caisse.dat"
           
                Dim g As New gGlobClass
            Try
               
                g = ReadFromXmlFile(Of gGlobClass)(ImgPah & "\Prt_Dsn\" & MP_Localname)
                If g.TabProp.Type.ToUpper.StartsWith("TAB") Then


                    Dim ps As New PaperSize(g.P_name, g.W_Page, g.h_Page)
                    ps.PaperName = g.p_Kind
                    PrintDocDesign.DefaultPageSettings.PaperSize = ps
                    PrintDocDesign.DefaultPageSettings.Landscape = g.is_Landscape
                End If
                PrintDocDesign.PrinterSettings.PrinterName = nm
               
            Catch ex As Exception
            End Try

            PrintDocDesign.Print()


        Catch ex As Exception

        End Try

             
    End Sub

    Private Sub RPl_ReturnItem(ByVal sender As Object, ByVal e As System.EventArgs) Handles RPl.ReturnItem
        Using a As SubClass = New SubClass(btswitsh.Tag)
            Dim i As Items = sender
            a.ReturnItem(i, RPl.isSell)
        End Using
        If RPl.EditMode = False Then
            'Select Search txtbox
            If chbcb.Checked Then
                txtSearchCode.Text = ""
                txtSearchCode.Focus()
            Else
                txtSearch.Text = ""
                txtSearch.Focus()
            End If
        End If
    End Sub

    Private Sub RPl_SetDetailArticle(ByVal txt As String, ByRef i As Items) Handles RPl.SetDetailArticle
        Using a As SubClass = New SubClass
            a.UpdateItemDetails(txt, i, RPl.isSell)
        End Using

        If RPl.EditMode = False Then
            'Select Search txtbox
            If chbcb.Checked Then
                txtSearchCode.Text = ""
                txtSearchCode.Focus()
            Else
                txtSearch.Text = ""
                txtSearch.Focus()
            End If
        End If

    End Sub
    Private Sub RPl_UpdateQte(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RPl.UpdateQte
        Dim clc As New Calc
        clc.title = "الكمية السابــقة"
        clc.desc = RPl.SelectedItem.Qte & " " & RPl.SelectedItem.Unite
        'If Field <> "qte" Then
        '    clc.desc = i.Price & " Dhs"
        'End If

        If clc.ShowDialog = DialogResult.OK Then
            Dim q = clc.CPanel1.Value
            If RPl.SelectedItem.isRetour Then q = q * -1

            Using a As SubClass = New SubClass
                a.UpdateItem(RPl.SelectedItem, q, RPl.isSell, "qte")
            End Using
        End If

        If RPl.EditMode = False Then
            'Select Search txtbox
            If chbcb.Checked Then
                txtSearchCode.Text = ""
                txtSearchCode.Focus()
            Else
                txtSearch.Text = ""
                txtSearch.Focus()
            End If
        End If
    End Sub
    Private Sub RPl_UpdatePrice(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RPl.UpdatePrice
        Dim clc As New Calc
        clc.title = "الثمن السابــق"
        clc.desc = RPl.SelectedItem.Price & " Dhs"

        If clc.ShowDialog = DialogResult.OK Then
            If clc.CPanel1.Value < RPl.SelectedItem.Bprice Then
                MsgBox(" ثمن البيع يجب ان يكون أكبر من ثمن الشراء", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                Exit Sub
            End If

            Using a As SubClass = New SubClass
                a.UpdateItem(RPl.SelectedItem, clc.CPanel1.Value, RPl.isSell, "price")
            End Using
        End If

        If RPl.EditMode = False Then
            'Select Search txtbox
            If chbcb.Checked Then
                txtSearchCode.Text = ""
                txtSearchCode.Focus()
            Else
                txtSearch.Text = ""
                txtSearch.Focus()
            End If
        End If
    End Sub
    Private Sub RPl_UpdateItem(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RPl.UpdateItem
        Using a As SubClass = New SubClass
            Dim itm As Items = sender
            a.UpdateItem(itm, RPl.isSell)
        End Using
        If RPl.EditMode = False Then
            'Select Search txtbox
            If chbcb.Checked Then
                txtSearchCode.Text = ""
                txtSearchCode.Focus()
            Else
                txtSearch.Text = ""
                txtSearch.Focus()
            End If
        End If
    End Sub
    Private Sub RPl_DeleteItem(ByRef i As Al_Mohasib.Items, ByVal id As System.Int32) Handles RPl.DeleteItem
        Using a As SubClass = New SubClass(btswitsh.Tag)
            a.DeleteItem(i, id)
        End Using
        If RPl.EditMode = False Then
            'Select Search txtbox
            If chbcb.Checked Then
                txtSearchCode.Text = ""
                txtSearchCode.Focus()
            Else
                txtSearch.Text = ""
                txtSearch.Focus()
            End If
        End If
    End Sub
    Private Sub RPl_UpdatePayment() Handles RPl.UpdatePayment
        If RPl.FctId = 0 Then Exit Sub
        Using a As SubClass = New SubClass()
            a.UpdatePayment(RPl.FctId, RPl.ClientName, RPl.ClId, RPl.isSell, RPl.EditMode, RPl.Total_TTC, RPl.Avance)
        End Using
        If RPl.EditMode = False Then
            'Select Search txtbox
            If chbcb.Checked Then
                txtSearchCode.Text = ""
                txtSearchCode.Focus()
            Else
                txtSearch.Text = ""
                txtSearch.Focus()
            End If
        End If
    End Sub

    '------------
    Private Function PayRecept() As Boolean

        Dim pr As New PayRecept
        pr.total = RPl.Total_TTC
        pr.txtTotal.Text = String.Format("{0:n}", CDec(RPl.Total_TTC))
        pr.avc = RPl.Avance

        If pr.ShowDialog = Windows.Forms.DialogResult.OK Then
            payedCache = pr.pay + pr.avc
            Return True
        Else
            Return False
        End If

    End Function

    '___________
    Private Sub RPl_SaveFacture(ByVal id As System.Int32, ByVal total As System.Double,
                                ByVal avance As System.Double, ByVal tva As System.Double,
                                ByVal table As System.Data.DataTable) Handles RPl.SaveFacture
        If RPl.FctId = 0 Then Exit Sub

        If cbCaisse.Checked And RPl.ClId = 0 And RPl.EditMode = False And RPl.Avance < RPl.Total_TTC Then
            If PayRecept() = False Then
                If chbcb.Checked Then
                    txtSearchCode.Text = ""
                    txtSearchCode.Focus()
                Else
                    txtSearch.Text = ""
                    txtSearch.Focus()
                End If
                Exit Sub
            End If
        End If

        Dim isS As Boolean = RPl.isSell
        Using a As SubClass = New SubClass(isS)
            a.SaveFacture(id, RPl.Total_TTC, RPl.Avance, tva, table, RPl.Remise, RPl.bl, RPl.isSell)
            If RPl.EditMode = False Then
                a.fillFactures(isS)
            Else
                lbLastBon.Text = ""
                DGVARFA.SelectedRows(0).Cells(3).Value = RPl.Total_TTC
                DGVARFA.SelectedRows(0).Cells(4).Value = RPl.Avance
                DGVARFA.SelectedRows(0).Cells(5).Value = RPl.Tva
            End If
            'a.FillGroupes(True)
            'a.FillGroupes()
        End Using
    End Sub
    Public payedCache As Double
    Private Sub RPl_SaveAndPrint(ByVal id As System.Int32, ByVal total As System.Double, ByVal avance As System.Double,
                                 ByVal tva As System.Double, ByVal table As System.Data.DataTable,
                                 ByVal isSell As System.Boolean, ByVal isBl As System.Boolean, ByVal isSecond As System.Boolean) Handles RPl.SaveAndPrint
        If RPl.FctId = 0 Then Exit Sub
        payedCache = RPl.Avance
        If cbCaisse.Checked And RPl.ClId = 0 And RPl.EditMode = False Then
            If PayRecept() = False Then
                If chbcb.Checked Then
                    txtSearchCode.Text = ""
                    txtSearchCode.Focus()
                Else
                    txtSearch.Text = ""
                    txtSearch.Focus()
                End If
                Exit Sub
            End If
        End If


        Dim nbr As Integer = txtNbrCopie.Text
        Dim nm As String = txttimp.Text
        If isBl = False Then nm = txtreceipt.Text


        Try
            If cbShowDialogPrint.Checked Then
                Dim dl As New PrintDialog
                If dl.ShowDialog = Windows.Forms.DialogResult.OK Then
                    nm = dl.PrinterSettings.PrinterName
                    nbr = dl.PrinterSettings.Copies
                Else
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try


        Try

            If cbNormalImp.Checked Then

                PrintDoc.PrinterSettings.PrinterName = nm
                PrintDocDepot.PrinterSettings.PrinterName = nm

                chbreceipt.Checked = False
                If isBl = False Then
                    chbreceipt.Checked = True

                    If cbPaper.Text = "Normal&A4" Then
                        Dim ps As New PaperSize("A4", 850, 1100)
                        ps.PaperName = PaperKind.A4
                        PrintDoc.DefaultPageSettings.PaperSize = ps

                    Else
                        PrintDoc.PrinterSettings.PrinterName = nm
                        PrintDocDepot.PrinterSettings.PrinterName = nm
                    End If
                End If

                For i = 0 To nbr - 1
                    PrintDoc.Print()
                Next

            Else

                MP_Localname = "Ticket.dat"
                If RPl.ClId = 0 Then MP_Localname = "Ticket-0.dat"
                If RPl.isSell = False Then MP_Localname = "Achat-Ticket.dat"
                Dim g As New gGlobClass
                Try
                    If isSecond Then
                        MP_Localname = "Ticket2.dat"
                        If RPl.isSell = False Then MP_Localname = "Achat-Ticket2.dat"
                    End If

                    g = ReadFromXmlFile(Of gGlobClass)(ImgPah & "\Prt_Dsn\" & MP_Localname)
                Catch ex As Exception
                End Try

                Try
                    If isBl Then
                        MP_Localname = "Default.dat"
                        If RPl.ClId = 0 Then MP_Localname = "Default-0.dat"
                        If RPl.isSell = False Then MP_Localname = "Achat-Default.dat"

                        If isSecond Then
                            MP_Localname = "Default2.dat"
                            If RPl.isSell = False Then MP_Localname = "Achat-Default2.dat"
                        End If


                        g = ReadFromXmlFile(Of gGlobClass)(ImgPah & "\Prt_Dsn\" & MP_Localname)
                        Dim ps As New PaperSize(g.P_name, g.W_Page, g.h_Page)
                        ps.PaperName = g.p_Kind
                        PrintDocDesign.DefaultPageSettings.PaperSize = ps
                        PrintDocDesign.DefaultPageSettings.Landscape = g.is_Landscape

                        PrintDocDesign.PrinterSettings.PrinterName = nm
                    Else
                        PrintDocDesign.PrinterSettings.PrinterName = nm
                    End If
                Catch ex As Exception
                End Try

                For i = 0 To nbr - 1
                    PrintDocDesign.Print()
                Next
            End If


        Catch ex As Exception

            If PrintDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintDoc.PrinterSettings.PrinterName = PrintDlg.PrinterSettings.PrinterName
                PrintDocDepot.PrinterSettings.PrinterName = PrintDoc.PrinterSettings.PrinterName
                PrintDoc.Print()
            End If
        End Try

        If RPl.EditMode = False Then
            Using a As SubClass = New SubClass(btswitsh.Tag)

                'print depot
                If cbPrintDepot.Checked Then

                    Try
                        If cbShowDialogPrint.Checked Then
                            Dim dl As New PrintDialog
                            If dl.ShowDialog = Windows.Forms.DialogResult.OK Then
                                nm = dl.PrinterSettings.PrinterName
                                nbr = dl.PrinterSettings.Copies
                            Else
                                Exit Sub
                            End If
                        End If
                    Catch ex As Exception
                        Exit Sub
                    End Try





                    Dim dt As DataTable = RPl.DataSource

                    MP_Localname = "Depot-Default.dat"
                    Dim g As New gGlobClass
                    g = ReadFromXmlFile(Of gGlobClass)(ImgPah & "\Prt_Dsn\" & MP_Localname)

                    If g.TabProp.Type.ToUpper.StartsWith("TAB") Then
                        Dim ps As New PaperSize(g.P_name, g.W_Page, g.h_Page)
                        ps.PaperName = g.p_Kind
                        PrintDocDepot.DefaultPageSettings.PaperSize = ps
                        PrintDocDepot.DefaultPageSettings.Landscape = g.is_Landscape
                    End If

                    PrintDocDepot.PrinterSettings.PrinterName = nm


                    Dim lst = GetListDepots()
                    For Each kvp As KeyValuePair(Of Integer, String) In lst
                        If cbNormalImp.Checked Then
                            _kvp = kvp
                            PrintDocDepot.Print()

                        Else

                            _kvp = kvp

                            Try '''''''''''''''''''''''''''''''''''''''''''''
                                Dim result = From myRow As DataRow In dt.Rows
                                                                                  Where myRow("depot") = _kvp.Key Select myRow
                                If result.Count Then dt_filtreDataSource = result.CopyToDataTable


                            Catch ex As Exception
                            End Try

                            If txtDptSkiped.Text.Contains(_kvp.Key) Then Continue For

                            For i = 0 To nbr - 1
                                PrintDocDepot.Print()
                            Next
                        End If

                    Next
                End If

                a.SaveFacture(id, RPl.Total_TTC, RPl.Avance, tva, table, RPl.Remise, RPl.bl, RPl.isSell)
                a.fillFactures(btswitsh.Tag)

                'a.FillGroupes(True)
                'a.FillGroupes()
            End Using
        End If
    End Sub
    Public _kvp As KeyValuePair(Of Integer, String)

    Private Sub RPl_DeleteFacture(ByVal id As System.Int32, ByVal isSell As System.Boolean, ByVal EM As System.Boolean,
                                  ByVal table As DataTable) Handles RPl.DeleteFacture
        If RPl.FctId = 0 Then Exit Sub
        Using a As SubClass = New SubClass(isSell)
            a.DeleteFacture(id, isSell, EM, table)
        End Using

        If RPl.EditMode = False Then
            'Select Search txtbox
            If chbcb.Checked Then
                txtSearchCode.Text = ""
                txtSearchCode.Focus()
            Else
                txtSearch.Text = ""
                txtSearch.Focus()
            End If
        End If
    End Sub
    Private Sub RPl_EditFacture(ByVal id As System.Int32, ByVal Clid As System.Int32, ByVal ClientName As System.String,
                                ByVal total As System.Double, ByVal avance As System.Double,
                                ByVal table As System.Data.DataTable) Handles RPl.EditFacture
        If RPl.FctId = 0 Then Exit Sub
        Using a As SubClass = New SubClass(btswitsh.Tag)
            Try
                a.EditFacture(id, table)
                RPl.ClearItems()
                DGVARFA.Rows.Remove(DGVARFA.SelectedRows(0))
            Catch ex As Exception

            End Try
        End Using
    End Sub
    Private Sub RPl_EditingItemValueChanged(ByVal oldValue As System.Double, ByVal newValue As System.Double,
                                            ByVal Field As System.String, ByVal itm As Items) Handles RPl.EditingItemValueChanged
        If RPl.FctId = 0 Then Exit Sub

        If RPl.EditMode = False Then
            'Select Search txtbox
            If chbcb.Checked Then
                txtSearchCode.Text = ""
                txtSearchCode.Focus()
            Else
                txtSearch.Text = ""
                txtSearch.Focus()
            End If
            Exit Sub
        End If

        Using a As SubClass = New SubClass(btSwitch2.Tag)
            a.SaveEditingFacture(oldValue, newValue, Field, itm, RPl)
        End Using


    End Sub
    Private Sub RPl_UpdateBl() Handles RPl.UpdateBl
        Using a As SubClass = New SubClass()
            a.UpdateBl(RPl.isSell)
        End Using

        If RPl.EditMode = False Then
            'Select Search txtbox
            If chbcb.Checked Then
                txtSearchCode.Text = ""
                txtSearchCode.Focus()
            Else
                txtSearch.Text = ""
                txtSearch.Focus()
            End If
        End If
    End Sub
    Private Sub RPl_UpdateClient() Handles RPl.UpdateClient
        Using a As SubClass = New SubClass()
            a.UpdateClient(RPl.FctId, RPl.isSell, RPl.EditMode)
        End Using

        If RPl.EditMode = False Then
            'Select Search txtbox
            If chbcb.Checked Then
                txtSearchCode.Text = ""
                txtSearchCode.Focus()
            Else
                txtSearch.Text = ""
                txtSearch.Focus()
            End If
        End If

    End Sub
    Dim M As Integer = 0
    Dim numPage As Integer = 1
    Dim myTva As New Dictionary(Of String, Double)
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage
        Try
            Using a As DrawClass = New DrawClass
                Dim dte As String = Format(Date.Now, "dd-MM-yyyy [hh:mm]")
                If RPl.EditMode = True Then dte = DGVARFA.SelectedRows(0).Cells(6).Value

                a.DrawBon(e, RPl.DataSource, RPl.FctId, RPl.ClId,
                          RPl.ClientName, RPl.ClientAdresse,
                            RPl.Total_Ht, RPl.Total_TTC, RPl.Avance, RPl.Tva, RPl.isSell,
                            dte, RPl.Remise, txtScale.Text, False, False, M, numPage)

            End Using
            myTva.Clear()
        Catch ex As Exception
            M = 0
            numPage = 1
            myTva.Clear()
        End Try
    End Sub
    Private Sub PrintDoc2_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc2.PrintPage
        Try
            Using a As DrawClass = New DrawClass
                a.RepportFacture(e, DGVARFA, "", myTva, CBool(btSwitch2.Tag), M)
            End Using
            myTva.Clear()
        Catch ex As Exception
            M = 0
            myTva.Clear()
        End Try
    End Sub
    Private Sub PrintDoc3_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc3.PrintPage
        Try
            If DGVFCT.Rows.Count = 0 Then Exit Sub
            Using a As DrawClass = New DrawClass
                Dim dte As Date = CDate(DGVFCT.SelectedRows(0).Cells(2).Value)
                Dim mode As String = DGVFCT.SelectedRows(0).Cells(8).Value
                Dim iscache As Boolean = CBool(mode.ToUpper = "CACHE")
                'ttc = String.Format("{0:n}", CDec(totalttc + (totalttc * 0.0025)))


                a.DrawFacture2(e, RPl.DataSource, RPl.FctId, RPl.ClientName, RPl.ClientAdresse, RPl.Total_Ht,
                                RPl.Total_TTC, RPl.Tva, True, 0, dte, RPl.Remise, lbfr.Text, iscache, myTva, M)
            End Using

        Catch ex As Exception
            M = 0
        End Try
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            PlRcpt.Width = _RplWidth
            RPl.EditMode = False
            RPl.ShowClc = True
            RPl.isSell = CBool(btswitsh.Tag)
            Using a As SubClass = New SubClass
                a.fillFactures(CInt(btswitsh.Tag))
            End Using

            If cbPvClient.Checked Then
                RPl.BtDel.Visible = False
                RPl.BtSave.Left = RPl.BtDel.Left
            Else
                RPl.BtDel.Visible = True
                RPl.BtSave.Left = RPl.BtDel.Left - RPl.BtSave.Width - 5
            End If
        ElseIf TabControl1.SelectedIndex = 1 Or TabControl1.SelectedIndex = 2 Then
            PlRcpt.Width = _RplWidth
            RPl.EditMode = True
            RPl.isSell = CBool(btSwitch2.Tag)
            RPl.ClearItems()
            'ElseIf TabControl1.SelectedIndex = 2 Then
            '    PlRcpt.Width = 420
            '    RPl.EditMode = False
            '    RPl.ShowClc = False
            '    RPl.ClearItems()

            If cbSuppression.Checked Then
                RPl.BtDel.Visible = True
                RPl.BtSave.Left = RPl.BtDel.Left - RPl.BtSave.Width - 5
            End If
        Else
            PlRcpt.Width = 0
        End If

        RPl.hideClc = CbBlocCalc.Checked

    End Sub
    Private Sub btSwitch2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSwitch2.Click
        Dim tb As String = "Client"
        DGVARFA.Rows.Clear()
        RPl.ClearItems()

        If btSwitch2.Tag = 1 Then
            btSwitch2.Text = " الدخــول "
            btSwitch2.BackColor = Color.Thistle
            btSwitch2.BackColor = Color.Thistle
            btSwitch2.Tag = 0

            Button33.Visible = False
            RPl.isSell = False
            tb = "company"
        Else
            btSwitch2.Text = " الخروج "
            btSwitch2.BackColor = Color.Teal
            btSwitch2.BackColor = Color.Teal
            btSwitch2.Tag = 1

            Button33.Visible = True
            RPl.isSell = True
            tb = "Client"
        End If

        Using a As SubClass = New SubClass(btSwitch2.Tag)
            txtArSearch.text = ""
            a.AutoCompleteArticles(txtArSearch, tb)
        End Using

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim artdlg As New Articles

        If artdlg.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'fill category in main page
        Using a As SubClass = New SubClass(1)
            a.FillGroupes(True)
        End Using

    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim stk As New stk
        If stk.ShowDialog = Windows.Forms.DialogResult.OK Then

            If stk.Button1.Tag = "1" Then
                Dim stok As New Stock
                stok.txttype.Text = "IN"
                stok.txttype.Tag = "1"
                If stok.ShowDialog = Windows.Forms.DialogResult.OK Then
                End If
            ElseIf stk.Button1.Tag = "2" Then
                Dim stok As New Stock
                stok.txttype.Text = "OUT"
                stok.txttype.Tag = "2"
                If stok.ShowDialog = Windows.Forms.DialogResult.OK Then
                End If
            ElseIf stk.Button1.Tag = "3" Then
                'show result
                Dim stok As New GestionStock
                If stok.ShowDialog = Windows.Forms.DialogResult.OK Then
                End If
            ElseIf stk.Button1.Tag = "0" Then
                'show result
                Dim stok As New AddDepot
                If stok.ShowDialog = Windows.Forms.DialogResult.OK Then
                End If
            End If
        End If
    End Sub
    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim cltdlg As New Client
        cltdlg.btcon.Tag = "0"
        If cltdlg.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim cmpdlg As New company
        cmpdlg.btcon.Tag = "0"
        If cmpdlg.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim crd As New PAYEMENT
        crd.isSell = True
        If crd.ShowDialog = Windows.Forms.DialogResult.OK Then
        End If
        DGVARFA.Rows.Clear()
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim crd As New PAYEMENT
        crd.isSell = False
        If crd.ShowDialog = Windows.Forms.DialogResult.OK Then
        End If
        DGVARFA.Rows.Clear()
    End Sub
    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        If DGVARFA.Rows.Count = 0 Then Exit Sub

        If My.Computer.Keyboard.CtrlKeyDown Then
            Try
                m_i_for = 0
                Dim nm As String = ""
                Dim dl As New PrintDialog
                If dl.ShowDialog = Windows.Forms.DialogResult.OK Then
                    nm = dl.PrinterSettings.PrinterName
                Else
                    Exit Sub
                End If

                MP_Localname = "Archive-Default.dat"
                Dim g As New gGlobClass
                g = ReadFromXmlFile(Of gGlobClass)(ImgPah & "\Prt_Dsn\" & MP_Localname)


                Dim ps As New PaperSize(g.P_name, g.W_Page, g.h_Page)
                ps.PaperName = g.p_Kind
                PrintDocDesign_ListArch.DefaultPageSettings.PaperSize = ps
                PrintDocDesign_ListArch.DefaultPageSettings.Landscape = g.is_Landscape

                PrintDocDesign_ListArch.PrinterSettings.PrinterName = nm

                For i As Integer = 0 To DGVARFA.Rows.Count - 1
                    m_i_for = i
                    PrintDocDesign_ListArch.Print()
                Next


                Exit Sub
            Catch ex As Exception
                Exit Sub
            End Try
        End If






        If RPl.FctId > 0 Then
            'print depot

            Dim dt As DataTable = RPl.DataSource


            If cbNormalImp.Checked Then
                PrintDocDepot.PrinterSettings.PrinterName = txtreceipt.Text
            Else
                MP_Localname = "Depot-Default.dat"
                Dim g As New gGlobClass
                g = ReadFromXmlFile(Of gGlobClass)(ImgPah & "\Prt_Dsn\" & MP_Localname)

                If g.TabProp.Type.ToUpper.StartsWith("TAB") Then
                    Dim ps As New PaperSize(g.P_name, g.W_Page, g.h_Page)
                    ps.PaperName = g.p_Kind
                    PrintDocDepot.DefaultPageSettings.PaperSize = ps
                    PrintDocDepot.DefaultPageSettings.Landscape = g.is_Landscape

                    PrintDocDepot.PrinterSettings.PrinterName = txttimp.Text
                Else
                    PrintDocDepot.PrinterSettings.PrinterName = txtreceipt.Text
                End If

            End If

            Dim lst = GetListDepots()
            For Each kvp As KeyValuePair(Of Integer, String) In lst
                If cbNormalImp.Checked Then
                    _kvp = kvp
                    PrintDocDepot.Print()
                Else
                    _kvp = kvp
                    Try '''''''''''''''''''''''''''''''''''''''''''''
                        Dim result = From myRow As DataRow In dt.Rows
                                                                          Where myRow("depot") = _kvp.Key Select myRow
                        If result.Count Then dt_filtreDataSource = result.CopyToDataTable
                    Catch ex As Exception
                    End Try
                    PrintDocDepot.Print()
                End If
            Next

            Exit Sub
        End If


        Dim str As String = "Archive " & txtArSearch.text & " - du " & dte1.Value.ToString("dd-MM-yy") & " Au " & dte2.Value.ToString("dd-MM-yy")

        str = str.Replace("|", " ")
        str = str.Replace("/", " ")
        str = str.Replace(":", " ")


        SaveDataToHtml(DGVARFA, str)

    End Sub

    Private Sub txtarticlearchive_KeyUp(ByVal sender As System.Object,
                                        ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtarticlearchive.KeyUp
        If e.KeyCode = Keys.Enter Then
            RsSearch_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub RectangleShape2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RectangleShape2.Click
        txtarticlearchive.Focus()
    End Sub

    Private Sub Button67_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button67.Click
        Dim bk As New BackUP
        If My.Computer.Keyboard.CtrlKeyDown Then bk.GB1.Visible = True
        If bk.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
    End Sub
    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        RPl.ClearItems()

        Dim isSell As Boolean = CBool(btSwitch2.Tag)

        Dim tName As String = "DetailsFacture"
        If isSell = False Then tName = "DetailsBon"


        Dim params As New Dictionary(Of String, Object)

        Dim avance As Double = 0
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            If DGVARFA.Rows.Count > 2 Then
                If DGVARFA.Rows(0).Cells(1).Value <> DGVARFA.Rows(1).Cells(1).Value Then Exit Sub

                Try
                    RPl.ClId = DGVARFA.Rows(0).Cells(1).Value
                    RPl.ClientAdresse = ""
                    RPl.ClientName = "Cumul " & DGVARFA.Rows(0).Cells(2).Value
                    RPl.FctId = 1
                    RPl.isSell = CBool(btSwitch2.Tag)
                    RPl.EditMode = True

                    For i As Integer = 0 To DGVARFA.Rows.Count - 1

                        avance += DGVARFA.Rows(0).Cells(4).Value

                        params.Clear()
                        params.Add("fctid", CInt(DGVARFA.Rows(i).Cells(0).Value))
                        Dim dt2 = c.SelectDataTable(tName, {"*"}, params)
                        If dt2.Rows.Count > 0 Then
                            RPl.AddItems(dt2, True)
                        End If
                    Next

                    'remise = ((100 * CDbl(Form1.lbfr.Text)) / (CDbl(Form1.lbft.Text) + CDbl(Form1.lbfr.Text) - CDbl(Form1.lbftva.Text)))
                    RPl.Remise = 0
                    RPl.Avance = avance
                Catch ex As Exception
                End Try
            End If
        End Using
    End Sub

    Private Sub RectangleShape5_Click(ByVal sender As System.Object,
                                      ByVal e As System.EventArgs) Handles RectangleShape5.Click
        If DGVFCT.Rows.Count = 0 Then Exit Sub
        Dim ft As New Facture
        ft.AddToList(DGVFCT.SelectedRows(0).Cells(0).Value, DGVFCT.SelectedRows(0).Cells(1).Value,
                      DGVFCT.SelectedRows(0).Cells(4).Value, DGVFCT.SelectedRows(0).Cells(8).Value,
                      DGVFCT.SelectedRows(0).Cells(6).Value)

        ft.EditMode = True
        Using a As SubFacture = New SubFacture
            a.DeleteDroitTimbre(ft.Id)
        End Using

        If ft.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtarticlearchive.Text = ft.Id
            RsSearch_Click(Nothing, Nothing)
            If DGVFCT.Rows.Count > 0 Then
                DGVFCT_CellContentClick(Nothing, Nothing)
            End If
        End If
    End Sub
    Private Sub RectangleShape6_Click(ByVal sender As System.Object,
                                      ByVal e As System.EventArgs) Handles RectangleShape6.Click
        Try
            If DGVFCT.Rows.Count = 0 Then Exit Sub
            Using a As SubFacture = New SubFacture
                a.DeleteFacture(CInt(DGVFCT.SelectedRows(0).Cells(0).Value))
                DGVFCT.Rows.Clear()
                DGVlistbon.Rows.Clear()
                RPl.ClearItems()

            End Using
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RectangleShape4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RectangleShape4.Click
        Dim ft As New Facture

        ft.EditMode = False
        If ft.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtarticlearchive.Text = ft.Id
            RsSearch_Click(Nothing, Nothing)
            If DGVFCT.Rows.Count > 0 Then
                DGVFCT_CellContentClick(Nothing, Nothing)
            End If
        End If

    End Sub
    Private Sub RectangleShape3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RectangleShape3.Click
        If DGVFCT.Rows.Count = 0 Then Exit Sub

        If cbNormalImp.Checked Then

            If My.Computer.Keyboard.CtrlKeyDown Then
                Try

                    For I As Integer = 0 To DGVFCT.Rows.Count - 1
                        DGVFCT.Rows(I).Selected = True
                        PrintDoc3.PrinterSettings.PrinterName = txttimp.Text
                        PrintDoc3.Print()
                    Next
                Catch ex As Exception

                    If PrintDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                        PrintDoc3.PrinterSettings.PrinterName = PrintDlg.PrinterSettings.PrinterName
                        PrintDoc3.Print()
                    End If
                End Try
            Else
                Try
                    PrintDoc3.PrinterSettings.PrinterName = txttimp.Text
                    PrintDoc3.Print()

                Catch ex As Exception

                    If PrintDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                        PrintDoc3.PrinterSettings.PrinterName = PrintDlg.PrinterSettings.PrinterName
                        PrintDoc3.Print()
                    End If
                End Try
            End If
        Else

            Try
                MP_Localname = "Facture-Default.dat"

                Dim g As New gGlobClass
                g = ReadFromXmlFile(Of gGlobClass)(ImgPah & "\Prt_Dsn\" & MP_Localname)

                g = ReadFromXmlFile(Of gGlobClass)(ImgPah & "\Prt_Dsn\" & MP_Localname)
                Dim ps As New PaperSize(g.P_name, g.W_Page, g.h_Page)
                ps.PaperName = g.p_Kind
                PrintDocDesignFct.DefaultPageSettings.PaperSize = ps
                PrintDocDesignFct.DefaultPageSettings.Landscape = g.is_Landscape




            Catch ex As Exception

            End Try

            PrintDocDesignFct.PrinterSettings.PrinterName = txttimp.Text
            PrintDocDesignFct.Print()

        End If
    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        AddMashine.ShowDialog()
        'Using a As SubClass = New SubClass
        '    a.FillMachines()
        'End Using
    End Sub
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim artdlg As New Articles

        If artdlg.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'fill category in main page
        Using a As SubClass = New SubClass(1)
            a.FillGroupes(True)
        End Using

    End Sub
    'after any closing save data
    Private Sub Form1_FormClosing(ByVal sender As System.Object,
                                  ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dim strpath As String = btSvPath.Tag & "\" & Date.Now.Year.ToString
            If Not Directory.Exists(strpath) Then
                Directory.CreateDirectory(strpath)
            End If
            strpath &= "\" & Date.Now.Month.ToString
            If Not Directory.Exists(strpath) Then
                Directory.CreateDirectory(strpath)
            End If

            Dim ds As New ALMohassinDBDataSet()
            Dim ada As New ALMohassinDBDataSetTableAdapters.ClientTableAdapter
            ada.Fill(ds.Client)

            Dim ada6 As New ALMohassinDBDataSetTableAdapters.PaymentTableAdapter
            ada6.Fill1(ds.Payment)

            Dim ada1 As New ALMohassinDBDataSetTableAdapters.companyTableAdapter
            ada1.Fill(ds.company)

            Dim ada7 As New ALMohassinDBDataSetTableAdapters.CompanyPaymentTableAdapter
            ada7.Fill1(ds.CompanyPayment)

            Dim ada9 As New ALMohassinDBDataSetTableAdapters.CategoryTableAdapter
            ada9.Fill(ds.Category)

            Dim ada8 As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
            ada8.Fill(ds.Article)

            Dim ada2 As New ALMohassinDBDataSetTableAdapters.FactureTableAdapter
            ada2.Fill(ds.Facture)

            Dim ada3 As New ALMohassinDBDataSetTableAdapters.DetailsFactureTableAdapter
            ada3.Fill1(ds.DetailsFacture)

            Dim ada4 As New ALMohassinDBDataSetTableAdapters.BonTableAdapter
            ada4.Fill(ds.Bon)

            Dim ada5 As New ALMohassinDBDataSetTableAdapters.DetailsBonTableAdapter
            ada5.Fill1(ds.DetailsBon)

            Dim adaa9 As New ALMohassinDBDataSetTableAdapters.DetailstockTableAdapter
            adaa9.Fill(ds.Detailstock)

            Dim adaa6 As New ALMohassinDBDataSetTableAdapters.DepotTableAdapter
            adaa6.Fill(ds.Depot)

            Dim adaa7 As New ALMohassinDBDataSetTableAdapters.MachineTableAdapter
            adaa7.Fill(ds.Machine)

            Dim adaa8 As New ALMohassinDBDataSetTableAdapters.Facture_ListeTableAdapter
            adaa8.Fill(ds.Facture_Liste)

            Dim adaB9 As New ALMohassinDBDataSetTableAdapters.ChargeTableAdapter
            adaB9.Fill(ds.Charge)

            ds.WriteXml(strpath & "\" & Date.Now.Day.ToString & ".xml")

        Catch ex As Exception

        End Try

        Using a As BoundClass = New BoundClass
            Dim str As String = BtImgPah.Tag & "\_Db\ALMohassinDB.mdb"
            a.LoadDbToDrive(str)
            'a.LoadDb(btDbDv.Tag)
        End Using


    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSvPath.Click
        Try
            Dim OPF As New OpenFileDialog
            If OPF.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim fi As New IO.FileInfo(OPF.FileName)
                Dim directoryName As String = fi.DirectoryName
                btSvPath.Tag = directoryName
            End If

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "SouvPath", btSvPath.Tag)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
    ' logo for receipt
    Private Sub Button16_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Try
            Dim OPF As New OpenFileDialog
            If OPF.ShowDialog = Windows.Forms.DialogResult.OK Then
                TextBox4.Text = OPF.FileName
            End If

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "LogoPath", TextBox4.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Try
            TextBox4.Text = ""
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "LogoPath", TextBox4.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As System.Object,
                                   ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress


        If e.KeyChar = Chr(13) And FlowLayoutPanel1.Controls.Count = 1 Then
            'If cbQte.Checked Then
            '    Dim bn As New byname
            '    If bn.ShowDialog = DialogResult.OK Then
            '        RPl.CP.Value = bn.qte
            '    End If
            'End If
            Using a As SubClass = New SubClass()
                a.SearchForcodebar()
            End Using


            If chbcb.Checked Then
                txtSearchCode.Text = ""
                txtSearchCode.Focus()
            Else
                txtSearch.Text = ""
                txtSearch.Focus()
            End If
        End If

    End Sub
    Private Sub BtImgPah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtImgPah.Click
        Try
            Dim OPF As New OpenFileDialog
            If OPF.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim fi As New IO.FileInfo(OPF.FileName)
                Dim directoryName As String = fi.DirectoryName
                BtImgPah.Tag = directoryName
            End If

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "ImgPath", BtImgPah.Tag)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Using C As SubClass = New SubClass
            C.StockValue()
        End Using
    End Sub
    Private Sub Button12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click

        If DGVS.Rows.Count = 0 Then Exit Sub


        Try
            Dim a = 0
            For i As Integer = 0 To DGVS.Rows.Count - 1

                If DGVS.Rows(i - a).Cells(3).Value <= 0 Then
                    DGVS.Rows.RemoveAt(i - a)
                    a += 1
                End If
            Next
        Catch ex As Exception
        End Try


        Dim str As String = "Stock "

        str &= Now.Date.ToString("dd-MM-yyyy")

        SaveDataToHtml(DGVS, str)


    End Sub
    Private Sub PrintDocSTOCK_PrintPage(ByVal sender As System.Object,
                                        ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocSTOCK.PrintPage
        Try
            Using a As DrawClass = New DrawClass
                a.RepportStock(e, DGVS, M)
            End Using
        Catch ex As Exception
            M = 0
        End Try
    End Sub
    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        Using a As ChargesClass = New ChargesClass
            a.AddCharges(dgvCharge)
        End Using
    End Sub
    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        If dgvCharge.Rows.Count = 0 Then Exit Sub
        Using a As ChargesClass = New ChargesClass
            a.EditCharges(dgvCharge.SelectedRows(0).Cells(0).Value, dgvCharge.SelectedRows(0).Cells(2).Value,
                           dgvCharge.SelectedRows(0).Cells(3).Value, dgvCharge.SelectedRows(0).Cells(4).Value,
                            dgvCharge.SelectedRows(0).Cells(5).Value, dgvCharge)
        End Using
    End Sub
    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        If dgvCharge.Rows.Count = 0 Then Exit Sub
        Using a As ChargesClass = New ChargesClass
            a.DeleteCharges(dgvCharge.SelectedRows(0).Cells(0).Value,
                            dgvCharge.SelectedRows(0).Cells(2).Value, dgvCharge)
        End Using
    End Sub

    Private Sub PrintDoc4_PrintPage(ByVal sender As System.Object,
                                    ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc4.PrintPage
        Try
            If dgvCharge.Rows.Count = 0 Then Exit Sub
            Using a As DrawClass = New DrawClass

                Dim firstday As Date = dtChargeFrom.Value.AddDays(-1) 'DateSerial(y, M, 0)
                Dim lastday As Date = dtChargeTo.Value.AddDays(1)

                a.DrawCharges(e, dgvCharge, lbChargesMonth.Text, CDbl(txtchtotal.Text),
                              firstday.ToString("dd, MMM yy") & " - " & lastday.ToString("dd, MMM yy"), M)
            End Using

        Catch ex As Exception
            M = 0
        End Try
    End Sub
    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        If dgvCharge.Rows.Count = 0 Then Exit Sub

        Try
            PrintDoc4.PrinterSettings.PrinterName = txttimp.Text
            PrintDoc4.Print()

        Catch ex As Exception

            If PrintDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintDoc4.PrinterSettings.PrinterName = PrintDlg.PrinterSettings.PrinterName
                PrintDoc4.Print()
            End If
        End Try
    End Sub
    Private Sub BtBoundDbPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBoundDbPath.Click
        Try
            Dim OPF As New OpenFileDialog
            If OPF.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim fi As New IO.FileInfo(OPF.FileName)
                'Dim directoryName As String = fi.DirectoryName
                BtBoundDbPath.Tag = fi.FullName
            End If

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "BtBoundDbPath", BtBoundDbPath.Tag)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click, Button48.Click
        Dim artdlg As New ArticleDetails
        If artdlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        End If
    End Sub
    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click, Button50.Click
        Dim artdlg As New ClientDetails
        If artdlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        End If
    End Sub
    Private Sub RectangleShape7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RectangleShape7.Click
        'If DGVlistbon.SelectedRows.Count = 0 Then Exit Sub
        'Using a As SubClass = New SubClass()
        '    a.UpdatePayment(DGVlistbon.SelectedRows(0).Cells(0).Value,
        '                    RPl.ClientName, RPl.ClId, True, True,
        '                     DGVlistbon.SelectedRows(0).Cells(1).Value,
        '                     DGVlistbon.SelectedRows(0).Cells(4).Value)

        '    'a.UpdatePaymentFromFacture(DGVlistbon.SelectedRows(0).Cells(0).Value,
        '    '                  lbfn.Text, DGVFCT.SelectedRows(0).Cells(6).Value,
        '    '                 True, DGVlistbon.SelectedRows(0).Cells(1).Value,
        '    '                   DGVlistbon.SelectedRows(0).Cells(2).Value,
        '    '                  DGVlistbon.SelectedRows(0).Cells(4).Value, lbfid.Text)
        '    DGVFCT_CellContentClick(Nothing, Nothing)
        'End Using

        Try
            Dim PM As New paypmt
            PM.id = DGVFCT.SelectedRows(0).Cells(0).Value
            If PM.ShowDialog = Windows.Forms.DialogResult.OK Then
                DGVFCT.SelectedRows(0).Cells(5).Value = CBool(PM.cbway.Text <> "Non Reglé")


                For I As Integer = 0 To DGVFCT.Rows.Count - 1
                    If CDbl(DGVFCT.Rows(I).Cells(5).Value) = True Then
                        DGVFCT.Rows(I).DefaultCellStyle.BackColor = Color.PaleGreen
                        DGVFCT.Rows(I).Cells(8).Style.BackColor = Color.LimeGreen
                    Else
                        DGVFCT.Rows(I).Cells(8).Style.BackColor = Color.LightSalmon
                    End If
                Next


            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub btHistorique_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btHistorique.Click
        Dim i As Integer = 0
        If DGVARFA.SelectedRows.Count > 0 Then i = DGVARFA.SelectedRows(0).Cells(0).Value
        Dim his As New Massar
        If i <> 0 Then
            his.TxtBox1.text = i
        End If
        If his.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
    End Sub

    Private Sub Button27_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click
        Dim dv As New Devis
        dv.ISSELL = True
        If dv.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
    End Sub

    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Click
        Dim dv As New Devis
        dv.ISSELL = False
        If dv.ShowDialog = Windows.Forms.DialogResult.OK Then
        End If
    End Sub
    Private Sub RPl_CPValueChange() Handles RPl.CPValueChange
        If RPl.EditMode = False Then
            'Select Search txtbox
            If chbcb.Checked Then
                txtSearchCode.Focus()
            Else
                txtSearch.Focus()
            End If
        Else
            txtArSearch.Focus()
        End If

    End Sub

    Private Sub btDbDv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDbDv.Click
        Try
            Dim OPF As New OpenFileDialog
            If OPF.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim fi As New IO.FileInfo(OPF.FileName)
                'Dim directoryName As String = fi.DirectoryName
                btDbDv.Tag = fi.FullName
            End If

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "btDbDv", btDbDv.Tag)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Sub Panel31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel31.Click
        If adminId > 1 Then Exit Sub
        If GB1.Width = 266 Then
            GB1.Width = 33
        Else
            GB1.Width = 266
        End If
    End Sub


    Private Sub Panel35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel35.Click
        If adminId > 1 Then Exit Sub
        If GB4.Width = 370 Then
            GB4.Width = 33
        Else
            GB4.Width = 370
        End If
    End Sub

    Private Sub Panel33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel33.Click
        If GB3.Width = 260 Then
            GB3.Width = 33
        Else
            GB3.Width = 260
        End If
    End Sub

    Private Sub Panel32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel32.Click
        If GB2.Width = 233 Then
            GB2.Width = 33
        Else
            GB2.Width = 233
        End If
    End Sub

    Private Sub DGVFCT_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVFCT.CellContentClick
        Try
            DGVlistbon.Rows.Clear()
            RPl.ClearItems()
            Using a As SubFacture = New SubFacture
                a.GetListifBons(CInt(DGVFCT.SelectedRows(0).Cells(0).Value),
                                   CStr(DGVFCT.SelectedRows(0).Cells(1).Value),
                                   CInt(DGVFCT.SelectedRows(0).Cells(6).Value),
                                   CInt(DGVFCT.SelectedRows(0).Cells(3).Value),
                                   CInt(DGVFCT.SelectedRows(0).Cells(5).Value))
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RPl_UpdateArticleRemise(ByRef i As Al_Mohasib.Items) Handles RPl.UpdateArticleRemise
        Using a As SubClass = New SubClass
            a.UpdateItemREMISE(i, RPl.isSell)
            a.UpdateBl(RPl.isSell)
        End Using
    End Sub
    Private Sub Button29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSearchArch.Click
        Dim isSell As Boolean = CBool(btSwitch2.Tag)


        'Dim dt1 As Date = Date.Parse(dte2.Value).AddDays(1) 'dte2.Value.AddDays(1)
        'Dim dt2 As Date = Date.Parse(dte1.Value).AddHours(addHours) '.AddHours(-12) dte1.Value.AddDays(-1)

        Dim dt1 = New DateTime(dte2.Value.Year, dte2.Value.Month, dte2.Value.Day, 23, 59, 0, 0)
        Dim dt2 = New DateTime(dte1.Value.Year, dte1.Value.Month, dte1.Value.Day, 0, 5, 0, 0)

        Dim tName As String = "Facture"
        If isSell = False Then tName = "Bon"
        Dim params As New Dictionary(Of String, Object)
        Dim dt As DataTable = Nothing

        DGVARFA.Rows.Clear()
        ProgressBar1.Value = 0

        DGVARFA.Columns(4).HeaderText = "Avance"
        Try
            If txtArSearch.text <> "" Then
                If IsNumeric(txtArSearch.text) Then
                    Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                        params.Add("fctid Like ", "%" & txtArSearch.text & "%")
                        params.Add("admin = ", True)
                        dt = a.SelectDataTableSymbols(tName, {"*"}, params)
                    End Using

                ElseIf txtArSearch.text.Contains("|") Then
                    Dim str As String = txtArSearch.text.Trim
                    str = str.Split(CChar("|"))(1)
                    Dim clid As Integer = CInt(str)

                    Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                        params.Add("clid = ", clid)
                        params.Add("[date] < ", dt1)
                        params.Add("[date] > ", dt2)
                        params.Add("admin = ", True)

                        If cbAffichageLimite.Checked And admin = False Then params.Add("writer = ", adminName)

                        If cbSearchRegler.Text = "Reglé" Then params.Add("payed = ", True)
                        If cbSearchRegler.Text = "Non Reglé" Then params.Add("payed = ", False)
                        If CbSearchFacture.Text = "Facturé" Then params.Add("beInFacture > ", 0)
                        If CbSearchFacture.Text = "Non Facturé" Then params.Add("beInFacture = ", 0)


                        dt = a.SelectDataTableSymbols(tName, {"*"}, params)
                    End Using
                End If
            Else
                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    params.Add("[date] < ", dt1)
                    params.Add("[date] > ", dt2)
                    params.Add("admin = ", True)
                    If cbAffichageLimite.Checked And admin = False Then params.Add("writer = ", adminName)

                    If cbSearchRegler.Text = "Reglé" Then params.Add("payed = ", True)
                    If cbSearchRegler.Text = "Non Reglé" Then params.Add("payed = ", False)
                    If CbSearchFacture.Text = "Facturé" Then params.Add("beInFacture > ", 0)
                    If CbSearchFacture.Text = "Non Facturé" Then params.Add("beInFacture = ", 0)

                    dt = a.SelectDataTableSymbols(tName, {"*"}, params)
                End Using
            End If

            If dt.Rows.Count > 0 Then

                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim rest As Decimal = CDec(dt.Rows(i).Item("total").ToString - CDec(dt.Rows(i).Item("avance").ToString))

                    DGVARFA.Rows.Add(dt.Rows(i).Item(0).ToString,
                     dt.Rows(i).Item("clid").ToString, dt.Rows(i).Item("name").ToString,
                   String.Format("{0:n}", CDec(dt.Rows(i).Item("total").ToString)),
                     String.Format("{0:n}", CDec(dt.Rows(i).Item("avance").ToString)),
                     String.Format("{0:n}", rest),
                     CDate(dt.Rows(i).Item("date")).ToString("dd-MM-yyyy [HH:mm]"),
                     dt.Rows(i).Item("adresse").ToString, dt.Rows(i).Item("writer").ToString,
                     dt.Rows(i).Item("payed").ToString, dt.Rows(i).Item("remise").ToString,
                   dt.Rows(i).Item("bl").ToString, dt.Rows(i).Item("beInFacture").ToString,
                   dt.Rows(i).Item("tp").ToString)

                    Try
                        ProgressBar1.Value += 100 / dt.Rows.Count
                    Catch ex As Exception
                        ProgressBar1.Value = 100
                    End Try

                Next
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' color payed

                If CbSearchFacture.Text = "" Or CbSearchFacture.Text = "Rapide" Or CbSearchFacture.Text = "----------" Then Exit Sub

                If admin = False Then Exit Sub


                For i As Integer = 0 To DGVARFA.Rows.Count - 1
                    If DGVARFA.Rows(i).Cells(9).Value = True Then
                        DGVARFA.Rows(i).DefaultCellStyle.BackColor = Color.BurlyWood
                    End If
                    If DGVARFA.Rows(i).Cells(12).Value <> 0 Then
                        DGVARFA.Rows(i).Cells(0).Style.BackColor = Color.Blue
                        DGVARFA.Rows(i).Cells(0).Style.Font = New Font("Arial", 11, FontStyle.Bold)
                        DGVARFA.Rows(i).Cells(0).Style.ForeColor = Color.White
                    End If
                Next
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Else
                MsgBox("لا توجد اي فاتورة لهذا الزبون")
            End If

            If CbSearchFacture.Text = "Sans Info" Then Exit Sub

            Using z As SubClass = New SubClass(isSell)
                If admin Then
                    z.AboutFactures(isSell)
                End If
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btAvoir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAvoir.Click
        Dim stok As New Stock
        stok.txttype.Text = "IN"
        stok.txttype.Tag = "1"
        If stok.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
    End Sub

    Private Sub txtArSearch_SaveText() Handles txtArSearch.SaveText
        Try
            Dim isSell As Boolean = CBool(btSwitch2.Tag)
            Dim chs As New ChoseClient
            chs.isSell = isSell
            If chs.ShowDialog = Windows.Forms.DialogResult.OK Then
                txtArSearch.text = chs.clientName & "|" & chs.cid
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtArSearch_TxtChanged() Handles txtArSearch.TxtChanged
        If txtArSearch.text = "" Then
            txtArSearch.ShowClearIcon = False
            txtArSearch.ShowSaveIcon = True
        Else
            txtArSearch.ShowClearIcon = True
            txtArSearch.ShowSaveIcon = False
        End If
    End Sub

    Private Sub RsSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RsSearch.Click
        Try
            DGVFCT.Rows.Clear()
            DGVlistbon.Rows.Clear()
            RPl.ClearItems()
            Using a As SubFacture = New SubFacture
                a.GetFactures(txtarticlearchive.Text, DtpArt1.Text, DtpArt2.Text)
            End Using

            For I As Integer = 0 To DGVFCT.Rows.Count - 1
                If CDbl(DGVFCT.Rows(I).Cells(5).Value) = True Then
                    DGVFCT.Rows(I).DefaultCellStyle.BackColor = Color.PaleGreen
                    DGVFCT.Rows(I).Cells(8).Style.BackColor = Color.LimeGreen
                Else
                    DGVFCT.Rows(I).Cells(8).Style.BackColor = Color.LightSalmon
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGVARFA_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVARFA.CellClick
        Try
            If DGVARFA.SelectedRows.Count = 0 Then Exit Sub
            If DGVARFA.SelectedRows(0).Cells(0).Value = 0 Then Exit Sub
            Dim isSell As Boolean = CBool(btSwitch2.Tag)

            If My.Computer.Keyboard.CtrlKeyDown Then
                'Dim a As Integer = 0
                'If isSell = False Then Exit Sub
                'If DGVARFA.SelectedRows(0).Cells(12).Value <> 0 And DGVARFA.SelectedRows(0).Cells(12).Value <> -5 Then Exit Sub
                ' '''''''''''
                'Dim pwdwin As New PWDPicker
                'If pwdwin.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                '    Exit Sub
                'End If
                ' '''''''''''
                'Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                '    If DGVARFA.SelectedRows(0).Cells(12).Value = 0 Then a = -5

                '    Dim param As New Dictionary(Of String, Object)
                '    Dim where As New Dictionary(Of String, Object)

                '    param.Add("beInFacture", a)
                '    where.Add("fctid", CInt(DGVARFA.SelectedRows(0).Cells(0).Value))

                '    c.UpdateRecord("Facture", param, where)

                '    DGVARFA.SelectedRows(0).Cells(12).Value = a

                '    ''''''''''
                '    DGVARFA.SelectedRows(0).Cells(0).Style.BackColor = Color.Blue
                '    DGVARFA.SelectedRows(0).Cells(0).Style.Font = New Font("Arial", 11, FontStyle.Bold)
                '    DGVARFA.SelectedRows(0).Cells(0).Style.ForeColor = Color.White
                'End Using
            Else
                '''' Regelar Click '''''''
                RPl.EditMode = True

                Dim a As Integer = DGVARFA.SelectedRows(0).Cells(0).Value
                Dim dt As DataTable
                If isSell Then
                    Dim ta As New ALMohassinDBDataSetTableAdapters.DetailsFactureTableAdapter
                    dt = ta.GetData(a)
                Else
                    Dim ta As New ALMohassinDBDataSetTableAdapters.DetailsBonTableAdapter
                    dt = ta.GetData(a)
                End If

                RPl.ClearItems()

                If DGVARFA.SelectedRows(0).Cells(12).Value > 0 Or CbDisArch.Checked Then
                    a = 0
                    RPl.ShowClc = False
                End If

                RPl.FctId = a
                RPl.ClientName = DGVARFA.SelectedRows(0).Cells(2).Value
                RPl.ClientAdresse = DGVARFA.SelectedRows(0).Cells(7).Value
                RPl.ClId = DGVARFA.SelectedRows(0).Cells(1).Value
                RPl.Avance = DGVARFA.SelectedRows(0).Cells(4).Value
                RPl.Remise = DGVARFA.SelectedRows(0).Cells(10).Value
                RPl.bl = DGVARFA.SelectedRows(0).Cells(11).Value
                RPl.isSell = isSell
                RPl.delivredDay = DGVARFA.SelectedRows(0).Cells(13).Value

                If dt.Rows.Count > 0 Then

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
                    table.Columns.Add("poid", GetType(Double))
                    table.Columns.Add("code", GetType(String))
                    table.Columns.Add("depot", GetType(Integer))
                    table.Columns.Add("cid", GetType(Integer))

                    For i As Integer = 0 To dt.Rows.Count - 1
                        table.Rows.Add(dt.Rows(i).Item(0).ToString, dt.Rows(i).Item("arid").ToString, dt.Rows(i).Item("qte").ToString, dt.Rows(i).Item("name").ToString, dt.Rows(i).Item("unit").ToString, dt.Rows(i).Item("price").ToString, dt.Rows(i).Item("bprice").ToString, dt.Rows(i).Item("tva").ToString, dt.Rows(i).Item("poid").ToString, dt.Rows(i).Item("code").ToString, dt.Rows(i).Item("depot").ToString, dt.Rows(i).Item("cid").ToString)
                    Next
                    RPl.AddItems(table, isSell)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            Using a As ChargesClass = New ChargesClass
                a.GetCharges(dtChargeFrom.Value, dtChargeTo.Value, dgvCharge)
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RPl_UpdateDepot(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RPl.UpdateDepot
        Using a As SubClass = New SubClass
            a.UpdateItemDepot(RPl.SelectedItem)
        End Using

        If chbcb.Checked Then
            txtSearchCode.Text = ""
            txtSearchCode.Focus()
        Else
            txtSearch.Text = ""
            txtSearch.Focus()
        End If

    End Sub



    Private Sub CHPRINTERRECEIPT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        '    My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "CHPRINTERRECEIPT", CHPRINTERRECEIPT.Checked)
        'Catch ex As Exception
        'End Try
    End Sub
    Private Sub PrintDocDepot_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocDepot.PrintPage

        If cbNormalImp.Checked Then
            Try
                Using a As DrawClass = New DrawClass
                    Dim dte As String = Format(Date.Now, "dd-MM-yyyy [hh:mm]")
                    If RPl.EditMode = True Then dte = DGVARFA.SelectedRows(0).Cells(6).Value

                    a.DrawReceiptDepot(e, _kvp.Value, RPl.FctId, _kvp.Key, RPl.DataSource, RPl.ClientName, dte, M)
                End Using
                myTva.Clear()
            Catch ex As Exception
                M = 0
                myTva.Clear()
            End Try

        Else
            Try
                Dim ds As RPanel = RPl
                Dim dte As String = Format(Date.Now, "dd-MM-yyyy [hh:mm]")
                If RPl.EditMode = True Then dte = DGVARFA.SelectedRows(0).Cells(6).Value


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
                data.Columns.Add("livreur", GetType(String))

                data.Rows.Add(RPl.FctId, dte, RPl.ClId, RPl.ClientName,
                              String.Format("{0:0.00}", RPl.Total_Ht), String.Format("{0:0.00}", RPl.Tva),
                              String.Format("{0:0.00}", RPl.Total_TTC), String.Format("{0:0.00}", RPl.Remise),
                              String.Format("{0:0.00}", RPl.Avance), String.Format("{0:0.00}", 0),
                              "Cache", adminName, dt_filtreDataSource.Rows.Count, RPl.bl)


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

                        Dim tac As New ALMohassinDBDataSetTableAdapters.ClientTableAdapter
                        tel = tac.ScalarQueryTel(RPl.ClId)
                    End If
                End If

                ' Add  rows with those columns filled in the DataTable.
                dt_Client.Rows.Add(RPl.ClId, RPl.ClientName, RPl.ClId, client_ville,
                                    adresse, client_ice, tel, credit, EncCreadit)

                Using g As gDrawClass = New gDrawClass(MP_Localname)
                    g.rtl = cbRTL.Checked

                    g.DrawBl(e, data, dt_filtreDataSource, dt_Client, Facture_Title, False, M)
                End Using

            Catch ex As Exception

            End Try
        End If

    End Sub
    Public Function GetListDepots() As Dictionary(Of Integer, String)

        Dim lst As New Dictionary(Of Integer, String)
        Dim params As New Dictionary(Of String, Object)
        Dim name As String = ""
        Dim e As Boolean = False
        Dim a As Items
        For Each a In RPl.Pl.Controls
            If Not lst.ContainsKey(a.Depot) And a.Depot <> 0 Then
                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    params.Add("dpid", a.Depot)
                    name = c.SelectByScalar("Depot", "name", params)
                    params.Clear()
                End Using
                lst.Add(a.Depot, name)
            End If
        Next
        Return lst
    End Function


    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

        Using a As SubClass = New SubClass()
            a.SearchForArticles(txtSearch, FlowLayoutPanel1.Tag)
        End Using

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Using a As SubClass = New SubClass()
            a.FillGroupes(False)
        End Using
    End Sub

   
    Private Sub Button30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button30.Click
        Dim isSell As Boolean = CBool(btSwitch2.Tag)
        'Dim dt1 As Date = Date.Parse(dte2.Text).AddDays(1)
        'Dim dt2 As Date = Date.Parse(dte1.Text).AddHours(addHours)


        Dim dt1 = New DateTime(dte2.Value.Year, dte2.Value.Month, dte2.Value.Day, 23, 59, 0, 0)
        Dim dt2 = New DateTime(dte1.Value.AddDays(-1).Year, dte1.Value.AddDays(-1).Month, dte1.Value.AddDays(-1).Day, 23, 59, 0, 0)

        Dim tName As String = "Payment"
        If isSell = False Then tName = "CompanyPayment"
        Dim params As New Dictionary(Of String, Object)
        Dim dt As DataTable = Nothing
        Dim TT As Decimal = 0

        Dim T_CA As Double = 0
        Dim T_TP As Double = 0
        Dim T_CH As Double = 0
        Dim T_VR As Double = 0


        Dim R_TT As Decimal = 0

        Dim R_CA As Double = 0
        Dim R_TP As Double = 0
        Dim R_CH As Double = 0
        Dim R_VR As Double = 0

        Dim credit As Double = 0


        DGVARFA.Rows.Clear()
        ProgressBar1.Value = 0

        Try

            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                params.Add("[date] < ", dt1)
                params.Add("[date] > ", dt2)

                If cbAffichageLimite.Checked And admin = False Then params.Add("writer = ", adminName)

                dt = a.SelectDataTableSymbols(tName, {"*"}, params)

                params.Add("payed = ", False)


                tName = "Facture"
                If isSell = False Then tName = "Bon"
                Dim dt_cr = a.SelectDataTableSymbols(tName, {"SUM(total)", "SUM(avance)"}, params)

                If dt_cr.Rows.Count > 0 Then
                    Dim t_cr As Double = 0
                    Dim a_cr As Double = 0

                    Try
                        t_cr = dt_cr.Rows(0).Item(0)
                    Catch ex As Exception
                        t_cr = 0
                    End Try

                    Try
                        a_cr = dt_cr.Rows(0).Item(1)
                    Catch ex As Exception
                        a_cr = 0
                    End Try


                    credit = t_cr - a_cr
                End If
            End Using

            If dt.Rows.Count > 0 Then

                For i As Integer = 0 To dt.Rows.Count - 1

                    DGVARFA.Rows.Add(0,
                     dt.Rows(i).Item(2).ToString, dt.Rows(i).Item("name").ToString,
                   String.Format("{0:n}", CDec(dt.Rows(i).Item("montant").ToString)),
                     dt.Rows(i).Item("way").ToString,
                  "", CDate(dt.Rows(i).Item("date")).ToString("dd, MMM yy [hh:mm]"),
                     "", dt.Rows(i).Item("writer").ToString, "", "", "", dt.Rows(i).Item(7).ToString)

                    TT += CDec(dt.Rows(i).Item("montant").ToString)

                    If dt.Rows(i).Item("Num").ToString.StartsWith("@/") Then

                        R_TT += CDec(dt.Rows(i).Item("montant").ToString)
                        If dt.Rows(i).Item("way").ToString.ToUpper.StartsWith("CHEQ") Then
                            R_CH += CDec(dt.Rows(i).Item("montant").ToString)

                        ElseIf dt.Rows(i).Item("way").ToString.ToUpper.StartsWith("TPE") Then
                            R_TP += CDec(dt.Rows(i).Item("montant").ToString)

                        ElseIf dt.Rows(i).Item("way").ToString.ToUpper.StartsWith("VIR") Then
                            R_VR += CDec(dt.Rows(i).Item("montant").ToString)

                        Else
                            R_CA += CDec(dt.Rows(i).Item("montant").ToString)
                        End If


                    End If

                    If dt.Rows(i).Item("way").ToString.ToUpper.StartsWith("CHEQ") Then
                        T_CH += CDec(dt.Rows(i).Item("montant").ToString)

                    ElseIf dt.Rows(i).Item("way").ToString.ToUpper.StartsWith("TPE") Then
                        T_TP += CDec(dt.Rows(i).Item("montant").ToString)

                    ElseIf dt.Rows(i).Item("way").ToString.ToUpper.StartsWith("VIR") Then
                        T_VR += CDec(dt.Rows(i).Item("montant").ToString)

                    Else
                        T_CA += CDec(dt.Rows(i).Item("montant").ToString)
                    End If
                Next
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' color payed

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DGVARFA.Columns(4).HeaderText = "---"

            Else
                MsgBox("aucun résultat")
            End If

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

            'table.Rows.Add(0, -111, 1, "TOTAL", "U", TT, TT, 0, 0, -110, 0, 0)

            table.Rows.Add(0, -112, 1, "VIREMENT", "U", T_VR, T_VR, 0, 0, -110, 0, 0)
            table.Rows.Add(0, -113, 1, "CHEQUE", "U", T_CH, T_CH, 0, 0, -110, 0, 0)
            table.Rows.Add(0, -114, 1, "TPE", "U", T_TP, T_TP, 0, 0, -110, 0, 0)
            table.Rows.Add(0, -115, 1, "CACHE", "U", T_CA, T_CA, 0, 0, -110, 0, 0)

            table.Rows.Add(0, -116, 1, "RECOUVREMENT TOTAL", "U", R_TT, R_TT, 0, 100, -110, 0, 0)

            table.Rows.Add(0, -117, 1, "REC. VIREMENT", "U", R_VR, R_VR, 0, 100, -110, 0, 0)
            table.Rows.Add(0, -118, 1, "REC. CHEQUE", "U", R_CH, R_CH, 0, 100, -110, 0, 0)
            table.Rows.Add(0, -119, 1, "REC. TPE", "U", R_TP, R_TP, 0, 100, -110, 0, 0)
            table.Rows.Add(0, -120, 1, "REC. CACHE", "U", R_CA, R_CA, 0, 100, -110, 0, 0)

            table.Rows.Add(0, -121, 1, "Credit", "U", credit, credit, 0, 100, -110, 0, 0)

            table.Rows.Add(0, -122, 1, "Nombre", "U", DGVARFA.Rows.Count, DGVARFA.Rows.Count, 0, 100, -110, 0, 0)

            RPl.ClearItems()


            RPl.FctId = 0
            RPl.ClientName = "RECETTES du" & dt2.ToString("dd/MM") & " au " & dt1.ToString("dd/MM")
            RPl.ClientAdresse = "RECETTES "
            If isSell = False Then
                RPl.ClientName = "DEPENSES du" & dt2.ToString("dd/MM") & " au " & dt1.ToString("dd/MM")
                RPl.ClientAdresse = "DEPENSES "
            End If

            RPl.ClId = -111
            RPl.Avance = 0


            RPl.AddItems(table, isSell)


            Dim r = ((RPl.Total_TTC - TT) * 100) / RPl.Total_TTC
            RPl.Remise = r



        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button31.Click
        End
    End Sub

    Private Sub Button32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button32.Click
        Dim pwdwin As New PWDPicker

        If pwdwin.ShowDialog = Windows.Forms.DialogResult.OK Then

            If pwdwin.DGV1.SelectedRows(0).Cells(2).Value = "admin" Then
                admin = True
                adminId = pwdwin.DGV1.SelectedRows(0).Cells(0).Value
                adminName = pwdwin.DGV1.SelectedRows(0).Cells(1).Value
                'BtCaisse.Visible = True
                'Button30.Visible = True
            Else
                admin = False
                adminId = pwdwin.DGV1.SelectedRows(0).Cells(0).Value
                adminName = pwdwin.DGV1.SelectedRows(0).Cells(1).Value

                Button13.Visible = False
                Button17.Visible = False
                RectangleShape6.Visible = False
                'BtCaisse.Visible = False
                'Button30.Visible = False
                Try
                    TabControl1.Controls.Remove(TabPageParm)
                    ' TabControl1.Controls.Remove(TabPageArch)
                    '  TabControl1.Controls.Remove(TabPageStk)
                Catch ex As Exception

                End Try
            End If
        Else
            End
        End If
    End Sub

    Private Sub RPl_UpdateValueChanged() Handles RPl.UpdateValueChanged
        If cbDual.Checked Then
            Try
                dualScrean.PlItems.Controls.Clear()
                For Each C As Items In RPl.Pl.Controls

                    Dim ap As New Items
                    ap.Dock = DockStyle.Top
                    ap.Name = C.Name
                    ap.Unite = ""
                    ap.Price = C.Price
                    ap.Qte = C.Qte
                    ap.Bprice = 0
                    ap.id = C.id
                    ap.arid = C.arid
                    ap.Tva = 20
                    ap.cid = 0
                    ap.Depot = 1
                    ap.code = 1
                    ap.Remise = 0

                    ap.BgColor = Color.White
                    ap.SideColor = Color.CadetBlue



                    dualScrean.PlItems.Controls.Add(ap)
                Next
                dualScrean.LbSum.Text = RPl.LbSum.Text & " Dhs"
            Catch ex As Exception
            End Try


            Try
                Dim sp As SerialPort = New SerialPort(TxtComName.text, 9600, Parity.None, 8, StopBits.One)

                sp.Open()
                sp.Write(Convert.ToString(ChrW(12)))
                sp.WriteLine(RPl.LbVidal.Text)
                sp.WriteLine(ChrW(13) & "Total : " & RPl.Total_TTC & " Dh")
                sp.Close()
                sp.Dispose()
                sp = Nothing

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Try
            Dim isSell As Boolean = CBool(btSwitch2.Tag)
            Dim chs As New ChoseClient
            chs.isSell = isSell
            If chs.ShowDialog = Windows.Forms.DialogResult.OK Then
                txtArSearch.text = chs.clientName & "|" & chs.cid
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSearchCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchCode.KeyPress

        If e.KeyChar = Chr(13) Then
            Using a As SubClass = New SubClass()

                If txtSearchCode.Text.StartsWith("99989") Then ' create new bon for client
                    Dim str As String = txtSearchCode.Text.Remove(0, 5)
                    str = str.Remove(str.Length - 1)

                    Dim dt = a.getClient(CInt(str))
                    If Not IsNothing(dt) Then
                        a.NewFacture(dt.Rows(0).Item(0), dt.Rows(0).Item("name"),
                                     dt.Rows(0).Item("Adress"), 0)
                    End If

                    txtSearchCode.Text = ""
                    txtSearchCode.Focus()
                ElseIf txtSearchCode.Text.StartsWith("9999") Then  ' sell a balance broduct
                    Dim str As String = txtSearchCode.Text.Remove(0, 4)
                    str = str.Remove(str.Length - 1)

                    Dim ref As String = ""
                    Dim qt As Double = 0
                    Try
                        ref = str.Remove(3)
                        qt = CDbl(str.Remove(0, 3))

                        a.getBalancebyRef(ref, qt)
                    Catch ex As Exception

                    End Try

                    txtSearchCode.Text = ""
                    txtSearchCode.Focus()
                Else
                    a.SearchForcodebarOnly(txtSearchCode)
                End If
            End Using
        End If

    End Sub

    Private Sub RPl_SetDetailFacture() Handles RPl.SetDetailFacture
        If RPl.EditMode = False Then
            'Select Search txtbox
            If chbcb.Checked Then
                txtSearchCode.Text = ""
                txtSearchCode.Focus()
            Else
                txtSearch.Text = ""
                txtSearch.Focus()
            End If
        End If
    End Sub

    Private Sub RPl_CommandeDate() Handles RPl.CommandeDate
        Try
            Dim cdd As New Commande
            If RPl.delivredDay <> "0" Then
                cdd.dtnow = CDate(RPl.delivredDay)
            Else
                cdd.dtnow = Now.Date
            End If

            If cdd.ShowDialog = Windows.Forms.DialogResult.OK Then
                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

                    Dim params As New Dictionary(Of String, Object)

                    params.Add("tp", cdd.str)

                    Dim where As New Dictionary(Of String, Object)
                    where.Add("fctid", RPl.FctId)

                    If c.UpdateRecord("Facture", params, where) Then
                        RPl.delivredDay = cdd.str
                    End If
                End Using
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button33.Click
        Dim isSell As Boolean = CBool(btSwitch2.Tag)
        Dim tName As String = "Facture"

        Dim params As New Dictionary(Of String, Object)
        Dim dt As DataTable = Nothing

        DGVARFA.Rows.Clear()
        ProgressBar1.Value = 0

        Try
            If txtArSearch.text.Contains("|") And isSell = True Then
                Dim str As String = txtArSearch.text.Trim
                str = str.Split(CChar("|"))(1)
                Dim clid As Integer = CInt(str)

                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    params.Add("clid = ", clid)
                    params.Add("tp <> ", "0")
                    params.Add("admin = ", True)

                    dt = a.SelectDataTableSymbols(tName, {"*"}, params)
                End Using

            Else
                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    params.Add("tp <> ", "0")
                    params.Add("admin = ", True)
                    dt = a.SelectDataTableSymbols(tName, {"*"}, params)
                End Using
            End If

            If dt.Rows.Count > 0 Then

                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim rest As Decimal = CDec(dt.Rows(i).Item("total").ToString - CDec(dt.Rows(i).Item("avance").ToString))

                    DGVARFA.Rows.Add(dt.Rows(i).Item(0).ToString,
                     dt.Rows(i).Item("clid").ToString, dt.Rows(i).Item("name").ToString,
                   String.Format("{0:n}", CDec(dt.Rows(i).Item("total").ToString)),
                     String.Format("{0:n}", CDec(dt.Rows(i).Item("avance").ToString)),
                     String.Format("{0:n}", rest),
                     CDate(dt.Rows(i).Item("date")).ToString("dd, MMM yy [hh:mm]"),
                     dt.Rows(i).Item("adresse").ToString, dt.Rows(i).Item("writer").ToString,
                     dt.Rows(i).Item("payed").ToString, dt.Rows(i).Item("remise").ToString,
                   dt.Rows(i).Item("tp").ToString, dt.Rows(i).Item("beInFacture").ToString,
                   dt.Rows(i).Item("tp").ToString)

                    Try
                        ProgressBar1.Value += 100 / dt.Rows.Count
                    Catch ex As Exception
                        ProgressBar1.Value = 100
                    End Try

                Next
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' color payed
                For i As Integer = 0 To DGVARFA.Rows.Count - 1
                    If DGVARFA.Rows(i).Cells(9).Value = True Then
                        DGVARFA.Rows(i).DefaultCellStyle.BackColor = Color.BurlyWood
                    End If
                    If DGVARFA.Rows(i).Cells(12).Value <> 0 Then
                        DGVARFA.Rows(i).Cells(0).Style.BackColor = Color.Blue
                        DGVARFA.Rows(i).Cells(0).Style.Font = New Font("Arial", 11, FontStyle.Bold)
                        DGVARFA.Rows(i).Cells(0).Style.ForeColor = Color.White
                    End If
                Next
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Else
                MsgBox("لا توجد اي طلب")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button34.Click

        If cbEnsGrp.Checked Then
            Using a As SubClass = New SubClass(1)
                a.FillGroupes()
            End Using
        Else

            Dim strpath As String = BtImgPah.Tag & "\StrdFct"
            If Not Directory.Exists(strpath) Then
                Directory.CreateDirectory(strpath)
                Exit Sub
            End If

            Dim Folder As New IO.DirectoryInfo(strpath)
            FlowLayoutPanel1.Controls.Clear()

            For Each File As IO.FileInfo In Folder.GetFiles("*.*", IO.SearchOption.AllDirectories)
                'CBfact.Items.Add(File.Name)

                Dim bt As New Button

                bt.Visible = True
                bt.FlatStyle = FlatStyle.Flat
                bt.BackColor = Color.LightSeaGreen
                bt.Text = File.Name
                'bt.Name = "art" & i
                bt.Tag = File.Name
                bt.TextAlign = ContentAlignment.BottomCenter
                bt.Width = txtlongerbt.Text
                bt.Height = txtlargebt.Text

                FlowLayoutPanel1.Controls.Add(bt)
                AddHandler bt.Click, AddressOf StrdFctBt_click
            Next
        End If
    End Sub
    Private Sub StrdFctBt_click(ByVal sender As Object, ByVal e As EventArgs)
        Dim bt As Button = sender

        Using c As SubClass = New SubClass
            c.loadStrdFct(bt.Text)
        End Using
    End Sub

    Private Sub Panel4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel4.Click
        If adminId > 1 Then Exit Sub

        If GB5.Width = 370 Then
            GB5.Width = 33
        Else
            GB5.Width = 370
        End If
    End Sub

    Private Sub Button35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button35.Click

        If Not IsNumeric(txtNbrArt.Text) Then
            txtNbrArt.Focus()
            Exit Sub
        End If

        Using z As SubClass = New SubClass()

            Dim params As New Dictionary(Of String, String)
            params.Add("sell", CStr(chbsell.Checked))
            params.Add("title", txttitle.Text)
            params.Add("stitle", txttitlestart.Text)
            params.Add("longerbt", txtlongerbt.Text)
            params.Add("largebt", txtlargebt.Text)
            params.Add("cltcomptoir", txtcltcomptoir.Text)
            params.Add("tel", txttel.Text)
            params.Add("FontSize", txtfntsize.Text)
            params.Add("Signature", TxtSignature.Text)

            z.UpdateValues(params)
        End Using

        Try
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtScale", txtScale.Text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtNbrArt", txtNbrArt.Text)
            indexLastArticle = CInt(txtNbrArt.Text)

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbRTL", cbRTL.Checked)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbMsgOc", cbMsgOc.Checked)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtMsgOc", txtMsgOc.Text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtAdrs", txtAdrs.Text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "SearchMethod", cbsearch.Text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbShowRef", cbShowRef.Checked)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbShowGloblCredit", cbShowGloblCredit.Checked)

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbNormalImp", cbNormalImp.Checked)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMsgOc.CheckedChanged, cbRTL.CheckedChanged, cbShowRef.CheckedChanged
        txtMsgOc.Enabled = cbMsgOc.Checked
    End Sub

    Private Sub txtNbrCopie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNbrCopie.TextChanged
        Try

            If Not IsNumeric(txtNbrCopie.Text) Then
                txtNbrCopie.Text = 1
            Else
                txtNbrCopie.Text = CInt(txtNbrCopie.Text)
            End If

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtNbrCopie", txtNbrCopie.Text)
            RPl.TypePrinter = cbPaper.Text
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Sub cbEnsGrp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbEnsGrp.CheckedChanged
        txtEnsGrp.Enabled = cbEnsGrp.Checked
    End Sub

    Private Sub Button36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button36.Click
        Dim clc As New ChoseDepot
        If clc.ShowDialog = DialogResult.OK Then
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                Dim where As New Dictionary(Of String, Object)

                Dim dpt As Integer = CInt(clc.DataGridView1.SelectedRows(0).Cells(0).Value)
                If clc.Button1.Tag = 2 Then dpt = 0

                RPl.CP.Depot = dpt
                Button36.Text = "Depot N [" & dpt & "]"
                If dpt = 0 Then Button36.Text = "-- Depot --"
            End Using
        End If


        If chbcb.Checked Then
            txtSearchCode.Text = ""
            txtSearchCode.Focus()
        Else
            txtSearch.Text = ""
            txtSearch.Focus()
        End If

    End Sub

    Private Sub CbDepotOrigine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbDepotOrigine.CheckedChanged
        plDepot.Visible = True
        If CbDepotOrigine.Checked Then plDepot.Visible = False
    End Sub

    Private Sub Button37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button37.Click
        Dim isSell As Boolean = CBool(btSwitch2.Tag)
        Dim tName As String = "Facture"
        If isSell = False Then tName = "Bon"
        Dim params As New Dictionary(Of String, Object)
        Dim dt As DataTable = Nothing

        DGVARFA.Rows.Clear()
        ProgressBar1.Value = 0

        DGVARFA.Columns(4).HeaderText = "Avance"
        Try
            If txtArSearch.text.Contains("|") = False Then
                Dim chs As New ChoseClient
                chs.isSell = isSell
                If chs.ShowDialog = Windows.Forms.DialogResult.OK Then
                    txtArSearch.text = chs.clientName & "|" & chs.cid
                End If
            End If

            Dim str As String = txtArSearch.text.Trim
            str = str.Split(CChar("|"))(1)
            Dim clid As Integer = CInt(str)

            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                params.Add("clid", clid)
                params.Add("admin", True)
                params.Add("payed", False)
                dt = a.SelectDataTable(tName, {"*"}, params)
            End Using

            If dt.Rows.Count > 0 Then

                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim rest As Decimal = CDec(dt.Rows(i).Item("total").ToString - CDec(dt.Rows(i).Item("avance").ToString))

                    DGVARFA.Rows.Add(dt.Rows(i).Item(0).ToString,
                     dt.Rows(i).Item("clid").ToString, dt.Rows(i).Item("name").ToString,
                   String.Format("{0:n}", CDec(dt.Rows(i).Item("total").ToString)),
                     String.Format("{0:n}", CDec(dt.Rows(i).Item("avance").ToString)),
                     String.Format("{0:n}", rest),
                     CDate(dt.Rows(i).Item("date")).ToString("dd, MMM yy [hh:mm]"),
                     dt.Rows(i).Item("adresse").ToString, dt.Rows(i).Item("writer").ToString,
                     dt.Rows(i).Item("payed").ToString, dt.Rows(i).Item("remise").ToString,
                   dt.Rows(i).Item("bl").ToString, dt.Rows(i).Item("beInFacture").ToString,
                   dt.Rows(i).Item("tp").ToString)

                    Try
                        ProgressBar1.Value += 100 / dt.Rows.Count
                    Catch ex As Exception
                        ProgressBar1.Value = 100
                    End Try

                Next
            Else
                MsgBox("لا توجد اي فاتورة لهذا الزبون")
            End If

            Using z As SubClass = New SubClass(isSell)
                If admin Then
                    z.AboutFactures(isSell)
                End If
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button38.Click

        Dim isSell As Boolean = CBool(btSwitch2.Tag)
        If txtArSearch.text.Contains("|") = False Then
            Dim chs As New ChoseClient
            chs.isSell = isSell
            If chs.ShowDialog = Windows.Forms.DialogResult.OK Then
                txtArSearch.text = chs.clientName & "|" & chs.cid
            Else
                Exit Sub
            End If
        End If

        Dim str As String = txtArSearch.text.Trim
        str = str.Split(CChar("|"))(1)
        Dim clid As Integer = CInt(str)

        Dim rv As New EtatClient
        rv.isSell = isSell
        rv.Client = txtArSearch.text.Trim
        rv.CID = clid
        If rv.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If

    End Sub

    Private Sub txtEnteteMarge_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEnteteMarge.TextChanged
        Try

            'If Not IsNumeric(txtEnteteMarge.Text) Then
            '    txtEnteteMarge.Text = 160
            'Else
            '    txtEnteteMarge.Text = CInt(txtEnteteMarge.Text)
            'End If

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtEnteteMarge", txtEnteteMarge.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Sub txtPiedMarge_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPiedMarge.TextChanged
        Try

            'If Not IsNumeric(txtPiedMarge.Text) Then
            '    txtPiedMarge.Text = 30
            'Else
            '    txtPiedMarge.Text = CInt(txtPiedMarge.Text)
            'End If

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtPiedMarge", txtPiedMarge.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Sub Button39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button39.Click
        Dim aa As New testimage
        aa.ShowDialog()
    End Sub

    Private Sub cbShowGloblCredit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbShowGloblCredit.CheckedChanged

        Try

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "cbShowGloblCredit", cbShowGloblCredit.Checked)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Sub Button40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button40.Click
        Dim gch As New gChooseDesign
        If gch.ShowDialog = DialogResult.OK Then
            Dim gf As New gForm
            gf.localname = gch.localName
            gf.LoadXml()


            If gf.ShowDialog = DialogResult.OK Then

            End If
        End If
    End Sub

    Private Sub PrintDocDesign_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocDesign.PrintPage
        Try
            Dim ds As RPanel = RPl
            Dim dte As String = Format(Date.Now, "dd-MM-yyyy [HH:mm]")
            If RPl.EditMode = True And RPl.ClId <> -111 Then dte = DGVARFA.SelectedRows(0).Cells(6).Value


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
            data.Columns.Add("livreur", GetType(String))
            data.Columns.Add("rest_ttc", GetType(String))
            data.Columns.Add("x_total_ttc_sn_remise", GetType(String))
            data.Columns.Add("RealAvance", GetType(String))
            data.Columns.Add("RealRest", GetType(String))
            data.Columns.Add("Rest", GetType(String))
            data.Columns.Add("caisseAvance", GetType(String))
            data.Columns.Add("caisseRest", GetType(String))


            Dim realAvc As Double = RPl.Avance
            Dim __rest As Double = RPl.Total_TTC - RPl.Avance
            Dim __RRest As Double = RPl.Total_TTC - RPl.Avance
            Dim caisseRest As Double = RPl.Total_TTC - payedCache

            Try
                If ds.isSell And RPl.FctId > 0 Then
                    Dim ta As New ALMohassinDBDataSetTableAdapters.PaymentTableAdapter
                    Dim rdt = ta.GetDataByfctid(RPl.FctId)
                    If rdt.Rows.Count > 0 Then
                        realAvc = 0
                        For i As Integer = 0 To rdt.Rows.Count - 1
                            If StrValue(rdt, "name", i).Contains("@") = False Then
                                realAvc += DblValue(rdt, "montant", i)
                            End If
                        Next
                    End If

                End If
            Catch ex As Exception

            End Try


            __RRest = RPl.Total_TTC - realAvc

            'x_total_ttc_sn_remise
            data.Rows.Add(RPl.FctId, dte, RPl.ClId, RPl.ClientName,
                          String.Format("{0:n2}", RPl.Total_Ht), String.Format("{0:n2}", RPl.Tva),
                          String.Format("{0:n2}", RPl.Total_TTC), String.Format("{0:n2}", RPl.Total_Remise),
                          String.Format("{0:n2}", RPl.Avance), String.Format("{0:n2}", 0),
                          "Cache", adminName, RPl.LbVidal.Text, RPl.bl,
                          String.Format("{0:n2}", RPl.Total_TTC - RPl.Avance),
                           String.Format("{0:n2}", RPl.Total_TTC_Befor_Remise), realAvc.ToString(frmDbl),
                           __RRest.ToString(frmDbl), __rest.ToString(frmDbl), payedCache.ToString(frmDbl), caisseRest.ToString(frmDbl))

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
            dt_Client.Columns.Add("RealEncCredit", GetType(String))

            Dim credit As Double = 0
            Dim EncCreadit As Double = 0
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
                client_ice = RPl.ClientAdresse.Split("*")(2)
            Catch ex As Exception
                client_ice = "-"
            End Try


            If RPl.ClId > 0 Then
                If ds.isSell Then
                    Dim ta As New ALMohassinDBDataSetTableAdapters.FactureTableAdapter
                    Dim tac As New ALMohassinDBDataSetTableAdapters.ClientTableAdapter

                    EncCreadit = ta.ScalarQueryClientCredit(False, RPl.ClId, True)

                    If ds.EditMode = False Then
                        credit = EncCreadit + (RPl.Total_TTC - RPl.Avance)
                    Else
                        credit = EncCreadit
                        EncCreadit = EncCreadit - (RPl.Total_TTC - RPl.Avance)
                        If EncCreadit < 0 Then EncCreadit = 0
                    End If


                    tel = tac.ScalarQueryTel(RPl.ClId)
                Else
                    Dim ta As New ALMohassinDBDataSetTableAdapters.BonTableAdapter
                    EncCreadit = ta.ScalarQueryCompanyCredit(False, RPl.ClId, True)

                    If ds.EditMode = False Then
                        credit = EncCreadit + (RPl.Total_TTC - RPl.Avance)
                    Else
                        credit = EncCreadit
                        EncCreadit = EncCreadit - (RPl.Total_TTC - RPl.Avance)
                        If EncCreadit < 0 Then EncCreadit = 0
                    End If

                End If
            End If

            Dim realEnc As Double = EncCreadit + (realAvc - RPl.Avance)



            ' Add  rows with those columns filled in the DataTable.
            dt_Client.Rows.Add(RPl.ClId, RPl.ClientName, RPl.ClId, client_ville,
                                adresse, client_ice, tel, credit.ToString(frmDbl), EncCreadit.ToString(frmDbl), realEnc.ToString(frmDbl))

            Using g As gDrawClass = New gDrawClass(MP_Localname)
                g.rtl = cbRTL.Checked

                g.DrawBl(e, data, ds.DataSource, dt_Client, Facture_Title, False, M)
            End Using

        Catch ex As Exception

        End Try
    End Sub
    Public MP_Localname As String
    Public Facture_Title As String

    Private Sub PrintDocDesignFct_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocDesignFct.PrintPage
        Try
            Dim ds As RPanel = RPl
            Dim dte As String = Format(CDate(DGVFCT.SelectedRows(0).Cells(2).Value), "dd-MM-yyyy [hh:mm]")
            ' dte = DGVARFA.SelectedRows(0).Cells(2).Value
            Dim ttc As Double = RPl.Total_TTC
            Dim total_droitTimbre As Double = 0
            Dim mode As String = DGVFCT.SelectedRows(0).Cells(8).Value

            If mode = "Cache" Then
                total_droitTimbre = ttc * 0.0025
                ttc += total_droitTimbre
            End If


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
                          String.Format("{0:n2}", RPl.Total_Ht), String.Format("{0:n2}", RPl.Tva),
                          String.Format("{0:n2}", ttc), String.Format("{0:n2}", RPl.Remise),
                          String.Format("{0:n2}", RPl.Avance), String.Format("{0:n2}", total_droitTimbre),
                          mode, adminName, RPl.LbVidal.Text)


            Dim dt_Client As New DataTable
            ' Create four typed columns in the DataTable.
            dt_Client.Columns.Add("Clid", GetType(Integer))
            dt_Client.Columns.Add("name", GetType(String))
            dt_Client.Columns.Add("ref", GetType(String))
            dt_Client.Columns.Add("ville", GetType(String))
            dt_Client.Columns.Add("adresse", GetType(String))
            dt_Client.Columns.Add("ice", GetType(String))
            dt_Client.Columns.Add("tel", GetType(String))




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
                client_ice = RPl.ClientAdresse.Split("*")(2)
            Catch ex As Exception
                client_ice = "-"
            End Try


            ' Add  rows with those columns filled in the DataTable.
            dt_Client.Rows.Add(RPl.ClId, RPl.ClientName, RPl.ClId, client_ville,
                                adresse, client_ice, tel)



            Using g As gDrawClass = New gDrawClass(MP_Localname)
                '   g.rtl = cbRTL.Checked
                g.DrawBl(e, data, ds.DataSource, dt_Client, Facture_Title, False, M)
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button43.Click
        Try
            Dim fntdlg As New FontDialog
            If fntdlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            txtFnPtFr.Text = fntdlg.Font.Name
            txtFsPtFr.Text = CInt(fntdlg.Font.Size)


            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtFnPtFr", txtFnPtFr.Text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtFsPtFr", txtFsPtFr.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Sub Button44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTarif.Click, Button44.Click
        If RPl.isSell Then

            Dim pt As New PriceType

            If pt.ShowDialog = Windows.Forms.DialogResult.OK Then

                If pt.value = 0 Then Exit Sub

                Using a As SubClass = New SubClass()

                    a.ChangeAllPrices(pt.value)
                    Dim bt As New Button
                    bt.Text = RPl.ClientName
                    bt.Tag = RPl.FctId

                    a.FactureSelected(bt, Nothing)
                End Using
            End If
        End If
    End Sub

    Private Sub FlowLayoutPanel1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles FlowLayoutPanel1.MouseDown
        Dim p1 As Point = New Point(0, 0)
        p1 = e.Location
        Dim int = FlowLayoutPanel1.VerticalScroll.Value
        If p1.Y * 2 > FlowLayoutPanel1.Height Then
            int += FlowLayoutPanel1.VerticalScroll.SmallChange * 33
        Else
            int -= FlowLayoutPanel1.VerticalScroll.SmallChange * 33
        End If

        FlowLayoutPanel1.AutoScrollPosition = New Point(0, int)
    End Sub

    Private Sub Panel10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel10.Click
        If GB6.Width = 370 Then
            GB6.Width = 33
        Else
            GB6.Width = 370
        End If
    End Sub

    Private Sub Button44_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PlRcpt.Width += 44
    End Sub

    Private Sub PlRcpt_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PlRcpt.MouseUp
        RplWidth = e.X
    End Sub

    Private Sub btGoBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGoBack.Click

        Dim pr As Integer = 0
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            params.Add("cid", btGoBack.Tag)

            pr = c.SelectByScalar("Category", "pr", params)
        End Using


        btGoBack.Tag = pr

        Using a As SubClass = New SubClass()
            If pr = 0 Then
                a.FillGroupes(False)
            Else
                a.ctg_click(sender, e)
            End If

        End Using
    End Sub

    Private Sub Button46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPrint_Top.Click

        Try
            If CInt(lbLastBon.Tag) = 0 Then Exit Sub

            If PrintDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    MP_Localname = "Top-Default.dat"

                    Dim g As New gGlobClass
                    g = ReadFromXmlFile(Of gGlobClass)(ImgPah & "\Prt_Dsn\" & MP_Localname)


                    Dim ps As New PaperSize(g.P_name, g.W_Page, g.h_Page)
                    ps.PaperName = g.p_Kind
                    PrintDocDesign2.DefaultPageSettings.PaperSize = ps
                    PrintDocDesign2.DefaultPageSettings.Landscape = g.is_Landscape

                    PrintDocDesign2.PrinterSettings.PrinterName = PrintDlg.PrinterSettings.PrinterName
                Catch ex As Exception

                End Try

                Dim nb = PrintDlg.PrinterSettings.Copies
                If nb < 1 Then nb = 1

                For i As Integer = 0 To nb - 1
                    PrintDocDesign2.Print()
                Next

            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub PrintDocDesign2_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocDesign2.PrintPage

        Try
            Dim dt_fct, dt_dtl As DataTable
            Dim clid As Integer = 0

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)

                params.Add("fctid", CInt(lbLastBon.Tag))

                dt_fct = c.SelectDataTable("Facture", {"*"}, params)

                dt_dtl = c.SelectDataTable("DetailsFacture", {"*"}, params)

                params.Clear()
                clid = IntValue(dt_fct, "clid", 0)
            End Using



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
            data.Columns.Add("livreur", GetType(String))

            data.Rows.Add(IntValue(dt_fct, "fctid", 0), DteValue(dt_fct, "date", 0).ToString("dd-MM-yyyy [HH:mm]"), clid, StrValue(dt_fct, "name", 0),
                          String.Format("{0:0.00}", DblValue(dt_fct, "total", 0)), String.Format("{0:0.00}", DblValue(dt_fct, "tva", 0)),
                          String.Format("{0:0.00}", DblValue(dt_fct, "total", 0)), String.Format("{0:0.00}", DblValue(dt_fct, "remise", 0)),
                          String.Format("{0:0.00}", DblValue(dt_fct, "avance", 0)), String.Format("{0:0.00}", 0),
                          "Cache", adminName, dt_dtl.Rows.Count, StrValue(dt_fct, "bl", 0))

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
            Dim adresse = StrValue(dt_fct, "adresse", 0).Split("*")(0)
            Dim client_ville As String = ""
            Dim client_ice As String = ""

            Try
                client_ville = StrValue(dt_fct, "adresse", 0).Split("*")(1)
            Catch ex As Exception
                client_ville = "-"
            End Try

            Try
                client_ice = StrValue(dt_fct, "adresse", 0).Split("*")(2)
            Catch ex As Exception
                client_ice = "-"
            End Try


            If RPl.ClId > 0 Then
                If RPl.isSell Then
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

            If clid > 0 Then
                ' Add  rows with those columns filled in the DataTable.
                dt_Client.Rows.Add(clid, StrValue(dt_fct, "name", 0), clid, client_ville,
                                    adresse, client_ice, tel, credit, EncCreadit)
            Else
                ' Add  rows with those columns filled in the DataTable.
                dt_Client.Rows.Add(0, txtcltcomptoir.Text, 0, "Agadir", "Agadir",
                                      "123456", "0000", credit, EncCreadit)
            End If




            Dim table As New DataTable

            ' Create four typed columns in the DataTable.
            table.Columns.Add("arid", GetType(Integer))
            table.Columns.Add("name", GetType(String))
            table.Columns.Add("price", GetType(Double))
            table.Columns.Add("bprice", GetType(Double))
            table.Columns.Add("tva", GetType(Double))
            table.Columns.Add("qte", GetType(Double))
            table.Columns.Add("unite", GetType(String))
            table.Columns.Add("total", GetType(Double))
            table.Columns.Add("cid", GetType(Integer))
            table.Columns.Add("code", GetType(String))
            table.Columns.Add("depot", GetType(Integer))
            table.Columns.Add("poid", GetType(Integer))
            table.Columns.Add("totalHt", GetType(Double))
            table.Columns.Add("totaltva", GetType(Double))
            table.Columns.Add("dsid", GetType(Double))
            table.Columns.Add("remise", GetType(Double))

            For i As Integer = 0 To dt_dtl.Rows.Count - 1
                Dim _total = DblValue(dt_dtl, "qte", i) * DblValue(dt_dtl, "price", i)
                Dim tv = DblValue(dt_dtl, "tva", i)
                Dim ht As Decimal = _total / ((100 + tv) / 100)
                Dim t_tv = (ht * tv) / 100

                table.Rows.Add(IntValue(dt_dtl, "arid", i), StrValue(dt_dtl, "name", i), DblValue(dt_dtl, "price", i),
                               DblValue(dt_dtl, "bprice", i), tv,
                              DblValue(dt_dtl, "qte", i), StrValue(dt_dtl, "unit", i),
                              _total, IntValue(dt_dtl, "cid", i), StrValue(dt_dtl, "code", i),
                              IntValue(dt_dtl, "depot", i), IntValue(dt_dtl, "poid", i), ht,
                              t_tv, IntValue(dt_dtl, "id", i), 0)
            Next



            Using g As gDrawClass = New gDrawClass(MP_Localname)
                g.rtl = cbRTL.Checked

                g.DrawBl(e, data, table, dt_Client, Facture_Title, False, M)
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CbArticleRemise_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbArticleRemise.CheckedChanged
        RPl.hasManyRemise = CbArticleRemise.Checked
    End Sub


    Private Sub Button70_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button70.Click
        Try
            Dim con As OleDb.OleDbConnection = New OleDb.OleDbConnection(My.Settings.ALMohassinDBConnectionString)
            Try
                con.Close()
            Catch ex As Exception

            End Try


            Dim SFD As New SaveFileDialog
            'SFD.Filter = "*.backup|*.backup"
            If SFD.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            Dim pt = GetDatabaseName()
            pt = pt.Split("|")(pt.Split("|").Count() - 1)

            Dim f As New FileInfo(pt)
            f.CopyTo(SFD.FileName)


            MsgBox("Backup complete successfully", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "AL Mohassib POS Back Up")


        Catch ex As Exception
            MsgBox("Unable to make Backup", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Error")

        End Try
    End Sub
    Function GetDatabaseName() As String
        Dim lcConnString = My.Settings.ALMohassinDBConnectionString
        lcConnString = lcConnString.ToLower

        ' if this is a Jet database, find the index of the "data source" setting
        Dim startIndex As Integer
        If lcConnString.IndexOf("jet.oledb") > -1 Then
            startIndex = lcConnString.IndexOf("data source=")
            If startIndex > -1 Then startIndex += 12
        Else
            ' if this is a SQL Server database, find the index of the "initial 
            ' catalog" or "database" setting
            startIndex = lcConnString.IndexOf("initial catalog=")
            If startIndex > -1 Then
                startIndex += 16
            Else ' if the "Initial Catalog" setting is not found,
                '  try with "Database"
                startIndex = lcConnString.IndexOf("database=")
                If startIndex > -1 Then startIndex += 9
            End If
        End If

        ' if the "database", "data source" or "initial catalog" values are not 
        ' found, return an empty string
        If startIndex = -1 Then Return ""

        ' find where the database name/path ends
        Dim endIndex As Integer = lcConnString.IndexOf(";", startIndex)
        If endIndex = -1 Then endIndex = lcConnString.Length

        ' return the substring with the database name/path
        Return lcConnString.Substring(startIndex, endIndex - startIndex)
    End Function

    Private Sub Button48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTransfert.Click
        If DGVS.SelectedRows.Count = 0 Then Exit Sub



        Dim tr As New TransformeStock
        tr.arid = DGVS.SelectedRows(0).Cells("arid").Value


        If tr.ShowDialog = Windows.Forms.DialogResult.OK Then

            Using g As SubClass = New SubClass()
                g.ctg_stock_click(btTransfert, e)
            End Using
        End If
    End Sub

    Private Sub txtnameStock_KeyDownOk() Handles txtnameStock.KeyDownOk

        DGVS.DataSource = Nothing

        Dim id As Integer = 0

        ' dpt = cbdepot.SelectedValue

        Try
            If txtnameStock.text.Contains("|") Then
                Dim str As String = txtnameStock.text.Trim
                str = str.Split(CChar("|"))(1)
                id = CInt(str)
            Else
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try



        Try
            ' Dim artta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
            Dim sta As New ALMohassinDBDataSetTableAdapters.DetailstockTableAdapter
            Dim sdt = sta.GetDataByAridOnly(id)


            If sdt.Rows.Count = 0 Then
                MsgBox("لا يوجد اي سجل", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "المخزن")
            Else


                DGVS.DataSource = sdt

                DGVS.Columns(0).Visible = False
                DGVS.Columns(1).Visible = False
                ' DGVS.Columns(2).Visible = False
                DGVS.Columns(4).Visible = False
                DGVS.Columns(5).Visible = False
                'DGVS.Columns(9).Visible = False
                'DGVS.Columns(10).Visible = False


                DGVS.Columns(6).DefaultCellStyle.Font = New Font(fontName_Normal, fontSize_Normal, FontStyle.Bold)

                DGVS.Columns(6).HeaderText = "Designation"
                DGVS.Columns(3).HeaderText = "Qte Stk"
                DGVS.Columns(2).HeaderText = "Depot N°"
                DGVS.Columns(7).HeaderText = "Unite"

                DGVS.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DGVS.Columns(6).DisplayIndex = 2
                DGVS.Columns(7).DisplayIndex = 3
                'DGVS.Columns(4).DisplayIndex = 3

            End If
            btTransfert.Tag = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Dim isPanelHide As Boolean = False
    Public paletteFix_width As Integer = 20
    Private Sub btPanelHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPanelHide.Click

        If isPanelHide Then
            btPanelHide.BackgroundImage = My.Resources.gui_10
            PL.Width = paletteFix_width
            isPanelHide = False
        Else
            btPanelHide.BackgroundImage = My.Resources.gui_09
            PL.Width = 20
            isPanelHide = True
        End If
    End Sub

    Private Sub btPanelAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPanelAdd.Click
        Using a As SideClass = New SideClass
            a.AddNewPanel()
        End Using
    End Sub

    Private Sub Button49_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button49.Click
        Dim artdlg As New ChoseCompany
        If artdlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        End If
    End Sub


    Private Sub Panel36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel36.Click
        If GB7.Width = 344 Then
            GB7.Width = 33
        Else
            GB7.Width = 344
        End If
    End Sub

    Private Sub Button29_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button29.Click
        Dim artdlg As New ClientRapport
        If artdlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        End If
    End Sub

    Private Sub lbListBon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbListBon.Click
        Try
            Dim dd As New OpenFactures

            If dd.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim bt As New Button
                bt.Tag = dd.id

                Using a As SubClass = New SubClass
                    a.FactureSelected(bt, e)
                End Using
            End If

        Catch ex As Exception
            Exit Sub
        End Try

    End Sub
    Dim m_i_for As Integer = 0
    Private Sub PrintDocDesign_ListArch_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocDesign_ListArch.PrintPage
        'If m_i_for > 0 Then Exit Sub

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            Dim dt_details As New DataTable
            Dim vidal As Integer = 0

            Dim data As New DataTable
            ' Create four typed columns in the DataTable.
            data.Columns.Add("id", GetType(String))
            data.Columns.Add("date", GetType(String))
            data.Columns.Add("cid", GetType(String))
            data.Columns.Add("name", GetType(String))
            data.Columns.Add("total_ttc", GetType(String))
            data.Columns.Add("total_avance", GetType(String))
            data.Columns.Add("Editeur", GetType(String))
            data.Columns.Add("vidal", GetType(String))

            Dim dt_Client As New DataTable
            ' Create four typed columns in the DataTable.
            dt_Client.Columns.Add("Clid", GetType(Integer))
            dt_Client.Columns.Add("name", GetType(String))
          


            Dim table As New DataTable

         
            table.Columns.Add("name", GetType(String))
            table.Columns.Add("price", GetType(String))
            table.Columns.Add("tva", GetType(Double))
            table.Columns.Add("qte", GetType(String))
            table.Columns.Add("total", GetType(String))
            table.Columns.Add("code", GetType(String))
            table.Columns.Add("depot", GetType(String))
            table.Columns.Add("totaltva", GetType(String))
            table.Columns.Add("remise", GetType(String))
      

            Using g As gDrawClass = New gDrawClass(MP_Localname)
                g.rtl = cbRTL.Checked

                params.Clear()
                data.Rows.Clear()
                dt_Client.Rows.Clear()
                dt_details.Rows.Clear()
                table.Rows.Clear()

                params.Add("fctid", DGVARFA.Rows(m_i_for).Cells(0).Value)
                Try

                    dt_details = a.SelectDataTable("DetailsFacture", {"*"}, params)
                    vidal = dt_details.Rows.Count

                    For i As Integer = 0 To dt_details.Rows.Count - 1
                        ' Add  rows with those columns filled in the DataTable.
                        table.Rows.Add(dt_details.Rows(i).Item("name"), dt_details.Rows(i).Item("price"), 0,
                                       dt_details.Rows(i).Item("qte"), CDbl(dt_details.Rows(i).Item("qte") * dt_details.Rows(i).Item("price")),
                                      dt_details.Rows(i).Item("code"), dt_details.Rows(i).Item("depot"), 0, 0)
                    Next



                    data.Rows.Add(DGVARFA.Rows(m_i_for).Cells(0).Value, DGVARFA.Rows(m_i_for).Cells(1).Value, DGVARFA.Rows(m_i_for).Cells(2).Value,
                                    CDbl(DGVARFA.Rows(m_i_for).Cells(3).Value).ToString(frmDbl),
                                    CDbl(DGVARFA.Rows(m_i_for).Cells(4).Value).ToString(frmDbl), DGVARFA.Rows(m_i_for).Cells(8).Value, vidal)

                    dt_Client.Rows.Add(DGVARFA.Rows(m_i_for).Cells(1).Value, DGVARFA.Rows(m_i_for).Cells(2).Value)


                    g.DrawBl(e, data, table, dt_Client, Facture_Title, False, M)

                Catch ex As Exception
                End Try

                M = 0
            End Using
        End Using

    End Sub

    
    Private Sub Button11_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        If RPl.FctId = 0 Or RPl.EditMode = True Then Exit Sub
        Dim bp As New byPrice
        If bp.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim tableName = "DetailsFacture"
            If btswitsh.Tag = 0 Then tableName = "DetailsBon"
            Dim arid As Integer = 0
            'qte
            Dim qte As Double = 1

            'Price
            Dim price As Double = CDbl(bp.txt.Text)
            'tva
            Dim tva As Double = 20

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)
                params.Add("fctid", CInt(RPl.FctId))
                params.Add("name", "Article")
                params.Add("bprice", price)
                params.Add("price", price)
                params.Add("unit", "u")
                params.Add("qte", qte)
                params.Add("tva", tva)
                params.Add("poid", 1)
                params.Add("arid", 0)
                params.Add("depot", 0)
                params.Add("code", "")
                params.Add("cid", 0)

                arid = c.InsertRecord(tableName, params, True)
            End Using

            If arid > 0 Then
                Dim bt As New Button
                bt.Text = RPl.ClientName
                bt.Tag = RPl.FctId
                Using a As SubClass = New SubClass
                    a.FactureSelected(bt, Nothing)
                End Using
            End If
        End If
    End Sub

    Private Sub Button51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button51.Click
        If plright.Controls.Count > 10 Then Exit Sub
        Using a As SubClass = New SubClass
            Try
                Dim cid As String = 0
                Dim clientname As String = txtcltcomptoir.Text.Split("/")(0)
                If RPl.isSell Then a.NewFacture(cid, clientname, "", 0)
            Catch ex As Exception
            End Try
        End Using
    End Sub

    Private Sub Button52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button52.Click
        'Modify DrawerCode to your receipt printer open drawer code
        Dim DrawerCode As String = Chr(27) & Chr(112) & Chr(48) & Chr(64) & Chr(64)
        'Modify PrinterName to your receipt printer name
        Dim PrinterName As String = txtreceipt.Text

        RawPrinter.PrintRaw(PrinterName, DrawerCode)
        'change Mode de recherche
    End Sub
End Class
