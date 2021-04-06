Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Configuration


Public Class BarCode2

    Public CODE As String = "12331233"
    Public Article As String = "111111111111"

    Private Sub btImprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImprimer.Click
        If Not IsNumeric(txtQte.text) Then
            txtQte.text = 1
        End If


        Try
            BarCodeCtrl1.Width = CInt(TXTW.text)
            BarCodeCtrl1.BarCodeHeight = CInt(TXTH.text)
            BarCodeCtrl1.LeftMargin = CInt(txtX.text)
            BarCodeCtrl1.TopMargin = CInt(txtY.text)

            BarCodeCtrl1.VertAlign = DSBarCode.BarCodeCtrl.AlignType.Left
            If CbAlign.Text.StartsWith("D") Then BarCodeCtrl1.VertAlign = DSBarCode.BarCodeCtrl.AlignType.Right
            If CbAlign.Text.StartsWith("C") Then BarCodeCtrl1.VertAlign = DSBarCode.BarCodeCtrl.AlignType.Center


        Catch ex As Exception
        End Try



        For i As Integer = 0 To CInt(txtQte.text) - 1
            BarCodeCtrl1.Print()
        Next

        Try

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtX", txtX.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtY", txtY.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TXTW", TXTW.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TXTH", TXTH.text)

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtF1", txtF1.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtZ1", txtZ1.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtF2", txtF2.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtZ2", txtZ2.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "CbAlign", CbAlign.Text)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarCode2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        getRegistryinfo(txtF1, "txtF1", "arial")
        getRegistryinfo(txtZ1, "txtZ1", "10")
        getRegistryinfo(txtF2, "txtF2", "arial")
        getRegistryinfo(txtZ2, "txtZ2", "10")
        getRegistryinfo(txtX, "txtX", "10")
        getRegistryinfo(txtY, "txtY", "10")
        getRegistryinfo(TXTW, "TXTW", "200")
        getRegistryinfo(TXTH, "TXTH", "100")
        getRegistryinfo(CbAlign, "CbAlign", "Centre")

        'getRegistryinfo(TxtBox1, "TxtBox1", "44")
        'getRegistryinfo(TxtBox2, "TxtBox2", "55")
        'getRegistryinfo(TxtBox3, "TxtBox3", "6")
        'getRegistryinfo(TxtBox4, "TxtBox4", "16")
        'getRegistryinfo(TxtBox5, "TxtBox5", "0")
        'getRegistryinfo(TxtBox6, "TxtBox6", "0")
        'getRegistryinfo(CheckBox1, "isRayounage", False)


        Try
            BarCodeCtrl1.Width = CInt(TXTW.text)
            BarCodeCtrl1.BarCodeHeight = CInt(TXTH.text)
            BarCodeCtrl1.HeaderFont = New Font(txtF1.text, CInt(txtZ1.text))
            BarCodeCtrl1.FooterFont = New Font(txtF2.text, CInt(txtZ2.text))
            BarCodeCtrl1.Weight = DSBarCode.BarCodeCtrl.BarCodeWeight.Small
            BarCodeCtrl1.VertAlign = DSBarCode.BarCodeCtrl.AlignType.Left
            'BarCodeCtrl1.LeftMargin
            'BarCodeCtrl1.TopMargin
            BarCodeCtrl1.codePrinterName = Form1.txtprt2.Text  'Form1.txtprt2.Text
            BarCodeCtrl1.BarCode = CODE
            BarCodeCtrl1.HeaderText = Article

            txtCode.text = CODE
        Catch ex As Exception
        End Try

    End Sub


    Private Sub getRegistryinfo(ByRef txt As TxtBox, ByVal str As String, ByVal v As String)
        Try
            Dim msg As String
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, Nothing)
            If msg = Nothing Then
                msg = v
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, msg)
                txt.text = msg
            Else
                txt.text = msg
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub getRegistryinfo(ByRef txt As ComboBox, ByVal str As String, ByVal v As String)
        Try
            Dim msg As String
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, Nothing)
            If msg = Nothing Then
                msg = v
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, msg)
                txt.Text = msg
            Else
                txt.Text = msg
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub getRegistryinfo(ByRef cb As CheckBox, ByVal str As String, ByVal v As Boolean)
        Try
            Dim msg As Boolean
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, Nothing)
            If IsNothing(msg) Then
                msg = v
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, msg)
                cb.Checked = msg
            Else
                cb.Checked = msg
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TXTW_TxtChanged() Handles TXTW.TxtChanged, TXTH.TxtChanged
        Try
            BarCodeCtrl1.Width = CInt(TXTW.text)
            BarCodeCtrl1.Height = CInt(TXTH.text)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click
        Try
            BarCodeCtrl1.HeaderFont = New Font(txtF1.text, CInt(txtZ1.text))
            BarCodeCtrl1.FooterFont = New Font(txtF2.text, CInt(txtZ2.text))
        Catch ex As Exception
        End Try
    End Sub

     
End Class