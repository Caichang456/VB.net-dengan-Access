
Imports System.Data.OleDb

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form2.Show()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim s1, s2 As String
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Silahkan data di input")
            TextBox1.Focus()
        Else
            s1 = "select * from tbsiswa where nis='" & TextBox1.Text & "'"
            cmd = New OleDbCommand(s1, con)
            baca = cmd.ExecuteReader
            If baca.Read Then
                MsgBox("data sudah ada")
            Else
                s2 = "insert into tbsiswa values('" & TextBox1.Text & "','" & TextBox2.Text & "')"
                cmd = New OleDbCommand(s2, con)
                cmd.ExecuteNonQuery()
                TextBox1.Text = ""
                TextBox2.Text = ""
                MsgBox("data sudah tersimpan")
            End If
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim ubah, s1, s2 As String
        If Button3.Text = "UBAH" Then
            ubah = InputBox("Input Nis yang akan diubah :")
            s1 = "select * from tbsiswa where nis='" & ubah & "'"
            cmd = New OleDbCommand(s1, con)
            baca = cmd.ExecuteReader
            If baca.Read Then
                TextBox1.Text = baca.Item("nis")
                TextBox2.Text = baca.Item("nama")
                Button3.Text = "UPDATE"
            Else
                MsgBox("data tidak ada")
            End If
        Else
            s2 = "update tbsiswa set nis='" & TextBox1.Text & "',nama='" & TextBox2.Text & "' where nis= '" & TextBox1.Text & "'"
            cmd = New OleDbCommand(s2, con)
            cmd.ExecuteNonQuery()
            TextBox1.Text = ""
            TextBox2.Text = ""
            MsgBox("data sudah berubah")
            Button3.Text = "UBAH"
        End If

    End Sub
End Class
