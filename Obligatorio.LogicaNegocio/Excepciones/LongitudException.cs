namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class LongitudException : LogicaNegocioException
    {
        public LongitudException() { }

        public LongitudException(string? message) : base(message) { }
    }
}
