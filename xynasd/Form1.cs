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
        
        public void Table()
        {
            string sql = $"SELECT id_tovara AS Код, Name AS 'Название', Vid_Ceni AS 'Вид цены', Kol_vo AS 'Количество' , Ostatok AS 'Остаток', Reiting_Prodaj AS 'Рейтинг Продаж'  FROM assortiment";
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
       

        MySqlConnection conn = new MySqlConnection(Base.Twenty());

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Table();
        }
        public void reload_list()
        {
           
            Table();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form3 Add = new Form3();
            Add.Show();
        }
      
        private void button3_Click(object sender, EventArgs e)
        {
            reload_list();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 Ue = new Form4();
            Ue.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 De = new Form5();
            De.Show();
        }
    }
}
