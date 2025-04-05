namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class PesoPaqueteException : LogicaNegocioExpception
    {
        public PesoPaqueteException() { }
        public PesoPaqueteException(string? message) : base(message) { }
    }
}