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
    public partial class Form4 : Form
    {
        MySqlConnection conn = new MySqlConnection(Base.Twenty());
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           //Получаем ID товара
            string ID_tovara = textBox4.Text;
            //Получаем новое количество 
            string Kol = textBox1.Text;
            //Получаем новое количество
            string Osta = textBox2.Text;
            //Получаем новоый рейтинг
            string Reit = textBox3.Text;
            // устанавливаем соединение с БД
            conn.Open();
            // запрос обновления данных
            string query2 = $"UPDATE assortiment SET kol_vo = '{Kol}',Ostatok = '{Osta}',Reiting_Prodaj = '{Reit}'  WHERE id_tovara = {ID_tovara}";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(query2, conn);
            // выполняем запрос
            command.ExecuteNonQuery();
            // закрываем подключение к БД
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Объявлем переменную для запроса в БД
            string ID_tovara = textBox4.Text;
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = $"SELECT Kol_vo, Ostatok, Reiting_Prodaj  FROM assortiment WHERE id_tovara={ID_tovara}";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                textBox5.Text = reader[0].ToString();
                textBox6.Text = reader[1].ToString();
                textBox7.Text = reader[2].ToString();
            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
