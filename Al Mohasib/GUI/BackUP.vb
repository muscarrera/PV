Imports System.IO

Public Class BackUP

    Private Sub BackUP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtfd.Text = CDate(Date.Now).ToString("yy")
        txtfn.Text = 0
        txtbd.Text = CDate(Date.Now).ToString("yy")
        txtbn.Text = 0

        Dim msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "EnableDeleting", Nothing)
        If msg = Nothing Then
            msg = True
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "EnableDeleting", msg)
            CheckBox1.Checked = msg
        Else
            CheckBox1.Checked = msg
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim strpath As String = "c:/"
        Dim sdf As New SaveFileDialog
        If sdf.ShowDialog = Windows.Forms.DialogResult.OK Then
            strpath = sdf.FileName

            Dim ds As New ALMohassinDBDataSet()
            'Dim ada As New ALMohassinDBDataSetTableAdapters.ClientTableAdapter
            'ada.Fill(ds.Client)
            'Dim ada6 As New ALMohassinDBDataSetTableAdapters.PaymentTableAdapter
            'ada6.Fill1(ds.Payment)
            'Dim ada1 As New ALMohassinDBDataSetTableAdapters.companyTableAdapter
            'ada1.Fill(ds.company)
            'Dim ada7 As New ALMohassinDBDataSetTableAdapters.CompanyPaymentTableAdapter
            'ada7.Fill1(ds.CompanyPayment)
            'Dim ada9 As New ALMohassinDBDataSetTableAdapters.CategoryTableAdapter
            'ada9.Fill(ds.Category)

            'Dim ada2 As New ALMohassinDBDataSetTableAdapters.FactureTableAdapter
            'ada2.Fill(ds.Facture)
            'Dim ada3 As New ALMohassinDBDataSetTableAdapters.DetailsFactureTableAdapter
            'ada3.Fill1(ds.DetailsFacture)
            'Dim ada4 As New ALMohassinDBDataSetTableAdapters.BonTableAdapter
            'ada4.Fill(ds.Bon)
            'Dim ada5 As New ALMohassinDBDataSetTableAdapters.DetailsBonTableAdapter
            'ada5.Fill1(ds.DetailsBon)

            ds.WriteXml(strpath & Date.Now.Day.ToString & "-" & Date.Now.Month.ToString & "-" & Date.Now.Year.ToString & ".xml")

            MsgBox("  تم حفظ البيانات  بنجاح ")
        End If

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim nmdg As New num
        If nmdg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        If TextBox1.Text = "" Then Exit Sub
        Using a As BackUpRestaure = New BackUpRestaure
            a.UpdateDataBase(TextBox1.Text)
        End Using
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim con As OleDb.OleDbConnection = New OleDb.OleDbConnection(My.Settings.ALMohassinDBConnectionString)
            Try
                con.Close()
            Catch ex As Exception

            End Try


            Dim SFD As New SaveFileDialog
            SFD.Filter = "*.backup|*.backup"
            If SFD.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
            Dim f As New FileInfo(GetDatabaseName())
            f.CopyTo(SFD.FileName)


            MsgBox("Backup complete successfully", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "AL Mohassib POS Back Up")


        Catch ex As Exception
            MsgBox("Unable to make Backup", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Error")

        End Try
    End Sub
    Function GetDatabaseName() As String
        Dim lcConnString = My.Settings.ALMohassinDBConnectionString
        lcConnString = lcConnString.ToLower

        ' if this is a Jet database, find the index of the "data source" setting
        Dim startIndex As Integer
        If lcConnString.IndexOf("jet.oledb") > -1 Then
            startIndex = lcConnString.IndexOf("data source=")
            If startIndex > -1 Then startIndex += 12
        Else
            ' if this is a SQL Server database, find the index of the "initial 
            ' catalog" or "database" setting
            startIndex = lcConnString.IndexOf("initial catalog=")
            If startIndex > -1 Then
                startIndex += 16
            Else ' if the "Initial Catalog" setting is not found,
                '  try with "Database"
                startIndex = lcConnString.IndexOf("database=")
                If startIndex > -1 Then startIndex += 9
            End If
        End If

        ' if the "database", "data source" or "initial catalog" values are not 
        ' found, return an empty string
        If startIndex = -1 Then Return ""

        ' find where the database name/path ends
        Dim endIndex As Integer = lcConnString.IndexOf(";", startIndex)
        If endIndex = -1 Then endIndex = lcConnString.Length

        ' return the substring with the database name/path
        Return lcConnString.Substring(startIndex, endIndex - startIndex)
    End Function
    
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            Dim strpath As String = "D:/"
            Dim sdf As New SaveFileDialog
            If sdf.ShowDialog = Windows.Forms.DialogResult.OK Then
                strpath = sdf.FileName
            Else
                Exit Sub
            End If

            Dim MyCon As OleDb.OleDbConnection = Nothing
            MyCon = New OleDb.OleDbConnection(My.Settings.ALMohassinDBConnectionString)
            MyCon.Open()

            Dim ada As New OleDb.OleDbDataAdapter("select * from Client", MyCon)
            Dim ds As New DataSet()
            ada.Fill(ds, "Client")

            ds.WriteXml(strpath & Date.Now.Day.ToString & "-" & Date.Now.Month.ToString & "-" & Date.Now.Year.ToString & "-Les Clients.xml")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            Dim strpath As String = "D:/"
            Dim sdf As New SaveFileDialog
            If sdf.ShowDialog = Windows.Forms.DialogResult.OK Then
                strpath = sdf.FileName
            Else
                Exit Sub
            End If

            Dim MyCon As OleDb.OleDbConnection = Nothing
            MyCon = New OleDb.OleDbConnection(My.Settings.ALMohassinDBConnectionString)
            MyCon.Open()
            Dim ds As New ALMohassinDBDataSet()
            'Dim ada9 As New ALMohassinDBDataSetTableAdapters.CategoryTableAdapter
            'ada9.Fill(ds.Category)
            'Dim ada8 As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
            'ada8.Fill(ds.Article)

            ds.WriteXml(strpath & Date.Now.Day.ToString & "-" & Date.Now.Month.ToString & "-" & Date.Now.Year.ToString & "-Produits.xml")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click

        If MsgBox("عند الموافقة سيتم حذف جميع المعطيات و التعاملات دون حفظها", MsgBoxStyle.YesNo Or MessageBoxIcon.Exclamation, "برمجة المصنع") = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim nmdg As New num
        If nmdg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        Dim conn As New OleDb.OleDbConnection
        Dim trans As OleDb.OleDbTransaction = Nothing
        Try



            'open olidb connection and start transaction

            '  Dim tmp As New ALMohassinDBDataSetTableAdapters.ClientTableAdapter
            conn.ConnectionString = My.Settings.ALMohassinDBConnectionString
            conn.Open()
            trans = conn.BeginTransaction

            'clear db
            Dim CMd As New OleDb.OleDbCommand
            CMd.CommandText = "Delete from DetailsFacture"
            CMd.Connection = conn
            CMd.Transaction = trans
            CMd.ExecuteNonQuery()
            CMd.Dispose()

            CMd.CommandText = "Delete from Facture"
            CMd.Connection = conn
            CMd.Transaction = trans
            CMd.ExecuteNonQuery()
            CMd.Dispose()


            CMd.CommandText = "Delete from DetailsBon"
            CMd.Connection = conn
            CMd.Transaction = trans
            CMd.ExecuteNonQuery()
            CMd.Dispose()

            CMd.CommandText = "Delete from DetailsStock"
            CMd.Connection = conn
            CMd.Transaction = trans
            CMd.ExecuteNonQuery()
            CMd.Dispose()

            CMd.CommandText = "Delete from DetailStock"
            CMd.Connection = conn
            CMd.Transaction = trans
            CMd.ExecuteNonQuery()
            CMd.Dispose()

            CMd.CommandText = "Delete from Bon"
            CMd.Connection = conn
            CMd.Transaction = trans
            CMd.ExecuteNonQuery()
            CMd.Dispose()
            CMd.CommandText = "Delete from CompanyPayment"
            CMd.Connection = conn
            CMd.Transaction = trans
            CMd.ExecuteNonQuery()
            CMd.Dispose()

            CMd.CommandText = "Delete from Stock"
            CMd.Connection = conn
            CMd.Transaction = trans
            CMd.ExecuteNonQuery()
            CMd.Dispose()
            CMd.CommandText = "Delete from Payment"
            CMd.Connection = conn
            CMd.Transaction = trans
            CMd.ExecuteNonQuery()
            CMd.Dispose()

            CMd.CommandText = "update Client set credit=:1"
            CMd.Connection = conn
            CMd.Transaction = trans
            CMd.Parameters.AddWithValue(":1", 0)
            CMd.ExecuteNonQuery()
            CMd.Dispose()

            CMd.CommandText = "update Company set credit=:1"
            CMd.Connection = conn
            CMd.Transaction = trans
            CMd.Parameters.AddWithValue(":1", 0)
            CMd.ExecuteNonQuery()
            CMd.Dispose()

            CMd.CommandText = "update Article set qte=:1"
            CMd.Connection = conn
            CMd.Transaction = trans
            CMd.Parameters.AddWithValue(":1", 0)
            CMd.ExecuteNonQuery()
            CMd.Dispose()

            CMd.CommandText = "Delete from Charge"
            CMd.Connection = conn
            CMd.Transaction = trans
            CMd.ExecuteNonQuery()
            CMd.Dispose()

            trans.Commit()
            conn.Close()
            MsgBox("  تم الحذف و التعديل  بنجاح ")
        Catch ex As Exception
            trans.Rollback()
            conn.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click

        Dim conn As New OleDb.OleDbConnection
        Dim trans As OleDb.OleDbTransaction = Nothing
        '  Try



        'open olidb connection and start transaction
        '
        ' Dim tmp As New ALMohassinDBDataSetTableAdapters.FactureTableAdapter
        'Dim DT = tmp.GetData()

        '    conn.ConnectionString = My.Settings.ALMohassinDBConnectionString
        '    conn.Open()
        '    trans = conn.BeginTransaction
        '    Dim CMd As New OleDb.OleDbCommand


        '    For i As Integer = 0 To DT.Rows.Count - 1
        '        If DT.Rows(i).Item("payed") = False Then

        '            If DT.Rows(i).Item("total") = DT.Rows(i).Item("avance") Then
        '                CMd.CommandText = "update  facture set payed=:1 where fctid=:2"
        '                Dim CMD71 As New OleDb.OleDbCommand
        '                CMd.Connection = conn
        '                CMd.Transaction = trans

        '                CMd.Parameters.AddWithValue(":1", True)
        '                CMd.Parameters.AddWithValue(":2", DT.Rows(i).Item("fctid"))
        '                CMd.ExecuteNonQuery()
        '                CMd.Dispose()
        '            End If
        '        End If
        '    Next

        '    trans.Commit()
        '    conn.Close()

        '    MsgBox("  تم التعديل  بنجاح ")

        'Catch ex As Exception

        '    trans.Rollback()
        '    conn.Close()
        '    MsgBox(ex.Message)
        'End Try
    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        'Dim a As Integer = 0
        'Try



        '    'open olidb connection and start transaction

        '    Dim TAC As New ALMohassinDBDataSetTableAdapters.CategoryTableAdapter
        '    Dim DTc = TAC.GetData()

        '    Dim TAa As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
        '    Dim DTa = TAa.GetData()
        '    Dim f As Integer = 0
        '    For i As Integer = 0 To DTa.Rows.Count - 1
        '        f = 0
        '        For j As Integer = 0 To DTc.Rows.Count - 1
        '            If DTc.Rows(j).Item("Cid") = DTa.Rows(i).Item("Cid") Then
        '                f = 1
        '                Exit For
        '            End If
        '        Next

        '        If f = 0 Then

        '            TAa.DeleteQuery(DTa.Rows(i).Item(0))
        '            a += 1

        '        End If

        '    Next



        '    MsgBox(a & "  تم التعديل  بنجاح ")

        'Catch ex As Exception


        '    MsgBox(ex.Message)
        'End Try
    End Sub
    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Try

            Dim pwdwin As New PWDPicker
            If pwdwin.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            Dim params As New Dictionary(Of String, String)

            params.Add("fdnStart", txtfd.Text & "000" & txtfn.Text)
            params.Add("bdnStart", txtbd.Text & "000" & txtbn.Text)

            Using z As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params2 As New Dictionary(Of String, Object)
                Dim id As String = txtfd.Text & "0000" & txtfn.Text
                params2.Add("fctid", id)
                z.InsertRecord("Facture", params2)
                z.DeleteRecords("Facture", params2)

                params2.Clear()
                params2.Add("flid", id)
                z.InsertRecord("Facture_Liste", params2)
                z.DeleteRecords("Facture_Liste", params2)

                params2.Clear()
                id = txtbd.Text & "000" & txtbn.Text
                params2.Add("bonid", id)
                z.InsertRecord("Bon", params2)
                z.DeleteRecords("Bon", params2)
            End Using
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Dim OPF As New OpenFileDialog
        If OPF.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = OPF.FileName
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            'Detailstock
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            params.Add("depot", 3)
            c.UpdateRecordAll("DetailsFacture", params)
            c.UpdateRecordAll("DetailsBon", params)
            MsgBox("greet job")
        End Using

        makeChanging()
    End Sub

    Private Sub makeChanging()
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            'Detailstock
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)
            Dim dt = c.SelectDataTable("Detailstock", {"*"})

            For i As Integer = 0 To dt.Rows.Count - 1
                Dim id As Integer = dt.Rows(i).Item(0)
                Dim arid As Integer = dt.Rows(i).Item("arid")
                Dim dpid As Integer = dt.Rows(i).Item("dpid")
                Dim qte As Double = dt.Rows(i).Item("qte")
                Dim cid As Integer = dt.Rows(i).Item("cid")
                Dim unit As String = dt.Rows(i).Item("unit")

                If dpid = 3 Then Continue For

                Dim oldQte As Double = qte

                where.Add("arid", arid)
                where.Add("dpid", 3)

                Dim dtt = c.SelectDataTable("Detailstock", {"*"}, where)
                where.Clear()

                If dtt.Rows.Count > 0 Then
                    oldQte += dtt.Rows(0).Item("qte")
                    params.Add("qte", oldQte)
                    where.Add("DSID", dtt.Rows(0).Item(0))
                    c.UpdateRecord("Detailstock", params, where)

                    params.Clear()
                    where.Clear()
                    params.Add("qte", 0)
                    where.Add("DSID", id)
                    c.UpdateRecord("Detailstock", params, where)
                Else
                    params.Add("arid", arid)
                    params.Add("dpid", 3)
                    params.Add("qte", qte)
                    params.Add("cid", cid)
                    params.Add("unit", unit)

                    c.InsertRecord("Detailstock", params)

                    params.Clear()
                    where.Clear()
                    params.Add("qte", 0)
                    where.Add("DSID", id)
                    c.UpdateRecord("Detailstock", params, where)
                End If

                params.Clear()
                where.Clear()
            Next
            MsgBox("greet job")
        End Using
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim nmdg As New num
        If nmdg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If


        If TextBox1.Text = "" Then Exit Sub
        Using a As BackUpRestaure = New BackUpRestaure
            a.UpdateDataBaseForAhmed(TextBox1.Text)
        End Using

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        'Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

        '    'Detailstock
        '    Dim params As New Dictionary(Of String, Object)
        '    Dim where As New Dictionary(Of String, Object)

        '    params.Add("poid", 0)
        '    c.UpdateRecordAll("DetailsFacture", params)
        '    c.UpdateRecordAll("DetailsBon", params)
        '    MsgBox("greet job")
        'End Using

        If MsgBox("عند الموافقة سيتم حذف جميع المعطيات و التعاملات دون حفظها", MsgBoxStyle.YesNo Or MessageBoxIcon.Exclamation, "برمجة المصنع") = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim nmdg As New num
        If nmdg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        Dim conn As New OleDb.OleDbConnection
        Dim trans As OleDb.OleDbTransaction = Nothing
        Try



            'open olidb connection and start transaction

            '    Dim tmp As New ALMohassinDBDataSetTableAdapters.ClientTableAdapter
            conn.ConnectionString = My.Settings.ALMohassinDBConnectionString
            conn.Open()
            trans = conn.BeginTransaction

            'clear db
            Dim CMd As New OleDb.OleDbCommand

            CMd.CommandText = "Delete from DetailsStock"
            CMd.Connection = conn
            CMd.Transaction = trans
            CMd.ExecuteNonQuery()
            CMd.Dispose()

            CMd.CommandText = "Delete from DetailStock"
            CMd.Connection = conn
            CMd.Transaction = trans
            CMd.ExecuteNonQuery()
            CMd.Dispose()
 
            trans.Commit()
            conn.Close()
            MsgBox("  تم الحذف و التعديل  بنجاح ")
        Catch ex As Exception
            trans.Rollback()
            conn.Close()
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)
            Dim t_ttc As Double = 0
            Dim t_tva As Double = 0
            Dim t_ht As Double = 0

            Dim DT = c.SelectDataTable("Facture", {"fctid", "remise"})

            For i As Integer = 0 To DT.Rows.Count - 1
                where.Add("fctid", DT.Rows(i).Item(0))
                Dim d = c.SelectDataTable("DetailsFacture", {"price", "qte"}, where)
                For a As Integer = 0 To d.Rows.Count - 1
                    t_ttc += d.Rows(a).Item("price") * d.Rows(a).Item("qte")
                Next

                Dim _Remise As Integer = 0
                Dim _tva As Integer = 0
                Try
                    _Remise = DT.Rows(i).Item("remise")
                Catch ex As Exception
                    _Remise = 0
                End Try

                t_ht = CDbl((100 * t_ttc) / (1.2 * (100 - _Remise)))

                '    Dim T As Decimal = Total_Ht
                t_tva = (t_ht - (t_ht * _Remise / 100)) * 20 / 100

                'Dim T As Decimal = Total_Ht
                t_ttc = (t_ht - (t_ht * _Remise / 100)) + t_tva
                'Return tt


                params.Add("total", t_ttc)
                params.Add("tva", t_tva)

                c.UpdateRecord("Facture", params, where)
                where.Clear()
                params.Clear()
                t_ht = 0
                t_ttc = 0
                t_tva = 0
            Next

            'Detailstock
            MsgBox("greet job")
        End Using
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click

        Try

            Using a As BackUpRestaure = New BackUpRestaure
                a.UpdateDataBaseXmlForAhmed(TextBox1.Text)
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            'Detailstock
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            params.Add("tva", 20)
            c.UpdateRecordAll("DetailsFacture", params)
            c.UpdateRecordAll("DetailsBon", params)
            MsgBox("greet job")
        End Using
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)
            Dim t_ttc As Double = 0
            Dim t_tva As Double = 0
            Dim t_ht As Double = 0

            Dim DT = c.SelectDataTable("Facture", {"fctid", "remise"})

            For i As Integer = 0 To DT.Rows.Count - 1
                where.Add("fctid", DT.Rows(i).Item(0))
                Dim d = c.SelectDataTable("DetailsFacture", {"price", "qte"}, where)
                For a As Integer = 0 To d.Rows.Count - 1
                    Dim _total = d.Rows(a).Item("price") * d.Rows(a).Item("qte")
                    Dim tva As Double = d.Rows(a).Item("tva")
                    Dim ht As Decimal = _total / ((100 + tva) / 100)
                    Dim t As Decimal = (ht * tva) / 100
                    Dim ttcc As Double = ht + t

                    t_ttc += ttcc
                Next

                Dim _Remise As Integer = 0
                Dim _tva As Integer = 0
                Try
                    _Remise = DT.Rows(i).Item("remise")
                Catch ex As Exception
                    _Remise = 0
                End Try

                t_ht = CDbl((100 * t_ttc) / (1.2 * (100 - _Remise)))

                '    Dim T As Decimal = Total_Ht
                t_tva = (t_ht - (t_ht * _Remise / 100)) * 20 / 100

                'Dim T As Decimal = Total_Ht
                t_ttc = (t_ht - (t_ht * _Remise / 100)) + t_tva
                'Return tt


                params.Add("total", t_ttc)
                params.Add("tva", t_tva)

                c.UpdateRecord("Facture", params, where)
                where.Clear()
                params.Clear()
                t_ht = 0
                t_ttc = 0
                t_tva = 0
            Next

            'Detailstock
            MsgBox("greet job")
        End Using
    End Sub

    Private Sub Button17_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)
             Dim total As Double = 0

            params.Add("total", 0)
            c.UpdateRecordAll("Facture_Liste", params)

            Dim DT = c.SelectDataTable("Facture_Liste", {"*"})
            params.Clear()

            For i As Integer = 0 To DT.Rows.Count - 1

                total = 0

                params.Add("beInFacture", DT.Rows(i).Item(0))
                Dim dt2 = c.SelectDataTable("Facture", {"*"}, params)
                params.Clear()

                For t As Integer = 0 To dt2.Rows.Count - 1
                    total += dt2.Rows(t).Item("total")
                Next

                If Not IsDBNull(DT.Rows(i).Item("mode")) Then
                    If DT.Rows(i).Item("mode") <> "Cheque" Then total += total * 0.0025
                End If

                params.Add("total", total)
                where.Add("flid", DT.Rows(i).Item(0))

                c.UpdateRecord("Facture_Liste", params, where)
                where.Clear()
                params.Clear()
            Next

            'Detailstock
            MsgBox("greet job")
        End Using
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "EnableDeleting", CheckBox1.Checked)
        Form1.EnableDeleting = CheckBox1.Checked
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Dim g As New BackUpClass

        Try
            Dim OPF As New OpenFileDialog

            If OPF.ShowDialog = Windows.Forms.DialogResult.OK Then
                g = ReadFromXmlFile(Of BackUpClass)(OPF.FileName)

                SaveDataLocalyWithPathToDb(g)
                 

            End If

        Catch ex As Exception
        End Try
    End Sub
    Public Sub SaveDataLocalyWithPathToDb(ByVal bk As BackUpClass)
        Try




            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)
                a.DeleteRecords("article")
                For i As Integer = 0 To bk.dt_article.Rows.Count - 1
                    params.Clear()
                    params.Add("arid", bk.dt_article.Rows(i).Item("arid"))
                    params.Add("cid", bk.dt_article.Rows(i).Item("cid")) ' cid)
                    params.Add("name", bk.dt_article.Rows(i).Item("name")) 'txtprdname.text)
                    params.Add("bprice", bk.dt_article.Rows(i).Item("bprice")) 'bprice)
                    params.Add("sprice", bk.dt_article.Rows(i).Item("sprice")) 'sprice)
                    params.Add("unite", bk.dt_article.Rows(i).Item("unite")) 'txtunit.text)
                    params.Add("codebar", bk.dt_article.Rows(i).Item("codebar")) ' txtcb.text)
                    params.Add("tva", bk.dt_article.Rows(i).Item("tva")) 'tva)
                    params.Add("sp3", bk.dt_article.Rows(i).Item("sp3")) 'price2)
                    params.Add("sp4", bk.dt_article.Rows(i).Item("sp4")) ' price3)
                    params.Add("sp5", bk.dt_article.Rows(i).Item("sp5")) 'price4)
                    params.Add("poid", bk.dt_article.Rows(i).Item("poid")) 'TxtPoids.text)
                    params.Add("depot", bk.dt_article.Rows(i).Item("depot")) ' CInt(CBdp.SelectedValue))
                    params.Add("mixte", bk.dt_article.Rows(i).Item("mixte")) 'CBool(cbIsMixte.Checked))
                    params.Add("elements", bk.dt_article.Rows(i).Item("elements")) 'txtMinStock.text)
                    params.Add("isMixte", bk.dt_article.Rows(i).Item("isMixte")) 'CBool(cbIsMixte.Checked))
                    a.InsertRecord("article", params)
                Next


                a.DeleteRecords("facture_liste")
                For i As Integer = 0 To bk.dt_facture_liste.Rows.Count - 1
                    params.Clear()
                    params.Add("ListBl", bk.dt_facture_liste.Rows(i).Item("ListBl")) '
                    params.Add("clid", bk.dt_facture_liste.Rows(i).Item("clid")) '
                    params.Add("date", bk.dt_facture_liste.Rows(i).Item("date")) '
                    params.Add("remise", bk.dt_facture_liste.Rows(i).Item("remise")) '
                    params.Add("timbre", bk.dt_facture_liste.Rows(i).Item("timbre")) '
                    params.Add("mode", bk.dt_facture_liste.Rows(i).Item("mode")) '
                    params.Add("total", bk.dt_facture_liste.Rows(i).Item("total")) '

                    a.InsertRecord("facture_liste", params)
                Next


                a.DeleteRecords("depot")
                For i As Integer = 0 To bk.dt_Depot.Rows.Count - 1
                    params.Clear()
                    params.Add("dpid", bk.dt_Depot.Rows(i).Item("dpid")) '
                    params.Add("name", bk.dt_Depot.Rows(i).Item("name")) '

                    a.InsertRecord("depot", params)
                Next

                a.DeleteRecords("machine")
                For i As Integer = 0 To bk.dt_machine.Rows.Count - 1
                    params.Clear()
                    params.Add("Mid ", bk.dt_machine.Rows(i).Item("Mid")) '
                    params.Add("name", bk.dt_machine.Rows(i).Item("name")) '
                    params.Add("val", bk.dt_machine.Rows(i).Item("val")) '

                    a.InsertRecord("machine", params)
                Next

                'chid	name	price	isRepeated	duree	writer	date	
                a.DeleteRecords("charge")
                For i As Integer = 0 To bk.dt_Charge.Rows.Count - 1
                    params.Clear()
                    ' params.Add("Mid ", bk.dt_Charge.Rows(i).Item("Mid")) '
                    params.Add("name", bk.dt_Charge.Rows(i).Item("name")) '
                    params.Add("price", bk.dt_Charge.Rows(i).Item("price")) '
                    params.Add("isRepeated ", bk.dt_Charge.Rows(i).Item("isRepeated")) '
                    params.Add("duree", bk.dt_Charge.Rows(i).Item("duree")) '
                    params.Add("writer", bk.dt_Charge.Rows(i).Item("writer")) '
                    params.Add("date", bk.dt_Charge.Rows(i).Item("date")) '
                    a.InsertRecord("charge", params)
                Next


                a.DeleteRecords("Category")
                For i As Integer = 0 To bk.dt_Category.Rows.Count - 1
                    params.Clear()
                    params.Add("cid", bk.dt_Category.Rows(i).Item("cid"))
                    params.Add("name", bk.dt_Category.Rows(i).Item("name")) ' TextBox1.Text)
                    params.Add("img", bk.dt_Category.Rows(i).Item("img")) ' PBctg.Tag)
                    params.Add("pr", bk.dt_Category.Rows(i).Item("pr")) ' cp) 'CBool(cbIsMixte.Checked))
                    a.InsertRecord("Category", params)
                Next


                a.DeleteRecords("Client")
                For i As Integer = 0 To bk.dt_Client.Rows.Count - 1
                    params.Clear()

                    params.Add("Clid", bk.dt_Client.Rows(i).Item("Clid")) 'txtname.text)
                    params.Add("name", bk.dt_Client.Rows(i).Item("name")) 'txtname.text)
                    params.Add("CIN", bk.dt_Client.Rows(i).Item("CIN")) 'txtcin.text)
                    params.Add("Adress", bk.dt_Client.Rows(i).Item("Adress")) 'adresse)
                    params.Add("tel", bk.dt_Client.Rows(i).Item("tel")) 'txttel.text)
                    params.Add("credit", bk.dt_Client.Rows(i).Item("credit")) ' "0")
                    params.Add("type", bk.dt_Client.Rows(i).Item("type")) ' tp) 'CInt(txtcrd.text))
                     
                    a.InsertRecord("Client", params)
                Next

                a.DeleteRecords("company")
                For i As Integer = 0 To bk.dt_Fournisseur.Rows.Count - 1
                    params.Clear()

                    params.Add("compid", bk.dt_Fournisseur.Rows(i).Item("compid")) 'txtname.text)
                    params.Add("name", bk.dt_Fournisseur.Rows(i).Item("name")) 'txtname.text)
                    params.Add("gerant", bk.dt_Fournisseur.Rows(i).Item("gerant")) 'txtcin.text)
                    params.Add("adress", bk.dt_Fournisseur.Rows(i).Item("adress")) 'adresse)
                    params.Add("tel", bk.dt_Fournisseur.Rows(i).Item("tel")) 'txttel.text)
                    params.Add("credit", bk.dt_Fournisseur.Rows(i).Item("credit")) ' "0")

                    a.InsertRecord("company", params)
                Next

                a.DeleteRecords("payment")
                For i As Integer = 0 To bk.dt_Client_Payement.Rows.Count - 1
                    params.Clear()

                    params.Add("Pid", bk.dt_Client_Payement.Rows(i).Item("Pid")) '
                    params.Add("name", bk.dt_Client_Payement.Rows(i).Item("name")) '
                    params.Add("cid", bk.dt_Client_Payement.Rows(i).Item("cid")) '
                    params.Add("montant", bk.dt_Client_Payement.Rows(i).Item("montant")) ' '
                    params.Add("way", bk.dt_Client_Payement.Rows(i).Item("way")) '
                    params.Add("date", bk.dt_Client_Payement.Rows(i).Item("date")) ' Format(dte, "dd-MM-yyyy HH:mm"))
                    params.Add("Num", bk.dt_Client_Payement.Rows(i).Item("Num")) '
                    params.Add("fctid", bk.dt_Client_Payement.Rows(i).Item("fctid")) '
                    params.Add("writer", bk.dt_Client_Payement.Rows(i).Item("writer")) '
                    params.Add("caisse", bk.dt_Client_Payement.Rows(i).Item("caisse")) '
                     
                    a.InsertRecord("payment", params)
                Next

                a.DeleteRecords("companypayment")
                For i As Integer = 0 To bk.dt_Company_Payement.Rows.Count - 1
                    params.Clear()

                    params.Add("PBid", bk.dt_Company_Payement.Rows(i).Item("PBid")) '
                    params.Add("name", bk.dt_Company_Payement.Rows(i).Item("name")) '
                    params.Add("cid", bk.dt_Company_Payement.Rows(i).Item("cid")) '
                    params.Add("montant", bk.dt_Company_Payement.Rows(i).Item("montant")) ' '
                    params.Add("way", bk.dt_Company_Payement.Rows(i).Item("way")) '
                    params.Add("date", bk.dt_Company_Payement.Rows(i).Item("date")) ' Format(dte, "dd-MM-yyyy HH:mm"))
                    params.Add("Num", bk.dt_Company_Payement.Rows(i).Item("Num")) '
                    params.Add("fctid", bk.dt_Company_Payement.Rows(i).Item("fctid")) '
                    params.Add("writer", bk.dt_Company_Payement.Rows(i).Item("writer")) '
                    'params.Add("caisse", bk.dt_Company_Payement.Rows(i).Item("caisse")) '

                    a.InsertRecord("companypayment", params)
                Next

                a.DeleteRecords("facture")
                For i As Integer = 0 To bk.dt_Sell_Facture.Rows.Count - 1
                    params.Clear()

                    params.Add("fctid", bk.dt_Sell_Facture.Rows(i).Item("fctid")) '
                    params.Add("clid", bk.dt_Sell_Facture.Rows(i).Item("clid")) '
                    params.Add("name", bk.dt_Sell_Facture.Rows(i).Item("name")) '
                    params.Add("total", bk.dt_Sell_Facture.Rows(i).Item("total")) '
                    params.Add("avance", bk.dt_Sell_Facture.Rows(i).Item("avance")) '
                    params.Add("date", bk.dt_Sell_Facture.Rows(i).Item("date")) '
                    params.Add("admin", bk.dt_Sell_Facture.Rows(i).Item("admin")) '
                    params.Add("writer", bk.dt_Sell_Facture.Rows(i).Item("writer")) '
                    params.Add("tp", bk.dt_Sell_Facture.Rows(i).Item("tp")) '
                    params.Add("payed", bk.dt_Sell_Facture.Rows(i).Item("payed")) '
                    params.Add("poid", bk.dt_Sell_Facture.Rows(i).Item("poid")) '
                    params.Add("num", bk.dt_Sell_Facture.Rows(i).Item("num")) '
                    params.Add("tva", bk.dt_Sell_Facture.Rows(i).Item("tva")) '
                    params.Add("adresse", bk.dt_Sell_Facture.Rows(i).Item("adresse")) '
                    params.Add("bl", bk.dt_Sell_Facture.Rows(i).Item("bl")) '
                    params.Add("remise", bk.dt_Sell_Facture.Rows(i).Item("remise")) '
                    params.Add("beInFacture", bk.dt_Sell_Facture.Rows(i).Item("beInFacture")) '
                    params.Add("caisse", bk.dt_Sell_Facture.Rows(i).Item("caisse")) '

                    a.InsertRecord("facture", params)
                Next

                a.DeleteRecords("bon")
                For i As Integer = 0 To bk.dt_Bon_Achat.Rows.Count - 1
                    params.Clear()

                    params.Add("bonid", bk.dt_Bon_Achat.Rows(i).Item("bonid")) '
                    params.Add("clid", bk.dt_Bon_Achat.Rows(i).Item("clid")) '
                    params.Add("name", bk.dt_Bon_Achat.Rows(i).Item("name")) '
                    params.Add("total", bk.dt_Bon_Achat.Rows(i).Item("total")) '
                    params.Add("avance", bk.dt_Bon_Achat.Rows(i).Item("avance")) '
                    params.Add("date", bk.dt_Bon_Achat.Rows(i).Item("date")) '
                    params.Add("admin", bk.dt_Bon_Achat.Rows(i).Item("admin")) '
                    params.Add("writer", bk.dt_Bon_Achat.Rows(i).Item("writer")) '
                    params.Add("tp", bk.dt_Bon_Achat.Rows(i).Item("tp")) '
                    params.Add("payed", bk.dt_Bon_Achat.Rows(i).Item("payed")) '
                    params.Add("poid", bk.dt_Bon_Achat.Rows(i).Item("poid")) '
                    params.Add("num", bk.dt_Bon_Achat.Rows(i).Item("num")) '
                    params.Add("tva", bk.dt_Bon_Achat.Rows(i).Item("tva")) '
                    params.Add("adresse", bk.dt_Bon_Achat.Rows(i).Item("adresse")) '
                    params.Add("bl", bk.dt_Bon_Achat.Rows(i).Item("bl")) '
                    params.Add("remise", bk.dt_Bon_Achat.Rows(i).Item("remise")) '
                    params.Add("beInFacture", bk.dt_Bon_Achat.Rows(i).Item("beInFacture")) '
                    params.Add("caisse", bk.dt_Bon_Achat.Rows(i).Item("caisse")) '

                    a.InsertRecord("bon", params)
                Next

                a.DeleteRecords("detailsfacture")
                For i As Integer = 0 To bk.dt_Details_Sell_Facture.Rows.Count - 1
                    params.Clear()

                    params.Add("fctid", bk.dt_Details_Sell_Facture.Rows(i).Item("fctid")) '
                    params.Add("name", bk.dt_Details_Sell_Facture.Rows(i).Item("name")) '
                    params.Add("bprice", bk.dt_Details_Sell_Facture.Rows(i).Item("bprice")) '
                    params.Add("price", bk.dt_Details_Sell_Facture.Rows(i).Item("price")) '
                    params.Add("unit", bk.dt_Details_Sell_Facture.Rows(i).Item("unit")) '
                    params.Add("qte", bk.dt_Details_Sell_Facture.Rows(i).Item("qte")) '
                    params.Add("tva", bk.dt_Details_Sell_Facture.Rows(i).Item("tva")) '
                    params.Add("arid", bk.dt_Details_Sell_Facture.Rows(i).Item("arid")) '
                    params.Add("depot", bk.dt_Details_Sell_Facture.Rows(i).Item("depot")) '
                    params.Add("poid", bk.dt_Details_Sell_Facture.Rows(i).Item("poid")) '
                    params.Add("code", bk.dt_Details_Sell_Facture.Rows(i).Item("code")) '
                    params.Add("cid", bk.dt_Details_Sell_Facture.Rows(i).Item("cid")) '
                    params.Add("rprice", bk.dt_Details_Sell_Facture.Rows(i).Item("rprice")) '
                    params.Add("caisse", bk.dt_Details_Sell_Facture.Rows(i).Item("caisse")) '

                    a.InsertRecord("detailsfacture", params)
                Next

                a.DeleteRecords("detailsbon")
                For i As Integer = 0 To bk.dt_Details_Bon_Achat.Rows.Count - 1
                    params.Clear()

                    params.Add("fctid", bk.dt_Details_Bon_Achat.Rows(i).Item("fctid")) '
                    params.Add("name", bk.dt_Details_Bon_Achat.Rows(i).Item("name")) '
                    params.Add("bprice", bk.dt_Details_Bon_Achat.Rows(i).Item("bprice")) '
                    params.Add("price", bk.dt_Details_Bon_Achat.Rows(i).Item("price")) '
                    params.Add("unit", bk.dt_Details_Bon_Achat.Rows(i).Item("unit")) '
                    params.Add("qte", bk.dt_Details_Bon_Achat.Rows(i).Item("qte")) '
                    params.Add("tva", bk.dt_Details_Bon_Achat.Rows(i).Item("tva")) '
                    params.Add("arid", bk.dt_Details_Bon_Achat.Rows(i).Item("arid")) '
                    params.Add("depot", bk.dt_Details_Bon_Achat.Rows(i).Item("depot")) '
                    params.Add("poid", bk.dt_Details_Bon_Achat.Rows(i).Item("poid")) '
                    params.Add("code", bk.dt_Details_Bon_Achat.Rows(i).Item("code")) '
                    params.Add("cid", bk.dt_Details_Bon_Achat.Rows(i).Item("cid")) '
                    params.Add("rprice", bk.dt_Details_Bon_Achat.Rows(i).Item("rprice")) '
                    params.Add("caisse", bk.dt_Details_Bon_Achat.Rows(i).Item("caisse")) '

                    a.InsertRecord("detailsbon", params)
                Next

                a.DeleteRecords("admin")
                For i As Integer = 0 To bk.dt_admin.Rows.Count - 1
                    params.Clear()
                    params.Add("adid", bk.dt_admin.Rows(i).Item("adid")) '
                    params.Add("name", bk.dt_admin.Rows(i).Item("name")) '
                    params.Add("admin", bk.dt_admin.Rows(i).Item("admin")) '
                    params.Add("pwd", bk.dt_admin.Rows(i).Item("pwd")) '
                    params.Add("rf", "-")
                    params.Add("role", bk.dt_admin.Rows(i).Item("role")) '

                    a.InsertRecord("admin", params)
                Next



                'bk.dt_machine = a.SelectDataTable("machine", {"*"})
                'bk.dt_Charge = a.SelectDataTable("charge", {"*"})
            End Using
 
            MsgBox("  تم حفظ البيانات  بنجاح ")

        Catch ex As Exception
        End Try





    End Sub
End Class