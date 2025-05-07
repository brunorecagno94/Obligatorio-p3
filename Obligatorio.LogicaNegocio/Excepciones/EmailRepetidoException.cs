namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class EmailRepetidoException : LogicaNegocioException
    {
        public EmailRepetidoException() { }
        public EmailRepetidoException(string? message) : base(message) { }
    }
}

