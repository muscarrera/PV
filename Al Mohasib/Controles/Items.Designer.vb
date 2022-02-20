<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Items
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
        Me.Pl = New System.Windows.Forms.Panel()
        Me.LbName = New System.Windows.Forms.Label()
        Me.LbTotal = New System.Windows.Forms.Label()
        Me.plRet = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LbStk = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LbPrice = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LbQte = New System.Windows.Forms.Label()
        Me.LbTva = New System.Windows.Forms.Label()
        Me.plCheck = New System.Windows.Forms.Panel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Pl.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.plCheck.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pl
        '
        Me.Pl.BackColor = System.Drawing.Color.Transparent
        Me.Pl.Controls.Add(Me.LbName)
        Me.Pl.Controls.Add(Me.LbTotal)
        Me.Pl.Controls.Add(Me.plRet)
        Me.Pl.Controls.Add(Me.Panel1)
        Me.Pl.Controls.Add(Me.plCheck)
        Me.Pl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pl.Location = New System.Drawing.Point(2, 2)
        Me.Pl.Name = "Pl"
        Me.Pl.Size = New System.Drawing.Size(298, 41)
        Me.Pl.TabIndex = 2
        '
        'LbName
        '
        Me.LbName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LbName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbName.ForeColor = System.Drawing.Color.DarkCyan
        Me.LbName.Location = New System.Drawing.Point(42, 0)
        Me.LbName.Name = "LbName"
        Me.LbName.Size = New System.Drawing.Size(181, 21)
        Me.LbName.TabIndex = 0
        Me.LbName.Text = "Label1"
        Me.LbName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LbTotal
        '
        Me.LbTotal.Dock = System.Windows.Forms.DockStyle.Right
        Me.LbTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbTotal.ForeColor = System.Drawing.Color.DarkCyan
        Me.LbTotal.Location = New System.Drawing.Point(223, 0)
        Me.LbTotal.Name = "LbTotal"
        Me.LbTotal.Size = New System.Drawing.Size(75, 21)
        Me.LbTotal.TabIndex = 0
        Me.LbTotal.Text = "Label1"
        Me.LbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'plRet
        '
        Me.plRet.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.RT
        Me.plRet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plRet.Dock = System.Windows.Forms.DockStyle.Left
        Me.plRet.Location = New System.Drawing.Point(21, 0)
        Me.plRet.Name = "plRet"
        Me.plRet.Size = New System.Drawing.Size(21, 21)
        Me.plRet.TabIndex = 4
        Me.plRet.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.LbStk)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.LbPrice)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.LbQte)
        Me.Panel1.Controls.Add(Me.LbTva)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(21, 21)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(277, 20)
        Me.Panel1.TabIndex = 3
        '
        'LbStk
        '
        Me.LbStk.AutoSize = True
        Me.LbStk.Dock = System.Windows.Forms.DockStyle.Left
        Me.LbStk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbStk.Location = New System.Drawing.Point(150, 0)
        Me.LbStk.Name = "LbStk"
        Me.LbStk.Size = New System.Drawing.Size(39, 13)
        Me.LbStk.TabIndex = 7
        Me.LbStk.Text = "Label4"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(117, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "   |     "
        '
        'LbPrice
        '
        Me.LbPrice.AutoSize = True
        Me.LbPrice.Dock = System.Windows.Forms.DockStyle.Left
        Me.LbPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbPrice.ForeColor = System.Drawing.Color.DeepPink
        Me.LbPrice.Location = New System.Drawing.Point(78, 0)
        Me.LbPrice.Name = "LbPrice"
        Me.LbPrice.Size = New System.Drawing.Size(39, 13)
        Me.LbPrice.TabIndex = 5
        Me.LbPrice.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(45, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "   |     "
        '
        'LbQte
        '
        Me.LbQte.AutoSize = True
        Me.LbQte.Dock = System.Windows.Forms.DockStyle.Left
        Me.LbQte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbQte.ForeColor = System.Drawing.Color.MediumBlue
        Me.LbQte.Location = New System.Drawing.Point(0, 0)
        Me.LbQte.Name = "LbQte"
        Me.LbQte.Size = New System.Drawing.Size(45, 13)
        Me.LbQte.TabIndex = 0
        Me.LbQte.Text = "Label1"
        '
        'LbTva
        '
        Me.LbTva.Dock = System.Windows.Forms.DockStyle.Right
        Me.LbTva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbTva.Location = New System.Drawing.Point(174, 0)
        Me.LbTva.Name = "LbTva"
        Me.LbTva.Size = New System.Drawing.Size(103, 20)
        Me.LbTva.TabIndex = 0
        Me.LbTva.Text = "Label1"
        Me.LbTva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LbTva.Visible = False
        '
        'plCheck
        '
        Me.plCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plCheck.Controls.Add(Me.CheckBox1)
        Me.plCheck.Dock = System.Windows.Forms.DockStyle.Left
        Me.plCheck.Location = New System.Drawing.Point(0, 0)
        Me.plCheck.Name = "plCheck"
        Me.plCheck.Size = New System.Drawing.Size(21, 41)
        Me.plCheck.TabIndex = 5
        Me.plCheck.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBox1.Location = New System.Drawing.Point(0, 0)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.CheckBox1.Size = New System.Drawing.Size(21, 41)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'Items
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.Pl)
        Me.Name = "Items"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.Size = New System.Drawing.Size(302, 45)
        Me.Pl.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.plCheck.ResumeLayout(False)
        Me.plCheck.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pl As System.Windows.Forms.Panel
    Friend WithEvents LbName As System.Windows.Forms.Label
    Friend WithEvents LbTva As System.Windows.Forms.Label
    Friend WithEvents LbQte As System.Windows.Forms.Label
    Friend WithEvents LbTotal As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LbStk As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LbPrice As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents plRet As System.Windows.Forms.Panel
    Friend WithEvents plCheck As System.Windows.Forms.Panel
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox

End Class
