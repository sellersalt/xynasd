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
    public partial class Form13 : Form
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
        public void Table()
        {

            string sql = $"SELECT t_articul AS Артикуль, t_name AS 'Наименованте', t_cena AS 'Цена', t_ostatok AS 'Остаток' FROM Tovar";
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
        public Form13()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                //Получаем айди сотрудника
                string pcod = textBox1.Text;
                //Меняем фио сотруднику
                string kol = textBox2.Text;
                
                //Меняем фио сотруднику
                // устанавливаем соединение с БД
                conn.Open();
                // запрос обновления данных
                string query2 = $"UPDATE Tovar SET t_sale = {kol} + t_sale, t_itog = t_itog + {kol}, t_ostatok = t_ostatok - {kol},t_itog = t_cena * {kol} + t_itog WHERE t_articul = {pcod}";
                
                MySqlCommand command = new MySqlCommand(query2, conn);
                // выполняем запрос
                command.ExecuteNonQuery();
                
                // закрываем подключение к БД
                conn.Close();
                reload_list();
            
            
            try
            {
                //Получаем айди сотрудника
                string fio = textBox3.Text;
                //Меняем фио сотруднику
                string comp = textBox4.Text;

                string email = textBox5.Text;

                string cData = maskedTextBox1.Text;
                
                // устанавливаем соединение с БД
                conn.Open();
                // запрос обновления данных
                string query4 = $"INSERT INTO client (c_fio, c_comp, c_email, c_date) " +
                                            $"VALUES ('{fio}', '{comp}', '{email}', '{cData}')";

                MySqlCommand command3 = new MySqlCommand(query4, conn);
                // выполняем запрос
                command3.ExecuteNonQuery();
                // закрываем подключение к БД
                conn.Close();
                reload_list();

                MessageBox.Show("Покупка совершена \n" + textBox3.Text);
            }
            catch
            {

            }

        }

        private void Form13_Load(object sender, EventArgs e)
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
    }
}
