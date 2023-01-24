Imports System.IO

Public Class PromosList
    Public localname As String = ""
    Public TableName As String = "PROMO"

    Dim g As New Promos

    Private Sub btRelveClientArch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt.Click

        g.name = txtName.text
        g.desgn = txtName.text
        g.type = cbB.SelectedItem
        g.isAuto = CbIsAuto.Checked

        If Not IsDate(txtEcheance.text) Then
            txtEcheance.text = Now.Date.ToString("dd/MM/yyyy")
        End If

        g.ech = CDate(txtEcheance.text)
        g.img = ""

        If localname = "" Then
            g.dte = Now
            localname = txtName.text & ".dat"
            g.isActive = True
            g.startList = New List(Of PromosArticle)
            g.resultList = New List(Of PromosArticle)

            DataGridView1.Rows.Add(localname)
        End If

        Dim dir1 As New DirectoryInfo(Form1.ImgPah & "\" & TableName)
        If dir1.Exists = False Then dir1.Create()

        WriteToXmlFile(Of Promos)(Form1.ImgPah & "\" & TableName & "\" & localname, g)

        Dim ad As New AddEditPromos
        ad.TableName = TableName
        ad.localname = localname
        ad.promos = g



        If ad.ShowDialog = Windows.Forms.DialogResult.OK Then


        End If
    End Sub

    Private Sub PromosList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dir1 As New DirectoryInfo(Form1.ImgPah & "\" & TableName)
        If dir1.Exists = False Then dir1.Create()

        lb.Text = TableName


        Dim aryFi As IO.FileInfo() = dir1.GetFiles("*.dat")
        Dim fi As IO.FileInfo

        For Each fi In aryFi
            DataGridView1.Rows.Add(fi.Name)
        Next

        If TableName <> "PROMO" Then
            cbB.Items.Clear()
            cbB.Items.Add("TA - Total Achat")
            cbB.Items.Add("TB - Total Bon")
        End If

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.SelectedRows.Count = 0 Then Exit Sub
        ClearFields()
        localname = DataGridView1.SelectedRows(0).Cells(0).Value.ToString
        LoadXml()
    End Sub

    Private Sub ClearFields()
        localname = ""
        txtName.text = ""
        txtDesc.text = ""
        bt.Enabled = False

    End Sub
    Public Sub LoadXml()
        Dim _g As New Promos
        Try
            _g = ReadFromXmlFile(Of Promos)(Form1.ImgPah & "\" & TableName & "\" & localname)
            txtName.text = _g.name
            txtDesc.text = _g.desgn
            txtEcheance.text = _g.ech
            cbB.SelectedItem = _g.type
          
            g = _g
            bt.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button45.Click
        ClearFields()
        bt.Enabled = True
        txtName.TXT.Focus()
    End Sub
     
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MsgBox("Vous ete sure de supprimer cet item? ", MsgBoxStyle.YesNo, "Supression") = MsgBoxResult.Yes Then
            Try
                Dim strpath As String = Form1.ImgPah & "\" & TableName
                localname = DataGridView1.SelectedRows(0).Cells(0).Value.ToString
                Dim fullPath As String = Path.Combine(strpath, localname)
                File.Delete(fullPath)

                DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        txtEcheance.text = Now.Date.ToShortDateString
    End Sub
End Class