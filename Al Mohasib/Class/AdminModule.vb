Imports System.IO
Imports System.Net.NetworkInformation
Imports System.Text.RegularExpressions

Module AdminModule

    Dim VER As String = "ALMsbtrFirstRun_sql_12"
    Dim VER_ID As String = "sdf_id_cvb_ver"
    Dim DB_ID As String = "fgh_db_ert_id"
    Dim _strLastDate As String = "lastDate_17"

    Dim _strKey As String
    Dim strFirstUse = "AL Mohasib System de gestion - Premier utilisation .."
    Dim nbrDays = 90
    Dim __id As String = "00"
    Dim __oldid As String = "--"


    Public ReadOnly Property TrialVersion_Master
        Get
            Return checktrialMaster()
        End Get
    End Property
    Public ReadOnly Property TrialVersion_Slave
        Get
            Return checktrialSlave()
        End Get
    End Property

    Private ReadOnly Property strKey As String
        Get
            Dim r = VER

            Dim mac = getMacAddress()
            'mac = Regex.Replace(mac, "[^0-9]", "")

            'r &= "_" & mac
            Return r
        End Get
    End Property

    'Functions
    Private Function LookForIt() As Boolean
        If isAFerstTime() Then
            If __oldid.Length < 5 Then
                Dim us As New UserInterface
                us.ID = __id

                If us.ShowDialog = DialogResult.OK Then
                    setRegistryinfo(VER_ID, __id)
                    setRegistryinfo(DB_ID, us.dbid)




                Else
                    MsgBox("Vous devez Contacter l'administration pour plus d'infos" & vbNewLine & __id, MsgBoxStyle.Information, "***TRIAL INTERFACE***")
                    End
                End If
            End If
        Else





        End If

        Return False
    End Function

    Private Function getRegistryinfo(ByVal str As String, ByVal v As String)
        Try
            Dim msg As String
            msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, Nothing)
            Return msg
        Catch ex As Exception
            Return v
        End Try
    End Function
    Private Function setRegistryinfo(ByVal str As String, ByVal v As String)
        Try
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", str, v)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Private Function HandleRegistry_net() As Integer
    '    Dim ALMohasibfirstRunDate As Date
    '    Dim LastRunDate As Date

    '    ALMohasibfirstRunDate = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", strKey, Nothing)
    '    LastRunDate = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", _strLastDate, Nothing)

    '    If LastRunDate = Nothing Then
    '        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", _strLastDate, Now.Date)
    '    ElseIf (Now - LastRunDate).Days <= -10 Then
    '        MsgBox("Merci de regler la date de votre PC ..", MsgBoxStyle.Information, "Error_Date")
    '        End
    '    End If

    '    If CDate(Now) > CDate(LastRunDate) Then My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", _strLastDate, Now.Date)

    '    '''''''''''''''''''''''''''''''''''''''''''''       '''''''''''''''''''''''''''''''''''''''''''''
    '    '''''''''''''''''''''''''''''''''''''''''''''       '''''''''''''''''''''''''''''''''''''''''''''
    '    Using a As DataAccess2 = New DataAccess2(My.Settings.ALMohassinDBConnectionString)


    '        If ALMohasibfirstRunDate = Nothing Then
    '            ALMohasibfirstRunDate = Now
    '            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", strKey, ALMohasibfirstRunDate)
    '            Try

    '                Dim where As New Dictionary(Of String, Object)
    '                where.Add("key", "keypsv")

    '                Dim dt = a.SelectDataTable("value", {"*"}, where)
    '                Dim val As String = ALMohasibfirstRunDate.Day & ALMohasibfirstRunDate.Hour & "-" & ALMohasibfirstRunDate.Second & "1d5-" & ALMohasibfirstRunDate.ToString("yy") & "2H7" & "-" & __id.ToString.Substring(__id.ToString.Length - 4) & "-" & __id.ToString.Substring(0, 4) & ALMohasibfirstRunDate.Month

    '                If dt.Rows.Count > 0 Then
    '                    Dim params As New Dictionary(Of String, Object)
    '                    params.Add("val", val)
    '                    a.UpdateRecord("value", params, where)
    '                Else
    '                    Dim params As New Dictionary(Of String, Object)
    '                    params.Add("key", "keypsv")
    '                    params.Add("val", val)
    '                    a.InsertRecord("value", params)
    '                End If
    '                where.Clear()
    '                where.Add("key", "truefont")
    '                Dim dt2 = a.SelectDataTable("value", {"*"}, where)


    '                If dt.Rows.Count > 0 Then

    '                    Dim params As New Dictionary(Of String, Object)
    '                    params.Add("val", "false")

    '                    a.UpdateRecord("value", params, where)
    '                Else

    '                    Dim params As New Dictionary(Of String, Object)
    '                    params.Add("key", "truefont")
    '                    params.Add("val", "False")
    '                    a.InsertRecord("value", params)

    '                End If

    '                MsgBox(strFirstUse)

    '            Catch ex As Exception
    '                MsgBox(ex.Message)

    '            End Try
    '            Return 1
    '        ElseIf (Now - ALMohasibfirstRunDate).Days > nbrDays Then
    '            Try

    '                Dim val As String = ALMohasibfirstRunDate.Day & ALMohasibfirstRunDate.Hour & "-" & ALMohasibfirstRunDate.Second & "1d5-" & ALMohasibfirstRunDate.ToString("yy") & "2H7" & "-" & mac.ToString.Substring(mac.ToString.Length - 4) & "-" & mac.ToString.Substring(0, 4) & ALMohasibfirstRunDate.Month

    '                Dim where As New Dictionary(Of String, Object)
    '                where.Add("key", "keypsv")

    '                Dim dt = a.SelectDataTable("value", {"*"}, where)


    '                If dt.Rows.Count > 0 Then

    '                    If dt.Rows(0).Item("val") <> val Then

    '                        Dim params As New Dictionary(Of String, Object)
    '                        params.Add("val", val)

    '                        a.UpdateRecord("value", params, where)

    '                        where.Clear()
    '                        where.Add("key", "truefont")

    '                        Dim dt2 = a.SelectDataTable("value", {"*"}, where)

    '                        params.Clear()

    '                        If dt.Rows.Count > 0 Then
    '                            params.Add("val", "false")
    '                            a.UpdateRecord("value", params, where)

    '                        Else
    '                            params.Add("key", "truefont")
    '                            params.Add("val", "false")
    '                            a.InsertRecord("value", params)

    '                            MsgBox(strFirstUse)
    '                        End If

    '                    Else

    '                    End If
    '                Else

    '                    Dim params As New Dictionary(Of String, Object)
    '                    params.Add("key", "keypsv")
    '                    params.Add("val", val)
    '                    a.InsertRecord("value", params)

    '                    params.Clear()
    '                    where.Clear()

    '                    where.Add("key", "truefont")
    '                    Dim dt2 = a.SelectDataTable("value", {"*"}, where)


    '                    If dt.Rows.Count > 0 Then
    '                        params.Add("val", val)
    '                        a.UpdateRecord("value", params, where)

    '                    Else
    '                        params.Add("key", "truefont")
    '                        params.Add("val", "false")
    '                        a.InsertRecord("value", params)

    '                    End If
    '                    MsgBox(strFirstUse)

    '                End If
    '                '''''''

    '            Catch ex As Exception
    '                MsgBox(ex.Message)

    '            End Try
    '            Return 0
    '        Else

    '            Try
    '                Dim params As New Dictionary(Of String, Object)
    '                Dim where As New Dictionary(Of String, Object)

    '                where.Clear()

    '                where.Add("key", "keypsv")
    '                Dim dt = a.SelectDataTable("value", {"*"}, where)

    '                Dim val As String = ALMohasibfirstRunDate.Day & ALMohasibfirstRunDate.Hour & "-" & ALMohasibfirstRunDate.Second & "1d5-" & ALMohasibfirstRunDate.ToString("yy") & "2H7" & "-" & mac.ToString.Substring(mac.ToString.Length - 4) & "-" & mac.ToString.Substring(0, 4) & ALMohasibfirstRunDate.Month
    '                ''''''
    '                If dt.Rows.Count > 0 Then

    '                    If dt.Rows(0).Item("val") <> val Then

    '                        params.Add("val", val)
    '                        a.UpdateRecord("value", params, where)


    '                        params.Clear()
    '                        where.Clear()

    '                        where.Add("key", "truefont")
    '                        Dim dt2 = a.SelectDataTable("value", {"*"}, where)

    '                        If dt.Rows.Count > 0 Then
    '                            params.Add("val", "false")
    '                            a.UpdateRecord("value", params, where)

    '                        Else

    '                            params.Add("key", "truefont")
    '                            params.Add("val", "false")
    '                            a.InsertRecord("value", params)

    '                            MsgBox(strFirstUse)
    '                        End If

    '                    Else

    '                    End If
    '                Else
    '                    params.Clear()
    '                    params.Add("key", "keypsv")
    '                    params.Add("val", val)
    '                    a.InsertRecord("value", params)

    '                    params.Clear()
    '                    where.Clear()

    '                    where.Add("key", "truefont")
    '                    Dim dt2 = a.SelectDataTable("value", {"*"}, where)


    '                    If dt.Rows.Count > 0 Then
    '                        params.Add("val", "false")
    '                        a.UpdateRecord("value", params, where)

    '                    Else
    '                        params.Clear()
    '                        params.Add("key", "truefont")
    '                        params.Add("val", "False")
    '                        a.InsertRecord("value", params)

    '                    End If
    '                    MsgBox(strFirstUse)

    '                End If
    '                '''''''

    '            Catch ex As Exception
    '                MsgBox(ex.Message)
    '            End Try
    '            Return 1
    '        End If
    '    End Using
    'End Function



    '1 ferstTimeToOpen
    Private Function isAFerstTime() As Boolean

        Try
            Dim md As String = SystemSerialNumber()
            Dim cp As String = CpuId()

            __id = "I5050D" & md & cp
            __oldid = getRegistryinfo(VER_ID, "")

            If __id = __oldid Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return True
        End Try
    End Function

    '2ChequeFortheId && isMasterOrSlayve


    '3ifxTimeCheckTheCloud



    '4ifNeverConnectForAyear



    '5ChequeLocally





    ' for master
    Private Function checktrialMaster() As Boolean
        Dim resultkey As Integer = HandleRegistry2()
        If resultkey = 0 Then 'something went wrong
            Dim fdt As Date
            fdt = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", strKey, Nothing)
            Try
                Using a As DataAccess2 = New DataAccess2(My.Settings.ALMohassinDBConnectionString)
                    Dim params As New Dictionary(Of String, Object)
                    params.Add("key", "truefont")

                    Dim dt2 = a.SelectDataTable("value", {"*"}, params)


                    If dt2.Rows(0).Item("val") = "true" Then
                        Form1.bttrial.Visible = False
                        Return True
                        Exit Function
                    Else
                        Dim trial As New TrialVersion
                        If trial.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                            Return False
                            Exit Function
                        Else
                            Return True
                            Exit Function
                        End If
                    End If
                End Using
            Catch ex As Exception
                Return False
            End Try
        Else

            Try
                Using a As DataAccess2 = New DataAccess2(My.Settings.ALMohassinDBConnectionString)


                    Dim params As New Dictionary(Of String, Object)
                    params.Add("key", "truefont")
                    Dim dt = a.SelectDataTable("value", {"*"}, params)

                    If dt.Rows(0).Item("val") = "true" Then
                        Form1.bttrial.Visible = False
                    Else
                        MsgBox("trial version", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "AL Mohasib")
                    End If
                    Return True
                End Using
            Catch ex As Exception
                Return True
            End Try

        End If
    End Function
    Private Function HandleRegistry2() As Integer
        Dim ALMohasibfirstRunDate As Date
        Dim LastRunDate As Date

        ALMohasibfirstRunDate = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", strKey, Nothing)

        '''''''''''''''''''''''''''''''''''''''''''''       '''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''       '''''''''''''''''''''''''''''''''''''''''''''
        LastRunDate = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", _strLastDate, Nothing)

        Dim sz = (Now - LastRunDate).Days

        'Reglage de date 
        If LastRunDate = Nothing Then
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", _strLastDate, Now.Date)
        ElseIf (Now - LastRunDate).Days <= -1 Then
            'MsgBox("Merci de regler la date de votre PC ..", MsgBoxStyle.Information, "Error_Date")
            'End
        End If

        If CDate(Now) > CDate(LastRunDate) Then My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", _strLastDate, Now.Date)


        '''''''''''''''''''''''''''''''''''''''''''''       '''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''       '''''''''''''''''''''''''''''''''''''''''''''

        'mac adresse
        Dim mac = getMacAddress()
        mac = Regex.Replace(mac, "[^0-9]", "")

        '''''''''''''''''''''''''''''''''''''''''''''       '''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''       '''''''''''''''''''''''''''''''''''''''''''''
        Using a As DataAccess2 = New DataAccess2(My.Settings.ALMohassinDBConnectionString)


            If ALMohasibfirstRunDate = Nothing Then
                ALMohasibfirstRunDate = Now
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", strKey, ALMohasibfirstRunDate)
                Try

                    Dim where As New Dictionary(Of String, Object)
                    where.Add("key", "keypsv")

                    Dim dt = a.SelectDataTable("value", {"*"}, where)

                    Dim val As String = ALMohasibfirstRunDate.Day & ALMohasibfirstRunDate.Hour & "-" & ALMohasibfirstRunDate.Second & "1d5-" & ALMohasibfirstRunDate.ToString("yy") & "2H7" & "-" & mac.ToString.Substring(mac.ToString.Length - 4) & "-" & mac.ToString.Substring(0, 4) & ALMohasibfirstRunDate.Month

                    If dt.Rows.Count > 0 Then

                        Dim params As New Dictionary(Of String, Object)
                        params.Add("val", val)

                        a.UpdateRecord("value", params, where)
                    Else
                        Dim params As New Dictionary(Of String, Object)
                        params.Add("key", "keypsv")
                        params.Add("val", val)
                        a.InsertRecord("value", params)

                    End If
                    where.Clear()
                    where.Add("key", "truefont")
                    Dim dt2 = a.SelectDataTable("value", {"*"}, where)


                    If dt.Rows.Count > 0 Then

                        Dim params As New Dictionary(Of String, Object)
                        params.Add("val", "false")

                        a.UpdateRecord("value", params, where)
                    Else

                        Dim params As New Dictionary(Of String, Object)
                        params.Add("key", "truefont")
                        params.Add("val", "False")
                        a.InsertRecord("value", params)

                    End If

                    MsgBox(strFirstUse)

                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try
                Return 1
            ElseIf (Now - ALMohasibfirstRunDate).Days > nbrDays Then
                Try

                    Dim val As String = ALMohasibfirstRunDate.Day & ALMohasibfirstRunDate.Hour & "-" & ALMohasibfirstRunDate.Second & "1d5-" & ALMohasibfirstRunDate.ToString("yy") & "2H7" & "-" & mac.ToString.Substring(mac.ToString.Length - 4) & "-" & mac.ToString.Substring(0, 4) & ALMohasibfirstRunDate.Month

                    Dim where As New Dictionary(Of String, Object)
                    where.Add("key", "keypsv")

                    Dim dt = a.SelectDataTable("value", {"*"}, where)


                    If dt.Rows.Count > 0 Then

                        If dt.Rows(0).Item("val") <> val Then

                            Dim params As New Dictionary(Of String, Object)
                            params.Add("val", val)

                            a.UpdateRecord("value", params, where)

                            where.Clear()
                            where.Add("key", "truefont")

                            Dim dt2 = a.SelectDataTable("value", {"*"}, where)

                            params.Clear()

                            If dt.Rows.Count > 0 Then
                                params.Add("val", "false")
                                a.UpdateRecord("value", params, where)

                            Else
                                params.Add("key", "truefont")
                                params.Add("val", "false")
                                a.InsertRecord("value", params)

                                MsgBox(strFirstUse)
                            End If

                        Else

                        End If
                    Else

                        Dim params As New Dictionary(Of String, Object)
                        params.Add("key", "keypsv")
                        params.Add("val", val)
                        a.InsertRecord("value", params)

                        params.Clear()
                        where.Clear()

                        where.Add("key", "truefont")
                        Dim dt2 = a.SelectDataTable("value", {"*"}, where)


                        If dt.Rows.Count > 0 Then
                            params.Add("val", val)
                            a.UpdateRecord("value", params, where)

                        Else
                            params.Add("key", "truefont")
                            params.Add("val", "false")
                            a.InsertRecord("value", params)

                        End If
                        MsgBox(strFirstUse)

                    End If
                    '''''''

                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try
                Return 0
            Else

                Try
                    Dim params As New Dictionary(Of String, Object)
                    Dim where As New Dictionary(Of String, Object)

                    where.Clear()

                    where.Add("key", "keypsv")
                    Dim dt = a.SelectDataTable("value", {"*"}, where)

                    Dim val As String = ALMohasibfirstRunDate.Day & ALMohasibfirstRunDate.Hour & "-" & ALMohasibfirstRunDate.Second & "1d5-" & ALMohasibfirstRunDate.ToString("yy") & "2H7" & "-" & mac.ToString.Substring(mac.ToString.Length - 4) & "-" & mac.ToString.Substring(0, 4) & ALMohasibfirstRunDate.Month
                    ''''''
                    If dt.Rows.Count > 0 Then

                        If dt.Rows(0).Item("val") <> val Then

                            params.Add("val", val)
                            a.UpdateRecord("value", params, where)


                            params.Clear()
                            where.Clear()

                            where.Add("key", "truefont")
                            Dim dt2 = a.SelectDataTable("value", {"*"}, where)

                            If dt.Rows.Count > 0 Then
                                params.Add("val", "false")
                                a.UpdateRecord("value", params, where)

                            Else

                                params.Add("key", "truefont")
                                params.Add("val", "false")
                                a.InsertRecord("value", params)

                                MsgBox(strFirstUse)
                            End If

                        Else

                        End If
                    Else
                        params.Clear()
                        params.Add("key", "keypsv")
                        params.Add("val", val)
                        a.InsertRecord("value", params)

                        params.Clear()
                        where.Clear()

                        where.Add("key", "truefont")
                        Dim dt2 = a.SelectDataTable("value", {"*"}, where)


                        If dt.Rows.Count > 0 Then
                            params.Add("val", "false")
                            a.UpdateRecord("value", params, where)

                        Else
                            params.Clear()
                            params.Add("key", "truefont")
                            params.Add("val", "False")
                            a.InsertRecord("value", params)

                        End If
                        MsgBox(strFirstUse)

                    End If
                    '''''''

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                Return 1
            End If
        End Using
    End Function




    ' for slave
    Private Function checktrialSlave() As Boolean

        'Using a As BoundClass = New BoundClass
        '    a.LoadDb()
        '    'a.LoadDb(btDbDv.Tag)
        'End Using

        Dim resultkey As Integer = HandleRegistry()

        Try
            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)


                Dim params As New Dictionary(Of String, Object)
                params.Add("vkey", "truefont")

                Dim dt2 = a.SelectDataTable("value", {"*"}, params)

                If dt2.Rows(0).Item("val") = "true" Then
                    Form1.bttrial.Visible = False
                    Return True
                    Exit Function
                Else
                    If resultkey = 1 Then
                        Return True
                    Else
                        Dim trial As New TrialVersion
                        If trial.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                            Return False
                            Exit Function
                        Else
                            Return True
                            Exit Function
                        End If
                    End If


                End If
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function HandleRegistry() As Integer
        Dim ALMohasibfirstRunDate As Date
        Dim LastRunDate As Date

        Try
            ALMohasibfirstRunDate = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", strKey, Nothing)

        Catch ex As Exception
            ALMohasibfirstRunDate = Now.Date

        End Try

        '''''''''''''''''''''''''''''''''''''''''''''       '''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''       '''''''''''''''''''''''''''''''''''''''''''''
        Try
            LastRunDate = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", _strLastDate, Nothing)

        Catch ex As Exception
            LastRunDate = Now.Date
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", _strLastDate, Now.Date)
        End Try

        Dim sz = (Now - LastRunDate).Days

        'Reglage de date 
        If LastRunDate = Nothing Then
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", _strLastDate, Now.Date)
        ElseIf (Now - LastRunDate).Days <= -1 Then
            'MsgBox("Merci de regler la date de votre PC ..", MsgBoxStyle.Information, "Error_Date")
            'End
        End If

        If CDate(Now) > CDate(LastRunDate) Then My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", _strLastDate, Now.Date)


        '''''''''''''''''''''''''''''''''''''''''''''       '''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''       '''''''''''''''''''''''''''''''''''''''''''''





        If ALMohasibfirstRunDate = Nothing Then
            ALMohasibfirstRunDate = Now
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", strKey, ALMohasibfirstRunDate)

            Return 1
        ElseIf (Now - ALMohasibfirstRunDate).Days > nbrDays Then
            Return 0
        Else
            Return 1
        End If

    End Function

    Function getMacAddress()
        Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()
        Return nics(1).GetPhysicalAddress.ToString
    End Function

