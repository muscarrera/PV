<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DevisionAuto
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
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.pb = New System.Windows.Forms.ProgressBar()
        Me.lb = New System.Windows.Forms.Label()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.Nbrs = New System.Windows.Forms.Label()
        Me.dt1 = New System.Windows.Forms.DateTimePicker()
        Me.dt2 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbDate = New System.Windows.Forms.Label()
        Me.txt = New Al_Mohasib.TxtBox()
        Me.Panel15.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        '
        'pb
        '
        Me.pb.Location = New System.Drawing.Point(30, 136)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(686, 23)
        Me.pb.TabIndex = 0
        '
        'lb
        '
        Me.lb.AutoSize = True
        Me.lb.Location = New System.Drawing.Point(30, 113)
        Me.lb.Name = "lb"
        Me.lb.Size = New System.Drawing.Size(20, 17)
        Me.lb.TabIndex = 1
        Me.lb.Text = "..."
        '
        'Button10
        '
        Me.Button10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button10.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.Image = Global.Al_Mohasib.My.Resources.Resources.SAVE_20
        Me.Button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button10.Location = New System.Drawing.Point(564, 46)
        Me.Button10.Margin = New System.Windows.Forms.Padding(4)
        Me.Button10.Name = "Button10"
        Me.Button10.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.Button10.Size = New System.Drawing.Size(142, 41)
        Me.Button10.TabIndex = 9
        Me.Button10.Text = "Valider"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.White
        Me.Panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel15.Controls.Add(Me.txt)
        Me.Panel15.Controls.Add(Me.Nbrs)
        Me.Panel15.Location = New System.Drawing.Point(20, 48)
        Me.Panel15.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(271, 39)
        Me.Panel15.TabIndex = 8
        '
        'Nbrs
        '
        Me.Nbrs.Dock = System.Windows.Forms.DockStyle.Left
        Me.Nbrs.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nbrs.Location = New System.Drawing.Point(0, 0)
        Me.Nbrs.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Nbrs.Name = "Nbrs"
        Me.Nbrs.Size = New System.Drawing.Size(95, 37)
        Me.Nbrs.TabIndex = 1
        Me.Nbrs.Text = "Nbrs"
        Me.Nbrs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dt1
        '
        Me.dt1.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dt1.Location = New System.Drawing.Point(3, 6)
        Me.dt1.Name = "dt1"
        Me.dt1.Size = New System.Drawing.Size(101, 22)
        Me.dt1.TabIndex = 10
        Me.dt1.Value = New Date(2023, 11, 5, 9, 0, 0, 0)
        '
        'dt2
        '
        Me.dt2.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dt2.Location = New System.Drawing.Point(446, 55)
        Me.dt2.Name = "dt2"
        Me.dt2.Size = New System.Drawing.Size(101, 22)
        Me.dt2.TabIndex = 10
        Me.dt2.Value = New Date(2023, 11, 5, 22, 18, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(116, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "à"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dt1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(299, 48)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(257, 39)
        Me.Panel1.TabIndex = 8
        '
        'lbDate
        '
        Me.lbDate.AutoSize = True
        Me.lbDate.Location = New System.Drawing.Point(300, 27)
        Me.lbDate.Name = "lbDate"
        Me.lbDate.Size = New System.Drawing.Size(51, 17)
        Me.lbDate.TabIndex = 1
        Me.lbDate.Text = "Label1"
        Me.lbDate.Visible = False
        '
        'txt
        '
        Me.txt.BackColor = System.Drawing.Color.Transparent
        Me.txt.BorderColor = System.Drawing.Color.Transparent
        Me.txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt.IsNumiric = False
        Me.txt.Location = New System.Drawing.Point(95, 0)
        Me.txt.Margin = New System.Windows.Forms.Padding(5)
        Me.txt.MinimumSize = New System.Drawing.Size(0, 37)
        Me.txt.Name = "txt"
        Me.txt.ShowClearIcon = False
        Me.txt.ShowSaveIcon = False
        Me.txt.Size = New System.Drawing.Size(174, 37)
        Me.txt.StartUp = 2
        Me.txt.TabIndex = 12
        Me.txt.TextSize = 8
        Me.txt.TxtBackColor = True
        Me.txt.TxtColor = System.Drawing.Color.White
        Me.txt.txtReadOnly = False
        Me.txt.TxtSelect = New Integer() {1, 0}
        '
        'DevisionAuto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 181)
        Me.Controls.Add(Me.dt2)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel15)
        Me.Controls.Add(Me.lbDate)
        Me.Controls.Add(Me.lb)
        Me.Controls.Add(Me.pb)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "DevisionAuto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DevisionAuto"
        Me.Panel15.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents pb As System.Windows.Forms.ProgressBar
    Friend WithEvents lb As System.Windows.Forms.Label
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Panel15 As System.Windows.Forms.Panel
    Friend WithEvents txt As Al_Mohasib.TxtBox
    Friend WithEvents Nbrs As System.Windows.Forms.Label
    Friend WithEvents dt1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbDate As System.Windows.Forms.Label
End Class
