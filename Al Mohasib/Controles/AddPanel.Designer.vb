<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddPanel
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtkey = New Al_Mohasib.TxtBox()
        Me.txtval = New Al_Mohasib.TxtBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtkey)
        Me.Panel1.Controls.Add(Me.txtval)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(3)
        Me.Panel1.Size = New System.Drawing.Size(478, 45)
        Me.Panel1.TabIndex = 2
        '
        'txtkey
        '
        Me.txtkey.BackColor = System.Drawing.Color.White
        Me.txtkey.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtkey.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtkey.IsNumiric = False
        Me.txtkey.Location = New System.Drawing.Point(3, 3)
        Me.txtkey.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtkey.Name = "txtkey"
        Me.txtkey.ShowClearIcon = False
        Me.txtkey.ShowSaveIcon = False
        Me.txtkey.Size = New System.Drawing.Size(361, 39)
        Me.txtkey.StartUp = 2
        Me.txtkey.TabIndex = 1
        Me.txtkey.TextSize = 8
        Me.txtkey.TxtBackColor = True
        Me.txtkey.TxtColor = System.Drawing.Color.White
        Me.txtkey.txtReadOnly = False
        Me.txtkey.TxtSelect = New Integer() {1, 0}
        '
        'txtval
        '
        Me.txtval.BackColor = System.Drawing.Color.White
        Me.txtval.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtval.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtval.IsNumiric = True
        Me.txtval.Location = New System.Drawing.Point(364, 3)
        Me.txtval.MaximumSize = New System.Drawing.Size(111, 0)
        Me.txtval.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtval.Name = "txtval"
        Me.txtval.ShowClearIcon = False
        Me.txtval.ShowSaveIcon = False
        Me.txtval.Size = New System.Drawing.Size(111, 39)
        Me.txtval.StartUp = 2
        Me.txtval.TabIndex = 0
        Me.txtval.TextSize = 8
        Me.txtval.TxtBackColor = True
        Me.txtval.TxtColor = System.Drawing.Color.White
        Me.txtval.txtReadOnly = False
        Me.txtval.TxtSelect = New Integer() {1, 0}
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(478, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(39, 45)
        Me.Panel2.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.COR_221
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(0, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(39, 45)
        Me.Button1.TabIndex = 4
        Me.Button1.UseVisualStyleBackColor = True
        '
        'AddPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "AddPanel"
        Me.Size = New System.Drawing.Size(517, 45)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtval As Al_Mohasib.TxtBox
    Friend WithEvents txtkey As Al_Mohasib.TxtBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
