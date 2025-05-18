using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasosDeUsoCompartida.DTOs.Agencias;
using Obligatorio.CasosDeUsoCompartida.DTOs.Envio;
using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.VO;
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
        public EnvioController(IGetByEmail<UsuarioListadoDTO> getByEmail,
                               IAdd<EnvioDTO> add,
                               IGetAll<EnvioListadoDTO> getAll,
                               IGetById<UsuarioListadoDTO> getById,
                               IGetAll<AgenciaListadaDTO> getAllAgencias,
                               IAddComentario addCommentario,
                               IGetById<EnvioListadoDTO> getByIdEnvio,
                               IGetAllComentarios<ComentarioDTO> getAllComentarios)
        {
            _getByEmail = getByEmail;
            _add = add;
            _getAll = getAll;
            _getById = getById;
            _getAllAgencias = getAllAgencias;
            _addComentario = addCommentario;
            _getByIdEnvio = getByIdEnvio;
            _getAllComentarios = getAllComentarios;
        }
        public IActionResult Index()
        {
            IEnumerable<EnvioListadoDTO> enviosDTO = _getAll.Execute();
            List<VMEnvioListado> enviosVM = new List<VMEnvioListado>();

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

            return View(enviosVM);
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

    }
}
