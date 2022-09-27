Public Class AddDepot

    Private Sub AddDepot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
   
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            dgvctg.DataSource = a.SelectDataTableSymbols("Depot", {"*"})

        End Using


    End Sub

    Private Sub btcid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcid.Click

        If TextBox1.Text.Trim = "" Then
            MsgBox("عذرا لا يمكن اتمام طلبكم.. المرجوا تعبئة الاسم", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
            TextBox1.Focus()
            Exit Sub
        End If

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            params.Add("name", TextBox1.text)

            If btcid.Tag = "1" Then
                For i As Integer = 0 To dgvctg.Rows.Count - 1
                    If TextBox1.text = dgvctg.Rows(i).Cells(1).Value Then
                        MsgBox("عذرا لا يمكن اتمام طلبكم.. يجب عدم تكرار نفس الاسم", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                        TextBox1.Focus()
                        dgvctg.Rows(i).Selected = True
                        dgvctg.FirstDisplayedScrollingRowIndex = dgvctg.Rows(i).Index
                        Exit Sub
                    End If
                Next

                c.InsertRecord("Depot", params, True)
            Else
                Dim where As New Dictionary(Of String, Object)
                where.Add("dpid", TextBox1.Tag)
                c.UpdateRecord("Depot", params, where)
                where = Nothing
            End If
        End Using

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            dgvctg.DataSource = c.SelectDataTableSymbols("Depot", {"*"})
        End Using




        TextBox1.Text = ""
        TextBox1.Tag = 0
        Panel1.Visible = False


    End Sub

    Private Sub Button45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button45.Click
        Panel1.Visible = True
        TextBox1.Text = ""
        TextBox1.Tag = 0
        btcid.Tag = "1"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If dgvctg.SelectedRows.Count = 0 Then
            Exit Sub
        End If

        Panel1.Visible = True
        TextBox1.Text = dgvctg.SelectedRows(0).Cells(1).Value
        TextBox1.Tag = dgvctg.SelectedRows(0).Cells(0).Value
        Label1.Tag = dgvctg.SelectedRows(0).Cells(1).Value
        btcid.Tag = "2"




    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If dgvctg.SelectedRows.Count = 0 Then
            Exit Sub
        End If

        If MsgBox("عند قيامكم على الضغط على 'موافق' سيتم حذف  المخزن المؤشر عليه من القائمة .. إضغط 'لا' لالغاء الحذف ", MsgBoxStyle.YesNo Or MessageBoxIcon.Exclamation, "حذف التصنيف") = MsgBoxResult.No Then
            Exit Sub
        End If


        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            '''''''''''''''''''
            params.Add("cid", dgvctg.SelectedRows(0).Cells(0).Value)

            If a.DeleteRecords("Depot", params) Then
                dgvctg.Rows.Remove(dgvctg.SelectedRows(0))
            End If
        End Using

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        TextBox1.Text = ""
        TextBox1.Tag = 0
        Panel1.Visible = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class