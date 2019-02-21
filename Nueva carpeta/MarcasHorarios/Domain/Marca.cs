using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Marca
    {
        [Key]
        public int MarcaId { get; set; }
        
        public DateTime Fecha { get; set; }

        public TimeSpan? HoraEntrada { get; set; }

        public TimeSpan? HoraSalida { get; set; }

        public TimeSpan? HoraOT { get; set; }

        public TimeSpan HorasTrabajadas { get { return HoraEntrada==null?TimeSpan.MinValue:HoraSalida==null?TimeSpan.MinValue:HoraSalida.Value - HoraEntrada.Value; } }

        public int UbicacionId { get; set; }

        public int PersonaId { get; set; }

        public int? EstadoMarcaId { get; set; }

        public virtual Ubicacion Ubicacion { get; set; }

        public virtual Persona Persona { get; set; }

        public virtual EstadoMarca EstadoMarca { get; set; }
    }
}
