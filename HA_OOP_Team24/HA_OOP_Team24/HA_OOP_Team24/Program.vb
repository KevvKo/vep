Option Strict On

Imports System

Module Program
    Sub Main(args As String())
        Dim t As New List(Of Medikament)
        Dim medikament1 As FreiesMedikament = New FreiesMedikament(42.4323, "11A1F", 1)
        Dim medikament2 As VerschreibungspflichtigesMedikament = New VerschreibungspflichtigesMedikament(634.3121, "4234F", False)
        Dim medikament3 As VerschreibungspflichtigesMedikament = New VerschreibungspflichtigesMedikament(13.132, "333FFF", False)

        medikament1.erhöheBestand(5)
        medikament1.erhöheBestand() 'erhöhe Bestand auch wenn 0 oder nichts übergeben wird
        medikament2.erhöheBestand(1)
        medikament3.erhöheBestand(9)

        'Bestand ist immer 0 in diesem Konstrukt und muss mittels der Funktion erhöht werden
        'Man hätte natürlich das ganze auch in dem Konstruktor übergeben können

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
