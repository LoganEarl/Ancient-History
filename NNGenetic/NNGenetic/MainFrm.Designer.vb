<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainFrm
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
        Me.XScroll = New System.Windows.Forms.HScrollBar()
        Me.YScroll = New System.Windows.Forms.VScrollBar()
        Me.PauseBtn = New System.Windows.Forms.Button()
        Me.pg3 = New System.Windows.Forms.TabPage()
        Me.ColorDisplayTxt = New System.Windows.Forms.TextBox()
        Me.SelectedCreatureDataTxt = New System.Windows.Forms.TextBox()
        Me.SelectedSpeciesDataTxt = New System.Windows.Forms.TextBox()
        Me.SelectedGenerationDataTxt = New System.Windows.Forms.TextBox()
        Me.CreatureSelectorDrp = New System.Windows.Forms.ComboBox()
        Me.SpeciesSelectorDrp = New System.Windows.Forms.ComboBox()
        Me.SpeciesListLbl = New System.Windows.Forms.Label()
        Me.GenerationSelectorDrp = New System.Windows.Forms.ComboBox()
        Me.pg1 = New System.Windows.Forms.TabPage()
        Me.UseGraphicsCb = New System.Windows.Forms.CheckBox()
        Me.KilledLbl = New System.Windows.Forms.Label()
        Me.GenerationLbl = New System.Windows.Forms.Label()
        Me.HyperdriveCb = New System.Windows.Forms.CheckBox()
        Me.ActionsPerTickSb = New System.Windows.Forms.TrackBar()
        Me.AvgFitnessLbl = New System.Windows.Forms.Label()
        Me.EatenLbl = New System.Windows.Forms.Label()
        Me.VStepsLbl = New System.Windows.Forms.Label()
        Me.FpsLbl = New System.Windows.Forms.Label()
        Me.totalTicksLbl = New System.Windows.Forms.Label()
        Me.ResSelector = New System.Windows.Forms.ComboBox()
        Me.CurGenerationDataTxt = New System.Windows.Forms.TextBox()
        Me.OptionsTC = New System.Windows.Forms.TabControl()
        Me.InputsLbl = New System.Windows.Forms.Label()
        Me.ActionsLbl = New System.Windows.Forms.Label()
        Me.BufferLayersLbl = New System.Windows.Forms.Label()
        Me.WallSenseLbl = New System.Windows.Forms.Label()
        Me.FoodSenseLbl = New System.Windows.Forms.Label()
        Me.TimeSenseLbl = New System.Windows.Forms.Label()
        Me.EnemySenseLbl = New System.Windows.Forms.Label()
        Me.MoveLbl = New System.Windows.Forms.Label()
        Me.EatLbl = New System.Windows.Forms.Label()
        Me.KillLbl = New System.Windows.Forms.Label()
        Me.SingleStepBtn = New System.Windows.Forms.Button()
        Me.pg3.SuspendLayout()
        Me.pg1.SuspendLayout()
        CType(Me.ActionsPerTickSb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.OptionsTC.SuspendLayout()
        Me.SuspendLayout()
        '
        'XScroll
        '
        Me.XScroll.Location = New System.Drawing.Point(2, 606)
        Me.XScroll.Maximum = 500
        Me.XScroll.Name = "XScroll"
        Me.XScroll.Size = New System.Drawing.Size(601, 20)
        Me.XScroll.TabIndex = 10
        '
        'YScroll
        '
        Me.YScroll.Location = New System.Drawing.Point(605, 0)
        Me.YScroll.Maximum = 200
        Me.YScroll.Name = "YScroll"
        Me.YScroll.Size = New System.Drawing.Size(20, 605)
        Me.YScroll.TabIndex = 12
        '
        'PauseBtn
        '
        Me.PauseBtn.Location = New System.Drawing.Point(1085, 560)
        Me.PauseBtn.Name = "PauseBtn"
        Me.PauseBtn.Size = New System.Drawing.Size(169, 45)
        Me.PauseBtn.TabIndex = 15
        Me.PauseBtn.Text = "Resume"
        Me.PauseBtn.UseVisualStyleBackColor = True
        '
        'pg3
        '
        Me.pg3.Controls.Add(Me.ColorDisplayTxt)
        Me.pg3.Controls.Add(Me.SelectedCreatureDataTxt)
        Me.pg3.Controls.Add(Me.SelectedSpeciesDataTxt)
        Me.pg3.Controls.Add(Me.SelectedGenerationDataTxt)
        Me.pg3.Controls.Add(Me.CreatureSelectorDrp)
        Me.pg3.Controls.Add(Me.SpeciesSelectorDrp)
        Me.pg3.Controls.Add(Me.SpeciesListLbl)
        Me.pg3.Controls.Add(Me.GenerationSelectorDrp)
        Me.pg3.Location = New System.Drawing.Point(4, 22)
        Me.pg3.Name = "pg3"
        Me.pg3.Padding = New System.Windows.Forms.Padding(3)
        Me.pg3.Size = New System.Drawing.Size(346, 515)
        Me.pg3.TabIndex = 2
        Me.pg3.Text = "Generation Data"
        Me.pg3.UseVisualStyleBackColor = True
        '
        'ColorDisplayTxt
        '
        Me.ColorDisplayTxt.Location = New System.Drawing.Point(181, 459)
        Me.ColorDisplayTxt.Multiline = True
        Me.ColorDisplayTxt.Name = "ColorDisplayTxt"
        Me.ColorDisplayTxt.ReadOnly = True
        Me.ColorDisplayTxt.Size = New System.Drawing.Size(162, 44)
        Me.ColorDisplayTxt.TabIndex = 14
        '
        'SelectedCreatureDataTxt
        '
        Me.SelectedCreatureDataTxt.Font = New System.Drawing.Font("Courier New", 7.0!)
        Me.SelectedCreatureDataTxt.Location = New System.Drawing.Point(4, 278)
        Me.SelectedCreatureDataTxt.MaxLength = 0
        Me.SelectedCreatureDataTxt.Multiline = True
        Me.SelectedCreatureDataTxt.Name = "SelectedCreatureDataTxt"
        Me.SelectedCreatureDataTxt.ReadOnly = True
        Me.SelectedCreatureDataTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.SelectedCreatureDataTxt.Size = New System.Drawing.Size(339, 175)
        Me.SelectedCreatureDataTxt.TabIndex = 12
        Me.SelectedCreatureDataTxt.WordWrap = False
        '
        'SelectedSpeciesDataTxt
        '
        Me.SelectedSpeciesDataTxt.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelectedSpeciesDataTxt.Location = New System.Drawing.Point(3, 155)
        Me.SelectedSpeciesDataTxt.Multiline = True
        Me.SelectedSpeciesDataTxt.Name = "SelectedSpeciesDataTxt"
        Me.SelectedSpeciesDataTxt.ReadOnly = True
        Me.SelectedSpeciesDataTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.SelectedSpeciesDataTxt.Size = New System.Drawing.Size(336, 90)
        Me.SelectedSpeciesDataTxt.TabIndex = 10
        '
        'SelectedGenerationDataTxt
        '
        Me.SelectedGenerationDataTxt.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelectedGenerationDataTxt.Location = New System.Drawing.Point(4, 33)
        Me.SelectedGenerationDataTxt.Multiline = True
        Me.SelectedGenerationDataTxt.Name = "SelectedGenerationDataTxt"
        Me.SelectedGenerationDataTxt.ReadOnly = True
        Me.SelectedGenerationDataTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.SelectedGenerationDataTxt.Size = New System.Drawing.Size(337, 89)
        Me.SelectedGenerationDataTxt.TabIndex = 9
        '
        'CreatureSelectorDrp
        '
        Me.CreatureSelectorDrp.Enabled = False
        Me.CreatureSelectorDrp.FormattingEnabled = True
        Me.CreatureSelectorDrp.Location = New System.Drawing.Point(4, 251)
        Me.CreatureSelectorDrp.Name = "CreatureSelectorDrp"
        Me.CreatureSelectorDrp.Size = New System.Drawing.Size(336, 21)
        Me.CreatureSelectorDrp.TabIndex = 11
        Me.CreatureSelectorDrp.Text = "Select Creature"
        '
        'SpeciesSelectorDrp
        '
        Me.SpeciesSelectorDrp.Enabled = False
        Me.SpeciesSelectorDrp.FormattingEnabled = True
        Me.SpeciesSelectorDrp.Location = New System.Drawing.Point(2, 128)
        Me.SpeciesSelectorDrp.Name = "SpeciesSelectorDrp"
        Me.SpeciesSelectorDrp.Size = New System.Drawing.Size(337, 21)
        Me.SpeciesSelectorDrp.TabIndex = 8
        Me.SpeciesSelectorDrp.Text = "Select Species"
        '
        'SpeciesListLbl
        '
        Me.SpeciesListLbl.AutoSize = True
        Me.SpeciesListLbl.Location = New System.Drawing.Point(7, 61)
        Me.SpeciesListLbl.Name = "SpeciesListLbl"
        Me.SpeciesListLbl.Size = New System.Drawing.Size(0, 13)
        Me.SpeciesListLbl.TabIndex = 7
        '
        'GenerationSelectorDrp
        '
        Me.GenerationSelectorDrp.FormattingEnabled = True
        Me.GenerationSelectorDrp.Location = New System.Drawing.Point(3, 6)
        Me.GenerationSelectorDrp.MaxDropDownItems = 20
        Me.GenerationSelectorDrp.Name = "GenerationSelectorDrp"
        Me.GenerationSelectorDrp.Size = New System.Drawing.Size(337, 21)
        Me.GenerationSelectorDrp.TabIndex = 5
        Me.GenerationSelectorDrp.Text = "Select Generation"
        '
        'pg1
        '
        Me.pg1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pg1.Controls.Add(Me.UseGraphicsCb)
        Me.pg1.Controls.Add(Me.KilledLbl)
        Me.pg1.Controls.Add(Me.GenerationLbl)
        Me.pg1.Controls.Add(Me.HyperdriveCb)
        Me.pg1.Controls.Add(Me.ActionsPerTickSb)
        Me.pg1.Controls.Add(Me.AvgFitnessLbl)
        Me.pg1.Controls.Add(Me.EatenLbl)
        Me.pg1.Controls.Add(Me.VStepsLbl)
        Me.pg1.Controls.Add(Me.FpsLbl)
        Me.pg1.Controls.Add(Me.totalTicksLbl)
        Me.pg1.Controls.Add(Me.ResSelector)
        Me.pg1.Controls.Add(Me.CurGenerationDataTxt)
        Me.pg1.Location = New System.Drawing.Point(4, 22)
        Me.pg1.Name = "pg1"
        Me.pg1.Padding = New System.Windows.Forms.Padding(3)
        Me.pg1.Size = New System.Drawing.Size(346, 515)
        Me.pg1.TabIndex = 0
        Me.pg1.Text = "Sim Controls"
        Me.pg1.UseVisualStyleBackColor = True
        '
        'UseGraphicsCb
        '
        Me.UseGraphicsCb.AutoSize = True
        Me.UseGraphicsCb.Checked = True
        Me.UseGraphicsCb.CheckState = System.Windows.Forms.CheckState.Checked
        Me.UseGraphicsCb.Location = New System.Drawing.Point(18, 133)
        Me.UseGraphicsCb.Name = "UseGraphicsCb"
        Me.UseGraphicsCb.Size = New System.Drawing.Size(90, 17)
        Me.UseGraphicsCb.TabIndex = 19
        Me.UseGraphicsCb.Text = "Use Graphics"
        Me.UseGraphicsCb.UseVisualStyleBackColor = True
        '
        'KilledLbl
        '
        Me.KilledLbl.AutoSize = True
        Me.KilledLbl.Location = New System.Drawing.Point(15, 225)
        Me.KilledLbl.Name = "KilledLbl"
        Me.KilledLbl.Size = New System.Drawing.Size(86, 13)
        Me.KilledLbl.TabIndex = 4
        Me.KilledLbl.Text = "Creatures Killed: "
        '
        'GenerationLbl
        '
        Me.GenerationLbl.AutoSize = True
        Me.GenerationLbl.Location = New System.Drawing.Point(122, 12)
        Me.GenerationLbl.Name = "GenerationLbl"
        Me.GenerationLbl.Size = New System.Drawing.Size(71, 13)
        Me.GenerationLbl.TabIndex = 1
        Me.GenerationLbl.Text = "Generation: 1"
        '
        'HyperdriveCb
        '
        Me.HyperdriveCb.AutoSize = True
        Me.HyperdriveCb.Location = New System.Drawing.Point(18, 111)
        Me.HyperdriveCb.Name = "HyperdriveCb"
        Me.HyperdriveCb.Size = New System.Drawing.Size(77, 17)
        Me.HyperdriveCb.TabIndex = 18
        Me.HyperdriveCb.Text = "Hyperdrive"
        Me.HyperdriveCb.UseVisualStyleBackColor = True
        '
        'ActionsPerTickSb
        '
        Me.ActionsPerTickSb.Location = New System.Drawing.Point(18, 59)
        Me.ActionsPerTickSb.Maximum = 30
        Me.ActionsPerTickSb.Minimum = 1
        Me.ActionsPerTickSb.Name = "ActionsPerTickSb"
        Me.ActionsPerTickSb.Size = New System.Drawing.Size(115, 45)
        Me.ActionsPerTickSb.TabIndex = 17
        Me.ActionsPerTickSb.TickFrequency = 3
        Me.ActionsPerTickSb.Value = 1
        '
        'AvgFitnessLbl
        '
        Me.AvgFitnessLbl.AutoSize = True
        Me.AvgFitnessLbl.Location = New System.Drawing.Point(12, 180)
        Me.AvgFitnessLbl.Name = "AvgFitnessLbl"
        Me.AvgFitnessLbl.Size = New System.Drawing.Size(181, 13)
        Me.AvgFitnessLbl.TabIndex = 0
        Me.AvgFitnessLbl.Text = "Current Generation Average Fitness: "
        '
        'EatenLbl
        '
        Me.EatenLbl.AutoSize = True
        Me.EatenLbl.Location = New System.Drawing.Point(12, 202)
        Me.EatenLbl.Name = "EatenLbl"
        Me.EatenLbl.Size = New System.Drawing.Size(76, 13)
        Me.EatenLbl.TabIndex = 3
        Me.EatenLbl.Text = "Things Eaten: "
        '
        'VStepsLbl
        '
        Me.VStepsLbl.AutoSize = True
        Me.VStepsLbl.Location = New System.Drawing.Point(15, 42)
        Me.VStepsLbl.Name = "VStepsLbl"
        Me.VStepsLbl.Size = New System.Drawing.Size(98, 13)
        Me.VStepsLbl.TabIndex = 16
        Me.VStepsLbl.Text = "Virtual Steps/Tick: "
        '
        'FpsLbl
        '
        Me.FpsLbl.AutoSize = True
        Me.FpsLbl.Location = New System.Drawing.Point(15, 29)
        Me.FpsLbl.Name = "FpsLbl"
        Me.FpsLbl.Size = New System.Drawing.Size(33, 13)
        Me.FpsLbl.TabIndex = 15
        Me.FpsLbl.Text = "FPS: "
        '
        'totalTicksLbl
        '
        Me.totalTicksLbl.AutoSize = True
        Me.totalTicksLbl.Location = New System.Drawing.Point(12, 12)
        Me.totalTicksLbl.Name = "totalTicksLbl"
        Me.totalTicksLbl.Size = New System.Drawing.Size(39, 13)
        Me.totalTicksLbl.TabIndex = 14
        Me.totalTicksLbl.Text = "Ticks: "
        '
        'ResSelector
        '
        Me.ResSelector.FormattingEnabled = True
        Me.ResSelector.Items.AddRange(New Object() {"30 X 20", "15 X 30", "12 X 50", "10 X 60", "8   X 75", "6   X 100", "5   X 120", "3   X 200", "2   X 300", "1   X 600"})
        Me.ResSelector.Location = New System.Drawing.Point(18, 156)
        Me.ResSelector.Name = "ResSelector"
        Me.ResSelector.Size = New System.Drawing.Size(121, 21)
        Me.ResSelector.TabIndex = 13
        Me.ResSelector.Text = "Zoom Level"
        '
        'CurGenerationDataTxt
        '
        Me.CurGenerationDataTxt.Location = New System.Drawing.Point(10, 253)
        Me.CurGenerationDataTxt.Multiline = True
        Me.CurGenerationDataTxt.Name = "CurGenerationDataTxt"
        Me.CurGenerationDataTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.CurGenerationDataTxt.Size = New System.Drawing.Size(330, 259)
        Me.CurGenerationDataTxt.TabIndex = 2
        Me.CurGenerationDataTxt.Text = "Average Fitness by Generation"
        '
        'OptionsTC
        '
        Me.OptionsTC.Controls.Add(Me.pg1)
        Me.OptionsTC.Controls.Add(Me.pg3)
        Me.OptionsTC.Location = New System.Drawing.Point(900, 12)
        Me.OptionsTC.Name = "OptionsTC"
        Me.OptionsTC.SelectedIndex = 0
        Me.OptionsTC.Size = New System.Drawing.Size(354, 541)
        Me.OptionsTC.TabIndex = 14
        '
        'InputsLbl
        '
        Me.InputsLbl.AutoSize = True
        Me.InputsLbl.Location = New System.Drawing.Point(644, 12)
        Me.InputsLbl.Name = "InputsLbl"
        Me.InputsLbl.Size = New System.Drawing.Size(36, 13)
        Me.InputsLbl.TabIndex = 16
        Me.InputsLbl.Text = "Inputs"
        '
        'ActionsLbl
        '
        Me.ActionsLbl.AutoSize = True
        Me.ActionsLbl.Location = New System.Drawing.Point(842, 12)
        Me.ActionsLbl.Name = "ActionsLbl"
        Me.ActionsLbl.Size = New System.Drawing.Size(42, 13)
        Me.ActionsLbl.TabIndex = 17
        Me.ActionsLbl.Text = "Actions"
        '
        'BufferLayersLbl
        '
        Me.BufferLayersLbl.AutoSize = True
        Me.BufferLayersLbl.Location = New System.Drawing.Point(717, 12)
        Me.BufferLayersLbl.Name = "BufferLayersLbl"
        Me.BufferLayersLbl.Size = New System.Drawing.Size(69, 13)
        Me.BufferLayersLbl.TabIndex = 18
        Me.BufferLayersLbl.Text = "Buffer Nodes"
        '
        'WallSenseLbl
        '
        Me.WallSenseLbl.AutoSize = True
        Me.WallSenseLbl.BackColor = System.Drawing.Color.White
        Me.WallSenseLbl.Location = New System.Drawing.Point(628, 35)
        Me.WallSenseLbl.Name = "WallSenseLbl"
        Me.WallSenseLbl.Size = New System.Drawing.Size(61, 13)
        Me.WallSenseLbl.TabIndex = 19
        Me.WallSenseLbl.Text = "Wall Sense"
        '
        'FoodSenseLbl
        '
        Me.FoodSenseLbl.AutoSize = True
        Me.FoodSenseLbl.BackColor = System.Drawing.Color.Transparent
        Me.FoodSenseLbl.Location = New System.Drawing.Point(628, 175)
        Me.FoodSenseLbl.Name = "FoodSenseLbl"
        Me.FoodSenseLbl.Size = New System.Drawing.Size(64, 13)
        Me.FoodSenseLbl.TabIndex = 20
        Me.FoodSenseLbl.Text = "Food Sense"
        '
        'TimeSenseLbl
        '
        Me.TimeSenseLbl.AutoSize = True
        Me.TimeSenseLbl.BackColor = System.Drawing.Color.Transparent
        Me.TimeSenseLbl.Location = New System.Drawing.Point(628, 315)
        Me.TimeSenseLbl.Name = "TimeSenseLbl"
        Me.TimeSenseLbl.Size = New System.Drawing.Size(63, 13)
        Me.TimeSenseLbl.TabIndex = 21
        Me.TimeSenseLbl.Text = "Time Sense"
        '
        'EnemySenseLbl
        '
        Me.EnemySenseLbl.AutoSize = True
        Me.EnemySenseLbl.BackColor = System.Drawing.Color.Transparent
        Me.EnemySenseLbl.Location = New System.Drawing.Point(628, 455)
        Me.EnemySenseLbl.Name = "EnemySenseLbl"
        Me.EnemySenseLbl.Size = New System.Drawing.Size(72, 13)
        Me.EnemySenseLbl.TabIndex = 22
        Me.EnemySenseLbl.Text = "Enemy Sense"
        '
        'MoveLbl
        '
        Me.MoveLbl.AutoSize = True
        Me.MoveLbl.BackColor = System.Drawing.Color.White
        Me.MoveLbl.Location = New System.Drawing.Point(860, 35)
        Me.MoveLbl.Name = "MoveLbl"
        Me.MoveLbl.Size = New System.Drawing.Size(34, 13)
        Me.MoveLbl.TabIndex = 23
        Me.MoveLbl.Text = "Move"
        '
        'EatLbl
        '
        Me.EatLbl.AutoSize = True
        Me.EatLbl.BackColor = System.Drawing.Color.White
        Me.EatLbl.Location = New System.Drawing.Point(871, 175)
        Me.EatLbl.Name = "EatLbl"
        Me.EatLbl.Size = New System.Drawing.Size(23, 13)
        Me.EatLbl.TabIndex = 24
        Me.EatLbl.Text = "Eat"
        '
        'KillLbl
        '
        Me.KillLbl.AutoSize = True
        Me.KillLbl.BackColor = System.Drawing.Color.White
        Me.KillLbl.Location = New System.Drawing.Point(874, 210)
        Me.KillLbl.Name = "KillLbl"
        Me.KillLbl.Size = New System.Drawing.Size(20, 13)
        Me.KillLbl.TabIndex = 25
        Me.KillLbl.Text = "Kill"
        '
        'SingleStepBtn
        '
        Me.SingleStepBtn.Location = New System.Drawing.Point(904, 560)
        Me.SingleStepBtn.Name = "SingleStepBtn"
        Me.SingleStepBtn.Size = New System.Drawing.Size(171, 45)
        Me.SingleStepBtn.TabIndex = 26
        Me.SingleStepBtn.Text = "Single Step"
        Me.SingleStepBtn.UseVisualStyleBackColor = True
        '
        'MainFrm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1266, 628)
        Me.Controls.Add(Me.SingleStepBtn)
        Me.Controls.Add(Me.KillLbl)
        Me.Controls.Add(Me.EatLbl)
        Me.Controls.Add(Me.MoveLbl)
        Me.Controls.Add(Me.EnemySenseLbl)
        Me.Controls.Add(Me.TimeSenseLbl)
        Me.Controls.Add(Me.FoodSenseLbl)
        Me.Controls.Add(Me.WallSenseLbl)
        Me.Controls.Add(Me.BufferLayersLbl)
        Me.Controls.Add(Me.ActionsLbl)
        Me.Controls.Add(Me.InputsLbl)
        Me.Controls.Add(Me.PauseBtn)
        Me.Controls.Add(Me.OptionsTC)
        Me.Controls.Add(Me.YScroll)
        Me.Controls.Add(Me.XScroll)
        Me.Name = "MainFrm"
        Me.Text = "Fun With Genetic Algorithms"
        Me.pg3.ResumeLayout(False)
        Me.pg3.PerformLayout()
        Me.pg1.ResumeLayout(False)
        Me.pg1.PerformLayout()
        CType(Me.ActionsPerTickSb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.OptionsTC.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents XScroll As HScrollBar
    Friend WithEvents YScroll As VScrollBar
    Friend WithEvents PauseBtn As Button
    Friend WithEvents pg3 As TabPage
    Friend WithEvents ColorDisplayTxt As TextBox
    Friend WithEvents SelectedCreatureDataTxt As TextBox
    Friend WithEvents SelectedSpeciesDataTxt As TextBox
    Friend WithEvents SelectedGenerationDataTxt As TextBox
    Friend WithEvents CreatureSelectorDrp As ComboBox
    Friend WithEvents SpeciesSelectorDrp As ComboBox
    Friend WithEvents SpeciesListLbl As Label
    Friend WithEvents GenerationSelectorDrp As ComboBox
    Friend WithEvents pg1 As TabPage
    Friend WithEvents UseGraphicsCb As CheckBox
    Friend WithEvents KilledLbl As Label
    Friend WithEvents GenerationLbl As Label
    Friend WithEvents HyperdriveCb As CheckBox
    Friend WithEvents ActionsPerTickSb As TrackBar
    Friend WithEvents AvgFitnessLbl As Label
    Friend WithEvents EatenLbl As Label
    Friend WithEvents VStepsLbl As Label
    Friend WithEvents FpsLbl As Label
    Friend WithEvents totalTicksLbl As Label
    Friend WithEvents ResSelector As ComboBox
    Friend WithEvents CurGenerationDataTxt As TextBox
    Friend WithEvents OptionsTC As TabControl
    Friend WithEvents InputsLbl As Label
    Friend WithEvents ActionsLbl As Label
    Friend WithEvents BufferLayersLbl As Label
    Friend WithEvents WallSenseLbl As Label
    Friend WithEvents FoodSenseLbl As Label
    Friend WithEvents TimeSenseLbl As Label
    Friend WithEvents EnemySenseLbl As Label
    Friend WithEvents MoveLbl As Label
    Friend WithEvents EatLbl As Label
    Friend WithEvents KillLbl As Label
    Friend WithEvents SingleStepBtn As Button
End Class
