using Livraria.Domain;
using Livraria.Web.Validation;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Web.Models
{
    public class LivroViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Informe o título do livro.")]
        [MaxLength(255, ErrorMessage = "O título do livro deve ter no máximo 255 caracteres.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Informe o nome do autor do livro.")]
        [MaxLength(255, ErrorMessage = "O nome do autor do livro deve ter no máximo 255 caracteres.")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "Informe o ano de publicação do livro.")]
        [ValidarAno]
        public int AnoPublicacao { get; set; }

        [Required(ErrorMessage = "Informe o ISBN do livro.")]
        public long Isbn { get; set; }

        public static LivroViewModel FromModel(Livro livro)
        {
            return new LivroViewModel
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                Autor = livro.Autor,
                AnoPublicacao = livro.AnoPublicacao,
                Isbn = livro.Isbn
            };
        }

        public Livro ToModel()
        {
            return new Livro
            {
                Id = Id ?? 0,
                Titulo = Titulo,
                Autor = Autor,
                AnoPublicacao = AnoPublicacao,
                Isbn = Isbn
            };
        }
    }
}