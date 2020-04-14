Imports System.IO
Imports System.IO.Ports
Imports System.Resources
Public Class frmMain

    Public Overrides Sub NewSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'New Instance of the form
        Dim NewInstance As New frmMain()
        NewInstance.ShowFrm(Me)
    End Sub


    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetProcessIDs(Me, ddlProcess, pnlBody)
        BindCtlsToProcess(Me, 0)
    End Sub

    Private Sub ddlProcess_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProcess.SelectedIndexChanged
        Dim ToDigit As Integer
        Dim DR As DataRowView
        DR = ddlProcess.SelectedItem
        SelectProcessID = DR("ProcessID")
        ProcessShow = ddlProcess.Text
        ToDigit = Microsoft.VisualBasic.InStr(ddlProcess.SelectedItem("Name"), "-")
        If ToDigit > 0 Then
            SelectProcess = Microsoft.VisualBasic.Mid(ddlProcess.SelectedItem("Name"), 4, ToDigit - 5)
        Else
            SelectProcess = Microsoft.VisualBasic.Mid(ddlProcess.SelectedItem("Name"), 4)
        End If
        Select Case SelectProcess
            Case "Matching1"
                Dim frmMatching1 As New frmMatching1()
                frmMatching1.ShowFrm(Me)
            Case "ID Swop"
                Dim frmIDSwop As New frmIDSwop()
                frmIDSwop.ShowFrm(Me)
            Case "ID Recycle"
                Dim frmIDRecycle As New frmIDRecycle()
                frmIDRecycle.ShowFrm(Me)
            Case "Packing"
                Dim frmPacking As New frmPacking()
                frmPacking.ShowFrm(Me)
            Case "OQA Cosmetic"
                Dim frmOQA As New frmOQA()
                frmOQA.ShowFrm(Me)
            Case "SMT"
                Dim frmSMT As New frmSMT()
                frmSMT.ShowFrm(Me)
            Case "BurnIn"
                Dim frmBurnIn As New frmBurnIn()
                frmBurnIn.ShowFrm(Me)
            Case "Change Box"
                Dim frmChangeBox As New frmChangeBox()
                frmChangeBox.ShowFrm(Me)
            Case "Change Pallet"
                Dim frmChangePallet As New frmChangePallet()
                frmChangePallet.ShowFrm(Me)
            Case "Rework"
                Dim frmRework As New frmRework()
                frmRework.ShowFrm(Me)
            Case "WIP Rework"
                Dim frmWIPRework As New frmWIPRework()
                frmWIPRework.ShowFrm(Me)
            Case "Info Update"
                Dim frmInfoUpdate As New frmInfoUpdate()
                frmInfoUpdate.ShowFrm(Me)
            Case "ID Update"
                Dim frmIDUpdate As New frmIDUpdate()
                frmIDUpdate.ShowFrm(Me)
            Case "Change Revision"
                Dim frmChangeRevision As New frmChangeRevision()
                frmChangeRevision.ShowFrm(Me)
            Case "Visual Inspection"
                Dim frmVisualInspection As New frmVisualInspection()
                frmVisualInspection.ShowFrm(Me)
            Case "QC and Packing"
                Dim frmQCPacking As New frmQCPacking()
                frmQCPacking.ShowFrm(Me)
            Case "Component Replacement"
                Dim frmComponentReplacement As New frmComponentReplacement()
                frmComponentReplacement.ShowFrm(Me)
            Case "Matching*"
                Dim frmMatchingN As New frmMatchingN()
                frmMatchingN.ShowFrm(Me)
            Case "Model Swop"
                Dim frmModelSwop As New frmModelSwop()
                frmModelSwop.ShowFrm(Me)
            Case "Fixture Mount"
                Dim frmModelSwop As New frmFixtureMount()
                frmModelSwop.ShowFrm(Me)
            Case "ATE Unlock"
                Dim frmModelSwop As New frmUnlock()
                frmModelSwop.ShowFrm(Me)
        End Select

    End Sub

    Private Sub frmMain_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        dsConfig = BLL.getConfig("SFC")
        Me.CenterToScreen()
        If ProductionLine() = "" Then
            Me.ShowMessage("^TDC-159@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            Dim UserSettings As New eTraceUI.frmUserSettings(Me)
            UserSettings.ShowDialog(Me)
        End If
        If myOrg() = "" Then
            Me.ShowMessage("^TDC-159@", eTraceUI.eTraceMessageBar.MessageTypes.Information, AnimationStatus.StopAnim, True, PopUpTypes.Message)
            Dim UserSettings As New eTraceUI.frmUserSettings(Me)
            UserSettings.ShowDialog(Me)
        End If
    End Sub
End Class
