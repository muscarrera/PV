Imports System.IO

Public Class LabelPrinter

    Public sf As New StringFormat()
    Public sf1 As New StringFormat()
    Public sf2 As New StringFormat()
    Private txtX, txtY, TXTW, TXTH, TxtBox1, TxtBox2, TxtBox3, TxtBox4, TxtBox5, TxtBox6, txtZ1, txtZ2 As Integer
    Private PRINTER, txtF1, txtF2 As String
    Private isRayounage As Boolean
    Private br As Brush = Brushes.Black

    Private gl As New LbGlobalElement
    Private ct As New CatElement

    Private table As New DataTable
    Private TOTAL_NUM_TRIAL As Integer = 1
    Private Sub TrialNumb()

        Dim value As Integer = 1
        value = getRegistryinfo("Labeling_Trial_Use", 1)

        TOTAL_NUM_TRIAL = value

        If value = 0 Then
            plTrial.Visible = False
            lbtrial.Visible = False
        ElseIf value >= 1 And value < 50 Then
            plTrial.Visible = True
            lbtrial.Text = value
            value += 1
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "Labeling_Trial_Use", value)
        Else

            Dim m = InputBox("Code =  " & value)
            If Not IsNumeric(m) Then
                End
            End If

            Dim tr = value * 11
            tr += 123
            tr *= 11

            '  tr = CInt(Now.Day() & "0" & tr & "0" & Now.Month)
            If m = tr Then
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "Labeling_Trial_Use", 0)
                plTrial.Visible = False
                lbtrial.Visible = False
            Else
                End
            End If
        End If
    End Sub

    Private Sub LabelPrinter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        TrialNumb() '' Activation

        Using a As SubClass = New SubClass(1)
            a.AutoCompleteArticles(txtCat, "Category")
        End Using

        Try
            Dim dir1 As New DirectoryInfo(Form1.ImgPah & "\EtqDsn")
            If dir1.Exists = False Then dir1.Create()

            Dim aryFi As IO.FileInfo() = dir1.GetFiles("*.dat")
            Dim fi As IO.FileInfo

            For Each fi In aryFi
                cbEtqs.Items.Add(fi.Name)
            Next
        Catch ex As Exception
        End Try

        Try
            Dim dir1 As New DirectoryInfo(Form1.ImgPah & "\CatDsn")
            If dir1.Exists = False Then dir1.Create()

            Dim aryFi As IO.FileInfo() = dir1.GetFiles("*.dat")
            Dim fi As IO.FileInfo

            For Each fi In aryFi
                cbCats.Items.Add(fi.Name)
            Next
        Catch ex As Exception
        End Try

        getRegistryinfo(num_Lines, "LabelNumPage", "50")
        txtNum.Text = num_Lines
        txtPage.Text = 1


        ' Create four typed columns in the DataTable.
        table.Columns.Add("Name", GetType(String))
        table.Columns.Add("Prix(G)", GetType(String))
        table.Columns.Add("Prix(P)", GetType(String))
        table.Columns.Add("Prix", GetType(String))
        table.Columns.Add("Ref", GetType(String))
        table.Columns.Add("Code", GetType(String))
        table.Columns.Add("Image_Article", GetType(String))

    End Sub

    Private Sub getData()
        getRegistryinfo(txtF1, "txtF1", "arial")
        getRegistryinfo(txtZ1, "txtZ1", "10")
        getRegistryinfo(txtF2, "txtF2", "arial")
        getRegistryinfo(txtZ2, "txtZ2", "10")
        getRegistryinfo(txtX, "txtX", "10")
        getRegistryinfo(txtY, "txtY", "10")
        getRegistryinfo(TXTW, "TXTW", "200")
        getRegistryinfo(TXTH, "TXTH", "100")

        getRegistryinfo(TxtBox1, "TxtBox1", "44")
        getRegistryinfo(TxtBox2, "TxtBox2", "55")
        getRegistryinfo(TxtBox3, "TxtBox3", "6")
        getRegistryinfo(TxtBox4, "TxtBox4", "16")
        getRegistryinfo(TxtBox5, "TxtBox5", "0")
        getRegistryinfo(TxtBox6, "TxtBox6", "0")
        getRegistryinfo(isRayounage, "isRayounage", False)
        Dim i As Integer = 0
        getRegistryinfo(i, "br", "0")

        br = New SolidBrush(Color.FromArgb(i))


        getRegistryinfo(PRINTER, "prt2", "no")
    End Sub

    Private Sub getRegistryinfo(ByRef txt As Integer, ByVal str As String, ByVal v As String)
        Try
            Dim msg As String
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, Nothing)
            If msg = Nothing Then
                msg = v
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, msg)
                txt = CInt(msg)
            Else
                txt = CInt(msg)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub getRegistryinfo(ByRef txt As String, ByVal str As String, ByVal v As String)
        Try
            Dim msg As String
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, Nothing)
            If msg = Nothing Then
                msg = v
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, msg)
                txt = msg
            Else
                txt = msg
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub getRegistryinfo(ByRef txt As Boolean, ByVal str As String, ByVal v As Boolean)
        Try
            Dim msg As String
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, Nothing)
            If msg = Nothing Then
                msg = v
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, msg)
                txt = msg
            Else
                txt = msg
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function getRegistryinfo(ByVal str As String, ByVal v As Integer)
        Try
            Dim msg As String
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, Nothing)
            If msg = Nothing Then
                msg = v
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, msg)
                Return msg
            Else
                Return msg
            End If
        Catch ex As Exception
        End Try

        Return v
    End Function
    Dim dt As DataTable
    Dim act_page As Integer = 0
    Dim tot_pages As Integer = 0
    Dim num_Lines As Integer = 50

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Cid As Integer

        Dim artdt As DataTable

        dg1.DataSource = Nothing

        Dim params As New Dictionary(Of String, Object)
        Try
            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)


                If txtCat.text.Contains("|") Then
                    Dim str As String = txtCat.text.Trim
                    str = str.Split(CChar("|"))(1)
                    Cid = CInt(str)
                    ' params.Add("cid", Cid)
                    ' dt = a.SelectDataTable("Article", {"*"}, params)
                End If

                If txtArt.text <> "" Then

                    params.Add("name LIKE ", "%" & txtArt.text & "%")
                    If Cid > 0 Then params.Add("cid = ", Cid)
                    dt = a.SelectDataTableSymbols("Article", {"*"}, params)

                    params.Clear()
                    params.Add("codebar LIKE ", "%" & txtArt.text & "%")
                    If Cid > 0 Then params.Add("cid = ", Cid)
                    artdt = a.SelectDataTableSymbols("Article", {"*"}, params)

                    Try
                        dt.Merge(artdt, False)
                    Catch ex As Exception
                    End Try
                Else
                    If Cid > 0 Then
                        params.Add("cid", Cid)
                        dt = a.SelectDataTable("Article", {"*"}, params)
                    Else
                        dt = a.SelectDataTable("Article", {"*"})
                    End If
                End If

                act_page = 1
                If dt.Rows.Count / num_Lines > CInt(dt.Rows.Count / num_Lines) Then
                    tot_pages = CInt(dt.Rows.Count / num_Lines) + 1
                Else
                    tot_pages = CInt(dt.Rows.Count / num_Lines)
                End If

                lbPagesNum.Text = "Page " & act_page & "/" & tot_pages

                Dim dtPage As DataTable = dt.Rows.Cast(Of System.Data.DataRow).Take(num_Lines).CopyToDataTable()
                txtPage.Text = act_page
                txtNum.Text = num_Lines

                dg1.DataSource = dtPage
                StyleDatagrid(dg1)
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Private Sub StyleDatagrid(ByRef dg As DataGridView)


        dg1.Columns(0).Visible = False
        dg1.Columns(1).Visible = False
        dg1.Columns(4).Visible = False
        dg1.Columns(3).Visible = False
        dg1.Columns(6).Visible = False
        dg1.Columns(7).Visible = False
        dg1.Columns(8).Visible = False
        dg1.Columns(10).Visible = False
        dg1.Columns(11).Visible = False
        dg1.Columns(12).Visible = False
        dg1.Columns(13).Visible = False
        dg1.Columns(14).Visible = False
        dg1.Columns(15).Visible = False
        dg1.Columns(16).Visible = False
        dg1.Columns(17).Visible = False
        dg1.Columns(18).Visible = False


        dg1.Columns(2).HeaderText = "Designation"
        dg1.Columns(5).HeaderText = "Prix"
        dg1.Columns(9).HeaderText = "Code/Ref"

        dg.AutoGenerateColumns = True
        dg.BorderStyle = Windows.Forms.BorderStyle.None
        dg.CellBorderStyle = DataGridViewCellBorderStyle.None

        dg.BackgroundColor = Color.White

        dg.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        dg.AllowUserToAddRows = False
        dg.AllowUserToDeleteRows = False
        dg.AllowUserToResizeRows = False
        dg.EditMode = DataGridViewEditMode.EditProgrammatically

        dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dg.RowTemplate.Height = 33
        dg.ColumnHeadersHeight = 33

        dg.Dock = DockStyle.Fill
        dg.RowHeadersVisible = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        dg1.ClearSelection()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        dg1.SelectAll()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        For i As Integer = 0 To dg1.SelectedRows.Count - 1
            DG2.Rows.Add(dg1.SelectedRows(i).Cells(0).Value,
                         dg1.SelectedRows(i).Cells(2).Value,
                         dg1.SelectedRows(i).Cells(9).Value,
                         dg1.SelectedRows(i).Cells(5).Value,
                         dg1.SelectedRows(i).Cells(3).Value,
                         DG2.Rows.Count + 1)
        Next

        lbNumArticles.Text = DG2.Rows.Count & " Articles"
        dg1.ClearSelection()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            For Each r As DataGridViewRow In DG2.SelectedRows
                If Not r.IsNewRow Then
                    DG2.Rows.RemoveAt(r.Index)
                End If
            Next

            For i As Integer = 0 To DG2.Rows.Count - 1
                DG2.Rows(i).Cells(5).Value = i + 1
            Next
        Catch ex As Exception
        End Try

        lbNumArticles.Text = DG2.Rows.Count & " Articles"
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            If TOTAL_NUM_TRIAL >= 1 And TOTAL_NUM_TRIAL < 50 Then
                TOTAL_NUM_TRIAL += 1
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "Labeling_Trial_Use", TOTAL_NUM_TRIAL)
            End If

            If TOTAL_NUM_TRIAL > 50 Then Exit Sub




            If dg1.SelectedRows.Count = 0 Then Exit Sub

            Dim cde As String = dg1.SelectedRows(0).Cells(9).Value
            If cde.Length > 12 Then cde = cde.Substring(cde.Length - 9)
            'If cde.Length < 12 Then
            '    For i As Integer = 0 To 11
            '        cde = "0" & cde
            '        If cde.Length = 12 Then Exit For
            '    Next
            'End If

            Dim CD As New BarCode2
            CD.Code = cde
            CD.article = dg1.SelectedRows(0).Cells(2).Value

            'CD.btImprimer.Visible = False
            'CD.Button3.Visible = True

            If CD.ShowDialog = DialogResult.OK Then

            End If

        Catch ex As Exception

        End Try

        getData()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            If TOTAL_NUM_TRIAL >= 1 And TOTAL_NUM_TRIAL < 50 Then
                TOTAL_NUM_TRIAL += 1
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "Labeling_Trial_Use", TOTAL_NUM_TRIAL)
            End If

            If TOTAL_NUM_TRIAL > 50 Then Exit Sub


            If DG2.SelectedRows.Count = 0 Then Exit Sub

            Dim cde As String = DG2.SelectedRows(0).Cells(2).Value
            If cde.Length > 12 Then cde = cde.Substring(cde.Length - 9)
            'If cde.Length < 12 Then
            '    For i As Integer = 0 To 11
            '        cde = "0" & cde
            '        If cde.Length = 12 Then Exit For
            '    Next
            'End If
            Dim CD As New BarCode2
            CD.Code = cde
            CD.article = DG2.SelectedRows(0).Cells(1).Value

            If CD.ShowDialog = DialogResult.OK Then

            End If

        Catch ex As Exception

        End Try

        getData()
    End Sub

    Public article As String
    Public qte As String
    Private K_nmPage As Integer = 0
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim _x As Integer = 0
        Dim _y As Integer = gl.Start_Y
        Dim _img As Image = Nothing
        '   Dim m = 0
        If gl.is_Repeated = False Then

            Dim NBPAGE = table.Rows.Count / (gl.Nbr_H * gl.Nbr_W)

            If NBPAGE > CInt(NBPAGE) Then
                NBPAGE = CInt(NBPAGE) + 1
            Else
                NBPAGE = CInt(NBPAGE)
            End If

            For k = K_nmPage To CInt(NBPAGE)
                For i As Integer = 0 To gl.Nbr_H - 1
                    _x = gl.Start_X
                    If i > 0 Then _y += gl.Sp_H
                    For t As Integer = 0 To gl.Nbr_W - 1

                        If m >= table.Rows.Count Then Exit Sub
                        PrintLabel(m, _x, _y, e)
                        _x += gl.W_El  '.Width
                        _x += gl.Sp_W
                        m += 1
                    Next
                    _y += gl.H_El
                Next
                If k < CInt(NBPAGE) Then
                    k += 1
                    e.HasMorePages = True
                    Return
                End If
            Next
        Else
            While m < table.Rows.Count


                For i As Integer = 0 To gl.Nbr_H - 1
                    _x = gl.Start_X
                    If i > 0 Then _y += gl.Sp_H
                    For t As Integer = 0 To gl.Nbr_W - 1

                        PrintLabel(m, _x, _y, e)
                        _x += gl.W_El
                        _x += gl.Sp_W
                    Next
                    _y += gl.H_El
                Next

                e.HasMorePages = True
                m += 1
                Return
            End While

        End If
        K_nmPage = 0
    End Sub

    Private Sub PrintLabel(ByRef _i As Integer, ByRef xx As Integer, ByRef yy As Integer, ByRef e As System.Drawing.Printing.PrintPageEventArgs)

        Dim pen As New Pen(Brushes.Black, 1.0F)
        Dim sf As New StringFormat()

        'gl.W_El, gl.H_El
        e.Graphics.DrawRectangle(Pens.WhiteSmoke, 0, 0, gl.W_El - 2, gl.H_El - 2)

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
                e.Graphics.DrawRectangle(pen, top_x, top_y, a.width, a.height)
                Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                e.Graphics.FillRectangle(_br, top_x, top_y, a.width, a.height)

                top_x += 5
                top_y += 3
            End If

            Dim str As String = CStr(a.designation)

            If a.field.StartsWith("*") Then

            ElseIf a.field.StartsWith("FOR") Then

                If str = "R" Then

                    Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                    e.Graphics.FillRectangle(_br, top_x, top_y, a.width, a.height)
                ElseIf str = "G" Then
                    DrawRoundedRectangle(e.Graphics, top_x, top_y, a.width, a.height, a.fSize)
                ElseIf str = "C" Then
                    Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                    e.Graphics.FillEllipse(_br, top_x, top_y, a.width, a.height)
                ElseIf str = "S" Then

                    Dim ls = a.points.Split("|")

                    Dim myPoints(ls.Length - 1) As Point
                    For n As Integer = 0 To ls.Length - 1
                        Try
                            myPoints(n) = New Point(ls(n).Split("*")(0) + xx, ls(n).Split("*")(1) + yy)
                        Catch ex As Exception
                        End Try
                    Next
                    Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                    e.Graphics.FillPolygon(_br, myPoints)
                End If

                str = ""

            ElseIf a.field.StartsWith("IMAGE_PATH") Then
                Try
                    str = ""
                    Dim fullPath As String = a.designation
                    e.Graphics.DrawImage(Image.FromFile(fullPath), top_x, top_y, a.width, a.height)
                Catch ex As Exception
                End Try
            ElseIf a.field.StartsWith("Image_Article") Then
                Try
                    str = ""
                    Dim fullPath As String = Path.Combine(Form1.ImgPah, table.Rows(_i).Item(a.field))
                    e.Graphics.DrawImage(Image.FromFile(fullPath), top_x, top_y, a.width, a.height)
                Catch ex As Exception
                End Try
            ElseIf a.field.StartsWith("//") Then  '' codebar G.FillRectangle(Brushes.Gray, top_x, top_y, a.width, a.height)

                Dim code = table.Rows(_i).Item("Code").ToUpper()
                Dim _str As String = "*"c & code & "*"c
                Dim strLength As Integer = _str.Length
                Dim intercharacterGap As String = "0"

                For i As Integer = 0 To code.Length - 1

                    If alphabet39.IndexOf(code(i)) = -1 OrElse code(i) = "*"c Then
                        e.Graphics.DrawString("INVALID BAR CODE TEXT", Font, Brushes.Red, 10, 10)
                        Exit Sub
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
                    e.Graphics.FillRectangle(If(i Mod 2 = 0, _br, Brushes.White), top_x, top_y, wid, a.height)
                    top_x += wid
                Next

            Else

                str &= table.Rows(_i).Item(a.field)
            End If

            Dim br = New SolidBrush(Color.FromArgb(a.forColor))
            sf.Alignment = a.Alignement
            If a.isVertical Then
                sf.FormatFlags = StringFormatFlags.DirectionVertical
            Else
                sf.FormatFlags = StringFormatFlags.DisplayFormatControl
            End If

            e.Graphics.DrawString(str, fn, br, New RectangleF(top_x, top_y, a.width, a.height), sf)
        Next

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click


        If TOTAL_NUM_TRIAL >= 1 And TOTAL_NUM_TRIAL < 50 Then
            TOTAL_NUM_TRIAL += DG2.Rows.Count
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "Labeling_Trial_Use", TOTAL_NUM_TRIAL)
        End If

        If TOTAL_NUM_TRIAL > 50 Then Exit Sub




        table.Rows.Clear()
        m = 0
        For i As Integer = 0 To DG2.Rows.Count - 1
            Try
                article = DG2.Rows(i).Cells(1).Value
                qte = DG2.Rows(i).Cells(3).Value
                Dim cde As String = DG2.Rows(i).Cells(2).Value
              
                If DG2.Rows(i).Cells(2).Value.ToString.Contains("|") Then

                    Dim str = DG2.Rows(i).Cells(2).Value.ToString.Split("|")

                    For r As Integer = 0 To str.Length - 1
                        If IsNumeric(str(r)) Then
                            cde = str(r)
                            Exit For
                        End If
                    Next
                End If

                If cde.Length > 12 Then cde = cde.Substring(0, 12)
           
                Dim bigPrice As Integer = 0
                Dim smallPrice As Double = 0
                SplitDecimal(qte, bigPrice, smallPrice)
                Dim SM As Integer = CInt(smallPrice * 100)

                table.Rows.Add(article, bigPrice, "." & String.Format("{0:00}", SM), qte,
                               DG2.SelectedRows(0).Cells(2).Value, cde, DG2.SelectedRows(0).Cells(4).Value)
            Catch ex As Exception
            End Try
        Next


        If DG2.Rows.Count = 0 Then Exit Sub
        If cbEtqs.Text = "" Then Exit Sub
        K_nmPage = 0

        LoadXmlEtqs()

        Dim ps As New Printing.PaperSize(gl.P_name, gl.W_Page, gl.h_Page)
        ps.PaperName = gl.p_Kind
        PrintDocument1.DefaultPageSettings.PaperSize = ps
        PrintDocument1.DefaultPageSettings.Landscape = gl.is_Landscape

        PrintDocument1.PrinterSettings.PrinterName = gl.Printer_name
        For i As Integer = 0 To gl.Nbr_Q - 1
            PrintDocument1.Print()
        Next

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        DG2.Rows.Clear()
        lbNumArticles.Text = DG2.Rows.Count & " Articles"
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Form1.PrintDlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Try
            PRINTER = Form1.PrintDlg.PrinterSettings.PrinterName
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "prt2", PRINTER)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        'Dim PR As New LabelSetting
        'If PR.ShowDialog = Windows.Forms.DialogResult.OK Then

        'End If


        Dim PR As New LbSetting
        If PR.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If


        getData()
    End Sub

    Private Sub PrintDocDesign_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocDesign.PrintPage

        Dim _x As Integer = 0
        Dim _y As Integer = gl.Start_Y
        Dim _img As Image = Nothing
        '   Dim m = 0
        If gl.is_Repeated Then


            For i As Integer = 0 To gl.Nbr_H - 1
                _x = gl.Start_X
                If i > 0 Then _y += gl.Sp_H
                For t As Integer = 0 To gl.Nbr_W - 1

                    If m >= table.Rows.Count Then Exit Sub
                    _img = DrawingEtq(m)
                    e.Graphics.DrawImage(_img, _x, _y)
                    _x += _img.Width
                    _x += gl.Sp_W
                    m += 1
                Next
                _y += _img.Height
            Next
        Else
            While m < table.Rows.Count

                _img = DrawingEtq(m)
                For i As Integer = 0 To gl.Nbr_H - 1
                    _x = gl.Start_X
                    If i > 0 Then _y += gl.Sp_H
                    For t As Integer = 0 To gl.Nbr_W - 1


                        e.Graphics.DrawImage(_img, _x, _y)
                        _x += _img.Width
                        _x += gl.Sp_W
                    Next
                    _y += _img.Height
                Next

                e.HasMorePages = True
                m += 1
                Return
            End While
        End If


        'DrawPage(e)
        'm = 0
    End Sub
    Private m = 0
    Private Sub DrawPage(ByRef e As System.Drawing.Printing.PrintPageEventArgs)


        Dim _x As Integer = 0
        Dim _y As Integer = gl.Start_Y
        Dim _img As Image = Nothing
        '   Dim m = 0
        If gl.is_Repeated Then


            For i As Integer = 0 To gl.Nbr_H - 1
                _x = gl.Start_X
                If i > 0 Then _y += gl.Sp_H
                For t As Integer = 0 To gl.Nbr_W - 1

                    If m >= table.Rows.Count Then Exit Sub
                    _img = DrawingEtq(m)
                    e.Graphics.DrawImage(_img, _x, _y)
                    _x += _img.Width
                    _x += gl.Sp_W
                    m += 1
                Next
                _y += _img.Height
            Next
        Else
            While m < table.Rows.Count

                _img = DrawingEtq(m)
                For i As Integer = 0 To gl.Nbr_H - 1
                    _x = gl.Start_X
                    If i > 0 Then _y += gl.Sp_H
                    For t As Integer = 0 To gl.Nbr_W - 1


                        e.Graphics.DrawImage(_img, _x, _y)
                        _x += _img.Width
                        _x += gl.Sp_W
                    Next
                    _y += _img.Height
                Next

                e.HasMorePages = True
                m += 1
                Return
            End While
        End If



    End Sub

    Private alphabet39 As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%*"
    Private coded39Char As String() = {"000110100", "100100001", "001100001", "101100000", "000110001", "100110000", "001110000", "000100101", "100100100", "001100100", "100001001", "001001001", "101001000", "000011001", "100011000", "001011000", "000001101", "100001100", "001001100", "000011100", "100000011", "001000011", "101000010", "000010011", "100010010", "001010010", "000000111", "100000110", "001000110", "000010110", "110000001", "011000001", "111000000", "010010001", "110010000", "011010000", "010000101", "110000100", "011000100", "010101000", "010100010", "010001010", "000101010", "010010100"}


    Public Function DrawingEtq(ByVal _i)
        'Create a font   

        Dim pen As New Pen(Brushes.Black, 1.0F)

        Dim sf As New StringFormat()

        Dim _Bmp As Bitmap

        Dim params_tva As New Dictionary(Of Double, Double)

        'Create a new bitmap
        Using Bmp As New Bitmap(gl.W_El, gl.H_El, Imaging.PixelFormat.Format64bppPArgb)
            'Set the resolution to 300 DPI
            'Bmp.SetResolution(300, 300)
            Using G As Graphics = Graphics.FromImage(Bmp)
                G.Clear(Color.White)
                G.DrawRectangle(Pens.WhiteSmoke, 0, 0, gl.W_El - 2, gl.H_El - 2)
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
                            Dim fullPath As String = Path.Combine(Form1.ImgPah, a.designation)
                            G.DrawImage(Image.FromFile(fullPath), top_x, top_y, a.width, a.height)
                        Catch ex As Exception
                        End Try
                    ElseIf a.field.StartsWith("//") Then  '' codebar G.FillRectangle(Brushes.Gray, top_x, top_y, a.width, a.height)
                        'For i As Integer = 0 To Code.Length - 1

                        '    If alphabet39.IndexOf(Code(i)) = -1 OrElse Code(i) = "*"c Then
                        '        e.Graphics.DrawString("INVALID BAR CODE TEXT", Font, Brushes.Red, 10, 10)
                        '        Return
                        '    End If
                        'Next
                    Else

                        str &= table.Rows(_i).Item(a.field)
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
    Public Sub LoadXmlEtqs()
        Try

            gl = ReadFromXmlFile(Of LbGlobalElement)(Form1.ImgPah & "\EtqDsn\" & cbEtqs.Text)

        Catch ex As Exception

        End Try
    End Sub
    Public Sub LoadXmlCats()
        Try

            ct = ReadFromXmlFile(Of CatElement)(Form1.ImgPah & "\CatDsn\" & cbCats.Text)
            DG2.Rows.Clear()
            For Each a As LbArticle In ct.Articles
                DG2.Rows.Add(a.arid, a.designation, a.code, a.prix, a.img, DG2.Rows.Count + 1)
            Next
        Catch ex As Exception

        End Try

        lbNumArticles.Text = DG2.Rows.Count & " Articles"
    End Sub

    Private Sub cb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbEtqs.SelectedIndexChanged
        If cbEtqs.Text = "" Then Exit Sub
        LoadXmlEtqs()
    End Sub

    Private Sub plTrial_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles plTrial.MouseClick
        Dim m = InputBox("Code =  " & lbtrial.Text)
        If Not IsNumeric(m) Then
            End
        End If

        Dim tr = CInt(lbtrial.Text) * 11
        tr += 123
        tr *= 11

        'tr = CInt(Now.Day() & "0" & tr & "0" & Now.Month)
        If m = tr Then
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "Labeling_Trial_Use", 0)
            plTrial.Visible = False
            lbtrial.Visible = False
        End If
    End Sub

    Private fromIndex As Integer
    Private dragIndex As Integer
    Private dragRect As Rectangle
    Private Sub DataGridView1_DragDrop(ByVal sender As Object, _
                                   ByVal e As DragEventArgs) _
                                   Handles DG2.DragDrop
        Try
            Dim p As Point = DG2.PointToClient(New Point(e.X, e.Y))
            dragIndex = DG2.HitTest(p.X, p.Y).RowIndex
            If (e.Effect = DragDropEffects.Move) Then
                Dim dragRow As DataGridViewRow = e.Data.GetData(GetType(DataGridViewRow))
                DG2.Rows.RemoveAt(fromIndex)
                DG2.Rows.Insert(dragIndex, dragRow)
                DG2.ClearSelection()
                DG2.Rows(dragIndex).Selected = True

                For i As Integer = 0 To DG2.Rows.Count - 1
                    DG2.Rows(i).Cells(5).Value = i + 1
                Next
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub DataGridView1_DragOver(ByVal sender As Object, _
                                       ByVal e As DragEventArgs) _
                                       Handles DG2.DragOver
        e.Effect = DragDropEffects.Move
    End Sub
    Private Sub DataGridView1_MouseDown(ByVal sender As Object, _
                                    ByVal e As MouseEventArgs) _
                                    Handles DG2.MouseDown
        Try
            fromIndex = DG2.HitTest(e.X, e.Y).RowIndex
            If fromIndex > -1 Then
                Dim dragSize As Size = SystemInformation.DragSize
                dragRect = New Rectangle(New Point(e.X - (dragSize.Width / 2), _
                                                   e.Y - (dragSize.Height / 2)), _
                                         dragSize)
            Else
                dragRect = Rectangle.Empty
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridView1_MouseMove(ByVal sender As Object, _
                                        ByVal e As MouseEventArgs) _
                                        Handles DG2.MouseMove
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            If (dragRect <> Rectangle.Empty _
            AndAlso Not dragRect.Contains(e.X, e.Y)) Then
                DG2.DoDragDrop(DG2.Rows(fromIndex), _
                                         DragDropEffects.Move)
            End If
        End If
    End Sub
    'Private Sub SkillGrid_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles DG2.DragDrop
    '    Dim p As Point = DG2.PointToClient(New Point(e.X, e.Y))
    '    Dim newRow As DataGridViewRow = DG2.Rows(DG2.HitTest(p.X, p.Y).RowIndex) 'gets new row info
    '    If newRow.Index >= 0 And newRow.Index < DG2.Rows.Count Then
    '        Dim oldRow As DataGridViewRow = DirectCast(e.Data.GetData(GetType(DataGridViewRow)), DataGridViewRow)
    '        'gets dropped row info


    '        If newRow.Index <> oldRow.Index Then 'if the two rows aren't the same it inserts dropped row
    '            DG2.Rows.RemoveAt(oldRow.Index)
    '            DG2.Rows.Insert(newRow.Index, oldRow)

    '        End If
    '    End If
    'End Sub

    'Private Sub SkillGrid_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles DG2.DragEnter
    '    e.Effect = DragDropEffects.Copy
    'End Sub

    'Private Sub SkillGrid_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DG2.MouseDown
    '    If e.Button = MouseButtons.Left Then
    '        Dim info As DataGridView.HitTestInfo = DG2.HitTest(e.X, e.Y)
    '        If info.RowIndex >= 0 Then
    '            Dim view As DataGridViewRow = DirectCast(DG2.Rows(info.RowIndex), DataGridViewRow)
    '            If view IsNot Nothing Then
    '                DG2.DoDragDrop(view, DragDropEffects.Copy)
    '            End If
    '        End If
    '    End If
    'End Sub

    Private Sub btCats_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCats.Click
        plEtqs.BackColor = Color.WhiteSmoke
        btetq.BackColor = Color.WhiteSmoke

        plEtqs.Width = 72

        plCats.BackColor = Color.LawnGreen
        btCats.BackColor = Color.LightGreen

    End Sub

    Private Sub btetq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btetq.Click
        plCats.BackColor = Color.WhiteSmoke
        btCats.BackColor = Color.WhiteSmoke
        '
        plEtqs.Width = 444

        plEtqs.BackColor = Color.LawnGreen
        btetq.BackColor = Color.LightGreen

    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        If DG2.Rows.Count = 0 Then Exit Sub

        Dim art As New List(Of LbArticle)
 
        For i As Integer = 0 To DG2.Rows.Count - 1
            Try
                Dim ar As New LbArticle
                ar.arid = DG2.Rows(i).Cells(0).Value
                ar.designation = DG2.Rows(i).Cells(1).Value
                ar.code = DG2.Rows(i).Cells(2).Value
                ar.prix = DG2.Rows(i).Cells(3).Value
                ar.img = DG2.Rows(i).Cells(4).Value

                art.Add(ar)
            Catch ex As Exception
            End Try
        Next

        ct.Articles = art

        WriteToXmlFile(Of CatElement)(Form1.ImgPah & "\CatDsn\" & cbCats.Text, ct)
    End Sub
  
    Private Sub cbCats_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCats.SelectedIndexChanged
        Try
            If cbCats.Text = "" Then Exit Sub
            LoadXmlCats()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        If act_page >= tot_pages Then Exit Sub

        act_page += 1
        dg1.DataSource = Nothing

        lbPagesNum.Text = "Page " & act_page & "/" & tot_pages
        txtPage.Text = act_page
        txtNum.Text = num_Lines

        Dim dtPage As DataTable = dt.Rows.Cast(Of System.Data.DataRow).Skip((act_page - 1) * num_Lines).Take(num_Lines).CopyToDataTable()

        dg1.DataSource = dtPage
        StyleDatagrid(dg1)
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        If act_page <= 1 Then Exit Sub

        act_page -= 1
        dg1.DataSource = Nothing

        lbPagesNum.Text = "Page " & act_page & "/" & tot_pages
        txtPage.Text = act_page
        txtNum.Text = num_Lines

        Dim dtPage As DataTable = dt.Rows.Cast(Of System.Data.DataRow).Skip((act_page - 1) * num_Lines).Take(num_Lines).CopyToDataTable()

        dg1.DataSource = dtPage
        StyleDatagrid(dg1)
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click

        If IsNumeric(txtNum.Text) Then
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "LabelNumPage", CInt(txtNum.Text))
            num_Lines = CInt(txtNum.Text)

            If dt.Rows.Count / num_Lines > CInt(dt.Rows.Count / num_Lines) Then
                tot_pages = CInt(dt.Rows.Count / num_Lines) + 1
            Else
                tot_pages = CInt(dt.Rows.Count / num_Lines)
            End If

        Else
            txtNum.Text = num_Lines
        End If



        If Not IsNumeric(txtPage.Text) Then
            txtPage.Text = act_page
            Exit Sub
        End If

        If CInt(txtPage.Text) > tot_pages Then Exit Sub
        If CInt(txtPage.Text) < 1 Then Exit Sub

        act_page = CInt(txtPage.Text)
        dg1.DataSource = Nothing

        lbPagesNum.Text = "Page " & act_page & "/" & tot_pages
        txtPage.Text = act_page
        txtNum.Text = num_Lines

        Dim dtPage As DataTable = dt.Rows.Cast(Of System.Data.DataRow).Skip((act_page - 1) * num_Lines).Take(num_Lines).CopyToDataTable()

        dg1.DataSource = dtPage
        StyleDatagrid(dg1)
    End Sub

    Private Sub dg1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dg1.KeyDown
         
    End Sub

    Private Sub dg1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dg1.KeyPress
      
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message,
                                               ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim k As System.Windows.Forms.Keys = keyData
        Select Case keyData

            Case Keys.F1
                Button3_Click(Nothing, Nothing)
            Case Keys.F2
                Button4_Click(Nothing, Nothing)
            Case Keys.F3
                Button2_Click(Nothing, Nothing)
            Case Keys.F4
               
            Case Keys.F5
                Button9_Click(Nothing, Nothing)
            Case Keys.F6
                Button5_Click(Nothing, Nothing)
            Case Keys.F7
                Button7_Click(Nothing, Nothing)

            Case Keys.Escape
                Button2_Click(Nothing, Nothing)
            Case Keys.Enter  ' add one
                Button2_Click(Nothing, Nothing)

            Case Keys.Space  ' save and print
                    Button4_Click(Nothing, Nothing)
            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)
        End Select

        Return True
    End Function
End Class