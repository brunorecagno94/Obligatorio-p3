
using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.LogicaNegocio.VO
{
    public record NumeroTracking
    {
        public string Value { get; }

        public NumeroTracking(string value)
        {
            Value = value;
            Validar();
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Value)) throw new NumeroTrackingException("Numero de tracking inválido");
        }
    }
}
