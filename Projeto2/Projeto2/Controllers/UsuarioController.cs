using Microsoft.AspNetCore.Mvc;

namespace Projeto2.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
