using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int Prioridad { get; set; }

        public double Precio { get; set; }

         [NotMapped] 
        public double Subtotal { get { return Descuento==0?   Precio * Prenda.Cantidad: (Precio * Prenda.Cantidad)- (double)((decimal)(Precio * Prenda.Cantidad)*((decimal)Descuento/(decimal)100)); } }

        public double Descuento { get; set; }

        public bool Estado { get; set; } = false;

        public string EmpleadoActualizo { get; set; } = "";

        public int DetalleTareaId { get; set; }

        public int? AfiliadoId { get; set; }

        // [NotMapped] 
        public virtual  DetalleTarea Detalle { get; set; }

        public int DetalleOrdenPrendaId { get; set; }

      //  [NotMapped]
        public virtual TemDetallesOrdenPrenda Prenda { get; set; }

        

     

    }
}
