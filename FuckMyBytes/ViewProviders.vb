Module ViewProviders
    Public Function DisableDecrypt()
        Form1.Button2.Enabled = False
        Return 0
    End Function
    Public Function EnableDecrypt()
        Form1.Button2.Enabled = True
        Return 0
    End Function
End Module
