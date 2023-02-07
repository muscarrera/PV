Public Class PromoListClientIdForm
    Public PromoListClient As New List(Of String)


    Private Sub TxtBox1_KeyDownOk() Handles TxtBox1.KeyDownOk
        Button3_Click(Nothing, Nothing)
    End Sub
    Private Sub fillData()
        dg.Rows.Clear()
        For Each s In PromoListClient
            dg.Rows.Add(s)
        Next
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        If PromoListClient.Contains(TxtBox1.text) = False Then
            PromoListClient.Add(TxtBox1.text)
            fillData()
            TxtBox1.text = ""
        End If
        '        IList<String> list_string= new List<String>();
        'DataGridView.DataSource = list_string.Select(x => new { Value = x }).ToList();
        'dgvSelectedNode.Show();

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If dg.SelectedRows.Count > 0 Then
            For i As Integer = 0 To dg.SelectedRows.Count - 1
                PromoListClient.Remove(dg.SelectedRows(i).Cells(0).Value)
            Next
            fillData()
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim chs As New ChoseClient
        chs.isSell = Form1.RPl.isSell
        chs.editMode = False
        If chs.ShowDialog = Windows.Forms.DialogResult.OK Then

            If PromoListClient.Contains(chs.cid) = False Then
                PromoListClient.Add(chs.cid)
               fillData()
            End If

           
        End If
    End Sub

    Private Sub btcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcon.Click
        Dim str As String = String.Join("|", PromoListClient)
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "PromoListClient", str)
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub PromoListClientIdForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim _ss As String = ""
        getRegistryinfo(_ss, "PromoListClient", "")
        Dim __ls = _ss.Split("|")
        PromoListClient.Clear()
        For Each __s In __ls
            PromoListClient.Add(__s)
        Next
        fillData()
    End Sub
    Private Sub getRegistryinfo(ByRef txt As String, ByVal str As String, ByVal v As String)
        Try
            Dim msg As String
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, Nothing)
            If msg = Nothing Then
                msg = v
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, msg)
                txt = msg
            Else
                txt = msg
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class