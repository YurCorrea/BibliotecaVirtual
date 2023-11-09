using BibliotecaVirtual.Services;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaVirtual.Controllers
{
    public class LivroController : Controller
    {
        private readonly LivroService _Livroservice;

        public LivroController(LivroService livroservice)
        {
            _Livroservice = livroservice;
        }

        public async Task<IActionResult> Index()
        {
            // var autores = await _Autorservice.FindAllAsyncAsNoTracking();

            return View();
        }
        public IActionResult Listagem()
        {
            return ViewComponent("ListagemLivrosInclude");
        }
    }
}
