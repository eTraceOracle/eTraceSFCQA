Public Class frmLogin
    Private Sub frmLogin_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'This is needed to change the webservice connection for eTraceUI
        SetEnv(My.Settings.LoginServer)
        BLL.SetTDCEnv(My.Settings.LoginServer)
    End Sub
    Private Sub LoginCompleted_event() Handles Me.LoginCompleted
        'Show application main form
        dsConfig = BLL.getConfig("SFC")
        Dim MainFrm As New frmMain
        MainFrm.ShowFrm(Me)
    End Sub

    Public Overrides Sub OnChangeUser()
        'Close all forms before changing user
        Me.ResetAppForLogin(My.Application.OpenForms)
    End Sub
End Class
