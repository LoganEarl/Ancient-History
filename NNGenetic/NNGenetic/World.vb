Public Class World
    Private worldData(,) As Integer
    'positives indicate a creature number (0 exclusive. subtract 1)
    ' 0  = empty
    '-1 = resouce
    '-2 = wall

    Public Sub New(resourceScarcity As Double, numWalls As Integer)
        ReDim worldData(worldSize, worldSize)
        placeResources(resourceScarcity)
        placeWalls(numWalls)
    End Sub

    Public Sub placeWalls(numWalls As Integer)

        For z = 1 To numWalls
            Dim xMod As Integer = randomNum(-1, 1)
            Dim yMod As Integer = randomNum(-1, 1)
            Dim x As Integer = randomNum(0, worldSize)
            Dim y As Integer = randomNum(0, worldSize)
            Dim wallLen As Integer = randomNum(0, worldSize)
            For n = 0 To wallLen
                worldData(fc(x), fc(y)) = -2
                x += xMod
                y += yMod
            Next
        Next
    End Sub

    Public Sub setData(x As Integer, y As Integer, state As Integer)
        worldData(fc(x), fc(y)) = state
    End Sub

    Public Sub placeResources(n As Integer)
        For x = 1 To n
            worldData(randomNum(0, worldSize - 1), randomNum(0, worldSize - 1)) = -1
        Next
    End Sub

    Public Function getCreature(x As Integer, y As Integer) As Creature
        If worldData(fc(x), fc(y)) > 0 Then
            Return creatures(worldData(fc(x), fc(y)) - 1)
        End If
        Return Nothing
    End Function

    Public Function getRawWorldData(x As Integer, y As Integer)
        Return worldData(fc(x), fc(y))
    End Function

    Public Function isInArea(x As Integer, y As Integer, item As Integer, exclude As Integer) As Boolean
        If item = 1 Then
            If worldData(fc(x), fc(y)) > 0 And worldData(fc(x), fc(y)) <> exclude Then Return True
        Else
            If worldData(fc(x), fc(y)) = item Then Return True
        End If
        Return False
    End Function

    Public Function areaEat(x As Integer, y As Integer) As Boolean
        For county = y - 1 To y + 1
            For countx = x - 1 To x + 1
                If worldData(fc(countx), fc(county)) = -1 Then
                    worldData(fc(countx), fc(county)) = 0
                    Return True
                End If
            Next
        Next
        Return False
    End Function

    Public Function getCreatureInArea(x As Integer, y As Integer, source As Creature) As Creature
        'returns the first creature in attack range
        For county = y - 1 To y + 1
            For countx = x - 1 To x + 1
                If worldData(fc(countx), fc(county)) > 0 And (worldData(fc(countx), fc(county)) <> source.number) Then
                    Return creatures(worldData(fc(countx), fc(county)))
                End If
            Next
        Next
        Return Nothing
    End Function

    Public Function isInArea(xA As Integer, yA As Integer, xP As Integer, yP As Integer, item As Integer, exclude As Integer) As Boolean
        'pass 1 for creature, the number for anything else
        'exclude is a creature number you dont want to be counted, -1 for no exclusion

        For y = yA To yP
            For x = xA To xP
                If item = 1 Then
                    If worldData(fc(x), fc(y)) > 0 And worldData(fc(x), fc(y)) <> exclude Then Return True
                Else
                    If worldData(fc(x), fc(y)) = item Then Return True
                End If
            Next
        Next
        Return False
    End Function

    Public Function getColor(x As Integer, y As Integer) As Color
        If worldData(fc(x), fc(y)) > 0 Then Return getCreature(x, y).color
        Select Case worldData(fc(x), fc(y))
            Case 0
                Return Color.White
            Case -1
                Return Color.LightPink
            Case -2
                Return Color.RosyBrown
        End Select
    End Function

    Public Function fc(cord As Integer) As Integer 'fix cordinate. short name bc i will have to type it out a lot
        If cord > worldSize - 1 Then
            cord -= worldSize
        ElseIf cord < 0 Then
            cord += worldSize
        End If
        Return cord
    End Function

    Public Sub refreshData()
        For y = 0 To worldSize
            For x = 0 To worldSize
                If worldData(x, y) > 0 Then worldData(x, y) = 0
            Next
        Next
        For Each member In creatures
            worldData(member.charX, member.charY) = member.number
        Next
    End Sub
End Class
