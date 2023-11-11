Imports System.IO
Imports System.Text
Public Class Form1
    Public mode As Integer
    Dim utf8 As Encoding = Encoding.UTF8
    Public passbytes As Double
    Public stringbytes As Double
    Public encFile As String
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
        Dim gzip1 As String = GZIPCompress(AESstring)
        Dim DESstring As String = DESEncrypt(gzip1, LengthController(hashedpass, 8))
        Dim IDEAstring As String = IDEAEncrypt(DESstring, LengthController(hashedpass, 128))
        Dim gzip2 As String = GZIPCompress(IDEAstring)
        StringEncrypt_Output.Text = TripleDESEncrypt(gzip2, hashedpass)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Logger_log("-----------")
        Dim hashedpass As String = SHAPassgen(StringEncrypt_Pwd.Text)
        Dim output As String = TripleDESDecrypt(StringEncrypt_String.Text, hashedpass)
        If output = "failed" Then
            StringEncrypt_Output.Text = "String decryption failed. Password not correct?"
        Else
            output = GZIPDecompress(output)
            output = IDEADecrypt(output, LengthController(hashedpass, 128))
            If output = "failed" Then
                StringEncrypt_Output.Text = "String decryption failed. Password not correct?"
            Else
                output = DESDecrypt(output, LengthController(hashedpass, 8))
                If output = "Padding is invalid and cannot be removed." Then
                    StringEncrypt_Output.Text = "String decryption failed. Password not correct?"
                Else
                    output = GZIPDecompress(output)
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
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        OpenFileDialog1.Title = "Open non encrypted file"
        OpenFileDialog1.Filter = "Choose anything (*.*)|*.*"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Dim filePath As String = OpenFileDialog1.FileName
            encFile = OpenFileDialog1.FileName
            Dim fileSizeInBytes As Long = New FileInfo(filePath).Length
            Dim fileSizeInKilobytes As Double = fileSizeInBytes / 1024.0
            FileEncryptor_neSize.Text = "File size: " + fileSizeInKilobytes.ToString("F2") + " KiB"
        Else
            MessageBox.Show("You didn't choose anything")
        End If
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        OpenFileDialog1.Title = "Open encrypted file"
        OpenFileDialog1.Filter = "FMB encrypted file (*.fmbf)|*.fmbf"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Dim filePath As String = OpenFileDialog1.FileName
            encFile = OpenFileDialog1.FileName
            Dim fileSizeInBytes As Long = New FileInfo(filePath).Length
            Dim fileSizeInKilobytes As Double = fileSizeInBytes / 1024.0
            FileEncryptor_neSize.Text = "File size: " + fileSizeInKilobytes.ToString("F2") + " KiB"
        Else
            MessageBox.Show("You didn't choose anything")
        End If
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim password As String = GeneratePassword(RandomNumber(8, 32))
        PWDFileGen_Pass.Text = password
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Logger_log("-----------")
        Dim hashedpass As String = SHAPassgen(GeneratePassword(RandomNumber(8, 32)))
        Dim input As String = SHAPassgen(PWDFileGen_Pass.Text)
        input = GZIPCompress(input)
        input = AES_Encrypt(input, hashedpass)
        input = GZIPCompress(input)
        input = SHAPassgen(input)
        Dim filler As Byte() = GenerateRandomBytes(500000)
        Dim filler2 As Byte() = GenerateRandomBytes(500000)
        input = RandomBytes2String(filler) + input + RandomBytes2String(filler2)
        SaveFileDialog1.Filter = "FMB password file (*.fmbp)|*.fmbp"
        SaveFileDialog1.Title = "Save password file"
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            Try
                Dim filePath As String = SaveFileDialog1.FileName
                File.WriteAllText(filePath, input)
                MessageBox.Show("Password file saved.")
            Catch ex As Exception
                MessageBox.Show("An error occured while saving: " + ex.Message)
            End Try
        Else
            MessageBox.Show("No changes were made.")
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Logger_log("-----------")
        OpenFileDialog1.Title = "Open password file"
        OpenFileDialog1.Filter = "FMB password file (*.fmbp)|*.fmbp"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Dim filePath As String = OpenFileDialog1.FileName
            Try
                Dim loadedText As String = LoadFile(filePath)
                If Not String.IsNullOrEmpty(loadedText) Then
                    Logger_log("Loaded password file.")
                    StringEncrypt_Pwd.Text = loadedText
                Else
                    Logger_log("File empty.")
                End If
            Catch ex As Exception
                Logger_log("Failed loading file: " + ex.Message)
            End Try
        Else
            MessageBox.Show("You didn't choose anything")
        End If
    End Sub
End Class
' felakasztom magam
