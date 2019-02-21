using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCC_Horarios_Y_Marcas
{
    public class Justificacion
    {
        public Int32 idJustificacion { get; set; }
        public Int32 idPersona { set; get; }
        public string fechaJustificacion { set; get; }
        public Int32 Motivo { set; get; }
        public string horaInicio { set; get; }
        public string horaFin { set; get; }
        public string observaciones { set; get; }
        public Int32 idPersonaregistro { set; get; }
    }
}