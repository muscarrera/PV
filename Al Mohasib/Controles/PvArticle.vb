Public Class PvArticle

    Public Event Choosed(ByVal sender As Object, ByVal e As EventArgs)
    Public Event MousseDown(ByVal sender As Button, ByVal e As MouseEventArgs)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' lb.Font = New Font(Form1.fontName_PV, Form1.fontSize_PV, FontStyle.Bold)


    End Sub
    Private _data As DataRow



    Public Property DataSource() As DataRow
        Get
            Return _data
        End Get
        Set(ByVal value As DataRow)
            _data = value

            lb.Text = value.Item("name").ToString.ToLower
            img = value.Item("img").ToString

            If Form1.cbImgPrice.Checked Then
                lbP.Text = CDbl(value.Item("sprice")).ToString(Form1.frmDbl)
                lbP.Visible = True
            End If

            'Try
            '    Dim arrImage() As Byte
            '    arrImage = value.Item("img")
            '    Dim mstream As New System.IO.MemoryStream(arrImage)
            '    Me.BackgroundImage = Image.FromStream(mstream)
            'Catch ex As Exception
            '    Me.BackgroundImage = Nothing
            'End Try

            'plB.Height = lb.PreferredHeight

        End Set
    End Property
    Public Property img As String
        Get
            Return ""
        End Get
        Set(ByVal value As String)
            Try
                If value = "No Image" Or value = "" Then Exit Property

                Dim str As String = Form1.BtImgPah.Tag & "\art" & value

                Dim mypic As New System.IO.FileStream(str, IO.FileMode.Open)
                Dim _img As Image = Image.FromStream(mypic)
                mypic.Close()
                PL.BackgroundImage = _img

            Catch ex As Exception
            End Try
        End Set
    End Property
    Public Property fnt As Font
        Get
            Return lb.Font
        End Get
        Set(ByVal value As Font)
            lb.Font = value
            scaleFont(lb)
        End Set
    End Property

    Private Sub scaleFont(ByVal lab As Label)
        Dim fakeImage As Image = New Bitmap(1, 1)
        Dim g As Graphics = Graphics.FromImage(fakeImage)
        Dim size As SizeF = g.MeasureString(lab.Text, lab.Font, lab.Width)
        If PL.Height < size.Height Then PL.Height = size.Height
    End Sub


    Private Sub lb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click, lb.Click, PL.Click, plB.Click, lbP.Click, lbBP.Click
        Dim bt As New Button
        bt.Tag = DataSource
        RaiseEvent Choosed(bt, e)
    End Sub
    Private Sub lb_MousseDown(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown, lb.MouseDown, PL.MouseDown, plB.MouseDown, lbP.MouseDown, lbBP.MouseDown
        Dim bt As New Button
        bt.Tag = DataSource
        RaiseEvent MousseDown(bt, e)
    End Sub
    Private Sub PL_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PL.DoubleClick
        Dim bt As New Button
        bt.Tag = DataSource
        RaiseEvent Choosed(bt, e)
        RaiseEvent Choosed(bt, e)
    End Sub

    Private Sub PL_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PL.MouseEnter, lb.MouseEnter
        lbBP.Visible = True

        If Form1.cbArtcleStockDetails.Checked = False Then Exit Sub
        If CInt(_data("cid")) < 0 Then Exit Sub

        btInfo.Visible = True

    End Sub
    Private Sub PL_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.MouseLeave
        btInfo.Visible = False
        lbBP.Visible = False
    End Sub

    Private Sub btInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btInfo.Click
        ALPHA = Not ALPHA
        btInfo_MouseEnter(sender, e)
    End Sub
    Dim AlphaParams As New Dictionary(Of String, String)
    Private Sub btInfo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btInfo.MouseEnter

        If bk.IsBusy = False Then bk.RunWorkerAsync()

        System.Threading.Thread.Sleep(1000)

        If AlphaParams.Count = 0 Then Exit Sub

        btInfo.BackColor = Color.Green
        'RaiseEvent UpdateRemise()
        Dim op As New PopUpMenu   ' OptionAddElement
        op.mode = "DT:Stock"
        'params.Add("Date d'échéance", "1") '  la 
        'params.Add("Date de création", "2") 'le mois dernier  la semaine dernière

        op.dataSource = AlphaParams

        Dim MPx As Point = MousePosition()
        Dim y = 15 'MPx.Y - op.Height
        Dim x = 2
        op.Location = New Point(x, y)

        AddHandler op.MenuLostFocus, AddressOf MenuLostFocus
        AddHandler op.MenuElementSelected, AddressOf MenuElementSelected

        op.BringToFront()

        PL.Controls.Add(op)
        op.BringToFront()
        ' op.Focus()

    End Sub
    Dim ALPHA As Boolean = False
    Private Sub MenuLostFocus(ByRef ds As PopUpMenu)
        If ALPHA Then Exit Sub
        PL.Controls.Remove(ds)
        ds.Dispose()
    End Sub
    Private Sub MenuElementSelected(ByRef ds As PopUpMenu)
        ALPHA = False

        _data("depot") = ds.key

          Dim bt As New Button
        bt.Tag = DataSource
        RaiseEvent Choosed(bt, Nothing)
    End Sub
    Private Sub btInfo_Mouseleave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btInfo.MouseLeave
        btInfo.BackColor = Color.White
    End Sub

    Private Sub bk_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bk.DoWork
        Try
            Dim sdt As DataTable
            AlphaParams.Clear()
            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)

                params.Add("arid", _data("arid"))
 
                sdt = a.SelectDataTable("detailstock", {"*"}, params)

            End Using
            If sdt.Rows.Count > 0 Then
                For i As Integer = 0 To sdt.Rows.Count - 1
                    AlphaParams.Add(sdt.Rows(i).Item("dpid") & " : " & CInt(sdt.Rows(i).Item("qte")) & " (" & sdt.Rows(i).Item("unit") & ")", sdt.Rows(i).Item("dpid"))
                Next
            End If

        Catch ex As Exception
        End Try
    End Sub
 
    Private Sub PvArticle_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.MouseEnter
        If Form1.admin = False And Form1.cbShowBp.Checked Then Exit Sub

        lbBP.Text = CDbl(DataSource.Item("bprice")).ToString(Form1.frmDbl)
        lbBP.Visible = True
    End Sub

   

End Class
