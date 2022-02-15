using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace xynasd
{
    public partial class Form9 : Form
    {
        MySqlConnection conn = new MySqlConnection(Base.Twenty());
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Определяем значение переменных для записи в БД
            string s_name = textBox2.Text;
            string s_tele = maskedTextBox1.Text;
            string s_em = textBox4.Text;
            string s_okld = textBox5.Text;
            //Формируем запрос на изменение
            string sql_update_current_stud = $"INSERT INTO Sotrudniki (s_fio, s_telephone, s_email, s_oklad) " +
                                            $"VALUES ('{s_name}', '{s_tele}', '{s_em}', '{s_okld}')";
            // устанавливаем соединение с БД
            conn.Open();
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql_update_current_stud, conn);
            // выполняем запрос
            command.ExecuteNonQuery();
            // закрываем подключение к БД
            conn.Close();
            //Закрываем форму
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
