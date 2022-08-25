Public Class SelectBon
    Public ReadOnly Property fctId As Integer
        Get
            If DG.SelectedRows.Count = 0 Then Return 0
            Return DG.SelectedRows(0).Cells(0).Value
        End Get
    End Property
    Public ReadOnly Property cId As Integer
        Get
            If DG.SelectedRows.Count = 0 Then Return 0
            Return DG.SelectedRows(0).Cells(1).Value
        End Get
    End Property
    Public ReadOnly Property ClientName As String
        Get
            If DG.SelectedRows.Count = 0 Then Return ""
            Return DG.SelectedRows(0).Cells(3).Value
        End Get
    End Property

    Private Sub btcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel

    End Sub

    Private Sub btcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcon.Click
        If DG.SelectedRows.Count = 0 Then Exit Sub
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btSearchArch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSearchArch.Click
        Dim dt1 = New DateTime(dte2.Value.Year, dte2.Value.Month, dte2.Value.Day, 23, 59, 0, 0)
        Dim dt2 = New DateTime(dte1.Value.Year, dte1.Value.Month, dte1.Value.Day, 0, 1, 0, 0)

        Dim tName As String = "Bon"

        Dim params As New Dictionary(Of String, Object)
        Dim dt As DataTable = Nothing

        DG.Rows.Clear()

        Try
            If txtArSearch.text <> "" Then
                If IsNumeric(txtArSearch.text) Then
                    Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                        params.Add("bonid LIKE ", "%" & txtArSearch.text & "%")
                        params.Add("admin = ", True)
                        dt = a.SelectDataTableSymbols(tName, {"*"}, params)
                    End Using

                ElseIf txtArSearch.text.Contains("|") Then
                    Dim str As String = txtArSearch.text.Trim
                    str = str.Split(CChar("|"))(1)
                    Dim clid As Integer = CInt(str)

                    Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                        params.Add("clid = ", clid)
                        params.Add("[date] < ", dt1)
                        params.Add("[date] > ", dt2)
                        params.Add("admin = ", True)


                        If cbSearchRegler.Text = "Reglé" Then params.Add("payed = ", True)
                        If cbSearchRegler.Text = "Non Reglé" Then params.Add("payed = ", False)
                        dt = a.SelectDataTableSymbols(tName, {"*"}, params)
                    End Using
                End If
            Else
                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    params.Add("[date] < ", dt1)
                    params.Add("[date] > ", dt2)
                    params.Add("admin = ", True)

                    If cbSearchRegler.Text = "Reglé" Then params.Add("payed = ", True)
                    If cbSearchRegler.Text = "Non Reglé" Then params.Add("payed = ", False)

                    dt = a.SelectDataTableSymbols(tName, {"*"}, params)
                End Using
            End If

            If dt.Rows.Count > 0 Then

                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim rest As Decimal = CDec(dt.Rows(i).Item("total").ToString - CDec(dt.Rows(i).Item("avance").ToString))

                    DG.Rows.Add(dt.Rows(i).Item(0).ToString,
                     dt.Rows(i).Item("clid").ToString, dt.Rows(i).Item("date").ToString,
                     dt.Rows(i).Item("name").ToString,
                   String.Format("{0:n2}", CDec(dt.Rows(i).Item("total").ToString)),
                     String.Format("{0:n2}", CDec(dt.Rows(i).Item("avance").ToString)),
                     String.Format("{0:n2}", rest))


                Next
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' color payed

            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Try

            Dim chs As New ChoseClient
            chs.isSell = False
            If chs.ShowDialog = Windows.Forms.DialogResult.OK Then
                txtArSearch.text = chs.clientName & "|" & chs.cid
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SelectBon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If txtArSearch.text <> "" Then
            btSearchArch_Click(Nothing, Nothing)
        End If
    End Sub
End Class