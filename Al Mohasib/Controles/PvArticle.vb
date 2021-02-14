Public Class PvArticle

    Public Event Choosed(ByVal sender As Object, ByVal e As EventArgs)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' lb.Font = New Font(Form1.fontName_PV, Form1.fontSize_PV, FontStyle.Bold)


    End Sub
    Private _data As DataRow
    Public Property DataSource() As DataRow
        Get
            Return _data
        End Get
        Set(ByVal value As DataRow)
            _data = value

            lb.Text = value.Item("name").ToString.ToLower

            Try
                Dim arrImage() As Byte
                arrImage = value.Item("img")
                Dim mstream As New System.IO.MemoryStream(arrImage)
                Me.BackgroundImage = Image.FromStream(mstream)
            Catch ex As Exception
                Me.BackgroundImage = Nothing
            End Try

            'plB.Height = lb.PreferredHeight

        End Set
    End Property

    Private Sub lb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click, lb.Click
        RaiseEvent Choosed(Me, e)
    End Sub





End Class
