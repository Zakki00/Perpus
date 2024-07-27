Imports System.Data.SqlClient
Imports System.Net.Mail
Imports excel = Microsoft.Office.Interop.Excel
Module Module1

    Public conn As SqlConnection 'objek yang digunakan untuk membuka koneksi database
    Public da As SqlDataAdapter  'objek yang digunakan untuk mengisi dan memperbarui database
    Public dr As SqlDataReader   'objek untuk membaca data dari database baris demi baris
    Public dt As DataTable       'objek dalam framework yang memungkinkan membuat dan memanipulasi struktur table
    Public cmd As SqlCommand     'objek untuk menjalankan perintah sql
    Sub koneksi() 'untuk koneksi data base
        conn = New SqlConnection("Data Source=MSI\SQLEXPRESS;Initial Catalog=perpustakaan;Integrated Security=True")
        If conn.State = conn.State.Closed Then
            conn.Open()
        End If
    End Sub
    'untuk menutup koneksi data base
    Sub closeKoneksi()
        conn.Close()
        cmd.Dispose()
    End Sub
    'untuk menampilkan jumlah data
    Function getData(s As String)
        koneksi()
        Try
            cmd = New SqlCommand(s, conn)
            da = New SqlDataAdapter
            dt = New DataTable
            da.SelectCommand = cmd
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            closeKoneksi()
        End Try
    End Function
    'untuk menampilkan tabel data base
    Function getCount(s As String)
        koneksi()
        Try
            cmd = New SqlCommand(s, conn)
            da = New SqlDataAdapter
            dt = New DataTable
            da.SelectCommand = cmd
            da.Fill(dt)
            Return dt.Rows.Count
        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        Finally
            closeKoneksi()
        End Try
    End Function
    'mengambil data dari data base berdasarkan nama kolum
    Function getValue(s As String, col As String)
        koneksi()
        Try
            cmd = New SqlCommand(s, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                If IsDBNull(dr.Item(col)) Then
                    Return ""
                Else
                    Return dr.Item(col)
                End If
            Else
                Return ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return ""
        Finally
            closeKoneksi()
        End Try
    End Function

    Function exc(s As String)
        koneksi()
        Try
            cmd = New SqlCommand(s, conn)
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            closeKoneksi()
        End Try
    End Function

    Function isEmail(s As String)
        Try
            Dim a = New MailAddress(s)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function adaKosong(gb As GroupBox)
        Dim status = False
        For Each ct As Control In gb.Controls
            If TypeOf ct Is TextBox Then
                If CType(ct, TextBox).Text = "" Then
                    status = True
                    Exit For
                End If
            End If
            If TypeOf ct Is PictureBox Then
                If CType(ct, PictureBox).ImageLocation = Nothing Then
                    status = True
                    Exit For
                End If
            End If
        Next
        Return status
    End Function

    Function clearForm(gb As GroupBox)
        For Each ct As Control In gb.Controls
            If TypeOf ct Is TextBox Then
                CType(ct, TextBox).Text = ""
            End If
            If TypeOf ct Is PictureBox Then
                CType(ct, PictureBox).ImageLocation = Nothing
            End If
            If TypeOf ct Is NumericUpDown Then
                CType(ct, NumericUpDown).Value = 0
            End If

        Next


    End Function

    Function onlyNumber(e As KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Function

    Function dialog(s As String)
        Dim a As DialogResult = MessageBox.Show(s, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If a = DialogResult.Yes Then
            Return True
        End If
    End Function
    Function relaseobject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Function


End Module
