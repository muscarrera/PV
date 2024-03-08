<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Addadmin
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GB = New System.Windows.Forms.GroupBox()
        Me.lbrf = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RsAdd = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RsEdit = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RsDel = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ShapeContainer4 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape9 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.lbb = New System.Windows.Forms.Label()
        Me.txtRole = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.AdidDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AdminDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PwdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rfid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Role = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GB.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AdidDataGridViewTextBoxColumn, Me.NameDataGridViewTextBoxColumn, Me.AdminDataGridViewTextBoxColumn, Me.PwdDataGridViewTextBoxColumn, Me.rfid, Me.Role})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(735, 526)
        Me.DataGridView1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(422, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(735, 526)
        Me.Panel1.TabIndex = 1
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(51, 123)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(311, 31)
        Me.TextBox1.TabIndex = 3
        '
        'GB
        '
        Me.GB.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GB.Controls.Add(Me.lbrf)
        Me.GB.Controls.Add(Me.Label1)
        Me.GB.Controls.Add(Me.TextBox2)
        Me.GB.Location = New System.Drawing.Point(51, 263)
        Me.GB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GB.Name = "GB"
        Me.GB.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GB.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GB.Size = New System.Drawing.Size(320, 138)
        Me.GB.TabIndex = 11
        Me.GB.TabStop = False
        Me.GB.Text = " "
        '
        'lbrf
        '
        Me.lbrf.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lbrf.Location = New System.Drawing.Point(4, 97)
        Me.lbrf.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbrf.Name = "lbrf"
        Me.lbrf.Size = New System.Drawing.Size(312, 37)
        Me.lbrf.TabIndex = 4
        Me.lbrf.Text = "00"
        Me.lbrf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(144, 32)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "المرجو ادخال الرقم السري"
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(8, 68)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox2.Size = New System.Drawing.Size(299, 37)
        Me.TextBox2.TabIndex = 5
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"مسؤول", "مستخدم"})
        Me.ComboBox1.Location = New System.Drawing.Point(51, 167)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(232, 24)
        Me.ComboBox1.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(319, 100)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 17)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "الاسم"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(316, 170)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 17)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "الصفة"
        '
        'RsAdd
        '
        Me.RsAdd.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.RsAdd.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.AddFile_32x32
        Me.RsAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.RsAdd.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RsAdd.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.RsAdd.CornerRadius = 5
        Me.RsAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.RsAdd.Location = New System.Drawing.Point(20, 16)
        Me.RsAdd.Name = "RsAdd"
        Me.RsAdd.Size = New System.Drawing.Size(47, 48)
        '
        'RsEdit
        '
        Me.RsEdit.BackColor = System.Drawing.Color.DarkGreen
        Me.RsEdit.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.ED_32
        Me.RsEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.RsEdit.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RsEdit.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.RsEdit.CornerRadius = 5
        Me.RsEdit.Cursor = System.Windows.Forms.Cursors.Default
        Me.RsEdit.Location = New System.Drawing.Point(122, 16)
        Me.RsEdit.Name = "RsEdit"
        Me.RsEdit.Size = New System.Drawing.Size(47, 48)
        '
        'RsDel
        '
        Me.RsDel.BackColor = System.Drawing.Color.Crimson
        Me.RsDel.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.COR_32
        Me.RsDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.RsDel.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RsDel.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.RsDel.CornerRadius = 5
        Me.RsDel.Cursor = System.Windows.Forms.Cursors.Default
        Me.RsDel.Location = New System.Drawing.Point(224, 16)
        Me.RsDel.Name = "RsDel"
        Me.RsDel.Size = New System.Drawing.Size(47, 48)
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RsDel, Me.RsEdit, Me.RsAdd})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1157, 526)
        Me.ShapeContainer1.TabIndex = 15
        Me.ShapeContainer1.TabStop = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.SeaGreen
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Yellow
        Me.Button2.Image = Global.Al_Mohasib.My.Resources.Resources.BTGROUP
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(16, 7)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(113, 34)
        Me.Button2.TabIndex = 2
        Me.Button2.Tag = "-1"
        Me.Button2.Text = "Ok"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Controls.Add(Me.ShapeContainer4)
        Me.Panel3.Location = New System.Drawing.Point(213, 423)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(147, 49)
        Me.Panel3.TabIndex = 16
        '
        'ShapeContainer4
        '
        Me.ShapeContainer4.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer4.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer4.Name = "ShapeContainer4"
        Me.ShapeContainer4.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape9})
        Me.ShapeContainer4.Size = New System.Drawing.Size(147, 49)
        Me.ShapeContainer4.TabIndex = 0
        Me.ShapeContainer4.TabStop = False
        '
        'RectangleShape9
        '
        Me.RectangleShape9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RectangleShape9.BackColor = System.Drawing.Color.SeaGreen
        Me.RectangleShape9.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape9.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.RectangleShape9.CornerRadius = 14
        Me.RectangleShape9.Location = New System.Drawing.Point(38, 4)
        Me.RectangleShape9.Name = "RectangleShape1"
        Me.RectangleShape9.Size = New System.Drawing.Size(107, 31)
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DarkOrange
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Yellow
        Me.Button1.Image = Global.Al_Mohasib.My.Resources.Resources.BTGROUP
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(16, 7)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(113, 34)
        Me.Button1.TabIndex = 2
        Me.Button1.Tag = "-1"
        Me.Button1.Text = "Anuler"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.ShapeContainer2)
        Me.Panel2.Location = New System.Drawing.Point(43, 423)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(147, 49)
        Me.Panel2.TabIndex = 16
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer2.Size = New System.Drawing.Size(147, 49)
        Me.ShapeContainer2.TabIndex = 0
        Me.ShapeContainer2.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RectangleShape1.BackColor = System.Drawing.Color.DarkOrange
        Me.RectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape1.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.RectangleShape1.CornerRadius = 14
        Me.RectangleShape1.Location = New System.Drawing.Point(38, 4)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(107, 31)
        '
        'lbb
        '
        Me.lbb.AutoSize = True
        Me.lbb.Location = New System.Drawing.Point(76, 489)
        Me.lbb.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbb.Name = "lbb"
        Me.lbb.Size = New System.Drawing.Size(16, 17)
        Me.lbb.TabIndex = 17
        Me.lbb.Text = "0"
        '
        'txtRole
        '
        Me.txtRole.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRole.Location = New System.Drawing.Point(51, 208)
        Me.txtRole.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRole.Name = "txtRole"
        Me.txtRole.Size = New System.Drawing.Size(232, 31)
        Me.txtRole.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(293, 217)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 17)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "الصلاحيات"
        '
        'AdidDataGridViewTextBoxColumn
        '
        Me.AdidDataGridViewTextBoxColumn.DataPropertyName = "adid"
        Me.AdidDataGridViewTextBoxColumn.HeaderText = "adid"
        Me.AdidDataGridViewTextBoxColumn.Name = "AdidDataGridViewTextBoxColumn"
        Me.AdidDataGridViewTextBoxColumn.ReadOnly = True
        Me.AdidDataGridViewTextBoxColumn.Visible = False
        '
        'NameDataGridViewTextBoxColumn
        '
        Me.NameDataGridViewTextBoxColumn.DataPropertyName = "name"
        Me.NameDataGridViewTextBoxColumn.HeaderText = "name"
        Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
        Me.NameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AdminDataGridViewTextBoxColumn
        '
        Me.AdminDataGridViewTextBoxColumn.DataPropertyName = "admin"
        Me.AdminDataGridViewTextBoxColumn.HeaderText = "admin"
        Me.AdminDataGridViewTextBoxColumn.Name = "AdminDataGridViewTextBoxColumn"
        Me.AdminDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PwdDataGridViewTextBoxColumn
        '
        Me.PwdDataGridViewTextBoxColumn.DataPropertyName = "pwd"
        Me.PwdDataGridViewTextBoxColumn.HeaderText = "pwd"
        Me.PwdDataGridViewTextBoxColumn.Name = "PwdDataGridViewTextBoxColumn"
        Me.PwdDataGridViewTextBoxColumn.ReadOnly = True
        '
        'rfid
        '
        Me.rfid.DataPropertyName = "rf"
        Me.rfid.HeaderText = "Rfid"
        Me.rfid.Name = "rfid"
        Me.rfid.ReadOnly = True
        '
        'Role
        '
        Me.Role.DataPropertyName = "role"
        Me.Role.HeaderText = "Role"
        Me.Role.Name = "Role"
        Me.Role.ReadOnly = True
        '
        'Addadmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1157, 526)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtRole)
        Me.Controls.Add(Me.lbb)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.GB)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Addadmin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "المستخدم"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GB.ResumeLayout(False)
        Me.GB.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GB As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RsAdd As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RsEdit As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RsDel As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer4 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape9 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents lbrf As System.Windows.Forms.Label
    Friend WithEvents lbb As System.Windows.Forms.Label
    Friend WithEvents AdidDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdminDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PwdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rfid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Role As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtRole As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
