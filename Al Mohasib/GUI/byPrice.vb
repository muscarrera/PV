Public Class byPrice

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button31.Click, Button30.Click, Button3.Click, Button29.Click, Button28.Click, Button27.Click, Button26.Click, Button25.Click, Button24.Click, Button23.Click, Button22.Click
        Dim bt2 As Button = sender

        If bt2.Text = "." Then
            If txt.text.Contains(Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) = False Then
                txt.text &= Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
            End If
        ElseIf IsNumeric(bt2.Text) Then
            txt.text &= bt2.Text
        End If

        txt.Focus()
    End Sub

    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button33.Click
        txt.Text = ""
        txt.Focus()
    End Sub

    Private Sub Panel46_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel46.Paint
        txt.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txt.Text.Contains(".") Then txt.Text.Replace(".", Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
        If txt.Text = "" Or Not IsNumeric(txt.Text) Then Exit Sub
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt.KeyPress
        If txt.Text.Contains(".") Then txt.Text.Replace(".", Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
        If txt.Text = "" Or Not IsNumeric(txt.Text) Then Exit Sub
        If e.KeyChar = Chr(13) Then Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub byPrice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        txt.Focus()
    End Sub

    Private Sub Annuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Annuler.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class