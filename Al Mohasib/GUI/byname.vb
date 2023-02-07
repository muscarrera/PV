Public Class byname

    Public qte As Double
    Public ii As Integer = 0
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message,
                                               ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim k As System.Windows.Forms.Keys = keyData
        Select Case keyData

        
            Case Keys.Space
             Button15_Click(Nothing, Nothing)
            Case Keys.Enter
                Button15_Click(Nothing, Nothing)


            Case Keys.Escape
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
           
            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)
        End Select
         
        Return True
    End Function

    Private Sub byname_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txt.TXT.Focus()

        If Form1.cbOptionJenani.Checked And Form1.RPl.isSell Then
            Me.Width = 756
        Else
            Me.Width = 500
        End If


        If ii = 1 Then
            Me.Width = 500
        ElseIf ii = 2 Then
            Label1.Text = "Prix"
            Label10.Text = "الثمن"
            Me.Width = 500
        Else
            Me.Width = 756
        End If



        If Form1.cbJnReduireQte.Checked Then
            plFooter.Height = 11
            Me.Width = 500
            Me.Height = 170
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        End If

        Me.Show()
        txt.Focus()
    End Sub

    Private Sub txt_KeyDownOk() Handles txt.KeyDownOk
        If txt.text = "0" Then Exit Sub

        If txt.text = "" Then
            If ii = 2 Then
                txt.TXT.Focus()
                Exit Sub
            End If
            qte = 1
        Else
            qte = txt.text
        End If


        If ii = 3 Then
            txtPrice.TXT.Focus()
        Else
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click, Button9.Click, Button8.Click, Button7.Click, Button4.Click, Button2.Click, Button17.Click, Button16.Click, Button13.Click, Button12.Click, Button11.Click
        Dim bt As Button = sender
        Dim decimalSeparator As String = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        If bt.Text = Button17.Text Then
            If Not txt.text.Contains(decimalSeparator) Then txt.text = txt.text + decimalSeparator
            txt.Focus()
            Exit Sub
        End If
        txt.text = txt.text + bt.Text
        txt.Focus()
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        'If txt.TXT.Focused Then
        '    txt_KeyDownOk()
        'Else
        '    txtPrice_KeyDownOk()
        'End If


        If txt.text = "0" Then Exit Sub

        If txt.text = "" Then
            If ii = 2 Then
                txt.TXT.Focus()
                Exit Sub
            End If
            qte = 1
        Else
            qte = txt.text
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK


        'If ii = 3 Then
        '    txtPrice.TXT.Focus()
        'Else
        '    Me.DialogResult = Windows.Forms.DialogResult.OK
        'End If

    End Sub

    Private Sub BTp1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTp4.Click, BTp3.Click, BTp2.Click, BTp1.Click
        Dim bt As Button = sender

        txtPrice.text = bt.Text
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        BTp1_Click(BTp1, e)
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        BTp1_Click(BTp2, e)
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
         BTp1_Click(BTp3, e)
    End Sub

    Private Sub txtPrice_KeyDownOk() Handles txtPrice.KeyDownOk
        If txt.text = "" Then
            qte = 1
        Else
            qte = txt.text
        End If
         

        If txtPrice.text = "" Or txtPrice.text = "0" Then
            txtPrice.TXT.Focus()
            Exit Sub
        End If
         
        Me.DialogResult = Windows.Forms.DialogResult.OK
         
    End Sub
End Class