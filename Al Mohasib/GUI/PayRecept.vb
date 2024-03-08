Public Class PayRecept

    Public _avc As Double = 0
    Private _pay As Double = 0
    Public total As Double = 0
    Public str As String = ""
    Public WAY As String = "CACHE"

    Public ReadOnly Property avance As Double
        Get
            Dim a As Double = 0
            a = pay + avc
            If a > total Then a = total

            Return a
        End Get
    End Property
    Public ReadOnly Property avancePay As Double
        Get
            Dim a As Double = pay

            If pay > (avc + total) Then
                a = total - avc
            End If

            Return a
        End Get
    End Property
    Public Property pay As Double
        Get
            Return _pay
        End Get
        Set(ByVal value As Double)
            _pay = value
            txt.Text = String.Format("{0:n}", CDec(value))

            Dim rest As Decimal = CDec((value + avc) - total)
            txtRest.Text = String.Format("{0:n}", rest)

            If rest < 0 Then
                txtRest.ForeColor = Color.Red
            Else
                txtRest.ForeColor = Color.GreenYellow
            End If
        End Set
    End Property

    Public Property avc As Double
        Get
            Return _avc
        End Get
        Set(ByVal value As Double)
            _avc = value
            txtAvc.Text = value.ToString(Form1.frmDbl)

        End Set
    End Property

    Private Sub PayRecept_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pay = 0
        If Form1.cbRYL.Checked Then ryalDevise = 20
    End Sub

    Public ryalDevise As Integer = 1
    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button30.Click, Button29.Click, Button28.Click, Button27.Click, Button26.Click, Button25.Click, Button24.Click, Button23.Click, Button22.Click
        Dim bt2 As Button = sender
        pay = pay + CDbl(bt2.Text * ryalDevise)

        If ryalDevise = 1 Then
            str &= "/" & bt2.Text & " Dhs"
        Else
            str &= "/" & CDbl(bt2.Text * ryalDevise).ToString() & " Ryl"
        End If
        WAY = "Cache"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txt.Text = "" Then Exit Sub

        txt.Text = txt.Text.Remove(txt.Text.Count - 1, 1)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        pay = total - avc
        str = "-- cache --"

        WAY = "Cache"

        AddPayement()
        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button33.Click
        pay = 0
        str = ""
    End Sub

    Private Sub txt_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt.VisibleChanged

    End Sub


    Public Sub AddPayement()
        If pay = 0 Then
            If Form1.cbCafeMode.Checked And Form1.cbCafeTable.Checked Then
                pay = total - avc
                str = "-- cache --"

                WAY = "Cache"

            Else
                Exit Sub
            End If
        End If



        Dim isSell = Form1.RPl.isSell
        Dim tableName As String = "CompanyPayment"
        Dim tName As String = "Bon"
        Dim fld As String = "bonid"

        If isSell Then
            tableName = "Payment"
            tName = "Facture"
            fld = "fctid"

        End If

        Dim fctid = Form1.RPl.FctId

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            params.Add("name", Form1.RPl.Name)
            params.Add("cid", Form1.RPl.ClId)
            params.Add("montant", avancePay)
            params.Add("way", WAY)
            params.Add("date", Now) 'Format(Now.Date, "dd-MM-yyyy"))
            params.Add("Num", str)
            params.Add("fctid", fctid)
            params.Add("writer", CStr(Form1.adminName))
            params.Add("caisse", Form1.caisseId)

            Dim Pid = c.InsertRecord(tableName, params, True)

            params.Clear()

            params.Add("avance", avance)
            where.Add(fld, fctid)
            c.UpdateRecord(tName, params, where)

            Form1.RPl.Avance = avance
            where = Nothing
            params = Nothing
        End Using

    End Sub

    Private Sub btOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOk.Click
        'If total > avance Then
        '    pay = total - avc
        '    str = "-- cache --"
        'End If

        AddPayement()

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Annuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Annuler.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        pay = total - avc
        str = "-- TPE --"

        WAY = "TPE"

        AddPayement()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        pay = total - avc
        str = "-- CHEQUE --"

        WAY = "Cheque"

        AddPayement()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        pay = total - avc
        str = "-- VIREMENT --"

        WAY = "Virement Bancaire"

        AddPayement()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub
End Class