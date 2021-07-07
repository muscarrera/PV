<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddEditSideElement
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
        Me.txt = New Al_Mohasib.TxtBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btArt = New System.Windows.Forms.Button()
        Me.btCat = New System.Windows.Forms.Button()
        Me.pb = New System.Windows.Forms.PictureBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.btprdimg = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.dg = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNm = New Al_Mohasib.TxtBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btColor = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt
        '
        Me.txt.BackColor = System.Drawing.Color.Transparent
        Me.txt.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txt.IsNumiric = False
        Me.txt.Location = New System.Drawing.Point(35, 62)
        Me.txt.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txt.Name = "txt"
        Me.txt.ShowClearIcon = True
        Me.txt.ShowSaveIcon = False
        Me.txt.Size = New System.Drawing.Size(352, 30)
        Me.txt.StartUp = 2
        Me.txt.TabIndex = 91
        Me.txt.TextSize = 8
        Me.txt.TxtBackColor = True
        Me.txt.TxtColor = System.Drawing.Color.White
        Me.txt.txtReadOnly = False
        Me.txt.TxtSelect = New Integer() {1, 0}
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Green
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(551, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(208, 38)
        Me.Button1.TabIndex = 83
        Me.Button1.Text = "Valider"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "Recherche"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Maroon
        Me.Button2.Image = Global.Al_Mohasib.My.Resources.Resources.COR_22
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(451, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(81, 38)
        Me.Button2.TabIndex = 84
        Me.Button2.Text = "Annuler"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'btArt
        '
        Me.btArt.BackColor = System.Drawing.Color.Green
        Me.btArt.FlatAppearance.BorderSize = 0
        Me.btArt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btArt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btArt.ForeColor = System.Drawing.Color.White
        Me.btArt.Location = New System.Drawing.Point(136, 29)
        Me.btArt.Name = "btArt"
        Me.btArt.Size = New System.Drawing.Size(113, 27)
        Me.btArt.TabIndex = 83
        Me.btArt.Text = "Article"
        Me.btArt.UseVisualStyleBackColor = False
        '
        'btCat
        '
        Me.btCat.BackColor = System.Drawing.Color.Black
        Me.btCat.FlatAppearance.BorderSize = 0
        Me.btCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btCat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCat.ForeColor = System.Drawing.Color.White
        Me.btCat.Location = New System.Drawing.Point(265, 29)
        Me.btCat.Name = "btCat"
        Me.btCat.Size = New System.Drawing.Size(122, 27)
        Me.btCat.TabIndex = 83
        Me.btCat.Text = "Categorie"
        Me.btCat.UseVisualStyleBackColor = False
        '
        'pb
        '
        Me.pb.BackColor = System.Drawing.Color.Linen
        Me.pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb.Location = New System.Drawing.Point(498, 114)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(261, 203)
        Me.pb.TabIndex = 92
        Me.pb.TabStop = False
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(708, 323)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(51, 36)
        Me.Button5.TabIndex = 94
        Me.Button5.Text = "C *** اللون"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'btprdimg
        '
        Me.btprdimg.Location = New System.Drawing.Point(603, 323)
        Me.btprdimg.Name = "btprdimg"
        Me.btprdimg.Size = New System.Drawing.Size(102, 36)
        Me.btprdimg.TabIndex = 93
        Me.btprdimg.Text = "Choisir une image *** اختر الصورة"
        Me.btprdimg.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(498, 323)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(102, 36)
        Me.Button3.TabIndex = 93
        Me.Button3.Text = "Img de produit *** صورة المنتج"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'dg
        '
        Me.dg.AllowUserToAddRows = False
        Me.dg.AllowUserToDeleteRows = False
        Me.dg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dg.BackgroundColor = System.Drawing.Color.White
        Me.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg.ColumnHeadersVisible = False
        Me.dg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg.DefaultCellStyle = DataGridViewCellStyle1
        Me.dg.Location = New System.Drawing.Point(35, 130)
        Me.dg.MultiSelect = False
        Me.dg.Name = "dg"
        Me.dg.ReadOnly = True
        Me.dg.RowHeadersVisible = False
        Me.dg.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dg.RowTemplate.Height = 33
        Me.dg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg.Size = New System.Drawing.Size(437, 187)
        Me.dg.TabIndex = 95
        '
        'Column1
        '
        Me.Column1.HeaderText = "id"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Design"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Prix"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "img"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 382)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(785, 52)
        Me.Panel1.TabIndex = 96
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Listes"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(426, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 80
        Me.Label3.Text = "Text"
        '
        'txtNm
        '
        Me.txtNm.BackColor = System.Drawing.Color.Transparent
        Me.txtNm.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtNm.IsNumiric = False
        Me.txtNm.Location = New System.Drawing.Point(429, 62)
        Me.txtNm.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtNm.Name = "txtNm"
        Me.txtNm.ShowClearIcon = False
        Me.txtNm.ShowSaveIcon = False
        Me.txtNm.Size = New System.Drawing.Size(208, 30)
        Me.txtNm.StartUp = 2
        Me.txtNm.TabIndex = 91
        Me.txtNm.TextSize = 8
        Me.txtNm.TxtBackColor = True
        Me.txtNm.TxtColor = System.Drawing.Color.White
        Me.txtNm.txtReadOnly = False
        Me.txtNm.TxtSelect = New Integer() {1, 0}
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 13)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "Designation/Ref/ID"
        '
        'btColor
        '
        Me.btColor.BackColor = System.Drawing.Color.Black
        Me.btColor.FlatAppearance.BorderSize = 0
        Me.btColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btColor.ForeColor = System.Drawing.Color.White
        Me.btColor.Location = New System.Drawing.Point(669, 65)
        Me.btColor.Name = "btColor"
        Me.btColor.Size = New System.Drawing.Size(90, 27)
        Me.btColor.TabIndex = 83
        Me.btColor.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(666, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 80
        Me.Label5.Text = "Couleur de Text"
        '
        'AddEditSideElement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Snow
        Me.ClientSize = New System.Drawing.Size(785, 434)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dg)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btprdimg)
        Me.Controls.Add(Me.pb)
        Me.Controls.Add(Me.txtNm)
        Me.Controls.Add(Me.txt)
        Me.Controls.Add(Me.btColor)
        Me.Controls.Add(Me.btCat)
        Me.Controls.Add(Me.btArt)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AddEditSideElement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AddEditSideElement"
        CType(Me.pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txt As Al_Mohasib.TxtBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btArt As System.Windows.Forms.Button
    Friend WithEvents btCat As System.Windows.Forms.Button
    Friend WithEvents pb As System.Windows.Forms.PictureBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents btprdimg As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents dg As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNm As Al_Mohasib.TxtBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btColor As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
