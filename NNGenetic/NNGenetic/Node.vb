Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
<Serializable()>
Public Class Node
    Implements ICloneable
    Public activity As Double       'the activity level. 
    Public links(4) As Link         'the link objects 
    Public myCollum As Integer


    Public Sub New(myCollum As Integer)
        Me.myCollum = myCollum
    End Sub

    Public Sub activate()
        'standard sigmoid activator. 

        'activity = 1 / (1 + Math.Exp(activity + 1))
        'If activity < 0.6 Then activity = 0

    End Sub

    Public Sub makeRandomLinks(ByVal nodeList() As Integer, numLinks As Integer)
        'nodelist is an array of five numbers. Each number is the number of nodes in that collum
        'pass in a 0 for numLinks to make it random. There is no situation where making 0 links would be usefull

        Dim nodeIndex As Integer = getNodeIndex(nodeList)
        If numLinks = 0 Then numLinks = randomNum(1, 3)

        For x = 0 To numLinks - 1
            links(x) = New Link(nodeIndex, randomNum(0, nodeList(nodeIndex) - 1))
        Next

    End Sub

    Public Sub makeLinkTo(nodeX, nodeY)
        Dim x As Integer = getNextLink()
        If x <> -1 Then
            links(x) = New Link(nodeX, nodeY)
        End If
    End Sub

    Private Function getNextLink() As Integer
        For x = 0 To 4
            If IsNothing(links(x)) Then
                Return x
            End If
        Next
        Return -1
    End Function
    Public Function modRandomLink() As String
        Dim x As Integer = randomNum(0, getNextLink() - 1)
        If x = 0 Then Return "(no change, empty node)"  'we are empty. dont try to change anything
        If x < 0 Then x = randomNum(0, 2)               'if we are full, check it differently
        Dim returns As String = "(Link " + Str(x) + " changed from strength " + Str(links(x).weight) + " to "
        links(x).weight *= (1 + randomNum(-30, 30) / 100.0) '+- 10% change
        If links(x).weight > 1 Then links(x).weight = 1
        Return returns + Str(links(x).weight)
    End Function

    Private Function getNodeIndex(ByVal nodeList() As Integer) As Integer
        'returns the collum that a link should shoot for. This way we dont try to point to a node in an empty collum

        Dim total As Integer
        Dim index As Integer = myCollum + 1

        For x = myCollum + 1 To 4
            total += nodeList(x)
        Next

        total = randomNum(1, total)
        Do
            total -= nodeList(index)
            index += 1
        Loop While total > 0

        Return index - 1
    End Function

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Dim m As New MemoryStream()
        Dim f As New BinaryFormatter()
        f.Serialize(m, Me)
        m.Seek(0, SeekOrigin.Begin)
        Return f.Deserialize(m)
    End Function
End Class
