Public Class AddArticleToFacture
    Public R As ALMohassinDBDataSet.ArticleRow
    Private Sub Button41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button41.Click


        If txtartsearch.Text.Trim = "" Then
            Exit Sub
        End If

        Me.FlowLayoutPanel1.Controls.Clear()
        Try
            Dim artta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
            Dim artdt As DataTable


            artdt = artta.GetDatalikecodebar(txtartsearch.Text & "%")



            If artdt.Rows.Count = 0 Then
                Dim lb As New Label

                lb.ForeColor = Color.DarkGray
                lb.Text = "لا يوجد اي سجل"
                Me.FlowLayoutPanel1.Controls.Add(lb)

            Else
                For i As Integer = 0 To artdt.Rows.Count - 1

                    Dim bt As New Button

                    bt.Visible = True
                    bt.BackColor = Color.LightSeaGreen
                    bt.Text = artdt.Rows(i).Item("name").ToString
                    bt.Name = "art" & i
                    bt.Tag = artdt.Rows(i)
                    bt.TextAlign = ContentAlignment.BottomCenter
                    Try
                        If artdt.Rows(i).Item("img").ToString = "No Image" Or artdt.Rows(i).Item("img").ToString = "" Then

                        Else
                            bt.BackgroundImage = Image.FromFile(artdt.Rows(i).Item("img").ToString)
                        End If

                        bt.BackgroundImageLayout = ImageLayout.Stretch
                        bt.ImageAlign = ContentAlignment.BottomCenter
                    Catch ex As Exception

                    End Try
                    bt.Width = Form1.txtlongerbt.Text
                    bt.Height = Form1.txtlargebt.Text
                    Me.FlowLayoutPanel1.Controls.Add(bt)
                    AddHandler bt.Click, AddressOf art_click

                    If i = 20 Then
                        Exit For
                    End If
                Next

            End If
            txtartsearch.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub art_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim bt As Button = sender
        'get the details
        R = bt.Tag
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub txtartsearch_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtartsearch.KeyUp
        If Form1.chbcb.Checked = False Then
            Button41_Click(Nothing, Nothing)
        End If

    End Sub
End Class