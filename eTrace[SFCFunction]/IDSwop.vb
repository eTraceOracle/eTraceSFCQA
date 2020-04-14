Partial Class Functions

    Public Function IDSwop(ByVal head As eTraceSFCService.StatusHeaderStructure, ByVal updateType As Boolean) As String
        Dim type As Integer = -1
        'Dim returnString = ""

        Try
            Dim returnValue As String
            returnValue = eTraceRS.CheckPrevResult(head.IntSerial, head.Process)
            If (returnValue.ToUpper = "PASS") Then
                returnValue = LargeThanMaxTest(head.IntSerial, head.Process)
                If (returnValue.ToUpper = "PASS") Then
                    type = 0
                End If
            End If

            If (type <> 0 And updateType) Then
                If (GetDataByIntSN(head.IntSerial).Tables(0).Rows(0)("MotherBoardSN") = "") Then
                    type = 1
                Else
                    returnValue = "^SFC-6@"
                End If

            End If

            If (type <> -1) Then
                eTraceRS.IDSwop(head, type)
                Return "^TDC-38@"
            Else
                Return "ERROR:" + returnValue
            End If
        Catch ex As Exception
            eTraceRS.ErrorLogging("SFC-IDSwop", "", "from: " & head.IntSerial & " to: " & head.ExtSerial & ", " & ex.Message)
            Return "ERROR:" + "^TDC-39@"
        End Try
    End Function

    Public Function WIPIDSwop(ByVal DSWIP As DataSet) As String
        Return eTraceRS.WIPIDSwop(DSWIP)
    End Function
    Public Function PanelIDSwop(ByVal head As eTraceSFCService.StatusHeaderStructure) As String
        Try

            Return eTrace121.PanelIDSwop(head.IntSerial, head.ExtSerial, head.OperatorName)
        Catch ex As Exception
            eTraceRS.ErrorLogging("SFC-PanelIDSwop", "", "from: " & head.IntSerial & " to: " & head.ExtSerial & ", " & ex.Message)
            Return "ERROR:" + "^TDC-39@"
        End Try

    End Function

    Public Function TrayIDSwop(ByVal OTrayID As String, ByVal CTrayID As String, ByVal User As String) As String
        Try

            Return eTrace121.TrayIDSwop(OTrayID, CTrayID, User)
        Catch ex As Exception
            eTraceRS.ErrorLogging("SFC-TrayIDSwop", "", "from: " & OTrayID & " to: " & CTrayID & ", " & ex.Message)
            Return "ERROR:" + "^TDC-39@"
        End Try

    End Function
End Class
