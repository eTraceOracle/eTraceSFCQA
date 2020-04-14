Public Class frmModelSwop
    Public ProcessID As Integer
    Public CurrProcess As String
    Dim User As String
    Dim record As DataTable
    Dim AllPass As Boolean
    Dim dsWIP As DataSet
    Dim dtResultList As DataTable
    Dim dtFlow As DataTable
    Dim Emifile As Object
    Private flgBusy As Boolean = False
    Private Delegate Sub UpdateUI(ByVal ReceivedData As String)
    Dim SFC001 As String
    Dim SFC004 As String
    Dim SFC009 As Integer
    Dim SFC019 As String
    Dim ModelRev As String
    Dim POQty As Double
    Dim ExtSNSameIntSN As Boolean
    Dim TraceLevel As String
    Dim PanelSize As Integer
    Dim ForceSwop As Boolean = False
    Dim DJOrgCode As String

    Public Overrides Sub NewSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'New Instance of the form
        Dim NewInstance As New frmMain()
        NewInstance.ShowFrm(Me)
    End Sub

    Private Sub frmModelSwop_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AttachHotkey(btnPost, Keys.F8)
        AttachHotkey(btnNew, Keys.F5)
        AttachHotkey(btnReset, Keys.F3)
        AttachHotkey(btnPrint, Keys.F9)
        ProcessID = SelectProcessID
        CurrProcess = SelectProcess
        BindCtlsToProcess(Me, ProcessID)
        SFC001 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC001'")(0)("Value"))
        SFC004 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC004'")(0)("Value"))
        SFC009 = Convert.ToInt32(BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC009'")(0)("Value")))
        SFC019 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC019'")(0)("Value"))
        If SFC004.ToUpper = "NO" Then
            txtIntSerial.KeyIn = False
            txtExtSerial.KeyIn = False
        Else
            txtIntSerial.KeyIn = True
            txtExtSerial.KeyIn = True
        End If
        Me.ShowMessage(ProcessShow, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
    End Sub

    Private Sub frmModelSwop_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        ddlProcess.Text = ProcessShow
        Me.CenterToScreen()
        User = Mid(UserName.Text, 1, InStr(UserName.Text, "-") - 1).Trim
        BLL.LoginData.User = User
        BLL.LoginData.OrgCode = Mid(MyOrg(), 1, 3)
        BLL.LoginData.ProductionLine = ProductionLine()
        chkAddlData.Focus()
        'txtPONo.Focus()
    End Sub

    Private Sub txtIntSerial_ValidateData() Handles txtIntSerial.ValidateData
        txtIntSerial.Text = Trim(txtIntSerial.Text)
        If txtIntSerial.Text = "" Then Exit Sub
        If txtPONo.Text.Trim = "" Then
            txtPONo.Focus()
            txtIntSerial.Text = ""
            Exit Sub
        End If

        If txtIntSerial.Text.Length < SFC009 Then
            Me.ShowMessage("^TDC-23@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
            Exit Sub
        End If

        Me.ShowMessage("^TDC-24@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
        pnlBody.Enabled = False
        Me.bgwIntSerial.RunWorkerAsync()
    End Sub

    Private Sub bgwIntSerial_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwIntSerial.DoWork
        Try
            e.Result = BLL.GetResultAndPCBAList(txtIntSerial.Text, CurrProcess)
        Catch ex As Exception
            BLL.ErrorLogging("SFCMatchingN-bgwIntSerial_DoWork", User, ex.Message)
        End Try
    End Sub

    Private Sub bgwIntSerial_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwIntSerial.RunWorkerCompleted
        pnlBody.Enabled = True
        If e.Result.Tables(0).rows(0)("ErrMsg") <> "" Then
            Me.ShowMessage("ERROR: " & txtIntSerial.Text & " ^TDC-5@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
            Return
        End If
        AllPass = False
        Dim FlowSeqNo As Integer = 0
        Dim NewModel As String
        Dim OldModel As String
        OldModel = txtModelNo.Text
        NewModel = e.Result.Tables(1).rows(0)("Model").ToString
        If NewModel = OldModel Then
            Me.ShowMessage("^SFC-123@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
            Exit Sub
        End If

        Dim ArrayNewModel() As String
        Dim ArrayOldModel() As String
        ArrayNewModel = Split(NewModel, "-")
        ArrayOldModel = Split(OldModel, "-")
        If ArrayNewModel.Length <> ArrayOldModel.Length Then
            Me.ShowMessage("^SFC-124@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
            Exit Sub
        End If

        Dim iArr As Integer
        For iArr = 0 To ArrayNewModel.Length - 2
            If ArrayNewModel(iArr) <> ArrayOldModel(iArr) Then
                Me.ShowMessage("^SFC-124@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtIntSerial.SelectAll()
                txtIntSerial.Focus()
                Exit Sub
            End If
        Next

        'txtModelNo.Text = e.Result.Tables(1).rows(0)("Model").ToString
        'txtPCBANo.Text = e.Result.Tables(1).rows(0)("PCBA").ToString
        'txtPONo.Text = e.Result.Tables(1).rows(0)("DJ").ToString
        dtResultList = e.Result.Tables(2)
        If dtResultList.Rows(0)("Process").ToString.Trim = "Rework" Or dtResultList.Rows(0)("Process").ToString.Trim.ToUpper = "RETEST" Then
            dtResultList.Rows(0).Delete()
            dtResultList.AcceptChanges()
        End If
        dgvResult.DataSource = dtResultList
        If dtResultList.Rows.Count <> dtFlow.Rows.Count Then
            Me.ShowMessage("^SFC-122@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
            Return
        Else
            Dim iCompare As Integer
            For iCompare = 0 To dtResultList.Rows.Count - 1
                If dtResultList.Rows(iCompare)("Process").ToString.Trim.ToUpper <> dtFlow.Rows(iCompare)("Process").ToString.Trim.ToUpper Then
                    Me.ShowMessage("^SFC-122@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtIntSerial.SelectAll()
                    txtIntSerial.Focus()
                    Return
                End If
            Next
        End If

        Dim iRows As Integer
        iRows = dtResultList.Rows.Count
        Dim i As Integer
        Dim ErrFound As Boolean = False
        If chkAddlData.Checked Then
            For i = 0 To iRows - 1
                If ErrFound = True Then
                    ForceSwop = True
                    Exit For
                End If

                If dtResultList.Rows(i)(0).ToString.Trim.ToUpper = CurrProcess.ToUpper Then   'For current process, fill in "pass" here
                    If dtResultList.Rows(i)(1) = "PASS" Or dtResultList.Rows(i)(1) = "SKIP" Then
                        'Me.ShowMessage("^SFC-2@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                        'txtIntSerial.SelectAll()
                        'txtIntSerial.Focus()
                        'Return
                        dgvResult.Rows(i).Cells(1).Style.ForeColor = Color.Red
                        ErrFound = True
                    Else
                        'If dtResultList.Rows(i)(1) = "FAIL" Then
                        '    Dim LargeMax As String
                        '    LargeMax = BLL.LargeThanMaxTest(txtIntSerial.Text, CurrProcess)
                        '    If LargeMax <> "PASS" Then
                        '        Me.ShowMessage(LargeMax, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                        '        txtIntSerial.SelectAll()
                        '        txtIntSerial.Focus()
                        '        Return
                        '    End If
                        'End If
                        dtResultList.Rows(i)(1) = "WIPIN"
                        dgvResult.Rows(i).Cells(1).Style.ForeColor = Color.Green
                        dgvResult.Rows(i).Cells(2).Style.ForeColor = Color.Green
                        FlowSeqNo = dtResultList.Rows(i)(2)
                    End If
                    Exit For
                End If
                If Microsoft.VisualBasic.Left(dtResultList.Rows(i)(1).ToString.ToUpper, 4) <> "PASS" Then
                    dgvResult.Rows(i).Cells(1).Style.ForeColor = Color.Red
                    ErrFound = True
                End If
            Next

        End If

        If Not chkAddlData.Checked Then
            If e.Result.Tables(1).rows(0)("CurrentProcess").ToString = "Repair" And e.Result.Tables(1).rows(0)("Result").ToString <> "Fixed" Then
                Me.ShowMessage("^SFC-66@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtIntSerial.SelectAll()
                txtIntSerial.Focus()
                Return
            End If

            Dim HasProc As Integer = 0
            HasProc = dtResultList.Select("Process='" & CurrProcess & "'").Length
            If HasProc = 0 Then
                Me.ShowMessage("ERROR: " & CurrProcess & " " & "^SFC-7@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtIntSerial.SelectAll()
                txtIntSerial.Focus()
                Return
            End If

            For i = 0 To iRows - 1
                If ErrFound = True Then
                    Me.ShowMessage("^TDC-13@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtIntSerial.SelectAll()
                    txtIntSerial.Focus()
                    Return
                End If

                If dtResultList.Rows(i)(0).ToString.Trim.ToUpper = CurrProcess.ToUpper Then   'For current process, fill in "pass" here
                    If dtResultList.Rows(i)(1).ToString.Trim = "PASS" Or dtResultList.Rows(i)(1).ToString.Trim = "SKIP" Then
                        Me.ShowMessage("^SFC-2@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                        txtIntSerial.SelectAll()
                        txtIntSerial.Focus()
                        Return
                    Else
                        'If dtResultList.Rows(i)(1) = "FAIL" Then
                        '    Dim LargeMax As String
                        '    LargeMax = BLL.LargeThanMaxTest(txtIntSerial.Text, CurrProcess)
                        '    If LargeMax <> "PASS" Then
                        '        Me.ShowMessage(LargeMax, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                        '        txtIntSerial.SelectAll()
                        '        txtIntSerial.Focus()
                        '        Return
                        '    End If
                        'End If
                        dtResultList.Rows(i)(1) = "WIPIN"
                        dgvResult.Rows(i).Cells(1).Style.ForeColor = Color.Green
                        dgvResult.Rows(i).Cells(2).Style.ForeColor = Color.Green
                        FlowSeqNo = dtResultList.Rows(i)(2)
                    End If
                    Exit For
                End If
                If Microsoft.VisualBasic.Left(dtResultList.Rows(i)(1).ToString.ToUpper, 4) <> "PASS" Then
                    dgvResult.Rows(i).Cells(1).Style.ForeColor = Color.Red
                    ErrFound = True
                End If
            Next

            If dtResultList.Rows(iRows - 1)("Process").ToString.Trim.ToUpper = CurrProcess.ToUpper Then
                AllPass = True
            Else
                AllPass = False
            End If
        End If

        dsWIP = dsVI()
        Dim dr As DataRow
        dr = dsWIP.Tables("WIPHeader").NewRow()
        dr("WIPID") = e.Result.Tables(1).rows(0)("WIPID").ToString
        dr("IntSN") = txtIntSerial.Text
        dr("Model") = txtModelNo.Text
        dr("PCBA") = txtPCBANo.Text
        dr("DJ") = txtPONo.Text
        dr("OldDJ") = e.Result.Tables(1).rows(0)("DJ").ToString
        dr("InvOrg") = DJOrgCode
        dr("ProdLine") = BLL.LoginData.ProductionLine
        dr("CurrentProcess") = CurrProcess
        dr("FlowSeqNo") = FlowSeqNo
        dr("Result") = "PASS"
        dr("AllPassed") = AllPass
        dr("ChangedBy") = User
        dsWIP.Tables("WIPHeader").Rows.Add(dr)

        If BLL.MatchingAccount(txtPONo.Text, DJOrgCode, txtPCBANo.Text, 1, PanelSize) Then
            Me.ShowMessage("^TDC-24@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
            'pnlBody.Enabled = False
            'Me.bgwPost.RunWorkerAsync()
        Else
            Select Case SFC001.ToUpper
                Case "WARNING"
                    'Warning: Matching Qty > PO Qty! Continue?
                    If Me.ShowMessage("^TDC-70@", eTraceUI.eTraceMessageBar.MessageTypes.Warning, AnimationStatus.StopAnim, True, PopUpTypes.Question) = True Then
                        If BLL.MatchingAccount(txtPONo.Text, DJOrgCode, txtPCBANo.Text, 0, PanelSize) = True Then
                            'Me.bgwPost.RunWorkerAsync()
                        Else
                            txtIntSerial.Clear()
                            txtIntSerial.Focus()
                            Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
                            Exit Sub
                        End If
                    Else
                        pnlBody.Enabled = True
                        txtProdQty.Text = BLL.GetDJMatchedQty(txtPONo.Text, txtPCBANo.Text, DJOrgCode)
                        txtIntSerial.Clear()
                        txtIntSerial.Focus()
                        Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
                        Exit Sub
                    End If
                Case "ERROR"
                    'Error: Matching Qty > PO Qty!
                    Me.ShowMessage("^SFC-43@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    pnlBody.Enabled = True
                    txtProdQty.Text = BLL.GetDJMatchedQty(txtPONo.Text, txtPCBANo.Text, DJOrgCode)
                    'ready for input for next product
                    txtIntSerial.Clear()
                    txtIntSerial.Focus()
                    Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
                    Exit Sub
            End Select
        End If

        RaveResult()

    End Sub

    'Private Sub txtExtSerial_ValidateData() Handles txtExtSerial.ValidateData
    '    txtExtSerial.Text = Trim(txtExtSerial.Text)
    '    If txtExtSerial.Text.Length < SFC009 Then
    '        Me.ShowMessage("^TDC-23@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
    '        Exit Sub
    '    End If
    '    If Trim(txtExtSerial.Text) <> "" And txtExtSerial.Modified Then
    '        Dim SNValid As String
    '        SNValid = BLL.IntSNIsValid(txtExtSerial.Text)
    '        If SNValid <> "0" Then
    '            Me.ShowMessage("^TDC-19@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
    '            txtExtSerial.SelectAll()
    '            txtExtSerial.Focus()
    '        Else
    '            pnlBody.Enabled = False
    '            RaveResult()
    '        End If
    '    End If
    'End Sub

    'Private Sub bgwExtSerial_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwExtSerial.DoWork
    '    Try
    '        e.Result = BLL.IntSNIsValid(txtExtSerial.Text)     'Validate if ID is already in use
    '    Catch ex As Exception
    '        BLL.ErrorLogging("TDC-IDSwop-txtExtSerial.ValidateData", "", ex.Message)
    '    End Try
    'End Sub

    'Private Sub bgwExtSerial_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwExtSerial.RunWorkerCompleted
    '    pnlBody.Enabled = True
    '    If e.Result <> "0" Then
    '        Me.ShowMessage("^TDC-19@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
    '        txtExtSerial.SelectAll()
    '        txtExtSerial.Focus()
    '    Else
    '        Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
    '        bgwPost.RunWorkerAsync()
    '    End If
    'End Sub

    Sub RaveResult()
        dsWIP.Tables("SwopModel").Clear()
        Dim drSwopSN As DataRow
        drSwopSN = dsWIP.Tables("SwopModel").NewRow
        drSwopSN("Model") = txtModelNo.Text
        If ForceSwop Then
            drSwopSN("isForce") = "Y"
        Else
            drSwopSN("isForce") = "N"
        End If
        dsWIP.Tables("SwopModel").Rows.Add(drSwopSN)
        dsWIP.Tables("SwopModel").AcceptChanges()
        Me.ShowMessage("^TDC-59@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
        bgwPost.RunWorkerAsync()
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        'RaveResult()
    End Sub


    Private Sub bgwPost_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwPost.DoWork
        'With BLL.StatusHeader
        '    .IntSerial = txtIntSerial.Text
        '    .ExtSerial = txtExtSerial.Text
        '    .Process = CurrProcess
        '    .OperatorName = User
        'End With
        'e.Result = BLL.IDSwop(BLL.StatusHeader, chkAddlData.Checked)
        e.Result = BLL.WIPModelSwop(dsWIP)
    End Sub

    Private Sub bgwPost_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPost.RunWorkerCompleted
        If e.Result = "^TDC-60@" Then
            Me.ShowMessage("^TDC-60@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
            pnlBody.Enabled = True
            ClearDataInput()
            txtIntSerial.Focus()
        Else
            Me.ShowMessage("^TDC-61@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            pnlBody.Enabled = True
            grpDataInput.Enabled = True
            btnPost.Enabled = True
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        ClearDataInput()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        txtPONo.Text = ""
        txtModelNo.Text = ""
        txtPCBANo.Text = ""
        grpModel.Enabled = True
        txtPONo.Enabled = True
        If Not dtFlow Is Nothing Then
            dtFlow.Clear()
        End If
        ClearDataInput()
        chkAddlData.Checked = False
    End Sub


    Private Sub ClearDataInput()
        Me.DisableValidation = True
        grpDataInput.Enabled = True
        btnPost.Enabled = True
        txtExtSerial.Text = ""
        txtIntSerial.Text = ""
        If txtPONo.Text = "" Then
            chkAddlData.Enabled = True
        Else
            txtIntSerial.Focus()
        End If
        DisableValidation = False

        If Not dtResultList Is Nothing Then
            dtResultList.Clear()
        End If
        'dgvResult.DataSource = Nothing
        btnEMI.Visible = False

    End Sub

    Private Sub frmModelSwop_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Try
            SerialPort1.Open()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmModelSwop_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
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
        If txtIntSerial.Focused Then
            txtIntSerial.Text = ReceivedText
            txtIntSerial.Modified = True
            My.Computer.Keyboard.SendKeys("{TAB}")
        ElseIf txtExtSerial.Focused Then
            txtExtSerial.Text = ReceivedText
            txtExtSerial.Modified = True
            My.Computer.Keyboard.SendKeys("{TAB}")
        End If
        flgBusy = False
    End Sub

    Private Sub btnEMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEMI.Click
        Dim path As String
        Dim MIForm As New frmMI()
        path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\eTrace\EMI\"
        Globals.MIFileName = "EMI_" + txtModelNo.Text.Trim + "_" + txtPCBANo.Text.Trim + "_" + CurrProcess
        Dim t() As Byte = CType(Emifile, Byte())
        Dim PDF As IO.FileStream
        If IO.File.Exists(path + MIFileName + ".pdf") Then
            IO.File.Delete(path + MIFileName + ".pdf")
        End If
        If (Not IO.Directory.Exists(path)) Then
            IO.Directory.CreateDirectory(path)
        End If
        PDF = IO.File.Create(path + MIFileName + ".pdf")
        PDF.Write(t, 0, t.GetUpperBound(0))
        PDF.Close()
        MIForm.ShowFrm(Me)
    End Sub

    'Create WIP Dataset
    Private Function dsVI() As DataSet
        Dim DS As DataSet = New DataSet("WIP")

        Dim WIPHeader As DataTable = New Data.DataTable("WIPHeader")
        WIPHeader.Columns.Add(New Data.DataColumn("WIPID", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("IntSN", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("Model", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("PCBA", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("DJ", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("OldDJ", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("InvOrg", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("ProdLine", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("CurrentProcess", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("FlowSeqNo", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("Result", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("AllPassed", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("ReuseChildISN", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("MotherBoardSN", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("ChangedBy", System.Type.GetType("System.String")))
        DS.Tables.Add(WIPHeader)

        Dim SwopSN As DataTable = New Data.DataTable("SwopModel")
        SwopSN.Columns.Add(New Data.DataColumn("Model", System.Type.GetType("System.String")))
        SwopSN.Columns.Add(New Data.DataColumn("isForce", System.Type.GetType("System.String")))
        DS.Tables.Add(SwopSN)

        Return DS
    End Function

    Private Sub txtPONo_ValidateData() Handles txtPONo.ValidateData
        txtPONo.Text = Trim(txtPONo.Text)
        If txtPONo.Text = "" Then
            Exit Sub
        End If
        'If SFC019.Contains(Mid(txtPONo.Text, 1, 1).ToUpper) Then
        '    Me.ShowMessage("^TDC-29@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        '    txtPONo.SelectAll()
        '    txtPONo.Focus()
        '    Exit Sub
        'End If

        Dim ds As DataSet
        ds = BLL.DJValidation(txtPONo.Text, "3", BLL.LoginData)
        Try
            'If chkAddlData.Checked Then
            '    If ds.Tables("DJInfo").Rows(0)("DJType").ToString.Trim.ToUpper <> "NON-STANDARD" Then
            '        Me.ShowMessage("^SFC-125@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            '        txtPONo.SelectAll()
            '        txtPONo.Focus()
            '        Return
            '    End If
            'End If

            If ds.Tables("ErrorMsg").Rows.Count > 0 Then
                Me.ShowMessage("^TDC-29@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtPONo.SelectAll()
                txtPONo.Focus()
                Return
            Else

                Dim CompIssueToDJ As String
                CompIssueToDJ = BLL.CheckCompIssueToDJ(txtPONo.Text)
                If CompIssueToDJ <> "0" Then
                    Me.ShowMessage(CompIssueToDJ, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtPONo.SelectAll()
                    txtPONo.Focus()
                    Exit Sub
                End If

                ModelRev = ds.Tables("DJInfo").Rows(0)("DJ_REVISION").ToString
                POQty = ds.Tables("DJInfo").Rows(0)("ORDER_QUANTITY")
                txtModelNo.Text = ds.Tables("DJInfo").Rows(0)("PRODUCT_NUMBER")
                DJOrgCode = ds.Tables("DJInfo").Rows(0)("OrgCode")
                Dim dsCPN As DataSet
                dsCPN = BLL.GetProductCPNbyModel(txtModelNo.Text)
                If dsCPN.Tables(0).Rows.Count = 0 Then
                    Me.ShowMessage("^TDC-1@ ^TDC-5@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtPONo.SelectAll()
                    txtPONo.Focus()
                    Exit Sub
                End If
                ExtSNSameIntSN = dsCPN.Tables(0).Rows(0)("ExtSNSameIntSN")
                TraceLevel = BLL.getTraceLevel(txtModelNo.Text)
                dtFlow = BLL.TLAFlow(txtModelNo.Text).Tables(0)
                If dtFlow.Rows.Count = 0 Then     'revision or PCBA upgrape result to it can't found the flow file.
                    Me.ShowMessage("^TDC-147@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtPONo.SelectAll()
                    txtPONo.Focus()
                    Exit Sub
                End If
                txtPCBANo.Text = dtFlow.Rows(0)("PCBA").ToString
                'If chkAddlData.Checked Then
                PanelSize = BLL.getPanelSize(txtModelNo.Text, txtPCBANo.Text)
                BLL.CountPoQty(DJOrgCode, txtPONo.Text, txtModelNo.Text, txtPCBANo.Text, POQty, ModelRev)
                dgvFlow.DataSource = dtFlow
                Emifile = BLL.getMIFileData(txtModelNo.Text.Trim, txtModelNo.Text.Trim, CurrProcess)
                If (Not Emifile Is Nothing) Then
                    btnEMI.Visible = True
                End If
                grpModel.Enabled = False
                chkAddlData.Enabled = False
                txtIntSerial.Focus()
            End If
        Catch ex As Exception
            Me.ShowMessage("^TDC-29@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtPONo.SelectAll()
            txtPONo.Focus()
            Return
        End Try

    End Sub
End Class
