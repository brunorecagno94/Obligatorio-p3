
using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Usuarios
{
    public class CambiarContrasenaUsuario : ICambiarContrasenaUsuario
    {
        private IRepositorioUsuario _repo;

        public CambiarContrasenaUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public void Execute(int id, CambiarContrasenaDTO datosCambio)
        {
            if (datosCambio.ContrasenaActual == datosCambio.ContrasenaNueva)
                throw new ContrasenaException("Las contraseñas deben ser diferentes");

            _repo.UpdateContrasena(id, datosCambio.ContrasenaActual, datosCambio.ContrasenaNueva);

        }
    }
}
