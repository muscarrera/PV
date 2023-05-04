<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InvoForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvoForm))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pl = New System.Windows.Forms.Panel()
        Me.dg_D = New System.Windows.Forms.DataGridView()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lbV1 = New System.Windows.Forms.Label()
        Me.lbT1 = New System.Windows.Forms.Label()
        Me.lbQteOut = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbQteIn = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbLnbr = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel24 = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel29 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btValid = New System.Windows.Forms.Button()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.TxtBox1 = New Al_Mohasib.TxtBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.TxtBox2 = New Al_Mohasib.TxtBox()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.TxtBox3 = New Al_Mohasib.TxtBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.cbGArt = New System.Windows.Forms.CheckBox()
        Me.cbGCat = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.txtCat = New Al_Mohasib.TxtBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.txtdp2 = New Al_Mohasib.TxtBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbDateValid = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lbDateCreation = New System.Windows.Forms.Label()
        Me.lbName = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.PrintDoc2 = New System.Drawing.Printing.PrintDocument()
        Me.Panel2.SuspendLayout()
        Me.pl.SuspendLayout()
        CType(Me.dg_D, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel24.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.pl)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel2.Size = New System.Drawing.Size(1036, 532)
        Me.Panel2.TabIndex = 23
        '
        'pl
        '
        Me.pl.AutoScroll = True
        Me.pl.BackColor = System.Drawing.Color.Transparent
        Me.pl.Controls.Add(Me.dg_D)
        Me.pl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pl.Location = New System.Drawing.Point(5, 194)
        Me.pl.Name = "pl"
        Me.pl.Padding = New System.Windows.Forms.Padding(5)
        Me.pl.Size = New System.Drawing.Size(1026, 280)
        Me.pl.TabIndex = 12
        '
        'dg_D
        '
        Me.dg_D.AllowUserToAddRows = False
        Me.dg_D.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dg_D.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dg_D.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dg_D.BackgroundColor = System.Drawing.Color.White
        Me.dg_D.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_D.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_D.GridColor = System.Drawing.SystemColors.HotTrack
        Me.dg_D.Location = New System.Drawing.Point(5, 5)
        Me.dg_D.MultiSelect = False
        Me.dg_D.Name = "dg_D"
        Me.dg_D.ReadOnly = True
        Me.dg_D.RowHeadersVisible = False
        Me.dg_D.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dg_D.RowTemplate.Height = 30
        Me.dg_D.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_D.Size = New System.Drawing.Size(1016, 270)
        Me.dg_D.TabIndex = 16
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel6.Controls.Add(Me.Panel1)
        Me.Panel6.Controls.Add(Me.Panel4)
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(5, 474)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1026, 53)
        Me.Panel6.TabIndex = 14
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Panel13)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1026, 14)
        Me.Panel1.TabIndex = 15
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel13.Location = New System.Drawing.Point(0, 0)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(1026, 2)
        Me.Panel13.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Controls.Add(Me.lbV1)
        Me.Panel4.Controls.Add(Me.lbT1)
        Me.Panel4.Controls.Add(Me.lbQteOut)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.lbQteIn)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.lbLnbr)
        Me.Panel4.Controls.Add(Me.Label14)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 16)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1026, 37)
        Me.Panel4.TabIndex = 14
        '
        'lbV1
        '
        Me.lbV1.BackColor = System.Drawing.Color.LightGray
        Me.lbV1.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbV1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbV1.Location = New System.Drawing.Point(760, 2)
        Me.lbV1.Name = "lbV1"
        Me.lbV1.Padding = New System.Windows.Forms.Padding(11, 0, 11, 0)
        Me.lbV1.Size = New System.Drawing.Size(150, 35)
        Me.lbV1.TabIndex = 20
        Me.lbV1.Text = "0"
        Me.lbV1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbT1
        '
        Me.lbT1.BackColor = System.Drawing.Color.Gainsboro
        Me.lbT1.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbT1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbT1.Location = New System.Drawing.Point(670, 2)
        Me.lbT1.Name = "lbT1"
        Me.lbT1.Padding = New System.Windows.Forms.Padding(11, 0, 11, 0)
        Me.lbT1.Size = New System.Drawing.Size(90, 35)
        Me.lbT1.TabIndex = 21
        Me.lbT1.Text = "Resultat"
        Me.lbT1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbQteOut
        '
        Me.lbQteOut.BackColor = System.Drawing.Color.LightGray
        Me.lbQteOut.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbQteOut.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQteOut.Location = New System.Drawing.Point(520, 2)
        Me.lbQteOut.Name = "lbQteOut"
        Me.lbQteOut.Padding = New System.Windows.Forms.Padding(11, 0, 11, 0)
        Me.lbQteOut.Size = New System.Drawing.Size(150, 35)
        Me.lbQteOut.TabIndex = 18
        Me.lbQteOut.Text = "0"
        Me.lbQteOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Gainsboro
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(430, 2)
        Me.Label7.Name = "Label7"
        Me.Label7.Padding = New System.Windows.Forms.Padding(11, 0, 11, 0)
        Me.Label7.Size = New System.Drawing.Size(90, 35)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Sortie"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbQteIn
        '
        Me.lbQteIn.BackColor = System.Drawing.Color.LightGray
        Me.lbQteIn.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbQteIn.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQteIn.Location = New System.Drawing.Point(280, 2)
        Me.lbQteIn.Name = "lbQteIn"
        Me.lbQteIn.Padding = New System.Windows.Forms.Padding(11, 0, 11, 0)
        Me.lbQteIn.Size = New System.Drawing.Size(150, 35)
        Me.lbQteIn.TabIndex = 16
        Me.lbQteIn.Text = "0"
        Me.lbQteIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Gainsboro
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(190, 2)
        Me.Label6.Name = "Label6"
        Me.Label6.Padding = New System.Windows.Forms.Padding(11, 0, 11, 0)
        Me.Label6.Size = New System.Drawing.Size(90, 35)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Entree"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbLnbr
        '
        Me.lbLnbr.BackColor = System.Drawing.Color.LightGray
        Me.lbLnbr.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbLnbr.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLnbr.Location = New System.Drawing.Point(90, 2)
        Me.lbLnbr.Name = "lbLnbr"
        Me.lbLnbr.Padding = New System.Windows.Forms.Padding(11, 0, 11, 0)
        Me.lbLnbr.Size = New System.Drawing.Size(100, 35)
        Me.lbLnbr.TabIndex = 14
        Me.lbLnbr.Text = "0"
        Me.lbLnbr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Gainsboro
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(0, 2)
        Me.Label14.Name = "Label14"
        Me.Label14.Padding = New System.Windows.Forms.Padding(11, 0, 11, 0)
        Me.Label14.Size = New System.Drawing.Size(90, 35)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Nbre :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1026, 2)
        Me.Panel5.TabIndex = 1
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1026, 2)
        Me.Panel7.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.Panel24)
        Me.Panel3.Controls.Add(Me.Panel8)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(5, 5)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(5, 5, 5, 15)
        Me.Panel3.Size = New System.Drawing.Size(1026, 189)
        Me.Panel3.TabIndex = 11
        '
        'Panel24
        '
        Me.Panel24.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel24.Controls.Add(Me.Button4)
        Me.Panel24.Controls.Add(Me.Panel29)
        Me.Panel24.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel24.Location = New System.Drawing.Point(5, 136)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Size = New System.Drawing.Size(1016, 38)
        Me.Panel24.TabIndex = 16
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Image = Global.Al_Mohasib.My.Resources.Resources.iconfinder_pdf_3745__1_
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(0, 2)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(129, 36)
        Me.Button4.TabIndex = 16
        Me.Button4.Text = "Exporter            "
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Panel29
        '
        Me.Panel29.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel29.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel29.Location = New System.Drawing.Point(0, 0)
        Me.Panel29.Name = "Panel29"
        Me.Panel29.Size = New System.Drawing.Size(1016, 2)
        Me.Panel29.TabIndex = 1
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.White
        Me.Panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel8.Controls.Add(Me.TabControl1)
        Me.Panel8.Controls.Add(Me.GroupBox1)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(5, 5)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1016, 126)
        Me.Panel8.TabIndex = 15
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.ItemSize = New System.Drawing.Size(444, 25)
        Me.TabControl1.Location = New System.Drawing.Point(331, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = New System.Drawing.Point(44, 3)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(685, 126)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button10)
        Me.TabPage1.Controls.Add(Me.Button6)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(677, 93)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Invtaires"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button10.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.Image = CType(resources.GetObject("Button10.Image"), System.Drawing.Image)
        Me.Button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button10.Location = New System.Drawing.Point(33, 35)
        Me.Button10.Name = "Button10"
        Me.Button10.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Button10.Size = New System.Drawing.Size(162, 33)
        Me.Button10.TabIndex = 2
        Me.Button10.Text = "Recherche"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button6.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(288, 35)
        Me.Button6.Name = "Button6"
        Me.Button6.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Button6.Size = New System.Drawing.Size(132, 33)
        Me.Button6.TabIndex = 2
        Me.Button6.Text = "Selection"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btValid)
        Me.TabPage2.Controls.Add(Me.Panel14)
        Me.TabPage2.Controls.Add(Me.Button7)
        Me.TabPage2.Controls.Add(Me.Panel15)
        Me.TabPage2.Controls.Add(Me.Panel16)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(677, 93)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Details"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btValid
        '
        Me.btValid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btValid.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btValid.Image = Global.Al_Mohasib.My.Resources.Resources.SAVE_20
        Me.btValid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btValid.Location = New System.Drawing.Point(556, 49)
        Me.btValid.Name = "btValid"
        Me.btValid.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.btValid.Size = New System.Drawing.Size(115, 33)
        Me.btValid.TabIndex = 9
        Me.btValid.Text = "Valider"
        Me.btValid.UseVisualStyleBackColor = True
        Me.btValid.Visible = False
        '
        'Panel14
        '
        Me.Panel14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel14.Controls.Add(Me.TxtBox1)
        Me.Panel14.Controls.Add(Me.Button5)
        Me.Panel14.Controls.Add(Me.Label9)
        Me.Panel14.Location = New System.Drawing.Point(151, 49)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(202, 32)
        Me.Panel14.TabIndex = 8
        '
        'TxtBox1
        '
        Me.TxtBox1.BackColor = System.Drawing.Color.Transparent
        Me.TxtBox1.BorderColor = System.Drawing.Color.Transparent
        Me.TxtBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtBox1.IsNumiric = False
        Me.TxtBox1.Location = New System.Drawing.Point(47, 0)
        Me.TxtBox1.MinimumSize = New System.Drawing.Size(0, 30)
        Me.TxtBox1.Name = "TxtBox1"
        Me.TxtBox1.ShowClearIcon = False
        Me.TxtBox1.ShowSaveIcon = False
        Me.TxtBox1.Size = New System.Drawing.Size(116, 30)
        Me.TxtBox1.StartUp = 2
        Me.TxtBox1.TabIndex = 12
        Me.TxtBox1.TextSize = 8
        Me.TxtBox1.TxtBackColor = True
        Me.TxtBox1.TxtColor = System.Drawing.Color.White
        Me.TxtBox1.txtReadOnly = False
        Me.TxtBox1.TxtSelect = New Integer() {1, 0}
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Transparent
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.Teal
        Me.Button5.Image = Global.Al_Mohasib.My.Resources.Resources.stock_icon_png_14
        Me.Button5.Location = New System.Drawing.Point(163, 0)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(37, 30)
        Me.Button5.TabIndex = 10
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label9.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(0, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 30)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Cat."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button7
        '
        Me.Button7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button7.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.Location = New System.Drawing.Point(556, 12)
        Me.Button7.Name = "Button7"
        Me.Button7.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Button7.Size = New System.Drawing.Size(115, 33)
        Me.Button7.TabIndex = 7
        Me.Button7.Text = "Recherche"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Panel15
        '
        Me.Panel15.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel15.Controls.Add(Me.TxtBox2)
        Me.Panel15.Controls.Add(Me.Button8)
        Me.Panel15.Controls.Add(Me.Label10)
        Me.Panel15.Location = New System.Drawing.Point(7, 11)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(456, 32)
        Me.Panel15.TabIndex = 5
        '
        'TxtBox2
        '
        Me.TxtBox2.BackColor = System.Drawing.Color.Transparent
        Me.TxtBox2.BorderColor = System.Drawing.Color.Transparent
        Me.TxtBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtBox2.IsNumiric = False
        Me.TxtBox2.Location = New System.Drawing.Point(66, 0)
        Me.TxtBox2.MinimumSize = New System.Drawing.Size(0, 30)
        Me.TxtBox2.Name = "TxtBox2"
        Me.TxtBox2.ShowClearIcon = False
        Me.TxtBox2.ShowSaveIcon = False
        Me.TxtBox2.Size = New System.Drawing.Size(357, 30)
        Me.TxtBox2.StartUp = 2
        Me.TxtBox2.TabIndex = 11
        Me.TxtBox2.TextSize = 8
        Me.TxtBox2.TxtBackColor = True
        Me.TxtBox2.TxtColor = System.Drawing.Color.White
        Me.TxtBox2.txtReadOnly = False
        Me.TxtBox2.TxtSelect = New Integer() {1, 0}
        '
        'Button8
        '
        Me.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button8.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button8.FlatAppearance.BorderSize = 0
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.Location = New System.Drawing.Point(423, 0)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(31, 30)
        Me.Button8.TabIndex = 10
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label10.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(0, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 30)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Libelle"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel16
        '
        Me.Panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel16.Controls.Add(Me.TxtBox3)
        Me.Panel16.Controls.Add(Me.Button9)
        Me.Panel16.Controls.Add(Me.Label11)
        Me.Panel16.Location = New System.Drawing.Point(7, 49)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(139, 32)
        Me.Panel16.TabIndex = 6
        '
        'TxtBox3
        '
        Me.TxtBox3.BackColor = System.Drawing.Color.Transparent
        Me.TxtBox3.BorderColor = System.Drawing.Color.Transparent
        Me.TxtBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtBox3.IsNumiric = False
        Me.TxtBox3.Location = New System.Drawing.Point(46, 0)
        Me.TxtBox3.MinimumSize = New System.Drawing.Size(0, 30)
        Me.TxtBox3.Name = "TxtBox3"
        Me.TxtBox3.ShowClearIcon = False
        Me.TxtBox3.ShowSaveIcon = False
        Me.TxtBox3.Size = New System.Drawing.Size(60, 30)
        Me.TxtBox3.StartUp = 2
        Me.TxtBox3.TabIndex = 12
        Me.TxtBox3.TextSize = 8
        Me.TxtBox3.TxtBackColor = True
        Me.TxtBox3.TxtColor = System.Drawing.Color.White
        Me.TxtBox3.txtReadOnly = False
        Me.TxtBox3.TxtSelect = New Integer() {1, 0}
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.Transparent
        Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button9.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button9.FlatAppearance.BorderSize = 0
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.ForeColor = System.Drawing.Color.Teal
        Me.Button9.Image = Global.Al_Mohasib.My.Resources.Resources.stock_icon_png_14
        Me.Button9.Location = New System.Drawing.Point(106, 0)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(31, 30)
        Me.Button9.TabIndex = 10
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label11.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(0, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 30)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Depot :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.cbGArt)
        Me.TabPage3.Controls.Add(Me.cbGCat)
        Me.TabPage3.Controls.Add(Me.Button1)
        Me.TabPage3.Controls.Add(Me.Panel12)
        Me.TabPage3.Controls.Add(Me.Panel11)
        Me.TabPage3.Location = New System.Drawing.Point(4, 29)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(677, 93)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Stock"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'cbGArt
        '
        Me.cbGArt.AutoSize = True
        Me.cbGArt.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbGArt.Location = New System.Drawing.Point(232, 56)
        Me.cbGArt.Name = "cbGArt"
        Me.cbGArt.Size = New System.Drawing.Size(152, 19)
        Me.cbGArt.TabIndex = 11
        Me.cbGArt.Text = "Grouper par Article"
        Me.cbGArt.UseVisualStyleBackColor = True
        Me.cbGArt.Visible = False
        '
        'cbGCat
        '
        Me.cbGCat.AutoSize = True
        Me.cbGCat.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbGCat.Location = New System.Drawing.Point(39, 56)
        Me.cbGCat.Name = "cbGCat"
        Me.cbGCat.Size = New System.Drawing.Size(173, 19)
        Me.cbGCat.TabIndex = 10
        Me.cbGCat.Text = "Grouper par Categorie"
        Me.cbGCat.UseVisualStyleBackColor = True
        Me.cbGCat.Visible = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(571, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Button1.Size = New System.Drawing.Size(115, 33)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Afficher"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel12
        '
        Me.Panel12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.txtCat)
        Me.Panel12.Controls.Add(Me.Button3)
        Me.Panel12.Controls.Add(Me.Label8)
        Me.Panel12.Location = New System.Drawing.Point(11, 10)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(263, 32)
        Me.Panel12.TabIndex = 7
        '
        'txtCat
        '
        Me.txtCat.BackColor = System.Drawing.Color.Transparent
        Me.txtCat.BorderColor = System.Drawing.Color.Transparent
        Me.txtCat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCat.IsNumiric = False
        Me.txtCat.Location = New System.Drawing.Point(71, 0)
        Me.txtCat.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtCat.Name = "txtCat"
        Me.txtCat.ShowClearIcon = False
        Me.txtCat.ShowSaveIcon = False
        Me.txtCat.Size = New System.Drawing.Size(153, 30)
        Me.txtCat.StartUp = 2
        Me.txtCat.TabIndex = 12
        Me.txtCat.TextSize = 8
        Me.txtCat.TxtBackColor = True
        Me.txtCat.TxtColor = System.Drawing.Color.White
        Me.txtCat.txtReadOnly = False
        Me.txtCat.TxtSelect = New Integer() {1, 0}
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Teal
        Me.Button3.Image = Global.Al_Mohasib.My.Resources.Resources.stock_icon_png_14
        Me.Button3.Location = New System.Drawing.Point(224, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(37, 30)
        Me.Button3.TabIndex = 10
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(0, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 30)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Categories"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel11
        '
        Me.Panel11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.txtdp2)
        Me.Panel11.Controls.Add(Me.Button2)
        Me.Panel11.Controls.Add(Me.Label5)
        Me.Panel11.Location = New System.Drawing.Point(290, 11)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(207, 32)
        Me.Panel11.TabIndex = 8
        '
        'txtdp2
        '
        Me.txtdp2.BackColor = System.Drawing.Color.Transparent
        Me.txtdp2.BorderColor = System.Drawing.Color.Transparent
        Me.txtdp2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtdp2.IsNumiric = False
        Me.txtdp2.Location = New System.Drawing.Point(71, 0)
        Me.txtdp2.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtdp2.Name = "txtdp2"
        Me.txtdp2.ShowClearIcon = False
        Me.txtdp2.ShowSaveIcon = False
        Me.txtdp2.Size = New System.Drawing.Size(97, 30)
        Me.txtdp2.StartUp = 2
        Me.txtdp2.TabIndex = 12
        Me.txtdp2.TextSize = 8
        Me.txtdp2.TxtBackColor = True
        Me.txtdp2.TxtColor = System.Drawing.Color.White
        Me.txtdp2.txtReadOnly = False
        Me.txtdp2.TxtSelect = New Integer() {1, 0}
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Teal
        Me.Button2.Image = Global.Al_Mohasib.My.Resources.Resources.stock_icon_png_14
        Me.Button2.Location = New System.Drawing.Point(168, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(37, 30)
        Me.Button2.TabIndex = 10
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 30)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Entrepôtes"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lbDateValid)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.lbDateCreation)
        Me.GroupBox1.Controls.Add(Me.lbName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(331, 126)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lbDateValid
        '
        Me.lbDateValid.AutoSize = True
        Me.lbDateValid.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDateValid.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbDateValid.Location = New System.Drawing.Point(131, 90)
        Me.lbDateValid.Name = "lbDateValid"
        Me.lbDateValid.Size = New System.Drawing.Size(13, 16)
        Me.lbDateValid.TabIndex = 1
        Me.lbDateValid.Text = "-"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(10, 94)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(119, 14)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "Date de Validation :"
        '
        'lbDateCreation
        '
        Me.lbDateCreation.AutoSize = True
        Me.lbDateCreation.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDateCreation.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbDateCreation.Location = New System.Drawing.Point(131, 51)
        Me.lbDateCreation.Name = "lbDateCreation"
        Me.lbDateCreation.Size = New System.Drawing.Size(13, 16)
        Me.lbDateCreation.TabIndex = 1
        Me.lbDateCreation.Text = "-"
        '
        'lbName
        '
        Me.lbName.AutoSize = True
        Me.lbName.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbName.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbName.Location = New System.Drawing.Point(131, 16)
        Me.lbName.Name = "lbName"
        Me.lbName.Size = New System.Drawing.Size(13, 16)
        Me.lbName.TabIndex = 1
        Me.lbName.Text = "-"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Date de Creation :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Designation :"
        '
        'InvoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1036, 532)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "InvoForm"
        Me.Text = "InvoForm"
        Me.Panel2.ResumeLayout(False)
        Me.pl.ResumeLayout(False)
        CType(Me.dg_D, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel24.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.Panel15.ResumeLayout(False)
        Me.Panel16.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pl As System.Windows.Forms.Panel
    Friend WithEvents dg_D As System.Windows.Forms.DataGridView
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lbV1 As System.Windows.Forms.Label
    Friend WithEvents lbT1 As System.Windows.Forms.Label
    Friend WithEvents lbQteOut As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbQteIn As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbLnbr As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel24 As System.Windows.Forms.Panel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Panel29 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents TxtBox1 As Al_Mohasib.TxtBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Panel15 As System.Windows.Forms.Panel
    Friend WithEvents TxtBox2 As Al_Mohasib.TxtBox
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents TxtBox3 As Al_Mohasib.TxtBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents cbGArt As System.Windows.Forms.CheckBox
    Friend WithEvents cbGCat As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents txtCat As Al_Mohasib.TxtBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents txtdp2 As Al_Mohasib.TxtBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbDateValid As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lbDateCreation As System.Windows.Forms.Label
    Friend WithEvents lbName As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents PrintDoc2 As System.Drawing.Printing.PrintDocument
    Friend WithEvents btValid As System.Windows.Forms.Button
End Class
