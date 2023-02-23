<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditAndPrintCheque
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditAndPrintCheque))
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Panel22 = New System.Windows.Forms.Panel()
        Me.CbWay = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.cbBanque = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btcancel = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.txtClient = New Al_Mohasib.TxtBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.lbR = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lbA = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbT = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.txtBon = New Al_Mohasib.TxtBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.plMsg = New System.Windows.Forms.Panel()
        Me.lbMsg = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.txtRef = New Al_Mohasib.TxtBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.plM = New System.Windows.Forms.Panel()
        Me.lbMontant = New System.Windows.Forms.Label()
        Me.txtMontant = New Al_Mohasib.TxtBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.txtEcheance = New Al_Mohasib.TxtBox()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PrintDoc = New System.Drawing.Printing.PrintDocument()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pb = New System.Windows.Forms.PictureBox()
        Me.Panel11.SuspendLayout()
        Me.Panel22.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.plMsg.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.plM.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.White
        Me.Panel11.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.WhatsApp_Image_2021_06_02_at_17_59_22__1_
        Me.Panel11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel11.Controls.Add(Me.Panel22)
        Me.Panel11.Controls.Add(Me.Panel5)
        Me.Panel11.Controls.Add(Me.btcancel)
        Me.Panel11.Controls.Add(Me.Panel6)
        Me.Panel11.Controls.Add(Me.Button17)
        Me.Panel11.Controls.Add(Me.Panel13)
        Me.Panel11.Controls.Add(Me.Panel10)
        Me.Panel11.Controls.Add(Me.plMsg)
        Me.Panel11.Controls.Add(Me.Panel9)
        Me.Panel11.Controls.Add(Me.plM)
        Me.Panel11.Controls.Add(Me.Panel8)
        Me.Panel11.Location = New System.Drawing.Point(31, 24)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(384, 469)
        Me.Panel11.TabIndex = 9
        '
        'Panel22
        '
        Me.Panel22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel22.Controls.Add(Me.CbWay)
        Me.Panel22.Controls.Add(Me.Label16)
        Me.Panel22.Location = New System.Drawing.Point(42, 200)
        Me.Panel22.Name = "Panel22"
        Me.Panel22.Size = New System.Drawing.Size(297, 31)
        Me.Panel22.TabIndex = 4
        '
        'CbWay
        '
        Me.CbWay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CbWay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbWay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbWay.FormattingEnabled = True
        Me.CbWay.Items.AddRange(New Object() {"Cheque", "Effet (LC)", "Cache", "Virement Bancaire", "TPE", "AUTRE"})
        Me.CbWay.Location = New System.Drawing.Point(62, 0)
        Me.CbWay.Name = "CbWay"
        Me.CbWay.Size = New System.Drawing.Size(233, 21)
        Me.CbWay.TabIndex = 4
        '
        'Label16
        '
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(0, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(62, 29)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Mode"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.cbBanque)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Location = New System.Drawing.Point(44, 28)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(294, 31)
        Me.Panel5.TabIndex = 0
        '
        'cbBanque
        '
        Me.cbBanque.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbBanque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBanque.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbBanque.FormattingEnabled = True
        Me.cbBanque.Location = New System.Drawing.Point(62, 0)
        Me.cbBanque.Name = "cbBanque"
        Me.cbBanque.Size = New System.Drawing.Size(230, 21)
        Me.cbBanque.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Banque"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btcancel
        '
        Me.btcancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btcancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btcancel.Font = New System.Drawing.Font("Century Gothic", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btcancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btcancel.Image = Global.Al_Mohasib.My.Resources.Resources.vector_cancel_icon_png_302651
        Me.btcancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btcancel.Location = New System.Drawing.Point(42, 406)
        Me.btcancel.Name = "btcancel"
        Me.btcancel.Size = New System.Drawing.Size(63, 35)
        Me.btcancel.TabIndex = 7
        Me.btcancel.Text = "Reset"
        Me.btcancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btcancel.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.txtClient)
        Me.Panel6.Controls.Add(Me.Button2)
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Location = New System.Drawing.Point(44, 65)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(294, 31)
        Me.Panel6.TabIndex = 2
        '
        'txtClient
        '
        Me.txtClient.BackColor = System.Drawing.Color.Transparent
        Me.txtClient.BorderColor = System.Drawing.Color.Transparent
        Me.txtClient.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtClient.IsNumiric = False
        Me.txtClient.Location = New System.Drawing.Point(62, 0)
        Me.txtClient.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtClient.Name = "txtClient"
        Me.txtClient.ShowClearIcon = False
        Me.txtClient.ShowSaveIcon = False
        Me.txtClient.Size = New System.Drawing.Size(188, 30)
        Me.txtClient.StartUp = 2
        Me.txtClient.TabIndex = 2
        Me.txtClient.TextSize = 8
        Me.txtClient.TxtBackColor = True
        Me.txtClient.TxtColor = System.Drawing.Color.White
        Me.txtClient.txtReadOnly = False
        Me.txtClient.TxtSelect = New Integer() {1, 0}
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.FACTURE_20
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(250, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(42, 29)
        Me.Button2.TabIndex = 8
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 29)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Client"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button17
        '
        Me.Button17.BackColor = System.Drawing.Color.Blue
        Me.Button17.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button17.FlatAppearance.BorderSize = 0
        Me.Button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button17.Font = New System.Drawing.Font("Century Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button17.Image = Global.Al_Mohasib.My.Resources.Resources.SAVE_20
        Me.Button17.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button17.Location = New System.Drawing.Point(194, 406)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(146, 36)
        Me.Button17.TabIndex = 6
        Me.Button17.Tag = "0"
        Me.Button17.Text = "Enregistrer"
        Me.Button17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button17.UseVisualStyleBackColor = False
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel13.Controls.Add(Me.lbR)
        Me.Panel13.Controls.Add(Me.Label12)
        Me.Panel13.Controls.Add(Me.lbA)
        Me.Panel13.Controls.Add(Me.Label9)
        Me.Panel13.Controls.Add(Me.lbT)
        Me.Panel13.Controls.Add(Me.Label7)
        Me.Panel13.Location = New System.Drawing.Point(44, 139)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(296, 31)
        Me.Panel13.TabIndex = 3
        '
        'lbR
        '
        Me.lbR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbR.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbR.Location = New System.Drawing.Point(220, 0)
        Me.lbR.Name = "lbR"
        Me.lbR.Size = New System.Drawing.Size(74, 29)
        Me.lbR.TabIndex = 6
        Me.lbR.Text = "0.00"
        Me.lbR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label12.Location = New System.Drawing.Point(190, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 29)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "- Rs."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbA
        '
        Me.lbA.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbA.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbA.Location = New System.Drawing.Point(123, 0)
        Me.lbA.Name = "lbA"
        Me.lbA.Size = New System.Drawing.Size(67, 29)
        Me.lbA.TabIndex = 4
        Me.lbA.Text = "0.00"
        Me.lbA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label9.Location = New System.Drawing.Point(87, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 29)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "- Av."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbT
        '
        Me.lbT.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbT.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbT.Location = New System.Drawing.Point(20, 0)
        Me.lbT.Name = "lbT"
        Me.lbT.Size = New System.Drawing.Size(67, 29)
        Me.lbT.TabIndex = 2
        Me.lbT.Text = "0.00"
        Me.lbT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 29)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "T."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel10
        '
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.txtBon)
        Me.Panel10.Controls.Add(Me.Button6)
        Me.Panel10.Controls.Add(Me.Label6)
        Me.Panel10.Location = New System.Drawing.Point(43, 102)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(294, 31)
        Me.Panel10.TabIndex = 3
        '
        'txtBon
        '
        Me.txtBon.BackColor = System.Drawing.Color.Transparent
        Me.txtBon.BorderColor = System.Drawing.Color.Transparent
        Me.txtBon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBon.IsNumiric = False
        Me.txtBon.Location = New System.Drawing.Point(62, 0)
        Me.txtBon.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtBon.Name = "txtBon"
        Me.txtBon.ShowClearIcon = False
        Me.txtBon.ShowSaveIcon = False
        Me.txtBon.Size = New System.Drawing.Size(189, 30)
        Me.txtBon.StartUp = 2
        Me.txtBon.TabIndex = 3
        Me.txtBon.TextSize = 8
        Me.txtBon.TxtBackColor = True
        Me.txtBon.TxtColor = System.Drawing.Color.White
        Me.txtBon.txtReadOnly = False
        Me.txtBon.TxtSelect = New Integer() {1, 0}
        '
        'Button6
        '
        Me.Button6.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.BTGROUP
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Location = New System.Drawing.Point(251, 0)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(41, 29)
        Me.Button6.TabIndex = 8
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 29)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Bon N°"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'plMsg
        '
        Me.plMsg.Controls.Add(Me.lbMsg)
        Me.plMsg.Location = New System.Drawing.Point(43, 348)
        Me.plMsg.Name = "plMsg"
        Me.plMsg.Padding = New System.Windows.Forms.Padding(4)
        Me.plMsg.Size = New System.Drawing.Size(297, 52)
        Me.plMsg.TabIndex = 7
        '
        'lbMsg
        '
        Me.lbMsg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbMsg.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMsg.Location = New System.Drawing.Point(4, 4)
        Me.lbMsg.Name = "lbMsg"
        Me.lbMsg.Size = New System.Drawing.Size(289, 44)
        Me.lbMsg.TabIndex = 0
        Me.lbMsg.Text = "."
        Me.lbMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel9
        '
        Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel9.Controls.Add(Me.txtRef)
        Me.Panel9.Controls.Add(Me.Label5)
        Me.Panel9.Location = New System.Drawing.Point(42, 311)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(297, 31)
        Me.Panel9.TabIndex = 7
        '
        'txtRef
        '
        Me.txtRef.BackColor = System.Drawing.Color.Transparent
        Me.txtRef.BorderColor = System.Drawing.Color.Transparent
        Me.txtRef.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRef.IsNumiric = False
        Me.txtRef.Location = New System.Drawing.Point(62, 0)
        Me.txtRef.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtRef.Name = "txtRef"
        Me.txtRef.ShowClearIcon = False
        Me.txtRef.ShowSaveIcon = False
        Me.txtRef.Size = New System.Drawing.Size(233, 30)
        Me.txtRef.StartUp = 2
        Me.txtRef.TabIndex = 7
        Me.txtRef.TextSize = 8
        Me.txtRef.TxtBackColor = True
        Me.txtRef.TxtColor = System.Drawing.Color.White
        Me.txtRef.txtReadOnly = False
        Me.txtRef.TxtSelect = New Integer() {1, 0}
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 29)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Ref/N°"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'plM
        '
        Me.plM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.plM.Controls.Add(Me.lbMontant)
        Me.plM.Controls.Add(Me.txtMontant)
        Me.plM.Controls.Add(Me.Label3)
        Me.plM.Location = New System.Drawing.Point(43, 237)
        Me.plM.Name = "plM"
        Me.plM.Size = New System.Drawing.Size(297, 31)
        Me.plM.TabIndex = 5
        '
        'lbMontant
        '
        Me.lbMontant.BackColor = System.Drawing.Color.Transparent
        Me.lbMontant.Dock = System.Windows.Forms.DockStyle.Right
        Me.lbMontant.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbMontant.Font = New System.Drawing.Font("Century Gothic", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMontant.ForeColor = System.Drawing.Color.Green
        Me.lbMontant.Location = New System.Drawing.Point(140, 0)
        Me.lbMontant.Name = "lbMontant"
        Me.lbMontant.Size = New System.Drawing.Size(155, 29)
        Me.lbMontant.TabIndex = 6
        Me.lbMontant.Text = "0.00 dhs"
        Me.lbMontant.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMontant
        '
        Me.txtMontant.BackColor = System.Drawing.Color.Transparent
        Me.txtMontant.BorderColor = System.Drawing.Color.Transparent
        Me.txtMontant.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMontant.IsNumiric = True
        Me.txtMontant.Location = New System.Drawing.Point(62, 0)
        Me.txtMontant.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtMontant.Name = "txtMontant"
        Me.txtMontant.ShowClearIcon = False
        Me.txtMontant.ShowSaveIcon = False
        Me.txtMontant.Size = New System.Drawing.Size(233, 30)
        Me.txtMontant.StartUp = 2
        Me.txtMontant.TabIndex = 5
        Me.txtMontant.TextSize = 8
        Me.txtMontant.TxtBackColor = True
        Me.txtMontant.TxtColor = System.Drawing.Color.White
        Me.txtMontant.txtReadOnly = False
        Me.txtMontant.TxtSelect = New Integer() {1, 0}
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 29)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Montant"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel8
        '
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.txtEcheance)
        Me.Panel8.Controls.Add(Me.Button14)
        Me.Panel8.Controls.Add(Me.Label4)
        Me.Panel8.Location = New System.Drawing.Point(42, 274)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(297, 31)
        Me.Panel8.TabIndex = 6
        '
        'txtEcheance
        '
        Me.txtEcheance.BackColor = System.Drawing.Color.Transparent
        Me.txtEcheance.BorderColor = System.Drawing.Color.Transparent
        Me.txtEcheance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEcheance.IsNumiric = False
        Me.txtEcheance.Location = New System.Drawing.Point(62, 0)
        Me.txtEcheance.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtEcheance.Name = "txtEcheance"
        Me.txtEcheance.ShowClearIcon = False
        Me.txtEcheance.ShowSaveIcon = False
        Me.txtEcheance.Size = New System.Drawing.Size(198, 30)
        Me.txtEcheance.StartUp = 2
        Me.txtEcheance.TabIndex = 6
        Me.txtEcheance.TextSize = 8
        Me.txtEcheance.TxtBackColor = True
        Me.txtEcheance.TxtColor = System.Drawing.Color.White
        Me.txtEcheance.txtReadOnly = False
        Me.txtEcheance.TxtSelect = New Integer() {1, 0}
        '
        'Button14
        '
        Me.Button14.BackgroundImage = CType(resources.GetObject("Button14.BackgroundImage"), System.Drawing.Image)
        Me.Button14.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button14.FlatAppearance.BorderSize = 0
        Me.Button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button14.Location = New System.Drawing.Point(260, 0)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(35, 29)
        Me.Button14.TabIndex = 7
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 29)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Echeance"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button1.Image = Global.Al_Mohasib.My.Resources.Resources.Print_22X22
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(746, 347)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(133, 36)
        Me.Button1.TabIndex = 6
        Me.Button1.Tag = "0"
        Me.Button1.Text = "Imprimer"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'PrintDoc
        '
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.WhatsApp_Image_2021_06_02_at_17_59_22__1_
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.pb)
        Me.Panel1.Location = New System.Drawing.Point(461, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(18, 14, 18, 14)
        Me.Panel1.Size = New System.Drawing.Size(436, 305)
        Me.Panel1.TabIndex = 9
        '
        'pb
        '
        Me.pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pb.Location = New System.Drawing.Point(18, 14)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(400, 277)
        Me.pb.TabIndex = 0
        Me.pb.TabStop = False
        '
        'EditAndPrintCheque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(904, 517)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "EditAndPrintCheque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Form :"
        Me.Panel11.ResumeLayout(False)
        Me.Panel22.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.plMsg.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.plM.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Panel22 As System.Windows.Forms.Panel
    Friend WithEvents CbWay As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents cbBanque As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btcancel As System.Windows.Forms.Button
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents txtClient As Al_Mohasib.TxtBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button17 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents lbR As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lbA As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbT As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents txtBon As Al_Mohasib.TxtBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents plMsg As System.Windows.Forms.Panel
    Friend WithEvents lbMsg As System.Windows.Forms.Label
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents txtRef As Al_Mohasib.TxtBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents plM As System.Windows.Forms.Panel
    Friend WithEvents lbMontant As System.Windows.Forms.Label
    Friend WithEvents txtMontant As Al_Mohasib.TxtBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents txtEcheance As Al_Mohasib.TxtBox
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PrintDoc As System.Drawing.Printing.PrintDocument
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pb As System.Windows.Forms.PictureBox
End Class
