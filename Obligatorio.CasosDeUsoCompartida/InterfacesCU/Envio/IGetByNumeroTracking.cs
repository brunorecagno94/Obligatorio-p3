namespace Obligatorio.CasosDeUsoCompartida.InterfacesCU.Envio
{
    public interface IGetByNumeroTracking<Envio>
    {
        Envio Execute(int numeroTracking);
    }
}
