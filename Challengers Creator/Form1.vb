Imports System.Collections.Specialized
Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Web

Public Class frmMain
    Dim txtCurrentDirectory As String = Directory.GetCurrentDirectory
    Dim strVersion As String = My.Application.Info.Version.ToString

    Private Sub txtR1Cat1_TextChanged_1(sender As Object, e As EventArgs) Handles txtR1Cat3F.TextChanged, txtR1Cat2F.TextChanged, txtR1Cat1F.TextChanged, txtR1Cat6.TextChanged, txtR1Cat3E.TextChanged, txtR1Cat2E.TextChanged, txtR1Cat1E.TextChanged, txtR1Cat5.TextChanged, txtR1Cat3D.TextChanged, txtR1Cat2D.TextChanged, txtR1Cat1D.TextChanged, txtR1Cat4.TextChanged, txtR1Cat3C.TextChanged, txtR1Cat2C.TextChanged, txtR1Cat1C.TextChanged, txtR1Cat3.TextChanged, txtR1Cat3C.TextChanged, txtR1Cat2C.TextChanged, txtR1Cat1C.TextChanged, txtR1Cat2.TextChanged, txtR1Cat3A.TextChanged, txtR1Cat2A.TextChanged, txtR1Cat1A.TextChanged, txtR1Cat1.TextChanged, txtR2Cat3F.TextChanged, txtR2Cat2F.TextChanged, txtR2Cat1F.TextChanged, txtR2Cat6.TextChanged, txtR2Cat3E.TextChanged, txtR2Cat2E.TextChanged, txtR2Cat1E.TextChanged, txtR2Cat5.TextChanged, txtR2Cat3D.TextChanged, txtR2Cat2D.TextChanged, txtR2Cat1D.TextChanged, txtR2Cat4.TextChanged, txtR2Cat3C.TextChanged, txtR2Cat2C.TextChanged, txtR2Cat1C.TextChanged, txtR2Cat3.TextChanged, txtR2Cat3C.TextChanged, txtR2Cat2C.TextChanged, txtR2Cat1C.TextChanged, txtR2Cat2.TextChanged, txtR2Cat3A.TextChanged, txtR2Cat2A.TextChanged, txtR2Cat1A.TextChanged, txtR2Cat1.TextChanged, txtFCat3.TextChanged, txtFCat2.TextChanged, txtFCat1.TextChanged, txtFCat.TextChanged, txtUltCat1.TextChanged, txtUltCatA1.TextChanged, txtUltCatA2.TextChanged, txtUltCatA3.TextChanged, txtUltCat2.TextChanged, txtUltCatB1.TextChanged, txtUltCatB2.TextChanged, txtUltCatB3.TextChanged, txtR1Cat3B.TextChanged, txtR1Cat2B.TextChanged, txtR1Cat1B.TextChanged
        Dim arrTextboxes As TextBox() = {txtR1Cat3F, txtR1Cat2F, txtR1Cat1F, txtR1Cat6, txtR1Cat3E, txtR1Cat2E, txtR1Cat1E, txtR1Cat5, txtR1Cat3D, txtR1Cat2D, txtR1Cat1D, txtR1Cat4, txtR1Cat3C, txtR1Cat2C, txtR1Cat1C, txtR1Cat3, txtR1Cat3B, txtR1Cat2B, txtR1Cat1B, txtR1Cat2, txtR1Cat3A, txtR1Cat2A, txtR1Cat1A, txtR1Cat1, txtR2Cat3F, txtR2Cat2F, txtR2Cat1F, txtR2Cat6, txtR2Cat3E, txtR2Cat2E, txtR2Cat1E, txtR2Cat5, txtR2Cat3D, txtR2Cat2D, txtR2Cat1D, txtR2Cat4, txtR2Cat3C, txtR2Cat2C, txtR2Cat1C, txtR2Cat3, txtR2Cat3B, txtR2Cat2B, txtR2Cat1B, txtR2Cat2, txtR2Cat3A, txtR2Cat2A, txtR2Cat1A, txtR2Cat1, txtFCat3, txtFCat2, txtFCat1, txtFCat, txtUltCat1, txtUltCatA1, txtUltCatA2, txtUltCatA3, txtUltCat2, txtUltCatB1, txtUltCatB2, txtUltCatB3}

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
        Dim blnBaseExists As Boolean = Directory.Exists(Directory.GetCurrentDirectory() + "/Game" + nudGameNo.Text.ToString())

        If blnBaseExists = False Then Directory.CreateDirectory("./Game" + nudGameNo.Text.ToString())

        ' First things first, try to create a directory named "GameX" where X is the number from the numeric up down.
        ' If you can't make it, that means the directory already has a game file in it. STOP unless Overwrite is given.
        If blnBaseExists And cbOverwrite.Checked = False Then
            MessageBox.Show("Cannot create directory:" + vbNewLine + Directory.GetCurrentDirectory() + "\Game" + nudGameNo.Text.ToString + vbNewLine + vbNewLine + "It might already exist. If you want to overwrite this, click the ""Overwrite?"" Checkbox and try again", "Cannot create new game directory.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            Try
                If rbVersion1.Checked Then
                    Dim blnFinalExists As Boolean = Directory.Exists(Directory.GetCurrentDirectory() + "/Game" + nudGameNo.Text.ToString() + "/Final")
                    Dim blnRound1Exists As Boolean = Directory.Exists(Directory.GetCurrentDirectory() + "/Game" + nudGameNo.Text.ToString() + "/Round1")
                    Dim blnRound2Exists As Boolean = Directory.Exists(Directory.GetCurrentDirectory() + "/Game" + nudGameNo.Text.ToString() + "/Round2")
                    Dim blnUltimateExists As Boolean = Directory.Exists(Directory.GetCurrentDirectory() + "/Game" + nudGameNo.Text.ToString() + "/Ultimate")

                    ' Create the base, /Final, /Round1 and /Round2 directories. If need be
                    If blnFinalExists = False Then Directory.CreateDirectory("./Game" + nudGameNo.Text.ToString() + "/Final")
                    If blnRound1Exists = False Then Directory.CreateDirectory("./Game" + nudGameNo.Text.ToString() + "/Round1")
                    If blnRound2Exists = False Then Directory.CreateDirectory("./Game" + nudGameNo.Text.ToString() + "/Round2")
                    If blnUltimateExists = False Then Directory.CreateDirectory("./Game" + nudGameNo.Text.ToString() + "/Ultimate")

                    ' Final Challenge - Category
                    Dim sw As New StreamWriter("./Game" + nudGameNo.Text.ToString() + "/Final/category.txt", False)
                    sw.Write("category=" + WebUtility.UrlEncode(FancyTrim(txtFCat.Text)) + "&")
                    sw.Close()

                    ' Final Challenge - Topics
                    sw = New StreamWriter("./Game" + nudGameNo.Text.ToString() + "/Final/topics.txt", False)
                    sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtFCat1.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtFCat2.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtFCat3.Text)) + "&")
                    sw.Close()

                    ' Round 1 - Categories
                    sw = New StreamWriter("./Game" + nudGameNo.Text.ToString() + "/Round1/categories.txt", False)
                    sw.Write("category1=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat1.Text)) + "&category2=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat2.Text)) + "&category3=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat3.Text)) + "&category4=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat4.Text)) + "&category5=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat5.Text)) + "&category6=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat6.Text)) + "&")
                    sw.Close()

                    ' Round 1 - Category 1 Topics
                    sw = New StreamWriter("./Game" + nudGameNo.Text.ToString() + "/Round1/topics1.txt", False)
                    sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat1A.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat2A.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat3A.Text)) + "&")
                    sw.Close()

                    ' Round 1 - Category 2 Topics
                    sw = New StreamWriter("./Game" + nudGameNo.Text.ToString() + "/Round1/topics2.txt", False)
                    sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat1C.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat2C.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat3C.Text)) + "&")
                    sw.Close()

                    ' Round 1 - Category 3 Topics
                    sw = New StreamWriter("./Game" + nudGameNo.Text.ToString() + "/Round1/topics3.txt", False)
                    sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat1C.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat2C.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat3C.Text)) + "&")
                    sw.Close()

                    ' Round 1 - Category 4 Topics
                    sw = New StreamWriter("./Game" + nudGameNo.Text.ToString() + "/Round1/topics4.txt", False)
                    sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat1D.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat2D.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat3D.Text)) + "&")
                    sw.Close()

                    ' Round 1 - Category 5 Topics
                    sw = New StreamWriter("./Game" + nudGameNo.Text.ToString() + "/Round1/topics5.txt", False)
                    sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat1E.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat2E.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat3E.Text)) + "&")
                    sw.Close()

                    ' Round 1 - Category 6 Topics
                    sw = New StreamWriter("./Game" + nudGameNo.Text.ToString() + "/Round1/topics6.txt", False)
                    sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat1F.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat2F.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat3F.Text)) + "&")
                    sw.Close()

                    ' Round 2 - Categories
                    sw = New StreamWriter("./Game" + nudGameNo.Text.ToString() + "/Round2/categories.txt", False)
                    sw.Write("category1=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat1.Text)) + "&category2=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat2.Text)) + "&category3=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat3.Text)) + "&category4=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat4.Text)) + "&category5=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat5.Text)) + "&category6=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat6.Text)) + "&")
                    sw.Close()

                    ' Round 2 - Category 1 Topics
                    sw = New StreamWriter("./Game" + nudGameNo.Text.ToString() + "/Round2/topics1.txt", False)
                    sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat1A.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat2A.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat3A.Text)) + "&")
                    sw.Close()

                    ' Round 2 - Category 2 Topics
                    sw = New StreamWriter("./Game" + nudGameNo.Text.ToString() + "/Round2/topics2.txt", False)
                    sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat1C.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat2C.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat3C.Text)) + "&")
                    sw.Close()

                    ' Round 2 - Category 3 Topics
                    sw = New StreamWriter("./Game" + nudGameNo.Text.ToString() + "/Round2/topics3.txt", False)
                    sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat1C.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat2C.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat3C.Text)) + "&")
                    sw.Close()

                    ' Round 2 - Category 4 Topics
                    sw = New StreamWriter("./Game" + nudGameNo.Text.ToString() + "/Round2/topics4.txt", False)
                    sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat1D.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat2D.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat3D.Text)) + "&")
                    sw.Close()

                    ' Round 2 - Category 5 Topics
                    sw = New StreamWriter("./Game" + nudGameNo.Text.ToString() + "/Round2/topics5.txt", False)
                    sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat1E.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat2E.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat3E.Text)) + "&")
                    sw.Close()

                    ' Round 2 - Category 6 Topics
                    sw = New StreamWriter("./Game" + nudGameNo.Text.ToString() + "/Round2/topics6.txt", False)
                    sw.Write("topic1=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat1F.Text)) + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat2F.Text)) + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat3F.Text)) + "&")
                    sw.Close()

                    ' Ultimate Challenge Topics
                    sw = New StreamWriter("./Game" + nudGameNo.Text.ToString() + "/Ultimate/category.txt", False)
                    sw.Write("category1=" + WebUtility.UrlEncode(FancyTrim(txtUltCat1.Text)) + "&category2=" + WebUtility.UrlEncode(FancyTrim(txtUltCat2.Text)) + "&")
                    sw.Close()

                    sw = New StreamWriter("./Game" + nudGameNo.Text.ToString() + "/Ultimate/topics.txt", False)
                    sw.Write("topicA1=" + WebUtility.UrlEncode(FancyTrim(txtUltCatA1.Text)) + "&topicA2=" + WebUtility.UrlEncode(FancyTrim(txtUltCatA2.Text)) + "&topicA3=" + WebUtility.UrlEncode(FancyTrim(txtUltCatA3.Text)) + "&topicB1=" + WebUtility.UrlEncode(FancyTrim(txtUltCatB1.Text)) + "&topicB2=" + WebUtility.UrlEncode(FancyTrim(txtUltCatB2.Text)) + "&topicB3=" + WebUtility.UrlEncode(FancyTrim(txtUltCatB3.Text)) + "&")
                    sw.Close()

                    MessageBox.Show("Game data files created successfully! (2022 Version)", "Save files OK", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    ' This means rbVersion2.Checked is True and should proceed.
                    ' Only two directories exist in the game folder, make those folders unless they already exist.

                    Dim blnR1MediaExists As Boolean = Directory.Exists(Directory.GetCurrentDirectory() + "/Game" + nudGameNo.Text.ToString() + "/R1MEDIA")
                    Dim blnR2MediaExists As Boolean = Directory.Exists(Directory.GetCurrentDirectory() + "/Game" + nudGameNo.Text.ToString() + "/R2MEDIA")

                    If blnR1MediaExists = False Then Directory.CreateDirectory("./Game" + nudGameNo.Text.ToString() + "/R1MEDIA")
                    If blnR2MediaExists = False Then Directory.CreateDirectory("./Game" + nudGameNo.Text.ToString() + "/R2MEDIA")


                    Dim strR1Cat1Multimedia, strR1Cat2Multimedia, strR1Cat3Multimedia, strR1Cat4Multimedia, strR1Cat5Multimedia, strR1Cat6Multimedia As String
                    Dim strR2Cat1Multimedia, strR2Cat2Multimedia, strR2Cat3Multimedia, strR2Cat4Multimedia, strR2Cat5Multimedia, strR2Cat6Multimedia As String

                    Select Case True
                        Case rbR1Cat1Picture.Checked
                            strR1Cat1Multimedia = "PIX"
                        Case rbR1Cat1Audio.Checked
                            strR1Cat1Multimedia = "AUDIO"
                        Case rbR1Cat1Video.Checked
                            strR1Cat1Multimedia = "VIDEO"
                        Case rbR1Cat1Normal.Checked
                            strR1Cat1Multimedia = "NO"
                    End Select

                    Select Case True
                        Case rbR1Cat2Picture.Checked
                            strR1Cat2Multimedia = "PIX"
                        Case rbR1Cat2Audio.Checked
                            strR1Cat2Multimedia = "AUDIO"
                        Case rbR1Cat2Video.Checked
                            strR1Cat2Multimedia = "VIDEO"
                        Case rbR1Cat2Normal.Checked
                            strR1Cat2Multimedia = "NO"
                    End Select

                    Select Case True
                        Case rbR1Cat3Picture.Checked
                            strR1Cat3Multimedia = "PIX"
                        Case rbR1Cat3Audio.Checked
                            strR1Cat3Multimedia = "AUDIO"
                        Case rbR1Cat3Video.Checked
                            strR1Cat3Multimedia = "VIDEO"
                        Case rbR1Cat3Normal.Checked
                            strR1Cat3Multimedia = "NO"
                    End Select

                    Select Case True
                        Case rbR1Cat4Picture.Checked
                            strR1Cat4Multimedia = "PIX"
                        Case rbR1Cat4Audio.Checked
                            strR1Cat4Multimedia = "AUDIO"
                        Case rbR1Cat4Video.Checked
                            strR1Cat4Multimedia = "VIDEO"
                        Case rbR1Cat4Normal.Checked
                            strR1Cat4Multimedia = "NO"
                    End Select

                    Select Case True
                        Case rbR1Cat5Picture.Checked
                            strR1Cat5Multimedia = "PIX"
                        Case rbR1Cat5Audio.Checked
                            strR1Cat5Multimedia = "AUDIO"
                        Case rbR1Cat5Video.Checked
                            strR1Cat5Multimedia = "VIDEO"
                        Case rbR1Cat5Normal.Checked
                            strR1Cat5Multimedia = "NO"
                    End Select

                    Select Case True
                        Case rbR1Cat6Picture.Checked
                            strR1Cat6Multimedia = "PIX"
                        Case rbR1Cat6Audio.Checked
                            strR1Cat6Multimedia = "AUDIO"
                        Case rbR1Cat6Video.Checked
                            strR1Cat6Multimedia = "VIDEO"
                        Case rbR1Cat6Normal.Checked
                            strR1Cat6Multimedia = "NO"
                    End Select

                    Select Case True
                        Case rbR2Cat1Picture.Checked
                            strR2Cat1Multimedia = "PIX"
                        Case rbR2Cat1Audio.Checked
                            strR2Cat1Multimedia = "AUDIO"
                        Case rbR2Cat1Video.Checked
                            strR2Cat1Multimedia = "VIDEO"
                        Case rbR2Cat1Normal.Checked
                            strR2Cat1Multimedia = "NO"
                    End Select

                    Select Case True
                        Case rbR2Cat2Picture.Checked
                            strR2Cat2Multimedia = "PIX"
                        Case rbR2Cat2Audio.Checked
                            strR2Cat2Multimedia = "AUDIO"
                        Case rbR2Cat2Video.Checked
                            strR2Cat2Multimedia = "VIDEO"
                        Case rbR2Cat2Normal.Checked
                            strR2Cat2Multimedia = "NO"
                    End Select

                    Select Case True
                        Case rbR2Cat3Picture.Checked
                            strR2Cat3Multimedia = "PIX"
                        Case rbR2Cat3Audio.Checked
                            strR2Cat3Multimedia = "AUDIO"
                        Case rbR2Cat3Video.Checked
                            strR2Cat3Multimedia = "VIDEO"
                        Case rbR2Cat3Normal.Checked
                            strR2Cat3Multimedia = "NO"
                    End Select

                    Select Case True
                        Case rbR2Cat4Picture.Checked
                            strR2Cat4Multimedia = "PIX"
                        Case rbR2Cat4Audio.Checked
                            strR2Cat4Multimedia = "AUDIO"
                        Case rbR2Cat4Video.Checked
                            strR2Cat4Multimedia = "VIDEO"
                        Case rbR2Cat4Normal.Checked
                            strR2Cat4Multimedia = "NO"
                    End Select

                    Select Case True
                        Case rbR2Cat5Picture.Checked
                            strR2Cat5Multimedia = "PIX"
                        Case rbR2Cat5Audio.Checked
                            strR2Cat5Multimedia = "AUDIO"
                        Case rbR2Cat5Video.Checked
                            strR2Cat5Multimedia = "VIDEO"
                        Case rbR2Cat5Normal.Checked
                            strR2Cat5Multimedia = "NO"
                    End Select

                    Select Case True
                        Case rbR2Cat6Picture.Checked
                            strR2Cat6Multimedia = "PIX"
                        Case rbR2Cat6Audio.Checked
                            strR2Cat6Multimedia = "AUDIO"
                        Case rbR2Cat6Video.Checked
                            strR2Cat6Multimedia = "VIDEO"
                        Case rbR2Cat6Normal.Checked
                            strR2Cat6Multimedia = "NO"
                    End Select

                    Dim sw As StreamWriter

                    ' Write the Round 1 File
                    sw = New StreamWriter("./Game" + nudGameNo.Text.ToString() + "/r1.txt", False)
                    ' Categories
                    sw.WriteLine("&category1=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat1.Text)) + "&category2=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat2.Text)) + "&category3=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat3.Text)) + "&category4=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat4.Text)) + "&category5=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat5.Text)) + "&category6=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat6.Text)) + "&" + vbNewLine)


                    ' Topics      
                    sw.WriteLine("&topic1A=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat1A.Text)) + "&" + vbNewLine + "&topic2A=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat2A.Text)) + "&" + vbNewLine + "&topic3A=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat3A.Text)) + "&" + vbNewLine + "&multimediaA=" + strR1Cat1Multimedia + "&" + vbNewLine)
                    sw.WriteLine("&topic1B=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat1B.Text)) + "&" + vbNewLine + "&topic2B=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat2B.Text)) + "&" + vbNewLine + "&topic3B=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat3B.Text)) + "&" + vbNewLine + "&multimediaB=" + strR1Cat2Multimedia + "&" + vbNewLine)
                    sw.WriteLine("&topic1C=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat1C.Text)) + "&" + vbNewLine + "&topic2C=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat2C.Text)) + "&" + vbNewLine + "&topic3C=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat3C.Text)) + "&" + vbNewLine + "&multimediaC=" + strR1Cat3Multimedia + "&" + vbNewLine)
                    sw.WriteLine("&topic1D=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat1D.Text)) + "&" + vbNewLine + "&topic2D=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat2D.Text)) + "&" + vbNewLine + "&topic3D=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat3D.Text)) + "&" + vbNewLine + "&multimediaD=" + strR1Cat4Multimedia + "&" + vbNewLine)
                    sw.WriteLine("&topic1E=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat1E.Text)) + "&" + vbNewLine + "&topic2E=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat2E.Text)) + "&" + vbNewLine + "&topic3E=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat3E.Text)) + "&" + vbNewLine + "&multimediaE=" + strR1Cat5Multimedia + "&" + vbNewLine)
                    sw.WriteLine("&topic1F=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat1F.Text)) + "&" + vbNewLine + "&topic2F=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat2F.Text)) + "&" + vbNewLine + "&topic3F=" + WebUtility.UrlEncode(FancyTrim(txtR1Cat3F.Text)) + "&" + vbNewLine + "&multimediaF=" + strR1Cat6Multimedia + "&" + vbNewLine)

                    ' Close and write the file.
                    sw.Close()

                    ' Write the Round 2 File
                    sw = New StreamWriter("./Game" + nudGameNo.Text.ToString() + "/r2.txt", False)
                    ' Categories
                    sw.WriteLine("&category1=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat1.Text)) + "&category2=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat2.Text)) + "&category3=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat3.Text)) + "&category4=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat4.Text)) + "&category5=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat5.Text)) + "&category6=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat6.Text)) + "&" + vbNewLine)

                    ' Topics      
                    sw.WriteLine("&topic1A=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat1A.Text)) + "&" + vbNewLine + "&topic2A=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat2A.Text)) + "&" + vbNewLine + "&topic3A=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat3A.Text)) + "&" + vbNewLine + "&multimediaA=" + strR2Cat1Multimedia + "&" + vbNewLine)
                    sw.WriteLine("&topic1B=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat1B.Text)) + "&" + vbNewLine + "&topic2B=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat2B.Text)) + "&" + vbNewLine + "&topic3B=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat3B.Text)) + "&" + vbNewLine + "&multimediaB=" + strR2Cat2Multimedia + "&" + vbNewLine)
                    sw.WriteLine("&topic1C=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat1C.Text)) + "&" + vbNewLine + "&topic2C=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat2C.Text)) + "&" + vbNewLine + "&topic3C=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat3C.Text)) + "&" + vbNewLine + "&multimediaC=" + strR2Cat3Multimedia + "&" + vbNewLine)
                    sw.WriteLine("&topic1D=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat1D.Text)) + "&" + vbNewLine + "&topic2D=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat2D.Text)) + "&" + vbNewLine + "&topic3D=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat3D.Text)) + "&" + vbNewLine + "&multimediaD=" + strR2Cat4Multimedia + "&" + vbNewLine)
                    sw.WriteLine("&topic1E=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat1E.Text)) + "&" + vbNewLine + "&topic2E=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat2E.Text)) + "&" + vbNewLine + "&topic3E=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat3E.Text)) + "&" + vbNewLine + "&multimediaE=" + strR2Cat5Multimedia + "&" + vbNewLine)
                    sw.WriteLine("&topic1F=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat1F.Text)) + "&" + vbNewLine + "&topic2F=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat2F.Text)) + "&" + vbNewLine + "&topic3F=" + WebUtility.UrlEncode(FancyTrim(txtR2Cat3F.Text)) + "&" + vbNewLine + "&multimediaF=" + strR2Cat6Multimedia + "&" + vbNewLine)

                    ' Close and write the file.
                    sw.Close()

                    ' Write the Final Challenge File
                    sw = New StreamWriter("./Game" + nudGameNo.Text.ToString() + "/final.txt", False)
                    ' Categories
                    sw.WriteLine("&category=" + WebUtility.UrlEncode(FancyTrim(txtFCat.Text)) + "&" + vbNewLine + vbNewLine + "&topic1=" + WebUtility.UrlEncode(FancyTrim(txtFCat1.Text)) + "&" + vbNewLine + "&topic2=" + WebUtility.UrlEncode(FancyTrim(txtFCat2.Text)) + "&" + vbNewLine + "&topic3=" + WebUtility.UrlEncode(FancyTrim(txtFCat3.Text)) + "&" + vbNewLine)

                    ' Close and write the file.
                    sw.Close()

                    ' Write the Ultimate Challenge File
                    sw = New StreamWriter("./Game" + nudGameNo.Text.ToString() + "/ultimate.txt", False)
                    ' Categories
                    sw.WriteLine("&category1=" + WebUtility.UrlEncode(FancyTrim(txtUltCat1.Text)) + "&" + vbNewLine + vbNewLine + "&topicA1=" + WebUtility.UrlEncode(FancyTrim(txtUltCatA1.Text)) + "&" + vbNewLine + "&topicA2=" + WebUtility.UrlEncode(FancyTrim(txtUltCatA2.Text)) + "&" + vbNewLine + "&topicA3=" + WebUtility.UrlEncode(FancyTrim(txtUltCatA3.Text)) + "&" + vbNewLine)
                    sw.WriteLine("&category2=" + WebUtility.UrlEncode(FancyTrim(txtUltCat2.Text)) + "&" + vbNewLine + vbNewLine + "&topicB1=" + WebUtility.UrlEncode(FancyTrim(txtUltCatB1.Text)) + "&" + vbNewLine + "&topicB2=" + WebUtility.UrlEncode(FancyTrim(txtUltCatB2.Text)) + "&" + vbNewLine + "&topicB3=" + WebUtility.UrlEncode(FancyTrim(txtUltCatB3.Text)) + "&" + vbNewLine)

                    ' Close and write the file.
                    sw.Close()

                    MessageBox.Show("Game data files created successfully! (2023 Version)", "Save files OK", MessageBoxButtons.OK, MessageBoxIcon.Information)


                End If
            Catch ex As Exception
                MessageBox.Show("Ran into a problem with writing the file." + vbNewLine + vbNewLine + ex.ToString, "Problem writing the game data.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            ' Since the file was written successfully, set this directory to be the new "LastOutputDirectory" property.
            My.Settings.LastOutputDirectory = Directory.GetCurrentDirectory()
            My.Settings.Save()

        End If

    End Sub

    Public Function FancyTrim(strEntry As String, Optional blnDatabase As Boolean = False)
        If Not IsNothing(strEntry) Then

            strEntry = System.Text.RegularExpressions.Regex.Replace(strEntry, "\s+", " ").Trim

            If String.IsNullOrWhiteSpace(strEntry) Then
                Return IIf(blnDatabase = False, String.Empty, DBNull.Value)
            Else
                Return strEntry
            End If
        Else
            Return String.Empty
        End If
    End Function

    Private Sub btnOpenGame_Click(sender As Object, e As EventArgs) Handles btnOpenGame.Click
        ' Opening the game file. This is going to be tricky.

        ' We need to open the directory selected the number selector and make sure there is a /Final, /Round1, and /Round2 directories.
        Dim blnBaseExists As Boolean = Directory.Exists(Directory.GetCurrentDirectory() + "/Game" + nudGameNo.Text.ToString())
        Dim blnFinalExists As Boolean = Directory.Exists(Directory.GetCurrentDirectory() + "/Game" + nudGameNo.Text.ToString() + "/Final")
        Dim blnRound1Exists As Boolean = Directory.Exists(Directory.GetCurrentDirectory() + "/Game" + nudGameNo.Text.ToString() + "/Round1")
        Dim blnRound2Exists As Boolean = Directory.Exists(Directory.GetCurrentDirectory() + "/Game" + nudGameNo.Text.ToString() + "/Round2")
        Dim blnUltimateExists As Boolean = Directory.Exists(Directory.GetCurrentDirectory() + "/Game" + nudGameNo.Text.ToString() + "/Ultimate")

        Dim strLine As String
        Dim nvcDecoded As NameValueCollection

        Dim lstErrors As New List(Of String)

        If blnBaseExists = False Then
            MessageBox.Show("No game exists at the directory:" + vbNewLine + vbNewLine + Directory.GetCurrentDirectory() + "\Game" + nudGameNo.Text.ToString() + vbNewLine + vbNewLine + "Try to select another game number.", "Invalid Game File", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            ' Blank out all of the form details.
            ClearTextboxes()

            Try
                If rbVersion1.Checked Then

                    ' The directory exists! Try to go through and retrieve as much of the game as possible.
                    If blnFinalExists Then

                        ' Final Challenge - Category
                        If File.Exists("./Game" + nudGameNo.Text.ToString() + "/Final/category.txt") Then
                            ' Final Challenge Category
                            Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Text.ToString() + "/Final/category.txt")
                            strLine = WebUtility.UrlDecode(sr)

                            nvcDecoded = HttpUtility.ParseQueryString(strLine)

                            ' Assign the value to the appropriate textbox.
                            txtFCat.Text = FancyTrim(nvcDecoded("category"))
                        End If

                        ' Final Challenge - Topics
                        If File.Exists("./Game" + nudGameNo.Text.ToString() + "/Final/topics.txt") Then
                            Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Text.ToString() + "/Final/topics.txt")
                            strLine = WebUtility.UrlDecode(sr)

                            nvcDecoded = HttpUtility.ParseQueryString(strLine)

                            ' Assign the value to the appropriate textbox.
                            txtFCat1.Text = FancyTrim(nvcDecoded("topic1"))
                            txtFCat2.Text = FancyTrim(nvcDecoded("topic2"))
                            txtFCat3.Text = FancyTrim(nvcDecoded("topic3"))

                        End If
                    End If

                    If blnRound1Exists Then
                        ' Round 1 - Categories
                        If File.Exists("./Game" + nudGameNo.Text.ToString() + "/Round1/categories.txt") Then
                            Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Text.ToString() + "/Round1/categories.txt")
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
                        If File.Exists("./Game" + nudGameNo.Text.ToString() + "/Round1/topics1.txt") Then
                            Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Text.ToString() + "/Round1/topics1.txt")
                            strLine = WebUtility.UrlDecode(sr)

                            nvcDecoded = HttpUtility.ParseQueryString(strLine)

                            ' Assign the value to the appropriate textbox.
                            txtR1Cat1A.Text = FancyTrim(nvcDecoded("topic1"))
                            txtR1Cat2A.Text = FancyTrim(nvcDecoded("topic2"))
                            txtR1Cat3A.Text = FancyTrim(nvcDecoded("topic3"))

                            ' Release the file
                        End If

                        ' Round 1 - Category 2 - Topics
                        If File.Exists("./Game" + nudGameNo.Text.ToString() + "/Round1/topics2.txt") Then
                            Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Text.ToString() + "/Round1/topics2.txt")
                            strLine = WebUtility.UrlDecode(sr)

                            nvcDecoded = HttpUtility.ParseQueryString(strLine)

                            ' Assign the value to the appropriate textbox.
                            txtR1Cat1B.Text = FancyTrim(nvcDecoded("topic1"))
                            txtR1Cat2B.Text = FancyTrim(nvcDecoded("topic2"))
                            txtR1Cat3B.Text = FancyTrim(nvcDecoded("topic3"))

                        End If

                        ' Round 1 - Category 3 - Topics
                        If File.Exists("./Game" + nudGameNo.Text.ToString() + "/Round1/topics3.txt") Then
                            Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Text.ToString() + "/Round1/topics3.txt")
                            strLine = WebUtility.UrlDecode(sr)

                            nvcDecoded = HttpUtility.ParseQueryString(strLine)

                            ' Assign the value to the appropriate textbox.
                            txtR1Cat1C.Text = FancyTrim(nvcDecoded("topic1"))
                            txtR1Cat2C.Text = FancyTrim(nvcDecoded("topic2"))
                            txtR1Cat3C.Text = FancyTrim(nvcDecoded("topic3"))

                        End If

                        ' Round 1 - Category 4 - Topics
                        If File.Exists("./Game" + nudGameNo.Text.ToString() + "/Round1/topics4.txt") Then
                            Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Text.ToString() + "/Round1/topics4.txt")
                            strLine = WebUtility.UrlDecode(sr)

                            nvcDecoded = HttpUtility.ParseQueryString(strLine)

                            ' Assign the value to the appropriate textbox.
                            txtR1Cat1D.Text = FancyTrim(nvcDecoded("topic1"))
                            txtR1Cat2D.Text = FancyTrim(nvcDecoded("topic2"))
                            txtR1Cat3D.Text = FancyTrim(nvcDecoded("topic3"))

                        End If

                        ' Round 1 - Category 5 - Topics
                        If File.Exists("./Game" + nudGameNo.Text.ToString() + "/Round1/topics5.txt") Then
                            Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Text.ToString() + "/Round1/topics5.txt")
                            strLine = WebUtility.UrlDecode(sr)

                            nvcDecoded = HttpUtility.ParseQueryString(strLine)

                            ' Assign the value to the appropriate textbox.
                            txtR1Cat1E.Text = FancyTrim(nvcDecoded("topic1"))
                            txtR1Cat2E.Text = FancyTrim(nvcDecoded("topic2"))
                            txtR1Cat3E.Text = FancyTrim(nvcDecoded("topic3"))

                        End If


                        ' Round 1 - Category 6 - Topics
                        If File.Exists("./Game" + nudGameNo.Text.ToString() + "/Round1/topics6.txt") Then
                            Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Text.ToString() + "/Round1/topics6.txt")
                            strLine = WebUtility.UrlDecode(sr)

                            nvcDecoded = HttpUtility.ParseQueryString(strLine)

                            ' Assign the value to the appropriate textbox.
                            txtR1Cat1F.Text = FancyTrim(nvcDecoded("topic1"))
                            txtR1Cat2F.Text = FancyTrim(nvcDecoded("topic2"))
                            txtR1Cat3F.Text = FancyTrim(nvcDecoded("topic3"))

                        End If
                    End If

                    If blnRound2Exists Then
                        ' Round 2 - Categories
                        If File.Exists("./Game" + nudGameNo.Text.ToString() + "/Round2/categories.txt") Then
                            Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Text.ToString() + "/Round2/categories.txt")
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
                        If File.Exists("./Game" + nudGameNo.Text.ToString() + "/Round2/topics1.txt") Then
                            Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Text.ToString() + "/Round2/topics1.txt")
                            strLine = WebUtility.UrlDecode(sr)

                            nvcDecoded = HttpUtility.ParseQueryString(strLine)

                            ' Assign the value to the appropriate textbox.
                            txtR2Cat1A.Text = FancyTrim(nvcDecoded("topic1"))
                            txtR2Cat2A.Text = FancyTrim(nvcDecoded("topic2"))
                            txtR2Cat3A.Text = FancyTrim(nvcDecoded("topic3"))

                        End If

                        ' Round 2 - Category 2 - Topics
                        If File.Exists("./Game" + nudGameNo.Text.ToString() + "/Round2/topics2.txt") Then
                            Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Text.ToString() + "/Round2/topics2.txt")
                            strLine = WebUtility.UrlDecode(sr)

                            nvcDecoded = HttpUtility.ParseQueryString(strLine)

                            ' Assign the value to the appropriate textbox.
                            txtR2Cat1B.Text = FancyTrim(nvcDecoded("topic1"))
                            txtR2Cat2B.Text = FancyTrim(nvcDecoded("topic2"))
                            txtR2Cat3B.Text = FancyTrim(nvcDecoded("topic3"))

                        End If

                        ' Round 2 - Category 3 - Topics
                        If File.Exists("./Game" + nudGameNo.Text.ToString() + "/Round2/topics3.txt") Then
                            Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Text.ToString() + "/Round2/topics3.txt")
                            strLine = WebUtility.UrlDecode(sr)

                            nvcDecoded = HttpUtility.ParseQueryString(strLine)

                            ' Assign the value to the appropriate textbox.
                            txtR2Cat1C.Text = FancyTrim(nvcDecoded("topic1"))
                            txtR2Cat2C.Text = FancyTrim(nvcDecoded("topic2"))
                            txtR2Cat3C.Text = FancyTrim(nvcDecoded("topic3"))

                        End If

                        ' Round 2 - Category 4 - Topics
                        If File.Exists("./Game" + nudGameNo.Text.ToString() + "/Round2/topics4.txt") Then
                            Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Text.ToString() + "/Round2/topics4.txt")
                            strLine = WebUtility.UrlDecode(sr)

                            nvcDecoded = HttpUtility.ParseQueryString(strLine)

                            ' Assign the value to the appropriate textbox.
                            txtR2Cat1D.Text = FancyTrim(nvcDecoded("topic1"))
                            txtR2Cat2D.Text = FancyTrim(nvcDecoded("topic2"))
                            txtR2Cat3D.Text = FancyTrim(nvcDecoded("topic3"))

                        End If

                        ' Round 2 - Category 5 - Topics
                        If File.Exists("./Game" + nudGameNo.Text.ToString() + "/Round2/topics5.txt") Then
                            Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Text.ToString() + "/Round2/topics5.txt")
                            strLine = WebUtility.UrlDecode(sr)

                            nvcDecoded = HttpUtility.ParseQueryString(strLine)

                            ' Assign the value to the appropriate textbox.
                            txtR2Cat1E.Text = FancyTrim(nvcDecoded("topic1"))
                            txtR2Cat2E.Text = FancyTrim(nvcDecoded("topic2"))
                            txtR2Cat3E.Text = FancyTrim(nvcDecoded("topic3"))

                        End If


                        ' Round 2 - Category 6 - Topics
                        If File.Exists("./Game" + nudGameNo.Text.ToString() + "/Round2/topics6.txt") Then
                            Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Text.ToString() + "/Round2/topics6.txt")
                            strLine = WebUtility.UrlDecode(sr)

                            nvcDecoded = HttpUtility.ParseQueryString(strLine)

                            ' Assign the value to the appropriate textbox.
                            txtR2Cat1F.Text = FancyTrim(nvcDecoded("topic1"))
                            txtR2Cat2F.Text = FancyTrim(nvcDecoded("topic2"))
                            txtR2Cat3F.Text = FancyTrim(nvcDecoded("topic3"))

                        End If

                    End If

                    If blnUltimateExists Then
                        ' Ultimate - Categories
                        If File.Exists("./Game" + nudGameNo.Text.ToString() + "/Ultimate/category.txt") Then
                            Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Text.ToString() + "/Ultimate/category.txt")
                            strLine = WebUtility.UrlDecode(sr)

                            nvcDecoded = HttpUtility.ParseQueryString(strLine)

                            ' Assign the value to the appropriate textbox.
                            txtUltCat1.Text = FancyTrim(nvcDecoded("category1"))
                            txtUltCat2.Text = FancyTrim(nvcDecoded("category2"))

                        End If

                        ' Ultimate Challenge - Topics
                        If File.Exists("./Game" + nudGameNo.Text.ToString() + "/Ultimate/topics.txt") Then
                            Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Text.ToString() + "/Ultimate/topics.txt")
                            strLine = WebUtility.UrlDecode(sr)

                            nvcDecoded = HttpUtility.ParseQueryString(strLine)

                            ' Assign the value to the appropriate textbox.
                            txtUltCatA1.Text = FancyTrim(nvcDecoded("topicA1"))
                            txtUltCatA2.Text = FancyTrim(nvcDecoded("topicA2"))
                            txtUltCatA3.Text = FancyTrim(nvcDecoded("topicA3"))

                            txtUltCatB1.Text = FancyTrim(nvcDecoded("topicB1"))
                            txtUltCatB2.Text = FancyTrim(nvcDecoded("topicB2"))
                            txtUltCatB3.Text = FancyTrim(nvcDecoded("topicB3"))

                        End If
                    End If

                    ' Reset all Media options to "None" since the 2022 file doesn't have them.
                    rbR1Cat1Normal.Checked = True
                    rbR1Cat2Normal.Checked = True
                    rbR1Cat3Normal.Checked = True
                    rbR1Cat4Normal.Checked = True
                    rbR1Cat5Normal.Checked = True
                    rbR1Cat6Normal.Checked = True

                    rbR2Cat1Normal.Checked = True
                    rbR2Cat2Normal.Checked = True
                    rbR2Cat3Normal.Checked = True
                    rbR2Cat4Normal.Checked = True
                    rbR2Cat5Normal.Checked = True
                    rbR2Cat6Normal.Checked = True


                Else
                    ' Final Challenge
                    If File.Exists("./Game" + nudGameNo.Text.ToString() + "/final.txt") Then



                        ' Final Challenge Category
                        Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Text.ToString() + "/final.txt")
                        strLine = WebUtility.UrlDecode(sr)

                        nvcDecoded = HttpUtility.ParseQueryString(strLine)

                        ' Assign the value to the appropriate textbox.
                        txtFCat.Text = FancyTrim(nvcDecoded("category"))
                        txtFCat1.Text = FancyTrim(nvcDecoded("topic1"))
                        txtFCat2.Text = FancyTrim(nvcDecoded("topic2"))
                        txtFCat3.Text = FancyTrim(nvcDecoded("topic3"))


                    End If

                    ' Round 1
                    If File.Exists("./Game" + nudGameNo.Text.ToString() + "/r1.txt") Then
                        Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Text.ToString() + "/r1.txt")
                        strLine = WebUtility.UrlDecode(sr)

                        nvcDecoded = HttpUtility.ParseQueryString(strLine)

                        ' Assign the value to the appropriate textbox.
                        txtR1Cat1.Text = FancyTrim(nvcDecoded("category1"))
                        txtR1Cat1A.Text = FancyTrim(nvcDecoded("topic1A"))
                        txtR1Cat2A.Text = FancyTrim(nvcDecoded("topic2A"))
                        txtR1Cat3A.Text = FancyTrim(nvcDecoded("topic3A"))

                        txtR1Cat2.Text = FancyTrim(nvcDecoded("category2"))
                        txtR1Cat1B.Text = FancyTrim(nvcDecoded("topic1B"))
                        txtR1Cat2B.Text = FancyTrim(nvcDecoded("topic2B"))
                        txtR1Cat3B.Text = FancyTrim(nvcDecoded("topic3B"))

                        txtR1Cat3.Text = FancyTrim(nvcDecoded("category3"))
                        txtR1Cat1C.Text = FancyTrim(nvcDecoded("topic1C"))
                        txtR1Cat2C.Text = FancyTrim(nvcDecoded("topic2C"))
                        txtR1Cat3C.Text = FancyTrim(nvcDecoded("topic3C"))

                        txtR1Cat4.Text = FancyTrim(nvcDecoded("category4"))
                        txtR1Cat1D.Text = FancyTrim(nvcDecoded("topic1D"))
                        txtR1Cat2D.Text = FancyTrim(nvcDecoded("topic2D"))
                        txtR1Cat3D.Text = FancyTrim(nvcDecoded("topic3D"))

                        txtR1Cat5.Text = FancyTrim(nvcDecoded("category5"))
                        txtR1Cat1E.Text = FancyTrim(nvcDecoded("topic1E"))
                        txtR1Cat2E.Text = FancyTrim(nvcDecoded("topic2E"))
                        txtR1Cat3E.Text = FancyTrim(nvcDecoded("topic3E"))

                        txtR1Cat6.Text = FancyTrim(nvcDecoded("category6"))
                        txtR1Cat1F.Text = FancyTrim(nvcDecoded("topic1F"))
                        txtR1Cat2F.Text = FancyTrim(nvcDecoded("topic2F"))
                        txtR1Cat3F.Text = FancyTrim(nvcDecoded("topic3F"))

                        Select Case FancyTrim(nvcDecoded("multimediaA")).ToString.ToUpper
                            Case "PIX"
                                rbR1Cat1Picture.Checked = True
                            Case "AUDIO"
                                rbR1Cat1Audio.Checked = True
                            Case "VIDEO"
                                rbR1Cat1Video.Checked = True
                            Case Else
                                rbR1Cat1Normal.Checked = True
                        End Select

                        Select Case FancyTrim(nvcDecoded("multimediaB")).ToString.ToUpper
                            Case "PIX"
                                rbR1Cat2Picture.Checked = True
                            Case "AUDIO"
                                rbR1Cat2Audio.Checked = True
                            Case "VIDEO"
                                rbR1Cat2Video.Checked = True
                            Case Else
                                rbR1Cat2Normal.Checked = True
                        End Select

                        Select Case FancyTrim(nvcDecoded("multimediaC")).ToString.ToUpper
                            Case "PIX"
                                rbR1Cat3Picture.Checked = True
                            Case "AUDIO"
                                rbR1Cat3Audio.Checked = True
                            Case "VIDEO"
                                rbR1Cat3Video.Checked = True
                            Case Else
                                rbR1Cat3Normal.Checked = True
                        End Select

                        Select Case FancyTrim(nvcDecoded("multimediaD")).ToString.ToUpper
                            Case "PIX"
                                rbR1Cat4Picture.Checked = True
                            Case "AUDIO"
                                rbR1Cat4Audio.Checked = True
                            Case "VIDEO"
                                rbR1Cat4Video.Checked = True
                            Case Else
                                rbR1Cat4Normal.Checked = True
                        End Select

                        Select Case FancyTrim(nvcDecoded("multimediaE")).ToString.ToUpper
                            Case "PIX"
                                rbR1Cat5Picture.Checked = True
                            Case "AUDIO"
                                rbR1Cat5Audio.Checked = True
                            Case "VIDEO"
                                rbR1Cat5Video.Checked = True
                            Case Else
                                rbR1Cat5Normal.Checked = True
                        End Select

                        Select Case FancyTrim(nvcDecoded("multimediaF")).ToString.ToUpper
                            Case "PIX"
                                rbR1Cat6Picture.Checked = True
                            Case "AUDIO"
                                rbR1Cat6Audio.Checked = True
                            Case "VIDEO"
                                rbR1Cat6Video.Checked = True
                            Case Else
                                rbR1Cat6Normal.Checked = True
                        End Select


                    End If

                    ' Round 2
                    If File.Exists("./Game" + nudGameNo.Text.ToString() + "/r2.txt") Then
                        Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Text.ToString() + "/r2.txt")
                        strLine = WebUtility.UrlDecode(sr)

                        nvcDecoded = HttpUtility.ParseQueryString(strLine)

                        ' Assign the value to the appropriate textbox.
                        txtR2Cat1.Text = FancyTrim(nvcDecoded("category1"))
                        txtR2Cat1A.Text = FancyTrim(nvcDecoded("topic1A"))
                        txtR2Cat2A.Text = FancyTrim(nvcDecoded("topic2A"))
                        txtR2Cat3A.Text = FancyTrim(nvcDecoded("topic3A"))

                        txtR2Cat2.Text = FancyTrim(nvcDecoded("category2"))
                        txtR2Cat1B.Text = FancyTrim(nvcDecoded("topic1B"))
                        txtR2Cat2B.Text = FancyTrim(nvcDecoded("topic2B"))
                        txtR2Cat3B.Text = FancyTrim(nvcDecoded("topic3B"))

                        txtR2Cat3.Text = FancyTrim(nvcDecoded("category3"))
                        txtR2Cat1C.Text = FancyTrim(nvcDecoded("topic1C"))
                        txtR2Cat2C.Text = FancyTrim(nvcDecoded("topic2C"))
                        txtR2Cat3C.Text = FancyTrim(nvcDecoded("topic3C"))

                        txtR2Cat4.Text = FancyTrim(nvcDecoded("category4"))
                        txtR2Cat1D.Text = FancyTrim(nvcDecoded("topic1D"))
                        txtR2Cat2D.Text = FancyTrim(nvcDecoded("topic2D"))
                        txtR2Cat3D.Text = FancyTrim(nvcDecoded("topic3D"))

                        txtR2Cat5.Text = FancyTrim(nvcDecoded("category5"))
                        txtR2Cat1E.Text = FancyTrim(nvcDecoded("topic1E"))
                        txtR2Cat2E.Text = FancyTrim(nvcDecoded("topic2E"))
                        txtR2Cat3E.Text = FancyTrim(nvcDecoded("topic3E"))

                        txtR2Cat6.Text = FancyTrim(nvcDecoded("category6"))
                        txtR2Cat1F.Text = FancyTrim(nvcDecoded("topic1F"))
                        txtR2Cat2F.Text = FancyTrim(nvcDecoded("topic2F"))
                        txtR2Cat3F.Text = FancyTrim(nvcDecoded("topic3F"))

                        Select Case FancyTrim(nvcDecoded("multimediaA")).ToString.ToUpper
                            Case "PIX"
                                rbR2Cat1Picture.Checked = True
                            Case "AUDIO"
                                rbR2Cat1Audio.Checked = True
                            Case "VIDEO"
                                rbR2Cat1Video.Checked = True
                            Case Else
                                rbR2Cat1Normal.Checked = True
                        End Select

                        Select Case FancyTrim(nvcDecoded("multimediaB")).ToString.ToUpper
                            Case "PIX"
                                rbR2Cat2Picture.Checked = True
                            Case "AUDIO"
                                rbR2Cat2Audio.Checked = True
                            Case "VIDEO"
                                rbR2Cat2Video.Checked = True
                            Case Else
                                rbR2Cat2Normal.Checked = True
                        End Select

                        Select Case FancyTrim(nvcDecoded("multimediaC")).ToString.ToUpper
                            Case "PIX"
                                rbR2Cat3Picture.Checked = True
                            Case "AUDIO"
                                rbR2Cat3Audio.Checked = True
                            Case "VIDEO"
                                rbR2Cat3Video.Checked = True
                            Case Else
                                rbR2Cat3Normal.Checked = True
                        End Select

                        Select Case FancyTrim(nvcDecoded("multimediaD")).ToString.ToUpper
                            Case "PIX"
                                rbR2Cat4Picture.Checked = True
                            Case "AUDIO"
                                rbR2Cat4Audio.Checked = True
                            Case "VIDEO"
                                rbR2Cat4Video.Checked = True
                            Case Else
                                rbR2Cat4Normal.Checked = True
                        End Select

                        Select Case FancyTrim(nvcDecoded("multimediaE")).ToString.ToUpper
                            Case "PIX"
                                rbR2Cat5Picture.Checked = True
                            Case "AUDIO"
                                rbR2Cat5Audio.Checked = True
                            Case "VIDEO"
                                rbR2Cat5Video.Checked = True
                            Case Else
                                rbR2Cat5Normal.Checked = True
                        End Select

                        Select Case FancyTrim(nvcDecoded("multimediaF")).ToString.ToUpper
                            Case "PIX"
                                rbR2Cat6Picture.Checked = True
                            Case "AUDIO"
                                rbR2Cat6Audio.Checked = True
                            Case "VIDEO"
                                rbR2Cat6Video.Checked = True
                            Case Else
                                rbR2Cat6Normal.Checked = True
                        End Select

                    End If

                    ' Ultimate Round
                    If File.Exists("./Game" + nudGameNo.Text.ToString() + "/ultimate.txt") Then
                        Dim sr = My.Computer.FileSystem.ReadAllText("./Game" + nudGameNo.Text.ToString() + "/ultimate.txt")
                        strLine = WebUtility.UrlDecode(sr)

                        nvcDecoded = HttpUtility.ParseQueryString(strLine)

                        txtUltCat1.Text = FancyTrim(nvcDecoded("category1"))
                        txtUltCatA1.Text = FancyTrim(nvcDecoded("topicA1"))
                        txtUltCatA2.Text = FancyTrim(nvcDecoded("topicA2"))
                        txtUltCatA3.Text = FancyTrim(nvcDecoded("topicA3"))

                        txtUltCat2.Text = FancyTrim(nvcDecoded("category2"))
                        txtUltCatB1.Text = FancyTrim(nvcDecoded("topicB1"))
                        txtUltCatB2.Text = FancyTrim(nvcDecoded("topicB2"))
                        txtUltCatB3.Text = FancyTrim(nvcDecoded("topicB3"))

                    End If



                End If

                ' Set the Overwrite flag
                cbOverwrite.Checked = True

            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub btnToUpper_Click(sender As Object, e As EventArgs) Handles btnToUpper.Click
        ' Change ALL forms into UPPER CASE
        Dim arrTextboxes As TextBox() = {txtR1Cat3F, txtR1Cat2F, txtR1Cat1F, txtR1Cat6, txtR1Cat3E, txtR1Cat2E, txtR1Cat1E, txtR1Cat5, txtR1Cat3D, txtR1Cat2D, txtR1Cat1D, txtR1Cat4, txtR1Cat3C, txtR1Cat2C, txtR1Cat1C, txtR1Cat3, txtR1Cat3B, txtR1Cat2B, txtR1Cat1B, txtR1Cat2, txtR1Cat3A, txtR1Cat2A, txtR1Cat1A, txtR1Cat1, txtR2Cat3F, txtR2Cat2F, txtR2Cat1F, txtR2Cat6, txtR2Cat3E, txtR2Cat2E, txtR2Cat1E, txtR2Cat5, txtR2Cat3D, txtR2Cat2D, txtR2Cat1D, txtR2Cat4, txtR2Cat3C, txtR2Cat2C, txtR2Cat1C, txtR2Cat3, txtR2Cat3B, txtR2Cat2B, txtR2Cat1B, txtR2Cat2, txtR2Cat3A, txtR2Cat2A, txtR2Cat1A, txtR2Cat1, txtFCat3, txtFCat2, txtFCat1, txtFCat, txtUltCat1, txtUltCatA1, txtUltCatA2, txtUltCatA3, txtUltCat2, txtUltCatB1, txtUltCatB2, txtUltCatB3}

        For Each item In arrTextboxes
            item.Text = item.Text.ToUpper()
        Next

    End Sub
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnStartOver.Click
        If MessageBox.Show("This will clear the textboxes and start a new game file." + vbNewLine + vbNewLine + "If you have saved your game file and/or you're ready to clear everything and start over, click OK. Otherwise hit Cancel.", "Starting a new game file?", MessageBoxButtons.OKCancel) = DialogResult.OK Then
            ClearTextboxes()

            ' Set the Overwrite flag
            cbOverwrite.Checked = False

            ' Reset Media choices
            rbR1Cat1Normal.Checked = True
            rbR1Cat2Normal.Checked = True
            rbR1Cat3Normal.Checked = True
            rbR1Cat4Normal.Checked = True
            rbR1Cat5Normal.Checked = True
            rbR1Cat6Normal.Checked = True

            rbR2Cat1Normal.Checked = True
            rbR2Cat2Normal.Checked = True
            rbR2Cat3Normal.Checked = True
            rbR2Cat4Normal.Checked = True
            rbR2Cat5Normal.Checked = True
            rbR2Cat6Normal.Checked = True

        End If
    End Sub

    Private Sub ClearTextboxes()
        ' Loop through every textbox and clear it.

        Dim arrTextboxes As TextBox() = {txtR1Cat3F, txtR1Cat2F, txtR1Cat1F, txtR1Cat6, txtR1Cat3E, txtR1Cat2E, txtR1Cat1E, txtR1Cat5, txtR1Cat3D, txtR1Cat2D, txtR1Cat1D, txtR1Cat4, txtR1Cat3C, txtR1Cat2C, txtR1Cat1C, txtR1Cat3, txtR1Cat3B, txtR1Cat2B, txtR1Cat1B, txtR1Cat2, txtR1Cat3A, txtR1Cat2A, txtR1Cat1A, txtR1Cat1, txtR2Cat3F, txtR2Cat2F, txtR2Cat1F, txtR2Cat6, txtR2Cat3E, txtR2Cat2E, txtR2Cat1E, txtR2Cat5, txtR2Cat3D, txtR2Cat2D, txtR2Cat1D, txtR2Cat4, txtR2Cat3C, txtR2Cat2C, txtR2Cat1C, txtR2Cat3, txtR2Cat3B, txtR2Cat2B, txtR2Cat1B, txtR2Cat2, txtR2Cat3A, txtR2Cat2A, txtR2Cat1A, txtR2Cat1, txtFCat3, txtFCat2, txtFCat1, txtFCat, txtUltCat1, txtUltCat2, txtUltCatA1, txtUltCatA2, txtUltCatA3, txtUltCatB1, txtUltCatB2, txtUltCatB3}

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

        lblVersion.Text = String.Format("Version {0}", strVersion)
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
            txtR2Cat2A.Text = txtR1Cat2A.Text
            txtR2Cat3A.Text = txtR1Cat3A.Text

            txtR2Cat1B.Text = txtR1Cat1B.Text
            txtR2Cat2B.Text = txtR1Cat2B.Text
            txtR2Cat3B.Text = txtR1Cat3B.Text

            txtR2Cat1C.Text = txtR1Cat1C.Text
            txtR2Cat2C.Text = txtR1Cat2C.Text
            txtR2Cat3C.Text = txtR1Cat3C.Text

            txtR2Cat1D.Text = txtR1Cat1D.Text
            txtR2Cat2D.Text = txtR1Cat2D.Text
            txtR2Cat3D.Text = txtR1Cat3D.Text

            txtR2Cat1E.Text = txtR1Cat1E.Text
            txtR2Cat2E.Text = txtR1Cat2E.Text
            txtR2Cat3E.Text = txtR1Cat3E.Text

            txtR2Cat1F.Text = txtR1Cat1F.Text
            txtR2Cat2F.Text = txtR1Cat2F.Text
            txtR2Cat3F.Text = txtR1Cat3F.Text
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
            txtR1Cat2A.Text = txtR2Cat2A.Text
            txtR1Cat3A.Text = txtR2Cat3A.Text

            txtR1Cat1B.Text = txtR2Cat1B.Text
            txtR1Cat2B.Text = txtR2Cat2B.Text
            txtR1Cat3B.Text = txtR2Cat3B.Text

            txtR1Cat1C.Text = txtR2Cat1C.Text
            txtR1Cat2C.Text = txtR2Cat2C.Text
            txtR1Cat3C.Text = txtR2Cat3C.Text

            txtR1Cat1D.Text = txtR2Cat1D.Text
            txtR1Cat2D.Text = txtR2Cat2D.Text
            txtR1Cat3D.Text = txtR2Cat3D.Text

            txtR1Cat1E.Text = txtR2Cat1E.Text
            txtR1Cat2E.Text = txtR2Cat2E.Text
            txtR1Cat3E.Text = txtR2Cat3E.Text

            txtR1Cat1F.Text = txtR2Cat1F.Text
            txtR1Cat2F.Text = txtR2Cat2F.Text
            txtR1Cat3F.Text = txtR2Cat3F.Text
        End If
    End Sub

    Private Sub btnFindGamePack_Click(sender As Object, e As EventArgs) Handles btnFindGamePack.Click
        ' Starting at 1, go through and find the first non-existing directory. When you do, set the number selector to that number.

        For i = 1 To 999999
            ' Test if a directory exists, if so... Keep Going.
            If Not Directory.Exists(Directory.GetCurrentDirectory() + "/Game" + i.ToString) Then
                nudGameNo.Text = i
                Exit For
            End If
        Next
    End Sub

    Private Sub rbR1Cat1Picture_CheckedChanged(sender As Object, e As EventArgs) Handles rbR1Cat6Picture.CheckedChanged, rbR1Cat5Picture.CheckedChanged, rbR1Cat4Picture.CheckedChanged, rbR1Cat3Picture.CheckedChanged, rbR1Cat2Picture.CheckedChanged, rbR1Cat1Picture.CheckedChanged
        ' Only ONE item can this. So... check all and disable it if it's not the sender.

        Dim rbArray As RadioButton() = {rbR1Cat6Picture, rbR1Cat5Picture, rbR1Cat4Picture, rbR1Cat3Picture, rbR1Cat2Picture, rbR1Cat1Picture}

        For Each item In rbArray
            If item.Name <> sender.Name Then item.Enabled = Not sender.checked
        Next

    End Sub

    Private Sub rbR1Cat1Audio_CheckedChanged(sender As Object, e As EventArgs) Handles rbR1Cat6Audio.CheckedChanged, rbR1Cat5Audio.CheckedChanged, rbR1Cat4Audio.CheckedChanged, rbR1Cat3Audio.CheckedChanged, rbR1Cat2Audio.CheckedChanged, rbR1Cat1Audio.CheckedChanged
        ' Only ONE item can this. So... check all and disable it if it's not the sender.

        Dim rbArray As RadioButton() = {rbR1Cat6Audio, rbR1Cat5Audio, rbR1Cat4Audio, rbR1Cat3Audio, rbR1Cat2Audio, rbR1Cat1Audio}

        For Each item In rbArray
            If item.Name <> sender.Name Then item.Enabled = Not sender.checked
        Next
    End Sub

    Private Sub rbR1Cat1Video_CheckedChanged(sender As Object, e As EventArgs) Handles rbR1Cat6Video.CheckedChanged, rbR1Cat5Video.CheckedChanged, rbR1Cat4Video.CheckedChanged, rbR1Cat3Video.CheckedChanged, rbR1Cat2Video.CheckedChanged, rbR1Cat1Video.CheckedChanged
        ' Only ONE item can this. So... check all and disable it if it's not the sender.

        Dim rbArray As RadioButton() = {rbR1Cat6Video, rbR1Cat5Video, rbR1Cat4Video, rbR1Cat3Video, rbR1Cat2Video, rbR1Cat1Video}

        For Each item In rbArray
            If item.Name <> sender.Name Then item.Enabled = Not sender.checked
        Next
    End Sub

    Private Sub rbR2Cat1Picture_CheckedChanged(sender As Object, e As EventArgs) Handles rbR2Cat6Picture.CheckedChanged, rbR2Cat5Picture.CheckedChanged, rbR2Cat4Picture.CheckedChanged, rbR2Cat3Picture.CheckedChanged, rbR2Cat2Picture.CheckedChanged, rbR2Cat1Picture.CheckedChanged
        ' Only ONE item can this. So... check all and disable it if it's not the sender.

        Dim rbArray As RadioButton() = {rbR2Cat6Picture, rbR2Cat5Picture, rbR2Cat4Picture, rbR2Cat3Picture, rbR2Cat2Picture, rbR2Cat1Picture}

        For Each item In rbArray
            If item.Name <> sender.Name Then item.Enabled = Not sender.checked
        Next

    End Sub

    Private Sub rbR2Cat1Audio_CheckedChanged(sender As Object, e As EventArgs) Handles rbR2Cat6Audio.CheckedChanged, rbR2Cat5Audio.CheckedChanged, rbR2Cat4Audio.CheckedChanged, rbR2Cat3Audio.CheckedChanged, rbR2Cat2Audio.CheckedChanged, rbR2Cat1Audio.CheckedChanged
        ' Only ONE item can this. So... check all and disable it if it's not the sender.

        Dim rbArray As RadioButton() = {rbR2Cat6Audio, rbR2Cat5Audio, rbR2Cat4Audio, rbR2Cat3Audio, rbR2Cat2Audio, rbR2Cat1Audio}

        For Each item In rbArray
            If item.Name <> sender.Name Then item.Enabled = Not sender.checked
        Next
    End Sub

    Private Sub rbR2Cat1Video_CheckedChanged(sender As Object, e As EventArgs) Handles rbR2Cat6Video.CheckedChanged, rbR2Cat5Video.CheckedChanged, rbR2Cat4Video.CheckedChanged, rbR2Cat3Video.CheckedChanged, rbR2Cat2Video.CheckedChanged, rbR2Cat1Video.CheckedChanged
        ' Only ONE item can this. So... check all and disable it if it's not the sender.

        Dim rbArray As RadioButton() = {rbR2Cat6Video, rbR2Cat5Video, rbR2Cat4Video, rbR2Cat3Video, rbR2Cat2Video, rbR2Cat1Video}

        For Each item In rbArray
            If item.Name <> sender.Name Then item.Enabled = Not sender.checked
        Next
    End Sub

    Private Sub btnClearMedia_Click(sender As Object, e As EventArgs) Handles btnClearMedia.Click
        If MessageBox.Show("This will reset the media options on all categories to ""None""." + vbNewLine + vbNewLine + "If you are sure you want to reset this, click OK. Otherwise hit Cancel.", "Reset Media Options", MessageBoxButtons.OKCancel) = DialogResult.OK Then
            ' Reset all Media Selections to None

            rbR1Cat1Normal.Checked = True
            rbR1Cat2Normal.Checked = True
            rbR1Cat3Normal.Checked = True
            rbR1Cat4Normal.Checked = True
            rbR1Cat5Normal.Checked = True
            rbR1Cat6Normal.Checked = True

            rbR2Cat1Normal.Checked = True
            rbR2Cat2Normal.Checked = True
            rbR2Cat3Normal.Checked = True
            rbR2Cat4Normal.Checked = True
            rbR2Cat5Normal.Checked = True
            rbR2Cat6Normal.Checked = True

        End If
    End Sub

    Private Sub btnMove1to2_Click(sender As Object, e As EventArgs) Handles btnMove1to2.Click
        If MessageBox.Show("This will move all content from Round 1's categories into Round 2's categories and erase what is there." + vbNewLine + vbNewLine + "If you are sure you want to do this, hit OK.", "Move Round 1 into Round 2 Categories", MessageBoxButtons.OKCancel) = DialogResult.OK Then

            ' Do this after they confirm they want to do it.
            ' MOVE ROUND 1 into 2

            ' Round 1 Categories into Round 2
            txtR2Cat1.Text = txtR1Cat1.Text
            txtR2Cat2.Text = txtR1Cat2.Text
            txtR2Cat3.Text = txtR1Cat3.Text
            txtR2Cat4.Text = txtR1Cat4.Text
            txtR2Cat5.Text = txtR1Cat5.Text
            txtR2Cat6.Text = txtR1Cat6.Text

            ' Round 1 Topics into Round 2
            txtR2Cat1A.Text = txtR1Cat1A.Text
            txtR2Cat2A.Text = txtR1Cat2A.Text
            txtR2Cat3A.Text = txtR1Cat3A.Text

            txtR2Cat1B.Text = txtR1Cat1B.Text
            txtR2Cat2B.Text = txtR1Cat2B.Text
            txtR2Cat3B.Text = txtR1Cat3B.Text

            txtR2Cat1C.Text = txtR1Cat1C.Text
            txtR2Cat2C.Text = txtR1Cat2C.Text
            txtR2Cat3C.Text = txtR1Cat3C.Text

            txtR2Cat1D.Text = txtR1Cat1D.Text
            txtR2Cat2D.Text = txtR1Cat2D.Text
            txtR2Cat3D.Text = txtR1Cat3D.Text

            txtR2Cat1E.Text = txtR1Cat1E.Text
            txtR2Cat2E.Text = txtR1Cat2E.Text
            txtR2Cat3E.Text = txtR1Cat3E.Text

            txtR2Cat1F.Text = txtR1Cat1F.Text
            txtR2Cat2F.Text = txtR1Cat2F.Text
            txtR2Cat3F.Text = txtR1Cat3F.Text

            ' Now clear all these of Round 1's textboxes
            ' Round 2 Categories into Round 1
            txtR1Cat1.Clear()
            txtR1Cat2.Clear()
            txtR1Cat3.Clear()
            txtR1Cat4.Clear()
            txtR1Cat5.Clear()
            txtR1Cat6.Clear()

            ' Round 2 Topics into Round 1
            txtR1Cat1A.Clear()
            txtR1Cat2A.Clear()
            txtR1Cat3A.Clear()

            txtR1Cat1B.Clear()
            txtR1Cat2B.Clear()
            txtR1Cat3B.Clear()

            txtR1Cat1C.Clear()
            txtR1Cat2C.Clear()
            txtR1Cat3C.Clear()

            txtR1Cat1D.Clear()
            txtR1Cat2D.Clear()
            txtR1Cat3D.Clear()

            txtR1Cat1E.Clear()
            txtR1Cat2E.Clear()
            txtR1Cat3E.Clear()

            txtR1Cat1F.Clear()
            txtR1Cat2F.Clear()
            txtR1Cat3F.Clear()
        End If
    End Sub

    Private Sub btnMove2to1_Click(sender As Object, e As EventArgs) Handles btnMove2to1.Click
        If MessageBox.Show("This will move all content from Round 2's categories into Round 1's categories and erase what is there." + vbNewLine + vbNewLine + "If you are sure you want to do this, hit OK.", "Move Round 2 into Round 1 Categories", MessageBoxButtons.OKCancel) = DialogResult.OK Then

            ' Do this after they confirm they want to do it.

            ' Round 2 Categories into Round 1
            txtR1Cat1.Text = txtR2Cat1.Text
            txtR1Cat2.Text = txtR2Cat2.Text
            txtR1Cat3.Text = txtR2Cat3.Text
            txtR1Cat4.Text = txtR2Cat4.Text
            txtR1Cat5.Text = txtR2Cat5.Text
            txtR1Cat6.Text = txtR2Cat6.Text

            ' Round 2 Topics into Round 1
            txtR1Cat1A.Text = txtR2Cat1A.Text
            txtR1Cat2A.Text = txtR2Cat2A.Text
            txtR1Cat3A.Text = txtR2Cat3A.Text

            txtR1Cat1B.Text = txtR2Cat1B.Text
            txtR1Cat2B.Text = txtR2Cat2B.Text
            txtR1Cat3B.Text = txtR2Cat3B.Text

            txtR1Cat1C.Text = txtR2Cat1C.Text
            txtR1Cat2C.Text = txtR2Cat2C.Text
            txtR1Cat3C.Text = txtR2Cat3C.Text

            txtR1Cat1D.Text = txtR2Cat1D.Text
            txtR1Cat2D.Text = txtR2Cat2D.Text
            txtR1Cat3D.Text = txtR2Cat3D.Text

            txtR1Cat1E.Text = txtR2Cat1E.Text
            txtR1Cat2E.Text = txtR2Cat2E.Text
            txtR1Cat3E.Text = txtR2Cat3E.Text

            txtR1Cat1F.Text = txtR2Cat1F.Text
            txtR1Cat2F.Text = txtR2Cat2F.Text
            txtR1Cat3F.Text = txtR2Cat3F.Text

            ' Now clear all these of Round 1's textboxes
            ' Round 2 Categories into Round 1
            txtR2Cat1.Clear()
            txtR2Cat2.Clear()
            txtR2Cat3.Clear()
            txtR2Cat4.Clear()
            txtR2Cat5.Clear()
            txtR2Cat6.Clear()

            ' Round 2 Topics into Round 1
            txtR2Cat1A.Clear()
            txtR2Cat2A.Clear()
            txtR2Cat3A.Clear()

            txtR2Cat1B.Clear()
            txtR2Cat2B.Clear()
            txtR2Cat3B.Clear()

            txtR2Cat1C.Clear()
            txtR2Cat2C.Clear()
            txtR2Cat3C.Clear()

            txtR2Cat1C.Clear()
            txtR2Cat2C.Clear()
            txtR2Cat3C.Clear()

            txtR2Cat1D.Clear()
            txtR2Cat2D.Clear()
            txtR2Cat3D.Clear()

            txtR2Cat1E.Clear()
            txtR2Cat2E.Clear()
            txtR2Cat3E.Clear()

            txtR2Cat1F.Clear()
            txtR2Cat2F.Clear()
            txtR2Cat3F.Clear()
        End If
    End Sub

    Private Sub btnSwap_Click(sender As Object, e As EventArgs) Handles btnSwap.Click
        If MessageBox.Show("Do you want to swap the rounds over? This will move Round 1's contents into Round 2 and vice versa.", "Swap Categories", MessageBoxButtons.OKCancel) = DialogResult.OK Then
            Dim strCategory1, strCategory2, strCategory3, strCategory4, strCategory5, strCategory6 As String

            Dim strC1_1, strC1_2, strC1_3 As String
            Dim strC2_1, strC2_2, strC2_3 As String
            Dim strC3_1, strC3_2, strC3_3 As String
            Dim strC4_1, strC4_2, strC4_3 As String
            Dim strC5_1, strC5_2, strC5_3 As String
            Dim strC6_1, strC6_2, strC6_3 As String

            Dim rbC1_1, rbC1_2, rbC1_3, rbC1_4 As New RadioButton
            Dim rbC2_1, rbC2_2, rbC2_3, rbC2_4 As New RadioButton
            Dim rbC3_1, rbC3_2, rbC3_3, rbC3_4 As New RadioButton
            Dim rbC4_1, rbC4_2, rbC4_3, rbC4_4 As New RadioButton
            Dim rbC5_1, rbC5_2, rbC5_3, rbC5_4 As New RadioButton
            Dim rbC6_1, rbC6_2, rbC6_3, rbC6_4 As New RadioButton

            ' Copy Round 1's options and settings into temp variable.
            rbC1_1.Checked = rbR1Cat1Picture.Checked
            rbC1_2.Checked = rbR1Cat1Audio.Checked
            rbC1_3.Checked = rbR1Cat1Video.Checked
            rbC1_4.Checked = rbR1Cat1Normal.Checked

            rbC2_1.Checked = rbR1Cat2Picture.Checked
            rbC2_2.Checked = rbR1Cat2Audio.Checked
            rbC2_3.Checked = rbR1Cat2Video.Checked
            rbC2_4.Checked = rbR1Cat2Normal.Checked

            rbC3_1.Checked = rbR1Cat3Picture.Checked
            rbC3_2.Checked = rbR1Cat3Audio.Checked
            rbC3_3.Checked = rbR1Cat3Video.Checked
            rbC3_4.Checked = rbR1Cat3Normal.Checked

            rbC4_1.Checked = rbR1Cat4Picture.Checked
            rbC4_2.Checked = rbR1Cat4Audio.Checked
            rbC4_3.Checked = rbR1Cat4Video.Checked
            rbC4_4.Checked = rbR1Cat4Normal.Checked

            rbC5_1.Checked = rbR1Cat5Picture.Checked
            rbC5_2.Checked = rbR1Cat5Audio.Checked
            rbC5_3.Checked = rbR1Cat5Video.Checked
            rbC5_4.Checked = rbR1Cat5Normal.Checked

            rbC6_1.Checked = rbR1Cat6Picture.Checked
            rbC6_2.Checked = rbR1Cat6Audio.Checked
            rbC6_3.Checked = rbR1Cat6Video.Checked
            rbC6_4.Checked = rbR1Cat6Normal.Checked

            strCategory1 = txtR1Cat1.Text
            strCategory2 = txtR1Cat2.Text
            strCategory3 = txtR1Cat3.Text
            strCategory4 = txtR1Cat4.Text
            strCategory5 = txtR1Cat5.Text
            strCategory6 = txtR1Cat6.Text

            strC1_1 = txtR1Cat1A.Text
            strC1_2 = txtR1Cat2A.Text
            strC1_3 = txtR1Cat3A.Text

            strC2_1 = txtR1Cat1B.Text
            strC2_2 = txtR1Cat2B.Text
            strC2_3 = txtR1Cat3B.Text

            strC3_1 = txtR1Cat1C.Text
            strC3_2 = txtR1Cat2C.Text
            strC3_3 = txtR1Cat3C.Text

            strC4_1 = txtR1Cat1D.Text
            strC4_2 = txtR1Cat2D.Text
            strC4_3 = txtR1Cat3D.Text

            strC5_1 = txtR1Cat1E.Text
            strC5_2 = txtR1Cat2E.Text
            strC5_3 = txtR1Cat3E.Text

            strC6_1 = txtR1Cat1F.Text
            strC6_2 = txtR1Cat2F.Text
            strC6_3 = txtR1Cat3F.Text

            ' Copy Round 2 into Round 1
            rbR1Cat1Picture.Checked = rbR2Cat1Picture.Checked
            rbR1Cat1Audio.Checked = rbR2Cat1Audio.Checked
            rbR1Cat1Video.Checked = rbR2Cat1Video.Checked
            rbR1Cat1Normal.Checked = rbR2Cat1Normal.Checked

            rbR1Cat2Picture.Checked = rbR2Cat2Picture.Checked
            rbR1Cat2Audio.Checked = rbR2Cat2Audio.Checked
            rbR1Cat2Video.Checked = rbR2Cat2Video.Checked
            rbR1Cat2Normal.Checked = rbR2Cat2Normal.Checked

            rbR1Cat3Picture.Checked = rbR2Cat3Picture.Checked
            rbR1Cat3Audio.Checked = rbR2Cat3Audio.Checked
            rbR1Cat3Video.Checked = rbR2Cat3Video.Checked
            rbR1Cat3Normal.Checked = rbR2Cat3Normal.Checked

            rbR1Cat4Picture.Checked = rbR2Cat4Picture.Checked
            rbR1Cat4Audio.Checked = rbR2Cat4Audio.Checked
            rbR1Cat4Video.Checked = rbR2Cat4Video.Checked
            rbR1Cat4Normal.Checked = rbR2Cat4Normal.Checked

            rbR1Cat5Picture.Checked = rbR2Cat5Picture.Checked
            rbR1Cat5Audio.Checked = rbR2Cat5Audio.Checked
            rbR1Cat5Video.Checked = rbR2Cat5Video.Checked
            rbR1Cat5Normal.Checked = rbR2Cat5Normal.Checked

            rbR1Cat6Picture.Checked = rbR2Cat6Picture.Checked
            rbR1Cat6Audio.Checked = rbR2Cat6Audio.Checked
            rbR1Cat6Video.Checked = rbR2Cat6Video.Checked
            rbR1Cat6Normal.Checked = rbR2Cat6Normal.Checked

            txtR1Cat1.Text = txtR2Cat1.Text
            txtR1Cat2.Text = txtR2Cat2.Text
            txtR1Cat3.Text = txtR2Cat3.Text
            txtR1Cat4.Text = txtR2Cat4.Text
            txtR1Cat5.Text = txtR2Cat5.Text
            txtR1Cat6.Text = txtR2Cat6.Text

            txtR1Cat1A.Text = txtR2Cat1A.Text
            txtR1Cat2A.Text = txtR2Cat2A.Text
            txtR1Cat3A.Text = txtR2Cat3A.Text

            txtR1Cat1B.Text = txtR2Cat1B.Text
            txtR1Cat2B.Text = txtR2Cat2B.Text
            txtR1Cat3B.Text = txtR2Cat3B.Text

            txtR1Cat1C.Text = txtR2Cat1C.Text
            txtR1Cat2C.Text = txtR2Cat2C.Text
            txtR1Cat3C.Text = txtR2Cat3C.Text

            txtR1Cat1D.Text = txtR2Cat1D.Text
            txtR1Cat2D.Text = txtR2Cat2D.Text
            txtR1Cat3D.Text = txtR2Cat3D.Text

            txtR1Cat1E.Text = txtR2Cat1E.Text
            txtR1Cat2E.Text = txtR2Cat2E.Text
            txtR1Cat3E.Text = txtR2Cat3E.Text

            txtR1Cat1F.Text = txtR2Cat1F.Text
            txtR1Cat2F.Text = txtR2Cat2F.Text
            txtR1Cat3F.Text = txtR2Cat3F.Text


            ' Copy Round 1 from temp variable into Round 2.
            txtR2Cat1.Text = strCategory1
            txtR2Cat2.Text = strCategory2
            txtR2Cat3.Text = strCategory3
            txtR2Cat4.Text = strCategory4
            txtR2Cat5.Text = strCategory5
            txtR2Cat6.Text = strCategory6

            txtR2Cat1A.Text = strC1_1
            txtR2Cat2A.Text = strC1_2
            txtR2Cat3A.Text = strC1_3

            txtR2Cat1B.Text = strC2_1
            txtR2Cat2B.Text = strC2_2
            txtR2Cat3B.Text = strC2_3

            txtR2Cat1C.Text = strC3_1
            txtR2Cat2C.Text = strC3_2
            txtR2Cat3C.Text = strC3_3

            txtR2Cat1D.Text = strC4_1
            txtR2Cat2D.Text = strC4_2
            txtR2Cat3D.Text = strC4_3

            txtR2Cat1E.Text = strC5_1
            txtR2Cat2E.Text = strC5_2
            txtR2Cat3E.Text = strC5_3

            txtR2Cat1F.Text = strC6_1
            txtR2Cat2F.Text = strC6_2
            txtR2Cat3F.Text = strC6_3

            rbR2Cat1Picture.Checked = rbC1_1.Checked
            rbR2Cat1Audio.Checked = rbC1_2.Checked
            rbR2Cat1Video.Checked = rbC1_3.Checked
            rbR2Cat1Normal.Checked = rbC1_4.Checked

            rbR2Cat2Picture.Checked = rbC2_1.Checked
            rbR2Cat2Audio.Checked = rbC2_2.Checked
            rbR2Cat2Video.Checked = rbC2_3.Checked
            rbR2Cat2Normal.Checked = rbC2_4.Checked

            rbR2Cat3Picture.Checked = rbC3_1.Checked
            rbR2Cat3Audio.Checked = rbC3_2.Checked
            rbR2Cat3Video.Checked = rbC3_3.Checked
            rbR2Cat3Normal.Checked = rbC3_4.Checked

            rbR2Cat4Picture.Checked = rbC4_1.Checked
            rbR2Cat4Audio.Checked = rbC4_2.Checked
            rbR2Cat4Video.Checked = rbC4_3.Checked
            rbR2Cat4Normal.Checked = rbC4_4.Checked

            rbR2Cat5Picture.Checked = rbC5_1.Checked
            rbR2Cat5Audio.Checked = rbC5_2.Checked
            rbR2Cat5Video.Checked = rbC5_3.Checked
            rbR2Cat5Normal.Checked = rbC5_4.Checked

            rbR2Cat6Picture.Checked = rbC6_1.Checked
            rbR2Cat6Audio.Checked = rbC6_2.Checked
            rbR2Cat6Video.Checked = rbC6_3.Checked
            rbR2Cat6Normal.Checked = rbC6_4.Checked

        End If

    End Sub
    'Only allow Numbers and control characters
    Private Sub nudGameNo_TextChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nudGameNo.KeyPress

        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = Nothing

    End Sub

    ' Only allow Numbers to be copy/pasted
    Private Sub nudGameNo_TextChanged(sender As Object, e As EventArgs) Handles nudGameNo.TextChanged, nudGameNo.KeyPress
        Dim digitsOnly As Regex = New Regex("[^\d]")
        nudGameNo.Text = digitsOnly.Replace(nudGameNo.Text, "")
    End Sub

    Private Sub btnLoadSlate_Click(sender As Object, e As EventArgs) Handles btnLoadSlate.Click
        Dim strLine As String
        Dim nvcDecoded As NameValueCollection

        '
        If File.Exists("../slate.txt") Then
            Dim sr = My.Computer.FileSystem.ReadAllText("../slate.txt")
            strLine = WebUtility.UrlDecode(sr)

            nvcDecoded = HttpUtility.ParseQueryString(strLine)

            txtEpisodeNo.Text = FancyTrim(nvcDecoded("episode"))
            txtVTRDate.Text = FancyTrim(nvcDecoded("vtr"))
            txtAirdate.Text = FancyTrim(nvcDecoded("airdate"))

        Else
            MessageBox.Show("No slate file found. Are you sure the file creator is pointing to the right directory? (The Saved Files Option to the right should point where the Games directory is made.", "No Slate File Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Private Sub btnSaveSlate_Click(sender As Object, e As EventArgs) Handles btnSaveSlate.Click
        Dim sw As New StreamWriter("../slate.txt", False)
        sw.WriteLine("&episode=" + WebUtility.UrlEncode(FancyTrim(txtEpisodeNo.Text)) + "&")
        sw.WriteLine("&vtr=" + WebUtility.UrlEncode(FancyTrim(txtVTRDate.Text)) + "&")
        sw.WriteLine("&airdate=" + WebUtility.UrlEncode(FancyTrim(txtAirdate.Text)) + "&")
        sw.Close()

        MessageBox.Show("Slate File Succesfully Created!")
    End Sub
End Class
