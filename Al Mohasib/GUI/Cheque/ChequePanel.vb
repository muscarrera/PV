Imports System.IO
Imports System.Drawing.Printing
Imports System.Text.RegularExpressions
Imports System.Net

Public Class ChequePanel

    Dim Total As Double
    Dim isRelatedApp As Boolean = False
    Dim nb_trial As Integer = 0
    Dim bonId As Integer = 0
    Public str_Path As String = ""
    Dim _montant As Double
    Dim _isSell As Boolean
    Public tb_F, tb_P, tb_C As String
    Dim _ds As DataTable
    Public admin As Boolean
    Public adminId As Object
    Public adminName As Object

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
    Public _pid As String = "Pid"
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
                btMode.Text = "V : Vente"
            Else
                tb_F = "Bon"
                tb_P = "CompanyPayment"
                tb_C = "company"
                _pid = "PBid"
                btMode.Text = "A : Achat"
            End If

            ModeChangedOnlyToday()
        End Set
    End Property
    Public Property dataSource As DataTable
        Get
            Return _ds
        End Get
        Set(ByVal value As DataTable)
            _ds = value


            pl.Visible = False
            Total = 0

            FillRowsByGrid(value)
            pl.Visible = True

        End Set
    End Property

    '///////////////////////////////////
    Private Sub FillRowsByGrid(ByVal _ds As DataTable)
        pl.Controls.Clear()
        Try
            If _ds.Rows.Count > 0 Then
                Dim dg As New DataGridView
                dg.DataSource = _ds
                StyleDatagrid(dg)
                pl.Controls.Add(dg)

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


                lbNbr.Text = dg.Rows.Count & " Lines"
                Dim sum As Double
                Try
                    sum = Convert.ToDouble(_ds.Compute("SUM(montant)", String.Empty))
                    lbTotal.Text = sum.ToString("N2") & " Dhs"
                Catch ex As Exception
                    lbTotal.Text = "... "
                End Try

                AddHandler dg.CellMouseDoubleClick, AddressOf Dg_MouseDoubleClick

            End If

        Catch ex As Exception
        End Try
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
    '//////////////////////////////////
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
        getRegistryinfo(isRelatedApp, "isRelatedApp", True)
        getRegistryinfo(nb_trial, "nb_trial", 1)
        getRegistryinfo(isActive, "ALM_ImpCheq_Ref", False)
        getRegistryinfo(str_Path, "str_Path", "")
    End Sub
    '//////////////////////////////////

    Private Sub ChequePanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        HandleRegistryinfo()
        isSell = True

        'Dim hostName As String = Net.Dns.GetHostName()
        'Dim IPAddress As String = Net.Dns.GetHostByName(hostName).AddressList(0).ToString()
        'Me.Text = "Host Name: " & hostName & "  IP: " & IPAddress
        'Dim MyIP As IPAddress = GetExternalIP()
        'Me.Text = MyIP.ToString

        Dim pwdwin As New PWDPicker

        If pwdwin.ShowDialog = Windows.Forms.DialogResult.OK Then

            If pwdwin.DGV1.SelectedRows(0).Cells(2).Value = "admin" Then
                admin = True
                adminId = pwdwin.DGV1.SelectedRows(0).Cells(0).Value
                adminName = pwdwin.DGV1.SelectedRows(0).Cells(1).Value
            Else
                admin = False
                adminId = pwdwin.DGV1.SelectedRows(0).Cells(0).Value
                adminName = pwdwin.DGV1.SelectedRows(0).Cells(1).Value

            End If
        Else
            End
        End If
    End Sub
    Function GetExternalIP() As IPAddress
        Dim lol As WebClient = New WebClient()
        Dim str As String = lol.DownloadString("http://www.ip-adress.com/")
        Dim pattern As String = "<h2>My IPv4 Address"
        Dim matches1 As MatchCollection = Regex.Matches(str, pattern)
        Dim ip As String = matches1(0).ToString
        ip = ip.Remove(0, 21)
        ip = ip.Replace("</h2>", "")
        ip = ip.Replace(" ", "")
        Return IPAddress.Parse(ip)
    End Function
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        txtC.text = ""
        txtB.text = ""
        txtD1.text = ""
        txtD2.text = ""
        txtR.text = ""
        txtM.text = ""
    End Sub


    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

            Dim params As New Dictionary(Of String, Object)

            If Not IsNothing(cbB.SelectedItem) Then If cbB.SelectedItem.ToString.Length > 2 Then params.Add("way = ", cbB.Text)
            If txtC.text.Contains("|") Then params.Add("cid = ", txtC.text.Split("|")(1))
            If IsNumeric(txtB.text) Then params.Add("fctid = ", txtB.text)

            If IsDate(txtD1.text) Then
                Dim d As Date = txtD1.text
                Dim dt1 = New DateTime(d.Year, d.Month, d.Day, 0, 1, 0, 0)
                params.Add("date > ", dt1)
            End If
            If IsDate(txtD2.text) Then
                Dim d As Date = txtD2.text
                Dim dt1 = New DateTime(d.Year, d.Month, d.Day, 23, 59, 0, 0)
                params.Add("date < ", dt1)
            End If

            If txtR.text <> "" Then params.Add("Num LIKE ", txtR.text)
            If txtM.text <> "" Then params.Add("montant = ", txtM.text)

            Dim dt As DataTable
            params.Add("name NOT  LIKE  ", "@%")

            dt = a.SelectDataTableSymbols("CompanyPayment", {"*"}, params, , "LIMIT 50")

            FillRowsByGrid(dt)



        End Using
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




    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Panel1.Width = 10
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

        If txtC.text.Contains("|") Then chs.txtArSearch.text = txtC.text
        If IsNumeric(txtB.text) Then chs.txtArSearch.text = txtB.text

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

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim edt As New EditAndPrintCheque
        edt.isSell = isSell
        edt.Pid = 0

        If edt.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        Try


            Dim dg As DataGridView = pl.Controls(0)
            If dg.SelectedRows.Count = 0 Then Exit Sub

            Dim edt As New EditAndPrintCheque
            edt.isSell = isSell
            edt.Pid = dg.SelectedRows(0).Cells(0).Value

            If edt.ShowDialog = Windows.Forms.DialogResult.OK Then


            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        'RaiseEvent UpdateRemise()
        Dim op As New PopUpMenu   ' OptionAddElement
        op.mode = "Fl:Filtre"
        Dim params As New Dictionary(Of String, String)

        params.Add("Reglage", "R")

        params.Add("Achat", "A")
        params.Add("Vente", "V")

        op.dataSource = params

        Dim MPx As Point = MousePosition()
        Dim y = 0 'MPx.Y - op.Height
        Dim x = Panel8.Left + Button19.Right - op.Width ' - 10
        op.Location = New Point(x, y)

        AddHandler op.MenuLostFocus, AddressOf MenuLostFocus
        AddHandler op.MenuElementSelected, AddressOf MenuElementSelected


        pl.Controls.Add(op)
        op.BringToFront()
        ' op.Focus()
    End Sub
    Private Sub MenuElementSelected(ByRef ds As PopUpMenu)

        Dim ss As New SearchBloc
        ss.Mode = ds.mode

        If ds.key = "A" Then
            isSell = False

        ElseIf ds.key = "V" Then
            isSell = True

        End If
    End Sub
    Private Sub MenuLostFocus(ByRef ds As PopUpMenu)
        pl.Controls.Remove(ds)
        ds.Dispose()
    End Sub

    Private Sub Dg_MouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs)
        Try
            Dim dg As DataGridView = pl.Controls(0)
            If dg.SelectedRows.Count = 0 Then Exit Sub
            If dg.SelectedRows.Count = 0 Then Exit Sub

            Dim edt As New EditAndPrintCheque
            edt.isSell = isSell
            edt.Pid = dg.SelectedRows(0).Cells(0).Value
            If edt.ShowDialog = Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MenuElementSelectedWay(ByRef ds As PopUpMenu)

        For Each sb As SearchBloc In plBlocSearch.Controls
            If sb.Mode = "Mth:Methode" Then
                sb.Key = "way:" & ds.value
                sb.Value = ds.value

                plBlocSearch_ControlAdded(Nothing, Nothing)
                Exit Sub
            End If
        Next

        Dim ss As New SearchBloc
        ss.Mode = "Mth:Methode"
        ss.Key = "way:" & ds.value
        ss.Value = ds.value

        AddHandler ss.ClearElemeent, AddressOf SearchBloc_ClearElemeent
        ss.Dock = DockStyle.Left

        plBlocSearch.Controls.Add(ss)
         
    End Sub
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        For Each sb As SearchBloc In plBlocSearch.Controls
            If sb.Mode = "P:isPayed" Then
                sb.Key = "desig:-;ech:" & Now.Date.ToString("yyyy-MM-dd") & ":>=;way:Cache:<>"
                sb.Value = sender.text

                plBlocSearch_ControlAdded(Nothing, Nothing)
                Exit Sub
            End If
        Next

        Dim ss As New SearchBloc
        ss.Mode = "P:isPayed"
        ss.Key = "desig:-;ech:" & Now.Date.ToString("yyyy-MM-dd") & ":>=;way:Cache:<>"
        ss.Value = sender.text

        AddHandler ss.ClearElemeent, AddressOf SearchBloc_ClearElemeent
        ss.Dock = DockStyle.Left

        plBlocSearch.Controls.Add(ss)
    End Sub
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        For Each sb As SearchBloc In plBlocSearch.Controls
            If sb.Mode = "P:isPayed" Then
                sb.Key = "desig:IMPAYE:<>;ech:" & Now.Date.ToString("yyyy-MM-dd") & ":<;way:Cache%:NOT LIKE; way :%[%:NOT LIKE" '"desig:PAYE"
                sb.Value = sender.text

                plBlocSearch_ControlAdded(Nothing, Nothing)
                Exit Sub
            End If
        Next

        Dim ss As New SearchBloc
        ss.Mode = "P:isPayed"
        ss.Key = "desig:IMPAYE:<>;ech:" & Now.Date.ToString("yyyy-MM-dd") & ":<;way:Cache%:NOT LIKE; way :%[%:NOT LIKE" '"desig:PAYE"
        ss.Value = sender.text

        AddHandler ss.ClearElemeent, AddressOf SearchBloc_ClearElemeent
        ss.Dock = DockStyle.Left

        plBlocSearch.Controls.Add(ss)
    End Sub
    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        For Each sb As SearchBloc In plBlocSearch.Controls
            If sb.Mode = "P:isPayed" Then
                sb.Key = "desig:IMPAYE"
                sb.Value = sender.text

                plBlocSearch_ControlAdded(Nothing, Nothing)
                Exit Sub
            End If
        Next

        Dim ss As New SearchBloc
        ss.Mode = "P:isPayed"
        ss.Key = "desig:IMPAYE"
        ss.Value = sender.text

        AddHandler ss.ClearElemeent, AddressOf SearchBloc_ClearElemeent
        ss.Dock = DockStyle.Left

        plBlocSearch.Controls.Add(ss)
    End Sub

    Private Sub plBlocSearch_ControlAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles plBlocSearch.ControlAdded, plBlocSearch.ControlRemoved
        Dim W As Integer = plBlocSearch.Width + 150
        If W < 650 Then W = 650
        plMainSearch.Width = W

        ModeChanged()
    End Sub
    Private Sub SearchBloc_ClearElemeent(ByVal ds As SearchBloc)
        plBlocSearch.Controls.Remove(ds)
    End Sub
    '///////////////////////////////////////
    Private Sub ModeChanged()

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            Dim order As New Dictionary(Of String, String)
            Dim dt As New DataTable
            order.Add(_pid, "DESC")
            params.Add("desig <> ", "@F")
            params.Add("way NOT LIKE ", "%CACHE%")
            params.Add("name NOT LIKE ", "@%")

            If plBlocSearch.Controls.Count = 0 Then
                '   dt = c.SelectDataTableWithSyntaxe(ds.tb_P, "", {"*"}, params, order, "LIMIT 50")
                dt = c.SelectDataTableSymbols(tb_P, {"*"}, params, order, "LIMIT 50")

                dataSource = dt

            Else
                SearchElementChanged()
            End If


        End Using

    End Sub
    Private Sub SearchElementChanged()

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)

            For Each p As SearchBloc In plBlocSearch.Controls
                If p.Mode.StartsWith("DT") Then
                    dateElementSearch(p, params, "date")
                    Continue For
                ElseIf p.Mode.StartsWith("EC") Then
                    dateElementSearch(p, params, "ech")
                    Continue For
                End If

                Dim str = p.Key.Split(";")
                For i As Integer = 0 To str.Length - 1
                    Dim str2 = str(i).Split(":")
                    If str2.Length = 2 Then
                        params.Add(str2(0) & " = ", str2(1))
                    Else
                        params.Add(str2(0) & " " & str2(2) & " ", str2(1))
                    End If
                Next
            Next

            params.Add(" desig <> ", "@F")
            params.Add("name NOT LIKE ", "@%")

            Dim order As New Dictionary(Of String, String)
            order.Add(_pid, "DESC")


            Dim ls = c.SelectDataTableSymbols(tb_P, {"*"}, params, order)

            dataSource = ls
        End Using


    End Sub
    Private Sub dateElementSearch(ByVal p As SearchBloc, ByRef params As Dictionary(Of String, Object), ByVal f As String)
        Dim str_dt As String = ""
        If p.Key = "MO" Then
            str_dt = Now.ToString("yyyy-MM") & "%"
            params.Add(f & " LIKE ", str_dt)
        ElseIf p.Key = "NM" Then '''''' next month
            str_dt = Now.AddMonths(1).ToString("yyyy-MM") & "%"
            params.Add(f & "  LIKE ", str_dt)
        ElseIf p.Key = "NS" Then '''''next week
            Dim fdw As DateTime = DateTime.Today.AddDays(15).AddDays(-Weekday(DateTime.Today.AddDays(15), FirstDayOfWeek.System) + 1)
            params.Add(f & "  <= ", fdw)

            fdw = DateTime.Today.AddDays(7).AddDays(-Weekday(DateTime.Today.AddDays(7), FirstDayOfWeek.System) + 1)
            params.Add(f & "  >= ", fdw)
        ElseIf p.Key = "DM" Then
            str_dt = Now.AddDays(1).ToString("yyyy-MM-dd") & "%"
            params.Add(f & "  LIKE ", str_dt)
        ElseIf p.Key = "AD" Then
            str_dt = Now.AddDays(2).ToString("yyyy-MM-dd") & "%"
            params.Add(f & "  LIKE ", str_dt)
        ElseIf p.Key.StartsWith("DS") Then '''''SpecialDate
            Dim str As String = p.Key.Split(":")(1)
            If str = "" Then Exit Sub

            If IsDate(str) Then
                str_dt = CDate(str).ToString("yyyy-MM-dd") & "%"
                params.Add(f & "  LIKE ", str_dt)
            Else
                Dim cleanString As String = Regex.Replace(str, "[^0-9\-/]", "")
                If IsDate(cleanString) Then Exit Sub

                If str.ToUpper.StartsWith("S") Or str.ToUpper.StartsWith("SE") Or
                    str.ToUpper.StartsWith("SEM") Or str.ToUpper.StartsWith("SM") Then
                    Dim fdw As DateTime = CDate(cleanString).AddDays(-Weekday(CDate(cleanString), FirstDayOfWeek.System) + 1)
                    params.Add(f & "  >= ", fdw)
                    fdw = CDate(cleanString).AddDays(+7).AddDays(-Weekday(CDate(cleanString).AddDays(+7), FirstDayOfWeek.System) + 1)
                    params.Add(f & "  <= ", fdw)
                ElseIf str.ToUpper.StartsWith("M") Or str.ToUpper.StartsWith("MO") Or
                                    str.ToUpper.StartsWith("MOIS") Then
                    str_dt = CDate(cleanString).ToString("yyyy-MM") & "%"
                    params.Add(f & " LIKE ", str_dt)
                End If
            End If
        ElseIf p.Key = "LM" Then
            str_dt = Now.AddMonths(-1).ToString("yyyy-MM") & "%"
            params.Add(f & "  LIKE ", str_dt)
        ElseIf p.Key = "SE" Then
            Dim fdw As DateTime = DateTime.Today.AddDays(-Weekday(DateTime.Today, FirstDayOfWeek.System) + 1)
            params.Add(f & "  >= ", fdw)
            fdw = DateTime.Today.AddDays(+7).AddDays(-Weekday(DateTime.Today.AddDays(+7), FirstDayOfWeek.System) + 1)
            params.Add(f & "  <= ", fdw)
        ElseIf p.Key = "LS" Then
            Dim fdw As DateTime = DateTime.Today.AddDays(-Weekday(DateTime.Today, FirstDayOfWeek.System) + 1)
            params.Add(f & "  <= ", fdw)

            fdw = DateTime.Today.AddDays(-7).AddDays(-Weekday(DateTime.Today.AddDays(-7), FirstDayOfWeek.System) + 1)
            params.Add(f & "  >= ", fdw)

        ElseIf p.Key = "HI" Then
            str_dt = Now.AddDays(-1).ToString("yyyy-MM-dd") & "%"
            params.Add(f & "  LIKE ", str_dt)
        Else
            str_dt = Now.ToString("yyyy-MM-dd") & "%"
            params.Add(f & "  LIKE ", str_dt)
        End If
    End Sub
    Private Sub ModeChangedOnlyToday()
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)


            Dim str_dt = Now.ToString("yyyy-MM-dd") & "%"
            params.Add("date LIKE ", str_dt)

            params.Add(" desig <> ", "@F")
            Dim order As New Dictionary(Of String, String)
            order.Add(_pid, "DESC")
            Dim ls = c.SelectDataTableSymbols(tb_P, {"*"}, params, order)

            dataSource = ls
        End Using

    End Sub

    Private Sub btMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btMode.Click
        'RaiseEvent UpdateRemise()
        Dim op As New PopUpMenu   ' OptionAddElement
        op.mode = "DT:Date"
        Dim params As New Dictionary(Of String, String)


        params.Add("Date d'échéance", "BB") '  la 
        params.Add("Date de création", "AA") 'le mois dernier  la semaine dernière

        op.dataSource = params

        Dim MPx As Point = MousePosition()
        Dim y = 0 'MPx.Y - op.Height
        Dim x = Panel8.Left + btMode.Right - op.Width ' MPx.X - 10
        op.Location = New Point(x, y)

        AddHandler op.MenuLostFocus, AddressOf MenuLostFocus
        AddHandler op.MenuElementSelected, AddressOf MenuElementSelected_Date


        pl.Controls.Add(op)
        op.BringToFront()
        ' op.Focus()
    End Sub
    Private Sub MenuElementSelected_Date(ByRef op As PopUpMenu)
        'RaiseEvent UpdateRemise()
        'Dim op As New PopUpMenu   ' OptionAddElement
        Dim params As New Dictionary(Of String, String)

        If op.key = "AA" Then
            op.mode = "DT:Date"

        ElseIf op.key = "BB" Then
            op.mode = "EC:Date"
            params.Add("Le mois prochain", "NM") '  la 
            params.Add("Semaine prochaine", "NS")
            params.Add("Après demain", "AD")
            params.Add("Demain", "DM")
        End If

        params.Add("Le mois dernier", "LM") '  la 
        params.Add("Ce mois-ci", "MO") 'le mois dernier  la semaine dernière
        params.Add("Semaine dernière", "LS")
        params.Add("Cette semaine", "SE")
        params.Add("Hier", "HI")
        params.Add("Aujourd'hui", "AU")
        params.Add("Date sélectionnée", "DS")

        op.dataSource = params

        Dim MPx As Point = MousePosition()
        Dim y = 0 'MPx.Y - op.Height
        Dim x = Panel8.Left + btMode.Right - op.Width ' MPx.X - 10
        op.Location = New Point(x, y)

        RemoveHandler op.MenuElementSelected, AddressOf MenuElementSelected_Date
        AddHandler op.MenuElementSelected, AddressOf MenuElementSelected2


        'Pl.Controls.Add(op)
        'op.BringToFront()
        '' op.Focus()


    End Sub

    Private Sub MenuElementSelected2(ByRef ds As PopUpMenu)

        If ds.key = "DS" Then ds.key = "DS:" & txtSearch.text

        For Each sb As SearchBloc In plBlocSearch.Controls
            If sb.Mode = ds.mode Then
                sb.Key = ds.key
                sb.Value = ds.value

                pl.Controls.Remove(ds)
                ds.Dispose()

                plBlocSearch_ControlAdded(Nothing, Nothing)
                Exit Sub
            End If
        Next

        Dim ss As New SearchBloc
        ss.Mode = ds.mode
        ss.Key = ds.key
        ss.Value = ds.value

        AddHandler ss.ClearElemeent, AddressOf SearchBloc_ClearElemeent
        ss.Dock = DockStyle.Left

        plBlocSearch.Controls.Add(ss)

        pl.Controls.Remove(ds)
        ds.Dispose()
    End Sub
    
    Private Sub txtsearch_KeyDownOk() Handles txtSearch.KeyDownOk
        Dim ss As New SearchBloc
        Dim str = txtSearch.text
        Dim _mode = ""
        Dim _key = ""

        If str.Contains(":") Then
            If str.Trim.ToUpper.StartsWith("T") Then
                _mode = "Tg:Tags"
                _key = "ref:%" & str.Split(":")(1) & "%: LIKE "
            ElseIf str.Trim.ToUpper.StartsWith("M") Then
                _mode = "Mth:Methode"
                _key = "way:%" & str.Split(":")(1) & "%: LIKE "
            ElseIf str.Trim.ToUpper.StartsWith("V") Then
                _mode = "Vl:Valeur"
                _key = "montant:" & str.Split(":")(1)
            Else
                _mode = "Nm:Nom"
                _key = "name:%" & str.Split(":")(1) & "%: LIKE "
            End If
        Else


            If IsNumeric(str) Then
                _mode = "Vl:Valeur"
                _key = "montant:" & str
            ElseIf IsDate(str) Then
                _mode = "Vl:Valeur"
                _key = "date:%" & txtSearch.text & "%: LIKE "
            Else
                _mode = "Nm:Nom"
                _key = "name:%" & txtSearch.text & "%: LIKE "
            End If

        End If

        For Each sb As SearchBloc In plBlocSearch.Controls
            If sb.Mode = _mode Then
                sb.Key = _key
                sb.Value = txtSearch.text

                plBlocSearch_ControlAdded(Nothing, Nothing)
                Exit Sub
            End If
        Next

        ss.Mode = _mode
        ss.Key = _key
        ss.Value = txtSearch.text

        AddHandler ss.ClearElemeent, AddressOf SearchBloc_ClearElemeent
        ss.Dock = DockStyle.Left

        plBlocSearch.Controls.Add(ss)
        txtSearch.text = ""
    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        ModeChanged()
    End Sub

    Private Sub btBloc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBloc.Click
        Dim CC As New ChoseClient
        CC.isSell = isSell

        If CC.ShowDialog = Windows.Forms.DialogResult.OK Then

            For Each sb As SearchBloc In plBlocSearch.Controls
                If sb.Mode = "C:CLT" Then
                    sb.Key = "cid:" & CC.cid
                    sb.Value = CC.clientName
                    plBlocSearch_ControlAdded(Nothing, Nothing)
                    Exit Sub
                End If
            Next

            Dim ss As New SearchBloc
            ss.Mode = "C:CLT"
            ss.Key = "cid:" & CC.cid
            ss.Value = CC.clientName

            AddHandler ss.ClearElemeent, AddressOf SearchBloc_ClearElemeent
            ss.Dock = DockStyle.Left

            plBlocSearch.Controls.Add(ss)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TypeOf pl.Controls(0) Is DataGridView Then
            Dim params As New Dictionary(Of String, String)
            params.Add("CAISSE", Now.Date)
            params.Add("Filtre Par", plBlocSearch.Controls.Count & " element(s)")

            For Each p As SearchBloc In plBlocSearch.Controls
                params.Add(p.Mode, p.Value)
            Next

            Dim TL = "Caisse"
            SaveDataToHtml_WithTITLE(pl.Controls(0), TL, params)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TypeOf pl.Controls(0) Is DataGridView Then
            SaveExcel(pl.Controls(0), "Caisse", "Caisse", "")
        End If
    End Sub

    Private Sub btList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btList.Click
        'RaiseEvent UpdateRemise()
        Dim op As New PopUpMenu   ' OptionAddElement
        op.mode = "Mth:Methode"
        Dim params As New Dictionary(Of String, String)
 
        params.Add("Autre", "aut")
        params.Add("BON DE RETOUR", "bon")
        params.Add("Virement(Bancaire)", "vir")
        params.Add("TPE", "tpe")
        params.Add("Effet(LC)", "eff")
        params.Add("Cheque", "che")
        params.Add("Cache", "cha")
   
        op.dataSource = params

        Dim MPx As Point = MousePosition()
        Dim y = 0 'MPx.Y - op.Height
        Dim x = Panel7.Left + btList.Right - op.Width ' - 10
        op.Location = New Point(x, y)

        AddHandler op.MenuLostFocus, AddressOf MenuLostFocus
        AddHandler op.MenuElementSelected, AddressOf MenuElementSelectedWay


        pl.Controls.Add(op)
        op.BringToFront()
    End Sub
End Class