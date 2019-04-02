Public Class Form3
    Private Sub btnStartOver_Click(sender As Object, e As EventArgs) Handles btnStartOver.Click
        Application.Restart()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub
End Class