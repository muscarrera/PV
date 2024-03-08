Imports System.IO

Public Class SelectBanque
    Public SelectedBanque As String = ""


    Private Sub FillBanques()
        Dim dir1 As New DirectoryInfo(ChequePanel.str_Path & "\bqu")
        If dir1.Exists = False Then dir1.Create()

        Dim aryFi As IO.FileInfo() = dir1.GetFiles("*.bqu")
        Dim fi As IO.FileInfo

        
        For Each fi In aryFi
            dg.Rows.Add(fi.Name.Split(".")(0))
        Next
     
    End Sub
    Private Sub SelectBanque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        StyleDatagrid(dg)
        FillBanques()
    End Sub
    Private Sub StyleDatagrid(ByRef dg As DataGridView)
        dg.AutoGenerateColumns = True
        dg.BorderStyle = Windows.Forms.BorderStyle.None
        dg.CellBorderStyle = DataGridViewCellBorderStyle.None
        dg.RowsDefaultCellStyle.BackColor = Color.White
        dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew

        'dg.DefaultCellStyle.SelectionBackColor = Form1.Color_Selected_Row
        'dg.DefaultCellStyle.SelectionForeColor = Form1.Color_Selected_Text

        dg.BackgroundColor = Color.White

        dg.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dg.MultiSelect = False

        dg.AllowUserToResizeColumns = False
        dg.AllowUserToAddRows = False
        dg.AllowUserToDeleteRows = False
        dg.AllowUserToResizeRows = False
        dg.EditMode = DataGridViewEditMode.EditProgrammatically

        dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dg.RowTemplate.Height = 33

        dg.Dock = DockStyle.Fill
        dg.RowHeadersVisible = False
        dg.ColumnHeadersVisible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If dg.SelectedRows.Count = 0 Then Me.DialogResult = Windows.Forms.DialogResult.Cancel

        SelectedBanque = dg.SelectedRows(0).Cells(0).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub dg_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellContentDoubleClick
        If dg.SelectedRows.Count = 0 Then Me.DialogResult = Windows.Forms.DialogResult.Cancel

        SelectedBanque = dg.SelectedRows(0).Cells(0).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class