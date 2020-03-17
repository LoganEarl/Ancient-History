Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
<Serializable()>
Public Class Link
    Implements ICloneable
    Public weight As Double
    Public destinationX As Integer
    Public destinationY As Integer
    Public isUsed As Boolean

    'implicit is basically an unused slot for error avoidance
    Public Sub New()
        isUsed = False
    End Sub

    'makes a random weight
    Public Sub New(destinationX As Integer, destinationY As Integer)
        isUsed = True
        Me.destinationX = destinationX
        Me.destinationY = destinationY
        weight = (Int(Rnd() * 200)) / 100.0
        If weight = 0 Then weight = 0.01

    End Sub

    'same as above, but with a set weight
    Public Sub New(destinationX As Integer, destinationY As Integer, weight As Double)
        Me.destinationX = destinationX
        Me.destinationY = destinationY
        Me.weight = weight
    End Sub

    'eh, cant hurt can it?
    Public Overrides Function toString() As String
        Dim returns As String

        If isUsed Then
            returns = "Destination: " + Str(destinationX) + ", " + Str(destinationY)
            returns += vbCrLf + "Weight: " + Str(weight)
        Else
            returns = "Unused Link Slot"
        End If

        Return returns
    End Function
    Public Function Clone() As Object Implements System.ICloneable.Clone
        Dim m As New MemoryStream()
        Dim f As New BinaryFormatter()
        f.Serialize(m, Me)
        m.Seek(0, SeekOrigin.Begin)
        Return f.Deserialize(m)
    End Function
End Class
