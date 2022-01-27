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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }
        MySqlConnection conn = new MySqlConnection(Base.Twenty());
        private void button1_Click(object sender, EventArgs e)
        {

            //Объявлем переменную для запроса в БД
            string p_kod = textBox1.Text;
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = $"SELECT p_Name, s_Country FROM postavchiki WHERE cod_postavki={p_kod}";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                textBox7.Text = reader[0].ToString();
                textBox6.Text = reader[1].ToString();

            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Получаем айди сотрудника
            string pcod = textBox1.Text;
            //Меняем фио сотруднику
            string pcon = textBox2.Text;
            //Получаем новое количество
            string ptov = textBox3.Text;
            //Получаем новоый рейтинг
            string pkol = textBox4.Text;
            //Получаем новоый рейтинг
            string psum = textBox5.Text;

            // устанавливаем соединение с БД
            conn.Open();
            // запрос обновления данных
            string query2 = $"UPDATE postavchiki SET s_Country= '{pcon}',Tovar = '{ptov}',Kol_vo_tovara = '{pkol}', Summa = '{psum}'  WHERE cod_postavki = {pcod}";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(query2, conn);
            // выполняем запрос
            command.ExecuteNonQuery();
            // закрываем подключение к БД
            conn.Close();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
