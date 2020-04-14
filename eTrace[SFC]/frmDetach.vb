Public Class frmDetach
    Public ProcessID As Integer
    Public CurrProcess As String
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
    Public Overrides Sub NewSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'New Instance of the form
        Dim NewInstance As New frmMain()
        NewInstance.ShowFrm(Me)
    End Sub

    Private Sub frmDetach_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'AttachHotkey(btnPost, Keys.F8)
        'AttachHotkey(btnNew, Keys.F5)
        'AttachHotkey(btnReset, Keys.F3)
        'AttachHotkey(btnPrint, Keys.F9)
        ProcessID = SelectProcessID
        BindCtlsToProcess(Me, ProcessID)
        txtPCBASerialNo.KeyIn = Config.AllowMunualInput
        txtSubPCBASerialNo.KeyIn = Config.AllowMunualInput
        Me.ShowMessage(ProcessShow, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
    End Sub

    Private Sub frmDetach_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        ddlProcess.Text = ProcessShow
        Me.CenterToScreen()
        User = Mid(UserName.Text, 1, InStr(UserName.Text, "-") - 1).Trim
        BLL.LoginData.User = User
        BLL.LoginData.OrgCode = MyOrg()
        BLL.LoginData.ProductionLine = ProductionLine()

    End Sub

    Private Sub txtPCBASerialNo_ValidateData() Handles txtPCBASerialNo.ValidateData
        txtPCBASerialNo.Text = Trim(txtPCBASerialNo.Text)
        If txtPCBASerialNo.Text.Length < Config.MinimalIntSNLength Then
            Me.ShowMessage("^TDC-23@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            Exit Sub
        End If
        Me.ShowMessage("^TDC-24@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
        pnlBody.Enabled = False

        '''to do start
    End Sub

    Private Async Sub DetachMotherBoardValid(motherBoardSN As String)
        Threading.Tasks.Task.
            Run(New Action(
            Sub()
                Dim res As eTrace_SFCFunction_.DetachMotherBoradValidResponse =
                BLL.DetachMotherBoradValid(txtPCBASerialNo.Text)
                If res.Success Then
                    txtPCBANo.Text = res.PCBA
                    txtModelNo.Text = res.Model
                    txtPONo.Text = res.DJ
                Else
                    Me.ShowMessage(res.ErrorMessage,
                    eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                    AnimationStatus.StopAnim,
                    True,
                    PopUpTypes.Message)
                End If
            End Sub))
    End Sub
    Private Function Detach(motherBoardSN As String, daugtherBoardSN As String) As String

    End Function
    Private Sub bgwIntSerial_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwIntSerial.DoWork
        Try
            e.Result = BLL.GetResultAndPCBAList(txtPCBASerialNo.Text, CurrProcess)
        Catch ex As Exception
            BLL.ErrorLogging("Packing-bgwIntSerial_DoWork", User, ex.Message)
        End Try
    End Sub

    Private Sub bgwIntSerial_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwIntSerial.RunWorkerCompleted
        pnlBody.Enabled = True
        'If e.Result.Tables(0).rows(0)("ErrMsg") <> "" Then
        '    Me.ShowMessage("ERROR: " & txtPCBASerialNo.Text & " ^TDC-5@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        '    txtPCBASerialNo.SelectAll()
        '    txtPCBASerialNo.Focus()
        '    Return
        'End If

        'txtPCBANo.Text = e.Result.Tables(1).rows(0)("PCBA").ToString
        'txtPONo.Text = e.Result.Tables(1).rows(0)("DJ").ToString

        'If e.Result.Tables(1).rows(0)("CurrentProcess").ToString = "Repair" And e.Result.Tables(1).rows(0)("Result").ToString <> "Fixed" Then
        '    Me.ShowMessage("^SFC-66@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        '    txtPCBASerialNo.SelectAll()
        '    txtPCBASerialNo.Focus()
        '    Return
        'End If

        'dtResultList = e.Result.Tables(2)
        'dgvSubPCBAList.DataSource = dtResultList
        'Dim HasProc As Integer = 0
        'HasProc = dtResultList.Select("Process='" & txtProcess.Text & "'").Length
        'If HasProc = 0 Then
        '    Me.ShowMessage("ERROR: " & txtProcess.Text & "^SFC-7@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        '    txtPCBASerialNo.SelectAll()
        '    txtPCBASerialNo.Focus()
        '    Return
        'End If

        'Dim iRows As Integer
        'Dim FlowSeqNo As Integer = 0
        'iRows = dtResultList.Rows.Count
        'Dim i As Integer
        'Dim ErrFound As Boolean = False
        'For i = 0 To iRows - 1
        '    If ErrFound = True Then
        '        Me.ShowMessage("^TDC-13@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        '        txtPCBASerialNo.SelectAll()
        '        txtPCBASerialNo.Focus()
        '        Return
        '    End If

        '    If dtResultList.Rows(i)(0).ToString.Trim.ToUpper = txtProcess.Text.ToUpper Then   'For current process, fill in "pass" here
        '        If dtResultList.Rows(i)(1) = "PASS" Then  'Matching* can't be Fail or skip
        '            Me.ShowMessage("^SFC-2@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        '            txtPCBASerialNo.SelectAll()
        '            txtPCBASerialNo.Focus()
        '            Return
        '        Else
        '            dtResultList.Rows(i)(1) = "WIPIN"
        '            dgvSubPCBAList.Rows(i).Cells(1).Style.ForeColor = Color.Green
        '            dgvSubPCBAList.Rows(i).Cells(2).Style.ForeColor = Color.Green
        '            FlowSeqNo = dtResultList.Rows(i)(2)
        '        End If
        '        Exit For
        '    End If
        '    If Microsoft.VisualBasic.Left(dtResultList.Rows(i)(1).ToString.ToUpper, 4) <> "PASS" Then
        '        dgvSubPCBAList.Rows(i).Cells(1).Style.ForeColor = Color.Red
        '        ErrFound = True
        '    End If
        'Next

        'If dtResultList.Rows(iRows - 1)("Process").ToString.Trim.ToUpper = txtProcess.Text.ToUpper Then
        '    AllPass = True
        'Else
        '    AllPass = False
        'End If

        'dsWIP = dsMatchingN()
        'Dim dr As DataRow
        'dr = dsWIP.Tables("WIPHeader").NewRow()
        'dr("WIPID") = e.Result.Tables(1).rows(0)("WIPID").ToString
        'dr("IntSN") = txtPCBASerialNo.Text
        'dr("Model") = txtModelNo.Text
        'dr("PCBA") = txtPCBANo.Text
        'dr("DJ") = txtPONo.Text
        'dr("InvOrg") = BLL.LoginData.OrgCode
        'dr("ProdLine") = BLL.LoginData.ProductionLine
        'dr("CurrentProcess") = txtProcess.Text
        'dr("FlowSeqNo") = FlowSeqNo
        'dr("Result") = "PASS"
        'dr("AllPassed") = AllPass
        'dr("ChangedBy") = User
        'dsWIP.Tables("WIPHeader").Rows.Add(dr)
        'dtAttributes = e.Result.Tables(3)
        'AddPCBATable(dsWIP)
        'Dim myDataRow As DataRow
        'For Each drPCBA As DataRow In dtAttributes.Rows
        '    myDataRow = dsWIP.Tables("PCBAList").NewRow()
        '    myDataRow("SubPCBA") = drPCBA("SubPCBA")
        '    dsWIP.Tables("PCBAList").Rows.Add(myDataRow)
        'Next

        'dgvPCBA.DataSource = dsWIP
        'dgvPCBA.DataMember = "PCBAList"

        'txtSubPCBASerialNo.Focus()

        'Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)

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
            Me.ShowMessage(ex.Message + "  " + txtPCBASerialNo.Text, eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
        End Try
    End Sub

    Private Sub bgwPost_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPost.RunWorkerCompleted
        Try
            pnlBody.Enabled = True
            If e.Result = "^TDC-155@" Then   'Matching successful.
                txtProdQty.Text = BLL.GetDJMatchedQty(txtPONo.Text, txtPCBANo.Text, BLL.LoginData.OrgCode)
                Me.ShowMessage(e.Result + "  " + txtPCBASerialNo.Text, eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
                txtPCBASerialNo.Clear()
                txtPCBASerialNo.Focus()
            Else                          ' Matching failed.
                Me.ShowMessage(e.Result + "  " + txtPCBASerialNo.Text, eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
                'txtPCBASerialNo.Clear()
                'txtPCBASerialNo.Focus()
                txtSubPCBASerialNo.Text = ""
                txtPCBASerialNo.Text = ""
                txtPCBASerialNo.SelectAll()
                txtPCBASerialNo.Focus()
            End If
            grpDataInput.Enabled = True
            txtSubPCBASerialNo.Clear()
            dtResultList.Clear()
            dsWIP.Clear()
            txtModelNo.Text = ""
            txtPCBANo.Text = ""
            txtPONo.Text = ""
        Catch ex As Exception
            BLL.ErrorLogging("MatchingN-bgwPost_RunWorkerCompleted", User, ex.Message)
            Me.ShowMessage(ex.Message + "  " + txtPCBASerialNo.Text, eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
        End Try
    End Sub
    Dim SubPCBANo As String
    Private Sub txtSubPCBASerialNo_ValidateData() Handles txtSubPCBASerialNo.ValidateData
        Try
            If txtPCBASerialNo.Text = "" Then
                Exit Sub
            End If
            Dim DRsubPCBA() As DataRow
            DRsubPCBA = dsWIP.Tables("PCBAList").Select("PCBASerialNo = '" & txtSubPCBASerialNo.Text & "'")
            If DRsubPCBA.Length <> 0 Then  'the subPCBA exists in pcba list.
                Me.ShowMessage("ERROR: " & txtSubPCBASerialNo.Text & " ^TDC-158@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                'If txtSubPCBASerialNo.Text = txtPCBASerialNo.Text Then
                '    txtSubPCBASerialNo.Text = ""
                '    txtPCBASerialNo.SelectAll()
                '    txtPCBASerialNo.Focus()
                'Else
                '    txtSubPCBASerialNo.SelectAll()
                '    txtSubPCBASerialNo.Focus()
                'End If
                txtSubPCBASerialNo.Text = ""
                txtPCBASerialNo.Text = ""
                txtPCBASerialNo.SelectAll()
                txtPCBASerialNo.Focus()
                Return
            End If
            SubPCBANo = BLL.getPCBAinWIPHeader(txtSubPCBASerialNo.Text)
            If SubPCBANo = "^TDC-5@" Then  'does not exist.
                Me.ShowMessage("ERROR: " & txtSubPCBASerialNo.Text & " ^TDC-5@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                'If txtSubPCBASerialNo.Text = txtPCBASerialNo.Text Then
                '    txtSubPCBASerialNo.Text = ""
                '    txtPCBASerialNo.SelectAll()
                '    txtPCBASerialNo.Focus()
                'Else
                '    txtSubPCBASerialNo.SelectAll()
                '    txtSubPCBASerialNo.Focus()
                'End If
                txtSubPCBASerialNo.Text = ""
                txtPCBASerialNo.Text = ""
                txtPCBASerialNo.SelectAll()
                txtPCBASerialNo.Focus()
                Return
            End If

            DRsubPCBA = dsWIP.Tables("PCBAList").Select("SubPCBA ='" & SubPCBANo & "'")
            If DRsubPCBA.Length = 0 Then  '^TDC-9@    'does not defined in the PCBA!     Sub PCBA not in the list
                Me.ShowMessage("ERROR: " & txtSubPCBASerialNo.Text & " ^TDC-9@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                'txtSubPCBASerialNo.SelectAll()
                'txtSubPCBASerialNo.Focus()
                txtSubPCBASerialNo.Text = ""
                txtPCBASerialNo.Text = ""
                txtPCBASerialNo.SelectAll()
                txtPCBASerialNo.Focus()
                Return
            End If
            Me.ShowMessage("^TDC-24@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
            txtSubPCBASerialNo.Modified = False
            pnlBody.Enabled = False
            Me.bgwSubPCBA.RunWorkerAsync()
        Catch ex As Exception
            BLL.ErrorLogging("MatchingN-txtSubPCBASerialNo_ValidateData", User, ex.Message)
        End Try
    End Sub

    Private Sub bgwSubPCBA_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwSubPCBA.DoWork
        Try
            e.Result = BLL.DBoardIsValid(txtSubPCBASerialNo.Text)
        Catch ex As Exception
            BLL.ErrorLogging("MatchingN-bgwSubPCBA_DoWork", User, ex.Message)
        End Try
    End Sub

    Private Sub bgwSubPCBA_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwSubPCBA.RunWorkerCompleted
        pnlBody.Enabled = True
        If Microsoft.VisualBasic.Left(e.Result, 5).ToUpper <> "WIPID" Then
            '^TDC-13@'  Failed process found!      
            '^TDC-157@' has been binded to another PCBA   
            Me.ShowMessage("ERROR: " & txtSubPCBASerialNo.Text & " " & e.Result, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            'Me.ShowMessage(Microsoft.VisualBasic.Mid(e.Result, 7), eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            'txtSubPCBASerialNo.SelectAll()
            'txtSubPCBASerialNo.Focus()
            txtSubPCBASerialNo.Text = ""
            txtPCBASerialNo.Text = ""
            txtPCBASerialNo.SelectAll()
            txtPCBASerialNo.Focus()
        Else

            If dsWIP.Tables("PCBAList").Select("SubPCBA='" & SubPCBANo & "' and (PCBASerialNo = '' or PCBASerialNo is null ) ").Length = 0 Then
                Me.ShowMessage("ERROR: " & txtSubPCBASerialNo.Text & " " & "'^SFC-1@'", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                'txtSubPCBASerialNo.SelectAll()
                'txtSubPCBASerialNo.Focus()
                txtSubPCBASerialNo.Text = ""
                txtPCBASerialNo.Text = ""
                txtPCBASerialNo.SelectAll()
                txtPCBASerialNo.Focus()
                Exit Sub
            End If
            For Each tmpRow In dsWIP.Tables("PCBAList").Rows
                If tmpRow(0) = SubPCBANo Then
                    If FixNull(tmpRow("PCBASerialNo")) = "" Then    ' only fill up blank 'sub pcba' column
                        tmpRow("PCBASerialNo") = txtSubPCBASerialNo.Text
                        tmpRow("PCBAResult") = "PASS"
                        tmpRow("PCBAWipID") = Mid(e.Result, 7)
                        Exit For
                    End If
                End If
            Next
            dsWIP.Tables("PCBAList").AcceptChanges()

            Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            'Check if all Sub PCBAs have been filled, if yes, txtSubPCBASerialNo is no more required
            'If not, then clear the input and focus on txtSubPCBASerialNo
            If SubPCBAInput(dsWIP.Tables("PCBAList")) = True Then
                'txtSubPCBASerialNo.Required = False
                txtSubPCBASerialNo.Modified = False
                'Auto complete the "save" process
                SaveResult()
            Else
                txtSubPCBASerialNo.Clear()
                txtSubPCBASerialNo.Focus()
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
        txtPCBASerialNo.Text = ""
        txtPCBASerialNo.Focus()

        Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        Me.DisableValidation = False
        btnEMI.Visible = False
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        ClearDataInput()
    End Sub

    Private Sub frmDetach_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Try
            SerialPort1.Open()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmDetach_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
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
        If txtPCBASerialNo.Focused Then
            txtPCBASerialNo.Text = ReceivedText
            txtPCBASerialNo.Modified = True
            My.Computer.Keyboard.SendKeys("{TAB}")
        ElseIf txtSubPCBASerialNo.Focused Then
            txtSubPCBASerialNo.Text = ReceivedText
            txtSubPCBASerialNo.Modified = True
            My.Computer.Keyboard.SendKeys("{TAB}")
        End If
        flgBusy = False
    End Sub

    Private Sub btnEMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

    Private Sub txtProcess_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtProcess.Text = txtProcess.Text.Trim
        If txtProcess.Text = "" Then Exit Sub
        CurrProcess = txtProcess.Text
        txtProcess.Enabled = False
        txtPCBASerialNo.Focus()
    End Sub
End Class
