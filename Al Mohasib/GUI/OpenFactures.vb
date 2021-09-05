Public Class OpenFactures

    Public id As Integer = 0
    Public data As New DataTable

    Private Sub OpenFactures_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tableName As String = "Facture"
        If Form1.RPl.isSell = False Then
            tableName = "Bon"
        End If

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add("admin", False)

            If Form1.cbAffichageLimite.Checked Then params.Add("writer", Form1.adminName)
            data = c.SelectDataTable(tableName, {"*"}, params)
        End Using


        getData()
    End Sub
    Private Sub getData()
     


            If data.Rows.Count > 0 Then
                dg.Rows.Clear()
                For i As Integer = 0 To data.Rows.Count - 1
                
                dg.Rows.Add(data.Rows(i).Item(0), StrValue(data, "name", i), DteValue(data, "date", i))
                Next
            End If

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If dg.SelectedRows.Count = 0 Then Exit Sub

        id = dg.SelectedRows(0).Cells(0).Value

       

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        id = 0
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub TxtBox1_TxtChanged() Handles TxtBox1.TxtChanged

        If TxtBox1.text.Trim = "" Then
            getData()
            Exit Sub
        End If


        Try
            Dim query = From d In data.AsEnumerable()
                                   Where d.Field(Of String)("name").Contains(TxtBox1.text)
                                   Select d

            Dim r As DataTable = query.CopyToDataTable()

            If r.Rows.Count > 0 Then
                dg.Rows.Clear()
                For i As Integer = 0 To r.Rows.Count - 1
                    dg.Rows.Add(r.Rows(i).Item(0), StrValue(r, "name", i), StrValue(r, "ref", i))
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class