Public Class Menu_utama
    Public idpustakawan, idbuku
    Dim idanggota
    Dim aksi = False
    Sub awal()
        DataGridView1.DataSource = getData("select * from anggota where namaanggota like '%" & TextBox1.Text & "%'")
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).HeaderText = "Anggota"
        DataGridView1.Columns(2).HeaderText = "Alamat"

        aksi = True
    End Sub
    Sub group1()
        GroupBox1.Enabled = False
        GroupBox2.Enabled = False
        GroupBox3.Enabled = True
        TextBox2.Enabled = False
        TextBox4.Enabled = False
        ComboBox1.Enabled = False
    End Sub
    Sub buka()
        GroupBox1.Enabled = True
        GroupBox2.Enabled = True
        GroupBox3.Enabled = False
        aksi = True
    End Sub
    Sub getcode()
        Dim sql = "select * from status"
        ComboBox1.DataSource = getData(sql)
        ComboBox1.DisplayMember = "status"
        ComboBox1.ValueMember = "idstatus"
    End Sub


    Private Sub Menu_utama_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If aksi = False Then
            Login.Close()
        End If
    End Sub
    Private Sub Menu_utama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        group1()
        getcode()

    End Sub

    Private Sub PustakawanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PustakawanToolStripMenuItem.Click
        pustakawan.ShowDialog()
    End Sub

    Private Sub AnggotaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnggotaToolStripMenuItem.Click
        anggota.ShowDialog()
    End Sub

    Private Sub BukuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BukuToolStripMenuItem.Click
        buku.ShowDialog()
    End Sub

    Private Sub PenegembalianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PenegembalianToolStripMenuItem.Click
        Pengembalian.ShowDialog()
    End Sub
    Private Sub LaporanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanToolStripMenuItem.Click
        Laporan.ShowDialog()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        aksi = True
        Me.Close()
        Login.Show()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            idanggota = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Cari_buku.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql
        If adaKosong(GroupBox2) Or idpustakawan = "0" Then
            MsgBox("Data Masih Kosong")
        Else
            sql = "insert into transaksi values ('" & idpustakawan & "','" & idanggota & "','" & idbuku & "','" & ComboBox1.SelectedValue & "','" & DateTimePicker1.Value.ToString("yyyy/MM/dd") & "','')"
            'MsgBox(sql)
            exc(sql)
            clearForm(GroupBox1)
            MsgBox("Buku Telah Di Pinjam")
            clearForm(GroupBox2)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        clearForm(GroupBox2)
        TextBox1.Clear()
        DataGridView1.DataSource = Nothing
        group1()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        awal()
        buka()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        buka()
        awal()
    End Sub
End Class