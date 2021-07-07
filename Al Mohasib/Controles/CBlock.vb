Public Class CBlock

    Dim _isActive As Boolean

    Public Event Choosed(ByVal sender As Object, ByVal e As EventArgs)
    Public Event Delete(ByVal ds As CBlock)

    Public ID As Integer = 0
    Public Property isActive As Boolean
        Get
            Return _isActive
        End Get
        Set(ByVal value As Boolean)
            _isActive = value

            If value Then
                os.BackColor = Color.DarkOrange
                rs.BackColor = Color.DarkOrange
                lb.BackColor = Color.DarkOrange
                rs.BorderColor = Color.Black
                bt.Visible = True
            Else
                os.BackColor = Color.Teal
                rs.BackColor = Color.Teal
                lb.BackColor = Color.Teal
                rs.BorderColor = Color.White
                bt.Visible = False
            End If


        End Set
    End Property

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt.Click
        RaiseEvent Delete(Me)
    End Sub

    Private Sub os_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rs.Click, os.Click, MyBase.Click, lb.Click
        'If isActive = False Then Exit Sub


        Dim bt As New Button

        bt.Tag = ID
        RaiseEvent Choosed(bt, e)
        isActive = True
    End Sub
End Class
