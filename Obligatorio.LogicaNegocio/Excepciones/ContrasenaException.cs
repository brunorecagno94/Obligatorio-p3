namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class ContrasenaException: LogicaNegocioException
    {
        public ContrasenaException()
        {
        }

        public ContrasenaException(string? message) : base(message)
        {
        }
    }
}
