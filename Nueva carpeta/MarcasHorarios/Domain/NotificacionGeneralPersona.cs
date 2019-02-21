using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    //1. Alerta 2. Success 3.Danger 4.Warning 5.Info
    public class NotificacionGeneralPersona
    {
        [Key]
        public int NotificacionGeneralPersonaId { get; set; }

        public int TipoNotificacion { get; set; }

        public string Titulo { get; set; }

        public string Nota { get; set; }

        public DateTime Fecha { get; set; }

        public int? PersonaId { get; set; }

        public bool Activo { get; set; }

        public bool Institucion { get; set; }

        public virtual Persona Persona { get; set; }

        public virtual ICollection<NotificacionPersona> Personas { get; set; }
    }
}
