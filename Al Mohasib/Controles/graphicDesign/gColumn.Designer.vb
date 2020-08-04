<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gColumn
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
        Me.lbHeader = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtT = New Al_Mohasib.TxtBox()
        Me.txtW = New Al_Mohasib.TxtBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbHeader
        '
        Me.lbHeader.BackColor = System.Drawing.Color.Gainsboro
        Me.lbHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbHeader.Location = New System.Drawing.Point(0, 0)
        Me.lbHeader.Name = "lbHeader"
        Me.lbHeader.Size = New System.Drawing.Size(160, 42)
        Me.lbHeader.TabIndex = 2
        Me.lbHeader.Text = "Header"
        Me.lbHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 31)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Large"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 34)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Text"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtT
        '
        Me.txtT.BackColor = System.Drawing.Color.Transparent
        Me.txtT.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtT.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtT.IsNumiric = False
        Me.txtT.Location = New System.Drawing.Point(0, 34)
        Me.txtT.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtT.Name = "txtT"
        Me.txtT.ShowClearIcon = False
        Me.txtT.ShowSaveIcon = False
        Me.txtT.Size = New System.Drawing.Size(160, 30)
        Me.txtT.StartUp = 2
        Me.txtT.TabIndex = 6
        Me.txtT.TextSize = 8
        Me.txtT.TxtBackColor = True
        Me.txtT.TxtColor = System.Drawing.Color.White
        Me.txtT.txtReadOnly = False
        Me.txtT.TxtSelect = New Integer() {1, 0}
        '
        'txtW
        '
        Me.txtW.BackColor = System.Drawing.Color.Transparent
        Me.txtW.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtW.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtW.IsNumiric = False
        Me.txtW.Location = New System.Drawing.Point(0, 95)
        Me.txtW.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtW.Name = "txtW"
        Me.txtW.ShowClearIcon = False
        Me.txtW.ShowSaveIcon = False
        Me.txtW.Size = New System.Drawing.Size(160, 30)
        Me.txtW.StartUp = 2
        Me.txtW.TabIndex = 7
        Me.txtW.TextSize = 8
        Me.txtW.TxtBackColor = True
        Me.txtW.TxtColor = System.Drawing.Color.White
        Me.txtW.txtReadOnly = False
        Me.txtW.TxtSelect = New Integer() {1, 0}
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtW)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtT)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 42)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(160, 228)
        Me.Panel1.TabIndex = 8
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.CANCEL_22
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(141, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'gColumn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lbHeader)
        Me.Name = "gColumn"
        Me.Size = New System.Drawing.Size(160, 270)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbHeader As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtT As Al_Mohasib.TxtBox
    Friend WithEvents txtW As Al_Mohasib.TxtBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
