using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xynasd
{
    public partial class Form1 : Form
    {
        string id_selected_rows = "0";
        public void GetSelectedIDString()
        {
            //Переменная для индекс выбранной строки в гриде
            string index_selected_rows;
            //Индекс выбранной строки
            index_selected_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
            //ID конкретной записи в Базе данных, на основании индекса строки
            id_selected_rows = dataGridView1.Rows[Convert.ToInt32(index_selected_rows)].Cells[0].Value.ToString();


        }
        public void DeleteS(string s_kodd)
        {
            //Формируем строку запроса на добавление строк
            string sql_delete_user = "DELETE FROM assortiment WHERE id_tovara='" + s_kodd + "'";
            //Посылаем запрос на обновление данных
            MySqlCommand delete_user = new MySqlCommand(sql_delete_user, conn);
            conn.Open();
            delete_user.ExecuteNonQuery();
            conn.Close();
        }


        public void Table()
        {

            string sql = $"SELECT Tovar.t_articul AS Код, Name AS 'Название', Vid_Ceni AS 'Вид цены', Kol_vo AS 'Количество' , Tovar.t_ostatok AS 'Остаток', Reiting_Prodaj AS 'Рейтинг Продаж'  FROM assortiment INNER JOIN Tovar ON assortiment.id_tov = Tovar.id_tov ";
               
               
            try
            {
                conn.Open();
                MySqlDataAdapter IDataAdapter = new MySqlDataAdapter(sql, conn);
                DataSet dataset = new DataSet();
                IDataAdapter.Fill(dataset);
                dataGridView1.DataSource = dataset.Tables[0];

                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch
            {
                MessageBox.Show("Ошибка подключения");
            }
            finally
            {
                conn.Close();
                
            }
        }
       

        MySqlConnection conn = new MySqlConnection(Base.Twenty());

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = false;
            Table();
        }
        public void reload_list()
        {
            Table();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }
      
        private void button3_Click(object sender, EventArgs e)
        {
            reload_list();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteS(id_selected_rows);
            reload_list();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Магические строки
            dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
            dataGridView1.CurrentRow.Selected = true;
            //Метод получения ID выделенной строки в глобальную переменную
            GetSelectedIDString();
        }
    }
}
