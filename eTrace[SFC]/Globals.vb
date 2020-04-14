Module Globals
    'instance Bussiness Logic Layer
    Public BLL As New eTrace_SFCFunction_.Functions
    Public ProcessShow As String   'process name and so on show on comboBox's text
    Public SelectProcessID As Integer
    Public SelectProcess As String
    Public eTraceRS As eTraceSMTService.eTraceSMTService = New eTraceSMTService.eTraceSMTService
    Public SAPLoginData1 As eTraceSMTService.SAPLogin = New eTraceSMTService.SAPLogin
    Public MIFileName As String
    Public dsConfig As DataSet
    ''' <summary>
    ''' Get a link  link to WipStatusOneView
    ''' </summary>
    ''' <param name="intSN">int Sn</param>
    ''' <returns></returns>
    Public Function GetReportLink(intSN As String) As String
        ''http://cnapgzhoetqa01/webapp/index.html#/sfc/WipStatusOneView?IntSN=b01212
        Dim server As String = My.Settings.LoginServer
        Return String.Format("http://{0}/webapp/index.html#/sfc/WipStatusOneView?IntSN={1}",
                             server,
                             intSN)
    End Function
    Public Class Config
        ''' <summary>
        ''' AllowMunualInput from t_config  "ConfigID='SFC004'
        ''' </summary>
        ''' <returns></returns>
        Public Shared ReadOnly Property AllowMunualInput As Boolean
            Get
                Return IIf(BLL.FixNull(dsConfig.Tables(0).Select("ConfigID='SFC004'")(0)("Value")), True, False)
            End Get
        End Property
        ''' <summary>
        ''' Minimal length of Int Serial No t_config  "ConfigID='SFC009'
        ''' </summary>
        ''' <returns></returns>
        Public Shared ReadOnly Property MinimalIntSNLength As Integer
            Get
                Return Convert.ToInt32(vbNullString & dsConfig.Tables(0).Select("ConfigID='SFC009'")(0)("Value"))
            End Get
        End Property
    End Class

End Module
