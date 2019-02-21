using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCC_Horarios_Y_Marcas
{
    public class Usuario
    {
        public int idUsuario { get; set; }

        public int idPersona { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string nombre { get; set; }

        public Sesion sesion { get; set; }

        public bool estado { get; set; }

        public Int16 departamento { get; set; }

        public Int16 seccion { get; set; }

        public string NomDepartamento { get; set; }

        public string NomSeccion { get; set; }

        public Int32 proyecto { get; set; }

        public string ConfirmPass { get; set; }
    }
}