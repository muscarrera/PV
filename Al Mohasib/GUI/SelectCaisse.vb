Public Class SelectCaisse

    Private Sub SelectCaisse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, String)
            params.Add("dtstkid", "DESC")
            Dim dt = c.SelectDataTable("DetailsStock", {"*"}, , params)

            If dt.Rows.Count Then
                DataGridView1.DataSource = dt

                DataGridView1.Columns(1).Visible = False
                DataGridView1.Columns(4).Visible = False
                DataGridView1.Columns(5).Visible = False
                DataGridView1.Columns(7).Visible = False
                DataGridView1.Columns(8).Visible = False
                DataGridView1.Columns(9).Visible = False
                DataGridView1.Columns(6).Visible = False


                DataGridView1.Columns(2).DisplayIndex = 10
                DataGridView1.Columns(2).HeaderText = "Valider"
                DataGridView1.Columns(3).HeaderText = "Designation"
            End If
        End Using


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Form1.admin = False Then
            If DataGridView1.SelectedRows(0).Cells(1).Value.ToString.ToUpper.StartsWith(Form1.adminName.ToUpper) = False Then
                Exit Sub
            End If
        End If


        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class