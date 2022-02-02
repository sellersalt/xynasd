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
    public partial class Form16 : Form
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
        public Form16()
        {
            InitializeComponent();
        }
        public void Table()
        {

            string sql = $"SELECT os_id AS id , os_name AS 'Название', os_sale AS 'Продано', os_ostatok AS 'Остаток', os_zakupka AS 'Закупка', os_pribel AS 'Прибыль'  FROM ot_sale";
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
        private void Form16_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            //Получаем айди сотрудника
            string pcod = textBox2.Text;
            //Меняем фио сотруднику
            string sale = textBox1.Text;
            //Меняем фио сотруднику
            // устанавливаем соединение с БД
            conn.Open();
            // запрос обновления данных
            string query2 = $"UPDATE ot_sale SET os_sale = os_sale + {sale}, os_ostatok = os_ostatok - {sale} WHERE os_id = {pcod}";

            MySqlCommand command = new MySqlCommand(query2, conn);
            // выполняем запрос
            command.ExecuteNonQuery();
            // закрываем подключение к БД
            conn.Close();
            reload_list();

        }
    }
   
}
