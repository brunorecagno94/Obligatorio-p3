namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class FechaException : LogicaNegocioException
    {
        public FechaException()
        {
        }

        public FechaException(string? message) : base(message)
        {
        }
    }
}
