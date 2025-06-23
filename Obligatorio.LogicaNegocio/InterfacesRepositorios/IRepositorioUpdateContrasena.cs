
namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUpdateContrasena
    {
        void UpdateContrasena(int id, string contrasenaActual, string contrasenaNueva);
    }
}