End Module

Public Class BoundClass
    Implements IDisposable
    Private _PathDocs As String
    Private _DbPath As String
    Private _PathBoundDb As String

    Public Sub New()
        _PathDocs = Form1.ImgPah
        _DbPath = GetDatabaseName()
        _PathBoundDb = Form1.BtBoundDbPath.Tag
    End Sub

    Public Function SaveNewChangement(ByVal CaseType As String, ByVal tableName As String,
                                      ByVal params As Dictionary(Of String, Object),
                                      Optional ByVal where As Dictionary(Of String, Object) = Nothing) As Boolean

        Try
            Dim TextLine As String = CaseType & "|" & tableName & "|"
            If params IsNot Nothing Then
                For Each kvp As KeyValuePair(Of String, Object) In params
                    TextLine &= kvp.Key & "_" & kvp.Value & "_"
                Next
                TextLine = TextLine.Substring(0, TextLine.Length - 1)
            End If

            If where IsNot Nothing Then
                TextLine &= "|"
                For Each kvp As KeyValuePair(Of String, Object) In where
                    TextLine &= kvp.Key & "_" & kvp.Value & "_"
                Next
                TextLine = TextLine.Substring(0, TextLine.Length - 1)
            End If

            Dim file As System.IO.StreamWriter
            Dim FILE_NAME As String = _PathDocs & "\Docs\Sv_New_Ch.dat"
            file = My.Computer.FileSystem.OpenTextFileWriter(FILE_NAME, True)
            file.WriteLine(TextLine)
            file.Close()

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function LoadNewChangement() As Boolean
        Try
            Dim FILE_NAME As String = _PathDocs & "\Docs\Sv_New_Ch.dat"
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                If System.IO.File.Exists(FILE_NAME) = True Then
                    Dim objReader As New System.IO.StreamReader(FILE_NAME)
                    Do While objReader.Peek() <> -1
                        Dim TextLine As String() = CStr(objReader.ReadLine()).Split("|")
                        Dim tableName As String = CStr(TextLine(1))
                        Dim params As New Dictionary(Of String, Object)
                        Dim where As New Dictionary(Of String, Object)

                        Dim param As String() = CStr(TextLine(2)).Split("_")
                        For i As Integer = 0 To param.Length - 1 Step 2
                            params.Add(param(i), param(i + 1))
                        Next

                        If TextLine.Length > 3 Then
                            Dim wher As String() = CStr(TextLine(3)).Split("_")
                            For i As Integer = 0 To param.Length - 1 Step 2
                                where.Add(wher(i), wher(i + 1))
                            Next
                        End If

                        Select Case TextLine(0)
                            Case "insert"
                                c.InsertRecord(tableName, params)
                            Case "update"
                                'Try
                                '    Dim dt = c.SelectDataTable(tableName, {"*"}, where)
                                '    If dt.Rows.Count > 0 Then
                                '        c.UpdateRecord(tableName, params, where)
                                '    End If
                                'Catch ex As Exception
                                'End Try
                                c.UpdateRecord(tableName, params, where)
                            Case "delete"
                                c.DeleteRecords(tableName, params)
                        End Select
                    Loop
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function LoadDb() As Boolean
        Try
            If File.Exists(_PathBoundDb) Then
                File.Copy(_PathBoundDb, _DbPath, True)
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Sub ChangeConnectionString()
        Try

            Dim _ldbfile As String = _PathBoundDb.Replace("mdb", "ldb")
            If File.Exists(_ldbfile) Then
                MsgBox("يوجد حاجز للربط بقاعدة البيانات المشتركة")
                Exit Sub
            End If


            Dim lcConnString = My.Settings.ALMohassinDBConnectionString
            lcConnString = lcConnString.ToLower

            ' if this is a Jet database, find the index of the "data source" setting
            Dim startIndex As Integer
            If lcConnString.IndexOf("jet.oledb") > -1 Then
                startIndex = lcConnString.IndexOf("data source=")
                If startIndex > -1 Then startIndex += 12
            Else
                ' if this is a SQL Server database, find the index of the "initial 
                ' catalog" or "database" setting
                startIndex = lcConnString.IndexOf("initial catalog=")
                If startIndex > -1 Then
                    startIndex += 16
                Else ' if the "Initial Catalog" setting is not found,
                    '  try with "Database"
                    startIndex = lcConnString.IndexOf("database=")
                    If startIndex > -1 Then startIndex += 9
                End If
            End If

            ' if the "database", "data source" or "initial catalog" values are not 
            ' found, return an empty string
            If startIndex = -1 Then Exit Sub

            ' find where the database name/path ends
            Dim endIndex As Integer = lcConnString.IndexOf(";", startIndex)
            If endIndex = -1 Then endIndex = lcConnString.Length

            ' return the substring with the database name/path
            Dim oldchar As String = lcConnString.Substring(startIndex, endIndex - startIndex)

            lcConnString = lcConnString.Replace(oldchar, _PathBoundDb)

            My.Settings.Item("ALMohassinDBConnectionString") = lcConnString
        Catch ex As Exception

        End Try
    End Sub

    Function GetDatabaseName() As String
        Dim lcConnString = My.Settings.ALMohassinDBConnectionString
        lcConnString = lcConnString.ToLower

        ' if this is a Jet database, find the index of the "data source" setting
        Dim startIndex As Integer
        If lcConnString.IndexOf("jet.oledb") > -1 Then
            startIndex = lcConnString.IndexOf("data source=")
            If startIndex > -1 Then startIndex += 12
        Else
            ' if this is a SQL Server database, find the index of the "initial 
            ' catalog" or "database" setting
            startIndex = lcConnString.IndexOf("initial catalog=")
            If startIndex > -1 Then
                startIndex += 16
            Else ' if the "Initial Catalog" setting is not found,
                '  try with "Database"
                startIndex = lcConnString.IndexOf("database=")
                If startIndex > -1 Then startIndex += 9
            End If
        End If

        ' if the "database", "data source" or "initial catalog" values are not 
        ' found, return an empty string
        If startIndex = -1 Then Return ""

        ' find where the database name/path ends
        Dim endIndex As Integer = lcConnString.IndexOf(";", startIndex)
        If endIndex = -1 Then endIndex = lcConnString.Length

        ' return the substring with the database name/path
        Return lcConnString.Substring(startIndex, endIndex - startIndex)
    End Function

    Public Function LoadDbToDrive(ByVal P As String) As Boolean
        Try
            'If File.Exists(P) Then
            Dim a = _DbPath.Replace("|datadirectory|\", "")
            File.Copy(a, P, True)
            'End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

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