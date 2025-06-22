using System.Runtime.Serialization;

namespace Obligatorio.Infraestructura.AccesoDatos.Exceptiones
{
    public class UnauthorizedException : InfraestructuraException
    {
        public UnauthorizedException()
        {
        }

        public UnauthorizedException(string? message) : base(message)
        {
        }

        protected UnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override int statusCode()
        {
            return 401;
        }
    }
}
