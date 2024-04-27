﻿using System;
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
                    string sql = "SELECT TOP (1000) * FROM [SalesLT].[Address]";
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Помилка підключення до бази даних: " + ex.Message);
                }
            }
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            this.addressTableAdapter.Fill(this.dtpv20BDDataSet.Address);

        }
    }   
}
