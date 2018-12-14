using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Afiliado
    {
        [Key]
        public int AfiliadoId { get; set; }

        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string CodigoPostal { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public string Porsentaje { get; set; }
        public bool Activo { get; set; } = true;
        public string NumeroOrden { get; set; } 
        public string Correo { get; set; }
     

    }
}
