namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class EstadoException : LogicaNegocioException
    {
        public EstadoException()
        {
        }

        public EstadoException(string? message) : base(message)
        {
        }
    }
}
