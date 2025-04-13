namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class CalleException : LogicaNegocioException
    {
        public CalleException() { }
        public CalleException(string? message) : base(message) { }
    }
}
