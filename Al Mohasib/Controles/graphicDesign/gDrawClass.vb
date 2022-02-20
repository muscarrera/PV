Imports System.IO

Public Class gDrawClass
    Implements IDisposable

    Dim FooterFieldDic As List(Of gTopField)
    Dim TopFieldDic As List(Of gTopField)
    Dim W_Page As Integer
    Dim h_Page As Integer
    Dim x_Page As Integer
    Dim y_Page As Integer
    Dim has_stopEntete As Boolean

    Dim gTabProp As gTabClass
    Dim localname As String
    Public rtl As Boolean = False

    Dim up_table_H As Integer = 0

    Public Sub New(ByVal lName As String)
        localname = lName
         LoadXml()
    End Sub


    Public Sub LoadXml()
        Dim g As New gGlobClass

        g = ReadFromXmlFile(Of gGlobClass)(Form1.ImgPah & "\Prt_Dsn\" & localname)
        FooterFieldDic = g.FooterFieldDic
        TopFieldDic = g.TopFieldDic
        W_Page = g.W_Page
        h_Page = g.h_Page
        x_Page = g.x_Page
        y_Page = g.y_Page
        has_stopEntete = g.has_StopEntete

        gTabProp = g.TabProp
    End Sub
    Public Sub DrawBl(ByRef e As System.Drawing.Printing.PrintPageEventArgs,
                           ByVal data As DataTable,
                              ByVal details As DataTable,
                              ByVal dt_Client As DataTable,
                              ByVal title As String,
                              ByVal HD As Boolean,
                              ByRef m As Integer)


        Dim g = e.Graphics

        Dim isRYAL As Boolean = Form1.isBaseOnRIYAL

        Dim _w = W_Page
        Dim _h = h_Page
        Dim tc = gTabProp

        Dim _Ttype = tc.Type

        Dim F_T As New Font(tc.pTl, tc.zTl, FontStyle.Bold)
        Dim F_D As New Font(tc.pIn, tc.zIn)
        If tc.isBIn Then F_D = New Font(tc.pIn, tc.zIn, FontStyle.Bold)



        Dim y As Integer = 20
        Dim h As Integer = 20
        Dim pen As New Pen(Brushes.Black, 1.0F)

        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Near
        Dim sfc As New StringFormat()
        sfc.Alignment = StringAlignment.Center
        Dim sfl As New StringFormat()
        sfl.Alignment = StringAlignment.Far


        Dim params_tva As New Dictionary(Of Double, Double)

        If m = 0 Or has_stopEntete = False Then


            Using B As New SolidBrush(Color.Black)
                For Each a As gTopField In TopFieldDic
                    'Create a brush
                    Dim top_x = a.x
                    Dim top_y = a.y

                    Dim fn As Font
                    If a.isBold Then
                        fn = New Font("Arial", a.fSize, FontStyle.Bold)
                    Else
                        fn = New Font("Arial", a.fSize)
                    End If

                    Try


                        If a.hasBloc Then
                            'g.DrawRectangle(pen, a.x, a.y, a.width, a.height)
                            Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                            g.FillRectangle(_br, a.x, a.y, a.width, a.height)

                            top_x += 5
                            top_y += 3
                        End If

                        Dim str As String = CStr(a.designation)

                        If a.field.StartsWith("CLT") Then
                            Dim s = a.field.Split("_")(1)
                            str &= dt_Client.Rows(0).Item(s)
                        ElseIf a.field.StartsWith("*") Then

                        ElseIf a.field.StartsWith("image") Then
                            Try
                                str = ""
                                Dim fullPath As String = Path.Combine("C:\cmcimage", a.designation)
                                g.DrawImage(Image.FromFile(fullPath), top_x, top_y, a.width, a.height)
                            Catch ex As Exception
                            End Try
                        ElseIf a.field.StartsWith("-") Then
                            str &= title

                        ElseIf a.field.StartsWith("DPT") Then
                            Dim s = a.field.Split("_")(1)

                            If s = "ID" Then
                                str &= Form1._kvp.Key
                            Else
                                str &= Form1._kvp.Value
                            End If

                        Else

                            str &= data.Rows(0).Item(a.field)
                        End If

                        g.DrawString(str, fn, B, New RectangleF(top_x, top_y, a.width, a.height), sf)
                    Catch ex As Exception
                    End Try
                Next
            End Using
        Else
            If up_table_H = 0 Then up_table_H = tc.TabHeight + (tc.y - 20)

            tc.y = 20
            tc.TabHeight = up_table_H
        End If

        '////////////////////////////////////////////////////////////////////////
        ' table

        Dim x As Integer = tc.x
        y = tc.y + 33

        If _Ttype = "Table_1" Then  '//////////////////////////////////////////////
            g.DrawRectangle(pen, tc.x, tc.y, tc.TabWidth, tc.TabHeight)
            g.DrawLine(pen, tc.x, tc.y + F_T.Height + 5, tc.x + tc.TabWidth, tc.y + F_T.Height + 5)
            Dim isFerst As Boolean = True
            For Each c As gColClass In tc.details
                g.DrawString(c.HeaderName, F_T, Brushes.Black,
                                New RectangleF(x, tc.y + 3, c.ColWidth, 44), sfc)


                If isFerst = True Then
                    isFerst = False
                    x = x + c.ColWidth
                    Continue For
                End If
                g.DrawLine(pen, x, tc.y, x, tc.y + tc.TabHeight)
                x = x + c.ColWidth
            Next

        ElseIf _Ttype = "Table_2" Then '//////////////////////////////////////////////
            g.DrawLine(pen, tc.x, tc.y + tc.TabHeight, tc.x + tc.TabWidth, tc.y + tc.TabHeight)

            For Each c As gColClass In tc.details
                g.DrawString(c.HeaderName, F_T, Brushes.Black, New RectangleF(x, tc.y + 3, c.ColWidth - 3, 44), sfc)
                g.DrawLine(pen, x, tc.y + F_T.Height + 5, x + c.ColWidth - 3, tc.y + F_T.Height + 5)
                x = x + c.ColWidth
            Next

        ElseIf _Ttype = "Liste_1" Then '//////////////////////////////////////////////

            For Each c As gColClass In tc.details
                g.DrawString(c.HeaderName, F_T, Brushes.Black, New RectangleF(x, tc.y + 3, c.ColWidth - 3, 44), sfc)
                g.DrawLine(pen, x, tc.y + F_T.Height + 5, x + c.ColWidth - 3, tc.y + F_T.Height + 5)
                x = x + c.ColWidth
            Next
        ElseIf _Ttype = "Table_3" Then '//////////////////////////////////////////////

            g.DrawEllipse(pen, tc.x, tc.y, 22, 22)
            g.DrawEllipse(pen, tc.x + tc.TabWidth - 22, tc.y, 22, 22)
            g.FillEllipse(Brushes.White, tc.x + 2, tc.y, 22, 22)
            g.FillEllipse(Brushes.White, tc.x + tc.TabWidth - 24, tc.y, 22, 22)
            'TOP LINES
            g.DrawLine(pen, tc.x + 11, tc.y, tc.x + tc.TabWidth - 22, tc.y)
            g.DrawLine(pen, tc.x + 11, tc.y + 22, tc.x + tc.TabWidth - 22, tc.y + 22)
            'BUTTOM LINE
            g.DrawLine(pen, tc.x, tc.y + tc.TabHeight, tc.x + tc.TabWidth, tc.y + tc.TabHeight)
            'sides lines
            g.DrawLine(pen, tc.x, tc.y + 11, tc.x, tc.y + tc.TabHeight)
            g.DrawLine(pen, tc.x + tc.TabWidth, tc.y + 11, tc.x + tc.TabWidth, tc.y + tc.TabHeight)

            Dim isFerst As Boolean = True
            For Each c As gColClass In tc.details
                g.DrawString(c.HeaderName, F_T, Brushes.Black,
                                New RectangleF(x, tc.y + 3, c.ColWidth, 44), sfc)


                If isFerst = True Then
                    isFerst = False
                    x = x + c.ColWidth
                    Continue For
                End If
                g.DrawLine(pen, x, tc.y, x, tc.y + tc.TabHeight)
                x = x + c.ColWidth
            Next
        ElseIf _Ttype = "Table_4" Then '//////////////////////////////////////////////

            g.FillEllipse(Brushes.Black, tc.x, tc.y, 22, 22)
            g.FillEllipse(Brushes.Black, tc.x + tc.TabWidth - 22, tc.y, 22, 22)
            ''TOP LINES
            g.FillRectangle(Brushes.Black, tc.x + 11, tc.y, tc.TabWidth - 22, 22)

            'BUTTOM LINE
            g.DrawLine(pen, tc.x, tc.y + tc.TabHeight, tc.x + tc.TabWidth, tc.y + tc.TabHeight)
            'sides lines
            g.DrawLine(pen, tc.x, tc.y + 11, tc.x, tc.y + tc.TabHeight)
            g.DrawLine(pen, tc.x + tc.TabWidth, tc.y + 11, tc.x + tc.TabWidth, tc.y + tc.TabHeight)

            Dim isFerst As Boolean = True
            For Each c As gColClass In tc.details
                g.DrawString(c.HeaderName, F_T, Brushes.White, New RectangleF(x, tc.y + 3, c.ColWidth, 44), sfc)
                If isFerst = True Then
                    isFerst = False
                    x = x + c.ColWidth
                    Continue For
                End If
                g.DrawLine(pen, x, tc.y, x, tc.y + tc.TabHeight)
                g.DrawLine(Pens.White, x, tc.y + 1, x, tc.y + 20)
                x = x + c.ColWidth
            Next
        ElseIf _Ttype = "None" Then  '//////////////////////////////////////////////

            For Each c As gColClass In tc.details
                g.DrawString(c.HeaderName, F_T, Brushes.Black,
                                New RectangleF(x, tc.y + 3, c.ColWidth, 44), sfc)

                x = x + c.ColWidth
            Next

        Else '////////////////////////////////////////////////////////////////////////////
            g.DrawRectangle(pen, tc.x, tc.y, tc.TabWidth, tc.TabHeight)
            g.DrawLine(pen, tc.x, tc.y + 22, tc.x + tc.TabWidth, tc.y + 22)
            For Each c As gColClass In tc.details
                g.DrawString(c.HeaderName, F_T, Brushes.Black, New RectangleF(x, tc.y + 3, c.ColWidth, 44), sfc)
                g.DrawLine(pen, x + c.ColWidth, tc.y, x + c.ColWidth, tc.y + tc.TabHeight)
                x = x + c.ColWidth
            Next

        End If
        '//////////////////////////////////////////////////////////////////////////
        'draw details into table

        ' If m > 0 Then g.DrawString("[ ..... ]", F_D, Brushes.Black, tc.x, tc.y - 22)

        Dim _brTab As New SolidBrush(Color.FromArgb(tc.clr))

        While m < details.Rows.Count

            Dim plus_h As Integer = F_D.Height

            If y + plus_h > tc.y + tc.TabHeight And _Ttype.ToUpper.StartsWith("LIS") = False Then
                '   g.DrawString("[ ..... ]", F_D, Brushes.Black, tc.TabWidth + tc.x - 60, tc.y + tc.TabHeight + 22)
                y = tc.y + 33

                g.DrawString("P-" & Form1.page_Number & "// ....", F_D, Brushes.Black, x_Page, y_Page)
                Form1.page_Number += 1

                e.HasMorePages = True
                Return
            End If


            If tc.hasRows Then
                Dim __h = plus_h
                For Each c As gColClass In tc.details
                    If c.Field = "name" Then '///////////////////////////////////////////////
                        Dim _str = details.Rows(m).Item("name")
                        sf.Alignment = StringAlignment.Near
                        Dim size As SizeF = g.MeasureString(_str, F_D, c.ColWidth - 3)
                        __h = size.Height
                    End If
                Next
                If m Mod 2 > 0 Then
                    g.FillRectangle(_brTab, tc.x, y, tc.TabWidth, __h)
                    g.DrawRectangle(Pens.Black, tc.x, y, tc.TabWidth, __h)
                End If
                g.DrawRectangle(Pens.Black, tc.x, y, tc.TabWidth, __h)
            End If


            Dim _x As Integer = tc.x
            Dim dh_ryal = 1
            Dim formatString = "N2"


            For Each c As gColClass In tc.details
                'plus_h = F_D.Height
                Dim _str As String = ""
                Dim field As String = c.Field

                dh_ryal = 1
                If c.Field.Contains("-RYL") Then
                    dh_ryal = 20
                    field = c.Field.Split("-")(0)
                    formatString = "N0"
                End If

                If field = "xTotal" Then '////////////////////////////////////////////////

                    _str = details.Rows(m).Item("qte") * details.Rows(m).Item("price")
                    Dim tva As Double = details.Rows(m).Item("tva")
                    _str = _str / ((100 + tva) / 100)

                    If isRYAL Then
                        _str = CInt(_str)
                    Else
                        _str = String.Format("{0:0.00}", CDbl(_str))
                    End If

                    sf.Alignment = StringAlignment.Far
                ElseIf field = "xPriceTTC" Then '/////////////////////////////////////////
                    _str = details.Rows(m).Item("price")

                    If isRYAL Then
                        _str = CInt(_str)
                    Else
                        _str = String.Format("{0:0.00}", CDbl(_str))
                    End If

                    sf.Alignment = StringAlignment.Far
                ElseIf field = "xTotalTTC" Then '/////////////////////////////////////////
                    _str = details.Rows(m).Item("qte") * details.Rows(m).Item("price")

                    If isRYAL Then
                        _str = CInt(_str)
                    Else
                        _str = String.Format("{0:0.00}", CDbl(_str))
                    End If

                    sf.Alignment = StringAlignment.Far

                ElseIf c.Field = "xdepot" Then '////////////////////////////////////////////
                    _str = details.Rows(m).Item("depot")
                    Try
                        Dim results = From myRow As DataRow In Form1.dt_Depot.Rows Where myRow(0) = _str Select myRow
                        _str = results(0).Item("name")
                    Catch ex As Exception
                        _str = ""
                    End Try
                    sf.Alignment = StringAlignment.Near

                ElseIf c.Field = "xname" Then '//////////////////////////////////////////////
                    _str = "[" & details.Rows(m).Item("ref") & "] " & details.Rows(m).Item("name")
                    sf.Alignment = StringAlignment.Near

                    If rtl Then sf.Alignment = StringAlignment.Far

                    Dim size As SizeF = g.MeasureString(_str, F_D, c.ColWidth - 3)
                    plus_h = size.Height

                ElseIf c.Field = "name" Then '///////////////////////////////////////////////
                    _str = details.Rows(m).Item("name")
                    sf.Alignment = StringAlignment.Near

                    If rtl Then sf.Alignment = StringAlignment.Far

                    Dim size As SizeF = g.MeasureString(_str, F_D, c.ColWidth - 3)
                    plus_h = size.Height
                ElseIf c.Field = "CheckBox" Then '///////////////////////////////////////////////
                    _str = ""
                    g.DrawRectangle(Pens.Black, _x, y + 4, 10, 10)

                ElseIf c.Field = "tva" Or c.Field = "remise" Then '///////////////////////////
                    _str = details.Rows(m).Item(c.Field) & " %"

                    If details.Rows(m).Item(c.Field).ToString = "0" Or details.Rows(m).Item(c.Field).ToString = "" Then _str = ""
                    If c.Field = "tva" And _str = "" Then _str = "Exo"
                    sf.Alignment = StringAlignment.Center

                ElseIf field = "price" Then '///////////////////////////////////////////////
                    _str = details.Rows(m).Item("price")

                    Dim tva As Double = details.Rows(m).Item("tva")
                    _str = _str / ((100 + tva) / 100)

                    If isRYAL Then
                        _str = CInt(_str)
                    Else
                        _str = String.Format("{0:0.00}", CDbl(_str))
                    End If

                    sf.Alignment = StringAlignment.Far

                ElseIf c.Field = "qte" Then '////////////////////////////////////////////////
                    _str = details.Rows(m).Item(c.Field)
                    sf.Alignment = StringAlignment.Center
                Else

                    If c.Field = "ref" Then c.Field = "code"
                    _str = details.Rows(m).Item(c.Field)
                    sf.Alignment = StringAlignment.Near
                    If rtl Then sf.Alignment = StringAlignment.Far
                End If
                g.DrawString(_str, F_D, Brushes.Black, New RectangleF(_x, y, c.ColWidth - 3, plus_h), sf)
                _x = _x + c.ColWidth
            Next


            Try
                params_tva.Add(details.Rows(m).Item("tva"), details.Rows(m).Item("totaltva"))
            Catch ex As Exception
                params_tva(details.Rows(m).Item("tva")) += details.Rows(m).Item("totaltva")
            End Try

            If tc.hasLines And m > 0 Then g.DrawLine(Pens.Black, tc.x, y, tc.x + tc.TabWidth, y)

            y += plus_h + 3
            m += 1
        End While
        '////////////////////////////////////////////////////////////////////////////
        'Foother
        Using B As New SolidBrush(Color.Black)
            For Each a As gTopField In FooterFieldDic
                'Create a brush
                Try

                    If _Ttype.ToUpper.StartsWith("TAB") = False Then a.y += y

                    Dim fn As Font
                    If a.isBold Then
                        fn = New Font("Arial", a.fSize, FontStyle.Bold)
                    Else
                        fn = New Font("Arial", a.fSize)
                    End If

                    Dim xx = a.x
                    Dim yy = a.y
                    If a.hasBloc Then
                        Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                        g.FillRectangle(_br, a.x, a.y, a.width, a.height)
                        g.DrawRectangle(pen, a.x, a.y, a.width, a.height)
                    End If

                    If a.field.StartsWith("//") Then
                        sf.Alignment = StringAlignment.Near

                        Dim nPart As Decimal = 0
                        Dim zPart As Decimal = 0

                        SplitDecimal(CDec(data.Rows(0).Item(a.designation)), nPart, zPart)
                        Dim stt As String = ChLettre.NBLT(nPart) & " Dirhams  "
                        If zPart > 0 Then
                            stt &= "et " & ChLettre.NBLT(CInt(zPart * 100)) & " (Cts)"
                        End If
                        'Dim strTotal As String = "Arrêté la présente facture à la somme : " & stt
                        Dim strTotal As String = stt.Substring(0, 2).ToUpper() + stt.Substring(2)
                        g.DrawString(strTotal, fn, B, New RectangleF(xx, yy, a.width, a.height), sf)
                    ElseIf a.field.StartsWith("-") Then
                        Dim Str = CStr(a.designation)
                        Str &= title
                        g.DrawString(Str, fn, B, New RectangleF(xx, yy, a.width, a.height), sf)

                    ElseIf a.field.StartsWith("CLT") Then
                        Dim s = a.field.Split("_")(1)
                        Dim Str = CStr(a.designation)
                        Str &= dt_Client.Rows(0).Item(s)
                        Try
                            g.DrawString(Str, fn, B, New RectangleF(xx, yy, a.width, a.height), sf)
                        Catch ex As Exception
                        End Try
                    ElseIf a.field.StartsWith("RYL-") Then
                        Dim s = a.field.Split("-")(1)
                        Dim Str = CStr(a.designation)
                        Str &= CInt(data.Rows(0).Item(s) * 20).ToString("N0")
                        Try
                            sf.Alignment = StringAlignment.Far
                            g.DrawString(Str, fn, B, New RectangleF(xx, yy, a.width, a.height), sf)
                            sf.Alignment = StringAlignment.Near
                        Catch ex As Exception
                        End Try
                    ElseIf a.field.StartsWith("total") Then
                        If a.hasBloc Then
                            Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                            g.FillRectangle(_br, a.x + a.width, a.y, a.width, a.height)
                            g.DrawRectangle(pen, a.x + a.width, a.y, a.width, a.height)
                            xx += 5
                            yy += 3
                        End If

                        sf.Alignment = StringAlignment.Near
                        g.DrawString(CStr(a.designation), fn, B, New RectangleF(xx, yy, a.width, a.height), sf)
                        sf.Alignment = StringAlignment.Far
                        Try
                            Dim ttr As String = data.Rows(0).Item(a.field)
                            If isRYAL Then ttr = CInt(ttr)

                            g.DrawString(ttr, fn, B, New RectangleF(xx + a.width - 10, yy, a.width, a.height), sf)
                        Catch ex As Exception
                        End Try

                        sf.Alignment = StringAlignment.Near

                    ElseIf a.field.StartsWith("x_total") Then
                        If a.hasBloc Then
                            Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                            g.FillRectangle(_br, a.x + a.width, a.y, a.width, a.height)
                            g.DrawRectangle(pen, a.x + a.width, a.y, a.width, a.height)
                            xx += 5
                            yy += 3
                        End If

                        sf.Alignment = StringAlignment.Near
                        g.DrawString(CStr(a.designation), fn, B, New RectangleF(xx, yy, a.width, a.height), sf)
                        sf.Alignment = StringAlignment.Far
                        Try

                            '  Dim ttr As String = CDbl(data.Rows(0).Item("total_ttc")) + CDbl(data.Rows(0).Item("total_remise"))
                            Dim ttr As String = data.Rows(0).Item(a.field)
                            If isRYAL Then ttr = CInt(ttr)


                            g.DrawString(ttr, fn, B, New RectangleF(xx + a.width - 10, yy, a.width, a.height), sf)
                        Catch ex As Exception
                        End Try
                        sf.Alignment = StringAlignment.Near
                    ElseIf a.field.StartsWith("tableau") Then

                        Dim _x As Integer = a.x
                        Dim _y As Integer = a.y
                        Dim _wt As Integer = a.width
                        Dim _ht As Integer = a.height
                        Dim _xm As Integer = CInt(a.x + (_wt / 2))
                        g.DrawLine(Pens.Black, _x, _y, _x + _wt, _y)
                        g.DrawLine(Pens.Black, _x, _y + 15, _x + _wt, _y + 15)

                        g.DrawLine(Pens.Black, _x, _y, _x, _y + 30)
                        g.DrawLine(Pens.Black, _xm, _y, _xm, _y + 30)
                        g.DrawLine(Pens.Black, _x + _wt, _y, _x + _wt, _y + 30)
                        g.DrawString("Tva", fn, B, New RectangleF(_x + 5, _y, a.width, a.height), sf)
                        g.DrawString("Montant", fn, B, New RectangleF(_xm + 5, _y, a.width, a.height), sf)

                        _y += 20
                        For Each kvp As KeyValuePair(Of Double, Double) In params_tva
                            If kvp.Key = 0 Then Continue For

                            g.DrawLine(Pens.Black, _x, _y, _x, _y + 30)
                            g.DrawLine(Pens.Black, _xm, _y, _xm, _y + 30)
                            g.DrawLine(Pens.Black, _x + _wt, _y, _x + _wt, _y + 30)

                            g.DrawString("Tva  " & kvp.Key & " %", fn, B, New RectangleF(_x + 5, _y, CInt(_wt / 2) - 7, 15), sf)
                            g.DrawString(String.Format("{0:0.00}", CDbl(kvp.Value)), fn, B, New RectangleF(_xm, _y, CInt(_wt / 2) - 7, 15), sfl)

                            _y += 15
                        Next
                        g.DrawLine(Pens.Black, _x, _y + 15, _x + _wt, _y + 15)

                    ElseIf a.field.StartsWith("image") Then
                        Try
                            Dim fullPath As String = Path.Combine("C:\cmcimage", a.designation)
                            g.DrawImage(Image.FromFile(fullPath), xx, yy, a.width, a.height)
                        Catch ex As Exception
                        End Try

                    ElseIf a.field.StartsWith("DPT") Then
                        Dim s = a.field.Split("_")(1)
                        Dim str As String = CStr(a.designation)

                        If s = "ID" Then
                            str &= Form1._kvp.Key
                        Else
                            str &= Form1._kvp.Value
                        End If

                        Try
                            g.DrawString(str, fn, B, New RectangleF(xx, yy, a.width, a.height), sf)
                        Catch ex As Exception
                        End Try
                    Else
                        Try
                            Dim str As String = CStr(a.designation)
                            sf.Alignment = StringAlignment.Near
                            If a.field.StartsWith("*") = False Then str &= data.Rows(0).Item(a.field)
                            g.DrawString(str, fn, B, New RectangleF(xx, yy, a.width, a.height), sf)
                        Catch ex As Exception
                        End Try
                    End If

                    If _Ttype.ToUpper.StartsWith("TAB") = False Then a.y -= y
                Catch ex As Exception
                End Try
            Next
        End Using

        If _Ttype.ToUpper.StartsWith("LIS") = False Then g.DrawString("P-" & Form1.page_Number & "/" & Form1.page_Number, F_D, Brushes.Black, x_Page, y_Page)
        Form1.page_Number = 0
        m = 0
        'Return _Bmp
    End Sub


#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
