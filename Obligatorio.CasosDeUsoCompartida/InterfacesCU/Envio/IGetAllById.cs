namespace Obligatorio.CasosDeUsoCompartida.InterfacesCU.Envio
{
    public interface IGetAllById<T>
    {
        IEnumerable<T> Execute(int id);
    }
}
