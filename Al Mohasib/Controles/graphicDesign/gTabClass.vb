Public Class gTabClass

    Public x As Integer = 40
    Public y As Integer = 160
    Public TabWidth As Integer = 500
    Public TabHeight As Integer = 800
    Public Type As String = "Table_1"
    Public hasLines As Boolean = False
    Public hasRows As Boolean = False
    Public details As New List(Of gColClass)

    Public zTl As Integer = 11
    Public zIn As Integer = 9
    Public pTl As String = "Arial"
    Public pIn As String = "Arial"
    Public isBIn As Boolean = False
    Public clr As Integer = color.black.ToArgb
End Class
