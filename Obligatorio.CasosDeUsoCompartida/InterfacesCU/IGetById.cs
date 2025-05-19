namespace Obligatorio.CasosDeUsoCompartida.InterfacesCU
{
    public interface IGetById<T>
    {
        T Execute(int id);
    }
}
