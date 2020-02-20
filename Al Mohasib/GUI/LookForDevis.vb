Public Class LookForDevis
    Public tableName As String
    Public dt As DataTable
    Public isSell As Boolean
    Dim conString As String

    Private Sub LookForDevis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Using a As SubClass = New SubClass(1)
            a.AutoCompleteArticles(txt, tableName)
        End Using

        Dim str As String = Form1.btDbDv.Tag
        conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & str & ";Persist Security Info=False;"

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt1 As Date = Date.Parse(dte2.Text).AddDays(1)
        Dim dt2 As Date = Date.Parse(dte1.Text).AddDays(-1)
        Dim tName As String = "Facture"
        If isSell = False Then tName = "Bon"
        Dim params As New Dictionary(Of String, Object)

        Try
            If txt.text <> "" Then
                If IsNumeric(txt.text) Then
                    Using a As DataAccess = New DataAccess(conString)
                        params.Add("fctid = ", txt.text)
                        dt = a.SelectDataTable(tName, {"*"}, params)
                    End Using

                ElseIf txt.text.Contains("|") Then
                    Dim str As String = txt.text.Trim
                    str = str.Split(CChar("|"))(1)
                    Dim clid As Integer = CInt(str)

                    Using a As DataAccess = New DataAccess(conString)
                        params.Add("clid = ", clid)
                        params.Add("[date] < ", dt1)
                        params.Add("[date] > ", dt2)

                        dt = a.SelectDataTableSymbols(tName, {"*"}, params)
                    End Using
                End If
            Else
                Using a As DataAccess = New DataAccess(conString)
                    params.Add("[date] < ", dt1)
                    params.Add("[date] > ", dt2)

                    dt = a.SelectDataTableSymbols(tName, {"*"}, params)
                End Using
            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK

        Catch ex As Exception
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Sub
End Class