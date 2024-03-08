Public Class Editprdfact

    Dim _depot As Integer
    Dim isRetour As Boolean = False
    Dim cid As Integer


    Public Property prdName As String
        Get
            Return txtArSearch.text
        End Get
        Set(ByVal value As String)
            txtArSearch.text = value
        End Set
    End Property
    Public Property prdSPrice As Double
        Get
            Return txtsprice.text
        End Get
        Set(ByVal value As Double)
            txtsprice.text = value
        End Set
    End Property
    Public Property depot As Integer
        Get
            If chNotDepot.Checked Then Return 0
            If Not IsNumeric(cbDepot.SelectedValue) Then Return 0
            Return cbDepot.SelectedValue
        End Get
        Set(ByVal value As Integer)
            _depot = value
            If value = 0 Then chNotDepot.Checked = True
            cbDepot.SelectedValue = value

        End Set
    End Property
    Public Property prdBPrice As Double
        Get
            Return txtbprice.text
        End Get
        Set(ByVal value As Double)
            txtbprice.text = value
        End Set
    End Property
    Public Property prdQte As Double
        Get
            Dim q As Double = CDbl(txtqte.text)
            If isRetour Then q = q * -1

            Return q
        End Get
        Set(ByVal value As Double)

            txtqte.text = value
        End Set
    End Property

    Private ReadOnly Property isValidate As Boolean
        Get
            If Not IsNumeric(txtbprice.text) Or Not IsNumeric(txtsprice.text) Or Not IsNumeric(txtqte.text) Then
                MsgBox("الكمية و ثمن الشراء و البيع يجب ان تكون بالارقام", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                Return False
            End If



            If Double.Parse(prdSPrice) < Double.Parse(prdBPrice) And Form1.RPl.isSell = True Then
                If Form1.txtAllowLowPrice_Cat.Text.Contains("*") Or
                    Form1.txtAllowLowPrice_Cat.Text.Contains(cid) Or
                   (Form1.txtAllowLowPrice_Client.Text.Contains(Form1.RPl.ClId) And Form1.RPl.ClId > 0) Then Return True

                Dim str As String = "ثمن البيع يجب ان يكون أكبر من ثمن الشراء"
                MsgBox(str, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                Return False
            End If

            Return True
        End Get
    End Property

    Public Sub New(ByVal name As String, ByVal bprice As String,
                   ByVal sprice As String, ByVal qte As String, ByVal dp As String, ByVal isR As Boolean, ByVal _cid As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        prdName = name
        prdBPrice = bprice
        prdSPrice = sprice
        prdQte = qte
        depot = dp
        isRetour = isR
        cid = _cid

    End Sub
    Private Sub Editprdfact_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ALMohassinDBDataSet.Depot' table. You can move, or remove it, as needed.
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            cbDepot.DataSource = a.SelectDataTableSymbols("Depot", {"*"})
            cbDepot.DisplayMember = "name"
            cbDepot.ValueMember = "dpid"
        End Using

        cbDepot.SelectedValue = _depot

        If Form1.admin Then
            Me.Show()
            txtsprice.Focus()
        Else
            'LBQTE.Top = LBBPRICE.Top
            'txtqte.Top = txtbprice.Top

            LBBPRICE.Visible = False
            LBSPR.Visible = False
            txtbprice.Visible = False
            txtsprice.Visible = False

            cbChangeName.Visible = False
            cbChangePrice.Visible = False
            chNotDepot.Visible = False
            ' Me.Height = 385
            Me.Show()
            txtqte.Focus()
        End If

        If Form1.RPl.EditMode Then
            Label8.Visible = False
            cbDepot.Visible = False
            chNotDepot.Visible = False
        End If

        Dim pr As Double = CDbl(txtsprice.text)
        Dim qt As Double = CDbl(txtqte.text)

        txtTotal.text = pr * qt
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If isValidate = False Then Exit Sub
        Dim C = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        txtqte.text = txtqte.text.Replace(".", C)
        txtbprice.text = txtbprice.text.Replace(".", C)
        txtsprice.text = txtsprice.text.Replace(".", C)

        Try
            prdQte = txtqte.text
        Catch ex As Exception
            txtqte.Focus()
        End Try

        Try
            prdBPrice = txtbprice.text
        Catch ex As Exception
            txtbprice.Focus()
        End Try

        Try
            prdSPrice = txtsprice.text
        Catch ex As Exception
            txtsprice.Focus()
        End Try

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel

    End Sub

    Private Sub txtArSearch_TxtChanged() Handles txtArSearch.TxtChanged
        prdName = txtArSearch.text
    End Sub

    Private Sub txtbprice_KeyDownOk() Handles txtqte.KeyDownOk, txtArSearch.KeyDownOk
        If isValidate = False Then Exit Sub
        Dim C = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        txtqte.text = txtqte.text.Replace(".", C)
        txtbprice.text = txtbprice.text.Replace(".", C)
        txtsprice.text = txtsprice.text.Replace(".", C)

        Try
            prdQte = txtqte.text
        Catch ex As Exception
            txtqte.Focus()
        End Try

        Try
            prdBPrice = txtbprice.text
        Catch ex As Exception
            txtbprice.Focus()
        End Try

        Try
            prdSPrice = txtsprice.text
        Catch ex As Exception
            txtsprice.Focus()
        End Try

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub txtbprice_KeyDownOk_1() Handles txtbprice.KeyDownOk
        txtsprice.Focus()
    End Sub

    Private Sub txtsprice_KeyDownOk() Handles txtsprice.KeyDownOk
        txtqte.Focus()
    End Sub

    Private selectedControle As TxtBox
    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button31.Click, Button30.Click, Button3.Click, Button29.Click, Button28.Click, Button27.Click, Button26.Click, Button25.Click, Button24.Click, Button23.Click, Button22.Click

        If IsNothing(selectedControle) Then Exit Sub
        Dim bt2 As Button = sender

        If selectedControle.IsNumiric Then
            If bt2.Text = "." Then
                If selectedControle.text.Contains(Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) = False Then
                    selectedControle.text &= Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
                End If
            ElseIf IsNumeric(bt2.Text) Then
                selectedControle.text &= bt2.Text
            End If
        Else
            selectedControle.text &= bt2.Text
        End If
    End Sub

    Private Sub txtbprice_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbprice.Enter
        selectedControle = txtbprice
    End Sub

    Private Sub txtsprice_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsprice.Enter
        selectedControle = txtsprice
    End Sub

    Private Sub txtqte_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtqte.Enter
        selectedControle = txtqte
    End Sub

    Private Sub txtArSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtArSearch.Load
        selectedControle = Nothing
    End Sub

    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button33.Click
        If IsNothing(selectedControle) Then Exit Sub
        selectedControle.text = ""
    End Sub

    Private Sub txtTotal_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotal.Enter
        selectedControle = txtTotal
    End Sub
    Private Sub txtsprice_TxtChanged() Handles txtsprice.TxtChanged
        Try
            If selectedControle.Name <> txtsprice.Name Then Exit Sub

            Dim pr As Double = CDbl(txtsprice.text)
            Dim qt As Double = CDbl(txtqte.text)

            txtTotal.text = pr * qt
        Catch ex As Exception
            txtTotal.text = ""
        End Try

    End Sub
    Private Sub txtqte_TxtChanged() Handles txtqte.TxtChanged
        Try
            If selectedControle.Name <> txtqte.Name Then Exit Sub

            Dim pr As Double = CDbl(txtsprice.text)
            Dim qt As Double = CDbl(txtqte.text)

            txtTotal.text = pr * qt
        Catch ex As Exception
            txtTotal.text = ""
        End Try

    End Sub
    Private Sub txttotal_TxtChanged() Handles txtTotal.TxtChanged
        Try
            If selectedControle.Name <> txtTotal.Name Then Exit Sub

            Dim pr As Double = CDbl(txtsprice.text)
            Dim tt As Double = CDbl(txtTotal.text)

            If pr = 0 Then Exit Sub

            txtqte.text = (tt / pr)
        Catch ex As Exception

        End Try

    End Sub
End Class