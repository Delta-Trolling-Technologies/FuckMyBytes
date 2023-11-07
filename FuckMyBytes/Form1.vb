
Imports System.Text

Public Class Form1
    Public mode As Integer
    Dim utf8 As Encoding = Encoding.UTF8
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedItem = ComboBox1.Items.Item(0)
        mode = 0
        enableDecrypt()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim stringBytes As Byte() = utf8.GetBytes(StringEncrypt_String.Text)
        StringEncrypt_Output.Text = AES_Encrypt(Convert.ToBase64String(stringBytes), StringEncrypt_Pwd.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim output As String = AES_Decrypt(StringEncrypt_String.Text, StringEncrypt_Pwd.Text)
        If output = "String decryption failed. Password not correct?" Then
            StringEncrypt_Output.Text = output
        Else
            Dim outputBytes As Byte() = Convert.FromBase64String(output)
            StringEncrypt_Output.Text = utf8.GetString(outputBytes)
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = ComboBox1.Items.Item(0) Then
            mode = 0
            enableDecrypt()
        ElseIf ComboBox1.SelectedItem = ComboBox1.Items.Item(1) Then
            mode = 1
            disableDecrypt()
        End If
    End Sub
End Class
