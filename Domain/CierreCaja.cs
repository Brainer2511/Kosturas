using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class CierreCaja
    {
        [Key]
        public int CierreId { get; set; }

        public double MontoInicial { get; set; } = 0;
        public DateTime FechaApertura { get; set; }
        public DateTime FechaCierre { get; set; }
        public double TotalDiferencia { get; set; } = 0;
        public string EmpleadoCerro { get; set; } = "";
        public string Notas { get; set; } = "";

        public string CantidadMonedas5 { get; set; } = "0";
        public string CantidadMonedas10 { get; set; } = "0";
        public string CantidadMonedas25 { get; set; } = "0";
        public string CantidadMonedas50 { get; set; } = "0";
        public string CantidadMonedas100 { get; set; } = "0";
        public string CantidadMonedas500 { get; set; } = "0";

        public string CantidadBilletes1000 { get; set; } = "0";
        public string CantidadBilletes2000 { get; set; } = "0";
        public string CantidadBilletes5000 { get; set; } = "0";
        public string CantidadBilletes10000 { get; set; } = "0";
        public string CantidadBilletes20000 { get; set; } = "0";
        public string CantidadBilletes50000 { get; set; } = "0";


        public string CantidadActualEfectivo { get; set; } = "0";
        public string CantidadIngresoEfectivo { get; set; } = "0";
        public string DiferenciaEfectivo { get; set; } = "0";
        public string CantidadActualTarjetas { get; set; } = "0";
        public string CantidadIngresoTarjetas { get; set; } = "0";
        public string DiferenciaTarjetas { get; set; } = "0";
        public string CantidadActualCheques { get; set; } = "0";
        public string CantidadIngresoCheques { get; set; } = "0";
        public string DiferenciaCheques { get; set; } = "0";
        public string CantidadActualTransferencia { get; set; } = "0";
        public string CantidadIngresoTransferencia { get; set; } = "0";
        public string DiferenciaTransferencia { get; set; } = "0";
        public string CantidadActualOtros { get; set; } = "0";
        public string CantidadIngresoOtros { get; set; } = "0";
        public string DiferenciaOtros { get; set; } = "0";



    }
}
