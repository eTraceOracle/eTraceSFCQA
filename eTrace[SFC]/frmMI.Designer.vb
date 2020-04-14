<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMI
    Inherits eTraceUI.eTraceForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMI))
        Me.ddlProcess = New eTraceUI.eTraceComboBox
        Me.pnlBody = New eTraceUI.eTracePanel
        Me.AxAcroPDF1 = New AxAcroPDFLib.AxAcroPDF
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MessageBar1
        '
        Me.MessageBar1.Location = New System.Drawing.Point(0, 543)
        Me.MessageBar1.Size = New System.Drawing.Size(1056, 22)
        '
        'ddlProcess
        '
        Me.ddlProcess.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ddlProcess.DataType = Nothing
        Me.ddlProcess.ElementTitle = Nothing
        Me.ddlProcess.ErrorColor = System.Drawing.Color.DarkOrange
        Me.ddlProcess.ErrorMessage = Nothing
        Me.ddlProcess.FormattingEnabled = True
        Me.ddlProcess.LimitToList = True
        Me.ddlProcess.Location = New System.Drawing.Point(139, 3)
        Me.ddlProcess.MaxDropDownItems = 20
        Me.ddlProcess.Name = "ddlProcess"
        Me.ddlProcess.NoOfDecimals = 0
        Me.ddlProcess.ParentControl = Nothing
        Me.ddlProcess.RegEx = Nothing
        Me.ddlProcess.Required = False
        Me.ddlProcess.Size = New System.Drawing.Size(219, 21)
        Me.ddlProcess.StatusControl = Nothing
        Me.ddlProcess.TabIndex = 1
        Me.ddlProcess.TextCase = eTraceUI.eTraceComboBox.TextCases.None
        Me.ddlProcess.ValidationType = Nothing
        Me.ddlProcess.WarnColor = System.Drawing.Color.Wheat
        '
        'pnlBody
        '
        Me.pnlBody.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBody.AutoScroll = True
        Me.pnlBody.Location = New System.Drawing.Point(0, 0)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Size = New System.Drawing.Size(792, 527)
        Me.pnlBody.TabIndex = 0
        '
        'AxAcroPDF1
        '
        Me.AxAcroPDF1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AxAcroPDF1.Enabled = True
        Me.AxAcroPDF1.Location = New System.Drawing.Point(0, 54)
        Me.AxAcroPDF1.Name = "AxAcroPDF1"
        Me.AxAcroPDF1.OcxState = CType(resources.GetObject("AxAcroPDF1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF1.Size = New System.Drawing.Size(1056, 511)
        Me.AxAcroPDF1.TabIndex = 4
        '
        'frmMI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1056, 565)
        Me.Controls.Add(Me.AxAcroPDF1)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "frmMI"
        Me.Text = "frmMI"
        Me.Controls.SetChildIndex(Me.AxAcroPDF1, 0)
        Me.Controls.SetChildIndex(Me.MessageBar1, 0)
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ddlProcess As eTraceUI.eTraceComboBox
    Friend WithEvents pnlBody As eTraceUI.eTracePanel
    Friend WithEvents AxAcroPDF1 As AxAcroPDFLib.AxAcroPDF
End Class
