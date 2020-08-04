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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btPrint = New System.Windows.Forms.Button()
        Me.cbway = New System.Windows.Forms.ComboBox()
        Me.txtmontant = New Al_Mohasib.TxtBox()
        Me.btcon = New System.Windows.Forms.Button()
        Me.btcancel = New System.Windows.Forms.Button()
        Me.lbnum = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtnum = New System.Windows.Forms.TextBox()
        Me.PrintDoc = New System.Drawing.Printing.PrintDocument()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GroupBox1.Controls.Add(Me.btPrint)
        Me.GroupBox1.Controls.Add(Me.cbway)
        Me.GroupBox1.Controls.Add(Me.txtmontant)
        Me.GroupBox1.Controls.Add(Me.btcon)
        Me.GroupBox1.Controls.Add(Me.btcancel)
        Me.GroupBox1.Controls.Add(Me.lbnum)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtnum)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(446, 469)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "العمليات"
        '
        'btPrint
        '
        Me.btPrint.AllowDrop = True
        Me.btPrint.BackColor = System.Drawing.Color.Transparent
        Me.btPrint.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.btprt
        Me.btPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btPrint.FlatAppearance.BorderSize = 0
        Me.btPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btPrint.Location = New System.Drawing.Point(68, 358)
        Me.btPrint.Name = "btPrint"
        Me.btPrint.Size = New System.Drawing.Size(92, 42)
        Me.btPrint.TabIndex = 18
        Me.btPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btPrint.UseVisualStyleBackColor = False
        '
        'cbway
        '
        Me.cbway.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbway.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbway.FormattingEnabled = True
        Me.cbway.Items.AddRange(New Object() {"Cache", "Cheque", "Effet (LC)", "Virement Bancaire", "Non Reglé"})
        Me.cbway.Location = New System.Drawing.Point(80, 72)
        Me.cbway.Name = "cbway"
        Me.cbway.Size = New System.Drawing.Size(265, 28)
        Me.cbway.TabIndex = 17
        '
        'txtmontant
        '
        Me.txtmontant.BackColor = System.Drawing.Color.Transparent
        Me.txtmontant.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtmontant.IsNumiric = True
        Me.txtmontant.Location = New System.Drawing.Point(80, 239)
        Me.txtmontant.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtmontant.Name = "txtmontant"
        Me.txtmontant.ShowClearIcon = False
        Me.txtmontant.ShowSaveIcon = False
        Me.txtmontant.Size = New System.Drawing.Size(265, 30)
        Me.txtmontant.StartUp = 2
        Me.txtmontant.TabIndex = 16
        Me.txtmontant.TextSize = 8
        Me.txtmontant.TxtBackColor = True
        Me.txtmontant.TxtColor = System.Drawing.Color.White
        Me.txtmontant.txtReadOnly = False
        Me.txtmontant.TxtSelect = New Integer() {1, 0}
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
        Me.btcon.Location = New System.Drawing.Point(80, 298)
        Me.btcon.Name = "btcon"
        Me.btcon.Size = New System.Drawing.Size(265, 50)
        Me.btcon.TabIndex = 14
        Me.btcon.Tag = "0"
        Me.btcon.Text = "Valider"
        Me.btcon.UseVisualStyleBackColor = True
        '
        'btcancel
        '
        Me.btcancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btcancel.FlatAppearance.BorderSize = 2
        Me.btcancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btcancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btcancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btcancel.Image = CType(resources.GetObject("btcancel.Image"), System.Drawing.Image)
        Me.btcancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btcancel.Location = New System.Drawing.Point(228, 365)
        Me.btcancel.Name = "btcancel"
        Me.btcancel.Size = New System.Drawing.Size(117, 35)
        Me.btcancel.TabIndex = 15
        Me.btcancel.Text = "Annuler"
        Me.btcancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btcancel.UseVisualStyleBackColor = True
        '
        'lbnum
        '
        Me.lbnum.AutoSize = True
        Me.lbnum.Location = New System.Drawing.Point(77, 128)
        Me.lbnum.Name = "lbnum"
        Me.lbnum.Size = New System.Drawing.Size(63, 13)
        Me.lbnum.TabIndex = 11
        Me.lbnum.Text = "Designation"
        Me.lbnum.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(83, 223)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Montant"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(84, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Methode de paiement"
        '
        'txtnum
        '
        Me.txtnum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtnum.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnum.Location = New System.Drawing.Point(80, 144)
        Me.txtnum.Name = "txtnum"
        Me.txtnum.Size = New System.Drawing.Size(265, 26)
        Me.txtnum.TabIndex = 10
        Me.txtnum.Text = "0"
        Me.txtnum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtnum.Visible = False
        '
        'PrintDoc
        '
        '
        'paypmt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(446, 469)
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btPrint As System.Windows.Forms.Button
    Friend WithEvents cbway As System.Windows.Forms.ComboBox
    Friend WithEvents txtmontant As Al_Mohasib.TxtBox
    Friend WithEvents btcon As System.Windows.Forms.Button
    Friend WithEvents btcancel As System.Windows.Forms.Button
    Friend WithEvents lbnum As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtnum As System.Windows.Forms.TextBox
    Friend WithEvents PrintDoc As System.Drawing.Printing.PrintDocument
End Class
