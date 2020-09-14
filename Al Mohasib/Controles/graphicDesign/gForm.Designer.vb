<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gForm
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
        Dim GTabClass1 As Al_Mohasib.gTabClass = New Al_Mohasib.gTabClass()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.gt = New Al_Mohasib.gTable()
        Me.Pfp = New System.Windows.Forms.Panel()
        Me.Pf = New System.Windows.Forms.FlowLayoutPanel()
        Me.PT = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Txt_H = New Al_Mohasib.TxtBox()
        Me.Txt_W = New Al_Mohasib.TxtBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btLand = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pb = New System.Windows.Forms.PictureBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Pfp.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(991, 534)
        Me.SplitContainer1.SplitterDistance = 642
        Me.SplitContainer1.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Pfp)
        Me.Panel1.Controls.Add(Me.PT)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(642, 534)
        Me.Panel1.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.AutoScroll = True
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.gt)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 126)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(642, 275)
        Me.Panel5.TabIndex = 3
        '
        'gt
        '
        Me.gt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gt.Location = New System.Drawing.Point(0, 0)
        Me.gt.Name = "gt"
        Me.gt.Size = New System.Drawing.Size(640, 273)
        Me.gt.TabIndex = 0
        Me.gt.TabProp = GTabClass1
        '
        'Pfp
        '
        Me.Pfp.BackColor = System.Drawing.Color.MintCream
        Me.Pfp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pfp.Controls.Add(Me.Pf)
        Me.Pfp.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pfp.Location = New System.Drawing.Point(0, 401)
        Me.Pfp.Name = "Pfp"
        Me.Pfp.Size = New System.Drawing.Size(642, 133)
        Me.Pfp.TabIndex = 2
        '
        'Pf
        '
        Me.Pf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pf.Location = New System.Drawing.Point(0, 0)
        Me.Pf.Name = "Pf"
        Me.Pf.Size = New System.Drawing.Size(640, 131)
        Me.Pf.TabIndex = 0
        '
        'PT
        '
        Me.PT.BackColor = System.Drawing.Color.Bisque
        Me.PT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PT.Dock = System.Windows.Forms.DockStyle.Top
        Me.PT.Location = New System.Drawing.Point(0, 0)
        Me.PT.Name = "PT"
        Me.PT.Size = New System.Drawing.Size(642, 126)
        Me.PT.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Txt_H)
        Me.Panel2.Controls.Add(Me.Txt_W)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.btLand)
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.pb)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(345, 534)
        Me.Panel2.TabIndex = 0
        '
        'Txt_H
        '
        Me.Txt_H.BackColor = System.Drawing.Color.Transparent
        Me.Txt_H.BorderColor = System.Drawing.SystemColors.ControlText
        Me.Txt_H.IsNumiric = False
        Me.Txt_H.Location = New System.Drawing.Point(189, 6)
        Me.Txt_H.MinimumSize = New System.Drawing.Size(0, 30)
        Me.Txt_H.Name = "Txt_H"
        Me.Txt_H.ShowClearIcon = False
        Me.Txt_H.ShowSaveIcon = False
        Me.Txt_H.Size = New System.Drawing.Size(48, 30)
        Me.Txt_H.StartUp = 2
        Me.Txt_H.TabIndex = 2
        Me.Txt_H.TextSize = 8
        Me.Txt_H.TxtBackColor = True
        Me.Txt_H.TxtColor = System.Drawing.Color.White
        Me.Txt_H.txtReadOnly = False
        Me.Txt_H.TxtSelect = New Integer() {1, 0}
        '
        'Txt_W
        '
        Me.Txt_W.BackColor = System.Drawing.Color.Transparent
        Me.Txt_W.BorderColor = System.Drawing.SystemColors.ControlText
        Me.Txt_W.IsNumiric = False
        Me.Txt_W.Location = New System.Drawing.Point(135, 6)
        Me.Txt_W.MinimumSize = New System.Drawing.Size(0, 30)
        Me.Txt_W.Name = "Txt_W"
        Me.Txt_W.ShowClearIcon = False
        Me.Txt_W.ShowSaveIcon = False
        Me.Txt_W.Size = New System.Drawing.Size(48, 30)
        Me.Txt_W.StartUp = 2
        Me.Txt_W.TabIndex = 2
        Me.Txt_W.TextSize = 8
        Me.Txt_W.TxtBackColor = True
        Me.Txt_W.TxtColor = System.Drawing.Color.White
        Me.Txt_W.txtReadOnly = False
        Me.Txt_W.TxtSelect = New Integer() {1, 0}
        '
        'Button3
        '
        Me.Button3.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.iconfinder_folder_delete_61770
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button3.Location = New System.Drawing.Point(372, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(44, 37)
        Me.Button3.TabIndex = 1
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.SAVE_20
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.Location = New System.Drawing.Point(55, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(43, 36)
        Me.Button2.TabIndex = 1
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btLand
        '
        Me.btLand.BackColor = System.Drawing.Color.Transparent
        Me.btLand.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.FACTURE_20
        Me.btLand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btLand.FlatAppearance.BorderSize = 0
        Me.btLand.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btLand.Location = New System.Drawing.Point(238, 5)
        Me.btLand.Name = "btLand"
        Me.btLand.Size = New System.Drawing.Size(29, 36)
        Me.btLand.TabIndex = 1
        Me.btLand.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.iconfinder_Folder_Settings_Tools_icon_88583_X_24
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button4.Location = New System.Drawing.Point(273, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(44, 36)
        Me.Button4.TabIndex = 1
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.AVOIR_22
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Location = New System.Drawing.Point(5, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(44, 36)
        Me.Button1.TabIndex = 1
        Me.Button1.UseVisualStyleBackColor = True
        '
        'pb
        '
        Me.pb.BackColor = System.Drawing.Color.White
        Me.pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pb.Location = New System.Drawing.Point(5, 46)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(416, 478)
        Me.pb.TabIndex = 0
        Me.pb.TabStop = False
        '
        'gForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(991, 534)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "gForm"
        Me.Text = "gForm"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Pfp.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents gt As Al_Mohasib.gTable
    Friend WithEvents Pfp As System.Windows.Forms.Panel
    Friend WithEvents Pf As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents PT As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btLand As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents pb As System.Windows.Forms.PictureBox
    Friend WithEvents Txt_H As Al_Mohasib.TxtBox
    Friend WithEvents Txt_W As Al_Mohasib.TxtBox
End Class
