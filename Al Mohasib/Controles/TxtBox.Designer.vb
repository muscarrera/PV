<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TxtBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TxtBox))
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RS = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.TXT = New System.Windows.Forms.TextBox()
        Me.PO = New System.Windows.Forms.PictureBox()
        Me.PD = New System.Windows.Forms.PictureBox()
        CType(Me.PO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RS})
        Me.ShapeContainer1.Size = New System.Drawing.Size(339, 72)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'RS
        '
        Me.RS.BackColor = System.Drawing.Color.White
        Me.RS.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RS.CornerRadius = 5
        Me.RS.Location = New System.Drawing.Point(6, 3)
        Me.RS.Name = "RS"
        Me.RS.Size = New System.Drawing.Size(325, 60)
        '
        'TXT
        '
        Me.TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TXT.Location = New System.Drawing.Point(7, 19)
        Me.TXT.Name = "TXT"
        Me.TXT.Size = New System.Drawing.Size(266, 13)
        Me.TXT.TabIndex = 3
        '
        'PO
        '
        Me.PO.BackColor = System.Drawing.Color.White
        Me.PO.BackgroundImage = CType(resources.GetObject("PO.BackgroundImage"), System.Drawing.Image)
        Me.PO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PO.Location = New System.Drawing.Point(242, 13)
        Me.PO.Name = "PO"
        Me.PO.Size = New System.Drawing.Size(20, 20)
        Me.PO.TabIndex = 4
        Me.PO.TabStop = False
        Me.PO.Visible = False
        '
        'PD
        '
        Me.PD.BackColor = System.Drawing.Color.White
        Me.PD.BackgroundImage = CType(resources.GetObject("PD.BackgroundImage"), System.Drawing.Image)
        Me.PD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PD.Location = New System.Drawing.Point(264, 13)
        Me.PD.Name = "PD"
        Me.PD.Size = New System.Drawing.Size(20, 20)
        Me.PD.TabIndex = 5
        Me.PD.TabStop = False
        Me.PD.Visible = False
        '
        'TxtBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.PO)
        Me.Controls.Add(Me.PD)
        Me.Controls.Add(Me.TXT)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.MinimumSize = New System.Drawing.Size(0, 30)
        Me.Name = "TxtBox"
        Me.Size = New System.Drawing.Size(339, 72)
        CType(Me.PO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RS As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents PO As System.Windows.Forms.PictureBox
    Friend WithEvents PD As System.Windows.Forms.PictureBox
    Friend WithEvents TXT As System.Windows.Forms.TextBox

End Class
