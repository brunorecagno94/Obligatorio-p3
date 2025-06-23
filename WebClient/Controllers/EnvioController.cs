using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;
using WebClient.Models.DTOs.Envio;

namespace WebClient.Controllers
{
    public class EnvioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BuscarPorTracking(string numeroTracking)
        {
            try
            {
                var options = new RestClientOptions("https://localhost:7113")
                {
                    MaxTimeout = -1,
                };
                int numeroTrackingInt;
                int.TryParse(numeroTracking, out numeroTrackingInt);
                if (numeroTrackingInt <= 0)
                {
                    throw new Exception("Ingrese un número mayor a 0");
                }

                var client = new RestClient(options);
                var request = new RestRequest($"/api/v1/Envios/{numeroTrackingInt}", Method.Get);
                RestResponse response = client.Execute(request);
                var optionsJson = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                if ((int)response.StatusCode == 404)
                {
                    ViewBag.Mensaje = "No se encontró ningún envío con ese número de tracking";
                    return View("Index");
                }
                EnvioListadoDTO envio = JsonSerializer.Deserialize<EnvioListadoDTO>(response.Content, optionsJson);

                return View("Index", envio);
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Hubo un error, intente nuevamente";
            }
            return View("Index");

        }

        public IActionResult GetByUsuario()
        {
            try
            {
                var options = new RestClientOptions("https://localhost:7113")
                {
                    MaxTimeout = -1,
                };
                int idUsuarioInt;
                int.TryParse(HttpContext.Session.GetString("Id"), out idUsuarioInt);
                if (idUsuarioInt <= 0)
                {
                    throw new Exception("Ingrese un número mayor a 0");
                }
                ViewBag.IdUsuario = idUsuarioInt;

                var client = new RestClient(options);
                var request = new RestRequest($"/api/v1/Envios/mis-envios/{idUsuarioInt}", Method.Get);
                RestResponse response = client.Execute(request);
                var optionsJson = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                if ((int)response.StatusCode == 404)
                {
                    ViewBag.Mensaje = "No se encontró ningún envío";
                    return View("Index");
                }
                IEnumerable<EnvioListadoDTO> envios = JsonSerializer.Deserialize<IEnumerable<EnvioListadoDTO>>(response.Content, optionsJson);

                return View(envios);
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Hubo un error, intente nuevamente";
            }
            return View("Index");
        }
    }
}
