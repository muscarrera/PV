<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Screen2
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
        Me.PrintDocdepot = New System.Drawing.Printing.PrintDocument()
        Me.PrintDoc = New System.Drawing.Printing.PrintDocument()
        Me.PrintDocRes = New System.Drawing.Printing.PrintDocument()
        Me.pl = New System.Windows.Forms.Panel()
        Me.PlItems = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LbSum = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PlBg = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.plB = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.plMsg = New System.Windows.Forms.Panel()
        Me.lbMsg = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.plLogo = New System.Windows.Forms.Panel()
        Me.pl.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PlBg.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.plMsg.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pl
        '
        Me.pl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pl.BackColor = System.Drawing.Color.White
        Me.pl.Controls.Add(Me.PlItems)
        Me.pl.Controls.Add(Me.Panel1)
        Me.pl.Location = New System.Drawing.Point(186, 6)
        Me.pl.Name = "pl"
        Me.pl.Padding = New System.Windows.Forms.Padding(10)
        Me.pl.Size = New System.Drawing.Size(490, 509)
        Me.pl.TabIndex = 1
        '
        'PlItems
        '
        Me.PlItems.AutoScroll = True
        Me.PlItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PlItems.Location = New System.Drawing.Point(10, 10)
        Me.PlItems.Name = "PlItems"
        Me.PlItems.Size = New System.Drawing.Size(470, 407)
        Me.PlItems.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.LbSum)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(10, 417)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(470, 82)
        Me.Panel1.TabIndex = 2
        '
        'LbSum
        '
        Me.LbSum.BackColor = System.Drawing.Color.Transparent
        Me.LbSum.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LbSum.Font = New System.Drawing.Font("Century Gothic", 24.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbSum.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LbSum.Location = New System.Drawing.Point(165, 0)
        Me.LbSum.Name = "LbSum"
        Me.LbSum.Size = New System.Drawing.Size(305, 82)
        Me.LbSum.TabIndex = 2
        Me.LbSum.Text = "00.00"
        Me.LbSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 82)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Total Net"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PlBg
        '
        Me.PlBg.BackColor = System.Drawing.Color.Gray
        Me.PlBg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PlBg.Controls.Add(Me.pl)
        Me.PlBg.Controls.Add(Me.Panel5)
        Me.PlBg.Controls.Add(Me.plB)
        Me.PlBg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PlBg.Location = New System.Drawing.Point(0, 100)
        Me.PlBg.Name = "PlBg"
        Me.PlBg.Size = New System.Drawing.Size(994, 521)
        Me.PlBg.TabIndex = 4
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.BGPVAR_33
        Me.Panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(2, 2, 2, 0)
        Me.Panel5.Size = New System.Drawing.Size(994, 66)
        Me.Panel5.TabIndex = 3
        '
        'plB
        '
        Me.plB.BackColor = System.Drawing.Color.Transparent
        Me.plB.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.BGPVAR_2
        Me.plB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plB.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.plB.Location = New System.Drawing.Point(0, 455)
        Me.plB.Name = "plB"
        Me.plB.Padding = New System.Windows.Forms.Padding(2, 2, 2, 0)
        Me.plB.Size = New System.Drawing.Size(994, 66)
        Me.plB.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.BGzAKHdOWN
        Me.Panel3.Controls.Add(Me.plMsg)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 621)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(994, 100)
        Me.Panel3.TabIndex = 3
        '
        'plMsg
        '
        Me.plMsg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.plMsg.BackColor = System.Drawing.Color.Transparent
        Me.plMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.plMsg.Controls.Add(Me.lbMsg)
        Me.plMsg.Location = New System.Drawing.Point(188, 12)
        Me.plMsg.Name = "plMsg"
        Me.plMsg.Padding = New System.Windows.Forms.Padding(4)
        Me.plMsg.Size = New System.Drawing.Size(612, 43)
        Me.plMsg.TabIndex = 1
        '
        'lbMsg
        '
        Me.lbMsg.BackColor = System.Drawing.Color.DarkSlateGray
        Me.lbMsg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbMsg.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMsg.ForeColor = System.Drawing.Color.White
        Me.lbMsg.Location = New System.Drawing.Point(4, 4)
        Me.lbMsg.Name = "lbMsg"
        Me.lbMsg.Size = New System.Drawing.Size(602, 33)
        Me.lbMsg.TabIndex = 0
        Me.lbMsg.Text = "*****"
        Me.lbMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.BGzAKH1
        Me.Panel2.Controls.Add(Me.plLogo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(994, 100)
        Me.Panel2.TabIndex = 2
        '
        'plLogo
        '
        Me.plLogo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.plLogo.BackColor = System.Drawing.Color.Transparent
        Me.plLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.plLogo.Location = New System.Drawing.Point(186, 12)
        Me.plLogo.Name = "plLogo"
        Me.plLogo.Size = New System.Drawing.Size(612, 82)
        Me.plLogo.TabIndex = 0
        '
        'Screen2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(994, 721)
        Me.Controls.Add(Me.PlBg)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Screen2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "       R  E  C  E  P  T"
        Me.pl.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.PlBg.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.plMsg.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PrintDocdepot As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDoc As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDocRes As System.Drawing.Printing.PrintDocument
    Friend WithEvents pl As System.Windows.Forms.Panel
    Friend WithEvents PlItems As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LbSum As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PlBg As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents plB As System.Windows.Forms.Panel
    Friend WithEvents plLogo As System.Windows.Forms.Panel
    Friend WithEvents plMsg As System.Windows.Forms.Panel
    Friend WithEvents lbMsg As System.Windows.Forms.Label
End Class
