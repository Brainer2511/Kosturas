using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
  public class Productos
    {

        [Key]
        public int ProductoId { get; set; }

        public int? CodigoId { get; set; }

        public string Nombre { get; set; } = "";
        public string Categoria { get; set; } = "";
        public string Provedor { get; set; } = "";
        public double PrecioCompra { get; set; } = 0;
        public double PrecioVenta { get; set; } = 0;
        public double Cantidad { get; set; } = 0;
        public string Imagen { get; set; }

        public virtual Ventas  Ventas { get; set; }
    }
}
