Public Class OpenAvoir



    Private Sub OneYear()

        DGV.Rows.Clear()

        Dim path As String = Form1.btSvPath.Tag & "/AVR_BN/" & DateTimePicker1.Text & "/"
        If Not IO.Directory.Exists(path) Then
            MsgBox("Aucun resultat")
            Exit Sub
        End If
      
        Dim Folder As New IO.DirectoryInfo(path)

        For Each File As IO.FileInfo In Folder.GetFiles("*.*", IO.SearchOption.AllDirectories)

            Try
                Dim strpath As String = path & File.Name
                Dim aa As Integer = 0
                Dim ds As New DataSet
                ds.ReadXml(strpath)
                Try
                    If ds.Tables("FactureInfo").Rows.Count > 0 Then

                        DGV.Rows.Add(File.Name,
                                     ds.Tables("FactureInfo").Rows(0).Item("client"),
                                     ds.Tables("FactureInfo").Rows(0).Item("date"),
                                     ds.Tables("FactureInfo").Rows(0).Item("total"))
                    End If
                Catch ex As Exception

                End Try
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try
        Next

    End Sub
    Private Sub ByClient()

        Dim id As Integer = CInt(TextBox1.Text.Split("|")(1))
        DGV.Rows.Clear()

        Dim path As String = Form1.btSvPath.Tag & "/AVR_BN/" & DateTimePicker1.Text & "/"
        If Not IO.Directory.Exists(path) Then
            MsgBox("Aucun resultat")
            Exit Sub
        End If

        Dim Folder As New IO.DirectoryInfo(path)

        For Each File As IO.FileInfo In Folder.GetFiles("*.*", IO.SearchOption.AllDirectories)

            Try
                Dim strpath As String = path & File.Name
                Dim ds As New DataSet
                ds.ReadXml(strpath)
                Try
                    If ds.Tables("FactureInfo").Rows.Count > 0 Then
                        If id = ds.Tables("FactureInfo").Rows(0).Item("clientID") Then
                            DGV.Rows.Add(File.Name,
                                         ds.Tables("FactureInfo").Rows(0).Item("client"),
                                          ds.Tables("FactureInfo").Rows(0).Item("date"),
                             ds.Tables("FactureInfo").Rows(0).Item("total"))
                        End If
                    End If
                Catch ex As Exception

                End Try
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try
        Next

    End Sub
    Private Sub ById()

        DGV.Rows.Clear()

        Dim path As String = Form1.btSvPath.Tag & "/AVR_BN/" & DateTimePicker1.Text & "/"
        If Not IO.Directory.Exists(path) Then
            MsgBox("Aucun resultat")
            Exit Sub
        End If


        Dim Filename As String = System.IO.Path.GetFileName(TextBox1.text.Trim)
        Dim SavePath As String = System.IO.Path.Combine(path, Filename)

        If System.IO.File.Exists(SavePath) Then
            'The file exists
            Try

                Dim strpath As String = SavePath
                Dim ds As New DataSet
                ds.ReadXml(strpath)

                If ds.Tables("FactureInfo").Rows.Count > 0 Then

                    DGV.Rows.Add(TextBox1.Text, ds.Tables("FactureInfo").Rows(0).Item("client"),
                                  ds.Tables("FactureInfo").Rows(0).Item("date"),
                     ds.Tables("FactureInfo").Rows(0).Item("total"))
                End If

            Catch ex As Exception

            End Try
        Else
            MsgBox("Aucun resultat")
        End If
    End Sub
    Public Y As String
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Y = DateTimePicker1.Text
        If IsNumeric(TextBox1.Text) Then
            ById()
        ElseIf TextBox1.Text.Contains("|") Then
            ByClient()
        Else
            OneYear()
        End If
    End Sub

    Private Sub OpenAvoir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Using a As SubClass = New SubClass(1)
            a.AutoCompleteArticles(TextBox1, "Client")
        End Using
    End Sub

    Public id As Integer = 0
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If DGV.Rows.Count = 0 Then Me.DialogResult = Windows.Forms.DialogResult.Cancel
            id = CInt(DGV.SelectedRows(0).Cells(0).Value)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try


    End Sub
End Class