Imports System.Drawing.Printing

Public Class LbGlobalElement
    Public localName As String = "Default.dat"
    Public W_Page As Integer = 820
    Public h_Page As Integer = 1160

    Public W_El As Integer = 200
    Public H_El As Integer = 100

    Public Nbr_W As Integer = 6
    Public Nbr_H As Integer = 10
    Public Nbr_Q As Integer = 1

    Public Sp_W As Integer = 33
    Public Sp_H As Integer = 33

    Public Start_X As Integer = 22
    Public Start_Y As Integer = 11

    Public Printer_name As String = "A4"
    Public P_name As String = "A4"
    Public p_Kind As PaperKind = PaperKind.A4
    Public is_Landscape As Boolean = False
    Public is_Repeated As Boolean = False
    Public elements As New List(Of LbElement)
End Class
