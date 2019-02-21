using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Provedor
    {
        [Key]
        public int ProvedorId { get; set; }
        public int?  idServicio { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public double MontoIngreso { get; set; } = 0;
        public double MontoPago { get; set; } = 0;
    }
}
