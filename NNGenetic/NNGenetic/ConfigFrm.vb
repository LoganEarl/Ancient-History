Public Class ConfigFrm
    Private Sub ConfigFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolTip1.InitialDelay = 100
        ToolTip1.ReshowDelay = 100
        ToolTip1.UseFading = False
    End Sub

    Private Sub WorldSizeTxt_TextChanged(sender As Object, e As EventArgs) Handles WorldSizeTxt.TextChanged
        checkParams()
    End Sub
    Private Sub checkParams()
        Dim noGoFlag As Boolean = False
        If Integer.TryParse(WorldSizeTxt.Text, worldSize) And WorldSizeTxt.Text <> "" AndAlso (Int(WorldSizeTxt.Text) <= 1000 And Int(WorldSizeTxt.Text) >= 50) Then
            WorldSizeTxt.ForeColor = Color.Black
        Else
            WorldSizeTxt.ForeColor = Color.Red
            noGoFlag = True
        End If

        If Integer.TryParse(SpeciesNumTxt.Text, numCreatures) And SpeciesNumTxt.Text <> "" AndAlso (Int(SpeciesNumTxt.Text) <= 2000 And Int(SpeciesNumTxt.Text) >= 1) Then
            SpeciesNumTxt.ForeColor = Color.Black
        Else
            SpeciesNumTxt.ForeColor = Color.Red
            noGoFlag = True
        End If

        If Integer.TryParse(EatFitnessTxt.Text, eatFitness) And EatFitnessTxt.Text <> "" AndAlso (Int(EatFitnessTxt.Text) <= 600 And Int(EatFitnessTxt.Text) >= 1) Then
            EatFitnessTxt.ForeColor = Color.Black
        Else
            EatFitnessTxt.ForeColor = Color.Red
            noGoFlag = True
        End If

        If Integer.TryParse(WallsNumTxt.Text, numWalls) And WallsNumTxt.Text <> "" AndAlso (Int(WallsNumTxt.Text) <= 100 And Int(WallsNumTxt.Text) >= 0) Then
            WallsNumTxt.ForeColor = Color.Black
        Else
            WallsNumTxt.ForeColor = Color.Red
            noGoFlag = True
        End If

        If Integer.TryParse(ResourceDensityTxt.Text, resourceDensity) And ResourceDensityTxt.Text <> "" AndAlso (Int(ResourceDensityTxt.Text) <= 5000 And Int(ResourceDensityTxt.Text) >= 0) Then
            ResourceDensityTxt.ForeColor = Color.Black
        Else
            ResourceDensityTxt.ForeColor = Color.Red
            noGoFlag = True
        End If

        If Integer.TryParse(TicksPerGenTxt.Text, ticksPerGeneration) And TicksPerGenTxt.Text <> "" AndAlso (Int(TicksPerGenTxt.Text) <= 10000 And Int(TicksPerGenTxt.Text) >= 20) Then
            TicksPerGenTxt.ForeColor = Color.Black
        Else
            TicksPerGenTxt.ForeColor = Color.Red
            noGoFlag = True
        End If

        If Integer.TryParse(AttackFitnessTxt.Text, attackFitness) And AttackFitnessTxt.Text <> "" AndAlso (Int(AttackFitnessTxt.Text) <= 2000 And Int(AttackFitnessTxt.Text) >= 1) Then
            AttackFitnessTxt.ForeColor = Color.Black
        Else
            AttackFitnessTxt.ForeColor = Color.Red
            noGoFlag = True
        End If


        BeginBtn.Enabled = Not noGoFlag
    End Sub

    Private Sub SpeciesNumTxt_TextChanged(sender As Object, e As EventArgs) Handles SpeciesNumTxt.TextChanged
        checkParams()
    End Sub

    Private Sub EatFitnessTxt_TextChanged(sender As Object, e As EventArgs) Handles EatFitnessTxt.TextChanged
        checkParams()
    End Sub

    Private Sub WallsNumTxt_TextChanged(sender As Object, e As EventArgs) Handles WallsNumTxt.TextChanged
        checkParams()
    End Sub

    Private Sub ResourceDensityTxt_TextChanged(sender As Object, e As EventArgs) Handles ResourceDensityTxt.TextChanged
        checkParams()
    End Sub

    Private Sub TicksPerGenTxt_TextChanged(sender As Object, e As EventArgs) Handles TicksPerGenTxt.TextChanged
        checkParams()
    End Sub

    Private Sub AttackFitnessTxt_TextChanged(sender As Object, e As EventArgs) Handles AttackFitnessTxt.TextChanged
        checkParams()
    End Sub

    Private Sub BeginBtn_Click(sender As Object, e As EventArgs) Handles BeginBtn.Click
        Me.Hide()
        MainFrm.Show()
    End Sub
End Class