Public Class EditDate


    Public dte As Date


    Private Sub MonthCalendar1_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles mc.DateChanged
        Try
            dte = New DateTime(mc.SelectionRange.Start.Date.Year, mc.SelectionRange.Start.Date.Month,
                                       mc.SelectionRange.Start.Date.Day, dte.Hour, dte.Minute, dte.Second)

            txt.Text = dte.ToString("dd/MM/yyyy [HH:mm]")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.DialogResult = Windows.Forms.DialogResult.OK
       
    End Sub
End Class