' ****************************************************************************
'   SetProcedure.vb
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

Public Class SetProcedure

    Private Sub CmdOk_Click(sender As Object, e As EventArgs) Handles CmdOk.Click

        Select Case MainForm.SET_PROCEDURE_FOR
            Case "CmdProcedureIph"
                MainForm.ThisMfm.ProcedureIPh = TxtFxn.Text
            Case "CmdProcedureMw"
                MainForm.ThisMfm.ProcedureMw = TxtFxn.Text
            Case "CmdProcedureMvar"
                MainForm.ThisMfm.ProcedureMvar = TxtFxn.Text
            Case "CmdProcedureMwhI"
                MainForm.ThisMfm.ProcedureMwhI = TxtFxn.Text
            Case "CmdProcedureMwhE"
                MainForm.ThisMfm.ProcedureMwhE = TxtFxn.Text
            Case "CmdProcedurePf"
                MainForm.ThisMfm.ProcedurePf = TxtFxn.Text
            Case "CmdProcedureVL"
                MainForm.ThisMfm.ProcedureVL = TxtFxn.Text
            Case Else
                MsgBox("Invalid case", MsgBoxStyle.Critical)
        End Select

        Me.Close()
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        Me.Close()
    End Sub

    Private Sub SetProcedure_Load(sender As Object, e As EventArgs) Handles Me.Load


        If MainForm.ThisMfm.Make = "Custom" Then    'User will lock hence function text enabled
            TxtFxn.Enabled = True
        Else
            TxtFxn.Enabled = False
        End If

        Select Case MainForm.SET_PROCEDURE_FOR
            Case "CmdProcedureIph"
                TxtFxn.Text = MainForm.ThisMfm.ProcedureIPh
            Case "CmdProcedureMw"
                TxtFxn.Text = MainForm.ThisMfm.ProcedureMw
            Case "CmdProcedureMvar"
                TxtFxn.Text = MainForm.ThisMfm.ProcedureMvar
            Case "CmdProcedureMwhI"
                TxtFxn.Text = MainForm.ThisMfm.ProcedureMwhI
            Case "CmdProcedureMwhE"
                TxtFxn.Text = MainForm.ThisMfm.ProcedureMwhE
            Case "CmdProcedurePf"
                TxtFxn.Text = MainForm.ThisMfm.ProcedurePf
            Case "CmdProcedureVL"
                TxtFxn.Text = MainForm.ThisMfm.ProcedureVL
            Case Else
                MsgBox("Invalid case", MsgBoxStyle.Critical)
        End Select

    End Sub
End Class