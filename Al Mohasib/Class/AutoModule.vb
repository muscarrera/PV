Module AutoModule
    Public Function StrValue(ByVal dt As DataTable, ByVal field As String, ByVal i As Integer) As String
        Dim str As String = ""
        Try
            str = dt.Rows(i).Item(field).ToString
        Catch ex As Exception
            str = ""
        End Try
        Return str
    End Function
    Public Function DblValue(ByVal dt As DataTable, ByVal field As String, ByVal i As Integer) As Double
        Dim str As Double = 0
        Try
            str = CDbl(dt.Rows(i).Item(field))
        Catch ex As Exception
            str = 0
        End Try
        Return str
    End Function
    Public Function IntValue(ByVal dt As DataTable, ByVal field As String, ByVal i As Integer) As Integer
        Dim str As Integer = 0
        Try
            str = CInt(dt.Rows(i).Item(field))
        Catch ex As Exception
            str = 0
        End Try
        Return str
    End Function
    Public Function BoolValue(ByVal dt As DataTable, ByVal field As String, ByVal i As Integer) As Boolean
        Dim str As Boolean = False
        Try
            str = CBool(dt.Rows(i).Item(field))
        Catch ex As Exception
            str = False
        End Try
        Return str
    End Function
    Public Function DteValue(ByVal dt As DataTable, ByVal field As String, ByVal i As Integer) As Date
        Dim str As Date = Now.Date
        Try
            str = CDate(dt.Rows(i).Item(field))
        Catch ex As Exception
            str = Now.Date
        End Try
        Return str
    End Function
End Module
