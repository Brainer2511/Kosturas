using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
 public   class Ordenes
    {
        [Key]
        public int OrdenId { get; set; }

        public string NumeroOrden { get; set; }
        public string FechaIngreso { get; set; }
        public string HoraIngreso { get; set; }
        public string HoraSalida { get; set; }
        public string TotalOrden { get; set; }
        public string CantidadPagada { get; set; }
        public string CantidadRestante { get; set; }
        public string EmpleadoRealizo { get; set; }
        public string NombreCliente { get; set; }
      //  public virtual Cliente ClienteId { get; set; }
    }
}
