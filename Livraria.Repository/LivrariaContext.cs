using Livraria.Domain;
using Livraria.Repository.EntityConfigurations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Livraria.Repository
{
    public class LivrariaContext : DbContext
    {
        public DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new LivroConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public LivrariaContext() : base()
        {
        }
    }
}