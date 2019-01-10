using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class TemDetallesOrdenes
    {
        [Key]
        public int DetalleOrdenesId { get; set; }

        public int Duracion { get; set; }

        public double Precio { get; set; }


        public int DetalleTareaId { get; set; }

        public virtual DetalleTarea Detalle { get; set; }

        public int DetalleOrdenPrendaId { get; set; }


        public virtual TemDetallesOrdenPrenda Prenda { get; set; }

    }
}
