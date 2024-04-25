using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

// test00

namespace Practice1
{
    internal static class Program
    {
        private static string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");

        private static void Log(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now} : {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }

        [STAThread]
        static void Main()
        {
            Log("Запуск додатку");

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("MyConnectionString");

            Log("Отримано рядок підключення до бази даних");

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    Log("Спроба відкрити з'єднання з базою даних");
                    connection.Open();
                    Log("З'єднання успішно відкрито");
                    MessageBox.Show("Соединение успешно установлено!");
                }
                catch (SqlException ex)
                {
                    Log($"Помилка з'єднання: {ex.Message}");
                    MessageBox.Show("Ошибка подключения: " + ex.Message);
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Log("Запуск головного вікна");
            Application.Run(new Form1());

            Log("Завершення роботи додатку");
        }
    }
}