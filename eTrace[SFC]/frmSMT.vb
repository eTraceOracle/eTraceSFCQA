Public Class frmSMT

#Region "Fields"


    Public ProcessID As Integer
    Public CurrProcess As String
    Private mydataset As DataSet = New DataSet
    Public MachineStr As eTraceSMTService.Machine = New eTraceSMTService.Machine
    Public FeederStr As eTraceSMTService.Feeder = New eTraceSMTService.Feeder
    Public FeederTypeStr As eTraceSMTService.FeederTypestr = New eTraceSMTService.FeederTypestr
    Dim copydataset As DataSet

#End Region


    Public Overrides Sub NewSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'New Instance of the form
        Dim NewInstance As New frmMain()
        NewInstance.ShowFrm(Me)
    End Sub

    Private Sub frmSMT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProcessID = SelectProcessID
        CurrProcess = SelectProcess
        BindCtlsToProcess(Me, ProcessID)
        Me.ShowMessage(ProcessShow, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
    End Sub

    Private Sub frmSMT_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        ddlProcess.Text = ProcessShow
        Me.CenterToScreen()
        BLL.LoginData.User = Mid(UserName.Text, 1, InStr(UserName.Text, "-") - 1).Trim
        BLL.LoginData.OrgCode = MyOrg()
        BLL.LoginData.ProductionLine = ProductionLine()
        pnlBody.Visible = True
        SAPLoginData1.User = Mid(UserName.Text, 1, InStr(UserName.Text, "-") - 1).Trim
        addtable()
        get_Infor()
        get_spec()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub addtable()
        Dim SpecTable As Data.DataTable = New System.Data.DataTable("Spec")

        Dim dcCheck As DataColumn = New DataColumn("Checked", System.Type.GetType("System.String"))
        SpecTable.Columns.Add(dcCheck)
        Dim dcSpec As DataColumn = New DataColumn("FeederSpec", System.Type.GetType("System.String"))
        SpecTable.Columns.Add(dcSpec)
        mydataset.Tables.Add(SpecTable)

        Dim SelectTable As DataTable = New DataTable("Selected")
        Dim dcSpec1 As DataColumn = New DataColumn("FeederSpec", System.Type.GetType("System.String"))
        SelectTable.Columns.Add(dcSpec1)
        mydataset.Tables.Add(SelectTable)
    End Sub


    Private Sub get_Infor()
        Dim i As Integer
        'Dim dr() As DataRow

        Dim IDDataset As DataSet = New DataSet
        IDDataset = eTraceRS.GetID()
        For i = 0 To IDDataset.Tables(0).Rows.Count - 1
            cobID.Items.Add(IDDataset.Tables(0).Rows(i)(0))
            'dr = IDDataset.Tables(0).Select("MachineID ='" & cobID.Items(i) & "'")
            'If dr.Length > 0 Then
            '    cobID.Items.Remove(i)
            'End If
        Next
        For i = 0 To IDDataset.Tables(1).Rows.Count - 1
            cobFeederID.Items.Add(IDDataset.Tables(1).Rows(i)(0))
        Next
        For i = 0 To IDDataset.Tables(2).Rows.Count - 1
            cobFeederType.Items.Add(IDDataset.Tables(2).Rows(i)(0))
        Next
    End Sub
    Private Sub get_spec()
        Dim i As Integer
        Dim SpecDataset As DataSet = New DataSet
        Dim mydatarow As DataRow
        Dim Spec As DataTable = New DataTable("FSpec")
        Dim dcSpec As DataColumn = New DataColumn("FeederSpec", System.Type.GetType("System.String"))
        Spec.Columns.Add(dcSpec)
        SpecDataset.Tables.Add(Spec)
        SpecDataset = eTraceRS.GetSpec(1, cobFeederType.SelectedItem)
        For i = 0 To SpecDataset.Tables(0).Rows.Count - 1
            mydatarow = mydataset.Tables(0).NewRow
            mydatarow(0) = Convert.ToString(False)
            mydatarow(1) = SpecDataset.Tables(0).Rows(i)("FeederSpec")
            mydataset.Tables(0).Rows.Add(mydatarow)
        Next

        dgvFeederSpec.DataSource = mydataset
        dgvFeederSpec.DataMember = "Spec"
    End Sub
    Private Sub btnSaveM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveM.Click
        Try
            Dim SaveMachine As String
            MachineStr.MachineID = cobID.Text
            MachineStr.Manufacturer = txtManu.Text
            MachineStr.Model = txtModel.Text
            MachineStr.MultipleBanks = ckbMulti.Checked
            MachineStr.DaulTables = ckbDaul.Checked
            MachineStr.ProductionLine = txtProd.Text
            MachineStr.Remarks = txtRemark.Text
            If MachineStr.MachineID <> "" And MachineStr.Manufacturer <> "" And MachineStr.Model <> "" And MachineStr.ProductionLine <> "" And MachineStr.Remarks <> "" Then
                SaveMachine = eTraceRS.SaveSMTMaster(MachineStr, FeederStr, FeederTypeStr, 1, SAPLoginData1)
                Me.ShowMessage(SaveMachine, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            Else
                Me.ShowMessage("The Data are required to be input", eTraceUI.eTraceMessageBar.MessageTypes.Warning, AnimationStatus.StopAnim)
            End If

            If SaveMachine = "okay to save machine" Then
                cobID.Items.Add(MachineStr.MachineID)
            End If
        Catch ex As Exception
            Me.ShowMessage(ex.ToString, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        End Try
    End Sub

    Private Sub btnSaveF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveF.Click
        Try
            Dim SaveFeeder As String
            FeederStr.FeederID = cobFeederID.Text
            FeederStr.FeederSpec = txtFeederSpec.Text
            FeederStr.MaxLanes = txtLanes.Text
            FeederStr.ProductionLine = txtProdu.Text
            FeederStr.Remarks = txtRemarks.Text
            If FeederStr.FeederID <> "" And FeederStr.FeederSpec <> "" And FeederStr.MaxLanes <> 0 And FeederStr.ProductionLine <> "" And FeederStr.Remarks <> "" Then
                SaveFeeder = eTraceRS.SaveSMTMaster(MachineStr, FeederStr, FeederTypeStr, 2, SAPLoginData1)
                Me.ShowMessage(SaveFeeder, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            Else
                Me.ShowMessage("The Data are required to be input", eTraceUI.eTraceMessageBar.MessageTypes.Warning, AnimationStatus.StopAnim)
            End If

            If SaveFeeder = "okay to save Feeder" Then
                cobFeederID.Items.Add(FeederStr.FeederID)
            End If
        Catch ex As Exception
            Me.ShowMessage(ex.ToString, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        End Try

    End Sub

    Private Sub btnSaveFT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveFT.Click
        Try
            Dim i As Integer
            Dim mydatarow As DataRow
            Dim SaveFeederType As String
            FeederTypeStr.FeederType = cobFeederType.Text
            FeederTypeStr.Description = txtDes.Text
            For i = 0 To mydataset.Tables(0).Rows.Count - 1
                If Not mydataset.Tables(0).Rows(i)("Checked") Is DBNull.Value Then
                    mydatarow = mydataset.Tables(1).NewRow
                    mydatarow(0) = mydataset.Tables(0).Rows(i)("FeederSpec")
                    mydataset.Tables(1).Rows.Add(mydatarow)
                End If
            Next
            If FeederTypeStr.FeederType <> "" And FeederTypeStr.Description <> "" Then
                SaveFeederType = eTraceRS.SaveFeederType(mydataset, MachineStr, FeederStr, FeederTypeStr, SAPLoginData1)
                Me.ShowMessage(SaveFeederType, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            Else
                Me.ShowMessage("The Data are required to be input", eTraceUI.eTraceMessageBar.MessageTypes.Warning, AnimationStatus.StopAnim)
            End If

            If SaveFeederType = "okay to save FeederType" Then
                cobFeederType.Items.Add(FeederTypeStr.FeederType)
            End If
        Catch ex As Exception
            Me.ShowMessage(ex.ToString, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        End Try
    End Sub


    Private Sub btnCancelM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelM.Click
        cobID.Text = MachineStr.MachineID
        txtManu.Text = MachineStr.Manufacturer
        txtModel.Text = MachineStr.Model
        txtProd.Text = MachineStr.ProductionLine
        ckbMulti.Checked = MachineStr.MultipleBanks
        ckbDaul.Checked = MachineStr.DaulTables
        txtRemark.Text = MachineStr.Remarks

    End Sub
    Private Sub btnCancelF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelF.Click
        cobFeederID.Text = FeederStr.FeederID
        txtFeederSpec.Text = FeederStr.FeederSpec
        txtLanes.Text = FeederStr.MaxLanes
        txtProdu.Text = FeederStr.ProductionLine
        txtRemarks.Text = FeederStr.Remarks
    End Sub
    Private Sub btnCancelFT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelFT.Click
        Dim i, j As Integer
        cobFeederType.Text = FeederTypeStr.FeederType
        txtDes.Text = FeederTypeStr.Description
        For j = 0 To mydataset.Tables(0).Rows.Count - 1
            For i = 0 To copydataset.Tables(0).Rows.Count - 1
                If copydataset.Tables(0).Rows(i)(0) = mydataset.Tables(0).Rows(j)(1) Then
                    mydataset.Tables(0).Rows(j)(0) = True

                End If

            Next
        Next
    End Sub

    Private Sub btnNewM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewM.Click
        cobID.Text = ""
        txtManu.Text = ""
        txtModel.Text = ""
        txtProd.Text = ""
        txtRemark.Text = ""
        ckbMulti.Checked = False
        ckbDaul.Checked = False
        Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)

    End Sub

    Private Sub btnNewF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewF.Click
        cobFeederID.Text = ""
        txtFeederSpec.Text = ""
        txtLanes.Text = ""
        txtProdu.Text = ""
        txtRemarks.Text = ""
        Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)

    End Sub

    Private Sub btnNewFT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewFT.Click
        Dim i As Integer

        cobFeederType.Text = ""
        txtDes.Text = ""
        ckbShow.Checked = False
        mydataset = New DataSet
        For i = 0 To mydataset.Tables(0).Rows.Count - 1
            mydataset.Tables(0).Rows(i)("Checked") = Convert.ToString(False)
        Next
        Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)

    End Sub

    Private Sub ckbShow_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbShow.CheckedChanged
        Dim i As Integer
        If ckbShow.Checked = True Then
            For i = 0 To mydataset.Tables(0).Rows.Count - 1

                mydataset.Tables(0).Rows(i)("Checked") = Convert.ToString(True)

            Next
        Else : ckbShow.Checked = False

            For i = 0 To mydataset.Tables(0).Rows.Count - 1

                mydataset.Tables(0).Rows(i)("Checked") = Convert.ToString(False)

            Next
        End If
    End Sub

    Private Sub cobID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobID.SelectedIndexChanged

        MachineStr = eTraceRS.GetMachine(cobID.SelectedItem)
        txtManu.Text = MachineStr.Manufacturer
        txtModel.Text = MachineStr.Model
        txtProd.Text = MachineStr.ProductionLine
        ckbMulti.Checked = MachineStr.MultipleBanks
        ckbDaul.Checked = MachineStr.DaulTables
        txtRemark.Text = MachineStr.Remarks

    End Sub

    Private Sub cobFeederID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobFeederID.SelectedIndexChanged
        FeederStr = eTraceRS.GetFeeder(cobFeederID.SelectedItem)
        txtFeederSpec.Text = FeederStr.FeederSpec
        txtLanes.Text = FeederStr.MaxLanes
        txtProdu.Text = FeederStr.ProductionLine
        txtRemarks.Text = FeederStr.Remarks
    End Sub

    Private Sub cobFeederType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ETraceTabControl1.SelectedIndexChanged
        Dim m As Integer

        For m = 0 To mydataset.Tables(0).Rows.Count - 1

            mydataset.Tables(0).Rows(m)("Checked") = Convert.ToString(False)
        Next
        Dim i, j As Integer
        copydataset = mydataset.Copy
        FeederTypeStr = eTraceRS.GetFeederType(cobFeederType.SelectedItem)
        copydataset = eTraceRS.GetSpec(2, cobFeederType.SelectedItem)
        txtDes.Text = FeederTypeStr.Description
        For j = 0 To mydataset.Tables(0).Rows.Count - 1
            For i = 0 To copydataset.Tables(0).Rows.Count - 1
                If copydataset.Tables(0).Rows(i)(0) = mydataset.Tables(0).Rows(j)(1) Then
                    mydataset.Tables(0).Rows(j)(0) = True

                End If

            Next
        Next
    End Sub

    Private Sub btnDelM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelM.Click
        Dim returnmsg As String
        If cobID.SelectedItem <> "" Then
            returnmsg = eTraceRS.Del_SMTMaster(cobID.SelectedItem, 1)
            Me.ShowMessage(returnmsg, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            cobID.Items.Remove(cobID.SelectedItem)
        End If
    End Sub

    Private Sub btnDelF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelF.Click
        Dim returnmsg As String
        If cobFeederID.SelectedItem <> "" Then
            returnmsg = eTraceRS.Del_SMTMaster(cobFeederID.SelectedItem, 2)
            Me.ShowMessage(returnmsg, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            cobFeederID.Items.Remove(cobFeederID.SelectedItem)
        End If
    End Sub

    Private Sub btnDelFT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelFT.Click
        Dim returnmsg As String
        If cobFeederType.SelectedItem <> "" Then
            returnmsg = eTraceRS.Del_SMTMaster(cobFeederType.SelectedItem, 3)
            Me.ShowMessage(returnmsg, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            cobFeederType.Items.Remove(cobFeederType.SelectedItem)
        End If
    End Sub

End Class
