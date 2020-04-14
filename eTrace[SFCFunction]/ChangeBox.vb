Partial Class Functions

    Public Function GetShipInfoBySN(ByVal SerialNo As String) As eTraceSFCService.ShipInfo
        Return eTraceRS.GetShipInfoBySN(SerialNo)

    End Function

    Public Function ChangeBox(ByVal SerialNo As String, ByVal oldboxid As String, ByVal newBoxID As String, ByVal user As String) As String
        Return eTraceRS.ChangeBox(SerialNo, oldboxid, newBoxID, user)
    End Function

    Public Function GetShipInfoByBoxID(ByVal BoxID As String, ByVal user As String) As eTraceSFCService.ShipInfo
        Return eTraceRS.GetShipInfoByBoxID(BoxID, user)
    End Function

    Public Function GetShipInfoByBoxIDSN(ByVal BoxIDSN As String) As DataSet
        Return eTraceRS.GetShipInfoByBoxIDSN(BoxIDSN)
    End Function

    Public Function GetCartonInfo(ByVal BoxID As String) As DataSet
        Return eTraceRS.getCartonInfo(BoxID)
    End Function

    Public Function SNListChangeBox(ByVal SNList As DataSet) As String
        Return eTraceRS.SNListChangeBox(SNList)
    End Function
End Class
