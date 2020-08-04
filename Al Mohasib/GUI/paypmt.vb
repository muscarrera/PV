Public Class paypmt

    Public pId As Integer = 0
    Dim _id As Integer

    Public Property id As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value

            If value = 0 Then Exit Property
            getDetails(id)

        End Set
    End Property
    Private Sub getDetails(ByVal id As Integer)

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim tableName As String = "Payment"


            Dim params As New Dictionary(Of String, Object)
            params.Add("fctid", 0)
            params.Add("clid", id)

            Dim dt = c.SelectDataTable(tableName, {"*"}, params)
            Try
                If dt.Rows.Count > 0 Then
                    pId = dt.Rows(0).Item(0)
                    txtmontant.text = dt.Rows(0).Item("montant")
                    cbway.Text = dt.Rows(0).Item("way")
                    txtnum.Text = dt.Rows(0).Item("num")
                End If
            Catch ex As Exception

            End Try
        End Using
    End Sub


    Private Sub btcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcancel.Click
        txtmontant.text = ""
        cbway.Text = "Cache"
        btcon.Tag = "0"
    End Sub

    Private Sub btcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcon.Click

        If Not IsNumeric(txtmontant.text) Then
            txtmontant.Focus()
            Exit Sub
        End If

        If cbway.Text = "" Or IsNothing(cbway.Text) Then
            cbway.Text = "Cache"
        End If

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim tableName As String = "Payment"

            Dim where As New Dictionary(Of String, Object)
            Dim params As New Dictionary(Of String, Object)
            params.Add("fctid", 0)
            params.Add("clid", id)

            params.Add("name", "Facture")
            params.Add("montant", txtmontant.text)
            params.Add("way", cbway.Text)
            params.Add("date", Now.Date)
            params.Add("num", txtnum.Text)
            params.Add("writer", Form1.adminName)

            If pId = 0 Then
                c.InsertRecord("Payment", params)
            Else
                where.Add("Pid", pId)
                c.UpdateRecord("Payment", params, where)
            End If

            params.Clear()
            where.Clear()

            If cbway.Text = "Non Reglé" Then
                params.Add("timbre", False)
            Else
                params.Add("timbre", True)
            End If

            where.Add("flid", id)
            c.UpdateRecord("Facture_Liste", params, where)

            DialogResult = Windows.Forms.DialogResult.OK
        End Using
    End Sub
    Private Sub cbway_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbway.SelectedIndexChanged
        If cbway.SelectedItem = "Cache" Then
            txtnum.Text = "0"
            txtnum.Visible = False
            lbnum.Visible = False
        ElseIf cbway.SelectedItem = "Non Reglé" Then
            txtnum.Text = "0"
            txtnum.Visible = False
            lbnum.Visible = False
        Else
            txtnum.Visible = True
            lbnum.Visible = True
        End If
    End Sub
    Dim m As Integer = 0
    Private Sub PrintDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage
        Try
            Using a As DrawClass = New DrawClass
                Dim dte As Date = Now.Date
                a.DrawpayemtFct(e, pId, Form1.lbfn.Text, Form1.RPl.ClId, id, True, Now.Date,
                                txtmontant.text, cbway.Text, txtnum.Text, m)

            End Using

        Catch ex As Exception
            M = 0
        End Try
    End Sub

    Private Sub btPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPrint.Click
        Try
            PrintDoc.PrinterSettings.PrinterName = Form1.txtreceipt.Text
            PrintDoc.Print()

        Catch ex As Exception

            If Form1.PrintDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintDoc.PrinterSettings.PrinterName = Form1.PrintDlg.PrinterSettings.PrinterName
                PrintDoc.Print()
            End If
        End Try
    End Sub

End Class