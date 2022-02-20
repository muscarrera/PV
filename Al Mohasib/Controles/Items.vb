Public Class Items
    Public Event ItemDoubleClick(ByVal sender As Object, ByVal e As EventArgs)
    Public Event Item_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
    Public Event ItemValueChanged(ByVal oldValue As Double, ByVal newValue As Double, ByVal Field As String, ByVal itm As Items)
    Public Event RemiseChanged()
    'Members
    Private _addDesc As String
    Private _showDesc As Boolean

    Private _qte As Decimal
    Private _price As Decimal
    Public _total As Decimal
    Private _tva As Double
    Private _stock As Double
    Private _index As Integer
    Private _color As Color
    Private _BgColor As Color
    Private _isSelected As Boolean
    Private _remise As Integer
    Private _code As String
    Private _name As String
    Private _colorStock As Integer = 0

    Public id As Integer
    Public arid As Integer

    Public Unite As String
    Public Bprice As Double
    Public Poid As Double
    Public cid As Integer
    Private _depot As Integer

    'properties
    Public Property isRetour As Boolean
        Get
            Return plRet.Visible
        End Get
        Set(ByVal value As Boolean)
            plRet.Visible = value

            If value Then
                LbName.Tag = LbName.ForeColor
                LbName.BackColor = Color.Red
                LbTotal.BackColor = Color.Red
                LbName.ForeColor = Color.White
                LbTotal.ForeColor = Color.White

            Else
                LbName.BackColor = Color.Transparent
                LbTotal.BackColor = Color.Transparent
                LbName.ForeColor = LbName.Tag
                LbTotal.ForeColor = Color.DarkCyan
            End If

            RaiseEvent ItemValueChanged(Qte * -1, Qte, "qte", Me)
            '''''''

            _total = _price * Qte

            If Form1.isBaseOnRIYAL Then
                LbTotal.Text = Total_ttc.ToString("N0")
            Else
                LbTotal.Text = String.Format("{0:n}", Total_ttc)
            End If
        End Set
    End Property
    Public ReadOnly Property Total_ttc() As Decimal
        Get
            Dim t As Decimal = 0
            If Remise > 0 Then
                t = Total_ht + Total_tva
            Else
                t = _total
            End If

            Return t
        End Get
    End Property
    Public ReadOnly Property Total_ht() As Decimal
        Get
            Dim t As Decimal = _total / ((100 + Tva) / 100)
            t -= (t * Remise) / 100


            Return t
        End Get
    End Property
    Public ReadOnly Property Total_tva() As Decimal
        Get
            Dim t As Decimal = Total_ht
            t = (t * Tva) / 100
            Return t
        End Get
    End Property
    Public ReadOnly Property Total_remise() As Decimal
        Get
            Dim t As Decimal = _total / ((100 + Tva) / 100)
            t = (t * Remise) / 100
            Return t
        End Get
    End Property
    Public ReadOnly Property Profit_ht() As Decimal
        Get
            Dim t As Decimal = (Qte * Bprice) / ((100 + Tva) / 100)
            't -= (t * Remise) / 100
            t = Total_ht - t
            Return t
        End Get
    End Property

    Shadows Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
            FullName = _name '& " " & _code
        End Set
    End Property
    Shadows Property code() As String
        Get
            Return _code
        End Get
        Set(ByVal value As String)
            _code = value
            ' FullName = _name & " " & _code
        End Set
    End Property
    Shadows Property FullName() As String
        Get
            Return LbName.Text
        End Get
        Set(ByVal value As String)
            LbName.Text = value
        End Set
    End Property

    Public Property Qte() As Decimal
        Get
            Dim t = _qte
            If isRetour Then t = t * -1
            Return t
        End Get
        Set(ByVal value As Decimal)
            '''''''
            RaiseEvent ItemValueChanged(Qte, value, "qte", Me)
            '''''''
            _qte = value
            _total = _price * value
            If isRetour Then _total = _price * value * (-1)


            If Form1.isBaseOnRIYAL Then
                LbTotal.Text = Total_ttc.ToString("N0")
            Else
                LbTotal.Text = String.Format("{0:n}", Total_ttc)
            End If

            LbQte.Text = _qte & " " & CStr(Unite) '& " x "
            'LbQte.Text &= String.Format("{0:n}", _price) & " Dhs  -  " '& "  (" & _addDesc & ")"
            'If Depot > 0 Then LbQte.Text &= " [Rest : (" & Stock & ")]"

        End Set
    End Property
    Public Property Price() As Decimal
        Get
            Return _price
        End Get
        Set(ByVal value As Decimal)
            '''''''
            RaiseEvent ItemValueChanged(_price, value, "price", Me)
            '''''''
            _price = value
            _total = Qte * value

            If Form1.isBaseOnRIYAL Then
                LbTotal.Text = Total_ttc.ToString("N0")
                LbPrice.Text = CInt(_price).ToString("N0") & " Rys"
            Else
                LbTotal.Text = String.Format("{0:n}", Total_ttc)
                LbPrice.Text = String.Format("{0:n}", _price) & " Dhs"
            End If

        End Set
    End Property
    Public Property Depot() As Decimal
        Get
            Return _depot
        End Get
        Set(ByVal value As Decimal)
            '''''''
            _depot = value

            'LbQte.Text = _qte & " " & CStr(Unite) & " x "
            'LbQte.Text &= String.Format("{0:n}", _price) & " Dhs  -  "
            LbStk.Text = ""
            If Depot > 0 Then LbStk.Text = " [" & Depot & "] Rest : (" & Stock & ")"

        End Set
    End Property
    Public Property Tva() As Double
        Get
            Return _tva
        End Get
        Set(ByVal value As Double)
            _tva = value
            LbTva.Text = "Tva:" & value & "%"
            If Remise > 0 Then LbTva.Text &= "-R:" & Remise & "%"
        End Set
    End Property
    Public Property Index As Integer
        Get
            Return _index
        End Get
        Set(ByVal value As Integer)
            _index = value
        End Set
    End Property
    Public Property SideColor() As Color
        Get
            Return _color
        End Get
        Set(ByVal value As Color)
            _color = value
        End Set
    End Property
    Public Property BgColor() As Color
        Get
            Return _BgColor
        End Get
        Set(ByVal value As Color)
            _BgColor = value
            Pl.BackColor = value
        End Set
    End Property
    Public Property IsSelected As Boolean
        Get
            Return _isSelected
        End Get
        Set(ByVal value As Boolean)
            _isSelected = value
            If value Then
                Pl.BackColor = _color
            Else
                Pl.BackColor = _BgColor
            End If
        End Set
    End Property
    Public Property IsArabic As Boolean
        Get
            Return True
        End Get
        Set(ByVal value As Boolean)
            If value Then
                LbTotal.Dock = DockStyle.Left
                LbName.TextAlign = ContentAlignment.MiddleRight
                LbTotal.TextAlign = ContentAlignment.MiddleLeft

                LbQte.Dock = DockStyle.Right
                Label2.Dock = DockStyle.Right
                LbPrice.Dock = DockStyle.Right
                Label3.Dock = DockStyle.Right
                LbStk.Dock = DockStyle.Right

                LbTva.Dock = DockStyle.Left
                LbTva.TextAlign = ContentAlignment.MiddleLeft
            End If
        End Set
    End Property

    Public Property Remise() As Integer
        Get
            Return _remise
        End Get
        Set(ByVal value As Integer)
            If value > 100 Then value = 100
            If value < 0 Then value = 0
            If Form1.CbArticleRemise.Checked = False Then value = 0

            _remise = value
            LbTva.Text = "Tva:" & Tva & "%"
            If value > 0 Then LbTva.Text &= "-R:" & value & "%"

            If Form1.isBaseOnRIYAL Then
                LbTotal.Text = Total_ttc.ToString("N0")
            Else
                LbTotal.Text = String.Format("{0:n}", Total_ttc)
            End If

            RaiseEvent RemiseChanged()
        End Set
    End Property
    Public Property ShowDesc As Boolean
        Get
            Return _showDesc
        End Get
        Set(ByVal value As Boolean)
            _showDesc = value

            LbQte.Visible = value
            LbTva.Visible = value
        End Set
    End Property
    Public Property ColorStock() As Integer
        Get
            Return _colorStock
        End Get
        Set(ByVal value As Integer)

            _colorStock = value

            If value = 0 Then
                LbName.ForeColor = Color.DarkCyan
            ElseIf value = 1 Then
                LbName.ForeColor = Color.Orange
            Else
                LbName.ForeColor = Color.Red
            End If

            If Depot = 0 Then LbName.ForeColor = Color.Black
        End Set
    End Property
    Public Property Stock() As Double
        Get
            Return _Stock
        End Get
        Set(ByVal value As Double)

            _Stock = value

            'LbQte.Text = String.Format("{0:n}", _qte) & " " & CStr(Unite) & " x "
            'LbQte.Text &= String.Format("{0:n}", _price) & " Dhs  -  "
            LbStk.Text = ""
            If Depot > 0 Then LbStk.Text = " [" & Depot & "] Rest : (" & Stock & ")"

        End Set
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        IsArabic = Form1.cbArticleItemDirection.Checked
        If Form1.cbItemCheckBox.Checked Then plCheck.Visible = True

    End Sub
    Private Sub PlBody_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pl.Click, LbQte.Click, LbName.Click, LbTotal.Click, LbTva.Click, Panel1.Click, LbStk.Click, LbPrice.Click, Label3.Click, Label2.Click
        If IsSelected = True Then
            IsSelected = False
        Else
            IsSelected = True
        End If
        RaiseEvent ItemDoubleClick(Me, e)
    End Sub

    Private Sub Pl_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pl.DoubleClick, LbTva.DoubleClick, LbTotal.DoubleClick, LbName.DoubleClick, LbQte.DoubleClick, LbStk.DoubleClick, LbPrice.DoubleClick, Label3.DoubleClick, Label2.DoubleClick
        RaiseEvent Item_DoubleClick(Me, e)
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        'CheckBox1.Checked = Not CheckBox1.Checked

        If CheckBox1.Checked Then
            CheckBox1.BackColor = Color.Green
        Else
            CheckBox1.BackColor = Color.Transparent
        End If
    End Sub
End Class
