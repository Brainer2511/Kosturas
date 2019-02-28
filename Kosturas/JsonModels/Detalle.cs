using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosturas.JsonModels
{
   public class Detalle
    {
        public string codigo { get; set; }
        public decimal cantidad { get; set; }
        public decimal precio_unitario { get; set; }
        public string unidad_medida_codigo { get; set; }
        public string detalle { get; set; }
        public decimal? monto_descuento { get; set; }
        public string naturaleza_descuento { get; set; }
        public string impuesto_codigo { get; set; }
        public decimal? impuesto_tarifa { get; set; }
        public decimal? tipo_documento_exoneracion { get; set; }
        public string num_documento_exoneracion { get; set; }
        public string nombre_institucion_emite_exoneracion { get; set; }
        public DateTime? fecha_emision_exoneracion { get; set; }
        public decimal? monto_impuesto_exonerado { get; set; }
        public int? porcentaje_compra_exoneracion { get; set; }
        public int? impuesto_incluido { get; set; }
    }

   

}
