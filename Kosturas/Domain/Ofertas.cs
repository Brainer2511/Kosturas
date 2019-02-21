using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Ofertas
    {
        [Key]
        public int OfertaId { get; set; }

        public string NumeroOferta { get; set; }
        public string Descripcion { get; set; }
        public int DescuentoPorsentaje { get; set; } = 0;
        public string ImporteDescuento { get; set; }
        public bool Habilitar { get; set; } = true;
       
    }
}
