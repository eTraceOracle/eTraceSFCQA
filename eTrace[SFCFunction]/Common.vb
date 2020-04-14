Partial Class Functions   'Common function

    Public Function SetTDCEnv(ByVal eTraceServer As String) As Boolean
        Dim a As Integer
        a = InStr(8, My.Settings.eTrace_SFCFunction__eTraceSFCService_eTraceOracleERP, "/", CompareMethod.Text)
        If a > 0 Then
            My.Settings.eTrace_SFCFunction__eTraceSFCService_eTraceOracleERP = Mid(My.Settings.eTrace_SFCFunction__eTraceSFCService_eTraceOracleERP, 1, 7) & eTraceServer & Mid(My.Settings.eTrace_SFCFunction__eTraceSFCService_eTraceOracleERP, a)
        End If
        eTraceRS.Url = My.Settings.eTrace_SFCFunction__eTraceSFCService_eTraceOracleERP

        'Dim b As Integer
        'b = InStr(8, My.Settings.eTrace_SFCFunction__eTraceOTOService_eTraceOTOService, "/", CompareMethod.Text)
        'If b > 0 Then
        '    My.Settings.eTrace_SFCFunction__eTraceOTOService_eTraceOTOService = Mid(My.Settings.eTrace_SFCFunction__eTraceOTOService_eTraceOTOService, 1, 7) & eTraceServer & Mid(My.Settings.eTrace_SFCFunction__eTraceOTOService_eTraceOTOService, b)
        'End If
        'eTrace121.Url = My.Settings.eTrace_SFCFunction__eTraceOTOService_eTraceOTOService

        My.Settings.Save()
        My.Settings.Reload()
    End Function

    'call it when program found exception,record error message on T_Errorlog.
    Public Sub ErrorLogging(ByVal ModuleName As String, ByVal User As String, ByVal ErrMsg As String)
        eTraceRS.ErrorLogging(ModuleName, User, ErrMsg)
    End Sub

    Private Sub AddErrorTable(ByVal DS As DataSet)
        Dim ErrorMsg As DataTable
        Dim myDataColumn As DataColumn
        ErrorMsg = New Data.DataTable("ErrorMsg")

        myDataColumn = New Data.DataColumn("ErrorMsg", System.Type.GetType("System.String"))
        ErrorMsg.Columns.Add(myDataColumn)

        DS.Tables.Add(ErrorMsg)
    End Sub

    Public Function FixNull(ByVal vMayBeNull As Object) As String
        On Error Resume Next
        FixNull = vbNullString & vMayBeNull
    End Function

    'Create WIP Dataset
    Public Function DSWIP() As DataSet
        Dim DS As DataSet = New DataSet("WIP")

        Dim WIPHeader As DataTable = New Data.DataTable("WIPHeader")
        WIPHeader.Columns.Add(New Data.DataColumn("IntSN", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("Model", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("PCBA", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("DJ", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("TVA", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("InvOrg", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("ProdLine", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("CurrentProcess", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("TestRound", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("Result", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("AllPassed", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("ReuseChildISN", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("MotherBoardSN", System.Type.GetType("System.String")))
        WIPHeader.Columns.Add(New Data.DataColumn("ChangedBy", System.Type.GetType("System.String")))

        Dim WIPFlow As DataTable = New Data.DataTable("WIPFlow")
        WIPFlow.Columns.Add(New Data.DataColumn("SeqNo", System.Type.GetType("System.String")))
        WIPFlow.Columns.Add(New Data.DataColumn("Process", System.Type.GetType("System.String")))
        WIPFlow.Columns.Add(New Data.DataColumn("Status", System.Type.GetType("System.String")))
        WIPFlow.Columns.Add(New Data.DataColumn("TestRound", System.Type.GetType("System.String")))
        WIPFlow.Columns.Add(New Data.DataColumn("LastResult", System.Type.GetType("System.String")))

        Dim WIPProperties As DataTable = New Data.DataTable("WIPProperties")
        WIPProperties.Columns.Add(New Data.DataColumn("SeqNo", System.Type.GetType("System.String")))
        WIPProperties.Columns.Add(New Data.DataColumn("PropertyType", System.Type.GetType("System.String")))
        WIPProperties.Columns.Add(New Data.DataColumn("PropertyName", System.Type.GetType("System.String")))
        WIPProperties.Columns.Add(New Data.DataColumn("PropertyValue", System.Type.GetType("System.String")))
        WIPProperties.Columns.Add(New Data.DataColumn("ChangedBy", System.Type.GetType("System.String")))

        DS.Tables.Add(WIPHeader)
        DS.Tables.Add(WIPFlow)
        DS.Tables.Add(WIPProperties)
        Return DS
    End Function

    'Dataset transfer to XML for storeprocedure calling
    Public Function DStoXML(ByVal DS As DataSet) As String
        Return DS.GetXml()
    End Function

    Public Function GetAccessCardUserInfo(ByVal AccessCardID As String) As eTrace_SFCFunction_.eTraceSFCService.AccessCard
        Return eTraceRS.GetAccessCardUserInfo(AccessCardID)
    End Function

    'WipIn
    Public Function CheckPrevResult(ByVal IntSerialNo As String, ByVal Process As String, ByVal User As String) As String

        CheckPrevResult = "INVALID"
        Dim PrevResult As String
        Dim returnValue As String
        PrevResult = eTraceRS.CheckPrevResult(IntSerialNo, Process)
        If (PrevResult.ToUpper = "PASS") Then
            returnValue = LargeThanMaxTest(IntSerialNo, Process)
            If (returnValue.ToUpper = "PASS") Then
                'CheckPrevResult = "PASS"
                'eTraceRS.WIPIn(IntSerialNo, Process, User)
                If eTraceRS.WIPIn(IntSerialNo, Process, User) Then
                    CheckPrevResult = "PASS"
                End If
            End If
        End If
        'If (CheckPrevResult.ToUpper <> "PASS") Then
        '    CheckPrevResult = "INVALID"
        'End If
        Return CheckPrevResult
    End Function

    'WipIn
    Public Function CheckPrevResultNotWipIn(ByVal IntSerialNo As String, ByVal Process As String, ByVal User As String) As String

        CheckPrevResultNotWipIn = "INVALID"
        Dim returnValue As String
        CheckPrevResultNotWipIn = eTraceRS.CheckPrevResult(IntSerialNo, Process)
        If (CheckPrevResultNotWipIn.ToUpper = "PASS") Then
            returnValue = LargeThanMaxTest(IntSerialNo, Process)
            If (returnValue.ToUpper = "PASS") Then
                CheckPrevResultNotWipIn = "PASS"
            Else
                CheckPrevResultNotWipIn = returnValue
            End If
        End If
        Return CheckPrevResultNotWipIn
    End Function

    Public Function LargeThanMaxTest(ByVal IntSerialNo As String, ByVal Process As String) As String
        LargeThanMaxTest = eTraceRS.LargeThanMaxTest(IntSerialNo, Process)
    End Function

    Public Function SCRSaveResult(ByVal Header As eTraceSFCService.StatusHeaderStructure) As Boolean
        SCRSaveResult = False
        If Header.Result.ToUpper = "RECYCLE" Then
            'TODO -FOR ID Recycle
        End If

        Try
            SCRSaveResult = eTraceRS.WIPOut(Header)
        Catch ex As Exception
            eTraceRS.ErrorLogging("SFC-SCRSaveResult", "", Header.IntSerial & ", " & Header.Process & ", " & ex.Message)
        End Try

    End Function

   
    Public Function GetResult(ByVal CardID As String, ByVal CurrProcess As String, ByVal IntSN As String) As String
        GetResult = "'"
        Try
            GetResult = eTraceRS.GetResult(CardID, CurrProcess)

            If (GetResult = "SKIP") Then
                If (eTraceRS.checkSamplingTest(IntSN, CurrProcess) = -1) Then
                    GetResult = ""
                End If
            End If
        Catch ex As Exception
            eTraceRS.ErrorLogging("SFC-GetResult", "", CardID + ", " + CurrProcess + ", " + ex.Message)
        End Try
    End Function

    Public Function GetDataByIntSN(ByVal BarcodeNo As String) As DataSet
        GetDataByIntSN = eTraceRS.GetDataByIntSN(BarcodeNo)
    End Function


    Public Function getMIFileData(ByVal model As String, ByVal PCBA As String, ByVal process As String) As Object
        getMIFileData = eTraceRS.getMIFileData(model, PCBA, process)
    End Function

    Public Function getConfig(ByVal eTraceModule As String) As DataSet
        Return eTraceRS.GetConfig(eTraceModule)
    End Function
End Class
