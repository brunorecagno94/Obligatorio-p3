namespace Obligatorio.CasosDeUsoCompartida.InterfacesCU
{
    public interface IGetByEmail<T>
    {
        T Execute(string email);
    }
}
