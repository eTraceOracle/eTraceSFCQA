Public Class frmChangeRevision
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
        DSList = New DataSet("DS")
        AddSNListTable(DSList)
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
            'e.Result = BLL.GetShipInfoBySN(txtIntSerial.Text)
            e.Result = BLL.GetShipInfoByBoxIDSN(txtIntSerial.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub bgwIntSerial_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwIntSerial.RunWorkerCompleted
        pnlBody.Enabled = True
        If e.Result.Tables(0).rows.count = 0 Then       'Invalid Box ID or SN
            Me.ShowMessage("^SFC-69@" + vbCrLf + txtIntSerial.Text, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
        Else
            Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)

            If txtPONo.Text <> "" Then
                If txtModelNo.Text <> e.Result.Tables(0).rows(0)("Model").ToString Then          'the products' model are defferent with DJ's
                    Me.ShowMessage("^SFC-67@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtIntSerial.SelectAll()
                    txtIntSerial.Focus()
                    Exit Sub
                End If
            End If

            If total = 0 Then        'the first box or product input
                If txtPONo.Text = "" Then
                    txtModelNo.Text = e.Result.Tables(0).rows(0)("Model").ToString
                End If
                CurDJ = e.Result.Tables(0).rows(0)("DJNo").ToString
                txtPONo.Enabled = False     'not allow input DJ after input box/sn.

            Else
                If DSList.Tables("SNList").Rows(0)("BoxID").ToString <> e.Result.Tables(0).rows(0)("BoxID").ToString Then         'the products' BoxID are defferent with the list's
                    Me.ShowMessage("^SFC-70@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtIntSerial.SelectAll()
                    txtIntSerial.Focus()
                    Exit Sub
                End If
            End If

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
            txtIntSerial.Text = ""
            txtExtSerial.Text = total.ToString
            If Emifile = "" Then Emifile = BLL.getMIFileData(txtModelNo.Text.Trim, txtModelNo.Text.Trim, CurrProcess)
            If (Not Emifile Is Nothing) Then
                btnEMI.Visible = True
            End If
        End If
    End Sub

    Private Sub txtPCBASerial_ValidateData() Handles txtPCBASerial.ValidateData
        txtPCBASerial.Text = Trim(txtPCBASerial.Text)
        If total = 0 Then
            Me.ShowMessage("^SFC-81@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtPCBASerial.Text = ""
            txtIntSerial.Focus()
            Exit Sub
        End If
        Exit Sub
    End Sub


    Private Sub bgwPost_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwPost.DoWork
        Try
            e.Result = BLL.ChangeRevision(DSList)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub bgwPost_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPost.RunWorkerCompleted
        If e.Result = "^SFC-78@" Then
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
        txtIntSerial.Focus()
        Me.txtExtSerial.Text = "0"
        total = 0
        txtPOPCBA.Text = ""
        txtPONo.Enabled = True
        txtPONo.Modified = True
        txtPONo.ReadOnly = False
        txtModelNo.Text = ""
        txtQty.Text = ""
        DisableValidation = False
        txtPONo.Text = ""
        txtModelNo.Text = ""
        txtPCBANo.Text = ""
        txtPCBASerial.Text = ""
        txtNewTVA.Text = ""
        DSList.Tables("SNList").Clear()
        DSList.Tables("Revision").Clear()
        btnEMI.Visible = False
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        If total > 0 And (txtPCBASerial.Text <> "" Or txtNewTVA.Text <> "") Then

            If Me.ShowMessage("^SFC-79@" + " " + total.ToString + "^SFC-190@" +
                               IIf(txtPCBASerial.Text <> "", "^SFC-80@" + " " + txtPCBASerial.Text, "") +
                               IIf(txtNewTVA.Text <> "", "^SFC-189@" + " " + txtNewTVA.Text, ""),
                              eTraceUI.eTraceMessageBar.MessageTypes.Warning,
                              AnimationStatus.StopAnim,
                              True,
                              PopUpTypes.Question) = True Then
                DSList.Tables("Revision").Clear()
                Dim myDataRow As DataRow
                myDataRow = DSList.Tables("Revision").NewRow()
                myDataRow("NewRev") = txtPCBASerial.Text
                myDataRow("NewTVA") = txtNewTVA.Text
                myDataRow("Operator") = user
                myDataRow("InvOrg") = BLL.LoginData.OrgCode
                DSList.Tables("Revision").Rows.Add(myDataRow)
                savesate()
            End If
        Else
            If total = 0 Then
                Me.ShowMessage("^SFC-187@",
                               eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                               AnimationStatus.StopAnim,
                               True,
                               PopUpTypes.Message)
                Exit Sub
            End If

            If txtPCBASerial.Text = "" And txtNewTVA.Text = "" Then
                Me.ShowMessage("^SFC-188@",
                               eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                               AnimationStatus.StopAnim,
                               True,
                               PopUpTypes.Message)
                txtPCBASerial.Focus()
                Exit Sub
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
        cleardataInput()
    End Sub



    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        cleardataInput()
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
        NewBox = New Data.DataTable("Revision")
        myDataColumn = New Data.DataColumn("NewRev", System.Type.GetType("System.String"))
        NewBox.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("NewTVA", System.Type.GetType("System.String"))
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
End Class
