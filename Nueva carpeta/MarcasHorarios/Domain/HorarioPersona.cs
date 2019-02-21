using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class HorarioPersona
    {
        [Key]
        public int HorarioPersonaId { get; set; }

        public DateTime Fecha { get; set; }

        public TimeSpan Hora { get; set; }

        public int PropPuerba { get; set; }

        [Display(Name = "Duración (Min)")]
        public int Duracion { get; set; } = 0;

        [DataType(DataType.MultilineText)]
        public string Nota { get; set; }

        public int PersonaId { get; set; }

        public int HorarioRubroId { get; set; }

        public virtual Persona Persona { get; set; }

        public virtual HorarioRubro HorarioRubro { get; set; }
    }
}
