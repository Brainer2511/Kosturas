using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class OpcionesOrdenes
    {
        [Key]
        public int OpcionesOrdenesId { get; set; }

        public string NumeroOpcion { get; set; }
        public string NombreOpcion { get; set; }
        public string TipoOpcion { get; set; }
        public string Precio { get; set; }
      
    }
}
