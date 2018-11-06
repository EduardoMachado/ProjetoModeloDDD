using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Infra.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace ProjetoModeloDDD.Infra.Context
{
    public class ProjetoModeloContext : DbContext
    {
        public ProjetoModeloContext()
            :base("ProjetoModeloDDD")
        {
            
        }

        public DbSet<Cliente>  Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(e => e.Name == e.ReflectedType.Name + "Id")
                .Configure(e => e.IsKey());

            modelBuilder.Properties<string>()
                .Configure(e => e.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(e => e.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new ProdutoConfiguration());


        }

        /// <summary>
        /// Executa ações no ato do sabe na entidade
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            //Sempre que houver uma entidade de nome DataCadastro
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                //Seto a data atual
                if (entry.State == EntityState.Added)
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;

                //Em caso de edição nao seta
                if (entry.State == EntityState.Modified)
                    entry.Property("DataCadastro").IsModified = false;
            }

            return base.SaveChanges();
        }

    }

       
}
