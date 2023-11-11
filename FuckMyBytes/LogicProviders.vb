Imports System.IO
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
        Dim byteCount As Integer = System.Text.Encoding.UTF8.GetByteCount(input)
        Dim kibibytes As Double = byteCount / 1024.0
        If what = 0 Then
            Form1.passbytes = Form1.passbytes + kibibytes
        ElseIf what = 1 Then
            Form1.stringbytes = Form1.stringbytes + kibibytes
        End If
        Form1.Statistic.Text = "Processed: " + Form1.stringbytes.ToString("F2") + "KiB/s " + Form1.passbytes.ToString("F2") + "KiB/p"
        Return 0
    End Function
    Public Function Logger_log(ByVal input As String)
        Form1.Logs.Text = Form1.Logs.Text + vbCrLf + input
        Return 0
    End Function
    Function GZIPCompress(input As String) As String
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
    Function GZIPDecompress(input As String) As String
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
End Module
