Imports System.Text.RegularExpressions
Partial Class Functions

    Public Function GetProductCPN(ByVal CPN As String) As DataTable
        Return eTraceRS.GetProductCPN(CPN).Tables(0)
    End Function

    Public Function GetResultList(ByVal IntSN As String) As DataTable
        Return eTraceRS.GetResultList(IntSN).Tables(0)
    End Function

    Public Function GetResultAndAttributesList(ByVal IntSN As String) As DataSet
        Return eTraceRS.GetResultAndAttributesList(IntSN)
    End Function

    Public Function GetBoxInfo(ByVal BoxID As String) As DataTable
        Return eTraceRS.GetBoxInfo(BoxID).Tables(0)
    End Function

    Public Function GetPackingListLabel(ByVal Model As String) As String
        Return eTraceRS.GetPackingListLabel(Model)
    End Function

    Public Function GetBoxQtyInPallet(ByVal PalletID As String) As Integer
        Return eTraceRS.GetBoxQtyInPallet(PalletID)
    End Function

    Public Function WIPPaking(ByVal ds As DataSet) As String
        Return eTraceRS.WIPPacking(ds)
    End Function

    Public Function PrintPaking(ByVal CartonID As String, ByVal LabelID As String, ByVal printer As String) As String
        Return eTraceRS.PrintPaking(CartonID, LabelID, printer)
    End Function

    Public Function GetLabels(ByVal Model As String, ByVal PCBA As String, ByVal Process As String) As DataSet
        Return eTraceRS.getLabels(Model, PCBA, Process)
    End Function

    Public Function AlphanumericValidation(ByVal strInput As String, ByVal strPattern As String) As Boolean
        If Len(strInput) <> Len(strPattern) Then
            Return False
        End If
        If Len(strInput) > 0 Then
            strInput = strInput.Trim.ToUpper
            Dim strRange As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            Dim i As Integer
            If strPattern = "" Then
                For i = 1 To Len(strInput)
                    If InStr(strRange, Mid(strInput, i, 1)) = 0 Then        'not in the range
                        Return False
                    End If
                Next
            Else
                Dim posInterrogation() As Integer
                Dim posString() As Integer
                posInterrogation = GetInterrogationPosOnPattern(strPattern)
                posString = GetStringPosOnPattern(strPattern)
                If Not posInterrogation Is Nothing Then
                    For i = 0 To UBound(posInterrogation)
                        If InStr(strRange, Mid(strInput, posInterrogation(i), 1)) = 0 Then        'not in the range
                            Return False
                        End If
                    Next
                End If

                If Not posString Is Nothing Then
                    Dim j As Integer
                    For j = 0 To UBound(posString)
                        If InStr(Mid(strInput, posString(j), 1), Mid(strPattern, posString(j), 1)) = 0 Then
                            Return False
                        End If
                    Next
                End If
            End If
        End If
        Return True
    End Function

    Public Function GetInterrogationPosOnPattern(ByVal strPattern As String) As Integer()
        Dim pos() As Integer = {}
        Dim i, j As Integer
        j = 0
        For i = 1 To Len(strPattern)
            If InStr("?", Mid(strPattern, i, 1)) <> 0 Then        ' is "?"
                ReDim Preserve pos(j)
                pos(j) = i
                j = j + 1
            End If
        Next
        Return pos
    End Function

    Public Function GetStringPosOnPattern(ByVal strPattern As String) As Integer()
        Dim pos() As Integer = {}
        Dim i, j As Integer
        j = 0
        For i = 1 To Len(strPattern)
            If InStr("?", Mid(strPattern, i, 1)) = 0 Then        ' is not "?"
                ReDim Preserve pos(j)
                pos(j) = i
                j = j + 1
            End If
        Next
        Return pos
    End Function


    Public Function AtrributeInput(ByVal tbArributes As DataTable) As Boolean
        Dim i As Integer
        'Return false if any blank serial number
        For i = 0 To tbArributes.Rows.Count - 1
            If tbArributes.Rows(i)(3) Is DBNull.Value Then
                Return False
            End If
            If tbArributes.Rows(i)(3) = "" Then
                Return False
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' Custom regular expression.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum RegExp

        IPv4 = 0
        Mac = 1

    End Enum


    ''' <summary>
    ''' Judge text whether mathes regular expression or not.
    ''' if <c>true</c> match regular expression, <c>false</c> didn't match.
    ''' </summary>
    ''' <param name="text">Input text.</param>
    ''' <param name="regExpIndex">Custom regular expression.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsMatchRegEx(ByVal text As String, ByVal regExpIndex As Integer) As Boolean

        Dim regExPattern As String = String.Empty
        Dim isEmpty As Boolean = String.IsNullOrEmpty(text)

        Select Case (regExpIndex)
            Case RegExp.IPv4
                regExPattern = "^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$"

            Case RegExp.Mac
                regExPattern = "^((([0-9A-Fa-f][0-9A-Fa-f]:){5})|(([0-9A-Fa-f][0-9A-Fa-f]:){7}))[0-9A-Fa-f][0-9A-Fa-f]$" '"^((([0-9A-Fa-f][0-9A-Fa-f]-){5})|(([0-9A-Fa-f][0-9A-Fa-f]-){7}))[0-9A-Fa-f][0-9A-Fa-f]$"

        End Select

        Return Regex.IsMatch(text, regExPattern)

    End Function

    Public Function DJinBox(ByVal DJ As String, ByVal BoxID As String) As String
        Return eTraceRS.DJinBox(DJ, BoxID)
    End Function

    Public Function RevinBox(ByVal BoxID As String) As String
        Return eTraceRS.RevinBox(BoxID)
    End Function

    Public Function BackToEeprom(ByVal IntSN As String, ByVal ExtSN As String, ByVal Attribute As String) As String
        Return eTraceRS.BackToEeprom(IntSN, ExtSN, Attribute)
    End Function
    Public Function PrintSNLabel(ByVal SN As String, ByVal LabelID As String, ByVal printer As String) As String
        Return eTraceRS.PrintSNLabel(SN, LabelID, printer)
    End Function
End Class
