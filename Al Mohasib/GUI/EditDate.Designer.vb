<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditDate
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
        Me.lbId = New System.Windows.Forms.Label()
        Me.mc = New System.Windows.Forms.MonthCalendar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txt = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbId
        '
        Me.lbId.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbId.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbId.ForeColor = System.Drawing.Color.Gainsboro
        Me.lbId.Location = New System.Drawing.Point(0, 0)
        Me.lbId.Name = "lbId"
        Me.lbId.Size = New System.Drawing.Size(398, 39)
        Me.lbId.TabIndex = 0
        Me.lbId.Text = "XXX"
        Me.lbId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'mc
        '
        Me.mc.Location = New System.Drawing.Point(87, 76)
        Me.mc.Name = "mc"
        Me.mc.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 354)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(398, 79)
        Me.Panel1.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(22, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(345, 35)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txt
        '
        Me.txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt.Enabled = False
        Me.txt.Location = New System.Drawing.Point(0, 11)
        Me.txt.Name = "txt"
        Me.txt.Size = New System.Drawing.Size(352, 19)
        Me.txt.TabIndex = 1
        Me.txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 266)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(22)
        Me.Panel2.Size = New System.Drawing.Size(398, 88)
        Me.Panel2.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.txt)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(22, 22)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(0, 11, 0, 0)
        Me.Panel3.Size = New System.Drawing.Size(354, 44)
        Me.Panel3.TabIndex = 4
        '
        'EditDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(398, 433)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.mc)
        Me.Controls.Add(Me.lbId)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "EditDate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Date"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbId As System.Windows.Forms.Label
    Friend WithEvents mc As System.Windows.Forms.MonthCalendar
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txt As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
End Class
