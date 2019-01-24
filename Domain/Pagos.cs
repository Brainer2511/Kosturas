using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Pagos
    {
        [Key]
        public int PagoId { get; set; }

        public DateTime Fecha { get; set; }

        public double Monto { get; set; } = 0;

        public string EmpleadoRealizo { get; set; } = "";

        public string Puntos { get; set; } = "";

        public int MedioPagoId { get; set; }

        public int OrdenId { get; set; }

        public virtual MediosPago MediosPago { get; set; }

        public virtual Ordenes Ordenes { get; set; }

        

    }
}
