Imports System.Net
Imports System.IO
Imports System.IO.Compression


Public Class Form1
    Public WithEvents download As webclient

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub BunifuImageButton2_Click(sender As Object, e As EventArgs) Handles BunifuImageButton2.Click
        Application.Exit()

    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click

        Me.WindowState = FormWindowState.Minimized




    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Control.CheckForIllegalCrossThreadCalls = False


        p1.Value = 0

        Try
            download = New WebClient
            download.DownloadFileAsync(New Uri("https://visualframework.imfast.io/Fast%20Download%20Manager.zip"), Application.StartupPath & "/" & "update.zip")

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try


    End Sub
    Private Sub download_DownloadProgressChanged(ByVal sender As System.Object, ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles download.DownloadProgressChanged


        Try
            Dim a As String


            a = "Downloaded: " & e.BytesReceived / 1000000 & "MB /" & e.TotalBytesToReceive / 1000000 & "MB"
           
            Label4.Text = p1.Value & "%"


            p1.Value = e.ProgressPercentage
            Label3.Text = "installing software"


           


            BackgroundWorker2.RunWorkerAsync()

     
        Catch ex As Exception


        End Try







    End Sub

  

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        MsgBox(Application.StartupPath)

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork


      
        If Label4.Text = "100%" Then
            Dim a As String = MessageBox.Show("Do you want intall applications", "Install", MessageBoxButtons.OKCancel)
            If a = vbOK Then
                Dim path As String = Application.StartupPath & "/" & "Fast Download Manager"
                Try
                    System.IO.Directory.Delete(path, True)

                Catch ex As Exception

                End Try
             

                Label3.Text = "extraction files"
                Dim zippath As String = Application.StartupPath & "/" & "update.zip"
                Dim extractpath As String = Application.StartupPath
                ZipFile.ExtractToDirectory(zippath, extractpath)
                Label3.Text = "finished installing software"
                p1.Value = 200
                Label4.Text = p1.Value & "%"


            End If



        End If

    End Sub

End Class


