Public Class frmWIPRework
    Public ProcessID As Integer
    Public CurrProcess As String
    Public ResultCode As String
    Private PCBA As String
    Private mydataset As DataSet = New DataSet
    Private dtFlow As DataTable = New DataTable
    Private dsFlow As DataSet = New DataSet
    Private flgBusy As Boolean = False
    Private Emifile As Object
    Dim TraceLevel As String
    Private Delegate Sub UpdateUI(ByVal ReceivedData As String)

    Public Overrides Sub NewSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'New Instance of the form
        Dim NewInstance As New frmMain()
        NewInstance.ShowFrm(Me)
    End Sub

    Private Sub frmWIPRework_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'AttachHotkey(btnPost, Keys.F8)
        AttachHotkey(btnNew, Keys.F5)
        AttachHotkey(btnReset, Keys.F3)
        AttachHotkey(btnPrint, Keys.F9)
        ProcessID = SelectProcessID
        CurrProcess = SelectProcess
        BindCtlsToProcess(Me, ProcessID)
        Me.ShowMessage(ProcessShow, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
    End Sub

    Private Sub frmWIPRework_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        ddlProcess.Text = ProcessShow
        Me.CenterToScreen()
        BLL.LoginData.User = Mid(UserName.Text, 1, InStr(UserName.Text, "-") - 1).Trim
        BLL.LoginData.OrgCode = MyOrg()
        BLL.LoginData.ProductionLine = ProductionLine()
        If txtPOPCBA.Enabled Then
            txtPOPCBA.Focus()
        Else
            txtModelNo.Focus()
        End If
        'chkAddlData.Focus()
    End Sub

    Private Sub txtExtSerial_ValidateData() Handles txtExtSerial.ValidateData
        txtExtSerial.Text = Trim(txtExtSerial.Text)
        'If txtModelNo.Text <> BLL.GetShipInfoBySN(txtExtSerial.Text).Model Then
        '    If Me.ShowMessage("^SFC-35@", eTraceUI.eTraceMessageBar.MessageTypes.Warning, AnimationStatus.StopAnim, True, PopUpTypes.Question) = False Then
        '        txtExtSerial.SelectAll()
        '        txtExtSerial.Focus()
        '    Else
        '        SaveResult()
        '    End If
        'Else
        '    SaveResult()
        'End If
    End Sub

    Private Sub txtModelNo_ValidateData() Handles txtModelNo.ValidateData
        txtModelNo.Text = Trim(txtModelNo.Text)
        txtPCBANo.Focus()
    End Sub


    Private Sub SaveResult()
        Try
            dsFlow = New DataSet
            'dtFlow.AcceptChanges()
            Dim dr() As DataRow
            Dim dtFlowCopy As DataTable = New DataTable
            dtFlowCopy = dtFlow.Copy
            If Not dtFlowCopy.Columns.Contains("Rework") Then
                dtFlowCopy.Columns.Add("Rework")
                dtFlowCopy.AcceptChanges()
            End If
            dr = dtFlowCopy.Select("Rework<>1 or Rework is null")
            For Each drInUse As DataRow In dr
                drInUse.Delete()
            Next
            dtFlowCopy.AcceptChanges()
            dsFlow.Tables.Add(dtFlowCopy)
            Dim dtRemark As DataTable = New DataTable
            dtRemark.Columns.Add("Remark")
            dtRemark.AcceptChanges()
            Dim drRemark As DataRow
            drRemark = dtRemark.NewRow()
            drRemark("Remark") = txtPOPCBA.Text
            dtRemark.Rows.Add(drRemark)
            dtRemark.AcceptChanges()
            dsFlow.Tables.Add(dtRemark)
            'Dim a As String
            'a = BLL.DStoXML(dsFlow)
            pnlBody.Enabled = False
            Me.ShowMessage("^TDC-26@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
            Me.bgwPost.RunWorkerAsync()
        Catch ex As Exception
            BLL.ErrorLogging("Rework-SaveResult", BLL.LoginData.User, ex.Message)
        End Try
    End Sub

    Private Sub bgwPost_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwPost.DoWork
        Try
            e.Result = BLL.WIPRework(txtIntSerial.Text, BLL.LoginData, dsFlow)
        Catch ex As Exception
            BLL.ErrorLogging("Rework-bgwPost_DoWork", BLL.LoginData.User, ex.Message)
        End Try

    End Sub

    Private Sub bgwPost_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPost.RunWorkerCompleted
        pnlBody.Enabled = True
        If e.Result = "^TDC-17@" Then
            Me.ShowMessage("^TDC-17@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim, False)
        Else
            Me.ShowMessage(e.Result, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True)
        End If
        Me.DisableValidation = True
        txtIntSerial.Text = ""
        txtIntSerial.Focus()
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        If txtIntSerial.Text.Trim = "" Then
            txtIntSerial.Focus()
            Exit Sub
        End If
        SaveResult()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        txtExtSerial.Text = ""
        txtIntSerial.Text = ""
        Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        txtIntSerial.Focus()
    End Sub

    Private Sub ClearDataInput()
        Me.DisableValidation = True
        grpDataInput.Enabled = True
        grpModel.Enabled = True
        dsFlow.Clear()
        dtFlow.Clear()
        chkAddlData.Checked = False
        txtIntSerial.Text = ""
        'dgvResult.Visible = False
        Me.DisableValidation = False
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ClearDataInput()
        txtModelNo.Text = ""
        txtPCBANo.Text = ""
        btnEMI.Visible = False
        'txtModelNo.Focus()
        chkAddlData.Enabled = True
        chkAddlData.Focus()
    End Sub

    Private Sub txtIntSerial_ValidateData() Handles txtIntSerial.ValidateData
        txtIntSerial.Text = Trim(txtIntSerial.Text)
        If Me.ShowMessage("^SFC-45@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim, True, PopUpTypes.Question) = False Then
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
            Exit Sub
        End If
        Me.ShowMessage("^TDC-24@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False) 'Validating Serial number, please wait...
        Me.bgwIntSerial.RunWorkerAsync()
    End Sub

    Private Sub bgwIntSerial_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwIntSerial.DoWork
        Try
            e.Result = BLL.IntSNIsValid(txtIntSerial.Text)
        Catch ex As Exception
            BLL.ErrorLogging("Rework-bgwIntSerial_DoWork", BLL.LoginData.User, ex.Message)
            Me.ShowMessage(ex.Message, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        End Try
    End Sub
    Private Sub bgwIntSerial_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwIntSerial.RunWorkerCompleted
        If e.Result = "^TDC-154@" Then  'e.Result = ^TDC-154@  SerialNo Is AccessCard   OR  '^TDC-6@  This Serial number is already in use!
            Me.ShowMessage(e.Result, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
            Exit Sub
        End If
        If e.Result = "0" Then  'card not be bind to product.
            Me.ShowMessage("^TDC-23@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
            Exit Sub
        End If
        'get model in wip header
        'get pcba in wip header
        'If txtPCBANo.Text <> BLL.getPCBAinWIPHeader(txtIntSerial.Text) Then  'PCBA is not the PCBA of this Model
        '    Me.ShowMessage("^TDC-23@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        '    txtIntSerial.SelectAll()
        '    txtIntSerial.Focus()
        '    Exit Sub
        'End If
        Dim dsInt As DataSet
        dsInt = BLL.GetDataByIntSN(txtIntSerial.Text)
        If dsInt.Tables(0).Rows(0)("MotherBoardSN").ToString <> "" Then
            Me.ShowMessage("^TDC-157@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
            Exit Sub
        End If
        If dsInt.Tables(0).Rows(0)("PCBA").ToString <> txtPCBANo.Text Then
            Me.ShowMessage("^SFC-115@" & " " & txtPCBANo.Text, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
            Exit Sub
        End If
        Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim, False)
        SaveResult()
    End Sub

    Private Sub txtPONo_ValidateData() Handles txtPONo.ValidateData
        txtPONo.Text = Trim(txtPONo.Text)
    End Sub

    Private Sub frmWIPRework_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Try
            SerialPort1.Open()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmWIPRework_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
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

    Private Sub txtPCBANo_ValidateData() Handles txtPCBANo.ValidateData
        If txtPCBANo.Text.Trim = "" Then
            Exit Sub
        End If
        If txtModelNo.Text.Trim = "" Then
            Exit Sub
        End If
        TraceLevel = BLL.getTraceLevel(txtModelNo.Text)
        dtFlow = BLL.PCBARouting(txtModelNo.Text, txtPCBANo.Text).Tables(0)
        If dtFlow.Rows.Count = 0 Then     'revision or PCBA upgrape result to it can't found the flow file.
            Me.ShowMessage("^TDC-147@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtPCBANo.SelectAll()
            txtPCBANo.Focus()
            Exit Sub
        End If
        If dtFlow.Columns.Count = 1 Then     'revision or PCBA upgrape result to it can't found the flow file.
            Me.ShowMessage(dtFlow.Rows(0)(0), eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtPCBANo.SelectAll()
            txtPCBANo.Focus()
            Exit Sub
        End If
        txtPCBANo.Text = dtFlow.Rows(0)("PCBA").ToString
        If Not dtFlow.Columns.Contains("Rework") Then
            dtFlow.Columns.Add("Rework")
        End If

        If TraceLevel.ToUpper = "SN" Then
            Dim drComRep As DataRow
            drComRep = dtFlow.NewRow()
            drComRep("SeqNo") = "2"
            drComRep("Process") = "Component Replacement"
            drComRep("RetestFlag") = "2"
            drComRep("Rework") = 0
            dtFlow.Rows.InsertAt(drComRep, 0)
        End If

        'dtFlow.Columns.Remove("FailedUnitReturnTo")
        'dtFlow.Columns.Remove("MaxTestRound")
        'dtFlow.Columns.Remove("MaxFailure")
        'dtFlow.Columns.Remove("StandardTime")
        'dtFlow.Columns.Remove("SamplingTest")
        'dtFlow.Columns.Remove("SamplingLogic")
        'dtFlow.Columns.Remove("PanelMatching")
        'dtFlow.Columns.Remove("PanelSize")
        'dtFlow.Columns.Remove("MatchingbyExtSN")
        'dtFlow.Columns.Remove("Label1")
        'dtFlow.Columns.Remove("Label2")
        'dtFlow.Columns.Remove("Label3")
        dgvResult.DataSource = dtFlow
        'dgvResult.Columns("Model").Visible = False
        'dgvResult.Columns("PCBA").Visible = False
        'dgvResult.Columns("SeqNo").Visible = False
        'dgvResult.Columns("RetestFlag").Visible = False
        Dim iCol As Integer
        For iCol = 0 To dgvResult.ColumnCount - 1
            If dgvResult.Columns(iCol).Name <> "Process" And dgvResult.Columns(iCol).Name <> "Rework" Then
                dgvResult.Columns(iCol).Visible = False
            End If
        Next
        Dim i As Integer
        For i = 0 To dtFlow.Rows.Count - 1
            Select Case dtFlow.Rows(i)("RetestFlag").ToString
                Case "0"
                    dgvResult.Rows(i).ReadOnly = True
                    dgvResult.Rows(i).Cells("Process").Style.ForeColor = Color.Gray
                    dgvResult.Rows(i).Cells("Rework").Style.ForeColor = Color.Gray
                    'Case "1"
                    '    dtFlow.Rows(i)("Rework") = 1
                    '    dgvResult.Rows(i).ReadOnly = True
                    '    dgvResult.Rows(i).Cells("Process").Style.ForeColor = Color.Red
                    '    dgvResult.Rows(i).Cells("Rework").Style.ForeColor = Color.Red
                Case "2"
                    dgvResult.Rows(i).Cells("Process").Style.ForeColor = Color.Green
                    dgvResult.Rows(i).Cells("Rework").Style.ForeColor = Color.Green
                Case "3"
                    dtFlow.Rows(i)("Rework") = 1
                    dgvResult.Rows(i).ReadOnly = True
                    dgvResult.Rows(i).Cells("Process").Style.ForeColor = Color.Red
                    dgvResult.Rows(i).Cells("Rework").Style.ForeColor = Color.Red
                Case "4"
                    dtFlow.Rows(i)("Rework") = 1
                    dgvResult.Rows(i).ReadOnly = True
                    dgvResult.Rows(i).Cells("Process").Style.ForeColor = Color.Red
                    dgvResult.Rows(i).Cells("Rework").Style.ForeColor = Color.Red
            End Select
        Next
        Emifile = BLL.getMIFileData(txtModelNo.Text.Trim, txtModelNo.Text.Trim, CurrProcess)
        If (Not Emifile Is Nothing) Then
            btnEMI.Visible = True
        End If
        grpModel.Enabled = False
        txtIntSerial.Focus()
    End Sub

    Private Sub txtPOPCBA_ValidateData() Handles txtPOPCBA.ValidateData
        txtPOPCBA.Text = Trim(txtPOPCBA.Text)
        txtModelNo.Focus()
    End Sub
End Class
