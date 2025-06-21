using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebClient.Models.DTOs.Usuarios;

namespace Obligatorio.WebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(UsuarioLoginDTO usuario)
        {

            //try
            //{
            //var usuarioLogueado = null;
            //    ViewBag.NombreUsuario = usuarioLogueado.Nombre;
            //    HttpContext.Session.SetString("Rol", usuarioLogueado.Rol);
            //    HttpContext.Session.SetString("Nombre", usuarioLogueado.Nombre);
            //    HttpContext.Session.SetString("Id", usuarioLogueado.Id.ToString());
            //    return Redirect("/Home/Index");
            //}
            //catch (LoginErrorException e)
            //{
            //    ViewBag.mensaje = "Ocurrió un error al intentar ingresar";
            //}
            try
            {
                var options = new RestClientOptions("https://localhost:5001/")
                {
                    MaxTimeout = -1,
                };

                var client = new RestClient(options);
                var request = new RestRequest($"api/Usuarios/{usuario.Email}", Method.Get);
                RestResponse response = client.Execute(request);

                if ((int)response.StatusCode == 404)
                {
                    throw new Exception("Credenciales inválidas");
                }
                var optionsJSON = new JsonSerializerOptions
                {
                    WriteIndented = true, // Para que el JSON sea legible (formato con sangrías)
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // Usa camelCase para las propiedades
                    PropertyNameCaseInsensitive = true, // Permite deserializar sin importar mayúsculas/minúsculas
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull // Ignora propiedades nulas
                };

                UsuarioListadoDTO usuarioLogueado = JsonSerializer.Deserialize<UsuarioListadoDTO>(response.Content, optionsJSON);
            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;
            }
            return Redirect("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }

    }
}
