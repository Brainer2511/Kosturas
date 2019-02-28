using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosturas.JsonModels
{
   public class Factura
    {
        public string condicion_venta { get; set; }
        public string medio_pago { get; set; }
        public string plazo_credito { get; set; }
        public string moneda { get; set; }
        public decimal tipo_cambio { get; set; }
        public string receptor_nombre { get; set; }
        public string receptor_tipo_identificacion { get; set; }
        public string receptor_numero_identificacion { get; set; }
        public int receptor_codigo_telefono { get; set; }
        public int receptor_provincia { get; set; }
        public int receptor_canton { get; set; }
        public int receptor_distrito { get; set; }
        public string receptor_otras_senas { get; set; }
        public int receptor_telefono { get; set; }
        public string receptor_email { get; set; }
    }




}
