﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtDel = New System.Windows.Forms.Button()
        Me.BtSave = New System.Windows.Forms.Button()
        Me.BtBlPrint = New System.Windows.Forms.Button()
        Me.BtPrint = New System.Windows.Forms.Button()
        Me.PlBody = New System.Windows.Forms.Panel()
        Me.Pl = New System.Windows.Forms.Panel()
        Me.PlHeader = New System.Windows.Forms.Panel()
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
        Me.CP = New Al_Mohasib.CPanel()
        Me.Panel1.SuspendLayout()
        Me.PlBody.SuspendLayout()
        Me.PlHeader.SuspendLayout()
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.bgbuy
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.BtDel)
        Me.Panel1.Controls.Add(Me.BtSave)
        Me.Panel1.Controls.Add(Me.BtBlPrint)
        Me.Panel1.Controls.Add(Me.BtPrint)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 275)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(385, 40)
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
        Me.BtDel.Location = New System.Drawing.Point(298, 3)
        Me.BtDel.MaximumSize = New System.Drawing.Size(94, 31)
        Me.BtDel.MinimumSize = New System.Drawing.Size(4, 31)
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
        Me.BtSave.Location = New System.Drawing.Point(200, 3)
        Me.BtSave.MaximumSize = New System.Drawing.Size(94, 31)
        Me.BtSave.MinimumSize = New System.Drawing.Size(4, 31)
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
        Me.BtBlPrint.Location = New System.Drawing.Point(78, 3)
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
        Me.BtPrint.Location = New System.Drawing.Point(11, 3)
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
        Me.Pl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pl.Location = New System.Drawing.Point(0, 0)
        Me.Pl.Name = "Pl"
        Me.Pl.Size = New System.Drawing.Size(385, 220)
        Me.Pl.TabIndex = 2
        '
        'PlHeader
        '
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
        Me.PlHeader.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PlHeader.Location = New System.Drawing.Point(0, 220)
        Me.PlHeader.Name = "PlHeader"
        Me.PlHeader.Size = New System.Drawing.Size(385, 55)
        Me.PlHeader.TabIndex = 1
        '
        'lbProfit
        '
        Me.lbProfit.AutoSize = True
        Me.lbProfit.Location = New System.Drawing.Point(15, 12)
        Me.lbProfit.Name = "lbProfit"
        Me.lbProfit.Size = New System.Drawing.Size(13, 13)
        Me.lbProfit.TabIndex = 2
        Me.lbProfit.Text = "[]"
        Me.lbProfit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbProfit.Visible = False
        '
        'lbremise
        '
        Me.lbremise.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbremise.AutoSize = True
        Me.lbremise.Location = New System.Drawing.Point(251, 34)
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
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(211, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "T. TTC :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Avance :"
        '
        'LbVidal
        '
        Me.LbVidal.AutoSize = True
        Me.LbVidal.Location = New System.Drawing.Point(181, 34)
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
        Me.Lbavc.AutoSize = True
        Me.Lbavc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbavc.Location = New System.Drawing.Point(93, 31)
        Me.Lbavc.Name = "Lbavc"
        Me.Lbavc.Size = New System.Drawing.Size(17, 18)
        Me.Lbavc.TabIndex = 1
        Me.Lbavc.Text = "0"
        '
        'LbSum
        '
        Me.LbSum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LbSum.AutoSize = True
        Me.LbSum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbSum.ForeColor = System.Drawing.Color.Red
        Me.LbSum.Location = New System.Drawing.Point(284, 10)
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
        Me.ShapeContainer1.Size = New System.Drawing.Size(385, 55)
        Me.ShapeContainer1.TabIndex = 3
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 211
        Me.LineShape1.X2 = 386
        Me.LineShape1.Y1 = 9
        Me.LineShape1.Y2 = 9
        '
        'CP
        '
        Me.CP.bl = "---"
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
        'RPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PlBody)
        Me.Controls.Add(Me.PlTop)
        Me.Name = "RPanel"
        Me.Size = New System.Drawing.Size(385, 573)
        Me.Panel1.ResumeLayout(False)
        Me.PlBody.ResumeLayout(False)
        Me.PlHeader.ResumeLayout(False)
        Me.PlHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PlTop As System.Windows.Forms.Panel
    Friend WithEvents PlBody As System.Windows.Forms.Panel
    Friend WithEvents PlHeader As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Pl As System.Windows.Forms.Panel
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

End Class
