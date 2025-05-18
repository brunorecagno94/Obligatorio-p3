
namespace Obligatorio.CasosDeUsoCompartida.InterfacesCU.Envio
{
    public interface IGetAllComentarios<T>
    {
        IEnumerable<T> Execute(int id);
    }
}
