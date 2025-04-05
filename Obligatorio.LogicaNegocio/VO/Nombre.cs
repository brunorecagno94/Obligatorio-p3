using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.LogicaNegocio.VO
{
    public record Nombre
    {
        public string Value { get; }

        public Nombre(string value)
        {
            Value = value;
            Validar();
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Value)) throw new NombreException("Nombre inválido");
            
        }
    }
}
