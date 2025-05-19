namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class AgenciaNulaException : LogicaNegocioException
    {
        public AgenciaNulaException() { }
        public AgenciaNulaException(string? message) : base(message) { }
    }
}
