<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Screen2
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
        Me.PrintDocdepot = New System.Drawing.Printing.PrintDocument()
        Me.PrintDoc = New System.Drawing.Printing.PrintDocument()
        Me.PrintDocRes = New System.Drawing.Printing.PrintDocument()
        Me.pl = New System.Windows.Forms.Panel()
        Me.PlItems = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LbSum = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.pl.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pl
        '
        Me.pl.BackColor = System.Drawing.Color.Black
        Me.pl.Controls.Add(Me.PlItems)
        Me.pl.Controls.Add(Me.Panel1)
        Me.pl.Location = New System.Drawing.Point(12, 12)
        Me.pl.Name = "pl"
        Me.pl.Padding = New System.Windows.Forms.Padding(10)
        Me.pl.Size = New System.Drawing.Size(388, 591)
        Me.pl.TabIndex = 1
        '
        'PlItems
        '
        Me.PlItems.AutoScroll = True
        Me.PlItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PlItems.Location = New System.Drawing.Point(10, 10)
        Me.PlItems.Name = "PlItems"
        Me.PlItems.Size = New System.Drawing.Size(368, 489)
        Me.PlItems.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.LbSum)
        Me.Panel1.Controls.Add(Me.ShapeContainer1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(10, 499)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(368, 82)
        Me.Panel1.TabIndex = 2
        '
        'LbSum
        '
        Me.LbSum.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbSum.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LbSum.Location = New System.Drawing.Point(23, 19)
        Me.LbSum.Name = "LbSum"
        Me.LbSum.Size = New System.Drawing.Size(325, 44)
        Me.LbSum.TabIndex = 2
        Me.LbSum.Text = "00.00"
        Me.LbSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(368, 82)
        Me.ShapeContainer1.TabIndex = 3
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 123
        Me.LineShape1.X2 = 245
        Me.LineShape1.Y1 = 13
        Me.LineShape1.Y2 = 13
        '
        'Screen2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(418, 615)
        Me.Controls.Add(Me.pl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Screen2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "       R  E  C  E  P  T"
        Me.pl.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PrintDocdepot As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDoc As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDocRes As System.Drawing.Printing.PrintDocument
    Friend WithEvents pl As System.Windows.Forms.Panel
    Friend WithEvents PlItems As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LbSum As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
End Class
