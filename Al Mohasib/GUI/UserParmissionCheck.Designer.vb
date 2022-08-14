<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserParmissionCheck
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lbNum = New System.Windows.Forms.Label()
        Me.bName = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 369)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(11)
        Me.Panel1.Size = New System.Drawing.Size(370, 62)
        Me.Panel1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button1.Location = New System.Drawing.Point(11, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(348, 40)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "CONTINUER"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 320)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(11)
        Me.Panel2.Size = New System.Drawing.Size(370, 49)
        Me.Panel2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label1.Location = New System.Drawing.Point(74, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(215, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "merci de scanner votre badge ..."
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.txtCode)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 310)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(11)
        Me.Panel3.Size = New System.Drawing.Size(370, 10)
        Me.Panel3.TabIndex = 2
        '
        'txtCode
        '
        Me.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCode.Location = New System.Drawing.Point(11, 11)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(348, 24)
        Me.txtCode.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.images
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(370, 310)
        Me.Panel4.TabIndex = 3
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.lbNum)
        Me.Panel5.Controls.Add(Me.bName)
        Me.Panel5.ForeColor = System.Drawing.Color.Red
        Me.Panel5.Location = New System.Drawing.Point(19, 206)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(330, 88)
        Me.Panel5.TabIndex = 0
        '
        'lbNum
        '
        Me.lbNum.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lbNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbNum.Location = New System.Drawing.Point(0, 56)
        Me.lbNum.Name = "lbNum"
        Me.lbNum.Size = New System.Drawing.Size(328, 30)
        Me.lbNum.TabIndex = 1
        Me.lbNum.Text = "XXX"
        Me.lbNum.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'bName
        '
        Me.bName.Dock = System.Windows.Forms.DockStyle.Top
        Me.bName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bName.Location = New System.Drawing.Point(0, 0)
        Me.bName.Name = "bName"
        Me.bName.Size = New System.Drawing.Size(328, 45)
        Me.bName.TabIndex = 0
        Me.bName.Text = "XXX"
        Me.bName.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'UserParmissionCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(370, 431)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "UserParmissionCheck"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parmission  Check"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents lbNum As System.Windows.Forms.Label
    Friend WithEvents bName As System.Windows.Forms.Label
End Class
