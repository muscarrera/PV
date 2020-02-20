Public Class Commande
    Dim LastSetOfBottonday As Integer = 0
    Public dtnow As Date = Date.Now
    Public str As String

    Private Sub ChooseDay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillButtonday()

        If Form1.RPl.EditMode = False Then
            GroupBox1.Visible = False
            Me.Height = 180
        End If

    End Sub
    Public Sub FillButtonday()
        Dim i As Integer
        Dim j As Integer = 0
        Dim bt As Button = Nothing
        For i = LastSetOfBottonday To LastSetOfBottonday + 4 - 1
            If j = 0 Then
                bt = btd1
                bt.ForeColor = Color.Blue
            End If
            If j = 1 Then bt = btd2
            If j = 2 Then bt = btd3
            If j = 3 Then bt = btd4
            bt.BackColor = Color.Cornsilk
            If j = 0 Then
                bt.BackColor = Color.AliceBlue
            End If
            j += 1
            Dim dtliv As Date = dtnow.AddDays(i)

            bt.Text = dtliv.Day.ToString & " / " & dtliv.Month.ToString
            bt.Tag = dtliv
        Next
    End Sub

    Private Sub Button39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button39.Click
        Me.LastSetOfBottonday = Me.LastSetOfBottonday + 4
        FillButtonday()
    End Sub

    Private Sub Button38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button38.Click
        Me.LastSetOfBottonday = Me.LastSetOfBottonday - 4

        If LastSetOfBottonday < 0 Then
            LastSetOfBottonday = 0
        End If
        FillButtonday()
    End Sub

    Private Sub btd1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btd4.Click, btd3.Click, btd2.Click, btd1.Click
        Dim bt As Button = sender
        dtnow = bt.Tag
        'Form1.Button38.Text = "Date de livraison : " & dtnow.Day.ToString & " / " & dtnow.Month.ToString

        str = dtnow.ToString("dd, MMM")
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        str = "-"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class