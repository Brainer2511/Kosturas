using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Sucursal
    {
        [Key]
        public int SucursalId { get; set; }

        public string Nombre { get; set; }

        public bool Activa { get; set; } = true;
    }
}
