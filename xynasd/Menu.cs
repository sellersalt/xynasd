using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using MySql.Data.MySqlClient;



namespace xynasd
{
    public partial class Menu : Form
    {
        public class CurrencyRate
        {
            /// <summary>
            /// Закодированное строковое обозначение валюты
            /// Например: USD, EUR, AUD и т.д.
            /// </summary>
            public string CurrencyStringCode;

            /// <summary>
            /// Наименование валюты
            /// Например: Доллар, Евро и т.д.
            /// </summary>
            public string CurrencyName;

            /// <summary>
            /// Обменный курс
            /// </summary>
            public double ExchangeRate;
        }

        public class CurrencyRates
        {
            public class ValCurs
            {
                [XmlElementAttribute("Valute")]
                public ValCursValute[] ValuteList;
            }

            public class ValCursValute
            {

                [XmlElementAttribute("CharCode")]
                public string ValuteStringCode;

                [XmlElementAttribute("Name")]
                public string ValuteName;

                [XmlElementAttribute("Value")]
                public string ExchangeRate;
            }

            /// <summary>
            /// Получить список котировок ЦБ ФР на данный момент
            /// </summary>
            /// <returns>список котировок ЦБ РФ</returns>
            public static List<CurrencyRate> GetExchangeRates()
            {
                List<CurrencyRate> result = new List<CurrencyRate>();
                XmlSerializer xs = new XmlSerializer(typeof(ValCurs));
                XmlReader xr = new XmlTextReader(@"http://www.cbr.ru/scripts/XML_daily.asp");
                foreach (ValCursValute valute in ((ValCurs)xs.Deserialize(xr)).ValuteList)
                {
                    result.Add(new CurrencyRate()
                    {
                        CurrencyName = valute.ValuteName,
                        CurrencyStringCode = valute.ValuteStringCode,
                        ExchangeRate = Convert.ToDouble(valute.ExchangeRate)
                    });
                }
                return result;
            }
        }


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
            List<CurrencyRate> tmp = CurrencyRates.GetExchangeRates();
            // Курс доллара
            label2.Text = tmp.FindLast(s => s.CurrencyStringCode == "USD").ExchangeRate.ToString();
            // Курс евро
            label3.Text = tmp.FindLast(s => s.CurrencyStringCode == "EUR").ExchangeRate.ToString();
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


        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
