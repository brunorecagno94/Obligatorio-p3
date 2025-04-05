namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class CodigoPostalException : LogicaNegocioExpception
    {
        public CodigoPostalException() { }
        public CodigoPostalException(string? message) : base(message) { }
    }
}
