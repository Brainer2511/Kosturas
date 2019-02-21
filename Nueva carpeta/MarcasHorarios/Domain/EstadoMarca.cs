using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class EstadoMarca
    {
        [Key]
        public int EstadoMarcaId { get; set; }

        [Display(Name ="Estado de Marcas")]
        public string Nombre { get; set; }

        public string Color { get; set; }

        public bool Activa { get; set; } = true;

        public virtual ICollection<Marca> Marcas { get; set; }

        public virtual ICollection<Justificacion> Justificaciones { get; set; }
    }
}
