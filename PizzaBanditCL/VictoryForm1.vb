Public Class VictoryForm1

    Public finaltime As Integer = Mainform.seconds



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub Quit_Click(sender As Object, e As EventArgs) Handles QuitButton.Click
        quit = True
        Me.Hide()
    End Sub




    Private Sub VictoryForm1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.clocktime.Text = finaltime.ToString
    End Sub
End Class