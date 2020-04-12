<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.CmdRun = New System.Windows.Forms.ToolStripButton()
        Me.CmdEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.CmbPollingTimer = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.CmdAdd = New System.Windows.Forms.ToolStripDropDownButton()
        Me.CmdAddAcord = New System.Windows.Forms.ToolStripMenuItem()
        Me.CmdAddSecureElite = New System.Windows.Forms.ToolStripMenuItem()
        Me.CmdAddCustom = New System.Windows.Forms.ToolStripMenuItem()
        Me.SecureElite4ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CmdAddRishbh = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.CmbBaud = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.CmbPort = New System.Windows.Forms.ToolStripComboBox()
        Me.CmdConnect = New System.Windows.Forms.ToolStripButton()
        Me.CmdConnected = New System.Windows.Forms.ToolStripButton()
        Me.CmdNetSts = New System.Windows.Forms.ToolStripButton()
        Me.LblWebTick = New System.Windows.Forms.ToolStripLabel()
        Me.CmdClrPending = New System.Windows.Forms.ToolStripButton()
        Me.CmdClose = New System.Windows.Forms.ToolStripButton()
        Me.TimerPolling = New System.Windows.Forms.Timer(Me.components)
        Me.TimerWebUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SetIdTSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetBayNameTSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetBayIdTSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetColorTSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetModbusPropertiesTSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteTSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StsLblPendingRecords = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StsLblLastUploadDtTm = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StsLblRecUplodaed = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StsLblLastRefresh = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblBus1Kv = New System.Windows.Forms.Label()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LinkToUnitTSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblBus2Kv = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CmdRun, Me.CmdEdit, Me.ToolStripLabel3, Me.CmbPollingTimer, Me.ToolStripSeparator5, Me.ToolStripSeparator4, Me.CmdAdd, Me.ToolStripSeparator1, Me.ToolStripSeparator2, Me.ToolStripLabel1, Me.CmbBaud, Me.ToolStripSeparator3, Me.ToolStripLabel2, Me.CmbPort, Me.CmdConnect, Me.CmdConnected, Me.CmdNetSts, Me.LblWebTick, Me.CmdClrPending, Me.CmdClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.MinimumSize = New System.Drawing.Size(48, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1159, 39)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'CmdRun
        '
        Me.CmdRun.Enabled = False
        Me.CmdRun.Image = CType(resources.GetObject("CmdRun.Image"), System.Drawing.Image)
        Me.CmdRun.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CmdRun.Name = "CmdRun"
        Me.CmdRun.Size = New System.Drawing.Size(64, 36)
        Me.CmdRun.Text = "Run"
        '
        'CmdEdit
        '
        Me.CmdEdit.Enabled = False
        Me.CmdEdit.Image = CType(resources.GetObject("CmdEdit.Image"), System.Drawing.Image)
        Me.CmdEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CmdEdit.Name = "CmdEdit"
        Me.CmdEdit.Size = New System.Drawing.Size(67, 36)
        Me.CmdEdit.Text = "Stop"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(74, 36)
        Me.ToolStripLabel3.Text = "Polling Time"
        '
        'CmbPollingTimer
        '
        Me.CmbPollingTimer.Items.AddRange(New Object() {"1 Sec", "3 Sec", "5 Sec", "10 Sec", "1 Min", "3 Min", "5 Min"})
        Me.CmbPollingTimer.Name = "CmbPollingTimer"
        Me.CmbPollingTimer.Size = New System.Drawing.Size(75, 39)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 39)
        '
        'CmdAdd
        '
        Me.CmdAdd.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CmdAddAcord, Me.CmdAddSecureElite, Me.CmdAddCustom, Me.SecureElite4ToolStripMenuItem, Me.CmdAddRishbh})
        Me.CmdAdd.Image = CType(resources.GetObject("CmdAdd.Image"), System.Drawing.Image)
        Me.CmdAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(108, 36)
        Me.CmdAdd.Text = "Add Meter"
        '
        'CmdAddAcord
        '
        Me.CmdAddAcord.Name = "CmdAddAcord"
        Me.CmdAddAcord.Size = New System.Drawing.Size(137, 22)
        Me.CmdAddAcord.Text = "Acord"
        '
        'CmdAddSecureElite
        '
        Me.CmdAddSecureElite.Name = "CmdAddSecureElite"
        Me.CmdAddSecureElite.Size = New System.Drawing.Size(137, 22)
        Me.CmdAddSecureElite.Text = "SecureElite2"
        '
        'CmdAddCustom
        '
        Me.CmdAddCustom.Name = "CmdAddCustom"
        Me.CmdAddCustom.Size = New System.Drawing.Size(137, 22)
        Me.CmdAddCustom.Text = "Custom"
        '
        'SecureElite4ToolStripMenuItem
        '
        Me.SecureElite4ToolStripMenuItem.Name = "SecureElite4ToolStripMenuItem"
        Me.SecureElite4ToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.SecureElite4ToolStripMenuItem.Text = "SecureElite4"
        '
        'CmdAddRishbh
        '
        Me.CmdAddRishbh.Name = "CmdAddRishbh"
        Me.CmdAddRishbh.Size = New System.Drawing.Size(137, 22)
        Me.CmdAddRishbh.Text = "Rishbh"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(60, 36)
        Me.ToolStripLabel1.Text = "Baud Rate"
        '
        'CmbBaud
        '
        Me.CmbBaud.DropDownWidth = 60
        Me.CmbBaud.Items.AddRange(New Object() {"1200", "2400", "4800", "9600", "19200"})
        Me.CmbBaud.Name = "CmbBaud"
        Me.CmbBaud.Size = New System.Drawing.Size(75, 39)
        Me.CmbBaud.ToolTipText = "CmbBaud"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(29, 36)
        Me.ToolStripLabel2.Text = "Port"
        '
        'CmbPort
        '
        Me.CmbPort.DropDownWidth = 60
        Me.CmbPort.Items.AddRange(New Object() {"COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10", "COM11", "COM12"})
        Me.CmbPort.Name = "CmbPort"
        Me.CmbPort.Size = New System.Drawing.Size(75, 39)
        '
        'CmdConnect
        '
        Me.CmdConnect.BackColor = System.Drawing.SystemColors.Highlight
        Me.CmdConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.CmdConnect.Enabled = False
        Me.CmdConnect.Image = CType(resources.GetObject("CmdConnect.Image"), System.Drawing.Image)
        Me.CmdConnect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CmdConnect.Name = "CmdConnect"
        Me.CmdConnect.Size = New System.Drawing.Size(56, 36)
        Me.CmdConnect.Text = "Connect"
        '
        'CmdConnected
        '
        Me.CmdConnected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CmdConnected.Enabled = False
        Me.CmdConnected.Image = CType(resources.GetObject("CmdConnected.Image"), System.Drawing.Image)
        Me.CmdConnected.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.CmdConnected.Name = "CmdConnected"
        Me.CmdConnected.Size = New System.Drawing.Size(36, 36)
        Me.CmdConnected.Text = "Connected"
        '
        'CmdNetSts
        '
        Me.CmdNetSts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CmdNetSts.Enabled = False
        Me.CmdNetSts.Image = CType(resources.GetObject("CmdNetSts.Image"), System.Drawing.Image)
        Me.CmdNetSts.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CmdNetSts.Name = "CmdNetSts"
        Me.CmdNetSts.Size = New System.Drawing.Size(36, 36)
        Me.CmdNetSts.Text = "ToolStripButton1"
        '
        'LblWebTick
        '
        Me.LblWebTick.Name = "LblWebTick"
        Me.LblWebTick.Size = New System.Drawing.Size(50, 36)
        Me.LblWebTick.Text = "HH:mm"
        '
        'CmdClrPending
        '
        Me.CmdClrPending.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CmdClrPending.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.CmdClrPending.Image = CType(resources.GetObject("CmdClrPending.Image"), System.Drawing.Image)
        Me.CmdClrPending.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CmdClrPending.Name = "CmdClrPending"
        Me.CmdClrPending.Size = New System.Drawing.Size(38, 36)
        Me.CmdClrPending.Text = "Celar"
        '
        'CmdClose
        '
        Me.CmdClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CmdClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.CmdClose.Image = CType(resources.GetObject("CmdClose.Image"), System.Drawing.Image)
        Me.CmdClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CmdClose.Name = "CmdClose"
        Me.CmdClose.Size = New System.Drawing.Size(40, 36)
        Me.CmdClose.Text = "Close"
        '
        'TimerPolling
        '
        Me.TimerPolling.Interval = 100000
        '
        'TimerWebUpdate
        '
        Me.TimerWebUpdate.Interval = 60000
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetIdTSMI, Me.SetBayNameTSMI, Me.SetBayIdTSMI, Me.SetColorTSMI, Me.SetModbusPropertiesTSMI, Me.DeleteTSMI})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(188, 136)
        '
        'SetIdTSMI
        '
        Me.SetIdTSMI.Name = "SetIdTSMI"
        Me.SetIdTSMI.Size = New System.Drawing.Size(187, 22)
        Me.SetIdTSMI.Text = "SetID"
        '
        'SetBayNameTSMI
        '
        Me.SetBayNameTSMI.Name = "SetBayNameTSMI"
        Me.SetBayNameTSMI.Size = New System.Drawing.Size(187, 22)
        Me.SetBayNameTSMI.Text = "SetBayName"
        '
        'SetBayIdTSMI
        '
        Me.SetBayIdTSMI.Name = "SetBayIdTSMI"
        Me.SetBayIdTSMI.Size = New System.Drawing.Size(187, 22)
        Me.SetBayIdTSMI.Text = "SetBayId"
        '
        'SetColorTSMI
        '
        Me.SetColorTSMI.Name = "SetColorTSMI"
        Me.SetColorTSMI.Size = New System.Drawing.Size(187, 22)
        Me.SetColorTSMI.Text = "SetColor"
        '
        'SetModbusPropertiesTSMI
        '
        Me.SetModbusPropertiesTSMI.Name = "SetModbusPropertiesTSMI"
        Me.SetModbusPropertiesTSMI.Size = New System.Drawing.Size(187, 22)
        Me.SetModbusPropertiesTSMI.Text = "SetModbusProperties"
        '
        'DeleteTSMI
        '
        Me.DeleteTSMI.Name = "DeleteTSMI"
        Me.DeleteTSMI.Size = New System.Drawing.Size(187, 22)
        Me.DeleteTSMI.Text = "Delete"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.Top
        Me.StatusStrip1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.StsLblPendingRecords, Me.ToolStripStatusLabel3, Me.StsLblLastUploadDtTm, Me.ToolStripStatusLabel2, Me.StsLblRecUplodaed, Me.ToolStripStatusLabel4, Me.StsLblLastRefresh})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 39)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1159, 23)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(129, 18)
        Me.ToolStripStatusLabel1.Text = "Pending Records"
        '
        'StsLblPendingRecords
        '
        Me.StsLblPendingRecords.AutoSize = False
        Me.StsLblPendingRecords.Name = "StsLblPendingRecords"
        Me.StsLblPendingRecords.Size = New System.Drawing.Size(60, 18)
        Me.StsLblPendingRecords.Text = "000"
        Me.StsLblPendingRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(130, 18)
        Me.ToolStripStatusLabel3.Text = "Last Upload Time"
        '
        'StsLblLastUploadDtTm
        '
        Me.StsLblLastUploadDtTm.AutoSize = False
        Me.StsLblLastUploadDtTm.Name = "StsLblLastUploadDtTm"
        Me.StsLblLastUploadDtTm.Size = New System.Drawing.Size(140, 18)
        Me.StsLblLastUploadDtTm.Text = "21/02/20 16:42"
        Me.StsLblLastUploadDtTm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(164, 18)
        Me.ToolStripStatusLabel2.Text = "Last records uploaded"
        '
        'StsLblRecUplodaed
        '
        Me.StsLblRecUplodaed.AutoSize = False
        Me.StsLblRecUplodaed.Name = "StsLblRecUplodaed"
        Me.StsLblRecUplodaed.Size = New System.Drawing.Size(60, 18)
        Me.StsLblRecUplodaed.Text = "000"
        Me.StsLblRecUplodaed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(154, 18)
        Me.ToolStripStatusLabel4.Text = "Screen Refreshed @"
        '
        'StsLblLastRefresh
        '
        Me.StsLblLastRefresh.Name = "StsLblLastRefresh"
        Me.StsLblLastRefresh.Size = New System.Drawing.Size(60, 18)
        Me.StsLblLastRefresh.Text = "HH:mm"
        '
        'lblBus1Kv
        '
        Me.lblBus1Kv.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblBus1Kv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBus1Kv.ContextMenuStrip = Me.ContextMenuStrip2
        Me.lblBus1Kv.Font = New System.Drawing.Font("Arial", 14.0!)
        Me.lblBus1Kv.Location = New System.Drawing.Point(90, 66)
        Me.lblBus1Kv.Name = "lblBus1Kv"
        Me.lblBus1Kv.Size = New System.Drawing.Size(105, 30)
        Me.lblBus1Kv.TabIndex = 2
        Me.lblBus1Kv.Text = "###.##"
        Me.lblBus1Kv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LinkToUnitTSMI})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(147, 26)
        '
        'LinkToUnitTSMI
        '
        Me.LinkToUnitTSMI.Name = "LinkToUnitTSMI"
        Me.LinkToUnitTSMI.Size = New System.Drawing.Size(146, 22)
        Me.LinkToUnitTSMI.Text = "Link to UnitID"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Bus1-kV"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBus2Kv
        '
        Me.lblBus2Kv.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblBus2Kv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBus2Kv.ContextMenuStrip = Me.ContextMenuStrip2
        Me.lblBus2Kv.Font = New System.Drawing.Font("Arial", 14.0!)
        Me.lblBus2Kv.Location = New System.Drawing.Point(283, 66)
        Me.lblBus2Kv.Name = "lblBus2Kv"
        Me.lblBus2Kv.Size = New System.Drawing.Size(100, 30)
        Me.lblBus2Kv.TabIndex = 5
        Me.lblBus2Kv.Text = "###.##"
        Me.lblBus2Kv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(201, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 23)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Bus2-kV"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1159, 733)
        Me.Controls.Add(Me.lblBus2Kv)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblBus1Kv)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "MainForm"
        Me.Text = "PowerLinkV2: New Substation"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents CmdRun As System.Windows.Forms.ToolStripButton
    Friend WithEvents CmdEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents CmdAdd As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents CmdAddAcord As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmdAddSecureElite As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimerPolling As System.Windows.Forms.Timer
    Friend WithEvents TimerWebUpdate As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CmbBaud As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CmbPort As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents CmdConnected As System.Windows.Forms.ToolStripButton
    Friend WithEvents CmdConnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents CmdAddCustom As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SetIdTSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetBayNameTSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetColorTSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetModbusPropertiesTSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetBayIdTSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents DeleteTSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SecureElite4ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmdAddRishbh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CmbPollingTimer As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StsLblPendingRecords As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StsLblLastUploadDtTm As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StsLblRecUplodaed As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StsLblLastRefresh As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CmdClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents CmdNetSts As System.Windows.Forms.ToolStripButton
    Friend WithEvents LblWebTick As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CmdClrPending As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblBus1Kv As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblBus2Kv As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents LinkToUnitTSMI As System.Windows.Forms.ToolStripMenuItem

End Class
