<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label2 = New Label()
        Label3 = New Label()
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        StringEncrypt_Output = New RichTextBox()
        Label1 = New Label()
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        StringEncrypt_Pwd = New TextBox()
        StringEncrypt_String = New TextBox()
        TabPage2 = New TabPage()
        ComboBox1 = New ComboBox()
        StatusStrip1 = New StatusStrip()
        Status = New ToolStripStatusLabel()
        ToolStripProgressBar1 = New ToolStripProgressBar()
        Statistic = New ToolStripStatusLabel()
        TabPage3 = New TabPage()
        Tester_Technology = New ComboBox()
        Label4 = New Label()
        Tester_String = New TextBox()
        Tester_Pass = New TextBox()
        Button4 = New Button()
        Tester_Output = New RichTextBox()
        TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        StatusStrip1.SuspendLayout()
        TabPage3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.Location = New Point(646, 9)
        Label2.Name = "Label2"
        Label2.Size = New Size(142, 30)
        Label2.TabIndex = 6
        Label2.Text = "FuckMyBytes"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(596, 39)
        Label3.Name = "Label3"
        Label3.Size = New Size(192, 15)
        Label3.TabIndex = 7
        Label3.Text = "Advanced byte fucking technology"
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Controls.Add(TabPage3)
        TabControl1.Location = New Point(12, 39)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(776, 399)
        TabControl1.TabIndex = 8
        ' 
        ' TabPage1
        ' 
        TabPage1.BackColor = Color.Black
        TabPage1.Controls.Add(StringEncrypt_Output)
        TabPage1.Controls.Add(Label1)
        TabPage1.Controls.Add(Button3)
        TabPage1.Controls.Add(Button2)
        TabPage1.Controls.Add(Button1)
        TabPage1.Controls.Add(StringEncrypt_Pwd)
        TabPage1.Controls.Add(StringEncrypt_String)
        TabPage1.Location = New Point(4, 24)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(768, 371)
        TabPage1.TabIndex = 0
        TabPage1.Text = "String"
        ' 
        ' StringEncrypt_Output
        ' 
        StringEncrypt_Output.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        StringEncrypt_Output.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        StringEncrypt_Output.Location = New Point(6, 79)
        StringEncrypt_Output.Name = "StringEncrypt_Output"
        StringEncrypt_Output.ReadOnly = True
        StringEncrypt_Output.Size = New Size(756, 286)
        StringEncrypt_Output.TabIndex = 6
        StringEncrypt_Output.Text = ""
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(6, 61)
        Label1.Name = "Label1"
        Label1.Size = New Size(45, 15)
        Label1.TabIndex = 5
        Label1.Text = "Output"
        ' 
        ' Button3
        ' 
        Button3.ForeColor = Color.Black
        Button3.Location = New Point(523, 35)
        Button3.Name = "Button3"
        Button3.Size = New Size(101, 23)
        Button3.TabIndex = 4
        Button3.Text = "Load from file"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.ForeColor = Color.Black
        Button2.Location = New Point(630, 35)
        Button2.Name = "Button2"
        Button2.Size = New Size(132, 23)
        Button2.TabIndex = 3
        Button2.Text = "Decrypt"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.ForeColor = Color.Black
        Button1.Location = New Point(630, 6)
        Button1.Name = "Button1"
        Button1.Size = New Size(132, 23)
        Button1.TabIndex = 2
        Button1.Text = "Encrypt"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' StringEncrypt_Pwd
        ' 
        StringEncrypt_Pwd.Location = New Point(6, 35)
        StringEncrypt_Pwd.Name = "StringEncrypt_Pwd"
        StringEncrypt_Pwd.PlaceholderText = "Encryption Password"
        StringEncrypt_Pwd.Size = New Size(511, 23)
        StringEncrypt_Pwd.TabIndex = 1
        ' 
        ' StringEncrypt_String
        ' 
        StringEncrypt_String.Location = New Point(6, 6)
        StringEncrypt_String.Name = "StringEncrypt_String"
        StringEncrypt_String.PlaceholderText = "String"
        StringEncrypt_String.Size = New Size(618, 23)
        StringEncrypt_String.TabIndex = 0
        ' 
        ' TabPage2
        ' 
        TabPage2.Location = New Point(4, 24)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(768, 371)
        TabPage2.TabIndex = 1
        TabPage2.Text = "File"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' ComboBox1
        ' 
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"Non-Destructive (Encrypt/Decrypt)", "Destructive (Encrypt only)"})
        ComboBox1.Location = New Point(12, 9)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(211, 23)
        ComboBox1.TabIndex = 10
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.Items.AddRange(New ToolStripItem() {Status, ToolStripProgressBar1, Statistic})
        StatusStrip1.Location = New Point(0, 441)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.RenderMode = ToolStripRenderMode.Professional
        StatusStrip1.Size = New Size(800, 22)
        StatusStrip1.SizingGrip = False
        StatusStrip1.TabIndex = 11
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' Status
        ' 
        Status.ForeColor = Color.Black
        Status.Name = "Status"
        Status.Size = New Size(26, 17)
        Status.Text = "Idle"
        ' 
        ' ToolStripProgressBar1
        ' 
        ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        ToolStripProgressBar1.Size = New Size(100, 16)
        ToolStripProgressBar1.Step = 1
        ToolStripProgressBar1.Style = ProgressBarStyle.Continuous
        ' 
        ' Statistic
        ' 
        Statistic.ForeColor = Color.Black
        Statistic.Name = "Statistic"
        Statistic.Size = New Size(137, 17)
        Statistic.Text = "Processed: 0KiB/s 0KiB/p"
        ' 
        ' TabPage3
        ' 
        TabPage3.BackColor = Color.Black
        TabPage3.Controls.Add(Tester_Output)
        TabPage3.Controls.Add(Button4)
        TabPage3.Controls.Add(Tester_Pass)
        TabPage3.Controls.Add(Tester_String)
        TabPage3.Controls.Add(Label4)
        TabPage3.Controls.Add(Tester_Technology)
        TabPage3.Location = New Point(4, 24)
        TabPage3.Name = "TabPage3"
        TabPage3.Padding = New Padding(3)
        TabPage3.Size = New Size(768, 371)
        TabPage3.TabIndex = 2
        TabPage3.Text = "Tester"
        ' 
        ' Tester_Technology
        ' 
        Tester_Technology.DropDownStyle = ComboBoxStyle.DropDownList
        Tester_Technology.FormattingEnabled = True
        Tester_Technology.Items.AddRange(New Object() {"AES Encrypt (Plain password)", "AES Decrypt (Plain password)", "SHA512", "FMB-SHA512x100", "DES Encrypt (Plain password max:8 char)", "DES Decrypt (Plain password max:8 char)", "IDEA Encrypt (Plain password max:8 char)", "IDEA Decrypt (Plain password max:8 char)"})
        Tester_Technology.Location = New Point(6, 21)
        Tester_Technology.Name = "Tester_Technology"
        Tester_Technology.Size = New Size(756, 23)
        Tester_Technology.TabIndex = 0
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(6, 3)
        Label4.Name = "Label4"
        Label4.Size = New Size(68, 15)
        Label4.TabIndex = 1
        Label4.Text = "Technology"
        ' 
        ' Tester_String
        ' 
        Tester_String.Location = New Point(6, 50)
        Tester_String.Name = "Tester_String"
        Tester_String.PlaceholderText = "String (input)"
        Tester_String.Size = New Size(756, 23)
        Tester_String.TabIndex = 2
        ' 
        ' Tester_Pass
        ' 
        Tester_Pass.Location = New Point(6, 79)
        Tester_Pass.Name = "Tester_Pass"
        Tester_Pass.PlaceholderText = "Password (optional)"
        Tester_Pass.Size = New Size(675, 23)
        Tester_Pass.TabIndex = 3
        ' 
        ' Button4
        ' 
        Button4.ForeColor = Color.Black
        Button4.Location = New Point(687, 78)
        Button4.Name = "Button4"
        Button4.Size = New Size(75, 23)
        Button4.TabIndex = 4
        Button4.Text = "$Execute$"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Tester_Output
        ' 
        Tester_Output.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        Tester_Output.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        Tester_Output.Location = New Point(6, 108)
        Tester_Output.Name = "Tester_Output"
        Tester_Output.Size = New Size(756, 257)
        Tester_Output.TabIndex = 5
        Tester_Output.Text = ""
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        ClientSize = New Size(800, 463)
        Controls.Add(StatusStrip1)
        Controls.Add(ComboBox1)
        Controls.Add(Label2)
        Controls.Add(Label3)
        Controls.Add(TabControl1)
        ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        Name = "Form1"
        Text = "FuckMyBytes"
        TabControl1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage1.PerformLayout()
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        TabPage3.ResumeLayout(False)
        TabPage3.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Status As ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents StringEncrypt_String As TextBox
    Friend WithEvents StringEncrypt_Pwd As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Statistic As ToolStripStatusLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents StringEncrypt_Output As RichTextBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Tester_Technology As ComboBox
    Friend WithEvents Tester_String As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Tester_Pass As TextBox
    Friend WithEvents Tester_Output As RichTextBox
End Class
