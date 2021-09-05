Imports System.Drawing.Printing

Public Class ClientRapport

    Public dt_Bon As New DataTable
    Public dt_Details As New DataTable
    Public arid As Integer

    Dim tb_F As String = "Facture"
    Dim tb_D As String = "DetailsFacture"
    Dim tb_C As String = "Client"
    Dim ClId As Integer
    Dim ClientName As String

    Private Sub ClientRapport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dte1.Value = Now.Date.AddMonths(-2)

        Using a As SubClass = New SubClass(1)
            a.AutoCompleteArticles(txt, tb_C)
        End Using
    End Sub

    Private Sub Trace_Search()

        dt_Details.Rows.Clear()
        dt_Bon.Rows.Clear()

        If txt.text.Contains("|") = False Then
            Dim chs As New ChoseClient
            chs.isSell = True
            If chs.ShowDialog = Windows.Forms.DialogResult.OK Then
                txt.text = chs.clientName & "|" & chs.cid
            End If
        End If

        Dim str As String = txt.text.Trim
        str = str.Split(CChar("|"))(1)

        ClId = CInt(str)
        ClientName = str.Split(CChar("|"))(0)

        Dim params As New Dictionary(Of String, Object)
        Dim dt As DataTable = Nothing
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            params.Add("clid", clid)
            params.Add("admin", True)
            params.Add("payed", False)
            dt_Bon = a.SelectDataTable(tb_F, {"*"}, params)

            If dt_Bon.Rows.Count Then

                If cbDt.Checked Then
                    filtreTheDetails()
                Else
                    filtreTheData()
                End If

                For i As Integer = 0 To dt_Bon.Rows.Count - 1
                    params.Clear()
                    params.Add("fctid", dt_Bon.Rows(i).Item(0))
                    dt = a.SelectDataTable(tb_D, {"*"}, params)

                    If dt.Rows.Count Then
                        If dt_Details.Rows.Count = 0 Then
                            dt_Details = dt
                        Else
                            dt_Details.Merge(dt)
                        End If
                    End If
                Next
            End If
        End Using



    End Sub
    Private Sub filtreTheData()

        dg_D.DataSource = Nothing
        dg_D.DataSource = dt_Bon


        dg_D.Columns(1).Visible = False
        'dg_D.Columns(2).Visible = False
        dg_D.Columns(6).Visible = False
        ' dg_D.Columns(7).Visible = False
        dg_D.Columns(8).Visible = False
        dg_D.Columns(9).Visible = False
        dg_D.Columns(10).Visible = False

        dg_D.Columns(11).Visible = False
        dg_D.Columns(12).Visible = False
        dg_D.Columns(13).Visible = False
        dg_D.Columns(14).Visible = False
        dg_D.Columns(15).Visible = False
        dg_D.Columns(16).Visible = False

        dg_D.Columns(0).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
        '' dg_D.Columns(14).DefaultCellStyle.ForeColor = Form1.Color_Default_Text
        dg_D.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None

        Try

            dg_D.Columns(0).HeaderText = "ID"
            dg_D.Columns(2).HeaderText = "Libelle"
            dg_D.Columns(3).HeaderText = "Total"

            dg_D.Columns(4).HeaderText = "Avance"
            dg_D.Columns(5).HeaderText = "Date"
            dg_D.Columns(7).HeaderText = "Editeur"

            dg_D.Columns(5).DisplayIndex = 1

        Catch ex As Exception

        End Try


        Dim sum As Double
        Try
            sum = Convert.ToDouble(dt_Bon.Compute("SUM(total)", String.Empty))
            lbTotal.Text = sum.ToString(Form1.frmDbl)
        Catch ex As Exception
            Dim t As Double = 0
            For i As Integer = 0 To dt_Bon.Rows.Count - 1
                Try
                    t += dt_Bon.Rows(i).Item("total")
                Catch x As Exception
                End Try
            Next

            lbTotal.Text = t.ToString(Form1.frmDbl)
        End Try

        Try
            sum = Convert.ToDouble(dt_Bon.Compute("SUM(avance)", String.Empty))
            lbAvc.Text = sum.ToString(Form1.frmDbl)
        Catch ex As Exception
            lbAvc.Text = "... "
        End Try

        lbLnbr.Text = dg_D.Rows.Count & " Lines"

    End Sub
    Private Sub filtreTheDetails()

        'RPL.ClearItems()

        'If dt_Details.Rows.Count = 0 Then Exit Sub

        'Form1.RPl.AddItems(dt_Details, True)


        ''dg_D.DataSource = Nothing


        ''dg_D.DataSource = dt_Details

        ' ''Arid = row.Field(Of Int32)("arid") Into MonthGroup = Group


        ''dg_D.Columns(0).Visible = False
        ''dg_D.Columns(3).Visible = False
        ''dg_D.Columns(5).Visible = False
        ''dg_D.Columns(7).Visible = False
        ''dg_D.Columns(8).Visible = False
        ' ''dg_D.Columns(9).Visible = False
        ''dg_D.Columns(10).Visible = False
        ''dg_D.Columns(11).Visible = False
        ''dg_D.Columns(12).Visible = False

        ''dg_D.Columns(2).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
        ''dg_D.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None

        ''Try

        ''    'dg_D.Columns(1).HeaderText = "ID"
        ''    'dg_D.Columns(2).HeaderText = "Designation"
        ''    'dg_D.Columns(4).HeaderText = "Prix U"

        ''    'dg_D.Columns(6).HeaderText = "Qte"
        ''    'dg_D.Columns(9).HeaderText = "Ref"


        ''Catch ex As Exception

        ''End Try


        ''Try

        ''Catch ex As Exception
        ''End Try


        Dim groups = (From dr In dt_Details
                 Group By x = New With {Key .arid = dr("arid"), Key .price = dr("price"), Key .Name = dr("name")} Into g = Group
                 Select New With {
                     .Qté = g.Sum(Function(r) r("qte")),
                     .Desgnation = x.Name,
                     .prix = x.price,
                  .Count = g.Count()
                 }).ToList()

        dg_D.DataSource = Nothing


        dg_D.DataSource = groups
        lbLnbr.Text = dg_D.Rows.Count & " Lines"

    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            Trace_Search()


        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txt.text = txt.text.Trim
    End Sub

    Private Sub cbDt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDt.CheckedChanged

        '   Dim groups =
        'From j In dt_Details
        'Group By x = New With {Key .arid = j("arid"), Key .price = j("price")} Into g = Group
        'Select New With {
        '    .var1 = x.arid,
        '   .var2 = x.price,
        '    .quantity = g.Sum(Function(r) r("qty")),
        '   .count = g.Count()
        '}

      

        If cbDt.Checked Then
            filtreTheDetails()
        Else
            filtreTheData()
        End If
    End Sub

    Private Sub cbMerge_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cbDt.Checked Then
            filtreTheDetails()
        End If
    End Sub
    'print button
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        If dg_D.Rows.Count = 0 Then Exit Sub

        If cbDt.Checked Then
            printDetails()
        Else

            Try
                dg_D.Rows.Add("***", "", "Total", lbTotal.Text, lbAvc.Text, "**", "", "")

            Catch ex As Exception
            End Try



            Dim str = "Etat du : " & txt.text.Split("|")(0)
            str = str.Replace("|", " ")
            str = str.Replace(":", " ")
            str = str.Replace("/", " ")

            SaveDataToHtml(dg_D, str)


            Try
                filtreTheData()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub printDetails()

        Dim nbr As Integer = Form1.txtNbrCopie.Text
        Dim nm As String = Form1.txttimp.Text

        Try

            Dim dl As New PrintDialog
            If dl.ShowDialog = Windows.Forms.DialogResult.OK Then
                nm = dl.PrinterSettings.PrinterName
                nbr = dl.PrinterSettings.Copies
            Else
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Form1.MP_Localname = "Commule.dat"
        Dim g As New gGlobClass

        g = ReadFromXmlFile(Of gGlobClass)(Form1.ImgPah & "\Prt_Dsn\" & Form1.MP_Localname)
        Dim ps As New PaperSize(g.P_name, g.W_Page, g.h_Page)
        ps.PaperName = g.p_Kind
        PrintDocDesign.DefaultPageSettings.PaperSize = ps
        PrintDocDesign.DefaultPageSettings.Landscape = g.is_Landscape

        PrintDocDesign.PrinterSettings.PrinterName = nm


        For i = 0 To nbr - 1
            PrintDocDesign.Print()
        Next


    End Sub
    Dim M As Integer = 0
    Private Sub PrintDocDesign_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocDesign.PrintPage
        Try

            Dim dte As String = Format(Date.Now, "dd-MM-yyyy [HH:mm]")

            Dim data As New DataTable
            ' Create four typed columns in the DataTable.
            data.Columns.Add("id", GetType(String))
            data.Columns.Add("date", GetType(String))
            data.Columns.Add("cid", GetType(String))
            data.Columns.Add("name", GetType(String))
            data.Columns.Add("total_ht", GetType(String))
            data.Columns.Add("total_tva", GetType(String))
            data.Columns.Add("total_ttc", GetType(String))
            data.Columns.Add("total_remise", GetType(String))
            data.Columns.Add("total_avance", GetType(String))
            data.Columns.Add("total_droitTimbre", GetType(String))
            data.Columns.Add("MPayement", GetType(String))
            data.Columns.Add("Editeur", GetType(String))
            data.Columns.Add("vidal", GetType(String))
            data.Columns.Add("livreur", GetType(String))
            data.Columns.Add("rest_ttc", GetType(String))
            data.Columns.Add("x_total_ttc_sn_remise", GetType(String))
            data.Columns.Add("RealAvance", GetType(String))
            data.Columns.Add("RealRest", GetType(String))
            data.Columns.Add("Rest", GetType(String))
            data.Columns.Add("caisseAvance", GetType(String))
            data.Columns.Add("caisseRest", GetType(String))



            Dim table As New DataTable

            ' Create four typed columns in the DataTable.
            table.Columns.Add("arid", GetType(Integer))
            table.Columns.Add("name", GetType(String))
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

            For i As Integer = 0 To dg_D.Rows.Count - 1
                ' Add  rows with those columns filled in the DataTable.
                table.Rows.Add(0, dg_D.Rows(i).Cells(1).Value, dg_D.Rows(i).Cells(2).Value, 0, 0,
                               dg_D.Rows(i).Cells(0).Value, "",
                              dg_D.Rows(i).Cells(0).Value * dg_D.Rows(i).Cells(2).Value, 0, dg_D.Rows(i).Cells(1).Value,
                               0, 0, 0, 0, 0, 0, 0)
            Next




            Dim realAvc As Double = lbAvc.Text
            Dim __rest As Double = CDbl(lbTotal.Text - lbAvc.Text)
            Dim __RRest As Double = __rest
            Dim caisseRest As Double = __rest

            'x_total_ttc_sn_remise
            data.Rows.Add(0, dte, ClId, ClientName, lbTotal.Text, 0, lbTotal.Text, String.Format("{0:n2}", 0),
                          lbAvc.Text, String.Format("{0:n2}", 0), "Cache", Form1.adminName, dg_D.Rows.Count, 0,
                          String.Format("{0:n2}", __rest), lbTotal.Text, realAvc.ToString(Form1.frmDbl),
                           __RRest.ToString(Form1.frmDbl), __rest.ToString(Form1.frmDbl), 0, caisseRest.ToString(Form1.frmDbl))

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

            Dim credit As Double = __rest
            Dim EncCreadit As Double = 0

            Dim ClientAdresse As String = dt_Bon.Rows(0).Item("adresse").ToString
            Dim tel As String = ""
            Dim adresse = ClientAdresse.Split("*")(0)
            Dim client_ville As String = ""
            Dim client_ice As String = ""

            Try
                client_ville = ClientAdresse.Split("*")(1)
            Catch ex As Exception
                client_ville = "-"
            End Try

            Try
                client_ice = ClientAdresse.Split("*")(2)
            Catch ex As Exception
                client_ice = "-"
            End Try




            ' Add  rows with those columns filled in the DataTable.
            dt_Client.Rows.Add(ClId, ClientName, ClId, client_ville,
                                adresse, client_ice, tel, credit.ToString(Form1.frmDbl), EncCreadit.ToString(Form1.frmDbl), EncCreadit.ToString(Form1.frmDbl))

            Using g As gDrawClass = New gDrawClass(Form1.MP_Localname)
                g.rtl = Form1.cbRTL.Checked

                g.DrawBl(e, data, table, dt_Client, Form1.Facture_Title, False, M)
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btInfo.Click
        Dim chs As New ChoseClient
        chs.isSell = True
        If chs.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt.text = chs.clientName & "|" & chs.cid
        End If
    End Sub
End Class