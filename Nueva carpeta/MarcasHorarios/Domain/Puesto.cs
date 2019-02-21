using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Puesto
    {
        [Key]
        public int PuestoId { get; set; }

        [Display(Name ="Puesto")]
        public string Nombre { get; set; }

        public bool Activo { get; set; } = true;

        [Display(Name = "Cant.Horas")]
        public int Horas { get; set; } = 9;

        [Display(Name ="Salario Base")]
        public double? SalarioBase { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
