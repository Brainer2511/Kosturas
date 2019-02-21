using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Templeis
    {
        [KeyAttribute()]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TempleiId { get; set; } = 1;

        public string TempleiSMS { get; set; } = "";
        public string TempleiEmail { get; set; } = "";
        public string DirrecTempleiFactura { get; set; } = "";
        public string DirrecTempleiVenta { get; set; } = "";
        public string DirrecTempleiFacturaMaciva { get; set; } = "";
        public string SubTempleiFactura { get; set; } = "";
        public string SubTempleiVenta { get; set; } = "";
        public string SubTempleiFacturaMaciva { get; set; } = "";

    }
}
