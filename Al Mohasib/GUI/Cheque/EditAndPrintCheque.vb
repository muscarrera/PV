Imports System.IO
Imports System.Drawing.Printing

Public Class EditAndPrintCheque

    Dim __p As Integer
    Public isRelatedApp As Boolean = False
    Dim nb_trial As Integer = 0
    Dim bonId As Integer = 0
    Dim str_Path As String = ""
    Dim _montant As Double
    Dim tb_P As String = "CompanyPayment"
    Dim tb_F As String = "Bon"
    Dim Tb_C As String = "company"
    Dim _fld As String = "fctid"
    Dim _cl As String = "cid"
    Dim _pid As String = "PBid"
    Dim _bnk As String = ""
    Public _isSell As Boolean = False
    Dim _obs As String = ""
    Dim _pj As Integer
    Dim _cltname As String

    Public Property Pid As Integer
        Get
            Return __p
        End Get
        Set(ByVal value As Integer)
            __p = value
            lbId.Text = value
            If value = 0 Then
                ClearForm()
            Else
                FillForm()
            End If
        End Set
    End Property
    Dim old_frct_ls As New List(Of Integer)
    Public Property clid As Integer
        Get
            Try
                If txtClient.text.Trim = "" Then Return 0
                If IsNumeric(txtClient.text.Trim) Then Return CInt(txtClient.text.Trim)

                Return txtClient.text.Split("|")(1)
            Catch ex As Exception
                Return 0
            End Try
        End Get
        Set(ByVal value As Integer)

            txtClient.text = clientName

            If value = 0 Or isRelatedApp = False Then Exit Property

            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                If isSell Then
                    params.Add("Clid", value)
                Else
                    params.Add("compid", value)
                End If

                clientName = a.SelectByScalar(Tb_C, "name", params)
                txtClient.text = clientName & "|" & value

                Dim total As Double = 0
                Dim avc As Double = 0

                params.Clear()
                params.Add("clid", value)
                Try
                    total = a.SelectByScalar(tb_F, "SUM(total)", params)
                    avc = a.SelectByScalar(tb_F, "SUM(avance)", params)
                Catch ex As Exception
                End Try

                params.Clear()
                'params.Add("cid", value)

                'Try
                '    avc = a.SelectByScalar(tb_P, "SUM(montant)", params)
                'Catch ex As Exception
                'End Try

                Dim rest = total - avc

                lbCredit.Text = rest.ToString("N2")
                lbRealCredit.Text = rest.ToString("N2")

                lbBs.Text = total.ToString("N2")
                lbPm.Text = avc.ToString("N2")

                Try

                    params.Clear()
                    params.Add("clid", value)
                    params.Add("payed", False)

                    Dim dt = a.SelectDataTable(tb_F, {"*"}, params)

                    For i As Integer = 0 To dt.Rows.Count - 1
                        If old_frct_ls.Contains(dt.Rows(i).Item(0)) Then Continue For

                        Dim fp As New FacturePayementItem
                        fp.DataSource = dt.Rows(i)
                        fp.Dock = DockStyle.Top

                        AddHandler fp.SelectionChanged, AddressOf FP_SelectionChanged
                        pl.Controls.Add(fp)
                        'fp.BringToFront()
                    Next
                Catch ex As Exception
                End Try


            End Using



        End Set
    End Property
    Public Property montant As Double
        Get
            Return _montant
        End Get
        Set(ByVal value As Double)
            _montant = value
            lbMontant.Text = value.ToString("N2") & " dhs"
        End Set
    End Property
    Public Property clientName As String
        Get
            Return txtClient.text.Split("|")(0)
        End Get
        Set(ByVal value As String)
            txtClient.text = value & "|" & clid
        End Set
    End Property
    Public Property isSell As Boolean
        Get
            Return _isSell
        End Get
        Set(ByVal value As Boolean)
            _isSell = value

            If value Then
                tb_F = "Facture"
                tb_P = "Payment"
                tb_C = "Client"
                _pid = "Pid"
            Else
                tb_F = "Bon"
                tb_P = "CompanyPayment"
                Tb_C = "company"
                _pid = "PBid"
            End If

        End Set
    End Property
    Private Property obs As String
        Get
            If Pid = 0 Then
                Return "Nv:D" & Now.ToString("ddMMyy") & "P:" & ChequePanel.adminName
            Else
                If _obs.EndsWith("D" & Now.ToString("ddMMyy") & "P:" & ChequePanel.adminName) Then Return _obs
                Dim t = _obs
                t &= "Md:D" & Now.ToString("ddMMyy") & "P:" & ChequePanel.adminName
                If t.Length >= 255 Then t = t.Substring(t.Length - 255)
                _obs = t
                Return t
            End If
        End Get
        Set(ByVal value As String)
            _obs = value
        End Set
    End Property
    Private Property design As String
        Get
            Return __design
        End Get
        Set(ByVal value As String)
            __design = value
            _isImpye = False
            lbDesgn.Text = value
            Panel20.BackColor = Color.WhiteSmoke
            If IsNumeric(value) Then
                If value = 0 Then
                    lbDesgn.Text = "Aucun"

                ElseIf value > 0 Then
                    lbDesgn.Text = "N° : " & value
                Else
                    lbDesgn.Text = "N° : " & value & " [IMPAYE]"
                    Panel20.BackColor = Color.LavenderBlush
                    _isImpye = True
                End If
            Else
                If value.Length < 3 Then
                    lbDesgn.Text = "Aucun"
                Else
                    lbDesgn.Text = value
                    If value = "IMPAYE" Then _isImpye = True
                End If
            End If
        End Set
    End Property
    Private Property _isImpye As Boolean
        Get
            Return plImpaye.Visible
        End Get
        Set(ByVal value As Boolean)
            plImpaye.Visible = value
        End Set
    End Property

    Private Sub FillForm()

        Dim dt As DataTable

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)

            params.Add(_pid, Pid)
            dt = c.SelectDataTable(tb_P, {"*"}, params)

            Try
                params.Clear()
                params.Add("name", "@" & Pid)
                Dim dtt = c.SelectDataTable(tb_P, {"*"}, params)

                For i As Integer = 0 To dtt.Rows.Count - 1
                    Try
                        params.Clear()

                        If isSell Then
                            params.Add("fctid", CInt(dtt.Rows(i).Item("fctid")))
                        Else
                            params.Add("bonid", CInt(dtt.Rows(i).Item("fctid")))
                        End If


                        Dim dtt_fn = c.SelectDataTable(tb_F, {"*"}, params)

                        Dim fp As New FacturePayementItem
                        fp.DataSource = dtt_fn.Rows(0)
                        fp.id_fraction = CInt(dtt.Rows(i).Item(0))
                        fp._avc -= CDbl(dtt.Rows(i).Item("montant"))
                        fp.montant_fraction = CDbl(dtt.Rows(i).Item("montant"))
                        fp.isActive = True
                        fp.Dock = DockStyle.Top
                        AddHandler fp.SelectionChanged, AddressOf FP_SelectionChanged
                        pl.Controls.Add(fp)
                        ' fp.BringToFront()
                        old_frct_ls.Add(CInt(dtt.Rows(i).Item("fctid")))
                    Catch ex As Exception
                    End Try
                Next

            Catch ex As Exception
            End Try
            params = Nothing
        End Using


        If dt.Rows.Count > 0 Then
            txtClient.text = StrValue(dt, "name", 0)
            clid = IntValue(dt, _cl, 0)
            bonId = IntValue(dt, _fld, 0)

            CbWay.SelectedItem = StrValue(dt, "way", 0)
            montant = DblValue(dt, "montant", 0).ToString("N2")
            txtEcheance.text = DteValue(dt, "ech", 0).ToString("dd/MM/yyyy")
            txtRef.text = StrValue(dt, "Num", 0)
            _bnk = StrValue(dt, "bank", 0)
            obs = StrValue(dt, "obs", 0)
            design = StrValue(dt, "desig", 0)

            'params.Clear()

            'If cid > 0 Then
            '    txtClient.text = cid
            '    If isSell Then
            '        params.Add("Clid", cid)
            '    Else
            '        params.Add("compid", cid)
            '    End If

            '    Dim nm = c.SelectByScalar(Tb_C, "name", params)
            '    txtClient.text = nm & "|" & cid

            'End If
            'params.Clear()

            'If bonId > 0 Then
            '    txtBon.text = bonId

            '    If isSell Then
            '        params.Add(_fld, bonId)
            '    Else
            '        params.Add("bonid", bonId)
            '    End If

            '    Dim dtb As DataTable = c.SelectDataTable(tb_F, {"*"}, params)

            '    If dtb.Rows.Count > 0 Then
            '        lbT.Text = DblValue(dtb, "total", 0).ToString("N2")
            '        lbA.Text = DblValue(dtb, "avance", 0).ToString("N2")
            '        lbR.Text = CDbl(lbT.Text) - CDbl(lbA.Text)
            '    End If
            'End If

            'params.Clear()

        End If
    End Sub
    Private Sub FP_SelectionChanged()
        Try

            Dim av As Double = 0
            Try
                av = montant
            Catch ex As Exception

            End Try

            For Each a As FacturePayementItem In pl.Controls
                a.montant_fraction = 0

                If a.isActive = False Then Continue For

                Dim m = a.rest
                If m <= av Then
                    av = av - m
                Else
                    m = av
                    av = 0
                End If
                a.montant_fraction = m
            Next

            If av <= 0 Then Exit Sub

            For Each a As FacturePayementItem In pl.Controls

                If a.isActive Then Continue For

                Dim m = a.rest
                If m <= av Then
                    av = av - m
                Else
                    m = av
                    av = 0
                End If
                a.montant_fraction = m
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Function savePayement() As Boolean

        ' If Not IsNumeric(lbMontant.Text) Then Return False
        If Not IsDate(txtEcheance.text) Then
            txtEcheance.TXT.Focus()
            Return False
        End If

        Dim dt As DataTable = Nothing

        ' addddd
        'If Pid = 0 Then
        If AddPayement() Then Return True
        'updateeee
        'Else
        'If EditPayement() Then Return True
        'End If

        Return False
    End Function
    Dim __design As String = "-"

    Public Function AddPayement() As Boolean


        Dim _dte As Date = Date.Now
        If IsDate(txtEcheance.text) Then _dte = CDate(txtEcheance.text)

        Dim editMode As Boolean = False
        If Pid > 0 Then editMode = True
        Dim isOk As Integer = 0

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            params.Add("name", clientName)
            params.Add(_cl, clid)
            params.Add("montant", montant)
            params.Add("way", CbWay.Text)
            params.Add("date", Now)
            params.Add("Num", txtRef.text)
            params.Add(_fld, txtBon.text)
            params.Add("writer", CStr(ChequePanel.adminName))
            params.Add("ech", _dte)

            If cbBanque.Text.Contains("*") = False Then params.Add("bank", cbBanque.Text)
            params.Add("obs", obs)

            If editMode = False Then
                If isSell And (CbWay.Text = "Cheque" Or CbWay.Text = "Effet (LC)") Then
                    params.Add("desig", "0")
                Else
                    params.Add("desig", design)
                End If
            Else
                If isSell = False Then
                    params.Add("desig", design)
                End If
            End If

            If editMode Then
                where.Add(_pid, Pid)
                isOk = c.UpdateRecord(tb_P, params, where)

                where.Clear()
                where.Add("name", "@" & Pid)
                c.DeleteRecords(tb_P, where)

                If isSell = False And is_Design_Changed Then
                    where.Clear()
                    where.Add("desig", "@" & Pid)

                    params.Clear()
                    params.Add(" desig", "0")
                    c.UpdateRecord("payment", params, where)

                    If IsNumeric(design) Then
                        If CInt(design) > 0 Then
                            where.Clear()
                            where.Add("Pid", design)

                            params.Clear()
                            params.Add("desig", "@" & Pid)
                            c.UpdateRecord("payment", params, where)
                        End If
                    End If
                End If


            Else
                isOk = c.InsertRecord(tb_P, params, True)
                __p = isOk
                lbId.Text = __p

                If isSell = False And is_Design_Changed And IsNumeric(design) Then
                    If CInt(design) > 0 Then
                        where.Clear()
                        where.Add("Pid", design)
                        params.Clear()
                        params.Add("desig", "@" & Pid)
                        c.UpdateRecord("payment", params, where)
                    End If
                End If 
            End If

            If isRelatedApp Then
                For Each a As FacturePayementItem In pl.Controls
                    If a.montant_fraction = 0 And a.id_fraction = 0 Then Continue For

                    If a.montant_fraction > 0 Then
                        params.Clear()
                        params.Add("name", "@" & Pid)
                        params.Add("cid", 0)
                        params.Add("montant", a.montant_fraction)
                        params.Add("way", CbWay.Text)
                        params.Add("date", Now.Date)
                        params.Add("ech", _dte)
                        params.Add("Num", "@" & Pid)
                        params.Add("writer", CStr(ChequePanel.adminName))
                        params.Add("fctid", a.id)

                        params.Add("bank", "")

                        params.Add("desig", "@F")
                        params.Add("obs", "@F")
                        c.InsertRecord(tb_P, params)
                    End If

                    params.Clear()
                    params.Add("payed", a.isPayed)
                    params.Add("avance", a.avance)
                    where.Clear()
                    If isSell Then
                        where.Add("fctid", a.id)
                    Else
                        where.Add("bonid", a.id)
                    End If

                    c.UpdateRecord(tb_F, params, where)
                Next

                'If bonId > 0 Then
                '    Dim av As Double = CDbl(lbA.Text) + CDbl(txtMontant.text)
                '    Dim isp As Boolean = av >= CDbl(lbT.Text)

                '    params.Clear()
                '    If isSell Then
                '        where.Add(_fld, bonId)
                '    Else
                '        where.Add("bonid", bonId)
                '    End If


                '    params.Add("avance", av)
                '    params.Add("payed", isp)

                '    c.UpdateRecord(tb_F, params, where)
                '    params.Clear()
                '    where.Clear()
                'End If
            End If

            where = Nothing
            params = Nothing
        End Using

        If isOk > 0 Then Return True
        Return False
    End Function
    Public Function EditPayement() As Boolean
        Dim _dte As Date = Date.Now
        If IsDate(txtEcheance.text) Then _dte = CDate(txtEcheance.text)
        Dim nPid As Integer = 0

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            params.Add("name", clientName)
            params.Add(_cl, clid)
            params.Add("montant", montant)
            params.Add("way", CbWay.Text)
            params.Add("Num", txtRef.text)
            params.Add(_fld, txtBon.text)
            params.Add("writer", CStr(ChequePanel.adminName))

            params.Add("ech", _dte)
            'params.Add("desig", "-")
            If cbBanque.Text.Contains("*") = False Then params.Add("bank", cbBanque.Text)
            params.Add("obs", obs)




            where.Add(_pid, Pid)
            nPid = c.UpdateRecord(tb_P, params, where)
            where = Nothing
            params = Nothing
        End Using

        If nPid > 0 Then
            If isRelatedApp Then
                If bonId > 0 Then
                    Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                        Dim params As New Dictionary(Of String, Object)
                        Dim where As New Dictionary(Of String, Object)

                        params.Add(_fld, txtBon.text)
                        Dim av = c.SelectByScalar(tb_P, "SUM(montant)", params)

                        Dim isp As Boolean = av >= CDbl(lbT.Text)

                        params.Clear()
                        If isSell Then
                            where.Add(_fld, bonId)
                        Else
                            where.Add("bonid", bonId)
                        End If

                        params.Add("avance", av)
                        params.Add("payed", isp)

                        c.UpdateRecord(tb_F, params, where)
                        params.Clear()
                        where.Clear()
                    End Using
                End If
            End If

            Return True
        End If

        Return False
    End Function
    Public Function DeletePayement() As Boolean
           Dim nPid As Integer = 0

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            where.Add(_pid, Pid)
            nPid = c.DeleteRecords(tb_P, where)



            where = Nothing
            params = Nothing
        End Using

        If nPid > 0 Then
            If isRelatedApp Then
                montant = 0

                Dim av As Double = montant

                For Each a As FacturePayementItem In pl.Controls
                    a.montant_fraction = 0
                Next

                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                    Dim params As New Dictionary(Of String, Object)
                    Dim where As New Dictionary(Of String, Object)

                    where.Add("name", "@" & Pid)
                    c.DeleteRecords(tb_P, where)


                    For Each a As FacturePayementItem In pl.Controls
                        params.Clear()
                        params.Add("payed", a.isPayed)
                        params.Add("avance", a.avance)
                        where.Clear()
                        If isSell Then
                            where.Add("fctid", a.id)
                        Else
                            where.Add("bonid", a.id)
                        End If

                        c.UpdateRecord(tb_F, params, where)
                    Next
                     
                    params.Clear()
                    where.Clear()
                End Using
            End If

            Return True
        End If

        
        Return False
    End Function
    Public Function ImpayedPayement() As Boolean
        
        Dim nPid As Integer = 0

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            where.Add(_pid, Pid)
            Dim _imp As String = "IMPAYE"

            If isSell = False Then
                If IsNumeric(design) Then
                    If design > 0 Then
                        _imp = design * -1
                    Else
                        Return False
                    End If
                End If

            End If

            params.Add("desig", _imp)
            nPid = c.UpdateRecord(tb_P, params, where)
            design = _imp


            where = Nothing
            params = Nothing
        End Using

        If nPid > 0 Then
            If isRelatedApp Then
                montant = 0

                Dim av As Double = montant

                For Each a As FacturePayementItem In pl.Controls
                    a.montant_fraction = 0
                Next

                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                    Dim params As New Dictionary(Of String, Object)
                    Dim where As New Dictionary(Of String, Object)

                    where.Add("name", "@" & Pid)
                    c.DeleteRecords(tb_P, where)


                    For Each a As FacturePayementItem In pl.Controls
                        params.Clear()
                        params.Add("payed", a.isPayed)
                        params.Add("avance", a.avance)
                        where.Clear()
                        If isSell Then
                            where.Add("fctid", a.id)
                        Else
                            where.Add("bonid", a.id)
                        End If

                        c.UpdateRecord(tb_F, params, where)
                    Next

                    params.Clear()
                    where.Clear()
                End Using
            End If

            Return True
        End If


        Return False
    End Function
    Public Function payedPayement() As Boolean

        Dim nPid As Integer = 0
        Dim should_refrech As Boolean = False
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            where.Add(_pid, Pid)
            Dim _imp As String = "PAYE"

            If isSell = False Then
                If IsNumeric(design) Then
                    If design < 0 Then
                        _imp = design * -1
                        should_refrech = True
                    Else
                        Return False
                    End If
                End If
                If design.StartsWith("IMPAYE") Then should_refrech = True
            Else
                If design.StartsWith("@") Then
                    Return False
                ElseIf design.StartsWith("IMPAYE@") Then
                    _imp = "@" & design.Split("@")(1)
                    should_refrech = True
                End If

                If design.StartsWith("IMPAYE") Then should_refrech = True
            End If

            params.Add("desig", _imp)
            nPid = c.UpdateRecord(tb_P, params, where)
            design = _imp


            where = Nothing
            params = Nothing
        End Using

        If nPid > 0 And should_refrech Then
            If isRelatedApp Then
                UpdatePayedFactuer(montant)

                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                    Dim params As New Dictionary(Of String, Object)
                    Dim where As New Dictionary(Of String, Object)


                    For Each a As FacturePayementItem In pl.Controls
                        params.Clear()
                        params.Add("payed", a.isPayed)
                        params.Add("avance", a.avance)
                        where.Clear()
                        If isSell Then
                            where.Add("fctid", a.id)
                        Else
                            where.Add("bonid", a.id)
                        End If

                        c.UpdateRecord(tb_F, params, where)
                    Next

                    params.Clear()
                    where.Clear()
                End Using
            End If

            Return True
        End If


        Return False
    End Function


    Private Sub ClearForm()

        txtClient.text = ""
        txtBon.text = ""
        lbT.Text = "00"
        lbA.Text = "00"
        lbR.Text = "00"
        montant = 0
        txtEcheance.text = Now.Date.ToString("dd/MM/yyyy")
        txtRef.text = ""
        bonId = 0

        lbMsg.Text = ""
        plMsg.Visible = False
    End Sub

    Private Sub btcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcancel.Click
        Pid = 0
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    Private Sub btcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        If savePayement() Then

            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
               
                Dim total As Double = 0
                Dim avc As Double = 0

                If clid > 0 Then
                    params.Clear()
                    params.Add("clid", clid)
                    Try
                        total = a.SelectByScalar(tb_F, "SUM(total)", params)
                        avc = a.SelectByScalar(tb_F, "SUM(avance)", params)
                    Catch ex As Exception
                    End Try

                    params.Clear()
                    Dim rest = total - avc

                    lbCredit.Text = rest.ToString("N2")
                    lbRealCredit.Text = rest.ToString("N2")

                    lbBs.Text = total.ToString("N2")
                    lbPm.Text = avc.ToString("N2")
                End If
            End Using


            plMsg.Visible = True
            lbMsg.Text = "Opération effectuée avec succès"
            plMsg.BackColor = Color.FromArgb(222, 254, 191)
            lbMsg.ForeColor = Color.FromArgb(115, 234, 160)

        Else
            plMsg.Visible = True
            lbMsg.Text = "l'Opération a échoué"
            plMsg.BackColor = Color.FromArgb(252, 192, 170)
            lbMsg.ForeColor = Color.FromArgb(234, 147, 115)
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If savePayement() Then
            plMsg.Visible = True
            lbMsg.Text = "Opération effectuée avec succès"
            plMsg.BackColor = Color.FromArgb(222, 254, 191)
            lbMsg.ForeColor = Color.FromArgb(115, 234, 160)

        Else
            plMsg.Visible = True
            lbMsg.Text = "l'Opération a échoué"
            plMsg.BackColor = Color.FromArgb(252, 192, 170)
            lbMsg.ForeColor = Color.FromArgb(234, 147, 115)
        End If

        Try

            MP_Localname = cbBanque.Text & ".bqu"
            If cbBanque.Text.Trim.Length < 2 Then
                Dim ss As New SelectBanque
                If ss.ShowDialog = Windows.Forms.DialogResult.OK Then
                    MP_Localname = ss.SelectedBanque & ".bqu"
                Else
                    Exit Sub
                End If

            End If

            Dim dl As New PrintDialog
            If dl.ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintDoc.PrinterSettings.PrinterName = dl.PrinterSettings.PrinterName

                Dim g As New bGlobClass
                g = ReadFromXmlFile(Of bGlobClass)(str_Path & "\bqu\" & MP_Localname)


                g = ReadFromXmlFile(Of bGlobClass)(str_Path & "\bqu\" & MP_Localname)
                Dim ps As New PaperSize(g.P_name, g.Wd, g.Ht)
                ps.PaperName = g.p_Kind
                PrintDoc.DefaultPageSettings.PaperSize = ps
                PrintDoc.DefaultPageSettings.Landscape = g.is_Landscape

                PrintDoc.Print()

            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Private Sub cbBanque_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cbBanque.SelectedItem = "*Cree un Nouveau*" Then
            Dim gch As New ChooseBanque
            gch.str_Path = str_Path
            If gch.ShowDialog = DialogResult.OK Then
                Dim gf As New bForm
                gf.str_Path = str_Path
                gf.localname = gch.localName
                gf.LoadXml()


                If gf.ShowDialog = DialogResult.OK Then

                End If
            End If
        End If
    End Sub
    Private Sub lbMontant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbMontant.Click
        txtMontant.TXT.Focus()
    End Sub

    Private Sub txtMontant_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMontant.Enter
        txtMontant.text = montant
        plM.BackColor = Color.GreenYellow
    End Sub
    Private Sub txtMontant_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMontant.Leave
        txtMontant.text = ""
        plM.BackColor = Color.Transparent
    End Sub
    Private Sub txtMontant_TxtChanged() Handles txtMontant.TxtChanged

        Try
            If txtMontant.TXT.Focused = False Then Exit Sub
            If IsNumeric(__design) Then
                If CInt(__design) > 0 Then

                    plM.BackColor = Color.MediumVioletRed
                    Exit Sub
                End If
            End If
            plM.BackColor = Color.GreenYellow

            Try
                montant = txtMontant.text
            Catch ex As Exception
                montant = 0
            End Try

            Dim av As Double = montant

            For Each a As FacturePayementItem In pl.Controls
                a.montant_fraction = 0

                If a.isActive = False Or _isImpye Then Continue For

                Dim m = a.rest
                If m <= av Then
                    av = av - m
                Else
                    m = av
                    av = 0
                End If
                a.montant_fraction = m
            Next

            If av <= 0 Or _isImpye Then Exit Sub

            For Each a As FacturePayementItem In pl.Controls

                If a.isActive Then Continue For

                Dim m = a.rest
                If m <= av Then
                    av = av - m
                Else
                    m = av
                    av = 0
                End If
                a.montant_fraction = m
            Next

        Catch ex As Exception
        End Try
        pb.BackgroundImage = DrawBl(Data_imp_Source, False, M)

    End Sub
    Private Sub PrintDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage
        Try
            Dim data As New DataTable
            ' Create four typed columns in the DataTable.
            data.Columns.Add("*", GetType(String))
            data.Columns.Add("Nom", GetType(String))
            data.Columns.Add("Date", GetType(String))
            data.Columns.Add("Montant", GetType(String))
            data.Columns.Add("En_Chiffre", GetType(String))
            data.Columns.Add("date_Creation", GetType(String))
            data.Columns.Add("ref", GetType(String))


            Dim str_mnt_chfr As String = ""
            Try
                Dim nPart As Decimal = 0
                Dim zPart As Decimal = 0

                SplitDecimal(CDec(montant), nPart, zPart)
                Dim stt As String = ChLettre.NBLT(nPart) & " Dirhams  "
                If zPart > 0 Then
                    stt &= "et " & ChLettre.NBLT(CInt(zPart * 100)) & " (Cts)"
                End If
                'Dim strTotal As String = "Arrêté la présente facture à la somme : " & stt
                str_mnt_chfr = stt.Substring(0, 2).ToUpper() + stt.Substring(2)
            Catch ex As Exception

            End Try
            data.Rows.Add(" ", clientName, txtEcheance.text, montant.ToString("n2"), str_mnt_chfr, Now.Date.ToString("dd/MM/yyyy"), txtRef.text)

            LoadXml(MP_Localname)
            DrawBl(e, data, False, M)
        Catch ex As Exception
        End Try

    End Sub
    Dim M As Integer = 0

    Public TopFieldDic As New List(Of bTopField)

    Private W_Page As Integer = 1200
    Private h_Page As Integer = 600

    Public localname As String = "Default.bqu"
    Dim p_name As String = "A4"
    Dim p_Kind As PaperKind = PaperKind.A4
    Public Sub LoadXml(ByVal localname As String)
        Dim g As New bGlobClass

        g = ReadFromXmlFile(Of bGlobClass)(str_Path & "\bqu\" & localname)
        TopFieldDic = g.TopFieldDic
        W_Page = g.W_Page
        H_Page = g.h_Page

        p_name = g.P_name
        p_Kind = g.p_Kind
    End Sub
    Public Sub DrawBl(ByRef e As System.Drawing.Printing.PrintPageEventArgs,
                           ByVal data As DataTable, ByVal HD As Boolean, ByRef m As Integer)


        Dim g = e.Graphics

        Dim isRYAL As Boolean = Form1.isBaseOnRIYAL

        Dim y As Integer = 20
        Dim h As Integer = 20
        Dim pen As New Pen(Brushes.Black, 1.0F)

        Dim sf As New StringFormat()

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

                Try
                    If a.hasBloc Then
                        'g.DrawRectangle(pen, a.x, a.y, a.width, a.height)
                        Dim _br As New SolidBrush(Color.FromArgb(a.backColor))
                        g.FillRectangle(_br, a.x, a.y, a.width, a.height)

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
                        g.FillPolygon(_br, myPoints)

                    Else
                        sf.Alignment = a.Alignement
                        If a.isVertical Then
                            sf.FormatFlags = StringFormatFlags.DirectionVertical
                        Else
                            sf.FormatFlags = StringFormatFlags.DisplayFormatControl
                        End If
                        If a.isRotate Then
                            g.TranslateTransform(0, 150)
                            g.RotateTransform(a.rotation)
                        Else
                            g.ResetTransform()
                        End If



                        Dim str As String = data.Rows(0).Item(a.field)
                        str = a.str_start & str & a.str_end
                        g.DrawString(str, fn, B, New RectangleF(top_x, top_y, a.width, a.height), sf)
                    End If

                Catch ex As Exception
                End Try
            Next
        End Using

        m = 0
    End Sub
    Public MP_Localname As String

    Private Sub EditAndPrintCheque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        str_Path = ChequePanel.str_path
        ' getRegistryinfo(isRelatedApp, "isRelatedApp", True)

        FillBanques()

        GB4.Dock = DockStyle.Left
        GB5.Dock = DockStyle.Fill
        GB4.Width = 30
        GB5.BringToFront()

        If isSell Then
            tb_P = "Payment"
            tb_F = "Facture"
            _fld = "fctid"
            Tb_C = "Client"
            _cl = "cid"
            _pid = "Pid"
            ' Me.Width = 455
        End If
    End Sub
    Private Sub FillBanques()
        Dim dir1 As New DirectoryInfo(str_Path & "\bqu")
        If dir1.Exists = False Then dir1.Create()

        Dim aryFi As IO.FileInfo() = dir1.GetFiles("*.bqu")
        Dim fi As IO.FileInfo

        cbBanque.Items.Clear()
        cbBanque.Items.Add("* Selectionner un model *")
        For Each fi In aryFi
            cbBanque.Items.Add(fi.Name.Split(".")(0))
        Next
        cbBanque.Items.Add("***")
        cbBanque.Items.Add("*Cree un Nouveau*")
    End Sub
    Private Sub getRegistryinfo(ByRef b As Boolean, ByVal str As String, ByVal v As Boolean)
        Try
            Dim msg As Boolean
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ALM_ImpCheq", str, Nothing)
            If msg = Nothing Then
                msg = v
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ALM_ImpCheq", str, msg)
                b = msg
            Else
                b = msg
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        txtEcheance.text = Now.Date.ToString("dd/MM/yyyy")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim chs As New ChoseClient
        chs.isSell = isSell
        chs.editMode = True 'Form1.RPl.EditMode

        If chs.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtClient.text = chs.clientName & "|" & chs.cid
            clid = chs.cid
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim chs As New SelectBon
        chs.isSell = isSell
        chs.dte1.Value = chs.dte1.Value.AddMonths(-2)
        chs.cbSearchRegler.SelectedItem = "Non Reglé"

        If txtClient.text.Contains("|") Then chs.txtArSearch.text = txtClient.text
        If IsNumeric(txtBon.text) Then chs.txtArSearch.text = txtBon.text

        If chs.ShowDialog = Windows.Forms.DialogResult.OK Then

            If chs.fctId = 0 Then
                lbT.Text = "0.00"
                lbA.Text = "0.00"
                lbR.Text = "0.00"
                Exit Sub
            End If

            txtBon.text = chs.fctId

            If chs.cId > 0 Then txtClient.text = chs.ClientName & "|" & chs.cId

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                If isSell Then
                    params.Add("fctid", chs.fctId)
                Else
                    params.Add("bonid", chs.fctId)
                End If

                Dim dtb As DataTable = c.SelectDataTable(tb_F, {"*"}, params)

                If dtb.Rows.Count > 0 Then
                    bonId = dtb.Rows(0).Item(0)
                    lbT.Text = DblValue(dtb, "total", 0).ToString("N2")
                    lbA.Text = DblValue(dtb, "avance", 0).ToString("N2")
                    lbR.Text = CDbl(lbT.Text) - CDbl(lbA.Text)
                End If
            End Using


        End If
    End Sub

    Private Sub cbBanque_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBanque.SelectedIndexChanged

        If isSell Then Exit Sub

        localname = cbBanque.Text
        LoadXml()
         pb.BackgroundImage = DrawBl(Data_imp_Source, False, m)


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
                            If a.isVertical Then
                                sf.FormatFlags = StringFormatFlags.DirectionVertical
                            Else
                                sf.FormatFlags = StringFormatFlags.DisplayFormatControl
                            End If
                            If a.isRotate Then
                                G.TranslateTransform(0, 150)
                                G.RotateTransform(a.rotation)
                            Else
                                G.ResetTransform()
                            End If
                            Dim str As String = data.Rows(0).Item(a.field)
                            str = a.str_start & str & a.str_end
                            G.DrawString(str, fn, B, New RectangleF(top_x, top_y, a.width, a.height), sf)

                            top_x -= 5
                            top_y -= 3

                            top_x += 5
                            top_y += 3
                        End If

                    Next
                End Using

                G.DrawRectangle(New Pen(Brushes.Red, 3), 5, 5, W_Page - 10, h_Page - 10)

                _Bmp = DirectCast(Bmp.Clone(), Image)
            End Using
        End Using
        m = 0
        Return _Bmp
    End Function
    Public Sub LoadXml()
        Dim g As New bGlobClass
        Try
            g = ReadFromXmlFile(Of bGlobClass)(str_Path & "\bqu\" & localname & ".bqu")

            TopFieldDic = g.TopFieldDic
            W_Page = g.W_Page
            H_Page = g.h_Page

            p_name = g.P_name
            p_Kind = g.p_Kind 
        Catch ex As Exception
        End Try
    End Sub

    Public ReadOnly Property Data_imp_Source As DataTable
        Get
            Dim data As New DataTable
            ' Create four typed columns in the DataTable.
            data.Columns.Add("*", GetType(String))
            data.Columns.Add("Nom", GetType(String))
            data.Columns.Add("Date", GetType(String))
            data.Columns.Add("Montant", GetType(String))
            data.Columns.Add("En_Chiffre", GetType(String))
           data.Columns.Add("date_Creation", GetType(String))
            data.Columns.Add("ref", GetType(String))

            Dim str_mnt_chfr As String = ""
            Try
                Dim nPart As Decimal = 0
                Dim zPart As Decimal = 0

                SplitDecimal(CDec(montant), nPart, zPart)
                Dim stt As String = ChLettre.NBLT(nPart) & " Dirhams  "
                If zPart > 0 Then
                    stt &= "et " & ChLettre.NBLT(CInt(zPart * 100)) & " (Cts)"
                End If
                'Dim strTotal As String = "Arrêté la présente facture à la somme : " & stt
                str_mnt_chfr = stt.Substring(0, 2).ToUpper() + stt.Substring(2)
            Catch ex As Exception

            End Try
            data.Rows.Add(" ", txtClient.text.Split("|")(0), CDate(txtEcheance.text).ToString("dd/MM/yyyy"), montant, str_mnt_chfr, Now.Date.ToString("dd/MM/yyyy"), txtRef.text)
            Return data
        End Get
    End Property
    Public Property pj As Integer
        Get
            Return _pj
        End Get
        Set(ByVal value As Integer)
            _pj = value

            If value = 0 Then
                lbpj.Text = "Joindre des fichiers"
            Else
                lbpj.Text = "* " & value & " Fichies"
            End If
        End Set
    End Property

    Private Sub txtClient_TxtChanged() Handles txtEcheance.TxtChanged, txtClient.TxtChanged
        If IsDate(txtEcheance.text) Then pb.BackgroundImage = DrawBl(Data_imp_Source, False, M)
    End Sub
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbpj.LinkClicked

        If Pid = 0 Then If AddPayement() = False Then Exit Sub

        Dim add As New AddFiles
        add.id = Pid
        add.isSell = isSell
        If add.ShowDialog = DialogResult.Cancel Then

        End If

    End Sub
    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click

        If Pid = 0 Then If AddPayement() = False Then Exit Sub

        Dim add As New AddFiles
        add.id = Pid
        add.isSell = isSell
        If add.ShowDialog = DialogResult.Cancel Then

        End If
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        If Pid = 0 Then Exit Sub


        Dim op As New PopUpMenu
        op.mode = "M:Machine"
        Dim params As New Dictionary(Of String, String)

        params.Add("Annuler  ", "5")

        If design <> "IMPYE" Then params.Add("IMPAYE  ", "4")
        If design <> "PAYE" And design.StartsWith("@") = False Then params.Add("PAYE  ", "3")
        params.Add("Supprimer le Paiement  ", "2")
        If isSell = False Then params.Add("Reference  ", "1")

        op.dataSource = params

        Dim MPx As Point = MousePosition()
        Dim y = Button3.Top - (35 * params.Count) - 15
        Dim x = Button3.Right - op.Width
        op.Location = New Point(x, y)

        AddHandler op.MenuLostFocus, AddressOf MenuLostFocus
        AddHandler op.MenuElementSelected, AddressOf MenuElementSelected_Machine


        Panel11.Controls.Add(op)
        op.BringToFront()
    End Sub
    Private Sub MenuLostFocus(ByRef ds As PopUpMenu)
        Panel11.Controls.Remove(ds)
        ds.Dispose()
    End Sub
    Dim is_Design_Changed As Boolean = False
    Private Sub MenuElementSelected_Machine(ByRef op As PopUpMenu)
        Dim _str As String = ""
        Dim should_Refrech As Boolean = False

        If op.key = "2" Then
            If DeletePayement() Then
                plMsg.Visible = True
                lbMsg.Text = "Suppression effectuée avec succès"
                plMsg.BackColor = Color.FromArgb(222, 254, 191)
                lbMsg.ForeColor = Color.FromArgb(115, 234, 160)
                Pid = 0
                should_Refrech = True
                Try
                    Dim dg As DataGridView = ChequePanel.pl.Controls(0)
                    If dg.SelectedRows.Count > 0 Then dg.Rows.Remove(dg.SelectedRows(0))
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Catch ex As Exception

                End Try
            Else
                plMsg.Visible = True
                lbMsg.Text = "la Suppression a échoué"
                plMsg.BackColor = Color.FromArgb(252, 192, 170)
                lbMsg.ForeColor = Color.FromArgb(234, 147, 115)
            End If
        ElseIf op.key = "1" Then
            Dim nn As New ListUnUsedCheque

            If nn.ShowDialog = Windows.Forms.DialogResult.OK Then
                is_Design_Changed = True
                Try
                    If nn.isChanged Then
                        design = nn.dg.SelectedRows(0).Cells(0).Value
                        montant = nn.dg.SelectedRows(0).Cells("montant").Value 'DblValue(dt, "montant", 0).ToString("N2")
                        txtEcheance.text = nn.dg.SelectedRows(0).Cells("ech").Value 'DteValue(dt, "ech", 0).ToString("dd/MM/yyyy")
                        CbWay.SelectedItem = nn.dg.SelectedRows(0).Cells("way").Value 'StrValue(dt, "way", 0)
                        obs = "Trsf:D" & Now.ToString("ddMMyy") & "P:" & ChequePanel.adminName 'StrValue(dt, "obs", 0)
                        txtRef.text = nn.dg.SelectedRows(0).Cells("Num").Value 'StrValue(dt, "Num", 0)
                        _bnk = nn.dg.SelectedRows(0).Cells("bank").Value 'S trValue(dt, "bank", 0)

                    Else
                        design = "-"
                        montant = 0 'DblValue(dt, "montant", 0).ToString("N2")
                        obs = "NV:D" & Now.ToString("ddMMyy") & "P:" & ChequePanel.adminName 'StrValue(dt, "obs", 0)
                    End If
                Catch ex As Exception
                End Try

                UpdatePayedFactuer(montant)
            End If
        ElseIf op.key = "3" Then

            If payedPayement() Then
                plMsg.Visible = True
                lbMsg.Text = "Oppertaion (PAYE) effectuée avec succès"
                plMsg.BackColor = Color.FromArgb(222, 254, 191)
                lbMsg.ForeColor = Color.FromArgb(115, 234, 160)
                should_Refrech = True
                Try
                    Dim dg As DataGridView = ChequePanel.pl.Controls(0)
                    If dg.SelectedRows.Count > 0 Then dg.SelectedRows(0).Cells("desig").Value = design
                Catch ex As Exception
                End Try
            Else
                plMsg.Visible = True
                lbMsg.Text = "Oppertaion (PAYE) a échoué"
                plMsg.BackColor = Color.FromArgb(252, 192, 170)
                lbMsg.ForeColor = Color.FromArgb(234, 147, 115)
            End If

        ElseIf op.key = "4" Then
            If ImpayedPayement() Then
                plMsg.Visible = True
                lbMsg.Text = "Oppertaion (IMPAYE) effectuée avec succès"
                plMsg.BackColor = Color.FromArgb(222, 254, 191)
                lbMsg.ForeColor = Color.FromArgb(115, 234, 160)
                should_Refrech = True
                Try
                    Dim dg As DataGridView = ChequePanel.pl.Controls(0)
                    If dg.SelectedRows.Count > 0 Then dg.SelectedRows(0).Cells("desig").Value = design
                Catch ex As Exception
                End Try
            Else
                plMsg.Visible = True
                lbMsg.Text = "Oppertaion (IMPAYE) a échoué"
                plMsg.BackColor = Color.FromArgb(252, 192, 170)
                lbMsg.ForeColor = Color.FromArgb(234, 147, 115)
            End If

        ElseIf op.key = "5" Then

        End If

        MenuLostFocus(op)

        If clid > 0 And should_Refrech = True Then

            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)

                Dim total As Double = 0
                Dim avc As Double = 0

                params.Clear()
                params.Add("clid", clid)
                Try
                    total = a.SelectByScalar(tb_F, "SUM(total)", params)
                    avc = a.SelectByScalar(tb_F, "SUM(avance)", params)
                Catch ex As Exception
                End Try

                params.Clear()
                Dim rest = total - avc

                lbCredit.Text = rest.ToString("N2")
                lbRealCredit.Text = rest.ToString("N2")

                lbBs.Text = total.ToString("N2")
                lbPm.Text = avc.ToString("N2")

            End Using
        End If


    End Sub
    Private Sub UpdatePayedFactuer(ByVal _montant As Double)
        Try

            Dim av As Double = _montant

            For Each a As FacturePayementItem In pl.Controls
                a.montant_fraction = 0

                If a.isActive = False Or _isImpye Then Continue For

                Dim m = a.rest
                If m <= av Then
                    av = av - m
                Else
                    m = av
                    av = 0
                End If
                a.montant_fraction = m
            Next

            If av <= 0 Or _isImpye Then Exit Sub

            For Each a As FacturePayementItem In pl.Controls

                If a.isActive Then Continue For

                Dim m = a.rest
                If m <= av Then
                    av = av - m
                Else
                    m = av
                    av = 0
                End If
                a.montant_fraction = m
            Next

        Catch ex As Exception
        End Try
    End Sub
    Private Sub Panel4_Paint(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel4.Click
        GB4.Dock = DockStyle.Left
        GB5.Dock = DockStyle.Fill
        GB4.Width = 33
        GB5.BringToFront()

    End Sub

    Private Sub Panel35_Paint(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel35.Click
        GB5.Dock = DockStyle.Right
        GB4.Dock = DockStyle.Fill
        GB5.Width = 33
        GB4.BringToFront()
    End Sub
End Class