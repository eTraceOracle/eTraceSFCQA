Partial Class Functions

    Public Function MatListOnPCBA(ByVal WIPID As String) As DataSet
        Try
            Return eTraceRS.MatListOnPCBA(WIPID)
        Catch ex As Exception
            eTraceRS.ErrorLogging("SFC-MatListOnPCBA", "", ex.Message)
            Return New DataSet
        End Try
    End Function

    Public Function ComponentReplacement(ByVal ds As DataSet) As String
        Try
            Return eTraceRS.ComponentReplacement(ds)
        Catch ex As Exception
            eTraceRS.ErrorLogging("SFC-ComponentReplacement", "", ex.Message)
            Return "^UMG-11@"
        End Try
    End Function

    Public Function IsReworkUnit(ByVal WIPID As String) As String
        Try
            Return eTraceRS.IsReworkUnit(WIPID)
        Catch ex As Exception
            eTraceRS.ErrorLogging("SFC-IsReworkUnit", "", ex.Message)
            Return "N"
        End Try
    End Function

    Public Function IsBottomPCBA(ByVal Model As String, ByVal PCBA As String) As String
        Try
            Return eTraceRS.IsBottomPCBA(Model, PCBA)
        Catch ex As Exception
            eTraceRS.ErrorLogging("SFC-IsButtomPCBA", "", ex.Message)
            Return "N"
        End Try
    End Function

    Public Function PCBListOfRework(ByVal WIPID As String) As DataSet
        Try
            Return eTraceRS.PCBListOfRework(WIPID)
        Catch ex As Exception
            eTraceRS.ErrorLogging("SFC-IsButtomPCBA", "", ex.Message)
            Return New DataSet
        End Try
    End Function
End Class
