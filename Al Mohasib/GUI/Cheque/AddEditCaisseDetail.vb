Imports System.Drawing.Printing

Public Class AddEditCaisseDetail

    Dim __p As Integer
    Dim __tag As Integer
    Dim __cid As Integer = 0
    Dim MP_Localname As String

    Public Property Pid As Integer
        Get
            Return __p
        End Get
        Set(ByVal value As Integer)
            __p = value
            lbId.Text = value

            FillForm()

        End Set
    End Property
    Public Property caisseId As Integer
        Get
            Return __cid
        End Get
        Set(ByVal value As Integer)
            __cid = value


            FillCaisse()

        End Set
    End Property
    Public Property tags As String
        Get
            Dim str As String = ""

            For Each t As SearchBloc In fl.Controls
                If str <> "" Then str &= "|"
                str &= t.Value

            Next
            Return str
        End Get
        Set(ByVal value As String)
            fl.Controls.Clear()
            Dim tt = value.Split("|")

            For Each t In tt
                Dim aa As New SearchBloc
                aa.Key = "tag"
                aa.Value = t
                AddHandler aa.ClearElemeent, AddressOf SearchBloc_ClearElemeent
                fl.Controls.Add(aa)
            Next

        End Set
    End Property
    Public ReadOnly Property tagsValue As Double
        Get
            Dim tt As Double = 0

            For Each t As SearchBloc In fl.Controls

                Try
                    Dim v = t.Value.Split("-")(0)
                    v = v.Replace("x", "*")

                    Dim q = CDbl(v.Split("*")(0).Trim())
                    Dim p = CDbl(v.Split("*")(1).Trim())

                    tt += q * p

                Catch ex As Exception
                End Try
            Next
            Return tt
        End Get
    End Property
    Private Sub SearchBloc_ClearElemeent(ByVal ds As SearchBloc)
        fl.Controls.Remove(ds)
        GetValeurReel()
    End Sub
    Private Sub FillForm()

        Dim dt As New DataTable

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)

            params.Add("id", Pid)
            dt = c.SelectDataTable("caisse", {"*"}, params)


            If dt.Rows.Count > 0 Then
                txtWrite.text = StrValue(dt, "name", 0)
                lbWriter.Text = StrValue(dt, "writer", 0)
                txtEcheance.text = StrValue(dt, "ech", 0)
                lbDate.Text = StrValue(dt, "date", 0)
                txtValeurTh.text = StrValue(dt, "ValeurTh", 0)
                txtValeurRl.text = StrValue(dt, "ValeurRl", 0)
                tags = StrValue(dt, "tags", 0)
                txt0.text = StrValue(dt, "0d", 0)
                txt1.text = StrValue(dt, "1d", 0)
                txt2.text = StrValue(dt, "2d", 0)
                txt5.text = StrValue(dt, "5d", 0)
                txt10.text = StrValue(dt, "10d", 0)
                txt20.text = StrValue(dt, "20d", 0)
                txt50.text = StrValue(dt, "50d", 0)
                txt100.text = StrValue(dt, "100d", 0)
                txt200.text = StrValue(dt, "200d", 0)
                caisseId = IntValue(dt, "cid", 0)
            End If
        End Using
    End Sub
    Private Sub FillCaisse()
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            Dim tName As String = "Payment"
            Dim dt As DataTable = Nothing
            Dim TT As Decimal = 0

            Dim T_CA As Double = 0
            Dim T_TP As Double = 0
            Dim T_CH As Double = 0
            Dim T_VR As Double = 0

            params.Add("caisse", caisseId)
            dt = a.SelectDataTable(tName, {"*"}, params)


            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    TT += CDec(dt.Rows(i).Item("montant").ToString)

                    If dt.Rows(i).Item("way").ToString.ToUpper.StartsWith("CHEQ") Then
                        T_CH += CDec(dt.Rows(i).Item("montant").ToString)

                    ElseIf dt.Rows(i).Item("way").ToString.ToUpper.StartsWith("TPE") Then
                        T_TP += CDec(dt.Rows(i).Item("montant").ToString)

                    ElseIf dt.Rows(i).Item("way").ToString.ToUpper.StartsWith("VIR") Then
                        T_VR += CDec(dt.Rows(i).Item("montant").ToString)

                    Else
                        T_CA += CDec(dt.Rows(i).Item("montant").ToString)
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' color payed
                Next

            Else
                MsgBox("aucun résultat")
            End If

            txtValeurTh.text = TT.ToString("n2")
            lbValeur.Text = "......................................." &
                            vbNewLine & "Cache : " & vbTab & T_CA.ToString("n2") & " dhs" &
                            vbNewLine & "Cheques : " & vbTab & T_CH.ToString("n2") & " dhs" &
                            vbNewLine & "TPE : " & vbTab & T_TP.ToString("n2") & " dhs" &
                            vbNewLine & "Virements : " & vbTab & T_VR.ToString("n2") & " dhs" &
                           vbNewLine & "......................................."

        End Using
    End Sub
    Private Sub AddEditCaisseDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Form1.adminRole = 100 Then
            lbValeur.Visible = True
            Panel18.Visible = True
        End If


        If Pid > 0 Then btPrint.Visible = True
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        txtEcheance.text = Now.Date
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btWriter.Click
        If Form1.adminRole < 50 Then Exit Sub

        Dim cc As New ChooseUsers
        If cc.ShowDialog = Windows.Forms.DialogResult.OK Then
            If cc.val = 1 Then
                caisseId = 0
                txtValeurRl.text = 0
                txtWrite.text = cc.adminName

                'caisse*
                If GetOpenCaisseLocaly(cc.adminName) = False Then
                    MsgBox("aucun résultat ...")
                    txtWrite.text = ""
                    txtValeurTh.text = 0
                    caisseId = 0
                    Exit Sub
                End If


                If Not IsDate(txtEcheance.text) Then txtEcheance.text = lbDate.Text
                'GetCaisseID()
                If caisseId > 0 Then txtValeurRl.text = Get_CaissePayement(caisseId)
            Else
                txtWrite.text = ""
                txtValeurTh.text = 0
                caisseId = 0
            End If
        End If

    End Sub
    Public Sub GetCaisseID()
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            params.Add("name LIKE ", "%" & txtWrite.text & "%")
            Dim str_dt = CDate(txtEcheance.text).ToString("yyyy-MM-dd") & "%"
            params.Add("date LIKE ", str_dt)
            Dim dt = c.SelectDataTableSymbols("caisse", {"*"}, params)

            If dt.Rows.Count Then
                caisseId = dt.Rows(0).Item(0)
            End If
        End Using

    End Sub
    Public Function GetOpenCaisseLocaly(ByVal nm As String) As Boolean
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim tb_caisse = "DetailsStock"
            Dim params As New Dictionary(Of String, Object)
            params.Add("arid", 0)
            Dim dt = c.SelectDataTable(tb_caisse, {"*"}, params)

            If dt.Rows.Count Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(i).Item("name").ToString.StartsWith(nm) Then
                        caisseId = dt.Rows(i).Item(0)
                        txtEcheance.text = CDate(dt.Rows(i).Item("date")).Date
                        Return True
                    End If
                Next
            End If
        End Using
        Return False
    End Function

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim str As String = ""

        Try

            Dim v = txtAutre.text.Split("-")(0)
            v = v.Replace("x", "*")

            If v.Contains("*") = False Then
                v = "1*" & v
            End If

            Dim q = v.Split("*")(0).Trim()
            Dim p = v.Split("*")(1).Trim()
            str = q & "*" & p

        Catch ex As Exception
            txtAutre.TXT.Focus()
            Exit Sub
        End Try

        Try
            Dim v = txtAutre.text.Split("-")(1)
            v = v.Replace("-", "/")
            str &= "-" & v

        Catch ex As Exception
            str &= "-Esp"
        End Try


        Dim aa As New SearchBloc
        aa.Key = "tag"
        aa.Value = str
        AddHandler aa.ClearElemeent, AddressOf SearchBloc_ClearElemeent
        fl.Controls.Add(aa)

        txtAutre.text = ""
        txtAutre.TXT.Focus()

        GetValeurReel()
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        If Pid = 0 Then
            SaveNewCaisse()
            PrintDoc()
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            EditCaisse()
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub
    Private Sub PrintDoc()
         
        Dim nm As String = ""
        Dim dl As New PrintDialog
        If dl.ShowDialog = Windows.Forms.DialogResult.OK Then
            nm = dl.PrinterSettings.PrinterName
        Else
            Exit Sub
        End If

        MP_Localname = "caisse-cloture.dat"
        Dim g As New gGlobClass
        g = ReadFromXmlFile(Of gGlobClass)(Form1.ImgPah & "\Prt_Dsn\" & MP_Localname)


        Dim ps As New PaperSize(g.P_name, g.W_Page, g.h_Page)
        ps.PaperName = g.p_Kind
        PrintDocument1.DefaultPageSettings.PaperSize = ps
        PrintDocument1.DefaultPageSettings.Landscape = g.is_Landscape
        PrintDocument1.PrinterSettings.PrinterName = nm
        PrintDocument1.Print()


    End Sub

    Private Sub SaveNewCaisse()
        Dim pwdwin As New PWDPicker
        pwdwin.isFillScreen = False

        If pwdwin.ShowDialog = Windows.Forms.DialogResult.OK Then
            If lbWriter.Text.ToUpper = pwdwin.DGV1.SelectedRows(0).Cells(1).Value.ToString.ToUpper Then
                If CloseCaisse(caisseId) Then
                    Dim str As String = Form1.lbCaisse.Text & vbNewLine
                    str &= Get_CaisseTotal(caisseId)
                    Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

                        Dim params As New Dictionary(Of String, Object)
                        params.Add("name", txtWrite.text)
                        params.Add("writer", lbWriter.Text)
                        params.Add("ech", Now.Date)
                        params.Add("date", Now)
                        params.Add("cid", caisseId)
                        params.Add("ValeurTh", CDbl(txtValeurTh.text))
                        params.Add("ValeurRl", CDbl(txtValeurRl.text))
                        params.Add("0d", txt0.text)
                        params.Add("1d", txt1.text)
                        params.Add("2d", txt2.text)
                        params.Add("5d", txt5.text)
                        params.Add("10d", txt10.text)
                        params.Add("20d", txt20.text)
                        params.Add("50d", txt50.text)
                        params.Add("100d", txt100.text)
                        params.Add("200d", txt200.text)
                        params.Add("tags", tags)

                        Dim cid = a.InsertRecord("caisse", params, True)

                    End Using

                    MsgBox(str, MsgBoxStyle.Information, vbOK)
                End If
            End If
        End If
    End Sub
   
    Private Sub EditCaisse()
        Dim pwdwin As New PWDPicker
        pwdwin.isFillScreen = False

        If pwdwin.ShowDialog = Windows.Forms.DialogResult.OK Then
            If pwdwin.DGV1.SelectedRows(0).Cells("role").Value = 100 Then
                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

                    Dim params As New Dictionary(Of String, Object)
                    params.Add("name", txtWrite.text)
                    If IsDate(txtEcheance.text) Then params.Add("ech", CDate(txtEcheance.text))
                    params.Add("ValeurRl", CDbl(txtValeurRl.text))
                    params.Add("0d", txt0.text)
                    params.Add("1d", txt1.text)
                    params.Add("2d", txt2.text)
                    params.Add("5d", txt5.text)
                    params.Add("10d", txt10.text)
                    params.Add("20d", txt20.text)
                    params.Add("50d", txt50.text)
                    params.Add("100d", txt100.text)
                    params.Add("200d", txt200.text)
                    params.Add("tags", tags)

                    Dim where As New Dictionary(Of String, Object)
                    where.Add("id", Pid)

                    Dim cid = a.UpdateRecord("caisse", params, where)

                End Using
                Me.DialogResult = Windows.Forms.DialogResult.OK

            Else
                MsgBox("Vous n’êtes pas autorisé à modifier cette caisse")
            End If
        End If
    End Sub

    Private Sub GetValeurReel() Handles txt50.TxtChanged, txt5.TxtChanged, txt200.TxtChanged, txt20.TxtChanged, txt2.TxtChanged, txt100.TxtChanged, txt10.TxtChanged, txt1.TxtChanged, txt0.TxtChanged
        Dim total As Double = 0
        If IsNumeric(txt0.text) Then total += txt0.text * 0.5
        If IsNumeric(txt1.text) Then total += txt1.text * 1
        If IsNumeric(txt2.text) Then total += txt2.text * 2
        If IsNumeric(txt5.text) Then total += txt5.text * 5
        If IsNumeric(txt10.text) Then total += txt10.text * 10
        If IsNumeric(txt20.text) Then total += txt20.text * 20
        If IsNumeric(txt50.text) Then total += txt50.text * 50
        If IsNumeric(txt100.text) Then total += txt100.text * 100
        If IsNumeric(txt200.text) Then total += txt200.text * 200
        total += tagsValue

        txtValeurRl.text = total.ToString("n2")
    End Sub

    Private Sub txtAutre_KeyDownOk() Handles txtAutre.KeyDownOk
        Button6_Click(Nothing, Nothing)
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim tt As Double = 0
        Dim av As Double = 0
        Dim tv As Double = 0

        Dim detailstable As New DataTable
        ' Create four typed columns in the DataTable.
        detailstable.Columns.Add("arid", GetType(Integer))
        detailstable.Columns.Add("name", GetType(String))
        detailstable.Columns.Add("unit", GetType(String))
        detailstable.Columns.Add("cid", GetType(Integer))
        detailstable.Columns.Add("qte", GetType(Double))
        detailstable.Columns.Add("price", GetType(Double))
        detailstable.Columns.Add("bprice", GetType(Double))
        detailstable.Columns.Add("tva", GetType(Double))
        detailstable.Columns.Add("code", GetType(String))
        detailstable.Columns.Add("depot", GetType(Integer))
        detailstable.Columns.Add("remise", GetType(Integer))
        detailstable.Columns.Add("bl", GetType(Integer))
        detailstable.Columns.Add("totaltva", GetType(Double))
         
        detailstable.Columns.Add("xOrder", GetType(Integer))
        detailstable.Columns.Add("rprice", GetType(Double))
        detailstable.Columns.Add("freeQte", GetType(Double))
        detailstable.Columns.Add("qteStr", GetType(String))



        If IsNumeric(txt0.text) Then detailstable.Rows.Add(0, "0.5 dh", "", 0, txt0.text, 0.5, 0.5, 0, "", 0, 0, 0, 0, 0, 0, 0, txt0.text)
        If IsNumeric(txt1.text) Then detailstable.Rows.Add(0, "1 dh", "", 0, txt1.text, 1, 1, 0, "", 0, 0, 0, 0, 0, 0, 0, txt0.text)
        If IsNumeric(txt2.text) Then detailstable.Rows.Add(0, "2 dh", "", 0, txt2.text, 2, 2, 0, "", 0, 0, 0, 0, 0, 0, 0, txt0.text)
        If IsNumeric(txt5.text) Then detailstable.Rows.Add(0, "5 dh", "", 0, txt5.text, 5, 5, 0, "", 0, 0, 0, 0, 0, 0, 0, txt0.text)
        If IsNumeric(txt10.text) Then detailstable.Rows.Add(0, "10 dh", "", 0, txt10.text, 10, 10, 0, "", 0, 0, 0, 0, 0, 0, 0, txt0.text)
        If IsNumeric(txt20.text) Then detailstable.Rows.Add(0, "20 dh", "", 0, txt20.text, 20, 20, 0, "", 0, 0, 0, 0, 0, 0, 0, txt0.text)
        If IsNumeric(txt50.text) Then detailstable.Rows.Add(0, "50 dh", "", 0, txt50.text, 50, 50, 0, "", 0, 0, 0, 0, 0, 0, 0, txt0.text)
        If IsNumeric(txt100.text) Then detailstable.Rows.Add(0, "100 dh", "", 0, txt100.text, 100, 100, 0, "", 0, 0, 0, 0, 0, 0, 0, txt0.text)
        If IsNumeric(txt200.text) Then detailstable.Rows.Add(0, "200 dh", "", 0, txt200.text, 200, 200, 0, "", 0, 0, 0, 0, 0, 0, 0, txt0.text)

        For Each t As SearchBloc In fl.Controls

            Try
                Dim v = t.Value.Split("-")(0)
                v = v.Replace("x", "*")

                Dim q = CDbl(v.Split("*")(0).Trim())
                Dim p = CDbl(v.Split("*")(1).Trim())
                Dim s = "Cache"
                
                Try 
                    s = t.Value.Split("-")(1)
                Catch ex As Exception
                End Try
                detailstable.Rows.Add(0, s, "", 0, q, p, p, 0, "", 0, 0, 0, 0)
            Catch ex As Exception
            End Try
        Next

        Dim _Datatable As New DataTable
        ' Create four typed columns in the DataTable.
        _Datatable.Columns.Add("id", GetType(String))
        _Datatable.Columns.Add("date", GetType(String))
        _Datatable.Columns.Add("cid", GetType(String))
        _Datatable.Columns.Add("name", GetType(String))
        _Datatable.Columns.Add("total_ht", GetType(String))
        _Datatable.Columns.Add("total_tva", GetType(String))
        _Datatable.Columns.Add("total_ttc", GetType(String))
        _Datatable.Columns.Add("total_remise", GetType(String))
        _Datatable.Columns.Add("total_avance", GetType(String))
        _Datatable.Columns.Add("total_droitTimbre", GetType(String))
        _Datatable.Columns.Add("MPayement", GetType(String))
        _Datatable.Columns.Add("Editeur", GetType(String))
        _Datatable.Columns.Add("vidal", GetType(String))
        _Datatable.Columns.Add("livreur", GetType(String))
        _Datatable.Columns.Add("rest_ttc", GetType(String))
        _Datatable.Columns.Add("x_total_ttc_sn_remise", GetType(String))
        _Datatable.Columns.Add("RealAvance", GetType(String))
        _Datatable.Columns.Add("RealRest", GetType(String))
        _Datatable.Columns.Add("Rest", GetType(String))
        _Datatable.Columns.Add("caisseAvance", GetType(String))
        _Datatable.Columns.Add("caisseRest", GetType(String))
        _Datatable.Columns.Add("Points_NV", GetType(String))
        _Datatable.Columns.Add("Points_ENC", GetType(String))
        _Datatable.Columns.Add("Points_TL", GetType(String))
        _Datatable.Columns.Add("Points_UT", GetType(String))
        _Datatable.Columns.Add("Points_RS", GetType(String))
        _Datatable.Columns.Add("PC_Nom", GetType(String))
        _Datatable.Columns.Add("PC_Tel", GetType(String))
        _Datatable.Columns.Add("PC_Adr", GetType(String))
        _Datatable.Columns.Add("poid", GetType(String))
        _Datatable.Columns.Add("bc", GetType(String))
        _Datatable.Columns.Add("bl", GetType(String))
        _Datatable.Columns.Add("Pouchet", GetType(String))

        ' Add  rows with those columns filled in the DataTable.
        _Datatable.Rows.Add(0, txtEcheance.text, 0, txtWrite.text, txtValeurRl.text, txtValeurRl.text, txtValeurRl.text, "0", txtValeurTh.text, "0", "", lbWriter.Text, 0, "", txtValeurRl.text - txtValeurTh.text, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "nom", "tel", "adrs", 12, lbDate.Text, Now, 0)

        Dim Clienttable As New DataTable
        ' Create four typed columns in the DataTable.
        Clienttable.Columns.Add("Clid", GetType(Integer))
        Clienttable.Columns.Add("name", GetType(String))
        Clienttable.Columns.Add("ref", GetType(String))
        Clienttable.Columns.Add("ville", GetType(String))
        Clienttable.Columns.Add("adresse", GetType(String))
        Clienttable.Columns.Add("ice", GetType(String))
        Clienttable.Columns.Add("tel", GetType(String))
        Clienttable.Columns.Add("NvCredit", GetType(String))
        Clienttable.Columns.Add("EncCredit", GetType(String))
        Clienttable.Columns.Add("RealEncCredit", GetType(String))


        ' Add  rows with those columns filled in the DataTable.
        Clienttable.Rows.Add(1, txtWrite.text, txtWrite.text, "AGADIR", "Av 01", "1234567890", "00000", "123", "23", "23")

        Try
            Using g As gDrawClass = New gDrawClass(MP_Localname)
                g.rtl = Form1.cbRTL.Checked
                 
                g.DrawBl(e, _Datatable, detailstable, Clienttable, "Archive", False, M, params_tva)
            End Using

        Catch ex As Exception
            params_tva.Clear()
        End Try

    End Sub
    Dim M As Integer = 0
    Dim params_tva As New Dictionary(Of Double, Double)

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPrint.Click

        EditCaisse()
        PrintDoc()
        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub txt0_KeyDownOk() Handles txt0.KeyDownOk
        txt1.TXT.Focus()
    End Sub
    Private Sub txt1_KeyDownOk() Handles txt1.KeyDownOk
        txt2.TXT.Focus()
    End Sub
    Private Sub txt2_KeyDownOk() Handles txt2.KeyDownOk
        txt5.TXT.Focus()
    End Sub
    Private Sub txt5_KeyDownOk() Handles txt5.KeyDownOk
        txt10.TXT.Focus()
    End Sub
    Private Sub txt10_KeyDownOk() Handles txt10.KeyDownOk
        txt20.TXT.Focus()
    End Sub
    Private Sub txt20_KeyDownOk() Handles txt20.KeyDownOk
        txt50.TXT.Focus()
    End Sub
    Private Sub txt50_KeyDownOk() Handles txt50.KeyDownOk
        txt100.TXT.Focus()
    End Sub
    Private Sub txt100_KeyDownOk() Handles txt100.KeyDownOk
        txt200.TXT.Focus()
    End Sub
    Private Sub txt200_KeyDownOk() Handles txt200.KeyDownOk
        txtAutre.TXT.Focus()
    End Sub
   
End Class