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
    public partial class Form10 : Form
    {
        MySqlConnection conn = new MySqlConnection(Base.Twenty());
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
        public Form10()
        {
            InitializeComponent();
        }
        public void DeleteS(string s_kodd)
        {
            //Формируем строку запроса на удаление строки
            string sql_delete_user = "DELETE FROM postavchiki WHERE cod_postavki='" + s_kodd + "'";
            //Посылаем запрос на обновление данных
            MySqlCommand delete_user = new MySqlCommand(sql_delete_user, conn);
            conn.Open();
            delete_user.ExecuteNonQuery();
            conn.Close();
        }
        public void Table()
        {
            string sql = $"SELECT cod_postavki AS Код, p_Name AS 'Поставщик', Tovar AS 'Товар', s_Country AS 'Страна' , data_postuplenia_v_magaz AS 'Дата', Kol_vo_tovara AS 'Количество', summa AS 'Стоимость'  FROM postavchiki";
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

            private void Form10_Load(object sender, EventArgs e)
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
            Form2 Add = new Form2();
            Add.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reload_list();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form12 Upd = new Form12();
            Upd.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteS(id_selected_rows);
            reload_list();
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
