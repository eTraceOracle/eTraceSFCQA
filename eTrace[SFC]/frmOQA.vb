Public Class frmOQA
    Public ProcessID As Integer
    Public CurrProcess As String
    Public ResultCode As String
    Private PCBA As String
    Private mydataset As DataSet = New DataSet
    Private dtFlow As DataTable = New DataTable
    Private dsFlow As DataSet = New DataSet
    Private flgBusy As Boolean = False
    Private Emifile As Object
    Private Delegate Sub UpdateUI(ByVal ReceivedData As String)
    Dim SFC004 As String
    Dim SFC005 As String
    Dim SFC006 As String

    Public Overrides Sub NewSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'New Instance of the form
        Dim NewInstance As New frmMain()
        NewInstance.ShowFrm(Me)
    End Sub

    Private Sub frmOQA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AttachHotkey(btnPost, Keys.F8)
        AttachHotkey(btnNew, Keys.F5)
        AttachHotkey(btnReset, Keys.F3)
        AttachHotkey(btnPrint, Keys.F9)
        ProcessID = SelectProcessID
        CurrProcess = SelectProcess
        BindCtlsToProcess(Me, ProcessID)
        SFC004 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC004'")(0)("Value"))
        SFC005 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC005'")(0)("Value"))
        SFC006 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC007'")(0)("Value"))
        If SFC004.ToUpper = "NO" Then
            txtRetestSN.KeyIn = False
        End If
        If SFC005.ToUpper = "NO" Then
            txtExtSerial.KeyIn = False
        End If
        If SFC006.ToUpper = "NO" Then
            chkAddlData.Visible = False
        End If
        Me.ShowMessage(ProcessShow, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
    End Sub

    Private Sub frmOQA_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        ddlProcess.Text = ProcessShow
        Me.CenterToScreen()
        BLL.LoginData.User = Mid(UserName.Text, 1, InStr(UserName.Text, "-") - 1).Trim
        BLL.LoginData.OrgCode = MyOrg()
        BLL.LoginData.ProductionLine = ProductionLine()
        txtModelNo.Focus()
    End Sub

    Private Sub txtExtSerial_ValidateData() Handles txtExtSerial.ValidateData
        txtExtSerial.Text = Trim(txtExtSerial.Text)
        If BLL.GetShipInfoBySN(txtExtSerial.Text).Model = "" Then
            Me.ShowMessage("^TDC-23@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtExtSerial.SelectAll()
            txtExtSerial.Focus()
            Exit Sub
        End If
        If txtModelNo.Text <> BLL.GetShipInfoBySN(txtExtSerial.Text).Model Then
            If Me.ShowMessage("^SFC-33@", eTraceUI.eTraceMessageBar.MessageTypes.Warning, AnimationStatus.StopAnim, True, PopUpTypes.Question) = False Then
                txtExtSerial.SelectAll()
                txtExtSerial.Focus()
            End If
        End If
    End Sub

    Private Sub txtResultCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtResultCode.Validated
        ResultCode = txtResultCode.Text.ToUpper
        Try
            PCBA = BLL.ExistsFunctionalTest(txtExtSerial.Text) ' Check if functional test exists or not
            If Not ResultCode = "RETEST" Then
                If PCBA = "^TDC-40@" Then
                    Me.ShowMessage("^TDC-40@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtResultCode.SelectAll()
                    txtResultCode.Focus()
                    Exit Sub
                End If
                If PCBA = "^SFC-32@" Then       'functional test fail
                    If ResultCode = "PASS" Then
                        Me.ShowMessage("^SFC-32@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                        txtResultCode.SelectAll()
                        txtResultCode.Focus()
                        Exit Sub
                    End If
                End If
            Else
                If PCBA <> "^TDC-40@" AndAlso PCBA <> "^SFC-32@" Then  'Exists functional test data, not allow retest.
                    Me.ShowMessage("^SFC-34@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtResultCode.SelectAll()
                    txtResultCode.Focus()
                    Exit Sub
                End If
            End If
            If ResultCode = "PASS" Then
                txtRetestSN.Visible = False
                txtRetestSN.Required = False
                txtRetestSN.ReadOnly = True
                If dgvResult.Visible Then
                    While dgvResult.RowCount > 0
                        dgvResult.Rows.RemoveAt(0)
                    End While
                    dgvResult.Visible = False
                End If
            Else
                If Not dtFlow.Columns.Contains("Rework") Then
                    dtFlow.Columns.Add("Rework")
                End If
                dgvResult.DataSource = dtFlow
                dgvResult.Columns("Model").Visible = False
                dgvResult.Columns("PCBA").Visible = False
                dgvResult.Columns("SeqNo").Visible = False
                dgvResult.Columns("RetestFlag").Visible = False
                Dim i As Integer
                For i = 0 To dtFlow.Rows.Count - 1
                    'If InStr(dtFlow.Rows(i)("Process").ToString.ToUpper, "MATCHING") _
                    'Or InStr(dtFlow.Rows(i)("Process").ToString.ToUpper, "ID SWOP") Then
                    '    dtFlow.Rows(i)("Rework") = 0
                    '    dgvResult.Rows(i).ReadOnly = True
                    '    dgvResult.Rows(i).Cells("Process").Style.ForeColor = Color.Gray
                    '    dgvResult.Rows(i).Cells("Rework").Style.ForeColor = Color.Gray
                    'End If
                    'If InStr(dtFlow.Rows(i)("Process").ToString.ToUpper, "PACKING") _
                    'Or dtFlow.Rows(i)("Process").ToString.ToUpper.Trim = "TEST2" Then
                    '    dtFlow.Rows(i)("Rework") = 1
                    '    dgvResult.Rows(i).ReadOnly = True
                    '    dgvResult.Rows(i).Cells("Process").Style.ForeColor = Color.Gray
                    '    dgvResult.Rows(i).Cells("Rework").Style.ForeColor = Color.Gray
                    'End If
                    'Select Case dtFlow.Rows(i)("RetestFlag").ToString
                    '    Case "0"
                    '        dgvResult.Rows(i).ReadOnly = True
                    '        dgvResult.Rows(i).Cells("Process").Style.ForeColor = Color.Gray
                    '        dgvResult.Rows(i).Cells("Rework").Style.ForeColor = Color.Gray
                    '    Case "1"
                    '        dtFlow.Rows(i)("Rework") = 1
                    '        dgvResult.Rows(i).ReadOnly = True
                    '        dgvResult.Rows(i).Cells("Process").Style.ForeColor = Color.Red
                    '        dgvResult.Rows(i).Cells("Rework").Style.ForeColor = Color.Red
                    '    Case "2"
                    '        dgvResult.Rows(i).Cells("Process").Style.ForeColor = Color.Green
                    '        dgvResult.Rows(i).Cells("Rework").Style.ForeColor = Color.Green
                    'End Select
                    Select Case dtFlow.Rows(i)("RetestFlag").ToString
                        Case "0"
                            dgvResult.Rows(i).ReadOnly = True
                            dgvResult.Rows(i).Cells("Process").Style.ForeColor = Color.Gray
                            dgvResult.Rows(i).Cells("Rework").Style.ForeColor = Color.Gray
                        Case "1"
                            dtFlow.Rows(i)("Rework") = 1
                            dgvResult.Rows(i).ReadOnly = True
                            dgvResult.Rows(i).Cells("Process").Style.ForeColor = Color.Red
                            dgvResult.Rows(i).Cells("Rework").Style.ForeColor = Color.Red
                        Case "2"
                            dgvResult.Rows(i).Cells("Process").Style.ForeColor = Color.Green
                            dgvResult.Rows(i).Cells("Rework").Style.ForeColor = Color.Green
                        Case "4"
                            dtFlow.Rows(i)("Rework") = 1
                            dgvResult.Rows(i).ReadOnly = True
                            dgvResult.Rows(i).Cells("Process").Style.ForeColor = Color.Red
                            dgvResult.Rows(i).Cells("Rework").Style.ForeColor = Color.Red
                    End Select
                Next
                dgvResult.Visible = True
                txtRetestSN.Visible = True
                txtRetestSN.Required = True
                txtRetestSN.ReadOnly = False
                txtRetestSN.Focus()
            End If

        Catch ex As Exception
            BLL.ErrorLogging("OQA-txtResultCode_Validated", BLL.LoginData.User, ex.Message)
        End Try
    End Sub

    Private Sub txtModelNo_ValidateData() Handles txtModelNo.ValidateData
        txtModelNo.Text = Trim(txtModelNo.Text)
        dtFlow = BLL.TLAFlow(txtModelNo.Text).Tables(0)
        If dtFlow.Rows.Count = 0 Then     'revision or PCBA upgrape result to it can't found the flow file.
            Me.ShowMessage("^TDC-147@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtModelNo.SelectAll()
            txtModelNo.Focus()
            Exit Sub
        End If
        txtPCBANo.Text = dtFlow.Rows(0)("PCBA").ToString

        Emifile = BLL.getMIFileData(txtModelNo.Text.Trim, txtModelNo.Text.Trim, CurrProcess)
        If (Not Emifile Is Nothing) Then
            btnEMI.Visible = True
        End If
    End Sub

    Private Sub txtRetestSN_ValidateData() Handles txtRetestSN.ValidateData
        Try
            txtRetestSN.Text = Trim(txtRetestSN.Text)
            Dim IntSNIsValid As String
            IntSNIsValid = BLL.IntSNIsValid(txtRetestSN.Text)
            If IntSNIsValid <> "0" Then  'e.Result = ^TDC-154@  SerialNo Is AccessCard   OR  '^TDC-6@  This Serial number is already in use!
                Me.ShowMessage(IntSNIsValid, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtRetestSN.SelectAll()
                txtRetestSN.Focus()
                Exit Sub
            End If
            SaveResult()
        Catch ex As Exception
            BLL.ErrorLogging("OQA-txtRetestSN_ValidateData", BLL.LoginData.User, ex.Message)
        End Try
    End Sub

    Private Sub SaveResult()
        Try
            dsFlow = New DataSet
            'dtFlow.AcceptChanges()
            Dim dr() As DataRow
            Dim dtFlowCopy As DataTable = New DataTable
            dtFlowCopy = dtFlow.Copy
            dr = dtFlowCopy.Select("Rework<>1 or Rework is null")
            For Each drInUse As DataRow In dr
                drInUse.Delete()
            Next
            dtFlowCopy.AcceptChanges()
            dsFlow.Tables.Add(dtFlowCopy)
            'Dim a As String
            'a = BLL.DStoXML(dsFlow)
            pnlBody.Enabled = False
            Me.ShowMessage("^TDC-26@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
            Me.bgwPost.RunWorkerAsync()
        Catch ex As Exception
            BLL.ErrorLogging("OQA-SaveResult", BLL.LoginData.User, ex.Message)
        End Try
    End Sub

    Private Sub bgwPost_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwPost.DoWork
        Try
            e.Result = BLL.OQACosmetic(txtExtSerial.Text, txtModelNo.Text, txtRetestSN.Text, ResultCode, BLL.LoginData, dsFlow)
        Catch ex As Exception
            BLL.ErrorLogging("OQA-bgwPost_DoWork", BLL.LoginData.User, ex.Message)
        End Try

    End Sub

    Private Sub bgwPost_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPost.RunWorkerCompleted
        pnlBody.Enabled = True
        If e.Result = "^TDC-17@" Then
            Me.ShowMessage("^TDC-17@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim, False)
        Else
            Me.ShowMessage(e.Result, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtRetestSN.SelectAll()
            txtRetestSN.Focus()
            Exit Sub
        End If
        If txtRetestSN.Visible Then
            txtExtSerial.Text = ""
            txtSN2.Text = ""
            txtRetestSN.Text = ""
        Else
            ClearDataInput()
        End If
        txtExtSerial.Focus()
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        SaveResult()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        ClearDataInput()
        txtExtSerial.Focus()
    End Sub

    Private Sub ClearDataInput()
        Me.DisableValidation = True
        grpDataInput.Enabled = True
        dsFlow.Clear()
        dtFlow.Clear()
        txtExtSerial.Text = ""
        txtSN2.Text = ""
        txtResultCode.Text = ""
        txtRetestSN.Text = ""
        txtRetestSN.Visible = False
        dgvResult.Visible = False
        Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        Me.DisableValidation = False
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ClearDataInput()
        txtModelNo.Text = ""
        txtPCBANo.Text = ""
        btnEMI.Visible = False
        txtModelNo.Focus()
    End Sub

    Private Sub frmOQA_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Try
            SerialPort1.Open()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmOQA_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
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
        If txtExtSerial.Focused Then
            txtExtSerial.Text = ReceivedText
            txtExtSerial.Modified = True
            My.Computer.Keyboard.SendKeys("{TAB}")
        ElseIf txtResultCode.Focused Then
            txtResultCode.Text = ReceivedText
            My.Computer.Keyboard.SendKeys("{TAB}")
        ElseIf txtRetestSN.Focus Then
            txtRetestSN.Text = ReceivedText
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
End Class
