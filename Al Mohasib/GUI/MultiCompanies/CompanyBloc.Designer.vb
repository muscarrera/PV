<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CompanyBloc
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
        Me.pl = New System.Windows.Forms.Panel()
        Me.BT = New System.Windows.Forms.Button()
        Me.pl1 = New System.Windows.Forms.Panel()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.OvalShape1 = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pl.SuspendLayout()
        Me.pl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pl
        '
        Me.pl.Controls.Add(Me.BT)
        Me.pl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pl.Location = New System.Drawing.Point(89, 0)
        Me.pl.Margin = New System.Windows.Forms.Padding(4)
        Me.pl.Name = "pl"
        Me.pl.Size = New System.Drawing.Size(411, 98)
        Me.pl.TabIndex = 4
        '
        'BT
        '
        Me.BT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BT.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.BT.FlatAppearance.BorderSize = 0
        Me.BT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT.Location = New System.Drawing.Point(29, 18)
        Me.BT.Margin = New System.Windows.Forms.Padding(4)
        Me.BT.Name = "BT"
        Me.BT.Size = New System.Drawing.Size(348, 43)
        Me.BT.TabIndex = 0
        Me.BT.Text = "--"
        Me.BT.UseVisualStyleBackColor = True
        '
        'pl1
        '
        Me.pl1.Controls.Add(Me.ShapeContainer1)
        Me.pl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.pl1.Location = New System.Drawing.Point(0, 0)
        Me.pl1.Margin = New System.Windows.Forms.Padding(4)
        Me.pl1.Name = "pl1"
        Me.pl1.Size = New System.Drawing.Size(89, 98)
        Me.pl1.TabIndex = 3
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.OvalShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(89, 98)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'OvalShape1
        '
        Me.OvalShape1.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.BGpRD
        Me.OvalShape1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.OvalShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.OvalShape1.BorderColor = System.Drawing.Color.Brown
        Me.OvalShape1.Location = New System.Drawing.Point(0, 2)
        Me.OvalShape1.Name = "OvalShape1"
        Me.OvalShape1.Size = New System.Drawing.Size(66, 63)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 98)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(500, 2)
        Me.Panel1.TabIndex = 5
        '
        'CompanyBloc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.pl)
        Me.Controls.Add(Me.pl1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "CompanyBloc"
        Me.Size = New System.Drawing.Size(500, 100)
        Me.pl.ResumeLayout(False)
        Me.pl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pl As System.Windows.Forms.Panel
    Friend WithEvents BT As System.Windows.Forms.Button
    Friend WithEvents pl1 As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents OvalShape1 As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
