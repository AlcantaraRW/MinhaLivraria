using Livraria.Repository.Repos;
using System;

namespace Livraria.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LivrariaContext _context;

        public ILivroRepository Livros { get; private set; }

        public UnitOfWork(LivrariaContext context)
        {
            _context = context;
            Livros = new LivroRepository(_context);
        }

        public int Complete()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
