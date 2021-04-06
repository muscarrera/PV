Imports System.Drawing.Printing
Imports System.IO

Public Class LbSetting

    Public localName As String = "Default.dat"
    Public _isLandscape As Boolean = False

    Public P_name As String = "A4"
    Public Printer_name As String = "A4"
    Public p_Kind As PaperKind = PaperKind.A4
    Public is_Landscape As Boolean = False
    Public elements As New List(Of LbElement)


    Public Property isLandScape() As Boolean
        Get
            Return _isLandscape
        End Get
        Set(ByVal value As Boolean)
            _isLandscape = value
            btLand.Visible = Not value

            If isLandScape Then
                Pb.Width = H_Page
                Pb.Height = W_Page
            Else
                Pb.Width = W_Page
                Pb.Height = H_Page
            End If
        End Set
    End Property
    Public Property W_Page As Integer
        Get
            Try
                Return CInt(Txt_W.text)
            Catch ex As Exception
                Return 1
            End Try
        End Get
        Set(ByVal value As Integer)
            Txt_W.text = value
        End Set
    End Property
    Public Property H_Page As Integer
        Get
            Try
                Return CInt(Txt_H.text)
            Catch ex As Exception
                Return 1
            End Try
        End Get
        Set(ByVal value As Integer)
            Txt_H.text = value
        End Set
    End Property

    Public Property Nbr_W As Integer
        Get
            Try
                Return CInt(txtNbrW.text)
            Catch ex As Exception
                Return 1
            End Try
        End Get
        Set(ByVal value As Integer)
            txtNbrW.text = value
        End Set
    End Property
    Public Property Nbr_H As Integer
        Get
            Try
                Return CInt(txtNbrH.text)
            Catch ex As Exception
                Return 1
            End Try
        End Get
        Set(ByVal value As Integer)
            txtNbrH.text = value
        End Set
    End Property

    Public Property W_El As Integer
        Get
            Try
                Return CInt(txtWel.text)
            Catch ex As Exception
                Return 1
            End Try
        End Get
        Set(ByVal value As Integer)
            txtWel.text = value
        End Set
    End Property
    Public Property H_El As Integer
        Get
            Try
                Return CInt(txtHel.text)
            Catch ex As Exception
                Return 1
            End Try
        End Get
        Set(ByVal value As Integer)
            txtHel.text = value
        End Set
    End Property

    Public Property Sp_W As Integer
        Get
            Try
                Return CInt(txtEspW.text)
            Catch ex As Exception
                Return 1
            End Try
        End Get
        Set(ByVal value As Integer)
            txtEspW.text = value
        End Set
    End Property
    Public Property Sp_H As Integer
        Get
            Try
                Return CInt(txtEspH.text)
            Catch ex As Exception
                Return 1
            End Try
        End Get
        Set(ByVal value As Integer)
            txtEspH.text = value
        End Set
    End Property

    Public Property Start_X As Integer
        Get
            Try
                Return CInt(txtX.text)
            Catch ex As Exception
                Return 1
            End Try
        End Get
        Set(ByVal value As Integer)
            txtX.text = value
        End Set
    End Property
    Public Property Start_Y As Integer
        Get
            Try
                Return CInt(txtY.text)
            Catch ex As Exception
                Return 1
            End Try
        End Get
        Set(ByVal value As Integer)
            txtY.text = value
        End Set
    End Property

    Public ReadOnly Property Data As DataTable
        Get
            Dim table As New DataTable
            ' Create four typed columns in the DataTable.
            table.Columns.Add("Name", GetType(String))
            table.Columns.Add("Prix(G)", GetType(String))
            table.Columns.Add("Prix(P)", GetType(String))
            table.Columns.Add("Prix", GetType(String))
            table.Columns.Add("Ref", GetType(String))
            table.Columns.Add("Code", GetType(String))

            ' Add  rows with those columns filled in the DataTable.
            table.Rows.Add("Article De Test", "19", ".55", "19.55", "Reference", "12345678")
            Return table
        End Get
    End Property

    Public Sub LoadXml()
        Dim g As New LbGlobalElement
        Try
            g = ReadFromXmlFile(Of LbGlobalElement)(Form1.ImgPah & "\EtqDsn\" & localName)
            W_Page = g.W_Page
            H_Page = g.h_Page
            P_name = g.P_name
            p_Kind = g.p_Kind
            isLandScape = g.is_Landscape

            Nbr_W = g.Nbr_W
            Nbr_H = g.Nbr_H

            W_El = g.W_El
            H_El = g.H_El

            Sp_W = g.Sp_W
            Sp_H = g.Sp_H

            Start_X = g.Start_X
            Start_Y = g.Start_Y

            Printer_name = g.Printer_name
            cbR.Checked = g.is_Repeated

            elements = g.elements

            For Each ff As LbElement In elements
                Dim bt As New Button
                bt.Text = ff.field
                bt.Tag = ff
                bt.FlatStyle = FlatStyle.Flat

                Dim fn As Font
                If ff.isBold Then
                    fn = New Font(ff.fName, ff.fSize, FontStyle.Bold)
                Else
                    fn = New Font(ff.fName, ff.fSize)
                End If

                bt.Font = fn

                AddHandler bt.Click, AddressOf btTop_Clicked
                PT.Controls.Add(bt)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If DataGridView1.SelectedRows.Count = 0 Then Exit Sub
        PT.Controls.Clear()
        PbCode.BackgroundImage = Nothing

        lb.Text = DataGridView1.SelectedRows(0).Cells(0).Value.ToString
        localName = lb.Text
        LoadXml()


    End Sub

    Private Sub btTop_Clicked(ByVal sender As Object, ByVal e As EventArgs)

        Dim ff As New AddEditElement
        Dim bt As Button = sender
        ff.EditMode = True
        ff.Prop = bt.Tag
        If ff.ShowDialog = Windows.Forms.DialogResult.OK Then
            If ff.Prop.isDeleted Then
                elements.Remove(bt.Tag)
                PT.Controls.Remove(bt)
                Exit Sub
            End If


            bt.Text = ff.Prop.designation
            bt.Tag = ff.Prop

            Dim fn As Font
            If ff.Prop.isBold Then
                fn = New Font("Arial", ff.Prop.fSize, FontStyle.Bold)
            Else
                fn = New Font("Arial", ff.Prop.fSize)
            End If

            bt.Font = fn

            elements.Clear()
            For Each b As Button In PT.Controls
                elements.Add(b.Tag)
            Next

            If localName.ToUpper.StartsWith("CAT") Then
                Pb.BackgroundImage = DrawBl(Data, False)
            Else
                PbCode.BackgroundImage = DrawBl(Data, False)
            End If

        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
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

        W_Page = doc.DefaultPageSettings.PaperSize.Width
        H_Page = doc.DefaultPageSettings.PaperSize.Height
        isLandScape = doc.DefaultPageSettings.Landscape
        P_name = doc.DefaultPageSettings.PaperSize.PaperName
        p_Kind = doc.DefaultPageSettings.PaperSize.Kind
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        'pb.BackgroundImage = DrawBl(gt.TabProp, Data_imp_Source, Details_imp_Source, Client_imp_Source, False, m)
        GetApercu()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim g As New LbGlobalElement
        g.elements = elements
        g.W_Page = W_Page
        g.h_Page = H_Page
        g.localName = localName

        g.W_El = W_El
        g.H_El = H_El
        g.Nbr_W = Nbr_W
        g.Nbr_H = Nbr_H
        g.Sp_W = Sp_W
        g.Sp_H = Sp_H
        g.Start_X = Start_X
        g.Start_Y = Start_Y

        g.is_Landscape = isLandScape
        g.is_Repeated = cbR.Checked
        g.P_name = P_name
        g.p_Kind = p_Kind
        g.Printer_name = Printer_name

        WriteToXmlFile(Of LbGlobalElement)(Form1.ImgPah & "\EtqDsn\" & localName, g)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim dir1 As New DirectoryInfo(Form1.ImgPah & "\EtqDsn")
        If dir1.Exists = False Then dir1.Create()

        Dim n = InputBox("Nom de Model", "Impression", "Default")
        If n.Length < 3 Then Exit Sub
        localName = n & ".dat"

        Dim aryFi As IO.FileInfo() = dir1.GetFiles("*.dat")
        Try
            Dim fi As IO.FileInfo = aryFi(0)
            Dim nm = fi.Name
            Dim g As New LbGlobalElement
            g = ReadFromXmlFile(Of LbGlobalElement)(Form1.ImgPah & "\EtqDsn\" & nm)
            WriteToXmlFile(Of LbGlobalElement)(Form1.ImgPah & "\EtqDsn\" & localName, g)

        Catch ex As Exception
            Dim g As New LbGlobalElement

            WriteToXmlFile(Of LbGlobalElement)(Form1.ImgPah & "\EtqDsn\" & localName, g)
        End Try


        DataGridView1.Rows.Add(localName)


    End Sub

    Private Sub LbSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dir1 As New DirectoryInfo(Form1.ImgPah & "\EtqDsn")
        If dir1.Exists = False Then dir1.Create()

        Dim aryFi As IO.FileInfo() = dir1.GetFiles("*.dat")
        Dim fi As IO.FileInfo

        For Each fi In aryFi
            DataGridView1.Rows.Add(fi.Name)
        Next



    End Sub

    Private Sub btImprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImprimer.Click
        Button6_Click(Nothing, Nothing)
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ff As New AddEditElement
        If ff.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim bt As New Button
            bt.Text = ff.Prop.designation
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
            elements.Add(ff.Prop)

            If localName.ToUpper.StartsWith("CAT") Then
                Pb.BackgroundImage = DrawBl(Data, False)
            Else
                PbCode.BackgroundImage = DrawBl(Data, False)
            End If

        End If
    End Sub

    Private alphabet39 As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%*"
    Private coded39Char As String() = {"000110100", "100100001", "001100001", "101100000", "000110001", "100110000", "001110000", "000100101", "100100100", "001100100", "100001001", "001001001", "101001000", "000011001", "100011000", "001011000", "000001101", "100001100", "001001100", "000011100", "100000011", "001000011", "101000010", "000010011", "100010010", "001010010", "000000111", "100000110", "001000110", "000010110", "110000001", "011000001", "111000000", "010010001", "110010000", "011010000", "010000101", "110000100", "011000100", "010101000", "010100010", "010001010", "000101010", "010010100"}

    Public Function DrawBl(ByVal data As DataTable, ByVal hightQ As Boolean)
        'Create a font   

        Dim pen As New Pen(Brushes.Black, 1.0F)

        Dim sf As New StringFormat()

        Dim _Bmp As Bitmap

        Dim params_tva As New Dictionary(Of Double, Double)

        'Create a new bitmap
        Using Bmp As New Bitmap(W_El, H_El, Imaging.PixelFormat.Format24bppRgb)
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
                End If

                G.DrawRectangle(Pens.Red, 0, 0, W_El - 1, H_El - 1)


                For Each a As LbElement In elements
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
                        G.DrawRectangle(pen, a.x, a.y, a.width, a.height)
                        Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                        G.FillRectangle(_br, a.x, a.y, a.width, a.height)

                        top_x += 5
                        top_y += 3
                    End If

                    Dim str As String = CStr(a.designation)

                    If a.field = "*" Then

                    ElseIf a.field = "IMAGE_PATH" Then
                        Try
                            str = ""
                            Dim fullPath As String = a.designation
                            G.DrawImage(Image.FromFile(fullPath), top_x, top_y, a.width, a.height)
                        Catch ex As Exception
                        End Try
                    ElseIf a.field = "IMAGE_PATH" Then
                        Try
                            str = ""
                            Dim fullPath As String = a.designation
                            G.DrawImage(Image.FromFile(fullPath), top_x, top_y, a.width, a.height)
                        Catch ex As Exception
                        End Try

                    ElseIf a.field = "Image_Article" Then
                        Try
                            str = ""
                            G.DrawImage(Image.FromFile(data.Rows(0).Item(a.field)), top_x, top_y, a.width, a.height)
                        Catch ex As Exception
                        End Try
                    ElseIf a.field.StartsWith("**") Then
                        str = ""
                        ' DrawEtqs(data, a.designation, G)
                        drawBloc(G, a.designation)
                    ElseIf a.field.StartsWith("FOR") Then

                        If str = "R" Then

                            Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                            G.FillRectangle(_br, a.x, a.y, a.width, a.height)

                        ElseIf str = "G" Then
                            DrawRoundedRectangle(G, a.x, a.y, a.width, a.height, a.fSize)
                        ElseIf str = "C" Then
                            Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                            G.FillEllipse(_br, a.x, a.y, a.width, a.height)
                        ElseIf str = "S" Then

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
                        End If

                        str = ""

                        'ElseIf a.field.StartsWith("image") Then
                        '    Try
                        '        str = ""
                        '        Dim fullPath As String = Path.Combine("C:\cmcimage", a.designation)
                        '        G.DrawImage(Image.FromFile(fullPath), top_x, top_y, a.width, a.height)
                        '    Catch ex As Exception
                        '    End Try
                    ElseIf a.field.StartsWith("//") Then
                        Dim code = data.Rows(0).Item("Code").ToUpper()
                        Dim _str As String = "*"c & code & "*"c
                        Dim strLength As Integer = _str.Length
                        Dim intercharacterGap As String = "0"

                        For i As Integer = 0 To code.Length - 1

                            If alphabet39.IndexOf(code(i)) = -1 OrElse code(i) = "*"c Then
                                G.DrawString("INVALID BAR CODE TEXT", Font, Brushes.Red, 10, 10)

                            End If
                        Next

                        Dim encodedString As String = ""

                        For i As Integer = 0 To strLength - 1
                            If i > 0 Then encodedString += intercharacterGap
                            encodedString += coded39Char(alphabet39.IndexOf(_str(i)))
                        Next

                        Dim encodedStringLength As Integer = encodedString.Length
                        Dim widthOfBarCodeString As Integer = 0
                        Dim wideToNarrowRatio As Double = 3

                        If a.Alignement <> 1 Then

                            For i As Integer = 0 To encodedStringLength - 1

                                If encodedString(i) = "1"c Then
                                    widthOfBarCodeString += CInt((wideToNarrowRatio))
                                Else
                                    widthOfBarCodeString += 1
                                End If
                            Next
                        End If


                        Dim wid As Integer = 0
                        For i As Integer = 0 To encodedStringLength - 1

                            If encodedString(i) = "1"c Then
                                wid = CInt((wideToNarrowRatio))
                            Else
                                wid = 1
                            End If

                            Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                            G.FillRectangle(If(i Mod 2 = 0, _br, Brushes.White), top_x, top_y, wid, a.height)
                            top_x += wid
                        Next
                    Else

                        str &= data.Rows(0).Item(a.field)
                    End If
                    Dim br = New SolidBrush(Color.FromArgb(a.forColor))
                    sf.Alignment = a.Alignement
                    If a.isVertical Then
                        sf.FormatFlags = StringFormatFlags.DirectionVertical
                    Else
                        sf.FormatFlags = StringFormatFlags.DisplayFormatControl
                    End If

                    G.DrawString(str, fn, br, New RectangleF(top_x, top_y, a.width, a.height), sf)
                Next

                '////////////////////////////////////////////////////////////////////////

                _Bmp = DirectCast(Bmp.Clone(), Image)
            End Using
        End Using

        Return _Bmp
    End Function
    Public Sub DrawEtqs(ByVal data As DataTable, ByRef G As Graphics, ByRef gl As LbGlobalElement, ByRef xx As Integer, ByRef yy As Integer)
        'Create a font   
        '        g.RotateTransform(45f);
        'g.DrawString("My String"...);
        'g.RotateTransform(-45f);


        Dim pen As New Pen(Brushes.Black, 1.0F)
        Dim sf As New StringFormat()
        Dim params_tva As New Dictionary(Of Double, Double)
        G.DrawRectangle(Pens.Red, 0, 0, W_El - 1, H_El - 1)

        For Each a As LbElement In gl.elements
            'Create a brush
            Dim top_x = a.x + xx
            Dim top_y = a.y + yy

            Dim fn As Font
            If a.isBold Then
                fn = New Font(a.fName, a.fSize, FontStyle.Bold)
            Else
                fn = New Font(a.fName, a.fSize)
            End If

            If a.hasBloc Then
                G.DrawRectangle(pen, top_x, top_y, a.width, a.height)
                Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                G.FillRectangle(_br, top_x, top_y, a.width, a.height)

                top_x += 5
                top_y += 3
            End If


            Dim str As String = CStr(a.designation)

            If a.field = "*" Then

            ElseIf a.field = "IMAGE_PATH" Then
                Try
                    str = ""
                    Dim fullPath As String = a.designation
                    G.DrawImage(Image.FromFile(fullPath), top_x, top_y, a.width, a.height)
                Catch ex As Exception
                End Try

            ElseIf a.field = "Image_Article" Then
                Try
                    str = ""
                    G.DrawImage(Image.FromFile(data.Rows(0).Item("img")), top_x, top_y, a.width, a.height)
                Catch ex As Exception
                End Try
            ElseIf a.field.StartsWith("**") Then
                str = ""
                drawBloc(G, a.designation)
            ElseIf a.field.StartsWith("FOR") Then

                If str = "R" Then

                    Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                    G.FillRectangle(_br, top_x, top_y, a.width, a.height)

                ElseIf str = "G" Then
                    DrawRoundedRectangle(G, top_x, top_y, a.width, a.height, a.fSize)
                ElseIf str = "C" Then
                    Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                    G.FillEllipse(_br, top_x, top_y, a.width, a.height)
                ElseIf str = "S" Then

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
                End If

                str = ""

            ElseIf a.field.StartsWith("//") Then
                DrawBarCode39(G, a, top_x, top_y)
            Else

                str &= data.Rows(0).Item(a.field)
            End If
            Dim br = New SolidBrush(Color.FromArgb(a.forColor))
            sf.Alignment = a.Alignement
            If a.isVertical Then
                sf.FormatFlags = StringFormatFlags.DirectionVertical
            Else
                sf.FormatFlags = StringFormatFlags.DisplayFormatControl
            End If

            G.DrawString(str, fn, br, New RectangleF(top_x, top_y, a.width, a.height), sf)
        Next

        '////////////////////////////////////////////////////////////////////////
    End Sub
    Private Sub DrawBarCode39(ByVal g As Graphics, ByVal a As LbElement, ByRef top_x As Integer, ByRef top_y As Integer)
        Dim code = Data.Rows(0).Item("Code").ToUpper()
        Dim _str As String = "*"c & code & "*"c
        Dim strLength As Integer = _str.Length
        Dim intercharacterGap As String = "0"

        For i As Integer = 0 To code.Length - 1

            If alphabet39.IndexOf(code(i)) = -1 OrElse code(i) = "*"c Then
                g.DrawString("INVALID BAR CODE TEXT", Font, Brushes.Red, 10, 10)

            End If
        Next

        Dim encodedString As String = ""

        For i As Integer = 0 To strLength - 1
            If i > 0 Then encodedString += intercharacterGap
            encodedString += coded39Char(alphabet39.IndexOf(_str(i)))
        Next

        Dim encodedStringLength As Integer = encodedString.Length
        Dim widthOfBarCodeString As Integer = 0
        Dim wideToNarrowRatio As Double = 3

        If a.Alignement <> 1 Then

            For i As Integer = 0 To encodedStringLength - 1

                If encodedString(i) = "1"c Then
                    widthOfBarCodeString += CInt((wideToNarrowRatio))
                Else
                    widthOfBarCodeString += 1
                End If
            Next
        End If


        Dim wid As Integer = 0
        For i As Integer = 0 To encodedStringLength - 1

            If encodedString(i) = "1"c Then
                wid = CInt((wideToNarrowRatio))
            Else
                wid = 1
            End If

            Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
            g.FillRectangle(If(i Mod 2 = 0, _br, Brushes.White), top_x, top_y, wid, a.height)
            top_x += wid
        Next
    End Sub
    Private Sub drawBloc(ByVal gr As Graphics, ByVal nm As String)
        If nm = "" Then Exit Sub

        Dim gl As New LbGlobalElement
        Try
            gl = ReadFromXmlFile(Of LbGlobalElement)(Form1.ImgPah & "\EtqDsn\" & nm)
        Catch ex As Exception
            Exit Sub
        End Try

        Dim _x As Integer = 0
        Dim _y As Integer = gl.Start_Y


        For i As Integer = 0 To gl.Nbr_H - 1
            _x = gl.Start_X
            If i > 0 Then _y += gl.Sp_H
            For t As Integer = 0 To gl.Nbr_W - 1
                DrawEtqs(Data, gr, gl, _x, _y)
                _x += gl.W_El  ' PbCode.BackgroundImage.Width
                _x += gl.Sp_W
            Next
            _y += gl.H_El  'PbCode.BackgroundImage.Height
        Next
    End Sub

    Private Sub GetApercu()

        Dim BMP As New Bitmap(Pb.Width, Pb.Height, Imaging.PixelFormat.Format24bppRgb)

        ' create the graphics object
        Dim GR As Graphics = Graphics.FromImage(BMP)

        ' fill the image with color white
        GR.Clear(Color.White)

        Dim _x As Integer = 0
        Dim _y As Integer = Start_Y


        For i As Integer = 0 To Nbr_H - 1
            _x = Start_X
            If i > 0 Then _y += Sp_H
            For t As Integer = 0 To Nbr_W - 1
                GR.DrawImage(PbCode.BackgroundImage, _x, _y)
                '   DrawBl(Data, False)
                _x += PbCode.BackgroundImage.Width
                _x += Sp_W
            Next
            _y += PbCode.BackgroundImage.Height
        Next

        Pb.BackgroundImage = BMP
    End Sub
    
    Private Sub txtHel_TxtChanged() Handles txtY.TxtChanged, txtX.TxtChanged, txtWel.TxtChanged, txtNbrW.TxtChanged, txtNbrH.TxtChanged, txtHel.TxtChanged, txtEspW.TxtChanged, txtEspH.TxtChanged
        If localName.ToUpper.StartsWith("CAT") Then
            Pb.BackgroundImage = DrawBl(Data, False)
        Else
            PbCode.BackgroundImage = DrawBl(Data, False)
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If Form1.PrintDlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Try
            Printer_name = Form1.PrintDlg.PrinterSettings.PrinterName
            'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "prt2", PRINTER)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
End Class