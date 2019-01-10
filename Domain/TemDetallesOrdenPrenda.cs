using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class TemDetallesOrdenPrenda
    {
        [Key]
        public int DetalleOrdenPrendaId { get; set; }

        public int Cantidad { get; set; }


        public int PrendaId { get; set; }

        public virtual Prenda Prenda { get; set; }

        public virtual ICollection<TemDetallesOrdenes> DetalleTareas  { get; set; }

        public int OrdenId { get; set; }


        public virtual Ordenes Orden { get; set; }
    }
}
