Partial Class Functions

    Public Function DJValidation(ByVal DJ As String, ByVal status As String, ByVal LoginData As eTraceSFCService.ERPLogin) As DataSet
        'DJValidation = New DataSet
        'AddErrorTable(DJValidation)
        'Dim dt As DataTable = New DataTable("DJInfo")
        'Dim DjInfo As eTraceTDCService.OrderInfo
        'Dim ds As DataSet
        'Try
        'DJInfo = eTraceTDCRS.GetOrderInfoFromSAP(DJ)
        '    ds = eTraceTDCRS.GetOrderInfoFromOracle(DJ)
        '    If ds.Tables("DJInfo").Rows.Count = 0 Then
        '        Dim ErrorRow As DataRow
        '        ErrorRow = DJValidation.Tables("ErrorMsg").NewRow()
        '        ErrorRow("ErrorMsg") = "Invalid DJ"
        '        DJValidation.Tables("ErrorMsg").Rows.Add(ErrorRow)
        '    Else
        '        dt.Columns.Add(New Data.DataColumn("PO", System.Type.GetType("System.String")))
        '        dt.Columns.Add(New Data.DataColumn("PRODUCT_NUMBER", System.Type.GetType("System.String")))
        '        dt.Columns.Add(New Data.DataColumn("PCBA", System.Type.GetType("System.String")))
        '        dt.Columns.Add(New Data.DataColumn("ORDER_QUANTITY", System.Type.GetType("System.String")))
        '        dt.Columns.Add(New Data.DataColumn("OPEN_QUANTITY", System.Type.GetType("System.String")))
        '        dt.Columns.Add(New Data.DataColumn("ProdQty", System.Type.GetType("System.String")))
        '        dt.Columns.Add(New Data.DataColumn("DJ_REVISION", System.Type.GetType("System.String")))
        '        dt.AcceptChanges()
        '        Dim DjInfoRow As DataRow
        '        DjInfoRow = dt.NewRow()
        '        DjInfoRow("PO") = DJ
        '        DjInfoRow("PRODUCT_NUMBER") = ds.Tables("DJInfo").Rows(0)("PRODUCT_NUMBER") 'DjInfo.MatlNo
        '        DjInfoRow("PCBA") = ds.Tables("DJInfo").Rows(0)("PRODUCT_NUMBER") 'DjInfo.MatlNo
        '        DjInfoRow("ORDER_QUANTITY") = ds.Tables("DJInfo").Rows(0)("START_QUANTITY") 'DjInfo.OrderQty
        '        DjInfoRow("OPEN_QUANTITY") = ds.Tables("DJInfo").Rows(0)("OPEN_QUANTITY") 'DjInfo.OpenQty
        '        DjInfoRow("ProdQty") = ds.Tables("DJInfo").Rows(0)("OPEN_QUANTITY") 'DjInfo.OpenQty
        '        DjInfoRow("DJ_REVISION") = ds.Tables("DJInfo").Rows(0)("DJ_REVISION")
        '        dt.Rows.Add(DjInfoRow)
        '        dt.AcceptChanges()
        '        DJValidation.Tables.Add(dt)
        '        DJValidation.AcceptChanges()
        '    End If
        'Catch ex As Exception

        'End Try
        'Return DJValidation
        DJValidation = New DataSet
        AddErrorTable(DJValidation)
        Dim dt As DataTable = New DataTable("DJInfo")
        'Dim DjInfo As eTraceRS.OrderInfo
        Dim ds As DataSet
        Try
            'DJInfo = eTraceTDCRS.GetOrderInfoFromSAP(DJ)
            ds = eTraceRS.GetOrderInfoFromOracle(DJ)
            If ds.Tables("DJInfo").Rows.Count = 0 Then
                Dim ErrorRow As DataRow
                ErrorRow = DJValidation.Tables("ErrorMsg").NewRow()
                ErrorRow("ErrorMsg") = "Invalid DJ"
                DJValidation.Tables("ErrorMsg").Rows.Add(ErrorRow)

                'Dim DjInfoRow As DataRow
                'DjInfoRow = ds.Tables("DJInfo").NewRow()
                'DjInfoRow("PO") = ""
                'DjInfoRow("PRODUCT_NUMBER") = "" 'DjInfo.MatlNo
                'DjInfoRow("PCBA") = "" 'DjInfo.MatlNo
                '' DjInfoRow("OPEN_QUANTITY") = "" 'DjInfo.OpenQty
                ''DjInfoRow("ProdQty") = "" 'DjInfo.OpenQty
                'DjInfoRow("DJ_REVISION") = ""
                'ds.Tables("DJInfo").Rows.Add(DjInfoRow)
                'ds.Tables("DJInfo").AcceptChanges()
                'DJValidation.Tables.Add(ds.Tables("DJInfo").Copy)
                dt.Columns.Add(New Data.DataColumn("PO", System.Type.GetType("System.String")))
                dt.Columns.Add(New Data.DataColumn("PRODUCT_NUMBER", System.Type.GetType("System.String")))
                dt.Columns.Add(New Data.DataColumn("PCBA", System.Type.GetType("System.String")))
                dt.Columns.Add(New Data.DataColumn("ORDER_QUANTITY", System.Type.GetType("System.String")))
                dt.Columns.Add(New Data.DataColumn("OPEN_QUANTITY", System.Type.GetType("System.String")))
                dt.Columns.Add(New Data.DataColumn("ProdQty", System.Type.GetType("System.String")))
                dt.Columns.Add(New Data.DataColumn("DJ_REVISION", System.Type.GetType("System.String")))
                dt.Columns.Add(New Data.DataColumn("DJType", System.Type.GetType("System.String")))
                dt.Columns.Add(New Data.DataColumn("OrgCode", System.Type.GetType("System.String")))
                dt.AcceptChanges()
                Dim DjInfoRow As DataRow
                DjInfoRow = dt.NewRow()
                DjInfoRow("PO") = DJ
                DjInfoRow("PRODUCT_NUMBER") = "" 'DjInfo.MatlNo
                DjInfoRow("PCBA") = "" 'DjInfo.MatlNo
                DjInfoRow("ORDER_QUANTITY") = "0" 'DjInfo.OrderQty
                DjInfoRow("OPEN_QUANTITY") = "0" 'DjInfo.OpenQty
                DjInfoRow("ProdQty") = "0" 'DjInfo.OpenQty
                DjInfoRow("DJ_REVISION") = ""
                DjInfoRow("DJType") = ""
                DjInfoRow("OrgCode") = ""
                dt.Rows.Add(DjInfoRow)
                dt.AcceptChanges()
                DJValidation.Tables.Add(dt)
                DJValidation.AcceptChanges()
            Else
                dt.Columns.Add(New Data.DataColumn("PO", System.Type.GetType("System.String")))
                dt.Columns.Add(New Data.DataColumn("PRODUCT_NUMBER", System.Type.GetType("System.String")))
                dt.Columns.Add(New Data.DataColumn("PCBA", System.Type.GetType("System.String")))
                dt.Columns.Add(New Data.DataColumn("ORDER_QUANTITY", System.Type.GetType("System.String")))
                dt.Columns.Add(New Data.DataColumn("OPEN_QUANTITY", System.Type.GetType("System.String")))
                dt.Columns.Add(New Data.DataColumn("ProdQty", System.Type.GetType("System.String")))
                dt.Columns.Add(New Data.DataColumn("DJ_REVISION", System.Type.GetType("System.String")))
                dt.Columns.Add(New Data.DataColumn("DJType", System.Type.GetType("System.String")))
                dt.Columns.Add(New Data.DataColumn("OrgCode", System.Type.GetType("System.String")))
                dt.AcceptChanges()
                Dim DjInfoRow As DataRow
                DjInfoRow = dt.NewRow()
                DjInfoRow("PO") = DJ
                DjInfoRow("PRODUCT_NUMBER") = ds.Tables("DJInfo").Rows(0)("PRODUCT_NUMBER") 'DjInfo.MatlNo
                DjInfoRow("PCBA") = ds.Tables("DJInfo").Rows(0)("PRODUCT_NUMBER") 'DjInfo.MatlNo
                DjInfoRow("ORDER_QUANTITY") = ds.Tables("DJInfo").Rows(0)("START_QUANTITY") 'DjInfo.OrderQty
                DjInfoRow("OPEN_QUANTITY") = ds.Tables("DJInfo").Rows(0)("OPEN_QUANTITY") 'DjInfo.OpenQty
                DjInfoRow("ProdQty") = ds.Tables("DJInfo").Rows(0)("OPEN_QUANTITY") 'DjInfo.OpenQty
                DjInfoRow("DJ_REVISION") = ds.Tables("DJInfo").Rows(0)("DJ_REVISION")
                DjInfoRow("DJType") = ds.Tables("DJInfo").Rows(0)("DJ_Type")
                DjInfoRow("OrgCode") = ds.Tables("DJInfo").Rows(0)("OrgCode")
                dt.Rows.Add(DjInfoRow)
                dt.AcceptChanges()
                DJValidation.Tables.Add(dt)
                DJValidation.AcceptChanges()
            End If
        Catch ex As Exception
            Return ds
        End Try


    End Function

    Public Function ModelDefined(ByVal ModelNo As String) As String
        Return eTraceRS.ModelDefined(ModelNo)                           '"^TDC-1@ ^TDC-5@"       'product data not defined
    End Function

    Public Function ModelStructure(ByVal ModelNo As String) As DataSet
        Return eTraceRS.ModelStructure(ModelNo)
    End Function

    Public Function GetDJMatchedQty(ByVal DJ As String, ByVal PCBA As String, ByVal OrgCode As String) As Integer
        Return eTraceRS.GetDJMatchedQty(DJ, PCBA, OrgCode)
    End Function


    Public Function InsertPoQty(ByVal OrgCode As String, ByVal DJ As String, ByVal Model As String, ByVal PCBA As String, ByVal Qty As Integer) As Boolean
        Return eTraceRS.InsertPoQty(OrgCode, DJ, Model, PCBA, Qty)
    End Function

    Public Function CountPoQty(ByVal OrgCode As String, ByVal DJ As String, ByVal Model As String, ByVal PCBA As String, ByVal Qty As Integer, ByVal ModelRev As String) As Boolean
        Return eTraceRS.CountPoQty(OrgCode, DJ, Model, PCBA, Qty, ModelRev)
    End Function

    Public Function CountPoQtyII(ByVal OrgCode As String, ByVal DJ As String, ByVal Model As String, ByVal PCBA As String, ByVal Qty As Integer, ByVal ModelRev As String, ByVal DJType As String) As Boolean
        Return eTraceRS.CountPoQtyII(OrgCode, DJ, Model, PCBA, Qty, ModelRev, DJType)
    End Function
    ''' <summary>
    ''' SN Validation 
    ''' </summary>
    ''' <param name="IntSN"></param>
    ''' <returns>0-Success</returns>
    Public Function IntSNIsValid(ByVal IntSN As String) As String
        Try
            Return eTraceRS.IntSNIsValid(IntSN)
        Catch ex As Exception
            If ex.GetType().Name = "WebException" Then
                ''SFC	169
                ''ÍøÂçÇëÇó´íÎó£¬Çë¼ì²éÍøÂç:
                Return "^SFC-169@"
            Else
                Return ex.Message
            End If

        End Try
    End Function

    Public Function PCBARouting(ByVal ModelNo As String, ByVal PCBA As String) As DataSet
        Return eTraceRS.PCBARouting(ModelNo, PCBA)
    End Function

    Public Function WIPMatching1(ByVal DSWIP As DataSet) As String
        Return eTraceRS.WIPMatching1(DSWIP)
    End Function

    Public Function DBoardIsValid(ByVal SubPCBANo As String) As String
        Return eTraceRS.DBoardIsValid(SubPCBANo)
    End Function

    Public Function SFCDBoardIsValid(ByVal SubPCBANo As String) As String
        Return eTraceRS.SFCDBoardIsValid(SubPCBANo)
    End Function

    Public Function getPCBAinWIPHeader(ByVal intSN As String) As String
        Return eTraceRS.getPCBAinWIPHeader(intSN)
    End Function

    Public Function ReadPOQtyByPOAndPCBA(ByVal DJ As String, ByVal PCBA As String) As DataSet
        Return eTraceRS.ReadPOQtyByPOAndPCBA(DJ, PCBA)
    End Function

    Public Function MatchingAccount(ByVal DJ As String, ByVal OrgCode As String, ByVal PCBA As String, ByVal Allow As Integer, ByVal PanelSize As Integer) As Boolean
        Return eTraceRS.MatchingAccount(DJ, OrgCode, PCBA, Allow, PanelSize)
    End Function

    Public Function getTraceLevel(ByVal ModelNo As String) As String
        Return eTraceRS.TraceLevel(ModelNo)
    End Function

    Public Function getPanelSize(ByVal ModelNo As String, ByVal PCBA As String) As Integer
        Return eTraceRS.GetPanelSize(ModelNo, PCBA)
    End Function

    Public Function CheckPanelID(ByVal IntSN As String) As String  'the function must be completed by James Hu.
        Return "0"
    End Function

    Public Function IntSNIsValidByPanel(ByVal IntSN As String) As String
        Return eTraceRS.IntSNIsValidByPanel(IntSN)
    End Function

    Public Function WIPMatchingByPanel(ByVal DSWIP As DataSet, ByVal PanelSize As Integer) As String
        Return eTraceRS.WIPMatchingByPanel(DSWIP, PanelSize)
    End Function

    Public Function CheckCompIssueToDJ(ByVal DJ As String) As String
        Return eTraceRS.CheckCompIssueToDJ(DJ)
    End Function

    Public Function IntSNPattern(ByVal Model As String) As String
        Return eTraceRS.IntSNPattern(Model)
    End Function

    Public Function StructureReadByPCBA(ByVal Model As String, ByVal PCBA As String, ByVal mode As Integer) As DataSet
        Return eTraceRS.StructureReadByPCBA(Model, PCBA, mode)
    End Function

    Public Function MaterialInfoReadByCLID(ByVal CLID As String) As DataSet
        Return eTrace121.MaterialInfoReadByCLID(CLID)
    End Function

    Public Function ModelConfiguratorSNValid(ByVal SN As String) As String
        Return eTraceRS.ModelConfiguratorSNValid(SN)
    End Function
    Public Function PanelIDIsValid(ByVal PanelID As String) As String  'the function must be completed by James Hu.
        Return eTrace121.PanelIDIsValid(PanelID)
        Try
            Return eTrace121.PanelIDIsValid(PanelID)
        Catch ex As Exception
            If ex.GetType().Name = "WebException" Then
                ''SFC	169
                ''ÍøÂçÇëÇó´íÎó£¬Çë¼ì²éÍøÂç:
                Return "^SFC-169@"
            Else
                Return ex.Message
            End If

        End Try
    End Function
End Class
