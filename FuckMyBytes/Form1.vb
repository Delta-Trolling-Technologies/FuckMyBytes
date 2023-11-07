Imports FuckMyBytes.EncryptionProviders
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RichTextBox1.Text = EncryptionProviders.AES_Encrypt(TextBox1.Text, TextBox2.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RichTextBox1.Text = EncryptionProviders.AES_Decrypt(TextBox1.Text, TextBox2.Text)
    End Sub
End Class
