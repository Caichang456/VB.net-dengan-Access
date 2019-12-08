
Imports System.Data.OleDb
Module Module1

    Public con As OleDbConnection
    Public cmd As OleDbCommand
    Public baca As OleDbDataReader
    Public tmpl As OleDbDataAdapter
    Public data As New DataSet

    Public Sub koneksi()
        Dim str = "provider=microsoft.jet.oledb.4.0; data source=dbsiswa.mdb"
        con = New OleDbConnection(str)
        If con.State = ConnectionState.Closed Then

            con.Open()

        End If
    End Sub

End Module
