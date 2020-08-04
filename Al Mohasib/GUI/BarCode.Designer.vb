<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BarCode
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
        Me.Pl = New System.Windows.Forms.Panel()
        Me.EaN13Barcode1 = New MyBarcode.EAN13Barcode()
        Me.txtX = New Al_Mohasib.TxtBox()
        Me.txtY = New Al_Mohasib.TxtBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PlCommande = New System.Windows.Forms.Panel()
        Me.txtQte = New Al_Mohasib.TxtBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btImprimer = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTH = New Al_Mohasib.TxtBox()
        Me.TXTW = New Al_Mohasib.TxtBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtZ2 = New Al_Mohasib.TxtBox()
        Me.txtF2 = New Al_Mohasib.TxtBox()
        Me.txtZ1 = New Al_Mohasib.TxtBox()
        Me.txtF1 = New Al_Mohasib.TxtBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Pl.SuspendLayout()
        Me.PlCommande.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pl
        '
        Me.Pl.AutoScroll = True
        Me.Pl.BackColor = System.Drawing.Color.White
        Me.Pl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Pl.Controls.Add(Me.EaN13Barcode1)
        Me.Pl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pl.Location = New System.Drawing.Point(0, 0)
        Me.Pl.Name = "Pl"
        Me.Pl.Size = New System.Drawing.Size(360, 280)
        Me.Pl.TabIndex = 3
        '
        'EaN13Barcode1
        '
        Me.EaN13Barcode1.BackColor = System.Drawing.Color.White
        Me.EaN13Barcode1.BarHeight = 0.0R
        Me.EaN13Barcode1.BarWidth = 0.33R
        Me.EaN13Barcode1.Font = New System.Drawing.Font("Arial", 18.0!)
        Me.EaN13Barcode1.Location = New System.Drawing.Point(43, 48)
        Me.EaN13Barcode1.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.EaN13Barcode1.Name = "EaN13Barcode1"
        Me.EaN13Barcode1.ShowBarcodeText = True
        Me.EaN13Barcode1.ShowCheckSum = True
        Me.EaN13Barcode1.Size = New System.Drawing.Size(239, 151)
        Me.EaN13Barcode1.TabIndex = 0
        Me.EaN13Barcode1.Value = "000000000000"
        Me.EaN13Barcode1.Visible = False
        '
        'txtX
        '
        Me.txtX.BackColor = System.Drawing.Color.White
        Me.txtX.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtX.IsNumiric = True
        Me.txtX.Location = New System.Drawing.Point(42, 12)
        Me.txtX.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtX.Name = "txtX"
        Me.txtX.ShowClearIcon = False
        Me.txtX.ShowSaveIcon = False
        Me.txtX.Size = New System.Drawing.Size(79, 30)
        Me.txtX.StartUp = 2
        Me.txtX.TabIndex = 6
        Me.txtX.TextSize = 8
        Me.txtX.TxtBackColor = True
        Me.txtX.TxtColor = System.Drawing.Color.White
        Me.txtX.txtReadOnly = False
        Me.txtX.TxtSelect = New Integer() {1, 0}
        '
        'txtY
        '
        Me.txtY.BackColor = System.Drawing.Color.White
        Me.txtY.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtY.IsNumiric = True
        Me.txtY.Location = New System.Drawing.Point(42, 48)
        Me.txtY.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtY.Name = "txtY"
        Me.txtY.ShowClearIcon = False
        Me.txtY.ShowSaveIcon = False
        Me.txtY.Size = New System.Drawing.Size(79, 30)
        Me.txtY.StartUp = 2
        Me.txtY.TabIndex = 6
        Me.txtY.TextSize = 8
        Me.txtY.TxtBackColor = True
        Me.txtY.TxtColor = System.Drawing.Color.White
        Me.txtY.txtReadOnly = False
        Me.txtY.TxtSelect = New Integer() {1, 0}
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Y :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "X :"
        '
        'PlCommande
        '
        Me.PlCommande.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.PlCommande.Controls.Add(Me.txtQte)
        Me.PlCommande.Controls.Add(Me.Label1)
        Me.PlCommande.Controls.Add(Me.btImprimer)
        Me.PlCommande.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PlCommande.Location = New System.Drawing.Point(0, 280)
        Me.PlCommande.Name = "PlCommande"
        Me.PlCommande.Size = New System.Drawing.Size(679, 42)
        Me.PlCommande.TabIndex = 4
        '
        'txtQte
        '
        Me.txtQte.BackColor = System.Drawing.Color.White
        Me.txtQte.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtQte.IsNumiric = True
        Me.txtQte.Location = New System.Drawing.Point(87, 6)
        Me.txtQte.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtQte.Name = "txtQte"
        Me.txtQte.ShowClearIcon = False
        Me.txtQte.ShowSaveIcon = False
        Me.txtQte.Size = New System.Drawing.Size(164, 30)
        Me.txtQte.StartUp = 2
        Me.txtQte.TabIndex = 6
        Me.txtQte.TextSize = 8
        Me.txtQte.TxtBackColor = True
        Me.txtQte.TxtColor = System.Drawing.Color.White
        Me.txtQte.txtReadOnly = False
        Me.txtQte.TxtSelect = New Integer() {1, 0}
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Nbr Copies : "
        '
        'btImprimer
        '
        Me.btImprimer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btImprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btImprimer.Location = New System.Drawing.Point(560, 6)
        Me.btImprimer.Name = "btImprimer"
        Me.btImprimer.Size = New System.Drawing.Size(107, 30)
        Me.btImprimer.TabIndex = 4
        Me.btImprimer.Text = "Imprimer"
        Me.btImprimer.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(190, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "W :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(190, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(21, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "H :"
        '
        'TXTH
        '
        Me.TXTH.BackColor = System.Drawing.Color.White
        Me.TXTH.BorderColor = System.Drawing.SystemColors.ControlText
        Me.TXTH.IsNumiric = True
        Me.TXTH.Location = New System.Drawing.Point(216, 48)
        Me.TXTH.MinimumSize = New System.Drawing.Size(0, 30)
        Me.TXTH.Name = "TXTH"
        Me.TXTH.ShowClearIcon = False
        Me.TXTH.ShowSaveIcon = False
        Me.TXTH.Size = New System.Drawing.Size(79, 30)
        Me.TXTH.StartUp = 2
        Me.TXTH.TabIndex = 6
        Me.TXTH.TextSize = 8
        Me.TXTH.TxtBackColor = True
        Me.TXTH.TxtColor = System.Drawing.Color.White
        Me.TXTH.txtReadOnly = False
        Me.TXTH.TxtSelect = New Integer() {1, 0}
        '
        'TXTW
        '
        Me.TXTW.BackColor = System.Drawing.Color.White
        Me.TXTW.BorderColor = System.Drawing.SystemColors.ControlText
        Me.TXTW.IsNumiric = True
        Me.TXTW.Location = New System.Drawing.Point(216, 12)
        Me.TXTW.MinimumSize = New System.Drawing.Size(0, 30)
        Me.TXTW.Name = "TXTW"
        Me.TXTW.ShowClearIcon = False
        Me.TXTW.ShowSaveIcon = False
        Me.TXTW.Size = New System.Drawing.Size(79, 30)
        Me.TXTW.StartUp = 2
        Me.TXTW.TabIndex = 6
        Me.TXTW.TextSize = 8
        Me.TXTW.TxtBackColor = True
        Me.TXTW.TxtColor = System.Drawing.Color.White
        Me.TXTW.txtReadOnly = False
        Me.TXTW.TxtSelect = New Integer() {1, 0}
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.TXTW)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.TXTH)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtX)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtZ2)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtF2)
        Me.Panel1.Controls.Add(Me.txtZ1)
        Me.Panel1.Controls.Add(Me.txtF1)
        Me.Panel1.Controls.Add(Me.txtY)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(360, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(319, 280)
        Me.Panel1.TabIndex = 7
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(252, 201)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(55, 30)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(252, 133)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(55, 30)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 185)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Police Prix"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Police Titre"
        '
        'txtZ2
        '
        Me.txtZ2.BackColor = System.Drawing.Color.White
        Me.txtZ2.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtZ2.IsNumiric = True
        Me.txtZ2.Location = New System.Drawing.Point(184, 201)
        Me.txtZ2.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtZ2.Name = "txtZ2"
        Me.txtZ2.ShowClearIcon = False
        Me.txtZ2.ShowSaveIcon = False
        Me.txtZ2.Size = New System.Drawing.Size(53, 30)
        Me.txtZ2.StartUp = 2
        Me.txtZ2.TabIndex = 6
        Me.txtZ2.TextSize = 8
        Me.txtZ2.TxtBackColor = True
        Me.txtZ2.TxtColor = System.Drawing.Color.White
        Me.txtZ2.txtReadOnly = False
        Me.txtZ2.TxtSelect = New Integer() {1, 0}
        '
        'txtF2
        '
        Me.txtF2.BackColor = System.Drawing.Color.White
        Me.txtF2.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtF2.IsNumiric = True
        Me.txtF2.Location = New System.Drawing.Point(19, 201)
        Me.txtF2.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtF2.Name = "txtF2"
        Me.txtF2.ShowClearIcon = False
        Me.txtF2.ShowSaveIcon = False
        Me.txtF2.Size = New System.Drawing.Size(159, 30)
        Me.txtF2.StartUp = 2
        Me.txtF2.TabIndex = 6
        Me.txtF2.TextSize = 8
        Me.txtF2.TxtBackColor = True
        Me.txtF2.TxtColor = System.Drawing.Color.White
        Me.txtF2.txtReadOnly = False
        Me.txtF2.TxtSelect = New Integer() {1, 0}
        '
        'txtZ1
        '
        Me.txtZ1.BackColor = System.Drawing.Color.White
        Me.txtZ1.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtZ1.IsNumiric = True
        Me.txtZ1.Location = New System.Drawing.Point(184, 133)
        Me.txtZ1.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtZ1.Name = "txtZ1"
        Me.txtZ1.ShowClearIcon = False
        Me.txtZ1.ShowSaveIcon = False
        Me.txtZ1.Size = New System.Drawing.Size(53, 30)
        Me.txtZ1.StartUp = 2
        Me.txtZ1.TabIndex = 6
        Me.txtZ1.TextSize = 8
        Me.txtZ1.TxtBackColor = True
        Me.txtZ1.TxtColor = System.Drawing.Color.White
        Me.txtZ1.txtReadOnly = False
        Me.txtZ1.TxtSelect = New Integer() {1, 0}
        '
        'txtF1
        '
        Me.txtF1.BackColor = System.Drawing.Color.White
        Me.txtF1.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtF1.IsNumiric = True
        Me.txtF1.Location = New System.Drawing.Point(19, 133)
        Me.txtF1.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtF1.Name = "txtF1"
        Me.txtF1.ShowClearIcon = False
        Me.txtF1.ShowSaveIcon = False
        Me.txtF1.Size = New System.Drawing.Size(159, 30)
        Me.txtF1.StartUp = 2
        Me.txtF1.TabIndex = 6
        Me.txtF1.TextSize = 8
        Me.txtF1.TxtBackColor = True
        Me.txtF1.TxtColor = System.Drawing.Color.White
        Me.txtF1.txtReadOnly = False
        Me.txtF1.TxtSelect = New Integer() {1, 0}
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(19, 247)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox1.TabIndex = 7
        Me.CheckBox1.Text = "Rayonnage"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'BarCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 322)
        Me.Controls.Add(Me.Pl)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PlCommande)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BarCode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BarCode"
        Me.Pl.ResumeLayout(False)
        Me.PlCommande.ResumeLayout(False)
        Me.PlCommande.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pl As System.Windows.Forms.Panel
    Friend WithEvents EaN13Barcode1 As MyBarcode.EAN13Barcode
    Friend WithEvents PlCommande As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btImprimer As System.Windows.Forms.Button
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtX As Al_Mohasib.TxtBox
    Friend WithEvents txtY As Al_Mohasib.TxtBox
    Friend WithEvents txtQte As Al_Mohasib.TxtBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXTH As Al_Mohasib.TxtBox
    Friend WithEvents TXTW As Al_Mohasib.TxtBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtZ2 As Al_Mohasib.TxtBox
    Friend WithEvents txtF2 As Al_Mohasib.TxtBox
    Friend WithEvents txtZ1 As Al_Mohasib.TxtBox
    Friend WithEvents txtF1 As Al_Mohasib.TxtBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
