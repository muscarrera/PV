Public Class paypmt


    Private Sub btcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcancel.Click
        txtmontant.Text = ""
        cbway.SelectedItem = "كاش"
        btcon.Tag = "0"
    End Sub
   
    Private Sub btcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcon.Click

        'validation
        ''empty field
        If txtmontant.Text.Trim = "" Then
            MsgBox("عذرا لا يمكن اتمام طلبكم.. المرجوا تعبئة المبلغ", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
            txtmontant.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtmontant.Text) Then

            If txtmontant.Text.Contains(".") Then
                txtmontant.Text = txtmontant.Text.Replace(".", ",")
            End If



            If Not IsNumeric(txtmontant.Text) Then


                MsgBox("عذرا لا يمكن اتمام طلبكم.. المبلغ يجب ان يكون بالارقام", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                txtmontant.Focus()
                Exit Sub
            End If
        End If
        If cbway.Text = "" Or IsNothing(cbway.Text) Then
            cbway.Text = "كاش"
        End If

        DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub cbway_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbway.SelectedIndexChanged
        If cbway.SelectedItem = "كاش" Then
            txtnum.Text = "0"
            txtnum.Visible = False
            lbnum.Visible = False
        Else
            txtnum.Visible = True
            lbnum.Visible = True
        End If
    End Sub
End Class