Public Class ListMultiCodes



    Private _code As String
    Public Property Code() As String
        Get
            Return _code
        End Get
        Set(ByVal value As String)
            _code = value

            Filllist()
        End Set
    End Property

    Private Sub Filllist()

        Dim ls = Code.Split("-")
        Panel1.Controls.Clear()

        For i As Integer = 0 To ls.Length - 1
            Dim t As New Tag
            t.key = i
            t.val = ls(i)
            t.Dock = DockStyle.Top

            AddHandler t.DeleteTag, AddressOf DeleteTag

            Panel1.Controls.Add(t)
        Next


    End Sub

    Private Sub DeleteTag(ByVal T As Al_Mohasib.Tag)
        Dim v = T.val
        Dim k = T.key
        Dim newStr As String = ""

        Dim ls = Code.Split("-")

        For i As Integer = 0 To ls.Length - 1

            If i = k And ls(i) = v Then Continue For

            If newStr.Length > 0 Then newStr &= "-"
            newStr &= ls(i)
        Next

        Code = newStr


        TxtBox1.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TxtBox1.text.Trim = "" Then
            TxtBox1.Focus()
            Exit Sub
        End If

        Dim str = TxtBox1.text

        If Code.Length > 0 Then str = "-" & TxtBox1.text

        If Code.Length > 250 Then Exit Sub

        Code = Code & str

        TxtBox1.text = ""
        TxtBox1.Focus()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class