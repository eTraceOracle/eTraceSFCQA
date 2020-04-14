Public Class frmMatching1
    Public ProcessID As Integer
    Public CurrProcess As String
    Dim User As String
    Private dsModelStructure As DataSet
    Private dsPCBARouting As DataSet
    Dim dsWIP As DataSet
    Dim AllPass As Boolean
    Dim tmpRow As DataRow
    Dim TraceLevel As String
    Dim PanelSize As Integer
    Dim Emifile As Object
    Dim IntSNPattern As String
    Dim ChildItem As String
    Dim ReuseChildISN As Boolean = False
    Dim PropertyType As String
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
    Dim DJOrgCode As String
    Dim DJType As String
    Dim ordQty As Integer
    Dim SFC001 As String
    Dim SFC004 As String
    Dim SFC009 As Integer
    Dim SFC031 As String  'Matching1 checked DJ is Standard DJ or not

    Public Overrides Sub NewSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'New Instance of the form
        Dim NewInstance As New frmMain()
        NewInstance.ShowFrm(Me)
    End Sub

    Private Sub frmMatching1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'AttachHotkey(btnPost, Keys.F8)
        'AttachHotkey(btnNew, Keys.F5)
        'AttachHotkey(btnReset, Keys.F3)
        'AttachHotkey(btnPrint, Keys.F9)
        ProcessID = SelectProcessID
        CurrProcess = SelectProcess
        BindCtlsToProcess(Me, ProcessID)
        SFC001 = FixNull(dsConfig.Tables(0).Select("ConfigID='SFC001'")(0)("Value"))
        SFC004 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC004'")(0)("Value"))
        SFC009 = Convert.ToInt32(FixNull(dsConfig.Tables(0).Select("ConfigID='SFC009'")(0)("Value")))
        SFC031 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC031'")(0)("Value"))
        If SFC004.ToUpper = "NO" Then
            txtIntSerial.KeyIn = False
            txtPCBASerial.KeyIn = False
        Else
            txtIntSerial.KeyIn = True
            txtPCBASerial.KeyIn = True
        End If
        Me.ShowMessage(ProcessShow, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
    End Sub

    Private Sub frmMatching1_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        ddlProcess.Text = ProcessShow
        Me.CenterToScreen()
        User = Mid(UserName.Text, 1, InStr(UserName.Text, "-") - 1).Trim
        BLL.LoginData.User = User
        BLL.LoginData.OrgCode = MyOrg()
        BLL.LoginData.ProductionLine = ProductionLine()
        txtPONo.Focus()
    End Sub

    Private Sub txtPONo_ValidateData() Handles txtPONo.ValidateData
        Try

            txtPONo.Text = Trim(txtPONo.Text)
            Dim CompIssueToDJ As String
            CompIssueToDJ = BLL.CheckCompIssueToDJ(txtPONo.Text)
            If CompIssueToDJ <> "0" Then
                Me.ShowMessage(CompIssueToDJ, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtPONo.SelectAll()
                txtPONo.Focus()
                Exit Sub
            End If
            If txtPONo.Enabled = True And txtPONo.ReadOnly = False Then
                'Modified not working? - fixed by modified eTraceUI.textbox
                If Trim(txtPONo.Text) <> "" And txtPONo.Modified Then
                    Me.ShowMessage("^TDC-3@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
                    pnlBody.Enabled = False
                    Me.bgwPO.RunWorkerAsync()
                    txtPONo.Modified = False
                End If
            End If

        Catch ex As Exception
            If ex.GetType() Is GetType(System.Net.WebException) Then
                Me.ShowMessage("^SFC-169@",
                               eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                               AnimationStatus.StopAnim,
                               True,
                               PopUpTypes.Message,,
                               GetReportLink(txtIntSerial.Text))
                pnlBody.Enabled = True
            Else
                Me.ShowMessage("ERROR: " & ex.Message, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                pnlBody.Enabled = True
            End If
        End Try
    End Sub

    Private Sub bgwPO_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwPO.DoWork
        'Try
        e.Result = BLL.DJValidation(txtPONo.Text, "3", BLL.LoginData)
        'Catch ex As Exception
        '    BLL.ErrorLogging("Matching1-bgwPO_DoWork", User, ex.Message)
        'End Try
    End Sub

    Private Sub bgwPO_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPO.RunWorkerCompleted
        Try
            pnlBody.Enabled = True
            If e.Error IsNot Nothing Then
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
                Return
            End If
            If e.Result.tables("ErrorMsg").rows.count > 0 Then 'Or e.Result.Tables("DJInfo").Rows(0)("DJType") <> "Standard"
                Me.ShowMessage("^TDC-29@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtPOPCBA.Text = ""
                txtPOPCBA.Visible = False
                txtPONo.Modified = True
                txtQty.Text = 0
                txtQty.Visible = False
                pnlBody.Enabled = True
                txtPONo.SelectAll()
                txtPONo.Focus()
            Else
                If e.Result.Tables("DJInfo").Rows(0)("DJType") <> "Standard" Then
                    If SFC031 = "YES" Then
                        Me.ShowMessage("^TDC-29@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                        txtPOPCBA.Text = ""
                        txtPOPCBA.Visible = False
                        txtPONo.Modified = True
                        txtQty.Text = 0
                        txtQty.Visible = False
                        pnlBody.Enabled = True
                        txtPONo.SelectAll()
                        txtPONo.Focus()
                        Exit Sub
                    End If
                End If
                OrderInfo.matlno = e.Result.tables("DJInfo").rows(0)("PRODUCT_NUMBER").ToString
                OrderInfo.Openqty = e.Result.tables("DJInfo").rows(0)("OPEN_QUANTITY")
                OrderInfo.OrderQty = e.Result.tables("DJInfo").rows(0)("ORDER_QUANTITY")
                OrderInfo.ModelRev = e.Result.tables("DJInfo").rows(0)("DJ_REVISION").ToString
                DJOrgCode = e.Result.tables("DJInfo").rows(0)("OrgCode").ToString
                DJType = e.Result.tables("DJInfo").rows(0)("DJType").ToString
                txtPOPCBA.Text = OrderInfo.matlno
                txtPOPCBA.Visible = True
                'txtQty.Text = OrderInfo.OrderQty        'can not be showed at once, because PCBA qty maybe double the DJ qty. 
                ordQty = OrderInfo.OrderQty
                txtQty.Visible = True
                txtProdQty.Visible = True
                txtModelNo.Focus()
                Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            End If
        Catch ex As Exception
            If ex.GetType() Is GetType(System.Net.WebException) Then
                Me.ShowMessage("^SFC-169@",
                               eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                               AnimationStatus.StopAnim,
                               True,
                               PopUpTypes.Message)
                pnlBody.Enabled = True
            Else
                Me.ShowMessage("ERROR: " & ex.Message, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                BLL.ErrorLogging("Matching1-bgwPO_RunWorkerCompleted", User, ex.Message)
                pnlBody.Enabled = True
            End If

        End Try

    End Sub

    Private Sub txtModelNo_ValidateData() Handles txtModelNo.ValidateData
        txtModelNo.Text = Trim(txtModelNo.Text)
        If txtModelNo.Text <> "" And txtModelNo.Modified Then
            If Trim(txtPCBANo.Text) = "" And txtPCBANo.Required = True Then
                txtPCBANo.Focus()
            ElseIf txtPOPCBA.Text.ToUpper = "NOERP" Or txtPCBANo.Text = txtPOPCBA.Text Or txtModelNo.Text = txtPOPCBA.Text Then
                ShowInputFields()
            Else
                Me.ShowMessage("^TDC-4@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                grpDataInput.Visible = False
                grpActions.Visible = False
                btnEMI.Visible = False
                txtPCBANo.SelectAll()
                txtPCBANo.Focus()
            End If
            txtModelNo.Modified = False
        End If
    End Sub
    Private Sub txtPCBANo_ValidateData() Handles txtPCBANo.ValidateData
        txtPCBANo.Text = Trim(txtPCBANo.Text)
        If txtPCBANo.Enabled = True And txtPCBANo.ReadOnly = False Then
            If Trim(txtPCBANo.Text) <> "" And txtPCBANo.Modified Then
                If Trim(txtModelNo.Text) = "" Then
                    txtModelNo.Focus()
                ElseIf txtPOPCBA.Text.ToUpper = "NOERP" Or txtPCBANo.Text = txtPOPCBA.Text Or txtModelNo.Text = txtPOPCBA.Text Then
                    ShowInputFields()
                Else
                    Me.ShowMessage("^TDC-4@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    grpDataInput.Visible = False
                    grpActions.Visible = False
                    txtPCBANo.SelectAll()
                    txtPCBANo.Focus()
                End If
                txtPCBANo.Modified = False
            End If
        End If
    End Sub
    Private Sub ShowInputFields()
        Try
            'get model structure
            dsModelStructure = New DataSet
            dsModelStructure = BLL.ModelStructure(txtModelNo.Text)
            If dsModelStructure.Tables("ModelStructure").Rows.Count = 0 Then
                Me.ShowMessage("^SFC-44@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                grpDataInput.Visible = False
                grpActions.Visible = False
                txtModelNo.SelectAll()
                txtModelNo.Focus()
                Return
            End If
            If dsModelStructure.Tables("ModelStructure").Rows(0)(0).ToString = "^TDC-1@ ^TDC-5@" Then        'product data not defined
                Me.ShowMessage("^TDC-619@" + txtModelNo.Text + " ^TDC-620@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                grpDataInput.Visible = False
                grpActions.Visible = False
                txtModelNo.SelectAll()
                txtModelNo.Focus()
                Return
            End If

            IntSNPattern = BLL.IntSNPattern(txtModelNo.Text)
            Dim dr() As DataRow
            Dim PCBAQty As Integer
            dr = dsModelStructure.Tables("ModelStructure").Select("PCBA ='" & txtPCBANo.Text & "' and Process = 'Matching1'")
            If dr.Length = 0 Then
                Me.ShowMessage("^TDC-619@" + txtModelNo.Text + " ^TDC-620@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                grpDataInput.Visible = False
                grpActions.Visible = False
                txtModelNo.SelectAll()
                txtModelNo.Focus()
                Return
            End If

            'get PCBA routing of the model, it is used when saveResult. if the PCBA only has matching1 process. allPass will be true.
            dsPCBARouting = New DataSet
            dsPCBARouting = BLL.PCBARouting(txtModelNo.Text, txtPCBANo.Text)
            TraceLevel = BLL.getTraceLevel(txtModelNo.Text)
            PanelSize = BLL.getPanelSize(txtModelNo.Text, txtPCBANo.Text)
            If dsPCBARouting.Tables("PCBARouting").Rows.Count = 1 Then    'OrElse dsPCBARouting.Tables("PCBARouting").Rows(1)("Process").ToString = "Packing"
                AllPass = True
            Else
                AllPass = False
            End If

            Dim dsStructurePCBA As DataSet
            Dim drStructurePCBA() As DataRow
            dsStructurePCBA = BLL.StructureReadByPCBA(txtModelNo.Text, txtPCBANo.Text, 1)
            drStructurePCBA = dsStructurePCBA.Tables(0).Select("Model='" & txtModelNo.Text & "' and PCBA ='" & txtPCBANo.Text & "'")
            If drStructurePCBA(0)("ReuseChildISN") Then
                ReuseChildISN = True
                ChildItem = drStructurePCBA(0)("ChildItem")
            End If

            'begin get PCBA qty of require on mathing1
            If dr(0)("IsTLA").ToString = "" Then
                Me.ShowMessage("^SFC-96@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                grpDataInput.Visible = False
                grpActions.Visible = False
                txtModelNo.SelectAll()
                txtModelNo.Focus()
                Return
            End If
            If Convert.ToBoolean(dr(0)("IsTLA")) Then
                If DJType <> "Standard" Then
                    Me.ShowMessage("^SFC-178@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtPCBANo.SelectAll()
                    txtPCBANo.Focus()
                    Return
                End If
                txtQty.Text = ordQty.ToString
            Else
                If dr(0)("SubPCBA").ToString = "" Then   'no assy boards on the PCBA, means it is the smallest board
                    dr = dsModelStructure.Tables("ModelStructure").Select("SubPCBA ='" & txtPCBANo.Text & "'")

                    Dim i As Integer
                    For i = 0 To dr.Length - 1
                        PCBAQty = PCBAQty + Convert.ToInt32(dr(i)("Qty"))
                    Next
                    txtQty.Text = (ordQty * PCBAQty).ToString
                    dr = Nothing
                Else                                     'some assy boards on PCBA.
                    Dim drSubPCBA() As DataRow
                    drSubPCBA = dsModelStructure.Tables("ModelStructure").Select("SubPCBA ='" & txtPCBANo.Text & "'")
                    Dim i As Integer
                    For i = 0 To drSubPCBA.Length - 1
                        PCBAQty = PCBAQty + Convert.ToInt32(drSubPCBA(i)("Qty"))
                        'PCBAQty = PCBAQty + NeedMathingQty(drSubPCBA(i))
                    Next
                    txtQty.Text = (ordQty * PCBAQty).ToString
                End If
            End If
            'end get PCBA qty of require on mathing1

            AddPCBATable(dsModelStructure)
            Dim SubPCBAqty As Integer
            Dim myDataRow As DataRow
            If Not dr Is Nothing Then
                PropertyType = dr(0)("PropertyType").ToString
                For Each drPCBA As DataRow In dr
                    If drPCBA("Qty").ToString <> "" Then
                        For SubPCBAqty = 1 To drPCBA("Qty")
                            myDataRow = dsModelStructure.Tables("PCBAList").NewRow()
                            myDataRow(0) = drPCBA("SubPCBA")
                            myDataRow(1) = drPCBA("SubPCBADesc")
                            dsModelStructure.Tables("PCBAList").Rows.Add(myDataRow)
                        Next
                    End If
                Next
            End If
            If dsModelStructure.Tables("PCBAList").Rows.Count > 0 Then    ' more than 1 board
                'Fill dgv here
                dgvPCBA.DataSource = dsModelStructure
                dgvPCBA.DataMember = "PCBAList"
                dgvPCBA.Visible = True
                txtPCBASerial.Required = True
                txtPCBASerial.Visible = True
                txtPCBASerial.ReadOnly = False
            Else
                txtPCBASerial.Required = False
                txtPCBASerial.Visible = False
                txtPCBASerial.ReadOnly = True
                lblPCBASerial.Visible = False
                dgvPCBA.Visible = False
                dgvPCBA.Enabled = False

            End If
            Me.ShowMessage("^TDC-67@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
            Me.bgwPoQty.RunWorkerAsync()
            'grpDataInput.Visible = True
            grpActions.Visible = True
            grpModel.Enabled = False
        Catch ex As Exception
            If ex.GetType() Is GetType(System.Net.WebException) Then
                Me.ShowMessage("^SFC-169@",
                               eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                               AnimationStatus.StopAnim,
                               True,
                               PopUpTypes.Message,,
                               GetReportLink(txtIntSerial.Text))
                pnlBody.Enabled = True
            Else
                Me.ShowMessage("ERROR: " & ex.Message, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                BLL.ErrorLogging("Matching1-ShowInputFields", User, ex.Message)
                pnlBody.Enabled = True
            End If

        End Try

    End Sub
    Dim NeedQty As Integer = 0
    Function NeedMathingQty(ByVal drSubPCBA As DataRow) As Integer
        'If Convert.ToBoolean(drSubPCBA("IsTLA")) Then
        '    Return Convert.ToInt32(drSubPCBA("Qty"))
        'Else
        Dim drPCBAMatching() As DataRow
        drPCBAMatching = dsModelStructure.Tables("ModelStructure").Select("SubPCBA ='" & drSubPCBA("PCBA") & "'")
        Dim i As Integer
        For i = 0 To drPCBAMatching.Length - 1
            NeedQty = NeedQty + Convert.ToInt32(drSubPCBA("Qty")) * NeedMathingQty(drPCBAMatching(i))
        Next
        Return NeedQty
        'End If
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

    Private Sub bgwPoQty_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwPoQty.DoWork
        'Try
        BLL.CountPoQtyII(DJOrgCode, txtPONo.Text, txtModelNo.Text, txtPCBANo.Text, Convert.ToInt32(txtQty.Text), OrderInfo.ModelRev, DJType)
        e.Result = BLL.GetDJMatchedQty(txtPONo.Text, txtPCBANo.Text, DJOrgCode)
        'Catch ex As Exception
        '    BLL.ErrorLogging("Matching1-bgwPoQty_DoWork", User, ex.Message)
        'End Try
    End Sub

    Private Sub bgwPoQty_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPoQty.RunWorkerCompleted

        Try
            If e.Error IsNot Nothing Then
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
                Return
            End If
            txtProdQty.Text = e.Result
            Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            Dim dsPOQty As DataSet
            dsPOQty = BLL.ReadPOQtyByPOAndPCBA(txtPONo.Text, txtPCBANo.Text)
            If dsPOQty.Tables(0).Rows(0)("TVA").ToString <> "" Then
                txtTVANo.Text = dsPOQty.Tables(0).Rows(0)("TVA").ToString
            End If
            If Not dsPOQty.Tables(0).Rows(0)("AllowMatching") Then
                Me.ShowMessage("^SFC-113@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                grpModel.Enabled = True
                grpActions.Visible = False
                txtPCBANo.Text = ""
                txtModelNo.Text = ""
                txtPONo.SelectAll()
                txtPONo.Focus()
                Exit Sub
            End If
            grpDataInput.Visible = True
            txtIntSerial.Focus()
            Emifile = BLL.getMIFileData(txtModelNo.Text.Trim, txtPCBANo.Text.Trim, CurrProcess)
            If (Not Emifile Is Nothing) Then
                btnEMI.Visible = True
            End If
        Catch ex As Exception
            If ex.GetType() Is GetType(System.Net.WebException) Then
                Me.ShowMessage("^SFC-169@",
                               eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                               AnimationStatus.StopAnim,
                               True,
                               PopUpTypes.Message,,
                               GetReportLink(txtIntSerial.Text))
                pnlBody.Enabled = True
            Else
                Me.ShowMessage("ERROR: " & ex.Message, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                BLL.ErrorLogging("Matching1-bgwPoQty_RunWorkerCompleted", User, ex.Message)
                pnlBody.Enabled = True
            End If

        End Try

    End Sub

    Private Sub txtIntSerial_ValidateData() Handles txtIntSerial.ValidateData
        txtIntSerial.Text = Trim(txtIntSerial.Text)
        If txtIntSerial.Text.Length < SFC009 Then
            Me.ShowMessage("^TDC-23@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtIntSerial.Text = ""
            txtIntSerial.Focus()
            Exit Sub
        End If
        If IntSNPattern <> "" And txtModelNo.Text = txtPCBANo.Text Then
            If Not BLL.AlphanumericValidation(txtIntSerial.Text, IntSNPattern) Then
                Me.ShowMessage("^SFC-167@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True)
                txtIntSerial.Text = ""
                txtIntSerial.Focus()
                Exit Sub
            End If
        End If
        Me.ShowMessage("^TDC-24@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False) 'Validating Serial number, please wait...
        pnlBody.Enabled = False
        Me.bgwIntSerial.RunWorkerAsync()
    End Sub

    Private Sub bgwIntSerial_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwIntSerial.DoWork
        'Try
        If ReuseChildISN Then
            e.Result = 0
        Else
            e.Result = BLL.IntSNIsValid(txtIntSerial.Text)
        End If
        'Catch ex As Exception
        '    BLL.ErrorLogging("Matching1-bgwIntSerial_DoWork", User, ex.Message)
        '    Me.ShowMessage(ex.Message, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        'End Try
    End Sub

    Private Sub bgwIntSerial_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwIntSerial.RunWorkerCompleted
        pnlBody.Enabled = True
        If e.Error Is Nothing Then
            Try
                If e.Result <> "0" Then  'e.Result = ^TDC-154@  SerialNo Is AccessCard   OR  '^TDC-6@  This Serial number is already in use!
                    Me.ShowMessage(e.Result,
                                   eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                                   AnimationStatus.StopAnim,
                                   True,
                                   PopUpTypes.Message,,
                                   GetReportLink(txtIntSerial.Text))
                    txtIntSerial.SelectAll()
                    txtIntSerial.Focus()
                    Exit Sub
                End If
                'End If
                If PropertyType = "FG" Then
                    Dim ModelSNValid As String
                    ModelSNValid = BLL.ModelConfiguratorSNValid(txtIntSerial.Text)
                    If Not ModelSNValid.Contains("^SFC-172@") Then  'is not a finished product
                        'not allow input finished product SN
                        Me.ShowMessage("ERROR: " & txtIntSerial.Text & " ^SFC-174@",
                                   eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                                   AnimationStatus.StopAnim,
                                   True,
                                   PopUpTypes.Message,,)
                        txtIntSerial.SelectAll()
                        txtIntSerial.Focus()
                        Exit Sub
                    End If
                End If

                If ReuseChildISN Then
                    txtPCBASerial.Text = txtIntSerial.Text
                    txtPCBASerial_ValidateData()
                    Exit Sub
                End If

                dsWIP = BLL.DSWIP()
                Dim dr As DataRow
                dr = dsWIP.Tables("WIPHeader").NewRow()
                dr("IntSN") = txtIntSerial.Text
                dr("Model") = txtModelNo.Text
                dr("PCBA") = txtPCBANo.Text
                dr("DJ") = txtPONo.Text
                dr("TVA") = txtTVANo.Text
                dr("InvOrg") = DJOrgCode
                dr("ProdLine") = ProductionLine()
                dr("CurrentProcess") = CurrProcess
                dr("TestRound") = 1
                dr("Result") = "PASS"
                dr("AllPassed") = AllPass
                dr("ReuseChildISN") = ReuseChildISN
                dr("MotherBoardSN") = ""
                dr("ChangedBy") = User
                dsWIP.Tables("WIPHeader").Rows.Add(dr)
                If txtPCBASerial.Visible Then     '
                    'Refresh dgvPCBA here...
                    Dim DataRow As DataRow
                    For Each DataRow In dsModelStructure.Tables("PCBAList").Rows
                        DataRow(2) = ""
                        DataRow(3) = ""
                        DataRow(4) = ""
                    Next
                    dsModelStructure.Tables("PCBAList").AcceptChanges()
                    txtPCBASerial.Focus()
                    Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
                Else
                    SaveResult()
                End If

            Catch ex As Exception
                If ex.GetType() Is GetType(System.Net.WebException) Then
                    Me.ShowMessage("^SFC-169@",
                                   eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                                   AnimationStatus.StopAnim,
                                   True,
                                   PopUpTypes.Message,,
                                   GetReportLink(txtIntSerial.Text))
                    pnlBody.Enabled = True
                Else
                    Me.ShowMessage("ERROR: " & ex.Message, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    pnlBody.Enabled = True
                End If
            End Try
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

    Private Sub SaveResult()
        Try
            If dsModelStructure.Tables("PCBAList").Rows.Count > 0 Then
                Dim DataRow As DataRow
                Dim dr As DataRow
                For Each DataRow In dsModelStructure.Tables("PCBAList").Rows
                    dr = dsWIP.Tables("WIPProperties").NewRow()
                    dr("PropertyType") = PropertyType
                    dr("PropertyName") = DataRow("SubPCBA")
                    dr("PropertyValue") = DataRow("PCBAWipID")
                    dsWIP.Tables("WIPProperties").Rows.Add(dr)
                Next
                dsWIP.Tables("WIPProperties").AcceptChanges()
            End If
            If BLL.MatchingAccount(txtPONo.Text, DJOrgCode, txtPCBANo.Text, 1, PanelSize) Then
                Me.ShowMessage("^TDC-26@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
                pnlBody.Enabled = False
                Me.bgwPost.RunWorkerAsync()
            Else
                Select Case SFC001.ToUpper
                    Case "WARNING"
                        'Warning: Matching Qty > PO Qty! Continue?
                        If Me.ShowMessage("^TDC-70@", eTraceUI.eTraceMessageBar.MessageTypes.Warning, AnimationStatus.StopAnim, True, PopUpTypes.Question) = True Then
                            If BLL.MatchingAccount(txtPONo.Text, DJOrgCode, txtPCBANo.Text, 0, PanelSize) = True Then
                                Me.bgwPost.RunWorkerAsync()
                            End If
                        Else
                            pnlBody.Enabled = True
                            txtProdQty.Text = BLL.GetDJMatchedQty(txtPONo.Text, txtPCBANo.Text, DJOrgCode)
                            'ready for input for next product
                            Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
                        End If
                    Case "ERROR"
                        'Error: Matching Qty > PO Qty!
                        Me.ShowMessage("^SFC-43@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                        pnlBody.Enabled = True
                        txtProdQty.Text = BLL.GetDJMatchedQty(txtPONo.Text, txtPCBANo.Text, DJOrgCode)
                        'ready for input for next product
                        If dgvPCBA.Visible = True Then
                            txtPCBASerial.Clear()
                            'Refresh dgvPCBA here...
                            Dim DataRow As DataRow
                            For Each DataRow In dsModelStructure.Tables("PCBAList").Rows
                                DataRow(2) = ""
                                DataRow(3) = ""
                                DataRow(4) = ""
                            Next
                            dsModelStructure.Tables("PCBAList").AcceptChanges()
                        End If
                        dsWIP.Tables("WIPHeader").Clear()
                        dsWIP.AcceptChanges()
                        txtIntSerial.Clear()
                        txtIntSerial.Focus()
                        Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
                End Select

            End If
        Catch ex As Exception
            If ex.GetType() Is GetType(System.Net.WebException) Then
                Me.ShowMessage("^SFC-169@",
                               eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                               AnimationStatus.StopAnim,
                               True,
                               PopUpTypes.Message,,
                               GetReportLink(txtIntSerial.Text))
            Else
                If dgvPCBA.Visible = True Then
                    txtPCBASerial.Clear()
                    'Refresh dgvPCBA here...
                    Dim DataRow As DataRow
                    For Each DataRow In dsModelStructure.Tables("PCBAList").Rows
                        DataRow(2) = ""
                        DataRow(3) = ""
                        DataRow(4) = ""
                    Next
                    dsModelStructure.Tables("PCBAList").AcceptChanges()
                End If
                dsWIP.Tables("WIPHeader").Clear()
                dsWIP.AcceptChanges()
                BLL.ErrorLogging("Matching1-SaveResult", User, ex.Message)
                Me.ShowMessage(ex.Message + "  " + txtIntSerial.Text, eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
                txtIntSerial.Clear()
                txtIntSerial.Focus()
            End If
        End Try
    End Sub

    Private Sub bgwPost_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwPost.DoWork
        'Try
        If PanelSize > 1 Then       ''''matching by panel
            e.Result = BLL.WIPMatchingByPanel(dsWIP, PanelSize)
        Else
            e.Result = BLL.WIPMatching1(dsWIP)
        End If

        'Catch ex As Exception
        '    If dgvPCBA.Visible = True Then
        '        txtPCBASerial.Clear()
        '        'Refresh dgvPCBA here...
        '        Dim DataRow As DataRow
        '        For Each DataRow In dsModelStructure.Tables("PCBAList").Rows
        '            DataRow(2) = ""
        '            DataRow(3) = ""
        '            DataRow(4) = ""
        '        Next
        '        dsModelStructure.Tables("PCBAList").AcceptChanges()
        '    End If
        '    dsWIP.Tables("WIPHeader").Clear()
        '    dsWIP.AcceptChanges()
        '    BLL.ErrorLogging("Matching1-bgwPost_DoWork", User, ex.Message)
        '    Me.ShowMessage(ex.Message + "  " + txtIntSerial.Text, eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
        '    txtIntSerial.Clear()
        '    txtIntSerial.Focus()
        'End Try
    End Sub

    Private Sub bgwPost_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPost.RunWorkerCompleted
        If e.Error IsNot Nothing Then
            If e.Error.GetType() Is GetType(System.Net.WebException) Then
                Me.ShowMessage("^SFC-169@",
                               eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                               AnimationStatus.StopAnim,
                               True,
                               PopUpTypes.Message,,
                               GetReportLink(txtIntSerial.Text))
            Else
                Me.ShowMessage("ERROR: " & e.Error.Message,
                               eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                               AnimationStatus.StopAnim,
                               True,
                               PopUpTypes.Message,,
                               GetReportLink(txtIntSerial.Text))
            End If
            pnlBody.Enabled = True
            Return
        End If
        Try
            pnlBody.Enabled = True

            If e.Result = "^TDC-155@" Then   'Matching successful.
                txtProdQty.Text = BLL.GetDJMatchedQty(txtPONo.Text, txtPCBANo.Text, DJOrgCode)
                Me.ShowMessage(e.Result + "  " + txtIntSerial.Text, eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
                txtIntSerial.Clear()
                txtIntSerial.Focus()
            Else                          ' Matching failed.
                Me.ShowMessage(e.Result + "  " + txtIntSerial.Text,
                               eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                               AnimationStatus.StopAnim,
                               True)
                txtIntSerial.Clear()
                txtIntSerial.Focus()
            End If

            grpDataInput.Enabled = True
            If dgvPCBA.Visible = True Then
                txtPCBASerial.Clear()
                'Refresh dgvPCBA here...
                Dim DataRow As DataRow
                For Each DataRow In dsModelStructure.Tables("PCBAList").Rows
                    DataRow(2) = ""
                    DataRow(3) = ""
                    DataRow(4) = ""
                Next
                dsModelStructure.Tables("PCBAList").AcceptChanges()
            End If
            dsWIP.Tables("WIPHeader").Clear()
            dsWIP.AcceptChanges()

        Catch ex As Exception


            If ex.GetType() Is GetType(System.Net.WebException) Then
                Me.ShowMessage("^SFC-169@",
                               eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                               AnimationStatus.StopAnim,
                               True,
                               PopUpTypes.Message,,
                               GetReportLink(txtIntSerial.Text))
                pnlBody.Enabled = True

            Else

                BLL.ErrorLogging("Matching1-bgwPost_RunWorkerCompleted", User, ex.Message)
                Me.ShowMessage(ex.Message + "  " + txtIntSerial.Text, eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
            End If
            If dgvPCBA.Visible = True Then
                txtPCBASerial.Clear()
                'Refresh dgvPCBA here...
                Dim DataRow As DataRow
                For Each DataRow In dsModelStructure.Tables("PCBAList").Rows
                    DataRow(2) = ""
                    DataRow(3) = ""
                    DataRow(4) = ""
                Next
                dsModelStructure.Tables("PCBAList").AcceptChanges()
            End If
            dsWIP.Tables("WIPHeader").Clear()
            dsWIP.AcceptChanges()
            txtIntSerial.Clear()
            txtIntSerial.Focus()

        End Try
    End Sub
    Dim SubPCBANo As String
    Private Sub txtPCBASerial_ValidateData() Handles txtPCBASerial.ValidateData
        Try
            txtPCBASerial.Text = Trim(txtPCBASerial.Text)
            If Trim(txtIntSerial.Text) = "" Then
                txtPCBASerial.Text = ""
                Exit Sub
            End If
            Dim DRsubPCBA() As DataRow
            DRsubPCBA = dsModelStructure.Tables("PCBAList").Select("PCBASerialNo = '" & txtPCBASerial.Text & "'")
            If DRsubPCBA.Length <> 0 Then  'the subPCBA exists in pcba list.
                Me.ShowMessage("ERROR: " & txtPCBASerial.Text & " ^TDC-158@",
                               eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                               AnimationStatus.StopAnim,
                               True,
                               PopUpTypes.Message,, GetReportLink(txtPCBASerial.Text))
                If txtPCBASerial.Text = txtIntSerial.Text Then
                    txtPCBASerial.Text = ""
                    txtIntSerial.SelectAll()
                    txtIntSerial.Focus()
                Else
                    txtPCBASerial.SelectAll()
                    txtPCBASerial.Focus()
                End If
                Return
            End If
            If PropertyType <> "FG" Then
                SubPCBANo = BLL.getPCBAinWIPHeader(txtPCBASerial.Text)
                If SubPCBANo = "^TDC-5@" Then  'does not exist.
                    Me.ShowMessage("ERROR: " & txtPCBASerial.Text & " ^TDC-5@",
                                   eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                                   AnimationStatus.StopAnim,
                                   True,
                                   PopUpTypes.Message,,
                                   GetReportLink(txtPCBASerial.Text))

                    If txtPCBASerial.Text = txtIntSerial.Text Then
                        txtPCBASerial.Text = ""
                        txtIntSerial.SelectAll()
                        txtIntSerial.Focus()
                    Else
                        txtPCBASerial.SelectAll()
                        txtPCBASerial.Focus()
                    End If
                    Return
                End If

                If SubPCBANo = txtPCBANo.Text Then
                    Me.ShowMessage("ERROR: " & txtPCBASerial.Text & " ^SFC-2@",
                                   eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                                   AnimationStatus.StopAnim,
                                   True,
                                   PopUpTypes.Message,, GetReportLink(txtPCBASerial.Text))
                    txtPCBASerial.Text = ""
                    txtPCBASerial.SelectAll()
                    txtPCBASerial.Focus()
                    Return
                End If

                If txtPCBASerial.Text = txtIntSerial.Text Then
                    If SubPCBANo <> ChildItem Then
                        Me.ShowMessage("ERROR: " & txtPCBASerial.Text & "(" & SubPCBANo & ") ^121-55@",
                                       eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                                       AnimationStatus.StopAnim,
                                       True,
                                       PopUpTypes.Message,,
                                       GetReportLink(txtPCBASerial.Text))
                        txtPCBASerial.Text = ""
                        txtIntSerial.SelectAll()
                        txtIntSerial.Focus()
                        Return
                    End If
                End If
                DRsubPCBA = dsModelStructure.Tables("PCBAList").Select("SubPCBA ='" & SubPCBANo & "'")
                If DRsubPCBA.Length = 0 Then  '^TDC-9@    'does not defined in the PCBA!     Sub PCBA not in the list
                    Me.ShowMessage("ERROR: " & txtPCBASerial.Text & "(" & SubPCBANo & ") ^TDC-9@",
                                   eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                                   AnimationStatus.StopAnim,
                                   True,
                                   PopUpTypes.Message,, GetReportLink(txtPCBASerial.Text))
                    txtPCBASerial.SelectAll()
                    txtPCBASerial.Focus()
                    Return
                End If
            End If

            Me.ShowMessage("^TDC-24@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
            txtPCBASerial.Modified = False
            pnlBody.Enabled = False
            Me.bgwSubPCBA.RunWorkerAsync()
        Catch ex As Exception
            If ex.GetType() Is GetType(System.Net.WebException) Then
                Me.ShowMessage("^SFC-169@",
                               eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                               AnimationStatus.StopAnim,
                               True,
                               PopUpTypes.Message,,
                               GetReportLink(txtIntSerial.Text))
            Else
                Me.ShowMessage("ERROR: " & ex.Message, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            End If
        End Try
    End Sub

    Private Sub bgwSubPCBA_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwSubPCBA.DoWork
        If PropertyType <> "FG" Then
            e.Result = BLL.DBoardIsValid(txtPCBASerial.Text)
        Else
            e.Result = BLL.ModelConfiguratorSNValid(txtPCBASerial.Text)
        End If
    End Sub

    Private Sub bgwSubPCBA_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwSubPCBA.RunWorkerCompleted
        pnlBody.Enabled = True
        If e.Error IsNot Nothing Then
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
            Return
        End If
        Try

            If Microsoft.VisualBasic.Left(e.Result, 5).ToUpper <> "WIPID" Then
                '^TDC-13@'  Failed process found!      
                '^TDC-157@' has been binded to another PCBA   
                Me.ShowMessage("ERROR: " & txtPCBASerial.Text & " " & e.Result,
                               eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                               AnimationStatus.StopAnim,
                               True,
                               PopUpTypes.Message,,
                               GetReportLink(txtPCBASerial.Text))
                'Me.ShowMessage(Microsoft.VisualBasic.Mid(e.Result, 7), eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtPCBASerial.SelectAll()
                txtPCBASerial.Focus()
            Else
                If PropertyType = "FG" Then
                    SubPCBANo = Mid(e.Result, 7)
                    If dsModelStructure.Tables("PCBAList").Select("SubPCBA ='" & SubPCBANo & "'").Length = 0 Then  '^TDC-9@    'does not defined in the PCBA!     Sub PCBA not in the list
                        Me.ShowMessage("ERROR: " & txtPCBASerial.Text & "(" & SubPCBANo & ") ^TDC-9@",
                                       eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                                       AnimationStatus.StopAnim,
                                       True,
                                       PopUpTypes.Message,,
                                       GetReportLink(txtPCBASerial.Text))
                        txtPCBASerial.SelectAll()
                        txtPCBASerial.Focus()
                        Return
                    End If
                End If
                If dsModelStructure.Tables("PCBAList").Select("SubPCBA='" & SubPCBANo & "' and (PCBASerialNo = '' or PCBASerialNo is null ) ").Length = 0 Then
                    Me.ShowMessage("ERROR: " & txtPCBASerial.Text & " " & "'^SFC-1@'",
                                   eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                                   AnimationStatus.StopAnim,
                                   True,
                                   PopUpTypes.Message,, GetReportLink(txtPCBASerial.Text))
                    txtPCBASerial.SelectAll()
                    txtPCBASerial.Focus()
                    Exit Sub
                End If
                For Each tmpRow In dsModelStructure.Tables("PCBAList").Rows
                    If tmpRow(0) = SubPCBANo Then
                        If FixNull(tmpRow("PCBASerialNo")) = "" Then    ' only fill up blank 'sub pcba' column
                            tmpRow("PCBASerialNo") = txtPCBASerial.Text
                            tmpRow("PCBAResult") = "PASS"
                            If PropertyType = "FG" Then
                                tmpRow("PCBAWipID") = txtPCBASerial.Text
                            Else
                                tmpRow("PCBAWipID") = Mid(e.Result, 7)
                            End If

                            Exit For
                        End If
                    End If
                Next
                dsModelStructure.Tables("PCBAList").AcceptChanges()
                If txtPCBASerial.Text = txtIntSerial.Text Then
                    dsWIP = BLL.DSWIP()
                    Dim dr As DataRow
                    dr = dsWIP.Tables("WIPHeader").NewRow()
                    dr("IntSN") = txtIntSerial.Text
                    dr("Model") = txtModelNo.Text
                    dr("PCBA") = txtPCBANo.Text
                    dr("DJ") = txtPONo.Text
                    dr("TVA") = txtTVANo.Text
                    dr("InvOrg") = DJOrgCode
                    dr("ProdLine") = ProductionLine()
                    dr("CurrentProcess") = CurrProcess
                    dr("TestRound") = 1
                    dr("Result") = "PASS"
                    dr("AllPassed") = AllPass
                    dr("ReuseChildISN") = ReuseChildISN
                    dr("MotherBoardSN") = ""
                    dr("ChangedBy") = User
                    dsWIP.Tables("WIPHeader").Rows.Add(dr)
                End If

                Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
                'Check if all Sub PCBAs have been filled, if yes, txtPCBASerial is no more required
                'If not, then clear the input and focus on txtPCBASerial
                If SubPCBAInput(dsModelStructure.Tables("PCBAList")) = True Then
                    'txtPCBASerial.Required = False
                    txtPCBASerial.Modified = False
                    'Auto complete the "save" process
                    SaveResult()
                Else
                    txtPCBASerial.Clear()
                    txtPCBASerial.Focus()
                End If
            End If
        Catch ex As Exception
            If ex.GetType() Is GetType(System.Net.WebException) Then
                Me.ShowMessage("^SFC-169@",
                               eTraceUI.eTraceMessageBar.MessageTypes.Abort,
                               AnimationStatus.StopAnim,
                               True,
                               PopUpTypes.Message,,
                               GetReportLink(txtIntSerial.Text))
                pnlBody.Enabled = True
            Else
                Me.ShowMessage("ERROR: " & ex.Message, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                pnlBody.Enabled = True
            End If
        End Try
    End Sub

    Public Function SubPCBAInput(ByVal tblPCBA As DataTable) As Boolean
        Dim i As Integer
        'Return false if any blank serial number
        For i = 0 To tblPCBA.Rows.Count - 1
            If tblPCBA.Rows(i)(3) Is DBNull.Value Then
                Return False
            End If
            If Trim(tblPCBA.Rows(i)(3).ToString) = "" Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Function FixNull(ByVal vMayBeNull As Object) As String
        On Error Resume Next
        FixNull = vbNullString & vMayBeNull
    End Function

    Private Sub ResetScreen()
        Me.DisableValidation = True
        If btnPost.Enabled Then
            If Me.ShowMessage("^OLD-4@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.NoChange, True, PopUpTypes.Question) = False Then
                Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
                Me.DisableValidation = False
                Exit Sub
            End If
        End If

        grpModel.Enabled = True
        grpDataInput.Visible = False
        grpActions.Visible = False
        txtIntSerial.Text = ""
        txtPCBASerial.Text = ""
        txtPONo.Text = ""
        txtPOPCBA.Text = ""
        txtQty.Text = ""
        txtProdQty.Text = ""
        txtModelNo.Text = ""
        txtPCBANo.Text = ""
        dsModelStructure = New DataSet
        While dgvPCBA.RowCount > 1
            dgvPCBA.Rows.RemoveAt(0)
        End While
        txtPONo.Focus()
        Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        Me.DisableValidation = False
        btnEMI.Visible = False
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ResetScreen()
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
        If dgvPCBA.Visible = True Then
            'Refresh dgvPCBA here...
            Dim DataRow As DataRow
            For Each DataRow In dsModelStructure.Tables("PCBAList").Rows
                DataRow(2) = ""
                DataRow(3) = ""
                DataRow(4) = ""
            Next
            dsModelStructure.Tables("PCBAList").AcceptChanges()
        End If
        btnPost.Enabled = True
        If txtIntSerial.Visible Then
            txtIntSerial.Text = ""
            txtIntSerial.Focus()
        Else
            grpDataInput.Focus()
        End If
        Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        Me.DisableValidation = False
        btnEMI.Visible = False
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        ClearDataInput()
    End Sub

    Private Sub frmMatching1_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Try
            SerialPort1.Open()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmMatching1_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
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
    Private Sub txtTVANo_ValidateData() Handles txtTVANo.ValidateData
        txtTVANo.Text = Trim(txtTVANo.Text)
    End Sub
End Class
