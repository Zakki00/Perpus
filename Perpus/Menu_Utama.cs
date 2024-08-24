using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perpus
{
    public partial class Menu_Utama : Form
    {

        public Menu_Utama()
        {
            InitializeComponent();
        }

        Modue1 md = new Modue1();


        private void Menu_Utama_Load(object sender, EventArgs e)
        {
            awal();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "INSERT* FROM perpustakaan VALUES ()";
        }

        void awal()
        {  
            string sql = "SELECT * FROM anggota";
            dataGridView1.DataSource = md.getData(sql);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Nama Anggota";
        }

        private void pustakawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void anggotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Anggota anggota = new Anggota();
            ShowDialog(anggota);
        }

        private void masterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
