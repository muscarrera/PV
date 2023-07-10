Imports System.IO.Ports

Public Class Addadmin

    Private Sub Addadmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ALMohassinDBDataSet.admin' table. You can move, or remove it, as needed.

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            DataGridView1.DataSource = a.SelectDataTableSymbols("admin", {"*"})
            If Form1.adminId <> "1" Then
                DataGridView1.Columns(3).Visible = False
            End If
        End Using

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub RectangleShape6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RsDel.Click
        If DataGridView1.Rows.Count = 1 Then
            Exit Sub
        End If

        If DataGridView1.SelectedRows(0).Cells(0).Value = 1 Then
            MsgBox("فشل في العملية. لايمكن حذف  الادمين الرئيسي ")
            Exit Sub
        End If


        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            '''''''''''''''''''
            params.Add("adid", DataGridView1.SelectedRows(0).Cells(0).Value)
            If a.DeleteRecords("admin", params) Then
                DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))
            End If

        End Using


    End Sub

    Private Sub RectangleShape5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RsEdit.Click
        Dim str As String = Form1.adminId

        TextBox1.Text = DataGridView1.SelectedRows(0).Cells(1).Value
        If DataGridView1.SelectedRows(0).Cells(2).Value = "admin" Then
            ComboBox1.Text = "مسؤول"
        Else
            ComboBox1.Text = "مستخدم"
        End If
        lbrf.Text = DataGridView1.SelectedRows(0).Cells(4).Value
        TextBox1.Tag = DataGridView1.SelectedRows(0).Cells(0).Value
        'TextBox1.Enabled = False
        ComboBox1.Enabled = False



        Button2.Tag = "1"


        Try
            If isPortOn = False Then
                isPortOn = OpenPort()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub RectangleShape4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RsAdd.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Tag = ""
        Button2.Tag = "2"
        rf = ""
        lbrf.Text = "0"
        Try
            If isPortOn = False Then
                isPortOn = OpenPort2()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try


            Dim a As String = "not"
            If ComboBox1.Text = "مسؤول" Or ComboBox1.Text = "admin" Then
                a = "admin"
            End If

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                params.Add("name", TextBox1.Text)
                params.Add("admin", a)
                params.Add("rf", lbrf.Text)

                If Button2.Tag = "1" Then
                    If TextBox2.Text <> "" Then params.Add("pwd", TextBox2.Text)
                    Dim where As New Dictionary(Of String, Object)
                    where.Add("adid", TextBox1.Tag)
                    c.UpdateRecord("admin", params, where)
                    where = Nothing

                Else
                    If TextBox2.Text = "" Then Exit Sub
                    params.Add("pwd", TextBox2.Text)
                    c.InsertRecord("admin", params, True)
                End If
            End Using

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                DataGridView1.DataSource = c.SelectDataTableSymbols("admin", {"*"})
            End Using

            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox1.Tag = ""

        Catch ex As Exception
            MsgBox(ex)
        End Try

        lbrf.Text = "0"
        TextBox2.Tag = "0"
        Button2.Tag = "2"
        TextBox1.Enabled = True
        ComboBox1.Enabled = True

        Try
            If isPortOn Then
                isPortOn = ClosePort()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Tag = ""
        Button2.Tag = "2"
        lbrf.Text = "0"

        Try
            If isPortOn Then
                isPortOn = ClosePort()
            End If
        Catch ex As Exception
        End Try
    End Sub



    '/////////// BALANCE ////////////////////////
    Public mySerialPort As SerialPort
    Dim _isOn As Boolean
    Dim rf As String

    Public Function OpenPort() As Boolean
        Try
            If Form1.txtRfidCom.Text.Length < 3 Then Return False

            mySerialPort = New SerialPort(Form1.txtRfidCom.Text.Trim)
            mySerialPort.BaudRate = 9600
            mySerialPort.Parity = Parity.None
            mySerialPort.StopBits = StopBits.One
            mySerialPort.DataBits = 8
            mySerialPort.Handshake = Handshake.None
            mySerialPort.RtsEnable = True
            AddHandler mySerialPort.DataReceived, New SerialDataReceivedEventHandler(AddressOf DataReceivedHandler)
            If mySerialPort.IsOpen = False Then mySerialPort.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Try
                If mySerialPort.IsOpen Then mySerialPort.Close()
            Catch exx As Exception
            End Try
        End Try
        Return mySerialPort.IsOpen
    End Function
    Public Function OpenPort2() As Boolean
        Try
            If Form1.txtRfidCom.Text.Length < 3 Then Return False

            mySerialPort = New SerialPort(Form1.txtRfidCom.Text.Trim)
            mySerialPort.BaudRate = 9600
            mySerialPort.Parity = Parity.None
            mySerialPort.StopBits = StopBits.One
            mySerialPort.DataBits = 8
            mySerialPort.Handshake = Handshake.None
            mySerialPort.RtsEnable = True
            AddHandler mySerialPort.DataReceived, New SerialDataReceivedEventHandler(AddressOf DataReceivedHandler2)
            If mySerialPort.IsOpen = False Then mySerialPort.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Try
                If mySerialPort.IsOpen Then mySerialPort.Close()
            Catch exx As Exception
            End Try
        End Try
        Return mySerialPort.IsOpen
    End Function
    Public Function ClosePort() As Boolean
        Try
            If Form1.txtRfidCom.Text.Length < 3 Then Return False

            RemoveHandler mySerialPort.DataReceived, AddressOf DataReceivedHandler
            mySerialPort.Close()
            mySerialPort = Nothing

        Catch ex As Exception
        End Try

        Return False

    End Function
    Public Property isPortOn() As Boolean
        Get
            Return _isOn
        End Get
        Set(ByVal value As Boolean)
            _isOn = value

            If value Then
                GB.BackColor = Color.PaleGreen
            Else
                GB.BackColor = Color.Salmon
            End If

        End Set
    End Property
    Public Sub DataReceivedHandler(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
        Try
            Dim sp As SerialPort = CType(sender, SerialPort)
            Dim indata As String = sp.ReadExisting

            lbrf.BeginInvoke(New Action(Function()
                                            Try
                                                lbb.Text += 1
                                                lbrf.Text = indata
                                            Catch ex As Exception
                                                MsgBox(ex.Message)
                                            End Try

                                            Return True
                                        End Function))

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "tesst")
        End Try
         
    End Sub
    Public Sub DataReceivedHandler2(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
        Try
            Dim sp As SerialPort = CType(sender, SerialPort)
            Dim indata As String = sp.ReadLine

            lbrf.BeginInvoke(New Action(Function()
                                            Try
                                                lbb.Text += 1
                                                lbrf.Text = indata
                                            Catch ex As Exception
                                                MsgBox(ex.Message)
                                            End Try

                                            Return True
                                        End Function))

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "tesst")
        End Try

    End Sub

End Class