Public Class LabelSetting

    Dim article As String = "azerty yuiop qsdfghé"
    Dim Code As String = "123456789012"
    Dim qte As Decimal = 16.55
    Dim br As Brush = Brushes.Black



    Private Sub LabelSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getRegistryinfo(txtF1, "txtF1", "arial")
        getRegistryinfo(txtZ1, "txtZ1", "10")
        getRegistryinfo(txtF2, "txtF2", "arial")
        getRegistryinfo(txtZ2, "txtZ2", "10")
        getRegistryinfo(txtX, "txtX", "10")
        getRegistryinfo(txtY, "txtY", "10")
        getRegistryinfo(TXTW, "TXTW", "200")
        getRegistryinfo(TXTH, "TXTH", "100")

        getRegistryinfo(TxtBox1, "TxtBox1", "44")
        getRegistryinfo(TxtBox2, "TxtBox2", "55")
        getRegistryinfo(TxtBox3, "TxtBox3", "6")
        getRegistryinfo(TxtBox4, "TxtBox4", "16")
        getRegistryinfo(TxtBox5, "TxtBox5", "0")
        getRegistryinfo(TxtBox6, "TxtBox6", "0")
        getRegistryinfo(CheckBox1, "isRayounage", False)
        getRegistryinfo(lb, "EtqSelectedMode", "Normal")
        getRegistryinfo(lbmode, "EtqMode", "Normal")


        getRegistryinfo(Button3, "br", 0)

        br = New SolidBrush(Button3.BackColor)

        Dim str = lbmode.Text.Split("|")

        For i As Integer = 0 To str.Length - 1
            DataGridView1.Rows.Add(str(i))
        Next

        SelectedMode(lb.Text)
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim fntdlg As New FontDialog
            If fntdlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            txtF1.text = fntdlg.Font.Name
            txtZ1.text = CInt(fntdlg.Font.Size)

          
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim fntdlg As New FontDialog
            If fntdlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            txtF2.text = fntdlg.Font.Name
            txtZ2.text = CInt(fntdlg.Font.Size)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
    Private Sub txtX_TxtChanged() Handles txtZ2.TxtChanged, txtZ1.TxtChanged, txtY.TxtChanged, txtX.TxtChanged, TXTW.TxtChanged, TXTH.TxtChanged, txtF2.TxtChanged, txtF1.TxtChanged, TxtBox4.TxtChanged, TxtBox3.TxtChanged, TxtBox2.TxtChanged, TxtBox1.TxtChanged, TxtBox5.TxtChanged, TxtBox6.TxtChanged
        Try
            GetApercu()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub SaveDefault()

        Try

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtX", txtX.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtY", txtY.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TXTW", TXTW.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TXTH", TXTH.text)

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtF2", txtF2.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtZ2", txtZ2.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtF1", txtF1.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtZ1", txtZ1.text)

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TxtBox1", TxtBox1.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TxtBox2", TxtBox2.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TxtBox3", TxtBox3.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TxtBox4", TxtBox4.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TxtBox5", TxtBox5.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TxtBox6", TxtBox6.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "isRayounage", CheckBox1.Checked)

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "br", Button3.BackColor.ToArgb)


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try

    End Sub
    Private Sub GetApercu()
        If txtX.text = "" Then txtX.text = 10
        If txtY.text = "" Then txtY.text = 10
        If TXTW.text = "" Then TXTW.text = 200
        If TXTH.text = "" Then TXTH.text = 100

        Dim BMP As New Bitmap(CInt(TXTW.text), CInt(TXTH.text), Imaging.PixelFormat.Format24bppRgb)

        ' create the graphics object
        Dim GR As Graphics = Graphics.FromImage(BMP)

        ' fill the image with color white
        GR.Clear(Color.White)

        Dim sf2 As New StringFormat()
        Dim bigPrice As Integer = 0
        Dim smallPrice As Double = 0
        SplitDecimal(qte, bigPrice, smallPrice)
        Dim SM As Integer = CInt(smallPrice * 100)

        Dim fntT As Font = New Font("Tahoma", CInt(TxtBox4.text), FontStyle.Bold)
        Dim fntP As Font = New Font("Arial", CInt(TxtBox3.text), FontStyle.Bold)

        Dim fntName As Font = New Font(txtF1.text, CInt(txtZ1.text))
        Dim fntcode As Font = New Font(txtF2.text, CInt(txtZ2.text))


        If CheckBox1.Checked = False Then
            GR.FillRectangle(Brushes.Coral, 0, CInt(TxtBox5.text), CInt(TXTW.text), CInt(TXTH.text))

            GR.FillRectangle(br, CInt(TXTW.text) - (CInt(TxtBox2.text) + CInt(TxtBox1.text)), CInt(txtY.text), CInt(TxtBox2.text) + 5, fntT.Height)

            sf2.Alignment = StringAlignment.Near
            GR.DrawString(SM, fntP, Brushes.White, New RectangleF(CInt(TXTW.text) - CInt(TxtBox1.text), CInt(txtY.text), CInt(TxtBox1.text), fntcode.Height), sf2)

            sf2.Alignment = StringAlignment.Far
            GR.DrawString(bigPrice, fntT, Brushes.White, New RectangleF(CInt(TXTW.text) - CInt(TxtBox2.text) - CInt(TxtBox1.text) - 2, CInt(txtY.text), CInt(TxtBox2.text), fntcode.Height), sf2)

            sf2.Alignment = StringAlignment.Center
            GR.DrawString(article, fntName, Brushes.Black, New RectangleF(2, 3, CInt(TXTW.text) - CInt(TxtBox2.text), CInt(TxtBox5.text) + 30), sf2)

            GR.FillRectangle(Brushes.White, 0, CInt(TxtBox6.text), CInt(TXTW.text), fntcode.Height * 5)
            GR.DrawString(Code, fntcode, Brushes.Black, New RectangleF(2, CInt(TxtBox6.text), CInt(TXTW.text), fntcode.Height), sf2)

        Else

            ''txstrFormat1.FormatFlags = StringFormatFlags.DirectionVertical;()

            'sf2.Alignment = StringAlignment.Center
            'If cbPromo.Checked Then
            '    sf2.FormatFlags = StringFormatFlags.DirectionVertical
            '    GR.FillRectangle(Brushes.Red, 0, 0, 25, CInt(TXTH.text))
            '    GR.DrawString("PROMO", fntT, Brushes.White, New RectangleF(2, 2, CInt(TXTW.text), fntcode.Height), sf2)

            'End If





            GR.DrawString(article, fntName, Brushes.Black, New RectangleF(2, 3, CInt(TXTW.text), CInt(TxtBox5.text)), sf2)

            GR.FillRectangle(br, CInt(TXTW.text) - (CInt(TxtBox2.text) + CInt(TxtBox1.text)), CInt(txtY.text), CInt(TxtBox2.text) + CInt(TxtBox1.text) + 5, fntT.Height)

            sf2.Alignment = StringAlignment.Near
            GR.DrawString(SM, fntP, Brushes.White, New RectangleF(CInt(TXTW.text) - CInt(TxtBox1.text), CInt(txtY.text), CInt(TxtBox1.text), fntT.Height), sf2)

            sf2.Alignment = StringAlignment.Far
            GR.DrawString(bigPrice, fntT, Brushes.White, New RectangleF(CInt(TXTW.text) - CInt(TxtBox2.text) - CInt(TxtBox1.text) - 2, txtY.text, CInt(TxtBox2.text), fntT.Height), sf2)
            GR.DrawString("درهم", fntName, Brushes.Black, New RectangleF(0, txtY.text, CInt(TXTW.text) - CInt(TxtBox2.text) - CInt(TxtBox1.text) - 4, fntT.Height), sf2)

        End If




        Pb.BackgroundImage = BMP


        'Pb.Image = createBarCodeNoDescription(Code, Color.Blue, 12, False)
    End Sub
    Private Sub SaveMode(ByVal str As String)

        Try
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtX" & str, txtX.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtY" & str, txtY.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TXTW" & str, TXTW.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TXTH" & str, TXTH.text)

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtF2" & str, txtF2.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtZ2" & str, txtZ2.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtF1" & str, txtF1.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtZ1" & str, txtZ1.text)

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TxtBox1" & str, TxtBox1.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TxtBox2" & str, TxtBox2.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TxtBox3" & str, TxtBox3.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TxtBox4" & str, TxtBox4.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TxtBox5" & str, TxtBox5.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "TxtBox6" & str, TxtBox6.text)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "isRayounage" & str, CheckBox1.Checked)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "br" & str, Button3.BackColor.ToArgb)


            lb.Text = str
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try

    End Sub
    Private Sub SelectedMode(ByVal str As String)

        Try

            getRegistryinfo(txtF1, "txtF1" & str, "arial")
            getRegistryinfo(txtZ1, "txtZ1" & str, "10")
            getRegistryinfo(txtF2, "txtF2" & str, "arial")
            getRegistryinfo(txtZ2, "txtZ2" & str, "10")
            getRegistryinfo(txtX, "txtX" & str, "10")
            getRegistryinfo(txtY, "txtY" & str, "10")
            getRegistryinfo(TXTW, "TXTW" & str, "200")
            getRegistryinfo(TXTH, "TXTH" & str, "100")

            getRegistryinfo(TxtBox1, "TxtBox1" & str, "44")
            getRegistryinfo(TxtBox2, "TxtBox2" & str, "55")
            getRegistryinfo(TxtBox3, "TxtBox3" & str, "6")
            getRegistryinfo(TxtBox4, "TxtBox4" & str, "16")
            getRegistryinfo(TxtBox5, "TxtBox5" & str, "0")
            getRegistryinfo(TxtBox6, "TxtBox6" & str, "0")
            getRegistryinfo(CheckBox1, "isRayounage" & str, False)

            getRegistryinfo(Button3, "br" & str, 0)

            br = New SolidBrush(Button3.BackColor)


            lb.Text = str
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try

    End Sub


    Private Sub getRegistryinfo(ByRef txt As Label, ByVal str As String, ByVal v As String)
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
    Private Sub getRegistryinfo(ByRef cb As Button, ByVal str As String, ByVal v As Boolean)
        Try
            Dim msg As Integer
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, Nothing)
            If IsNothing(msg) Then
                msg = v
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, msg)
                cb.BackColor = Color.FromArgb(msg)
            Else
                cb.BackColor = Color.FromArgb(msg)

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim cl As New ColorDialog
        If cl.ShowDialog = Windows.Forms.DialogResult.OK Then
            br = New SolidBrush(cl.Color)

            Button3.BackColor = cl.Color
        End If

        Try
            GetApercu()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.SelectedRows.Count = 0 Then Exit Sub

        SelectedMode(DataGridView1.SelectedRows(0).Cells(0).Value.ToString)
    End Sub

    Private Sub btImprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImprimer.Click
        SaveDefault()
        SaveMode(lb.Text)
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "EtqSelectedMode", lb.Text)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim str = InputBox("Nom  =  ")
        If str = "" Then Exit Sub

        lbmode.Text &= "|" & str

        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "EtqMode", lbmode.Text)

        DataGridView1.Rows.Add(str)

        SelectedMode(str)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If lb.Text = "" Then Exit Sub
        If DataGridView1.Rows.Count <= 1 Then Exit Sub

        Dim str As String = ""
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(0).Value.ToString = lb.Text Then Continue For
            If str.Length > 0 Then str &= "|"
            str &= DataGridView1.Rows(i).Cells(0).Value.ToString
        Next
        lbmode.Text = str
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "EtqMode", lbmode.Text)

        DataGridView1.Rows.Clear()

        Dim stra = lbmode.Text.Split("|")

        For i As Integer = 0 To stra.Length - 1
            DataGridView1.Rows.Add(stra(i))
        Next
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged, cbPromo.CheckedChanged
        Try
            GetApercu()
        Catch ex As Exception

        End Try
    End Sub
End Class