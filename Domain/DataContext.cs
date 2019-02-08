using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Domain
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<Provincia> Provincias { get; set; }

        public DbSet<Canton> Cantones { get; set; }

        public DbSet<Distrito> Distritos { get; set; }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Sucursal> Sucursales { get; set; }

        public DbSet<MediosPago> MediosPago { get; set; }

        public DbSet<Servicios> Servicios { get; set; }

        public DbSet<Ofertas> Ofertas { get; set; }

        public DbSet<ImpresionesAutomaticas> impresiones { get; set; }

        public DbSet<DetallesOrdenes> DetallesOrdenes { get; set; }

        public DbSet<Tarea> Tareas { get; set; }

        public DbSet<DetalleTarea> DetalleTareas { get; set; }

        public DbSet<Prenda> Prendas { get; set; }

        public DbSet<OpcionesOrdenes> opcionesOrdenes { get; set; }

        public DbSet<Afiliado> Afiliados { get; set; }


        public DbSet<Usuario> Usuarios { get; set; }


        public DbSet<Ordenes> Ordenes { get; set; }

        public DbSet<Pagos> Pagos { get; set; }

        public DbSet<TemDetallesOrdenes> OrdenDetalleTareas { get; set; }

        public DbSet<TemDetallesOrdenPrenda> OrdenDetallePrendas { get; set; }

        public DbSet<CierreCaja> CierreCajas { get; set; }

        public DbSet<Estados>  Estados { get; set; }


        public DbSet<CodigoBarras> CodigoBarras { get; set; }
    }
}
