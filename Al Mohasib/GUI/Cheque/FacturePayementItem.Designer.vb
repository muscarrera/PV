<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FacturePayementItem
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
        Me.lbT = New System.Windows.Forms.Label()
        Me.lbA = New System.Windows.Forms.Label()
        Me.lbId = New System.Windows.Forms.Label()
        Me.lbD = New System.Windows.Forms.Label()
        Me.PLav = New System.Windows.Forms.Panel()
        Me.PLd = New System.Windows.Forms.Panel()
        Me.cb = New System.Windows.Forms.CheckBox()
        Me.PLd.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbT
        '
        Me.lbT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbT.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbT.ForeColor = System.Drawing.Color.Maroon
        Me.lbT.Location = New System.Drawing.Point(74, 0)
        Me.lbT.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbT.Name = "lbT"
        Me.lbT.Size = New System.Drawing.Size(157, 30)
        Me.lbT.TabIndex = 9
        Me.lbT.Text = "TT"
        Me.lbT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbA
        '
        Me.lbA.Dock = System.Windows.Forms.DockStyle.Right
        Me.lbA.Font = New System.Drawing.Font("Century Gothic", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbA.ForeColor = System.Drawing.Color.Green
        Me.lbA.Location = New System.Drawing.Point(231, 0)
        Me.lbA.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbA.Name = "lbA"
        Me.lbA.Size = New System.Drawing.Size(76, 30)
        Me.lbA.TabIndex = 10
        Me.lbA.Text = "AV"
        '
        'lbId
        '
        Me.lbId.AutoSize = True
        Me.lbId.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbId.Font = New System.Drawing.Font("Century Gothic", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbId.Location = New System.Drawing.Point(54, 0)
        Me.lbId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbId.Name = "lbId"
        Me.lbId.Size = New System.Drawing.Size(20, 17)
        Me.lbId.TabIndex = 8
        Me.lbId.Text = "ID"
        '
        'lbD
        '
        Me.lbD.AutoSize = True
        Me.lbD.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbD.Font = New System.Drawing.Font("Century Gothic", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD.Location = New System.Drawing.Point(32, 0)
        Me.lbD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbD.Name = "lbD"
        Me.lbD.Size = New System.Drawing.Size(22, 17)
        Me.lbD.TabIndex = 7
        Me.lbD.Text = "DT"
        '
        'PLav
        '
        Me.PLav.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.PLav.Dock = System.Windows.Forms.DockStyle.Left
        Me.PLav.Location = New System.Drawing.Point(0, 0)
        Me.PLav.Margin = New System.Windows.Forms.Padding(4)
        Me.PLav.Name = "PLav"
        Me.PLav.Size = New System.Drawing.Size(157, 7)
        Me.PLav.TabIndex = 1
        '
        'PLd
        '
        Me.PLd.BackColor = System.Drawing.Color.Salmon
        Me.PLd.Controls.Add(Me.PLav)
        Me.PLd.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PLd.Location = New System.Drawing.Point(32, 30)
        Me.PLd.Margin = New System.Windows.Forms.Padding(4)
        Me.PLd.Name = "PLd"
        Me.PLd.Size = New System.Drawing.Size(275, 7)
        Me.PLd.TabIndex = 6
        '
        'cb
        '
        Me.cb.Dock = System.Windows.Forms.DockStyle.Left
        Me.cb.Location = New System.Drawing.Point(0, 0)
        Me.cb.Margin = New System.Windows.Forms.Padding(4)
        Me.cb.Name = "cb"
        Me.cb.Size = New System.Drawing.Size(32, 37)
        Me.cb.TabIndex = 11
        Me.cb.UseVisualStyleBackColor = True
        '
        'FacturePayementItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lbT)
        Me.Controls.Add(Me.lbA)
        Me.Controls.Add(Me.lbId)
        Me.Controls.Add(Me.lbD)
        Me.Controls.Add(Me.PLd)
        Me.Controls.Add(Me.cb)
        Me.Name = "FacturePayementItem"
        Me.Size = New System.Drawing.Size(307, 37)
        Me.PLd.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbT As System.Windows.Forms.Label
    Friend WithEvents lbA As System.Windows.Forms.Label
    Friend WithEvents lbId As System.Windows.Forms.Label
    Friend WithEvents lbD As System.Windows.Forms.Label
    Friend WithEvents PLav As System.Windows.Forms.Panel
    Friend WithEvents PLd As System.Windows.Forms.Panel
    Friend WithEvents cb As System.Windows.Forms.CheckBox

End Class
