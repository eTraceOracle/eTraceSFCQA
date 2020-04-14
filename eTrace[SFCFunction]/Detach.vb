
Imports eTrace_SFCFunction_.DataModel.WIP
''' <summary>
''' 
''' </summary>
Public Class Detach
    Public Shared Function DetachMotherBoradValid(ByVal motherbordSN) As DetachMotherBoradValidResponse
        Dim response As DetachMotherBoradValidResponse
        Dim ds As DataSet = eTraceRS.DetachMotherBoardValid(motherbordSN)
        response = New DetachMotherBoradValidResponse(ds)
        Return response
    End Function
    Public Shared Function Detach(ByVal motherBoardSN As String, ByVal daugtherBoardSN As String, ByVal user As String) As DetachResponse
        Dim response As DetachResponse
        Dim ds As DataSet = eTraceRS.Detach(motherBoardSN, daugtherBoardSN, user)
        response = New DetachResponse(ds)
        Return response
    End Function
End Class



Public Class DetachMotherBoradValidResponse
    Inherits DataModel.Base.ResponseBase
    Public Sub New(dataset As DataSet)
        MyBase.New(dataset)
        If dataset.Tables.Count > 2 Then
            Me.PCBA = dataset.Tables(1).Rows(0)("pcba")
            Me.Model = dataset.Tables(1).Rows(0)("model")
            Me.DJ = dataset.Tables(1).Rows(0)("dj")
            Dim SubPCBATable As DataTable = dataset.Tables(2)
            SubPCBAList = New List(Of WIPHeaeder)
            For i As Integer = 0 To SubPCBATable.Rows.Count - 1
                Dim wipHeader As New WIPHeaeder()
                wipHeader.IntSN = SubPCBATable.Rows(0)("IntSN")
                wipHeader.Model = SubPCBATable.Rows(0)("Model")
                wipHeader.MotherBoradSN = SubPCBATable.Rows(0)("MotherBoradSN")
                wipHeader.WipID = SubPCBATable.Rows(0)("WipID")
                wipHeader.PCBA = SubPCBATable.Rows(0)("PCBA")
                SubPCBAList.Add(New WIPHeaeder())
            Next
        End If
    End Sub
    Public PCBA As String
    Public Model As String
    Public DJ As String
    Public SubPCBAList As List(Of WIPHeaeder)
End Class



Public Class DetachResponse
    Inherits DataModel.Base.ResponseBase
    Public Sub New(dataset As DataSet)
        MyBase.New(dataset)
    End Sub
End Class