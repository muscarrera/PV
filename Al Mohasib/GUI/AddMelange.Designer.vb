<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddMelange
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddMelange))
        Me.AddList1 = New Al_Mohasib.AddList()
        Me.SuspendLayout()
        '
        'AddList1
        '
        Me.AddList1.AutoCompleteSource = Nothing
        Me.AddList1.barCode = "101894083627"
        Me.AddList1.DataListe = CType(resources.GetObject("AddList1.DataListe"), System.Collections.Generic.Dictionary(Of String, Object))
        Me.AddList1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AddList1.EditMode = False
        Me.AddList1.HasValue = True
        Me.AddList1.Location = New System.Drawing.Point(0, 0)
        Me.AddList1.Name = "AddList1"
        Me.AddList1.Padding = New System.Windows.Forms.Padding(3)
        Me.AddList1.Size = New System.Drawing.Size(589, 339)
        Me.AddList1.TabIndex = 0
        '
        'AddMelange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 339)
        Me.Controls.Add(Me.AddList1)
        Me.Name = "AddMelange"
        Me.Text = "Melange"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AddList1 As Al_Mohasib.AddList
End Class
