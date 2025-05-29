using Microsoft.AspNetCore.Mvc;

namespace Obligatorio.WebApp.Controllers
{
    public class EnvioController : Controller
    {
        public IActionResult Index(string mensaje)
        {
            ViewBag.message = mensaje;

            return View();
        }

        //public IActionResult BuscarPorNumeroDeTracking(int numeroTracking)
        //{
        //    try
        //    {
        //        EnvioListadoDTO envio = null;
        //        //var cliente = null;
        //        VMEnvioListado VMEnvio = new VMEnvioListado(envio.Id, envio.NumeroTracking,
        //                                        envio.EsUrgente,
        //                                        cliente.Email,
        //                                        envio.FechaSalida,
        //                                        envio.Estado);
        //        return View("Index", new List<VMEnvioListado> { VMEnvio });

        //    }
        //    catch (NotFoundException e)
        //    {
        //        ViewBag.message = "No se encontró ningún envío con ese número de tracking.";
        //        return View("Index", new List<VMEnvioListado>());
        //    }

        //}

        //public IActionResult Create()
        //{
        //    var agencias = _getAllAgencias.Execute();
        //    ViewBag.Agencias = agencias ?? new List<AgenciaListadaDTO>();
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(VMEnvio envio)
        //{
        //    try
        //    {
        //        UsuarioListadoDTO usuario = _getByEmail.Execute(envio.EmailCliente);

        //        string empleadoId = HttpContext.Session.GetString("Id");

        //        if (envio.IdAgencia == 0 && !envio.EsUrgente)
        //        {
        //            throw new AgenciaNulaException();
        //        }
        //        _add.Execute(new EnvioDTO(envio.Id,
        //                                  envio.EsUrgente,
        //                                  int.Parse(empleadoId),
        //                                  usuario.Id,
        //                                  envio.PesoPaquete,
        //                                  envio.CalleDireccion,
        //                                  envio.NumeroDireccion,
        //                                  envio.CodigoPostalDireccion,
        //                                  envio.IdAgencia));

        //        return RedirectToAction("Index", new { message = "Envío creado exitosamente!" });
        //    }
        //    catch (NotFoundException e)
        //    {
        //        ViewBag.Mensaje = "Error al crear envío, el mail de cliente incorrecto";
        //    }
        //    catch (PesoPaqueteException e)
        //    {
        //        ViewBag.Mensaje = "Error al crear envío, el peso del paquete debe ser mayor a 0";
        //    }
        //    catch (CalleException e)
        //    {
        //        ViewBag.Mensaje = "Error al crear envío, la calle no puede estar vacía";
        //    }
        //    catch (NumeroException e)
        //    {
        //        ViewBag.Mensaje = "Error al crear envío, el número no puede estar vacío";
        //    }
        //    catch (CodigoPostalException e)
        //    {
        //        ViewBag.Mensaje = "Error al crear envío, el código postal no puede estar vacío";
        //    }
        //    catch (AgenciaNulaException e)
        //    {
        //        ViewBag.Mensaje = "La agencia no puede ser nula si el envío no es urgente.";
        //    }
        //    catch (Exception e)
        //    {
        //        ViewBag.Mensaje = "Error al crear el envío";
        //    }
        //    var agencias = _getAllAgencias.Execute();
        //    ViewBag.Agencias = agencias ?? new List<AgenciaListadaDTO>();
        //    return View("Create", envio);

        //}

        //private VMEnvioComentarios CargarVMEnvioComentarios(int envioId)
        //{
        //    EnvioListadoDTO envio = _getByIdEnvio.Execute(envioId);
        //    IEnumerable<ComentarioDTO> comentarios = _getAllComentarios.Execute(envioId);

        //    List<VMComentario> comentariosVM = comentarios
        //        .Select(c => new VMComentario(c.TextoComentario, c.Empleado, c.EnvioId, c.FechaComentario))
        //        .ToList();

        //    return new VMEnvioComentarios(
        //        envio.Id,
        //        envio.NumeroTracking,
        //        envio.EsUrgente,
        //        envio.ClienteId.ToString(),
        //        envio.FechaSalida,
        //        envio.Estado,
        //        comentariosVM
        //    );
        //}

        //public IActionResult Comentarios(int id)
        //{
        //    var model = CargarVMEnvioComentarios(id);
        //    return View(model);
        //}

        //[HttpPost]
        //public IActionResult AgregarComentario(VMComentario comentario)
        //{
        //    try
        //    {
        //        _addComentario.Execute(comentario.TextoComentario, comentario.EmpleadoId, comentario.EnvioId);
        //        return RedirectToAction("Comentarios", new { id = comentario.EnvioId });
        //    }
        //    catch (Exception)
        //    {
        //        ViewBag.Error = "Error al agregar comentario.";
        //        var model = CargarVMEnvioComentarios(comentario.EnvioId);
        //        return View("Comentarios", model);
        //    }

        //}

        //public IActionResult FinalizarEnvio(int id)
        //{
        //    try
        //    {
        //        _finalizarEnvio.Execute(id);
        //        return RedirectToAction("Index", new { message = "Envio finalizado exitosamente" });
        //    }
        //    catch (Exception e)
        //    {
        //        ViewBag.Error = "Error al finalizar envio.";
        //        return RedirectToAction("Index");
        //    }
        //}

        //[HttpGet]
        //public IActionResult FiltrarPorRangoFechas(DateTime? fechaInicio, DateTime? fechaFin)
        //{
        //    if (fechaInicio == null || fechaFin == null)
        //    {

        //        IEnumerable<EnvioListadoDTO> enviosDTO = _getAll.Execute();
        //        List<VMEnvioListado> enviosVM = new List<VMEnvioListado>();
        //        try
        //        {
        //            foreach (var envio in enviosDTO)
        //            {
        //                var cliente = _getById.Execute(envio.ClienteId);

        //                enviosVM.Add(new VMEnvioListado(
        //                    envio.Id, envio.NumeroTracking,
        //                                                envio.EsUrgente,
        //                                                cliente.Email,
        //                                                envio.FechaSalida,
        //                                                envio.Estado));
        //            }

        //        }
        //        catch (Exception e)
        //        {
        //            ViewBag.message = "Error al cargar envios";
        //        }

        //        return View("Index", enviosVM);
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
