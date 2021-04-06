<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PricingParams
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtImgPr = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtImgSl = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMsg = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbSl = New System.Windows.Forms.ComboBox()
        Me.cbPr = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtImgScanner = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(330, 56)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(39, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "...."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(42, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(159, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Path Images  Produits"
        '
        'txtImgPr
        '
        Me.txtImgPr.Location = New System.Drawing.Point(45, 58)
        Me.txtImgPr.Name = "txtImgPr"
        Me.txtImgPr.Size = New System.Drawing.Size(279, 20)
        Me.txtImgPr.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(330, 113)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(39, 23)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "...."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(42, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Path Images Slider"
        '
        'txtImgSl
        '
        Me.txtImgSl.Location = New System.Drawing.Point(45, 115)
        Me.txtImgSl.Name = "txtImgSl"
        Me.txtImgSl.Size = New System.Drawing.Size(279, 20)
        Me.txtImgSl.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(42, 204)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Text Message"
        '
        'txtMsg
        '
        Me.txtMsg.Location = New System.Drawing.Point(45, 223)
        Me.txtMsg.Name = "txtMsg"
        Me.txtMsg.Size = New System.Drawing.Size(324, 20)
        Me.txtMsg.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(42, 258)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Slider Interval"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(234, 258)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 16)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Produit  Interval"
        '
        'cbSl
        '
        Me.cbSl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSl.FormattingEnabled = True
        Me.cbSl.Items.AddRange(New Object() {"5", "10", "20", "30", "60"})
        Me.cbSl.Location = New System.Drawing.Point(45, 287)
        Me.cbSl.Name = "cbSl"
        Me.cbSl.Size = New System.Drawing.Size(121, 21)
        Me.cbSl.TabIndex = 3
        '
        'cbPr
        '
        Me.cbPr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPr.FormattingEnabled = True
        Me.cbPr.Items.AddRange(New Object() {"5", "10", "20", "30", "60"})
        Me.cbPr.Location = New System.Drawing.Point(237, 287)
        Me.cbPr.Name = "cbPr"
        Me.cbPr.Size = New System.Drawing.Size(121, 21)
        Me.cbPr.TabIndex = 3
        '
        'Button3
        '
        Me.Button3.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.bbuy
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Gold
        Me.Button3.Location = New System.Drawing.Point(45, 353)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(324, 39)
        Me.Button3.TabIndex = 0
        Me.Button3.Text = "Valider"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(330, 168)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(39, 23)
        Me.Button4.TabIndex = 0
        Me.Button4.Text = "...."
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(42, 151)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 16)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Image de Code"
        '
        'txtImgScanner
        '
        Me.txtImgScanner.Location = New System.Drawing.Point(45, 170)
        Me.txtImgScanner.Name = "txtImgScanner"
        Me.txtImgScanner.Size = New System.Drawing.Size(279, 20)
        Me.txtImgScanner.TabIndex = 2
        '
        'PricingParams
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(422, 423)
        Me.Controls.Add(Me.cbPr)
        Me.Controls.Add(Me.cbSl)
        Me.Controls.Add(Me.txtMsg)
        Me.Controls.Add(Me.txtImgScanner)
        Me.Controls.Add(Me.txtImgSl)
        Me.Controls.Add(Me.txtImgPr)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "PricingParams"
        Me.Text = "Paramettres"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtImgPr As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtImgSl As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMsg As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbSl As System.Windows.Forms.ComboBox
    Friend WithEvents cbPr As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtImgScanner As System.Windows.Forms.TextBox
End Class
