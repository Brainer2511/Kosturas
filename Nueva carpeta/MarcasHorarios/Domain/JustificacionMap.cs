using System.Data.Entity.ModelConfiguration;

namespace Domain
{
    internal class JustificacionMap : EntityTypeConfiguration<Justificacion>
    {
        public JustificacionMap()
        {
            HasOptional(o => o.Supervisor)
                .WithMany(m => m.JustificacionesSupervisor)
                .HasForeignKey(m => m.SupervisorId);

            HasOptional(o => o.Subordinado)
               .WithMany(m => m.JustificacionesSubordinado)
               .HasForeignKey(m => m.SubordinadoId);

            HasOptional(o => o.Planilla)
              .WithMany(m => m.JustificacionesPlanilla)
              .HasForeignKey(m => m.PlanillaId);
        }
    }
}
