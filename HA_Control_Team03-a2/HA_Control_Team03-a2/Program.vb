Imports System

Module Program
    Sub Main(args As String())
        Dim i As Integer
        Dim persons As Integer = 1000
        Dim k As Integer = 7
        Dim lastPersons As Integer

        Do While persons >= 3

            Dim person As String = CStr(persons Mod 7)

            i += 1
            persons -= 7
        Loop

        Console.WriteLine("Benötigte Iterationen: " & CStr(i))


    End Sub

    End Function
End Module
