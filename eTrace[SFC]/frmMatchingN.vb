Imports System.Threading.Tasks
Imports eTrace_SFCFunction_.DataModel.WIP

Public Class frmMatchingN

    Public ProcessID As Integer
    Public CurrProcess As String
    Private Const C_PROCESS_DETACH = "PCBA Detach"
    Dim User As String
    Private dsModelStructure As DataSet
    Private dsPCBARouting As DataSet
    Dim dsWIP As DataSet
    Dim AllPass As Boolean
    Dim dtResultList As DataTable
    Dim dtAttributes As DataTable
    Dim tmpRow As DataRow
    Dim TraceLevel As String
    Dim PanelSize As Integer
    Dim Emifile As Object
    Dim IntSNPattern As String
    Dim ChildItem As String
    Dim ReuseChildISN As Boolean = False
    Private flgBusy As Boolean = False
    Private Delegate Sub UpdateUI(ByVal ReceivedData As String)
    Public Structure DJInfo
        Public MatlNo As String
        Public ModelRev As String
        Public OrderQty As Double
        Public OpenQty As Double
        Public ErrorMsg As String
    End Structure
    Dim OrderInfo = New DJInfo
    Dim ordQty As Integer
    Dim SFC001 As String
    Dim SFC004 As String
    Dim SFC009 As Integer
    Public Overrides Sub NewSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'New Instance of the form
        Dim NewInstance As New frmMain()
        NewInstance.ShowFrm(Me)
    End Sub

    Private Sub frmMatchingN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'AttachHotkey(btnPost, Keys.F8)
        'AttachHotkey(btnNew, Keys.F5)
        'AttachHotkey(btnReset, Keys.F3)
        'AttachHotkey(btnPrint, Keys.F9)
        ProcessID = SelectProcessID
        BindCtlsToProcess(Me, ProcessID)
        SFC001 = FixNull(dsConfig.Tables(0).Select("ConfigID='SFC001'")(0)("Value"))
        SFC004 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC004'")(0)("Value"))
        SFC009 = Convert.ToInt32(FixNull(dsConfig.Tables(0).Select("ConfigID='SFC009'")(0)("Value")))
        If SFC004.ToUpper = "NO" Then
            txtIntSerial.KeyIn = False
            txtPCBASerial.KeyIn = False
        Else
            txtIntSerial.KeyIn = True
            txtPCBASerial.KeyIn = True
        End If
        Me.ShowMessage(ProcessShow, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
    End Sub

    Private Sub frmMatchingN_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        ddlProcess.Text = ProcessShow
        Me.CenterToScreen()
        User = Mid(UserName.Text, 1, InStr(UserName.Text, "-") - 1).Trim
        BLL.LoginData.User = User
        BLL.LoginData.OrgCode = MyOrg()
        BLL.LoginData.ProductionLine = ProductionLine()
        txtProcess.Text = "MATCHING2"
        txtProcess.Focus()
    End Sub

    Private Sub txtIntSerial_ValidateData() Handles txtIntSerial.ValidateData
        txtIntSerial.Text = Trim(txtIntSerial.Text)
        If txtIntSerial.Text.Length < SFC009 Then
            Me.ShowMessage("^TDC-23@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            Exit Sub
        End If
        Me.ShowMessage("^TDC-24@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
        pnlBody.Enabled = False

        If txtProcess.Text.Trim() = C_PROCESS_DETACH Then
            DetachMotherBoardValid(txtIntSerial.Text.Trim())
        Else
            Me.bgwIntSerial.RunWorkerAsync()
        End If
    End Sub

    Private Sub DetachMotherBoardValid(motherBoardSN As String)

        Dim task As Task(Of eTrace_SFCFunction_.DetachMotherBoradValidResponse)
        task = New Task(Of eTrace_SFCFunction_.DetachMotherBoradValidResponse)(New Func(Of eTrace_SFCFunction_.DetachMotherBoradValidResponse)(
        Function()
            'Threading.Thread.Sleep(10000)
            Return eTrace_SFCFunction_.Detach.DetachMotherBoradValid(motherBoardSN)
        End Function))
        task.Start()
        pnlBody.Enabled = True
        If task.Result.Success Then
            txtPCBANo.Text = task.Result.PCBA
            txtModelNo.Text = task.Result.Model
            txtPONo.Text = task.Result.DJ
            txtPCBASerial.Focus()
            Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        Else
            Me.ShowMessage(task.Result.ErrorMessage,
            eTraceUI.eTraceMessageBar.MessageTypes.Abort,
            AnimationStatus.StopAnim,
            True,
            PopUpTypes.Message)
            txtIntSerial.Focus()
            txtIntSerial.SelectAll()
        End If

        'Await Threading.Tasks.Task.
        '    Run(New Action(
        '    Sub()
        '        Dim res As eTrace_SFCFunction_.DetachMotherBoradValidResponse =
        '        eTrace_SFCFunction_.Detach.DetachMotherBoradValid(txtIntSerial.Text)
        '        If res.Success Then
        '            txtPCBANo.Text = res.PCBA
        '            txtModelNo.Text = res.Model
        '            txtPONo.Text = res.DJ
        '            txtPCBASerial.Focus()
        '            Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        '        Else
        '            'Me.ShowMessage("ERROR: " & res.ErrorMessage, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        '            Me.ShowMessage(res.ErrorMessage,
        '            eTraceUI.eTraceMessageBar.MessageTypes.Abort,
        '            AnimationStatus.StopAnim,
        '            True,
        '            PopUpTypes.Message)
        '            'Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        '        End If
        '    End Sub))
    End Sub
    Private Sub Detach(motherBoardSN As String, daugtherBoardSN As String)

        'Dim pcbalist As List(Of WIPHeaeder) = _detachValidResult.SubPCBAList
        'Dim index As Integer = -1
        'If pcbalist IsNot Nothing Then
        '    For i As Integer = 0 To pcbalist.Count
        '        If pcbalist(i).IntSN = daugtherBoardSN Then
        '            index = i
        '        End If
        '    Next
        'End If
        'If index > -1 Then
        Dim result As eTrace_SFCFunction_.DetachResponse
            result = eTrace_SFCFunction_.Detach.Detach(motherBoardSN, daugtherBoardSN, User)

            If result.Success Then
                txtIntSerial.Clear()
                txtPCBASerial.Clear()
                txtIntSerial.Focus()
                Me.ShowMessage("^TDC-35@",
                    eTraceUI.eTraceMessageBar.MessageTypes.Information,
                    AnimationStatus.StopAnim,
                    False,
                    PopUpTypes.Message)
            Else
                Me.ShowMessage(result.ErrorMessage,
                 eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                 AnimationStatus.StopAnim,
                 True,
                 PopUpTypes.Message)
            End If
        'Await Threading.Tasks.Task.
        '    Run(New Action(
        '    Sub()
        '        Dim res As eTrace_SFCFunction_.DetachResponse =
        '        eTrace_SFCFunction_.Detach.Detach(motherBoardSN, daugtherBoardSN, User)
        '        If res.Success Then
        '            Me.ShowMessage(res.ErrorMessage,
        '            eTraceUI.eTraceMessageBar.MessageTypes.Information,
        '            AnimationStatus.StopAnim,
        '            False,
        '            PopUpTypes.Message)
        '            txtIntSerial.Clear()
        '            txtPCBASerial.Clear()
        '            txtIntSerial.Focus()
        '        Else
        '            Me.ShowMessage(res.ErrorMessage,
        '            eTraceUI.eTraceMessageBar.MessageTypes.Abort,
        '            AnimationStatus.StopAnim,
        '            True,
        '            PopUpTypes.Message)
        '        End If
        '    End Sub))
    End Sub
    Private Sub bgwIntSerial_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwIntSerial.DoWork
        Try
            e.Result = BLL.GetResultAndPCBAList(txtIntSerial.Text, CurrProcess)
        Catch ex As Exception
            BLL.ErrorLogging("Packing-bgwIntSerial_DoWork", User, ex.Message)
        End Try
    End Sub

    Private Sub bgwIntSerial_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwIntSerial.RunWorkerCompleted
        pnlBody.Enabled = True
        If e.Result.Tables(0).rows(0)("ErrMsg") <> "" Then
            Me.ShowMessage("ERROR: " & txtIntSerial.Text & " ^TDC-5@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
            Return
        End If

        txtPCBANo.Text = e.Result.Tables(1).rows(0)("PCBA").ToString
        txtPONo.Text = e.Result.Tables(1).rows(0)("DJ").ToString

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
            Me.ShowMessage("ERROR: " & txtProcess.Text & "^SFC-7@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
            Return
        End If

        Dim iRows As Integer
        Dim FlowSeqNo As Integer = 0
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
                If dtResultList.Rows(i)(1) = "PASS" Then  'Matching* can't be Fail or skip
                    Me.ShowMessage("^SFC-2@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtIntSerial.SelectAll()
                    txtIntSerial.Focus()
                    Return
                Else
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

        If dtResultList.Rows(iRows - 1)("Process").ToString.Trim.ToUpper = txtProcess.Text.ToUpper Then
            AllPass = True
        Else
            AllPass = False
        End If

        dsWIP = dsMatchingN()
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
        dr("FlowSeqNo") = FlowSeqNo
        dr("Result") = "PASS"
        dr("AllPassed") = AllPass
        dr("ChangedBy") = User
        dsWIP.Tables("WIPHeader").Rows.Add(dr)
        dtAttributes = e.Result.Tables(3)
        AddPCBATable(dsWIP)
        Dim myDataRow As DataRow
        For Each drPCBA As DataRow In dtAttributes.Rows
            myDataRow = dsWIP.Tables("PCBAList").NewRow()
            myDataRow("SubPCBA") = drPCBA("SubPCBA")
            dsWIP.Tables("PCBAList").Rows.Add(myDataRow)
        Next

        dgvPCBA.DataSource = dsWIP
        dgvPCBA.DataMember = "PCBAList"

        txtPCBASerial.Focus()

        Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)

    End Sub

    Private Sub SaveResult()
        Try
            Me.ShowMessage("^TDC-26@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
            pnlBody.Enabled = False
            Me.bgwPost.RunWorkerAsync()
        Catch ex As Exception
            BLL.ErrorLogging("MatchingN-SaveResult", User, ex.Message)
        End Try
    End Sub

    Private Sub bgwPost_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwPost.DoWork
        Try
            e.Result = BLL.WIPMatchingN(dsWIP)
        Catch ex As Exception
            BLL.ErrorLogging("MatchingN-bgwPost_DoWork", User, ex.Message)
            Me.ShowMessage(ex.Message + "  " + txtIntSerial.Text, eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
        End Try
    End Sub

    Private Sub bgwPost_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPost.RunWorkerCompleted
        Try
            pnlBody.Enabled = True
            If e.Result = "^TDC-155@" Then   'Matching successful.
                txtProdQty.Text = BLL.GetDJMatchedQty(txtPONo.Text, txtPCBANo.Text, BLL.LoginData.OrgCode)
                Me.ShowMessage(e.Result + "  " + txtIntSerial.Text, eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
                txtIntSerial.Clear()
                txtIntSerial.Focus()
            Else                          ' Matching failed.
                Me.ShowMessage(e.Result + "  " + txtIntSerial.Text, eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
                'txtIntSerial.Clear()
                'txtIntSerial.Focus()
                txtPCBASerial.Text = ""
                txtIntSerial.Text = ""
                txtIntSerial.SelectAll()
                txtIntSerial.Focus()
            End If
            grpDataInput.Enabled = True
            txtPCBASerial.Clear()
            dtResultList.Clear()
            dsWIP.Clear()
            txtModelNo.Text = ""
            txtPCBANo.Text = ""
            txtPONo.Text = ""
        Catch ex As Exception
            BLL.ErrorLogging("MatchingN-bgwPost_RunWorkerCompleted", User, ex.Message)
            Me.ShowMessage(ex.Message + "  " + txtIntSerial.Text, eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
        End Try
    End Sub
    Dim SubPCBANo As String
    Private Sub txtPCBASerial_ValidateData() Handles txtPCBASerial.ValidateData
        Try
            If txtIntSerial.Text = "" Then
                Exit Sub
            End If
            If txtProcess.Text = C_PROCESS_DETACH Then
                Detach(txtIntSerial.Text, txtPCBASerial.Text)
                Exit Sub
            End If
            Dim DRsubPCBA() As DataRow
            DRsubPCBA = dsWIP.Tables("PCBAList").Select("PCBASerialNo = '" & txtPCBASerial.Text & "'")
            If DRsubPCBA.Length <> 0 Then  'the subPCBA exists in pcba list.
                Me.ShowMessage("ERROR: " & txtPCBASerial.Text & " ^TDC-158@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                'If txtPCBASerial.Text = txtIntSerial.Text Then
                '    txtPCBASerial.Text = ""
                '    txtIntSerial.SelectAll()
                '    txtIntSerial.Focus()
                'Else
                '    txtPCBASerial.SelectAll()
                '    txtPCBASerial.Focus()
                'End If
                txtPCBASerial.Text = ""
                txtIntSerial.Text = ""
                txtIntSerial.SelectAll()
                txtIntSerial.Focus()
                Return
            End If
            SubPCBANo = BLL.getPCBAinWIPHeader(txtPCBASerial.Text)
            If SubPCBANo = "^TDC-5@" Then  'does not exist.
                Me.ShowMessage("ERROR: " & txtPCBASerial.Text & " ^TDC-5@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                'If txtPCBASerial.Text = txtIntSerial.Text Then
                '    txtPCBASerial.Text = ""
                '    txtIntSerial.SelectAll()
                '    txtIntSerial.Focus()
                'Else
                '    txtPCBASerial.SelectAll()
                '    txtPCBASerial.Focus()
                'End If
                txtPCBASerial.Text = ""
                txtIntSerial.Text = ""
                txtIntSerial.SelectAll()
                txtIntSerial.Focus()
                Return
            End If

            DRsubPCBA = dsWIP.Tables("PCBAList").Select("SubPCBA ='" & SubPCBANo & "'")
            If DRsubPCBA.Length = 0 Then  '^TDC-9@    'does not defined in the PCBA!     Sub PCBA not in the list
                Me.ShowMessage("ERROR: " & txtPCBASerial.Text & " ^TDC-9@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                'txtPCBASerial.SelectAll()
                'txtPCBASerial.Focus()
                txtPCBASerial.Text = ""
                txtIntSerial.Text = ""
                txtIntSerial.SelectAll()
                txtIntSerial.Focus()
                Return
            End If
            Me.ShowMessage("^TDC-24@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
            txtPCBASerial.Modified = False
            pnlBody.Enabled = False
            Me.bgwSubPCBA.RunWorkerAsync()
        Catch ex As Exception
            BLL.ErrorLogging("MatchingN-txtPCBASerial_ValidateData", User, ex.Message)
        End Try
    End Sub

    Private Sub bgwSubPCBA_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwSubPCBA.DoWork
        Try
            e.Result = BLL.DBoardIsValid(txtPCBASerial.Text)
        Catch ex As Exception
            BLL.ErrorLogging("MatchingN-bgwSubPCBA_DoWork", User, ex.Message)
        End Try
    End Sub

    Private Sub bgwSubPCBA_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwSubPCBA.RunWorkerCompleted
        pnlBody.Enabled = True
        If Microsoft.VisualBasic.Left(e.Result, 5).ToUpper <> "WIPID" Then
            '^TDC-13@'  Failed process found!      
            '^TDC-157@' has been binded to another PCBA   
            Me.ShowMessage("ERROR: " & txtPCBASerial.Text & " " & e.Result, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            'Me.ShowMessage(Microsoft.VisualBasic.Mid(e.Result, 7), eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            'txtPCBASerial.SelectAll()
            'txtPCBASerial.Focus()
            txtPCBASerial.Text = ""
            txtIntSerial.Text = ""
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
        Else

            If dsWIP.Tables("PCBAList").Select("SubPCBA='" & SubPCBANo & "' and (PCBASerialNo = '' or PCBASerialNo is null ) ").Length = 0 Then
                Me.ShowMessage("ERROR: " & txtPCBASerial.Text & " " & "'^SFC-1@'", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                'txtPCBASerial.SelectAll()
                'txtPCBASerial.Focus()
                txtPCBASerial.Text = ""
                txtIntSerial.Text = ""
                txtIntSerial.SelectAll()
                txtIntSerial.Focus()
                Exit Sub
            End If
            For Each tmpRow In dsWIP.Tables("PCBAList").Rows
                If tmpRow(0) = SubPCBANo Then
                    If FixNull(tmpRow("PCBASerialNo")) = "" Then    ' only fill up blank 'sub pcba' column
                        tmpRow("PCBASerialNo") = txtPCBASerial.Text
                        tmpRow("PCBAResult") = "PASS"
                        tmpRow("PCBAWipID") = Mid(e.Result, 7)
                        Exit For
                    End If
                End If
            Next
            dsWIP.Tables("PCBAList").AcceptChanges()

            Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            'Check if all Sub PCBAs have been filled, if yes, txtPCBASerial is no more required
            'If not, then clear the input and focus on txtPCBASerial
            If SubPCBAInput(dsWIP.Tables("PCBAList")) = True Then
                'txtPCBASerial.Required = False
                txtPCBASerial.Modified = False
                'Auto complete the "save" process
                SaveResult()
            Else
                txtPCBASerial.Clear()
                txtPCBASerial.Focus()
            End If
        End If
    End Sub

    Public Function SubPCBAInput(ByVal tblPCBA As DataTable) As Boolean
        Dim i As Integer
        'Return false if any blank serial number
        For i = 0 To tblPCBA.Rows.Count - 1
            If tblPCBA.Rows(i)(2) Is DBNull.Value Then
                Return False
            End If
            If tblPCBA.Rows(i)(2) = "" Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Function FixNull(ByVal vMayBeNull As Object) As String
        On Error Resume Next
        FixNull = vbNullString & vMayBeNull
    End Function


    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ClearDataInput()
    End Sub

    Private Sub ClearDataInput()
        Me.DisableValidation = True
        If btnPost.Enabled Then
            If Me.ShowMessage("^OLD-4@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.NoChange, True, PopUpTypes.Question) = False Then
                Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
                Me.DisableValidation = False
                Exit Sub
            End If
        End If
        grpDataInput.Enabled = True

        'Refresh dgvPCBA here...
        Dim DataRow As DataRow
        If Not dsWIP Is Nothing Then
            For Each DataRow In dsWIP.Tables("PCBAList").Rows
                DataRow(2) = ""
                DataRow(3) = ""
            Next
            dsWIP.Tables("PCBAList").AcceptChanges()
        End If

        btnPost.Enabled = True
        txtIntSerial.Text = ""
        txtIntSerial.Focus()

        Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        Me.DisableValidation = False
        btnEMI.Visible = False
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        ClearDataInput()
    End Sub

    Private Sub frmMatchingN_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Try
            SerialPort1.Open()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmMatchingN_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
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
    Private Function dsMatchingN() As DataSet
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

        'Dim WIPFlow As DataTable = New Data.DataTable("WIPFlow")
        'WIPFlow.Columns.Add(New Data.DataColumn("SeqNo", System.Type.GetType("System.String")))
        'WIPFlow.Columns.Add(New Data.DataColumn("Process", System.Type.GetType("System.String")))
        'WIPFlow.Columns.Add(New Data.DataColumn("Status", System.Type.GetType("System.String")))
        'WIPFlow.Columns.Add(New Data.DataColumn("TestRound", System.Type.GetType("System.String")))
        'WIPFlow.Columns.Add(New Data.DataColumn("LastResult", System.Type.GetType("System.String")))

        'Dim WIPProperties As DataTable = New Data.DataTable("WIPProperties")
        'WIPProperties.Columns.Add(New Data.DataColumn("SeqNo", System.Type.GetType("System.String")))
        'WIPProperties.Columns.Add(New Data.DataColumn("PropertyType", System.Type.GetType("System.String")))
        'WIPProperties.Columns.Add(New Data.DataColumn("PropertyName", System.Type.GetType("System.String")))
        'WIPProperties.Columns.Add(New Data.DataColumn("PropertyValue", System.Type.GetType("System.String")))
        'WIPProperties.Columns.Add(New Data.DataColumn("ChangedBy", System.Type.GetType("System.String")))

        DS.Tables.Add(WIPHeader)
        'DS.Tables.Add(WIPFlow)
        'DS.Tables.Add(WIPProperties)
        Return DS
    End Function

    Private Sub AddPCBATable(ByVal DS As DataSet)
        Dim PCBAList As DataTable
        Dim myDataColumn As DataColumn
        PCBAList = New Data.DataTable("PCBAList")

        myDataColumn = New Data.DataColumn("SubPCBA", System.Type.GetType("System.String"))
        PCBAList.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("SubPCBADesc", System.Type.GetType("System.String"))
        PCBAList.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("PCBASerialNo", System.Type.GetType("System.String"))
        PCBAList.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("PCBAResult", System.Type.GetType("System.String"))
        PCBAList.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("PCBAWipID", System.Type.GetType("System.String"))
        PCBAList.Columns.Add(myDataColumn)

        DS.Tables.Add(PCBAList)
    End Sub

    Private Sub txtProcess_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProcess.Validated
        txtProcess.Text = txtProcess.Text.Trim
        If txtProcess.Text = "" Then Exit Sub
        CurrProcess = txtProcess.Text
        txtProcess.Enabled = False
        txtIntSerial.Focus()
    End Sub
End Class
