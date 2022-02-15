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
    public partial class Form14 : Form
    {
        MySqlConnection conn = new MySqlConnection(Base.Twenty());
        string id_selected_rows = "0";
        public Form14()
        {
            InitializeComponent();
        }
        public void Table()
        {

            string sql = $"SELECT c_id AS Код, c_fio AS 'ФИО', c_email AS 'Почта', c_comp AS 'Компания', c_date AS 'Дата покупики', с_Tsale AS 'Купленый товар', c_Itog AS 'Сумма' FROM client";
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
        public void reload_list()
        {
            Table();
        }
        
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
            string sql_delete_user = "DELETE FROM client WHERE c_id='" + s_kodd + "'";
            //Посылаем запрос на обновление данных
            MySqlCommand delete_user = new MySqlCommand(sql_delete_user, conn);
            conn.Open();
            delete_user.ExecuteNonQuery();
            conn.Close();
        }
        private void Form14_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = false;
            Table();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Магические строки
            dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
            dataGridView1.CurrentRow.Selected = true;
            //Метод получения ID выделенной строки в глобальную переменную
            GetSelectedIDString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reload_list();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteS(id_selected_rows);
            reload_list();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form18 form18 = new Form18();
            form18.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form19 form19 = new Form19();
            form19.Show();
        }
    }
}
