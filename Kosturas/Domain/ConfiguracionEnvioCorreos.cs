using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
  public  class ConfiguracionEnvioCorreos
    {
        [KeyAttribute()]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ConfiguracionId { get; set; } = 1;

        public string NombreEmpresa { get; set; } = "";
        public string Emcabezado { get; set; } = "";
        public string Dirrecion { get; set; } = "";
        public string Horario { get; set; } = "";
        public string PiePagina { get; set; } = "";
        public string DirrecionLinea1 { get; set; } = "";
        public string DirrecionLinea2 { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string PaginaWeb { get; set; } = "";
        public string NumeroEmpresa { get; set; } = "";
        public double MontoInicialCaja { get; set; } = 0;
        public double CantidadDineroPorHora { get; set; } = 0;
        public string STPMinutos { get; set; } = "";
        public string CorreoEmpresa { get; set; } = "";
        public string SMSEmpresa { get; set; } = "";
        public bool ActivoCorreo { get; set; } = true;
        public bool ActivoSMS { get; set; } = true;

    }
}
