Imports System.Collections.Specialized
Imports System.IO
Imports System.Net
Imports System.Web

Public Class frmMain
    Dim txtCurrentDirectory As String = Directory.GetCurrentDirectory

    Private Sub txtR1Cat1_TextChanged_1(sender As Object, e As EventArgs) Handles txtR1Cat6C.TextChanged, txtR1Cat6B.TextChanged, txtR1Cat6A.TextChanged, txtR1Cat6.TextChanged, txtR1Cat5C.TextChanged, txtR1Cat5B.TextChanged, txtR1Cat5A.TextChanged, txtR1Cat5.TextChanged, txtR1Cat4C.TextChanged, txtR1Cat4B.TextChanged, txtR1Cat4A.TextChanged, txtR1Cat4.TextChanged, txtR1Cat3C.TextChanged, txtR1Cat3B.TextChanged, txtR1Cat3A.TextChanged, txtR1Cat3.TextChanged, txtR1Cat3C.TextChanged, txtR1Cat3B.TextChanged, txtR1Cat3A.TextChanged, txtR1Cat2.TextChanged, txtR1Cat1C.TextChanged, txtR1Cat1B.TextChanged, txtR1Cat1A.TextChanged, txtR1Cat1.TextChanged, txtR2Cat6C.TextChanged, txtR2Cat6B.TextChanged, txtR2Cat6A.TextChanged, txtR2Cat6.TextChanged, txtR2Cat5C.TextChanged, txtR2Cat5B.TextChanged, txtR2Cat5A.TextChanged, txtR2Cat5.TextChanged, txtR2Cat4C.TextChanged, txtR2Cat4B.TextChanged, txtR2Cat4A.TextChanged, txtR2Cat4.TextChanged, txtR2Cat3C.TextChanged, txtR2Cat3B.TextChanged, txtR2Cat3A.TextChanged, txtR2Cat3.TextChanged, txtR2Cat3C.TextChanged, txtR2Cat3B.TextChanged, txtR2Cat3A.TextChanged, txtR2Cat2.TextChanged, txtR2Cat1C.TextChanged, txtR2Cat1B.TextChanged, txtR2Cat1A.TextChanged, txtR2Cat1.TextChanged, txtFCatC.TextChanged, txtFCatB.TextChanged, txtFCatA.TextChanged, txtFCat.TextChanged, txtUltCat1.TextChanged, txtUltCat1A.TextChanged, txtUltCat1B.TextChanged, txtUltCat1C.TextChanged, txtUltCat2.TextChanged, txtUltCat2A.TextChanged, txtUltCat2B.TextChanged, txtUltCat2C.TextChanged
        Dim arrTextboxes As TextBox() = {txtR1Cat6C, txtR1Cat6B, txtR1Cat6A, txtR1Cat6, txtR1Cat5C, txtR1Cat5B, txtR1Cat5A, txtR1Cat5, txtR1Cat4C, txtR1Cat4B, txtR1Cat4A, txtR1Cat4, txtR1Cat3C, txtR1Cat3B, txtR1Cat3A, txtR1Cat3, txtR1Cat2C, txtR1Cat2B, txtR1Cat2A, txtR1Cat2, txtR1Cat1C, txtR1Cat1B, txtR1Cat1A, txtR1Cat1, txtR2Cat6C, txtR2Cat6B, txtR2Cat6A, txtR2Cat6, txtR2Cat5C, txtR2Cat5B, txtR2Cat5A, txtR2Cat5, txtR2Cat4C, txtR2Cat4B, txtR2Cat4A, txtR2Cat4, txtR2Cat3C, txtR2Cat3B, txtR2Cat3A, txtR2Cat3, txtR2Cat2C, txtR2Cat2B, txtR2Cat2A, txtR2Cat2, txtR2Cat1C, txtR2Cat1B, txtR2Cat1A, txtR2Cat1, txtFCatC, txtFCatB, txtFCatA, txtFCat, txtUltCat1, txtUltCat1A, txtUltCat1B, txtUltCat1C, txtUltCat2, txtUltCat2A, txtUltCat2B, txtUltCat2C}

        For Each item In arrTextboxes
            If String.IsNullOrWhiteSpace(item.Text) Then
                item.BackColor = Color.LightCoral
            Else
                item.BackColor = SystemColors.Window
            End If
        Next

    End Sub


    Private Sub btnSaveGame_Click(sender As Object, e As EventArgs) Handles btnSaveGame.Click
        ' We want to save the game. 

        Dim blnBaseExists As Boolean = Directory.Exists(Directory.GetCurrentDirectory() + "/Game" + nudGameNo.Value.ToString())
        Dim blnFinalExists As Boolean = Directory.Exists(Directory.GetCurrentDirectory() + "/Game" + nudGameNo.Value.ToString() + "/Final")
        Dim blnRound1Exists As Boolean = Directory.Exists(Directory.GetCurrentDirectory() + "/Game" + nudGameNo.Value.ToString() + "/Round1")
        Dim blnRound2Exists As Boolean = Directory.Exists(Directory.GetCurrentDirectory() + "/Game" + nudGameNo.Value.ToString() + "/Round2")
        Dim blnUltimateExists As Boolean = Directory.Exists(Directory.GetCurrentDirectory() + "/Game" + nudGameNo.Value.ToString() + "/Ultimate")

        ' First things first, try to create a directory named "GameX" where X is the number from the numeric up down.
        ' If you can't make it, that means the directory already has a game file in it. STOP unless Overwrite is given.
        If blnBaseExists And cbOverwrite.Checked = False Then
            MessageBox.Show("Cannot create directory:" + vbNewLine + Directory.GetCurrentDirectory() + "\Game" + nudGameNo.Value.ToString + vbNewLine + vbNewLine + "It might already exist. If you want to overwrite this, click the ""Overwrite?"" Checkbox and try again", "Cannot create new game directory.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            ' Create the base, /Final, /Round1 and /Round2 directories. If need be
            If blnBaseExists = False Then Directory.CreateDirectory("./Game" + nudGameNo.Value.ToString())
            If blnFinalExists = False Then Directory.CreateDirectory("./Game" + nudGameNo.Value.ToString() + "/Final")
            If blnRound1Exists = False Then Directory.CreateDirectory("./Game" + nudGameNo.Value.ToString() + "/Round1")
            If blnRound2Exists = False Then Directory.CreateDirectory("./Game" + nudGameNo.Value.ToString() + "/Round2")
            If blnUltimateExists = False Then Directory.CreateDirectory("./Game" + nudGameNo.Value.ToString() + "/Ultimate")

            ' Final Challenge - Category
            Dim sw As New StreamWriter("./Game" + nudGameNo.Value.ToString() + "/Final/category.txt", False)
            sw.Write("category=" + WebUtility.UrlEncode(FancyTrim(txtFCat.Text)) + "&")
            sw.Close()

            ' Final Challenge - Topics
            sw = New StreamWriter("./Game" + nudGameNo.Value.ToString() + "/Final/topics.txt", False)
            sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtFCatA.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtFCatB.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtFCatC.Text)) + "&")
            sw.Close()

            ' Round 1 - Categories
            sw = New StreamWriter("./Game" + nudGameNo.Value.ToString() + "/Round1/categories.txt", False)
            sw.Write("category1=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat1.Text)) + "&category2=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat2.Text)) + "&category3=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat3.Text)) + "&category4=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat4.Text)) + "&category5=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat5.Text)) + "&category6=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat6.Text)) + "&")
            sw.Close()

            ' Round 1 - Category 1 Topics
            sw = New StreamWriter("./Game" + nudGameNo.Value.ToString() + "/Round1/topics1.txt", False)
            sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat1A.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat1B.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat1C.Text)) + "&")
            sw.Close()

            ' Round 1 - Category 2 Topics
            sw = New StreamWriter("./Game" + nudGameNo.Value.ToString() + "/Round1/topics2.txt", False)
            sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat3A.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat3B.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat3C.Text)) + "&")
            sw.Close()

            ' Round 1 - Category 3 Topics
            sw = New StreamWriter("./Game" + nudGameNo.Value.ToString() + "/Round1/topics3.txt", False)
            sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat3A.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat3B.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat3C.Text)) + "&")
            sw.Close()

            ' Round 1 - Category 4 Topics
            sw = New StreamWriter("./Game" + nudGameNo.Value.ToString() + "/Round1/topics4.txt", False)
            sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat4A.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat4B.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat4C.Text)) + "&")
            sw.Close()

            ' Round 1 - Category 5 Topics
            sw = New StreamWriter("./Game" + nudGameNo.Value.ToString() + "/Round1/topics5.txt", False)
            sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat5A.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat5B.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat5C.Text)) + "&")
            sw.Close()

            ' Round 1 - Category 6 Topics
            sw = New StreamWriter("./Game" + nudGameNo.Value.ToString() + "/Round1/topics6.txt", False)
            sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat6A.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat6B.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat6C.Text)) + "&")
            sw.Close()

            ' Round 2 - Categories
            sw = New StreamWriter("./Game" + nudGameNo.Value.ToString() + "/Round2/categories.txt", False)
            sw.Write("category1=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat1.Text)) + "&category2=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat2.Text)) + "&category3=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat3.Text)) + "&category4=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat4.Text)) + "&category5=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat5.Text)) + "&category6=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat6.Text)) + "&")
            sw.Close()

            ' Round 2 - Category 1 Topics
            sw = New StreamWriter("./Game" + nudGameNo.Value.ToString() + "/Round2/topics1.txt", False)
            sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat1A.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat1B.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat1C.Text)) + "&")
            sw.Close()

            ' Round 2 - Category 2 Topics
            sw = New StreamWriter("./Game" + nudGameNo.Value.ToString() + "/Round2/topics2.txt", False)
            sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat3A.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat3B.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat3C.Text)) + "&")
            sw.Close()

            ' Round 2 - Category 3 Topics
            sw = New StreamWriter("./Game" + nudGameNo.Value.ToString() + "/Round2/topics3.txt", False)
            sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat3A.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat3B.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat3C.Text)) + "&")
            sw.Close()

            ' Round 2 - Category 4 Topics
            sw = New StreamWriter("./Game" + nudGameNo.Value.ToString() + "/Round2/topics4.txt", False)
            sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat4A.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat4B.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat4C.Text)) + "&")
            sw.Close()

            ' Round 2 - Category 5 Topics
            sw = New StreamWriter("./Game" + nudGameNo.Value.ToString() + "/Round2/topics5.txt", False)
            sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat5A.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat5B.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat5C.Text)) + "&")
            sw.Close()

            ' Round 2 - Category 6 Topics
            sw = New StreamWriter("./Game" + nudGameNo.Value.ToString() + "/Round2/topics6.txt", False)
            sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat6A.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat6B.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat6C.Text)) + "&")
            sw.Close()

            ' Ultimate Challenge Topics
            sw = New StreamWriter("./Game" + nudGameNo.Value.ToString() + "/Ultimate/category.txt", False)
            sw.Write("category1=" + WebUtility.UrlEncode(FancyTrim(txtUltCat1.Text)) + "&category2=" + WebUtility.UrlEncode(FancyTrim(txtUltCat2.Text)) + "&")
            sw.Close()

            sw = New StreamWriter("./Game" + nudGameNo.Value.ToString() + "/Ultimate/topics.txt", False)
            sw.Write("topicA1=" + WebUtility.UrlEncode(FancyTrim(txtUltCat1A.Text)) + "&topicA2=" + WebUtility.UrlEncode(FancyTrim(txtUltCat1B.Text)) + "&topicA3=" + WebUtility.UrlEncode(FancyTrim(txtUltCat1C.Text)) + "&topicB1=" + WebUtility.UrlEncode(FancyTrim(txtUltCat2A.Text)) + "&topicB2=" + WebUtility.UrlEncode(FancyTrim(txtUltCat2B.Text)) + "&topicB3=" + WebUtility.UrlEncode(FancyTrim(txtUltCat2C.Text)) + "&")
            sw.Close()

            MessageBox.Show("Game data files created successfully!", "Save files OK", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Since the file was written successfully, set this directory to be the new "LastOutputDirectory" property.
            My.Settings.LastOutputDirectory = Directory.GetCurrentDirectory()
            My.Settings.Save()

        End If

    End Sub

    Public Function FancyTrim(strEntry As String, Optional blnDatabase As Boolean = False)
        If Not IsNothing(strEntry) Then

            strEntry = System.Text.RegularExpressions.Regex.Replace(strEntry, "\s+", " ").Trim

            If String.IsNullOrWhiteSpace(strEntry) Then
                Return IIf(blnDatabase = False, Nothing, DBNull.Value)
            Else
                Return strEntry
            End If
        Else
            Return Nothing
        End If
    End Function

    Private Sub btnOpenGame_Click(sender As Object, e As EventArgs) Handles btnOpenGame.Click
        ' Opening the game file. This is going to be tricky.

        ' We need to open the directory selected the number selector and make sure there is a /Final, /Round1, and /Round2 directories.
        Dim blnBaseExists As Boolean = Directory.Exists(Directory.GetCurrentDirectory() + "/Game" + nudGameNo.Value.ToString())
        Dim blnFinalExists As Boolean = Directory.Exists(Directory.GetCurrentDirectory() + "/Game" + nudGameNo.Value.ToString() + "/Final")
        Dim blnRound1Exists As Boolean = Directory.Exists(Directory.GetCurrentDirectory() + "/Game" + nudGameNo.Value.ToString() + "/Round1")
        Dim blnRound2Exists As Boolean = Directory.Exists(Directory.GetCurrentDirectory() + "/Game" + nudGameNo.Value.ToString() + "/Round2")

        Dim strLine As String
        Dim nvcDecoded As NameValueCollection

        Dim lstErrors As New List(Of String)

        If blnBaseExists = False Then
            MessageBox.Show("No game exists at the directory:" + vbNewLine + vbNewLine + Directory.GetCurrentDirectory() + "\Game" + nudGameNo.Value.ToString() + vbNewLine + vbNewLine + "Try to select another game number.", "Invalid Game File", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            ' Blank out all of the form details.
            ClearTextboxes()

            ' The directory exists! Try to go through and retrieve as much of the game as possible.
            If blnFinalExists Then

                ' Final Challenge - Category
                If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Final/category.txt") Then
                    ' Final Challenge Category
                    Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Value.ToString() + "/Final/category.txt")
                    strLine = WebUtility.UrlDecode(sr)

                    nvcDecoded = HttpUtility.ParseQueryString(strLine)

                    ' Assign the value to the appropriate textbox.
                    txtFCat.Text = FancyTrim(nvcDecoded("category"))
                End If

                ' Final Challenge - Topics
                If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Final/topics.txt") Then
                    Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Value.ToString() + "/Final/topics.txt")
                    strLine = WebUtility.UrlDecode(sr)

                    nvcDecoded = HttpUtility.ParseQueryString(strLine)

                    ' Assign the value to the appropriate textbox.
                    txtFCatA.Text = FancyTrim(nvcDecoded("topic1"))
                    txtFCatB.Text = FancyTrim(nvcDecoded("topic2"))
                    txtFCatC.Text = FancyTrim(nvcDecoded("topic3"))

                End If
            End If

            If blnRound1Exists Then
                ' Round 1 - Categories
                If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round1/categories.txt") Then
                    Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Value.ToString() + "/Round1/categories.txt")
                    strLine = WebUtility.UrlDecode(sr)

                    nvcDecoded = HttpUtility.ParseQueryString(strLine)

                    ' Assign the value to the appropriate textbox.
                    txtR1Cat1.Text = FancyTrim(nvcDecoded("category1"))
                    txtR1Cat2.Text = FancyTrim(nvcDecoded("category2"))
                    txtR1Cat3.Text = FancyTrim(nvcDecoded("category3"))
                    txtR1Cat4.Text = FancyTrim(nvcDecoded("category4"))
                    txtR1Cat5.Text = FancyTrim(nvcDecoded("category5"))
                    txtR1Cat6.Text = FancyTrim(nvcDecoded("category6"))

                    ' Release the file
                    'sr.Close()
                End If

                ' Round 1 - Category 1 - Topics
                If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round1/topics1.txt") Then
                    Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Value.ToString() + "/Round1/topics1.txt")
                    strLine = WebUtility.UrlDecode(sr)

                    nvcDecoded = HttpUtility.ParseQueryString(strLine)

                    ' Assign the value to the appropriate textbox.
                    txtR1Cat1A.Text = FancyTrim(nvcDecoded("topic1"))
                    txtR1Cat1B.Text = FancyTrim(nvcDecoded("topic2"))
                    txtR1Cat1C.Text = FancyTrim(nvcDecoded("topic3"))

                    ' Release the file
                End If

                ' Round 1 - Category 2 - Topics
                If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round1/topics2.txt") Then
                    Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Value.ToString() + "/Round1/topics2.txt")
                    strLine = WebUtility.UrlDecode(sr)

                    nvcDecoded = HttpUtility.ParseQueryString(strLine)

                    ' Assign the value to the appropriate textbox.
                    txtR1Cat2A.Text = FancyTrim(nvcDecoded("topic1"))
                    txtR1Cat2B.Text = FancyTrim(nvcDecoded("topic2"))
                    txtR1Cat2C.Text = FancyTrim(nvcDecoded("topic3"))

                End If

                ' Round 1 - Category 3 - Topics
                If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round1/topics3.txt") Then
                    Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Value.ToString() + "/Round1/topics3.txt")
                    strLine = WebUtility.UrlDecode(sr)

                    nvcDecoded = HttpUtility.ParseQueryString(strLine)

                    ' Assign the value to the appropriate textbox.
                    txtR1Cat3A.Text = FancyTrim(nvcDecoded("topic1"))
                    txtR1Cat3B.Text = FancyTrim(nvcDecoded("topic2"))
                    txtR1Cat3C.Text = FancyTrim(nvcDecoded("topic3"))

                End If

                ' Round 1 - Category 4 - Topics
                If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round1/topics4.txt") Then
                    Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Value.ToString() + "/Round1/topics4.txt")
                    strLine = WebUtility.UrlDecode(sr)

                    nvcDecoded = HttpUtility.ParseQueryString(strLine)

                    ' Assign the value to the appropriate textbox.
                    txtR1Cat4A.Text = FancyTrim(nvcDecoded("topic1"))
                    txtR1Cat4B.Text = FancyTrim(nvcDecoded("topic2"))
                    txtR1Cat4C.Text = FancyTrim(nvcDecoded("topic3"))

                End If

                ' Round 1 - Category 5 - Topics
                If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round1/topics5.txt") Then
                    Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Value.ToString() + "/Round1/topics5.txt")
                    strLine = WebUtility.UrlDecode(sr)

                    nvcDecoded = HttpUtility.ParseQueryString(strLine)

                    ' Assign the value to the appropriate textbox.
                    txtR1Cat5A.Text = FancyTrim(nvcDecoded("topic1"))
                    txtR1Cat5B.Text = FancyTrim(nvcDecoded("topic2"))
                    txtR1Cat5C.Text = FancyTrim(nvcDecoded("topic3"))

                End If


                ' Round 1 - Category 6 - Topics
                If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round1/topics6.txt") Then
                    Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Value.ToString() + "/Round1/topics6.txt")
                    strLine = WebUtility.UrlDecode(sr)

                    nvcDecoded = HttpUtility.ParseQueryString(strLine)

                    ' Assign the value to the appropriate textbox.
                    txtR1Cat6A.Text = FancyTrim(nvcDecoded("topic1"))
                    txtR1Cat6B.Text = FancyTrim(nvcDecoded("topic2"))
                    txtR1Cat6C.Text = FancyTrim(nvcDecoded("topic3"))

                End If
            End If

            If blnRound2Exists Then
                ' Round 2 - Categories
                If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round2/categories.txt") Then
                    Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Value.ToString() + "/Round2/categories.txt")
                    strLine = WebUtility.UrlDecode(sr)

                    nvcDecoded = HttpUtility.ParseQueryString(strLine)

                    ' Assign the value to the appropriate textbox.
                    txtR2Cat1.Text = FancyTrim(nvcDecoded("category1"))
                    txtR2Cat2.Text = FancyTrim(nvcDecoded("category2"))
                    txtR2Cat3.Text = FancyTrim(nvcDecoded("category3"))
                    txtR2Cat4.Text = FancyTrim(nvcDecoded("category4"))
                    txtR2Cat5.Text = FancyTrim(nvcDecoded("category5"))
                    txtR2Cat6.Text = FancyTrim(nvcDecoded("category6"))

                End If

                ' Round 2 - Category 1 - Topics
                If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round2/topics1.txt") Then
                    Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Value.ToString() + "/Round2/topics1.txt")
                    strLine = WebUtility.UrlDecode(sr)

                    nvcDecoded = HttpUtility.ParseQueryString(strLine)

                    ' Assign the value to the appropriate textbox.
                    txtR2Cat1A.Text = FancyTrim(nvcDecoded("topic1"))
                    txtR2Cat1B.Text = FancyTrim(nvcDecoded("topic2"))
                    txtR2Cat1C.Text = FancyTrim(nvcDecoded("topic3"))

                End If

                ' Round 2 - Category 2 - Topics
                If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round2/topics2.txt") Then
                    Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Value.ToString() + "/Round2/topics2.txt")
                    strLine = WebUtility.UrlDecode(sr)

                    nvcDecoded = HttpUtility.ParseQueryString(strLine)

                    ' Assign the value to the appropriate textbox.
                    txtR2Cat2A.Text = FancyTrim(nvcDecoded("topic1"))
                    txtR2Cat2B.Text = FancyTrim(nvcDecoded("topic2"))
                    txtR2Cat2C.Text = FancyTrim(nvcDecoded("topic3"))

                End If

                ' Round 2 - Category 3 - Topics
                If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round2/topics3.txt") Then
                    Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Value.ToString() + "/Round2/topics3.txt")
                    strLine = WebUtility.UrlDecode(sr)

                    nvcDecoded = HttpUtility.ParseQueryString(strLine)

                    ' Assign the value to the appropriate textbox.
                    txtR2Cat3A.Text = FancyTrim(nvcDecoded("topic1"))
                    txtR2Cat3B.Text = FancyTrim(nvcDecoded("topic2"))
                    txtR2Cat3C.Text = FancyTrim(nvcDecoded("topic3"))

                End If

                ' Round 2 - Category 4 - Topics
                If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round2/topics4.txt") Then
                    Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Value.ToString() + "/Round2/topics4.txt")
                    strLine = WebUtility.UrlDecode(sr)

                    nvcDecoded = HttpUtility.ParseQueryString(strLine)

                    ' Assign the value to the appropriate textbox.
                    txtR2Cat4A.Text = FancyTrim(nvcDecoded("topic1"))
                    txtR2Cat4B.Text = FancyTrim(nvcDecoded("topic2"))
                    txtR2Cat4C.Text = FancyTrim(nvcDecoded("topic3"))

                End If

                ' Round 2 - Category 5 - Topics
                If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round2/topics5.txt") Then
                    Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Value.ToString() + "/Round2/topics5.txt")
                    strLine = WebUtility.UrlDecode(sr)

                    nvcDecoded = HttpUtility.ParseQueryString(strLine)

                    ' Assign the value to the appropriate textbox.
                    txtR2Cat5A.Text = FancyTrim(nvcDecoded("topic1"))
                    txtR2Cat5B.Text = FancyTrim(nvcDecoded("topic2"))
                    txtR2Cat5C.Text = FancyTrim(nvcDecoded("topic3"))

                End If


                ' Round 2 - Category 6 - Topics
                If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round2/topics6.txt") Then
                    Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Value.ToString() + "/Round2/topics6.txt")
                    strLine = WebUtility.UrlDecode(sr)

                    nvcDecoded = HttpUtility.ParseQueryString(strLine)

                    ' Assign the value to the appropriate textbox.
                    txtR2Cat6A.Text = FancyTrim(nvcDecoded("topic1"))
                    txtR2Cat6B.Text = FancyTrim(nvcDecoded("topic2"))
                    txtR2Cat6C.Text = FancyTrim(nvcDecoded("topic3"))

                End If

                ' Ultimate - Categories
                If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Ultimate/category.txt") Then
                    Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Value.ToString() + "/Ultimate/category.txt")
                    strLine = WebUtility.UrlDecode(sr)

                    nvcDecoded = HttpUtility.ParseQueryString(strLine)

                    ' Assign the value to the appropriate textbox.
                    txtUltCat1.Text = FancyTrim(nvcDecoded("category1"))
                    txtUltCat2.Text = FancyTrim(nvcDecoded("category2"))

                End If

                ' Ultimate Challenge - Topics
                If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Ultimate/topics.txt") Then
                    Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Value.ToString() + "/Ultimate/topics.txt")
                    strLine = WebUtility.UrlDecode(sr)

                    nvcDecoded = HttpUtility.ParseQueryString(strLine)

                    ' Assign the value to the appropriate textbox.
                    txtUltCat1A.Text = FancyTrim(nvcDecoded("topicA1"))
                    txtUltCat1B.Text = FancyTrim(nvcDecoded("topicA2"))
                    txtUltCat1C.Text = FancyTrim(nvcDecoded("topicA3"))

                    txtUltCat2A.Text = FancyTrim(nvcDecoded("topicB1"))
                    txtUltCat2B.Text = FancyTrim(nvcDecoded("topicB2"))
                    txtUltCat2C.Text = FancyTrim(nvcDecoded("topicB3"))

                End If

            End If
        End If

    End Sub

    Private Sub btnToUpper_Click(sender As Object, e As EventArgs) Handles btnToUpper.Click
        ' Change ALL forms into UPPER CASE
        Dim arrTextboxes As TextBox() = {txtR1Cat6C, txtR1Cat6B, txtR1Cat6A, txtR1Cat6, txtR1Cat5C, txtR1Cat5B, txtR1Cat5A, txtR1Cat5, txtR1Cat4C, txtR1Cat4B, txtR1Cat4A, txtR1Cat4, txtR1Cat3C, txtR1Cat3B, txtR1Cat3A, txtR1Cat3, txtR1Cat2C, txtR1Cat2B, txtR1Cat2A, txtR1Cat2, txtR1Cat1C, txtR1Cat1B, txtR1Cat1A, txtR1Cat1, txtR2Cat6C, txtR2Cat6B, txtR2Cat6A, txtR2Cat6, txtR2Cat5C, txtR2Cat5B, txtR2Cat5A, txtR2Cat5, txtR2Cat4C, txtR2Cat4B, txtR2Cat4A, txtR2Cat4, txtR2Cat3C, txtR2Cat3B, txtR2Cat3A, txtR2Cat3, txtR2Cat2C, txtR2Cat2B, txtR2Cat2A, txtR2Cat2, txtR2Cat1C, txtR2Cat1B, txtR2Cat1A, txtR2Cat1, txtFCatC, txtFCatB, txtFCatA, txtFCat, txtUltCat1, txtUltCat1A, txtUltCat1B, txtUltCat1C, txtUltCat2, txtUltCat2A, txtUltCat2B, txtUltCat2C}

        For Each item In arrTextboxes
            item.Text = item.Text.ToUpper()
        Next

    End Sub
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        If MessageBox.Show("This will clear the textboxes and start a new game file." + vbNewLine + vbNewLine + "If you have saved your game file and/or you're ready to clear everything and start over, click OK. Otherwise hit Cancel.", "Starting a new game file?", MessageBoxButtons.OKCancel) = DialogResult.OK Then ClearTextboxes()
    End Sub

    Private Sub ClearTextboxes()
        ' Loop through every textbox and clear it.

        Dim arrTextboxes As TextBox() = {txtR1Cat6C, txtR1Cat6B, txtR1Cat6A, txtR1Cat6, txtR1Cat5C, txtR1Cat5B, txtR1Cat5A, txtR1Cat5, txtR1Cat4C, txtR1Cat4B, txtR1Cat4A, txtR1Cat4, txtR1Cat3C, txtR1Cat3B, txtR1Cat3A, txtR1Cat3, txtR1Cat2C, txtR1Cat2B, txtR1Cat2A, txtR1Cat2, txtR1Cat1C, txtR1Cat1B, txtR1Cat1A, txtR1Cat1, txtR2Cat6C, txtR2Cat6B, txtR2Cat6A, txtR2Cat6, txtR2Cat5C, txtR2Cat5B, txtR2Cat5A, txtR2Cat5, txtR2Cat4C, txtR2Cat4B, txtR2Cat4A, txtR2Cat4, txtR2Cat3C, txtR2Cat3B, txtR2Cat3A, txtR2Cat3, txtR2Cat2C, txtR2Cat2B, txtR2Cat2A, txtR2Cat2, txtR2Cat1C, txtR2Cat1B, txtR2Cat1A, txtR2Cat1, txtFCatC, txtFCatB, txtFCatA, txtFCat, txtUltCat1, txtUltCat2, txtUltCat1A, txtUltCat1B, txtUltCat1C, txtUltCat2A, txtUltCat2B, txtUltCat2C}

        For Each item In arrTextboxes
            item.Clear()
        Next

        ' Clear the overwrite save checkbox
        cbOverwrite.Checked = False

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If String.IsNullOrEmpty(My.Settings.LastOutputDirectory) Then
            My.Settings.LastOutputDirectory = Directory.GetCurrentDirectory.Trim
        End If

        SetCurrentDirectory(My.Settings.LastOutputDirectory)
    End Sub

    Private Sub btnDirectorySetting_Click(sender As Object, e As EventArgs) Handles btnDirectorySetting.Click
        ' Prompt for choose directory
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then SetCurrentDirectory(FolderBrowserDialog1.SelectedPath)
    End Sub

    Private Sub SetCurrentDirectory(selectedPath As String)
        Directory.SetCurrentDirectory(selectedPath)
        FolderBrowserDialog1.SelectedPath = selectedPath

        ' Set the directory variable on load.
        txtCurrentDirectory = Directory.GetCurrentDirectory.Trim

        ' Put the current directory into the label on the form.
        lblGamesDirectory.Text = txtCurrentDirectory
    End Sub

    Private Sub btnCopy1to2_Click(sender As Object, e As EventArgs) Handles btnCopy1to2.Click
        If MessageBox.Show("This will overwrite ANYTHING that is already written in the Round 2 text boxes. If you're sure and you're ready, click OK. Otherwise, hit Cancel.", "Confirm Overwrite", MessageBoxButtons.OKCancel) = DialogResult.OK Then
            ' Do this after they confirm they want to do it.
            ' COPY ROUND 1 to COPY 2

            ' Round 1 Categories into Round 2
            txtR2Cat1.Text = txtR1Cat1.Text
            txtR2Cat2.Text = txtR1Cat2.Text
            txtR2Cat3.Text = txtR1Cat3.Text
            txtR2Cat4.Text = txtR1Cat4.Text
            txtR2Cat5.Text = txtR1Cat5.Text
            txtR2Cat6.Text = txtR1Cat6.Text

            ' Round 1 Topics into Round 2
            txtR2Cat1A.Text = txtR1Cat1A.Text
            txtR2Cat1B.Text = txtR1Cat1B.Text
            txtR2Cat1C.Text = txtR1Cat1C.Text

            txtR2Cat2A.Text = txtR1Cat2A.Text
            txtR2Cat2B.Text = txtR1Cat2B.Text
            txtR2Cat2C.Text = txtR1Cat2C.Text

            txtR2Cat3A.Text = txtR1Cat3A.Text
            txtR2Cat3B.Text = txtR1Cat3B.Text
            txtR2Cat3C.Text = txtR1Cat3C.Text

            txtR2Cat3A.Text = txtR1Cat3A.Text
            txtR2Cat3B.Text = txtR1Cat3B.Text
            txtR2Cat3C.Text = txtR1Cat3C.Text

            txtR2Cat4A.Text = txtR1Cat4A.Text
            txtR2Cat4B.Text = txtR1Cat4B.Text
            txtR2Cat4C.Text = txtR1Cat4C.Text

            txtR2Cat5A.Text = txtR1Cat5A.Text
            txtR2Cat5B.Text = txtR1Cat5B.Text
            txtR2Cat5C.Text = txtR1Cat5C.Text

            txtR2Cat6A.Text = txtR1Cat6A.Text
            txtR2Cat6B.Text = txtR1Cat6B.Text
            txtR2Cat6C.Text = txtR1Cat6C.Text
        End If
    End Sub

    Private Sub btnCopy2to1_Click(sender As Object, e As EventArgs) Handles btnCopy2to1.Click
        If MessageBox.Show("This will overwrite ANYTHING that is already written in the Round 1 text boxes. If you're sure and you're ready, click OK. Otherwise, hit Cancel.", "Confirm Overwrite", MessageBoxButtons.OKCancel) = DialogResult.OK Then
            ' Do this after they confirm they want to do it.
            ' COPY ROUND 2 to COPY 1

            ' Round 2 Categories into Round 1
            txtR1Cat1.Text = txtR2Cat1.Text
            txtR1Cat2.Text = txtR2Cat2.Text
            txtR1Cat3.Text = txtR2Cat3.Text
            txtR1Cat4.Text = txtR2Cat4.Text
            txtR1Cat5.Text = txtR2Cat5.Text
            txtR1Cat6.Text = txtR2Cat6.Text

            ' Round 2 Topics into Round 1
            txtR1Cat1A.Text = txtR2Cat1A.Text
            txtR1Cat1B.Text = txtR2Cat1B.Text
            txtR1Cat1C.Text = txtR2Cat1C.Text

            txtR1Cat2A.Text = txtR2Cat2A.Text
            txtR1Cat2B.Text = txtR2Cat2B.Text
            txtR1Cat2C.Text = txtR2Cat2C.Text

            txtR1Cat3A.Text = txtR2Cat3A.Text
            txtR1Cat3B.Text = txtR2Cat3B.Text
            txtR1Cat3C.Text = txtR2Cat3C.Text

            txtR1Cat3A.Text = txtR2Cat3A.Text
            txtR1Cat3B.Text = txtR2Cat3B.Text
            txtR1Cat3C.Text = txtR2Cat3C.Text

            txtR1Cat4A.Text = txtR2Cat4A.Text
            txtR1Cat4B.Text = txtR2Cat4B.Text
            txtR1Cat4C.Text = txtR2Cat4C.Text

            txtR1Cat5A.Text = txtR2Cat5A.Text
            txtR1Cat5B.Text = txtR2Cat5B.Text
            txtR1Cat5C.Text = txtR2Cat5C.Text

            txtR1Cat6A.Text = txtR2Cat6A.Text
            txtR1Cat6B.Text = txtR2Cat6B.Text
            txtR1Cat6C.Text = txtR2Cat6C.Text
        End If
    End Sub

    Private Sub btnFindGamePack_Click(sender As Object, e As EventArgs) Handles btnFindGamePack.Click
        ' Starting at 1, go through and find the first non-existing directory. When you do, set the number selector to that number.

        For i = 1 To 999999
            ' Test if a directory exists, if so... Keep Going.
            If Not Directory.Exists(Directory.GetCurrentDirectory() + "/Game" + i.ToString) Then
                nudGameNo.Value = i
                Exit For
            End If
        Next
    End Sub
End Class
