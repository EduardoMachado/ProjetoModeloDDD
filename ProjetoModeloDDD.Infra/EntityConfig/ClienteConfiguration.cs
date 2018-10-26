using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.EntityConfig
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            HasKey(e => e.ClienteId);

            Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(e => e.SobreNome)
                .IsRequired()
                .HasMaxLength(200);

            Property(e => e.Email)
                .IsRequired();
        }

    }
}
