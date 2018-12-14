using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Tarea
    {
        [Key]
        public int TareaId { get; set; }

        public string NombreTareas { get; set; }

        public string NumeroTarea { get; set; }

        public int PrendaId { get; set; }

        public int ServiciosId { get; set; }


        public string Imagen { get; set; }


        public virtual Prenda Prenda { get; set; }



        public virtual ICollection<DetalleTarea> DetalleTareas { get; set; }

        public virtual ICollection<DetallesOrdenes> DetallesOrdenes { get; set; }

        public virtual Servicios Servicio { get; set; }

    }
}
