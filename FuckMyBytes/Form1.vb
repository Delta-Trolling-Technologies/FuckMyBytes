Imports System.IO
Imports System.Text
Public Class Form1
    Public Mode As Integer
    Dim ReadOnly _utf8 As Encoding = Encoding.UTF8
    Public Passbytes As Double
    Public Stringbytes As Double
    Private _encFile As String
    Dim _nencFile As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Logs.Text = "Application Started!"
        ComboBox1.SelectedItem = ComboBox1.Items.Item(0)
        Tester_Technology.SelectedItem = Tester_Technology.Items.Item(0)
        Mode = 0
        EnableDecrypt()
        Passbytes = 0
        Stringbytes = 0
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Logger_log("-----------")
        Dim hashedpass As String = ShaPassgen(StringEncrypt_Pwd.Text)
        Dim stringBytes As Byte() = _utf8.GetBytes(StringEncrypt_String.Text)
        Dim encryptstring As String = "Im nothing like yall" + Convert.ToBase64String(stringBytes)
        Dim aeSstring As String = AES_Encrypt(encryptstring, hashedpass)
        Dim gzip1 As String = GzipCompress(aeSstring)
        Dim deSstring As String = DesEncrypt(gzip1, LengthController(hashedpass, 8))
        Dim ideAstring As String = IdeaEncrypt(deSstring, LengthController(hashedpass, 128))
        Dim gzip2 As String = GzipCompress(ideAstring)
        StringEncrypt_Output.Text = TripleDesEncrypt(gzip2, hashedpass)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Logger_log("-----------")
        Dim hashedpass As String = ShaPassgen(StringEncrypt_Pwd.Text)
        Dim output As String = TripleDesDecrypt(StringEncrypt_String.Text, hashedpass)
        If output = "failed" Then
            StringEncrypt_Output.Text = "String decryption failed. Password not correct?"
        Else
            output = GzipDecompress(output)
            output = IdeaDecrypt(output, LengthController(hashedpass, 128))
            If output = "failed" Then
                StringEncrypt_Output.Text = "String decryption failed. Password not correct?"
            Else
                output = DesDecrypt(output, LengthController(hashedpass, 8))
                If output = "Padding is invalid and cannot be removed." Then
                    StringEncrypt_Output.Text = "String decryption failed. Password not correct?"
                Else
                    output = GzipDecompress(output)
                    output = AES_Decrypt(output, hashedpass)
                    If output = "String decryption failed. Password not correct?" Then
                        StringEncrypt_Output.Text = output
                    Else
                        output = output.Remove(0, "Im nothing like yall".Length)
                        Dim outputbytes As Byte()
                        outputbytes = Convert.FromBase64String(output)
                        Dim aesdecrypted As String = _utf8.GetString(outputbytes)
                        StringEncrypt_Output.Text = aesdecrypted
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = ComboBox1.Items.Item(0) Then
            Mode = 0
            EnableDecrypt()
        ElseIf ComboBox1.SelectedItem = ComboBox1.Items.Item(1) Then
            Mode = 1
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
            output = Sha512(Tester_String.Text)
        ElseIf mode = 3 Then
            output = ShaPassgen(Tester_String.Text)
        ElseIf mode = 4 Then
            output = DesEncrypt(Tester_String.Text, LengthController(Tester_Pass.Text, 8))
        ElseIf mode = 5 Then
            output = DesDecrypt(Tester_String.Text, LengthController(Tester_Pass.Text, 8))
        ElseIf mode = 6 Then
            output = IdeaEncrypt(Tester_String.Text, LengthController(Tester_Pass.Text, 128))
        ElseIf mode = 7 Then
            output = IdeaDecrypt(Tester_String.Text, LengthController(Tester_Pass.Text, 128))
        End If
        Tester_Output.Text = output
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        OpenFileDialog1.Title = "Open non encrypted file"
        OpenFileDialog1.Filter = "Anything (*.*)|*.*"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Dim filePath As String = OpenFileDialog1.FileName
            _nencFile = OpenFileDialog1.FileName
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
            _encFile = OpenFileDialog1.FileName
            Dim fileSizeInBytes As Long = New FileInfo(filePath).Length
            Dim fileSizeInKilobytes As Double = fileSizeInBytes / 1024.0
            FileEncryptor_eSize.Text = "File size: " + fileSizeInKilobytes.ToString("F2") + " KiB"
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
        Dim hashedpass As String = ShaPassgen(GeneratePassword(RandomNumber(8, 32)))
        Dim input As String = ShaPassgen(PWDFileGen_Pass.Text)
        input = GzipCompress(input)
        input = AES_Encrypt(input, hashedpass)
        input = GzipCompress(input)
        input = ShaPassgen(input)
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

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Logger_log("-----------")
        OpenFileDialog1.Title = "Open password file"
        OpenFileDialog1.Filter = "FMB password file (*.fmbp)|*.fmbp"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Dim filePath As String = OpenFileDialog1.FileName
            Try
                Dim loadedText As String = LoadFile(filePath)
                If Not String.IsNullOrEmpty(loadedText) Then
                    Logger_log("Loaded password file.")
                    FileEncrypt_Pwd.Text = loadedText
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

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        'encrypt
        Logger_log("-----------")
        Dim input As String = LoadFile(_nencFile)
        Dim hashedpass As String = ShaPassgen(FileEncrypt_Pwd.Text)
        Dim stringBytes As Byte() = _utf8.GetBytes(input)
        input = "Im nothing like yall" + Convert.ToBase64String(stringBytes)
        input = AES_Encrypt(input, hashedpass)
        input = GzipCompress(input)
        input = DesEncrypt(input, LengthController(hashedpass, 8))
        input = IdeaEncrypt(input, LengthController(hashedpass, 128))
        input = GzipCompress(input)
        input = TripleDesEncrypt(input, hashedpass)
        input = input
        SaveFileDialog1.Filter = "FMB encrypted file (*.fmbf)|*.fmbf"
        SaveFileDialog1.Title = "Save encrypted file"
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            Try
                Dim filePath As String = SaveFileDialog1.FileName
                File.WriteAllText(filePath, Input)
                MessageBox.Show("Encrypted file saved.")
            Catch ex As Exception
                MessageBox.Show("An error occured while saving: " + ex.Message)
            End Try
        Else
            MessageBox.Show("No changes were made.")
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        'decrypt
        Logger_log("-----------")
        Dim hashedpass As String = ShaPassgen(FileEncrypt_Pwd.Text)
        Dim output As String = LoadFile(_encFile)
        output = TripleDesDecrypt(output, hashedpass)
        If output = "failed" Then
            MessageBox.Show("String decryption failed. Password not correct?")
        Else
            output = GzipDecompress(output)
            output = IdeaDecrypt(output, LengthController(hashedpass, 128))
            If output = "failed" Then
                MessageBox.Show("String decryption failed. Password not correct?")
            Else
                output = DesDecrypt(output, LengthController(hashedpass, 8))
                If output = "Padding is invalid and cannot be removed." Then
                    MessageBox.Show("String decryption failed. Password not correct?")
                Else
                    output = GzipDecompress(output)
                    output = AES_Decrypt(output, hashedpass)
                    If output = "String decryption failed. Password not correct?" Then
                        MessageBox.Show(output)
                    Else
                        output = output.Remove(0, "Im nothing like yall".Length)
                        Dim outputbytes As Byte()
                        outputbytes = Convert.FromBase64String(output)
                        output = _utf8.GetString(outputbytes)
                    End If
                End If
            End If
        End If
        SaveFileDialog1.Filter = "Anything (*.*)|*.*"
        SaveFileDialog1.Title = "Save decrypted file"
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            Try
                Dim filePath As String = SaveFileDialog1.FileName
                File.WriteAllText(filePath, output)
                MessageBox.Show("Decrypted file saved.")
            Catch ex As Exception
                MessageBox.Show("An error occured while saving: " + ex.Message)
            End Try
        Else
            MessageBox.Show("No changes were made.")
        End If
    End Sub
End Class
' felakasztom magam
