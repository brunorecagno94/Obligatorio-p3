
using System.Runtime.Serialization;
using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.Infraestructura.AccesoDatos.Exceptiones
{
    public abstract class InfraestructuraException: Exception
    {
        string _message;
        public InfraestructuraException()
        {
        }

        public InfraestructuraException(string? message) : base(message)
        {
            _message = message;
        }

        protected InfraestructuraException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public abstract int statusCode();

        public Error Error()
        {
            return new Error(
                statusCode(),
                _message
                );

        }

    }
}
