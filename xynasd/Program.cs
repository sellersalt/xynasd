using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace xynasd
{
   
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
        }
    }
    static class Koll
    {
        public static string Text;
    }



    class Base
    {
        public static string Twenty()
        {
            const string Host = "caseum.ru";
            const int Port = 33333;
            const string Polz = "st_2_20_19";
            const string DB = "st_2_20_19";
            const string Pass = "72279361";

            string connStr = $"server={Host};port={Port};user={Polz};" + $"database={DB};password={Pass};";
            return connStr;


        }
    }
}
