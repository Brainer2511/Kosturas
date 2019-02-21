using Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finanzas.ViewModels
{
    [NotMapped]
    public class ProyectoViewModel:Proyecto
    {
        public string sFecha { get; set; }
    }
}