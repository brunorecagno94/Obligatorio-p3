namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class CodigoPostalException : LogicaNegocioException
    {
        public CodigoPostalException() { }
        public CodigoPostalException(string? message) : base(message) { }
    }
}
