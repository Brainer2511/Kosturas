using Kosturas.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kosturas.InfraExtructura;

namespace Kosturas
{
   public static class Program
    {
        public static string Pin { get; set; }

        public static int Editar { get; set; }
        public static int abrirform { get; set; }
        public static string TotalOrden { get; set; }
        public static string servicio { get; set; }
        
        public static List<string> listados;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
         
        Database.SetInitializer(new MigrateDatabaseToLatestVersion<Model.DataContextLocal, Migrations.Configuration>());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Ayudas.CheckEstadosOrdenes();
            AutoMapperPerfil.Run();
            Application.Run(new MantenimientoProductos());

        }
    }
}
