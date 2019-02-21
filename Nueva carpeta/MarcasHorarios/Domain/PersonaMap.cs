using System.Data.Entity.ModelConfiguration;

namespace Domain
{
    internal class PersonaMap : EntityTypeConfiguration<Persona>
    {
        public PersonaMap()
        {
            HasOptional(o => o.Supervisor)
                .WithMany(m => m.Subordinados)
                .HasForeignKey(m => m.SupervisorId);
        }
    }
}
