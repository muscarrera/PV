<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PvArticle
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
        Me.PL = New System.Windows.Forms.Panel()
        Me.plB = New System.Windows.Forms.Panel()
        Me.lb = New System.Windows.Forms.Label()
        Me.lbBP = New System.Windows.Forms.Label()
        Me.btInfo = New System.Windows.Forms.Button()
        Me.lbP = New System.Windows.Forms.Label()
        Me.bk = New System.ComponentModel.BackgroundWorker()
        Me.PL.SuspendLayout()
        Me.plB.SuspendLayout()
        Me.SuspendLayout()
        '
        'PL
        '
        Me.PL.BackColor = System.Drawing.Color.White
        Me.PL.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.WhatsApp_Image_2021_06_02_at_17_59_22
        Me.PL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PL.Controls.Add(Me.plB)
        Me.PL.Controls.Add(Me.lbBP)
        Me.PL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PL.Location = New System.Drawing.Point(11, 10)
        Me.PL.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PL.Name = "PL"
        Me.PL.Size = New System.Drawing.Size(242, 233)
        Me.PL.TabIndex = 0
        '
        'plB
        '
        Me.plB.BackColor = System.Drawing.Color.Transparent
        Me.plB.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.BGPVAR_2
        Me.plB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plB.Controls.Add(Me.lb)
        Me.plB.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.plB.Location = New System.Drawing.Point(0, 184)
        Me.plB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.plB.Name = "plB"
        Me.plB.Padding = New System.Windows.Forms.Padding(3, 2, 3, 0)
        Me.plB.Size = New System.Drawing.Size(242, 49)
        Me.plB.TabIndex = 1
        '
        'lb
        '
        Me.lb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lb.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lb.Location = New System.Drawing.Point(3, 2)
        Me.lb.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb.Name = "lb"
        Me.lb.Size = New System.Drawing.Size(236, 47)
        Me.lb.TabIndex = 0
        Me.lb.Text = "Label1"
        Me.lb.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lbBP
        '
        Me.lbBP.AutoSize = True
        Me.lbBP.BackColor = System.Drawing.Color.DarkMagenta
        Me.lbBP.Font = New System.Drawing.Font("Arial Rounded MT Bold", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbBP.ForeColor = System.Drawing.Color.White
        Me.lbBP.Location = New System.Drawing.Point(67, 0)
        Me.lbBP.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbBP.Name = "lbBP"
        Me.lbBP.Padding = New System.Windows.Forms.Padding(11, 2, 5, 2)
        Me.lbBP.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbBP.Size = New System.Drawing.Size(30, 18)
        Me.lbBP.TabIndex = 3
        Me.lbBP.Text = "0"
        Me.lbBP.Visible = False
        '
        'btInfo
        '
        Me.btInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btInfo.BackColor = System.Drawing.Color.Transparent
        Me.btInfo.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources._3643768_info_information_letter_mark_sign_icon__1_
        Me.btInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btInfo.FlatAppearance.BorderSize = 0
        Me.btInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btInfo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btInfo.Location = New System.Drawing.Point(225, 6)
        Me.btInfo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btInfo.Name = "btInfo"
        Me.btInfo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.btInfo.Size = New System.Drawing.Size(33, 31)
        Me.btInfo.TabIndex = 2
        Me.btInfo.UseVisualStyleBackColor = False
        Me.btInfo.Visible = False
        '
        'lbP
        '
        Me.lbP.AutoSize = True
        Me.lbP.BackColor = System.Drawing.Color.MidnightBlue
        Me.lbP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbP.ForeColor = System.Drawing.Color.White
        Me.lbP.Location = New System.Drawing.Point(0, 10)
        Me.lbP.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbP.Name = "lbP"
        Me.lbP.Padding = New System.Windows.Forms.Padding(11, 2, 5, 2)
        Me.lbP.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbP.Size = New System.Drawing.Size(70, 20)
        Me.lbP.TabIndex = 3
        Me.lbP.Text = "Label1"
        Me.lbP.Visible = False
        '
        'bk
        '
        '
        'PvArticle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.WhatsApp_Image_2021_06_02_at_17_59_22__1_
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.btInfo)
        Me.Controls.Add(Me.lbP)
        Me.Controls.Add(Me.PL)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "PvArticle"
        Me.Padding = New System.Windows.Forms.Padding(11, 10, 11, 7)
        Me.Size = New System.Drawing.Size(264, 250)
        Me.PL.ResumeLayout(False)
        Me.PL.PerformLayout()
        Me.plB.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PL As System.Windows.Forms.Panel
    Friend WithEvents plB As System.Windows.Forms.Panel
    Friend WithEvents lb As System.Windows.Forms.Label
    Friend WithEvents lbP As System.Windows.Forms.Label
    Friend WithEvents btInfo As System.Windows.Forms.Button
    Friend WithEvents bk As System.ComponentModel.BackgroundWorker
    Friend WithEvents lbBP As System.Windows.Forms.Label

End Class
