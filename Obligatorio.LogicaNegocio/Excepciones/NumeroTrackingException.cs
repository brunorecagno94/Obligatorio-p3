
namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class NumeroTrackingException: LogicaNegocioException
    {
        public NumeroTrackingException()
        {
        }

        public NumeroTrackingException(string? message) : base(message)
        {
        }
    }
}
