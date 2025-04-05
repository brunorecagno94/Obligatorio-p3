using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.LogicaNegocio.VO
{
    public record Telefono
    {
        public string Value { get; }

        public Telefono(string value)
        {
            Value = value;
            Validar();
        }
        private void Validar()
        {
            if (string.IsNullOrEmpty(Value))
                throw new TelefonoException("Teléfono inválido");
        }
    }
}
