using Livraria.Domain;
using Livraria.Web.Helpers;
using Livraria.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Livraria.Web.Controllers
{
    public class LivrosController : Controller
    {
        const string ControllerUri = "Livros";
        const string MainForm = "LivroForm";

        public async Task<ActionResult> Index()
        {
            var livros = await HttpClientHelper.GetAsync<IEnumerable<Livro>>(ControllerUri);

            return View(livros);
        }

        public ActionResult Cadastrar()
        {
            return View(MainForm);
        }

        public async Task<ActionResult> Alterar(int id)
        {
            var livro = await HttpClientHelper.GetAsync<Livro>($"{ControllerUri}/{id}");

            if (livro == null)
                return HttpNotFound();

            var livroViewModel = LivroViewModel.FromModel(livro);

            return View(MainForm, livroViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Salvar(LivroViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(MainForm, viewModel);

            if (!viewModel.Id.HasValue || viewModel.Id.Value == 0)
                await HttpClientHelper.PostAsync(ControllerUri, viewModel);
            else
                await HttpClientHelper.PutAsync($"{ControllerUri}/{viewModel.Id}", viewModel);

            return RedirectToAction(nameof(Index), ControllerUri);
        }
    }
}
