Public Class bSetting

    Public str_Path As String = ""

    Private Sub btColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btColor.Click
        Try
            Dim OPF As New OpenFileDialog
            If OPF.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim fi As New IO.FileInfo(OPF.FileName)
                Dim directoryName As String = fi.DirectoryName
                str_Path = directoryName
                txtF1.text = str_Path
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcon.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label22.Click, Button16.Click
        Dim gch As New ChooseBanque
        gch.str_Path = str_Path
        If gch.ShowDialog = DialogResult.OK Then
            Dim gf As New bForm
            gf.str_Path = str_Path
            gf.localname = gch.localName
            gf.LoadXml()


            If gf.ShowDialog = DialogResult.OK Then
            End If

        End If
    End Sub
End Class