Imports System.Threading

Public Class frmInitial
    Public Delegate Sub myDg()
    Public myLoginForm As frmLogin

    Public Sub ShowLoginFrm()
        Try
            Dim myDelegate1 As New myDg(AddressOf LoadLoginFrm)
            Me.Invoke(myDelegate1)
        Catch ex As Exception
        End Try

    End Sub

    Public Sub LoadLoginFrm()
        myLoginForm = New frmLogin
        myLoginForm.ShowFrm(Me)
        'myLoginForm.Show()
    End Sub

    Private Sub InitialForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Check if allow to run the program multiple times or not
        If AllowMultipleRun = False Then
            If UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) > 0 Then
                Timer1.Enabled = False
                'MsgBox("The Programm is running!")
                Application.Exit()
            End If
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try

            'LoadInitial()
            Dim myThread As New System.Threading.Thread(AddressOf ShowLoginFrm)
            myThread.Start()

            Timer1.Enabled = False
        Catch ex As Exception
        End Try
    End Sub

End Class
