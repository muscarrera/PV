<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddEditElement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddEditElement))
        Me.btColor = New System.Windows.Forms.Button()
        Me.cbBloc = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CB = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btForColor = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CbAlign = New System.Windows.Forms.ComboBox()
        Me.cbIsV = New System.Windows.Forms.CheckBox()
        Me.txtF1 = New Al_Mohasib.TxtBox()
        Me.T = New Al_Mohasib.TxtBox()
        Me.H = New Al_Mohasib.TxtBox()
        Me.W = New Al_Mohasib.TxtBox()
        Me.Y = New Al_Mohasib.TxtBox()
        Me.txt = New Al_Mohasib.TxtBox()
        Me.X = New Al_Mohasib.TxtBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pb = New System.Windows.Forms.PictureBox()
        Me.cbEtqs = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btImage = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btColor
        '
        Me.btColor.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btColor.Location = New System.Drawing.Point(213, 204)
        Me.btColor.Name = "btColor"
        Me.btColor.Size = New System.Drawing.Size(125, 30)
        Me.btColor.TabIndex = 37
        Me.btColor.Text = "Fond"
        Me.btColor.UseVisualStyleBackColor = False
        '
        'cbBloc
        '
        Me.cbBloc.AutoSize = True
        Me.cbBloc.Location = New System.Drawing.Point(66, 373)
        Me.cbBloc.Name = "cbBloc"
        Me.cbBloc.Size = New System.Drawing.Size(94, 17)
        Me.cbBloc.TabIndex = 35
        Me.cbBloc.Text = "Crée un Cadre"
        Me.cbBloc.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(66, 350)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(85, 17)
        Me.CheckBox1.TabIndex = 36
        Me.CheckBox1.Text = "Text en gras"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Green
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(154, 446)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(219, 38)
        Me.Button1.TabIndex = 33
        Me.Button1.Text = "Valider"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'CB
        '
        Me.CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB.FormattingEnabled = True
        Me.CB.ItemHeight = 13
        Me.CB.Items.AddRange(New Object() {"*", "name", "Prix(G)", "Prix(P)", "Prix", "Ref", "Image_Article", "Code", "FORME", "//BarCode", "**Bloc ETQ", "IMAGE_PATH"})
        Me.CB.Location = New System.Drawing.Point(46, 79)
        Me.CB.Name = "CB"
        Me.CB.Size = New System.Drawing.Size(327, 21)
        Me.CB.TabIndex = 32
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(225, 298)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 13)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "T"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(133, 243)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "H"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(67, 243)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "W"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(133, 188)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 13)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Y"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(77, 188)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "X"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(54, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Field"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(57, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Text"
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(276, 314)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(62, 30)
        Me.Button3.TabIndex = 44
        Me.Button3.Text = "..."
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(65, 298)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "Police "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(210, 185)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 45
        Me.Label9.Text = "Couleur"
        '
        'btForColor
        '
        Me.btForColor.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btForColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btForColor.Location = New System.Drawing.Point(213, 259)
        Me.btForColor.Name = "btForColor"
        Me.btForColor.Size = New System.Drawing.Size(125, 30)
        Me.btForColor.TabIndex = 37
        Me.btForColor.Text = "Text"
        Me.btForColor.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(242, 349)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "Alignment"
        '
        'CbAlign
        '
        Me.CbAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbAlign.FormattingEnabled = True
        Me.CbAlign.ItemHeight = 13
        Me.CbAlign.Items.AddRange(New Object() {"Gauche", "Droite", "Centre"})
        Me.CbAlign.Location = New System.Drawing.Point(245, 369)
        Me.CbAlign.Name = "CbAlign"
        Me.CbAlign.Size = New System.Drawing.Size(93, 21)
        Me.CbAlign.TabIndex = 32
        '
        'cbIsV
        '
        Me.cbIsV.AutoSize = True
        Me.cbIsV.Location = New System.Drawing.Point(66, 396)
        Me.cbIsV.Name = "cbIsV"
        Me.cbIsV.Size = New System.Drawing.Size(61, 17)
        Me.cbIsV.TabIndex = 35
        Me.cbIsV.Text = "Vertical"
        Me.cbIsV.UseVisualStyleBackColor = True
        '
        'txtF1
        '
        Me.txtF1.BackColor = System.Drawing.Color.White
        Me.txtF1.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtF1.IsNumiric = False
        Me.txtF1.Location = New System.Drawing.Point(68, 314)
        Me.txtF1.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtF1.Name = "txtF1"
        Me.txtF1.ShowClearIcon = False
        Me.txtF1.ShowSaveIcon = False
        Me.txtF1.Size = New System.Drawing.Size(150, 30)
        Me.txtF1.StartUp = 2
        Me.txtF1.TabIndex = 46
        Me.txtF1.TextSize = 8
        Me.txtF1.TxtBackColor = True
        Me.txtF1.TxtColor = System.Drawing.Color.White
        Me.txtF1.txtReadOnly = True
        Me.txtF1.TxtSelect = New Integer() {1, 0}
        '
        'T
        '
        Me.T.BackColor = System.Drawing.Color.Transparent
        Me.T.BorderColor = System.Drawing.SystemColors.ControlText
        Me.T.IsNumiric = True
        Me.T.Location = New System.Drawing.Point(224, 314)
        Me.T.MinimumSize = New System.Drawing.Size(0, 30)
        Me.T.Name = "T"
        Me.T.ShowClearIcon = False
        Me.T.ShowSaveIcon = False
        Me.T.Size = New System.Drawing.Size(46, 30)
        Me.T.StartUp = 2
        Me.T.TabIndex = 40
        Me.T.TextSize = 8
        Me.T.TxtBackColor = True
        Me.T.TxtColor = System.Drawing.Color.White
        Me.T.txtReadOnly = False
        Me.T.TxtSelect = New Integer() {1, 0}
        '
        'H
        '
        Me.H.BackColor = System.Drawing.Color.Transparent
        Me.H.BorderColor = System.Drawing.SystemColors.ControlText
        Me.H.IsNumiric = False
        Me.H.Location = New System.Drawing.Point(132, 259)
        Me.H.MinimumSize = New System.Drawing.Size(0, 30)
        Me.H.Name = "H"
        Me.H.ShowClearIcon = False
        Me.H.ShowSaveIcon = False
        Me.H.Size = New System.Drawing.Size(57, 30)
        Me.H.StartUp = 2
        Me.H.TabIndex = 39
        Me.H.TextSize = 8
        Me.H.TxtBackColor = True
        Me.H.TxtColor = System.Drawing.Color.White
        Me.H.txtReadOnly = False
        Me.H.TxtSelect = New Integer() {1, 0}
        '
        'W
        '
        Me.W.BackColor = System.Drawing.Color.Transparent
        Me.W.BorderColor = System.Drawing.SystemColors.ControlText
        Me.W.IsNumiric = False
        Me.W.Location = New System.Drawing.Point(66, 259)
        Me.W.MinimumSize = New System.Drawing.Size(0, 30)
        Me.W.Name = "W"
        Me.W.ShowClearIcon = False
        Me.W.ShowSaveIcon = False
        Me.W.Size = New System.Drawing.Size(57, 30)
        Me.W.StartUp = 2
        Me.W.TabIndex = 38
        Me.W.TextSize = 8
        Me.W.TxtBackColor = True
        Me.W.TxtColor = System.Drawing.Color.White
        Me.W.txtReadOnly = False
        Me.W.TxtSelect = New Integer() {1, 0}
        '
        'Y
        '
        Me.Y.BackColor = System.Drawing.Color.Transparent
        Me.Y.BorderColor = System.Drawing.SystemColors.ControlText
        Me.Y.IsNumiric = False
        Me.Y.Location = New System.Drawing.Point(132, 204)
        Me.Y.MinimumSize = New System.Drawing.Size(0, 30)
        Me.Y.Name = "Y"
        Me.Y.ShowClearIcon = False
        Me.Y.ShowSaveIcon = False
        Me.Y.Size = New System.Drawing.Size(57, 30)
        Me.Y.StartUp = 2
        Me.Y.TabIndex = 43
        Me.Y.TextSize = 8
        Me.Y.TxtBackColor = True
        Me.Y.TxtColor = System.Drawing.Color.White
        Me.Y.txtReadOnly = False
        Me.Y.TxtSelect = New Integer() {1, 0}
        '
        'txt
        '
        Me.txt.BackColor = System.Drawing.Color.Transparent
        Me.txt.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txt.IsNumiric = False
        Me.txt.Location = New System.Drawing.Point(46, 23)
        Me.txt.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txt.Name = "txt"
        Me.txt.ShowClearIcon = False
        Me.txt.ShowSaveIcon = False
        Me.txt.Size = New System.Drawing.Size(327, 30)
        Me.txt.StartUp = 2
        Me.txt.TabIndex = 42
        Me.txt.TextSize = 8
        Me.txt.TxtBackColor = True
        Me.txt.TxtColor = System.Drawing.Color.White
        Me.txt.txtReadOnly = False
        Me.txt.TxtSelect = New Integer() {1, 0}
        '
        'X
        '
        Me.X.BackColor = System.Drawing.Color.Transparent
        Me.X.BorderColor = System.Drawing.SystemColors.ControlText
        Me.X.IsNumiric = False
        Me.X.Location = New System.Drawing.Point(66, 204)
        Me.X.MinimumSize = New System.Drawing.Size(0, 30)
        Me.X.Name = "X"
        Me.X.ShowClearIcon = False
        Me.X.ShowSaveIcon = False
        Me.X.Size = New System.Drawing.Size(57, 30)
        Me.X.StartUp = 2
        Me.X.TabIndex = 41
        Me.X.TextSize = 8
        Me.X.TxtBackColor = True
        Me.X.TxtColor = System.Drawing.Color.White
        Me.X.txtReadOnly = False
        Me.X.TxtSelect = New Integer() {1, 0}
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button7)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Location = New System.Drawing.Point(52, 120)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(327, 35)
        Me.Panel1.TabIndex = 48
        Me.Panel1.Visible = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.White
        Me.Button7.BackgroundImage = CType(resources.GetObject("Button7.BackgroundImage"), System.Drawing.Image)
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.Maroon
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.Location = New System.Drawing.Point(240, 0)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(80, 35)
        Me.Button7.TabIndex = 47
        Me.Button7.Text = "Formes"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.White
        Me.Button5.BackgroundImage = CType(resources.GetObject("Button5.BackgroundImage"), System.Drawing.Image)
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.Maroon
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(160, 0)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(80, 35)
        Me.Button5.TabIndex = 47
        Me.Button5.Text = "Rond"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.White
        Me.Button6.BackgroundImage = CType(resources.GetObject("Button6.BackgroundImage"), System.Drawing.Image)
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.Maroon
        Me.Button6.Location = New System.Drawing.Point(80, 0)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(80, 35)
        Me.Button6.TabIndex = 47
        Me.Button6.Text = "Cecle"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.BackgroundImage = CType(resources.GetObject("Button4.BackgroundImage"), System.Drawing.Image)
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Maroon
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(0, 0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(80, 35)
        Me.Button4.TabIndex = 47
        Me.Button4.Text = "Rectangle"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.pb)
        Me.Panel2.Controls.Add(Me.cbEtqs)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Location = New System.Drawing.Point(436, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(333, 472)
        Me.Panel2.TabIndex = 49
        '
        'pb
        '
        Me.pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pb.Location = New System.Drawing.Point(30, 108)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(277, 352)
        Me.pb.TabIndex = 35
        Me.pb.TabStop = False
        '
        'cbEtqs
        '
        Me.cbEtqs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEtqs.FormattingEnabled = True
        Me.cbEtqs.ItemHeight = 13
        Me.cbEtqs.Location = New System.Drawing.Point(30, 40)
        Me.cbEtqs.Name = "cbEtqs"
        Me.cbEtqs.Size = New System.Drawing.Size(277, 21)
        Me.cbEtqs.TabIndex = 34
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(27, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 13)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "Bloc Etqs"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Maroon
        Me.Button2.Image = Global.Al_Mohasib.My.Resources.Resources.COR_22
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(46, 446)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(81, 38)
        Me.Button2.TabIndex = 34
        Me.Button2.Text = "Delete"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'btImage
        '
        Me.btImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btImage.Location = New System.Drawing.Point(379, 23)
        Me.btImage.Name = "btImage"
        Me.btImage.Size = New System.Drawing.Size(34, 30)
        Me.btImage.TabIndex = 50
        Me.btImage.Text = "..."
        Me.btImage.UseVisualStyleBackColor = True
        Me.btImage.Visible = False
        '
        'AddEditElement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Snow
        Me.ClientSize = New System.Drawing.Size(790, 496)
        Me.Controls.Add(Me.btImage)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtF1)
        Me.Controls.Add(Me.T)
        Me.Controls.Add(Me.H)
        Me.Controls.Add(Me.W)
        Me.Controls.Add(Me.Y)
        Me.Controls.Add(Me.txt)
        Me.Controls.Add(Me.X)
        Me.Controls.Add(Me.btForColor)
        Me.Controls.Add(Me.btColor)
        Me.Controls.Add(Me.cbIsV)
        Me.Controls.Add(Me.cbBloc)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CbAlign)
        Me.Controls.Add(Me.CB)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AddEditElement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Element"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents T As Al_Mohasib.TxtBox
    Friend WithEvents H As Al_Mohasib.TxtBox
    Friend WithEvents W As Al_Mohasib.TxtBox
    Friend WithEvents Y As Al_Mohasib.TxtBox
    Friend WithEvents txt As Al_Mohasib.TxtBox
    Friend WithEvents X As Al_Mohasib.TxtBox
    Friend WithEvents btColor As System.Windows.Forms.Button
    Friend WithEvents cbBloc As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CB As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtF1 As Al_Mohasib.TxtBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btForColor As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CbAlign As System.Windows.Forms.ComboBox
    Friend WithEvents cbIsV As System.Windows.Forms.CheckBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cbEtqs As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents pb As System.Windows.Forms.PictureBox
    Friend WithEvents btImage As System.Windows.Forms.Button
End Class
