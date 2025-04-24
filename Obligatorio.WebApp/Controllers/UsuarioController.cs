using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaNegocio.VO;
using Obligatorio.WebApp.Models;

namespace Obligatorio.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        IGetAll<UsuarioListadoDTO> _getAll;
        IAdd<UsuarioDTO> _add;
        IRemove _remove;
        IGetById<UsuarioListadoDTO> _getById;
        IUpdate<UsuarioDTO> _update;

        public UsuarioController(IGetAll<UsuarioListadoDTO> getAll,
                                 IAdd<UsuarioDTO> add,
                                 IRemove remove,
                                 IGetById<UsuarioListadoDTO> getById,
                                 IUpdate<UsuarioDTO> update)
        {
            _getAll = getAll;
            _add = add;
            _remove = remove;
            _getById = getById;
            _update = update;
        }

        public IActionResult Index()
        {
            return View(_getAll.Execute());
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VMUsuario usuario)
        {
            try
            {
                _add.Execute(new UsuarioDTO(usuario.Nombre.Value,
                                            usuario.Apellido.Value,
                                            usuario.Contrasena.Value,
                                            usuario.Telefono.Value,
                                            usuario.Email.Value,
                                            usuario.Cedula.Value));
                return RedirectToAction("Index", new { message = "Usuario creado exitosamente!" });
            }

            catch(ArgumentNullException)
            {
                ViewBag.Message = "No envio datos";
            }

            return View();

        }
    }
}
