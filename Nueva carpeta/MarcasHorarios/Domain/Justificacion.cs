using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Justificacion
    {
        [Key]
        public int JustificacionId { get; set; }

        public int? EstadoMarcaId { get; set; }

        public int? SupervisorId { get; set; }

        public int? SubordinadoId { get; set; }

        public int? PlanillaId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaSupervisor { get; set; }

        public DateTime? FechaPlanilla { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name ="Observación 1")]
        public string Observacion1 { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Observación 2")]
        public string Observacion2 { get; set; }

        public virtual EstadoMarca EstadoMarca { get; set; }

        public virtual Persona Supervisor { get; set; }

        public virtual Persona Subordinado { get; set; }

        public virtual Persona Planilla { get; set; }
    }
}
