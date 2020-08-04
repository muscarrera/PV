Public Class byname

    Public qte As Double

    Private Sub byname_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txt.Focus()
    End Sub

    Private Sub txt_KeyDownOk() Handles txt.KeyDownOk
        If txt.text = "" Then
            qte = 1
        Else
            qte = txt.text
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
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
        If txt.text = "" Then
            qte = 1
        Else
            qte = txt.text
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class