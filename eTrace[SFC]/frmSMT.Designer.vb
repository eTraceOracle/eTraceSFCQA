<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSMT
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
        Me.pnlBody = New eTraceUI.eTracePanel
        Me.ETraceTabControl1 = New eTraceUI.eTraceTabControl
        Me.Machine = New System.Windows.Forms.TabPage
        Me.grpActionM = New eTraceUI.eTraceGroupBox
        Me.tblActions = New eTraceUI.eTraceTableLayoutPanel
        Me.btnSaveM = New eTraceUI.eTraceButton
        Me.btnCancelM = New eTraceUI.eTraceButton
        Me.btnNewM = New eTraceUI.eTraceButton
        Me.btnDelM = New eTraceUI.eTraceButton
        Me.grpInputM = New eTraceUI.eTraceGroupBox
        Me.tblRemarks = New eTraceUI.eTraceTableLayoutPanel
        Me.lblRemark = New eTraceUI.eTraceLabel
        Me.txtRemark = New eTraceUI.eTraceTextBox
        Me.tblMachine = New eTraceUI.eTraceTableLayoutPanel
        Me.lblID = New eTraceUI.eTraceLabel
        Me.lblManu = New eTraceUI.eTraceLabel
        Me.txtManu = New eTraceUI.eTraceTextBox
        Me.lblModel = New eTraceUI.eTraceLabel
        Me.txtModel = New eTraceUI.eTraceTextBox
        Me.lblProd = New eTraceUI.eTraceLabel
        Me.txtProd = New eTraceUI.eTraceTextBox
        Me.ckbMulti = New eTraceUI.eTraceCheckBox
        Me.ckbDaul = New eTraceUI.eTraceCheckBox
        Me.cobID = New eTraceUI.eTraceComboBox
        Me.Feeder = New System.Windows.Forms.TabPage
        Me.grpActionF = New eTraceUI.eTraceGroupBox
        Me.tblActionF = New eTraceUI.eTraceTableLayoutPanel
        Me.btnSaveF = New eTraceUI.eTraceButton
        Me.btnCancelF = New eTraceUI.eTraceButton
        Me.btnNewF = New eTraceUI.eTraceButton
        Me.btnDelF = New eTraceUI.eTraceButton
        Me.grpInputF = New eTraceUI.eTraceGroupBox
        Me.tblFeeder = New eTraceUI.eTraceTableLayoutPanel
        Me.lblFeederID = New eTraceUI.eTraceLabel
        Me.lblFeederSpec = New eTraceUI.eTraceLabel
        Me.txtFeederSpec = New eTraceUI.eTraceTextBox
        Me.lblLanes = New eTraceUI.eTraceLabel
        Me.txtLanes = New eTraceUI.eTraceTextBox
        Me.lblProdu = New eTraceUI.eTraceLabel
        Me.txtProdu = New eTraceUI.eTraceTextBox
        Me.lblRemarks = New eTraceUI.eTraceLabel
        Me.txtRemarks = New eTraceUI.eTraceTextBox
        Me.cobFeederID = New eTraceUI.eTraceComboBox
        Me.FeederType = New System.Windows.Forms.TabPage
        Me.grpActionFT = New eTraceUI.eTraceGroupBox
        Me.tblActionFT = New eTraceUI.eTraceTableLayoutPanel
        Me.btnSaveFT = New eTraceUI.eTraceButton
        Me.btnCancelFT = New eTraceUI.eTraceButton
        Me.btnNewFT = New eTraceUI.eTraceButton
        Me.btnDelFT = New eTraceUI.eTraceButton
        Me.grpInputFT = New eTraceUI.eTraceGroupBox
        Me.dgvFeederSpec = New eTraceUI.eTraceDataGridView
        Me.Checked = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.FeederSpec = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tblFeederType = New eTraceUI.eTraceTableLayoutPanel
        Me.ckbShow = New eTraceUI.eTraceCheckBox
        Me.lblDes = New eTraceUI.eTraceLabel
        Me.txtDes = New eTraceUI.eTraceTextBox
        Me.cobFeederType = New eTraceUI.eTraceComboBox
        Me.lblFeederType = New eTraceUI.eTraceLabel
        Me.grpProcess = New eTraceUI.eTraceGroupBox
        Me.pnlProcess = New eTraceUI.eTraceTableLayoutPanel
        Me.lblProcess = New eTraceUI.eTraceLabel
        Me.ddlProcess = New eTraceUI.eTraceComboBox
        Me.chkAddlData = New eTraceUI.eTraceCheckBox
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.bgwPost = New System.ComponentModel.BackgroundWorker
        Me.pnlBody.SuspendLayout()
        Me.ETraceTabControl1.SuspendLayout()
        Me.Machine.SuspendLayout()
        Me.grpActionM.SuspendLayout()
        Me.tblActions.SuspendLayout()
        Me.grpInputM.SuspendLayout()
        Me.tblRemarks.SuspendLayout()
        Me.tblMachine.SuspendLayout()
        Me.Feeder.SuspendLayout()
        Me.grpActionF.SuspendLayout()
        Me.tblActionF.SuspendLayout()
        Me.grpInputF.SuspendLayout()
        Me.tblFeeder.SuspendLayout()
        Me.FeederType.SuspendLayout()
        Me.grpActionFT.SuspendLayout()
        Me.tblActionFT.SuspendLayout()
        Me.grpInputFT.SuspendLayout()
        CType(Me.dgvFeederSpec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tblFeederType.SuspendLayout()
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
        Me.pnlBody.Controls.Add(Me.ETraceTabControl1)
        Me.pnlBody.Controls.Add(Me.grpProcess)
        Me.pnlBody.Location = New System.Drawing.Point(0, 54)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Size = New System.Drawing.Size(789, 521)
        Me.pnlBody.TabIndex = 2
        '
        'ETraceTabControl1
        '
        Me.ETraceTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ETraceTabControl1.Controls.Add(Me.Machine)
        Me.ETraceTabControl1.Controls.Add(Me.Feeder)
        Me.ETraceTabControl1.Controls.Add(Me.FeederType)
        Me.ETraceTabControl1.Location = New System.Drawing.Point(0, 56)
        Me.ETraceTabControl1.Name = "ETraceTabControl1"
        Me.ETraceTabControl1.SelectedIndex = 0
        Me.ETraceTabControl1.Size = New System.Drawing.Size(786, 465)
        Me.ETraceTabControl1.TabIndex = 5
        Me.ETraceTabControl1.Tag = ""
        '
        'Machine
        '
        Me.Machine.Controls.Add(Me.grpActionM)
        Me.Machine.Controls.Add(Me.grpInputM)
        Me.Machine.Location = New System.Drawing.Point(4, 22)
        Me.Machine.Name = "Machine"
        Me.Machine.Padding = New System.Windows.Forms.Padding(3)
        Me.Machine.Size = New System.Drawing.Size(778, 439)
        Me.Machine.TabIndex = 2
        Me.Machine.Tag = ""
        Me.Machine.Text = "Machine"
        Me.Machine.UseVisualStyleBackColor = True
        '
        'grpActionM
        '
        Me.grpActionM.Controls.Add(Me.tblActions)
        Me.grpActionM.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpActionM.Location = New System.Drawing.Point(3, 391)
        Me.grpActionM.Name = "grpActionM"
        Me.grpActionM.Size = New System.Drawing.Size(772, 45)
        Me.grpActionM.TabIndex = 1
        Me.grpActionM.TabStop = False
        Me.grpActionM.Tag = "^TDC-119@"
        Me.grpActionM.Text = "Actions"
        '
        'tblActions
        '
        Me.tblActions.ColumnCount = 4
        Me.tblActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tblActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tblActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tblActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tblActions.Controls.Add(Me.btnSaveM, 0, 0)
        Me.tblActions.Controls.Add(Me.btnCancelM, 1, 0)
        Me.tblActions.Controls.Add(Me.btnNewM, 2, 0)
        Me.tblActions.Controls.Add(Me.btnDelM, 3, 0)
        Me.tblActions.Location = New System.Drawing.Point(5, 13)
        Me.tblActions.Name = "tblActions"
        Me.tblActions.RowCount = 1
        Me.tblActions.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblActions.Size = New System.Drawing.Size(476, 28)
        Me.tblActions.TabIndex = 0
        '
        'btnSaveM
        '
        Me.btnSaveM.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnSaveM.Location = New System.Drawing.Point(3, 3)
        Me.btnSaveM.Name = "btnSaveM"
        Me.btnSaveM.Size = New System.Drawing.Size(75, 22)
        Me.btnSaveM.TabIndex = 0
        Me.btnSaveM.Tag = "^TDC-115@"
        Me.btnSaveM.Text = "Save"
        Me.btnSaveM.UseVisualStyleBackColor = True
        '
        'btnCancelM
        '
        Me.btnCancelM.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnCancelM.Location = New System.Drawing.Point(84, 3)
        Me.btnCancelM.Name = "btnCancelM"
        Me.btnCancelM.Size = New System.Drawing.Size(75, 22)
        Me.btnCancelM.TabIndex = 1
        Me.btnCancelM.Tag = "^TDC-116@"
        Me.btnCancelM.Text = "Cancel"
        Me.btnCancelM.UseVisualStyleBackColor = True
        '
        'btnNewM
        '
        Me.btnNewM.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnNewM.Location = New System.Drawing.Point(165, 3)
        Me.btnNewM.Name = "btnNewM"
        Me.btnNewM.Size = New System.Drawing.Size(75, 22)
        Me.btnNewM.TabIndex = 2
        Me.btnNewM.Tag = "^TDC-117@"
        Me.btnNewM.Text = "New"
        Me.btnNewM.UseVisualStyleBackColor = True
        '
        'btnDelM
        '
        Me.btnDelM.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnDelM.Location = New System.Drawing.Point(246, 3)
        Me.btnDelM.Name = "btnDelM"
        Me.btnDelM.Size = New System.Drawing.Size(75, 22)
        Me.btnDelM.TabIndex = 3
        Me.btnDelM.Tag = "^TDC-118@"
        Me.btnDelM.Text = "Delete"
        Me.btnDelM.UseVisualStyleBackColor = True
        '
        'grpInputM
        '
        Me.grpInputM.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpInputM.Controls.Add(Me.tblRemarks)
        Me.grpInputM.Controls.Add(Me.tblMachine)
        Me.grpInputM.Location = New System.Drawing.Point(4, 3)
        Me.grpInputM.Name = "grpInputM"
        Me.grpInputM.Size = New System.Drawing.Size(772, 389)
        Me.grpInputM.TabIndex = 0
        Me.grpInputM.TabStop = False
        Me.grpInputM.Tag = "^TDC-111@"
        Me.grpInputM.Text = "Input Area"
        '
        'tblRemarks
        '
        Me.tblRemarks.ColumnCount = 2
        Me.tblRemarks.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.0!))
        Me.tblRemarks.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.0!))
        Me.tblRemarks.Controls.Add(Me.lblRemark, 0, 0)
        Me.tblRemarks.Controls.Add(Me.txtRemark, 1, 0)
        Me.tblRemarks.Location = New System.Drawing.Point(3, 144)
        Me.tblRemarks.Name = "tblRemarks"
        Me.tblRemarks.RowCount = 1
        Me.tblRemarks.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblRemarks.Size = New System.Drawing.Size(476, 30)
        Me.tblRemarks.TabIndex = 1
        '
        'lblRemark
        '
        Me.lblRemark.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRemark.AutoSize = True
        Me.lblRemark.Location = New System.Drawing.Point(3, 8)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(49, 13)
        Me.lblRemark.TabIndex = 0
        Me.lblRemark.Text = "Remarks"
        '
        'txtRemark
        '
        Me.txtRemark.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtRemark.BackColor = System.Drawing.SystemColors.Window
        Me.txtRemark.DataType = Nothing
        Me.txtRemark.ElementTitle = Me.lblRemark
        Me.txtRemark.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtRemark.ErrorMessage = Nothing
        Me.txtRemark.Location = New System.Drawing.Point(102, 5)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.NoOfDecimals = 0
        Me.txtRemark.ParentControl = Nothing
        Me.txtRemark.RegEx = Nothing
        Me.txtRemark.Required = False
        Me.txtRemark.Size = New System.Drawing.Size(343, 20)
        Me.txtRemark.StatusControl = Nothing
        Me.txtRemark.TabIndex = 1
        Me.txtRemark.Tag = "Remark"
        Me.txtRemark.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtRemark.ValidationType = Nothing
        Me.txtRemark.WarnColor = System.Drawing.Color.Wheat
        '
        'tblMachine
        '
        Me.tblMachine.ColumnCount = 6
        Me.tblMachine.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tblMachine.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tblMachine.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblMachine.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tblMachine.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tblMachine.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tblMachine.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblMachine.Controls.Add(Me.lblID, 0, 0)
        Me.tblMachine.Controls.Add(Me.lblManu, 3, 0)
        Me.tblMachine.Controls.Add(Me.txtManu, 4, 0)
        Me.tblMachine.Controls.Add(Me.lblModel, 0, 1)
        Me.tblMachine.Controls.Add(Me.txtModel, 1, 1)
        Me.tblMachine.Controls.Add(Me.lblProd, 3, 1)
        Me.tblMachine.Controls.Add(Me.txtProd, 4, 1)
        Me.tblMachine.Controls.Add(Me.ckbMulti, 0, 2)
        Me.tblMachine.Controls.Add(Me.ckbDaul, 1, 2)
        Me.tblMachine.Controls.Add(Me.cobID, 1, 0)
        Me.tblMachine.Location = New System.Drawing.Point(4, 14)
        Me.tblMachine.Name = "tblMachine"
        Me.tblMachine.RowCount = 3
        Me.tblMachine.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33332!))
        Me.tblMachine.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.tblMachine.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.tblMachine.Size = New System.Drawing.Size(476, 120)
        Me.tblMachine.TabIndex = 0
        '
        'lblID
        '
        Me.lblID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(3, 13)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(62, 13)
        Me.lblID.TabIndex = 0
        Me.lblID.Text = "Machine ID"
        '
        'lblManu
        '
        Me.lblManu.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblManu.AutoSize = True
        Me.lblManu.Location = New System.Drawing.Point(251, 13)
        Me.lblManu.Name = "lblManu"
        Me.lblManu.Size = New System.Drawing.Size(70, 13)
        Me.lblManu.TabIndex = 2
        Me.lblManu.Text = "Manufacturer"
        '
        'txtManu
        '
        Me.txtManu.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtManu.BackColor = System.Drawing.SystemColors.Window
        Me.txtManu.DataType = Nothing
        Me.txtManu.ElementTitle = Me.lblManu
        Me.txtManu.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtManu.ErrorMessage = Nothing
        Me.txtManu.Location = New System.Drawing.Point(338, 9)
        Me.txtManu.Name = "txtManu"
        Me.txtManu.NoOfDecimals = 0
        Me.txtManu.ParentControl = Nothing
        Me.txtManu.RegEx = Nothing
        Me.txtManu.Required = False
        Me.txtManu.Size = New System.Drawing.Size(100, 20)
        Me.txtManu.StatusControl = Nothing
        Me.txtManu.TabIndex = 5
        Me.txtManu.Tag = "Manufacturer"
        Me.txtManu.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtManu.ValidationType = Nothing
        Me.txtManu.WarnColor = System.Drawing.Color.Wheat
        '
        'lblModel
        '
        Me.lblModel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblModel.AutoSize = True
        Me.lblModel.Location = New System.Drawing.Point(3, 52)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(36, 13)
        Me.lblModel.TabIndex = 6
        Me.lblModel.Text = "Model"
        '
        'txtModel
        '
        Me.txtModel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtModel.BackColor = System.Drawing.SystemColors.Window
        Me.txtModel.DataType = Nothing
        Me.txtModel.ElementTitle = Me.lblModel
        Me.txtModel.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtModel.ErrorMessage = Nothing
        Me.txtModel.Location = New System.Drawing.Point(104, 49)
        Me.txtModel.Name = "txtModel"
        Me.txtModel.NoOfDecimals = 0
        Me.txtModel.ParentControl = Nothing
        Me.txtModel.RegEx = Nothing
        Me.txtModel.Required = False
        Me.txtModel.Size = New System.Drawing.Size(100, 20)
        Me.txtModel.StatusControl = Nothing
        Me.txtModel.TabIndex = 7
        Me.txtModel.Tag = "Model"
        Me.txtModel.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtModel.ValidationType = Nothing
        Me.txtModel.WarnColor = System.Drawing.Color.Wheat
        '
        'lblProd
        '
        Me.lblProd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblProd.AutoSize = True
        Me.lblProd.Location = New System.Drawing.Point(251, 52)
        Me.lblProd.Name = "lblProd"
        Me.lblProd.Size = New System.Drawing.Size(81, 13)
        Me.lblProd.TabIndex = 8
        Me.lblProd.Text = "Production Line"
        '
        'txtProd
        '
        Me.txtProd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtProd.BackColor = System.Drawing.SystemColors.Window
        Me.txtProd.DataType = Nothing
        Me.txtProd.ElementTitle = Me.lblProd
        Me.txtProd.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtProd.ErrorMessage = Nothing
        Me.txtProd.Location = New System.Drawing.Point(338, 49)
        Me.txtProd.Name = "txtProd"
        Me.txtProd.NoOfDecimals = 0
        Me.txtProd.ParentControl = Nothing
        Me.txtProd.RegEx = Nothing
        Me.txtProd.Required = False
        Me.txtProd.Size = New System.Drawing.Size(100, 20)
        Me.txtProd.StatusControl = Nothing
        Me.txtProd.TabIndex = 9
        Me.txtProd.Tag = "ProductionLine"
        Me.txtProd.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtProd.ValidationType = Nothing
        Me.txtProd.WarnColor = System.Drawing.Color.Wheat
        '
        'ckbMulti
        '
        Me.ckbMulti.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckbMulti.AutoSize = True
        Me.ckbMulti.Location = New System.Drawing.Point(3, 91)
        Me.ckbMulti.Name = "ckbMulti"
        Me.ckbMulti.Size = New System.Drawing.Size(95, 17)
        Me.ckbMulti.TabIndex = 10
        Me.ckbMulti.Tag = "MultiBanks"
        Me.ckbMulti.Text = "Multiple Banks"
        Me.ckbMulti.UseVisualStyleBackColor = True
        '
        'ckbDaul
        '
        Me.ckbDaul.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckbDaul.AutoSize = True
        Me.ckbDaul.Location = New System.Drawing.Point(104, 91)
        Me.ckbDaul.Name = "ckbDaul"
        Me.ckbDaul.Size = New System.Drawing.Size(83, 17)
        Me.ckbDaul.TabIndex = 11
        Me.ckbDaul.Tag = "DaulTables"
        Me.ckbDaul.Text = "Daul Tables"
        Me.ckbDaul.UseVisualStyleBackColor = True
        '
        'cobID
        '
        Me.cobID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cobID.DataType = Nothing
        Me.cobID.ElementTitle = Me.lblID
        Me.cobID.ErrorColor = System.Drawing.Color.DarkOrange
        Me.cobID.ErrorMessage = Nothing
        Me.cobID.FormattingEnabled = True
        Me.cobID.LimitToList = False
        Me.cobID.Location = New System.Drawing.Point(104, 9)
        Me.cobID.Name = "cobID"
        Me.cobID.NoOfDecimals = 0
        Me.cobID.ParentControl = Nothing
        Me.cobID.RegEx = Nothing
        Me.cobID.Required = False
        Me.cobID.Size = New System.Drawing.Size(121, 21)
        Me.cobID.StatusControl = Nothing
        Me.cobID.TabIndex = 12
        Me.cobID.Tag = "MachineID"
        Me.cobID.TextCase = eTraceUI.eTraceComboBox.TextCases.None
        Me.cobID.ValidationType = Nothing
        Me.cobID.WarnColor = System.Drawing.Color.Wheat
        '
        'Feeder
        '
        Me.Feeder.Controls.Add(Me.grpActionF)
        Me.Feeder.Controls.Add(Me.grpInputF)
        Me.Feeder.Location = New System.Drawing.Point(4, 22)
        Me.Feeder.Name = "Feeder"
        Me.Feeder.Padding = New System.Windows.Forms.Padding(3)
        Me.Feeder.Size = New System.Drawing.Size(741, 287)
        Me.Feeder.TabIndex = 1
        Me.Feeder.Text = "Feeder"
        Me.Feeder.UseVisualStyleBackColor = True
        '
        'grpActionF
        '
        Me.grpActionF.Controls.Add(Me.tblActionF)
        Me.grpActionF.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpActionF.Location = New System.Drawing.Point(3, 239)
        Me.grpActionF.Name = "grpActionF"
        Me.grpActionF.Size = New System.Drawing.Size(735, 45)
        Me.grpActionF.TabIndex = 1
        Me.grpActionF.TabStop = False
        Me.grpActionF.Tag = "^TDC-119@"
        Me.grpActionF.Text = "Actions"
        '
        'tblActionF
        '
        Me.tblActionF.ColumnCount = 4
        Me.tblActionF.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tblActionF.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tblActionF.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tblActionF.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 233.0!))
        Me.tblActionF.Controls.Add(Me.btnSaveF, 0, 0)
        Me.tblActionF.Controls.Add(Me.btnCancelF, 1, 0)
        Me.tblActionF.Controls.Add(Me.btnNewF, 2, 0)
        Me.tblActionF.Controls.Add(Me.btnDelF, 3, 0)
        Me.tblActionF.Location = New System.Drawing.Point(3, 13)
        Me.tblActionF.Name = "tblActionF"
        Me.tblActionF.RowCount = 1
        Me.tblActionF.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblActionF.Size = New System.Drawing.Size(476, 28)
        Me.tblActionF.TabIndex = 0
        Me.tblActionF.TabStop = True
        '
        'btnSaveF
        '
        Me.btnSaveF.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnSaveF.Location = New System.Drawing.Point(3, 3)
        Me.btnSaveF.Name = "btnSaveF"
        Me.btnSaveF.Size = New System.Drawing.Size(75, 22)
        Me.btnSaveF.TabIndex = 0
        Me.btnSaveF.Tag = "^TDC-115@"
        Me.btnSaveF.Text = "Save" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnSaveF.UseVisualStyleBackColor = True
        '
        'btnCancelF
        '
        Me.btnCancelF.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnCancelF.Location = New System.Drawing.Point(84, 3)
        Me.btnCancelF.Name = "btnCancelF"
        Me.btnCancelF.Size = New System.Drawing.Size(75, 22)
        Me.btnCancelF.TabIndex = 1
        Me.btnCancelF.Tag = "^TDC-116@"
        Me.btnCancelF.Text = "Cancel"
        Me.btnCancelF.UseVisualStyleBackColor = True
        '
        'btnNewF
        '
        Me.btnNewF.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnNewF.Location = New System.Drawing.Point(165, 3)
        Me.btnNewF.Name = "btnNewF"
        Me.btnNewF.Size = New System.Drawing.Size(75, 22)
        Me.btnNewF.TabIndex = 2
        Me.btnNewF.Tag = "^TDC-117@"
        Me.btnNewF.Text = "New"
        Me.btnNewF.UseVisualStyleBackColor = True
        '
        'btnDelF
        '
        Me.btnDelF.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnDelF.Location = New System.Drawing.Point(246, 3)
        Me.btnDelF.Name = "btnDelF"
        Me.btnDelF.Size = New System.Drawing.Size(75, 22)
        Me.btnDelF.TabIndex = 3
        Me.btnDelF.Tag = "^TDC-118@"
        Me.btnDelF.Text = "Delete"
        Me.btnDelF.UseVisualStyleBackColor = True
        '
        'grpInputF
        '
        Me.grpInputF.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpInputF.Controls.Add(Me.tblFeeder)
        Me.grpInputF.Location = New System.Drawing.Point(4, 3)
        Me.grpInputF.Name = "grpInputF"
        Me.grpInputF.Size = New System.Drawing.Size(733, 237)
        Me.grpInputF.TabIndex = 0
        Me.grpInputF.TabStop = False
        Me.grpInputF.Tag = "^TDC-111@"
        Me.grpInputF.Text = "Input Area"
        '
        'tblFeeder
        '
        Me.tblFeeder.ColumnCount = 5
        Me.tblFeeder.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tblFeeder.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tblFeeder.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblFeeder.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tblFeeder.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tblFeeder.Controls.Add(Me.lblFeederID, 0, 0)
        Me.tblFeeder.Controls.Add(Me.lblFeederSpec, 3, 0)
        Me.tblFeeder.Controls.Add(Me.txtFeederSpec, 4, 0)
        Me.tblFeeder.Controls.Add(Me.lblLanes, 0, 1)
        Me.tblFeeder.Controls.Add(Me.txtLanes, 1, 1)
        Me.tblFeeder.Controls.Add(Me.lblProdu, 3, 1)
        Me.tblFeeder.Controls.Add(Me.txtProdu, 4, 1)
        Me.tblFeeder.Controls.Add(Me.lblRemarks, 0, 2)
        Me.tblFeeder.Controls.Add(Me.txtRemarks, 1, 2)
        Me.tblFeeder.Controls.Add(Me.cobFeederID, 1, 0)
        Me.tblFeeder.Location = New System.Drawing.Point(3, 15)
        Me.tblFeeder.Name = "tblFeeder"
        Me.tblFeeder.RowCount = 3
        Me.tblFeeder.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tblFeeder.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tblFeeder.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tblFeeder.Size = New System.Drawing.Size(476, 160)
        Me.tblFeeder.TabIndex = 0
        '
        'lblFeederID
        '
        Me.lblFeederID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblFeederID.AutoSize = True
        Me.lblFeederID.Location = New System.Drawing.Point(3, 20)
        Me.lblFeederID.Name = "lblFeederID"
        Me.lblFeederID.Size = New System.Drawing.Size(54, 13)
        Me.lblFeederID.TabIndex = 0
        Me.lblFeederID.Text = "Feeder ID"
        '
        'lblFeederSpec
        '
        Me.lblFeederSpec.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblFeederSpec.AutoSize = True
        Me.lblFeederSpec.Location = New System.Drawing.Point(244, 20)
        Me.lblFeederSpec.Name = "lblFeederSpec"
        Me.lblFeederSpec.Size = New System.Drawing.Size(68, 13)
        Me.lblFeederSpec.TabIndex = 2
        Me.lblFeederSpec.Text = "Feeder Spec"
        '
        'txtFeederSpec
        '
        Me.txtFeederSpec.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtFeederSpec.BackColor = System.Drawing.SystemColors.Window
        Me.txtFeederSpec.DataType = Nothing
        Me.txtFeederSpec.ElementTitle = Me.lblFeederSpec
        Me.txtFeederSpec.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtFeederSpec.ErrorMessage = Nothing
        Me.txtFeederSpec.Location = New System.Drawing.Point(331, 16)
        Me.txtFeederSpec.Name = "txtFeederSpec"
        Me.txtFeederSpec.NoOfDecimals = 0
        Me.txtFeederSpec.ParentControl = Nothing
        Me.txtFeederSpec.RegEx = Nothing
        Me.txtFeederSpec.Required = False
        Me.txtFeederSpec.Size = New System.Drawing.Size(100, 20)
        Me.txtFeederSpec.StatusControl = Nothing
        Me.txtFeederSpec.TabIndex = 3
        Me.txtFeederSpec.Tag = "FeederSpec"
        Me.txtFeederSpec.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtFeederSpec.ValidationType = Nothing
        Me.txtFeederSpec.WarnColor = System.Drawing.Color.Wheat
        '
        'lblLanes
        '
        Me.lblLanes.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblLanes.AutoSize = True
        Me.lblLanes.Location = New System.Drawing.Point(3, 73)
        Me.lblLanes.Name = "lblLanes"
        Me.lblLanes.Size = New System.Drawing.Size(59, 13)
        Me.lblLanes.TabIndex = 4
        Me.lblLanes.Text = "Max Lanes"
        '
        'txtLanes
        '
        Me.txtLanes.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtLanes.BackColor = System.Drawing.SystemColors.Window
        Me.txtLanes.DataType = Nothing
        Me.txtLanes.ElementTitle = Me.lblLanes
        Me.txtLanes.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtLanes.ErrorMessage = Nothing
        Me.txtLanes.Location = New System.Drawing.Point(68, 69)
        Me.txtLanes.Name = "txtLanes"
        Me.txtLanes.NoOfDecimals = 0
        Me.txtLanes.ParentControl = Nothing
        Me.txtLanes.RegEx = Nothing
        Me.txtLanes.Required = False
        Me.txtLanes.Size = New System.Drawing.Size(100, 20)
        Me.txtLanes.StatusControl = Nothing
        Me.txtLanes.TabIndex = 5
        Me.txtLanes.Tag = "MaxLanes"
        Me.txtLanes.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtLanes.ValidationType = Nothing
        Me.txtLanes.WarnColor = System.Drawing.Color.Wheat
        '
        'lblProdu
        '
        Me.lblProdu.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblProdu.AutoSize = True
        Me.lblProdu.Location = New System.Drawing.Point(244, 73)
        Me.lblProdu.Name = "lblProdu"
        Me.lblProdu.Size = New System.Drawing.Size(81, 13)
        Me.lblProdu.TabIndex = 6
        Me.lblProdu.Text = "Production Line"
        '
        'txtProdu
        '
        Me.txtProdu.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtProdu.BackColor = System.Drawing.SystemColors.Window
        Me.txtProdu.DataType = Nothing
        Me.txtProdu.ElementTitle = Me.lblProdu
        Me.txtProdu.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtProdu.ErrorMessage = Nothing
        Me.txtProdu.Location = New System.Drawing.Point(331, 69)
        Me.txtProdu.Name = "txtProdu"
        Me.txtProdu.NoOfDecimals = 0
        Me.txtProdu.ParentControl = Nothing
        Me.txtProdu.RegEx = Nothing
        Me.txtProdu.Required = False
        Me.txtProdu.Size = New System.Drawing.Size(100, 20)
        Me.txtProdu.StatusControl = Nothing
        Me.txtProdu.TabIndex = 7
        Me.txtProdu.Tag = "ProductionLines"
        Me.txtProdu.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtProdu.ValidationType = Nothing
        Me.txtProdu.WarnColor = System.Drawing.Color.Wheat
        '
        'lblRemarks
        '
        Me.lblRemarks.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Location = New System.Drawing.Point(3, 126)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(49, 13)
        Me.lblRemarks.TabIndex = 8
        Me.lblRemarks.Text = "Remarks" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtRemarks
        '
        Me.txtRemarks.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtRemarks.BackColor = System.Drawing.SystemColors.Window
        Me.txtRemarks.DataType = Nothing
        Me.txtRemarks.ElementTitle = Me.lblRemarks
        Me.txtRemarks.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtRemarks.ErrorMessage = Nothing
        Me.txtRemarks.Location = New System.Drawing.Point(68, 123)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.NoOfDecimals = 0
        Me.txtRemarks.ParentControl = Nothing
        Me.txtRemarks.RegEx = Nothing
        Me.txtRemarks.Required = False
        Me.txtRemarks.Size = New System.Drawing.Size(150, 20)
        Me.txtRemarks.StatusControl = Nothing
        Me.txtRemarks.TabIndex = 9
        Me.txtRemarks.Tag = "Remarks"
        Me.txtRemarks.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtRemarks.ValidationType = Nothing
        Me.txtRemarks.WarnColor = System.Drawing.Color.Wheat
        '
        'cobFeederID
        '
        Me.cobFeederID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cobFeederID.DataType = Nothing
        Me.cobFeederID.ElementTitle = Me.lblFeederID
        Me.cobFeederID.ErrorColor = System.Drawing.Color.DarkOrange
        Me.cobFeederID.ErrorMessage = Nothing
        Me.cobFeederID.FormattingEnabled = True
        Me.cobFeederID.LimitToList = False
        Me.cobFeederID.Location = New System.Drawing.Point(68, 16)
        Me.cobFeederID.Name = "cobFeederID"
        Me.cobFeederID.NoOfDecimals = 0
        Me.cobFeederID.ParentControl = Nothing
        Me.cobFeederID.RegEx = Nothing
        Me.cobFeederID.Required = False
        Me.cobFeederID.Size = New System.Drawing.Size(121, 21)
        Me.cobFeederID.StatusControl = Nothing
        Me.cobFeederID.TabIndex = 10
        Me.cobFeederID.Tag = "FeederID"
        Me.cobFeederID.TextCase = eTraceUI.eTraceComboBox.TextCases.None
        Me.cobFeederID.ValidationType = Nothing
        Me.cobFeederID.WarnColor = System.Drawing.Color.Wheat
        '
        'FeederType
        '
        Me.FeederType.Controls.Add(Me.grpActionFT)
        Me.FeederType.Controls.Add(Me.grpInputFT)
        Me.FeederType.Location = New System.Drawing.Point(4, 22)
        Me.FeederType.Name = "FeederType"
        Me.FeederType.Padding = New System.Windows.Forms.Padding(3)
        Me.FeederType.Size = New System.Drawing.Size(741, 287)
        Me.FeederType.TabIndex = 0
        Me.FeederType.Text = "FeederType"
        Me.FeederType.UseVisualStyleBackColor = True
        '
        'grpActionFT
        '
        Me.grpActionFT.Controls.Add(Me.tblActionFT)
        Me.grpActionFT.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpActionFT.Location = New System.Drawing.Point(3, 239)
        Me.grpActionFT.Name = "grpActionFT"
        Me.grpActionFT.Size = New System.Drawing.Size(735, 45)
        Me.grpActionFT.TabIndex = 1
        Me.grpActionFT.TabStop = False
        Me.grpActionFT.Tag = "^TDC-119@"
        Me.grpActionFT.Text = "Actions"
        '
        'tblActionFT
        '
        Me.tblActionFT.ColumnCount = 4
        Me.tblActionFT.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tblActionFT.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tblActionFT.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tblActionFT.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 237.0!))
        Me.tblActionFT.Controls.Add(Me.btnSaveFT, 0, 0)
        Me.tblActionFT.Controls.Add(Me.btnCancelFT, 1, 0)
        Me.tblActionFT.Controls.Add(Me.btnNewFT, 2, 0)
        Me.tblActionFT.Controls.Add(Me.btnDelFT, 3, 0)
        Me.tblActionFT.Location = New System.Drawing.Point(3, 14)
        Me.tblActionFT.Name = "tblActionFT"
        Me.tblActionFT.RowCount = 1
        Me.tblActionFT.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblActionFT.Size = New System.Drawing.Size(480, 28)
        Me.tblActionFT.TabIndex = 0
        '
        'btnSaveFT
        '
        Me.btnSaveFT.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnSaveFT.Location = New System.Drawing.Point(3, 3)
        Me.btnSaveFT.Name = "btnSaveFT"
        Me.btnSaveFT.Size = New System.Drawing.Size(75, 22)
        Me.btnSaveFT.TabIndex = 0
        Me.btnSaveFT.Tag = "^TDC-115@"
        Me.btnSaveFT.Text = "Save"
        Me.btnSaveFT.UseVisualStyleBackColor = True
        '
        'btnCancelFT
        '
        Me.btnCancelFT.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnCancelFT.Location = New System.Drawing.Point(84, 3)
        Me.btnCancelFT.Name = "btnCancelFT"
        Me.btnCancelFT.Size = New System.Drawing.Size(75, 22)
        Me.btnCancelFT.TabIndex = 1
        Me.btnCancelFT.Tag = "^TDC-116@"
        Me.btnCancelFT.Text = "Cancel"
        Me.btnCancelFT.UseVisualStyleBackColor = True
        '
        'btnNewFT
        '
        Me.btnNewFT.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnNewFT.Location = New System.Drawing.Point(165, 3)
        Me.btnNewFT.Name = "btnNewFT"
        Me.btnNewFT.Size = New System.Drawing.Size(75, 22)
        Me.btnNewFT.TabIndex = 2
        Me.btnNewFT.Tag = "^TDC-117@"
        Me.btnNewFT.Text = "New"
        Me.btnNewFT.UseVisualStyleBackColor = True
        '
        'btnDelFT
        '
        Me.btnDelFT.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnDelFT.Location = New System.Drawing.Point(246, 3)
        Me.btnDelFT.Name = "btnDelFT"
        Me.btnDelFT.Size = New System.Drawing.Size(75, 22)
        Me.btnDelFT.TabIndex = 3
        Me.btnDelFT.Tag = "^TDC-118@"
        Me.btnDelFT.Text = "Delete"
        Me.btnDelFT.UseVisualStyleBackColor = True
        '
        'grpInputFT
        '
        Me.grpInputFT.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpInputFT.Controls.Add(Me.dgvFeederSpec)
        Me.grpInputFT.Controls.Add(Me.tblFeederType)
        Me.grpInputFT.Location = New System.Drawing.Point(0, 5)
        Me.grpInputFT.Name = "grpInputFT"
        Me.grpInputFT.Size = New System.Drawing.Size(738, 233)
        Me.grpInputFT.TabIndex = 0
        Me.grpInputFT.TabStop = False
        Me.grpInputFT.Tag = "^TDC-111@"
        Me.grpInputFT.Text = "Input Area"
        '
        'dgvFeederSpec
        '
        Me.dgvFeederSpec.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvFeederSpec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFeederSpec.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Checked, Me.FeederSpec})
        Me.dgvFeederSpec.Location = New System.Drawing.Point(4, 82)
        Me.dgvFeederSpec.Name = "dgvFeederSpec"
        Me.dgvFeederSpec.Size = New System.Drawing.Size(480, 144)
        Me.dgvFeederSpec.TabIndex = 1
        '
        'Checked
        '
        Me.Checked.DataPropertyName = "Checked"
        Me.Checked.HeaderText = ""
        Me.Checked.Name = "Checked"
        Me.Checked.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Checked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'FeederSpec
        '
        Me.FeederSpec.DataPropertyName = "FeederSpec"
        Me.FeederSpec.HeaderText = "FeederSpec"
        Me.FeederSpec.Name = "FeederSpec"
        Me.FeederSpec.ToolTipText = "FeederSpecdgv"
        '
        'tblFeederType
        '
        Me.tblFeederType.ColumnCount = 5
        Me.tblFeederType.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tblFeederType.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tblFeederType.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblFeederType.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tblFeederType.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 208.0!))
        Me.tblFeederType.Controls.Add(Me.ckbShow, 3, 0)
        Me.tblFeederType.Controls.Add(Me.lblDes, 0, 1)
        Me.tblFeederType.Controls.Add(Me.txtDes, 1, 1)
        Me.tblFeederType.Controls.Add(Me.cobFeederType, 1, 0)
        Me.tblFeederType.Controls.Add(Me.lblFeederType, 0, 0)
        Me.tblFeederType.Location = New System.Drawing.Point(4, 14)
        Me.tblFeederType.Name = "tblFeederType"
        Me.tblFeederType.RowCount = 2
        Me.tblFeederType.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblFeederType.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblFeederType.Size = New System.Drawing.Size(480, 66)
        Me.tblFeederType.TabIndex = 0
        '
        'ckbShow
        '
        Me.ckbShow.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckbShow.AutoSize = True
        Me.ckbShow.Location = New System.Drawing.Point(223, 8)
        Me.ckbShow.Name = "ckbShow"
        Me.ckbShow.Size = New System.Drawing.Size(67, 17)
        Me.ckbShow.TabIndex = 2
        Me.ckbShow.Tag = "Showall"
        Me.ckbShow.Text = "Show All"
        Me.ckbShow.UseVisualStyleBackColor = True
        '
        'lblDes
        '
        Me.lblDes.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDes.AutoSize = True
        Me.lblDes.Location = New System.Drawing.Point(3, 43)
        Me.lblDes.Name = "lblDes"
        Me.lblDes.Size = New System.Drawing.Size(60, 13)
        Me.lblDes.TabIndex = 3
        Me.lblDes.Text = "Description"
        '
        'txtDes
        '
        Me.txtDes.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtDes.BackColor = System.Drawing.SystemColors.Window
        Me.txtDes.DataType = Nothing
        Me.txtDes.ElementTitle = Nothing
        Me.txtDes.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtDes.ErrorMessage = Nothing
        Me.txtDes.Location = New System.Drawing.Point(76, 39)
        Me.txtDes.Name = "txtDes"
        Me.txtDes.NoOfDecimals = 0
        Me.txtDes.ParentControl = Nothing
        Me.txtDes.RegEx = Nothing
        Me.txtDes.Required = False
        Me.txtDes.Size = New System.Drawing.Size(100, 20)
        Me.txtDes.StatusControl = Nothing
        Me.txtDes.TabIndex = 4
        Me.txtDes.Tag = "Des"
        Me.txtDes.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtDes.ValidationType = Nothing
        Me.txtDes.WarnColor = System.Drawing.Color.Wheat
        '
        'cobFeederType
        '
        Me.cobFeederType.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cobFeederType.DataType = Nothing
        Me.cobFeederType.ElementTitle = Me.lblFeederType
        Me.cobFeederType.ErrorColor = System.Drawing.Color.DarkOrange
        Me.cobFeederType.ErrorMessage = Nothing
        Me.cobFeederType.FormattingEnabled = True
        Me.cobFeederType.LimitToList = False
        Me.cobFeederType.Location = New System.Drawing.Point(76, 6)
        Me.cobFeederType.Name = "cobFeederType"
        Me.cobFeederType.NoOfDecimals = 0
        Me.cobFeederType.ParentControl = Nothing
        Me.cobFeederType.RegEx = Nothing
        Me.cobFeederType.Required = False
        Me.cobFeederType.Size = New System.Drawing.Size(121, 21)
        Me.cobFeederType.StatusControl = Nothing
        Me.cobFeederType.TabIndex = 5
        Me.cobFeederType.Tag = "FeederType"
        Me.cobFeederType.TextCase = eTraceUI.eTraceComboBox.TextCases.None
        Me.cobFeederType.ValidationType = Nothing
        Me.cobFeederType.WarnColor = System.Drawing.Color.Wheat
        '
        'lblFeederType
        '
        Me.lblFeederType.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblFeederType.AutoSize = True
        Me.lblFeederType.Location = New System.Drawing.Point(3, 10)
        Me.lblFeederType.Name = "lblFeederType"
        Me.lblFeederType.Size = New System.Drawing.Size(67, 13)
        Me.lblFeederType.TabIndex = 6
        Me.lblFeederType.Text = "Feeder Type"
        '
        'grpProcess
        '
        Me.grpProcess.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpProcess.Controls.Add(Me.pnlProcess)
        Me.grpProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.grpProcess.Location = New System.Drawing.Point(1, 6)
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
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 374.0!))
        Me.pnlProcess.Controls.Add(Me.lblProcess, 0, 0)
        Me.pnlProcess.Controls.Add(Me.ddlProcess, 1, 0)
        Me.pnlProcess.Controls.Add(Me.chkAddlData, 7, 0)
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
        Me.chkAddlData.Location = New System.Drawing.Point(424, 3)
        Me.chkAddlData.Name = "chkAddlData"
        Me.chkAddlData.Size = New System.Drawing.Size(146, 22)
        Me.chkAddlData.TabIndex = 2
        Me.chkAddlData.TabStop = False
        Me.chkAddlData.Tag = "chkAddlData"
        Me.chkAddlData.Text = "Additional Data Input"
        Me.chkAddlData.UseVisualStyleBackColor = True
        Me.chkAddlData.Visible = False
        '
        'frmSMT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(791, 596)
        Me.Controls.Add(Me.pnlBody)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "frmSMT"
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.Controls.SetChildIndex(Me.pnlBody, 0)
        Me.Controls.SetChildIndex(Me.MessageBar1, 0)
        Me.pnlBody.ResumeLayout(False)
        Me.ETraceTabControl1.ResumeLayout(False)
        Me.Machine.ResumeLayout(False)
        Me.grpActionM.ResumeLayout(False)
        Me.tblActions.ResumeLayout(False)
        Me.grpInputM.ResumeLayout(False)
        Me.tblRemarks.ResumeLayout(False)
        Me.tblRemarks.PerformLayout()
        Me.tblMachine.ResumeLayout(False)
        Me.tblMachine.PerformLayout()
        Me.Feeder.ResumeLayout(False)
        Me.grpActionF.ResumeLayout(False)
        Me.tblActionF.ResumeLayout(False)
        Me.grpInputF.ResumeLayout(False)
        Me.tblFeeder.ResumeLayout(False)
        Me.tblFeeder.PerformLayout()
        Me.FeederType.ResumeLayout(False)
        Me.grpActionFT.ResumeLayout(False)
        Me.tblActionFT.ResumeLayout(False)
        Me.grpInputFT.ResumeLayout(False)
        CType(Me.dgvFeederSpec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tblFeederType.ResumeLayout(False)
        Me.tblFeederType.PerformLayout()
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
    Friend WithEvents bgwPost As System.ComponentModel.BackgroundWorker
    Friend WithEvents ETraceTabControl1 As eTraceUI.eTraceTabControl
    Friend WithEvents Machine As System.Windows.Forms.TabPage
    Friend WithEvents grpActionM As eTraceUI.eTraceGroupBox
    Friend WithEvents tblActions As eTraceUI.eTraceTableLayoutPanel
    Friend WithEvents btnSaveM As eTraceUI.eTraceButton
    Friend WithEvents btnCancelM As eTraceUI.eTraceButton
    Friend WithEvents btnNewM As eTraceUI.eTraceButton
    Friend WithEvents btnDelM As eTraceUI.eTraceButton
    Friend WithEvents grpInputM As eTraceUI.eTraceGroupBox
    Friend WithEvents tblRemarks As eTraceUI.eTraceTableLayoutPanel
    Friend WithEvents lblRemark As eTraceUI.eTraceLabel
    Friend WithEvents txtRemark As eTraceUI.eTraceTextBox
    Friend WithEvents tblMachine As eTraceUI.eTraceTableLayoutPanel
    Friend WithEvents lblID As eTraceUI.eTraceLabel
    Friend WithEvents lblManu As eTraceUI.eTraceLabel
    Friend WithEvents txtManu As eTraceUI.eTraceTextBox
    Friend WithEvents lblModel As eTraceUI.eTraceLabel
    Friend WithEvents txtModel As eTraceUI.eTraceTextBox
    Friend WithEvents lblProd As eTraceUI.eTraceLabel
    Friend WithEvents txtProd As eTraceUI.eTraceTextBox
    Friend WithEvents ckbMulti As eTraceUI.eTraceCheckBox
    Friend WithEvents ckbDaul As eTraceUI.eTraceCheckBox
    Friend WithEvents cobID As eTraceUI.eTraceComboBox
    Friend WithEvents Feeder As System.Windows.Forms.TabPage
    Friend WithEvents grpActionF As eTraceUI.eTraceGroupBox
    Friend WithEvents tblActionF As eTraceUI.eTraceTableLayoutPanel
    Friend WithEvents btnSaveF As eTraceUI.eTraceButton
    Friend WithEvents btnCancelF As eTraceUI.eTraceButton
    Friend WithEvents btnNewF As eTraceUI.eTraceButton
    Friend WithEvents btnDelF As eTraceUI.eTraceButton
    Friend WithEvents grpInputF As eTraceUI.eTraceGroupBox
    Friend WithEvents tblFeeder As eTraceUI.eTraceTableLayoutPanel
    Friend WithEvents lblFeederID As eTraceUI.eTraceLabel
    Friend WithEvents lblFeederSpec As eTraceUI.eTraceLabel
    Friend WithEvents txtFeederSpec As eTraceUI.eTraceTextBox
    Friend WithEvents lblLanes As eTraceUI.eTraceLabel
    Friend WithEvents txtLanes As eTraceUI.eTraceTextBox
    Friend WithEvents lblProdu As eTraceUI.eTraceLabel
    Friend WithEvents txtProdu As eTraceUI.eTraceTextBox
    Friend WithEvents lblRemarks As eTraceUI.eTraceLabel
    Friend WithEvents txtRemarks As eTraceUI.eTraceTextBox
    Friend WithEvents cobFeederID As eTraceUI.eTraceComboBox
    Friend WithEvents FeederType As System.Windows.Forms.TabPage
    Friend WithEvents grpActionFT As eTraceUI.eTraceGroupBox
    Friend WithEvents tblActionFT As eTraceUI.eTraceTableLayoutPanel
    Friend WithEvents btnSaveFT As eTraceUI.eTraceButton
    Friend WithEvents btnCancelFT As eTraceUI.eTraceButton
    Friend WithEvents btnNewFT As eTraceUI.eTraceButton
    Friend WithEvents btnDelFT As eTraceUI.eTraceButton
    Friend WithEvents grpInputFT As eTraceUI.eTraceGroupBox
    Friend WithEvents dgvFeederSpec As eTraceUI.eTraceDataGridView
    Friend WithEvents Checked As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents FeederSpec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tblFeederType As eTraceUI.eTraceTableLayoutPanel
    Friend WithEvents ckbShow As eTraceUI.eTraceCheckBox
    Friend WithEvents lblDes As eTraceUI.eTraceLabel
    Friend WithEvents txtDes As eTraceUI.eTraceTextBox
    Friend WithEvents cobFeederType As eTraceUI.eTraceComboBox
    Friend WithEvents lblFeederType As eTraceUI.eTraceLabel

End Class
