Partial Class Functions
    ''' <summary>
    ''' Check if Fixture is already in use,true for in use
    ''' </summary>
    ''' <param name="FixtureID">FixtureID for checking</param>
    ''' <returns></returns>
    Public Function IsFixtureInUse(ByVal FixtureID As String) As Boolean
        Return eTraceRS.CheckFixutureID(FixtureID) = "True"
    End Function
    ''' <summary>
    ''' Check FixtueID,if check sucessed return 'PASS'
    ''' </summary>
    ''' <param name="FixtueID">FixtureID for checking</param>
    ''' <returns></returns>
    Public Function CheckFixtureID(ByVal FixtueID As String) As String
        Return eTraceRS.CheckFixutureID(FixtueID)
    End Function

    ''' <summary>
    ''' Query PanelID By IntSn
    ''' </summary>
    ''' <param name="IntSN"></param>
    ''' <returns></returns>
    Public Function GetPanelIDByIntSN(ByVal IntSN) As String
        ''to do
        Return eTraceRS.GetPanelIDByIntSN(IntSN)
    End Function

    ''' <summary>
    ''' clear fixtureID async
    ''' </summary>
    Public Sub ClearFixtureID(ByVal FixtureID As String)
        eTraceRS.ClearFixtureIDAsync(FixtureID)
    End Sub
    ''' <summary>
    '''  record fixturemount data
    ''' </summary>
    ''' <param name="dataset"></param>
    ''' <returns></returns>
    Public Function FixtureMount(ByVal dataset As DataSet, ByVal FixtureID As String, ByVal user As String) As String
        Return eTraceRS.FixtureMount(dataset, FixtureID, user)
    End Function
    Public Function GetWipHeaderByIntSN(ByVal IntSN As String) As DataSet
        Return eTraceRS.GetWipHeaderByIntSN(IntSN)
    End Function
End Class
