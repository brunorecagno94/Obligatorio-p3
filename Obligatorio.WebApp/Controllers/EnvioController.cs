using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasosDeUsoCompartida.DTOs.Agencias;
using Obligatorio.CasosDeUsoCompartida.DTOs.Envio;
using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.WebApp.Filters;
using Obligatorio.WebApp.Models;

namespace Obligatorio.WebApp.Controllers
{
    //[EmpleadoAutorizado]
    public class EnvioController : Controller
    {
        IGetByEmail<UsuarioListadoDTO> _getByEmail;
        IAdd<EnvioDTO> _add;
        IGetAll<EnvioListadoDTO> _getAll;
        IGetById<UsuarioListadoDTO> _getById;
        IGetAll<AgenciaListadaDTO> _getAllAgencias;

        public EnvioController(IGetByEmail<UsuarioListadoDTO> getByEmail,
                               IAdd<EnvioDTO> add,
                               IGetAll<EnvioListadoDTO> getAll,
                               IGetById<UsuarioListadoDTO> getById,
                               IGetAll<AgenciaListadaDTO> getAllAgencias)
        {
            _getByEmail = getByEmail;
            _add = add;
            _getAll = getAll;
            _getById = getById;
            _getAllAgencias = getAllAgencias;
        }
        public IActionResult Index()
        {
            IEnumerable<EnvioListadoDTO> enviosDTO = _getAll.Execute();
            List<VMEnvioListado> enviosVM = new List<VMEnvioListado>();

            foreach(var envio in enviosDTO)
            {
                var cliente = _getById.Execute(envio.ClienteId);

                enviosVM.Add(new VMEnvioListado(envio.NumeroTracking,
                                                envio.EsUrgente,
                                                cliente.Email,
                                                envio.FechaSalida,
                                                envio.Estado));
            }
           
            return View(enviosVM);
        }

        public IActionResult Create()
        {
            ViewBag.Agencias = _getAllAgencias.Execute();
            return View();
        }

        [HttpPost]
        public IActionResult Create(VMEnvio envio)
        {
            try
            {
                UsuarioListadoDTO usuario = _getByEmail.Execute(envio.EmailCliente);

                string empleadoId = HttpContext.Session.GetString("Id");

                _add.Execute(new EnvioDTO(envio.EsUrgente,
                                          int.Parse(empleadoId),
                                          usuario.Id,
                                          envio.PesoPaquete,
                                          envio.CalleDireccion,
                                          envio.NumeroDireccion,
                                          envio.CodigoPostalDireccion,
                                          envio.IdAgencia));

                return RedirectToAction("Index", new { message = "Envio creado exitosamente!" });
            }
            catch (Exception e)
            {
                ViewBag.Message = "Error al crear usuario";
            }

            return View();
        }

    }
}
