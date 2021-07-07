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
        Me.lbP = New System.Windows.Forms.Label()
        Me.PL.SuspendLayout()
        Me.plB.SuspendLayout()
        Me.SuspendLayout()
        '
        'PL
        '
        Me.PL.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PL.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.WhatsApp_Image_2021_06_02_at_17_59_22
        Me.PL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PL.Controls.Add(Me.plB)
        Me.PL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PL.Location = New System.Drawing.Point(8, 8)
        Me.PL.Name = "PL"
        Me.PL.Size = New System.Drawing.Size(182, 189)
        Me.PL.TabIndex = 0
        '
        'plB
        '
        Me.plB.BackColor = System.Drawing.Color.Transparent
        Me.plB.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.BGPVAR_2
        Me.plB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plB.Controls.Add(Me.lb)
        Me.plB.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.plB.Location = New System.Drawing.Point(0, 149)
        Me.plB.Name = "plB"
        Me.plB.Padding = New System.Windows.Forms.Padding(2, 2, 2, 0)
        Me.plB.Size = New System.Drawing.Size(182, 40)
        Me.plB.TabIndex = 1
        '
        'lb
        '
        Me.lb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lb.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lb.Location = New System.Drawing.Point(2, 2)
        Me.lb.Name = "lb"
        Me.lb.Size = New System.Drawing.Size(178, 38)
        Me.lb.TabIndex = 0
        Me.lb.Text = "Label1"
        Me.lb.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lbP
        '
        Me.lbP.AutoSize = True
        Me.lbP.BackColor = System.Drawing.Color.MidnightBlue
        Me.lbP.Font = New System.Drawing.Font("Arial Rounded MT Bold", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbP.ForeColor = System.Drawing.Color.White
        Me.lbP.Location = New System.Drawing.Point(0, 8)
        Me.lbP.Name = "lbP"
        Me.lbP.Padding = New System.Windows.Forms.Padding(8, 2, 4, 2)
        Me.lbP.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbP.Size = New System.Drawing.Size(45, 15)
        Me.lbP.TabIndex = 3
        Me.lbP.Text = "Label1"
        Me.lbP.Visible = False
        '
        'PvArticle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.WhatsApp_Image_2021_06_02_at_17_59_22__1_
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.lbP)
        Me.Controls.Add(Me.PL)
        Me.DoubleBuffered = True
        Me.Name = "PvArticle"
        Me.Padding = New System.Windows.Forms.Padding(8, 8, 8, 6)
        Me.Size = New System.Drawing.Size(198, 203)
        Me.PL.ResumeLayout(False)
        Me.plB.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PL As System.Windows.Forms.Panel
    Friend WithEvents plB As System.Windows.Forms.Panel
    Friend WithEvents lb As System.Windows.Forms.Label
    Friend WithEvents lbP As System.Windows.Forms.Label

End Class
