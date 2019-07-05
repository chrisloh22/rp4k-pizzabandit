Public Class GameOverForm1

    Private Sub GameOverForm1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown



        If e.KeyCode = Keys.Enter Then
            Me.Hide()
        End If
    End Sub

    Private Sub GameOverForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub Quit_Click(sender As Object, e As EventArgs) Handles QuitButton.Click
        quit = True
        Me.Hide()

    End Sub
End Class