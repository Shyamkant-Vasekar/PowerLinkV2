<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetProcedure
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TxtFxn = New System.Windows.Forms.TextBox()
        Me.CmdOk = New System.Windows.Forms.Button()
        Me.CmdCancel = New System.Windows.Forms.Button()
        Me.LblFxnHeader = New System.Windows.Forms.Label()
        Me.LblFxnFooter = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TxtFxn
        '
        Me.TxtFxn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFxn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtFxn.Location = New System.Drawing.Point(12, 83)
        Me.TxtFxn.Multiline = True
        Me.TxtFxn.Name = "TxtFxn"
        Me.TxtFxn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtFxn.Size = New System.Drawing.Size(494, 179)
        Me.TxtFxn.TabIndex = 0
        Me.TxtFxn.Text = "              If ReadValue > 127 Then" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "                        ReadValue = ReadVa" & _
    "lue - 256" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "              End If" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'CmdOk
        '
        Me.CmdOk.Location = New System.Drawing.Point(431, 306)
        Me.CmdOk.Name = "CmdOk"
        Me.CmdOk.Size = New System.Drawing.Size(75, 33)
        Me.CmdOk.TabIndex = 1
        Me.CmdOk.Text = "OK"
        Me.CmdOk.UseVisualStyleBackColor = True
        '
        'CmdCancel
        '
        Me.CmdCancel.Location = New System.Drawing.Point(15, 306)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(75, 33)
        Me.CmdCancel.TabIndex = 2
        Me.CmdCancel.Text = "Cancel"
        Me.CmdCancel.UseVisualStyleBackColor = True
        '
        'LblFxnHeader
        '
        Me.LblFxnHeader.BackColor = System.Drawing.Color.White
        Me.LblFxnHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblFxnHeader.ForeColor = System.Drawing.Color.Gray
        Me.LblFxnHeader.Location = New System.Drawing.Point(12, 51)
        Me.LblFxnHeader.Name = "LblFxnHeader"
        Me.LblFxnHeader.Size = New System.Drawing.Size(494, 29)
        Me.LblFxnHeader.TabIndex = 3
        Me.LblFxnHeader.Text = "Public Function ScaleValue(ReadValue)"
        '
        'LblFxnFooter
        '
        Me.LblFxnFooter.BackColor = System.Drawing.Color.White
        Me.LblFxnFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblFxnFooter.ForeColor = System.Drawing.Color.Gray
        Me.LblFxnFooter.Location = New System.Drawing.Point(12, 265)
        Me.LblFxnFooter.Name = "LblFxnFooter"
        Me.LblFxnFooter.Size = New System.Drawing.Size(494, 38)
        Me.LblFxnFooter.TabIndex = 4
        Me.LblFxnFooter.Text = "         ScaleValue = ReadValue" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "End Function"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(315, 41)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Script for converting value read from Mfm suitably (Language VBScript)"
        '
        'SetProcedure
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(518, 360)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblFxnFooter)
        Me.Controls.Add(Me.LblFxnHeader)
        Me.Controls.Add(Me.CmdCancel)
        Me.Controls.Add(Me.CmdOk)
        Me.Controls.Add(Me.TxtFxn)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SetProcedure"
        Me.Text = "Set Procedure"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtFxn As System.Windows.Forms.TextBox
    Friend WithEvents CmdOk As System.Windows.Forms.Button
    Friend WithEvents CmdCancel As System.Windows.Forms.Button
    Friend WithEvents LblFxnHeader As System.Windows.Forms.Label
    Friend WithEvents LblFxnFooter As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
