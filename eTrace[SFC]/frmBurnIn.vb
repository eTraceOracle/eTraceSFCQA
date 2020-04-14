Public Class frmBurnIn
    Public ProcessID As Integer
    Public CurrProcess As String
    Dim record As DataTable
    Dim User As String
    Dim dtResultList As DataTable
    Dim currentProcessRowIndex As Integer
    Dim AllPass As Boolean
    Dim dsWIP As DataSet
    Dim WIPID As String
    Dim WIPIN As Date
    Dim Emifile As Object
    Private flgBusy As Boolean = False
    Private Delegate Sub UpdateUI(ByVal ReceivedData As String)
    Dim SFC009 As Integer
    Dim SFC015 As String         'Auto Burn-in time calculation based on WIP In/Out, if PASS  
    ''' <summary>
    '''  Burn In - Allow WIP Out without WIP In(Yes/No)
    ''' </summary>
    Dim SFC016 As String
    Dim SFC023 As String         'Auto Burn-in time calculation based on WIP In/Out,  if FAIL (Yes/No)
    Dim SFC024 As String         '

    Public Overrides Sub NewSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'New Instance of the form
        Dim NewInstance As New frmMain()
        NewInstance.ShowFrm(Me)
    End Sub

    Private Sub frmTemplate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AttachHotkey(btnPost, Keys.F8)
        AttachHotkey(btnNew, Keys.F5)
        AttachHotkey(btnReset, Keys.F3)
        AttachHotkey(btnPrint, Keys.F9)
        ProcessID = SelectProcessID
        CurrProcess = SelectProcess
        BindCtlsToProcess(Me, ProcessID)
        'ShowWipIn()
        SFC009 = Convert.ToInt32(BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC009'")(0)("Value")))
        SFC016 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC016'")(0)("Value")).ToUpper
        SFC015 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC015'")(0)("Value")).ToUpper
        SFC023 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC023'")(0)("Value")).ToUpper
        SFC024 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC024'")(0)("Value")).ToUpper
        Me.ShowMessage(ProcessShow, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
    End Sub

    Private Sub frmTemplate_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        ddlProcess.Text = ProcessShow
        Me.CenterToScreen()
        User = Mid(UserName.Text, 1, InStr(UserName.Text, "-") - 1).Trim
        txtIntSerial.Focus()
        BLL.LoginData.User = User
        BLL.LoginData.OrgCode = Mid(MyOrg(), 1, 3)
        BLL.LoginData.ProductionLine = ProductionLine()
    End Sub

    Private Sub txtIntSerial_ValidateData() Handles txtIntSerial.ValidateData
        txtIntSerial.Text = Trim(txtIntSerial.Text)
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
            BLL.ErrorLogging("SFCBunr-bgwIntSerial_DoWork", User, ex.Message)
        End Try
    End Sub
    Dim FlowSeqNo As Integer = 0
    Private Sub bgwIntSerial_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwIntSerial.RunWorkerCompleted
        pnlBody.Enabled = True

        If e.Result.Tables(0).rows(0)("ErrMsg") <> "" Then
            Me.ShowMessage("ERROR: " & txtIntSerial.Text & " ^TDC-5@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
            Return
        End If
        WIPID = e.Result.Tables(1).rows(0)("WIPID").ToString
        AllPass = False

        txtModelNo.Text = e.Result.Tables(1).rows(0)("Model").ToString
        txtPCBANo.Text = e.Result.Tables(1).rows(0)("PCBA").ToString
        txtPONo.Text = e.Result.Tables(1).rows(0)("DJ").ToString
        WIPIN = e.Result.Tables(1).rows(0)("ChangedOn")
        dtResultList = e.Result.Tables(2)

        dgvResult.DataSource = dtResultList
        Dim HasProc As Integer = 0
        HasProc = dtResultList.Select("Process='" & CurrProcess & "'").Length
        ' not define in flow.
        If HasProc = 0 Then
            Me.ShowMessage("ERROR: " & CurrProcess & " " & "^SFC-7@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
            Return
        End If
        'the unit is on repair station. 
        If e.Result.Tables(1).Rows(0)("CurrentProcess").ToString = "Repair" And e.Result.Tables(1).Rows(0)("Result").ToString <> "Fixed" Then
            Me.ShowMessage("^SFC-66@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
            Return
        End If
        'Current Process already complete.
        If e.Result.Tables(1).Rows(0)("CurrentProcess").ToString.ToUpper = CurrProcess.ToUpper And (e.Result.Tables(1).Rows(0)("Result").ToString = "PASS" Or e.Result.Tables(1).Rows(0)("Result").ToString = "SKIP") Then
            Me.ShowMessage("^SFC-2@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
            Return
        End If

        Dim ErrFound As Boolean = False
        For i As Integer = 0 To dtResultList.Rows.Count - 1
            'Failed process found! 
            If ErrFound = True Then
                Me.ShowMessage("^TDC-13@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtIntSerial.SelectAll()
                txtIntSerial.Focus()
                Return
            End If
            'Current Process already complete.
            If dtResultList.Rows(i)(0).ToString.Trim.ToUpper = CurrProcess.ToUpper Then
                FlowSeqNo = dtResultList.Rows(i)(2)
                If dtResultList.Rows(i)(1) = "PASS" Or dtResultList.Rows(i)(1) = "SKIP" Then
                    Me.ShowMessage("^SFC-2@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtIntSerial.SelectAll()
                    txtIntSerial.Focus()
                    Return
                End If
                Exit For
            End If
            If Microsoft.VisualBasic.Left(dtResultList.Rows(i)(1).ToString.ToUpper, 4) <> "PASS" Then
                dgvResult.Rows(i).Cells(1).Style.ForeColor = Color.Red
                ErrFound = True
            End If
        Next

        If RadioBtnWIPIn.Checked Then
            WipInPosition(e.Result)
        ElseIf RadioBtnWIPOut.Checked Then
            WipOutPosition(e.Result)
        End If
        'saveresult()
    End Sub
    Private Sub WipInPosition(ByVal dsResult As DataSet)
        If SFC016 = "NO" Then 'because if sfc016="NO", the validation done when WIPIN

            Dim LargeMax As String
            LargeMax = BLL.LargeThanMaxTest(txtIntSerial.Text, CurrProcess)
            If LargeMax <> "PASS" Then
                Me.ShowMessage(LargeMax, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtIntSerial.SelectAll()
                txtIntSerial.Focus()
                Return
            End If


        Else
            SFC015 = "NO"
            SFC023 = "NO"
            If dsResult.Tables(1).Rows(0)("CurrentProcess").ToString <> CurrProcess Then
                WIPIN = Date.Now
            End If
        End If
        If dsResult.Tables(1).Rows(0)("CurrentProcess").ToString.ToUpper = CurrProcess.ToUpper AndAlso dsResult.Tables(1).Rows(0)("Result").ToString = "WIPIN" Then
            Me.ShowMessage("^SFC-127@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            'already wipin
            'Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            txtIntSerial.SelectAll()
            txtIntSerial.Text = ""
            txtIntSerial.Focus()
            Return
        End If
        Dim iRows As Integer
        iRows = dtResultList.Rows.Count
        Dim i As Integer
        For i = 0 To iRows - 1
            If dtResultList.Rows(i)(0).ToString.Trim.ToUpper = CurrProcess.ToUpper Then   'For current process, fill in "pass" here
                If i = 0 OrElse dtResultList.Rows(i - 1)(1) = "PASS" Or dtResultList.Rows(i)(1) = "SKIP" Then
                    saveResultWipIn(i)
                    Exit For
                End If
            End If

        Next

        Emifile = BLL.getMIFileData(txtModelNo.Text.Trim, txtPCBANo.Text.Trim, CurrProcess)
        If (Not Emifile Is Nothing) Then
            btnEMI.Visible = True
        End If

        Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
    End Sub
    Private Sub WipOutPosition(ByVal dsResult As DataSet)

        Dim iRows As Integer = dtResultList.Rows.Count
        'because if sfc016="NO", the validation done when WIPIN
        If SFC016 = "YES" Then
            Dim LargeMax As String
            LargeMax = BLL.LargeThanMaxTest(txtIntSerial.Text, CurrProcess)
            If LargeMax <> "PASS" Then
                Me.ShowMessage(LargeMax, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtIntSerial.SelectAll()
                txtIntSerial.Focus()
                Return
            End If
        Else
            If dsResult.Tables(1).Rows(0)("currentprocess") <> CurrProcess OrElse dsResult.Tables(1).Rows(0)("Result") <> "WIPIN" Then
                Me.ShowMessage("^SFC-31@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtIntSerial.SelectAll()
                txtIntSerial.Focus()
                Return
            ElseIf dsResult.Tables(1).Rows(0)("currentprocess") = CurrProcess AndAlso dsResult.Tables(1).Rows(0)("Result") = "WIPIN" Then
                For i As Integer = 0 To dtResultList.Rows.Count - 1
                    If dtResultList.Rows(i)(0).ToString.Trim.ToUpper = CurrProcess.ToUpper Then   'For current process, fill in "pass" here
                        dtResultList.Rows(i)(1) = "WIPIN"
                        dgvResult.Rows(i).Cells(1).Style.ForeColor = Color.Green
                        dgvResult.Rows(i).Cells(2).Style.ForeColor = Color.Green
                    End If

                Next
            End If
        End If

        If txtResultCode.Text.Trim = "" Then
            Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            Exit Sub
        End If

        Dim tsTemp As TimeSpan
        If txtResultCode.Text = "PASS" Then
            If SFC015 = "YES" Then
                txtBurnInTime.Enabled = False
                tsTemp = WIPIN.Subtract(DateTime.Now)
                If SFC024 = "H" Then
                    txtBurnInTime.Text = System.Math.Round(Val(Trim(tsTemp.Duration.TotalHours.ToString)), 1)
                Else
                    txtBurnInTime.Text = System.Math.Round(Val(Trim(tsTemp.Duration.TotalMinutes.ToString)), 0)
                End If
            Else
                txtBurnInTime.Enabled = True
            End If
        End If

        If txtResultCode.Text = "FAIL" Then
            If SFC023 = "YES" Then
                txtBurnInTime.Enabled = False
                tsTemp = WIPIN.Subtract(DateTime.Now)
                If SFC024 = "H" Then
                    txtBurnInTime.Text = System.Math.Round(Val(Trim(tsTemp.Duration.TotalHours.ToString)), 1)
                Else
                    txtBurnInTime.Text = System.Math.Round(Val(Trim(tsTemp.Duration.TotalMinutes.ToString)), 0)
                End If
            Else
                txtBurnInTime.Enabled = True
            End If
        End If
        If dtResultList.Rows(iRows - 1)("Process").ToString.Trim.ToUpper = CurrProcess.ToUpper Then
            AllPass = True
        Else
            AllPass = False
        End If
        Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        saveresult()
    End Sub
    Private Sub bgwWipIn_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwWipIn.DoWork
        Try
            e.Result = BLL.WIPIn(txtIntSerial.Text, CurrProcess, Me.User)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bgwWipIn_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwWipIn.RunWorkerCompleted
        pnlBody.Enabled = True
        If e.Result = "True" Then
            Try

                dtResultList.Rows(currentProcessRowIndex)(1) = "WIPIN"
                dgvResult.Rows(currentProcessRowIndex).Cells(1).Style.ForeColor = Color.Green
                dgvResult.Rows(currentProcessRowIndex).Cells(2).Style.ForeColor = Color.Green
                ClearDataInput()
                Me.ShowMessage("^SFC-126@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            Catch ex As Exception
                Me.ShowMessage("ERR:" + ex.Message, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            End Try

        Else
            Me.ShowMessage(e.Result.ToString, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        End If
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        ClearDataInput()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ClearDataInput()
    End Sub

    Private Sub ClearDataInput()
        Me.DisableValidation = True
        grpDataInput.Enabled = True
        btnPost.Enabled = True
        txtIntSerial.Text = ""
        txtIntSerial.Focus()
        If dtResultList IsNot Nothing Then
            dtResultList.Clear()
        End If
        'dgvResult.DataSource = Nothing
        DisableValidation = False
        btnEMI.Visible = False
        txtPONo.Text = ""
        txtModelNo.Text = ""
        txtPCBANo.Text = ""
        If (Not chkAddlData.Checked) Then
            txtPCBASerial.Text = ""
            txtResultCode.Text = ""
            txtInputVoltage.Text = ""
            If SFC015 = "YES" Then
                txtBurnInTime.Text = ""
            End If
            chkAddlData.Checked = False
        End If
    End Sub

    Private Sub saveResultWipIn(index As Integer)
        'currentRowIndex = index
        bgwWipIn.RunWorkerAsync()
    End Sub

    Private Sub saveresult()
        If txtIntSerial.Highlight = True Then Exit Sub
        If txtPCBASerial.Highlight = True Then Exit Sub
        If txtInputVoltage.Highlight = True Then Exit Sub
        If txtResultCode.Highlight = True Then Exit Sub
        If txtBurnInTime.Highlight = True Then Exit Sub
        If txtResultCode.Text.ToUpper = "FAIL" Then
            If Me.ShowMessage("^SFC-65@", eTraceUI.eTraceMessageBar.MessageTypes.Warning, AnimationStatus.StopAnim, True, PopUpTypes.Question) = False Then
                Exit Sub
            End If
        End If
        If txtBurnInTime.Text.Trim = "" Then
            Me.ShowMessage("^SFC-94@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtBurnInTime.Focus()
            Exit Sub
        End If

        dsWIP = dsVI()
        Dim dr As DataRow
        dr = dsWIP.Tables("WIPHeader").NewRow()
        dr("WIPID") = WIPID
        dr("IntSN") = txtIntSerial.Text
        dr("Model") = txtModelNo.Text
        dr("PCBA") = txtPCBANo.Text
        dr("DJ") = txtPONo.Text
        dr("InvOrg") = BLL.LoginData.OrgCode
        dr("ProdLine") = BLL.LoginData.ProductionLine
        dr("CurrentProcess") = CurrProcess
        dr("FlowSeqNo") = FlowSeqNo
        dr("Result") = txtResultCode.Text
        dr("AllPassed") = AllPass
        dr("WIPIN") = WIPIN
        dr("ChangedBy") = User
        dsWIP.Tables("WIPHeader").Rows.Add(dr)

        Dim drTD As DataRow
        drTD = dsWIP.Tables("WIPTDHeader").NewRow()
        drTD("TesterNo") = Trim(txtPCBASerial.Text)
        drTD("ProgramName") = Trim(txtInputVoltage.Text) 'Input Voltage
        If SFC024 = "H" Then
            drTD("IPSNo") = "Hrs"
        Else
            drTD("IPSNo") = "Mintues"
        End If

        drTD("ProgramRev") = Trim(txtBurnInTime.Text)  'BurnIn Time
        dsWIP.Tables("WIPTDHeader").Rows.Add(drTD)
        'dsWIP.Tables("WIPHeader").Rows(0)("Result") = txtResultCode.Text
        dsWIP.AcceptChanges()
        Me.ShowMessage("^TDC-59@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
        bgwPost.RunWorkerAsync()
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        saveresult()
    End Sub

    Private Sub bgwPost_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwPost.DoWork
        e.Result = BLL.WIPBurnIn(dsWIP)
    End Sub


    Private Sub bgwPost_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPost.RunWorkerCompleted
        If e.Result = "^TDC-60@" Then
            Me.ShowMessage("^TDC-60@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
            ClearDataInput()
        Else
            Me.ShowMessage("^TDC-61@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            grpDataInput.Enabled = True
            btnPost.Enabled = True
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
            txtPCBASerial.Text = ""
            txtResultCode.Text = ""
            txtInputVoltage.Text = ""
            txtBurnInTime.Text = ""
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
        If txtIntSerial.Focused Then
            txtIntSerial.Text = ReceivedText
            txtIntSerial.Modified = True
            My.Computer.Keyboard.SendKeys("{TAB}")
        ElseIf txtPCBASerial.Focused Then
            txtPCBASerial.Text = ReceivedText
            txtPCBASerial.Modified = True
            My.Computer.Keyboard.SendKeys("{TAB}")
        ElseIf txtResultCode.Focused Then
            txtResultCode.Text = ReceivedText
            My.Computer.Keyboard.SendKeys("{TAB}")
        ElseIf txtBurnInTime.Focused Then
            txtBurnInTime.Text = ReceivedText
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

    Private Sub txtResultCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtResultCode.SelectedIndexChanged
        Dim tsTemp As TimeSpan
        If SFC016 = "YES" Then
            SFC015 = "NO"
            SFC023 = "NO"
        End If
        If txtResultCode.Text = "PASS" Then
            If SFC015 = "YES" Then
                txtBurnInTime.Enabled = False
                If txtIntSerial.Text.Trim = "" Then
                    Exit Sub
                End If
                tsTemp = WIPIN.Subtract(DateTime.Now)
                If SFC024 = "H" Then
                    txtBurnInTime.Text = System.Math.Round(Val(Trim(tsTemp.Duration.TotalHours.ToString)), 1)
                Else
                    txtBurnInTime.Text = System.Math.Round(Val(Trim(tsTemp.Duration.TotalMinutes.ToString)), 0)
                End If
            Else
                txtBurnInTime.Enabled = True
            End If
        End If

        If txtResultCode.Text = "FAIL" Then
            If SFC023 = "YES" Then
                txtBurnInTime.Enabled = False
                If txtIntSerial.Text.Trim = "" Then
                    Exit Sub
                End If
                tsTemp = WIPIN.Subtract(DateTime.Now)
                If SFC024 = "H" Then
                    txtBurnInTime.Text = System.Math.Round(Val(Trim(tsTemp.Duration.TotalHours.ToString)), 1)
                Else
                    txtBurnInTime.Text = System.Math.Round(Val(Trim(tsTemp.Duration.TotalMinutes.ToString)), 0)
                End If
            Else
                txtBurnInTime.Enabled = True
            End If
        End If
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
        WIPHeader.Columns.Add(New Data.DataColumn("InvOrg", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("ProdLine", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("CurrentProcess", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("FlowSeqNo", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("Result", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("AllPassed", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("ReuseChildISN", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("MotherBoardSN", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("WIPIN", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("ChangedBy", System.Type.GetType("System.String")))
        DS.Tables.Add(WIPHeader)

        Dim WIPTDHeader As DataTable = New Data.DataTable("WIPTDHeader")
        WIPTDHeader.Columns.Add(New Data.DataColumn("TesterNo", System.Type.GetType("System.String")))
        WIPTDHeader.Columns.Add(New Data.DataColumn("ProgramName", System.Type.GetType("System.String")))
        WIPTDHeader.Columns.Add(New Data.DataColumn("ProgramRev", System.Type.GetType("System.String")))
        WIPTDHeader.Columns.Add(New Data.DataColumn("IPSNo", System.Type.GetType("System.String")))
        WIPTDHeader.Columns.Add(New Data.DataColumn("IPSRev", System.Type.GetType("System.String")))
        WIPTDHeader.Columns.Add(New Data.DataColumn("Remarks", System.Type.GetType("System.String")))
        DS.Tables.Add(WIPTDHeader)

        Return DS
    End Function


    Private Sub RadioBtnWIPIn_Click(sender As Object, e As EventArgs) Handles RadioBtnWIPIn.Click, RadioBtnWIPOut.Click
        Dim radioButton As eTraceUI.eTraceRadioButton
        radioButton = CType(sender, eTraceUI.eTraceRadioButton)
        If radioButton IsNot Nothing Then
            If radioButton.Name = "RadioBtnWIPIn" Then
                ShowWipIn()
            ElseIf radioButton.Tag = "RadioBtnWIPOut" Then
                ShowWipOut()
            End If
            ClearDataInput()
        End If

    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub ShowWipIn()
        chkAddlData.Checked = False
        chkAddlData.Enabled = False
        'For i As Integer = 1 To ETraceTableLayoutPanel1.RowCount - 1
        '    ETraceTableLayoutPanel1.RowStyles.Item(i).SizeType = SizeType.Absolute
        '    ETraceTableLayoutPanel1.RowStyles.Item(i).Height = 0
        'Next
        lblPCBASerial.Visible = False
        txtPCBASerial.Visible = False
        lblInputVoltage.Visible = False
        txtInputVoltage.Visible = False

        lblResultCode.Visible = False
        txtResultCode.Visible = False
        lblBurnInTime.Visible = False
        txtBurnInTime.Visible = False

    End Sub
    Private Sub ShowWipOut()
        chkAddlData.Enabled = True
        'For i As Integer = 1 To ETraceTableLayoutPanel1.RowCount - 1
        '    ETraceTableLayoutPanel1.RowStyles.Item(i).SizeType = SizeType.AutoSize
        'Next
        lblPCBASerial.Visible = True
        txtPCBASerial.Visible = True
        lblInputVoltage.Visible = True
        txtInputVoltage.Visible = True

        lblResultCode.Visible = True
        txtResultCode.Visible = True
        lblBurnInTime.Visible = True
        txtBurnInTime.Visible = True
    End Sub
End Class
