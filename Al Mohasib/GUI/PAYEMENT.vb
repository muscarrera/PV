Public Class PAYEMENT
    Public isSell As Boolean
    Private clid As Integer
    Private clientName As String
    Private txt As String
    Private totalFcts As Double
    Private avcFcts As Double

    Private Sub PAYEMENT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If isSell = False Then Button3.Text = "اختيار المورد"
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        DGVP.Rows.Clear()
        dgvfct.Rows.Clear()
        dgvfct.Columns(2).Visible = False
        GroupBox2.Width = 390
        Dim tableName As String = "Facture"
        If isSell = False Then tableName = "Bon"

        Try
            Dim chs As New ChoseClient
            chs.isSell = isSell
            If chs.ShowDialog = Windows.Forms.DialogResult.OK Then
                If chs.btOk.Tag = "0" Then

                Else
                    txtname.Tag = chs.cid
                    txtname.Text = chs.clientName
                    clid = chs.cid
                    clientName = txtname.Text

                    Dim CrdSum As Integer = 0
                    totalFcts = 0
                    avcFcts = 0
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

                        Dim params As New Dictionary(Of String, Object)
                        params.Add("admin", True)
                        params.Add("payed", False)
                        params.Add("clid", clid)

                        Dim fdt = c.SelectDataTable(tableName, {"*"}, params)
                        If fdt.Rows.Count > 0 Then
                            For f As Integer = 0 To fdt.Rows.Count - 1
                                CrdSum = CrdSum + (fdt.Rows(f).Item("Total") - fdt.Rows(f).Item("Avance"))
                                dgvfct.Rows.Add(fdt.Rows(f).Item(0), fdt.Rows(f).Item(0), fdt.Rows(f).Item("name"), fdt.Rows(f).Item("date"), fdt.Rows(f).Item("total"), fdt.Rows(f).Item("avance"), fdt.Rows(f).Item("payed"))
                                totalFcts += CDbl(fdt.Rows(f).Item("Total"))
                                avcFcts += CDbl(fdt.Rows(f).Item("Avance"))
                            Next
                            txtcrd.Text = CrdSum
                            txtcrd.Tag = CrdSum
                        Else
                            txtcrd.Text = CrdSum
                            txtcrd.Tag = CrdSum
                        End If
                    End Using

                    ''''''''''''''''''
                    Dim ta As New ALMohassinDBDataSetTableAdapters.PaymentTableAdapter

                    For t As Integer = 0 To dgvfct.Rows.Count - 1
                        Dim dt = ta.GetDataByfctid(CInt(dgvfct.Rows(t).Cells(0).Value))
                        For i As Integer = 0 To dt.Rows.Count - 1
                            DGVP.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("montant"), dt.Rows(i).Item("way"), dt.Rows(i).Item("date"), dt.Rows(i).Item("Num"), dt.Rows(i).Item("writer"), dt.Rows(i).Item("fctid"), dt.Rows(i).Item("fctid"))
                        Next
                    Next
                End If

                Dim cta As New ALMohassinDBDataSetTableAdapters.ClientTableAdapter
                cta.Updatecredit(txtcrd.Text, txtname.Tag)
            End If
        Catch ex As Exception

        End Try



    End Sub

   

    Private Sub Button35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button35.Click
        'validation
        ''empty field
        If txtname.Text.Trim = "" Then
            Exit Sub
        End If

        If txtcrd.Text = "" Or txtcrd.Text <= 0 Then
            MsgBox("لا يتوفر على دين")
            Exit Sub
        End If

        Dim pay As New paypmt

        If pay.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtmp.Text = pay.txtmontant.Text
            txtmp.Tag = 0
            Dim avc As Double = Double.Parse(pay.txtmontant.Text)


            Dim MyCon As OleDb.OleDbConnection = Nothing
            Dim MyTRans As OleDb.OleDbTransaction = Nothing
            'start a transaction object

            Try
                MyCon = New OleDb.OleDbConnection(My.Settings.ALMohassinDBConnectionString)
                MyCon.Open()

                MyTRans = MyCon.BeginTransaction
                If avc > 0 Then

                    Dim SQL As String = "insert into Payment (name,clid,montant,way,[date],Num,fctid,writer) values (:1,:2,:3,:4,:5,:6,:7,:8)"
                    Dim CMD1 As New OleDb.OleDbCommand
                    CMD1.Connection = MyCon
                    CMD1.Transaction = MyTRans
                    CMD1.CommandText = SQL
                    CMD1.Parameters.AddWithValue(":1", txtname.Text)
                    CMD1.Parameters.AddWithValue(":2", txtname.Tag)
                    CMD1.Parameters.AddWithValue(":3", avc)
                    CMD1.Parameters.AddWithValue(":4", pay.cbway.SelectedItem)
                    CMD1.Parameters.AddWithValue(":5", Now.Date)
                    CMD1.Parameters.AddWithValue(":6", pay.txtnum.Text)
                    CMD1.Parameters.AddWithValue(":7", 0)
                    CMD1.Parameters.AddWithValue(":8", Form1.admin)
                    CMD1.ExecuteNonQuery()
                    CMD1.Dispose()
                 
                Else
                    Exit Sub
                End If


                '  txtcrd.Text = Double.Parse(txtcrd.Text) - Double.Parse(pay.txtmontant.Text)
                txtcrd.Text = Double.Parse(txtcrd.Text) - avc

                'select receipt id 
                Dim Sql2 As String = "update Client set credit=:1 where clid=:2"
                Dim CMD2 As New OleDb.OleDbCommand
                CMD2.Connection = MyCon
                CMD2.Transaction = MyTRans
                CMD2.CommandText = Sql2
                CMD2.Parameters.AddWithValue(":1", txtcrd.Text)
                CMD2.Parameters.AddWithValue(":2", txtname.Tag)
                CMD2.ExecuteNonQuery()
                CMD2.Dispose()


                'all will save the changes
                MyTRans.Commit()

                ''close all 
                MyTRans.Dispose()
                MyCon.Close()
                MyCon.Dispose()


                ''''''''''''''''''''''''''''''''''''''''''''''"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""''show

                txtcrd.Tag = txtcrd.Text


                Dim ta As New ALMohassinDBDataSetTableAdapters.PaymentTableAdapter
                DGVP.Rows.Clear()


                Dim dt = ta.GetData(Integer.Parse(txtname.Tag))
                For i As Integer = 0 To dt.Rows.Count - 1

                    DGVP.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("montant"), dt.Rows(i).Item("way"), dt.Rows(i).Item("date"), dt.Rows(i).Item("Num"), dt.Rows(i).Item("writer"), dt.Rows(i).Item("fctid"), dt.Rows(i).Item("fctid"))

                Next





                Try
                    'impimer ticket
                    'print button

                    Dim sv As New SavePrint
                    sv.Button2.Visible = False
                    If sv.ShowDialog = Windows.Forms.DialogResult.OK Then
                        If sv.RadioButton2.Checked Then
                            coransy = 20
                        ElseIf sv.RadioButton3.Checked Then
                            coransy = 100
                        Else
                            coransy = 1
                        End If
                        If sv.Button1.Tag = "1" Then
                            If Form1.txttimp.Text <> "" Then
                                'select the printer
                                Try
                                    PrintDocR.PrinterSettings.PrinterName = Form1.txttimp.Text
                                    PrintDocR.Print()

                                Catch ex As Exception

                                    If Form1.PrintDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                                        PrintDocR.PrinterSettings.PrinterName = Form1.PrintDlg.PrinterSettings.PrinterName
                                        PrintDocR.Print()
                                    End If
                                End Try
                            Else
                                MsgBox("لم تقم بإختبار اسم الطابعة ", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
                            End If
                        End If

                    End If

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
                End Try

            Catch ex As Exception
                If MyTRans IsNot Nothing Then
                    MyTRans.Rollback()
                End If
                If MyCon IsNot Nothing Then
                    If MyCon.State = ConnectionState.Open Then
                        MyCon.Close()
                    End If

                End If
                '  lbcrd.Text = lbcrd.Tag
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            End Try




        End If




        coransy = 1

    End Sub
    Dim coransy As Integer = 1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If DGVP.SelectedRows.Count = 0 Then
            Exit Sub
        End If

        If DGVP.SelectedRows(0).Cells(4).Value = "--" And DGVP.SelectedRows(0).Cells(2).Value <> "شيك" And DGVP.SelectedRows(0).Cells(2).Value <> "كاش" Then
            Exit Sub
        End If


        Dim pay As New paypmt
        pay.txtmontant.Text = DGVP.SelectedRows(0).Cells(1).Value.ToString
        pay.txtmontant.Tag = DGVP.SelectedRows(0).Cells(1).Value.ToString
        pay.txtnum.Text = DGVP.SelectedRows(0).Cells(4).Value.ToString
        pay.cbway.Text = DGVP.SelectedRows(0).Cells(2).Value.ToString
        If pay.cbway.Text <> "كاش" Then
            pay.txtnum.Visible = True
        End If




        If pay.ShowDialog = Windows.Forms.DialogResult.OK Then
            If pay.txtmontant.Text <> pay.txtmontant.Tag Then

                Dim a As Integer = DGVP.SelectedRows(0).Index
                Dim mnt As Double = Double.Parse(pay.txtmontant.Text)
                Dim def As Double = Double.Parse(pay.txtmontant.Text) - Double.Parse(pay.txtmontant.Tag)
                Dim avc As Double = 0
                Dim ttl As Double = 0
                Dim crd As Double = txtcrd.Text
                Dim payed As Boolean = False
                Dim ii As Integer = 0
                For ii = 0 To dgvfct.Rows.Count - 1
                    If dgvfct.Rows(ii).Cells(0).Value = DGVP.SelectedRows(0).Cells(7).Value Then
                        avc = dgvfct.Rows(ii).Cells(5).Value
                        ttl = dgvfct.Rows(ii).Cells(4).Value

                        Exit For
                    End If

                Next


                Dim MyCon As OleDb.OleDbConnection = Nothing
                Dim MyTRans As OleDb.OleDbTransaction = Nothing
                'start a transaction object

                Try
                    MyCon = New OleDb.OleDbConnection(My.Settings.ALMohassinDBConnectionString)
                    MyCon.Open()

                    MyTRans = MyCon.BeginTransaction

                    avc += def
                    crd -= def

                    def = 0

                    If avc > ttl Then
                        crd = crd + avc - ttl
                        def = ttl - avc - def
                        mnt = mnt + ttl - avc
                        avc = ttl
                        payed = True
                    ElseIf avc = ttl Then
                        payed = True
                    End If


                    Dim SQL As String = "update  Payment set montant=:1,way=:2,Num=:3,writer=:4 where Pid=:5 "
                    Dim CMD1 As New OleDb.OleDbCommand
                    CMD1.Connection = MyCon
                    CMD1.Transaction = MyTRans
                    CMD1.CommandText = SQL
                    CMD1.Parameters.AddWithValue(":1", mnt)
                    CMD1.Parameters.AddWithValue(":2", pay.cbway.SelectedItem)
                    CMD1.Parameters.AddWithValue(":3", pay.txtnum.Text)
                    CMD1.Parameters.AddWithValue(":4", Form1.admin)
                    CMD1.Parameters.AddWithValue(":5", DGVP.SelectedRows(0).Cells(0).Value)
                    CMD1.ExecuteNonQuery()
                    CMD1.Dispose()

                    SQL = "update facture set avance=:1 , payed=:2 where fctid=:3"
                    Dim CMD11 As New OleDb.OleDbCommand
                    CMD11.Connection = MyCon
                    CMD11.Transaction = MyTRans
                    CMD11.CommandText = SQL
                    CMD11.Parameters.AddWithValue(":1", avc)
                    CMD11.Parameters.AddWithValue(":2", payed)
                    CMD11.Parameters.AddWithValue(":3", dgvfct.Rows(ii).Cells(0).Value)

                    CMD11.ExecuteNonQuery()
                    CMD11.Dispose()

                    dgvfct.Rows(ii).Cells(5).Value = avc
                    dgvfct.Rows(ii).Cells(6).Value = payed

                 

            'select receipt id 
                    Dim Sql2 As String = "update Client set credit=:1 where clid=:2"
                    Dim CMD2 As New OleDb.OleDbCommand
                    CMD2.Connection = MyCon
                    CMD2.Transaction = MyTRans
                    CMD2.CommandText = Sql2
                    CMD2.Parameters.AddWithValue(":1", crd)
                    CMD2.Parameters.AddWithValue(":2", txtname.Tag)
                    CMD2.ExecuteNonQuery()
                    CMD2.Dispose()


            'all will save the changes
            MyTRans.Commit()

            ''close all 
            MyTRans.Dispose()
            MyCon.Close()
            MyCon.Dispose()


            ''''''''''''''''''''''''''''''''''''''''''''''"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""''show
                    txtcrd.Text = crd
            txtcrd.Tag = txtcrd.Text


            Dim ta As New ALMohassinDBDataSetTableAdapters.PaymentTableAdapter
            DGVP.Rows.Clear()

            For j As Integer = 0 To dgvfct.Rows.Count - 1
                Dim dt = ta.GetDataByfctid(dgvfct.Rows(j).Cells(0).Value)
                For i As Integer = 0 To dt.Rows.Count - 1

                    DGVP.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("montant"), dt.Rows(i).Item("way"), dt.Rows(i).Item("date"), dt.Rows(i).Item("Num"), dt.Rows(i).Item("writer"), dgvfct.Rows(j).Cells(1).Value, dt.Rows(i).Item("fctid"))

                Next



            Next



                    If def < 0 Then

                        MsgBox("لقد نم اداء هذه الفاتورة  بنجاح  ... المبلغ الذي يجب ارجاعه اليه هو '(" & def & ")' درهم")
                    End If

                Catch ex As Exception
                If MyTRans IsNot Nothing Then
                    MyTRans.Rollback()
                End If
                If MyCon IsNot Nothing Then
                    If MyCon.State = ConnectionState.Open Then
                        MyCon.Close()
                    End If

                End If
                '  lbcrd.Text = lbcrd.Tag
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            End Try
                DGVP.Rows(a).Selected = True
                DGVP.FirstDisplayedScrollingRowIndex = DGVP.Rows(a).Index


            End If
        End If



    End Sub



   

    Private Sub txtsearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsearch.KeyPress
        If Button1.Enabled = True Then
            If e.KeyChar = Chr(13) Then
                Button3_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub txtsearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsearch.KeyUp
        Button5_Click(Nothing, Nothing)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        For i As Integer = 0 To dgvfct.Rows.Count - 1
            If dgvfct.Rows(i).Cells(1).Value.ToString.Contains(txtsearch.Text) Then
                dgvfct.Rows(i).Selected = True
                dgvfct.FirstDisplayedScrollingRowIndex = dgvfct.Rows(i).Index
                Exit For
            End If
            If dgvfct.Rows(i).Cells(0).Value.ToString.Contains(txtsearch.Text) Then
                dgvfct.Rows(i).Selected = True
                dgvfct.FirstDisplayedScrollingRowIndex = dgvfct.Rows(i).Index
                Exit For
            End If
        Next
    End Sub
    Dim m As Integer = 0
    Private Sub PrintDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage
        Try
            If dgvfct.Rows.Count = 0 Then Exit Sub
            Using a As DrawClass = New DrawClass
                a.RepportPayement(e, dgvfct, clientName & " [ C-" & clid & " ]", txtcrd.Text, totalFcts, avcFcts, isSell, m)
            End Using

        Catch ex As Exception
            M = 0
        End Try
    End Sub

 
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If dgvfct.Rows.Count = 0 Then Exit Sub

        Try
            PrintDoc.PrinterSettings.PrinterName = Form1.txttimp.Text
            PrintDoc.Print()

        Catch ex As Exception

            If Form1.PrintDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintDoc.PrinterSettings.PrinterName = Form1.PrintDlg.PrinterSettings.PrinterName
                PrintDoc.Print()
            End If
        End Try

    End Sub

    Private Sub DGVP_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGVP.MouseDoubleClick
        Try
            MsgBox(DGVP.SelectedRows(0).Cells(4).Value & " // (" & DGVP.SelectedRows(0).Cells(5).Value & ")")
        Catch ex As Exception

        End Try
    End Sub

    

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim bdt As New byname
        If bdt.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim txt As String = bdt.txt.text


            Try
                Dim ta As New ALMohassinDBDataSetTableAdapters.PaymentTableAdapter
                Dim dt = ta.GetDataBynum(txt, "شيك")
                dgvfct.Rows.Clear()
                DGVP.Rows.Clear()
                If dt.Rows.Count > 0 Then


                    For i As Integer = 0 To dt.Rows.Count - 1

                        DGVP.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("montant"), dt.Rows(i).Item("way"), dt.Rows(i).Item("date"), dt.Rows(i).Item("Num"), dt.Rows(i).Item("writer"), dt.Rows(i).Item("fctid"))

                    Next

                Else
                    MsgBox("لا يوجد")

                End If




            Catch ex As Exception

            End Try




        End If


    End Sub

    

    Private Sub PrintDoc2_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc2.PrintPage


        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Far
        Dim sf2 As New StringFormat()
        sf2.Alignment = StringAlignment.Center

        Dim WidthUnit As Integer = 14
        Dim HeightUnit As Integer = 20
        Dim ReciptWidth As Integer = 17 * WidthUnit

        Dim a As Double = Form1.txtScale.Text
        Dim pn As New Pen(Brushes.Black, 0.0F)
        Dim fnt As New Font(Form1.txtfname.Text, Form1.txtfntsize.Text)
        Dim xx As String = ""
        Dim wd As Integer = Int((150 + 120 + 100 + 250 + 50 + 80 + 30 + 40) * a)
        Dim ht As Integer = 20 + Form1.txtfntsize.Text
        Dim FNTh1 As New Font(Form1.txtfname.Text, 14)

        If Form1.txttitlestart.Text = "" Or Not IsNumeric(Form1.txttitlestart.Text) Then
            Form1.txttitlestart.Text = "300"
        End If


        e.Graphics.DrawString(Form1.txttitle.Text, New Font(fnt, FontStyle.Bold), Brushes.Black, Form1.txttitlestart.Text, 70) '+ Integer.Parse(txttitle.Tag))




        e.Graphics.DrawString("كشف الحساب  ", fnt, Brushes.Black, 590 * a, 100) '+ Integer.Parse(txttitle.Tag))
        e.Graphics.DrawString(":تاريخ", fnt, Brushes.Black, 645 * a, 120) '+ Integer.Parse(txttitle.Tag))
        e.Graphics.DrawString(": الزبون", fnt, Brushes.Black, 635 * a, 140) '+ Integer.Parse(txttitle.Tag))

        Dim dt As String = Now.Date.Day & "/" & Now.Date.Month & "/" & Now.Date.Year

        e.Graphics.DrawString(dt, fnt, Brushes.Black, 500 * a, 120) ' + Integer.Parse(txttitle.Tag))
        e.Graphics.DrawString(txtname.Text, fnt, Brushes.Black, 500 * a, 140) ' + Integer.Parse(txttitle.Tag))

       
     
        '''''''''''''''''''''

        e.Graphics.DrawString(": الدين", fnt, Brushes.Black, New RectangleF(WidthUnit * 13, 200, WidthUnit * 4, 15), sf)
        xx = txtcrd.Text * coransy
        If xx.Contains(".") Then
            Dim dd As String()
            dd = xx.Split(".")
            dd(1) = dd(1) & "0"
            Try
                dd(1) = dd(1).Remove(2)
            Catch ex As Exception

            End Try
            xx = dd(0) & "." & dd(1)
        ElseIf xx.Contains(",") Then

            Dim dd As String()
            dd = xx.Split(",")
            dd(1) = dd(1) & "0"
            Try
                dd(1) = dd(1).Remove(2)
            Catch ex As Exception

            End Try

            xx = dd(0) & "," & dd(1)
        Else

            xx = xx & Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator & "00"
        End If
        e.Graphics.DrawString(xx, FNTh1, Brushes.Black, New RectangleF(WidthUnit * 1, 210, WidthUnit * 17, 30), sf2)
        e.Graphics.DrawString("***  merci  de  votre  visite  ***", New Font(fnt, FontStyle.Bold), Brushes.White, New RectangleF(5, 240, WidthUnit * 19, 25), sf2)


    End Sub

    Private Sub PrintDocR_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocR.PrintPage
        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Far
        Dim sf2 As New StringFormat()
        sf2.Alignment = StringAlignment.Center

        Dim WidthUnit As Integer = 14
        Dim HeightUnit As Integer = 20
        Dim ReciptWidth As Integer = 17 * WidthUnit


        Dim fontsize As Double = Form1.txtfntsize.Text
        Dim xx As String = ""



        Dim dt As Date = Date.Now
        Dim tm As String = DateTime.Now.Hour & ":" & DateTime.Now.Minute & ":" & DateTime.Now.Second
        Dim ReciptDate As String = dt.Day & "/" & dt.Month & "/" & dt.Year & " - " & tm
        Dim poid As String = 0


        Dim ClientName As String = txtname.Text

        ''''''''''''''''  count weight

        ' draw the lines
        Dim LNheaderYstart = 3 * HeightUnit
        Dim LNDetailsStart = LNheaderYstart + HeightUnit


        ' header text
        Dim FNT As New Font(Form1.txtfname.Text, 8)
        Dim FNTh1 As New Font(Form1.txtfname.Text, 14)


        e.Graphics.DrawString(Form1.txttitle.Text, New Font(FNTh1, FontStyle.Bold), Brushes.Black, New RectangleF(WidthUnit * 1, 10, WidthUnit * 15, 25), sf2)
        e.Graphics.DrawString(Form1.txttel.Text, FNT, Brushes.Black, New RectangleF(WidthUnit * 1, 35, WidthUnit * 15, 15), sf2)


        e.Graphics.DrawString(": إيصال أداء الدين", New Font(FNT, FontStyle.Bold), Brushes.Black, New RectangleF(5, 70, WidthUnit * 19, 15), sf2)
        e.Graphics.DrawString(": التاريخ", FNT, Brushes.Black, New RectangleF(WidthUnit * 13, 90, WidthUnit * 4, 15), sf)
        e.Graphics.DrawString(": الزبون", FNT, Brushes.Black, New RectangleF(WidthUnit * 13, 110, WidthUnit * 4, 15), sf)
     
        '  e.Graphics.DrawString(ReciptNo, New Font(FNT, FontStyle.Bold), Brushes.Black, New RectangleF(WidthUnit * 1, 70, WidthUnit * 12, 15), sf)
        e.Graphics.DrawString(ReciptDate, FNT, Brushes.Black, New RectangleF(WidthUnit * 1, 90, WidthUnit * 12, 15), sf)
        e.Graphics.DrawString(ClientName, FNT, Brushes.Black, New RectangleF(WidthUnit * 1, 110, WidthUnit * 12, 15), sf)

        e.Graphics.DrawLine(New Pen(Brushes.Black, 0.5), 5, 130, WidthUnit * 19 + 2, 130)

        e.Graphics.DrawString(": الدين القديم", New Font(FNT, FontStyle.Bold), Brushes.Black, New RectangleF(WidthUnit * 13, 140, WidthUnit * 4, 15), sf)
        e.Graphics.DrawString(": المبلغ", New Font(FNT, FontStyle.Bold), Brushes.Black, New RectangleF(WidthUnit * 13, 160, WidthUnit * 4, 15), sf)
        Dim rest As Double = txtcrd.Text * coransy
        Dim mt As Double = txtmp.Text * coransy
        Dim crd As Double = (mt + rest) * coransy

        xx = crd
        If xx.Contains(".") Then
            Dim dd As String()
            dd = xx.Split(".")
            dd(1) = dd(1) & "0"
            Try
                dd(1) = dd(1).Remove(2)
            Catch ex As Exception

            End Try
            xx = dd(0) & "." & dd(1)
        ElseIf xx.Contains(",") Then

            Dim dd As String()
            dd = xx.Split(",")
            dd(1) = dd(1) & "0"
            Try
                dd(1) = dd(1).Remove(2)
            Catch ex As Exception

            End Try

            xx = dd(0) & "," & dd(1)
        Else

            xx = xx & Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator & "00"
        End If

        e.Graphics.DrawString(xx, FNT, Brushes.Black, New RectangleF(WidthUnit * 8, 140, WidthUnit * 5, 15), sf)
        xx = mt
        If xx.Contains(".") Then
            Dim dd As String()
            dd = xx.Split(".")
            dd(1) = dd(1) & "0"
            Try
                dd(1) = dd(1).Remove(2)
            Catch ex As Exception

            End Try
            xx = dd(0) & "." & dd(1)
        ElseIf xx.Contains(",") Then

            Dim dd As String()
            dd = xx.Split(",")
            dd(1) = dd(1) & "0"
            Try
                dd(1) = dd(1).Remove(2)
            Catch ex As Exception

            End Try

            xx = dd(0) & "," & dd(1)
        Else

            xx = xx & Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator & "00"
        End If
        e.Graphics.DrawString(xx, FNT, Brushes.Black, New RectangleF(WidthUnit * 8, 160, WidthUnit * 5, 15), sf)

        e.Graphics.DrawLine(New Pen(Brushes.Black, 0.5), 5, 180, WidthUnit * 19 + 2, 180)

        e.Graphics.DrawString(": الباقي", FNT, Brushes.Black, New RectangleF(WidthUnit * 13, 200, WidthUnit * 4, 15), sf)
        xx = rest
        If xx.Contains(".") Then
            Dim dd As String()
            dd = xx.Split(".")
            dd(1) = dd(1) & "0"
            Try
                dd(1) = dd(1).Remove(2)
            Catch ex As Exception

            End Try
            xx = dd(0) & "." & dd(1)
        ElseIf xx.Contains(",") Then

            Dim dd As String()
            dd = xx.Split(",")
            dd(1) = dd(1) & "0"
            Try
                dd(1) = dd(1).Remove(2)
            Catch ex As Exception

            End Try

            xx = dd(0) & "," & dd(1)
        Else

            xx = xx & Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator & "00"
        End If
        e.Graphics.DrawString(xx, FNTh1, Brushes.Black, New RectangleF(WidthUnit * 1, 210, WidthUnit * 17, 30), sf2)
        e.Graphics.DrawString("***  merci  de  votre  visite  ***", New Font(FNT, FontStyle.Bold), Brushes.White, New RectangleF(5, 240, WidthUnit * 19, 25), sf2)

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DGVP.Rows.Clear()
        dgvfct.Rows.Clear()

        Try


            Dim ta As New ALMohassinDBDataSetTableAdapters.PaymentTableAdapter


            Dim dt = ta.GetDataByfctid(0)
            For i As Integer = 0 To dt.Rows.Count - 1

                DGVP.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("montant"), dt.Rows(i).Item("way"), dt.Rows(i).Item("date"), dt.Rows(i).Item("Num"), dt.Rows(i).Item("writer"), dt.Rows(i).Item("name"), dt.Rows(i).Item("fctid"))

            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        DGVP.Rows.Clear()
        dgvfct.Rows.Clear()
        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim CrdSum As Integer = 0

            Dim tableName As String = "Facture"
            If isSell = False Then tableName = "Bon"
            clid = 0
            clientName = "Tous"
            totalFcts = 0
            avcFcts = 0

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)
                params.Add("admin", True)
                params.Add("payed", False)

                Dim fdt = c.SelectDataTable(tableName, {"*"}, params)

                If fdt.Rows.Count > 0 Then
                    dgvfct.Columns(2).Visible = True
                    GroupBox2.Width = 0

                    For f As Integer = 0 To fdt.Rows.Count - 1
                        CrdSum = CrdSum + (fdt.Rows(f).Item("Total") - fdt.Rows(f).Item("Avance"))
                        dgvfct.Rows.Add(fdt.Rows(f).Item(0), fdt.Rows(f).Item(0), fdt.Rows(f).Item("name"), fdt.Rows(f).Item("date"), fdt.Rows(f).Item("total"), fdt.Rows(f).Item("avance"), fdt.Rows(f).Item("payed"))
                        totalFcts += CDbl(fdt.Rows(f).Item("Total"))
                        avcFcts += CDbl(fdt.Rows(f).Item("Avance"))
                    Next
                    txtcrd.Text = CrdSum
                    txtcrd.Tag = CrdSum
                Else
                    txtcrd.Text = CrdSum
                    txtcrd.Tag = CrdSum
                End If
            End Using

        Catch ex As Exception

        End Try
    End Sub
End Class