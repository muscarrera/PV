<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddMashine
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TxtBox1 = New Al_Mohasib.TxtBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pl = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RsOk = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RsAdd = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RsEdit = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RsDel = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        'Me.ALMohassinDBDataSet = New Al_Mohasib.ALMohassinDBDataSet()
        'Me.AdminFactureBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        ''Me.AdminFactureTableAdapter = New Al_Mohasib.ALMohassinDBDataSetTableAdapters.AdminFactureTableAdapter()
        'Me.AdminFactureBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Machine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.pl.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.ALMohassinDBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.AdminFactureBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.AdminFactureBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtBox1
        '
        Me.TxtBox1.BackColor = System.Drawing.Color.White
        Me.TxtBox1.BorderColor = System.Drawing.SystemColors.ControlText
        Me.TxtBox1.IsNumiric = False
        Me.TxtBox1.Location = New System.Drawing.Point(23, 26)
        Me.TxtBox1.MinimumSize = New System.Drawing.Size(0, 30)
        Me.TxtBox1.Name = "TxtBox1"
        Me.TxtBox1.ShowClearIcon = False
        Me.TxtBox1.ShowSaveIcon = False
        Me.TxtBox1.Size = New System.Drawing.Size(248, 30)
        Me.TxtBox1.StartUp = 2
        Me.TxtBox1.TabIndex = 0
        Me.TxtBox1.TextSize = 8
        Me.TxtBox1.TxtBackColor = True
        Me.TxtBox1.TxtColor = System.Drawing.Color.White
        Me.TxtBox1.txtReadOnly = False
        Me.TxtBox1.TxtSelect = New Integer() {1, 0}
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pl)
        Me.Panel1.Controls.Add(Me.ShapeContainer1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(318, 327)
        Me.Panel1.TabIndex = 1
        '
        'pl
        '
        Me.pl.Controls.Add(Me.Label1)
        Me.pl.Controls.Add(Me.TxtBox1)
        Me.pl.Controls.Add(Me.ShapeContainer2)
        Me.pl.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pl.Location = New System.Drawing.Point(0, 178)
        Me.pl.Name = "pl"
        Me.pl.Size = New System.Drawing.Size(318, 149)
        Me.pl.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nom :"
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RsOk})
        Me.ShapeContainer2.Size = New System.Drawing.Size(318, 149)
        Me.ShapeContainer2.TabIndex = 3
        Me.ShapeContainer2.TabStop = False
        '
        'RsOk
        '
        Me.RsOk.BackColor = System.Drawing.Color.Crimson
        Me.RsOk.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.OK_22
        Me.RsOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.RsOk.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RsOk.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.RsOk.CornerRadius = 5
        Me.RsOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.RsOk.Location = New System.Drawing.Point(19, 83)
        Me.RsOk.Name = "RsOk"
        Me.RsOk.Size = New System.Drawing.Size(251, 48)
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RsAdd, Me.RsEdit, Me.RsDel})
        Me.ShapeContainer1.Size = New System.Drawing.Size(318, 327)
        Me.ShapeContainer1.TabIndex = 1
        Me.ShapeContainer1.TabStop = False
        '
        'RsAdd
        '
        Me.RsAdd.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.RsAdd.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.AddFile_32x32
        Me.RsAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.RsAdd.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RsAdd.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.RsAdd.CornerRadius = 5
        Me.RsAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.RsAdd.Location = New System.Drawing.Point(27, 30)
        Me.RsAdd.Name = "RsAdd"
        Me.RsAdd.Size = New System.Drawing.Size(47, 48)
        '
        'RsEdit
        '
        Me.RsEdit.BackColor = System.Drawing.Color.DarkGreen
        Me.RsEdit.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.ED_32
        Me.RsEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.RsEdit.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RsEdit.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.RsEdit.CornerRadius = 5
        Me.RsEdit.Cursor = System.Windows.Forms.Cursors.Default
        Me.RsEdit.Location = New System.Drawing.Point(129, 30)
        Me.RsEdit.Name = "RsEdit"
        Me.RsEdit.Size = New System.Drawing.Size(47, 48)
        '
        'RsDel
        '
        Me.RsDel.BackColor = System.Drawing.Color.Crimson
        Me.RsDel.BackgroundImage = Global.Al_Mohasib.My.Resources.Resources.COR_32
        Me.RsDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.RsDel.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RsDel.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.RsDel.CornerRadius = 5
        Me.RsDel.Cursor = System.Windows.Forms.Cursors.Default
        Me.RsDel.Location = New System.Drawing.Point(231, 30)
        Me.RsDel.Name = "RsDel"
        Me.RsDel.Size = New System.Drawing.Size(47, 48)
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(318, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(369, 327)
        Me.Panel2.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(2)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Machine})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.DefaultCellStyle.Padding = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(369, 327)
        Me.DataGridView1.TabIndex = 0
        '
        ''ALMohassinDBDataSet
        ''
        'Me.ALMohassinDBDataSet.DataSetName = "ALMohassinDBDataSet"
        'Me.ALMohassinDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        ''
        ''AdminFactureBindingSource
        ''
        'Me.AdminFactureBindingSource.DataMember = "AdminFacture"
        'Me.AdminFactureBindingSource.DataSource = Me.ALMohassinDBDataSet
        ''
        ''AdminFactureTableAdapter
        ''
        'Me.AdminFactureTableAdapter.ClearBeforeFill = True
        ''
        ''AdminFactureBindingSource1
        ''
        'Me.AdminFactureBindingSource1.DataMember = "AdminFacture"
        'Me.AdminFactureBindingSource1.DataSource = Me.ALMohassinDBDataSet
        ''
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        '
        'Machine
        '
        Me.Machine.HeaderText = "Nom"
        Me.Machine.Name = "Machine"
        Me.Machine.ReadOnly = True
        '
        'AddMashine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 327)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "AddMashine"
        Me.Text = "Elements"
        Me.Panel1.ResumeLayout(False)
        Me.pl.ResumeLayout(False)
        Me.pl.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.ALMohassinDBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.AdminFactureBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.AdminFactureBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtBox1 As Al_Mohasib.TxtBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    'Friend WithEvents ALMohassinDBDataSet As Al_Mohasib.ALMohassinDBDataSet
    'Friend WithEvents AdminFactureBindingSource As System.Windows.Forms.BindingSource
    ''Friend WithEvents AdminFactureTableAdapter As Al_Mohasib.ALMohassinDBDataSetTableAdapters.AdminFactureTableAdapter
    'Friend WithEvents AdminFactureBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RsOk As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RsAdd As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RsEdit As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RsDel As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents pl As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Machine As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
