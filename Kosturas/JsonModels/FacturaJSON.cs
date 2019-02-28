using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosturas.JsonModels
{
   public class FacturaJSON
    {
        public int user_id { get; set; }
        public Factura factura { get; set; }
        public List<Detalle> detalles { get; set; }
    }
}
