using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Nacionalidad
    {
        public int NacionalidadId { get; set; }

        [Display(Name ="Nacionalidad")]
        public string Nombre { get; set; }

        public string Nomenclatura { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
