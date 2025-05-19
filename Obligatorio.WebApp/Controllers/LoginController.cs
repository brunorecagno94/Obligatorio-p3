using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.WebApp.Controllers
{
    public class LoginController : Controller
    {
        ILoginUsuario _loginUsuario;
        public LoginController(ILoginUsuario loginUsuario)
        {
            _loginUsuario = loginUsuario;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(UsuarioLoginDTO usuario)
        {
            try
            {
                var usuarioLogueado = _loginUsuario.Execute(usuario);
                ViewBag.NombreUsuario = usuarioLogueado.Nombre;
                HttpContext.Session.SetString("Rol", usuarioLogueado.Rol);
                HttpContext.Session.SetString("Nombre", usuarioLogueado.Nombre);
                HttpContext.Session.SetString("Id", usuarioLogueado.Id.ToString());
                return Redirect("/Home/Index");
            }
            catch (LoginErrorException e)
            {
                ViewBag.mensaje = "Ocurrió un error al intentar ingresar";
            }
            return View("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }

    }
}
