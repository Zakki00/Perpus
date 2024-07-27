Public Class anggota
    Dim id = "0"
    Dim aksi = False

    'untuk menampilkan data dan tampilan awal
    Sub awal()
        DataGridView1.DataSource = getData("select * from anggota where namaanggota like '%" & TextBox3.Text & "%'")
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).HeaderText = "anggota"
        DataGridView1.Columns(2).HeaderText = "alamat"
        clearForm(GroupBox2)
        aksi = False


    End Sub
    Sub tutup()
        GroupBox1.Enabled = True
        GroupBox2.Enabled = False
        GroupBox3.Enabled = True
    End Sub
    Sub buka()
        GroupBox1.Enabled = True
        GroupBox2.Enabled = True
        GroupBox3.Enabled = True
    End Sub
    'untuk membuka tampilan awal

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        awal()
    End Sub

    Private Sub anggota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
        tutup()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        awal()
        clearForm(GroupBox2)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If id = "0" Then
            MsgBox("Pilih data dulu")
        Else
            aksi = True
            buka()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If adaKosong(GroupBox2) Then
            MsgBox("Ada data kosong")
        Else
            Dim sql
            If Not aksi Then
                sql = "insert into anggota values('" & TextBox1.Text & "','" & TextBox2.Text & "')"
                'MsgBox(sql)
                exc(sql)
                MsgBox("Data berhasil ditambah")
                awal()

            Else
                sql = "update anggota set namaanggota = '" & TextBox1.Text & "', alamat = '" & TextBox2.Text & "' where idanggota = " & id
                'MsgBox(sql)
                exc(sql)
                MsgBox("Data berhasil diubah")
                awal()

            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If id = "0" Then
            MsgBox("Pilih data dulu")
        Else
            If dialog("Apakah anda yakin ingin menghapus?") Then
                Dim sql = "delete from anggota where idanggota ='" & id & "'"
                'MsgBox(sql)
                exc(sql)
                clearForm(GroupBox2)
                awal()

            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
            id = DataGridView1.Rows(e.RowIndex).Cells(0).Value
            'MsgBox(id)
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        awal()
        tutup()
    End Sub

End Class