namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class LoginErrorException : LogicaNegocioException
    {
        public LoginErrorException()
        {
        }

        public LoginErrorException(string? message) : base(message)
        {
        }
    }
}
