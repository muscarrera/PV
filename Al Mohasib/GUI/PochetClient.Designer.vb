<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PochetClient
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
        Me.plPoch = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbPoch = New System.Windows.Forms.Label()
        Me.lbClient = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.plPoch.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'plPoch
        '
        Me.plPoch.Controls.Add(Me.Label6)
        Me.plPoch.Controls.Add(Me.lbPoch)
        Me.plPoch.Location = New System.Drawing.Point(116, 71)
        Me.plPoch.Name = "plPoch"
        Me.plPoch.Size = New System.Drawing.Size(207, 58)
        Me.plPoch.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(207, 22)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "POUCHET"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbPoch
        '
        Me.lbPoch.BackColor = System.Drawing.Color.LightYellow
        Me.lbPoch.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lbPoch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbPoch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPoch.ForeColor = System.Drawing.Color.Maroon
        Me.lbPoch.Location = New System.Drawing.Point(0, 24)
        Me.lbPoch.Name = "lbPoch"
        Me.lbPoch.Size = New System.Drawing.Size(207, 34)
        Me.lbPoch.TabIndex = 5
        Me.lbPoch.Tag = "0"
        Me.lbPoch.Text = "000"
        Me.lbPoch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbClient
        '
        Me.lbClient.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbClient.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbClient.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbClient.Location = New System.Drawing.Point(0, 0)
        Me.lbClient.Name = "lbClient"
        Me.lbClient.Size = New System.Drawing.Size(424, 40)
        Me.lbClient.TabIndex = 9
        Me.lbClient.Text = "Client"
        Me.lbClient.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'TextBox1
        '
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(0, 22)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(325, 38)
        Me.TextBox1.TabIndex = 10
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(51, 202)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(325, 58)
        Me.Panel1.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(325, 22)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "NOUVEAU  POUCHET"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(51, 268)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(325, 30)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "V A L I D E R"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PochetClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 335)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lbClient)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.plPoch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "PochetClient"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PochetClient"
        Me.plPoch.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents plPoch As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbPoch As System.Windows.Forms.Label
    Friend WithEvents lbClient As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
