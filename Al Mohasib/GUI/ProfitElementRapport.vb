Public Class ProfitElementRapport

    Dim _dt As DataTable

    Public dt_Pr As DataTable
     

    Private Sub ProfitElementRapport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = dt_Pr

        For i As Integer = 0 To DataGridView1.Columns.Count - 1
            DataGridView1.Columns(i).Visible = False
        Next
        DataGridView1.Columns(0).Visible = True
        DataGridView1.Columns(2).Visible = True
        DataGridView1.Columns(3).Visible = True


    End Sub
    Dim id As Integer = 0
    Private Sub ClearTxt(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtDesig.text = ""
        txtValeur.text = ""
        id = 0
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ClearTxt(sender, e)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ClearTxt(sender, e)
        If DataGridView1.SelectedRows.Count = 0 Then Exit Sub

        id = DataGridView1.SelectedRows(0).Cells(0).Value
        txtDesig.text = DataGridView1.SelectedRows(0).Cells(2).Value
        txtValeur.text = DataGridView1.SelectedRows(0).Cells(3).Value

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Not IsNumeric(txtValeur.text) Then
            txtValeur.TXT.Focus()
            Exit Sub
        End If

        If id = 0 Then
            dt_Pr.Rows.Add(dt_Pr.Rows.Count, 0, txtDesig.text, txtValeur.text, 0, Now.ToString(), True, Form1.adminName)
        Else
            dt_Pr.Rows(id).Item(2) = txtDesig.text
            dt_Pr.Rows(id).Item(3) = txtValeur.text
        End If

        ClearTxt(sender, e)
    End Sub
End Class