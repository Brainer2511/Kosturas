using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class RazonSocial
    {
        public int RazonSocialId { get; set; }

        [Display(Name ="Rázon Social")]
        public string Nombre { get; set; }

        [Display(Name="Código")]
        public string Codigo { get; set; }

        public bool Activo { get; set; } = true;

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
