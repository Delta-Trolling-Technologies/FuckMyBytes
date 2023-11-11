Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports Org.BouncyCastle.Crypto
Imports Org.BouncyCastle.Crypto.Parameters
Imports Org.BouncyCastle.Security
Module EncryptionProviders
    Public Function AES_Encrypt(ByVal input As String, ByVal pass As String) As String
        Using AES As New RijndaelManaged
            Using Hash_AES As New MD5CryptoServiceProvider
                Dim encrypted As String = ""
                Try
                    Dim hash(31) As Byte
                    Dim temp As Byte() = Hash_AES.ComputeHash(Encoding.ASCII.GetBytes(pass))
                    Array.Copy(temp, 0, hash, 0, 16)
                    Array.Copy(temp, 0, hash, 15, 16)
                    AES.Key = hash
                    AES.Mode = CipherMode.ECB
                    Dim DESEncrypter As ICryptoTransform = AES.CreateEncryptor
                    Dim Buffer As Byte() = Encoding.ASCII.GetBytes(input)
                    encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
                    ConvertToKiB(encrypted, 1)
                    Logger_log("AES encrypted: " + encrypted)
                    Return encrypted
                Catch ex As Exception
                    Logger_log("AES thrown an error: " + ex.Message)
                    Return ex.Message
                End Try
            End Using
        End Using
    End Function
    Public Function AES_Decrypt(ByVal input As String, ByVal pass As String) As String
        Using AES As New RijndaelManaged
            Using Hash_AES As New MD5CryptoServiceProvider
                Dim decrypted As String = ""
                Try
                    Dim hash(31) As Byte
                    Dim temp As Byte() = Hash_AES.ComputeHash(Encoding.ASCII.GetBytes(pass))
                    Array.Copy(temp, 0, hash, 0, 16)
                    Array.Copy(temp, 0, hash, 15, 16)
                    AES.Key = hash
                    AES.Mode = CipherMode.ECB
                    Dim DESDecrypter As ICryptoTransform = AES.CreateDecryptor
                    Dim Buffer As Byte() = Convert.FromBase64String(input)
                    decrypted = Encoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
                    ConvertToKiB(decrypted, 1)
                    Logger_log("AES decrypted: " + decrypted)
                    Return decrypted
                Catch ex As Exception
                    Logger_log("AES thrown an error: " + ex.Message)
                    If ex.Message = "Padding is invalid and cannot be removed." Then
                        Return "String decryption failed. Password not correct?"
                    Else
                        Return ex.Message
                    End If
                End Try
            End Using
        End Using
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
        For i As Int32 = 1 To 100
            input = SHA512(input)
        Next i
        Logger_log("Final password hash is: " + input)
        Return input
    End Function
    Public Function DESEncrypt(plainText As String, password As String) As String
        Dim keyBytes As Byte() = Encoding.UTF8.GetBytes(password)
        Dim ivBytes As Byte() = Encoding.UTF8.GetBytes(password)
        Dim output As String
        Try
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
            Logger_log("DES encrypted: " + output)
            Return output
        Catch ex As Exception
            Logger_log("DES thrown an error: " + ex.Message)
            Return 0
        End Try
    End Function
    Public Function DESDecrypt(encryptedText As String, password As String) As String
        Dim keyBytes As Byte() = Encoding.UTF8.GetBytes(password)
        Dim ivBytes As Byte() = Encoding.UTF8.GetBytes(password)
        Dim encryptedBytes As Byte()
        Dim errors As Boolean
        Try
            encryptedBytes = Convert.FromBase64String(encryptedText)
        Catch ex As Exception
            Logger_log("DES thrown an error: " + ex.Message)
            errors = True
        End Try
        Dim output As String
        If errors = False Then
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
                                    Logger_log("DES thrown an error: " + ex.Message)
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
        Logger_log("DES decrypted: " + output)
        Return output
    End Function
    Public Function IDEAEncrypt(data As String, password As String)
        Dim key As Byte() = Encoding.UTF8.GetBytes(password)
        If key.Length < 16 Then
            Logger_log("IDEA thrown an error: password length is not enough")
        End If
        Dim cipher As IBufferedCipher = CipherUtilities.GetCipher("IDEA/ECB/PKCS7Padding")
        cipher.Init(True, New KeyParameter(key))
        Dim dataToEncrypt As Byte() = Encoding.UTF8.GetBytes(data)
        Dim encryptedData As Byte() = cipher.DoFinal(dataToEncrypt)
        Dim encryptedText As String = Convert.ToBase64String(encryptedData)
        ConvertToKiB(encryptedText, 1)
        Logger_log("IDEA encrypted: " + encryptedText)
        Return encryptedText
    End Function
    Public Function IDEADecrypt(encryptedText As String, password As String)
        Dim key As Byte() = Encoding.UTF8.GetBytes(password)
        Dim errors As Boolean
        If key.Length < 16 Then
            Logger_log("IDEA thrown an error: password length is not enough")
        End If
        Dim cipher As IBufferedCipher = CipherUtilities.GetCipher("IDEA/ECB/PKCS7Padding")
        cipher.Init(False, New KeyParameter(key))
        Dim encryptedData As Byte() = Convert.FromBase64String(encryptedText)
        Dim decryptedData As Byte()
        Try
            decryptedData = cipher.DoFinal(encryptedData)
        Catch ex As Exception
            Logger_log("IDEA thrown an error: " + ex.Message)
            errors = True
        End Try
        If errors = False Then
            Dim decryptedText As String = Encoding.UTF8.GetString(decryptedData)
            ConvertToKiB(decryptedText, 1)
            Logger_log("IDEA decrypted: " + decryptedText)
            Return decryptedText
        Else
            Dim decryptedtext As String = "failed"
            Logger_log("IDEA failed decryption.")
            Return decryptedtext
        End If
    End Function
    Public Function TripleDESEncrypt(data As String, password As String) As String
        Dim tripleDesAlg As New TripleDESCryptoServiceProvider()
        Dim key As Byte() = TDESGen(password)
        Dim iv As Byte() = New Byte() {0, 0, 0, 0, 0, 0, 0, 0}
        tripleDesAlg.Key = key
        tripleDesAlg.IV = iv
        Dim encryptor As ICryptoTransform = tripleDesAlg.CreateEncryptor()
        Dim dataBytes As Byte() = Encoding.UTF8.GetBytes(data)
        Dim encryptedData As Byte() = encryptor.TransformFinalBlock(dataBytes, 0, dataBytes.Length)
        Dim output As String = Convert.ToBase64String(encryptedData)
        ConvertToKiB(output, 1)
        Logger_log("3DES encrypted: " + output)
        Return output
    End Function

    Public Function TripleDESDecrypt(encryptedData As String, password As String) As String
        Dim tripleDesAlg As New TripleDESCryptoServiceProvider()
        Dim errors As Boolean
        Dim key As Byte() = TDESGen(password)
        Dim iv As Byte() = New Byte() {0, 0, 0, 0, 0, 0, 0, 0}
        tripleDesAlg.Key = key
        tripleDesAlg.IV = iv
        Dim decryptor As ICryptoTransform = tripleDesAlg.CreateDecryptor()
        Dim encryptedBytes As Byte() = Convert.FromBase64String(encryptedData)
        Dim decryptedBytes As Byte()
        Try
            decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length)
        Catch ex As Exception
            Logger_log("3DES thrown an error: " + ex.Message)
            errors = True
        End Try
        If errors = False Then
            Dim output As String = Encoding.UTF8.GetString(decryptedBytes)
            ConvertToKiB(output, 1)
            Logger_log("3DES decrypted: " + output)
            Return output
        Else
            Dim output As String = "failed"
            Logger_log("3DES failed decryption.")
            Return output
        End If
    End Function
    Public Function TDESGen(password As String) As Byte()
        Dim sha1 As New SHA1CryptoServiceProvider()
        Dim keyBytes As Byte() = sha1.ComputeHash(Encoding.UTF8.GetBytes(password))
        Array.Resize(keyBytes, 24)
        Return keyBytes
    End Function
End Module