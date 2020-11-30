Imports System

Module Program
    Sub Main(args As String())

        Dim input As String

        Do

            Dim i, j As Integer
            i = 0
            j = 0
            Dim countPersons, remainingPersons, steps As Integer

            While True
                Console.WriteLine("Bitte geben Sie die Gesamtanzahl der Personen ein:")
                Dim inp As String = Console.ReadLine()

                If (Int32.TryParse(inp, countPersons)) Then
                    Exit While
                End If
            End While

            While True
                Console.WriteLine("Bitte geben Sie die Anzahl der zu verbleibenden Personen ein")
                Dim inp As String = Console.ReadLine()

                If (Int32.TryParse(inp, remainingPersons)) Then
                    Exit While
                End If
            End While

            While True
                Console.WriteLine("Bitte geben Sie den Abstand der Personen untereinander ein:")
                Dim inp As String = Console.ReadLine()
                If (Int32.TryParse(inp, steps)) Then
                    Exit While
                End If
            End While

            Dim persons = Enumerable.Range(1, countPersons).ToList()

            While persons.Count > remainingPersons
                i = (i + steps - 1) Mod persons.Count
                persons.RemoveAt(i)
                If i < steps - 1 Then
                    j += 1
                End If
            End While

            Console.WriteLine("Zum Schluss stehende Personen:")
            For Each person In persons
                Console.WriteLine(person)
            Next person
            Console.WriteLine("Benötigte Iterationen")
            Console.WriteLine(j)

            Console.WriteLine("Für einen Neustart, geben Sie bitte 'restart' ein.")
            input = Console.ReadLine()
        Loop Until Input <> "restart"
    End Sub
End Module
