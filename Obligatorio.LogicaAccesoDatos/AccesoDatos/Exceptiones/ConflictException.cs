
using System.Runtime.Serialization;

namespace Obligatorio.Infraestructura.AccesoDatos.Exceptiones
{
    public class ConflictException : InfraestructuraException
    {
        public ConflictException()
        {
        }

        public ConflictException(string? message) : base(message)
        {
        }

        protected ConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override int statusCode()
        {
            return 400;
        }
    }
}
