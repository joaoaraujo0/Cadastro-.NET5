using Microsoft.AspNetCore.Mvc;
using NovoProjeto.Filters;

namespace NovoProjeto.Controllers
{
    public class RestritoController : Controller
    {
        [PaginaParaUsuarioLogado]
        public IActionResult Index()
        {
            return View();
        }
    }
}
