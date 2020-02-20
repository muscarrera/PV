<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class byname
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
        Me.Panel44 = New System.Windows.Forms.Panel()
        Me.txt = New Al_Mohasib.TxtBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel44.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel44
        '
        Me.Panel44.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel44.Controls.Add(Me.Label1)
        Me.Panel44.Controls.Add(Me.txt)
        Me.Panel44.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel44.Location = New System.Drawing.Point(0, 0)
        Me.Panel44.Name = "Panel44"
        Me.Panel44.Size = New System.Drawing.Size(495, 150)
        Me.Panel44.TabIndex = 4
        '
        'txt
        '
        Me.txt.BackColor = System.Drawing.Color.Transparent
        Me.txt.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt.IsNumiric = True
        Me.txt.Location = New System.Drawing.Point(14, 55)
        Me.txt.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txt.MinimumSize = New System.Drawing.Size(0, 55)
        Me.txt.Name = "txt"
        Me.txt.ShowClearIcon = False
        Me.txt.ShowSaveIcon = False
        Me.txt.Size = New System.Drawing.Size(457, 55)
        Me.txt.StartUp = 2
        Me.txt.TabIndex = 1
        Me.txt.TextSize = 14
        Me.txt.TxtBackColor = True
        Me.txt.TxtColor = System.Drawing.Color.White
        Me.txt.txtReadOnly = False
        Me.txt.TxtSelect = New Integer() {1, 0}
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Quantité"
        '
        'byname
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(495, 150)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel44)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "byname"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Quantité"
        Me.Panel44.ResumeLayout(False)
        Me.Panel44.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel44 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt As Al_Mohasib.TxtBox
End Class
