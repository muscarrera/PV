Module CaisseModule
    Dim tb_caisse = "DetailsStock" ' Mashine


    Public Function GetOpenCaisse(ByVal nm As String) As Boolean
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            params.Add("arid", 0)
            Dim dt = c.SelectDataTable(tb_caisse, {"*"}, params)

            If dt.Rows.Count Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(i).Item("name").ToString.StartsWith(nm) Then
                        Form1.caisseId = dt.Rows(i).Item(0)
                        Form1.caisseDate = dt.Rows(i).Item("name")
                        Return True
                    End If
                Next
            End If
        End Using
        Return False
    End Function
    Public Function CloseCaisse(ByVal id As Integer) As Boolean
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)
            where.Add("dtstkid", id)
            params.Add("arid", 1)
            Return c.UpdateRecordAll(tb_caisse, params)
        End Using
    End Function
    Public Function NewCaisse(ByVal nm As String) As Boolean
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)

            params.Add("name", nm)
            params.Add("qte", 0)
            params.Add("arid", 0)
            params.Add("date", Now)
            Dim id = c.InsertRecord(tb_caisse, params, True)
            If id > 0 Then
                Form1.caisseId = id
                Form1.caisseDate = nm
                Return True
            Else
                Return False
            End If

        End Using
    End Function

    Public Function Get_CaisseDetails(ByVal id As Integer) As DataTable
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            params.Add("caisse", id)
            Dim dt = c.SelectDataTable("DetailsFacture", {"*"}, params)

            If dt.Rows.Count Then
                Return dt
            End If
        End Using
        Return Nothing
    End Function


    Public Function Get_CaissePayement(ByVal id As Integer) As Double
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            params.Add("caisse", id)


            Try
                Dim dt As Double = c.SelectByScalarSUM("Payment", "SUM(montant)", params)
                Return dt
            Catch ex As Exception
                Return 0
            End Try


        End Using
        Return Nothing
    End Function



    Public Function Get_CaisseTotal(ByVal id As Integer) As String
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            params.Add("caisse", id)
            Dim dt = c.SelectDataTable("Facture", {"*"}, params)
            Dim str As String = ""
            If dt.Rows.Count Then
                Dim sum As Double = Convert.ToDouble(dt.Compute("SUM(total)", String.Empty))
                str = "[ Total Bons : " & sum.ToString("N2") & "dh]"
            End If

            params.Clear()
            params.Add("caisse", id)
            Dim dtP = c.SelectDataTable("Payment", {"*"}, params)

            If dtP.Rows.Count Then
                Dim sum As Double = Convert.ToDouble(dtP.Compute("SUM(montant)", String.Empty))

                str &= vbNewLine & "[ Total Paiement : " & sum.ToString("N2") & "dh]"
            End If

            Return str
        End Using
        Return 0
    End Function

End Module
