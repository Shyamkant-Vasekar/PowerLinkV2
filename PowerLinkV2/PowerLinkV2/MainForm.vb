' ****************************************************************************
'   MainForm.vb
' 
'   Copyright 2020 EngineersKatta
' 
'   This file is part of PowerLinkV2.
' 
'   PowerLinkV2 is free software: you can redistribute it and/or modify
'   it under the terms of the GNU General Public License as published by
'   the Free Software Foundation, either version 3 of the License, or
'   (at your option) any later version.
' 
'   PowerLinkV2 is distributed in the hope that it will be useful,
'   but WITHOUT ANY WARRANTY; without even the implied warranty of
'   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'   GNU General Public License for more details.
' 
'   You should have received a copy of the GNU General Public License
'   along with PowerLinkV2. If not, see <http://www.gnu.org/licenses/>.
' 
'   See COPYING file for the complete license text.



'*******************************************************************************
'   Modbus TCP, Modbus UDP and Modbus RTU client/server library

'   Copyright (c) 2018-2020 Rossmann-Engineering 

'   Permission is hereby granted, free of charge, to any person obtaining a copy 
'   of this software and associated documentation files (the "Software"), to deal
'   in the Software without restriction, including without limitation the rights 
'   to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
'   copies of the Software, and to permit persons to whom the Software is 
'   furnished to do so, subject to the following conditions:

'   The above copyright notice and this permission notice shall be included in 
'   all copies or substantial portions of the Software.

'   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
'   IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
'   FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
'   THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
'   LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
'   FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
'   DEALINGS IN THE SOFTWARE.

Imports EasyModbus.ModbusClient
Imports Mfm.GeneralMfm
Imports System.Runtime.InteropServices 'For extracting icons from Shell.dll
Imports System.Data.SqlClient
Imports CheckNetClass

