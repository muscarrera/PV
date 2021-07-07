<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gTable
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
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.pl = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cbLine = New System.Windows.Forms.CheckBox()
        Me.txtH = New Al_Mohasib.TxtBox()
        Me.txtW = New Al_Mohasib.TxtBox()
        Me.txtY = New Al_Mohasib.TxtBox()
        Me.txtX = New Al_Mohasib.TxtBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btColor = New System.Windows.Forms.Button()
        Me.cbRows = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(19, 9)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(176, 21)
        Me.ComboBox1.TabIndex = 1
        '
        'pl
        '
        Me.pl.AutoScroll = True
        Me.pl.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.pl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pl.Location = New System.Drawing.Point(0, 40)
        Me.pl.Name = "pl"
        Me.pl.Size = New System.Drawing.Size(580, 250)
        Me.pl.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.cbType)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(580, 40)
        Me.Panel1.TabIndex = 2
        '
        'cbType
        '
        Me.cbType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbType.FormattingEnabled = True
        Me.cbType.Items.AddRange(New Object() {"None", "Table_1", "Table_2", "Table_3", "Table_4", "Liste_1", "Liste_2"})
        Me.cbType.Location = New System.Drawing.Point(440, 10)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(130, 21)
        Me.cbType.TabIndex = 29
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.SteelBlue
        Me.Button3.Location = New System.Drawing.Point(350, 5)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(70, 28)
        Me.Button3.TabIndex = 0
        Me.Button3.Text = "F-Int"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Crimson
        Me.Button2.Location = New System.Drawing.Point(274, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(70, 28)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "F-Ttr"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(201, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(46, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "add"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cbLine
        '
        Me.cbLine.BackColor = System.Drawing.Color.Transparent
        Me.cbLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLine.ForeColor = System.Drawing.Color.White
        Me.cbLine.Location = New System.Drawing.Point(20, 3)
        Me.cbLine.Name = "cbLine"
        Me.cbLine.Size = New System.Drawing.Size(90, 31)
        Me.cbLine.TabIndex = 30
        Me.cbLine.Text = "Inter Lines"
        Me.cbLine.UseVisualStyleBackColor = False
        '
        'txtH
        '
        Me.txtH.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtH.BackColor = System.Drawing.Color.Transparent
        Me.txtH.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtH.IsNumiric = False
        Me.txtH.Location = New System.Drawing.Point(509, 3)
        Me.txtH.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtH.Name = "txtH"
        Me.txtH.ShowClearIcon = False
        Me.txtH.ShowSaveIcon = False
        Me.txtH.Size = New System.Drawing.Size(61, 30)
        Me.txtH.StartUp = 2
        Me.txtH.TabIndex = 29
        Me.txtH.TextSize = 8
        Me.txtH.TxtBackColor = True
        Me.txtH.TxtColor = System.Drawing.Color.White
        Me.txtH.txtReadOnly = False
        Me.txtH.TxtSelect = New Integer() {1, 0}
        '
        'txtW
        '
        Me.txtW.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtW.BackColor = System.Drawing.Color.Transparent
        Me.txtW.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtW.IsNumiric = False
        Me.txtW.Location = New System.Drawing.Point(449, 3)
        Me.txtW.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtW.Name = "txtW"
        Me.txtW.ShowClearIcon = False
        Me.txtW.ShowSaveIcon = False
        Me.txtW.Size = New System.Drawing.Size(61, 30)
        Me.txtW.StartUp = 2
        Me.txtW.TabIndex = 27
        Me.txtW.TextSize = 8
        Me.txtW.TxtBackColor = True
        Me.txtW.TxtColor = System.Drawing.Color.White
        Me.txtW.txtReadOnly = False
        Me.txtW.TxtSelect = New Integer() {1, 0}
        '
        'txtY
        '
        Me.txtY.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtY.BackColor = System.Drawing.Color.Transparent
        Me.txtY.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtY.IsNumiric = False
        Me.txtY.Location = New System.Drawing.Point(389, 3)
        Me.txtY.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtY.Name = "txtY"
        Me.txtY.ShowClearIcon = False
        Me.txtY.ShowSaveIcon = False
        Me.txtY.Size = New System.Drawing.Size(61, 30)
        Me.txtY.StartUp = 2
        Me.txtY.TabIndex = 25
        Me.txtY.TextSize = 8
        Me.txtY.TxtBackColor = True
        Me.txtY.TxtColor = System.Drawing.Color.White
        Me.txtY.txtReadOnly = False
        Me.txtY.TxtSelect = New Integer() {1, 0}
        '
        'txtX
        '
        Me.txtX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtX.BackColor = System.Drawing.Color.Transparent
        Me.txtX.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtX.IsNumiric = False
        Me.txtX.Location = New System.Drawing.Point(329, 3)
        Me.txtX.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtX.Name = "txtX"
        Me.txtX.ShowClearIcon = False
        Me.txtX.ShowSaveIcon = False
        Me.txtX.Size = New System.Drawing.Size(61, 30)
        Me.txtX.StartUp = 2
        Me.txtX.TabIndex = 26
        Me.txtX.TextSize = 8
        Me.txtX.TxtBackColor = True
        Me.txtX.TxtColor = System.Drawing.Color.White
        Me.txtX.txtReadOnly = False
        Me.txtX.TxtSelect = New Integer() {1, 0}
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Controls.Add(Me.btColor)
        Me.Panel2.Controls.Add(Me.cbRows)
        Me.Panel2.Controls.Add(Me.cbLine)
        Me.Panel2.Controls.Add(Me.txtH)
        Me.Panel2.Controls.Add(Me.txtW)
        Me.Panel2.Controls.Add(Me.txtX)
        Me.Panel2.Controls.Add(Me.txtY)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 290)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(580, 40)
        Me.Panel2.TabIndex = 4
        '
        'btColor
        '
        Me.btColor.BackColor = System.Drawing.Color.Gainsboro
        Me.btColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btColor.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btColor.Location = New System.Drawing.Point(205, 8)
        Me.btColor.Name = "btColor"
        Me.btColor.Size = New System.Drawing.Size(75, 23)
        Me.btColor.TabIndex = 33
        Me.btColor.Text = "Couleur"
        Me.btColor.UseVisualStyleBackColor = False
        '
        'cbRows
        '
        Me.cbRows.BackColor = System.Drawing.Color.Transparent
        Me.cbRows.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRows.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbRows.Location = New System.Drawing.Point(116, 3)
        Me.cbRows.Name = "cbRows"
        Me.cbRows.Size = New System.Drawing.Size(97, 31)
        Me.cbRows.TabIndex = 32
        Me.cbRows.Text = "Alts Rows"
        Me.cbRows.UseVisualStyleBackColor = False
        '
        'gTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pl)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "gTable"
        Me.Size = New System.Drawing.Size(580, 330)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents pl As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtH As Al_Mohasib.TxtBox
    Friend WithEvents txtW As Al_Mohasib.TxtBox
    Friend WithEvents txtY As Al_Mohasib.TxtBox
    Friend WithEvents txtX As Al_Mohasib.TxtBox
    Friend WithEvents cbLine As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cbRows As System.Windows.Forms.CheckBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents btColor As System.Windows.Forms.Button

End Class
