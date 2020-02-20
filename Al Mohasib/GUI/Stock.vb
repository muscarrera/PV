Public Class Stock

    Public AvId As Integer
    Public clid As Integer
    Public clientName As String
    Public ClientAdresse As String
    Public tt As Double

    Private _y As String
    Private _isEditing As Boolean = False

    Private Sub Stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ALMohassinDBDataSet.Depot' table. You can move, or remove it, as needed.
        Me.DepotTableAdapter.Fill(Me.ALMohassinDBDataSet.Depot)

        AvId = 0

        'TODO: This line of code loads data into the 'ALMohassinDBDataSet.company' table. You can move, or remove it, as needed.
        Me.CompanyTableAdapter.Fill(Me.ALMohassinDBDataSet.company)
        'fill category in main page

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
                        bt.BackgroundImage = Form1.BackgroundImage
                    Else
                        bt.BackgroundImage = Image.FromFile(ctgdt.Rows(i).Item("img").ToString)
                    End If

                    bt.BackgroundImageLayout = ImageLayout.Stretch
                Catch ex As Exception

                End Try
                bt.Width = 125
                bt.Height = 90
                Me.FlowLayoutPanel1.Controls.Add(bt)
                AddHandler bt.Click, AddressOf ctg_click
            Next
        Catch ex As Exception

        End Try


    End Sub

    Private Sub ctg_click2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Button1.Tag = "1" Then
            Select Case MsgBox("العمل الحالي عير مسجل. اضغط على موافق لحفظ العمل.", MsgBoxStyle.Information Or MsgBoxStyle.YesNoCancel, "AL Mohasseb Stock")
                Case MsgBoxResult.Yes
                    Button1_Click(Nothing, Nothing)
                Case MsgBoxResult.Cancel
                    Exit Sub

            End Select
        End If

        Dim bt2 As Button = sender
        DGVS.Rows.Clear()
        Try
            Dim artta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
            Dim artdt = artta.GetDataBycid(bt2.Tag)

            If artdt.Rows.Count > 0 Then
                For i As Integer = 0 To artdt.Rows.Count - 1

                    DGVS.Rows.Add(artdt.Rows(i).Item("arid").ToString, artdt.Rows(i).Item("codebar").ToString, artdt.Rows(i).Item("name").ToString, "", artdt.Rows(i).Item("unite").ToString, bt2.Tag)

                Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Button1.Tag = "0"



    End Sub
    Private Sub ctg_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Button1.Tag = "1" Then
            For i As Integer = 0 To DGVS.Rows.Count - 1
                If i > DGVS.Rows.Count - 1 Then Exit For
                If DGVS.Rows(i).Cells(3).Value = "" Then
                    DGVS.Rows.Remove(DGVS.Rows(i))
                    i -= 1

                End If
            Next
        End If
        Dim bt2 As Button = sender
        Try
            Dim artta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
            Dim artdt = artta.GetDataBycid(bt2.Tag)
            If artdt.Rows.Count > 0 Then
                For i As Integer = 0 To artdt.Rows.Count - 1
                    Dim price As Double = CDbl(artdt.Rows(i).Item("sprice").ToString)
                    If txttype.Text = "IN" Then price = CDbl(artdt.Rows(i).Item("bprice").ToString)
                    Dim ARID As String = artdt.Rows(i).Item("arid").ToString
                    Dim ISEXIST As Boolean = False

                    For T As Integer = 0 To DGVS.Rows.Count - 1
                        If DGVS.Rows(T).Cells(0).Value = ARID Then
                            ISEXIST = True
                            Exit For
                        End If
                        If DGVS.Rows(T).Cells(3).Value = "" Then Exit For
                    Next

                    If ISEXIST = False Then
                        DGVS.Rows.Add(ARID, artdt.Rows(i).Item("codebar").ToString,
                                                        artdt.Rows(i).Item("name").ToString, "", artdt.Rows(i).Item("unite").ToString,
                                                        bt2.Tag, artdt.Rows(i).Item("depot").ToString, price)
                    End If

                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Save_XmlFile(ByVal Id As Integer)

        Try

            Dim dt1 As DataTable = New DataTable
            Dim dc1 As DataColumn = New DataColumn("client")
            Dim dc2 As DataColumn = New DataColumn("clientID")
            Dim dc3 As DataColumn = New DataColumn("writer")
            Dim dc4 As DataColumn = New DataColumn("date")
            Dim dc5 As DataColumn = New DataColumn("Total")

            dt1.Columns.Add(dc1)
            dt1.Columns.Add(dc2)
            dt1.Columns.Add(dc3)
            dt1.Columns.Add(dc4)
            dt1.Columns.Add(dc5)

            Dim dt2 As DataTable = New DataTable
            Dim dcl1 As DataColumn = New DataColumn("arid")
            Dim dcl2 As DataColumn = New DataColumn("cd")
            Dim dcl3 As DataColumn = New DataColumn("name")
            Dim dcl4 As DataColumn = New DataColumn("qte")
            Dim dcl5 As DataColumn = New DataColumn("unit")
            Dim dcl6 As DataColumn = New DataColumn("cid")
            Dim dcl7 As DataColumn = New DataColumn("dpid")
            Dim dcl8 As DataColumn = New DataColumn("price")

            dt2.Columns.Add(dcl1)
            dt2.Columns.Add(dcl2)
            dt2.Columns.Add(dcl3)
            dt2.Columns.Add(dcl4)
            dt2.Columns.Add(dcl5)
            dt2.Columns.Add(dcl6)
            dt2.Columns.Add(dcl7)
            dt2.Columns.Add(dcl8)

            Dim writer As String = Form1.adminName
            Dim dte As String = Format(Now.Date, "dd-MM-yyyy")
            Dim total As String = 0

            For i As Integer = 0 To DGVS.Rows.Count - 1
                dt2.Rows.Add(DGVS.Rows(i).Cells(0).Value, DGVS.Rows(i).Cells(1).Value,
                             DGVS.Rows(i).Cells(2).Value, DGVS.Rows(i).Cells(3).Value,
                             DGVS.Rows(i).Cells(4).Value, DGVS.Rows(i).Cells(5).Value,
                              DGVS.Rows(i).Cells(6).Value, DGVS.Rows(i).Cells(7).Value)

                total += CDbl(DGVS.Rows(i).Cells(7).Value) * CDbl(DGVS.Rows(i).Cells(3).Value)
            Next

            dt1.Rows.Add(clientName, clid, writer, dte, total)

            dt1.TableName = "FactureInfo"
            dt2.TableName = "DetailsFacture"

            Dim ds As DataSet = New DataSet

            ds.DataSetName = "Facture"

            ds.Tables.Add(dt1)
            ds.Tables.Add(dt2)
            Dim yr As String = CDate(dtpstock.Text).Year

            Dim path As String = Form1.btSvPath.Tag & "/AVR_BN/" & yr & "/"
            If Not IO.Directory.Exists(path) Then
                IO.Directory.CreateDirectory(path)
            End If
            Dim nbr As Integer = IO.Directory.GetFiles(path).Length
            If Id > 0 Then nbr = Id

            path &= nbr

            Dim curFile As String = path
            For i As Integer = 0 To 100
                If Not IO.File.Exists(curFile) Then
                    ds.WriteXml(curFile)
                    Exit For
                End If
                If Id > 0 Then
                    IO.File.Delete(curFile)
                    ds.WriteXml(curFile)
                    Exit For
                End If
                curFile = path & i
            Next
         
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function SaveDb(ByVal b As Integer) As Boolean
        Dim MyCon As OleDb.OleDbConnection = Nothing
        Dim MyTRans As OleDb.OleDbTransaction = Nothing
        'start a transaction object
        Try
            MyCon = New OleDb.OleDbConnection(My.Settings.ALMohassinDBConnectionString)
            MyCon.Open()

            MyTRans = MyCon.BeginTransaction

            Dim cltype As String = "client"
            Dim dgvcol As Integer = 5

            For i As Integer = 0 To DGVS.Rows.Count - 1
                If DGVS.Rows(i).Cells(3).Value <> "" Then
                    Dim dtstock As Date = dtpstock.Text
                    Dim dpid As Integer = CInt(DGVS.Rows(i).Cells(6).Value)
                    Dim arid As Integer = CInt(DGVS.Rows(i).Cells(0).Value)

                    Dim SQL2 As String = "insert into DetailsStock (dpid,arid,name," & cltype & ",type,qte,codebar,unit,[date]) values ( :1,:2,:3,:4,:5,:6,:7,:8,:9)"
                   
                    SQL2 = "select DSID, qte from Detailstock where arid=:1 and dpid=:2"
                    Dim CMD61 As New OleDb.OleDbCommand
                    CMD61.Connection = MyCon
                    CMD61.Transaction = MyTRans
                    CMD61.CommandText = SQL2
                    CMD61.Parameters.AddWithValue(":1", arid)
                    CMD61.Parameters.AddWithValue(":1", dpid)
                    Dim dr61 = CMD61.ExecuteReader
                    CMD61.Dispose()

                    If dr61.HasRows Then
                        dr61.Read()
                        Dim dsid As Integer = dr61.Item("DSID")
                        Dim oldstkqte As Double = dr61.Item("qte")
                        dr61.Close()

                        oldstkqte = oldstkqte + (b * DGVS.Rows(i).Cells(3).Value)
                        SQL2 = "update  Detailstock set qte=:1 where DSID=:2"
                        Dim CMD71 As New OleDb.OleDbCommand
                        CMD71.Connection = MyCon
                        CMD71.Transaction = MyTRans
                        CMD71.CommandText = SQL2
                        CMD71.Parameters.AddWithValue(":1", oldstkqte)
                        CMD71.Parameters.AddWithValue(":2", dsid)
                        CMD71.ExecuteNonQuery()
                        CMD71.Dispose()
                    Else
                        SQL2 = "insert into  Detailstock (arid,dpid,qte,cid,unit) values(:1,:2,:3,:4,:5)"
                        Dim CMD71 As New OleDb.OleDbCommand
                        CMD71.Connection = MyCon
                        CMD71.Transaction = MyTRans
                        CMD71.CommandText = SQL2
                        CMD71.Parameters.AddWithValue(":1", arid)
                        CMD71.Parameters.AddWithValue(":2", dpid)
                        CMD71.Parameters.AddWithValue(":3", (b * DGVS.Rows(i).Cells(3).Value))
                        CMD71.Parameters.AddWithValue(":4", DGVS.Rows(i).Cells(5).Value)
                        CMD71.Parameters.AddWithValue(":5", DGVS.Rows(i).Cells(4).Value)
                        CMD71.ExecuteNonQuery()
                        CMD71.Dispose()
                    End If
                End If
            Next
            'all will save the changes
            MyTRans.Commit()
            ''close all 
            MyTRans.Dispose()
            MyCon.Close()
            MyCon.Dispose()
            ''''
        Catch ex As Exception
            If MyTRans IsNot Nothing Then
                MyTRans.Rollback()
            End If
            If MyCon IsNot Nothing Then
                If MyCon.State = ConnectionState.Open Then
                    MyCon.Close()
                End If
            End If
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try

        Return True

    End Function

    'save
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtname.Text = "" Then Exit Sub
        If Button1.Tag = "0" Then Exit Sub

        For i As Integer = 0 To DGVS.Rows.Count - 1
            If DGVS.Rows(i).Cells(3).Value = "" Then
                DGVS.Rows.Remove(DGVS.Rows(i))
                i -= 1
                If i = DGVS.Rows.Count - 1 Then Exit For
            End If
        Next


        If clid = 0 Then clientName = Form1.txtcltcomptoir.Text

        For i As Integer = 0 To DGVS.Rows.Count - 1
            If DGVS.Rows(i).Cells(3).Value = "" Then DGVS.Rows.Remove(DGVS.Rows(i))
        Next


        If SaveDb(1) Then
            'In case when it is updating the old avoir
            If AvId > 0 Then

            End If

            Save_XmlFile(AvId)

            Button1.Tag = "0"
            txtname.Text = ""
            TXTtOTAL.Text = 0
            clid = 0
            DGVS.Rows.Clear()
            dtpstock.Text = Now.Date
            _isEditing = False
            AvId = 0

        End If
    End Sub

    'value changed
    Private Sub DGVS_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVS.CellValueChanged
        Dim a As Integer = 0
        Dim TOTAL As Double = 0

        For i As Integer = 0 To DGVS.Rows.Count - 1
            Dim QTE As Double = 0
            Dim PRICE As Double = 0

            If DGVS.Rows(i).Cells(3).Value <> "" Then
                If Not IsNumeric(DGVS.Rows(i).Cells(3).Value) Then
                    If DGVS.Rows(i).Cells(3).Value.ToString.Contains(".") Then
                        DGVS.Rows(i).Cells(3).Value = DGVS.Rows(i).Cells(3).Value.ToString.Replace(".", Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                    End If
                    If Not IsNumeric(DGVS.Rows(i).Cells(3).Value) Then
                        ' MsgBox("المرجوا كتابة الكمية بالأرقام")
                        DGVS.Rows(i).Cells(3).Value = ""
                    End If
                End If
                a = 1
                Try
                    QTE = DGVS.Rows(i).Cells(3).Value
                Catch ex As Exception
                    QTE = 0
                End Try
            End If
            If CStr(DGVS.Rows(i).Cells(7).Value) <> "" Then
                If Not IsNumeric(DGVS.Rows(i).Cells(7).Value) Then
                    If DGVS.Rows(i).Cells(7).Value.ToString.Contains(".") Then
                        DGVS.Rows(i).Cells(7).Value = DGVS.Rows(i).Cells(7).Value.ToString.Replace(".", Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                    End If
                    If Not IsNumeric(DGVS.Rows(i).Cells(7).Value) Then
                        ' MsgBox("المرجوا كتابة الكمية بالأرقام")
                        DGVS.Rows(i).Cells(7).Value = ""
                    End If
                End If
                Try
                    PRICE = DGVS.Rows(i).Cells(7).Value
                Catch ex As Exception
                    PRICE = 0
                End Try
            End If

            TOTAL += QTE * PRICE
        Next
        If a = 1 Then
            Button1.Tag = "1"
        Else
            Button1.Tag = "0"
        End If


        TXTtOTAL.Text = TOTAL

    End Sub
    'exit
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To DGVS.Rows.Count - 1
            If DGVS.Rows(i).Cells(4).Selected = True Or DGVS.Rows(i).Cells(5).Selected = True Or DGVS.Rows(i).Cells(3).Selected = True Or DGVS.Rows(i).Cells(2).Selected = True Or DGVS.Rows(i).Cells(1).Selected = True Or DGVS.Rows(i).Cells(6).Selected = True Then
                Try
                    DGVS.Rows(i).Cells(5).Value = 0
                Catch ex As Exception
                End Try
            End If
        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim a As Integer = 0
        If Button1.Tag = "1" Then
            For i As Integer = 0 To DGVS.Rows.Count - 1
                If DGVS.Rows(i).Cells(3).Value = "" Then
                    DGVS.Rows.Remove(DGVS.Rows(i))
                    a += 1
                    i -= 1
                    If i = DGVS.Rows.Count - 1 Then Exit For
                End If
            Next
            If a = 0 & AvId = 0 Then DGVS.Rows.Clear()
        Else
            DGVS.Rows.Clear()
            TXTtOTAL.Text = 0
        End If

    End Sub
    'save & print
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Button1_Click(Nothing, Nothing)

            PrintDoc.PrinterSettings.PrinterName = Form1.txttimp.Text
            PrintDoc.Print()

        Catch ex As Exception

            If Form1.PrintDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintDoc.PrinterSettings.PrinterName = Form1.PrintDlg.PrinterSettings.PrinterName
                PrintDoc.Print()
            End If
        End Try
    End Sub
    Dim M As Integer = 0
    Private Sub PrintDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage
        Try
            Using a As DrawClass = New DrawClass
                Dim dte As Date = Now.Date
                a.DrawAvoir(e, DGVS, AvId, clientName, ClientAdresse, tt, dte, M)
            End Using
        Catch ex As Exception
            M = 0
        End Try
    End Sub
    'open old file
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim op As New OpenAvoir
        If op.ShowDialog = Windows.Forms.DialogResult.OK Then
            DGVS.Rows.Clear()
            Dim path As String = Form1.btSvPath.Tag & "/AVR_BN/" & op.Y & "/"
            If Not IO.Directory.Exists(path) Then
                MsgBox("Aucun resultat")
                Exit Sub
            End If
            Dim Filename As String = System.IO.Path.GetFileName(op.id)
            Dim SavePath As String = System.IO.Path.Combine(path, Filename)
            If System.IO.File.Exists(SavePath) Then
                'The file exists
                Try
                    Dim strpath As String = SavePath
                    Dim ds As New DataSet
                    ds.ReadXml(strpath)

                    TXTtOTAL.Text = op.DGV.SelectedRows(0).Cells(3).Value
                    dtpstock.Text = op.DGV.SelectedRows(0).Cells(2).Value

                    If ds.Tables("FactureInfo").Rows.Count > 0 Then
                        txtname.Text = ds.Tables("FactureInfo").Rows(0).Item("client")
                        clientName = ds.Tables("FactureInfo").Rows(0).Item("client")
                        clid = CInt(ds.Tables("FactureInfo").Rows(0).Item("clientID"))
                    End If
                    If ds.Tables("DetailsFacture").Rows.Count > 0 Then
                        For i As Integer = 0 To ds.Tables("DetailsFacture").Rows.Count - 1
                            DGVS.Rows.Add(ds.Tables("DetailsFacture").Rows(i).Item("arid"),
                                          ds.Tables("DetailsFacture").Rows(i).Item("cd"),
                                          ds.Tables("DetailsFacture").Rows(i).Item("name"),
                                          ds.Tables("DetailsFacture").Rows(i).Item("qte"),
                                          ds.Tables("DetailsFacture").Rows(i).Item("unit"),
                                           ds.Tables("DetailsFacture").Rows(i).Item("cid"),
                                            ds.Tables("DetailsFacture").Rows(i).Item("dpid"),
                                          ds.Tables("DetailsFacture").Rows(i).Item("price"))
                        Next
                    End If
                    ' save to db
                    If SaveDb(-1) Then
                        _isEditing = True
                        AvId = op.id
                        _y = CDate(dtpstock.Text).Year
                    Else
                        Button1.Tag = "0"
                        txtname.Text = ""
                        TXTtOTAL.Text = 0
                        clid = 0
                        DGVS.Rows.Clear()
                        dtpstock.Text = Now.Date
                        _isEditing = False
                        AvId = 0
                        MsgBox("Error Db")
                    End If
                Catch ex As Exception
                End Try
            Else
                MsgBox("Aucun resultat")
            End If
        End If
        op = Nothing
    End Sub
    'choose client
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim chs As New ChoseClient
        chs.isSell = True
        chs.editMode = False

        If chs.ShowDialog = Windows.Forms.DialogResult.OK Then
            clid = chs.cid
            clientName = chs.clientName
            txtname.Text = chs.clientName
        End If
    End Sub

    Private Sub Stock_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If _isEditing Then
            Select Case MsgBox("Voulez-vous enregistrer les modifications apportées à votre bon?", MsgBoxStyle.YesNoCancel, "Enregestrer les Changement")
                Case Is = MsgBoxResult.Ok 'save the changes '''''''''
                    Button1_Click(Nothing, Nothing)
                Case Is = MsgBoxResult.No 'go back to old value '''''''''
                    DGVS.Rows.Clear()
                    Dim path As String = Form1.btSvPath.Tag & "/AVR_BN/" & _y & "/"

                    Dim Filename As String = System.IO.Path.GetFileName(AvId)
                    Dim SavePath As String = System.IO.Path.Combine(path, Filename)
                    If System.IO.File.Exists(SavePath) Then
                        'The file exists
                        Try
                            Dim strpath As String = SavePath
                            Dim ds As New DataSet
                            ds.ReadXml(strpath)

                            If ds.Tables("DetailsFacture").Rows.Count > 0 Then
                                For i As Integer = 0 To ds.Tables("DetailsFacture").Rows.Count - 1
                                    DGVS.Rows.Add(ds.Tables("DetailsFacture").Rows(i).Item("arid"),
                                                  ds.Tables("DetailsFacture").Rows(i).Item("cd"),
                                                  ds.Tables("DetailsFacture").Rows(i).Item("name"),
                                                  ds.Tables("DetailsFacture").Rows(i).Item("qte"),
                                                  ds.Tables("DetailsFacture").Rows(i).Item("unit"),
                                                   ds.Tables("DetailsFacture").Rows(i).Item("cid"),
                                                    ds.Tables("DetailsFacture").Rows(i).Item("dpid"),
                                                  ds.Tables("DetailsFacture").Rows(i).Item("price"))
                                Next
                                ' Edit (db)
                                SaveDb(1)
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Case Else
                    e.Cancel = True
            End Select
        End If
    End Sub
End Class