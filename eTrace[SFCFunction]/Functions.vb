
Public Class Functions


    Public Function ReadXMLByProperty(ByVal strProperty As String, ByVal strField As String, Optional ByVal ProcessID As String = "") As String
        Dim eTraceMessages As DataSet = New DataSet
        Dim myDR() As DataRow
        ReadXMLByProperty = ""

        Try
            eTraceMessages.ReadXml(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\eTrace\TestDataCollection\ProcessConfig.xml")
            If ProcessID = "" Then
                myDR = eTraceMessages.Tables(1).Select("Property Like '" & strProperty & "'")
            Else
                myDR = eTraceMessages.Tables(1).Select("ProcessID = '" & ProcessID & "' And Property Like '" & strProperty & "'")
            End If
            If myDR.Length > 0 Then
                ReadXMLByProperty = myDR(0)(strField)
            End If
        Catch ex As Exception
            eTraceRS.ErrorLogging("TDC-ReadXMLByProperty", "", ex.Message) '1.0.0.9
        End Try
    End Function

    Public Function ReadPCBAStructure(ByVal Model As String, ByVal PCBA As String, ByVal Process As String) As DataSet

    End Function

    Public Function ReadStatus(ByVal IntSerialNo As String, ByVal FieldName As String) As String

    End Function

    Public Function ReadFailedTestStep(ByVal IntSerialNo As String) As String

    End Function

    Private Function ReadDeliText(ByVal SourceFile As String, ByVal strSeek As String, ByVal Position As Integer) As String

    End Function

    Public Function SerialNoInUse(ByVal IntSerialNo As String) As Boolean

    End Function

    Public Function FixtureIDInUse(ByVal FixtureID As String, ByVal PanelSize As Integer) As Boolean

    End Function

    Public Function SerialNoExist(ByVal serialNo As String) As String

    End Function

    Public Function IDSwop(ByVal BarcodeNo As String, ByVal SCRNo As String) As Boolean

    End Function


    Public Function ReadResultbySerial(ByVal IntSerialNo As String, ByRef mydataset As DataSet) As String

    End Function

    Public Function SearchSession(ByVal SourceFile As String, ByVal Session As String, ByVal Position As Integer, ByVal strSeek As String) As Boolean

    End Function

    Public Function ReadDeliTextBySession(ByVal SourceFile As String, ByVal Session As String, ByVal strSeek As String, ByVal Position As Integer, Optional ByVal PosiSeek As Integer = 1) As String

    End Function

    Public Function ReadTestSteps(ByVal IntSerialNo As String, ByVal TestStatus As String) As String()

    End Function

    Private Function ReadDeliArrayBySession(ByVal SourceFile As String, ByVal Session As String, ByVal Position As Integer, ByVal strSeek As String, ByVal posiSeek As Integer) As String()

    End Function

    Public Function SubPCBAInput(ByVal tblPCBA As DataTable) As Boolean
        Dim i As Integer

        'Return false if any blank serial number
        For i = 0 To tblPCBA.Rows.Count - 1
            If tblPCBA.Rows(i)(2) Is DBNull.Value Then
                Return False
            End If
            If tblPCBA.Rows(i)(2) = "" Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Function ScrMatchScr(ByVal oldScrNo As String, ByVal newScrNo As String) As Boolean

    End Function

    Public Function SwopFiles(ByVal currFile As String, ByVal newFile As String) As Boolean

    End Function

    Public Function GetFlowControl(ByVal Model As String, ByVal PCBA As String) As String

    End Function

    Public Function CreateStatusFile(ByVal Header As eTraceSFCService.StatusHeaderStructure, ByVal tblPCBA As DataTable, Optional ByVal ChooseStation As Boolean = False) As String

    End Function
    Public Function CreateStatusFileByPanel(ByVal Header As eTraceSFCService.StatusHeaderStructure, ByVal PanelSize As Integer, ByVal PanelID As String) As String

    End Function
   

    Public Function ReadPCBAbySerialID(ByVal IntSerialNo As String) As String

    End Function

    Public Function UpdateStatusFile(ByVal Header As eTraceSFCService.StatusHeaderStructure) As Boolean

    End Function

    Public Function MassUpdateStatusSession(ByVal IntSerial As String, ByVal Session As String, ByVal Position As Integer, ByVal NewValue As String, ByVal strSeek As String, ByVal SingleRow As Boolean) As Boolean


    End Function

    Public Function WriteResultToFile(ByVal Header As eTraceSFCService.StatusHeaderStructure) As String



    End Function

    Public Function WriteResultToFileByPanel(ByVal Header As eTraceSFCService.StatusHeaderStructure, ByVal PanelID As String) As Boolean

    End Function

    Public Function GetTestResult(ByVal SerialNo As String, ByVal Process As String, Optional ByVal Model As String = "", Optional ByVal PCBA As String = "") As DataSet

    End Function


    Public Function TestDataCollection(ByVal Header As eTraceSFCService.StatusHeaderStructure, ByVal ProdLine As String) As String

    End Function

    Public Function BoardExplosion(ByVal StatusFolder As String, ByVal FileExt As String, ByVal MotherBoard As String, ByRef BoardCount As Integer, ByRef BoardList() As String) As String


    End Function

    'The below function is to read the full board list for a product, for Repair program        '1.0.1.0
    Public Function ReadAllBoards(ByVal IntSerialNo As String) As String()

    End Function

    Public Function OQAtDataCollection(ByVal Header As eTraceSFCService.StatusHeaderStructure, ByVal ProdLine As String) As String


    End Function

    Public Function ProductRework(ByVal Header As eTraceSFCService.StatusHeaderStructure, Optional ByVal ChooseStation As Boolean = False) As String

    End Function



    Public Function AppendText(ByVal toFile As String, ByVal fromFile As String) As Boolean

    End Function

    Public Function ReadModelDesc(ByVal FieldName As String) As String


    End Function

    Public Function ReadModelBoradList(ByVal FieldName As String) As DataSet

    End Function

    Public Function Movefile(ByVal fromFile As String, ByVal toFile As String) As Boolean

    End Function

    Public Function ReadDeliSession(ByVal SourceFile As String, ByVal Session As String, ByVal Position As Integer) As String()

    End Function

    Private Sub AddPCBATable(ByVal DS As DataSet)

    End Sub

    Private Sub AddProcessTable(ByVal DS As DataSet)

    End Sub

    Public Sub AddResultHeaderTable(ByVal DS As DataSet)
        Dim ResultHeader As DataTable
        Dim myDataColumn As DataColumn
        ResultHeader = New Data.DataTable("TDHeader")

        myDataColumn = New Data.DataColumn("ExtSerial", System.Type.GetType("System.String"))
        ResultHeader.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("IntSerial", System.Type.GetType("System.String"))
        ResultHeader.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("Process", System.Type.GetType("System.String"))
        ResultHeader.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("SeqNo", System.Type.GetType("System.String"))
        ResultHeader.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("PO", System.Type.GetType("System.String"))
        ResultHeader.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("Model", System.Type.GetType("System.String"))
        ResultHeader.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("PCBA", System.Type.GetType("System.String"))
        ResultHeader.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("Result", System.Type.GetType("System.String"))
        ResultHeader.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("OperatorName", System.Type.GetType("System.String"))
        ResultHeader.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("Tester", System.Type.GetType("System.String"))
        ResultHeader.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("ProgramName", System.Type.GetType("System.String"))
        ResultHeader.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("ProgramVersion", System.Type.GetType("System.String"))
        ResultHeader.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("IPSNo", System.Type.GetType("System.String"))
        ResultHeader.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("IPSVersion", System.Type.GetType("System.String"))
        ResultHeader.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("Remark", System.Type.GetType("System.String"))
        ResultHeader.Columns.Add(myDataColumn)
        DS.Tables.Add(ResultHeader)
    End Sub

    Public Sub AddResultItemTable(ByVal DS As DataSet)
        Dim ResultItem As DataTable
        Dim myDataColumn As DataColumn
        ResultItem = New Data.DataTable("TDItem")

        myDataColumn = New Data.DataColumn("ExtSerialNo", System.Type.GetType("System.String"))
        ResultItem.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("IntSerialNo", System.Type.GetType("System.String"))
        ResultItem.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("ProcessName", System.Type.GetType("System.String"))
        ResultItem.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("SeqNo", System.Type.GetType("System.String"))
        ResultItem.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("TestStep", System.Type.GetType("System.String"))
        ResultItem.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("TestName", System.Type.GetType("System.String"))
        ResultItem.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("OutputName", System.Type.GetType("System.String"))
        ResultItem.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("InputCondition", System.Type.GetType("System.String"))
        ResultItem.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("OutputLoading", System.Type.GetType("System.String"))
        ResultItem.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("LowerLimit", System.Type.GetType("System.String"))
        ResultItem.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("Result", System.Type.GetType("System.String"))
        ResultItem.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("UpperLimit", System.Type.GetType("System.String"))
        ResultItem.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("Unit", System.Type.GetType("System.String"))
        ResultItem.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("Status", System.Type.GetType("System.String"))
        ResultItem.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("IPSReference", System.Type.GetType("System.String"))
        ResultItem.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("TestID", System.Type.GetType("System.String"))
        ResultItem.Columns.Add(myDataColumn)

        DS.Tables.Add(ResultItem)
    End Sub

    Public Sub AddResultAttributeTable(ByVal DS As DataSet)
        Dim ResultItem As DataTable
        Dim myDataColumn As DataColumn
        ResultItem = New Data.DataTable("TDProperties")

        myDataColumn = New Data.DataColumn("PropertyType", System.Type.GetType("System.String"))
        ResultItem.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("PropertyName", System.Type.GetType("System.String"))
        ResultItem.Columns.Add(myDataColumn)
        myDataColumn = New Data.DataColumn("PropertyValue", System.Type.GetType("System.String"))
        ResultItem.Columns.Add(myDataColumn)

        DS.Tables.Add(ResultItem)
    End Sub

    Private Sub AddSwopListTable(ByVal DS As DataSet)

    End Sub

    Private Sub AddBoardListTable(ByVal DS As DataSet)

    End Sub

    Public Function MatchingNo(ByVal PO As String, ByVal PCBA As String) As Integer

    End Function
    Public Function MatchingAccount(ByVal Header As eTraceSFCService.StatusHeaderStructure, ByVal Allow As Integer) As Boolean

    End Function

    Public Function MatchingAccountByPanel(ByVal Header As eTraceSFCService.StatusHeaderStructure, ByVal PanelSize As Integer, ByVal Allow As Integer) As Boolean

    End Function

    Public Function TestDataDisplay(ByVal Header As eTraceSFCService.StatusHeaderStructure) As DataSet

    End Function

    Public Function CheckSN(ByVal IntSN As String, ByVal SN As String, ByVal ColumnIndex As Integer) As Boolean

    End Function

    Public Function OpenPrintLabels(ByVal boxid As String, ByVal printer As String) As Boolean

    End Function
    ''' <summary>
    ''' Judging   whether  param is positive integers 
    ''' </summary>
    ''' <returns></returns>
    Public Function IsPositiveInteger(ByVal txt As String) As Boolean
        Dim txtRef As Integer
        If Integer.TryParse(txt, txtRef) Then
            Return txtRef > 0
        Else
            Return False
        End If
    End Function


End Class
