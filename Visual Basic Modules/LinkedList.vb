Module LinkedList


    Class Node
        Public data As Integer ' data to be stred at Node
        Public nextNode As Node ' Next node in the linked list 

        ''' <summary>
        ''' INitialises the Node object
        ''' </summary>
        ''' <param name="d">data to be stored</param>
        Sub New(d As Integer)
            data = d
        End Sub
    End Class

    Class LinkedList
        Public head As Node ' head or start of linked list

        ''' <summary>
        ''' initialises LinkedList class
        ''' </summary>
        Sub New()
            head = Nothing
        End Sub

        ''' <summary>
        ''' adds a value to the start of the linked list
        ''' </summary>
        ''' <param name="data">data to be added</param>
        Sub push(data As Integer)
            Dim newNode As New Node(data)
            newNode.nextNode = head
            head = newNode
        End Sub

        ''' <summary>
        ''' Inserts value into a linked list
        ''' </summary>
        ''' <param name="previous">the value to be inserted after</param>
        ''' <param name="newDat">the value to be inserted</param>
        Sub insertAfter(previous As Node, newDat As Integer)
            If (previous Is Nothing) = False Then
                Dim newNode As Node = New Node(newDat)
                newNode.nextNode = previous.nextNode
                previous.nextNode = newNode
            End If
        End Sub


        ''' <summary>
        ''' appends a value to the end of the linked lst
        ''' </summary>
        ''' <param name="newDat">data to be appended</param>
        Sub append(newDat As Integer)
            Dim newNode As New Node(newDat)
            If head Is Nothing Then
                head = newNode
            Else
                Dim last As Node = head
                While (last.nextNode Is Nothing) = False
                    last = last.nextNode
                End While
                last.nextNode = newNode
            End If
        End Sub

        ''' <summary>
        ''' Prints every value in order in the linked list
        ''' </summary>
        Sub printList()
            Dim temp As Node = head
            While (temp Is Nothing) = False

                Console.WriteLine(temp.data)
                temp = temp.nextNode
            End While
        End Sub
    End Class
End Module
