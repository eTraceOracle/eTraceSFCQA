<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangeBox
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
        Me.ETraceTableLayoutPanel2 = New eTraceUI.eTraceTableLayoutPanel
        Me.ETraceLabel3 = New eTraceUI.eTraceLabel
        Me.lblPCBASerial = New eTraceUI.eTraceLabel
        Me.txtPCBASerial = New eTraceUI.eTraceTextBox
        Me.ETraceTableLayoutPanel1 = New eTraceUI.eTraceTableLayoutPanel
        Me.txtIntSerial = New eTraceUI.eTraceTextBox
        Me.lblIntserial = New eTraceUI.eTraceLabel
        Me.txtExtSerial = New eTraceUI.eTraceTextBox
        Me.lblExtSerial = New eTraceUI.eTraceLabel
        Me.dgvResult = New eTraceUI.eTraceDataGridView
        Me.ExtSN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Choose = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.grpModel = New eTraceUI.eTraceGroupBox
        Me.pnlModel = New eTraceUI.eTraceTableLayoutPanel
        Me.txtProdQty = New eTraceUI.eTraceTextBox
        Me.lblProdQty = New eTraceUI.eTraceLabel
        Me.txtPCBANo = New eTraceUI.eTraceTextBox
        Me.lblPCBANo = New eTraceUI.eTraceLabel
        Me.lblMsg = New eTraceUI.eTraceLabel
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
        Me.bgwChangePick = New System.ComponentModel.BackgroundWorker
        Me.bgwPO = New System.ComponentModel.BackgroundWorker
        Me.pnlBody.SuspendLayout()
        Me.grpActions.SuspendLayout()
        Me.pnlActions.SuspendLayout()
        Me.grpDataInput.SuspendLayout()
        Me.ETraceTableLayoutPanel2.SuspendLayout()
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
        Me.MessageBar1.Location = New System.Drawing.Point(0, 585)
        Me.MessageBar1.Size = New System.Drawing.Size(816, 22)
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
        Me.pnlBody.Size = New System.Drawing.Size(814, 532)
        Me.pnlBody.TabIndex = 2
        '
        'grpActions
        '
        Me.grpActions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpActions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.grpActions.Controls.Add(Me.pnlActions)
        Me.grpActions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpActions.Location = New System.Drawing.Point(3, 475)
        Me.grpActions.Name = "grpActions"
        Me.grpActions.Size = New System.Drawing.Size(808, 51)
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
        Me.pnlActions.Size = New System.Drawing.Size(802, 32)
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
        Me.grpDataInput.Controls.Add(Me.ETraceTableLayoutPanel2)
        Me.grpDataInput.Controls.Add(Me.ETraceTableLayoutPanel1)
        Me.grpDataInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDataInput.Location = New System.Drawing.Point(4, 129)
        Me.grpDataInput.Name = "grpDataInput"
        Me.grpDataInput.Size = New System.Drawing.Size(808, 344)
        Me.grpDataInput.TabIndex = 2
        Me.grpDataInput.TabStop = False
        Me.grpDataInput.Tag = "^TDC-2@"
        Me.grpDataInput.Text = "Data Input"
        '
        'ETraceTableLayoutPanel2
        '
        Me.ETraceTableLayoutPanel2.ColumnCount = 8
        Me.ETraceTableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.ETraceTableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.ETraceTableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.ETraceTableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.ETraceTableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126.0!))
        Me.ETraceTableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.ETraceTableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.ETraceTableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.ETraceTableLayoutPanel2.Controls.Add(Me.ETraceLabel3, 0, 2)
        Me.ETraceTableLayoutPanel2.Controls.Add(Me.lblPCBASerial, 0, 0)
        Me.ETraceTableLayoutPanel2.Controls.Add(Me.txtPCBASerial, 1, 0)
        Me.ETraceTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ETraceTableLayoutPanel2.Location = New System.Drawing.Point(3, 311)
        Me.ETraceTableLayoutPanel2.Name = "ETraceTableLayoutPanel2"
        Me.ETraceTableLayoutPanel2.RowCount = 3
        Me.ETraceTableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.ETraceTableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.ETraceTableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.ETraceTableLayoutPanel2.Size = New System.Drawing.Size(802, 30)
        Me.ETraceTableLayoutPanel2.TabIndex = 3
        '
        'ETraceLabel3
        '
        Me.ETraceLabel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ETraceLabel3.Location = New System.Drawing.Point(3, 37)
        Me.ETraceLabel3.Margin = New System.Windows.Forms.Padding(3)
        Me.ETraceLabel3.Name = "ETraceLabel3"
        Me.ETraceLabel3.Size = New System.Drawing.Size(100, 14)
        Me.ETraceLabel3.TabIndex = 15
        Me.ETraceLabel3.Tag = ""
        Me.ETraceLabel3.Text = "Sub PCBA Serial No"
        Me.ETraceLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPCBASerial
        '
        Me.lblPCBASerial.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPCBASerial.Location = New System.Drawing.Point(3, 10)
        Me.lblPCBASerial.Margin = New System.Windows.Forms.Padding(3)
        Me.lblPCBASerial.Name = "lblPCBASerial"
        Me.lblPCBASerial.Size = New System.Drawing.Size(100, 14)
        Me.lblPCBASerial.TabIndex = 15
        Me.lblPCBASerial.Tag = ""
        Me.lblPCBASerial.Text = "Sub PCBA Serial No"
        Me.lblPCBASerial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPCBASerial
        '
        Me.txtPCBASerial.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPCBASerial.BackColor = System.Drawing.SystemColors.Window
        Me.txtPCBASerial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPCBASerial.DataType = Nothing
        Me.txtPCBASerial.ElementTitle = Me.lblPCBASerial
        Me.txtPCBASerial.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtPCBASerial.ErrorMessage = Nothing
        Me.txtPCBASerial.KeyIn = True
        Me.txtPCBASerial.Location = New System.Drawing.Point(133, 4)
        Me.txtPCBASerial.Name = "txtPCBASerial"
        Me.txtPCBASerial.NoOfDecimals = 0
        Me.txtPCBASerial.ParentControl = Nothing
        Me.txtPCBASerial.RegEx = Nothing
        Me.txtPCBASerial.Required = False
        Me.txtPCBASerial.Size = New System.Drawing.Size(194, 20)
        Me.txtPCBASerial.StatusControl = Nothing
        Me.txtPCBASerial.TabIndex = 6
        Me.txtPCBASerial.Tag = "NewBoxID"
        Me.txtPCBASerial.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtPCBASerial.ValidationType = Nothing
        Me.txtPCBASerial.WarnColor = System.Drawing.Color.Wheat
        '
        'ETraceTableLayoutPanel1
        '
        Me.ETraceTableLayoutPanel1.ColumnCount = 8
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.ETraceTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtIntSerial, 1, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblIntserial, 0, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.txtExtSerial, 7, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.lblExtSerial, 6, 0)
        Me.ETraceTableLayoutPanel1.Controls.Add(Me.dgvResult, 0, 1)
        Me.ETraceTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ETraceTableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.ETraceTableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 40)
        Me.ETraceTableLayoutPanel1.Name = "ETraceTableLayoutPanel1"
        Me.ETraceTableLayoutPanel1.RowCount = 2
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.ETraceTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.ETraceTableLayoutPanel1.Size = New System.Drawing.Size(802, 325)
        Me.ETraceTableLayoutPanel1.TabIndex = 2
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
        Me.txtIntSerial.Location = New System.Drawing.Point(139, 3)
        Me.txtIntSerial.Name = "txtIntSerial"
        Me.txtIntSerial.NoOfDecimals = 0
        Me.txtIntSerial.ParentControl = Nothing
        Me.txtIntSerial.RegEx = Nothing
        Me.txtIntSerial.Required = False
        Me.txtIntSerial.Size = New System.Drawing.Size(300, 20)
        Me.txtIntSerial.StatusControl = Nothing
        Me.txtIntSerial.TabIndex = 4
        Me.txtIntSerial.Tag = "BoxIDSN"
        Me.txtIntSerial.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtIntSerial.ValidationType = Nothing
        Me.txtIntSerial.WarnColor = System.Drawing.Color.Wheat
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
        'txtExtSerial
        '
        Me.txtExtSerial.BackColor = System.Drawing.SystemColors.Window
        Me.txtExtSerial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtExtSerial.DataType = Nothing
        Me.txtExtSerial.ElementTitle = Me.lblExtSerial
        Me.txtExtSerial.ErrorColor = System.Drawing.Color.DarkOrange
        Me.txtExtSerial.ErrorMessage = Nothing
        Me.txtExtSerial.KeyIn = True
        Me.txtExtSerial.Location = New System.Drawing.Point(595, 3)
        Me.txtExtSerial.Name = "txtExtSerial"
        Me.txtExtSerial.NoOfDecimals = 0
        Me.txtExtSerial.ParentControl = Nothing
        Me.txtExtSerial.RegEx = Nothing
        Me.txtExtSerial.Required = False
        Me.txtExtSerial.Size = New System.Drawing.Size(100, 20)
        Me.txtExtSerial.StatusControl = Nothing
        Me.txtExtSerial.TabIndex = 5
        Me.txtExtSerial.Tag = "Total"
        Me.txtExtSerial.TextCase = eTraceUI.eTraceTextBox.TextCases.None
        Me.txtExtSerial.ValidationType = Nothing
        Me.txtExtSerial.WarnColor = System.Drawing.Color.Wheat
        '
        'lblExtSerial
        '
        Me.lblExtSerial.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblExtSerial.Location = New System.Drawing.Point(465, 6)
        Me.lblExtSerial.Name = "lblExtSerial"
        Me.lblExtSerial.Size = New System.Drawing.Size(124, 14)
        Me.lblExtSerial.TabIndex = 17
        Me.lblExtSerial.Tag = ""
        Me.lblExtSerial.Text = "Total"
        '
        'dgvResult
        '
        Me.dgvResult.AllowUserToAddRows = False
        Me.dgvResult.AllowUserToDeleteRows = False
        Me.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResult.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ExtSN, Me.BoxID, Me.Choose})
        Me.ETraceTableLayoutPanel1.SetColumnSpan(Me.dgvResult, 8)
        Me.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResult.Location = New System.Drawing.Point(3, 30)
        Me.dgvResult.Margin = New System.Windows.Forms.Padding(3, 3, 3, 33)
        Me.dgvResult.Name = "dgvResult"
        Me.dgvResult.ReadOnly = True
        Me.dgvResult.RowHeadersWidth = 23
        Me.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvResult.Size = New System.Drawing.Size(796, 262)
        Me.dgvResult.TabIndex = 21
        Me.dgvResult.TabStop = False
        '
        'ExtSN
        '
        Me.ExtSN.DataPropertyName = "ExtSN"
        Me.ExtSN.FillWeight = 217.1582!
        Me.ExtSN.HeaderText = "ExtSN"
        Me.ExtSN.Name = "ExtSN"
        Me.ExtSN.ReadOnly = True
        Me.ExtSN.ToolTipText = "ExtSN"
        Me.ExtSN.Width = 540
        '
        'BoxID
        '
        Me.BoxID.DataPropertyName = "BoxID"
        Me.BoxID.FillWeight = 55.19081!
        Me.BoxID.HeaderText = "BoxID"
        Me.BoxID.Name = "BoxID"
        Me.BoxID.ReadOnly = True
        Me.BoxID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BoxID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.BoxID.ToolTipText = "BoxID"
        Me.BoxID.Width = 137
        '
        'Choose
        '
        Me.Choose.DataPropertyName = "Choose"
        Me.Choose.FillWeight = 27.65102!
        Me.Choose.HeaderText = "Choose"
        Me.Choose.Name = "Choose"
        Me.Choose.ReadOnly = True
        Me.Choose.ToolTipText = "Choose"
        Me.Choose.Width = 69
        '
        'grpModel
        '
        Me.grpModel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpModel.Controls.Add(Me.pnlModel)
        Me.grpModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpModel.Location = New System.Drawing.Point(3, 54)
        Me.grpModel.Name = "grpModel"
        Me.grpModel.Size = New System.Drawing.Size(808, 72)
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
        Me.pnlModel.Controls.Add(Me.lblProdQty, 6, 1)
        Me.pnlModel.Controls.Add(Me.txtPCBANo, 4, 1)
        Me.pnlModel.Controls.Add(Me.lblPCBANo, 3, 1)
        Me.pnlModel.Controls.Add(Me.lblMsg, 3, 0)
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
        'lblMsg
        '
        Me.lblMsg.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.pnlModel.SetColumnSpan(Me.lblMsg, 5)
        Me.lblMsg.Location = New System.Drawing.Point(285, 6)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(400, 14)
        Me.lblMsg.TabIndex = 6
        Me.lblMsg.Tag = ""
        Me.lblMsg.Text = "PCBA No"
        Me.lblMsg.Visible = False
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
        Me.grpProcess.Size = New System.Drawing.Size(809, 47)
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
        Me.pnlProcess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 404.0!))
        Me.pnlProcess.Controls.Add(Me.lblProcess, 0, 0)
        Me.pnlProcess.Controls.Add(Me.ddlProcess, 1, 0)
        Me.pnlProcess.Controls.Add(Me.chkAddlData, 7, 0)
        Me.pnlProcess.Controls.Add(Me.btnEMI, 3, 0)
        Me.pnlProcess.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlProcess.Location = New System.Drawing.Point(3, 16)
        Me.pnlProcess.Name = "pnlProcess"
        Me.pnlProcess.RowCount = 1
        Me.pnlProcess.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlProcess.Size = New System.Drawing.Size(803, 28)
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
        'bgwPO
        '
        '
        'frmChangeBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(816, 607)
        Me.Controls.Add(Me.pnlBody)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "frmChangeBox"
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
        Me.ETraceTableLayoutPanel2.ResumeLayout(False)
        Me.ETraceTableLayoutPanel2.PerformLayout()
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
    Friend WithEvents lblMsg As eTraceUI.eTraceLabel
    Friend WithEvents lblPCBANo As eTraceUI.eTraceLabel
    Friend WithEvents txtPCBANo As eTraceUI.eTraceTextBox
    Friend WithEvents lblProdQty As eTraceUI.eTraceLabel
    Friend WithEvents txtProdQty As eTraceUI.eTraceTextBox
    Friend WithEvents bgwPost As System.ComponentModel.BackgroundWorker
    Friend WithEvents ETraceTableLayoutPanel1 As eTraceUI.eTraceTableLayoutPanel
    Friend WithEvents txtPCBASerial As eTraceUI.eTraceTextBox
    Friend WithEvents txtIntSerial As eTraceUI.eTraceTextBox
    Friend WithEvents lblIntserial As eTraceUI.eTraceLabel
    Friend WithEvents lblPCBASerial As eTraceUI.eTraceLabel
    Friend WithEvents lblExtSerial As eTraceUI.eTraceLabel
    Friend WithEvents txtExtSerial As eTraceUI.eTraceTextBox
    Friend WithEvents bgwIntSerial As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwChangePick As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnEMI As eTraceUI.eTraceButton
    Friend WithEvents dgvResult As eTraceUI.eTraceDataGridView
    Friend WithEvents bgwPO As System.ComponentModel.BackgroundWorker
    Friend WithEvents ETraceTableLayoutPanel2 As eTraceUI.eTraceTableLayoutPanel
    Friend WithEvents ETraceLabel3 As eTraceUI.eTraceLabel
    Friend WithEvents ExtSN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Choose As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
