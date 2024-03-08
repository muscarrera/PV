Imports System.Drawing.Printing

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
     
    Public ReadOnly Property Details_imp_Source As DataTable
        Get
            Dim table As New DataTable
            ' Create four typed columns in the DataTable.
            table.Columns.Add("arid", GetType(Integer))
            table.Columns.Add("name", GetType(String))
            table.Columns.Add("unit", GetType(String))
            table.Columns.Add("cid", GetType(Integer))
            table.Columns.Add("qte", GetType(Double))
            table.Columns.Add("price", GetType(Double))
            table.Columns.Add("bprice", GetType(Double))
            table.Columns.Add("tva", GetType(Double))
            table.Columns.Add("code", GetType(String))
            table.Columns.Add("depot", GetType(Integer))
            table.Columns.Add("remise", GetType(Integer))
            table.Columns.Add("bl", GetType(Integer))
            table.Columns.Add("totaltva", GetType(Double))

            table.Columns.Add("rprice", GetType(Double))
            table.Columns.Add("freeQte", GetType(Double))
            table.Columns.Add("qteStr", GetType(String))


            For i As Integer = 0 To DataGridView1.RowCount - 1
                table.Rows.Add(DataGridView1.Rows(i).Cells(1).Value, DataGridView1.Rows(i).Cells(2).Value,
                               DataGridView1.Rows(i).Cells(4).Value, i, 1, DataGridView1.Rows(i).Cells(3).Value, DataGridView1.Rows(i).Cells(3).Value, 0,
                               DataGridView1.Rows(i).Cells(0).Value, DataGridView1.Rows(i).Cells(1).Value, 0, 0, 0, 0, 0, "")
            Next
         
            Return table
        End Get
    End Property
    Public ReadOnly Property Client_imp_Source As DataTable
        Get
            Dim table As New DataTable
            ' Create four typed columns in the DataTable.
            table.Columns.Add("Clid", GetType(Integer))
            table.Columns.Add("name", GetType(String))
            table.Columns.Add("ref", GetType(String))
            table.Columns.Add("ville", GetType(String))
            table.Columns.Add("adresse", GetType(String))
            table.Columns.Add("ice", GetType(String))
            table.Columns.Add("tel", GetType(String))
            table.Columns.Add("NvCredit", GetType(String))
            table.Columns.Add("EncCredit", GetType(String))
            table.Columns.Add("RealEncCredit", GetType(String))


            ' Add  rows with those columns filled in the DataTable.
            table.Rows.Add(1, "Mohamed", "md123", "AGADIR", "Av 01, Lot 2, Imm 3, hay Dakhla", "1234567890",
                           "05282828283", "123", "23", "23")

            Return table
        End Get
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
    Private Sub btPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

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
        'Try
        '    Using a As DrawClass = New DrawClass
        '        Dim dte As String = Format(Date.Now, "dd-MM-yyyy [hh:mm]")

        '        a.DrawRelve(e, DataGridView1, Client, False, "", lbrestFact.Text, lbRest.Text, m)

        '    End Using
        'Catch ex As Exception
        '    m = 0
        'End Try

        Dim table As New DataTable
        Try

            ' Create four typed columns in the DataTable.
            table.Columns.Add("id", GetType(String))
            table.Columns.Add("date", GetType(String))
            table.Columns.Add("cid", GetType(String))
            table.Columns.Add("name", GetType(String))
            table.Columns.Add("total_ht", GetType(String))
            table.Columns.Add("total_tva", GetType(String))
            table.Columns.Add("total_ttc", GetType(String))
            table.Columns.Add("total_remise", GetType(String))
            table.Columns.Add("total_avance", GetType(String))
            table.Columns.Add("total_droitTimbre", GetType(String))
            table.Columns.Add("MPayement", GetType(String))
            table.Columns.Add("Editeur", GetType(String))
            table.Columns.Add("vidal", GetType(String))
            table.Columns.Add("livreur", GetType(String))
            table.Columns.Add("rest_ttc", GetType(String))
            table.Columns.Add("x_total_ttc_sn_remise", GetType(String))
            table.Columns.Add("RealAvance", GetType(String))
            table.Columns.Add("RealRest", GetType(String))
            table.Columns.Add("Rest", GetType(String))
            table.Columns.Add("caisseAvance", GetType(String))
            table.Columns.Add("caisseRest", GetType(String))
            table.Columns.Add("Points_NV", GetType(String))
            table.Columns.Add("Points_ENC", GetType(String))
            table.Columns.Add("Points_TL", GetType(String))
            table.Columns.Add("Points_UT", GetType(String))
            table.Columns.Add("Points_RS", GetType(String))
            table.Columns.Add("PC_Nom", GetType(String))
            table.Columns.Add("PC_Tel", GetType(String))
            table.Columns.Add("PC_Adr", GetType(String))
            table.Columns.Add("poid", GetType(String))
            table.Columns.Add("bc", GetType(String))
            table.Columns.Add("bl", GetType(String))
            table.Columns.Add("Pouchet", GetType(String))
            table.Rows.Add(0, Now.Date, CID, Client, lbRest.Text,
                        lbRest.Text, lbRest.Text, "0",
                             "0", "0", "", Form1.adminName, DataGridView1.RowCount, "", lbRest.Text, lbRest.Text, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "nom", "tel", "adrs", 12, 0, 0, 0)
        Catch ex As Exception

        End Try



        Try
            Dim dt_Client As New DataTable
            ' Create four typed columns in the DataTable.
            dt_Client.Columns.Add("Clid", GetType(Integer))
            dt_Client.Columns.Add("name", GetType(String))
            dt_Client.Columns.Add("ref", GetType(String))
            dt_Client.Columns.Add("ville", GetType(String))
            dt_Client.Columns.Add("adresse", GetType(String))
            dt_Client.Columns.Add("ice", GetType(String))
            dt_Client.Columns.Add("tel", GetType(String))
            dt_Client.Columns.Add("NvCredit", GetType(String))
            dt_Client.Columns.Add("EncCredit", GetType(String))
            dt_Client.Columns.Add("RealEncCredit", GetType(String))

            Dim credit As Double = 0
            Dim EncCreadit As Double = 0
            Dim tel As String = ""
            Dim adresse = ""
            Dim client_ville As String = ""
            Dim client_ice As String = ""
 


            If CID > 0 Then
                If isSell Then
                    Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                        Dim params As New Dictionary(Of String, Object)
                        params.Add("payed", False)
                        params.Add("Clid", CID)
                        params.Add("admin", True)
                        Try
                            EncCreadit = c.SelectByScalar("Facture", "SUM(total - avance) AS credit", params)
                        Catch ex As Exception
                            EncCreadit = 0
                        End Try


                        params.Clear()

                        Try
                            params.Add("Clid", CID)
                            tel = c.SelectByScalar("Client", "tel", params)
                        Catch ex As Exception

                        End Try

                    End Using
                     
                        credit = EncCreadit
                        
                Else


                    Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                        Dim params As New Dictionary(Of String, Object)
                        params.Add("payed", False)
                        params.Add("Clid", CID)
                        params.Add("admin", True)
                        Try
                            EncCreadit = c.SelectByScalar("Bon", "SUM(total - avance) AS credit", params)
                        Catch ex As Exception
                            EncCreadit = 0
                        End Try

                    End Using


                     
                        credit = EncCreadit
                         
                End If
            End If

            ' Add  rows with those columns filled in the DataTable.
            dt_Client.Rows.Add(CID, Client, CID, client_ville,
                            adresse, client_ice, tel, credit.ToString(Form1.frmDbl), EncCreadit.ToString(Form1.frmDbl), EncCreadit.ToString(Form1.frmDbl))

            Using g As gDrawClass = New gDrawClass(MP_Localname)
                g.rtl = Form1.cbRTL.Checked
                g.DrawBl(e, table, Details_imp_Source, dt_Client, "Etat Client", False, m, New Dictionary(Of Double, Double))
            End Using

        Catch ex As Exception

        End Try


    End Sub

    Dim MP_Localname = "Etat-Client.dat"
    Private Sub btPrint_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPrint.Click

        Try

            Dim nm As String = ""
            Dim dl As New PrintDialog
            If dl.ShowDialog = Windows.Forms.DialogResult.OK Then
                nm = dl.PrinterSettings.PrinterName
            Else
                Exit Sub
            End If

            MP_Localname = "Etat-Client.dat"
            Dim g As New gGlobClass
            g = ReadFromXmlFile(Of gGlobClass)(Form1.ImgPah & "\Prt_Dsn\" & MP_Localname)

            If g.TabProp.Type.ToUpper.StartsWith("TAB") Then
                Dim ps As New PaperSize(g.P_name, g.W_Page, g.h_Page)
                ps.PaperName = g.p_Kind
                PrintDoc.DefaultPageSettings.PaperSize = ps
                PrintDoc.DefaultPageSettings.Landscape = g.is_Landscape
            End If


            PrintDoc.PrinterSettings.PrinterName = nm

            PrintDoc.Print()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub EtatClient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class