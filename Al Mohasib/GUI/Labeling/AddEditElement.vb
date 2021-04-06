Imports System.IO

Public Class AddEditElement


    Dim _tabProp As LbElement
    Dim _points As String

    Private Property Align As Integer
        Get
            Dim t = 0
            If CbAlign.Text = "Droite" Then t = 2
            If CbAlign.Text = "Centre" Then t = 1

            Return t
        End Get
        Set(ByVal value As Integer)

            If value = 2 Then
                CbAlign.Text = "Droite"
            ElseIf value = 1 Then
                CbAlign.Text = "Centre"
            Else
                CbAlign.Text = "Gauche"
            End If
        End Set
    End Property

    Public Property Prop As LbElement
        Get

            _tabProp.designation = txt.text
            _tabProp.field = CB.Text
            _tabProp.width = W.text
            _tabProp.height = H.text
            _tabProp.x = X.text
            _tabProp.y = Y.text
            _tabProp.fSize = T.text
            _tabProp.fName = txtF1.text
            _tabProp.isBold = CheckBox1.Checked
            _tabProp.backColor = btColor.BackColor.ToArgb
            _tabProp.forColor = btForColor.BackColor.ToArgb
            _tabProp.isVertical = cbIsV.Checked

            _tabProp.hasBloc = cbBloc.Checked
            _tabProp.Alignement = Align
            _tabProp.points = _points

            Return _tabProp
        End Get
        Set(ByVal value As LbElement)
            _tabProp = value
            If IsNothing(value) Then Exit Property

            txt.text = value.designation
            CB.Text = value.field

            W.text = value.width
            H.text = value.height
            X.text = value.x
            Y.text = value.y
            T.text = value.fSize
            txtF1.text = value.fName
            CheckBox1.Checked = value.isBold
            btColor.BackColor = Color.FromArgb(value.backColor)
            btForColor.BackColor = Color.FromArgb(value.forColor)
            Align = value.Alignement

            cbIsV.Checked = value.isVertical

            cbBloc.Checked = value.hasBloc
            _points = value.points
        End Set
    End Property

    Private _editMode As Boolean = False
    Public Property EditMode() As Boolean
        Get
            Return _editMode
        End Get
        Set(ByVal value As Boolean)
            _editMode = value
            Button2.Visible = value
        End Set
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Prop = New LbElement
    End Sub

    Private Sub AddEditElement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dir1 As New DirectoryInfo(Form1.ImgPah & "\EtqDsn")
        If dir1.Exists = False Then dir1.Create()

        Dim aryFi As IO.FileInfo() = dir1.GetFiles("*.dat")
        Dim fi As IO.FileInfo

        For Each fi In aryFi
            cbEtqs.Items.Add(fi.Name)
        Next

        If CB.Text.StartsWith("**") Then
            Me.Width = 800
            cbEtqs.Text = txt.text
        Else
            Me.Width = 430
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Prop.isDeleted = True
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btColor.Click
        Dim cr As New ColorDialog
        If cr.ShowDialog = DialogResult.OK Then
            btColor.BackColor = cr.Color
            _tabProp.backColor = cr.Color.ToArgb
        End If
    End Sub

    Private Sub btForColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btForColor.Click
        Dim cr As New ColorDialog
        If cr.ShowDialog = DialogResult.OK Then
            btForColor.BackColor = cr.Color
            _tabProp.forColor = cr.Color.ToArgb
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If CB.Text = "" Then Exit Sub

        If CB.Text.StartsWith("**") Then txt.text = cbEtqs.Text


        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim fntdlg As New FontDialog
            If fntdlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            txtF1.text = fntdlg.Font.Name
            T.text = CInt(fntdlg.Font.Size)


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        txt.text = "R"


    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        txt.text = "G"
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        txt.text = "C"
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        txt.text = "S"

        Dim st As New ShapeTrace
        st.Data = _points
        st.PB.Width = W.text
        st.PB.Height = H.text

        If st.ShowDialog = Windows.Forms.DialogResult.OK Then
            _points = st.Data
        End If
    End Sub

    Private Sub CB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB.SelectedIndexChanged
        Panel1.Visible = (CB.Text = "FORME")

        btImage.Visible = (CB.Text = "IMAGE_PATH")

        If CB.Text.StartsWith("**") Then
            Me.Width = 800
        Else
            Me.Width = 430
        End If

    End Sub

    Private Sub cbEtqs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbEtqs.SelectedIndexChanged
        Dim g As New LbGlobalElement

        Try
            g = ReadFromXmlFile(Of LbGlobalElement)(Form1.ImgPah & "\EtqDsn\" & cbEtqs.Text)

            Dim BMP As New Bitmap(g.W_Page, g.h_Page, Imaging.PixelFormat.Format24bppRgb)

            ' create the graphics object
            Dim GR As Graphics = Graphics.FromImage(BMP)

            ' fill the image with color white
            GR.Clear(Color.White)

            Dim _x As Integer = 0
            Dim _y As Integer = g.Start_Y


            For i As Integer = 0 To g.Nbr_H - 1
                _x = g.Start_X
                If i > 0 Then _y += g.Sp_H
                For t As Integer = 0 To g.Nbr_W - 1
                    GR.DrawImage(DrawBl(Data, g), _x, _y)
                    _x += g.W_El
                    _x += g.Sp_W
                Next
                _y += g.H_El
            Next

            Pb.BackgroundImage = BMP
        Catch ex As Exception
        End Try
    End Sub
    Public Function DrawBl(ByVal data As DataTable, ByVal gl As LbGlobalElement)
        'Create a font   

        Dim pen As New Pen(Brushes.Black, 1.0F)

        Dim sf As New StringFormat()

        Dim _Bmp As Bitmap

        Dim params_tva As New Dictionary(Of Double, Double)

        'Create a new bitmap
        Using Bmp As New Bitmap(gl.W_El, gl.H_El, Imaging.PixelFormat.Format24bppRgb)
            'Set the resolution to 300 DPI

            'Create a graphics object from the bitmap
            Using G As Graphics = Graphics.FromImage(Bmp)
                'Paint the canvas white
                G.Clear(Color.White)
                'Set various modes to higher quality

                G.DrawRectangle(Pens.Red, 0, 0, gl.W_El - 1, gl.H_El - 1)


                For Each a As LbElement In gl.elements
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

                    If a.field.StartsWith("*") Then


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

                    ElseIf a.field.StartsWith("image") Then
                        Try
                            str = ""
                            Dim fullPath As String = Path.Combine("C:\cmcimage", a.designation)
                            G.DrawImage(Image.FromFile(fullPath), top_x, top_y, a.width, a.height)
                        Catch ex As Exception
                        End Try
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
    Private alphabet39 As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%*"
    Private coded39Char As String() = {"000110100", "100100001", "001100001", "101100000", "000110001", "100110000", "001110000", "000100101", "100100100", "001100100", "100001001", "001001001", "101001000", "000011001", "100011000", "001011000", "000001101", "100001100", "001001100", "000011100", "100000011", "001000011", "101000010", "000010011", "100010010", "001010010", "000000111", "100000110", "001000110", "000010110", "110000001", "011000001", "111000000", "010010001", "110010000", "011010000", "010000101", "110000100", "011000100", "010101000", "010100010", "010001010", "000101010", "010010100"}

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImage.Click
        Try
            Dim OPF As New OpenFileDialog
            If OPF.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim fi As New IO.FileInfo(OPF.FileName)
                txt.text = fi.FullName
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class