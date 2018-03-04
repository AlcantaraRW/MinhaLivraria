using Livraria.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Livraria.Repository.EntityConfigurations
{
    public class LivroConfiguration : EntityTypeConfiguration<Livro>
    {
        public LivroConfiguration()
        {
            ToTable("Livros");

            Property(l => l.Titulo)
                .HasMaxLength(255)
                .IsRequired();

            Property(l => l.Autor)
                .HasMaxLength(255)
                .IsRequired();

            Property(l => l.AnoPublicacao)
                .IsRequired();
        }
    }
}
