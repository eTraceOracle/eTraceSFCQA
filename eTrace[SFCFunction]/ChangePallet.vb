Partial Class Functions

    Public Function ChangePallet(ByVal BoxID As String, ByVal PalletID As String, ByVal user As String) As String
        Return eTraceRS.ChangePallet(BoxID, PalletID, user)
    End Function

    Public Function GetShipInfoByPalletID(ByVal PalletID As String, ByVal user As String) As eTraceSFCService.ShipInfo
        Return eTraceRS.GetShipInfoByPalletID(PalletID, user)

    End Function
End Class
