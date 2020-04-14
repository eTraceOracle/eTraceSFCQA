Public Class frmChangePallet
    Public ProcessID As Integer
    Public CurrProcess As String
    Public user As String
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
        Me.ShowMessage(ProcessShow, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
    End Sub

    Private Sub frmTemplate_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        ddlProcess.Text = ProcessShow
        Me.CenterToScreen()
        user = Mid(UserName.Text, 1, InStr(UserName.Text, "-") - 1).Trim
        BLL.LoginData.User = user
        BLL.LoginData.OrgCode = MyOrg()
        BLL.LoginData.ProductionLine = ProductionLine()
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
            e.Result = BLL.GetShipInfoByBoxID(txtIntSerial.Text, user)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub bgwIntSerial_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwIntSerial.RunWorkerCompleted
        pnlBody.Enabled = True
        If e.Result.Model = "" Then
            Me.ShowMessage("^TDC-106@" + vbCrLf + txtIntSerial.Text, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
        Else
            BLL.ShipInfo = e.Result
            Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            txtExtSerial.Text = e.Result.PalletID
            txtModelNo.Text = e.Result.model
            txtPONo.Text = e.Result.prodOrder
            Emifile = BLL.getMIFileData(txtModelNo.Text.Trim, txtModelNo.Text.Trim, CurrProcess)
            If (Not Emifile Is Nothing) Then
                btnEMI.Visible = True
            End If
            txtPCBASerial.Focus()
        End If
    End Sub

    Private Sub txtPCBASerial_ValidateData() Handles txtPCBASerial.ValidateData
        If Mid(txtPCBASerial.Text, 1, 1).ToUpper <> "P" Then
            Me.ShowMessage("^TDC-107@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtPCBASerial.SelectAll()
            txtPCBASerial.Focus()
        Else
            Me.ShowMessage("^TDC-149@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
            Me.bgwChangePick.RunWorkerAsync()
        End If
        Exit Sub
    End Sub


    Private Sub bgwChangePick_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwChangePick.DoWork
        Try
            e.Result = BLL.GetShipInfoByPalletID(txtPCBASerial.Text, user)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub bgwChangePick_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwChangePick.RunWorkerCompleted
        If (BLL.ShipInfo.CustomerPN <> e.Result.CustomerPN And BLL.ShipInfo.Customer <> e.Result.Customer) And ((Not e.Result.CustomerPN Is Nothing) And (Not e.Result.Customer Is Nothing)) Then
            Me.ShowMessage("^TDC-151@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtPCBASerial.SelectAll()
            txtPCBASerial.Focus()
        Else
            savesate()
        End If
    End Sub

    Private Sub bgwPost_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwPost.DoWork
        Try
            e.Result = BLL.ChangePallet(txtIntSerial.Text, txtPCBASerial.Text, user)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub bgwPost_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPost.RunWorkerCompleted
        If e.Result = "0" Then
            Me.ShowMessage("^TDC-150@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
            cleardataInput()
        ElseIf e.Result = "1" Then
            Me.ShowMessage("^TDC-61@" & ", " & "^TDC-102@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        Else
            Me.ShowMessage("^TDC-61@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        End If
    End Sub


    Private Sub cleardataInput()
        Me.DisableValidation = True
        grpDataInput.Enabled = True
        btnPost.Enabled = True
        txtIntSerial.Text = ""
        txtIntSerial.Focus()
        Me.txtExtSerial.Text = ""
        DisableValidation = False
        txtPONo.Text = ""
        txtModelNo.Text = ""
        txtPCBANo.Text = ""
        txtPCBASerial.Text = ""
        btnEMI.Visible = False
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        savesate()
    End Sub

    Private Sub savesate()
        If txtIntSerial.Highlight = True Then Exit Sub
        If txtPCBASerial.Highlight = True Then Exit Sub
        bgwPost.RunWorkerAsync()
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
        ElseIf txtExtSerial.Focused Then
            txtExtSerial.Text = ReceivedText
            txtExtSerial.Modified = True
            My.Computer.Keyboard.SendKeys("{TAB}")
        ElseIf txtPCBASerial.Focused Then
            txtPCBASerial.Text = ReceivedText
            txtPCBASerial.Modified = True
            My.Computer.Keyboard.SendKeys("{TAB}")
        End If
        flgBusy = False
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        cleardataInput()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        cleardataInput()
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
