Module MazeGenerator

    ''' <summary>
    ''' Class <c>Coord</c> used to store an X value and a Y value much like a point on a graph or a 2D vector
    ''' </summary>
    Public Class Coord

        Public X As Integer : Public Y As Integer

        ''' <summary>
        ''' Sub <code>New</code> is used for initialisation
        ''' </summary>
        ''' <param name="xVal">X value of coordinate</param>
        ''' <param name="yVal">Y value of coordinate</param>
        Public Sub New(ByRef xVal As Integer, ByRef yVal As Integer)
            X = xVal : Y = yVal
        End Sub
    End Class


    ''' <summary>
    ''' Class <c>Generation</c> a class to create a maze using prims algorithm
    ''' </summary>
    Public Class Generation
        Public grid(,) As Boolean
        Private complex As Integer
        Private dense As Integer
        Private shape As Coord

        ''' <summary>
        ''' Sub <code>New</code> used to initalise te class used for maze generation
        ''' </summary>
        ''' <param name="size">Size of the square 2D array to be generated</param>
        ''' <param name="complexity">Defines how complex the maze will be, the higher the number the more complex the maze</param>
        ''' <param name="density">Defines how densly packed the maze will be</param>
        Public Sub New(size As Integer, Optional complexity As Single = 0.75, Optional density As Single = 0.75)
            Randomize()
            Me.shape = New Coord(Int(size / 2) * 2 + 1, Int(size / 2) * 2 + 1)
            Me.complex = complexity * (5 * (2 * Me.shape.X))
            Me.dense = density * (Int(Me.shape.X / 2) * Int(Me.shape.X / 2))

            ReDim grid(Me.shape.X, Me.shape.Y)
            FalseArray()

            TrueLeft()
            TrueRight()
            TrueTop()
            TrueBottom()

            For i As Integer = 0 To Me.dense

                Dim x As Integer = (Rnd() * (Int((Me.shape.X - 1) / 2) * 2))
                Dim y As Integer =  (Rnd() * (Int((Me.shape.Y - 1)/ 2) * 2))

                grid(y, x) = True

                For j As Integer = 0 To Me.complex - 1
                    Dim neighbouring As New List(Of Coord)
                    If x > 1 Then
                        neighbouring.Add(New Coord(y, x - 2))
                    End If
                    If x < shape.Y - 2 Then
                        neighbouring.Add(New Coord(y, x + 2))
                    End If

                    If y > 1 Then
                        neighbouring.Add(New Coord(y - 2, x))
                    End If
                    If y < shape.X - 2 Then
                        neighbouring.Add(New Coord(y + 2, x))
                    End If
                    If neighbouring.Count > 0 Then
                        Dim randInd As Integer = Rnd() * (neighbouring.Count - 1)
                        Dim nc As Coord = neighbouring(randInd)
                        If grid(nc.Y, nc.X) = False Then
                            grid(nc.Y, nc.X) = True
                            grid(nc.Y + Int((y - nc.Y) / 2), nc.X + Int((x - nc.X) / 2)) = True

                            x = nc.X
                            y = nc.Y
                        End If
                    End If
                Next

            Next
        End Sub

        ''' <summary>
        ''' Fills the grid array with False
        ''' </summary>
        Sub FalseArray()
            For x As Integer = 0 To Me.shape.X
                For y As Integer = 0 To Me.shape.Y
                    grid(x, y) = False
                Next
            Next
        End Sub

        ''' <summary>
        ''' Fills the left hand side of the grid v array with True - essentially building a left wall
        ''' </summary>
        Sub TrueLeft()
            For y As Integer = 0 To Me.shape.Y
                grid(y, 0) = True
            Next
        End Sub

        ''' <summary>
        ''' Fills the right hand side of the grid array with True - essentially building a right wall
        ''' </summary>
        Sub TrueRight()
            For y As Integer = 0 To Me.shape.Y
                grid(y, Me.shape.Y) = True
            Next
        End Sub

        ''' <summary>
        ''' Fills the top row of the grid array with True - essentially building a top wall
        ''' </summary>
        Sub TrueTop()
            For x As Integer = 0 To Me.shape.X
                grid(0, x) = True
            Next
        End Sub

        ''' <summary>
        ''' Fills the bottom row of the grid array with True - essentially building a bottom wall
        ''' </summary>
        Sub TrueBottom()
            For x As Integer = 0 To Me.shape.X
                grid(Me.shape.Y, x) = True
            Next
        End Sub
    End Class
End Module
