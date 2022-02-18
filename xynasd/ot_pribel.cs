using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace xynasd
{
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }
        MySqlConnection conn = new MySqlConnection(Base.Twenty());

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        public void postov()
        {
            conn.Open();
            // запрос 
            string sql = $"SELECT COUNT(*) FROM postavchiki";
            // объект для выполнения SQL-запроса 
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера 
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат 
            while (reader.Read())
            {
                ;
                // элементы массива [] - это значения столбцов из запроса SELECT 
                label14.Text = reader[0].ToString();

            }
            reader.Close(); // закрываем reader 
            // закрываем соединение с БД 
            conn.Close();

        }
        public void sotrudnku()
        {
            conn.Open();
            // запрос 
            string sql = $"SELECT COUNT(*) FROM Sotrudniki";
            
            // объект для выполнения SQL-запроса 
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера 
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат 
            while (reader.Read())
            {
                ;
                // элементы массива [] - это значения столбцов из запроса SELECT 
                label12.Text = reader[0].ToString();

            }
            reader.Close(); // закрываем reader 
            // закрываем соединение с БД 
            conn.Close();

        }
        public void CLient()
        {
            conn.Open();
            // запрос 
            string sql = $"SELECT COUNT(*) FROM client";
            
            // объект для выполнения SQL-запроса 
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера 
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат 
            while (reader.Read())
            {
                ;
                // элементы массива [] - это значения столбцов из запроса SELECT 
                label8.Text = reader[0].ToString();

            }
            reader.Close(); // закрываем reader 
            // закрываем соединение с БД 
            conn.Close();

        }

        public void Table()
        {
            conn.Open();
            // запрос 
            string sql = $"SELECT SUM(t_sale), SUM(t_itog), SUM(t_zakupka) FROM Tovar";
            // объект для выполнения SQL-запроса 
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера 
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат 
            while (reader.Read())
            {;
                // элементы массива [] - это значения столбцов из запроса SELECT 
                label2.Text = reader[0].ToString();
                label3.Text = reader[1].ToString();
                label5.Text = reader[2].ToString();

            }
            reader.Close(); // закрываем reader 
            // закрываем соединение с БД 
            conn.Close();
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            Table();
            CLient();
            sotrudnku();
            postov();


        }
    }
}
