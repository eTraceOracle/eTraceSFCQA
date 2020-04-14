<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFixtureMount
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
        Me.grpActions = New eTraceUI.eTraceGroupBox()
        Me.pnlActions = New eTraceUI.eTraceTableLayoutPanel()
        Me.btnPost = New eTraceUI.eTraceButton()
        Me.btnCancel = New eTraceUI.eTraceButton()
        Me.grpDataInput = New eTraceUI.eTraceGroupBox()
        Me.ETraceTableLayoutPanel1 = New eTraceUI.eTraceTableLayoutPanel()
        Me.txtSize = New eTraceUI.eTraceTextBox()
        Me.lblSize = New eTraceUI.eTraceLabel()
        Me.dgvResult = New eTraceUI.eTraceDataGridView()
        Me.txtIntSN = New eTraceUI.eTraceTextBox()
        Me.lblIntSN = New eTraceUI.eTraceLabel()
        Me.txtFixtureID = New eTraceUI.eTraceTextBox()
        Me.lblFixtureID = New eTraceUI.eTraceLabel()
        Me.lblSizeAdded = New eTraceUI.eTraceLabel()
        Me.grpProcess = New eTraceUI.eTraceGroupBox()
        Me.pnlProcess = New eTraceUI.eTraceTableLayoutPanel()
        Me.lblProcess = New eTraceUI.eTraceLabel()
        Me.ddlProcess = New eTraceUI.eTraceComboBox()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.bgwPost = New System.ComponentModel.BackgroundWorker()
        Me.bgwIntSerial = New System.ComponentModel.BackgroundWorker()
        Me.bgwFixtureID = New System.ComponentModel.BackgroundWorker()
        Me.IntSN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PCBA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Process = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlBody.SuspendLayout()
        Me.grpActions.SuspendLayout()
        Me.pnlActions.SuspendLayout()
        Me.grpDataInput.SuspendLayout()
        Me.ETraceTableLayoutPanel1.SuspendLayout()
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpProcess.SuspendLayout()
        Me.pnlProcess.SuspendLayout()
        Me.SuspendLayout()
        '
        'MessageBar1
        '
        Me.MessageBar1.Location = New System.Drawing.Point(0, 574)
        Me.MessageBar1.Size = New System.Drawing.Size(791, 22)
        '
        'pnlBody
        '
        Me.pnlBody.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBody.Controls.Add(Me.grpActions)
        Me.pnlBody.Controls.Add(Me.grpDataInput)
        Me.pnlBody.Controls.Add(Me.grpProcess)
        Me.pnlBody.Location = New System.Drawing.Point(0, 54)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Size = New System.Drawing.Size(789, 521)
        Me.pnlBody.TabIndex = 2
        '
        'grpActions
        '
        Me.grpActions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpActions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.grpActions.Controls.Add(Me.pnlActions)
        Me.grpActions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpActions.Location = New System.Drawing.Point(3, 464)
        Me.grpActions.Name = "grpActions"
        Me.grpActions.Size = New System.Drawing.Size(783, 51)
        Me.grpActions.TabIndex = 4
        Me.grpActions.TabStop = False
        Me.grpActions.Tag = "^APP-13@"
        Me.grpActions.Text = "Actions"
        '
        'pnlActions
        '
        Me.pnlActions.ColumnCount = 4
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 595.0!))
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlActions.Controls.Add(Me.btnPost, 0, 0)
        Me.pnlActions.Controls.Add(Me.btnCancel, 2, 0)
        Me.pnlActions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlActions.Location = New System.Drawing.Point(3, 16)
        Me.pnlActions.Name = "pnlActions"
        Me.pnlActions.RowCount = 1
        Me.pnlActions.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlActions.Size = New System.Drawing.Size(777, 32)
        Me.pnlActions.TabIndex = 0
        '
        'btnPost
        '
        Me.btnPost.Location = New System.Drawing.Point(3, 3)
        Me.btnPost.Name = "btnPost"
        Me.btnPost.Size = New System.Drawing.Size(80, 26)
        Me.btnPost.TabIndex = 0
        Me.btnPost.Tag = "^APP-22@"
        Me.btnPost.Text = "&Save [F8]"
        Me.btnPost.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(99, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 26)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Tag = "^APP-7@"
        Me.btnCancel.Text = "&Cancel [F8]"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'grpDataInput
        '
        Me.grpDataInput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDataInput.Controls.Add(Me.ETraceTableLayoutPanel1)
        Me.grpDataInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDataInput.Location = New System.Drawing.Point(3, 54)
        Me.grpDataInput.Name = "grpDataInput"
        Me.grpDataInput.Size = New System.Drawing.Size(783, 408)
        Me.grpDataInput.TabIndex = 2
        Me.grpDataInput.TabStop = False
        Me.grpDataInput.Tag = "^TDC-2@"
        Me.grpDataInput.Text = "Data Input"
        '
        'ETraceTableLayoutPanel1
        '
        Me.ETraceTableLayoutPanel1.ColumnCount = 8
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblSizeAdded, 4, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtSize, 5, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.dgvResult, 0, 2)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtIntSN, 1, 1)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtFixtureID, 1, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblFixtureID, 0, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblIntSN, 0, 1)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblSize, 3, 0)
        Me.ETraceTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ETraceTableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.ETraceTableLayoutPanel1.Name = "ETraceTableLayoutPanel1"
        Me.ETraceTableLayoutPanel1.RowCount = 3
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ETraceTableLayoutPanel1.Size = New System.Drawing.Size(777, 389)
        Me.ETraceTableLayoutPanel1.TabIndex = 2
        '
        'txtSize
        '
        Me.txtSize.BackColor = System.Drawing.SystemColors.Window
        Me.txtSize.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSize.DataType = Nothing
        Me.txtSize.ElementTitle = Me.lblSize
        Me.txtSize.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtSize.ErrorMessage = Nothing
        Me.txtSize.KeyIn = True
        Me.txtSize.Location = New System.Drawing.Point(457, 3)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.NoOfDecimals = 0
        Me.txtSize.ParentControl = Nothing
        Me.txtSize.RegEx = Nothing
        Me.txtSize.Required = False
        Me.txtSize.Size = New System.Drawing.Size(120, 20)
        Me.txtSize.StatusControl = Nothing
        Me.txtSize.TabIndex = 3
        Me.txtSize.Tag = "Size"
        Me.txtSize.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtSize.ValidationType = Nothing
        Me.txtSize.WarnColor = System.Drawing.Color.Wheat
        '
        'lblSize
        '
        Me.lblSize.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSize.Location = New System.Drawing.Point(285, 6)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(130, 14)
        Me.lblSize.TabIndex = 23
        Me.lblSize.Tag = "Size"
        Me.lblSize.Text = "Size"
        '
        'dgvResult
        '
        Me.dgvResult.AllowUserToAddRows = False
        Me.dgvResult.AllowUserToDeleteRows = False
        Me.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResult.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IntSN, Me.PCBA, Me.Process})
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.dgvResult, 10)
        Me.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResult.Location = New System.Drawing.Point(3, 55)
        Me.dgvResult.MultiSelect = False
        Me.dgvResult.Name = "dgvResult"
        Me.dgvResult.RowHeadersWidth = 23
        Me.dgvResult.Size = New System.Drawing.Size(773, 380)
        Me.dgvResult.TabIndex = 21
        Me.dgvResult.TabStop = False
        '
        'txtIntSN
        '
        Me.txtIntSN.BackColor = System.Drawing.SystemColors.Window
        Me.txtIntSN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIntSN.DataType = Nothing
        Me.txtIntSN.ElementTitle = Me.lblIntSN
        Me.txtIntSN.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtIntSN.ErrorMessage = Nothing
        Me.txtIntSN.KeyIn = True
        Me.txtIntSN.Location = New System.Drawing.Point(139, 29)
        Me.txtIntSN.Name = "txtIntSN"
        Me.txtIntSN.NoOfDecimals = 0
        Me.txtIntSN.ParentControl = Nothing
        Me.txtIntSN.RegEx = Nothing
        Me.txtIntSN.Required = False
        Me.txtIntSN.Size = New System.Drawing.Size(120, 20)
        Me.txtIntSN.StatusControl = Nothing
        Me.txtIntSN.TabIndex = 4
        Me.txtIntSN.Tag = "IntSerial"
        Me.txtIntSN.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtIntSN.ValidationType = Nothing
        Me.txtIntSN.WarnColor = System.Drawing.Color.Wheat
        '
        'lblIntSN
        '
        Me.lblIntSN.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblIntSN.Location = New System.Drawing.Point(3, 32)
        Me.lblIntSN.Name = "lblIntSN"
        Me.lblIntSN.Size = New System.Drawing.Size(130, 14)
        Me.lblIntSN.TabIndex = 15
        Me.lblIntSN.Tag = "IntSerial"
        Me.lblIntSN.Text = "Int. Serial No"
        '
        'txtFixtureID
        '
        Me.txtFixtureID.BackColor = System.Drawing.SystemColors.Window
        Me.txtFixtureID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFixtureID.DataType = Nothing
        Me.txtFixtureID.ElementTitle = Me.lblFixtureID
        Me.txtFixtureID.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtFixtureID.ErrorMessage = Nothing
        Me.txtFixtureID.KeyIn = True
        Me.txtFixtureID.Location = New System.Drawing.Point(139, 3)
        Me.txtFixtureID.Name = "txtFixtureID"
        Me.txtFixtureID.NoOfDecimals = 0
        Me.txtFixtureID.ParentControl = Nothing
        Me.txtFixtureID.RegEx = Nothing
        Me.txtFixtureID.Required = False
        Me.txtFixtureID.Size = New System.Drawing.Size(120, 20)
        Me.txtFixtureID.StatusControl = Nothing
        Me.txtFixtureID.TabIndex = 2
        Me.txtFixtureID.Tag = "FixtureID"
        Me.txtFixtureID.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtFixtureID.ValidationType = Nothing
        Me.txtFixtureID.WarnColor = System.Drawing.Color.Wheat
        '
        'lblFixtureID
        '
        Me.lblFixtureID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblFixtureID.Location = New System.Drawing.Point(3, 6)
        Me.lblFixtureID.Name = "lblFixtureID"
        Me.lblFixtureID.Size = New System.Drawing.Size(130, 14)
        Me.lblFixtureID.TabIndex = 14
        Me.lblFixtureID.Tag = "FixtureID"
        Me.lblFixtureID.Text = "FixtureID"
        '
        'lblSizeAdded
        '
        Me.lblSizeAdded.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSizeAdded.Location = New System.Drawing.Point(421, 6)
        Me.lblSizeAdded.Name = "lblSizeAdded"
        Me.lblSizeAdded.Size = New System.Drawing.Size(30, 14)
        Me.lblSizeAdded.TabIndex = 23
        Me.lblSizeAdded.Tag = ""
        Me.lblSizeAdded.Text = "0/"
        Me.lblSizeAdded.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'grpProcess
        '
        Me.grpProcess.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpProcess.Controls.Add(Me.pnlProcess)
        Me.grpProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.grpProcess.Location = New System.Drawing.Point(3, 4)
        Me.grpProcess.Name = "grpProcess"
        Me.grpProcess.Size = New System.Drawing.Size(784, 47)
        Me.grpProcess.TabIndex = 0
        Me.grpProcess.TabStop = False
        Me.grpProcess.Tag = "^TDC-0@"
        Me.grpProcess.Text = "Process"
        '
        'pnlProcess
        '
        Me.pnlProcess.ColumnCount = 3
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 417.0!))
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlProcess.Controls.Add(Me.lblProcess, 0, 0)
        Me.pnlProcess.Controls.Add(Me.ddlProcess, 1, 0)
        Me.pnlProcess.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlProcess.Location = New System.Drawing.Point(3, 16)
        Me.pnlProcess.Name = "pnlProcess"
        Me.pnlProcess.RowCount = 1
        Me.pnlProcess.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlProcess.Size = New System.Drawing.Size(778, 28)
        Me.pnlProcess.TabIndex = 2
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
        Me.ddlProcess.Size = New System.Drawing.Size(219, 21)
        Me.ddlProcess.StatusControl = Nothing
        Me.ddlProcess.TabIndex = 1
        Me.ddlProcess.TextCase = eTraceUI.eTraceComboBox.TextCases.None
        Me.ddlProcess.ValidationType = Nothing
        Me.ddlProcess.WarnColor = System.Drawing.Color.Wheat
        '
        'SerialPort1
        '
        '
        'bgwPost
        '
        '
        'bgwIntSerial
        '
        '
        'bgwFixtureID
        '
        '
        'IntSN
        '
        Me.IntSN.DataPropertyName = "IntSN"
        Me.IntSN.HeaderText = "Int. Serial No"
        Me.IntSN.Name = "IntSN"
        Me.IntSN.ReadOnly = True
        Me.IntSN.ToolTipText = "IntSN"
        Me.IntSN.Width = 200
        '
        'PCBA
        '
        Me.PCBA.DataPropertyName = "PCBA"
        Me.PCBA.HeaderText = "PCBA"
        Me.PCBA.Name = "PCBA"
        Me.PCBA.ReadOnly = True
        Me.PCBA.ToolTipText = "PCBA"
        Me.PCBA.Width = 200
        '
        'Process
        '
        Me.Process.DataPropertyName = "Process"
        Me.Process.HeaderText = "Process"
        Me.Process.Name = "Process"
        Me.Process.ReadOnly = True
        Me.Process.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Process.ToolTipText = "Process"
        '
        'frmFixtureMount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(791, 596)
        Me.Controls.Add(Me.pnlBody)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "frmFixtureMount"
        TimerStatus1.Frequencies = eTraceUI.Frequencies.Second
        TimerStatus1.Interval = 0
        TimerStatus1.Start = False
        Me.TimerStatus = TimerStatus1
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.Controls.SetChildIndex(Me.pnlBody, 0)
        Me.Controls.SetChildIndex(Me.MessageBar1, 0)
        Me.pnlBody.ResumeLayout(False)
        Me.grpActions.ResumeLayout(False)
        Me.pnlActions.ResumeLayout(False)
        Me.grpDataInput.ResumeLayout(False)
        Me.ETraceTableLayoutPanel1.ResumeLayout(False)
        Me.ETraceTableLayoutPanel1.PerformLayout()
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpProcess.ResumeLayout(False)
        Me.pnlProcess.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBody As eTraceUI.eTracePanel
    Friend WithEvents grpProcess As eTraceUI.eTraceGroupBox
    Friend WithEvents pnlProcess As eTraceUI.eTraceTableLayoutPanel
    Friend WithEvents lblProcess As eTraceUI.eTraceLabel
    Friend WithEvents ddlProcess As eTraceUI.eTraceComboBox
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents grpDataInput As eTraceUI.eTraceGroupBox
    Friend WithEvents grpActions As eTraceUI.eTraceGroupBox
    Friend WithEvents pnlActions As eTraceUI.eTraceTableLayoutPanel
    Friend WithEvents btnPost As eTraceUI.eTraceButton
    Friend WithEvents bgwPost As System.ComponentModel.BackgroundWorker
    Friend WithEvents ETraceTableLayoutPanel1 As eTraceUI.eTraceTableLayoutPanel
    Friend WithEvents bgwIntSerial As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwFixtureID As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblSize As eTraceUI.eTraceLabel
    Friend WithEvents txtSize As eTraceUI.eTraceTextBox
    Friend WithEvents lblIntSN As eTraceUI.eTraceLabel
    Friend WithEvents dgvResult As eTraceUI.eTraceDataGridView
    Friend WithEvents txtIntSN As eTraceUI.eTraceTextBox
    Friend WithEvents txtFixtureID As eTraceUI.eTraceTextBox
    Friend WithEvents lblFixtureID As eTraceUI.eTraceLabel
    Friend WithEvents btnCancel As eTraceUI.eTraceButton
    Friend WithEvents lblSizeAdded As eTraceUI.eTraceLabel
    Friend WithEvents IntSN As DataGridViewTextBoxColumn
    Friend WithEvents PCBA As DataGridViewTextBoxColumn
    Friend WithEvents Process As DataGridViewTextBoxColumn
End Class
