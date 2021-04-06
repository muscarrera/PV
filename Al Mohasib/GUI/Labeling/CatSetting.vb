Public Class CatSetting

    Dim localName As String

    Private Sub dgvCats_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCats.CellContentClick
        If dgvCats.SelectedRows.Count = 0 Then Exit Sub
        dgvPages.Rows.Clear()
        Pb.BackgroundImage = Nothing

        lb.Text = dgvCats.SelectedRows(0).Cells(0).Value.ToString
        localName = lb.Text
        LoadXml()

    End Sub
    Public Sub LoadXml()
        Dim g As New CatElement
        Try
            g = ReadFromXmlFile(Of CatElement)(Form1.ImgPah & "\CatDsn\" & localName)
         

            For Each ff As String In g.Pages
                dgvPages.Rows.Add("Pages " & dgvPages.Rows.Count + 1 & " :" & ff)
            Next
        Catch ex As Exception

        End Try
    End Sub

End Class