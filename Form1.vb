Imports System.Net
Public Class Form1
    
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim s As String = txtUrl.Text.ToLower()
        txtUrl.Text = doCheck(s)
        Dim req As HttpWebRequest = HttpWebRequest.Create(txtUrl.Text)
        Dim resp As HttpWebResponse
        Try
            resp = DirectCast(req.GetResponse(), HttpWebResponse)
            MsgBox(txtUrl.Text & " = " & resp.StatusCode & " " & resp.StatusDescription)
            If MsgBoxResult.Ok Then
                txtUrl.Clear()
            End If
        Catch ex As WebException
            resp = DirectCast(ex.Response, HttpWebResponse)
            Dim A = MsgBox(ex.Message.ToString)
            If A = MsgBoxResult.Ok Then
                txtUrl.Clear()
            Else
                txtUrl.Clear()
            End If
        End Try

        
    End Sub
    Private Function doCheck(ByVal s As String)
        If (s.StartsWith("http://") Or s.StartsWith("https://")) Then
            Return s
        Else
            If (s.StartsWith("www.")) Then
                s = "http://www." & s.Substring(4, s.Count() - 4)
                txtUrl.Text = s
                Return s
            Else
                s = "http://www." & s
                txtUrl.Text = s
                Return s
            End If
        End If
    End Function
    

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtUrl.Select()
    End Sub
End Class