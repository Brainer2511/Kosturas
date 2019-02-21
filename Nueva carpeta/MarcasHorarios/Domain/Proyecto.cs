using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Proyecto
    {
        [Key]
        public int ProyectoId { get; set; }

        [Display(Name="Proyecto")]
        public string Nombre { get; set; }

        [Display(Name ="Código")]
        public string Codigo { get; set; }

        [Display(Name ="Descripción")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        public bool Activo { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Today;
    }
}
