Public Class FacturePayementItem

    Public id As Integer = 0
    Public total As Double = 0
    Dim _mnt As Double = 0
    Public _avc As Double = 0
    Public Event SelectionChanged()

    Public Property avance As Double
        Get
            Return CDbl(lbA.Text)
        End Get
        Set(ByVal value As Double)

            _avc = value

            lbA.Text = (_avc + _mnt).ToString("N2")
            Try
                PLav.Width = PLd.Width * (_avc + _mnt) / total
            Catch ex As Exception
                PLav.Width = PLd.Width
            End Try

        End Set
    End Property
    Public ReadOnly Property isPayed As Boolean
        Get
            Return avance >= total
        End Get
    End Property
    Public ReadOnly Property rest As Double
        Get
            Return total - avance
        End Get
    End Property
    Public Property isActive As Boolean
        Get
            Return cb.Checked
        End Get
        Set(ByVal value As Boolean)
            cb.Checked = value
        End Set
    End Property
    Private _data As DataRow
    Public Property DataSource() As DataRow
        Get
            Return _data
        End Get
        Set(ByVal value As DataRow)
            _data = value

            id = CInt(value.Item(0))
            total = CDbl(value.Item("total"))
            avance = CDbl(value.Item("avance"))

            lbD.Text = CDate(value.Item("date")).ToString("dd/MM")
            lbId.Text = id
            lbT.Text = total.ToString("N2")

        End Set
    End Property

    Public hasFraction As Boolean = False
    Public id_fraction As Integer = 0
    Public Property montant_fraction As Double
        Get
            Return _mnt
        End Get
        Set(ByVal value As Double)
            _mnt = value
            lbA.Text = (_avc + _mnt).ToString("N2")
            ' PLav.Width = PLd.Width * (_avc + _mnt) / total
            Try
                PLav.Width = PLd.Width * (_avc + _mnt) / total
            Catch ex As Exception
                PLav.Width = PLd.Width
            End Try
        End Set
    End Property
    Private Sub cb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb.CheckedChanged
        RaiseEvent SelectionChanged()
    End Sub
End Class

