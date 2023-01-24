Public Class PopUpMenu

    Public mode As String = "Tag"
    Dim ft As New Font("Arial Rounded MT", 7, FontStyle.Bold)
    Event MenuElementSelected(ByRef ds As PopUpMenu)
    Event MenuLostFocus(ByRef ds As PopUpMenu)


    Public key As String
    Public value As String

    Public Property dataSource As Dictionary(Of String, String)
        Get
            Return Nothing
        End Get
        Set(ByVal value As Dictionary(Of String, String))

            'Me.Controls.Clear()

            For Each c As KeyValuePair(Of String, String) In value
                Dim bt As New Label

                bt.Text = c.Key
                bt.Tag = c.Value
                bt.FlatStyle = FlatStyle.Flat
                bt.BackColor = Color.WhiteSmoke
                bt.Font = ft
                bt.Dock = DockStyle.Top
                bt.Height = 14

                '  bt.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224)
                bt.ImageAlign = ContentAlignment.MiddleRight
                bt.TextAlign = ContentAlignment.MiddleLeft


                AddHandler bt.Click, AddressOf Button4_Click
                AddHandler bt.LostFocus, AddressOf Button4_LostFocus
                Me.Controls.Add(bt)
            Next

        End Set
    End Property


    Private Sub PopUpMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Controls(0).Focus()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        key = sender.tag
        value = sender.text

        RaiseEvent MenuElementSelected(Me)
    End Sub

    Private Sub Button4_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
        For Each b As Label In Me.Controls
            If b.Focused Then Exit Sub
        Next

        RaiseEvent MenuLostFocus(Me)
    End Sub

End Class
