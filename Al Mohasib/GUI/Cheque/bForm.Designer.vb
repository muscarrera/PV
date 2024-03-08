<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class bForm
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
        Me.PT = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.plCh = New System.Windows.Forms.Panel()
        Me.pb = New System.Windows.Forms.PictureBox()
        Me.btLand = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Txt_W = New Al_Mohasib.TxtBox()
        Me.Txt_H = New Al_Mohasib.TxtBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbPage = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.plCh.SuspendLayout()
        CType(Me.pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PT
        '
        Me.PT.BackColor = System.Drawing.Color.Bisque
        Me.PT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PT.Location = New System.Drawing.Point(0, 0)
        Me.PT.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PT.Name = "PT"
        Me.PT.Size = New System.Drawing.Size(456, 831)
        Me.PT.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(717, 30)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 17)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Cheque :"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PT)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(456, 831)
        Me.Panel1.TabIndex = 18
        '
        'Button4
        '
        Me.Button4.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.iconfinder_Folder_Settings_Tools_icon_88583_X_24
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button4.Location = New System.Drawing.Point(1085, 11)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(59, 44)
        Me.Button4.TabIndex = 10
        Me.Button4.UseVisualStyleBackColor = True
        '
        'plCh
        '
        Me.plCh.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.BG_BOOK
        Me.plCh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plCh.Controls.Add(Me.pb)
        Me.plCh.Location = New System.Drawing.Point(507, 68)
        Me.plCh.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.plCh.Name = "plCh"
        Me.plCh.Padding = New System.Windows.Forms.Padding(53, 222, 27, 49)
        Me.plCh.Size = New System.Drawing.Size(1120, 738)
        Me.plCh.TabIndex = 19
        '
        'pb
        '
        Me.pb.BackColor = System.Drawing.Color.White
        Me.pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pb.Location = New System.Drawing.Point(53, 222)
        Me.pb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(1040, 467)
        Me.pb.TabIndex = 5
        Me.pb.TabStop = False
        '
        'btLand
        '
        Me.btLand.BackColor = System.Drawing.Color.Transparent
        Me.btLand.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.FACTURE_20
        Me.btLand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btLand.FlatAppearance.BorderSize = 0
        Me.btLand.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btLand.Location = New System.Drawing.Point(1039, 12)
        Me.btLand.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btLand.Name = "btLand"
        Me.btLand.Size = New System.Drawing.Size(39, 44)
        Me.btLand.TabIndex = 8
        Me.btLand.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.SAVE_20
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.Location = New System.Drawing.Point(573, 15)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(57, 44)
        Me.Button2.TabIndex = 6
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.AVOIR_22
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Location = New System.Drawing.Point(507, 15)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(59, 44)
        Me.Button1.TabIndex = 9
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.iconfinder_folder_delete_61770
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button3.Location = New System.Drawing.Point(1568, 14)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(59, 46)
        Me.Button3.TabIndex = 7
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Txt_W
        '
        Me.Txt_W.BackColor = System.Drawing.Color.Transparent
        Me.Txt_W.BorderColor = System.Drawing.SystemColors.ControlText
        Me.Txt_W.IsNumiric = False
        Me.Txt_W.Location = New System.Drawing.Point(803, 17)
        Me.Txt_W.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Txt_W.MinimumSize = New System.Drawing.Size(0, 37)
        Me.Txt_W.Name = "Txt_W"
        Me.Txt_W.ShowClearIcon = False
        Me.Txt_W.ShowSaveIcon = False
        Me.Txt_W.Size = New System.Drawing.Size(64, 37)
        Me.Txt_W.StartUp = 2
        Me.Txt_W.TabIndex = 11
        Me.Txt_W.TextSize = 8
        Me.Txt_W.TxtBackColor = True
        Me.Txt_W.TxtColor = System.Drawing.Color.White
        Me.Txt_W.txtReadOnly = False
        Me.Txt_W.TxtSelect = New Integer() {1, 0}
        '
        'Txt_H
        '
        Me.Txt_H.BackColor = System.Drawing.Color.Transparent
        Me.Txt_H.BorderColor = System.Drawing.SystemColors.ControlText
        Me.Txt_H.IsNumiric = False
        Me.Txt_H.Location = New System.Drawing.Point(875, 17)
        Me.Txt_H.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Txt_H.MinimumSize = New System.Drawing.Size(0, 37)
        Me.Txt_H.Name = "Txt_H"
        Me.Txt_H.ShowClearIcon = False
        Me.Txt_H.ShowSaveIcon = False
        Me.Txt_H.Size = New System.Drawing.Size(64, 37)
        Me.Txt_H.StartUp = 2
        Me.Txt_H.TabIndex = 13
        Me.Txt_H.TextSize = 8
        Me.Txt_H.TxtBackColor = True
        Me.Txt_H.TxtColor = System.Drawing.Color.White
        Me.Txt_H.txtReadOnly = False
        Me.Txt_H.TxtSelect = New Integer() {1, 0}
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1152, 27)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 17)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Page :"
        '
        'lbPage
        '
        Me.lbPage.AutoSize = True
        Me.lbPage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPage.Location = New System.Drawing.Point(1219, 30)
        Me.lbPage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbPage.Name = "lbPage"
        Me.lbPage.Size = New System.Drawing.Size(25, 17)
        Me.lbPage.TabIndex = 16
        Me.lbPage.Text = "A4"
        '
        'bForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1672, 831)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.plCh)
        Me.Controls.Add(Me.btLand)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Txt_W)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lbPage)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Txt_H)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "bForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "*** DESIGNER PALLETE"
        Me.Panel1.ResumeLayout(False)
        Me.plCh.ResumeLayout(False)
        CType(Me.pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PT As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_H As Al_Mohasib.TxtBox
    Friend WithEvents Txt_W As Al_Mohasib.TxtBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btLand As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents pb As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents plCh As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbPage As System.Windows.Forms.Label
End Class
