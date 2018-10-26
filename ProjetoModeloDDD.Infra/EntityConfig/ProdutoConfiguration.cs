using ProjetoModeloDDD.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoModeloDDD.Infra.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            HasKey(e => e.ProdutoId);

            Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(e => e.Valor)
                .IsRequired();

            HasRequired(e => e.Cliente)
                .WithMany()
                .HasForeignKey(e => e.ClienteId);   
        }
    }
}
