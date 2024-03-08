Public Class DevisionAuto

    Public Data As New DataTable
    Public dte As Date = Now
    Public fctid As Integer = 0
    Dim percentageValue As Integer = 100

    Private Sub DevisionAuto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbDate.Text = dte.ToString("dd/MM/yyyy")
        Me.Show()
        txt.Focus()
    End Sub
    Dim ls_dt As New List(Of Date)
    Dim ls_tables As New List(Of DataTable)

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If BackgroundWorker1.IsBusy = False Then BackgroundWorker1.RunWorkerAsync()
    End Sub
    Public Sub NewFacture(ByVal id As Integer, ByRef c As DataAccess)
        Try
            Dim fid As Integer = 0
            Dim DataSource = ls_tables(id)
            Dim total As Double = 0
            Try
                total = Convert.ToDouble(DataSource.Compute("SUM(total)", String.Empty))
               
            Catch ex As Exception
            End Try

            Dim params As New Dictionary(Of String, Object)
            params.Add("clid", 0)
            params.Add("name", Form1.txtcltcomptoir.Text)
            params.Add("total", total)
            params.Add("avance", total)
            params.Add("date", ls_dt(id)) 'Format(dte, "dd-MM-yyyy HH:mm"))
            params.Add("admin", True)
            params.Add("writer", CStr(Form1.adminName))
            params.Add("tp", 0)
            params.Add("payed", True)
            params.Add("poid", 0)
            params.Add("num", num)
            params.Add("tva", 0)
            params.Add("adresse", "")
            params.Add("bl", "---")
            params.Add("remise", 0)
            params.Add("beInFacture", 0)
            params.Add("caisse", Form1.caisseId)
            'params.Add("delivredDay", Now.Date.AddDays(2))

            fid = c.InsertRecord(Form1.TB_Bon, params, True)
            params.Clear()

            If fid > 0 Then


                For i As Integer = 0 To DataSource.Rows.Count - 1
                    Dim r As DataRow = DataSource.Rows(i)

                    params.Add("fctid", fid)
                    params.Add("name", r("name"))
                    params.Add("bprice", CDbl(r("bprice")))
                    params.Add("price", r("price"))
                    params.Add("unit", r("unite"))
                    params.Add("qte", r("qte"))

                    params.Add("tva", CDbl(20))

                    params.Add("poid", CInt(0 * 100))
                    params.Add("arid", CInt(r("arid")))
                    params.Add("depot", CInt(r("depot")))
                    params.Add("code", "")
                    params.Add("cid", CStr(r("cid")))
                    params.Add("caisse", Form1.caisseId)

                    c.InsertRecord("DetailsFacture", params, True)
                    params.Clear()
                Next
            End If
              
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If Not IsNumeric(txt.text) Then Exit Sub
        Dim random As New Random()
        Dim vl As Integer = 0
        percentageValue = txt.text * 2 + 5

        ' Define the start and end times
        Dim startTime As TimeSpan = dt1.Value.TimeOfDay ' Start time at 08:00:00 AM
        Dim endTime As TimeSpan = dt2.Value.TimeOfDay 'New TimeSpan(18, 0, 0) ' End time at 06:00:00 PM

        ' Generate 20 random times between the start and end times
        For i As Integer = 1 To txt.text
            Dim randomTicks As Long = CLng((random.NextDouble() * (endTime.Ticks - startTime.Ticks)) + startTime.Ticks)
            Dim randomTime As TimeSpan = New TimeSpan(randomTicks)
            dte = dte.Date.Add(randomTime) ' 14:30:00
            ls_dt.Add(dte)

            Dim table As New DataTable
            ' Create four typed columns in the DataTable.
            table.Columns.Add("arid", GetType(Integer))
            table.Columns.Add("name", GetType(String))
            table.Columns.Add("unit", GetType(String))
            table.Columns.Add("price", GetType(Double))
            table.Columns.Add("bprice", GetType(Double))
            table.Columns.Add("tva", GetType(Double))
            table.Columns.Add("qte", GetType(Double))
            table.Columns.Add("unite", GetType(String))
            table.Columns.Add("total", GetType(Double))
            table.Columns.Add("cid", GetType(Integer))
            table.Columns.Add("code", GetType(String))
            table.Columns.Add("depot", GetType(Integer))
            table.Columns.Add("poid", GetType(Integer))
            table.Columns.Add("totalHt", GetType(Double))
            table.Columns.Add("totaltva", GetType(Double))
            table.Columns.Add("dsid", GetType(Double))
            table.Columns.Add("remise", GetType(Double))
            table.Columns.Add("id", GetType(Double))
            table.Columns.Add("xOrder", GetType(Integer))
            table.Columns.Add("rprice", GetType(Double))

            ls_tables.Add(table)
        Next
        ls_dt.Sort(Function(ts1, ts2) ts1.CompareTo(ts2))
        vl = 2

        Dim _data = New DataTable
        _data = Data.Copy

        For Each row As DataRow In _data.Rows
            Dim qte As Double = row("qte")

            For i As Integer = 1 To CInt(qte)
                Dim randomNumber As Integer = random.Next(0, txt.text - 1) ' Generates a random number between 1 and 20 (inclusive)
                Dim _q As Double = 1
                ls_tables(randomNumber).Rows.Add(row("arid"), row("name"), row("unit"), row("price"), row("bprice"), row("tva"), _q, row("unite"),
                                      row("price") * _q, row("cid"), row("code"), row("depot"), row("poid"), row("totalHt"), row("totaltva"),
                                      row("dsid"), row("remise"), row("id"), row("xOrder"), row("rprice"))
                row("qte") -= 1
            Next
            vl += 1
            System.Threading.Thread.Sleep(100)
            BackgroundWorker1.ReportProgress(vl, "Init..")
        Next



        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            For i As Integer = 0 To txt.text - 1
                NewFacture(i, c)
                vl += 1
                System.Threading.Thread.Sleep(300)
                BackgroundWorker1.ReportProgress(vl, "Bon N° ID : " & i)
            Next


            Dim params As New Dictionary(Of String, Object)
            params.Add("fctid", fctid)
            c.DeleteRecords("DetailsFacture", params)
            params.Clear()

            vl += 1
            System.Threading.Thread.Sleep(300)
            BackgroundWorker1.ReportProgress(vl, "Enregistrement ...")

            Dim total As Double = 0
            For Each r As DataRow In _data.Rows
                Dim qte As Double = r("qte")
                If qte > 0 Then
                    params.Add("fctid", fctid)
                    params.Add("name", r("name"))
                    params.Add("bprice", CDbl(r("bprice")))
                    params.Add("price", r("price"))
                    params.Add("unit", r("unite"))
                    params.Add("qte", r("qte"))

                    params.Add("tva", CDbl(20))

                    params.Add("poid", CInt(0 * 100))
                    params.Add("arid", CInt(r("arid")))
                    params.Add("depot", CInt(r("depot")))
                    params.Add("code", "")
                    params.Add("cid", CStr(r("cid")))
                    params.Add("caisse", Form1.caisseId)

                    c.InsertRecord("DetailsFacture", params, True)
                    params.Clear()
                    total += qte * r("price")
                End If
            Next

            vl += 1
            System.Threading.Thread.Sleep(300)
            BackgroundWorker1.ReportProgress(vl, "Nett ...")

            Dim where As New Dictionary(Of String, Object)
            where.Add("fctid", fctid)
            params.Add("total", total)
            params.Add("avance", total)
            params.Add("admin", True)
            params.Add("payed", True)
            c.UpdateRecord("facture", params, where)
        End Using

        vl += 1
        System.Threading.Thread.Sleep(300)
        BackgroundWorker1.ReportProgress(vl, "Validation ...")

        MsgBox("Opération réussite")

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Dim v As Integer = e.ProgressPercentage * 100 / percentageValue
        pb.Value = v

        lb.Text = "[" & v.ToString() & "%]  -  " & e.UserState.ToString()

    End Sub
End Class