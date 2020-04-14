Public Class frmVisualInspection
    Public ProcessID As Integer
    Public CurrProcess As String
    Public user As String
    Dim record As DataTable
    Dim dsWIP As DataSet
    Dim dtResultList As DataTable
    Dim AllPass As Boolean
    Dim SFC004 As String
    Dim SFC005 As String
    Dim SFC009 As Integer
    Dim Model As String
    Dim PCBA As String
    Private flgBusy As Boolean = False
    Private Emifile As Object
    Private Delegate Sub UpdateUI(ByVal ReceivedData As String)
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
        SFC004 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC004'")(0)("Value"))
        SFC005 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC005'")(0)("Value"))
        SFC009 = Convert.ToInt32(FixNull(dsConfig.Tables(0).Select("ConfigID='SFC009'")(0)("Value")))
        If SFC004.ToUpper = "NO" Then
            txtIntSerial.KeyIn = False
        Else
            txtIntSerial.KeyIn = True
        End If
        If SFC005.ToUpper = "NO" Then
            txtResult.KeyIn = False
        Else
            txtResult.KeyIn = True
        End If
        Me.ShowMessage(ProcessShow, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
    End Sub

    Private Sub frmTemplate_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        ddlProcess.Text = ProcessShow
        Me.CenterToScreen()
        user = Mid(UserName.Text, 1, InStr(UserName.Text, "-") - 1).Trim
        BLL.LoginData.User = user
        BLL.LoginData.OrgCode = Mid(MyOrg(), 1, 3)
        BLL.LoginData.ProductionLine = ProductionLine()
        txtProcess.Text = "QC4"
        txtSC.Items.Add("")
        'Dim iRow As Integer
        Dim dsCode As DataSet
        dsCode = BLL.ReadRepairCode()
        txtDC.ItemDataTable = dsCode.Tables(0)
        txtDC.setItems("Status=1 and Category='" & "DEFECT'")
        'For iRow = 0 To dsCode.Tables("RepairCode").Rows.Count - 1
        '    If dsCode.Tables("RepairCode").Rows(iRow).Item("Status").ToString.Trim = "1" Then
        '        If dsCode.Tables("RepairCode").Rows(iRow).Item("Category").ToString.Trim.ToUpper = "DEFECT" Then
        '            txtDC.Items.Add(dsCode.Tables("RepairCode").Rows(iRow)("Code").ToString)
        '            txtProcess.Focus()
        '        End If
        '    End If
        'Next
    End Sub


    Private Sub txtIntSerial_ValidateData() Handles txtIntSerial.ValidateData
        txtIntSerial.Text = Trim(txtIntSerial.Text)
        If txtIntSerial.Text.Length < SFC009 Then
            Me.ShowMessage("^TDC-23@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
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
            BLL.ErrorLogging("SFCMatchingN-bgwIntSerial_DoWork", user, ex.Message)
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

        txtModelNo.Text = e.Result.Tables(1).rows(0)("Model").ToString
        txtPCBANo.Text = e.Result.Tables(1).rows(0)("PCBA").ToString
        txtPONo.Text = e.Result.Tables(1).rows(0)("DJ").ToString
        Model = txtModelNo.Text.Trim
        PCBA = txtPCBANo.Text.Trim

        If e.Result.Tables(1).rows(0)("CurrentProcess").ToString = "Repair" And e.Result.Tables(1).rows(0)("Result").ToString <> "Fixed" Then
            Me.ShowMessage("^SFC-66@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
            Return
        End If

        dtResultList = e.Result.Tables(2)
        dgvResult.DataSource = dtResultList
        Dim HasProc As Integer = 0
        HasProc = dtResultList.Select("Process='" & txtProcess.Text & "'").Length
        If HasProc = 0 Then
            If CurrProcess <> "VI" Then
                Me.ShowMessage("ERROR: " & txtProcess.Text & "^SFC-7@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtIntSerial.SelectAll()
                txtIntSerial.Focus()
                Return
            End If
        End If

        If CurrProcess = "QC4" And e.Result.Tables(1).Rows(0)("CurrentProcess") <> "QC4" And e.Result.Tables(1).Rows(0)("ChangedBy") = user And e.Result.Tables(1).Rows(0)("Result") <> "WIPIN" Then
            If e.Result.Tables(1).Rows(0)("CurrentProcess") <> "Repair" Then
                Me.ShowMessage("^SFC-87@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                pnlBody.Enabled = True
                txtIntSerial.SelectAll()
                txtIntSerial.Focus()
                Exit Sub
            End If
        End If

        Dim FlowSeqNo As Integer = 0

        Dim iRows As Integer

        iRows = dtResultList.Rows.Count
        Dim i As Integer
        Dim ErrFound As Boolean = False
        For i = 0 To iRows - 1
            If ErrFound = True Then
                Me.ShowMessage("^TDC-13@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtIntSerial.SelectAll()
                txtIntSerial.Focus()
                Return
            End If

            If dtResultList.Rows(i)(0).ToString.Trim.ToUpper = txtProcess.Text.ToUpper Then   'For current process, fill in "pass" here
                If dtResultList.Rows(i)(1) = "PASS" Or dtResultList.Rows(i)(1) = "SKIP" Then
                    Me.ShowMessage("^SFC-2@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtIntSerial.SelectAll()
                    txtIntSerial.Focus()
                    Return
                Else
                    If dtResultList.Rows(i)(1) = "FAIL" Then
                        Dim LargeMax As String
                        LargeMax = BLL.LargeThanMaxTest(txtIntSerial.Text, CurrProcess)
                        If LargeMax <> "PASS" Then
                            Me.ShowMessage(LargeMax, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                            txtIntSerial.SelectAll()
                            txtIntSerial.Focus()
                            Return
                        End If
                    End If
                    dtResultList.Rows(i)(1) = "WIPIN"
                    dgvResult.Rows(i).Cells(1).Style.ForeColor = Color.Green
                    dgvResult.Rows(i).Cells(2).Style.ForeColor = Color.Green
                    FlowSeqNo = dtResultList.Rows(i)(2)
                End If
                Exit For
            Else
                If dtResultList.Rows(i)(1) = "" Then
                    FlowSeqNo = Convert.ToInt32(dtResultList.Rows(i - 1)(2)) + 1
                    'Exit For
                End If

            End If

            If Microsoft.VisualBasic.Left(dtResultList.Rows(i)(1).ToString.ToUpper, 4) <> "PASS" Then
                dgvResult.Rows(i).Cells(1).Style.ForeColor = Color.Red
                If CurrProcess <> "VI" Or Microsoft.VisualBasic.Left(dtResultList.Rows(i)(1).ToString.ToUpper, 4) = "FAIL" Then
                    ErrFound = True
                End If
            End If
        Next

        If dtResultList.Rows(iRows - 1)("Process").ToString.Trim.ToUpper = txtProcess.Text.ToUpper Then
            AllPass = True
            FlowSeqNo = Convert.ToInt32(dtResultList.Rows(iRows - 1)(2)) + 1
        Else
            AllPass = False
        End If



        dsWIP = dsVI()
        Dim dr As DataRow
        dr = dsWIP.Tables("WIPHeader").NewRow()
        dr("WIPID") = e.Result.Tables(1).rows(0)("WIPID").ToString
        dr("IntSN") = txtIntSerial.Text
        dr("Model") = txtModelNo.Text
        dr("PCBA") = txtPCBANo.Text
        dr("DJ") = txtPONo.Text
        dr("InvOrg") = BLL.LoginData.OrgCode
        dr("ProdLine") = BLL.LoginData.ProductionLine
        dr("CurrentProcess") = txtProcess.Text
        If CurrProcess = "VI" Then
            dr("Result") = "FAIL"
            AllPass = False
        Else
            dr("Result") = "PASS"
        End If
        dr("AllPassed") = AllPass
        dr("FlowSeqNo") = FlowSeqNo
        dr("ChangedBy") = user
        dsWIP.Tables("WIPHeader").Rows.Add(dr)
        If CurrProcess = "VI" Then
            Me.ShowMessage("^TDC-59@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StartAnim, False)
            pnlBody.Enabled = False
            doPost()
        Else
            txtResult.Focus()
            Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        End If
    End Sub


    Private Sub cleardataInput()
        Me.DisableValidation = True
        pnlBody.Enabled = True
        grpDataInput.Enabled = True
        btnPost.Enabled = True
        txtIntSerial.Text = ""
        Me.txtResult.Text = ""
        DisableValidation = False
        txtPONo.Text = ""
        txtModelNo.Text = ""
        txtPCBANo.Text = ""
        If CurrProcess = "VI" Then
            txtResult.Text = "FAIL"
        Else
            txtResult.Text = ""
        End If
        txtPOPCBA.Text = ""
        If Not dsWIP Is Nothing Then
            dsWIP.Clear()
        End If
        record = New DataTable
        If Not dtResultList Is Nothing Then
            dtResultList.Clear()
            dgvResult.DataSource = dtResultList
        End If
        dtResultList = New DataTable
        btnEMI.Visible = False
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        If txtResult.Text = "" Then
            Exit Sub
        End If
        Me.ShowMessage("^TDC-59@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StartAnim, False)
        pnlBody.Enabled = False
        doPost()
    End Sub


    Private Sub frmChangePallet_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Try
            SerialPort1.Open()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmChangePallet_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
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
        ElseIf txtResult.Focused Then
            txtResult.Text = ReceivedText
            txtResult.Modified = True
            My.Computer.Keyboard.SendKeys("{TAB}")
        End If
        flgBusy = False
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        cleardataInput()
        txtProcess.Enabled = True
        txtProcess.Focus()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        cleardataInput()
        txtIntSerial.Focus()
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

    Private Sub txtResult_ValidateData() Handles txtResult.ValidateData
        txtResult.Text = Trim(txtResult.Text)
        If Trim(txtIntSerial.Text) = "" Then
            txtResult.Text = ""
            txtIntSerial.Focus()
            Exit Sub
        End If
        If txtResult.Text.ToUpper = "PASS" Or txtResult.Text.ToUpper = "FAIL" Or txtResult.Text.ToUpper = "SKIP" Then
            If txtResult.Text.ToUpper = "FAIL" Then
                txtDC.Visible = True
                txtDC.Focus()
                Exit Sub
            End If
            Me.ShowMessage("^TDC-59@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
            pnlBody.Enabled = False
            doPost()
        Else
            If txtResult.Text <> "" And txtResult.Modified Then
                Me.ShowMessage("^TDC-24@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
                pnlBody.Enabled = False
                Me.bgwResult.RunWorkerAsync()
            End If
        End If

    End Sub

    Private Sub bgwResult_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwResult.DoWork
        Try
            e.Result = BLL.GetResult(txtResult.Text, CurrProcess, "")
        Catch ex As Exception
            BLL.ErrorLogging("SFC-txtResult_ValidateData", "", ex.Message)
        End Try
    End Sub

    Private Sub bgwResult_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwResult.RunWorkerCompleted
        pnlBody.Enabled = True
        If e.Result.ToString.ToUpper <> "PASS" AndAlso e.Result.ToString.ToUpper <> "FAIL" AndAlso e.Result.ToString.ToUpper <> "SKIP" Then
            Me.ShowMessage("^SFC-179@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtResult.SelectAll()
            txtResult.Focus()
        Else
            txtResult.Text = e.Result.ToString.ToUpper()
            If txtResult.Text.ToUpper = "FAIL" Then
                txtDC.Visible = True
                txtDC.Focus()
                Exit Sub
            End If
            Me.ShowMessage("^TDC-59@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StartAnim, False)
            pnlBody.Enabled = False
            doPost()
        End If
    End Sub

    Private Sub doPost()
        If txtResult.Text.ToUpper = "FAIL" And txtDC.Text.Trim = "" Then
            'show a warning
        End If
        Dim dr As DataRow
        dr = dsWIP.Tables("WIPTDHeader").NewRow()
        dr("TesterNo") = Trim(txtTesterNo.Text)
        dr("ProgramName") = Trim(txtProgName.Text)
        dr("ProgramRev") = Trim(txtProgRev.Text)
        dr("IPSNo") = Trim(txtIPSNo.Text)
        dr("IPSRev") = Trim(txtIPSRev.Text)
        dr("Remarks") = Trim(txtRemarks.Text)
        dr("DefectCode") = Trim(txtDC.Text)
        dr("SymptomCode") = Trim(txtSC.Text)
        dsWIP.Tables("WIPTDHeader").Rows.Add(dr)
        dsWIP.Tables("WIPHeader").Rows(0)("Result") = txtResult.Text
        dsWIP.AcceptChanges()
        bgwPost.RunWorkerAsync()
    End Sub


    Private Sub bgwPost_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwPost.DoWork
        e.Result = BLL.WIPVisualInspection(dsWIP)
    End Sub

    Private Sub bgwPost_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPost.RunWorkerCompleted
        If e.Result = "^TDC-60@" Then
            Me.ShowMessage("^TDC-60@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
            cleardataInput()
            txtIntSerial.Focus()
        Else
            Me.ShowMessage("^TDC-61@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            pnlBody.Enabled = True
            grpDataInput.Enabled = True
            btnPost.Enabled = True
            txtResult.SelectAll()
            txtResult.Focus()
        End If

    End Sub


    Private Sub txtProcess_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProcess.SelectedValueChanged
        CurrProcess = txtProcess.Text
    End Sub

    Private Sub txtProcess_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProcess.Validated
        CurrProcess = txtProcess.Text
        txtProcess.Enabled = False
        If CurrProcess = "VI" Then
            txtResult.Text = "FAIL"
            txtResult.Enabled = False
        Else
            txtResult.Enabled = True
        End If
    End Sub

    Public Function FixNull(ByVal vMayBeNull As Object) As String
        On Error Resume Next
        FixNull = vbNullString & vMayBeNull
    End Function

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
        WIPHeader.Columns.Add(New Data.DataColumn("ChangedBy", System.Type.GetType("System.String")))
        DS.Tables.Add(WIPHeader)

        Dim WIPTDHeader As DataTable = New Data.DataTable("WIPTDHeader")
        WIPTDHeader.Columns.Add(New Data.DataColumn("TesterNo", System.Type.GetType("System.String")))
        WIPTDHeader.Columns.Add(New Data.DataColumn("ProgramName", System.Type.GetType("System.String")))
        WIPTDHeader.Columns.Add(New Data.DataColumn("ProgramRev", System.Type.GetType("System.String")))
        WIPTDHeader.Columns.Add(New Data.DataColumn("IPSNo", System.Type.GetType("System.String")))
        WIPTDHeader.Columns.Add(New Data.DataColumn("IPSRev", System.Type.GetType("System.String")))
        WIPTDHeader.Columns.Add(New Data.DataColumn("Remarks", System.Type.GetType("System.String")))
        WIPTDHeader.Columns.Add(New Data.DataColumn("DefectCode", System.Type.GetType("System.String")))
        WIPTDHeader.Columns.Add(New Data.DataColumn("SymptomCode", System.Type.GetType("System.String")))
        DS.Tables.Add(WIPTDHeader)

        Return DS
    End Function

    Private Sub txtDC_Validated(sender As Object, e As EventArgs) Handles txtDC.Validated
        If txtDC.Items.Count = 0 Then Exit Sub
        If txtDC.Text <> "" Then
            Dim compcc() As String
            compcc = txtDC.Text.Split("|")
            txtDC.Text = Trim(compcc(0))
        End If
    End Sub

End Class
