using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.LogicaNegocio.VO
{
    public record Contrasena
    {
        public string Value { get; }

        public Contrasena(string value)
        {
            Value = value;
            Validar();
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Value)) throw new ContrasenaException("Contraseña inválido");
        }
    }
}
