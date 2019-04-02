Option Strict On

Public Class frmDepreciation
    Private _intLifeOfItems As Integer = 5
    Public Shared _intSizeOfArray As Integer = 7
    Public Shared _strInventoryItem(_intSizeOfArray) As String
    Private _strItemId(_intSizeOfArray) As String
    Private _decInitialPrice(_intSizeOfArray) As Decimal
    Private _intQuantity(_intSizeOfArray) As Integer

    Private Sub frmDepreciation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim objReader As IO.StreamReader
        Dim strLocationAndNameOfFile As String = "inventory.txt"
        Dim intCount As Integer = 0
        Dim intFill As Integer
        Dim strFileError As String = "The file is not available."

        If IO.File.Exists(strLocationAndNameOfFile) Then
            objReader = IO.File.OpenText(strLocationAndNameOfFile)
            Do While objReader.Peek <> -1
                _strInventoryItem(intCount) = objReader.ReadLine()
                _strItemId(intCount) = objReader.ReadLine()
                _decInitialPrice(intCount) = Convert.ToDecimal(objReader.ReadLine())
                _intQuantity(intCount) = Convert.ToInt32(objReader.ReadLine())
                intCount += 1
            Loop
            objReader.Close()

            For intFill = 0 To (_strItemId.Length - 1)
                lstInventoryId.Items.Add(_strItemId(intFill))
            Next
        Else
            MsgBox(strFileError, , "Error")
            Close()
        End If
    End Sub


    Private Sub btnCalculateDepreciation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculateDepreciation.Click

        Dim intSelectedItemId As Integer
        Dim strMissingSelection As String = "missing selection"
        Dim strSelectDepreciationError As String = "select a depreciation method"
        Dim strSelectInventoryItemIDError As String = "select an inventroy item id"

        If lstInventoryId.SelectedIndex >= 0 Then
            intSelectedItemId = lstInventoryId.SelectedIndex
            If rad.Checked Then
                StraightLineDepreciation(intSelectedItemId)
            ElseIf radDoubleDeclining.Checked Then
                DoubleDecliningDepreciaiton(intSelectedItemId)
            Else
                MsgBox(strSelectDepreciationError, , strMissingSelection)
            End If
        End If
    End Sub

    Private Sub StraightLineDepreciation(ByVal intItemId As Integer)
        Dim intStraightPresentYear As Integer
        Dim decStraightPresentYearValue As Decimal = 0
        Dim decStraightDepreciation As Decimal
        Dim decStraightTotal As Decimal
        Dim strdepreciationItem As String = "The depreciation fo the item: "
        Dim strQuantityMessage As String = "Quantity"

        MakeObjectsVisible()

        lblItem.Text = strdepreciationItem & _strInventoryItem(intItemId)
        lblQuantity.Text = strQuantityMessage & _intQuantity(intItemId) / _intLifeOfItems
        decStraightPresentYearValue = _decInitialPrice(intItemId)


        For intStraightPresentYear = 1 To _intLifeOfItems
            decStraightTotal += decStraightDepreciation
            lstYear.Items.Add(intStraightPresentYear.ToString())
            lstPresentValue.Items.Add(decStraightPresentYearValue.ToString("C"))
            lstYearDepreciation.Items.Add(decStraightDepreciation.ToString("C"))
            lstTotalDepreciation.Items.Add(decStraightTotal.ToString("C"))
            decStraightPresentYearValue -= decStraightDepreciation
        Next
    End Sub

    Private Sub DoubleDecliningDepreciaiton(ByVal intItemId As Integer)
        Dim intDoublePresentYear As Integer
        Dim decDoublePresentYearValue As Decimal = 0
        Dim decDoubleDepreciaiton As Decimal
        Dim decDoubleTotal As Decimal


        MakeObjectsVisible()

        lblItem.Text = "The depreciation of the item: " & _strInventoryItem(intItemId)
        lblQuantity.Text = "Quantity: " & _decInitialPrice(intItemId)

        For intDoublePresentYear = 1 To _intLifeOfItems
            decDoubleDepreciaiton = (decDoublePresentYearValue * 2D) / _intLifeOfItems
            decDoubleTotal += decDoubleDepreciaiton
            lstYear.Items.Add(intDoublePresentYear.ToString())
            lstPresentValue.Items.Add(decDoublePresentYearValue.ToString("C"))
            lstYearDepreciation.Items.Add(decDoubleDepreciaiton.ToString("C"))
            lstTotalDepreciation.Items.Add(decDoubleTotal.ToString("C"))
            decDoublePresentYearValue -= decDoubleDepreciaiton

        Next
    End Sub

    Private Sub MakeObjectsVisible()
        lblItem.Visible = True
        lblQuantity.Visible = True
        lblYear.Visible = True
        lstYear.Visible = True
        lblPresentValue.Visible = True
        lstPresentValue.Visible = True
        lblYearDepreciation.Visible = True
        lstYearDepreciation.Visible = True
        lblTotalDepreciation.Visible = True
        lblTotalDepreciation.Visible = True
        lstYear.Items.Clear()
        lstPresentValue.Items.Clear()
        lstYearDepreciation.Items.Clear()
        lstTotalDepreciation.Items.Clear()
    End Sub

    Private Sub mnuDisplay_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDisplay.Click
        Dim frmSecond As New frmDisplayInventory

        Hide()
        frmSecond.ShowDialog()
    End Sub

    Private Sub mnuClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClear.Click
        lstInventoryId.SelectedIndex = -1
        rad.Checked = False
        radDoubleDeclining.Checked = False
        lblItem.Visible = False
        lblQuantity.Visible = False
        lblYear.Visible = False
        lstYear.Items.Clear()
        lblPresentValue.Visible = False
        lstYearDepreciation.Visible = False
        lstYearDepreciation.Items.Clear()
        lblTotalDepreciation.Visible = False
        lblTotalDepreciation.Visible = False
        lstTotalDepreciation.Items.Clear()

    End Sub

    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Application.Exit()
    End Sub


End Class