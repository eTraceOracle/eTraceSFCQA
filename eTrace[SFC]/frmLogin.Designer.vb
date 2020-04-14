<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
    Inherits eTraceUI.LoginForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(314, 276)
        Me.eTraceLoginType = eTraceUI.LoginForm.LoginType.AccessCard
        Me.eTraceModule = eTraceUI.LoginForm.ModuleName.ShopFloorControl
        Me.Name = "frmLogin"
        Me.Tag = "SFC006"
        Me.Text = " Login for ShopFloorControl module"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

End Class
