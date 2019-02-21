using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Provincia
    {
        [Key]
        public int numeroProvincia { get; set; }

        [Display(Name ="Provincia")]
        public string nombre { get; set; }

        public virtual ICollection<Canton> Cantones { get; set; }

    }
}
