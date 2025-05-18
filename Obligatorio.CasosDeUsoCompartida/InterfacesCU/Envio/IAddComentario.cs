
namespace Obligatorio.CasosDeUsoCompartida.InterfacesCU.Envio
{
    public interface IAddComentario
    {
       void Execute(string textoComentario, int empleadoId, int envioId);
    }
}
