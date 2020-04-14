<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUnlock
    Inherits eTraceUI.eTraceForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TimerStatus1 As eTraceUI.TimerStatus = New eTraceUI.TimerStatus()
        Me.pnlBody = New eTraceUI.eTracePanel()
        Me.grpCurrentLocks = New eTraceUI.eTraceGroupBox()
        Me.dgvLocks = New eTraceUI.eTraceDataGridView()
        Me.Slectecd = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Line = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Model = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PCBA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Process = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FailTestStep = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LockedOn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LockType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Details = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ETraceTableLayoutPanel1 = New eTraceUI.eTraceTableLayoutPanel()
        Me.txtDetails = New eTraceUI.eTraceTextBox()
        Me.lblPQE = New eTraceUI.eTraceLabel()
        Me.lblDetails = New eTraceUI.eTraceLabel()
        Me.lblLockType = New eTraceUI.eTraceLabel()
        Me.txtLockType = New eTraceUI.eTraceTextBox()
        Me.txtRemarks = New eTraceUI.eTraceTextBox()
        Me.lblRemarks = New eTraceUI.eTraceLabel()
        Me.lblPBR = New eTraceUI.eTraceLabel()
        Me.txtPBR = New eTraceUI.eTraceTextBox()
        Me.lblPE = New eTraceUI.eTraceLabel()
        Me.txtOthers = New eTraceUI.eTraceTextBox()
        Me.lblOthers = New eTraceUI.eTraceLabel()
        Me.txtPE = New eTraceUI.eTraceTextBox()
        Me.txtTE = New eTraceUI.eTraceTextBox()
        Me.lblTE = New eTraceUI.eTraceLabel()
        Me.txtPQE = New eTraceUI.eTraceTextBox()
        Me.txtSymptom = New eTraceUI.eTraceTextBox()
        Me.lblSymptom = New eTraceUI.eTraceLabel()
        Me.grpProcess = New eTraceUI.eTraceGroupBox()
        Me.pnlProcess = New eTraceUI.eTraceTableLayoutPanel()
        Me.chkShowUnlocked = New eTraceUI.eTraceCheckBox()
        Me.RadioBtnCurrentLine = New eTraceUI.eTraceRadioButton()
        Me.RadioBtnAllLine = New eTraceUI.eTraceRadioButton()
        Me.lblProcess = New eTraceUI.eTraceLabel()
        Me.ddlProcess = New eTraceUI.eTraceComboBox()
        Me.btnEMI = New eTraceUI.eTraceButton()
        Me.grpActions = New eTraceUI.eTraceGroupBox()
        Me.pnlActions = New eTraceUI.eTraceTableLayoutPanel()
        Me.txtCardNo = New eTraceUI.eTraceTextBox()
        Me.btnPost = New eTraceUI.eTraceButton()
        Me.btnRefresh = New eTraceUI.eTraceButton()
        Me.btnUnlock = New eTraceUI.eTraceButton()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.bgwPost = New System.ComponentModel.BackgroundWorker()
        Me.bgwUnlock = New System.ComponentModel.BackgroundWorker()
        Me.bgwLoadLocks = New System.ComponentModel.BackgroundWorker()
        Me.pnlBody.SuspendLayout()
        Me.grpCurrentLocks.SuspendLayout()
        CType(Me.dgvLocks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ETraceTableLayoutPanel1.SuspendLayout()
        Me.grpProcess.SuspendLayout()
        Me.pnlProcess.SuspendLayout()
        Me.grpActions.SuspendLayout()
        Me.pnlActions.SuspendLayout()
        Me.SuspendLayout()
        '
        'MessageBar1
        '
        Me.MessageBar1.Location = New System.Drawing.Point(0, 574)
        Me.MessageBar1.Size = New System.Drawing.Size(791, 22)
        '
        'pnlBody
        '
        Me.pnlBody.Controls.Add(Me.grpCurrentLocks)
        Me.pnlBody.Controls.Add(Me.grpProcess)
        Me.pnlBody.Controls.Add(Me.grpActions)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Location = New System.Drawing.Point(0, 54)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Size = New System.Drawing.Size(791, 520)
        Me.pnlBody.TabIndex = 2
        '
        'grpCurrentLocks
        '
        Me.grpCurrentLocks.Controls.Add(Me.dgvLocks)
        Me.grpCurrentLocks.Controls.Add(Me.ETraceTableLayoutPanel1)
        Me.grpCurrentLocks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpCurrentLocks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCurrentLocks.Location = New System.Drawing.Point(0, 47)
        Me.grpCurrentLocks.Name = "grpCurrentLocks"
        Me.grpCurrentLocks.Size = New System.Drawing.Size(791, 422)
        Me.grpCurrentLocks.TabIndex = 2
        Me.grpCurrentLocks.TabStop = False
        Me.grpCurrentLocks.Tag = "^SFC-159@"
        Me.grpCurrentLocks.Text = "Current Locks"
        '
        'dgvLocks
        '
        Me.dgvLocks.AllowUserToAddRows = False
        Me.dgvLocks.AllowUserToDeleteRows = False
        Me.dgvLocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLocks.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Slectecd, Me.Line, Me.Model, Me.PCBA, Me.Process, Me.FailTestStep, Me.LockedOn, Me.Status, Me.LockType, Me.Details})
        Me.dgvLocks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLocks.Location = New System.Drawing.Point(3, 16)
        Me.dgvLocks.MultiSelect = False
        Me.dgvLocks.Name = "dgvLocks"
        Me.dgvLocks.RowHeadersWidth = 23
        Me.dgvLocks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLocks.Size = New System.Drawing.Size(785, 253)
        Me.dgvLocks.TabIndex = 22
        Me.dgvLocks.TabStop = False
        '
        'Slectecd
        '
        Me.Slectecd.HeaderText = ""
        Me.Slectecd.Name = "Slectecd"
        Me.Slectecd.ReadOnly = True
        Me.Slectecd.Width = 30
        '
        'Line
        '
        Me.Line.DataPropertyName = "Line"
        Me.Line.HeaderText = "Line"
        Me.Line.Name = "Line"
        Me.Line.ReadOnly = True
        Me.Line.ToolTipText = "Line"
        '
        'Model
        '
        Me.Model.DataPropertyName = "Model"
        Me.Model.HeaderText = "Model"
        Me.Model.Name = "Model"
        Me.Model.ReadOnly = True
        Me.Model.ToolTipText = "Model"
        '
        'PCBA
        '
        Me.PCBA.DataPropertyName = "PCBA"
        Me.PCBA.HeaderText = "PCBA"
        Me.PCBA.Name = "PCBA"
        Me.PCBA.ReadOnly = True
        Me.PCBA.ToolTipText = "PCBA"
        '
        'Process
        '
        Me.Process.DataPropertyName = "ProcessHead"
        Me.Process.HeaderText = "Process"
        Me.Process.Name = "Process"
        Me.Process.ReadOnly = True
        Me.Process.ToolTipText = "ProcessHead"
        '
        'FailTestStep
        '
        Me.FailTestStep.DataPropertyName = "FailTestStep"
        Me.FailTestStep.HeaderText = "FailTestStep"
        Me.FailTestStep.Name = "FailTestStep"
        Me.FailTestStep.ReadOnly = True
        Me.FailTestStep.ToolTipText = "FailTestStep"
        '
        'LockedOn
        '
        Me.LockedOn.DataPropertyName = "LockedOn"
        Me.LockedOn.HeaderText = "LockedOn"
        Me.LockedOn.Name = "LockedOn"
        Me.LockedOn.ReadOnly = True
        Me.LockedOn.ToolTipText = "LockedOn"
        Me.LockedOn.Width = 150
        '
        'Status
        '
        Me.Status.DataPropertyName = "LockStatus"
        Me.Status.HeaderText = "LockStatus"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.ToolTipText = "LockStatus"
        '
        'LockType
        '
        Me.LockType.DataPropertyName = "LockType"
        Me.LockType.HeaderText = "LockType"
        Me.LockType.Name = "LockType"
        Me.LockType.ReadOnly = True
        Me.LockType.ToolTipText = "LockType"
        '
        'Details
        '
        Me.Details.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Details.DataPropertyName = "Details"
        Me.Details.HeaderText = "Details"
        Me.Details.MinimumWidth = 100
        Me.Details.Name = "Details"
        Me.Details.ReadOnly = True
        Me.Details.ToolTipText = "Details"
        '
        'ETraceTableLayoutPanel1
        '
        Me.ETraceTableLayoutPanel1.ColumnCount = 10
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtDetails, 1, 4)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblDetails, 0, 4)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblLockType, 5, 3)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtLockType, 6, 3)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtRemarks, 1, 3)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblRemarks, 0, 3)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblPBR, 5, 2)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtPBR, 6, 2)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtOthers, 1, 2)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblOthers, 0, 2)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtPE, 1, 1)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblPQE, 5, 1)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtTE, 6, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblTE, 5, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtPQE, 6, 1)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtSymptom, 1, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblSymptom, 0, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblPE, 0, 1)
        Me.ETraceTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ETraceTableLayoutPanel1.Location = New System.Drawing.Point(3, 269)
        Me.ETraceTableLayoutPanel1.Name = "ETraceTableLayoutPanel1"
        Me.ETraceTableLayoutPanel1.RowCount = 5
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ETraceTableLayoutPanel1.Size = New System.Drawing.Size(785, 150)
        Me.ETraceTableLayoutPanel1.TabIndex = 2
        '
        'txtDetails
        '
        Me.txtDetails.BackColor = System.Drawing.SystemColors.Window
        Me.txtDetails.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.txtDetails, 8)
        Me.txtDetails.DataType = Nothing
        Me.txtDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDetails.ElementTitle = Me.lblPQE
        Me.txtDetails.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtDetails.ErrorMessage = Nothing
        Me.txtDetails.KeyIn = True
        Me.txtDetails.Location = New System.Drawing.Point(139, 107)
        Me.txtDetails.Multiline = True
        Me.txtDetails.Name = "txtDetails"
        Me.txtDetails.NoOfDecimals = 0
        Me.txtDetails.ParentControl = Nothing
        Me.txtDetails.RegEx = Nothing
        Me.txtDetails.Required = False
        Me.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDetails.Size = New System.Drawing.Size(578, 40)
        Me.txtDetails.StatusControl = Nothing
        Me.txtDetails.TabIndex = 28
        Me.txtDetails.Tag = "Details"
        Me.txtDetails.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtDetails.ValidationType = Nothing
        Me.txtDetails.WarnColor = System.Drawing.Color.Wheat
        '
        'lblPQE
        '
        Me.lblPQE.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPQE.Location = New System.Drawing.Point(395, 32)
        Me.lblPQE.Name = "lblPQE"
        Me.lblPQE.Size = New System.Drawing.Size(130, 14)
        Me.lblPQE.TabIndex = 19
        Me.lblPQE.Tag = "PQE"
        Me.lblPQE.Text = "PQE"
        '
        'lblDetails
        '
        Me.lblDetails.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDetails.Location = New System.Drawing.Point(3, 120)
        Me.lblDetails.Name = "lblDetails"
        Me.lblDetails.Size = New System.Drawing.Size(130, 14)
        Me.lblDetails.TabIndex = 27
        Me.lblDetails.Tag = "Details"
        Me.lblDetails.Text = "Details"
        '
        'lblLockType
        '
        Me.lblLockType.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblLockType.Location = New System.Drawing.Point(395, 84)
        Me.lblLockType.Name = "lblLockType"
        Me.lblLockType.Size = New System.Drawing.Size(130, 14)
        Me.lblLockType.TabIndex = 26
        Me.lblLockType.Tag = "LockType"
        Me.lblLockType.Text = "LockType"
        '
        'txtLockType
        '
        Me.txtLockType.BackColor = System.Drawing.SystemColors.Window
        Me.txtLockType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.txtLockType, 3)
        Me.txtLockType.DataType = Nothing
        Me.txtLockType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLockType.ElementTitle = Me.lblPQE
        Me.txtLockType.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtLockType.ErrorMessage = Nothing
        Me.txtLockType.KeyIn = True
        Me.txtLockType.Location = New System.Drawing.Point(531, 81)
        Me.txtLockType.Name = "txtLockType"
        Me.txtLockType.NoOfDecimals = 0
        Me.txtLockType.ParentControl = Nothing
        Me.txtLockType.RegEx = Nothing
        Me.txtLockType.Required = False
        Me.txtLockType.Size = New System.Drawing.Size(186, 20)
        Me.txtLockType.StatusControl = Nothing
        Me.txtLockType.TabIndex = 25
        Me.txtLockType.Tag = "LockType"
        Me.txtLockType.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtLockType.ValidationType = Nothing
        Me.txtLockType.WarnColor = System.Drawing.Color.Wheat
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.SystemColors.Window
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.txtRemarks, 3)
        Me.txtRemarks.DataType = Nothing
        Me.txtRemarks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRemarks.ElementTitle = Me.lblPQE
        Me.txtRemarks.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtRemarks.ErrorMessage = Nothing
        Me.txtRemarks.KeyIn = True
        Me.txtRemarks.Location = New System.Drawing.Point(139, 81)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.NoOfDecimals = 0
        Me.txtRemarks.ParentControl = Nothing
        Me.txtRemarks.RegEx = Nothing
        Me.txtRemarks.Required = False
        Me.txtRemarks.Size = New System.Drawing.Size(186, 20)
        Me.txtRemarks.StatusControl = Nothing
        Me.txtRemarks.TabIndex = 10
        Me.txtRemarks.Tag = "IntSerial"
        Me.txtRemarks.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtRemarks.ValidationType = Nothing
        Me.txtRemarks.WarnColor = System.Drawing.Color.Wheat
        '
        'lblRemarks
        '
        Me.lblRemarks.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRemarks.Location = New System.Drawing.Point(3, 84)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(130, 14)
        Me.lblRemarks.TabIndex = 24
        Me.lblRemarks.Tag = "Remarks"
        Me.lblRemarks.Text = "Remarks"
        '
        'lblPBR
        '
        Me.lblPBR.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPBR.Location = New System.Drawing.Point(395, 58)
        Me.lblPBR.Name = "lblPBR"
        Me.lblPBR.Size = New System.Drawing.Size(130, 14)
        Me.lblPBR.TabIndex = 23
        Me.lblPBR.Tag = "PBR"
        Me.lblPBR.Text = "PBR"
        '
        'txtPBR
        '
        Me.txtPBR.BackColor = System.Drawing.SystemColors.Window
        Me.txtPBR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.txtPBR, 3)
        Me.txtPBR.DataType = Nothing
        Me.txtPBR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPBR.ElementTitle = Me.lblPE
        Me.txtPBR.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtPBR.ErrorMessage = Nothing
        Me.txtPBR.KeyIn = True
        Me.txtPBR.Location = New System.Drawing.Point(531, 55)
        Me.txtPBR.Name = "txtPBR"
        Me.txtPBR.NoOfDecimals = 0
        Me.txtPBR.ParentControl = Nothing
        Me.txtPBR.RegEx = Nothing
        Me.txtPBR.Required = False
        Me.txtPBR.Size = New System.Drawing.Size(186, 20)
        Me.txtPBR.StatusControl = Nothing
        Me.txtPBR.TabIndex = 9
        Me.txtPBR.Tag = "PBR"
        Me.txtPBR.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtPBR.ValidationType = Nothing
        Me.txtPBR.WarnColor = System.Drawing.Color.Wheat
        '
        'lblPE
        '
        Me.lblPE.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPE.Location = New System.Drawing.Point(3, 32)
        Me.lblPE.Name = "lblPE"
        Me.lblPE.Size = New System.Drawing.Size(130, 14)
        Me.lblPE.TabIndex = 15
        Me.lblPE.Tag = "PE"
        Me.lblPE.Text = "PE"
        '
        'txtOthers
        '
        Me.txtOthers.BackColor = System.Drawing.SystemColors.Window
        Me.txtOthers.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.txtOthers, 3)
        Me.txtOthers.DataType = Nothing
        Me.txtOthers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOthers.ElementTitle = Me.lblPQE
        Me.txtOthers.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtOthers.ErrorMessage = Nothing
        Me.txtOthers.KeyIn = True
        Me.txtOthers.Location = New System.Drawing.Point(139, 55)
        Me.txtOthers.Name = "txtOthers"
        Me.txtOthers.NoOfDecimals = 0
        Me.txtOthers.ParentControl = Nothing
        Me.txtOthers.RegEx = Nothing
        Me.txtOthers.Required = False
        Me.txtOthers.Size = New System.Drawing.Size(186, 20)
        Me.txtOthers.StatusControl = Nothing
        Me.txtOthers.TabIndex = 8
        Me.txtOthers.Tag = "Others"
        Me.txtOthers.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtOthers.ValidationType = Nothing
        Me.txtOthers.WarnColor = System.Drawing.Color.Wheat
        '
        'lblOthers
        '
        Me.lblOthers.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblOthers.Location = New System.Drawing.Point(3, 58)
        Me.lblOthers.Name = "lblOthers"
        Me.lblOthers.Size = New System.Drawing.Size(130, 14)
        Me.lblOthers.TabIndex = 20
        Me.lblOthers.Tag = "Others"
        Me.lblOthers.Text = "Others"
        '
        'txtPE
        '
        Me.txtPE.BackColor = System.Drawing.SystemColors.Window
        Me.txtPE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.txtPE, 3)
        Me.txtPE.DataType = Nothing
        Me.txtPE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPE.ElementTitle = Me.lblPQE
        Me.txtPE.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtPE.ErrorMessage = Nothing
        Me.txtPE.KeyIn = True
        Me.txtPE.Location = New System.Drawing.Point(139, 29)
        Me.txtPE.Name = "txtPE"
        Me.txtPE.NoOfDecimals = 0
        Me.txtPE.ParentControl = Nothing
        Me.txtPE.RegEx = Nothing
        Me.txtPE.Required = False
        Me.txtPE.Size = New System.Drawing.Size(186, 20)
        Me.txtPE.StatusControl = Nothing
        Me.txtPE.TabIndex = 6
        Me.txtPE.Tag = "PE"
        Me.txtPE.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtPE.ValidationType = Nothing
        Me.txtPE.WarnColor = System.Drawing.Color.Wheat
        '
        'txtTE
        '
        Me.txtTE.BackColor = System.Drawing.SystemColors.Window
        Me.txtTE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.txtTE, 3)
        Me.txtTE.DataType = Nothing
        Me.txtTE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTE.ElementTitle = Me.lblTE
        Me.txtTE.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtTE.ErrorMessage = Nothing
        Me.txtTE.KeyIn = True
        Me.txtTE.Location = New System.Drawing.Point(531, 3)
        Me.txtTE.Name = "txtTE"
        Me.txtTE.NoOfDecimals = 0
        Me.txtTE.ParentControl = Nothing
        Me.txtTE.RegEx = Nothing
        Me.txtTE.Required = False
        Me.txtTE.Size = New System.Drawing.Size(186, 20)
        Me.txtTE.StatusControl = Nothing
        Me.txtTE.TabIndex = 5
        Me.txtTE.Tag = "TE"
        Me.txtTE.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtTE.ValidationType = Nothing
        Me.txtTE.WarnColor = System.Drawing.Color.Wheat
        '
        'lblTE
        '
        Me.lblTE.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTE.Location = New System.Drawing.Point(395, 6)
        Me.lblTE.Name = "lblTE"
        Me.lblTE.Size = New System.Drawing.Size(130, 14)
        Me.lblTE.TabIndex = 17
        Me.lblTE.Tag = "TE"
        Me.lblTE.Text = "TE"
        '
        'txtPQE
        '
        Me.txtPQE.BackColor = System.Drawing.SystemColors.Window
        Me.txtPQE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.txtPQE, 3)
        Me.txtPQE.DataType = Nothing
        Me.txtPQE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPQE.ElementTitle = Me.lblPE
        Me.txtPQE.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtPQE.ErrorMessage = Nothing
        Me.txtPQE.KeyIn = True
        Me.txtPQE.Location = New System.Drawing.Point(531, 29)
        Me.txtPQE.Name = "txtPQE"
        Me.txtPQE.NoOfDecimals = 0
        Me.txtPQE.ParentControl = Nothing
        Me.txtPQE.RegEx = Nothing
        Me.txtPQE.Required = False
        Me.txtPQE.Size = New System.Drawing.Size(186, 20)
        Me.txtPQE.StatusControl = Nothing
        Me.txtPQE.TabIndex = 7
        Me.txtPQE.Tag = "PQE"
        Me.txtPQE.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtPQE.ValidationType = Nothing
        Me.txtPQE.WarnColor = System.Drawing.Color.Wheat
        '
        'txtSymptom
        '
        Me.txtSymptom.BackColor = System.Drawing.SystemColors.Window
        Me.txtSymptom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.txtSymptom, 3)
        Me.txtSymptom.DataType = Nothing
        Me.txtSymptom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSymptom.ElementTitle = Me.lblSymptom
        Me.txtSymptom.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtSymptom.ErrorMessage = Nothing
        Me.txtSymptom.KeyIn = True
        Me.txtSymptom.Location = New System.Drawing.Point(139, 3)
        Me.txtSymptom.Name = "txtSymptom"
        Me.txtSymptom.NoOfDecimals = 0
        Me.txtSymptom.ParentControl = Nothing
        Me.txtSymptom.RegEx = Nothing
        Me.txtSymptom.Required = False
        Me.txtSymptom.Size = New System.Drawing.Size(186, 20)
        Me.txtSymptom.StatusControl = Nothing
        Me.txtSymptom.TabIndex = 4
        Me.txtSymptom.Tag = "Symptom"
        Me.txtSymptom.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtSymptom.ValidationType = Nothing
        Me.txtSymptom.WarnColor = System.Drawing.Color.Wheat
        '
        'lblSymptom
        '
        Me.lblSymptom.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSymptom.Location = New System.Drawing.Point(3, 6)
        Me.lblSymptom.Name = "lblSymptom"
        Me.lblSymptom.Size = New System.Drawing.Size(130, 14)
        Me.lblSymptom.TabIndex = 14
        Me.lblSymptom.Tag = "Symptom"
        Me.lblSymptom.Text = "Symptom"
        '
        'grpProcess
        '
        Me.grpProcess.Controls.Add(Me.pnlProcess)
        Me.grpProcess.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.grpProcess.Location = New System.Drawing.Point(0, 0)
        Me.grpProcess.Name = "grpProcess"
        Me.grpProcess.Size = New System.Drawing.Size(791, 47)
        Me.grpProcess.TabIndex = 0
        Me.grpProcess.TabStop = False
        Me.grpProcess.Tag = "^TDC-0@"
        Me.grpProcess.Text = "Process"
        '
        'pnlProcess
        '
        Me.pnlProcess.ColumnCount = 10
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlProcess.Controls.Add(Me.chkShowUnlocked, 9, 0)
        Me.pnlProcess.Controls.Add(Me.RadioBtnCurrentLine, 7, 0)
        Me.pnlProcess.Controls.Add(Me.RadioBtnAllLine, 8, 0)
        Me.pnlProcess.Controls.Add(Me.lblProcess, 0, 0)
        Me.pnlProcess.Controls.Add(Me.ddlProcess, 1, 0)
        Me.pnlProcess.Controls.Add(Me.btnEMI, 3, 0)
        Me.pnlProcess.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlProcess.Location = New System.Drawing.Point(3, 16)
        Me.pnlProcess.Name = "pnlProcess"
        Me.pnlProcess.RowCount = 1
        Me.pnlProcess.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlProcess.Size = New System.Drawing.Size(785, 28)
        Me.pnlProcess.TabIndex = 2
        '
        'chkShowUnlocked
        '
        Me.chkShowUnlocked.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkShowUnlocked.AutoSize = True
        Me.chkShowUnlocked.Location = New System.Drawing.Point(544, 3)
        Me.chkShowUnlocked.Name = "chkShowUnlocked"
        Me.chkShowUnlocked.Size = New System.Drawing.Size(115, 22)
        Me.chkShowUnlocked.TabIndex = 17
        Me.chkShowUnlocked.TabStop = False
        Me.chkShowUnlocked.Tag = "ShowUnlocked"
        Me.chkShowUnlocked.Text = "Show Unlocked"
        Me.chkShowUnlocked.UseVisualStyleBackColor = True
        '
        'RadioBtnCurrentLine
        '
        Me.RadioBtnCurrentLine.AutoSize = True
        Me.RadioBtnCurrentLine.Checked = True
        Me.RadioBtnCurrentLine.Location = New System.Drawing.Point(403, 3)
        Me.RadioBtnCurrentLine.Name = "RadioBtnCurrentLine"
        Me.RadioBtnCurrentLine.Size = New System.Drawing.Size(90, 17)
        Me.RadioBtnCurrentLine.TabIndex = 20
        Me.RadioBtnCurrentLine.TabStop = True
        Me.RadioBtnCurrentLine.Tag = "CurrentLine"
        Me.RadioBtnCurrentLine.Text = "CurrentLine"
        Me.RadioBtnCurrentLine.UseVisualStyleBackColor = True
        '
        'RadioBtnAllLine
        '
        Me.RadioBtnAllLine.AutoSize = True
        Me.RadioBtnAllLine.Location = New System.Drawing.Point(499, 3)
        Me.RadioBtnAllLine.Name = "RadioBtnAllLine"
        Me.RadioBtnAllLine.Size = New System.Drawing.Size(39, 17)
        Me.RadioBtnAllLine.TabIndex = 21
        Me.RadioBtnAllLine.Tag = "All"
        Me.RadioBtnAllLine.Text = "All"
        Me.RadioBtnAllLine.UseVisualStyleBackColor = True
        '
        'lblProcess
        '
        Me.lblProcess.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblProcess.Location = New System.Drawing.Point(3, 7)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(130, 14)
        Me.lblProcess.TabIndex = 0
        Me.lblProcess.Tag = "^TDC-0@"
        Me.lblProcess.Text = "Process"
        '
        'ddlProcess
        '
        Me.ddlProcess.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ddlProcess.DataType = Nothing
        Me.ddlProcess.ElementTitle = Me.lblProcess
        Me.ddlProcess.Enabled = False
        Me.ddlProcess.ErrorColor = System.Drawing.Color.DarkOrange
        Me.ddlProcess.ErrorMessage = Nothing
        Me.ddlProcess.FormattingEnabled = True
        Me.ddlProcess.ItemDataTable = Nothing
        Me.ddlProcess.ItemDesc = Nothing
        Me.ddlProcess.ItemID = Nothing
        Me.ddlProcess.ItemSelect = eTraceUI.eTraceComboBox.ItemSelects.None
        Me.ddlProcess.ItemValue = Nothing
        Me.ddlProcess.LimitToList = True
        Me.ddlProcess.Location = New System.Drawing.Point(139, 3)
        Me.ddlProcess.MaxDropDownItems = 20
        Me.ddlProcess.Name = "ddlProcess"
        Me.ddlProcess.NoOfDecimals = 0
        Me.ddlProcess.ParentControl = Nothing
        Me.ddlProcess.RegEx = Nothing
        Me.ddlProcess.Required = False
        Me.ddlProcess.Size = New System.Drawing.Size(150, 21)
        Me.ddlProcess.StatusControl = Nothing
        Me.ddlProcess.TabIndex = 1
        Me.ddlProcess.TextCase = eTraceUI.eTraceComboBox.TextCases.None
        Me.ddlProcess.ValidationType = Nothing
        Me.ddlProcess.WarnColor = System.Drawing.Color.Wheat
        '
        'btnEMI
        '
        Me.btnEMI.AutoSize = True
        Me.btnEMI.Location = New System.Drawing.Point(315, 3)
        Me.btnEMI.Name = "btnEMI"
        Me.btnEMI.Size = New System.Drawing.Size(62, 22)
        Me.btnEMI.TabIndex = 19
        Me.btnEMI.Tag = "^SFC-36@"
        Me.btnEMI.Text = "ShowMI"
        Me.btnEMI.UseVisualStyleBackColor = True
        Me.btnEMI.Visible = False
        '
        'grpActions
        '
        Me.grpActions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.grpActions.Controls.Add(Me.pnlActions)
        Me.grpActions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpActions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpActions.Location = New System.Drawing.Point(0, 469)
        Me.grpActions.Name = "grpActions"
        Me.grpActions.Size = New System.Drawing.Size(791, 51)
        Me.grpActions.TabIndex = 4
        Me.grpActions.TabStop = False
        Me.grpActions.Tag = "^APP-13@"
        Me.grpActions.Text = "Actions"
        '
        'pnlActions
        '
        Me.pnlActions.ColumnCount = 8
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlActions.Controls.Add(Me.txtCardNo, 6, 0)
        Me.pnlActions.Controls.Add(Me.btnPost, 2, 0)
        Me.pnlActions.Controls.Add(Me.btnRefresh, 0, 0)
        Me.pnlActions.Controls.Add(Me.btnUnlock, 4, 0)
        Me.pnlActions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlActions.Location = New System.Drawing.Point(3, 16)
        Me.pnlActions.Name = "pnlActions"
        Me.pnlActions.RowCount = 1
        Me.pnlActions.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlActions.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.pnlActions.Size = New System.Drawing.Size(785, 32)
        Me.pnlActions.TabIndex = 0
        '
        'txtCardNo
        '
        Me.txtCardNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtCardNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCardNo.DataType = Nothing
        Me.txtCardNo.ElementTitle = Nothing
        Me.txtCardNo.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtCardNo.ErrorMessage = Nothing
        Me.txtCardNo.KeyIn = True
        Me.txtCardNo.Location = New System.Drawing.Point(321, 3)
        Me.txtCardNo.Name = "txtCardNo"
        Me.txtCardNo.NoOfDecimals = 0
        Me.txtCardNo.ParentControl = Nothing
        Me.txtCardNo.RegEx = Nothing
        Me.txtCardNo.Required = False
        Me.txtCardNo.Size = New System.Drawing.Size(200, 20)
        Me.txtCardNo.StatusControl = Nothing
        Me.txtCardNo.TabIndex = 5
        Me.txtCardNo.Tag = "CardNo"
        Me.txtCardNo.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtCardNo.ValidationType = Nothing
        Me.txtCardNo.Visible = False
        Me.txtCardNo.WarnColor = System.Drawing.Color.Wheat
        '
        'btnPost
        '
        Me.btnPost.Location = New System.Drawing.Point(109, 3)
        Me.btnPost.Name = "btnPost"
        Me.btnPost.Size = New System.Drawing.Size(90, 26)
        Me.btnPost.TabIndex = 0
        Me.btnPost.Tag = "^APP-22@"
        Me.btnPost.Text = "&Save [F8]"
        Me.btnPost.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(3, 3)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(90, 26)
        Me.btnRefresh.TabIndex = 0
        Me.btnRefresh.Tag = "^SFC-158@"
        Me.btnRefresh.Text = "&Refresh[F5]"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnUnlock
        '
        Me.btnUnlock.Enabled = False
        Me.btnUnlock.Location = New System.Drawing.Point(215, 3)
        Me.btnUnlock.Name = "btnUnlock"
        Me.btnUnlock.Size = New System.Drawing.Size(90, 26)
        Me.btnUnlock.TabIndex = 0
        Me.btnUnlock.Tag = "^SFC-151@"
        Me.btnUnlock.Text = "&Unlock[F3]"
        Me.btnUnlock.UseVisualStyleBackColor = True
        '
        'bgwPost
        '
        '
        'bgwUnlock
        '
        '
        'bgwLoadLocks
        '
        '
        'frmUnlock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(791, 596)
        Me.Controls.Add(Me.pnlBody)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "frmUnlock"
        TimerStatus1.Frequencies = eTraceUI.Frequencies.Second
        TimerStatus1.Interval = 0
        TimerStatus1.Start = False
        Me.TimerStatus = TimerStatus1
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.Controls.SetChildIndex(Me.MessageBar1, 0)
        Me.Controls.SetChildIndex(Me.pnlBody, 0)
        Me.pnlBody.ResumeLayout(False)
        Me.grpCurrentLocks.ResumeLayout(False)
        CType(Me.dgvLocks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ETraceTableLayoutPanel1.ResumeLayout(False)
        Me.ETraceTableLayoutPanel1.PerformLayout()
        Me.grpProcess.ResumeLayout(False)
        Me.pnlProcess.ResumeLayout(False)
        Me.pnlProcess.PerformLayout()
        Me.grpActions.ResumeLayout(False)
        Me.pnlActions.ResumeLayout(False)
        Me.pnlActions.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBody As eTraceUI.eTracePanel
    Friend WithEvents grpProcess As eTraceUI.eTraceGroupBox
    Friend WithEvents pnlProcess As eTraceUI.eTraceTableLayoutPanel
    Friend WithEvents lblProcess As eTraceUI.eTraceLabel
    Friend WithEvents ddlProcess As eTraceUI.eTraceComboBox
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents grpCurrentLocks As eTraceUI.eTraceGroupBox
    Friend WithEvents grpActions As eTraceUI.eTraceGroupBox
    Friend WithEvents pnlActions As eTraceUI.eTraceTableLayoutPanel
    Friend WithEvents btnPost As eTraceUI.eTraceButton
    Friend WithEvents btnRefresh As eTraceUI.eTraceButton
    Friend WithEvents btnUnlock As eTraceUI.eTraceButton
    Friend WithEvents bgwPost As System.ComponentModel.BackgroundWorker
    Friend WithEvents ETraceTableLayoutPanel1 As eTraceUI.eTraceTableLayoutPanel
    Friend WithEvents txtPQE As eTraceUI.eTraceTextBox
    Friend WithEvents txtSymptom As eTraceUI.eTraceTextBox
    Friend WithEvents lblSymptom As eTraceUI.eTraceLabel
    Friend WithEvents lblPE As eTraceUI.eTraceLabel
    Friend WithEvents bgwUnlock As System.ComponentModel.BackgroundWorker
    Friend WithEvents RadioBtnCurrentLine As eTraceUI.eTraceRadioButton
    Friend WithEvents RadioBtnAllLine As eTraceUI.eTraceRadioButton
    Friend WithEvents txtTE As eTraceUI.eTraceTextBox
    Friend WithEvents lblTE As eTraceUI.eTraceLabel
    Friend WithEvents dgvLocks As eTraceUI.eTraceDataGridView
    Friend WithEvents txtRemarks As eTraceUI.eTraceTextBox
    Friend WithEvents lblPQE As eTraceUI.eTraceLabel
    Friend WithEvents lblRemarks As eTraceUI.eTraceLabel
    Friend WithEvents lblPBR As eTraceUI.eTraceLabel
    Friend WithEvents txtPBR As eTraceUI.eTraceTextBox
    Friend WithEvents txtOthers As eTraceUI.eTraceTextBox
    Friend WithEvents lblOthers As eTraceUI.eTraceLabel
    Friend WithEvents txtPE As eTraceUI.eTraceTextBox
    Friend WithEvents btnEMI As eTraceUI.eTraceButton
    Friend WithEvents bgwLoadLocks As System.ComponentModel.BackgroundWorker
    Friend WithEvents chkShowUnlocked As eTraceUI.eTraceCheckBox
    Friend WithEvents txtCardNo As eTraceUI.eTraceTextBox
    Friend WithEvents Slectecd As DataGridViewCheckBoxColumn
    Friend WithEvents Line As DataGridViewTextBoxColumn
    Friend WithEvents Model As DataGridViewTextBoxColumn
    Friend WithEvents PCBA As DataGridViewTextBoxColumn
    Friend WithEvents Process As DataGridViewTextBoxColumn
    Friend WithEvents FailTestStep As DataGridViewTextBoxColumn
    Friend WithEvents LockedOn As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents LockType As DataGridViewTextBoxColumn
    Friend WithEvents Details As DataGridViewTextBoxColumn
    Friend WithEvents txtDetails As eTraceUI.eTraceTextBox
    Friend WithEvents lblDetails As eTraceUI.eTraceLabel
    Friend WithEvents lblLockType As eTraceUI.eTraceLabel
    Friend WithEvents txtLockType As eTraceUI.eTraceTextBox
End Class
