<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PricingGetter
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
        Me.components = New System.ComponentModel.Container()
        Me.pb = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PlButtom = New System.Windows.Forms.Panel()
        Me.PLimage = New System.Windows.Forms.Panel()
        Me.lbInfo = New System.Windows.Forms.Label()
        Me.pbScanner = New System.Windows.Forms.PictureBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txt = New System.Windows.Forms.TextBox()
        Me.pl = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PbProduct = New System.Windows.Forms.PictureBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.plTrial = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbtrial = New System.Windows.Forms.Label()
        Me.pb.SuspendLayout()
        Me.PlButtom.SuspendLayout()
        Me.PLimage.SuspendLayout()
        CType(Me.pbScanner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pl.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PbProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pb
        '
        Me.pb.BackColor = System.Drawing.Color.Maroon
        Me.pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pb.Controls.Add(Me.Panel2)
        Me.pb.Controls.Add(Me.Panel3)
        Me.pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pb.Location = New System.Drawing.Point(0, 0)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(724, 502)
        Me.pb.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.BGPVAR_21
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(166, 502)
        Me.Panel2.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.BGPVAR_22
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(599, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(125, 502)
        Me.Panel3.TabIndex = 0
        '
        'PlButtom
        '
        Me.PlButtom.Controls.Add(Me.PLimage)
        Me.PlButtom.Controls.Add(Me.Panel4)
        Me.PlButtom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PlButtom.Location = New System.Drawing.Point(0, 351)
        Me.PlButtom.Name = "PlButtom"
        Me.PlButtom.Padding = New System.Windows.Forms.Padding(11)
        Me.PlButtom.Size = New System.Drawing.Size(724, 151)
        Me.PlButtom.TabIndex = 0
        '
        'PLimage
        '
        Me.PLimage.BackColor = System.Drawing.Color.White
        Me.PLimage.Controls.Add(Me.lbInfo)
        Me.PLimage.Controls.Add(Me.pbScanner)
        Me.PLimage.Controls.Add(Me.Panel8)
        Me.PLimage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PLimage.Location = New System.Drawing.Point(11, 11)
        Me.PLimage.Name = "PLimage"
        Me.PLimage.Size = New System.Drawing.Size(702, 112)
        Me.PLimage.TabIndex = 0
        '
        'lbInfo
        '
        Me.lbInfo.BackColor = System.Drawing.Color.White
        Me.lbInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbInfo.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbInfo.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lbInfo.Location = New System.Drawing.Point(45, 0)
        Me.lbInfo.Name = "lbInfo"
        Me.lbInfo.Size = New System.Drawing.Size(475, 112)
        Me.lbInfo.TabIndex = 2
        Me.lbInfo.Text = "اســــم المـــــادة"
        Me.lbInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbScanner
        '
        Me.pbScanner.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.s_l300
        Me.pbScanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbScanner.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbScanner.Location = New System.Drawing.Point(520, 0)
        Me.pbScanner.Name = "pbScanner"
        Me.pbScanner.Size = New System.Drawing.Size(182, 112)
        Me.pbScanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbScanner.TabIndex = 20
        Me.pbScanner.TabStop = False
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.plTrial)
        Me.Panel8.Controls.Add(Me.Panel9)
        Me.Panel8.Controls.Add(Me.Panel7)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(45, 112)
        Me.Panel8.TabIndex = 19
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.White
        Me.Panel9.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.iconfinder_Gnome_Emblem_System_48_55301
        Me.Panel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(45, 40)
        Me.Panel9.TabIndex = 19
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.White
        Me.Panel7.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources._500px_Crystal_Clear_action_exit_svg
        Me.Panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(0, 76)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(45, 36)
        Me.Panel7.TabIndex = 18
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Brown
        Me.Panel4.Controls.Add(Me.lbtrial)
        Me.Panel4.Controls.Add(Me.txt)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(11, 123)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(702, 17)
        Me.Panel4.TabIndex = 0
        '
        'txt
        '
        Me.txt.Location = New System.Drawing.Point(109, 60)
        Me.txt.Name = "txt"
        Me.txt.Size = New System.Drawing.Size(478, 20)
        Me.txt.TabIndex = 0
        '
        'pl
        '
        Me.pl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pl.Controls.Add(Me.Panel5)
        Me.pl.Controls.Add(Me.Panel6)
        Me.pl.Controls.Add(Me.Panel1)
        Me.pl.Location = New System.Drawing.Point(109, 31)
        Me.pl.Name = "pl"
        Me.pl.Size = New System.Drawing.Size(526, 347)
        Me.pl.TabIndex = 0
        Me.pl.Visible = False
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.PbProduct)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(524, 201)
        Me.Panel5.TabIndex = 0
        '
        'PbProduct
        '
        Me.PbProduct.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.bgLightForm
        Me.PbProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PbProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PbProduct.Image = Global.Al_Mohasib.My.Resources.Resources.consumer_products
        Me.PbProduct.Location = New System.Drawing.Point(0, 0)
        Me.PbProduct.Name = "PbProduct"
        Me.PbProduct.Size = New System.Drawing.Size(524, 201)
        Me.PbProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbProduct.TabIndex = 0
        Me.PbProduct.TabStop = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(0, 201)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(524, 62)
        Me.Panel6.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.bbuy
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 263)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(524, 82)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Tai Le", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gold
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(524, 82)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "22.45"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10000
        '
        'Timer2
        '
        Me.Timer2.Interval = 22222
        '
        'plTrial
        '
        Me.plTrial.BackColor = System.Drawing.Color.White
        Me.plTrial.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.icon_manage_user
        Me.plTrial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.plTrial.Dock = System.Windows.Forms.DockStyle.Top
        Me.plTrial.Location = New System.Drawing.Point(0, 40)
        Me.plTrial.Name = "plTrial"
        Me.plTrial.Size = New System.Drawing.Size(45, 40)
        Me.plTrial.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(524, 62)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "اســــم المـــــادة"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbtrial
        '
        Me.lbtrial.BackColor = System.Drawing.Color.Transparent
        Me.lbtrial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbtrial.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbtrial.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbtrial.Location = New System.Drawing.Point(0, 0)
        Me.lbtrial.Name = "lbtrial"
        Me.lbtrial.Size = New System.Drawing.Size(702, 17)
        Me.lbtrial.TabIndex = 2
        Me.lbtrial.Text = "1"
        Me.lbtrial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PricingGetter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 502)
        Me.Controls.Add(Me.pl)
        Me.Controls.Add(Me.PlButtom)
        Me.Controls.Add(Me.pb)
        Me.Name = "PricingGetter"
        Me.Text = "PricingGetter"
        Me.pb.ResumeLayout(False)
        Me.PlButtom.ResumeLayout(False)
        Me.PLimage.ResumeLayout(False)
        CType(Me.pbScanner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pl.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.PbProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pb As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PlButtom As System.Windows.Forms.Panel
    Friend WithEvents pl As System.Windows.Forms.Panel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents PbProduct As System.Windows.Forms.PictureBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PLimage As System.Windows.Forms.Panel
    Friend WithEvents lbInfo As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents txt As System.Windows.Forms.TextBox
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents pbScanner As System.Windows.Forms.PictureBox
    Friend WithEvents plTrial As System.Windows.Forms.Panel
    Friend WithEvents lbtrial As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
