Imports System.Collections.Specialized
Imports System.IO
Imports System.Net
Imports System.Web

Public Class frmMain
	'Private Sub txtR1Cat1_TextChanged(sender As Object, e As EventArgs) Handles txtR1Cat6C.TextChanged, txtR1Cat6B.TextChanged, txtR1Cat6A.TextChanged, txtR1Cat6.TextChanged, txtR1Cat5C.TextChanged, txtR1Cat5B.TextChanged, txtR1Cat5A.TextChanged, txtR1Cat5.TextChanged, txtR1Cat4C.TextChanged, txtR1Cat4B.TextChanged, txtR1Cat4A.TextChanged, txtR1Cat4.TextChanged, txtR1Cat3C.TextChanged, txtR1Cat3B.TextChanged, txtR1Cat3A.TextChanged, txtR1Cat3.TextChanged, txtR1Cat2C.TextChanged, txtR1Cat2B.TextChanged, txtR1Cat2A.TextChanged, txtR1Cat2.TextChanged, txtR1Cat1C.TextChanged, txtR1Cat1B.TextChanged, txtR1Cat1A.TextChanged, txtR1Cat1.TextChanged, txtR2Cat6C.TextChanged, txtR2Cat6B.TextChanged, txtR2Cat6A.TextChanged, txtR2Cat6.TextChanged, txtR2Cat5C.TextChanged, txtR2Cat5B.TextChanged, txtR2Cat5A.TextChanged, txtR2Cat5.TextChanged, txtR2Cat4C.TextChanged, txtR2Cat4B.TextChanged, txtR2Cat4A.TextChanged, txtR2Cat4.TextChanged, txtR2Cat3C.TextChanged, txtR2Cat3B.TextChanged, txtR2Cat3A.TextChanged, txtR2Cat3.TextChanged, txtR2Cat2C.TextChanged, txtR2Cat2B.TextChanged, txtR2Cat2A.TextChanged, txtR2Cat2.TextChanged, txtR2Cat1C.TextChanged, txtR2Cat1B.TextChanged, txtR2Cat1A.TextChanged, txtR2Cat1.TextChanged, txtFCatC.TextChanged, txtFCatB.TextChanged, txtFCatA.TextChanged, txtFCat.TextChanged

	'	Dim arrTextboxes As TextBox() = {txtR1Cat6C, txtR1Cat6B, txtR1Cat6A, txtR1Cat6, txtR1Cat5C, txtR1Cat5B, txtR1Cat5A, txtR1Cat5, txtR1Cat4C, txtR1Cat4B, txtR1Cat4A, txtR1Cat4, txtR1Cat3C, txtR1Cat3B, txtR1Cat3A, txtR1Cat3, txtR1Cat2C, txtR1Cat2B, txtR1Cat2A, txtR1Cat2, txtR1Cat1C, txtR1Cat1B, txtR1Cat1A, txtR1Cat1, txtR2Cat6C, txtR2Cat6B, txtR2Cat6A, txtR2Cat6, txtR2Cat5C, txtR2Cat5B, txtR2Cat5A, txtR2Cat5, txtR2Cat4C, txtR2Cat4B, txtR2Cat4A, txtR2Cat4, txtR2Cat3C, txtR2Cat3B, txtR2Cat3A, txtR2Cat3, txtR2Cat2C, txtR2Cat2B, txtR2Cat2A, txtR2Cat2, txtR2Cat1C, txtR2Cat1B, txtR2Cat1A, txtR2Cat1, txtFCatC, txtFCatB, txtFCatA, txtFCat}

	'	Dim blnValid As Boolean = True
	'	' When any of these fields change.

	'	' If ANY of them are BLANK, disable the save button! (We do not write incomplete files!)
	'	For Each item In arrTextboxes
	'		If String.IsNullOrWhiteSpace(item.Text) Then
	'			blnValid = False
	'			Exit For
	'		Else
	'			blnValid = True
	'		End If
	'	Next

	'	btnSaveGame.Enabled = blnValid
	'	cbOverwrite.Enabled = blnValid

	'End Sub
	Private Sub txtR1Cat1_TextChanged_1(sender As Object, e As EventArgs) Handles txtR1Cat6C.TextChanged, txtR1Cat6B.TextChanged, txtR1Cat6A.TextChanged, txtR1Cat6.TextChanged, txtR1Cat5C.TextChanged, txtR1Cat5B.TextChanged, txtR1Cat5A.TextChanged, txtR1Cat5.TextChanged, txtR1Cat4C.TextChanged, txtR1Cat4B.TextChanged, txtR1Cat4A.TextChanged, txtR1Cat4.TextChanged, txtR1Cat3C.TextChanged, txtR1Cat3B.TextChanged, txtR1Cat3A.TextChanged, txtR1Cat3.TextChanged, txtR1Cat2C.TextChanged, txtR1Cat2B.TextChanged, txtR1Cat2A.TextChanged, txtR1Cat2.TextChanged, txtR1Cat1C.TextChanged, txtR1Cat1B.TextChanged, txtR1Cat1A.TextChanged, txtR1Cat1.TextChanged, txtR2Cat6C.TextChanged, txtR2Cat6B.TextChanged, txtR2Cat6A.TextChanged, txtR2Cat6.TextChanged, txtR2Cat5C.TextChanged, txtR2Cat5B.TextChanged, txtR2Cat5A.TextChanged, txtR2Cat5.TextChanged, txtR2Cat4C.TextChanged, txtR2Cat4B.TextChanged, txtR2Cat4A.TextChanged, txtR2Cat4.TextChanged, txtR2Cat3C.TextChanged, txtR2Cat3B.TextChanged, txtR2Cat3A.TextChanged, txtR2Cat3.TextChanged, txtR2Cat2C.TextChanged, txtR2Cat2B.TextChanged, txtR2Cat2A.TextChanged, txtR2Cat2.TextChanged, txtR2Cat1C.TextChanged, txtR2Cat1B.TextChanged, txtR2Cat1A.TextChanged, txtR2Cat1.TextChanged, txtFCatC.TextChanged, txtFCatB.TextChanged, txtFCatA.TextChanged, txtFCat.TextChanged
		Dim arrTextboxes As TextBox() = {txtR1Cat6C, txtR1Cat6B, txtR1Cat6A, txtR1Cat6, txtR1Cat5C, txtR1Cat5B, txtR1Cat5A, txtR1Cat5, txtR1Cat4C, txtR1Cat4B, txtR1Cat4A, txtR1Cat4, txtR1Cat3C, txtR1Cat3B, txtR1Cat3A, txtR1Cat3, txtR1Cat2C, txtR1Cat2B, txtR1Cat2A, txtR1Cat2, txtR1Cat1C, txtR1Cat1B, txtR1Cat1A, txtR1Cat1, txtR2Cat6C, txtR2Cat6B, txtR2Cat6A, txtR2Cat6, txtR2Cat5C, txtR2Cat5B, txtR2Cat5A, txtR2Cat5, txtR2Cat4C, txtR2Cat4B, txtR2Cat4A, txtR2Cat4, txtR2Cat3C, txtR2Cat3B, txtR2Cat3A, txtR2Cat3, txtR2Cat2C, txtR2Cat2B, txtR2Cat2A, txtR2Cat2, txtR2Cat1C, txtR2Cat1B, txtR2Cat1A, txtR2Cat1, txtFCatC, txtFCatB, txtFCatA, txtFCat}
		
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
            sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat2A.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat2B.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat2C.Text)) + "&")
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
            sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat2A.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat2B.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat2C.Text)) + "&")
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
		        
		        MessageBox.Show("Game data files created successfully!", "Save files OK", MessageBoxButtons.OK, MessageBoxIcon.Information)

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
					Dim sr As New StreamReader("./Game" + nudGameNo.Value.ToString() + "/Final/category.txt")
					strLine = WebUtility.UrlDecode(sr.ReadLine)

					nvcDecoded = HttpUtility.ParseQueryString(strLine)

					' Assign the value to the appropriate textbox.
					txtFCat.Text = FancyTrim(nvcDecoded("category"))

					' Release the file
					sr.Close()
				End If

				' Final Challenge - Topics
				If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Final/topics.txt") Then
					' Final Challenge Category
					Dim sr As New StreamReader("./Game" + nudGameNo.Value.ToString() + "/Final/topics.txt")
					strLine = WebUtility.UrlDecode(sr.ReadLine)

					nvcDecoded = HttpUtility.ParseQueryString(strLine)

					' Assign the value to the appropriate textbox.
					txtFCatA.Text = FancyTrim(nvcDecoded("topic1"))
					txtFCatB.Text = FancyTrim(nvcDecoded("topic2"))
					txtFCatC.Text = FancyTrim(nvcDecoded("topic3"))

					' Release the file
					sr.Close()
				End If
			End If

			If blnRound1Exists Then
				' Round 1 - Categories
				If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round1/categories.txt") Then
					' Final Challenge Category
					Dim sr As New StreamReader("./Game" + nudGameNo.Value.ToString() + "/Round1/categories.txt")
					strLine = WebUtility.UrlDecode(sr.ReadLine)

					nvcDecoded = HttpUtility.ParseQueryString(strLine)

					' Assign the value to the appropriate textbox.
					txtR1Cat1.Text = FancyTrim(nvcDecoded("category1"))
					txtR1Cat2.Text = FancyTrim(nvcDecoded("category2"))
					txtR1Cat3.Text = FancyTrim(nvcDecoded("category3"))
					txtR1Cat4.Text = FancyTrim(nvcDecoded("category4"))
					txtR1Cat5.Text = FancyTrim(nvcDecoded("category5"))
					txtR1Cat6.Text = FancyTrim(nvcDecoded("category6"))

					' Release the file
					sr.Close()
				End If

				' Round 1 - Category 1 - Topics
				If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round1/topics1.txt") Then
					' Final Challenge Category
					Dim sr As New StreamReader("./Game" + nudGameNo.Value.ToString() + "/Round1/topics1.txt")
					strLine = WebUtility.UrlDecode(sr.ReadLine)

					nvcDecoded = HttpUtility.ParseQueryString(strLine)

					' Assign the value to the appropriate textbox.
					txtR1Cat1A.Text = FancyTrim(nvcDecoded("topic1"))
					txtR1Cat1B.Text = FancyTrim(nvcDecoded("topic2"))
					txtR1Cat1C.Text = FancyTrim(nvcDecoded("topic3"))

					' Release the file
					sr.Close()
				End If

				' Round 1 - Category 2 - Topics
				If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round1/topics2.txt") Then
					' Final Challenge Category
					Dim sr As New StreamReader("./Game" + nudGameNo.Value.ToString() + "/Round1/topics2.txt")
					strLine = WebUtility.UrlDecode(sr.ReadLine)

					nvcDecoded = HttpUtility.ParseQueryString(strLine)

					' Assign the value to the appropriate textbox.
					txtR1Cat2A.Text = FancyTrim(nvcDecoded("topic1"))
					txtR1Cat2B.Text = FancyTrim(nvcDecoded("topic2"))
					txtR1Cat2C.Text = FancyTrim(nvcDecoded("topic3"))

					' Release the file
					sr.Close()
				End If

				' Round 1 - Category 3 - Topics
				If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round1/topics3.txt") Then
					' Final Challenge Category
					Dim sr As New StreamReader("./Game" + nudGameNo.Value.ToString() + "/Round1/topics3.txt")
					strLine = WebUtility.UrlDecode(sr.ReadLine)

					nvcDecoded = HttpUtility.ParseQueryString(strLine)

					' Assign the value to the appropriate textbox.
					txtR1Cat3A.Text = FancyTrim(nvcDecoded("topic1"))
					txtR1Cat3B.Text = FancyTrim(nvcDecoded("topic2"))
					txtR1Cat3C.Text = FancyTrim(nvcDecoded("topic3"))

					' Release the file
					sr.Close()
				End If

				' Round 1 - Category 4 - Topics
				If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round1/topics4.txt") Then
					' Final Challenge Category
					Dim sr As New StreamReader("./Game" + nudGameNo.Value.ToString() + "/Round1/topics4.txt")
					strLine = WebUtility.UrlDecode(sr.ReadLine)

					nvcDecoded = HttpUtility.ParseQueryString(strLine)

					' Assign the value to the appropriate textbox.
					txtR1Cat4A.Text = FancyTrim(nvcDecoded("topic1"))
					txtR1Cat4B.Text = FancyTrim(nvcDecoded("topic2"))
					txtR1Cat4C.Text = FancyTrim(nvcDecoded("topic3"))

					' Release the file
					sr.Close()
				End If

				' Round 1 - Category 5 - Topics
				If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round1/topics5.txt") Then
					' Final Challenge Category
					Dim sr As New StreamReader("./Game" + nudGameNo.Value.ToString() + "/Round1/topics5.txt")
					strLine = WebUtility.UrlDecode(sr.ReadLine)

					nvcDecoded = HttpUtility.ParseQueryString(strLine)

					' Assign the value to the appropriate textbox.
					txtR1Cat5A.Text = FancyTrim(nvcDecoded("topic1"))
					txtR1Cat5B.Text = FancyTrim(nvcDecoded("topic2"))
					txtR1Cat5C.Text = FancyTrim(nvcDecoded("topic3"))

					' Release the file
					sr.Close()
				End If


				' Round 1 - Category 6 - Topics
				If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round1/topics6.txt") Then
					' Final Challenge Category
					Dim sr As New StreamReader("./Game" + nudGameNo.Value.ToString() + "/Round1/topics6.txt")
					strLine = WebUtility.UrlDecode(sr.ReadLine)

					nvcDecoded = HttpUtility.ParseQueryString(strLine)

					' Assign the value to the appropriate textbox.
					txtR1Cat6A.Text = FancyTrim(nvcDecoded("topic1"))
					txtR1Cat6B.Text = FancyTrim(nvcDecoded("topic2"))
					txtR1Cat6C.Text = FancyTrim(nvcDecoded("topic3"))

					' Release the file
					sr.Close()
				End If
			End If

			If blnRound2Exists Then
				' Round 2 - Categories
				If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round2/categories.txt") Then
					' Final Challenge Category
					Dim sr As New StreamReader("./Game" + nudGameNo.Value.ToString() + "/Round2/categories.txt")
					strLine = WebUtility.UrlDecode(sr.ReadLine)

					nvcDecoded = HttpUtility.ParseQueryString(strLine)

					' Assign the value to the appropriate textbox.
					txtR2Cat1.Text = FancyTrim(nvcDecoded("category1"))
					txtR2Cat2.Text = FancyTrim(nvcDecoded("category2"))
					txtR2Cat3.Text = FancyTrim(nvcDecoded("category3"))
					txtR2Cat4.Text = FancyTrim(nvcDecoded("category4"))
					txtR2Cat5.Text = FancyTrim(nvcDecoded("category5"))
					txtR2Cat6.Text = FancyTrim(nvcDecoded("category6"))

					' Release the file
					sr.Close()
				End If

				' Round 2 - Category 1 - Topics
				If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round2/topics1.txt") Then
					' Final Challenge Category
					Dim sr As New StreamReader("./Game" + nudGameNo.Value.ToString() + "/Round2/topics1.txt")
					strLine = WebUtility.UrlDecode(sr.ReadLine)

					nvcDecoded = HttpUtility.ParseQueryString(strLine)

					' Assign the value to the appropriate textbox.
					txtR2Cat1A.Text = FancyTrim(nvcDecoded("topic1"))
					txtR2Cat1B.Text = FancyTrim(nvcDecoded("topic2"))
					txtR2Cat1C.Text = FancyTrim(nvcDecoded("topic3"))

					' Release the file
					sr.Close()
				End If

				' Round 2 - Category 2 - Topics
				If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round2/topics2.txt") Then
					' Final Challenge Category
					Dim sr As New StreamReader("./Game" + nudGameNo.Value.ToString() + "/Round2/topics2.txt")
					strLine = WebUtility.UrlDecode(sr.ReadLine)

					nvcDecoded = HttpUtility.ParseQueryString(strLine)

					' Assign the value to the appropriate textbox.
					txtR2Cat2A.Text = FancyTrim(nvcDecoded("topic1"))
					txtR2Cat2B.Text = FancyTrim(nvcDecoded("topic2"))
					txtR2Cat2C.Text = FancyTrim(nvcDecoded("topic3"))

					' Release the file
					sr.Close()
				End If

				' Round 2 - Category 3 - Topics
				If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round2/topics3.txt") Then
					' Final Challenge Category
					Dim sr As New StreamReader("./Game" + nudGameNo.Value.ToString() + "/Round2/topics3.txt")
					strLine = WebUtility.UrlDecode(sr.ReadLine)

					nvcDecoded = HttpUtility.ParseQueryString(strLine)

					' Assign the value to the appropriate textbox.
					txtR2Cat3A.Text = FancyTrim(nvcDecoded("topic1"))
					txtR2Cat3B.Text = FancyTrim(nvcDecoded("topic2"))
					txtR2Cat3C.Text = FancyTrim(nvcDecoded("topic3"))

					' Release the file
					sr.Close()
				End If

				' Round 2 - Category 4 - Topics
				If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round2/topics4.txt") Then
					' Final Challenge Category
					Dim sr As New StreamReader("./Game" + nudGameNo.Value.ToString() + "/Round2/topics4.txt")
					strLine = WebUtility.UrlDecode(sr.ReadLine)

					nvcDecoded = HttpUtility.ParseQueryString(strLine)

					' Assign the value to the appropriate textbox.
					txtR2Cat4A.Text = FancyTrim(nvcDecoded("topic1"))
					txtR2Cat4B.Text = FancyTrim(nvcDecoded("topic2"))
					txtR2Cat4C.Text = FancyTrim(nvcDecoded("topic3"))

					' Release the file
					sr.Close()
				End If

				' Round 2 - Category 5 - Topics
				If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round2/topics5.txt") Then
					' Final Challenge Category
					Dim sr As New StreamReader("./Game" + nudGameNo.Value.ToString() + "/Round2/topics5.txt")
					strLine = WebUtility.UrlDecode(sr.ReadLine)

					nvcDecoded = HttpUtility.ParseQueryString(strLine)

					' Assign the value to the appropriate textbox.
					txtR2Cat5A.Text = FancyTrim(nvcDecoded("topic1"))
					txtR2Cat5B.Text = FancyTrim(nvcDecoded("topic2"))
					txtR2Cat5C.Text = FancyTrim(nvcDecoded("topic3"))

					' Release the file
					sr.Close()
				End If


				' Round 2 - Category 6 - Topics
				If File.Exists("./Game" + nudGameNo.Value.ToString() + "/Round2/topics6.txt") Then
					' Final Challenge Category
					Dim sr As New StreamReader("./Game" + nudGameNo.Value.ToString() + "/Round2/topics6.txt")
					strLine = WebUtility.UrlDecode(sr.ReadLine)

					nvcDecoded = HttpUtility.ParseQueryString(strLine)

					' Assign the value to the appropriate textbox.
					txtR2Cat6A.Text = FancyTrim(nvcDecoded("topic1"))
					txtR2Cat6B.Text = FancyTrim(nvcDecoded("topic2"))
					txtR2Cat6C.Text = FancyTrim(nvcDecoded("topic3"))

					' Release the file
					sr.Close()
				End If

			End If
        End If

    End Sub

	Private Sub btnToUpper_Click(sender As Object, e As EventArgs) Handles btnToUpper.Click
		' Change ALL forms into UPPER CASE
		Dim arrTextboxes As TextBox() = {txtR1Cat6C, txtR1Cat6B, txtR1Cat6A, txtR1Cat6, txtR1Cat5C, txtR1Cat5B, txtR1Cat5A, txtR1Cat5, txtR1Cat4C, txtR1Cat4B, txtR1Cat4A, txtR1Cat4, txtR1Cat3C, txtR1Cat3B, txtR1Cat3A, txtR1Cat3, txtR1Cat2C, txtR1Cat2B, txtR1Cat2A, txtR1Cat2, txtR1Cat1C, txtR1Cat1B, txtR1Cat1A, txtR1Cat1, txtR2Cat6C, txtR2Cat6B, txtR2Cat6A, txtR2Cat6, txtR2Cat5C, txtR2Cat5B, txtR2Cat5A, txtR2Cat5, txtR2Cat4C, txtR2Cat4B, txtR2Cat4A, txtR2Cat4, txtR2Cat3C, txtR2Cat3B, txtR2Cat3A, txtR2Cat3, txtR2Cat2C, txtR2Cat2B, txtR2Cat2A, txtR2Cat2, txtR2Cat1C, txtR2Cat1B, txtR2Cat1A, txtR2Cat1, txtFCatC, txtFCatB, txtFCatA, txtFCat}
		
		For Each item in arrTextboxes
			item.Text = item.Text.ToUpper()
		Next
		
	End Sub
	Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
		ClearTextboxes()
	End Sub

	Private Sub ClearTextboxes()
		' Loop through every textbox and clear it.

		Dim arrTextboxes As TextBox() = {txtR1Cat6C, txtR1Cat6B, txtR1Cat6A, txtR1Cat6, txtR1Cat5C, txtR1Cat5B, txtR1Cat5A, txtR1Cat5, txtR1Cat4C, txtR1Cat4B, txtR1Cat4A, txtR1Cat4, txtR1Cat3C, txtR1Cat3B, txtR1Cat3A, txtR1Cat3, txtR1Cat2C, txtR1Cat2B, txtR1Cat2A, txtR1Cat2, txtR1Cat1C, txtR1Cat1B, txtR1Cat1A, txtR1Cat1, txtR2Cat6C, txtR2Cat6B, txtR2Cat6A, txtR2Cat6, txtR2Cat5C, txtR2Cat5B, txtR2Cat5A, txtR2Cat5, txtR2Cat4C, txtR2Cat4B, txtR2Cat4A, txtR2Cat4, txtR2Cat3C, txtR2Cat3B, txtR2Cat3A, txtR2Cat3, txtR2Cat2C, txtR2Cat2B, txtR2Cat2A, txtR2Cat2, txtR2Cat1C, txtR2Cat1B, txtR2Cat1A, txtR2Cat1, txtFCatC, txtFCatB, txtFCatA, txtFCat}

		For Each item In arrTextboxes
			item.Clear()
		Next

	End Sub

	Private Sub btnHowToUse_Click(sender As Object, e As EventArgs) Handles btnHowToUse.Click

		' MessageBox.Show("This program allows you to create Game Files (and the needed directories) for ""The Challengers"" game show control program." + vbNewLine + vbNewLine + "To start, you will need to create six categories for each of the two rounds and three topics for each category. For a total of 12 Categories and 36 Topic questions plus a category and three additional topics for the final." + vbNewLine + vbNewLine + "Simply enter the NAME of the category and the NAME of the topic to be asked. You are limited to a total of 40 characters for a Category name and 32 characters for a topic name." + vbNewLine + vbNewLine+ "To fit in line with the actual show: the easier the question, the less value it's worth. However, you're not beholdened to that rule." + vbNewLine + vbNewLine + "To change rounds: Click the ""tab"" at the top of the program to change over. Your work on Round 1 and Round 2 are separate." + vbNewLine + vbNewLine + "When you're ready to save, pick a number from the selector and click SAVE GAME. " + vbNewLine + vbNewLine + "NOTE: If there already is a game with that number, the program will not let you proceed unless you click the overwrite checkbox and then click save." + vbNewLine + vbNewLine + "When you're all set, load ""The Challengers"" game control software to check your results.", "Instructions for using the program", MessageBoxButtons.OK, MessageBoxIcon.Information)
		Using frmHowToUse As New frmDialog
			frmHowToUse.txtMain.Text = "This program allows you to create Game Files (and the needed directories) for ""The Challengers"" game show control program." + vbNewLine + vbNewLine + "To start, you will need to create six categories for each of the two rounds and three topics for each category. For a total of 12 Categories and 36 Topic questions plus a category and three additional topics for the final." + vbNewLine + vbNewLine + "Simply enter the NAME of the category and the NAME of the topic to be asked. You are limited to a total of 40 characters for a Category name and 32 characters for a topic name." + vbNewLine + vbNewLine+ "To fit in line with the actual show: the easier the question, the less value it's worth. However, you're not beholdened to that rule." + vbNewLine + vbNewLine + "To change rounds: Click the ""tab"" at the top of the program to change over. Your work on Round 1 and Round 2 are separate." + vbNewLine + vbNewLine + "When you're ready to save, pick a number from the selector and click SAVE GAME. " + vbNewLine + vbNewLine + "NOTE: If there already is a game with that number, the program will not let you proceed unless you click the overwrite checkbox and then click save." + vbNewLine + vbNewLine + "When you're all set, load ""The Challengers"" game control software to check your results."  + vbNewLine + vbNewLine +"==================" + vbNewLine + "To OPEN a file, type it's game number in the directory where prompted for a game number. (Example to Open /Game6/ enter 6 for game number.) The program will open the file as best as possible."
			frmHowToUse.Text = "How to Use This Program"
			
			frmHowToUse.ShowDialog()
		End Using
		
		
	End Sub

	Private Sub btnGameShowRules_Click(sender As Object, e As EventArgs) Handles btnGameShowRules.Click
		'MessageBox.Show("The game of The Challengers first starts off with a 60 second sprint. Depending on preference, you can either start the players off with $200 or $0 as their base score. During this round, the host will read questions and let the players buzz-in using their buzzers. For every correct answer, add $100. Deduct $100 for every wrong answer. The player in the lead after the 60 seconds, finish the last question if interrupted by the timer, gains control of Round 1's first category selection. In the event of a tie, break the tie by asking another question (worth $100)." + vbNewLine + vbNewLine + "Round 1 and Round 2 starts off with the introduction of the six categories of the round. The player who is in the lead after ""The Challengers Sprint"" will select the first category. (After this, the last player to get an answer correct will control board.) Behind that one category, are three topics (each with one question). The players will use their marking devices in secret (or cue cards if not using the device) to select their topic. If each player chooses separate topics, start with the player who chose the lowest value question and then proceed down the line asking each player a question. Correct answers add to a player's score, wrong answer deduct. If two players choose the same question, the question is played as a toss-up between the two. If three players choose the same question, the category is a toss-up between all three players. Additionally, the values of the category are doubled if all three players choose the same. After one player breaks that 3-way toss up, they have the option to continue the category and win more money for each correct answer or stop. (They'll be stopped on a wrong answer if they continue.)" + vbNewLine +vbNewLine + "Round 1 and Round 2 are played the same way, but values are doubled in Round 2." + vbNewLine + vbNewLine + "At the end of Round 2, any player with $0 or lower are eliminated from playing." + vbNewLine + vbNewLine + "For the Final Challenge: the players will be shown the category and then three possible choices of topic. The players will be asked to wager their score and choose a topic. If more than one player chooses one topic, the player that wagers more will be asked the question. If the player answers correctly, they will win a bonus based on their wager and the topic chosen. (Even money, double money, or triple money depending on their category.)" + vbNewLine + vbNewLine + "The player who has the most money at the end of the round, shall be considered the champion." + vbNewLine + vbNewLine + "Special Rule: If a player enters the Final Challenge by themself, they may continue to wager on the additional topics until they are wrong.", "Playing the Game", MessageBoxButtons.OK, MessageBoxIcon.Information)
		Using frmHowToPlay As New frmDialog
			frmHowToPlay.txtMain.Text = "The game of The Challengers first starts off with a 60 second sprint. Depending on preference, you can either start the players off with $200 or $0 as their base score. During this round, the host will read questions and let the players buzz-in using their buzzers. For every correct answer, add $100. Deduct $100 for every wrong answer. The player in the lead after the 60 seconds, finish the last question if interrupted by the timer, gains control of Round 1's first category selection. In the event of a tie, break the tie by asking another question (worth $100)." + vbNewLine + vbNewLine + "Round 1 and Round 2 starts off with the introduction of the six categories of the round. The player who is in the lead after ""The Challengers Sprint"" will select the first category in Round 1. (After this, the last player to get an answer correct will control the category selection next.) Behind that one category, are three topics (each with one question). The players will use their devices in secret (or cue cards if not using the devices) to select their topic." + vbNewLine + vbNewLine + "If each player chooses separate topics, start with the player who chose the lowest valued question and then proceed down the line asking each player their respective question. Correct answers add to a player's score, wrong answer deduct. " + vbNewLine + vbNewLine + "If two players choose the same question, the question is played as a toss-up between the two. If three players choose the same question, the category is a toss-up between all three players. Additionally, the values of the category are doubled if all three players choose the same topic to play. After one player breaks that 3-way toss up, they have the option to continue the category and win more money for each correct answer or stop. (The category will end when either that player gets a question wrong or they choose to stop.)" + vbNewLine +vbNewLine + "Round 1 and Round 2 are played the same way, but values are doubled in Round 2." + vbNewLine + vbNewLine + "At the end of Round 2, any player with $0 or lower are eliminated from playing." + vbNewLine + vbNewLine + "For the Final Challenge: the players will be shown the category and then three possible choices of topic. The players will be asked to wager their score and choose a topic. If more than one player chooses one topic, the player that wagers more will be asked the question. If the player answers correctly, they will win a bonus based on their wager and the topic chosen. (Even money, double money, or triple money depending on their category.)" + vbNewLine + vbNewLine + "The player who has the most money at the end of the round, shall be considered the champion." + vbNewLine + vbNewLine + "Special Rule: If a player enters the Final Challenge by themself, they may continue to wager on the additional topics until they are wrong."
			frmHowToPlay.Text = "How to Play The Game"
			
			frmHowToPlay.ShowDialog()
		End Using
	End Sub

End Class
