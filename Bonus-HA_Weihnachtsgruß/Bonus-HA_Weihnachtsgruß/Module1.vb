
Module Module1
    Sub Main()
        '<--- Benutzte Musik: ---> 
        '----------------------------------------------------------------------------------------------------------------------------------------------------
        'Carol Of The Bells von Audionautix unterliegt der Lizenz Creative-Commons-Lizenz "Namensnennung 4.0". https://creativecommons.org/licenses/by/4.0/
        'Künstler: http : //audionautix.com/
        '----------------------------------------------------------------------------------------------------------------------------------------------------
        'Jingle Bells 7 von Kevin MacLeod unterliegt der Lizenz Creative-Commons-Lizenz "Namensnennung 4.0". https: //creativecommons.org/licenses/by/4.0/
        'Künstler: http : //incompetech.com/
        '----------------------------------------------------------------------------------------------------------------------------------------------------
        Dim receiver As String

        '<--- Programm ---> 
        '1. Eingabe
        Console.Write("Empfänger: ")
        receiver = Console.ReadLine()
        Console.WriteLine(vbCrLf & "Liebe/r " + receiver + ",")
        Console.WriteLine("Ich wünsche dir ein Frohes Weihnachtsfest und das du gesund und munter bleibst. :)" & vbCrLf)
        Console.WriteLine("Weihnachtliche Grüße")
        Console.WriteLine("Der Student" & vbCrLf)

        '2. Richtigen Sound abspielen
        If Weihnachtsmuffel.Contains(receiver) Then
            My.Computer.Audio.Play(My.Resources.Jingle_Bells___Kevin_MacLeod, AudioPlayMode.BackgroundLoop)
        Else
            My.Computer.Audio.Play(My.Resources.Carol_Of_The_Bells___Audionautix, AudioPlayMode.BackgroundLoop)
        End If

        Console.ForegroundColor = ConsoleColor.Yellow

        'Der Stern :)
        Console.WriteLine("      /\")
        Console.WriteLine("_____/  \_____")
        Console.WriteLine("\            /")
        Console.WriteLine(" >          <")
        Console.WriteLine("/____    ____\")
        Console.WriteLine("     \  /")
        Console.WriteLine("      \/" & vbCrLf)

        getXMasTree(3, 7)

        '3. Console mit buntem Text voll ballern; auch getXMasTree() aufrufen

        '4. Auf Beendigung warten
        Console.ReadKey()
    End Sub

    ' Funktion für Weihnachtsbaum
    ' Ich habe die Parameter den Parameter Breite nicht verwendet, da man ja auch ganz einfach mit dem Paramater höheNadelwerk 
    ' schöne gleichmäßige Weihnachtsbäume erhalten kann. :)
    Function getXMasTree(höheStamm%, höheNadelwerk%) As String

        Dim OuterDistance As Integer = höheNadelwerk + 1
        Dim OuterWhiteSpace As String = StrDup(OuterDistance, " ")
        Dim InnerDistance As Integer = 1
        Dim InnerWhiteSpace As String = " "

        'Prüfe ob der Baum auch groß genug werden kann (kleiner 3 Nadelhöhe wäre kein schöner Baum)
        If höheNadelwerk < 3 Then
            Exit Function
        End If

        'Gebe die Baumkrone aus
        For i As Integer = 0 To höheNadelwerk - 1

            'Gebe die Spitze aus ( Zeile 1-2)
            If (i = 0) Then

                Console.ForegroundColor = ConsoleColor.Green

                OuterDistance -= 1
                OuterWhiteSpace = StrDup(OuterDistance, " ")
                Console.WriteLine(OuterWhiteSpace + "^")

                OuterDistance -= 1
                OuterWhiteSpace = StrDup(OuterDistance, " ")
                Console.WriteLine(OuterWhiteSpace + "-" + InnerWhiteSpace + "-")

                Continue For
            End If

            OuterDistance -= 1

            'Standardausgabe für einen Baumkronenzeile und dem äußeren Rand :)
            If OuterDistance >= 0 Then
                OuterWhiteSpace = StrDup(OuterDistance, " ")
            End If

            InnerDistance += 2
            InnerWhiteSpace = StrDup(InnerDistance, " ")


            'Gebe letzte Zeile wieder der Baumkrone
            If i = höheNadelwerk - 1 Then
                Console.WriteLine("<" + StrDup((höheNadelwerk * 2) - 1, "_") + ">")
                Exit For
            End If

            Console.WriteLine(OuterWhiteSpace + "<" + InnerWhiteSpace + ">")
        Next


        'Und jetzt nochmal äußere Distanz für den Baumstamm neu berechnen
        OuterDistance = ((höheNadelwerk * 2) - 1) / 2
        OuterWhiteSpace = StrDup(OuterDistance, " ")

        Console.ForegroundColor = ConsoleColor.DarkRed

        'Gebe den Stamm aus
        For i = 0 To höheStamm - 1

            If i = höheStamm - 1 Then
                Console.WriteLine(OuterWhiteSpace + "|_|")
            Else
                Console.WriteLine(OuterWhiteSpace + "| |")
            End If

        Next

    End Function

End Module
