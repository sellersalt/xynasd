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
    public partial class Form18 : Form
    {
        MySqlConnection conn = new MySqlConnection(Base.Twenty());
        public Form18()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Определяем значение переменных для записи в БД
            
            string fio = textBox2.Text;
            string email = textBox3.Text;
            string comp = textBox4.Text;
            
            
            //Формируем запрос на изменение
            string sql_update_current_stud = $"INSERT INTO client (c_fio, c_email, c_comp)" +
                                            $"VALUES ('{fio}', '{email}', '{comp}')";
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

        private void Form18_Load(object sender, EventArgs e)
        {

        }
    }
}
