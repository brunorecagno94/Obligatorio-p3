namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class PesoPaqueteException : LogicaNegocioException
    {
        public PesoPaqueteException() { }
        public PesoPaqueteException(string? message) : base(message) { }
    }
}