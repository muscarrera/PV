<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addtoliste
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(addtoliste))
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button63 = New System.Windows.Forms.Button()
        Me.TxtBox1 = New Al_Mohasib.TxtBox()
        Me.TxtBox2 = New Al_Mohasib.TxtBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button3.FlatAppearance.BorderSize = 2
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.Location = New System.Drawing.Point(230, 240)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(141, 67)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "اضافة مواد"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button63
        '
        Me.Button63.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button63.FlatAppearance.BorderSize = 2
        Me.Button63.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button63.Image = CType(resources.GetObject("Button63.Image"), System.Drawing.Image)
        Me.Button63.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button63.Location = New System.Drawing.Point(23, 240)
        Me.Button63.Name = "Button63"
        Me.Button63.Size = New System.Drawing.Size(141, 67)
        Me.Button63.TabIndex = 14
        Me.Button63.Text = "الغاء"
        Me.Button63.UseVisualStyleBackColor = True
        '
        'TxtBox1
        '
        Me.TxtBox1.BackColor = System.Drawing.Color.White
        Me.TxtBox1.BorderColor = System.Drawing.SystemColors.ControlText
        Me.TxtBox1.IsNumiric = False
        Me.TxtBox1.Location = New System.Drawing.Point(19, 60)
        Me.TxtBox1.MinimumSize = New System.Drawing.Size(0, 30)
        Me.TxtBox1.Name = "TxtBox1"
        Me.TxtBox1.ShowClearIcon = False
        Me.TxtBox1.ShowSaveIcon = False
        Me.TxtBox1.Size = New System.Drawing.Size(357, 42)
        Me.TxtBox1.StartUp = 2
        Me.TxtBox1.TabIndex = 16
        Me.TxtBox1.TextSize = 8
        Me.TxtBox1.TxtBackColor = True
        Me.TxtBox1.TxtColor = System.Drawing.Color.White
        Me.TxtBox1.txtReadOnly = False
        Me.TxtBox1.TxtSelect = New Integer() {1, 0}
        '
        'TxtBox2
        '
        Me.TxtBox2.BackColor = System.Drawing.Color.White
        Me.TxtBox2.BorderColor = System.Drawing.SystemColors.ControlText
        Me.TxtBox2.IsNumiric = True
        Me.TxtBox2.Location = New System.Drawing.Point(19, 155)
        Me.TxtBox2.MinimumSize = New System.Drawing.Size(0, 30)
        Me.TxtBox2.Name = "TxtBox2"
        Me.TxtBox2.ShowClearIcon = False
        Me.TxtBox2.ShowSaveIcon = False
        Me.TxtBox2.Size = New System.Drawing.Size(357, 41)
        Me.TxtBox2.StartUp = 2
        Me.TxtBox2.TabIndex = 16
        Me.TxtBox2.TextSize = 8
        Me.TxtBox2.TxtBackColor = True
        Me.TxtBox2.TxtColor = System.Drawing.Color.White
        Me.TxtBox2.txtReadOnly = False
        Me.TxtBox2.TxtSelect = New Integer() {1, 0}
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Nom "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Valure"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'addtoliste
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(405, 330)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtBox2)
        Me.Controls.Add(Me.TxtBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button63)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "addtoliste"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Machine"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button63 As System.Windows.Forms.Button
    Friend WithEvents TxtBox1 As Al_Mohasib.TxtBox
    Friend WithEvents TxtBox2 As Al_Mohasib.TxtBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
