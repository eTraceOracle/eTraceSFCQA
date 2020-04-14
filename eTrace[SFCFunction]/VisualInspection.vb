Partial Class Functions

    Public Function WIPVisualInspection(ByVal DSWIP As DataSet) As String
        Return eTraceRS.WIPVisualInspection(DSWIP)
    End Function

    Public Function ReadRepairCode() As DataSet
        Return eTraceRS.ReadRepairCode()
    End Function

    Public Function PCBListReadByPanelID(ByVal PanelID As String) As DataSet
        Return eTrace121.PCBListReadByPanelID(PanelID)
    End Function
End Class
