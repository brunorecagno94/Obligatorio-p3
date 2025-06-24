
namespace Obligatorio.CasosDeUsoCompartida.InterfacesCU.Envio
{
    public interface IBuscarEnviosPorComentario<T>
    {
        IEnumerable<T> Execute(int id, string comentario);
    }
}
