Public Class frmIDSwop
    Public ProcessID As Integer
    Public CurrProcess As String
    Dim User As String
    Dim record As DataTable
    Dim AllPass As Boolean
    Dim dsWIP As DataSet
    Dim dtResultList As DataTable
    Dim dtPatternInfo As DataTable
    Dim Emifile As Object
    Private _panelResult As DataSet
    Private flgBusy As Boolean = False
    Private Delegate Sub UpdateUI(ByVal ReceivedData As String)
    Dim SFC004 As String
    Dim SFC009 As Integer

    Private ReadOnly Property IsInputPanel As Boolean
        Get
            If Mid(txtIntSerial.Text, 1, 1).ToUpper = "P" Then
                If _panelResult IsNot Nothing Then
                    If _panelResult.Tables.Count > 0 And _panelResult.Tables(0).Rows.Count > 0 Then
                        Return True
                    End If
                End If
            End If
            Return False
        End Get
    End Property
    Public Overrides Sub NewSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'New Instance of the form
        Dim NewInstance As New frmMain()
        NewInstance.ShowFrm(Me)
    End Sub

    Private Sub frmIDSwop_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'AttachHotkey(btnPost, Keys.F8)
        'AttachHotkey(btnNew, Keys.F5)
        'AttachHotkey(btnReset, Keys.F3)
        'AttachHotkey(btnPrint, Keys.F9)
        ProcessID = SelectProcessID
        CurrProcess = SelectProcess
        BindCtlsToProcess(Me, ProcessID)
        SFC004 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC004'")(0)("Value"))
        SFC009 = Convert.ToInt32(BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC009'")(0)("Value")))
        If SFC004.ToUpper = "NO" Then
            txtIntSerial.KeyIn = False
            txtExtSerial.KeyIn = False
        Else
            txtIntSerial.KeyIn = True
            txtExtSerial.KeyIn = True
        End If
        Me.ShowMessage(ProcessShow, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
    End Sub

    Private Sub frmIDSwop_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        ddlProcess.Text = ProcessShow
        Me.CenterToScreen()
        User = Mid(UserName.Text, 1, InStr(UserName.Text, "-") - 1).Trim
        BLL.LoginData.User = User
        BLL.LoginData.OrgCode = Mid(MyOrg(), 1, 3)
        BLL.LoginData.ProductionLine = ProductionLine()
        txtIntSerial.Focus()
        'txtPONo.Focus()
    End Sub

    Private Sub txtIntSerial_ValidateData() Handles txtIntSerial.ValidateData
        txtIntSerial.Text = Trim(txtIntSerial.Text)
        'If txtIntSerial.Text.Length < SFC009 Then
        '    Me.ShowMessage("^SFC-175@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        '    txtIntSerial.SelectAll()
        '    txtIntSerial.Focus()
        '    Exit Sub
        'End If
        'If Mid(txtIntSerial.Text, 1, 1).ToUpper = "P" Then
        '    chkAddlData.Checked = True
        'End If
        'If Mid(txtIntSerial.Text, 1, 4) = "CNTR" And txtIntSerial.Text.Contains("-") Then
        '    chkAddlData.Checked = True
        'End If
        Me.ShowMessage("^TDC-24@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
        pnlBody.Enabled = False
        Me.bgwIntSerial.RunWorkerAsync()
    End Sub

    Private Sub bgwIntSerial_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwIntSerial.DoWork
        'Try
        'If Mid(txtIntSerial.Text, 1, 1).ToUpper = "P" Then
        '    e.Result = BLL.PCBListReadByPanelID(txtIntSerial.Text)
        'Else
        e.Result = BLL.GetResultAndPCBAList(txtIntSerial.Text, CurrProcess)
            'End If
        'Catch ex As Exception
        '    BLL.ErrorLogging("SFCMatchingN-bgwIntSerial_DoWork", User, ex.Message)
        '    Me.ShowMessage("ERROR: " & ex.Message, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        'End Try
    End Sub

    Private Sub bgwIntSerial_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwIntSerial.RunWorkerCompleted
        If e.Error Is Nothing Then
            pnlBody.Enabled = True

            'If Mid(txtIntSerial.Text, 1, 1).ToUpper = "P" Then
            '    If e.Result.Tables(0).Rows.Count = 0 Then
            '        Me.ShowMessage("^121-15@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            '        pnlBody.Enabled = True
            '        txtIntSerial.SelectAll()
            '        txtIntSerial.Focus()
            '        Return
            '    Else
            '        record = BLL.GetDataByIntSN(e.Result.Tables(0).Rows(0)("IntSN")).Tables(0)
            '        txtPONo.Text = record.Rows(0)("DJ")
            '        txtModelNo.Text = record.Rows(0)("Model")
            '        txtPCBANo.Text = record.Rows(0)("PCBA")
            '        dtResultList = BLL.GetResultList(e.Result.Tables(0).Rows(0)("IntSN"))
            '        dtResultList.Columns.Remove("Model")
            '        dtResultList.Columns.Remove("PCBA")
            '        dgvResult.DataSource = dtResultList
            '        dgvResult.Visible = True
            '    End If
            'Else '<>'P'
            If e.Result.Tables(0).rows(0)("ErrMsg") <> "" Then
                ''user input a Panel ID
                If e.Result.Tables(0).rows(0)("ErrMsg") = "^TDC-23@" And Mid(txtIntSerial.Text, 1, 1).ToUpper = "P" Then
                    _panelResult = BLL.PCBListReadByPanelID(txtIntSerial.Text)
                    If _panelResult.Tables(0).Rows.Count = 0 Then
                        Me.ShowMessage("^121-15@",
                                       eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                                       AnimationStatus.StopAnim,
                                       True,
                                       PopUpTypes.Message,,
                                       GetReportLink(txtIntSerial.Text))
                        pnlBody.Enabled = True
                        txtIntSerial.SelectAll()
                        txtIntSerial.Focus()
                        Return
                    Else
                        record = BLL.GetDataByIntSN(_panelResult.Tables(0).Rows(0)("IntSN")).Tables(0)
                        txtPONo.Text = record.Rows(0)("DJ")
                        txtModelNo.Text = record.Rows(0)("Model")
                        txtPCBANo.Text = record.Rows(0)("PCBA")
                        dtResultList = BLL.GetResultList(_panelResult.Tables(0).Rows(0)("IntSN"))
                        dtResultList.Columns.Remove("Model")
                        dtResultList.Columns.Remove("PCBA")
                        dgvResult.DataSource = dtResultList
                        dgvResult.Visible = True
                    End If
                Else
                    Me.ShowMessage("ERROR: " & txtIntSerial.Text & " ^TDC-5@",
                                   eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                                   AnimationStatus.StopAnim,
                                   True,
                                   PopUpTypes.Message,
                                   ,
                                   reportLink:=GetReportLink(txtIntSerial.Text))
                    txtIntSerial.SelectAll()
                    txtIntSerial.Focus()
                    Return
                End If
            Else
                ''user input a intSn
                AllPass = False
                Dim FlowSeqNo As Integer = 0
                txtModelNo.Text = e.Result.Tables(1).rows(0)("Model").ToString
                txtPCBANo.Text = e.Result.Tables(1).rows(0)("PCBA").ToString
                txtPONo.Text = e.Result.Tables(1).rows(0)("DJ").ToString
                dtResultList = e.Result.Tables(2)
                dtPatternInfo = e.Result.Tables(3)
                dgvResult.DataSource = dtResultList
                If Not chkAddlData.Checked Then
                    If e.Result.Tables(1).rows(0)("CurrentProcess").ToString = "Repair" And e.Result.Tables(1).rows(0)("Result").ToString <> "Fixed" Then
                        Me.ShowMessage("^SFC-66@",
                                       eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                                       AnimationStatus.StopAnim,
                                       True,
                                       PopUpTypes.Message,,
                                       GetReportLink(txtIntSerial.Text))
                        txtIntSerial.SelectAll()
                        txtIntSerial.Focus()
                        Return
                    End If

                    Dim HasProc As Integer = 0
                    HasProc = dtResultList.Select("Process='" & CurrProcess & "'").Length
                    If HasProc = 0 Then
                        Me.ShowMessage("ERROR: " & CurrProcess & " " & "^SFC-7@",
                                       eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                                       AnimationStatus.StopAnim,
                                       True,
                                       PopUpTypes.Message,,
                                       GetReportLink(txtIntSerial.Text))
                        txtIntSerial.SelectAll()
                        txtIntSerial.Focus()
                        Return
                    End If

                    Dim iRows As Integer
                    iRows = dtResultList.Rows.Count
                    Dim i As Integer
                    Dim ErrFound As Boolean = False
                    For i = 0 To iRows - 1
                        If ErrFound = True Then
                            Me.ShowMessage("^TDC-13@",
                                           eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                                           AnimationStatus.StopAnim,
                                           True,
                                           PopUpTypes.Message,,
                                           GetReportLink(txtIntSerial.Text))
                            txtIntSerial.SelectAll()
                            txtIntSerial.Focus()
                            Return
                        End If

                        If dtResultList.Rows(i)(0).ToString.Trim.ToUpper = CurrProcess.ToUpper Then   'For current process, fill in "pass" here
                            If dtResultList.Rows(i)(1) = "PASS" Or dtResultList.Rows(i)(1) = "SKIP" Then
                                Me.ShowMessage("^SFC-2@",
                                               eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                                               AnimationStatus.StopAnim,
                                               True, PopUpTypes.Message,,
                                               GetReportLink(txtIntSerial.Text))
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
                dr("InvOrg") = BLL.LoginData.OrgCode
                dr("ProdLine") = BLL.LoginData.ProductionLine
                dr("CurrentProcess") = CurrProcess
                dr("FlowSeqNo") = FlowSeqNo
                dr("Result") = "PASS"
                dr("AllPassed") = AllPass
                dr("ChangedBy") = User
                dsWIP.Tables("WIPHeader").Rows.Add(dr)
            End If


            'End If
            txtExtSerial.Focus()
            Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        Else
            If e.Error.GetType() Is GetType(System.Net.WebException) Then
                Me.ShowMessage("^SFC-169@",
                               eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                               AnimationStatus.StopAnim,
                               True,
                               PopUpTypes.Message,,
                               GetReportLink(txtIntSerial.Text))
                pnlBody.Enabled = True
            Else
                Me.ShowMessage("ERROR: " & e.Error.Message, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                pnlBody.Enabled = True
            End If
        End If


    End Sub
    Dim OTray() As String
    Dim CTray() As String
    Private Sub txtExtSerial_ValidateData() Handles txtExtSerial.ValidateData
        txtExtSerial.Text = Trim(txtExtSerial.Text)
        If txtExtSerial.Text = "" Then Exit Sub
        If txtIntSerial.Text = "" Then
            txtIntSerial.Focus()
            txtExtSerial.Text = ""
            Exit Sub
        End If
        If txtExtSerial.Text.Length < SFC009 Then
            Me.ShowMessage("^SFC-175@",
                           eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                           AnimationStatus.StopAnim,
                           True,
                           PopUpTypes.Message,,
                           GetReportLink(txtExtSerial.Text))
            txtExtSerial.SelectAll()
            txtExtSerial.Focus()
            Exit Sub
        End If
        If IsInputPanel Then
            If Mid(txtExtSerial.Text, 1, 1).ToUpper <> "P" Then
                Me.ShowMessage("^121-3@",
                               eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                               AnimationStatus.StopAnim,
                               True,
                               PopUpTypes.Message,,
                               GetReportLink(txtExtSerial.Text))
                txtExtSerial.SelectAll()
                txtExtSerial.Focus()
                Exit Sub
            End If
        End If
        'If Mid(txtIntSerial.Text, 1, 1).ToUpper = "B" Then
        '    If Mid(txtExtSerial.Text, 1, 1).ToUpper <> "B" Then
        '        Me.ShowMessage("ERROR: " & "^121-4@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        '        txtExtSerial.SelectAll()
        '        txtExtSerial.Focus()
        '        Exit Sub
        '    End If
        'End If

        If Mid(txtIntSerial.Text, 1, 4) = "CNTR" Then
            If Mid(txtExtSerial.Text, 1, 4).ToUpper <> "CNTR" Then
                Me.ShowMessage("ERROR: " & "^121-4@",
                               eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                               AnimationStatus.StopAnim,
                               True,
                               PopUpTypes.Message,,
                               GetReportLink(txtExtSerial.Text))
                txtExtSerial.SelectAll()
                txtExtSerial.Focus()
                Exit Sub
            End If
            If txtIntSerial.Text.Contains("-") Then

                OTray = Split(txtIntSerial.Text, "-")
                CTray = Split(txtExtSerial.Text, "-")
                If Me.ShowMessage("^121-77@ " & CTray(0) & " ?",
                                  eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                                  AnimationStatus.StopAnim,
                                  True,
                                  PopUpTypes.Question) <> True Then
                    txtExtSerial.SelectAll()
                    txtExtSerial.Focus()
                    Exit Sub
                End If
            End If
        End If


        ''IF select UseExtSN in Product Master,check SerialNoPattern
        If Not chkAddlData.Checked Then
            Dim IsUseExtSN As Boolean = (dtPatternInfo.Rows(0)("UseExtSN").ToString() = "True")
            If IsUseExtSN Then
                Dim IsSerialNoPatternPass As Boolean = False
                For i As Integer = 0 To dtPatternInfo.Rows.Count - 1
                    Dim SerialNoPattern As String = dtPatternInfo.Rows(i)("SerialNoPattern").ToString()
                    If BLL.AlphanumericValidation(txtExtSerial.Text, SerialNoPattern) Then
                        IsSerialNoPatternPass = True
                        Exit For
                    End If
                Next
                If Not IsSerialNoPatternPass Then
                    Me.ShowMessage("^SFC-166@",
                                   eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                                   AnimationStatus.StopAnim,
                                   True, PopUpTypes.Message,,
                                   GetReportLink(txtExtSerial.Text))
                    txtExtSerial.Focus()
                    txtExtSerial.SelectAll()
                    Exit Sub
                End If
            End If
        End If

        If Trim(txtExtSerial.Text) <> "" And txtExtSerial.Modified Then
            Dim SNValid As String
            'SNValid = BLL.IntSNIsValid(txtExtSerial.Text)

            If IsInputPanel Then
                SNValid = BLL.PanelIDIsValid(txtExtSerial.Text)
                If SNValid = "^121-7@" Then
                    Me.ShowMessage("^121-7@",
                                   eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                                   AnimationStatus.StopAnim,
                                   True,
                                   PopUpTypes.Message)
                    txtExtSerial.SelectAll()
                    txtExtSerial.Focus()
                    Exit Sub
                End If
            Else
                If Mid(txtIntSerial.Text, 1, 4) = "CNTR" And txtIntSerial.Text.Contains("-") Then
                    SNValid = BLL.PanelIDIsValid(CTray(0))
                    If SNValid = "^121-7@" Then
                        Me.ShowMessage("^121-7@",
                                       eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                                       AnimationStatus.StopAnim,
                                       True,
                                       PopUpTypes.Message,, GetReportLink(txtExtSerial.Text))
                        txtExtSerial.SelectAll()
                        txtExtSerial.Focus()
                        Exit Sub
                    End If
                Else
                    SNValid = BLL.IntSNIsValid(txtExtSerial.Text)    'Validate if ID is already in use
                    If SNValid <> "0" Then
                        Me.ShowMessage(SNValid,
                                       eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                                       AnimationStatus.StopAnim,
                                       True,
                                       PopUpTypes.Message,,
                                       GetReportLink(txtExtSerial.Text))
                        txtExtSerial.SelectAll()
                        txtExtSerial.Focus()
                        Exit Sub
                    End If
                End If
            End If
            pnlBody.Enabled = False
            RaveResult()
        End If
    End Sub

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
        If txtExtSerial.Text = "" Then
            Exit Sub
        End If

        If IsInputPanel Then
            Me.ShowMessage("^TDC-59@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
        Else
            If Mid(txtIntSerial.Text, 1, 4) = "CNTR" And txtIntSerial.Text.Contains("-") Then
                Me.ShowMessage("^TDC-59@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
            Else
                dsWIP.Tables("SwopSN").Clear()
                Dim drSwopSN As DataRow
                drSwopSN = dsWIP.Tables("SwopSN").NewRow
                drSwopSN("SN") = txtExtSerial.Text
                If chkAddlData.Checked Then
                    drSwopSN("isForce") = "Y"
                Else
                    drSwopSN("isForce") = "N"
                End If
                dsWIP.Tables("SwopSN").Rows.Add(drSwopSN)
                dsWIP.Tables("SwopSN").AcceptChanges()
                Me.ShowMessage("^TDC-59@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
            End If
        End If

        bgwPost.RunWorkerAsync()
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        RaveResult()
    End Sub


    Private Sub bgwPost_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwPost.DoWork
        With BLL.StatusHeader
            .IntSerial = txtIntSerial.Text
            .ExtSerial = txtExtSerial.Text
            .Process = CurrProcess
            .OperatorName = User
        End With
        If IsInputPanel Then
            e.Result = BLL.PanelIDSwop(BLL.StatusHeader)
        Else
            If Mid(txtIntSerial.Text, 1, 4) = "CNTR" And txtIntSerial.Text.Contains("-") Then
                e.Result = BLL.TrayIDSwop(OTray(0), CTray(0), User)
            Else
                e.Result = BLL.WIPIDSwop(dsWIP)
            End If
        End If
        'Try
        '    e.Result = BLL.WIPIDSwop(dsWIP)
        'Catch ex As Exception
        '    Me.ShowMessage("ERROR: " & ex.Message, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        'End Try
    End Sub

    Private Sub bgwPost_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPost.RunWorkerCompleted
        Try
            If e.Error Is Nothing Then
                If IsInputPanel Then
                    If Microsoft.VisualBasic.Left(e.Result, 5) = "ERROR" Then
                        Me.ShowMessage(Microsoft.VisualBasic.Mid(e.Result, 7), eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                        grpDataInput.Enabled = True
                        btnPost.Enabled = True
                        txtIntSerial.SelectAll()
                        txtIntSerial.Focus()
                        txtExtSerial.Text = ""
                        _panelResult = Nothing
                    Else
                        Me.ShowMessage(e.Result, eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
                        pnlBody.Enabled = True
                        ClearDataInput()
                        txtIntSerial.Focus()
                        txtExtSerial.Text = ""
                        _panelResult = Nothing
                    End If
                Else
                    If Mid(txtIntSerial.Text, 1, 4) = "CNTR" And txtIntSerial.Text.Contains("-") Then
                        If Microsoft.VisualBasic.Left(e.Result, 5) = "ERROR" Then
                            Me.ShowMessage(Microsoft.VisualBasic.Mid(e.Result, 7), eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                            grpDataInput.Enabled = True
                            btnPost.Enabled = True
                            txtIntSerial.SelectAll()
                            txtIntSerial.Focus()
                            txtExtSerial.Text = ""
                            _panelResult = Nothing
                        Else
                            Me.ShowMessage(e.Result, eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
                            pnlBody.Enabled = True
                            ClearDataInput()
                            txtIntSerial.Focus()
                            txtExtSerial.Text = ""
                            _panelResult = Nothing
                        End If
                    Else
                        If e.Result = "^TDC-60@" Then
                            Me.ShowMessage("^TDC-60@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
                            pnlBody.Enabled = True
                            ClearDataInput()
                            txtIntSerial.Focus()
                        Else
                            Me.ShowMessage(e.Result, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                            pnlBody.Enabled = True
                            grpDataInput.Enabled = True
                            btnPost.Enabled = True
                            txtIntSerial.SelectAll()
                            txtIntSerial.Focus()
                            txtExtSerial.Text = ""
                            _panelResult = Nothing
                        End If
                    End If
                End If
            Else
                If e.Error.GetType() Is GetType(System.Net.WebException) Then
                    Me.ShowMessage("^SFC-169@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    pnlBody.Enabled = True
                Else


                    Me.ShowMessage("ERROR: " & e.Error.Message, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    pnlBody.Enabled = True
                End If

            End If


        Catch ex As Exception
            Me.ShowMessage("ERROR: " & ex.Message, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            pnlBody.Enabled = True
        Finally
        End Try

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
        txtExtSerial.Text = ""
        _panelResult = Nothing
        txtIntSerial.Text = ""
        txtIntSerial.Focus()
        DisableValidation = False
        txtPONo.Text = ""
        txtModelNo.Text = ""
        txtPCBANo.Text = ""
        'chkAddlData.Checked = False
        dtResultList.Clear()
        'dgvResult.DataSource = Nothing
        btnEMI.Visible = False

    End Sub

    Private Sub frmIDSwop_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Try
            SerialPort1.Open()
        Catch ex As Exception
            'Me.ShowMessage("ERROR: " & ex.Message, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        End Try
    End Sub

    Private Sub frmIDSwop_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Try
            SerialPort1.Close()
        Catch ex As Exception
            'Me.ShowMessage("ERROR: " & ex.Message, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
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

        Dim SwopSN As DataTable = New Data.DataTable("SwopSN")
        SwopSN.Columns.Add(New Data.DataColumn("SN", System.Type.GetType("System.String")))
        SwopSN.Columns.Add(New Data.DataColumn("isForce", System.Type.GetType("System.String")))
        DS.Tables.Add(SwopSN)

        Return DS
    End Function
End Class
