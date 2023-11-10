Module ViewProviders
    Public Function disableDecrypt()
        Form1.Button2.Enabled = False
        Return 0
    End Function
    Public Function enableDecrypt()
        Form1.Button2.Enabled = True
        Return 0
    End Function
End Module
