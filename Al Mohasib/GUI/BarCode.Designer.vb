<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BarCode1
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
        Me.Pb = New System.Windows.Forms.PictureBox()
        Me.EaN13Barcode1 = New MyBarcode.EAN13Barcode()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PlCommande = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btImprimer = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PrintDocument2 = New System.Drawing.Printing.PrintDocument()
        Me.TXTW = New Al_Mohasib.TxtBox()
        Me.TXTH = New Al_Mohasib.TxtBox()
        Me.txtX = New Al_Mohasib.TxtBox()
        Me.txtZ2 = New Al_Mohasib.TxtBox()
        Me.txtF2 = New Al_Mohasib.TxtBox()
        Me.txtZ1 = New Al_Mohasib.TxtBox()
        Me.txtF1 = New Al_Mohasib.TxtBox()
        Me.TxtBox4 = New Al_Mohasib.TxtBox()
        Me.TxtBox3 = New Al_Mohasib.TxtBox()
        Me.TxtBox2 = New Al_Mohasib.TxtBox()
        Me.TxtBox6 = New Al_Mohasib.TxtBox()
        Me.TxtBox5 = New Al_Mohasib.TxtBox()
        Me.TxtBox1 = New Al_Mohasib.TxtBox()
        Me.txtY = New Al_Mohasib.TxtBox()
        Me.txtQte = New Al_Mohasib.TxtBox()
        Me.Pl.SuspendLayout()
        CType(Me.Pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PlCommande.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pl
        '
        Me.Pl.AutoScroll = True
        Me.Pl.BackColor = System.Drawing.Color.White
        Me.Pl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Pl.Controls.Add(Me.Pb)
        Me.Pl.Controls.Add(Me.EaN13Barcode1)
        Me.Pl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pl.Location = New System.Drawing.Point(0, 0)
        Me.Pl.Name = "Pl"
        Me.Pl.Size = New System.Drawing.Size(360, 293)
        Me.Pl.TabIndex = 3
        '
        'Pb
        '
        Me.Pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Pb.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pb.Location = New System.Drawing.Point(0, 141)
        Me.Pb.Name = "Pb"
        Me.Pb.Size = New System.Drawing.Size(343, 239)
        Me.Pb.TabIndex = 1
        Me.Pb.TabStop = False
        '
        'EaN13Barcode1
        '
        Me.EaN13Barcode1.BackColor = System.Drawing.Color.White
        Me.EaN13Barcode1.BarHeight = 0.0R
        Me.EaN13Barcode1.BarWidth = 0.33R
        Me.EaN13Barcode1.Font = New System.Drawing.Font("Arial", 18.0!)
        Me.EaN13Barcode1.Location = New System.Drawing.Point(62, -10)
        Me.EaN13Barcode1.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.EaN13Barcode1.Name = "EaN13Barcode1"
        Me.EaN13Barcode1.ShowBarcodeText = True
        Me.EaN13Barcode1.ShowCheckSum = True
        Me.EaN13Barcode1.Size = New System.Drawing.Size(239, 151)
        Me.EaN13Barcode1.TabIndex = 0
        Me.EaN13Barcode1.Value = "000000000000"
        Me.EaN13Barcode1.Visible = False
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
        Me.PlCommande.Controls.Add(Me.Button3)
        Me.PlCommande.Controls.Add(Me.btImprimer)
        Me.PlCommande.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PlCommande.Location = New System.Drawing.Point(0, 293)
        Me.PlCommande.Name = "PlCommande"
        Me.PlCommande.Size = New System.Drawing.Size(679, 42)
        Me.PlCommande.TabIndex = 4
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
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(380, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(107, 30)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Imprimer"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
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
        Me.Panel1.Controls.Add(Me.TxtBox4)
        Me.Panel1.Controls.Add(Me.TxtBox3)
        Me.Panel1.Controls.Add(Me.TxtBox2)
        Me.Panel1.Controls.Add(Me.TxtBox6)
        Me.Panel1.Controls.Add(Me.TxtBox5)
        Me.Panel1.Controls.Add(Me.TxtBox1)
        Me.Panel1.Controls.Add(Me.txtY)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(360, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(319, 293)
        Me.Panel1.TabIndex = 7
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(168, 224)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox1.TabIndex = 7
        Me.CheckBox1.Text = "Rayonnage"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(252, 174)
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
        Me.Button1.Location = New System.Drawing.Point(252, 125)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(55, 30)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 158)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Police Prix"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Police Titre"
        '
        'PrintDocument2
        '
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
        'txtZ2
        '
        Me.txtZ2.BackColor = System.Drawing.Color.White
        Me.txtZ2.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtZ2.IsNumiric = True
        Me.txtZ2.Location = New System.Drawing.Point(184, 174)
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
        Me.txtF2.Location = New System.Drawing.Point(19, 174)
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
        Me.txtZ1.Location = New System.Drawing.Point(184, 125)
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
        Me.txtF1.Location = New System.Drawing.Point(19, 125)
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
        'TxtBox4
        '
        Me.TxtBox4.BackColor = System.Drawing.Color.White
        Me.TxtBox4.BorderColor = System.Drawing.SystemColors.ControlText
        Me.TxtBox4.IsNumiric = True
        Me.TxtBox4.Location = New System.Drawing.Point(81, 259)
        Me.TxtBox4.MinimumSize = New System.Drawing.Size(0, 30)
        Me.TxtBox4.Name = "TxtBox4"
        Me.TxtBox4.ShowClearIcon = False
        Me.TxtBox4.ShowSaveIcon = False
        Me.TxtBox4.Size = New System.Drawing.Size(40, 30)
        Me.TxtBox4.StartUp = 2
        Me.TxtBox4.TabIndex = 6
        Me.TxtBox4.TextSize = 8
        Me.TxtBox4.TxtBackColor = True
        Me.TxtBox4.TxtColor = System.Drawing.Color.White
        Me.TxtBox4.txtReadOnly = False
        Me.TxtBox4.TxtSelect = New Integer() {1, 0}
        '
        'TxtBox3
        '
        Me.TxtBox3.BackColor = System.Drawing.Color.White
        Me.TxtBox3.BorderColor = System.Drawing.SystemColors.ControlText
        Me.TxtBox3.IsNumiric = True
        Me.TxtBox3.Location = New System.Drawing.Point(20, 256)
        Me.TxtBox3.MinimumSize = New System.Drawing.Size(0, 30)
        Me.TxtBox3.Name = "TxtBox3"
        Me.TxtBox3.ShowClearIcon = False
        Me.TxtBox3.ShowSaveIcon = False
        Me.TxtBox3.Size = New System.Drawing.Size(40, 30)
        Me.TxtBox3.StartUp = 2
        Me.TxtBox3.TabIndex = 6
        Me.TxtBox3.TextSize = 8
        Me.TxtBox3.TxtBackColor = True
        Me.TxtBox3.TxtColor = System.Drawing.Color.White
        Me.TxtBox3.txtReadOnly = False
        Me.TxtBox3.TxtSelect = New Integer() {1, 0}
        '
        'TxtBox2
        '
        Me.TxtBox2.BackColor = System.Drawing.Color.White
        Me.TxtBox2.BorderColor = System.Drawing.SystemColors.ControlText
        Me.TxtBox2.IsNumiric = True
        Me.TxtBox2.Location = New System.Drawing.Point(81, 224)
        Me.TxtBox2.MinimumSize = New System.Drawing.Size(0, 30)
        Me.TxtBox2.Name = "TxtBox2"
        Me.TxtBox2.ShowClearIcon = False
        Me.TxtBox2.ShowSaveIcon = False
        Me.TxtBox2.Size = New System.Drawing.Size(40, 30)
        Me.TxtBox2.StartUp = 2
        Me.TxtBox2.TabIndex = 6
        Me.TxtBox2.TextSize = 8
        Me.TxtBox2.TxtBackColor = True
        Me.TxtBox2.TxtColor = System.Drawing.Color.White
        Me.TxtBox2.txtReadOnly = False
        Me.TxtBox2.TxtSelect = New Integer() {1, 0}
        '
        'TxtBox6
        '
        Me.TxtBox6.BackColor = System.Drawing.Color.White
        Me.TxtBox6.BorderColor = System.Drawing.SystemColors.ControlText
        Me.TxtBox6.IsNumiric = True
        Me.TxtBox6.Location = New System.Drawing.Point(267, 256)
        Me.TxtBox6.MinimumSize = New System.Drawing.Size(0, 30)
        Me.TxtBox6.Name = "TxtBox6"
        Me.TxtBox6.ShowClearIcon = False
        Me.TxtBox6.ShowSaveIcon = False
        Me.TxtBox6.Size = New System.Drawing.Size(40, 30)
        Me.TxtBox6.StartUp = 2
        Me.TxtBox6.TabIndex = 6
        Me.TxtBox6.TextSize = 8
        Me.TxtBox6.TxtBackColor = True
        Me.TxtBox6.TxtColor = System.Drawing.Color.White
        Me.TxtBox6.txtReadOnly = False
        Me.TxtBox6.TxtSelect = New Integer() {1, 0}
        '
        'TxtBox5
        '
        Me.TxtBox5.BackColor = System.Drawing.Color.White
        Me.TxtBox5.BorderColor = System.Drawing.SystemColors.ControlText
        Me.TxtBox5.IsNumiric = True
        Me.TxtBox5.Location = New System.Drawing.Point(267, 224)
        Me.TxtBox5.MinimumSize = New System.Drawing.Size(0, 30)
        Me.TxtBox5.Name = "TxtBox5"
        Me.TxtBox5.ShowClearIcon = False
        Me.TxtBox5.ShowSaveIcon = False
        Me.TxtBox5.Size = New System.Drawing.Size(40, 30)
        Me.TxtBox5.StartUp = 2
        Me.TxtBox5.TabIndex = 6
        Me.TxtBox5.TextSize = 8
        Me.TxtBox5.TxtBackColor = True
        Me.TxtBox5.TxtColor = System.Drawing.Color.White
        Me.TxtBox5.txtReadOnly = False
        Me.TxtBox5.TxtSelect = New Integer() {1, 0}
        '
        'TxtBox1
        '
        Me.TxtBox1.BackColor = System.Drawing.Color.White
        Me.TxtBox1.BorderColor = System.Drawing.SystemColors.ControlText
        Me.TxtBox1.IsNumiric = True
        Me.TxtBox1.Location = New System.Drawing.Point(20, 224)
        Me.TxtBox1.MinimumSize = New System.Drawing.Size(0, 30)
        Me.TxtBox1.Name = "TxtBox1"
        Me.TxtBox1.ShowClearIcon = False
        Me.TxtBox1.ShowSaveIcon = False
        Me.TxtBox1.Size = New System.Drawing.Size(40, 30)
        Me.TxtBox1.StartUp = 2
        Me.TxtBox1.TabIndex = 6
        Me.TxtBox1.TextSize = 8
        Me.TxtBox1.TxtBackColor = True
        Me.TxtBox1.TxtColor = System.Drawing.Color.White
        Me.TxtBox1.txtReadOnly = False
        Me.TxtBox1.TxtSelect = New Integer() {1, 0}
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
        'BarCode1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 335)
        Me.Controls.Add(Me.Pl)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PlCommande)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BarCode1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BarCode"
        Me.Pl.ResumeLayout(False)
        CType(Me.Pb, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Pb As System.Windows.Forms.PictureBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents PrintDocument2 As System.Drawing.Printing.PrintDocument
    Friend WithEvents TxtBox4 As Al_Mohasib.TxtBox
    Friend WithEvents TxtBox3 As Al_Mohasib.TxtBox
    Friend WithEvents TxtBox2 As Al_Mohasib.TxtBox
    Friend WithEvents TxtBox1 As Al_Mohasib.TxtBox
    Friend WithEvents TxtBox5 As Al_Mohasib.TxtBox
    Friend WithEvents TxtBox6 As Al_Mohasib.TxtBox
End Class
