using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCC_Horarios_Y_Marcas
{
    public class Marca
    {
        public string nombre { set; get; }
        public int idMarca { get; set; }
        public string fecha { get; set; }
        public string horaEntrada { get; set; }
        public string horaSalida { get; set; }
        public int ubicacion { get; set; }
    }
}
