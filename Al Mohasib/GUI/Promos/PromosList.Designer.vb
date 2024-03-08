<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PromosList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PromosList))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lb = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.bt = New System.Windows.Forms.Button()
        Me.Button45 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CbIsAuto = New System.Windows.Forms.CheckBox()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.cbB = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.txtEcheance = New Al_Mohasib.TxtBox()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtName = New Al_Mohasib.TxtBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txtDesc = New Al_Mohasib.TxtBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(429, 608)
        Me.Panel2.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.InactiveBorder
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ColumnHeadersVisible = False
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 44
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(429, 608)
        Me.DataGridView1.TabIndex = 8
        '
        'Column1
        '
        Me.Column1.HeaderText = "Designation"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.lb)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.Button45)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(429, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(495, 608)
        Me.Panel1.TabIndex = 2
        '
        'lb
        '
        Me.lb.Font = New System.Drawing.Font("Century Gothic", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb.ForeColor = System.Drawing.Color.Green
        Me.lb.Location = New System.Drawing.Point(237, 26)
        Me.lb.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb.Name = "lb"
        Me.lb.Size = New System.Drawing.Size(161, 36)
        Me.lb.TabIndex = 9
        Me.lb.Text = "Promos"
        Me.lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel6
        '
        Me.Panel6.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.WhatsApp_Image_2021_06_02_at_13_13_57__1_
        Me.Panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel6.Controls.Add(Me.Button2)
        Me.Panel6.Controls.Add(Me.bt)
        Me.Panel6.Location = New System.Drawing.Point(7, 521)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(480, 73)
        Me.Panel6.TabIndex = 14
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.iconfinder_folder_delete_61770
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.Location = New System.Drawing.Point(60, 11)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(59, 53)
        Me.Button2.TabIndex = 14
        Me.Button2.UseVisualStyleBackColor = True
        '
        'bt
        '
        Me.bt.BackColor = System.Drawing.Color.Gainsboro
        Me.bt.Enabled = False
        Me.bt.FlatAppearance.BorderSize = 0
        Me.bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt.ForeColor = System.Drawing.Color.Maroon
        Me.bt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt.Location = New System.Drawing.Point(147, 11)
        Me.bt.Margin = New System.Windows.Forms.Padding(4)
        Me.bt.Name = "bt"
        Me.bt.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.bt.Size = New System.Drawing.Size(272, 53)
        Me.bt.TabIndex = 13
        Me.bt.Text = "Enregistrer / Modifier"
        Me.bt.UseVisualStyleBackColor = False
        '
        'Button45
        '
        Me.Button45.BackColor = System.Drawing.Color.Transparent
        Me.Button45.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.newprd
        Me.Button45.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button45.FlatAppearance.BorderSize = 0
        Me.Button45.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button45.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button45.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button45.Location = New System.Drawing.Point(7, 11)
        Me.Button45.Margin = New System.Windows.Forms.Padding(0)
        Me.Button45.Name = "Button45"
        Me.Button45.Size = New System.Drawing.Size(119, 79)
        Me.Button45.TabIndex = 25
        Me.Button45.Text = " جديد"
        Me.Button45.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button45.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.WhatsApp_Image_2021_06_02_at_13_13_57__1_
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.CbIsAuto)
        Me.Panel3.Controls.Add(Me.Panel15)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Panel8)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Location = New System.Drawing.Point(7, 95)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(480, 421)
        Me.Panel3.TabIndex = 14
        '
        'CbIsAuto
        '
        Me.CbIsAuto.AutoSize = True
        Me.CbIsAuto.Location = New System.Drawing.Point(67, 352)
        Me.CbIsAuto.Margin = New System.Windows.Forms.Padding(4)
        Me.CbIsAuto.Name = "CbIsAuto"
        Me.CbIsAuto.Size = New System.Drawing.Size(59, 21)
        Me.CbIsAuto.TabIndex = 10
        Me.CbIsAuto.Text = "Auto"
        Me.CbIsAuto.UseVisualStyleBackColor = True
        Me.CbIsAuto.Visible = False
        '
        'Panel15
        '
        Me.Panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel15.Controls.Add(Me.cbB)
        Me.Panel15.Location = New System.Drawing.Point(64, 223)
        Me.Panel15.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(355, 38)
        Me.Panel15.TabIndex = 8
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
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(64, 41)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 36)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Nom"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel8
        '
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.txtEcheance)
        Me.Panel8.Controls.Add(Me.Button14)
        Me.Panel8.Location = New System.Drawing.Point(64, 153)
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
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.txtName)
        Me.Panel4.Location = New System.Drawing.Point(64, 79)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(357, 38)
        Me.Panel4.TabIndex = 7
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.Transparent
        Me.txtName.BorderColor = System.Drawing.Color.Transparent
        Me.txtName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtName.IsNumiric = False
        Me.txtName.Location = New System.Drawing.Point(0, 0)
        Me.txtName.Margin = New System.Windows.Forms.Padding(5)
        Me.txtName.MinimumSize = New System.Drawing.Size(0, 37)
        Me.txtName.Name = "txtName"
        Me.txtName.ShowClearIcon = False
        Me.txtName.ShowSaveIcon = False
        Me.txtName.Size = New System.Drawing.Size(355, 37)
        Me.txtName.StartUp = 2
        Me.txtName.TabIndex = 6
        Me.txtName.TextSize = 8
        Me.txtName.TxtBackColor = True
        Me.txtName.TxtColor = System.Drawing.Color.White
        Me.txtName.txtReadOnly = False
        Me.txtName.TxtSelect = New Integer() {1, 0}
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(64, 262)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 36)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Desc"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.txtDesc)
        Me.Panel5.Location = New System.Drawing.Point(64, 298)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(357, 38)
        Me.Panel5.TabIndex = 7
        '
        'txtDesc
        '
        Me.txtDesc.BackColor = System.Drawing.Color.Transparent
        Me.txtDesc.BorderColor = System.Drawing.Color.Transparent
        Me.txtDesc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDesc.IsNumiric = False
        Me.txtDesc.Location = New System.Drawing.Point(0, 0)
        Me.txtDesc.Margin = New System.Windows.Forms.Padding(5)
        Me.txtDesc.MinimumSize = New System.Drawing.Size(0, 37)
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.ShowClearIcon = False
        Me.txtDesc.ShowSaveIcon = False
        Me.txtDesc.Size = New System.Drawing.Size(355, 37)
        Me.txtDesc.StartUp = 2
        Me.txtDesc.TabIndex = 6
        Me.txtDesc.TextSize = 8
        Me.txtDesc.TxtBackColor = True
        Me.txtDesc.TxtColor = System.Drawing.Color.White
        Me.txtDesc.txtReadOnly = False
        Me.txtDesc.TxtSelect = New Integer() {1, 0}
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(69, 191)
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
        Me.Label4.Location = New System.Drawing.Point(64, 121)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 36)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Echeance"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PromosList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(924, 608)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PromosList"
        Me.Text = "Liste"
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel15.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents bt As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents txtEcheance As Al_Mohasib.TxtBox
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents txtName As Al_Mohasib.TxtBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents txtDesc As Al_Mohasib.TxtBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel15 As System.Windows.Forms.Panel
    Friend WithEvents cbB As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button45 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lb As System.Windows.Forms.Label
    Friend WithEvents CbIsAuto As System.Windows.Forms.CheckBox
End Class
