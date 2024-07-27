Public Class Laporan
    Dim id
    Sub awal()
        DataGridView1.DataSource = getData("select namapustakawan, username, namaanggota, judul, status, tanggalpeminjaman, tanggalpengembalian from Perpustakaan where namaanggota like '%" & TextBox1.Text & "%' and tanggalpeminjaman = '" & DateTimePicker1.Value & "'")
        DataGridView1.Columns(0).HeaderText = "Pustakawan"
        DataGridView1.Columns(1).HeaderText = "User Name"
        DataGridView1.Columns(2).HeaderText = "Nama Anggota"
        DataGridView1.Columns(3).HeaderText = "Judul"
        DataGridView1.Columns(4).HeaderText = "Status"
        DataGridView1.Columns(5).HeaderText = "Tanggal Peminjaman"
        DataGridView1.Columns(6).HeaderText = "Tanggal Pengembalian"

    End Sub


    Private Sub Laporan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        awal()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SaveFileDialog1.Filter = "Excel Files (.xlsx)|.xlsx"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim xlaapp As Microsoft.Office.Interop.Excel.Application
            Dim xlworkbook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlworksheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim misvalue As Object = System.Reflection.Missing.Value
            Dim i As Integer
            Dim j As Integer

            xlaapp = New Microsoft.Office.Interop.Excel.Application
            xlworkbook = xlaapp.Workbooks.Add(misvalue)
            xlworksheet = xlworkbook.Sheets(1)

            For i = 0 To DataGridView1.RowCount - 2
                For j = 0 To DataGridView1.ColumnCount - 1
                    For k As Integer = 1 To DataGridView1.Columns.Count
                        xlworksheet.Cells(1, k) = DataGridView1.Columns(k - 1).HeaderText
                        xlworksheet.Cells(i + 2, j + 1) = DataGridView1(j, i).Value.ToString
                    Next
                Next
            Next

            xlworksheet.SaveAs(SaveFileDialog1.FileName)
            xlworkbook.Close()
            xlaapp.Quit()

            relaseobject(xlaapp)
            relaseobject(xlworkbook)
            relaseobject(xlworksheet)

            MsgBox("Ekspor Berhasil")

        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        awal()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class