using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        public string Nombre { get; set; }
        public string Notas { get; set; }
        public string Calle { get; set; }
        public string Email { get; set; }
        public string Ciudad { get; set; }
        public string Codigopostal { get; set; }
        public string TelefonoPrincipal { get; set; }
        public string TelefonoDos { get; set; }
        public string Telefonotres { get; set; }
        public string Abreviatura { get; set; }
        public string TotalOrden{ get; set; }
        public string Fecha { get; set; }
        public string EmpleadoInserta { get; set; }
        public string Visitas { get; set; }
        public string FechaModificacion { get; set; }
        public string Empleadoactualiza { get; set; }
    }
}
