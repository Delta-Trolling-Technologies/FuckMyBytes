Module LogicProviders
    Public Function ShortenHashValue(hashValue As String, length As Integer) As String
        Dim shortenedHash As String
        If hashValue.Length < length Then
            shortenedHash = "F@ck1234"
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
    End Function
End Module
