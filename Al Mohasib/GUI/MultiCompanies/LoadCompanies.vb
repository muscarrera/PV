Imports System.IO

Public Class LoadCompanies

    Public dataName As String

    Private Sub LoadCompanies_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim di As DirectoryInfo = New DirectoryInfo("path")
        'Dim ls = di.GetDirectories()

        Try
            Dim i = 1
            For Each Dir As String In Directory.GetDirectories(Form1.Data_Comp_Path)
                Dim cb As New CompanyBloc
                Dim dirInfo As New System.IO.DirectoryInfo(Dir)
                cb.DataName = dirInfo.Name
                cb.Dock = DockStyle.Top

                AddHandler cb.Activated, AddressOf cb_Activated
                pl.Controls.Add(cb)

                i += 1
                If i > 4 Then Exit Sub
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cb_Activated(ByVal cb As CompanyBloc, ByVal b As Boolean)
        dataName = cb.DataName

        If b = False Then

            dataName = ""
            Exit Sub

        End If


        For Each c As CompanyBloc In pl.Controls
            If c.DataName <> cb.DataName Then c.active = False
        Next

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        If dataName = "" Then
            MsgBox("vous n'avais pas choisir aucune société", MsgBoxStyle.Exclamation, "CMC Pro")
            End
        End If

        ' Form1.BoundDbPath = Form1.Data_Comp_Path & "\" &  & "\ALMohassinDB.mdb"


        ChangeConnectionString(dataName)


        Form1.Text = "Al Mohassib POS" & "   - *** Sté : " & dataName & " *** -"
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Public Sub ChangeConnectionString(ByVal dbname As String)
        Try
            'server=localhost;user id=root;password=;database=pos_db;persistsecurityinfo=True

            Dim lcConnString = My.Settings.movedbConnectionString
            lcConnString = lcConnString.ToLower

            ' if this is a Jet database, find the index of the "data source" setting
            Dim startIndex As Integer
            If lcConnString.IndexOf("jet.oledb") > -1 Then
                startIndex = lcConnString.IndexOf("data source=")
                If startIndex > -1 Then startIndex += 12
            Else
                ' if this is a SQL Server database, find the index of the "initial 
                ' catalog" or "database" setting
                startIndex = lcConnString.IndexOf("initial catalog=")
                If startIndex > -1 Then
                    startIndex += 16
                Else ' if the "Initial Catalog" setting is not found,
                    '  try with "Database"
                    startIndex = lcConnString.IndexOf("database=")
                    If startIndex > -1 Then startIndex += 9
                End If
            End If

            ' if the "database", "data source" or "initial catalog" values are not 
            ' found, return an empty string
            If startIndex = -1 Then Exit Sub

            ' find where the database name/path ends
            Dim endIndex As Integer = lcConnString.IndexOf(";", startIndex)
            If endIndex = -1 Then endIndex = lcConnString.Length

            ' return the substring with the database name/path
            Dim oldchar As String = lcConnString.Substring(startIndex, endIndex - startIndex)

            lcConnString = lcConnString.Replace(oldchar, dbname)

            My.Settings.Item("movedbConnectionString") = lcConnString

            Dim dir1 As New DirectoryInfo(Form1.Data_Comp_Path & "\" & dbname & "\IMG")
            If dir1.Exists = False Then dir1.Create()
            Form1.BtImgPah.Tag = Form1.Data_Comp_Path & "\" & dbname & "\IMG"

        Catch ex As Exception

        End Try
    End Sub



End Class