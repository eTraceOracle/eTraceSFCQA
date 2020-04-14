Partial Class Functions

    Public Function IsWipIn(ByVal IntSerial As String, ByVal CurrProcess As String) As Boolean
        Return eTraceRS.IsWipIn(IntSerial, CurrProcess)
    End Function

    Public Function BurnInWipOut(ByVal Header As eTraceSFCService.StatusHeaderStructure, ByVal checked As Boolean) As Boolean
        Return eTraceRS.BurnInWipOut(Header, checked)
    End Function

    Public Function GetBurnInTime(ByVal IntSerial As String, ByVal CurrProcess As String) As Integer
        Return eTraceRS.GetBurnInTime(IntSerial, CurrProcess)
    End Function

    Public Function WIPBurnIn(ByVal DSWIP As DataSet) As String
        Return eTraceRS.WIPBurnIn(DSWIP)
    End Function

    Public Function WIPIn(ByVal IntSerialNo As String, ByVal Process As String, ByVal OperatorName As String) As Boolean
        Return eTraceRS.WIPIn(IntSerialNo, Process, OperatorName)
    End Function
End Class
