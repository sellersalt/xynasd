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
   
    public partial class Form6 : Form
    {
        MySqlConnection conn = new MySqlConnection(Base.Twenty());
        public Form6()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Объявлем переменную для запроса в БД
            string s_kod = textBox1.Text;
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = $"SELECT s_fio, s_email FROM Sotrudniki WHERE s_kod={s_kod}";
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

        private void button1_Click(object sender, EventArgs e)
        {
            //Получаем айди сотрудника
            string skod = textBox1.Text;
            //Меняем фио сотруднику
            string sfio = textBox2.Text;
            //Получаем новое количество
            string stel = textBox3.Text;
            //Получаем новоый рейтинг
            string spoch = textBox4.Text;
            //Получаем новоый рейтинг
            string oklad = textBox5.Text;
            
            // устанавливаем соединение с БД
            conn.Open();
            // запрос обновления данных
            string query2 = $"UPDATE Sotrudniki SET s_fio = '{sfio}',s_telephone = '{stel}',s_email = '{spoch}', s_oklad = '{oklad}'  WHERE s_kod = {skod}";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(query2, conn);
            // выполняем запрос
            command.ExecuteNonQuery();
            // закрываем подключение к БД
            conn.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
