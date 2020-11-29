Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Structure User

        Dim firstName, lastName, fullName, street, streetNumber, postcode, town As String
        Dim birthday As Date
        Dim age As Integer
        Dim legalAge As Boolean

    End Structure

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles getData.Click

        Dim user As User = New User()

        user.firstName = Interaction.InputBox("Vorname")
        user.lastName = Interaction.InputBox("Nachname")
        user.fullName = user.firstName + " " + user.lastName

        user.street = Interaction.InputBox("Straße")
        user.streetNumber = Interaction.InputBox("Hausnummer")
        user.postcode = Interaction.InputBox("PLZ")
        user.town = Interaction.InputBox("Ort")
        user.birthday = Convert.ToDateTime(Interaction.InputBox("Geburtstag"))

        user.age = GetCurrentAge(user.birthday)
        user.legalAge = user.age >= 18

        Dim dayOfYear As String = New Date(user.birthday.Year, user.birthday.Month, user.birthday.Day).DayOfYear().ToString

        'fills all labels with the nessecary strings
        Label1.Text = user.fullName + " ist am " + user.birthday.ToString("dd.MM.yyy") + ", dem " + dayOfYear + ". Tag des Jahres geboren und ist " + user.age.ToString() + " alt."
        Label2.Text = "Die Person hat folgende Adresse:"
        Label3.Text = user.street + " " + user.streetNumber
        Label4.Text = user.postcode + " " + user.town
        Label5.Text = "volljährig: " + user.legalAge.ToString

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    'returns the current age from the users birthday
    Public Function GetCurrentAge(ByVal birthday As Date) As Integer
        Dim age As Integer
        age = Today.Year - birthday.Year
        If (birthday > Today.AddYears(-age)) Then age -= 1
        Return age
    End Function

End Class
