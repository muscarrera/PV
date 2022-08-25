Imports System.IO

Public Class ProfitProduitRapport


    Public dt_in As New DataTable
    Public dt_OUT As New DataTable
    Public dt_Art As New DataTable
    Public dt_Pr As New DataTable
    Public myRapport As New RpClass


    Dim STR_TITLE As String = ""
    Dim code_str As String

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim op As New OpenFileDialog
        op.InitialDirectory = ThePath

        If op.ShowDialog = Windows.Forms.DialogResult.OK Then

            FileName = op.FileName
            txtRP.text = ""
            plTxt.Enabled = False

            myRapport = ReadFromXmlFile(Of RpClass)(FileName)
            FileName = myRapport.name
            txtRP.text = myRapport.name
            dt_in = myRapport.dt_in
            dt_OUT = myRapport.dt_OUT
            dt_Art = myRapport.dt_Art
            dt_Pr = myRapport.dt_Pr
        End If

    End Sub

    Private Sub filtreTheData_RapportDala3()

        Dim dt As New DataTable

        dt.Columns.Add("N", GetType(Integer))
        dt.Columns.Add("Designation", GetType(String))
        dt.Columns.Add("Nbr_Oprt", GetType(String))
        dt.Columns.Add("Prix_Min", GetType(String))
        dt.Columns.Add("Prix_Max", GetType(String))
        dt.Columns.Add("Qte", GetType(String))
        dt.Columns.Add("Total_Vente", GetType(String))
        dt.Columns.Add("Total_Achat", GetType(String))
        dt.Columns.Add("Profit", GetType(String))

        Dim MAX As Decimal = 0
        Dim MIN As Decimal = 0
        Dim QTE As Decimal = 0
        Dim TT As Decimal = 0
        Dim nb As Integer = 0
        Dim TA As Decimal = 0

        Dim T_TT_IN As Decimal = 0
        Dim T_nb_IN As Integer = 0

        Dim T_TT_OUT As Decimal = 0
        Dim T_nb_OUT As Integer = 0
        Dim T_TA_OUT As Integer = 0

        dt.Rows.Add(10, "ACHATS")
        dt.Rows.Add(20, "VENTE")
        'dt.Rows.Add(30, "STOCK")
        dt.Rows.Add(30, "OPERATION")
        dt.Rows.Add(90, "RESULTAT")

        For i As Integer = 0 To dt_Art.Rows.Count - 1
            MAX = 0
            MIN = 0
            QTE = 0
            TT = 0
            TA = 0
            nb = 0

            Try
                'achat
                MAX = dt_in.AsEnumerable().Where(Function(x) x.Field(Of Integer)("arid") = dt_Art.Rows(i).Item(0)).Select(Function(x) x.Field(Of Decimal)("Prix")).Max()
                MIN = dt_in.AsEnumerable().Where(Function(x) x.Field(Of Integer)("arid") = dt_Art.Rows(i).Item(0)).Select(Function(x) x.Field(Of Decimal)("Prix")).Min()
                QTE = dt_in.AsEnumerable().Where(Function(x) x.Field(Of Integer)("arid") = dt_Art.Rows(i).Item(0)).Select(Function(x) x.Field(Of Decimal)("Qte")).Sum()
                TT = dt_in.AsEnumerable().Where(Function(x) x.Field(Of Integer)("arid") = dt_Art.Rows(i).Item(0)).Select(Function(x) x.Field(Of Decimal)("Total")).Sum()
                nb = dt_in.AsEnumerable().Where(Function(x) x.Field(Of Integer)("arid") = dt_Art.Rows(i).Item(0)).Select(Function(x) x.Field(Of Integer)("arid")).Count()

                T_nb_IN += nb
                T_TT_IN += TT

                dt.Rows.Add(11, dt_Art.Rows(i).Item("name"), nb, MIN.ToString("N2"), MAX.ToString("N2"), QTE, "", TT.ToString("N2"))
            Catch ex As Exception
            End Try

            MAX = 0
            MIN = 0
            QTE = 0
            TT = 0
            TA = 0
            nb = 0



            Try
                'vente
                MAX = dt_OUT.AsEnumerable().Where(Function(x) x.Field(Of Integer)("arid") = dt_Art.Rows(i).Item(0)).Select(Function(x) x.Field(Of Decimal)("Prix")).Max()
                MIN = dt_OUT.AsEnumerable().Where(Function(x) x.Field(Of Integer)("arid") = dt_Art.Rows(i).Item(0)).Select(Function(x) x.Field(Of Decimal)("Prix")).Min()
                QTE = dt_OUT.AsEnumerable().Where(Function(x) x.Field(Of Integer)("arid") = dt_Art.Rows(i).Item(0)).Select(Function(x) x.Field(Of Decimal)("Qte")).Sum()
                TT = dt_OUT.AsEnumerable().Where(Function(x) x.Field(Of Integer)("arid") = dt_Art.Rows(i).Item(0)).Select(Function(x) x.Field(Of Decimal)("Total")).Sum()
                nb = dt_OUT.AsEnumerable().Where(Function(x) x.Field(Of Integer)("arid") = dt_Art.Rows(i).Item(0)).Select(Function(x) x.Field(Of Integer)("arid")).Count()
                TA = dt_OUT.AsEnumerable().Where(Function(x) x.Field(Of Integer)("arid") = dt_Art.Rows(i).Item(0)).Select(Function(x) x.Field(Of Decimal)("Total_Achat")).Sum()


                T_nb_OUT += nb
                T_TT_OUT += TT
                T_TA_OUT += TA
                dt.Rows.Add(21, dt_Art.Rows(i).Item("name"), nb, MIN.ToString("N2"), MAX.ToString("N2"), QTE, TT.ToString("N2"), TA.ToString("N2"), (TT - TA).ToString("N2"))
            Catch ex As Exception
            End Try


        Next
         
        dt.Rows.Add(12, "Total", T_nb_IN, "", "", "", "", T_TT_IN)
        dt.Rows.Add(22, "Total", T_nb_OUT, "", "", "", T_TT_OUT.ToString("N2"), T_TA_OUT.ToString("N2"), (T_TT_OUT - T_TA_OUT).ToString("N2"))

        Dim T_P_C As Double = 0
        For I As Integer = 0 To dt_Pr.Rows.Count - 1
            dt.Rows.Add(31 + dt_Pr.Rows(I).Item(0), dt_Pr.Rows(I).Item(2), "", dt_Pr.Rows(I).Item(5), "", "", "", "", dt_Pr.Rows(I).Item(3))
            T_P_C += dt_Pr.Rows(I).Item(3)
        Next

        dt.Rows.Add(91, "Profits des ventes", "", "", "", "", "", "", (TT - TA).ToString("N2"))
        dt.Rows.Add(92, "Total cadeaux", "", "", "", "", "", "", T_P_C.ToString("N2"))
        dt.Rows.Add(93, "Resultat Final", "", "", "", "", "", "", (TT - TA + T_P_C).ToString("N2"))





        dg_D.DataSource = Nothing
        dg_D.DataSource = dt

        dg_D.Sort(dg_D.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
        dg_D.Columns(1).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)

        dg_D.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dg_D.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dg_D.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dg_D.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dg_D.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dg_D.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells


        For i As Integer = 0 To dg_D.Rows.Count - 1

            If dg_D.Rows(i).Cells(0).Value = 93 Then

                dg_D.Rows(i).DefaultCellStyle.BackColor = Color.DarkRed
                dg_D.Rows(i).DefaultCellStyle.ForeColor = Color.White

            ElseIf dg_D.Rows(i).Cells(0).Value < 20 Then
                dg_D.Rows(i).DefaultCellStyle.BackColor = Color.LightYellow
            ElseIf dg_D.Rows(i).Cells(0).Value < 30 Then
                dg_D.Rows(i).DefaultCellStyle.BackColor = Color.Honeydew
            ElseIf dg_D.Rows(i).Cells(0).Value < 40 Then
                dg_D.Rows(i).DefaultCellStyle.BackColor = Color.LightCyan
            Else
                dg_D.Rows(i).DefaultCellStyle.BackColor = Color.LavenderBlush
            End If



            If dg_D.Rows(i).Cells(1).Value = "Total" Then
                dg_D.Rows(i).DefaultCellStyle.BackColor = Color.DarkViolet
                dg_D.Rows(i).DefaultCellStyle.ForeColor = Color.White
            End If

        Next

        lbLnbr.Text = dg_D.Rows.Count & " Lines"

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        dg_D.DataSource = Nothing
        dg_D.DataSource = dt_in


        dg_D.Columns(0).Visible = False
        dg_D.Columns(1).Visible = False
        dg_D.Columns(2).Visible = False
        dg_D.Columns(3).Visible = False
        'dg_D.Columns(4).Visible = False
        dg_D.Columns(5).Visible = False
        dg_D.Columns(6).Visible = False
        dg_D.Columns(7).Visible = False
        dg_D.Columns(8).Visible = False
        dg_D.Columns(9).Visible = False
        dg_D.Columns(11).Visible = False
        dg_D.Columns(12).Visible = False
        dg_D.Columns(13).Visible = False

        dg_D.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dg_D.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        ' dg_D.Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dg_D.Columns(16).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dg_D.Columns(17).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dg_D.Columns(18).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells


        dg_D.Columns(16).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)

        dg_D.Columns(4).DisplayIndex = 16
        'dg_D.Columns(15).DisplayIndex = 1

        lbLnbr.Text = dg_D.Rows.Count & " Lines"
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        dg_D.DataSource = Nothing
        dg_D.DataSource = dt_OUT

        dg_D.Columns(0).Visible = False
        dg_D.Columns(1).Visible = False
        dg_D.Columns(2).Visible = False
        dg_D.Columns(3).Visible = False
        'dg_D.Columns(4).Visible = False
        dg_D.Columns(5).Visible = False
        dg_D.Columns(6).Visible = False
        dg_D.Columns(7).Visible = False
        dg_D.Columns(8).Visible = False
        dg_D.Columns(9).Visible = False
        dg_D.Columns(11).Visible = False
        dg_D.Columns(12).Visible = False
        dg_D.Columns(13).Visible = False

        dg_D.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dg_D.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        ' dg_D.Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dg_D.Columns(16).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dg_D.Columns(17).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dg_D.Columns(18).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells



        lbLnbr.Text = dg_D.Rows.Count & " Lines"
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        filtreTheData_RapportDala3()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim str As String = InputBox("Code / Ref  de groupe d'article", "Rapport ..")
        If str = "" Then Exit Sub

        Dim BTA As New ALMohassinDBDataSetTableAdapters.TracabilityINTableAdapter

        dt_in = BTA.GetDataByRapportDala3_Achat("%" & str & "%")
        dt_OUT = BTA.GetDataByRapportDal3_Vente("%" & str & "%")

        Dim artta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
        Dim dfta As New ALMohassinDBDataSetTableAdapters.FactureTableAdapter
        dt_Art = artta.GetDatalikecodebar("%" & str & "%")
        dt_Pr = dfta.GetDataByfctid(0)
        dt_Pr.Rows.Clear()
        dt_Pr.Rows.Add(0, 0, "Creation", 0, 0, Now.ToString(), True, Form1.adminName)





        myRapport = New RpClass
        myRapport.isNew = True

        filtreTheData_RapportDala3()

        plTxt.Enabled = True
        FileName = New Random().Next & "-" & Now.ToString("ddMMyyyy") & "-" & str
        txtRP.text = FileName
        code_str = str
        STR_TITLE = "Rapport Article :  " & txtRP.text

    End Sub
    Public ThePath As String = ""
    Public FileName As String = ""

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If myRapport.isNew = True Then
            Try
                ' SaveChanges()
                FileName = txtRP.text

                myRapport.name = txtRP.text
                myRapport.dt_in = dt_in
                myRapport.dt_OUT = dt_OUT
                myRapport.dt_Art = dt_Art
                myRapport.dt_Pr = dt_Pr
                myRapport.pid = CInt(Now.ToString("ddMMyyyy"))
                myRapport.code_str = code_str


                'update database
                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                    Dim params As New Dictionary(Of String, Object)
                    Dim where As New Dictionary(Of String, Object)


                    where.Add("code LIKE", "%" & code_str & "%")
                    where.Add("pid = ", 0)
                    params.Add(" pid = ", myRapport.pid)
                    c.UpdateRecordSymbols("DetailsFacture", params, where)


                    'End If
                    params.Clear()
                    where.Clear()

                    where.Add("code LIKE", "%" & myRapport.code_str & "%")
                    where.Add("pid = ", 0)
                    params.Add(" pid = ", myRapport.pid)
                    c.UpdateRecordSymbols("DetailsBon", params, where)


                    params = Nothing
                    where = Nothing
                End Using

                myRapport.isNew = False
                WriteToXmlFile(Of RpClass)(ThePath & "\" & FileName, myRapport)

            Catch ex As Exception

            End Try
        Else
            Try
                WriteToXmlFile(Of RpClass)(ThePath & "\" & FileName, myRapport)
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub ProfitProduitRapport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dir1 As New DirectoryInfo(Form1.ImgPah & "\RapportProduit")
        If dir1.Exists = False Then dir1.Create()
        ThePath = System.IO.Path.Combine(Form1.ImgPah, "RapportProduit").ToString

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim pr As New ProfitElementRapport
        pr.dt_Pr = dt_Pr

        If pr.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If

        dt_Pr = pr.dt_Pr

        If myRapport.isNew = False Then
            myRapport.dt_Pr = dt_Pr
            WriteToXmlFile(Of RpClass)(ThePath & "\" & FileName, myRapport)
        End If

        filtreTheData_RapportDala3()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If myRapport.isNew = True Then Exit Sub

        STR_TITLE = FileName
        STR_TITLE = STR_TITLE.Replace("|", " ")
        STR_TITLE = STR_TITLE.Replace(":", " ")
        STR_TITLE = STR_TITLE.Replace("/", " ")

        SaveDataToHtml(dg_D, STR_TITLE)
    End Sub
End Class

Public Class RpClass
    Public name As String
    Public code_str As String
    Public pid As Integer
    Public dt_in As New DataTable
    Public dt_OUT As New DataTable
    Public dt_Art As New DataTable
    Public isNew As Boolean = True
    Public dt_Pr As New DataTable

End Class

