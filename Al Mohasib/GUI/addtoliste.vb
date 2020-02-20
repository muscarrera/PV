Public Class addtoliste
    Dim EditMode As Boolean
    Public id As Integer
    Private Sub addtoliste_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            If EditMode Then
                IIf(CDbl(TxtBox2.text) < 3, "3", TxtBox2.text)

                Dim params As New Dictionary(Of String, Object)
                params.Add("name", TxtBox1.text)
                If CDbl(TxtBox2.text) > 3 Then params.Add("val", TxtBox2.text)
                Dim where As New Dictionary(Of String, Object)
                where.Add("Mid", id)

                c.UpdateRecord("Machine", params, where)

                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                IIf(CDbl(TxtBox2.text) < 3, "3", TxtBox2.text)

                Dim where As New Dictionary(Of String, Object)
                where.Add("name", TxtBox1.text)
                where.Add("val", TxtBox2.text)

                c.InsertRecord("Machine", where)

                Me.DialogResult = Windows.Forms.DialogResult.OK

            End If
        End Using

    End Sub
    Private Sub Button63_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button63.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class