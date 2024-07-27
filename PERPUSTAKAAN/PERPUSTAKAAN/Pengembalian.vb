Public Class Pengembalian

    Dim id
    Sub awal()
        Dim sql = "select * from Perpustakaan where namaanggota like '%" & TextBox1.Text & "%' and status = '" & ComboBox2.Text & "'"
        DataGridView1.DataSource = getData(sql)
        DataGridView1.Columns(1).Visible = False
        DataGridView1.Columns(2).Visible = False
        DataGridView1.Columns(3).Visible = False
        DataGridView1.Columns(4).Visible = False
        DataGridView1.Columns(11).Visible = False
        DataGridView1.Columns(12).Visible = False
        DataGridView1.Columns(13).Visible = False
        TextBox2.Enabled = False
        TextBox4.Enabled = False
    End Sub

    Sub getcode()
        Dim sql = "select * from status"
        ComboBox1.DataSource = getData(sql)
        ComboBox1.DisplayMember = "status"
        ComboBox1.ValueMember = "idstatus"
    End Sub
    Sub getcode2()
        Dim sql = "select * from status"
        ComboBox2.DataSource = getData(sql)
        ComboBox2.DisplayMember = "status"
        ComboBox2.ValueMember = "idstatus"
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
            TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value
            id = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        End If
    End Sub

    Private Sub Pengembalian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
        getcode()
        getcode2()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If id = "0" Then
            MsgBox("pilih Data Dulu")
        Else
            Dim Sql = "update transaksi set idstatus = '" & ComboBox1.SelectedValue & "', tanggalpengembalian = '" & DateTimePicker1.Value.ToString("yyyy/MM/dd") & "' where idpeminjaman = " & id
            'MsgBox(Sql)
            exc(Sql)
            MsgBox("Buku Berhasil Dikembalikan")
            clearForm(GroupBox1)
            awal()


        End If
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        awal()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        awal()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        clearForm(GroupBox2)
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Dim sql As String = "SELECT * FROM Perpustakaan WHERE idpeminjaman = '" & TextBox3.Text & "'"

        TextBox2.Text = getValue(sql, "namaanggota")
        TextBox4.Text = getValue(sql, "judul")
        id = getValue(sql, "idpeminjaman")
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class