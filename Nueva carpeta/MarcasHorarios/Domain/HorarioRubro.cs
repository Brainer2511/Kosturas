using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class HorarioRubro
    {
        [Key]
        public int HorarioRubroId { get; set; }

        [Display(Name ="Rubro Horario")]
        public string Nombre { get; set; }

        public bool Activo { get; set; } = true;

        public virtual ICollection<HorarioPersona> Horarios { get; set; }
    }
}
