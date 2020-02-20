<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddEditCharges
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtBox1 = New Al_Mohasib.TxtBox()
        Me.TxtBox2 = New Al_Mohasib.TxtBox()
        Me.TxtBox4 = New Al_Mohasib.TxtBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(240, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "إســــم "
        '
        'TxtBox1
        '
        Me.TxtBox1.BackColor = System.Drawing.Color.White
        Me.TxtBox1.BorderColor = System.Drawing.SystemColors.ControlText
        Me.TxtBox1.IsNumiric = False
        Me.TxtBox1.Location = New System.Drawing.Point(12, 62)
        Me.TxtBox1.MinimumSize = New System.Drawing.Size(0, 40)
        Me.TxtBox1.Name = "TxtBox1"
        Me.TxtBox1.ShowClearIcon = False
        Me.TxtBox1.ShowSaveIcon = False
        Me.TxtBox1.Size = New System.Drawing.Size(268, 40)
        Me.TxtBox1.StartUp = 2
        Me.TxtBox1.TabIndex = 1
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
        Me.TxtBox2.Location = New System.Drawing.Point(12, 142)
        Me.TxtBox2.MinimumSize = New System.Drawing.Size(0, 40)
        Me.TxtBox2.Name = "TxtBox2"
        Me.TxtBox2.ShowClearIcon = False
        Me.TxtBox2.ShowSaveIcon = False
        Me.TxtBox2.Size = New System.Drawing.Size(268, 40)
        Me.TxtBox2.StartUp = 2
        Me.TxtBox2.TabIndex = 2
        Me.TxtBox2.TextSize = 8
        Me.TxtBox2.TxtBackColor = True
        Me.TxtBox2.TxtColor = System.Drawing.Color.White
        Me.TxtBox2.txtReadOnly = False
        Me.TxtBox2.TxtSelect = New Integer() {1, 0}
        '
        'TxtBox4
        '
        Me.TxtBox4.BackColor = System.Drawing.Color.White
        Me.TxtBox4.BorderColor = System.Drawing.SystemColors.ControlText
        Me.TxtBox4.IsNumiric = True
        Me.TxtBox4.Location = New System.Drawing.Point(12, 270)
        Me.TxtBox4.MinimumSize = New System.Drawing.Size(0, 40)
        Me.TxtBox4.Name = "TxtBox4"
        Me.TxtBox4.ShowClearIcon = False
        Me.TxtBox4.ShowSaveIcon = False
        Me.TxtBox4.Size = New System.Drawing.Size(268, 40)
        Me.TxtBox4.StartUp = 2
        Me.TxtBox4.TabIndex = 4
        Me.TxtBox4.TextSize = 8
        Me.TxtBox4.TxtBackColor = True
        Me.TxtBox4.TxtColor = System.Drawing.Color.White
        Me.TxtBox4.txtReadOnly = False
        Me.TxtBox4.TxtSelect = New Integer() {1, 0}
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(176, 211)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox1.Size = New System.Drawing.Size(104, 17)
        Me.CheckBox1.TabIndex = 3
        Me.CheckBox1.Text = "قــــــــابل للتكرار"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(230, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "المــــــبلغ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(230, 254)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "المدة"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 342)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(268, 48)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "تـــــأكـــــيـــد"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'AddEditCharges
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 412)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.TxtBox4)
        Me.Controls.Add(Me.TxtBox2)
        Me.Controls.Add(Me.TxtBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddEditCharges"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "الحمـــولات"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtBox1 As Al_Mohasib.TxtBox
    Friend WithEvents TxtBox2 As Al_Mohasib.TxtBox
    Friend WithEvents TxtBox4 As Al_Mohasib.TxtBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
