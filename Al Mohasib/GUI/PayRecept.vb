Public Class PayRecept

    Public avc As Double = 0
    Private _pay As Double = 0
    Public total As Double = 0
    Public str As String = ""

    Public ReadOnly Property avance As Double
        Get
            Dim a As Double = 0
            a = pay + avc
            If a > total Then a = total

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

            Dim rest As Decimal = CDec(value - total)
            txtRest.Text = String.Format("{0:n}", rest)

            If rest < 0 Then
                txtRest.ForeColor = Color.Red
            Else
                txtRest.ForeColor = Color.GreenYellow
            End If
        End Set
    End Property


    Private Sub PayRecept_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pay = 0
    End Sub


    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button30.Click, Button29.Click, Button28.Click, Button27.Click, Button26.Click, Button25.Click, Button24.Click, Button23.Click, Button22.Click
        Dim bt2 As Button = sender
        pay = pay + CDbl(bt2.Text)
        str &= "/" & bt2.Text & " Dhs"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txt.Text = "" Then Exit Sub

        txt.Text = txt.Text.Remove(txt.Text.Count - 1, 1)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        pay = total - avc
        str = "-- cache --"


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

        Dim isSell = Form1.RPl.isSell
        Dim tableName As String = "CompanyPayment"
        Dim tName As String = "Bon"
        Dim fld As String = "bonid"
        Dim cl As String = "comid"
        If isSell Then
            tableName = "Payment"
            tName = "Facture"
            fld = "fctid"
            cl = "clid"
        End If

        Dim fctid = Form1.RPl.FctId

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            params.Add("name", Form1.RPl.Name)
            params.Add(cl, Form1.RPl.ClId)
            params.Add("montant", avance)
            params.Add("way", "Comptoire")
            params.Add("date", Format(Now.Date, "dd-MM-yyyy"))
            params.Add("Num", str)
            params.Add(fld, fctid)
            params.Add("writer", CStr(Form1.adminName))

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
End Class