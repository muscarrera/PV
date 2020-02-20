Public Class SubFacture
    Implements IDisposable


    Public Sub GetFactures(ByVal N As String, ByVal d1 As Date, ByVal d2 As Date)
        Dim id As Integer = 0
        Dim params As New Dictionary(Of String, Object)
        Form1.DGVFCT.Rows.Clear()
        Dim field As String() = {""}
        If IsNumeric(N) Then
            id = CInt(N)
            params.Add("flid = ", id)
        ElseIf N.Contains("|") Then
            id = CInt(N.Split("|")(1))
            params.Add("clid = ", id)
            params.Add("date > ", d1.AddDays(-1))
            params.Add("date < ", d2.AddDays(1))
        Else
            params.Add("date > ", d1.AddDays(-1))
            params.Add("date < ", d2.AddDays(1))
        End If

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            Dim dt = c.SelectDataTableSymbols("Facture_Liste", {"*"}, params)

            If dt.Rows.Count > 0 Then
                Try
                    For i As Integer = 0 To dt.Rows.Count - 1
                        params.Clear()
                        params.Add("Clid", dt.Rows(i).Item("clid"))
                        Dim cltname As String = c.SelectByScalar("Client", "name", params)
                        Form1.DGVFCT.Rows.Add(dt.Rows(i).Item(0), cltname, dt.Rows(i).Item("date"),
                                              dt.Rows(i).Item("remise"), dt.Rows(i).Item("ListBl"),
                                              dt.Rows(i).Item("timbre"), dt.Rows(i).Item("clid"),
                                               dt.Rows(i).Item("total"), dt.Rows(i).Item("mode"))
                    Next
                Catch ex As Exception
                    Form1.RPl.ClientAdresse = ""
                    Form1.RPl.Remise = dt.Rows(0).Item("remise")
                End Try
            End If
        End Using
    End Sub
    Public Sub GetListifBons(ByVal id As Integer, ByVal CLname As String,
                             ByVal clid As Integer, ByVal r As Double,
                             ByVal tmbr As Boolean)

        Form1.DGVlistbon.Rows.Clear()
        Form1.RPl.ClearItems()

        Dim params As New Dictionary(Of String, Object)
        params.Add("beInFacture", id)
        Form1.RPl.Avance = 0
        Form1.RPl.Remise = 0

        Dim total As Double = 0
        Dim avance As Double = 0
        Dim remise As Double = r '0
        Dim tva As Double = 0

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim dt = c.SelectDataTable("Facture", {"*"}, params)
            If dt.Rows.Count > 0 Then
                Try
                    Form1.RPl.ClId = clid
                    Form1.RPl.ClientAdresse = dt.Rows(0).Item("adresse")
                    Form1.RPl.ClientName = CLname
                    Form1.lbfn.Text = CLname
                    Form1.RPl.FctId = id
                    Form1.lbfid.Text = id

                    For i As Integer = 0 To dt.Rows.Count - 1
                        Form1.DGVlistbon.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("total"), dt.Rows(i).Item("avance"),
                                              dt.Rows(i).Item("date"), dt.Rows(i).Item("payed"))

                        total += dt.Rows(i).Item("total")
                        avance += dt.Rows(i).Item("avance")
                        'remise += ((dt.Rows(i).Item("total") / 1.2) * dt.Rows(i).Item("remise")) / (100 - dt.Rows(i).Item("remise"))

                        params.Clear()
                        params.Add("fctid", dt.Rows(i).Item(0))
                        Dim dt2 = c.SelectDataTable("DetailsFacture", {"*"}, params)
                        If dt2.Rows.Count > 0 Then
                            Form1.RPl.AddItems(dt2, True)
                        End If
                    Next

                    'remise = ((100 * CDbl(Form1.lbfr.Text)) / (CDbl(Form1.lbft.Text) + CDbl(Form1.lbfr.Text) - CDbl(Form1.lbftva.Text)))
                    Form1.RPl.Remise = remise

                    Form1.RPl.Avance = String.Format("{0:n}", avance)
                    Form1.lbfr.Text = String.Format("{0:n}", remise)
                    Form1.lbftva.Text = String.Format("{0:n}", Form1.RPl.Tva) 'total - (total / 1.2))

                    Dim tm As Double = 0
                    If tmbr Then tm = (Form1.RPl.Total_Ht - remise) * 0.0025

                    Form1.lbft.Text = String.Format("{0:n}", Form1.RPl.Total_TTC + tm) ' total)
                    Form1.lbtimbre.Text = String.Format("{0:n}", tm)

                    If CBool(Form1.DGVFCT.SelectedRows(0).Cells(5).Value) = False Then Form1.lbtimbre.Text = 0

                Catch ex As Exception
                End Try
            End If
        End Using
    End Sub
    Public Function NewFacture(ByVal Clid As Integer, ByVal d As Date, ByVal r As Double,
                               ByVal t As Double, ByVal lst As String, ByVal tmbr As Boolean,
                               ByVal mode As String) As Integer
        Dim fid As Integer = 0
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add("ListBl", lst)
            params.Add("clid", Clid)
            params.Add("date", Format(d, "dd-MM-yyyy"))
            params.Add("remise", r)
            params.Add("timbre", tmbr)
            params.Add("mode", mode)
            params.Add("total", t)

            fid = c.InsertRecord("Facture_Liste", params, True)


            Dim arr As String() = lst.Split(",")
            Dim where As New Dictionary(Of String, Object)
            For i As Integer = 0 To arr.Length - 1
                where.Clear()
                params.Clear()

                params.Add("beInFacture", fid)
                where.Add("fctid", arr(i))
                c.UpdateRecord("Facture", params, where)
            Next
            where = Nothing
            params = Nothing
        End Using
        Return fid
    End Function
    Public Function UpdateFacture(ByVal fid As Integer, ByVal Clid As Integer, ByVal d As Date,
                                  ByVal r As Double, ByVal t As Double, ByVal lst As String,
                                  ByVal tmbr As Boolean, ByVal mode As String) As Boolean

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            params.Add("ListBl", lst)
            params.Add("clid", Clid)
            params.Add("date", Format(d, "dd-MM-yyyy"))
            params.Add("remise", r)
            params.Add("timbre", tmbr)
            params.Add("mode", mode)
            params.Add("total", t)

            where.Add("flid", fid)

            c.UpdateRecord("Facture_Liste", params, where)

            Dim arr As String() = lst.Split(",")
            where.Clear()
            params.Clear()
            params.Add("beInFacture", 0)
            where.Add("BeInFacture", fid)
            c.UpdateRecord("Facture", params, where)

            For i As Integer = 0 To arr.Length - 1
                where.Clear()
                params.Clear()

                params.Add("beInFacture", fid)
                where.Add("fctid", CInt(arr(i)))
                c.UpdateRecord("Facture", params, where)
            Next
            where = Nothing
            params = Nothing
        End Using
        If fid = 0 Then Return False
        Return True
    End Function
    Public Function DeleteFacture(ByVal fid As Integer) As Boolean
        Dim str As String = " عند قيامكم على الضغط على 'موافق' سيتم حذف الفاتورة "
        str = str + vbNewLine
        str = str & "رقم"
        str = str + vbNewLine
        str = str + CStr(fid)

        If MsgBox(str, MsgBoxStyle.YesNo Or MessageBoxIcon.Exclamation, "الغاء الفاتورة") = MsgBoxResult.No Then
            Return False
            Exit Function
        End If

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            params.Add("ListBl", "-")
            params.Add("clid", 0)
            params.Add("remise", 0)

            where.Add("flid", fid)

            c.UpdateRecord("Facture_Liste", params, where)

            where.Clear()
            params.Clear()

            params.Add("beInFacture", 0)
            where.Add("BeInFacture", fid)
            c.UpdateRecord("Facture", params, where)

            where = Nothing
            params = Nothing
            fid = 0
        End Using
        If fid = 0 Then Return True
        Return False
    End Function


    Public Function AddDroitTimbre(ByVal fid As Integer, ByVal bid As Integer, ByVal clid As Integer,
                                   ByVal montant As Double) As Boolean
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            params.Add("name", "@-FCT" & fid)

            params.Add("clid", clid)
            params.Add("montant", montant * -1)
            params.Add("way", "Droit de Timber")
            params.Add("date", Format(Now.Date, "dd-MM-yyyy"))
            params.Add("Num", "@-FCT" & fid)
            params.Add("fctid", bid)
            params.Add("writer", CStr(Form1.adminName))

            c.InsertRecord("Payment", params)


            params.Clear()
            where.Add("fctid", bid)

            Dim total = c.SelectByScalar("Facture", "total", where)

            Dim dt = c.SelectDataTable("Payment", {"*"}, where)
            Dim avance As Double = 0

            For i As Integer = 0 To dt.Rows.Count - 1
                avance += dt.Rows(i).Item("montant")
            Next

            Dim ispayed As Boolean = False
            If avance >= total Then ispayed = True

            params.Add("avance", avance)
            params.Add("payed", ispayed)

            c.UpdateRecord("Facture", params, where)

        End Using
        Return False
    End Function
    Public Function DeleteDroitTimbre(ByVal fid As Integer) As Boolean
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)
            Try

           
            'params.Add("name", "@-FCT" & fid)
            'c.DeleteRecords("Payment", params)

            params.Add("name", "@-FCT" & fid)
            Dim fctid = c.SelectByScalar("Payment", "fctid", params)
            c.DeleteRecords("Payment", params)

            params.Clear()
            where.Add("fctid", fctid)

            Dim total = c.SelectByScalar("Facture", "total", where)

            Dim dt = c.SelectDataTable("Payment", {"*"}, where)
            Dim avance As Double = 0

            For i As Integer = 0 To dt.Rows.Count - 1
                avance += dt.Rows(i).Item("montant")
            Next

            Dim ispayed As Boolean = False
            If avance >= total Then ispayed = True

            params.Add("avance", avance)
            params.Add("payed", ispayed)

            c.UpdateRecord("Facture", params, where)
            Catch ex As Exception

            End Try
        End Using
        Return False
    End Function


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
