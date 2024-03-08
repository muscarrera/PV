Imports System.IO.Ports

Public Class PWDPicker
    Private nn As Boolean = False
    Public selectedOne As String = ""
    Dim dt As New DataTable

    Private Sub PWDPicker_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If isPortOn Then
                isPortOn = ClosePort()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public isFillScreen As Boolean = True

    Private Sub PWDPicker_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ALMohassinDBDataSet.admin' table. You can move, or remove it, as needed.

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            dt = a.SelectDataTableSymbols("admin", {"*"})
            DGV1.DataSource = dt
        End Using

        TextBox1.Select()
        Try
            If DGV1.Rows.Count Then
                TextBox2.Text = DGV1.Rows(0).Cells(1).Value
            End If
            If Form1.isMaster = True Then btSlvMode.Visible = False

        Catch ex As Exception
        End Try


        If isFillScreen Then
            Call CenterToScreen()
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.WindowState = FormWindowState.Maximized

            Panel6.Location = New Point((Me.Width - Panel6.Width) \ 2, (Me.Height - Panel6.Height) \ 2)
        End If


        If selectedOne <> "" Then
            For i As Integer = 0 To DGV1.Rows.Count - 1
                If DGV1.Rows(i).Cells(2).Value = selectedOne Then
                    DGV1.Rows(i).Selected = True
                    Exit For
                End If
            Next
        End If

        'Try
        '    If isPortOn = False Then
        '        isPortOn = OpenPort()
        '    End If

        'Catch ex As Exception
        'End Try

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = DGV1.SelectedRows(0).Cells(3).Value Then
            Try
                If isPortOn Then
                    isPortOn = ClosePort()
                End If
            Catch ex As Exception
            End Try

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            MsgBox("الرقم السري عير صحيح")
        End If
    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            Button1_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TextBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Click
        TextBox1.Text = ""
        TextBox1.PasswordChar = "*"
    End Sub
    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick
        Try
            TextBox2.Text = DGV1.SelectedRows(0).Cells(1).Value
            nn = False
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btSlvMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSlvMode.Click
        If TextBox1.Text = DGV1.SelectedRows(0).Cells(3).Value Then
            If Form1.isMaster = False Then
                Using a As BoundClass = New BoundClass
                    a.ChangeConnectionString()
                End Using
            End If


            Try
                If isPortOn Then
                    isPortOn = ClosePort()
                End If
            Catch ex As Exception
            End Try

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            MsgBox("الرقم السري عير صحيح")
        End If
    End Sub
    Private Sub Panel7_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel7.MouseClick
      

        If isFillScreen Then
            Try
                If isPortOn Then
                    isPortOn = ClosePort()
                End If
            Catch ex As Exception
            End Try

            End
        Else

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If

    End Sub
    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        Dim a = 300
        If plClavier.Width > 100 Then a = -300
        Panel6.Width += a
        plClavier.Width += a
        Panel6.Location = New Point((Me.Width - Panel6.Width) \ 2, (Me.Height - Panel6.Height) \ 2)

    End Sub
    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click, Button31.Click, Button30.Click, Button29.Click, Button28.Click, Button27.Click, Button26.Click, Button25.Click, Button24.Click, Button23.Click
        If nn = False Then
            TextBox1.Text = ""
            nn = True
        End If

        Dim bt As Button = sender
        TextBox1.Text = TextBox1.Text + bt.Text
    End Sub
    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button33.Click
        TextBox1.Text = ""
        nn = True
    End Sub



    '/////////// BALANCE ////////////////////////
    Public mySerialPort As SerialPort
    Dim _isOn As Boolean

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
                pl.BackColor = Color.PaleGreen
            Else
                pl.BackColor = Color.Salmon
            End If

        End Set
    End Property
    Public Sub DataReceivedHandler(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
        Try
            Dim sp As SerialPort = CType(sender, SerialPort)
            Dim indata As String = sp.ReadLine()

            Try
                lbrf.BeginInvoke(New Action(Function()
                                                Try
                                                    Me.DialogResult = Windows.Forms.DialogResult.OK
                                                Catch ex As Exception
                                                End Try

                                                Return True
                                            End Function))
            Catch ex As Exception

            End Try


            Dim isAdmin As Boolean = False

            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i).Item("rf") = indata Then

                    For r As Integer = 0 To DGV1.Rows.Count - 1
                        If DGV1.Rows(r).Cells(0).Value = dt.Rows(i).Item(0) Then
                            DGV1.Rows(r).Selected = True
                            isAdmin = True
                        End If
                    Next


                End If
            Next

            If isAdmin Then
                '     lbQte.Text = indata
                Me.BeginInvoke(New Action(Function()
                                              Try
                                                    Me.DialogResult = Windows.Forms.DialogResult.OK
                                              Catch ex As Exception
                                              End Try

                                              Return True
                                          End Function))
            End If


        Catch ex As Exception

        End Try
    End Sub
  
    Private Sub pl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pl.Click
        Try
            If isPortOn = False Then
                isPortOn = OpenPort()
            End If

        Catch ex As Exception
        End Try
    End Sub
 
End Class