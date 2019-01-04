﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
 public   class Ordenes
    {
        [Key]
        public int OrdenId { get; set; }

        public string NumeroOrden { get; set; }
        public DateTime FeEnt { get; set; }

        [NotMapped]
        public DateTime FechaEnt { get{ return FeEnt.Date; } }
        public TimeSpan Horaent { get { return FeEnt.TimeOfDay; } }
        public string sFecha { get { return FeEnt.Date.ToString(); } }
        public string sHora { get { return FeEnt.TimeOfDay.ToString(); } }

        
        public string HoraSalida { get; set; }


        public string Localizacion { get; set; }
        public string FechaSalida { get; set; }
        public string TotalOrden { get; set; }
        public string CantidadPagada { get; set; }
        public string CantidadRestante { get; set; }
        public string EmpleadoRealizo { get; set; }
        public string NombreCliente { get; set; }
        public string MedioPago { get; set; }
        //  public virtual Cliente ClienteId { get; set; }
    }
}