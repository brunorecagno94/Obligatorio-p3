
namespace Obligatorio.CasosDeUsoCompartida.InterfacesCU
{
    public interface IUpdate<T>
    {
        void Execute(int id, T obj);
    }
}
