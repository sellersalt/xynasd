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
    public partial class Form3 : Form
    {
        MySqlConnection conn = new MySqlConnection(Base.Twenty());
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Определяем значение переменных для записи в БД
            string n_id = textBox1.Text;
            string n_name = textBox2.Text;
            string n_vid = textBox3.Text;
            string n_kol = textBox4.Text;
            string n_ostatok = textBox5.Text;
            string n_reit = textBox6.Text;
            //Формируем запрос на изменение
            string sql_update_current_stud = $"INSERT INTO assortiment (id_tovara, Name, Vid_Ceni, Kol_vo, Ostatok, Reiting_Prodaj) " +
                                            $"VALUES ('{n_id}', '{n_name}', '{n_vid}', '{n_kol}', '{n_ostatok}', '{n_reit}')";
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
            
        }
    }
}
