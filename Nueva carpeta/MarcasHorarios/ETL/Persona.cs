using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCC_Horarios_Y_Marcas
{
    public class Persona
    {
        public int idPersona { get; set; }

        public string nombre { get; set; }

        public int departamento { get; set; }

        public string DesDpto { get; set; }

        public int seccion { get; set; }

        public string DesSeccion { get; set; }

        public int idMarcaZapote { get; set; }

        public int idMarcaSanPedro { get; set; }

        public int estado { get; set; }

        public int LoginId { get; set; }

        public string correo { get; set; }

        public int codProyecto { get; set; }

        public string proyecto { get; set; }

        public Int32 encargado { get; set; }
    }
}
