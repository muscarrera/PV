Imports System.IO
Imports System.Drawing.Printing

Public Class ChequePanel


    Dim isRelatedApp As Boolean = False
    Dim nb_trial As Integer = 0
    Dim bonId As Integer = 0
    Dim str_Path As String = ""
    Dim _montant As Double
    Dim _isSell As Boolean
    Public tb_F, tb_P, tb_C As String

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
    Public Property isSell As Boolean
        Get
            Return _isSell
        End Get
        Set(ByVal value As Boolean)
            _isSell = value

            If value Then
                tb_F = "Facture"
                tb_P = "Client_Payement"
                tb_C = "Client"
                btMode.Text = "V : Vente"
            Else
                tb_F = "Bon"
                tb_P = "Company_Payement"
                tb_C = "Fournisseur"
                btMode.Text = "A : Achat"
            End If

            ModeChangedOnlyToday()
        End Set
    End Property

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
       
        Dim edt As New EditAndPrintCheque
        edt.Pid = 0
        If edt.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
    End Sub
    ''' edit payement
    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click, Label20.Click
        Try
            Dim dg As DataGridView = pl.Controls(0)
            If dg.SelectedRows.Count = 0 Then Exit Sub


            Dim edt As New EditAndPrintCheque
            edt.Pid = dg.SelectedRows(0).Cells(0).Value
            If edt.ShowDialog = Windows.Forms.DialogResult.OK Then


            End If
        Catch ex As Exception

        End Try


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

        End If
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
        edt.Pid = 0
        If edt.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        Try


            Dim dg As DataGridView = pl.Controls(0)
            If dg.SelectedRows.Count = 0 Then Exit Sub

            Dim edt As New EditAndPrintCheque
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
        Dim x = pl.Left + Button3.Right - op.Width ' MPx.X - 10
        op.Location = New Point(x, y)

        AddHandler op.MenuLostFocus, AddressOf MenuLostFocus
        AddHandler op.MenuElementSelected, AddressOf MenuElementSelected


        Pl.Controls.Add(op)
        op.BringToFront()
        ' op.Focus()
    End Sub
    Private Sub MenuElementSelected(ByRef ds As PopUpMenu)

        'Dim ss As New SearchBloc
        'ss.Mode = ds.mode

        'If ds.key = "A" Then
        '    isSell = False

        'ElseIf ds.key = "V" Then
        '    isSell = True
        'Else
        '    Dim pr As New MoneySetting
        '    If pr.ShowDialog = DialogResult.OK Then
        '        isSell = isSell
        '    End If
        'End If
    End Sub
    Private Sub MenuLostFocus(ByRef ds As PopUpMenu)
        Pl.Controls.Remove(ds)
        ds.Dispose()
    End Sub

    Private Sub Dg_MouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs)
        Try


            Dim dg As DataGridView = pl.Controls(0)
            If dg.SelectedRows.Count = 0 Then Exit Sub
            If dg.SelectedRows.Count = 0 Then Exit Sub

            Dim edt As New EditAndPrintCheque
            edt.Pid = dg.SelectedRows(0).Cells(0).Value
            If edt.ShowDialog = Windows.Forms.DialogResult.OK Then


            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ModeChangedOnlyToday()
        Throw New NotImplementedException
    End Sub

End Class