<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CBlock
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
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.os = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.rs = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.lb = New System.Windows.Forms.Label()
        Me.bt = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.os, Me.rs})
        Me.ShapeContainer1.Size = New System.Drawing.Size(180, 33)
        Me.ShapeContainer1.TabIndex = 2
        Me.ShapeContainer1.TabStop = False
        '
        'os
        '
        Me.os.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.Untitled_1
        Me.os.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.os.BorderColor = System.Drawing.Color.Transparent
        Me.os.Location = New System.Drawing.Point(3, 3)
        Me.os.Name = "os"
        Me.os.Size = New System.Drawing.Size(27, 27)
        '
        'rs
        '
        Me.rs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rs.BackColor = System.Drawing.Color.Teal
        Me.rs.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.rs.BorderColor = System.Drawing.Color.White
        Me.rs.CornerRadius = 16
        Me.rs.FillColor = System.Drawing.Color.White
        Me.rs.Location = New System.Drawing.Point(1, 0)
        Me.rs.Name = "rs"
        Me.rs.Size = New System.Drawing.Size(178, 32)
        '
        'lb
        '
        Me.lb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lb.BackColor = System.Drawing.Color.Teal
        Me.lb.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb.ForeColor = System.Drawing.Color.White
        Me.lb.Location = New System.Drawing.Point(42, 1)
        Me.lb.Name = "lb"
        Me.lb.Size = New System.Drawing.Size(97, 30)
        Me.lb.TabIndex = 3
        Me.lb.Text = "Label1"
        Me.lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'bt
        '
        Me.bt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt.BackColor = System.Drawing.Color.DarkOrange
        Me.bt.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.COR_32
        Me.bt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt.FlatAppearance.BorderSize = 0
        Me.bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt.Location = New System.Drawing.Point(145, 5)
        Me.bt.Name = "bt"
        Me.bt.Size = New System.Drawing.Size(23, 23)
        Me.bt.TabIndex = 4
        Me.bt.UseVisualStyleBackColor = False
        '
        'CBlock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Teal
        Me.Controls.Add(Me.bt)
        Me.Controls.Add(Me.lb)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "CBlock"
        Me.Size = New System.Drawing.Size(180, 33)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents os As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents rs As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents lb As System.Windows.Forms.Label
    Friend WithEvents bt As System.Windows.Forms.Button

End Class
