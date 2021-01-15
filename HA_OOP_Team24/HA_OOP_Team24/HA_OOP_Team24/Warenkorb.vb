Public Class Warenkorb
    Inherits List(Of Medikament)

    Public Function berechneZuzahlung() As Double
        Dim summe As Double = 0

        For Each medikament As Medikament In Me  'Rechnet hier alle Zuzahlung für die Medikamente im Warnekorb auf
            summe += medikament.Zuzahlung
        Next

        Return Math.Round(summe, 2)
    End Function

    Public Function prüfeBestand() As Boolean

        Dim bestandIstGedeckt = True

        For Each medikament As Medikament In Me     'Prüft über alle Medikamente im Korb, ob jedes Medikament mindestens 1x vorhanden ist
            If medikament.Bestand = 0 Then
                bestandIstGedeckt = False

                Exit For
            End If
        Next

        Return bestandIstGedeckt
    End Function

    Public Function benötigtRezept() As Boolean

        For Each medikament As Medikament In Me                                'Prüft über alle Medikamente im Korb, ob ein
            If TypeOf medikament Is VerschreibungspflichtigesMedikament Then   ' verschreibungspflichtiges Medikament vorhanden sit
                Return True
            End If
        Next

        Return False
    End Function
    Public Function benötigtFacharzt() As Boolean

        For Each medikament As Medikament In Me                                'Prüft über alle Medikamente im Korb, ob ein
            If TypeOf medikament Is VerschreibungspflichtigesMedikament Then   ' verschreibungspflichtiges Medikament vorhanden sit

                If medikament.benötigtFacharzt() Then
                    Return True
                End If
            End If
        Next

        Return False
    End Function
End Class
