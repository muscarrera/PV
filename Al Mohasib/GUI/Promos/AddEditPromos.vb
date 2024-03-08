Imports System.IO




Public Class AddEditPromos
    Public localname As String = "Default.dat"
    Public TableName As String = "PROMO"
    Dim _g As Promos


    Public Property promos As Promos
        Get
            Return _g
        End Get
        Set(ByVal value As Promos)
            _g = value

            TxtBox1.text = value.name
            cbB.SelectedItem = value.type
            txtEcheance.text = value.ech
            TxtBox2.text = value.desgn

            For Each p As PromosArticle In value.startList
                Dg1.Rows.Add(p.type, p.arid, p.name, p.qte, p.point)
            Next

        End Set
    End Property

    Private Sub btRelveClientArch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRelveClientArch.Click
         
        Dim dir1 As New DirectoryInfo(Form1.Data_Comp_Path & "\" & TableName)
        If dir1.Exists = False Then dir1.Create()

        WriteToXmlFile(Of Promos)(Form1.Data_Comp_Path & "\" & TableName & "\" & localname, promos)
         
    End Sub

    Private Sub AddEditPromos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If TableName <> "PROMO" Then
            cbB.Items.Clear()
            cbB.Items.Add("TA - Total Achat")
            cbB.Items.Add("TB - Total Bon")

            lbQ.Text = "Qte/Remise"

            cbCond.Items.Clear()
            cbCond.Items.Add("Article")
            cbCond.Items.Add("Remise")
        End If
    End Sub

    Private Sub cbCond_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCond.SelectedIndexChanged
        txt.Enabled = True
        txt.text = ""

        Using a As SubClass = New SubClass(1)
            If cbCond.Text = "Article" Then
                a.AutoCompleteArticlesWithRef(txt, "Article")
            ElseIf cbCond.Text = "Categorie" Then
                a.AutoCompleteArticles(txt, "Category")
            ElseIf cbCond.Text = "Remise" Then
                txt.Enabled = False
                txt.text = "Remise (Dhs)"
            Else
                txt.Enabled = False
            End If
        End Using


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cbCond.Text = "" Then Exit Sub
        If Not IsNumeric(txtQ.text) Then Exit Sub
        If Not IsNumeric(txtP.text) Then Exit Sub
        Dim id As Integer = 0

        If cbCond.Text = "Article" Or cbCond.Text = "Categorie" Then
            If txt.text.Contains("|") Then
                Dim str As String = txt.text.Trim
                str = str.Split(CChar("|"))(1)
                id = CInt(str)
            Else
                Exit Sub
            End If
        End If


        Dim p As New PromosArticle
        p.type = cbCond.Text
        p.arid = id

        Try
            p.name = txt.text.Split("|")(2)
        Catch ex As Exception
            p.name = txt.text.Split("|")(0)
        End Try

        p.qte = txtQ.text
        p.point = txtP.text

        _g.startList.Add(p)

        Dg1.Rows.Add(p.type, p.arid, p.name, p.qte, p.point)
        txt.text = ""
        txtQ.text = ""
        txtP.text = ""

    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        If MsgBox("Vous ete sure de supprimer cet item? ", MsgBoxStyle.YesNo, "Supression") = MsgBoxResult.Yes Then
            Try
                If Dg1.SelectedRows.Count > 0 Then
                    For Each a As PromosArticle In _g.startList
                        If a.type = Dg1.SelectedRows(0).Cells(0).Value And
                            a.arid = Dg1.SelectedRows(0).Cells(1).Value And
                               a.qte = Dg1.SelectedRows(0).Cells(3).Value And
                            a.point = Dg1.SelectedRows(0).Cells(4).Value Then
                            _g.startList.Remove(a)
                            Dg1.Rows.Remove(Dg1.SelectedRows(0))
                        End If
                    Next
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        txtEcheance.text = Now.Date.ToShortDateString
    End Sub

    Private Sub cbB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbB.SelectedIndexChanged

        ' TA - Total Achat
        'TB - Total Bon
        'LA - List d'Articles 
        
         

        If cbB.Text = "Article_Gratuit" Or cbB.Text = "Total_Gratuit" Then
            lbpintName.Text = "Qte Gratuits"
        ElseIf cbB.Text = "Categories_Prix" Then
            lbpintName.Text = "Remise"
        ElseIf cbB.Text = "Article_Prix" Then
            lbpintName.Text = "Nouveau prix"
        Else 
            lbpintName.Text = "Points"
        End If


    End Sub
End Class