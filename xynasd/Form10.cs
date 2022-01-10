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
        public Form10()
        {
            InitializeComponent();
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
            Table();
        }
    }
}
