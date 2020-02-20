Public Class CompanyPAYEMENT

    Private Sub CompanyPAYEMENT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ALMohassinDBDataSet.company' table. You can move, or remove it, as needed.
        Me.CompanyTableAdapter.Fill(Me.ALMohassinDBDataSet.company)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        btcancel_Click(Nothing, Nothing)

        If DataGridView1.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        txtname.Text = DataGridView1.SelectedRows(0).Cells(1).Value
        txtname.Tag = DataGridView1.SelectedRows(0).Cells(0).Value
        lbcrd.Text = DataGridView1.SelectedRows(0).Cells(5).Value
        lbcrd.Tag = DataGridView1.SelectedRows(0).Cells(5).Value
        Try
            DGVP.Rows.Clear()

            Dim ta As New ALMohassinDBDataSetTableAdapters.CompanyPaymentTableAdapter
            Dim dt = ta.GetData(txtname.Tag)
            For i As Integer = 0 To dt.Rows.Count - 1
                
                    DGVP.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("montant"), dt.Rows(i).Item("way"), dt.Rows(i).Item("Num"), dt.Rows(i).Item("paydate"), dt.Rows(i).Item("writer"), dt.Rows(i).Item("date"))

            Next


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub btcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcancel.Click
       
        txtmontant.Text = ""
        txtmontant.Tag = ""
        btcon.Tag = "0"
        cbway.SelectedItem = "كاش"
        DateTimePicker1.Visible = False
        DateTimePicker1.Text = Now.Date
        PB1.BackgroundImage = pbadd.BackgroundImage

    End Sub

    Private Sub Button35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button35.Click
        btcancel_Click(Nothing, Nothing)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DGVP.SelectedRows.Count = 0 Then
            Exit Sub
        End If

        If DGVP.SelectedRows(0).Cells(2).Value.ToString.Contains("دين") Then
            MsgBox("لا يمكن تغير هذه القيمة. لاعتبارها تذكير فقط بالباقي من الفاتورة", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, " تذكير")
            Exit Sub
        End If




        txtmontant.Text = DGVP.SelectedRows(0).Cells(1).Value.ToString
        txtmontant.Tag = DGVP.SelectedRows(0).Cells(1).Value.ToString
        txtnum.Text = DGVP.SelectedRows(0).Cells(3).Value.ToString
        cbway.Text = DGVP.SelectedRows(0).Cells(2).Value.ToString
        Try
            DateTimePicker1.Text = DGVP.SelectedRows(0).Cells(4).Value.ToString
        Catch ex As Exception

        End Try
        If cbway.Text = "كاش" Then
            txtnum.Visible = False
            DateTimePicker1.Visible = False
            DateTimePicker1.Text = Now.Date
        End If
        btcon.Tag = DGVP.SelectedRows(0).Cells(0).Value.ToString
        PB1.BackgroundImage = pbedit.BackgroundImage
    End Sub

    Private Sub btcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcon.Click
        'validation
        ''empty field
        If txtname.Text.Trim = "" Then
            Exit Sub
        End If
        If txtmontant.Text.Trim = "" Then
            MsgBox("عذرا لا يمكن اتمام طلبكم.. المرجوا تعبئة المبلغ", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
            txtmontant.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtmontant.Text) Then
            MsgBox("عذرا لا يمكن اتمام طلبكم.. المبلغ يجب ان يكون بالارقام", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
            txtmontant.Focus()
            Exit Sub
        End If
        ' addddd
        If btcon.Tag = "0" Then


            Dim MyCon As OleDb.OleDbConnection = Nothing
            Dim MyTRans As OleDb.OleDbTransaction = Nothing
            'start a transaction object

            Try
                MyCon = New OleDb.OleDbConnection(My.Settings.ALMohassinDBConnectionString)
                MyCon.Open()

                MyTRans = MyCon.BeginTransaction




                Dim SQL As String = "insert into CompanyPayment (name,comid,montant,way,[date],Num,bonid,writer) values (:1,:2,:3,:4,:5,:6,:7,:8)"
                Dim CMD1 As New OleDb.OleDbCommand
                CMD1.Connection = MyCon
                CMD1.Transaction = MyTRans
                CMD1.CommandText = SQL
                CMD1.Parameters.AddWithValue(":1", txtname.Text)
                CMD1.Parameters.AddWithValue(":2", txtname.Tag)
                CMD1.Parameters.AddWithValue(":3", txtmontant.Text)
                CMD1.Parameters.AddWithValue(":4", cbway.SelectedItem)
                CMD1.Parameters.AddWithValue(":5", Now.Date)
                CMD1.Parameters.AddWithValue(":6", txtnum.Text)
                CMD1.Parameters.AddWithValue(":7", "0")
                CMD1.Parameters.AddWithValue(":8", Form1.admin)

                CMD1.ExecuteNonQuery()
                CMD1.Dispose()

                ' credit
                lbcrd.Text = lbcrd.Text - txtmontant.Text



                'select receipt id 
                SQL = "update company set credit=:1 where compid=:2"
                Dim CMD2 As New OleDb.OleDbCommand
                CMD2.Connection = MyCon
                CMD2.Transaction = MyTRans
                CMD2.CommandText = SQL
                CMD2.Parameters.AddWithValue(":1", lbcrd.Text)
                CMD2.Parameters.AddWithValue(":2", txtname.Tag)
                CMD2.ExecuteNonQuery()
                CMD2.Dispose()

                'all will save the changes
                MyTRans.Commit()

                ''close all 
                MyTRans.Dispose()
                MyCon.Close()
                MyCon.Dispose()
                ''''
                lbcrd.Tag = lbcrd.Text
                txtmontant.Text = ""
                txtmontant.Tag = ""
                cbway.SelectedItem = "كاش"
                ''fill       DGVP.Rows.Clear()
                DGVP.Rows.Clear()
                Try
                    Dim ta As New ALMohassinDBDataSetTableAdapters.PaymentTableAdapter
                    Dim dt = ta.GetData(txtname.Tag)
                    CompanyTableAdapter.Fill(ALMohassinDBDataSet.company)
                    For i As Integer = 0 To dt.Rows.Count - 1
                      
                            DGVP.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("montant"), dt.Rows(i).Item("way"), dt.Rows(i).Item("Num"), dt.Rows(i).Item("paydate"), dt.Rows(i).Item("writer"), dt.Rows(i).Item("date"))

                    Next


                Catch x As Exception
                    MsgBox(x.Message)
                End Try

                btcon.Tag = "0"
            Catch ex As Exception
                If MyTRans IsNot Nothing Then
                    MyTRans.Rollback()
                End If
                If MyCon IsNot Nothing Then
                    If MyCon.State = ConnectionState.Open Then
                        MyCon.Close()
                    End If

                End If
                lbcrd.Text = lbcrd.Tag
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            End Try


            'updateeee
        Else

            Dim MyCon As OleDb.OleDbConnection = Nothing
            Dim MyTRans As OleDb.OleDbTransaction = Nothing
            'start a transaction object

            Try
                MyCon = New OleDb.OleDbConnection(My.Settings.ALMohassinDBConnectionString)
                MyCon.Open()

                MyTRans = MyCon.BeginTransaction


                Dim SQL As String = "update CompanyPayment set montant=:1 , way=:2 ,  Num=:3, paydate=:4, writer=:5 where pid=:6  "
                Dim CMD1 As New OleDb.OleDbCommand
                CMD1.Connection = MyCon
                CMD1.Transaction = MyTRans
                CMD1.CommandText = SQL
                CMD1.Parameters.AddWithValue(":1", Double.Parse(txtmontant.Text))
                CMD1.Parameters.AddWithValue(":2", cbway.SelectedItem)
                CMD1.Parameters.AddWithValue(":3", txtnum.Text)
                CMD1.Parameters.AddWithValue(":4", DateTimePicker1.Text)
                CMD1.Parameters.AddWithValue(":5", Form1.admin)
                CMD1.Parameters.AddWithValue(":6", Integer.Parse(btcon.Tag))
                CMD1.ExecuteNonQuery()
                CMD1.Dispose()


                ' credit
                lbcrd.Text = lbcrd.Text - (txtmontant.Text - txtmontant.Tag)


                'select receipt id 
                SQL = "update Company set credit=:1 where compid=:2"
                Dim CMD2 As New OleDb.OleDbCommand
                CMD2.Connection = MyCon
                CMD2.Transaction = MyTRans
                CMD2.CommandText = SQL
                CMD2.Parameters.AddWithValue(":1", lbcrd.Text)
                CMD2.Parameters.AddWithValue(":2", txtname.Tag)
                CMD2.ExecuteNonQuery()
                CMD2.Dispose()

                'all will save the changes
                MyTRans.Commit()

                ''close all 
                MyTRans.Dispose()
                MyCon.Close()
                MyCon.Dispose()
                ''''
                lbcrd.Tag = lbcrd.Text
                txtmontant.Text = ""
                txtmontant.Tag = ""
                cbway.SelectedItem = "كاش"
                ''fill       DGVP.Rows.Clear()
                DGVP.Rows.Clear()


                Try
                    Dim ta As New ALMohassinDBDataSetTableAdapters.PaymentTableAdapter
                    Dim dt = ta.GetData(txtname.Tag)
                    CompanyTableAdapter.Fill(ALMohassinDBDataSet.company)
                    For i As Integer = 0 To dt.Rows.Count - 1
                     
                            DGVP.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("montant"), dt.Rows(i).Item("way"), dt.Rows(i).Item("Num"), dt.Rows(i).Item("paydate"), dt.Rows(i).Item("writer"), dt.Rows(i).Item("date"))


                    Next


                Catch x As Exception
                    MsgBox(x.Message)
                End Try

                btcon.Tag = "0"
            Catch ex As Exception
                If MyTRans IsNot Nothing Then
                    MyTRans.Rollback()
                End If
                If MyCon IsNot Nothing Then
                    If MyCon.State = ConnectionState.Open Then
                        MyCon.Close()
                    End If

                End If
                lbcrd.Text = lbcrd.Tag
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            End Try

            'updateeee
        End If

    End Sub

    Private Sub cbway_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbway.SelectedIndexChanged
        If cbway.SelectedItem = "كاش" Then
            txtnum.Text = "0"
            txtnum.Visible = False
            lbnum.Visible = False
            DateTimePicker1.Text = Now.Date
            DateTimePicker1.Visible = False
        Else
            txtnum.Visible = True
            lbnum.Visible = True
        End If
    End Sub

    Private Sub txtsearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsearch.KeyPress
        If Button1.Enabled = True Then
            If e.KeyChar = Chr(13) Then
                Button3_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub txtsearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsearch.KeyUp
        Button5_Click(Nothing, Nothing)
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

    Private Sub DGVP_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGVP.MouseDoubleClick
        Try
            MsgBox(DGVP.SelectedRows(0).Cells(4).Value & " // (" & DGVP.SelectedRows(0).Cells(5).Value & ")")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub
End Class