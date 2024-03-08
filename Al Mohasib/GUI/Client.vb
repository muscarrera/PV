Imports System.IO

Public Class Client
    Private Function IsPhoneNumberValid(ByVal phoneNumber As String) As Boolean
        ' Define a regular expression pattern for a basic phone number format
        Dim pattern As String = "^\d{10}$" ' Assumes a 10-digit phone number format

        ' Create a regular expression object
        Dim regex As New System.Text.RegularExpressions.Regex(pattern)

        ' Check if the input string matches the pattern
        Return regex.IsMatch(phoneNumber)
    End Function

    Private Sub Client_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
         Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            DataGridView1.DataSource = a.SelectDataTable("Client", {"*"})
        End Using

        If Form1.cbCafeTable.Checked Then
            lbTp.Text = "Zone"
            GroupBox2.Text = "LISTE DES TABLES"
        End If



        If Form1.admin = False Then
            DataGridView1.Columns(6).Visible = False
            btAllow.Visible = False
            btAllow2.Visible = False
            btAllow3.Visible = False

            txttp.Visible = False
            lbTp.Visible = False
        Else
            txttp.Visible = Form1.chbsell.Checked
            lbTp.Visible = Form1.chbsell.Checked
        End If

    End Sub

    Private Sub Button35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button35.Click
        btcancel_Click(Nothing, Nothing)
        If Form1.admin = False Then
            txtcrd.text = 1
            txtcrd.Visible = False
        End If

        GB1.Visible = True
    End Sub

    Private Sub btcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcancel.Click
        txtname.text = ""
        txtname.Tag = ""
        txtcin.text = ""
        txtad.text = ""
        txtVille.text = ""
        txtIce.text = ""
        txttel.text = ""
        btcon.Tag = "0"
        GB1.Visible = False
        lbPouch.Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            Exit Sub
        End If

        If Form1.admin = False Then txtcrd.Visible = False



        Dim adresse = DataGridView1.SelectedRows(0).Cells(3).Value.ToString.Split("*")

        txtname.text = DataGridView1.SelectedRows(0).Cells(1).Value
        txtname.Tag = DataGridView1.SelectedRows(0).Cells(0).Value
        txtcin.text = DataGridView1.SelectedRows(0).Cells(2).Value.ToString
        txttel.text = DataGridView1.SelectedRows(0).Cells(4).Value.ToString

        Try
            txtad.text = adresse(0)
            txtVille.text = adresse(1)
            txtIce.text = adresse(2)
        Catch ex As Exception
        End Try


        Dim tp As String = DataGridView1.SelectedRows(0).Cells(6).Value.ToString
        If tp.Contains("|") Then
            txtcrd.text = tp.Split("|")(0)
            txttp.text = tp.Split("|")(1)
        Else
            txtcrd.text = tp
            txttp.text = 0
        End If

        btcon.Tag = "1"
        lbPouch.Visible = True
        GB1.Visible = True

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If DataGridView1.SelectedRows.Count = 0 Then Exit Sub

        Dim id As Integer = DataGridView1.SelectedRows(0).Cells(0).Value

        'If hasMoreFacture(id) = False Then
        '    MsgBox("vous ne disposez pas des autorisations nécessaires pour supprimer ce client")
        '    Exit Sub
        'End If

        If MsgBox("عند قيامكم على الضغط على 'موافق' سيتم حذف الزبون  المؤشر عليها من القائمة .. إضغط  'لا'  لالغاء الحذف ", MsgBoxStyle.YesNo Or MessageBoxIcon.Exclamation, "حذف الزبون") = MsgBoxResult.No Then
            Exit Sub
        End If
        If DataGridView1.SelectedRows(0).Cells(5).Value > 0 Then
            'MsgBox("عذرا لا يمكن اتمام طلبكم.. هذا الزبون ما زال يتوفر على دين. المرجوا قضاء دينه اولا", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
            'Exit Sub
        End If


        Try

            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

                Dim params As New Dictionary(Of String, Object)
                '''''''''''''''''''
                params.Add("Clid", id)
                If a.DeleteRecords("Client", params) Then
                    DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))
                End If

            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function hasMoreFacture(ByVal id As Integer) As Boolean



        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            Dim params As New Dictionary(Of String, Object)
            params.Add("clid", id)
            ' added some items

            Dim dt As DataTable = a.SelectDataTable("Facture", {"*"}, params)

            If dt.Rows.Count > 0 Then Return False


            Return True
        End Using

        Return False
    End Function
    Private Sub btcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcon.Click

        'validation
        ''empty field
        If txtname.text.Trim = "" Then
            MsgBox("عذرا لا يمكن اتمام طلبكم.. المرجوا تعبئة الاسم", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
            txtname.Focus()
            Exit Sub
        End If

        If txtcrd.text.Trim = "" Or Not IsNumeric(txtcrd.text) Then txtcrd.text = 30
        If txttp.text.Trim = "" Or Not IsNumeric(txttp.text) Then txttp.text = 0

        Dim tp As String = txtcrd.text & "|" & txttp.text

        If Form1.cbCafeTable.Checked Then tp = txttp.text


        If txtad.text = "" Then txtad.text = "-"
        If txtIce.text = "" Then txtIce.text = "-"
        If txtVille.text = "" Then txtVille.text = "-"

        Dim adresse As String = txtad.text & "*" & txtVille.text & "*" & txtIce.text



        Dim isValidPhoneNumber As Boolean = IsPhoneNumberValid(txttel.text)

        If isValidPhoneNumber = False Then
            MessageBox.Show("Numero de tel. est incorrect.")
            txttel.TXT.Focus()
            Exit Sub
        End If


        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            params.Add("name", txtname.text)
            params.Add("CIN", txtcin.text)
            params.Add("Adress", adresse)
            params.Add("tel", txttel.text)
            params.Add("credit", "0")
            params.Add("type", tp) 'CInt(txtcrd.text))

            If btcon.Tag = "1" Then
                Dim where As New Dictionary(Of String, Object)
                where.Add("Clid", txtname.Tag)
                c.UpdateRecord("Client", params, where)
                where = Nothing
            Else
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    If txtname.text = DataGridView1.Rows(i).Cells(1).Value Then
                        MsgBox("عذرا لا يمكن اتمام طلبكم.. يجب عدم تكرار نفس الاسم", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                        txtname.Focus()
                        DataGridView1.Rows(i).Selected = True
                        DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.SelectedRows(0).Index
                        Exit Sub
                    End If
                Next
                c.InsertRecord("Client", params, True)
            End If
        End Using

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            DataGridView1.DataSource = c.SelectDataTable("Client", {"*"})
        End Using

        btcancel_Click(Nothing, Nothing)
        GB1.Visible = False

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(1).Value.ToString.Contains(txtsearch.Text) Then
                DataGridView1.Rows(i).Selected = True
                DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.Rows(i).Index
                Exit For
            End If
            If DataGridView1.Rows(i).Cells(0).Value.ToString.Contains(txtsearch.Text) Then
                DataGridView1.Rows(i).Selected = True
                DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.Rows(i).Index
                Exit For
            End If
        Next

    End Sub

    Private Sub txtsearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsearch.KeyUp
        Button5_Click(Nothing, Nothing)
    End Sub

    Private Sub btAllow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAllow.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        If MsgBox("Voulez-vous autoriser ce client ? ", MsgBoxStyle.YesNo Or MessageBoxIcon.Exclamation, "ترخيص الزبون") = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim strpath As String = Form1.BtImgPah.Tag & "\AllowClient"
        If Not Directory.Exists(strpath) Then
            Directory.CreateDirectory(strpath)
            Exit Sub
        End If

        Dim cid As String = DataGridView1.SelectedRows(0).Cells(0).Value
        Dim savePath As String = Path.Combine(strpath, cid & "-Allowed.dat")
        If System.IO.File.Exists(savePath) Then
        Else
            System.IO.File.Create(savePath)
        End If
    End Sub

    Private Sub txttp_TxtChanged() Handles txttp.TxtChanged
        Try
            If IsNumeric(txttp.text) Then
                txttp.text = CInt(txttp.text)
            Else
                txttp.text = ""
            End If
            If txttp.text > 4 Or txttp.text < 0 Then txttp.text = ""
        Catch ex As Exception
            txttp.text = ""
        End Try

    End Sub

    Private Sub btAllow2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAllow2.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        If MsgBox("Voulez-vous donner l'autorisation illimité à ce client?", MsgBoxStyle.YesNo Or MessageBoxIcon.Exclamation, "ترخيص الزبون") = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim strpath As String = Form1.BtImgPah.Tag & "\AllowClient"
        If Not Directory.Exists(strpath) Then
            Directory.CreateDirectory(strpath)
            Exit Sub
        End If

        Dim cid As String = DataGridView1.SelectedRows(0).Cells(0).Value
        Dim savePath As String = Path.Combine(strpath, cid & "-Auth.dat")
        If System.IO.File.Exists(savePath) Then
        Else
            System.IO.File.Create(savePath)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAllow3.Click
        Dim strpath As String = Form1.BtImgPah.Tag & "\AllowClient"
        If Not Directory.Exists(strpath) Then
            Directory.CreateDirectory(strpath)
        End If
        Dim clid As String = DataGridView1.SelectedRows(0).Cells(0).Value

        Dim savePath As String = Path.Combine(strpath, clid & "-Allowed.dat")
        Dim savePath2 As String = Path.Combine(strpath, clid & "-Auth.dat")

        If System.IO.File.Exists(savePath) Then
            File.Delete(savePath)
        End If
        If System.IO.File.Exists(savePath2) Then
            File.Delete(savePath2)
        End If

        MsgBox("l'autorisation de ce client a bien supprimer")
    End Sub

    Private Sub lbPouch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbPouch.Click
        If Form1.admin = False Then Exit Sub
        If txtname.Tag = 0 Then Exit Sub

        Dim pp As New PochetClient
        pp.clid = txtname.Tag
        pp.lbClient.text = txtname.text
        pp.isSell = True

        If pp.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If

    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim ss As New SelectClient
        ss.isUpdatingMode = True

        If ss.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim dt As DataTable
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)


                Dim rf As String = ss.ref
                If rf.ToUpper.StartsWith("SUP") Then
                    rf = "-"
                    Form1.PromoListClient.Remove(txtname.Tag)
                    Dim str As String = String.Join("|", Form1.PromoListClient)

                    My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "PromoListClient", str)

                Else
                    If Form1.PromoListClient.Contains(txtname.Tag) = False Then
                        Form1.PromoListClient.Add(txtname.Tag)
                    End If
                    Dim str As String = String.Join("|", Form1.PromoListClient)

                    My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "PromoListClient", str)
                End If


                params.Add("code", rf)

                Try
                    dt = c.SelectDataTable("Client", {"*"}, params)
                    If dt.Rows.Count > 0 And rf.ToUpper.StartsWith("SUP") Then
                        If dt.Rows(0).Item(0) <> txtname.Tag Then
                            MsgBox("ce code est deja porter par un autre client")
                        End If

                    Else
                        Dim where As New Dictionary(Of String, Object)

                        where.Add("Clid", txtname.Tag)
                        If c.UpdateRecord("Client", params, where) Then
                            MsgBox("")
                        End If
                        where = Nothing
                    End If
                Catch ex As Exception
                    dt = Nothing
                End Try
            End Using
        End If




    End Sub
End Class