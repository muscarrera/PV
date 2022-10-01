Public Class Promos

    Public name As String
    Public desgn As String
    Public type As String
    Public dte As Date
    Public ech As Date
    Public img As String  ' design to show
    Public isActive As Boolean


    Public resultList As List(Of PromosArticle)
    Public startList As List(Of PromosArticle)

End Class

Public Class PromosArticle


    Public type As String
    Public name As String
    Public arid As Integer
    Public qte As Double
    Public point As Integer


End Class