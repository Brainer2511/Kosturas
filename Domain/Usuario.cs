using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        public string Nombre { get; set; }
        public string Clave { get; set; }
        public string Perfil { get; set; }
    }
}
