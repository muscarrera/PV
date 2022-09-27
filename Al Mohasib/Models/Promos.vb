Public Class Promos

    Public name As String
    Public desgn As String
    Public type As String
    Public dte As Date

    Public resultList As List(Of PromosArticle)
    Public startList As List(Of PromosArticle)




End Class

Public Class PromosArticle

    Public name As String
    Public arid As Integer
    Public qte As Double
    Public price As Double
    Public promo As Double
    Public type As String

End Class