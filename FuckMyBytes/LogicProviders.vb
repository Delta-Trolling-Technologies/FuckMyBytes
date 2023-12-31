﻿Imports System.IO
Imports System.IO.Compression
Imports System.Text
Module LogicProviders
    Public Function LengthController(hashValue As String, length As Integer) As String
        Dim shortenedHash As String
        If hashValue.Length < length Then
            Dim charactersToAdd As Integer = length - hashValue.Length
            shortenedHash = hashValue & New String("X"c, charactersToAdd)
        Else
            shortenedHash = hashValue.Substring(0, length)
        End If
        Return shortenedHash
    End Function
    Public Function ConvertToKiB(input As String, what As Integer) As Double
        Dim byteCount As Integer = Encoding.UTF8.GetByteCount(input)
        Dim kibibytes As Double = byteCount / 1024.0
        If what = 0 Then
            Form1.Passbytes = Form1.Passbytes + kibibytes
        ElseIf what = 1 Then
            Form1.Stringbytes = Form1.Stringbytes + kibibytes
        End If
        Form1.Statistic.Text = "Processed: " + Form1.Stringbytes.ToString("F2") + "KiB/s " + Form1.Passbytes.ToString("F2") + "KiB/p"
        Return 0
    End Function
    Public Function Logger_log(ByVal input As String)
        Form1.Logs.Text = Form1.Logs.Text + vbCrLf + input
        Return 0
    End Function
    Public Function GzipCompress(input As String) As String
        Using outputStream As New MemoryStream()
            Using gZipStream As New GZipStream(outputStream, CompressionLevel.Optimal)
                Using writer As New StreamWriter(gZipStream, Encoding.UTF8)
                    writer.Write(input)
                End Using
            End Using
            Dim output As String = Convert.ToBase64String(outputStream.ToArray())
            ConvertToKiB(output, 1)
            Logger_log("GZIP compressed: " + output)
            Return output
        End Using
    End Function
    Public Function GzipDecompress(input As String) As String
        Dim compressedBytes As Byte() = Convert.FromBase64String(input)
        Using inputStream As New MemoryStream(compressedBytes)
            Using gZipStream As New GZipStream(inputStream, CompressionMode.Decompress)
                Using reader As New StreamReader(gZipStream, Encoding.UTF8)
                    Dim output As String = reader.ReadToEnd()
                    ConvertToKiB(output, 1)
                    Logger_log("GZIP decompressed: " + output)
                    Return output
                End Using
            End Using
        End Using
    End Function
    Public Function RandomNumber(min As Integer, max As Integer) As Integer
        Static random As New Random()
        Dim output As Integer = random.Next(min, max)
        Return output
    End Function
    Function GeneratePassword(length As Integer) As String
        Const uppercaseChars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Const lowercaseChars As String = "abcdefghijklmnopqrstuvwxyz"
        Const specialChars As String = "@#$%^&*()-_=+[]{}|;:'<>,.?/~"
        Const numericChars As String = "0123456789"
        Dim allChars As String = uppercaseChars & lowercaseChars & specialChars & numericChars
        Dim passwordBuilder As New StringBuilder()
        Dim rand As New Random()
        For i = 0 To length - 1
            Dim randomIndex As Integer = rand.Next(0, allChars.Length)
            passwordBuilder.Append(allChars(randomIndex))
        Next
        Return passwordBuilder.ToString()
    End Function
    Function GenerateRandomBytes(length As Integer) As Byte()
        Dim random As New Random()
        Dim randomBytes(length - 1) As Byte
        random.NextBytes(randomBytes)
        Return randomBytes
    End Function
    Function RandomBytes2String(randomBytes() As Byte) As String
        Dim stringBuilder As New StringBuilder("")
        For Each randomByte As Byte In randomBytes
            stringBuilder.Append(Convert.ToChar(randomByte))
        Next
        Return stringBuilder.ToString()
    End Function
    Public Function LoadFile(filePath As String) As String
        If File.Exists(filePath) Then
            Return File.ReadAllText(filePath)
        Else
            Logger_log("File not found at: " + filePath)
            Throw New FileNotFoundException
        End If
    End Function
End Module
