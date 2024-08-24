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
    public partial class Login : Form
    {
       Modue1 mod = new Modue1();

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM pustakawan WHERE username =  '" + textBox1.Text + "' AND password =  '" + textBox2.Text + "'";

            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Silahkan Isi Data");
            }
            else
            {
                if (mod.getCount(sql) == 0)
                {
                    MessageBox.Show("username atau password salah");
                }
                else
                {
                    Menu_Utama menu_Utama = new Menu_Utama();
                    menu_Utama.ShowDialog();
                   this.Hide();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
