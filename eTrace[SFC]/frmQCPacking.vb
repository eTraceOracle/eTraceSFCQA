Public Class frmQCPacking
    Public ProcessID As Integer
    Public CurrProcess As String
    Dim user As String
    Dim dtProductCPN As DataTable

    'define CPN info
    Dim Customer As String
    Dim CPN As String
    Dim Model As String
    Dim SerialNoPattern As String
    Dim SN2pattern As String
    Dim SN3pattern As String
    Dim SN4pattern As String
    Dim Boxsize As Integer
    Dim Palletsize As Integer
    Dim Revision As String
    Dim ExtSNSameIntSN As Boolean
    Dim DJ As String
    Dim TVA As String
    'Dim ConfirmSN As Boolean
    Dim IPAddress As Boolean
    Dim MacAddress As Boolean
    Dim SNRangeControl As Boolean
    Dim DataTransmission As String
    Dim tmpCPN As String
    Dim tmpBoxID As String            'use transfer box for remind original box
    Dim tmpPalletID As String         'use transfer pallet for remind original pallet
    Dim HasDautherBoard As String
    Dim dtBoxInfo As DataTable
    Dim dtResultList As DataTable
    Dim dtAttributes As DataTable
    Dim dtValuesOfCollection As DataTable
    Dim Emifile As Object
    Dim dsPackingInfo As DataSet = New DataSet("PackingInfo")
    Dim LabelID As String
    Dim LabelType As String
    Dim PrintSN As String
    Private flgBusy As Boolean = False
    Private Delegate Sub UpdateUI(ByVal ReceivedData As String)
    Dim SFC004 As String
    Dim SFC005 As String
    Dim SFC010 As String
    Dim SFC013 As String
    Dim SFC014 As String
    Dim SFC025 As String
    Dim TLABoard As String
    Dim DJinBox As String
    Dim Rev As String
    Dim RevInBox As String
    Dim BoxID As String
    Dim InvOrg As String

    Public Overrides Sub NewSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'New Instance of the form
        Dim NewInstance As New frmMain()
        NewInstance.ShowFrm(Me)
    End Sub

    Private Sub frmPacking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'AttachHotkey(btnPost, Keys.F8)
        AttachHotkey(btnNew, Keys.F5)
        AttachHotkey(btnReset, Keys.F3)
        AttachHotkey(btnPrint, Keys.F9)
        ProcessID = SelectProcessID
        CurrProcess = SelectProcess
        BindCtlsToProcess(Me, ProcessID)
        SFC004 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC004'")(0)("Value"))
        SFC005 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC005'")(0)("Value"))
        SFC010 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC010'")(0)("Value"))
        SFC013 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC013'")(0)("Value"))
        SFC025 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC025'")(0)("Value"))
        If SFC004.ToUpper = "NO" Then
            txtIntSerial.KeyIn = False
        Else
            txtIntSerial.KeyIn = True
        End If
        If SFC005.ToUpper = "NO" Then
            txtExtSerial.KeyIn = False
        Else
            txtExtSerial.KeyIn = True
        End If
        If dsConfig.Tables(0).Select("ConfigID='SFC014'").Length > 0 Then
            SFC014 = BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC014'")(0)("Value"))
        Else
            SFC014 = "NO"
        End If
        Me.ShowMessage(ProcessShow, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
    End Sub

    Private Sub frmPacking_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        ddlProcess.Text = ProcessShow
        Me.CenterToScreen()
        user = Mid(UserName.Text, 1, InStr(UserName.Text, "-") - 1).Trim
        BLL.LoginData.User = user
        BLL.LoginData.OrgCode = MyOrg()
        BLL.LoginData.ProductionLine = ProductionLine()
        txtPOPCBA.Focus()
        txtSymptom.Items.Add("")
    End Sub

    Private Sub txtPOPCBA_ValidateData() Handles txtPOPCBA.ValidateData
        Try
            txtPOPCBA.Text = Trim(txtPOPCBA.Text)
            If txtPOPCBA.Text = "" OrElse txtPOPCBA.Text = tmpCPN Then
                Return
            End If
            dtProductCPN = BLL.GetProductCPN(txtPOPCBA.Text)
            tmpCPN = txtPOPCBA.Text
            If dtProductCPN.Rows.Count = 0 Then
                Me.ShowMessage("^TDC-619@" + Model + " ^TDC-620@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtPOPCBA.SelectAll()
                txtPOPCBA.Focus()
                Return
            End If
            If dtProductCPN.Rows.Count = 1 Then
                txtPONo.Enabled = False
                Customer = dtProductCPN.Rows(0)("Customer")
                CPN = dtProductCPN.Rows(0)("CustomerPN")
                Model = dtProductCPN.Rows(0)("Model")
                SerialNoPattern = dtProductCPN.Rows(0)("SerialNoPattern")
                SN2pattern = dtProductCPN.Rows(0)("SN2pattern")
                SN3pattern = dtProductCPN.Rows(0)("SN3pattern")
                SN4pattern = dtProductCPN.Rows(0)("SN4pattern")
                Boxsize = dtProductCPN.Rows(0)("Boxsize")
                Palletsize = dtProductCPN.Rows(0)("Palletsize")
                Revision = dtProductCPN.Rows(0)("Revision")
                ExtSNSameIntSN = dtProductCPN.Rows(0)("ExtSNSameIntSN")
                'ConfirmSN = dtProductCPN.Rows(0)("ConfirmSN")
                IPAddress = dtProductCPN.Rows(0)("IPAddress")
                MacAddress = dtProductCPN.Rows(0)("MacAddress")
                SNRangeControl = dtProductCPN.Rows(0)("SNRangeControl")
                DataTransmission = dtProductCPN.Rows(0)("DataTransmission").ToString
                txtPONo.Text = Customer
                Dim j As Integer
                Dim revfromdb As String
                j = InStr(Customer, "(")
                revfromdb = Mid(Customer, j)
                Customer = Replace(Customer, revfromdb, "")
            Else
                txtPONo.Items.Clear()
                txtPONo.Enabled = True
                Dim i As Integer
                For i = 0 To dtProductCPN.Rows.Count - 1
                    txtPONo.Items.Add(dtProductCPN.Rows(i)("Customer"))
                Next
                txtPONo.Text = ""
                txtPONo.Focus()
                Me.ShowMessage("^SFC-12@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            End If
        Catch ex As Exception
            BLL.ErrorLogging("Packing-txtPOPCBA_ValidateData", user, ex.Message)
            Me.ShowMessage(ex.Message, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        End Try

    End Sub

    Private Sub txtPONo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPONo.SelectedIndexChanged
        Try
            txtPONo.Enabled = False
            Dim i As Integer = txtPONo.SelectedIndex
            Dim j As Integer
            Dim revfromdb As String
            Customer = dtProductCPN.Rows(i)("Customer")
            j = InStr(Customer, "(")
            revfromdb = Mid(Customer, j)
            Customer = Replace(Customer, revfromdb, "")
            CPN = dtProductCPN.Rows(i)("CustomerPN")
            Model = dtProductCPN.Rows(i)("Model")
            SerialNoPattern = dtProductCPN.Rows(i)("SerialNoPattern")
            SN2pattern = dtProductCPN.Rows(i)("SN2pattern")
            SN3pattern = dtProductCPN.Rows(i)("SN3pattern")
            SN4pattern = dtProductCPN.Rows(i)("SN4pattern")
            Boxsize = dtProductCPN.Rows(i)("Boxsize")
            Palletsize = dtProductCPN.Rows(i)("Palletsize")
            Revision = dtProductCPN.Rows(i)("Revision")
            ExtSNSameIntSN = dtProductCPN.Rows(i)("ExtSNSameIntSN")
            'ConfirmSN = dtProductCPN.Rows(i)("ConfirmSN")
            IPAddress = dtProductCPN.Rows(i)("IPAddress")
            MacAddress = dtProductCPN.Rows(i)("MacAddress")
            SNRangeControl = dtProductCPN.Rows(i)("SNRangeControl")
            DataTransmission = dtProductCPN.Rows(i)("DataTransmission").ToString
            txtQty.Focus()
        Catch ex As Exception
            BLL.ErrorLogging("Packing-bgwPO_DoWork", user, ex.Message)
            Me.ShowMessage(ex.Message, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        End Try
    End Sub

    Private Sub txtQty_ValidateData() Handles txtQty.ValidateData
        If Trim(txtPOPCBA.Text) = "" Then
            txtPOPCBA.Focus()
        Else
            txtQty.Text = Trim(txtQty.Text)
            If BLL.AlphanumericValidation(txtQty.Text, Revision) = False Then   'check revision format
                Me.ShowMessage("^TDC-130@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtQty.SelectAll()
                txtQty.Focus()
                Exit Sub
            End If
            Dim dtStructure As DataTable
            Dim drTLA() As DataRow
            dtStructure = BLL.ModelStructure(Model).Tables("ModelStructure")
            If dtStructure.Rows.Count > 1 Then
                HasDautherBoard = "Y"
            Else
                If dtStructure.Rows(0)(0) = "^TDC-1@ ^TDC-5@" Then
                    Me.ShowMessage("^TDC-619@" + Model + " ^TDC-620@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtQty.Text = ""
                    Exit Sub
                End If
                HasDautherBoard = "N"
            End If
            drTLA = dtStructure.Select("IsTLA = True")
            TLABoard = drTLA(0)("PCBA").ToString
            Dim dtLabelInfo As DataTable
            dtLabelInfo = BLL.GetLabels(Model, TLABoard, "Packing").Tables(0)
            LabelID = dtLabelInfo.Rows(0)("Label1").ToString.Trim
            LabelType = dtLabelInfo.Rows(0)("Type").ToString.Trim
            If LabelType = "PRODUCT LABEL" Then
                If LabelPrinter().Trim = "" Then
                    Me.ShowMessage("^SFC-116@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtPOPCBA.Text = ""
                    txtQty.Text = ""
                    Exit Sub
                End If
            End If
            If SerialNoPattern.Contains("^") Then           'if the production trace by batch.(date code or lot No.)
                txtProdQty.Visible = True
                txtProdQty.Enabled = True
                txtProdQty.Focus()
            Else
                DataInput()
            End If
        End If
    End Sub

    Private Sub txtProdQty_ValidateData() Handles txtProdQty.ValidateData
        'trace product by batch, date code or lot No.
        txtProdQty.Text = Trim(txtProdQty.Text)
        If txtProdQty.Text = "" Then
            txtProdQty.Focus()
            Exit Sub
        End If
        Dim Patterns() As String
        Patterns = SerialNoPattern.Split("^")
        If Not BLL.AlphanumericValidation(txtProdQty.Text, Patterns(0)) Then
            Me.ShowMessage("^TDC-152@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtProdQty.SelectAll()
            txtProdQty.Focus()
            Exit Sub
        End If
        DataInput()
    End Sub

    Private Sub DataInput()
        txtModelNo.Text = Model
        grpDataInput.Visible = True
        grpActions.Visible = True
        grpModel.Enabled = False

        Emifile = BLL.getMIFileData(txtModelNo.Text.Trim, txtModelNo.Text.Trim, CurrProcess)
        If (Not Emifile Is Nothing) Then
            btnEMI.Visible = True
        End If

        If SNRangeControl Then
            txtSNFROM.Visible = True
            txtSNTO.Visible = True
        End If

        If Boxsize > 0 Then
            txtBoxID.Visible = True
            txtBoxQty.Visible = True
            txtBoxQty.Enabled = False
            txtBoxSize.Visible = True
            txtBoxQty.Text = "0"
            txtBoxSize.Text = Boxsize
            If Palletsize > 0 Then
                txtPalletID.Visible = True
                txtPalletQty.Visible = True
                txtPalletQty.Enabled = False
                txtPalletSize.Visible = True
                txtPalletQty.Text = "0"
                txtPalletSize.Text = Palletsize
            End If
            txtBoxID.Focus()
        Else
            If SNRangeControl Then
                txtSNFROM.Focus()
            Else
                txtIntSerial.Focus()
            End If
        End If
    End Sub

    Private Sub txtBoxID_ValidateData() Handles txtBoxID.ValidateData
        txtBoxID.Text = Trim(txtBoxID.Text)
        If txtBoxID.Text = "" Then
            Return
        End If
        If txtBoxID.Text = "MISTEST" Then
            txtIntSerial.KeyIn = True
            txtExtSerial.KeyIn = True
            txtBoxID.Text = ""
            Return
        End If
        txtIntSerial.Enabled = True
        txtExtSerial.Enabled = True
        If Mid(txtBoxID.Text, 1, 1).ToUpper <> "B" And Mid(txtBoxID.Text, 1, 2).ToUpper <> "LE" Then
            Me.ShowMessage("^TDC-106@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtBoxID.Focus()
            txtBoxID.SelectAll()
            Return
        End If

        dtBoxInfo = BLL.GetBoxInfo(txtBoxID.Text)
        'RevInBox = BLL.RevinBox(txtBoxID.Text)
        txtDJ.Text = "Model Rev:" & RevInBox
        If dtBoxInfo.Rows.Count > 0 Then
            If dtBoxInfo.Rows(0)("CustomerPN").ToString = "SFC-64@" Then
                Me.ShowMessage("^SFC-64@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtBoxID.Text = ""
                txtBoxQty.Text = "0"
                txtBoxID.Focus()
                Return
            End If
            If txtPOPCBA.Text.Trim <> dtBoxInfo.Rows(0)("CustomerPN").ToString OrElse Customer <> dtBoxInfo.Rows(0)("Customer").ToString Then       'if the BoxID has other product.
                Me.ShowMessage("^TDC-105@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtBoxID.Text = ""
                txtBoxQty.Text = "0"
                txtBoxID.Focus()
                Return
            ElseIf Int(txtBoxSize.Text) <= dtBoxInfo.Rows(0)("PackedQty") Then            ' if the Box is full
                'If Me.ShowMessage("^TDC-164@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.NoChange, True, PopUpTypes.Question) = True Then
                '    If BLL.GetPackingListLabel(Model) <> "" And LabelID <> "" Then
                '        PrintPackingList()
                '    Else
                '        Me.ShowMessage("^SFC-12@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
                '    End If
                'End If
                'txtBoxID.Text = ""
                'txtBoxQty.Text = "0"
                'txtBoxID.Focus()
                Me.ShowMessage("^TDC-103@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtBoxID.SelectAll()
                txtIntSerial.Enabled = False
                txtExtSerial.Enabled = False
                btnPrint.Focus()
                Return
            Else
                txtBoxQty.Text = dtBoxInfo.Rows(0)("PackedQty")
            End If
            If Palletsize > 0 Then
                If txtPalletID.Text.Trim <> "" Then 'box in other pallet
                    If txtPalletID.Text.Trim <> dtBoxInfo.Rows(0)("PalletID") Then
                        Me.ShowMessage("^TDC-104@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                        txtBoxID.Text = ""
                        txtBoxQty.Text = "0"
                        txtBoxID.Focus()
                    End If
                Else
                    txtPalletID.Text = dtBoxInfo.Rows(0)("PalletID")
                    txtPalletID.Enabled = False
                    Dim PalletQty As Integer
                    PalletQty = BLL.GetBoxQtyInPallet(txtPalletID.Text)
                    txtPalletQty.Text = PalletQty.ToString
                    txtIntSerial.Focus()
                End If
            Else
                txtPalletID.Text = dtBoxInfo.Rows(0)("PalletID")
                txtIntSerial.Focus()
            End If
            ''''''this box is a new box
        Else
            BoxID = txtBoxID.Text
            If Palletsize > 0 Then
                If txtPalletID.Text.Trim <> "" Then
                    Dim PalletQty As Integer
                    PalletQty = BLL.GetBoxQtyInPallet(txtPalletID.Text)
                    If Palletsize = PalletQty Then              'pallet is full
                        Me.ShowMessage("^TDC-102@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                        txtPalletID.Enabled = True
                        txtPalletID.Text = ""
                        txtPalletQty.Text = "0"
                        txtPalletID.Focus()
                        Return
                    Else
                        txtPalletQty.Text = (PalletQty + 1).ToString
                        txtIntSerial.Focus()
                    End If
                Else
                    txtPalletID.Focus()
                End If
            Else
                If SNRangeControl Then
                    txtSNFROM.Focus()
                Else
                    txtIntSerial.Focus()
                End If
            End If
        End If
        BoxID = txtBoxID.Text
    End Sub

    Private Sub txtPalletID_ValidateData() Handles txtPalletID.ValidateData
        txtPalletID.Text = Trim(txtPalletID.Text)
        If txtPalletID.Text = "" Then
            Return
        End If
        If Mid(txtPalletID.Text, 1, 1).ToUpper <> "P" Then
            Me.ShowMessage("^TDC-107@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtPalletID.Focus()
            txtPalletID.SelectAll()
            Return
        End If
        Dim PalletQty As Integer
        PalletQty = BLL.GetBoxQtyInPallet(txtPalletID.Text)
        If Trim(txtBoxID.Text) = "" Then
            txtPalletQty.Text = PalletQty.ToString
            txtBoxID.Focus()
        Else
            If dtBoxInfo.Rows.Count = 0 Then      'box is not in any Pallet
                If Int(txtPalletSize.Text.Trim) = PalletQty Then
                    Me.ShowMessage("^TDC-102@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtPalletID.Text = ""
                    txtPalletQty.Text = "0"
                    txtPalletID.Focus()
                Else                             'box will be added into pallet
                    txtPalletQty.Text = (PalletQty + 1).ToString
                    txtIntSerial.Focus()
                End If
            Else                                  'box is in this pallet
                txtPalletQty.Text = PalletQty.ToString
                If SNRangeControl Then
                    txtSNFROM.Focus()
                Else
                    txtIntSerial.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtIntSerial_ValidateData() Handles txtIntSerial.ValidateData
        Me.ShowMessage("^TDC-24@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
        pnlBody.Enabled = False
        Me.bgwIntSerial.RunWorkerAsync()
    End Sub

    Private Sub bgwIntSerial_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwIntSerial.DoWork
        Try
            e.Result = BLL.GetResultAndAttributesList(txtIntSerial.Text)
        Catch ex As Exception
            BLL.ErrorLogging("Packing-bgwIntSerial_DoWork", user, ex.Message)
        End Try
    End Sub

    Dim iQCResult As Integer
    Private Sub bgwIntSerial_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwIntSerial.RunWorkerCompleted
        Try
            pnlBody.Enabled = True
            dtResultList = e.Result.Tables(0)
            If dtResultList.Rows.Count = 0 Then
                Me.ShowMessage("ERROR: " & txtIntSerial.Text & " ^TDC-5@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtIntSerial.SelectAll()
                txtIntSerial.Focus()
                Return
            End If

            If dtResultList.Rows(0)("Model").ToString <> Model Then
                Me.ShowMessage("^TDC-41@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtIntSerial.SelectAll()
                txtIntSerial.Focus()
                Return
            End If

            DJ = dtResultList.Rows(0)("DJ").ToString

            Dim dsPOQty As DataSet
            dsPOQty = BLL.ReadPOQtyByPOAndPCBA(DJ, dtResultList.Rows(0)("PCBA").ToString)
            If Not dsPOQty.Tables(0).Rows(0)("AllowPacking") Then
                Me.ShowMessage(DJ & " " & "^SFC-114@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtIntSerial.SelectAll()
                txtIntSerial.Focus()
                Return
            End If

            If e.Result.Tables(2).Rows.count = 0 Then
                Me.ShowMessage("^SFC-95@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                Return
            End If

            Rev = e.Result.Tables(2).Rows(0)("ModelRev").ToString
            If RevInBox = "" Then
                RevInBox = BLL.RevinBox(txtBoxID.Text)
                txtDJ.Text = "Model Rev:" & RevInBox
            End If
            If BLL.DJinBox(DJ, txtBoxID.Text) = "N" Then
                Select Case SFC010.ToUpper
                    Case "WARNING"
                        'Warning: Allow multiple DJ in a box
                        If Me.ShowMessage("^SFC-83@", eTraceUI.eTraceMessageBar.MessageTypes.Warning, AnimationStatus.StopAnim, True, PopUpTypes.Question) = False Then
                            txtIntSerial.Clear()
                            txtIntSerial.Focus()
                            Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
                            Return
                        End If
                    Case "ERROR"
                        'Error: not Allow multiple DJ in a box
                        Me.ShowMessage("^SFC-47@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                        pnlBody.Enabled = True
                        txtIntSerial.Clear()
                        txtIntSerial.Focus()
                        Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
                        Return
                    Case "ALLOWED"
                        If Rev <> RevInBox Then
                            If SFC013.ToUpper = "WARNING" Then
                                If Me.ShowMessage("Rev:" & Rev & " " & "^SFC-88@", eTraceUI.eTraceMessageBar.MessageTypes.Warning, AnimationStatus.StopAnim, True, PopUpTypes.Question) = False Then
                                    txtIntSerial.Clear()
                                    txtIntSerial.Focus()
                                    Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
                                    Return
                                End If
                            End If
                            If SFC013.ToUpper = "ERROR" Then
                                Me.ShowMessage("Rev:" & Rev & " " & "^SFC-89@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                                pnlBody.Enabled = True
                                txtIntSerial.Clear()
                                txtIntSerial.Focus()
                                Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
                                Return
                            End If
                        End If
                End Select
            End If

            TVA = dtResultList.Rows(0)("TVA").ToString
            txtDJ.Text = DJ & " " & "Model Rev:" & Rev
            txtPCBANo.Text = dtResultList.Rows(0)("PCBA").ToString
            'LabelID = BLL.GetLabels(Model, txtPCBANo.Text, CurrProcess).Tables(0).Rows(0)("Label1").ToString
            dtResultList.Columns.Remove("DJ")
            dtResultList.Columns.Remove("TVA")
            dtResultList.Columns.Remove("Model")
            dtResultList.Columns.Remove("PCBA")
            dgvResult.DataSource = dtResultList

            If dtResultList.Rows(dtResultList.Rows.Count - 1)("Process").ToString.ToUpper.Trim <> "PACKING" Then
                Me.ShowMessage("^TDC-28@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtIntSerial.SelectAll()
                txtIntSerial.Focus()
                Return
            End If

            dtValuesOfCollection = e.Result.Tables(3)
            dtAttributes = e.Result.Tables(1)
            dtAttributes.Columns.Add("Pattern")
            Dim drAttributes As DataRow
            For Each drAttributes In dtAttributes.Rows
                Select Case drAttributes("Attributes")
                    Case "ProductSerialNo"
                        drAttributes("Pattern") = SerialNoPattern
                    Case "SerialNo2"
                        drAttributes("Pattern") = SN2pattern
                    Case "SerialNo3"
                        drAttributes("Pattern") = SN3pattern
                    Case "SerialNo4"
                        drAttributes("Pattern") = SN4pattern
                    Case Else
                        If drAttributes("Values").ToString <> "" Then
                            drAttributes("Pattern") = Microsoft.VisualBasic.Left(drAttributes("Values").ToString, Len(drAttributes("Values").ToString) - 1) & "?"
                        Else
                            drAttributes("Pattern") = dtValuesOfCollection.Select("Attributes='" & drAttributes("Attributes").ToString & "'")(0)("Values").ToString
                        End If
                End Select
            Next
            dtAttributes.AcceptChanges()
            dgvAttributes.DataSource = dtAttributes
            dgvAttributes.Columns("WIPID").Visible = False
            dgvAttributes.Columns("SeqNo").Visible = False
            dgvAttributes.Columns("Pattern").Visible = False

            Dim i As Integer
            Dim ErrFound As Boolean = False
            For i = 0 To dtResultList.Rows.Count - 1
                If ErrFound = True Then
                    Me.ShowMessage("^TDC-13@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtIntSerial.SelectAll()
                    txtIntSerial.Focus()
                    Return
                End If

                'If dtResultList.Rows(i)(0).ToString.ToUpper = CurrProcess.ToUpper Then   'For current process, fill in "pass" here
                '    dtResultList.Rows(i)(1) = "PASS"
                '    Exit For
                'End If
                If Microsoft.VisualBasic.Left(dtResultList.Rows(i)(1).ToString.ToUpper, 4) <> "PASS" Then
                    If dtResultList.Rows(i)(0).ToString.ToUpper.Trim = "QC4" Then   'For current process, fill in "pass" here
                        If dtResultList.Rows(i)(1).ToString.ToUpper.Trim = "" Then
                            Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
                            BLL.CheckPrevResult(txtIntSerial.Text, "QC4", user)
                            dtResultList.Rows(i)(1) = "WIPIN"
                            iQCResult = i
                            txtQCResult.Enabled = True
                            txtQCResult.Text = ""
                            txtQCResult.Focus()
                            Exit Sub
                        End If
                    End If

                    If dtResultList.Rows(i)(0).ToString.ToUpper.Trim = "PACKING" Then   'For current process, fill in "pass" here
                        dtResultList.Rows(i)(1) = "PASS"
                        Exit For
                    End If
                    dgvResult.Rows(i).Cells(1).Style.ForeColor = Color.Red
                    ErrFound = True
                End If
            Next
            Me.ShowMessage("^APP-16@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            If ExtSNSameIntSN Then  'no need to input SN
                txtExtSerial.Text = txtIntSerial.Text
                txtExtSerial.Modified = True
                txtExtSerial_ValidateDataEvent()
            Else
                txtExtSerial.Focus()
            End If
        Catch ex As Exception
            BLL.ErrorLogging("SFC-PackingbgwIntSerial_RunWorkerCompleted", user, ex.Message)
            Me.ShowMessage(ex.Message, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        End Try
    End Sub

    Private Sub txtExtSerial_ValidateData() Handles txtExtSerial.ValidateData
        txtExtSerial.Text = Trim(txtExtSerial.Text)
        If dtResultList.Rows(dtResultList.Rows.Count - 1)(1).ToString.Trim <> "PASS" Then
            Me.ShowMessage("^TDC-13@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtExtSerial.Text = ""
            txtIntSerial.SelectAll()
            txtIntSerial.Focus()
            Exit Sub
        End If
        If ExtSNSameIntSN Then
            If txtExtSerial.Text.Trim <> txtIntSerial.Text.Trim Then
                Me.ShowMessage("^TDC-23@" + " " + txtExtSerial.ElementTitle.Text, eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True)
                txtExtSerial.SelectAll()
                txtExtSerial.Focus()
                Exit Sub
            End If
        End If
        txtExtSerial_ValidateDataEvent()

    End Sub

    'for call conveniently,when the ExtSN is same as IntSN.  make it independent 
    Private Sub txtExtSerial_ValidateDataEvent()
        ValidateSerialNoAndSave()
    End Sub

    'check SN is follow the pattern or not. If yes, then focus on other txtNextSN or save.  
    Private Sub ValidateSerialNoAndSave()
        Try
            Dim SN As String = ""
            'Dim drRows() As DataRow
            'drRows = dtAttributes.Select("Values = '" & txtExtSerial.Text & "'")
            'If drRows.Length > 0 Then                   'attribute exists in the list.
            '    Me.ShowMessage("ERROR: " & txtExtSerial.Text & " ^SFC-14@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            '    txtExtSerial.SelectAll()
            '    txtExtSerial.Focus()
            '    Return
            'End If

            Dim flag As Boolean
            Dim Attr As String = ""
            Dim Patt As String = ""
            Dim drAttributes As DataRow
            For Each drAttributes In dtAttributes.Rows
                If drAttributes("Values") <> "" Then
                    Continue For
                End If
                flag = False
                Attr = drAttributes("Attributes").ToString
                Patt = drAttributes("Pattern").ToString
                Select Case drAttributes("Attributes").ToString
                    Case "IP"
                        If BLL.IsMatchRegEx(txtExtSerial.Text, 0) Then
                            'If drAttributes("Values").ToString <> "" Then         'attribute values exists, but not same as input.
                            '    Me.ShowMessage("ERROR: " & drAttributes("Attributes").ToString & " ^SFC-14@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                            '    txtExtSerial.SelectAll()
                            '    txtExtSerial.Focus()
                            '    Return
                            'End If
                            drAttributes("Values") = txtExtSerial.Text
                            flag = True
                            Exit For
                        End If
                    Case "MACAddress"
                        If BLL.IsMatchRegEx(txtExtSerial.Text, 1) Then
                            'If drAttributes("Values").ToString <> "" Then         'attribute values exists, but not same as input.
                            '    Me.ShowMessage("ERROR: " & drAttributes("Attributes").ToString & " ^SFC-14@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                            '    txtExtSerial.SelectAll()
                            '    txtExtSerial.Focus()
                            '    Return
                            'End If
                            drAttributes("Values") = txtExtSerial.Text
                            flag = True
                            Exit For
                        End If
                    Case "ProductSerialNo"
                        If Not txtProdQty.Visible Then
                            SN = txtExtSerial.Text.Trim()
                        Else
                            SN = txtProdQty.Text.Trim() & "^" & txtExtSerial.Text.Trim()
                        End If

                        If SNRangeControl Then
                            If SN < txtSNFROM.Text Or SN > txtSNTO.Text Then   'the sn not in the range
                                Me.ShowMessage("^SFC-46@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                                txtExtSerial.SelectAll()
                                txtExtSerial.Focus()
                                Return
                            End If
                        End If

                        If BLL.AlphanumericValidation(SN, drAttributes("Pattern").ToString) Then
                            'If drAttributes("Values").ToString <> "" Then         'attribute values exists, but not same as input.
                            '    Me.ShowMessage("ERROR: " & drAttributes("Attributes").ToString & " ^SFC-14@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                            '    txtExtSerial.SelectAll()
                            '    txtExtSerial.Focus()
                            '    Return
                            'End If
                            drAttributes("Values") = SN
                            flag = True
                            Exit For
                        End If
                    Case Else
                        If BLL.AlphanumericValidation(txtExtSerial.Text, drAttributes("Pattern").ToString) Then
                            'If drAttributes("Values").ToString <> "" Then         'attribute values exists, but not same as input.
                            '    Me.ShowMessage("ERROR: " & drAttributes("Attributes").ToString & " ^SFC-14@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                            '    txtExtSerial.SelectAll()
                            '    txtExtSerial.Focus()
                            '    Return
                            'End If
                            drAttributes("Values") = txtExtSerial.Text
                            flag = True
                            Exit For
                        End If
                End Select
            Next
            If flag = False Then
                'Me.ShowMessage(Attr + ":" + Patt + " " + "^SFC-167@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True)
                Me.ShowMessage("^SFC-167@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True)
                txtExtSerial.SelectAll()
                txtExtSerial.Focus()
                Exit Sub
            End If
            If BLL.AtrributeInput(dtAttributes) Then
                SaveResult()
            Else
                txtExtSerial.Clear()
                txtExtSerial.Focus()
            End If
        Catch ex As Exception
            BLL.ErrorLogging("Packing-ValidateSerialNoAndSave", user, ex.Message)
            Me.ShowMessage(ex.Message, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        End Try
    End Sub

    Private Sub SaveResult()
        Try
            If (txtBoxID.Visible = True) And (txtBoxID.Text = "") Then
                Me.ShowMessage("^TDC-108@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtBoxID.Focus()
                Exit Sub
            End If
            If (txtPalletID.Visible = True) And (txtPalletID.Text = "") Then
                Me.ShowMessage("^TDC-109@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtPalletID.Focus()
                Exit Sub
            End If
            If Not dsPackingInfo.Tables.Contains("StatusHeader") Then
                Dim dtStatusHeader As DataTable = New Data.DataTable("StatusHeader")
                dtStatusHeader.Columns.Add(New Data.DataColumn("IntSN", System.Type.GetType("System.String")))
                dtStatusHeader.Columns.Add(New Data.DataColumn("DJ", System.Type.GetType("System.String")))
                dtStatusHeader.Columns.Add(New Data.DataColumn("TVA", System.Type.GetType("System.String")))
                dtStatusHeader.Columns.Add(New Data.DataColumn("InvOrg", System.Type.GetType("System.String")))
                dtStatusHeader.Columns.Add(New Data.DataColumn("BoxID", System.Type.GetType("System.String")))
                dtStatusHeader.Columns.Add(New Data.DataColumn("PalletID", System.Type.GetType("System.String")))
                dtStatusHeader.Columns.Add(New Data.DataColumn("BoxSize", System.Type.GetType("System.String")))
                dtStatusHeader.Columns.Add(New Data.DataColumn("PalletSize", System.Type.GetType("System.String")))
                dtStatusHeader.Columns.Add(New Data.DataColumn("Model", System.Type.GetType("System.String")))
                dtStatusHeader.Columns.Add(New Data.DataColumn("PCBA", System.Type.GetType("System.String")))
                dtStatusHeader.Columns.Add(New Data.DataColumn("Customer", System.Type.GetType("System.String")))
                dtStatusHeader.Columns.Add(New Data.DataColumn("CustPN", System.Type.GetType("System.String")))
                dtStatusHeader.Columns.Add(New Data.DataColumn("CustRev", System.Type.GetType("System.String")))
                dtStatusHeader.Columns.Add(New Data.DataColumn("ProdLine", System.Type.GetType("System.String")))
                dtStatusHeader.Columns.Add(New Data.DataColumn("CurrentProcess", System.Type.GetType("System.String")))
                dtStatusHeader.Columns.Add(New Data.DataColumn("Result", System.Type.GetType("System.String")))
                dtStatusHeader.Columns.Add(New Data.DataColumn("OperatorName", System.Type.GetType("System.String")))
                dtStatusHeader.Columns.Add(New Data.DataColumn("HasDautherBoard", System.Type.GetType("System.String")))

                Dim drStatusHeader As DataRow = dtStatusHeader.NewRow
                drStatusHeader("IntSN") = txtIntSerial.Text
                drStatusHeader("DJ") = DJ
                drStatusHeader("TVA") = TVA
                drStatusHeader("InvOrg") = BLL.LoginData.OrgCode
                drStatusHeader("BoxID") = txtBoxID.Text
                drStatusHeader("PalletID") = txtPalletID.Text
                drStatusHeader("BoxSize") = Boxsize
                drStatusHeader("PalletSize") = Palletsize
                drStatusHeader("Model") = Model
                drStatusHeader("PCBA") = txtPCBANo.Text
                drStatusHeader("Customer") = Customer
                drStatusHeader("CustPN") = CPN
                drStatusHeader("CustRev") = txtQty.Text
                drStatusHeader("ProdLine") = ProductionLine() 'BLL.LoginData.ProductionLine
                drStatusHeader("Result") = "PASS"
                drStatusHeader("CurrentProcess") = "Packing"
                drStatusHeader("OperatorName") = user
                drStatusHeader("HasDautherBoard") = HasDautherBoard
                dtStatusHeader.Rows.Add(drStatusHeader)
                dsPackingInfo.Tables.Add(dtStatusHeader)
            Else
                dsPackingInfo.Tables("StatusHeader").Clear()
                Dim drStatusHeader As DataRow = dsPackingInfo.Tables("StatusHeader").NewRow
                drStatusHeader("IntSN") = txtIntSerial.Text
                drStatusHeader("DJ") = DJ
                drStatusHeader("TVA") = TVA
                drStatusHeader("InvOrg") = BLL.LoginData.OrgCode
                drStatusHeader("BoxID") = txtBoxID.Text
                drStatusHeader("PalletID") = txtPalletID.Text
                drStatusHeader("BoxSize") = Boxsize
                drStatusHeader("PalletSize") = Palletsize
                drStatusHeader("Model") = Model
                drStatusHeader("PCBA") = txtPCBANo.Text
                drStatusHeader("Customer") = Customer
                drStatusHeader("CustPN") = CPN
                drStatusHeader("CustRev") = txtQty.Text
                drStatusHeader("ProdLine") = ProductionLine() 'BLL.LoginData.ProductionLine
                drStatusHeader("Result") = "PASS"
                drStatusHeader("CurrentProcess") = "Packing"
                drStatusHeader("OperatorName") = user
                drStatusHeader("HasDautherBoard") = HasDautherBoard
                dsPackingInfo.Tables("StatusHeader").Rows.Add(drStatusHeader)
                'dsPackingInfo.Tables("StatusHeader").Rows(0)("IntSN") = txtIntSerial.Text
                'dsPackingInfo.Tables("StatusHeader").Rows(0)("InvOrg") = BLL.LoginData.OrgCode
                'dsPackingInfo.Tables("StatusHeader").Rows(0)("BoxID") = txtBoxID.Text
                'dsPackingInfo.Tables("StatusHeader").Rows(0)("PalletID") = txtPalletID.Text
                'dsPackingInfo.Tables("StatusHeader").Rows(0)("BoxSize") = Boxsize
                'dsPackingInfo.Tables("StatusHeader").Rows(0)("PalletSize") = Palletsize
                'dsPackingInfo.Tables("StatusHeader").Rows(0)("Model") = Model
                'dsPackingInfo.Tables("StatusHeader").Rows(0)("Customer") = Customer
                'dsPackingInfo.Tables("StatusHeader").Rows(0)("CustPN") = CPN
                'dsPackingInfo.Tables("StatusHeader").Rows(0)("CustRev") = Revision
                'dsPackingInfo.Tables("StatusHeader").Rows(0)("ProdLine") = BLL.LoginData.ProductionLine
                'dsPackingInfo.Tables("StatusHeader").Rows(0)("Result") = "PASS"
                'dsPackingInfo.Tables("StatusHeader").Rows(0)("CurrentProcess") = CurrProcess
                'dsPackingInfo.Tables("StatusHeader").Rows(0)("OperatorName") = user
            End If
            If Not dsPackingInfo.Tables.Contains("Attributes") Then
                Dim dtAttribute As DataTable = New DataTable("Attributes")
                dtAttribute = dtAttributes.Copy
                dtAttribute.TableName = "Attributes"
                dsPackingInfo.Tables.Add(dtAttribute)
                'if not contain '?', not send to webservice, for some barcode had to be scan, but not to save in database. 11/24
                'Dim drAttribute As DataRow
                'For Each drAttribute In dtAttribute.Rows
                '    If Not drAttribute("Pattern").ToString.Contains("?") Then
                '        drAttribute.Delete()
                '    End If
                'Next
                'dtAttributes.AcceptChanges()
                '''''''''
            Else
                dsPackingInfo.Tables.Remove("Attributes")
                Dim dtAttribute As DataTable = New DataTable("Attributes")
                dtAttribute = dtAttributes.Copy
                dtAttribute.TableName = "Attributes"
                dsPackingInfo.Tables.Add(dtAttribute)
                'if not contain '?', not send to webservice, for some barcode had to be scan, but not to save in database. 11/24
                'Dim drAttribute As DataRow
                'For Each drAttribute In dtAttribute.Rows
                '    If Not drAttribute("Pattern").ToString.Contains("?") Then
                '        drAttribute.Delete()
                '    End If
                'Next
                'dtAttributes.AcceptChanges()
                '''''''''
            End If
            dsPackingInfo.AcceptChanges()
            pnlBody.Enabled = False
            Me.ShowMessage("^TDC-26@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
            Me.bgwPost.RunWorkerAsync()
        Catch ex As Exception
            BLL.ErrorLogging("Packing-SaveResult", user, ex.Message)
            Me.ShowMessage(ex.Message, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        End Try
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        If BLL.AtrributeInput(dtAttributes) Then
            SaveResult()
        Else
            Me.ShowMessage("^SFC-16@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True)
        End If
    End Sub

    Private Sub bgwPost_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwPost.DoWork
        Try
            e.Result = BLL.WIPPaking(dsPackingInfo)
        Catch ex As Exception
            BLL.ErrorLogging("Packing-bgwPost_DoWork", user, ex.Message)
            Me.ShowMessage(ex.Message, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        End Try
    End Sub

    Private Sub bgwPost_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPost.RunWorkerCompleted
        Try
            Select Case e.Result
                Case "TDC-301@"   'The box is full
                    Me.ShowMessage("^TDC-301@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtBoxID.Text = ""
                    txtBoxQty.Text = "0"
                    pnlBody.Enabled = True
                    txtBoxID.Focus()
                Case "TDC-19@"     'Serial number is already in use!
                    Me.ShowMessage("^TDC-19@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    Dim drValue() As DataRow
                    drValue = dtAttributes.Select("Attributes='ProductSerialNo'")
                    drValue(0)("Values") = ""
                    txtExtSerial.Text = ""
                    pnlBody.Enabled = True
                    txtExtSerial.Focus()
                Case "SFC-20@"     'Serial number is not match with previous process'
                    Dim drValue() As DataRow
                    drValue = dtAttributes.Select("Attributes='ProductSerialNo'")
                    If SFC014.ToUpper = "YES" Then
                        Me.ShowMessage("^SFC-20@ ^SFC-90@" & " " & BLL.BackToEeprom(txtIntSerial.Text, drValue(0)("Values"), "ProductSerialNo"), eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                        dsPackingInfo.Clear()
                        dtAttributes.Clear()
                        dtResultList.Clear()
                        txtExtSerial.Text = ""
                        txtIntSerial.Text = ""
                        pnlBody.Enabled = True
                        txtIntSerial.Focus()
                        Return
                    End If
                    Me.ShowMessage("^SFC-20@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    drValue(0)("Values") = ""
                    txtExtSerial.Text = ""
                    pnlBody.Enabled = True
                    txtExtSerial.Focus()
                Case "SFC-17@"     'Serial number2 is already in use!
                    Me.ShowMessage("^SFC-17@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    Dim drValue() As DataRow
                    drValue = dtAttributes.Select("Attributes='SerialNo2'")
                    drValue(0)("Values") = ""
                    txtExtSerial.Text = ""
                    pnlBody.Enabled = True
                    txtExtSerial.Focus()
                Case "SFC-21@"     'Serial number2 is not match with previous process'
                    Me.ShowMessage("^SFC-21@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    Dim drValue() As DataRow
                    drValue = dtAttributes.Select("Attributes='SerialNo2'")
                    drValue(0)("Values") = ""
                    txtExtSerial.Text = ""
                    pnlBody.Enabled = True
                    txtExtSerial.Focus()
                Case "SFC-18@"     'Serial number3 is already in use!
                    Me.ShowMessage("^SFC-18@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    Dim drValue() As DataRow
                    drValue = dtAttributes.Select("Attributes='SerialNo3'")
                    drValue(0)("Values") = ""
                    txtExtSerial.Text = ""
                    pnlBody.Enabled = True
                    txtExtSerial.Focus()
                Case "SFC-22@"     'Serial number3 is not match with previous process'
                    Me.ShowMessage("^SFC-22@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    Dim drValue() As DataRow
                    drValue = dtAttributes.Select("Attributes='SerialNo3'")
                    drValue(0)("Values") = ""
                    txtExtSerial.Text = ""
                    pnlBody.Enabled = True
                    txtExtSerial.Focus()
                Case "SFC-19@"     'Serial number4 is already in use!
                    Me.ShowMessage("^SFC-19@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    Dim drValue() As DataRow
                    drValue = dtAttributes.Select("Attributes='SerialNo4'")
                    drValue(0)("Values") = ""
                    txtExtSerial.Text = ""
                    pnlBody.Enabled = True
                    txtExtSerial.Focus()
                Case "SFC-23@"     'Serial number4 is not match with previous process'
                    Me.ShowMessage("^SFC-23@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    Dim drValue() As DataRow
                    drValue = dtAttributes.Select("Attributes='SerialNo4'")
                    drValue(0)("Values") = ""
                    txtExtSerial.Text = ""
                    pnlBody.Enabled = True
                    txtExtSerial.Focus()
                Case "SFC-24@"     'IP is not match with previous process'
                    Me.ShowMessage("^SFC-24@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    Dim drValue() As DataRow
                    drValue = dtAttributes.Select("Attributes='IP'")
                    drValue(0)("Values") = ""
                    txtExtSerial.Text = ""
                    pnlBody.Enabled = True
                    txtExtSerial.Focus()
                Case "SFC-25@"     'MAC is not match with previous process'
                    Me.ShowMessage("^SFC-25@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    Dim drValue() As DataRow
                    drValue = dtAttributes.Select("Attributes='MACAddress'")
                    drValue(0)("Values") = ""
                    txtExtSerial.Text = ""
                    pnlBody.Enabled = True
                    txtExtSerial.Focus()
                Case "TDC-303@"    'The Pallet is full
                    Me.ShowMessage("^TDC-303@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    txtPalletID.Text = ""
                    txtPalletID.Text = "0"
                    pnlBody.Enabled = True
                    txtPalletID.Focus()
                Case "0"
                    Me.ShowMessage("^SFC-26@" + "  " + dtAttributes.Select("Attributes='ProductSerialNo'")(0)("Values").ToString, eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
                    pnlBody.Enabled = True
                    dtAttributes.Clear()
                    dtResultList.Clear()
                    txtExtSerial.Text = ""
                    txtIntSerial.Text = ""
                    txtIntSerial.Focus()
                Case "SFC-27@"
                    Me.ShowMessage("^SFC-27@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    pnlBody.Enabled = True
                    dtAttributes.Clear()
                    dtResultList.Clear()
                    txtExtSerial.Text = ""
                    txtIntSerial.Text = ""
                    txtIntSerial.Focus()
                Case "SFC-47@"
                    Me.ShowMessage("^SFC-47@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    pnlBody.Enabled = True
                    dtAttributes.Clear()
                    dtResultList.Clear()
                    txtExtSerial.Text = ""
                    txtIntSerial.Text = ""
                    txtIntSerial.Focus()
                Case "SFC-48@"
                    Me.ShowMessage("^SFC-48@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    pnlBody.Enabled = True
                    dtAttributes.Clear()
                    dtResultList.Clear()
                    txtExtSerial.Text = ""
                    txtIntSerial.Text = ""
                    txtIntSerial.Focus()
                Case "SFC-49@"
                    Me.ShowMessage("^SFC-49@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    pnlBody.Enabled = True
                    dtAttributes.Clear()
                    dtResultList.Clear()
                    txtExtSerial.Text = ""
                    txtIntSerial.Text = ""
                    txtIntSerial.Focus()
                Case "SFC-50@"
                    Me.ShowMessage("^SFC-50@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    pnlBody.Enabled = True
                    dtAttributes.Clear()
                    dtResultList.Clear()
                    txtExtSerial.Text = ""
                    txtIntSerial.Text = ""
                    txtIntSerial.Focus()
                Case "SFC-51@"
                    Me.ShowMessage("^SFC-51@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    pnlBody.Enabled = True
                    dtAttributes.Clear()
                    dtResultList.Clear()
                    txtExtSerial.Text = ""
                    txtIntSerial.Text = ""
                    txtIntSerial.Focus()
                Case "SFC-52@"
                    Me.ShowMessage("^SFC-52@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    pnlBody.Enabled = True
                    dtAttributes.Clear()
                    dtResultList.Clear()
                    txtExtSerial.Text = ""
                    txtIntSerial.Text = ""
                    txtIntSerial.Focus()
                Case "SFC-53@"
                    Me.ShowMessage("^SFC-53@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    pnlBody.Enabled = True
                    dtAttributes.Clear()
                    dtResultList.Clear()
                    txtExtSerial.Text = ""
                    txtIntSerial.Text = ""
                    txtIntSerial.Focus()
                Case "SFC-54@"
                    Me.ShowMessage("^SFC-54@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    pnlBody.Enabled = True
                    dtAttributes.Clear()
                    dtResultList.Clear()
                    txtExtSerial.Text = ""
                    txtIntSerial.Text = ""
                    txtIntSerial.Focus()
                Case "SFC-55@"
                    Me.ShowMessage("^SFC-55@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    pnlBody.Enabled = True
                    dtAttributes.Clear()
                    dtResultList.Clear()
                    txtExtSerial.Text = ""
                    txtIntSerial.Text = ""
                    txtIntSerial.Focus()
                Case "SFC-56@"
                    Me.ShowMessage("^SFC-56@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    pnlBody.Enabled = True
                    dtAttributes.Clear()
                    dtResultList.Clear()
                    txtExtSerial.Text = ""
                    txtIntSerial.Text = ""
                    txtIntSerial.Focus()
                Case "SFC-57@"
                    Me.ShowMessage("^SFC-57@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    pnlBody.Enabled = True
                    dtAttributes.Clear()
                    dtResultList.Clear()
                    txtExtSerial.Text = ""
                    txtIntSerial.Text = ""
                    txtIntSerial.Focus()
                Case "SFC-58@"
                    Me.ShowMessage("^SFC-58@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                    pnlBody.Enabled = True
                    dtAttributes.Clear()
                    dtResultList.Clear()
                    txtExtSerial.Text = ""
                    txtIntSerial.Text = ""
                    txtIntSerial.Focus()
                Case Else
                    If e.Result = "" Or e.Result Is Nothing Then
                        Me.ShowMessage("^SFC-117@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                        pnlBody.Enabled = True
                        dtAttributes.Clear()
                        dtResultList.Clear()
                        txtExtSerial.Text = ""
                        txtIntSerial.Text = ""
                        txtIntSerial.Focus()
                        Return
                    End If
                    txtBoxQty.Text = e.Result
                    Me.ShowMessage("^SFC-26@" + "  " + dtAttributes.Select("Attributes='ProductSerialNo'")(0)("Values").ToString, eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
                    If LabelID <> "" Then
                        PrintSN = dtAttributes.Select("Attributes='ProductSerialNo'")(0)("Values").ToString
                        If LabelType <> "PRODUCT LABEL" Then
                            If txtBoxQty.Text.Trim = txtBoxSize.Text.Trim Then
                                PrintPackingList()
                            End If
                        Else
                            PrintPackingList()
                        End If
                    End If
                    dsPackingInfo.Clear()
                    dtAttributes.Clear()
                    dtResultList.Clear()
                    pnlBody.Enabled = True
                    txtQCResult.Text = ""
                    txtExtSerial.Text = ""
                    txtIntSerial.Text = ""
                    If txtBoxQty.Text.Trim = txtBoxSize.Text.Trim Then
                        txtBoxQty.Text = "0"
                        txtBoxID.Text = ""
                        txtBoxID.Focus()
                    Else
                        txtIntSerial.Focus()
                    End If
            End Select
        Catch ex As Exception
            BLL.ErrorLogging("Packing-bgwPost_RunWorkerCompleted", user, ex.Message)
            Me.ShowMessage(ex.Message, eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
        End Try
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If SFC025 = "YES" Then
            Dim strInput As String
            strInput = Me.ShowMessageInput("^APP-66@", AnimationStatus.StopAnim, 0, True)
            If strInput = "" Then Exit Sub
            If BLL.GetResult(strInput, "REPRINT", "") <> "REPRINT" Then
                Me.ShowMessage("^APP-67@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                Exit Sub
            End If
        End If
        PrintPackingList()
    End Sub

    Private Sub PrintPackingList()
        If LabelID = "" Then
            Exit Sub
        End If
        If LabelType <> "PRODUCT LABEL" Then
            'If txtBoxQty.Text.Trim <> txtBoxSize.Text.Trim Then
            '    Exit Sub
            'End If
            If txtBoxID.Text.Trim = "" Then
                Exit Sub
            End If
        End If
        If LabelPrinter() <> "" Then
            Me.ShowMessage("^SFC-28@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
            Me.bgwPrint.RunWorkerAsync()
        Else
            Me.ShowMessage("^TDC-163@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
        End If
    End Sub

    Private Sub bgwPrint_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwPrint.DoWork
        Try
            If LabelType = "PRODUCT LABEL" Then
                e.Result = BLL.PrintSNLabel(PrintSN, LabelID, LabelPrinter)
            Else
                e.Result = BLL.PrintPaking(BoxID, LabelID, LabelPrinter)
            End If
        Catch ex As Exception
            BLL.ErrorLogging("Packing-bgwPrint_DoWork", user, ex.Message)
            Me.ShowMessage("^SFC-30@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
        End Try
    End Sub

    Private Sub bgwPrint_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPrint.RunWorkerCompleted
        Me.ShowMessage("^SFC-29@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Me.DisableValidation = True
        dtProductCPN.Clear()
        dsPackingInfo.Clear()
        If Not dtAttributes Is Nothing Then
            dtAttributes.Clear()
        End If
        If Not dtResultList Is Nothing Then
            dtResultList.Clear()
        End If
        tmpCPN = ""
        txtModelNo.Text = ""
        txtPONo.Items.Clear()
        txtPONo.Enabled = False
        txtPONo.Text = ""
        txtPOPCBA.Text = ""
        txtPCBANo.Text = ""
        txtQty.Text = ""
        txtBoxID.Text = ""
        txtBoxID.Visible = False
        txtBoxQty.Visible = False
        txtBoxQty.Enabled = False
        txtBoxSize.Visible = False
        txtBoxQty.Text = "0"
        txtBoxSize.Text = ""
        txtPalletID.Text = ""
        txtPalletID.Visible = False
        txtPalletQty.Visible = False
        txtPalletQty.Enabled = False
        txtPalletSize.Visible = False
        txtPalletQty.Text = "0"
        txtPalletSize.Text = ""
        txtExtSerial.Text = ""
        txtIntSerial.Text = ""
        grpDataInput.Visible = False
        grpActions.Visible = False
        grpModel.Enabled = True
        btnEMI.Visible = False
        txtPOPCBA.Focus()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Me.DisableValidation = True
        If Not dtAttributes Is Nothing Then
            dtAttributes.Clear()
        End If
        If Not dtResultList Is Nothing Then
            dtResultList.Clear()
        End If
        txtExtSerial.Text = ""
        txtIntSerial.Text = ""
        txtBoxID.Text = ""
        txtBoxQty.Text = "0"
        txtPalletID.Text = ""
        txtPalletQty.Text = "0"
        If Boxsize > 0 Then
            txtBoxID.Focus()
        Else
            txtIntSerial.Focus()
        End If
    End Sub

    Private Sub frmPacking_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Try
            SerialPort1.Open()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmPacking_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
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
        ElseIf txtBoxID.Focus Then
            txtBoxID.Text = ReceivedText
            My.Computer.Keyboard.SendKeys("{TAB}")
        ElseIf txtPalletID.Focus Then
            txtPalletID.Text = ReceivedText
            My.Computer.Keyboard.SendKeys("{TAB}")
        ElseIf txtQCResult.Focus Then
            txtQCResult.Text = ReceivedText
            txtQCResult.Modified = True
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

    Private Sub txtSNFROM_ValidateData() Handles txtSNFROM.ValidateData
        txtSNFROM.Text = Trim(txtSNFROM.Text)
        If txtSNFROM.Text = "" Then
            txtSNFROM.Focus()
        Else
            txtSNTO.Focus()
        End If
    End Sub

    Private Sub txtSNTO_ValidateData() Handles txtSNTO.ValidateData
        txtSNTO.Text = Trim(txtSNTO.Text)
        If txtSNTO.Text = "" Then
            txtSNTO.Focus()
        Else
            If txtSNTO.Text < txtSNFROM.Text Then
                'SNTO can not over SNFROM
                Me.ShowMessage("^SFC-180@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
                txtSNTO.Focus()
            Else
                txtIntSerial.Focus()
            End If
        End If
    End Sub

    Private Sub txtBoxSize_ValidateData() Handles txtBoxSize.ValidateData
        txtBoxSize.Text = Trim(txtBoxSize.Text)
        If txtBoxSize.Text = "" Then
            txtBoxSize.Focus()
        Else
            Boxsize = Convert.ToInt32(txtBoxSize.Text)
            txtBoxID.Focus()
        End If

    End Sub

    Private Sub txtPalletSize_ValidateData() Handles txtPalletSize.ValidateData
        txtPalletSize.Text = Trim(txtPalletSize.Text)
        If txtPalletSize.Text = "" Then
            txtPalletSize.Focus()
        Else
            Palletsize = Convert.ToInt32(txtPalletSize.Text)
            txtPalletID.Focus()
        End If
    End Sub

    Private Sub txtQCResult_ValidateData() Handles txtQCResult.ValidateData
        If Trim(txtIntSerial.Text) = "" Then
            Exit Sub
        End If
        txtQCResult.Text = Trim(txtQCResult.Text)
        If Trim(txtQCResult.Text) <> "" Then
            Me.ShowMessage("^TDC-24@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StartAnim, False)
            pnlBody.Enabled = False
            Me.bgwQCResult.RunWorkerAsync()
        End If
    End Sub

    Private Sub bgwQCResult_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwQCResult.DoWork
        Try
            e.Result = BLL.GetResult(txtQCResult.Text, "QC4", "")
        Catch ex As Exception
            BLL.ErrorLogging("SFC-txtQCResult_ValidateData", "", ex.Message)
        End Try
    End Sub

    Private Sub bgwQCResult_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwQCResult.RunWorkerCompleted
        pnlBody.Enabled = True
        If e.Result.ToString.ToUpper <> "PASS" AndAlso e.Result.ToString.ToUpper <> "FAIL" AndAlso e.Result.ToString.ToUpper <> "SKIP" Then
            Me.ShowMessage("^SFC-179@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            txtQCResult.SelectAll()
            txtQCResult.Focus()
        Else
            Me.ShowMessage("^TDC-59@", eTraceUI.eTraceMessageBar.MessageTypes.NoMessage, AnimationStatus.StopAnim)
            txtQCResult.Text = e.Result.ToString.ToUpper()
            doPost()
            'If e.Result.ToString.ToUpper = "PASS" Or e.Result.ToString.ToUpper = "SKIP" Then
            '    doPost()
            'Else
            '    txtSymptom.Focus()
            'End If

        End If
    End Sub


    Private Sub doPost()
        With BLL.StatusHeader
            .IntSerial = txtIntSerial.Text
            .Result = txtQCResult.Text
            .Process = "QC4"
            .OperatorName = user
        End With
        If (Not BLL.SCRSaveResult(BLL.StatusHeader)) Then
            Me.ShowMessage("^TDC-61@", eTraceUI.eTraceMessageBar.MessageTypes.Abort, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            grpDataInput.Enabled = True
            txtQCResult.SelectAll()
            txtQCResult.Focus()
        Else
            Me.ShowMessage("^TDC-60@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim)
            setQCResult(iQCResult, txtQCResult.Text)         'QC4 fill pass
            If txtQCResult.Text = "PASS" Then
                setQCResult(iQCResult + 1, txtQCResult.Text)  'packing fill pass
                If ExtSNSameIntSN Then  'no need to input SN
                    txtExtSerial.Text = txtIntSerial.Text
                    txtExtSerial.Modified = True
                    txtExtSerial_ValidateDataEvent()
                Else
                    txtExtSerial.Focus()
                End If
                txtQCResult.Text = ""
                txtQCResult.Enabled = False
            Else
                txtQCResult.Text = ""
                txtQCResult.Enabled = False
                txtIntSerial.Text = ""
                txtIntSerial.Focus()
            End If
        End If
    End Sub
    Private Sub setQCResult(ByVal i As Integer, ByVal Result As String)
        dtResultList.Rows(i)(1) = Result
        dtResultList.AcceptChanges()
    End Sub

    Private Sub txtSymptom_ValidateData() Handles txtSymptom.ValidateData
        If txtQCResult.Text = "FAIL" Then
            txtQCResult.Text = "FAIL/" & txtSymptom.Text
            doPost()
        End If
    End Sub
End Class
