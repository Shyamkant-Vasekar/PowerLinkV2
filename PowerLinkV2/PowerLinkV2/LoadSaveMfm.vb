' ****************************************************************************
'   LoadSaveMfm.vb
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

Module LoadSaveMfm
    Public MeterList As New List(Of MeterData) 'to be used for saving Mfm properties to file. Saving related all subroutines will be written in this module  

    Public Sub SaveAllMfm()
        Dim F As Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim s As IO.Stream
        TransferAllMfmToSavableObject()
        F = New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        s = New IO.FileStream("C:\ProgramData\PowerLinkV2\MfmSetup.bin", IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.None)
        's = New IO.FileStream("MfmSetup.bin", IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.None)
        F.Serialize(s, MeterList)
        s.Close()
    End Sub


    Public Sub LoadAllMfm()

        'Read energy meters from existing file
        Dim f As Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim s As IO.Stream
        Dim ThisMfm As Mfm.GeneralMfm

        f = New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        If System.IO.File.Exists("C:\ProgramData\PowerLinkV2\MfmSetup.bin") Then
            'If System.IO.File.Exists("MfmSetup.bin") Then
            Try
                s = New IO.FileStream("C:\ProgramData\PowerLinkV2\MfmSetup.bin", IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.None)
                's = New IO.FileStream("MfmSetup.bin", IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.None)
                MeterList = DirectCast(f.Deserialize(s), Object)
                s.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                If Not IsNothing(s) Then
                    s.Close()
                End If
            End Try
        End If

        'Display the meters on form and add them to drag drop and context menu functionality
        If Not IsNothing(MeterList) Then
            For Each element In MeterList
                ThisMfm = New Mfm.GeneralMfm
                ThisMfm = TransferThisObjectToMfm(element)
                MainForm.Controls.Add(ThisMfm)
                MainForm.MouseDownSettingSingleControl(ThisMfm)
                MainForm.MouseMoveSettingSingleControl(ThisMfm)
                MainForm.MouseUpSettingSingleControl(ThisMfm)
                ThisMfm.ContextMenuStrip = MainForm.ContextMenuStrip1
            Next
        End If

    End Sub


    Public Sub TransferAllMfmToSavableObject()
        Dim ThisMeterData As MeterData
        'Write meter setup data to file
        '=======================================================================
        If Not IsNothing(MeterList) Then
            MeterList.Clear()
            Dim Cntrl As Control
            For Each Cntrl In MainForm.Controls
                If TypeOf (Cntrl) Is Mfm.GeneralMfm Then
                    ThisMeterData = TransferThisMfmToSavableObject(Cntrl)
                    MeterList.Add(ThisMeterData)
                End If
            Next
        End If
    End Sub


    Public Function TransferThisMfmToSavableObject(ByVal ThisMfm As Mfm.GeneralMfm) As MeterData
        Dim ThisMeterData As New MeterData

        'General
        ThisMeterData.Left = ThisMfm.Left
        ThisMeterData.Top = ThisMfm.Top
        ThisMeterData.Make = ThisMfm.Make
        ThisMeterData.Type = ThisMfm.Type
        ThisMeterData.SrNo = ThisMfm.SrNo
        ThisMeterData.BayName = ThisMfm.Bay
        ThisMeterData.ID = ThisMfm.ID
        ThisMeterData.BackColor = ThisMfm.BackColor
        ThisMeterData.ReadHoldingReg = ThisMfm.ReadHoldingReg

        'Addresses
        ThisMeterData.AdrsIR = ThisMfm.AdrsIR
        ThisMeterData.AdrsIY = ThisMfm.AdrsIY
        ThisMeterData.AdrsIB = ThisMfm.AdrsIB
        ThisMeterData.AdrsMw = ThisMfm.AdrsMw
        ThisMeterData.AdrsMvar = ThisMfm.AdrsMvar
        ThisMeterData.AdrsMwhI = ThisMfm.AdrsMwhI
        ThisMeterData.AdrsMwhE = ThisMfm.AdrsMwhE
        ThisMeterData.AdrsPf = ThisMfm.AdrsPf
        ThisMeterData.AdrsVL = ThisMfm.AdrsVL


        'Variable type
        ThisMeterData.VerTypeIPh = ThisMfm.VerTypeIPh
        ThisMeterData.VerTypeMw = ThisMfm.VerTypeMw
        ThisMeterData.VerTypeMvar = ThisMfm.VerTypeMvar
        ThisMeterData.VerTypeMwhI = ThisMfm.VerTypeMwhI
        ThisMeterData.VerTypeMwhE = ThisMfm.VerTypeMwhE
        ThisMeterData.VerTypePf = ThisMfm.VerTypePf
        ThisMeterData.VerTypeVL = ThisMfm.VerTypeVL

        'Scales
        ThisMeterData.ScaleIPh = ThisMfm.ScaleIPh
        ThisMeterData.ScaleMw = ThisMfm.ScaleMw
        ThisMeterData.ScaleMvar = ThisMfm.ScaleMvar
        ThisMeterData.ScaleMwhI = ThisMfm.ScaleMwhI
        ThisMeterData.ScaleMwhE = ThisMfm.ScaleMwhE
        ThisMeterData.ScalePf = ThisMfm.ScalePf
        ThisMeterData.ScaleVL = ThisMfm.ScaleVL

        'Procedures
        ThisMeterData.ProcedureIph = ThisMfm.ProcedureIPh
        ThisMeterData.ProcedureMw = ThisMfm.ProcedureMw
        ThisMeterData.ProcedureMvar = ThisMfm.ProcedureMvar
        ThisMeterData.ProcedureMwhI = ThisMfm.ProcedureMwhI
        ThisMeterData.ProcedureMwhE = ThisMfm.ProcedureMwhE
        ThisMeterData.ProcedurePf = ThisMfm.ProcedurePf
        ThisMeterData.ProcedureVL = ThisMfm.ProcedureVL

        Return ThisMeterData
    End Function



    Public Function TransferThisObjectToMfm(ByVal ThisMeterData As MeterData) As Mfm.GeneralMfm
        Dim ThisMfm As New Mfm.GeneralMfm

        'General
        ThisMfm.Left = ThisMeterData.Left
        ThisMfm.Top = ThisMeterData.Top
        ThisMfm.Make = ThisMeterData.Make
        ThisMfm.Type = ThisMeterData.Type
        ThisMfm.SrNo = ThisMeterData.SrNo
        ThisMfm.Bay = ThisMeterData.BayName
        ThisMfm.ID = ThisMeterData.ID
        ThisMfm.BackColor = ThisMeterData.BackColor
        ThisMfm.ReadHoldingReg = ThisMeterData.ReadHoldingReg

        'Addresses
        ThisMfm.AdrsIR = ThisMeterData.AdrsIR
        ThisMfm.AdrsIY = ThisMeterData.AdrsIY
        ThisMfm.AdrsIB = ThisMeterData.AdrsIB
        ThisMfm.AdrsMw = ThisMeterData.AdrsMw
        ThisMfm.AdrsMvar = ThisMeterData.AdrsMvar
        ThisMfm.AdrsMwhI = ThisMeterData.AdrsMwhI
        ThisMfm.AdrsMwhE = ThisMeterData.AdrsMwhE
        ThisMfm.AdrsPf = ThisMeterData.AdrsPf
        ThisMfm.AdrsVL = ThisMeterData.AdrsVL


        'Variable type
        ThisMfm.VerTypeIPh = ThisMeterData.VerTypeIPh
        ThisMfm.VerTypeMw = ThisMeterData.VerTypeMw
        ThisMfm.VerTypeMvar = ThisMeterData.VerTypeMvar
        ThisMfm.VerTypeMwhI = ThisMeterData.VerTypeMwhI
        ThisMfm.VerTypeMwhE = ThisMeterData.VerTypeMwhE
        ThisMfm.VerTypePf = ThisMeterData.VerTypePf
        ThisMfm.VerTypeVL = ThisMeterData.VerTypeVL

        'Scales
        ThisMfm.ScaleIPh = ThisMeterData.ScaleIPh
        ThisMfm.ScaleMw = ThisMeterData.ScaleMw
        ThisMfm.ScaleMvar = ThisMeterData.ScaleMvar
        ThisMfm.ScaleMwhI = ThisMeterData.ScaleMwhI
        ThisMfm.ScaleMwhE = ThisMeterData.ScaleMwhE
        ThisMfm.ScalePf = ThisMeterData.ScalePf
        ThisMfm.ScaleVL = ThisMeterData.ScaleVL

        'Procedures
        ThisMfm.ProcedureIPh = ThisMeterData.ProcedureIph
        ThisMfm.ProcedureMw = ThisMeterData.ProcedureMw
        ThisMfm.ProcedureMvar = ThisMeterData.ProcedureMvar
        ThisMfm.ProcedureMwhI = ThisMeterData.ProcedureMwhI
        ThisMfm.ProcedureMwhE = ThisMeterData.ProcedureMwhE
        ThisMfm.ProcedurePf = ThisMeterData.ProcedurePf
        ThisMfm.ProcedureVL = ThisMeterData.ProcedureVL

        Return ThisMfm
    End Function


    <Serializable()> Public Class MeterData
        'General
        Public Make As String
        Public Type As String
        Public SrNo As String
        Public Left As Integer
        Public Top As Integer
        Public ID As Integer
        Public BayName As String
        Public BackColor As Color
        Public ReadHoldingReg As Boolean


        'Addresses
        Public AdrsIR As Integer
        Public AdrsIY As Integer
        Public AdrsIB As Integer
        Public AdrsMw As Integer
        Public AdrsMvar As Integer
        Public AdrsMwhI As Integer
        Public AdrsMwhE As Integer
        Public AdrsPf As Integer
        Public AdrsVL As Integer

        'Variable Types
        Public VerTypeIPh As Integer
        Public VerTypeMw As Integer
        Public VerTypeMvar As Integer
        Public VerTypeMwhI As Integer
        Public VerTypeMwhE As Integer
        Public VerTypePf As Integer
        Public VerTypeVL As Integer

        'Scales
        Public ScaleIPh As Double
        Public ScaleMw As Double
        Public ScaleMvar As Double
        Public ScaleMwhI As Double
        Public ScaleMwhE As Double
        Public ScalePf As Double
        Public ScaleVL As Double

        'Procedures
        Public ProcedureIph As String
        Public ProcedureMw As String
        Public ProcedureMvar As String
        Public ProcedureMwhI As String
        Public ProcedureMwhE As String
        Public ProcedurePf As String
        Public ProcedureVL As String

        Public Sub New()
            Make = "Unknown"
            Type = "New"
            SrNo = "NotKnown"
            Left = 0
            Top = 0
            ID = 0
            BayName = "SomeBay"
            AdrsIR = 0
            AdrsIY = 0
            AdrsIB = 0
            VerTypeIPh = 0
            ScaleIPh = 1.0
        End Sub
    End Class

End Module
