using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Distrito
    {
        [Key]
        [Column(Order = 0)]
        public int numeroDistrito { get; set; }

        [Key]
        [Column(Order = 1)]
        public int numeroCanton { get; set; }

        [Key]
        [Column(Order = 2)]
        public int numeroProvincia { get; set; }

        [Display(Name = "Distrito")]
        public string nombre { get; set; }

        public virtual Canton Canton { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
