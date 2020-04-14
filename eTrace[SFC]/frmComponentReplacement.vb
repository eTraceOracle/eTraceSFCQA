Public Class frmComponentReplacement
    Public ProcessID As Integer
    Public CurrProcess As String
    Public user As String
    Private flgBusy As Boolean = False
    Private Emifile As Object
    Dim dsResult As DataSet
    Dim dsTLAandPCBA As DataSet
    Dim dtTLA As DataTable
    Dim dtPCBA As DataTable
    Dim dtRep As DataTable
    Dim dtOtherInfo As DataTable
    Dim MatListID As String
    Dim ReworkFlg As String
    Dim IsBottom As String
    Dim ContinueList As String = "N"
    Private Delegate Sub UpdateUI(ByVal ReceivedData As String)
    Public Overrides Sub NewSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'New Instance of the form
        Dim NewInstance As New frmMain()
        NewInstance.ShowFrm(Me)
    End Sub

    Private Sub frmComponentReplacement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AttachHotkey(btnPost, Keys.F8)
        AttachHotkey(btnNew, Keys.F5)
        AttachHotkey(btnReset, Keys.F3)
        AttachHotkey(btnPrint, Keys.F9)
        ProcessID = SelectProcessID
        CurrProcess = SelectProcess
        BindCtlsToProcess(Me, ProcessID)
        AddOtherColumn()
        AddRepColumn()
        Me.ShowMessage(ProcessShow, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
    End Sub

    Private Sub frmComponentReplacement_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        ddlProcess.Text = ProcessShow
        Me.CenterToScreen()
        user = Mid(UserName.Text, 1, InStr(UserName.Text, "-") - 1).Trim
        BLL.LoginData.User = user
        BLL.LoginData.OrgCode = MyOrg()
        BLL.LoginData.ProductionLine = ProductionLine()
        dgvCR.DataSource = dtRep
        dgvCR.Columns("WIPID").Visible = False
        dgvCR.Columns("NewWIPID").Visible = False
        txtIntSerial.Focus()
    End Sub


    Private Sub txtIntSerial_ValidateData() Handles txtIntSerial.ValidateData
        txtIntSerial.Text = Trim(txtIntSerial.Text)
        If Trim(txtIntSerial.Text) <> "" And txtIntSerial.Modified Then
            Me.ShowMessage("^TDC-24@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
            pnlBody.Enabled = False
            Me.bgwIntSerial.RunWorkerAsync()
        End If
    End Sub

    Private Sub bgwIntSerial_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwIntSerial.DoWork
        Try
            e.Result = BLL.IntSNIsValid(txtIntSerial.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub bgwIntSerial_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwIntSerial.RunWorkerCompleted
        pnlBody.Enabled = True
        If e.Result <> "^TDC-6@" Then
            Me.ShowMessage("^TDC-23@" + ": " + txtIntSerial.Text, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
        ElseIf e.Result = "^TDC-6@" Then
            If Not chkAddlData.Checked Then
                IntValid(txtIntSerial.Text)
                If IntIsValid <> "" Then
                    Me.ShowMessage(IntIsValid & " " & txtIntSerial.Text, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtIntSerial.SelectAll()
                    txtIntSerial.Focus()
                    Exit Sub
                End If
            End If
            dsTLAandPCBA = New DataSet
            dtTLA = New DataTable
            dtPCBA = New DataTable
            dsTLAandPCBA = BLL.GetDataByIntSN(txtIntSerial.Text)
            dtTLA = dsTLAandPCBA.Tables(0)
            txtPONo.Text = dtTLA.Rows(0)("DJ")

            If txtModelNo.Text <> dtTLA.Rows(0)("Model") Then
                txtModelNo.Text = dtTLA.Rows(0)("Model")
                ContinueList = "N"
            Else
                ContinueList = "Y"
            End If

            If dtTLA.Rows(0)("MotherBoardSN").ToString <> "" Then
                Me.ShowMessage("^SFC-112@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtIntSerial.SelectAll()
                txtIntSerial.Focus()
                Exit Sub
            End If
            If dtTLA.Rows(0)("CurrentProcess").ToString = "Rework" Then
                ReworkFlg = "Y"
            Else
                ReworkFlg = BLL.IsReworkUnit(dtTLA.Rows(0)("WIPID").ToString)
            End If
            'If ReworkFlg = "Y" Then
            '    dsMatList = BLL.MatListOnPCBA(dtTLA.Rows(0)("WIPID").ToString)
            '    If dsMatList.Tables(0).Rows.Count = 0 Then
            '        Me.ShowMessage("^121-50@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            '        txtIntSerial.SelectAll()
            '        txtIntSerial.Focus()
            '        Exit Sub
            '    End If
            '    Dim strPCBID As String = ""
            '    Dim strPCB As String = ""
            '    splitCC(dsMatList.Tables(0))
            '    txtPCBID.ItemDataTable = dsMatList.Tables(0)
            '    txtPCBID.setItems()
            '    'txtPCBID.Items.Clear()
            '    'For Each dr As DataRow In dsMatList.Tables(0).Rows
            '    '    If strPCBID <> dr("IntSN").ToString And strPCB <> dr("PCBA").ToString Then
            '    '        txtPCBID.Items.Add(dr("IntSN").ToString)
            '    '        strPCBID = dr("IntSN").ToString
            '    '        strPCB = dr("PCBA").ToString
            '    '    End If
            '    'Next
            '    If txtPCBID.Items.Count = 1 Then
            '        'txtCC.Items.Clear()
            '        'For Each dr As DataRow In dsMatList.Tables(0).Rows
            '        '    txtCC.Items.Add(dr("CircuitCode").ToString)
            '        'Next
            '        txtCC.ItemDataTable = dsMatList.Tables(0)
            '        txtCC.setItems()
            '        txtCC.Focus()
            '    Else
            '        txtPCBID.Focus()
            '    End If
            'Else
            '    dtPCBA = dsTLAandPCBA.Tables(1)
            '    If dtPCBA.Rows.Count = 1 Then
            '        'txtPCBID.Items.Clear()
            '        txtPCBID.Text = txtIntSerial.Text
            '        'txtPCBID.Items.Add(txtIntSerial.Text)
            '        txtPCBID.ItemDataTable = dtPCBA
            '        txtPCBID.setItems()
            '        MatListID = dtPCBA.Rows(0)("WIPID").ToString
            '        txtPCBID.Enabled = False
            '        addCC(MatListID)
            '        txtCC.Focus()
            '    Else
            '        'txtPCBID.Items.Clear()
            '        'For Each dr As DataRow In dtPCBA.Rows
            '        '    txtPCBID.Items.Add(dr("IntSN").ToString)
            '        'Next
            '        txtPCBID.Enabled = True
            '        txtPCBID.ItemDataTable = dtPCBA
            '        txtPCBID.setItems()
            '        txtPCBID.Focus()
            '    End If
            'End If

            If ReworkFlg = "Y" Then
                dtPCBA = BLL.PCBListOfRework(dtTLA.Rows(0)("WIPID").ToString).Tables(0)
            Else
                dtPCBA = dsTLAandPCBA.Tables(1)
            End If

            If dtPCBA.Rows.Count = 1 Then
                txtPCBID.Text = txtIntSerial.Text
                txtPCBID.ItemDataTable = dtPCBA
                txtPCBID.setItems()
                MatListID = dtPCBA.Rows(0)("WIPID").ToString
                txtPCBID.Enabled = False
                addCC(MatListID)
                txtCC.Focus()
            Else
                txtPCBID.Enabled = True
                txtPCBID.ItemDataTable = dtPCBA
                txtPCBID.setItems()
                txtPCBID.Focus()
            End If

            If ContinueList = "Y" Then
                ContinuedataInput()
            Else
                dtRep.Clear()
            End If

            'txtPCBANo.Text = dtTLA.Rows(0)("PCBA")
            'Emifile = BLL.getMIFileData(txtModelNo.Text.Trim, txtPCBANo.Text.Trim, CurrProcess)
            'If (Not Emifile Is Nothing) Then
            '    btnEMI.Visible = True
            'End If
            dgvCR.Visible = True
            Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            'End If
        End If

    End Sub

    Dim IntIsValid As String = ""
    Private Sub IntValid(ByVal intSN As String)
        Dim Prevresult As String
        IntIsValid = ""

        Prevresult = BLL.CheckPrevResultNotWipIn(intSN, CurrProcess, user)
        If Prevresult <> "PASS" Then
            IntIsValid = Prevresult
        End If
    End Sub
    Dim dsMatList As DataSet
    Private Sub addCC(ByVal ID As String)
        dsMatList = New DataSet
        dsMatList = BLL.MatListOnPCBA(ID) ' call sp_121MatListOnPCBAbyWIPID
        Dim dtCC As DataTable
        dtCC = splitCC(dsMatList.Tables(0))
        'txtCC.Items.Clear()
        'For Each dr As DataRow In dsMatList.Tables(0).Rows
        '    txtCC.Items.Add(dr("CircuitCode"))
        'Next
        txtCC.ItemDataTable = dtCC
        txtCC.setItems()
        'txtCC.Focus()
    End Sub

    Function splitCC(ByVal dt As DataTable) As DataTable
        Dim drCCwithComma() As DataRow
        drCCwithComma = dt.Select("CircuitCode like '%,%'")
        Dim iCC As Integer
        Dim str As String
        Dim strs() As String
        Dim i As Integer
        Dim drCC As DataRow
        For iCC = 0 To drCCwithComma.Length - 1
            str = drCCwithComma(iCC)("CircuitCode").ToString
            strs = str.Split(",")
            If strs.Length > 1 Then
                For i = 0 To strs.Length - 1
                    drCC = dt.NewRow
                    'WIPID, Model, PCBA, CircuitCode, ProductSN, Process, Component, Qty, CLID, JobID, ChangedOn, ChangedBy, Remarks, IntSN
                    drCC("WIPID") = drCCwithComma(iCC)("WIPID")
                    drCC("Model") = drCCwithComma(iCC)("Model")
                    drCC("PCBA") = drCCwithComma(iCC)("PCBA")
                    drCC("CircuitCode") = strs(i)
                    drCC("ProductSN") = drCCwithComma(iCC)("ProductSN")
                    drCC("Process") = drCCwithComma(iCC)("Process")
                    drCC("Component") = drCCwithComma(iCC)("Component")
                    drCC("Qty") = drCCwithComma(iCC)("Qty")
                    drCC("CLID") = drCCwithComma(iCC)("CLID")
                    drCC("JobID") = drCCwithComma(iCC)("JobID")
                    drCC("ChangedOn") = drCCwithComma(iCC)("ChangedOn")
                    drCC("ChangedBy") = drCCwithComma(iCC)("ChangedBy")
                    drCC("Remarks") = drCCwithComma(iCC)("Remarks")
                    drCC("IntSN") = drCCwithComma(iCC)("IntSN")
                    dt.Rows.Add(drCC)
                Next
                'drCCwithComma(iCC).Delete()
            End If
        Next
        dt.AcceptChanges()
        For iCC = 0 To drCCwithComma.Length - 1
            drCCwithComma(iCC).Delete()
        Next
        dt.AcceptChanges()
        Dim drSort() As DataRow
        drSort = dt.Select(True, "CircuitCode ASC")
        Dim dtCC As DataTable = dt.Clone()
        For Each dr As DataRow In drSort
            drCC = dtCC.NewRow
            'WIPID, Model, PCBA, CircuitCode, ProductSN, Process, Component, Qty, CLID, JobID, ChangedOn, ChangedBy, Remarks, IntSN
            drCC("WIPID") = dr("WIPID")
            drCC("Model") = dr("Model")
            drCC("PCBA") = dr("PCBA")
            drCC("CircuitCode") = dr("CircuitCode")
            drCC("ProductSN") = dr("ProductSN")
            drCC("Process") = dr("Process")
            drCC("Component") = dr("Component")
            drCC("Qty") = dr("Qty")
            drCC("CLID") = dr("CLID")
            drCC("JobID") = dr("JobID")
            drCC("ChangedOn") = dr("ChangedOn")
            drCC("ChangedBy") = dr("ChangedBy")
            drCC("Remarks") = dr("Remarks")
            drCC("IntSN") = dr("IntSN")
            dtCC.Rows.Add(drCC)
        Next
        dtCC.AcceptChanges()
        Return dtCC
    End Function

    Private Sub txtCLID_ValidateData() Handles txtCLID.ValidateData
        Try
            txtCLID.Text = Trim(txtCLID.Text)
            If txtCLID.Text = "" Then Exit Sub
            If txtCLID.Text = txtPCBID.Text Or txtCLID.Text = txtIntSerial.Text Then
                Me.ShowMessage("^TDC-23@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtCLID.Text = ""
                txtCLID.Focus()
                Exit Sub
            End If

            If txtCC.Text <> "" Then
                If ReworkFlg = "Y" Then
                    If dtRep.Select("WIPID='" & MatListID & "' and CircuitCode='" & txtCC.Text & "' and PCBA='" & txtPCBANo.Text & "'").Length <> 0 Then
                        Me.ShowMessage(txtCC.Text & " " & "^SFC-109@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                        txtCLID.Text = ""
                        txtCC.Text = ""
                        txtCC.Focus()
                        Exit Sub
                    End If
                Else
                    If dtRep.Select("WIPID='" & MatListID & "' and CircuitCode='" & txtCC.Text & "'").Length <> 0 Then
                        Me.ShowMessage(txtCC.Text & " " & "^SFC-109@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                        txtCLID.Text = ""
                        txtCC.Text = ""
                        txtCC.Focus()
                        Exit Sub
                    End If
                End If
            Else
                '1. whether the PCBA has daugther board
                IsBottom = BLL.IsBottomPCBA(txtModelNo.Text, txtPCBANo.Text)
                If IsBottom = "N" Then
                    Me.ShowMessage(txtPCBANo.Text & " " & "^121-51@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtCLID.Text = ""
                    txtCLID.Focus()
                    Exit Sub
                End If
                If dtRep.Select("NewCLID='" & txtCLID.Text & "'").Length <> 0 Then
                    Me.ShowMessage(txtCLID.Text & " ^TDC-158@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtCLID.Text = ""
                    txtCLID.Focus()
                    Exit Sub
                End If
            End If
            Me.ShowMessage("^MMC-13@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
            bgwCLID.RunWorkerAsync(txtCC.Text)
        Catch ex As Exception
            Me.ShowMessage(ex.ToString, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        End Try
    End Sub

    Private Sub bgwCLID_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwCLID.DoWork
        If e.Argument = "" Then
            e.Result = BLL.GetDataByIntSN(txtCLID.Text)
        Else
            e.Result = BLL.MaterialInfoReadByCLID(txtCLID.Text)
        End If
    End Sub

    Dim currPN As String
    Private Sub bgwCLID_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwCLID.RunWorkerCompleted
        Try
            Dim drPN() As DataRow
            Dim dr As DataRow
            If txtCC.Text <> "" Then
                If e.Result.Tables(0).rows.count = 0 Then       'does not exist.
                    Me.ShowMessage("ERROR: " & txtCLID.Text & " " & "^TDC-5@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtCLID.SelectAll()
                    txtCLID.Focus()
                    Return
                End If
                If e.Result.Tables(0).rows(0)("StatusCode") <> 0 Then   'Invalid Material Label 
                    Me.ShowMessage("ERROR: " & txtCLID.Text & " " & "^MMC-5@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtCLID.SelectAll()
                    txtCLID.Focus()
                    Return
                End If
                If ReworkFlg = "Y" Then
                    drPN = dsMatList.Tables(0).Select("IntSN='" & txtPCBID.Text & "' and CircuitCode='" & txtCC.Text & "' and PCBA='" & txtPCBANo.Text & "'")
                Else
                    drPN = dsMatList.Tables(0).Select("CircuitCode='" & txtCC.Text & "'")
                End If

                currPN = drPN(0)("Component")
                If e.Result.Tables(0).rows(0)("MaterialNo") <> currPN Then
                    If Me.ShowMessage("^RDC-97@", eTraceUI.eTraceMessageBar.MessageTypes.Warning, AnimationStatus.StopAnim, True, PopUpTypes.Question) = False Then
                        txtCLID.SelectAll()
                        txtCLID.Focus()
                        Return
                    End If
                End If
                dr = dtRep.NewRow
                dr("WIPID") = drPN(0)("WIPID")
                dr("PCBID") = txtPCBID.Text
                dr("PCBA") = drPN(0)("PCBA")
                dr("CircuitCode") = drPN(0)("CircuitCode")
                dr("CurPN") = drPN(0)("Component")
                dr("CurCLID") = drPN(0)("CLID")
                dr("NewItem") = e.Result.Tables(0).rows(0)("MaterialNo")
                dr("NewCLID") = txtCLID.Text
                dr("NewWIPID") = ""
                dtRep.Rows.Add(dr)
            Else
                'drPN = dsMatList.Tables(0).Select("IntSN='" & txtPCBID.Text & "'")
                If e.Result.tables(0).rows(0)("MotherBoardSN").ToString <> "" Then
                    Me.ShowMessage("^TDC-157@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtCLID.SelectAll()
                    txtCLID.Focus()
                    Exit Sub
                End If
                If e.Result.tables(0).rows(0)("PCBA").ToString <> txtPCBANo.Text Then
                    Me.ShowMessage("^121-55@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtCLID.SelectAll()
                    txtCLID.Focus()
                    Exit Sub
                End If
                If Not e.Result.tables(0).rows(0)("AllPassed") Then
                    Me.ShowMessage("^TDC-13@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtCLID.SelectAll()
                    txtCLID.Focus()
                    Exit Sub
                End If
                dr = dtRep.NewRow
                dr("WIPID") = MatListID
                dr("PCBID") = txtPCBID.Text
                dr("PCBA") = txtPCBANo.Text
                dr("CircuitCode") = ""
                dr("CurPN") = ""
                dr("CurCLID") = txtPCBID.Text
                dr("NewItem") = ""
                dr("NewCLID") = txtCLID.Text
                dr("NewWIPID") = e.Result.tables(0).rows(0)("WIPID")
                dtRep.Rows.Add(dr)
            End If
            Me.ShowMessage(txtCLID.Text & " " & "^SFC-108@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim, False, PopUpTypes.Message)
            txtCC.Text = ""
            txtCLID.Text = ""
            txtCC.Focus()
        Catch ex As Exception
            Me.ShowMessage(txtCLID.Text, eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim, False, PopUpTypes.Message)
        End Try
    End Sub

    Private Sub cleardataInput()
        Me.DisableValidation = True
        grpDataInput.Enabled = True
        btnPost.Enabled = True
        dtOtherInfo.Clear()
        dtRep.Clear()
        If Not dsResult Is Nothing Then
            dsResult.Clear()
        End If
        txtIntSerial.Text = ""
        txtIntSerial.Focus()
        txtPOPCBA.Text = ""
        txtQty.Text = ""
        DisableValidation = False
        txtPONo.Text = ""
        txtPCBANo.Text = ""
        txtCLID.Text = ""
        txtPCBID.Text = ""
        txtResult.Text = ""
        txtCC.Text = ""
        txtCC.Items.Clear()
        txtPCBID.Items.Clear()
        btnEMI.Visible = False
    End Sub

    Private Sub KeepList()
        Me.DisableValidation = True
        grpDataInput.Enabled = True
        btnPost.Enabled = True
        dtOtherInfo.Clear()
        'dtRep.Clear()
        For Each dr As DataRow In dtRep.Rows
            If dr("NewWIPID") <> "" Then
                dr.Delete()
            Else
                dr("CurCLID") = ""
                dr("WIPID") = ""
                dr("PCBID") = ""
            End If
        Next
        dtRep.AcceptChanges()
        txtIntSerial.Text = ""
        txtIntSerial.Focus()
        txtPOPCBA.Text = ""
        txtQty.Text = ""
        DisableValidation = False
        txtPONo.Text = ""
        txtPCBANo.Text = ""
        txtCLID.Text = ""
        txtPCBID.Text = ""
        txtResult.Text = ""
        txtCC.Text = ""
        txtCC.Items.Clear()
        txtPCBID.Items.Clear()
        btnEMI.Visible = False
    End Sub
    Private Sub ContinuedataInput()
        Me.DisableValidation = True
        grpDataInput.Enabled = True
        btnPost.Enabled = True
        Dim drMat() As DataRow
        Dim wid As String = ""
        For Each dr As DataRow In dtRep.Rows
            If ReworkFlg = "Y" Then
                drMat = dsMatList.Tables(0).Select("PCBA='" & dr("PCBA") & "' and CircuitCode='" & dr("CircuitCode") & "'")
                dr("CurCLID") = drMat(0)("CLID")
                dr("WIPID") = dsMatList.Tables(0).Rows(0)("WIPID").ToString
                dr("PCBID") = txtIntSerial.Text
            Else
                If dtPCBA.Rows.Count = 1 Then
                    drMat = dsMatList.Tables(0).Select("PCBA='" & dr("PCBA") & "' and CircuitCode='" & dr("CircuitCode") & "'")
                    dr("CurCLID") = drMat(0)("CLID")
                    dr("WIPID") = dtPCBA.Rows(0)("WIPID").ToString
                    dr("PCBID") = dtPCBA.Rows(0)("IntSN").ToString
                Else
                    Dim drPCBA() As DataRow
                    drPCBA = dtPCBA.Select("PCBA='" & dr("PCBA") & "'")
                    If wid <> drPCBA(0)("WIPID").ToString Then
                        wid = drPCBA(0)("WIPID").ToString
                        dsMatList = BLL.MatListOnPCBA(wid)
                    End If
                    drMat = dsMatList.Tables(0).Select("CircuitCode='" & dr("CircuitCode") & "'")
                    dr("CurCLID") = drMat(0)("CLID").ToString
                    dr("WIPID") = drPCBA(0)("WIPID").ToString
                    dr("PCBID") = drPCBA(0)("IntSN")
                End If
            End If
        Next
        dtRep.AcceptChanges()
        txtPCBID.Focus()
        btnEMI.Visible = False
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        If dtRep.Rows.Count = 0 Then
            Me.ShowMessage("^SFC-111@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtCLID.Focus()
            Exit Sub
        End If
        If dtRep.Select("PCBID=''").Length <> 0 Then
            Me.ShowMessage("^TDC-23@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSerial.Focus()
            Exit Sub
        End If
        If Me.ShowMessage("^SFC-110@", eTraceUI.eTraceMessageBar.MessageTypes.Warning, AnimationStatus.StopAnim, True, PopUpTypes.Question) = True Then
            grpDataInput.Enabled = False
            dtOtherInfo.Clear()
            Dim myDataRow As DataRow
            myDataRow = dtOtherInfo.NewRow()
            myDataRow("TLAWIPID") = dtTLA.Rows(0)("WIPID")
            myDataRow("Operator") = user
            myDataRow("Line") = BLL.LoginData.ProductionLine
            myDataRow("OrgCode") = BLL.LoginData.OrgCode
            myDataRow("Process") = CurrProcess
            myDataRow("DJ") = txtPONo.Text
            myDataRow("Model") = txtModelNo.Text
            myDataRow("PCBA") = txtPCBANo.Text
            If chkAddlData.Checked Then
                myDataRow("Forced") = "Y"
            Else
                myDataRow("Forced") = "N"
            End If
            myDataRow("ReworkUnit") = ReworkFlg
            dtOtherInfo.Rows.Add(myDataRow)
            If Not dsResult Is Nothing Then
                dsResult.Tables.Remove("OtherInfo")
                dsResult.Tables.Remove("RepList")
            End If
            dsResult = New DataSet("DS")
            If Not dsResult.Tables.Contains("OtherInfo") Then
                dsResult.Tables.Add(dtOtherInfo)
            End If
            If Not dsResult.Tables.Contains("RepList") Then
                dsResult.Tables.Add(dtRep)
            End If
            dsResult.AcceptChanges()
            Me.ShowMessage("^TDC-92@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
            savesate()
        End If

    End Sub

    Private Sub savesate()
        bgwPost.RunWorkerAsync()
    End Sub

    Private Sub bgwPost_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwPost.DoWork
        Try
            e.Result = BLL.ComponentReplacement(dsResult)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub bgwPost_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPost.RunWorkerCompleted
        If e.Result = "^UMG-10@" Then
            Me.ShowMessage(e.Result, eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
            KeepList()
        Else
            Me.ShowMessage(e.Result, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        End If
    End Sub

    Private Sub frmComponentReplacement_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Try
            SerialPort1.Open()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmComponentReplacement_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
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
        ElseIf txtCLID.Focused Then
            txtCLID.Text = ReceivedText
            txtCLID.Modified = True
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


    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        cleardataInput()
    End Sub


    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        cleardataInput()
    End Sub

    Private Sub dgvResult_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCR.KeyDown
        If (e.KeyCode = Keys.Delete And dgvCR.SelectedRows.Count <> 0) Then
            For Each dgvr As DataGridViewRow In dgvCR.SelectedRows
                dtRep.Rows(dgvr.Index).Delete()
            Next
        End If
    End Sub

    Private Sub chkAddlData_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAddlData.CheckedChanged
        If chkAddlData.Checked Then
            txtResult.Visible = False
        Else
            txtResult.Visible = True
        End If
    End Sub
    Dim PcbidOnDD As String = "" ' PCBID on DropDown
    Private Sub txtPCBID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPCBID.SelectedIndexChanged
        If PCBIDFlag Then
            txtPCBID.Text = Trim(txtPCBID.Text)
            If txtPCBID.Text = "" Then Exit Sub
            Dim strPCBID() As String
            strPCBID = txtPCBID.Text.Split("|")
            txtPCBANo.Text = strPCBID(1).Trim
            txtPCBID.GetText()
            PcbidOnDD = txtPCBID.Text
            txtCC.Text = ""
            'If ReworkFlg = "Y" Then
            '    Dim dr() As DataRow
            '    dr = dsMatList.Tables(0).Select("IntSN='" & txtPCBID.Text & "'")
            '    txtPCBANo.Text = dr(0)("PCBA").ToString
            '    splitCC(dsMatList.Tables(0))
            '    'txtCC.Items.Clear()
            '    'For Each drCC As DataRow In dr
            '    '    txtCC.Items.Add(drCC("CircuitCode").ToString)
            '    'Next
            '    txtCC.ItemDataTable = dsMatList.Tables(0)
            '    txtCC.setItems("IntSN='" & txtPCBID.Text & "'")
            'Else
            '    MatListID = dtPCBA.Select("IntSN='" & txtPCBID.Text & "'")(0)("WIPID").ToString
            '    txtPCBANo.Text = dtPCBA.Select("IntSN='" & txtPCBID.Text & "'")(0)("PCBA").ToString
            '    addCC(MatListID)
            'End If
            MatListID = dtPCBA.Select("IntSN='" & txtPCBID.Text & "'")(0)("WIPID").ToString
            addCC(MatListID)
        End If
        PCBIDFlag = False
    End Sub

    Dim PCBIDFlag As Boolean = False
    Private Sub txtPCBID_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPCBID.DropDown
        PCBIDFlag = True
    End Sub

    Private Sub txtPCBID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPCBID.TextChanged
        If txtPCBID.Text = "" Then
            Exit Sub
        End If
        If Not PCBIDFlag Then
            Dim dr() As DataRow
            If dtPCBA.Rows.Count <> 0 Then
                dr = dtPCBA.Select("IntSN='" & txtPCBID.Text & "'")
                If dr.Length <> 0 AndAlso MatListID <> dr(0)("WIPID").ToString Then
                    MatListID = dr(0)("WIPID").ToString
                    addCC(MatListID)
                End If
            End If
        End If
    End Sub

    Private Sub AddOtherColumn()
        Dim myDataColumn As DataColumn
        dtOtherInfo = New Data.DataTable("OtherInfo")
        myDataColumn = New Data.DataColumn("TLAWIPID", System.Type.GetType("System.String"))
        dtOtherInfo.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("Operator", System.Type.GetType("System.String"))
        dtOtherInfo.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("Line", System.Type.GetType("System.String"))
        dtOtherInfo.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("OrgCode", System.Type.GetType("System.String"))
        dtOtherInfo.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("Process", System.Type.GetType("System.String"))
        dtOtherInfo.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("DJ", System.Type.GetType("System.String"))
        dtOtherInfo.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("Model", System.Type.GetType("System.String"))
        dtOtherInfo.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("PCBA", System.Type.GetType("System.String"))
        dtOtherInfo.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("Forced", System.Type.GetType("System.String"))
        dtOtherInfo.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("ReworkUnit", System.Type.GetType("System.String"))
        dtOtherInfo.Columns.Add(myDataColumn)
    End Sub
    Private Sub AddRepColumn()
        Dim myDataColumn As DataColumn
        dtRep = New Data.DataTable("RepList")
        myDataColumn = New Data.DataColumn("WIPID", System.Type.GetType("System.String"))
        dtRep.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("PCBID", System.Type.GetType("System.String"))
        dtRep.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("PCBA", System.Type.GetType("System.String"))
        dtRep.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("CircuitCode", System.Type.GetType("System.String"))
        dtRep.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("CurPN", System.Type.GetType("System.String"))
        dtRep.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("CurCLID", System.Type.GetType("System.String"))
        dtRep.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("NewItem", System.Type.GetType("System.String"))
        dtRep.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("NewCLID", System.Type.GetType("System.String"))
        dtRep.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("NewWIPID", System.Type.GetType("System.String"))
        dtRep.Columns.Add(myDataColumn)
    End Sub

    Private Sub txtResult_ValidateData() Handles txtResult.ValidateData
        txtResult.Text = Trim(txtResult.Text)
        If BLL.CheckPrevResult(txtIntSerial.Text, CurrProcess, user) = "INVALID" Then
            Me.ShowMessage("^TDC-23@" + " " + txtIntSerial.Text, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
        End If
        If Trim(txtResult.Text) <> "" And txtResult.Modified Then
            Me.ShowMessage("^TDC-24@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
            pnlBody.Enabled = False
            Me.bgwResult.RunWorkerAsync()
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
            Me.ShowMessage("^TDC-59@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            txtResult.Text = e.Result.ToString.ToUpper()
            With BLL.StatusHeader
                .IntSerial = txtIntSerial.Text
                .Result = txtResult.Text
                .Process = CurrProcess
                .OperatorName = user
            End With
            Dim saveMsg As Boolean
            saveMsg = BLL.SCRSaveResult(BLL.StatusHeader)
            If (Not saveMsg) Then
                Me.ShowMessage("^SFC-61@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                grpDataInput.Enabled = True
                txtResult.SelectAll()
                txtResult.Focus()
            Else
                Me.ShowMessage("^TDC-60@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
                cleardataInput()
            End If
        End If
    End Sub

    Private Sub txtPCBID_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPCBID.Validated
        txtPCBID.Text = PcbidOnDD
    End Sub

    Dim CConDD As String = ""
    Private Sub txtCC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCC.SelectedIndexChanged
        txtCC.GetText()
        CConDD = txtCC.Text
    End Sub

    Private Sub txtCC_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCC.Validated
        txtCC.Text = CConDD
    End Sub

End Class
