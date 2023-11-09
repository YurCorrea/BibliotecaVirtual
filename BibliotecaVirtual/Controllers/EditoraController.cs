using BibliotecaVirtual.Services;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaVirtual.Controllers
{
    public class EditoraController : Controller
    {
        private readonly EditoraService _Editoraservice
            ;

        public EditoraController(EditoraService editoraservice)
        {
            _Editoraservice = editoraservice;
        }

        public async Task<IActionResult> Index()
        {
            // var autores = await _Autorservice.FindAllAsyncAsNoTracking();

            return View();
        }
        public IActionResult Listagem()
        {
            return ViewComponent("ListagemEditora");
        }
    }
}
