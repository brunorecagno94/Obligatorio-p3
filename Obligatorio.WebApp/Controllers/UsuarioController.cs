using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasosDeUsoCompartida.DTOs.LogsCrud;
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
        IAdd<LogCrudDTO> _addLog;
        //private string _usuarioLogueado = HttpContext.Session.GetString("Nombre");

        public UsuarioController(IGetAll<UsuarioListadoDTO> getAll,
                                 IAdd<UsuarioDTO> add,
                                 IRemove remove,
                                 IGetById<UsuarioListadoDTO> getById,
                                 IUpdate<UsuarioDTO> update,
                                 IAdd<LogCrudDTO> addLog)
        {
            _getAll = getAll;
            _add = add;
            _remove = remove;
            _getById = getById;
            _update = update;
            _addLog = addLog;
        }

        public IActionResult Index(string message)
        {
            try
            {
                ViewBag.Message = message;
                return View(_getAll.Execute());
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { message = "No se encontraron usuarios" });
            }
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

                _addLog.Execute(new LogCrudDTO(0,
                                            "Usuario creado",
                                            DateTime.Now,
                                            int.Parse(HttpContext.Session.GetString("Id"))));

                return RedirectToAction("Index", new { message = "Usuario creado exitosamente!" });
            }

            catch (ArgumentNullException)
            {
                ViewBag.Message = "Error al crear usuario";
            }
            catch (Exception e)
            {
                ViewBag.Message = "Hubo un error, intente nuevamente más tarde";
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
                return RedirectToAction("Index", new { message = "Hubo un error, intente nuevamente más tarde" });

            }
        }

        [HttpPost]

        public IActionResult Edit(int id, UsuarioDTO usuario)
        {
            try
            {
                _update.Execute(id, usuario);
                _addLog.Execute(new LogCrudDTO(0,
                                            "Usuario modificado",
                                            DateTime.Now,
                                            int.Parse(HttpContext.Session.GetString("Id"))));
                return RedirectToAction("Index", new { message = "Usuario modificado exitosamente" });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { message = "Hubo un error, intente nuevamente más tarde" });
            }
        }

        public IActionResult Details(int id)
        {
            UsuarioListadoDTO usuario = _getById.Execute(id);
            try
            {
                if (usuario == null)
                {
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (ArgumentNullException)
            {
                return RedirectToAction("Index", new { message = "No se encontró el usuario" });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { message = "Hubo un error, intente nuevamente más tarde" });
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                _remove.Execute(id);
                _addLog.Execute(new LogCrudDTO(0,
                                            "Usuario eliminado",
                                            DateTime.Now,
                                            int.Parse(HttpContext.Session.GetString("Id"))));
                return RedirectToAction("Index", new { message = "Usuario eliminado exitosamente" });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { message = "Hubo un error, intente nuevamente más tarde" });
            }
        }
    }
}
