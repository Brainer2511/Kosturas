using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
  public  class Estados
    {
        [KeyAttribute()]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]        
        public int EstadoId { get; set; }

        public string Nombre { get; set; }

        public Color Color { get; set; }



        public virtual ICollection<Ordenes> Ordenes { get; set; }

    }
}
