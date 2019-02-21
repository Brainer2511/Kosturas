using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Ventas
    {
        [Key]
        public int VentaId { get; set; }

     
        public DateTime FeEnt { get; set; }
        public double TotalOrden { get; set; } = 0;
        public double CantidadPagada { get; set; } = 0;
        public double CantidadRestante { get; set; } = 0;
        public string EmpleadoRealizo { get; set; } = "";
        public int? ClienteId { get; set; }
        public int? ProductoId { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }


        public virtual Cliente Cliente { get; set; }

    }
}
