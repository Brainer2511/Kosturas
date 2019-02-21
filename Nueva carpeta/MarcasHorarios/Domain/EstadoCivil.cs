using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//1 Soltero, 2 Casado, 3 Divorciado, 4 Union Libre
namespace Domain
{
    public class EstadoCivil
    {
        [KeyAttribute()]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EstadoCivilId { get; set; }

        [Display(Name ="Estado Civil")]
        public string Nombre { get; set; }

        public bool Activa { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
