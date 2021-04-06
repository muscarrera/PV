Public Class ShapeElement

    Event DeleteMe(ByVal shapeElement As ShapeElement)
    Event ValueChanged()

    Public Property Data As String
        Get
            If Not IsNumeric(txt1.Text) Then txt1.Text = 0
            If Not IsNumeric(txt2.Text) Then txt2.Text = 0

            Return txt1.Text & "*" & txt2.Text
        End Get
        Set(ByVal value As String)

            Try
                txt1.Text = value.Split("*")(0)
                txt2.Text = value.Split("*")(1)
            Catch ex As Exception

            End Try

        End Set
    End Property



    Private Sub ShapeElement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()

        txt1.Focus()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RaiseEvent DeleteMe(Me)
    End Sub

    Private Sub txt1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt2.TextChanged, txt1.TextChanged
        RaiseEvent ValueChanged()
    End Sub
End Class
