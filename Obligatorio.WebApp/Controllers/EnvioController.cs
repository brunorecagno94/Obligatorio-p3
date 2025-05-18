using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasosDeUsoCompartida.DTOs.Agencias;
using Obligatorio.CasosDeUsoCompartida.DTOs.Envio;
using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.Infraestructura.AccesoDatos.Exceptiones;
using Obligatorio.WebApp.Filters;
using Obligatorio.WebApp.Models;

namespace Obligatorio.WebApp.Controllers
{
    [EmpleadoAutorizado]
    public class EnvioController : Controller
    {
        IGetByEmail<UsuarioListadoDTO> _getByEmail;
        IAdd<EnvioDTO> _add;
        IGetAll<EnvioListadoDTO> _getAll;
        IGetById<UsuarioListadoDTO> _getById;
        IGetById<EnvioListadoDTO> _getByIdEnvio;
        IGetAll<AgenciaListadaDTO> _getAllAgencias;
        IAddComentario _addComentario;
        IGetAllComentarios<ComentarioDTO> _getAllComentarios;
        IFinalizarEnvio _finalizarEnvio;
        IGetByNumeroTracking<EnvioListadoDTO> _getByNumeroTracking;
        public EnvioController(IGetByEmail<UsuarioListadoDTO> getByEmail,
                               IAdd<EnvioDTO> add,
                               IGetAll<EnvioListadoDTO> getAll,
                               IGetById<UsuarioListadoDTO> getById,
                               IGetAll<AgenciaListadaDTO> getAllAgencias,
                               IAddComentario addCommentario,
                               IGetById<EnvioListadoDTO> getByIdEnvio,
                               IGetAllComentarios<ComentarioDTO> getAllComentarios,
                               IFinalizarEnvio finalizarEnvio,
                               IGetByNumeroTracking<EnvioListadoDTO> getByNumeroTracking)
        {
            _getByEmail = getByEmail;
            _add = add;
            _getAll = getAll;
            _getById = getById;
            _getAllAgencias = getAllAgencias;
            _addComentario = addCommentario;
            _getByIdEnvio = getByIdEnvio;
            _getAllComentarios = getAllComentarios;
            _finalizarEnvio = finalizarEnvio;
            _getByNumeroTracking = getByNumeroTracking;
        }
        public IActionResult Index()
        {
            IEnumerable<EnvioListadoDTO> enviosDTO = _getAll.Execute();
            List<VMEnvioListado> enviosVM = new List<VMEnvioListado>();
            try
            {
                foreach (var envio in enviosDTO)
                {
                    var cliente = _getById.Execute(envio.ClienteId);

                    enviosVM.Add(new VMEnvioListado(
                        envio.Id, envio.NumeroTracking,
                                                    envio.EsUrgente,
                                                    cliente.Email,
                                                    envio.FechaSalida,
                                                    envio.Estado));
                }
            }
            catch (Exception e)
            {
                ViewBag.message = "Error al cargar envios";
            }

            return View(enviosVM);
        }

        public IActionResult BuscarPorNumeroDeTracking(int numeroTracking)
        {
            try
            {
                EnvioListadoDTO envio = _getByNumeroTracking.Execute(numeroTracking);
                var cliente = _getById.Execute(envio.ClienteId);
                VMEnvioListado VMEnvio = new VMEnvioListado(envio.Id, envio.NumeroTracking,
                                                envio.EsUrgente,
                                                cliente.Email,
                                                envio.FechaSalida,
                                                envio.Estado);
                return View("Index", new List<VMEnvioListado> { VMEnvio });

            }
            catch (NotFoundException e)
            {
                ViewBag.message = "No se encontró ningún envío con ese número de tracking.";
                return View("Index", new List<VMEnvioListado>());
            }

        }

        public IActionResult Create()
        {
            var agencias = _getAllAgencias.Execute();
            ViewBag.Agencias = agencias ?? new List<AgenciaListadaDTO>();
            return View();
        }

        [HttpPost]
        public IActionResult Create(VMEnvio envio)
        {
            try
            {
                UsuarioListadoDTO usuario = _getByEmail.Execute(envio.EmailCliente);

                string empleadoId = HttpContext.Session.GetString("Id");


                _add.Execute(new EnvioDTO(envio.Id,
                                          envio.EsUrgente,
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
                ViewBag.Message = "Error al crear envio";
            }

            return RedirectToAction("Index");
        }

        private VMEnvioComentarios CargarVMEnvioComentarios(int envioId)
        {
            EnvioListadoDTO envio = _getByIdEnvio.Execute(envioId);
            IEnumerable<ComentarioDTO> comentarios = _getAllComentarios.Execute(envioId);

            List<VMComentario> comentariosVM = comentarios
                .Select(c => new VMComentario(c.TextoComentario, c.Empleado, c.EnvioId, c.FechaComentario))
                .ToList();

            return new VMEnvioComentarios(
                envio.Id,
                envio.NumeroTracking,
                envio.EsUrgente,
                envio.ClienteId.ToString(),
                envio.FechaSalida,
                envio.Estado,
                comentariosVM
            );
        }

        public IActionResult Comentarios(int id)
        {
            var model = CargarVMEnvioComentarios(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult AgregarComentario(VMComentario comentario)
        {
            try
            {
                _addComentario.Execute(comentario.TextoComentario, comentario.EmpleadoId, comentario.EnvioId);
                return RedirectToAction("Comentarios", new { id = comentario.EnvioId });
            }
            catch (Exception)
            {
                ViewBag.Error = "Error al agregar comentario.";
                var model = CargarVMEnvioComentarios(comentario.EnvioId);
                return View("Comentarios", model);
            }

        }

        public IActionResult FinalizarEnvio(int id)
        {
            try
            {
                _finalizarEnvio.Execute(id);
                return RedirectToAction("Index", new { message = "Envio finalizado exitosamente" });
            }
            catch (Exception e)
            {
                ViewBag.Error = "Error al finalizar envio.";
                return RedirectToAction("Index");
            }
        }

        //[HttpGet]
        //public IActionResult FiltrarPorRangoFechas(DateTime? fechaInicio, DateTime? fechaFin)
        //{
        //    if (fechaInicio == null || fechaFin == null)
        //    {
        //        // Retornar todos si no hay fechas
        //        var todos = _getAll.Execute();
        //        return View("Index", todos.Select(...));
        //    }

        //    if (fechaInicio > fechaFin)
        //    {
        //        ViewBag.Mensaje = "La fecha de inicio no puede ser posterior a la fecha de fin.";
        //        return View("Index");
        //    }

        //    var enviosFiltrados = _getAll.Execute()
        //        .Where(e => e.FechaSalida >= fechaInicio && e.FechaSalida <= fechaFin)
        //        .ToList();

        //    if (!enviosFiltrados.Any())
        //    {
        //        ViewBag.Mensaje = "No se encontraron envíos en el rango seleccionado.";
        //        return View("Index", new List<VMEnvioListado>());
        //    }

        //    var resultado = enviosFiltrados.Select(e => new VMEnvioListado(
        //        e.Id,
        //        e.NumeroTracking,
        //        e.EsUrgente,
        //        _getById.Execute(e.ClienteId).Email,
        //        e.FechaSalida,
        //        e.Estado
        //    )).ToList();

        //    return View("Index", resultado);
        //}

    }
}
