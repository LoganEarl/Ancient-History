Public Class Generation
    Public generationNum As Integer
    Public numSpecies As Integer
    Public species() As String
    Public ArchivedCreatures() As Creature
    Public averageFitness As Double
    Public resourcesEaten As Integer
    Public creaturesKilled As Integer

    'default constructor madeto represent the current generation
    Public Sub New()
        Me.New(-1, GlobalVars.creatures)
    End Sub

    Public Sub New(curGeneration As Integer, ArchivedCreatures() As Creature)
        Me.ArchivedCreatures = ArchivedCreatures
        generationNum = curGeneration
        ReDim species(ArchivedCreatures.Length)
        For x = 0 To species.Length - 1
            species(x) = ""
        Next

        resourcesEaten = GlobalVars.resourcesEaten
        'generationNum

        Dim fitnessTotal As Integer = 0
        For x = 0 To ArchivedCreatures.Length - 1
            fitnessTotal += ArchivedCreatures(x).fitness
            If ArchivedCreatures(x).isDead Then creaturesKilled += 1
            If Not checkForSpecies(ArchivedCreatures(x).species) Then
                Dim z As Integer = 0
                While (Not species(z).Equals(""))
                    z += 1
                End While
                species(z) = ArchivedCreatures(x).species
            End If
        Next

        Dim y As Integer = 0
        While (Not species(y).Equals(""))
            y += 1
        End While
        numSpecies = y
        ReDim Preserve species(numSpecies - 1)

        averageFitness = fitnessTotal / ArchivedCreatures.Length
    End Sub

    Public Sub liveUpdateMe()
        averageFitness = findAvgFitness()
        resourcesEaten = GlobalVars.resourcesEaten
        creaturesKilled = GlobalVars.creaturesKilled
    End Sub

    Public Function checkForSpecies(mySpecies As String) As Boolean
        For Each speciesName In species
            If speciesName.Equals(mySpecies) Then Return True
        Next
        Return False
    End Function

    Public Function getSpeciesColor(selectedSpecies As String) As Color
        For Each selectedCreature In ArchivedCreatures
            If selectedCreature.species.Equals(selectedSpecies) Then
                Return selectedCreature.color
            End If
        Next
        Return Color.White
    End Function

    Public Function getMembersOf(selectedSpecies As String) As String()
        Dim total As Integer = 0
        Dim returns(numCreatures - 1) As String

        For Each selectedCreature In ArchivedCreatures
            If selectedCreature.species.Equals(selectedSpecies) Then
                returns(total) = selectedCreature.id '
                total += 1
            End If
        Next
        ReDim Preserve returns(total - 1)
        Return returns
    End Function

    Public Function getCreatureData(id As String) As String
        Dim idP As Integer
        If Integer.TryParse(id, idP) Then
            Dim returns As String = ""
            Dim myCreature As Creature = Nothing
            For Each myCreature In ArchivedCreatures
                If myCreature.id = idP Then Exit For
            Next

            returns += "Creature ID:        " + Str(myCreature.id) + vbCrLf
            returns += "Was KIA:            " + Str(myCreature.isDead) + vbCrLf
            returns += "Fitness:            " + Str(myCreature.fitness) + vbCrLf
            returns += "Total Kills:        " + Str(myCreature.myKills) + vbCrLf
            returns += "Total Eaten:        " + Str(myCreature.myResourcesEaten) + vbCrLf
            returns += "Age (Generations):  " + Str(myCreature.age) + vbCrLf
            returns += "Time Intervals:     ("
            For x = 0 To 2
                returns += Str(myCreature.timeIntervals(x)) + ","
            Next
            returns += Str(myCreature.timeIntervals(3)) + ")" + vbCrLf + "======Begin Creature log=========" + vbCrLf
            returns += myCreature.creatureLog

            Return returns
        Else
            Return "Could not parse ID"
        End If

    End Function

    Public Function getSpeciesData(index As Integer) As String
        Dim returns As String = ""
        Dim population As Integer = 0
        Dim speciesAvgFitness As Integer = 0
        Dim speciesAvgKills As Integer = 0
        Dim speciesAvgEaten As Integer = 0
        Dim populationKilled As Integer = 0
        Dim maxKills(1) As Integer
        Dim maxEaten(1) As Integer

        For Each selectedCreature In ArchivedCreatures
            If selectedCreature.species.Equals(species(index)) Then
                speciesAvgFitness += selectedCreature.fitness
                speciesAvgEaten += selectedCreature.myResourcesEaten
                speciesAvgKills += selectedCreature.myKills
                If selectedCreature.myKills > maxKills(0) Then
                    maxKills(0) = selectedCreature.myKills
                    maxKills(1) = selectedCreature.id
                End If
                If selectedCreature.myResourcesEaten > maxEaten(0) Then
                    maxEaten(0) = selectedCreature.myResourcesEaten
                    maxEaten(1) = selectedCreature.id
                End If
                If selectedCreature.isDead Then populationKilled += 1
                population += 1
            End If
        Next
        If population = 0 Then Return "Species population was 0... Error?"
        speciesAvgFitness /= population
        speciesAvgEaten /= population
        speciesAvgKills /= population

        returns += "Species:             " + species(index) + vbCrLf
        returns += "Highest Ranking:     " + Str(index) + vbCrLf
        returns += "Total Population:    " + Str(population) + vbCrLf
        returns += "Population KIA:      " + Str(populationKilled) + vbCrLf
        returns += "Avg Resouces Eaten:  " + Str(speciesAvgEaten) + vbCrLf
        returns += "Avg Kills:           " + Str(speciesAvgKills) + vbCrLf
        returns += "Highest KillCount:   " + Str(maxKills(0)) + "(" + Str(maxKills(1)) + ")" + vbCrLf
        returns += "Most Resource Eaten: " + Str(maxEaten(0)) + "(" + Str(maxEaten(1)) + ")" + vbCrLf

        Return returns
    End Function
    Public Function getGenerationData() As String
        Dim returns As String
        returns = "Generation:          " + Str(generationNum) + vbCrLf
        returns += "Average Fitness:     " + Str(averageFitness) + vbCrLf
        returns += "Resources Eaten:     " + Str(resourcesEaten) + vbCrLf
        returns += "Creatures Killed:    " + Str(creaturesKilled) + vbCrLf
        returns += "Number of Species:   " + Str(species.Length - 1) + vbCrLf
        returns += "Fittest Species:     " + species(0) + vbCrLf
        Return returns
    End Function

    Public Overloads Function toString() As String
        Return "Generation: " + Str(generationNum)
    End Function
End Class
