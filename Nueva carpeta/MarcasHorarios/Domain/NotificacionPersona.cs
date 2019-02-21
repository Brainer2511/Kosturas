using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class NotificacionPersona
    {
        [Key]
        public int NotificacionPersonaId { get; set; }

        public int? NotificacionGeneralPersonaId { get; set; }

        public int PersonaId { get; set; }

        public DateTime Fecha { get; set; }

        public string Titulo { get; set; }

        public string Nota { get; set; }

        public bool Activo { get; set; }

        public virtual NotificacionGeneralPersona NotificacionGeneral { get; set; }

        public virtual Persona Persona { get; set; }
    }
}
