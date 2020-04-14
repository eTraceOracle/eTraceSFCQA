Partial Class Functions

    Public Function ATEWIPout(ByVal dsxml As String) As String
        Try
            eTraceRS.ATEWIPout(dsxml)
        Catch ex As Exception
            eTraceRS.ErrorLogging("TDC-ReadXMLByProperty", "", ex.Message) '1.0.0.9
        End Try
        Return ""
    End Function

    ''' <summary>
    ''' 获取当前系统所有锁
    ''' </summary>
    ''' <returns></returns>
    Public Function ATEGetAllLocks() As DataSet
        Try
            Return eTraceRS.GetLocks()
        Catch ex As Exception
            eTraceRS.ErrorLogging("SFC-ATEGetAllLocks", "", ex.Message) '1.0.0.9
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' 
    ''' </summary> 
    ''' <returns>if sucess return 'true'</returns>
    Public Function UpdateLockByID(loadateLockInfo As LockInfo) As LockInfo
        Dim res As New updateLockInfoResponse()
        With loadateLockInfo
            res.lockId = .lockId
            res.symptom = .symptom
            res.te = .te
            res.pe = .pe
            res.pqe = .pqe
            res.other = .other
            res.pbr = .pbr
            res.remarks = .remarks
        End With
        Try
            With loadateLockInfo
                res.ReponseInfo = eTraceRS.UpdateLockByID(.lockId, .symptom, .te, .pe, .pqe, .other, .pbr, .remarks)
            End With

        Catch ex As Exception
            eTraceRS.ErrorLogging("SFC-UpdateLocks", "", ex.Message) '1.0.0.9
            res.ReponseInfo = ex.Message
        End Try

        Return res
    End Function
    ''' <summary>
    ''' 保存同时解锁
    ''' </summary>
    ''' <param name="upateLockInfo"></param>
    ''' <returns>返回'True'</returns>
    Public Function UpdateAndUnLockByID(upateLockInfo As UpdateAndUnclockRequset) As String
        Dim res As String

        Dim GetResult As String
        Try
            With upateLockInfo
                GetResult = eTraceRS.GetResult(.CardNo, "")
                If GetResult = "Unlock" Then
                    res = eTraceRS.SaveAndUnlockdByID(.lockId, .symptom, .te, .pe, .pqe, .other, .pbr, .remarks, .User)
                Else
                    res = "^SFC-156@"
                End If
            End With

        Catch ex As Exception
            eTraceRS.ErrorLogging("SFC-UpdateLocks", "", ex.Message) '1.0.0.9
            res = ex.Message
        End Try

        Return res
    End Function

    Public Class LockInfo
        Public lockId As String
        Public symptom As String
        Public te As String
        Public pe As String
        Public pqe As String
        Public other As String
        Public pbr As String
        Public remarks As String
    End Class
    Public Class updateLockInfoResponse
        Inherits LockInfo
        Public ReponseInfo As String
    End Class

    Public Class UpdateAndUnclockRequset
        Inherits LockInfo
        Public User As String
        Public CardNo As String
    End Class
End Class
