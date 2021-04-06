<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShapeTrace
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
        Me.pl = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PB = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pl
        '
        Me.pl.AutoScroll = True
        Me.pl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pl.Location = New System.Drawing.Point(322, 0)
        Me.pl.Name = "pl"
        Me.pl.Size = New System.Drawing.Size(335, 222)
        Me.pl.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 222)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(657, 52)
        Me.Panel2.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Green
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(415, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(219, 38)
        Me.Button1.TabIndex = 34
        Me.Button1.Text = "Valider"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.Controls.Add(Me.PB)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(322, 222)
        Me.Panel3.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(12, 14)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(58, 30)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "+"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'PB
        '
        Me.PB.BackColor = System.Drawing.Color.White
        Me.PB.Location = New System.Drawing.Point(12, 12)
        Me.PB.Name = "PB"
        Me.PB.Size = New System.Drawing.Size(208, 145)
        Me.PB.TabIndex = 0
        Me.PB.TabStop = False
        '
        'ShapeTrace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 274)
        Me.Controls.Add(Me.pl)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ShapeTrace"
        Me.Text = "ShapeTrace"
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.PB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pl As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PB As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
