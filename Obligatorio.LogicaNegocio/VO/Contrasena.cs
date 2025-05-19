using Obligatorio.LogicaNegocio.Excepciones;
using System.Text.RegularExpressions;

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
            if (Value.Length < 6)
                throw new ContrasenaException("La contraseña debe tener al menos 6 caracteres");

            if (!Regex.IsMatch(Value, @"[A-Za-z]"))
                throw new ContrasenaException("La contraseña debe contener al menos una letra");

            if (!Regex.IsMatch(Value, @"\d"))
                throw new ContrasenaException("La contraseña debe contener al menos un número");

            if (!Regex.IsMatch(Value, @"[\W_]"))
                throw new ContrasenaException("La contraseña debe contener al menos un carácter especial");
        }
    }
}
