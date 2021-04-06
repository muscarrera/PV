<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShapeElement
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
        Me.txt1 = New System.Windows.Forms.TextBox()
        Me.txt2 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txt1
        '
        Me.txt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt1.Dock = System.Windows.Forms.DockStyle.Left
        Me.txt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt1.Location = New System.Drawing.Point(11, 11)
        Me.txt1.Name = "txt1"
        Me.txt1.Size = New System.Drawing.Size(100, 29)
        Me.txt1.TabIndex = 0
        Me.txt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt2
        '
        Me.txt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt2.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt2.Location = New System.Drawing.Point(111, 11)
        Me.txt2.Name = "txt2"
        Me.txt2.Size = New System.Drawing.Size(98, 29)
        Me.txt2.TabIndex = 1
        Me.txt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.vector_cancel_icon_png_302651
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(209, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(48, 31)
        Me.Button1.TabIndex = 2
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ShapeElement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txt2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txt1)
        Me.Name = "ShapeElement"
        Me.Padding = New System.Windows.Forms.Padding(11)
        Me.Size = New System.Drawing.Size(268, 53)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt1 As System.Windows.Forms.TextBox
    Friend WithEvents txt2 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
