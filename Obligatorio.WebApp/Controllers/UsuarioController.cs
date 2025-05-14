using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.WebApp.Filters;
using Obligatorio.WebApp.Models;

namespace Obligatorio.WebApp.Controllers
{
    [AdminAutorizado]
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

        public IActionResult Index(string message)
        {
            ViewBag.Message = message;
            return View(_getAll.Execute());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VMUsuario usuario)
        {
            try
            {
                _add.Execute(new UsuarioDTO(usuario.Nombre,
                                            usuario.Apellido,
                                            usuario.Contrasena,
                                            usuario.Telefono,
                                            usuario.Email,
                                            usuario.Cedula));
                return RedirectToAction("Index", new { message = "Usuario creado exitosamente!" });
            }

            catch(ArgumentNullException)
            {
                ViewBag.Message = "Error al crear usuario";
            }

            return View();

        }

        public IActionResult Edit(int id)
        {
            try
            {
                UsuarioListadoDTO usuarioEncontrado = _getById.Execute(id);
                UsuarioDTO usuario = new UsuarioDTO(usuarioEncontrado.Nombre,
                                                       usuarioEncontrado.Apellido,
                                                       "",
                                                       usuarioEncontrado.Telefono,
                                                       usuarioEncontrado.Email,
                                                       usuarioEncontrado.Cedula);
                ViewBag.Id = id;
                return View(usuario);

            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { message = e.Message });

            }
        }

        [HttpPost]

        public IActionResult Edit(int id, UsuarioDTO usuario)
        {
            try
            {
                _update.Execute(id, usuario);
                return RedirectToAction("Index", new { message = "Usuario modificado exitosamente"});
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { message = e.Message});

            }
        }

        public IActionResult Details(int id)
        {
            UsuarioListadoDTO usuario = _getById.Execute(id);

            if (usuario == null)
            {
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                _remove.Execute(id);
                return RedirectToAction("Index", new { message = "Usuario eliminado exitosamente" });
            }
            catch (Exception e)
            {
                return RedirectToAction("index", new { message = e.Message });
            }
        }
    }
}
