Imports System.Drawing.Printing
Imports System.IO

Public Class bForm
    Public str_Path As String = ""
    Public TopFieldDic As New List(Of bTopField)

    Private _W_Page As Integer = 1200
    Private _h_Page As Integer = 600

    Public localname As String = "Default.dat"

    Dim p_name As String = "A4"
    Dim p_Kind As PaperKind = PaperKind.A4
    Dim Wd As Integer = 820
    Dim Ht As Integer = 1160



    Dim allowDraw As Boolean = True
    Dim p1 As Point = New Point(0, 0)
    Dim p2 As Point = New Point(0, 0)
    Dim _isLandscape As Boolean

    Public Property W_Page As Integer
        Get
            Try
                Return CInt(Txt_W.text) * 40
            Catch ex As Exception
                Return 1
            End Try
        End Get
        Set(ByVal value As Integer)
            Txt_W.text = CInt(value / 40)

            SetPadding()
        End Set
    End Property
    Public Property H_Page As Integer
        Get
            Try
                Return CInt(Txt_H.text) * 40
            Catch ex As Exception
                Return 1
            End Try
        End Get
        Set(ByVal value As Integer)
            Txt_H.text = CInt(value / 40)

            SetPadding()
        End Set
    End Property
    Public Property is_LandScape() As Boolean
        Get
            Return _isLandscape
        End Get
        Set(ByVal value As Boolean)
            _isLandscape = value
            btLand.Visible = Not value

            lbPage.Text = p_name & " (" & Wd & " x " & Ht & ")"
            If value Then lbPage.Text &= " *Paysage"
        End Set
    End Property
   
    Public ReadOnly Property Data_imp_Source As DataTable
        Get
            Dim data As New DataTable
            ' Create four typed columns in the DataTable.
            data.Columns.Add("*", GetType(String))
            data.Columns.Add("Nom", GetType(String))
            data.Columns.Add("Date", GetType(String))
            data.Columns.Add("Montant", GetType(String))
            data.Columns.Add("En_Chiffre", GetType(String))

            Dim str_mnt_chfr As String = ""
            Try
                Dim nPart As Decimal = 0
                Dim zPart As Decimal = 0

                SplitDecimal(CDec(100), nPart, zPart)
                Dim stt As String = ChLettre.NBLT(nPart) & " Dirhams  "
                If zPart > 0 Then
                    stt &= "et " & ChLettre.NBLT(CInt(zPart * 100)) & " (Cts)"
                End If
                'Dim strTotal As String = "Arrêté la présente facture à la somme : " & stt
                str_mnt_chfr = stt.Substring(0, 2).ToUpper() + stt.Substring(2)
            Catch ex As Exception

            End Try
            data.Rows.Add(" ", "Mohamed Ali", Now.Date.ToString("dd/MM/yyyy"), "100.00", str_mnt_chfr)
            Return data
        End Get
    End Property

    Private Sub bForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Txt_H.text.Trim = "" Then H_Page = 1160
        If Txt_W.text.Trim = "" Then W_Page = 680
        SetPadding()
    End Sub

    Public Sub SetPadding()

        Try
            Dim w = plCh.Width - W_Page
            w -= 40
            If w < 0 Then w = 0
            Dim h = plCh.Height - H_Page
            h -= 40
            If h < 0 Then h = 0

            plCh.Padding = New Padding(40, h, w, 40)
        Catch ex As Exception

        End Try
    End Sub
    Public Function DrawBl(ByVal data As DataTable, ByVal hightQ As Boolean, ByRef m As Integer)
        'Create a font   


        
        Dim y As Integer = 20
        Dim h As Integer = 20
        Dim pen As New Pen(Brushes.Black, 1.0F)

        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Near
        Dim sfc As New StringFormat()
        sfc.Alignment = StringAlignment.Center
        Dim sfl As New StringFormat()
        sfl.Alignment = StringAlignment.Far

        Dim _Bmp As Bitmap


        Dim _w = W_Page
        Dim _h = H_Page



        Dim params_tva As New Dictionary(Of Double, Double)

        'Create a new bitmap
        Using Bmp As New Bitmap(_w, _h, Imaging.PixelFormat.Format24bppRgb)
            'Set the resolution to 300 DPI
            If hightQ Then Bmp.SetResolution(300, 300)
            'Create a graphics object from the bitmap
            Using G As Graphics = Graphics.FromImage(Bmp)
                'Paint the canvas white
                G.Clear(Color.White)
                'Set various modes to higher quality
                If hightQ Then
                    G.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                    G.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    G.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
                    '  h = F.Height + 40
                End If

              
                Using B As New SolidBrush(Color.Black)
                    For Each a As bTopField In TopFieldDic
                       
                        'Create a brush
                        Dim top_x = a.x
                        Dim top_y = a.y

                        Dim fn As Font
                        If a.isBold Then
                            fn = New Font(a.fName, a.fSize, FontStyle.Bold)
                        Else
                            fn = New Font(a.fName, a.fSize)
                        End If
 
                            If a.hasBloc Then
                                'g.DrawRectangle(pen, a.x, a.y, a.width, a.height)
                                Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                                G.FillRectangle(_br, a.x, a.y, a.width, a.height)

                                top_x += 5
                                top_y += 3
                            End If

                        If a.field.ToUpper.StartsWith("FOR") Then

                            Dim ls = a.points.Split("|")

                            Dim myPoints(ls.Length - 1) As Point
                            For n As Integer = 0 To ls.Length - 1
                                Try
                                    myPoints(n) = New Point(ls(n).Split("*")(0), ls(n).Split("*")(1))
                                Catch ex As Exception
                                End Try
                            Next
                            Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                            G.FillPolygon(_br, myPoints)

                        Else
                            sf.Alignment = a.Alignement
                            Dim str As String = data.Rows(0).Item(a.field)
                            str = a.str_start & str & a.str_end
                            G.DrawString(str, fn, B, New RectangleF(top_x, top_y, a.width, a.height), sf)

                            top_x -= 5
                            top_y -= 3
                            G.DrawRectangle(New Pen(Brushes.Azure, 3), a.x, a.y, a.width, a.height)
                            top_x += 5
                            top_y += 3
                        End If


                    Next
                End Using

                _Bmp = DirectCast(Bmp.Clone(), Image)
            End Using
        End Using
        m = 0
        Return _Bmp
    End Function
    Dim m = 0
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        pb.BackgroundImage = DrawBl(Data_imp_Source, False, m)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim g As New bGlobClass

        g.TopFieldDic = TopFieldDic
        g.W_Page = W_Page
        g.h_Page = H_Page

        g.localName = localname
        g.P_name = p_name
        g.p_Kind = p_Kind
        g.Wd = Wd
        g.Ht = Ht
        g.is_Landscape = is_Landscape

        WriteToXmlFile(Of bGlobClass)(str_Path & "\bqu\" & localname, g)
    End Sub
    Public Sub LoadXml()
        Dim g As New bGlobClass
        Try

            g = ReadFromXmlFile(Of bGlobClass)(str_Path & "\bqu\" & localname)

            TopFieldDic = g.TopFieldDic
            W_Page = g.W_Page
            H_Page = g.h_Page

            p_name = g.P_name
            p_Kind = g.p_Kind
            Wd = g.Wd
            Ht = g.Ht
            is_Landscape = g.is_Landscape

            For Each ff As bTopField In TopFieldDic
                Dim bt As New Button
                bt.Text = ff.str_start & ff.field & ff.str_end
                bt.Tag = ff
                bt.FlatStyle = FlatStyle.Flat

                Dim fn As Font
                If ff.isBold Then
                    fn = New Font("Arial", ff.fSize, FontStyle.Bold)
                Else
                    fn = New Font("Arial", ff.fSize)
                End If

                bt.Font = fn

                AddHandler bt.Click, AddressOf btTop_Clicked
                PT.Controls.Add(bt)
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub PT_DoubleClick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PT.DoubleClick
        Dim ff As New AddEditBanqueField
        If ff.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim bt As New Button
            bt.Text = ff.Prop.str_start & ff.Prop.field & ff.Prop.str_end
            bt.Tag = ff.Prop
            bt.FlatStyle = FlatStyle.Flat
            bt.AutoSize = True

            Dim fn As Font
            If ff.Prop.isBold Then
                fn = New Font("Arial", ff.Prop.fSize, FontStyle.Bold)
            Else
                fn = New Font("Arial", ff.Prop.fSize)
            End If

            bt.Font = fn

            AddHandler bt.Click, AddressOf btTop_Clicked
            PT.Controls.Add(bt)
            TopFieldDic.Add(ff.Prop)

            pb.BackgroundImage = DrawBl(Data_imp_Source, False, m)
        End If
    End Sub

    Private Sub pb_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pb.MouseDown
        p1 = e.Location
    End Sub

    Private Sub pb_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pb.MouseUp
        If p1.X = 0 Then Exit Sub
        p2 = e.Location

        If Math.Abs(p1.X - p2.X) < 10 And Math.Abs(p1.Y - p2.Y) < 10 Then Exit Sub

        Dim _tabProp As New bTopField
        _tabProp.str_start = ""
        _tabProp.str_end = ""
        _tabProp.field = "*"
        _tabProp.width = IIf(p1.X > p2.X, p1.X - p2.X, p2.X - p1.X)
        _tabProp.height = IIf(p1.Y > p2.Y, p1.Y - p2.Y, p2.Y - p1.Y)
        _tabProp.x = IIf(p1.X > p2.X, p2.X, p1.X)
        _tabProp.y = IIf(p1.Y > p2.Y, p2.Y, p1.Y)
        _tabProp.fSize = 9
        _tabProp.isBold = False
        _tabProp.backColor = Color.Gray.ToArgb
        _tabProp.hasBloc = True

        Dim bt As New Button
        bt.Text = "   *   "
        bt.AutoSize = True
        bt.Tag = _tabProp
        bt.FlatStyle = FlatStyle.Flat

        Dim fn As Font
        fn = New Font("Arial", 9)

        bt.Font = fn

        AddHandler bt.Click, AddressOf btTop_Clicked
        PT.Controls.Add(bt)
        TopFieldDic.Add(_tabProp)

        pb.BackgroundImage = DrawBl(Data_imp_Source, False, m)

        _tabProp.hasBloc = False

        If p1.Y * 2 > H_Page Then
            btTop_Clicked(bt, Nothing)
        Else
            btTop_Clicked(bt, Nothing)
        End If
    End Sub
    Private Sub btTop_Clicked(ByVal sender As Object, ByVal e As EventArgs)
        Dim ff As New AddEditBanqueField
        Dim bt As Button = sender
        ff.EditMode = True
        ff.Prop = bt.Tag
        If ff.ShowDialog = Windows.Forms.DialogResult.OK Then
            If ff.Prop.isDeleted Then
                TopFieldDic.Remove(bt.Tag)
                PT.Controls.Remove(bt)
                Exit Sub
            End If


            bt.Text = ff.Prop.str_start & ff.Prop.field & ff.Prop.str_end
            bt.Tag = ff.Prop

            Dim fn As Font
            If ff.Prop.isBold Then
                fn = New Font("Arial", ff.Prop.fSize, FontStyle.Bold)
            Else
                fn = New Font("Arial", ff.Prop.fSize)
            End If

            bt.Font = fn

            TopFieldDic.Clear()
            For Each b As Button In PT.Controls
                TopFieldDic.Add(b.Tag)
            Next

            pb.BackgroundImage = DrawBl(Data_imp_Source, False, m)
        End If
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MsgBox("Vous ete sure de supprimercet item? ", MsgBoxStyle.YesNo, "Supression") = MsgBoxResult.Yes Then
            Try
                Dim strpath As String = str_Path & "\bqu"
                Dim fullPath As String = Path.Combine(strpath, localname)
                File.Delete(fullPath)

                Me.DialogResult = Windows.Forms.DialogResult.OK
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Txt_W_TxtChanged_1() Handles Txt_W.TxtChanged, Txt_H.TxtChanged
        SetPadding()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim doc As New PrintDocument
        Dim ps As New PageSetupDialog
        With ps
            .Document = doc
            .ShowDialog(Me)
        End With
        Dim str As String = ""

        str &= "oriontation " &
            IIf(doc.DefaultPageSettings.Landscape, "Payessage", "portrait") & vbNewLine
        str &= "Format " & doc.DefaultPageSettings.PaperSize.ToString
        MsgBox(str)

        Wd = doc.DefaultPageSettings.PaperSize.Width
        Ht = doc.DefaultPageSettings.PaperSize.Height

        p_name = doc.DefaultPageSettings.PaperSize.PaperName
        p_Kind = doc.DefaultPageSettings.PaperSize.Kind
        is_LandScape = doc.DefaultPageSettings.Landscape

    End Sub
End Class