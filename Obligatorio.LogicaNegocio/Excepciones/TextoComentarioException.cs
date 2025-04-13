namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class TextoComentarioException : LogicaNegocioException
    {
        public TextoComentarioException() { }
        public TextoComentarioException(string? message) : base(message) { }
    }
}
