<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddEditPromos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddEditPromos))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.cbB = New System.Windows.Forms.ComboBox()
        Me.btRelveClientArch = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TxtBox2 = New Al_Mohasib.TxtBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TxtBox1 = New Al_Mohasib.TxtBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.txtEcheance = New Al_Mohasib.TxtBox()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.cbResult = New System.Windows.Forms.ComboBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.txtResult = New Al_Mohasib.TxtBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.txt = New Al_Mohasib.TxtBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.cbCond = New System.Windows.Forms.ComboBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Dg1 = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.lbpintName = New System.Windows.Forms.Label()
        Me.lbQ = New System.Windows.Forms.Label()
        Me.Designation = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.txtP = New Al_Mohasib.TxtBox()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.txtQ = New Al_Mohasib.TxtBox()
        Me.T = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.Dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel15)
        Me.Panel1.Controls.Add(Me.btRelveClientArch)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(420, 567)
        Me.Panel1.TabIndex = 0
        '
        'Panel15
        '
        Me.Panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel15.Controls.Add(Me.cbB)
        Me.Panel15.Location = New System.Drawing.Point(27, 236)
        Me.Panel15.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(355, 38)
        Me.Panel15.TabIndex = 14
        '
        'cbB
        '
        Me.cbB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbB.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbB.FormattingEnabled = True
        Me.cbB.Items.AddRange(New Object() {"TA - Total Achat", "TB - Total Bon", "LA - List d'Articles ", "Article_Prix", "Categories_Prix", "Article_Gratuit", "Total_Gratuit"})
        Me.cbB.Location = New System.Drawing.Point(0, 0)
        Me.cbB.Margin = New System.Windows.Forms.Padding(4)
        Me.cbB.Name = "cbB"
        Me.cbB.Size = New System.Drawing.Size(353, 28)
        Me.cbB.TabIndex = 1
        '
        'btRelveClientArch
        '
        Me.btRelveClientArch.BackColor = System.Drawing.Color.Maroon
        Me.btRelveClientArch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btRelveClientArch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btRelveClientArch.ForeColor = System.Drawing.Color.White
        Me.btRelveClientArch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btRelveClientArch.Location = New System.Drawing.Point(28, 460)
        Me.btRelveClientArch.Margin = New System.Windows.Forms.Padding(4)
        Me.btRelveClientArch.Name = "btRelveClientArch"
        Me.btRelveClientArch.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.btRelveClientArch.Size = New System.Drawing.Size(352, 53)
        Me.btRelveClientArch.TabIndex = 13
        Me.btRelveClientArch.Text = "Enregistrer"
        Me.btRelveClientArch.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(25, 33)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 36)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Nom"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(25, 278)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 36)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Desc"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 199)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 36)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Type"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(25, 119)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 36)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Echeance"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.TxtBox2)
        Me.Panel5.Location = New System.Drawing.Point(27, 318)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(357, 38)
        Me.Panel5.TabIndex = 7
        '
        'TxtBox2
        '
        Me.TxtBox2.BackColor = System.Drawing.Color.Transparent
        Me.TxtBox2.BorderColor = System.Drawing.Color.Transparent
        Me.TxtBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtBox2.IsNumiric = False
        Me.TxtBox2.Location = New System.Drawing.Point(0, 0)
        Me.TxtBox2.Margin = New System.Windows.Forms.Padding(5)
        Me.TxtBox2.MinimumSize = New System.Drawing.Size(0, 37)
        Me.TxtBox2.Name = "TxtBox2"
        Me.TxtBox2.ShowClearIcon = False
        Me.TxtBox2.ShowSaveIcon = False
        Me.TxtBox2.Size = New System.Drawing.Size(355, 37)
        Me.TxtBox2.StartUp = 2
        Me.TxtBox2.TabIndex = 6
        Me.TxtBox2.TextSize = 8
        Me.TxtBox2.TxtBackColor = True
        Me.TxtBox2.TxtColor = System.Drawing.Color.White
        Me.TxtBox2.txtReadOnly = False
        Me.TxtBox2.TxtSelect = New Integer() {1, 0}
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.TxtBox1)
        Me.Panel4.Location = New System.Drawing.Point(27, 71)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(357, 38)
        Me.Panel4.TabIndex = 7
        '
        'TxtBox1
        '
        Me.TxtBox1.BackColor = System.Drawing.Color.Transparent
        Me.TxtBox1.BorderColor = System.Drawing.Color.Transparent
        Me.TxtBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtBox1.IsNumiric = False
        Me.TxtBox1.Location = New System.Drawing.Point(0, 0)
        Me.TxtBox1.Margin = New System.Windows.Forms.Padding(5)
        Me.TxtBox1.MinimumSize = New System.Drawing.Size(0, 37)
        Me.TxtBox1.Name = "TxtBox1"
        Me.TxtBox1.ShowClearIcon = False
        Me.TxtBox1.ShowSaveIcon = False
        Me.TxtBox1.Size = New System.Drawing.Size(355, 37)
        Me.TxtBox1.StartUp = 2
        Me.TxtBox1.TabIndex = 6
        Me.TxtBox1.TextSize = 8
        Me.TxtBox1.TxtBackColor = True
        Me.TxtBox1.TxtColor = System.Drawing.Color.White
        Me.TxtBox1.txtReadOnly = False
        Me.TxtBox1.TxtSelect = New Integer() {1, 0}
        '
        'Panel8
        '
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.txtEcheance)
        Me.Panel8.Controls.Add(Me.Button14)
        Me.Panel8.Location = New System.Drawing.Point(27, 158)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(357, 38)
        Me.Panel8.TabIndex = 7
        '
        'txtEcheance
        '
        Me.txtEcheance.BackColor = System.Drawing.Color.Transparent
        Me.txtEcheance.BorderColor = System.Drawing.Color.Transparent
        Me.txtEcheance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEcheance.IsNumiric = False
        Me.txtEcheance.Location = New System.Drawing.Point(0, 0)
        Me.txtEcheance.Margin = New System.Windows.Forms.Padding(5)
        Me.txtEcheance.MinimumSize = New System.Drawing.Size(0, 37)
        Me.txtEcheance.Name = "txtEcheance"
        Me.txtEcheance.ShowClearIcon = False
        Me.txtEcheance.ShowSaveIcon = False
        Me.txtEcheance.Size = New System.Drawing.Size(308, 37)
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
        Me.Button14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button14.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button14.FlatAppearance.BorderSize = 0
        Me.Button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button14.Location = New System.Drawing.Point(308, 0)
        Me.Button14.Margin = New System.Windows.Forms.Padding(4)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(47, 36)
        Me.Button14.TabIndex = 7
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.DataGridView2)
        Me.Panel3.Controls.Add(Me.LinkLabel2)
        Me.Panel3.Controls.Add(Me.Panel7)
        Me.Panel3.Controls.Add(Me.Panel10)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1385, 567)
        Me.Panel3.TabIndex = 0
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView2.BackgroundColor = System.Drawing.SystemColors.InactiveBorder
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DataGridView2.Location = New System.Drawing.Point(0, 188)
        Me.DataGridView2.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowTemplate.Height = 33
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(1385, 379)
        Me.DataGridView2.TabIndex = 11
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "arid"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Designation"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Qte"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(29, 28)
        Me.LinkLabel2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(116, 17)
        Me.LinkLabel2.TabIndex = 9
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Ajouter Condition"
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.cbResult)
        Me.Panel7.Location = New System.Drawing.Point(33, 71)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(355, 38)
        Me.Panel7.TabIndex = 8
        '
        'cbResult
        '
        Me.cbResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbResult.FormattingEnabled = True
        Me.cbResult.Items.AddRange(New Object() {"REMISE (%)", "REMISE (DHS)", "BON D'ACHAT", "POINTS"})
        Me.cbResult.Location = New System.Drawing.Point(0, 0)
        Me.cbResult.Margin = New System.Windows.Forms.Padding(4)
        Me.cbResult.Name = "cbResult"
        Me.cbResult.Size = New System.Drawing.Size(353, 28)
        Me.cbResult.TabIndex = 1
        '
        'Panel10
        '
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.txtResult)
        Me.Panel10.Location = New System.Drawing.Point(35, 117)
        Me.Panel10.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(357, 38)
        Me.Panel10.TabIndex = 7
        '
        'txtResult
        '
        Me.txtResult.BackColor = System.Drawing.Color.Transparent
        Me.txtResult.BorderColor = System.Drawing.Color.Transparent
        Me.txtResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtResult.IsNumiric = False
        Me.txtResult.Location = New System.Drawing.Point(0, 0)
        Me.txtResult.Margin = New System.Windows.Forms.Padding(5)
        Me.txtResult.MinimumSize = New System.Drawing.Size(0, 37)
        Me.txtResult.Name = "txtResult"
        Me.txtResult.ShowClearIcon = False
        Me.txtResult.ShowSaveIcon = False
        Me.txtResult.Size = New System.Drawing.Size(355, 37)
        Me.txtResult.StartUp = 2
        Me.txtResult.TabIndex = 6
        Me.txtResult.TextSize = 8
        Me.txtResult.TxtBackColor = True
        Me.txtResult.TxtColor = System.Drawing.Color.White
        Me.txtResult.txtReadOnly = False
        Me.txtResult.TxtSelect = New Integer() {1, 0}
        '
        'Panel9
        '
        Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel9.Controls.Add(Me.txt)
        Me.Panel9.Location = New System.Drawing.Point(156, 101)
        Me.Panel9.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(354, 38)
        Me.Panel9.TabIndex = 7
        '
        'txt
        '
        Me.txt.BackColor = System.Drawing.Color.Transparent
        Me.txt.BorderColor = System.Drawing.Color.Transparent
        Me.txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt.IsNumiric = False
        Me.txt.Location = New System.Drawing.Point(0, 0)
        Me.txt.Margin = New System.Windows.Forms.Padding(5)
        Me.txt.MinimumSize = New System.Drawing.Size(0, 37)
        Me.txt.Name = "txt"
        Me.txt.ShowClearIcon = False
        Me.txt.ShowSaveIcon = False
        Me.txt.Size = New System.Drawing.Size(352, 37)
        Me.txt.StartUp = 2
        Me.txt.TabIndex = 6
        Me.txt.TextSize = 8
        Me.txt.TxtBackColor = True
        Me.txt.TxtColor = System.Drawing.Color.White
        Me.txt.txtReadOnly = False
        Me.txt.TxtSelect = New Integer() {1, 0}
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.cbCond)
        Me.Panel6.Location = New System.Drawing.Point(25, 101)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(123, 38)
        Me.Panel6.TabIndex = 8
        '
        'cbCond
        '
        Me.cbCond.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbCond.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCond.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbCond.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCond.FormattingEnabled = True
        Me.cbCond.Items.AddRange(New Object() {"Article", "Categorie", "Total"})
        Me.cbCond.Location = New System.Drawing.Point(0, 0)
        Me.cbCond.Margin = New System.Windows.Forms.Padding(4)
        Me.cbCond.Name = "cbCond"
        Me.cbCond.Size = New System.Drawing.Size(121, 28)
        Me.cbCond.TabIndex = 1
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(21, 33)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(116, 17)
        Me.LinkLabel1.TabIndex = 0
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Ajouter Condition"
        '
        'Dg1
        '
        Me.Dg1.AllowUserToAddRows = False
        Me.Dg1.AllowUserToDeleteRows = False
        Me.Dg1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dg1.BackgroundColor = System.Drawing.SystemColors.InactiveBorder
        Me.Dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dg1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.T, Me.arid, Me.Column1, Me.Column2, Me.Column3})
        Me.Dg1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Dg1.Location = New System.Drawing.Point(0, 188)
        Me.Dg1.Margin = New System.Windows.Forms.Padding(4)
        Me.Dg1.Name = "Dg1"
        Me.Dg1.ReadOnly = True
        Me.Dg1.RowHeadersVisible = False
        Me.Dg1.RowTemplate.Height = 33
        Me.Dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dg1.Size = New System.Drawing.Size(965, 379)
        Me.Dg1.TabIndex = 8
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Dg1)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.LinkLabel3)
        Me.Panel2.Controls.Add(Me.LinkLabel1)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.lbpintName)
        Me.Panel2.Controls.Add(Me.lbQ)
        Me.Panel2.Controls.Add(Me.Designation)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Panel12)
        Me.Panel2.Controls.Add(Me.Panel11)
        Me.Panel2.Controls.Add(Me.Panel9)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(420, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(965, 567)
        Me.Panel2.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Maroon
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(721, 101)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.Button1.Size = New System.Drawing.Size(129, 38)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Valider"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(704, 159)
        Me.LinkLabel3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(148, 17)
        Me.LinkLabel3.TabIndex = 0
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Supprimer la selection"
        '
        'lbpintName
        '
        Me.lbpintName.AutoSize = True
        Me.lbpintName.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbpintName.Location = New System.Drawing.Point(616, 75)
        Me.lbpintName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbpintName.Name = "lbpintName"
        Me.lbpintName.Size = New System.Drawing.Size(41, 17)
        Me.lbpintName.TabIndex = 9
        Me.lbpintName.Text = "Point"
        Me.lbpintName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbQ
        '
        Me.lbQ.AutoSize = True
        Me.lbQ.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQ.Location = New System.Drawing.Point(515, 75)
        Me.lbQ.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbQ.Name = "lbQ"
        Me.lbQ.Size = New System.Drawing.Size(62, 17)
        Me.lbQ.TabIndex = 9
        Me.lbQ.Text = "Qte Min"
        Me.lbQ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Designation
        '
        Me.Designation.AutoSize = True
        Me.Designation.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Designation.Location = New System.Drawing.Point(153, 75)
        Me.Designation.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Designation.Name = "Designation"
        Me.Designation.Size = New System.Drawing.Size(88, 17)
        Me.Designation.TabIndex = 9
        Me.Designation.Text = "Designation"
        Me.Designation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 75)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 17)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Type"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel12
        '
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.txtP)
        Me.Panel12.Location = New System.Drawing.Point(619, 101)
        Me.Panel12.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(93, 38)
        Me.Panel12.TabIndex = 7
        '
        'txtP
        '
        Me.txtP.BackColor = System.Drawing.Color.Transparent
        Me.txtP.BorderColor = System.Drawing.Color.Transparent
        Me.txtP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtP.IsNumiric = True
        Me.txtP.Location = New System.Drawing.Point(0, 0)
        Me.txtP.Margin = New System.Windows.Forms.Padding(5)
        Me.txtP.MinimumSize = New System.Drawing.Size(0, 37)
        Me.txtP.Name = "txtP"
        Me.txtP.ShowClearIcon = False
        Me.txtP.ShowSaveIcon = False
        Me.txtP.Size = New System.Drawing.Size(91, 37)
        Me.txtP.StartUp = 2
        Me.txtP.TabIndex = 6
        Me.txtP.TextSize = 8
        Me.txtP.TxtBackColor = True
        Me.txtP.TxtColor = System.Drawing.Color.White
        Me.txtP.txtReadOnly = False
        Me.txtP.TxtSelect = New Integer() {1, 0}
        '
        'Panel11
        '
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.txtQ)
        Me.Panel11.Location = New System.Drawing.Point(517, 101)
        Me.Panel11.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(93, 38)
        Me.Panel11.TabIndex = 7
        '
        'txtQ
        '
        Me.txtQ.BackColor = System.Drawing.Color.Transparent
        Me.txtQ.BorderColor = System.Drawing.Color.Transparent
        Me.txtQ.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtQ.IsNumiric = True
        Me.txtQ.Location = New System.Drawing.Point(0, 0)
        Me.txtQ.Margin = New System.Windows.Forms.Padding(5)
        Me.txtQ.MinimumSize = New System.Drawing.Size(0, 37)
        Me.txtQ.Name = "txtQ"
        Me.txtQ.ShowClearIcon = False
        Me.txtQ.ShowSaveIcon = False
        Me.txtQ.Size = New System.Drawing.Size(91, 37)
        Me.txtQ.StartUp = 2
        Me.txtQ.TabIndex = 6
        Me.txtQ.TextSize = 8
        Me.txtQ.TxtBackColor = True
        Me.txtQ.TxtColor = System.Drawing.Color.White
        Me.txtQ.txtReadOnly = False
        Me.txtQ.TxtSelect = New Integer() {1, 0}
        '
        'T
        '
        Me.T.FillWeight = 30.0!
        Me.T.HeaderText = "T"
        Me.T.Name = "T"
        Me.T.ReadOnly = True
        '
        'arid
        '
        Me.arid.FillWeight = 20.0!
        Me.arid.HeaderText = "arid"
        Me.arid.Name = "arid"
        Me.arid.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.FillWeight = 99.49239!
        Me.Column1.HeaderText = "Designation"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.FillWeight = 30.0!
        Me.Column2.HeaderText = "Qte Min"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.FillWeight = 30.0!
        Me.Column3.HeaderText = "Point"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'AddEditPromos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1385, 567)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "AddEditPromos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Promos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel15.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        CType(Me.Dg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents TxtBox1 As Al_Mohasib.TxtBox
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents txtEcheance As Al_Mohasib.TxtBox
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents TxtBox2 As Al_Mohasib.TxtBox
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents cbResult As System.Windows.Forms.ComboBox
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents txtResult As Al_Mohasib.TxtBox
    Friend WithEvents btRelveClientArch As System.Windows.Forms.Button
    Friend WithEvents Panel15 As System.Windows.Forms.Panel
    Friend WithEvents cbB As System.Windows.Forms.ComboBox
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents txt As Al_Mohasib.TxtBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents cbCond As System.Windows.Forms.ComboBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lbpintName As System.Windows.Forms.Label
    Friend WithEvents lbQ As System.Windows.Forms.Label
    Friend WithEvents Designation As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents txtP As Al_Mohasib.TxtBox
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents txtQ As Al_Mohasib.TxtBox
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents T As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents arid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
