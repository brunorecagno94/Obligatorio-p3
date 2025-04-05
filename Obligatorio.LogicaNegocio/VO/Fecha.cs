using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.LogicaNegocio.VO
{
    public record Fecha
    {
        public DateTime Value { get; }

        public Fecha(DateTime value)
        {
            Value = value;
            Validar();
        }

        public void Validar()
        {
            if (Value == DateTime.MinValue) throw new FechaException("Fecha inválida");
            

            if (Value > DateTime.Now) throw new FechaException("Fecha inválida");
        }

    }
}
