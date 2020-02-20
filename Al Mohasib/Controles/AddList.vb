Imports MyBarcode

Public Class AddList
    'Event 
    Public Event RefreshData(ByVal Data As Dictionary(Of String, Object))
    Public Event NewKey(ByRef sender As Object, ByVal Key As String)
    Public Event SaveColor(ByVal Data As Dictionary(Of String, Object), ByVal Dataliste As Dictionary(Of String, Object), ByVal p As String)
    Public Event UpdateColor(ByVal Data As Dictionary(Of String, Object), ByVal where As Dictionary(Of String, Object), ByVal difParams As Dictionary(Of String, Object), ByVal p As String)
    'Membres
    Private _DataListe As New Dictionary(Of String, Object)
    Public _oldDataListe As New Dictionary(Of String, Object)
    Private _autocomplite As AutoCompleteStringCollection
    Private _hasValue As Boolean = True
    Private _barCode As String
    Private _editMode As Boolean
    Private _price As Double
    Private _bprice As Double
    Public id As Integer
    Public p As String

    'Properties
    Public Shadows Property HasValue() As Boolean
        Get
            Return _hasValue
        End Get
        Set(ByVal value As Boolean)
            _hasValue = value
        End Set
    End Property
    Public Property AutoCompleteSource() As AutoCompleteStringCollection
        Get
            Return _autocomplite
        End Get
        Set(ByVal value As AutoCompleteStringCollection)
            _autocomplite = value
        End Set
    End Property
    Public Property DataListe() As Dictionary(Of String, Object)
        Get
            Return _DataListe
        End Get
        Set(ByVal value As Dictionary(Of String, Object))
            Pl.Controls.Clear()
            _DataListe.Clear()
            Dim h As Integer = 0
            Dim a As KeyValuePair(Of String, Object)
            For Each a In value
                DataListe.Add(a.Key, a.Value)
                Dim ap As New AddPanel
                ap.Dock = DockStyle.Top
                ap.index = Pl.Controls.Count
                ap.Key = a.Key
                ap.Val = CStr(a.Value)
                AddHandler ap.Clear, AddressOf ClearPanel
                AddHandler ap.ValChanged, AddressOf Val_Changed
                Pl.Controls.Add(ap)
                h += ap.Height
            Next
            Pl.Height = h + 50
            Me.Height = h + 80
            _DataListe = value
        End Set
    End Property

    Public Property barCode As String
        Get
            Return _barCode
        End Get
        Set(ByVal value As String)
            _barCode = value
            TextBox1.Text = "Code Bar : " & value
        End Set
    End Property
    Public Property EditMode As Boolean
        Get
            Return _editMode
        End Get
        Set(ByVal value As Boolean)
            _editMode = value
        End Set
    End Property
    Public Property price As Double
        Get
            Return _price
        End Get
        Set(ByVal value As Double)
            _price = value
            TxtBox1.text = value
        End Set
    End Property
    Public Property bprice As Double
        Get
            Return _bprice
        End Get
        Set(ByVal value As Double)
            _bprice = value
        End Set
    End Property
    'sub for clear
    Public Sub Clearliste()
        If EditMode Then EditMode = False
        DataListe.Clear()
        Pl.Controls.Clear()
        txtQte.text = ""
        txtName.text = ""
        txtprice.text = 0
        barCode = GetRandom(10000000, 99999999)
    End Sub
    Public Sub AddItems(ByVal _id As Integer, ByVal elements As String, ByVal _p As String,
                        ByVal name As String, ByVal codebar As String)
        Try
            id = _id
            p = _p
            EditMode = True
            txtName.text = name
            barCode = codebar

            DataListe.Clear()
            _oldDataListe.Clear()

            Dim h As Integer = 0
            elements = elements.Substring(1, elements.Length - 2)
            Dim str As String() = elements.Split("}*{")


            For i As Integer = 0 To str.Length - 1
                Dim ap As New AddPanel

                ap.Key = str(i).Split("|||")(0)
                ap.Val = str(i).Split("|||")(1)

                ap.Dock = DockStyle.Top
                ap.index = Pl.Controls.Count
                ap.AutoCompleteSource = _autocomplite
                ap.HasValue = _hasValue

                AddHandler ap.Clear, AddressOf ClearPanel
                AddHandler ap.ValChanged, AddressOf Val_Changed
                AddHandler ap.PriceChanged, AddressOf Val_Changed
                AddHandler ap.NewKeyVal, AddressOf New_KeyVal
                AddHandler ap.AddNewPanel, AddressOf New_Panel
                Pl.Controls.Add(ap)
                Pl.Height = h + 50
                Me.Height = h + 80

                DataListe.Add(str(i).Split("|||")(0), str(i).Split("|||")(1))
                _oldDataListe.Add(str(i).Split("|||")(0), str(i).Split("|||")(1))
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    'handle the events
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        DataListe.Clear()
        Dim h As Integer = 0
        Try
            For Each a As AddPanel In Pl.Controls
                DataListe.Add(a.Key, a.Val)
                a.enabled = False
                h += a.Height
            Next
        Catch ex As Exception
            Exit Sub
        End Try

        Dim ap As New AddPanel
        ap.Dock = DockStyle.Top
        ap.index = Pl.Controls.Count
        ap.AutoCompleteSource = _autocomplite
        ap.HasValue = _hasValue

        AddHandler ap.Clear, AddressOf ClearPanel
        AddHandler ap.ValChanged, AddressOf Val_Changed
        AddHandler ap.PriceChanged, AddressOf Val_Changed
        AddHandler ap.NewKeyVal, AddressOf New_KeyVal
        AddHandler ap.AddNewPanel, AddressOf New_Panel
        Pl.Controls.Add(ap)
        Pl.Height = h + 50
        Me.Height = h + 80
        ap.Focus()

    End Sub
    Public Sub Val_Changed(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ap As AddPanel = CType(sender, AddPanel)
        Try
            DataListe(ap.Key) = ap.Val
            RaiseEvent RefreshData(_DataListe)

            Dim P As Double = 0
            Dim B As Double = 0
            Dim a As AddPanel
            For Each a In Pl.Controls
                P += a.price * a.Val
                B += a.bPrice * a.Val
            Next
            price = P
            bprice = B
        Catch ex As Exception
        End Try
    End Sub
    Public Sub ClearPanel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ap As AddPanel = CType(sender, AddPanel)
        For Each a As AddPanel In Pl.Controls
            If ap.Val = a.Val And ap.Key = a.Key Then
                DataListe.Remove(a.Key)
                Pl.Controls.Remove(a)
                RaiseEvent RefreshData(_DataListe)
                Exit For
            End If
        Next
        Me.Height -= 30

    End Sub
    Public Sub New_KeyVal(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim ap As AddPanel = CType(sender, AddPanel)
            _DataListe.Add(ap.Key, ap.Val)
            RaiseEvent NewKey(sender, ap.Key)
        Catch ex As Exception

        End Try
        RaiseEvent RefreshData(_DataListe)
    End Sub
    Public Sub New_Panel(ByVal sender As Object, ByVal e As System.EventArgs)
        LinkLabel1_LinkClicked(Nothing, Nothing)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then Exit Sub
        Dim cde As String = barCode
        If cde.Length > 12 Then cde = cde.Substring(0, 12)
        If cde.Length < 12 Then cde = cde.Substring(0, 12)

        Dim CD As New BarCode
        CD.Code = cde
        CD.article = txtName.text
        CD.qte = txtQte.text

        If CD.ShowDialog = DialogResult.OK Then

        End If
    End Sub
    'save the color mixed
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If txtQte.text.Trim = "" Or txtName.text.Trim = "" Or txtprice.text.Trim = "" Then Exit Sub
        If DataListe.Count = 0 Then Exit Sub
        Dim price As Double = CDbl(txtprice.text)

        Dim elements As String = ""
        For Each kv As KeyValuePair(Of String, Object) In DataListe
            elements &= kv.Key & " & " & kv.Value & "*"
        Next
        elements = elements.Substring(0, elements.Length - 1)

        Dim params As New Dictionary(Of String, Object)
        params.Add("cid", 0)
        params.Add("name", txtName.text)
        params.Add("bprice", bprice)
        params.Add("sprice", price)
        params.Add("unite", txtQte.text)
        params.Add("codebar", barCode)
        params.Add("tva", 20)
        params.Add("sp3", price)
        params.Add("sp4", price)
        params.Add("sp5", price)
        params.Add("poid", 1)
        params.Add("depot", p)
        params.Add("mixte", False)
        params.Add("isMixte", True)
        params.Add("elements", elements)

        Dim where As New Dictionary(Of String, Object)
        where.Add("arid", id)


        Dim difParams As New Dictionary(Of String, Object)
        If EditMode Then
            For Each kv As KeyValuePair(Of String, Object) In _oldDataListe
                If DataListe.ContainsKey(kv.Key) Then
                    Dim qte As Double = CStr(DataListe.Item(kv.Key))
                    qte -= CStr(kv.Value)
                    difParams.Add(kv.Key, qte)
                Else
                    difParams.Add(kv.Key, kv.Value)
                End If
            Next
            For Each kv As KeyValuePair(Of String, Object) In DataListe
                If Not _oldDataListe.ContainsKey(kv.Key) Then
                    Dim qte As Double = CStr(kv.Value) * -1
                    difParams.Add(kv.Key, qte)
                End If
            Next
        End If

        If EditMode Then
            RaiseEvent UpdateColor(params, difParams, where, p)
        Else
            RaiseEvent SaveColor(params, DataListe, p)
        End If

        params = Nothing
        where = Nothing
    End Sub
End Class
