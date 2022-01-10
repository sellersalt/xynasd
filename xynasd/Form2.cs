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
    public partial class Form2 : Form
    {
       

    
        public Form2()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 tovar = new Form6();
            tovar.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
      

        private void Form2_Load(object sender, EventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 assortiment = new Form1();
            assortiment.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 Sotrudnik = new Form7();
            Sotrudnik.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form10 Postavshiki = new Form10();
            Postavshiki.ShowDialog();

        }
    }
}
