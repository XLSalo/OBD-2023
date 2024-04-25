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
            // Отримайте введені логін та пароль
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Перевірте логін та пароль
            if (username == "admin" && password == "password123")
            {
                // Авторизація успішна
                MessageBox.Show("Ви успішно увійшли до системи!");

                // Зробіть речі, які ви хочете зробити після успішної авторизації
                // ...

                // (За бажанням) Закрийте форму авторизації
                // this.Close();
            }
            else
            {
                // Авторизація не вдалася
                MessageBox.Show("Неправильний логін або пароль!");
            }
        }
    }
}
