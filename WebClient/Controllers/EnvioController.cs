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
                    throw new Exception("Ingrese un número válido");
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

                var token = HttpContext.Session.GetString("Token");
                if (string.IsNullOrEmpty(token))
                {
                    throw new Exception("Token no encontrado");
                }

                var client = new RestClient(options);
                var request = new RestRequest($"/api/v1/Envios/mis-envios", Method.Get);
                request.AddHeader("Authorization", $"Bearer {token}");

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
                IEnumerable<EnvioCompletoListadoDTO> envios = JsonSerializer.Deserialize<IEnumerable<EnvioCompletoListadoDTO>>(response.Content, optionsJson);

                return View(envios);
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Hubo un error, intente nuevamente";
            }
            return View("Index");
        }

        public IActionResult BuscarPorComentario()
        {
            var listaVacia = new List<EnvioCompletoListadoDTO>();
            return View(listaVacia);
        }

        [HttpPost]
        public IActionResult BuscarPorComentario(string palabraClave)
        {
            try
            {
                var token = HttpContext.Session.GetString("Token");
                if (string.IsNullOrEmpty(token))
                {
                    throw new Exception("Token no encontrado");
                }

                var options = new RestClientOptions("https://localhost:7113")
                {
                    MaxTimeout = -1,
                };

                var client = new RestClient(options);
                var request = new RestRequest("/api/v1/Envios/mis-envios/busquedaComentario", Method.Post);
                request.AddHeader("Authorization", $"Bearer {token}");
                request.AddHeader("Content-Type", "application/json");

                var body = JsonSerializer.Serialize(palabraClave);
                request.AddStringBody(body, DataFormat.Json);

                RestResponse response = client.Execute(request);

                var optionsJson = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                if ((int)response.StatusCode == 404)
                {
                    ViewBag.Mensaje = "No se encontraron envíos que coincidan con el comentario";
                    return View();
                }

                IEnumerable<EnvioCompletoListadoDTO> envios = JsonSerializer.Deserialize<IEnumerable<EnvioCompletoListadoDTO>>(response.Content, optionsJson);

                return View("BuscarPorComentario", envios);
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Hubo un error, intente nuevamente";
                return View();
            }
        }
    }
}
