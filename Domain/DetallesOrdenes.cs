using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class DetallesOrdenes
    {
        [Key]
        public int DetalleOrdenesId { get; set; }

        public string TipoRopa { get; set; }

        public string piezas { get; set; }

        public string NumeroPrenda { get; set; }

        public int TareaId { get; set; }

        public virtual Tarea Tarea { get; set; }


    }
}
