// Form2.cs

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Practice1
{
    public partial class Form2 : Form
    {
        private string connectionString;

        public Form2()
        {
            InitializeComponent();
        }

        public void SetConnectionString(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadDataFromDatabase();
        }

        private void LoadDataFromDatabase()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM Customers"; // Replace "YourTable" with your actual table name
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable; // Bind data to dataGridView1
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Помилка підключення до бази даних: " + ex.Message);
                }
            }
        }
    }
}
