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
        cmd = New OleDbCommand("select * from tbsiswa where nis like '%" & TXTCARI.Text & "%'", con)
        baca = cmd.ExecuteReader
        baca.Read()
        If baca.HasRows Then
            tmpl = New OleDbDataAdapter("select * from tbsiswa where nis like '%" & TXTCARI.Text & "%'", con)
            data = New DataSet
            tmpl.Fill(data, "ketemu")
            DataGridView1.DataSource = data.Tables("ketemu")
            DataGridView1.ReadOnly = True
        End If
    End Sub
End Class

