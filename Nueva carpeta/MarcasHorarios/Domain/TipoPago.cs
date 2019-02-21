using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class TipoPago
    {
        [KeyAttribute()]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TipoPagoId { get; set; }

        [Required]
        [Display(Name ="Tipo de Pago")]
        public string Nombre { get; set; }

        public bool Activo { get; set; } = true;
    }
}
