Public Class company

    Private Sub Button35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button35.Click
        btcancel_Click(Nothing, Nothing)
        GB.Visible = True
    End Sub

    Private Sub btcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcancel.Click
        txtname.Text = ""
        txtname.Tag = ""
        txtcin.Text = ""
        txtad.Text = ""
        txttel.Text = ""
        btcon.Tag = "0"
        GB.Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        txtname.Text = DataGridView1.SelectedRows(0).Cells(1).Value
        txtname.Tag = DataGridView1.SelectedRows(0).Cells(0).Value
        txtcin.Text = DataGridView1.SelectedRows(0).Cells(2).Value
        txtad.Text = DataGridView1.SelectedRows(0).Cells(3).Value
        txttel.Text = DataGridView1.SelectedRows(0).Cells(4).Value
        btcon.Tag = "1"
        GB.Visible = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        If MsgBox("عند قيامكم على الضغط على 'موافق' سيتم حذف الزبون  المؤشر عليها من القائمة .. إضغط  'لا'  لالغاء الحذف ", MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "حذف الزبون") = MsgBoxResult.No Then
            Exit Sub
        End If
        If DataGridView1.SelectedRows(0).Cells(5).Value > 0 Then
            MsgBox("عذرا لا يمكن اتمام طلبكم.. هذا الزبون ما زال يتوفر على دين. المرجوا قضاء دينه اولا", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
            Exit Sub
        End If
        Try
            Dim ta As New ALMohassinDBDataSetTableAdapters.companyTableAdapter
            ta.DeleteQuery(DataGridView1.SelectedRows(0).Cells(0).Value)
            ta.Fill(ALMohassinDBDataSet.company)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub company_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ALMohassinDBDataSet.company' table. You can move, or remove it, as needed.
        Me.CompanyTableAdapter.Fill(Me.ALMohassinDBDataSet.company)

    End Sub

    Private Sub btcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcon.Click

        'validation
        ''empty field
        If txtname.Text.Trim = "" Then
            MsgBox("عذرا لا يمكن اتمام طلبكم.. المرجوا تعبئة الاسم", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
            txtname.Focus()
            Exit Sub
        End If

        ' addddd
        If btcon.Tag = "0" Then


            ''check the name

            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                If txtname.Text = DataGridView1.Rows(i).Cells(1).Value Then
                    MsgBox("عذرا لا يمكن اتمام طلبكم.. يجب عدم تكرار نفس الاسم", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                    txtname.Focus()
                    DataGridView1.Rows(i).Selected = True
                    DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.SelectedRows(0).Index
                    Exit Sub
                End If
            Next



            Try
                Dim ta As New ALMohassinDBDataSetTableAdapters.companyTableAdapter
                ta.InsertQuery(txtname.Text, txtcin.Text, txtad.Text, txttel.Text, "0")
                ta.Fill(ALMohassinDBDataSet.company)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try



            'updateeee
        Else


            Try
                Dim ta As New ALMohassinDBDataSetTableAdapters.companyTableAdapter
                ta.UpdateQuery(txtname.Text, txtcin.Text, txtad.Text, txttel.Text, txtname.Tag)
                ta.Fill(ALMohassinDBDataSet.company)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
        btcancel_Click(Nothing, Nothing)
        GB.Visible = False
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

End Class