''' <summary>
''' A Module for the Binary Search Tree data structure
''' </summary>
Module BinarySearchTree

    Class Node
        Public data As Integer 'data to be stored in the node
        Public left As Node 'node to the left of this node
        Public right As Node 'node to the right of this node

        ''' <summary>
        ''' Initialse <code>Node</code>
        ''' </summary>
        ''' <param name="d">data to be stored at this node</param>
        Sub New(d As Integer)
            data = d
        End Sub
    End Class

    Class Tree

        ''' <summary>
        ''' Adds a node to the binary search tree
        ''' </summary>
        ''' <param name="root">the root node for the new node to be added to</param>
        ''' <param name="node">the new node to be added</param>
        Sub add(root As Node, node As Node)
            If root Is Nothing Then
                root = node
            Else
                If root.data < node.data Then
                    If root.right Is Nothing Then
                        root.right = node
                    Else
                        add(root.right, node)
                    End If
                Else
                    If root.left Is Nothing Then
                        root.left = node
                    Else
                        add(root.left, node)
                    End If
                End If
            End If
        End Sub

        ''' <summary>
        ''' Outputs the binary search tree in ascending order
        ''' </summary>
        ''' <param name="root">the tree to output</param>
        Sub output(root As Node)
            If (root Is Nothing) = False Then
                output(root.left)
                Console.WriteLine(root.data)
                output(root.right)
            End If
        End Sub
    End Class
End Module
