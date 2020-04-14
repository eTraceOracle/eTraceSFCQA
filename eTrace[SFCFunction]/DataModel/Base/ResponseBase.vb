Namespace DataModel.Base
    ''' <summary>
    ''' 
    ''' </summary>
    Public Class ResponseBase
        Public Sub New(dataset As DataSet)
            If dataset IsNot Nothing Then
                If dataset.Tables.Count > 0 Then
                    Dim datatable As DataTable
                    datatable = dataset.Tables(0)
                    If datatable.Rows.Count > 0 Then
                        ''columns name use camel
                        Success = datatable.Rows(0)("success")
                        ErrorMessage = datatable.Rows(0)("errorMessage")
                    End If
                End If
            End If
        End Sub
        ''' <summary>
        ''' comunicate success
        ''' </summary>
        Public Success As Boolean = False
        Public ErrorMessage As String = ""
    End Class

End Namespace

