Module GlobalVars
    Public generations() As Generation
    Public worldSize = 100
    Public numCreatures As Integer = 100
    Public creatures() As Creature
    Public myWorld As World
    Public moveFitness As Integer = 1
    Public eatFitness As Integer = 60
    Public attackFitness As Integer = 70
    Public ticksPerGeneration As Integer = 500
    Public numWalls As Integer = 10
    Public resourceDensity As Integer = 150
    Public maxNodesPerCollum = 16
    Public worldGeneration As Integer = 1
    Public totalTicks As ULong = 0
    Public resourcesEaten As Integer = 0
    Public creaturesKilled As Integer = 0
    Public totalCreaturesMade As Integer = 1
    Public globalSelectedCreature As Creature
End Module
