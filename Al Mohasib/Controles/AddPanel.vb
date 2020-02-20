Public Class AddPanel
    'Members
    Private _index As Integer
    Private _hasValue As Boolean = True
    Private _price As Double
    Private _bPrice As Double
    'Eents
    Public Event ValChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event KeyChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event PriceChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event NewKeyVal(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event AddNewPanel(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event Clear(ByVal sender As Object, ByVal e As System.EventArgs)

    'Properties
    Public Property AutoCompleteSource() As AutoCompleteStringCollection
        Get
            Return Nothing
        End Get
        Set(ByVal value As AutoCompleteStringCollection)
            TXTKEY.AutoCompleteSource = value
        End Set
    End Property
    Public Property index() As Integer
        Get
            Return _index
        End Get
        Set(ByVal value As Integer)
            _index = value
        End Set
    End Property
    Public Property Key() As String
        Get
            Return TXTKEY.text
        End Get
        Set(ByVal value As String)
            TXTKEY.text = value
        End Set
    End Property
    Public Property Val() As String
        Get
            Return TXTVAL.text
        End Get
        Set(ByVal value As String)
            TXTVAL.text = value
        End Set
    End Property
    Public Property price() As Double
        Get
            Return _price
        End Get
        Set(ByVal value As Double)
            _price = value
        End Set
    End Property
    Public Property bPrice() As Double
        Get
            Return _bPrice
        End Get
        Set(ByVal value As Double)
            _bPrice = value
        End Set
    End Property
    Public Shadows Property enabled() As Boolean
        Get
            Return txtkey.Enabled
        End Get
        Set(ByVal value As Boolean)
            txtkey.Enabled = value
            txtval.txtReadOnly = value
        End Set
    End Property
    Public Shadows Property HasValue() As Boolean
        Get
            Return _hasValue
        End Get
        Set(ByVal value As Boolean)
            _hasValue = value
            If value Then
                TXTKEY.Width = CInt(Me.Width / 2) - 46
                TXTVAL.Width = CInt(Me.Width / 2) - 46
                TXTVAL.Left = TXTKEY.Right + 2
                TXTVAL.Visible = True
            Else
                TXTKEY.Width = Me.Width - 45
                TXTVAL.Visible = False
            End If
        End Set
    End Property

    'subs and Functions
    Shadows Sub Focus()
        TXTKEY.Focus()
    End Sub

    'handling the events
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'clear Functions
        RaiseEvent Clear(Me, e)
    End Sub
    Private Sub TXTKEY_KeyDownOk() Handles txtkey.KeyDownOk
        RaiseEvent NewKeyVal(Me, Nothing)
        If _hasValue Then
            TXTVAL.Focus()
        Else
            RaiseEvent AddNewPanel(Me, Nothing)
        End If

    End Sub
    Private Sub TXTVAL_KeyDownOk() Handles txtval.KeyDownOk
        RaiseEvent addnewpanel(Me, Nothing)
    End Sub
    Private Sub TXTVAL_TxtChanged() Handles txtval.TxtChanged
        RaiseEvent ValChanged(Me, Nothing)
    End Sub
    Private Sub TXTKEY_TxtChanged() Handles txtkey.TxtChanged
        RaiseEvent KeyChanged(Me, Nothing)
    End Sub
    Private Sub AddPanel_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If _hasValue Then
            TXTKEY.Width = CInt(Me.Width / 2) - 46
            TXTVAL.Width = CInt(Me.Width / 2) - 46
            TXTVAL.Left = TXTKEY.Right + 2
            TXTVAL.Visible = True
        Else
            TXTKEY.Width = Me.Width - 45
            TXTVAL.Visible = False
        End If
    End Sub
    Private Sub TXTVAL_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        TXTVAL.txtReadOnly = True
    End Sub
    Private Sub TXTKEY_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtkey.Leave
        RaiseEvent NewKeyVal(Me, e)
    End Sub

    Private Sub TxtPrice_TxtChanged()
        RaiseEvent PriceChanged(Me, Nothing)
    End Sub
End Class
