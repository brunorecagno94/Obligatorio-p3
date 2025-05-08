using Microsoft.AspNetCore.Mvc;

namespace Obligatorio.WebApp.Controllers
{
    public class EnvioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
