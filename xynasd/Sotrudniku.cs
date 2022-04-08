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
    public partial class Form7 : Form
    {
        string id_selected_rows = "0";

        MySqlConnection conn = new MySqlConnection(Base.Twenty());
        public Form7()
        {
            InitializeComponent();
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
            string sql_delete_user = "DELETE FROM Sotrudniki WHERE s_kod='" + s_kodd + "'";
            //Посылаем запрос на обновление данных
            MySqlCommand delete_user = new MySqlCommand(sql_delete_user, conn);
            conn.Open();
            delete_user.ExecuteNonQuery();
            conn.Close();
        }


        public void Table()
        {
            string sql = $"SELECT s_kod AS 'Код', s_fio AS 'ФИО', s_telephone AS 'Телефон', s_email AS 'Почта', s_oklad AS 'Оклад', s_procent AS 'Добавка к зарплате', s_doljnost AS 'Должность'  FROM Sotrudniki";
           
                conn.Open();
                MySqlDataAdapter IDataAdapter = new MySqlDataAdapter(sql, conn);
                DataSet dataset = new DataSet();
                IDataAdapter.Fill(dataset);
                dataGridView1.DataSource = dataset.Tables[0];

            int count_rows = dataGridView1.RowCount - 0;
            label1.Text = (count_rows).ToString();
            for (int i = 0; i < count_rows; i++)
            {
                int kol = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
            }

            conn.Close();

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        public void reload_list()
        {
            Table();
        }


        private void Form7_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = false;
            Table();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteS(id_selected_rows);
            reload_list();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reload_list();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Koll.Text = label1.Text;
            Form8 fffff = new Form8();
            fffff.Show();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
                form9.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 form9 = new Form6();
            form9.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Магические строки
            dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
            dataGridView1.CurrentRow.Selected = true;
            //Метод получения ID выделенной строки в глобальную переменную
            GetSelectedIDString();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
