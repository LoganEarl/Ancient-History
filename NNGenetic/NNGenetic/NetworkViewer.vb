Public Class NetworkViewer
    'graphics objects
    Dim G As Graphics
    Dim BBG As Graphics
    Dim BB As Bitmap

    Private Sub NetworkViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Show()
        Focus()

        G = CreateGraphics()
        BB = New Bitmap(Width, Height)
        BBG = G

        detailCreatureView(globalSelectedCreature)
    End Sub

    Public Sub detailCreatureView(myCreature As Creature)

        Dim Pen1 = New Pen(Color.Black, 2)
        Dim myBrushes(3) As Brush

        myBrushes(0) = New SolidBrush(Color.Green)
        myBrushes(1) = New SolidBrush(Color.Blue)
        myBrushes(2) = New SolidBrush(Color.Black)
        myBrushes(3) = New SolidBrush(Color.Gold)

        For y = 0 To 4
            Dim x As Integer = 0
            Do While (x < maxNodesPerCollum - 1) AndAlso (Not IsNothing(myCreature.nodes(y, x)))
                G.DrawEllipse(Pen1, 50 * y, x * 50, 15, 15)
                'draw lines here

                x += 1
            Loop
        Next

        G = Graphics.FromImage(BB)

        BBG = CreateGraphics()
        BBG.DrawImage(BB, 0, 0, Width, Height)

        G.Clear(Color.White)

        'G.FillEllipse(Brush1, 5, 5, 10, 50)

        'Using Pen1 As New Pen(Color.Black, 10)
        '    G.DrawEllipse(Pen1, 20, 20, 200, 200)
        'End Using

        'draw tiles
        'For x = 0 To stageWidth - 1
        '    For y = 0 To stageHeight
        '        r = New Rectangle(x * tileSize, y * tileSize, tileSize, tileSize)
        '        Dim myBrush As Brush
        '        myBrush = New SolidBrush(myWorld.getColor(x + selectX, y + selectY))

        '        G.FillRectangle(myBrush, r)
        '    Next
        'Next



    End Sub
End Class