using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Prenda
    {
        [Key]
        public int PrendaId { get; set; }

        public string TipoRopa { get; set; }

        public string piezas { get; set; }

        public string NumeroPrenda { get; set; }

        public string Imagen { get; set; }

        public virtual ICollection<Tarea> Tareas { get; set; }

        public virtual ICollection<TemDetallesOrdenPrenda> Ordenes { get; set; }
    }
}
