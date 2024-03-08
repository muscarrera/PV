<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PayRecept
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
        Me.PrintDocdepot = New System.Drawing.Printing.PrintDocument()
        Me.PrintDoc = New System.Drawing.Printing.PrintDocument()
        Me.PrintDocRes = New System.Drawing.Printing.PrintDocument()
        Me.plClavier = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button22 = New System.Windows.Forms.Button()
        Me.Button30 = New System.Windows.Forms.Button()
        Me.Button23 = New System.Windows.Forms.Button()
        Me.Button29 = New System.Windows.Forms.Button()
        Me.Button25 = New System.Windows.Forms.Button()
        Me.Button27 = New System.Windows.Forms.Button()
        Me.Button24 = New System.Windows.Forms.Button()
        Me.Button28 = New System.Windows.Forms.Button()
        Me.Button26 = New System.Windows.Forms.Button()
        Me.btOk = New System.Windows.Forms.Button()
        Me.Annuler = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button33 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRest = New System.Windows.Forms.TextBox()
        Me.txtAvc = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txt = New System.Windows.Forms.TextBox()
        Me.plClavier.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'plClavier
        '
        Me.plClavier.BackColor = System.Drawing.Color.Black
        Me.plClavier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.plClavier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.plClavier.Controls.Add(Me.Button3)
        Me.plClavier.Controls.Add(Me.Button2)
        Me.plClavier.Controls.Add(Me.Button1)
        Me.plClavier.Controls.Add(Me.Button4)
        Me.plClavier.Controls.Add(Me.Button22)
        Me.plClavier.Controls.Add(Me.Button30)
        Me.plClavier.Controls.Add(Me.Button23)
        Me.plClavier.Controls.Add(Me.Button29)
        Me.plClavier.Controls.Add(Me.Button25)
        Me.plClavier.Controls.Add(Me.Button27)
        Me.plClavier.Controls.Add(Me.Button24)
        Me.plClavier.Controls.Add(Me.Button28)
        Me.plClavier.Controls.Add(Me.Button26)
        Me.plClavier.Dock = System.Windows.Forms.DockStyle.Left
        Me.plClavier.Location = New System.Drawing.Point(0, 0)
        Me.plClavier.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.plClavier.Name = "plClavier"
        Me.plClavier.Size = New System.Drawing.Size(573, 652)
        Me.plClavier.TabIndex = 17
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.DarkOrchid
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Honeydew
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(16, 558)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(173, 79)
        Me.Button3.TabIndex = 0
        Me.Button3.Text = "VIREMENT"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.MediumBlue
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Honeydew
        Me.Button2.Image = Global.Al_Mohasib.My.Resources.Resources.iconfinder_finance_23_808654
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(16, 453)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(173, 97)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "CHEQUE"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Crimson
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Honeydew
        Me.Button1.Image = Global.Al_Mohasib.My.Resources.Resources.iconfinder_CasH_44
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(197, 453)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(173, 183)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "TPE"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Honeydew
        Me.Button4.Image = Global.Al_Mohasib.My.Resources.Resources.money1
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.Location = New System.Drawing.Point(379, 453)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(173, 183)
        Me.Button4.TabIndex = 0
        Me.Button4.Text = "Total cache"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button22
        '
        Me.Button22.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button22.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button22.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button22.ForeColor = System.Drawing.Color.DarkGreen
        Me.Button22.Image = Global.Al_Mohasib.My.Resources.Resources._0
        Me.Button22.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button22.Location = New System.Drawing.Point(16, 14)
        Me.Button22.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(173, 111)
        Me.Button22.TabIndex = 0
        Me.Button22.Text = "0.5"
        Me.Button22.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button22.UseVisualStyleBackColor = False
        '
        'Button30
        '
        Me.Button30.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button30.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button30.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button30.ForeColor = System.Drawing.Color.Black
        Me.Button30.Image = Global.Al_Mohasib.My.Resources.Resources._200
        Me.Button30.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button30.Location = New System.Drawing.Point(377, 284)
        Me.Button30.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button30.Name = "Button30"
        Me.Button30.Size = New System.Drawing.Size(173, 140)
        Me.Button30.TabIndex = 0
        Me.Button30.Text = "200"
        Me.Button30.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button30.UseVisualStyleBackColor = False
        '
        'Button23
        '
        Me.Button23.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button23.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button23.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button23.ForeColor = System.Drawing.Color.DarkGreen
        Me.Button23.Image = Global.Al_Mohasib.My.Resources.Resources._1
        Me.Button23.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button23.Location = New System.Drawing.Point(197, 14)
        Me.Button23.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(173, 111)
        Me.Button23.TabIndex = 0
        Me.Button23.Text = "1"
        Me.Button23.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button23.UseVisualStyleBackColor = False
        '
        'Button29
        '
        Me.Button29.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button29.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button29.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button29.ForeColor = System.Drawing.Color.Black
        Me.Button29.Image = Global.Al_Mohasib.My.Resources.Resources._100
        Me.Button29.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button29.Location = New System.Drawing.Point(195, 284)
        Me.Button29.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button29.Name = "Button29"
        Me.Button29.Size = New System.Drawing.Size(173, 140)
        Me.Button29.TabIndex = 0
        Me.Button29.Text = "100"
        Me.Button29.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button29.UseVisualStyleBackColor = False
        '
        'Button25
        '
        Me.Button25.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button25.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button25.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button25.ForeColor = System.Drawing.Color.DarkGreen
        Me.Button25.Image = Global.Al_Mohasib.My.Resources.Resources._5
        Me.Button25.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button25.Location = New System.Drawing.Point(15, 132)
        Me.Button25.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button25.Name = "Button25"
        Me.Button25.Size = New System.Drawing.Size(173, 145)
        Me.Button25.TabIndex = 0
        Me.Button25.Text = "5"
        Me.Button25.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button25.UseVisualStyleBackColor = False
        '
        'Button27
        '
        Me.Button27.BackColor = System.Drawing.Color.BlueViolet
        Me.Button27.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button27.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button27.ForeColor = System.Drawing.Color.DarkGreen
        Me.Button27.Image = Global.Al_Mohasib.My.Resources.Resources._20
        Me.Button27.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button27.Location = New System.Drawing.Point(379, 132)
        Me.Button27.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button27.Name = "Button27"
        Me.Button27.Size = New System.Drawing.Size(173, 145)
        Me.Button27.TabIndex = 0
        Me.Button27.Text = "20"
        Me.Button27.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button27.UseVisualStyleBackColor = False
        '
        'Button24
        '
        Me.Button24.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button24.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button24.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button24.ForeColor = System.Drawing.Color.DarkGreen
        Me.Button24.Image = Global.Al_Mohasib.My.Resources.Resources._2
        Me.Button24.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button24.Location = New System.Drawing.Point(379, 14)
        Me.Button24.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(173, 111)
        Me.Button24.TabIndex = 0
        Me.Button24.Text = "2"
        Me.Button24.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button24.UseVisualStyleBackColor = False
        '
        'Button28
        '
        Me.Button28.BackColor = System.Drawing.Color.Green
        Me.Button28.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button28.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button28.ForeColor = System.Drawing.Color.Black
        Me.Button28.Image = Global.Al_Mohasib.My.Resources.Resources._501
        Me.Button28.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button28.Location = New System.Drawing.Point(13, 284)
        Me.Button28.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button28.Name = "Button28"
        Me.Button28.Size = New System.Drawing.Size(173, 140)
        Me.Button28.TabIndex = 0
        Me.Button28.Text = "50"
        Me.Button28.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button28.UseVisualStyleBackColor = False
        '
        'Button26
        '
        Me.Button26.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button26.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button26.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button26.ForeColor = System.Drawing.Color.DarkGreen
        Me.Button26.Image = Global.Al_Mohasib.My.Resources.Resources._10
        Me.Button26.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button26.Location = New System.Drawing.Point(196, 132)
        Me.Button26.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button26.Name = "Button26"
        Me.Button26.Size = New System.Drawing.Size(173, 145)
        Me.Button26.TabIndex = 0
        Me.Button26.Text = "10"
        Me.Button26.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button26.UseVisualStyleBackColor = False
        '
        'btOk
        '
        Me.btOk.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.btOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btOk.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOk.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btOk.Location = New System.Drawing.Point(149, 548)
        Me.btOk.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btOk.Name = "btOk"
        Me.btOk.Size = New System.Drawing.Size(263, 90)
        Me.btOk.TabIndex = 0
        Me.btOk.Text = "OK"
        Me.btOk.UseVisualStyleBackColor = False
        '
        'Annuler
        '
        Me.Annuler.BackColor = System.Drawing.Color.Red
        Me.Annuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Annuler.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Annuler.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Annuler.Location = New System.Drawing.Point(15, 548)
        Me.Annuler.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Annuler.Name = "Annuler"
        Me.Annuler.Size = New System.Drawing.Size(127, 90)
        Me.Annuler.TabIndex = 0
        Me.Annuler.Text = "Annuler"
        Me.Annuler.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel1.Controls.Add(Me.Button33)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtRest)
        Me.Panel1.Controls.Add(Me.txtAvc)
        Me.Panel1.Controls.Add(Me.txtTotal)
        Me.Panel1.Controls.Add(Me.txt)
        Me.Panel1.Controls.Add(Me.Annuler)
        Me.Panel1.Controls.Add(Me.btOk)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(573, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(426, 652)
        Me.Panel1.TabIndex = 18
        '
        'Button33
        '
        Me.Button33.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button33.FlatAppearance.BorderSize = 0
        Me.Button33.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button33.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button33.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button33.Image = Global.Al_Mohasib.My.Resources.Resources.vector_cancel_icon_png_302651
        Me.Button33.Location = New System.Drawing.Point(339, 214)
        Me.Button33.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button33.Name = "Button33"
        Me.Button33.Size = New System.Drawing.Size(63, 50)
        Me.Button33.TabIndex = 0
        Me.Button33.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(21, 294)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 17)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "REST"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(21, 188)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 17)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "CACHE"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(251, 78)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 17)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "AVANCE (encien)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(21, 78)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 17)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "TOTAL"
        '
        'txtRest
        '
        Me.txtRest.BackColor = System.Drawing.SystemColors.MenuText
        Me.txtRest.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRest.Font = New System.Drawing.Font("Arial Rounded MT Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRest.ForeColor = System.Drawing.Color.GreenYellow
        Me.txtRest.Location = New System.Drawing.Point(25, 321)
        Me.txtRest.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtRest.Name = "txtRest"
        Me.txtRest.ReadOnly = True
        Me.txtRest.Size = New System.Drawing.Size(367, 35)
        Me.txtRest.TabIndex = 20
        Me.txtRest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAvc
        '
        Me.txtAvc.BackColor = System.Drawing.SystemColors.MenuText
        Me.txtAvc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAvc.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAvc.ForeColor = System.Drawing.Color.White
        Me.txtAvc.Location = New System.Drawing.Point(255, 102)
        Me.txtAvc.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtAvc.Name = "txtAvc"
        Me.txtAvc.ReadOnly = True
        Me.txtAvc.Size = New System.Drawing.Size(147, 42)
        Me.txtAvc.TabIndex = 19
        Me.txtAvc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.SystemColors.MenuText
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotal.Font = New System.Drawing.Font("Arial Rounded MT Bold", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.Color.White
        Me.txtTotal.Location = New System.Drawing.Point(25, 102)
        Me.txtTotal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(221, 51)
        Me.txtTotal.TabIndex = 19
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt
        '
        Me.txt.BackColor = System.Drawing.SystemColors.MenuText
        Me.txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt.Font = New System.Drawing.Font("Arial Rounded MT Bold", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt.ForeColor = System.Drawing.Color.GreenYellow
        Me.txt.Location = New System.Drawing.Point(25, 212)
        Me.txt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt.Name = "txt"
        Me.txt.ReadOnly = True
        Me.txt.Size = New System.Drawing.Size(295, 51)
        Me.txt.TabIndex = 18
        Me.txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PayRecept
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(999, 652)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.plClavier)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "PayRecept"
        Me.plClavier.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PrintDocdepot As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDoc As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDocRes As System.Drawing.Printing.PrintDocument
    Friend WithEvents plClavier As System.Windows.Forms.Panel
    Friend WithEvents Button33 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button22 As System.Windows.Forms.Button
    Friend WithEvents Button30 As System.Windows.Forms.Button
    Friend WithEvents Button23 As System.Windows.Forms.Button
    Friend WithEvents Button29 As System.Windows.Forms.Button
    Friend WithEvents Button25 As System.Windows.Forms.Button
    Friend WithEvents Button27 As System.Windows.Forms.Button
    Friend WithEvents Button24 As System.Windows.Forms.Button
    Friend WithEvents Button28 As System.Windows.Forms.Button
    Friend WithEvents Button26 As System.Windows.Forms.Button
    Friend WithEvents btOk As System.Windows.Forms.Button
    Friend WithEvents Annuler As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtRest As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAvc As System.Windows.Forms.TextBox
End Class
