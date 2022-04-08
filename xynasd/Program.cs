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
            Application.Run(new Menu());
        }
    }
    static class Koll
    {
        public static string Text;
    }
    class Sale
    {
        public void sell()
        {

        }
    }
    class Base
    {
        public static string Twenty()
        {
            const string Host = "chuc.caseum.ru";
            const int Port = 33333;
            const string Polz = "st_2_19_20";
            const string DB = "is_2_19_st20_KURS";
            const string Pass = "21252198";

            string connStr = $"server={Host};port={Port};user={Polz};" + $"database={DB};password={Pass};";
            return connStr;

        }
    }
}
