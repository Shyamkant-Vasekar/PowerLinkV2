﻿' ****************************************************************************
'   FxnReadAndConvertValues.vb
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

Module FxnReadAndConvertValues

    Public Function ReadValue(ByRef clnt As EasyModbus.ModbusClient, ByVal AdrsX As Integer, ByVal verTpX As GeneralMfm.VerType, ByVal WhetherReadHolding As Boolean) As Double
        Dim xH As Int16
        Dim xL As Int16
        Dim val As Double

        'Select Case verTpX
        '    Case GeneralMfm.VerType.Signed16
        '        xH = clnt.ReadHoldingRegisters(AdrsX, 1).GetValue(0)
        '        val = ConvertToShortSigned(xH)

        '    Case GeneralMfm.VerType.Unsigned16
        '        xH = clnt.ReadHoldingRegisters(AdrsX, 1).GetValue(0)
        '        val = ConvertToShortUnsigned(xH)

        '    Case GeneralMfm.VerType.Signed32
        '        xH = clnt.ReadHoldingRegisters(AdrsX, 1).GetValue(0)
        '        xL = clnt.ReadHoldingRegisters(AdrsX + 1, 1).GetValue(0)
        '        val = ConvertToLongSigned(xH, xL)

        '    Case GeneralMfm.VerType.Unsigned32
        '        xH = clnt.ReadHoldingRegisters(AdrsX, 1).GetValue(0)
        '        xL = clnt.ReadHoldingRegisters(AdrsX + 1, 1).GetValue(0)
        '        val = ConvertToLongUnsigned(xH, xL)

        '    Case GeneralMfm.VerType.Real
        '        xH = clnt.ReadHoldingRegisters(AdrsX, 1).GetValue(0)
        '        xL = clnt.ReadHoldingRegisters(AdrsX + 1, 1).GetValue(0)
        '        val = ConvertToReal(xH, xL)
        'End Select

        If WhetherReadHolding = True Then
            Select Case verTpX
                Case GeneralMfm.VerType.Signed16
                    xH = clnt.ReadHoldingRegisters(AdrsX, 1).GetValue(0)
                    val = ConvertToShortSigned(xH)

                Case GeneralMfm.VerType.Unsigned16
                    xH = clnt.ReadHoldingRegisters(AdrsX, 1).GetValue(0)
                    val = ConvertToShortUnsigned(xH)

                Case GeneralMfm.VerType.Signed32
                    xH = clnt.ReadHoldingRegisters(AdrsX, 2).GetValue(0)
                    xL = clnt.ReadHoldingRegisters(AdrsX, 2).GetValue(1)
                    val = ConvertToLongSigned(xH, xL)

                Case GeneralMfm.VerType.Unsigned32
                    xH = clnt.ReadHoldingRegisters(AdrsX, 2).GetValue(0)
                    xL = clnt.ReadHoldingRegisters(AdrsX, 2).GetValue(1)
                    val = ConvertToLongUnsigned(xH, xL)

                Case GeneralMfm.VerType.Real
                    xH = clnt.ReadHoldingRegisters(AdrsX, 2).GetValue(0)
                    xL = clnt.ReadHoldingRegisters(AdrsX, 2).GetValue(1)
                    val = ConvertToReal(xH, xL)
            End Select
        Else
            Select Case verTpX
                Case GeneralMfm.VerType.Signed16
                    xH = clnt.ReadInputRegisters(AdrsX, 1).GetValue(0)
                    val = ConvertToShortSigned(xH)

                Case GeneralMfm.VerType.Unsigned16
                    xH = clnt.ReadInputRegisters(AdrsX, 1).GetValue(0)
                    val = ConvertToShortUnsigned(xH)

                Case GeneralMfm.VerType.Signed32
                    xH = clnt.ReadInputRegisters(AdrsX, 2).GetValue(0)
                    xL = clnt.ReadInputRegisters(AdrsX, 2).GetValue(1)
                    val = ConvertToLongSigned(xH, xL)

                Case GeneralMfm.VerType.Unsigned32
                    xH = clnt.ReadInputRegisters(AdrsX, 2).GetValue(0)
                    xL = clnt.ReadInputRegisters(AdrsX, 2).GetValue(1)
                    val = ConvertToLongUnsigned(xH, xL)

                Case GeneralMfm.VerType.Real
                    xH = clnt.ReadInputRegisters(AdrsX, 2).GetValue(0)
                    xL = clnt.ReadInputRegisters(AdrsX, 2).GetValue(1)
                    val = ConvertToReal(xH, xL)
            End Select

        End If

        ReadValue = val

    End Function



    Private Function ConvertToShortSigned(ByVal valx As Int16) As Int16
        ConvertToShortSigned = valx
    End Function

    Private Function ConvertToShortUnsigned(ByVal valx As Int16) As UInt16
        Dim Val As UInt16
        Try
            If valx < 0 Then
                Val = 65536 + valx
            Else
                Val = valx
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ConvertToShortUnsigned = Val
    End Function

    Private Function ConvertToLongSigned(ByVal HW As Int16, ByVal LW As Int16) As Int32
        Dim s1 As String
        Dim s2 As String
        Dim sx As String
        s1 = Convert.ToString(HW, 16).PadLeft(4, "0"c)
        s2 = Convert.ToString(LW, 16).PadLeft(4, "0"c)
        sx = s1 + s2
        ConvertToLongSigned = Convert.ToInt32(sx, 16)
    End Function

    Private Function ConvertToLongUnsigned(ByVal HW As Int16, ByVal LW As Int16) As UInt32
        Dim s1 As String
        Dim s2 As String
        Dim sx As String
        s1 = Convert.ToString(HW, 16).PadLeft(4, "0"c)
        s2 = Convert.ToString(LW, 16).PadLeft(4, "0"c)
        sx = s1 + s2
        ConvertToLongUnsigned = Convert.ToUInt32(sx, 16)
    End Function


    Private Function ConvertToReal(ByVal valH As Int16, ByVal valL As Int16) As Single
        Dim interslt As bit32
        Dim val As Single
        Try
            interslt = ConvertToBits(valH, valL)
            val = FindRealNum(interslt)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ConvertToReal = val
    End Function


    Private Function FindRealNum(ByVal mybits As bit32) As Single

        Dim SumForExp As UInteger = 0
        Dim Sum As Double = 1.0
        Dim Term As Double
        Dim Num As UInteger = 2
        Dim Multiplier As Double
        Dim SignDesision As Double = 1
        If mybits.mbit(31) = True Then
            SignDesision = -1
        Else
            SignDesision = 1
        End If
        Num = 1
        For I = 23 To 30
            If mybits.mbit(I) = True Then
                SumForExp = SumForExp + Num
            End If
            Num = Num * 2
        Next
        Multiplier = 2 ^ (SumForExp - 127)
        Num = 2 '(Why ?)
        For I = 22 To 0 Step -1
            If mybits.mbit(I) = True Then
                Term = 1 / Num
                Sum = Sum + Term
            End If
            Num = Num * 2
        Next
        FindRealNum = SignDesision * Sum * Multiplier
    End Function

    Private Function ConvertToBits(ByVal XH As Int16, ByVal XL As Int16) As bit32
        Dim binString As String
        Dim xbit As New bit32
        Dim i As Integer
        binString = Convert.ToString(XL, 2).PadLeft(16, "0"c)
        For i = 0 To 15
            If Mid(binString, 16 - i, 1) = "1" Then
                xbit.mbit(i) = True
            Else
                xbit.mbit(i) = False
            End If
        Next
        binString = Convert.ToString(XH, 2).PadLeft(16, "0"c)
        For i = 16 To 31
            If Mid(binString, 32 - i, 1) = "1" Then
                xbit.mbit(i) = True
            Else
                xbit.mbit(i) = False
            End If
        Next
        ConvertToBits = xbit
    End Function


    Public Function CreateScaleValueFunction(ByVal ProcedureBody As String)
        Dim StrP As String = ""
        StrP = "Function ScaleValue(ReadValue)" & vbCrLf & ProcedureBody & vbCrLf
        StrP = StrP & "ScaleValue = ReadValue" & vbCrLf
        StrP = StrP & "End Function"
        CreateScaleValueFunction = StrP
    End Function



    Class bit32
        Public mbit(32) As Boolean

        Public Sub New()
            Dim i As Integer
            For i = 0 To 31
                mbit(i) = False
            Next
        End Sub

    End Class




End Module
