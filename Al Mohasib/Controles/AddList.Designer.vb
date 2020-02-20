<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddList
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
        Me.PlHead = New System.Windows.Forms.Panel()
        Me.txtName = New Al_Mohasib.TxtBox()
        Me.txtprice = New Al_Mohasib.TxtBox()
        Me.txtQte = New Al_Mohasib.TxtBox()
        Me.Pl = New System.Windows.Forms.Panel()
        Me.PlCommande = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.PlFooter = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtBox1 = New Al_Mohasib.TxtBox()
        Me.PlHead.SuspendLayout()
        Me.PlCommande.SuspendLayout()
        Me.PlFooter.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PlHead
        '
        Me.PlHead.BackColor = System.Drawing.Color.White
        Me.PlHead.Controls.Add(Me.txtName)
        Me.PlHead.Controls.Add(Me.txtprice)
        Me.PlHead.Controls.Add(Me.txtQte)
        Me.PlHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.PlHead.Location = New System.Drawing.Point(3, 30)
        Me.PlHead.Name = "PlHead"
        Me.PlHead.Padding = New System.Windows.Forms.Padding(5)
        Me.PlHead.Size = New System.Drawing.Size(584, 47)
        Me.PlHead.TabIndex = 0
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.White
        Me.txtName.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtName.IsNumiric = False
        Me.txtName.Location = New System.Drawing.Point(5, 5)
        Me.txtName.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtName.Name = "txtName"
        Me.txtName.ShowClearIcon = False
        Me.txtName.ShowSaveIcon = False
        Me.txtName.Size = New System.Drawing.Size(329, 37)
        Me.txtName.StartUp = 2
        Me.txtName.TabIndex = 0
        Me.txtName.TextSize = 8
        Me.txtName.TxtBackColor = True
        Me.txtName.TxtColor = System.Drawing.Color.White
        Me.txtName.txtReadOnly = False
        Me.txtName.TxtSelect = New Integer() {1, 0}
        '
        'txtprice
        '
        Me.txtprice.BackColor = System.Drawing.Color.White
        Me.txtprice.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtprice.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtprice.IsNumiric = True
        Me.txtprice.Location = New System.Drawing.Point(334, 5)
        Me.txtprice.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtprice.Name = "txtprice"
        Me.txtprice.ShowClearIcon = False
        Me.txtprice.ShowSaveIcon = False
        Me.txtprice.Size = New System.Drawing.Size(118, 37)
        Me.txtprice.StartUp = 2
        Me.txtprice.TabIndex = 1
        Me.txtprice.TextSize = 8
        Me.txtprice.TxtBackColor = True
        Me.txtprice.TxtColor = System.Drawing.Color.White
        Me.txtprice.txtReadOnly = False
        Me.txtprice.TxtSelect = New Integer() {1, 0}
        '
        'txtQte
        '
        Me.txtQte.BackColor = System.Drawing.Color.White
        Me.txtQte.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtQte.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtQte.IsNumiric = False
        Me.txtQte.Location = New System.Drawing.Point(452, 5)
        Me.txtQte.MinimumSize = New System.Drawing.Size(0, 30)
        Me.txtQte.Name = "txtQte"
        Me.txtQte.ShowClearIcon = False
        Me.txtQte.ShowSaveIcon = False
        Me.txtQte.Size = New System.Drawing.Size(127, 37)
        Me.txtQte.StartUp = 2
        Me.txtQte.TabIndex = 2
        Me.txtQte.TextSize = 8
        Me.txtQte.TxtBackColor = True
        Me.txtQte.TxtColor = System.Drawing.Color.White
        Me.txtQte.txtReadOnly = False
        Me.txtQte.TxtSelect = New Integer() {1, 0}
        '
        'Pl
        '
        Me.Pl.AutoScroll = True
        Me.Pl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pl.Location = New System.Drawing.Point(3, 119)
        Me.Pl.Name = "Pl"
        Me.Pl.Size = New System.Drawing.Size(584, 222)
        Me.Pl.TabIndex = 1
        '
        'PlCommande
        '
        Me.PlCommande.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.PlCommande.Controls.Add(Me.TextBox1)
        Me.PlCommande.Controls.Add(Me.Button1)
        Me.PlCommande.Controls.Add(Me.LinkLabel1)
        Me.PlCommande.Dock = System.Windows.Forms.DockStyle.Top
        Me.PlCommande.Location = New System.Drawing.Point(3, 77)
        Me.PlCommande.Name = "PlCommande"
        Me.PlCommande.Size = New System.Drawing.Size(584, 42)
        Me.PlCommande.TabIndex = 2
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(291, 13)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(234, 20)
        Me.TextBox1.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button1.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.Print_22X221
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(536, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(48, 42)
        Me.Button1.TabIndex = 4
        Me.Button1.UseVisualStyleBackColor = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(6, 22)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(116, 15)
        Me.LinkLabel1.TabIndex = 3
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Ajouter un element"
        '
        'PlFooter
        '
        Me.PlFooter.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.PlFooter.Controls.Add(Me.TxtBox1)
        Me.PlFooter.Controls.Add(Me.Button2)
        Me.PlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PlFooter.Location = New System.Drawing.Point(3, 341)
        Me.PlFooter.Name = "PlFooter"
        Me.PlFooter.Size = New System.Drawing.Size(584, 44)
        Me.PlFooter.TabIndex = 3
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button2.Image = Global.Al_Mohasib.My.Resources.Resources.Save_32x321
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(476, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(108, 44)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Enregistrer"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel1.Size = New System.Drawing.Size(584, 27)
        Me.Panel1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(16, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(164, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Article ( Code Couleur)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(457, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Qte"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(339, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Prix"
        '
        'TxtBox1
        '
        Me.TxtBox1.BackColor = System.Drawing.Color.White
        Me.TxtBox1.BorderColor = System.Drawing.SystemColors.ControlText
        Me.TxtBox1.IsNumiric = False
        Me.TxtBox1.Location = New System.Drawing.Point(3, 3)
        Me.TxtBox1.MinimumSize = New System.Drawing.Size(0, 30)
        Me.TxtBox1.Name = "TxtBox1"
        Me.TxtBox1.ShowClearIcon = False
        Me.TxtBox1.ShowSaveIcon = False
        Me.TxtBox1.Size = New System.Drawing.Size(134, 41)
        Me.TxtBox1.StartUp = 2
        Me.TxtBox1.TabIndex = 6
        Me.TxtBox1.TextSize = 8
        Me.TxtBox1.TxtBackColor = True
        Me.TxtBox1.TxtColor = System.Drawing.Color.White
        Me.TxtBox1.txtReadOnly = False
        Me.TxtBox1.TxtSelect = New Integer() {1, 0}
        '
        'AddList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Pl)
        Me.Controls.Add(Me.PlFooter)
        Me.Controls.Add(Me.PlCommande)
        Me.Controls.Add(Me.PlHead)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "AddList"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.Size = New System.Drawing.Size(590, 388)
        Me.PlHead.ResumeLayout(False)
        Me.PlCommande.ResumeLayout(False)
        Me.PlCommande.PerformLayout()
        Me.PlFooter.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PlHead As System.Windows.Forms.Panel
    Friend WithEvents txtprice As Al_Mohasib.TxtBox
    Friend WithEvents Pl As System.Windows.Forms.Panel
    Friend WithEvents PlCommande As System.Windows.Forms.Panel
    Friend WithEvents txtName As Al_Mohasib.TxtBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents PlFooter As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtQte As Al_Mohasib.TxtBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtBox1 As Al_Mohasib.TxtBox

End Class
