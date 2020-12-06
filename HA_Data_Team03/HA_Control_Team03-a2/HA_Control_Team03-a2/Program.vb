Imports System

Module Program
    Sub Main(args As String())

        Dim input As String

        'Loop to restart the program'
        Do

            Dim i, j As Integer
            i = 0
            j = 0
            Dim countPersons, remainingPersons, steps As Integer

            'Inputs from the user for the algorithm'

            While True
                Console.WriteLine("Bitte geben Sie die Gesamtanzahl der Personen ein:")
                Dim inp As String = Console.ReadLine()

                'Typecheck if input is an integer and larger than 1'
                If (Int32.TryParse(inp, countPersons) And inp >= 1) Then
                    Exit While
                End If
            End While

            While True
                Console.WriteLine("Bitte geben Sie die Anzahl der zu verbleibenden Personen ein")
                Dim inp As String = Console.ReadLine()

                'Typecheck if input is an integer and larger than 1'
                If (Int32.TryParse(inp, remainingPersons) And inp >= 1) Then
                    Exit While
                End If
            End While

            While True
                Console.WriteLine("Bitte geben Sie den Abstand der Personen untereinander ein:")
                Dim inp As String = Console.ReadLine()

                'Typecheck if input is an integer and larger than 1'
                If (Int32.TryParse(inp, steps) And inp >= 1) Then
                    Exit While
                End If
            End While

            'Contains all persons with a number'
            Dim persons = Enumerable.Range(1, countPersons).ToList()

            'computing the alternative josephus problem and count the iterations'
            While persons.Count > remainingPersons
                i = (i + steps - 1) Mod persons.Count
                persons.RemoveAt(i)
                If i < steps - 1 Then
                    j += 1
                End If
            End While

            'output for needed iterations and remaining persons'
            Console.WriteLine("Zum Schluss stehende Personen:")

            For Each person In persons
                Console.WriteLine(person)
            Next person

            Console.WriteLine("Benötigte Iterationen")
            Console.WriteLine(j)

            'checks, if the user should be restart the program'
            Console.WriteLine("Für einen Neustart, geben Sie bitte 'restart' ein.")
            input = Console.ReadLine()
        Loop Until Input <> "restart"
    End Sub
End Module
