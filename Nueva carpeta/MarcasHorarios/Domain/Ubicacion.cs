using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Ubicacion
    {
        [Key]
        public int UbicacionId { get; set; }

        [Display(Name ="Ubicación")]
        public string Nombre { get; set; }

        public bool Activa { get; set; } = true;

        public virtual ICollection<Marca> Marcas { get; set; }
    }
}
