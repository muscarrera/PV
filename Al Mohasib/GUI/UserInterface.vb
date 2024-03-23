Imports System.Net

Public Class UserInterface
    Public ID As String = ""
    Public dbid As Integer = "0"
    Public user As New User

    Private Sub UserInterface_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        user.cpu = ID
        user.id = dbid

        txtCPu.Text = user.cpu
        txtId.Text = user.id



        txtN.Select()





        Call CenterToScreen()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized

        Panel6.Location = New Point((Me.Width - Panel6.Width) \ 2, (Me.Height - Panel6.Height) \ 2)



    End Sub
    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' JSON data to be sent in the request body
        Dim jsonData As String = "{""id"": " & user.id & ", ""name"": " & txtN.Text & ", ""ville"": " & txtV.Text & ", ""cpu"": " & txtCPu.Text & ", ""role"": " & txtR.Text & "}" ' Modify this as per your requirements
        ' Dim json As String = ObjectToJson(user)
        ' Call the function to perform the POST request
        Dim result As String = PostDataToApi(jsonData)

        ' Display the result
        MessageBox.Show(result, "POST Request Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Function PostDataToApi(ByVal jsonData As String) As String
        Dim responseMessage As String = String.Empty
        Try
            ' Set TLS version to TLS 1.2
            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)

            ' API endpoint URL
            Dim apiUrl As String = "http://localhost:3000/api/profil"

            ' Create WebClient instance
            Dim client As New WebClient()

            ' Set the Content-Type header
            client.Headers.Add("Content-Type", "application/json")

            ' Perform the POST request and get the response
            Dim responseData As String = client.UploadString(apiUrl, jsonData)

            ' You can process the response data here if needed
            responseMessage = "POST request successful. Response: " & responseData
        Catch ex As WebException
            ' Check if the exception is due to a redirect (status code 308)
            If TypeOf ex.Response Is HttpWebResponse AndAlso DirectCast(ex.Response, HttpWebResponse).StatusCode = 308 Then 'PermanentRedirect
                ' Get the new location from the response header
                Dim redirectUrl As String = ex.Response.Headers("Location")
                responseMessage = "Permanent Redirect to: " & redirectUrl
            Else
                ' Handle other web exceptions
                responseMessage = "Error: " & ex.Message
            End If
        Catch ex As Exception
            ' Handle other exceptions
            responseMessage = "Error: " & ex.Message
        End Try

        Return responseMessage
    End Function

 














End Class

Public Class User
    Public id As String
    Public name As String
    Public ville As String
    Public cpu As String
    Public role As String
End Class