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
            img = value.Item("img").ToString

            If Form1.cbImgPrice.Checked Then
                lbP.Text = CDbl(value.Item("sprice")).ToString(Form1.frmDbl)
                lbP.Visible = True
            End If

            'Try
            '    Dim arrImage() As Byte
            '    arrImage = value.Item("img")
            '    Dim mstream As New System.IO.MemoryStream(arrImage)
            '    Me.BackgroundImage = Image.FromStream(mstream)
            'Catch ex As Exception
            '    Me.BackgroundImage = Nothing
            'End Try

            'plB.Height = lb.PreferredHeight

        End Set
    End Property
    Public Property img As String
        Get
            Return ""
        End Get
        Set(ByVal value As String)
            Try
                If value = "No Image" Or value = "" Then Exit Property

                Dim str As String = Form1.BtImgPah.Tag & "\art" & value

                Dim mypic As New System.IO.FileStream(str, IO.FileMode.Open)
                Dim _img As Image = Image.FromStream(mypic)
                mypic.Close()
                PL.BackgroundImage = _img

            Catch ex As Exception
            End Try
        End Set
    End Property
    Public Property fnt As Font
        Get
            Return lb.Font
        End Get
        Set(ByVal value As Font)
            lb.Font = value
            scaleFont(lb)
        End Set
    End Property

    Private Sub scaleFont(ByVal lab As Label)
        Dim fakeImage As Image = New Bitmap(1, 1)
        Dim g As Graphics = Graphics.FromImage(fakeImage)
        Dim size As SizeF = g.MeasureString(lab.Text, lab.Font, lab.Width)
        If PL.Height < size.Height Then PL.Height = size.Height
    End Sub


    Private Sub lb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click, lb.Click, PL.Click, plB.Click
        Dim bt As New Button
        bt.Tag = DataSource
        RaiseEvent Choosed(bt, e)
    End Sub





End Class
