<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchBloc
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
        Me.Panel26 = New System.Windows.Forms.Panel()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.lb = New System.Windows.Forms.Label()
        Me.PR2 = New System.Windows.Forms.Panel()
        Me.PL2 = New System.Windows.Forms.Panel()
        Me.PT2 = New System.Windows.Forms.Panel()
        Me.PB2 = New System.Windows.Forms.Panel()
        Me.Panel26.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel26
        '
        Me.Panel26.AutoSize = True
        Me.Panel26.BackColor = System.Drawing.Color.White
        Me.Panel26.Controls.Add(Me.Button14)
        Me.Panel26.Controls.Add(Me.lb)
        Me.Panel26.Controls.Add(Me.PR2)
        Me.Panel26.Controls.Add(Me.PL2)
        Me.Panel26.Controls.Add(Me.PT2)
        Me.Panel26.Controls.Add(Me.PB2)
        Me.Panel26.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel26.Location = New System.Drawing.Point(0, 0)
        Me.Panel26.Name = "Panel26"
        Me.Panel26.Size = New System.Drawing.Size(58, 30)
        Me.Panel26.TabIndex = 9
        '
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.Color.Transparent
        Me.Button14.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources._30632_close_cross_x_icon
        Me.Button14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button14.FlatAppearance.BorderSize = 0
        Me.Button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button14.Location = New System.Drawing.Point(40, 1)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(17, 28)
        Me.Button14.TabIndex = 10
        Me.Button14.UseVisualStyleBackColor = False
        '
        'lb
        '
        Me.lb.AutoSize = True
        Me.lb.Dock = System.Windows.Forms.DockStyle.Left
        Me.lb.Font = New System.Drawing.Font("Century Gothic", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lb.Location = New System.Drawing.Point(1, 1)
        Me.lb.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        Me.lb.Name = "lb"
        Me.lb.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.lb.Size = New System.Drawing.Size(39, 17)
        Me.lb.TabIndex = 11
        Me.lb.Text = "Label1"
        Me.lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PR2
        '
        Me.PR2.BackColor = System.Drawing.Color.Silver
        Me.PR2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PR2.Location = New System.Drawing.Point(57, 1)
        Me.PR2.Name = "PR2"
        Me.PR2.Size = New System.Drawing.Size(1, 28)
        Me.PR2.TabIndex = 8
        '
        'PL2
        '
        Me.PL2.BackColor = System.Drawing.Color.Silver
        Me.PL2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PL2.Location = New System.Drawing.Point(0, 1)
        Me.PL2.Name = "PL2"
        Me.PL2.Size = New System.Drawing.Size(1, 28)
        Me.PL2.TabIndex = 7
        '
        'PT2
        '
        Me.PT2.BackColor = System.Drawing.Color.Silver
        Me.PT2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PT2.Location = New System.Drawing.Point(0, 0)
        Me.PT2.Name = "PT2"
        Me.PT2.Size = New System.Drawing.Size(58, 1)
        Me.PT2.TabIndex = 6
        '
        'PB2
        '
        Me.PB2.BackColor = System.Drawing.Color.Silver
        Me.PB2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PB2.Location = New System.Drawing.Point(0, 29)
        Me.PB2.Name = "PB2"
        Me.PB2.Size = New System.Drawing.Size(58, 1)
        Me.PB2.TabIndex = 5
        '
        'SearchBloc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.Panel26)
        Me.Name = "SearchBloc"
        Me.Size = New System.Drawing.Size(60, 30)
        Me.Panel26.ResumeLayout(False)
        Me.Panel26.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel26 As System.Windows.Forms.Panel
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents lb As System.Windows.Forms.Label
    Friend WithEvents PR2 As System.Windows.Forms.Panel
    Friend WithEvents PL2 As System.Windows.Forms.Panel
    Friend WithEvents PT2 As System.Windows.Forms.Panel
    Friend WithEvents PB2 As System.Windows.Forms.Panel

End Class
