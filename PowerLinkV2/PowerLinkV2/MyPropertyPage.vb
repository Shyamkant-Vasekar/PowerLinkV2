' ****************************************************************************
'   MyPropertyPage.vb
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


Public Class MyPropertyPage

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Update general
        If RdbHolding.Checked = True Then
            MainForm.ThisMfm.ReadHoldingReg = True
        Else
            MainForm.ThisMfm.ReadHoldingReg = False
        End If


        'Update addresses (For custom meter only)
        MainForm.ThisMfm.AdrsIR = CInt(Me.TxtRCurAdrs.Text)
        MainForm.ThisMfm.AdrsIY = CInt(Me.TxtYCurAdrs.Text)
        MainForm.ThisMfm.AdrsIB = CInt(Me.TxtBCurAdrs.Text)
        MainForm.ThisMfm.AdrsMw = CInt(Me.TxtAdrsMw.Text)
        MainForm.ThisMfm.AdrsMvar = CInt(Me.TxtAdrsMvar.Text)
        MainForm.ThisMfm.AdrsMwhI = CInt(Me.TxtAdrsMwhI.Text)
        MainForm.ThisMfm.AdrsMwhE = CInt(Me.TxtAdrsMwhE.Text)
        MainForm.ThisMfm.AdrsPf = CInt(Me.TxtAdrsPf.Text)
        MainForm.ThisMfm.AdrsVL = CInt(Me.TxtAdrsVL.Text)


        'Update current variable type (For custom meter only)
        MainForm.ThisMfm.VerTypeIPh = (Me.CmbVerTypeIPh.SelectedIndex) 'Combo index zero based enum zero based 
        MainForm.ThisMfm.VerTypeMw = (Me.CmbVerTypeMw.SelectedIndex)
        MainForm.ThisMfm.VerTypeMvar = (Me.CmbVerTypeMvar.SelectedIndex)
        MainForm.ThisMfm.VerTypeMwhI = (Me.CmbVerTypeMwhI.SelectedIndex)
        MainForm.ThisMfm.VerTypeMwhE = (Me.CmbVerTypeMwhE.SelectedIndex)
        MainForm.ThisMfm.VerTypePf = (Me.CmbVerTypePf.SelectedIndex)
        MainForm.ThisMfm.VerTypeVL = (Me.CmbVerTypeVL.SelectedIndex)


        'Update phase-current scalling factor (For custom meter only)
        MainForm.ThisMfm.ScaleIPh = CDbl(Me.TxtScaleIPh.Text)
        MainForm.ThisMfm.ScaleMw = CDbl(Me.TxtScaleMw.Text)
        MainForm.ThisMfm.ScaleMvar = CDbl(Me.TxtScaleMvar.Text)
        MainForm.ThisMfm.ScaleMwhI = CDbl(Me.TxtScaleMwhI.Text)
        MainForm.ThisMfm.ScaleMwhE = CDbl(Me.TxtScaleMwhE.Text)
        MainForm.ThisMfm.ScalePf = CDbl(Me.TxtScalePf.Text)
        MainForm.ThisMfm.ScaleVL = CDbl(Me.TxtScaleVL.Text)

        'Update phase-current scalling factor (For custom meter only)
        'NOTE: In SetProcedure form

        Me.Close()
    End Sub

    Private Sub CmdFxn_Click(sender As Object, e As EventArgs) Handles CmdProcedureIph.Click, CmdProcedureMvar.Click, CmdProcedureMw.Click, CmdProcedureMwhE.Click, CmdProcedureMwhI.Click, CmdProcedurePf.Click, CmdProcedureVL.Click
        Dim x As New Button 'To access sender name
        x = sender
        MainForm.SET_PROCEDURE_FOR = x.Name
        SetProcedure.ShowDialog()
    End Sub

    Private Sub CmdEditLock_Click(sender As Object, e As EventArgs) Handles CmdEditLock.Click
        If MsgBox("This will make the selected meter as 'Custom' meter" & vbCrLf & _
                  "Proceed for custom meter?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = vbYes Then
            EnableControls(True)
            MainForm.ThisMfm.Make = "Custom"
            MainForm.ThisMfm.Bay = "Custom Bay"
            CmdEditLock.Enabled = False
        End If
        'If CmdEditLock.Text = "Edit" Then
        '    EnableControls(True)
        '    CmdEditLock.Text = "Lock"
        'Else
        '    EnableControls(False)
        '    CmdEditLock.Text = "Edit"
        'End If
    End Sub


    Private Sub EnableControls(ByVal x As Boolean)
        TxtRCurAdrs.Enabled = x
        TxtYCurAdrs.Enabled = x
        TxtBCurAdrs.Enabled = x
        TxtAdrsMw.Enabled = x
        TxtAdrsMvar.Enabled = x
        TxtAdrsMwhI.Enabled = x
        TxtAdrsMwhE.Enabled = x
        TxtAdrsPf.Enabled = x
        TxtAdrsVL.Enabled = x

        TxtScaleIPh.Enabled = x
        TxtScaleMw.Enabled = x
        TxtScaleMvar.Enabled = x
        TxtScaleMwhI.Enabled = x
        TxtScaleMwhE.Enabled = x
        TxtScaleIPh.Enabled = x
        TxtScaleVL.Enabled = x

        CmbVerTypeIPh.Enabled = x
        CmbVerTypeMw.Enabled = x
        CmbVerTypeMvar.Enabled = x
        CmbVerTypeMwhI.Enabled = x
        CmbVerTypeMwhE.Enabled = x
        CmbVerTypePf.Enabled = x
        CmbVerTypeVL.Enabled = x
    End Sub


    Private Sub MyPropertyPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If MainForm.ThisMfm.Make = "Custom" Then
            CmdEditLock.Enabled = False
        Else
            CmdEditLock.Enabled = True
        End If
    End Sub
End Class