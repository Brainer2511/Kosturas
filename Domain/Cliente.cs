using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        public string Nombre { get; set; } = "";
        public string Email { get; set; } = "";
        public string Direcion { get; set; } = "";
        public string Cedula { get; set; } = "";
        public string TelefonoPrincipal { get; set; } = "";
        public string TelefonoDos { get; set; } = "";
        public string Abreviatura { get; set; } = "";
        public string Fecha { get; set; } = "";
        public string EmpleadoInserta { get; set; } = "";
        public string Visitas { get; set; } = "";
        public string FechaModificacion { get; set; } = "";
        public string Empleadoactualiza { get; set; } = "";


        public int? numeroDistrito { get; set; }
        public int? numeroCanton { get; set; }
        public int? numeroProvincia { get; set; }


        public virtual Distrito Distrito { get; set; }

        public virtual ICollection<Ordenes> Ordenes { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
