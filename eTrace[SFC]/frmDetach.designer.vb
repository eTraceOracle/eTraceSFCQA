<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDetach
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
        Me.btnPrint = New eTraceUI.eTraceButton()
        Me.btnPost = New eTraceUI.eTraceButton()
        Me.btnNew = New eTraceUI.eTraceButton()
        Me.btnReset = New eTraceUI.eTraceButton()
        Me.grpDataInput = New eTraceUI.eTraceGroupBox()
        Me.ETraceTableLayoutPanel1 = New eTraceUI.eTraceTableLayoutPanel()
        Me.dgvSubPCBAList = New eTraceUI.eTraceDataGridView()
        Me.Process = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Result = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtSubPCBASerialNo = New eTraceUI.eTraceTextBox()
        Me.lblPCBASerial = New eTraceUI.eTraceLabel()
        Me.lblIntserial = New eTraceUI.eTraceLabel()
        Me.txtPCBASerialNo = New eTraceUI.eTraceTextBox()
        Me.grpModel = New eTraceUI.eTraceGroupBox()
        Me.pnlModel = New eTraceUI.eTraceTableLayoutPanel()
        Me.txtPCBANo = New eTraceUI.eTraceTextBox()
        Me.lblPCBANo = New eTraceUI.eTraceLabel()
        Me.txtModelNo = New eTraceUI.eTraceTextBox()
        Me.lblModel = New eTraceUI.eTraceLabel()
        Me.lblPONo = New eTraceUI.eTraceLabel()
        Me.txtPONo = New eTraceUI.eTraceTextBox()
        Me.grpProcess = New eTraceUI.eTraceGroupBox()
        Me.pnlProcess = New eTraceUI.eTraceTableLayoutPanel()
        Me.lblProcess = New eTraceUI.eTraceLabel()
        Me.ddlProcess = New eTraceUI.eTraceComboBox()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.bgwPost = New System.ComponentModel.BackgroundWorker()
        Me.bgwPO = New System.ComponentModel.BackgroundWorker()
        Me.bgwPoQty = New System.ComponentModel.BackgroundWorker()
        Me.bgwIntSerial = New System.ComponentModel.BackgroundWorker()
        Me.bgwSubPCBA = New System.ComponentModel.BackgroundWorker()
        Me.pnlBody.SuspendLayout()
        Me.grpActions.SuspendLayout()
        Me.pnlActions.SuspendLayout()
        Me.grpDataInput.SuspendLayout()
        Me.ETraceTableLayoutPanel1.SuspendLayout()
        CType(Me.dgvSubPCBAList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpModel.SuspendLayout()
        Me.pnlModel.SuspendLayout()
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
        Me.pnlBody.Controls.Add(Me.grpModel)
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
        Me.pnlActions.ColumnCount = 7
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlActions.Controls.Add(Me.btnPrint, 6, 0)
        Me.pnlActions.Controls.Add(Me.btnPost, 0, 0)
        Me.pnlActions.Controls.Add(Me.btnNew, 2, 0)
        Me.pnlActions.Controls.Add(Me.btnReset, 4, 0)
        Me.pnlActions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlActions.Location = New System.Drawing.Point(3, 16)
        Me.pnlActions.Name = "pnlActions"
        Me.pnlActions.RowCount = 1
        Me.pnlActions.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlActions.Size = New System.Drawing.Size(777, 32)
        Me.pnlActions.TabIndex = 0
        '
        'btnPrint
        '
        Me.btnPrint.AutoSize = True
        Me.btnPrint.Location = New System.Drawing.Point(276, 3)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 26)
        Me.btnPrint.TabIndex = 1
        Me.btnPrint.Tag = "^APP-52@"
        Me.btnPrint.Text = "&Print[F9]"
        Me.btnPrint.UseVisualStyleBackColor = True
        Me.btnPrint.Visible = False
        '
        'btnPost
        '
        Me.btnPost.Location = New System.Drawing.Point(3, 3)
        Me.btnPost.Name = "btnPost"
        Me.btnPost.Size = New System.Drawing.Size(75, 26)
        Me.btnPost.TabIndex = 0
        Me.btnPost.Tag = "^APP-22@"
        Me.btnPost.Text = "&Save [F8]"
        Me.btnPost.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(94, 3)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 26)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Tag = "^APP-15@"
        Me.btnNew.Text = "&New [F5]"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(185, 3)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 26)
        Me.btnReset.TabIndex = 0
        Me.btnReset.Tag = "^APP-21@"
        Me.btnReset.Text = "&Reset[F3]"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'grpDataInput
        '
        Me.grpDataInput.Controls.Add(Me.ETraceTableLayoutPanel1)
        Me.grpDataInput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDataInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDataInput.Location = New System.Drawing.Point(0, 95)
        Me.grpDataInput.Name = "grpDataInput"
        Me.grpDataInput.Size = New System.Drawing.Size(789, 426)
        Me.grpDataInput.TabIndex = 2
        Me.grpDataInput.TabStop = False
        Me.grpDataInput.Tag = "^TDC-2@"
        Me.grpDataInput.Text = "Data Input"
        '
        'ETraceTableLayoutPanel1
        '
        Me.ETraceTableLayoutPanel1.AutoSize = True
        Me.ETraceTableLayoutPanel1.ColumnCount = 7
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 6.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.dgvSubPCBAList, 0, 3)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtSubPCBASerialNo, 1, 2)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblPCBASerial, 0, 2)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblIntserial, 0, 1)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtPCBASerialNo, 1, 1)
        Me.ETraceTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ETraceTableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.ETraceTableLayoutPanel1.Name = "ETraceTableLayoutPanel1"
        Me.ETraceTableLayoutPanel1.RowCount = 4
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.ETraceTableLayoutPanel1.Size = New System.Drawing.Size(783, 407)
        Me.ETraceTableLayoutPanel1.TabIndex = 1
        '
        'dgvSubPCBAList
        '
        Me.dgvSubPCBAList.AllowUserToAddRows = False
        Me.dgvSubPCBAList.AllowUserToDeleteRows = False
        Me.dgvSubPCBAList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSubPCBAList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSubPCBAList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Process, Me.Result})
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.dgvSubPCBAList, 7)
        Me.dgvSubPCBAList.Location = New System.Drawing.Point(3, 55)
        Me.dgvSubPCBAList.MultiSelect = False
        Me.dgvSubPCBAList.Name = "dgvSubPCBAList"
        Me.dgvSubPCBAList.RowHeadersWidth = 23
        Me.dgvSubPCBAList.Size = New System.Drawing.Size(777, 349)
        Me.dgvSubPCBAList.TabIndex = 20
        Me.dgvSubPCBAList.TabStop = False
        '
        'Process
        '
        Me.Process.DataPropertyName = "IntSN"
        Me.Process.HeaderText = "IntSN"
        Me.Process.Name = "Process"
        Me.Process.ReadOnly = True
        Me.Process.ToolTipText = "IntSN"
        Me.Process.Width = 200
        '
        'Result
        '
        Me.Result.DataPropertyName = "PCBA"
        Me.Result.HeaderText = "PCBA"
        Me.Result.Name = "Result"
        Me.Result.ReadOnly = True
        Me.Result.ToolTipText = "PCBA"
        Me.Result.Width = 200
        '
        'txtSubPCBASerialNo
        '
        Me.txtSubPCBASerialNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtSubPCBASerialNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSubPCBASerialNo.DataType = Nothing
        Me.txtSubPCBASerialNo.ElementTitle = Me.lblPCBASerial
        Me.txtSubPCBASerialNo.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtSubPCBASerialNo.ErrorMessage = Nothing
        Me.txtSubPCBASerialNo.KeyIn = True
        Me.txtSubPCBASerialNo.Location = New System.Drawing.Point(139, 29)
        Me.txtSubPCBASerialNo.Name = "txtSubPCBASerialNo"
        Me.txtSubPCBASerialNo.NoOfDecimals = 0
        Me.txtSubPCBASerialNo.ParentControl = Nothing
        Me.txtSubPCBASerialNo.RegEx = Nothing
        Me.txtSubPCBASerialNo.Required = False
        Me.txtSubPCBASerialNo.Size = New System.Drawing.Size(200, 20)
        Me.txtSubPCBASerialNo.StatusControl = Nothing
        Me.txtSubPCBASerialNo.TabIndex = 5
        Me.txtSubPCBASerialNo.Tag = "PCBASerial"
        Me.txtSubPCBASerialNo.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtSubPCBASerialNo.ValidationType = Nothing
        Me.txtSubPCBASerialNo.WarnColor = System.Drawing.Color.Wheat
        '
        'lblPCBASerial
        '
        Me.lblPCBASerial.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPCBASerial.Location = New System.Drawing.Point(3, 32)
        Me.lblPCBASerial.Name = "lblPCBASerial"
        Me.lblPCBASerial.Size = New System.Drawing.Size(130, 14)
        Me.lblPCBASerial.TabIndex = 15
        Me.lblPCBASerial.Tag = ""
        Me.lblPCBASerial.Text = "Sub PCBA Serial No"
        Me.lblPCBASerial.Visible = False
        '
        'lblIntserial
        '
        Me.lblIntserial.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblIntserial.Location = New System.Drawing.Point(3, 6)
        Me.lblIntserial.Name = "lblIntserial"
        Me.lblIntserial.Size = New System.Drawing.Size(130, 14)
        Me.lblIntserial.TabIndex = 14
        Me.lblIntserial.Tag = ""
        Me.lblIntserial.Text = "PCBA Serial No"
        '
        'txtPCBASerialNo
        '
        Me.txtPCBASerialNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtPCBASerialNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPCBASerialNo.DataType = Nothing
        Me.txtPCBASerialNo.ElementTitle = Me.lblIntserial
        Me.txtPCBASerialNo.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtPCBASerialNo.ErrorMessage = Nothing
        Me.txtPCBASerialNo.KeyIn = True
        Me.txtPCBASerialNo.Location = New System.Drawing.Point(139, 3)
        Me.txtPCBASerialNo.Name = "txtPCBASerialNo"
        Me.txtPCBASerialNo.NoOfDecimals = 0
        Me.txtPCBASerialNo.ParentControl = Nothing
        Me.txtPCBASerialNo.RegEx = Nothing
        Me.txtPCBASerialNo.Required = False
        Me.txtPCBASerialNo.Size = New System.Drawing.Size(200, 20)
        Me.txtPCBASerialNo.StatusControl = Nothing
        Me.txtPCBASerialNo.TabIndex = 1
        Me.txtPCBASerialNo.Tag = "IntSerial"
        Me.txtPCBASerialNo.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtPCBASerialNo.ValidationType = Nothing
        Me.txtPCBASerialNo.WarnColor = System.Drawing.Color.Wheat
        '
        'grpModel
        '
        Me.grpModel.Controls.Add(Me.pnlModel)
        Me.grpModel.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpModel.Location = New System.Drawing.Point(0, 47)
        Me.grpModel.Name = "grpModel"
        Me.grpModel.Size = New System.Drawing.Size(789, 48)
        Me.grpModel.TabIndex = 1
        Me.grpModel.TabStop = False
        Me.grpModel.Tag = "^TDC-1@"
        Me.grpModel.Text = "Model Information"
        '
        'pnlModel
        '
        Me.pnlModel.ColumnCount = 8
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlModel.Controls.Add(Me.txtPCBANo, 7, 0)
        Me.pnlModel.Controls.Add(Me.lblPCBANo, 6, 0)
        Me.pnlModel.Controls.Add(Me.txtModelNo, 4, 0)
        Me.pnlModel.Controls.Add(Me.lblModel, 3, 0)
        Me.pnlModel.Controls.Add(Me.lblPONo, 0, 0)
        Me.pnlModel.Controls.Add(Me.txtPONo, 1, 0)
        Me.pnlModel.Location = New System.Drawing.Point(3, 16)
        Me.pnlModel.Name = "pnlModel"
        Me.pnlModel.RowCount = 1
        Me.pnlModel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlModel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.pnlModel.Size = New System.Drawing.Size(778, 26)
        Me.pnlModel.TabIndex = 0
        '
        'txtPCBANo
        '
        Me.txtPCBANo.BackColor = System.Drawing.SystemColors.Window
        Me.txtPCBANo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPCBANo.DataType = Nothing
        Me.txtPCBANo.ElementTitle = Me.lblPCBANo
        Me.txtPCBANo.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtPCBANo.ErrorMessage = Nothing
        Me.txtPCBANo.KeyIn = True
        Me.txtPCBANo.Location = New System.Drawing.Point(623, 3)
        Me.txtPCBANo.Name = "txtPCBANo"
        Me.txtPCBANo.NoOfDecimals = 0
        Me.txtPCBANo.ParentControl = Nothing
        Me.txtPCBANo.RegEx = Nothing
        Me.txtPCBANo.Required = False
        Me.txtPCBANo.Size = New System.Drawing.Size(120, 20)
        Me.txtPCBANo.StatusControl = Nothing
        Me.txtPCBANo.TabIndex = 9
        Me.txtPCBANo.Tag = "PCBA"
        Me.txtPCBANo.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtPCBANo.ValidationType = Nothing
        Me.txtPCBANo.WarnColor = System.Drawing.Color.Wheat
        '
        'lblPCBANo
        '
        Me.lblPCBANo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPCBANo.Location = New System.Drawing.Point(517, 6)
        Me.lblPCBANo.Name = "lblPCBANo"
        Me.lblPCBANo.Size = New System.Drawing.Size(100, 14)
        Me.lblPCBANo.TabIndex = 7
        Me.lblPCBANo.Tag = ""
        Me.lblPCBANo.Text = "PCBA No"
        '
        'txtModelNo
        '
        Me.txtModelNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtModelNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtModelNo.DataType = Nothing
        Me.txtModelNo.ElementTitle = Me.lblModel
        Me.txtModelNo.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtModelNo.ErrorMessage = Nothing
        Me.txtModelNo.KeyIn = True
        Me.txtModelNo.Location = New System.Drawing.Point(371, 3)
        Me.txtModelNo.Name = "txtModelNo"
        Me.txtModelNo.NoOfDecimals = 0
        Me.txtModelNo.ParentControl = Nothing
        Me.txtModelNo.RegEx = Nothing
        Me.txtModelNo.Required = False
        Me.txtModelNo.Size = New System.Drawing.Size(120, 20)
        Me.txtModelNo.StatusControl = Nothing
        Me.txtModelNo.TabIndex = 5
        Me.txtModelNo.Tag = "ModelNo"
        Me.txtModelNo.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtModelNo.ValidationType = Nothing
        Me.txtModelNo.WarnColor = System.Drawing.Color.Wheat
        '
        'lblModel
        '
        Me.lblModel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblModel.Location = New System.Drawing.Point(285, 6)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(80, 14)
        Me.lblModel.TabIndex = 3
        Me.lblModel.Tag = ""
        Me.lblModel.Text = "Model No"
        '
        'lblPONo
        '
        Me.lblPONo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPONo.Location = New System.Drawing.Point(3, 6)
        Me.lblPONo.Name = "lblPONo"
        Me.lblPONo.Size = New System.Drawing.Size(130, 14)
        Me.lblPONo.TabIndex = 2
        Me.lblPONo.Tag = ""
        Me.lblPONo.Text = "Production Order No"
        '
        'txtPONo
        '
        Me.txtPONo.BackColor = System.Drawing.SystemColors.Window
        Me.txtPONo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPONo.DataType = Nothing
        Me.txtPONo.ElementTitle = Me.lblPONo
        Me.txtPONo.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtPONo.ErrorMessage = Nothing
        Me.txtPONo.KeyIn = True
        Me.txtPONo.Location = New System.Drawing.Point(139, 3)
        Me.txtPONo.Name = "txtPONo"
        Me.txtPONo.NoOfDecimals = 0
        Me.txtPONo.ParentControl = Nothing
        Me.txtPONo.RegEx = Nothing
        Me.txtPONo.Required = False
        Me.txtPONo.Size = New System.Drawing.Size(120, 20)
        Me.txtPONo.StatusControl = Nothing
        Me.txtPONo.TabIndex = 0
        Me.txtPONo.Tag = "PONo"
        Me.txtPONo.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtPONo.ValidationType = Nothing
        Me.txtPONo.WarnColor = System.Drawing.Color.Wheat
        '
        'grpProcess
        '
        Me.grpProcess.Controls.Add(Me.pnlProcess)
        Me.grpProcess.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.grpProcess.Location = New System.Drawing.Point(0, 0)
        Me.grpProcess.Name = "grpProcess"
        Me.grpProcess.Size = New System.Drawing.Size(789, 47)
        Me.grpProcess.TabIndex = 0
        Me.grpProcess.TabStop = False
        Me.grpProcess.Tag = "^TDC-0@"
        Me.grpProcess.Text = "Process"
        '
        'pnlProcess
        '
        Me.pnlProcess.ColumnCount = 8
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 374.0!))
        Me.pnlProcess.Controls.Add(Me.lblProcess, 0, 0)
        Me.pnlProcess.Controls.Add(Me.ddlProcess, 1, 0)
        Me.pnlProcess.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlProcess.Location = New System.Drawing.Point(3, 16)
        Me.pnlProcess.Name = "pnlProcess"
        Me.pnlProcess.RowCount = 1
        Me.pnlProcess.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlProcess.Size = New System.Drawing.Size(783, 28)
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
        'bgwSubPCBA
        '
        '
        'frmDetach
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(791, 596)
        Me.Controls.Add(Me.pnlBody)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "frmDetach"
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
        Me.pnlActions.PerformLayout()
        Me.grpDataInput.ResumeLayout(False)
        Me.grpDataInput.PerformLayout()
        Me.ETraceTableLayoutPanel1.ResumeLayout(False)
        Me.ETraceTableLayoutPanel1.PerformLayout()
        CType(Me.dgvSubPCBAList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpModel.ResumeLayout(False)
        Me.pnlModel.ResumeLayout(False)
        Me.pnlModel.PerformLayout()
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
    Friend WithEvents grpModel As eTraceUI.eTraceGroupBox
    Friend WithEvents grpDataInput As eTraceUI.eTraceGroupBox
    Friend WithEvents grpActions As eTraceUI.eTraceGroupBox
    Friend WithEvents pnlActions As eTraceUI.eTraceTableLayoutPanel
    Friend WithEvents btnPrint As eTraceUI.eTraceButton
    Friend WithEvents btnPost As eTraceUI.eTraceButton
    Friend WithEvents btnNew As eTraceUI.eTraceButton
    Friend WithEvents btnReset As eTraceUI.eTraceButton
    Friend WithEvents pnlModel As eTraceUI.eTraceTableLayoutPanel
    Friend WithEvents lblModel As eTraceUI.eTraceLabel
    Friend WithEvents lblPONo As eTraceUI.eTraceLabel
    Friend WithEvents txtPONo As eTraceUI.eTraceTextBox
    Friend WithEvents txtModelNo As eTraceUI.eTraceTextBox
    Friend WithEvents lblPCBANo As eTraceUI.eTraceLabel
    Friend WithEvents txtPCBANo As eTraceUI.eTraceTextBox
    Friend WithEvents bgwPost As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwPO As System.ComponentModel.BackgroundWorker
    Friend WithEvents ETraceTableLayoutPanel1 As eTraceUI.eTraceTableLayoutPanel
    Friend WithEvents txtSubPCBASerialNo As eTraceUI.eTraceTextBox
    Friend WithEvents txtPCBASerialNo As eTraceUI.eTraceTextBox
    Friend WithEvents lblIntserial As eTraceUI.eTraceLabel
    Friend WithEvents lblPCBASerial As eTraceUI.eTraceLabel
    Friend WithEvents bgwPoQty As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwIntSerial As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwSubPCBA As System.ComponentModel.BackgroundWorker
    Friend WithEvents dgvSubPCBAList As eTraceUI.eTraceDataGridView
    Friend WithEvents Process As DataGridViewTextBoxColumn
    Friend WithEvents Result As DataGridViewTextBoxColumn
End Class
