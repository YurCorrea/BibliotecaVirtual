using BibliotecaVirtual.Services;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaVirtual.Controllers
{
    public class AutorController : Controller
    {
        private readonly AutorService _Autorservice;

        public AutorController(AutorService autorservice)
        {
            _Autorservice = autorservice;
        }

        public async Task<IActionResult> Index()
        {
           // var autores = await _Autorservice.FindAllAsyncAsNoTracking();

            return View();
        }
        public IActionResult Listagem()
        {
            return ViewComponent("ListagemAutores");
        }
    }
}
