using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Domain
{
    public class DataContext:DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.Add(new PersonaMap());
            modelBuilder.Configurations.Add(new JustificacionMap());
        }

        public DbSet<TipoPago> TipoPagos { get; set; }

        public DbSet<EstadoCivil> EstadosCiviles { get; set; }

        public DbSet<Provincia> Provincias { get; set; }

        public DbSet<Canton> Cantones { get; set; }

        public DbSet<Distrito> Distritos { get; set; }

        public DbSet<Nacionalidad> Nacionalidades { get; set; }

        public DbSet<Puesto> Puestos { get; set; }

        public DbSet<Proyecto> Proyectos { get; set; }

        public DbSet<Persona> Personas { get; set; }

        public DbSet<NotificacionGeneralPersona> NotificacionGeneralPersonas { get; set; }

        public DbSet<NotificacionPersona> NotificacionPersonas { get; set; }

        public DbSet<RazonSocial> RazonesSociales { get; set; }

        public DbSet<BDPersonalff> BDPersonalff { get; set; }

        public DbSet<HorarioRubro> HorarioRubros { get; set; }

        public DbSet<HorarioPersona> HorarioPersonas { get; set; }

        public DbSet<Ubicacion> Ubicaciones { get; set; }

        public DbSet<EstadoMarca> EstadoMarcas { get; set; }

        public DbSet<Marca> Marcas { get; set; }

        public DbSet<Justificacion> Justificaciones { get; set; }
    }
}
