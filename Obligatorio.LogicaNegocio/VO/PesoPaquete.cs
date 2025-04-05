using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.LogicaNegocio.VO
{
    public record PesoPaquete
    {
        public float Value { get; }
        public PesoPaquete(float value)
        {
            Value = value;
            Validar();
        }
        private void Validar()
        {
            if (Value <= 0)
                throw new PesoPaqueteException("Peso inválido");
        }
    }
}
