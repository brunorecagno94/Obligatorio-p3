namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class LongitudException : LogicaNegocioExpception
    {
        public LongitudException() { }

        public LongitudException(string? message) : base(message) { }
    }
}
