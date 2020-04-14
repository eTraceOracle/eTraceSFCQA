Partial Class Functions

    Public Function WIPRework(ByVal IntSN As String, ByVal LoginData As eTraceSFCService.ERPLogin, ByVal dsFlow As DataSet) As String

        Try
            Return eTraceRS.WIPRework(IntSN, LoginData, dsFlow)
        Catch ex As Exception
            eTraceRS.ErrorLogging("SFC-WIPRework", "", IntSN & ", " & ex.Message)
            Return "ERROR:" + "^TDC-61@"
        End Try
    End Function
End Class
