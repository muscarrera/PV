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

        If clid = 0 Then
            plSide.Visible = True
            DGV.Rows.Clear()
        End If


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
                    params.Add(fld, dt2.Rows(i).Item("fctid"))

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
        Dim cl As String = "cid"
        Dim _pid As String = "PBid"

        If isSell Then
            tableName = "Payment"
            tName = "Facture"
            fld = "fctid"
            cl = "cid"
            _pid = "Pid"
        End If

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            params.Add("name", name)
            params.Add(cl, clid)
            params.Add("montant", montant)
            params.Add("way", way)
            params.Add("date", dte) ' Format(dte, "dd-MM-yyyy HH:mm"))
            params.Add("Num", num)
            params.Add("fctid", fctid)
            params.Add("writer", CStr(Form1.adminName))
            params.Add("caisse", Form1.caisseId)

            Dim Pid = c.InsertRecord(tableName, params, True)

            Dim tt As Double = (Avance + montant) - total

            If tt > 0 And haManyPayement Then

                params.Clear()

                params.Add("montant", tt * -1)
                params.Add("name", "@" & Pid)
                params.Add(cl, clid)
                params.Add("way", way & " - [Rest]")
                params.Add("date", dte) 'Format(dte, "dd-MM-yyyy HH:mm"))
                params.Add("Num", "[" & montant & "]" & num)
                params.Add("fctid", fctid)
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
                    params.Add("date", dte) 'Format(dte, "dd-MM-yyyy HH:mm"))
                    params.Add("Num", "[" & fctid & "] - " & num)
                    params.Add("fctid", id)
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



                If tt > 0 Then
                    Dim p As Integer = 0
                    Dim m As Double = 0
                    Try
                        params.Clear()
                        params.Add("fctid", 0)
                        params.Add(cl, clid)

                        Dim pchdt = c.SelectDataTable(tableName, {_pid, "montant"}, params)
                        p = IntValue(pchdt, _pid, 0)
                        m = DblValue(pchdt, "montant", 0)
                    Catch ex As Exception
                    End Try

                    If p > 0 Then
                        params.Clear()
                        where.Clear()

                        params.Add("montant", tt + m)
                        where.Add(_pid, p)
                        c.UpdateRecord(tableName, params, where)
                        params.Clear()
                    Else
                        params.Clear()
                        params.Add("montant", tt)
                        params.Add("name", clientName)
                        params.Add(cl, clid)
                        params.Add("way", "POCHET")
                        params.Add("date", dte.AddYears(-10)) ' Format(dte.AddYears(-10), "dd-MM-yyyy HH:mm"))
                        params.Add("Num", "POCHET")
                        params.Add("fctid", 0)
                        params.Add("writer", CStr(Form1.adminName))

                        c.InsertRecord(tableName, params)
                        params.Clear()
                    End If
                End If



            End If
            where.Clear()
            where.Add("fctid", fctid)
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
        Dim cl As String = "cid"
        Dim _pid As String = "PBid"

        If isSell Then
            tableName = "Payment"
            tName = "Facture"
            fld = "fctid"
            cl = "cid"
            _pid = "Pid"
        End If

        Dim newAvance As Double = 0

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
            params.Add("date", dte) 'Format(, "dd-MM-yyyy HH:mm")
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
                        where.Add("bonid", dt2.Rows(i).Item("fctid"))
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

                params.Clear()
                params.Add("name", "@" & pid)
                c.DeleteRecords(tableName, params)
            End If

        End Using

        LaodUnPaidFactures()

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)



            where.Add("fctid", fctid)

            newAvance = c.SelectByScalarSum(tableName, "SUM(montant)", where)
            Dim tt As Double = newAvance - total '- oldMontant

            If editMode = True And tt > 0 And haManyPayement Then
                params.Clear()
                where.Clear()

                params.Add("montant", tt * -1)
                params.Add("name", "@" & pid)
                params.Add(cl, clid)
                params.Add("way", way & " - [Rest]")
                params.Add("date", dte) 'Format(dte, "dd-MM-yyyy HH:mm"))
                params.Add("Num", "[" & montant & "]" & num)
                params.Add("fctid", fctid)
                params.Add("writer", CStr(Form1.adminName))

                c.InsertRecord(tableName, params)
                params.Clear()

                ''''''''''''''''''''''''''''''''''''''



                Dim _nm As String = fctid
                For i As Integer = 0 To DGV.Rows.Count - 1
                    _nm &= "|" & DGV.Rows(i).Cells(1).Value
                Next

                Dim ids As String() = _nm.Split("|")


                For i As Integer = 0 To ids.Length - 1
                    If i = 0 Then Continue For

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
                    params.Add("date", dte) ' Format(dte, "dd-MM-yyyy HH:mm"))
                    params.Add("Num", "[" & fctid & "] - " & num)
                    params.Add("fctid", id)
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

                If tt > 0 Then
                    Dim p As Integer = 0
                    Dim m As Double = 0
                    Try
                        params.Clear()
                        params.Add("fctid", 0)
                        params.Add(cl, clid)

                        Dim pchdt = c.SelectDataTable(tableName, {_pid, "montant"}, params)
                        p = IntValue(pchdt, _pid, 0)
                        m = DblValue(pchdt, "montant", 0)
                    Catch ex As Exception
                    End Try

                    If p > 0 Then
                        params.Clear()
                        where.Clear()

                        params.Add("montant", tt + m)
                        where.Add(_pid, p)
                        c.UpdateRecord(tableName, params, where)
                        params.Clear()
                    Else
                        params.Clear()
                        params.Add("montant", tt)
                        params.Add("name", clientName)
                        params.Add(cl, clid)
                        params.Add("way", "POCHET")
                        params.Add("date", dte) ' Format(dte, "dd-MM-yyyy HH:mm"))
                        params.Add("Num", "POCHET")
                        params.Add("fctid", 0)
                        params.Add("writer", CStr(Form1.adminName))

                        c.InsertRecord(tableName, params)
                        params.Clear()
                    End If
                End If


            End If
            where.Clear()
            where.Add("fctid", fctid)
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
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim tableName As String = "Payment"
                If isSell = False Then tableName = "CompanyPayment"
                Dim params As New Dictionary(Of String, Object)
                params.Add("fctid", fctid)

                dt = c.SelectDataTable(tableName, {"*"}, params)
            End Using

            For i As Integer = 0 To dt.Rows.Count - 1
                DGVP.Rows.Add(dt.Rows(i).Item(0), DteValue(dt, "date", i).ToString("dd-MM-yyyy"),
                              dt.Rows(i).Item("montant"), dt.Rows(i).Item("way"),
                              dt.Rows(i).Item("Num"), dt.Rows(i).Item("name"))
                Avance += CDbl(dt.Rows(i).Item("montant"))
            Next

            'If editMode Then LaodUnPaidFactures()
            If clid > 0 Then LaodUnPaidFactures()
            allowSelection = Form1.cbMultiPayemnt.Checked
        Catch x As Exception
        End Try

        'Pochet''''''''''''''''''''''''''
        If clid = 0 Then Exit Sub
        plPoch.Visible = True


        Try
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)


                Dim tableName As String = "CompanyPayment"
                Dim tName As String = "Bon"
                Dim fld As String = "bonid"
                Dim cl As String = "cid"
                Dim _pid As String = "PBid"

                If isSell Then
                    tableName = "Payment"
                    tName = "Facture"
                    fld = "fctid"
                    cl = "cid"
                    _pid = "Pid"
                End If

                Dim params As New Dictionary(Of String, Object)
            
                params.Add("fctid", 0)
                params.Add(cl, clid)

                Dim pchdt = c.SelectDataTable(tableName, {_pid, "montant"}, params)
                If pchdt.rows.count > 0 Then
                    lbPoch.Tag = IntValue(pchdt, _pid, 0)
                    lbPoch.Text = DblValue(pchdt, "montant", 0).ToString(Form1.frmDbl)
                    plPoch.Visible = True
                End If

                params = Nothing
            End Using
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcon.Click
        'validation
        ''empty field
        If txtmontant.text.Trim = "" Then
            txtmontant.Focus()
            Exit Sub
        End If

        Dim _dte As Date = Date.Now 'CDate(dtpech.Text) 
        If btcon.Tag <> "0" Then _dte = CDate(dtpech.Value)
        If cbway.SelectedItem = "Effet (LC)" Then _dte = CDate(dtpech.Value)


        Dim _num As String = txtnum.text
        If Form1.RPl.EditMode = True Then _num = "@/" & _num

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
            DGVP.Rows.Add(dt.Rows(i).Item(0), DteValue(dt, "date", i).ToString("dd-MM-yyyy"),
                          dt.Rows(i).Item("montant"), dt.Rows(i).Item("way"),
                          dt.Rows(i).Item("Num"), dt.Rows(i).Item("name"))
            Avance += CDbl(dt.Rows(i).Item("montant"))
        Next

        For i As Integer = 0 To DGVP.Rows.Count - 1
            If DGVP.Rows(i).Cells(4).Value.ToString.Contains("@") Then
                DGVP.Rows(i).DefaultCellStyle.BackColor = Color.BurlyWood
            End If
        Next

        If isSell Then


            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)
                Dim where As New Dictionary(Of String, Object)

                where.Add("fctid", fctid)
                params.Add("avance", Avance)
                c.UpdateRecord("Facture", params, where)

            End Using

        Else
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)
                Dim where As New Dictionary(Of String, Object)

                where.Add("bonid", fctid)
                params.Add("avance", Avance)
                c.UpdateRecord("Bon", params, where)

            End Using
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
        dtpech.Value = Now
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DGVP.SelectedRows.Count = 0 Then Exit Sub
        If DGVP.SelectedRows(0).Cells(5).Value.ToString.Contains("@") Then Exit Sub
        If Form1.adminRole < 100 Then Exit Sub


        txtmontant.text = DGVP.SelectedRows(0).Cells(2).Value.ToString
        txtmontant.Tag = DGVP.SelectedRows(0).Cells(2).Value.ToString
        txtnum.text = DGVP.SelectedRows(0).Cells(4).Value.ToString
        cbway.Text = DGVP.SelectedRows(0).Cells(3).Value.ToString
        btcon.Tag = DGVP.SelectedRows(0).Cells(0).Value.ToString
        dtpech.Value = CDate(DGVP.SelectedRows(0).Cells(1).Value)

        GroupBox1.Visible = True
        _nm = DGVP.SelectedRows(0).Cells(4).Value
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim rest As Decimal = total
            For i As Integer = 0 To DGVP.Rows.Count - 1
                rest = rest - DGVP.Rows(i).Cells(2).Value
            Next
            Dim dt As DataTable
            Dim tb As String = "payment"
            If Form1.RPl.isSell = False Then tb = "CompanyPayment"

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)
                params.Add("name", "facture")
                params.Add("cid", clid)
                params.Add("montant", rest)
                params.Add("way", "Cache")
                params.Add("date", Now)
                params.Add("fctid", fctid)
                params.Add("writer", Form1.adminName)
                params.Add("paydate", Now)
                params.Add("caisse", Form1.caisseId)
                c.InsertRecord(tb, params, True)
            End Using

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)
                params.Add("fctid", fctid)
              
                dt = c.SelectDataTable(tb, {"*"}, params)
            End Using

            DGVP.Rows.Clear()
            Avance = 0
            For i As Integer = 0 To dt.Rows.Count - 1
                DGVP.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("montant"), dt.Rows(i).Item("way"), dt.Rows(i).Item("Num"))
                Avance += CDbl(dt.Rows(i).Item("montant"))
            Next
            'update facture
            If isSell Then
              
                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    Dim params As New Dictionary(Of String, Object)
                    Dim where As New Dictionary(Of String, Object)

                    where.Add("fctid", fctid)
                    params.Add("avance", Avance)
                    c.UpdateRecord("Facture", params, where)

                End Using
            Else
                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    Dim params As New Dictionary(Of String, Object)
                    Dim where As New Dictionary(Of String, Object)
                    where.Add("bonid", fctid)

                    params.Add("avance", Avance)
                    c.UpdateRecord("Bon", params, where)

                End Using
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
        btPrint.Enabled = True
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellClick
        If allowSelection = False Then Exit Sub
        _nm = ""

        For i As Integer = 0 To DGV.Rows.Count - 1

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


    Private Sub btPanelAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPanelAdd.Click
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            Dim tableName As String = "CompanyPayment"
            Dim tName As String = "Bon"

            Dim cl As String = "cid"
            Dim _pid As String = "PBid"

            If isSell Then
                tableName = "Payment"
                tName = "Facture"
                cl = "cid"
                _pid = "Pid"
            End If

            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            Dim TT As Double = CDbl(lbPoch.Text)
            Dim _p As Integer = CInt(lbPoch.Tag)

            If TT = 0 Then Exit Sub
            If _p = 0 Then Exit Sub

            Dim av As Double = total - Avance
            If av > TT Then
                av = TT
                TT = 0
            Else
                TT -= av
            End If
            params.Add("montant", av)
            params.Add("name", "@POCHET")
            params.Add(cl, clid)
            params.Add("way", "Reserve")
            params.Add("date", Now.Date)
            params.Add("Num", "@POCHET")
            params.Add("fctid", fctid)
            params.Add("writer", CStr(Form1.adminName))
            params.Add("caisse", Form1.caisseId)
            c.InsertRecord(tableName, params)

            params.Clear()
            where.Clear()

            params.Add("montant", TT)
            where.Add(_pid, _p)
            c.UpdateRecord(tableName, params, where)
            lbPoch.Text = TT.ToString(Form1.frmDbl)

            params.Clear()
            where.Clear()
            where.Add("fctid", fctid)
            Dim dt = c.SelectDataTable(tableName, {"*"}, where)

            'fill payment
            DGVP.Rows.Clear()
            Avance = 0

            For i As Integer = 0 To dt.Rows.Count - 1
                DGVP.Rows.Add(dt.Rows(i).Item(0), DteValue(dt, "date", i).ToString("dd-MM-yyyy"),
                              dt.Rows(i).Item("montant"), dt.Rows(i).Item("way"),
                              dt.Rows(i).Item("Num"), dt.Rows(i).Item("name"))
                Avance += CDbl(dt.Rows(i).Item("montant"))
            Next

            For i As Integer = 0 To DGVP.Rows.Count - 1
                If DGVP.Rows(i).Cells(4).Value.ToString.Contains("@") Then
                    DGVP.Rows(i).DefaultCellStyle.BackColor = Color.BurlyWood
                End If
            Next

            If isSell Then
                params.Clear()
                where.Clear()

                where.Add("fctid", fctid)
                params.Add("avance", Avance)
                c.UpdateRecord("Facture", params, where)
            Else
                params.Clear()
                where.Clear()
                where.Add("bonid", fctid)
                params.Add("avance", Avance)
                c.UpdateRecord("Bon", params, where)
            End If

            btcancel_Click(Nothing, Nothing)

            If haManyPayement Then DGV.Columns(0).Visible = False
            DGVP.ClearSelection()

            where = Nothing
            params = Nothing
        End Using
    End Sub
End Class