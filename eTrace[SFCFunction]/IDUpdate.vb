Partial Class Functions

    Public Function IDUpdate(ByVal IntSN As String, ByVal DJ As String, ByVal Model As String, ByVal TVANo As String, ByVal OrgCode As String, ByVal user As String) As String
        Try
            Return eTraceRS.IDUpdate(IntSN, DJ, Model, TVANo, OrgCode, user)
        Catch ex As Exception
            eTraceRS.ErrorLogging("SFC-IDUpdate", "", DJ & ", " & Model & ", " & ex.Message)
            Return "^TDC-29@"
        End Try
    End Function

End Class
