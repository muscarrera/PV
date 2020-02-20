Public Class Massar
    Private str, conString As String

    Private Sub Massar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        str = Form1.btDbDv.Tag
        conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & str & ";Persist Security Info=False;"
    End Sub
    Public Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DataGridView1.Rows.Clear()
        Try
            Using c As DataAccess = New DataAccess(conString, True)
                Dim params As New Dictionary(Of String, Object)
                params.Add("fctid", TxtBox1.text)

                Dim dt = c.SelectDataTable("historique", {"*"}, params)
                If dt.Rows.Count > 0 Then
                    txtClient.text = dt.Rows(0).Item("client")
                    txtfct.text = dt.Rows(0).Item("fctid")

                    For j As Integer = 0 To dt.Rows.Count - 1
                        DataGridView1.Rows.Add(CDate(dt.Rows(j).Item("date")).ToString("dd, MMM yy"),
                                               dt.Rows(j).Item("Designation"),
                                                 dt.Rows(j).Item("Qte"),
                                               dt.Rows(j).Item("Price"),
                                               dt.Rows(j).Item("writer"))
                    Next
                End If

                ColorRows()

            End Using
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DataGridView2.Rows.Clear()
        Using c As DataAccess = New DataAccess(conString, True)
            Dim dt1 As Date = Date.Parse(DateTimePicker1.Text).AddDays(1)
            Dim dt2 As Date = Date.Parse(DateTimePicker1.Text).AddDays(-1)


            Dim params As New Dictionary(Of String, Object)
            params.Add("[date] <", dt1)
            params.Add("[date] >", dt2)

            Dim dt = c.SelectDataTableSymbols("historique", {"*"}, params)
            If dt.Rows.Count > 0 Then

                For j As Integer = 0 To dt.Rows.Count - 1
                    Dim ex As Boolean = False
                    For I = 0 To DataGridView2.Rows.Count - 1
                        If DataGridView2.Rows(I).Cells(0).Value = dt.Rows(j).Item("fctid") Then
                            ex = True
                        End If
                    Next

                    If ex = False Then DataGridView2.Rows.Add(dt.Rows(j).Item("fctid"), dt.Rows(j).Item("client"))
                Next
            End If
        End Using
    End Sub

    Private Sub ColorRows()
        For i = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(1).Value = "Total" Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.BurlyWood
                DataGridView1.Rows(i).Cells(1).Style.Font = New Font("Arial", 11, FontStyle.Bold)
            ElseIf DataGridView1.Rows(i).Cells(1).Value = "Avance" Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.GreenYellow
                DataGridView1.Rows(i).Cells(1).Style.Font = New Font("Arial", 11, FontStyle.Bold)
            End If
        Next
    End Sub

    Private Sub DataGridView2_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        If DataGridView2.SelectedRows.Count = 0 Then Exit Sub
        DataGridView1.Rows.Clear()

        Using c As DataAccess = New DataAccess(conString, True)
            Dim params As New Dictionary(Of String, Object)
            params.Add("fctid", DataGridView2.SelectedRows(0).Cells(0).Value)

            Dim dt = c.SelectDataTable("historique", {"*"}, params)
            If dt.Rows.Count > 0 Then
                txtClient.text = dt.Rows(0).Item("client")
                txtfct.text = dt.Rows(0).Item("fctid")

                For j As Integer = 0 To dt.Rows.Count - 1
                    DataGridView1.Rows.Add(CDate(dt.Rows(j).Item("date")).ToString("dd, MMM yy"),
                                           dt.Rows(j).Item("Designation"),
                                             dt.Rows(j).Item("Qte"),
                                           dt.Rows(j).Item("Price"),
                                           dt.Rows(j).Item("writer"))
                Next
            End If

            ColorRows()
        End Using
    End Sub

    
End Class