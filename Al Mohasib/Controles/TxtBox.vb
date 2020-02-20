Public Class TxtBox
    'Membres
    Private start As Integer = 2
    Private Clr As Boolean = True
    Private color As Color = Drawing.Color.White
    Private _isNumirique As Boolean = False


    Public Event TxtChanged()
    Public Event SaveText()
    Public Event KeyDownOk()
    Public Event TxtKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    ' Shadows Event keypress()

    'Property
    Public Property TextSize() As Integer
        Get
            Return CInt(TXT.Font.Size)
        End Get
        Set(ByVal value As Integer)
            Dim fn As Font = New Font(Me.Font.FontFamily, value, FontStyle.Bold)
            TXT.Font = fn

            Me.Height = TXT.Height + 10
            RS.CornerRadius = CInt(Me.Height / 10)
        End Set
    End Property
    Public Property StartUp() As Integer
        Get
            Return start
        End Get
        Set(ByVal value As Integer)
            start = value
            TXT.Left = 4 + start
            TXT.Width = Me.Width - 8 - start
        End Set
    End Property
    Public Overrides Property text() As String
        Get
            Return TXT.Text
        End Get
        Set(ByVal value As String)
            TXT.Text = value

        End Set
    End Property
    Public Property BorderColor() As Color
        Get
            Return RS.BorderColor
        End Get
        Set(ByVal value As Color)
            RS.BorderColor = value
        End Set
    End Property
    Public Property TxtBackColor() As Boolean
        Get
            Return Clr
        End Get
        Set(ByVal value As Boolean)
            Clr = value
        End Set
    End Property
    Public Property TxtColor() As Color
        Get
            Return color
        End Get
        Set(ByVal value As Color)
            color = value
            TXT.BackColor = value
            RS.BackColor = value
        End Set
    End Property
    Public Property AutoCompleteSource() As AutoCompleteStringCollection
        Get
            Return TXT.AutoCompleteCustomSource
        End Get
        Set(ByVal value As AutoCompleteStringCollection)
            TXT.AutoCompleteCustomSource = value
            TXT.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            TXT.AutoCompleteSource = Windows.Forms.AutoCompleteSource.CustomSource
        End Set
    End Property
    Public Property ShowSaveIcon() As Boolean
        Get
            Return PO.Visible
        End Get
        Set(ByVal value As Boolean)
            Dim A As Integer = CInt((Me.Height - PD.Height) / 2)
            Position(A)
            PO.Visible = value
        End Set
    End Property
    Public Property ShowClearIcon() As Boolean
        Get
            Return PD.Visible
        End Get
        Set(ByVal value As Boolean)
            Dim A As Integer = CInt((Me.Height - PD.Height) / 2)
            Position(A)
            PD.Visible = value
            TXT.BackColor = Drawing.Color.White
            RS.BackColor = Drawing.Color.White
        End Set
    End Property
    Public Property TxtSelect() As Integer()
        Get
            Return {1, 0}
        End Get
        Set(ByVal value As Integer())
            TXT.Select(value(0), value(1))
        End Set
    End Property
    Public Property txtReadOnly() As Boolean
        Get
            Return TXT.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            TXT.ReadOnly = value
        End Set
    End Property
    Public Property IsNumiric() As Boolean
        Get
            Return _isNumirique
        End Get
        Set(ByVal value As Boolean)
            _isNumirique = value
        End Set
    End Property

    Shadows Sub [Select](ByVal d As Integer, ByVal f As Integer)
        TXT.Select(d, f)
    End Sub

    'create subs & functions
    Private Sub Position(ByVal A As Integer)
        PD.Top = A
        PO.Top = A
        Dim s As Integer = 0

        If PD.Visible And PO.Visible Then
            s = PD.Width + PO.Width
            TXT.Width = RS.Width - s - 6
            PD.Left = RS.Right - PD.Width - 2
            PO.Left = TXT.Right + 2

        ElseIf PD.Visible = True And PO.Visible = False Then
            s = PD.Width
            TXT.Width = RS.Width - s - 6
            PD.Left = RS.Right - PD.Width - 2
        ElseIf PD.Visible = False And PO.Visible = True Then
            s = PO.Width
            TXT.Width = RS.Width - s - 6
            PO.Left = RS.Right - PO.Width - 2
        End If
        TXT.Left = start + 5

    End Sub

    ' handling the events
    Private Sub UserControl1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RS.Width = Me.Width - 2
        RS.Height = Me.Height - 2
        RS.Top = 1
        RS.Left = 1
    End Sub
    Private Sub UserControl1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        RS.Width = Me.Width - 2 '6
        RS.Height = Me.Height - 2 '4
        RS.Top = 1 '2
        RS.Left = 1 '3
        Dim A As Integer = CInt((Me.Height - TXT.Height) / 2)
        TXT.Top = A
        TXT.Left = 4 + start
        TXT.Width = Me.Width - 8 - start
        A = CInt((Me.Height - PD.Height) / 2)
        Position(A)
    End Sub
    Private Sub RS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RS.Click
        TXT.Focus()
    End Sub
    Private Sub txtBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        TXT.Focus()
    End Sub
    Private Sub TXT_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT.Enter
        If Clr Then
            TXT.BackColor = color.GreenYellow
            TXT.ForeColor = color.Green
            RS.BackColor = color.GreenYellow
            PO.Visible = False
            PD.Visible = False
        End If
    End Sub
    Private Sub TXT_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT.Leave
        If Clr Then
            TXT.BackColor = color
            TXT.ForeColor = color.Black
            RS.BackColor = color

            Dim A As Integer = CInt((Me.Height - PD.Height) / 2)
            Position(A)
        End If
    End Sub
    Private Sub TXT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT.TextChanged
        RaiseEvent TxtChanged()
    End Sub
    Private Sub PD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PD.Click
        Me.ShowClearIcon = False
        'Me.ShowSaveIcon = False

        TXT.Text = ""
        TXT.Focus()
    End Sub
    Private Sub PO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PO.Click
        RaiseEvent SaveText()
        'Me.ShowSaveIcon = False
    End Sub
    Private Sub TXT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            RaiseEvent KeyDownOk()
        End If
    End Sub

    Private Sub PD_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PD.MouseEnter
        '   PD.BackgroundImage = My.Resources.close16HOVER
    End Sub

    Private Sub PD_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PD.MouseLeave
        ' PD.BackgroundImage = My.Resources.close16O
    End Sub

    Private Sub TXT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT.KeyPress
        If IsNumiric Then
            If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "," AndAlso Not e.KeyChar = "." Then
                e.Handled = True
            End If
            If e.KeyChar = "." Then e.KeyChar = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
            If e.KeyChar = "," Then e.KeyChar = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        End If

        RaiseEvent TxtKeyPress(TXT, e)
    End Sub
End Class
