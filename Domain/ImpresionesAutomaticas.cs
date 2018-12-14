using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
  public  class ImpresionesAutomaticas
    {
        [Key]
        public int ImpresionesId { get; set; }

        public string NumeroImprecion { get; set; }
        public string TipoImpresion { get; set; }
        public bool Precio { get; set; }
        public bool CodigoBarras { get; set; }
        public string Servicio { get; set; }
       
    }
}
