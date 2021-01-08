Option Strict On

Imports System

Module Program
    Sub Main(args As String())
        Dim t As New List(Of Medikament)
        Dim medikament1 As FreiesMedikament = New FreiesMedikament(42.423, "1111F", 1)
        Dim medikament2 As VerschreibungspflichtigesMedikament = New VerschreibungspflichtigesMedikament(634.3121, "422HF", True)
        Dim medikament3 As VerschreibungspflichtigesMedikament = New VerschreibungspflichtigesMedikament(13.0, "333FFF", False)

        Dim warenkorb As New Warenkorb()

        warenkorb.Add(medikament1)
        warenkorb.Add(medikament2)
        warenkorb.Add(medikament3)

        Console.WriteLine(warenkorb.berechneZuzahlung())
        Console.WriteLine(warenkorb.prüfeBestand())
        Console.WriteLine(warenkorb.benötigtRezept())
        Console.WriteLine(warenkorb.benötigtFacharzt())

    End Sub


End Module
