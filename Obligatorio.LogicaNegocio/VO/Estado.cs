using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.LogicaNegocio.VO
{
    public record Estado
    {
        //public static readonly Estado EnProceso = new Estado("EnProceso");
        //public static readonly Estado Finalizado = new Estado("Finalizado");

        public string Value { get; }

        public Estado(string value)
        {
            Value = value;
            Validar();
        }

        public void Validar() {

            if (string.IsNullOrEmpty(Value)) throw new EstadoException("Estado inválido");
        }
    }
}
