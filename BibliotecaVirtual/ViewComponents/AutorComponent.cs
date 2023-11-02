using BibliotecaVirtual.Services;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaVirtual.ViewComponents
{
    [ViewComponent(Name = "ListagemAutores")]
    public class ListagemAutorComponent : ViewComponent
    {
        private readonly AutorService _Autorservice;
        public ListagemAutorComponent(AutorService autorservice)
        {
            _Autorservice = autorservice;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        { 
            var autores = await _Autorservice.FindAllAsyncAsNoTracking();

            return View("ListagemAutor",autores);
        }

    }
    [ViewComponent(Name = "ListagemDescricao")]
    public class ListagemDescricaoComponent : ViewComponent
    {
        private readonly AutorService _Autorservice;
        public ListagemDescricaoComponent(AutorService autorservice)
        {
            _Autorservice = autorservice;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var autores = await _Autorservice.FindDescricaoAsyncAsNoTracking();

            return View("ListagemDescricao", autores);
        }
    }

}
