using Domain;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Finanzas.ViewModels
{
    public class PersonaViewModel:Persona
    {
        [Display(Name = "Foto")]
        public HttpPostedFileBase ImagenFile { get; set; }

        [Display(Name = "Fecha nacimiento")]
        public string sFechaNacimiento { get; set; }

        [Display(Name = "Fecha nacimiento")]
        public string sFechaSalida { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Contrasena", ErrorMessage = "Contraseña and Confirmar Contraseña No Coinciden")]
        public string ConfirmarContrasena { get; set; }

        public string Role { get; set; }
    }
}