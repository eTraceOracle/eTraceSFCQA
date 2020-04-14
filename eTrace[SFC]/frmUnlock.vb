Imports System.ComponentModel

Public Class frmUnlock
    Public ProcessID As Integer
    Public CurrProcess As String
    Dim User As String
    Dim record As DataTable
    Dim dtResultList As DataTable
    Dim Emifile As Object
    Private flgBusy As Boolean = False
    Private Delegate Sub UpdateUI(ByVal ReceivedData As String)
    ''' <summary>
    ''' 记录上一次选择项rowId
    ''' </summary>
    Private _lastselectIndex = -1
    Private _dsLocks As DataSet
    ''' <summary>
    ''' 缓存所有locks
    ''' </summary>
    Private _dtAllLocks As DataTable

    Private Function GetCurrentDataRow(gridviewRowIndex As Integer) As DataRow
        Dim dr As DataRow
        Dim dgvRow As DataGridViewRow = dgvLocks.Rows(gridviewRowIndex)
        If dgvRow Is Nothing Then
            Return Nothing
        End If
        Dim lockid As String = dgvRow.Tag
        dr = GetDataRowByLockID(lockid)
        Return dr
    End Function
    Public Overrides Sub NewSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'New Instance of the form
        Dim NewInstance As New frmMain()
        NewInstance.ShowFrm(Me)
    End Sub

    Private Sub bgwUnlock_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwUnlock.DoWork
        Try
            Dim lockinfo As eTrace_SFCFunction_.Functions.UpdateAndUnclockRequset
            lockinfo = e.Argument
            e.Result = BLL.UpdateAndUnLockByID(lockinfo)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub bgwUnlock_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwUnlock.RunWorkerCompleted
        If e.Result = "true" Then
            Me.ShowMessage("^SFC-152@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            '重新加载
            StartLoadLocks()
            txtCardNo.Clear()
            txtCardNo.Visible = False
        Else
            Me.ShowMessage("^SFC-153@" + ":" + e.Result, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtCardNo.Visible = True
            txtCardNo.Focus()
            txtCardNo.Clear()
        End If

    End Sub

    'Private Sub bgwExtSerial_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
    '    Try
    '        e.Result = BLL.GetResult(txtPQE.Text, CurrProcess, "")
    '    Catch ex As Exception
    '        BLL.ErrorLogging("TDC-IDSwop-txtExtSerial.ValidateData", "", ex.Message)
    '    End Try
    'End Sub

    'Private Sub bgwExtSerial_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
    '    pnlBody.Enabled = True
    '    If e.Result.ToString.ToUpper <> "RECYCLE" Then
    '        Me.ShowMessage("^SFC-9@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
    '        txtPQE.SelectAll()
    '        txtPQE.Focus()
    '    Else
    '        Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
    '        txtPQE.Text = "Accept"
    '        txtPQE.ReadOnly = True
    '        doPost()
    '    End If
    'End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        doPost()
    End Sub


    Private Sub doPost()
        'If Me.ShowMessage("^SFC-8@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.NoChange, True, PopUpTypes.Question) = False Then
        '    Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        '    ' Me.DisableValidation = False
        '    txtPQE.ReadOnly = False
        '    txtPQE.Text = ""
        '    txtSymptom.Focus()
        '    txtSymptom.SelectAll()
        '    Exit Sub
        'End If
        ''保存
        If dgvLocks.SelectedRows.Count = 0 Then
            Me.ShowMessage("^SFC-150@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            Return
        End If
        Dim dgbRow As DataGridViewRow = dgvLocks.SelectedRows(0)
        Dim lockinfo As New eTrace_SFCFunction_.Functions.LockInfo
        lockinfo.lockId = dgbRow.Tag
        lockinfo.other = txtOthers.Text
        lockinfo.pbr = txtPBR.Text
        lockinfo.pe = txtPE.Text
        lockinfo.pqe = txtPQE.Text
        lockinfo.remarks = txtRemarks.Text
        lockinfo.symptom = txtSymptom.Text
        lockinfo.te = txtTE.Text
        bgwPost.RunWorkerAsync(lockinfo)
    End Sub

    Private Sub bgwPost_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwPost.DoWork
        Dim lockInfo As eTrace_SFCFunction_.Functions.LockInfo = e.Argument

        e.Result = BLL.UpdateLockByID(lockInfo)

    End Sub

    Private Sub bgwPost_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPost.RunWorkerCompleted
        Dim lockid As String
        Dim currentLockID As String = ""
        Dim result As eTrace_SFCFunction_.Functions.updateLockInfoResponse
        result = e.Result
        If (result.ReponseInfo = "true") Then
            lockid = result.lockId
            If dgvLocks.SelectedRows.Count > 0 Then
                currentLockID = dgvLocks.SelectedRows.Item(0).Tag.ToString()
            End If
            For i As Integer = 0 To _dsLocks.Tables(0).Rows.Count - 1
                Dim dr = _dsLocks.Tables(0).Rows(i)
                Dim eachLockID = dr.Item("lockID").ToString()
                If eachLockID = lockid Then
                    dr("SymptomCode") = result.symptom
                    dr("FA_TE") = result.te
                    dr("FA_PE") = result.pe
                    dr("FA_PQE") = result.pqe
                    dr("FA_Others") = result.other
                    dr("PBR") = result.pbr
                    dr("Remarks") = result.remarks
                    'if Current row Has Changed ,display  it in the textbox 
                    If currentLockID = lockid Then
                        txtSymptom.Text = result.symptom
                        txtTE.Text = result.te
                        txtPE.Text = result.pe
                        txtPQE.Text = result.pqe
                        txtOthers.Text = result.other
                        txtPBR.Text = result.pbr
                        txtRemarks.Text = result.remarks
                    End If

                    Exit For
                End If
            Next
            Me.ShowMessage("^TDC-60@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
        Else
            Me.ShowMessage("^TDC-61@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        End If
        'grpDataInput.Enabled = False
        'btnPost.Enabled = False
    End Sub

    Private Sub ClearDataInput()
        Me.DisableValidation = True
        'If btnPost.Enabled Then
        '    If Me.ShowMessage("^OLD-4@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.NoChange, True, PopUpTypes.Question) = False Then
        '        Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        '        Me.DisableValidation = False
        '        Exit Sub
        '    End If
        'End If
        grpCurrentLocks.Enabled = True
        btnPost.Enabled = True
        txtPQE.Text = ""
        txtSymptom.Text = ""
        txtOthers.Text = ""
        txtPBR.Text = ""
        txtPE.Text = ""
        txtTE.Text = ""
        txtRemarks.Text = ""
        txtPQE.ReadOnly = False
        DisableValidation = False
        'dgvLocks.DataSource = Nothing
        'dgvLocks.Visible = False

    End Sub




    Private Sub WriteBox(ByVal ReceivedText As String)
        If txtSymptom.Focused Then
            txtSymptom.Text = ReceivedText
            txtSymptom.Modified = True
            My.Computer.Keyboard.SendKeys("{TAB}")
        ElseIf txtPQE.Focused Then
            txtPQE.Text = ReceivedText
            txtPQE.Modified = True
            My.Computer.Keyboard.SendKeys("{TAB}")
        End If
        flgBusy = False
    End Sub

    Private Sub btnEMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEMI.Click
        'Dim path As String
        'Dim MIForm As New frmMI()
        'path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\eTrace\EMI\"
        'Globals.MIFileName = "EMI_" + txtModelNo.Text.Trim + "_" + txtPCBANo.Text.Trim + "_" + CurrProcess
        'Dim t() As Byte = CType(Emifile, Byte())
        'Dim PDF As IO.FileStream
        'If IO.File.Exists(path + MIFileName + ".pdf") Then
        '    IO.File.Delete(path + MIFileName + ".pdf")
        'End If
        'If (Not IO.Directory.Exists(path)) Then
        '    IO.Directory.CreateDirectory(path)
        'End If
        'PDF = IO.File.Create(path + MIFileName + ".pdf")
        'PDF.Write(t, 0, t.GetUpperBound(0))
        'PDF.Close()
        'MIForm.ShowFrm(Me)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub StartLoadLocks()
        Me.ShowMessage("^TDC-529@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
        bgwLoadLocks.RunWorkerAsync()
    End Sub

    Private Sub bgwLoadLocks_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwLoadLocks.DoWork
        Try
            e.Result = BLL.ATEGetAllLocks()
        Catch ex As Exception
            BLL.ErrorLogging("SFC-ATEGetAllLocks", User, ex.Message)
        End Try
    End Sub

    Private Sub bgwLoadLocks_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwLoadLocks.RunWorkerCompleted
        If (e.Result Is Nothing) Then
            Me.ShowMessage("^SFC-163@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            'grpCurrentLocks.Enabled = True
            'btnPost.Enabled = True
            txtSymptom.SelectAll()
            txtSymptom.Focus()
        Else
            _dsLocks = e.Result
            InitDatagridview()
            Me.ShowMessage("^SFC-162@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
            'ClearDataInput()
        End If
    End Sub
    Private Sub InitDatagridview()
        '_dsRecord.Tables.Add()
        Try
            dgvLocks.Rows.Clear()
            ClearDataInput()
            Dim ds As New DataSet
            Dim rows As DataRow()
            Dim fiter As String = "1=1"
            If Not chkShowUnlocked.Checked Then
                fiter = fiter + " and " + "Status ='" + "0" + "'"
            End If
            If RadioBtnCurrentLine.Checked Then
                fiter = fiter + " and " + "ProdLine ='" + ProductionLine() + "'"
            End If

            rows = _dsLocks.Tables(0).Select(fiter, "Status, LockedOn desc")
            'rows = _dsLocks.Tables(0).Select(fiter, "LockedOn desc")
            'rows = _dsLocks.Tables(0).Select(fiter)
            For i As Integer = 0 To rows.Length - 1
                Dim dr As DataRow = rows(i)
                Dim dgvRow As DataGridViewRow
                dgvRow = New DataGridViewRow()
                dgvRow.Tag = dr.Item("LockID").ToString()
                dgvRow.CreateCells(dgvLocks, {False, dr("ProdLine"), dr("Model"), dr("PCBA"), dr("Process"), dr("FailedTestStep"), dr("LockedOn"), IIf(dr("Status").ToString() = "1", "UnLocked", "Locked"), dr("LockType"), dr("Details")})
                dgvLocks.Rows.Add(dgvRow)
            Next

        Catch ex As Exception

        End Try
        'ds.Tables.Add(table)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
        'dgvLocks.DataSource = ds
        'dgvLocks.Refresh()
    End Sub

    Private Sub frmUnlock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AttachHotkey(btnPost, Keys.F8)
        AttachHotkey(btnRefresh, Keys.F5)
        AttachHotkey(btnUnlock, Keys.F3)
        ProcessID = SelectProcessID
        CurrProcess = SelectProcess
        BindCtlsToProcess(Me, ProcessID)
        StartLoadLocks()
        txtCardNo.Visible = False
        'Me.ShowMessage(ProcessShow, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click

        StartLoadLocks()
    End Sub
    ''' <summary>
    ''' 切换
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Radio_CheckedChanged(sender As Object, e As EventArgs) Handles RadioBtnAllLine.CheckedChanged, RadioBtnCurrentLine.CheckedChanged
        If _dsLocks IsNot Nothing Then
            InitDatagridview()
            'ClearDataInput()
        End If
    End Sub

    Private Sub dgvLocks_SelectionChanged(sender As Object, e As EventArgs) Handles dgvLocks.SelectionChanged
        For i As Integer = 0 To dgvLocks.RowCount - 1
            dgvLocks.Rows(i).Cells(0).Value = False
        Next


        If dgvLocks.SelectedRows Is Nothing Then
            Return
        End If
        If dgvLocks.SelectedRows.Count = 0 Then
            Return
        End If
        Dim dr As DataRow
        Dim lockid As String
        Dim dgvRow As DataGridViewRow = dgvLocks.SelectedRows.Item(0)
        dgvRow.Cells(0).Value = True
        lockid = dgvRow.Tag
        dr = GetDataRowByLockID(lockid)
        If dr IsNot Nothing Then
            txtSymptom.Text = dr("SymptomCode").ToString
            txtTE.Text = dr("FA_TE").ToString
            txtPE.Text = dr("FA_PE").ToString
            txtPQE.Text = dr("FA_PQE").ToString
            txtOthers.Text = dr("FA_Others").ToString
            txtPBR.Text = dr("PBR").ToString
            txtRemarks.Text = dr("Remarks").ToString
            txtLockType.Text = dr("LockType").ToString
            txtDetails.Text = dr("Details").ToString
            If dr("Status").ToString() = "0" Then
                btnUnlock.Enabled = True
            Else
                btnUnlock.Enabled = False
            End If
        End If
    End Sub
    ''' <summary>
    ''' jarge weather locks info have been modifed
    ''' </summary>
    ''' <returns></returns>
    Private Function IsModifed(dr As DataRow) As Boolean

        If txtSymptom.Text <> dr("SymptomCode").ToString().ToUpper() Then
            Return True
        End If
        If txtTE.Text <> dr("FA_TE").ToString().ToUpper() Then
            Return True
        End If
        If txtPE.Text <> dr("FA_PE").ToString().ToUpper() Then
            Return True
        End If
        If txtPQE.Text <> dr("FA_PQE").ToString().ToUpper() Then
            Return True
        End If
        If txtOthers.Text <> dr("FA_Others").ToString().ToUpper() Then
            Return True
        End If
        If txtRemarks.Text <> dr("Remarks").ToString().ToUpper() Then
            Return True
        End If
        If txtPBR.Text <> dr("PBR").ToString().ToUpper() Then
            Return True
        End If
        Return False
    End Function

    Private Sub dgvLocks_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvLocks.RowValidating
        'Dim dr As DataRow = _dsLocks.Tables(0).row
        Dim dr As DataRow
        dr = GetCurrentDataRow(e.RowIndex)
        If dr Is Nothing Then
            Return
        End If
        If IsModifed(dr) Then
            If Me.ShowMessage("^SFC-161@", eTraceUI.eTraceMessageBar.MessageTypes.Warning, AnimationStatus.StopAnim, True, PopUpTypes.Question) Then
                ''保存
                Dim dgbRow As DataGridViewRow = dgvLocks.Rows(e.RowIndex)
                Dim lockinfo As New eTrace_SFCFunction_.Functions.LockInfo
                lockinfo.lockId = dr.Item("LockID").ToString()
                lockinfo.other = txtOthers.Text
                lockinfo.pbr = txtPBR.Text
                lockinfo.pe = txtPE.Text
                lockinfo.pqe = txtPQE.Text
                lockinfo.remarks = txtRemarks.Text
                lockinfo.symptom = txtSymptom.Text
                lockinfo.te = txtTE.Text
                bgwPost.RunWorkerAsync(lockinfo)
            Else
                Me.ShowMessage("^SFC-155@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
            End If
        End If
    End Sub

    Private Function GetDataRowByLockID(ByVal lockId As String) As DataRow
        Dim dr As DataRow
        For i As Integer = 0 To _dsLocks.Tables(0).Rows.Count - 1
            dr = _dsLocks.Tables(0).Rows(i)
            If dr IsNot Nothing Then
                If dr.Item("LockID").ToString() = lockId Then
                    Return dr
                End If
            End If
        Next
        Return Nothing
    End Function

    Private Sub frmUnlock_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ddlProcess.Text = ProcessShow
        Me.CenterToScreen()
        User = Mid(UserName.Text, 1, InStr(UserName.Text, "-") - 1).Trim
        BLL.LoginData.User = User
        BLL.LoginData.OrgCode = Mid(MyOrg(), 1, 3)
        BLL.LoginData.ProductionLine = ProductionLine()
    End Sub

    Private Sub btnUnlock_Click(sender As Object, e As EventArgs) Handles btnUnlock.Click
        If dgvLocks.SelectedRows.Count = 0 Then
            Return
        End If
        If Me.ShowMessage("^SFC-154@", eTraceUI.eTraceMessageBar.MessageTypes.Warning, AnimationStatus.StopAnim, True, PopUpTypes.Question) = False Then
            Me.ShowMessage("^SFC-155@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
            'Give up 
            Return
        End If
        If dgvLocks.SelectedRows.Count = 0 Then
            Me.ShowMessage("^SFC-150@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            Return
        End If
        Me.ShowMessage("^SFC-157@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
        With txtCardNo
            .Visible = True
            .Clear()
            .SelectAll()
            .Focus()
        End With

    End Sub





    Private Sub chkShowUnlocked_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowUnlocked.CheckedChanged
        If _dsLocks IsNot Nothing Then
            InitDatagridview()
            'ClearDataInput()
        End If
    End Sub

    Private Sub txtCardNo_ValidateData() Handles txtCardNo.ValidateData
        Dim cardNo = txtCardNo.Text
        If String.IsNullOrEmpty(cardNo) Then
            Return
            txtCardNo.Visible = False
        End If
        Dim dgbRow As DataGridViewRow = dgvLocks.SelectedRows(0)
        Dim lockinfo As New eTrace_SFCFunction_.Functions.UpdateAndUnclockRequset
        With lockinfo
            .lockId = dgbRow.Tag
            .other = txtOthers.Text
            .pbr = txtPBR.Text
            .pe = txtPE.Text
            .pqe = txtPQE.Text
            .remarks = txtRemarks.Text
            .symptom = txtSymptom.Text
            .te = txtTE.Text
            .User = BLL.LoginData.User
            .CardNo = cardNo
        End With
        bgwUnlock.RunWorkerAsync(lockinfo)
    End Sub

    Private Sub txtCardNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCardNo.KeyPress
        If Asc(e.KeyChar) = 27 Then
            txtCardNo.CausesValidation = False
            txtCardNo.Visible = False
            Me.ShowMessage("^SFC-155@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
            txtCardNo.CausesValidation = True
        End If
    End Sub

    Private Sub txtCardNo_Validated(sender As Object, e As EventArgs) Handles txtCardNo.Validated

    End Sub

    Private Sub txtCardNo_Leave(sender As Object, e As EventArgs) Handles txtCardNo.Leave
        txtCardNo.CausesValidation = False
        txtCardNo.Visible = False
        Me.ShowMessage("^SFC-155@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
        txtCardNo.CausesValidation = True
    End Sub
End Class
