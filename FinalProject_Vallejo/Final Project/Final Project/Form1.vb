'Omar Vallejo 
'final Project
'Car Database Search




Imports System.IO
'Option Strict On
Public Class Form1

    'Horse power: 300+ Sports Car, 500+ Supper Sports
    'Im feddbacking the ID


    'Set up arrays which receive info from database
    'If needed, There are 5077 lines to save
    Public arrYear(5077) As String
    Public arrCityMPG(5077) As String
    Public arrClassification(5077) As String
    Public arrFuelType(5077) As String
    Public arrHighWayMPG(5077) As String
    Public arrHorsePower(5077) As String
    Public arrHybrid(5077) As String
    Public arrID(5077) As String
    Public arrMake(5077) As String
    Public arrModelYear(5077) As String
    Public arrDriveline(5077) As String
    Public arrSportType(5077) As String
    'Public dims
    Public strOptionError As String = "Please select an option"
    Public intMPG As String
    Public boolClassification As String
    Public strDriveline As String
    Public strFuelType As String
    Public strSportType As String
    Public boolHybrid As String

    'Execute the search for users dream car
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        lstResults.Visible = True
        btnSubmit.Visible = False
        gpbHybrid.Visible = False
        lblHybrid.Visible = False
        btnOrderCar.Visible = True

        Dim i As Integer = 0
        lstResults.Items.Add("Car Year Make and Model")

        Do While (i < 5077)
            'Classification 
            If arrClassification(i) = boolClassification Then
                'Driveline
                If arrDriveline(i) = strDriveline Then
                    'Fuel Type
                    If strFuelType = arrFuelType(i) Then

                        'Hybrid
                        If boolHybrid = arrHybrid(i) Then
                            lstResults.Items.Add(arrID(i))
                        End If
                    End If
                End If
            End If
                            i += 1
        Loop
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'wHEN PROGRAM LOADS,   read form database file

        Dim objReader As IO.StreamReader
        Dim strFile As String = "D:\cars.CSV"
        Dim intCount As Integer = 0
        Dim strFileError As String = "The file is not available."


        If IO.File.Exists(strFile) Then
            objReader = IO.File.OpenText(strFile)
            Dim tempString As String
            Dim separator() As String = {","}

            Do While objReader.Peek <> -1
                tempString = objReader.ReadLine()
                Dim words() As String = tempString.Split(separator, StringSplitOptions.RemoveEmptyEntries)
                arrCityMPG(intCount) = words(0)
                arrClassification(intCount) = words(1)
                arrDriveline(intCount) = words(2)
                arrFuelType(intCount) = words(3)
                arrHighWayMPG(intCount) = words(4)
                arrHorsePower(intCount) = words(5)
                arrHybrid(intCount) = words(6)
                arrID(intCount) = words(7)
                arrMake(intCount) = words(8)
                arrModelYear(intCount) = words(9)
                arrYear(intCount) = words(10)

                intCount += 1
            Loop


        Else
            MsgBox(strFileError, , "Error")
            Close()

        End If

    End Sub


    'submits the specifications to search in the database




    'Will start from scratch 
    Private Sub StartOverToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartOverToolStripMenuItem.Click
        Application.Restart()


    End Sub

    'Qill quit the program

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        Application.Exit()
    End Sub




    Private Sub btnSearchAll_Click(sender As Object, e As EventArgs) Handles btnSearchAll.Click
        Dim ftmSecond As New Form2
        Hide() 'Hides current form
        ftmSecond.ShowDialog() 'Shows the new form

    End Sub


    'SECOND PAGe. Classification (transmisison)
    Private Sub btnBegin_Click(sender As Object, e As EventArgs) Handles btnBegin.Click
        'Second Page setup. Classification (transmission)
        ' Off all previous pages items
        btnBegin.Visible = False
        lblTittle.Visible = False
        lblDescription.Visible = False
        btnSearchAll.Visible = False
        Label1.Visible = False
        ' btnMPG.Visible = False

        'New page
        gpbClassification.Visible = True
        lblClassification.Visible = True
    End Sub

    Private Sub radAutomatic_CheckedChanged(sender As Object, e As EventArgs) Handles radAutomatic.CheckedChanged
        boolClassification = "Automatic transmission"
        picAutomatic.Visible = True
        picManual.Visible = False
        btnClassification.Visible = True
    End Sub

    Private Sub radManual_CheckedChanged(sender As Object, e As EventArgs) Handles radManual.CheckedChanged
        boolClassification = "Manual transmission"
        picManual.Visible = True
        picAutomatic.Visible = False
        btnClassification.Visible = True
    End Sub


    'THIRD PAGE. DRIVELINE
    Private Sub btnClassification_Click(sender As Object, e As EventArgs) Handles btnClassification.Click
        'DRIVELINE PAGE
        'Old page off
        picAutomatic.Visible = False
        picManual.Visible = False
        gpbClassification.Visible = False
        lblClassification.Visible = False
        btnClassification.Visible = False

        'new page
        lblDriveline.Visible = True
        gpbDriveline.Visible = True
    End Sub

    Private Sub radAllWheelDrive_CheckedChanged(sender As Object, e As EventArgs) Handles radAllWheelDrive.CheckedChanged
        strDriveline = "All-wheel drive"
        picAll.Visible = True
        picRearFront.Visible = False
        btnDriveline.Visible = True
    End Sub

    Private Sub radRearWheelDrive_CheckedChanged(sender As Object, e As EventArgs) Handles radRearWheelDrive.CheckedChanged
        strDriveline = "Rear-wheel drive"
        btnDriveline.Visible = True
        picAll.Visible = False
        picRearFront.Visible = True

    End Sub

    Private Sub radFrontwheelDrive_CheckedChanged(sender As Object, e As EventArgs) Handles radFrontwheelDrive.CheckedChanged
        strDriveline = "Front-wheel drive"
        btnDriveline.Visible = True
        picAll.Visible = False
        picRearFront.Visible = True
    End Sub




    'FUEL TYPE PAGE
    Private Sub btnDriveline_Click(sender As Object, e As EventArgs) Handles btnDriveline.Click
        'old page
        lblDriveline.Visible = False
        btnDriveline.Visible = False
        gpbDriveline.Visible = False
        picRearFront.Visible = False
        picAll.Visible = False

        'New page
        lblFuelType.Visible = True
        gpbFuelType.Visible = True

    End Sub

    Private Sub radNaturalGas_CheckedChanged(sender As Object, e As EventArgs) Handles radNaturalGas.CheckedChanged
        strFuelType = "Compressed natural gas"
        picGas.Visible = True
        btnGasType.Visible = True
    End Sub

    Private Sub radDiselFuel_CheckedChanged(sender As Object, e As EventArgs) Handles radDiselFuel.CheckedChanged
        strFuelType = "Diesel fuel"
        btnGasType.Visible = True
        picGas.Visible = True

    End Sub

    Private Sub radE85_CheckedChanged(sender As Object, e As EventArgs) Handles radE85.CheckedChanged
        strFuelType = "E85"
        btnGasType.Visible = True
        picGas.Visible = True

    End Sub

    Private Sub radGasoline_CheckedChanged(sender As Object, e As EventArgs) Handles radGasoline.CheckedChanged
        strFuelType = "Gasoline"
        btnGasType.Visible = True
        picGas.Visible = True

    End Sub








    ''Car Sport type PAGE 5
    Private Sub btnGasType_Click(sender As Object, e As EventArgs) Handles btnGasType.Click
        'old page
        lblFuelType.Visible = False
        gpbFuelType.Visible = False
        btnGasType.Visible = False
        picGas.Visible = False

        'new page 
        lblSportType.Visible = True
        gpbSportType.Visible = True

    End Sub

    Private Sub radNonSport_CheckedChanged(sender As Object, e As EventArgs) Handles radNonSport.CheckedChanged
        strSportType = "Non"
        picNonSport.Visible = True
        picSport.Visible = False
        btnSport.Visible = True
        picSuper.Visible = False
    End Sub

    Private Sub radSport_CheckedChanged(sender As Object, e As EventArgs) Handles radSport.CheckedChanged
        strSportType = "Sport"
        btnSport.Visible = True
        picNonSport.Visible = False
        picSport.Visible = True
        picSuper.Visible = False

    End Sub

    Private Sub radSuperSport_CheckedChanged(sender As Object, e As EventArgs) Handles radSuperSport.CheckedChanged
        strSportType = "Super"
        btnSport.Visible = True
        picNonSport.Visible = False
        picSport.Visible = False
        picSuper.Visible = True

    End Sub





    'PAGE 6 HYBRID
    Private Sub btnSport_Click(sender As Object, e As EventArgs) Handles btnSport.Click
        'old page
        lblSportType.Visible = False
        gpbSportType.Visible = False
        btnSport.Visible = False
        picSuper.Visible = False
        picSport.Visible = False
        picNonSport.Visible = False

        'new apge 
        lblHybrid.Visible = True
        gpbHybrid.Visible = True
    End Sub

    Private Sub radGasOnly_CheckedChanged(sender As Object, e As EventArgs) Handles radGasOnly.CheckedChanged
        boolHybrid = "FALSE"
        btnSubmit.Visible = True
        picHybrid.Visible = False
    End Sub

    Private Sub radHybrid_CheckedChanged(sender As Object, e As EventArgs) Handles radHybrid.CheckedChanged
        boolHybrid = "TRUE"
        btnSubmit.Visible = True
        picHybrid.Visible = True

    End Sub

    Private Sub btnOrderCar_Click(sender As Object, e As EventArgs) Handles btnOrderCar.Click
        picHybrid.Visible = False
        If lstResults.SelectedIndex > 0 Then
            lstResults.Visible = False
            lblLast.Visible = True
            lblLast2.Visible = True
            lblLast3.Visible = True
            Dim intResult As Integer = lstResults.SelectedIndex

            lblLast2.Text = (arrID(intResult) + ".")
            btnOrderCar.Visible = False
            btnSubmitOrder.Visible = True

        Else
            MsgBox("Select a vehicle to purchase.", , "Error")

        End If

    End Sub

    Private Sub btnSubmitOrder_Click(sender As Object, e As EventArgs) Handles btnSubmitOrder.Click
        Dim frm3 As New Form3
        Hide() 'Hides current form
        frm3.ShowDialog() 'Shows the new form
    End Sub
End Class
