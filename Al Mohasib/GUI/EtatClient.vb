Public Class EtatClient
    Dim _cid As Integer
    Private factureTable As String = "Sell_Facture"
    Private bonTable As String = "Bon_Livraison"
    Private PayementTable As String = "Client_Payement"

    Dim ClientTable As String

    Public Property isSell As String
        Get
            Return factureTable = "Facture"
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

            Dim ttBon As Double = 0
            Dim ttAvc As Double = 0


            If isSell Then
                order.Add("fctid", "Asc")
            Else
                order.Add("bonid", "Asc")
            End If


            'get last impayed facture date
            Dim dt = a.SelectDataTable(factureTable, {"*"}, params, order)
            If dt.Rows.Count > 0 Then
                dte = DteValue(dt, "date", 0)
            End If

            Dim ls As New List(Of Integer)

            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dte > DteValue(dt, "date", i) Then dte = DteValue(dt, "date", i)

                    DataGridView1.Rows.Add(DteValue(dt, "date", i), dt.Rows(i).Item(0), "Bon",
                                           CDec(DblValue(dt, "total", i)).ToString(Form1.frmDbl), "Bon")

                    RestFact += DblValue(dt, "total", i) - DblValue(dt, "avance", i)


                    ttBon += DblValue(dt, "total", i)
                    ls.Add(IntValue(dt, "fctid", i))
                Next
            End If

            params.Clear()

            dte = dte.AddDays(-10)
            params.Add("date >=", dte)

            params.Add("cid = ", CID)

            dt = a.SelectDataTableSymbols(PayementTable, {"*"}, params)
            If Not IsNothing(dt) Then
                If dt.Rows.Count > 0 Then
                    Dim fctid_str = "fctid"
                    If isSell = False Then fctid_str = "bonid"

                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim fctId As Integer = IntValue(dt, "fctid", i)
                        If ls.Contains(fctId) = False Then
                            params.Clear()
                            params.Add(fctid_str, fctId)
                            Dim dtff = a.SelectDataTable(factureTable, {"*"}, params)
                            If dtff.Rows.Count > 0 Then
                                DataGridView1.Rows.Add(DteValue(dtff, "date", 0), IntValue(dtff, fctid_str, 0), "Bon *",
                                        CDec(DblValue(dtff, "total", 0)).ToString(Form1.frmDbl), "Bon *")

                                ttBon += DblValue(dtff, "total", 0)
                            End If
                            ls.Add(fctId)
                        End If

                        If StrValue(dt, "name", i).StartsWith("@") Then Continue For

                        DataGridView1.Rows.Add(DteValue(dt, "date", i), IntValue(dt, fctid_str, i), StrValue(dt, "way", i),
                                              CDec(DblValue(dt, "montant", i) * -1).ToString(Form1.frmDbl), "Avance")

                        ttAvc += DblValue(dt, "montant", i)
                    Next
                End If
            End If

            lbrestFact.Text = RestFact.ToString(Form1.frmDbl)
            lbRest.Text = CDec(RestBon + RestFact).ToString(Form1.frmDbl)


            Dim enc As Double = ttBon - ttAvc

            DataGridView2.Rows.Add(Now.Date.ToString("dd/MM/yyyy"), "", "REST", RestFact.ToString(Form1.frmDbl))
            If enc > 0 Then DataGridView2.Rows.Add(dte.AddDays(-1).ToString("dd/MM/yyyy"), "", "Ancien Crédit", enc.ToString(Form1.frmDbl), "Ancien Crédit")

            params.Clear()

            If isSell Then
                params.Add("Clid", CID)
            Else
                params.Add("compid", CID)
            End If


            Client = a.SelectByScalar(ClientTable, "name", params)

            'DataGridView1.Columns(0).SortMode = DataGridViewColumnSortMode.Automatic
            DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Try
                For I As Integer = 0 To DataGridView1.Rows.Count - 1
                    If DataGridView1.Rows(I).Cells(4).Value.ToString = "Avance" Then
                        DataGridView1.Rows(I).DefaultCellStyle.BackColor = Color.Honeydew
                    ElseIf DataGridView1.Rows(I).Cells(4).Value.ToString = "Ancien Crédit" Then
                        DataGridView1.Rows(I).DefaultCellStyle.BackColor = Color.Honeydew
                        DataGridView1.Rows(I).DefaultCellStyle.ForeColor = Color.Yellow
                    End If

                    If DataGridView1.Rows(I).Cells(2).Value.ToString = "BON DE RETOUR" Then
                        DataGridView1.Rows(I).DefaultCellStyle.BackColor = Color.LavenderBlush
                        DataGridView1.Rows(I).DefaultCellStyle.ForeColor = Color.Red

                    End If

                Next
            Catch ex As Exception

            End Try




        End Using
    End Sub

    Private Sub btPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPrint.Click

        Try
            DataGridView1.Rows.Add(DataGridView2.Rows(0).Cells(0).Value,
                                         DataGridView2.Rows(0).Cells(1).Value,
                                         DataGridView2.Rows(0).Cells(2).Value,
                                         DataGridView2.Rows(0).Cells(3).Value)
        Catch ex As Exception
        End Try




        Dim str As String = "Relve Client " & lbClient.Text
        str &= Now.Date.ToString(" dd-MM-yyyy")

        str = str.Replace("/", " ")
        str = str.Replace("|", " ")

        ' SaveDataToHtml(DataGridView1, str)

        SaveDataToHtml2(DataGridView1, str)

        Try
            If DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(2).Value.ToString = "REST" Then
                DataGridView1.Rows.Remove(DataGridView1.Rows(DataGridView1.Rows.Count - 1))
            End If
        Catch ex As Exception
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