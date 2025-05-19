using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.LogicaNegocio.VO
{
    public record Estado
    {
        public string Value { get; }
        public Estado() { }

        public Estado(string value)
        {
            Value = value;
            Validar();
        }


        public void Validar()
        {

            if (string.IsNullOrEmpty(Value)) throw new EstadoException("Estado inválido");
        }
    }
}
