<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProfitProduitRapport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProfitProduitRapport))
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.plTxt = New System.Windows.Forms.Panel()
        Me.txtRP = New Al_Mohasib.TxtBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Panel24 = New System.Windows.Forms.Panel()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel29 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dg_D = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lbLnbr = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel8.SuspendLayout()
        Me.plTxt.SuspendLayout()
        Me.Panel24.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dg_D, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.White
        Me.Panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel8.Controls.Add(Me.plTxt)
        Me.Panel8.Controls.Add(Me.Button1)
        Me.Panel8.Controls.Add(Me.Button3)
        Me.Panel8.Controls.Add(Me.Button2)
        Me.Panel8.Controls.Add(Me.Button11)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(986, 85)
        Me.Panel8.TabIndex = 16
        '
        'plTxt
        '
        Me.plTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.plTxt.Controls.Add(Me.txtRP)
        Me.plTxt.Controls.Add(Me.Label12)
        Me.plTxt.Enabled = False
        Me.plTxt.Location = New System.Drawing.Point(12, 28)
        Me.plTxt.Name = "plTxt"
        Me.plTxt.Size = New System.Drawing.Size(355, 32)
        Me.plTxt.TabIndex = 9
        '
        'txtRP
        '
        Me.txtRP.BackColor = System.Drawing.Color.Transparent
        Me.txtRP.BorderColor = System.Drawing.Color.Transparent
        Me.txtRP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRP.IsNumiric = False
        Me.txtRP.Location = New System.Drawing.Point(58, 0)
        Me.txtRP.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtRP.Name = "txtRP"
        Me.txtRP.ShowClearIcon = False
        Me.txtRP.ShowSaveIcon = False
        Me.txtRP.Size = New System.Drawing.Size(295, 30)
        Me.txtRP.StartUp = 2
        Me.txtRP.TabIndex = 11
        Me.txtRP.TextSize = 8
        Me.txtRP.TxtBackColor = True
        Me.txtRP.TxtColor = System.Drawing.Color.White
        Me.txtRP.txtReadOnly = False
        Me.txtRP.TxtSelect = New Integer() {1, 0}
        '
        'Label12
        '
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label12.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(0, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 30)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Rapport"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(857, 27)
        Me.Button1.Name = "Button1"
        Me.Button1.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Button1.Size = New System.Drawing.Size(117, 33)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Rapport"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = Global.Al_Mohasib.My.Resources.Resources.FACTURE_20
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(743, 28)
        Me.Button3.Name = "Button3"
        Me.Button3.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Button3.Size = New System.Drawing.Size(91, 33)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "Ventes"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = Global.Al_Mohasib.My.Resources.Resources.company
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(634, 27)
        Me.Button2.Name = "Button2"
        Me.Button2.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Button2.Size = New System.Drawing.Size(103, 33)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Achats"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.Image = CType(resources.GetObject("Button11.Image"), System.Drawing.Image)
        Me.Button11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button11.Location = New System.Drawing.Point(372, 27)
        Me.Button11.Name = "Button11"
        Me.Button11.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Button11.Size = New System.Drawing.Size(113, 33)
        Me.Button11.TabIndex = 10
        Me.Button11.Text = "Load ..."
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Panel24
        '
        Me.Panel24.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel24.Controls.Add(Me.Button10)
        Me.Panel24.Controls.Add(Me.Button9)
        Me.Panel24.Controls.Add(Me.Button7)
        Me.Panel24.Controls.Add(Me.Button8)
        Me.Panel24.Controls.Add(Me.Button6)
        Me.Panel24.Controls.Add(Me.Button5)
        Me.Panel24.Controls.Add(Me.Button4)
        Me.Panel24.Controls.Add(Me.Panel29)
        Me.Panel24.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel24.Location = New System.Drawing.Point(0, 85)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Size = New System.Drawing.Size(986, 38)
        Me.Panel24.TabIndex = 17
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.Transparent
        Me.Button10.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button10.FlatAppearance.BorderSize = 0
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.Image = Global.Al_Mohasib.My.Resources.Resources.sell
        Me.Button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button10.Location = New System.Drawing.Point(642, 2)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(155, 36)
        Me.Button10.TabIndex = 22
        Me.Button10.Text = "Cadeau de retour"
        Me.Button10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button10.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.Transparent
        Me.Button9.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button9.FlatAppearance.BorderSize = 0
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button9.Location = New System.Drawing.Point(797, 2)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(60, 36)
        Me.Button9.TabIndex = 21
        Me.Button9.Text = "       "
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.Transparent
        Me.Button7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button7.FlatAppearance.BorderSize = 0
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Image = Global.Al_Mohasib.My.Resources.Resources.SAVE_20
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.Location = New System.Drawing.Point(164, 2)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(108, 36)
        Me.Button7.TabIndex = 19
        Me.Button7.Text = "Enregistrer"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.Transparent
        Me.Button8.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button8.FlatAppearance.BorderSize = 0
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.Location = New System.Drawing.Point(136, 2)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(28, 36)
        Me.Button8.TabIndex = 20
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Image = Global.Al_Mohasib.My.Resources.Resources.buy1
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(28, 2)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(108, 36)
        Me.Button6.TabIndex = 18
        Me.Button6.Text = "Nouveau"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Transparent
        Me.Button5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Image = Global.Al_Mohasib.My.Resources.Resources.iconfinder_pdf_3745__1_
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(857, 2)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(129, 36)
        Me.Button5.TabIndex = 17
        Me.Button5.Text = "Exporter            "
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(0, 2)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(28, 36)
        Me.Button4.TabIndex = 16
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Panel29
        '
        Me.Panel29.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel29.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel29.Location = New System.Drawing.Point(0, 0)
        Me.Panel29.Name = "Panel29"
        Me.Panel29.Size = New System.Drawing.Size(986, 2)
        Me.Panel29.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.dg_D)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 123)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(986, 337)
        Me.Panel1.TabIndex = 18
        '
        'dg_D
        '
        Me.dg_D.AllowUserToAddRows = False
        Me.dg_D.AllowUserToDeleteRows = False
        Me.dg_D.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dg_D.BackgroundColor = System.Drawing.Color.White
        Me.dg_D.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_D.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_D.Location = New System.Drawing.Point(0, 2)
        Me.dg_D.Name = "dg_D"
        Me.dg_D.ReadOnly = True
        Me.dg_D.RowHeadersVisible = False
        Me.dg_D.RowTemplate.Height = 33
        Me.dg_D.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_D.Size = New System.Drawing.Size(986, 335)
        Me.dg_D.TabIndex = 17
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(986, 2)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.lbLnbr)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 460)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(986, 38)
        Me.Panel3.TabIndex = 19
        '
        'lbLnbr
        '
        Me.lbLnbr.BackColor = System.Drawing.Color.LightGray
        Me.lbLnbr.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbLnbr.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLnbr.Location = New System.Drawing.Point(71, 2)
        Me.lbLnbr.Name = "lbLnbr"
        Me.lbLnbr.Padding = New System.Windows.Forms.Padding(11, 0, 11, 0)
        Me.lbLnbr.Size = New System.Drawing.Size(140, 36)
        Me.lbLnbr.TabIndex = 20
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
        Me.Label14.Size = New System.Drawing.Size(71, 36)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "Nbre :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(986, 2)
        Me.Panel4.TabIndex = 1
        '
        'ProfitProduitRapport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(986, 498)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel24)
        Me.Controls.Add(Me.Panel8)
        Me.Name = "ProfitProduitRapport"
        Me.Text = "R A P P O R T"
        Me.Panel8.ResumeLayout(False)
        Me.plTxt.ResumeLayout(False)
        Me.Panel24.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dg_D, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents plTxt As System.Windows.Forms.Panel
    Friend WithEvents txtRP As Al_Mohasib.TxtBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Panel24 As System.Windows.Forms.Panel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Panel29 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents dg_D As System.Windows.Forms.DataGridView
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lbLnbr As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
End Class
