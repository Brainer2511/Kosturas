using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Canton
    {
        [Key]
        [Column(Order =0)]
        public int numeroCanton { get; set; }

        [Key]
        [Column(Order = 1)]
        public int numeroProvincia { get; set; }

        [Display(Name = "Canton")]
        public string nombre { get; set; }

        public virtual Provincia Provincia { get; set; }

        public virtual ICollection<Distrito> Distritos { get; set; }

    }
}
