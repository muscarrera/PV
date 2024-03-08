Public Class SplitDetailsBon

    Private _colors As New Dictionary(Of Integer, Color)
    Private fctid As Integer = 0

    Public ReadOnly Property Total_Ht As Decimal
        Get
            Dim a As Items
            Dim t As Decimal = 0
            Dim p As Panel
            For Each p In PL.Controls
                For Each a In p.Controls
                    t += a.Total_ht
                Next
            Next
            Return t
        End Get
    End Property
    Public ReadOnly Property Tva As Decimal
        Get

            Dim tv As Decimal = 0

            Dim a As Items
            Dim p As Panel
            For Each p In PL.Controls
                For Each a In p.Controls
                    tv += a.Total_tva
                Next
            Next

            Return tv
        End Get
    End Property
    Public ReadOnly Property Total_TTC As Decimal
        Get
            Dim t As Decimal = 0

            Dim a As Items
            Dim p As Panel
            For Each p In PL.Controls
                For Each a In p.Controls
                    t += a.Total_ttc
                Next
            Next

            Return t
        End Get
    End Property
    Public ReadOnly Property SelectedItemleft As Items
        Get
            Dim a As Items
            Dim p As Panel
            For Each p In Pl2.Controls
                For Each a In p.Controls
                    If a.IsSelected = True Then
                        Return a
                    End If
                Next
            Next
            Return Nothing
        End Get
    End Property
    Public ReadOnly Property SelectedItem As Items
        Get
            Dim a As Items
            Dim p As Panel
            For Each p In PL.Controls
                For Each a In p.Controls
                    If a.IsSelected = True Then
                        Return a
                    End If
                Next
            Next
            Return Nothing
        End Get
    End Property
    Public ReadOnly Property DataSource As DataTable
        Get
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
            table.Columns.Add("id", GetType(Integer))
            Dim a As Items
            Dim p As Panel
            For Each p In PL.Controls
                For Each a In p.Controls
                    ' Add  rows with those columns filled in the DataTable.
                    table.Rows.Add(a.arid, a.Name, a.Price, a.Bprice, a.Tva,
                                   a.Qte, a.Unite, a.Total_ttc, a.cid, a.code,
                                   a.Depot, a.Poid, a.Total_ht, a.Total_tva, a.id)
                Next
            Next
            Return table
        End Get
    End Property

    Private Sub EditPrdBon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lbName.Text = Form1.RPl.ClientName



        Dim r As Items
        'newPanel.Tag = p.Tag
            'Pl2.Controls.Add(newPanel)
        For Each r In Form1.RPl.Pl.Controls
            Dim newPanel As Panel = GetCidPanel(r.cid, Pl2)
            Dim ap As New Items
            ap.Dock = DockStyle.Top
            ap.Index = PL.Controls.Count
            ap.Name = r.Name
            ap.Unite = r.Unite
            ap.Price = r.Price
            'use many prices 
            ap.Qte = r.Qte
            ap.Bprice = r.Bprice
            ap.BgColor = Color.White
            ap.SideColor = Color.CadetBlue
            ap.arid = r.arid
            ap.Tva = 20
            ap.Tva = r.Tva
            ap.cid = r.cid
            ap.code = ""
            ap.Poid = r.Poid
            ap.Depot = r.Depot
            ap.Remise = 0
            ap.ColorFont = _colors(getPanelId(r.cid, Pl2))
            ap.id = r.id
            ''''''''
            AddHandler ap.Click, AddressOf ClearPanel
            AddHandler ap.ItemDoubleClick, AddressOf Item_click

            ap.SendToBack()
            newPanel.Controls.Add(ap)

            ap.IsSelected = False
            Item_Doubleclick(ap, Nothing)
        Next


    End Sub
    Private Sub Item_Doubleclick(ByVal sender As Object, ByVal e As EventArgs)
        Dim it As Items = sender
        Dim p As Panel

        For Each p In PL.Controls
            For Each i In p.Controls
                If i.arid = it.arid Then Continue For
                i.IsSelected = False
            Next
        Next
    End Sub
    Private Sub Item_click(ByVal sender As Object, ByVal e As EventArgs)
        Dim it As Items = sender
        Dim p As Panel

        For Each p In Pl2.Controls
            For Each i In p.Controls
                If i.arid = it.arid Then Continue For
                i.IsSelected = False
            Next
        Next
    End Sub

    Private Function getPanelId(ByRef cid As Integer, ByVal pp As Panel) As Integer

        'Dim arrList As String() = Form1.txtg1Groupe.Text.Split("|")
        'If arrList.Length = 0 Then Return 0

        'Dim panelId As String = 0

        'For i As Integer = 0 To arrList.Length - 1
        '    Dim arrgroup As String() = arrList(i).Split("-")
        '    For t As Integer = 0 To arrgroup.Length - 1
        '        If arrgroup(t) = cid Then
        '            Return arrgroup(0)
        '            Exit For
        '        End If
        '    Next
        '    If panelId <> 0 Then Exit For
        'Next

        Return 0
    End Function
    Public Function GetCidPanel(ByRef cid As Integer, ByVal pp As Panel) As Panel

        Dim panelId = getPanelId(cid, pp)

        Dim a As Panel
        For Each a In pp.Controls
            If a.Tag = panelId Then
                Return a
            End If
        Next

        Dim p As New Panel
        Dim rnd As New Random
        Try
            Dim clr As Color = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255))
            _colors.Add(panelId, clr)
        Catch ex As Exception

        End Try

        p.Tag = panelId
        p.Dock = DockStyle.Top
        p.AutoSize = True
        pp.Controls.Add(p)
        Return p
    End Function
    Private Sub ClearPanel(ByVal sender As Object, ByVal e As EventArgs)
        Dim i As Items = sender
        IIf(i.IsSelected, False, True)
    End Sub
    Private Sub UpdateValue()
        LbSum.Text = String.Format("{0:n}", Total_TTC)
        LbVidal.Text = DataSource.Rows.Count & " - Vidals"

        'lbHT.Text = "T. Ht : " & String.Format("{0:n}", CDec(Total_Ht - (Total_Ht * Remise / 100)))
        lbHT.Text = "T. Ht : " & String.Format("{0:n}", Total_Ht)
        LbTva.Text = "Tva : " & String.Format("{0:n}", Tva)

        'lbremise.Text = "Remise = " & String.Format("{0:n}", CDec(Total_Ht * Remise / 100))
    End Sub
    Public Sub ChangedItemsQte(ByRef arid As Integer, ByVal qte As Double, ByVal pp As Panel)
        Dim p As Panel
        Dim a As Items
        For Each p In pp.Controls
            For Each a In p.Controls
                If a.arid = arid Then
                    a.Qte += qte
                    If a.Qte <= 0 Then
                        p.Controls.Remove(a)
                    End If
                    UpdateValue()

                    a.IsSelected = True
                    Item_Doubleclick(a, Nothing)

                    Exit For
                End If
            Next
        Next
    End Sub
    Public Function IsExiste(ByVal arid As Integer, ByVal PP As Panel) As Boolean
        Dim a As Items
        Dim P As Panel
        If PP.Controls.Count = 0 Then Return False


        For Each P In PP.Controls
            'If P.Tag = cid Then

            For Each a In P.Controls
                If a.arid = arid Then
                    Return True
                    Exit Function
                End If
            Next
            'End If
        Next
        Return False
    End Function
    Public Function IsExisteById(ByVal id As Integer, ByVal PP As Panel) As Double
        Dim a As Items
        Dim P As Panel
        If PP.Controls.Count = 0 Then Return False

        For Each P In PP.Controls
            'If P.Tag = cid Then

            For Each a In P.Controls
                If a.id = id Then
                    Return a.Qte
                End If
            Next
            'End If
        Next
        Return 0
    End Function
    Public Sub AddItems(ByRef R As Items, ByVal qte As Double)
        Try

            Dim p As Panel = GetCidPanel(R.cid, PL)

            If IsExiste(R.arid, PL) = True Then
                ChangedItemsQte(R.arid, qte, PL)
                ChangedItemsQte(R.arid, qte * -1, Pl2)
                Exit Sub
            End If

            Dim h As Integer = 0
            Dim ap As New Items
            ap.Dock = DockStyle.Top
            ap.Index = PL.Controls.Count
            ap.Name = R.Name
            ap.Unite = R.Unite
            ap.Price = R.Price
            'use many prices 
            ap.Qte = qte
            ap.Bprice = R.Bprice
            ap.BgColor = Color.White
            ap.SideColor = Color.CadetBlue
            ap.arid = R.arid
            ap.Tva = 20
            ap.Tva = R.Tva
            ap.cid = R.cid
            ap.code = ""
            ap.Poid = R.Poid
            ap.Depot = R.Depot
            ap.Remise = 0
            ap.ColorFont = _colors(getPanelId(R.cid, PL))
            ap.id = R.id
            ''''''''
            AddHandler ap.Click, AddressOf ClearPanel
            AddHandler ap.ItemDoubleClick, AddressOf Item_click

            ap.SendToBack()
            p.Controls.Add(ap)

            ChangedItemsQte(R.arid, qte * -1, Pl2)

            ap.IsSelected = True
            Item_Doubleclick(ap, Nothing)
            UpdateValue()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub returnItems(ByRef R As Items, ByVal qte As Double)
        Try
            Dim p As Panel = GetCidPanel(R.cid, Pl2)

            If IsExiste(R.arid, Pl2) = True Then
                ChangedItemsQte(R.arid, qte * -1, PL)
                ChangedItemsQte(R.arid, qte, Pl2)
                Exit Sub
            End If

            Dim h As Integer = 0
            Dim ap As New Items
            ap.Dock = DockStyle.Top
            ap.Index = PL.Controls.Count
            ap.Name = R.Name
            ap.Unite = R.Unite
            ap.Price = R.Price
            'use many prices 
            ap.Qte = qte
            ap.Bprice = R.Bprice
            ap.BgColor = Color.White
            ap.SideColor = Color.CadetBlue
            ap.arid = R.arid
            ap.Tva = 20
            ap.Tva = R.Tva
            ap.cid = R.cid
            ap.code = ""
            ap.Poid = R.Poid
            ap.Depot = R.Depot
            ap.Remise = 0
            ap.ColorFont = _colors(getPanelId(R.cid, PL))
            ap.id = R.id
            ''''''''
            AddHandler ap.Click, AddressOf ClearPanel
            AddHandler ap.ItemDoubleClick, AddressOf Item_click

            ap.SendToBack()
            p.Controls.Add(ap)
            ChangedItemsQte(R.arid, qte * -1, PL)

            ap.IsSelected = True
            Item_Doubleclick(ap, Nothing)
            UpdateValue()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Pl2.Controls.Count = 0 Then Exit Sub
        If IsNothing(SelectedItemleft) Then Exit Sub
        AddItems(SelectedItemleft, 1)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Pl2.Controls.Count = 0 Then Exit Sub
        If IsNothing(SelectedItemleft) Then Exit Sub

        Dim QTE = SelectedItemleft.Qte
        AddItems(SelectedItemleft, QTE)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If PL.Controls.Count = 0 Then Exit Sub
        If IsNothing(SelectedItem) Then Exit Sub

        Dim QTE = 1
        returnItems(SelectedItem, QTE)
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If PL.Controls.Count = 0 Then Exit Sub
        If IsNothing(SelectedItem) Then Exit Sub

        Dim QTE = SelectedItem.Qte
        returnItems(SelectedItem, QTE)
    End Sub
    Dim M As Integer = 0
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage
        Try
            Dim t As Integer = 0
            Dim r As Items
            Dim p As Panel
            For Each p In Pl2.Controls
                For Each r In p.Controls
                    t = 1
                    Exit For
                Next
                If t = 1 Then Exit For
            Next

            Using a As DrawClass = New DrawClass
                Dim dte As String = Format(Date.Now, "dd-MM-yyyy [hh:mm]")

                If t = 1 Then
                    fctid = NewFacture()
                Else
                    fctid = Form1.RPl.FctId
                End If


                a.DrawReceipt(e, DataSource, fctid, Form1.RPl.ClientName, Form1.RPl.ClientAdresse,
                              Total_Ht, Total_TTC, Tva, Total_TTC, True, dte, 0, M)


                If t = 1 Then
                    SaveFacture()
                Else
                    SaveLastFacture()
                End If


            End Using
        Catch ex As Exception
            M = 0
        End Try
    End Sub
    Public Function NewFacture() As Integer
        Try

            Dim tableName As String = "Facture"

            Dim cid As Integer = Form1.RPl.ClId
            Dim clientname As String = Form1.RPl.ClientName
            Dim clientadesse As String = ""
            Dim tp As String = 1
            Dim num As String = ""
            Dim fid As Integer = 0
            Dim dte As Date = Date.Now


            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                Dim where As New Dictionary(Of String, Object)

                params.Add("clid", cid)
                params.Add("name", clientname)
                params.Add("total", 0)
                params.Add("avance", 0)
                params.Add("date", Now)
                params.Add("admin", False)
                params.Add("writer", CStr(Form1.adminName))
                params.Add("tp", 1)
                params.Add("payed", False)
                params.Add("poid", 0)
                params.Add("num", 0)
                params.Add("tva", 0)
                params.Add("adresse", clientadesse)
                params.Add("bl", "---")
                params.Add("remise", 0)
                params.Add("beInFacture", 0)

                fid = c.InsertRecord(tableName, params, True)
                params.Clear()
            End Using

            Return fid

        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function
    Public Sub SaveFacture()

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim clid As Integer = Form1.RPl.ClId
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            For i As Integer = 0 To DataSource.Rows.Count - 1
                Dim r As DataRow = DataSource.Rows(i)

                params.Add("fctid", fctid)
                params.Add("name", r("name"))
                params.Add("bprice", CDbl(r("bprice")))
                params.Add("price", r("price"))
                params.Add("unit", r("unite"))
                params.Add("qte", r("qte"))

                params.Add("tva", CDbl(20))

                params.Add("poid", CInt(0 * 100))
                params.Add("arid", CInt(r("arid")))
                params.Add("depot", CInt(r("depot")))
                params.Add("code", "")
                params.Add("cid", CStr(r("cid")))
                params.Add("caisse", Form1.caisseId)

                c.InsertRecord("DetailsFacture", params, True)
                params.Clear()
                params.Add("id", r("id"))

                Dim q As Double = IsExisteById(CInt(r("id")), Pl2)
                If q > 0 Then
                    where.Clear()
                    where.Add("qte", q)
                    c.UpdateRecord("DetailsFacture", where, params)
                Else
                    c.DeleteRecords("DetailsFacture", params)
                End If




                params.Clear()
            Next

            Dim tableName = "Facture"
            Dim ptName = "Payment"
            Dim cl = "cid"
            Dim fc = "fctid"

            Dim dte As Date = Now.Date

            If Form1.cbCafeMode.Checked Then
                params.Add("name", "--")
                params.Add(cl, clid)
                params.Add("montant", Total_TTC)
                params.Add("way", "CACHE")
                params.Add(fc, fctid)
                params.Add("date", dte)
                params.Add("writer", Form1.adminName)
                params.Add("caisse", Form1.caisseId)

                c.InsertRecord(ptName, params)
            End If
             
            'Facture
            params.Clear()
            params.Add("total", Total_TTC)
            If Form1.cbCafeMode.Checked Then params.Add("avance", Total_TTC)
            params.Add("admin", True)
            params.Add("payed", True)
            params.Add("remise", 0)
            params.Add("bl", "-")

            where.Clear()
            where.Add(fc, fctid)

            c.UpdateRecord(tableName, params, where)

            params.Clear()
            where.Clear()

       
            PL.Controls.Clear()
            UpdateValue()


            params = Nothing
            where = Nothing
        End Using
    End Sub
    Public Sub SaveLastFacture()

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim clid As Integer = Form1.RPl.ClId
            Dim params As New Dictionary(Of String, Object)
            Dim id As Integer = Form1.RPl.FctId

            Dim tableName = "Facture"
            Dim ptName = "Payment"
            Dim cl = "cid"
            Dim fc = "fctid"

            Dim dte As Date = Now.Date
            If Form1.cbCafeMode.Checked Then
                params.Add("name", "--")
                params.Add(cl, clid)
                params.Add("montant", Total_TTC)
                params.Add("way", "CACHE")
                params.Add(fc, id)
                params.Add("date", dte)
                params.Add("writer", Form1.adminName)
                params.Add("caisse", Form1.caisseId)
                c.InsertRecord(ptName, params)
            End If

            'Facture
            params.Clear()
            params.Add("total", Total_TTC)
            If Form1.cbCafeMode.Checked Then params.Add("avance", Total_TTC)
            params.Add("admin", True)
            params.Add("payed", True)
            params.Add("tva", Tva)
            params.Add("remise", 0)
            'params.Add("date", dte)
            params.Add("bl", "-")

            Dim where As New Dictionary(Of String, Object)

            where.Add(fc, id)

            c.UpdateRecord(tableName, params, where)

            params.Clear()
            where.Clear()

            If Form1.cbCafeMode.Checked Then
                params.Add("CIN", 0)
                where.Add("Clid", clid)
                c.UpdateRecord("Client", params, where)
            End If


            PL.Controls.Clear()
            UpdateValue()

            Form1.RPl.ClearItems()
            Form1.plright.Controls.Clear()

            params = Nothing
            where = Nothing
        End Using
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            If DataSource.Rows.Count = 0 Then Exit Sub

            PrintDoc.PrinterSettings.PrinterName = Form1.txtreceipt.Text
            PrintDoc.Print()

        Catch ex As Exception

            If Form1.PrintDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintDoc.PrinterSettings.PrinterName = Form1.PrintDlg.PrinterSettings.PrinterName
                PrintDoc.Print()
            End If
        End Try
    End Sub

    Private Sub EditPrdBon_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub

    Private Sub BtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSave.Click
        Try
            Dim t As Integer = 0
            Dim r As Items
            Dim p As Panel
            For Each p In Pl2.Controls
                For Each r In p.Controls
                    t = 1
                    Exit For
                Next
                If t = 1 Then Exit For
            Next


            If t = 1 Then
                fctid = NewFacture()
                SaveFacture()
            Else
                fctid = Form1.RPl.FctId
                SaveLastFacture()
            End If

        Catch ex As Exception
            M = 0
        End Try
    End Sub
End Class