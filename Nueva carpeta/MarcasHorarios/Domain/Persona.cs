using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Persona
    {
        [Key]
        public int PersonaId { get; set; }

        public int? LoginId { get; set; }

        public int RazonSocialId { get; set; }

        [Display(Name = "ADM/CC")]
        public string ADMCC { get; set; }

        public bool Activo { get; set; }

        [Display(Name = "Bilingüe")]
        public bool Bilingue { get; set; }

        public DateTime? FechaIngreso { get; set; } = DateTime.Today;

        [Display(Name ="Fecha Salida")]
        public DateTime? FechaSalida { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Imagen { get; set; }

        [Display(Name = "Género")]
        public string Genero { get; set; }

        [Display(Name = "Identificación")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(150, ErrorMessage = "El tamaño maximo del campo {0} es {1} caracteres")]
        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        [Display(Name ="Fecha Nacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        [NotMapped]
        [Display(Name ="Nombre Completo")]
        public string NombreCompleto { get { return string.Format("{0} {1}", Nombre, Apellidos); } }

        [Display(Name ="Cuenta Banco")]
        public string CuentaBanco { get; set; }

        public double Salario { get; set; } = 0;

        public int NacionalidadId { get; set; }

        [Display(Name ="Teléfono")]
        public string Telefono { get; set; }

        public string Celular { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public int? numeroProvincia { get; set; }
        public int? numeroCanton { get; set; }
        public int? numeroDistrito { get; set; }

        [Display(Name ="Dirección")]
        [DataType(DataType.MultilineText)]
        public string Direccion { get; set; }

        public int EstadoCivilId { get; set; }

        public int PuestoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(50, ErrorMessage = "El tamaño maximo del campo {0} es {1} caracteres")]
        [Index("Persona_Usuario_Index", IsUnique = true)]
        public string Usuario { get; set; }

        public int? SupervisorId { get; set; }

        [Display(Name ="Marca San Pedro")]
        public string MarcaSP { get; set; }

        [Display(Name ="Marca Zapote")]
        public string MarcaZAP{ get; set; }

        public virtual EstadoCivil EstadoCivil { get; set; }

        public virtual RazonSocial RazonSocial { get; set; }

        public virtual Nacionalidad Nacionalidad { get; set; }

        public virtual Distrito Distrito { get; set; }

        public virtual Puesto Puesto { get; set; }

        public virtual Persona Supervisor { get; set; }

        public virtual ICollection<Persona> Subordinados { get; set; }

        public virtual ICollection<NotificacionPersona> Notificaciones { get; set; }

        public virtual ICollection<NotificacionGeneralPersona> NotificacionesGenerales { get; set; }

        public virtual ICollection<HorarioPersona> Horarios { get; set; }

        public virtual ICollection<Marca> Marcas { get; set; }

        public virtual ICollection<Justificacion> JustificacionesSupervisor { get; set; }

        public virtual ICollection<Justificacion> JustificacionesSubordinado { get; set; }

        public virtual ICollection<Justificacion> JustificacionesPlanilla { get; set; }
    }
}
