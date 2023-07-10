Public Class InvoForm

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        dt_details.Rows.Clear()
        dt_Stock.Rows.Clear()
        dg_D.DataSource = Nothing
        _fctid = 0


        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim dt = a.SelectDataTable("invo", {"*"})

            dg_D.DataSource = Nothing
            dg_D.DataSource = dt
            dg_D.Sort(dg_D.Columns(0), System.ComponentModel.ListSortDirection.Descending)

            dg_D.Columns(0).HeaderText = "N°/ID"
            dg_D.Columns(1).HeaderText = "Réf"
            dg_D.Columns(2).HeaderText = "Code"
            dg_D.Columns(3).HeaderText = "Creation"
            dg_D.Columns(4).HeaderText = "Validation"
            dg_D.Columns(5).HeaderText = "Actf *"
            dg_D.Columns(6).Visible = False
            dg_D.Columns(7).Visible = False
            dg_D.Columns(8).HeaderText = "Vald *"

            dg_D.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg_D.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg_D.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg_D.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg_D.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg_D.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            isInvo = True
        End Using

    End Sub

    Dim dt_details As New DataTable
    Dim dt_Stock As New DataTable
    Dim isInvo As Boolean = False
    Dim _fctid As Integer = 0
    Dim _isValid As Boolean = False

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If dg_D.SelectedRows.Count = 0 Then Exit Sub

        If isInvo = False Then
            Button10_Click(Nothing, Nothing)
            Exit Sub
        End If


        _fctid = dg_D.SelectedRows(0).Cells(0).Value

        lbName.Text = dg_D.SelectedRows(0).Cells(1).Value
        lbDateCreation.Text = dg_D.SelectedRows(0).Cells(3).Value
        lbDateValid.Text = dg_D.SelectedRows(0).Cells(4).Value

        btValid.Visible = Not CBool(dg_D.SelectedRows(0).Cells(5).Value)
        _isValid = CBool(dg_D.SelectedRows(0).Cells(8).Value)

        LoadFromDb_Details()
        'showDetails
        Button7_Click(Nothing, Nothing)
        Button1_Click(Nothing, Nothing)
    End Sub

    Private Sub LoadFromDb_Details()
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add("fctid", _fctid)
            dt_details = a.SelectDataTable("detailsinvo", {"id, arid, name AS Designation, bprice AS Pr_Achat, price AS Pr_Vente, qte, unit, depot, cid", " (bprice*qte) AS Valeur_Achat", " (price*qte) AS Valeur_Vente"}, params)

            If _isvalid Then
                params.Clear()

                Dim tb_A As String = "article"
                Dim tb_D_A As String = "detailsinvo"
                params.Add(tb_D_A & ".fctid =", _fctid)

                dt_Stock = a.SelectDataTableSymbols("(" & tb_D_A & " INNER JOIN " & tb_A & " ON " & tb_D_A & ".arid = " & tb_A & ".arid) ",
                    {tb_A & ".codebar, " & tb_A & ".name AS Designation, " & tb_A & ".unite, " & tb_D_A & ".qte, " &
                        tb_D_A & ".arid, " & tb_D_A & ".dpid, " & tb_D_A & ".oldqte AS Enc_Qte"}, params)



            Else
                params.Clear()
                params.Add("fctid = ", _fctid)
                dt_Stock = a.SelectDataTableSymbols("detailsinvo", {"name AS Designation, bprice AS Pr_Achat, price AS Pr_Vente, unit, arid, cid, depot, SUM(qte) As Qte"}, params, , "GROUP BY arid")

                dt_Stock.Columns.Add("Enc_Qte")
                dt_Stock.Columns.Add("Valeur_Vente")
                dt_Stock.Columns.Add("Valeur_Achat")

                For i As Integer = 0 To dt_Stock.Rows.Count - 1
                    dt_Stock.Rows(i).Item("Valeur_Vente") = dt_Stock.Rows(i).Item("Pr_Vente") * dt_Stock.Rows(i).Item("Qte")
                    dt_Stock.Rows(i).Item("Valeur_Achat") = dt_Stock.Rows(i).Item("Pr_Achat") * dt_Stock.Rows(i).Item("Qte")

                    params.Clear()
                    params.Add("arid", dt_Stock.Rows(i).Item("arid"))
                    params.Add("dpid", dt_Stock.Rows(i).Item("depot"))
                    Dim vl As Integer = 0
                    Try
                        vl = a.SelectByScalar("detailstock", "SUM(qte)", params)
                    Catch ex As Exception
                    End Try

                    dt_Stock.Rows(i).Item("Enc_Qte") = vl
                Next
            End If
             
            'SELECT client, SUM(tarif) FROM achat GROUP BY client
            isInvo = False
        End Using
    End Sub


    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        dg_D.DataSource = Nothing
        dg_D.DataSource = dt_details
        dg_D.Sort(dg_D.Columns("arid"), System.ComponentModel.ListSortDirection.Descending)

        dg_D.ReadOnly = True
        dg_D.DefaultCellStyle.BackColor = Nothing
        'dg_D.Columns(0).Visible = False
        'dg_D.Columns(1).Visible = False
        'dg_D.Columns(6).Visible = False


        Try
            Dim sum = Convert.ToDouble(dt_details.Compute("SUM(Valeur_Vente)", String.Empty))
            lbQteOut.Text = sum & " U"
        Catch ex As Exception
            lbQteOut.Text = "... "
        End Try

       Try
            Dim sum = Convert.ToDouble(dt_details.Compute("SUM(Valeur_Achat)", String.Empty))
            lbQteIn.Text = sum & " U"
        Catch ex As Exception
            lbQteIn.Text = "... "
        End Try

        lbLnbr.Text = dg_D.Rows.Count & " Lines"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        dg_D.DataSource = Nothing
        dg_D.DataSource = dt_Stock
        dg_D.Sort(dg_D.Columns("arid"), System.ComponentModel.ListSortDirection.Descending)

        dg_D.Columns(1).DefaultCellStyle.BackColor = Color.MintCream
        dg_D.Columns(2).DefaultCellStyle.BackColor = Color.LavenderBlush
        dg_D.Columns(7).DefaultCellStyle.BackColor = Color.LightSalmon

        dg_D.Columns(7).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
        dg_D.ReadOnly = False
        dg_D.Columns(10).Visible = False
        dg_D.Columns(9).Visible = False

        If btValid.Visible Then
            dg_D.Columns(0).ReadOnly = True
            dg_D.Columns(3).ReadOnly = True
            dg_D.Columns(4).ReadOnly = True
            dg_D.Columns(5).ReadOnly = True
            dg_D.Columns(6).ReadOnly = True
            dg_D.Columns(8).ReadOnly = True
        End If

        Try
            Dim sum = Convert.ToDouble(dt_details.Compute("SUM(Valeur_Vente)", String.Empty))
            lbQteOut.Text = sum & " U"
        Catch ex As Exception
            lbQteOut.Text = "... "
        End Try

        Try
            Dim sum = Convert.ToDouble(dt_details.Compute("SUM(Valeur_Achat)", String.Empty))
            lbQteIn.Text = sum & " U"
        Catch ex As Exception
            lbQteIn.Text = "... "
        End Try

        lbLnbr.Text = dg_D.Rows.Count & " Lines"
        isInvo = False
    End Sub

    Private Sub dg_D_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_D.CellValueChanged
        Try
            'Dim old_v = dg_D.SelectedRows(0).Cells(6).Value
            dg_D.EndEdit()
            'If Not IsNumeric(dg_D.SelectedRows(0).Cells(6).Value) Then
            '    dg_D.SelectedRows(0).Cells(6).Value = old_v
            '    Exit Sub
            'End If

            Dim d_i = dg_D.SelectedRows(0).Cells("arid").Value
            Dim d_v = dg_D.SelectedRows(0).Cells(2).Value
            Dim d_a = dg_D.SelectedRows(0).Cells(1).Value
            Dim d_q = dg_D.SelectedRows(0).Cells(6).Value

            For i As Integer = 0 To dt_Stock.Rows.Count - 1
                If dt_Stock.Rows(i).Item("arid") = d_i Then


                    Try

                        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                            Dim params As New Dictionary(Of String, Object)
                            params.Add("bprice", d_a)
                            params.Add("price", d_v)

                            Dim where As New Dictionary(Of String, Object)
                            where.Add("arid", d_i)

                            a.UpdateRecord("detailsinvo", params, where)
                        End Using
                    Catch ex As Exception
                    End Try





                    dt_Stock.Rows(i).Item("Pr_Vente") = d_v
                    dt_Stock.Rows(i).Item("Pr_Achat") = d_a
                    dt_Stock.Rows(i).Item("Qte") = d_q

                    dt_Stock.Rows(i).Item("Valeur_Vente") = dt_Stock.Rows(i).Item("Pr_Vente") * dt_Stock.Rows(i).Item("Qte")
                    dt_Stock.Rows(i).Item("Valeur_Achat") = dt_Stock.Rows(i).Item("Pr_Achat") * dt_Stock.Rows(i).Item("Qte")

                    For t As Integer = 0 To dt_details.Rows.Count - 1
                        If dt_details.Rows(t).Item("arid") = d_i Then
                            dt_details.Rows(t).Item("Pr_Vente") = d_v
                            dt_details.Rows(t).Item("Pr_Achat") = d_a
                        End If
                    Next

                    Exit For
                End If
            Next
        Catch ex As Exception
        End Try


        Try
            Dim sum = Convert.ToDouble(dt_Stock.Compute("SUM(Valeur_Vente)", 0))
            lbQteOut.Text = sum & " U"
        Catch ex As Exception
            lbQteOut.Text = "... "
        End Try

        Try
            Dim sum = Convert.ToDouble(dt_Stock.Compute("SUM(Valeur_Achat)", 0))
            lbQteIn.Text = sum & " U"
        Catch ex As Exception
            lbQteIn.Text = "... "
        End Try

    End Sub
    Dim _dpid As Integer = -1
    Dim _cid As Integer = 0
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim clc As New ChooseCat

        If clc.ShowDialog = DialogResult.OK Then
            If clc.Button1.Tag = 1 Then
                _cid = clc.DataGridView1.SelectedRows(0).Cells(0).Value
                txtTrCat.text = clc.DataGridView1.SelectedRows(0).Cells(1).Value & "|" & clc.DataGridView1.SelectedRows(0).Cells(0).Value

            Else
                _cid = 0
                txtTrCat.text = ""
            End If
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim clc As New ChoseDepot
        If clc.ShowDialog = DialogResult.OK Then
            If clc.Button1.Tag = 1 Then
                _dpid = clc.DataGridView1.SelectedRows(0).Cells(0).Value
                txtDepot.text = clc.DataGridView1.SelectedRows(0).Cells(1).Value & "|" & clc.DataGridView1.SelectedRows(0).Cells(0).Value

            Else
                _dpid = -1
                txtDepot.text = ""

            End If
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim clc As New ChooseCat

        If clc.ShowDialog = DialogResult.OK Then
            If clc.Button1.Tag = 1 Then
                _cid = clc.DataGridView1.SelectedRows(0).Cells(0).Value
                txtCat.text = clc.DataGridView1.SelectedRows(0).Cells(1).Value & "|" & clc.DataGridView1.SelectedRows(0).Cells(0).Value

            Else
                _cid = 0
                txtCat.text = ""
            End If
        End If
    End Sub

    Private Sub InvoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Using a As SubClass = New SubClass(1)
            a.AutoCompleteArticles(txt, "Article")
        End Using
    End Sub
    Public ReadOnly Property arid As Integer
        Get
            If txt.text.Contains("|") = False Then Return 0
            If Not IsNumeric(txt.text.Trim.Split("|")(1)) Then Return 0

            Return txt.text.Trim.Split("|")(1)
        End Get
    End Property
  
    Private Sub txtDepot_TxtChanged() Handles txtDepot.TxtChanged, txtTrCat.TxtChanged, txt.TxtChanged, txtWriter.TxtChanged

        Dim dt As New DataTable
        dt = dt_details.Copy

        If txt.text.Length > 0 Then
            If arid > 0 Then
                Dim result = From myRow As DataRow In dt.Rows
                                   Where myRow("arid") = arid Select myRow
                If result.Count Then
                    dt = result.CopyToDataTable
                Else
                    dt.Rows.Clear()
                End If
            Else
                Dim result = From myRow As DataRow In dt.Rows
                                Where myRow("Designation").ToString.Contains(txt.text) Select myRow
                If result.Count Then
                    dt = result.CopyToDataTable
                Else
                    dt.Rows.Clear()
                End If
            End If
        End If


        If txtWriter.text.Length > 0 Then
            Dim result = From myRow As DataRow In dt.Rows
                               Where myRow("writer") = txtWriter.text Select myRow
            If result.Count Then
                dt = result.CopyToDataTable
            Else
                dt.Rows.Clear()
            End If
        End If



        If _cid > 0 And _dpid >= 0 Then
            Dim result = From myRow As DataRow In dt.Rows
                                    Where myRow("depot") = _dpid And myRow("cid") = _cid Select myRow
            If result.Count Then
                dt = result.CopyToDataTable
            Else
                dt.Rows.Clear()
            End If


        ElseIf _cid = 0 And _dpid >= 0 Then

            Dim result = From myRow As DataRow In dt.Rows
                                    Where myRow("depot") = _dpid Select myRow
            If result.Count Then
                dt = result.CopyToDataTable
            Else
                dt.Rows.Clear()
            End If


        ElseIf _cid > 0 And _dpid < 0 Then
            Dim result = From myRow As DataRow In dt.Rows
                                    Where myRow("cid") = _cid Select myRow
            If result.Count Then
                dt = result.CopyToDataTable
            Else
                dt.Rows.Clear()
            End If
        End If






        dg_D.DataSource = Nothing
        dg_D.DataSource = dt
        dg_D.Sort(dg_D.Columns("arid"), System.ComponentModel.ListSortDirection.Descending)

        dg_D.ReadOnly = True
        dg_D.DefaultCellStyle.BackColor = Nothing

        Try
            Dim sum = Convert.ToDouble(dt_details.Compute("SUM(Valeur_Vente)", String.Empty))
            lbQteOut.Text = sum & " U"
        Catch ex As Exception
            lbQteOut.Text = "... "
        End Try

        Try
            Dim sum = Convert.ToDouble(dt_details.Compute("SUM(Valeur_Achat)", String.Empty))
            lbQteIn.Text = sum & " U"
        Catch ex As Exception
            lbQteIn.Text = "... "
        End Try

        lbLnbr.Text = dg_D.Rows.Count & " Lines"

    End Sub
    Private Sub txtstock_TxtChanged() Handles txtdp2.TxtChanged, txtCat.TxtChanged

        Dim dt As New DataTable
        dt = dt_Stock.Copy


        If _cid > 0 And _dpid >= 0 Then
            Dim result = From myRow As DataRow In dt.Rows
                                    Where myRow("depot") = _dpid And myRow("cid") = _cid Select myRow
            If result.Count Then
                dt = result.CopyToDataTable
            Else
                dt.Rows.Clear()
            End If


        ElseIf _cid = 0 And _dpid >= 0 Then

            Dim result = From myRow As DataRow In dt.Rows
                                    Where myRow("depot") = _dpid Select myRow
            If result.Count Then
                dt = result.CopyToDataTable
            Else
                dt.Rows.Clear()
            End If


        ElseIf _cid > 0 And _dpid < 0 Then
            Dim result = From myRow As DataRow In dt.Rows
                                    Where myRow("cid") = _cid Select myRow
            If result.Count Then
                dt = result.CopyToDataTable
            Else
                dt.Rows.Clear()
            End If
        End If


        dg_D.DataSource = Nothing
        dg_D.DataSource = dt
        dg_D.Sort(dg_D.Columns("arid"), System.ComponentModel.ListSortDirection.Descending)

        dg_D.Columns(1).DefaultCellStyle.BackColor = Color.MintCream
        dg_D.Columns(2).DefaultCellStyle.BackColor = Color.LavenderBlush
        dg_D.Columns(6).DefaultCellStyle.BackColor = Color.LightSalmon

        dg_D.Columns(6).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
        dg_D.ReadOnly = False
        dg_D.Columns(8).Visible = False
        dg_D.Columns(9).Visible = False

        If btValid.Visible Then
            dg_D.Columns(0).ReadOnly = True
            dg_D.Columns(3).ReadOnly = True
            dg_D.Columns(4).ReadOnly = True
            dg_D.Columns(5).ReadOnly = True
            dg_D.Columns(7).ReadOnly = True
        End If

        Try
            Dim sum = Convert.ToDouble(dt_details.Compute("SUM(Valeur_Vente)", String.Empty))
            lbQteOut.Text = sum & " U"
        Catch ex As Exception
            lbQteOut.Text = "... "
        End Try

        Try
            Dim sum = Convert.ToDouble(dt_details.Compute("SUM(Valeur_Achat)", String.Empty))
            lbQteIn.Text = sum & " U"
        Catch ex As Exception
            lbQteIn.Text = "... "
        End Try

        lbLnbr.Text = dg_D.Rows.Count & " Lines"
        isInvo = False

    End Sub
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim clc As New ChooseUsers
        If clc.ShowDialog = DialogResult.OK Then
            If clc.Button1.Tag = 1 Then
                txtWriter.text = clc.DataGridView1.SelectedRows(0).Cells(1).Value

            Else
                txtWriter.text = ""
            End If
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        'dg_D.Sort(dg_D.Columns("qte"), System.ComponentModel.ListSortDirection.Descending)
        'dg_D.Sort(dg_D.Columns("arid"), System.ComponentModel.ListSortDirection.Descending)

        Dim txt As String = InputBox("Code de l'inventaire =  ")
        If txt <> "111" Then Exit Sub
        Dim __c As Integer = 0


        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            Dim __a As Integer = 0
            Dim __q As Double = 0

            For i As Integer = 0 To dg_D.RowCount - 1
                If __a = dg_D.Rows(i).Cells("arid").Value Then
                    If __q = dg_D.Rows(i).Cells("qte").Value Then
                        params.Clear()
                        params.Add("id", dg_D.Rows(i).Cells(0).Value)
                        a.DeleteRecords("detailsinvo", params)
                        __c += 1
                    Else
                        __q = dg_D.Rows(i).Cells("qte").Value
                    End If

                Else
                    __a = dg_D.Rows(i).Cells("arid").Value
                    __q = dg_D.Rows(i).Cells("qte").Value
                End If
            Next
        End Using
        MsgBox(__c)


        LoadFromDb_Details()
        Button7_Click(Nothing, Nothing)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim params2 As New Dictionary(Of String, String)
        params2.Add("Nbr", dg_D.Rows.Count)
        params2.Add(Label6.Text, lbQteIn.Text)
        params2.Add(Label7.Text, lbQteOut.Text)
        params2.Add("Date crt", lbDateCreation.Text)
        params2.Add("Date Vld", lbDateValid.Text)
        params2.Add("Editeur", Form1.adminName)

        SaveDataToHtml_WithTotal(dg_D, "Inventaire" & lbName.Text, params2)

    End Sub

    Private Sub btValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btValid.Click
        Dim txt As String = InputBox("Code de Validation =  ")
        If txt <> "91285" Then Exit Sub

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)
            a.DeleteRecords("Detailstock")
            For i As Integer = 0 To dt_Stock.Rows.Count - 1
                params.Clear()
                where.Clear()

                params.Add("arid", dt_Stock.Rows(i).Item("arid"))
                params.Add("dpid", dt_Stock.Rows(i).Item("depot"))
                params.Add("qte", dt_Stock.Rows(i).Item("Qte"))
                params.Add("unit", dt_Stock.Rows(i).Item("unit"))
                params.Add("cid", dt_Stock.Rows(i).Item("cid"))
                a.InsertRecord("Detailstock", params)


                params.Add("oldqte", dt_Stock.Rows(i).Item("Enc_Qte"))
                params.Add("fctid", _fctid)
                a.InsertRecord("stockinvo", params)

                params.Clear()
                params.Add("bprice", dt_Stock.Rows(i).Item("Pr_Achat"))
                where.Add("arid", dt_Stock.Rows(i).Item("arid"))
                a.UpdateRecord("article", params, where)
            Next

            MsgBox("Opération Réussie")
            Button10_Click(sender, e)
        End Using
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add("fctid", _fctid)

            Dim order As New Dictionary(Of String, String)
            order.Add("qte", "Desc")
            order.Add("arid", "Desc")

            dt_details = a.SelectDataTable("detailsinvo", {"id, arid, name AS Designation, bprice AS Pr_Achat, price AS Pr_Vente, qte, unit, depot, cid", " (bprice*qte) AS Valeur_Achat", " (price*qte) AS Valeur_Vente"}, params, order)

            dg_D.DataSource = Nothing
            dg_D.DataSource = dt_details

            isInvo = False
        End Using
    End Sub
End Class