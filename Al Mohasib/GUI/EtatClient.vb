Public Class EtatClient
    Dim _cid As Integer
    Private factureTable As String = "Sell_Facture"
    Private bonTable As String = "Bon_Livraison"
    Private PayementTable As String = "Client_Payement"

    Dim ClientTable As String

    Public Property isSell As String
        Get
            Return True
        End Get
        Set(ByVal value As String)
         
            If value Then
                factureTable = "Facture"
                PayementTable = "Payment"
                ClientTable = "Client"
            Else
                factureTable = "Bon"
                ClientTable = "company"
                PayementTable = "CompanyPayment"
            End If
        End Set
    End Property
    Public Property Client As String
        Get
            Return lbClient.Text
        End Get
        Set(ByVal value As String)
            lbClient.Text = value
        End Set
    End Property
    Public Property CID As Integer
        Get
            Return _cid
        End Get
        Set(ByVal value As Integer)
            _cid = value

            If value = 0 Then Exit Property
            getDetails()
        End Set
    End Property

    Private Sub getDetails()

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim order As New Dictionary(Of String, String)

            params.Add("clid", CID)
            params.Add("payed", False)

            Dim dte As Date = Now.Date.AddDays(-40)
            Dim RestFact As Double = 0
            Dim RestBon As Double = 0


            order.Add("fctid", "Asc")

            'get last impayed facture date
            Dim dt = a.SelectDataTable(factureTable, {"*"}, params, order)
            If dt.Rows.Count > 0 Then
                dte = DteValue(dt, "date", 0)
            End If


            params.Clear()
            dte = dte.AddDays(-10)
            params.Add("clid = ", CID)
            params.Add("date >", dte)

            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    DataGridView1.Rows.Add(DteValue(dt, "date", i), "Bon",
                                           String.Format("{0:n}", CDec(DblValue(dt, "total", i))),
                                            "", IntValue(dt, "fctid", i))
                    RestFact += DblValue(dt, "total", i) - DblValue(dt, "avance", i)
                Next
            End If

            params.Clear()

            'dte = dte.AddDays(-7)
            params.Add("clid = ", CID)
            params.Add("date >", dte)

            dt = a.SelectDataTableSymbols(PayementTable, {"*"}, params)
            If Not IsNothing(dt) Then
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        If dte > DteValue(dt, "date", i) Then dte = DteValue(dt, "date", i)
                        DataGridView1.Rows.Add(DteValue(dt, "date", i), "Reglement", "",
                                               String.Format("{0:n}", CDec(DblValue(dt, "montant", i))),
                                               IntValue(dt, "fctid", i))
                    Next
                End If
            End If

            lbrestFact.Text = String.Format("{0:n}", CDec(RestFact)) & " Dhs"

            lbRest.Text = String.Format("{0:n}", CDec(RestBon + RestFact)) & " Dhs"


            params.Clear()
            params.Add("Clid", CID)
            Client = a.SelectByScalar(ClientTable, "name", params)

            'DataGridView1.Columns(0).SortMode = DataGridViewColumnSortMode.Automatic
            DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

            For I As Integer = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Rows(I).Cells(3).Value.ToString <> "" Then
                    DataGridView1.Rows(I).DefaultCellStyle.BackColor = Color.Honeydew
                End If
            Next



        End Using
    End Sub

    Private Sub btPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPrint.Click


        Try
            PrintDoc.PrinterSettings.PrinterName = Form1.txttimp.Text
            PrintDoc.Print()

        Catch ex As Exception
            Dim PrintDlg As New PrintDialog

            If PrintDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintDoc.PrinterSettings.PrinterName = PrintDlg.PrinterSettings.PrinterName
                PrintDoc.Print()
            End If
        End Try


    End Sub
    Dim m As Integer = 0
    Private Sub PrintDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage
        Try
            Using a As DrawClass = New DrawClass
                Dim dte As String = Format(Date.Now, "dd-MM-yyyy [hh:mm]")

                a.DrawRelve(e, DataGridView1, Client, False, "", lbrestFact.Text, lbRest.Text, m)

            End Using
        Catch ex As Exception
            m = 0
        End Try
    End Sub


End Class