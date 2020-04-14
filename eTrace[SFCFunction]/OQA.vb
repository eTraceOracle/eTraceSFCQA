Partial Class Functions

    Public Function ExistsFunctionalTest(ByVal ExtSN As String) As String

        Try
            Return eTraceRS.ExistsFunctionalTest(ExtSN)
        Catch ex As Exception
            eTraceRS.ErrorLogging("SFC-ExistsFunctionalTest", "", ExtSN & ", " & ex.Message)
            Return "ERROR:" + "^TDC-40@"
        End Try
    End Function

    Public Function TLAFlow(ByVal Model As String) As DataSet

        Try
            Return eTraceRS.TLAFlow(Model)
        Catch ex As Exception
            eTraceRS.ErrorLogging("SFC-TLAFlow", "", Model & ", " & ex.Message)
            Return New DataSet
        End Try
    End Function


    Public Function OQACosmetic(ByVal ExtSN As String, ByVal Model As String, ByVal RetestNo As String, ByVal Result As String, ByVal LoginData As eTraceSFCService.ERPLogin, ByVal dsFlow As DataSet) As String

        Try
            Return eTraceRS.OQACosmetic(ExtSN, Model, RetestNo, Result, LoginData, dsFlow)
        Catch ex As Exception
            eTraceRS.ErrorLogging("SFC-OQACosmetic", "", ExtSN & ", " & ex.Message)
            Return "ERROR:" + "^TDC-61@"
        End Try
    End Function
End Class
