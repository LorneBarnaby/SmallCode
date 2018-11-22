Module StandardAlgorithm


    ''' <summary>
    ''' findMin : finds the lowest value in an array
    ''' </summary>
    ''' <param name="arr">array of integers</param>
    ''' <returns>lowest integer in the array. If array is empyt returns False</returns>
    ''' <remarks></remarks>
    Function findMin(ByRef arr() As Integer)
        If arr.Length > 0 Then
            Dim minimum As Integer = arr(0)
            For i As Integer = 1 To arr.Length - 1
                If arr(i) < minimum Then
                    minimum = arr(i)
                End If
            Next
            Return minimum
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' findMax : finds the largest value in an array
    ''' </summary>
    ''' <param name="arr">array of integers</param>
    ''' <returns>highest integer in the array. If array is empyt returns False</returns>
    ''' <remarks></remarks>
    Function findMax(ByRef arr() As Integer)
        If arr.Length > 0 Then
            Dim maximum As Integer = arr(0)
            For i As Integer = 1 To arr.Length - 1
                If arr(i) > maximum Then
                    maximum = arr(i)
                End If
            Next
            Return maximum
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' linearSearch : determines wether or not a target value is in an array
    ''' </summary>
    ''' <param name="arr">array of integers </param>
    ''' <param name="target">target to be found in the array</param>
    ''' <returns>Boolean, True if found, False if not</returns>
    ''' <remarks></remarks>
    Function linearSearch(ByRef arr() As Integer, target As Integer)
        For Each value As Integer In arr
            If value = target Then
                Return True
            End If
        Next
        Return False
    End Function

    ''' <summary>
    ''' countOccurances : counts how many times a value is in an array
    ''' </summary>
    ''' <param name="arr">array of integer </param>
    ''' <param name="target"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function countOccurences(arr() As Integer, target As Integer)
        Dim hits As Integer = 0
        For Each value As Integer In arr
            If value = target Then
                hits += 1
            End If
        Next
        Return hits
    End Function

    Function BinarySearch(ByRef arr() As Integer, target As Integer)
        Dim endArr As Integer = arr.Length - 1
        Dim startArr As Integer = 0
        Dim found As Boolean
        Dim pos As Integer = -1
        Do
            Dim middle As Integer = (endArr + startArr) / 2
            If arr(middle) = target Then
                found = True
                pos = middle
            ElseIf arr(middle) > target Then
                endArr = middle - 1
            Else
                startArr = middle + 1
            End If
        Loop Until startArr > endArr Or found = True
        Return pos
    End Function


    Function mean(ByRef arr() As Integer)
        Dim total As Integer = 0
        For Each value As Integer In arr
            total += value
        Next
        Dim average As Integer = total / arr.Length
        Return average
    End Function

    Function mode(ByRef arr() As Integer)
        Dim occurances As New Dictionary(Of String, Integer)
        For Each value As Integer In arr
            If occurances.ContainsKey(value.ToString()) Then
                occurances.Item(value.ToString()) += 1
            Else
                occurances.Add(value.ToString(), 1)
            End If
        Next
        Dim max As Integer = occurances(occurances.Keys(0))
        Dim k As String
        For Each key As String In occurances.Keys
            If occurances.Item(key) > max Then
                max = occurances.Item(key)
                k = key
            End If
        Next
        Return Convert.ToInt32(k)
    End Function

    Function median(arr() As Integer)
        Dim middle As Integer = arr.Length / 2
        If arr.Length Mod 2 = 0 Then 'length of array is even 
            Return (arr(middle) + arr(middle - 1)) / 2
        Else
            Return arr(middle)
        End If
    End Function
End Module
