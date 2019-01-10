using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Empleado
    {
        [Key]
        public int EmpleadoId { get; set; }
        
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Alias { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public bool RecibirInforme { get; set; } = true;
        public bool ResivirNotifica { get; set; } = true;
        public bool EditPagina { get; set; } = true;
        public bool EditSegundaPagina { get; set; } = true;
        public bool ApcederTarjeta { get; set; } = true;
        public bool EditCreditoClinte { get; set; } = true;
        public bool EditPuntosClinte { get; set; } = true;
        public bool AbrirCajon { get; set; } = true;
        public TimeSpan? desdelunes { get; set; }
        public TimeSpan? desdemartes { get; set; }
        public TimeSpan? desdemiercoles { get; set; }
        public TimeSpan? desdejueves { get; set; }
        public TimeSpan? desdeviernes { get; set; }
        public TimeSpan? desdesabado { get; set; }
        public TimeSpan? desdedomingo { get; set; }
        public TimeSpan? hastalunes { get; set; }
        public TimeSpan? hastamartes { get; set; }
        public TimeSpan? hastamiercoles { get; set; }
        public TimeSpan? hastajueves { get; set; }
        public TimeSpan? hastaviernes { get; set; }
        public TimeSpan? hastasabado { get; set; }
        public TimeSpan? hastadomingo { get; set; }

        public int HorasLunes { get{ return hastalunes.Value.Hours-desdelunes.Value.Hours; } }
        public int HorasMartes { get { return hastamartes.Value.Hours - desdemartes.Value.Hours; } }
        public int HorasMiercoles { get { return hastamiercoles.Value.Hours - desdemiercoles.Value.Hours; } }
        public int HorasJueves { get { return hastajueves.Value.Hours - desdejueves.Value.Hours; } }
        public int HorasViernes { get { return hastaviernes.Value.Hours - desdeviernes.Value.Hours; } }
        public int HorasSabado { get { return hastasabado.Value.Hours - desdesabado.Value.Hours; } }
        public int HorasDomingo { get { return hastadomingo.Value.Hours - desdedomingo.Value.Hours; } }
    }
}
