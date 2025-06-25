namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioFiltrarPorFechaYEstado<T>
    {
        IEnumerable<T> FiltrarPorFechaYEstado(DateTime fechaInicio, DateTime fechaFin, string estado);
    }
}