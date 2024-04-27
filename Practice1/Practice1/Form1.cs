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
            // Get username and password from text boxes
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            // Validate login credentials
            if (username == "a" && password == "p")
            {
                // Login successful
                MessageBox.Show("Ви успішно увійшли до системи!");
                // Open Form2 and pass connection string
                Form2 form2 = new Form2();
                form2.SetConnectionString("YourConnectionString"); // Pass connection string to Form2
                this.Hide(); // Hide Form1
                form2.FormClosed += (s, args) => this.Close(); // Close Form1 when Form2 is closed
                form2.Show();
            }
            else
            {
                // Login failed
                MessageBox.Show("Неправильний логін або пароль!");
            }
        }
    }
}
