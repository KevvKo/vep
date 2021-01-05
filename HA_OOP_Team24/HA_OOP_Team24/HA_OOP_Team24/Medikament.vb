Public Class Medikament
    Public Zuzahlung As Double
    Public MedikamentenID As String

    Public Sub New(Zuzahlung As Double, MedikamentenID As String)

        Me.Zuzahlung = Math.Round(Zuzahlung, 2)

        If Me.isHexadecimal(MedikamentenID) Then
            Me.MedikamentenID = MedikamentenID
        End If

    End Sub

    Private Function isHexadecimal(value As String) As Boolean

        Dim letters = New String() {"A", "B", "C", "D", "F"}
        Dim numbers = New String() {"10", "11", "12", "13", "14", "15"}
        value = value.ToUpper()

        For i As Integer = 0 To 6

            If value.Contains(letters(i)) Then
                value = value.Replace(letters(i), numbers(i))
            End If
            Console.WriteLine(value)
            Return IsNumeric(value)
        Next

    End Function
End Class
