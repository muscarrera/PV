Imports MyBarcode

Public Class AddMelange

    'properties
    Public Property p As String
        Get
            Return AddList1.p
        End Get
        Set(ByVal value As String)
            AddList1.p = value
        End Set
    End Property
    Public Property AutoCompleteSource() As AutoCompleteStringCollection
        Get
            Return AddList1.AutoCompleteSource
        End Get
        Set(ByVal value As AutoCompleteStringCollection)
            AddList1.AutoCompleteSource = value
        End Set
    End Property

    Private Sub AddMelange_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Using a As SubClass = New SubClass
            'Records binded to the AutocompleteStringCollection.
            Dim MySource As New AutoCompleteStringCollection()
            MySource.AddRange(a.AutoCompleteMelange(p).ToArray)
            AutoCompleteSource = MySource

            If AddList1.EditMode = False Then
                Dim EA As New EAN13Barcode
                EA.Value = GetRandom(10000000, 99999999)
                AddList1.barCode = EA.Value & EA.CheckSum.ToString()
                EA = Nothing
            End If


        End Using
    End Sub

    Private Sub AddList1_NewKey(ByRef sender As System.Object, ByVal Key As System.String) Handles AddList1.NewKey
        Dim ap As AddPanel = CType(sender, AddPanel)

        Using a As SubClass = New SubClass
            a.Get_MedDesc(ap, Key, p, AddList1)

        End Using
    End Sub
    Private Sub AddList1_SaveColor(ByVal Data As Dictionary(Of String, Object), ByVal Dataliste As Dictionary(Of String, Object), ByVal p As String) Handles AddList1.SaveColor
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            c.InsertRecord("Article", Data)
            For Each kv As KeyValuePair(Of String, Object) In Dataliste
                If CStr(kv.Key).Contains("|") = False Then Continue For

                'Detailstock
                Dim id As String = CStr(kv.Key).Split("|")(1)
                Dim qte As Double = CStr(kv.Value)

                Dim where As New Dictionary(Of String, Object)
                where.Add("arid", id)
                where.Add("dpid", p)

                Dim CloseBoxQte As Double = c.SelectByScalar("Detailstock", "qte", where)
                where.Clear()

                CloseBoxQte -= qte

                Dim params As New Dictionary(Of String, Object)
                params.Add("qte", CloseBoxQte)
                where.Clear()
                where.Add("arid", id)
                where.Add("dpid", p)
                If c.UpdateRecord("Detailstock", params, where) = 0 Then
                    params.Clear()
                    where.Clear()
                    where.Add("arid", id)
                    Dim cid As String = c.SelectByScalar("Article", "cid", where)
                    Dim unit As String = c.SelectByScalar("Article", "unite", where)

                    params.Add("qte", CloseBoxQte)
                    params.Add("arid", id)
                    params.Add("dpid", p)
                    params.Add("cid", cid)
                    params.Add("unit", unit)
                    c.InsertRecord("Detailstock", params)
                End If
                params.Clear()
                where.Clear()
            Next

            AddList1.Clearliste()
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End Using
    End Sub
    Private Sub AddList1_UpdateColor(ByVal Data As Dictionary(Of String, Object), ByVal where2 As Dictionary(Of String, Object), ByVal difParams As Dictionary(Of String, Object), ByVal p As String) Handles AddList1.UpdateColor

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            c.UpdateRecord("Article", Data, where2)

            For Each kv As KeyValuePair(Of String, Object) In difParams
                'Detailstock
                Dim id As String = CStr(kv.Key).Split("|")(1)
                Dim qte As String = kv.Value

                Dim where As New Dictionary(Of String, Object)
                where.Add("arid", id)
                where.Add("dpid", 2)

                Dim OpenBoxQte As Double = c.SelectByScalar("Detailstock", "qte", where)
                where.Clear()

                where.Add("arid", id)
                where.Add("dpid", 1)

                Dim CloseBoxQte As Double = c.SelectByScalar("Detailstock", "qte", where)
                where.Clear()

                qte += OpenBoxQte + CloseBoxQte

                If qte < 0 Then
                    'is not enough
                    c._hasError = True
                    c.Dispose()
                    Exit Sub
                End If

                Dim newQteclosed As Integer = 0
                Dim newQteOpened As Double = 0
                SplitDecimal(qte, newQteclosed, newQteOpened)

                Dim params As New Dictionary(Of String, Object)
                params.Add("qte", newQteclosed)

                where.Add("arid", id)
                where.Add("dpid", 1)
                c.UpdateRecord("Detailstock", params, where)

                params.Clear()
                where.Clear()

                params.Add("qte", newQteOpened)

                where.Add("arid", id)
                where.Add("dpid", 2)
                c.UpdateRecord("Detailstock", params, where)

            Next

            AddList1.Clearliste()
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End Using

    End Sub
End Class