Public Class PochetClient


    Public isSell As Boolean = True
    Public clid As Integer = 0

    Private Property clientName As Object

    Private Sub PochetClient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)


                Dim tableName As String = "CompanyPayment"
                Dim tName As String = "Bon"
                Dim fld As String = "bonid"
                Dim cl As String = "comid"
                Dim _pid As String = "PBid"

                If isSell Then
                    tableName = "Payment"
                    tName = "Facture"
                    fld = "fctid"
                    cl = "clid"
                    _pid = "Pid"
                End If

                Dim params As New Dictionary(Of String, Object)

                params.Add(fld, 0)
                params.Add(cl, clid)

                Dim pchdt = c.SelectDataTable(tableName, {_pid, "montant"}, params)
                If pchdt.Rows.Count > 0 Then
                    lbPoch.Tag = IntValue(pchdt, _pid, 0)
                    lbPoch.Text = DblValue(pchdt, "montant", 0).ToString(Form1.frmDbl)

                End If

                params = Nothing
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Not IsNumeric(TextBox1.Text) Then Exit Sub

        Dim tableName As String = "CompanyPayment"
        Dim tName As String = "Bon"
        Dim fld As String = "bonid"
        Dim cl As String = "comid"
        Dim _pid As String = "PBid"

        If isSell Then
            tableName = "Payment"
            tName = "Facture"
            fld = "fctid"
            cl = "clid"
            _pid = "Pid"
        End If

        Try
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                Dim where As New Dictionary(Of String, Object)

                Dim p As Integer = 0
                Dim m As Double = 0
                Try
                    params.Clear()
                    params.Add(fld, 0)
                    params.Add(cl, clid)

                    Dim pchdt = c.SelectDataTable(tableName, {_pid, "montant"}, params)
                    p = IntValue(pchdt, _pid, 0)
                    m = DblValue(pchdt, "montant", 0)
                Catch ex As Exception
                End Try

                If p > 0 Then
                    params.Clear()
                    where.Clear()

                    params.Add("montant", CDbl(TextBox1.Text))
                    where.Add(_pid, p)
                    c.UpdateRecord(tableName, params, where)
                    params.Clear()
                Else
                    params.Clear()
                    params.Add("montant", CDbl(TextBox1.Text))
                    params.Add("name", lbClient.text)
                    params.Add(cl, clid)
                    params.Add("way", "POCHET")
                    params.Add("date", Format(Now.AddYears(-10), "dd-MM-yyyy HH:mm"))
                    params.Add("Num", "POCHET")
                    params.Add(fld, 0)
                    params.Add("writer", CStr(Form1.adminName))

                    c.InsertRecord(tableName, params)
                    params.Clear()
                End If

                lbPoch.Text = CDbl(TextBox1.Text).ToString(Form1.frmDbl)
                TextBox1.Text = ""
                params = Nothing
            End Using
        Catch ex As Exception
        End Try
    End Sub
End Class