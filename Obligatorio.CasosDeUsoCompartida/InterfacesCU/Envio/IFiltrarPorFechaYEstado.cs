namespace Obligatorio.CasosDeUsoCompartida.InterfacesCU.Envio
{
    public interface IFiltrarPorFechaYEstado<T>
    {
        IEnumerable<T> Execute(DateTime fechaInicio, DateTime fechaFin, string estado);
    }
}