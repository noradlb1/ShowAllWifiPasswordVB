
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Partial Public Class Form1
    Inherits Form
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        'Key Content            :
        komut2()

        Dim getir As String = TextBox3.Text
        Dim data3 As String = getBetween(getir, "Key Content            : ", "Cost ")
        TextBox4.Text = data3
    End Sub

    Public Sub komut1()
        Dim q As String = ""
        Try
            Dim komut As String = "netsh wlan show profile"
            Dim process As New System.Diagnostics.Process()
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
            process.StartInfo.FileName = "cmd.exe"
            process.StartInfo.Arguments = "/C " & komut
            process.StartInfo.UseShellExecute = False
            process.StartInfo.CreateNoWindow = True
            process.StartInfo.RedirectStandardOutput = True
            process.StartInfo.RedirectStandardInput = True
            process.Start()

            While Not process.HasExited
                q &= process.StandardOutput.ReadToEnd()
            End While

            q &= "000"

        Catch ex As Exception
            q &= "error"
        End Try
        TextBox1.Text = q
    End Sub

    Public Sub komut2()
        Dim q As String = ""
        Try
            Dim komut As String = "netsh wlan show profile " & """" & ComboBox1.Text.Trim() & """" & " key=clear"
            Dim process As New System.Diagnostics.Process()
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
            process.StartInfo.FileName = "cmd.exe"
            process.StartInfo.Arguments = "/C " & komut
            process.StartInfo.UseShellExecute = False
            process.StartInfo.CreateNoWindow = True
            process.StartInfo.RedirectStandardOutput = True
            process.StartInfo.RedirectStandardInput = True
            process.Start()

            TextBox3.Text = komut

            While Not process.HasExited
                q &= process.StandardOutput.ReadToEnd()
            End While

            q &= "000"

        Catch ex As Exception
            q &= "error"
        End Try
        TextBox3.Text = q
    End Sub

    Public Shared Function getBetween(ByVal strSource As String, ByVal strStart As String, ByVal strEnd As String) As String
        If strSource.Contains(strStart) AndAlso strSource.Contains(strEnd) Then
            Dim Start, [End] As Integer
            Start = strSource.IndexOf(strStart, 0) + strStart.Length
            [End] = strSource.IndexOf(strEnd, Start)
            Return strSource.Substring(Start, [End] - Start)
        End If

        Return ""
    End Function

    Public Sub tocombo()
        Try
            Dim linecount As Integer = TextBox2.Lines.Length
            For i As Integer = 0 To linecount - 1
                Dim kontrol As String = TextBox2.Lines(i).ToString()
                If kontrol = "" Then
                Else
                    ComboBox1.Items.Add(TextBox2.Lines(i))
                End If
            Next
            ComboBox1.SelectedIndex = 0
        Catch
        End Try
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'textBox1.Visible = False
        'textBox2.Visible = False
        'textBox3.Visible = False
        Me.Text = "Telegram: @MONSTERMC"
        komut1()
        Dim data1 As String = TextBox1.Text
        data1 = data1.Replace("All User Profile     :", "")
        'data1 = data1.Replace("-", "");
        Dim data As String = getBetween(data1, "User profiles", "000")
        TextBox2.Text = data
        tocombo()
    End Sub
End Class