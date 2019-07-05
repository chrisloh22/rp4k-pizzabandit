<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VictoryForm1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VictoryForm1))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.QuitButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.clocktime = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.AccessibleName = ""
        Me.Button1.BackColor = System.Drawing.Color.Maroon
        Me.Button1.Font = New System.Drawing.Font("Segoe Marker", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(958, 673)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(198, 64)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Play Again"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'QuitButton
        '
        Me.QuitButton.AccessibleName = ""
        Me.QuitButton.BackColor = System.Drawing.Color.Maroon
        Me.QuitButton.Font = New System.Drawing.Font("Segoe Marker", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QuitButton.ForeColor = System.Drawing.Color.White
        Me.QuitButton.Location = New System.Drawing.Point(1160, 673)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(198, 64)
        Me.QuitButton.TabIndex = 4
        Me.QuitButton.Text = "Quit"
        Me.QuitButton.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe Marker", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(453, 220)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(313, 40)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "        Your Time:            "
        '
        'clocktime
        '
        Me.clocktime.AutoSize = True
        Me.clocktime.Font = New System.Drawing.Font("Segoe Marker", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clocktime.Location = New System.Drawing.Point(667, 220)
        Me.clocktime.Name = "clocktime"
        Me.clocktime.Size = New System.Drawing.Size(32, 40)
        Me.clocktime.TabIndex = 6
        Me.clocktime.Text = "0"
        '
        'VictoryForm1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1370, 749)
        Me.Controls.Add(Me.clocktime)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.QuitButton)
        Me.Name = "VictoryForm1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents clocktime As System.Windows.Forms.Label
End Class
