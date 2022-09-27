Imports System.IO

Imports System.Drawing.Imaging

Public Class PricingGetter
    Private lst As New List(Of Image)
    Private i As Integer = 0
    Dim txtImgPr As String
    Dim txtImgSl As String

    Private Sub TrialNumb()

        Dim value As Integer = 1
        value = getRegistryinfo("Pricing_Trial_Use", 1)

        If value = 0 Then
            plTrial.Visible = False
            lbtrial.Visible = False
        ElseIf value >= 1 And value < 50 Then
            plTrial.Visible = True
            lbtrial.Text = value
            value += 1
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "Pricing_Trial_Use", value)
        Else

            Dim m = InputBox("Code =  " & value)
            If Not IsNumeric(m) Then
                End
            End If

            Dim tr = value * 11
            tr += 123
            tr *= 11

            tr = CInt(Now.Day() & "0" & tr & "0" & Now.Month)
            If m = tr Then
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "Pricing_Trial_Use", 0)
                plTrial.Visible = False
                lbtrial.Visible = False
            Else
                End
            End If
        End If
    End Sub

    Private Sub PricingGetter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitForm()

        TrialNumb() '' Activation

        Call CenterToScreen()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized

        pl.Location = New Point((Me.Width - pl.Width) \ 2, (Me.Height - pl.Height) \ 2)






        Me.Show()

        txt.Focus()
    End Sub
    Private Function getRegistryinfo(ByVal str As String, ByVal v As String)
        Try
            Dim msg As String
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, Nothing)
            If msg = Nothing Then
                msg = v
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, msg)
                Return msg
            Else
                Return msg
            End If
        Catch ex As Exception
        End Try

        Return v
    End Function
    Private Function getRegistryinfo(ByVal str As String, ByVal v As Integer)
        Try
            Dim msg As String
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, Nothing)
            If msg = Nothing Then
                msg = v
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, msg)
                Return msg
            Else
                Return msg
            End If
        Catch ex As Exception
        End Try

        Return v
    End Function
    Private Sub InitForm()
        Try
            txtImgPr = getRegistryinfo("ImgPath", "C:\Al Mohassib")
            txtImgSl = getRegistryinfo("ImgPathSl", "C:\Al Mohassib")

            lbInfo.Text = getRegistryinfo("pricingMsh", "Welcome")
            Timer1.Interval = CInt(getRegistryinfo("intSlider", "10")) * 1000
            Timer2.Interval = CInt(getRegistryinfo("intProduct", "20")) * 1000

        Catch ex As Exception

        End Try

        Try
            pbScanner.BackgroundImage = Image.FromFile(getRegistryinfo("imgScanner", "C:\Al Mohassib\imgscanner.jpg"))
        Catch ex As Exception
            pbScanner.BackgroundImage = My.Resources.s_l300
        End Try

        Try
            Dim strFileSize As String = ""
            Dim di As New IO.DirectoryInfo(txtImgSl)
            Dim aryFi As IO.FileInfo() = di.GetFiles("*.jpg")
            Dim fi As IO.FileInfo

            For Each fi In aryFi
                lst.Add(Image.FromFile(fi.FullName))
            Next
        Catch ex As Exception
            lst.Add(PbProduct.Image)
        End Try


        pb.BackgroundImage = lst(0)
        i = 1
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Try
            pb.BackgroundImage = lst(i)
            i += 1
        Catch ex As Exception
            pb.BackgroundImage = lst(0)
            i = 1
        End Try

        txt.Focus()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        pl.Visible = False

        Timer2.Enabled = False


        txt.Focus()
    End Sub

    Private Sub txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt.KeyPress
        Try
            If e.KeyChar = Chr(13) Then


                If txt.Text.StartsWith("9999") Then  ' sell a balance broduct
                    Dim str As String = txt.Text.Remove(0, 4)
                    str = str.Remove(str.Length - 1)

                    Dim ref As String = ""
                    Try
                        ref = str.Remove(3)
                        getBalancebyRef(ref)
                    Catch ex As Exception

                    End Try
                Else
                    SearchForcodebarOnly(txt)
                End If



                txt.Text = ""
                txt.Focus()
            End If

        Catch ex As Exception
        End Try


    End Sub

    Public Sub SearchForcodebarOnly(ByRef txt As TextBox)

        Try
            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

                Dim params As New Dictionary(Of String, Object)
                Dim artdt As DataTable

                '''''''''''''''''''
                params.Add("codebar LIKE ", "%" & txt.Text & "%")
                artdt = a.SelectDataTableSymbols("article", {"*"}, params)
                 
                If artdt.Rows.Count > 0 Then

                    Label1.Text = String.Format("{0:n2}", CDec(artdt.Rows(0).Item("sprice").ToString())) & "  Dhs"
                    Label2.Text = artdt.Rows(0).Item("name").ToString & " - " & artdt.Rows(0).Item("unite").ToString

                    Try
                        Dim str As String = txtImgPr & "\art" & artdt.Rows(0).Item("img").ToString
                        Using bm As Bitmap = New Bitmap(str)
                            Dim ms As New MemoryStream()
                            bm.Save(ms, ImageFormat.Bmp)
                            PbProduct.Image = Image.FromStream(ms)
                        End Using
                    Catch ex As Exception
                        PbProduct.Image = My.Resources.consumer_products
                    End Try

                    pl.Visible = True
                    Timer2.Enabled = True

                Else

                End If

            End Using
        Catch ex As Exception

        End Try

    End Sub
    Public Sub getBalancebyRef(ByRef ref As String)

        Try
            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

                Dim params As New Dictionary(Of String, Object)
                Dim artdt As DataTable

                '''''''''''''''''''
                params.Add("codebar", ref)
                params.Add("mixte", True)
                artdt = a.SelectDataTableSymbols("article", {"*"}, params)

                If artdt.Rows.Count > 0 Then

                    Label1.Text = String.Format("{0:n2}", CDec(artdt.Rows(0).Item("sprice").ToString())) & "  Dhs"
                    Label2.Text = artdt.Rows(0).Item("name").ToString & " - " & artdt.Rows(0).Item("unite").ToString

                    Dim str As String = txtImgPr & "\art" & artdt.Rows(0).Item("img").ToString

                    Try
                        Using bm As Bitmap = New Bitmap(str)
                            Dim ms As New MemoryStream()
                            bm.Save(ms, ImageFormat.Bmp)
                            PbProduct.Image = Image.FromStream(ms)
                        End Using
                    Catch ex As Exception
                        PbProduct.Image = My.Resources.consumer_products
                    End Try


                    pl.Visible = True
                    Timer2.Enabled = True
                Else

                End If

            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Panel7_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel7.MouseClick
        End
    End Sub

    Private Sub Panel9__MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel9.MouseClick
        Dim pr As New PricingParams
        If pr.ShowDialog = Windows.Forms.DialogResult.OK Then
            InitForm()
        End If
    End Sub

    Private Sub Panel10_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles plTrial.MouseClick
        Dim m = InputBox("Code =  " & lbtrial.Text)
        If Not IsNumeric(m) Then
            End
        End If

        Dim tr = CInt(lbtrial.Text) * 11
        tr += 123
        tr *= 11

        tr = CInt(Now.Day() & "0" & tr & "0" & Now.Month)
        If m = tr Then
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "Pricing_Trial_Use", 0)
            plTrial.Visible = False
            lbtrial.Visible = False
        End If

    End Sub
End Class