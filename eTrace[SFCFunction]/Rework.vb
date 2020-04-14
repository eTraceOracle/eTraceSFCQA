Partial Class Functions

    Public Function Rework(ByVal ExtSN As String, ByVal DJ As String, ByVal Model As String, ByVal RetestNo As String, ByVal check As Boolean, ByVal LoginData As eTraceSFCService.ERPLogin, ByVal dsFlow As DataSet) As String

        Try
            Return eTraceRS.Rework(ExtSN, DJ, Model, RetestNo, check, LoginData, dsFlow)
        Catch ex As Exception
            eTraceRS.ErrorLogging("SFC-OQACosmetic", "", ExtSN & ", " & ex.Message)
            Return "ERROR:" + "^TDC-61@"
        End Try
    End Function

    Public Function Rework_New(ByVal dsFlow As DataSet) As String

        Try
            Return eTraceRS.Rework_New(dsFlow)
        Catch ex As Exception
            eTraceRS.ErrorLogging("SFC-Rework_New", "", ex.Message)
            Return "ERROR:" + "^TDC-61@"
        End Try
    End Function

    Public Function GetProductCPNbyModel(ByVal Model As String) As DataSet

        Try
            Return eTraceRS.GetProductCPNbyModel(Model)
        Catch ex As Exception
            eTraceRS.ErrorLogging("SFC-GetProductCPNbyModel", "", ex.Message)
            Return New DataSet
        End Try
    End Function
End Class
