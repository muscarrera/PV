Public Class BackUpRestaure
    Implements IDisposable


    Public Sub UpdateDataBase(ByVal str As String)

        Dim dt As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable
        Dim dt5 As DataTable
        Dim dt6 As DataTable

        Using A As DataAccess = New DataAccess("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & str & ";Persist Security Info=False;")
            dt = A.SelectDataTable("Category", {"*"})
            dt2 = A.SelectDataTable("Article", {"*"})
            dt3 = A.SelectDataTable("Client", {"*"})
            dt4 = A.SelectDataTable("company", {"*"})
            dt5 = A.SelectDataTable("Facture", {"*"})
            dt6 = A.SelectDataTable("DetailsFacture", {"*"})
        End Using

        Try
            Using A As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                A.DeleteRecords("Category")
                A.DeleteRecords("Article")
                A.DeleteRecords("Client")
                A.DeleteRecords("company")
                A.DeleteRecords("Facture")
                A.DeleteRecords("DetailsFacture")

                Dim params As New Dictionary(Of String, Object)

                For i As Integer = 0 To dt.Rows.Count - 1
                    params.Add("cid", dt.Rows(i).Item(0))
                    params.Add("name", dt.Rows(i).Item(1))
                    params.Add("img", dt.Rows(i).Item(2))

                    A.InsertRecord("Category", params)
                    params.Clear()
                Next

                For i As Integer = 0 To dt2.Rows.Count - 1
                    params.Add("arid", CInt(dt2.Rows(i).Item("arid")))

                    params.Add("name", CStr(dt2.Rows(i).Item("name")))
                    Dim IMMG As String = "-"
                    If IsDBNull(dt2.Rows(i).Item("img")) Then
                        IMMG = "No image"
                    Else
                        IMMG = CStr(dt2.Rows(i).Item("img"))
                    End If
                    params.Add("img", IMMG)
                    params.Add("bprice", CDbl(dt2.Rows(i).Item("bprice")))
                    params.Add("sprice", CDbl(dt2.Rows(i).Item("sprice")))
                    params.Add("unite", CStr(dt2.Rows(i).Item("unite")))
                    params.Add("qte", CDbl(0))
                    params.Add("tva", CDbl(dt2.Rows(i).Item("tva")))
                    params.Add("sp3", CDbl(dt2.Rows(i).Item("sprice")))
                    params.Add("sp4", CDbl(dt2.Rows(i).Item("sprice")))
                    params.Add("sp5", CDbl(dt2.Rows(i).Item("sprice")))
                    params.Add("depot", CInt(dt2.Rows(i).Item("depot")))
                    params.Add("poid", CInt(dt2.Rows(i).Item("poid")))
                    params.Add("mixte", CBool(dt2.Rows(i).Item("mixte")))

                    Try
                        params.Add("cid", CInt(dt2.Rows(i).Item("cid")))
                        params.Add("codebar", CStr(dt2.Rows(i).Item("codebar")))
                        params.Add("elements", CStr(dt2.Rows(i).Item("elements")))
                    Catch ex As Exception
                    End Try

                    params.Add("isMixte", CBool(dt2.Rows(i).Item("isMixte")))

                    A.InsertRecord("Article", params)
                    params.Clear()
                Next

                For i As Integer = 0 To dt3.Rows.Count - 1
                    Dim crd As Double = 0
                    params.Clear()

                    params.Add("Clid", dt3.Rows(i).Item("Clid"))
                    params.Add("name", dt3.Rows(i).Item("name"))
                    params.Add("CIN", dt3.Rows(i).Item("CIN"))
                    params.Add("Adress", dt3.Rows(i).Item("Adress"))
                    params.Add("tel", dt3.Rows(i).Item("tel"))
                    params.Add("credit", crd)
                    params.Add("type", 1)


                    A.InsertRecord("Client", params)
                    params.Clear()
                Next
                For i As Integer = 0 To dt5.Rows.Count - 1
                    params.Add("fctid", CInt(dt5.Rows(i).Item("fctid")))
                    params.Add("clid", CInt(dt5.Rows(i).Item("Clid")))
                    params.Add("name", dt5.Rows(i).Item("name"))
                    params.Add("total", CDbl(dt5.Rows(i).Item("total")))
                    params.Add("avance", CDbl(dt5.Rows(i).Item("avance")))
                    params.Add("date", CDate(dt5.Rows(i).Item("date")))
                    params.Add("admin", CBool(dt5.Rows(i).Item("admin")))
                    params.Add("writer", CStr(dt5.Rows(i).Item("writer")))
                    params.Add("tp", dt5.Rows(i).Item("tp"))
                    params.Add("payed", CBool(dt5.Rows(i).Item("payed")))
                    params.Add("poid", CInt(dt5.Rows(i).Item("poid")))
                    params.Add("num", CInt(dt5.Rows(i).Item("num")))
                    params.Add("tva", CDbl(dt5.Rows(i).Item("poid")))
                    params.Add("adresse", CStr(dt5.Rows(i).Item("num")))
                    params.Add("bl", CStr(dt5.Rows(i).Item("bl")))
                    params.Add("remise", CInt(dt5.Rows(i).Item("remise")))
                    params.Add("beInFacture", CInt(dt5.Rows(i).Item("beInFacture")))

                    A.InsertRecord("Facture", params)
                    params.Clear()
                Next

                For i As Integer = 0 To dt6.Rows.Count - 1
                    params.Add("id", CInt(dt6.Rows(i).Item("id")))
                    params.Add("fctid", CInt(dt6.Rows(i).Item("fctid")))
                    params.Add("name", dt6.Rows(i).Item("name"))
                    params.Add("bprice", CDbl(dt6.Rows(i).Item("bprice")))
                    params.Add("price", CDbl(dt6.Rows(i).Item("price")))
                    params.Add("unit", dt6.Rows(i).Item("unit"))
                    params.Add("qte", CDbl(dt6.Rows(i).Item("qte")))
                    params.Add("tva", CDbl(dt6.Rows(i).Item("tva")))
                    params.Add("poid", CInt(dt6.Rows(i).Item("poid")))
                    params.Add("depot", CInt(dt6.Rows(i).Item("depot")))
                    params.Add("code", dt6.Rows(i).Item("code"))
                    params.Add("arid", CInt(dt6.Rows(i).Item("arid")))
                    params.Add("cid", dt6.Rows(i).Item("cid"))

                    A.InsertRecord("DetailsFacture", params)
                    params.Clear()
                Next
            End Using

            MsgBox("greet job")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub UpdateDataBaseForAhmed(ByVal str As String)

        Dim dt As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable

        Using A As DataAccess = New DataAccess("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & str & ";Persist Security Info=False;")
            dt = A.SelectDataTable("Category", {"*"})
            dt2 = A.SelectDataTable("Article", {"*"})
            dt3 = A.SelectDataTable("Client", {"*"})
            dt4 = A.SelectDataTable("company", {"*"})
        End Using

        Try
            Using A As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                A.DeleteRecords("Category")
                A.DeleteRecords("Article")
                A.DeleteRecords("Client")
                A.DeleteRecords("company")
                A.DeleteRecords("Facture")
                A.DeleteRecords("DetailsFacture")
                A.DeleteRecords("Bon")
                A.DeleteRecords("DetailsBon")
                A.DeleteRecords("Depot")

                Dim params As New Dictionary(Of String, Object)

                For i As Integer = 0 To dt.Rows.Count - 1
                    params.Add("cid", dt.Rows(i).Item(0))
                    params.Add("name", dt.Rows(i).Item(1))
                    params.Add("img", dt.Rows(i).Item(2))

                    A.InsertRecord("Category", params)
                    params.Clear()
                Next

                For i As Integer = 0 To dt2.Rows.Count - 1
                    params.Add("arid", CInt(dt2.Rows(i).Item("arid")))

                    params.Add("name", CStr(dt2.Rows(i).Item("name")))
                    Dim IMMG As String = "-"
                    If IsDBNull(dt2.Rows(i).Item("img")) Then
                        IMMG = "No image"
                    Else
                        IMMG = CStr(dt2.Rows(i).Item("img"))
                    End If
                    params.Add("img", IMMG)
                    params.Add("bprice", CDbl(dt2.Rows(i).Item("bprice")))
                    params.Add("sprice", CDbl(dt2.Rows(i).Item("sprice")))
                    params.Add("unite", CStr(dt2.Rows(i).Item("unite")))
                    params.Add("qte", CDbl(0))
                    params.Add("tva", 20)
                    params.Add("sp3", CDbl(dt2.Rows(i).Item("sprice")))
                    params.Add("sp4", CDbl(dt2.Rows(i).Item("sprice")))
                    params.Add("sp5", CDbl(dt2.Rows(i).Item("sprice")))
                    params.Add("depot", 1)
                    params.Add("poid", 0)
                    params.Add("mixte", False)

                    Try
                        params.Add("cid", CInt(dt2.Rows(i).Item("cid")))
                        params.Add("codebar", CStr(dt2.Rows(i).Item("codebar")))
                        params.Add("elements", "0")
                    Catch ex As Exception
                    End Try

                    params.Add("isMixte", False)

                    A.InsertRecord("Article", params)
                    params.Clear()
                Next

                For i As Integer = 0 To dt3.Rows.Count - 1
                    Dim crd As Double = 0
                    params.Clear()

                    params.Add("Clid", dt3.Rows(i).Item("Clid"))
                    params.Add("name", dt3.Rows(i).Item("name"))
                    params.Add("CIN", dt3.Rows(i).Item("CIN"))
                    params.Add("Adress", dt3.Rows(i).Item("Adress"))
                    params.Add("tel", dt3.Rows(i).Item("tel"))
                    params.Add("credit", crd)
                    params.Add("type", 1)


                    A.InsertRecord("Client", params)
                    params.Clear()

                    If CDbl(dt3.Rows(i).Item("credit")) <> 0 Then
                        params.Add("fctid", i)
                        params.Add("clid", CInt(dt3.Rows(i).Item("Clid")))
                        params.Add("name", dt3.Rows(i).Item("name"))
                        params.Add("total", CDbl(dt3.Rows(i).Item("credit")))
                        params.Add("avance", 0)
                        params.Add("date", Now.Date)
                        params.Add("admin", True)
                        params.Add("tp", CInt(1))
                        params.Add("payed", False)
                        params.Add("poid", CDbl(1))
                        params.Add("num", CInt(1))
                        params.Add("tva", CDbl(0))
                        params.Add("adresse", "-")
                        params.Add("bl", "-")

                        A.InsertRecord("Facture", params)
                        params.Clear()

                        params.Add("id", i)
                        params.Add("fctid", i)
                        params.Add("name", "credit")
                        params.Add("bprice", CDbl(dt3.Rows(i).Item("credit")))
                        params.Add("price", CDbl(dt3.Rows(i).Item("credit")))
                        params.Add("unit", "DH")
                        params.Add("qte", 1)
                        params.Add("tva", 0)
                        params.Add("poid", 1)
                        params.Add("depot", 0)
                        params.Add("arid", 0)
                        params.Add("cid", 0)

                        A.InsertRecord("DetailsFacture", params)
                        params.Clear()
                    End If


                Next

                ''''' Depot
                params.Clear()
                params.Add("dpid", CInt(1))
                params.Add("name", "Depot 1")
                A.InsertRecord("Depot", params)


                MsgBox("greet job")
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub UpdateClients(ByVal str As String)

        Dim dt3 As DataTable

        Try
            Using A As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                dt3 = A.SelectDataTable("Client", {"*"})

                Dim params As New Dictionary(Of String, Object)
                Dim where As New Dictionary(Of String, Object)

                For i As Integer = 0 To dt3.Rows.Count - 1
                    Dim crd As Double = 0
                    params.Add("clid", dt3.Rows(i).Item("Clid"))
                    params.Add("admin", True)
                    params.Add("payed", False)
                    Dim ddt = A.SelectDataTable("Facture", {"total", "avance"}, params)
                    If ddt.Rows.Count > 0 Then
                        For e As Integer = 0 To ddt.Rows.Count - 1
                            crd += ddt.Rows(e).Item("total") - ddt.Rows(e).Item("avance")
                        Next
                    End If

                    params.Clear()

                    crd -= CDbl(dt3.Rows(i).Item("credit"))

                    where.Add("Clid", dt3.Rows(i).Item("Clid"))
                    params.Add("credit", crd)

                    A.UpdateRecord("Client", params, where)
                    params.Clear()
                    where.Clear()
                Next
                MsgBox("greet job")
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Sub UpdateDataBaseXml(ByVal SavePath As String)

        If System.IO.File.Exists(SavePath) Then
            'The file exists
            Dim strpath As String = SavePath
            Dim ds As New DataSet
            ds.ReadXml(strpath)

            Dim dt As DataTable
            Dim dt2 As DataTable
            Dim dt3 As DataTable
            Dim dt4 As DataTable
            Dim dt5 As DataTable
            Dim dt6 As DataTable
            Dim dt7 As DataTable
            Dim dt8 As DataTable
            Dim dt9 As DataTable
            Dim dt10 As DataTable
            'Dim dt11 As DataTable
            'Dim dt12 As DataTable
            'Dim dt13 As DataTable
            'Dim dt14 As DataTable
            'Dim dt15 As DataTable

            Try
                dt = ds.Tables("Payment")
                dt2 = ds.Tables("CompanyPayment")
                dt3 = ds.Tables("Client")
                dt4 = ds.Tables("company")
                dt5 = ds.Tables("Facture")
                dt6 = ds.Tables("DetailsFacture")
                dt7 = ds.Tables("Bon")
                dt8 = ds.Tables("DetailsBon")
                dt9 = ds.Tables("Charge")
                dt10 = ds.Tables("Facture_Liste")
                'dt11 = ds.Tables("Detailstock")
                'dt12 = ds.Tables("Article")
                'dt13 = ds.Tables("Category")
                'dt14 = ds.Tables("Client")
                'dt15 = ds.Tables("company")

                Using A As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                    A.DeleteRecords("company")
                    A.DeleteRecords("CompanyPayment")
                    A.DeleteRecords("Client")
                    A.DeleteRecords("Payment")
                    A.DeleteRecords("Facture")
                    A.DeleteRecords("DetailsFacture")
                    A.DeleteRecords("Bon")
                    A.DeleteRecords("DetailsBon")
                    A.DeleteRecords("Charge")
                    A.DeleteRecords("Facture_Liste")
                    'A.DeleteRecords("Detailstock")
                    'A.DeleteRecords("Article")
                    'A.DeleteRecords("Category")
                    'A.DeleteRecords("Client")
                    'A.DeleteRecords("company")

                    Dim params As New Dictionary(Of String, Object)

                    For i As Integer = 0 To dt.Rows.Count - 1
                        params.Add("Pid", CInt(dt.Rows(i).Item(0)))
                        params.Add("name", dt.Rows(i).Item("name"))
                        params.Add("clid", CInt(dt.Rows(i).Item("clid")))
                        params.Add("montant", dt.Rows(i).Item("montant"))
                        params.Add("way", dt.Rows(i).Item("way"))
                        params.Add("date", CDate(dt.Rows(i).Item("date")))
                        Dim NUM As String = ""
                        Try
                            NUM = dt.Rows(i).Item("Num")
                        Catch ex As Exception
                            NUM = "-"
                        End Try

                        params.Add("Num", NUM)
                        params.Add("fctid", CInt(dt.Rows(i).Item("fctid")))
                        params.Add("writer", dt.Rows(i).Item("writer"))

                        A.InsertRecord("Payment", params)
                        params.Clear()
                    Next

                    For i As Integer = 0 To dt2.Rows.Count - 1
                        params.Add("PBid", CInt(dt2.Rows(i).Item(0)))
                        params.Add("name", dt2.Rows(i).Item("name"))
                        params.Add("comid", CInt(dt2.Rows(i).Item("comid")))
                        params.Add("montant", dt2.Rows(i).Item("montant"))
                        params.Add("way", dt2.Rows(i).Item("way"))
                        params.Add("date", CDate(dt2.Rows(i).Item("date")))
                        Dim NUM As String = ""
                        Try
                            NUM = dt2.Rows(i).Item("Num")
                        Catch ex As Exception
                            NUM = "-"
                        End Try
                        params.Add("Num", NUM)
                        params.Add("bonid", CInt(dt2.Rows(i).Item("bonid")))
                        params.Add("writer", dt2.Rows(i).Item("writer"))
                        params.Add("paydate", CDate(dt2.Rows(i).Item("date")))

                        A.InsertRecord("CompanyPayment", params)
                        params.Clear()
                    Next

                    For i As Integer = 0 To dt3.Rows.Count - 1
                        Dim crd As Double = 0
                        params.Clear()

                        params.Add("Clid", CInt(dt3.Rows(i).Item("Clid")))
                        params.Add("name", dt3.Rows(i).Item("name"))
                        params.Add("CIN", dt3.Rows(i).Item("CIN"))
                        params.Add("Adress", dt3.Rows(i).Item("Adress"))
                        params.Add("tel", dt3.Rows(i).Item("tel"))
                        params.Add("credit", crd)
                        params.Add("type", dt3.Rows(i).Item("type"))


                        A.InsertRecord("Client", params)
                        params.Clear()
                    Next

                    For i As Integer = 0 To dt4.Rows.Count - 1
                        Dim crd As Double = 0
                        params.Clear()

                        params.Add("compid", CInt(dt4.Rows(i).Item("compid")))
                        params.Add("name", dt4.Rows(i).Item("name"))
                        params.Add("gerant", dt4.Rows(i).Item("gerant"))
                        params.Add("Adress", dt4.Rows(i).Item("Adress"))
                        params.Add("tel", dt4.Rows(i).Item("tel"))
                        params.Add("credit", crd)
                        params.Add("type", 1)


                        A.InsertRecord("company", params)
                        params.Clear()
                    Next

                    For i As Integer = 0 To dt5.Rows.Count - 1
                        params.Add("fctid", CInt(dt5.Rows(i).Item("fctid")))
                        params.Add("clid", CInt(dt5.Rows(i).Item("Clid")))
                        params.Add("name", CStr(dt5.Rows(i).Item("name")))
                        params.Add("total", CDbl(dt5.Rows(i).Item("total")))
                        params.Add("avance", CDbl(dt5.Rows(i).Item("avance")))
                        params.Add("date", CDate(dt5.Rows(i).Item("date")))
                        params.Add("admin", CBool(dt5.Rows(i).Item("admin")))
                        params.Add("writer", CStr(dt5.Rows(i).Item("writer")))
                        params.Add("tp", dt5.Rows(i).Item("tp"))
                        params.Add("payed", CBool(dt5.Rows(i).Item("payed")))
                        params.Add("poid", CInt(dt5.Rows(i).Item("poid")))
                        params.Add("num", CInt(dt5.Rows(i).Item("num")))
                        params.Add("tva", CDbl(dt5.Rows(i).Item("tva")))
                        params.Add("adresse", CStr(dt5.Rows(i).Item("adresse")))
                        params.Add("bl", CStr(dt5.Rows(i).Item("bl")))
                        params.Add("remise", CInt(dt5.Rows(i).Item("remise")))
                        params.Add("beInFacture", CInt(dt5.Rows(i).Item("beInFacture")))

                        A.InsertRecord("Facture", params)
                        params.Clear()
                    Next

                    For i As Integer = 0 To dt6.Rows.Count - 1
                        params.Add("id", CInt(dt6.Rows(i).Item("id")))
                        params.Add("fctid", CInt(dt6.Rows(i).Item("fctid")))
                        params.Add("name", dt6.Rows(i).Item("name"))
                        params.Add("bprice", CDbl(dt6.Rows(i).Item("bprice")))
                        params.Add("price", CDbl(dt6.Rows(i).Item("price")))
                        params.Add("unit", dt6.Rows(i).Item("unit"))
                        params.Add("qte", CDbl(dt6.Rows(i).Item("qte")))
                        params.Add("tva", CDbl(dt6.Rows(i).Item("tva")))
                        params.Add("poid", CInt(dt6.Rows(i).Item("poid")))
                        params.Add("code", dt6.Rows(i).Item("code"))
                        params.Add("depot", CInt(dt6.Rows(i).Item("depot")))
                        params.Add("arid", CInt(dt6.Rows(i).Item("arid")))
                        params.Add("cid", dt6.Rows(i).Item("cid"))

                        A.InsertRecord("DetailsFacture", params)
                        params.Clear()
                    Next

                    For i As Integer = 0 To dt7.Rows.Count - 1
                        params.Add("bonid", CInt(dt7.Rows(i).Item("fctid")))
                        params.Add("clid", CInt(dt7.Rows(i).Item("Clid")))
                        params.Add("name", CStr(dt7.Rows(i).Item("name")))
                        params.Add("total", CDbl(dt7.Rows(i).Item("total")))
                        params.Add("avance", CDbl(dt7.Rows(i).Item("avance")))
                        params.Add("date", CDate(dt7.Rows(i).Item("date")))
                        params.Add("admin", CBool(dt7.Rows(i).Item("admin")))
                        params.Add("writer", CStr(dt7.Rows(i).Item("writer")))
                        params.Add("payed", CBool(dt7.Rows(i).Item("payed")))
                        params.Add("num", CInt(dt7.Rows(i).Item("num")))
                        params.Add("tp", dt7.Rows(i).Item("tp"))
                        params.Add("poid", CInt(dt7.Rows(i).Item("poid")))
                        params.Add("tva", CDbl(dt7.Rows(i).Item("tva")))
                        params.Add("adresse", CStr(dt7.Rows(i).Item("adresse")))
                        params.Add("bl", CStr(dt7.Rows(i).Item("bl")))
                        params.Add("remise", CInt(dt7.Rows(i).Item("remise")))
                        params.Add("beInFacture", CInt(dt7.Rows(i).Item("beInFacture")))

                        A.InsertRecord("Bon", params)
                        params.Clear()
                    Next

                    For i As Integer = 0 To dt8.Rows.Count - 1
                        params.Add("bid", CInt(dt8.Rows(i).Item("id")))
                        params.Add("fctid", CInt(dt8.Rows(i).Item("fctid")))
                        params.Add("name", dt8.Rows(i).Item("name"))
                        params.Add("bprice", CDbl(dt8.Rows(i).Item("bprice")))
                        params.Add("price", CDbl(dt8.Rows(i).Item("price")))
                        params.Add("unit", dt8.Rows(i).Item("unit"))
                        params.Add("qte", CDbl(dt8.Rows(i).Item("qte")))
                        params.Add("tva", CDbl(dt8.Rows(i).Item("tva")))
                        params.Add("poid", CInt(dt8.Rows(i).Item("poid")))
                        params.Add("code", dt8.Rows(i).Item("code"))
                        params.Add("depot", CInt(dt8.Rows(i).Item("depot")))
                        params.Add("arid", CInt(dt8.Rows(i).Item("arid")))
                        params.Add("cid", dt8.Rows(i).Item("cid"))

                        A.InsertRecord("DetailsBon", params)
                        params.Clear()
                    Next

                    For i As Integer = 0 To dt9.Rows.Count - 1
                        params.Add("chid", CInt(dt9.Rows(i).Item("chid")))
                        params.Add("name", CStr(dt9.Rows(i).Item("name")))
                        params.Add("price", CDbl(dt9.Rows(i).Item("price")))
                        params.Add("isRepeated", CBool(dt9.Rows(i).Item("isRepeated")))
                        params.Add("duree", CInt(dt9.Rows(i).Item("duree")))
                        params.Add("writer", dt9.Rows(i).Item("writer"))
                        params.Add("date", CDate(dt9.Rows(i).Item("date")))

                        A.InsertRecord("Charge", params)
                        params.Clear()
                    Next

                    For i As Integer = 0 To dt10.Rows.Count - 1
                        params.Add("flid", CInt(dt10.Rows(i).Item("chid")))
                        params.Add("ListBl", CStr(dt10.Rows(i).Item("ListBl")))
                        params.Add("clid", CInt(dt10.Rows(i).Item("clid")))
                        params.Add("date", CDate(dt10.Rows(i).Item("date")))
                        params.Add("remise", CDbl(dt10.Rows(i).Item("remise")))
                        params.Add("timbre", CBool(dt10.Rows(i).Item("timbre")))
                        params.Add("mode", dt10.Rows(i).Item("mode"))
                        params.Add("total", CDbl(dt10.Rows(i).Item("total")))

                        A.InsertRecord("Charge", params)
                        params.Clear()
                    Next


                    MsgBox("greet job")
                End Using

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Public Sub UpdateDataBaseXmlForAhmed(ByVal SavePath As String)

        If System.IO.File.Exists(SavePath) Then
            'The file exists
            Dim strpath As String = SavePath
            Dim ds As New DataSet
            Try
                ds.ReadXml(strpath)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


            Dim dt As DataTable
            Dim dt2 As DataTable
            Dim dt3 As DataTable
            Dim dt4 As DataTable

            Try
                dt = ds.Tables("Category")
                dt2 = ds.Tables("Article")
                dt3 = ds.Tables("Client")
                dt4 = ds.Tables("company")

                Using A As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                    A.DeleteRecords("Category")
                    A.DeleteRecords("Article")
                    A.DeleteRecords("Client")
                    A.DeleteRecords("company")
          
                    Dim params As New Dictionary(Of String, Object)

                    For i As Integer = 0 To dt.Rows.Count - 1
                        params.Add("Cid", CInt(dt.Rows(i).Item(0)))
                        params.Add("name", dt.Rows(i).Item("name"))
                        params.Add("img", dt.Rows(i).Item("img"))
                        A.InsertRecord("Category", params)
                        params.Clear()
                    Next

                    'articles
                    For i As Integer = 0 To dt2.Rows.Count - 1
                        params.Add("arid", CInt(dt2.Rows(i).Item("arid")))

                        params.Add("name", CStr(dt2.Rows(i).Item("name")))
                        Dim IMMG As String = "-"
                        If IsDBNull(dt2.Rows(i).Item("img")) Then
                            IMMG = "No image"
                        Else
                            IMMG = CStr(dt2.Rows(i).Item("img"))
                        End If
                        params.Add("img", IMMG)
                        params.Add("bprice", CDbl(dt2.Rows(i).Item("bprice")))
                        params.Add("sprice", CDbl(dt2.Rows(i).Item("sprice")))
                        params.Add("unite", CStr(dt2.Rows(i).Item("unite")))
                        params.Add("qte", CDbl(0))
                        params.Add("tva", 20)
                        params.Add("sp3", CDbl(dt2.Rows(i).Item("sp2")))
                        params.Add("sp4", CDbl(dt2.Rows(i).Item("sp3")))
                        params.Add("sp5", CDbl(dt2.Rows(i).Item("sp3")))
                        params.Add("depot", 1)
                        params.Add("poid", 0)
                        params.Add("mixte", False)

                        Try
                            params.Add("cid", CInt(dt2.Rows(i).Item("cid")))
                            params.Add("codebar", CStr(dt2.Rows(i).Item("codebar")))
                            params.Add("elements", "-")
                        Catch ex As Exception
                        End Try

                        params.Add("isMixte", False)

                        A.InsertRecord("Article", params)
                        params.Clear()
                    Next

                    For i As Integer = 0 To dt3.Rows.Count - 1
                        Dim crd As Double = 0
                        params.Clear()

                        params.Add("Clid", CInt(dt3.Rows(i).Item("Clid")))
                        params.Add("name", dt3.Rows(i).Item("name"))
                        params.Add("CIN", dt3.Rows(i).Item("CIN"))
                        params.Add("Adress", dt3.Rows(i).Item("Adress"))
                        params.Add("tel", dt3.Rows(i).Item("tel"))
                        params.Add("credit", crd)
                        params.Add("type", dt3.Rows(i).Item("type"))


                        A.InsertRecord("Client", params)
                        params.Clear()
                    Next

                    For i As Integer = 0 To dt4.Rows.Count - 1
                        Dim crd As Double = 0
                        params.Clear()

                        params.Add("compid", CInt(dt4.Rows(i).Item("compid")))
                        params.Add("name", dt4.Rows(i).Item("name"))
                        params.Add("gerant", dt4.Rows(i).Item("gerant"))
                        params.Add("Adress", dt4.Rows(i).Item("Adress"))
                        params.Add("tel", dt4.Rows(i).Item("tel"))
                        params.Add("credit", crd)
                        params.Add("type", 1)


                        A.InsertRecord("company", params)
                        params.Clear()
                    Next

                    MsgBox("greet job")
                End Using

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
