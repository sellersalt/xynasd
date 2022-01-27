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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        MySqlConnection conn = new MySqlConnection(Base.Twenty());
        private void button1_Click(object sender, EventArgs e)
        {
            string p_id = textBox1.Text;
            string p_name = textBox2.Text;
            string p_coun = textBox3.Text;
            string p_tovar = textBox4.Text;
            string p_data = textBox5.Text;
            string p_kol = textBox6.Text;
            string p_summa = textBox7.Text;
            //Формируем запрос на изменение
            string sql_update_current_stud = $"INSERT INTO postavchiki (cod_postavki, p_Name, s_Country, Tovar, data_postuplenia_v_magaz, Kol_vo_tovara, Summa) " +
                                            $"VALUES ('{p_id}', '{p_name}', '{p_coun}', '{p_tovar}', '{p_data}', '{p_kol}', '{p_summa}')";
            //Определяем значение переменных для записи в БД

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

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
