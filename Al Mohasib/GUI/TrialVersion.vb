Public Class TrialVersion

    Dim a As Integer = 0
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim arr As String() = TextBox1.Text.Split("-")
        arr(0) = arr(0).Remove(2) + 321
        arr(1) = arr(1).Remove(2) + 654
        arr(2) = arr(2).Remove(2) + 987
        arr(3) = arr(3).Remove(2) + 741
        arr(4) = arr(4).Remove(2) + 258

        Dim str As String = arr(0) & "1-2" & arr(3) & "-3" & arr(1) & "-" & arr(4) & "4-0" & arr(2)
        If TextBox2.Text = str Then
            Try
                Using a As DataAccess2 = New DataAccess2(My.Settings.ALMohassinDBConnectionString)
                    Dim params As New Dictionary(Of String, Object)
                    Dim where As New Dictionary(Of String, Object)
                    where.Add("key", "truefont")
                    params.Add("val", "true")

                    a.UpdateRecord("value", params, where)
                End Using
            Catch ex As Exception

            End Try

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If

    End Sub

    Private Sub trialversion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Using a As DataAccess2 = New DataAccess2(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add("key", "keypsv")


            Dim dt = a.SelectDataTable("value", {"*"}, params)

            Try
                TextBox1.Text = dt.Rows(0).Item("val")
            Catch ex As Exception

            End Try

        End Using


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class