using Kosturas.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kosturas
{
   public static class Program
    {
        public static string Pin { get; set; }
        public static int abrirform { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
         
        Database.SetInitializer(new MigrateDatabaseToLatestVersion<Model.DataContextLocal, Migrations.Configuration>());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmOrdenPorDia());

        }
    }
}
