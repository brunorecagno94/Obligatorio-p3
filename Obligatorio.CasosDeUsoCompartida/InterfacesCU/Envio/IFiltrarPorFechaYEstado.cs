namespace Obligatorio.CasosDeUsoCompartida.InterfacesCU.Envio
{
    public interface IFiltrarPorFechaYEstado<T>
    {
        IEnumerable<T> Execute(int idUsuario, DateTime fechaInicio, DateTime fechaFin, string estado);
    }
}