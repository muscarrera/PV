Public Class AddCharges
    Public Val As Double
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged, DateTimePicker1.ValueChanged


        Dim total As Double = 0

        Dim dt1 As Date = Date.Parse(DateTimePicker2.Text).AddDays(1)
        Dim dt2 As Date = Date.Parse(DateTimePicker1.Text).AddDays(-1)
        Dim dt As DataTable = Nothing
        Try
         
            Dim ta As New ALMohassinDBDataSetTableAdapters.PaymentTableAdapter
            dt = ta.GetDataBydtcaisse(dt1, dt2)

            If dt.Rows.Count > 0 Then

                For i As Integer = 0 To dt.Rows.Count - 1

                    DGVARFA.Rows.Add(CDate(dt.Rows(i).Item("date")).ToString("dd, MMM yy"),
                                     dt.Rows(i).Item("name").ToString & "[" & dt.Rows(i).Item("fctid").ToString & "]",
                                             String.Format("{0:F}", dt.Rows(i).Item("montant").ToString))
                    total += dt.Rows(i).Item("montant")
                Next
            Else
                MsgBox("لا توجد اي فاتورة ")
            End If

            TextBox1.Text = DGVARFA.Rows.Count
            TextBox2.Text = total
            If total > 30000 Then
                TextBox3.Text = 900
                Val = (total - 30000) * 4 / 100
                TextBox4.Text = Val
                Val += 900
                TxtBox1.text = Val & " Dhs"
            Else
                TextBox4.Text = 0
                Val = total * 3 / 100
                TextBox3.Text = Val
                TxtBox1.text = Val & " Dhs"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class