' ****************************************************************************
'   GeneralMfm.vb
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
Public Class GeneralMfm

    'Public AxScriptControl1 = CreateObject("ScriptControl")

    Private ConnectedThis As Boolean
    Private Amp As Double
    Private Uid As Integer = 10

    'Read what
    Private mReadHoldingReg As Boolean 'If false read input register


    'Parameter addresses from where to be read
    Private mModel As String = "New-1"

    'Address From where parameters to be read
    Public AdrsIR As Integer = 10      'May think of converting to property when needed
    Public AdrsIY As Integer = 12      'May think of converting to property when needed
    Public AdrsIB As Integer = 14      'May think of converting to property when needed
    Public AdrsMw As Integer = 16
    Public AdrsMvar As Integer = 18
    Public AdrsMwhI As Integer = 20
    Public AdrsMwhE As Integer = 22
    Public AdrsPf As Integer = 24
    Public AdrsVL As Integer = 26


    'Parameter Variable Types
    Private mTypeIPh As VerType = VerType.Signed16
    Private mTypeMw As VerType = VerType.Signed32
    Private mTypeMvar As VerType = VerType.Signed32
    Private mTypeMwhI As VerType = VerType.Unsigned32
    Private mTypeMwhE As VerType = VerType.Unsigned32
    Private mTypePf As VerType = VerType.Signed16
    Private mTypeVL As VerType = VerType.Unsigned16


    'Parameter scalling factor
    Public ScaleIPh As Double = 1.0     'May think of converting to property when needed
    Public ScaleMw As Double = 1.0
    Public ScaleMvar As Double = 1.0
    Public ScaleMwhI As Double = 1.0
    Public ScaleMwhE As Double = 1.0
    Public ScalePf As Double = 1.0
    Public ScaleVL As Double = 1.0
    Public ProcedureIPh As String = ""
    Public ProcedureMw As String = ""
    Public ProcedureMvar As String = ""
    Public ProcedureMwhI As String = ""
    Public ProcedureMwhE As String = ""
    Public ProcedurePf As String = ""
    Public ProcedureVL As String = ""


    'Parameter Store after applying proper scalling/procedure i.e. final values to be used for displaying
    Public IR As Double       'May think of converting to property when needed
    Public IY As Double       'May think of converting to property when needed
    Public IB As Double       'May think of converting to property when needed
    Public Mw As Double
    Public Mvar As Double
    Public MwhI As Double
    Public MwhE As Double
    Public Pf As Double
    Public VL As Double

    'Reading Mechanism from RTU
    Dim mIRH As Int16
    Dim mIRL As Int16
    Dim mIYH As Int16
    Dim mIYL As Int16
    Dim mIBH As Int16
    Dim mIBL As Int16
    Dim mMwH As Int16
    Dim mMwL As Int16
    Dim mMvarH As Int16
    Dim mMvarL As Int16
    Dim mMwhiH As Int16
    Dim mMwhiL As Int16
    Dim mMwheH As Int16
    Dim mMwheL As Int16
    Dim mPfH As Int16
    Dim mPfL As Int16
    Dim mVlH As Int16
    Dim mVlL As Int16

    'Scaling Mechanism For storing read values as is 
    'i.e. before applying scalling/procedure
    Dim mIr As Double
    Dim mIy As Double
    Dim mIb As Double
    Dim mMw As Double
    Dim mMvar As Double
    Dim mMwhI As Double
    Dim mMwhE As Double
    Dim mPf As Double
    Dim mVL As Double


    'Property attached to control property
    Public Property ReadHoldingReg As Boolean

        Get
            ReadHoldingReg = mReadHoldingReg
        End Get
        Set(value As Boolean)
            mReadHoldingReg = value
        End Set
    End Property



    'Property attached to control property
    Public Property Bay As String

        Get
            Bay = LblBay.Text
        End Get
        Set(value As String)
            LblBay.Text = value
        End Set
    End Property

    'Property attached to control property
    Public Property SrNo As String

        Get
            SrNo = LblSrNo.Text
        End Get
        Set(value As String)
            LblSrNo.Text = value
        End Set
    End Property


    Public ReadOnly Property Connected As Boolean
        Get
            Connected = ConnectedThis
        End Get
        'Set(value As Boolean)
        '    ConnectedThis = value
        'End Set
    End Property

    'Property attached to control property
    Public Property ID As Integer
        Get
            ID = Uid
        End Get
        Set(value As Integer)
            Uid = value
            LblId.Text = Str(Uid)
        End Set
    End Property

    'Property attached to control property
    Public Property Make As String

        Get
            Make = LblMake.Text
        End Get
        Set(value As String)
            LblMake.Text = value
            'AxScriptControl1.Language = "VBScript"
        End Set
    End Property


    'Property attached to control property
    Public Property Type As String

        Get
            Type = LblType.Text
        End Get
        Set(value As String)
            LblType.Text = value
        End Set
    End Property


    'Property enum
    Public Property VerTypeIPh As Integer    'May be replaced with enum in next stage

        Get
            VerTypeIPh = mTypeIPh
        End Get
        Set(value As Integer)
            If value < 1 Or value > 5 Then
                MsgBox("Error")
            End If
            mTypeIPh = value
        End Set
    End Property

    Public Property VerTypeMw As Integer    'May be replaced with enum in next stage

        Get
            VerTypeMw = mTypeMw
        End Get
        Set(value As Integer)
            mTypeMw = value
        End Set
    End Property

    Public Property VerTypeMvar As Integer    'May be replaced with enum in next stage

        Get
            VerTypeMvar = mTypeMvar
        End Get
        Set(value As Integer)
            mTypeMvar = value
        End Set
    End Property


    Public Property VerTypeMwhI As Integer    'May be replaced with enum in next stage

        Get
            VerTypeMwhI = mTypeMwhI
        End Get
        Set(value As Integer)
            mTypeMwhI = value
        End Set
    End Property



    Public Property VerTypeMwhE As Integer    'May be replaced with enum in next stage

        Get
            VerTypeMwhE = mTypeMwhE
        End Get
        Set(value As Integer)
            mTypeMwhE = value
        End Set
    End Property



    Public Property VerTypePf As Integer    'May be replaced with enum in next stage

        Get
            VerTypePf = mTypePf
        End Get
        Set(value As Integer)
            mTypePf = value
        End Set
    End Property



    Public Property VerTypeVL As Integer    'May be replaced with enum in next stage

        Get
            VerTypeVL = mTypeVL
        End Get
        Set(value As Integer)
            mTypeVL = value
        End Set
    End Property


    Public Function StopPolling() As Boolean
        LblConnected.BackColor = Me.BackColor
        Amp = 0
        Mw = 0
        Mvar = 0
        Pf = 0
        VL = 0
        RefreshDisplay()
        StopPolling = True
    End Function


    Public Function ReadData(ByRef ForClient As EasyModbus.ModbusClient) As Boolean

        Try

            'READING METER PARAMETERS
            '=========================================================================
            ForClient.UnitIdentifier = ID

            'Reading currents
            mIr = ReadValue(ForClient, AdrsIR, mTypeIPh, ReadHoldingReg)
            mIy = ReadValue(ForClient, AdrsIY, mTypeIPh, ReadHoldingReg)
            mIb = ReadValue(ForClient, AdrsIB, mTypeIPh, ReadHoldingReg)
            'Reading Power
            mMw = ReadValue(ForClient, AdrsMw, mTypeMw, ReadHoldingReg)
            mMvar = ReadValue(ForClient, AdrsMvar, mTypeMvar, ReadHoldingReg)
            'Reading Energy
            mMwhI = ReadValue(ForClient, AdrsMwhI, mTypeMwhI, ReadHoldingReg)
            mMwhE = ReadValue(ForClient, AdrsMwhE, mTypeMwhE, ReadHoldingReg)
            'Reading Others
            mPf = ReadValue(ForClient, AdrsPf, mTypePf, ReadHoldingReg)
            mVL = ReadValue(ForClient, AdrsVL, mTypeVL, ReadHoldingReg)

            ConnectedThis = True
            LblConnected.BackColor = Color.LawnGreen
            ReadData = True
        Catch ex As Exception
            'MsgBox("Unknown Error: " & ex.Message, MsgBoxStyle.Exclamation)
            ReadData = False
            ConnectedThis = False
            LblConnected.BackColor = Color.Red
        End Try
        ApplyScallingOrProcedure()  'Transfer read data to final properties
        RefreshDisplay()
    End Function


    'Public Function WriteCurrentDataToMyWebsite() As Boolean
    '    Dim webClient As New System.Net.WebClient
    '    Dim result As String
    '    Dim GetStr As String

    '    'Sample GET string
    '    '/WriteMfmData.aspx?BayID=33333&BayNm=ThreeThree&Amp=224&Mw=53&Mvar=12&MwhI=125690&MwhE=985421

    '    GetStr = "http://aksharait.in/Sample/WriteMfmData.aspx?"
    '    GetStr = GetStr & "BayID=" & SrNo & "&"
    '    GetStr = GetStr & "BayNm=" & Bay & "&"
    '    GetStr = GetStr & "Amp=" & Amp & "&"
    '    GetStr = GetStr & "Mw=" & Mw & "&"
    '    GetStr = GetStr & "Mvar=" & Mvar & "&"
    '    GetStr = GetStr & "MwhI=" & MwhI & "&"
    '    GetStr = GetStr & "MwhE=" & MwhE & "&"

    '    Try
    '        result = webClient.DownloadString(GetStr)
    '        LblWebUpdate.BackColor = Color.LightBlue
    '        WriteCurrentDataToMyWebsite = True
    '    Catch ex As Exception
    '        LblWebUpdate.BackColor = Color.LightGray
    '        WriteCurrentDataToMyWebsite = False
    '    End Try

    'End Function

    'Scalling or procedure takes place on mIr, mIy, mIb 
    'and values assigned to IR, IY and IB and Amp calculated
    Private Sub ApplyScallingOrProcedure()
        Dim EvalFxn As String

        'APPLYING SCALE OR PROCEDURE FOR CURRENT
        '===================================================================================
        If ProcedureIPh = "" Then   'Simple Scale
            IR = mIr * ScaleIPh
            IY = mIy * ScaleIPh
            IB = mIb * ScaleIPh
        Else
            ' Add code, and then run the function.
            Try

                'Apply procedure to current
                AxScriptControl1.Reset()
                AxScriptControl1.AddCode(CreateScaleValueFunction(ProcedureIPh))
                EvalFxn = "ScaleValue(" & mIr.ToString & ")"    'ScaleValue is function name defined on SetProcedure Form in Main program
                IR = AxScriptControl1.Eval(EvalFxn)
                EvalFxn = "ScaleValue(" & mIy.ToString & ")"    'ScaleValue is function name defined on SetProcedure Form in Main program
                IY = AxScriptControl1.Eval(EvalFxn)
                EvalFxn = "ScaleValue(" & mIb.ToString & ")"    'ScaleValue is function name defined on SetProcedure Form in Main program
                IB = AxScriptControl1.Eval(EvalFxn)


                'Apply Procedure to energy
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        Amp = (IR + IY + IB) / 3.0

        'APPLYING SCALE OR PROCEDURE FOR POWER
        '===================================================================================
        If ProcedureMw = "" Then
            Mw = mMw * ScaleMw
        Else
            Try
                AxScriptControl1.Reset()
                AxScriptControl1.AddCode(CreateScaleValueFunction(ProcedureMw))
                EvalFxn = "ScaleValue(" & mMw.ToString & ")"    'ScaleValue is function name defined on SetProcedure Form in Main program
                Mw = AxScriptControl1.Eval(EvalFxn)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        If ProcedureMvar = "" Then
            Mvar = mMvar * ScaleMvar
        Else
            Try
                AxScriptControl1.Reset()
                AxScriptControl1.AddCode(CreateScaleValueFunction(ProcedureMvar))
                EvalFxn = "ScaleValue(" & mMvar.ToString & ")"    'ScaleValue is function name defined on SetProcedure Form in Main program
                Mvar = AxScriptControl1.Eval(EvalFxn)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        'APPLYING SCALE OR PROCEDURE FOR Energy
        '===================================================================================
        If ProcedureMwhI = "" Then
            MwhI = mMwhI * ScaleMwhI
        Else
            Try
                AxScriptControl1.Reset()
                AxScriptControl1.AddCode(CreateScaleValueFunction(ProcedureMwhI))
                EvalFxn = "ScaleValue(" & mMwhI.ToString & ")"    'ScaleValue is function name defined on SetProcedure Form in Main program
                MwhI = AxScriptControl1.Eval(EvalFxn)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        If ProcedureMwhE = "" Then
            MwhE = mMwhE * ScaleMwhE
        Else
            Try
                AxScriptControl1.Reset()
                AxScriptControl1.AddCode(CreateScaleValueFunction(ProcedureMwhE))
                EvalFxn = "ScaleValue(" & mMwhE.ToString & ")"    'ScaleValue is function name defined on SetProcedure Form in Main program
                MwhE = AxScriptControl1.Eval(EvalFxn)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        'APPLYING SCALE OR PROCEDURE FOR OTHER
        '===================================================================================
        If ProcedurePf = "" Then
            Pf = mPf * ScalePf
        Else
            Try
                AxScriptControl1.Reset()
                AxScriptControl1.AddCode(CreateScaleValueFunction(ProcedurePf))
                EvalFxn = "ScaleValue(" & mPf.ToString & ")"    'ScaleValue is function name defined on SetProcedure Form in Main program
                Pf = AxScriptControl1.Eval(EvalFxn)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        If ProcedureVL = "" Then
            VL = mVL * ScaleVL
        Else
            Try
                AxScriptControl1.Reset()
                AxScriptControl1.AddCode(CreateScaleValueFunction(ProcedureVL))
                EvalFxn = "ScaleValue(" & mVL.ToString & ")"    'ScaleValue is function name defined on SetProcedure Form in Main program
                VL = AxScriptControl1.Eval(EvalFxn)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If


    End Sub

    Private Sub RefreshDisplay()
        'Refreshing Acord meter display
        If Connected Then
            LblAmp.Text = Format(Amp, ".00") & "/" & Format(Pf, "0.00")
            LblMw.Text = Format(Mw, ".00")
            LblMvar.Text = Format(Mvar, ".00")
            LblMwhI.Text = Format(MwhI, "000000.00")
            LblMwhE.Text = Format(MwhE, "000000.00")
        Else
            LblAmp.Text = "###.##"
            LblMw.Text = "###.##"
            LblMvar.Text = "###.##"
            LblMwhI.Text = "###.##"
            LblMwhE.Text = "###.##"
        End If
    End Sub


    Public Enum VerType
        Signed16
        Unsigned16
        Signed32
        Unsigned32
        Real
    End Enum


    Private Sub GeneralMfm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class


