Option Strict On
Public MustInherit Class Medikament
    Protected _Bestand As Integer
    Protected _Zuzahlung As Double
    Protected _MedikamentenID As String
    Public Sub New(Zuzahlung As Double, MedikamentenID As String)

        _Bestand = 0
        _Zuzahlung = Math.Round(Zuzahlung, 2)

        If isHexadecimal(MedikamentenID) Then
            _MedikamentenID = MedikamentenID
        End If

    End Sub

    Public Property Zuzahlung() As Double

        Get
            Return _Zuzahlung
        End Get

        Set(value As Double)
            _Zuzahlung = Math.Round(value, 2)
        End Set
    End Property

    Public Property MedikamentenID() As String

        Get
            Return _MedikamentenID
        End Get

        Set(value As String)
            If isHexadecimal(value) Then
                _MedikamentenID = value
            End If
        End Set
    End Property

    Public ReadOnly Property Bestand() As Integer

        Get
            Return _Bestand
        End Get

    End Property

    Public Function erhöheBestand(Optional value As Integer = 0) As Integer

        If (value > 0) Then     'Wenn Bestand nicht größer 0 oder positiv ist, erhöhe den Bestand dennoch um 1
            _Bestand = _Bestand + value
        Else
            _Bestand = _Bestand + 1
        End If
    End Function

    Public Function entnehmeBestand(value As Integer) As Integer

        If value > Bestand Then
            _Bestand -= _Bestand  'Falls zu entnehmende Menge größer als der Bestand ist, reduziere den Bestand um sich selbst_
        Else
            _Bestand -= value
        End If
    End Function

    'Prüft, ob ein gegebener String Hexadezimal ist
    Public Shared Function isHexadecimal(value As String) As Boolean

        Dim letters = New String() {"A", "B", "C", "D", "F"}
        Dim numbers = New String() {"10", "11", "12", "13", "14", "15"}
        value = value.ToUpper()

        For i As Integer = 0 To 6

            If value.Contains(letters(i)) Then
                value = value.Replace(letters(i), numbers(i))
            End If

            Return IsNumeric(value)
        Next

    End Function

    Public MustOverride Function benötigtFacharzt() As Boolean
End Class

Public Class FreiesMedikament
    Inherits Medikament

    Protected medikamentenTyp As Integer
    Public Enum Typ
        Homöopathisch
        Naturheilmittel
        Schulmedizinisch
    End Enum

    Public Sub New(Zuzahlung As Double, MedikamentenID As String, Typ As Integer)
        MyBase.New(Zuzahlung, MedikamentenID)

        medikamentenTyp = Typ

    End Sub

    Public Function getMedikamententyp() As String

        Select Case medikamentenTyp
            Case 0
                Console.WriteLine("homöopathisches Medikament zum freien Verkauf")
            Case 1
                Console.WriteLine("Naturheilmittel zum freien Verkauf")
            Case 2
                Console.WriteLine("schulmedizinisches Medikament zum freien Verkauf")
            Case Else
                Console.WriteLine("Kein bekannter Medikamententyp")
        End Select

    End Function

     Public Overrides Function benötigtFacharzt() As Boolean
        Return False
    End Function
End Class

Public Class VerschreibungspflichtigesMedikament
    Inherits Medikament

    Protected _Facharzt As Boolean
    Public Sub New(Zuzahlung As Double, MedikamentenID As String, Facharzt As Boolean)
        MyBase.New(Zuzahlung, MedikamentenID)

        _Facharzt = Facharzt
    End Sub

    Public ReadOnly Property Facharzt() As Boolean

        Get
            Return _Facharzt
        End Get
    End Property
    Public Overrides Function benötigtFacharzt() As Boolean
        Return _Facharzt
    End Function
End Class

Public Class Warenkorb
    Inherits List(Of Medikament)

    Public Function berechneZuzahlung() As Double
        Dim summe As Double = 0

        For Each medikament As Medikament In Me  'Rechnet hier alle Zuzahlung für die Medikamente im Warnekorb auf
            summe += medikament.Zuzahlung
        Next

        Return summe
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