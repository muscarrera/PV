<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RPanel
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RPanel))
        Me.PlTop = New System.Windows.Forms.Panel()
        Me.PlBody = New System.Windows.Forms.Panel()
        Me.Pl = New System.Windows.Forms.Panel()
        Me.PlHeader = New System.Windows.Forms.Panel()
        Me.lbFree = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lbProfit = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LbVidal = New System.Windows.Forms.Label()
        Me.lbDh = New System.Windows.Forms.Label()
        Me.lbremise = New System.Windows.Forms.Label()
        Me.lbHT = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LbTva = New System.Windows.Forms.Label()
        Me.Lbavc = New System.Windows.Forms.Label()
        Me.LbSum = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtSave = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BtBlPrint = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BtPrint = New System.Windows.Forms.Button()
        Me.BtDel = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.plDate = New System.Windows.Forms.Panel()
        Me.lbDate = New System.Windows.Forms.Label()
        Me.plPromo = New System.Windows.Forms.Panel()
        Me.lbPointUtiliser = New System.Windows.Forms.Label()
        Me.lbUsedPoint = New System.Windows.Forms.Label()
        Me.lbTotalPoint = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbPoint = New System.Windows.Forms.Label()
        Me.plAutoPromo = New System.Windows.Forms.Panel()
        Me.lbSelectedAutoPoint = New System.Windows.Forms.Label()
        Me.lbAutoPrNbr = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.plCafeCmd = New System.Windows.Forms.Panel()
        Me.btCalc = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btMinis = New System.Windows.Forms.Button()
        Me.btPlus = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CP = New Al_Mohasib.CPanel()
        Me.BwPromos = New System.ComponentModel.BackgroundWorker()
        Me.PlBody.SuspendLayout()
        Me.PlHeader.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.plDate.SuspendLayout()
        Me.plPromo.SuspendLayout()
        Me.plAutoPromo.SuspendLayout()
        Me.plCafeCmd.SuspendLayout()
        Me.SuspendLayout()
        '
        'PlTop
        '
        Me.PlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PlTop.Location = New System.Drawing.Point(0, 0)
        Me.PlTop.Margin = New System.Windows.Forms.Padding(4)
        Me.PlTop.Name = "PlTop"
        Me.PlTop.Size = New System.Drawing.Size(513, 12)
        Me.PlTop.TabIndex = 1
        '
        'PlBody
        '
        Me.PlBody.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PlBody.Controls.Add(Me.Pl)
        Me.PlBody.Controls.Add(Me.PlHeader)
        Me.PlBody.Controls.Add(Me.Panel1)
        Me.PlBody.Controls.Add(Me.plCafeCmd)
        Me.PlBody.Controls.Add(Me.CP)
        Me.PlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PlBody.Location = New System.Drawing.Point(0, 12)
        Me.PlBody.Margin = New System.Windows.Forms.Padding(4)
        Me.PlBody.Name = "PlBody"
        Me.PlBody.Size = New System.Drawing.Size(513, 693)
        Me.PlBody.TabIndex = 3
        '
        'Pl
        '
        Me.Pl.AutoScroll = True
        Me.Pl.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Pl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pl.Location = New System.Drawing.Point(0, 0)
        Me.Pl.Margin = New System.Windows.Forms.Padding(4)
        Me.Pl.Name = "Pl"
        Me.Pl.Size = New System.Drawing.Size(513, 155)
        Me.Pl.TabIndex = 2
        '
        'PlHeader
        '
        Me.PlHeader.Controls.Add(Me.lbFree)
        Me.PlHeader.Controls.Add(Me.Panel3)
        Me.PlHeader.Controls.Add(Me.lbDh)
        Me.PlHeader.Controls.Add(Me.lbremise)
        Me.PlHeader.Controls.Add(Me.lbHT)
        Me.PlHeader.Controls.Add(Me.Label2)
        Me.PlHeader.Controls.Add(Me.Label1)
        Me.PlHeader.Controls.Add(Me.LbTva)
        Me.PlHeader.Controls.Add(Me.Lbavc)
        Me.PlHeader.Controls.Add(Me.LbSum)
        Me.PlHeader.Controls.Add(Me.ShapeContainer1)
        Me.PlHeader.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.PlHeader.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PlHeader.Location = New System.Drawing.Point(0, 155)
        Me.PlHeader.Margin = New System.Windows.Forms.Padding(4)
        Me.PlHeader.Name = "PlHeader"
        Me.PlHeader.Size = New System.Drawing.Size(513, 73)
        Me.PlHeader.TabIndex = 1
        '
        'lbFree
        '
        Me.lbFree.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbFree.BackColor = System.Drawing.Color.Maroon
        Me.lbFree.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFree.ForeColor = System.Drawing.Color.White
        Me.lbFree.Location = New System.Drawing.Point(24, 49)
        Me.lbFree.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbFree.Name = "lbFree"
        Me.lbFree.Size = New System.Drawing.Size(176, 21)
        Me.lbFree.TabIndex = 1
        Me.lbFree.Text = "--"
        Me.lbFree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbFree.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lbProfit)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.LbVidal)
        Me.Panel3.Location = New System.Drawing.Point(26, 7)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(174, 22)
        Me.Panel3.TabIndex = 4
        '
        'lbProfit
        '
        Me.lbProfit.AutoSize = True
        Me.lbProfit.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbProfit.Location = New System.Drawing.Point(75, 0)
        Me.lbProfit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbProfit.Name = "lbProfit"
        Me.lbProfit.Size = New System.Drawing.Size(16, 17)
        Me.lbProfit.TabIndex = 2
        Me.lbProfit.Text = "[]"
        Me.lbProfit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbProfit.Visible = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Green
        Me.Label10.Location = New System.Drawing.Point(60, 0)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(15, 22)
        Me.Label10.TabIndex = 5
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LbVidal
        '
        Me.LbVidal.AutoSize = True
        Me.LbVidal.Dock = System.Windows.Forms.DockStyle.Left
        Me.LbVidal.Location = New System.Drawing.Point(0, 0)
        Me.LbVidal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LbVidal.Name = "LbVidal"
        Me.LbVidal.Size = New System.Drawing.Size(60, 17)
        Me.LbVidal.TabIndex = 2
        Me.LbVidal.Text = "0 - Vidal"
        Me.LbVidal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbDh
        '
        Me.lbDh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbDh.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDh.ForeColor = System.Drawing.Color.Red
        Me.lbDh.Location = New System.Drawing.Point(285, -20)
        Me.lbDh.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbDh.Name = "lbDh"
        Me.lbDh.Size = New System.Drawing.Size(165, 25)
        Me.lbDh.TabIndex = 1
        Me.lbDh.Text = "000"
        Me.lbDh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbremise
        '
        Me.lbremise.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbremise.AutoSize = True
        Me.lbremise.Location = New System.Drawing.Point(24, 31)
        Me.lbremise.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbremise.Name = "lbremise"
        Me.lbremise.Size = New System.Drawing.Size(83, 17)
        Me.lbremise.TabIndex = 1
        Me.lbremise.Text = "Remise =  0"
        Me.lbremise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbHT
        '
        Me.lbHT.AutoSize = True
        Me.lbHT.Location = New System.Drawing.Point(100, 116)
        Me.lbHT.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbHT.Name = "lbHT"
        Me.lbHT.Size = New System.Drawing.Size(60, 17)
        Me.lbHT.TabIndex = 1
        Me.lbHT.Text = "T HT : 0"
        Me.lbHT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbHT.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(281, 11)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "T. TTC :"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(279, 42)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Avance :"
        '
        'LbTva
        '
        Me.LbTva.AutoSize = True
        Me.LbTva.Location = New System.Drawing.Point(15, 127)
        Me.LbTva.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LbTva.Name = "LbTva"
        Me.LbTva.Size = New System.Drawing.Size(64, 17)
        Me.LbTva.TabIndex = 1
        Me.LbTva.Text = "Tva : 0%"
        Me.LbTva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LbTva.Visible = False
        '
        'Lbavc
        '
        Me.Lbavc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbavc.AutoSize = True
        Me.Lbavc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbavc.Location = New System.Drawing.Point(383, 43)
        Me.Lbavc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbavc.Name = "Lbavc"
        Me.Lbavc.Size = New System.Drawing.Size(21, 24)
        Me.Lbavc.TabIndex = 1
        Me.Lbavc.Text = "0"
        '
        'LbSum
        '
        Me.LbSum.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LbSum.AutoSize = True
        Me.LbSum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbSum.ForeColor = System.Drawing.Color.Red
        Me.LbSum.Location = New System.Drawing.Point(379, 9)
        Me.LbSum.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LbSum.Name = "LbSum"
        Me.LbSum.Size = New System.Drawing.Size(66, 25)
        Me.LbSum.TabIndex = 1
        Me.LbSum.Text = "00.00"
        Me.LbSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(513, 73)
        Me.ShapeContainer1.TabIndex = 3
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 211
        Me.LineShape1.X2 = 514
        Me.LineShape1.Y1 = 20
        Me.LineShape1.Y2 = 20
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.bgbuy
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.plDate)
        Me.Panel1.Controls.Add(Me.plPromo)
        Me.Panel1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 228)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(513, 102)
        Me.Panel1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtSave)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.BtBlPrint)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.BtPrint)
        Me.Panel2.Controls.Add(Me.BtDel)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(4)
        Me.Panel2.Size = New System.Drawing.Size(513, 46)
        Me.Panel2.TabIndex = 5
        '
        'BtSave
        '
        Me.BtSave.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.gui_16
        Me.BtSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtSave.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.BtSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtSave.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BtSave.Image = CType(resources.GetObject("BtSave.Image"), System.Drawing.Image)
        Me.BtSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtSave.Location = New System.Drawing.Point(272, 4)
        Me.BtSave.Margin = New System.Windows.Forms.Padding(4)
        Me.BtSave.MaximumSize = New System.Drawing.Size(125, 38)
        Me.BtSave.MinimumSize = New System.Drawing.Size(5, 37)
        Me.BtSave.Name = "BtSave"
        Me.BtSave.Size = New System.Drawing.Size(115, 38)
        Me.BtSave.TabIndex = 0
        Me.BtSave.Text = "   Enreg"
        Me.BtSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtSave.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Green
        Me.Label9.Location = New System.Drawing.Point(387, 4)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(13, 38)
        Me.Label9.TabIndex = 7
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtBlPrint
        '
        Me.BtBlPrint.BackgroundImage = CType(resources.GetObject("BtBlPrint.BackgroundImage"), System.Drawing.Image)
        Me.BtBlPrint.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtBlPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtBlPrint.FlatAppearance.BorderSize = 2
        Me.BtBlPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtBlPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtBlPrint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtBlPrint.Image = CType(resources.GetObject("BtBlPrint.Image"), System.Drawing.Image)
        Me.BtBlPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtBlPrint.Location = New System.Drawing.Point(112, 4)
        Me.BtBlPrint.Margin = New System.Windows.Forms.Padding(4)
        Me.BtBlPrint.MaximumSize = New System.Drawing.Size(0, 38)
        Me.BtBlPrint.MinimumSize = New System.Drawing.Size(4, 38)
        Me.BtBlPrint.Name = "BtBlPrint"
        Me.BtBlPrint.Size = New System.Drawing.Size(4, 38)
        Me.BtBlPrint.TabIndex = 0
        Me.BtBlPrint.Tag = "1"
        Me.BtBlPrint.Text = "B. Liv"
        Me.BtBlPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtBlPrint.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Green
        Me.Label7.Location = New System.Drawing.Point(100, 4)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(12, 38)
        Me.Label7.TabIndex = 5
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtPrint
        '
        Me.BtPrint.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtPrint.BackgroundImage = CType(resources.GetObject("BtPrint.BackgroundImage"), System.Drawing.Image)
        Me.BtPrint.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtPrint.FlatAppearance.BorderSize = 2
        Me.BtPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtPrint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtPrint.Image = CType(resources.GetObject("BtPrint.Image"), System.Drawing.Image)
        Me.BtPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtPrint.Location = New System.Drawing.Point(19, 4)
        Me.BtPrint.Margin = New System.Windows.Forms.Padding(4)
        Me.BtPrint.MinimumSize = New System.Drawing.Size(4, 38)
        Me.BtPrint.Name = "BtPrint"
        Me.BtPrint.Size = New System.Drawing.Size(81, 38)
        Me.BtPrint.TabIndex = 0
        Me.BtPrint.Tag = "0"
        Me.BtPrint.Text = "طـــبع"
        Me.BtPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtPrint.UseVisualStyleBackColor = False
        Me.BtPrint.Visible = False
        '
        'BtDel
        '
        Me.BtDel.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.gui_13
        Me.BtDel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtDel.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.BtDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtDel.ForeColor = System.Drawing.Color.Red
        Me.BtDel.Image = CType(resources.GetObject("BtDel.Image"), System.Drawing.Image)
        Me.BtDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtDel.Location = New System.Drawing.Point(400, 4)
        Me.BtDel.Margin = New System.Windows.Forms.Padding(4)
        Me.BtDel.MaximumSize = New System.Drawing.Size(125, 38)
        Me.BtDel.MinimumSize = New System.Drawing.Size(5, 37)
        Me.BtDel.Name = "BtDel"
        Me.BtDel.Size = New System.Drawing.Size(97, 38)
        Me.BtDel.TabIndex = 0
        Me.BtDel.Text = "     Suppr"
        Me.BtDel.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Green
        Me.Label6.Location = New System.Drawing.Point(4, 4)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 38)
        Me.Label6.TabIndex = 4
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Green
        Me.Label8.Location = New System.Drawing.Point(497, 4)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(12, 38)
        Me.Label8.TabIndex = 6
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'plDate
        '
        Me.plDate.BackColor = System.Drawing.Color.Transparent
        Me.plDate.Controls.Add(Me.lbDate)
        Me.plDate.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.plDate.Location = New System.Drawing.Point(0, 46)
        Me.plDate.Margin = New System.Windows.Forms.Padding(4)
        Me.plDate.Name = "plDate"
        Me.plDate.Size = New System.Drawing.Size(513, 25)
        Me.plDate.TabIndex = 4
        '
        'lbDate
        '
        Me.lbDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbDate.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDate.ForeColor = System.Drawing.Color.Navy
        Me.lbDate.Location = New System.Drawing.Point(0, 0)
        Me.lbDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbDate.Name = "lbDate"
        Me.lbDate.Size = New System.Drawing.Size(513, 25)
        Me.lbDate.TabIndex = 1
        Me.lbDate.Text = "1/1"
        Me.lbDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'plPromo
        '
        Me.plPromo.AutoScroll = True
        Me.plPromo.BackColor = System.Drawing.Color.CornflowerBlue
        Me.plPromo.Controls.Add(Me.lbPointUtiliser)
        Me.plPromo.Controls.Add(Me.lbUsedPoint)
        Me.plPromo.Controls.Add(Me.lbTotalPoint)
        Me.plPromo.Controls.Add(Me.Label4)
        Me.plPromo.Controls.Add(Me.Label3)
        Me.plPromo.Controls.Add(Me.lbPoint)
        Me.plPromo.Controls.Add(Me.plAutoPromo)
        Me.plPromo.Cursor = System.Windows.Forms.Cursors.HSplit
        Me.plPromo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.plPromo.Location = New System.Drawing.Point(0, 71)
        Me.plPromo.Margin = New System.Windows.Forms.Padding(4)
        Me.plPromo.Name = "plPromo"
        Me.plPromo.Size = New System.Drawing.Size(513, 31)
        Me.plPromo.TabIndex = 3
        Me.plPromo.Visible = False
        '
        'lbPointUtiliser
        '
        Me.lbPointUtiliser.BackColor = System.Drawing.Color.Transparent
        Me.lbPointUtiliser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbPointUtiliser.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPointUtiliser.ForeColor = System.Drawing.Color.Crimson
        Me.lbPointUtiliser.Location = New System.Drawing.Point(299, 0)
        Me.lbPointUtiliser.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbPointUtiliser.Name = "lbPointUtiliser"
        Me.lbPointUtiliser.Size = New System.Drawing.Size(130, 31)
        Me.lbPointUtiliser.TabIndex = 7
        Me.lbPointUtiliser.Text = "Pt Utiliser"
        Me.lbPointUtiliser.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbUsedPoint
        '
        Me.lbUsedPoint.BackColor = System.Drawing.Color.Transparent
        Me.lbUsedPoint.Dock = System.Windows.Forms.DockStyle.Right
        Me.lbUsedPoint.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUsedPoint.ForeColor = System.Drawing.Color.Crimson
        Me.lbUsedPoint.Location = New System.Drawing.Point(429, 0)
        Me.lbUsedPoint.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbUsedPoint.Name = "lbUsedPoint"
        Me.lbUsedPoint.Size = New System.Drawing.Size(84, 31)
        Me.lbUsedPoint.TabIndex = 8
        Me.lbUsedPoint.Text = "0"
        Me.lbUsedPoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTotalPoint
        '
        Me.lbTotalPoint.BackColor = System.Drawing.Color.Transparent
        Me.lbTotalPoint.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbTotalPoint.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalPoint.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbTotalPoint.Location = New System.Drawing.Point(232, 0)
        Me.lbTotalPoint.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbTotalPoint.Name = "lbTotalPoint"
        Me.lbTotalPoint.Size = New System.Drawing.Size(67, 31)
        Me.lbTotalPoint.TabIndex = 5
        Me.lbTotalPoint.Text = "0"
        Me.lbTotalPoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.Location = New System.Drawing.Point(160, 0)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 31)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Tl Points"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Green
        Me.Label3.Location = New System.Drawing.Point(140, 0)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 31)
        Me.Label3.TabIndex = 3
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbPoint
        '
        Me.lbPoint.BackColor = System.Drawing.Color.Transparent
        Me.lbPoint.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbPoint.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPoint.ForeColor = System.Drawing.Color.Green
        Me.lbPoint.Location = New System.Drawing.Point(48, 0)
        Me.lbPoint.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbPoint.Name = "lbPoint"
        Me.lbPoint.Size = New System.Drawing.Size(92, 31)
        Me.lbPoint.TabIndex = 2
        Me.lbPoint.Text = "1/1"
        Me.lbPoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'plAutoPromo
        '
        Me.plAutoPromo.BackColor = System.Drawing.Color.DarkMagenta
        Me.plAutoPromo.Controls.Add(Me.lbSelectedAutoPoint)
        Me.plAutoPromo.Controls.Add(Me.lbAutoPrNbr)
        Me.plAutoPromo.Controls.Add(Me.Label5)
        Me.plAutoPromo.Dock = System.Windows.Forms.DockStyle.Left
        Me.plAutoPromo.Location = New System.Drawing.Point(0, 0)
        Me.plAutoPromo.Margin = New System.Windows.Forms.Padding(4)
        Me.plAutoPromo.Name = "plAutoPromo"
        Me.plAutoPromo.Size = New System.Drawing.Size(48, 31)
        Me.plAutoPromo.TabIndex = 9
        Me.plAutoPromo.Visible = False
        '
        'lbSelectedAutoPoint
        '
        Me.lbSelectedAutoPoint.BackColor = System.Drawing.Color.Transparent
        Me.lbSelectedAutoPoint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbSelectedAutoPoint.Font = New System.Drawing.Font("Century Gothic", 5.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSelectedAutoPoint.ForeColor = System.Drawing.Color.Yellow
        Me.lbSelectedAutoPoint.Location = New System.Drawing.Point(19, 12)
        Me.lbSelectedAutoPoint.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbSelectedAutoPoint.Name = "lbSelectedAutoPoint"
        Me.lbSelectedAutoPoint.Size = New System.Drawing.Size(29, 19)
        Me.lbSelectedAutoPoint.TabIndex = 7
        Me.lbSelectedAutoPoint.Text = "0000"
        Me.lbSelectedAutoPoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbAutoPrNbr
        '
        Me.lbAutoPrNbr.BackColor = System.Drawing.Color.Transparent
        Me.lbAutoPrNbr.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbAutoPrNbr.Font = New System.Drawing.Font("Century Gothic", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAutoPrNbr.ForeColor = System.Drawing.Color.White
        Me.lbAutoPrNbr.Location = New System.Drawing.Point(0, 12)
        Me.lbAutoPrNbr.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbAutoPrNbr.Name = "lbAutoPrNbr"
        Me.lbAutoPrNbr.Size = New System.Drawing.Size(19, 19)
        Me.lbAutoPrNbr.TabIndex = 6
        Me.lbAutoPrNbr.Text = "2"
        Me.lbAutoPrNbr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 5.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 12)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Auto"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'plCafeCmd
        '
        Me.plCafeCmd.BackColor = System.Drawing.Color.WhiteSmoke
        Me.plCafeCmd.Controls.Add(Me.btCalc)
        Me.plCafeCmd.Controls.Add(Me.Button2)
        Me.plCafeCmd.Controls.Add(Me.btMinis)
        Me.plCafeCmd.Controls.Add(Me.btPlus)
        Me.plCafeCmd.Controls.Add(Me.Button1)
        Me.plCafeCmd.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.plCafeCmd.Location = New System.Drawing.Point(0, 330)
        Me.plCafeCmd.Margin = New System.Windows.Forms.Padding(4)
        Me.plCafeCmd.Name = "plCafeCmd"
        Me.plCafeCmd.Size = New System.Drawing.Size(513, 58)
        Me.plCafeCmd.TabIndex = 3
        Me.plCafeCmd.Visible = False
        '
        'btCalc
        '
        Me.btCalc.BackColor = System.Drawing.Color.White
        Me.btCalc.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.ttal
        Me.btCalc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btCalc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btCalc.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.btCalc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btCalc.ForeColor = System.Drawing.Color.Red
        Me.btCalc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btCalc.Location = New System.Drawing.Point(400, 0)
        Me.btCalc.Margin = New System.Windows.Forms.Padding(4)
        Me.btCalc.MinimumSize = New System.Drawing.Size(5, 38)
        Me.btCalc.Name = "btCalc"
        Me.btCalc.Size = New System.Drawing.Size(113, 58)
        Me.btCalc.TabIndex = 0
        Me.btCalc.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Blue
        Me.Button2.Image = Global.Al_Mohasib.My.Resources.Resources.Print_22X22
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(293, 0)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.MinimumSize = New System.Drawing.Size(4, 38)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(107, 58)
        Me.Button2.TabIndex = 1
        Me.Button2.Tag = "0"
        Me.Button2.Text = "Impression"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btMinis
        '
        Me.btMinis.BackColor = System.Drawing.Color.Maroon
        Me.btMinis.Dock = System.Windows.Forms.DockStyle.Left
        Me.btMinis.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btMinis.FlatAppearance.BorderSize = 0
        Me.btMinis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btMinis.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btMinis.ForeColor = System.Drawing.Color.White
        Me.btMinis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btMinis.Location = New System.Drawing.Point(200, 0)
        Me.btMinis.Margin = New System.Windows.Forms.Padding(4)
        Me.btMinis.MaximumSize = New System.Drawing.Size(125, 54)
        Me.btMinis.MinimumSize = New System.Drawing.Size(5, 38)
        Me.btMinis.Name = "btMinis"
        Me.btMinis.Size = New System.Drawing.Size(93, 54)
        Me.btMinis.TabIndex = 0
        Me.btMinis.Tag = "-1"
        Me.btMinis.Text = "-"
        Me.btMinis.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btMinis.UseVisualStyleBackColor = False
        '
        'btPlus
        '
        Me.btPlus.BackColor = System.Drawing.Color.Navy
        Me.btPlus.Dock = System.Windows.Forms.DockStyle.Left
        Me.btPlus.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btPlus.FlatAppearance.BorderSize = 0
        Me.btPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btPlus.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btPlus.ForeColor = System.Drawing.Color.White
        Me.btPlus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btPlus.Location = New System.Drawing.Point(107, 0)
        Me.btPlus.Margin = New System.Windows.Forms.Padding(4)
        Me.btPlus.MaximumSize = New System.Drawing.Size(125, 54)
        Me.btPlus.MinimumSize = New System.Drawing.Size(4, 38)
        Me.btPlus.Name = "btPlus"
        Me.btPlus.Size = New System.Drawing.Size(93, 54)
        Me.btPlus.TabIndex = 0
        Me.btPlus.Tag = "1"
        Me.btPlus.Text = "+"
        Me.btPlus.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.DarkRed
        Me.Button1.Image = Global.Al_Mohasib.My.Resources.Resources.Print_22X22
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(0, 0)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.MinimumSize = New System.Drawing.Size(4, 38)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(107, 58)
        Me.Button1.TabIndex = 0
        Me.Button1.Tag = "0"
        Me.Button1.Text = "Commande"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CP
        '
        Me.CP.bc = "---"
        Me.CP.bl = "---"
        Me.CP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CP.Depot = 0
        Me.CP.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CP.EditMode = False
        Me.CP.hasRemise = False
        Me.CP.Liv = "---"
        Me.CP.Location = New System.Drawing.Point(0, 388)
        Me.CP.Margin = New System.Windows.Forms.Padding(5)
        Me.CP.MinimumSize = New System.Drawing.Size(400, 201)
        Me.CP.Name = "CP"
        Me.CP.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.CP.Size = New System.Drawing.Size(513, 305)
        Me.CP.TabIndex = 0
        Me.CP.Value = 1.0R
        '
        'BwPromos
        '
        '
        'RPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PlBody)
        Me.Controls.Add(Me.PlTop)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "RPanel"
        Me.Size = New System.Drawing.Size(513, 705)
        Me.PlBody.ResumeLayout(False)
        Me.PlBody.PerformLayout()
        Me.PlHeader.ResumeLayout(False)
        Me.PlHeader.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.plDate.ResumeLayout(False)
        Me.plPromo.ResumeLayout(False)
        Me.plAutoPromo.ResumeLayout(False)
        Me.plCafeCmd.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PlTop As System.Windows.Forms.Panel
    Friend WithEvents PlBody As System.Windows.Forms.Panel
    Friend WithEvents PlHeader As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LbVidal As System.Windows.Forms.Label
    Friend WithEvents LbSum As System.Windows.Forms.Label
    Friend WithEvents LbTva As System.Windows.Forms.Label
    Friend WithEvents Lbavc As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents BtDel As System.Windows.Forms.Button
    Friend WithEvents BtSave As System.Windows.Forms.Button
    Friend WithEvents BtPrint As System.Windows.Forms.Button
    Friend WithEvents lbHT As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbremise As System.Windows.Forms.Label
    Friend WithEvents BtBlPrint As System.Windows.Forms.Button
    Friend WithEvents lbProfit As System.Windows.Forms.Label
    Friend WithEvents CP As Al_Mohasib.CPanel
    Friend WithEvents plPromo As System.Windows.Forms.Panel
    Friend WithEvents lbDh As System.Windows.Forms.Label
    Friend WithEvents plDate As System.Windows.Forms.Panel
    Friend WithEvents lbDate As System.Windows.Forms.Label
    Friend WithEvents BwPromos As System.ComponentModel.BackgroundWorker
    Friend WithEvents lbPoint As System.Windows.Forms.Label
    Friend WithEvents lbPointUtiliser As System.Windows.Forms.Label
    Friend WithEvents lbUsedPoint As System.Windows.Forms.Label
    Friend WithEvents lbTotalPoint As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Pl As System.Windows.Forms.Panel
    Friend WithEvents plAutoPromo As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbSelectedAutoPoint As System.Windows.Forms.Label
    Friend WithEvents lbAutoPrNbr As System.Windows.Forms.Label
    Friend WithEvents plCafeCmd As System.Windows.Forms.Panel
    Friend WithEvents btCalc As System.Windows.Forms.Button
    Friend WithEvents btMinis As System.Windows.Forms.Button
    Friend WithEvents btPlus As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbFree As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label

End Class
