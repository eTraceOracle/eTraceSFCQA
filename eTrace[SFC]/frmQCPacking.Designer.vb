<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQCPacking
    Inherits eTraceUI.eTraceForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
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
        Me.txtSymptom = New eTraceUI.eTraceComboBox()
        Me.lblSymCode = New eTraceUI.eTraceLabel()
        Me.txtQCResult = New eTraceUI.eTraceTextBox()
        Me.lblQCResult = New eTraceUI.eTraceLabel()
        Me.txtSNTO = New eTraceUI.eTraceTextBox()
        Me.lblSNTO = New eTraceUI.eTraceLabel()
        Me.txtSNFROM = New eTraceUI.eTraceTextBox()
        Me.lblSNFROM = New eTraceUI.eTraceLabel()
        Me.dgvAttributes = New eTraceUI.eTraceDataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblPSize = New eTraceUI.eTraceLabel()
        Me.lblBSize = New eTraceUI.eTraceLabel()
        Me.txtPalletSize = New eTraceUI.eTraceTextBox()
        Me.txtPalletQty = New eTraceUI.eTraceTextBox()
        Me.lblPalletID = New eTraceUI.eTraceLabel()
        Me.txtBoxSize = New eTraceUI.eTraceTextBox()
        Me.txtBoxQty = New eTraceUI.eTraceTextBox()
        Me.lblBoxID = New eTraceUI.eTraceLabel()
        Me.txtPalletID = New eTraceUI.eTraceTextBox()
        Me.txtBoxID = New eTraceUI.eTraceTextBox()
        Me.txtExtSerial = New eTraceUI.eTraceTextBox()
        Me.lblExtSerial = New eTraceUI.eTraceLabel()
        Me.txtIntSerial = New eTraceUI.eTraceTextBox()
        Me.lblIntserial = New eTraceUI.eTraceLabel()
        Me.dgvResult = New eTraceUI.eTraceDataGridView()
        Me.Process = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Result = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rework = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.txtDJ = New eTraceUI.eTraceTextBox()
        Me.lblPO = New eTraceUI.eTraceLabel()
        Me.grpModel = New eTraceUI.eTraceGroupBox()
        Me.pnlModel = New eTraceUI.eTraceTableLayoutPanel()
        Me.txtPONo = New eTraceUI.eTraceComboBox()
        Me.lblPONo = New eTraceUI.eTraceLabel()
        Me.txtProdQty = New eTraceUI.eTraceTextBox()
        Me.lblProdQty = New eTraceUI.eTraceLabel()
        Me.txtQty = New eTraceUI.eTraceTextBox()
        Me.lblQty = New eTraceUI.eTraceLabel()
        Me.txtPCBANo = New eTraceUI.eTraceTextBox()
        Me.lblPCBANo = New eTraceUI.eTraceLabel()
        Me.txtPOPCBA = New eTraceUI.eTraceTextBox()
        Me.lblPOPCBA = New eTraceUI.eTraceLabel()
        Me.txtModelNo = New eTraceUI.eTraceTextBox()
        Me.lblModel = New eTraceUI.eTraceLabel()
        Me.grpProcess = New eTraceUI.eTraceGroupBox()
        Me.pnlProcess = New eTraceUI.eTraceTableLayoutPanel()
        Me.lblProcess = New eTraceUI.eTraceLabel()
        Me.ddlProcess = New eTraceUI.eTraceComboBox()
        Me.chkAddlData = New eTraceUI.eTraceCheckBox()
        Me.btnEMI = New eTraceUI.eTraceButton()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.bgwPost = New System.ComponentModel.BackgroundWorker()
        Me.bgwIntSerial = New System.ComponentModel.BackgroundWorker()
        Me.bgwPrint = New System.ComponentModel.BackgroundWorker()
        Me.bgwQCResult = New System.ComponentModel.BackgroundWorker()
        Me.pnlBody.SuspendLayout()
        Me.grpActions.SuspendLayout()
        Me.pnlActions.SuspendLayout()
        Me.grpDataInput.SuspendLayout()
        Me.ETraceTableLayoutPanel1.SuspendLayout()
        CType(Me.dgvAttributes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpModel.SuspendLayout()
        Me.pnlModel.SuspendLayout()
        Me.grpProcess.SuspendLayout()
        Me.pnlProcess.SuspendLayout()
        Me.SuspendLayout()
        '
        'MessageBar1
        '
        Me.MessageBar1.Location = New System.Drawing.Point(0, 622)
        Me.MessageBar1.Size = New System.Drawing.Size(939, 22)
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
        Me.pnlBody.Size = New System.Drawing.Size(937, 569)
        Me.pnlBody.TabIndex = 2
        '
        'grpActions
        '
        Me.grpActions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpActions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.grpActions.Controls.Add(Me.pnlActions)
        Me.grpActions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpActions.Location = New System.Drawing.Point(3, 512)
        Me.grpActions.Name = "grpActions"
        Me.grpActions.Size = New System.Drawing.Size(931, 51)
        Me.grpActions.TabIndex = 4
        Me.grpActions.TabStop = False
        Me.grpActions.Tag = "^APP-13@"
        Me.grpActions.Text = "Actions"
        Me.grpActions.Visible = False
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
        Me.pnlActions.Size = New System.Drawing.Size(925, 32)
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
        Me.grpDataInput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDataInput.Controls.Add(Me.ETraceTableLayoutPanel1)
        Me.grpDataInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDataInput.Location = New System.Drawing.Point(4, 129)
        Me.grpDataInput.Name = "grpDataInput"
        Me.grpDataInput.Size = New System.Drawing.Size(931, 381)
        Me.grpDataInput.TabIndex = 2
        Me.grpDataInput.TabStop = False
        Me.grpDataInput.Tag = "^TDC-2@"
        Me.grpDataInput.Text = "Data Input"
        Me.grpDataInput.Visible = False
        '
        'ETraceTableLayoutPanel1
        '
        Me.ETraceTableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ETraceTableLayoutPanel1.ColumnCount = 11
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtSymptom, 7, 3)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblSymCode, 6, 3)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtQCResult, 7, 2)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtSNTO, 7, 1)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblSNTO, 6, 1)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtSNFROM, 1, 1)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblSNFROM, 0, 1)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.dgvAttributes, 0, 6)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblPSize, 9, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblBSize, 3, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtPalletSize, 10, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtPalletQty, 8, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtBoxSize, 4, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtBoxQty, 2, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtPalletID, 7, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtBoxID, 1, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblBoxID, 0, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtExtSerial, 1, 4)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtIntSerial, 1, 2)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblIntserial, 0, 2)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblExtSerial, 0, 4)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblPalletID, 6, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.dgvResult, 7, 6)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtDJ, 7, 4)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblPO, 6, 4)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblQCResult, 6, 2)
        Me.ETraceTableLayoutPanel1.Location = New System.Drawing.Point(2, 19)
        Me.ETraceTableLayoutPanel1.Name = "ETraceTableLayoutPanel1"
        Me.ETraceTableLayoutPanel1.RowCount = 7
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ETraceTableLayoutPanel1.Size = New System.Drawing.Size(926, 355)
        Me.ETraceTableLayoutPanel1.TabIndex = 2
        '
        'txtSymptom
        '
        Me.txtSymptom.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtSymptom.DataType = Nothing
        Me.txtSymptom.DropDownHeight = 200
        Me.txtSymptom.DropDownWidth = 250
        Me.txtSymptom.ElementTitle = Me.lblSymCode
        Me.txtSymptom.Enabled = False
        Me.txtSymptom.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtSymptom.ErrorMessage = Nothing
        Me.txtSymptom.FormattingEnabled = True
        Me.txtSymptom.IntegralHeight = False
        Me.txtSymptom.ItemDataTable = Nothing
        Me.txtSymptom.ItemDesc = Nothing
        Me.txtSymptom.ItemHeight = 13
        Me.txtSymptom.ItemID = Nothing
        Me.txtSymptom.ItemSelect = eTraceUI.eTraceComboBox.ItemSelects.None
        Me.txtSymptom.ItemValue = Nothing
        Me.txtSymptom.LimitToList = True
        Me.txtSymptom.Location = New System.Drawing.Point(601, 81)
        Me.txtSymptom.MaxDropDownItems = 20
        Me.txtSymptom.Name = "txtSymptom"
        Me.txtSymptom.NoOfDecimals = 0
        Me.txtSymptom.ParentControl = Nothing
        Me.txtSymptom.RegEx = Nothing
        Me.txtSymptom.Required = False
        Me.txtSymptom.Size = New System.Drawing.Size(190, 21)
        Me.txtSymptom.StatusControl = Nothing
        Me.txtSymptom.TabIndex = 42
        Me.txtSymptom.Tag = "Symptom"
        Me.txtSymptom.TextCase = eTraceUI.eTraceComboBox.TextCases.None
        Me.txtSymptom.UseWaitCursor = True
        Me.txtSymptom.ValidationType = Nothing
        Me.txtSymptom.Visible = False
        Me.txtSymptom.WarnColor = System.Drawing.Color.Wheat
        '
        'lblSymCode
        '
        Me.lblSymCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSymCode.Location = New System.Drawing.Point(465, 84)
        Me.lblSymCode.Name = "lblSymCode"
        Me.lblSymCode.Size = New System.Drawing.Size(130, 14)
        Me.lblSymCode.TabIndex = 41
        Me.lblSymCode.Tag = ""
        Me.lblSymCode.Text = "Symptom Code"
        Me.lblSymCode.Visible = False
        '
        'txtQCResult
        '
        Me.txtQCResult.BackColor = System.Drawing.SystemColors.Window
        Me.txtQCResult.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.txtQCResult, 4)
        Me.txtQCResult.DataType = Nothing
        Me.txtQCResult.ElementTitle = Me.lblQCResult
        Me.txtQCResult.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtQCResult.ErrorMessage = Nothing
        Me.txtQCResult.KeyIn = True
        Me.txtQCResult.Location = New System.Drawing.Point(601, 55)
        Me.txtQCResult.Name = "txtQCResult"
        Me.txtQCResult.NoOfDecimals = 0
        Me.txtQCResult.ParentControl = Nothing
        Me.txtQCResult.RegEx = Nothing
        Me.txtQCResult.Required = True
        Me.txtQCResult.Size = New System.Drawing.Size(300, 20)
        Me.txtQCResult.StatusControl = Nothing
        Me.txtQCResult.TabIndex = 40
        Me.txtQCResult.Tag = "QCResult"
        Me.txtQCResult.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtQCResult.ValidationType = Nothing
        Me.txtQCResult.WarnColor = System.Drawing.Color.Wheat
        '
        'lblQCResult
        '
        Me.lblQCResult.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblQCResult.Location = New System.Drawing.Point(465, 58)
        Me.lblQCResult.Name = "lblQCResult"
        Me.lblQCResult.Size = New System.Drawing.Size(130, 14)
        Me.lblQCResult.TabIndex = 39
        Me.lblQCResult.Tag = ""
        Me.lblQCResult.Text = "QC Result"
        '
        'txtSNTO
        '
        Me.txtSNTO.BackColor = System.Drawing.SystemColors.Window
        Me.txtSNTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.txtSNTO, 4)
        Me.txtSNTO.DataType = Nothing
        Me.txtSNTO.ElementTitle = Me.lblSNTO
        Me.txtSNTO.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtSNTO.ErrorMessage = Nothing
        Me.txtSNTO.KeyIn = True
        Me.txtSNTO.Location = New System.Drawing.Point(601, 29)
        Me.txtSNTO.Name = "txtSNTO"
        Me.txtSNTO.NoOfDecimals = 0
        Me.txtSNTO.ParentControl = Nothing
        Me.txtSNTO.RegEx = Nothing
        Me.txtSNTO.Required = False
        Me.txtSNTO.Size = New System.Drawing.Size(300, 20)
        Me.txtSNTO.StatusControl = Nothing
        Me.txtSNTO.TabIndex = 38
        Me.txtSNTO.Tag = "SNTo"
        Me.txtSNTO.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtSNTO.ValidationType = Nothing
        Me.txtSNTO.WarnColor = System.Drawing.Color.Wheat
        '
        'lblSNTO
        '
        Me.lblSNTO.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSNTO.Location = New System.Drawing.Point(465, 32)
        Me.lblSNTO.Name = "lblSNTO"
        Me.lblSNTO.Size = New System.Drawing.Size(130, 14)
        Me.lblSNTO.TabIndex = 37
        Me.lblSNTO.Tag = ""
        Me.lblSNTO.Text = "SN TO"
        '
        'txtSNFROM
        '
        Me.txtSNFROM.BackColor = System.Drawing.SystemColors.Window
        Me.txtSNFROM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.txtSNFROM, 4)
        Me.txtSNFROM.DataType = Nothing
        Me.txtSNFROM.ElementTitle = Me.lblSNFROM
        Me.txtSNFROM.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtSNFROM.ErrorMessage = Nothing
        Me.txtSNFROM.KeyIn = True
        Me.txtSNFROM.Location = New System.Drawing.Point(139, 29)
        Me.txtSNFROM.Name = "txtSNFROM"
        Me.txtSNFROM.NoOfDecimals = 0
        Me.txtSNFROM.ParentControl = Nothing
        Me.txtSNFROM.RegEx = Nothing
        Me.txtSNFROM.Required = False
        Me.txtSNFROM.Size = New System.Drawing.Size(300, 20)
        Me.txtSNFROM.StatusControl = Nothing
        Me.txtSNFROM.TabIndex = 36
        Me.txtSNFROM.Tag = "SNFrom"
        Me.txtSNFROM.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtSNFROM.ValidationType = Nothing
        Me.txtSNFROM.WarnColor = System.Drawing.Color.Wheat
        '
        'lblSNFROM
        '
        Me.lblSNFROM.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSNFROM.Location = New System.Drawing.Point(3, 32)
        Me.lblSNFROM.Name = "lblSNFROM"
        Me.lblSNFROM.Size = New System.Drawing.Size(130, 14)
        Me.lblSNFROM.TabIndex = 35
        Me.lblSNFROM.Tag = ""
        Me.lblSNFROM.Text = "SN FROM"
        '
        'dgvAttributes
        '
        Me.dgvAttributes.AllowUserToAddRows = False
        Me.dgvAttributes.AllowUserToDeleteRows = False
        Me.dgvAttributes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAttributes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewCheckBoxColumn1})
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.dgvAttributes, 7)
        Me.dgvAttributes.Location = New System.Drawing.Point(3, 134)
        Me.dgvAttributes.MultiSelect = False
        Me.dgvAttributes.Name = "dgvAttributes"
        Me.dgvAttributes.RowHeadersWidth = 23
        Me.dgvAttributes.Size = New System.Drawing.Size(592, 245)
        Me.dgvAttributes.TabIndex = 32
        Me.dgvAttributes.TabStop = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Attributes"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Attributes"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.ToolTipText = "Attributes"
        Me.DataGridViewTextBoxColumn1.Width = 150
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Values"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Values"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.ToolTipText = "Values"
        Me.DataGridViewTextBoxColumn2.Width = 350
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "InputType"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "InputType"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewCheckBoxColumn1.ToolTipText = "InputType"
        Me.DataGridViewCheckBoxColumn1.Visible = False
        Me.DataGridViewCheckBoxColumn1.Width = 60
        '
        'lblPSize
        '
        Me.lblPSize.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPSize.Location = New System.Drawing.Point(845, 6)
        Me.lblPSize.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPSize.Name = "lblPSize"
        Me.lblPSize.Size = New System.Drawing.Size(10, 14)
        Me.lblPSize.TabIndex = 28
        Me.lblPSize.Tag = ""
        Me.lblPSize.Text = "/"
        Me.lblPSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPSize.Visible = False
        '
        'lblBSize
        '
        Me.lblBSize.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblBSize.Location = New System.Drawing.Point(383, 6)
        Me.lblBSize.Margin = New System.Windows.Forms.Padding(0)
        Me.lblBSize.Name = "lblBSize"
        Me.lblBSize.Size = New System.Drawing.Size(10, 14)
        Me.lblBSize.TabIndex = 27
        Me.lblBSize.Tag = ""
        Me.lblBSize.Text = "/"
        Me.lblBSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBSize.Visible = False
        '
        'txtPalletSize
        '
        Me.txtPalletSize.BackColor = System.Drawing.SystemColors.Window
        Me.txtPalletSize.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPalletSize.DataType = Nothing
        Me.txtPalletSize.ElementTitle = Me.lblPSize
        Me.txtPalletSize.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtPalletSize.ErrorMessage = Nothing
        Me.txtPalletSize.KeyIn = True
        Me.txtPalletSize.Location = New System.Drawing.Point(856, 3)
        Me.txtPalletSize.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.txtPalletSize.Name = "txtPalletSize"
        Me.txtPalletSize.NoOfDecimals = 0
        Me.txtPalletSize.ParentControl = Nothing
        Me.txtPalletSize.RegEx = Nothing
        Me.txtPalletSize.Required = False
        Me.txtPalletSize.Size = New System.Drawing.Size(45, 20)
        Me.txtPalletSize.StatusControl = Nothing
        Me.txtPalletSize.TabIndex = 13
        Me.txtPalletSize.Tag = "PalletSize"
        Me.txtPalletSize.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtPalletSize.ValidationType = Nothing
        Me.txtPalletSize.WarnColor = System.Drawing.Color.Wheat
        '
        'txtPalletQty
        '
        Me.txtPalletQty.BackColor = System.Drawing.SystemColors.Window
        Me.txtPalletQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPalletQty.DataType = Nothing
        Me.txtPalletQty.ElementTitle = Me.lblPalletID
        Me.txtPalletQty.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtPalletQty.ErrorMessage = Nothing
        Me.txtPalletQty.KeyIn = True
        Me.txtPalletQty.Location = New System.Drawing.Point(799, 3)
        Me.txtPalletQty.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.txtPalletQty.Name = "txtPalletQty"
        Me.txtPalletQty.NoOfDecimals = 0
        Me.txtPalletQty.ParentControl = Nothing
        Me.txtPalletQty.RegEx = Nothing
        Me.txtPalletQty.Required = False
        Me.txtPalletQty.Size = New System.Drawing.Size(45, 20)
        Me.txtPalletQty.StatusControl = Nothing
        Me.txtPalletQty.TabIndex = 12
        Me.txtPalletQty.Tag = "PalletID"
        Me.txtPalletQty.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtPalletQty.ValidationType = Nothing
        Me.txtPalletQty.WarnColor = System.Drawing.Color.Wheat
        '
        'lblPalletID
        '
        Me.lblPalletID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPalletID.Location = New System.Drawing.Point(465, 6)
        Me.lblPalletID.Name = "lblPalletID"
        Me.lblPalletID.Size = New System.Drawing.Size(130, 14)
        Me.lblPalletID.TabIndex = 21
        Me.lblPalletID.Tag = ""
        Me.lblPalletID.Text = "Pallet ID"
        '
        'txtBoxSize
        '
        Me.txtBoxSize.BackColor = System.Drawing.SystemColors.Window
        Me.txtBoxSize.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBoxSize.DataType = Nothing
        Me.txtBoxSize.ElementTitle = Me.lblBSize
        Me.txtBoxSize.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtBoxSize.ErrorMessage = Nothing
        Me.txtBoxSize.KeyIn = True
        Me.txtBoxSize.Location = New System.Drawing.Point(394, 3)
        Me.txtBoxSize.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.txtBoxSize.Name = "txtBoxSize"
        Me.txtBoxSize.NoOfDecimals = 0
        Me.txtBoxSize.ParentControl = Nothing
        Me.txtBoxSize.RegEx = Nothing
        Me.txtBoxSize.Required = False
        Me.txtBoxSize.Size = New System.Drawing.Size(45, 20)
        Me.txtBoxSize.StatusControl = Nothing
        Me.txtBoxSize.TabIndex = 10
        Me.txtBoxSize.Tag = "BoxSize"
        Me.txtBoxSize.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtBoxSize.ValidationType = Nothing
        Me.txtBoxSize.WarnColor = System.Drawing.Color.Wheat
        '
        'txtBoxQty
        '
        Me.txtBoxQty.BackColor = System.Drawing.SystemColors.Window
        Me.txtBoxQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBoxQty.DataType = Nothing
        Me.txtBoxQty.ElementTitle = Me.lblBoxID
        Me.txtBoxQty.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtBoxQty.ErrorMessage = Nothing
        Me.txtBoxQty.KeyIn = True
        Me.txtBoxQty.Location = New System.Drawing.Point(337, 3)
        Me.txtBoxQty.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.txtBoxQty.Name = "txtBoxQty"
        Me.txtBoxQty.NoOfDecimals = 0
        Me.txtBoxQty.ParentControl = Nothing
        Me.txtBoxQty.RegEx = Nothing
        Me.txtBoxQty.Required = False
        Me.txtBoxQty.Size = New System.Drawing.Size(45, 20)
        Me.txtBoxQty.StatusControl = Nothing
        Me.txtBoxQty.TabIndex = 9
        Me.txtBoxQty.Tag = "BoxID"
        Me.txtBoxQty.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtBoxQty.ValidationType = Nothing
        Me.txtBoxQty.WarnColor = System.Drawing.Color.Wheat
        '
        'lblBoxID
        '
        Me.lblBoxID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblBoxID.Location = New System.Drawing.Point(3, 6)
        Me.lblBoxID.Name = "lblBoxID"
        Me.lblBoxID.Size = New System.Drawing.Size(130, 14)
        Me.lblBoxID.TabIndex = 20
        Me.lblBoxID.Tag = ""
        Me.lblBoxID.Text = "Box ID"
        '
        'txtPalletID
        '
        Me.txtPalletID.BackColor = System.Drawing.SystemColors.Window
        Me.txtPalletID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPalletID.DataType = Nothing
        Me.txtPalletID.ElementTitle = Me.lblPalletID
        Me.txtPalletID.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtPalletID.ErrorMessage = Nothing
        Me.txtPalletID.KeyIn = True
        Me.txtPalletID.Location = New System.Drawing.Point(601, 3)
        Me.txtPalletID.Name = "txtPalletID"
        Me.txtPalletID.NoOfDecimals = 0
        Me.txtPalletID.ParentControl = Nothing
        Me.txtPalletID.RegEx = Nothing
        Me.txtPalletID.Required = False
        Me.txtPalletID.Size = New System.Drawing.Size(191, 20)
        Me.txtPalletID.StatusControl = Nothing
        Me.txtPalletID.TabIndex = 11
        Me.txtPalletID.Tag = "PalletID"
        Me.txtPalletID.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtPalletID.ValidationType = Nothing
        Me.txtPalletID.WarnColor = System.Drawing.Color.Wheat
        '
        'txtBoxID
        '
        Me.txtBoxID.BackColor = System.Drawing.SystemColors.Window
        Me.txtBoxID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBoxID.DataType = Nothing
        Me.txtBoxID.ElementTitle = Me.lblBoxID
        Me.txtBoxID.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtBoxID.ErrorMessage = Nothing
        Me.txtBoxID.KeyIn = True
        Me.txtBoxID.Location = New System.Drawing.Point(139, 3)
        Me.txtBoxID.Name = "txtBoxID"
        Me.txtBoxID.NoOfDecimals = 0
        Me.txtBoxID.ParentControl = Nothing
        Me.txtBoxID.RegEx = Nothing
        Me.txtBoxID.Required = False
        Me.txtBoxID.Size = New System.Drawing.Size(191, 20)
        Me.txtBoxID.StatusControl = Nothing
        Me.txtBoxID.TabIndex = 8
        Me.txtBoxID.Tag = "BoxID"
        Me.txtBoxID.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtBoxID.ValidationType = Nothing
        Me.txtBoxID.WarnColor = System.Drawing.Color.Wheat
        '
        'txtExtSerial
        '
        Me.txtExtSerial.BackColor = System.Drawing.SystemColors.Window
        Me.txtExtSerial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.txtExtSerial, 4)
        Me.txtExtSerial.DataType = Nothing
        Me.txtExtSerial.ElementTitle = Me.lblExtSerial
        Me.txtExtSerial.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtExtSerial.ErrorMessage = Nothing
        Me.txtExtSerial.KeyIn = True
        Me.txtExtSerial.Location = New System.Drawing.Point(139, 108)
        Me.txtExtSerial.Name = "txtExtSerial"
        Me.txtExtSerial.NoOfDecimals = 0
        Me.txtExtSerial.ParentControl = Nothing
        Me.txtExtSerial.RegEx = Nothing
        Me.txtExtSerial.Required = False
        Me.txtExtSerial.Size = New System.Drawing.Size(300, 20)
        Me.txtExtSerial.StatusControl = Nothing
        Me.txtExtSerial.TabIndex = 15
        Me.txtExtSerial.Tag = "Attributes"
        Me.txtExtSerial.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtExtSerial.ValidationType = Nothing
        Me.txtExtSerial.WarnColor = System.Drawing.Color.Wheat
        '
        'lblExtSerial
        '
        Me.lblExtSerial.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblExtSerial.Location = New System.Drawing.Point(3, 111)
        Me.lblExtSerial.Name = "lblExtSerial"
        Me.lblExtSerial.Size = New System.Drawing.Size(130, 14)
        Me.lblExtSerial.TabIndex = 15
        Me.lblExtSerial.Tag = ""
        Me.lblExtSerial.Text = "Ext. Serial No"
        '
        'txtIntSerial
        '
        Me.txtIntSerial.BackColor = System.Drawing.SystemColors.Window
        Me.txtIntSerial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.txtIntSerial, 4)
        Me.txtIntSerial.DataType = Nothing
        Me.txtIntSerial.ElementTitle = Me.lblIntserial
        Me.txtIntSerial.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtIntSerial.ErrorMessage = Nothing
        Me.txtIntSerial.KeyIn = True
        Me.txtIntSerial.Location = New System.Drawing.Point(139, 55)
        Me.txtIntSerial.Name = "txtIntSerial"
        Me.txtIntSerial.NoOfDecimals = 0
        Me.txtIntSerial.ParentControl = Nothing
        Me.txtIntSerial.RegEx = Nothing
        Me.txtIntSerial.Required = False
        Me.txtIntSerial.Size = New System.Drawing.Size(300, 20)
        Me.txtIntSerial.StatusControl = Nothing
        Me.txtIntSerial.TabIndex = 14
        Me.txtIntSerial.Tag = "IntSerial"
        Me.txtIntSerial.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtIntSerial.ValidationType = Nothing
        Me.txtIntSerial.WarnColor = System.Drawing.Color.Wheat
        '
        'lblIntserial
        '
        Me.lblIntserial.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblIntserial.Location = New System.Drawing.Point(3, 58)
        Me.lblIntserial.Name = "lblIntserial"
        Me.lblIntserial.Size = New System.Drawing.Size(130, 14)
        Me.lblIntserial.TabIndex = 14
        Me.lblIntserial.Tag = ""
        Me.lblIntserial.Text = "PCBA Serial No"
        '
        'dgvResult
        '
        Me.dgvResult.AllowUserToAddRows = False
        Me.dgvResult.AllowUserToDeleteRows = False
        Me.dgvResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResult.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Process, Me.Result, Me.Rework})
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.dgvResult, 4)
        Me.dgvResult.Location = New System.Drawing.Point(601, 134)
        Me.dgvResult.MultiSelect = False
        Me.dgvResult.Name = "dgvResult"
        Me.dgvResult.RowHeadersWidth = 23
        Me.dgvResult.Size = New System.Drawing.Size(322, 245)
        Me.dgvResult.TabIndex = 18
        Me.dgvResult.TabStop = False
        '
        'Process
        '
        Me.Process.DataPropertyName = "Process"
        Me.Process.HeaderText = "Process"
        Me.Process.Name = "Process"
        Me.Process.ReadOnly = True
        Me.Process.ToolTipText = "Process"
        Me.Process.Width = 130
        '
        'Result
        '
        Me.Result.DataPropertyName = "Result"
        Me.Result.HeaderText = "Result"
        Me.Result.Name = "Result"
        Me.Result.ReadOnly = True
        Me.Result.ToolTipText = "Result"
        '
        'Rework
        '
        Me.Rework.DataPropertyName = "Rework"
        Me.Rework.FalseValue = "0"
        Me.Rework.HeaderText = "Rework"
        Me.Rework.Name = "Rework"
        Me.Rework.ToolTipText = "Rework"
        Me.Rework.TrueValue = "1"
        Me.Rework.Visible = False
        Me.Rework.Width = 60
        '
        'txtDJ
        '
        Me.txtDJ.BackColor = System.Drawing.SystemColors.Window
        Me.txtDJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.txtDJ, 4)
        Me.txtDJ.DataType = Nothing
        Me.txtDJ.ElementTitle = Me.lblPO
        Me.txtDJ.Enabled = False
        Me.txtDJ.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtDJ.ErrorMessage = Nothing
        Me.txtDJ.KeyIn = True
        Me.txtDJ.Location = New System.Drawing.Point(601, 108)
        Me.txtDJ.Name = "txtDJ"
        Me.txtDJ.NoOfDecimals = 0
        Me.txtDJ.ParentControl = Nothing
        Me.txtDJ.RegEx = Nothing
        Me.txtDJ.Required = False
        Me.txtDJ.Size = New System.Drawing.Size(300, 20)
        Me.txtDJ.StatusControl = Nothing
        Me.txtDJ.TabIndex = 34
        Me.txtDJ.Tag = "PO"
        Me.txtDJ.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtDJ.ValidationType = Nothing
        Me.txtDJ.WarnColor = System.Drawing.Color.Wheat
        '
        'lblPO
        '
        Me.lblPO.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPO.Location = New System.Drawing.Point(465, 111)
        Me.lblPO.Name = "lblPO"
        Me.lblPO.Size = New System.Drawing.Size(130, 14)
        Me.lblPO.TabIndex = 33
        Me.lblPO.Tag = ""
        Me.lblPO.Text = "Prod Order"
        '
        'grpModel
        '
        Me.grpModel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpModel.Controls.Add(Me.pnlModel)
        Me.grpModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpModel.Location = New System.Drawing.Point(3, 54)
        Me.grpModel.Name = "grpModel"
        Me.grpModel.Size = New System.Drawing.Size(931, 72)
        Me.grpModel.TabIndex = 1
        Me.grpModel.TabStop = False
        Me.grpModel.Tag = "^TDC-1@"
        Me.grpModel.Text = "Model Information"
        '
        'pnlModel
        '
        Me.pnlModel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlModel.ColumnCount = 8
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlModel.Controls.Add(Me.txtPONo, 1, 0)
        Me.pnlModel.Controls.Add(Me.txtProdQty, 7, 1)
        Me.pnlModel.Controls.Add(Me.txtQty, 7, 0)
        Me.pnlModel.Controls.Add(Me.lblProdQty, 6, 1)
        Me.pnlModel.Controls.Add(Me.lblQty, 6, 0)
        Me.pnlModel.Controls.Add(Me.txtPCBANo, 4, 1)
        Me.pnlModel.Controls.Add(Me.txtPOPCBA, 4, 0)
        Me.pnlModel.Controls.Add(Me.lblPCBANo, 3, 1)
        Me.pnlModel.Controls.Add(Me.lblPOPCBA, 3, 0)
        Me.pnlModel.Controls.Add(Me.txtModelNo, 1, 1)
        Me.pnlModel.Controls.Add(Me.lblModel, 0, 1)
        Me.pnlModel.Controls.Add(Me.lblPONo, 0, 0)
        Me.pnlModel.Location = New System.Drawing.Point(3, 16)
        Me.pnlModel.Name = "pnlModel"
        Me.pnlModel.RowCount = 2
        Me.pnlModel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.pnlModel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.pnlModel.Size = New System.Drawing.Size(878, 53)
        Me.pnlModel.TabIndex = 0
        '
        'txtPONo
        '
        Me.txtPONo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtPONo.DataType = Nothing
        Me.txtPONo.DropDownHeight = 200
        Me.txtPONo.DropDownWidth = 250
        Me.txtPONo.ElementTitle = Me.lblPONo
        Me.txtPONo.Enabled = False
        Me.txtPONo.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtPONo.ErrorMessage = Nothing
        Me.txtPONo.FormattingEnabled = True
        Me.txtPONo.IntegralHeight = False
        Me.txtPONo.ItemDataTable = Nothing
        Me.txtPONo.ItemDesc = Nothing
        Me.txtPONo.ItemHeight = 13
        Me.txtPONo.ItemID = Nothing
        Me.txtPONo.ItemSelect = eTraceUI.eTraceComboBox.ItemSelects.None
        Me.txtPONo.ItemValue = Nothing
        Me.txtPONo.LimitToList = True
        Me.txtPONo.Location = New System.Drawing.Point(139, 3)
        Me.txtPONo.MaxDropDownItems = 20
        Me.txtPONo.Name = "txtPONo"
        Me.txtPONo.NoOfDecimals = 0
        Me.txtPONo.ParentControl = Nothing
        Me.txtPONo.RegEx = Nothing
        Me.txtPONo.Required = False
        Me.txtPONo.Size = New System.Drawing.Size(190, 21)
        Me.txtPONo.StatusControl = Nothing
        Me.txtPONo.TabIndex = 2
        Me.txtPONo.Tag = "PONo"
        Me.txtPONo.TextCase = eTraceUI.eTraceComboBox.TextCases.None
        Me.txtPONo.ValidationType = Nothing
        Me.txtPONo.WarnColor = System.Drawing.Color.Wheat
        '
        'lblPONo
        '
        Me.lblPONo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPONo.Location = New System.Drawing.Point(3, 6)
        Me.lblPONo.Name = "lblPONo"
        Me.lblPONo.Size = New System.Drawing.Size(130, 14)
        Me.lblPONo.TabIndex = 2
        Me.lblPONo.Tag = ""
        Me.lblPONo.Text = "Customer"
        '
        'txtProdQty
        '
        Me.txtProdQty.BackColor = System.Drawing.SystemColors.Window
        Me.txtProdQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProdQty.DataType = Nothing
        Me.txtProdQty.ElementTitle = Me.lblProdQty
        Me.txtProdQty.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtProdQty.ErrorMessage = Nothing
        Me.txtProdQty.KeyIn = True
        Me.txtProdQty.Location = New System.Drawing.Point(771, 29)
        Me.txtProdQty.Name = "txtProdQty"
        Me.txtProdQty.NoOfDecimals = 0
        Me.txtProdQty.ParentControl = Nothing
        Me.txtProdQty.RegEx = Nothing
        Me.txtProdQty.Required = False
        Me.txtProdQty.Size = New System.Drawing.Size(60, 20)
        Me.txtProdQty.StatusControl = Nothing
        Me.txtProdQty.TabIndex = 7
        Me.txtProdQty.Tag = "ProdQty"
        Me.txtProdQty.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtProdQty.ValidationType = Nothing
        Me.txtProdQty.WarnColor = System.Drawing.Color.Wheat
        '
        'lblProdQty
        '
        Me.lblProdQty.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblProdQty.Location = New System.Drawing.Point(685, 32)
        Me.lblProdQty.Name = "lblProdQty"
        Me.lblProdQty.Size = New System.Drawing.Size(80, 14)
        Me.lblProdQty.TabIndex = 11
        Me.lblProdQty.Tag = ""
        Me.lblProdQty.Text = "Prod Qty"
        Me.lblProdQty.Visible = False
        '
        'txtQty
        '
        Me.txtQty.BackColor = System.Drawing.SystemColors.Window
        Me.txtQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQty.DataType = Nothing
        Me.txtQty.ElementTitle = Me.lblQty
        Me.txtQty.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtQty.ErrorMessage = Nothing
        Me.txtQty.KeyIn = True
        Me.txtQty.Location = New System.Drawing.Point(771, 3)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.NoOfDecimals = 0
        Me.txtQty.ParentControl = Nothing
        Me.txtQty.RegEx = Nothing
        Me.txtQty.Required = False
        Me.txtQty.Size = New System.Drawing.Size(60, 20)
        Me.txtQty.StatusControl = Nothing
        Me.txtQty.TabIndex = 4
        Me.txtQty.Tag = "Qty"
        Me.txtQty.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtQty.ValidationType = Nothing
        Me.txtQty.WarnColor = System.Drawing.Color.Wheat
        '
        'lblQty
        '
        Me.lblQty.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblQty.Location = New System.Drawing.Point(685, 6)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(80, 14)
        Me.lblQty.TabIndex = 10
        Me.lblQty.Tag = ""
        Me.lblQty.Text = "Qty"
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
        Me.txtPCBANo.Location = New System.Drawing.Point(465, 29)
        Me.txtPCBANo.Name = "txtPCBANo"
        Me.txtPCBANo.NoOfDecimals = 0
        Me.txtPCBANo.ParentControl = Nothing
        Me.txtPCBANo.RegEx = Nothing
        Me.txtPCBANo.Required = False
        Me.txtPCBANo.Size = New System.Drawing.Size(194, 20)
        Me.txtPCBANo.StatusControl = Nothing
        Me.txtPCBANo.TabIndex = 6
        Me.txtPCBANo.Tag = "PCBA"
        Me.txtPCBANo.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtPCBANo.ValidationType = Nothing
        Me.txtPCBANo.WarnColor = System.Drawing.Color.Wheat
        '
        'lblPCBANo
        '
        Me.lblPCBANo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPCBANo.Location = New System.Drawing.Point(359, 32)
        Me.lblPCBANo.Name = "lblPCBANo"
        Me.lblPCBANo.Size = New System.Drawing.Size(100, 14)
        Me.lblPCBANo.TabIndex = 7
        Me.lblPCBANo.Tag = ""
        Me.lblPCBANo.Text = "PCBA No"
        '
        'txtPOPCBA
        '
        Me.txtPOPCBA.BackColor = System.Drawing.SystemColors.Window
        Me.txtPOPCBA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPOPCBA.DataType = Nothing
        Me.txtPOPCBA.ElementTitle = Me.lblPOPCBA
        Me.txtPOPCBA.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtPOPCBA.ErrorMessage = Nothing
        Me.txtPOPCBA.KeyIn = True
        Me.txtPOPCBA.Location = New System.Drawing.Point(465, 3)
        Me.txtPOPCBA.Name = "txtPOPCBA"
        Me.txtPOPCBA.NoOfDecimals = 0
        Me.txtPOPCBA.ParentControl = Nothing
        Me.txtPOPCBA.RegEx = Nothing
        Me.txtPOPCBA.Required = False
        Me.txtPOPCBA.Size = New System.Drawing.Size(194, 20)
        Me.txtPOPCBA.StatusControl = Nothing
        Me.txtPOPCBA.TabIndex = 3
        Me.txtPOPCBA.Tag = "POPCBA"
        Me.txtPOPCBA.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtPOPCBA.ValidationType = Nothing
        Me.txtPOPCBA.WarnColor = System.Drawing.Color.Wheat
        '
        'lblPOPCBA
        '
        Me.lblPOPCBA.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPOPCBA.Location = New System.Drawing.Point(359, 6)
        Me.lblPOPCBA.Name = "lblPOPCBA"
        Me.lblPOPCBA.Size = New System.Drawing.Size(100, 14)
        Me.lblPOPCBA.TabIndex = 6
        Me.lblPOPCBA.Tag = ""
        Me.lblPOPCBA.Text = "PCBA No"
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
        Me.txtModelNo.Location = New System.Drawing.Point(139, 29)
        Me.txtModelNo.Name = "txtModelNo"
        Me.txtModelNo.NoOfDecimals = 0
        Me.txtModelNo.ParentControl = Nothing
        Me.txtModelNo.RegEx = Nothing
        Me.txtModelNo.Required = False
        Me.txtModelNo.Size = New System.Drawing.Size(194, 20)
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
        Me.lblModel.Location = New System.Drawing.Point(3, 32)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(80, 14)
        Me.lblModel.TabIndex = 3
        Me.lblModel.Tag = ""
        Me.lblModel.Text = "Model No"
        '
        'grpProcess
        '
        Me.grpProcess.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpProcess.Controls.Add(Me.pnlProcess)
        Me.grpProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.grpProcess.Location = New System.Drawing.Point(3, 4)
        Me.grpProcess.Name = "grpProcess"
        Me.grpProcess.Size = New System.Drawing.Size(932, 47)
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
        Me.pnlProcess.Controls.Add(Me.chkAddlData, 7, 0)
        Me.pnlProcess.Controls.Add(Me.btnEMI, 4, 0)
        Me.pnlProcess.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlProcess.Location = New System.Drawing.Point(3, 16)
        Me.pnlProcess.Name = "pnlProcess"
        Me.pnlProcess.RowCount = 1
        Me.pnlProcess.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlProcess.Size = New System.Drawing.Size(926, 28)
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
        'chkAddlData
        '
        Me.chkAddlData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkAddlData.AutoSize = True
        Me.chkAddlData.Enabled = False
        Me.chkAddlData.Location = New System.Drawing.Point(569, 3)
        Me.chkAddlData.Name = "chkAddlData"
        Me.chkAddlData.Size = New System.Drawing.Size(146, 22)
        Me.chkAddlData.TabIndex = 2
        Me.chkAddlData.TabStop = False
        Me.chkAddlData.Tag = "chkAddlData"
        Me.chkAddlData.Text = "Additional Data Input"
        Me.chkAddlData.UseVisualStyleBackColor = True
        Me.chkAddlData.Visible = False
        '
        'btnEMI
        '
        Me.btnEMI.AutoSize = True
        Me.btnEMI.Location = New System.Drawing.Point(404, 3)
        Me.btnEMI.Name = "btnEMI"
        Me.btnEMI.Size = New System.Drawing.Size(59, 22)
        Me.btnEMI.TabIndex = 20
        Me.btnEMI.Tag = "^SFC-36@"
        Me.btnEMI.Text = "ShowMI"
        Me.btnEMI.UseVisualStyleBackColor = True
        Me.btnEMI.Visible = False
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
        'bgwPrint
        '
        '
        'bgwQCResult
        '
        '
        'frmQCPacking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(939, 644)
        Me.Controls.Add(Me.pnlBody)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "frmQCPacking"
        Me.Text = " "
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
        Me.ETraceTableLayoutPanel1.ResumeLayout(False)
        Me.ETraceTableLayoutPanel1.PerformLayout()
        CType(Me.dgvAttributes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpModel.ResumeLayout(False)
        Me.pnlModel.ResumeLayout(False)
        Me.pnlModel.PerformLayout()
        Me.grpProcess.ResumeLayout(False)
        Me.pnlProcess.ResumeLayout(False)
        Me.pnlProcess.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBody As eTraceUI.eTracePanel
    Friend WithEvents grpProcess As eTraceUI.eTraceGroupBox
    Friend WithEvents pnlProcess As eTraceUI.eTraceTableLayoutPanel
    Friend WithEvents lblProcess As eTraceUI.eTraceLabel
    Friend WithEvents ddlProcess As eTraceUI.eTraceComboBox
    Friend WithEvents chkAddlData As eTraceUI.eTraceCheckBox
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
    Friend WithEvents txtModelNo As eTraceUI.eTraceTextBox
    Friend WithEvents lblPOPCBA As eTraceUI.eTraceLabel
    Friend WithEvents lblPCBANo As eTraceUI.eTraceLabel
    Friend WithEvents txtPCBANo As eTraceUI.eTraceTextBox
    Friend WithEvents txtPOPCBA As eTraceUI.eTraceTextBox
    Friend WithEvents lblQty As eTraceUI.eTraceLabel
    Friend WithEvents lblProdQty As eTraceUI.eTraceLabel
    Friend WithEvents txtQty As eTraceUI.eTraceTextBox
    Friend WithEvents txtProdQty As eTraceUI.eTraceTextBox
    Friend WithEvents bgwPost As System.ComponentModel.BackgroundWorker
    Friend WithEvents ETraceTableLayoutPanel1 As eTraceUI.eTraceTableLayoutPanel
    Friend WithEvents txtExtSerial As eTraceUI.eTraceTextBox
    Friend WithEvents txtIntSerial As eTraceUI.eTraceTextBox
    Friend WithEvents lblIntserial As eTraceUI.eTraceLabel
    Friend WithEvents lblExtSerial As eTraceUI.eTraceLabel
    Friend WithEvents txtBoxID As eTraceUI.eTraceTextBox
    Friend WithEvents lblBoxID As eTraceUI.eTraceLabel
    Friend WithEvents dgvResult As eTraceUI.eTraceDataGridView
    Friend WithEvents lblPalletID As eTraceUI.eTraceLabel
    Friend WithEvents txtPalletID As eTraceUI.eTraceTextBox
    Friend WithEvents txtBoxSize As eTraceUI.eTraceTextBox
    Friend WithEvents txtBoxQty As eTraceUI.eTraceTextBox
    Friend WithEvents txtPalletQty As eTraceUI.eTraceTextBox
    Friend WithEvents txtPalletSize As eTraceUI.eTraceTextBox
    Friend WithEvents lblPSize As eTraceUI.eTraceLabel
    Friend WithEvents lblBSize As eTraceUI.eTraceLabel
    Friend WithEvents txtPONo As eTraceUI.eTraceComboBox
    Friend WithEvents bgwIntSerial As System.ComponentModel.BackgroundWorker
    Friend WithEvents dgvAttributes As eTraceUI.eTraceDataGridView
    Friend WithEvents Process As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Result As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rework As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents bgwPrint As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnEMI As eTraceUI.eTraceButton
    Friend WithEvents txtDJ As eTraceUI.eTraceTextBox
    Friend WithEvents lblPO As eTraceUI.eTraceLabel
    Friend WithEvents txtSNFROM As eTraceUI.eTraceTextBox
    Friend WithEvents lblSNFROM As eTraceUI.eTraceLabel
    Friend WithEvents txtSNTO As eTraceUI.eTraceTextBox
    Friend WithEvents lblSNTO As eTraceUI.eTraceLabel
    Friend WithEvents txtQCResult As eTraceUI.eTraceTextBox
    Friend WithEvents lblQCResult As eTraceUI.eTraceLabel
    Friend WithEvents bgwQCResult As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtSymptom As eTraceUI.eTraceComboBox
    Friend WithEvents lblSymCode As eTraceUI.eTraceLabel
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As DataGridViewTextBoxColumn
End Class
