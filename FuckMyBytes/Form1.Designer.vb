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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
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
        Button11 = New Button()
        Button10 = New Button()
        Button9 = New Button()
        FileEncrypt_Pwd = New TextBox()
        FileEncryptor_eSize = New Label()
        Button6 = New Button()
        Label6 = New Label()
        FileEncryptor_neSize = New Label()
        Button5 = New Button()
        TabPage3 = New TabPage()
        Tester_Output = New RichTextBox()
        Button4 = New Button()
        Tester_Pass = New TextBox()
        Tester_String = New TextBox()
        Label4 = New Label()
        Tester_Technology = New ComboBox()
        TabPage4 = New TabPage()
        Logs = New RichTextBox()
        TabPage5 = New TabPage()
        Button8 = New Button()
        RichTextBox1 = New RichTextBox()
        Label7 = New Label()
        PWDFileGen_Pass = New TextBox()
        Button7 = New Button()
        Label5 = New Label()
        ComboBox1 = New ComboBox()
        StatusStrip1 = New StatusStrip()
        Statistic = New ToolStripStatusLabel()
        OpenFileDialog1 = New OpenFileDialog()
        SaveFileDialog1 = New SaveFileDialog()
        TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        TabPage2.SuspendLayout()
        TabPage3.SuspendLayout()
        TabPage4.SuspendLayout()
        TabPage5.SuspendLayout()
        StatusStrip1.SuspendLayout()
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
        TabControl1.Controls.Add(TabPage4)
        TabControl1.Controls.Add(TabPage5)
        TabControl1.Location = New Point(0, 39)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(800, 399)
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
        TabPage1.Size = New Size(792, 371)
        TabPage1.TabIndex = 0
        TabPage1.Text = "String"
        ' 
        ' StringEncrypt_Output
        ' 
        StringEncrypt_Output.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        StringEncrypt_Output.BorderStyle = BorderStyle.None
        StringEncrypt_Output.Dock = DockStyle.Bottom
        StringEncrypt_Output.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        StringEncrypt_Output.Location = New Point(3, 82)
        StringEncrypt_Output.Name = "StringEncrypt_Output"
        StringEncrypt_Output.ReadOnly = True
        StringEncrypt_Output.Size = New Size(786, 286)
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
        Button3.Location = New Point(545, 34)
        Button3.Name = "Button3"
        Button3.Size = New Size(101, 23)
        Button3.TabIndex = 4
        Button3.Text = "Load from file"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.ForeColor = Color.Black
        Button2.Location = New Point(652, 35)
        Button2.Name = "Button2"
        Button2.Size = New Size(132, 23)
        Button2.TabIndex = 3
        Button2.Text = "Decrypt"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.ForeColor = Color.Black
        Button1.Location = New Point(652, 6)
        Button1.Name = "Button1"
        Button1.Size = New Size(132, 23)
        Button1.TabIndex = 2
        Button1.Text = "Encrypt"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' StringEncrypt_Pwd
        ' 
        StringEncrypt_Pwd.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        StringEncrypt_Pwd.Location = New Point(6, 35)
        StringEncrypt_Pwd.MaxLength = Integer.MaxValue
        StringEncrypt_Pwd.Name = "StringEncrypt_Pwd"
        StringEncrypt_Pwd.PlaceholderText = "Encryption Password"
        StringEncrypt_Pwd.Size = New Size(533, 23)
        StringEncrypt_Pwd.TabIndex = 1
        ' 
        ' StringEncrypt_String
        ' 
        StringEncrypt_String.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        StringEncrypt_String.Location = New Point(6, 6)
        StringEncrypt_String.Name = "StringEncrypt_String"
        StringEncrypt_String.PlaceholderText = "String"
        StringEncrypt_String.Size = New Size(640, 23)
        StringEncrypt_String.TabIndex = 0
        ' 
        ' TabPage2
        ' 
        TabPage2.BackColor = Color.Black
        TabPage2.Controls.Add(Button11)
        TabPage2.Controls.Add(Button10)
        TabPage2.Controls.Add(Button9)
        TabPage2.Controls.Add(FileEncrypt_Pwd)
        TabPage2.Controls.Add(FileEncryptor_eSize)
        TabPage2.Controls.Add(Button6)
        TabPage2.Controls.Add(Label6)
        TabPage2.Controls.Add(FileEncryptor_neSize)
        TabPage2.Controls.Add(Button5)
        TabPage2.Location = New Point(4, 24)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(792, 371)
        TabPage2.TabIndex = 1
        TabPage2.Text = "File"
        ' 
        ' Button11
        ' 
        Button11.ForeColor = Color.Black
        Button11.Location = New Point(248, 105)
        Button11.Name = "Button11"
        Button11.Size = New Size(75, 23)
        Button11.TabIndex = 8
        Button11.Text = "Decrypt"
        Button11.UseVisualStyleBackColor = True
        ' 
        ' Button10
        ' 
        Button10.ForeColor = Color.Black
        Button10.Location = New Point(167, 105)
        Button10.Name = "Button10"
        Button10.Size = New Size(75, 23)
        Button10.TabIndex = 7
        Button10.Text = "Encrypt"
        Button10.UseVisualStyleBackColor = True
        ' 
        ' Button9
        ' 
        Button9.ForeColor = Color.Black
        Button9.Location = New Point(8, 105)
        Button9.Name = "Button9"
        Button9.Size = New Size(149, 23)
        Button9.TabIndex = 6
        Button9.Text = "Load password from file"
        Button9.UseVisualStyleBackColor = True
        ' 
        ' FileEncrypt_Pwd
        ' 
        FileEncrypt_Pwd.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        FileEncrypt_Pwd.Location = New Point(8, 76)
        FileEncrypt_Pwd.MaxLength = Integer.MaxValue
        FileEncrypt_Pwd.Name = "FileEncrypt_Pwd"
        FileEncrypt_Pwd.PlaceholderText = "Encryption Password"
        FileEncrypt_Pwd.Size = New Size(776, 23)
        FileEncrypt_Pwd.TabIndex = 5
        ' 
        ' FileEncryptor_eSize
        ' 
        FileEncryptor_eSize.AutoSize = True
        FileEncryptor_eSize.Location = New Point(163, 51)
        FileEncryptor_eSize.Name = "FileEncryptor_eSize"
        FileEncryptor_eSize.Size = New Size(79, 15)
        FileEncryptor_eSize.TabIndex = 4
        FileEncryptor_eSize.Text = "File size: 0 KiB"
        ' 
        ' Button6
        ' 
        Button6.ForeColor = Color.Black
        Button6.Location = New Point(6, 47)
        Button6.Name = "Button6"
        Button6.Size = New Size(151, 23)
        Button6.TabIndex = 3
        Button6.Text = "Open encrypted file"
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(6, 29)
        Label6.Name = "Label6"
        Label6.Size = New Size(20, 15)
        Label6.TabIndex = 2
        Label6.Text = "Or"
        ' 
        ' FileEncryptor_neSize
        ' 
        FileEncryptor_neSize.AutoSize = True
        FileEncryptor_neSize.Location = New Point(163, 7)
        FileEncryptor_neSize.Name = "FileEncryptor_neSize"
        FileEncryptor_neSize.Size = New Size(79, 15)
        FileEncryptor_neSize.TabIndex = 1
        FileEncryptor_neSize.Text = "File size: 0 KiB"
        ' 
        ' Button5
        ' 
        Button5.ForeColor = Color.Black
        Button5.Location = New Point(6, 3)
        Button5.Name = "Button5"
        Button5.Size = New Size(151, 23)
        Button5.TabIndex = 0
        Button5.Text = "Open non-encrypted file"
        Button5.UseVisualStyleBackColor = True
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
        TabPage3.Size = New Size(792, 371)
        TabPage3.TabIndex = 2
        TabPage3.Text = "Tester"
        ' 
        ' Tester_Output
        ' 
        Tester_Output.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        Tester_Output.BorderStyle = BorderStyle.None
        Tester_Output.Dock = DockStyle.Bottom
        Tester_Output.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        Tester_Output.Location = New Point(3, 111)
        Tester_Output.Name = "Tester_Output"
        Tester_Output.Size = New Size(786, 257)
        Tester_Output.TabIndex = 5
        Tester_Output.Text = ""
        ' 
        ' Button4
        ' 
        Button4.ForeColor = Color.Black
        Button4.Location = New Point(709, 78)
        Button4.Name = "Button4"
        Button4.Size = New Size(75, 23)
        Button4.TabIndex = 4
        Button4.Text = "$Execute$"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Tester_Pass
        ' 
        Tester_Pass.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        Tester_Pass.Location = New Point(6, 79)
        Tester_Pass.Name = "Tester_Pass"
        Tester_Pass.PasswordChar = "*"c
        Tester_Pass.PlaceholderText = "Password"
        Tester_Pass.Size = New Size(697, 23)
        Tester_Pass.TabIndex = 3
        Tester_Pass.UseSystemPasswordChar = True
        ' 
        ' Tester_String
        ' 
        Tester_String.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        Tester_String.Location = New Point(6, 50)
        Tester_String.Name = "Tester_String"
        Tester_String.PlaceholderText = "String (input)"
        Tester_String.Size = New Size(778, 23)
        Tester_String.TabIndex = 2
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
        ' Tester_Technology
        ' 
        Tester_Technology.DropDownStyle = ComboBoxStyle.DropDownList
        Tester_Technology.FormattingEnabled = True
        Tester_Technology.Items.AddRange(New Object() {"AES Encrypt (Plain password)", "AES Decrypt (Plain password)", "SHA512", "FMB-SHA512x100", "DES Encrypt (Plain password max:8 char)", "DES Decrypt (Plain password max:8 char)", "IDEA Encrypt (Plain password max:8 char)", "IDEA Decrypt (Plain password max:8 char)"})
        Tester_Technology.Location = New Point(6, 21)
        Tester_Technology.Name = "Tester_Technology"
        Tester_Technology.Size = New Size(778, 23)
        Tester_Technology.TabIndex = 0
        ' 
        ' TabPage4
        ' 
        TabPage4.BackColor = Color.Black
        TabPage4.Controls.Add(Logs)
        TabPage4.Location = New Point(4, 24)
        TabPage4.Name = "TabPage4"
        TabPage4.Padding = New Padding(3)
        TabPage4.Size = New Size(792, 371)
        TabPage4.TabIndex = 3
        TabPage4.Text = "Logs"
        ' 
        ' Logs
        ' 
        Logs.BackColor = Color.Black
        Logs.BorderStyle = BorderStyle.None
        Logs.Dock = DockStyle.Fill
        Logs.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        Logs.Location = New Point(3, 3)
        Logs.Name = "Logs"
        Logs.ReadOnly = True
        Logs.ScrollBars = RichTextBoxScrollBars.Vertical
        Logs.Size = New Size(786, 365)
        Logs.TabIndex = 0
        Logs.Text = ""
        ' 
        ' TabPage5
        ' 
        TabPage5.BackColor = Color.Black
        TabPage5.Controls.Add(Button8)
        TabPage5.Controls.Add(RichTextBox1)
        TabPage5.Controls.Add(Label7)
        TabPage5.Controls.Add(PWDFileGen_Pass)
        TabPage5.Controls.Add(Button7)
        TabPage5.Controls.Add(Label5)
        TabPage5.Location = New Point(4, 24)
        TabPage5.Name = "TabPage5"
        TabPage5.Padding = New Padding(3)
        TabPage5.Size = New Size(792, 371)
        TabPage5.TabIndex = 4
        TabPage5.Text = "Key Maker"
        ' 
        ' Button8
        ' 
        Button8.ForeColor = Color.Black
        Button8.Location = New Point(621, 50)
        Button8.Name = "Button8"
        Button8.Size = New Size(163, 23)
        Button8.TabIndex = 5
        Button8.Text = "Generate my password file!"
        Button8.UseVisualStyleBackColor = True
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.BackColor = Color.Black
        RichTextBox1.BorderStyle = BorderStyle.None
        RichTextBox1.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        RichTextBox1.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        RichTextBox1.Location = New Point(126, 135)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.ReadOnly = True
        RichTextBox1.ScrollBars = RichTextBoxScrollBars.None
        RichTextBox1.Size = New Size(636, 230)
        RichTextBox1.TabIndex = 4
        RichTextBox1.Text = resources.GetString("RichTextBox1.Text")
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label7.Location = New Point(126, 111)
        Label7.Name = "Label7"
        Label7.Size = New Size(108, 21)
        Label7.TabIndex = 3
        Label7.Text = "How it works?"
        ' 
        ' PWDFileGen_Pass
        ' 
        PWDFileGen_Pass.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        PWDFileGen_Pass.Location = New Point(6, 21)
        PWDFileGen_Pass.Name = "PWDFileGen_Pass"
        PWDFileGen_Pass.PasswordChar = "*"c
        PWDFileGen_Pass.PlaceholderText = "Password"
        PWDFileGen_Pass.Size = New Size(778, 23)
        PWDFileGen_Pass.TabIndex = 2
        PWDFileGen_Pass.UseSystemPasswordChar = True
        ' 
        ' Button7
        ' 
        Button7.ForeColor = Color.Black
        Button7.Location = New Point(6, 50)
        Button7.Name = "Button7"
        Button7.Size = New Size(104, 23)
        Button7.TabIndex = 1
        Button7.Text = "Or generate one"
        Button7.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(6, 3)
        Label5.Name = "Label5"
        Label5.Size = New Size(87, 15)
        Label5.TabIndex = 0
        Label5.Text = "Enter Password"
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
        StatusStrip1.Items.AddRange(New ToolStripItem() {Statistic})
        StatusStrip1.Location = New Point(0, 441)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.RenderMode = ToolStripRenderMode.Professional
        StatusStrip1.Size = New Size(800, 22)
        StatusStrip1.SizingGrip = False
        StatusStrip1.TabIndex = 11
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' Statistic
        ' 
        Statistic.ForeColor = Color.Black
        Statistic.Name = "Statistic"
        Statistic.Size = New Size(137, 17)
        Statistic.Text = "Processed: 0KiB/s 0KiB/p"
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.FileName = "OpenFileDialog1"
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
        DoubleBuffered = True
        ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "Form1"
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterScreen
        Text = "FuckMyBytes"
        TabControl1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage1.PerformLayout()
        TabPage2.ResumeLayout(False)
        TabPage2.PerformLayout()
        TabPage3.ResumeLayout(False)
        TabPage3.PerformLayout()
        TabPage4.ResumeLayout(False)
        TabPage5.ResumeLayout(False)
        TabPage5.PerformLayout()
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
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
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents Logs As RichTextBox
    Friend WithEvents Button5 As Button
    Friend WithEvents FileEncryptor_neSize As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Label6 As Label
    Friend WithEvents Button6 As Button
    Friend WithEvents FileEncryptor_eSize As Label
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents Label5 As Label
    Friend WithEvents Button7 As Button
    Friend WithEvents PWDFileGen_Pass As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Button8 As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents FileEncrypt_Pwd As TextBox
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button11 As Button
End Class
