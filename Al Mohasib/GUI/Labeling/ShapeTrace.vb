Public Class ShapeTrace


    Public Property Data As String
        Get
            Dim str = ""

            For Each el As ShapeElement In pl.Controls
                If str <> "" Then str &= "|"
                str &= el.Data
            Next
            Return str
        End Get
        Set(ByVal value As String)

            Try
                Dim str = value.Split("|")

                For i As Integer = 0 To str.Length - 1
                    Dim el As New ShapeElement
                    el.Data = str(i)
                    pl.Controls.Add(el)
                    el.Dock = DockStyle.Top
                    AddHandler el.ValueChanged, AddressOf ValueChanged
                    AddHandler el.DeleteMe, AddressOf DeleteMe

                Next

            Catch ex As Exception

            End Try

        End Set
    End Property

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim el As New ShapeElement
        el.Data = "0*0"
        pl.Controls.Add(el)
        el.Dock = DockStyle.Top

        AddHandler el.ValueChanged, AddressOf ValueChanged
        AddHandler el.DeleteMe, AddressOf DeleteMe

    End Sub
    Public Function DrawBl()
        'Create a font   

        Dim pen As New Pen(Brushes.Black, 1.0F)

        Dim sf As New StringFormat()

        Dim _Bmp As Bitmap

        Dim params_tva As New Dictionary(Of Double, Double)

        'Create a new bitmap
        Using Bmp As New Bitmap(PB.Width, PB.Height, Imaging.PixelFormat.Format24bppRgb)
            'Set the resolution to 300 DPI
            Using G As Graphics = Graphics.FromImage(Bmp)
                'Paint the canvas white
                G.Clear(Color.White)

                Dim ls = data.Split("|")

                Dim myPoints(ls.Length - 1) As Point
                For n As Integer = 0 To ls.Length - 1
                    Try
                        myPoints(n) = New Point(ls(n).Split("*")(0), ls(n).Split("*")(1))
                    Catch ex As Exception

                    End Try

                Next
                G.FillPolygon(Brushes.Red, myPoints)
                _Bmp = DirectCast(Bmp.Clone(), Image)
            End Using
        End Using

        Return _Bmp
    End Function

    Private Sub ValueChanged()
        PB.Image = DrawBl()
    End Sub

    Private Sub DeleteMe(ByVal el As ShapeElement)
        pl.Controls.Remove(el)

        PB.Image = DrawBl()
    End Sub

End Class