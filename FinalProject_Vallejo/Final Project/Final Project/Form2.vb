Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LOOK IN DEPRECIATION FORM 2 LIST INVENTORY FOR GUIDE
        Dim objReader As IO.StreamReader
        Dim strFile As String = "D:\cars.CSV"
        Dim intCount As Integer = 0
        Dim strFileError As String = "The file is not available."
        objReader = IO.File.OpenText(strFile)
        Dim tempString As String
        Dim separator() As String = {","}
        Dim coma As String = ", "

        Do While objReader.Peek <> -1
            tempString = objReader.ReadLine()
            Dim words() As String = tempString.Split(separator, StringSplitOptions.RemoveEmptyEntries)
            lstResults.Items.Add(words(7) + coma + words(1) + coma + words(2) + coma + words(5) + "HP" + coma + words(3) + coma + words(0) + "/" + words(4) + " City/Highway MPG, " + words(6) + " Hybrid")


            intCount += 1
        Loop
    End Sub


    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        Dim ftmFirst As New Form1
        Hide() 'Hides current form
        ftmFirst.ShowDialog() 'Shows the new form
    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        Dim ftmFirst As New Form1
        Hide() 'Hides current form
        ftmFirst.ShowDialog() 'Shows the new form
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub
End Class