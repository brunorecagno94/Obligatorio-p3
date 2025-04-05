namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class CalleException : LogicaNegocioExpception
    {
        public CalleException() { }
        public CalleException(string? message) : base(message) { }
    }
}
