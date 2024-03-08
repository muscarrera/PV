Public Class DrawClass
    Implements IDisposable

    '*Members
    ' Private m As Integer = 0
    Private l As Integer = 250
    Public Sub DrawReceipt(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal dt As DataTable, ByVal fid As Integer,
                               ByVal CName As String, ByVal CAdresse As String, ByVal totalht As Double, ByVal totalttc As Double,
                               ByVal totaltva As Double, ByVal avance As Double, ByVal isSell As Boolean, ByVal dte As String,
                               ByVal remise As Double, ByRef m As Integer)

        Dim pen As New Pen(Brushes.Black, 1.0F)
        Dim pn As New Pen(Brushes.Black, 0.5F)

        Dim fnt As New Font(Form1.txtfname.Text, CInt(Form1.txtfntsize.Text))
        Dim fntTitle As New Font("Arial", 12, FontStyle.Bold)

        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Near
        Dim sf1 As New StringFormat()
        sf1.Alignment = StringAlignment.Far
        Dim sf2 As New StringFormat()
        sf2.Alignment = StringAlignment.Center

        Dim fctid As Integer = fid
        Dim clientName As String = CName
        Dim data As DataTable = dt
        Dim poids As Decimal = 0

        e.Graphics.DrawString(Form1.txttitle.Text, fntTitle, Brushes.Black, New RectangleF(10, 20, 300, 55), sf2)
        e.Graphics.DrawString(Form1.txttel.Text, fnt, Brushes.Black, New RectangleF(10, 80, 300, 30), sf2)

        Try
            e.Graphics.DrawImage(Image.FromFile(Form1.txtLogo.Text), 10, 10, 300, 120)
        Catch ex As Exception

        End Try

        e.Graphics.DrawString(Form1.TxtSignature.Text, fnt, Brushes.Black, 15, 145)

        Dim myPoints() As Point = New Point() {New Point(10, 160), New Point(270, 160),
                                               New Point(282, 175), New Point(270, 190),
                                               New Point(10, 190)}
        '  e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
        e.Graphics.DrawPolygon(New Pen(Brushes.Black, 0.5F), myPoints)

        'print date 
        e.Graphics.DrawString(dte, fnt, Brushes.Black, 15, 200)
        'print  num Facture 

        e.Graphics.DrawString("Receipt  N° : " & fctid, fntTitle, Brushes.Black, 15, 165)

        'print Client 
        e.Graphics.DrawString(clientName, fnt, Brushes.Black, 15, 215)
        e.Graphics.DrawString("*****  " & dt.Rows.Count & " - Vidals    |", fnt, Brushes.Black, 15, 230)

        e.Graphics.DrawString("Editeur :", fnt, Brushes.Black, 200, 200)
        e.Graphics.DrawString(Form1.adminName, fnt, Brushes.Black, 200, 215)

        If m > 0 Then
            e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 10, l)
            l += 15
        End If

        e.Graphics.DrawLine(pn, 10, l, 300, l)

        l = l + 10

        While m < data.Rows.Count

            'Dim ref As String = data.Rows(m).Item("code")
            Dim prdName As String = data.Rows(m).Item("name")
            Dim qte As String = String.Format("{0:n}", CDec(data.Rows(m).Item("qte")))
            Dim price As String = String.Format("{0:n}", CDec(data.Rows(m).Item("price")))
            Dim total As String = String.Format("{0:n}", CDec(data.Rows(m).Item("price") * data.Rows(m).Item("qte")))

            ''''''

            Dim size As SizeF = e.Graphics.MeasureString(prdName, fnt, 120)

            e.Graphics.DrawString(qte, fnt, Brushes.Black, New RectangleF(10, l, 40, size.Height), sf1)
            e.Graphics.DrawLine(pn, 52, l, 52, l + size.Height)
            e.Graphics.DrawString(prdName, fnt, Brushes.Black, New RectangleF(55, l, 120, size.Height), sf)
            e.Graphics.DrawLine(pn, 177, l, 177, l + size.Height)
            e.Graphics.DrawString(price, fnt, Brushes.Black, New RectangleF(180, l, 50, 25), sf1)
            e.Graphics.DrawLine(pn, 232, l, 232, l + size.Height)
            e.Graphics.DrawString(total, fnt, Brushes.Black, New RectangleF(230, l, 55, 25), sf1)

            l = l + size.Height + 5
            m += 1
        End While


        Dim ttc As String = String.Format("{0:n}", CDec(totalttc))

        l += 10

        e.Graphics.DrawLine(pn, 10, l, 300, l)
        e.Graphics.DrawLine(pn, 10, l + 2, 300, l + 2)

        l += 10

        e.Graphics.DrawString("Total  : ", fnt, Brushes.Black, New RectangleF(10, l, 200, 22), sf)
        e.Graphics.DrawString(ttc & " (Dhs)", fntTitle, Brushes.Black, New RectangleF(10, l + 20, 220, 22), sf)


        e.Graphics.FillRectangle(Brushes.Black, 5, l + 60, 280, 25)
        e.Graphics.DrawString("***  Merci  de  votre  visite  ***", New Font(fnt, FontStyle.Bold), Brushes.White, New RectangleF(5, l + 65, 280, 25), sf2)

        l = 250
        m = 0
    End Sub
    Public Sub DrawBon(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal dt As DataTable, ByVal fid As Integer, ByVal clid As Integer,
                           ByVal CName As String, ByVal CAdresse As String, ByVal totalht As Double, ByVal totalttc As Double, ByVal avance As Double,
                           ByVal totaltva As Double, ByVal isSell As Boolean, ByVal dte As String,
                           ByVal remise As Double, ByVal a As Double, ByVal isDevis As Boolean,
                           ByVal withou_price As Boolean, ByRef m As Integer, ByRef numPage As Integer)


        If Form1.chbreceipt.Checked Then
            If Form1.cbPaper.Text = "Normal&A4" Then
                'print A4
                If Form1.cbRTL.Checked Then
                    DrawBL_A5_Ar(e, dt, fid, clid, CName, CAdresse,
                                           totalht, totalttc, avance, totaltva, isSell,
                                           dte, remise, 1, isDevis, withou_price, m, numPage)
                Else
                    DrawBL_A5_Fr(e, dt, fid, clid, CName, CAdresse,
                                           totalht, totalttc, avance, totaltva, isSell,
                                           dte, remise, 1, isDevis, withou_price, m, numPage)
                End If


            Else
                If Form1.cbRTL.Checked Then
                    DrawReceipt_Ar(e, dt, fid, CName, CAdresse,
                                        totalht, totalttc, totaltva, avance, isSell, dte, remise, m)

                Else
                    DrawReceipt_FR(e, dt, fid, CName, CAdresse,
                                          totalht, totalttc, totaltva, avance, isSell, dte, remise, m)

                End If
            End If
        Else
            If Form1.cbBonToFact.Checked Then

            Else
                If Form1.txtScale.Text = 0 Then
                    DrawReceipt_FR(e, dt, fid, CName, CAdresse,
                             totalht, totalttc, totaltva, avance, isSell, dte, remise, m)
                Else
                    If Form1.cbRTL.Checked Then
                        DrawBL_A5_Ar(e, dt, fid, clid, CName, CAdresse,
                                               totalht, totalttc, avance, totaltva, isSell,
                                               dte, remise, Form1.txtScale.Text, isDevis, withou_price, m, numPage)
                    Else
                        DrawBL_A5_Fr(e, dt, fid, clid, CName, CAdresse,
                                               totalht, totalttc, avance, totaltva, isSell,
                                               dte, remise, Form1.txtScale.Text, isDevis, withou_price, m, numPage)
                    End If


                End If
            End If
        End If


    End Sub

    Public Sub DrawFacture(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal dt As DataTable, ByVal fid As Integer,
                           ByVal CName As String, ByVal CAdresse As String, ByVal totalht As Decimal, ByVal totalttc As Decimal,
                           ByVal totaltva As Decimal, ByVal isSell As Boolean, ByVal dte As Date,
                           ByVal remise As Decimal, ByVal iscache As Boolean, ByVal mode As String, ByRef m As Integer)
        Try


            Dim pen As New Pen(Brushes.Black, 1.0F)
            Dim pn As New Pen(Brushes.Black, 0.5F)

            Dim fnt As New Font(Form1.txtfname.Text, CInt(Form1.txtfntsize.Text))
            Dim fntTitle As New Font("Arial", 14, FontStyle.Bold)
            Dim fntsmall As New Font("Arial", 8)

            Dim sf As New StringFormat()
            sf.Alignment = StringAlignment.Near
            Dim sfR As New StringFormat()
            sfR.Alignment = StringAlignment.Far
            Dim sfC As New StringFormat()
            sfC.Alignment = StringAlignment.Center

            Dim fctid As Integer = fid
            Dim clientName As String = CName
            Dim data As DataTable = dt

            Dim myPoints() As Point = New Point() {New Point(60, 160), New Point(600, 160),
                                                   New Point(612, 175), New Point(600, 190),
                                                   New Point(60, 190)}
            e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            myPoints = {New Point(606, 160), New Point(770, 160),
                       New Point(770, 190), New Point(606, 190),
                       New Point(618, 175)}
            e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            'print date 
            e.Graphics.DrawString(dte.ToString("dd MMMM, yyyy"), fnt, Brushes.Black, New RectangleF(620, 167, 144, 24), sfR)
            'print  num Facture 
            If isSell Then
                e.Graphics.DrawString("Facture  N° : " & fctid, fntTitle, Brushes.Black, 65, 165)
            Else
                e.Graphics.DrawString("Bon de Commande  N° : " & fctid, fntTitle, Brushes.Black, 65, 165)
            End If

            'print Client 
            e.Graphics.DrawString("M : " & clientName, fnt, Brushes.Black, 65, 200)
            e.Graphics.DrawString(CAdresse, fnt, Brushes.Black, 65, 215)

            If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60, 230)

            Dim a As Integer = 0
            If remise > 0 And Form1.CbArticleRemise.Checked Then
                a = 50
                e.Graphics.DrawString("Remise", fnt, Brushes.Black, New RectangleF(630, l + 5, 40, 25), sfR)
                e.Graphics.DrawLine(pen, 630, l + 20, 670, l + 20)
            End If

            e.Graphics.DrawString("Designation", fnt, Brushes.Black, New RectangleF(60, l + 5, 460 - a, 25), sf)
            'e.Graphics.DrawString("Unite", fnt, Brushes.Black, New RectangleF(470, l + 5, 55, 25), sf)
            e.Graphics.DrawString("Qte", fnt, Brushes.Black, New RectangleF(525 - a, l + 5, 65, 25), sfR)
            e.Graphics.DrawString("P.U", fnt, Brushes.Black, New RectangleF(600 - a, l + 5, 70, 25), sfR)
            e.Graphics.DrawString("Total HT", fnt, Brushes.Black, New RectangleF(680, l + 5, 90, 25), sfR)

            pn.DashCap = System.Drawing.Drawing2D.DashCap.Round

            e.Graphics.DrawLine(pen, 60, l + 20, 515 - a, l + 20)
            'e.Graphics.DrawLine(pen, 470, l + 20, 515, l + 20)
            e.Graphics.DrawLine(pen, 525 - a, l + 20, 590, l + 20)
            e.Graphics.DrawLine(pen, 600 - a, l + 20, 670, l + 20)
            e.Graphics.DrawLine(pen, 680, l + 20, 770, l + 20)

            l = 280

            While m < data.Rows.Count

                If l + 180 > e.MarginBounds.Height Then
                    e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605, 870)
                    l = 250
                    e.HasMorePages = True
                    Return
                End If

                Dim Ref As String = data.Rows(m).Item("code")
                Dim prdName As String = data.Rows(m).Item("name")
                Dim unite As String = data.Rows(m).Item("unite")
                Dim qte As String = String.Format("{0:n}", CDec(data.Rows(m).Item("qte")))
                Dim price As String = String.Format("{0:n}", CDec(data.Rows(m).Item("price") / 1.2))
                Dim total As String = String.Format("{0:n}", CDec((data.Rows(m).Item("price") / 1.2) * data.Rows(m).Item("qte")))

                ''''''
                Dim size As SizeF = e.Graphics.MeasureString("[" & Ref & "]  " & prdName, fnt, 460 - a)

                e.Graphics.DrawString("[" & Ref & "]  " & prdName, fnt, Brushes.Black, New RectangleF(60, l, 460 - a, size.Height), sf)
                'e.Graphics.DrawString(unite, fnt, Brushes.Black, New RectangleF(471, l, 53, 17), sf)
                e.Graphics.DrawString(qte, fnt, Brushes.Black, New RectangleF(527 - a, l, 71, 25), sfR)
                e.Graphics.DrawString(price, fnt, Brushes.Black, New RectangleF(602 - a, l, 76, 25), sfR)
                e.Graphics.DrawString(total, fnt, Brushes.Black, New RectangleF(682, l, 90, 25), sfR)


                If a > 0 Then
                    e.Graphics.DrawString(data.Rows(m).Item("poid") & " %", fnt, Brushes.Black, New RectangleF(632, l + 5, 37, 25), sfR)
                End If

                l = l + size.Height + 5
                m += 1
            End While

            Dim ht As String = String.Format("{0:n}", totalht)
            Dim Ttva As String = String.Format("{0:n}", totaltva)
            Dim ttc As String = String.Format("{0:n}", totalttc)


            If l < 720 Then l = 720

            e.Graphics.DrawLine(pen, 60, l + 25, 770, l + 25)
            e.Graphics.DrawString("Total HT", fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf)
            e.Graphics.DrawString(ht, fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sfR)

            e.Graphics.DrawLine(pn, 550, l + 45, 770, l + 45)
            e.Graphics.DrawString("TVA", fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sf)
            e.Graphics.DrawString(Ttva, fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sfR)

            If remise > 0 Then
                e.Graphics.DrawLine(pn, 550, l + 65, 770, l + 65)
                e.Graphics.DrawString("Remise", fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sf)
                e.Graphics.DrawString(String.Format("{0:n}", CDec(remise)), fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sfR)
                l += 20
            End If

            If iscache Then
                e.Graphics.DrawLine(pn, 550, l + 65, 770, l + 65)
                e.Graphics.DrawString("Droit de timbre", fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sf)
                e.Graphics.DrawString(String.Format("{0:F}", (totalht - remise) * 0.0025), fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sfR)
                ttc = String.Format("{0:n}", CDec(totalttc + ((totalttc - remise) * 0.0025)))
                l += 20
            End If

            e.Graphics.DrawLine(pen, 550, l + 65, 770, l + 65)
            e.Graphics.DrawString("Total TTC (Dhs) ", fnt, Brushes.Black, New RectangleF(550, l + 70, 266, 22), sf)
            e.Graphics.DrawString(ttc, fntTitle, Brushes.Black, New RectangleF(550, l + 67, 220, 22), sfR)
            e.Graphics.DrawLine(pn, 550, l + 90, 770, l + 90)


            If iscache Then l -= 20
            If remise > 0 Then l -= 20

            Dim strTotal As String = "Arrêté la présente facture à la somme : " & NumericStrings.GetNumberWords(CDec(ttc)) & " (Dhs)"
            Dim sze As SizeF = e.Graphics.MeasureString(strTotal, fnt, 440)
            e.Graphics.DrawString(strTotal, fnt, Brushes.Black, New RectangleF(60, l + 25, 440, sze.Height), sf)

            e.Graphics.DrawLine(pn, 60, l + sze.Height + 35, 160, l + sze.Height + 35)
            e.Graphics.DrawString("* Mode de paiement : " & mode, fntsmall, Brushes.Black, New RectangleF(60, l + sze.Height + 45, 266, 22), sf)

        Catch ex As Exception
            l = 250
            m = 0
        End Try

        l = 250
        m = 0
    End Sub
    Public Sub DrawFacture2(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal dt As DataTable, ByVal fid As Integer,
                           ByVal CName As String, ByVal CAdresse As String, ByVal totalht As Decimal, ByVal totalttc As Decimal,
                           ByVal totaltva As Decimal, ByVal isSell As Boolean, ByVal Bl As String, ByVal dte As Date,
                           ByVal remise As Decimal, ByVal iscache As Boolean, ByVal Desgn As String, ByRef myTva As Dictionary(Of String, Double), ByRef m As Integer)
        Try


            Dim pen As New Pen(Brushes.Black, 1.0F)
            Dim pn As New Pen(Brushes.Black, 0.5F)

            Dim fnt As New Font(Form1.txtfname.Text, CInt(Form1.txtfntsize.Text))
            Dim fntTitle As New Font("Arial", 14, FontStyle.Bold)
            Dim fntsmall As New Font("Arial", 8)

            Dim sf As New StringFormat()
            sf.Alignment = StringAlignment.Near
            Dim sfR As New StringFormat()
            sfR.Alignment = StringAlignment.Far
            Dim sfC As New StringFormat()
            sfC.Alignment = StringAlignment.Center

            Dim fctid As Integer = fid
            Dim clientName As String = CName
            Dim data As DataTable = dt

            Dim myPoints() As Point = New Point() {New Point(60, 160), New Point(600, 160),
                                                   New Point(612, 175), New Point(600, 190),
                                                   New Point(60, 190)}
            e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            myPoints = {New Point(606, 160), New Point(770, 160),
                       New Point(770, 190), New Point(606, 190),
                       New Point(618, 175)}
            e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            'print date 
            e.Graphics.DrawString(dte.ToString("dd MMMM, yyyy"), fnt, Brushes.Black, New RectangleF(620, 167, 144, 24), sfR)
            'print  num Facture 
            If isSell Then
                e.Graphics.DrawString("Facture  N° : " & fctid, fntTitle, Brushes.Black, 65, 165)
            Else
                e.Graphics.DrawString("Bon de Commande  N° : " & fctid, fntTitle, Brushes.Black, 65, 165)
            End If

            'print Client 
            e.Graphics.DrawString("M : " & clientName, fnt, Brushes.Black, 65, 200)
            e.Graphics.DrawString(CAdresse, fnt, Brushes.Black, 65, 215)

            If Form1.cbBonToFact.Checked = True Then e.Graphics.DrawString("[ " & Desgn & " ]", fnt, Brushes.Black, 460, 215)

            If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60, 230)

            e.Graphics.DrawString("Designation", fnt, Brushes.Black, New RectangleF(60, l + 5, 400, 25), sf)
            'e.Graphics.DrawString("Unite", fnt, Brushes.Black, New RectangleF(470, l + 5, 55, 25), sf)
            e.Graphics.DrawString("Qte", fnt, Brushes.Black, New RectangleF(465, l + 5, 60, 25), sfR)
            e.Graphics.DrawString("P.U ", fnt, Brushes.Black, New RectangleF(530, l + 5, 90, 25), sfR)
            e.Graphics.DrawString("TVA ", fnt, Brushes.Black, New RectangleF(625, l + 5, 55, 25), sfR)
            e.Graphics.DrawString("Total", fnt, Brushes.Black, New RectangleF(685, l + 5, 90, 25), sfR)

            pn.DashCap = System.Drawing.Drawing2D.DashCap.Round

            e.Graphics.DrawLine(pen, 60, l + 20, 460, l + 20)
            e.Graphics.DrawLine(pen, 465, l + 20, 525, l + 20)
            e.Graphics.DrawLine(pen, 530, l + 20, 620, l + 20)
            e.Graphics.DrawLine(pen, 625, l + 20, 680, l + 20)
            e.Graphics.DrawLine(pen, 685, l + 20, 770, l + 20)

            l = 280

            While m < data.Rows.Count

                If l + 180 > e.MarginBounds.Height Then
                    e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605, 870)
                    l = 250
                    e.HasMorePages = True
                    Return
                End If

                Dim Ref As String = data.Rows(m).Item("code")
                Dim prdName As String = data.Rows(m).Item("name")
                Dim unite As String = data.Rows(m).Item("unite")
                Dim tva As String = String.Format("{0:n}", CDec(data.Rows(m).Item("tva")))
                Dim qte As String = String.Format("{0:n}", CDec(data.Rows(m).Item("qte")))
                Dim price As String = String.Format("{0:n}", CDec(data.Rows(m).Item("price")))
                Dim total As String = String.Format("{0:n}", CDec((data.Rows(m).Item("price") * data.Rows(m).Item("qte"))))

                ''''''
                Dim size As SizeF = e.Graphics.MeasureString("[" & Ref & "]  " & prdName, fnt, 395)

                e.Graphics.DrawString("[" & Ref & "]  " & prdName, fnt, Brushes.Black, New RectangleF(60, l, 400, size.Height), sf)
                'e.Graphics.DrawString(unite, fnt, Brushes.Black, New RectangleF(471, l, 53, 17), sf)
                e.Graphics.DrawString(qte, fnt, Brushes.Black, New RectangleF(465, l, 60, 25), sfR)
                e.Graphics.DrawString(price, fnt, Brushes.Black, New RectangleF(530, l, 90, 25), sfR)
                e.Graphics.DrawString(tva & " %", fnt, Brushes.Black, New RectangleF(625, l, 55, 25), sfR)
                e.Graphics.DrawString(total, fnt, Brushes.Black, New RectangleF(685, l, 90, 25), sfR)

                Try
                    If Form1.CBTVA.Checked Then
                        If myTva.ContainsKey(data.Rows(m).Item("tva")) Then
                            Dim _tva As Decimal = data.Rows(m).Item("totaltva")
                            myTva(data.Rows(m).Item("tva")) += _tva
                        Else
                            If data.Rows(m).Item("tva") > 0 Then
                                Dim _tva As Decimal = data.Rows(m).Item("totaltva")
                                myTva.Add(data.Rows(m).Item("tva"), _tva)
                            End If
                        End If
                    End If
                Catch ex As Exception

                End Try

                l = l + size.Height + 5
                m += 1
            End While

            Dim ht As String = String.Format("{0:n}", CDec(totalht))
            Dim Ttva As String = String.Format("{0:n}", CDec(totaltva))
            Dim ttc As String = String.Format("{0:n}", CDec(totalttc))


            If l < 720 Then l = 720

            e.Graphics.DrawLine(pen, 60, l + 25, 770, l + 25)
            e.Graphics.DrawString("Total HT", fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf)
            e.Graphics.DrawString(ht, fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sfR)

            e.Graphics.DrawLine(pn, 550, l + 45, 770, l + 45)
            e.Graphics.DrawString("TVA", fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sf)
            e.Graphics.DrawString(Ttva, fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sfR)

            If remise > 0 Then
                e.Graphics.DrawLine(pn, 550, l + 65, 770, l + 65)
                e.Graphics.DrawString("Remise", fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sf)
                e.Graphics.DrawString(String.Format("{0:F}", remise), fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sfR)
                l += 20
            End If

            If iscache Then
                e.Graphics.DrawLine(pn, 550, l + 65, 770, l + 65)
                e.Graphics.DrawString("Droit de timbre", fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sf)
                e.Graphics.DrawString(String.Format("{0:F}", totalht * 0.0025), fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sfR)
                ttc = String.Format("{0:n}", CDec(totalttc + (totalttc * 0.0025)))
                l += 20
            End If

            e.Graphics.DrawLine(pen, 550, l + 65, 770, l + 65)
            e.Graphics.DrawString("Total TTC (Dhs) ", fnt, Brushes.Black, New RectangleF(550, l + 70, 266, 22), sf)
            e.Graphics.DrawString(ttc, fntTitle, Brushes.Black, New RectangleF(550, l + 67, 220, 22), sfR)
            e.Graphics.DrawLine(pn, 550, l + 90, 770, l + 90)

            ''''''
            If Form1.CBTVA.Checked Then
                e.Graphics.DrawLine(pn, 60, l + 65, 500, l + 65)
                Dim _x As Integer = 60
                Dim _y As Integer = l + 70
                Dim _i As Integer = 0

                For Each kvp As KeyValuePair(Of String, Double) In myTva

                    Dim _t As String = String.Format("{0:n}", CDec(kvp.Value))

                    Dim size As SizeF = e.Graphics.MeasureString("TVA [" & kvp.Key & "%]  = " & _t, fnt)

                    If _x + size.Width > 440 Then
                        _x = 60
                        _y = _y + 15
                        e.Graphics.DrawLine(pn, 60, l + 45, 500, _y)
                    End If

                    e.Graphics.DrawString("TVA [" & kvp.Key & "%]  = " & _t, fnt, Brushes.Black, New RectangleF(_x, _y, 440 - _x, 22), sf)
                    e.Graphics.DrawLine(pn, _x + size.Width + 5, _y, _x + size.Width + 5, _y + 15)
                    _x += size.Width + 10
                Next
                e.Graphics.DrawLine(pn, 60, _y + 20, 500, _y + 20)
            End If
            '''''


            If iscache Then l -= 20
            If remise > 0 Then l -= 20

            Dim strTotal As String = "Arrêté la présente facture à la somme : " & NumericStrings.GetNumberWords(CDec(ttc)) & " (Dhs)"
            Dim sze As SizeF = e.Graphics.MeasureString(strTotal, fnt, 440)
            e.Graphics.DrawString(strTotal, fnt, Brushes.Black, New RectangleF(60, l + 25, 440, sze.Height), sf)

            If iscache Then
                e.Graphics.DrawLine(pn, 60, l + sze.Height + 75, 160, l + sze.Height + 35)
                e.Graphics.DrawString("* facture régler en espece", fntsmall, Brushes.Black, New RectangleF(60, l + sze.Height + 65, 266, 22), sf)
            End If
        Catch ex As Exception
            l = 250
            m = 0
            myTva.Clear()
        End Try
        myTva.Clear()
        l = 250
        m = 0
    End Sub
    Public Sub DrawFactureWithRemise(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal dt As DataTable, ByVal fid As Integer,
                           ByVal CName As String, ByVal CAdresse As String, ByVal totalht As Decimal, ByVal totalttc As Decimal,
                           ByVal totaltva As Decimal, ByVal isSell As Boolean, ByVal Bl As String, ByVal dte As Date,
                           ByVal remise As Decimal, ByVal iscache As Boolean, ByVal Desgn As String, ByRef myTva As Dictionary(Of String, Double), ByRef m As Integer)
        Try


            Dim pen As New Pen(Brushes.Black, 1.0F)
            Dim pn As New Pen(Brushes.Black, 0.5F)

            Dim fnt As New Font(Form1.txtfname.Text, CInt(Form1.txtfntsize.Text))
            Dim fntTitle As New Font("Arial", 14, FontStyle.Bold)
            Dim fntsmall As New Font("Arial", 8)

            Dim sf As New StringFormat()
            sf.Alignment = StringAlignment.Near
            Dim sfR As New StringFormat()
            sfR.Alignment = StringAlignment.Far
            Dim sfC As New StringFormat()
            sfC.Alignment = StringAlignment.Center

            Dim fctid As Integer = fid
            Dim clientName As String = CName
            Dim data As DataTable = dt

            Dim myPoints() As Point = New Point() {New Point(60, 160), New Point(600, 160),
                                                   New Point(612, 175), New Point(600, 190),
                                                   New Point(60, 190)}
            e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            myPoints = {New Point(606, 160), New Point(770, 160),
                       New Point(770, 190), New Point(606, 190),
                       New Point(618, 175)}
            e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            'print date 
            e.Graphics.DrawString(dte.ToString("dd MMMM, yyyy"), fnt, Brushes.Black, New RectangleF(620, 167, 144, 24), sfR)
            'print  num Facture 
            If isSell Then
                e.Graphics.DrawString("Facture  N° : " & fctid, fntTitle, Brushes.Black, 65, 165)
            Else
                e.Graphics.DrawString("Bon de Commande  N° : " & fctid, fntTitle, Brushes.Black, 65, 165)
            End If

            'print Client 
            e.Graphics.DrawString("M : " & clientName, fnt, Brushes.Black, 65, 200)
            e.Graphics.DrawString(CAdresse, fnt, Brushes.Black, 65, 215)

            If Form1.cbBonToFact.Checked = True Then e.Graphics.DrawString("[ " & Desgn & " ]", fnt, Brushes.Black, 460, 215)

            If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60, 230)

            e.Graphics.DrawString("Designation", fnt, Brushes.Black, New RectangleF(60, l + 5, 350, 25), sf)
            'e.Graphics.DrawString("Unite", fnt, Brushes.Black, New RectangleF(470, l + 5, 55, 25), sf)
            e.Graphics.DrawString("Qte", fnt, Brushes.Black, New RectangleF(415, l + 5, 60, 25), sfR)
            e.Graphics.DrawString("P.U ", fnt, Brushes.Black, New RectangleF(480, l + 5, 80, 25), sfR)
            If remise > 0 Then
                e.Graphics.DrawString("Remise", fnt, Brushes.Black, New RectangleF(565, l + 5, 55, 25), sfR)
            End If
            e.Graphics.DrawString("TVA ", fnt, Brushes.Black, New RectangleF(625, l + 5, 55, 25), sfR)
            e.Graphics.DrawString("Total", fnt, Brushes.Black, New RectangleF(685, l + 5, 90, 25), sfR)

            pn.DashCap = System.Drawing.Drawing2D.DashCap.Round

            e.Graphics.DrawLine(pen, 60, l + 20, 410, l + 20)
            e.Graphics.DrawLine(pen, 415, l + 20, 475, l + 20)
            e.Graphics.DrawLine(pen, 480, l + 20, 560, l + 20)
            e.Graphics.DrawLine(pen, 565, l + 20, 620, l + 20)
            e.Graphics.DrawLine(pen, 625, l + 20, 680, l + 20)
            e.Graphics.DrawLine(pen, 685, l + 20, 770, l + 20)

            l = 280

            While m < data.Rows.Count

                If l + 180 > e.MarginBounds.Height Then
                    e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605, 870)
                    l = 250
                    e.HasMorePages = True
                    Return
                End If

                Dim Ref As String = data.Rows(m).Item("code")
                Dim prdName As String = data.Rows(m).Item("name")
                Dim unite As String = data.Rows(m).Item("unite")
                Dim tva As String = String.Format("{0:n}", CDec(data.Rows(m).Item("tva")))
                Dim qte As String = String.Format("{0:n}", CDec(data.Rows(m).Item("qte")))
                Dim price As String = String.Format("{0:n}", CDec(data.Rows(m).Item("price")))
                Dim total As String = String.Format("{0:n}", CDec(data.Rows(m).Item("total")))
                Dim rm As String = String.Format("{0:n}", CDec(data.Rows(m).Item("poid") / 100))

                ''''''
                Dim size As SizeF = e.Graphics.MeasureString("[" & Ref & "]  " & prdName, fnt, 395)

                e.Graphics.DrawString("[" & Ref & "]  " & prdName, fnt, Brushes.Black, New RectangleF(60, l, 350, size.Height), sf)
                'e.Graphics.DrawString(unite, fnt, Brushes.Black, New RectangleF(471, l, 53, 17), sf)
                e.Graphics.DrawString(qte, fnt, Brushes.Black, New RectangleF(415, l, 60, 25), sfR)
                e.Graphics.DrawString(price, fnt, Brushes.Black, New RectangleF(480, l, 80, 25), sfR)
                If rm > 0 Then e.Graphics.DrawString(rm & " %", fnt, Brushes.Black, New RectangleF(565, l, 55, 25), sfR)
                e.Graphics.DrawString(tva & " %", fnt, Brushes.Black, New RectangleF(625, l, 55, 25), sfR)
                e.Graphics.DrawString(total, fnt, Brushes.Black, New RectangleF(685, l, 90, 25), sfR)

                Try
                    If Form1.CBTVA.Checked Then
                        If myTva.ContainsKey(data.Rows(m).Item("tva")) Then
                            Dim _tva As Decimal = data.Rows(m).Item("totaltva")
                            myTva(data.Rows(m).Item("tva")) += _tva
                        Else
                            If data.Rows(m).Item("tva") > 0 Then
                                Dim _tva As Decimal = data.Rows(m).Item("totaltva")
                                myTva.Add(data.Rows(m).Item("tva"), _tva)
                            End If
                        End If
                    End If
                Catch ex As Exception

                End Try

                l = l + size.Height + 5
                m += 1
            End While

            Dim ht As String = String.Format("{0:n}", CDec(totalht))
            Dim Ttva As String = String.Format("{0:n}", CDec(totaltva))
            Dim ttc As String = String.Format("{0:n}", CDec(totalttc))


            If l < 720 Then l = 720

            e.Graphics.DrawLine(pen, 60, l + 25, 770, l + 25)
            e.Graphics.DrawString("Total HT", fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf)
            e.Graphics.DrawString(ht, fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sfR)

            e.Graphics.DrawLine(pn, 550, l + 45, 770, l + 45)
            e.Graphics.DrawString("TVA", fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sf)
            e.Graphics.DrawString(Ttva, fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sfR)

            If remise > 0 Then
                e.Graphics.DrawLine(pn, 550, l + 65, 770, l + 65)
                e.Graphics.DrawString("Remise", fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sf)
                e.Graphics.DrawString(String.Format("{0:F}", remise), fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sfR)
                l += 20
            End If

            If iscache Then
                e.Graphics.DrawLine(pn, 550, l + 65, 770, l + 65)
                e.Graphics.DrawString("Droit de timbre", fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sf)
                e.Graphics.DrawString(String.Format("{0:F}", totalht * 0.0025), fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sfR)
                ttc = String.Format("{0:n}", CDec(totalttc + (totalttc * 0.0025)))
                l += 20
            End If

            e.Graphics.DrawLine(pen, 550, l + 65, 770, l + 65)
            e.Graphics.DrawString("Total TTC (Dhs) ", fnt, Brushes.Black, New RectangleF(550, l + 70, 266, 22), sf)
            e.Graphics.DrawString(ttc, fntTitle, Brushes.Black, New RectangleF(550, l + 67, 220, 22), sfR)
            e.Graphics.DrawLine(pn, 550, l + 90, 770, l + 90)

            ''''''
            If Form1.CBTVA.Checked Then
                e.Graphics.DrawLine(pn, 60, l + 65, 500, l + 65)
                Dim _x As Integer = 60
                Dim _y As Integer = l + 70
                Dim _i As Integer = 0

                For Each kvp As KeyValuePair(Of String, Double) In myTva

                    Dim _t As String = String.Format("{0:n}", CDec(kvp.Value))

                    Dim size As SizeF = e.Graphics.MeasureString("TVA [" & kvp.Key & "%]  = " & _t, fnt)

                    If _x + size.Width > 440 Then
                        _x = 60
                        _y = _y + 15
                        e.Graphics.DrawLine(pn, 60, l + 45, 500, _y)
                    End If

                    e.Graphics.DrawString("TVA [" & kvp.Key & "%]  = " & _t, fnt, Brushes.Black, New RectangleF(_x, _y, 440 - _x, 22), sf)
                    e.Graphics.DrawLine(pn, _x + size.Width + 5, _y, _x + size.Width + 5, _y + 15)
                    _x += size.Width + 10
                Next
                e.Graphics.DrawLine(pn, 60, _y + 20, 500, _y + 20)
            End If
            '''''


            If iscache Then l -= 20
            If remise > 0 Then l -= 20

            Dim strTotal As String = "Arrêté la présente facture à la somme : " & NumericStrings.GetNumberWords(CDec(ttc)) & " (Dhs)"
            Dim sze As SizeF = e.Graphics.MeasureString(strTotal, fnt, 440)
            e.Graphics.DrawString(strTotal, fnt, Brushes.Black, New RectangleF(60, l + 25, 440, sze.Height), sf)

            If iscache Then
                e.Graphics.DrawLine(pn, 60, l + sze.Height + 75, 160, l + sze.Height + 35)
                e.Graphics.DrawString("* facture régler en espece", fntsmall, Brushes.Black, New RectangleF(60, l + sze.Height + 65, 266, 22), sf)
            End If
        Catch ex As Exception
            l = 250
            m = 0
            myTva.Clear()
        End Try
        myTva.Clear()
        l = 250
        m = 0
    End Sub

    Public Sub DrawDevis(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal dt As DataTable, ByVal fid As Integer,
                           ByVal CName As String, ByVal CAdresse As String, ByVal totalht As Double, ByVal totalttc As Double,
                           ByVal totaltva As Double, ByVal isSell As Boolean, ByVal Bl As String, ByVal dte As Date,
                           ByVal remise As Double, ByVal iscache As Boolean, ByVal Desgn As String, ByVal withou_price As Boolean, ByRef m As Integer)
        Try
            Dim pen As New Pen(Brushes.Black, 1.0F)
            Dim pn As New Pen(Brushes.Black, 0.5F)

            Dim fnt As New Font(Form1.txtfname.Text, CInt(Form1.txtfntsize.Text))
            Dim fntTitle As New Font("Arial", 14, FontStyle.Bold)
            Dim fntsmall As New Font("Arial", 8)

            Dim sf As New StringFormat()
            sf.Alignment = StringAlignment.Near
            Dim sfR As New StringFormat()
            sfR.Alignment = StringAlignment.Far
            Dim sfC As New StringFormat()
            sfC.Alignment = StringAlignment.Center

            Dim fctid As Integer = fid
            Dim clientName As String = CName
            Dim data As DataTable = dt

            Dim myPoints() As Point = New Point() {New Point(60, 160), New Point(600, 160),
                                                   New Point(612, 175), New Point(600, 190),
                                                   New Point(60, 190)}
            e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            myPoints = {New Point(606, 160), New Point(770, 160),
                       New Point(770, 190), New Point(606, 190),
                       New Point(618, 175)}
            e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            'print date 
            e.Graphics.DrawString(dte.ToString("dd MMMM, yyyy"), fnt, Brushes.Black, New RectangleF(620, 167, 144, 24), sfR)
            'print  num Facture 
            If isSell Then
                e.Graphics.DrawString("Devis  N° : " & fctid, fntTitle, Brushes.Black, 65, 165)
            Else
                e.Graphics.DrawString("Bon de Commande  N° : " & fctid, fntTitle, Brushes.Black, 65, 165)
            End If

            'print Client 
            e.Graphics.DrawString("M : " & clientName, fnt, Brushes.Black, 65, 200)
            e.Graphics.DrawString(CAdresse, fnt, Brushes.Black, 65, 215)

            If Form1.cbBonToFact.Checked = True Then e.Graphics.DrawString("[ " & Desgn & " ]", fnt, Brushes.Black, 460, 215)

            If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60, 230)

            e.Graphics.DrawString("Designation", fnt, Brushes.Black, New RectangleF(60, l + 5, 400, 25), sf)
            'e.Graphics.DrawString("Unite", fnt, Brushes.Black, New RectangleF(470, l + 5, 55, 25), sf)
            e.Graphics.DrawString("Qte", fnt, Brushes.Black, New RectangleF(465, l + 5, 60, 25), sfR)
            e.Graphics.DrawString("P.U ", fnt, Brushes.Black, New RectangleF(530, l + 5, 90, 25), sfR)
            e.Graphics.DrawString("tva ", fnt, Brushes.Black, New RectangleF(625, l + 5, 55, 25), sfR)
            e.Graphics.DrawString("Total", fnt, Brushes.Black, New RectangleF(685, l + 5, 90, 25), sfR)

            pn.DashCap = System.Drawing.Drawing2D.DashCap.Round

            e.Graphics.DrawLine(pen, 60, l + 20, 460, l + 20)
            e.Graphics.DrawLine(pen, 465, l + 20, 525, l + 20)
            e.Graphics.DrawLine(pen, 530, l + 20, 620, l + 20)
            e.Graphics.DrawLine(pen, 625, l + 20, 680, l + 20)
            e.Graphics.DrawLine(pen, 685, l + 20, 770, l + 20)

            l = 280

            While m < data.Rows.Count

                If l + 180 > e.MarginBounds.Height Then
                    e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605, 870)
                    l = 250
                    e.HasMorePages = True
                    Return
                End If

                Dim Ref As String = data.Rows(m).Item("code")
                Dim unite As String = data.Rows(m).Item("unite")
                Dim prdName As String = data.Rows(m).Item("name") & " (" & unite & ")"

                Dim tva As Double = data.Rows(m).Item("tva")
                Dim qte As String = String.Format("{0:n}", CDec(data.Rows(m).Item("qte")))
                Dim price As String = String.Format("{0:n}", CDec(data.Rows(m).Item("price")))
                Dim total As String = String.Format("{0:n}", CDec(data.Rows(m).Item("price") * data.Rows(m).Item("qte")))

                ''''''
                Dim size As SizeF = e.Graphics.MeasureString("[" & Ref & "]  " & prdName, fnt, 390)

                e.Graphics.DrawString("[" & Ref & "]  " & prdName, fnt, Brushes.Black, New RectangleF(60, l, 400, size.Height), sf)
                'e.Graphics.DrawString(unite, fnt, Brushes.Black, New RectangleF(471, l, 53, 17), sf)
                e.Graphics.DrawString(qte, fnt, Brushes.Black, New RectangleF(465, l, 60, 25), sfR)
                If withou_price = False Then
                    e.Graphics.DrawString(price, fnt, Brushes.Black, New RectangleF(530, l, 90, 25), sfR)
                    e.Graphics.DrawString(tva & " %", fnt, Brushes.Black, New RectangleF(625, l, 55, 25), sfR)
                    e.Graphics.DrawString(total, fnt, Brushes.Black, New RectangleF(685, l, 90, 25), sfR)
                End If

                l = l + size.Height + 5
                m += 1
            End While

            Dim ht As String = String.Format("{0:n}", CDec(totalht))
            Dim Ttva As String = String.Format("{0:n}", CDec(totaltva))
            Dim ttc As String = String.Format("{0:n}", CDec(totalttc))

            If withou_price = False Then

                If l < 720 Then l = 720

                e.Graphics.DrawLine(pen, 60, l + 25, 770, l + 25)
                e.Graphics.DrawString("Total HT", fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf)
                e.Graphics.DrawString(ht, fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sfR)

                e.Graphics.DrawLine(pn, 550, l + 45, 770, l + 45)
                e.Graphics.DrawString("TVA", fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sf)
                e.Graphics.DrawString(Ttva, fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sfR)

                If remise > 0 Then
                    e.Graphics.DrawLine(pn, 550, l + 65, 770, l + 65)
                    e.Graphics.DrawString("Remise", fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sf)
                    e.Graphics.DrawString(String.Format("{0:F}", remise), fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sfR)
                    l += 20
                End If

                e.Graphics.DrawLine(pen, 550, l + 65, 770, l + 65)
                e.Graphics.DrawString("Total TTC (Dhs) ", fnt, Brushes.Black, New RectangleF(550, l + 70, 266, 22), sf)
                e.Graphics.DrawString(ttc, fntTitle, Brushes.Black, New RectangleF(550, l + 67, 220, 22), sfR)
                e.Graphics.DrawLine(pn, 550, l + 90, 770, l + 90)

                If iscache Then l -= 20
                If remise > 0 Then l -= 20

                If isSell Then
                    Dim strTotal As String = "Arrêté la présent DEVIS à la somme : " & NumericStrings.GetNumberWords(CDec(ttc)) & " (Dhs)"
                    Dim sze As SizeF = e.Graphics.MeasureString(strTotal, fnt, 440)
                    e.Graphics.DrawString(strTotal, fnt, Brushes.Black, New RectangleF(60, l + 25, 440, sze.Height), sf)
                End If
            End If
        Catch ex As Exception
            l = 250
            m = 0
        End Try

        l = 250
        m = 0
    End Sub

    Public Sub DrawBL_A5_Ar(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal dt As DataTable, ByVal fid As Integer, ByVal clid As Integer,
                           ByVal CName As String, ByVal CAdresse As String, ByVal totalht As Double, ByVal totalttc As Double, ByVal avance As Double,
                           ByVal totaltva As Double, ByVal isSell As Boolean, ByVal dte As String,
                           ByVal remise As Double, ByVal a As Double, ByVal isDevis As Boolean,
                           ByVal withou_price As Boolean, ByRef m As Integer, ByRef numPages As Integer)

        Dim pen As New Pen(Brushes.Black, 1.0F)
        Dim pn As New Pen(Brushes.Black, 0.5F)

        Dim fnt As New Font(Form1.txtfname.Text, CInt(Form1.txtfntsize.Text))
        Dim fntTitle As New Font("Arial", 14, FontStyle.Bold)

        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Near
        Dim sf1 As New StringFormat()
        sf1.Alignment = StringAlignment.Far
        Dim sf2 As New StringFormat()
        sf2.Alignment = StringAlignment.Center

        Dim fctid As Integer = fid
        Dim clientName As String = CName
        Dim data As DataTable = dt


        Dim m_Entete = Form1.txtEnteteMarge.Text
        If Not IsNumeric(m_Entete) Then m_Entete = 160

        Dim m_Pied = Form1.txtPiedMarge.Text
        If Not IsNumeric(m_Pied) Then m_Pied = 750

        l = m_Entete


        Dim rest As Decimal = totalttc - avance

        Try
            e.Graphics.DrawImage(Image.FromFile(Form1.txtLogo.Text), 10, 10, 750, 120)
        Catch ex As Exception
        End Try

        Dim myPoints() As Point = New Point() {New Point(60 * a, l), New Point(600 * a, l),
                                               New Point(612 * a, l + 15), New Point(600 * a, l + 30),
                                               New Point(60 * a, l + 30)}
        e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
        e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

        myPoints = {New Point(606 * a, l), New Point(770 * a, l),
                   New Point(770 * a, l + 30), New Point(606 * a, l + 30),
                   New Point(618 * a, l + 15)}
        e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
        e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

        'print date 
        e.Graphics.DrawString(dte, fnt, Brushes.Black, New RectangleF(600 * a, l + 7, 164 * a, 30), sf1)
        'print  num Facture 
        If isSell Then
            If isDevis Then
                e.Graphics.DrawString("Devis  N° : " & fctid, fntTitle, Brushes.Black, 65 * a, l + 5)

            Else
                e.Graphics.DrawString("Bon de Livraison  N° : " & fctid, fntTitle, Brushes.Black, 65 * a, l + 5)

            End If
        Else
            e.Graphics.DrawString("Bon de Commande  N° : " & fctid, fntTitle, Brushes.Black, 65 * a, l + 5)
        End If

        Try
            'print Client 
            e.Graphics.DrawString("M : " & clientName, fnt, Brushes.Black, 65 * a, l + 40)
            e.Graphics.DrawString(CAdresse, fnt, Brushes.Black, 65 * a, l + 55)

        Catch ex As Exception

        End Try

        l += 60

        If m > 0 Then
            e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60 * a, l)
            l += 15
        End If


        'Draw the table  e.MarginBounds.Height
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, CInt(60 * a), l, CInt(710 * a), 25)
        'e.Graphics.DrawRectangle(pen, CInt(60 * a), CInt(l * a), CInt(710 * a), CInt(600 * a))
        e.Graphics.DrawRectangle(pen, CInt(60 * a), l, CInt(710 * a), CInt(m_Pied - l))
        e.Graphics.DrawLine(pn, CInt(60 * a), l + 25, CInt(770 * a), l + 25)

        'e.Graphics.DrawLine(pn, 420, l, 420, 850)
        e.Graphics.DrawLine(pn, CInt(201 * a), l, CInt(201 * a), CInt(m_Pied)) ' CInt(850 * a))
        e.Graphics.DrawLine(pn, CInt(282 * a), l, CInt(282 * a), CInt(m_Pied))
        e.Graphics.DrawLine(pn, CInt(697 * a), l, CInt(697 * a), CInt(m_Pied))

        e.Graphics.DrawString("المواد", fnt, Brushes.Black, New RectangleF(284 * a, (l + 5), 410 * a, 25), sf2)
        'e.Graphics.DrawString("Unite", fnt, Brushes.Black, New RectangleF(420, l + 5, 55, 25), sf2)
        e.Graphics.DrawString("الكمية", fnt, Brushes.Black, New RectangleF(699 * a, (l + 5), 71 * a, 25), sf2)
        e.Graphics.DrawString("الثمن", fnt, Brushes.Black, New RectangleF(203 * a, (l + 5), 76 * a, 25), sf2)
        e.Graphics.DrawString("المجموع ", fnt, Brushes.Black, New RectangleF(62 * a, (l + 5), 136 * a, 25), sf2)

        l += 30

        While m < data.Rows.Count

            If (l + 20) > CInt(m_Pied) Then
                e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605 * a, CInt(m_Pied) + 5)
                e.Graphics.DrawString("N° : " & fctid & " // P: " & numPages, fnt, Brushes.Black, 15, CInt(m_Pied) + 130)
                numPages += 1
                l = m_Entete
                e.HasMorePages = True
                Return
            End If

            Dim ref As String = data.Rows(m).Item("code")
            Dim prdName As String = data.Rows(m).Item("name") ' & " " & ref
            'Dim unite As String = data.Rows(m).Item("unite")
            Dim qte As String = data.Rows(m).Item("qte")
            Dim price As String = String.Format("{0:n}", CDec(data.Rows(m).Item("price")))
            Dim total As String = String.Format("{0:n}", CDec(data.Rows(m).Item("total")))
            Dim re As Decimal = CDec(data.Rows(m).Item("poid") / 100)

            If re > 0 And Form1.CbArticleRemise.Checked Then prdName &= " *(Remise:" & String.Format("{0:n}", re) & "%)*"

            ''''''
            Dim size As SizeF = e.Graphics.MeasureString(prdName, fnt, CInt(410 * a))

            ''''''''''''''carré
            'e.Graphics.DrawRectangle(Pens.Black, CInt(780 * a), CInt(l + 2), 10, 10)

            e.Graphics.DrawString(prdName, fnt, Brushes.Black, New RectangleF(284 * a, l, 410 * a, size.Height), sf1)
            'e.Graphics.DrawString(unite, fnt, Brushes.Black, New RectangleF(421, l, 51, 17), sf)
            e.Graphics.DrawString(qte, fnt, Brushes.Black, New RectangleF(699 * a, l, 71 * a, 25), sf1)
            If withou_price = False Then
                e.Graphics.DrawString(price, fnt, Brushes.Black, New RectangleF(203 * a, l, 76 * a, 25), sf1)
                e.Graphics.DrawString(total, fnt, Brushes.Black, New RectangleF(62 * a, l, 136 * a, 25), sf1)
            End If

            l = l + size.Height + 5
            m += 1
        End While

        Dim ht As String = String.Format("{0:n}", CDec(totalht))
        Dim Ttva As String = String.Format("{0:n}", CDec(totaltva))
        Dim ttc As String = String.Format("{0:n}", CDec(totalttc))

        If withou_price = False Then
            Dim h As Integer = 32

            'e.MarginBounds.Height 
            If remise > 0 Then h = 60
            If isDevis = False Then h = 115


            e.Graphics.DrawLine(pn, CInt(550 * a), CInt(m_Pied) + 5, CInt(770 * a), CInt(m_Pied) + 5)
            'e.Graphics.DrawLine(pn, CInt(550 * a), e.MarginBounds.Height + 25, CInt(770 * a), e.MarginBounds.Height + 25)

            e.Graphics.DrawString("Total  ", fnt, Brushes.Black, New RectangleF(552 * a, CInt(m_Pied) + 10, 60 * a, 22), sf)
            e.Graphics.DrawString(ttc & " (Dhs)", fnt, Brushes.Black, New RectangleF(615 * a, CInt(m_Pied) + 10, 120, 22), sf)

            e.Graphics.DrawString(dt.Rows.Count & "Vidals", fnt, Brushes.Black, New RectangleF(60 * a, CInt(m_Pied) + 10, 260 * a, 22), sf)

            h = 28

            If remise > 0 Then
                e.Graphics.DrawLine(pn, CInt(550 * a), CInt(m_Pied) + 60, CInt(770 * a), CInt(m_Pied) + 60)
                e.Graphics.DrawString("Remise : ", fnt, Brushes.Black, New RectangleF(552 * a, CInt(m_Pied) + h, 60 * a, 22), sf)
                e.Graphics.DrawString(String.Format("{0:n}", CDec(remise)) & " %", fnt, Brushes.Black, New RectangleF(615 * a, CInt(m_Pied) + h, 120, 22), sf)

                h = 30
            End If

            If isDevis = False Then
                e.Graphics.DrawLine(pn, CInt(550 * a), CInt(m_Pied) + h, CInt(770 * a), CInt(m_Pied) + h)
                h += 3
                e.Graphics.DrawString("Avance : ", fnt, Brushes.Black, New RectangleF(552 * a, CInt(m_Pied) + h, 100 * a, 22), sf)
                e.Graphics.DrawString(String.Format("{0:n}", CDec(avance)) & " Dhs", fnt, Brushes.Black, New RectangleF(620 * a, CInt(m_Pied) + h, 120, 22), sf)
                h += 20
                e.Graphics.DrawLine(pn, CInt(550 * a), CInt(m_Pied) + h, CInt(770 * a), CInt(m_Pied) + h)
                e.Graphics.DrawString("Rest : ", fnt, Brushes.Black, New RectangleF(552 * a, CInt(m_Pied) + h + 5, 60 * a, 22), sf)
                e.Graphics.DrawString(String.Format("{0:n}", CDec(rest)) & " Dhs", fnt, Brushes.Black, New RectangleF(615 * a, CInt(m_Pied) + h + 5, 120, 22), sf)
            End If


            e.Graphics.DrawLine(pn, CInt(550 * a), CInt(m_Pied) + 5, CInt(550 * a), CInt(m_Pied) + h + 25)
            'e.Graphics.DrawLine(pn, CInt(610 * a), e.MarginBounds.Height + 5, CInt(610 * a), e.MarginBounds.Height + h + 25)
            e.Graphics.DrawLine(pn, CInt(770 * a), CInt(m_Pied) + 5, CInt(770 * a), CInt(m_Pied) + h + 25)

            e.Graphics.DrawLine(pn, CInt(550 * a), CInt(m_Pied) + h + 25, CInt(770 * a), CInt(m_Pied) + h + 25)
        End If



        If isSell And a = 1 And isDevis = False And rest > 0 Then
            Try
                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    Dim param As New Dictionary(Of String, Object)
                    param.Add("clid", clid)

                    Dim delai As String = c.SelectByScalar("Client", "type", param)
                    If delai <> "" Or delai <> "0" Then
                        e.Graphics.DrawString("* Délai  de paiement pour ce bon : " & delai & " j", fnt, Brushes.Black, New RectangleF(60 * a, CInt(m_Pied) + 40, 266, 22), sf)
                    End If
                    param = Nothing
                End Using
            Catch ex As Exception
            End Try
        End If

        'If Form1.TxtSignature.Text <> "" And a = 1 And isDevis = False Then
        '    'Signatures
        '    Dim sig As String() = Form1.TxtSignature.Text.Split("*")
        '    Dim w As Integer = 710
        '    w = CInt(w - (20 * (sig.Length - 1)))
        '    w = CInt(w / sig.Length)

        '    For i As Integer = 0 To sig.Length - 1
        '        Dim st As Integer = 60 + i * w + i * 20
        '        e.Graphics.DrawRectangle(pen, CInt(st * a), e.MarginBounds.Height + 70, CInt(w * a), 90)

        '        Dim size2 As SizeF = e.Graphics.MeasureString(sig(i), fnt)
        '        e.Graphics.FillRectangle(Brushes.White, CInt((st * a) + 10), e.MarginBounds.Height + 63, size2.Width + 5, 15)

        '        e.Graphics.DrawString(sig(i), fnt, Brushes.Black, CInt((st * a) + 12), e.MarginBounds.Height + 65)
        '    Next
        'End If

        e.Graphics.DrawString("N° : " & fctid & " // P: " & numPages & " / " & numPages, fnt, Brushes.Black, 15, CInt(m_Pied) + 130)

        l = m_Entete
        numPages = 1
        m = 0

    End Sub
    Public Sub DrawBL_A5_Fr(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal dt As DataTable, ByVal fid As Integer, ByVal clid As Integer,
                           ByVal CName As String, ByVal CAdresse As String, ByVal totalht As Double, ByVal totalttc As Double, ByVal avance As Double,
                           ByVal totaltva As Double, ByVal isSell As Boolean, ByVal dte As String,
                           ByVal remise As Double, ByVal a As Double, ByVal isDevis As Boolean,
                           ByVal withou_price As Boolean, ByRef m As Integer, ByRef numPages As Integer)

        Dim pen As New Pen(Brushes.Black, 1.0F)
        Dim pn As New Pen(Brushes.Black, 0.5F)

        Dim fnt As New Font(Form1.txtfname.Text, CInt(Form1.txtfntsize.Text))
        Dim fntTitle As New Font("Arial", 14, FontStyle.Bold)

        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Near
        Dim sf1 As New StringFormat()
        sf1.Alignment = StringAlignment.Far
        Dim sf2 As New StringFormat()
        sf2.Alignment = StringAlignment.Center

        Dim fctid As Integer = fid
        Dim clientName As String = CName
        Dim data As DataTable = dt

        Dim rest As Decimal = totalttc - avance

        Try
            e.Graphics.DrawImage(Image.FromFile(Form1.txtLogo.Text), 10, 10, 750, 120)
        Catch ex As Exception
        End Try

        Dim m_Entete = Form1.txtEnteteMarge.Text
        If Not IsNumeric(m_Entete) Then m_Entete = 160

        Dim m_Pied = Form1.txtPiedMarge.Text
        If Not IsNumeric(m_Pied) Then m_Pied = 750

        l = m_Entete



        Dim myPoints() As Point = New Point() {New Point(60 * a, l), New Point(600 * a, l),
                                        New Point(612 * a, l + 15), New Point(600 * a, l + 30),
                                        New Point(60 * a, l + 30)}
        e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
        e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

        myPoints = {New Point(606 * a, l), New Point(770 * a, l),
                   New Point(770 * a, l + 30), New Point(606 * a, l + 30),
                   New Point(618 * a, l + 15)}
        e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
        e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

        'print date 
        e.Graphics.DrawString(dte, fnt, Brushes.Black, New RectangleF(600 * a, l + 7, 164 * a, 30), sf1)
        'print  num Facture 
        If isSell Then
            If isDevis Then
                e.Graphics.DrawString("Devis  N° : " & fctid, fntTitle, Brushes.Black, 65 * a, l + 5)

            Else
                e.Graphics.DrawString("Bon de Livraison  N° : " & fctid, fntTitle, Brushes.Black, 65 * a, l + 5)

            End If
        Else
            e.Graphics.DrawString("Bon de Commande  N° : " & fctid, fntTitle, Brushes.Black, 65 * a, l + 5)
        End If

        Try
            'print Client 
            e.Graphics.DrawString("M : " & clientName, fnt, Brushes.Black, 65 * a, l + 40)
            e.Graphics.DrawString(CAdresse, fnt, Brushes.Black, 65 * a, l + 55)

        Catch ex As Exception

        End Try

        l += 60

        If m > 0 Then
            e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60 * a, l)
            l += 15
        End If

        'Draw the table  e.MarginBounds.Height
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, CInt(60 * a), CInt(l), CInt(710 * a), 25)
        'e.Graphics.DrawRectangle(pen, CInt(60 * a), CInt(l * a), CInt(710 * a), CInt(600 * a))
        e.Graphics.DrawRectangle(pen, CInt(60 * a), CInt(l), CInt(710 * a), CInt(m_Pied - l))
        e.Graphics.DrawLine(pn, CInt(60 * a), CInt(l + 25), CInt(770 * a), CInt(l + 25))

        'e.Graphics.DrawLine(pn, 420, l, 420, 850)
        e.Graphics.DrawLine(pn, CInt(470 * a), l, CInt(470 * a), CInt(m_Pied)) ' CInt(850 * a))
        e.Graphics.DrawLine(pn, CInt(542 * a), l, CInt(542 * a), CInt(m_Pied)) 'e.MarginBounds.Height)
        e.Graphics.DrawLine(pn, CInt(618 * a), l, CInt(618 * a), CInt(m_Pied)) 'e.MarginBounds.Height)

        e.Graphics.DrawString("Designation", fnt, Brushes.Black, New RectangleF(62 * a, (l + 5), 410 * a, 25), sf2)
        'e.Graphics.DrawString("Unite", fnt, Brushes.Black, New RectangleF(420, l + 5, 55, 25), sf2)
        e.Graphics.DrawString("Qte", fnt, Brushes.Black, New RectangleF(472 * a, (l + 5), 71 * a, 25), sf2)
        e.Graphics.DrawString("Prix", fnt, Brushes.Black, New RectangleF(544 * a, (l + 5), 76 * a, 25), sf2)
        e.Graphics.DrawString("Total ", fnt, Brushes.Black, New RectangleF(620 * a, (l + 5), 136 * a, 25), sf2)

        l += 29

        While m < data.Rows.Count

            If l + 20 > m_Pied Then
                e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605 * a, CInt(m_Pied) + 5)
                e.Graphics.DrawString("N° : " & fctid & " // P: " & numPages, fnt, Brushes.Black, 15, CInt(m_Pied) + 130)
                numPages += 1

                l = m_Entete
                e.HasMorePages = True
                Return
            End If

            Dim ref As String = data.Rows(m).Item("code")
            Dim prdName As String = data.Rows(m).Item("name") '"[" & ref & "] " & data.Rows(m).Item("name")
            'Dim unite As String = data.Rows(m).Item("unite")
            Dim qte As String = data.Rows(m).Item("qte")
            Dim price As String = String.Format("{0:n}", CDec(data.Rows(m).Item("price")))
            Dim total As String = String.Format("{0:n}", CDec(data.Rows(m).Item("total")))
            Dim re As Decimal = CDec(data.Rows(m).Item("poid") / 100)

            If re > 0 And Form1.CbArticleRemise.Checked Then prdName &= " *(Remise:" & String.Format("{0:n}", re) & "%)*"

            ''''''
            Dim size As SizeF = e.Graphics.MeasureString(prdName, fnt, CInt(410 * a))

            If withou_price = True Then
                price = ""
                total = ""
            End If

            e.Graphics.DrawString(prdName, fnt, Brushes.Black, New RectangleF(62 * a, l, 410 * a, size.Height), sf)
            e.Graphics.DrawString(qte, fnt, Brushes.Black, New RectangleF(472 * a, l, 71 * a, 25), sf1)
            e.Graphics.DrawString(price, fnt, Brushes.Black, New RectangleF(544 * a, l, 76 * a, 25), sf1)
            e.Graphics.DrawString(total, fnt, Brushes.Black, New RectangleF(620 * a, l, 136 * a, 25), sf1)

            ''''''carre
            ' e.Graphics.FillRectangle(Brushes.WhiteSmoke, CInt(50 * a), CInt(l * a), 5, 5)


            l = l + size.Height + 5
            m += 1
        End While

        Dim ht As String = String.Format("{0:n}", CDec(totalht))
        Dim Ttva As String = String.Format("{0:n}", CDec(totaltva))
        Dim ttc As String = String.Format("{0:n}", CDec(totalttc))

        If withou_price = False Then
            Dim h As Integer = 32

            'e.MarginBounds.Height 
            If remise > 0 Then h = 60
            If isDevis = False Then h = 115


            e.Graphics.DrawLine(pn, CInt(550 * a), CInt(m_Pied) + 5, CInt(770 * a), CInt(m_Pied) + 5)
            'e.Graphics.DrawLine(pn, CInt(550 * a), e.MarginBounds.Height + 25, CInt(770 * a), e.MarginBounds.Height + 25)

            e.Graphics.DrawString("Total  ", fnt, Brushes.Black, New RectangleF(552 * a, CInt(m_Pied) + 10, 60 * a, 22), sf)
            e.Graphics.DrawString(ttc & " (Dhs)", fnt, Brushes.Black, New RectangleF(615 * a, CInt(m_Pied) + 10, 120, 22), sf)



            e.Graphics.DrawString(dt.Rows.Count & "Vidals", fnt, Brushes.Black, New RectangleF(60 * a, CInt(m_Pied) + 10, 260 * a, 22), sf)



            h = 28

            If remise > 0 Then
                e.Graphics.DrawLine(pn, CInt(550 * a), CInt(m_Pied) + 60, CInt(770 * a), CInt(m_Pied) + 60)
                e.Graphics.DrawString("Remise : ", fnt, Brushes.Black, New RectangleF(552 * a, CInt(m_Pied) + h, 60 * a, 22), sf)
                e.Graphics.DrawString(String.Format("{0:n}", CDec(remise)) & " %", fnt, Brushes.Black, New RectangleF(615 * a, CInt(m_Pied) + h, 120, 22), sf)

                h = 30
            End If

            If isDevis = False Then
                e.Graphics.DrawLine(pn, CInt(550 * a), CInt(m_Pied) + h, CInt(770 * a), CInt(m_Pied) + h)
                h += 3
                e.Graphics.DrawString("Avance : ", fnt, Brushes.Black, New RectangleF(552 * a, CInt(m_Pied) + h, 100 * a, 22), sf)
                e.Graphics.DrawString(String.Format("{0:n}", CDec(avance)) & " Dhs", fnt, Brushes.Black, New RectangleF(620 * a, CInt(m_Pied) + h, 120, 22), sf)
                h += 20
                e.Graphics.DrawLine(pn, CInt(550 * a), CInt(m_Pied) + h, CInt(770 * a), CInt(m_Pied) + h)
                e.Graphics.DrawString("Rest : ", fnt, Brushes.Black, New RectangleF(552 * a, CInt(m_Pied) + h + 5, 60 * a, 22), sf)
                e.Graphics.DrawString(String.Format("{0:n}", CDec(rest)) & " Dhs", fnt, Brushes.Black, New RectangleF(615 * a, CInt(m_Pied) + h + 5, 120, 22), sf)
            End If


            e.Graphics.DrawLine(pn, CInt(550 * a), CInt(m_Pied) + 5, CInt(550 * a), CInt(m_Pied) + h + 25)
            'e.Graphics.DrawLine(pn, CInt(610 * a), e.MarginBounds.Height + 5, CInt(610 * a), e.MarginBounds.Height + h + 25)
            e.Graphics.DrawLine(pn, CInt(770 * a), CInt(m_Pied) + 5, CInt(770 * a), CInt(m_Pied) + h + 25)

            e.Graphics.DrawLine(pn, CInt(550 * a), CInt(m_Pied) + h + 25, CInt(770 * a), CInt(m_Pied) + h + 25)
        End If



        If isSell And a = 1 And isDevis = False And rest > 0 Then
            Try
                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    Dim param As New Dictionary(Of String, Object)
                    param.Add("clid", clid)

                    Dim delai As String = c.SelectByScalar("Client", "type", param)
                    If delai <> "" Or delai <> "0" Then
                        e.Graphics.DrawString("* Délai  de paiement pour ce bon : " & delai & " j", fnt, Brushes.Black, New RectangleF(60 * a, CInt(m_Pied) + 40, 266, 22), sf)
                    End If
                    param = Nothing
                End Using
            Catch ex As Exception
            End Try
        End If

        'If Form1.TxtSignature.Text <> "" And a = 1 And isDevis = False Then
        '    'Signatures
        '    Dim sig As String() = Form1.TxtSignature.Text.Split("*")
        '    Dim w As Integer = 710
        '    w = CInt(w - (20 * (sig.Length - 1)))
        '    w = CInt(w / sig.Length)

        '    For i As Integer = 0 To sig.Length - 1
        '        Dim st As Integer = 60 + i * w + i * 20
        '        e.Graphics.DrawRectangle(pen, CInt(st * a), e.MarginBounds.Height + 70, CInt(w * a), 90)

        '        Dim size2 As SizeF = e.Graphics.MeasureString(sig(i), fnt)
        '        e.Graphics.FillRectangle(Brushes.White, CInt((st * a) + 10), e.MarginBounds.Height + 63, size2.Width + 5, 15)

        '        e.Graphics.DrawString(sig(i), fnt, Brushes.Black, CInt((st * a) + 12), e.MarginBounds.Height + 65)
        '    Next
        'End If

        e.Graphics.DrawString("N° : " & fctid & " // P: " & numPages & " / " & numPages, fnt, Brushes.Black, 15, CInt(m_Pied) + 130)

        l = m_Entete
        numpages = 1
        m = 0
    End Sub


    Public Sub DrawReceipt_Ar(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal dt As DataTable, ByVal fid As Integer,
                               ByVal CName As String, ByVal CAdresse As String, ByVal totalht As Double, ByVal totalttc As Double,
                               ByVal totaltva As Double, ByVal avance As Double, ByVal isSell As Boolean, ByVal dte As String,
                               ByVal remise As Double, ByRef m As Integer)

        Dim pen As New Pen(Brushes.Black, 1.0F)
        Dim pn As New Pen(Brushes.Black, 0.5F)

        Dim fnt As New Font(Form1.txtfname.Text, CInt(Form1.txtfntsize.Text))
        Dim fntTitle As New Font("Arial", 12, FontStyle.Bold)

        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Near
        Dim sf1 As New StringFormat()
        sf1.Alignment = StringAlignment.Far
        Dim sf2 As New StringFormat()
        sf2.Alignment = StringAlignment.Center

        Dim fctid As Integer = fid
        Dim clientName As String = CName
        Dim data As DataTable = dt
        Dim poids As Decimal = 0

        e.Graphics.DrawString(Form1.txttitle.Text, fntTitle, Brushes.Black, New RectangleF(10, 20, 300, 55), sf2)
        e.Graphics.DrawString(Form1.txtAdrs.Text, fnt, Brushes.Black, New RectangleF(10, 80, 300, 30), sf2)
        e.Graphics.DrawString(Form1.txttel.Text, fnt, Brushes.Black, New RectangleF(10, 100, 300, 30), sf2)

        Try
            e.Graphics.DrawImage(Image.FromFile(Form1.txtLogo.Text), 10, 10, 300, 120)
        Catch ex As Exception

        End Try

        Dim myPoints() As Point = New Point() {New Point(10, 150), New Point(270, 150),
                                               New Point(282, 165), New Point(270, 180),
                                               New Point(10, 180)}
        '  e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
        e.Graphics.DrawPolygon(New Pen(Brushes.Black, 0.5F), myPoints)

        'print date 
        e.Graphics.DrawString(dte, fnt, Brushes.Black, 15, 130)
        'print  num Facture 
        If isSell Then
            e.Graphics.DrawString("Tickit  N° : " & fctid, fntTitle, Brushes.Black, 15, 155)
        Else
            e.Graphics.DrawString("Bon d'ACHAT  N° : " & fctid, fntTitle, Brushes.Black, 15, 155)
        End If

        'print Client 
        e.Graphics.DrawString("M : " & clientName & " | " & Form1.RPl.ClId, fntTitle, Brushes.Black, New RectangleF(15, 195, 275, 35), sf)
        e.Graphics.DrawString("*****  " & dt.Rows.Count & " - مادة    |", fnt, Brushes.Black, 15, 230)

        If m > 0 Then
            e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 10, l)
            l += 15
        End If

        e.Graphics.DrawLine(pn, 10, l, 300, l)

        l = l + 10

        While m < data.Rows.Count

            'If (l + 30) > e.MarginBounds.Height And Form1.CHPRINTERRECEIPT.Checked = False Then
            '    e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 10, l + 30)
            '    l = 250
            '    e.HasMorePages = True
            '    Return
            'End If

            Dim ref As String = data.Rows(m).Item("code")
            Dim prdName As String = "(" & data.Rows(m).Item("unite") & ") " & data.Rows(m).Item("name")
            If Form1.cbUnite.Checked = True Then prdName = data.Rows(m).Item("name")
            If Form1.cbShowRef.Checked Then prdName &= " " & ref

            Dim qte As String = data.Rows(m).Item("qte")
            Dim price As String = String.Format("{0:n}", CDec(data.Rows(m).Item("price")))
            Dim total As String = String.Format("{0:n}", CDec(data.Rows(m).Item("price") * data.Rows(m).Item("qte")))

            ''''''
            'Try
            '    Dim p As Double = CDbl(data.Rows(m).Item("qte") * data.Rows(m).Item("poid"))
            '    poids += p
            'Catch ex As Exception

            'End Try

            Dim size As SizeF = e.Graphics.MeasureString(prdName, fnt, 120)

            e.Graphics.DrawString(total, fnt, Brushes.Black, New RectangleF(10, l, 55, size.Height), sf1)
            e.Graphics.DrawLine(pn, 67, l, 67, l + size.Height)
            e.Graphics.DrawString(price, fnt, Brushes.Black, New RectangleF(69, l, 50, 25), sf1)
            e.Graphics.DrawLine(pn, 121, l, 121, l + size.Height)
            e.Graphics.DrawString(prdName, fnt, Brushes.Black, New RectangleF(122, l, 120, size.Height), sf1)
            e.Graphics.DrawLine(pn, 243, l, 243, l + size.Height)
            e.Graphics.DrawString(qte, fnt, Brushes.Black, New RectangleF(245, l, 40, 25), sf1)
            e.Graphics.DrawLine(pn, 200, l + size.Height, 300, l + size.Height)

            l = l + size.Height + 5
            m += 1
        End While

        Dim avc As String = String.Format("{0:n}", CDec(Form1.payedCache))
        Dim Ttva As String = String.Format("{0:n}", CDec(totaltva))
        Dim ttc As String = String.Format("{0:n}", CDec(totalttc))
        Dim rest As String = String.Format("{0:n}", CDec(totalttc - Form1.payedCache))

        l += 10

        e.Graphics.DrawLine(pn, 10, l, 300, l)
        e.Graphics.DrawLine(pn, 10, l + 2, 300, l + 2)

        l += 10

        e.Graphics.DrawString("Total ttc : ", fnt, Brushes.Black, New RectangleF(10, l, 200, 22), sf)
        e.Graphics.DrawString(ttc & " (Dhs)", fntTitle, Brushes.Black, New RectangleF(10, l + 20, 220, 22), sf)

        l += 50
        If remise > 0 Then
            e.Graphics.DrawString("Remise : " & remise & " %", fnt, Brushes.Black, New RectangleF(10, l, 232, 22), sf)
            l += 30
        End If

        e.Graphics.DrawString("Avance : " & avance & " Dhs", fnt, Brushes.Black, New RectangleF(10, l, 232, 22), sf)
        e.Graphics.DrawString("Rest : " & rest & " Dhs", fntTitle, Brushes.Black, New RectangleF(10, l + 20, 232, 22), sf)

        Try

            Using a As SubClass = New SubClass
                rest += a.LaodUnPaidFactures
            End Using

        Catch ex As Exception

        End Try

        If Form1.RPl.ClId > 0 And Form1.cbShowGloblCredit.Checked Then e.Graphics.DrawString("Credit Total : " & rest & " Dhs", fntTitle, Brushes.Black, New RectangleF(10, l + 50, 232, 22), sf)



        l += 70

        Dim BL As String = Form1.RPl.bl
        If BL <> "" And BL <> "-" And BL <> "---" Then
            e.Graphics.DrawString("------  *****  ------", fnt, Brushes.Black, New RectangleF(10, l, 300, 22), sf2)
            e.Graphics.DrawString("Charger par : " & BL, fnt, Brushes.Black, New RectangleF(10, l + 12, 300, 22), sf2)
            e.Graphics.DrawString("------  *****  ------", fnt, Brushes.Black, New RectangleF(10, l + 25, 300, 22), sf2)

            l += 44
        End If


        ''''' DRAW THE WEIGHT ANG NBR VIDALS UP
        'e.Graphics.DrawString(" Poids : " & String.Format("{0:n}", poids) & " Kg  *****", fnt, Brushes.Black, 125, 230)

        If Form1.cbMsgOc.Checked Then

            Dim size As SizeF = e.Graphics.MeasureString(Form1.txtMsgOc.Text, fnt, 290)

            'e.Graphics.FillRectangle(Brushes.WhiteSmoke, 10, l, 300, size.Height + 20)
            e.Graphics.DrawRectangle(Pens.Black, 10, l, 300, size.Height + 20)

            e.Graphics.DrawString(Form1.txtMsgOc.Text, fnt, Brushes.Black, New RectangleF(15, l + 5, 290, size.Height), sf)
            l += size.Height + 60
        End If



        If Form1.RPl.delivredDay.Length > 3 Then
            e.Graphics.DrawLine(Pens.Black, 5, l, 285, l)
            e.Graphics.DrawString("*** COMMANDE : " & Form1.RPl.delivredDay & " ***", New Font(fnt, FontStyle.Bold), Brushes.Black, New RectangleF(5, l + 5, 280, 25), sf2)

            e.Graphics.DrawLine(Pens.Black, 5, l + 20, 285, l + 20)
        Else
            e.Graphics.FillRectangle(Brushes.Black, 5, l, 280, 25)
            e.Graphics.DrawString("***  Merci  de  votre  visite  ***", New Font(fnt, FontStyle.Bold), Brushes.White, New RectangleF(5, l + 5, 280, 25), sf2)

        End If
        l = 250
        m = 0
    End Sub
    Public Sub DrawReceipt_FR(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal dt As DataTable, ByVal fid As Integer,
                               ByVal CName As String, ByVal CAdresse As String, ByVal totalht As Double, ByVal totalttc As Double,
                               ByVal totaltva As Double, ByVal avance As Double, ByVal isSell As Boolean, ByVal dte As String,
                               ByVal remise As Double, ByRef m As Integer)

        Dim pen As New Pen(Brushes.Black, 1.0F)
        Dim pn As New Pen(Brushes.Black, 0.5F)

        Dim fnt As New Font(Form1.txtfname.Text, CInt(Form1.txtfntsize.Text))
        Dim fntTitle As New Font("Arial", 12, FontStyle.Bold)

        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Near
        Dim sf1 As New StringFormat()
        sf1.Alignment = StringAlignment.Far
        Dim sf2 As New StringFormat()
        sf2.Alignment = StringAlignment.Center

        Dim fctid As Integer = fid
        Dim clientName As String = CName
        Dim data As DataTable = dt
        Dim poids As Decimal = 0

        e.Graphics.DrawString(Form1.txttitle.Text, fntTitle, Brushes.Black, New RectangleF(10, 20, 300, 55), sf2)
        e.Graphics.DrawString(Form1.txtAdrs.Text, fnt, Brushes.Black, New RectangleF(10, 80, 300, 30), sf2)
        e.Graphics.DrawString(Form1.txttel.Text, fnt, Brushes.Black, New RectangleF(10, 100, 300, 30), sf2)

        Try
            e.Graphics.DrawImage(Image.FromFile(Form1.txtLogo.Text), 10, 10, 300, 120)
        Catch ex As Exception

        End Try

        Dim myPoints() As Point = New Point() {New Point(10, 150), New Point(270, 150),
                                               New Point(282, 165), New Point(270, 180),
                                               New Point(10, 180)}
        '  e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
        e.Graphics.DrawPolygon(New Pen(Brushes.Black, 0.5F), myPoints)

        'print date 
        e.Graphics.DrawString(dte, fnt, Brushes.Black, 15, 130)
        'print  num Facture 
        If isSell Then
            e.Graphics.DrawString("Receipt  N° : " & fctid, fntTitle, Brushes.Black, 15, 155)
        Else
            e.Graphics.DrawString("Bon d'ACHAT  N° : " & fctid, fntTitle, Brushes.Black, 15, 155)
        End If

        'print Client 
        e.Graphics.DrawString("M : " & clientName & " | " & Form1.RPl.ClId, fntTitle, Brushes.Black, New RectangleF(15, 195, 275, 35), sf)
        e.Graphics.DrawString("*****  " & dt.Rows.Count & " - Vidals", fnt, Brushes.Black, 15, 230)

        If m > 0 Then
            e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 10, l)
            l += 15
        End If

        e.Graphics.DrawLine(pn, 10, l, 300, l)

        l = l + 10
        While m < data.Rows.Count

            'Dim ref As String = data.Rows(m).Item("code")
            Dim prdName As String = data.Rows(m).Item("name") & " (" & data.Rows(m).Item("unite") & ")"
            Dim qte As String = String.Format("{0:n}", CDec(data.Rows(m).Item("qte")))
            Dim price As String = String.Format("{0:n}", CDec(data.Rows(m).Item("price")))
            Dim total As String = String.Format("{0:n}", CDec(data.Rows(m).Item("price") * data.Rows(m).Item("qte")))

            ''''''

            Dim size As SizeF = e.Graphics.MeasureString(prdName, fnt, 120)

            e.Graphics.DrawString(qte, fnt, Brushes.Black, New RectangleF(10, l, 40, size.Height), sf1)
            e.Graphics.DrawLine(pn, 52, l, 52, l + size.Height)
            e.Graphics.DrawString(prdName, fnt, Brushes.Black, New RectangleF(55, l, 120, size.Height), sf)
            e.Graphics.DrawLine(pn, 177, l, 177, l + size.Height)
            e.Graphics.DrawString(price, fnt, Brushes.Black, New RectangleF(180, l, 50, 25), sf1)
            e.Graphics.DrawLine(pn, 232, l, 232, l + size.Height)
            e.Graphics.DrawString(total, fnt, Brushes.Black, New RectangleF(230, l, 55, 25), sf1)

            l = l + size.Height + 5
            m += 1
        End While

        Dim avc As String = String.Format("{0:n}", CDec(Form1.payedCache))
        Dim Ttva As String = String.Format("{0:n}", CDec(totaltva))
        Dim ttc As String = String.Format("{0:n}", CDec(totalttc))
        Dim rest As String = String.Format("{0:n}", CDec(totalttc - Form1.payedCache))

        l += 10

        e.Graphics.DrawLine(pn, 10, l, 300, l)
        e.Graphics.DrawLine(pn, 10, l + 2, 300, l + 2)

        l += 10

        e.Graphics.DrawString("Total ttc : ", fnt, Brushes.Black, New RectangleF(10, l, 200, 22), sf)
        e.Graphics.DrawString(ttc & " (Dhs)", fntTitle, Brushes.Black, New RectangleF(10, l + 20, 220, 22), sf)

        l += 50
        If remise > 0 Then
            e.Graphics.DrawString("Remise : " & remise & " %", fnt, Brushes.Black, New RectangleF(10, l, 232, 22), sf)
            l += 30
        End If


        e.Graphics.DrawString("Cache : " & avc, fnt, Brushes.Black, New RectangleF(10, l, 200, 22), sf)

        e.Graphics.DrawString("Rest : " & rest, fnt, Brushes.Black, New RectangleF(10, l + 20, 200, 22), sf)

        l += 40

        If Form1.cbMsgOc.Checked Then

            Dim size As SizeF = e.Graphics.MeasureString(Form1.txtMsgOc.Text, fnt, 290)

            'e.Graphics.FillRectangle(Brushes.WhiteSmoke, 10, l, 300, size.Height + 20)
            e.Graphics.DrawRectangle(Pens.Black, 10, l, 300, size.Height + 20)

            e.Graphics.DrawString(Form1.txtMsgOc.Text, fnt, Brushes.Black, New RectangleF(15, l + 5, 290, size.Height), sf)
            l += size.Height + 60
        End If

        If Form1.RPl.delivredDay.Length > 3 Then
            e.Graphics.DrawLine(Pens.Black, 5, l, 285, l)
            e.Graphics.DrawString("*** COMMANDE : " & Form1.RPl.delivredDay & " ***", New Font(fnt, FontStyle.Bold), Brushes.Black, New RectangleF(5, l + 5, 280, 25), sf2)

            e.Graphics.DrawLine(Pens.Black, 5, l + 20, 285, l + 20)
        Else
            e.Graphics.FillRectangle(Brushes.Black, 5, l, 280, 25)
            e.Graphics.DrawString("***  Merci  de  votre  visite  ***", New Font(fnt, FontStyle.Bold), Brushes.White, New RectangleF(5, l + 5, 280, 25), sf2)

        End If


        l = 250
        m = 0
    End Sub

    Public Sub DrawReceiptDepot(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal dp As String,
                                ByVal fid As Integer, ByVal dpid As Integer, ByVal data As DataTable,
                                ByVal CName As String, ByVal dte As String, ByRef m As Integer)

        Dim pen As New Pen(Brushes.Black, 1.0F)
        Dim pn As New Pen(Brushes.Black, 0.5F)

        Dim fnt As New Font(Form1.txtfname.Text, CInt(Form1.txtfntsize.Text))
        Dim fntTitle As New Font("Arial", 12, FontStyle.Bold)

        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Near
        Dim sf1 As New StringFormat()
        sf1.Alignment = StringAlignment.Far
        Dim sf2 As New StringFormat()
        sf2.Alignment = StringAlignment.Center

        Dim fctid As Integer = fid
        Dim tableName As String = CName
        Dim poids As Decimal = 0

        e.Graphics.DrawString(Form1.txttitle.Text, fntTitle, Brushes.Black, New RectangleF(10, 20, 300, 55), sf2)
        e.Graphics.DrawString(dp, fntTitle, Brushes.Black, New RectangleF(10, 80, 300, 30), sf2)

        Try
            e.Graphics.DrawImage(Image.FromFile(Form1.txtLogo.Text), 10, 10, 300, 120)
        Catch ex As Exception

        End Try

        Dim myPoints() As Point = New Point() {New Point(10, 160), New Point(270, 160),
                                               New Point(282, 175), New Point(270, 190),
                                               New Point(10, 190)}
        '  e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
        e.Graphics.DrawPolygon(New Pen(Brushes.Black, 0.5F), myPoints)

        'print date 
        e.Graphics.DrawString(dte, fnt, Brushes.Black, 15, 200)
        'print  num Facture 

        If Form1.RPl.isSell Then
            e.Graphics.DrawString("Bon de Sortie : " & fctid, fntTitle, Brushes.Black, 15, 165)
        Else
            e.Graphics.DrawString("Bon de Entree : " & fctid, fntTitle, Brushes.Black, 15, 165)
        End If

        'print Client 
        e.Graphics.DrawString(tableName, fnt, Brushes.Black, 15, 215)
        e.Graphics.DrawString("***  LIVRER PAR : " & Form1.RPl.bl, fnt, Brushes.Black, 15, 230)


        If m > 0 Then
            e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 10, l)
            l += 15
        End If

        e.Graphics.DrawLine(pn, 10, l, 300, l)

        l = l + 10

        While m < data.Rows.Count

            If data.Rows(m).Item("depot") <> dpid Then
                m += 1
                Continue While
            End If



            Dim prdName As String = data.Rows(m).Item("name") & " " & data.Rows(m).Item("code")
            Dim qte As String = data.Rows(m).Item("qte")

            ''''''

            Dim size As SizeF = e.Graphics.MeasureString(prdName, fnt, 230)

            e.Graphics.DrawString(qte, fnt, Brushes.Black, New RectangleF(10, l, 40, 25), sf1)
            e.Graphics.DrawLine(pn, 52, l, 52, l + size.Height)

            e.Graphics.DrawString(prdName, fnt, Brushes.Black, New RectangleF(55, l, 230, size.Height), sf)


            l = l + size.Height + 5
            m += 1
        End While



        l += 10

        e.Graphics.DrawLine(pn, 10, l, 300, l)
        e.Graphics.DrawLine(pn, 10, l + 2, 300, l + 2)

        l += 10


        l = 250
        m = 0
    End Sub

    Public Sub RepportFacture(ByRef e As System.Drawing.Printing.PrintPageEventArgs,
                              ByVal data As DataGridView, ByVal txt As String,
                              ByRef myTva As Dictionary(Of String, Double),
                              ByVal isSell As Boolean, ByRef m As Integer)

        Dim pen As New Pen(Brushes.Black, 1.0F)
        Dim pn As New Pen(Brushes.Black, 0.5F)

        Dim fnt As New Font("Arial", 9)
        Dim fntTitle As New Font("Arial", 14, FontStyle.Bold)

        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Near
        Dim sf1 As New StringFormat()
        sf1.Alignment = StringAlignment.Far
        Dim sf2 As New StringFormat()
        sf2.Alignment = StringAlignment.Center


        Dim dte As Date = Now.Date


        Dim myPoints() As Point = New Point() {New Point(60, 160), New Point(600, 160),
                                               New Point(612, 175), New Point(600, 190),
                                               New Point(60, 190)}
        e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
        e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

        myPoints = {New Point(606, 160), New Point(770, 160),
                   New Point(770, 190), New Point(606, 190),
                   New Point(618, 175)}
        e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
        e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

        'print date 
        e.Graphics.DrawString(dte.ToString("dd MMMM, yyyy"), fnt, Brushes.Black, New RectangleF(620, 167, 144, 24), sf1)
        'print  num Facture 
        If isSell Then
            e.Graphics.DrawString("Rapport des ventes", fntTitle, Brushes.Black, 65, 165)
        Else
            e.Graphics.DrawString("Rapport des achats", fntTitle, Brushes.Black, 65, 165)
        End If

        'print Client 
        e.Graphics.DrawString(txt, fnt, Brushes.Black, 65, 200)

        If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60, 230)

        'Draw the table
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, 60, l, 710, 25)
        e.Graphics.DrawRectangle(pen, 60, l, 720, 600)
        e.Graphics.DrawLine(pn, 60, l + 25, 780, l + 25)

        e.Graphics.DrawLine(pn, 140, l, 140, 850)
        e.Graphics.DrawLine(pn, 210, l, 210, 850)
        e.Graphics.DrawLine(pn, 430, l, 430, 850)
        e.Graphics.DrawLine(pn, 500, l, 500, 850)
        e.Graphics.DrawLine(pn, 560, l, 560, 850)
        e.Graphics.DrawLine(pn, 630, l, 630, 850)
        e.Graphics.DrawLine(pn, 680, l, 680, 850)

        e.Graphics.DrawString("Date", fnt, Brushes.Black, New RectangleF(60, l + 5, 80, 25), sf2)
        e.Graphics.DrawString("Id", fnt, Brushes.Black, New RectangleF(140, l + 5, 70, 25), sf2)
        e.Graphics.DrawString("Nom", fnt, Brushes.Black, New RectangleF(210, l + 5, 220, 25), sf2)
        e.Graphics.DrawString("Total HT", fnt, Brushes.Black, New RectangleF(430, l + 5, 70, 25), sf2)
        e.Graphics.DrawString("TVA", fnt, Brushes.Black, New RectangleF(500, l + 5, 60, 25), sf2)
        e.Graphics.DrawString("Total TTC", fnt, Brushes.Black, New RectangleF(560, l + 5, 70, 25), sf2)
        e.Graphics.DrawString("Regler", fnt, Brushes.Black, New RectangleF(630, l + 5, 50, 25), sf2)
        e.Graphics.DrawString("Desig.", fnt, Brushes.Black, New RectangleF(680, l + 5, 100, 25), sf2)
        l = 280

        While m < data.Rows.Count

            If l + 180 > e.MarginBounds.Height Then
                e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605, 870)
                l = 250
                e.HasMorePages = True
                Return
            End If

            Dim Id As String = data.Rows(m).Cells(0).Value
            Dim prdName As String = data.Rows(m).Cells(2).Value
            Dim Total As String = String.Format("{0:n}", CDec(data.Rows(m).Cells(3).Value))
            Dim avance As String = String.Format("{0:n}", CDec(data.Rows(m).Cells(4).Value))
            Dim tva As String = String.Format("{0:n}", CDec(data.Rows(m).Cells(5).Value))
            Dim ht As String = String.Format("{0:n}", CDec(data.Rows(m).Cells(3).Value - data.Rows(m).Cells(5).Value))
            Dim date1 As String = CDate(data.Rows(m).Cells(6).Value).ToString("dd/MM/yyyy")
            Dim DESIG As String = data.Rows(m).Cells(11).Value

            Dim reg As String = "Non"
            If CBool(data.Rows(m).Cells(9).Value) Then reg = "Oui"

            '''''' 

            Dim size As SizeF = e.Graphics.MeasureString(prdName, fnt, 290)

            e.Graphics.DrawString(date1, fnt, Brushes.Black, New RectangleF(62, l, 77, 25), sf2)
            e.Graphics.DrawString(Id, fnt, Brushes.Black, New RectangleF(142, l, 67, size.Height), sf)
            e.Graphics.DrawString(prdName, fnt, Brushes.Black, New RectangleF(212, l, 217, size.Height), sf)
            e.Graphics.DrawString(ht, fnt, Brushes.Black, New RectangleF(432, l, 67, 25), sf1)
            e.Graphics.DrawString(tva, fnt, Brushes.Black, New RectangleF(502, l, 57, 25), sf1)
            e.Graphics.DrawString(Total, fnt, Brushes.Black, New RectangleF(562, l, 67, 25), sf1)
            e.Graphics.DrawString(reg, fnt, Brushes.Black, New RectangleF(632, l, 47, 25), sf2)
            e.Graphics.DrawString(DESIG, fnt, Brushes.Black, New RectangleF(682, l, 97, size.Height), sf)
            l = l + size.Height + 5
            m += 1


            Try
                If Form1.CBTVA.Checked Then
                    Dim dtailsData As DataTable

                    Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                        Dim PARAMS As New Dictionary(Of String, Object)
                        PARAMS.Add("fctid", Id)
                        Dim tableName = "DetailsBon"
                        If isSell Then tableName = "DetailsFacture"
                        dtailsData = c.SelectDataTable(tableName, {"*"}, PARAMS)
                        If dtailsData.Rows.Count > 0 Then

                            For i As Integer = 0 To dtailsData.Rows.Count - 1

                                Dim t As Decimal = (dtailsData.Rows(i).Item("price") * dtailsData.Rows(i).Item("qte")) / ((100 + dtailsData.Rows(i).Item("tva")) / 100)
                                t = t - (t * CDbl(dtailsData.Rows(i).Item("poid") / 100)) / 100
                                t = (t * dtailsData.Rows(i).Item("tva")) / 100

                                If myTva.ContainsKey(dtailsData.Rows(i).Item("tva")) Then
                                    myTva(dtailsData.Rows(i).Item("tva")) += t
                                Else
                                    If dtailsData.Rows(i).Item("tva") > 0 Then
                                        myTva.Add(dtailsData.Rows(i).Item("tva"), t)
                                    End If
                                End If
                            Next
                        End If
                    End Using

                End If
            Catch ex As Exception

            End Try
        End While

        Dim avc As Decimal = 0
        Dim Ttva As Decimal = 0
        Dim ttc As Decimal = 0

        For I As Integer = 0 To data.Rows.Count - 1
            Ttva += CDec(data.Rows(I).Cells(5).Value)
            ttc += CDec(data.Rows(I).Cells(3).Value)
            avc += CDec(data.Rows(I).Cells(4).Value)
        Next

        e.Graphics.DrawLine(pn, 522, 850, 770, 850)
        e.Graphics.DrawLine(pn, 522, 880, 770, 880)
        e.Graphics.DrawLine(pn, 522, 910, 770, 910)
        e.Graphics.DrawLine(pn, 522, 940, 770, 940)
        '
        e.Graphics.DrawLine(pn, 522, 850, 522, 940)
        e.Graphics.DrawLine(pn, 630, 850, 630, 940)
        e.Graphics.DrawLine(pn, 770, 850, 770, 940)

        e.Graphics.DrawString("Total HT", fnt, Brushes.Black, New RectangleF(522, 860, 96, 22), sf)
        e.Graphics.DrawString("TVA", fnt, Brushes.Black, New RectangleF(522, 890, 66, 92), sf)
        e.Graphics.DrawString("Total TTC", fnt, Brushes.Black, New RectangleF(522, 920, 90, 22), sf)

        e.Graphics.DrawString(String.Format("{0:n}", ttc - Ttva), fnt, Brushes.Black, New RectangleF(635, 860, 132, 22), sf1)
        e.Graphics.DrawString(String.Format("{0:n}", Ttva), fnt, Brushes.Black, New RectangleF(635, 890, 132, 22), sf1)
        e.Graphics.DrawString(String.Format("{0:n}", ttc), fnt, Brushes.Black, New RectangleF(635, 920, 132, 22), sf1)


        ''''''
        If Form1.CBTVA.Checked Then

            Dim _x As Integer = 60
            Dim _y As Integer = 910
            Dim _i As Integer = 0

            e.Graphics.DrawLine(pn, 60, _y, 500, _y)
            _y = _y + 10
            For Each kvp As KeyValuePair(Of String, Double) In myTva

                Dim _t As String = String.Format("{0:n}", CDec(kvp.Value))

                Dim size As SizeF = e.Graphics.MeasureString("TVA [" & kvp.Key & "%]  = " & _t, fnt)

                If _x + size.Width > 440 Then
                    _x = 60
                    _y = _y + 15
                    'e.Graphics.DrawLine(pn, 60, l + 45, 500, _y)
                End If

                e.Graphics.DrawString("TVA [" & kvp.Key & "%]  = " & _t, fnt, Brushes.Black, New RectangleF(_x, _y, 440 - _x, 22), sf)
                e.Graphics.DrawLine(pn, _x + size.Width + 5, _y, _x + size.Width + 5, _y + 15)
                _x += size.Width + 10
            Next
            e.Graphics.DrawLine(pn, 60, _y + 20, 500, _y + 20)
        End If
        '''''

        myTva.Clear()
        l = 250
        m = 0
    End Sub
    'Rapports
    Public Sub RepportArticle(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal data As DataGridView,
                              ByVal datarpl As DataTable, ByVal article As String, ByVal isSell As Boolean,
                              ByVal str As String, ByVal strdt As String, ByVal isSearch As Boolean, ByRef m As Integer)

        Dim pen As New Pen(Brushes.Black, 1.0F)
        Dim pn As New Pen(Brushes.Black, 0.5F)

        Dim fnt As New Font("Arial", 10)
        Dim fntTitle As New Font("Arial", 14, FontStyle.Bold)

        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Near
        Dim sf1 As New StringFormat()
        sf1.Alignment = StringAlignment.Far
        Dim sf2 As New StringFormat()
        sf2.Alignment = StringAlignment.Center

        Dim dte As Date = Now.Date

        Dim myPoints() As Point = New Point() {New Point(60, 160), New Point(600, 160),
                                               New Point(612, 175), New Point(600, 190),
                                               New Point(60, 190)}
        e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
        e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

        myPoints = {New Point(606, 160), New Point(770, 160),
                   New Point(770, 190), New Point(606, 190),
                   New Point(618, 175)}
        e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
        e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

        'print date 
        e.Graphics.DrawString(dte.ToString("dd MMMM, yyyy"), fnt, Brushes.Black, New RectangleF(620, 167, 144, 24), sf1)
        'print  num Facture 

        e.Graphics.DrawString(str, fntTitle, Brushes.Black, 65, 165)
        e.Graphics.DrawString(strdt, fntTitle, Brushes.Black, 65, 190)

        If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60, 230)

        'Draw the table
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, 60, l, 710, 25)
        e.Graphics.DrawRectangle(pen, 60, l, 710, 600)
        e.Graphics.DrawLine(pn, 60, l + 25, 770, l + 25)

        e.Graphics.DrawLine(pn, 180, l, 180, 850)
        e.Graphics.DrawLine(pn, 260, l, 260, 850)
        e.Graphics.DrawLine(pn, 460, l, 460, 850)
        e.Graphics.DrawLine(pn, 560, l, 560, 850)
        e.Graphics.DrawLine(pn, 660, l, 660, 850)

        If isSearch Then
            e.Graphics.DrawString("Date", fnt, Brushes.Black, New RectangleF(60, l + 5, 120, 25), sf2)
        Else
            e.Graphics.DrawString("Nbr fct.", fnt, Brushes.Black, New RectangleF(60, l + 5, 120, 25), sf2)
        End If

        e.Graphics.DrawString("Id", fnt, Brushes.Black, New RectangleF(180, l + 5, 80, 25), sf2)
        e.Graphics.DrawString("Nom", fnt, Brushes.Black, New RectangleF(260, l + 5, 200, 25), sf2)
        e.Graphics.DrawString("Qte", fnt, Brushes.Black, New RectangleF(460, l + 5, 100, 25), sf2)
        e.Graphics.DrawString("P. Achat", fnt, Brushes.Black, New RectangleF(560, l + 5, 100, 25), sf2)
        e.Graphics.DrawString("P. Vente", fnt, Brushes.Black, New RectangleF(660, l + 5, 110, 25), sf2)

        l = 280

        While m < data.Rows.Count

            If l + 180 > e.MarginBounds.Height Then
                e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605, 870)
                l = 250
                e.HasMorePages = True
                Return
            End If
            Dim date1 As String = data.Rows(m).Cells(0).Value
            If isSearch Then date1 = CDate(data.Rows(m).Cells(0).Value).ToString("dd MMMM, yyyy")
            Dim Id As String = data.Rows(m).Cells(1).Value
            Dim prdName As String = data.Rows(m).Cells(2).Value
            Dim QTE As String = String.Format("{0:n}", CDec(data.Rows(m).Cells(3).Value))
            Dim bprice As String = String.Format("{0:n}", CDec(data.Rows(m).Cells(4).Value))
            Dim sprice As String = String.Format("{0:n}", CDec(data.Rows(m).Cells(5).Value))

            ''''''
            Dim size As SizeF = e.Graphics.MeasureString(prdName, fnt, 290)
            e.Graphics.DrawString(date1, fnt, Brushes.Black, New RectangleF(62, l, 116, size.Height), sf)
            e.Graphics.DrawString(Id, fnt, Brushes.Black, New RectangleF(182, l, 76, 25), sf2)
            e.Graphics.DrawString(prdName, fnt, Brushes.Black, New RectangleF(262, l, 195, size.Height), sf)
            e.Graphics.DrawString(QTE, fnt, Brushes.Black, New RectangleF(462, l, 95, 25), sf1)
            e.Graphics.DrawString(bprice, fnt, Brushes.Black, New RectangleF(562, l, 95, 25), sf1)
            e.Graphics.DrawString(sprice, fnt, Brushes.Black, New RectangleF(662, l, 105, 25), sf1)

            l = l + size.Height + 5
            m += 1
        End While

        'Signatures
        Dim sig As Integer = datarpl.Rows.Count
        Dim w As Integer = 710
        w = CInt(w - (20 * sig))
        w = CInt(w / sig)

        For i As Integer = 0 To sig - 1
            Dim st As Integer = 60 + i * w + i * 20
            e.Graphics.DrawRectangle(pen, st, 860, w, 100)

            e.Graphics.DrawString(datarpl.Rows(i).Item("name") & " :", fnt, Brushes.Black, st + 3, 870)
            e.Graphics.DrawString(String.Format("{0:n}", CDec(datarpl.Rows(i).Item("price"))), fnt, Brushes.Black, st + 3, 890)
        Next

        l = 250
        m = 0
    End Sub
    Public Sub RepportClientDetails(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal data As DataGridView,
                              ByVal datarpl As DataTable, ByVal txt As String, ByRef m As Integer)

        Dim pen As New Pen(Brushes.Black, 1.0F)
        Dim pn As New Pen(Brushes.Black, 0.5F)

        Dim fnt As New Font("Arial", 10)
        Dim fntTitle As New Font("Arial", 14, FontStyle.Bold)

        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Near
        Dim sf1 As New StringFormat()
        sf1.Alignment = StringAlignment.Far
        Dim sf2 As New StringFormat()
        sf2.Alignment = StringAlignment.Center

        Dim dte As Date = Now.Date

        Dim myPoints() As Point = New Point() {New Point(60, 160), New Point(600, 160),
                                               New Point(612, 175), New Point(600, 190),
                                               New Point(60, 190)}
        e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
        e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

        myPoints = {New Point(606, 160), New Point(770, 160),
                   New Point(770, 190), New Point(606, 190),
                   New Point(618, 175)}
        e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
        e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

        'print date 
        e.Graphics.DrawString(dte.ToString("dd MMMM, yyyy"), fnt, Brushes.Black, New RectangleF(620, 167, 144, 24), sf1)
        e.Graphics.DrawString(txt, fntTitle, Brushes.Black, 65, 165)
        If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60, 230)

        'talbe titles:
        e.Graphics.DrawString("ID", fnt, Brushes.Black, New RectangleF(50, l + 5, 50, 25), sf)
        e.Graphics.DrawString("Nom", fnt, Brushes.Black, New RectangleF(100, l + 5, 200, 25), sf)
        e.Graphics.DrawString("--", fnt, Brushes.Black, New RectangleF(300, l + 5, 60, 25), sf)
        e.Graphics.DrawString("Nbr", fnt, Brushes.Black, New RectangleF(360, l + 5, 50, 25), sf)
        e.Graphics.DrawString("Total", fnt, Brushes.Black, New RectangleF(410, l + 5, 100, 25), sf)
        e.Graphics.DrawString("Avance", fnt, Brushes.Black, New RectangleF(510, l + 5, 100, 25), sf)
        e.Graphics.DrawString("Rest.", fnt, Brushes.Black, New RectangleF(610, l + 5, 100, 25), sf)
        e.Graphics.DrawString("--", fnt, Brushes.Black, New RectangleF(710, l + 5, 60, 25), sf)

        'table headers lines
        e.Graphics.DrawLine(pen, 50, l + 25, 95, l + 25)
        e.Graphics.DrawLine(pen, 100, l + 25, 295, l + 25)
        e.Graphics.DrawLine(pen, 300, l + 25, 355, l + 25)
        e.Graphics.DrawLine(pen, 360, l + 25, 405, l + 25)
        e.Graphics.DrawLine(pen, 410, l + 25, 505, l + 25)
        e.Graphics.DrawLine(pen, 510, l + 25, 605, l + 25)
        e.Graphics.DrawLine(pen, 610, l + 25, 705, l + 25)
        e.Graphics.DrawLine(pen, 710, l + 25, 770, l + 25)

        l = 280

        While m < data.Rows.Count

            If l + 180 > e.MarginBounds.Height Then
                e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605, 870)
                l = 250
                e.HasMorePages = True
                Return
            End If
            Dim Id As String = data.Rows(m).Cells(0).Value
            Dim prdName As String = data.Rows(m).Cells(1).Value
            Dim AAA As String = data.Rows(m).Cells(2).Value
            Dim nbr As String = data.Rows(m).Cells(3).Value
            Dim total As String = String.Format("{0:n}", CDec(data.Rows(m).Cells(4).Value))
            Dim avc As String = String.Format("{0:n}", CDec(data.Rows(m).Cells(5).Value))
            Dim rest As String = String.Format("{0:n}", CDec(data.Rows(m).Cells(6).Value))
            Dim bbb As String = data.Rows(m).Cells(7).Value
            ''''''
            Dim size As SizeF = e.Graphics.MeasureString(prdName, fnt, 290)
            e.Graphics.DrawString(Id, fnt, Brushes.Black, New RectangleF(50, l + 5, 100, 25), sf)
            e.Graphics.DrawString(prdName, fnt, Brushes.Black, New RectangleF(100, l + 5, 200, 25), sf)
            e.Graphics.DrawString(AAA, fnt, Brushes.Black, New RectangleF(300, l + 5, 60, 25), sf)
            e.Graphics.DrawString(nbr, fnt, Brushes.Black, New RectangleF(360, l + 5, 50, 25), sf)
            e.Graphics.DrawString(total, fnt, Brushes.Black, New RectangleF(410, l + 5, 100, 25), sf)
            e.Graphics.DrawString(avc, fnt, Brushes.Black, New RectangleF(510, l + 5, 100, 25), sf)
            e.Graphics.DrawString(rest, fnt, Brushes.Black, New RectangleF(610, l + 5, 100, 25), sf)
            e.Graphics.DrawString(bbb, fnt, Brushes.Black, New RectangleF(710, l + 5, 60, 25), sf)

            l = l + size.Height + 5
            m += 1
        End While

        'Signatures
        Dim sig As Integer = datarpl.Rows.Count - 1
        Dim w As Integer = 710
        w = CInt(w - (20 * sig))
        w = CInt(w / sig)

        For i As Integer = 0 To sig - 1
            Dim st As Integer = 60 + i * w + i * 20
            e.Graphics.DrawRectangle(pen, st, 860, w, 55)

            e.Graphics.DrawString(datarpl.Rows(i).Item("name") & " :", fnt, Brushes.Black, st + 3, 870)
            e.Graphics.DrawString(String.Format("{0:n}", CDec(datarpl.Rows(i).Item("price"))), fnt, Brushes.Black, st + 3, 890)
        Next

        l = 250
        m = 0
    End Sub
    Public Sub RepportPayement(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal data As DataGridView, ByVal TXT As String, ByVal trest As String, ByVal totalFcts As String, ByVal avcFcts As String, ByVal isSell As Boolean, ByRef m As Integer)

        Dim pen As New Pen(Brushes.Black, 1.0F)
        Dim pn As New Pen(Brushes.Black, 0.5F)

        Dim fnt As New Font("Arial", 10)
        Dim fntTitle As New Font("Arial", 14, FontStyle.Bold)

        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Near
        Dim sf1 As New StringFormat()
        sf1.Alignment = StringAlignment.Far
        Dim sf2 As New StringFormat()
        sf2.Alignment = StringAlignment.Center


        Dim dte As Date = Now.Date


        Dim myPoints() As Point = New Point() {New Point(60, 160), New Point(600, 160),
                                               New Point(612, 175), New Point(600, 190),
                                               New Point(60, 190)}
        e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
        e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

        myPoints = {New Point(606, 160), New Point(770, 160),
                   New Point(770, 190), New Point(606, 190),
                   New Point(618, 175)}
        e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
        e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

        'print date 
        e.Graphics.DrawString(dte.ToString("dd MMMM, yyyy"), fnt, Brushes.Black, New RectangleF(620, 167, 144, 24), sf1)
        'print  num Facture 
        If isSell Then
            e.Graphics.DrawString("l'état des clients ", fntTitle, Brushes.Black, 65, 165)
        Else
            e.Graphics.DrawString("l'état des fournisseur", fntTitle, Brushes.Black, 65, 165)
        End If

        'print Client 
        e.Graphics.DrawString(TXT, fnt, Brushes.Black, 65, 200)

        If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60, 230)

        'Draw the table
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, 60, l, 710, 25)
        e.Graphics.DrawRectangle(pen, 60, l, 710, 600)
        e.Graphics.DrawLine(pn, 60, l + 25, 770, l + 25)

        e.Graphics.DrawLine(pn, 210, l, 210, 850)
        e.Graphics.DrawLine(pn, 330, l, 330, 850)
        e.Graphics.DrawLine(pn, 480, l, 480, 850)
        e.Graphics.DrawLine(pn, 630, l, 630, 850)

        e.Graphics.DrawString("Date", fnt, Brushes.Black, New RectangleF(60, l + 5, 150, 25), sf2)
        e.Graphics.DrawString("Id", fnt, Brushes.Black, New RectangleF(210, l + 5, 120, 25), sf2)
        e.Graphics.DrawString("Total", fnt, Brushes.Black, New RectangleF(330, l + 5, 150, 25), sf2)
        e.Graphics.DrawString("Avance", fnt, Brushes.Black, New RectangleF(480, l + 5, 150, 25), sf2)
        e.Graphics.DrawString("Rest", fnt, Brushes.Black, New RectangleF(630, l + 5, 140, 25), sf2)


        l = 280

        While m < data.Rows.Count

            If l + 180 > e.MarginBounds.Height Then
                e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605, 870)
                l = 250
                e.HasMorePages = True
                Return
            End If
            Dim date1 As String = CDate(data.Rows(m).Cells(3).Value).ToString("dd MMMM, yyyy")
            Dim Id As String = data.Rows(m).Cells(1).Value
            Dim TOTAL As String = String.Format("{0:n}", CDec(data.Rows(m).Cells(4).Value))
            Dim AVANCE As String = String.Format("{0:n}", CDec(data.Rows(m).Cells(5).Value))
            Dim REST As String = String.Format("{0:n}", CDec(data.Rows(m).Cells(4).Value - data.Rows(m).Cells(5).Value))

            ''''''


            e.Graphics.DrawString(date1, fnt, Brushes.Black, New RectangleF(62, l, 145, 25), sf)
            e.Graphics.DrawString(Id, fnt, Brushes.Black, New RectangleF(212, l, 115, 25), sf2)
            e.Graphics.DrawString(TOTAL, fnt, Brushes.Black, New RectangleF(332, l, 145, 25), sf1)
            e.Graphics.DrawString(AVANCE, fnt, Brushes.Black, New RectangleF(482, l, 145, 25), sf1)
            e.Graphics.DrawString(REST, fnt, Brushes.Black, New RectangleF(632, l, 95, 135), sf1)

            l = l + 25
            m += 1
        End While
        e.Graphics.DrawString("Total :" & trest, fnt, Brushes.Black, New RectangleF(60, 865, 300, 22), sf)
        e.Graphics.DrawString("Avance :" & trest, fnt, Brushes.Black, New RectangleF(230, 865, 300, 22), sf)
        e.Graphics.DrawString("REST :" & trest, fnt, Brushes.Black, New RectangleF(400, 865, 300, 22), sf)

        l = 250
        m = 0
    End Sub

    Public Sub RepportStock(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal data As DataGridView, ByRef m As Integer)

        Dim pen As New Pen(Brushes.Black, 1.0F)
        Dim pn As New Pen(Brushes.Black, 0.5F)

        Dim fnt As New Font("Arial", 10)
        Dim fntTitle As New Font("Arial", 14, FontStyle.Bold)

        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Near
        Dim sf1 As New StringFormat()
        sf1.Alignment = StringAlignment.Far
        Dim sf2 As New StringFormat()
        sf2.Alignment = StringAlignment.Center


        Dim dte As Date = Now.Date


        Dim myPoints() As Point = New Point() {New Point(60, 160), New Point(600, 160),
                                               New Point(612, 175), New Point(600, 190),
                                               New Point(60, 190)}
        e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
        e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

        myPoints = {New Point(606, 160), New Point(770, 160),
                   New Point(770, 190), New Point(606, 190),
                   New Point(618, 175)}
        e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
        e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

        'print date 
        e.Graphics.DrawString(dte.ToString("dd MMMM, yyyy"), fnt, Brushes.Black, New RectangleF(620, 167, 144, 24), sf1)
        'print  num Facture 

        e.Graphics.DrawString("Valeur de stock ", fntTitle, Brushes.Black, 65, 165)



        If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60, 230)

        'Draw the table
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, 60, l, 710, 25)
        e.Graphics.DrawRectangle(pen, 60, l, 710, 600)
        e.Graphics.DrawLine(pn, 60, l + 25, 770, l + 25)

        e.Graphics.DrawLine(pn, 110, l, 110, 850)
        e.Graphics.DrawLine(pn, 360, l, 360, 850)
        e.Graphics.DrawLine(pn, 560, l, 560, 850)

        e.Graphics.DrawString("N°", fnt, Brushes.Black, New RectangleF(60, l + 5, 50, 25), sf2)
        e.Graphics.DrawString("Nom de Categorie", fnt, Brushes.Black, New RectangleF(110, l + 5, 250, 25), sf2)
        e.Graphics.DrawString("Nbres Articles", fnt, Brushes.Black, New RectangleF(360, l + 5, 200, 25), sf2)
        e.Graphics.DrawString("Valeur", fnt, Brushes.Black, New RectangleF(560, l + 5, 210, 25), sf2)

        l = 280

        While m < data.Rows.Count - 2

            If l + 180 > e.MarginBounds.Height Then
                e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605, 870)
                l = 250
                e.HasMorePages = True
                Return
            End If
            Dim Id As String = m + 1
            Dim name As String = data.Rows(m).Cells(1).Value
            Dim ctgr As String = data.Rows(m).Cells(2).Value
            Dim value As String = data.Rows(m).Cells(3).Value

            ''''''

            e.Graphics.DrawString(Id, fnt, Brushes.Black, New RectangleF(60, l + 5, 50, 25), sf2)
            e.Graphics.DrawString(name, fnt, Brushes.Black, New RectangleF(110, l + 5, 250, 25), sf)
            e.Graphics.DrawString(ctgr, fnt, Brushes.Black, New RectangleF(360, l + 5, 200, 25), sf)
            e.Graphics.DrawString(value, fnt, Brushes.Black, New RectangleF(560, l + 5, 200, 25), sf1)

            l = l + 25
            m += 1
        End While
        l += 5

        e.Graphics.FillRectangle(Brushes.WhiteSmoke, 60, 850, 710, 25)
        e.Graphics.DrawRectangle(Pens.Gray, 60, 850, 710, 25)


        e.Graphics.DrawString("", fnt, Brushes.Black, New RectangleF(60, 850 + 5, 50, 25), sf)
        e.Graphics.DrawString("Total :", fnt, Brushes.Black, New RectangleF(110, 850 + 5, 250, 25), sf)
        e.Graphics.DrawString(m & "Categories", fnt, Brushes.Black, New RectangleF(360, 850 + 5, 200, 25), sf2)
        e.Graphics.DrawString(data.Rows(m + 1).Cells(3).Value, fnt, Brushes.Black, New RectangleF(560, 850 + 5, 200, 25), sf1)

        l = 250
        m = 0
    End Sub

    Public Sub DrawCharges(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal data As DataGridView,
                           ByVal MONTH As String, ByVal totalht As Double, ByVal dte As String, ByRef m As Integer)
        Try
            Dim pen As New Pen(Brushes.Black, 1.0F)
            Dim pn As New Pen(Brushes.Black, 0.5F)

            Dim fnt As New Font(Form1.txtfname.Text, CInt(Form1.txtfntsize.Text))
            Dim fntTitle As New Font("Arial", 14, FontStyle.Bold)
            Dim fntsmall As New Font("Arial", 8)

            Dim sf As New StringFormat()
            sf.Alignment = StringAlignment.Near
            Dim sfR As New StringFormat()
            sfR.Alignment = StringAlignment.Far
            Dim sfC As New StringFormat()
            sfC.Alignment = StringAlignment.Center

            Dim myPoints() As Point = New Point() {New Point(60, 160), New Point(600, 160),
                                                   New Point(612, 175), New Point(600, 190),
                                                   New Point(60, 190)}
            e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            myPoints = {New Point(606, 160), New Point(770, 160),
                       New Point(770, 190), New Point(606, 190),
                       New Point(618, 175)}
            e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            'print date 
            e.Graphics.DrawString(dte, fnt, Brushes.Black, New RectangleF(620, 167, 144, 24), sfR)

            e.Graphics.DrawString("Charges : " & Form1.lbChargesMonth.Text, fntTitle, Brushes.Black, 65, 165)

            If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60, 230)

            e.Graphics.DrawString("Date", fnt, Brushes.Black, New RectangleF(60, l + 5, 120, 25), sf)
            e.Graphics.DrawString("Designation", fnt, Brushes.Black, New RectangleF(190, l + 5, 450, 25), sf)
            e.Graphics.DrawString("Montant", fnt, Brushes.Black, New RectangleF(650, l + 5, 120, 25), sfR)

            e.Graphics.DrawLine(pen, 60, l + 20, 180, l + 20)
            e.Graphics.DrawLine(pen, 190, l + 20, 640, l + 20)
            e.Graphics.DrawLine(pen, 650, l + 20, 770, l + 20)
            l = 280

            While m < data.Rows.Count

                If l + 180 > e.MarginBounds.Height Then
                    e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605, 870)
                    l = 250
                    e.HasMorePages = True
                    Return
                End If

                Dim dd As String = CDate(data.Rows(m).Cells(1).Value).ToString("dd MM, yyyy")
                Dim prdName As String = data.Rows(m).Cells(2).Value
                Dim montant As String = String.Format("{0:F}", data.Rows(m).Cells(3).Value)

                ''''''
                Dim size As SizeF = e.Graphics.MeasureString(prdName, fnt, 450)

                e.Graphics.DrawString("[ " & dd & " ]  ", fnt, Brushes.Black, New RectangleF(60, l, 120, size.Height), sf)
                e.Graphics.DrawString(prdName, fnt, Brushes.Black, New RectangleF(190, l, 450, size.Height), sf)
                e.Graphics.DrawString(montant, fnt, Brushes.Black, New RectangleF(650, l, 120, size.Height), sfR)

                l = l + size.Height + 5
                m += 1
            End While

            Dim Total As String = String.Format("{0:F}", totalht)

            If l < 720 Then l = 720
            e.Graphics.DrawLine(pen, 60, l + 25, 770, l + 25)
            e.Graphics.DrawString("Total ", fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf)
            e.Graphics.DrawString(Total, fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sfR)
            e.Graphics.DrawLine(pen, 550, l + 45, 770, l + 45)
        Catch ex As Exception
            l = 250
            m = 0
        End Try

        l = 250
        m = 0
    End Sub

    Public Sub DrawAvoir(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal data As DataGridView, ByVal fid As Integer,
                           ByVal CName As String, ByVal CAdresse As String, ByVal totalttc As Double,
                           ByVal dte As Date, ByRef m As Integer)

        Dim pen As New Pen(Brushes.Black, 1.0F)
        Dim pn As New Pen(Brushes.Black, 0.5F)

        Dim fnt As New Font(Form1.txtfname.Text, CInt(Form1.txtfntsize.Text))
        Dim fntTitle As New Font("Arial", 14, FontStyle.Bold)

        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Near
        Dim sf1 As New StringFormat()
        sf1.Alignment = StringAlignment.Far
        Dim sf2 As New StringFormat()
        sf2.Alignment = StringAlignment.Center

        Dim fctid As Integer = fid
        Dim clientName As String = CName

        Dim myPoints() As Point = New Point() {New Point(60, 160), New Point(600, 160),
                                               New Point(612, 175), New Point(600, 190),
                                               New Point(60, 190)}
        e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
        e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

        myPoints = {New Point(606, 160), New Point(770, 160),
                   New Point(770, 190), New Point(606, 190),
                   New Point(618, 175)}
        e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
        e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

        'print date 
        e.Graphics.DrawString(dte.ToString("dd MMMM, yyyy"), fnt, Brushes.Black, New RectangleF(620, 167, 144, 24), sf1)
        'print  num Facture 

        e.Graphics.DrawString("Avoir  N° : " & fctid, fntTitle, Brushes.Black, 65, 165)


        'print Client 
        e.Graphics.DrawString("M : " & clientName, fnt, Brushes.Black, 65, 200)
        e.Graphics.DrawString(CAdresse, fnt, Brushes.Black, 65, 215)

        If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60, 230)

        'Draw the table
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, 60, l, 710, 25)
        e.Graphics.DrawRectangle(pen, 60, l, 710, 600)
        e.Graphics.DrawLine(pn, 60, l + 25, 770, l + 25)


        'e.Graphics.DrawLine(pn, 420, l, 420, 850)
        e.Graphics.DrawLine(pn, 475, l, 475, 850)
        e.Graphics.DrawLine(pn, 550, l, 550, 850)
        e.Graphics.DrawLine(pn, 630, l, 630, 850)


        e.Graphics.DrawString("Designation", fnt, Brushes.Black, New RectangleF(60, l + 5, 415, 25), sf2)
        'e.Graphics.DrawString("Unite", fnt, Brushes.Black, New RectangleF(420, l + 5, 55, 25), sf2)
        e.Graphics.DrawString("Qte", fnt, Brushes.Black, New RectangleF(475, l + 5, 75, 25), sf2)
        e.Graphics.DrawString("P.U", fnt, Brushes.Black, New RectangleF(550, l + 5, 80, 25), sf2)
        e.Graphics.DrawString("Total ", fnt, Brushes.Black, New RectangleF(630, l + 5, 140, 25), sf2)

        l = 280

        While m < data.Rows.Count

            If l + 180 > e.MarginBounds.Height Then
                e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605, 870)
                l = 250
                e.HasMorePages = True
                Return
            End If

            'Dim ref As String = data.Rows(m).Item("code")

            'Dim unite As String = data.Rows(m).Item("unite")
            Dim qte As String = String.Format("{0:F}", data.Rows(m).Cells(3).Value)
            Dim price As String = String.Format("{0:F}", data.Rows(m).Cells(7).Value)
            Dim total As String = String.Format("{0:F}", data.Rows(m).Cells(7).Value * data.Rows(m).Cells(3).Value)
            Dim prdName As String = data.Rows(m).Cells(2).Value & "( " & data.Rows(m).Cells(3).Value & " )"
            ''''''

            Dim size As SizeF = e.Graphics.MeasureString(prdName, fnt, 290)

            e.Graphics.DrawString(prdName, fnt, Brushes.Black, New RectangleF(62, l, 410, size.Height), sf)
            'e.Graphics.DrawString(unite, fnt, Brushes.Black, New RectangleF(421, l, 51, 17), sf)
            e.Graphics.DrawString(qte, fnt, Brushes.Black, New RectangleF(477, l, 71, 25), sf1)
            e.Graphics.DrawString(price, fnt, Brushes.Black, New RectangleF(552, l, 76, 25), sf1)
            e.Graphics.DrawString(total, fnt, Brushes.Black, New RectangleF(632, l, 136, 25), sf1)

            l = l + size.Height + 5
            m += 1
        End While

        Dim ttc As String = String.Format("{0:F}", totalttc)

        e.Graphics.DrawLine(pn, 550, 855, 770, 855)
        e.Graphics.DrawLine(pn, 550, 885, 770, 885)
        e.Graphics.DrawLine(pn, 550, 915, 770, 915)

        e.Graphics.DrawLine(pn, 550, 855, 550, 915)
        e.Graphics.DrawLine(pn, 610, 855, 610, 915)
        e.Graphics.DrawLine(pn, 770, 855, 770, 915)

        e.Graphics.DrawString("Total  ", fnt, Brushes.Black, New RectangleF(555, 860, 60, 22), sf)
        e.Graphics.DrawString(ttc & " (Dhs)", fnt, Brushes.Black, New RectangleF(615, 860, 120, 22), sf)

        If Form1.TxtSignature.Text <> "" Then
            'Signatures
            Dim sig As String() = Form1.TxtSignature.Text.Split("*")
            Dim w As Integer = 710
            w = CInt(w - (20 * (sig.Length - 1)))
            w = CInt(w / sig.Length)

            For i As Integer = 0 To sig.Length - 1
                Dim st As Integer = 60 + i * w + i * 20
                e.Graphics.DrawRectangle(pen, st, 955, w, 100)

                Dim size2 As SizeF = e.Graphics.MeasureString(sig(i), fnt)
                e.Graphics.FillRectangle(Brushes.White, st + 10, 946, size2.Width + 5, 15)

                e.Graphics.DrawString(sig(i), fnt, Brushes.Black, st + 12, 947)
            Next
        End If


        l = 250
        m = 0
    End Sub

    'draw article imgs
    Public Function Drawimg(ByVal name As String, ByVal sprice As String, ByVal im As String) As Bitmap
        Dim fnt As New Font("Arial", 8)

        'create the bitmap
        Dim BMG As New Bitmap(Form1.txtlongerbt.Text, Form1.txtlargebt.Text, Imaging.PixelFormat.Format24bppRgb)
        'ceate the graphic
        Dim GR As Graphics = Graphics.FromImage(BMG)
        GR.Clear(Color.White)

        'draw the lines
        Try
            Dim img As Image = Image.FromFile(im)

            If im = "" Or im = "No Image" Then
                Dim rnd As New Random
                GR.Clear(Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255)))
            Else
                GR.DrawImage(img, 0, 0, Integer.Parse(Form1.txtlongerbt.Text), Integer.Parse(Form1.txtlargebt.Text))
            End If
        Catch ex As Exception

        End Try

        Dim Sl As Size = TextRenderer.MeasureText(sprice, fnt)
        GR.FillRectangle(Brushes.Green, Integer.Parse(Form1.txtlongerbt.Text) - Integer.Parse(Sl.Width + 5), 3, Integer.Parse(Sl.Width + 5), Integer.Parse(Sl.Height + 5))
        GR.DrawString(sprice, fnt, Brushes.White, Integer.Parse(Form1.txtlongerbt.Text) - Integer.Parse(Sl.Width + 5) + 2, 32)

        Dim size As SizeF = GR.MeasureString(name, fnt, Form1.txtlongerbt.Text)
        GR.FillRectangle(Brushes.White, 0, Integer.Parse(Form1.txtlargebt.Text - size.Height - 5), Integer.Parse(Form1.txtlongerbt.Text), Integer.Parse(size.Height + 5))
        GR.DrawString(sprice, fnt, Brushes.Black, 2, Integer.Parse(Form1.txtlargebt.Text - size.Height))

        Return BMG
    End Function

    'draw bon de caisse
    Public Sub Drawpayemt(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal data As DataGridView, ByVal Pid As String,
                            ByVal clientName As String, ByVal Clid As String, ByVal fctid As String,
                             ByVal isSell As Boolean, ByVal dte As Date, ByVal mnt As Double,
                             ByVal way As String, ByVal nm As String, ByRef m As Integer)

        Dim pen As New Pen(Brushes.Black, 1.0F)
        Dim pn As New Pen(Brushes.Black, 0.5F)

        Dim fnt As New Font(Form1.txtfname.Text, CInt(Form1.txtfntsize.Text))
        Dim fntTitle As New Font("Arial", 12, FontStyle.Bold)

        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Center

        Dim Nsf As New StringFormat()
        Nsf.Alignment = StringAlignment.Near

        e.Graphics.DrawString(Form1.txttitle.Text, fntTitle, Brushes.Black, New RectangleF(10, 20, 300, 55), sf)
        e.Graphics.DrawString(Form1.txttel.Text, fnt, Brushes.Black, New RectangleF(10, 80, 300, 30), sf)

        Try
            e.Graphics.DrawImage(Image.FromFile(Form1.txtLogo.Text), 10, 10, 300, 120)
        Catch ex As Exception

        End Try


        'Dim myPoints() As Point = New Point() {New Point(10, 160), New Point(270, 160),
        '                                       New Point(282, 175), New Point(270, 190),
        '                                       New Point(10, 190)}
        '  e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
        'e.Graphics.DrawPolygon(New Pen(Brushes.Black, 0.5F), myPoints)

        'print date 
        e.Graphics.DrawString(dte.ToString("dd MMMM, yyyy"), fnt, Brushes.Black, 15, 166)
        'print  num Facture 
        If isSell Then
            e.Graphics.DrawString("Bon d'Entree de Caisse  N° : " & Pid, fntTitle, Brushes.Black, 15, 135)
        Else
            e.Graphics.DrawString("Bon d'Sortie de Caisse  N°: " & Pid, fntTitle, Brushes.Black, 15, 135)
        End If

        'print Client 
        e.Graphics.DrawString("M : " & clientName & " - [" & Clid & "]", fnt, Brushes.Black, 15, 200)

        e.Graphics.DrawString("Mode de Paiement : " & way, fnt, Brushes.Black, 15, 230)

        Dim strNUM As String = "N° : " & nm
        Dim szNM As SizeF = e.Graphics.MeasureString(strNUM, fnt, 350)
        e.Graphics.DrawString(strNUM, fnt, Brushes.Black, New RectangleF(15, 245, 350, szNM.Height), Nsf)

        l = 255 + szNM.Height

        e.Graphics.DrawString("Sur Bon de Livraison N° : " & fctid, fnt, Brushes.Black, 15, l)


        e.Graphics.DrawString("Montant: " & String.Format("{0:F}", mnt) & " Dhs", fntTitle, Brushes.Black, 15, l + 20)

        Dim strTotal As String = NumericStrings.GetNumberWords(CDec(mnt)) & " (Dhs)"
        Dim sze As SizeF = e.Graphics.MeasureString(strTotal, fnt, 350)
        e.Graphics.DrawString(strTotal, fnt, Brushes.Black, New RectangleF(15, l + 40, 350, sze.Height), Nsf)


        l += 80 + sze.Height
        e.Graphics.DrawString("Details : ", fnt, Brushes.Black, 15, l)
        e.Graphics.DrawLine(pn, 10, l + 20, 300, l + 20)

        l = l + 30
        Dim REST As Double = 0
        While m < data.Rows.Count

            'Dim ref As String = data.Rows(m).Item("code")
            Dim id As String = data.Rows(m).Cells(1).Value
            Dim t As String = String.Format("{0:F}", data.Rows(m).Cells(2).Value)
            Dim v As String = String.Format("{0:F}", data.Rows(m).Cells(3).Value)
            Dim R As String = String.Format("{0:F}", t - v)

            REST += R
            ''''''
            e.Graphics.DrawString(id, fnt, Brushes.Black, 10, l)
            e.Graphics.DrawString("|  " & t, fnt, Brushes.Black, 72, l)
            e.Graphics.DrawString("|  " & v, fnt, Brushes.Black, 142, l)
            e.Graphics.DrawString("|  " & R, fnt, Brushes.Black, 212, l)

            l = l + 15
            m += 1
        End While

        Dim rr As String = String.Format("{0:F}", REST)

        e.Graphics.DrawString("--------------------------------------", fnt, Brushes.Black, 72, l)
        e.Graphics.DrawString("Rest |  " & rr, fnt, Brushes.Black, 72, l + 15)

        l = 250
        m = 0
    End Sub
    Public Sub DrawpayemtFct(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal Pid As String,
                         ByVal clientName As String, ByVal Clid As String, ByVal fctid As String,
                          ByVal isSell As Boolean, ByVal dte As Date, ByVal mnt As Double,
                          ByVal way As String, ByVal nm As String, ByRef m As Integer)

        Dim pen As New Pen(Brushes.Black, 1.0F)
        Dim pn As New Pen(Brushes.Black, 0.5F)

        Dim fnt As New Font(Form1.txtfname.Text, CInt(Form1.txtfntsize.Text))
        Dim fntTitle As New Font("Arial", 12, FontStyle.Bold)

        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Center

        Dim Nsf As New StringFormat()
        Nsf.Alignment = StringAlignment.Near

        e.Graphics.DrawString(Form1.txttitle.Text, fntTitle, Brushes.Black, New RectangleF(10, 20, 300, 55), sf)
        e.Graphics.DrawString(Form1.txttel.Text, fnt, Brushes.Black, New RectangleF(10, 80, 300, 30), sf)

        Try
            e.Graphics.DrawImage(Image.FromFile(Form1.txtLogo.Text), 10, 10, 300, 120)
        Catch ex As Exception

        End Try


        'Dim myPoints() As Point = New Point() {New Point(10, 160), New Point(270, 160),
        '                                       New Point(282, 175), New Point(270, 190),
        '                                       New Point(10, 190)}
        '  e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
        'e.Graphics.DrawPolygon(New Pen(Brushes.Black, 0.5F), myPoints)

        'print date 
        e.Graphics.DrawString(dte.ToString("dd MMMM, yyyy"), fnt, Brushes.Black, 15, 166)
        'print  num Facture 

        e.Graphics.DrawString("Bon d'Entree de Caisse  N° : " & Pid, fntTitle, Brushes.Black, 15, 135)

        'print Client 
        e.Graphics.DrawString("M : " & clientName & " - [" & Clid & "]", fnt, Brushes.Black, 15, 200)

        e.Graphics.DrawString("Mode de Paiement : " & way, fnt, Brushes.Black, 15, 230)

        Dim strNUM As String = "N° : " & nm
        Dim szNM As SizeF = e.Graphics.MeasureString(strNUM, fnt, 350)
        e.Graphics.DrawString(strNUM, fnt, Brushes.Black, New RectangleF(15, 245, 350, szNM.Height), Nsf)

        l = 255 + szNM.Height

        e.Graphics.DrawString("Sur Facture N° : " & fctid, fnt, Brushes.Black, 15, l)


        e.Graphics.DrawString("Montant: " & String.Format("{0:F}", mnt) & " Dhs", fntTitle, Brushes.Black, 15, l + 20)

        Dim strTotal As String = NumericStrings.GetNumberWords(CDec(mnt)) & " (Dhs)"
        Dim sze As SizeF = e.Graphics.MeasureString(strTotal, fnt, 350)
        e.Graphics.DrawString(strTotal, fnt, Brushes.Black, New RectangleF(15, l + 40, 350, sze.Height), Nsf)


        l += 80 + sze.Height
        e.Graphics.DrawString("Details : ", fnt, Brushes.Black, 15, l)
        e.Graphics.DrawLine(pn, 10, l + 20, 300, l + 20)

        l = 250
        m = 0
    End Sub
    Public Sub DrawRelve(ByRef e As System.Drawing.Printing.PrintPageEventArgs,
                           ByVal daTa As DataGridView,
                           ByVal title As String, ByVal entete As Boolean,
                           ByVal restbon As String, ByVal restfact As String, ByVal rest As String,
                          ByRef m As Integer)
        Try
            Dim pen As New Pen(Brushes.Black, 1.0F)
            Dim pn As New Pen(Brushes.Black, 0.5F)

            Dim fnt As New Font(Form1.txtfname.Text, CInt(Form1.txtfntsize.Text))
            Dim fntTitle As New Font("Arial", 14, FontStyle.Bold)
            Dim fntsmall As New Font("Arial", 8)

            Dim sf_L As New StringFormat()
            sf_L.Alignment = StringAlignment.Near
            Dim sf_R As New StringFormat()
            sf_R.Alignment = StringAlignment.Far
            Dim sfC As New StringFormat()
            sfC.Alignment = StringAlignment.Center


            Dim m_Entete = Form1.txtEnteteMarge.Text
            If Not IsNumeric(m_Entete) Then m_Entete = 160

            Dim m_Pied = Form1.txtPiedMarge.Text
            If Not IsNumeric(m_Pied) Then m_Pied = 750

            l = m_Entete

            Dim h = m_Pied - 20
            Dim w = e.MarginBounds.Width
            Dim a As Double = Form1.txtScale.Text
            Try
                e.Graphics.DrawImage(Image.FromFile(Form1.txtLogo.Text), 10, 10, 300, 120)
            Catch ex As Exception

            End Try

            'e.Graphics.FillRectangle(Brushes.Honeydew, 60, l + 25, 300, 65)
            e.Graphics.FillRectangle(Brushes.WhiteSmoke, CInt(60 * a), l, CInt(630 * a), 30)

            e.Graphics.DrawString("Relve Client : " & title, fntTitle, Brushes.Black, CInt(65 * a), l + 5)

            'e.Graphics.DrawString("FACTURE : ", fntTitle, Brushes.Black, 65, l + 5)
            e.Graphics.DrawString("Date : " & Now.Date.ToString("dd MMM yyyy"), fnt, Brushes.Black, CInt(65 * a), l - 20)

            If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 460 * a, l)

            l += 33

            e.Graphics.DrawRectangle(pen, CInt(55 * a), l, CInt(780 * a), 22)

            e.Graphics.DrawString("Date", fnt, Brushes.Black, New RectangleF(60 * a, l + 5, 200 * a, 25), sf_L)
            e.Graphics.DrawString("Type", fnt, Brushes.Black, New RectangleF(265 * a, l + 5, 200 * a, 25), sf_L)
            e.Graphics.DrawString("Sortie", fnt, Brushes.Black, New RectangleF(470 * a, l + 5, 150 * a, 25), sf_R)
            e.Graphics.DrawString("Entrée", fnt, Brushes.Black, New RectangleF(625 * a, l + 5, 150 * a, 25), sf_R)

            pn.DashCap = System.Drawing.Drawing2D.DashCap.Round

            e.Graphics.DrawLine(pen, CInt(262 * a), l, CInt(262 * a), l + 22)
            e.Graphics.DrawLine(pen, CInt(468 * a), l, CInt(468 * a), l + 22)
            'e.Graphics.DrawLine(pen, CInt(680 * a), l, CInt(680 * a), l + 22)


            l += 25

            While m < daTa.Rows.Count

                If l > h Then
                    e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605 * a, m_Pied + 5)
                    l = m_Entete
                    e.HasMorePages = True
                    Return
                End If


                Dim D As String = daTa.Rows(m).Cells(0).Value
                Dim T As String = daTa.Rows(m).Cells(1).Value
                Dim R As String = daTa.Rows(m).Cells(2).Value
                Dim P As String = daTa.Rows(m).Cells(3).Value

                ''''''
                e.Graphics.DrawString(D, fnt, Brushes.Black, New RectangleF(60 * a, l, CInt(200 * a), 25), sf_L)
                e.Graphics.DrawString(T, fnt, Brushes.Black, New RectangleF(CInt(265 * a), l, 200 * a, 25), sf_L)
                e.Graphics.DrawString(R, fnt, Brushes.Black, New RectangleF(CInt(470 * a), l, 150 * a, 25), sf_R)
                e.Graphics.DrawString(P, fnt, Brushes.Black, New RectangleF(625 * a, l, 150 * a, 25), sf_R)


                l = l + 22
                m += 1
            End While

            If l < m_Pied Then l = m_Pied

            e.Graphics.DrawLine(pen, CInt(55 * a), l, CInt(680 * a), l)
            e.Graphics.DrawString("Factures", fnt, Brushes.Black, New RectangleF(430 * a, l + 29, 320 * a, 22), sf_L)
            e.Graphics.DrawString(restfact, fnt, Brushes.Black, New RectangleF(430 * a, l + 29, 320 * a, 22), sf_R)

            e.Graphics.DrawLine(pn, CInt(430 * a), l + 45, CInt(680 * a), l + 45)
            e.Graphics.DrawString("Bons", fnt, Brushes.Black, New RectangleF(430 * a, l + 49, 320 * a, 22), sf_L)
            e.Graphics.DrawString(restbon, fnt, Brushes.Black, New RectangleF(430 * a, l + 49, 320 * a, 22), sf_R)


            e.Graphics.DrawLine(pn, CInt(430 * a), l + 65, CInt(680 * a), l + 65)
            e.Graphics.DrawString("Total", fnt, Brushes.Black, New RectangleF(430 * a, l + 69, 320 * a, 22), sf_L)
            e.Graphics.DrawString(rest, fnt, Brushes.Black, New RectangleF(430 * a, l + 69, 320 * a, 22), sf_R)
            l += 20

            Try
                If entete Then e.Graphics.DrawImage(Image.FromFile(Form1.txtLogo.Text), CInt(10 * a), CInt(h - 20), CInt(750 * a), 120)
            Catch ex As Exception
            End Try

        Catch ex As Exception
            l = 200
            m = 0
        End Try

        l = 200
        m = 0
    End Sub


    Public Sub RepportFactureRecept(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal _dt1 As Date, ByVal _dt2 As Date)
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

            Dim pen As New Pen(Brushes.Black, 1.0F)
            Dim pn As New Pen(Brushes.Black, 0.5F)

            Dim fnt As New Font("Arial", 9)
            Dim fntTitle As New Font("Arial", 14, FontStyle.Bold)
            Dim fntH2 As New Font("Arial", 11, FontStyle.Bold)

            Dim sf As New StringFormat()
            sf.Alignment = StringAlignment.Near
            Dim sf1 As New StringFormat()
            sf1.Alignment = StringAlignment.Far
            Dim sf2 As New StringFormat()
            sf2.Alignment = StringAlignment.Center


            Dim dte As Date = Now.Date

            e.Graphics.DrawString(Form1.txttitle.Text, fntTitle, Brushes.Black, New RectangleF(10, 20, 300, 55), sf2)
            e.Graphics.DrawString(Form1.txtAdrs.Text, fnt, Brushes.Black, New RectangleF(10, 80, 300, 30), sf2)
            e.Graphics.DrawString(Form1.txttel.Text, fnt, Brushes.Black, New RectangleF(10, 100, 300, 30), sf2)

            Try
                e.Graphics.DrawImage(Image.FromFile(Form1.txtLogo.Text), 10, 10, 300, 120)
            Catch ex As Exception

            End Try

            Dim myPoints() As Point = New Point() {New Point(10, 150), New Point(270, 150),
                                                   New Point(282, 165), New Point(270, 180),
                                                   New Point(10, 180)}
            '  e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Black, 0.5F), myPoints)

            'print date 
            e.Graphics.DrawString(dte, fnt, Brushes.Black, 15, 130)

            e.Graphics.DrawString("Rapport  ", fntTitle, Brushes.Black, 15, 155)


            'print Client 
            e.Graphics.DrawString("De " & _dt1.ToString("dd / MM / yyyy"), fnt, Brushes.Black, New RectangleF(15, 195, 275, 35), sf)
            e.Graphics.DrawString("Au " & _dt2.ToString("dd / MM / yyyy"), fnt, Brushes.Black, New RectangleF(15, 220, 275, 35), sf)
            e.Graphics.DrawString("Imprimé par : " & Form1.adminName, fnt, Brushes.Black, New RectangleF(15, 240, 275, 35), sf)

            l = 265
            'Dim dt1 As Date = Date.Parse(Form1.dte2.Text).AddDays(1)
            'Dim dt2 As Date = Date.Parse(Form1.dte1.Text).AddDays(-1)

            Dim dt1 = New DateTime(_dt2.Year, _dt2.Month, _dt2.Day, 23, 59, 0, 0)
            Dim dt2 = New DateTime(_dt1.Year, _dt1.Month, _dt1.Day, 0, 1, 0, 0)

            'Dim dt1 As Date = Date.Parse(Form1.dte2.Text).AddDays(1)
            'Dim dt2 As Date = Date.Parse(Form1.dte1.Text)
            Dim params As New Dictionary(Of String, Object)
            Dim dt As DataTable = Nothing
            Dim TT As Decimal = 0

            Dim ttall As Double = 0
            Dim ttBoy As Double = 0
            Dim ttGirl As Double = 0
            Dim tttrk As Double = 0
            Dim ttmsg As Double = 0


            Dim WHERE As New Dictionary(Of String, Object)
            Dim tb As String = "Facture"
            Dim tb_D As String = "DetailsFacture"


            l += 30

            Dim STR As String() = {"NONE", "حــمام بــلدي", "الحلاقة", "التركي"}

            Dim totalProduct As Double = 0
            Dim totalSell As Double = 0

            If Form1.txtGroupe.Text.Contains("4") = True Then
                Try
                    'totalProduct = dFTA.ScalarQuerySumProduct(dt1, dt2, True, 4)
                    params.Clear()
                    params.Add(tb & ".date >", dt2)
                    params.Add(tb & ".date <", dt1)
                    params.Add(tb & ".admin = ", True)
                    params.Add(tb_D & ".cid =", 4)
                    params.Add(tb & ".writer = ", Form1.adminName)

                    totalProduct = c.SelectByScalar("(DetailsFacture INNER JOIN Facture ON DetailsFacture.fctid = Facture.fctid)",
                                "SUM(DetailsFacture.qte * DetailsFacture.price) AS Expr1", params)
                     
                Catch ex As Exception
                    totalProduct = 0
                End Try

            End If

            For z As Integer = 1 To 3
                Try
                    If Form1.txtGroupe.Text.Contains(z) = True Then
                        Dim a, b
                        Try
                            ' SELECT        
                            'FROM    
                            'WHERE   (Facture.[date] < ?) AND (Facture.[date] > ?) AND (Facture.admin = ?) AND (DetailsFacture.cid = ?)



                            params.Clear()
                            params.Add(tb & ".date >", dt2)
                            params.Add(tb & ".date <", dt1)
                            params.Add(tb & ".admin = ", True)
                            params.Add(tb_D & ".cid =", z)
                            params.Add(tb & ".writer = ", Form1.adminName)

                            a = c.SelectByScalar("(DetailsFacture INNER JOIN Facture ON DetailsFacture.fctid = Facture.fctid)",
                               "SUM(DetailsFacture.qte) AS Expr1", params)

                            b = c.SelectByScalar("(DetailsFacture INNER JOIN Facture ON DetailsFacture.fctid = Facture.fctid)",
                              "SUM(DetailsFacture.qte * DetailsFacture.price) AS Expr1", params)

                            'a = dFTA.ScalarQuerycount(dt1, dt2, True, z)
                            'b = dFTA.ScalarQuerySum(dt1, dt2, True, z)
                        Catch ex As Exception
                            a = 0
                            b = 0
                        End Try

                        If z = 1 Then b += totalProduct

                        e.Graphics.FillRectangle(Brushes.WhiteSmoke, 5, l - 3, 280, 25)
                        e.Graphics.DrawString(a & "  --  " & b & " Dhs   ||  " & STR(z), fntH2, Brushes.Black, New RectangleF(15, l, 275, 20), sf2)

                        totalSell += b

                        l += 30
                        Dim msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "Cat_Ham_" & z, Nothing)
                        If Not IsNothing(msg) Then
                            Dim cat As String() = msg.ToString.Split("-")
                            For r As Integer = 0 To cat.Length - 1
                                Dim lll = l + 8
                                Dim ttt As Double = 0

                                l += 33

                                ' ORDER BY sprice DESC
                                'Dim dta = dA.GetDataByCidHammam(z, cat(r))
                                params.Clear()
                                params.Add("cid", z)
                                params.Add("codebar", cat(r))

                                Dim dta = c.SelectDataTable("Article", {"*"}, params)


                                If dta.Rows.Count > 0 Then
                                    For i As Integer = 0 To dta.Rows.Count - 1
                                        Dim aa
                                        Dim ba
                                        Try

                                            params.Clear()
                                            params.Add(tb & ".date >", dt2)
                                            params.Add(tb & ".date <", dt1)
                                            params.Add(tb & ".admin = ", True)
                                            params.Add(tb_D & ".arid =", dta.Rows(i).Item(0))

                                            aa = c.SelectByScalar("(DetailsFacture INNER JOIN Facture ON DetailsFacture.fctid = Facture.fctid)",
                                               "SUM(DetailsFacture.qte) AS Expr1", params)
                                            ba = c.SelectByScalar("(DetailsFacture INNER JOIN Facture ON DetailsFacture.fctid = Facture.fctid)",
                                            "SUM(DetailsFacture.qte * DetailsFacture.price) AS Expr1", params)


                                            '    aa = dFTA.ScalarQueryArid(dt1, dt2, True, )
                                            '    ba = dFTA.ScalarQuerySumArid(dt1, dt2, True, dta.Rows(i).Item(0))
                                        Catch ex As Exception
                                            aa = 0
                                            ba = 0
                                        End Try
                                        ttt += ba

                                        'check if article start with * to print it s details 
                                        If cat(r).StartsWith("*") = False Then Continue For
                                        If aa = 0 Then Continue For
                                        Try
                                            e.Graphics.DrawString(aa & "  -  " & String.Format("{0:n}", CDec(ba)) & " Dhs", fnt, Brushes.Black, New RectangleF(15, l, 275, 20), sf)
                                            e.Graphics.DrawString(dta.Rows(i).Item("name"), fnt, Brushes.Black, New RectangleF(15, l, 275, 20), sf1)
                                            l += 20
                                        Catch ex As Exception
                                        End Try
                                    Next
                                End If

                                e.Graphics.DrawString(cat(r), fntH2, Brushes.Black, New RectangleF(15, lll, 165, 20), sf)
                                e.Graphics.DrawString("|", fnt, Brushes.Black, 185, lll)
                                e.Graphics.DrawString(String.Format("{0:n}", CDec(ttt)), fntH2, Brushes.Black, New RectangleF(190, lll, 85, 20), sf1)

                                dta = Nothing
                            Next

                            If z = 1 And totalProduct > 0 Then
                                e.Graphics.DrawRectangle(Pens.Black, 5, l - 3, 280, 25)
                                e.Graphics.DrawString("المواد", fnt, Brushes.Black, New RectangleF(15, l + 2, 265, 20), sf1)

                                e.Graphics.DrawString(String.Format("{0:n}", CDec(totalProduct)) & " Dhs", fnt, Brushes.Black, New RectangleF(15, l + 2, 111, 20), sf1)
                                l += 30
                            End If

                        End If
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                l += 33
            Next

            e.Graphics.DrawString("----------------------------------------", fnt, Brushes.Black, New RectangleF(15, l + 3, 275, 20), sf)
            e.Graphics.DrawString("Total       ||     " & totalSell & " Dhs       ||     المجموع", fnt, Brushes.Black, New RectangleF(15, l + 10 + 3, 275, 20), sf)
            e.Graphics.DrawString("----------------------------------------", fnt, Brushes.Black, New RectangleF(15, l + 30 + 3, 275, 20), sf)




            ' ''''''''''''''''''''''''''''''''''''''''''''''''
            'l += 60
            'Dim BTA As New ALMohassinDBDataSetTableAdapters.BonTableAdapter
            'Try
            '    Dim a = BTA.ScalarQuery(dt1, dt2)
            '    Dim b = BTA.ScalarQuerytotal(dt1, dt2)
            '    Dim c = BTA.ScalarQueryAvc(dt1, dt2)

            '    e.Graphics.FillRectangle(Brushes.WhiteSmoke, 5, l - 3, 280, 25)
            '    e.Graphics.DrawRectangle(Pens.Black, 5, l - 3, 280, 25)

            '    e.Graphics.DrawString(a & "    |     Achates       |    ايصالات المشتريات", fnt, Brushes.Black, New RectangleF(15, l, 275, 20), sf2)
            '    l += 10
            '    e.Graphics.DrawString("Total       ||     " & b & " Dhs       ||     المجموع", fnt, Brushes.Black, New RectangleF(15, l + 20 + 3, 275, 20), sf)
            '    e.Graphics.DrawString("Avance       ||     " & c & " Dhs       ||     الدفــع", fnt, Brushes.Black, New RectangleF(15, l + 40 + 3, 275, 20), sf)

            'Catch ex As Exception
            'End Try

            'l += 80

            'Dim CTA As New ALMohassinDBDataSetTableAdapters.ChargeTableAdapter
            'Try
            '    Dim a = CTA.ScalarQueryCount(dt1, dt2)
            '    Dim b = CTA.ScalarQueryTotal(dt1, dt2)

            '    e.Graphics.FillRectangle(Brushes.WhiteSmoke, 5, l - 3, 280, 25)
            '    e.Graphics.DrawRectangle(Pens.Black, 5, l - 3, 280, 25)

            '    e.Graphics.DrawString(a & "    |     Charges       |    ايصالات المصرفات", fnt, Brushes.Black, New RectangleF(15, l, 275, 20), sf2)
            '    l += 10
            '    e.Graphics.DrawString("Total       ||     " & b & " Dhs       ||     المجموع", fnt, Brushes.Black, New RectangleF(15, l + 20 + 3, 275, 20), sf)
            'Catch ex As Exception
            'End Try

        End Using

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
