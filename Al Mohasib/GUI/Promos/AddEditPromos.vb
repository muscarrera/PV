Public Class AddEditPromos
    Public localname As String = "Default.dat"

    Private Sub btRelveClientArch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRelveClientArch.Click
        Dim g As New Promos
        g.name = TxtBox1.text
     
        WriteToXmlFile(Of Promos)(Form1.ImgPah & "\Prt_Dsn\" & localname, g)
    End Sub
End Class