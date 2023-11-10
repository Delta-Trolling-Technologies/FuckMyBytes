﻿Imports System.Security.Cryptography
Imports System.Text

Public Class Form1
    Public mode As Integer
    Dim utf8 As Encoding = Encoding.UTF8
    Public passbytes As Double
    Public stringbytes As Double
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Logs.Text = "Application Started!"
        ComboBox1.SelectedItem = ComboBox1.Items.Item(0)
        Tester_Technology.SelectedItem = Tester_Technology.Items.Item(0)
        mode = 0
        EnableDecrypt()
        passbytes = 0
        stringbytes = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Logger_log("-----------")
        Dim hashedpass As String = SHAPassgen(StringEncrypt_Pwd.Text)
        Dim stringBytes As Byte() = utf8.GetBytes(StringEncrypt_String.Text)
        Dim encryptstring As String = "Im nothing like yall" + Convert.ToBase64String(stringBytes)
        Dim AESstring As String = AES_Encrypt(encryptstring, hashedpass)
        Dim DESstring As String = DESEncrypt(AESstring, LengthController(hashedpass, 8))
        Dim IDEAstring As String = IDEAEncrypt(DESstring, LengthController(hashedpass, 128))
        StringEncrypt_Output.Text = TripleDESEncrypt(IDEAstring, hashedpass)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Logger_log("-----------")
        Dim hashedpass As String = SHAPassgen(StringEncrypt_Pwd.Text)
        Dim output As String = TripleDESDecrypt(StringEncrypt_String.Text, hashedpass)
        If output = "failed" Then
            StringEncrypt_Output.Text = "String decryption failed. Password not correct?"
        Else
            output = IDEADecrypt(output, LengthController(hashedpass, 128))
            If output = "failed" Then
                StringEncrypt_Output.Text = "String decryption failed. Password not correct?"
            Else
                output = DESDecrypt(output, LengthController(hashedpass, 8))
                If output = "Padding is invalid and cannot be removed." Then
                    StringEncrypt_Output.Text = "String decryption failed. Password not correct?"
                Else
                    output = AES_Decrypt(output, hashedpass)
                    If output = "String decryption failed. Password not correct?" Then
                        StringEncrypt_Output.Text = output
                    Else
                        output = output.Remove(0, "Im nothing like yall".Length)
                        Dim outputbytes As Byte()
                        outputbytes = Convert.FromBase64String(output)
                        Dim aesdecrypted As String = utf8.GetString(outputbytes)
                        StringEncrypt_Output.Text = aesdecrypted
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = ComboBox1.Items.Item(0) Then
            mode = 0
            EnableDecrypt()
        ElseIf ComboBox1.SelectedItem = ComboBox1.Items.Item(1) Then
            mode = 1
            DisableDecrypt()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim mode As Integer = Tester_Technology.SelectedIndex
        Dim output As String
        If mode = 0 Then
            output = AES_Encrypt(Tester_String.Text, Tester_Pass.Text)
        ElseIf mode = 1 Then
            output = AES_Decrypt(Tester_String.Text, Tester_Pass.Text)
        ElseIf mode = 2 Then
            output = SHA512(Tester_String.Text)
        ElseIf mode = 3 Then
            output = SHAPassgen(Tester_String.Text)
        ElseIf mode = 4 Then
            output = DESEncrypt(Tester_String.Text, LengthController(Tester_Pass.Text, 8))
        ElseIf mode = 5 Then
            output = DESDecrypt(Tester_String.Text, LengthController(Tester_Pass.Text, 8))
        ElseIf mode = 6 Then
            output = IDEAEncrypt(Tester_String.Text, LengthController(Tester_Pass.Text, 128))
        ElseIf mode = 7 Then
            output = IDEADecrypt(Tester_String.Text, LengthController(Tester_Pass.Text, 128))
        End If
        Tester_Output.Text = output
    End Sub
End Class
' felakasztom magam
