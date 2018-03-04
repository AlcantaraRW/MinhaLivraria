using Livraria.Repository.Repos;
using System;

namespace Livraria.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ILivroRepository Livros { get; }
        int Complete();
    }
}
