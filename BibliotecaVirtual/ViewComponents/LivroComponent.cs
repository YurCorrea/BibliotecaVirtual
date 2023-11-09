using BibliotecaVirtual.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaVirtual.ViewComponents
{
    [ViewComponent(Name = "ListagemLivrosInclude")]
    public class LivroComponent : ViewComponent
    {
        private readonly LivroService _livroService;

        public LivroComponent(LivroService livroService)
        {
            _livroService = livroService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var livros = await _livroService.FindAllAsyncAsNoTrackingInclude();
            return View("ListagemLivrosInclude", livros);

        }
    }
}
