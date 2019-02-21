using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class CodigoBarras
    {
        [Key]
        public int CodigoId { get; set; }

        public int OrdenId { get; set; }

    

        public string Imagen { get; set; }


        public virtual Ordenes  Ordenes { get; set; }
        

    }
}
