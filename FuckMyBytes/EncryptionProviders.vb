Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Module EncryptionProviders
    Public Function AES_Encrypt(ByVal input As String, ByVal pass As String) As String
        Dim AES As New Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New Security.Cryptography.MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            ConvertToKiB(encrypted, 1)
            Return encrypted
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function AES_Decrypt(ByVal input As String, ByVal pass As String) As String
        Dim AES As New Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New Security.Cryptography.MD5CryptoServiceProvider
        Dim decrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(input)
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            ConvertToKiB(decrypted, 1)
            Return decrypted
        Catch ex As Exception
            If ex.Message = "Padding is invalid and cannot be removed." Then
                Return "String decryption failed. Password not correct?"
            Else
                Return ex.Message
            End If
        End Try
    End Function
    Public Function SHA512(ByVal input As String) As String
        Dim data As Byte() = Encoding.UTF8.GetBytes(input)
        Using sha As SHA512 = sha.Create()
            Dim hashBytes As Byte() = sha.ComputeHash(data)
            Dim hashString As String = BitConverter.ToString(hashBytes).Replace("-", "").ToLower()
            ConvertToKiB(hashString, 0)
            Return hashString
        End Using
    End Function
    Public Function SHAPassgen(ByVal input As String) As String
        Dim in1 As String = SHA512(input)
        Dim in2 As String = SHA512(in1)
        Dim in3 As String = SHA512(in2)
        Dim in4 As String = SHA512(in3)
        Dim in5 As String = SHA512(in4)
        Dim in6 As String = SHA512(in5)
        Dim in7 As String = SHA512(in6)
        Dim in8 As String = SHA512(in7)
        Dim in9 As String = SHA512(in8)
        Dim in10 As String = SHA512(in9)
        Return in10
    End Function
    Public Function DESEncrypt(plainText As String, password As String) As String
        Dim keyBytes As Byte() = Encoding.UTF8.GetBytes(password)
        Dim ivBytes As Byte() = Encoding.UTF8.GetBytes(password)
        Dim output As String
        Using desAlg As DESCryptoServiceProvider = New DESCryptoServiceProvider()
            desAlg.Key = keyBytes
            desAlg.IV = ivBytes

            Using encryptor As ICryptoTransform = desAlg.CreateEncryptor(keyBytes, ivBytes)
                Using msEncrypt As New MemoryStream()
                    Using csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)
                        Using swEncrypt As New StreamWriter(csEncrypt)
                            swEncrypt.Write(plainText)
                        End Using
                    End Using
                    output = Convert.ToBase64String(msEncrypt.ToArray())
                End Using
            End Using
        End Using
        ConvertToKiB(output, 1)
        Return output
    End Function
    Public Function DESDecrypt(encryptedText As String, password As String) As String
        Dim keyBytes As Byte() = Encoding.UTF8.GetBytes(password)
        Dim ivBytes As Byte() = Encoding.UTF8.GetBytes(password)
        Dim encryptedBytes As Byte()
        Dim errors As Boolean
        Try
            encryptedBytes = Convert.FromBase64String(encryptedText)
        Catch ex As Exception
            Debug.WriteLine("ex: " + ex.Message)
            errors = True
        End Try
        Dim output As String
        If Errors = False Then
            Using desAlg As DESCryptoServiceProvider = New DESCryptoServiceProvider()
                desAlg.Key = keyBytes
                desAlg.IV = ivBytes

                Using decryptor As ICryptoTransform = desAlg.CreateDecryptor(keyBytes, ivBytes)
                    Using msDecrypt As New MemoryStream(encryptedBytes)
                        Using csDecrypt As New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)
                            Using srDecrypt As New StreamReader(csDecrypt)
                                Try
                                    output = srDecrypt.ReadToEnd()
                                Catch ex As Exception
                                    output = ex.Message
                                End Try
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        Else
            output = "Padding is invalid and cannot be removed."
        End If
        ConvertToKiB(output, 1)
        Return output
    End Function
End Module
