Public Class LbElement
    Public designation As String = String.Empty
    Public field As String = String.Empty
    Public x As Integer = 10
    Public y As Integer = 10
    Public width As Integer = 100
    Public height As Integer = 15
    Public fSize As Integer = 9
    Public Alignement As Integer = 0
    Public fName As String = "Arial"
    Public backColor As Integer = Color.Red.ToArgb
    Public forColor As Integer = Color.Black.ToArgb
    Public isBold As Boolean = False
    Public hasBloc As Boolean = False
    Public isVertical As Boolean = False

    Public points As String

    Public isDeleted As Boolean = False
End Class
