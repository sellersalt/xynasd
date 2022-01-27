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
    public partial class Menu : Form
    {

        
    
        public Menu()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form11 tovar = new Form11();
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

        private void button5_Click(object sender, EventArgs e)
        {
            Form14 Client = new Form14();
            Client.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
           
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form16 Prodajam = new Form16();
            Prodajam.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form17 Pribil = new Form17();
            Pribil.ShowDialog();
        }
    }
}
