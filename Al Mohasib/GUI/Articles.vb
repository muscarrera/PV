Imports System.IO

Public Class Articles

    Private Sub Articles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim ctgta As New ALMohassinDBDataSetTableAdapters.CategoryTableAdapter
            Dim ctgdt = ctgta.GetData()
            For i As Integer = 0 To ctgdt.Rows.Count - 1
                Dim bt As New Button

                bt.BackColor = Color.LightGoldenrodYellow
                bt.Text = ctgdt.Rows(i).Item("name").ToString
                bt.Name = "ctg" & i
                bt.Tag = ctgdt.Rows(i).Item("cid")

                bt.TextAlign = ContentAlignment.BottomCenter
                
                Try
                    If ctgdt.Rows(i).Item("img").ToString = "No Image" Or ctgdt.Rows(i).Item("img").ToString = "" Then
                        bt.BackColor = Color.Moccasin
                    Else
                        Dim str As String = Form1.BtImgPah.Tag & "\cat" & ctgdt.Rows(i).Item("img").ToString
                        If Form1.cbImgPrice.Checked Then
                            str = Form1.BtImgPah.Tag & "\P-cat" & ctgdt.Rows(i).Item("img").ToString
                            bt.Text = ""
                        End If

                        bt.BackgroundImage = Image.FromFile(str)
                    End If
                    bt.BackgroundImageLayout = ImageLayout.Stretch
                Catch ex As Exception
                    bt.Text = ctgdt.Rows(i).Item("name").ToString
                End Try

                    bt.Width = 125
                    bt.Height = 90
                Me.FlowLayoutPanel5.Controls.Add(bt)
                AddHandler bt.Click, AddressOf ctg3_click
            Next

            '''''''' add temperory mixete element
            'If Form1.admin Then
            '    Dim btMlg As New Button
            '    btMlg.BackColor = Color.LightGoldenrodYellow
            '    btMlg.Text = "Melange"
            '    btMlg.Name = "ctg0"
            '    btMlg.Tag = 0

            '    btMlg.TextAlign = ContentAlignment.BottomCenter

            '    btMlg.BackColor = Color.Moccasin

            '    btMlg.Width = 125
            '    btMlg.Height = 90

            '    AddHandler btMlg.Click, AddressOf ctg3_click
            'Me.FlowLayoutPanel5.Controls.Add(btMlg)
            'End If

            Me.Show()
            txtsearch.Focus()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ctg3_click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        '""""""""""""""""""""""""""
        ' a virifie '
        ''''''''''''''''''''''''''''''
        Dim bt2 As Button = sender
        DGVPRD.Rows.Clear()
        txtsearch.Text = ""

        Try
            Dim artta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
            Dim artdt = artta.GetDataBycid(bt2.Tag)

            If artdt.Rows.Count = 0 Then
                MsgBox("لا يوجد اي سجل", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "المواد")

            Else

                For i As Integer = 0 To artdt.Rows.Count - 1

                    DGVPRD.Rows.Add(artdt.Rows(i).Item("arid").ToString, artdt.Rows(i).Item("codebar").ToString,
                                    artdt.Rows(i).Item("name").ToString, artdt.Rows(i).Item("unite").ToString,
                                    artdt.Rows(i).Item("bprice").ToString, artdt.Rows(i).Item("sprice").ToString,
                                    artdt.Rows(i).Item("tva").ToString, artdt.Rows(i).Item("sp3").ToString,
                                    artdt.Rows(i).Item("sp4").ToString, artdt.Rows(i).Item("sp5").ToString,
                                    artdt.Rows(i).Item("poid").ToString, bt2.Tag, artdt.Rows(i).Item("Depot").ToString,
                                    artdt.Rows(i).Item("img").ToString, artdt.Rows(i).Item("mixte"), artdt.Rows(i).Item("elements"))

                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        txtsearch.Focus()
    End Sub

    Private Sub Button48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button48.Click
        txtsearch.Text = ""

        If DGVPRD.SelectedRows.Count = 0 Then Exit Sub
        Dim a As Integer = DGVPRD.SelectedRows(0).Index

        Dim art As New AddEditArticle
        art.editMode = True
        art.id = CInt(DGVPRD.SelectedRows(0).Cells(0).Value)
        art.PlPrice.Visible = Form1.chbsell.Checked

        If art.ShowDialog = Windows.Forms.DialogResult.OK Then
            'Dim bt As New Button
            'bt.Tag = DGVPRD.SelectedRows(0).Cells(11).Value
            'ctg3_click(bt, Nothing)
            DGVPRD.Rows(a).Cells(1).Value = art.txtcb.text
            DGVPRD.Rows(a).Cells(2).Value = art.txtprdname.Text
            DGVPRD.Rows(a).Cells(3).Value = art.txtunit.Text
            DGVPRD.Rows(a).Cells(4).Value = art.txtbprice.text
            DGVPRD.Rows(a).Cells(5).Value = art.txtsprice.text
            DGVPRD.Rows(a).Cells(6).Value = art.txttva.text
            DGVPRD.Rows(a).Cells(12).Value = art.CBdp.SelectedValue
        End If

        Try
            DGVPRD.Rows(a).Selected = True
            DGVPRD.FirstDisplayedScrollingRowIndex = DGVPRD.Rows(a).Index
        Catch ex As Exception
        End Try

        txtsearch.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        txtsearch.Text = ""

        If DGVPRD.SelectedRows.Count = 0 Then Exit Sub

        If MsgBox("عند قيامكم على الضغط على 'موافق' سيتم حذف المادة المؤشر عليها من القائمة .. إضغط  'لا'  لالغاء الحذف ", MsgBoxStyle.YesNo Or MessageBoxIcon.Exclamation, "حذف المادة") = MsgBoxResult.No Then
            Exit Sub
        End If
      
        Try
            Dim ta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter

            For i As Integer = 0 To DGVPRD.SelectedRows.Count - 1

                ta.DeleteQuery(DGVPRD.SelectedRows(i).Cells(0).Value)
            Next

            Dim bt As New Button
            bt.Tag = DGVPRD.SelectedRows(0).Cells(11).Value
            ctg3_click(bt, Nothing)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        txtsearch.Focus()
    End Sub

    Private Sub Button35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button35.Click
        txtsearch.Text = ""

        Dim art As New AddEditArticle
        art.btprd.Tag = "0"
        art.editMode = False
        'art.cbctg.Tag = "1"
        art.PlPrice.Visible = Form1.chbsell.Checked


        If art.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If

        txtsearch.Focus()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        '""""""""""""""""""""""""""
        ' a virifie '
        '''''''''''''''''''''''''''

        If txtsearch.Text.Length < 2 Then
            Exit Sub
        End If
        DGVPRD.Rows.Clear()

        Try
            Dim artta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
            Dim artdt As DataTable
            Dim artdt2 As DataTable


            If Form1.cbsearch.Text = "الرمز" Then
                artdt = artta.GetDatalikecodebar("%" & txtsearch.Text & "%")
            Else
                artdt = artta.GetDatalikename("%" & txtsearch.Text & "%")
            End If

            If Form1.cbsearch.Text = "الاسم" Then
                artdt = artta.GetDatalikename("%" & txtsearch.Text & "%")

            ElseIf Form1.cbsearch.Text = "الرمز" Then
                Dim str As String = "%" & txtsearch.Text & "%"
                artdt = artta.GetDatalikecodebar(str)

            Else
                Dim str As String = "%" & txtsearch.Text & "%"
                '  If Form1.adminName.Contains("*") Then str = "*" & txt.Text & "%"

                artdt = artta.GetDatalikecodebar(str)
                artdt2 = artta.GetDatalikename("%" & txtsearch.Text & "%")
                artdt.Merge(artdt2, False)
            End If




            If artdt.Rows.Count = 0 Then
                MsgBox("لا يوجد اي سجل", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "المواد")
                txtsearch.Text = ""
            Else
                For i As Integer = 0 To artdt.Rows.Count - 1
                    Dim bt As New Button
                    DGVPRD.Rows.Add(artdt.Rows(i).Item("arid").ToString, artdt.Rows(i).Item("codebar").ToString,
                                    artdt.Rows(i).Item("name").ToString, artdt.Rows(i).Item("unite").ToString,
                                    artdt.Rows(i).Item("bprice").ToString, artdt.Rows(i).Item("sprice").ToString,
                                    artdt.Rows(i).Item("tva").ToString, artdt.Rows(i).Item("sp3").ToString,
                                    artdt.Rows(i).Item("sp4").ToString, artdt.Rows(i).Item("sp5").ToString,
                                    artdt.Rows(i).Item("poid").ToString, artdt.Rows(i).Item("cid").ToString, artdt.Rows(i).Item("Depot").ToString,
                                    artdt.Rows(i).Item("img").ToString, artdt.Rows(i).Item("mixte"), artdt.Rows(i).Item("elements"))
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        txtsearch.Focus()

    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim cat As New AddEditCat

        If cat.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
        txtsearch.Focus()
    End Sub

    Private Sub txtsearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsearch.KeyUp
        Button5_Click(Nothing, Nothing)

        txtsearch.Focus()
    End Sub

    Private Sub DGVPRD_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGVPRD.DoubleClick
        Button48_Click(Nothing, Nothing)

        txtsearch.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cid As Integer = DGVPRD.SelectedRows(0).Cells(11).Value
        Dim id As Integer = DGVPRD.SelectedRows(0).Cells(0).Value
        If cid <> 0 And cid <> -100 Then Exit Sub
        Dim str As String = "مكونات هذه المــادة : "

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            Dim where As New Dictionary(Of String, Object)
            where.Add("arid", id)
            Dim elements As String = c.SelectByScalar("Article", "elements", where)

            str = str + vbNewLine
            str = str + DGVPRD.SelectedRows(0).Cells(2).Value
            str = str + vbNewLine
            str = str & " ID " & " | " & " Nom " & " | " & " qte "

            elements = elements.Substring(1, elements.Length - 2)
            Dim eleArr As String() = elements.Split("*")
            For i As Integer = 0 To eleArr.Length - 1
                Try
                    Dim arid As String = CStr(eleArr(i).Split("&")(0)).Split("|")(1)
                    Dim qte As String = CStr(eleArr(i).Split("&")(1))
                    Dim NAME As String = CStr(eleArr(i).Split("&")(0)).Split("|")(0)

                    str = str + vbNewLine
                    str = str & arid & " | " & NAME & " | " & qte
                Catch ex As Exception
                End Try
            Next
        End Using

        MsgBox(Str)

    End Sub

    Private Sub txtsearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsearch.KeyPress
        If e.KeyChar = Chr(13) Then
            Button5_Click(Nothing, Nothing)
            txtsearch.Text = ""
            txtsearch.Focus()
        End If
    End Sub
End Class