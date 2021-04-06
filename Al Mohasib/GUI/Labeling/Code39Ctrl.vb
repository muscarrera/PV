Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Namespace DSBarCode
    Public Class BarCodeCtrl
        Inherits System.Windows.Forms.UserControl

        Private components As System.ComponentModel.Container = Nothing

        Public Enum AlignType
            Left
            Center
            Right
        End Enum

        Public Enum BarCodeWeight
            Small = 1
            Medium
            Large
        End Enum

        Private align As AlignType = AlignType.Center
        Private code As String = "1234567890"
        Private _leftMargin As Integer = 10
        Private _topMargin As Integer = 10
        Private _height As Integer = 50
        Private _showHeader As Boolean
        Private _showFooter As Boolean
        Private _headerText As String = "BarCode Demo"
        Private _weight As BarCodeWeight = BarCodeWeight.Small
        Private _headerFont As Font = New Font("Courier", 18)
        Private _footerFont As Font = New Font("Courier", 8)
        Public codePrinterName As String = ""

        Public Property VertAlign As AlignType
            Get
                Return align
            End Get
            Set(ByVal value As AlignType)
                align = value
                panel1.Invalidate()
            End Set
        End Property

        Public Property BarCode As String
            Get
                Return code
            End Get
            Set(ByVal value As String)
                code = value.ToUpper()
                panel1.Invalidate()
            End Set
        End Property

        Public Property BarCodeHeight As Integer
            Get
                Return height
            End Get
            Set(ByVal value As Integer)
                height = value
                panel1.Invalidate()
            End Set
        End Property

        Public Property LeftMargin As Integer
            Get
                Return _leftMargin
            End Get
            Set(ByVal value As Integer)
                _leftMargin = value
                panel1.Invalidate()
            End Set
        End Property

        Public Property TopMargin As Integer
            Get
                Return _topMargin
            End Get
            Set(ByVal value As Integer)
                _topMargin = value
                panel1.Invalidate()
            End Set
        End Property

        Public Property ShowHeader As Boolean
            Get
                Return _showHeader
            End Get
            Set(ByVal value As Boolean)
                _showHeader = value
                panel1.Invalidate()
            End Set
        End Property

        Public Property ShowFooter As Boolean
            Get
                Return _showFooter
            End Get
            Set(ByVal value As Boolean)
                _showFooter = value
                panel1.Invalidate()
            End Set
        End Property

        Public Property HeaderText As String
            Get
                Return _headerText
            End Get
            Set(ByVal value As String)
                _headerText = value
                panel1.Invalidate()
            End Set
        End Property

        Public Property Weight As BarCodeWeight
            Get
                Return _weight
            End Get
            Set(ByVal value As BarCodeWeight)
                _weight = value
                panel1.Invalidate()
            End Set
        End Property

        Public Property HeaderFont As Font
            Get
                Return _HeaderFont
            End Get
            Set(ByVal value As Font)
                _headerFont = value
                panel1.Invalidate()
            End Set
        End Property

        Public Property FooterFont As Font
            Get
                Return _footerFont
            End Get
            Set(ByVal value As Font)
                _footerFont = value
                panel1.Invalidate()
            End Set
        End Property

        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub Print()
            'Dim pd As PrintDialog = New PrintDialog()
            'pd.Document = printDocument1

            'If pd.ShowDialog() = DialogResult.OK Then
            '    pd.Document.Print()
            'End If


            PrintDocument1.DefaultPageSettings.PrinterSettings.PrinterName = codePrinterName
            PrintDocument1.Print()

        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If components IsNot Nothing Then components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

        Private alphabet39 As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%*"
        Private coded39Char As String() = {"000110100", "100100001", "001100001", "101100000", "000110001", "100110000", "001110000", "000100101", "100100100", "001100100", "100001001", "001001001", "101001000", "000011001", "100011000", "001011000", "000001101", "100001100", "001001100", "000011100", "100000011", "001000011", "101000010", "000010011", "100010010", "001010010", "000000111", "100000110", "001000110", "000010110", "110000001", "011000001", "111000000", "010010001", "110010000", "011010000", "010000101", "110000100", "011000100", "010101000", "010100010", "010001010", "000101010", "010010100"}

        Private Sub panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
            Dim intercharacterGap As String = "0"
            Dim str As String = "*"c & code.ToUpper() & "*"c
            Dim strLength As Integer = str.Length

            For i As Integer = 0 To code.Length - 1

                If alphabet39.IndexOf(code(i)) = -1 OrElse code(i) = "*"c Then
                    e.Graphics.DrawString("INVALID BAR CODE TEXT", Font, Brushes.Red, 10, 10)
                    Return
                End If
            Next

            Dim encodedString As String = ""

            For i As Integer = 0 To strLength - 1
                If i > 0 Then encodedString += intercharacterGap
                encodedString += coded39Char(alphabet39.IndexOf(str(i)))
            Next

            Dim encodedStringLength As Integer = encodedString.Length
            Dim widthOfBarCodeString As Integer = 0
            Dim wideToNarrowRatio As Double = 3

            If align <> AlignType.Left Then

                For i As Integer = 0 To encodedStringLength - 1

                    If encodedString(i) = "1"c Then
                        widthOfBarCodeString += CInt((wideToNarrowRatio * CInt(Weight)))
                    Else
                        widthOfBarCodeString += CInt(Weight)
                    End If
                Next
            End If

            Dim x As Integer = 0
            Dim wid As Integer = 0
            Dim yTop As Integer = 0
            Dim hSize As SizeF = e.Graphics.MeasureString(HeaderText, HeaderFont)
            Dim fSize As SizeF = e.Graphics.MeasureString(code, FooterFont)
            Dim headerX As Integer = 0
            Dim footerX As Integer = 0

            If align = AlignType.Left Then
                x = LeftMargin
                headerX = LeftMargin
                footerX = LeftMargin
            ElseIf align = AlignType.Center Then
                x = (Width - widthOfBarCodeString) / 2
                headerX = (Width - CInt(hSize.Width)) / 2
                footerX = (Width - CInt(fSize.Width)) / 2
            Else
                x = Width - widthOfBarCodeString - LeftMargin
                headerX = Width - CInt(hSize.Width) - LeftMargin
                footerX = Width - CInt(fSize.Width) - LeftMargin
            End If

            If ShowHeader Then
                yTop = CInt(hSize.Height) + TopMargin
                e.Graphics.DrawString(HeaderText, HeaderFont, Brushes.Black, headerX, TopMargin)
            Else
                yTop = TopMargin
            End If

            For i As Integer = 0 To encodedStringLength - 1

                If encodedString(i) = "1"c Then
                    wid = CInt((wideToNarrowRatio * CInt(Weight)))
                Else
                    wid = CInt(Weight)
                End If

                e.Graphics.FillRectangle(If(i Mod 2 = 0, Brushes.Black, Brushes.White), x, yTop, wid, Height)
                x += wid
            Next

            yTop += Height
            If ShowFooter Then e.Graphics.DrawString(code, FooterFont, Brushes.Black, footerX, yTop)
        End Sub

        Private Sub printDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
            panel1_Paint(sender, New PaintEventArgs(e.Graphics, Me.ClientRectangle))
        End Sub

        Public Sub SaveImage(ByVal file As String)
            Dim bmp As Bitmap = New Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            Dim g As Graphics = Graphics.FromImage(bmp)
            g.FillRectangle(Brushes.White, 0, 0, Width, Height)
            panel1_Paint(Nothing, New PaintEventArgs(g, Me.ClientRectangle))
            bmp.Save(file)
        End Sub

        Private Sub BarCodeCtrl_Resize(ByVal sender As Object, ByVal e As System.EventArgs)
            panel1.Invalidate()
        End Sub

        Private Sub InitializeComponent()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
            Me.SuspendLayout()
            '
            'Panel1
            '
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(463, 229)
            Me.Panel1.TabIndex = 0
            '
            'PrintDocument1
            '
            '
            'BarCodeCtrl
            '
            Me.Controls.Add(Me.Panel1)
            Me.Name = "BarCodeCtrl"
            Me.Size = New System.Drawing.Size(463, 229)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    End Class
End Namespace
