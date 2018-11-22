Module Prims

    ''' <summary>
    ''' Builds the grid with prims
    ''' </summary>
    ''' <param name="wid">width of the grid to return </param>
    ''' <param name="hid">hieght of the grid to return</param>
    ''' <returns>a grid that has had prims algorithm run on it</returns>
    Public Function Build(wid As Integer, hid As Integer) As Grid
        Dim myGrid As Grid = New Grid(wid, hid)
        myGrid.fillWithWalls()

        Randomize()
        Dim randomX As Integer = Rnd() * myGrid.Height
        Dim randomY As Integer = Rnd() * myGrid.Width

        myGrid.Cells(randomX, randomY).makePath()
        Dim n As List(Of Cell) = myGrid.getNeighboursOfCell(myGrid.Cells(randomX, randomY))

        For Each c As Cell In n
            myGrid.Walls.Add(c)
        Next

        While myGrid.Walls.Count > 0
            Dim thisWall As Cell = myGrid.getRandomWall()

            If thisWall.DividesHowMany(myGrid.Cells) = 1 Then
                myGrid.Cells(thisWall.X, thisWall.Y).makePath()
                Dim walls As List(Of Cell) = myGrid.getNeighboursOfCell(myGrid.Cells(thisWall.X, thisWall.Y))

                For Each c As Cell In walls
                    myGrid.Walls.Add(c)
                Next
            End If

            myGrid.Walls.Remove(thisWall)
        End While
        myGrid.getPaths()
        Return myGrid
    End Function

    Class Cell
        Public X As Integer
        Public Y As Integer
        Public isWall As Boolean

        Public Sub New(x As Integer, y As Integer)
            Me.X = x : Me.Y = y
        End Sub

        Sub makeWall() 'makes cell a wall
            Me.isWall = True
        End Sub

        Sub makePath() 'makes cell a path
            Me.isWall = False
        End Sub

        ''' <summary>
        ''' calculates how many paths a wall divides
        ''' </summary>
        ''' <param name="cellsList">list of cells to use for calculation of divisions</param>
        ''' <returns>an numeric value for how many paths the cell divides</returns>
        Function DividesHowMany(ByRef cellsList As Cell(,)) As Integer
            Dim posistions() As Cell = {New Cell(Me.X, Me.Y + 1), New Cell(Me.X, Me.Y - 1), New Cell(Me.X + 1, Me.Y), New Cell(Me.X - 1, Me.Y)}
            Dim count As Integer = 0
            For Each c As Cell In posistions
                Try
                    If cellsList(c.X, c.Y).isWall = False Then
                        count += 1
                    End If
                Catch e As Exception
                End Try
            Next
            Return count
        End Function
    End Class

    Class Grid
        Public Width As Integer
        Public Height As Integer
        Public Cells(,) As Cell
        Public Walls As New List(Of Cell)
        Public legitPaths As New List(Of Cell)

        Public Sub New(width As Integer, height As Integer)
            Me.Width = width : Me.Height = height
            ReDim Cells(height, width)
        End Sub

        ''' <summary>
        ''' fills cells array with cells that are walls
        ''' </summary>
        Public Sub fillWithWalls()
            For i As Integer = 0 To Height
                For j As Integer = 0 To Width
                    Cells(i, j) = New Cell(i, j)
                    Cells(i, j).makeWall()
                Next
            Next
        End Sub

        ''' <summary>
        ''' gets a random wall from the walls list
        ''' </summary>
        ''' <returns>returns the random cell</returns>
        Function getRandomWall() As Cell
            Randomize()
            Dim index As Integer = Rnd() * (Walls.Count - 1)
            Return Walls(index)
        End Function

        ''' <summary>
        ''' gets the neighbours of a cell
        ''' </summary>
        ''' <param name="c">cell to get neighbours of</param>
        ''' <returns>a list of the cells which neighbour cell <c>c</c></returns>
        Function getNeighboursOfCell(c As Cell) As List(Of Cell)
            Dim n As New List(Of Cell)
            Dim posistions() As Cell = {New Cell(c.X, c.Y + 1), New Cell(c.X, c.Y - 1), New Cell(c.X + 1, c.Y), New Cell(c.X - 1, c.Y)}

            For Each p As Cell In posistions
                Try
                    n.Add(Cells(p.X, p.Y))
                Catch ex As Exception
                End Try
            Next
            Return n
        End Function

        ''' <summary>
        ''' adds all the paths in the grid to the paths list
        ''' </summary>
        Sub getPaths()
            For i As Integer = 0 To Height
                For j As Integer = 0 To Width
                    If Cells(i, j).isWall = False Then
                        legitPaths.Add(Cells(i, j))
                    End If
                Next
            Next
        End Sub


        Function getRandomPath()
            Randomize()
            Dim index As Integer = Rnd() * (legitPaths.Count - 1)
            Return legitPaths(index)
        End Function

        ''' <summary>
        ''' Creates a text rendition of the grid with 1's and 0's
        ''' </summary>
        ''' <returns>string containing grid as text</returns>
        Function textify() As String
            Dim s As String = ""
            For i As Integer = 0 To Height
                For j As Integer = 0 To Width

                    If Cells(i, j).isWall Then
                        s += "1"
                    Else
                        s += "0"
                    End If
                Next
                s += vbCrLf
            Next
            Return s
        End Function
    End Class

End Module
