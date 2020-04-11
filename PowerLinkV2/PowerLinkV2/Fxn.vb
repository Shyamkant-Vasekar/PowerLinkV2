Imports Mfm.GeneralMfm
Module Fxn

    Public Sub SetAcordMeterProperties(ByRef ThisMfm As Mfm.GeneralMfm)

        'General
        ThisMfm.Make = "Acord"
        ThisMfm.Type = "Ac-1"
        ThisMfm.Bay = "Acord Bay"
        ThisMfm.ID = Format(255 * Rnd(), "000")
        ThisMfm.SrNo = Format(1000000 * Rnd(), "000000")    'Bay ID
        ThisMfm.BackColor = Color.LightCyan
        ThisMfm.ReadHoldingReg = True

        'Addresses
        ThisMfm.AdrsIR = 158
        ThisMfm.AdrsIY = 159
        ThisMfm.AdrsIB = 160
        ThisMfm.AdrsMw = 162
        ThisMfm.AdrsMvar = 166
        ThisMfm.AdrsMwhI = 170
        ThisMfm.AdrsMwhE = 178
        ThisMfm.AdrsPf = 168
        ThisMfm.AdrsVL = 154

        'Variable Type
        ThisMfm.VerTypeIPh = Mfm.GeneralMfm.VerType.Unsigned16
        ThisMfm.VerTypeMw = Mfm.GeneralMfm.VerType.Signed32
        ThisMfm.VerTypeMvar = Mfm.GeneralMfm.VerType.Signed32
        ThisMfm.VerTypeMwhI = Mfm.GeneralMfm.VerType.Unsigned32
        ThisMfm.VerTypeMwhE = Mfm.GeneralMfm.VerType.Unsigned32
        ThisMfm.VerTypePf = Mfm.GeneralMfm.VerType.Signed16
        ThisMfm.VerTypeVL = Mfm.GeneralMfm.VerType.Unsigned16

        'Scales
        ThisMfm.ScaleIPh = 0.1
        ThisMfm.ScaleMw = 0.00001
        ThisMfm.ScaleMvar = 0.00001
        ThisMfm.ScaleMwhI = 0.01
        ThisMfm.ScaleMwhE = 0.01
        ThisMfm.ScalePf = 0.001
        ThisMfm.ScaleVL = 0.01

        'Procedures (Higher Precidance over scale)
        ThisMfm.ProcedureIPh = ""
        ThisMfm.ProcedureMw = ""
        ThisMfm.ProcedureMvar = ""
        ThisMfm.ProcedureMwhI = ""
        ThisMfm.ProcedureMwhE = ""
        ThisMfm.ProcedurePf = ""
        ThisMfm.ProcedureVL = ""

    End Sub


    Public Sub SetSecureMeterProperties(ByRef ThisMfm As Mfm.GeneralMfm)

        'General
        ThisMfm.Make = "Secure"
        ThisMfm.Type = "Elite"
        ThisMfm.Bay = "Secure Bay"
        ThisMfm.ID = Format(255 * Rnd(), "000")
        ThisMfm.SrNo = Format(1000000 * Rnd(), "000000")    'Bay ID
        ThisMfm.BackColor = Color.LightPink
        ThisMfm.ReadHoldingReg = True

        'Addresses
        ThisMfm.AdrsIR = 55
        ThisMfm.AdrsIY = 57
        ThisMfm.AdrsIB = 59
        ThisMfm.AdrsMw = 65
        ThisMfm.AdrsMvar = 67
        ThisMfm.AdrsMwhI = 217
        ThisMfm.AdrsMwhE = 219
        ThisMfm.AdrsPf = 74
        ThisMfm.AdrsVL = 49

        'Variable Type
        ThisMfm.VerTypeIPh = Mfm.GeneralMfm.VerType.Unsigned32
        ThisMfm.VerTypeMw = Mfm.GeneralMfm.VerType.Unsigned32
        ThisMfm.VerTypeMvar = Mfm.GeneralMfm.VerType.Unsigned32
        ThisMfm.VerTypeMwhI = Mfm.GeneralMfm.VerType.Unsigned32
        ThisMfm.VerTypeMwhE = Mfm.GeneralMfm.VerType.Unsigned32
        ThisMfm.VerTypePf = Mfm.GeneralMfm.VerType.Signed16
        ThisMfm.VerTypeVL = Mfm.GeneralMfm.VerType.Unsigned32

        'Scales
        ThisMfm.ScaleIPh = 0.005
        ThisMfm.ScaleMw = 1.0 '0.0002
        ThisMfm.ScaleMvar = 1.0 '0.0002
        ThisMfm.ScaleMwhI = 1.0
        ThisMfm.ScaleMwhE = 1.0
        ThisMfm.ScalePf = 0.001
        ThisMfm.ScaleVL = 0.001732

        'Procedures (Higher Precidance over scale)
        ThisMfm.ProcedureIPh = ""
        ThisMfm.ProcedureMw = "If ReadValue > 8388608 Then" & vbCrLf & "     ReadValue = 5*(ReadValue - 16777215)*0.0001" & vbCrLf & "Else" & vbCrLf & "     ReadValue = 5*ReadValue*0.0001" & vbCrLf & "End If"
        ThisMfm.ProcedureMvar = "If ReadValue > 8388608 Then" & vbCrLf & "     ReadValue = 5*(ReadValue - 16777215)*0.0001" & vbCrLf & "Else" & vbCrLf & "     ReadValue = 5*ReadValue*0.0001" & vbCrLf & "End If"
        ThisMfm.ProcedureMwhI = ""
        ThisMfm.ProcedureMwhE = ""
        ThisMfm.ProcedurePf = ""
        ThisMfm.ProcedureVL = ""

    End Sub



    Public Sub SetSecureMeter4Properties(ByRef ThisMfm As Mfm.GeneralMfm)

        'General
        ThisMfm.Make = "Secure4"
        ThisMfm.Type = "Elite"
        ThisMfm.Bay = "Secure Bay"
        ThisMfm.ID = Format(255 * Rnd(), "000")
        ThisMfm.SrNo = Format(1000000 * Rnd(), "000000")    'Bay ID
        ThisMfm.BackColor = Color.LightPink
        ThisMfm.ReadHoldingReg = True

        'Addresses
        ThisMfm.AdrsIR = 55
        ThisMfm.AdrsIY = 57
        ThisMfm.AdrsIB = 59
        ThisMfm.AdrsMw = 65
        ThisMfm.AdrsMvar = 67
        ThisMfm.AdrsMwhI = 217
        ThisMfm.AdrsMwhE = 219
        ThisMfm.AdrsPf = 74
        ThisMfm.AdrsVL = 49

        'Variable Type
        ThisMfm.VerTypeIPh = Mfm.GeneralMfm.VerType.Unsigned32
        ThisMfm.VerTypeMw = Mfm.GeneralMfm.VerType.Unsigned32
        ThisMfm.VerTypeMvar = Mfm.GeneralMfm.VerType.Unsigned32
        ThisMfm.VerTypeMwhI = Mfm.GeneralMfm.VerType.Unsigned32
        ThisMfm.VerTypeMwhE = Mfm.GeneralMfm.VerType.Unsigned32
        ThisMfm.VerTypePf = Mfm.GeneralMfm.VerType.Signed16
        ThisMfm.VerTypeVL = Mfm.GeneralMfm.VerType.Unsigned32

        'Scales
        ThisMfm.ScaleIPh = 0.01
        ThisMfm.ScaleMw = 1.0 '0.0002
        ThisMfm.ScaleMvar = 1.0 '0.0002
        ThisMfm.ScaleMwhI = 1.0
        ThisMfm.ScaleMwhE = 1.0
        ThisMfm.ScalePf = 0.001
        ThisMfm.ScaleVL = 0.001732

        'Procedures (Higher Precidance over scale)
        ThisMfm.ProcedureIPh = ""
        ThisMfm.ProcedureMw = "If ReadValue > 8388608 Then" & vbCrLf & "     ReadValue = (ReadValue - 16777215)*0.001" & vbCrLf & "Else" & vbCrLf & "     ReadValue = ReadValue*0.001" & vbCrLf & "End If"
        ThisMfm.ProcedureMvar = "If ReadValue > 8388608 Then" & vbCrLf & "     ReadValue = (ReadValue - 16777215)*0.001" & vbCrLf & "Else" & vbCrLf & "     ReadValue = ReadValue*0.001" & vbCrLf & "End If"
        ThisMfm.ProcedureMwhI = ""
        ThisMfm.ProcedureMwhE = ""
        ThisMfm.ProcedurePf = ""
        ThisMfm.ProcedureVL = ""

    End Sub


    Public Sub SetCustomMeterProperties(ByRef ThisMfm As Mfm.GeneralMfm)

        'General
        ThisMfm.Make = "Custom"
        ThisMfm.Type = "New"
        ThisMfm.Bay = "Custom Bay"
        ThisMfm.ID = Format(255 * Rnd(), "000")
        ThisMfm.SrNo = Format(1000000 * Rnd(), "000000")    'Bay ID
        ThisMfm.BackColor = Color.LightGray
        ThisMfm.ReadHoldingReg = True

        'Addresses
        ThisMfm.AdrsIR = 55
        ThisMfm.AdrsIY = 57
        ThisMfm.AdrsIB = 59
        ThisMfm.AdrsMw = 65
        ThisMfm.AdrsMvar = 67
        ThisMfm.AdrsMwhI = 217
        ThisMfm.AdrsMwhE = 219
        ThisMfm.AdrsPf = 74
        ThisMfm.AdrsVL = 49

        'Variable Type
        ThisMfm.VerTypeIPh = Mfm.GeneralMfm.VerType.Unsigned32
        ThisMfm.VerTypeMw = Mfm.GeneralMfm.VerType.Unsigned32
        ThisMfm.VerTypeMvar = Mfm.GeneralMfm.VerType.Unsigned32
        ThisMfm.VerTypeMwhI = Mfm.GeneralMfm.VerType.Unsigned32
        ThisMfm.VerTypeMwhE = Mfm.GeneralMfm.VerType.Unsigned32
        ThisMfm.VerTypePf = Mfm.GeneralMfm.VerType.Signed16
        ThisMfm.VerTypeVL = Mfm.GeneralMfm.VerType.Unsigned32

        'Scales
        ThisMfm.ScaleIPh = 0.002
        ThisMfm.ScaleMw = 1.0 '0.0002
        ThisMfm.ScaleMvar = 1.0 '0.0002
        ThisMfm.ScaleMwhI = 1.0
        ThisMfm.ScaleMwhE = 1.0
        ThisMfm.ScalePf = 0.001
        ThisMfm.ScaleVL = 0.001732

        'Procedures (Higher Precidance over scale)
        ThisMfm.ProcedureIPh = ""
        ThisMfm.ProcedureMw = "If ReadValue > 8388608 Then" & vbCrLf & "     ReadValue = ReadValue - 16777215" & vbCrLf & "End If"
        ThisMfm.ProcedureMvar = "If ReadValue > 8388608 Then" & vbCrLf & "     ReadValue = ReadValue - 16777215" & vbCrLf & "End If"
        ThisMfm.ProcedureMwhI = ""
        ThisMfm.ProcedureMwhE = ""
        ThisMfm.ProcedurePf = ""
        ThisMfm.ProcedureVL = ""

    End Sub




    Public Sub SetRishbhMeterProperties(ByRef ThisMfm As Mfm.GeneralMfm)

        'General
        ThisMfm.Make = "Rishbh"
        ThisMfm.Type = "3430"
        ThisMfm.Bay = "Rishbh Bay"
        ThisMfm.ID = Format(255 * Rnd(), "000")
        ThisMfm.SrNo = Format(1000000 * Rnd(), "000000")    'Bay ID
        ThisMfm.BackColor = Color.LightBlue
        ThisMfm.ReadHoldingReg = False

        'Addresses
        ThisMfm.AdrsIR = 6
        ThisMfm.AdrsIY = 8
        ThisMfm.AdrsIB = 10
        ThisMfm.AdrsMw = 52
        ThisMfm.AdrsMvar = 60
        ThisMfm.AdrsMwhI = 72
        ThisMfm.AdrsMwhE = 74
        ThisMfm.AdrsPf = 62
        ThisMfm.AdrsVL = 0

        'Variable Type
        ThisMfm.VerTypeIPh = Mfm.GeneralMfm.VerType.Real
        ThisMfm.VerTypeMw = Mfm.GeneralMfm.VerType.Real
        ThisMfm.VerTypeMvar = Mfm.GeneralMfm.VerType.Real
        ThisMfm.VerTypeMwhI = Mfm.GeneralMfm.VerType.Real
        ThisMfm.VerTypeMwhE = Mfm.GeneralMfm.VerType.Real
        ThisMfm.VerTypePf = Mfm.GeneralMfm.VerType.Real
        ThisMfm.VerTypeVL = Mfm.GeneralMfm.VerType.Real

        'Scales
        ThisMfm.ScaleIPh = 1
        ThisMfm.ScaleMw = 0.000001
        ThisMfm.ScaleMvar = 0.000001
        ThisMfm.ScaleMwhI = 1.0
        ThisMfm.ScaleMwhE = 1.0
        ThisMfm.ScalePf = 1
        ThisMfm.ScaleVL = 0.001732

        'Procedures (Higher Precidance over scale)
        ThisMfm.ProcedureIPh = ""
        ThisMfm.ProcedureMw = ""
        ThisMfm.ProcedureMvar = ""
        ThisMfm.ProcedureMwhI = ""
        ThisMfm.ProcedureMwhE = ""
        ThisMfm.ProcedurePf = ""
        ThisMfm.ProcedureVL = ""

    End Sub



End Module
