Public Class frmRework
    Public ProcessID As Integer
    Public CurrProcess As String
    Public ResultCode As String
    Private PCBA As String
    Private mydataset As DataSet = New DataSet
    Private dtFlow As DataTable = New DataTable
    Private dsFlow As DataSet = New DataSet
    Private flgBusy As Boolean = False
    Private emifile As Object
    Private Delegate Sub UpdateUI(ByVal ReceivedData As String)
    Dim SFC004 As String
    Dim SFC005 As String
    Dim SFC007 As String
    Dim SFC009 As Integer
    Dim ModelRev As String
    Dim POQty As Double
    Dim ExtSNSameIntSN As Boolean
    Dim TraceLevel As String
    Dim dsSNlist As DataSet
    Dim DJOrgCode As String
    Dim DJType As String
    Dim SFC032 As String  'Rework checked DJ is Non-standard DJ or not

    Public Overrides Sub NewSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'New Instance of the form
        Dim NewInstance As New frmMain()
        NewInstance.ShowFrm(Me)
    End Sub

    Private Sub frmRework_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AttachHotkey(btnPost, Keys.F8)
        AttachHotkey(btnNew, Keys.F5)
        AttachHotkey(btnReset, Keys.F3)
        AttachHotkey(btnPrint, Keys.F9)
        ProcessID = SelectProcessID
        CurrProcess = SelectProcess
        BindCtlsToProcess(Me, ProcessID)
        SFC004 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC004'")(0)("Value"))
        SFC005 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC005'")(0)("Value"))
        SFC007 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC007'")(0)("Value"))
        SFC009 = Convert.ToInt32(BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC009'")(0)("Value")))
        SFC032 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC032'")(0)("Value"))
        If SFC004.ToUpper = "NO" Then
            txtIntSerial.KeyIn = False
        End If
        If SFC005.ToUpper = "NO" Then
            txtExtSerial.KeyIn = False
        End If
        'If SFC007.ToUpper = "NO" Then
        '    chkAddlData.Visible = False
        'End If
        Me.ShowMessage(ProcessShow, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
    End Sub

    Private Sub frmRework_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        ddlProcess.Text = ProcessShow
        Me.CenterToScreen()
        BLL.LoginData.User = Mid(UserName.Text, 1, InStr(UserName.Text, "-") - 1).Trim
        BLL.LoginData.OrgCode = MyOrg()
        BLL.LoginData.ProductionLine = ProductionLine()
        txtPONo.Focus()
        'chkAddlData.Focus()
    End Sub

    Private Sub ReworkSingle()
        If txtModelNo.Text <> BLL.GetShipInfoBySN(txtExtSerial.Text).Model Then
            If Me.ShowMessage("^SFC-35@", eTraceUI.eTraceMessageBar.MessageTypes.Warning, AnimationStatus.StopAnim, True, PopUpTypes.Question) = False Then
                txtExtSerial.SelectAll()
                txtExtSerial.Focus()
            Else
                SaveResult()
            End If
        Else
            SaveResult()
        End If
    End Sub

    Private Sub ReworkByBox()
        dsSNlist = BLL.GetShipInfoByBoxIDSN(txtExtSerial.Text)
        If txtModelNo.Text <> dsSNlist.Tables(0).Rows(0)("Model").ToString Then          'the products' model are defferent with DJ's
            If Me.ShowMessage("^SFC-35@", eTraceUI.eTraceMessageBar.MessageTypes.Warning, AnimationStatus.StopAnim, True, PopUpTypes.Question) = False Then
                txtExtSerial.SelectAll()
                txtExtSerial.Focus()
                Exit Sub
            Else
                SaveResultWithBox()
            End If
        Else
            SaveResultWithBox()
        End If
    End Sub

    Private Sub txtExtSerial_ValidateData() Handles txtExtSerial.ValidateData
        txtExtSerial.Text = Trim(txtExtSerial.Text)
        If txtExtSerial.Text = "" Then
            Exit Sub
        End If
        If Not ExtSNSameIntSN Then
            If txtIntSerial.Text = "" Then
                Me.ShowMessage("^TDC-360@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtIntSerial.Focus()
                Exit Sub
            End If
            ReworkSingle()
        Else
            If txtIntSerial.Text <> "" Then
                ReworkSingle()
            Else
                ReworkByBox()
            End If
        End If
    End Sub

    Private Sub txtModelNo_ValidateData() Handles txtModelNo.ValidateData
        txtModelNo.Text = Trim(txtModelNo.Text)
        If txtPONo.Text = "" Then
            Me.ShowMessage("^SFC-86@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtModelNo.Text = ""
            txtPONo.Focus()
            Exit Sub
        End If
       
    End Sub


    Private Sub SaveResult()
        Try
            dsFlow = New DataSet
            Dim dr() As DataRow
            Dim dtFlowCopy As DataTable = New DataTable
            dtFlowCopy = dtFlow.Copy

            dr = dtFlowCopy.Select("Rework<>1 or Rework is null")
            For Each drInUse As DataRow In dr
                drInUse.Delete()
            Next
            dtFlowCopy.AcceptChanges()
            dsFlow.Tables.Add(dtFlowCopy)
            Dim dtInfo As DataTable = New DataTable
            If Not dtInfo.Columns.Contains("PONo") Then
                dtInfo.Columns.Add("PONo")
                dtInfo.AcceptChanges()
            End If
            If Not dtInfo.Columns.Contains("Model") Then
                dtInfo.Columns.Add("Model")
                dtInfo.AcceptChanges()
            End If
            If Not dtInfo.Columns.Contains("ExtSN") Then
                dtInfo.Columns.Add("ExtSN")
                dtInfo.AcceptChanges()
            End If
            If Not dtInfo.Columns.Contains("IntSN") Then
                dtInfo.Columns.Add("IntSN")
                dtInfo.AcceptChanges()
            End If
            If Not dtInfo.Columns.Contains("OrgCode") Then
                dtInfo.Columns.Add("OrgCode")
                dtInfo.AcceptChanges()
            End If
            If Not dtInfo.Columns.Contains("Operator") Then
                dtInfo.Columns.Add("Operator")
                dtInfo.AcceptChanges()
            End If
            If Not dtInfo.Columns.Contains("ProdLine") Then
                dtInfo.Columns.Add("ProdLine")
                dtInfo.AcceptChanges()
            End If
            If Not dtInfo.Columns.Contains("Remark") Then
                dtInfo.Columns.Add("Remark")
                dtInfo.AcceptChanges()
            End If
            If Not dtInfo.Columns.Contains("TVANo") Then
                dtInfo.Columns.Add("TVANo")
                dtInfo.AcceptChanges()
            End If
            Dim drInfo As DataRow
            drInfo = dtInfo.NewRow()
            drInfo("PONo") = txtPONo.Text
            drInfo("Model") = txtModelNo.Text
            drInfo("ExtSN") = txtExtSerial.Text
            drInfo("IntSN") = txtIntSerial.Text
            drInfo("OrgCode") = DJOrgCode
            drInfo("Operator") = BLL.LoginData.User
            drInfo("ProdLine") = BLL.LoginData.ProductionLine
            drInfo("Remark") = txtPOPCBA.Text
            drInfo("TVANo") = txtQty.Text
            dtInfo.Rows.Add(drInfo)
            dtInfo.AcceptChanges()
            dsFlow.Tables.Add(dtInfo)
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
            'e.Result = BLL.Rework(txtExtSerial.Text, txtPONo.Text, txtModelNo.Text, txtIntSerial.Text, chkAddlData.Checked, BLL.LoginData, dsFlow)
            e.Result = BLL.Rework_New(dsFlow)
        Catch ex As Exception
            BLL.ErrorLogging("Rework-bgwPost_DoWork", BLL.LoginData.User, ex.Message)
        End Try

    End Sub

    Private Sub bgwPost_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPost.RunWorkerCompleted
        pnlBody.Enabled = True
        If e.Result = "^TDC-17@" Then
            For i As Integer = 0 To dgvResult.Rows.Count - 1
                If dgvResult.Rows(i).Cells("Process").Value = "Component Replacement" Then
                    dgvResult.Rows(i).Cells("Process").Style.ForeColor = Color.Green
                    dgvResult.Rows(i).Cells("Rework").Style.ForeColor = Color.Green
                    dgvResult.Rows(i).ReadOnly = False
                End If
            Next
            Me.ShowMessage("^TDC-17@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim, False)
        Else
            Me.ShowMessage(e.Result, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True)
            If e.Result = "^SFC-176@" Then
                For i As Integer = 0 To dgvResult.Rows.Count - 1
                    If dgvResult.Rows(i).Cells("Process").Value = "Component Replacement" Then
                        dgvResult.Rows(i).Cells("Rework").Value = 0
                        dgvResult.Rows(i).Cells("Process").Style.ForeColor = Color.Gray
                        dgvResult.Rows(i).Cells("Rework").Style.ForeColor = Color.Gray
                        dgvResult.Rows(i).ReadOnly = True
                        txtExtSerial.Focus()
                        Exit Sub
                    End If
                Next
            End If
        End If
        'If chkAddlData.Checked Then
        '    Me.DisableValidation = True
        '    txtExtSerial.Text = ""
        '    txtIntSerial.Text = ""
        'Else
        ClearDataInput()
        'End If
        txtIntSerial.Focus()
    End Sub

    Private Sub SaveResultWithBox()
        Dim iSuccess As Integer = 0
        Dim iFail As Integer = 0
        Try
            iFail = dsSNlist.Tables(0).Rows.Count
            pnlBody.Enabled = False
            Me.ShowMessage("^TDC-51@" & " " & iSuccess.ToString & "^SFC-88@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
            For Each drSN As DataRow In dsSNlist.Tables(0).Rows
                dsFlow = New DataSet
                Dim dr() As DataRow
                Dim dtFlowCopy As DataTable = New DataTable
                dtFlowCopy = dtFlow.Copy
                dr = dtFlowCopy.Select("Rework<>1 or Rework is null")
                For Each drInUse As DataRow In dr
                    drInUse.Delete()
                Next
                dtFlowCopy.AcceptChanges()
                dsFlow.Tables.Add(dtFlowCopy)
                Dim dtInfo As DataTable = New DataTable
                If Not dtInfo.Columns.Contains("PONo") Then
                    dtInfo.Columns.Add("PONo")
                    dtInfo.AcceptChanges()
                End If
                If Not dtInfo.Columns.Contains("Model") Then
                    dtInfo.Columns.Add("Model")
                    dtInfo.AcceptChanges()
                End If
                If Not dtInfo.Columns.Contains("ExtSN") Then
                    dtInfo.Columns.Add("ExtSN")
                    dtInfo.AcceptChanges()
                End If
                If Not dtInfo.Columns.Contains("IntSN") Then
                    dtInfo.Columns.Add("IntSN")
                    dtInfo.AcceptChanges()
                End If
                If Not dtInfo.Columns.Contains("OrgCode") Then
                    dtInfo.Columns.Add("OrgCode")
                    dtInfo.AcceptChanges()
                End If
                If Not dtInfo.Columns.Contains("Operator") Then
                    dtInfo.Columns.Add("Operator")
                    dtInfo.AcceptChanges()
                End If
                If Not dtInfo.Columns.Contains("ProdLine") Then
                    dtInfo.Columns.Add("ProdLine")
                    dtInfo.AcceptChanges()
                End If
                If Not dtInfo.Columns.Contains("Remark") Then
                    dtInfo.Columns.Add("Remark")
                    dtInfo.AcceptChanges()
                End If
                If Not dtInfo.Columns.Contains("TVANo") Then
                    dtInfo.Columns.Add("TVANo")
                    dtInfo.AcceptChanges()
                End If
                Dim drInfo As DataRow
                drInfo = dtInfo.NewRow()
                drInfo("PONo") = txtPONo.Text
                drInfo("Model") = txtModelNo.Text
                drInfo("ExtSN") = drSN("ExtSN")
                drInfo("IntSN") = drSN("ExtSN")
                drInfo("OrgCode") = DJOrgCode
                drInfo("Operator") = BLL.LoginData.User
                drInfo("ProdLine") = BLL.LoginData.ProductionLine
                drInfo("Remark") = txtPOPCBA.Text
                drInfo("TVANo") = txtQty.Text
                dtInfo.Rows.Add(drInfo)
                dtInfo.AcceptChanges()
                dsFlow.Tables.Add(dtInfo)
                If BLL.Rework_New(dsFlow) = "^TDC-17@" Then
                    dsFlow.Clear()
                    iSuccess = iSuccess + 1
                    iFail = iFail - 1
                Else
                    dsFlow.Clear()
                End If
                Me.ShowMessage("^TDC-51@" & " " & iSuccess.ToString & "^SFC-88@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
            Next
            Me.ShowMessage(iSuccess.ToString & " " & "^SFC-88@" & " " & iFail.ToString & " " & "^SFC-89@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim, False)
            Me.DisableValidation = True
            grpDataInput.Enabled = True
            grpModel.Enabled = True
            txtExtSerial.Text = ""
            Me.DisableValidation = False
            txtExtSerial.Focus()
        Catch ex As Exception
            BLL.ErrorLogging("Rework-SaveResultWithBox", BLL.LoginData.User, ex.Message)
            Me.ShowMessage(iSuccess.ToString & " " & "^SFC-88@" & " " & iFail.ToString & " " & "^SFC-89@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim, False)
        End Try
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        txtExtSerial.Text = Trim(txtExtSerial.Text)
        If txtExtSerial.Text = "" Then
            txtExtSerial.Focus()
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
        pnlModel.Enabled = True
        dsFlow.Clear()
        txtExtSerial.Text = ""
        txtIntSerial.Text = ""
        Me.DisableValidation = False
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ClearDataInput()
        txtModelNo.Text = ""
        txtPCBANo.Text = ""
        txtPONo.Text = ""
        txtPOPCBA.Text = ""
        txtPCBANo.Text = ""
        txtQty.Text = ""
        btnEMI.Visible = False
        txtPONo.Focus()
        'chkAddlData.Enabled = True
        'chkAddlData.Focus()
    End Sub

    Private Sub txtIntSerial_ValidateData() Handles txtIntSerial.ValidateData
        txtIntSerial.Text = Trim(txtIntSerial.Text)
        If txtIntSerial.Text.Length < SFC009 Then
            Me.ShowMessage("^TDC-23@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
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
        If e.Result <> "0" Then  'e.Result = ^TDC-154@  SerialNo Is AccessCard   OR  '^TDC-6@  This Serial number is already in use!
            Me.ShowMessage(e.Result, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
        Else
            Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            txtExtSerial.Focus()
        End If
    End Sub

    Private Sub chkAddlData_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAddlData.Validated
        'chkAddlData.Enabled = False
    End Sub

    Private Sub txtPONo_ValidateData() Handles txtPONo.ValidateData
        txtPONo.Text = Trim(txtPONo.Text)
        If txtPONo.Text = "" Then
            Exit Sub
        End If
        Dim ds As DataSet
        Try
            ds = BLL.DJValidation(txtPONo.Text, "3", BLL.LoginData)
            If ds.Tables("ErrorMsg").Rows.Count > 0 Then 'Or ds.Tables("DJInfo").Rows(0)("DJType") <> "Non-standard" 
                Me.ShowMessage("^TDC-29@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtPONo.SelectAll()
                txtPONo.Focus()
                Return
            Else
                If ds.Tables("DJInfo").Rows(0)("DJType") <> "Non-standard" Then
                    If SFC032 = "YES" Then
                        Me.ShowMessage("^TDC-29@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                        txtPONo.SelectAll()
                        txtPONo.Focus()
                        Return
                    End If
                End If
                ModelRev = ds.Tables("DJInfo").Rows(0)("DJ_REVISION").ToString
                POQty = ds.Tables("DJInfo").Rows(0)("ORDER_QUANTITY")
                txtModelNo.Text = ds.Tables("DJInfo").Rows(0)("PRODUCT_NUMBER")
                DJOrgCode = ds.Tables("DJInfo").Rows(0)("OrgCode")
                DJType = ds.Tables("DJInfo").Rows(0)("DJType")
                Dim dsCPN As DataSet
                dsCPN = BLL.GetProductCPNbyModel(txtModelNo.Text)
                If dsCPN.Tables(0).Rows.Count = 0 Then
                    Me.ShowMessage("^TDC-1@ ^TDC-5@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtModelNo.SelectAll()
                    txtModelNo.Focus()
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
                BLL.CountPoQtyII(DJOrgCode, txtPONo.Text, txtModelNo.Text, txtPCBANo.Text, POQty, ModelRev, DJType)
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
                dgvResult.DataSource = dtFlow
                dgvResult.Columns("Model").Visible = False
                dgvResult.Columns("PCBA").Visible = False
                dgvResult.Columns("SeqNo").Visible = False
                dgvResult.Columns("RetestFlag").Visible = False
                Dim i As Integer
                For i = 0 To dtFlow.Rows.Count - 1
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

                emifile = BLL.getMIFileData(txtModelNo.Text.Trim, txtModelNo.Text.Trim, CurrProcess)
                If (Not emifile Is Nothing) Then
                    btnEMI.Visible = True
                End If
                If Trim(txtQty.Text) = "" Then
                    txtQty.Focus()
                    Exit Sub
                End If
                If Trim(txtPOPCBA.Text) = "" Then
                    txtPOPCBA.Focus()
                    Exit Sub
                End If
                grpModel.Enabled = False
                txtIntSerial.Focus()
            End If
        Catch ex As Exception
            Me.ShowMessage("^TDC-29@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtPONo.SelectAll()
            txtPONo.Focus()
        End Try

    End Sub

    Private Sub frmRework_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Try
            SerialPort1.Open()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmRework_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
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
        Dim t() As Byte = CType(emifile, Byte())
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

    Private Sub txtPOPCBA_ValidateData() Handles txtPOPCBA.ValidateData
        txtPOPCBA.Text = Trim(txtPOPCBA.Text)
        grpModel.Enabled = False
        pnlModel.Enabled = False
        txtIntSerial.Focus()
    End Sub

    Private Sub txtExtSerial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtExtSerial.KeyDown
        If Not txtExtSerial.KeyIn Then
            If (e.Control = True And e.KeyCode = Keys.V) Then
                txtExtSerial.KeyIn = True
            End If
        End If
    End Sub

    Private Sub txtExtSerial_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExtSerial.Enter
        If SFC005.ToUpper = "NO" And txtExtSerial.KeyIn = True Then
            txtExtSerial.KeyIn = False
        End If
    End Sub

    Private Sub txtQty_ValidateData() Handles txtQty.ValidateData
        txtQty.Text = Trim(txtQty.Text)
        txtPOPCBA.Focus()
    End Sub
End Class
