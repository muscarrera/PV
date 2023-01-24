<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PromoArticleBloc
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbQte = New System.Windows.Forms.Label()
        Me.lbPoints = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lbName = New System.Windows.Forms.Label()
        Me.lbType = New System.Windows.Forms.Label()
        Me.lbValide = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Qte :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Points :"
        '
        'lbQte
        '
        Me.lbQte.AutoSize = True
        Me.lbQte.Font = New System.Drawing.Font("Century Gothic", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQte.Location = New System.Drawing.Point(67, 54)
        Me.lbQte.Name = "lbQte"
        Me.lbQte.Size = New System.Drawing.Size(16, 18)
        Me.lbQte.TabIndex = 2
        Me.lbQte.Text = "1"
        '
        'lbPoints
        '
        Me.lbPoints.AutoSize = True
        Me.lbPoints.Font = New System.Drawing.Font("Century Gothic", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPoints.Location = New System.Drawing.Point(67, 73)
        Me.lbPoints.Name = "lbPoints"
        Me.lbPoints.Size = New System.Drawing.Size(16, 18)
        Me.lbPoints.TabIndex = 2
        Me.lbPoints.Text = "1"
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.FACTURE_20
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(185, 90)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.stock_icon_png_14
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(149, 90)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(30, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lbName
        '
        Me.lbName.BackColor = System.Drawing.Color.Transparent
        Me.lbName.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbName.Font = New System.Drawing.Font("Century Gothic", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbName.ForeColor = System.Drawing.Color.DarkOrange
        Me.lbName.Location = New System.Drawing.Point(5, 5)
        Me.lbName.Name = "lbName"
        Me.lbName.Size = New System.Drawing.Size(210, 41)
        Me.lbName.TabIndex = 2
        Me.lbName.Text = "npù"
        Me.lbName.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lbType
        '
        Me.lbType.BackColor = System.Drawing.Color.Sienna
        Me.lbType.Font = New System.Drawing.Font("Century Gothic", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbType.ForeColor = System.Drawing.Color.White
        Me.lbType.Location = New System.Drawing.Point(8, 95)
        Me.lbType.Name = "lbType"
        Me.lbType.Size = New System.Drawing.Size(53, 18)
        Me.lbType.TabIndex = 2
        Me.lbType.Text = "Remise"
        Me.lbType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbValide
        '
        Me.lbValide.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lbValide.Font = New System.Drawing.Font("Century Gothic", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbValide.ForeColor = System.Drawing.Color.White
        Me.lbValide.Location = New System.Drawing.Point(67, 95)
        Me.lbValide.Name = "lbValide"
        Me.lbValide.Size = New System.Drawing.Size(53, 18)
        Me.lbValide.TabIndex = 2
        Me.lbValide.Text = "encours"
        Me.lbValide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PromoArticle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.WhatsApp_Image_2021_06_02_at_13_13_57__1_
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lbPoints)
        Me.Controls.Add(Me.lbValide)
        Me.Controls.Add(Me.lbType)
        Me.Controls.Add(Me.lbQte)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbName)
        Me.Controls.Add(Me.Label4)
        Me.Name = "PromoArticle"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.Size = New System.Drawing.Size(220, 120)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbQte As System.Windows.Forms.Label
    Friend WithEvents lbPoints As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lbName As System.Windows.Forms.Label
    Friend WithEvents lbType As System.Windows.Forms.Label
    Friend WithEvents lbValide As System.Windows.Forms.Label

End Class
