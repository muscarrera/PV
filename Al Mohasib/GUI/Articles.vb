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

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ctg3_click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        '""""""""""""""""""""""""""
        ' a virifie '
        ''''''''''''''''''''''''''''''
        Dim bt2 As Button = sender
        DGVPRD.Rows.Clear()

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
                                    artdt.Rows(i).Item("img").ToString, artdt.Rows(i).Item("elements"))
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button48.Click
        If DGVPRD.SelectedRows.Count = 0 Then
            Exit Sub
        End If

        'If DGVPRD.SelectedRows(0).Cells(11).Value = 0 Then
        '    Exit Sub
        'End If
        Dim bprice As Double = String.Format("{0:F}", DGVPRD.SelectedRows(0).Cells(4).Value.ToString)
        Dim Sprice As Double = String.Format("{0:F}", DGVPRD.SelectedRows(0).Cells(5).Value.ToString)
        Dim tva As Double = String.Format("{0:F}", DGVPRD.SelectedRows(0).Cells(6).Value.ToString)
        Dim cid As Integer = DGVPRD.SelectedRows(0).Cells(11).Value
        Dim price2 As String = ""
        Dim price3 As String = ""
        Dim price4 As String = ""

        If Form1.chbsell.Checked Then
            price2 = String.Format("{0:F}", DGVPRD.SelectedRows(0).Cells(7).Value.ToString)
            price3 = String.Format("{0:F}", DGVPRD.SelectedRows(0).Cells(8).Value.ToString)
            price4 = String.Format("{0:F}", DGVPRD.SelectedRows(0).Cells(9).Value.ToString)
        End If


        Dim art As New AddEditArticle
        art.editMode = True

        art.cbctg.Tag = cid
        art.cid = cid
        art.cbctg.SelectedValue = CInt(DGVPRD.SelectedRows(0).Cells(11).Value.ToString)
        art.CBdp.SelectedValue = CInt(DGVPRD.SelectedRows(0).Cells(12).Value.ToString)
        art.CBdp.Tag = DGVPRD.SelectedRows(0).Cells(12).Value.ToString
        art.txtcb.text = DGVPRD.SelectedRows(0).Cells(1).Value.ToString
        art.txtprdname.Text = DGVPRD.SelectedRows(0).Cells(2).Value.ToString

        art.txtbprice.text = bprice
        art.txtsprice.text = Sprice
        art.txtprice2.text = price2
        art.txtprice3.text = price3
        art.txtPrice4.text = price4

        art.txtunit.Text = DGVPRD.SelectedRows(0).Cells(3).Value.ToString
        art.txttva.text = tva
        art.txtprdname.Tag = DGVPRD.SelectedRows(0).Cells(0).Value.ToString
        art.PlPrice.Visible = Form1.chbsell.Checked

        Try
            art.txtMinStock.text = CInt(DGVPRD.SelectedRows(0).Cells(14).Value)
        Catch ex As Exception
            art.txtMinStock.text = "0"
        End Try

        Try
            art.TxtPoids.text = DGVPRD.SelectedRows(0).Cells(10).Value.ToString
        Catch ex As Exception
            art.TxtPoids.text = "0"
        End Try


        Dim a As Integer = DGVPRD.SelectedRows(0).Index

        If DGVPRD.SelectedRows(0).Cells(7).Value.ToString <> "" And DGVPRD.SelectedRows(0).Cells(7).Value.ToString <> "No Image" Then
            Try
                '    Dim pmg3 As New Bitmap(dgvctg.SelectedRows(0).Cells(7).Value.ToString)
                art.PBprd.Tag = DGVPRD.SelectedRows(0).Cells(13).Value
                'art.PBprd.BackgroundImage = Image.FromFile(Form1.BtImgPah.Tag & "\art" & DGVPRD.SelectedRows(0).Cells(13).Value.ToString)
                art.ImgPrd = Image.FromFile(Form1.BtImgPah.Tag & "\art" & DGVPRD.SelectedRows(0).Cells(13).Value.ToString)
            Catch ex As Exception

            End Try

        End If

        art.btprd.Tag = "1"

        If art.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim bt As New Button
            bt.Tag = DGVPRD.SelectedRows(0).Cells(11).Value
            ctg3_click(bt, Nothing)
        End If

        Try
            DGVPRD.Rows(a).Selected = True
            DGVPRD.FirstDisplayedScrollingRowIndex = DGVPRD.Rows(a).Index
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
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
    End Sub

    Private Sub Button35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button35.Click

        Dim art As New AddEditArticle
        art.btprd.Tag = "0"
        art.editMode = False
        'art.cbctg.Tag = "1"

        art.PlPrice.Visible = Form1.chbsell.Checked

        If art.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
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

            If Form1.cbsearch.Text = "الرمز" Then
                artdt = artta.GetDatalikecodebar(txtsearch.Text & "%")
            Else
                artdt = artta.GetDatalikename("%" & txtsearch.Text & "%")
            End If


            If artdt.Rows.Count = 0 Then
                MsgBox("لا يوجد اي سجل", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "المواد")
            Else
                For i As Integer = 0 To artdt.Rows.Count - 1
                    Dim bt As New Button
                    DGVPRD.Rows.Add(artdt.Rows(i).Item("arid").ToString, artdt.Rows(i).Item("codebar").ToString, artdt.Rows(i).Item("name").ToString, artdt.Rows(i).Item("unite").ToString, artdt.Rows(i).Item("bprice").ToString, artdt.Rows(i).Item("sprice").ToString, artdt.Rows(i).Item("tva").ToString, artdt.Rows(i).Item("sp3").ToString, artdt.Rows(i).Item("sp4").ToString, artdt.Rows(i).Item("sp5").ToString, artdt.Rows(i).Item("poid").ToString, artdt.Rows(i).Item("cid").ToString, artdt.Rows(i).Item("Depot").ToString, artdt.Rows(i).Item("img").ToString)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim cat As New AddEditCat

        If cat.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If

    End Sub

    Private Sub txtsearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsearch.KeyUp
        Button5_Click(Nothing, Nothing)
    End Sub

    Private Sub DGVPRD_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGVPRD.DoubleClick
        Button48_Click(Nothing, Nothing)
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
End Class