

namespace Obligatorio.Infraestructura.AccesoDatos.Exceptiones
{
    public class NotFoundException: InfraestructuraException
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string? message) : base(message)
        {
        }

        public override int statusCode()
        {
            return 404;
        }
    }
}
