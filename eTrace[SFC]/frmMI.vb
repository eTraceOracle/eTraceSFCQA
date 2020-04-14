Imports AcroPDFLib

Public Class frmMI
    Dim path As String
    Private Sub frmMI_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        AxAcroPDF1.Dispose()
    End Sub

    Private Sub frmMI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        pnlBody.Enabled = True
        BindCtlsToProcess(Me, 0)
        path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\eTrace\EMI\"
        AxAcroPDF1.LoadFile(path + MIFileName + ".pdf")
        AxAcroPDF1.Show()


    End Sub

    Private Sub frmMI_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Me.Visible = True Then
            Me.CenterToScreen()
        End If
    End Sub

End Class