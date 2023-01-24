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
        Me.lbDh = New System.Windows.Forms.Label()
        Me.lbProfit = New System.Windows.Forms.Label()
        Me.lbremise = New System.Windows.Forms.Label()
        Me.lbHT = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LbVidal = New System.Windows.Forms.Label()
        Me.LbTva = New System.Windows.Forms.Label()
        Me.Lbavc = New System.Windows.Forms.Label()
        Me.LbSum = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtDel = New System.Windows.Forms.Button()
        Me.BtSave = New System.Windows.Forms.Button()
        Me.BtBlPrint = New System.Windows.Forms.Button()
        Me.BtPrint = New System.Windows.Forms.Button()
        Me.plDate = New System.Windows.Forms.Panel()
        Me.lbDate = New System.Windows.Forms.Label()
        Me.plPromo = New System.Windows.Forms.Panel()
        Me.lbPointUtiliser = New System.Windows.Forms.Label()
        Me.lbUsedPoint = New System.Windows.Forms.Label()
        Me.lbTotalPoint = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbPoint = New System.Windows.Forms.Label()
        Me.BwPromos = New System.ComponentModel.BackgroundWorker()
        Me.plAutoPromo = New System.Windows.Forms.Panel()
        Me.CP = New Al_Mohasib.CPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbAutoPrNbr = New System.Windows.Forms.Label()
        Me.lbSelectedAutoPoint = New System.Windows.Forms.Label()
        Me.PlBody.SuspendLayout()
        Me.PlHeader.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.plDate.SuspendLayout()
        Me.plPromo.SuspendLayout()
        Me.plAutoPromo.SuspendLayout()
        Me.SuspendLayout()
        '
        'PlTop
        '
        Me.PlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PlTop.Location = New System.Drawing.Point(0, 0)
        Me.PlTop.Name = "PlTop"
        Me.PlTop.Size = New System.Drawing.Size(385, 10)
        Me.PlTop.TabIndex = 1
        '
        'PlBody
        '
        Me.PlBody.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PlBody.Controls.Add(Me.Pl)
        Me.PlBody.Controls.Add(Me.PlHeader)
        Me.PlBody.Controls.Add(Me.Panel1)
        Me.PlBody.Controls.Add(Me.CP)
        Me.PlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PlBody.Location = New System.Drawing.Point(0, 10)
        Me.PlBody.Name = "PlBody"
        Me.PlBody.Size = New System.Drawing.Size(385, 563)
        Me.PlBody.TabIndex = 3
        '
        'Pl
        '
        Me.Pl.AutoScroll = True
        Me.Pl.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Pl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pl.Location = New System.Drawing.Point(0, 0)
        Me.Pl.Name = "Pl"
        Me.Pl.Size = New System.Drawing.Size(385, 196)
        Me.Pl.TabIndex = 2
        '
        'PlHeader
        '
        Me.PlHeader.Controls.Add(Me.lbDh)
        Me.PlHeader.Controls.Add(Me.lbProfit)
        Me.PlHeader.Controls.Add(Me.lbremise)
        Me.PlHeader.Controls.Add(Me.lbHT)
        Me.PlHeader.Controls.Add(Me.Label2)
        Me.PlHeader.Controls.Add(Me.Label1)
        Me.PlHeader.Controls.Add(Me.LbVidal)
        Me.PlHeader.Controls.Add(Me.LbTva)
        Me.PlHeader.Controls.Add(Me.Lbavc)
        Me.PlHeader.Controls.Add(Me.LbSum)
        Me.PlHeader.Controls.Add(Me.ShapeContainer1)
        Me.PlHeader.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.PlHeader.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PlHeader.Location = New System.Drawing.Point(0, 196)
        Me.PlHeader.Name = "PlHeader"
        Me.PlHeader.Size = New System.Drawing.Size(385, 59)
        Me.PlHeader.TabIndex = 1
        '
        'lbDh
        '
        Me.lbDh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbDh.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDh.ForeColor = System.Drawing.Color.Red
        Me.lbDh.Location = New System.Drawing.Point(214, -16)
        Me.lbDh.Name = "lbDh"
        Me.lbDh.Size = New System.Drawing.Size(124, 20)
        Me.lbDh.TabIndex = 1
        Me.lbDh.Text = "000"
        Me.lbDh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbProfit
        '
        Me.lbProfit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbProfit.AutoSize = True
        Me.lbProfit.Location = New System.Drawing.Point(18, 41)
        Me.lbProfit.Name = "lbProfit"
        Me.lbProfit.Size = New System.Drawing.Size(13, 13)
        Me.lbProfit.TabIndex = 2
        Me.lbProfit.Text = "[]"
        Me.lbProfit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbProfit.Visible = False
        '
        'lbremise
        '
        Me.lbremise.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbremise.AutoSize = True
        Me.lbremise.Location = New System.Drawing.Point(18, 26)
        Me.lbremise.Name = "lbremise"
        Me.lbremise.Size = New System.Drawing.Size(63, 13)
        Me.lbremise.TabIndex = 1
        Me.lbremise.Text = "Remise =  0"
        Me.lbremise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbHT
        '
        Me.lbHT.AutoSize = True
        Me.lbHT.Location = New System.Drawing.Point(75, 94)
        Me.lbHT.Name = "lbHT"
        Me.lbHT.Size = New System.Drawing.Size(47, 13)
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
        Me.Label2.Location = New System.Drawing.Point(211, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "T. TTC :"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(209, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Avance :"
        '
        'LbVidal
        '
        Me.LbVidal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LbVidal.AutoSize = True
        Me.LbVidal.Location = New System.Drawing.Point(18, 9)
        Me.LbVidal.Name = "LbVidal"
        Me.LbVidal.Size = New System.Drawing.Size(45, 13)
        Me.LbVidal.TabIndex = 2
        Me.LbVidal.Text = "0 - Vidal"
        Me.LbVidal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LbTva
        '
        Me.LbTva.AutoSize = True
        Me.LbTva.Location = New System.Drawing.Point(11, 103)
        Me.LbTva.Name = "LbTva"
        Me.LbTva.Size = New System.Drawing.Size(49, 13)
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
        Me.Lbavc.Location = New System.Drawing.Point(287, 31)
        Me.Lbavc.Name = "Lbavc"
        Me.Lbavc.Size = New System.Drawing.Size(17, 18)
        Me.Lbavc.TabIndex = 1
        Me.Lbavc.Text = "0"
        '
        'LbSum
        '
        Me.LbSum.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LbSum.AutoSize = True
        Me.LbSum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbSum.ForeColor = System.Drawing.Color.Red
        Me.LbSum.Location = New System.Drawing.Point(284, 7)
        Me.LbSum.Name = "LbSum"
        Me.LbSum.Size = New System.Drawing.Size(54, 20)
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
        Me.ShapeContainer1.Size = New System.Drawing.Size(385, 59)
        Me.ShapeContainer1.TabIndex = 3
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 211
        Me.LineShape1.X2 = 386
        Me.LineShape1.Y1 = 6
        Me.LineShape1.Y2 = 6
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.bgbuy
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.BtDel)
        Me.Panel1.Controls.Add(Me.BtSave)
        Me.Panel1.Controls.Add(Me.BtBlPrint)
        Me.Panel1.Controls.Add(Me.BtPrint)
        Me.Panel1.Controls.Add(Me.plDate)
        Me.Panel1.Controls.Add(Me.plPromo)
        Me.Panel1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 255)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(385, 60)
        Me.Panel1.TabIndex = 2
        '
        'BtDel
        '
        Me.BtDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtDel.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.gui_13
        Me.BtDel.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.BtDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtDel.ForeColor = System.Drawing.Color.Red
        Me.BtDel.Image = CType(resources.GetObject("BtDel.Image"), System.Drawing.Image)
        Me.BtDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtDel.Location = New System.Drawing.Point(298, 2)
        Me.BtDel.MaximumSize = New System.Drawing.Size(94, 31)
        Me.BtDel.MinimumSize = New System.Drawing.Size(4, 30)
        Me.BtDel.Name = "BtDel"
        Me.BtDel.Size = New System.Drawing.Size(73, 31)
        Me.BtDel.TabIndex = 0
        Me.BtDel.Text = "     Suppr"
        Me.BtDel.UseVisualStyleBackColor = True
        '
        'BtSave
        '
        Me.BtSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtSave.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.gui_16
        Me.BtSave.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.BtSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtSave.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BtSave.Image = CType(resources.GetObject("BtSave.Image"), System.Drawing.Image)
        Me.BtSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtSave.Location = New System.Drawing.Point(200, 2)
        Me.BtSave.MaximumSize = New System.Drawing.Size(94, 31)
        Me.BtSave.MinimumSize = New System.Drawing.Size(4, 30)
        Me.BtSave.Name = "BtSave"
        Me.BtSave.Size = New System.Drawing.Size(86, 31)
        Me.BtSave.TabIndex = 0
        Me.BtSave.Text = "   Enreg"
        Me.BtSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtSave.UseVisualStyleBackColor = True
        '
        'BtBlPrint
        '
        Me.BtBlPrint.BackgroundImage = CType(resources.GetObject("BtBlPrint.BackgroundImage"), System.Drawing.Image)
        Me.BtBlPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtBlPrint.FlatAppearance.BorderSize = 2
        Me.BtBlPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtBlPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtBlPrint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtBlPrint.Image = CType(resources.GetObject("BtBlPrint.Image"), System.Drawing.Image)
        Me.BtBlPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtBlPrint.Location = New System.Drawing.Point(78, 2)
        Me.BtBlPrint.MaximumSize = New System.Drawing.Size(0, 31)
        Me.BtBlPrint.MinimumSize = New System.Drawing.Size(3, 31)
        Me.BtBlPrint.Name = "BtBlPrint"
        Me.BtBlPrint.Size = New System.Drawing.Size(3, 31)
        Me.BtBlPrint.TabIndex = 0
        Me.BtBlPrint.Tag = "1"
        Me.BtBlPrint.Text = "B. Liv"
        Me.BtBlPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtBlPrint.UseVisualStyleBackColor = True
        '
        'BtPrint
        '
        Me.BtPrint.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtPrint.BackgroundImage = CType(resources.GetObject("BtPrint.BackgroundImage"), System.Drawing.Image)
        Me.BtPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtPrint.FlatAppearance.BorderSize = 2
        Me.BtPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtPrint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtPrint.Image = CType(resources.GetObject("BtPrint.Image"), System.Drawing.Image)
        Me.BtPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtPrint.Location = New System.Drawing.Point(11, 2)
        Me.BtPrint.MinimumSize = New System.Drawing.Size(3, 31)
        Me.BtPrint.Name = "BtPrint"
        Me.BtPrint.Size = New System.Drawing.Size(61, 31)
        Me.BtPrint.TabIndex = 0
        Me.BtPrint.Tag = "0"
        Me.BtPrint.Text = "طـــبع"
        Me.BtPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtPrint.UseVisualStyleBackColor = False
        Me.BtPrint.Visible = False
        '
        'plDate
        '
        Me.plDate.BackColor = System.Drawing.Color.Transparent
        Me.plDate.Controls.Add(Me.lbDate)
        Me.plDate.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.plDate.Location = New System.Drawing.Point(0, 15)
        Me.plDate.Name = "plDate"
        Me.plDate.Size = New System.Drawing.Size(385, 20)
        Me.plDate.TabIndex = 4
        '
        'lbDate
        '
        Me.lbDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbDate.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDate.ForeColor = System.Drawing.Color.Navy
        Me.lbDate.Location = New System.Drawing.Point(0, 0)
        Me.lbDate.Name = "lbDate"
        Me.lbDate.Size = New System.Drawing.Size(385, 20)
        Me.lbDate.TabIndex = 1
        Me.lbDate.Text = "1/1"
        Me.lbDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'plPromo
        '
        Me.plPromo.AutoScroll = True
        Me.plPromo.BackColor = System.Drawing.Color.MediumBlue
        Me.plPromo.Controls.Add(Me.lbPointUtiliser)
        Me.plPromo.Controls.Add(Me.lbUsedPoint)
        Me.plPromo.Controls.Add(Me.lbTotalPoint)
        Me.plPromo.Controls.Add(Me.Label4)
        Me.plPromo.Controls.Add(Me.Label3)
        Me.plPromo.Controls.Add(Me.lbPoint)
        Me.plPromo.Controls.Add(Me.plAutoPromo)
        Me.plPromo.Cursor = System.Windows.Forms.Cursors.HSplit
        Me.plPromo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.plPromo.Location = New System.Drawing.Point(0, 35)
        Me.plPromo.Name = "plPromo"
        Me.plPromo.Size = New System.Drawing.Size(385, 25)
        Me.plPromo.TabIndex = 3
        '
        'lbPointUtiliser
        '
        Me.lbPointUtiliser.BackColor = System.Drawing.Color.Transparent
        Me.lbPointUtiliser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbPointUtiliser.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPointUtiliser.ForeColor = System.Drawing.Color.Crimson
        Me.lbPointUtiliser.Location = New System.Drawing.Point(224, 0)
        Me.lbPointUtiliser.Name = "lbPointUtiliser"
        Me.lbPointUtiliser.Size = New System.Drawing.Size(98, 25)
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
        Me.lbUsedPoint.Location = New System.Drawing.Point(322, 0)
        Me.lbUsedPoint.Name = "lbUsedPoint"
        Me.lbUsedPoint.Size = New System.Drawing.Size(63, 25)
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
        Me.lbTotalPoint.Location = New System.Drawing.Point(174, 0)
        Me.lbTotalPoint.Name = "lbTotalPoint"
        Me.lbTotalPoint.Size = New System.Drawing.Size(50, 25)
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
        Me.Label4.Location = New System.Drawing.Point(120, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 25)
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
        Me.Label3.Location = New System.Drawing.Point(105, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 25)
        Me.Label3.TabIndex = 3
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbPoint
        '
        Me.lbPoint.BackColor = System.Drawing.Color.Transparent
        Me.lbPoint.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbPoint.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPoint.ForeColor = System.Drawing.Color.Green
        Me.lbPoint.Location = New System.Drawing.Point(36, 0)
        Me.lbPoint.Name = "lbPoint"
        Me.lbPoint.Size = New System.Drawing.Size(69, 25)
        Me.lbPoint.TabIndex = 2
        Me.lbPoint.Text = "1/1"
        Me.lbPoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BwPromos
        '
        '
        'plAutoPromo
        '
        Me.plAutoPromo.BackColor = System.Drawing.Color.DarkMagenta
        Me.plAutoPromo.Controls.Add(Me.lbSelectedAutoPoint)
        Me.plAutoPromo.Controls.Add(Me.lbAutoPrNbr)
        Me.plAutoPromo.Controls.Add(Me.Label5)
        Me.plAutoPromo.Dock = System.Windows.Forms.DockStyle.Left
        Me.plAutoPromo.Location = New System.Drawing.Point(0, 0)
        Me.plAutoPromo.Name = "plAutoPromo"
        Me.plAutoPromo.Size = New System.Drawing.Size(36, 25)
        Me.plAutoPromo.TabIndex = 9
        Me.plAutoPromo.Visible = False
        '
        'CP
        '
        Me.CP.bl = "---"
        Me.CP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CP.Depot = 0
        Me.CP.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CP.EditMode = False
        Me.CP.hasRemise = False
        Me.CP.Location = New System.Drawing.Point(0, 315)
        Me.CP.MinimumSize = New System.Drawing.Size(300, 163)
        Me.CP.Name = "CP"
        Me.CP.Padding = New System.Windows.Forms.Padding(5)
        Me.CP.Size = New System.Drawing.Size(385, 248)
        Me.CP.TabIndex = 0
        Me.CP.Value = 1.0R
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 5.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 10)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Auto"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbAutoPrNbr
        '
        Me.lbAutoPrNbr.BackColor = System.Drawing.Color.Transparent
        Me.lbAutoPrNbr.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbAutoPrNbr.Font = New System.Drawing.Font("Century Gothic", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAutoPrNbr.ForeColor = System.Drawing.Color.White
        Me.lbAutoPrNbr.Location = New System.Drawing.Point(0, 10)
        Me.lbAutoPrNbr.Name = "lbAutoPrNbr"
        Me.lbAutoPrNbr.Size = New System.Drawing.Size(14, 15)
        Me.lbAutoPrNbr.TabIndex = 6
        Me.lbAutoPrNbr.Text = "2"
        Me.lbAutoPrNbr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbSelectedAutoPoint
        '
        Me.lbSelectedAutoPoint.BackColor = System.Drawing.Color.Transparent
        Me.lbSelectedAutoPoint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbSelectedAutoPoint.Font = New System.Drawing.Font("Century Gothic", 5.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSelectedAutoPoint.ForeColor = System.Drawing.Color.Yellow
        Me.lbSelectedAutoPoint.Location = New System.Drawing.Point(14, 10)
        Me.lbSelectedAutoPoint.Name = "lbSelectedAutoPoint"
        Me.lbSelectedAutoPoint.Size = New System.Drawing.Size(22, 15)
        Me.lbSelectedAutoPoint.TabIndex = 7
        Me.lbSelectedAutoPoint.Text = "0000"
        Me.lbSelectedAutoPoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PlBody)
        Me.Controls.Add(Me.PlTop)
        Me.Name = "RPanel"
        Me.Size = New System.Drawing.Size(385, 573)
        Me.PlBody.ResumeLayout(False)
        Me.PlHeader.ResumeLayout(False)
        Me.PlHeader.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.plDate.ResumeLayout(False)
        Me.plPromo.ResumeLayout(False)
        Me.plAutoPromo.ResumeLayout(False)
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

End Class
