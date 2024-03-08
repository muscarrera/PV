<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplitDetailsBon
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SplitDetailsBon))
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.plup = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.lbremise = New System.Windows.Forms.Label()
        Me.lbHT = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.LbVidal = New System.Windows.Forms.Label()
        Me.LbTva = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Lbavc = New System.Windows.Forms.Label()
        Me.LbSum = New System.Windows.Forms.Label()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.PL = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Pl2 = New System.Windows.Forms.Panel()
        Me.PlTop = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.PrintDoc = New System.Drawing.Printing.PrintDocument()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtSave = New System.Windows.Forms.Button()
        Me.lbName = New System.Windows.Forms.Label()
        Me.plup.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Image = Global.Al_Mohasib.My.Resources.Resources.Print_22X221
        Me.Button5.Location = New System.Drawing.Point(8, 487)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(91, 64)
        Me.Button5.TabIndex = 0
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(7, 302)
        Me.Button7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(91, 64)
        Me.Button7.TabIndex = 0
        Me.Button7.Text = "<<"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(7, 230)
        Me.Button6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(91, 64)
        Me.Button6.TabIndex = 0
        Me.Button6.Text = "<"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'plup
        '
        Me.plup.Controls.Add(Me.lbName)
        Me.plup.Dock = System.Windows.Forms.DockStyle.Top
        Me.plup.Location = New System.Drawing.Point(0, 0)
        Me.plup.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.plup.Name = "plup"
        Me.plup.Size = New System.Drawing.Size(1305, 70)
        Me.plup.TabIndex = 7
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(7, 118)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(91, 64)
        Me.Button4.TabIndex = 0
        Me.Button4.Text = ">>"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'lbremise
        '
        Me.lbremise.AutoSize = True
        Me.lbremise.Location = New System.Drawing.Point(235, 42)
        Me.lbremise.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbremise.Name = "lbremise"
        Me.lbremise.Size = New System.Drawing.Size(83, 17)
        Me.lbremise.TabIndex = 7
        Me.lbremise.Text = "Remise =  0"
        Me.lbremise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbHT
        '
        Me.lbHT.AutoSize = True
        Me.lbHT.Location = New System.Drawing.Point(37, 17)
        Me.lbHT.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbHT.Name = "lbHT"
        Me.lbHT.Size = New System.Drawing.Size(60, 17)
        Me.lbHT.TabIndex = 9
        Me.lbHT.Text = "T HT : 0"
        Me.lbHT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(232, 16)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 24)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "T. TTC :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(235, 62)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 24)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Avance :"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(600, 12)
        Me.Panel4.TabIndex = 4
        '
        'LbVidal
        '
        Me.LbVidal.AutoSize = True
        Me.LbVidal.Location = New System.Drawing.Point(40, 69)
        Me.LbVidal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LbVidal.Name = "LbVidal"
        Me.LbVidal.Size = New System.Drawing.Size(60, 17)
        Me.LbVidal.TabIndex = 11
        Me.LbVidal.Text = "0 - Vidal"
        Me.LbVidal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LbTva
        '
        Me.LbTva.AutoSize = True
        Me.LbTva.Location = New System.Drawing.Point(37, 41)
        Me.LbTva.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LbTva.Name = "LbTva"
        Me.LbTva.Size = New System.Drawing.Size(64, 17)
        Me.LbTva.TabIndex = 4
        Me.LbTva.Text = "Tva : 0%"
        Me.LbTva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.lbremise)
        Me.Panel6.Controls.Add(Me.lbHT)
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Controls.Add(Me.Label1)
        Me.Panel6.Controls.Add(Me.LbVidal)
        Me.Panel6.Controls.Add(Me.LbTva)
        Me.Panel6.Controls.Add(Me.Lbavc)
        Me.Panel6.Controls.Add(Me.LbSum)
        Me.Panel6.Controls.Add(Me.ShapeContainer2)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(0, 471)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(600, 96)
        Me.Panel6.TabIndex = 3
        '
        'Lbavc
        '
        Me.Lbavc.AutoSize = True
        Me.Lbavc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbavc.Location = New System.Drawing.Point(336, 62)
        Me.Lbavc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbavc.Name = "Lbavc"
        Me.Lbavc.Size = New System.Drawing.Size(21, 24)
        Me.Lbavc.TabIndex = 5
        Me.Lbavc.Text = "0"
        '
        'LbSum
        '
        Me.LbSum.AutoSize = True
        Me.LbSum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbSum.Location = New System.Drawing.Point(332, 14)
        Me.LbSum.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LbSum.Name = "LbSum"
        Me.LbSum.Size = New System.Drawing.Size(66, 25)
        Me.LbSum.TabIndex = 3
        Me.LbSum.Text = "00.00"
        Me.LbSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer2.Size = New System.Drawing.Size(600, 96)
        Me.ShapeContainer2.TabIndex = 0
        Me.ShapeContainer2.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 180
        Me.LineShape1.X2 = 302
        Me.LineShape1.Y1 = 8
        Me.LineShape1.Y2 = 8
        '
        'PL
        '
        Me.PL.AutoScroll = True
        Me.PL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PL.Location = New System.Drawing.Point(0, 12)
        Me.PL.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PL.Name = "PL"
        Me.PL.Size = New System.Drawing.Size(600, 459)
        Me.PL.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Pl2)
        Me.Panel1.Controls.Add(Me.PlTop)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 70)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(598, 567)
        Me.Panel1.TabIndex = 9
        '
        'Pl2
        '
        Me.Pl2.AutoScroll = True
        Me.Pl2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Pl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pl2.Location = New System.Drawing.Point(0, 12)
        Me.Pl2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Pl2.Name = "Pl2"
        Me.Pl2.Size = New System.Drawing.Size(598, 555)
        Me.Pl2.TabIndex = 6
        '
        'PlTop
        '
        Me.PlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PlTop.Location = New System.Drawing.Point(0, 0)
        Me.PlTop.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PlTop.Name = "PlTop"
        Me.PlTop.Size = New System.Drawing.Size(598, 12)
        Me.PlTop.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel3.Controls.Add(Me.PL)
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(705, 70)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(600, 567)
        Me.Panel3.TabIndex = 10
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(7, 47)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(91, 64)
        Me.Button3.TabIndex = 0
        Me.Button3.Text = ">"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'PrintDoc
        '
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtSave)
        Me.Panel2.Controls.Add(Me.Button5)
        Me.Panel2.Controls.Add(Me.Button7)
        Me.Panel2.Controls.Add(Me.Button6)
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(598, 70)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(107, 567)
        Me.Panel2.TabIndex = 8
        '
        'BtSave
        '
        Me.BtSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtSave.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.gui_16
        Me.BtSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtSave.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.BtSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtSave.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BtSave.Image = CType(resources.GetObject("BtSave.Image"), System.Drawing.Image)
        Me.BtSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtSave.Location = New System.Drawing.Point(8, 403)
        Me.BtSave.Margin = New System.Windows.Forms.Padding(4)
        Me.BtSave.MaximumSize = New System.Drawing.Size(125, 138)
        Me.BtSave.MinimumSize = New System.Drawing.Size(5, 37)
        Me.BtSave.Name = "BtSave"
        Me.BtSave.Size = New System.Drawing.Size(90, 68)
        Me.BtSave.TabIndex = 1
        Me.BtSave.Text = "   Enreg"
        Me.BtSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtSave.UseVisualStyleBackColor = True
        '
        'lbName
        '
        Me.lbName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbName.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbName.Location = New System.Drawing.Point(0, 0)
        Me.lbName.Name = "lbName"
        Me.lbName.Size = New System.Drawing.Size(1305, 70)
        Me.lbName.TabIndex = 0
        Me.lbName.Text = "Label3"
        Me.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SplitDetailsBon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1305, 637)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.plup)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "SplitDetailsBon"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "   Partage de Bon"
        Me.plup.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents plup As System.Windows.Forms.Panel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents lbremise As System.Windows.Forms.Label
    Friend WithEvents lbHT As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents LbVidal As System.Windows.Forms.Label
    Friend WithEvents LbTva As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Lbavc As System.Windows.Forms.Label
    Friend WithEvents LbSum As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents PL As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Pl2 As System.Windows.Forms.Panel
    Friend WithEvents PlTop As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents PrintDoc As System.Drawing.Printing.PrintDocument
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtSave As System.Windows.Forms.Button
    Friend WithEvents lbName As System.Windows.Forms.Label
End Class
