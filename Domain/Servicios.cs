using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Servicios
    {
        [Key]
        public int ServiciosId { get; set; }

        public string VisualizarServicio { get; set; }
        public string NombreServicio { get; set; }
        public string Prefijo { get; set; }
        public string Impuesto { get; set; }
        public string Descuentos { get; set; }
        public string Afiliado { get; set; }
        public bool Alerta { get; set; } = true;
        public bool Habilitar { get; set; } = true;
        public bool ImprimirEtiqueta { get; set; } = true;
        public string Imagen { get; set; }


        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
