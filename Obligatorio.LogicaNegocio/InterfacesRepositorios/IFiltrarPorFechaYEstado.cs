namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioFiltrarPorFechaYEstado<T>
    {
        IEnumerable<T> FiltrarPorFechaYEstado(int idUsuario, DateTime fechaInicio, DateTime fechaFin, string estado);
    }
}