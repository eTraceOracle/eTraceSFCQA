Public Class frmIDRecycle
    Public ProcessID As Integer
    Public CurrProcess As String
    Dim User As String
    Dim record As DataTable
    Dim dtResultList As DataTable
    Dim Emifile As Object
    Private flgBusy As Boolean = False
    Private Delegate Sub UpdateUI(ByVal ReceivedData As String)
    Dim SFC004 As String

    Public Overrides Sub NewSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'New Instance of the form
        Dim NewInstance As New frmMain()
        NewInstance.ShowFrm(Me)
    End Sub

    Private Sub frmIDRecycle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AttachHotkey(btnPost, Keys.F8)
        AttachHotkey(btnNew, Keys.F5)
        AttachHotkey(btnReset, Keys.F3)
        AttachHotkey(btnPrint, Keys.F9)
        ProcessID = SelectProcessID
        CurrProcess = SelectProcess
        BindCtlsToProcess(Me, ProcessID)
        SFC004 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC004'")(0)("Value"))
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
        BLL.LoginData.User = user
        BLL.LoginData.OrgCode = MyOrg()
        BLL.LoginData.ProductionLine = ProductionLine()
        txtIntSerial.Focus()
        'txtPONo.Focus()
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
            record = BLL.GetDataByIntSN(txtIntSerial.Text).Tables(0)
            txtPONo.Text = record.Rows(0)("DJ")
            txtModelNo.Text = record.Rows(0)("Model")
            txtPCBANo.Text = record.Rows(0)("PCBA")
            dtResultList = BLL.GetResultList(txtIntSerial.Text)
            dtResultList.Columns.Remove("Model")
            dtResultList.Columns.Remove("PCBA")
            dgvResult.DataSource = dtResultList
            dgvResult.Visible = True
            txtExtSerial.Focus()
            Emifile = BLL.getMIFileData(txtModelNo.Text.Trim, txtPCBANo.Text.Trim, CurrProcess)
            If (Not Emifile Is Nothing) Then
                btnEMI.Visible = True
            End If
            Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            
            'End If
        End If

    End Sub

    Private Sub txtExtSerial_ValidateData() Handles txtExtSerial.ValidateData
        txtExtSerial.Text = Trim(txtExtSerial.Text)
        If Trim(txtExtSerial.Text) <> "" And txtExtSerial.Modified Then
            Me.ShowMessage("^TDC-24@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
            pnlBody.Enabled = False
            Me.bgwExtSerial.RunWorkerAsync()
        End If
    End Sub

    Private Sub bgwExtSerial_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwExtSerial.DoWork
        Try
            e.Result = BLL.GetResult(txtExtSerial.Text, CurrProcess, "")
        Catch ex As Exception
            BLL.ErrorLogging("TDC-IDSwop-txtExtSerial.ValidateData", "", ex.Message)
        End Try
    End Sub

    Private Sub bgwExtSerial_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwExtSerial.RunWorkerCompleted
        pnlBody.Enabled = True
        If e.Result.ToString.ToUpper <> "RECYCLE" Then
            Me.ShowMessage("^SFC-9@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtExtSerial.SelectAll()
            txtExtSerial.Focus()
        Else
            Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            txtExtSerial.Text = "Accept"
            txtExtSerial.ReadOnly = True
            doPost()
        End If
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        If txtExtSerial.Text <> "Accept" Then
            Exit Sub
        End If
        doPost()
    End Sub


    Private Sub doPost()
        If Me.ShowMessage("^SFC-8@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.NoChange, True, PopUpTypes.Question) = False Then
            Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            ' Me.DisableValidation = False
            txtExtSerial.ReadOnly = False
            txtExtSerial.Text = ""
            txtIntSerial.Focus()
            txtIntSerial.SelectAll()
            Exit Sub
        End If
        bgwPost.RunWorkerAsync()
    End Sub


    Private Sub bgwPost_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwPost.DoWork
        With BLL.StatusHeader
            .IntSerial = txtIntSerial.Text
            .ExtSerial = txtExtSerial.Text
            .Process = CurrProcess
            .OperatorName = User
        End With
        e.Result = BLL.IntSNRecycleII(BLL.StatusHeader)
    End Sub

    Private Sub bgwPost_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPost.RunWorkerCompleted
        'If (e.Result = "^SFC-10@" Or e.Result = "^SFC-183@") Then
        '    Me.ShowMessage(e.Result, eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
        '    ClearDataInput()
        'Else
        '    Me.ShowMessage(e.Result, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        '    grpDataInput.Enabled = True
        '    btnPost.Enabled = True
        '    txtIntSerial.SelectAll()
        '    txtIntSerial.Focus()
        'End If
        If (e.Result = "^SFC-10@" Or e.Result = "^SFC-183@") Then
            Me.ShowMessage(e.Result, eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
            ClearDataInput()
        Else
            Me.ShowMessage(e.Result, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            ClearDataInput()
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
        'If btnPost.Enabled Then
        '    If Me.ShowMessage("^OLD-4@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.NoChange, True, PopUpTypes.Question) = False Then
        '        Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        '        Me.DisableValidation = False
        '        Exit Sub
        '    End If
        'End If
        grpDataInput.Enabled = True
        btnPost.Enabled = True
        txtExtSerial.Text = ""
        txtExtSerial.ReadOnly = False
        txtIntSerial.Text = ""
        txtIntSerial.Focus()
        DisableValidation = False
        txtPONo.Text = ""
        txtModelNo.Text = ""
        txtPCBANo.Text = ""
        dgvResult.DataSource = Nothing
        dgvResult.Visible = False

    End Sub

    Private Sub frmIDRecycle_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Try
            SerialPort1.Open()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmIDRecycle_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
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

End Class
