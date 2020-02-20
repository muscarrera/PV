Public Class Facture
    Private clid As Integer
    Private ClientName As String
    Private lst As String
    Private _modePayement As String
    Private _iscache As Boolean
   
    Public Id As Integer
    Public EditMode As Boolean
    Public _UnpayedMode As Boolean = False
    Private remiseValue As Double

    Public Property UnpayedMode() As Boolean
        Get
            Return _UnpayedMode
        End Get
        Set(ByVal value As Boolean)
            _UnpayedMode = value
            DataGridView1.Columns(5).Visible = value
        End Set
    End Property
    Public Property ModePayement() As String
        Get
            Return _modePayement
        End Get
        Set(ByVal value As String)
            _modePayement = value
            If value = "Cache" Or value = "Autre" Then
                _iscache = True
            Else
                _iscache = False
            End If

            txtRemise.text = totalFacture
            LbRemise.Text = "Remise : " & remise & " % - (" & remiseValue & " dhs)"
            cbway.SelectedItem = value
        End Set
    End Property

    Public ReadOnly Property total As Double
        Get
            remiseValue = 0
            Dim tt As Double = 0
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                If CBool(DataGridView1.Rows(i).Cells(0).Value) = True Then

                    Dim t As Double = CDbl(DataGridView1.Rows(i).Cells(3).Value)
                    Dim r As Double = CDbl(DataGridView1.Rows(i).Cells(4).Value)

                    tt += t
                    remiseValue += ((t * 100) / (100 - r)) * r / 100
                End If
            Next
            Return tt
        End Get
    End Property

    Public ReadOnly Property totalFacture As Double
        Get
            If _iscache Then
                Return total + (total * 0.25 / 100)

            Else
                Return total

            End If
        End Get
    End Property

    Public ReadOnly Property remise As Double
        Get
            Dim t As Double = (total + remiseValue)
            Dim r As Double = remiseValue * 100 / t
            Return r
            'Dim t As Double = 0
            'For i As Integer = 0 To DataGridView1.Rows.Count - 1
            '    If CBool(DataGridView1.Rows(i).Cells(0).Value) = True Then
            '        t += (CDbl(DataGridView1.Rows(i).Cells(3).Value) * CDbl(DataGridView1.Rows(i).Cells(4).Value) / (100 - CDbl(DataGridView1.Rows(i).Cells(4).Value)))
            '    End If
            'Next
            'Return t
        End Get
    End Property

    Private Sub NewList()
        Try

            Dim chs As New ChoseClient
            chs.isSell = True
            chs.editMode = False

            If chs.ShowDialog = Windows.Forms.DialogResult.OK Then

                ClientName = chs.clientName
                clid = chs.cid

                Button1.Text = chs.clientName

                Dim dt2 As Date = CDate(DtpArt1.Text).AddDays(1)
                Dim dt1 As Date = CDate(DtpArt2.Text).AddDays(-1)


                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    Dim params As New Dictionary(Of String, Object)
                    params.Add("clid = ", clid)
                    params.Add("beInFacture = ", CInt(0))
                    params.Add("[date] >", dt1)
                    params.Add("[date] <", dt2)

                    Dim dt = c.SelectDataTableSymbols("Facture", {"*"}, params)

                    DataGridView1.Rows.Clear()
                    lst = ""
                    If dt.Rows.Count > 0 Then
                        For i As Integer = 0 To dt.Rows.Count - 1

                            DataGridView1.Rows.Add(False, dt.Rows(i).Item(0).ToString,
                       CDate(dt.Rows(i).Item("date")).ToString("dd, MMMM yy"),
                        dt.Rows(i).Item("total"),
                        dt.Rows(i).Item("remise"))

                        Next
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Else
                        MsgBox("لا توجد اي ايصالات لهذا الزبون")
                    End If
                    params = Nothing
                End Using
                UnpayedMode = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub AddToList()
        Try
            Dim dt2 As Date = DtpArt1.Text
            Dim dt1 As Date = DtpArt2.Text

            If clid = 0 Then
                Dim chs As New ChoseClient
                chs.isSell = True
                chs.editMode = False
                If chs.ShowDialog = Windows.Forms.DialogResult.OK Then
                    ClientName = chs.clientName
                    clid = chs.cid
                    Button1.Text = chs.clientName
                End If
            End If

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)
                params.Add("clid = ", clid)
                params.Add("beInFacture = ", 0)
                params.Add("[date] >", dt1)
                params.Add("[date] <", dt2)

                Dim dt = c.SelectDataTableSymbols("Facture", {"*"}, params)

                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1

                        '     DataGridView1.Rows.Add(False, dt.Rows(i).Item(0).ToString,
                        'CDate(dt.Rows(i).Item("date")).ToString("dd, MMM yy"),
                        'String.Format("{0:F}", dt.Rows(i).Item("total").ToString))

                        DataGridView1.Rows.Add(False, dt.Rows(i).Item(0).ToString,
                     CDate(dt.Rows(i).Item("date")).ToString("dd, MMMM yy"),
                      dt.Rows(i).Item("total"), dt.Rows(i).Item("remise"))
                    Next
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Else
                    MsgBox("لا توجد اي ايصالات لهذا الزبون")
                End If
                params = Nothing
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub AddToList(ByVal fid As Integer, ByVal cNAME As String, ByVal txt As String, ByVal mode As String, ByVal cid As Integer)
        Try
            lst = txt
            Id = fid
            ClientName = cNAME
            Button1.Text = cNAME
            ModePayement = mode
            clid = cid

            DataGridView1.Rows.Clear()

            If lst = "-" Then Exit Sub
            Dim arr As String() = txt.Split(",")
            Dim params As New Dictionary(Of String, Object)

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                For i As Integer = 0 To arr.Length - 1
                    params.Add("fctid", arr(i))
                    Dim dt = c.SelectDataTable("Facture", {"*"}, params)

                    If dt.Rows.Count > 0 Then
                        DataGridView1.Rows.Add(True, dt.Rows(0).Item(0).ToString,
                         CDate(dt.Rows(0).Item("date")).ToString("dd, MMMM yy"),
                          dt.Rows(0).Item("total"), dt.Rows(0).Item("remise"))
                    End If

                    dt = Nothing
                    params.Clear()
                Next
            End Using
            txtRemise.text = total
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub UnPayedList(ByVal b As Boolean)
        Try
            Dim dt2 As Date = CDate(DtpArt1.Text).AddDays(1)
            Dim dt1 As Date = CDate(DtpArt2.Text).AddDays(-1)


            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)
                params.Add("beInFacture <= ", CInt(0))
                params.Add("[date] >", dt1)
                params.Add("[date] <", dt2)

                Dim dt = c.SelectDataTableSymbols("Facture", {"*"}, params)

                If b = False Then DataGridView1.Rows.Clear()

                lst = ""
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1

                        '     DataGridView1.Rows.Add(False, dt.Rows(i).Item(0).ToString,
                        'CDate(dt.Rows(i).Item("date")).ToString("dd, MMM yy"),
                        'String.Format("{0:F}", dt.Rows(i).Item("total").ToString),
                        ' dt.Rows(i).Item("name").ToString)

                        DataGridView1.Rows.Add(False, dt.Rows(i).Item(0).ToString,
                     CDate(dt.Rows(i).Item("date")).ToString("dd, MMMM yy"),
                      dt.Rows(i).Item("total"), dt.Rows(i).Item("remise"),
                       dt.Rows(i).Item("name").ToString)

                    Next
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    UnpayedMode = True
                Else
                    MsgBox("لا توجد اي ايصالات لهذا الزبون")
                End If
                params = Nothing
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'If clid = 0 Then EditMode = False

        If EditMode Then
            'If lst = "-" Then
            '    NewList()
            'Else
            AddToList()
            'End If

        Else
            NewList()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim b As Boolean
        If DataGridView1.Rows.Count = 0 Then Exit Sub
        If lst = "" Then Exit Sub

        'selection le nom de porteur de facture
        If UnpayedMode Then
            Dim chs As New ChoseClient
            chs.isSell = True
            If chs.ShowDialog = Windows.Forms.DialogResult.OK Then

                ClientName = chs.clientName
                clid = chs.cid
            End If
        End If

        Using a As SubFacture = New SubFacture
            ' ajouter le droit de timber a 1er bon
            If ModePayement = "Cache" Or ModePayement = "Autre" Then
                Dim timber = (total * 0.25 / 100)

                Dim bid As Integer = 0

                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    If DataGridView1.Rows(i).Cells(0).Value = True Then
                        bid = DataGridView1.Rows(i).Cells(1).Value

                        If DataGridView1.Rows(i).Cells(5).Value <> 0 Then
                            bid = DataGridView1.Rows(i).Cells(1).Value
                            Exit Sub
                        End If
                    End If
                Next



                a.AddDroitTimbre(Id, bid, clid, timber)

            End If

            'enregestrer la facture

            If txtRemise.text = "" Then txtRemise.text = 0
            If EditMode Then
                b = a.UpdateFacture(Id, clid, DtFct.Text, remise, totalFacture, lst, _iscache, ModePayement)
                If b Then Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                Id = a.NewFacture(clid, DtFct.Text, remise, totalFacture, lst, _iscache, ModePayement)
                If Id > 0 Then Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        End Using
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        UnPayedList(EditMode)
    End Sub
    Private Sub cbway_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbway.SelectedIndexChanged
        ModePayement = cbway.Text
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Rows.Count = 0 Then Exit Sub

        Dim a As Boolean = False

        If CBool(DataGridView1.SelectedRows(0).Cells(0).Value) = False Then a = True
        DataGridView1.SelectedRows(0).Cells(0).Value = a

        DataGridView1.Sort(DataGridView1.Columns(0),
       System.ComponentModel.ListSortDirection.Descending)

        lst = ""
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(0).Value = True Then
                If lst <> "" Then lst += ","
                lst += DataGridView1.Rows(i).Cells(1).Value
            End If
        Next

        txtRemise.text = totalFacture
        LbRemise.Text = "Remise : " & remise & " % - (" & remiseValue & " dhs)"
    End Sub
End Class