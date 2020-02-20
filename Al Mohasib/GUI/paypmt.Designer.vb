<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class paypmt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(paypmt))
        Me.cbway = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbnum = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btcon = New System.Windows.Forms.Button()
        Me.btcancel = New System.Windows.Forms.Button()
        Me.txtnum = New System.Windows.Forms.TextBox()
        Me.txtmontant = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbway
        '
        Me.cbway.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbway.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbway.FormattingEnabled = True
        Me.cbway.Items.AddRange(New Object() {"كاش", "شيك"})
        Me.cbway.Location = New System.Drawing.Point(35, 80)
        Me.cbway.Name = "cbway"
        Me.cbway.Size = New System.Drawing.Size(156, 28)
        Me.cbway.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(228, 173)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "المبلغ"
        '
        'lbnum
        '
        Me.lbnum.AutoSize = True
        Me.lbnum.Location = New System.Drawing.Point(207, 124)
        Me.lbnum.Name = "lbnum"
        Me.lbnum.Size = New System.Drawing.Size(53, 13)
        Me.lbnum.TabIndex = 3
        Me.lbnum.Text = "رقم الشيك"
        Me.lbnum.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(200, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "طريقة الدفع"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GroupBox1.Controls.Add(Me.cbway)
        Me.GroupBox1.Controls.Add(Me.btcon)
        Me.GroupBox1.Controls.Add(Me.btcancel)
        Me.GroupBox1.Controls.Add(Me.lbnum)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtnum)
        Me.GroupBox1.Controls.Add(Me.txtmontant)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(297, 347)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "العمليات"
        '
        'btcon
        '
        Me.btcon.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btcon.FlatAppearance.BorderSize = 2
        Me.btcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btcon.Font = New System.Drawing.Font("ae_AlArabiya", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btcon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btcon.Image = CType(resources.GetObject("btcon.Image"), System.Drawing.Image)
        Me.btcon.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btcon.Location = New System.Drawing.Point(130, 262)
        Me.btcon.Name = "btcon"
        Me.btcon.Size = New System.Drawing.Size(130, 50)
        Me.btcon.TabIndex = 4
        Me.btcon.Tag = "0"
        Me.btcon.Text = "تأكيد     "
        Me.btcon.UseVisualStyleBackColor = True
        '
        'btcancel
        '
        Me.btcancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btcancel.FlatAppearance.BorderSize = 2
        Me.btcancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btcancel.Font = New System.Drawing.Font("ae_AlArabiya", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btcancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btcancel.Image = CType(resources.GetObject("btcancel.Image"), System.Drawing.Image)
        Me.btcancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btcancel.Location = New System.Drawing.Point(35, 277)
        Me.btcancel.Name = "btcancel"
        Me.btcancel.Size = New System.Drawing.Size(85, 35)
        Me.btcancel.TabIndex = 5
        Me.btcancel.Text = "الغاء"
        Me.btcancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btcancel.UseVisualStyleBackColor = True
        '
        'txtnum
        '
        Me.txtnum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtnum.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnum.Location = New System.Drawing.Point(35, 114)
        Me.txtnum.Name = "txtnum"
        Me.txtnum.Size = New System.Drawing.Size(156, 26)
        Me.txtnum.TabIndex = 2
        Me.txtnum.Text = "0"
        Me.txtnum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtnum.Visible = False
        '
        'txtmontant
        '
        Me.txtmontant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtmontant.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmontant.Location = New System.Drawing.Point(35, 166)
        Me.txtmontant.Name = "txtmontant"
        Me.txtmontant.Size = New System.Drawing.Size(156, 26)
        Me.txtmontant.TabIndex = 2
        Me.txtmontant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'paypmt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(297, 347)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "paypmt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "المبلغ"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbway As System.Windows.Forms.ComboBox
    Friend WithEvents btcon As System.Windows.Forms.Button
    Friend WithEvents btcancel As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbnum As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtnum As System.Windows.Forms.TextBox
    Friend WithEvents txtmontant As System.Windows.Forms.TextBox
End Class
