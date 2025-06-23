using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasosDeUsoCompartida.DTOs.Login;
using RestSharp;
using System.Net;
using System.Text.Json;
using WebClient.Models.DTOs.Usuarios;

namespace WebClient.Controllers
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
            try
            {
                var client = new RestClient("https://localhost:7113");
                var request = new RestRequest("/api/v1/Auth/login", Method.Post);
                request.AddHeader("Content-Type", "application/json");

                var body = JsonSerializer.Serialize(usuario);
                request.AddStringBody(body, DataFormat.Json);

                RestResponse response = client.Execute(request);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    throw new Exception("Credenciales inválidas");

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var loginResponse = JsonSerializer.Deserialize<LoginResponse>(response.Content, options);

                HttpContext.Session.SetString("Token", loginResponse.Token);
                HttpContext.Session.SetString("Nombre", JsonSerializer.Serialize(loginResponse.Usuario.Nombre));
                HttpContext.Session.SetString("Rol", JsonSerializer.Serialize(loginResponse.Usuario.Rol));

                return Redirect("/Envio/Index");
            }
            catch (Exception)
            {
                ViewBag.mensaje = "Ocurrió un error al iniciar sesión, intente nuevamente";
                return View("Index");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }

    }
}
