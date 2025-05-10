using Microsoft.AspNetCore.Mvc;
using Obligatorio.WebApp.Filters;

namespace Obligatorio.WebApp.Controllers
{
    [EmpleadoAutorizado]
    public class EnvioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
