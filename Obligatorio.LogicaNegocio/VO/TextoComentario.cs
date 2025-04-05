using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.LogicaNegocio.VO
{
    public record TextoComentario
    {
        public string Value { get; }
        public TextoComentario(string value)
        {
            Value = value;
            Validar();
        }
        private void Validar()
        {
            if (string.IsNullOrEmpty(Value))
                throw new TextoComentarioException("Teléfono inválido");
        }
    }
}
