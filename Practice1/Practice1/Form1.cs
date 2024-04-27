using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (username == "a" && password == "p")
            {
                MessageBox.Show("Ви успішно увійшли до системи!");
                Form2 form2 = new Form2();
                form2.SetConnectionString("YourConnectionString");
                this.Hide();
                form2.FormClosed += (s, args) => this.Close();
                form2.Show();
            }
            else
            {
                MessageBox.Show("Неправильний логін або пароль!");
            }
        }
    }
}
