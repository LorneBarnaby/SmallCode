Module Caesar
    Class Cipher
        Function encodeCaesar(s As String, shift As Integer)
            s = UCase(s)
            Dim encoded As String = ""
            Dim alpha() As Char = alphabet()
            For Each c As Char In s
                Dim code As UInt16 = Asc(c)
                Dim index As Integer = ((code - 65) + shift) Mod 26
                encoded += alpha(index)
            Next
            Return encoded
        End Function

        Function decodeCaesar(s As String, shift As Integer)
            Dim alp() As Char = alphabet()
            Dim decoded As String = ""
            s = UCase(s)
            For Each c As Char In s
                Dim code As UInt16 = Asc(c)
                Dim index As Integer = ((code + 90) - shift + 1) Mod 26
                MsgBox(index)
                decoded += alp(index)
            Next
            Return decoded
        End Function

        Function alphabet()
            Dim alp(25) As Char
            For i As Integer = 65 To 90
                alp(i - 65) = Chr(i)
            Next
            Return alp
        End Function
    End Class
End Module
