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
    public partial class Form5 : Form
    {
        public void gsTovara(ListBox one)
        {
            //Чистим ListBox
            one.Items.Clear();
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = $"SELECT * FROM assortiment";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                //Присваеваем переменным значения в ридере
                // элементы массива [] - это значения столбцов из запроса SELECT
                string id_tovara = reader[0].ToString();
                string Name = reader[1].ToString();
             

                one.Items.Add($"{id_tovara}) {Name}");


            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();

        }
        MySqlConnection conn = new MySqlConnection(Base.Twenty());
        public bool dTovar(string ID_tovara)
        {
            //определяем переменную, хранящую количество вставленных строк
            int InsertCount = 0;
            //Объявляем переменную храняющую результат операции
            bool result = false;
            // открываем соединение
            conn.Open();
            // запрос удаления данных
            string query = $"DELETE FROM assortiment WHERE (id_tovara='{ID_tovara}')";
            try
            {
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(query, conn);
                // выполняем запрос
                InsertCount = command.ExecuteNonQuery();
                // закрываем подключение к БД
            }
            catch
            {
                //Если возникла ошибка, то запрос не вставит ни одной строки
                InsertCount = 0;
            }
            finally
            {
                //Но в любом случае, нужно закрыть соединение
                conn.Close();
                //Ессли количество вставленных строк было не 0, то есть вставлена хотя бы 1 строка
                if (InsertCount != 0)
                {
                    //то результат операции - истина
                    result = true;
                }
            }
            //Вернём результат операции, где его обработает алгоритм
            return result;
        }
        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            string id_del = textBox1.Text;
            if (dTovar(id_del))
            {
               
                gsTovara(listBox1);
            }

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            gsTovara(listBox1);
        }
    }
}
