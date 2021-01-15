Option Strict On

Imports System

Module Program
    Sub Main(args As String())
        Dim t As New List(Of Medikament)
        Dim medikament1 As FreiesMedikament = New FreiesMedikament(42.4323, "11A1F", 1)
        Dim medikament2 As VerschreibungspflichtigesMedikament = New VerschreibungspflichtigesMedikament(634.3121, "4234F", False)
        Dim medikament3 As VerschreibungspflichtigesMedikament = New VerschreibungspflichtigesMedikament(13.132, "333FFF", False)

        medikament1.erh�heBestand(5)
        medikament1.erh�heBestand() 'erh�he Bestand auch wenn 0 oder nichts �bergeben wird
        medikament2.erh�heBestand(1)
        medikament3.erh�heBestand(9)

        'Bestand ist immer 0 in diesem Konstrukt und muss mittels der Funktion erh�ht werden
        'Man h�tte nat�rlich das ganze auch in dem Konstruktor �bergeben k�nnen

        Dim warenkorb As New Warenkorb()

        warenkorb.Add(medikament1)
        warenkorb.Add(medikament2)
        warenkorb.Add(medikament3)

        Console.WriteLine(warenkorb.berechneZuzahlung())
        Console.WriteLine(warenkorb.pr�feBestand())
        Console.WriteLine(warenkorb.ben�tigtRezept())
        Console.WriteLine(warenkorb.ben�tigtFacharzt())

    End Sub


End Module
