
namespace Obligatorio.CasosDeUsoCompartida.InterfacesCU
{
    public interface IGetByNumeroTracking<Envio>
    {
        Envio Execute(int numeroTracking);
    }
}
