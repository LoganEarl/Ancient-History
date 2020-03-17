<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigFrm
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
        Me.components = New System.ComponentModel.Container()
        Me.BeginBtn = New System.Windows.Forms.Button()
        Me.WorldSizeTxt = New System.Windows.Forms.TextBox()
        Me.WorldSizeLbl = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SpeciesNumTxt = New System.Windows.Forms.TextBox()
        Me.ResourceDensityTxt = New System.Windows.Forms.TextBox()
        Me.AttackFitnessTxt = New System.Windows.Forms.TextBox()
        Me.EatFitnessTxt = New System.Windows.Forms.TextBox()
        Me.TicksPerGenTxt = New System.Windows.Forms.TextBox()
        Me.WallsNumTxt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ResourceLbl = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BeginBtn
        '
        Me.BeginBtn.Location = New System.Drawing.Point(113, 306)
        Me.BeginBtn.Name = "BeginBtn"
        Me.BeginBtn.Size = New System.Drawing.Size(133, 34)
        Me.BeginBtn.TabIndex = 0
        Me.BeginBtn.Text = "Begin Simulation"
        Me.BeginBtn.UseVisualStyleBackColor = True
        '
        'WorldSizeTxt
        '
        Me.WorldSizeTxt.ForeColor = System.Drawing.Color.Black
        Me.WorldSizeTxt.Location = New System.Drawing.Point(15, 29)
        Me.WorldSizeTxt.Name = "WorldSizeTxt"
        Me.WorldSizeTxt.Size = New System.Drawing.Size(69, 20)
        Me.WorldSizeTxt.TabIndex = 1
        Me.WorldSizeTxt.Text = "100"
        Me.ToolTip1.SetToolTip(Me.WorldSizeTxt, "100 - 300. Any higher makes big fps drop" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        '
        'WorldSizeLbl
        '
        Me.WorldSizeLbl.AutoSize = True
        Me.WorldSizeLbl.Location = New System.Drawing.Point(12, 13)
        Me.WorldSizeLbl.Name = "WorldSizeLbl"
        Me.WorldSizeLbl.Size = New System.Drawing.Size(58, 13)
        Me.WorldSizeLbl.TabIndex = 2
        Me.WorldSizeLbl.Text = "World Size"
        '
        'SpeciesNumTxt
        '
        Me.SpeciesNumTxt.Location = New System.Drawing.Point(15, 68)
        Me.SpeciesNumTxt.Name = "SpeciesNumTxt"
        Me.SpeciesNumTxt.Size = New System.Drawing.Size(69, 20)
        Me.SpeciesNumTxt.TabIndex = 5
        Me.SpeciesNumTxt.Text = "75"
        Me.ToolTip1.SetToolTip(Me.SpeciesNumTxt, "100 is small, 800 is quite big")
        '
        'ResourceDensityTxt
        '
        Me.ResourceDensityTxt.Location = New System.Drawing.Point(113, 29)
        Me.ResourceDensityTxt.Name = "ResourceDensityTxt"
        Me.ResourceDensityTxt.Size = New System.Drawing.Size(69, 20)
        Me.ResourceDensityTxt.TabIndex = 6
        Me.ResourceDensityTxt.Text = "80"
        Me.ToolTip1.SetToolTip(Me.ResourceDensityTxt, "The amount of additional resources created per generation")
        '
        'AttackFitnessTxt
        '
        Me.AttackFitnessTxt.Location = New System.Drawing.Point(113, 108)
        Me.AttackFitnessTxt.Name = "AttackFitnessTxt"
        Me.AttackFitnessTxt.Size = New System.Drawing.Size(69, 20)
        Me.AttackFitnessTxt.TabIndex = 7
        Me.AttackFitnessTxt.Text = "100"
        Me.ToolTip1.SetToolTip(Me.AttackFitnessTxt, "creature fitnes accuired for killing others. 300 is quite hillarious")
        '
        'EatFitnessTxt
        '
        Me.EatFitnessTxt.Location = New System.Drawing.Point(15, 108)
        Me.EatFitnessTxt.Name = "EatFitnessTxt"
        Me.EatFitnessTxt.Size = New System.Drawing.Size(69, 20)
        Me.EatFitnessTxt.TabIndex = 8
        Me.EatFitnessTxt.Text = "100"
        Me.ToolTip1.SetToolTip(Me.EatFitnessTxt, "Creature fitness accuired for eating. 20-100 is best")
        '
        'TicksPerGenTxt
        '
        Me.TicksPerGenTxt.Location = New System.Drawing.Point(113, 68)
        Me.TicksPerGenTxt.Name = "TicksPerGenTxt"
        Me.TicksPerGenTxt.Size = New System.Drawing.Size(69, 20)
        Me.TicksPerGenTxt.TabIndex = 9
        Me.TicksPerGenTxt.Text = "300"
        Me.ToolTip1.SetToolTip(Me.TicksPerGenTxt, "The length of a generation in in-game time. 500 is average")
        '
        'WallsNumTxt
        '
        Me.WallsNumTxt.Location = New System.Drawing.Point(15, 147)
        Me.WallsNumTxt.Name = "WallsNumTxt"
        Me.WallsNumTxt.Size = New System.Drawing.Size(71, 20)
        Me.WallsNumTxt.TabIndex = 15
        Me.WallsNumTxt.Text = "6"
        Me.ToolTip1.SetToolTip(Me.WallsNumTxt, "The number of randomly generated walls. keep below 10 for small worlds")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "# of Species"
        '
        'ResourceLbl
        '
        Me.ResourceLbl.AutoSize = True
        Me.ResourceLbl.Location = New System.Drawing.Point(110, 13)
        Me.ResourceLbl.Name = "ResourceLbl"
        Me.ResourceLbl.Size = New System.Drawing.Size(91, 13)
        Me.ResourceLbl.TabIndex = 10
        Me.ResourceLbl.Text = "Resource Density"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(110, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Attack Fitness"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Eat Fitness"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(110, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Ticks per Generation"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "# of Walls"
        '
        'ConfigFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(253, 352)
        Me.Controls.Add(Me.WallsNumTxt)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ResourceLbl)
        Me.Controls.Add(Me.TicksPerGenTxt)
        Me.Controls.Add(Me.EatFitnessTxt)
        Me.Controls.Add(Me.AttackFitnessTxt)
        Me.Controls.Add(Me.ResourceDensityTxt)
        Me.Controls.Add(Me.SpeciesNumTxt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.WorldSizeLbl)
        Me.Controls.Add(Me.WorldSizeTxt)
        Me.Controls.Add(Me.BeginBtn)
        Me.Name = "ConfigFrm"
        Me.Text = "Configuration"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BeginBtn As Button
    Friend WithEvents WorldSizeTxt As TextBox
    Friend WithEvents WorldSizeLbl As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label1 As Label
    Friend WithEvents SpeciesNumTxt As TextBox
    Friend WithEvents ResourceDensityTxt As TextBox
    Friend WithEvents AttackFitnessTxt As TextBox
    Friend WithEvents EatFitnessTxt As TextBox
    Friend WithEvents TicksPerGenTxt As TextBox
    Friend WithEvents ResourceLbl As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents WallsNumTxt As TextBox
End Class
