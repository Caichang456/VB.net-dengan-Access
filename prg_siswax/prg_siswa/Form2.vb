Imports System.Data.OleDb

Public Class Form2
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        tampil()
    End Sub
    Sub tampil()
        tmpl = New OleDbDataAdapter("select * from tbsiswa", con)
        data = New DataSet
        tmpl.Fill(data, "tbsiswa")
        DataGridView1.DataSource = data.Tables("tbsiswa")
    End Sub

    Private Sub TXTCARI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTCARI.TextChanged
        Dim s1, s2 As String
        s1 = "select * from tbsiswa where nama like '%" & TXTCARI.Text & "%'"
        cmd = New OleDbCommand(s1, con)
        baca = cmd.ExecuteReader
        baca.Read()
        If baca.HasRows Then
            s2 = "select * from tbsiswa where nama like '%" & TXTCARI.Text & "%'"
            tmpl = New OleDbDataAdapter(s2, con)
            data = New DataSet
            tmpl.Fill(data, "tbsiswa")
            DataGridView1.DataSource = data.Tables("tbsiswa")
            DataGridView1.ReadOnly = True
        End If

    End Sub
End Class

