Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Module ExcelModule
    Private _path As String = ""
    Private ReadOnly Property Path As String
        Get
            Dim st As String = Form1.btSvPath.Tag & "\" & _path & "\" & Now.ToString("yyyy")
            Dim dir1 As New DirectoryInfo(st)
            If dir1.Exists = False Then dir1.Create()

            Return st & "\" & Now.ToString("dd-MM-yyyy - HH-mm")
        End Get
    End Property


    Public Sub SaveExcel(ByVal DataGridView1 As DataGridView, ByVal path_str As String, ByVal t1 As String, ByVal t2 As String)

        _path = path_str
        Dim xlApp As Excel.Application = New Microsoft.Office.Interop.Excel.Application()
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer

        '  xlApp = New Excel.ApplicationClass
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets(1)


        'Dim formatRange As Excel.Range
        'formatRange = xlWorkSheet.Range("a1")
        'formatRange.EntireRow.Font.Bold = True
        'xlWorkSheet.Cells(1, 5) = "Bold"


        xlWorkSheet.Cells(1, 1) = t1
        xlWorkSheet.Cells(1, 1).Font.Bold = True
        ' xlWorkSheet.Cells(1, 1).font = New Font("Arial", 16, FontStyle.Bold)
        xlWorkSheet.Cells(3, 1) = t2
        xlWorkSheet.Cells(4, 1) = "Date : " & Now.ToString("dd MMMM yyyy - [HH:mm]")
        xlWorkSheet.Cells(3, 1).Font.Bold = True



        j = 0
        For Each column As DataGridViewColumn In DataGridView1.Columns
            If column.Visible = False Then Continue For
            xlWorkSheet.Cells(6, j + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            xlWorkSheet.Cells(6, j + 1) = column.Name

            Dim formatRange As Excel.Range = xlWorkSheet.UsedRange
            Dim cell As Excel.Range = formatRange.Cells(6, j + 1)
            Dim border As Excel.Borders = cell.Borders
            border.LineStyle = Excel.XlLineStyle.xlContinuous
            border.Weight = 3.0
            j += 1
        Next


        For i = 0 To DataGridView1.RowCount - 1

            j = 0
            Dim cl = -1
            For Each column As DataGridViewColumn In DataGridView1.Columns
                cl += 1
                If column.Visible = False Then Continue For
                xlWorkSheet.Cells(i + 7, j + 1) = DataGridView1(cl, i).Value

                Dim formatRange As Excel.Range = xlWorkSheet.UsedRange
                Dim cell As Excel.Range = formatRange.Cells(i + 7, j + 1)
                Dim border As Excel.Borders = cell.Borders
                border.LineStyle = Excel.XlLineStyle.xlContinuous
                border.Weight = 2.0

                j += 1
            Next
        Next

        xlWorkSheet.SaveAs(Path)
        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)

        MsgBox("Fichier excel est bien enregistré ...")
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
End Module
