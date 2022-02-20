﻿Public Class PvCat

    Dim _data As DataTable
    Dim _nxt As Boolean
    Dim _prv As Boolean

    Public Event Choosed(ByVal sender As Object, ByVal e As EventArgs)
    Public CID As Integer = 0


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub
    Public Property fnt As Font
        Get
            Return lb.Font
        End Get
        Set(ByVal value As Font)
            lb.Font = value
            scaleFont(lb)
        End Set
    End Property
    Dim _img As String
    Public Property img As String
        Get
            Return _img
        End Get
        Set(ByVal value As String)
            _img = value
           
            'Try
            '    If value = "No Image" Or value = "" Then

            '    Else
            '        Dim str As String = Form1.BtImgPah.Tag & "\cat" & value

            '        PL.BackgroundImage = Image.FromFile(str)
            '    End If
            '    PL.BackgroundImageLayout = ImageLayout.Stretch

            'Catch ex As Exception
            'End Try


            Dim str As String = Form1.BtImgPah.Tag & "\cat" & value

            Dim mypic As New System.IO.FileStream(str, IO.FileMode.Open)
            Dim _image As Image = Image.FromStream(mypic)
            mypic.Close()
            PL.BackgroundImage = _image

        End Set
    End Property
    Public Property CatName As String
        Get
            Return lb.Text
        End Get
        Set(ByVal value As String)
            lb.Text = value
        End Set
    End Property
    Public Property DataSource() As DataTable
        Get
            Return _data
        End Get
        Set(ByVal value As DataTable)
            _data = value
        End Set
    End Property
    Public Property isNext As Boolean
        Get
            Return _nxt
        End Get
        Set(ByVal value As Boolean)
            _nxt = value

            If value Then
                isPrev = False
                'plCat.Visible = False
                PL.BackgroundImage = My.Resources.catNX
            End If


        End Set
    End Property
    Public Property isPrev As Boolean
        Get
            Return _prv
        End Get
        Set(ByVal value As Boolean)
            _prv = value

            If value Then
                isNext = False
                'plCat.Visible = False
                PL.BackgroundImage = My.Resources.catPR
            End If

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

        If isNext = True Or isPrev = True Then
            bt.Tag = DataSource
            RaiseEvent Choosed(bt, e)
        Else
            bt.Tag = CID
            RaiseEvent Choosed(bt, e)
        End If

    End Sub

End Class