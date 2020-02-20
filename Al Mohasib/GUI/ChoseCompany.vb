Public Class ChoseCompany
    Dim cid As Integer = 0
    Dim clientName As String = Form1.txtcltcomptoir.Text
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel

    End Sub

    Private Sub Button35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button35.Click

        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(1).Value.ToString.Contains(txtsearch.Text) Then
                DataGridView1.Rows(i).Selected = True
                DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.Rows(i).Index
                Exit For
            End If
            If DataGridView1.Rows(i).Cells(2).Value.ToString.Contains(txtsearch.Text) Then
                DataGridView1.Rows(i).Selected = True
                DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.Rows(i).Index
                Exit For
            End If
            If DataGridView1.Rows(i).Cells(0).Value.ToString.Contains(txtsearch.Text) Then
                DataGridView1.Rows(i).Selected = True
                DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.Rows(i).Index
                Exit For
            End If
        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cid = DataGridView1.SelectedRows(0).Cells(0).Value
        clientName = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim cltdlg As New company
        cltdlg.btcon.Tag = "0"
        If cltdlg.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
        CompanyTableAdapter.Fill(ALMohassinDBDataSet.company)

    End Sub

    Private Sub txtsearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsearch.KeyPress
        If Button1.Enabled = True Then
            If e.KeyChar = Chr(13) Then

                cid = DataGridView1.SelectedRows(0).Cells(0).Value
                clientName = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                Me.DialogResult = Windows.Forms.DialogResult.OK


            End If
        End If
    End Sub

    Private Sub txtsearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsearch.KeyUp
        Button5_Click(Nothing, Nothing)
    End Sub

    Private Sub ChoseCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ALMohassinDBDataSet.company' table. You can move, or remove it, as needed.
        Me.CompanyTableAdapter.Fill(Me.ALMohassinDBDataSet.company)

    End Sub
End Class