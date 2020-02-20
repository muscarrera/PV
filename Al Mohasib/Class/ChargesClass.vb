Public Class ChargesClass
    Implements IDisposable

    Public Sub GetCharges(ByVal dt1 As Date, ByVal dt2 As Date, ByRef data As DataGridView)
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            Dim admin As Boolean = Form1.admin

            Dim firstday As Date = dt1.AddDays(-1) 'DateSerial(y, M, 0)
            Dim lastday As Date = dt2.AddDays(1) 'DateSerial(y, M + 1, 1)

            params.Clear()
            data.Rows.Clear()

            params.Add("date > ", firstday)
            params.Add("date < ", lastday)

            Dim dt = a.SelectDataTableSymbols("Charge", {"*"}, params)
            Dim total As Double = 0
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If admin = False And dt.Rows(i).Item("name").ToString.Contains("ouvrier") Then Continue For
                    If admin = False And dt.Rows(i).Item("name").ToString.Contains("CNSS") Then Continue For
                    data.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("date"),
                                  dt.Rows(i).Item("name"), dt.Rows(i).Item("price"),
                                  dt.Rows(i).Item("duree"), dt.Rows(i).Item("isRepeated"))
                    total += CDbl(dt.Rows(i).Item("price"))
                Next
            End If
            Try
                Form1.txtchtotal.Text = total
                Form1.txtchNum.Text = Form1.dgvCharge.Rows.Count
                Form1.lbChargesMonth.Text = "du " & dt1.ToString("dd, MMM yy") & " au " & dt2.ToString("dd, MMM yy")
            Catch ex As Exception

            End Try
        End Using
    End Sub

    Public Sub GetUnPaiedCharges(ByRef data As DataGridView, ByRef fl As FlowLayoutPanel)
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)

            Dim firstday As Date = DateSerial(Now.Year, Now.Month - 1, 0)
            Dim lastday As Date = DateSerial(Now.Year, Now.Month, 1)

            params.Clear()
            data.Rows.Clear()

            params.Add("date > ", firstday)
            params.Add("date < ", lastday)
            params.Add("isRepeated = ", True)

            Dim dt = a.SelectDataTableSymbols("Charge", {"*"}, params)

            If dt.Rows.Count > 0 Then

                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim dte As Date = CDate(dt.Rows(i).Item("date"))
                    Dim duree As Integer = CInt(dt.Rows(i).Item("duree"))

                    Dim spm As TimeSpan = Date.Now - dte
                    If spm.Days > duree Then

                        Dim bt As New Button
                        bt.Tag = dt.Rows(i).Item(0) & "@" & dt.Rows(i).Item("duree") & "@" & dt.Rows(i).Item("price")
                        bt.Text = dt.Rows(i).Item("name")
                        bt.Width = 125
                        bt.Height = 90
                        Dim rnd As New Random
                        bt.BackColor = Color.FromArgb(255, Rnd.Next(255), Rnd.Next(255), Rnd.Next(255))
                        AddHandler bt.Click, AddressOf Charge_click
                        fl.Controls.Add(bt)
                    End If
                Next
            End If
        End Using
    End Sub
    Private Sub Charge_click(ByVal sender As Object, ByVal e As EventArgs)
        Dim bt As Button = sender
        AddCharges(bt)
    End Sub

    Public Sub AddCharges(ByRef data As DataGridView)

        Dim addch As New AddEditCharges
        If addch.ShowDialog = DialogResult.OK Then

            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                params.Add("name", addch.chargename)
                params.Add("price", addch.price)
                params.Add("isRepeated", addch.isR)
                params.Add("duree", addch.duree)
                params.Add("writer", Form1.adminName)
                params.Add("date", Now.Date)

                a.InsertRecord("Charge", params)

                Dim firstday As Date = DateSerial(Now.Year, Now.Month, 0)
                Dim lastday As Date = DateSerial(Now.Year, Now.Month + 1, 1)

                params.Clear()
                data.Rows.Clear()

                params.Add("date > ", firstday)
                params.Add("date < ", lastday)

                Dim dt = a.SelectDataTableSymbols("Charge", {"*"}, params)
                Dim total As Double = 0
                If dt.Rows.Count > 0 Then

                    For i As Integer = 0 To dt.Rows.Count - 1
                        data.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("date"),
                                      dt.Rows(i).Item("name"), dt.Rows(i).Item("price"),
                                      dt.Rows(i).Item("duree"), dt.Rows(i).Item("isRepeated"))
                        total += CDbl(dt.Rows(i).Item("price"))
                    Next
                End If

                Form1.txtchtotal.Text = total
                Form1.txtchNum.Text = Form1.dgvCharge.Rows.Count
            End Using
        End If

    End Sub
    Public Sub AddCharges(ByRef bt As Button)

        Dim addch As New AddEditCharges
        Dim str As String() = bt.Tag.ToString.Split("@")
        addch.chargename = bt.Text
        addch.price = str(2)
        addch.duree = str(1)
        addch.isR = True
        Dim chid As Integer = str(0)

        If addch.ShowDialog = DialogResult.OK Then

            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                params.Add("name", addch.chargename)
                params.Add("price", addch.price)
                params.Add("isRepeated", addch.isR)
                params.Add("duree", addch.duree)
                params.Add("writer", Form1.adminName)
                params.Add("date", Now.Date)

                a.InsertRecord("Charge", params)
                params.Clear()

                Dim where As New Dictionary(Of String, Object)
                where.Add("chid", chid)
                params.Add("isRepeated", False)
                a.UpdateRecord("Charge", params, where)

                params.Clear()
                where.Clear()

                Form1.FlpCharges.Controls.Remove(bt)
                Form1.dgvCharge.Rows.Clear()

                Dim firstday As Date = DateSerial(Now.Year, Now.Month, 0)
                Dim lastday As Date = DateSerial(Now.Year, Now.Month + 1, 1)

                params.Add("date > ", firstday)
                params.Add("date < ", lastday)

                Dim dt = a.SelectDataTableSymbols("Charge", {"*"}, params)
                Dim total As Double = 0
                If dt.Rows.Count > 0 Then

                    For i As Integer = 0 To dt.Rows.Count - 1
                        Form1.dgvCharge.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("date"),
                                      dt.Rows(i).Item("name"), dt.Rows(i).Item("price"),
                                      dt.Rows(i).Item("duree"), dt.Rows(i).Item("isRepeated"))
                        total += CDbl(dt.Rows(i).Item("price"))
                    Next
                End If

                Form1.txtchtotal.Text = total
                Form1.txtchNum.Text = Form1.dgvCharge.Rows.Count
            End Using
        End If

    End Sub
    Public Sub EditCharges(ByVal id As Integer, ByVal name As String, ByVal price As Double,
                           ByVal duree As Integer, ByVal isR As Boolean, ByRef data As DataGridView)

        Dim addch As New AddEditCharges

        addch.chargename = name
        addch.price = price
        addch.duree = duree
        addch.isR = isR

        If addch.ShowDialog = DialogResult.OK Then

            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                Dim where As New Dictionary(Of String, Object)

                params.Add("name", addch.chargename)
                params.Add("price", addch.price)
                params.Add("isRepeated", addch.isR)
                params.Add("duree", addch.duree)

                where.Add("chid", id)

                a.UpdateRecord("Charge", params, where)

                Dim firstday As Date = DateSerial(Now.Year, Now.Month, 0)
                Dim lastday As Date = DateSerial(Now.Year, Now.Month + 1, 1)

                params.Clear()

                data.Rows.Clear()

                params.Add("date > ", firstday)
                params.Add("date < ", lastday)

                Dim dt = a.SelectDataTableSymbols("Charge", {"*"}, params)

                Dim total As Double = 0
                If dt.Rows.Count > 0 Then

                    For i As Integer = 0 To dt.Rows.Count - 1
                        data.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("date"),
                                      dt.Rows(i).Item("name"), dt.Rows(i).Item("price"),
                                      dt.Rows(i).Item("duree"), dt.Rows(i).Item("isRepeated"))
                        total += CDbl(dt.Rows(i).Item("price"))
                    Next
                End If

                Form1.txtchtotal.Text = total
                Form1.txtchNum.Text = Form1.dgvCharge.Rows.Count
            End Using
        End If

    End Sub

    Public Sub DeleteCharges(ByVal id As Integer, ByVal name As String, ByRef data As DataGridView)

        Dim str As String = " عند قيامكم على الضغط على 'موافق' سيتم حذف الحمولة "
        str = str + vbNewLine
        str = str & "رقم" & id
        str = str + vbNewLine
        str = str + name

        If MsgBox(str, MsgBoxStyle.YesNo Or MessageBoxIcon.Exclamation, "الغاء الفاتورة") = MsgBoxResult.No Then
            Exit Sub
        End If

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            Dim params As New Dictionary(Of String, Object)

            params.Add("chid", id)
            a.DeleteRecords("Charge", params)

            Dim firstday As Date = DateSerial(Now.Year, Now.Month, 0)
            Dim lastday As Date = DateSerial(Now.Year, Now.Month + 1, 1)

            params.Clear()

            data.Rows.Clear()

            params.Add("date > ", firstday)
            params.Add("date < ", lastday)

            Dim dt = a.SelectDataTableSymbols("Charge", {"*"}, params)

            Dim total As Double = 0
            If dt.Rows.Count > 0 Then

                For i As Integer = 0 To dt.Rows.Count - 1
                    data.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("date"),
                                  dt.Rows(i).Item("name"), dt.Rows(i).Item("price"),
                                  dt.Rows(i).Item("duree"), dt.Rows(i).Item("isRepeated"))
                    total += CDbl(dt.Rows(i).Item("price"))
                Next
            End If

            Form1.txtchtotal.Text = total
            Form1.txtchNum.Text = Form1.dgvCharge.Rows.Count
        End Using

    End Sub

    Public Sub FillbtCharge()

        Dim admin As Boolean = Form1.admin
        Dim p As FlowLayoutPanel = Form1.FlpCharges
        p.Controls.Clear()
        If Form1.admin = False Then Exit Sub

        Dim rnd As New Random
        Dim bt As New Button
        bt.Text = "OUVRIER"

        bt.BackColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255)) 'Color.DarkSlateGray
        bt.FlatStyle = FlatStyle.Flat
        bt.ForeColor = Color.White
        bt.Name = "bt" & CStr(rnd.Next) & p.Controls.Count
        bt.Font = New Font("Arial", 9, FontStyle.Bold)
        bt.Width = 125
        bt.Height = 90
        bt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        bt.TextAlign = ContentAlignment.MiddleLeft
        AddHandler bt.Click, AddressOf AjouterCharge

        If admin Then p.Controls.Add(bt)
    End Sub
    Public Sub AjouterCharge(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim ac As New AddCharges
        If ac.ShowDialog = DialogResult.OK Then

            Dim table As New DataTable

            ' Create four typed columns in the DataTable.

            If ac.txtname.text = "" Then ac.txtname.text = "ouvrier"
            ac.txtname.text &= " (" & CDate(ac.DateTimePicker1.Text).Day & "/" & CDate(ac.DateTimePicker1.Text).Month
            ac.txtname.text &= " - " & CDate(ac.DateTimePicker2.Text).Day & "/" & CDate(ac.DateTimePicker2.Text).Month & ")"

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim arid As Integer = 0
                Dim price As Double = CDbl(ac.Val)
                Dim params As New Dictionary(Of String, Object)
                params.Add("name", ac.txtname.text)
                params.Add("price", price)
                params.Add("isRepeated", False)
                params.Add("duree", 1)
                params.Add("writer", Form1.adminName)
                params.Add("date", Now.Date)
                arid = c.InsertRecord("Charge", params, True)

                Dim firstday As Date = DateSerial(Now.Year, Now.Month, 0)
                Dim lastday As Date = DateSerial(Now.Year, Now.Month + 1, 1)

                params.Clear()
                Form1.dgvCharge.Rows.Clear()

                params.Add("date > ", firstday)
                params.Add("date < ", lastday)

                Dim dt = c.SelectDataTableSymbols("Charge", {"*"}, params)

                Dim total As Double = 0
                If dt.Rows.Count > 0 Then

                    For i As Integer = 0 To dt.Rows.Count - 1
                        Form1.dgvCharge.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("date"),
                                      dt.Rows(i).Item("name"), dt.Rows(i).Item("price"),
                                      dt.Rows(i).Item("duree"), dt.Rows(i).Item("isRepeated"))
                        total += CDbl(dt.Rows(i).Item("price"))
                    Next
                End If

                Form1.txtchtotal.Text = total
                Form1.txtchNum.Text = Form1.dgvCharge.Rows.Count
            End Using

        End If

    End Sub


#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region



End Class
