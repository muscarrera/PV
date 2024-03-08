Public Class CPanel

    Dim _bc As String
    Dim _liv As String

    Public Event UpdateQte()
    Public Event UpdatePrice()
    Public Event DeleteItems()
    Public Event UpdatePayment()
    Public Event UpdateRemise()
    Public Event UpdateClient()
    Public Event ValueChange()
    Public Event UpdateArticleRemise()
    Public Event UpdateArticledepot()
    Public Event UpdatearicleDetails()
    Public Event CommandeDate()
    Public Event ReturnItem()

    Private _hasRemise As Boolean
    Public isActive As Boolean = False
    Private _EditMode As Boolean
    Private _bl As String
    Private _depot As Integer = 0

    Event UpdateRefBon(ByVal p1 As String)

    Event DupliquerBon()

    Event DivisionBon()

    Event TotalDirect()





    'properties
    Public Property Value() As Double
        Get
            Dim qte As Double = 0
            If txt.Text = "" Then
                qte = 1
            Else
                qte = CDbl(txt.Text)
            End If
            Return qte
        End Get
        Set(ByVal value As Double)
            If value = 0 Then
                txt.Text = ""
            Else
                txt.Text = value
            End If
        End Set
    End Property
    Public Property EditMode() As Boolean
        Get
            Return _EditMode
        End Get
        Set(ByVal value As Boolean)
            _EditMode = value
            'If value Then
            '    btClient.Text = "Client"

            'Else
            '    btClient.Text = "Designation"
            'End If
        End Set
    End Property
    Public Property bl As String
        Get
            Return _bl
        End Get
        Set(ByVal value As String)
            If value = "" Then value = "---"
            _bl = value

        End Set
    End Property
    Public Property bc As String
        Get
            Return _bc
        End Get
        Set(ByVal value As String)
            If value = "" Then value = "---"
            _bc = value

        End Set
    End Property
    Public Property Liv As String
        Get
            Return _liv
        End Get
        Set(ByVal value As String)
            If value = "" Then value = "---"
            _liv = value

        End Set
    End Property
    Public Property hasRemise() As Boolean
        Get
            Return _hasRemise
        End Get
        Set(ByVal value As Boolean)
            _hasRemise = value
            'If value Then
            '    BtDel.Text = ""
            '    BtDel.BackgroundImage = My.Resources.Remisepng
            '    BtRemise.Visible = False
            'Else
            '    BtDel.Text = "C"
            '    BtDel.BackgroundImage = Nothing
            '    BtRemise.Visible = True
            'End If
        End Set
    End Property
    Public Property Depot As Integer
        Get
            Return _depot
        End Get
        Set(ByVal value As Integer)
            _depot = value
        End Set
    End Property

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt6.Click, bt5.Click, bt4.Click, bt7.Click, bt8.Click, bt9.Click, bt0.Click, bt3.Click, bt2.Click, bt1.Click, btPn.Click
        Dim bt As Button = sender
        Dim decimalSeparator As String = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        If bt.Text = btPn.Text Then
            If Not txt.Text.Contains(decimalSeparator) Then txt.Text = txt.Text + decimalSeparator
            Exit Sub
        End If
        txt.Text = txt.Text + bt.Text
    End Sub
    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        txt.Text = ""
    End Sub

    Public Sub ActiveQte(ByVal a As Boolean)
        Dim fnt As New Font("Microsoft Sans Serif", 9, FontStyle.Bold)
        Dim bkc As Color = Color.Teal
        Dim ftc As Color = Color.White
        isActive = True

        If a = False Then
            fnt = New Font("Microsoft Sans Serif", 9)
            bkc = Color.WhiteSmoke
            isActive = False
            ftc = Color.Black
        End If

        BtPrix.BackColor = bkc
        BtPrix.Font = fnt
        BtPrix.ForeColor = ftc
        BtQte.BackColor = bkc
        BtQte.ForeColor = ftc
        BtQte.Font = fnt
        BtDpt.BackColor = bkc
        BtDpt.ForeColor = ftc
        BtDpt.Font = fnt
        BtDel.BackColor = bkc
        'btClient.BackColor = bkc
        'If EditMode = False Then btClient.Text = "Designation"
        '''''''''''''

    End Sub
    Private Sub BtQte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtQte.Click
        If isActive Then
            If Form1.cbCafeMode.Checked And Form1.cbCafeTable.Checked Then Exit Sub

            If Form1.cbBadgeMA.Checked And EditMode Then
                Try
                    Dim sc As New UserParmissionCheck
                    sc.bName.Text = Form1.RPl.SelectedItem.Name
                    sc.lbNum.Text = Form1.RPl.SelectedItem.Qte
                    If sc.ShowDialog = DialogResult.OK Then
                        RaiseEvent UpdateQte()
                    End If
                Catch ex As Exception
                End Try

                Exit Sub
            End If
            RaiseEvent UpdateQte()
        Else
            RaiseEvent ValueChange()
        End If
    End Sub
    Private Sub BtPrix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtPrix.Click
        If isActive Then
            If Form1.cbCafeMode.Checked And Form1.cbCafeTable.Checked Then Exit Sub

            If Form1.cbBadgeMA.Checked And EditMode Then
                Try
                    Dim sc As New UserParmissionCheck
                    sc.bName.Text = Form1.RPl.SelectedItem.Name
                    sc.lbNum.Text = Form1.RPl.SelectedItem.Price
                    If sc.ShowDialog = DialogResult.OK Then
                         RaiseEvent UpdatePrice()
                    End If
                Catch ex As Exception
                End Try

                Exit Sub
            End If
            RaiseEvent UpdatePrice()

        Else
            RaiseEvent ValueChange()
        End If
    End Sub
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDel.Click

        If isActive Then

            If Form1.cbBadgeSA.Checked And EditMode Then
                Try
                    Dim sc As New UserParmissionCheck
                    sc.bName.Text = Form1.RPl.SelectedItem.Name
                    sc.lbNum.Text = Form1.RPl.SelectedItem.Qte
                    If sc.ShowDialog = DialogResult.OK Then
                        RaiseEvent DeleteItems()
                        isActive = False
                    End If
                Catch ex As Exception
                End Try

                Exit Sub
            End If

            RaiseEvent DeleteItems()
            isActive = False
        Else
            RaiseEvent ValueChange()
        End If
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        '  If Form1.adminRole < 31 Then Exit Sub

        If Form1.cbBadgeTPm.Checked Then
            Try
                Dim sc As New UserParmissionCheck
                sc.bName.Text = "Activer Paiements"
                sc.lbNum.Text = Form1.adminName
                If sc.ShowDialog = DialogResult.OK Then RaiseEvent UpdatePayment()
            Catch
            End Try
            Exit Sub
        End If


        RaiseEvent UpdatePayment()
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtRemise.Click
        If Form1.adminRole < 31 Then Exit Sub

        If hasRemise Then
            RaiseEvent UpdateArticleRemise()
        Else
            RaiseEvent UpdateRemise()
        End If
        RaiseEvent ValueChange()
    End Sub
    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPlus.Click
        If isActive Then

            If Form1.cbBadgeSA.Checked Then
                Try
                    Dim sc As New UserParmissionCheck
                    sc.bName.Text = "Retour"
                    sc.lbNum.Text = Form1.adminName
                    If sc.ShowDialog = DialogResult.OK Then RaiseEvent ReturnItem()
                Catch
                End Try
                Exit Sub
            End If




            RaiseEvent ReturnItem()
        Else
            RaiseEvent ValueChange()
        End If
    End Sub
    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDpt.Click
        If isActive Then
            RaiseEvent UpdateArticledepot()
        Else
            RaiseEvent ValueChange()
        End If
    End Sub
    Private Sub Client_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClient.Click
        'If isActive Then
        '    RaiseEvent UpdatearicleDetails()
        'Else

        If Form1.cbBadgeMB.Checked And EditMode Then
            Try
                Dim sc As New UserParmissionCheck
                sc.bName.Text = Form1.RPl.ClientName
                sc.lbNum.Text = Form1.RPl.FctId
                If sc.ShowDialog = DialogResult.OK Then
                    RaiseEvent UpdateClient()
                End If
            Catch ex As Exception
            End Try

            Exit Sub
        End If

        RaiseEvent UpdateClient()
        'End If

    End Sub
    Private Sub txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt.TextChanged
        RaiseEvent ValueChange()
    End Sub
    Private Sub BtCmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCmd.Click
        'RaiseEvent CommandeDate()
        'RaiseEvent UpdateRemise()
        Dim op As New PopUpMenu   ' OptionAddElement
        op.mode = "M:Machine"
        Dim params As New Dictionary(Of String, String)
        If Form1.RPl.isSell Then
            params.Add("Division bon  ", "6")
            params.Add("Dupliquer  ", "5")
            params.Add(" ---- ", "0")
            params.Add("Livreur : " & Liv, "3")
            params.Add("BC : " & bc, "2") '  la 
            params.Add("BL : " & bl, "1")
        Else
            params.Add("Total Direct  ", "10")
            params.Add("Dupliquer  ", "5")
            params.Add("BC : " & bc, "2") '  la 
            params.Add("BL : " & bl, "1")
        End If




        op.dataSource = params

        Dim MPx As Point = MousePosition()
        Dim y = 10 'MPx.Y - op.Height
        Dim x = 60
        op.Location = New Point(x, y)

        AddHandler op.MenuLostFocus, AddressOf MenuLostFocus
        AddHandler op.MenuElementSelected, AddressOf MenuElementSelected_Machine


        Me.Controls.Add(op)
        op.BringToFront()
    End Sub
    Private Sub MenuLostFocus(ByRef ds As PopUpMenu)
        Me.Controls.Remove(ds)
        ds.Dispose()
    End Sub
    Private Sub MenuElementSelected_Machine(ByRef op As PopUpMenu)
        Dim _str As String = ""
        If op.key = "1" Then
            RaiseEvent UpdateRefBon("bl")
        ElseIf op.key = "2" Then
            RaiseEvent UpdateRefBon("bc")
        ElseIf op.key = "3" Then
            RaiseEvent CommandeDate()
        ElseIf op.key = "5" Then
            RaiseEvent DupliquerBon()
        ElseIf op.key = "6" Then
            RaiseEvent DivisionBon()

        ElseIf op.key = "10" Then
            RaiseEvent TotalDirect()
        End If
    End Sub
    Private Sub Panel3_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel3.Resize
        Dim wd As Integer = Panel3.Width

        wd = CInt(wd / 3)

        'PLLF.Width = 50 + (wd / 2)
        'PLRT.Width = 50 + (wd / 2)


        bt1.Width = wd
        bt3.Width = wd
        bt4.Width = wd
        bt6.Width = wd
        bt7.Width = wd
        bt9.Width = wd
        btPlus.Width = wd
        btPn.Width = wd

        wd = Panel3.Height
        wd = CInt(wd / 4)

        PLNB1.Height = wd
        PLNB2.Height = wd
        PLNB3.Height = wd
        BtCmd.Height = wd
        BtRemise.Height = wd
        btClient.Height = wd
        BtQte.Height = wd
        BtPrix.Height = wd
        BtDel.Height = wd
    End Sub
End Class
