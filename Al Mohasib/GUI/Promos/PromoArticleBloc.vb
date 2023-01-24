Public Class PromoArticleBloc

    Public Event Choosed(ByVal sender As Object, ByVal e As EventArgs)

    Private _data As PromosArticle
    Public Property DataSource() As PromosArticle
        Get
            Return _data
        End Get
        Set(ByVal value As PromosArticle)
            _data = value

            lbName.Text = value.name
            lbPoints.Text = value.point & " Pts"
            lbQte.Text = value.qte & " U"
            lbType.Text = value.type

            If Form1.RPl.CadeauxAuto_ls.Contains(value) Then
                lbValide.Text = "Auto"
                lbValide.BackColor = Color.GreenYellow
            End If


            ' img = value.img

        End Set
    End Property

    Private Sub Panel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click, lbQte.Click, lbPoints.Click, Button2.Click, lbValide.Click, lbType.Click
        Dim bt As New Button
        bt.Tag = DataSource
        RaiseEvent Choosed(bt, e)
    End Sub
End Class
