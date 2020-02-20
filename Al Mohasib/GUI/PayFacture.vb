Public Class PayFacture
    Public fctid As Integer = 0
    Public clid As Integer = 0
    Public Avance As Double = 0
    Public total As Double
    Public isSell As Boolean
    Public editMode As Boolean
    Public clientName As String

    Private _nm As String
    Private _hasManyPayement As Boolean
    Private _allowSelection As Boolean

    'properties
    Public Property haManyPayement() As Boolean
        Get
            Return _hasManyPayement
        End Get
        Set(ByVal value As Boolean)
            _hasManyPayement = value
            'plSide.Visible = False
            If isSell = True And value = True And editMode = True Then
                plSide.Visible = value
                'Me.Width += 200
                DGV.Width = 210
                LaodUnPaidFactures()
            End If
        End Set
    End Property
    Public ReadOnly Property totalSelectionner() As Double
        Get
            Dim tt As Double = 0
            For i As Integer = 0 To DGV.Rows.Count - 1
                'If DGV.Rows(i).Cells(0).Value = True Then
                tt += CDbl(DGV.Rows(i).Cells(2).Value) - CDbl(DGV.Rows(i).Cells(3).Value)
                'End If
            Next
            tt += total - Avance
            Return tt
        End Get
    End Property
    Private Property allowSelection() As Boolean
        Get
            Return _allowSelection
        End Get
        Set(ByVal value As Boolean)
            _allowSelection = value
            DGV.Columns(0).Visible = value
            _nm &= ""

            For i As Integer = 0 To DGV.Rows.Count - 1
                DGV.Rows(i).Cells(0).Value = False
                _nm &= "|" & DGV.SelectedRows(0).Cells(1).Value
            Next

            BtTotal.Text = String.Format("{0:F}", totalSelectionner)
            'BtTotal.Text = totalSelectionner
            '_nm = fctid
        End Set
    End Property

    'subs
    Public Sub LaodUnPaidFactures()
        plSide.Visible = True
        btPrint.Enabled = False

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim tableName As String = "Facture"
            If isSell = False Then tableName = "Bon"

            DGV.Rows.Clear()

            Dim params As New Dictionary(Of String, Object)
            params.Add("clid", clid)
            params.Add("payed", False)
            params.Add("admin", True)

            Dim dt = c.SelectDataTable(tableName, {"*"}, params)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(i).Item(0) <> fctid Then
                        DGV.Rows.Add(False, dt.Rows(i).Item(0),
                                               dt.Rows(i).Item("total"),
                                               dt.Rows(i).Item("avance"),
                                               dt.Rows(i).Item("beInFacture"))
                    End If
                Next
            End If
        End Using
    End Sub
    Public Sub LaoddetailPayment(ByVal pid As Integer)
        allowSelection = False
        btPrint.Enabled = True

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim tableName As String = "CompanyPayment"
            Dim tName As String = "Bon"
            Dim fld As String = "bonid"
            If isSell Then
                tableName = "Payment"
                tName = "Facture"
                fld = "fctid"
            End If


            DGV.Rows.Clear()

            Dim params As New Dictionary(Of String, Object)
            params.Add("name", "@" & pid)
            Dim dt2 = c.SelectDataTable(tableName, {"*"}, params)

            If dt2.Rows.Count > 0 Then
                For i As Integer = 0 To dt2.Rows.Count - 1
                    params.Clear()
                    params.Add(fld, dt2.Rows(i).Item(fld))

                    Dim dt = c.SelectDataTable(tName, {"*"}, params)

                    If dt.Rows.Count > 0 Then
                        DGV.Rows.Add(False, dt.Rows(0).Item(0),
                                               dt.Rows(0).Item("total"),
                                               dt.Rows(0).Item("avance"),
                                               dt.Rows(0).Item("beInFacture"))
                    End If
                Next
            End If
        End Using
    End Sub
    Public Sub AddPayement(ByVal name As String, ByVal clid As String, ByVal montant As Double,
                                ByVal way As String, ByVal dte As Date, ByVal num As String,
                                ByVal isSell As Boolean, ByRef dt As DataTable)

        Dim tableName As String = "CompanyPayment"
        Dim tName As String = "Bon"
        Dim fld As String = "bonid"
        Dim cl As String = "comid"
        If isSell Then
            tableName = "Payment"
            tName = "Facture"
            fld = "fctid"
            cl = "clid"
        End If

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            params.Add("name", name)
            params.Add(cl, clid)
            params.Add("montant", montant)
            params.Add("way", way)
            params.Add("date", Format(dte, "dd-MM-yyyy"))
            params.Add("Num", num)
            params.Add(fld, fctid)
            params.Add("writer", CStr(Form1.adminName))

            Dim Pid = c.InsertRecord(tableName, params, True)

            Dim tt As Double = (Avance + montant) - total

            If tt > 0 And haManyPayement Then

                params.Clear()

                params.Add("montant", tt * -1)
                params.Add("name", "@" & Pid)
                params.Add(cl, clid)
                params.Add("way", way & " - [Rest]")
                params.Add("date", Format(dte, "dd-MM-yyyy"))
                params.Add("Num", "[" & montant & "]" & num)
                params.Add(fld, fctid)
                params.Add("writer", CStr(Form1.adminName))

                c.InsertRecord(tableName, params)
                params.Clear()

                For i As Integer = 0 To DGV.Rows.Count - 1
                    'If DGV.Rows(i).Cells(0).Value = True Then
                    Dim id As Integer = CInt(DGV.Rows(i).Cells(1).Value)
                    Dim a As Double = CDbl(DGV.Rows(i).Cells(3).Value)
                    Dim r As Double = CDbl(DGV.Rows(i).Cells(2).Value) - CDbl(DGV.Rows(i).Cells(3).Value)
                    Dim ispayed As Boolean = False
                    If tt >= r Then
                        ispayed = True
                        params.Add("montant", r)
                        a += r
                        tt -= r
                    Else
                        ispayed = False
                        params.Add("montant", tt)
                        a += tt
                        tt = 0
                    End If

                    params.Add("name", "@" & Pid)
                    params.Add(cl, clid)
                    params.Add("way", way & " - [" & montant & "]")
                    params.Add("date", Format(dte, "dd-MM-yyyy"))
                    params.Add("Num", "[" & fctid & "] - " & num)
                    params.Add(fld, id)
                    params.Add("writer", CStr(Form1.adminName))

                    c.InsertRecord(tableName, params)
                    params.Clear()

                    where.Add(fld, id)
                    params.Add("avance", a)
                    params.Add("payed", ispayed)

                    c.UpdateRecord(tName, params, where)
                    params.Clear()
                    where.Clear()

                    If tt = 0 Then Exit For
                    'End If
                Next
            End If
            where.Add(fld, fctid)
            dt = c.SelectDataTable(tableName, {"*"}, where)
            where = Nothing
            params = Nothing
        End Using
        LaodUnPaidFactures()
    End Sub
    Public Sub EditPayement(ByVal nm As String, ByVal oldMontant As Double, ByVal montant As Double,
                                ByVal way As String, ByVal dte As Date, ByVal num As String,
                                ByVal pid As Integer, ByVal isSell As Boolean, ByRef dt As DataTable)

        Dim tableName As String = "CompanyPayment"
        Dim tName As String = "Bon"
        Dim fld As String = "bonid"
        Dim cl As String = "comid"
        If isSell Then
            tableName = "Payment"
            tName = "Facture"
            fld = "fctid"
            cl = "clid"
        End If

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            If isSell Then
                where.Add("Pid", pid)
            Else
                where.Add("PBid", pid)
            End If

            params.Add("montant", montant)
            params.Add("way", way)
            params.Add("date", Format(dte, "dd-MM-yyyy"))
            params.Add("Num", num)
            params.Add("writer", CStr(Form1.adminName))

            c.UpdateRecord(tableName, params, where)

            params.Clear()
            where.Clear()

            params.Add("name", "@" & pid)

            Dim dt2 = c.SelectDataTable(tableName, {"*"}, params)
            If dt2.Rows.Count > 0 Then
                For i As Integer = 0 To dt2.Rows.Count - 1
                    If isSell Then
                        where.Add("fctid", dt2.Rows(i).Item("fctid"))
                    Else
                        where.Add("bonid", dt2.Rows(i).Item("bonid"))
                    End If

                    Dim avc As Double = c.SelectByScalar(tName, "avance", where)
                    Dim ttl As Double = c.SelectByScalar(tName, "total", where)

                    avc -= dt2.Rows(i).Item("montant")

                    Dim ispayed As Double = False
                    If dt2.Rows(i).Item("montant") <= 0 Then ispayed = True

                    params.Clear()

                    params.Add("avance", avc)
                    params.Add("payed", ispayed)

                    c.UpdateRecord(tName, params, where)
                    params.Clear()
                    where.Clear()
                Next

                params.Add("name", "@" & pid)
                c.DeleteRecords(tableName, params)
            End If


            Dim tt As Double = (Avance + montant) - total - oldMontant

            If editMode = True And tt > 0 And way <> "Cache" And haManyPayement Then
                params.Clear()
                where.Clear()

                params.Add("montant", tt * -1)
                params.Add("name", "@" & pid)
                params.Add(cl, clid)
                params.Add("way", way & " - [Rest]")
                params.Add("date", Format(dte, "dd-MM-yyyy"))
                params.Add("Num", "[" & montant & "]" & num)
                params.Add(fld, fctid)
                params.Add("writer", CStr(Form1.adminName))

                c.InsertRecord(tableName, params)
                params.Clear()

                Dim ids As String() = nm.Split("|")


                For i As Integer = 0 To ids.Length - 1

                    Dim id As Integer = CInt(ids(i))


                    If isSell Then
                        where.Add("fctid", id)
                    Else
                        where.Add("bonid", id)
                    End If

                    Dim a As Double = c.SelectByScalar(tName, "avance", where)
                    Dim t As Double = c.SelectByScalar(tName, "total", where)
                    Dim r As Double = t - a

                    Dim ispayed As Boolean = False
                    If tt >= r Then
                        ispayed = True
                        params.Add("montant", r)
                        a += r
                        tt -= r
                    Else
                        ispayed = False
                        params.Add("montant", tt)
                        a += tt
                        tt = 0
                    End If

                    params.Add("name", "@" & pid)
                    params.Add(cl, clid)
                    params.Add("way", way & " - [" & montant & "]")
                    params.Add("date", Format(dte, "dd-MM-yyyy"))
                    params.Add("Num", "[" & fctid & "] - " & num)
                    params.Add(fld, id)
                    params.Add("writer", CStr(Form1.adminName))

                    c.InsertRecord(tableName, params)
                    params.Clear()

                    'where.Add(fld, id)
                    params.Add("avance", a)
                    params.Add("payed", ispayed)

                    c.UpdateRecord(tName, params, where)
                    params.Clear()
                    where.Clear()

                    If tt = 0 Then Exit For
                Next
            End If
            where.Add(fld, fctid)
            dt = c.SelectDataTable(tableName, {"*"}, where)
            where = Nothing
            params = Nothing
        End Using
        LaodUnPaidFactures()
    End Sub

    Private Sub PayFacture_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If fctid = 0 Then DialogResult = Windows.Forms.DialogResult.Cancel

        btcancel_Click(Nothing, Nothing)
        DGVP.Rows.Clear()
        Avance = 0
        Dim dt As DataTable
        Try
            If isSell Then
                Dim ta As New ALMohassinDBDataSetTableAdapters.PaymentTableAdapter
                dt = ta.GetDataByfctid(fctid)
            Else
                Dim ta As New ALMohassinDBDataSetTableAdapters.CompanyPaymentTableAdapter
                dt = ta.GetDataBybonid(fctid)
            End If


            For i As Integer = 0 To dt.Rows.Count - 1
                DGVP.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("montant"), dt.Rows(i).Item("way"),
                              dt.Rows(i).Item("Num"), dt.Rows(i).Item("name"))
                Avance += CDbl(dt.Rows(i).Item("montant"))
            Next

            'If editMode Then LaodUnPaidFactures()
            LaodUnPaidFactures()
            allowSelection = Form1.cbMultiPayemnt.Checked
        Catch x As Exception
        End Try
    End Sub
    Private Sub btcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcon.Click
        'validation
        ''empty field
        If txtmontant.text.Trim = "" Then
            txtmontant.Focus()
            Exit Sub
        End If

        Dim _dte As Date = Now.Date
        If cbway.SelectedItem = "Effet (LC)" Then _dte = CDate(dtpech.Text)

        Dim _num As String = txtnum.text
        If _num.Contains("[") Then _num = _num.Split("[")(0)
        _num &= " [" & dtpech.Text & " ]"

        Dim _nm As String = fctid
        For i As Integer = 0 To DGV.Rows.Count - 1
            If DGV.Rows(i).Cells(0).Value = True Then
                _nm &= "|" & DGV.Rows(i).Cells(1).Value
            End If
        Next

        Dim dt As DataTable = Nothing

        ' addddd
        If btcon.Tag = "0" Then
            AddPayement(_nm, clid, CDbl(txtmontant.text), cbway.SelectedItem, _dte, _num, isSell, dt)
            'updateeee
        Else
            EditPayement(_nm, CDbl(txtmontant.Tag), CDbl(txtmontant.text), cbway.SelectedItem, _dte,
                         _num, CInt(btcon.Tag), isSell, dt)
        End If


        'fill payment

        DGVP.Rows.Clear()
        Avance = 0

        For i As Integer = 0 To dt.Rows.Count - 1
            DGVP.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("montant"), dt.Rows(i).Item("way"),
                          dt.Rows(i).Item("Num"), dt.Rows(i).Item("name"))
            Avance += CDbl(dt.Rows(i).Item("montant"))
        Next

        For i As Integer = 0 To DGVP.Rows.Count - 1
            If DGVP.Rows(i).Cells(4).Value.ToString.Contains("@") Then
                DGVP.Rows(i).DefaultCellStyle.BackColor = Color.BurlyWood
            End If
        Next

        If isSell Then
            Dim ta As New ALMohassinDBDataSetTableAdapters.FactureTableAdapter
            ta.UpdateAvc(Avance, fctid)
        Else
            Dim ta As New ALMohassinDBDataSetTableAdapters.BonTableAdapter
            ta.UpdateAvc(Avance, fctid)
        End If

        btcancel_Click(Nothing, Nothing)

        If haManyPayement Then DGV.Columns(0).Visible = False
        DGVP.ClearSelection()
    End Sub
    Private Sub btcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcancel.Click
        txtnum.text = ""
        txtmontant.text = ""
        txtmontant.Tag = ""
        cbway.SelectedItem = "Cache"
        btcon.Tag = "0"
        GroupBox1.Visible = False
        allowSelection = False

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DGVP.SelectedRows.Count = 0 Then Exit Sub
        If DGVP.SelectedRows(0).Cells(4).Value.ToString.Contains("@") Then Exit Sub

        txtmontant.text = DGVP.SelectedRows(0).Cells(1).Value.ToString
        txtmontant.Tag = DGVP.SelectedRows(0).Cells(1).Value.ToString
        txtnum.text = DGVP.SelectedRows(0).Cells(3).Value.ToString
        cbway.Text = DGVP.SelectedRows(0).Cells(2).Value.ToString
        btcon.Tag = DGVP.SelectedRows(0).Cells(0).Value.ToString
        GroupBox1.Visible = True
        _nm = DGVP.SelectedRows(0).Cells(4).Value
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim rest As Decimal = total
            For i As Integer = 0 To DGVP.Rows.Count - 1
                rest = rest - DGVP.Rows(i).Cells(1).Value
            Next
            Dim dt As DataTable

            If isSell Then
                Dim ta As New ALMohassinDBDataSetTableAdapters.PaymentTableAdapter
                ta.Insert("facture", clid, rest, "كاش", Now.Date, "0", fctid, Form1.admin)
                dt = ta.GetDataByfctid(fctid)
            Else
                Dim ta As New ALMohassinDBDataSetTableAdapters.CompanyPaymentTableAdapter
                ta.Insert("facture", clid, rest, "كاش", Now.Date, "0", fctid, Form1.admin, Now.Date)
                dt = ta.GetDataBybonid(fctid)
            End If

            DGVP.Rows.Clear()
            Avance = 0
            For i As Integer = 0 To dt.Rows.Count - 1
                DGVP.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("montant"), dt.Rows(i).Item("way"), dt.Rows(i).Item("Num"))
                Avance += CDbl(dt.Rows(i).Item("montant"))
            Next
            'update facture
            If isSell Then
                Dim ta As New ALMohassinDBDataSetTableAdapters.FactureTableAdapter
                ta.UpdateAvc(Avance, fctid)
            Else
                Dim ta As New ALMohassinDBDataSetTableAdapters.BonTableAdapter
                ta.UpdateAvc(Avance, fctid)
            End If
            'end dialoge
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch x As Exception
            MsgBox(x.Message)
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Sub Button35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button35.Click
        btcancel_Click(Nothing, Nothing)
        GroupBox1.Visible = True
        allowSelection = True
        LaodUnPaidFactures()
    End Sub

    Private Sub DGVP_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVP.CellClick

        'If DGVP.Rows.Count = 0 Then Exit Sub
        'If DGVP.SelectedRows.Count = 0 Then Exit Sub

        'If My.Computer.Keyboard.CtrlKeyDown Then

        '    If DGVP.SelectedRows(0).Cells(2).Value <> "Cheque" And DGVP.SelectedRows(0).Cells(2).Value <> "Traite" Then
        '        Exit Sub
        '    End If

        '    Try
        '        Dim dt As DataTable
        '        Dim _dte As Date = Now.Date
        '        Dim mnt As Double = DGVP.SelectedRows(0).Cells(1).Value * -1
        '        Dim txt As String = "Le rejet de " & DGVP.SelectedRows(0).Cells(2).Value
        '        txt &= " [" & DGVP.SelectedRows(0).Cells(3).Value & "]"

        '        If isSell Then
        '            Dim ta As New ALMohassinDBDataSetTableAdapters.PaymentTableAdapter
        '            ta.Insert("@facture", clid, mnt, "REJETE", _dte, txt, fctid, Form1.admin)
        '            dt = ta.GetDataByfctid(fctid)
        '        Else
        '            Dim ta As New ALMohassinDBDataSetTableAdapters.CompanyPaymentTableAdapter
        '            ta.Insert("@facture", clid, mnt, "REJETE", _dte, txt, fctid, Form1.admin, _dte)
        '            dt = ta.GetDataBybonid(fctid)
        '        End If


        '        DGVP.Rows.Clear()
        '        Avance = 0
        '        For i As Integer = 0 To dt.Rows.Count - 1
        '            DGVP.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("montant"), dt.Rows(i).Item("way"),
        '                          dt.Rows(i).Item("Num"), dt.Rows(i).Item("name"))
        '            Avance += CDbl(dt.Rows(i).Item("montant"))
        '        Next
        '        If isSell Then
        '            Dim ta As New ALMohassinDBDataSetTableAdapters.FactureTableAdapter
        '            ta.UpdateAvc(Avance, fctid)
        '        Else
        '            Dim ta As New ALMohassinDBDataSetTableAdapters.BonTableAdapter
        '            ta.UpdateAvc(Avance, fctid)
        '        End If

        '        btcancel_Click(Nothing, Nothing)
        '    Catch x As Exception
        '        MsgBox(x.Message)
        '    End Try
        'Else
        'LaoddetailPayment(DGVP.SelectedRows(0).Cells(0).Value)
        'End If
        btPrint.Enabled = True
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellClick
        If allowSelection = False Then Exit Sub
        _nm = ""

        'Dim a As Boolean = False
        'If CBool(DGV.SelectedRows(0).Cells(0).Value) = False Then a = True
        'DGV.SelectedRows(0).Cells(0).Value = a

        For i As Integer = 0 To DGV.Rows.Count - 1
            'If CBool(DGV.SelectedRows(0).Cells(0).Value) = True Then
            _nm &= "|" & DGV.SelectedRows(0).Cells(1).Value
        Next
        BtTotal.Text = String.Format("{0:F}", totalSelectionner)

    End Sub
    Private Sub BtTotal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtTotal.Click
        LaodUnPaidFactures()
    End Sub
    Private Sub cbway_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbway.SelectedIndexChanged
        'If cbway.SelectedItem = "Cache" Then
        '    txtnum.Text = "0"
        '    txtnum.Visible = False
        '    lbnum.Visible = False
        '    dtpech.Visible = False
        '    Label4.Visible = False
        'Else
        '    txtnum.Visible = True
        '    lbnum.Visible = True
        '    dtpech.Visible = True
        '    Label4.Visible = True
        'End If
    End Sub

    Private Sub btPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPrint.Click
        If DGVP.Rows.Count = 0 Then Exit Sub

        Try
            PrintDoc.PrinterSettings.PrinterName = Form1.txtreceipt.Text
            PrintDoc.Print()

        Catch ex As Exception

            If Form1.PrintDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintDoc.PrinterSettings.PrinterName = Form1.PrintDlg.PrinterSettings.PrinterName
                PrintDoc.Print()
            End If
        End Try
    End Sub
    Dim M As Integer = 0

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage
        Try
            Using a As DrawClass = New DrawClass
                Dim dte As Date = Now.Date
                a.Drawpayemt(e, DGV, DGVP.SelectedRows(0).Cells(0).Value,
                            clientName, clid, fctid, isSell, Now.Date, DGVP.SelectedRows(0).Cells(1).Value,
                            DGVP.SelectedRows(0).Cells(2).Value, DGVP.SelectedRows(0).Cells(3).Value, M)

            End Using

        Catch ex As Exception
            M = 0
        End Try
    End Sub


End Class