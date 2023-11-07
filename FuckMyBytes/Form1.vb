Imports FuckMyBytes.EncryptionProviders
Public Class Form1
    Public mode As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedItem = ComboBox1.Items.Item(0)
        mode = 0
        ViewProviders.enableDecrypt()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        StringEncrypt_Output.Text = EncryptionProviders.AES_Encrypt(StringEncrypt_String.Text, StringEncrypt_Pwd.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        StringEncrypt_Output.Text = EncryptionProviders.AES_Decrypt(StringEncrypt_String.Text, StringEncrypt_Pwd.Text)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = ComboBox1.Items.Item(0) Then
            mode = 0
            ViewProviders.enableDecrypt()
        ElseIf ComboBox1.SelectedItem = ComboBox1.Items.Item(1) Then
            mode = 1
            ViewProviders.disableDecrypt()
        End If
    End Sub
End Class
