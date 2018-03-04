using Livraria.Domain;
using System.Collections.Generic;

namespace Livraria.Repository.Repos
{
    public interface ILivroRepository : IRepository<Livro>
    {
        IEnumerable<Livro> GetLivrosOrdemAlfabetica();
    }
}