Public Class MainForm
    Dim MyModbusClient As EasyModbus.ModbusClient
    Public ThisMfm As Mfm.GeneralMfm 'For using with context menu

    Dim INTERRUPTED As Boolean

    'For logging hourly
    Dim PreWebWrittenHr As Integer
    Dim StopWatchForMonitoringUploadInterval As New Stopwatch
    Dim UploadInterval As Long

    Dim dragging As Boolean
    Dim ClickX As Integer
    Dim ClickY As Integer

    'For informing which procedure being set 
    'from PropertyPage form to SetProcedure form
    Public SET_PROCEDURE_FOR As String = ""

    'For local remote synchronization
    Public PwrDataSetL As DataSet
    Public PwrDataTableL As DataTable
    Public PwrDataAdapterL As SQLiteDataAdapter
    Public ConStrL As String = "Data Source=C:\ProgramData\PowerLinkV2\PowerLinkV2.mplx;Version=3" '"Data Source=C:\ProgramData\PowerLinkV2\PowerLinkV2.mplx;Version=3"
    'Public ConStrL As String = "Data Source=PowerLinkV2.mplx;Version=3" '"Data Source=C:\ProgramData\PowerLinkV2\PowerLinkV2.mplx;Version=3"
    Public conL As SQLiteConnection

    Public PwrDataSetR As DataSet
    Public PwrDataTableR As DataTable
    Public PwrDataAdapterR As SqlDataAdapter
    Public ConStrR As String = "Data Source=148.72.232.168;Integrated Security=False;User ID=spvasekar; Password=Mydatabasepassword#1"
    Public conR As SqlConnection


    'For allowing restricted clossing
    Public CloseOperationCanceled As Boolean

    'For checking internet availability
    Dim NetworkAvailable As Boolean = True 'Start application after confirming internet availability
    'Otherwise it will not update unless on-off for the connection

    'For controled clossing
    Public ClosedByUser As Boolean = False

    'For Displaying Voltages
    Public UidBus1Kv As Int16
    Public UidBus2Kv As Int16

    '====================================================================================================
    'FOR ADDING RUN TIME CONTROLS TO DRAG DROP METHOD
    '====================================================================================================
    Public Sub MouseDownSettingSingleControl(ByVal ctr As Control)
        AddHandler ctr.MouseDown, AddressOf Me.MouseDownHandling
    End Sub
    Public Sub MouseMoveSettingSingleControl(ByVal ctr As Control)
        AddHandler ctr.MouseMove, AddressOf Me.MouseMoveHandling
    End Sub
    Public Sub MouseUpSettingSingleControl(ByVal ctr As Control)
        AddHandler ctr.MouseUp, AddressOf Me.MouseUpHandling
    End Sub

    Private Sub DoNetworkAvailabilityStatusChanges(ByVal sender As Object, ByVal e As NetworkStatusChangedArgs)
        If CheckNetClass.NetworkStatus.IsAvailable Then
            NetworkAvailable = True
        Else
            NetworkAvailable = False
        End If
    End Sub

    '=========================================================================================
    'Standard dragging code
    Private Sub MouseDownHandling(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        dragging = True
        ClickX = e.X
        ClickY = e.Y
    End Sub
    Private Sub MouseMoveHandling(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If dragging = True Then
            sender.Left = sender.Left + e.X - ClickX
            sender.Top = sender.Top + e.Y - ClickY
        End If
    End Sub
    Private Sub MouseUpHandling(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        dragging = False
    End Sub
    '=============================================================================================

    Private Sub CmdRun_Click(sender As Object, e As EventArgs) Handles CmdRun.Click

        MsgBox("1. At start of the application INTERNET AVAILABILITY STATUS to be informed manually." & vbCrLf & _
               "2. After start of the application INTERNET AVAILABILITY STATUS get communicated to application upon its change." & vbCrLf & _
               "3. The application PowerLinkV2 checkes INTERNET AVAILABILITY STATUS after every 3 minute and displays on tool bar." & vbCrLf & _
               "4. If internet is available uploads current data and any pending data.", MsgBoxStyle.Information)

        If MsgBox("Is internet available?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            CmdEdit.Enabled = True
            CmdRun.Enabled = False
            CmdConnect.Enabled = False
            INTERRUPTED = False
            TimerPolling.Enabled = True     'DevRem: 19/02/20 instead of loop timer is used as previous 
            'Wait(15000) 'REVIEW NEEDED TIME TO ALL METER POLLING
            'TimerWebUpdate.Enabled = True
            TimerPolling_Tick(sender, e)
        End If

    End Sub

    Private Sub CmdEdit_Click(sender As Object, e As EventArgs) Handles CmdEdit.Click
        TimerPolling.Enabled = False
        'TimerWebUpdate.Enabled = False
        StopPolling()   'Explicit required otherwise all meters doesnot stops
        INTERRUPTED = True
        CmdEdit.Enabled = False
        CmdRun.Enabled = True
        CmdConnect.Enabled = True
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing


        If Not ClosedByUser Then
            MsgBox("Please use 'Close' button", MsgBoxStyle.Exclamation)
            e.Cancel = True
        Else

            'Save work done uptill now      'Eachtime not necessary we will try for changes made falg 
            SaveAllMfm()

            'Windup
            DestroyAllIcons()
        End If
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Me.Text = "PowerLinkV" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision & " : New Substation"


            LoadAllMfm()


            CmbBaud.SelectedIndex = My.Settings.LastBaudRateSelNdx
            CmbPort.SelectedIndex = My.Settings.LastPortSelNdx
            SetPollingTime(My.Settings.LastPollingTimeSelNdx)
            SetWebUploadTime(My.Settings.LastWebUpdateTimeSelNdx)
            UidBus1Kv = My.Settings.UnitIdBus1Kv
            UidBus2Kv = My.Settings.UnitIdBus2Kv

            'For local and remote database update
            MakeLocalResources()
            MakeRemoteResources()

            Dim PendingRec As Integer = RecordsPending()
            StsLblPendingRecords.Text = Format(PendingRec, "000")

            AssignIcons()
            TryInitiation()
            If MyModbusClient IsNot Nothing Then
                CmdConnect.Enabled = True
            End If

            AddHandler NetworkStatus.AvailabilityChanged, AddressOf Me.DoNetworkAvailabilityStatusChanges

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    Private Sub TimerPolling_Tick(sender As Object, e As EventArgs) Handles TimerPolling.Tick

        Application.DoEvents()
        Dim Cntrl As Control
        For Each Cntrl In Me.Controls
            If TypeOf (Cntrl) Is Mfm.GeneralMfm Then
                Dim x As Mfm.GeneralMfm
                x = Cntrl
                x.ReadData(MyModbusClient)

                'Refresh kV Display
                If x.ID = UidBus1Kv Then
                    lblBus1Kv.Text = Format(x.VL, "000.00")
                End If
                If x.ID = UidBus2Kv Then
                    lblBus2Kv.Text = Format(x.VL, "000.00")
                End If

            End If
        Next
        StsLblLastRefresh.Text = Format(Now(), "HH:mm:ss")
        'TimerWebUpdate_Tick(sender, e)

        'Display Internet Status
        If NetworkAvailable Then
            CmdNetSts.Enabled = True
        Else
            CmdNetSts.Enabled = False
        End If




        'Copied from TimerWebUpdate_Tick
        'For status display
        Dim PendingRec As Integer
        Dim NowUploaded As Integer
        Dim NowUploadTm As Date

        '//////////////////////////////////////////////////////////////////////////////////
        '            Stage-1 Save to local data base once upload interval time over
        If (IsDesiredTimeLapsed(UploadInterval) And IsTimeNowMinAreDivisibleBy(UploadInterval)) Then
            RestartUploadTimeLapsedMeasurement()
            LblWebTick.Text = Format(Now(), "HH:mm")
            Application.DoEvents()
            'MsgBox("Web")

            'Dim Cntrl As Control

            'If new hour started and lapsed time is less than 5 minutes then
            'Hourly FIRST transfer data to local data set'
            'If (PreWebWrittenHr <> Now.Hour And (Now.Minute < 12)) Then
            'If True Then
            For Each Cntrl In Me.Controls
                If TypeOf (Cntrl) Is Mfm.GeneralMfm Then
                    Dim x As Mfm.GeneralMfm
                    x = Cntrl
                    If x.Connected Then
                        CreateDataRowInLocalDataset(x)
                        Try
                            PwrDataAdapterL.Update(PwrDataSetL) 'Inserted record from memory to local db file
                        Catch ex As Exception
                            'MsgBox(ex.Message)
                        End Try
                    End If
                End If
            Next
            PreWebWrittenHr = Now.Hour  'All Mfm Logging completed for this hour
        End If


        '//////////////////////////////////////////////////////////////////////////
        '     Stage-2 THEN Try to update to remote in each polling instance if record is pending and network is available
        PendingRec = RecordsPending()
        If NetworkAvailable And PendingRec > 0 Then
            Try
                PwrDataSetL.Tables("MfmData000").Clear()    'Clear previous data if any
                PwrDataSetR.Tables("MfmData020").Clear()
                PwrDataAdapterL.Fill(PwrDataSetL)           'Load local data set with un-uploaded data if any
                TransferDataFromLocalToRemoteDataSet()      'Transfer that data to remote data set
                NowUploaded = PwrDataAdapterR.Update(PwrDataSetR)         'Upload the data
                'MsgBox(NowUploaded.ToString)
                'PwrDataAdapterR.Fill(PwrDataSetR)          'Read JUST NOW uploaded data THIS WAS CULPRIT IN 2.1.0.3
                If NowUploaded = PwrDataSetL.Tables("MfmData000").Rows.Count Then
                    ModifyUploadedStatus()                      'Modify uploaded status in local data set
                    PwrDataAdapterL.Update(PwrDataSetL)         'Write uploaded status to local db file
                    NowUploadTm = Now()
                Else
                    GoTo DontTry
                End If
            Catch ex As Exception
                'To display as previous if not change during this upload 
                NowUploaded = CInt(StsLblRecUplodaed.Text)
                NowUploadTm = CDate(StsLblLastUploadDtTm.Text)
                MsgBox(ex.Message)
            End Try
        Else
            'To display as previous if not change during this upload 
            NowUploaded = CInt(StsLblRecUplodaed.Text)
            NowUploadTm = CDate(StsLblLastUploadDtTm.Text)
        End If

DontTry:
        PendingRec = RecordsPending()
        StsLblLastUploadDtTm.Text = Format(NowUploadTm, "dd/MM/yy HH:mm")
        StsLblPendingRecords.Text = Format(PendingRec, "000")
        StsLblRecUplodaed.Text = Format(NowUploaded, "000")




    End Sub

    Private Sub Wait(ByVal interval As Integer)
        Dim sw As New Stopwatch
        sw.Start()
        Do While sw.ElapsedMilliseconds < interval
            ' Allows UI to remain responsive
            Application.DoEvents()
        Loop
        sw.Stop()
    End Sub

    'Timer to write on web tries after every 3 minutes and if one hour passed writes
    '***************************************************************************************
    '       NOTE: CALLED THROUGH TimerPolling_Tick even after every  3 seconds
    '***************************************************************************************
    Private Sub TimerWebUpdate_Tick(sender As Object, e As EventArgs) Handles TimerWebUpdate.Tick



        '        LblWebTick.Text = Format(Now(), "HH:mm")
        '        Application.DoEvents()
        '        'MsgBox("Web")
        '        'For status display
        '        Dim PendingRec As Integer
        '        Dim NowUploaded As Integer
        '        Dim NowUploadTm As Date
        '        Dim Cntrl As Control

        '        'If new hour started and lapsed time is less than 5 minutes then
        '        'Hourly FIRST transfer data to local data set'
        '        'If (PreWebWrittenHr <> Now.Hour And (Now.Minute < 12)) Then
        '        If True Then
        '            For Each Cntrl In Me.Controls
        '                If TypeOf (Cntrl) Is Mfm.GeneralMfm Then
        '                    Dim x As Mfm.GeneralMfm
        '                    x = Cntrl
        '                    If x.Connected Then
        '                        CreateDataRowInLocalDataset(x)
        '                        Try
        '                            PwrDataAdapterL.Update(PwrDataSetL) 'Inserted record from memory to local db file
        '                        Catch ex As Exception
        '                            'MsgBox(ex.Message)
        '                        End Try
        '                    End If
        '                End If
        '            Next
        '            PreWebWrittenHr = Now.Hour  'All Mfm Logging completed for this hour
        '        End If


        '        'THEN Try to update to remote
        '        PendingRec = RecordsPending()
        '        If NetworkAvailable And PendingRec > 0 Then
        '            Try
        '                PwrDataSetL.Tables("MfmData000").Clear()    'Clear previous data if any
        '                PwrDataSetR.Tables("MfmData020").Clear()
        '                PwrDataAdapterL.Fill(PwrDataSetL)           'Load local data set with un-uploaded data if any
        '                TransferDataFromLocalToRemoteDataSet()      'Transfer that data to remote data set
        '                NowUploaded = PwrDataAdapterR.Update(PwrDataSetR)         'Upload the data
        '                PwrDataAdapterR.Fill(PwrDataSetR)          'Read JUST NOW uploaded data
        '                If NowUploaded = PwrDataSetL.Tables("MfmData000").Rows.Count Then
        '                    ModifyUploadedStatus()                      'Modify uploaded status in local data set
        '                    PwrDataAdapterL.Update(PwrDataSetL)         'Write uploaded status to local db file
        '                    NowUploadTm = Now()
        '                Else
        '                    GoTo DontTry
        '                End If
        '            Catch ex As Exception
        '                'To display as previous if not change during this upload 
        '                NowUploaded = CInt(StsLblRecUplodaed.Text)
        '                NowUploadTm = CDate(StsLblLastUploadDtTm.Text)
        '                'MsgBox(ex.Message)
        '            End Try
        '        Else
        '            'To display as previous if not change during this upload 
        '            NowUploaded = CInt(StsLblRecUplodaed.Text)
        '            NowUploadTm = CDate(StsLblLastUploadDtTm.Text)
        '        End If

        'DontTry:
        '        PendingRec = RecordsPending()
        '        StsLblLastUploadDtTm.Text = Format(NowUploadTm, "dd/MM/yy HH:mm")
        '        StsLblPendingRecords.Text = Format(PendingRec, "000")
        '        StsLblRecUplodaed.Text = Format(NowUploaded, "000")




    End Sub

    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    '               CODE TO SAVE APPLICATION SETTINGS AFTER EACH CHANGE OF BAUD RATE, COM PORT AND POLLING TIMER INTERVAL
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub CmbPort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbPort.SelectedIndexChanged
        My.Settings.LastPortSelNdx = CmbPort.SelectedIndex
    End Sub

    Private Sub CmbBaud_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBaud.SelectedIndexChanged
        My.Settings.LastBaudRateSelNdx = CmbBaud.SelectedIndex
    End Sub
    Private Sub CmbPollingTimer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbPollingTimer.SelectedIndexChanged

        SetPollingTime(CmbPollingTimer.SelectedIndex)
    End Sub
    Private Sub TryInitiation()
        Try
            MyModbusClient = New EasyModbus.ModbusClient(CStr(CmbPort.SelectedItem))
            MyModbusClient.Baudrate = CInt(CmbBaud.SelectedItem)
            MyModbusClient.Parity = IO.Ports.Parity.None
            MyModbusClient.StopBits = IO.Ports.StopBits.One
            MsgBox("Master Initiation Successfull!" & vbCrLf & "Set connection time out: " & MyModbusClient.ConnectionTimeout.ToString, MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub TryConnection()
        MyModbusClient.Baudrate = CInt(CmbBaud.SelectedItem)
        MyModbusClient.SerialPort = CStr(CmbPort.SelectedItem)
        Try
            MyModbusClient.Connect()
            CmdConnected.Enabled = True
            CmdRun.Enabled = True
            CmdEdit.Enabled = False
            CmdAdd.Enabled = False
            MsgBox("Connection made", MsgBoxStyle.Information)
        Catch ex As EasyModbus.Exceptions.SerialPortNotOpenedException
            MsgBox("SerialPortNotOpenedException: " & ex.Message, MsgBoxStyle.Exclamation)
            CmdConnected.Enabled = False
        Catch ex1 As EasyModbus.Exceptions.ConnectionException
            MsgBox("ConnectionException: " & ex1.Message, MsgBoxStyle.Exclamation)
            CmdConnected.Enabled = False
        Catch ex2 As Exception
            MsgBox("Unknown Error: " & ex2.Message, MsgBoxStyle.Exclamation)
            CmdConnected.Enabled = False
        End Try

    End Sub


    '////////////////////////////////////////////////////////////////////////////////////////////////
    '               CODE FOR ASSIGNING ICONS TO TOOLBOX BUTTON
    '////////////////////////////////////////////////////////////////////////////////////////////////

    'Win API to extract icon from Shell.dll
    <DllImport("shell32.dll", EntryPoint:="ExtractAssociatedIconW", CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function MyIconExtractor(ByVal hInst As IntPtr, <MarshalAs(UnmanagedType.LPWStr)> ByVal lpIconPath As String, ByRef lpiIcon As UShort) As IntPtr
    End Function
    <DllImport("user32.dll", EntryPoint:="DestroyIcon")>
    Public Shared Function MyIconDestroyer(ByVal hIcon As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    'Icons for button needed to be decleared here because at end we have to destroy it
    Dim btnConnectedIcon As Icon = GetSystemIcon(18)
    Dim btnStopIcon As Icon = GetSystemIcon(27)  'To be used as Stop Icon
    Dim btnRunIcon As Icon = GetSystemIcon(137) 'To be used as start icon
    Dim btnInternetIcon As Icon = GetSystemIcon(135)    'To be used for indicating internet connection status

    'Fxn to extract Shell.dll icon to be used in ribbon
    Private Function GetSystemIcon(ByVal indx As UShort) As Icon
        Dim Shell32dllPath As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "Shell32.dll")
        Return Icon.FromHandle(MyIconExtractor(IntPtr.Zero, Shell32dllPath, indx))
    End Function

    Private Sub AssignIcons()
        CmdRun.Image = btnRunIcon.ToBitmap
        CmdEdit.Image = btnStopIcon.ToBitmap
        'CmdConnected.Image = btnConnectedIcon.ToBitmap
        CmdConnected.Image = My.Resources.MyMfmSsAppIco2
        CmdNetSts.Image = btnInternetIcon.ToBitmap
    End Sub

    Private Sub DestroyAllIcons()
        MyIconDestroyer(btnRunIcon.Handle)
        MyIconDestroyer(btnStopIcon.Handle)
        MyIconDestroyer(btnConnectedIcon.Handle)
        MyIconDestroyer(btnInternetIcon.Handle)
    End Sub

    Private Sub CmdConnect_Click(sender As Object, e As EventArgs) Handles CmdConnect.Click
        If CmdConnect.Text = "Connect" Then
            TryConnection()
            If CmdConnected.Enabled = True Then 'That means connection done
                CmdConnect.Text = "Disconnect"
                CmbPollingTimer.Enabled = False
                CmbWebUploadTimer.Enabled = False
                CmbPort.Enabled = False
                CmbBaud.Enabled = False
                CmdConnect.BackColor = SystemColors.GradientActiveCaption
            End If
        Else
            Try
                MyModbusClient.Disconnect()
            Catch ex1 As EasyModbus.Exceptions.ConnectionException
                MsgBox("EasyModbus Connection Exception:" & vbCrLf & ex1.Message)
            Catch ex2 As EasyModbus.Exceptions.SerialPortNotOpenedException
                MsgBox("EasyModbus Communication Port Exception:" & vbCrLf & ex2.Message)
            Catch ex As Exception

            End Try
            CmdAdd.Enabled = True
            CmdRun.Enabled = False
            CmdEdit.Enabled = False
            TimerPolling.Enabled = False
            'TimerWebUpdate.Enabled = False
            CmdConnected.Enabled = False
            CmbPollingTimer.Enabled = True
            CmbWebUploadTimer.Enabled = True
            CmbPort.Enabled = True
            CmbBaud.Enabled = True
            StopPolling()
            CmdConnect.Text = "Connect"
            CmdConnect.BackColor = SystemColors.Highlight
        End If
    End Sub
    Private Sub StopPolling()
        Dim Cntrl As Control
        For Each Cntrl In Me.Controls
            If TypeOf (Cntrl) Is Mfm.GeneralMfm Then
                Dim x As Mfm.GeneralMfm
                x = Cntrl
                x.StopPolling()
            End If
        Next
    End Sub

    'ADD METER MENU CLICK
    '==========================================================================================================
    Private Sub CmdAddAcord_Click(sender As Object, e As EventArgs) Handles CmdAddAcord.Click
        Dim AcordX As New Mfm.GeneralMfm
        AcordX.Left = 100
        AcordX.Top = 100
        SetAcordMeterProperties(AcordX)
        Me.Controls.Add(AcordX)
        AcordX.ContextMenuStrip = ContextMenuStrip1
        AcordX.BringToFront()
        MouseDownSettingSingleControl(AcordX)
        MouseMoveSettingSingleControl(AcordX)
        MouseUpSettingSingleControl(AcordX)
    End Sub

    Private Sub CmdAddSecureElite_Click(sender As Object, e As EventArgs) Handles CmdAddSecureElite.Click
        Dim SecureX As New Mfm.GeneralMfm
        SecureX.Left = 100
        SecureX.Top = 100
        SetSecureMeterProperties(SecureX)
        Me.Controls.Add(SecureX)
        SecureX.ContextMenuStrip = ContextMenuStrip1
        SecureX.BringToFront()
        MouseDownSettingSingleControl(SecureX)
        MouseMoveSettingSingleControl(SecureX)
        MouseUpSettingSingleControl(SecureX)
    End Sub

    Private Sub CmdAddCustom_Click(sender As Object, e As EventArgs) Handles CmdAddCustom.Click
        Dim CustomX As New Mfm.GeneralMfm
        CustomX.Left = 100
        CustomX.Top = 100
        SetCustomMeterProperties(CustomX)
        Me.Controls.Add(CustomX)
        CustomX.ContextMenuStrip = ContextMenuStrip1
        CustomX.BringToFront()
        MouseDownSettingSingleControl(CustomX)
        MouseMoveSettingSingleControl(CustomX)
        MouseUpSettingSingleControl(CustomX)
    End Sub

    'CONTEXT MENU ITEM SUBROUTINES
    '=============================================================================================================
    Private Sub SetIdTSMI_Click(sender As Object, e As EventArgs) Handles SetIdTSMI.Click
        Dim ThisMeter As Mfm.GeneralMfm
        Me.TopMost = False
        ThisMeter = ContextMenuStrip1.SourceControl
        ThisMeter.ID = InputBox("Enter new ID", , ThisMeter.ID)
        'Me.TopMost = True
    End Sub

    Private Sub SetBayIdTSMI_Click(sender As Object, e As EventArgs) Handles SetBayIdTSMI.Click
        Dim ThisMeter As Mfm.GeneralMfm
        Me.TopMost = False
        ThisMeter = ContextMenuStrip1.SourceControl
        ThisMeter.SrNo = InputBox("Enter Bay ID", , ThisMeter.SrNo)
        'Me.TopMost = True
    End Sub

    Private Sub SetBayNameTSMI_Click(sender As Object, e As EventArgs) Handles SetBayNameTSMI.Click
        Dim ThisMeter As Mfm.GeneralMfm
        Me.TopMost = False
        ThisMeter = ContextMenuStrip1.SourceControl
        ThisMeter.Bay = InputBox("Enter Bay Name", , ThisMeter.Bay)
        'Me.TopMost = True
    End Sub

    Private Sub SetColorTSMI_Click(sender As Object, e As EventArgs) Handles SetColorTSMI.Click
        Dim ThisMeter As Mfm.GeneralMfm
        Me.TopMost = False
        ThisMeter = ContextMenuStrip1.SourceControl
        ColorDialog1.ShowDialog()
        ThisMeter.BackColor = ColorDialog1.Color
        'Me.TopMost = True
    End Sub

    Private Sub DeleteTSMI_Click(sender As Object, e As EventArgs) Handles DeleteTSMI.Click
        Dim ThisMeter As Mfm.GeneralMfm
        Me.TopMost = False
        ThisMeter = ContextMenuStrip1.SourceControl
        Me.Controls.Remove(ThisMeter)
        'Me.TopMost = True
    End Sub

    Private Sub SetModbusPropertiesTSMI_Click(sender As Object, e As EventArgs) Handles SetModbusPropertiesTSMI.Click
        Me.TopMost = False
        ThisMfm = ContextMenuStrip1.SourceControl

        'General
        MyPropertyPage.RdbHolding.Checked = ThisMfm.ReadHoldingReg
        MyPropertyPage.RdbInput.Checked = Not ThisMfm.ReadHoldingReg

        'Read previous addresses
        MyPropertyPage.TxtRCurAdrs.Text = ThisMfm.AdrsIR.ToString
        MyPropertyPage.TxtYCurAdrs.Text = ThisMfm.AdrsIY.ToString
        MyPropertyPage.TxtBCurAdrs.Text = ThisMfm.AdrsIB.ToString
        MyPropertyPage.TxtAdrsMw.Text = ThisMfm.AdrsMw.ToString
        MyPropertyPage.TxtAdrsMvar.Text = ThisMfm.AdrsMvar.ToString
        MyPropertyPage.TxtAdrsMwhI.Text = ThisMfm.AdrsMwhI.ToString
        MyPropertyPage.TxtAdrsMwhE.Text = ThisMfm.AdrsMwhE.ToString
        MyPropertyPage.TxtAdrsPf.Text = ThisMfm.AdrsPf.ToString
        MyPropertyPage.TxtAdrsVL.Text = ThisMfm.AdrsVL.ToString


        'Read previous data types
        MyPropertyPage.CmbVerTypeIPh.SelectedIndex = ThisMfm.VerTypeIPh  'Combo index zero based enum zero based 
        MyPropertyPage.CmbVerTypeMw.SelectedIndex = ThisMfm.VerTypeMw
        MyPropertyPage.CmbVerTypeMvar.SelectedIndex = ThisMfm.VerTypeMvar
        MyPropertyPage.CmbVerTypeMwhI.SelectedIndex = ThisMfm.VerTypeMwhI
        MyPropertyPage.CmbVerTypeMwhE.SelectedIndex = ThisMfm.VerTypeMwhE
        MyPropertyPage.CmbVerTypePf.SelectedIndex = ThisMfm.VerTypePf
        MyPropertyPage.CmbVerTypeVL.SelectedIndex = ThisMfm.VerTypeVL


        'Read previous scales
        MyPropertyPage.TxtScaleIPh.Text = ThisMfm.ScaleIPh.ToString
        MyPropertyPage.TxtScaleMw.Text = ThisMfm.ScaleMw.ToString
        MyPropertyPage.TxtScaleMvar.Text = ThisMfm.ScaleMvar.ToString
        MyPropertyPage.TxtScaleMwhI.Text = ThisMfm.ScaleMwhI.ToString
        MyPropertyPage.TxtScaleMwhE.Text = ThisMfm.ScaleMwhE.ToString
        MyPropertyPage.TxtScalePf.Text = ThisMfm.ScalePf.ToString
        MyPropertyPage.TxtScaleVL.Text = ThisMfm.ScaleVL.ToString

        'Read bay name and meter make
        MyPropertyPage.LblBay.Text = ThisMfm.Bay
        MyPropertyPage.LblMake.Text = ThisMfm.Make

        If MyPropertyPage.LblMake.Text = "Custom" Then

            'General
            MyPropertyPage.RdbHolding.Enabled = True
            MyPropertyPage.RdbInput.Enabled = True

            'Make Addresses editable
            MyPropertyPage.TxtRCurAdrs.Enabled = True
            MyPropertyPage.TxtYCurAdrs.Enabled = True
            MyPropertyPage.TxtBCurAdrs.Enabled = True
            MyPropertyPage.TxtAdrsMw.Enabled = True
            MyPropertyPage.TxtAdrsMvar.Enabled = True
            MyPropertyPage.TxtAdrsMwhI.Enabled = True
            MyPropertyPage.TxtAdrsMwhE.Enabled = True
            MyPropertyPage.TxtAdrsPf.Enabled = True
            MyPropertyPage.TxtAdrsVL.Enabled = True

            'Make variable type editable
            MyPropertyPage.CmbVerTypeIPh.Enabled = True
            MyPropertyPage.CmbVerTypeMw.Enabled = True
            MyPropertyPage.CmbVerTypeMvar.Enabled = True
            MyPropertyPage.CmbVerTypeMwhI.Enabled = True
            MyPropertyPage.CmbVerTypeMwhE.Enabled = True
            MyPropertyPage.CmbVerTypePf.Enabled = True
            MyPropertyPage.CmbVerTypeVL.Enabled = True

            'Make variable type editable
            MyPropertyPage.TxtScaleIPh.Enabled = True
            MyPropertyPage.TxtScaleMw.Enabled = True
            MyPropertyPage.TxtScaleMvar.Enabled = True
            MyPropertyPage.TxtScaleMwhI.Enabled = True
            MyPropertyPage.TxtScaleMwhE.Enabled = True
            MyPropertyPage.TxtScalePf.Enabled = True
            MyPropertyPage.TxtScaleVL.Enabled = True

            ''Make Procedures editable
            SetProcedure.TxtFxn.Enabled = True

        Else

            'General
            MyPropertyPage.RdbHolding.Enabled = False
            MyPropertyPage.RdbInput.Enabled = False

            'Make Addresses Non-editable
            MyPropertyPage.TxtRCurAdrs.Enabled = False
            MyPropertyPage.TxtYCurAdrs.Enabled = False
            MyPropertyPage.TxtBCurAdrs.Enabled = False
            MyPropertyPage.TxtAdrsMw.Enabled = False
            MyPropertyPage.TxtAdrsMvar.Enabled = False
            MyPropertyPage.TxtAdrsMwhI.Enabled = False
            MyPropertyPage.TxtAdrsMwhE.Enabled = False
            MyPropertyPage.TxtAdrsPf.Enabled = False
            MyPropertyPage.TxtAdrsVL.Enabled = False

            'Make variable type Non-editable
            MyPropertyPage.CmbVerTypeIPh.Enabled = False
            MyPropertyPage.CmbVerTypeMw.Enabled = False
            MyPropertyPage.CmbVerTypeMvar.Enabled = False
            MyPropertyPage.CmbVerTypeMwhI.Enabled = False
            MyPropertyPage.CmbVerTypeMwhE.Enabled = False
            MyPropertyPage.CmbVerTypePf.Enabled = False
            MyPropertyPage.CmbVerTypeVL.Enabled = False

            'Make variable type Non-editable
            MyPropertyPage.TxtScaleIPh.Enabled = False
            MyPropertyPage.TxtScaleMw.Enabled = False
            MyPropertyPage.TxtScaleMvar.Enabled = False
            MyPropertyPage.TxtScaleMwhI.Enabled = False
            MyPropertyPage.TxtScaleMwhE.Enabled = False
            MyPropertyPage.TxtScalePf.Enabled = False
            MyPropertyPage.TxtScaleVL.Enabled = False

            ''Make Procedures Non-editable
            SetProcedure.TxtFxn.Enabled = False

        End If

        MyPropertyPage.ShowDialog()
        'Me.TopMost = True
    End Sub

    Private Sub SecureElite4ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SecureElite4ToolStripMenuItem.Click
        Dim SecureX As New Mfm.GeneralMfm
        SecureX.Left = 100
        SecureX.Top = 100
        SetSecureMeter4Properties(SecureX)
        Me.Controls.Add(SecureX)
        SecureX.ContextMenuStrip = ContextMenuStrip1
        SecureX.BringToFront()
        MouseDownSettingSingleControl(SecureX)
        MouseMoveSettingSingleControl(SecureX)
        MouseUpSettingSingleControl(SecureX)
    End Sub

    Private Sub CmdAddRishbh_Click(sender As Object, e As EventArgs) Handles CmdAddRishbh.Click
        Dim RishbhX As New Mfm.GeneralMfm
        RishbhX.Left = 100
        RishbhX.Top = 100
        SetRishbhMeterProperties(RishbhX)
        Me.Controls.Add(RishbhX)
        RishbhX.ContextMenuStrip = ContextMenuStrip1
        RishbhX.BringToFront()
        MouseDownSettingSingleControl(RishbhX)
        MouseMoveSettingSingleControl(RishbhX)
        MouseUpSettingSingleControl(RishbhX)
    End Sub

    Private Sub CmdClose_Click(sender As Object, e As EventArgs) Handles CmdClose.Click

        'Me.Close()

        If CmdRun.Enabled = False And CmdEdit.Enabled = True And CmdConnect.Text = "Disconnect" Then    'Connected and running       
            MsgBox("Stop the polling", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If CmdConnect.Text = "Disconnect" Then  'Connected
            MsgBox("Disconnect from Modbus", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MsgBox("Do you realy want to close the application", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
            If MsgBox("Will you restore it after fininshing your intended work", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
                'Me.TopMost = False
                ClosePermissionForm.TopMost = True
                ClosePermissionForm.ShowDialog()
                If Not CloseOperationCanceled Then
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub SetPollingTime(ByVal N As Integer)

        Select Case N
            Case 0                                  '1 Sec
                TimerPolling.Interval = 1000
            Case 1                                  '3 Sec
                TimerPolling.Interval = 3000
            Case 2                                  '5 Sec
                TimerPolling.Interval = 5000
            Case 3                                  '10 Sec
                TimerPolling.Interval = 10000
            Case 4                                  '1 Min
                TimerPolling.Interval = 60000
            Case 5                                  '3 Min
                TimerPolling.Interval = 180000
            Case 6                                  '5 Min
                TimerPolling.Interval = 300000

        End Select

        My.Settings.LastPollingTimeSelNdx = N
        CmbPollingTimer.SelectedIndex = N
    End Sub

    Private Sub SetWebUploadTime(ByVal N As Integer)

        Select Case N
            Case 0                                  '1 min
                'TimerWebUpdate.Interval = 60000
                UploadInterval = 60000
            Case 1                                  '5 min
                'TimerWebUpdate.Interval = 300000
                UploadInterval = 300000 - 40000     'Keep ready 40 sec before time polling (valid for polling time more than 1 min) 
            Case 2                                  '15 min
                'TimerWebUpdate.Interval = 900000
                UploadInterval = 900000 - 40000     'Keep ready 40 sec before time polling (valid for polling time more than 1 min) 
            Case 3                                  '30 min
                'TimerWebUpdate.Interval = 1800000
                UploadInterval = 1800000 - 40000    'Keep ready 40 sec before time polling (valid for polling time more than 1 min) 
            Case 4                                  '60 min
                'TimerWebUpdate.Interval = 3600000
                UploadInterval = 3600000 - 40000    'Keep ready 40 sec before time polling (valid for polling time more than 1 min) 
        End Select

        My.Settings.LastWebUpdateTimeSelNdx = N
        CmbWebUploadTimer.SelectedIndex = N
    End Sub

    Private Sub CmdClrPending_Click(sender As Object, e As EventArgs) Handles CmdClrPending.Click
        Dim pnd As Integer

        'Write as records updated
        ModifyUploadedStatus()                      'Modify uploaded status in local data set
        PwrDataAdapterL.Update(PwrDataSetL)         'Write uploaded status to local db file
        pnd = RecordsPending()
        StsLblPendingRecords.Text = Format(pnd, "000")

    End Sub

    Private Sub CmbPollingTimer_Click(sender As Object, e As EventArgs) Handles CmbPollingTimer.Click
        SetPollingTime(CmbPollingTimer.SelectedIndex)
    End Sub

    Private Sub LinkToUnitTSMI_Click(sender As Object, e As EventArgs) Handles LinkToUnitTSMI.Click
        Try
            If MsgBox("NOTE: AFTER ASSIGNING THE UNIT ID NEED TO CONFIRM THE ACCURACY FOR VOLTAGE DISPLAY" & vbCrLf & vbCrLf & "WILL YOU CONFIRM THE ACCURACY FOR VOLTAGE DISPLAY", vbYesNo + vbExclamation) = vbYes Then
                If ContextMenuStrip2.SourceControl.Name = "lblBus1Kv" Then
                    UidBus1Kv = InputBox("Enter Unit ID for displaying Bus-1 kV")
                    My.Settings.UnitIdBus1Kv = UidBus1Kv
                End If
                If ContextMenuStrip2.SourceControl.Name = "lblBus1Kv" Then
                    UidBus2Kv = InputBox("Enter Unit ID for displaying Bus-2 kV")
                    My.Settings.UnitIdBus2Kv = UidBus2Kv
                End If
            End If
        Catch ex As Exception
            MsgBox("Setting could not be modified" & vbCrLf & vbCrLf & "ERROR: " & ex.Message, MsgBoxStyle.Critical)
        End Try



    End Sub

    Private Sub ToolStripLabel4_Click(sender As Object, e As EventArgs) Handles ToolStripLabel4.Click

    End Sub

    Private Sub CmbWebUploadTimer_Click(sender As Object, e As EventArgs) Handles CmbWebUploadTimer.Click
        SetWebUploadTime(CmbWebUploadTimer.SelectedIndex)
    End Sub

    Private Sub CmbWebUploadTimer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbWebUploadTimer.SelectedIndexChanged
        SetWebUploadTime(CmbWebUploadTimer.SelectedIndex)
    End Sub

    Private Function IsDesiredTimeLapsed(ByVal TimeInterval As Long) As Boolean
        'May not be needed as we have introduced sub RestartUploadTimeLapsedMeasurement
        If Not StopWatchForMonitoringUploadInterval.IsRunning Then
            StopWatchForMonitoringUploadInterval.Start()
        End If
        If StopWatchForMonitoringUploadInterval.ElapsedMilliseconds > TimeInterval Then
            StopWatchForMonitoringUploadInterval.Stop()
            IsDesiredTimeLapsed = True
        Else
            IsDesiredTimeLapsed = False
        End If
    End Function

    Private Sub RestartUploadTimeLapsedMeasurement()
        StopWatchForMonitoringUploadInterval.Reset()
        StopWatchForMonitoringUploadInterval.Start()
    End Sub


    Private Function IsTimeNowMinAreDivisibleBy(ByVal interval As Long) As Boolean
        Select Case interval
            Case 60000                                  '1 min
                IsTimeNowMinAreDivisibleBy = True
            Case 260000                                  '5 min
                If (Now().Minute Mod 5 < 2) Then
                    IsTimeNowMinAreDivisibleBy = True
                Else
                    IsTimeNowMinAreDivisibleBy = False
                End If
            Case 860000                                  '15 min
                If (Now().Minute Mod 15 < 4) Then
                    IsTimeNowMinAreDivisibleBy = True
                Else
                    IsTimeNowMinAreDivisibleBy = False
                End If
            Case 1760000                                  '30 min
                If (Now().Minute Mod 30 < 7) Then
                    IsTimeNowMinAreDivisibleBy = True
                Else
                    IsTimeNowMinAreDivisibleBy = False
                End If
            Case 3560000                                  '60 min
                If (Now().Minute < 12) Then
                    IsTimeNowMinAreDivisibleBy = True
                Else
                    IsTimeNowMinAreDivisibleBy = False
                End If
            Case Else
                IsTimeNowMinAreDivisibleBy = False
        End Select
    End Function

    Private Sub CmdAbout_Click(sender As Object, e As EventArgs) Handles CmdAbout.Click
        AboutBox1.Show()
    End Sub
End Class


