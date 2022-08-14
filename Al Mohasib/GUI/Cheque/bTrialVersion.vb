Public Class bTrialVersion

    Private Sub bTrialVersion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim rnd As New Random
        TextBox1.Text = rnd.Next(9999) & "-" & rnd.Next(9999) & "-" & rnd.Next(9999) & "-" & rnd.Next(9999)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim arr As String() = TextBox1.Text.Split("-")
        arr(0) = 10000 - arr(0)
        arr(1) = 10000 - arr(1)
        arr(2) = 10000 - arr(2)
        arr(3) = 10000 - arr(3)

        Dim str As String = CInt(arr(3)).ToString("0000") & "-" & CInt(arr(0)).ToString("0000") & "-" & CInt(arr(1)).ToString("0000") & "-" & CInt(arr(2)).ToString("0000")
        If TextBox2.Text = str Then
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ALM_ImpCheq", "ALM_ImpCheq_Ref", True)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub
    
End Class