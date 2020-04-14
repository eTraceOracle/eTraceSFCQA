<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComponentReplacement
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
        Me.components = New System.ComponentModel.Container
        Dim TimerStatus1 As eTraceUI.TimerStatus = New eTraceUI.TimerStatus
        Me.pnlBody = New eTraceUI.eTracePanel
        Me.grpActions = New eTraceUI.eTraceGroupBox
        Me.pnlActions = New eTraceUI.eTraceTableLayoutPanel
        Me.btnPrint = New eTraceUI.eTraceButton
        Me.btnPost = New eTraceUI.eTraceButton
        Me.btnNew = New eTraceUI.eTraceButton
        Me.btnReset = New eTraceUI.eTraceButton
        Me.grpDataInput = New eTraceUI.eTraceGroupBox
        Me.ETraceTableLayoutPanel1 = New eTraceUI.eTraceTableLayoutPanel
        Me.dgvCR = New eTraceUI.eTraceDataGridView
        Me.PCBID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PCBA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CircuitCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CurPN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CurCLID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NewItem = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NewCLID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtIntSerial = New eTraceUI.eTraceTextBox
        Me.lblIntserial = New eTraceUI.eTraceLabel
        Me.txtCLID = New eTraceUI.eTraceTextBox
        Me.lblCLID = New eTraceUI.eTraceLabel
        Me.lblPCBID = New eTraceUI.eTraceLabel
        Me.txtPCBID = New eTraceUI.eTraceComboBox
        Me.lblCC = New eTraceUI.eTraceLabel
        Me.txtCC = New eTraceUI.eTraceComboBox
        Me.lblResult = New eTraceUI.eTraceLabel
        Me.txtResult = New eTraceUI.eTraceTextBox
        Me.grpModel = New eTraceUI.eTraceGroupBox
        Me.pnlModel = New eTraceUI.eTraceTableLayoutPanel
        Me.txtProdQty = New eTraceUI.eTraceTextBox
        Me.lblProdQty = New eTraceUI.eTraceLabel
        Me.txtQty = New eTraceUI.eTraceTextBox
        Me.lblQty = New eTraceUI.eTraceLabel
        Me.txtPCBANo = New eTraceUI.eTraceTextBox
        Me.lblPCBANo = New eTraceUI.eTraceLabel
        Me.txtPOPCBA = New eTraceUI.eTraceTextBox
        Me.lblPOPCBA = New eTraceUI.eTraceLabel
        Me.txtModelNo = New eTraceUI.eTraceTextBox
        Me.lblModel = New eTraceUI.eTraceLabel
        Me.lblPONo = New eTraceUI.eTraceLabel
        Me.txtPONo = New eTraceUI.eTraceTextBox
        Me.grpProcess = New eTraceUI.eTraceGroupBox
        Me.pnlProcess = New eTraceUI.eTraceTableLayoutPanel
        Me.lblProcess = New eTraceUI.eTraceLabel
        Me.ddlProcess = New eTraceUI.eTraceComboBox
        Me.chkAddlData = New eTraceUI.eTraceCheckBox
        Me.btnEMI = New eTraceUI.eTraceButton
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.bgwPost = New System.ComponentModel.BackgroundWorker
        Me.bgwIntSerial = New System.ComponentModel.BackgroundWorker
        Me.bgwCLID = New System.ComponentModel.BackgroundWorker
        Me.bgwResult = New System.ComponentModel.BackgroundWorker
        Me.pnlBody.SuspendLayout()
        Me.grpActions.SuspendLayout()
        Me.pnlActions.SuspendLayout()
        Me.grpDataInput.SuspendLayout()
        Me.ETraceTableLayoutPanel1.SuspendLayout()
        CType(Me.dgvCR, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.pnlActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
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
        Me.grpDataInput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDataInput.Controls.Add(Me.ETraceTableLayoutPanel1)
        Me.grpDataInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDataInput.Location = New System.Drawing.Point(4, 129)
        Me.grpDataInput.Name = "grpDataInput"
        Me.grpDataInput.Size = New System.Drawing.Size(783, 333)
        Me.grpDataInput.TabIndex = 2
        Me.grpDataInput.TabStop = False
        Me.grpDataInput.Tag = "^TDC-2@"
        Me.grpDataInput.Text = "Data Input"
        '
        'ETraceTableLayoutPanel1
        '
        Me.ETraceTableLayoutPanel1.ColumnCount = 8
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.dgvCR, 0, 2)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtIntSerial, 1, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblIntserial, 0, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtCLID, 7, 1)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblCLID, 6, 1)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblPCBID, 0, 1)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtPCBID, 1, 1)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblCC, 3, 1)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtCC, 4, 1)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblResult, 3, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtResult, 4, 0)
        Me.ETraceTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ETraceTableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.ETraceTableLayoutPanel1.Name = "ETraceTableLayoutPanel1"
        Me.ETraceTableLayoutPanel1.RowCount = 4
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.ETraceTableLayoutPanel1.Size = New System.Drawing.Size(777, 314)
        Me.ETraceTableLayoutPanel1.TabIndex = 2
        '
        'dgvCR
        '
        Me.dgvCR.AllowUserToAddRows = False
        Me.dgvCR.AllowUserToDeleteRows = False
        Me.dgvCR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PCBID, Me.PCBA, Me.CircuitCode, Me.CurPN, Me.CurCLID, Me.NewItem, Me.NewCLID})
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.dgvCR, 8)
        Me.dgvCR.Location = New System.Drawing.Point(3, 56)
        Me.dgvCR.Name = "dgvCR"
        Me.dgvCR.RowHeadersWidth = 23
        Me.ETraceTableLayoutPanel1.SetRowSpan(Me.dgvCR, 2)
        Me.dgvCR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCR.Size = New System.Drawing.Size(771, 255)
        Me.dgvCR.TabIndex = 21
        Me.dgvCR.TabStop = False
        '
        'PCBID
        '
        Me.PCBID.DataPropertyName = "PCBID"
        Me.PCBID.HeaderText = "PCBID"
        Me.PCBID.Name = "PCBID"
        Me.PCBID.ReadOnly = True
        Me.PCBID.ToolTipText = "PCBID"
        Me.PCBID.Width = 110
        '
        'PCBA
        '
        Me.PCBA.DataPropertyName = "PCBA"
        Me.PCBA.HeaderText = "PCBA"
        Me.PCBA.Name = "PCBA"
        Me.PCBA.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PCBA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PCBA.ToolTipText = "PCBA"
        Me.PCBA.Width = 110
        '
        'CircuitCode
        '
        Me.CircuitCode.DataPropertyName = "CircuitCode"
        Me.CircuitCode.HeaderText = "CircuitCode"
        Me.CircuitCode.Name = "CircuitCode"
        Me.CircuitCode.ToolTipText = "CircuitCode"
        '
        'CurPN
        '
        Me.CurPN.DataPropertyName = "CurPN"
        Me.CurPN.HeaderText = "CurPN"
        Me.CurPN.Name = "CurPN"
        Me.CurPN.ToolTipText = "CurPN"
        '
        'CurCLID
        '
        Me.CurCLID.DataPropertyName = "CurCLID"
        Me.CurCLID.HeaderText = "CurCLID"
        Me.CurCLID.Name = "CurCLID"
        Me.CurCLID.ToolTipText = "CurCLID"
        Me.CurCLID.Width = 150
        '
        'NewItem
        '
        Me.NewItem.DataPropertyName = "NewItem"
        Me.NewItem.HeaderText = "NewItem"
        Me.NewItem.Name = "NewItem"
        Me.NewItem.ToolTipText = "NewItem"
        '
        'NewCLID
        '
        Me.NewCLID.DataPropertyName = "NewCLID"
        Me.NewCLID.HeaderText = "NewCLID"
        Me.NewCLID.Name = "NewCLID"
        Me.NewCLID.ToolTipText = "NewCLID"
        Me.NewCLID.Width = 150
        '
        'txtIntSerial
        '
        Me.txtIntSerial.BackColor = System.Drawing.SystemColors.Window
        Me.txtIntSerial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIntSerial.DataType = Nothing
        Me.txtIntSerial.ElementTitle = Me.lblIntserial
        Me.txtIntSerial.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtIntSerial.ErrorMessage = Nothing
        Me.txtIntSerial.KeyIn = True
        Me.txtIntSerial.Location = New System.Drawing.Point(109, 3)
        Me.txtIntSerial.Name = "txtIntSerial"
        Me.txtIntSerial.NoOfDecimals = 0
        Me.txtIntSerial.ParentControl = Nothing
        Me.txtIntSerial.RegEx = Nothing
        Me.txtIntSerial.Required = False
        Me.txtIntSerial.Size = New System.Drawing.Size(120, 20)
        Me.txtIntSerial.StatusControl = Nothing
        Me.txtIntSerial.TabIndex = 4
        Me.txtIntSerial.Tag = "IntSN"
        Me.txtIntSerial.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtIntSerial.ValidationType = Nothing
        Me.txtIntSerial.WarnColor = System.Drawing.Color.Wheat
        '
        'lblIntserial
        '
        Me.lblIntserial.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblIntserial.Location = New System.Drawing.Point(3, 6)
        Me.lblIntserial.Name = "lblIntserial"
        Me.lblIntserial.Size = New System.Drawing.Size(100, 14)
        Me.lblIntserial.TabIndex = 14
        Me.lblIntserial.Tag = ""
        Me.lblIntserial.Text = "Int Serial No"
        '
        'txtCLID
        '
        Me.txtCLID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtCLID.BackColor = System.Drawing.SystemColors.Window
        Me.txtCLID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCLID.DataType = Nothing
        Me.txtCLID.ElementTitle = Me.lblCLID
        Me.txtCLID.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtCLID.ErrorMessage = Nothing
        Me.txtCLID.KeyIn = True
        Me.txtCLID.Location = New System.Drawing.Point(575, 29)
        Me.txtCLID.Name = "txtCLID"
        Me.txtCLID.NoOfDecimals = 0
        Me.txtCLID.ParentControl = Nothing
        Me.txtCLID.RegEx = Nothing
        Me.txtCLID.Required = False
        Me.txtCLID.Size = New System.Drawing.Size(170, 20)
        Me.txtCLID.StatusControl = Nothing
        Me.txtCLID.TabIndex = 6
        Me.txtCLID.Tag = "CLID"
        Me.txtCLID.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtCLID.ValidationType = Nothing
        Me.txtCLID.WarnColor = System.Drawing.Color.Wheat
        '
        'lblCLID
        '
        Me.lblCLID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCLID.AutoSize = True
        Me.lblCLID.Location = New System.Drawing.Point(455, 33)
        Me.lblCLID.Name = "lblCLID"
        Me.lblCLID.Size = New System.Drawing.Size(78, 13)
        Me.lblCLID.TabIndex = 15
        Me.lblCLID.Tag = ""
        Me.lblCLID.Text = "CLID/PCBID"
        '
        'lblPCBID
        '
        Me.lblPCBID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPCBID.AutoSize = True
        Me.lblPCBID.Location = New System.Drawing.Point(3, 33)
        Me.lblPCBID.Name = "lblPCBID"
        Me.lblPCBID.Size = New System.Drawing.Size(48, 13)
        Me.lblPCBID.TabIndex = 22
        Me.lblPCBID.Tag = ""
        Me.lblPCBID.Text = "PCB ID"
        '
        'txtPCBID
        '
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.txtPCBID, 2)
        Me.txtPCBID.DataType = Nothing
        Me.txtPCBID.DropDownHeight = 300
        Me.txtPCBID.DropDownWidth = 500
        Me.txtPCBID.ElementTitle = Me.lblPCBID
        Me.txtPCBID.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtPCBID.ErrorMessage = Nothing
        Me.txtPCBID.FormattingEnabled = True
        Me.txtPCBID.IntegralHeight = False
        Me.txtPCBID.ItemDataTable = Nothing
        Me.txtPCBID.ItemDesc = Nothing
        Me.txtPCBID.ItemID = "IntSN"
        Me.txtPCBID.ItemSelect = eTraceUI.eTraceComboBox.ItemSelects.ID
        Me.txtPCBID.ItemValue = "PCBA"
        Me.txtPCBID.LimitToList = True
        Me.txtPCBID.Location = New System.Drawing.Point(109, 29)
        Me.txtPCBID.Name = "txtPCBID"
        Me.txtPCBID.NoOfDecimals = 0
        Me.txtPCBID.ParentControl = Nothing
        Me.txtPCBID.RegEx = Nothing
        Me.txtPCBID.Required = False
        Me.txtPCBID.Size = New System.Drawing.Size(120, 21)
        Me.txtPCBID.StatusControl = Nothing
        Me.txtPCBID.TabIndex = 23
        Me.txtPCBID.Tag = "PCBID"
        Me.txtPCBID.TextCase = eTraceUI.eTraceComboBox.TextCases.None
        Me.txtPCBID.ValidationType = Nothing
        Me.txtPCBID.WarnColor = System.Drawing.Color.Wheat
        '
        'lblCC
        '
        Me.lblCC.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCC.Location = New System.Drawing.Point(250, 32)
        Me.lblCC.Name = "lblCC"
        Me.lblCC.Size = New System.Drawing.Size(84, 14)
        Me.lblCC.TabIndex = 25
        Me.lblCC.Tag = ""
        Me.lblCC.Text = "Circuit Code"
        '
        'txtCC
        '
        Me.txtCC.DataType = Nothing
        Me.txtCC.DropDownHeight = 300
        Me.txtCC.DropDownWidth = 400
        Me.txtCC.ElementTitle = Me.lblCC
        Me.txtCC.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtCC.ErrorMessage = Nothing
        Me.txtCC.FormattingEnabled = True
        Me.txtCC.IntegralHeight = False
        Me.txtCC.ItemDataTable = Nothing
        Me.txtCC.ItemDesc = "CLID"
        Me.txtCC.ItemID = "CircuitCode"
        Me.txtCC.ItemSelect = eTraceUI.eTraceComboBox.ItemSelects.ID
        Me.txtCC.ItemValue = "Component"
        Me.txtCC.LimitToList = True
        Me.txtCC.Location = New System.Drawing.Point(340, 29)
        Me.txtCC.Name = "txtCC"
        Me.txtCC.NoOfDecimals = 0
        Me.txtCC.ParentControl = Nothing
        Me.txtCC.RegEx = "1"
        Me.txtCC.Required = False
        Me.txtCC.Size = New System.Drawing.Size(90, 21)
        Me.txtCC.StatusControl = Nothing
        Me.txtCC.TabIndex = 24
        Me.txtCC.Tag = "CircuitCode"
        Me.txtCC.TextCase = eTraceUI.eTraceComboBox.TextCases.None
        Me.txtCC.ValidationType = Nothing
        Me.txtCC.WarnColor = System.Drawing.Color.Wheat
        '
        'lblResult
        '
        Me.lblResult.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblResult.Location = New System.Drawing.Point(250, 6)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(84, 14)
        Me.lblResult.TabIndex = 17
        Me.lblResult.Tag = ""
        Me.lblResult.Text = "Test Reuslt"
        '
        'txtResult
        '
        Me.txtResult.BackColor = System.Drawing.SystemColors.Window
        Me.txtResult.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtResult.DataType = Nothing
        Me.txtResult.ElementTitle = Me.lblResult
        Me.txtResult.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtResult.ErrorMessage = Nothing
        Me.txtResult.KeyIn = True
        Me.txtResult.Location = New System.Drawing.Point(340, 3)
        Me.txtResult.Name = "txtResult"
        Me.txtResult.NoOfDecimals = 0
        Me.txtResult.ParentControl = Nothing
        Me.txtResult.RegEx = Nothing
        Me.txtResult.Required = False
        Me.txtResult.Size = New System.Drawing.Size(90, 20)
        Me.txtResult.StatusControl = Nothing
        Me.txtResult.TabIndex = 5
        Me.txtResult.Tag = "ResultCode"
        Me.txtResult.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtResult.ValidationType = Nothing
        Me.txtResult.WarnColor = System.Drawing.Color.Wheat
        '
        'grpModel
        '
        Me.grpModel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpModel.Controls.Add(Me.pnlModel)
        Me.grpModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpModel.Location = New System.Drawing.Point(3, 54)
        Me.grpModel.Name = "grpModel"
        Me.grpModel.Size = New System.Drawing.Size(783, 72)
        Me.grpModel.TabIndex = 1
        Me.grpModel.TabStop = False
        Me.grpModel.Tag = "^TDC-1@"
        Me.grpModel.Text = "Model Information"
        '
        'pnlModel
        '
        Me.pnlModel.ColumnCount = 8
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
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
        Me.pnlModel.Controls.Add(Me.txtPONo, 1, 0)
        Me.pnlModel.Location = New System.Drawing.Point(3, 16)
        Me.pnlModel.Name = "pnlModel"
        Me.pnlModel.RowCount = 2
        Me.pnlModel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.pnlModel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.pnlModel.Size = New System.Drawing.Size(778, 53)
        Me.pnlModel.TabIndex = 0
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
        Me.txtProdQty.Location = New System.Drawing.Point(623, 29)
        Me.txtProdQty.Name = "txtProdQty"
        Me.txtProdQty.NoOfDecimals = 0
        Me.txtProdQty.ParentControl = Nothing
        Me.txtProdQty.RegEx = Nothing
        Me.txtProdQty.Required = False
        Me.txtProdQty.Size = New System.Drawing.Size(60, 20)
        Me.txtProdQty.StatusControl = Nothing
        Me.txtProdQty.TabIndex = 13
        Me.txtProdQty.Tag = "ProdQty"
        Me.txtProdQty.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtProdQty.ValidationType = Nothing
        Me.txtProdQty.WarnColor = System.Drawing.Color.Wheat
        '
        'lblProdQty
        '
        Me.lblProdQty.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblProdQty.Location = New System.Drawing.Point(537, 32)
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
        Me.txtQty.Location = New System.Drawing.Point(623, 3)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.NoOfDecimals = 0
        Me.txtQty.ParentControl = Nothing
        Me.txtQty.RegEx = Nothing
        Me.txtQty.Required = False
        Me.txtQty.Size = New System.Drawing.Size(60, 20)
        Me.txtQty.StatusControl = Nothing
        Me.txtQty.TabIndex = 12
        Me.txtQty.Tag = "Qty"
        Me.txtQty.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtQty.ValidationType = Nothing
        Me.txtQty.WarnColor = System.Drawing.Color.Wheat
        '
        'lblQty
        '
        Me.lblQty.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblQty.Location = New System.Drawing.Point(537, 6)
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
        Me.txtPCBANo.Location = New System.Drawing.Point(391, 29)
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
        Me.lblPCBANo.Location = New System.Drawing.Point(285, 32)
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
        Me.txtPOPCBA.Location = New System.Drawing.Point(391, 3)
        Me.txtPOPCBA.Name = "txtPOPCBA"
        Me.txtPOPCBA.NoOfDecimals = 0
        Me.txtPOPCBA.ParentControl = Nothing
        Me.txtPOPCBA.RegEx = Nothing
        Me.txtPOPCBA.Required = False
        Me.txtPOPCBA.Size = New System.Drawing.Size(120, 20)
        Me.txtPOPCBA.StatusControl = Nothing
        Me.txtPOPCBA.TabIndex = 8
        Me.txtPOPCBA.Tag = "POPCBA"
        Me.txtPOPCBA.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtPOPCBA.ValidationType = Nothing
        Me.txtPOPCBA.WarnColor = System.Drawing.Color.Wheat
        '
        'lblPOPCBA
        '
        Me.lblPOPCBA.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPOPCBA.Location = New System.Drawing.Point(285, 6)
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
        Me.lblModel.Location = New System.Drawing.Point(3, 32)
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
        Me.txtPONo.TabIndex = 4
        Me.txtPONo.Tag = "PONo"
        Me.txtPONo.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtPONo.ValidationType = Nothing
        Me.txtPONo.WarnColor = System.Drawing.Color.Wheat
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
        Me.pnlProcess.ColumnCount = 8
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 374.0!))
        Me.pnlProcess.Controls.Add(Me.lblProcess, 0, 0)
        Me.pnlProcess.Controls.Add(Me.ddlProcess, 1, 0)
        Me.pnlProcess.Controls.Add(Me.chkAddlData, 7, 0)
        Me.pnlProcess.Controls.Add(Me.btnEMI, 3, 0)
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
        'chkAddlData
        '
        Me.chkAddlData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkAddlData.AutoSize = True
        Me.chkAddlData.Enabled = False
        Me.chkAddlData.Location = New System.Drawing.Point(472, 3)
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
        Me.btnEMI.Location = New System.Drawing.Point(384, 3)
        Me.btnEMI.Name = "btnEMI"
        Me.btnEMI.Size = New System.Drawing.Size(62, 22)
        Me.btnEMI.TabIndex = 19
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
        'bgwCLID
        '
        '
        'bgwResult
        '
        '
        'frmComponentReplacement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(791, 596)
        Me.Controls.Add(Me.pnlBody)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "frmComponentReplacement"
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
        CType(Me.dgvCR, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents txtPONo As eTraceUI.eTraceTextBox
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
    Friend WithEvents txtCLID As eTraceUI.eTraceTextBox
    Friend WithEvents txtIntSerial As eTraceUI.eTraceTextBox
    Friend WithEvents lblIntserial As eTraceUI.eTraceLabel
    Friend WithEvents lblCLID As eTraceUI.eTraceLabel
    Friend WithEvents lblResult As eTraceUI.eTraceLabel
    Friend WithEvents txtResult As eTraceUI.eTraceTextBox
    Friend WithEvents bgwIntSerial As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwCLID As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnEMI As eTraceUI.eTraceButton
    Friend WithEvents dgvCR As eTraceUI.eTraceDataGridView
    Friend WithEvents lblPCBID As eTraceUI.eTraceLabel
    Friend WithEvents txtPCBID As eTraceUI.eTraceComboBox
    Friend WithEvents lblCC As eTraceUI.eTraceLabel
    Friend WithEvents txtCC As eTraceUI.eTraceComboBox
    Friend WithEvents PCBID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PCBA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CircuitCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurPN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurCLID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NewItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NewCLID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bgwResult As System.ComponentModel.BackgroundWorker

End Class
