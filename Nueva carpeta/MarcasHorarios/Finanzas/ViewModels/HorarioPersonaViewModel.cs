using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finanzas.ViewModels
{
    public class HorarioPersonaViewModel:HorarioPersona
    {
        public string sFecha { get; set; }

        public string sHora { get; set; }
    }
}