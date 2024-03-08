Imports System.IO

Public Module BackUpModule


    Public Sub SaveDataLocaly()
        If Form1._isNotSauvegarde Then Exit Sub

        Try
            Dim strpath As String = Form1.btSvPath.Tag & "\LocalData\" & Date.Now.Year.ToString
            If Not Directory.Exists(strpath) Then
                Directory.CreateDirectory(strpath)
            End If
            strpath &= "\" & Date.Now.Month.ToString
            If Not Directory.Exists(strpath) Then
                Directory.CreateDirectory(strpath)
            End If



            Dim bk As New BackUpClass
            bk.dte = Now

            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

                bk.dt_article = a.SelectDataTable("article", {"*"})
                bk.dt_Client = a.SelectDataTable("Client", {"*"})
                bk.dt_Client_Payement = a.SelectDataTable("payment", {"*"})

                bk.dt_Fournisseur = a.SelectDataTable("company", {"*"})
                bk.dt_Company_Payement = a.SelectDataTable("companypayment", {"*"})
                bk.dt_Category = a.SelectDataTable("Category", {"*"})
                bk.dt_Sell_Facture = a.SelectDataTable("Facture", {"*"})
                bk.dt_Details_Sell_Facture = a.SelectDataTable("detailsfacture", {"*"})
                bk.dt_Bon_Achat = a.SelectDataTable("Bon", {"*"})
                bk.dt_Details_Bon_Achat = a.SelectDataTable("detailsbon", {"*"})
                bk.dt_Depot = a.SelectDataTable("Depot", {"*"})
                bk.dt_Details_Stock = a.SelectDataTable("detailsstock", {"*"})
                bk.dt_admin = a.SelectDataTable("admin", {"*"})

                bk.dt_facture_liste = a.SelectDataTable("facture_liste", {"*"})
                bk.dt_machine = a.SelectDataTable("machine", {"*"})
                bk.dt_Charge = a.SelectDataTable("charge", {"*"})


            End Using

            WriteToXmlFile(Of BackUpClass)(strpath & "\" & Date.Now.Day.ToString & ".xml", bk)

        Catch ex As Exception
        End Try


    End Sub
    Public Sub SaveFacturesLocaly()
        If Form1._isNotSauvegarde Then Exit Sub

        Try
            Dim strpath As String = Form1.btSvPath.Tag & "\LocalData\" & Date.Now.Year.ToString
            If Not Directory.Exists(strpath) Then
                Directory.CreateDirectory(strpath)
            End If
            strpath &= "\" & Date.Now.Month.ToString
            If Not Directory.Exists(strpath) Then
                Directory.CreateDirectory(strpath)
            End If



            Dim bk As New BackUpClass
            bk.dte = Now

            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

                bk.dt_Sell_Facture = a.SelectDataTable("Facture", {"*"})
                bk.dt_Details_Sell_Facture = a.SelectDataTable("detailsfacture", {"*"})
                bk.dt_Client_Payement = a.SelectDataTable("payment", {"*"})

            End Using

            WriteToXmlFile(Of BackUpClass)(strpath & "\" & Date.Now.Day.ToString & ".xml", bk)

        Catch ex As Exception
        End Try


    End Sub
    Public Sub SaveArticleLocaly()

        Try
            Dim strpath As String = Form1.btSvPath.Tag & "\Articles\" & Date.Now.Year.ToString
            If Not Directory.Exists(strpath) Then
                Directory.CreateDirectory(strpath)
            End If
            strpath &= "\" & Date.Now.Month.ToString
            If Not Directory.Exists(strpath) Then
                Directory.CreateDirectory(strpath)
            End If



            Dim bk As New BackUpClass
            bk.dte = Now

            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                bk.dt_article = a.SelectDataTable("article", {"*"})
                bk.dt_Category = a.SelectDataTable("Category", {"*"})
            End Using

            WriteToXmlFile(Of BackUpClass)(strpath & "\" & Date.Now.Day.ToString & ".xml", bk)

        Catch ex As Exception
        End Try


    End Sub

    Public Sub SaveDataLocalyWithPath()
        Try
            Dim strpath As String = "c:/"
            Dim sdf As New SaveFileDialog
            If sdf.ShowDialog = Windows.Forms.DialogResult.OK Then

                strpath = sdf.FileName
                Dim bk As New BackUpClass
                bk.dte = Now

                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

                    bk.dt_article = a.SelectDataTable("article", {"*"})
                    bk.dt_Client = a.SelectDataTable("Client", {"*"})
                    bk.dt_Client_Payement = a.SelectDataTable("payment", {"*"})
                    bk.dt_Fournisseur = a.SelectDataTable("company", {"*"})
                    bk.dt_Company_Payement = a.SelectDataTable("companypayment", {"*"})
                    bk.dt_Category = a.SelectDataTable("Category", {"*"})
                    bk.dt_Sell_Facture = a.SelectDataTable("Facture", {"*"})
                    bk.dt_Details_Sell_Facture = a.SelectDataTable("detailsfacture", {"*"})
                    bk.dt_Bon_Achat = a.SelectDataTable("Bon", {"*"})
                    bk.dt_Details_Bon_Achat = a.SelectDataTable("detailsbon", {"*"})
                    bk.dt_Depot = a.SelectDataTable("Depot", {"*"})
                    bk.dt_Details_Stock = a.SelectDataTable("detailsstock", {"*"})
                    bk.dt_admin = a.SelectDataTable("admin", {"*"})

                    bk.dt_facture_liste = a.SelectDataTable("facture_liste", {"*"})
                    bk.dt_machine = a.SelectDataTable("machine", {"*"})
                    bk.dt_Charge = a.SelectDataTable("charge", {"*"})
                End Using

                WriteToXmlFile(Of BackUpClass)(strpath & Date.Now.Day.ToString & ".xml", bk)
                MsgBox("  تم حفظ البيانات  بنجاح ")
            End If
        Catch ex As Exception
        End Try





    End Sub

End Module
Public Class BackUpClass

    Public dte As Date
    Public dt_article As New DataTable
    Public dt_Client As New DataTable
    Public dt_Client_Payement As New DataTable
    Public dt_Fournisseur As New DataTable
    Public dt_Company_Payement As New DataTable
    Public dt_Category As New DataTable
    Public dt_Sell_Facture As New DataTable
    Public dt_Details_Sell_Facture As New DataTable
    Public dt_Bon_Achat As New DataTable
    Public dt_Details_Bon_Achat As New DataTable
    Public dt_facture_liste As New DataTable
    Public dt_machine As New DataTable
    Public dt_Depot As New DataTable
    Public dt_Details_Stock As New DataTable
    Public dt_Charge As New DataTable
    Public dt_admin As New DataTable
End Class
