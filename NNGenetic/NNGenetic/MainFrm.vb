Imports System.ComponentModel

Public Class MainFrm
    'graphics objects
    Dim G As Graphics
    Dim BBG As Graphics
    Dim BB As Bitmap
    Dim r As Rectangle

    'fps counter
    Dim tSec As Integer = TimeOfDay.Second
    Dim tTicks As Integer = 0
    Dim maxTicks As Integer = 0

    'sim controls
    Dim virtualSteps As Integer = 1
    Dim modVirtualSteps As Integer = 1

    'stage settings
    Dim selectX As Integer = 0
    Dim selectY As Integer = 0
    Dim stageWidth As Integer = 30
    Dim stageHeight As Integer = 30
    Dim tileSize As Integer = 20

    Dim isRunning As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Show()
        Focus()
        Randomize()

        myWorld = New World(resourceDensity, numWalls)
        ReDim creatures(numCreatures - 1)
        ReDim generations(99)

        For i = 0 To creatures.Length - 1
            creatures(i) = New Creature(randomNum(0, worldSize), randomNum(0, worldSize), {0.1, 0.02, 0.1}, i)
        Next

        'initialize the current generation(that is, the one that will allways represent the current population
        generations(0) = New Generation()

        G = CreateGraphics()
        BB = New Bitmap(Width, Height)
        BBG = G
        XScroll.Maximum = worldSize - stageWidth
        YScroll.Maximum = worldSize - stageHeight

        Me.ResSelector.SelectedIndex = 9
        simLoop()
    End Sub

    Private Sub simLoop()
        Do
            Application.DoEvents()
            Do While isRunning
                For i = 1 To modVirtualSteps
                    Application.DoEvents()

                    For n = 0 To creatures.Length - 1
                        creatures(n).tick()
                    Next

                    generations(0).liveUpdateMe()

                    totalTicks += 1
                    totalTicksLbl.Text = "Ticks: " + Str(totalTicks)
                    updateHyperdrive()
                    If totalTicks > ticksPerGeneration Then
                        Me.CurGenerationDataTxt.AppendText(vbCrLf & "Generation " + Str(GlobalVars.worldGeneration) + ": " + Str(findAvgFitness()))
                        nextGeneration()
                        totalTicks = 0
                        Me.GenerationLbl.Text = "Generation: " + Str(GlobalVars.worldGeneration)
                        myWorld.refreshData()
                        generations(0) = New Generation()
                        refreshCreatureSelectors()
                    End If
                Next

                drawGraphics()
                tickCounter()
            Loop
            drawGraphics()
            tickCounter()
        Loop
    End Sub

    Private Sub SingleStepBtn_Click(sender As Object, e As EventArgs) Handles SingleStepBtn.Click
        For n = 0 To creatures.Length - 1
            creatures(n).tick()
        Next

        generations(0).liveUpdateMe()

        totalTicks += 1
        totalTicksLbl.Text = "Ticks: " + Str(totalTicks)
        If totalTicks > ticksPerGeneration Then
            Me.CurGenerationDataTxt.AppendText(vbCrLf & "Generation " + Str(GlobalVars.worldGeneration) + ": " + Str(findAvgFitness()))
            nextGeneration()
            totalTicks = 0
            Me.GenerationLbl.Text = "Generation: " + Str(GlobalVars.worldGeneration)
            myWorld.refreshData()
            generations(0) = New Generation()
            refreshCreatureSelectors()
        End If
        drawGraphics()
        tickCounter()
    End Sub

    Private Sub drawGraphics()
        If Me.UseGraphicsCb.Checked Then
            'used for node display
            Dim nodeRadius As Integer = 8
            Dim horOffset As Integer = 650
            Dim vertOffset As Integer = 50
            Dim horSpace As Integer = 55
            Dim vertSpace As Integer = 35

            'display creature nodes
            If Not IsNothing(globalSelectedCreature) Then
                Dim Pen1 = New Pen(Color.Black, 2)
                For y = 0 To 4
                    Dim x As Integer = 0
                    Do While (x < maxNodesPerCollum) AndAlso (Not IsNothing(globalSelectedCreature.nodes(y, x)))
                        Dim x1, y1, x2, y2 As Integer
                        x1 = horSpace * y + horOffset
                        y1 = x * vertSpace + vertOffset
                        If y Mod 2 <> 0 Then y1 += (vertSpace / 2)


                        For Each selectLink In globalSelectedCreature.nodes(y, x).links
                            If Not IsNothing(selectLink) AndAlso Not IsNothing(globalSelectedCreature.nodes(selectLink.destinationX, selectLink.destinationY)) Then
                                Dim Pen2
                                If Me.GenerationSelectorDrp.SelectedIndex = 0 Then
                                    Dim modActivity As Double = selectLink.weight * globalSelectedCreature.nodes(y, x).activity * 255
                                    If modActivity > 255 Then modActivity = 255
                                    Pen2 = New Pen(Color.FromArgb(modActivity, modActivity, 0), Int(selectLink.weight * 5))
                                Else
                                    Pen2 = New Pen(Color.FromArgb(selectLink.weight * 127, 0, 200), Int(selectLink.weight * 5))
                                End If
                                x2 = selectLink.destinationX * horSpace + horOffset + nodeRadius
                                y2 = selectLink.destinationY * vertSpace + vertOffset + nodeRadius
                                If selectLink.destinationX Mod 2 <> 0 Then y2 += (vertSpace / 2)
                                G.DrawLine(Pen2, x1 + nodeRadius, y1 + nodeRadius, x2, y2)
                            End If
                        Next

                        Dim nodeActivity As Integer
                        Dim nodeColor
                        If Me.GenerationSelectorDrp.SelectedIndex = 0 Then
                            nodeActivity = globalSelectedCreature.nodes(y, x).activity * 255
                            If nodeActivity > 255 Then nodeActivity = 255
                            nodeColor = New SolidBrush(Color.FromArgb(nodeActivity, nodeActivity, 0))
                        Else
                            nodeColor = New SolidBrush(Color.White)
                        End If
                        G.FillEllipse(nodeColor, x1, y1, nodeRadius * 2, nodeRadius * 2)
                        G.DrawEllipse(Pen1, x1, y1, nodeRadius * 2, nodeRadius * 2)

                        x += 1
                    Loop
                Next
            End If

            'draw tiles
            For x = 0 To stageWidth - 1
                For y = 0 To stageHeight
                    r = New Rectangle(x * tileSize, y * tileSize, tileSize, tileSize)
                    Dim myBrush As Brush
                    myBrush = New SolidBrush(myWorld.getColor(x + selectX, y + selectY))

                    G.FillRectangle(myBrush, r)
                Next
            Next

            If Not IsNothing(globalSelectedCreature) AndAlso globalSelectedCreature.isDead = False Then
                Dim x As Integer = globalSelectedCreature.charX
                Dim y As Integer = globalSelectedCreature.charY

                If x > selectX AndAlso x < selectX + stageWidth AndAlso y > selectY AndAlso y < selectY + stageHeight Then '
                    Dim myPen = New Pen(Color.Red, Int(Math.Sqrt(tileSize)))
                    G.DrawRectangle(myPen, x * tileSize, y * tileSize, tileSize, tileSize)
                End If
            End If

            'display the graphics object weve been writing to
            G = Graphics.FromImage(BB)

            BBG = CreateGraphics()
            BBG.DrawImage(BB, 0, 0, Width, Height)

            G.Clear(Color.White)
        End If

        If (Me.GenerationSelectorDrp.SelectedIndex = 0) Then
            Me.SelectedGenerationDataTxt.Text = generations(0).getGenerationData()
            If Me.SpeciesSelectorDrp.Enabled And Me.SpeciesSelectorDrp.SelectedIndex <> -1 Then
                Me.SelectedSpeciesDataTxt.Text = generations(0).getSpeciesData(SpeciesSelectorDrp.SelectedIndex)
            End If
            If Me.CreatureSelectorDrp.Enabled And Me.CreatureSelectorDrp.SelectedIndex <> -1 Then
                Me.SelectedCreatureDataTxt.Text = generations(0).getCreatureData(CreatureSelectorDrp.SelectedItem)
            End If
        End If
        Me.AvgFitnessLbl.Text = "Current Generation Average Fitness: " + Str(findAvgFitness())
        Me.EatenLbl.Text = "Things Eaten: " + Str(resourcesEaten)
        Me.KilledLbl.Text = "Creatures Killed: " + Str(creaturesKilled)

    End Sub

    'Private GenSelectorDrpsEventsEnabled As Boolean = True
    Private Sub refreshCreatureSelectors()
        'run this only at the end of a generation
        If Me.GenerationSelectorDrp.SelectedIndex = 0 Then
            Dim lastGeneration As Integer = Me.GenerationSelectorDrp.SelectedIndex
            Dim lastSpecies As String = Me.SpeciesSelectorDrp.SelectedItem
            Dim lastCreature As String = Me.CreatureSelectorDrp.SelectedItem

            Me.GenerationSelectorDrp.SelectedIndex = -1
            Me.GenerationSelectorDrp.SelectedIndex = lastGeneration

            If (Not IsNothing(lastSpecies)) AndAlso Me.SpeciesSelectorDrp.Enabled AndAlso Me.SpeciesSelectorDrp.Items.IndexOf(lastSpecies) <> -1 Then
                Me.SpeciesSelectorDrp.SelectedItem = lastSpecies
            End If

            If (Not IsNothing(lastCreature)) AndAlso Me.CreatureSelectorDrp.Enabled AndAlso Me.CreatureSelectorDrp.Items.IndexOf(lastCreature) <> -1 Then
                Me.CreatureSelectorDrp.SelectedItem = lastCreature
            End If

        End If
    End Sub

    Private Sub updateHyperdrive()
        If HyperdriveCb.Checked Then
            modVirtualSteps = virtualSteps * 100
        Else
            modVirtualSteps = virtualSteps
        End If
    End Sub
    Private Sub tickCounter()
        If tSec = TimeOfDay.Second And isRunning Then
            tTicks += 1
        Else
            maxTicks = tTicks
            tTicks = 0
            tSec = TimeOfDay.Second
        End If
        FpsLbl.Text = "FPS: " + Str(maxTicks)
    End Sub

    Private Sub ActionsPerTickSb_Scroll(sender As Object, e As EventArgs) Handles ActionsPerTickSb.Scroll
        virtualSteps = ActionsPerTickSb.Value
        VStepsLbl.Text = "Virtual Steps/Tick: " + Str(virtualSteps)
    End Sub

    Private Sub PauseBtn_Click(sender As Object, e As EventArgs) Handles PauseBtn.Click
        isRunning = Not isRunning
        If isRunning Then
            Me.PauseBtn.Text = "Pause"
            Me.SingleStepBtn.Enabled = False
        Else
            Me.PauseBtn.Text = "Resume"
            Me.SingleStepBtn.Enabled = True
        End If
    End Sub

    Private Sub XScroll_Scroll(sender As Object, e As ScrollEventArgs) Handles XScroll.Scroll
        selectX = Me.XScroll.Value
        Me.drawGraphics()
    End Sub

    Private Sub YScroll_Scroll(sender As Object, e As ScrollEventArgs) Handles YScroll.Scroll
        selectY = Me.YScroll.Value
        Me.drawGraphics()
    End Sub

    Private ResSelectorEventsEnabled As Boolean = True

    Private Sub ResSelector_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ResSelector.SelectedIndexChanged
        Dim base As Integer
        Dim selection = Me.ResSelector.SelectedIndex + 1

        If ResSelectorEventsEnabled Then
            ResSelectorEventsEnabled = False
            Do
                selection = selection - 1
                Select Case selection
                    Case 0
                        base = 20
                    Case 1
                        base = 40
                    Case 2
                        base = 50
                    Case 3
                        base = 60
                    Case 4
                        base = 75
                    Case 5
                        base = 100
                    Case 6
                        base = 120
                    Case 7
                        base = 200
                    Case 8
                        base = 300
                    Case 9
                        base = 600
                End Select

            Loop While Not selectRes(base, base, 600 / base)

            If Me.ResSelector.SelectedIndex <> selection Then Me.ResSelector.SelectedIndex = selection
            ResSelectorEventsEnabled = True
        End If
    End Sub
    Private Function selectRes(myStageWidth As Integer, myStageHeight As Integer, myTileSize As Integer) As Boolean
        If myStageHeight > worldSize Or myStageWidth > worldSize Then
            Return False
        End If
        stageWidth = myStageWidth
        stageHeight = myStageHeight
        tileSize = myTileSize
        XScroll.Maximum = worldSize - stageWidth
        YScroll.Maximum = worldSize - stageHeight
        Return True
    End Function

    Private Sub MainFrm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Hide()
        End
    End Sub

    Private Sub GenerationSelectorDrp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GenerationSelectorDrp.SelectedIndexChanged
        If GenerationSelectorDrp.SelectedIndex <> -1 Then
            'add a check for the current generation
            SelectedGenerationDataTxt.Text = generations(GenerationSelectorDrp.SelectedIndex).getGenerationData()
            SpeciesSelectorDrp.Items.Clear()
            For Each species In generations(GenerationSelectorDrp.SelectedIndex).species
                SpeciesSelectorDrp.Items.Add(species)
            Next
            SpeciesSelectorDrp.Enabled = True
            CreatureSelectorDrp.Enabled = False
            SelectedCreatureDataTxt.Text = ""
            SelectedSpeciesDataTxt.Text = ""
        End If
    End Sub

    Private Sub GenerationSelectorDrp_MouseClick(sender As Object, e As MouseEventArgs) Handles GenerationSelectorDrp.MouseClick
        GenerationSelectorDrp.Items.Clear()
        For Each curGen In generations
            If IsNothing(curGen) Then Exit For
            If (GenerationSelectorDrp.SelectedIndex = 0) Then
                GenerationSelectorDrp.Items.Add("Current Generation")
            Else
                GenerationSelectorDrp.Items.Add(curGen.toString())
            End If
        Next
    End Sub

    Private Sub SpeciesSelectorDrp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SpeciesSelectorDrp.SelectedIndexChanged
        If (generations(GenerationSelectorDrp.SelectedIndex).species.Count >= GenerationSelectorDrp.SelectedIndex) Then
            SelectedSpeciesDataTxt.Text = generations(GenerationSelectorDrp.SelectedIndex).getSpeciesData(SpeciesSelectorDrp.SelectedIndex)
            CreatureSelectorDrp.Items.Clear()

            CreatureSelectorDrp.Items.AddRange(generations(GenerationSelectorDrp.SelectedIndex).getMembersOf(SpeciesSelectorDrp.SelectedItem))
            CreatureSelectorDrp.Enabled = True
            ColorDisplayTxt.BackColor = generations(GenerationSelectorDrp.SelectedIndex).getSpeciesColor(SpeciesSelectorDrp.SelectedItem)
        End If
    End Sub

    Private Sub CreatureSelectorDrp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CreatureSelectorDrp.SelectedIndexChanged
        SelectedCreatureDataTxt.Text = generations(GenerationSelectorDrp.SelectedIndex).getCreatureData(CreatureSelectorDrp.SelectedItem)
        Dim idP As Integer

        For Each myCreature In generations(GenerationSelectorDrp.SelectedIndex).ArchivedCreatures
            If Integer.TryParse(CreatureSelectorDrp.SelectedItem, idP) Then
                If idP = myCreature.id Then
                    globalSelectedCreature = myCreature
                End If
            End If
        Next
    End Sub

    Private Sub MainFrm_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        If Cursor.Position.X - Me.Bounds.X > 635 AndAlso Cursor.Position.X - Me.Bounds.X < 910 Then
            selectNode(Cursor.Position.X - Me.Bounds.X, Cursor.Position.Y - Me.Bounds.Y)
        ElseIf Cursor.Position.X - Me.Bounds.X > 0 AndAlso Cursor.Position.X - Me.Bounds.X < 610 Then
            selectCreature(Cursor.Position.X - Me.Bounds.X, Cursor.Position.Y - Me.Bounds.Y)
        End If
    End Sub

    Private Sub selectCreature(x As Integer, y As Integer)
        Dim tileX As Integer = x / tileSize + selectX
        Dim tileY As Integer = y / tileSize + selectY

        Dim selCreature As Creature = myWorld.getCreature(tileX, tileY)

        If Not IsNothing(selCreature) Then
            globalSelectedCreature = selCreature

            Me.GenerationSelectorDrp.SelectedIndex = 0

            'may need to validate these...
            Me.SpeciesSelectorDrp.SelectedItem = selCreature.species
            Me.CreatureSelectorDrp.SelectedItem = selCreature.id

        End If
    End Sub

    Private Sub selectNode(x As Integer, y As Integer)
        'not yet implemented
    End Sub


End Class


