<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddEditTopField
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
        Me.btColor = New System.Windows.Forms.Button()
        Me.cbBloc = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CB = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.T = New Al_Mohasib.TxtBox()
        Me.H = New Al_Mohasib.TxtBox()
        Me.W = New Al_Mohasib.TxtBox()
        Me.Y = New Al_Mohasib.TxtBox()
        Me.txt = New Al_Mohasib.TxtBox()
        Me.X = New Al_Mohasib.TxtBox()
        Me.SuspendLayout()
        '
        'btColor
        '
        Me.btColor.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btColor.Location = New System.Drawing.Point(280, 209)
        Me.btColor.Name = "btColor"
        Me.btColor.Size = New System.Drawing.Size(125, 30)
        Me.btColor.TabIndex = 23
        Me.btColor.Text = "Couleur"
        Me.btColor.UseVisualStyleBackColor = False
        '
        'cbBloc
        '
        Me.cbBloc.AutoSize = True
        Me.cbBloc.Location = New System.Drawing.Point(214, 287)
        Me.cbBloc.Name = "cbBloc"
        Me.cbBloc.Size = New System.Drawing.Size(94, 17)
        Me.cbBloc.TabIndex = 21
        Me.cbBloc.Text = "Crée un Cadre"
        Me.cbBloc.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(82, 287)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(85, 17)
        Me.CheckBox1.TabIndex = 22
        Me.CheckBox1.Text = "Text en gras"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Maroon
        Me.Button2.Location = New System.Drawing.Point(280, 389)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(125, 38)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "Delete"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(78, 345)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(328, 38)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "Valider"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CB
        '
        Me.CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB.FormattingEnabled = True
        Me.CB.ItemHeight = 13
        Me.CB.Items.AddRange(New Object() {"*", "-Titre", "id", "date", "cid", "name", "CLT_ice", "CLT_adresse", "CLT_tel", "CLT_ville", "CLT_ref", "CLT_NvCredit", "CLT_EncCredit", "CLT_RealEncCredit", "total_ht", "total_tva", "total_ttc", "x_total_ttc_sn_remise", "total_remise", "total_droitTimbre", "image", "total_avance", "rest_ht", "rest_ttc", "Editeur", "livreur", "vidal", "poid", "//En_Chiffre", "MPayement", "tableau_tva", "DPT_ID", "DPT_Nom", "RYL-total_ht", "RYL-total_ttc", "RealAvance", "RealRest", "Rest", "caisseAvance", "caisseRest", "Points_NV", "Points_ENC", "Points_TL", "Points_UT", "Points_RS", "PC_Nom", "PC_Tel", "PC_Adr"})
        Me.CB.Location = New System.Drawing.Point(82, 106)
        Me.CB.Name = "CB"
        Me.CB.Size = New System.Drawing.Size(327, 21)
        Me.CB.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(353, 159)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "T"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(287, 159)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "H"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(221, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "W"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(158, 159)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Y"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(102, 159)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "X"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(86, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Field"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(85, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Text"
        '
        'T
        '
        Me.T.BackColor = System.Drawing.Color.Transparent
        Me.T.BorderColor = System.Drawing.SystemColors.ControlText
        Me.T.IsNumiric = False
        Me.T.Location = New System.Drawing.Point(346, 175)
        Me.T.MinimumSize = New System.Drawing.Size(0, 30)
        Me.T.Name = "T"
        Me.T.ShowClearIcon = False
        Me.T.ShowSaveIcon = False
        Me.T.Size = New System.Drawing.Size(57, 30)
        Me.T.StartUp = 2
        Me.T.TabIndex = 24
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
        Me.H.Location = New System.Drawing.Point(280, 175)
        Me.H.MinimumSize = New System.Drawing.Size(0, 30)
        Me.H.Name = "H"
        Me.H.ShowClearIcon = False
        Me.H.ShowSaveIcon = False
        Me.H.Size = New System.Drawing.Size(57, 30)
        Me.H.StartUp = 2
        Me.H.TabIndex = 24
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
        Me.W.Location = New System.Drawing.Point(214, 175)
        Me.W.MinimumSize = New System.Drawing.Size(0, 30)
        Me.W.Name = "W"
        Me.W.ShowClearIcon = False
        Me.W.ShowSaveIcon = False
        Me.W.Size = New System.Drawing.Size(57, 30)
        Me.W.StartUp = 2
        Me.W.TabIndex = 24
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
        Me.Y.Location = New System.Drawing.Point(151, 175)
        Me.Y.MinimumSize = New System.Drawing.Size(0, 30)
        Me.Y.Name = "Y"
        Me.Y.ShowClearIcon = False
        Me.Y.ShowSaveIcon = False
        Me.Y.Size = New System.Drawing.Size(57, 30)
        Me.Y.StartUp = 2
        Me.Y.TabIndex = 24
        Me.Y.TextSize = 8
        Me.Y.TxtBackColor = True
        Me.Y.TxtColor = System.Drawing.Color.White
        Me.Y.txtReadOnly = False
        Me.Y.TxtSelect = New Integer() {1, 0}
        '
        'txt
        '
        Me.txt.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt.BackColor = System.Drawing.Color.Transparent
        Me.txt.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txt.IsNumiric = False
        Me.txt.Location = New System.Drawing.Point(82, 29)
        Me.txt.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txt.Name = "txt"
        Me.txt.ShowClearIcon = False
        Me.txt.ShowSaveIcon = False
        Me.txt.Size = New System.Drawing.Size(327, 30)
        Me.txt.StartUp = 2
        Me.txt.TabIndex = 24
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
        Me.X.Location = New System.Drawing.Point(85, 175)
        Me.X.MinimumSize = New System.Drawing.Size(0, 30)
        Me.X.Name = "X"
        Me.X.ShowClearIcon = False
        Me.X.ShowSaveIcon = False
        Me.X.Size = New System.Drawing.Size(57, 30)
        Me.X.StartUp = 2
        Me.X.TabIndex = 24
        Me.X.TextSize = 8
        Me.X.TxtBackColor = True
        Me.X.TxtColor = System.Drawing.Color.White
        Me.X.txtReadOnly = False
        Me.X.TxtSelect = New Integer() {1, 0}
        '
        'AddEditTopField
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 440)
        Me.Controls.Add(Me.T)
        Me.Controls.Add(Me.H)
        Me.Controls.Add(Me.W)
        Me.Controls.Add(Me.Y)
        Me.Controls.Add(Me.txt)
        Me.Controls.Add(Me.X)
        Me.Controls.Add(Me.btColor)
        Me.Controls.Add(Me.cbBloc)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CB)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Name = "AddEditTopField"
        Me.Text = "AddEditTopField"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents X As Al_Mohasib.TxtBox
    Friend WithEvents Y As Al_Mohasib.TxtBox
    Friend WithEvents W As Al_Mohasib.TxtBox
    Friend WithEvents H As Al_Mohasib.TxtBox
    Friend WithEvents T As Al_Mohasib.TxtBox
    Friend WithEvents txt As Al_Mohasib.TxtBox
End Class
