Public Class AddEditBanqueField

    Dim _tabProp As bTopField
    Dim _points As String

    Public Property Prop As bTopField
        Get

            _tabProp.str_start = txt.text
            _tabProp.str_end = TxtBox1.text
            _tabProp.field = CB.Text
            _tabProp.width = W.text
            _tabProp.height = H.text
            _tabProp.x = X.text
            _tabProp.y = Y.text
            _tabProp.fSize = T.text
            _tabProp.fName = txtF1.text
            _tabProp.isBold = CheckBox1.Checked

            _tabProp.backColor = btColor.BackColor.ToArgb
            _tabProp.hasBloc = cbBloc.Checked
            _tabProp.Alignement = Align
            _tabProp.points = _points

            Return _tabProp
        End Get
        Set(ByVal value As bTopField)
            _tabProp = value
            If IsNothing(value) Then Exit Property

            Try
                _points = value.points
            Catch ex As Exception
            End Try


            txt.text = value.str_start
            TxtBox1.text = value.str_end
            CB.Text = value.field

            W.text = value.width
            H.text = value.height
            X.text = value.x
            Y.text = value.y
            T.text = value.fSize
            CheckBox1.Checked = value.isBold
            btColor.BackColor = Color.FromArgb(value.backColor)
            cbBloc.Checked = value.hasBloc
            Align = value.Alignement
            txtF1.text = value.fName


        End Set
    End Property
    Private Property Align As Integer
        Get
            Dim t = 0
            If CbAlign.Text = "Droite" Then t = 2
            If CbAlign.Text = "Centre" Then t = 1

            Return t
        End Get
        Set(ByVal value As Integer)

            If value = 2 Then
                CbAlign.Text = "Droite"
            ElseIf value = 1 Then
                CbAlign.Text = "Centre"
            Else
                CbAlign.Text = "Gauche"
            End If
        End Set
    End Property
    Private _editMode As Boolean = False
    Public Property EditMode() As Boolean
        Get
            Return _editMode
        End Get
        Set(ByVal value As Boolean)
            _editMode = value
            btcancel.Visible = value
        End Set
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Prop = New bTopField
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcon.Click

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcancel.Click
        Prop.isDeleted = True
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btColor.Click
        Dim cr As New ColorDialog
        If cr.ShowDialog = DialogResult.OK Then
            btColor.BackColor = cr.Color
            _tabProp.backColor = cr.Color.ToArgb
        End If
    End Sub
 
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim fntdlg As New FontDialog
            If fntdlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
            txtF1.text = fntdlg.Font.Name
        Catch ex As Exception
        End Try
    End Sub


    Private Sub CB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB.SelectedIndexChanged
        If CB.Text = "Forms" Then
            txt.text = "S"

            Dim st As New ShapeTrace
            st.Data = _points
            st.PB.Width = W.text
            st.PB.Height = H.text

            If st.ShowDialog = Windows.Forms.DialogResult.OK Then
                _points = st.Data
            End If
        End If
    End Sub
End Class