Public Class Creature
    Public nodes(4, maxNodesPerCollum - 1) As Node

    Public isDead As Boolean

    Public species As String
    Public generation As Integer
    Public color As Color
    Public number As Integer
    Public id As Integer

    Public creatureLog As String

    Public charX As Integer
    Public charY As Integer

    Public startingX As Integer
    Public startingY As Integer

    Public fitness As Double
    Public myKills As Integer
    Public myResourcesEaten As Integer
    Public age As Integer

    Public timeIntervals(3) As Integer

    Public mutationChance(2) As Double
    '0 = new node chance                    chance to make a new node with connections 0-1
    '1 = new connection chance              chance to make a new link. (the chance to modify a link's strength is 3x this)
    '2 = change time interval chance        chance to change the time intervals in which nodes 8-11 trigger
    Public Sub New(x As Integer, y As Integer, number As Integer)
        id = generation * 100000 + totalCreaturesMade
        totalCreaturesMade += 1
        startingX = x
        startingY = y
        isDead = False
        Me.number = number
        charX = x
        charY = y
    End Sub
    Public Sub New(parent As Creature, x As Integer, y As Integer, number As Integer, timeIntervals() As Integer)
        Me.New(x, y, number)
        Me.timeIntervals = timeIntervals
        color = parent.color

        For x = 0 To 4
            For y = 0 To maxNodesPerCollum - 1
                If Not IsNothing(parent.nodes(x, y)) Then
                    nodes(x, y) = parent.nodes(x, y).Clone()
                End If
            Next
        Next

        species = parent.species
        generation = parent.generation + 1
        creatureLog = parent.creatureLog.Clone()
        creatureLog += "--------New Creature Born---------- (the above logs are from this creature's parent)" + vbCrLf

        For q = 0 To mutationChance.Length - 1
            mutationChance(q) = parent.mutationChance(q)
        Next

        mutateMe()
        myWorld.setData(x, y, number)

    End Sub

    Public Sub New(x As Integer, y As Integer, mutationChance() As Double, number As Integer)
        Me.New(x, y, number)

        For q = 0 To Me.mutationChance.Length - 1
            Me.mutationChance(q) = mutationChance(q)
        Next

        species = Utils.generateSpeciesName()
        creatureLog = "The founder of the " + species + " is born! May they live long and prosper" + vbCrLf
        createTimeIntervals()
        generation = 0
        color = Color.FromArgb(randomNum(0, 255), randomNum(0, 255), randomNum(0, 255))

        createNewNodeSet()
        mutateMe()
        myWorld.setData(x, y, number)
    End Sub
    Public Sub createTimeIntervals()
        For x = 0 To timeIntervals.Length - 1
            timeIntervals(x) = randomNum(2, 20)
        Next
    End Sub

    Public Sub tick()
        If Not isDead Then
            For Each member In nodes
                If Not IsNothing(member) Then member.activity = 0
            Next

            'save a shit ton of memory not saving logs for every single damn creature
            creatureLog = ""

            injectInputNodes()
            propigateNodes(False) 'make clearbehind a global option later
            makeAction()
        End If
    End Sub
    Public Sub wrapCordinants()
        While (charX > worldSize - 1)
            charX -= worldSize
        End While
        While (charY > worldSize - 1)
            charY -= worldSize
        End While
        While (charX < 0)
            charX += worldSize
        End While
        While (charY < 0)
            charY += worldSize
        End While
    End Sub

    Public Sub propigateNodes(clearBehind As Boolean)
        If Not clearBehind Then clearNodes()

        For x = 0 To 3
            For y = 0 To maxNodesPerCollum - 1
                If Not IsNothing(nodes(x, y)) Then                  'skip uninitialized nodes
                    nodes(x, y).activate()
                    If Not IsNothing(nodes(x, y).links(0)) Then     'skip unconnected nodes
                        For Each link In nodes(x, y).links
                            If Not IsNothing(link) AndAlso Not IsNothing(nodes(link.destinationX, link.destinationY)) Then             'skip uninitialized links
                                nodes(link.destinationX, link.destinationY).activity += nodes(x, y).activity * link.weight  'problem here. somtimes links are generated that point nowere (maybe fixked now, keep an eye out)
                            End If
                        Next
                        If clearBehind Then nodes(x, y).activity = 0
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub clearNodes()
        For x = 1 To 3
            For y = 0 To maxNodesPerCollum - 1
                If Not IsNothing(nodes(x, y)) Then
                    nodes(x, y).activity = 0
                End If
            Next
        Next
    End Sub

    Public Sub mutateMe()
        creatureLog += "-Generation " + Str(generation) + vbCrLf

        Dim tempRnd As Double = Rnd()
        If tempRnd <= mutationChance(0) Then
            creatureLog += "---New node at " + makeNewNode() + vbCrLf
        End If
        If tempRnd >= 1 - mutationChance(0) Then
            creatureLog += "---Node at " + deleteRandomNode() + " was deleted." + vbCrLf
        End If

        If Rnd() <= mutationChance(1) Then
            creatureLog += "---New Link(s) at " + makeNewLinks(1) + vbCrLf
        ElseIf Rnd() <= mutationChance(1) * 2 Then
            Dim randomCords() As Integer = getRandomNode(0, 4, True)
            creatureLog += "---Change in link strength " + nodes(randomCords(0), randomCords(1)).modRandomLink() + vbCrLf
        End If
        If Rnd() <= mutationChance(2) Then
            Dim intervalIndex As Integer = randomNum(0, timeIntervals.Length - 1)
            Dim newValue As Integer = randomNum(2, 20)
            creatureLog += "---Interval " + Str(intervalIndex) + " changed from " + Str(timeIntervals(intervalIndex)) + " to " + Str(newValue) + vbCrLf
            timeIntervals(intervalIndex) = newValue
        End If
        cleanNodeSet()
    End Sub

    Public Function deleteRandomNode() As String
        Dim x() As Integer = getRandomNode(1, 4, True)
        If x(0) = 0 Then
            Return "(No nodes to delete)"
        Else
            nodes(x(0), x(1)) = Nothing
            Return "(" + Str(x(0)) + "," + Str(x(1)) + ")"
        End If


    End Function

    Public Sub cleanNodeSet()
        'this is needed so when we delete a random node or link, it doesnt leave behind useless bits

        'activate all inputs. this should mean everything that is connected to the start gets a least a little activation
        For x = 0 To maxNodesPerCollum - 1
            nodes(0, x).activity = 1
        Next
        propigateNodes(False)

        'delete every middle node that isnt activated. if it isnt activated, it means it has no way to become activated
        'consider disabling this. could be cool to have a set reactivate after a bunch of gens
        For x = 1 To 3
            For y = 0 To maxNodesPerCollum - 1
                If Not IsNothing(nodes(x, y)) Then
                    If nodes(x, y).activity = 0 Then
                        nodes(x, y) = Nothing
                    End If
                End If
            Next
        Next

        'loop through every link in every node. if it references a null node, delete it
        For x = 0 To 3
            For y = 0 To maxNodesPerCollum - 1
                If Not IsNothing(nodes(x, y)) Then
                    For z = 0 To 4
                        If Not IsNothing(nodes(x, y).links(z)) Then
                            If IsNothing(nodes(nodes(x, y).links(z).destinationX, nodes(x, y).links(z).destinationY)) Then
                                nodes(x, y).links(z) = Nothing
                            End If
                        End If
                    Next
                End If
            Next
        Next

        'flush out the node set
        propigateNodes(True)

    End Sub

    Public Function getRandomNode(minCollum As Integer, maxCollum As Integer, startLow As Boolean) As Integer()
        'not sure how this thing works. but it does and its fast so dont fuck with it
        Dim activeNodes(4 * maxNodesPerCollum) As Integer
        Dim count As Integer = 0
        Dim returns(1) As Integer
        Dim startPoint, stopPoint As Integer

        If startLow Then
            startPoint = minCollum
            stopPoint = maxCollum - 1
        Else
            startPoint = maxCollum + 1
            stopPoint = 4
        End If

        'looks pretty dontit?
        For y = startPoint To stopPoint
            For x = 0 To maxNodesPerCollum - 1
                If Not IsNothing(nodes(y, x)) Then
                    activeNodes(count) = x + (maxNodesPerCollum * y)
                    count += 1
                End If
            Next
        Next
        count = randomNum(0, count - 1)
        returns(0) = Math.Floor(activeNodes(count) / maxNodesPerCollum)
        returns(1) = activeNodes(count) Mod maxNodesPerCollum
        Return returns
    End Function

    Public Sub createNewNodeSet()
        'inits all inputs and outputs
        'makes a random node with a link In And out
        'makes 2 other random links

        For x = 0 To maxNodesPerCollum - 1               'create the maximum # of input nodes
            nodes(0, x) = New Node(0)
        Next
        For x = 0 To 5
            nodes(4, x) = New Node(4)                    'create 6 output nodes
        Next

        makeNewNode()
        makeNewLinks(1)


    End Sub
    Public Function makeNewNode() As String
        Dim newNodeCollum As Integer = randomNum(1, 3)
        Dim newNodeSlot As Integer = getNextNodeSlot(newNodeCollum)

        If newNodeSlot <> -1 Then
            nodes(newNodeCollum, newNodeSlot) = New Node(newNodeCollum)
            nodes(newNodeCollum, newNodeSlot).makeRandomLinks(getNodeList(), 1)  'number of links per generation is here!!!!!

            Dim randomCords() As Integer = getRandomNode(0, newNodeCollum, True)
            nodes(randomCords(0), randomCords(1)).makeLinkTo(newNodeCollum, newNodeSlot)
            'god that was a pain to write. Probly going to redo it when im fresh
        End If
        If newNodeSlot <> -1 Then
            Return "(" + Str(newNodeCollum) + "," + Str(newNodeSlot) + ")"
        Else
            Return "(failed to make new node. collum " + Str(newNodeCollum) + " is full)"
        End If
    End Function

    Public Function makeNewLinks(n As Integer) As String
        Dim startPoint(2), endpoint(2) As Integer
        Dim returns As String = ""
        For x = 1 To n
            startPoint = getRandomNode(0, 4, True)
            endpoint = getRandomNode(0, startPoint(0), False)
            nodes(startPoint(0), startPoint(1)).makeLinkTo(endpoint(0), endpoint(1))
            returns += "(" + Str(startPoint(0)) + "," + Str(startPoint(1)) + ") -> (" + Str(endpoint(0)) + "," + Str(endpoint(1)) + ")  "
        Next
        Return returns
    End Function

    Public Function getNodeList() As Integer()
        Dim returns(4) As Integer
        Dim x As Integer = 0
        returns(0) = 12 'just a little optimization
        For y = 1 To 4
            Do Until x >= maxNodesPerCollum OrElse IsNothing(nodes(y, x))
                returns(y) += 1
                x += 1
            Loop
            x = 0
        Next
        Return returns
    End Function

    Public Function getNextNodeSlot(collum As Integer) As Integer
        For x = 0 To maxNodesPerCollum - 1
            If IsNothing(nodes(collum, x)) Then
                Return x
            End If
        Next
        Return -1
    End Function

    Public Sub makeAction()
        Dim max As Double
        Dim maxNode As Integer
        For x = 0 To 5
            If nodes(4, x).activity > max Then
                maxNode = x
                max = nodes(4, x).activity
            End If
        Next
        If max <> 0 Then
            'distance formula
            If maxNode < 4 Then fitness -= Math.Sqrt(Math.Pow((charX - startingX), 2) + Math.Pow((charY - startingY), 2))

            Select Case maxNode
                Case 0
                    'If move(0, 1) Then fitness += moveFitness
                    move(0, 1)
                Case 1
                    'If move(1, 0) Then fitness += moveFitness
                    move(1, 0)
                Case 2
                    'If move(0, -1) Then fitness += moveFitness
                    move(0, -1)
                Case 3
                    'If move(-1, 0) Then fitness += moveFitness
                    move(-1, 0)
                Case 4
                    If myWorld.areaEat(charX, charY) Then
                        fitness += eatFitness
                        resourcesEaten += 1
                        myResourcesEaten += 1
                    End If
                Case 5
                    If attack() Then
                        fitness += attackFitness
                        creaturesKilled += 1
                        myKills += 1
                    End If
            End Select
            wrapCordinants()
            If maxNode < 4 Then fitness += Math.Sqrt(Math.Pow((charX - startingX), 2) + Math.Pow((charY - startingY), 2))
        End If
    End Sub

    Public Sub clear()
        fitness = 0
        myWorld.setData(charX, charY, 0)
        isDead = False
        charX = randomNum(0, worldSize)
        charY = randomNum(0, worldSize)
    End Sub

    Public Sub reset()
        fitness = 0
        myWorld.setData(charX, charY, 0)
        charX = randomNum(0, worldSize)
        charY = randomNum(0, worldSize)
        myWorld.setData(charX, charY, number)
    End Sub

    Public Function attack() As Boolean
        Dim myEnemy As Creature = myWorld.getCreatureInArea(charX, charY, Me)
        If Not IsNothing(myEnemy) AndAlso myEnemy.isDead = False Then
            myWorld.setData(myEnemy.charX, myEnemy.charY, -1)
            myEnemy.isDead = True 'fucking savage
            Return True
        End If
        Return False
    End Function

    Public Function move(xMod As Integer, yMod As Integer) As Boolean
        If myWorld.isInArea(charX + xMod, charY + yMod, 0, -1) Or myWorld.isInArea(charX + xMod, charY + yMod, -1, -1) Then
            myWorld.setData(charX, charY, 0)
            charX = charX + xMod
            charY = charY + yMod
            myWorld.setData(charX, charY, number)
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub injectInputNodes()
        If myWorld.isInArea(charX, charY + 1, 0, -1) Then nodes(0, 0).activity = 1
        If myWorld.isInArea(charX + 1, charY, 0, -1) Then nodes(0, 1).activity = 1
        If myWorld.isInArea(charX, charY - 1, 0, -1) Then nodes(0, 2).activity = 1
        If myWorld.isInArea(charX - 1, charY, 0, -1) Then nodes(0, 3).activity = 1

        If myWorld.isInArea(charX, charY + 1, charX, charY + 5, -1, -1) Then nodes(0, 4).activity = 1
        If myWorld.isInArea(charX + 1, charY, charX + 5, charY, -1, -1) Then nodes(0, 5).activity = 1
        If myWorld.isInArea(charX, charY - 1, charX, charY - 5, -1, -1) Then nodes(0, 6).activity = 1
        If myWorld.isInArea(charX - 1, charY, charX - 5, charY, -1, -1) Then nodes(0, 7).activity = 1

        'loops through the nodes and ocelates them like a binary up-counter
        'For x = 8 To 11
        '    If nodes(0, x).activity = 1 Then
        '        nodes(0, x).activity = 0
        '    Else
        '        nodes(0, x).activity = 1
        '        Exit For
        '    End If
        'Next

        For x = 8 To 11
            If totalTicks Mod timeIntervals(x - 8) = 0 Then
                nodes(0, x).activity = 1
            Else
                nodes(0, 8).activity = 0
            End If
        Next

        If myWorld.isInArea(charX, charY + 1, charX, charY + 5, 1, -1) Then nodes(0, 12).activity = 1
        If myWorld.isInArea(charX + 1, charY, charX + 5, charY, 1, -1) Then nodes(0, 13).activity = 1
        If myWorld.isInArea(charX, charY - 1, charX, charY - 5, 1, -1) Then nodes(0, 14).activity = 1
        If myWorld.isInArea(charX - 1, charY, charX - 5, charY, 1, -1) Then nodes(0, 15).activity = 1
    End Sub


    Public Overloads Function compareTo(that As Creature) As Integer
        Return that.fitness - Me.fitness
    End Function
End Class

''-------------------------------------------
''Input Node Locations-----------------------
''-------------------------------------------
''0  = Location Trigger Up
''1  = Location Trigger Right
''2  = Location Trigger Down
''3  = Location Trigger Left

''4  = Food Sensor: Covers directly above and to the right
''5  = Food Sensor: Covers directly right and downward
''6  = Food Sensor: Covers down and to the left
''7  = Food Sensor: Covers left and upwards

''8  = Ocilating Signal: uses timeInterval(0)
''9  = Ocilating Signal: uses timeInterval(1)
''10 = Ocilating Signal: uses timeInterval(2)
''11 = Ocilating Signal: uses timeInterval(3)

''12 = Enemy Sensor: same layout as food sensors
''13 = Enemy Sensor: ^^
''14 = Enemy Sensor: ^^
''15 = Enemy Sensor: ^^






''------------------------------------------
''Output Node Locations---------------------
''------------------------------------------
''0  = Movement up
''1  = Movement right
''2  = Movement down
''3  = Movement left
''4  = Eat vicinity                 (diagonals included)
''5  = Attack immediate vicinity    (diagonals included)
