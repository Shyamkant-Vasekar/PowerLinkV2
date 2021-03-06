﻿' ****************************************************************************
'   SubMakeResources.vb
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


Imports System.Data.SqlClient
Module SubMakeResources

    Public Sub MakeLocalResources()
        Dim cmd As SQLiteCommand


        'Make dataset with one table by table name PwrDataTableL
        MainForm.PwrDataSetL = New DataSet
        MainForm.PwrDataTableL = New DataTable
        With MainForm.PwrDataTableL.Columns
            .Add(New DataColumn("DtTm"))
            .Add(New DataColumn("BayID"))
            .Add(New DataColumn("BayNm"))
            .Add(New DataColumn("Amp"))
            .Add(New DataColumn("Mw"))
            .Add(New DataColumn("Mvar"))
            .Add(New DataColumn("MwhI"))
            .Add(New DataColumn("MwhE"))
            .Add(New DataColumn("Uploaded"))
        End With
        MainForm.PwrDataTableL.TableName = "MfmData000"
        MainForm.PwrDataSetL.Tables.Add(MainForm.PwrDataTableL)

        'Create data adapter SUITABLE for inserting new data and selecting not uploaded
        '1. Create new table adapter
        MainForm.PwrDataAdapterL = New SQLiteDataAdapter()
        '2. Add table mapping to it
        MainForm.PwrDataAdapterL.TableMappings.Add("Table", "MfmData000")
        '3. Create conLnection
        MainForm.conL = New SQLiteConnection(MainForm.ConStrL)
        '4. Create insert command for inserting data with parameters
        cmd = New SQLiteCommand("INSERT INTO MfmData000 (DtTm, BayId, BayNm, Amp, Mw, Mvar, MwhI, MwhE, Uploaded) VALUES (@DtTm, @BayId, @BayNm, @Amp, @Mw, @Mvar, @MwhI, @MwhE, @Uploaded)", MainForm.conL)
        '5. Add parameters to insert command
        cmd.Parameters.Add("@DtTm", SqlDbType.Variant, 24, "DtTm")
        cmd.Parameters.Add("@BayId", SqlDbType.Variant, 10, "BayId")
        cmd.Parameters.Add("@BayNm", SqlDbType.Variant, 10, "BayNm")
        cmd.Parameters.Add("@Amp", SqlDbType.Real, 10, "Amp")
        cmd.Parameters.Add("@Mw", SqlDbType.Real, 10, "Mw")
        cmd.Parameters.Add("@Mvar", SqlDbType.Real, 10, "Mvar")
        cmd.Parameters.Add("@MwhI", SqlDbType.Real, 10, "MwhI")
        cmd.Parameters.Add("@MwhE", SqlDbType.Real, 10, "MwhE")
        cmd.Parameters.Add("@Uploaded", SqlDbType.Int, 10, "Uploaded")

        '6. Assign insert command to data adapter
        MainForm.PwrDataAdapterL.InsertCommand = cmd

        cmd = New SQLiteCommand("Select * From MfmData000 Where Uploaded = 0", MainForm.conL)
        MainForm.PwrDataAdapterL.SelectCommand = cmd

        cmd = New SQLiteCommand("UPDATE MfmData000 SET Uploaded = @Uploaded", MainForm.conL)
        cmd.Parameters.Add("@Uploaded", SqlDbType.Int, 10, "Uploaded")
        MainForm.PwrDataAdapterL.UpdateCommand = cmd

        MainForm.conL.Close() 'Does not required any more(?) 

    End Sub


    Public Sub MakeRemoteResources()
        Dim cmd As SqlCommand


        'Make dataset with one table by table name PwrDataTableR
        MainForm.PwrDataSetR = New DataSet
        MainForm.PwrDataTableR = New DataTable
        With MainForm.PwrDataTableR.Columns
            .Add(New DataColumn("DtTm"))
            .Add(New DataColumn("BayID"))
            '.Add(New DataColumn("BayNm"))
            .Add(New DataColumn("Amp"))
            .Add(New DataColumn("Mw"))
            .Add(New DataColumn("Mvar"))
            .Add(New DataColumn("MwhI"))
            .Add(New DataColumn("MwhE"))
        End With
        MainForm.PwrDataTableR.TableName = "MfmData020"
        MainForm.PwrDataSetR.Tables.Add(MainForm.PwrDataTableR)

        'Create data adapter SUITABLE for inserting new data and selecting not uploaded
        '1. Create new table adapter
        MainForm.PwrDataAdapterR = New SqlDataAdapter()
        '2. Add table mapping to it
        'MainForm.PwrDataAdapterR.TableMappings.Add("Table", "MfmData020")
        MainForm.PwrDataAdapterR.TableMappings.Add("Table", "MfmData020")
        '3. Create conLnection
        MainForm.conR = New SqlConnection(MainForm.ConStrR)
        '4. Create insert command for inserting data with parameters
        'cmd = New SqlCommand("INSERT INTO MfmData020 (DtTm, BayId, BayNm, Amp, Mw, Mvar, MwhI, MwhE) VALUES (@DtTm, @BayId, @BayNm, @Amp, @Mw, @Mvar, @MwhI, @MwhE)", MainForm.conR)
        cmd = New SqlCommand("INSERT INTO MfmData020 (DtTm, BayId, Amp, Mw, Mvar, MwhI, MwhE) VALUES (@DtTm, @BayId, @Amp, @Mw, @Mvar, @MwhI, @MwhE)", MainForm.conR)
        '5. Add parameters to insert command
        cmd.Parameters.Add("@DtTm", SqlDbType.DateTime, 24, "DtTm")
        cmd.Parameters.Add("@BayId", SqlDbType.NChar, 10, "BayId")
        'cmd.Parameters.Add("@BayNm", SqlDbType.NVarChar, 50, "BayNm")
        cmd.Parameters.Add("@Amp", SqlDbType.Float, 10, "Amp")
        cmd.Parameters.Add("@Mw", SqlDbType.Float, 10, "Mw")
        cmd.Parameters.Add("@Mvar", SqlDbType.Float, 10, "Mvar")
        cmd.Parameters.Add("@MwhI", SqlDbType.Float, 10, "MwhI")
        cmd.Parameters.Add("@MwhE", SqlDbType.Float, 10, "MwhE")

        '6. Assign insert command to data adapter
        MainForm.PwrDataAdapterR.InsertCommand = cmd

        cmd = New SqlCommand("Select * From MfmData020", MainForm.conR)
        MainForm.PwrDataAdapterR.SelectCommand = cmd
        MainForm.conR.Close() 'Does not required any more(?) 

    End Sub


    Public Sub TransferDataFromLocalToRemoteDataSet()
        MainForm.PwrDataSetR.Tables("MfmData020").Clear()
        For Each row As DataRow In MainForm.PwrDataSetL.Tables("MfmData000").Rows
            'MsgBox(row.Item(1))
            MainForm.PwrDataSetR.Tables("MfmData020").Rows.Add(row.Item(0), row.Item(1), row.Item(3), row.Item(4), row.Item(5), row.Item(6), row.Item(7))
        Next
    End Sub


    Public Sub CreateDataRowInLocalDataset(ByRef ThisMfm As Mfm.GeneralMfm)
        Dim DtTm As Date
        Dim DtTmStr As String
        Dim Amp As Double
        Dim Uploaded As Integer

        'Create data

        'For date formating suitable for MS SQL SERVER
        DtTm = Date.Now()

        DtTmStr = DtTm.Year.ToString("0000") & "-" & DtTm.Month.ToString("00") & "-" & DtTm.Day.ToString("00") & " " & Str(DtTm.Hour) & ":" & DtTm.Minute.ToString("00") & ":" & DtTm.Second.ToString("00")


        Uploaded = 0

        MainForm.PwrDataSetL.Tables("MfmData000").Clear()
        With ThisMfm
            Amp = (.IR + .IY + .IB) / 3.0
            MainForm.PwrDataSetL.Tables("MfmData000").Rows.Add(DtTmStr, .SrNo, .Bay, Amp, .Mw, .Mvar, .MwhI, .MwhE, Uploaded)
        End With
    End Sub


    Sub ModifyUploadedStatus()
        For Each row As DataRow In MainForm.PwrDataSetL.Tables("MfmData000").Rows
            row.Item(8) = 1
        Next
    End Sub

    Public Function RecordsPending() As Integer
        MainForm.PwrDataSetL.Tables("MfmData000").Clear()    'Clear previous data if any
        MainForm.PwrDataAdapterL.Fill(MainForm.PwrDataSetL)           'Load local data set with un-uploaded data if any
        RecordsPending = MainForm.PwrDataSetL.Tables("MfmData000").Rows.Count
    End Function


End Module
