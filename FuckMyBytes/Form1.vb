Imports System.Text

Public Class Form1
    Public mode As Integer
    Dim utf8 As Encoding = Encoding.UTF8
    Public passbytes As Double
    Public stringbytes As Double
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedItem = ComboBox1.Items.Item(0)
        mode = 0
        enableDecrypt()
        passbytes = 0
        stringbytes = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim hashedpass As String = SHAPassgen(StringEncrypt_Pwd.Text)
        Debug.WriteLine("hashed pass: " + hashedpass)
        Dim stringBytes As Byte() = utf8.GetBytes(StringEncrypt_String.Text)
        Dim encryptstring As String = "Im nothing like yall" + Convert.ToBase64String(stringBytes)
        Debug.WriteLine("got: " + encryptstring)
        Dim AESstring As String = AES_Encrypt(encryptstring, hashedpass)
        Debug.WriteLine("aes got: " + AESstring)
        StringEncrypt_Output.Text = DESEncrypt(AESstring, ShortenHashValue(hashedpass, 8))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim hashedpass As String = SHAPassgen(StringEncrypt_Pwd.Text)
        Debug.WriteLine("hashed pass: " + hashedpass)
        Dim output As String = DESDecrypt(StringEncrypt_String.Text, ShortenHashValue(hashedpass, 8))
        Debug.WriteLine("des got: " + output)
        If output = "Padding is invalid and cannot be removed." Then
            StringEncrypt_Output.Text = "String decryption failed. Password not correct?"
        Else
            output = AES_Decrypt(output, hashedpass)
            Debug.WriteLine("aes got: " + output)
            If output = "String decryption failed. Password not correct?" Then
                StringEncrypt_Output.Text = output
            Else
                output = output.Remove(0, "Im nothing like yall".Length)
                Debug.WriteLine("removed string: " + output)
                Dim outputbytes As Byte()
                outputbytes = Convert.FromBase64String(output)
                Dim aesdecrypted As String = utf8.GetString(outputBytes)
                Debug.WriteLine("base64 got: " + aesdecrypted)
                StringEncrypt_Output.Text = aesdecrypted
            End If
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
