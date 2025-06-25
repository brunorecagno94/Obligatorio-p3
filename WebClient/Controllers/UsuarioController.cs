using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net;
using System.Text.Json;
using WebClient.Models.DTOs.Usuarios;

namespace WebClient.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CambiarContrasena(CambiarContrasenaDTO datosContrasena)
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");

                if (string.IsNullOrEmpty(token))
                {
                    ViewBag.mensaje = "No tienes permisos para realizar esta acción";
                    return View("Index");
                }

                var client = new RestClient("https://localhost:7113");

                var request = new RestRequest("/api/v1/Usuarios/contrasena", Method.Put);
                request.AddHeader("Authorization", $"Bearer {token}");
                request.AddHeader("Content-Type", "application/json");

                var body = JsonSerializer.Serialize(datosContrasena);
                request.AddStringBody(body, DataFormat.Json);

                var response = client.Execute(request);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    ViewBag.mensaje = "No tienes permisos para realizar esta acción";
                }

                if (!response.IsSuccessful)
                {
                    ViewBag.mensaje = "Error al cambiar la contraseña";
                    return View("Index");
                }

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                ViewBag.exito = "Contraseña actualizada correctamente.";
                var usuario = JsonSerializer.Deserialize<UsuarioListadoDTO>(response.Content, options);
                return View("Index");
            }
            catch (Exception)
            {
                ViewBag.mensaje = "Ocurrió un error al obtener los datos del usuario, intente nuevamente.";
                return View("Index");
            }
        }

    }
}
