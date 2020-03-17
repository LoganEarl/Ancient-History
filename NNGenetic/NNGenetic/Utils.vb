Module Utils

    Public Function randomNum(min As Integer, max As Integer) As Integer
        Return Int(((max + 1) - min) * Rnd()) + min
    End Function

    Public Sub nextGeneration()
        sortCreaturesByFitness()

        ageCreatures()

        If worldGeneration > generations.Length - 1 Then
            ReDim Preserve generations(generations.Length + 100)
        End If
        generations(worldGeneration) = New Generation(worldGeneration, creatures.Clone())

        worldGeneration += 1
        breedNew()
        resourcesEaten = 0
        creaturesKilled = 0
    End Sub
    Public Sub ageCreatures()
        For Each selectedCreature In creatures
            selectedCreature.age += 1
        Next
    End Sub
    Public Sub sortCreaturesByFitness()
        Dim temp As Creature
        Dim min As Integer
        'eww, make a new one with merge sort or sm. none of this selection sort BS
        For sel = 0 To creatures.Length - 2
            min = sel
            For cur = sel + 1 To creatures.Length - 1
                If (creatures(min).compareTo(creatures(cur)) > 0) Then min = cur
            Next
            temp = creatures(sel)
            creatures(sel) = creatures(min)
            creatures(min) = temp
        Next
        For x = 0 To creatures.Length - 1
            creatures(x).number = x
        Next
    End Sub

    Public Sub breedNew()
        Dim numCreatures As Integer = creatures.Length

        For i = 0 To creatures.Length - 1
            creatures(i).clear()
        Next

        For i = Math.Floor(numCreatures / 2) To numCreatures - 1
            creatures(i) = New Creature(creatures(i - numCreatures / 2), randomNum(0, worldSize), randomNum(0, worldSize), i, creatures(i).timeIntervals)
        Next

        If GlobalVars.worldGeneration Mod 50 = 0 Then
            myWorld.placeWalls(numWalls)
        End If
        'If generation Mod 1 = 0 Then
        myWorld.placeResources(resourceDensity)
        'End If

        'If generation Mod 2 = 0 Then
        '    For i = Int(creatures.Length * 0.5) To creatures.Length - 1
        '        creatures(i) = New Creature(randomNum(0, worldSize), randomNum(0, worldSize), 0.09, 0.15, i)
        '    Next
        'End If

    End Sub

    Public Function findAvgFitness() As Integer
        Dim total As Double
        For Each creature In creatures
            total += creature.fitness
        Next
        Return total / creatures.Length
    End Function

    Public Function generateSpeciesName() As String
        Dim firstAdj() As String = {"Red", "Green", "Yellow", "Orange", "Blue", "Violet", "Angry", "Depressed", "Clever", "Stupid", "Pointless", "Elegant", "Drab", "Plain", "Sparkling", "Ugliest", "Wide-Eyed", "Quant", "Unsightly", "Obidient", "Witty", "Silly", "Shy", "Tender", "Vast", "Fat", "Extreemly", "Super Duper", "Clumsy", "Continuously Itchy", "Chubby", "Crooked", "Broad-chested"}
        Dim secondAdj() As String = {"Pulsating", "Yeasty", "Bitter", "Boiling", "Bumpy", "Fluffy", "French", "Polish", "Sweedish", "Alert", "Alcoholic", "Abrasive", "Acidic", "Acrid", "Aloof", "Amused", "Aquatic", "Alluring", "Awsome", "Wet", "Substantial", "Bitter", "Loose", "Melted", "Filthy", "Flaky", "Dirty", "Sparse", "Aboriginal", "Acidic", "Amused", "Assorted", "Agressive", "Ancient", "Rotten", "Tart", "Tastless", "Dry"}
        Dim noun() As String = {"Yeast", "Anax", "Argus", "Chiron", "Chull", "Bat", "Bandicoot", "Bowtruckle", "Chicken", "Cockatrice", "Crup", "Dugbog", "Erkling", "Frenchman", "Sweed", "Crazy American", "Knarl", "Imp", "Lobalug", "Manticore", "Fat Hoe", "Pixie", "Porlock", "Rat", "Salamander", "Sasquatch", "Troll", "Unicorn", "Werewolf", "Winged Horse", "Yeti", "Tebo", "Shrake", "Hag", "Curupika", "Dwarf", "Ogre", "Veela", "Yumbo"}

        Return firstAdj(randomNum(0, firstAdj.Length - 1)) + " " + secondAdj(randomNum(0, secondAdj.Length - 1)) + " " + noun(randomNum(0, noun.Length - 1)) + "s"
    End Function

End Module
