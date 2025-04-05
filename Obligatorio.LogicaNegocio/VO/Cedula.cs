using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.LogicaNegocio.VO
{
    public record Cedula
    {
        public string Value { get; }
        public Cedula(string value)
        {
            Value = value;
            Validar();
        }
        private void Validar()
        {
            if (string.IsNullOrEmpty(Value))
                throw new TelefonoException("Cédula inválida");
        }
    }
}
