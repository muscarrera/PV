Public Class SavePrint

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.Tag = "0"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button48.Click


        Dim a As Integer = 0
        Dim b As Integer = 0
        Try
            If CheckBox2.Checked Then
                a = 1
            End If
            If CheckBox3.Checked Then
                b = 1
            End If
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "resprt", b)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "dptprt", a)
        Catch ex As Exception

        End Try

        Button1.Tag = "1"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Try
        '    Form1.PrintPreviewDialog1.ShowDialog()
        'Catch ex As Exception
        '    Exit Sub
        'End Try

    End Sub

    Private Sub SavePrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        chbprt.Items.Add(Form1.txttimp.Text)
        If Form1.chbreceipt.Checked = True Then
            chbprt.Items.Add(Form1.txtreceipt.Text)
        End If
        If Form1.chbprint.Checked = True Then
            chbprt.Items.Add(Form1.txtprt2.Text)
        End If

        chbprt.Text = chbprt.Items(0).ToString

        Try
            Dim msg As String

            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "resprt", Nothing)
            If msg = Nothing Or msg = "0" Then
                msg = "0"
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "restprt", msg)
            Else
                CheckBox3.Checked = True
            End If

            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "dptprt", Nothing)
            If msg = Nothing Or msg = "0" Then
                msg = "0"
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "dptprt", msg)
            Else
                CheckBox2.Checked = True
            End If
        Catch ex As Exception

        End Try



    End Sub
End Class