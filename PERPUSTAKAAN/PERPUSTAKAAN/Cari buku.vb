Public Class Cari_buku

    Private Sub Cari_buku_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Sub awal()
        DataGridView1.DataSource = getData("select * from buku where judul like '%" & TextBox1.Text & "%'")
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).HeaderText = "judul"
        DataGridView1.Columns(2).HeaderText = "penerbit"

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Menu_utama.TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            Menu_utama.idbuku = DataGridView1.Rows(e.RowIndex).Cells(0).Value
            Me.Close()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class
