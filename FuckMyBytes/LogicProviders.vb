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
End Module
