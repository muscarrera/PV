Public Class ListUnUsedCheque
    Public isChanged As Boolean = False
    Private Sub ListUnUsedCheque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            Dim params As New Dictionary(Of String, Object)

            params.Add("desig", "0")
            Dim dt = c.SelectDataTable("Payment", {"*"}, params)

            FillRowsByGrid(dt)

        End Using

    End Sub

    Private Sub FillRowsByGrid(ByVal _ds As DataTable)
        Try
            If _ds.Rows.Count > 0 Then


                dg.DataSource = _ds
                StyleDatagrid(dg)

                dg.Columns(0).Visible = False
                dg.Columns(2).Visible = False
                dg.Columns(7).Visible = False
                dg.Columns(8).Visible = False
                dg.Columns(9).Visible = False
                dg.Columns(11).Visible = False
                dg.Columns(12).Visible = False
                dg.Columns(13).Visible = False
                dg.Columns(14).Visible = False
                '  dg.Columns(1).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
                dg.Columns(3).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)

                dg.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                dg.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                dg.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                dg.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                dg.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                dg.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

                dg.Columns(1).HeaderText = "Labels"
                dg.Columns(3).HeaderText = "Montant"
                dg.Columns(4).HeaderText = "M.P"
                dg.Columns(6).HeaderText = "Ref"

                dg.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dg.Columns(3).DefaultCellStyle.Format = "n2"

                dg.Columns(4).DisplayIndex = 1
                dg.Columns(3).DisplayIndex = 2
                dg.Columns(5).DisplayIndex = 3

                dg.Sort(dg.Columns(0), System.ComponentModel.ListSortDirection.Descending)

                StyleDatagrid(dg)
            End If

        Catch ex As Exception
        End Try
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
        dg.ColumnHeadersHeight = 33

        dg.Dock = DockStyle.Fill
        dg.RowHeadersVisible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If dg.SelectedRows.Count = 0 Then Exit Sub
        isChanged = True
        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub btCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class