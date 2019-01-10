using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class DetalleTarea
    {
        [Key]
        public int DetalleTareaId { get; set; }

        public int TareaId { get; set; }

        public string DetalleTareas { get; set; }

        public string NumeroDetalleTarea { get; set; }

        public double Precio { get; set; } = 0;

        public string TiempoRespuesta { get; set; }

        public string Imagen { get; set; }

        public virtual Tarea Tarea { get; set; }
    }
}
