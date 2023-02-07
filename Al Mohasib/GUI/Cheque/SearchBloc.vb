Public Class SearchBloc

    Dim _key As String
    Public Mode As String = ""

    Event ClearElemeent(ByVal searchBloc As SearchBloc)

    Public Property Key As String
        Get
            Return _key
        End Get
        Set(ByVal value As String)
            _key = value
        End Set
    End Property

    Public Property Value As String
        Get
            Return lb.Text
        End Get
        Set(ByVal value As String)
            lb.Text = ""

            If Mode.Contains(":") Then
                lb.Text = Mode.Split(":")(0) & ": "
            End If
            lb.Text &= value
        End Set
    End Property


    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        RaiseEvent ClearElemeent(Me)
    End Sub



End Class
