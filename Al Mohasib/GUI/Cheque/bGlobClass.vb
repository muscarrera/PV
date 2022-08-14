Imports System.Drawing.Printing

Public Class bGlobClass
    Public localName As String = "Default.bqu"
    Public W_Page As Integer = 820
    Public h_Page As Integer = 1160
    Public P_name As String = "A4"
    Public p_Kind As PaperKind = PaperKind.A4
    Public is_Landscape As Boolean = False
    Public Wd As Integer = 820
    Public Ht As Integer = 1160

    Public TopFieldDic As New List(Of bTopField)

End Class
