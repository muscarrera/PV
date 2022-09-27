Public Class SideClass



    Implements IDisposable



    Private Sub SaveXml()

        WriteToXmlFile(Of SideGlobal)("c:\cmc_Side.dat", Form1.GlobalSidePanel)
    End Sub
    Public Sub LoadXml(ByRef pl As Panel)
        pl.Visible = True
        pl.Width = 20

        Dim g As New SideGlobal
        Try


            g = ReadFromXmlFile(Of SideGlobal)("c:\cmc_Side.dat")
            Form1.GlobalSidePanel = g

            If IsNothing(g) Then
                g = New SideGlobal()
                Form1.GlobalSidePanel = g
                SaveXml()
            End If


            Dim i_pl As Integer = 0
            Dim i_el As Integer = 0

            For Each pp As SidePanel In g.listPanels

                Dim p As New Panel
                p.BackColor = Color.FromArgb(pp.backColor)
                p.Dock = DockStyle.Left
                p.Width = pp.width
                pl.Width += pp.width
                'index panelSide
                p.Tag = i_pl

                Dim fn As Font
                If pp.isBold Then
                    fn = New Font(pp.fname, pp.fSize, FontStyle.Bold)
                Else
                    fn = New Font(pp.fname, pp.fSize)
                End If

                'bt form edit paramettres
                Dim bTT As New Button
                bTT.FlatStyle = FlatStyle.Flat
                bTT.FlatAppearance.BorderColor = Color.FromArgb(pp.backColor)
                bTT.BackColor = Color.FromArgb(pp.backColor)
                bTT.Text = pp.sideName
                bTT.Visible = True
                bTT.TextAlign = ContentAlignment.MiddleCenter
                bTT.Dock = DockStyle.Bottom
                ' bTT.Tag = pp
                bTT.Tag = i_pl
                bTT.Height = 33
                AddHandler bTT.Click, AddressOf EditSidePanel
                p.Controls.Add(bTT)

                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    Dim params As New Dictionary(Of String, Object)

                 
                    'load list of side element
                    Dim i As Integer = 0
                    For Each el As SideElement In pp.ls
                        i += 1
                        Dim bt As New Button
                        bt.FlatStyle = FlatStyle.Flat
                        bt.FlatAppearance.BorderColor = Color.FromArgb(pp.backColor)
                        bt.BackColor = Color.WhiteSmoke
                        If i Mod 2 = 0 Then bt.BackColor = Color.Aqua

                        bt.Text = el.elementName
                        bt.Name = el.index & "|" & i
                        bt.BackgroundImageLayout = ImageLayout.Stretch
                        bt.Visible = True
                        bt.Height = pp.heigth
                        bt.TextAlign = ContentAlignment.BottomCenter
                        bt.Dock = DockStyle.Top
                        bt.ForeColor = Color.FromArgb(el.color)
                        bt.Font = fn
                        Try
                            bt.BackgroundImage = Image.FromFile(el.img)
                        Catch ex As Exception
                        End Try

                        If el.isArticle Then
                            If el.id = 0 Then
                                AddHandler bt.Click, AddressOf addNewElement
                            Else
                                params.Add("arid", el.id)
                                Dim artdt = a.SelectDataTable("article", {"*"}, params)
                                If artdt.Rows.Count = 0 Then
                                    AddHandler bt.Click, AddressOf addNewElement
                                Else
                                    bt.Tag = artdt.Rows(0)
                                    AddHandler bt.Click, AddressOf art_click
                                End If
                            End If
                        Else
                            bt.Tag = el.id
                            If el.id = 0 Then
                                AddHandler bt.Click, AddressOf addNewElement
                            Else
                                AddHandler bt.Click, AddressOf ctg_click
                            End If
                        End If

                        p.Controls.Add(bt)
                        i_el += 1
                    Next

                End Using
                pl.Controls.Add(p)
                i_pl += 1
            Next
        Catch ex As Exception
        End Try

        Form1.paletteFix_width = pl.Width
    End Sub
    Private Sub addNewElement(ByVal sender As Object, ByVal e As EventArgs)
        Dim ad As New AddEditSideElement
        Dim bt As Button = sender
        Try
            Dim Str = bt.Name
            Dim el As SideElement = Form1.GlobalSidePanel.listPanels(Str.Split("|")(0)).ls(Str.Split("|")(1))

            ad.element = el
            ad.isArticle = True

            If ad.ShowDialog = DialogResult.OK Then

                el = ad.element


                SaveXml()
                LoadXml(Form1.PL)
            End If

        Catch ex As Exception
        End Try



    End Sub
    Public Sub AddNewPanel()
        Dim ad As New AddEditSidePanel
        If ad.ShowDialog = DialogResult.OK Then
            Try
                Dim pl As New SidePanel

                pl.sideName = ad.txt.text
                pl.fname = ad.txtF1.text
                pl.fSize = ad.T.text
                pl.number = ad.N.text
                pl.heigth = ad.H.text
                pl.width = ad.W.text
                pl.isBold = ad.CheckBox1.Checked
                pl.backColor = ad.btColor.BackColor.ToArgb

                For i As Integer = 0 To pl.number - 1
                    Dim el As New SideElement
                    el.elementName = "EL " & (i + 1)
                    el.id = 0
                    el.color = Color.Black.ToArgb
                    el.index = Form1.GlobalSidePanel.listPanels.Count & "|" & i
                    pl.ls.Add(el)
                Next


                Form1.GlobalSidePanel.listPanels.Add(pl)
            Catch ex As Exception
            End Try



            SaveXml()
            LoadXml(Form1.PL)
        End If
    End Sub
    Private Sub EditSidePanel(ByVal sender As Object, ByVal e As EventArgs)

        Dim bt As Button = sender

        Dim pl As SidePanel = Form1.GlobalSidePanel.listPanels(bt.Tag)

        Dim ad As New AddEditSidePanel

        ad.txt.text = pl.sideName
        ad.txtF1.text = pl.fname
        ad.T.text = pl.fSize
        ad.N.text = pl.number
        ad.H.text = pl.heigth
        ad.W.text = pl.width
        ad.CheckBox1.Checked = pl.isBold
        ad.btColor.BackColor = Color.FromArgb(pl.backColor)

        ad.btSup.Visible = True
        If ad.ShowDialog = DialogResult.OK Then

            If ad.isDeleting = True Then
                Form1.GlobalSidePanel.listPanels.Remove(pl)

                Dim i_pl As Integer = 0
                Dim i_el As Integer = 0
                For Each pp As SidePanel In Form1.GlobalSidePanel.listPanels
                    For Each el As SideElement In pp.ls
                        el.index = i_pl & "|" & i_el
                        i_el += 1
                    Next
                       i_pl += 1
                Next

            Else

                Try
                    Dim dif = CInt(ad.N.text) - pl.number
                    If dif < 0 Then
                        For i As Integer = CInt(ad.N.text) To pl.number - 1
                            pl.ls.Remove(pl.ls(pl.ls.Count - 1))
                        Next
                    Else
                        For i As Integer = 0 To dif - 1
                            Dim el As New SideElement
                            el.elementName = "EL " & ((pl.number + i) + 1)
                            el.id = 0
                            el.color = Color.Black.ToArgb
                            el.index = bt.Tag & "|" & (pl.number + i)
                            pl.ls.Add(el)
                        Next
                    End If

                    pl.sideName = ad.txt.text
                    pl.fname = ad.txtF1.text
                    pl.fSize = ad.T.text
                    pl.number = ad.N.text
                    pl.heigth = ad.H.text
                    pl.width = ad.W.text
                    pl.isBold = ad.CheckBox1.Checked
                    pl.backColor = ad.btColor.BackColor.ToArgb

                Catch ex As Exception
                End Try


            End If
            SaveXml()
            LoadXml(Form1.PL)
        End If




    End Sub

    Private Sub art_click(ByVal sender As Object, ByVal e As EventArgs)

        If Control.ModifierKeys = Keys.Control Then
            addNewElement(sender, e)
            Exit Sub
        End If


        Using a As SubClass = New SubClass
            a.art_click(sender, e)
        End Using
    End Sub

    Private Sub ctg_click(ByVal sender As Object, ByVal e As EventArgs)
        If Control.ModifierKeys = Keys.Control Then
            addNewElement(sender, e)
            Exit Sub
        End If

        Using a As SubClass = New SubClass
            a.ctg_click(sender, e)
        End Using
    End Sub


#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class
