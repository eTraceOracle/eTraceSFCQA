Public Class frmChangeBox
    Public ProcessID As Integer
    Public CurrProcess As String
    Public user As String
    Private flgBusy As Boolean = False
    Private Emifile As Object
    Dim DSList As DataSet
    Dim total As Integer = 0
    Dim Customer As String
    Dim CustomerPN As String
    Dim CurDJ As String
    Dim ChangeDJ As String = "N"
    Dim BoxFlag As String = ""
    Dim ModelRev As String
    Dim POQty As Double
    Dim SFC019 As String
    Private Delegate Sub UpdateUI(ByVal ReceivedData As String)
    Public Overrides Sub NewSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'New Instance of the form
        Dim NewInstance As New frmMain()
        NewInstance.ShowFrm(Me)
    End Sub

    Private Sub frmTemplate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'AttachHotkey(btnPost, Keys.F8)
        'AttachHotkey(btnNew, Keys.F5)
        'AttachHotkey(btnReset, Keys.F3)
        'AttachHotkey(btnPrint, Keys.F9)
        ProcessID = SelectProcessID
        CurrProcess = SelectProcess
        BindCtlsToProcess(Me, ProcessID)
        SFC019 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC019'")(0)("Value"))
        Me.ShowMessage(ProcessShow, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
    End Sub

    Private Sub frmTemplate_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        ddlProcess.Text = ProcessShow
        Me.CenterToScreen()
        user = Mid(UserName.Text, 1, InStr(UserName.Text, "-") - 1).Trim
        BLL.LoginData.User = user
        BLL.LoginData.OrgCode = MyOrg()
        BLL.LoginData.ProductionLine = ProductionLine()
        DSList = New DataSet("DS")
        AddSNListTable(DSList)
        txtPONo.Focus()
    End Sub


    Private Sub txtIntSerial_ValidateData() Handles txtIntSerial.ValidateData
        txtIntSerial.Text = Trim(txtIntSerial.Text)
        If Trim(txtPONo.Text) = "" Then
            Me.ShowMessage("^SFC-86@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            txtIntSerial.Text = ""
            txtPONo.Focus()
            Exit Sub
        End If
        If Trim(txtIntSerial.Text) <> "" Then
            Me.ShowMessage("^TDC-24@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
            pnlBody.Enabled = False
            Me.bgwIntSerial.RunWorkerAsync()
        End If
    End Sub

    Private Sub bgwIntSerial_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwIntSerial.DoWork
        Try
            'e.Result = BLL.GetShipInfoBySN(txtIntSerial.Text)
            If BoxFlag = "" Or BoxFlag = "0" Then
                e.Result = BLL.GetShipInfoByBoxIDSN(txtIntSerial.Text)
            Else
                e.Result = txtIntSerial.Text
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub bgwIntSerial_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwIntSerial.RunWorkerCompleted
        pnlBody.Enabled = True
        If BoxFlag <> "1" Then
            If e.Result.Tables(0).rows.count = 0 Then       'Invalid Box ID or SN
                Me.ShowMessage("^SFC-69@" + vbCrLf + txtIntSerial.Text, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtIntSerial.SelectAll()
                txtIntSerial.Focus()
                Exit Sub
            End If

            If txtPONo.Text <> "" Then
                If txtModelNo.Text <> e.Result.Tables(0).rows(0)("Model").ToString Then          'the products' model are defferent with DJ's
                    Me.ShowMessage("^SFC-67@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtIntSerial.SelectAll()
                    txtIntSerial.Focus()
                    Exit Sub
                End If
            End If

            If DSList.Tables("SNList").Rows.Count = 0 Then 'the first box or product input

                Customer = e.Result.Tables(0).rows(0)("Customer").ToString
                CustomerPN = e.Result.Tables(0).rows(0)("CustomerPN").ToString
                CurDJ = e.Result.Tables(0).rows(0)("DJNo").ToString
                If txtIntSerial.Text = e.Result.Tables(0).rows(0)("ExtSN").ToString Then     'not the BoxID
                    BoxFlag = "0"
                    Dim myDataRow As DataRow
                    Dim drInList() As DataRow
                    For Each drSN As DataRow In e.Result.Tables(0).rows
                        drInList = DSList.Tables("SNList").Select("ExtSN = '" & drSN("ExtSN") & "'")
                        If drInList.Length = 0 Then
                            myDataRow = DSList.Tables("SNList").NewRow()
                            myDataRow("ExtSN") = drSN("ExtSN")
                            myDataRow("BoxID") = drSN("BoxID")
                            myDataRow("Choose") = True
                            DSList.Tables("SNList").Rows.Add(myDataRow)
                            total = total + 1
                        End If
                    Next
                Else
                    BoxFlag = "1"
                    Dim myDataRow As DataRow
                    Dim drInList() As DataRow
                    If e.Result.Tables(0).rows(0)("ExtSN").ToString.Contains("^") Then
                        'dgvResult.Enabled = True
                        dgvResult.ReadOnly = False
                    Else
                        'dgvResult.Enabled = False
                        dgvResult.ReadOnly = True
                    End If
                    For Each drSN As DataRow In e.Result.Tables(0).rows
                        drInList = DSList.Tables("SNList").Select("ExtSN = '" & drSN("ExtSN") & "'")
                        If drInList.Length = 0 Then
                            myDataRow = DSList.Tables("SNList").NewRow()
                            myDataRow("ExtSN") = drSN("ExtSN")
                            myDataRow("BoxID") = drSN("BoxID")
                            myDataRow("Choose") = False
                            DSList.Tables("SNList").Rows.Add(myDataRow)
                            'total = total + 1
                        End If
                    Next
                End If
            Else   'not the first box or product input
                If txtIntSerial.Text = e.Result.Tables(0).rows(0)("ExtSN").ToString Then     'not the BoxID
                    If e.Result.Tables(0).rows(0)("BoxID").ToString <> DSList.Tables("SNList").Rows(0)("BoxID").ToString Then
                        Me.ShowMessage("^SFC-70@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                        txtIntSerial.SelectAll()
                        txtIntSerial.Focus()
                        Exit Sub
                    End If
                    Dim drExtInList() As DataRow
                    drExtInList = DSList.Tables("SNList").Select("ExtSN = '" & txtIntSerial.Text & "'")
                    If drExtInList.Length = 0 Then
                        Dim myDataRow As DataRow
                        myDataRow = DSList.Tables("SNList").NewRow()
                        myDataRow("ExtSN") = e.Result.Tables(0).rows(0)("ExtSN")
                        myDataRow("BoxID") = e.Result.Tables(0).rows(0)("BoxID")
                        myDataRow("Choose") = True
                        DSList.Tables("SNList").Rows.Add(myDataRow)
                        'dgvResult.Rows(DSList.Tables("SNList").Rows.Count).Cells("Process").Style.ForeColor = Color.Green
                        total = total + 1
                    End If
                Else    'if input boxid now, show message
                    'invalid input
                    Me.ShowMessage("^SFC-69@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtIntSerial.SelectAll()
                    txtIntSerial.Focus()
                    Exit Sub
                End If
            End If
        Else           'BoxFlag = "1"
            Dim drExtInList() As DataRow
            drExtInList = DSList.Tables("SNList").Select("ExtSN = '" & txtIntSerial.Text & "'")
            If drExtInList.Length = 0 Then
                drExtInList = DSList.Tables("SNList").Select("ExtSN like '" + "%^" + txtIntSerial.Text + "'")
            End If
            If drExtInList.Length = 1 Then   ' on the list
                If Not drExtInList(0)("Choose") Then
                    drExtInList(0)("Choose") = True
                    total = total + 1
                End If
            Else                                               'the products' BoxID are defferent with the list's 
                Me.ShowMessage("^SFC-70@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtIntSerial.SelectAll()
                txtIntSerial.Focus()
                Exit Sub
            End If
        End If


        'If e.Result.Tables(0).rows.count = 0 Then       'Invalid Box ID or SN
        '    Me.ShowMessage("^SFC-69@" + vbCrLf + txtIntSerial.Text, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        '    txtIntSerial.SelectAll()
        '    txtIntSerial.Focus()
        'Else
        '    Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)

        '    If txtPONo.Text <> "" Then
        '        If txtModelNo.Text <> e.Result.Tables(0).rows(0)("Model").ToString Then          'the products' model are defferent with DJ's
        '            Me.ShowMessage("^SFC-67@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        '            txtIntSerial.SelectAll()
        '            txtIntSerial.Focus()
        '            Exit Sub
        '        End If
        '    End If

        'If DSList.Tables("SNList").Rows.Count = 0 Then 'the first box or product input

        '    Customer = e.Result.Tables(0).rows(0)("Customer").ToString
        '    CustomerPN = e.Result.Tables(0).rows(0)("CustomerPN").ToString
        '    CurDJ = e.Result.Tables(0).rows(0)("DJNo").ToString
        '    If txtIntSerial.Text = e.Result.Tables(0).rows(0)("ExtSN").ToString Then     'not the BoxID
        '        BoxFlag = "0"
        '        Dim myDataRow As DataRow
        '        Dim drInList() As DataRow
        '        For Each drSN As DataRow In e.Result.Tables(0).rows
        '            drInList = DSList.Tables("SNList").Select("ExtSN = '" & drSN("ExtSN") & "'")
        '            If drInList.Length = 0 Then
        '                myDataRow = DSList.Tables("SNList").NewRow()
        '                myDataRow("ExtSN") = drSN("ExtSN")
        '                myDataRow("BoxID") = drSN("BoxID")
        '                myDataRow("Choose") = True
        '                DSList.Tables("SNList").Rows.Add(myDataRow)
        '                total = total + 1
        '            End If
        '        Next
        '    Else
        '        BoxFlag = "1"
        '        Dim myDataRow As DataRow
        '        Dim drInList() As DataRow
        '        If e.Result.Tables(0).rows(0)("ExtSN").ToString.Contains("^") Then
        '            dgvResult.Enabled = True
        '        End If
        '        For Each drSN As DataRow In e.Result.Tables(0).rows
        '            drInList = DSList.Tables("SNList").Select("ExtSN = '" & drSN("ExtSN") & "'")
        '            If drInList.Length = 0 Then
        '                myDataRow = DSList.Tables("SNList").NewRow()
        '                myDataRow("ExtSN") = drSN("ExtSN")
        '                myDataRow("BoxID") = drSN("BoxID")
        '                myDataRow("Choose") = False
        '                DSList.Tables("SNList").Rows.Add(myDataRow)
        '                'total = total + 1
        '            End If
        '        Next
        '    End If

        'Else              'not the first box or product input
        '    If DSList.Tables("SNList").Rows(0)("BoxID").ToString <> e.Result.Tables(0).rows(0)("BoxID").ToString Then         'the products' BoxID are defferent with the list's
        '        Me.ShowMessage("^SFC-70@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        '        txtIntSerial.SelectAll()
        '        txtIntSerial.Focus()
        '        Exit Sub
        '    End If
        '    If BoxFlag = "0" Then     'not the BoxID
        '        If txtIntSerial.Text = e.Result.Tables(0).rows(0)("ExtSN").ToString Then     'not the BoxID
        '            Dim drExtInList() As DataRow
        '            drExtInList = DSList.Tables("SNList").Select("ExtSN = '" & txtIntSerial.Text & "'")
        '            If drExtInList.Length = 0 Then
        '                Dim myDataRow As DataRow
        '                myDataRow = DSList.Tables("SNList").NewRow()
        '                myDataRow("ExtSN") = e.Result.Tables(0).rows(0)("ExtSN")
        '                myDataRow("BoxID") = e.Result.Tables(0).rows(0)("BoxID")
        '                myDataRow("Choose") = True
        '                DSList.Tables("SNList").Rows.Add(myDataRow)
        '                total = total + 1
        '                'Else
        '                '    'exist on the list
        '                '    Exit Sub
        '            End If
        '        Else
        '            'invalid input
        '            Me.ShowMessage("^SFC-69@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        '            'Exit Sub
        '        End If
        '    Else
        '        If txtIntSerial.Text = e.Result.Tables(0).rows(0)("ExtSN").ToString Then     'not the BoxID
        '            Dim drExtInList() As DataRow
        '            drExtInList = DSList.Tables("SNList").Select("ExtSN = '" & txtIntSerial.Text & "'")
        '            If drExtInList.Length = 1 Then   ' on the list
        '                If Not drExtInList(0)("Choose") Then
        '                    drExtInList(0)("Choose") = True
        '                    total = total + 1
        '                    'Else
        '                    '    'already select the productSN
        '                    '    Exit Sub
        '                End If
        '                'Else                                               'the products' BoxID are defferent with the list's  ----had show message on perious
        '                '    'invalid SN
        '                '    Exit Sub
        '            End If
        '            'Else
        '            '    'invalid input

        '        End If
        '    End If

        'End If

        'If total = 0 Then        'the first box or product input
        '    If txtPONo.Text = "" Then
        '        txtModelNo.Text = e.Result.Tables(0).rows(0)("Model").ToString
        '    End If
        '    Customer = e.Result.Tables(0).rows(0)("Customer").ToString
        '    CustomerPN = e.Result.Tables(0).rows(0)("CustomerPN").ToString
        '    CurDJ = e.Result.Tables(0).rows(0)("DJNo").ToString
        '    txtPONo.Enabled = False     'not allow input DJ after input box/sn.
        'Else

        '    If DSList.Tables("SNList").Rows(0)("BoxID").ToString <> e.Result.Tables(0).rows(0)("BoxID").ToString Then         'the products' BoxID are defferent with the list's
        '        Me.ShowMessage("^SFC-70@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        '        txtIntSerial.SelectAll()
        '        txtIntSerial.Focus()
        '        Exit Sub
        '    End If
        'End If

        'Dim myDataRow As DataRow
        'Dim drInList() As DataRow
        'For Each drSN As DataRow In e.Result.Tables(0).rows
        '    drInList = DSList.Tables("SNList").Select("ExtSN = '" & drSN("ExtSN") & "'")
        '    If drInList.Length = 0 Then
        '        myDataRow = DSList.Tables("SNList").NewRow()
        '        myDataRow("ExtSN") = drSN("ExtSN")
        '        myDataRow("BoxID") = drSN("BoxID")
        '        myDataRow("Choose") = True
        '        DSList.Tables("SNList").Rows.Add(myDataRow)
        '        total = total + 1
        '    End If
        'Next
        'If Mid(txtIntSerial.Text, 1, 1).ToUpper = "B" Then
        '    txtPCBASerial.Focus()
        'End If
        txtIntSerial.Focus()
        txtIntSerial.Text = ""
        txtExtSerial.Text = total.ToString
        Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        If Emifile = "" Then Emifile = BLL.getMIFileData(txtModelNo.Text.Trim, txtModelNo.Text.Trim, CurrProcess)
        If (Not Emifile Is Nothing) Then
            btnEMI.Visible = True
        End If

    End Sub

    Private Sub txtPCBASerial_ValidateData() Handles txtPCBASerial.ValidateData
        txtPCBASerial.Text = Trim(txtPCBASerial.Text)
        'If total = 0 Then
        '    Me.ShowMessage("^SFC-72@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        '    txtPCBASerial.Text = ""
        '    txtIntSerial.Focus()
        '    Exit Sub
        'End If
        If Mid(txtPCBASerial.Text, 1, 1).ToUpper <> "B" And Mid(txtPCBASerial.Text, 1, 2).ToUpper <> "LE" Then
            Me.ShowMessage("^TDC-106@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtPCBASerial.SelectAll()
            txtPCBASerial.Focus()
            Exit Sub
        End If

        If txtPCBASerial.Text = DSList.Tables("SNList").Rows(0)("BoxID").ToString Then
            Me.ShowMessage("^SFC-75@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtPCBASerial.SelectAll()
            txtPCBASerial.Focus()
            Exit Sub
        End If
        Exit Sub
    End Sub


    Private Sub bgwPost_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwPost.DoWork
        Try
            'e.Result = BLL.ChangeBox(txtIntSerial.Text, txtExtSerial.Text, txtPCBASerial.Text, user)
            e.Result = BLL.SNListChangeBox(DSList)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub bgwPost_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPost.RunWorkerCompleted
        If e.Result = "^TDC-145@" Then
            Me.ShowMessage(e.Result + "  " + txtExtSerial.Text, eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
            cleardataInput()
        Else
            Me.ShowMessage(e.Result, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        End If
    End Sub


    Private Sub cleardataInput()
        Me.DisableValidation = True
        grpDataInput.Enabled = True
        btnPost.Enabled = True
        txtIntSerial.Text = ""
        BoxFlag = ""
        txtIntSerial.Focus()
        Me.txtExtSerial.Text = "0"
        total = 0
        DSList.Tables("SNList").Clear()
        DSList.Tables("NewBox").Clear()
        txtPCBASerial.Text = ""
        If txtPONo.Text <> "" Then
            Exit Sub
        End If
        txtPONo.Enabled = True
        txtPONo.Modified = True
        txtPONo.ReadOnly = False
        txtModelNo.Text = ""
        DisableValidation = False
        txtPCBANo.Text = ""
        btnEMI.Visible = False
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        If total > 0 And txtPCBASerial.Text <> "" Then
            If Me.ShowMessage("^SFC-73@" + " " + total.ToString + " " + "^SFC-74@" + " " + txtPCBASerial.Text, eTraceUI.eTraceMessageBar.MessageTypes.Warning, AnimationStatus.StopAnim, True, PopUpTypes.Question) = True Then
                DSList.Tables("NewBox").Clear()
                Dim myDataRow As DataRow
                myDataRow = DSList.Tables("NewBox").NewRow()
                myDataRow("NewBoxID") = txtPCBASerial.Text
                myDataRow("CurBoxID") = DSList.Tables("SNList").Rows(0)("BoxID").ToString
                myDataRow("NewDJ") = txtPONo.Text
                myDataRow("ModelRev") = ModelRev
                myDataRow("CurDJ") = CurDJ
                myDataRow("ChangeDJ") = ChangeDJ
                myDataRow("Model") = txtModelNo.Text
                myDataRow("CurCustomer") = Customer
                myDataRow("CurCustomerPN") = CustomerPN
                myDataRow("ChangeQty") = total
                myDataRow("Operator") = user
                myDataRow("InvOrg") = BLL.LoginData.OrgCode
                DSList.Tables("NewBox").Rows.Add(myDataRow)
                savesate()
            Else
                Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            End If
        End If
    End Sub

    Private Sub savesate()
        If txtIntSerial.Highlight = True Then Exit Sub
        If txtPCBASerial.Highlight = True Then Exit Sub
        bgwPost.RunWorkerAsync()
    End Sub

    Private Sub frmChangeBox_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Try
            SerialPort1.Open()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmChangeBox_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
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
        Me.DisableValidation = True
        grpDataInput.Enabled = True
        btnPost.Enabled = True
        txtIntSerial.Text = ""
        txtIntSerial.Focus()
        Me.txtExtSerial.Text = "0"
        BoxFlag = ""
        total = 0
        lblMsg.Text = ""
        DSList.Tables("SNList").Clear()
        DSList.Tables("NewBox").Clear()
        txtPONo.Text = ""
        txtPCBASerial.Text = ""
        txtPONo.Enabled = True
        txtPONo.Modified = True
        txtPONo.ReadOnly = False
        txtModelNo.Text = ""
        DisableValidation = False
        txtPCBANo.Text = ""
        btnEMI.Visible = False
    End Sub

  

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ClearDataInput()
    End Sub

    Private Sub txtPONo_ValidateData() Handles txtPONo.ValidateData
        txtPONo.Text = Trim(txtPONo.Text)
        If txtPONo.Enabled = True And txtPONo.ReadOnly = False Then
            'Modified not working? - fixed by modified eTraceUI.textbox
            If Trim(txtPONo.Text) <> "" Then
                Me.ShowMessage("^TDC-3@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
                pnlBody.Enabled = False
                Me.bgwPO.RunWorkerAsync()
                txtPONo.Modified = False
            End If
        End If
    End Sub

    Private Sub bgwPO_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwPO.DoWork
        Try
            e.Result = BLL.DJValidation(txtPONo.Text, "3", BLL.LoginData)
        Catch ex As Exception
            BLL.ErrorLogging("ChangeBox-bgwPO_DoWork", user, ex.Message)
        End Try
    End Sub

    Private Sub bgwPO_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPO.RunWorkerCompleted
        Try
            pnlBody.Enabled = True
            If e.Result.tables("ErrorMsg").rows.count > 0 Or e.Result.tables("DJInfo").rows(0)("PRODUCT_NUMBER").ToString.Trim = "" Then
                Me.ShowMessage("^TDC-29@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtPONo.Modified = True
                pnlBody.Enabled = True
                txtPONo.SelectAll()
                txtPONo.Focus()
            Else
                'If Mid(txtPONo.Text, 1, 1).ToUpper = "P" Or Mid(txtPONo.Text, 1, 1).ToUpper = "M" Then
                'If SFC019.Contains(Mid(txtPONo.Text, 1, 1).ToUpper) Then
                If e.Result.Tables("DJInfo").Rows(0)("DJType") = "Standard" Then
                    ChangeDJ = "N"
                    lblMsgShow("^SFC-98@")
                    lblMsg.Visible = True
                    lblMsg.ForeColor = Color.Red
                Else
                    ChangeDJ = "Y"
                    lblMsgShow("^SFC-99@")
                    lblMsg.Visible = True
                    lblMsg.ForeColor = Color.Green
                End If
                txtPONo.ReadOnly = True
                txtModelNo.Text = e.Result.tables("DJInfo").rows(0)("PRODUCT_NUMBER").ToString
                ModelRev = e.Result.tables("DJInfo").Rows(0)("DJ_REVISION")
                POQty = e.Result.tables("DJInfo").Rows(0)("ORDER_QUANTITY")
                Emifile = BLL.getMIFileData(txtModelNo.Text.Trim, txtModelNo.Text.Trim, CurrProcess)
                BLL.CountPoQty(BLL.LoginData.OrgCode, txtPONo.Text, txtModelNo.Text, txtPCBANo.Text, POQty, ModelRev)
                txtIntSerial.Focus()
                Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            End If
        Catch ex As Exception
            BLL.ErrorLogging("ChangeBox-bgwPO_RunWorkerCompleted", user, ex.Message)
        End Try
    End Sub

    Private Sub AddSNListTable(ByVal DS As DataSet)
        Dim SNList As DataTable
        Dim myDataColumn As DataColumn
        SNList = New Data.DataTable("SNList")
        myDataColumn = New Data.DataColumn("ExtSN", System.Type.GetType("System.String"))
        SNList.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("BoxID", System.Type.GetType("System.String"))
        SNList.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("Choose", System.Type.GetType("System.Boolean"))
        SNList.Columns.Add(myDataColumn)
        DS.Tables.Add(SNList)
        Dim NewBox As DataTable
        NewBox = New Data.DataTable("NewBox")
        myDataColumn = New Data.DataColumn("NewBoxID", System.Type.GetType("System.String"))
        NewBox.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("CurBoxID", System.Type.GetType("System.String"))
        NewBox.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("NewDJ", System.Type.GetType("System.String"))
        NewBox.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("ModelRev", System.Type.GetType("System.String"))
        NewBox.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("CurDJ", System.Type.GetType("System.String"))
        NewBox.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("ChangeDJ", System.Type.GetType("System.String"))
        NewBox.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("Model", System.Type.GetType("System.String"))
        NewBox.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("CurCustomer", System.Type.GetType("System.String"))
        NewBox.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("CurCustomerPN", System.Type.GetType("System.String"))
        NewBox.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("ChangeQty", System.Type.GetType("System.String"))
        NewBox.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("Operator", System.Type.GetType("System.String"))
        NewBox.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("InvOrg", System.Type.GetType("System.String"))
        NewBox.Columns.Add(myDataColumn)
        DS.Tables.Add(NewBox)
        dgvResult.DataSource = DS
        dgvResult.DataMember = "SNList"
    End Sub

    Private Sub dgvResult_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvResult.KeyDown
        If (e.KeyCode = Keys.Delete And dgvResult.SelectedRows.Count <> 0) Then
            For Each dgvr As DataGridViewRow In dgvResult.SelectedRows
                If DSList.Tables("SNList").Rows(dgvr.Index)("Choose") Then
                    total = total - 1
                End If
                DSList.Tables("SNList").Rows(dgvr.Index).Delete()
            Next
            txtExtSerial.Text = total.ToString
        End If
    End Sub


    Private Sub dgvResult_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvResult.CellContentClick
        If dgvResult.ReadOnly Then
            Exit Sub
        End If
        If e.ColumnIndex = 2 Then
            If e.RowIndex >= 0 Then

                DSList.Tables("SNList").Rows(e.RowIndex)(2) = Not DSList.Tables("SNList").Rows(e.RowIndex)(2)

                If DSList.Tables("SNList").Rows(e.RowIndex)(2) Then
                    total = total + 1
                Else
                    total = total - 1
                End If
                txtExtSerial.Text = total.ToString
            End If
        End If
    End Sub

    Private Sub dgvResult_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvResult.CellContentDoubleClick
        If dgvResult.ReadOnly Then
            Exit Sub
        End If
        If e.ColumnIndex = 2 Then
            If e.RowIndex >= 0 Then

                DSList.Tables("SNList").Rows(e.RowIndex)(2) = Not DSList.Tables("SNList").Rows(e.RowIndex)(2)

                If DSList.Tables("SNList").Rows(e.RowIndex)(2) Then
                    total = total + 1
                Else
                    total = total - 1
                End If
                txtExtSerial.Text = total.ToString
            End If
        End If
    End Sub

    Private Sub lblMsgShow(ByVal tag As String)
        lblMsg.Text = ComposeMessage(tag)
    End Sub
End Class
