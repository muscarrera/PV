Public Class AddMashine
    Private AddMode As Boolean
    Private idM As Integer

    Private Sub RectangleShape4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RsAdd.Click
        TxtBox1.text = ""
        AddMode = True
        pl.Visible = True
    End Sub
    Private Sub RectangleShape5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RsEdit.Click

        If DataGridView1.Rows.Count = 0 Then Exit Sub
        TxtBox1.text = DataGridView1.SelectedRows(0).Cells(1).Value
        idM = DataGridView1.SelectedRows(0).Cells(0).Value
        AddMode = False
        pl.Visible = True
    End Sub
    Private Sub RectangleShape6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RsDel.Click
        If DataGridView1.Rows.Count = 0 Then Exit Sub
        idM = DataGridView1.SelectedRows(0).Cells(0).Value

        If MsgBox("هل حقا تريد حذف هذه الالة", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add("Mid", idM)
            c.DeleteRecords("Machine", params)
            params.Clear()
            params.Add("dpid", idM)
            c.DeleteRecords("Depot", params)

            AddMode = True
        End Using

        Fillsub()
    End Sub

    Private Sub AddMashine_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Fillsub()

    End Sub

    Private Sub RsOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RsOk.Click
        If TxtBox1.text = "" Then Exit Sub
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)

            If AddMode Then
                params.Add("name", TxtBox1.text)

                Dim dpis As Integer = c.InsertRecord("Machine", params, True)
                'params.Add("dpid", dpis)
                'c.InsertRecord("Depot", params)
            Else
                params.Add("Mid", idM)
                Dim where As New Dictionary(Of String, Object)
                where.Add("name", TxtBox1.text)
                c.UpdateRecord("Machine", where, params)
            End If

        End Using


        Fillsub()
    End Sub

    Private Sub Fillsub()
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            Dim dt = c.SelectDataTable("Machine", {"*"})
            DataGridView1.Rows.Clear()

            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    DataGridView1.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item(1))
                Next
            End If
        End Using
        idM = 0
        AddMode = True
        pl.Visible = False
    End Sub

End Class