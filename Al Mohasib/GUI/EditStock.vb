Public Class EditStock

    Private Sub EditStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ALMohassinDBDataSet.company' table. You can move, or remove it, as needed.
        Me.CompanyTableAdapter.Fill(Me.ALMohassinDBDataSet.company)

    End Sub

  

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If TextBox1.Text = TextBox1.Tag Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Exit Sub
        End If


            Dim ta As New ALMohassinDBDataSetTableAdapters.DetailsStockTableAdapter

            For i As Integer = 0 To DGVS.Rows.Count - 1
                Try
                ta.UpdateQte(Double.Parse(DGVS.Rows(i).Cells(4).Value), DGVS.Rows(i).Cells(0).Value)
                Catch ex As Exception

                End Try

            Next
            Me.DialogResult = Windows.Forms.DialogResult.OK


    End Sub

    
    Private Sub DGVS_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVS.CellValueChanged
        TextBox1.Text = "0"
        For i As Integer = 0 To DGVS.Rows.Count - 1
            If Not IsNumeric(DGVS.Rows(i).Cells(4).Value) Then
                TextBox1.Text = TextBox1.Tag
            Else
                TextBox1.Text = Double.Parse(TextBox1.Text) + Double.Parse(DGVS.Rows(i).Cells(4).Value)
            End If

        Next
    End Sub

  
End Class