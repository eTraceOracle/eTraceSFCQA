Partial Class Functions

    Public LoginData As eTraceSFCService.ERPLogin = New eTraceSFCService.ERPLogin
    Public UserData As eTraceSFCService.UserData = New eTraceSFCService.UserData
    Public AccessCardInfo As eTraceSFCService.AccessCard = New eTraceSFCService.AccessCard
    'Public eTraceRS As eTraceSFCService.eTraceOracleERP = New eTraceSFCService.eTraceOracleERP
    'Public eTraceTDCRS As eTraceTDCService.eTraceTDCService = New eTraceTDCService.eTraceTDCService
    Public StatusHeader As eTraceSFCService.StatusHeaderStructure = New eTraceSFCService.StatusHeaderStructure
    Public ShipInfo As eTraceSFCService.ShipInfo = New eTraceSFCService.ShipInfo
    'Public WIPHeader As eTraceSFCService.WIPHeader = New eTraceSFCService.WIPHeader

    Public Structure TDSelectionStructure
        Public SerialNo As String
        Public frProdDate As Date
        Public toProdDate As Date
        Public Process As String
    End Structure

    Public Structure ProductData
        Public Model As String
        Public Desc As String
        Public BU As String
        Public Customer As String
        Public CPN As String
        Public ExtSerialPattern As String
        Public SN2pattern As String
        Public SN3pattern As String
        Public SN4pattern As String
        Public MainBoard As String
        Public SpecialReq As String
        Public Boxsize As Integer
        Public Palletsize As Integer
        Public Revision As String
        Public ExtSNSameIntSN As Boolean
        Public ConfirmSN As Boolean
    End Structure

    Public Structure RuleDetail
        Public Model As String
        Public Desc As String
        Public BU As String
        Public Customer As String
        Public CPN As String
        Public SNpattern As String
        Public SN2pattern As String
        Public SN3pattern As String
        Public SN4pattern As String
        Public VoltageType As String
        Public Power As String
        Public Mainboard As String
        Public SpecialRequirement As String
        Public Boxsize As Integer
        Public Palletsize As Integer
        Public Revision As String
        Public Remarks As String
        Public ExtSNSameIntSN As Boolean
        Public ConfirmSN As Boolean
    End Structure



    Public Structure DJInfo
        Public DJNo As Integer
        Public Model As String
        Public OpenQty As String
    End Structure


End Class
