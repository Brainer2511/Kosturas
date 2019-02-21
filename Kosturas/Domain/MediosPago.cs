using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class MediosPago
    {

        [Key]
        public int MedioPagoId { get; set; }

        public string FormaPago { get; set; }
        public string CodigosCuentas { get; set; }
        public string VisualizarOrden { get; set; }
        public string  TipoMedio { get; set; }
        public bool AbrirCajon { get; set; } = true;
        public bool IncluirTotal { get; set; } = true;
       
    
    }
}
