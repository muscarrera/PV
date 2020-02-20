Public Class GestionStock

    Private Sub ChangeValue()

        Dim nmdg As New num
        If nmdg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        If DGVS.SelectedRows.Count = 0 Then Exit Sub
        If Not IsNumeric(DGVS.SelectedRows(0).Cells(0).Value) Then Exit Sub

        Dim QTE = InputBox("NOUVEAU QTE =  ")
        If Not IsNumeric(QTE) Then Exit Sub

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim tableName As String = "Detailstock"

            Dim WHERE As New Dictionary(Of String, Object)
            WHERE.Add("DSID", DGVS.SelectedRows(0).Cells(0).Value)

            Dim params As New Dictionary(Of String, Object)
            params.Add("qte", QTE)

            c.UpdateRecord(tableName, params, WHERE)
            MsgBox("well done")
        End Using
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim ta As New ALMohassinDBDataSetTableAdapters.DetailstockTableAdapter
            Dim ta2 As New ALMohassinDBDataSetTableAdapters.DetailsFactureTableAdapter
            Dim ta3 As New ALMohassinDBDataSetTableAdapters.DetailsBonTableAdapter
            DGVS.Rows.Clear()

    
            '''''''''''''''''''''''''' ---------------------------- details facture 

            Dim dt22 = ta2.GetDataBydate(Now.Date.AddDays(1), Now.Date.AddDays(-1), cbdepot.SelectedValue)
            For j As Integer = 0 To dt22.Rows.Count - 1


                Dim qteout As Double = 0
                qteout = dt22.Rows(j).Item("qte")

                'search for the barcode in dgv2
                Dim i As Integer = 0
                Dim itemLOC As Integer = -1
                For i = 0 To DGVS.Rows.Count - 1
                    If dt22.Rows(j).Item("name") = DGVS.Rows(i).Cells(2).Value Then
                        'item found
                        itemLOC = i
                        Exit For
                    End If
                Next

                'if item no found 
                If itemLOC = -1 Then
                    DGVS.Rows.Add("", dt22.Rows(j).Item("code"), dt22.Rows(j).Item("name"), dt22.Rows(j).Item("unit"), 0, qteout, 0 - qteout, "", dt22.Rows(j).Item("depot"))

                Else
                    ' if already exist increase its count
                    Dim qte As Double = 0

                    qte = DGVS.Rows(itemLOC).Cells(5).Value + qteout
                    DGVS.Rows(itemLOC).Cells(5).Value = qte
                    DGVS.Rows(itemLOC).Cells(6).Value = DGVS.Rows(itemLOC).Cells(4).Value - qte

                End If
            Next




            '''''''''''''''''''''''''' ---------------------------- details bon


            Dim dt33 = ta3.GetDataBydate(Now.Date.AddDays(1), Now.Date.AddDays(-1), cbdepot.SelectedValue)
            For j As Integer = 0 To dt33.Rows.Count - 1

                Dim qtein As Double = 0
                qtein = dt33.Rows(j).Item("qte")

                'search for the barcode in dgv2
                Dim i As Integer = 0
                Dim itemLOC As Integer = -1
                For i = 0 To DGVS.Rows.Count - 1
                    If dt33.Rows(j).Item("name") = DGVS.Rows(i).Cells(2).Value Then
                        'item found
                        itemLOC = i
                        Exit For
                    End If
                Next

                'if item no found 
                If itemLOC = -1 Then
                    DGVS.Rows.Add("", dt33.Rows(j).Item("code"), dt33.Rows(j).Item("name"), dt33.Rows(j).Item("unit"), qtein, 0, qtein, "", dt33.Rows(j).Item("depot"))

                Else
                    ' if already exist increase its count
                    Dim qte As Double = 0


                    qte = DGVS.Rows(itemLOC).Cells(4).Value + qtein
                    DGVS.Rows(itemLOC).Cells(4).Value = qte
                    DGVS.Rows(itemLOC).Cells(6).Value = qte - DGVS.Rows(itemLOC).Cells(5).Value


                End If
            Next



            '''''''''''''''''''''--------------------------------------------

            For i = 0 To DGVS.Rows.Count - 1
                Dim sta As New ALMohassinDBDataSetTableAdapters.DetailstockTableAdapter
                Dim sdt = sta.GetDataByname(DGVS.Rows(i).Cells(2).Value, DGVS.Rows(i).Cells(8).Value)
                DGVS.Rows(i).Cells(7).Value = sdt.Rows(0).Item("qte")
                DGVS.Rows(i).Cells(0).Value = sdt.Rows(0).Item(0)
            Next



            TextBox1.Text = "1"
        Catch ex As Exception
            TextBox1.Text = "0"
        End Try

    End Sub

    Private Sub GestionStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ALMohassinDBDataSet.company' table. You can move, or remove it, as needed.
        Me.CompanyTableAdapter.Fill(Me.ALMohassinDBDataSet.company)
        'TODO: This line of code loads data into the 'ALMohassinDBDataSet.Depot' table. You can move, or remove it, as needed.
        Me.DepotTableAdapter.Fill(Me.ALMohassinDBDataSet.Depot)

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try

           If My.Computer.Keyboard.CtrlKeyDown Then
                ChangeValue()
                Exit Sub
            End If

            'Dim ta As New ALMohassinDBDataSetTableAdapters.DetailsStockTableAdapter
            Dim ta2 As New ALMohassinDBDataSetTableAdapters.DetailsFactureTableAdapter
            Dim ta3 As New ALMohassinDBDataSetTableAdapters.DetailsBonTableAdapter
            Dim dt1 As Date = DTP1.Text
            Dim dt2 As Date = DTP2.Text
            DGVS.Rows.Clear()

            Dim dt22 = ta2.GetDataBydate(dt2.AddDays(1), dt1.AddDays(-1), cbdepot.SelectedValue)
            For j As Integer = 0 To dt22.Rows.Count - 1
                Dim qteout As Double = 0
                qteout = dt22.Rows(j).Item("qte")

                'search for the barcode in dgv2
                Dim i As Integer = 0
                Dim itemLOC As Integer = -1
                For i = 0 To DGVS.Rows.Count - 1
                    If dt22.Rows(j).Item("name") = DGVS.Rows(i).Cells(2).Value Then
                        'item found
                        itemLOC = i
                        Exit For
                    End If
                Next

                'if item no found 
                If itemLOC = -1 Then
                    DGVS.Rows.Add("", dt22.Rows(j).Item("code"), dt22.Rows(j).Item("name"), dt22.Rows(j).Item("unit"), 0, qteout, 0 - qteout, "", dt22.Rows(j).Item("depot"), dt22.Rows(j).Item("arid"), dt22.Rows(j).Item("cid"))

                Else
                    ' if already exist increase its count
                    Dim qte As Double = 0

                    qte = DGVS.Rows(itemLOC).Cells(5).Value + qteout
                    DGVS.Rows(itemLOC).Cells(5).Value = qte
                    DGVS.Rows(itemLOC).Cells(6).Value = DGVS.Rows(itemLOC).Cells(4).Value - qte

                End If
            Next

            '''''''''''''''''''''''''' ---------------------------- details bon
            Dim dt33 = ta3.GetDataBydate(dt2.AddDays(1), dt1.AddDays(-1), cbdepot.SelectedValue)
            For j As Integer = 0 To dt33.Rows.Count - 1

                Dim qtein As Double = 0
                qtein = dt33.Rows(j).Item("qte")

                'search for the barcode in dgv2
                Dim i As Integer = 0
                Dim itemLOC As Integer = -1
                For i = 0 To DGVS.Rows.Count - 1
                    If dt33.Rows(j).Item("name") = DGVS.Rows(i).Cells(2).Value Then
                        'item found
                        itemLOC = i
                        Exit For
                    End If
                Next

                'if item no found 
                If itemLOC = -1 Then
                    DGVS.Rows.Add("", dt33.Rows(j).Item("code"), dt33.Rows(j).Item("name"),
                                  dt33.Rows(j).Item("unit"), qtein, 0, qtein, "", dt33.Rows(j).Item("depot"),
                                  dt33.Rows(j).Item("arid"), dt33.Rows(j).Item("cid"))

                Else
                    ' if already exist increase its count
                    Dim qte As Double = 0

                    qte = DGVS.Rows(itemLOC).Cells(4).Value + qtein
                    DGVS.Rows(itemLOC).Cells(4).Value = qte
                    DGVS.Rows(itemLOC).Cells(6).Value = qte - DGVS.Rows(itemLOC).Cells(5).Value
                End If
            Next

            '''''''''''''''''''''--------------------------------------------
            For i = 0 To DGVS.Rows.Count - 1
                Dim sta As New ALMohassinDBDataSetTableAdapters.DetailstockTableAdapter
                Dim sdt = sta.GetDataByids(DGVS.Rows(i).Cells(9).Value, DGVS.Rows(i).Cells(8).Value)
                DGVS.Rows(i).Cells(7).Value = sdt.Rows(0).Item("qte")
                DGVS.Rows(i).Cells(0).Value = sdt.Rows(0).Item(0)
            Next

            TextBox1.Text = "2"
        Catch ex As Exception
            TextBox1.Text = "0"
        End Try

    End Sub

    Public Sub Editstok(ByVal Qten As String, ByVal oldqte As String, ByVal qte1 As String, ByVal qte2 As String, ByVal d As Double)
        Dim MyCon As OleDb.OleDbConnection = Nothing
        Dim MyTRans As OleDb.OleDbTransaction = Nothing
        'start a transaction object

        Try
            MyCon = New OleDb.OleDbConnection(My.Settings.ALMohassinDBConnectionString)
            MyCon.Open()

            MyTRans = MyCon.BeginTransaction

            Dim qte As Double = Double.Parse(oldqte) + (d * (Double.Parse(qte2) - Double.Parse(qte1)))

            Dim SQL As String = "update Detailstock set qte=:1  where arid=:2 and dpid=:3"
            Dim CMD3 As New OleDb.OleDbCommand
            CMD3.Connection = MyCon
            CMD3.Transaction = MyTRans
            CMD3.CommandText = SQL
            CMD3.Parameters.AddWithValue(":1", qte)
            CMD3.Parameters.AddWithValue(":2", DGVS.SelectedRows(0).Cells(0).Value)
            CMD3.Parameters.AddWithValue(":2", Qten)
            CMD3.ExecuteNonQuery()
            CMD3.Dispose()
            'all will save the changes
            MyTRans.Commit()

            ''close all 
            MyTRans.Dispose()
            MyCon.Close()
            MyCon.Dispose()
            ''''
        Catch ex As Exception
            If MyTRans IsNot Nothing Then
                MyTRans.Rollback()
            End If
            If MyCon IsNot Nothing Then
                If MyCon.State = ConnectionState.Open Then
                    MyCon.Close()
                End If

            End If

            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            Dim edtstk As New EditStock
            If TextBox1.Text = "0" Then
                Exit Sub
                ' 'search for today
            ElseIf TextBox1.Text = "1" Then
                edtstk.TextBox1.Tag = DGVS.SelectedRows(0).Cells(4).Value
                Dim ta As New ALMohassinDBDataSetTableAdapters.DetailsStockTableAdapter
                Dim dt = ta.GetDataforedit(Now.Date.AddDays(1), Now.Date.AddDays(-1), cbdepot.SelectedValue, DGVS.SelectedRows(0).Cells(0).Value, "IN")
                edtstk.DGVS.Rows.Clear()
                Dim comta As New ALMohassinDBDataSetTableAdapters.companyTableAdapter
                Dim dpta As New ALMohassinDBDataSetTableAdapters.DepotTableAdapter

                For i As Integer = 0 To dt.Rows.Count - 1
                    edtstk.DGVS.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("codebar"), dt.Rows(i).Item("name"), dt.Rows(i).Item("unit"), dt.Rows(i).Item("qte"), dt.Rows(i).Item("dpid"), dt.Rows(i).Item("date"))
                 
                    Dim dpdt = dpta.GetDataByid(dt.Rows(i).Item("dpid"))
                    edtstk.DGVS.Rows(i).Cells(5).Value = dpdt.Rows(0).Item("name").ToString
                Next

                If edtstk.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim dpid As Integer
                    Dim ddt = dpta.GetDataByname(edtstk.DGVS.Rows(0).Cells(5).Value)
                    dpid = ddt.Rows(0).Item(0)

                    Editstok(dpid, DGVS.SelectedRows(0).Cells(7).Value, DGVS.SelectedRows(0).Cells(4).Value, edtstk.TextBox1.Text, 1)
                    Button4_Click(Nothing, Nothing)
                End If
                'search by date
            ElseIf TextBox1.Text = "2" Then
                edtstk.TextBox1.Tag = DGVS.SelectedRows(0).Cells(4).Value
                Dim dt1 As Date = DTP1.Text
                Dim dt2 As Date = DTP2.Text

                Dim ta As New ALMohassinDBDataSetTableAdapters.DetailsStockTableAdapter
                Dim dt = ta.GetDataforedit(dt2.AddDays(1), dt1.AddDays(-1), cbdepot.SelectedValue, DGVS.SelectedRows(0).Cells(0).Value, "IN")
                edtstk.DGVS.Rows.Clear()
                Dim comta As New ALMohassinDBDataSetTableAdapters.companyTableAdapter
                Dim dpta As New ALMohassinDBDataSetTableAdapters.DepotTableAdapter

                For i As Integer = 0 To dt.Rows.Count - 1
                    edtstk.DGVS.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("codebar"), dt.Rows(i).Item("name"), dt.Rows(i).Item("unit"), dt.Rows(i).Item("qte"), dt.Rows(i).Item("dpid"), dt.Rows(i).Item("date"))
                  
                    Dim dpdt = dpta.GetDataByid(dt.Rows(i).Item("dpid"))
                    edtstk.DGVS.Rows(i).Cells(5).Value = dpdt.Rows(0).Item("name").ToString
                Next
                If edtstk.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim dpid As Integer
                    Dim ddt = dpta.GetDataByname(edtstk.DGVS.Rows(0).Cells(5).Value)
                    dpid = ddt.Rows(0).Item(0)

                    Editstok(dpid, DGVS.SelectedRows(0).Cells(7).Value, DGVS.SelectedRows(0).Cells(4).Value, edtstk.TextBox1.Text, 1)

                    Button5_Click(Nothing, Nothing)
                End If
            Else
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            Dim edtstk As New EditStock
            If TextBox1.Text = "0" Then
                Exit Sub
                ' 'search for today
            ElseIf TextBox1.Text = "1" Then
            
                edtstk.TextBox1.Tag = DGVS.SelectedRows(0).Cells(5).Value
                Dim ta As New ALMohassinDBDataSetTableAdapters.DetailsStockTableAdapter
                Dim dt = ta.GetDataforedit(Now.Date.AddDays(1), Now.Date.AddDays(-1), cbdepot.SelectedValue, DGVS.SelectedRows(0).Cells(0).Value, "OUT")
                edtstk.DGVS.Rows.Clear()
                Dim comta As New ALMohassinDBDataSetTableAdapters.companyTableAdapter
                Dim dpta As New ALMohassinDBDataSetTableAdapters.DepotTableAdapter

                For i As Integer = 0 To dt.Rows.Count - 1
                    edtstk.DGVS.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("codebar"),
                                         dt.Rows(i).Item("name"), dt.Rows(i).Item("unit"),
                                         dt.Rows(i).Item("qte"), dt.Rows(i).Item("dpid"),
                                         dt.Rows(i).Item("date"))
                    Dim dpdt = dpta.GetDataByid(dt.Rows(i).Item("dpid"))
                    edtstk.DGVS.Rows(i).Cells(5).Value = dpdt.Rows(0).Item("name").ToString

                Next

                If edtstk.ShowDialog = Windows.Forms.DialogResult.OK Then

                    Dim dpid As Integer
                    Dim ddt = dpta.GetDataByname(edtstk.DGVS.Rows(0).Cells(5).Value)
                    dpid = ddt.Rows(0).Item(0)


                    Editstok(dpid, DGVS.SelectedRows(0).Cells(7).Value, DGVS.SelectedRows(0).Cells(5).Value, edtstk.TextBox1.Text, -1)

                    Button4_Click(Nothing, Nothing)
                End If

                'search by date
            ElseIf TextBox1.Text = "2" Then


                edtstk.TextBox1.Tag = DGVS.SelectedRows(0).Cells(5).Value
                Dim dt1 As Date = DTP1.Text
                Dim dt2 As Date = DTP2.Text

                Dim ta As New ALMohassinDBDataSetTableAdapters.DetailsStockTableAdapter
                Dim dt = ta.GetDataforedit(dt2.AddDays(1), dt1.AddDays(-1), cbdepot.SelectedValue, DGVS.SelectedRows(0).Cells(0).Value, "OUT")
                edtstk.DGVS.Rows.Clear()
                Dim comta As New ALMohassinDBDataSetTableAdapters.companyTableAdapter
                Dim dpta As New ALMohassinDBDataSetTableAdapters.DepotTableAdapter

                For i As Integer = 0 To dt.Rows.Count - 1
                    edtstk.DGVS.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("codebar"), dt.Rows(i).Item("name"), dt.Rows(i).Item("unit"), dt.Rows(i).Item("qte"), dt.Rows(i).Item("dpid"), dt.Rows(i).Item("date"))
            
                    Dim dpdt = dpta.GetDataByid(dt.Rows(i).Item("dpid"))
                    edtstk.DGVS.Rows(i).Cells(5).Value = dpdt.Rows(0).Item("name").ToString

                Next

                If edtstk.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim dpid As Integer
                    Dim ddt = dpta.GetDataByname(edtstk.DGVS.Rows(0).Cells(5).Value)
                    dpid = ddt.Rows(0).Item(0)


                    Editstok(dpid, DGVS.SelectedRows(0).Cells(7).Value, DGVS.SelectedRows(0).Cells(5).Value, edtstk.TextBox1.Text, -1)

                    Button5_Click(Nothing, Nothing)
                End If
            Else
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If My.Computer.Keyboard.CtrlKeyDown Then
            Dim nmdg As New num
            If nmdg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim tableName As String = "Detailstock"
                c.DeleteRecords(tableName)

                Dim params As New Dictionary(Of String, Object)
                Dim where As New Dictionary(Of String, Object)

                For i As Integer = 0 To DGVS.Rows.Count - 1
                    params.Clear()
                    where.Clear()

                    If DGVS.Rows(i).Cells(10).Value = 0 Then
                        where.Add("arid", DGVS.Rows(i).Cells(9).Value)
                        Dim elements As String = ""
                        Try
                            elements = c.SelectByScalar("Article", "elements", where)
                            If elements = "" Or IsDBNull(elements) Then Continue For

                        Dim DPID As String = c.SelectByScalar("Article", "depot", where)
                        elements = elements.Substring(1, elements.Length - 2)
                        Dim eleArr As String() = elements.Split("*")
                            For a As Integer = 0 To eleArr.Length - 1

                                Dim arid As Integer = CInt(CStr(eleArr(a).Split("&")(0)).Split("|")(1))
                                Dim qte As String = CStr(eleArr(a).Split("&")(1))
                                where.Clear()
                                where.Add("arid", arid)
                                where.Add("dpid", DPID)

                                Dim CloseBoxQte As Double = c.SelectByScalar("Detailstock", "qte", where)

                                CloseBoxQte -= qte

                                where.Clear()
                                params.Clear()

                                params.Add("qte", qte)

                                where.Add("arid", arid)
                                where.Add("dpid", DPID)

                                If c.UpdateRecord("Detailstock", params, where) = 0 Then
                                    params.Clear()
                                    where.Clear()

                                    where.Add("arid", arid)
                                    Dim cid As String = c.SelectByScalar("Article", "cid", where)
                                    Dim unit As String = c.SelectByScalar("Article", "unite", where)

                                    Try
                                        params.Add("qte", CloseBoxQte)
                                        params.Add("arid", arid)
                                        params.Add("dpid", DPID)
                                        params.Add("cid", cid)
                                        params.Add("unit", unit)

                                        If IsNothing(cid) Or IsNothing(unit) Then Continue For
                                        c.InsertRecord("Detailstock", params)
                                    Catch ex As Exception

                                    End Try

                                End If
                                params.Clear()
                                where.Clear()
                            Next
                  Catch ex As Exception
                    Continue For
                End Try
                        Continue For
                    End If

                    If Not IsNumeric(DGVS.Rows(i).Cells(6).Value) Then Continue For
                    params.Add("arid", DGVS.Rows(i).Cells(9).Value)
                    params.Add("dpid", cbdepot.SelectedValue)
                    params.Add("qte", DGVS.Rows(i).Cells(6).Value)
                    params.Add("cid", DGVS.Rows(i).Cells(10).Value)
                    params.Add("unit", DGVS.Rows(i).Cells(3).Value)
                    c.InsertRecord(tableName, params)

                Next
                MsgBox("well done")
            End Using
        End If
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Dim m As Integer = 0
    Dim l As Integer = 170
    Private Sub PrintDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage

        Dim a As Double = Form1.txtScale.Text
        Dim pn As New Pen(Brushes.Black, 0.0F)
        Dim fnt As New Font("Arial", "10")

        Dim wd As Integer = Int((100 + 80 + 95 + 90 + 75 + 179) * a)
        Dim ht As Integer = 20 + Form1.txtfntsize.Text

        e.Graphics.FillRectangle(Brushes.Gray, New Rectangle(60 * a, l, 110 * a, 10 + Form1.txtfntsize.Text))
        '  e.Graphics.DrawRectangle(pn, New Rectangle(100, 100, DGV1.Columns(0).Width, DGV1.Rows(0).Height))
        e.Graphics.DrawString("كمية المخزون", fnt, Brushes.White, 60 * a, l + 5)

        e.Graphics.FillRectangle(Brushes.Gray, New Rectangle(170 * a, l, 120 * a, 10 + Form1.txtfntsize.Text))
        '   e.raphics.DrawRectangle(pn, New Rectangle(100, 100, DGV1.Columns(0).Width, DGV1.Rows(0).Height))
        e.Graphics.DrawString("ك.الاستخراج", fnt, Brushes.White, 173 * a, l + 5)

        e.Graphics.FillRectangle(Brushes.Gray, New Rectangle(285 * a, l, 115 * a, 10 + Form1.txtfntsize.Text))
        '  e.Graphics.DrawRectangle(pn, New Rectangle(100, 100, DGV1.Columns(0).Width, DGV1.Rows(0).Height))
        e.Graphics.DrawString("ك.الادخال", fnt, Brushes.White, 290 * a, l + 5)

        e.Graphics.FillRectangle(Brushes.Gray, New Rectangle(400 * a, l, 75 * a, 10 + Form1.txtfntsize.Text))
        ' e.Graphics.DrawRectangle(pn, New Rectangle(100, 100, DGV1.Columns(0).Width, DGV1.Rows(0).Height))
        e.Graphics.DrawString("الوحدة", fnt, Brushes.White, 405 * a, l + 5)

        e.Graphics.FillRectangle(Brushes.Gray, New Rectangle(475 * a, l, 200 * a, 10 + Form1.txtfntsize.Text))
        ' e.Graphics.DrawRectangle(pn, New Rectangle(100, 100, DGV1.Columns(0).Width, DGV1.Rows(0).Height))
        e.Graphics.DrawString("الاسم", fnt, Brushes.White, 500 * a, l + 5)

        e.Graphics.FillRectangle(Brushes.Gray, New Rectangle(680 * a, l, 110 * a, 10 + Form1.txtfntsize.Text))
        ' e.Graphics.DrawRectangle(pn, New Rectangle(100, 100, DGV1.Columns(0).Width, DGV1.Rows(0).Height))
        e.Graphics.DrawString("رمز التعريف", fnt, Brushes.White, 683 * a, l + 5)

    


        While m < DGVS.Rows.Count
            If m = 0 Then
                Try
                    If Form1.txttitlestart.Text = "" Or Not IsNumeric(Form1.txttitlestart.Text) Then
                        Form1.txttitlestart.Text = "300"
                    End If


                    e.Graphics.DrawString(Form1.txttitle.Text, New Font(fnt, FontStyle.Bold), Brushes.Black, Form1.txttitlestart.Text, 70) '+ Integer.Parse(txttitle.Tag))

                Catch ex As Exception

                End Try


                e.Graphics.DrawString(" : المستودع", fnt, Brushes.Black, 615 * a, 110) '+ Integer.Parse(txttitle.Tag))
                e.Graphics.DrawString(":نوع الاستعلام", fnt, Brushes.Black, 645 * a, 130) '+ Integer.Parse(txttitle.Tag))
                e.Graphics.DrawString(": التاريخ", fnt, Brushes.Black, 635 * a, 150) '+ Integer.Parse(txttitle.Tag))

                Dim dpta As New ALMohassinDBDataSetTableAdapters.DepotTableAdapter
                Dim dpdt = dpta.GetDataByid(DGVS.Rows(0).Cells(8).Value)
                Dim dtt As String = Format(Now.Date, "dd-MM-yyyy").ToString
                Dim tt As String = ""
                If TextBox1.Text = "1" Then
                    tt = " الاستعلام لهذا اليوم"
                ElseIf TextBox1.Text = "2" Then
                    tt = " الاستعلام حسب المدة الزمنية"
                    Dim dt1 As Date = DTP1.Text
                    Dim dt2 As Date = DTP2.Text
                    dtt = "من  " & Format(dt1, "dd-mm-yyyy").ToString & "الى  " & Format(dt2, "dd-mm-yyyy").ToString
                ElseIf TextBox1.Text = "3" Then
                    tt = " الاستعلام حسب الموزيعون"
                    dtt = "-"
                ElseIf TextBox1.Text = "4" Then
                    tt = " الاستعلام حسب رقم الفاتورة"
                    dtt = "-"
                End If

                e.Graphics.DrawString(dpdt.Rows(0).Item("name").ToString, fnt, Brushes.Black, 450 * a, 110) ' + Integer.Parse(txttitle.Tag))
                e.Graphics.DrawString(tt, fnt, Brushes.Black, 450 * a, 130) '+ Integer.Parse(txttitle.Tag))
                e.Graphics.DrawString(dtt, fnt, Brushes.Black, 450 * a, 150) ' + Integer.Parse(txttitle.Tag))

            End If

            If l > e.MarginBounds.Height Then
                l = 100
                e.HasMorePages = True
                Return

            End If




            l = l + 10 + Form1.txtfntsize.Text
            If m Mod 2 = 0 Then
                e.Graphics.FillRectangle(Brushes.LightCyan, New Rectangle(60 * a, l, wd, 10 + Form1.txtfntsize.Text))
            End If


            e.Graphics.DrawString(DGVS.Rows(m).Cells(7).Value, New Font(fnt, FontStyle.Bold), Brushes.Black, 60 * a, l + 3)

            e.Graphics.DrawString(DGVS.Rows(m).Cells(5).Value, fnt, Brushes.Black, 175 * a, l + 3)
            e.Graphics.DrawString(DGVS.Rows(m).Cells(4).Value, fnt, Brushes.Black, 290 * a, l + 3)
            e.Graphics.DrawString(DGVS.Rows(m).Cells(3).Value, fnt, Brushes.Black, 410 * a, l + 3)
            Dim prdname As String = DGVS.Rows(m).Cells(2).Value
            e.Graphics.DrawString(prdname, fnt, Brushes.Black, (475 * a) + (160 * a - Int(prdname.Length * 20 / 3.75)), l + 3)
            e.Graphics.DrawString(DGVS.Rows(m).Cells(1).Value, fnt, Brushes.Black, 690 * a, l + 3)
            m += 1
        End While

       
        l = 170
        m = 0

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        PrintPrev.ShowDialog()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Try
            'impimer ticket
            'print button


            If Form1.txttimp.Text <> "" Then
                'select the printer
                Try
                    PrintDoc.PrinterSettings.PrinterName = Form1.txttimp.Text
                    PrintDoc.Print()

                Catch ex As Exception

                    If PrintDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                        PrintDoc.PrinterSettings.PrinterName = PrintDlg.PrinterSettings.PrinterName
                        PrintDoc.Print()
                    End If


                End Try



            Else
                MsgBox("لم تقم بإختبار اسم الطابعة ", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub


End Class