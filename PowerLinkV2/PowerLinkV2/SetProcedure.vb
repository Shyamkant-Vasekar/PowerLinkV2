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