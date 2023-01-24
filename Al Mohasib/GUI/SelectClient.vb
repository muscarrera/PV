Public Class SelectClient

    Public cid As Integer = 0
    Public cName As String = ""
    Public cAdress As String = ""
    Public num As String = ""
    Public ref As String = ""

    Public isUpdatingMode As Boolean = False
    Dim TB_Client As String = "Client"

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TXT.Text.Length < 4 Then Exit Sub

        ref = ""

        If TXT.Text.StartsWith("99989") Then ' create new bon for client
            Dim str As String = TXT.Text.Remove(0, 5)
            str = str.Remove(str.Length - 1)
            ref = str

        Else
            ref = TXT.Text
        End If

        If ref <> "" Then

            If isUpdatingMode Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Exit Sub
            End If


            Dim dt As DataTable
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)
                params.Add("code", ref)

                Try
                    dt = c.SelectDataTable(TB_Client, {"*"}, params)
                    If dt.Rows.Count > 0 Then
                        cid = dt.Rows(0).Item(0)
                        cName = dt.Rows(0).Item(1)
                        cAdress = dt.Rows(0).Item("Adress")
                        num = 0

                        Me.DialogResult = Windows.Forms.DialogResult.OK

                    End If

                Catch ex As Exception
                    dt = Nothing
                End Try
            End Using
        End If

    End Sub

    Private Sub SelectClient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Show()
        TXT.Focus()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If isUpdatingMode Then Exit Sub
       
        Dim chs As New ChoseClient
        chs.isSell = Form1.RPl.isSell

        If chs.ShowDialog = Windows.Forms.DialogResult.OK Then

            cid = chs.cid
            cName = chs.clientName
            cAdress = chs.clientadresse
            num = chs.num

            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
         
    End Sub

    Private Sub TXT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT.KeyPress

        If e.KeyChar = Chr(13) Then
            Button1_Click(Nothing, Nothing)
        End If


    End Sub

End Class