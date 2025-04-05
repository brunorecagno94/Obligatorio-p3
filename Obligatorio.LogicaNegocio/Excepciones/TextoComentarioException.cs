namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class TextoComentarioException : LogicaNegocioExpception
    {
        public TextoComentarioException() { }
        public TextoComentarioException(string? message) : base(message) { }
    }
}
