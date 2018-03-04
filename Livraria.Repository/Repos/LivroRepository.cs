using Livraria.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Livraria.Repository.Repos
{
    public class LivroRepository : Repository<Livro>, ILivroRepository
    {
        public LivrariaContext Context => dbContext as LivrariaContext;

        public LivroRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Livro> GetLivrosOrdemAlfabetica()
        {
            return Context.Livros.OrderBy(l => l.Titulo);
        }
    }
}
