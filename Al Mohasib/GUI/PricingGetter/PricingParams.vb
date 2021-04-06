Public Class PricingParams

    Private Sub PricingParams_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtImgPr.Text = getRegistryinfo("ImgPath", "c")
        txtImgSl.Text = getRegistryinfo("ImgPathSl", "c")
        txtImgScanner.Text = getRegistryinfo("imgScanner", "c")

        txtMsg.Text = getRegistryinfo("pricingMsh", "c")
        cbSl.Text = getRegistryinfo("intSlider", "10")
        cbPr.Text = getRegistryinfo("intProduct", "20")
    End Sub
    Private Function getRegistryinfo(ByVal str As String, ByVal v As String)
        Try
            Dim msg As String
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, Nothing)
            If msg = Nothing Then
                msg = v
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, msg)
                Return msg
            Else
                Return msg
            End If
        Catch ex As Exception
        End Try

        Return v
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim OPF As New OpenFileDialog
            If OPF.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim fi As New IO.FileInfo(OPF.FileName)
                Dim directoryName As String = fi.DirectoryName
                txtImgPr.Text = directoryName
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim OPF As New OpenFileDialog
            If OPF.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim fi As New IO.FileInfo(OPF.FileName)
                Dim directoryName As String = fi.DirectoryName
                txtImgSl.Text = directoryName
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "ImgPathSl", txtImgSl.Text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "ImgPath", txtImgPr.Text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "imgScanner", txtImgScanner.Text)

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "pricingMsh", txtMsg.Text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "intSlider", cbSl.Text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "intProduct", cbPr.Text)


            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim OPF As New OpenFileDialog
            If OPF.ShowDialog = Windows.Forms.DialogResult.OK Then
                txtImgScanner.Text = OPF.FileName
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
End Class