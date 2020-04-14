Public Class frmFixtureMount
    Public ProcessID As Integer
    Public CurrProcess As String
    Dim _user As String
    Dim _dsRecord As DataSet
    ''' <summary>
    ''' the input in textbox "txtSize" can not be larger then _maxSize
    ''' </summary>
    Const C_MAXSIZE = 100
    Const C_COLNAME_INTSN = "IntSN"
    Const C_COLNAME_PCBA = "PCBA"
    Const C_COLNAME_Process = "Process"
    Dim currentRowIndex As Integer
    Dim AllPass As Boolean
    Private flgBusy As Boolean = False
    Private Delegate Sub UpdateUI(ByVal ReceivedData As String)
    'Dim SFC009 As Integer
    'Dim SFC015 As String         'Auto Burn-in time calculation based on WIP In/Out, if PASS  
    'Dim SFC016 As String         'Burn In - Allow WIP Out without WIP In(Yes/No)
    'Dim SFC023 As String         'Auto Burn-in time calculation based on WIP In/Out,  if FAIL (Yes/No)
    'Dim SFC024 As String         '

    Public Overrides Sub NewSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'New Instance of the form
        Dim NewInstance As New frmMain()
        NewInstance.ShowFrm(Me)

    End Sub

    Private Sub frmTemplate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AttachHotkey(btnPost, Keys.F8)
        AttachHotkey(btnCancel, Keys.F5)
        ProcessID = SelectProcessID
        CurrProcess = SelectProcess
        BindCtlsToProcess(Me, ProcessID)

        'SFC009 = Convert.ToInt32(BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC009'")(0)("Value")))
        'SFC016 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC016'")(0)("Value")).ToUpper
        'SFC015 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC015'")(0)("Value")).ToUpper
        'SFC023 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC023'")(0)("Value")).ToUpper
        'SFC024 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC024'")(0)("Value")).ToUpper
        Me.ShowMessage(ProcessShow, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
    End Sub

    Private Sub frmTemplate_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        ddlProcess.Text = ProcessShow
        Me.CenterToScreen()
        _user = Mid(UserName.Text, 1, InStr(UserName.Text, "-") - 1).Trim
        'txtIntSerial.Focus()
        InitDatagridview()
        BLL.LoginData.User = _user
        BLL.LoginData.OrgCode = Mid(MyOrg(), 1, 3)
        BLL.LoginData.ProductionLine = ProductionLine()
    End Sub

    'Private Sub txtIntSerial_ValidateData() Handles txtFixtureID.ValidateData
    '    txtIntSerial.Text = Trim(txtIntSerial.Text)
    '    If txtIntSerial.Text.Length < SFC009 Then
    '        Me.ShowMessage("^TDC-23@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
    '        txtIntSerial.SelectAll()
    '        txtIntSerial.Focus()
    '        Exit Sub
    '    End If
    '    Me.ShowMessage("^TDC-24@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
    '    pnlBody.Enabled = False
    '    Me.bgwIntSerial.RunWorkerAsync()
    'End Sub








    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        ClearDataInput()
    End Sub



    Private Sub ClearDataInput()
        txtFixtureID.Enabled = True
        Me.DisableValidation = True
        grpDataInput.Enabled = True
        btnPost.Enabled = True
        _dsRecord.Clear()
        InitDatagridview()
        'dgvResult.DataSource = Nothing
        DisableValidation = False
        txtIntSN.Clear()
        txtFixtureID.Clear()
        txtFixtureID.Focus()
    End Sub





    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        If _dsRecord.Tables(0).Rows.Count > 0 Then
            SaveResult()
        Else
            Me.ShowMessage("^SFC-140@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        End If
    End Sub

    Private Sub bgwPost_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwPost.DoWork
        e.Result = BLL.FixtureMount(_dsRecord, txtFixtureID.Text, _user)
    End Sub


    Private Sub bgwPost_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPost.RunWorkerCompleted
        If e.Result = "^TDC-60@" Then
            Me.ShowMessage("^TDC-60@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
            ClearDataInput()
        Else
            Me.ShowMessage(e.Result, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            grpDataInput.Enabled = True
            btnPost.Enabled = True
        End If
    End Sub


    'Private Sub txtBurnInTime_ValidateData() Handles txtBurnInTime.ValidateData
    '    If txtIntSerial.Highlight = True Then Exit Sub
    '    If txtPCBASerial.Highlight = True Then Exit Sub
    '    If txtInputVoltage.Highlight = True Then Exit Sub
    '    If txtResultCode.Highlight = True Then Exit Sub
    '    If txtBurnInTime.Highlight = True Then Exit Sub
    '    With BLL.StatusHeader
    '        .IntSerial = txtIntSerial.Text
    '        .ExtSerial = Me.txtPCBASerial.Text
    '        .Process = CurrProcess
    '        .OperatorName = User
    '        .Tester = txtPCBASerial.Text        'Oven ID
    '        .Result = txtResultCode.Text
    '        .ProgramName = txtInputVoltage.Text 'Input Voltage
    '        .ProgramVersion = txtBurnInTime.Text  'BurnIn Time
    '    End With

    '    bgwPost.RunWorkerAsync()
    'End Sub

    Private Sub frmBurnIn_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Try
            SerialPort1.Open()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmBurnIn_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Try
            SerialPort1.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        If flgBusy = False Then
            flgBusy = True
            'There may be special character at the end of the Read string, need to check here
            Dim strReadLine, strRange As String
            strReadLine = SerialPort1.ReadLine.ToString.ToUpper
            strRange = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            If InStr(strRange, Microsoft.VisualBasic.Right(strReadLine, 1)) = 0 Then
                strReadLine = Mid(strReadLine, 1, Len(strReadLine) - 1)
            End If
            SerialPort1.DiscardInBuffer()
            Dim updateUIDelegate As New UpdateUI(AddressOf WriteBox)
            Dim args As Object() = {strReadLine}
            Me.Invoke(updateUIDelegate, args)
        End If
    End Sub

    Private Sub WriteBox(ByVal ReceivedText As String)
        'If txtIntSerial.Focused Then
        '    txtIntSerial.Text = ReceivedText
        '    txtIntSerial.Modified = True
        '    My.Computer.Keyboard.SendKeys("{TAB}")
        'ElseIf txtPCBASerial.Focused Then
        '    txtPCBASerial.Text = ReceivedText
        '    txtPCBASerial.Modified = True
        '    My.Computer.Keyboard.SendKeys("{TAB}")
        'ElseIf txtResultCode.Focused Then
        '    txtResultCode.Text = ReceivedText
        '    My.Computer.Keyboard.SendKeys("{TAB}")
        'ElseIf txtBurnInTime.Focused Then
        '    txtBurnInTime.Text = ReceivedText
        '    My.Computer.Keyboard.SendKeys("{TAB}")
        'End If
        'flgBusy = False
    End Sub





    'Create WIP Dataset


    Private Sub txtFixtureID_ValidateData() Handles txtFixtureID.ValidateData
        txtFixtureID.Text = txtFixtureID.Text.Trim
        If String.IsNullOrEmpty(txtFixtureID.Text) Then

            Me.ShowMessage("^sfc-139@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtFixtureID.Clear()
            txtFixtureID.Focus()
            Return
        End If

        If _dsRecord.Tables(0).Rows.Count > 0 Then
            Dim fixtureID As String
            fixtureID = _dsRecord.Tables(0).Rows(0).Item("PCBA").ToString()
            If txtFixtureID.Text <> fixtureID Then
                Me.ShowMessage("^SFC-136@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtFixtureID.Clear()
                txtFixtureID.Focus()
                Return
            End If
        End If
        Me.ShowMessage("^TDC-130@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
        bgwFixtureID.RunWorkerAsync()
    End Sub

    Private Sub txtSize_ValidateData() Handles txtSize.ValidateData
        txtSize.Text = Trim(txtSize.Text)
        If Not BLL.IsPositiveInteger(txtSize.Text) Then
            Me.ShowMessage("^sfc-128@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtSize.SelectAll()
            txtSize.Focus()
            Exit Sub
        End If
        If FixtureSize > C_MAXSIZE Then
            Me.ShowMessage("^sfc-137@" + C_MAXSIZE.ToString, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtSize.SelectAll()
            txtSize.Focus()
            Exit Sub
        End If
        If FixtureSize < _dsRecord.Tables(0).Rows.Count Then
            Me.ShowMessage("^sfc-138@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtSize.Clear()
            txtSize.Focus()
            Exit Sub
        End If
        'txtSize.Enabled = False
        'Me.ShowMessage("^TDC-24@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
        'pnlBody.Enabled = False
        'Me.bgwIntSerial.RunWorkerAsync()
    End Sub

    Private Sub txtIntSN_ValidateData() Handles txtIntSN.ValidateData
        txtIntSN.Text = txtIntSN.Text.Trim
        If String.IsNullOrEmpty(txtIntSN.Text) Then
            txtIntSN.Focus()
            Return
        End If
        If FixtureSize = 0 Then
            Me.ShowMessage("^sfc-128@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtSize.SelectAll()
            txtSize.Focus()
            Return
        End If
        If String.IsNullOrEmpty(txtFixtureID.Text.Trim) Then
            Me.ShowMessage("^sfc-139@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtFixtureID.SelectAll()
            txtFixtureID.Focus()
            Return
        End If
        For i As Integer = 0 To _dsRecord.Tables(0).Rows.Count - 1
            If _dsRecord.Tables(0).Rows(i).Item(C_COLNAME_INTSN).ToString.Equals(txtIntSN.Text) Then
                'If Me.ShowMessage("^SFC-129@", eTraceUI.eTraceMessageBar.MessageTypes.Warning, AnimationStatus.StopAnim, True, PopUpTypes.Question) = False Then
                '    'Give up 
                '    txtIntSN.SelectAll()
                '    txtIntSN.Focus()
                '    Return
                'Else
                '    Exit For
                'End If
                Me.ShowMessage("^SFC-135@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtIntSN.SelectAll()
                txtIntSN.Focus()
                Return
            End If
        Next
        If dgvResult.RowCount >= FixtureSize Then
            Me.ShowMessage("^SFC-132@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)

            Return
        End If
        Me.ShowMessage("^TDC-24@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)

        bgwIntSerial.RunWorkerAsync()
    End Sub

    Private Sub bgwIntSerial_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwIntSerial.DoWork
        Try
            'e.Result = BLL.CheckIntSn(txtIntSN.Text)
            e.Result = BLL.GetWipHeaderByIntSN(txtIntSN.Text)
        Catch ex As Exception
            BLL.ErrorLogging("SFCfixturemount-bgwIntSerial_DoWork", _user, ex.Message)
        End Try
    End Sub

    Private Sub bgwIntSerial_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwIntSerial.RunWorkerCompleted
        Dim ds As DataSet
        Dim table As DataTable
        Dim PCBA As String
        Dim currentProcess As String
        Dim Result As String
        Dim PanelID As String
        ds = e.Result
        If ds Is Nothing Then
            Me.ShowMessage("^SFC-133@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSN.SelectAll()
            txtIntSN.Focus()
            Return
        End If
        table = ds.Tables(0)
        If table Is Nothing Then
            Me.ShowMessage("^SFC-133@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSN.SelectAll()
            txtIntSN.Focus()
            Return
        End If
        ''rows count equals 0  mean no record match where intSn={intSn}
        If table.Rows.Count = 0 Then
            Me.ShowMessage("^SFC-133@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSN.SelectAll()
            txtIntSN.Focus()
            Return
        End If
        PCBA = table.Rows(0).Item("PCBA").ToString
        currentProcess = table.Rows(0).Item("currentProcess").ToString
        Result = table.Rows(0).Item("Result").ToString
        PanelID = table.Rows(0).Item("PanelID").ToString
        If Not examData(PCBA, currentProcess) Then
            Me.ShowMessage("^SFC-143@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSN.SelectAll()
            txtIntSN.Focus()
            Return
        End If

        If Result <> "PASS" Then
            Me.ShowMessage("^SFC-142@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSN.SelectAll()
            txtIntSN.Focus()
            Return
        End If
        If Not String.IsNullOrEmpty(PanelID) Then
            'exist panel, ask  wheather continue?
            If Me.ShowMessage("^SFC-144@" + PanelID + "^SFC-145@" + txtFixtureID.Text + "^SFC-146@", eTraceUI.eTraceMessageBar.MessageTypes.Warning, AnimationStatus.StopAnim, True, PopUpTypes.Question) = False Then
                'Give up 
                txtIntSN.Clear()
                txtIntSN.Focus()
                Return
            End If
            'Else
            '    'other error situation
            '    Me.ShowMessage(response.ErrorMessage, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            '    txtIntSN.Clear()
            '    txtIntSN.Focus()
            '    Return
        End If
        '' add to   gridview 
        _dsRecord.Tables(0).Rows.Add(New String() {txtIntSN.Text, PCBA, currentProcess})
        'dgvResult.Rows(_dsRecord.Tables(0).Rows.Count - 1).Tag = response
        If dgvResult.RowCount < FixtureSize Then
            txtIntSN.Text = String.Empty
            txtIntSN.Focus()
        Else
            SaveResult()
        End If
        Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
    End Sub
    ''' <summary>
    ''' update GridViewData to Webservice
    ''' </summary>
    Private Sub SaveResult()
        'Me.ShowMessage("^TDC-29@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
        If examData() Then
            bgwPost.RunWorkerAsync()
        Else
            Me.ShowMessage("^SFC-143@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        End If
    End Sub

    Private ReadOnly Property FixtureSize As Integer
        Get
            Dim fSize As Integer = 0

            If BLL.IsPositiveInteger(txtSize.Text) Then
                Return Integer.Parse(txtSize.Text)
            Else
                Return 0
            End If
        End Get
    End Property

    Private Sub bgwFixtureID_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwFixtureID.DoWork
        Try
            e.Result = BLL.CheckFixtureID(txtFixtureID.Text)
        Catch ex As Exception
            BLL.ErrorLogging("SFCfixturemount-bgwIntSerial_DoWork", _user, ex.Message)
        End Try
    End Sub

    Private Sub bgwFixtureID_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwFixtureID.RunWorkerCompleted
        If e.Result <> "PASS" Then

            If e.Result = "^SFC-131@" Then
                'Give up 
                If Me.ShowMessage("^SFC-131@", eTraceUI.eTraceMessageBar.MessageTypes.Warning, AnimationStatus.StopAnim, True, PopUpTypes.Question) = False Then
                    txtSize.SelectAll()
                    txtFixtureID.SelectAll()
                    txtFixtureID.Clear()
                    txtFixtureID.Focus()
                    Return
                Else
                    ''to-do clear fixtureID
                    BLL.ClearFixtureID(txtFixtureID.Text)
                End If
            ElseIf e.Result = "^SFC-134@" Then
                Me.ShowMessage("^SFC-134@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtSize.SelectAll()
                txtFixtureID.Clear()
                txtFixtureID.Focus()
                Return
            Else
                Me.ShowMessage(e.Result, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtSize.SelectAll()
                txtFixtureID.Clear()
                txtFixtureID.Focus()
                Return
            End If

        End If
        txtFixtureID.Enabled = False
        If String.IsNullOrEmpty(txtSize.Text) Then
            txtSize.Focus()
        Else
            txtIntSN.Focus()
        End If
        Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub InitDatagridview()
        _dsRecord = New DataSet("DS")
        '_dsRecord.Tables.Add()
        Dim table As New DataTable
        Dim myDataColumn As DataColumn
        myDataColumn = New Data.DataColumn(C_COLNAME_INTSN, System.Type.GetType("System.String"))
        table.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn(C_COLNAME_PCBA, System.Type.GetType("System.String"))
        table.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn(C_COLNAME_Process, System.Type.GetType("System.String"))
        table.Columns.Add(myDataColumn)
        _dsRecord.Tables.Add(table)
        dgvResult.DataSource = _dsRecord.Tables(0)

    End Sub

    Private Function examData() As Boolean
        For i As Integer = 0 To dgvResult.Rows.Count - 2
            For j As Integer = i + 1 To dgvResult.RowCount - 1
                If dgvResult.Rows(i).Cells(C_COLNAME_PCBA).Value = dgvResult.Rows(j).Cells(C_COLNAME_PCBA).Value Then
                    If dgvResult.Rows(i).Cells(C_COLNAME_Process).Value <> dgvResult.Rows(j).Cells(C_COLNAME_Process).Value Then
                        dgvResult.Rows(i).Cells(C_COLNAME_Process).Style.ForeColor = Color.Red
                        dgvResult.Rows(j).Cells(C_COLNAME_Process).Style.ForeColor = Color.Red
                        Return False
                    End If
                End If
            Next
        Next
        Return True
    End Function
    ''' <summary>
    ''' exam Process when adding to list
    ''' </summary>
    ''' <param name="PCBA"></param>
    ''' <param name="process"></param>
    ''' <returns></returns>
    Private Function examData(ByVal PCBA As String, ByVal process As String) As Boolean
        Dim eachPCBA As String
        Dim eachProcess As String
        For i As Integer = 0 To dgvResult.RowCount - 1
            eachPCBA = dgvResult.Rows(i).Cells(C_COLNAME_PCBA).Value
            eachProcess = dgvResult.Rows(i).Cells(C_COLNAME_Process).Value
            If eachPCBA = PCBA AndAlso eachProcess <> process Then
                dgvResult.Rows(i).Cells(C_COLNAME_Process).Style.ForeColor = Color.Red
                Return False
            Else
                dgvResult.Rows(i).Cells(C_COLNAME_Process).Style.ForeColor = DefaultForeColor
            End If
        Next

        Return True
    End Function



    Private Sub dgvResult_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvResult.RowsAdded
        lblSizeAdded.Text = dgvResult.RowCount.ToString + "/"
    End Sub

    Private Sub dgvResult_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvResult.RowsRemoved
        lblSizeAdded.Text = dgvResult.RowCount.ToString + "/"
    End Sub
End Class
