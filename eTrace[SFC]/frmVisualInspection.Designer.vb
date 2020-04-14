<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisualInspection
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
        Me.lblSC = New eTraceUI.eTraceLabel()
        Me.txtSC = New eTraceUI.eTraceComboBox()
        Me.txtProcess = New eTraceUI.eTraceComboBox()
        Me.lblProc = New eTraceUI.eTraceLabel()
        Me.lblIPSNo = New eTraceUI.eTraceLabel()
        Me.txtIPSNo = New eTraceUI.eTraceTextBox()
        Me.lblIPSRev = New eTraceUI.eTraceLabel()
        Me.txtIPSRev = New eTraceUI.eTraceTextBox()
        Me.txtProgRev = New eTraceUI.eTraceTextBox()
        Me.lblProgRev = New eTraceUI.eTraceLabel()
        Me.txtProgName = New eTraceUI.eTraceTextBox()
        Me.lblProgName = New eTraceUI.eTraceLabel()
        Me.lblTesterNo = New eTraceUI.eTraceLabel()
        Me.txtTesterNo = New eTraceUI.eTraceTextBox()
        Me.lblRemarks = New eTraceUI.eTraceLabel()
        Me.txtRemarks = New eTraceUI.eTraceTextBox()
        Me.txtIntSerial = New eTraceUI.eTraceTextBox()
        Me.lblIntserial = New eTraceUI.eTraceLabel()
        Me.dgvResult = New eTraceUI.eTraceDataGridView()
        Me.Process = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Result = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SeqNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rework = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.lblResult = New eTraceUI.eTraceLabel()
        Me.txtResult = New eTraceUI.eTraceTextBox()
        Me.lblDC = New eTraceUI.eTraceLabel()
        Me.txtDC = New eTraceUI.eTraceComboBox()
        Me.grpModel = New eTraceUI.eTraceGroupBox()
        Me.pnlModel = New eTraceUI.eTraceTableLayoutPanel()
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
        Me.lblPONo = New eTraceUI.eTraceLabel()
        Me.txtPONo = New eTraceUI.eTraceTextBox()
        Me.grpProcess = New eTraceUI.eTraceGroupBox()
        Me.pnlProcess = New eTraceUI.eTraceTableLayoutPanel()
        Me.lblProcess = New eTraceUI.eTraceLabel()
        Me.ddlProcess = New eTraceUI.eTraceComboBox()
        Me.chkAddlData = New eTraceUI.eTraceCheckBox()
        Me.btnEMI = New eTraceUI.eTraceButton()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.bgwPost = New System.ComponentModel.BackgroundWorker()
        Me.bgwIntSerial = New System.ComponentModel.BackgroundWorker()
        Me.bgwResult = New System.ComponentModel.BackgroundWorker()
        Me.pnlBody.SuspendLayout()
        Me.grpActions.SuspendLayout()
        Me.pnlActions.SuspendLayout()
        Me.grpDataInput.SuspendLayout()
        Me.ETraceTableLayoutPanel1.SuspendLayout()
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ETraceTableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ETraceTableLayoutPanel1.ColumnCount = 8
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblSC, 6, 4)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtSC, 7, 4)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtProcess, 1, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblProc, 0, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblIPSNo, 0, 2)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtIPSNo, 1, 2)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblIPSRev, 3, 2)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtIPSRev, 4, 2)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtProgRev, 7, 1)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblProgRev, 6, 1)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtProgName, 4, 1)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblProgName, 3, 1)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblTesterNo, 0, 1)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtTesterNo, 1, 1)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblRemarks, 6, 2)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtRemarks, 7, 2)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtIntSerial, 1, 3)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblIntserial, 0, 3)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.dgvResult, 0, 5)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblResult, 0, 4)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtResult, 1, 4)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblDC, 3, 4)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtDC, 4, 4)
        Me.ETraceTableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.ETraceTableLayoutPanel1.Name = "ETraceTableLayoutPanel1"
        Me.ETraceTableLayoutPanel1.RowCount = 11
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.ETraceTableLayoutPanel1.Size = New System.Drawing.Size(777, 314)
        Me.ETraceTableLayoutPanel1.TabIndex = 2
        '
        'lblSC
        '
        Me.lblSC.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSC.Location = New System.Drawing.Point(533, 111)
        Me.lblSC.Name = "lblSC"
        Me.lblSC.Size = New System.Drawing.Size(96, 14)
        Me.lblSC.TabIndex = 37
        Me.lblSC.Tag = ""
        Me.lblSC.Text = "Symptom Code"
        Me.lblSC.Visible = False
        '
        'txtSC
        '
        Me.txtSC.DataType = Nothing
        Me.txtSC.DropDownHeight = 600
        Me.txtSC.DropDownWidth = 300
        Me.txtSC.ElementTitle = Me.lblSC
        Me.txtSC.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtSC.ErrorMessage = Nothing
        Me.txtSC.FormattingEnabled = True
        Me.txtSC.IntegralHeight = False
        Me.txtSC.ItemDataTable = Nothing
        Me.txtSC.ItemDesc = "Description"
        Me.txtSC.ItemID = "Code"
        Me.txtSC.ItemSelect = eTraceUI.eTraceComboBox.ItemSelects.ID
        Me.txtSC.ItemValue = ""
        Me.txtSC.LimitToList = True
        Me.txtSC.Location = New System.Drawing.Point(635, 108)
        Me.txtSC.Name = "txtSC"
        Me.txtSC.NoOfDecimals = 0
        Me.txtSC.ParentControl = Nothing
        Me.txtSC.RegEx = Nothing
        Me.txtSC.Required = False
        Me.txtSC.Size = New System.Drawing.Size(121, 21)
        Me.txtSC.StatusControl = Nothing
        Me.txtSC.TabIndex = 36
        Me.txtSC.Tag = "Symptom"
        Me.txtSC.TextCase = eTraceUI.eTraceComboBox.TextCases.None
        Me.txtSC.ValidationType = Nothing
        Me.txtSC.Visible = False
        Me.txtSC.WarnColor = System.Drawing.Color.Wheat
        '
        'txtProcess
        '
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.txtProcess, 3)
        Me.txtProcess.DataType = Nothing
        Me.txtProcess.DropDownHeight = 200
        Me.txtProcess.ElementTitle = Me.lblProc
        Me.txtProcess.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtProcess.ErrorMessage = Nothing
        Me.txtProcess.FormattingEnabled = True
        Me.txtProcess.IntegralHeight = False
        Me.txtProcess.ItemDataTable = Nothing
        Me.txtProcess.ItemDesc = Nothing
        Me.txtProcess.ItemID = Nothing
        Me.txtProcess.ItemSelect = eTraceUI.eTraceComboBox.ItemSelects.None
        Me.txtProcess.ItemValue = Nothing
        Me.txtProcess.LimitToList = True
        Me.txtProcess.Location = New System.Drawing.Point(139, 3)
        Me.txtProcess.Name = "txtProcess"
        Me.txtProcess.NoOfDecimals = 0
        Me.txtProcess.ParentControl = Nothing
        Me.txtProcess.RegEx = Nothing
        Me.txtProcess.Required = False
        Me.txtProcess.Size = New System.Drawing.Size(120, 21)
        Me.txtProcess.StatusControl = Nothing
        Me.txtProcess.TabIndex = 20
        Me.txtProcess.Tag = "Proc"
        Me.txtProcess.TextCase = eTraceUI.eTraceComboBox.TextCases.None
        Me.txtProcess.ValidationType = Nothing
        Me.txtProcess.WarnColor = System.Drawing.Color.Wheat
        '
        'lblProc
        '
        Me.lblProc.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblProc.Location = New System.Drawing.Point(3, 6)
        Me.lblProc.Name = "lblProc"
        Me.lblProc.Size = New System.Drawing.Size(130, 14)
        Me.lblProc.TabIndex = 15
        Me.lblProc.Tag = ""
        Me.lblProc.Text = "Process"
        '
        'lblIPSNo
        '
        Me.lblIPSNo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblIPSNo.Location = New System.Drawing.Point(3, 59)
        Me.lblIPSNo.Name = "lblIPSNo"
        Me.lblIPSNo.Size = New System.Drawing.Size(130, 14)
        Me.lblIPSNo.TabIndex = 25
        Me.lblIPSNo.Tag = ""
        Me.lblIPSNo.Text = "IPS No"
        '
        'txtIPSNo
        '
        Me.txtIPSNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtIPSNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIPSNo.DataType = Nothing
        Me.txtIPSNo.ElementTitle = Me.lblIPSNo
        Me.txtIPSNo.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtIPSNo.ErrorMessage = Nothing
        Me.txtIPSNo.KeyIn = True
        Me.txtIPSNo.Location = New System.Drawing.Point(139, 56)
        Me.txtIPSNo.Name = "txtIPSNo"
        Me.txtIPSNo.NoOfDecimals = 0
        Me.txtIPSNo.ParentControl = Nothing
        Me.txtIPSNo.RegEx = Nothing
        Me.txtIPSNo.Required = False
        Me.txtIPSNo.Size = New System.Drawing.Size(120, 20)
        Me.txtIPSNo.StatusControl = Nothing
        Me.txtIPSNo.TabIndex = 31
        Me.txtIPSNo.Tag = "IPSNo"
        Me.txtIPSNo.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtIPSNo.ValidationType = Nothing
        Me.txtIPSNo.WarnColor = System.Drawing.Color.Wheat
        '
        'lblIPSRev
        '
        Me.lblIPSRev.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblIPSRev.Location = New System.Drawing.Point(285, 59)
        Me.lblIPSRev.Name = "lblIPSRev"
        Me.lblIPSRev.Size = New System.Drawing.Size(96, 14)
        Me.lblIPSRev.TabIndex = 26
        Me.lblIPSRev.Tag = ""
        Me.lblIPSRev.Text = "IPS Rev"
        '
        'txtIPSRev
        '
        Me.txtIPSRev.BackColor = System.Drawing.SystemColors.Window
        Me.txtIPSRev.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIPSRev.DataType = Nothing
        Me.txtIPSRev.ElementTitle = Me.lblIPSRev
        Me.txtIPSRev.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtIPSRev.ErrorMessage = Nothing
        Me.txtIPSRev.KeyIn = True
        Me.txtIPSRev.Location = New System.Drawing.Point(387, 56)
        Me.txtIPSRev.Name = "txtIPSRev"
        Me.txtIPSRev.NoOfDecimals = 0
        Me.txtIPSRev.ParentControl = Nothing
        Me.txtIPSRev.RegEx = Nothing
        Me.txtIPSRev.Required = False
        Me.txtIPSRev.Size = New System.Drawing.Size(120, 20)
        Me.txtIPSRev.StatusControl = Nothing
        Me.txtIPSRev.TabIndex = 32
        Me.txtIPSRev.Tag = "IPSRev"
        Me.txtIPSRev.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtIPSRev.ValidationType = Nothing
        Me.txtIPSRev.WarnColor = System.Drawing.Color.Wheat
        '
        'txtProgRev
        '
        Me.txtProgRev.BackColor = System.Drawing.SystemColors.Window
        Me.txtProgRev.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProgRev.DataType = Nothing
        Me.txtProgRev.ElementTitle = Me.lblProgRev
        Me.txtProgRev.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtProgRev.ErrorMessage = Nothing
        Me.txtProgRev.KeyIn = True
        Me.txtProgRev.Location = New System.Drawing.Point(635, 30)
        Me.txtProgRev.Name = "txtProgRev"
        Me.txtProgRev.NoOfDecimals = 0
        Me.txtProgRev.ParentControl = Nothing
        Me.txtProgRev.RegEx = Nothing
        Me.txtProgRev.Required = False
        Me.txtProgRev.Size = New System.Drawing.Size(120, 20)
        Me.txtProgRev.StatusControl = Nothing
        Me.txtProgRev.TabIndex = 30
        Me.txtProgRev.Tag = "ProgRev"
        Me.txtProgRev.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtProgRev.ValidationType = Nothing
        Me.txtProgRev.WarnColor = System.Drawing.Color.Wheat
        '
        'lblProgRev
        '
        Me.lblProgRev.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblProgRev.Location = New System.Drawing.Point(533, 33)
        Me.lblProgRev.Name = "lblProgRev"
        Me.lblProgRev.Size = New System.Drawing.Size(96, 14)
        Me.lblProgRev.TabIndex = 24
        Me.lblProgRev.Tag = ""
        Me.lblProgRev.Text = "Program Rev"
        '
        'txtProgName
        '
        Me.txtProgName.BackColor = System.Drawing.SystemColors.Window
        Me.txtProgName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProgName.DataType = Nothing
        Me.txtProgName.ElementTitle = Me.lblProgName
        Me.txtProgName.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtProgName.ErrorMessage = Nothing
        Me.txtProgName.KeyIn = True
        Me.txtProgName.Location = New System.Drawing.Point(387, 30)
        Me.txtProgName.Name = "txtProgName"
        Me.txtProgName.NoOfDecimals = 0
        Me.txtProgName.ParentControl = Nothing
        Me.txtProgName.RegEx = Nothing
        Me.txtProgName.Required = False
        Me.txtProgName.Size = New System.Drawing.Size(120, 20)
        Me.txtProgName.StatusControl = Nothing
        Me.txtProgName.TabIndex = 29
        Me.txtProgName.Tag = "ProgName"
        Me.txtProgName.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtProgName.ValidationType = Nothing
        Me.txtProgName.WarnColor = System.Drawing.Color.Wheat
        '
        'lblProgName
        '
        Me.lblProgName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblProgName.Location = New System.Drawing.Point(285, 33)
        Me.lblProgName.Name = "lblProgName"
        Me.lblProgName.Size = New System.Drawing.Size(96, 14)
        Me.lblProgName.TabIndex = 23
        Me.lblProgName.Tag = ""
        Me.lblProgName.Text = "Program Name"
        '
        'lblTesterNo
        '
        Me.lblTesterNo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTesterNo.Location = New System.Drawing.Point(3, 33)
        Me.lblTesterNo.Name = "lblTesterNo"
        Me.lblTesterNo.Size = New System.Drawing.Size(100, 14)
        Me.lblTesterNo.TabIndex = 22
        Me.lblTesterNo.Tag = ""
        Me.lblTesterNo.Text = "Tester No"
        '
        'txtTesterNo
        '
        Me.txtTesterNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtTesterNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTesterNo.DataType = Nothing
        Me.txtTesterNo.ElementTitle = Me.lblTesterNo
        Me.txtTesterNo.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtTesterNo.ErrorMessage = Nothing
        Me.txtTesterNo.KeyIn = True
        Me.txtTesterNo.Location = New System.Drawing.Point(139, 30)
        Me.txtTesterNo.Name = "txtTesterNo"
        Me.txtTesterNo.NoOfDecimals = 0
        Me.txtTesterNo.ParentControl = Nothing
        Me.txtTesterNo.RegEx = Nothing
        Me.txtTesterNo.Required = False
        Me.txtTesterNo.Size = New System.Drawing.Size(120, 20)
        Me.txtTesterNo.StatusControl = Nothing
        Me.txtTesterNo.TabIndex = 28
        Me.txtTesterNo.Tag = "TesterNo"
        Me.txtTesterNo.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtTesterNo.ValidationType = Nothing
        Me.txtTesterNo.WarnColor = System.Drawing.Color.Wheat
        '
        'lblRemarks
        '
        Me.lblRemarks.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRemarks.Location = New System.Drawing.Point(533, 59)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(96, 14)
        Me.lblRemarks.TabIndex = 27
        Me.lblRemarks.Tag = ""
        Me.lblRemarks.Text = "Remark"
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.SystemColors.Window
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.DataType = Nothing
        Me.txtRemarks.ElementTitle = Me.lblRemarks
        Me.txtRemarks.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtRemarks.ErrorMessage = Nothing
        Me.txtRemarks.KeyIn = True
        Me.txtRemarks.Location = New System.Drawing.Point(635, 56)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.NoOfDecimals = 0
        Me.txtRemarks.ParentControl = Nothing
        Me.txtRemarks.RegEx = Nothing
        Me.txtRemarks.Required = False
        Me.txtRemarks.Size = New System.Drawing.Size(120, 20)
        Me.txtRemarks.StatusControl = Nothing
        Me.txtRemarks.TabIndex = 33
        Me.txtRemarks.Tag = "Remarks"
        Me.txtRemarks.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtRemarks.ValidationType = Nothing
        Me.txtRemarks.WarnColor = System.Drawing.Color.Wheat
        '
        'txtIntSerial
        '
        Me.txtIntSerial.BackColor = System.Drawing.SystemColors.Window
        Me.txtIntSerial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.txtIntSerial, 3)
        Me.txtIntSerial.DataType = Nothing
        Me.txtIntSerial.ElementTitle = Me.lblIntserial
        Me.txtIntSerial.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtIntSerial.ErrorMessage = Nothing
        Me.txtIntSerial.KeyIn = True
        Me.txtIntSerial.Location = New System.Drawing.Point(139, 82)
        Me.txtIntSerial.Name = "txtIntSerial"
        Me.txtIntSerial.NoOfDecimals = 0
        Me.txtIntSerial.ParentControl = Nothing
        Me.txtIntSerial.RegEx = Nothing
        Me.txtIntSerial.Required = False
        Me.txtIntSerial.Size = New System.Drawing.Size(210, 20)
        Me.txtIntSerial.StatusControl = Nothing
        Me.txtIntSerial.TabIndex = 4
        Me.txtIntSerial.Tag = "IntSerial"
        Me.txtIntSerial.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtIntSerial.ValidationType = Nothing
        Me.txtIntSerial.WarnColor = System.Drawing.Color.Wheat
        '
        'lblIntserial
        '
        Me.lblIntserial.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblIntserial.Location = New System.Drawing.Point(3, 85)
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
        Me.dgvResult.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Process, Me.Result, Me.SeqNo, Me.Rework})
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.dgvResult, 9)
        Me.dgvResult.Location = New System.Drawing.Point(3, 134)
        Me.dgvResult.MultiSelect = False
        Me.dgvResult.Name = "dgvResult"
        Me.dgvResult.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvResult.RowHeadersWidth = 23
        Me.ETraceTableLayoutPanel1.SetRowSpan(Me.dgvResult, 6)
        Me.dgvResult.Size = New System.Drawing.Size(771, 204)
        Me.dgvResult.TabIndex = 21
        Me.dgvResult.TabStop = False
        '
        'Process
        '
        Me.Process.DataPropertyName = "Process"
        Me.Process.HeaderText = "Process"
        Me.Process.Name = "Process"
        Me.Process.ReadOnly = True
        Me.Process.ToolTipText = "Process"
        Me.Process.Width = 200
        '
        'Result
        '
        Me.Result.DataPropertyName = "Result"
        Me.Result.HeaderText = "Result"
        Me.Result.Name = "Result"
        Me.Result.ReadOnly = True
        Me.Result.ToolTipText = "Result"
        Me.Result.Width = 200
        '
        'SeqNo
        '
        Me.SeqNo.DataPropertyName = "SeqNo"
        Me.SeqNo.HeaderText = "SeqNo"
        Me.SeqNo.Name = "SeqNo"
        Me.SeqNo.Visible = False
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
        'lblResult
        '
        Me.lblResult.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblResult.Location = New System.Drawing.Point(3, 111)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(120, 14)
        Me.lblResult.TabIndex = 17
        Me.lblResult.Tag = ""
        Me.lblResult.Text = "Ext. Serial No"
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
        Me.txtResult.Location = New System.Drawing.Point(139, 108)
        Me.txtResult.Name = "txtResult"
        Me.txtResult.NoOfDecimals = 0
        Me.txtResult.ParentControl = Nothing
        Me.txtResult.RegEx = Nothing
        Me.txtResult.Required = False
        Me.txtResult.Size = New System.Drawing.Size(120, 20)
        Me.txtResult.StatusControl = Nothing
        Me.txtResult.TabIndex = 5
        Me.txtResult.Tag = "VisualResult"
        Me.txtResult.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtResult.ValidationType = Nothing
        Me.txtResult.WarnColor = System.Drawing.Color.Wheat
        '
        'lblDC
        '
        Me.lblDC.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDC.Location = New System.Drawing.Point(285, 111)
        Me.lblDC.Name = "lblDC"
        Me.lblDC.Size = New System.Drawing.Size(96, 14)
        Me.lblDC.TabIndex = 34
        Me.lblDC.Tag = ""
        Me.lblDC.Text = "Defect Code"
        '
        'txtDC
        '
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.txtDC, 2)
        Me.txtDC.DataType = Nothing
        Me.txtDC.DropDownHeight = 600
        Me.txtDC.DropDownWidth = 300
        Me.txtDC.ElementTitle = Me.lblDC
        Me.txtDC.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtDC.ErrorMessage = Nothing
        Me.txtDC.FormattingEnabled = True
        Me.txtDC.IntegralHeight = False
        Me.txtDC.ItemDataTable = Nothing
        Me.txtDC.ItemDesc = "Description"
        Me.txtDC.ItemID = "Code"
        Me.txtDC.ItemSelect = eTraceUI.eTraceComboBox.ItemSelects.ID
        Me.txtDC.ItemValue = ""
        Me.txtDC.LimitToList = True
        Me.txtDC.Location = New System.Drawing.Point(387, 108)
        Me.txtDC.Name = "txtDC"
        Me.txtDC.NoOfDecimals = 0
        Me.txtDC.ParentControl = Nothing
        Me.txtDC.RegEx = Nothing
        Me.txtDC.Required = False
        Me.txtDC.Size = New System.Drawing.Size(121, 21)
        Me.txtDC.StatusControl = Nothing
        Me.txtDC.TabIndex = 35
        Me.txtDC.Tag = "DefectCode"
        Me.txtDC.TextCase = eTraceUI.eTraceComboBox.TextCases.None
        Me.txtDC.ValidationType = Nothing
        Me.txtDC.WarnColor = System.Drawing.Color.Wheat
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
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlModel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
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
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
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
        'bgwResult
        '
        '
        'frmVisualInspection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(791, 596)
        Me.Controls.Add(Me.pnlBody)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "frmVisualInspection"
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
    Friend WithEvents txtIntSerial As eTraceUI.eTraceTextBox
    Friend WithEvents lblIntserial As eTraceUI.eTraceLabel
    Friend WithEvents lblProc As eTraceUI.eTraceLabel
    Friend WithEvents lblResult As eTraceUI.eTraceLabel
    Friend WithEvents txtResult As eTraceUI.eTraceTextBox
    Friend WithEvents bgwIntSerial As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwResult As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnEMI As eTraceUI.eTraceButton
    Friend WithEvents txtProcess As eTraceUI.eTraceComboBox
    Friend WithEvents dgvResult As eTraceUI.eTraceDataGridView
    Friend WithEvents lblTesterNo As eTraceUI.eTraceLabel
    Friend WithEvents lblProgName As eTraceUI.eTraceLabel
    Friend WithEvents lblProgRev As eTraceUI.eTraceLabel
    Friend WithEvents lblIPSNo As eTraceUI.eTraceLabel
    Friend WithEvents lblIPSRev As eTraceUI.eTraceLabel
    Friend WithEvents lblRemarks As eTraceUI.eTraceLabel
    Friend WithEvents txtTesterNo As eTraceUI.eTraceTextBox
    Friend WithEvents txtProgName As eTraceUI.eTraceTextBox
    Friend WithEvents txtProgRev As eTraceUI.eTraceTextBox
    Friend WithEvents txtIPSNo As eTraceUI.eTraceTextBox
    Friend WithEvents txtIPSRev As eTraceUI.eTraceTextBox
    Friend WithEvents txtRemarks As eTraceUI.eTraceTextBox
    Friend WithEvents Process As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Result As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SeqNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rework As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents lblDC As eTraceUI.eTraceLabel
    Friend WithEvents txtDC As eTraceUI.eTraceComboBox
    Friend WithEvents lblSC As eTraceUI.eTraceLabel
    Friend WithEvents txtSC As eTraceUI.eTraceComboBox
End Class
