<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Devis
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PlRcpt = New System.Windows.Forms.Panel()
        Me.RPl = New Al_Mohasib.RPanel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.plrightA = New System.Windows.Forms.Panel()
        Me.plright = New System.Windows.Forms.Panel()
        Me.btswitsh = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PrintDoc = New System.Drawing.Printing.PrintDocument()
        Me.PlArchive = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.PlMachine = New System.Windows.Forms.Panel()
        Me.CBPRICE = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.ShapeContainer3 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.BtGroupes = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button42 = New System.Windows.Forms.Button()
        Me.Button41 = New System.Windows.Forms.Button()
        Me.txtartsearch = New System.Windows.Forms.TextBox()
        Me.PlRcpt.SuspendLayout()
        Me.plrightA.SuspendLayout()
        Me.PlArchive.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.PlMachine.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'PlRcpt
        '
        Me.PlRcpt.BackColor = System.Drawing.Color.White
        Me.PlRcpt.Controls.Add(Me.RPl)
        Me.PlRcpt.Controls.Add(Me.Panel12)
        Me.PlRcpt.Dock = System.Windows.Forms.DockStyle.Left
        Me.PlRcpt.Location = New System.Drawing.Point(0, 0)
        Me.PlRcpt.Name = "PlRcpt"
        Me.PlRcpt.Padding = New System.Windows.Forms.Padding(10, 0, 10, 5)
        Me.PlRcpt.Size = New System.Drawing.Size(360, 647)
        Me.PlRcpt.TabIndex = 4
        '
        'RPl
        '
        Me.RPl.Avance = New Decimal(New Integer() {0, 0, 0, 0})
        Me.RPl.bl = "---"
        Me.RPl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RPl.delivredDay = Nothing
        Me.RPl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RPl.EditMode = False
        Me.RPl.hasManyRemise = False
        Me.RPl.hideClc = True
        Me.RPl.Location = New System.Drawing.Point(10, 30)
        Me.RPl.Name = "RPl"
        Me.RPl.Num = 0
        Me.RPl.Remise = "0"
        Me.RPl.ShowClc = True
        Me.RPl.ShowProfit = False
        Me.RPl.Size = New System.Drawing.Size(340, 612)
        Me.RPl.TabIndex = 0
        Me.RPl.TypePrinter = "&"
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel12.Location = New System.Drawing.Point(10, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(340, 30)
        Me.Panel12.TabIndex = 1
        '
        'plrightA
        '
        Me.plrightA.BackColor = System.Drawing.Color.Teal
        Me.plrightA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plrightA.Controls.Add(Me.plright)
        Me.plrightA.Controls.Add(Me.btswitsh)
        Me.plrightA.Controls.Add(Me.Button1)
        Me.plrightA.Dock = System.Windows.Forms.DockStyle.Top
        Me.plrightA.Location = New System.Drawing.Point(360, 0)
        Me.plrightA.Name = "plrightA"
        Me.plrightA.Padding = New System.Windows.Forms.Padding(5)
        Me.plrightA.Size = New System.Drawing.Size(772, 43)
        Me.plrightA.TabIndex = 15
        '
        'plright
        '
        Me.plright.BackColor = System.Drawing.Color.Transparent
        Me.plright.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plright.Location = New System.Drawing.Point(53, 5)
        Me.plright.Name = "plright"
        Me.plright.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.plright.Size = New System.Drawing.Size(623, 33)
        Me.plright.TabIndex = 5
        '
        'btswitsh
        '
        Me.btswitsh.BackColor = System.Drawing.Color.Teal
        Me.btswitsh.Dock = System.Windows.Forms.DockStyle.Right
        Me.btswitsh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btswitsh.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btswitsh.ForeColor = System.Drawing.Color.White
        Me.btswitsh.Location = New System.Drawing.Point(676, 5)
        Me.btswitsh.Name = "btswitsh"
        Me.btswitsh.Size = New System.Drawing.Size(91, 33)
        Me.btswitsh.TabIndex = 4
        Me.btswitsh.Tag = "1"
        Me.btswitsh.Text = "Devis"
        Me.btswitsh.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(5, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(48, 33)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "+"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'PrintDoc
        '
        '
        'PlArchive
        '
        Me.PlArchive.Controls.Add(Me.DataGridView1)
        Me.PlArchive.Controls.Add(Me.Panel1)
        Me.PlArchive.Dock = System.Windows.Forms.DockStyle.Right
        Me.PlArchive.Location = New System.Drawing.Point(816, 83)
        Me.PlArchive.Name = "PlArchive"
        Me.PlArchive.Size = New System.Drawing.Size(316, 564)
        Me.PlArchive.TabIndex = 18
        Me.PlArchive.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(1, 7, 1, 7)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(316, 510)
        Me.DataGridView1.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.HeaderText = "ID"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Nom"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Date"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 510)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(316, 54)
        Me.Panel1.TabIndex = 0
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Gainsboro
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button3.Location = New System.Drawing.Point(0, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(316, 54)
        Me.Button3.TabIndex = 4
        Me.Button3.Tag = "-1"
        Me.Button3.Text = "Masquer"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.FlowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(360, 83)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(456, 564)
        Me.FlowLayoutPanel1.TabIndex = 17
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.DimGray
        Me.Panel11.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.SEARCHART2
        Me.Panel11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel11.Controls.Add(Me.PlMachine)
        Me.Panel11.Controls.Add(Me.Panel8)
        Me.Panel11.Controls.Add(Me.BtGroupes)
        Me.Panel11.Controls.Add(Me.Label2)
        Me.Panel11.Controls.Add(Me.Button42)
        Me.Panel11.Controls.Add(Me.Button41)
        Me.Panel11.Controls.Add(Me.txtartsearch)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(360, 43)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(772, 40)
        Me.Panel11.TabIndex = 16
        '
        'PlMachine
        '
        Me.PlMachine.BackColor = System.Drawing.Color.Transparent
        Me.PlMachine.Controls.Add(Me.CBPRICE)
        Me.PlMachine.Controls.Add(Me.Panel2)
        Me.PlMachine.Controls.Add(Me.Button4)
        Me.PlMachine.Controls.Add(Me.Button2)
        Me.PlMachine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PlMachine.Location = New System.Drawing.Point(86, 0)
        Me.PlMachine.Name = "PlMachine"
        Me.PlMachine.Padding = New System.Windows.Forms.Padding(10, 3, 3, 0)
        Me.PlMachine.Size = New System.Drawing.Size(370, 40)
        Me.PlMachine.TabIndex = 6
        '
        'CBPRICE
        '
        Me.CBPRICE.AutoSize = True
        Me.CBPRICE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CBPRICE.Location = New System.Drawing.Point(112, 3)
        Me.CBPRICE.Name = "CBPRICE"
        Me.CBPRICE.Size = New System.Drawing.Size(100, 37)
        Me.CBPRICE.TabIndex = 5
        Me.CBPRICE.Text = "Imp sans prix"
        Me.CBPRICE.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(96, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(16, 37)
        Me.Panel2.TabIndex = 6
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Teal
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button4.Location = New System.Drawing.Point(212, 3)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(155, 37)
        Me.Button4.TabIndex = 4
        Me.Button4.Tag = "-1"
        Me.Button4.Text = "<PASSAGE EN BON>"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Gainsboro
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button2.Location = New System.Drawing.Point(10, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(86, 37)
        Me.Button2.TabIndex = 3
        Me.Button2.Tag = "-1"
        Me.Button2.Text = "ARCHIVE"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Transparent
        Me.Panel8.Controls.Add(Me.txtSearch)
        Me.Panel8.Controls.Add(Me.ShapeContainer3)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel8.Location = New System.Drawing.Point(456, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(316, 40)
        Me.Panel8.TabIndex = 6
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(41, 14)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(246, 15)
        Me.txtSearch.TabIndex = 5
        Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ShapeContainer3
        '
        Me.ShapeContainer3.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer3.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer3.Name = "ShapeContainer3"
        Me.ShapeContainer3.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer3.Size = New System.Drawing.Size(316, 40)
        Me.ShapeContainer3.TabIndex = 0
        Me.ShapeContainer3.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RectangleShape1.BackColor = System.Drawing.Color.White
        Me.RectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape1.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.RectangleShape1.CornerRadius = 14
        Me.RectangleShape1.Location = New System.Drawing.Point(26, 5)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(277, 31)
        '
        'BtGroupes
        '
        Me.BtGroupes.BackColor = System.Drawing.Color.Gainsboro
        Me.BtGroupes.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtGroupes.FlatAppearance.BorderSize = 0
        Me.BtGroupes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtGroupes.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtGroupes.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.BtGroupes.Location = New System.Drawing.Point(0, 0)
        Me.BtGroupes.Name = "BtGroupes"
        Me.BtGroupes.Size = New System.Drawing.Size(86, 40)
        Me.BtGroupes.TabIndex = 2
        Me.BtGroupes.Tag = "-1"
        Me.BtGroupes.Text = "GROUPES"
        Me.BtGroupes.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Miriam", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonShadow
        Me.Label2.Location = New System.Drawing.Point(1012, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(190, 14)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "للبحت عن السلعة  ( بإدخال جزء من الاسم او الرقم)"
        '
        'Button42
        '
        Me.Button42.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button42.Location = New System.Drawing.Point(1226, 8)
        Me.Button42.Name = "Button42"
        Me.Button42.Size = New System.Drawing.Size(56, 24)
        Me.Button42.TabIndex = 1
        Me.Button42.Text = "الغاء"
        Me.Button42.UseVisualStyleBackColor = True
        '
        'Button41
        '
        Me.Button41.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button41.Location = New System.Drawing.Point(1284, 9)
        Me.Button41.Name = "Button41"
        Me.Button41.Size = New System.Drawing.Size(56, 24)
        Me.Button41.TabIndex = 1
        Me.Button41.Text = "بحث"
        Me.Button41.UseVisualStyleBackColor = True
        '
        'txtartsearch
        '
        Me.txtartsearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtartsearch.Location = New System.Drawing.Point(1346, 10)
        Me.txtartsearch.Name = "txtartsearch"
        Me.txtartsearch.Size = New System.Drawing.Size(187, 20)
        Me.txtartsearch.TabIndex = 0
        '
        'Devis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1132, 647)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.PlArchive)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.plrightA)
        Me.Controls.Add(Me.PlRcpt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Devis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Devis"
        Me.PlRcpt.ResumeLayout(False)
        Me.plrightA.ResumeLayout(False)
        Me.PlArchive.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.PlMachine.ResumeLayout(False)
        Me.PlMachine.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PlRcpt As System.Windows.Forms.Panel
    Friend WithEvents RPl As Al_Mohasib.RPanel
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents plrightA As System.Windows.Forms.Panel
    Friend WithEvents plright As System.Windows.Forms.Panel
    Friend WithEvents btswitsh As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents PlMachine As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents ShapeContainer3 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents BtGroupes As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button42 As System.Windows.Forms.Button
    Friend WithEvents Button41 As System.Windows.Forms.Button
    Friend WithEvents txtartsearch As System.Windows.Forms.TextBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents PrintDoc As System.Drawing.Printing.PrintDocument
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents PlArchive As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents CBPRICE As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
