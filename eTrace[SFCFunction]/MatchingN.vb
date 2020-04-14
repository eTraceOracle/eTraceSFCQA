Partial Class Functions

    Public Function MatchingUpdate(ByVal header As eTraceSFCService.StatusHeaderStructure, ByVal dsDBoards As DataSet) As DataSet
        Dim tmpRow As DataRow
        Dim DRsubPCBA() As DataRow
        Dim SubPCBANo As String
        Dim DBoardsIsValid As String
        Dim MatchingDone As Boolean

        Try
            If dsDBoards.Tables.Count = 0 Then
                dsDBoards = eTraceRS.ReadDBoards(header)
                AddReturnValue(dsDBoards)
                Dim dr As DataRow = dsDBoards.Tables("dtReturnValue").NewRow()
                dr("value") = ""
                dsDBoards.Tables("dtReturnValue").Rows.Add(dr)
                dsDBoards.AcceptChanges()
            End If

            If dsDBoards.Tables.Count = 1 OrElse dsDBoards.Tables(0).Rows(0)(0).ToString = "ERROR" Then
                dsDBoards.Tables("dtReturnValue").Rows(0)("value") = "ERROR"
                Return dsDBoards
            End If
            DRsubPCBA = dsDBoards.Tables(0).Select("PropertyValue = '" & header.Result & "'")
            If DRsubPCBA.Length <> 0 Then  'the subPCBA exists in pcba list.
                eTraceRS.ErrorLogging("SFC-MatchingUpdate", header.OperatorName, "the subPCBA exists in pcba list " & header.Result) '1.0.0.9
                dsDBoards.Tables("dtReturnValue").Rows(0)("value") = "ERROR"
                Return dsDBoards
            End If
            SubPCBANo = getPCBAinWIPHeader(header.Result)
            If SubPCBANo = "^TDC-5@" Then  'does not exist.
                eTraceRS.ErrorLogging("SFC-MatchingUpdate", header.OperatorName, " ^TDC-5@" & header.Result)
                dsDBoards.Tables("dtReturnValue").Rows(0)("value") = "ERROR"
                Return dsDBoards
            End If
            DRsubPCBA = dsDBoards.Tables(0).Select("PropertyName ='" & SubPCBANo & "'")
            If DRsubPCBA.Length = 0 Then  '^TDC-9@    'does not defined in the PCBA!     Sub PCBA not in the list
                eTraceRS.ErrorLogging("SFC-MatchingUpdate", header.OperatorName, " ^TDC-9@" & header.Result)
                dsDBoards.Tables("dtReturnValue").Rows(0)("value") = "ERROR"
                Return dsDBoards
            End If
            'DBoardsIsValid = DBoardIsValid(header.Result)       'upgrade when domain change
            DBoardsIsValid = SFCDBoardIsValid(header.Result)
            'If DBoardsIsValid <> "0" Then
            If Microsoft.VisualBasic.Left(DBoardsIsValid, 5).ToUpper <> "WIPID" Then
                '^TDC-13@'  Failed process found!      
                '^TDC-157@' has been binded to another PCBA  
                eTraceRS.ErrorLogging("SFC-MatchingUpdate", header.OperatorName, DBoardsIsValid & header.Result)
                dsDBoards.Tables("dtReturnValue").Rows(0)("value") = "ERROR"
                Return dsDBoards
            End If
            If dsDBoards.Tables(0).Select("PropertyName='" & SubPCBANo & "' and (PropertyValue = '' or PropertyValue is null ) ").Length = 0 Then
                eTraceRS.ErrorLogging("SFC-MatchingUpdate", header.OperatorName, "'^SFC-1@'" & header.Result)
                dsDBoards.Tables("dtReturnValue").Rows(0)("value") = "ERROR"
                Return dsDBoards
            End If
            For Each tmpRow In dsDBoards.Tables(0).Rows
                If tmpRow("PropertyName") = SubPCBANo Then
                    If FixNull(tmpRow("PropertyValue").ToString) = "" Then    ' only fill up blank 'sub pcba' column
                        tmpRow("PropertyValue") = header.Result
                        Exit For
                    End If
                End If
            Next
            dsDBoards.Tables(0).AcceptChanges()
            If dsDBoards.Tables(0).Select("PropertyValue = '' or PropertyValue is null ").Length = 0 Then
                MatchingDone = True
            Else
                MatchingDone = False
            End If

            'Now, update the T_WIP*.

            If MatchingDone = True Then
                header.Result = "PASS"
                If Microsoft.VisualBasic.Left(eTraceRS.WIPOutMatchingN(header, dsDBoards), 5) = "ERROR" Then
                    eTraceRS.ErrorLogging("TDC-MatchingUpdate", header.OperatorName, "Failed updating result file: " & header.IntSerial) '1.0.0.9
                    dsDBoards.Tables("dtReturnValue").Rows(0)("value") = "ERROR"
                    Return dsDBoards
                Else
                    dsDBoards.Tables("dtReturnValue").Rows(0)("value") = "DONE"
                    Return dsDBoards
                End If
            Else
                dsDBoards.Tables("dtReturnValue").Rows(0)("value") = "NEXTID"
                Return dsDBoards
            End If
        Catch ex As Exception
            eTraceRS.ErrorLogging("TDC-MatchingUpdate", header.OperatorName, header.IntSerial & ", " & header.Result & ", " & ex.Message) '1.0.0.9
            dsDBoards.Tables("dtReturnValue").Rows(0)("value") = "ERROR"
            Return dsDBoards
        End Try
    End Function

    Public Sub AddReturnValue(ByVal DS As DataSet)
        Dim ReturnValue As DataTable
        Dim myDataColumn As DataColumn
        ReturnValue = New Data.DataTable("dtReturnValue")
        myDataColumn = New Data.DataColumn("value", System.Type.GetType("System.String"))
        ReturnValue.Columns.Add(myDataColumn)
        DS.Tables.Add(ReturnValue)
    End Sub

    Public Function GetResultAndPCBAList(ByVal IntSN As String, ByVal proc As String) As DataSet
        Return eTraceRS.GetResultAndPCBAList(IntSN, proc)
    End Function

    Public Function WIPMatchingN(ByVal DSWIP As DataSet) As String
        Return eTraceRS.WIPMatchingN(DSWIP)
    End Function

    '    Public Function DetachMotherBoradValid(ByVal motherbordSN) As DetachMotherBoradValidResponse
    '        Dim response As DetachMotherBoradValidResponse
    '        Dim ds As DataSet = eTraceRS.DetachMotherBoardValid(motherbordSN)
    '        response = New DetachMotherBoradValidResponse(ds)
    '        Return response
    '    End Function

    '    Public Function Detach(ByVal motherBoardSN As String, ByVal daugtherBoardSN As String, ByVal user As String) As DetachResponse
    '        Dim response As DetachResponse
    '        Dim ds As DataSet = eTraceRS.Detach(motherBoardSN, daugtherBoardSN, user)
    '        response = New DetachResponse(ds)
    '        Return response
    '    End Function
End Class


'Public Class DetachMotherBoradValidResponse
'    Inherits ResponseBase
'    Public Sub New(dataset As DataSet)
'        MyBase.New(dataset)
'        If dataset.Tables.Count > 1 Then
'            Me.PCBA = dataset.Tables(2).Rows(0)("pcba")
'            Me.Model = dataset.Tables(2).Rows(0)("model")
'            Me.DJ = dataset.Tables(2).Rows(0)("dj")
'        End If
'    End Sub
'    Public PCBA As String
'    Public Model As String
'    Public DJ As String
'End Class

'Public Class DetachResponse
'    Inherits ResponseBase
'    Public Sub New(dataset As DataSet)
'        MyBase.New(dataset)
'    End Sub
'End Class