using Livraria.Domain;
using Livraria.Repository;
using System;
using System.Web.Http;

namespace Livraria.Api.Controllers
{
    public class LivrosController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public LivrosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IHttpActionResult Get()
        {
            return Ok(_unitOfWork.Livros.GetLivrosOrdemAlfabetica());
        }

        public IHttpActionResult Get(int id)
        {
            var livro = _unitOfWork.Livros.Get(id);

            if (livro == null)
                return NotFound();

            return Ok(livro);
        }

        public IHttpActionResult Post(Livro livro)
        {
            try
            {
                _unitOfWork.Livros.Add(livro);
                _unitOfWork.Complete();

                return Created(new Uri($"{Request.RequestUri}/{livro.Id}"), livro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Put(int id, Livro livro)
        {
            try
            {
                var livroDb = _unitOfWork.Livros.Get(id);

                if (livroDb == null)
                    return NotFound();

                livroDb.Titulo = livro.Titulo;
                livroDb.Autor = livro.Autor;
                livroDb.AnoPublicacao = livro.AnoPublicacao;
                livroDb.Isbn = livro.Isbn;

                _unitOfWork.Complete();

                return Ok(livroDb);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                var livro = _unitOfWork.Livros.Get(id);

                if (livro == null)
                    return NotFound();

                _unitOfWork.Livros.Remove(livro);
                _unitOfWork.Complete();

                return Ok(livro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
