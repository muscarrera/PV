Public Class AddEditCharges
    Private _chargename As String
    Private _price As Double
    Private _isR As Boolean
    Private _duree As Integer
    Private _chid As Integer

    Public chid As Integer

    Public Property chargename As String
        Get
            Return _chargename
        End Get
        Set(ByVal value As String)
            _chargename = value
            TxtBox1.text = value
        End Set
    End Property
    Public Property price As Double
        Get
            Return _price
        End Get
        Set(ByVal value As Double)
            _price = value
            TxtBox2.text = value
        End Set
    End Property
    Public Property isR As Boolean
        Get
            Return _isR
        End Get
        Set(ByVal value As Boolean)
            _isR = value
            CheckBox1.Checked = value
        End Set
    End Property
    Public Property duree As Integer
        Get
            Return _duree
        End Get
        Set(ByVal value As Integer)
            _duree = value
            TxtBox4.text = value
        End Set
    End Property


    Private Sub TxtBox1_TxtChanged() Handles TxtBox1.TxtChanged
        chargename = TxtBox1.text
    End Sub

    Private Sub TxtBox2_Load() Handles TxtBox2.TxtChanged
        price = TxtBox2.text
    End Sub

    Private Sub CheckBox1_CheckedChanged() Handles CheckBox1.CheckedChanged
        isR = CheckBox1.Checked
    End Sub

    Private Sub TxtBox4_Load() Handles TxtBox4.TxtChanged
        duree = TxtBox4.text
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If chargename = "" Then Exit Sub
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class