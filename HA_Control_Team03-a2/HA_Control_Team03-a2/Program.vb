Imports System

Module Program
    Sub Main(args As String())
        Dim i As Integer = 0
        Dim remainingPersons As Integer = 3
        Dim countPersons As Integer = 1000
        Dim persons As List(Of Integer) = New List(Of Integer)()
        Dim steps As Integer = 7
        Dim stepCounter As Integer = steps
        Dim length As Integer = countPersons

        For j As Integer = 1 To countPersons
            persons.Add(j)
        Next j
        Console.WriteLine(persons.Count Mod steps)
        Do While persons.Count > remainingPersons

            persons.Remove(stepCounter)
            stepCounter += steps

            If (stepCounter = (length - (length Mod steps))) Then
                Console.WriteLine(persons.Count)
                stepCounter = steps - (length Mod steps)
                length = persons.Count
                i += 1
            End If

        Loop

        Console.WriteLine("Benötigte Iterationen: " & CStr(i))


    End Sub
End Module
