Public Class RPanel


    'Events
    Public Event UpdateItem(ByVal sender As Object, ByVal e As EventArgs)
    Public Event UpdateQte(ByVal sender As Object, ByVal e As EventArgs)
    Public Event UpdatePrice(ByVal sender As Object, ByVal e As EventArgs)
    Public Event UpdateDepot(ByVal sender As Object, ByVal e As EventArgs)
    Public Event DeleteItem(ByRef i As Items, ByVal id As Integer)
    Public Event ReturnItem(ByVal sender As Object, ByVal e As EventArgs)

    Public Event UpdatePayment()
    Public Event UpdateBl()
    Public Event SetDetailFacture()
    Public Event UpdateClient()
    Public Event SaveFacture(ByVal id As Integer, ByVal total As Double, ByVal avance As Double, ByVal tva As Double, ByVal table As DataTable)
    Public Event SaveAndPrint(ByVal id As Integer, ByVal total As Double, ByVal avance As Double, ByVal tva As Double, ByVal table As DataTable, ByVal b As Boolean, ByVal isBl As Boolean, ByVal SecondModel As Boolean)
    Public Event EditFacture(ByVal id As Integer, ByVal Clid As Integer, ByVal ClientName As String, ByVal total As Double, ByVal avance As Double, ByVal table As DataTable)
    Public Event DeleteFacture(ByVal id As Integer, ByVal isSell As Boolean, ByVal EM As Boolean, ByVal table As DataTable)
    Public Event CPValueChange()
    Public Event UpdateArticleRemise(ByRef i As Items)
    'Edit Mode Events
    Public Event EditingItemValueChanged(ByVal oldValue As Double, ByVal newValue As Double, ByVal Field As String, ByVal itm As Items)
    Public Event SetDetailArticle(ByVal txt As String, ByRef i As Items)
    Public Event CommandeDate()
    Public Event UpdateValueChanged()
    'Members
    Public ClientName As String
    Public ClientAdresse As String
    Public FctId As Integer
    Public ClId As Integer
    Public isSell As Boolean = True
    Public _bl As String
    Public isUniqTva As Boolean
    Public ModePayement As String = "Cache"

    Private _hasManyRemise As Boolean

    Private _Num As Integer
    Private _Total As Decimal
    Private _Avance As Decimal
    Private _EditMode As Boolean

    Private _isEditing As Boolean
    Private _oldValue As Decimal
    Private _newValue As Decimal
    Private _Field As String
    Private _editingItem As Items
    Private _Remise As Decimal
    Private _ShowClc As Boolean
    Private _hideClc As Boolean
    Private _ShowProfit As Boolean
    Private _delivredDay As String

    Event printCaisse()
    Event UpdateDate()

    Event GetModePayement(ByVal FctId As Integer)

    'properties
    Public ReadOnly Property Total_Ht As Decimal
        Get

            'If isUniqTva Then

            '    For Each a In Pl.Controls
            '        t = t + (a.Total_ttc / ((100 + a.Tva) / 100))
            '    Next
            '    Return t
            'Else
            '    For Each a In Pl.Controls
            '        t = t + a.Total_ttc
            '    Next
            '    Return CDbl(t / 1.2)
            'End If

            Dim a As Items
            Dim t As Decimal = 0
            For Each a In Pl.Controls
                t += a.Total_ht
            Next
            'If hasManyRemise = False Then t -= (t * Remise) / 100
            Return t
        End Get
    End Property

    Public ReadOnly Property Tva As Decimal
        Get

            Dim tv As Decimal = 0
            If hasManyRemise = False Then
                If isUniqTva Then
                    Dim a As Items
                    For Each a In Pl.Controls
                        Dim ttl As Double = (a.Total_ttc / ((100 + a.Tva) / 100))
                        tv = tv + ((ttl - (ttl * _Remise / 100)) * a.Tva / 100)
                    Next
                Else
                    Dim T As Decimal = Total_Ht
                    tv = (T - (T * _Remise / 100)) * 20 / 100
                End If

            Else
                Dim a As Items
                For Each a In Pl.Controls
                    tv += a.Total_tva
                Next
            End If

            Return tv
        End Get
    End Property
    Public ReadOnly Property Total_TTC As Decimal
        Get
            Dim t As Decimal = 0

            If hasManyRemise = False Then
                t = (Total_Ht - (Total_Ht * Remise / 100)) + Tva
            Else
                Dim a As Items
                For Each a In Pl.Controls
                    t += a.Total_ttc
                Next
            End If

            Return t
        End Get
    End Property
    Public ReadOnly Property Rest As Decimal
        Get
            Return Total_TTC - _Avance
        End Get
    End Property
    Public Property Avance As Decimal
        Get
            Return _Avance
        End Get
        Set(ByVal value As Decimal)
            _Avance = value

            Try
                If Form1.isBaseOnRIYAL Then
                    Lbavc.Text = value.ToString("N0")
                Else
                    Lbavc.Text = String.Format("{0:n}", value)
                End If
            Catch ex As Exception
                Lbavc.Text = String.Format("{0:n}", value)
            End Try

            If value > 0 Then
                RaiseEvent GetModePayement(FctId)
            Else
                ModePayement = "Cache"
            End If
        End Set
    End Property
    Public Property Remise As String
        Get
            If hasManyRemise = False Then
                Return _Remise
            Else
                Dim a As Items
                Dim r As Decimal = 0
                Dim t As Decimal = 0

                For Each a In Pl.Controls
                    r += a.Total_remise
                    t += a.Price * a.Qte
                Next
                Try
                    'Return (r * 100) / Total_Ht
                    _Remise = (r * 100) / t
                    Return _Remise
                Catch ex As Exception
                    Return 0
                End Try
            End If
        End Get
        Set(ByVal value As String)

            If hasManyRemise = False Then
                Try
                    If value.Contains(".") Then value = value.Replace(".", Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                    If IsNumeric(value) = False Then value = 0
                    _Remise = value
                    'CP.BtRemise.Text = "Remise (" & value & " %)"
                    lbremise.Text = "Remise = " & String.Format("{0:F}", Total_Remise)

                Catch ex As Exception
                    _Remise = 0
                    'CP.BtRemise.Text = "Remise (0 %)"
                    lbremise.Text = "Remise = 0"

                End Try

                UpdateValue()
            End If
        End Set
    End Property

    Public ReadOnly Property Total_TTC_Befor_Remise As Decimal
        Get
            Dim a As Items
            Dim t As Decimal = 0
            For Each a In Pl.Controls
                ' t += a.Price * a.Qte
                t += a._total
            Next
            Return t
        End Get
    End Property
    Public ReadOnly Property Total_Remise As Decimal
        Get
            Dim t As Decimal = 0
            If hasManyRemise Then

                Dim a As Items
                For Each a In Pl.Controls
                    t += a.Total_remise
                Next
            Else

                t = (Total_Ht * Remise) / 100

            End If


            ' Return Total_Ht_Befor_Remise * Remise / 100
            Return t
        End Get
    End Property
    Public Property bl As String
        Get
            Return _bl
        End Get
        Set(ByVal value As String)
            If value = "" Then value = "---"
            _bl = value
            CP.bl = value
        End Set
    End Property
    Public Property Dte As Date
        Get
            Return CDate(lbDate.Text)
        End Get
        Set(ByVal value As Date)
            lbDate.Text = value
        End Set
    End Property
    Public ReadOnly Property SelectedItem As Items
        Get
            Dim a As Items
            For Each a In Pl.Controls
                If a.IsSelected = True Then
                    Return a
                End If
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
            table.Columns.Add("unit", GetType(String))
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
            table.Columns.Add("xOrder", GetType(Integer))
            Dim a As Items
            Dim i = 0
            For Each a In Pl.Controls
                ' Add  rows with those columns filled in the DataTable.
                table.Rows.Add(a.arid, a.Name, a.Unite, a.Price, a.Bprice, a.Tva,
                               a.Qte, a.Unite, a.Total_ttc, a.cid, a.code,
                               a.Depot, a.Poid, a.Total_ht, a.Total_tva, a.id, a.Remise, a.id, i)
                i += 1
            Next

            If i > 1 Then
                table.DefaultView.Sort = "xOrder DESC"
                table = table.DefaultView.ToTable
            End If

            If table.Rows.Count > 0 And Form1.isOrderByIdDesc_items.checked Then
                table.DefaultView.Sort = "id DESC"
                table = table.DefaultView.ToTable
            End If
            Return table
        End Get
    End Property
    Public ReadOnly Property TotalProfit_ht As Decimal
        Get
            Dim t As Decimal = 0
            Dim a As Items

            'If hasManyRemise = True Then
            '    For Each a In Pl.Controls
            '        t += a.Profit_ht
            '    Next
            'Else
            '    t = (Total_Ht - (Total_Ht * Remise / 100))
            '    Dim b As Decimal = 0
            '    For Each a In Pl.Controls
            '        b += (a.Qte * a.Bprice) / ((100 + a.Tva) / 100)
            '    Next

            '    t = t - b
            'End If

            If hasManyRemise = True Then
                For Each a In Pl.Controls
                    t += a.Profit_ht
                Next
            Else
                Dim b As Decimal = 0
                For Each a In Pl.Controls
                    b += a.Qte * a.Bprice
                Next

                t = Total_TTC - b
            End If
            Return t
        End Get
    End Property

    Public Property EditMode As Boolean
        Get
            Return _EditMode
        End Get
        Set(ByVal value As Boolean)
            _EditMode = value
            CP.EditMode = value
            If value = True Then
                'CP.Visible = False
                'PlButtom.Height = 45
                BtSave.Text = "   Modifier"
            Else
                'If ShowClc Then CP.Visible = True
                'If ShowClc Then PlButtom.Height = 242
                BtSave.Text = "   Enreg"
            End If
            CP.ActiveQte(False)
            'ShowClc = True
        End Set
    End Property
    Public Property hasManyRemise As Boolean
        Get
            Return _hasManyRemise
        End Get
        Set(ByVal value As Boolean)
            _hasManyRemise = value
            CP.hasRemise = value
        End Set
    End Property
    Public Property ShowClc As Boolean
        Get
            Return _ShowClc
        End Get
        Set(ByVal value As Boolean)
            _ShowClc = value

            CP.Visible = value
            CP.ActiveQte(False)
        End Set
    End Property
    Public Property hideClc As Boolean
        Get
            Return _hideClc
        End Get
        Set(ByVal value As Boolean)
            _hideClc = value
            CP.Height = 44
            CP.Visible = value
            If value Then CP.Height = 242
            CP.ActiveQte(False)
        End Set
    End Property
    Public Property ShowProfit As Boolean
        Get
            Return _ShowProfit
        End Get
        Set(ByVal value As Boolean)
            _ShowProfit = value
            lbProfit.Visible = value

            'If value = False Then
            '    LbVidal.Top = lbProfit.Top
            '    LbVidal.Left = lbProfit.Left
            'Else
            '    LbVidal.Top = LbTva.Top
            '    LbVidal.Left = 81
            'End If
        End Set
    End Property
    Public Property Num As Integer
        Get
            Return _Num
        End Get
        Set(ByVal value As Integer)
            _Num = value
            Label2.ForeColor = Color.Black
            LbSum.ForeColor = Color.Black
            If value > 0 Then
                Label2.ForeColor = Color.Blue
                LbSum.ForeColor = Color.Blue
            End If
        End Set
    End Property
    Public Property delivredDay As String
        Get
            Return _delivredDay
        End Get
        Set(ByVal value As String)
            _delivredDay = value
            CP.BtCmd.BackColor = Color.MistyRose
            CP.BtCmd.ForeColor = Color.Maroon
            If value <> "0" And value <> "-" Then
                CP.BtCmd.BackColor = Color.ForestGreen
                CP.BtCmd.ForeColor = Color.White
            End If
        End Set
    End Property

    Public Property TypePrinter As String
        Get
            Return "&"
        End Get
        Set(ByVal value As String)

            If value = "Receipt" Then

                BtPrint.Width = 125
                BtPrint.Visible = True
                BtBlPrint.Visible = False

                BtPrint.TextAlign = ContentAlignment.MiddleCenter

            ElseIf value = "Normal" Then

                BtBlPrint.Width = 125
                BtBlPrint.Visible = True
                BtPrint.Visible = False

                BtBlPrint.TextAlign = ContentAlignment.MiddleCenter

                BtBlPrint.Left = BtPrint.Left
            Else
                BtBlPrint.Width = 65
                BtPrint.Width = 65
                BtBlPrint.Visible = True
                BtPrint.Visible = True

                BtPrint.TextAlign = ContentAlignment.MiddleRight
                BtBlPrint.TextAlign = ContentAlignment.MiddleRight

                BtBlPrint.Left = BtPrint.Left + 75
            End If
        End Set
    End Property

    'Subs & functions
    Public Sub AddItems(ByVal R As ALMohassinDBDataSet.ArticleRow, ByVal id As Integer, ByVal isSell As Boolean) 'old and stable one
        Try
            'Never add charges items to selling items

            If R.cid = -100 And isSell = True Then Exit Sub

            Dim h As Integer = 0
            Dim ap As New Items
            ap.Dock = DockStyle.Top
            ap.Index = Pl.Controls.Count
            ap.Name = R.name
            ap.Unite = R.unite
            If isSell Then
                ap.Price = R.sprice
                'use many prices 
                'If Num > 0 Then
                '    ap.Price = R.bprice + (R.bprice * Num / 100)
                'End If

                If Num > 0 Then
                    'Select Case Form1.RPl.Num
                    '    Case 2
                    '        ap.Price = R.sp3
                    '    Case 3
                    '        ap.Price = R.sp4
                    '    Case 4
                    '        ap.Price = R.sp5
                    '    Case Else
                    '        ap.Price = R.sprice
                    'End Select
                End If

            Else
                ap.Price = R.bprice
            End If

            ap.Bprice = R.bprice
            ap.BgColor = Color.White
            ap.SideColor = Color.Moccasin
            ap.id = id
            ap.arid = R.arid
            ap.Tva = 20
            If isUniqTva Then ap.Tva = R.tva
            ap.cid = R.cid
            ap.code = R.codebar
            ap.Poid = R.poid
            ap.Depot = CP.Depot ' R.depot
            If Form1.CbDepotOrigine.Checked Then ap.Depot = R.depot
            ap.Remise = 0

            ap.LbTva.Visible = Form1.CbArticleRemise.Visible

            If Form1.cbBaseOnStartedRemise.Checked Then ap.Remise = R.poid

            ''''''''
            Dim qte As Double = CP.Value

            Using c As SubClass = New SubClass

                If Form1.CbQteStk.Checked And isSell Then
                    Dim stk = c.getStock(ap.arid, ap.Depot, 0)
                    If qte >= stk Then qte = stk

                    If ClId = -1 Then qte = stk

                    If qte < 0 Then qte = 0
                End If

                ap.ColorStock = c.CheckForMinStock(ap.arid, ap.Depot, qte)
                ap.Stock = c.getStock(ap.arid, ap.Depot, qte)
            End Using

            ap.Qte = qte

            'ap.IsArabic = True

            AddHandler ap.Click, AddressOf ClearPanel
            AddHandler ap.ItemDoubleClick, AddressOf Item_Doubleclick
            AddHandler ap.Item_DoubleClick, AddressOf Item_ShowBlocModif
            AddHandler ap.RemiseChanged, AddressOf UpdateValue

            ap.SendToBack()
            Pl.Controls.Add(ap)

            If Form1.CbBlocModArt.Checked Then
                Item_ShowBlocModif(ap, Nothing)
                CP.ActiveQte(False)
            Else
                ap.IsSelected = True
                Item_Doubleclick(ap, Nothing)
            End If
            Pl.ScrollControlIntoView(ap)
            UpdateValue()
            CP.Value = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub AddItems(ByVal R As ALMohassinDBDataSet.ArticleRow)
        Try

            Dim ap As New Items
            ap.Dock = DockStyle.Top
            ap.Index = Pl.Controls.Count
            ap.Name = R.name
            ap.Unite = R.unite
            ap.Price = R.sprice

            ap.Bprice = R.bprice
            ap.BgColor = Color.White
            ap.SideColor = Color.Moccasin
            ap.id = CInt(R.arid + Pl.Controls.Count) * -1
            ap.arid = R.arid
            ap.Tva = R.tva
            ap.cid = R.cid
            ap.code = R.codebar
            ap.Poid = R.poid
            ap.Depot = R.depot
            ap.Remise = 0

            ap.LbTva.Visible = Form1.CbArticleRemise.Visible

            If Form1.cbBaseOnStartedRemise.Checked Then ap.Remise = R.poid

            ''''''''
            If Form1.CbQteStk.Checked Then
                Using c As SubClass = New SubClass
                    ap.ColorStock = c.CheckForMinStock(ap.arid, ap.Depot, CP.Value)
                    ap.Stock = c.getStock(ap.arid, ap.Depot, CP.Value)
                End Using
            End If


            ap.Qte = CP.Value

            'ap.IsArabic = True

            AddHandler ap.Click, AddressOf ClearPanel
            AddHandler ap.ItemDoubleClick, AddressOf Item_Doubleclick
            AddHandler ap.Item_DoubleClick, AddressOf Item_ShowBlocModif
            AddHandler ap.RemiseChanged, AddressOf UpdateValue


            Pl.Controls.Add(ap)
            ap.BringToFront()

            If Form1.CbBlocModArt.Checked Then
                Item_ShowBlocModif(ap, Nothing)
                CP.ActiveQte(False)
            Else
                ap.IsSelected = True
                Item_Doubleclick(ap, Nothing)
            End If

            Pl.ScrollControlIntoView(ap)
            UpdateValue()
            CP.Value = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub AddItems_F6_Product(ByVal pr As Double)
        Try

            Dim ap As New Items
            ap.Dock = DockStyle.Top
            ap.Index = Pl.Controls.Count
            ap.Name = "Article"
            ap.Unite = "U"
            ap.Price = pr

            ap.Bprice = pr
            ap.BgColor = Color.White
            ap.SideColor = Color.Moccasin
            ap.id = New Random().Next * -1
            ap.arid = 0
            ap.Tva = 20
            ap.cid = 0
            ap.code = "art"
            ap.Poid = 0
            ap.Depot = 0
            ap.Remise = 0
            ap.Qte = 1

            'ap.IsArabic = True

            AddHandler ap.Click, AddressOf ClearPanel
            AddHandler ap.ItemDoubleClick, AddressOf Item_Doubleclick
            AddHandler ap.Item_DoubleClick, AddressOf Item_ShowBlocModif
            AddHandler ap.RemiseChanged, AddressOf UpdateValue

            ap.SendToBack()
            Pl.Controls.Add(ap)

            If Form1.CbBlocModArt.Checked Then
                Item_ShowBlocModif(ap, Nothing)
                CP.ActiveQte(False)
            Else
                ap.IsSelected = True
                Item_Doubleclick(ap, Nothing)
            End If

            Pl.ScrollControlIntoView(ap)
            UpdateValue()
            CP.Value = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub AddItems__old(ByVal D As DataTable, ByVal isSell As Boolean)
        Try
            For i As Integer = 0 To D.Rows.Count - 1
                Dim RM As Double = CDbl(D.Rows(i).Item("poid"))

                If IsExiste(D.Rows(i).Item("arid"), D.Rows(i).Item("depot")) And Form1.cbMergeArt.Checked = True Then
                    Dim a As Items
                    Dim aaa_isExit = False

                    For Each a In Pl.Controls
                        If a.arid <> D.Rows(i).Item("arid") Then Continue For
                        If Math.Sign(a.Qte) <> Math.Sign(D.Rows(i).Item("qte")) Then Continue For

                        If a.Price = D.Rows(i).Item("price") And a.Remise = RM Then
                            a.Qte += D.Rows(i).Item("qte")
                            aaa_isExit = True
                            Exit For
                        End If
                    Next

                    AddItemDetails(D, i, RM)
                Else
                    AddItemDetails(D, i, RM)
                End If

            Next
            UpdateValue()
            CP.Value = 0
            CP.ActiveQte(False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub AddItems(ByVal D As DataTable, ByVal isSell As Boolean)
        Try
            For i As Integer = 0 To D.Rows.Count - 1
                Dim RM As Double = CDbl(D.Rows(i).Item("poid"))
                Dim ap As New Items
                Dim qte = D.Rows(i).Item("qte")

                ap.Dock = DockStyle.Top
                ap.Index = Pl.Controls.Count
                ap.Name = D.Rows(i).Item("name")
                ap.Unite = D.Rows(i).Item("unit")
                ap.Price = D.Rows(i).Item("price")
                ap.Qte = D.Rows(i).Item("qte")
                ap.Bprice = D.Rows(i).Item("bprice")
                ap.id = D.Rows(i).Item(0)
                ap.arid = D.Rows(i).Item("arid")
                ap.Tva = D.Rows(i).Item("tva")
                ap.cid = D.Rows(i).Item("cid")
                ap.Depot = D.Rows(i).Item("depot")
                ap.code = D.Rows(i).Item("code")

                ap.Remise = RM

                If qte < 0 Then
                    ap.isRetour = True
                    ap.Qte = qte * -1
                Else
                    ap.Qte = qte
                End If

                ap.BgColor = Color.White
                ap.SideColor = Color.Moccasin

                ap.LbTva.Visible = Form1.CbArticleRemise.Visible
                ''''''''
                If Form1.CbQteStk.Checked Then
                    Using c As SubClass = New SubClass
                        ap.ColorStock = c.CheckForMinStock(ap.arid, ap.Depot, ap.Qte)
                        ap.Stock = c.getStock(ap.arid, ap.Depot, ap.Qte)
                    End Using
                End If


                AddHandler ap.Click, AddressOf ClearPanel
                AddHandler ap.ItemDoubleClick, AddressOf Item_Doubleclick
                AddHandler ap.Item_DoubleClick, AddressOf Item_ShowBlocModif
                AddHandler ap.ItemValueChanged, AddressOf Item_Value_changed
                AddHandler ap.RemiseChanged, AddressOf UpdateValue


                Pl.Controls.Add(ap)
                ap.BringToFront()
                ap = Nothing
            Next
            UpdateValue()
            CP.Value = 0
            CP.ActiveQte(False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub AddItemsBouch(ByVal D As DataTable, ByVal isSell As Boolean)
        Try
            For i As Integer = 0 To D.Rows.Count - 1
                If D.Rows(i).Item("unit") <> "**" Then Continue For

                Dim RM As Double = CDbl(D.Rows(i).Item("poid"))

                If IsExiste(D.Rows(i).Item("arid"), D.Rows(i).Item("depot")) And Form1.cbMergeArt.Checked = True Then
                    Dim a As Items
                    Dim aaa_isExit = False

                    For Each a In Pl.Controls
                        If a.arid <> D.Rows(i).Item("arid") Then Continue For
                        If Math.Sign(a.Qte) <> Math.Sign(D.Rows(i).Item("qte")) Then Continue For

                        If a.Price = D.Rows(i).Item("price") And a.Remise = RM Then
                            a.Qte += D.Rows(i).Item("qte")
                            aaa_isExit = True
                            Exit For
                        End If
                    Next

                    AddItemDetails(D, i, RM)
                Else
                    AddItemDetails(D, i, RM)
                End If

            Next
            UpdateValue()
            CP.Value = 0
            CP.ActiveQte(False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub AddItemsRapport(ByVal D As DataTable)
        Try
            Dim ls As New List(Of String)
            For i As Integer = 0 To D.Rows.Count - 1
                Dim RM As Double = CDbl(D.Rows(i).Item("poid"))
                Dim id = D.Rows(i).Item("arid") & "|" & D.Rows(i).Item("price") & "|" & RM

                If ls.Contains(id) Then
                    Dim __i As Items
                    __i = Pl.Controls(ls.IndexOf(id))
                    __i.Qte += D.Rows(i).Item("qte")
                Else
                    ls.Add(id)
                    AddItemDetails(D, i, RM)
                End If
            Next
            UpdateValue()
            CP.Value = 0
            CP.ActiveQte(False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub AddItemDetails(ByVal d As DataTable, ByVal i As Integer, ByVal rm As Double)
        Dim ap As New Items
        Dim qte = d.Rows(i).Item("qte")


        ap.Dock = DockStyle.Top
        ap.Index = Pl.Controls.Count
        ap.Name = d.Rows(i).Item("name")
        ap.Unite = d.Rows(i).Item("unit")
        ap.Price = d.Rows(i).Item("price")
        ap.Qte = d.Rows(i).Item("qte")
        ap.Bprice = d.Rows(i).Item("bprice")
        ap.id = d.Rows(i).Item(0)
        ap.arid = d.Rows(i).Item("arid")
        ap.Tva = d.Rows(i).Item("tva")
        ap.cid = d.Rows(i).Item("cid")
        ap.Depot = d.Rows(i).Item("depot")
        ap.code = d.Rows(i).Item("code")

        ap.Remise = rm


        If qte < 0 Then
            ap.isRetour = True
            ap.Qte = qte * -1
        Else
            ap.Qte = qte
        End If

        ap.BgColor = Color.White
        ap.SideColor = Color.Moccasin

        ap.LbTva.Visible = Form1.CbArticleRemise.Visible
        ''''''''
        Using c As SubClass = New SubClass
            ap.ColorStock = c.CheckForMinStock(ap.arid, ap.Depot, ap.Qte)
            ap.Stock = c.getStock(ap.arid, ap.Depot, ap.Qte)
        End Using

        AddHandler ap.Click, AddressOf ClearPanel
        AddHandler ap.ItemDoubleClick, AddressOf Item_Doubleclick
        AddHandler ap.Item_DoubleClick, AddressOf Item_ShowBlocModif
        AddHandler ap.ItemValueChanged, AddressOf Item_Value_changed
        AddHandler ap.RemiseChanged, AddressOf UpdateValue

        ap.SendToBack()
        Pl.Controls.Add(ap)
        ap = Nothing
    End Sub
    Public Sub ChangedItemsDepot(ByRef id As Integer, ByVal dpid As Integer)

        Dim a As Items
        For Each a In Pl.Controls
            If a.id = id Then
                a.Depot = dpid

                Using c As SubClass = New SubClass
                    a.ColorStock = c.CheckForMinStock(a.arid, a.Depot, a.Qte)
                    a.Stock = c.getStock(a.arid, a.Depot, a.Qte)
                End Using

                Exit For
            End If
        Next
    End Sub
    Public Sub ChangedItemsQte(ByRef arid As Integer)

        Dim a As Items
        For Each a In Pl.Controls
            If a.arid = arid Then
                a.Qte += CP.Value

                UpdateValue()
                CP.Value = 0

                If Form1.CbBlocModArt.Checked = False Then
                    a.IsSelected = True
                    Item_Doubleclick(a, Nothing)
                End If

                Using c As SubClass = New SubClass
                    a.ColorStock = c.CheckForMinStock(a.arid, a.Depot, a.Qte)
                    a.Stock = c.getStock(a.arid, a.Depot, a.Qte)
                End Using
                Exit For
            End If
        Next
    End Sub
    Public Sub ChangedItemsQte(ByRef arid As Integer, ByVal dpid As Integer, ByVal qte As Double)

        Dim a As Items
        For Each a In Pl.Controls
            If a.arid = arid And a.Depot = dpid And a.isRetour = False Then
                a.Qte = qte  '+= CP.Value

                UpdateValue()
                CP.Value = 0

                If Form1.CbBlocModArt.Checked = False Then
                    a.IsSelected = True
                    Item_Doubleclick(a, Nothing)
                End If

                If Form1.CbQteStk.Checked Then
                    Using c As SubClass = New SubClass
                        a.ColorStock = c.CheckForMinStock(a.arid, a.Depot, a.Qte)
                        a.Stock = c.getStock(a.arid, a.Depot, a.Qte)
                    End Using
                End If

                Exit For
            End If
        Next
    End Sub
    Public Sub ChangedItems(ByRef id As Integer, ByVal prdname As String, ByVal bprice As Double, ByVal price As Double, ByVal qte As Double, ByVal dpt As Integer)

        Dim a As Items
        For Each a In Pl.Controls
            If a.id = id Then
                a.Name = prdname
                a.Bprice = bprice
                a.Price = price
                a.Qte = qte
                a.Depot = dpt

                UpdateValue()
                CP.Value = 0

                If Form1.CbQteStk.Checked Then
                    Using c As SubClass = New SubClass
                        a.ColorStock = c.CheckForMinStock(a.arid, a.Depot, a.Qte)
                        a.Stock = c.getStock(a.arid, a.Depot, a.Qte)
                    End Using
                End If

                Exit For
            End If
        Next
    End Sub
    Public Sub ChangedItemsQte(ByRef id As Integer, ByVal q As Double, ByVal field As String)
        Dim a As Items
        For Each a In Pl.Controls
            If a.id = id Then
                If field = "qte" Then
                    a.Qte = q
                Else
                    a.Price = q
                End If
                UpdateValue()
                CP.Value = 0
                Exit For
            End If
        Next
    End Sub
    Public Sub DeleteItems()
        Dim a As Items
        For Each a In Pl.Controls
            If a.IsSelected = True Then
                Pl.Controls.Remove(a)

                UpdateValue()
                CP.Value = 0
                Exit For
            End If
        Next
    End Sub
    Public Sub ClearItems()
        Pl.Controls.Clear()
        _Total = 0


        If Form1.isBaseOnRIYAL Then
            LbSum.Text = CInt(Total_TTC)
        Else
            LbSum.Text = Total_TTC
        End If

        LbTva.Text = "Tva : 0"
        LbVidal.Text = Pl.Controls.Count & " - Vidals"
        lbHT.Text = "T. Ht : " & String.Format("{0:n}", Total_Ht)
        Avance = 0
        FctId = 0
        Remise = 0
        bl = "---"
        lbProfit.Text = "[]"
        delivredDay = "-"
        Dte = Now
    End Sub
    Public Function IsExiste(ByVal arid As Integer) As Boolean
        Dim a As Items
        If Pl.Controls.Count = 0 Then
            Return False
        End If
        For Each a In Pl.Controls
            If a.arid = arid Then
                Return True
                Exit Function
            End If
        Next
        Return False
    End Function
    Public Function IsExiste(ByVal arid As Integer, ByVal dpid As Integer) As Boolean
        Dim a As Items
        If Pl.Controls.Count = 0 Then
            Return False
        End If
        For Each a In Pl.Controls
            If a.arid = arid And a.Depot = dpid And a.isRetour = False Then
                Return True
                Exit Function
            End If
        Next
        Return False
    End Function
    Public Function SelectedItems(ByVal arid As Integer, ByVal dpid As Integer) As Items
        Dim a As Items
        If Pl.Controls.Count = 0 Then
            Return Nothing
        End If
        For Each a In Pl.Controls
            If a.arid = arid And a.Depot = dpid And a.isRetour = False Then
                Return a
                Exit Function
            End If
        Next
        Return Nothing
    End Function
    Public Function SelectedQte(ByVal arid As Integer) As Double
        Dim a As Items
        If Pl.Controls.Count = 0 Then
            Return 0
        End If
        For Each a In Pl.Controls
            If a.arid = arid Then
                Return a.Qte
                Exit Function
            End If
        Next
        Return 0
    End Function
    Private Sub ClearPanel(ByVal sender As Object, ByVal e As EventArgs)
        Dim i As Items = sender
        IIf(i.IsSelected, False, True)

    End Sub
    Private Sub UpdateValue()
        Try

            If Form1.isBaseOnRIYAL Then
                LbSum.Text = Total_TTC.ToString("N0")

                lbHT.Text = "T. Ht : " & Total_Ht.ToString("N0")
                LbTva.Text = "Tva : " & CInt(Tva)
                lbremise.Text = "Remise = " & CInt(Total_Remise).ToString("N0")
                lbDh.Text = "( " & CDbl(Total_TTC / 20).ToString("N2") & " Dh )"
            Else
                LbSum.Text = String.Format("{0:n}", Total_TTC)

                lbHT.Text = "T. Ht : " & String.Format("{0:n}", Total_Ht)
                LbTva.Text = "Tva : " & String.Format("{0:n}", Tva)
                lbremise.Text = "Remise = " & String.Format("{0:n}", CDec(Total_Remise))

            End If

            LbVidal.Text = Pl.Controls.Count & " - Articles"

            'lbHT.Text = "T. Ht : " & String.Format("{0:n}", CDec(Total_Ht - (Total_Ht * Remise / 100)))


            Try
                If ShowProfit Then
                    lbProfit.Text = "[" & TotalProfit_ht.ToString(Form1.frmDbl) & " - " & (TotalProfit_ht * 100 / Total_Ht).ToString("N0") & "%]"
                End If
            Catch ex As Exception
            End Try

            RaiseEvent UpdateValueChanged()

            If _isEditing = False Then Exit Sub
            RaiseEvent EditingItemValueChanged(_oldValue, _newValue, _Field, _editingItem)
            _isEditing = False
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Item_Doubleclick(ByVal sender As Object, ByVal e As EventArgs)
        Dim it As Items = sender

        For Each i As Items In Pl.Controls
            If i.id = it.id Then Continue For
            i.IsSelected = False
        Next

        CP.ActiveQte(it.IsSelected)
    End Sub
    Private Sub Item_ShowBlocModif(ByVal sender As Object, ByVal e As EventArgs)
        '_oldValue = SelectedItem.Qte
        Dim itm As Items = sender
        If Form1.cbBadgeMA.Checked And EditMode Then
            Try
                Dim sc As New UserParmissionCheck
                sc.bName.Text = Form1.RPl.SelectedItem.Name
                sc.lbNum.Text = Form1.RPl.SelectedItem.Qte
                If sc.ShowDialog = DialogResult.OK Then

                    If itm.cid = 0 Then Exit Sub
                    itm.IsSelected = True
                    Item_Doubleclick(itm, e)

                    RaiseEvent UpdateItem(itm, Nothing)
                End If
               
            Catch ex As Exception
            End Try

            Exit Sub
        End If

        If itm.cid = 0 Then Exit Sub
        itm.IsSelected = True
        Item_Doubleclick(itm, e)

        RaiseEvent UpdateItem(itm, Nothing)
    End Sub

    Private Sub CP_ReturnItem() Handles CP.ReturnItem
        If EditMode = True Then Exit Sub

        Dim str As String = " عند قيامكم على الضغط على 'موافق' سيتم "
        str = str + vbNewLine
        str = str + " نقل هذه المادة ما بين لائحة المود و المرجوعات..    "
        str = str + vbNewLine
        str = str + "  .. إضغط  'لا'  لالغاء النقل   "

        If MsgBox(str, MsgBoxStyle.YesNo Or MessageBoxIcon.Exclamation, "الغاء الفاتورة") = MsgBoxResult.No Then
            RaiseEvent CPValueChange()
            Exit Sub
        End If

        RaiseEvent ReturnItem(SelectedItem, Nothing)
        UpdateValue()
    End Sub
    Private Sub CP_UpdateQte() Handles CP.UpdateQte
        _oldValue = SelectedItem.Qte
        If SelectedItem.cid = 0 Then Exit Sub
        RaiseEvent UpdateQte(Me, Nothing)
        'If EditMode Then RaiseEvent SaveFacture(FctId, Total, Avance, Tva, DataSource)
    End Sub
    Private Sub CP_UpdatePrice() Handles CP.UpdatePrice
        RaiseEvent UpdatePrice(Me, Nothing)
    End Sub
    Private Sub CP_DeleteItems() Handles CP.DeleteItems
        _oldValue = SelectedItem.Qte
        RaiseEvent DeleteItem(SelectedItem, FctId)
        CP.ActiveQte(False)
        If EditMode Then
            _isEditing = True
            Item_Value_changed(0, 0, "Non", SelectedItem)

        End If

        UpdateValue()
        If EditMode Then CP.txt.Focus()
    End Sub
    Private Sub CP_UpdatePayment() Handles CP.UpdatePayment
        If FctId = 0 Then
            RaiseEvent CPValueChange()
            Exit Sub
        End If
        RaiseEvent UpdatePayment()
        If EditMode Then RaiseEvent EditingItemValueChanged(0, 0, "not", _editingItem) 'SaveFacture(FctId, Total, Avance, Tva, DataSource)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSave.Click
        If FctId = 0 Then
            RaiseEvent CPValueChange()
            Exit Sub
        End If

        If EditMode Then
            If Form1.cbBadgeMB.Checked Then
                Try
                    Dim sc As New UserParmissionCheck
                    sc.bName.Text = Form1.RPl.ClientName
                    sc.lbNum.Text = Form1.RPl.FctId
                    If sc.ShowDialog = DialogResult.OK Then
                        RaiseEvent EditFacture(FctId, ClId, ClientName, Total_TTC, Avance, DataSource)
                    End If
                Catch ex As Exception
                End Try

                Exit Sub
            End If

            RaiseEvent EditFacture(FctId, ClId, ClientName, Total_TTC, Avance, DataSource)
        Else
            RaiseEvent SaveFacture(FctId, Total_TTC, Avance, Tva, DataSource)

            If Form1.cbTiroir.Checked Then
                'Modify DrawerCode to your receipt printer open drawer code
                Dim DrawerCode As String = Chr(27) & Chr(112) & Chr(48) & Chr(64) & Chr(64)
                'Modify PrinterName to your receipt printer name
                Dim PrinterName As String = Form1.txtreceipt.Text

                RawPrinter.PrintRaw(PrinterName, DrawerCode)
            End If
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtPrint.Click, BtBlPrint.Click

        Form1.page_Number = 1

        Dim BT As Button = sender
        Dim SecondModel As Boolean = False
        If My.Computer.Keyboard.CtrlKeyDown Then SecondModel = True

        If FctId = 0 Then
            RaiseEvent CPValueChange()
            If ClId = -111 Then
                RaiseEvent printCaisse()
                Exit Sub
            End If

            Try
                If DataSource.Rows.Count > 0 And EditMode Then
                    FctId = CInt(Form1.DGVARFA.SelectedRows(0).Cells(0).Value)
                    RaiseEvent SaveAndPrint(FctId, Total_TTC, Avance, Tva, DataSource, isSell, CBool(BT.Tag), SecondModel)
                    FctId = 0
                    Exit Sub
                Else
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try
        End If

        RaiseEvent SaveAndPrint(FctId, Total_TTC, Avance, Tva, DataSource, isSell, CBool(BT.Tag), SecondModel)

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDel.Click
        If FctId = 0 Then
            RaiseEvent CPValueChange()
            Exit Sub
        End If

        Dim str As String = " عند قيامكم على الضغط على 'موافق' سيتم حذف ايصال "
        str = str + vbNewLine
        str = str & ClientName & " ( " & FctId & ")"
        str = str + vbNewLine
        str = str + " و جميع المواد الدفعات المسجلة في القائمة ..    "
        str = str + vbNewLine
        str = str + "  .. إضغط  'لا'  لالغاء الحذف   "

        If MsgBox(str, MsgBoxStyle.YesNo Or MessageBoxIcon.Exclamation, "الغاء الايصال") = MsgBoxResult.No Then
            Exit Sub
        End If

        If Form1.cbBadgeSB.Checked And EditMode Then
            Try
                Dim sc As New UserParmissionCheck
                sc.bName.Text = "Bon N° " & FctId
                sc.lbNum.Text = Total_TTC
                If sc.ShowDialog = DialogResult.OK Then
                    RaiseEvent DeleteFacture(FctId, isSell, EditMode, DataSource)
                End If
            Catch ex As Exception
            End Try

            Exit Sub
        End If

        RaiseEvent DeleteFacture(FctId, isSell, EditMode, DataSource)
    End Sub
    Private Sub Item_Value_changed(ByVal oldValue As Double, ByVal newValue As Double, ByVal Field As String, ByVal itm As Items)
        If EditMode = False Then Exit Sub
        If EditMode Then _isEditing = True
        _oldValue = oldValue
        _newValue = newValue
        _Field = Field
        _editingItem = itm
        ' RaiseEvent EditingItemValueChanged(oldValue, newValue, Field, itm)
    End Sub
    Private Sub CP_UpdateRemise() Handles CP.UpdateRemise
        If FctId = 0 Then
            RaiseEvent CPValueChange()
            Exit Sub
        End If
        Remise = InputBox("Remise =  ")
        If Not IsNumeric(Remise) Then
            Remise = 0
        End If

        RaiseEvent UpdateBl()
    End Sub
    Private Sub CP_UpdateClient() Handles CP.UpdateClient
        If FctId = 0 Then
            RaiseEvent CPValueChange()
            Exit Sub
        End If



        RaiseEvent UpdateClient()
        'If EditMode Then
        '    RaiseEvent UpdateClient()
        'Else

        '    Dim clc As New ChoseLivreur
        '    If clc.ShowDialog = DialogResult.OK Then
        '        Try
        '            bl = clc.DataGridView1.SelectedRows(0).Cells(0).Value
        '        Catch ex As Exception
        '            bl = "---"
        '        End Try

        '        If clc.Button1.Tag = 2 Then bl = "-"
        '    End If
        '    RaiseEvent SetDetailFacture()
        'End If
    End Sub
    Private Sub CP_ValueChange() Handles CP.ValueChange
        RaiseEvent CPValueChange()
    End Sub
    Private Sub CP_UpdateArticleRemise() Handles CP.UpdateArticleRemise
        If FctId = 0 Then Exit Sub
        RaiseEvent UpdateArticleRemise(SelectedItem)
        UpdateValue()
    End Sub

    Private Sub CP_UpdateArticledepot() Handles CP.UpdateArticledepot
        If FctId = 0 Then Exit Sub
        If SelectedItem.cid = 0 Then
            RaiseEvent CPValueChange()
            Exit Sub
        End If

        RaiseEvent UpdateDepot(Me, Nothing)
    End Sub

    Private Sub CP_UpdatearicleDetails() Handles CP.UpdatearicleDetails
        'bl = InputBox("Designation =  ")
        'RaiseEvent SetDetailArticle(bl, SelectedItem)
    End Sub

    Private Sub CP_CommandeDate() Handles CP.CommandeDate
        If FctId = 0 Then
            RaiseEvent CPValueChange()
            Exit Sub
        End If
        'RaiseEvent CommandeDate()




        If isSell Then
            Dim clc As New ChoseLivreur
            If clc.ShowDialog = DialogResult.OK Then
                Try
                    bl = clc.DataGridView1.SelectedRows(0).Cells(0).Value
                    ' bl = InputBox("Infos =  ")
                Catch ex As Exception
                    bl = "---"
                End Try

                If clc.Button1.Tag = 2 Then bl = "-"
            End If
        Else
            bl = InputBox("Infos / Ref :", "BON D'ACHATS ..", bl)
        End If

            RaiseEvent SetDetailFacture()
    End Sub

    Dim hh As Integer = 0
    Private Sub Panel2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseDown
        hh = e.Y
    End Sub

    Private Sub Panel2_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseUp
        If hh = 0 Then Exit Sub

        Form1.RplHeight = CP.Height + (hh - e.Y)
        hh = 0
    End Sub

    Private Sub lbDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbDate.Click
        RaiseEvent UpdateDate()
    End Sub
End Class
