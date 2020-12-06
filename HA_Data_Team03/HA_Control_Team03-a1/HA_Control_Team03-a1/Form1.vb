Public Class Form1
    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim selectedIndex As String = ComboBox1.SelectedIndex
        RichTextBox1.Text = ""

        'Switch case to check which loop variant was selected'
        Select Case selectedIndex
            Case 0

                RichTextBox1.Text &= "For ... Next: " & vbNewLine & vbNewLine
                For i As Integer = 1 To 100
                    If primenumber(i) Then
                        RichTextBox1.Text &= i & vbNewLine
                    End If
                Next i

            Case 1
                Dim i As Integer = 1
                RichTextBox1.Text &= "Do While ... Loop: " & vbNewLine & vbNewLine

                Do While i <= 100
                    If primenumber(i) Then
                        RichTextBox1.Text &= i & vbNewLine
                    End If
                    i += 1
                Loop

            Case 2
                Dim i As Integer = 1
                RichTextBox1.Text &= "Do ... Loop While: " & vbNewLine & vbNewLine
                Do
                    If primenumber(i) Then
                        RichTextBox1.Text &= i & vbNewLine
                    End If
                    i += 1
                Loop While i <= 100


            Case 3
                Dim i As Integer = 1
                RichTextBox1.Text &= "Do Until ... Loop: " & vbNewLine & vbNewLine

                Do Until i > 100
                    If primenumber(i) Then
                        RichTextBox1.Text &= i & vbNewLine
                    End If
                    i += 1
                Loop

            Case 4
                Dim i As Integer = 1
                RichTextBox1.Text &= "Do ... Loop Until: " & vbNewLine & vbNewLine

                Do
                    If primenumber(i) Then
                        RichTextBox1.Text &= i & vbNewLine
                    End If
                    i += 1
                Loop Until i > 100
        End Select
    End Sub
    'Function to check ifthe current integer is a primenumber'
    Function primenumber(x As Integer)
        Dim isPrim As Boolean = True
        For i As Integer = 2 To x
            If x Mod i = 0 And i <> x Then
                isPrim = False
                Exit For
            End If
        Next i

        Return x > 1 And isPrim


    End Function

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub
End Class
