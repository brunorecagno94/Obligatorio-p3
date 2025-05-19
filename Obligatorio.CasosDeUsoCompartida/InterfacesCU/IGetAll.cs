namespace Obligatorio.CasosDeUsoCompartida.InterfacesCU
{
    public interface IGetAll<T>
    {
        IEnumerable<T> Execute();
    }
}
