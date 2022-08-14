Module StockModule


    '*Stock function and methodes
    Private Function getStockById(ByVal arid As Integer, ByVal dpid As Integer, ByVal c As DataAccess) As Double
        'If Form1.isWorkinOnStock = False Then Return Nothing

        Dim where As New Dictionary(Of String, Object)
        where.Add("arid", arid)
        where.Add("dpid", dpid)


        Dim qte = c.SelectByScalar("Details_Stock", "qte", where)

        Return qte
    End Function
    Private Function getStockId(ByVal arid As Integer, ByVal dpid As Integer, ByVal c As DataAccess) As Integer
        'If Form1.isWorkinOnStock = False Then Return 0

        Dim where As New Dictionary(Of String, Object)
        where.Add("arid", arid)
        where.Add("dpid", dpid)


        Dim id = c.SelectByScalar("Details_Stock", "id", where)
        If IsNothing(id) Then id = 0
        Return id
    End Function
    Private Function AddNewStock(ByVal arid As Integer, ByVal dpid As Integer,
                                     ByVal cid As Integer, ByVal qte As Double,
                                     ByVal c As DataAccess) As Integer
        'If Form1.isWorkinOnStock = False And Form1.useButtonValidForStock + False Then Return Nothing

        Dim where As New Dictionary(Of String, Object)
        where.Add("arid", arid)
        where.Add("dpid", dpid)
        where.Add("cid", cid)
        where.Add("qte", qte)

        Return c.InsertRecord("Details_Stock", where)

        Return qte
    End Function
    Private Function updateStock(ByVal arid As Integer, ByVal dpid As Integer,
                                    ByVal qte As Double, ByVal c As DataAccess) As Integer
        'If Form1.isWorkinOnStock = False Then Return Nothing

        Dim where As New Dictionary(Of String, Object)
        Dim params As New Dictionary(Of String, Object)
        where.Add("arid", arid)
        where.Add("dpid", dpid)

        params.Add("qte", qte)

        Return c.UpdateRecord("Details_Stock", params, where)

        Return qte
    End Function
    Private Sub getItemStock(ByRef i As Items)
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

            Try

                If i.Depot > 0 And i.arid > 0 Then

                    i.Stock = getStockById(i.arid, i.Depot, c)
                Else
                    i.Stock = 0
                End If
            Catch ex As Exception

            End Try



        End Using
    End Sub
End Module
