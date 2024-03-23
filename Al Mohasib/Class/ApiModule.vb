Imports System.Net
Imports System.Net.NetworkInformation

Module ApiModule

    Dim __id As String = "00"
    Dim __oldid As String = "--"
    Dim VER As String = "ALMsbtrFirstRun_sql_12"
    Dim VER_ID As String = "sdf_id_cvb_ver"
    Dim DB_ID As String = "fgh_db_ert_id"

    Dim id__db As String = ""

    Public Function TestApiRequest() As Boolean
        LookForIt()


        Return True
    End Function

    Private Function getRegistryinfo(ByVal str As String, ByVal v As String)
        Try
            Dim msg As String
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\CMC", str, Nothing)
            Return msg
        Catch ex As Exception
            Return v
        End Try
    End Function
    Private Function setRegistryinfo(ByVal str As String, ByVal v As String)
        Try
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\CMC", str, v)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function isAFerstTime() As Boolean

        Try
            Dim md As String = SystemSerialNumber()
            Dim cp As String = CpuId()

            __id = "I5050D" & md & cp
            __oldid = getRegistryinfo(VER_ID, "")

            If __id = __oldid Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return True
        End Try
    End Function
    Private Function LookForIt() As Boolean
        If isAFerstTime() Then
            If __oldid.Length < 5 Then
                Dim us As New UserInterface
                us.ID = __id

                If us.ShowDialog = DialogResult.OK Then
                    setRegistryinfo(VER_ID, __id)
                    setRegistryinfo(DB_ID, us.dbid)




                Else
                    MsgBox("Vous devez Contacter l'administration pour plus d'infos" & vbNewLine & __id, MsgBoxStyle.Information, "***TRIAL INTERFACE***")
                    End
                End If
            End If
        Else





        End If

        Return False
    End Function



    Public Function checkOnLine_Params() As Boolean
        If Form1.__CheckMySituation Then Return True

        Try
            Form1.TabControl1.Controls.Remove(Form1.TabPageArch)
            Form1.TabControl1.Controls.Remove(Form1.TabPageAcu)
            Form1.TabControl1.Controls.Remove(Form1.TabPageFac)
        Catch ex As Exception
        End Try

        Dim trial As New TrialVersion
        If trial.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Return False
            Exit Function
        Else
            Return True
            Exit Function
        End If

        Return False
    End Function

    Public Function GetApiRequestbyID(ByVal id As String) As String
        Dim SmsStatusMsg As String = String.Empty
        Try
            ' Set TLS version to TLS 1.2
            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)

            'Sending SMS To User
            Dim client As WebClient = New WebClient()
            Dim URL As String = "https://www.yanly.io/api/profil/" & id
            SmsStatusMsg = client.DownloadString(URL)

            If SmsStatusMsg.Contains("<br>") Then
                SmsStatusMsg = SmsStatusMsg.Replace("<br>", ", ")
            End If
        Catch e1 As WebException
            SmsStatusMsg = e1.Message
        Catch e2 As Exception
            SmsStatusMsg = e2.Message
        End Try
        Return SmsStatusMsg
    End Function

    Private Function CheckInternetConnection() As Boolean
        Try
            ' Ping a well-known website to check internet connectivity
            Dim ping As New Ping()
            Dim reply As PingReply = ping.Send("www.google.com")

            ' Check if the reply is successful
            Return reply.Status = IPStatus.Success


        Catch ex As Exception
            Return False
        End Try
    End Function
End Module
