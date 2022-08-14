<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectBon
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel43 = New System.Windows.Forms.Panel()
        Me.Panel27 = New System.Windows.Forms.Panel()
        Me.cbSearchRegler = New System.Windows.Forms.ComboBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.txtArSearch = New Al_Mohasib.TxtBox()
        Me.btSearchArch = New System.Windows.Forms.Button()
        Me.dte2 = New System.Windows.Forms.DateTimePicker()
        Me.dte1 = New System.Windows.Forms.DateTimePicker()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btcancel = New System.Windows.Forms.Button()
        Me.btcon = New System.Windows.Forms.Button()
        Me.DG = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel43.SuspendLayout()
        Me.Panel27.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel43
        '
        Me.Panel43.BackColor = System.Drawing.SystemColors.Control
        Me.Panel43.Controls.Add(Me.Panel27)
        Me.Panel43.Controls.Add(Me.Button9)
        Me.Panel43.Controls.Add(Me.txtArSearch)
        Me.Panel43.Controls.Add(Me.btSearchArch)
        Me.Panel43.Controls.Add(Me.dte2)
        Me.Panel43.Controls.Add(Me.dte1)
        Me.Panel43.Controls.Add(Me.Label28)
        Me.Panel43.Controls.Add(Me.Label4)
        Me.Panel43.Controls.Add(Me.Label6)
        Me.Panel43.Controls.Add(Me.Label3)
        Me.Panel43.Controls.Add(Me.Label31)
        Me.Panel43.Controls.Add(Me.Label32)
        Me.Panel43.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel43.Location = New System.Drawing.Point(772, 0)
        Me.Panel43.Name = "Panel43"
        Me.Panel43.Size = New System.Drawing.Size(219, 389)
        Me.Panel43.TabIndex = 2
        '
        'Panel27
        '
        Me.Panel27.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Panel27.Controls.Add(Me.cbSearchRegler)
        Me.Panel27.Controls.Add(Me.Label38)
        Me.Panel27.Location = New System.Drawing.Point(12, 201)
        Me.Panel27.Name = "Panel27"
        Me.Panel27.Padding = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.Panel27.Size = New System.Drawing.Size(198, 34)
        Me.Panel27.TabIndex = 15
        '
        'cbSearchRegler
        '
        Me.cbSearchRegler.BackColor = System.Drawing.SystemColors.HotTrack
        Me.cbSearchRegler.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbSearchRegler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSearchRegler.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbSearchRegler.ForeColor = System.Drawing.Color.White
        Me.cbSearchRegler.FormattingEnabled = True
        Me.cbSearchRegler.Items.AddRange(New Object() {"Tous", "Reglé", "Non Reglé"})
        Me.cbSearchRegler.Location = New System.Drawing.Point(69, 6)
        Me.cbSearchRegler.Name = "cbSearchRegler"
        Me.cbSearchRegler.Size = New System.Drawing.Size(126, 21)
        Me.cbSearchRegler.TabIndex = 14
        '
        'Label38
        '
        Me.Label38.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.White
        Me.Label38.Location = New System.Drawing.Point(3, 6)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(66, 25)
        Me.Label38.TabIndex = 6
        Me.Label38.Text = "Regler"
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.RosyBrown
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.ForeColor = System.Drawing.Color.Maroon
        Me.Button9.Location = New System.Drawing.Point(170, 34)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(35, 30)
        Me.Button9.TabIndex = 13
        Me.Button9.Text = "..."
        Me.Button9.UseVisualStyleBackColor = False
        '
        'txtArSearch
        '
        Me.txtArSearch.BackColor = System.Drawing.Color.Transparent
        Me.txtArSearch.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtArSearch.IsNumiric = False
        Me.txtArSearch.Location = New System.Drawing.Point(12, 34)
        Me.txtArSearch.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtArSearch.Name = "txtArSearch"
        Me.txtArSearch.ShowClearIcon = False
        Me.txtArSearch.ShowSaveIcon = False
        Me.txtArSearch.Size = New System.Drawing.Size(156, 30)
        Me.txtArSearch.StartUp = 2
        Me.txtArSearch.TabIndex = 9
        Me.txtArSearch.TextSize = 8
        Me.txtArSearch.TxtBackColor = True
        Me.txtArSearch.TxtColor = System.Drawing.Color.White
        Me.txtArSearch.txtReadOnly = False
        Me.txtArSearch.TxtSelect = New Integer() {1, 0}
        '
        'btSearchArch
        '
        Me.btSearchArch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btSearchArch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSearchArch.ForeColor = System.Drawing.Color.MidnightBlue
        Me.btSearchArch.Image = Global.Al_Mohasib.My.Resources.Resources.SEARCH_24X24
        Me.btSearchArch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btSearchArch.Location = New System.Drawing.Point(12, 263)
        Me.btSearchArch.Name = "btSearchArch"
        Me.btSearchArch.Padding = New System.Windows.Forms.Padding(11, 0, 0, 0)
        Me.btSearchArch.Size = New System.Drawing.Size(193, 45)
        Me.btSearchArch.TabIndex = 12
        Me.btSearchArch.Text = "  Recherche"
        Me.btSearchArch.UseVisualStyleBackColor = True
        '
        'dte2
        '
        Me.dte2.CustomFormat = ""
        Me.dte2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dte2.Location = New System.Drawing.Point(13, 163)
        Me.dte2.Name = "dte2"
        Me.dte2.Size = New System.Drawing.Size(197, 22)
        Me.dte2.TabIndex = 10
        '
        'dte1
        '
        Me.dte1.CustomFormat = ""
        Me.dte1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dte1.Location = New System.Drawing.Point(13, 106)
        Me.dte1.Name = "dte1"
        Me.dte1.Size = New System.Drawing.Size(197, 22)
        Me.dte1.TabIndex = 11
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(17, 147)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(61, 13)
        Me.Label28.TabIndex = 6
        Me.Label28.Text = "Date 2 (Au)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(166, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "تاريخ 2"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(167, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "الاســم"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(166, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "تاريخ 1"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(14, 90)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(62, 13)
        Me.Label31.TabIndex = 7
        Me.Label31.Text = "Date 1 (Du)"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(16, 16)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(91, 13)
        Me.Label32.TabIndex = 8
        Me.Label32.Text = "Id BL/BC  -  Nom "
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel1.Controls.Add(Me.btcancel)
        Me.Panel1.Controls.Add(Me.btcon)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 328)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(772, 61)
        Me.Panel1.TabIndex = 3
        '
        'btcancel
        '
        Me.btcancel.BackColor = System.Drawing.Color.Crimson
        Me.btcancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btcancel.FlatAppearance.BorderSize = 2
        Me.btcancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btcancel.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btcancel.ForeColor = System.Drawing.Color.White
        Me.btcancel.Image = Global.Al_Mohasib.My.Resources.Resources.iconfinder_folder_delete_61770
        Me.btcancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btcancel.Location = New System.Drawing.Point(16, 14)
        Me.btcancel.Name = "btcancel"
        Me.btcancel.Size = New System.Drawing.Size(123, 35)
        Me.btcancel.TabIndex = 9
        Me.btcancel.Text = "Annuler"
        Me.btcancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btcancel.UseVisualStyleBackColor = False
        '
        'btcon
        '
        Me.btcon.BackColor = System.Drawing.Color.AliceBlue
        Me.btcon.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btcon.FlatAppearance.BorderSize = 2
        Me.btcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btcon.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btcon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btcon.Image = Global.Al_Mohasib.My.Resources.Resources.FACTURE_20
        Me.btcon.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btcon.Location = New System.Drawing.Point(145, 13)
        Me.btcon.Name = "btcon"
        Me.btcon.Size = New System.Drawing.Size(245, 36)
        Me.btcon.TabIndex = 8
        Me.btcon.Tag = "0"
        Me.btcon.Text = "Valider"
        Me.btcon.UseVisualStyleBackColor = False
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = False
        Me.DG.AllowUserToDeleteRows = False
        Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DG.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(2)
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Column6, Me.Column5, Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.DG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DG.GridColor = System.Drawing.SystemColors.ButtonFace
        Me.DG.Location = New System.Drawing.Point(0, 0)
        Me.DG.MultiSelect = False
        Me.DG.Name = "DG"
        Me.DG.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DG.RowHeadersVisible = False
        Me.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG.Size = New System.Drawing.Size(772, 328)
        Me.DG.TabIndex = 4
        '
        'ID
        '
        Me.ID.HeaderText = "N°"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "CID"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        '
        'Column5
        '
        Me.Column5.HeaderText = "Date"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "Nom"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Total"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Avance"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Rest"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'SelectBon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(991, 389)
        Me.Controls.Add(Me.DG)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel43)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "SelectBon"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Les Bons"
        Me.Panel43.ResumeLayout(False)
        Me.Panel43.PerformLayout()
        Me.Panel27.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel43 As System.Windows.Forms.Panel
    Friend WithEvents Panel27 As System.Windows.Forms.Panel
    Friend WithEvents cbSearchRegler As System.Windows.Forms.ComboBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents txtArSearch As Al_Mohasib.TxtBox
    Friend WithEvents btSearchArch As System.Windows.Forms.Button
    Friend WithEvents dte2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dte1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents btcancel As System.Windows.Forms.Button
    Friend WithEvents btcon As System.Windows.Forms.Button
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
