<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class bSetting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(bSetting))
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btcancel = New System.Windows.Forms.Button()
        Me.btcon = New System.Windows.Forms.Button()
        Me.txtF1 = New Al_Mohasib.TxtBox()
        Me.btColor = New System.Windows.Forms.Button()
        Me.Panel11.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.White
        Me.Panel11.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.WhatsApp_Image_2021_06_02_at_17_59_22__1_
        Me.Panel11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel11.Controls.Add(Me.Label7)
        Me.Panel11.Controls.Add(Me.btcancel)
        Me.Panel11.Controls.Add(Me.btcon)
        Me.Panel11.Controls.Add(Me.txtF1)
        Me.Panel11.Controls.Add(Me.btColor)
        Me.Panel11.Location = New System.Drawing.Point(40, 23)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(346, 374)
        Me.Panel11.TabIndex = 45
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(30, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Path"
        '
        'btcancel
        '
        Me.btcancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btcancel.FlatAppearance.BorderSize = 2
        Me.btcancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btcancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btcancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btcancel.Image = CType(resources.GetObject("btcancel.Image"), System.Drawing.Image)
        Me.btcancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btcancel.Location = New System.Drawing.Point(17, 311)
        Me.btcancel.Name = "btcancel"
        Me.btcancel.Size = New System.Drawing.Size(122, 44)
        Me.btcancel.TabIndex = 7
        Me.btcancel.Text = "Supprimer"
        Me.btcancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btcancel.UseVisualStyleBackColor = True
        '
        'btcon
        '
        Me.btcon.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btcon.FlatAppearance.BorderSize = 2
        Me.btcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btcon.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btcon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btcon.Image = CType(resources.GetObject("btcon.Image"), System.Drawing.Image)
        Me.btcon.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btcon.Location = New System.Drawing.Point(145, 311)
        Me.btcon.Name = "btcon"
        Me.btcon.Size = New System.Drawing.Size(181, 45)
        Me.btcon.TabIndex = 6
        Me.btcon.Tag = "0"
        Me.btcon.Text = "Valider  "
        Me.btcon.UseVisualStyleBackColor = True
        '
        'txtF1
        '
        Me.txtF1.BackColor = System.Drawing.Color.Transparent
        Me.txtF1.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtF1.IsNumiric = False
        Me.txtF1.Location = New System.Drawing.Point(33, 74)
        Me.txtF1.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtF1.Name = "txtF1"
        Me.txtF1.ShowClearIcon = False
        Me.txtF1.ShowSaveIcon = False
        Me.txtF1.Size = New System.Drawing.Size(247, 30)
        Me.txtF1.StartUp = 2
        Me.txtF1.TabIndex = 40
        Me.txtF1.TextSize = 8
        Me.txtF1.TxtBackColor = True
        Me.txtF1.TxtColor = System.Drawing.Color.White
        Me.txtF1.txtReadOnly = False
        Me.txtF1.TxtSelect = New Integer() {1, 0}
        '
        'btColor
        '
        Me.btColor.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btColor.Location = New System.Drawing.Point(286, 74)
        Me.btColor.Name = "btColor"
        Me.btColor.Size = New System.Drawing.Size(40, 30)
        Me.btColor.TabIndex = 37
        Me.btColor.Text = "..."
        Me.btColor.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btColor.UseVisualStyleBackColor = False
        '
        'bSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(427, 420)
        Me.Controls.Add(Me.Panel11)
        Me.Name = "bSetting"
        Me.Text = "Params"
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btcancel As System.Windows.Forms.Button
    Friend WithEvents btcon As System.Windows.Forms.Button
    Friend WithEvents txtF1 As Al_Mohasib.TxtBox
    Friend WithEvents btColor As System.Windows.Forms.Button
End Class
