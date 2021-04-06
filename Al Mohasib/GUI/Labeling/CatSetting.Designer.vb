<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CatSetting
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
        Me.cbR = New System.Windows.Forms.CheckBox()
        Me.Pl = New System.Windows.Forms.Panel()
        Me.Pb = New System.Windows.Forms.PictureBox()
        Me.txtWel = New Al_Mohasib.TxtBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtNbrW = New Al_Mohasib.TxtBox()
        Me.txtHel = New Al_Mohasib.TxtBox()
        Me.txtEspW = New Al_Mohasib.TxtBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNbrH = New Al_Mohasib.TxtBox()
        Me.txtEspH = New Al_Mohasib.TxtBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtX = New Al_Mohasib.TxtBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtY = New Al_Mohasib.TxtBox()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvCats = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Txt_H = New Al_Mohasib.TxtBox()
        Me.Txt_W = New Al_Mohasib.TxtBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btLand = New System.Windows.Forms.Button()
        Me.PlCommande = New System.Windows.Forms.Panel()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.btImprimer = New System.Windows.Forms.Button()
        Me.lb = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.dgvPages = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Pl.SuspendLayout()
        CType(Me.Pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvCats, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PlCommande.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgvPages, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbR
        '
        Me.cbR.AutoSize = True
        Me.cbR.Location = New System.Drawing.Point(31, 21)
        Me.cbR.Name = "cbR"
        Me.cbR.Size = New System.Drawing.Size(41, 17)
        Me.cbR.TabIndex = 9
        Me.cbR.Text = "RP"
        Me.cbR.UseVisualStyleBackColor = True
        '
        'Pl
        '
        Me.Pl.AutoScroll = True
        Me.Pl.BackColor = System.Drawing.Color.Gainsboro
        Me.Pl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Pl.Controls.Add(Me.Pb)
        Me.Pl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pl.Location = New System.Drawing.Point(857, 0)
        Me.Pl.Name = "Pl"
        Me.Pl.Size = New System.Drawing.Size(186, 455)
        Me.Pl.TabIndex = 15
        '
        'Pb
        '
        Me.Pb.BackColor = System.Drawing.Color.White
        Me.Pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pb.Cursor = System.Windows.Forms.Cursors.Default
        Me.Pb.Location = New System.Drawing.Point(6, 5)
        Me.Pb.Name = "Pb"
        Me.Pb.Size = New System.Drawing.Size(300, 331)
        Me.Pb.TabIndex = 1
        Me.Pb.TabStop = False
        '
        'txtWel
        '
        Me.txtWel.BackColor = System.Drawing.Color.White
        Me.txtWel.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtWel.IsNumiric = True
        Me.txtWel.Location = New System.Drawing.Point(145, 12)
        Me.txtWel.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtWel.Name = "txtWel"
        Me.txtWel.ShowClearIcon = False
        Me.txtWel.ShowSaveIcon = False
        Me.txtWel.Size = New System.Drawing.Size(59, 30)
        Me.txtWel.StartUp = 2
        Me.txtWel.TabIndex = 6
        Me.txtWel.TextSize = 8
        Me.txtWel.TxtBackColor = True
        Me.txtWel.TxtColor = System.Drawing.Color.White
        Me.txtWel.txtReadOnly = False
        Me.txtWel.TxtSelect = New Integer() {1, 0}
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cbR)
        Me.Panel1.Controls.Add(Me.txtWel)
        Me.Panel1.Controls.Add(Me.txtNbrW)
        Me.Panel1.Controls.Add(Me.txtHel)
        Me.Panel1.Controls.Add(Me.txtEspW)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtNbrH)
        Me.Panel1.Controls.Add(Me.txtEspH)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtX)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtY)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(488, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(369, 455)
        Me.Panel1.TabIndex = 17
        '
        'txtNbrW
        '
        Me.txtNbrW.BackColor = System.Drawing.Color.White
        Me.txtNbrW.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtNbrW.IsNumiric = True
        Me.txtNbrW.Location = New System.Drawing.Point(145, 54)
        Me.txtNbrW.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtNbrW.Name = "txtNbrW"
        Me.txtNbrW.ShowClearIcon = False
        Me.txtNbrW.ShowSaveIcon = False
        Me.txtNbrW.Size = New System.Drawing.Size(59, 30)
        Me.txtNbrW.StartUp = 2
        Me.txtNbrW.TabIndex = 6
        Me.txtNbrW.TextSize = 8
        Me.txtNbrW.TxtBackColor = True
        Me.txtNbrW.TxtColor = System.Drawing.Color.White
        Me.txtNbrW.txtReadOnly = False
        Me.txtNbrW.TxtSelect = New Integer() {1, 0}
        '
        'txtHel
        '
        Me.txtHel.BackColor = System.Drawing.Color.White
        Me.txtHel.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtHel.IsNumiric = True
        Me.txtHel.Location = New System.Drawing.Point(278, 12)
        Me.txtHel.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtHel.Name = "txtHel"
        Me.txtHel.ShowClearIcon = False
        Me.txtHel.ShowSaveIcon = False
        Me.txtHel.Size = New System.Drawing.Size(59, 30)
        Me.txtHel.StartUp = 2
        Me.txtHel.TabIndex = 6
        Me.txtHel.TextSize = 8
        Me.txtHel.TxtBackColor = True
        Me.txtHel.TxtColor = System.Drawing.Color.White
        Me.txtHel.txtReadOnly = False
        Me.txtHel.TxtSelect = New Integer() {1, 0}
        '
        'txtEspW
        '
        Me.txtEspW.BackColor = System.Drawing.Color.White
        Me.txtEspW.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtEspW.IsNumiric = True
        Me.txtEspW.Location = New System.Drawing.Point(278, 54)
        Me.txtEspW.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtEspW.Name = "txtEspW"
        Me.txtEspW.ShowClearIcon = False
        Me.txtEspW.ShowSaveIcon = False
        Me.txtEspW.Size = New System.Drawing.Size(59, 30)
        Me.txtEspW.StartUp = 2
        Me.txtEspW.TabIndex = 6
        Me.txtEspW.TextSize = 8
        Me.txtEspW.TxtBackColor = True
        Me.txtEspW.TxtColor = System.Drawing.Color.White
        Me.txtEspW.txtReadOnly = False
        Me.txtEspW.TxtSelect = New Integer() {1, 0}
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "X :"
        '
        'txtNbrH
        '
        Me.txtNbrH.BackColor = System.Drawing.Color.White
        Me.txtNbrH.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtNbrH.IsNumiric = True
        Me.txtNbrH.Location = New System.Drawing.Point(145, 91)
        Me.txtNbrH.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtNbrH.Name = "txtNbrH"
        Me.txtNbrH.ShowClearIcon = False
        Me.txtNbrH.ShowSaveIcon = False
        Me.txtNbrH.Size = New System.Drawing.Size(59, 30)
        Me.txtNbrH.StartUp = 2
        Me.txtNbrH.TabIndex = 6
        Me.txtNbrH.TextSize = 8
        Me.txtNbrH.TxtBackColor = True
        Me.txtNbrH.TxtColor = System.Drawing.Color.White
        Me.txtNbrH.txtReadOnly = False
        Me.txtNbrH.TxtSelect = New Integer() {1, 0}
        '
        'txtEspH
        '
        Me.txtEspH.BackColor = System.Drawing.Color.White
        Me.txtEspH.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtEspH.IsNumiric = True
        Me.txtEspH.Location = New System.Drawing.Point(278, 91)
        Me.txtEspH.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtEspH.Name = "txtEspH"
        Me.txtEspH.ShowClearIcon = False
        Me.txtEspH.ShowSaveIcon = False
        Me.txtEspH.Size = New System.Drawing.Size(59, 30)
        Me.txtEspH.StartUp = 2
        Me.txtEspH.TabIndex = 6
        Me.txtEspH.TextSize = 8
        Me.txtEspH.TxtBackColor = True
        Me.txtEspH.TxtColor = System.Drawing.Color.White
        Me.txtEspH.txtReadOnly = False
        Me.txtEspH.TxtSelect = New Integer() {1, 0}
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(234, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Largeur :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Y :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(104, 60)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 13)
        Me.Label16.TabIndex = 5
        Me.Label16.Text = "Nbr W :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(96, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Longeur :"
        '
        'txtX
        '
        Me.txtX.BackColor = System.Drawing.Color.White
        Me.txtX.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtX.IsNumiric = True
        Me.txtX.Location = New System.Drawing.Point(31, 54)
        Me.txtX.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtX.Name = "txtX"
        Me.txtX.ShowClearIcon = False
        Me.txtX.ShowSaveIcon = False
        Me.txtX.Size = New System.Drawing.Size(53, 30)
        Me.txtX.StartUp = 2
        Me.txtX.TabIndex = 6
        Me.txtX.TextSize = 8
        Me.txtX.TxtBackColor = True
        Me.txtX.TxtColor = System.Drawing.Color.White
        Me.txtX.txtReadOnly = False
        Me.txtX.TxtSelect = New Integer() {1, 0}
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(234, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Esp W :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(104, 97)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(44, 13)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Nbr  H :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(234, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Esp H :"
        '
        'txtY
        '
        Me.txtY.BackColor = System.Drawing.Color.White
        Me.txtY.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtY.IsNumiric = True
        Me.txtY.Location = New System.Drawing.Point(31, 91)
        Me.txtY.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtY.Name = "txtY"
        Me.txtY.ShowClearIcon = False
        Me.txtY.ShowSaveIcon = False
        Me.txtY.Size = New System.Drawing.Size(53, 30)
        Me.txtY.StartUp = 2
        Me.txtY.TabIndex = 6
        Me.txtY.TextSize = 8
        Me.txtY.TxtBackColor = True
        Me.txtY.TxtColor = System.Drawing.Color.White
        Me.txtY.txtReadOnly = False
        Me.txtY.TxtSelect = New Integer() {1, 0}
        '
        'Column1
        '
        Me.Column1.HeaderText = "Designation"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(162, 20)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(58, 30)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "+"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BackColor = System.Drawing.Color.Snow
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Controls.Add(Me.dgvCats)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(244, 455)
        Me.Panel2.TabIndex = 14
        '
        'dgvCats
        '
        Me.dgvCats.AllowUserToAddRows = False
        Me.dgvCats.AllowUserToDeleteRows = False
        Me.dgvCats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCats.BackgroundColor = System.Drawing.Color.Snow
        Me.dgvCats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCats.ColumnHeadersVisible = False
        Me.dgvCats.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.dgvCats.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvCats.EnableHeadersVisualStyles = False
        Me.dgvCats.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvCats.Location = New System.Drawing.Point(0, 98)
        Me.dgvCats.Name = "dgvCats"
        Me.dgvCats.ReadOnly = True
        Me.dgvCats.RowHeadersVisible = False
        Me.dgvCats.RowTemplate.Height = 44
        Me.dgvCats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCats.Size = New System.Drawing.Size(242, 355)
        Me.dgvCats.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CATALOGUES"
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.Black
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.ForeColor = System.Drawing.SystemColors.Control
        Me.Button10.Image = Global.Al_Mohasib.My.Resources.Resources.Print_22X22
        Me.Button10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button10.Location = New System.Drawing.Point(200, 4)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(70, 34)
        Me.Button10.TabIndex = 9
        Me.Button10.Text = "PRN"
        Me.Button10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button10.UseVisualStyleBackColor = False
        '
        'Txt_H
        '
        Me.Txt_H.BackColor = System.Drawing.Color.Transparent
        Me.Txt_H.BorderColor = System.Drawing.SystemColors.ControlText
        Me.Txt_H.IsNumiric = False
        Me.Txt_H.Location = New System.Drawing.Point(66, 6)
        Me.Txt_H.MinimumSize = New System.Drawing.Size(0, 30)
        Me.Txt_H.Name = "Txt_H"
        Me.Txt_H.ShowClearIcon = False
        Me.Txt_H.ShowSaveIcon = False
        Me.Txt_H.Size = New System.Drawing.Size(48, 30)
        Me.Txt_H.StartUp = 2
        Me.Txt_H.TabIndex = 9
        Me.Txt_H.TextSize = 8
        Me.Txt_H.TxtBackColor = True
        Me.Txt_H.TxtColor = System.Drawing.Color.White
        Me.Txt_H.txtReadOnly = False
        Me.Txt_H.TxtSelect = New Integer() {1, 0}
        '
        'Txt_W
        '
        Me.Txt_W.BackColor = System.Drawing.Color.Transparent
        Me.Txt_W.BorderColor = System.Drawing.SystemColors.ControlText
        Me.Txt_W.IsNumiric = False
        Me.Txt_W.Location = New System.Drawing.Point(12, 6)
        Me.Txt_W.MinimumSize = New System.Drawing.Size(0, 30)
        Me.Txt_W.Name = "Txt_W"
        Me.Txt_W.ShowClearIcon = False
        Me.Txt_W.ShowSaveIcon = False
        Me.Txt_W.Size = New System.Drawing.Size(48, 30)
        Me.Txt_W.StartUp = 2
        Me.Txt_W.TabIndex = 10
        Me.Txt_W.TextSize = 8
        Me.Txt_W.TxtBackColor = True
        Me.Txt_W.TxtColor = System.Drawing.Color.White
        Me.Txt_W.txtReadOnly = False
        Me.Txt_W.TxtSelect = New Integer() {1, 0}
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button6.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.SAVE_20
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button6.Location = New System.Drawing.Point(688, 3)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(43, 36)
        Me.Button6.TabIndex = 8
        Me.Button6.UseVisualStyleBackColor = True
        '
        'btLand
        '
        Me.btLand.BackColor = System.Drawing.Color.Transparent
        Me.btLand.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.FACTURE_20
        Me.btLand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btLand.FlatAppearance.BorderSize = 0
        Me.btLand.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btLand.Location = New System.Drawing.Point(115, 5)
        Me.btLand.Name = "btLand"
        Me.btLand.Size = New System.Drawing.Size(29, 36)
        Me.btLand.TabIndex = 5
        Me.btLand.UseVisualStyleBackColor = False
        '
        'PlCommande
        '
        Me.PlCommande.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.PlCommande.Controls.Add(Me.Button10)
        Me.PlCommande.Controls.Add(Me.Txt_H)
        Me.PlCommande.Controls.Add(Me.Txt_W)
        Me.PlCommande.Controls.Add(Me.Button6)
        Me.PlCommande.Controls.Add(Me.btLand)
        Me.PlCommande.Controls.Add(Me.Button7)
        Me.PlCommande.Controls.Add(Me.Button8)
        Me.PlCommande.Controls.Add(Me.btImprimer)
        Me.PlCommande.Controls.Add(Me.lb)
        Me.PlCommande.Controls.Add(Me.Label14)
        Me.PlCommande.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PlCommande.Location = New System.Drawing.Point(0, 455)
        Me.PlCommande.Name = "PlCommande"
        Me.PlCommande.Size = New System.Drawing.Size(1043, 42)
        Me.PlCommande.TabIndex = 16
        '
        'Button7
        '
        Me.Button7.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.iconfinder_Folder_Settings_Tools_icon_88583_X_24
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button7.Location = New System.Drawing.Point(150, 4)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(44, 36)
        Me.Button7.TabIndex = 6
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button8.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.AVOIR_22
        Me.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button8.Location = New System.Drawing.Point(617, 3)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(44, 36)
        Me.Button8.TabIndex = 7
        Me.Button8.UseVisualStyleBackColor = True
        '
        'btImprimer
        '
        Me.btImprimer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btImprimer.BackColor = System.Drawing.Color.Lime
        Me.btImprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btImprimer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btImprimer.ForeColor = System.Drawing.Color.Indigo
        Me.btImprimer.Location = New System.Drawing.Point(725, 3)
        Me.btImprimer.Name = "btImprimer"
        Me.btImprimer.Size = New System.Drawing.Size(294, 32)
        Me.btImprimer.TabIndex = 4
        Me.btImprimer.Text = "Enregistrer"
        Me.btImprimer.UseVisualStyleBackColor = False
        '
        'lb
        '
        Me.lb.AutoSize = True
        Me.lb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb.ForeColor = System.Drawing.Color.SaddleBrown
        Me.lb.Location = New System.Drawing.Point(415, 15)
        Me.lb.Name = "lb"
        Me.lb.Size = New System.Drawing.Size(19, 13)
        Me.lb.TabIndex = 0
        Me.lb.Text = """"""
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.SaddleBrown
        Me.Label14.Location = New System.Drawing.Point(292, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(117, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Mode Selectionné :"
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Controls.Add(Me.dgvPages)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(244, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(244, 455)
        Me.Panel3.TabIndex = 18
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(159, 21)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(58, 30)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "+"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'dgvPages
        '
        Me.dgvPages.AllowUserToAddRows = False
        Me.dgvPages.AllowUserToDeleteRows = False
        Me.dgvPages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPages.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvPages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPages.ColumnHeadersVisible = False
        Me.dgvPages.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1})
        Me.dgvPages.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvPages.EnableHeadersVisualStyles = False
        Me.dgvPages.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvPages.Location = New System.Drawing.Point(0, 99)
        Me.dgvPages.Name = "dgvPages"
        Me.dgvPages.ReadOnly = True
        Me.dgvPages.RowHeadersVisible = False
        Me.dgvPages.RowTemplate.Height = 44
        Me.dgvPages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPages.Size = New System.Drawing.Size(242, 354)
        Me.dgvPages.TabIndex = 3
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Designation"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(21, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "PAGES"
        '
        'CatSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1043, 497)
        Me.Controls.Add(Me.Pl)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PlCommande)
        Me.Name = "CatSetting"
        Me.Text = "CatSetting"
        Me.Pl.ResumeLayout(False)
        CType(Me.Pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvCats, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PlCommande.ResumeLayout(False)
        Me.PlCommande.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dgvPages, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbR As System.Windows.Forms.CheckBox
    Friend WithEvents Pl As System.Windows.Forms.Panel
    Friend WithEvents Pb As System.Windows.Forms.PictureBox
    Friend WithEvents txtWel As Al_Mohasib.TxtBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtNbrW As Al_Mohasib.TxtBox
    Friend WithEvents txtHel As Al_Mohasib.TxtBox
    Friend WithEvents txtEspW As Al_Mohasib.TxtBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNbrH As Al_Mohasib.TxtBox
    Friend WithEvents txtEspH As Al_Mohasib.TxtBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtX As Al_Mohasib.TxtBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtY As Al_Mohasib.TxtBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgvCats As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Txt_H As Al_Mohasib.TxtBox
    Friend WithEvents Txt_W As Al_Mohasib.TxtBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents btLand As System.Windows.Forms.Button
    Friend WithEvents PlCommande As System.Windows.Forms.Panel
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents btImprimer As System.Windows.Forms.Button
    Friend WithEvents lb As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents dgvPages As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
