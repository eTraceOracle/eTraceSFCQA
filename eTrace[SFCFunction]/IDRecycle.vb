Partial Class Functions
    Public Function IntSNRecycle(ByVal head As eTraceSFCService.StatusHeaderStructure) As Boolean
        IntSNRecycle = False

        If (Not GetDataByIntSN(head.IntSerial).Tables(0).Rows(0)("MotherBoardSN") = "") Then
            Return IntSNRecycle
        End If
        Try
            IntSNRecycle = eTraceRS.IntSNRecycle(head)
        Catch ex As Exception
            eTraceRS.ErrorLogging("SFC-IDRecycle", "", "from: " & head.IntSerial & " to: " & head.ExtSerial & ", " & ex.Message)
        End Try
    End Function
    Public Function IntSNRecycleII(ByVal head As eTraceSFCService.StatusHeaderStructure) As String

        Try
            IntSNRecycleII = eTraceRS.IntSNRecycleII(head)
        Catch ex As Exception
            eTraceRS.ErrorLogging("SFC-IDRecycleII", "", "from: " & head.IntSerial & " to: " & head.ExtSerial & ", " & ex.Message)
        End Try
    End Function
End Class
